using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace _4Test
{
    public class RunEnviroment
    {
        private static string _currentOSMajor = string.Empty;
        private static string _buildNumber = string.Empty;
        private static string _currentOSMajorMinor = string.Empty;
        public static bool argumentFlagT = false;
        private static string _currentOSMinor = string.Empty;
        private static string _currentOSMajorMinorBuildNumber = string.Empty;
        private enum VersionType
        {
            MajorVersion,
            MinorVersion,
            BuildNumber
        }
        private static string PeriodSeparator = @".";
        public static string CurrentOSMajorMinor
        {
            get
            {
                if (string.IsNullOrEmpty(_currentOSMajorMinor))
                {
                    //
                    _currentOSMajorMinor = CurrentOSMajor + PeriodSeparator + CurrentOSMinor;
                }
                return _currentOSMajorMinor;
            }
        }
        public static string CurrentOSMajor
        {
            get
            {
                if (string.IsNullOrEmpty(_currentOSMajor))
                {
                    // 取得処理
                    _currentOSMajor = GetOSVersionInfo(VersionType.MajorVersion);
                }
                return _currentOSMajor;
            }
        }
        public static string CurrentOSMinor
        {
            get
            {
                if (string.IsNullOrEmpty(_currentOSMinor))
                {
                    // 取得処理
                    _currentOSMinor = GetOSVersionInfo(VersionType.MinorVersion);
                }
                return _currentOSMinor;
            }
        }
        public static string BuildNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_buildNumber))
                {
                    _buildNumber = GetOSVersionInfo(VersionType.BuildNumber);
                }
                return _buildNumber;
            }
        }
        public static string CurrentOSMajorMinorBuildNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_currentOSMajorMinorBuildNumber))
                {
                    _currentOSMajorMinorBuildNumber = CurrentOSMajor + PeriodSeparator + CurrentOSMinor + PeriodSeparator + BuildNumber;
                }
                return _currentOSMajorMinorBuildNumber;
            }
        }
        private static string GetOSVersionInfo(VersionType vType)
        {
            string targetValue = string.Empty;
            string result = string.Empty;
            string wmiNamespace = @"root\CIMV2";
            string queryMessage = @"SELECT * FROM Win32_OperatingSystem";
            string pv_Version = @"Version";

            try
            {
                ManagementObjectSearcher MOSearcher = new ManagementObjectSearcher(wmiNamespace, queryMessage);
                foreach (ManagementObject queryObj in MOSearcher.Get())
                {
                    result = queryObj[pv_Version].ToString();
                }

                // 指定された部分だけ切り取って戻す。
                if (!string.IsNullOrEmpty(result))
                {
                    string[] splitResult = result.Split('.');
                    if (vType == VersionType.MajorVersion)
                    {
                        targetValue = splitResult[0];
                    }
                    else if (vType == VersionType.MinorVersion)
                    {
                        targetValue = splitResult[1];
                    }
                    else if (vType == VersionType.BuildNumber)
                    {
                        targetValue = splitResult[2];
                    }
                }
            }
            catch (ManagementException e)
            {
                result = e.Message;
            }
            return targetValue;
        }
    }
}
