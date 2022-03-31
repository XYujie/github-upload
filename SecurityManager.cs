using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4Test
{
    public class SecurityManager
    {
        #region Field
        private List<ISecurityItem> settingItemArray = new List<ISecurityItem>();
        // KatouTsuyoshi 2014.02.14 mod start --- File/Folderの64bit保存
        //private List<string> exportTopFolder = new List<string>();
        // KatouTsuyoshi 2014.02.14 mod end   --- File/Folderの64bit保存

        //ISE-14.02.07 [R10.03.00] レジストリのアクセス権保存 変更
        //        private List<string> exportTopRegistryKey = new List<string>();
        //ISE-14.02.07 END
        private string defaultPassword;
        private string errorFile = string.Empty; // add begin 2010/06/03 motonaga No.39

        //YangJiannan 2010/11/29 add start --- HeaderとBody無くす対応
        private Dictionary<string, List<string>> headerDictionary;
        private Dictionary<string, List<string>> headerDisplayNameDictionary;
        private bool atOnceTrueFlag = false;
        private Guid secMgrGUID = Guid.Empty;
        private int progressMaximum = 0;

        private string definitionFileFullName = string.Empty;
        private string securityVersion = string.Empty;
        private string productVersion = string.Empty;
        private string includeHardeningFolder = string.Empty;
        private string hardeningSecVer = string.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SecurityManager()
        {
            this.settingItemArray = new List<ISecurityItem>();

            //YangJiannan 2010/11/29 add start --- HeaderとBody無くす対応
            this.headerDictionary = new Dictionary<string, List<string>>();
            this.headerDisplayNameDictionary = new Dictionary<string, List<string>>();
            //YangJiannan 2010/11/29 add end --- HeaderとBody無くす対応

            //YangJiannan 2010/11/30 add start --- UI修正
            ReserveKeyManager.GetInstance().Clear();
            //YangJiannan 2010/11/30 add start --- UI修正

            //KatouTsuyoshi 20140417 mod start --- [Benkei:103614] RemovableMediaの設定値マージ処理対応
            this.secMgrGUID = Guid.NewGuid();
            //KatouTsuyoshi 20140417 mod end   --- [Benkei:103614] RemovableMediaの設定値マージ処理対応

        }
        #endregion

        public XmlDocument ConvertXML(XmlDocument xmlDoc)
        {
            try
            {
                XmlNodeList IF_Or_IncList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_IncNode);
                while (IF_Or_IncList.Count != 0)
                {
                    XmlNode IF_Rrv_IncNode = xmlDoc.SelectSingleNode(ITSecurityConstants.XPathTopNodeIF_IncNode);
                    //Console.WriteLine(IF_Rrv_IncNode.InnerXml);
                    //Console.WriteLine("------------------------------");
                    switch (IF_Rrv_IncNode.Name.ToLower())
                    {
                        case ITSecurityConstants.XmlNodeIfTag:
                            foreach (XmlAttribute xmlAttri in IF_Rrv_IncNode.Attributes)
                            {
                                if (!xmlAttri.Name.ToString().ToLower().Equals(ITSecurityConstants.XmlAttributeTag, StringComparison.InvariantCultureIgnoreCase) && !xmlAttri.Name.ToString().ToLower().Equals(ITSecurityConstants.XmlAttributeOperator, StringComparison.InvariantCultureIgnoreCase) && xmlAttri.Value.ToString().Contains(ITSecurityConstants.LeftReserveSeperator) && xmlAttri.Value.ToString().Contains(ITSecurityConstants.RightReserveSeperator))
                                {

                                    if (!CheckIfAndLoadReserveKey(xmlDoc))
                                    {
                                        //WriteMessage(MessageType.ERROR, string.Format(Resource.Log_Error_GetReserveName, xmlAttri.Value.ToString()));

                                    }
                                }
                            }
                            //Console.WriteLine(IF_Rrv_IncNode.InnerXml); //for comfirm results 
                            //RemoveIFTag
                            XmlNode TrueNode = IFTagManager.RemoveIFTag(IF_Rrv_IncNode, ref this.atOnceTrueFlag);
                            if (TrueNode == null)
                            {
                                string iftagStr = IF_Rrv_IncNode.OuterXml.ToString();
                                IF_Rrv_IncNode.ParentNode.RemoveChild(IF_Rrv_IncNode);
                                string[] ifNodeLog = IFTag.ListConverter(IF_Rrv_IncNode);
                                if (!IFTagManager.argTExist)
                                {

                                }
                            }
                            else
                            {
                                foreach (XmlNode tempNode in IF_Rrv_IncNode.ChildNodes)
                                {
                                    XmlNode importedNode = xmlDoc.ImportNode(tempNode, true);
                                    IF_Rrv_IncNode.ParentNode.InsertBefore(importedNode, IF_Rrv_IncNode);
                                }
                                IF_Rrv_IncNode.ParentNode.RemoveChild(IF_Rrv_IncNode);
                                string[] ifNodeLog = IFTag.ListConverter(IF_Rrv_IncNode);
                                //Console.WriteLine(IF_Rrv_IncNode.InnerXml);
                            }
                            break;
                        default:
                            break;
                    }
                    IF_Or_IncList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_IncNode);
                    

                }
            }

            catch (Exception e)
            {
                return null;
            }
            return xmlDoc;
        }

        public bool CheckIfAndLoadReserveKey(XmlDocument xmlDoc)
        {
            ReserveKeyManager.GetInstance().Clear();
            bool retval = false;
            try
            {
                XmlNodeList if_RrvList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_RrvNode);
                foreach (XmlNode node in if_RrvList)
                {
                    if (node.Name.ToLower().Equals(ITSecurityConstants.XmlNodeIfTag, StringComparison.InvariantCultureIgnoreCase))
                    {
                        string setedValue = string.Empty;

                        if (!ConvertFirstIF(node, out setedValue))
                        {

                        }

                        break;
                    }

                    else
                    {

                        XmlNodeList if_SVList = node.SelectNodes(ITSecurityConstants.XPathToLowerIF_SVName);
                        XmlDocument tmpXmlDoc = new XmlDocument();
                        XmlNode reserveNode = tmpXmlDoc.CreateNode(XmlNodeType.Element, "ReserveKey", null);
                        foreach (XmlNode valueNode in if_SVList)
                        {
                            if (valueNode.Name.ToLower().Equals(ITSecurityConstants.XmlNodeIfTag, StringComparison.InvariantCultureIgnoreCase))
                            {
                                break;
                            }
                            else
                            {
                                XmlNode importedValueNode = reserveNode.OwnerDocument.ImportNode(valueNode, true);
                                reserveNode.AppendChild(importedValueNode);
                            }

                        }
                        LoadFromXML(reserveNode);
                    }
                }
                retval = true;
            }
            catch (ArgumentNullException e)
            {
                retval = false;
            }
            catch (Exception e)
            {
                retval = false;
            }
            finally
            {
                ReserveKeyManager.GetInstance().Clear();
            }
            return retval;
        }
        public static bool ConvertFirstIF(XmlNode sourceXML, out string setedValue)
        {

            setedValue = string.Empty;
            foreach (XmlAttribute attri in sourceXML.Attributes)
            {//Ono Masatsohi 2014/01/28 Tag属性を処理しないように変更
                if (!attri.Name.ToLower().Equals(ITSecurityConstants.XmlAttributeTag) && !attri.Name.ToLower().Equals(ITSecurityConstants.XmlAttributeOperator))
                {
                    //string convertedXmlStr = sourceXML.OuterXml;
                    //string convertedAttriValue = attri.Value;
                    setedValue = attri.Value;
                    foreach (string iterKey in ReserveKeyManager.GetInstance().Keys)
                    {
                        string reserveKey = ITSecurityConstants.LeftReserveSeperator + iterKey + ITSecurityConstants.RightReserveSeperator;
                        string reserveValue = ReserveKeyManager.GetInstance()[iterKey];
                        //Console.WriteLine(reserveValue);

                        //convertedXmlStr = ReplaceTopIFName4CaseInsensitive(convertedXmlStr, reserveKey, convertedValue);
                        setedValue = Replace4CaseInsensitive(setedValue, reserveKey, reserveValue);
                    }
                    if (setedValue.Equals(attri.Value))
                    {
                        return false;
                    }
                    attri.Value = setedValue;
                    //Console.WriteLine(attri.Value);
                }
            }

            return true;
        }
        private static string Replace4CaseInsensitive(string srcStr, string oldValue, string newValue)
        {
            string regexStr = string.Empty;
            foreach (char c in oldValue)
            {
                regexStr += "[" + c.ToString().ToLower() + c.ToString().ToUpper() + "]";
            }
            return System.Text.RegularExpressions.Regex.Replace(srcStr, regexStr, newValue);
        }
        public static bool LoadFromXML(XmlNode sourceXML)
        {
            if (sourceXML == null || !sourceXML.Name.Equals(ITSecurityConstants.XmlNodeReserveKey, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            foreach (XmlNode setValueNode in sourceXML.ChildNodes)
            {
                if (setValueNode.Name.Equals(ITSecurityConstants.XmlNodeSetValue, StringComparison.InvariantCultureIgnoreCase))
                {
                    string attrName = string.Empty;
                    string attrValue = string.Empty;
                    bool isAppend = false;

                    foreach (XmlAttribute xmlAttribute in setValueNode.Attributes)
                    {
                        switch (xmlAttribute.Name.ToLower())
                        {
                            case ITSecurityConstants.XmlAttributeName:
                                attrName = xmlAttribute.Value;
                                break;
                            case ITSecurityConstants.XmlAttributeValue:
                                attrValue = xmlAttribute.Value;
                                break;
                            case ITSecurityConstants.XmlAttributeAppend:
                                isAppend = xmlAttribute.Value.Equals(ITSecurityConstants.TrueIntValue) ? true : false;
                                break;
                            //KatouTsuyoshi 2014.01.14 add start --- 定義ファイルの新しい属性値 R10.03.00対応
                            case ITSecurityConstants.XmlAttributeModuleType_LowerCase:
                                break;
                            //KatouTsuyoshi 2014.01.14 add end   --- 定義ファイルの新しい属性値 R10.03.00対応
                            default:
                                break;
                        }
                    }

                    string keyValue = attrValue;
                    // KatouTsuyoshi 2014.02.25 add end   --- ReserveKeyのSetValueにあるSystem32はCreationType64ならNativeにする
                    // KatouTsuyoshi 2014.02.27 add end   --- ReserveKeyのSetValueにあるSystem32はCreationType32ならSysWOW64にする

                    if (!string.IsNullOrEmpty(attrName) && !string.IsNullOrEmpty(keyValue))
                    {
                        if (ReserveKeyManager.GetInstance().ContainsKey(attrName))
                        {
                            if (isAppend)
                            {
                                string currentValue = ReserveKeyManager.GetInstance()[attrName];
                                if (!currentValue.StartsWith(ITSecurityConstants.GuidSeperator))
                                {
                                    currentValue = ITSecurityConstants.GuidSeperator + currentValue;
                                }
                                if (!currentValue.EndsWith(ITSecurityConstants.GuidSeperator))
                                {
                                    currentValue = currentValue + ITSecurityConstants.GuidSeperator;
                                }
                                string newValue = currentValue + keyValue + ITSecurityConstants.GuidSeperator;
                                ReserveKeyManager.GetInstance()[attrName] = newValue;

                                //Debug Print
                            }
                            else
                            {
                                ReserveKeyManager.GetInstance()[attrName] = keyValue;

                                //Debug Print
                            }
                        }
                        else
                        {
                            ReserveKeyManager.GetInstance().Add(attrName, keyValue);
                            //Debug Print
                        }
                    }
                }
            }

            return true;
        }

        private List<string> ListConverter(string data)
        {
            string rkeytocsvString = string.Empty;
            List<string> tmpList = new List<string>();

            if (data.Contains(ITSecurityConstants.GuidSeperator))
            {
                rkeytocsvString = ConvertReserveKey(data);
                if (rkeytocsvString.Contains(ITSecurityConstants.IFComma))
                {
                    return ConvertCSVtoList(rkeytocsvString);
                }
                else
                {
                    tmpList.Clear();
                    tmpList.Add(rkeytocsvString);
                }
            }

            if (data.Contains(ITSecurityConstants.IFComma))
            {
                return ConvertCSVtoList(data);
            }
            else
            {
                tmpList.Clear();
                tmpList.Add(data);
            }
            return tmpList;
        }
        private string ConvertReserveKey(string rkeyData)
        {
            string[] strArray = null;
            string convertedCommaString = string.Empty;

            if (!rkeyData.Contains(ITSecurityConstants.GuidSeperator))
            {
                return rkeyData;
            }
            // GUIDのStringをCommaつきのStringに変換する。
            else
            {
                string[] delimiter = { ITSecurityConstants.GuidSeperator };

                strArray = rkeyData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strArray)
                {
                    convertedCommaString += ITSecurityConstants.IFComma + str;
                }
                return convertedCommaString;
            }
        }
        private List<string> ConvertCSVtoList(string csvData)
        {
            List<string> CSVConvertList = new List<string>();
            string[] strArray = null;

            if (!csvData.Contains(ITSecurityConstants.IFComma))
            {
                CSVConvertList.Clear();
                CSVConvertList.Add(csvData);

                return CSVConvertList;
            }
            else
            {
                CSVConvertList.Clear();
                string[] delimiter = { ITSecurityConstants.IFComma };

                strArray = csvData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strArray)
                {
                    CSVConvertList.Add(str.ToLower());
                }
            }
            return CSVConvertList;
        }
    }
}