using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace _4Test
{
   
    class IFTag: ISecurityItem
    {
        #region fields
        private List<string> langList;
        private List<string> osList;
        private List<string> secVersionList;
        private List<string> tagList;
        //KatouTsuyoshi 20110905 add start -- inprement the new if attribute
        private List<string> productList;
        private List<string> selectedUserManagementList;
        private List<string> selectedModelTypeList;
        //KatouTsuyoshi 20110905 add end   -- inprement the new if attribute
        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        private List<string> displayedSverList;
        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        private List<string> lastNBTSettingList;
        private List<string> domainLinkStatus;
        private List<string> ifElements;
        private string ifOperator;
        #endregion
        #region properties
        //KatouTsuyoshi 20110905 add start -- inprement the new if attribute
        public List<string> SelectedModelTypeList
        {
            get
            {
                return this.selectedModelTypeList;
            }
            set
            {
                this.selectedModelTypeList = value;
            }
        }

        public List<string> SelectedUserManagementList
        {
            get
            {
                return this.selectedUserManagementList;
            }
            set
            {
                this.selectedUserManagementList = value;
            }
        }

        public List<string> ProductList
        {
            get
            {
                return this.productList;
            }
            set
            {
                this.productList = value;
            }
        }
        //KatouTsuyoshi 20110905 add end   -- inprement the new if attribute

        public List<string> LangList
        {
            get
            {
                return this.langList;
            }
            set
            {
                this.langList = value;
            }
        }

        public List<string> OSList
        {
            get
            {
                return this.osList;
            }
            set
            {
                this.osList = value;
            }
        }

        public List<string> SecVersionList
        {
            get
            {
                return this.secVersionList;
            }
            set
            {
                this.secVersionList = value;
            }
        }

        public List<string> TagList
        {
            get
            {
                return this.tagList;
            }
            set
            {
                this.tagList = value;
            }
        }

        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        private List<string> DisplayedSverList
        {
            get { return this.displayedSverList; }
            set { this.displayedSverList = value; }
        }
        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        private List<string> LastNBTSetting
        {
            get { return this.lastNBTSettingList; }
            set { this.lastNBTSettingList = value; }
        }

        private List<string> DomainLinkStatus
        {
            get { return this.domainLinkStatus; }
            set { this.domainLinkStatus = value; }
        }

        public string IfOperator
        {
            get
            {
                return this.ifOperator;
            }
            set
            {
                this.ifOperator = value;
            }
        }

        public int ProgressValueWhenGetOrSetOS { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        public IFTag()
        {
            ifElements = null;

            langList = new List<string>();
            osList = new List<string>();
            secVersionList = new List<string>();
            tagList = new List<string>();
            //KatouTsuyoshi 20110905 add start -- implement the new if attribute
            productList = new List<string>();
            selectedUserManagementList = new List<string>();
            selectedModelTypeList = new List<string>();
            //KatouTsuyoshi 20110905 add end   -- implement the new if attribute

            //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
            displayedSverList = new List<string>();
            //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)

            lastNBTSettingList = new List<string>();
            domainLinkStatus = new List<string>();

            ifElements = new List<string>();
            ifOperator = string.Empty;
        }

        public bool LoadFromXML(XmlNode inputXMLNode)
        {
            if (inputXMLNode == null)
            {
                return false;
            }

            List<string> templist = new List<string>();
            bool retcheckCondition = false;
            string tempAttributeName = string.Empty;

            try
            {
                if (inputXMLNode.Name.ToLower() != ITSecurityConstants.XmlNodeIfTag)
                {
                    return false;
                }
                foreach (XmlAttribute xmlAttri in inputXMLNode.Attributes)
                {
                    switch (xmlAttri.Name.ToLower())
                    {
                        case ITSecurityConstants.XmlAttributeLang:
                            this.LangList = ListConverter(xmlAttri.Value);
                            templist = this.LangList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeOS:
                            this.OSList = ListConverter(xmlAttri.Value);
                            templist = this.OSList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeSVer:
                            this.SecVersionList = ListConverter(xmlAttri.Value);
                            templist = this.SecVersionList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeTag:
                            //KatouTsuyoshi 20101211 add start --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                            //this.TagList.Add(xmlAttri.Value);
                            this.TagList = ListConverter(xmlAttri.Value);
                            //KatouTsuyoshi 20101211 add end   --- NotEqualは&&処理とする。ひとつでもFalseならFalseで返す。
                            templist = this.TagList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        //KatouTsuyoshi 20101224 add start --- AtOnce
                        case ITSecurityConstants.XmlAttributeAtOnce:
                            this.TagList = ListConverter(xmlAttri.Value);
                            templist = this.TagList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        //KatouTsuyoshi 20101224 add end   --- AtOnce
                        //KatouTsuyoshi 20110905 add start -- implement the new if attribute
                        case ITSecurityConstants.XmlAttributeProduct:
                            this.ProductList = ListConverter(xmlAttri.Value);
                            templist = this.ProductList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeSelectedUserManagement:
                            this.SelectedUserManagementList = ListConverter(xmlAttri.Value);
                            templist = this.SelectedUserManagementList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeSelectedModelType:
                            this.SelectedModelTypeList = ListConverter(xmlAttri.Value);
                            templist = this.SelectedModelTypeList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        //KatouTsuyoshi 20110905 add end   -- implement the new if attribute
                        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
                        case ITSecurityConstants.XmlAttributeDisplayedSecurityVersion:
                            this.DisplayedSverList = ListConverter(xmlAttri.Value);
                            templist = this.displayedSverList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得
                        case ITSecurityConstants.XmlAttributeIFTagLastNBTSetting:
                            this.LastNBTSetting = ListConverter(xmlAttri.Value);
                            templist = this.lastNBTSettingList;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeIFTagDomainLinkStatus:
                            this.DomainLinkStatus = ListConverter(xmlAttri.Value);
                            templist = this.domainLinkStatus;
                            tempAttributeName = xmlAttri.Name.ToLower();
                            break;
                        case ITSecurityConstants.XmlAttributeOperator:
                            this.IfOperator = xmlAttri.Value;
                            break;
                        default:
                            break;
                    }
                }
                //Below just Added FOR SIMULATION!
                IFTagManager.SelectedOsVersionOnGUI = "10.0.17763:2";
                retcheckCondition = IFTagManager.CheckRunCondition(tempAttributeName, templist, this.IfOperator);
            }
            catch (XmlException e)
            {
                return false;
            }
            return retcheckCondition;
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

        public static string[] ListConverter(XmlNode sourceNode)
        {

            string[] AttributeArry = { "", "", "", "" };
            int loop = 0;
            foreach (XmlAttribute attribute in sourceNode.Attributes)
            {
                if (!attribute.Name.ToLower().Equals(ITSecurityConstants.XmlAttributeOperator, StringComparison.InvariantCultureIgnoreCase))
                {
                    IFTag tmpObj = new IFTag();
                    string rkeytocsvString = attribute.Value;
                    List<string> valueList = new List<string>();
                    if (attribute.Value.Contains(ITSecurityConstants.GuidSeperator))
                    {
                        valueList = tmpObj.ConvertCSVtoList(tmpObj.ConvertReserveKey(attribute.Value));
                        rkeytocsvString = string.Empty;
                        foreach (string str in valueList)
                        {
                            rkeytocsvString += str + ITSecurityConstants.IFComma;
                        }
                        rkeytocsvString = rkeytocsvString.TrimEnd(',');
                    }
                    AttributeArry[loop] = attribute.Name;
                    AttributeArry[loop + 2] = rkeytocsvString;
                }
                else
                {
                    AttributeArry[loop] = attribute.Name;
                    AttributeArry[loop + 2] = attribute.Value;
                }
                loop++;

            }
            return AttributeArry;  //AttributeArry = {"os","operator","10.0.18363:1","EQ"}


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

        public XmlNode GetOutputData(XmlDocument xmlDoc)
        {
            throw new NotImplementedException();
        }

        public XmlNode SaveToXML(XmlDocument securityDom)
        {
            throw new NotImplementedException();
        }

        public bool ReadFromOS()
        {
            throw new NotImplementedException();
        }

        public bool SetToOS()
        {
            throw new NotImplementedException();
        }

        public bool SetToGPO()
        {
            throw new NotImplementedException();
        }

    }
}
