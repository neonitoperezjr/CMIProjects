<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.cmbAppList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFormHandler2 = New System.Windows.Forms.Label()
        Me.Bgw1 = New System.ComponentModel.BackgroundWorker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtboxProgramPath = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtboxApplicationName = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtboxStatus = New System.Windows.Forms.TextBox()
        Me.txtboxVersion = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblNewVersionAvailable = New System.Windows.Forms.Label()
        Me.btnTaskManager = New System.Windows.Forms.Button()
        Me.btnUninstall = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.Gray
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.FlatAppearance.BorderSize = 0
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(24, 304)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(494, 32)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "&UPDATE"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'cmbAppList
        '
        Me.cmbAppList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAppList.FormattingEnabled = True
        Me.cmbAppList.Location = New System.Drawing.Point(23, 116)
        Me.cmbAppList.Name = "cmbAppList"
        Me.cmbAppList.Size = New System.Drawing.Size(494, 21)
        Me.cmbAppList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Application Name"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(23, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(494, 2)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(-4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(544, 2)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Label5"
        '
        'lblFormHandler2
        '
        Me.lblFormHandler2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFormHandler2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.lblFormHandler2.ForeColor = System.Drawing.Color.White
        Me.lblFormHandler2.Location = New System.Drawing.Point(-3, 2)
        Me.lblFormHandler2.Name = "lblFormHandler2"
        Me.lblFormHandler2.Size = New System.Drawing.Size(544, 40)
        Me.lblFormHandler2.TabIndex = 12
        Me.lblFormHandler2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 7.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(230, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "CMI SD 2018"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblStatus.Location = New System.Drawing.Point(13, 73)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(43, 13)
        Me.LblStatus.TabIndex = 15
        Me.LblStatus.Text = "Status"
        '
        'LblVersion
        '
        Me.LblVersion.AutoSize = True
        Me.LblVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LblVersion.Location = New System.Drawing.Point(7, 51)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(49, 13)
        Me.LblVersion.TabIndex = 14
        Me.LblVersion.Text = "Version"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtboxProgramPath)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtboxApplicationName)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtboxStatus)
        Me.GroupBox2.Controls.Add(Me.txtboxVersion)
        Me.GroupBox2.Controls.Add(Me.LblVersion)
        Me.GroupBox2.Controls.Add(Me.LblStatus)
        Me.GroupBox2.Location = New System.Drawing.Point(23, 153)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(494, 101)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "APPLICATION CURRENTLY INSTALLED IN YOUR COMPUTER"
        '
        'txtboxProgramPath
        '
        Me.txtboxProgramPath.BackColor = System.Drawing.Color.White
        Me.txtboxProgramPath.Location = New System.Drawing.Point(64, 92)
        Me.txtboxProgramPath.Name = "txtboxProgramPath"
        Me.txtboxProgramPath.ReadOnly = True
        Me.txtboxProgramPath.Size = New System.Drawing.Size(421, 20)
        Me.txtboxProgramPath.TabIndex = 25
        Me.txtboxProgramPath.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(24, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Path"
        Me.Label8.Visible = False
        '
        'txtboxApplicationName
        '
        Me.txtboxApplicationName.BackColor = System.Drawing.Color.White
        Me.txtboxApplicationName.Location = New System.Drawing.Point(64, 26)
        Me.txtboxApplicationName.Name = "txtboxApplicationName"
        Me.txtboxApplicationName.ReadOnly = True
        Me.txtboxApplicationName.Size = New System.Drawing.Size(421, 20)
        Me.txtboxApplicationName.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(16, 29)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Name"
        '
        'txtboxStatus
        '
        Me.txtboxStatus.BackColor = System.Drawing.Color.White
        Me.txtboxStatus.Location = New System.Drawing.Point(64, 70)
        Me.txtboxStatus.Name = "txtboxStatus"
        Me.txtboxStatus.ReadOnly = True
        Me.txtboxStatus.Size = New System.Drawing.Size(421, 20)
        Me.txtboxStatus.TabIndex = 20
        '
        'txtboxVersion
        '
        Me.txtboxVersion.BackColor = System.Drawing.Color.White
        Me.txtboxVersion.Location = New System.Drawing.Point(64, 48)
        Me.txtboxVersion.Name = "txtboxVersion"
        Me.txtboxVersion.ReadOnly = True
        Me.txtboxVersion.Size = New System.Drawing.Size(421, 20)
        Me.txtboxVersion.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(24, 299)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(494, 2)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Label9"
        '
        'lblNewVersionAvailable
        '
        Me.lblNewVersionAvailable.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.lblNewVersionAvailable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewVersionAvailable.Location = New System.Drawing.Point(23, 261)
        Me.lblNewVersionAvailable.Name = "lblNewVersionAvailable"
        Me.lblNewVersionAvailable.Size = New System.Drawing.Size(494, 31)
        Me.lblNewVersionAvailable.TabIndex = 26
        Me.lblNewVersionAvailable.Text = "New version available"
        Me.lblNewVersionAvailable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblNewVersionAvailable.Visible = False
        '
        'btnTaskManager
        '
        Me.btnTaskManager.BackgroundImage = Global.AutoAppUpdater.My.Resources.Resources.team_coop_structure
        Me.btnTaskManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnTaskManager.Location = New System.Drawing.Point(487, 52)
        Me.btnTaskManager.Name = "btnTaskManager"
        Me.btnTaskManager.Size = New System.Drawing.Size(31, 26)
        Me.btnTaskManager.TabIndex = 28
        Me.btnTaskManager.UseVisualStyleBackColor = True
        '
        'btnUninstall
        '
        Me.btnUninstall.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.btnUninstall.FlatAppearance.BorderSize = 0
        Me.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUninstall.Font = New System.Drawing.Font("Verdana", 7.25!)
        Me.btnUninstall.ForeColor = System.Drawing.Color.White
        Me.btnUninstall.Location = New System.Drawing.Point(425, 147)
        Me.btnUninstall.Name = "btnUninstall"
        Me.btnUninstall.Size = New System.Drawing.Size(84, 23)
        Me.btnUninstall.TabIndex = 29
        Me.btnUninstall.Text = "&UNINSTALL"
        Me.btnUninstall.UseVisualStyleBackColor = False
        Me.btnUninstall.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(539, 367)
        Me.Controls.Add(Me.btnUninstall)
        Me.Controls.Add(Me.lblNewVersionAvailable)
        Me.Controls.Add(Me.btnTaskManager)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblFormHandler2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbAppList)
        Me.Controls.Add(Me.btnUpdate)
        Me.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(555, 589)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents cmbAppList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFormHandler2 As System.Windows.Forms.Label
    Friend WithEvents Bgw1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents LblVersion As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtboxStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtboxVersion As System.Windows.Forms.TextBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtboxApplicationName As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnTaskManager As System.Windows.Forms.Button
    Friend WithEvents txtboxProgramPath As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblNewVersionAvailable As System.Windows.Forms.Label
    Friend WithEvents btnUninstall As System.Windows.Forms.Button

End Class
