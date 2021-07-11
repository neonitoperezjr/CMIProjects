Imports System.IO

Public Class Main

    ''' <summary>
    '''  For the future development of this program.
    '''  Developer can add a progress bar during installation of application.
    '''  Developer can add more applications they have developed in the _check_update(...) , _update(...) and install(...) subs.
    ''' </summary>
    ''' <remarks></remarks>

    Public current_project_dir As String
    Public latest_project_dir As String
    Public _version As String = "v1.0.20"
    Public latestApp_version As String
    Public currentApp_version As String

    Dim application_name As String()
    Dim new_file_name As String()
    Dim exe_file As New ArrayList
    Dim flag As Boolean = False
    Dim applicationName As String
    Dim updateFlag As Boolean = False

    Private Sub ua_setup()
        '#update app setup
        Dim resp As DialogResult
        If Not System.IO.File.Exists(PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP\AutoAppUpdater.exe") Then
            resp = MessageBox.Show("Do you want to install UpdateApp on your Computer?", " UpdateApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                mk_dir(PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP")
                Try
                    current_project_dir = PROJECT_CURRENT_VERSIONS_FOLDER & "\SETUP"
                    mk_dir(current_project_dir)
                    latest_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, "SETUP")
                    flag = True
                Catch ex As Exception
                    MessageBox.Show("Can't update right now unavailable to connect lastest project repository", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    flag = False
                End Try
                If flag = True Then
                    Try
                        For Each _file As String In My.Computer.FileSystem.GetFiles(latest_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                            new_file_name = _file.Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            FileCopy(_file, current_project_dir & "\" & new_file_name(new_file_name.Length - 1))
                        Next
                    Catch ex As Exception
                        MessageBox.Show(ex.Message & vbCrLf & vbCrLf & "The software/application your are trying to update is still running." & vbCrLf & vbCrLf & "Please close the application and click the update button again.", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
                create_desktop_shortcut(_path:=PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP\", application_exe:="AutoAppUpdater.exe", _icon:="updateapp_ico.ico", _shortcut_dir:=My.Computer.FileSystem.SpecialDirectories.Desktop & "\UpdateApp.lnk", _description:="UpdateApp " & _version)
                MessageBox.Show("UpdateApp successfully installed on your Computer", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ua_update()
        If System.IO.File.Exists(PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP\AutoAppUpdater.exe") Then
            currentApp_version = My.Computer.FileSystem.ReadAllText(PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP\version.txt").Replace("v", "")
            latestApp_version = My.Computer.FileSystem.ReadAllText(Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, "SETUP") & "\version.txt").Replace("v", "")
            If version_compare(currentApp_version, latestApp_version) < 0 Then
                System.Threading.Thread.Sleep(3000)
                For Each _file As String In My.Computer.FileSystem.GetFiles(PROJECT_CURRENT_VERSIONS_FOLDER & "SETUP\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                    My.Computer.FileSystem.DeleteFile(_file)
                Next
                For Each _file As String In My.Computer.FileSystem.GetFiles(PROJECT_LATEST_VERSIONS_FOLDER & "SETUP\", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                    new_file_name = _file.Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    FileCopy(_file, PROJECT_CURRENT_VERSIONS_FOLDER & "\SETUP\" & new_file_name(new_file_name.Length - 1))
                Next
            End If
        End If
    End Sub

    Sub initialize()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        ua_setup()
        cls()
        load_data()
    End Sub

    Sub get_application_list()
        Dim _folders As ArrayList = New ArrayList()
        Dim _arrFolder As String()
        cmbAppList.Text = ""
        cmbAppList.Items.Clear()
        txtboxApplicationName.Clear()
        txtboxVersion.Clear()
        txtboxStatus.Clear()
        txtboxProgramPath.Clear()
        btnUpdate.BackColor = Color.Gray
        For Each _dir As String In Directory.GetDirectories(PROJECT_LATEST_VERSIONS_FOLDER)
            _arrFolder = _dir.Split("\".ToCharArray())
            _folders.Add(_arrFolder(_arrFolder.Length() - 1))
        Next
        For i As Integer = 0 To _folders.Count - 1
            If _folders(i) <> "SETUP" Then
                cmbAppList.Items.Add(_folders(i))
            End If
        Next
    End Sub

    Sub load_data()
        txtboxApplicationName.Clear()
        txtboxVersion.Clear()
        txtboxStatus.Clear()
        txtboxProgramPath.Clear()
        btnUpdate.BackColor = Color.Gray
        lblNewVersionAvailable.Visible = False
        get_application_list()
    End Sub

    Sub cls()
        cmbAppList.Text = ""
        cmbAppList.SelectedIndex = -1
        txtboxApplicationName.Clear()
        txtboxVersion.Clear()
        txtboxStatus.Clear()
        txtboxProgramPath.Clear()
        btnUpdate.BackColor = Color.Gray
        lblNewVersionAvailable.Visible = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        lblFormHandler2.Text = "    UpdateApp " & _version
        initialize()
    End Sub

    Private Sub apx1(ByVal cAppList As ComboBox, ByVal bUpdate As Button, ByVal this_button_text As String, ByVal this_application_name As String, ByVal tApplicationName As TextBox, ByVal tVersion As TextBox, ByVal tStatus As TextBox, ByVal lNewVersionAvailable As Label)
        bUpdate.Text = "&UPDATE"
        exe_file.Clear()
        tApplicationName.Clear()
        tVersion.Clear()
        tStatus.Clear()
        lNewVersionAvailable.Visible = False
        Try
            current_project_dir = Base.project_folder(PROJECT_CURRENT_VERSIONS_FOLDER, cmbAppList.Text)
            For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                exe_file.Add(_file)
            Next
            application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            btnUninstall.Visible = True
            flag = True
        Catch ex As Exception
            flag = False
            btnUninstall.Visible = False
            'MessageBox.Show("Application was not found in your computer", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            bUpdate.Text = this_button_text
            bUpdate.Enabled = True
            bUpdate.BackColor = Color.FromArgb(21, 101, 192)
        End Try
        If flag = True Then
            For Each process As Process In process.GetProcesses
                If process.MainWindowTitle <> "" Then
                    If process.ProcessName.Contains(application_name(application_name.Length() - 1)) Then
                        flag = False
                        MessageBox.Show("Please close the running application.", " Application is currently running", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        AppActivate(process.MainWindowTitle)
                        cAppList.SelectedIndex = -1
                    Else
                        flag = True
                    End If
                End If
            Next
        End If
        If flag = True Then
            MsgBox("flag is true")
            tApplicationName.Text = application_name(application_name.Length() - 1)
            currentApp_version = My.Computer.FileSystem.ReadAllText(current_project_dir & "\version.txt").Replace("v", "")
            tVersion.Text = "v" & currentApp_version
            tStatus.Text = "Stable Release"
            'txtboxProgramPath.Text = current_project_dir
            latestApp_version = My.Computer.FileSystem.ReadAllText(Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cAppList.Text) & "\version.txt").Replace("v", "")
            If version_compare(currentApp_version, latestApp_version) > 0 Then
                lNewVersionAvailable.Visible = False
            ElseIf version_compare(currentApp_version, latestApp_version) < 0 Then
                MsgBox(lblNewVersionAvailable.Visible)
                lNewVersionAvailable.Text = "New version available"
                lNewVersionAvailable.Visible = True
                _application = this_application_name
                bUpdate.Enabled = True
                bUpdate.BackColor = Color.FromArgb(21, 101, 192)
            Else
                lNewVersionAvailable.Text = "Software installed is updated"
                lNewVersionAvailable.Visible = True
                bUpdate.Enabled = False
                bUpdate.BackColor = Color.Gray
            End If
        End If
    End Sub

    '# check latest update of the application installed in the user's machine/computer.
    Private Sub check_update(ByVal csf As String)
        Select Case csf
            Case "HCT ORDER RECEIVING"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT ORDER RECEIVING", "HCT ORDER RECEIVING", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "HCT RECEIVING INSPECTION"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT RECEIVING INSPECTION", "HCT RECEIVING INSPECTION", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "HCT GANTT CHART"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT GANTT CHART", "HCT GANTT CHART", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "HCT WIP"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT WIP", "HCT WIP", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "HCT WIP SCANNING"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT WIP SCANNING", "HCT WIP SCANNING", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "HCT WORKDAY"
                apx1(cmbAppList, btnUpdate, "INSTALL HCT WORKDAY", "HCT WORKDAY", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case "CCP MATERIAL INVENTORY"
                apx1(cmbAppList, btnUpdate, "INSTALL CCP MATERIAL INVENTORY", "CCP MATERIAL INVENTORY", txtboxApplicationName, txtboxVersion, txtboxStatus, lblNewVersionAvailable)
            Case Else
                MessageBox.Show("Failed to get update to an application", " Application not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    Private Sub apx2(ByVal cAppList As ComboBox)
        Try
            current_project_dir = Base.project_folder(PROJECT_CURRENT_VERSIONS_FOLDER, cAppList.Text)
            mk_dir(current_project_dir)
            latest_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cAppList.Text)
            flag = True
        Catch ex As Exception
            MessageBox.Show("Can't update right now unavailable to connect lastest project repository", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flag = False
        End Try
        If flag = True Then
            Try
                For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                    My.Computer.FileSystem.DeleteFile(_file)
                Next
                For Each _file As String In My.Computer.FileSystem.GetFiles(latest_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                    new_file_name = _file.Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    FileCopy(_file, current_project_dir & "\" & new_file_name(new_file_name.Length - 1))
                Next
                check_update(_application)
            Catch ex As Exception
                MessageBox.Show(ex.Message & vbCrLf & vbCrLf & "The software/application your are trying to update is still running." & vbCrLf & vbCrLf & "Please close the application and click the update button again.", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '# do a quick update of application in the user's machine/computer.
    Private Sub _update(ByVal csf As String)
        Select Case csf
            Case "HCT ORDER RECEIVING"
                apx2(cmbAppList)
            Case "HCT RECEIVING INSPECTION"
                apx2(cmbAppList)
            Case "HCT GANTT CHART"
                apx2(cmbAppList)
            Case "HCT WIP"
                apx2(cmbAppList)
            Case "HCT WIP SCANNING"
                apx2(cmbAppList)
            Case "HCT WORKDAY"
                apx2(cmbAppList)
            Case "CCP MATERIAL INVENTORY"
                apx2(cmbAppList)
        End Select
    End Sub

    Private Sub apx3(ByVal cAppList As ComboBox, ByVal application_exe As String, ByVal icon_name As String, ByVal shortcut_name As String, ByVal description As String)
        Dim resp As DialogResult
        If Not System.IO.File.Exists(PROJECT_CURRENT_VERSIONS_FOLDER & cAppList.Text & "\" & application_exe) Then
            resp = MessageBox.Show("Do you want to install " & cAppList.Text & " on your Computer?", " UpdateApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                mk_dir(PROJECT_CURRENT_VERSIONS_FOLDER & cAppList.Text)
                Try
                    current_project_dir = PROJECT_CURRENT_VERSIONS_FOLDER & cAppList.Text
                    mk_dir(current_project_dir)
                    latest_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cAppList.Text)
                    flag = True
                Catch ex As Exception
                    MessageBox.Show(ex.Message, " UpdateApp - apx3", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    flag = False
                End Try
                If flag = True Then
                    Try
                        For Each _file As String In My.Computer.FileSystem.GetFiles(latest_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                            new_file_name = _file.Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            FileCopy(_file, current_project_dir & "\" & new_file_name(new_file_name.Length - 1))
                        Next
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, " UpdateApp - apx3", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
                create_desktop_shortcut(_path:=PROJECT_CURRENT_VERSIONS_FOLDER & cAppList.Text & "\", application_exe:=application_exe, _icon:=icon_name, _shortcut_dir:=My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & shortcut_name, _description:=description & " " & _version)
                MessageBox.Show(cAppList.Text & " was successfully installed on your Computer", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    '# do a quick installation of application in the user's machine/computer.
    Private Sub install(ByVal csf As String)
        Select Case csf
            Case "HCT ORDER RECEIVING"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "order_receiving_ico.ico", "HCT ORDER RECEIVING.lnk", "HCT ORDER RECEIVING")
            Case "HCT RECEIVING INSPECTION"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "material_receiving.ico", "HCT RECEIVING INSPECTION.lnk", "HCT RECEIVING INSPECTION")
            Case "HCT GANTT CHART"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "gantt_chart.ico", "HCT GANTT CHART.lnk", "HCT GANTT CHART")
            Case "HCT WIP"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "work_in_progress.ico", "HCT WIP.lnk", "HCT WIP")
            Case "HCT WIP SCANNING"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "scanning.ico", "HCT WIP SCANNING.lnk", "HCT WIP SCANNING")
            Case "HCT WORKDAY"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "hct_workday.ico", "HCT WORKDAY.lnk", "HCT WORKDAY")
            Case "CCP MATERIAL INVENTORY"
                apx3(cmbAppList, application_name(application_name.Length() - 1), "matreceive.ico", "CCP MATERIAL INVENTORY.lnk", "CCP MATERIAL INVENTORY")
        End Select
    End Sub

    Private Sub apx4(ByVal application_name As String)
        Dim resp As DialogResult
        resp = MessageBox.Show("Do you want to uninstall " & application_name & "?", " UpdateApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then
            current_project_dir = Base.project_folder(PROJECT_CURRENT_VERSIONS_FOLDER, application_name)
            For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories)
                My.Computer.FileSystem.DeleteFile(_file)
            Next
            delete_desktop_shortcut(application_name & ".lnk")
            MessageBox.Show("Uninstallation done", " UpdateApp", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub uninstall(ByVal csf As String)
        Select Case csf
           
        End Select
    End Sub

    Private Sub cmbAppList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbAppList.SelectedIndexChanged
        Select Case cmbAppList.Text
            Case "HCT ORDER RECEIVING"
                _application = "HCT ORDER RECEIVING"
                check_update(_application)
            Case "HCT RECEIVING INSPECTION"
                _application = "HCT RECEIVING INSPECTION"
                check_update(_application)
            Case "HCT GANTT CHART"
                _application = "HCT GANTT CHART"
                check_update(_application)
            Case "HCT WIP"
                _application = "HCT WIP"
                check_update(_application)
            Case "HCT WIP SCANNING"
                _application = "HCT WIP SCANNING"
                check_update(_application)
            Case "HCT WORKDAY"
                _application = "HCT WORKDAY"
                check_update(_application)
            Case "CCP MATERIAL INVENTORY"
                _application = "CCP MATERIAL INVENTORY"
                check_update(_application)
            Case Else
                MessageBox.Show("Please contact your software developer team to update UpdateApp")
        End Select
        Base._focus(Label1)
    End Sub

    Private Sub btnTaskManager_Click(sender As System.Object, e As System.EventArgs) Handles btnTaskManager.Click
        If Not Application.OpenForms().OfType(Of RunningAppsViewer).Any Then
            RunningAppsViewer.initialize()
            RunningAppsViewer.Show()
            RunningAppsViewer.Activate()
            RunningAppsViewer.BringToFront()
        Else
            RunningAppsViewer.Activate()
            RunningAppsViewer.BringToFront()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If btnUpdate.Text = "&UPDATE" Then
            Select Case cmbAppList.Text
                Case "HCT ORDER RECEIVING"
                    _application = "HCT ORDER RECEIVING"
                    _update(_application)
                Case "HCT RECEIVING INSPECTION"
                    _application = "HCT RECEIVING INSPECTION"
                    _update(_application)
                Case "HCT GANTT CHART"
                    _application = "HCT GANTT CHART"
                    _update(_application)
                Case "HCT WIP"
                    _application = "HCT WIP"
                    _update(_application)
                Case "HCT WIP SCANNING"
                    _application = "HCT WIP SCANNING"
                    _update(_application)
                Case "HCT WORKDAY"
                    _application = "HCT WORKDAY"
                    _update(_application)
                Case "CCP MATERIAL INVENTORY"
                    _application = "CCP MATERIAL INVENTORY"
                    _update(_application)
                Case Else
                    MessageBox.Show("Please contact your software developer team to update UpdateApp")
            End Select
        ElseIf btnUpdate.Text.Contains("INSTALL") Then
            Select Case cmbAppList.Text
                Case "HCT ORDER RECEIVING"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT ORDER RECEIVING"
                        install(_application)
                        check_update(_application)
                    End If
                Case "HCT RECEIVING INSPECTION"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT RECEIVING INSPECTION"
                        install(_application)
                        check_update(_application)
                    End If
                Case "HCT GANTT CHART"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT GANTT CHART"
                        install(_application)
                        check_update(_application)
                    End If
                Case "HCT WIP"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT WIP"
                        install(_application)
                        check_update(_application)
                    End If
                Case "HCT WIP SCANNING"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT WIP SCANNING"
                        install(_application)
                        check_update(_application)
                    End If
                Case "HCT WORKDAY"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "HCT WORKDAY"
                        install(_application)
                        check_update(_application)
                    End If
                Case "CCP MATERIAL INVENTORY"
                    Try
                        current_project_dir = Base.project_folder(PROJECT_LATEST_VERSIONS_FOLDER, cmbAppList.Text)
                        For Each _file As String In My.Computer.FileSystem.GetFiles(current_project_dir, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.exe")
                            exe_file.Add(_file)
                        Next
                        application_name = exe_file(0).Split("\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        flag = True
                    Catch ex As Exception
                        MessageBox.Show("Application was not found in the repository and return message." & vbCrLf & vbCrLf & ex.Message, " Can't install at the moment try contact SD for this.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        flag = False
                    End Try
                    If flag = True Then
                        _application = "CCP MATERIAL INVENTORY"
                        install(_application)
                        check_update(_application)
                    End If
                Case Else
                    MessageBox.Show("Please contact your software developer team to update UpdateApp")
            End Select
        End If
    End Sub

    Private Sub btnUninstall_Click(sender As System.Object, e As System.EventArgs) Handles btnUninstall.Click
        Select Case cmbAppList.Text
            Case "HCT ORDER RECEIVING"
                _application = "HCT ORDER RECEIVING"
                apx4(_application)
                check_update(_application)
            Case "HCT RECEIVING INSPECTION"
                _application = "HCT RECEIVING INSPECTION"
                apx4(_application)
                check_update(_application)
            Case "HCT GANTT CHART"
                _application = "HCT GANTT CHART"
                apx4(_application)
                check_update(_application)
            Case "HCT WIP"
                _application = "HCT WIP"
                apx4(_application)
                check_update(_application)
            Case "HCT WIP SCANNING"
                _application = "HCT WIP SCANNING"
                apx4(_application)
                check_update(_application)
            Case "HCT WORKDAY"
                _application = "HCT WORKDAY"
                apx4(_application)
                check_update(_application)
            Case "CCP MATERIAL INVENTORY"
                _application = "CCP MATERIAL INVENTORY"
                apx4(_application)
                check_update(_application)
            Case Else
                MessageBox.Show("Please contact your software developer team to update UpdateApp")
        End Select
    End Sub
End Class
