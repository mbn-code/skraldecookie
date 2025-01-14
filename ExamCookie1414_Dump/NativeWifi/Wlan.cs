// Decompiled with JetBrains decompiler
// Type: NativeWifi.Wlan
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace NativeWifi
{
  public static class Wlan
  {
    public const uint WLAN_CLIENT_VERSION_XP_SP2 = 1;
    public const uint WLAN_CLIENT_VERSION_LONGHORN = 2;

    [DllImport("wlanapi.dll")]
    public static extern int WlanOpenHandle(
      [In] uint clientVersion,
      [In, Out] IntPtr pReserved,
      out uint negotiatedVersion,
      out IntPtr clientHandle);

    [DllImport("wlanapi.dll")]
    public static extern int WlanCloseHandle([In] IntPtr clientHandle, [In, Out] IntPtr pReserved);

    [DllImport("wlanapi.dll")]
    public static extern int WlanEnumInterfaces(
      [In] IntPtr clientHandle,
      [In, Out] IntPtr pReserved,
      out IntPtr ppInterfaceList);

    [DllImport("wlanapi.dll")]
    public static extern int WlanQueryInterface(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] Wlan.WlanIntfOpcode opCode,
      [In, Out] IntPtr pReserved,
      out int dataSize,
      out IntPtr ppData,
      out Wlan.WlanOpcodeValueType wlanOpcodeValueType);

    [DllImport("wlanapi.dll")]
    public static extern int WlanSetInterface(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] Wlan.WlanIntfOpcode opCode,
      [In] uint dataSize,
      [In] IntPtr pData,
      [In, Out] IntPtr pReserved);

    [DllImport("wlanapi.dll")]
    public static extern int WlanScan(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] IntPtr pDot11Ssid,
      [In] IntPtr pIeData,
      [In, Out] IntPtr pReserved);

    [DllImport("wlanapi.dll")]
    public static extern int WlanGetAvailableNetworkList(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] Wlan.WlanGetAvailableNetworkFlags flags,
      [In, Out] IntPtr reservedPtr,
      out IntPtr availableNetworkListPtr);

    [DllImport("wlanapi.dll")]
    public static extern int WlanSetProfile(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] Wlan.WlanProfileFlags flags,
      [MarshalAs(UnmanagedType.LPWStr), In] string profileXml,
      [MarshalAs(UnmanagedType.LPWStr), In, Optional] string allUserProfileSecurity,
      [In] bool overwrite,
      [In] IntPtr pReserved,
      out Wlan.WlanReasonCode reasonCode);

    [DllImport("wlanapi.dll")]
    public static extern int WlanGetProfile(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [MarshalAs(UnmanagedType.LPWStr), In] string profileName,
      [In] IntPtr pReserved,
      out IntPtr profileXml,
      [Optional] out Wlan.WlanProfileFlags flags,
      [Optional] out Wlan.WlanAccess grantedAccess);

    [DllImport("wlanapi.dll")]
    public static extern int WlanGetProfileList(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] IntPtr pReserved,
      out IntPtr profileList);

    [DllImport("wlanapi.dll")]
    public static extern void WlanFreeMemory(IntPtr pMemory);

    [DllImport("wlanapi.dll")]
    public static extern int WlanReasonCodeToString(
      [In] Wlan.WlanReasonCode reasonCode,
      [In] int bufferSize,
      [In, Out] StringBuilder stringBuffer,
      IntPtr pReserved);

    [DllImport("wlanapi.dll")]
    public static extern int WlanRegisterNotification(
      [In] IntPtr clientHandle,
      [In] Wlan.WlanNotificationSource notifSource,
      [In] bool ignoreDuplicate,
      [In] Wlan.WlanNotificationCallbackDelegate funcCallback,
      [In] IntPtr callbackContext,
      [In] IntPtr reserved,
      out Wlan.WlanNotificationSource prevNotifSource);

    [DllImport("wlanapi.dll")]
    public static extern int WlanConnect(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] ref Wlan.WlanConnectionParameters connectionParameters,
      IntPtr pReserved);

    [DllImport("wlanapi.dll")]
    public static extern int WlanDeleteProfile(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [MarshalAs(UnmanagedType.LPWStr), In] string profileName,
      IntPtr reservedPtr);

    [DllImport("wlanapi.dll")]
    public static extern int WlanGetNetworkBssList(
      [In] IntPtr clientHandle,
      [MarshalAs(UnmanagedType.LPStruct), In] Guid interfaceGuid,
      [In] IntPtr dot11SsidInt,
      [In] Wlan.Dot11BssType dot11BssType,
      [In] bool securityEnabled,
      IntPtr reservedPtr,
      out IntPtr wlanBssList);

    [DebuggerStepThrough]
    internal static void ThrowIfError(int win32ErrorCode)
    {
      if (win32ErrorCode != 0)
        throw new Win32Exception(win32ErrorCode);
    }

    public enum WlanIntfOpcode
    {
      AutoconfEnabled = 1,
      BackgroundScanEnabled = 2,
      MediaStreamingMode = 3,
      RadioState = 4,
      BssType = 5,
      InterfaceState = 6,
      CurrentConnection = 7,
      ChannelNumber = 8,
      SupportedInfrastructureAuthCipherPairs = 9,
      SupportedAdhocAuthCipherPairs = 10, // 0x0000000A
      SupportedCountryOrRegionStringList = 11, // 0x0000000B
      CurrentOperationMode = 12, // 0x0000000C
      Statistics = 268435713, // 0x10000101
      RSSI = 268435714, // 0x10000102
      SecurityStart = 536936448, // 0x20010000
      SecurityEnd = 805306367, // 0x2FFFFFFF
      IhvStart = 805306368, // 0x30000000
      IhvEnd = 1073741823, // 0x3FFFFFFF
    }

    public enum WlanOpcodeValueType
    {
      QueryOnly,
      SetByGroupPolicy,
      SetByUser,
      Invalid,
    }

    [Flags]
    public enum WlanGetAvailableNetworkFlags
    {
      IncludeAllAdhocProfiles = 1,
      IncludeAllManualHiddenProfiles = 2,
    }

    internal struct WlanAvailableNetworkListHeader
    {
      public uint numberOfItems;
      public uint index;
    }

    [Flags]
    public enum WlanAvailableNetworkFlags
    {
      Connected = 1,
      HasProfile = 2,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanAvailableNetwork
    {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string profileName;
      public Wlan.Dot11Ssid dot11Ssid;
      public Wlan.Dot11BssType dot11BssType;
      public uint numberOfBssids;
      public bool networkConnectable;
      public Wlan.WlanReasonCode wlanNotConnectableReason;
      private uint numberOfPhyTypes;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
      private Wlan.Dot11PhyType[] dot11PhyTypes;
      public bool morePhyTypes;
      public uint wlanSignalQuality;
      public bool securityEnabled;
      public Wlan.Dot11AuthAlgorithm dot11DefaultAuthAlgorithm;
      public Wlan.Dot11CipherAlgorithm dot11DefaultCipherAlgorithm;
      public Wlan.WlanAvailableNetworkFlags flags;
      private uint reserved;

      public Wlan.Dot11PhyType[] Dot11PhyTypes
      {
        get
        {
          Wlan.Dot11PhyType[] destinationArray = new Wlan.Dot11PhyType[(int) this.numberOfPhyTypes];
          Array.Copy((Array) this.dot11PhyTypes, (Array) destinationArray, (long) this.numberOfPhyTypes);
          return destinationArray;
        }
      }
    }

    [Flags]
    public enum WlanProfileFlags
    {
      AllUser = 0,
      GroupPolicy = 1,
      User = 2,
    }

    [Flags]
    public enum WlanAccess
    {
      ReadAccess = 131073, // 0x00020001
      ExecuteAccess = 131105, // 0x00020021
      WriteAccess = 458787, // 0x00070023
    }

    [Flags]
    public enum WlanNotificationSource
    {
      None = 0,
      All = 65535, // 0x0000FFFF
      ACM = 8,
      MSM = 16, // 0x00000010
      Security = 32, // 0x00000020
      IHV = 64, // 0x00000040
    }

    public enum WlanNotificationCodeAcm
    {
      AutoconfEnabled = 1,
      AutoconfDisabled = 2,
      BackgroundScanEnabled = 3,
      BackgroundScanDisabled = 4,
      BssTypeChange = 5,
      PowerSettingChange = 6,
      ScanComplete = 7,
      ScanFail = 8,
      ConnectionStart = 9,
      ConnectionComplete = 10, // 0x0000000A
      ConnectionAttemptFail = 11, // 0x0000000B
      FilterListChange = 12, // 0x0000000C
      InterfaceArrival = 13, // 0x0000000D
      InterfaceRemoval = 14, // 0x0000000E
      ProfileChange = 15, // 0x0000000F
      ProfileNameChange = 16, // 0x00000010
      ProfilesExhausted = 17, // 0x00000011
      NetworkNotAvailable = 18, // 0x00000012
      NetworkAvailable = 19, // 0x00000013
      Disconnecting = 20, // 0x00000014
      Disconnected = 21, // 0x00000015
      AdhocNetworkStateChange = 22, // 0x00000016
    }

    public enum WlanNotificationCodeMsm
    {
      Associating = 1,
      Associated = 2,
      Authenticating = 3,
      Connected = 4,
      RoamingStart = 5,
      RoamingEnd = 6,
      RadioStateChange = 7,
      SignalQualityChange = 8,
      Disassociating = 9,
      Disconnected = 10, // 0x0000000A
      PeerJoin = 11, // 0x0000000B
      PeerLeave = 12, // 0x0000000C
      AdapterRemoval = 13, // 0x0000000D
      AdapterOperationModeChange = 14, // 0x0000000E
    }

    public struct WlanNotificationData
    {
      public Wlan.WlanNotificationSource notificationSource;
      public int notificationCode;
      public Guid interfaceGuid;
      public int dataSize;
      public IntPtr dataPtr;

      public object NotificationCode
      {
        get
        {
          switch (this.notificationSource)
          {
            case Wlan.WlanNotificationSource.ACM:
              return (object) (Wlan.WlanNotificationCodeAcm) this.notificationCode;
            case Wlan.WlanNotificationSource.MSM:
              return (object) (Wlan.WlanNotificationCodeMsm) this.notificationCode;
            default:
              return (object) this.notificationCode;
          }
        }
      }
    }

    public delegate void WlanNotificationCallbackDelegate(
      ref Wlan.WlanNotificationData notificationData,
      IntPtr context);

    [Flags]
    public enum WlanConnectionFlags
    {
      HiddenNetwork = 1,
      AdhocJoinOnly = 2,
      IgnorePrivacyBit = 4,
      EapolPassthrough = 8,
    }

    public struct WlanConnectionParameters
    {
      public Wlan.WlanConnectionMode wlanConnectionMode;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string profile;
      public IntPtr dot11SsidPtr;
      public IntPtr desiredBssidListPtr;
      public Wlan.Dot11BssType dot11BssType;
      public Wlan.WlanConnectionFlags flags;
    }

    public enum WlanAdhocNetworkState
    {
      Formed,
      Connected,
    }

    internal struct WlanBssListHeader
    {
      internal uint totalSize;
      internal uint numberOfItems;
    }

    public struct WlanBssEntry
    {
      public Wlan.Dot11Ssid dot11Ssid;
      public uint phyId;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
      public byte[] dot11Bssid;
      public Wlan.Dot11BssType dot11BssType;
      public Wlan.Dot11PhyType dot11BssPhyType;
      public int rssi;
      public uint linkQuality;
      public bool inRegDomain;
      public ushort beaconPeriod;
      public ulong timestamp;
      public ulong hostTimestamp;
      public ushort capabilityInformation;
      public uint chCenterFrequency;
      public Wlan.WlanRateSet wlanRateSet;
      public uint ieOffset;
      public uint ieSize;
    }

    public struct WlanRateSet
    {
      private uint rateSetLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 126)]
      private ushort[] rateSet;

      public ushort[] Rates
      {
        get
        {
          ushort[] destinationArray = new ushort[(int) (this.rateSetLength / 2U)];
          Array.Copy((Array) this.rateSet, (Array) destinationArray, destinationArray.Length);
          return destinationArray;
        }
      }

      public double GetRateInMbps(int rateIndex)
      {
        if (rateIndex < 0 || rateIndex > this.rateSet.Length)
          throw new ArgumentOutOfRangeException(nameof (rateIndex));
        return (double) ((int) this.rateSet[rateIndex] & (int) short.MaxValue) * 0.5;
      }
    }

    public class WlanException : Exception
    {
      private readonly Wlan.WlanReasonCode reasonCode;

      public WlanException(Wlan.WlanReasonCode reasonCode) => this.reasonCode = reasonCode;

      public Wlan.WlanReasonCode ReasonCode => this.reasonCode;

      public override string Message
      {
        get
        {
          StringBuilder stringBuffer = new StringBuilder(1024);
          return Wlan.WlanReasonCodeToString(this.reasonCode, stringBuffer.Capacity, stringBuffer, IntPtr.Zero) == 0 ? stringBuffer.ToString() : string.Empty;
        }
      }
    }

    public enum WlanReasonCode
    {
      Success = 0,
      RANGE_SIZE = 65536, // 0x00010000
      UNKNOWN = 65537, // 0x00010001
      AC_BASE = 131072, // 0x00020000
      BASE = 131072, // 0x00020000
      NETWORK_NOT_COMPATIBLE = 131073, // 0x00020001
      PROFILE_NOT_COMPATIBLE = 131074, // 0x00020002
      AC_CONNECT_BASE = 163840, // 0x00028000
      NO_AUTO_CONNECTION = 163841, // 0x00028001
      NOT_VISIBLE = 163842, // 0x00028002
      GP_DENIED = 163843, // 0x00028003
      USER_DENIED = 163844, // 0x00028004
      BSS_TYPE_NOT_ALLOWED = 163845, // 0x00028005
      IN_FAILED_LIST = 163846, // 0x00028006
      IN_BLOCKED_LIST = 163847, // 0x00028007
      SSID_LIST_TOO_LONG = 163848, // 0x00028008
      CONNECT_CALL_FAIL = 163849, // 0x00028009
      SCAN_CALL_FAIL = 163850, // 0x0002800A
      NETWORK_NOT_AVAILABLE = 163851, // 0x0002800B
      PROFILE_CHANGED_OR_DELETED = 163852, // 0x0002800C
      KEY_MISMATCH = 163853, // 0x0002800D
      USER_NOT_RESPOND = 163854, // 0x0002800E
      AC_END = 196607, // 0x0002FFFF
      MSM_BASE = 196608, // 0x00030000
      UNSUPPORTED_SECURITY_SET_BY_OS = 196609, // 0x00030001
      UNSUPPORTED_SECURITY_SET = 196610, // 0x00030002
      BSS_TYPE_UNMATCH = 196611, // 0x00030003
      PHY_TYPE_UNMATCH = 196612, // 0x00030004
      DATARATE_UNMATCH = 196613, // 0x00030005
      MSM_CONNECT_BASE = 229376, // 0x00038000
      USER_CANCELLED = 229377, // 0x00038001
      ASSOCIATION_FAILURE = 229378, // 0x00038002
      ASSOCIATION_TIMEOUT = 229379, // 0x00038003
      PRE_SECURITY_FAILURE = 229380, // 0x00038004
      START_SECURITY_FAILURE = 229381, // 0x00038005
      SECURITY_FAILURE = 229382, // 0x00038006
      SECURITY_TIMEOUT = 229383, // 0x00038007
      ROAMING_FAILURE = 229384, // 0x00038008
      ROAMING_SECURITY_FAILURE = 229385, // 0x00038009
      ADHOC_SECURITY_FAILURE = 229386, // 0x0003800A
      DRIVER_DISCONNECTED = 229387, // 0x0003800B
      DRIVER_OPERATION_FAILURE = 229388, // 0x0003800C
      IHV_NOT_AVAILABLE = 229389, // 0x0003800D
      IHV_NOT_RESPONDING = 229390, // 0x0003800E
      DISCONNECT_TIMEOUT = 229391, // 0x0003800F
      INTERNAL_FAILURE = 229392, // 0x00038010
      UI_REQUEST_TIMEOUT = 229393, // 0x00038011
      TOO_MANY_SECURITY_ATTEMPTS = 229394, // 0x00038012
      MSM_END = 262143, // 0x0003FFFF
      MSMSEC_BASE = 262144, // 0x00040000
      MSMSEC_MIN = 262144, // 0x00040000
      MSMSEC_PROFILE_INVALID_KEY_INDEX = 262145, // 0x00040001
      MSMSEC_PROFILE_PSK_PRESENT = 262146, // 0x00040002
      MSMSEC_PROFILE_KEY_LENGTH = 262147, // 0x00040003
      MSMSEC_PROFILE_PSK_LENGTH = 262148, // 0x00040004
      MSMSEC_PROFILE_NO_AUTH_CIPHER_SPECIFIED = 262149, // 0x00040005
      MSMSEC_PROFILE_TOO_MANY_AUTH_CIPHER_SPECIFIED = 262150, // 0x00040006
      MSMSEC_PROFILE_DUPLICATE_AUTH_CIPHER = 262151, // 0x00040007
      MSMSEC_PROFILE_RAWDATA_INVALID = 262152, // 0x00040008
      MSMSEC_PROFILE_INVALID_AUTH_CIPHER = 262153, // 0x00040009
      MSMSEC_PROFILE_ONEX_DISABLED = 262154, // 0x0004000A
      MSMSEC_PROFILE_ONEX_ENABLED = 262155, // 0x0004000B
      MSMSEC_PROFILE_INVALID_PMKCACHE_MODE = 262156, // 0x0004000C
      MSMSEC_PROFILE_INVALID_PMKCACHE_SIZE = 262157, // 0x0004000D
      MSMSEC_PROFILE_INVALID_PMKCACHE_TTL = 262158, // 0x0004000E
      MSMSEC_PROFILE_INVALID_PREAUTH_MODE = 262159, // 0x0004000F
      MSMSEC_PROFILE_INVALID_PREAUTH_THROTTLE = 262160, // 0x00040010
      MSMSEC_PROFILE_PREAUTH_ONLY_ENABLED = 262161, // 0x00040011
      MSMSEC_CAPABILITY_NETWORK = 262162, // 0x00040012
      MSMSEC_CAPABILITY_NIC = 262163, // 0x00040013
      MSMSEC_CAPABILITY_PROFILE = 262164, // 0x00040014
      MSMSEC_CAPABILITY_DISCOVERY = 262165, // 0x00040015
      MSMSEC_PROFILE_PASSPHRASE_CHAR = 262166, // 0x00040016
      MSMSEC_PROFILE_KEYMATERIAL_CHAR = 262167, // 0x00040017
      MSMSEC_PROFILE_WRONG_KEYTYPE = 262168, // 0x00040018
      MSMSEC_MIXED_CELL = 262169, // 0x00040019
      MSMSEC_PROFILE_AUTH_TIMERS_INVALID = 262170, // 0x0004001A
      MSMSEC_PROFILE_INVALID_GKEY_INTV = 262171, // 0x0004001B
      MSMSEC_TRANSITION_NETWORK = 262172, // 0x0004001C
      MSMSEC_PROFILE_KEY_UNMAPPED_CHAR = 262173, // 0x0004001D
      MSMSEC_CAPABILITY_PROFILE_AUTH = 262174, // 0x0004001E
      MSMSEC_CAPABILITY_PROFILE_CIPHER = 262175, // 0x0004001F
      MSMSEC_CONNECT_BASE = 294912, // 0x00048000
      MSMSEC_UI_REQUEST_FAILURE = 294913, // 0x00048001
      MSMSEC_AUTH_START_TIMEOUT = 294914, // 0x00048002
      MSMSEC_AUTH_SUCCESS_TIMEOUT = 294915, // 0x00048003
      MSMSEC_KEY_START_TIMEOUT = 294916, // 0x00048004
      MSMSEC_KEY_SUCCESS_TIMEOUT = 294917, // 0x00048005
      MSMSEC_M3_MISSING_KEY_DATA = 294918, // 0x00048006
      MSMSEC_M3_MISSING_IE = 294919, // 0x00048007
      MSMSEC_M3_MISSING_GRP_KEY = 294920, // 0x00048008
      MSMSEC_PR_IE_MATCHING = 294921, // 0x00048009
      MSMSEC_SEC_IE_MATCHING = 294922, // 0x0004800A
      MSMSEC_NO_PAIRWISE_KEY = 294923, // 0x0004800B
      MSMSEC_G1_MISSING_KEY_DATA = 294924, // 0x0004800C
      MSMSEC_G1_MISSING_GRP_KEY = 294925, // 0x0004800D
      MSMSEC_PEER_INDICATED_INSECURE = 294926, // 0x0004800E
      MSMSEC_NO_AUTHENTICATOR = 294927, // 0x0004800F
      MSMSEC_NIC_FAILURE = 294928, // 0x00048010
      MSMSEC_CANCELLED = 294929, // 0x00048011
      MSMSEC_KEY_FORMAT = 294930, // 0x00048012
      MSMSEC_DOWNGRADE_DETECTED = 294931, // 0x00048013
      MSMSEC_PSK_MISMATCH_SUSPECTED = 294932, // 0x00048014
      MSMSEC_FORCED_FAILURE = 294933, // 0x00048015
      MSMSEC_SECURITY_UI_FAILURE = 294934, // 0x00048016
      MSMSEC_END = 327679, // 0x0004FFFF
      MSMSEC_MAX = 327679, // 0x0004FFFF
      PROFILE_BASE = 524288, // 0x00080000
      INVALID_PROFILE_SCHEMA = 524289, // 0x00080001
      PROFILE_MISSING = 524290, // 0x00080002
      INVALID_PROFILE_NAME = 524291, // 0x00080003
      INVALID_PROFILE_TYPE = 524292, // 0x00080004
      INVALID_PHY_TYPE = 524293, // 0x00080005
      MSM_SECURITY_MISSING = 524294, // 0x00080006
      IHV_SECURITY_NOT_SUPPORTED = 524295, // 0x00080007
      IHV_OUI_MISMATCH = 524296, // 0x00080008
      IHV_OUI_MISSING = 524297, // 0x00080009
      IHV_SETTINGS_MISSING = 524298, // 0x0008000A
      CONFLICT_SECURITY = 524299, // 0x0008000B
      SECURITY_MISSING = 524300, // 0x0008000C
      INVALID_BSS_TYPE = 524301, // 0x0008000D
      INVALID_ADHOC_CONNECTION_MODE = 524302, // 0x0008000E
      NON_BROADCAST_SET_FOR_ADHOC = 524303, // 0x0008000F
      AUTO_SWITCH_SET_FOR_ADHOC = 524304, // 0x00080010
      AUTO_SWITCH_SET_FOR_MANUAL_CONNECTION = 524305, // 0x00080011
      IHV_SECURITY_ONEX_MISSING = 524306, // 0x00080012
      PROFILE_SSID_INVALID = 524307, // 0x00080013
      TOO_MANY_SSID = 524308, // 0x00080014
      PROFILE_CONNECT_BASE = 557056, // 0x00088000
      PROFILE_END = 589823, // 0x0008FFFF
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanConnectionNotificationData
    {
      public Wlan.WlanConnectionMode wlanConnectionMode;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string profileName;
      public Wlan.Dot11Ssid dot11Ssid;
      public Wlan.Dot11BssType dot11BssType;
      public bool securityEnabled;
      public Wlan.WlanReasonCode wlanReasonCode;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
      public string profileXml;
    }

    public enum WlanInterfaceState
    {
      NotReady,
      Connected,
      AdHocNetworkFormed,
      Disconnecting,
      Disconnected,
      Associating,
      Discovering,
      Authenticating,
    }

    public struct Dot11Ssid
    {
      public uint SSIDLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
      public byte[] SSID;
    }

    public enum Dot11PhyType : uint
    {
      Any = 0,
      Unknown = 0,
      FHSS = 1,
      DSSS = 2,
      IrBaseband = 3,
      OFDM = 4,
      HRDSSS = 5,
      ERP = 6,
      IHV_Start = 2147483648, // 0x80000000
      IHV_End = 4294967295, // 0xFFFFFFFF
    }

    public enum Dot11BssType
    {
      Infrastructure = 1,
      Independent = 2,
      Any = 3,
    }

    public struct WlanAssociationAttributes
    {
      public Wlan.Dot11Ssid dot11Ssid;
      public Wlan.Dot11BssType dot11BssType;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
      public byte[] dot11Bssid;
      public Wlan.Dot11PhyType dot11PhyType;
      public uint dot11PhyIndex;
      public uint wlanSignalQuality;
      public uint rxRate;
      public uint txRate;

      public PhysicalAddress Dot11Bssid => new PhysicalAddress(this.dot11Bssid);
    }

    public enum WlanConnectionMode
    {
      Profile,
      TemporaryProfile,
      DiscoverySecure,
      DiscoveryUnsecure,
      Auto,
      Invalid,
    }

    public enum Dot11AuthAlgorithm : uint
    {
      IEEE80211_Open = 1,
      IEEE80211_SharedKey = 2,
      WPA = 3,
      WPA_PSK = 4,
      WPA_None = 5,
      RSNA = 6,
      RSNA_PSK = 7,
      IHV_Start = 2147483648, // 0x80000000
      IHV_End = 4294967295, // 0xFFFFFFFF
    }

    public enum Dot11CipherAlgorithm : uint
    {
      None = 0,
      WEP40 = 1,
      TKIP = 2,
      CCMP = 4,
      WEP104 = 5,
      RSN_UseGroup = 256, // 0x00000100
      WPA_UseGroup = 256, // 0x00000100
      WEP = 257, // 0x00000101
      IHV_Start = 2147483648, // 0x80000000
      IHV_End = 4294967295, // 0xFFFFFFFF
    }

    public struct WlanSecurityAttributes
    {
      [MarshalAs(UnmanagedType.Bool)]
      public bool securityEnabled;
      [MarshalAs(UnmanagedType.Bool)]
      public bool oneXEnabled;
      public Wlan.Dot11AuthAlgorithm dot11AuthAlgorithm;
      public Wlan.Dot11CipherAlgorithm dot11CipherAlgorithm;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanConnectionAttributes
    {
      public Wlan.WlanInterfaceState isState;
      public Wlan.WlanConnectionMode wlanConnectionMode;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string profileName;
      public Wlan.WlanAssociationAttributes wlanAssociationAttributes;
      public Wlan.WlanSecurityAttributes wlanSecurityAttributes;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanInterfaceInfo
    {
      public Guid interfaceGuid;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string interfaceDescription;
      public Wlan.WlanInterfaceState isState;
    }

    internal struct WlanInterfaceInfoListHeader
    {
      public uint numberOfItems;
      public uint index;
    }

    internal struct WlanProfileInfoListHeader
    {
      public uint numberOfItems;
      public uint index;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanProfileInfo
    {
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
      public string profileName;
      public Wlan.WlanProfileFlags profileFlags;
    }

    [Flags]
    public enum Dot11OperationMode : uint
    {
      Unknown = 0,
      Station = 1,
      AP = 2,
      ExtensibleStation = 4,
      NetworkMonitor = 2147483648, // 0x80000000
    }

    public enum Dot11RadioState : uint
    {
      Unknown,
      On,
      Off,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanPhyRadioState
    {
      public int dwPhyIndex;
      public Wlan.Dot11RadioState dot11SoftwareRadioState;
      public Wlan.Dot11RadioState dot11HardwareRadioState;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WlanRadioState
    {
      public int numberofItems;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
      private Wlan.WlanPhyRadioState[] phyRadioState;

      public Wlan.WlanPhyRadioState[] PhyRadioState
      {
        get
        {
          Wlan.WlanPhyRadioState[] destinationArray = new Wlan.WlanPhyRadioState[this.numberofItems];
          Array.Copy((Array) this.phyRadioState, (Array) destinationArray, this.numberofItems);
          return destinationArray;
        }
      }
    }
  }
}
