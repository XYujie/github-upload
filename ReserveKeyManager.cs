using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Test
{
    public class ReserveKeyManager : ICloneable
    //class ReserveKeyManager
    //YangJiannan 2010/11/30 add start --- UI修正
    {
        #region Field
        private static ReserveKeyManager instance = null;

        private Dictionary<string, string> reserveKeyDict = null;
        #endregion

        #region Property
        public string this[string keyName]
        {
            get
            {
                //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
                return this.reserveKeyDict[keyName.ToLower()];
                //return this.reserveKeyDict[keyName];
                //YangJiannan 2011/02/11 edit end --- 大文字小文字関係なしにする
            }
            set
            {
                //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
                this.reserveKeyDict[keyName.ToLower()] = value;
                //this.reserveKeyDict[keyName] = value;
                //YangJiannan 2011/02/11 edit end --- 大文字小文字関係なしにする
            }
        }

        public Dictionary<string, string>.KeyCollection Keys
        {
            get { return this.reserveKeyDict.Keys; }
        }
        #endregion

        #region Constructor
        private ReserveKeyManager()
        {
            this.reserveKeyDict = new Dictionary<string, string>();
        }
        #endregion

        #region Public Method
        public static ReserveKeyManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ReserveKeyManager();
            }
            return instance;
        }

        public bool ContainsKey(string key)
        {
            //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
            return this.reserveKeyDict.ContainsKey(key.ToLower());
            //return this.reserveKeyDict.ContainsKey(key);
            //YangJiannan 2011/02/11 edit end --- 大文字小文字関係なしにする
        }

        public void Clear()
        {
            this.reserveKeyDict.Clear();
        }

        public void Add(string key, string value)
        {
            //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
            this.reserveKeyDict.Add(key.ToLower(), value);
            //this.reserveKeyDict.Add(key, value);
            //YangJiannan 2011/02/11 edit end --- 大文字小文字関係なしにする
        }

        public bool Remove(string key)
        {
            //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
            return this.reserveKeyDict.Remove(key.ToLower());
            //return this.reserveKeyDict.Remove(key);
            //YangJiannan 2011/02/11 edit start --- 大文字小文字関係なしにする
        }

        //YangJiannan 2010/11/30 add start --- UI修正
        public object Clone()
        {
            ReserveKeyManager clonedManager = new ReserveKeyManager();
            foreach (KeyValuePair<string, string> iter in this.reserveKeyDict)
            {
                clonedManager.reserveKeyDict.Add(iter.Key, iter.Value);
            }
            return clonedManager;
        }

        public void Set(ReserveKeyManager srcManager)
        {
            this.reserveKeyDict = srcManager.reserveKeyDict;
        }
        //YangJiannan 2010/11/30 add end --- UI修正
        #endregion
    }
}
