using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4Test
{
    class Program
    {
        private bool atOnceTrueFlag = false;
        static void Main(string[] args)
        {
            #region TEST
            //            XmlDocument xmlDoc = new XmlDocument();
            //            xmlDoc.Load("key.xml");
            //            XmlNodeList IF_Or_IncList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_IncNode);
            //            while (IF_Or_IncList.Count != 0)
            //            {
            //                XmlNode IF_Rrv_IncNode = xmlDoc.SelectSingleNode(ITSecurityConstants.XPathTopNodeIF_IncNode);
            //                switch (IF_Rrv_IncNode.Name.ToLower())
            //                {
            //                    case ITSecurityConstants.XmlNodeIfTag:
            //                        foreach (XmlAttribute xmlAttri in IF_Rrv_IncNode.Attributes)
            //                        {
            //                            if (!xmlAttri.Name.ToString().ToLower().Equals(ITSecurityConstants.XmlAttributeTag, StringComparison.InvariantCultureIgnoreCase) && !xmlAttri.Name.ToString().ToLower().Equals(ITSecurityConstants.XmlAttributeOperator, StringComparison.InvariantCultureIgnoreCase) && xmlAttri.Value.ToString().Contains(ITSecurityConstants.LeftReserveSeperator) && xmlAttri.Value.ToString().Contains(ITSecurityConstants.RightReserveSeperator))
            //                            {
            //                                XmlNodeList if_RrvList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_RrvNode);
            //                                foreach (XmlNode node in if_RrvList)
            //                                {
            //                                    if (node.Name.ToLower().Equals(ITSecurityConstants.XmlNodeIfTag, StringComparison.InvariantCultureIgnoreCase))
            //                                    {
            //                                        string setedValue = string.Empty;

            //                                        if (!ConvertFirstIF(node, out setedValue))
            //                                        {

            //                                        }

            //                                        break;
            //                                    }
            //                                    #region Get the data under "ReserveKey", make a dictionary.
            //                                    else
            //                                    {   

            //                                        XmlNodeList if_SVList = node.SelectNodes(ITSecurityConstants.XPathToLowerIF_SVName);
            //                                        XmlDocument tmpXmlDoc = new XmlDocument();
            //                                        XmlNode reserveNode = tmpXmlDoc.CreateNode(XmlNodeType.Element, "ReserveKey", null);
            //                                        foreach (XmlNode valueNode in if_SVList)
            //                                        {
            //                                            if (valueNode.Name.ToLower().Equals(ITSecurityConstants.XmlNodeIfTag, StringComparison.InvariantCultureIgnoreCase))
            //                                            {
            //                                                break;
            //                                            }
            //                                            else
            //                                            {
            //                                                XmlNode importedValueNode = reserveNode.OwnerDocument.ImportNode(valueNode, true);
            //                                                reserveNode.AppendChild(importedValueNode);
            //                                            }                                            
            //                                            LoadFromXML(reserveNode);
            //                                        }

            //                                        #region for confirm
            //                                        //foreach (XmlNode setValueNode in reserveNode)
            //                                        //{
            //                                        //    //Console.WriteLine(setValueNode);
            //                                        //    string attrName = string.Empty;
            //                                        //    string attrValue = string.Empty;
            //                                        //    bool isAppend = false;
            //                                        //    foreach (XmlAttribute xmlAttribute in setValueNode.Attributes)
            //                                        //    {
            //                                        //        switch (xmlAttribute.Name.ToLower())
            //                                        //        {
            //                                        //            case ITSecurityConstants.XmlAttributeName:
            //                                        //                attrName = xmlAttribute.Value;
            //                                        //                break;
            //                                        //            case ITSecurityConstants.XmlAttributeValue:
            //                                        //                attrValue = xmlAttribute.Value;
            //                                        //                break;
            //                                        //            case ITSecurityConstants.XmlAttributeAppend:
            //                                        //                isAppend = xmlAttribute.Value.Equals(ITSecurityConstants.TrueIntValue) ? true : false;
            //                                        //                break;
            //                                        //            //KatouTsuyoshi 2014.01.14 add start --- 定義ファイルの新しい属性値 R10.03.00対応
            //                                        //            case ITSecurityConstants.XmlAttributeModuleType_LowerCase:
            //                                        //                //creationType = RunEnviroment.GetCreationType(xmlAttribute.Value.ToString());
            //                                        //                break;
            //                                        //            //KatouTsuyoshi 2014.01.14 add end   --- 定義ファイルの新しい属性値 R10.03.00対応
            //                                        //            default:
            //                                        //                break;
            //                                        //        }
            //                                        //    }
            //                                        //Console.WriteLine(attrName);
            //                                        //Console.WriteLine(attrValue);
            //                                        //}
            //#endregion
            //                                    }
            //                                    #endregion
            //                                }
            //                                //Console.WriteLine(IF_Rrv_IncNode.InnerText); //for comfirm results
            //                            }
            //                        }

            //                        //RemoveIFTag
            //                        XmlNode TrueNode = IFTagManager.RemoveIFTag(IF_Rrv_IncNode, ref this.atOnceTrueFlag);


            //                        break;
            //                    default:
            //                        break;
            //                }
            //                IF_Or_IncList = xmlDoc.SelectNodes(ITSecurityConstants.XPathTopNodeIF_IncNode);
            //            }
            #endregion
            SecurityManager scM = new SecurityManager();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("key.xml");
            XmlDocument xmlDocAll = scM.ConvertXML(xmlDoc);
            xmlDocAll.Save("TEST_R0.xml"); //for original code
            //xmlDocAll.Save("TEST_R1.xml"); //for test the modified code
            Console.WriteLine("Save finished");
            Console.ReadKey();
        }


        //public static bool ConvertFirstIF(XmlNode sourceXML, out string setedValue)
        //{

        //    setedValue = string.Empty;
        //    foreach (XmlAttribute attri in sourceXML.Attributes)
        //    {//Ono Masatsohi 2014/01/28 Tag属性を処理しないように変更
        //        if (!attri.Name.ToLower().Equals(ITSecurityConstants.XmlAttributeTag) && !attri.Name.ToLower().Equals(ITSecurityConstants.XmlAttributeOperator))
        //        {
        //            //string convertedXmlStr = sourceXML.OuterXml;
        //            //string convertedAttriValue = attri.Value;
        //            setedValue = attri.Value;
        //            foreach (string iterKey in ReserveKeyManager.GetInstance().Keys)
        //            {
        //                string reserveKey = ITSecurityConstants.LeftReserveSeperator + iterKey + ITSecurityConstants.RightReserveSeperator;
        //                string reserveValue = ReserveKeyManager.GetInstance()[iterKey];
        //                //Console.WriteLine(reserveValue);

        //                //convertedXmlStr = ReplaceTopIFName4CaseInsensitive(convertedXmlStr, reserveKey, convertedValue);
        //                setedValue = Replace4CaseInsensitive(setedValue, reserveKey, reserveValue);
        //            }
        //            if (setedValue.Equals(attri.Value))
        //            {
        //                return false;
        //            }
        //            attri.Value = setedValue;
        //            //Console.WriteLine(attri.Value);
        //        }
        //    }

        //    return true;
        //}
        //private static string Replace4CaseInsensitive(string srcStr, string oldValue, string newValue)
        //{
        //    string regexStr = string.Empty;
        //    foreach (char c in oldValue)
        //    {
        //        regexStr += "[" + c.ToString().ToLower() + c.ToString().ToUpper() + "]";
        //    }
        //    return System.Text.RegularExpressions.Regex.Replace(srcStr, regexStr, newValue);
        //}
        //public static bool LoadFromXML(XmlNode sourceXML)
        //{
        //    if (sourceXML == null || !sourceXML.Name.Equals(ITSecurityConstants.XmlNodeReserveKey, StringComparison.InvariantCultureIgnoreCase))
        //    {
        //        return false;
        //    }

        //    foreach (XmlNode setValueNode in sourceXML.ChildNodes)
        //    {
        //        if (setValueNode.Name.Equals(ITSecurityConstants.XmlNodeSetValue, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            string attrName = string.Empty;
        //            string attrValue = string.Empty;
        //            bool isAppend = false;

        //            foreach (XmlAttribute xmlAttribute in setValueNode.Attributes)
        //            {
        //                switch (xmlAttribute.Name.ToLower())
        //                {
        //                    case ITSecurityConstants.XmlAttributeName:
        //                        attrName = xmlAttribute.Value;
        //                        break;
        //                    case ITSecurityConstants.XmlAttributeValue:
        //                        attrValue = xmlAttribute.Value;
        //                        break;
        //                    case ITSecurityConstants.XmlAttributeAppend:
        //                        isAppend = xmlAttribute.Value.Equals(ITSecurityConstants.TrueIntValue) ? true : false;
        //                        break;
        //                    //KatouTsuyoshi 2014.01.14 add start --- 定義ファイルの新しい属性値 R10.03.00対応
        //                    case ITSecurityConstants.XmlAttributeModuleType_LowerCase:
        //                        break;
        //                    //KatouTsuyoshi 2014.01.14 add end   --- 定義ファイルの新しい属性値 R10.03.00対応
        //                    default:
        //                        break;
        //                }
        //            }

        //            string keyValue = attrValue;
        //            // KatouTsuyoshi 2014.02.25 add end   --- ReserveKeyのSetValueにあるSystem32はCreationType64ならNativeにする
        //            // KatouTsuyoshi 2014.02.27 add end   --- ReserveKeyのSetValueにあるSystem32はCreationType32ならSysWOW64にする

        //            if (!string.IsNullOrEmpty(attrName) && !string.IsNullOrEmpty(keyValue))
        //            {
        //                if (ReserveKeyManager.GetInstance().ContainsKey(attrName))
        //                {
        //                    if (isAppend)
        //                    {
        //                        string currentValue = ReserveKeyManager.GetInstance()[attrName];
        //                        if (!currentValue.StartsWith(ITSecurityConstants.GuidSeperator))
        //                        {
        //                            currentValue = ITSecurityConstants.GuidSeperator + currentValue;
        //                        }
        //                        if (!currentValue.EndsWith(ITSecurityConstants.GuidSeperator))
        //                        {
        //                            currentValue = currentValue + ITSecurityConstants.GuidSeperator;
        //                        }
        //                        string newValue = currentValue + keyValue + ITSecurityConstants.GuidSeperator;
        //                        ReserveKeyManager.GetInstance()[attrName] = newValue;

        //                        //Debug Print
        //                    }
        //                    else
        //                    {
        //                        ReserveKeyManager.GetInstance()[attrName] = keyValue;

        //                        //Debug Print
        //                    }
        //                }
        //                else
        //                {
        //                    ReserveKeyManager.GetInstance().Add(attrName, keyValue);

        //                    //Debug Print
        //                }
        //            }
        //        }
        //    }

        //    return true;
        //}

        //private List<string> ListConverter(string data)
        //{
        //    string rkeytocsvString = string.Empty;
        //    List<string> tmpList = new List<string>();

        //    if (data.Contains(ITSecurityConstants.GuidSeperator))
        //    {
        //        rkeytocsvString = ConvertReserveKey(data);
        //        if (rkeytocsvString.Contains(ITSecurityConstants.IFComma))
        //        {
        //            return ConvertCSVtoList(rkeytocsvString);
        //        }
        //        else
        //        {
        //            tmpList.Clear();
        //            tmpList.Add(rkeytocsvString);
        //        }
        //    }

        //    if (data.Contains(ITSecurityConstants.IFComma))
        //    {
        //        return ConvertCSVtoList(data);
        //    }
        //    else
        //    {
        //        tmpList.Clear();
        //        tmpList.Add(data);
        //    }
        //    return tmpList;
        //}
        //private string ConvertReserveKey(string rkeyData)
        //{
        //    string[] strArray = null;
        //    string convertedCommaString = string.Empty;

        //    if (!rkeyData.Contains(ITSecurityConstants.GuidSeperator))
        //    {
        //        return rkeyData;
        //    }
        //    // GUIDのStringをCommaつきのStringに変換する。
        //    else
        //    {
        //        string[] delimiter = { ITSecurityConstants.GuidSeperator };

        //        strArray = rkeyData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string str in strArray)
        //        {
        //            convertedCommaString += ITSecurityConstants.IFComma + str;
        //        }
        //        return convertedCommaString;
        //    }
        //}
        //private List<string> ConvertCSVtoList(string csvData)
        //{
        //    List<string> CSVConvertList = new List<string>();
        //    string[] strArray = null;

        //    if (!csvData.Contains(ITSecurityConstants.IFComma))
        //    {
        //        CSVConvertList.Clear();
        //        CSVConvertList.Add(csvData);

        //        return CSVConvertList;
        //    }
        //    else
        //    {
        //        CSVConvertList.Clear();
        //        string[] delimiter = { ITSecurityConstants.IFComma };

        //        strArray = csvData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        //        foreach (string str in strArray)
        //        {
        //            CSVConvertList.Add(str.ToLower());
        //        }
        //    }
        //    return CSVConvertList;
        //}
    }
}
