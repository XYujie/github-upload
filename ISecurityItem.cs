using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _4Test
{
    public interface ISecurityItem
    {
        XmlNode GetOutputData(XmlDocument xmlDoc);
        XmlNode SaveToXML(XmlDocument securityDom);
        bool LoadFromXML(XmlNode sourceXML);
        bool ReadFromOS();
        bool SetToOS();
        bool SetToGPO();

        // ISE 2017.09.01 add start [R11.03.00] プログレスバーの進捗表示を変更
        /// <summary>
        /// セキュリティ反映時のウエイト
        /// </summary>
        int ProgressValueWhenGetOrSetOS
        {
            get;
            set;
        }
        // ISE 2017.09.01 add end [R11.03.00]
    }
}
