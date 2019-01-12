Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.InteropServices

Public Enum ESFGAO
    SFGAO_BROWSABLE = &H8000000
    SFGAO_CANCOPY = 1
    SFGAO_CANDELETE = &H20
    SFGAO_CANLINK = 4
    SFGAO_CANMOVE = 2
    SFGAO_CANRENAME = &H10
    SFGAO_CAPABILITYMASK = &H177
    SFGAO_COMPRESSED = &H4000000
    SFGAO_CONTENTSMASK = -2147483648
    SFGAO_DISPLAYATTRMASK = &HF0000
    SFGAO_DROPTARGET = &H100
    SFGAO_FILESYSANCESTOR = &H10000000
    SFGAO_FILESYSTEM = &H40000000
    SFGAO_FOLDER = &H20000000
    SFGAO_GHOSTED = &H80000
    SFGAO_HASPROPSHEET = &H40
    SFGAO_HASSUBFOLDER = -2147483648
    SFGAO_LINK = &H10000
    SFGAO_NONENUMERATED = &H100000
    SFGAO_READONLY = &H40000
    SFGAO_REMOVABLE = &H2000000
    SFGAO_SHARE = &H20000
    SFGAO_VALIDATE = &H1000000
End Enum

Public Enum ESHCONTF
    SHCONTF_FOLDERS = &H20
    SHCONTF_INCLUDEHIDDEN = &H80
    SHCONTF_NONFOLDERS = &H40
End Enum

Public Enum ESHGNO
    SHGDN_FORADDRESSBAR = &H4000
    SHGDN_FORPARSING = &H8000
    SHGDN_INFOLDER = 1
    SHGDN_NORMAL = 0
End Enum

Public Enum ESTRRET
    STRRET_WSTR
    STRRET_OFFSET
    STRRET_CSTR
End Enum

<Flags()> _
Public Enum SHELL_LINK_DATA_FLAGS
    SLDF_DEFAULT = &H0
    SLDF_HAS_ID_LIST = &H1
    SLDF_HAS_LINK_INFO = &H2
    SLDF_HAS_NAME = &H4
    SLDF_HAS_RELPATH = &H8
    SLDF_HAS_WORKINGDIR = &H10
    SLDF_HAS_ARGS = &H20
    SLDF_HAS_ICONLOCATION = &H40
    SLDF_UNICODE = &H80
    SLDF_FORCE_NO_LINKINFO = &H100
    SLDF_HAS_EXP_SZ = &H200
    SLDF_RUN_IN_SEPARATE = &H400
    SLDF_HAS_LOGO3ID = &H800
    SLDF_HAS_DARWINID = &H1000
    SLDF_RUNAS_USER = &H2000
    SLDF_HAS_EXP_ICON_SZ = &H4000
    SLDF_NO_PIDL_ALIAS = &H8000
    SLDF_FORCE_UNCNAME = &H10000
    SLDF_RUN_WITH_SHIMLAYER = &H20000
    SLDF_FORCE_NO_LINKTRACK = &H40000
    SLDF_ENABLE_TARGET_METADATA = &H800000
    SLDF_DISABLE_LINK_PATH_TRACKING = &H100000
    SLDF_DISABLE_KNOWNFOLDER_RELATIVE_TRACKING = &H200000
    SLDF_NO_KF_ALIAS = &H400000
    SLDF_ALLOW_LINK_TO_LINK = &H800000
    SLDF_UNALIAS_ON_SAVE = &H1000000
    SLDF_PREFER_ENVIRONMENT_PATH = &H2000000
    SLDF_KEEP_LOCAL_IDLIST_FOR_UNC_TARGET = &H4000000
    SLDF_PERSIST_VOLUME_ID_RELATIVE = &H8000000
    SLDF_VALID = &HFFFF7FF
    SLDF_RESERVED = &H80000000
End Enum

<ComImport(), Guid("00000002-0000-0000-C000-000000000046"), InterfaceType(1)> _
Public Interface IMalloc
    <PreserveSig()> _
    Function Alloc(<[In]()> ByVal cb As Integer) As Integer
    <PreserveSig()> _
    Function Realloc(<[In]()> ByVal pv As IntPtr, <[In]()> ByVal cb As Integer) As Integer
    <PreserveSig()> _
    Sub Free(<[In]()> ByVal pv As IntPtr)
    <PreserveSig()> _
    Function GetSize(<[In]()> ByVal pv As IntPtr) As Integer
    <PreserveSig()> _
    Function DidAlloc(<[In]()> ByVal pv As IntPtr) As Integer
    <PreserveSig()> _
    Sub HeapMinimize()
End Interface

<ComImport(), Guid("0000010C-0000-0000-C000-000000000046"), InterfaceType(1)> _
Public Interface IPersist
    Sub GetClassID(<[In](), Out()> ByRef pClassID As Guid)
End Interface

<ComImport(), InterfaceType(1), Guid("0000010B-0000-0000-C000-000000000046")> _
Public Interface IPersistFile
    Inherits IPersist
    Sub GetClassID(<[In](), Out()> ByRef pClassID As Guid)
    <PreserveSig()> _
    Function IsDirty() As Integer
    Sub Load(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, <[In]()> ByVal dwMode As Integer)
    Sub Save(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, <[In]()> ByVal fRemember As Integer)
    Sub SaveCompleted(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String)
    Sub GetCurFile(<[In](), Out(), MarshalAs(UnmanagedType.LPWStr)> ByRef ppszFileName As String)
End Interface

<ComImport(), InterfaceType(1), Guid("000214E6-0000-0000-C000-000000000046")> _
Public Interface IShellFolder
    Sub ParseDisplayName(<[In]()> ByVal hwndOwner As IntPtr, <[In]()> ByVal pbcReserved As IntPtr, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpszDisplayName As String, <[In](), Out()> ByRef pchEaten As Integer, <[In](), Out()> ByRef ppidl As IntPtr, <[In](), Out()> ByRef pdwAttributes As Integer)
    Sub EnumObjects(<[In]()> ByVal hwndOwner As Integer, <[In]()> ByVal grfFlags As Integer, <[In](), Out()> ByRef ppenumIDList As Integer)
    Sub BindToObject(<[In]()> ByVal pidl As Integer, <[In]()> ByVal pbcReserved As Integer, <[In]()> ByRef riid As Guid, <[In](), Out()> ByRef ppvOut As Integer)
    Sub BindToStorage(<[In]()> ByVal pidl As Integer, <[In]()> ByVal pbcReserved As Integer, <[In]()> ByRef riid As Guid, <[In](), Out()> ByRef ppvObj As Integer)
    Sub CompareIDs(<[In]()> ByVal lParam As Integer, <[In]()> ByVal pidl1 As Integer, <[In]()> ByVal pidl2 As Integer)
    Sub CreateViewObject(<[In]()> ByVal hwndOwner As Integer, <[In]()> ByRef riid As Guid, <[In](), Out()> ByRef ppvOut As Integer)
    Sub GetAttributesOf(<[In]()> ByVal cidl As Integer, <[In]()> ByRef apidl As Integer, <[In](), Out()> ByRef rgfInOut As Integer)
    Sub GetUIObjectOf(<[In]()> ByVal hwndOwner As Integer, <[In]()> ByVal cidl As Integer, <[In]()> ByRef apidl As Integer, <[In]()> ByRef riid As Guid, <[In](), Out()> ByRef prgfInOut As Integer, <[In](), Out()> ByRef ppvOut As Integer)
    Sub GetDisplayNameOf(<[In]()> ByVal pidl As Integer, <[In]()> ByVal uFlags As Integer, <[In](), Out()> ByRef lpName As STRRET)
    Sub SetNameOf(<[In]()> ByVal hwndOwner As Integer, <[In]()> ByVal pidl As Integer, <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal lpszName As String, <[In]()> ByVal uFlags As Integer, <[In](), Out()> ByRef ppidlOut As Integer)
End Interface

<ComImport(), InterfaceType(1), Guid("000214EE-0000-0000-C000-000000000046")> _
Public Interface IShellLink
    Sub GetPath(<[In](), Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszFile As StringBuilder, <[In]()> ByVal cchMaxPath As Integer, <[In](), Out()> ByVal pfd As IntPtr, <[In]()> ByVal fFlags As Integer)
    Sub GetIDList(ByRef ppidl As Integer)
    Sub SetIDList(<[In]()> ByVal pidl As IntPtr)
    Sub GetDescription(<[In](), Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszName As StringBuilder, <[In]()> ByVal cchMaxName As Integer)
    Sub SetDescription(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszName As String)
    Sub GetWorkingDirectory(<[In](), Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszDir As StringBuilder, <[In]()> ByVal cchMaxPath As Integer)
    Sub SetWorkingDirectory(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszDir As String)
    Sub GetArguments(<[In](), Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszArgs As StringBuilder, <[In]()> ByVal cchMaxPath As Integer)
    Sub SetArguments(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszArgs As String)
    Sub GetHotkey(<[In](), Out()> ByRef pwHotkey As Short)
    Sub SetHotkey(<[In]()> ByVal wHotkey As Short)
    Sub GetShowCmd(ByRef piShowCmd As Integer)
    Sub SetShowCmd(<[In]()> ByVal iShowCmd As Integer)
    Sub GetIconLocation(<[In](), Out(), MarshalAs(UnmanagedType.LPStr)> ByVal pszIconPath As StringBuilder, <[In]()> ByVal cchIconPath As Integer, <[In](), Out()> ByRef piIcon As Integer)
    Sub SetIconLocation(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszIconPath As String, <[In]()> ByVal iIcon As Integer)
    Sub SetRelativePath(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszPathRel As String, <[In]()> ByVal dwReserved As Integer)
    Sub Resolve(<[In]()> ByVal hwnd As Integer, <[In]()> ByVal fFlags As Integer)
    Sub SetPath(<[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszFile As String)
End Interface

<ComImportAttribute(), _
 GuidAttribute("45e2b4ae-b1c3-11d0-b92f-00a0c90312e1"), _
 InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)> _
Public Interface IShellLinkDataList
    Sub AddDataBlock(ByVal pDataBlock As IntPtr)
    Sub CopyDataBlock(ByVal dwSig As Integer, ByRef ppDataBlock As IntPtr)
    Sub RemoveDataBlock(ByVal dwSig As Integer)
    Sub GetFlags(ByRef pdwFlags As SHELL_LINK_DATA_FLAGS)
    Sub SetFlags(ByVal dwFlags As SHELL_LINK_DATA_FLAGS)
End Interface

<StructLayout(LayoutKind.Sequential, Pack:=2)> _
Public Structure ITEMIDLIST
    Public mkid As SHITEMID
End Structure

<ComImport(), InterfaceType(1), Guid("00000000-0000-0000-C000-000000000046")> _
Public Interface IUnknown
End Interface

<StructLayout(LayoutKind.Sequential, Pack:=2)> _
Public Structure SHITEMID
    Public cb As Short
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> _
    Public abID As Byte()
End Structure

<StructLayout(LayoutKind.Sequential, Pack:=4)> _
Public Structure STRRET
    Public uType As ESTRRET
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=260)> _
    Public [cStr] As Byte()
End Structure

<StructLayout(LayoutKind.Sequential, Pack:=4)> _
Public Structure DATABLOCK_HEADER
    Private cbSize As Integer
    Private dwSignature As Integer
End Structure
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)> _
Public Structure EXP_DARWIN_LINK_ANSI
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szDarwinID As String
End Structure
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode, Pack:=4)> _
Public Structure EXP_DARWIN_LINK_UNI
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
    Public szwDarwinID As String
End Structure
<StructLayout(LayoutKind.Sequential, Pack:=4)> _
Public Structure EXP_DARWIN_LINK
    Public dbh As DATABLOCK_HEADER
    Public ansiDarwinID As EXP_DARWIN_LINK_ANSI
    Public uniDarwinID As EXP_DARWIN_LINK_UNI
End Structure

