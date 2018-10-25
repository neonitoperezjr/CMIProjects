Imports System.Reflection
Imports System.IO
Imports IWshRuntimeLibrary

Module Base

    Public PROJECT_LATEST_VERSIONS_FOLDER As String = "\\sd02-04-1\Data\UpdateApp\"
    Public Const PROJECT_CURRENT_VERSIONS_FOLDER As String = "C:\UpdateApp\"
    Public folder_count As Integer
    Public file_count As Integer

    Public Function project_folder(ByVal source As String, ByVal project As String) As String
        Return source & "" & project
    End Function

    Public Function _filename(ByVal path As String) As String
        Return IO.Path.GetFileName(path)
    End Function

    Public Sub _dir_info(ByVal path As String)
        Dim dir As New System.IO.DirectoryInfo(path)
        folder_count = dir.GetDirectories.GetUpperBound(0) + 1
        file_count = dir.GetFiles.GetUpperBound(0) + 1
    End Sub

    Public Function mk_dir(ByVal dir As String) As String
        If Not Directory.Exists(dir) Then
            Directory.CreateDirectory(dir)
            Return dir
        Else
            Return dir
        End If
    End Function

    Sub _buff(ByVal control As Control)
        Try
            If Not System.Windows.Forms.SystemInformation.TerminalServerSession Then
                Dim control_type As Type = control.GetType()
                Dim pi As PropertyInfo = control_type.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
                pi.SetValue(control, True, Nothing)
            End If
        Catch ex As Exception
            MessageBox.Show("Unable to render double buffered to this control." & vbCrLf & vbCrLf & _
                            "Base.vb - Sub buff(...)" & vbCrLf & vbCrLf & "Technical Information: " & vbCrLf & vbCrLf & ex.Message, " AutoAppUpdater")
        End Try
    End Sub

    Public Sub _focus(control As Control)
        If control.CanFocus Then
            control.Focus()
        Else
            control.Select()
        End If
    End Sub

    Public Function version_compare(ByVal current_version As String, ByVal latest_version As String) As Integer
        Dim v1 As New Version(current_version)
        Dim v2 As New Version(latest_version)
        Return v1.CompareTo(v2)
    End Function

    Sub create_desktop_shortcut(ByVal _path As String, ByVal application_exe As String, ByVal _icon As String, ByVal _shortcut_dir As String, ByVal _description As String)
        Try
            Dim my_shortcut As IWshShortcut
            Dim wsh As New WshShell
            Dim str As String = My.Computer.FileSystem.GetFileInfo(_path & application_exe).Name.Replace(My.Computer.FileSystem.GetFileInfo(_path & application_exe).Extension, Nothing)
            my_shortcut = CType(wsh.CreateShortcut(_shortcut_dir), IWshShortcut)
            With my_shortcut
                .TargetPath = _path & application_exe
                .WindowStyle = 1
                .Description = _description
                .IconLocation = _path & _icon & ", 0"
                .Save()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, " Failed to create UpdateApp desktop shortcut", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub delete_desktop_shortcut(ByVal _shortcut_name As String)
        If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & _shortcut_name) Then
            System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & _shortcut_name)
        End If
    End Sub

End Module
