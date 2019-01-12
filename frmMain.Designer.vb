Partial Class frmMain
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTipMain As System.Windows.Forms.ToolTip
    Public CDOpen As System.Windows.Forms.OpenFileDialog
    Public WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents btnSaveLink As System.Windows.Forms.Button
    Public WithEvents btnOpenLink As System.Windows.Forms.Button
    Public WithEvents btnSetIconPath As System.Windows.Forms.Button
    Public WithEvents btnSetTarget As System.Windows.Forms.Button
    Public WithEvents txtShortcut As System.Windows.Forms.TextBox
    Public WithEvents cbShowCmd As System.Windows.Forms.ComboBox
    Public WithEvents txtIconIndex As System.Windows.Forms.TextBox
    Public WithEvents txtArgument As System.Windows.Forms.TextBox
    Public WithEvents txtIconPath As System.Windows.Forms.TextBox
    Public WithEvents txtDescription As System.Windows.Forms.TextBox
    Public WithEvents txtWorkingDir As System.Windows.Forms.TextBox
    Public WithEvents txtTarget As System.Windows.Forms.TextBox
    Public Label10 As System.Windows.Forms.Label
    Public Label9 As System.Windows.Forms.Label
    Public Label8 As System.Windows.Forms.Label
    Public Label7 As System.Windows.Forms.Label
    Public Label6 As System.Windows.Forms.Label
    Public Label5 As System.Windows.Forms.Label
    Public Label4 As System.Windows.Forms.Label
    Public Label3 As System.Windows.Forms.Label
    Public Frame2 As System.Windows.Forms.GroupBox
    Public txtCreateInPath As System.Windows.Forms.TextBox
    Public txtTitle As System.Windows.Forms.TextBox
    Public Label2 As System.Windows.Forms.Label
    Public Label1 As System.Windows.Forms.Label
    Public Frame1 As System.Windows.Forms.GroupBox
    Private listBoxComboBoxHelper1 As System.Windows.Forms.ListBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.CDOpen = New System.Windows.Forms.OpenFileDialog()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSaveLink = New System.Windows.Forms.Button()
        Me.btnOpenLink = New System.Windows.Forms.Button()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.txtFlags = New System.Windows.Forms.TextBox()
        Me.btnSetIconPath = New System.Windows.Forms.Button()
        Me.btnSetTarget = New System.Windows.Forms.Button()
        Me.txtShortcut = New System.Windows.Forms.TextBox()
        Me.cbShowCmd = New System.Windows.Forms.ComboBox()
        Me.txtIconIndex = New System.Windows.Forms.TextBox()
        Me.txtArgument = New System.Windows.Forms.TextBox()
        Me.txtIconPath = New System.Windows.Forms.TextBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.txtWorkingDir = New System.Windows.Forms.TextBox()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtCreateInPath = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.listBoxComboBoxHelper1 = New System.Windows.Forms.ListBox()
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(368, 352)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(161, 33)
        Me.btnClose.TabIndex = 26
        Me.btnClose.Text = "Fermer"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSaveLink
        '
        Me.btnSaveLink.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaveLink.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSaveLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveLink.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSaveLink.Location = New System.Drawing.Point(200, 352)
        Me.btnSaveLink.Name = "btnSaveLink"
        Me.btnSaveLink.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveLink.Size = New System.Drawing.Size(161, 33)
        Me.btnSaveLink.TabIndex = 25
        Me.btnSaveLink.Text = "Enregistrer"
        Me.btnSaveLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSaveLink.UseVisualStyleBackColor = False
        '
        'btnOpenLink
        '
        Me.btnOpenLink.BackColor = System.Drawing.SystemColors.Control
        Me.btnOpenLink.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnOpenLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenLink.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOpenLink.Location = New System.Drawing.Point(8, 352)
        Me.btnOpenLink.Name = "btnOpenLink"
        Me.btnOpenLink.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenLink.Size = New System.Drawing.Size(185, 33)
        Me.btnOpenLink.TabIndex = 24
        Me.btnOpenLink.Text = "Ouvrir"
        Me.btnOpenLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnOpenLink.UseVisualStyleBackColor = False
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.label11)
        Me.Frame2.Controls.Add(Me.txtFlags)
        Me.Frame2.Controls.Add(Me.btnSetIconPath)
        Me.Frame2.Controls.Add(Me.btnSetTarget)
        Me.Frame2.Controls.Add(Me.txtShortcut)
        Me.Frame2.Controls.Add(Me.cbShowCmd)
        Me.Frame2.Controls.Add(Me.txtIconIndex)
        Me.Frame2.Controls.Add(Me.txtArgument)
        Me.Frame2.Controls.Add(Me.txtIconPath)
        Me.Frame2.Controls.Add(Me.txtDescription)
        Me.Frame2.Controls.Add(Me.txtWorkingDir)
        Me.Frame2.Controls.Add(Me.txtTarget)
        Me.Frame2.Controls.Add(Me.Label10)
        Me.Frame2.Controls.Add(Me.Label9)
        Me.Frame2.Controls.Add(Me.Label8)
        Me.Frame2.Controls.Add(Me.Label7)
        Me.Frame2.Controls.Add(Me.Label6)
        Me.Frame2.Controls.Add(Me.Label5)
        Me.Frame2.Controls.Add(Me.Label4)
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 88)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(521, 257)
        Me.Frame2.TabIndex = 5
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Paramètres"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(8, 234)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(35, 13)
        Me.label11.TabIndex = 25
        Me.label11.Text = "Flags:"
        '
        'txtFlags
        '
        Me.txtFlags.AcceptsReturn = True
        Me.txtFlags.BackColor = System.Drawing.SystemColors.Window
        Me.txtFlags.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFlags.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlags.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFlags.Location = New System.Drawing.Point(48, 231)
        Me.txtFlags.MaxLength = 255
        Me.txtFlags.Name = "txtFlags"
        Me.txtFlags.ReadOnly = True
        Me.txtFlags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFlags.Size = New System.Drawing.Size(465, 20)
        Me.txtFlags.TabIndex = 24
        '
        'btnSetIconPath
        '
        Me.btnSetIconPath.BackColor = System.Drawing.SystemColors.Control
        Me.btnSetIconPath.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSetIconPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetIconPath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetIconPath.Location = New System.Drawing.Point(480, 104)
        Me.btnSetIconPath.Name = "btnSetIconPath"
        Me.btnSetIconPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSetIconPath.Size = New System.Drawing.Size(33, 17)
        Me.btnSetIconPath.TabIndex = 23
        Me.btnSetIconPath.Text = "..."
        Me.btnSetIconPath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSetIconPath.UseVisualStyleBackColor = False
        '
        'btnSetTarget
        '
        Me.btnSetTarget.BackColor = System.Drawing.SystemColors.Control
        Me.btnSetTarget.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSetTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetTarget.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSetTarget.Location = New System.Drawing.Point(480, 16)
        Me.btnSetTarget.Name = "btnSetTarget"
        Me.btnSetTarget.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSetTarget.Size = New System.Drawing.Size(33, 17)
        Me.btnSetTarget.TabIndex = 22
        Me.btnSetTarget.Text = "..."
        Me.btnSetTarget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnSetTarget.UseVisualStyleBackColor = False
        '
        'txtShortcut
        '
        Me.txtShortcut.AcceptsReturn = True
        Me.txtShortcut.BackColor = System.Drawing.SystemColors.Window
        Me.txtShortcut.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShortcut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortcut.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtShortcut.Location = New System.Drawing.Point(128, 160)
        Me.txtShortcut.MaxLength = 0
        Me.txtShortcut.Name = "txtShortcut"
        Me.txtShortcut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtShortcut.Size = New System.Drawing.Size(385, 20)
        Me.txtShortcut.TabIndex = 21
        '
        'cbShowCmd
        '
        Me.cbShowCmd.BackColor = System.Drawing.SystemColors.Window
        Me.cbShowCmd.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbShowCmd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbShowCmd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbShowCmd.Items.AddRange(New Object() {"Fenêtre normal", "Fenêtre réduite", "Fenêtre agrandie"})
        Me.cbShowCmd.Location = New System.Drawing.Point(368, 128)
        Me.cbShowCmd.Name = "cbShowCmd"
        Me.cbShowCmd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbShowCmd.Size = New System.Drawing.Size(145, 21)
        Me.cbShowCmd.TabIndex = 19
        '
        'txtIconIndex
        '
        Me.txtIconIndex.AcceptsReturn = True
        Me.txtIconIndex.BackColor = System.Drawing.SystemColors.Window
        Me.txtIconIndex.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIconIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIconIndex.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIconIndex.Location = New System.Drawing.Point(104, 128)
        Me.txtIconIndex.MaxLength = 0
        Me.txtIconIndex.Name = "txtIconIndex"
        Me.txtIconIndex.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIconIndex.Size = New System.Drawing.Size(81, 20)
        Me.txtIconIndex.TabIndex = 17
        '
        'txtArgument
        '
        Me.txtArgument.AcceptsReturn = True
        Me.txtArgument.BackColor = System.Drawing.SystemColors.Window
        Me.txtArgument.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtArgument.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArgument.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArgument.Location = New System.Drawing.Point(184, 40)
        Me.txtArgument.MaxLength = 0
        Me.txtArgument.Name = "txtArgument"
        Me.txtArgument.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtArgument.Size = New System.Drawing.Size(329, 20)
        Me.txtArgument.TabIndex = 15
        '
        'txtIconPath
        '
        Me.txtIconPath.AcceptsReturn = True
        Me.txtIconPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtIconPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIconPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIconPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIconPath.Location = New System.Drawing.Point(104, 104)
        Me.txtIconPath.MaxLength = 0
        Me.txtIconPath.Name = "txtIconPath"
        Me.txtIconPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIconPath.Size = New System.Drawing.Size(377, 20)
        Me.txtIconPath.TabIndex = 13
        '
        'txtDescription
        '
        Me.txtDescription.AcceptsReturn = True
        Me.txtDescription.BackColor = System.Drawing.SystemColors.Window
        Me.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescription.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDescription.Location = New System.Drawing.Point(8, 208)
        Me.txtDescription.MaxLength = 255
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDescription.Size = New System.Drawing.Size(505, 20)
        Me.txtDescription.TabIndex = 10
        '
        'txtWorkingDir
        '
        Me.txtWorkingDir.AcceptsReturn = True
        Me.txtWorkingDir.BackColor = System.Drawing.SystemColors.Window
        Me.txtWorkingDir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWorkingDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkingDir.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWorkingDir.Location = New System.Drawing.Point(96, 80)
        Me.txtWorkingDir.MaxLength = 0
        Me.txtWorkingDir.Name = "txtWorkingDir"
        Me.txtWorkingDir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWorkingDir.Size = New System.Drawing.Size(417, 20)
        Me.txtWorkingDir.TabIndex = 9
        '
        'txtTarget
        '
        Me.txtTarget.AcceptsReturn = True
        Me.txtTarget.BackColor = System.Drawing.SystemColors.Window
        Me.txtTarget.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTarget.Enabled = False
        Me.txtTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarget.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTarget.Location = New System.Drawing.Point(48, 16)
        Me.txtTarget.MaxLength = 0
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTarget.Size = New System.Drawing.Size(433, 20)
        Me.txtTarget.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(8, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(113, 17)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Touche de raccourci :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(312, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(57, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Exécuter :"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 128)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(97, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Index de l'icone :"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(8, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(177, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Argument de la ligne de commande :"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(8, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(97, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Chemin de l'icone :"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(8, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(505, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Commentaire :"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Démarrer dans :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cible :"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtCreateInPath)
        Me.Frame1.Controls.Add(Me.txtTitle)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(521, 73)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Fichier"
        '
        'txtCreateInPath
        '
        Me.txtCreateInPath.AcceptsReturn = True
        Me.txtCreateInPath.BackColor = System.Drawing.SystemColors.Window
        Me.txtCreateInPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCreateInPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateInPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCreateInPath.Location = New System.Drawing.Point(200, 40)
        Me.txtCreateInPath.MaxLength = 0
        Me.txtCreateInPath.Name = "txtCreateInPath"
        Me.txtCreateInPath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCreateInPath.Size = New System.Drawing.Size(313, 20)
        Me.txtCreateInPath.TabIndex = 3
        '
        'txtTitle
        '
        Me.txtTitle.AcceptsReturn = True
        Me.txtTitle.BackColor = System.Drawing.SystemColors.Window
        Me.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTitle.Location = New System.Drawing.Point(8, 40)
        Me.txtTitle.MaxLength = 0
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTitle.Size = New System.Drawing.Size(185, 20)
        Me.txtTitle.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(200, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(313, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Créer dans :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(185, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Titre :"
        '
        'listBoxComboBoxHelper1
        '
        Me.listBoxComboBoxHelper1.Location = New System.Drawing.Point(0, 0)
        Me.listBoxComboBoxHelper1.Name = "listBoxComboBoxHelper1"
        Me.listBoxComboBoxHelper1.Size = New System.Drawing.Size(120, 96)
        Me.listBoxComboBoxHelper1.TabIndex = 0
        '
        'ShortCut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(534, 389)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSaveLink)
        Me.Controls.Add(Me.btnOpenLink)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 30)
        Me.Name = "ShortCut"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Raccourci"
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private label11 As System.Windows.Forms.Label
    Public txtFlags As System.Windows.Forms.TextBox
End Class

