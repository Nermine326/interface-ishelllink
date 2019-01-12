Imports System.Runtime.InteropServices
Imports System.Text
'commande d'affichage
Public Enum SW
  SW_NORMAL = &H1
  SW_MINIMIZED = &H2
  SW_MAXIMIZED = &H3
End Enum

'raccourci clavier
Public Enum HOTKEYF
  HOTKEYF_NONE = &H0
  HOTKEYF_SHIFT = &H1
  HOTKEYF_CONTROL = &H2
  HOTKEYF_ALT = &H4
  HOTKEYF_EXT = &H8
End Enum

'propriétés d'un raccourci
Public Class ShellLink
  Public Property TargetFile() As String
  Public Property WorkingDir() As String
  Public Property Decription() As String
  Public Property IconPath() As String
  Public Property IconIndex() As Integer
  Public Property HotKey() As Byte
  Public Property HotKeyModifier() As HOTKEYF
  Public Property ShowCommand() As SW
  Public Property Flags() As SHELL_LINK_DATA_FLAGS
  Public Property Arguments() As String

  Public Sub New()
    Me.TargetFile = String.Empty
    Me.WorkingDir = String.Empty
    Me.Decription = String.Empty
    Me.IconPath = String.Empty
    Me.IconIndex = -1
    Me.HotKey = 0
    Me.HotKeyModifier = HOTKEYF.HOTKEYF_NONE
    Me.ShowCommand = SW.SW_NORMAL
    Me.Arguments = String.Empty
  End Sub
End Class

Public Class ShellLinksManager

  '*********************************************
  'Ce module est basé sur le code de JC Alsup (www.vbbyjc.com)
  '(la fonction CreateShortCut)
  Private Const CLSCTX_INPROC_SERVER As Integer = 1
  'context flag
  Private Const S_OK As Integer = 0
  Private Const S_FALSE As Integer = 1
  Private Const cNULL As Integer = 0
  Private Const STGM_DIRECT As Integer = &H0
  Private Const SLR_UPDATE As Integer = &H4
  'flags
    Private Const EXP_DARWIN_ID_SIG As Integer = &HA0000006

  <DllImport("ole32.dll", CharSet := CharSet.Ansi, SetLastError := True, ExactSpelling := True)> _
  Public Shared Function CoCreateInstance(ByRef refCLSID As Guid, pkUnkOuter As IntPtr, dwClsContext As Integer, ByRef refIID As Guid, ByRef ppv As IntPtr) As Integer
  End Function
  <DllImport("shell32.dll", CharSet := CharSet.Ansi, SetLastError := True, ExactSpelling := True)> _
  Public Shared Function SHGetMalloc(ByRef ppMalloc As IntPtr) As Integer
  End Function
  <DllImport("shell32.dll", CharSet := CharSet.Ansi, SetLastError := True, ExactSpelling := True)> _
  Public Shared Function SHGetDesktopFolder(ByRef ppshf As IntPtr) As Integer
  End Function
  <DllImport("kernel32.dll", SetLastError := True)> _
  Shared Function LocalFree(hMem As IntPtr) As IntPtr
  End Function
  <DllImport("msi.dll", CharSet := CharSet.Unicode)> _
  Shared Function MsiGetProductInfo(product As String, [property] As String, <Out, MarshalAs(UnmanagedType.LPTStr)> valueBuf As StringBuilder, ByRef len As Integer) As Int32
  End Function

  '****************************************************************
  '    ByVal sShortcutTitle As String : titre du raccourci
  '    ByVal sTargetFile As String : fichier cible existant
  '    ByVal sCreateInPath As String : dossier dans lequel le fichier .lnk sera créé
  '    Optional ByVal sWorkingDir As String : dossier dans lequel la cible est executée
  '    Optional ByVal sIconPath As String : chemin du fichier contenant l'icone du raccourci
  '    Optional ByVal iIconIndex As Long : index de l'icone à afficher
  '    Optional ByVal iHotKey As Byte : Touche de raccourci (code Ascii)
  '    Optional ByVal iHotKeyModifier As HOTKEYF : touches de raccourci complementaires
  '    Optional ByVal iShowCommand As SW = SW_NORMAL : affichage de la cible
  '    Optional ByVal sArguments As String = "" : argument de la ligne de commande de l'executable cible
  '****************************************************************
  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer, _
    iHotKey As Byte, iHotKeyModifier As HOTKEYF, iShowCommand As SW, sArguments As String, sDescription As String, Optional flags As SHELL_LINK_DATA_FLAGS = DirectCast(0, SHELL_LINK_DATA_FLAGS))

    'un code d'erreur API

    'On définit les GUID dont on a besoins ----------------------------------------
    Dim IID_IShellLink As New Guid("000214EE-0000-0000-C000-000000000046")
    Dim IID_IPersistFile As New Guid("0000010B-0000-0000-C000-000000000046")
    Dim CLSID_ShellLink As New Guid("00021401-0000-0000-C000-000000000046")

    'CLSID_ShellLink = "{00021401-0000-0000-C000-000000000046}"
    'IID_IShellLink = "{000214EE-0000-0000-C000-000000000046}"
    'IID_IPersistFile = "{0000010B-0000-0000-C000-000000000046}"

    'on verifie que sCreateInPath se termine par un "\"
    If Not sCreateInPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
      sCreateInPath = sCreateInPath + System.IO.Path.DirectorySeparatorChar
    End If

    Dim sSHFile As String = sCreateInPath + sShortcutTitle + ".lnk"

    'on verifie que sCreateInPath ne se termine pas par un "\"
    If sWorkingDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
      sWorkingDir = sWorkingDir.Substring(0, sWorkingDir.Length - 2)
    End If

    Dim ppvMalloc As IntPtr = IntPtr.Zero
    Dim oMalloc As IMalloc = Nothing
    Dim ppvDesktop As IntPtr = IntPtr.Zero
    Dim oDesktop As IShellFolder = Nothing
    Dim pidl As IntPtr = IntPtr.Zero
    Dim nEaten As Integer = 0
    Dim ppvShellLink As IntPtr = IntPtr.Zero
    Dim oShellLink As IShellLink = Nothing
    Dim ppvIPersistFile As IntPtr = IntPtr.Zero
    Dim oPersistFile As IPersistFile = Nothing
    'On obtient le handle du Shell's memory allocator
    Dim r As Integer = SHGetMalloc(ppvMalloc)
    If r = S_OK Then
      oMalloc = DirectCast(Marshal.GetTypedObjectForIUnknown(ppvMalloc, GetType(IMalloc)), IMalloc)

      'On obtient le dossier du bureau.

      r = SHGetDesktopFolder(ppvDesktop)
      If r = S_OK Then
        oDesktop = DirectCast(Marshal.GetTypedObjectForIUnknown(ppvDesktop, GetType(IShellFolder)), IShellFolder)

        'On essaie d'obtenir le pidl de notre fichier cible.
        Dim tempRefParam2 As Integer = 0
        oDesktop.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, sTargetFile, nEaten, pidl, tempRefParam2)

        '----------------------------------------------------------------------
        'On crée un objet ShellLink (CoClass) et on demande son interface IShellLink

        'ShellLink coclass que nous allons créer.
        r = CoCreateInstance(CLSID_ShellLink, IntPtr.Zero, CLSCTX_INPROC_SERVER, IID_IShellLink, ppvShellLink)

        If r = S_OK Then
          'Succés - On crée un objet VB pour l'utiliser
          oShellLink = DirectCast(Marshal.GetTypedObjectForIUnknown(ppvShellLink, GetType(IShellLink)), IShellLink)

          'On définit la cible du raccourci
          oShellLink.SetIDList(pidl)

          'On remplie les differents propriétés du raccourci.
          '------------------------------------------------------------
          'On définit nom/description du raccourci
          oShellLink.SetDescription(sDescription)

          If Not String.IsNullOrEmpty(sWorkingDir) Then
            'On définit le répertoire de travail
            oShellLink.SetWorkingDirectory(sWorkingDir)
          End If

          If Not String.IsNullOrEmpty(sArguments) Then
            'On définit le ou les argument(s) de la ligne de commande
            oShellLink.SetArguments(sArguments)
          End If

          If Not String.IsNullOrEmpty(sIconPath) Then
            'On définit le chemin de l'icone (autre que celle du fichier cible)
            oShellLink.SetIconLocation(sIconPath, iIconIndex)
          End If

          If iHotKey <> 0 Then
            'On définie la touche de raccourci et les touches de raccourci de contrôle
                        oShellLink.SetHotkey(CShort(iHotKeyModifier << 8 + iHotKey))
          End If

          If (DirectCast(iShowCommand, Integer)) <> 0 Then
            'On définit la commande d'affichage
            oShellLink.SetShowCmd(DirectCast(iShowCommand, Integer))
          End If
        Else
          Marshal.ThrowExceptionForHR(r)
        End If

        'On résout le chemein de la cible pour être sur que tout est OK
        oShellLink.Resolve(0, SLR_UPDATE)
      Else
        Marshal.ThrowExceptionForHR(r)
      End If

      If flags <> 0 Then
        Dim dataList As IShellLinkDataList = DirectCast(oShellLink, IShellLinkDataList)
        Dim sFlags As SHELL_LINK_DATA_FLAGS
        dataList.GetFlags(sFlags)
        sFlags = sFlags Or flags
        dataList.SetFlags(sFlags)
      End If

      'Nous avons défini les propriété du raccourci, maintenant nous devons
      'l'enregistrer. Nous aurons besoin d'un pointeur vers
      'une interface IPersistFile de ShellLink pour enregistrer
      oPersistFile = DirectCast(oShellLink, IPersistFile)

      oPersistFile.Save(sSHFile, cNULL)

      'On nettoie et libère le pointeur vers IPersistFile.
      oPersistFile = Nothing

      'On nettoie et libère le pointeur vers IShellLink.
      oShellLink = Nothing
    Else
      Marshal.ThrowExceptionForHR(r)
    End If

    'On libère le pidl
    oMalloc.Free(pidl)

    'On nettoie et libère le pointeur vers Desktop Folder.
    oDesktop = Nothing

    'On nettoie et libère le pointeur vers IMalloc.
    oMalloc = Nothing
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer, _
    iHotKey As Byte, iHotKeyModifier As HOTKEYF, iShowCommand As SW, sArguments As String)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, iIconIndex, _
      iHotKey, iHotKeyModifier, iShowCommand, sArguments, "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer, _
    iHotKey As Byte, iHotKeyModifier As HOTKEYF, iShowCommand As SW)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, iIconIndex, _
      iHotKey, iHotKeyModifier, iShowCommand, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer, _
    iHotKey As Byte, iHotKeyModifier As HOTKEYF)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, iIconIndex, _
      iHotKey, iHotKeyModifier, SW.SW_NORMAL, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer, _
    iHotKey As Byte)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, iIconIndex, _
      iHotKey, HOTKEYF.HOTKEYF_SHIFT, SW.SW_NORMAL, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String, iIconIndex As Integer)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, iIconIndex, _
      0, HOTKEYF.HOTKEYF_SHIFT, SW.SW_NORMAL, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String, sIconPath As String)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, sIconPath, 0, _
      0, HOTKEYF.HOTKEYF_SHIFT, SW.SW_NORMAL, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String, sWorkingDir As String)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, sWorkingDir, [String].Empty, 0, _
      0, HOTKEYF.HOTKEYF_SHIFT, SW.SW_NORMAL, "", "")
  End Sub

  Public Shared Sub CreateShortcut(sShortcutTitle As String, sTargetFile As String, sCreateInPath As String)
    CreateShortcut(sShortcutTitle, sTargetFile, sCreateInPath, [String].Empty, [String].Empty, 0, _
      0, HOTKEYF.HOTKEYF_SHIFT, SW.SW_NORMAL, "", "")
  End Sub

  '**************************************************
  '   ByVal sFileName As String : chemin et nom du fichier .lnk
  '**************************************************
  Public Shared Function GetShortcut(sFileName As String) As ShellLink

    'Cette fonction retourne les propriétés d'un raccourci dans une structure ShellLink

    'On définit les GUID dont on a besoins ----------------------------------------
    Dim result As New ShellLink()
    Dim IID_IShellLink As New Guid("000214EE-0000-0000-C000-000000000046")
    Dim IID_IPersistFile As New Guid("0000010B-0000-0000-C000-000000000046")
    Dim CLSID_ShellLink As New Guid("00021401-0000-0000-C000-000000000046")

    'CLSID_ShellLink = "{00021401-0000-0000-C000-000000000046}"
    'IID_IShellLink = "{000214EE-0000-0000-C000-000000000046}"
    'IID_IPersistFile = "{0000010B-0000-0000-C000-000000000046}"

    '----------------------------------------------------------------------
    Dim sSHFile As String = [String].Empty

    '----------------------------------------------------------------------
    'On initialise COM (Ce n'est problablement pas nécessaire mais c'est une bonne
    'pratique néanmoins.

    Dim ppvShellLink As IntPtr = IntPtr.Zero
    Dim oShellLink As IShellLink = Nothing
    Dim oPersistFile As IPersistFile = Nothing
    Dim HotKey As Integer = 0
    '----------------------------------------------------------------------
    'On crée un objet ShellLink (CoClass) et on demande son interface IShellLink

    'ShellLink coclass que nous allons créer.
    Dim r As Integer = CoCreateInstance(CLSID_ShellLink, IntPtr.Zero, CLSCTX_INPROC_SERVER, IID_IShellLink, ppvShellLink)

    If r = S_OK Then
      'Succés - On crée un objet VB pour l'utiliser
      oShellLink = DirectCast(Marshal.GetTypedObjectForIUnknown(ppvShellLink, GetType(IShellLink)), IShellLink)

      'Nous avons un objet IShellLink. Nous allons maintenant ouvrir le fichier .lnk
      'Pour cela, nous avons besoin d'un pointeur vers une interface IPersistFile de ShellLink
      oPersistFile = DirectCast(oShellLink, IPersistFile)

      'On ouvre le raccourci
      oPersistFile.Load(sFileName, cNULL)
      Dim sb As StringBuilder
      'Ouverture réussie
      'On lit les differentes propriétés du raccourci
      sb = New StringBuilder(255)
      oShellLink.GetArguments(sb, 255)
      result.Arguments = sb.ToString()

      sb = New StringBuilder(255)
      oShellLink.GetDescription(sb, 255)
      result.Decription = sb.ToString()

            Dim tempRefParam4 As Short = CShort(HotKey)
      oShellLink.GetHotkey(tempRefParam4)
      HotKey = tempRefParam4
            result.HotKey = CByte(HotKey Mod 256)
            result.HotKeyModifier = DirectCast(CInt((HOTKEYF.HOTKEYF_ALT) \ 256), HOTKEYF)

      sb = New StringBuilder(255)
      oShellLink.GetIconLocation(sb, 255, result.IconIndex)
      result.IconPath = sb.ToString()

      sb = New StringBuilder(255)
      Dim tempRefParam5 As IntPtr = IntPtr.Zero
      oShellLink.GetPath(sb, 255, tempRefParam5, 0)
      result.TargetFile = sb.ToString()

      sb = New StringBuilder(255)
      oShellLink.GetWorkingDirectory(sb, 255)
      result.WorkingDir = sb.ToString()

      Dim tempRefParam6 As Integer = DirectCast(result.ShowCommand, Integer)
      oShellLink.GetShowCmd(tempRefParam6)
      result.ShowCommand = DirectCast(tempRefParam6, SW)

      Dim oShellLinkDataList As IShellLinkDataList = DirectCast(oShellLink, IShellLinkDataList)
      Dim flags As SHELL_LINK_DATA_FLAGS
      oShellLinkDataList.GetFlags(flags)
      result.Flags = flags

      If (flags And SHELL_LINK_DATA_FLAGS.SLDF_HAS_DARWINID) = SHELL_LINK_DATA_FLAGS.SLDF_HAS_DARWINID Then
        Dim ptr As IntPtr
        oShellLinkDataList.CopyDataBlock(EXP_DARWIN_ID_SIG, ptr)

        Dim dw As EXP_DARWIN_LINK = DirectCast(Marshal.PtrToStructure(ptr, GetType(EXP_DARWIN_LINK)), EXP_DARWIN_LINK)

        Dim len As Integer = 1024
        Dim productName As New StringBuilder(len)
        If (flags And SHELL_LINK_DATA_FLAGS.SLDF_UNICODE) = SHELL_LINK_DATA_FLAGS.SLDF_UNICODE Then
          MsiGetProductInfo(dw.uniDarwinID.szwDarwinID, "ProductName", productName, len)
        Else
          MsiGetProductInfo(dw.ansiDarwinID.szDarwinID, "ProductName", productName, len)
        End If

        result.TargetFile = productName.ToString()

        LocalFree(ptr)
      End If

      'On nettoie et on libère le pointeur vers IShellLink.
      oShellLink = Nothing
    Else
      Marshal.ThrowExceptionForHR(r)
    End If

    'On nettoie et on libère le pointeur vers IPersistFile.
    oPersistFile = Nothing

    Return result
  End Function

  '****************************************************************
  '    ByVal sShortcutTitle As String : titre du raccourci
  '    ByVal sCreateInPath As String : dossier dans lequel le fichier .lnk sera créé
  '    Shortcut As ShellLink : structure contenant les propriétés d'un raccourci à modifier
  '****************************************************************
  Public Shared Sub ModifyShortcut(sShortcutTitle As String, sCreateInPath As String, shortcut As ShellLink)
    CreateShortcut(sShortcutTitle, shortcut.TargetFile, sCreateInPath, shortcut.WorkingDir, shortcut.IconPath, shortcut.IconIndex, _
      shortcut.HotKey, shortcut.HotKeyModifier, shortcut.ShowCommand, shortcut.Arguments, shortcut.Decription)
  End Sub
End Class

