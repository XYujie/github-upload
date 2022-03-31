using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Xml;



namespace _4Test
{
    public class IFTagManager
    {
        #region Fields
        public static bool argTExist = RunEnviroment.argumentFlagT;

        //KatouTsuyoshi 20110302 add start --- [82654]The IF-TAG has the empty node only, this method judges no accept.
        public static string returnMessage = string.Empty;
        //KatouTsuyoshi 20110302 add end   --- [82654]The IF-TAG has the empty node only, this method judges no accept.

        // 2015.01.16 add start --- AtOnceを通過したかどうかの判断ロジック変更 [Benkei:113959]
        //KatouTsuyoshi 2010.12.28 add start --- AtOnceが処理されたか、されていないかのFlag
        private static bool tempAtOnceTrueFlag = false;
        //KatouTsuyoshi 2010.12.28 add end   --- AtOnceが処理されたか、されていないかのFlag
        // 2015.01.16 add end   --- AtOnceを通過したかどうかの判断ロジック変更 [Benkei:113959]

        private static string[] acceptLangs = { ITSecurityConstants.IFja, ITSecurityConstants.IFen };
        private static string[] acceptOSs = {ITSecurityConstants.IFOSXP,ITSecurityConstants.IFOS2003,ITSecurityConstants.IFOSVista,
                                               ITSecurityConstants.IFOS2008,ITSecurityConstants.IFOS7,ITSecurityConstants.IFOS2008R2};

        //KatouTsuyoshi 20110905 add start -- implement the new if attribute
        private static string selectedUserManagementOnGUI = string.Empty;
        private static string selectedModelTypeOnGUI = string.Empty;
        //KatouTsuyoshi 20110905 add start -- implement the new if attribute

        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        //初期値はConditionのSverを入れておく
        private static string displayedITSecurityVersion = string.Empty;
        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)

        // ISE 2017.08.21 add start [R11.03.00] csf解析ツール機能拡張対応
#if DEBUG
        private static string selectedOsVersionOnGUI = string.Empty;
        private static string selectedLanguageOnGUI = string.Empty;
        //private static ConditionFileLibrary.ConditionFileLibrary.DomainLinkageStatus selectedDLMStatusOnGUI = ConditionFileLibrary.ConditionFileLibrary.DomainLinkageStatus.Non;
#endif
        // ISE 2017.08.21 add end [R11.03.00]
        #endregion
        #region Propeties
        // 2015.01.16 add start --- AtOnceを通過したかどうかの判断ロジック変更 [Benkei:113959]
        // 外部からの明示的な操作は不可
        //public static bool TempAtOnceTrueFlag
        //{
        //    set { tempAtOnceTrueFlag = value; }
        //    get { return atOnceTrueFlag; }
        //}
        // 2015.01.16 add end   --- AtOnceを通過したかどうかの判断ロジック変更 [Benkei:113959]

        //KatouTsuyoshi 20110905 add start -- implement the new if attribute
        public static string SelectedUserManagementOnGUI
        {
            set { selectedUserManagementOnGUI = value; }
            get { return selectedUserManagementOnGUI; }
        }

        public static string SelectedModelTypeOnGUI
        {
            set { selectedModelTypeOnGUI = value; }
            get { return selectedModelTypeOnGUI; }
        }

        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        public static string DisplayedITSecurityVersion
        {
            set { displayedITSecurityVersion = value; }
        }
        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        // ISE 2017.08.21 add start [R11.03.00] csf解析ツール機能拡張対応
#if DEBUG
        public static string SelectedOsVersionOnGUI
        {
            set { selectedOsVersionOnGUI = value; }
        }
        public static string SelectedLanguageOnGUI
        {
            set { selectedLanguageOnGUI = value; }
        }
        //public static ConditionFileLibrary.ConditionFileLibrary.DomainLinkageStatus SelectedDLMStatusOnGUI
        //{
        //    set { selectedDLMStatusOnGUI = value; }
        //}
#endif
        // ISE 2017.08.21 add end [R11.03.00]
        //KatouTsuyoshi 20110905 add start -- implement the new if attribute
        #endregion

        public static XmlNode RemoveIFTag(XmlNode sourceRootNode, ref bool isPerformedAtonce)
        {
            XmlNode returnXMLNode = sourceRootNode.Clone();
            if (sourceRootNode.Name.Equals(ITSecurityConstants.XmlNodeIfTag, StringComparison.InvariantCultureIgnoreCase))
            {
                ISecurityItem settingItem = new IFTag();
                int iRoopCount = 0;

                if (settingItem != null)
                {
                    try
                    {
                        bool ifRet = settingItem.LoadFromXML(sourceRootNode); 

                        // LoadFromXML内部のCheckRunCondition()を実行した結果、atOnceが処理されていれば
                        // IFTagManagerのtempAtOnceTruFlagがTrueになっている。
                        if (IFTagManager.tempAtOnceTrueFlag)
                        {
                            isPerformedAtonce = true;
                        }

                        // [JA_JP] IF処理FalseならNullをTrueなら子供(達)だけをReturnする。
                        if (!ifRet)
                        {
                            //returnXMLNode.RemoveAll();
                            return null;
                        }
                        else
                        {
                            //KatouTsuyoshi 20110302 add start --- [82654]The IF-TAG has the empty node only, this method judges no accept.
                            if (returnXMLNode.ChildNodes.Count == 0)
                            {
                                returnMessage = @"Cannot find the child node. Thus the following IF-TAG was removed.";
                                return null;
                            }
                            //KatouTsuyoshi 20110302 add end   --- [82654]The IF-TAG has the empty node only, this method judges no accept.

                            XmlNode tempNode = returnXMLNode.FirstChild.Clone(); //<Commands> data </Commands>
                            XmlNodeList souceChildList = returnXMLNode.ChildNodes;

                            //[JA_JP] IF以下が１つ以上のChildNodeを持っている場合、First以降にInsertしていく。
                            if (souceChildList.Count > 1)
                            {
                                foreach (XmlNode iterNode in souceChildList)
                                {
                                    if (iRoopCount != 0)
                                    {
                                        tempNode.InsertAfter(iterNode, tempNode.LastChild);
                                    }
                                    iRoopCount++;
                                }
                            }
                            return tempNode;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                
            }
            return returnXMLNode;
        }

        public static bool CheckRunCondition(string attributeName, List<string> attributeValueList, string ifOperator)
        {
            // [JA_JP] Null,Emptyチェック
            if (String.IsNullOrEmpty(attributeName))
            {
                return false;
            }
            if (attributeValueList.Contains(null))
            {
                return false;
            }
            if (String.IsNullOrEmpty(ifOperator))
            {
                return false;
            }

            // [JA_JP] 比較用のList作成
            List<string> acceptLangList = new List<string>();
            List<string> acceptOSList = new List<string>();
            List<string> acceptTagList = new List<string>();

            foreach (string str in acceptLangs)//acceptsLangs("ja","en")
            {
                acceptLangList.Add(str);
            }
            foreach (string str in acceptOSs)//acceptsOSs("xp","2003","vista","2008","7","2008r2")
            {
                acceptOSList.Add(str);
            }
            //foreach (string str in RunEnviroment.argumentValueT)
            //{
            //    acceptTagList.Add(str);
            //}
           
            acceptTagList.Add(ITSecurityConstants.IF_ALL);


            string tempName = attributeName.ToLower();
            bool retAccept = false;
            string convertedValue = string.Empty;

            //[JA_JP] 比較に使うソース情報を各情報元から取得
            string culture = System.Globalization.CultureInfo.CurrentCulture.ToString().ToLower();
            if (!string.IsNullOrEmpty(selectedLanguageOnGUI))
            {
                // 画面入力があれば、値を上書きする
                culture = selectedLanguageOnGUI.ToLower();
            }
            string osVer = RunEnviroment.CurrentOSMajorMinor + ITSecurityConstants.IFVersionProductTypeSeparater + GetOSProductType();
            string osVerWithBuildNumber = RunEnviroment.CurrentOSMajorMinorBuildNumber + ITSecurityConstants.IFVersionProductTypeSeparater + GetOSProductType();
            if (RunEnviroment.CurrentOSMajorMinor == "5.1" || RunEnviroment.CurrentOSMajorMinor == "6.0" || RunEnviroment.CurrentOSMajorMinor == "6.1")
            {
                osVer = RunEnviroment.CurrentOSMajorMinor + ITSecurityConstants.IFVersionProductTypeSeparater + "1";
            }
            //osVer = "10.0:1"
            //osVerWithBuildNumber = "10.0.18363:1"
            if (!string.IsNullOrEmpty(selectedOsVersionOnGUI))
            {
                // 画面入力があれば、値を上書きする
                osVer = selectedOsVersionOnGUI.ToLower();
                //Yujie 2022/02/24 Only overwrite osVer could cause leave out RunEnvironMent osVerWithBuildNumber"
                osVerWithBuildNumber = selectedOsVersionOnGUI.ToLower();
            }
            if (tempName.Equals(ITSecurityConstants.XmlAttributeTag, StringComparison.InvariantCultureIgnoreCase))
            #region /T check logic
            {
                foreach (string tempValue in attributeValueList)
                {
                    //KatouTsuyoshi 20101212 add start --- _ALLが含まれている場合はOperatorに関係なく常に処理対象とする。
                    List<string> checkAll = new List<string>(attributeValueList);
                    foreach (string isAll in checkAll)
                    {
                        string lowerAll = isAll.ToLower();
                        if (lowerAll.Equals(ITSecurityConstants.IF_ALL, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return true;
                        }
                    }
                    //KatouTsuyoshi 20101212 add end   --- _ALLが含まれている場合はOperatorに関係なく常に処理対象とする。

                    if (ifOperator.ToLower().Equals(ITSecurityConstants.IFEqual))
                    {
                        retAccept = checkTagName(tempValue.ToLower(), acceptTagList);
                        //KatouTsuyoshi 20101212 add start --- EqualはOR処理とする。ひとつでもTrueならTrueを返す。
                        if (retAccept)
                        {
                            return retAccept;
                        }
                        //KatouTsuyoshi 20101212 add end   --- EqualはOR処理とする。ひとつでもTrueならTrueを返す。
                    }
                    else if (ifOperator.ToLower().Equals(ITSecurityConstants.IFNotEqual))
                    {
                        retAccept = !checkTagName(tempValue.ToLower(), acceptTagList);
                        //KatouTsuyoshi 20101211 add start --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                        if (!retAccept)
                        {
                            return retAccept;
                        }
                        //KatouTsuyoshi 20101211 add end   --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                    }
                }
                return retAccept;
            }
            #endregion
            else
            {
                foreach (string tempValue in attributeValueList)
                {
                    switch (tempName.ToLower())
                    {
                        #region OS
                        case ITSecurityConstants.XmlAttributeOS:
                            if (ifOperator.ToLower().Equals(ITSecurityConstants.IFEqual))
                            {
                                convertedValue = checkOSVersion(tempValue);
                                if (osVer.StartsWith(convertedValue.ToLower()) 
                                    || osVerWithBuildNumber.StartsWith(convertedValue.ToLower()))
                                {
                                    retAccept = true;
                                }
                            }
                            else if (ifOperator.ToLower().Equals(ITSecurityConstants.IFNotEqual))
                            {
                                convertedValue = checkOSVersion(tempValue);
                                if (convertedValue.Equals(ITSecurityConstants.IFError, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    retAccept = false;
                                }
                                if (!osVer.StartsWith(convertedValue.ToLower())
                                    && !osVerWithBuildNumber.StartsWith(convertedValue.ToLower()))
                                {
                                    retAccept = true;
                                }
                                //KatouTsuyoshi 20101211 add start --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                                else if (osVer.StartsWith(convertedValue.ToLower())
                                    || osVerWithBuildNumber.StartsWith(convertedValue.ToLower()))
                                {
                                    retAccept = false;
                                    return retAccept;
                                }
                                //KatouTsuyoshi 20101211 add end   --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                            }
                            break;
                        #endregion
                        default:
                            break;
                    }
                }
            }
            return retAccept;
        }
        public static bool checkTagName(string sourceTagValue, List<string> acceptList)
        {
            foreach (string acceptStr in acceptList)
            {
                if (sourceTagValue.Equals(acceptStr, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        public static string checkOSVersion(string sourceOS)
        {
            string compareString = String.Empty;

            // KatouTsuyoshi 20110304 add start --- for DomainController
            string productType = "3";
            if (!GetOSProductType().Equals("1"))
            {
                productType = GetOSProductType();
            }
            // ISE 2017.08.21 add start [R11.03.00] csf解析ツール機能拡張対応
#if DEBUG
            if (!string.IsNullOrEmpty(selectedOsVersionOnGUI))
            {
                // 画面入力があれば、2固定。
                productType = "2";
            }
#endif
            // ISE 2017.08.21 add end [R11.03.00]
            //KatouTsuyoshi 20140120 edit start --- OS情報の取得をAPI方式からWMI方式に変更
            //(桁無制限数字).(桁無制限数字):(桁無制限数字)に一致する場合は、その値をそのまま返す。
            if (System.Text.RegularExpressions.Regex.IsMatch(sourceOS, @"\d+\.\d+:\d+")
                || System.Text.RegularExpressions.Regex.IsMatch(sourceOS, @"\d+\.\d+\.\d+:\d+"))
            {
                return sourceOS;
            }
            switch (sourceOS.ToLower())
            {
                case ITSecurityConstants.IFOSXP:
                    compareString = ITSecurityConstants.IFXPVersion + ITSecurityConstants.IFVersionProductTypeSeparater + "1";
                    //compareString = "1" + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IFXPVersion;
                    break;
                case ITSecurityConstants.IFOS2003:
                    compareString = ITSecurityConstants.IF2003Version + ITSecurityConstants.IFVersionProductTypeSeparater + productType;
                    //compareString = productType + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IF2003Version;
                    break;
                case ITSecurityConstants.IFOSVista:
                    compareString = ITSecurityConstants.IFVistaVersion + ITSecurityConstants.IFVersionProductTypeSeparater + "1";
                    //compareString = "1" + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IFVistaVersion;
                    break;
                case ITSecurityConstants.IFOS2008:
                    compareString = ITSecurityConstants.IF2008Version + ITSecurityConstants.IFVersionProductTypeSeparater + productType;
                    //compareString = productType + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IF2008Version;
                    break;
                case ITSecurityConstants.IFOS7:
                    compareString = ITSecurityConstants.IF7Version + ITSecurityConstants.IFVersionProductTypeSeparater + "1";
                    //compareString = "1" + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IF7Version;
                    break;
                case ITSecurityConstants.IFOS2008R2:
                    compareString = ITSecurityConstants.IF2008R2Version + ITSecurityConstants.IFVersionProductTypeSeparater + productType;
                    //compareString = productType + ITSecurityConstants.FolderSeparator + ITSecurityConstants.IF2008R2Version;
                    break;
                default:
                    compareString = ITSecurityConstants.IFError;
                    break;
            }
            //KatouTsuyoshi 20140120 edit start --- OS情報の取得をAPI方式からWMI方式に変更
            // KatouTsuyoshi 20110304 add end   --- for DomainController
            return compareString.ToLower();
        }
        public static string GetOSProductType()
        {
            uint productType = 0;
            System.Management.ManagementClass mgmtClass = new System.Management.ManagementClass("Win32_OperatingSystem");
            System.Management.ManagementObjectCollection systemObjectCollection = mgmtClass.GetInstances();
            foreach (System.Management.ManagementObject systemObject in systemObjectCollection)
            {
                productType = (uint)systemObject["ProductType"];
            }
            return productType.ToString();

        }
    }
}
