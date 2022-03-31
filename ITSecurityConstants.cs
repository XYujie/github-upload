using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Test
{
    class ITSecurityConstants
    {
        #region ConfigFile
        //[JA_JP] CONFIGファイル名称
        //KatouTsuyoshi 20110220 mod start --- PATH change
        //public const string ConfigFilePath = @"\Yokogawa\IA\iPCS\Products\Security\Config";
        //public const string ConfigFilePath = @"\Yokogawa\IA\iPCS\Products\Platform\Security\Config";
        public const string ConfigFilePath = @"\Yokogawa\IA\iPCS\Platform\Security\Config";
        //KatouTsuyoshi 20110220 mod end   --- PATH change
        public const string ConfigFileName = @"ITSecuritySettingTool.config";
        public const string ConfigFileExt = ".config";
        //ISE-14.02.07 [R10.03.00] 保存機能の画面に表示するOS選択のチェックボックスの機能拡張 追加
        public const string CommonConfigFileName = "Common.config";
        //ISE-14.02.07 END

        //[JA_JP] CONFIGファイルXML定義
        public const string ConfigXMLRootNode = @"ITSecurityToolConfig";
        public const string ConfigXMLExportNode = @"Export";
        public const string ConfigXMLTopFodersNode = @"TopFolders";
        public const string ConfigXMLFoldersNode = @"Folders";
        public const string ConfigXMLFolderNode = @"Folder";
        public const string ConfigXMLTopRegistryKeyNode = @"TopRegistryKey";
        public const string ConfigXMLRegistryKeyNode = @"RegistryKey";
        public const string ConfigXMLPINNode = @"PIN";

        public const string ConfigXMLSettingNode = @"Setting";
        public const string ConfigXMLMNTSNode = @"maintenancegroups";
        public const string ConfigXMLMNTNode = @"maintenancegroup";

        //ISE-14.02.07 [R10.03.00] 保存機能の画面に表示するOS選択のチェックボックスの機能拡張 追加
        public const string ConfigXMLFormNode = @"ITsecurityForm";
        public const string ConfigXMLTargetWizardNode = @"TargetWizard";
        public const string ConfigXMLTargetOSNode = @"TargetOS";
        public const string ConfigXMLTargetOSVersion = @"version";
        //ISE-14.02.07 END

        //YangJiannan 2011/03/07 add start --- Log 機能追加
        public const string ConfigXMLOutputDebugInfoNode = @"outputdebuginfo";
        //YangJiannan 2011/03/07 add end --- Log 機能追加

        //ISE 2016.08.31 add start --- セキュリティバージョン対応
        public const string ConfigXMLProductsNode = @"Products";
        public const string ConfigXMLProductNode = @"Product";
        public const string ConfigXMLNameNode = @"Name";
        public const string ConfigXMLName = @"name";
        //ISE 2016.08.31 add end   --- セキュリティバージョン対応

        // ISE 2017.08.18 add start [R11.03.00] Log機能の強化
        public const string ConfigXMLLogManagementNode = @"logmanagement";
        public const string ConfigXMLLogLevel = @"loglevel";
        public const string ConfigXMLFileMaxSize = @"filemaxsize";
        public const string ConfigXMLGeneration = @"generation";
        // ISE 2017.08.18 add end [R11.03.00]

        #endregion

        #region Header
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string HeaderItemIdentifier = @"identificationname";
        public const string HeaderItemComputer = @"computer";
        public const string HeaderItemDate = @"date";
        public const string HeaderItemProduct = @"product";
        public const string HeaderItemOS = @"os";
        public const string HeaderItemUser = @"user";
        public const string HeaderItemVersion = @"version";
        // add hama start 2010/4/19
        public const string HeaderItemInclude = @"bodyfile";
        // add hama end 2010/4/19

        //public const string HeaderItemIdentifier = @"IdentificationName";
        //public const string HeaderItemComputer = @"Computer";
        //public const string HeaderItemDate = @"Date";
        //public const string HeaderItemProduct = @"Product";
        //public const string HeaderItemOS = @"OS";
        //public const string HeaderItemUser = @"User";
        //public const string HeaderItemVersion = @"Version";
        //// add hama start 2010/4/19
        //public const string HeaderItemInclude = @"BodyFile";
        //// add hama end 2010/4/19
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        //KatouTsuyoshi 20110220 mod start --- PATH change
        //public const string PathBackupFile = @"\Yokogawa\IA\iPCS\Products\Security\system";
        //public const string PathBackupFile = @"\Yokogawa\IA\iPCS\Products\Platform\Security\system";
        public const string PathBackupFile = @"\Yokogawa\IA\iPCS\Platform\Security\system";
        //public const string PathTemplateFile = @"\Yokogawa\IA\iPCS\Products\Security\system\default";
        //public const string PathTemplateFile = @"\Yokogawa\IA\iPCS\Products\Platform\Security\system\default";
        public const string PathTemplateFile = @"\Yokogawa\IA\iPCS\Platform\Security\system\default";

        //YangJiannan 2011/04/19 edit start --- Bug 83893
        public const string PathCDRomTemplateFile = @"SECURITY";
        //public const string PathCDRomTemplateFile = @"CENTUM\SECURITY";
        //YangJiannan 2011/04/19 edit end --- Bug 83893

        //public const string PathSaveProhibitionFolder = @"\Yokogawa\IA\iPCS\Products\Security";
        //public const string PathSaveProhibitionFolder = @"\Yokogawa\IA\iPCS\Products\Platform\Security";
        public const string PathSaveProhibitionFolder = @"\Yokogawa\IA\iPCS\Platform\Security";
        //KatouTsuyoshi 20110220 mod end   --- PATH change
        public const string PathLogFile = PathSaveProhibitionFolder + @"\Log\Log.txt";
        public const string PathLogFileForMultiLaunch = PathSaveProhibitionFolder + @"\Log\MultiLaunchLog.txt";

        #endregion

        #region Xml
        /// <summary>
        /// [JA_JP] XMLファイルタグ／属性定義
        /// [JA_JP] この定義は他の人のソースと最終的に結合する必要がある。
        /// </summary>

        //[JA_JP] 確認文字列用
        public const string XmlOutputNode = @"output";
        public const string XmlOutputAttribute = @"string";

        //[JA_JP] Templateファイルのルートノード
        public const string XmlSecuritySettingNode = @"SecuritySetting";

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlTemplateBodyNode = @"body";
        public const string XmlHeaderNode = @"header";

        //public const string XmlTemplateBodyNode = @"Body";
        //public const string XmlHeaderNode = @"Header";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        public const string XmlHeaderRootNode = XmlSecuritySettingNode + @"/" + XmlHeaderNode;

        //[JA_JP] XML共通
        public const string XmlNodeExplanation = @"Explanation";
        //CSE/T.Kobayashi 2016/09/09 edit start
        //11.01.00以降「Explanation」の判定はこちらを使用する
        public const string XmlNodeExplanation_lower = @"explanation";
        //CSE/T.Kobayashi 2016/09/09 edit end
        public const string Valid = "Valid";
        public const string XmlNodeRole = @"Role";
        public const string XmlAttributeDisplayName = @"displayName";
        public const string XmlAttributeSelected = @"selected";
        public const string XmlAttributeUnSelected = @"unselected";
        public const string XmlAttributeRequired = @"required";
        //Ono Masatoshi 2014/1/27 add start 属性値を元に戻す
        //KatouTsuyoshi 2014.01.06 add start --- 定義ファイルの新しい属性値 R10.03.00対応
        public const string XmlAttributeReserveName = @"reserveName";
        public const string XmlAttributePath = @"keyName";
        public const string XmlAttributeKey = @"keyValue";
        //YangJiannan 2010/12/23 add start --- hidden属性対応
        public const string XmlAttributeHidden = "hidden";
        //YangJiannan 2010/12/23 add end --- hidden属性対応
        public const string XmlAttributeModuleType = "moduleType";
        public const string XmlAttributeModuleType_LowerCase = "moduletype";

        //Yang edit start 20100615 --- 環境変数の対応
        public const string XmlAttributeEnvVarFlag = @"envVarFlag";
        //Yang edit end   20100615 --- 環境変数の対応
        //KatouTsuyoshi 2014.01.06 add end   --- 定義ファイルの新しい属性値 R10.03.00対応
        //Ono Masatoshi 2014/1/27 add end 属性値を元に戻す
        public const string XmlAttributeFolderName = @"folderName";
        public const string XmlAttributeFileName = @"fileName";
        public const string XmlAttributeInherit = @"inherit";
        public const string XmlAttributePropagate = @"propagate";
        public const string XmlAttributeDelete = @"delete";
        //Yang edit start 20100618 --- 共有フォルダの対応
        public const string XmlAttributeShareFolder = @"shared";
        //Yang edit end   20100618 --- 共有フォルダの対応
        //Katou edit start 20101119 -- recursiveの対応
        public const string XmlAttributeRecursive = @"recursive";
        public const string XmlAttributeAutoSetting = @"autoSetting";
        //Katou edit end   20101119 -- recursiveの対応
        public const string XmlAttributeName = @"name";
        public const string XmlAttributeRights = @"right";
        public const string XmlAttributeKeyName = @"keyName";
        public const string XmlAttributeIsInherited = @"isInherited";
        public const string XmlAttributeApply = @"apply";
        public const string XmlAttributeDeny = @"deny";
        public const string XmlAttributeConfirm = @"confirm";
        public const string XmlAttributeValue = @"value";
        public const string XmlAttributeBasic = @"BasicProperty";
        public const string XmlNodeCommand = @"commands";
        public const string XmlNodeAccount = @"account";
        public const string XmlNodeAccessControl = @"accesscontrol";
        public const string XmlNodeConfitionFileAgent = @"conditionfile";
        public const string XmlNodeFiles = @"Files";
        public const string XmlNodeFolder = @"Folder";
        public const string XmlNodeFile = @"File";
        public const string XmlNodeRegistry = @"Registry";
        public const string XmlNodeKey = @"Key";
        public const string XmlNodeRegUser = @"RegUser";
        public const string XmlNodeRegGroup = @"RegGroup";
        public const string XmlNodeDcom = @"dcom";
        public const string COMSecurity = "COMSecurity";
        public const string DCOMSecurity = "DCOMSecurity";
        public const string AuthenticationLevel = "authenticationLevel";
        //YangJiannan 2011/06/17 add start --- Add the "force" attribute for Comsecurity's AuthenticationLevel. 
        public const string XmlAttributeForce = "force";
        //YangJiannan 2011/06/17 add end --- Add the "force" attribute for Comsecurity's AuthenticationLevel. 
        public const string COMPort = "COMPort";
        public const string DefaultAccess = "DefaultAccess";
        public const string DefaultLaunch = "DefaultLaunch";
        public const string RestrictionAccess = "RestrictionAccess";
        public const string RestrictionLaunch = "RestrictionLaunch";
        public const string Module = "Module";
        public const string ModuleID = "ModuleID";
        public const string ModuleDescription = "Description";
        public const string Launch = "Launch";
        public const string Access = "Access";
        public const string Configuration = "Configuration";
        public const string Role = "Role";
        public const string FullName = "FullName";
        //public const string Mode = "Mode";
        //public const string Rights = "Rights";
        public const string Default = "Default";
        //[JA_JP] ファイアーウォール

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeFirewall = @"firewall";

        //public const string XmlNodeFirewall = @"Firewall";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        //CSE/OhtawaraShu 2016/09/09 edit start
        public const string XmlNodeAdministrativeTemplate = @"administrativetemplate";
        public const string XmlNodeAdministrativeTemplateSetting = @"administrativetemplatesetting";
        public const string XmlNodeAdvancedAudit = @"advancedaudit";
        //CSE/OhtawaraShu 2016/09/09 edit end

        public const string ICMP = "ICMP";
        public const string Exceptions = "Exceptions";
        public const string Program = "Program";
        public const string ProgramName = "programName";
        public const string Programs = "Programs";
        public const string Port = "Port";
        public const string Setting = "Setting";
        public const string PropertyName = "propertyName";
        public const string ReserveName = "reserveName";
        public const string Path = "path";
        public const string PortName = "portName";
        public const string PortType = "portType";
        public const string PortNO = "portNO";
        public const string Scope = "scope";
        public const string Custom = "custom";
        public const string ServiceName = "serviceName";
        //KatouTsuyoshi 2011/04/27 add start --- Firewall Service Check
        public const string FirewallServiceNameforXP = "SharedAccess";
        public const string FirewallServiceNameforVista = "MpsSvc";
        public const string checkServiceStarted = "Started";
        public const string checkServiceStatusIsFalse = "False";
        public const string detailServiceNameOnWMI = "Caption";
        public const string getWMIServiceObject = "Win32_Service='{0}'";
        //KatouTsuyoshi 2011/04/27 add end   --- Firewall Service Check

        //CSE/M.Kikumoto 2016/09/02 add start
        public const string FirewallUnicastResponseDisabled = "UnicastResponseDisabled";
        //CSE/M.Kikumoto 2016/09/02 add end

        //[JA_JP] 不要サービス停止

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeUnuseService = @"stopservice";

        //public const string XmlNodeUnuseService = @"StopService";
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする

        public const string Service = "Service";
        public const string Name = "Name";
        public const string Startup = "startup";
        public const string Account = "account";
        public const string Password = "password";

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        //[JA_JP] パスワードポリシー
        public const string XmlNodePasswordPolicy = @"passwordpolicy";
        //[JA_JP] アカウントロックアウトポリシー
        public const string XmlNodeAccountLockoutPoicy = @"accountlockoutpolicy";
        //[JA_JP] 監査ポリシー
        public const string XmlNodeEventAudit = @"eventaudit";
        //[JA_JP] ユーザ権限割付
        public const string XmlNodePrivilegeRights = @"privilegerights";
        //[JA_JP] セキュリティオプション
        public const string XmlNodeSecurityOption = @"securityoption";
        //[JA_JP] ソフトウェア制限ポリシー
        public const string XmlNodeSoftwareRestrictionPolicy = @"softwarerestrictionpolicy";

        //[JA_JP] AutoRunの制限
        public const string XmlNodeAutoRun = @"autorun";

        //[JA_JP]AdvancedAudit
        public const string XMLNodeAdvancedAuditSetting = @"advancedauditsetting";

        ////[JA_JP] パスワードポリシー
        //public const string XmlNodePasswordPolicy = @"PasswordPolicy";
        ////[JA_JP] アカウントロックアウトポリシー
        //public const string XmlNodeAccountLockoutPoicy = @"AccountLockOutPolicy";
        ////[JA_JP] 監査ポリシー
        //public const string XmlNodeEventAudit = @"EventAudit";
        ////[JA_JP] ユーザ権限割付
        //public const string XmlNodePrivilegeRights = @"PrivilegeRights";
        ////[JA_JP] セキュリティオプション
        //public const string XmlNodeSecurityOption = @"SecurityOption";
        ////[JA_JP] ソフトウェア制限ポリシー
        //public const string XmlNodeSoftwareRestrictionPolicy = @"SoftwareRestrictionPolicy";

        ////[JA_JP] AutoRunの制限
        //public const string XmlNodeAutoRun = @"AutoRun";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        public const string XmlAttributeAutoRunValue = "autoRunValue";

        //[JA_JP] NetBIOS over TCP/IPの無効化

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeNetBIOS = @"netbios";

        //public const string XmlNodeNetBIOS = @"NetBIOS";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        public const string XmlNodeNetBIOSSetting = @"NetBIOSSetting";
        public const string XmlAttributeConnectionName = @"ConnectionName";
        public const string XmlAttributeNetBIIOValue = @"netBIOSValue";

        // add hama start 2010/4/12
        //[JA_JP] リムーバブルメディアの制限
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeRemovableMedia = @"removablemedia";
        //public const string XmlNodeRemovableMedia = @"RemovableMedia";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする
        public const string XmlNodeUSB = @"USB";
        public const string XmlAttributeUSBWriteProtect = @"writeProtect";
        //KatouTsuyoshi 20110204 add start --- USB Deny 
        public const string XmlAttributeUSBDenyAll = @"denyAll";
        //KatouTsuyoshi 20110204 add end   --- USB Deny 
        // add hama end 2010/4/12

        // add hama start 2010/4/14
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeRegistryEdit = @"registryedit";
        //public const string XmlNodeRegistryEdit = @"RegistryEdit";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする
        // edit hama start 2010/5/7
        public const string XmlNodeAddKey = @"AddKey";
        public const string XmlNodeDeleteKey = @"DeleteKey";
        // edit hama end 2010/5/7
        public const string XmlAttributeFullPath = @"keyName";
        public const string XmlNodeValue = @"Value";
        public const string XmlAttributeType = @"type";
        public const string XmlAttributeData = @"data";
        // add hama end 2010/4/14

        //YangJiannan 2010/07/21 add start --- legacy 対応
        public const string XmlNodeDeleteValue = @"DeleteValue";
        //YangJiannan 2010/07/21 add start --- legacy 対応

        //Yang 2010/10/27 add start --- Services 対応
        public const string XmlAttributeLogonType = "logonType";

        //YangJiannan 2011/01/20 edit start --- Bug 80932
        public const string XmlAttributeDesktopInteract = "desktopInteract";
        //YangJiannan 2011/01/20 edit end --- Bug 80932

        public const string XmlAttributeAccount = "account";
        public const string XmlAttributePassword = "password";

        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeServices = "services";
        //public const string XmlNodeServices = "Services";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        //Yang 2010/10/27 add end --- Services 対応

        //YangJiannan 2010/10/26 add start --- ReserveKeyタグ対応
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeReserveKey = "reservekey";
        //public const string XmlNodeReserveKey = "ReserveKey";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする
        public const string XmlNodeSetValue = "SetValue";
        public const string XmlAttributeAppend = "append";
        //YangJiannan 2010/10/26 add end --- ReserveKeyタグ対応

        //Katou Edit 20101130 start --- IFタグ対応
        // //public const string XmlNodeIfTag = @"IF";
        public const string XmlNodeIfTag = @"if";
        public const string XmlAttributeLang = @"lang";
        //public const string XmlAttributeInvLang = @"lang_not";
        public const string XmlAttributeOS = @"os";
        //public const string XmlAttributeInvOS = @"os_not";
        public const string XmlAttributeSVer = @"sver";
        //public const string XmlAttributeInvSVer = @"sver_not";
        public const string XmlAttributeTag = @"tag";
        //public const string XmlAttributeInvTag = @"tag_not";
        public const string XmlAttributeOperator = @"operator";
        //KatouTsuyoshi 20101224 add start --- AtOnce
        public const string XmlAttributeAtOnce = @"atonce";
        //KatouTsuyoshi 20101224 add end   --- AtOnce
        //KatouTsuyoshi 20110905 add start -- implement the new if attribute
        public const string XmlAttributeProduct = @"product";
        public const string XmlAttributeSelectedUserManagement = @"usermanagement";
        public const string XmlAttributeSelectedModelType = @"modeltype";
        //KatouTsuyoshi 20110905 add end   -- implement the new if attribute
        //KatouTsuyoshi 20161115 add start --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        public const string XmlAttributeDisplayedSecurityVersion = @"displayedsver";
        //KatouTsuyoshi 20161115 add end   --- ITセキュリティバージョン対応 (ConditionFileの<sercurityversion>ではなく、画面選択の情報を取得)
        //Katou Edit 20101130 end   --- IFタグ対応
        public const string XmlAttributeIFTagLastNBTSetting = @"lastnbtsetting";
        public const string XmlAttributeIFTagDomainLinkStatus = @"domainlinkstatus";

        //Ono Edit 20121220 start --ConfrimDialogタグの対応
        public const string ConfigXMLConfrimDialogNode = @"confirmdialog";
        public const string XmlAttributeShow = @"show";
        public const string ConfigXMLTitleNode = @"title";
        public const string ConfigXMLMSGNode = @"message";
        public const string Ja_Jp = @"ja-jp";
        public const string XmlValueJa = @"japanese";
        //Ono Edit 20121220 end --ConfrimDialogタグの対応

        //YangJiannan 2010/12/08 add start --- SharedFolders 対応
        //YangJiannan 2010/12/10 edit start --- 大文字小文字関係なしにする
        public const string XmlNodeSharedFolders = "sharedfolders";
        //public const string XmlNodeSharedFolders = "SharedFolders";
        //YangJiannan 2010/12/10 edit end --- 大文字小文字関係なしにする

        public const string XmlNodeSharedFolder = "SharedFolder";
        public const string XmlNodeShareName = "ShareName";
        public const string XmlAttributeShareName = "name";
        public const string XmlAttributeComment = "comment";
        public const string XmlAttributeIsMaximumUsers = "isMaximumUsers";
        public const string XmlAttributeUnshare = "unshare";
        public const string XmlAttributeAllowUsers = "allowUsers";
        public const string XmlAttributeRemoveShare = "removeShare";
        //YangJiannan 2010/12/08 add end --- SharedFolders 対応

        //YangJiannan 2010/12/26 add start --- SecurityVerとProductVer対応
        public const string XmlNodeSecurityVersion = "securityversion";
        public const string XmlNodeProductVersion = "productversion";
        //YangJiannan 2010/12/26 add end --- SecurityVerとProductVer対応
        #endregion

        #region Const Value
        //[JA_JP] True/False
        public const string TrueValue = "true";
        public const string FalseValue = "false";
        public const string TrueIntValue = "1";
        public const string FalseIntValue = "0";

        //[JA_JP] InheritType
        //YangJiannan 2010/10/27 add start --- Inherit対応
        public const string DefaultInheritAccessRule = "0";
        //YangJiannan 2010/10/27 add end --- Inherit対応
        public const string InheritAccessRule = "1";
        public const string DeleteInheritAccessRule = "2";
        public const string CopyInheritAccessRule = "3";

        //[JA_JP] FolderApplyType
        public const string FolderApplyFolderOnly = "1";
        public const string FolderApplyFolderAndFile = "2";
        public const string FolderApplyFolderAndSubFolder = "3";
        public const string FolderApplyFolderAndSubFolderAndFile = "4";
        public const string FolderApplyFileOnly = "5";
        public const string FolderApplySubFolderOnly = "6";
        public const string FolderApplySubFolderAndFile = "7";

        //[JA_JP] RegistryApplyType
        public const string RegApplyKeyOnly = "1";
        public const string RegApplyKeyAndSubKey = "3";
        public const string RegApplySubKeyOnly = "6";

        //katou 20101119 add start --- WildCard 対応
        //[JA_JP] WildCardType
        public const string WildCardTypeAsterisk = "*";
        public const string WildCardTypeQuestion = "?";
        //katou 20101119 add end   --- WildCard 対応

        //KatouTsuyoshi 2014.01.06 add start --- 定義ファイルの新しい属性値 R10.03.00対応
        public const string XmlValue32bit = "32";
        public const string XmlValue64bit = "64";
        public const string XmlValueAnyCPU = "any";
        //KatouTsuyoshi 2014.01.06 add end   --- 定義ファイルの新しい属性値 R10.03.00対応

        //ISE-14.02.07 [R10.03.00] 保存機能の画面に表示するOS選択のチェックボックスの機能拡張 追加
        public const string XmlValueWizardNameExportInformation = "ExportInformation";
        //ISE-14.02.07 END

        //Katou Edit 20101130 start --- IFタグ対応
        public const string IFLangEng = "english";
        public const string IFLangJp = "japanese";
        public const string IFOSXP = "xp";
        public const string IFOS2003 = "2003";
        public const string IFOSVista = "vista";
        public const string IFOS2008 = "2008";
        public const string IFOS7 = "7";
        public const string IFOS2008R2 = "2008r2";
        public const string IF_ALL = "_all";
        public const string IFComma = @",";
        public const string IFja = "ja";
        public const string IFen = "en";
        public const string IFXPVersion = "5.1";
        public const string IF2003Version = "5.2";
        public const string IFVistaVersion = "6.0";
        public const string IF2008Version = "6.0";
        public const string IF7Version = "6.1";
        public const string IF2008R2Version = "6.1";
        public const string IFError = "error";
        public const string IFEqual = "eq";
        public const string IFNotEqual = "ne";
        public const string IFVersionProductTypeSeparater = ":";
        //Katou Edit 20101130 end   --- IFタグ対応
        public const string IFNBTNoSetting = "nosetting";
        public const string IFNBTchecked = "checked";
        public const string IFNBTunchecked = "unchecked";
        public const string IFLinkStatus_unlinked = "unlinked";
        public const string IFLinkStatus_partlinked = "partlinked";
        public const string IFLinkStatus_linked = "linked";

        //YangJiannan 2010/12/20 add start --- Required属性の機能変更
        public const string RequiredShowAndEditable = "0";
        public const string RequiredShowAndUneditable = "1";
        public const string RequiredUnshow = "2";
        //YangJiannan 2010/12/20 add end --- Required属性の機能変更

        public const string XMLElementNotDefined = "-1";

        // ISE 2017.08.18 add start [R11.03.00] Log機能の強化
        // ログの出力レベル Configファイルに設定可能な範囲
        public const int SetConfigFileMaxValueLogLevel = 5;
        public const int SetConfigFileMinValueLogLevel = 0;
        // Logファイルの最大サイズ（MB単位） Configファイルに設定可能な範囲
        public const long SetConfigFileMaxValueFileMaxSize = 1000;
        public const long SetConfigFileMinValueFileMaxSize = 1;
        // 世代番号 Configファイルに設定可能な範囲
        public const int SetConfigFileMaxValueGeneration = 50;
        public const int SetConfigFileMinValueGeneration = 1;
        // 過去ログファイル名テンプレート
        public const string LogFileNameTemplate = @"\Log_{0}_{1}.txt";
        // 過去ログファイル検索テンプレート
        public const string SerchLogFileNameTemplate = @"Log_*_*.txt";
        // ISE 2017.08.18 add end [R11.03.00]

        #endregion

        #region Registry
        //[JA_JP] RegRootKey
        public const string RegistryClassesRoot = @"HKEY_CLASSES_ROOT";
        public const string RegistryCurrentUser = @"HKEY_CURRENT_USER";
        public const string RegistryLocalMachine = @"HKEY_LOCAL_MACHINE";
        public const string RegistryUsers = @"HKEY_USERS";
        public const string RegistryCurrentConfig = @"HKEY_CURRENT_CONFIG";

        //[JA_JP] AutoRunレジストリ
        public const string RegistryKeyAutoRun = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer";
        public const string RegistryValueAutoRun = @"NoDriveTypeAutoRun";

        //[JA_JP] NetBIOSコネクションレジストリ
        public const string RegistryKeyNetBIOSConnections = @"SYSTEM\CurrentControlSet\Control\Network\{4D36E972-E325-11CE-BFC1-08002BE10318}";
        public const string RegistryKeyNetBIOSConnection = @"Connection";
        public const string RegistryValueNetBIOSConnection = @"Name";
        //[JA_JP] NetBIOSレジストリ
        public const string RegistryKeyNetBIOS = @"SYSTEM\CurrentControlSet\Services\NetBT\Parameters\Interfaces\Tcpip_";
        public const string RegistryValueNetBIOS = @"NetBIOSOptions";

        // Yang edit start 20100825 --- Removable Media Setting in Win2008
        // add hama start 2010/4/12
        //[JA_JP] USBメモリ書き込み禁止レジストリ
        //public const string RegistryKeyUsbWriteProtect = @"SYSTEM\CurrentControlSet\Control\StorageDevicePolicies";
        //public const string RegistryValueUsbWriteProtect = @"WriteProtect";
        // add hama end 2010/4/12

        //Ono masatoshi  add start 20140225 --- USBCommon
        public static string writeProtectIsTrue = @"0x00000001";
        public static string writeProtectIsFalse = @"0x00000000";
        public static string writeProtectIsDelete = "-1";
        public static string denyAllIsTrue = @"0x00000001";
        public static string denyAllIsFalse = @"0x00000000";
        public static string denyAllIsDelete = "-1";
        //KatouTsuyoshi add end   20140225 --- USBCommon
        //KatouTusyohi 20161125 add start --- 現在値取得のためにConstを併記
        public const string constWriteProtectIsTrue = "0x00000001";
        public const string constWriteProtectIsFalse = "0x00000000";
        public const string constWriteProtectIsDelete = "-1";

        //public static string RegistryKeyUsbWriteProtect
        //{
        //    get
        //    {
        //        string registryKeyUsbWriteProtect = string.Empty;
        //        //Ono Masatoshi 2014/01/22
        //        //if (IsWin2008 || IsWin7)
        //        //{
        //        //    registryKeyUsbWriteProtect = @"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}";
        //        //}
        //        //else
        //        //{
        //        //    registryKeyUsbWriteProtect = @"SYSTEM\CurrentControlSet\Control\StorageDevicePolicies";
        //        //}
        //        if (OSVersion.IsWinXP || OSVersion.IsWinVista)
        //        {
        //            registryKeyUsbWriteProtect = @"SYSTEM\CurrentControlSet\Control\StorageDevicePolicies";

        //        }
        //        else
        //        {
        //            registryKeyUsbWriteProtect = @"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}";
        //        }
        //        //Ono Masatoshi 2014/01/22
        //        return registryKeyUsbWriteProtect;
        //    }
        //}
        //public static string RegistryValueUsbWriteProtect
        //{
        //    get
        //    {
        //        string registryValueUsbWriteProtect = string.Empty;
        //        //if (IsWin2008 || IsWin7)
        //        //{
        //        //    registryValueUsbWriteProtect = @"Deny_Write";
        //        //}
        //        //else
        //        //{
        //        //    registryValueUsbWriteProtect = @"WriteProtect";
        //        //}
        //        if (OSVersion.IsWinXP || OSVersion.IsWinVista)
        //        {
        //            registryValueUsbWriteProtect = @"WriteProtect";

        //        }
        //        else
        //        {
        //            registryValueUsbWriteProtect = @"Deny_Write";
        //        }
        //        return registryValueUsbWriteProtect;
        //    }
        //}

        //KatouTsuyoshi 20110204 add start --- USB Deny 

        // 2013.06.25 Katou edit start --- 未定義(存在しないとき)の保存・復元処理 
        public static string RemovableStorageDevicesKey = @"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices";
        public static string RemovableStorageDevices_USB = @"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}";
        public static string RemovableStorageDevices_USBID = @"{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}";
        public static string Deny_WriteValueName = @"Deny_Write";

        //public static List<string> RemovableStorageDevices_FD_WPF
        //{
        //    get
        //    {
        //        List<string> removableStorageDevices_FD_WPF = new List<string>();

        //        //FD
        //        removableStorageDevices_FD_WPF.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f56311-b6bf-11d0-94f2-00a0c91efb8b}");
        //        //Windows Portable Device
        //        removableStorageDevices_FD_WPF.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{6AC27878-A6FA-4155-BA85-F98F491D4F33}");
        //        removableStorageDevices_FD_WPF.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{F33FDC04-D1AC-4E8E-9A30-19BBD4B108AE}");

        //        return removableStorageDevices_FD_WPF;
        //    }
        //}

        // 2013.06.25 Katou edit end   --- 未定義(存在しないとき)の保存・復元処理 

        //public static List<string> RegistryKeyUsbDenyAll
        //{
        //    get
        //    {
        //        List<string> registryKeyUsbDenyAll = new List<string>();
        //        if (OSVersion.IsAfterVista && !OSVersion.IsWin2008R2)
        //        {
        //            //USB
        //            registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f5630d-b6bf-11d0-94f2-00a0c91efb8b}");
        //            //FD
        //            registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f56311-b6bf-11d0-94f2-00a0c91efb8b}");
        //            //Windows Portable Device
        //            registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{6AC27878-A6FA-4155-BA85-F98F491D4F33}");
        //            registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{F33FDC04-D1AC-4E8E-9A30-19BBD4B108AE}");
        //            //ALL
        //            //registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices");
        //        }
        //        else
        //        {
        //            registryKeyUsbDenyAll.Add(@"SYSTEM\CurrentControlSet\Services\USBSTOR");
        //        }
        //        return registryKeyUsbDenyAll;
        //    }
        //}

        //public static List<string> RegistryValueUsbDenyAll
        //{
        //    get
        //    {
        //        List<string> registryValueUsbDenyAll = new List<string>();
        //        if (OSVersion.IsAfterVista && !OSVersion.IsWin2008R2)
        //        {
        //            //DenyRead
        //            registryValueUsbDenyAll.Add(@"Deny_Read");
        //            //DenyWrite
        //            registryValueUsbDenyAll.Add(@"Deny_Write");
        //            //DenyExecute
        //            registryValueUsbDenyAll.Add(@"Deny_Execute");
        //        }
        //        else
        //        {
        //            registryValueUsbDenyAll.Add(@"start");
        //        }
        //        return registryValueUsbDenyAll;
        //    }
        //}

        //public static List<string> RegistryKeyUsbDenyAllwithoutUSBKey
        //{
        //    get
        //    {
        //        List<string> registryKeyUsbDenyAllwithoutUSBKey = new List<string>();
        //        if (OSVersion.IsAfterVista && !OSVersion.IsWin2008R2)
        //        {
        //            //FD
        //            registryKeyUsbDenyAllwithoutUSBKey.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{53f56311-b6bf-11d0-94f2-00a0c91efb8b}");
        //            //Windows Portable Device
        //            registryKeyUsbDenyAllwithoutUSBKey.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{6AC27878-A6FA-4155-BA85-F98F491D4F33}");
        //            registryKeyUsbDenyAllwithoutUSBKey.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices\{F33FDC04-D1AC-4E8E-9A30-19BBD4B108AE}");
        //            //ALL
        //            //registryKeyUsbDenyAll.Add(@"SOFTWARE\Policies\Microsoft\Windows\RemovableStorageDevices");
        //        }
        //        else
        //        {
        //            registryKeyUsbDenyAllwithoutUSBKey.Add(@"SYSTEM\CurrentControlSet\Services\USBSTOR");
        //        }
        //        return registryKeyUsbDenyAllwithoutUSBKey;
        //    }

        //}

        //public static List<string> RegistryValueUsbDenyAllwithoutDenyWrite
        //{
        //    get
        //    {
        //        List<string> RegistryValueUsbDenyAllwithoutDenyWrite = new List<string>();
        //        if (OSVersion.IsAfterVista && !OSVersion.IsWin2008R2)
        //        {
        //            //DenyRead
        //            RegistryValueUsbDenyAllwithoutDenyWrite.Add(@"Deny_Read");
        //            //DenyExecute
        //            RegistryValueUsbDenyAllwithoutDenyWrite.Add(@"Deny_Execute");
        //        }
        //        else
        //        {
        //            RegistryValueUsbDenyAllwithoutDenyWrite.Add(@"start");
        //        }
        //        return RegistryValueUsbDenyAllwithoutDenyWrite;
        //    }
        //}

        //KatouTsuyoshi 20140120 edit end   --- OS情報の取得をAPI方式からWMI方式に変更

        public static string IsUSBAcceptable = @"3";
        public static string ISUSBDeny = @"4";

        //KatouTsuyoshi 20110523 edit start --- for Benkei:84813 C:\ is Hard coding.
        //public static string usbStorParentPATH = @"C:\WINDOWS\inf";
        //Ono Masatoshi 20140217 Fortify対応 start
        //public static string usbStorParentPATH = Environment.GetEnvironmentVariable("SystemRoot") + ITSecurityConstants.FolderSeparator + "inf";
        public static string usbStorParentPATH = System.IO.Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "inf");
        //Ono Masatoshi 20140217 Fortify対応 end

        //KatouTsuyoshi 20110523 edit end   --- for Benkei:84813 C:\ is Hard coding.

        public static string usbStorInfPATH = @"usbstor.inf";
        public static string usbStorPnfPATH = @"usbstor.PNF";

        public static string usbInfPATH = @"usbstor.inf";//@"usb.inf";
        public static string usbPnfPATH = @"usbstor.PNF";//@"usb.PNF";

        public static string usbDenyIsTrue = @"0x00000001";
        public static string usbDenyIsFalse = @"0x00000000";




        // add hama start 2010/4/14
        //[JA_JP] レジストリ登録機能
        public const string RegistryValueKindBinary = "Binary";
        public const string RegistryValueKindDWord = "DWord";
        public const string RegistryValueKindExpandString = "ExpandString";
        public const string RegistryValueKindMultiString = "MultiString";
        public const string RegistryValueKindQWord = "QWord";
        public const string RegistryValueKindString = "String";
        public const string RegistryRootKeyClassesRoot = "HKEY_CLASSES_ROOT";
        public const string RegistryRootKeyCurrentConfig = "HKEY_CURRENT_CONFIG";
        public const string RegistryRootKeyCurrentUser = "HKEY_CURRENT_USER";
        public const string RegistryRootKeyLocalMachine = "HKEY_LOCAL_MACHINE";
        public const string RegistryRootKeyUsers = "HKEY_USERS";
        // add hama end 2010/4/14

        // add hama start 2010/4/19
        public const string SupporOSWindowsXP = "Windows XP";
        //YangJiannan 2010/07/23 edit start
        public const string SupporOSWindows2003Server = "Windows Server 2003";
        //public const string SupporOSWindows2003Server = "Windows 2003 Server";
        //YangJiannan 2010/07/23 edit end
        public const string SupporOSWindowsVista = "Windows Vista";
        // add hama end 2010/4/19

        //YangJiannan 2010/08/06 add start --- Windows Server 2008対応
        public const string SupporOSWindowsServer2008 = "Windows Server 2008";
        //YangJiannan 2010/08/06 add end --- Windows Server 2008対応

        //KatouTusyoshi 2011/02/17 add start --- support OS expand
        public const string SupporOSWindowsServer2008R2 = "Windows Server 2008 R2";
        public const string SupporOSWindowsServer2003R2 = "Windows Server 2003 R2";
        public const string SupporOSWindows7 = "Windows 7";
        //KatouTusyoshi 2011/02/17 add end   --- support OS expand

        //YangJiannan 2010/07/21 add start --- legacy 対応
        //[JA_JP] RegistryEditレジストリ
        public const string RegistryKeySecurity = @"SOFTWARE\YOKOGAWA\CENTUMVP\Security";
        public const string RegistryValueLegacy = @"legacy";
        //YangJiannan 2010/07/21 add end --- legacy 対応

        //YangJiannan 2010/10/25 add start --- DefaultAccessPermission 対応
        public const string RegistryKeyMicrosoftOle = @"SOFTWARE\Microsoft\Ole";
        public const string RegistryValueDefaultAccessPermission = @"DefaultAccessPermission";
        //YangJiannan 2010/10/25 add end --- DefaultAccessPermission 対応
        #endregion

        // Kaseda Add Start 2010/05/28
        #region DCOM
        public const string DcomExternalModuleName = @"dcomperm.exe";
        public const string DcomPermSwDefaultAccess = @"-da";
        public const string DcomPermSwDefaultLaunch = @"-dl";
        public const string DcomPermSwRestrictionAccess = @"-ma";
        public const string DcomPermSwRestrictionLaunch = @"-ml";
        public const string DcomPermSwAccess = @"-aa";
        public const string DcomPermSwLaunch = @"-al";
        public const string DcomPermModeSet = @"set";
        public const string DcomPermModeRemove = @"remove";
        public const string DcomPermAccessPermit = @"permit";
        public const string DcomPermAccessDeny = @"deny";
        #endregion
        // Kaseda Add End 2010/05/28

        #region CommonProperty
        public const string CommonPropertyDisplayName = "DisplayName";
        public const string CommonPropertyRequired = "Required";
        public const string CommonPropertySelected = "Selected";
        public const string CommonPropertyConfirm = "Confirm";
        public const string CommonPropertyExplanation = "Explanation";
        public const string CommonPropertyUnSelected = "UnSelected";

        public const string CommonPropertyReserveName = "ReserveName";
        public const string CommonPropertyReserveNamePath = "Path";
        // K24 Add From komura 2010/06/09
        public const string CommonPropertyReserveNameKey = "Key";
        // K24 Add To komura 2010/06/09

        public const string CommonPropertyFirewall = "Firewall";
        public const string CommonPropertyProgramName = "ProgramName";
        public const string CommonPropertyServiceName = "ServiceName";
        public const string CommonPropertyFwPath = "Path";
        public const string CommonPropertyScope = "Scope";
        public const string CommonPropertyCustom = "Custom";
        public const string CommonPropertyPropertyName = "PropertyName";

        public const string CommonPropertyStartMode = "StartMode";
        public const string CommonPropertyAccount = "Account";
        public const string CommonPropertyPassword = "Password";

        //YangJiannan 2010/10/27 add start --- Services対応
        public const string CommonPropertyLogonType = "LogonType";
        public const string CommonPropertyDesktopInteract = "DesktopInteract";
        //YangJiannan 2010/10/27 add end --- Services対応

        #endregion

        #region Other
        public const char SplitSign = ',';
        public const string FolderSeparator = @"\";
        public const string DriveSeparator = @":\";
        public const string ReserveNameSeparator = @"%";
        // Kaseda Add Start 2010/05/28
        public const string DoubleQuote = "\"";
        // Kaseda Add End 2010/05/28

        public const string HeadExtName = ".hed";
        public const int HeadExtLength = 4;
        public const string BodyExtName = ".csf";
        public const int BodyExtLength = 4;

        //Yang edit start 20100616 --- ドメイン名の対応
        public const string DomainFileFlag = @"DOMAIN";
        public const string DomainReserveFlag = @"%TargetDomain%";
        //Yang edit end   20100616 --- ドメイン名の対応

        //YangJiannan 2010/12/09 add start --- COMBINATION対応
        public const string CombinationFileFlag = "COMBINATION";
        //YangJiannan 2010/12/09 add end --- COMBINATION対応

        //YangJiannan 2010/08/09 add start ---
        public const string WinDirReserveName = "%windir%";
        public const string System32Name = "system32";
        public const string SysNative = "sysnative";
        //KatouTsuyoshi 2014.01.07 add start --- Native変換ロジック対応 R10.03.00対応
        public const string windowsFolderName = "windows";
        public const string EnvValueProgramFiles = @"%programfiles%";
        public const string EnvValueCommonProgramFiles = @"%commonprogramfiles%";
        //KatouTsuyoshi 2014.01.07 add end   --- Native変換ロジック対応 R10.03.00対応

        //YangJiannan 2010/10/25 edit start --- system32保存対応
        //YangJiannan 2011/04/06 edit start --- Bug 83754
        public const string ToAdministrator32CmdPath = @".\ToAdministrator32.cmd";
        public const string ToAdministrator64CmdPath = @".\ToAdministrator64.cmd";
        public const string ToTrustedInstaller32CmdPath = @".\ToTrustedInstaller32.cmd";
        public const string ToTrustedInstaller64CmdPath = @".\ToTrustedInstaller64.cmd";
        //public const string ToAdministratorCmdPath = @".\ToAdministrator.cmd";
        //public const string ToTrustedInstallerCmdPath = @".\ToTrustedInstaller.cmd";
        //YangJiannan 2011/04/06 edit end --- Bug 83754

        //public const string ToAdministratorCmdPath = @"%ProgramFiles%\YOKOGAWA\IA\iPCS\Products\Security\Program\ToAdministrator.cmd";
        //public const string ToTrustedInstallerCmdPath = @"%ProgramFiles%\YOKOGAWA\IA\iPCS\Products\Security\Program\ToTrustedInstaller.cmd";
        //YangJiannan 2010/10/25 edit end --- system32保存対応
        //YangJiannan 2010/08/09 add end ---

        //KatouTsuyoshi 20110220 mod start --- PATH change
        //YangJiannan 2010/08/12 add start --- CTM_ENGINEER_ADM_LCL
        public const string CtmEngineerAdmLclName = "CTM_ENGINEER_ADM_LCL";
        public const string SetDCOMLongCmdPath = @".\SetDCOMLong.cmd";
        //YangJiannan 2010/08/12 add end --- CTM_ENGINEER_ADM_LCL
        //KatouTsuyoshi 20110220 mod end   --- PATH change

        //YangJiannan 2011/04/22 add start --- Bug 84209
        public const string RunFwCmdPath = @".\RunFw.cmd";
        //YangJiannan 2011/04/22 add end --- Bug 84209

        //YangJiannan 2010/10/26 add start --- ReserveKeyタグ対応
        public const string LeftRegistrySeperator = "{[";
        public const string RightRegistrySeperator = "]}";
        public const string LeftEnviromentSeperator = "{%";
        public const string RightEnviromentSeperator = "%}";
        public const string LeftReserveSeperator = "{$";
        public const string RightReserveSeperator = "$}";
        public const string LeftCommonAppDataSeparator = "{!";
        public const string RightCommonAppDataSeparator = "!}";
        public const string CommonAppDataFixedString = "_CommonApplicationData";
        public const string GuidSeperator = "{EFE6ACAF-3F7D-4784-BB41-0721E38E4BC5}";
        //YangJiannan 2010/10/26 add end --- ReserveKeyタグ対応

        // Katou.Tsuyoshi 2010/10/31 edit start --- Modified System32 Export for Administrators
        public const string CtmMaintenanceName = "CTM_MAINTENANCE";
        public const string AdministratorsSID = "s-1-5-32-544";
        public const string FullACL = "F";
        public const string isPermissionD11 = "d11";
        public const string isPermissionD12 = "d12";
        public const string isPermissionD13 = "d13";
        public const string AttributeSeparator = ",";
        // Katou.Tsuyoshi 2010/10/31 edit   end --- Modified System32 Export for Administrators

        //YangJiannan 2010/11/10 add start --- Comment delete対応
        public const string CommentName = "//comment()";
        //YangJiannan 2010/11/10 add end --- Comment delete対応

        //KatouTsuyoshi 2010/12/09 add start --- IF Tag対応
        public const string IFTagName = "///IF()";
        public const string XPathToLowerIFNodeName = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if']";
        public const string XPathTopNode_and_IFNode = XmlSecuritySettingNode + @"//" + XPathToLowerIFNodeName;
        //KatouTsuyoshi 2010/12/09 add end   --- IF Tag対応

        //Ono Masatoshi IF Reservekye対応
        public const string XPathToLowerIFTagNodeName = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if']";
        public const string XPathTopNode_and_IFTagNode = XmlSecuritySettingNode + @"//" + XPathToLowerIFTagNodeName;
        public const string XPathToLowerIF_RrvName = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if' or translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'reservekey']";
        public const string XPathTopNodeIF_RrvNode = ITSecurityConstants.XmlSecuritySettingNode + @"//" + XPathToLowerIF_RrvName;
        public const string XPathToLowerIF_SVName = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if' or translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'setvalue']";
        public const string XmlNodeIncludeFile = "includefile";
        public const string XPathToLowerIF_IncName = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if' or translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'includefile']";
        public const string XPathTopNodeIF_IncNode = ITSecurityConstants.XmlSecuritySettingNode + @"//" + XPathToLowerIF_IncName;
        //Ono Masatoshi IF Reservekye対応

        public const string XPath_NodeName_ProductConfigLinkedDomainManagement = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if' or translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'linkeddomainmanagement']";
        public const string XPath_NodeName_ProductConfigProduct = @"node()[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'if' or translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') = 'product']";

        //YangJiannan 2010/12/10 add start --- ConfirmManager
        public const string ConfirmTypeAccount = "Account";
        public const string ConfirmTypeFirewall = "Firewall";
        public const string ConfirmTypeSecurityOption = "SecurityOption";
        public const string ConfirmTypeDomain = "Domain";
        //YangJiannan 2010/12/10 add end --- ConfirmManager

        //YangJiannan 2010/01/13 add start --- /L mode definition file look up 
        public const string SettingFilesFolderName = @"SettingFiles";
        //YangJiannan 2010/01/13 add start --- /L mode definition file look up 

        public const string HardeningFileName = "_hardening";
        public const string UnhardeningFileName = "_unhardening";
        public const string FinalizeFileName = "_finalize";

        //YangJiannan 2011/03/08 add start --- CDRom start
        //public const string CDRomExtension = @"Yokogawa\IA\iPCS\Products\Platform\Security\System\Extension";
        public const string CDRomExtension = @"Yokogawa\IA\iPCS\Platform\Security\System\Extension";
        //YangJiannan 2011/03/08 add end --- CDRom start
        #endregion

        // Tsuyoshi.KATO add start 2012.11.21 --- Log message
        #region Log constant values
        public const string LogHeader_ProductVersion = @"ProductVersion: ";
        #endregion
        // Tsuyoshi.KATO add end 2012.11.21 --- Log message
        // CSE/T.Kobayashi add start 2016.10.27
        #region RegistryType
        public const string RegistryTypeString = @"string";
        public const string RegistryTypeDword = @"dword";
        public const string RegistryTypeQword = @"qword";
        public const string RegistryTypeMulti = @"multistring";
        public const string RegistryTypeExpand = @"expandstring";
        public const string RegistryTypeBinary = @"binary";
        #endregion
        // CSE/T.Kobayashi add end 2016.10.27

        public const string XmlNodeAdministartiveTemplate = @"administartivetemplate";
        public const string XmlNodeAdministartiveTemplateSetting = @"administartivetemplatesetting";

        // KatoTsuyoshi 20170214 add start --- Constant value for media 起動
        public const string MediaSettingModelDomainControllerUpperCase = "DOMAINCONTROLLER";
        public const string MediaSettingModelFileServerUpperCase = "FILESERVER";

    }
}
