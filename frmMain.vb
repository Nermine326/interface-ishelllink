Imports System.Windows.Forms

Partial Friend Class frmMain
    Inherits System.Windows.Forms.Form
    Private Sub btnSetTarget_Click(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles btnSetTarget.Click
        CDOpen.Filter = "Tous|*.*"
        If CDOpen.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Return
        End If
        txtTarget.Text = CDOpen.FileName
    End Sub

    Private Sub btnSetIconPath_Click(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles btnSetIconPath.Click
        CDOpen.Filter = "Tous|*.*"
        If CDOpen.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
            Return
        End If
        txtIconPath.Text = CDOpen.FileName
    End Sub

    Private Sub btnOpenLink_Click(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles btnOpenLink.Click
        Try
            CDOpen.Filter = "Lien|*.lnk"
            CDOpen.FilterIndex = 0
            If CDOpen.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
                Return
            End If
            Dim sh As ShellLink = ShellLinksManager.GetShortcut(CDOpen.FileName)
            txtTarget.Text = sh.TargetFile
            txtCreateInPath.Text = System.IO.Path.GetDirectoryName(CDOpen.FileName)
            txtTitle.Text = System.IO.Path.GetFileNameWithoutExtension(CDOpen.FileName)
            cbShowCmd.SelectedIndex = (DirectCast(sh.ShowCommand, Integer)) - 1
            txtArgument.Text = sh.Arguments
            txtIconPath.Text = (If(String.IsNullOrEmpty(sh.IconPath), sh.TargetFile, sh.IconPath))
            txtIconIndex.Text = sh.IconIndex.ToString()
            txtShortcut.Text = GetHK(sh.HotKey, sh.HotKeyModifier)
            txtDescription.Text = sh.Decription
            txtWorkingDir.Text = sh.WorkingDir
            txtFlags.Text = sh.Flags.ToString()
        Catch ex As Exception
            MessageBox.Show(Me, "Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSaveLink_Click(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles btnSaveLink.Click
        Try
            Dim HKM As HOTKEYF = HOTKEYF.HOTKEYF_NONE

            Dim HK As Byte = 0
            If Not String.IsNullOrEmpty(txtShortcut.Text) Then
                If txtShortcut.Text.Contains("KeyAscii") Then
                    HK = [Byte].Parse(System.Text.RegularExpressions.Regex.Match(txtShortcut.Text, "KeyAscii\((\d+)\)").Result("$1"))
                End If
                If txtShortcut.Text.IndexOf("Shift") >= 0 Then
                    HKM = HKM Or HOTKEYF.HOTKEYF_SHIFT
                End If
                If txtShortcut.Text.IndexOf("Ctrl") >= 0 Then
                    HKM = HKM Or HOTKEYF.HOTKEYF_CONTROL
                End If
                If txtShortcut.Text.IndexOf("Alt") >= 0 Then
                    HKM = HKM Or HOTKEYF.HOTKEYF_ALT
                End If
            End If
            Dim iconIdx As Integer
            If Not Integer.TryParse(txtIconIndex.Text, iconIdx) Then
                iconIdx = 0
            End If

            Dim lnk As String = System.IO.Path.Combine(txtCreateInPath.Text, txtTitle.Text + ".lnk")
            If System.IO.File.Exists(lnk) AndAlso MessageBox.Show(Me, "Link already exists. Do you want to overwrite ?", "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then
                Return
            End If

            ShellLinksManager.CreateShortcut(txtTitle.Text, txtTarget.Text, txtCreateInPath.Text, txtWorkingDir.Text, txtIconPath.Text, iconIdx, _
              HK, HKM, DirectCast((cbShowCmd.SelectedIndex + 1), SW), txtArgument.Text, txtDescription.Text)

            MessageBox.Show(Me, "Link created successfully !", "Create link", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(Me, "Error:" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ShortCut_Load(ByVal eventSender As [Object], ByVal eventArgs As EventArgs) Handles MyBase.Load
    End Sub

    Private Function GetHK(ByVal HotKey As Byte, ByVal Modifier As HOTKEYF) As String
        Dim result As String = [String].Empty
        If (Modifier And HOTKEYF.HOTKEYF_ALT) = HOTKEYF.HOTKEYF_ALT Then
            result = "Alt + "
        End If
        If (Modifier And HOTKEYF.HOTKEYF_CONTROL) = HOTKEYF.HOTKEYF_CONTROL Then
            result = result + "Ctrl + "
        End If
        If (Modifier And HOTKEYF.HOTKEYF_SHIFT) = HOTKEYF.HOTKEYF_SHIFT Then
            result = result + "Shift + "
        End If
        Return result + "KeyAscii(" + HotKey.ToString() + ")"
    End Function

    Private Sub Raccourci_KeyUp(ByVal eventSender As [Object], ByVal eventArgs As KeyEventArgs) Handles txtShortcut.KeyUp
        Dim KeyCode As Integer = DirectCast(eventArgs.KeyCode, Integer)
        If (KeyCode = (DirectCast(Keys.Left, Integer))) OrElse (KeyCode = (DirectCast(Keys.Right, Integer))) OrElse (KeyCode = (DirectCast(Keys.Up, Integer))) OrElse (KeyCode = (DirectCast(Keys.Down, Integer))) OrElse (KeyCode = (DirectCast(Keys.Escape, Integer))) OrElse (KeyCode = (DirectCast(Keys.[Return], Integer))) OrElse (KeyCode = (DirectCast(Keys.Menu, Integer))) OrElse (KeyCode = (DirectCast(Keys.ControlKey, Integer))) OrElse (KeyCode = (DirectCast(Keys.ShiftKey, Integer))) Then
            Return
        End If

        txtShortcut.Text = ""
        If (KeyCode = (DirectCast(Keys.Delete, Integer))) OrElse (KeyCode = (DirectCast(Keys.Back, Integer))) Then
            Return
        End If
        If (eventArgs.Modifiers And Keys.Alt) = Keys.Alt Then
            txtShortcut.Text = "Alt + "
        End If
        If (eventArgs.Modifiers And Keys.Control) = Keys.Control Then
            txtShortcut.Text = txtShortcut.Text + "Ctrl + "
        End If
        If (eventArgs.Modifiers And Keys.Shift) = Keys.Shift Then
            txtShortcut.Text = txtShortcut.Text + "Shift + "
        End If
        txtShortcut.Text = txtShortcut.Text + "KeyAscii(" + KeyCode.ToString() + ")"
    End Sub
End Class

