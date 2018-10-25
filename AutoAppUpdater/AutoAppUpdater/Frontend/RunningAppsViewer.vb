Imports System.Reflection

Public Class RunningAppsViewer

    Dim image_list As New ImageList
    Dim running_apps_counter As Integer

    Sub initialize()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Sub get_running_apps()
        ' display running apps in a listview
        ListView1.Items.Clear()
        ListView1.Columns.Add("Programs", 130, HorizontalAlignment.Left)
        ListView1.Columns.Add("Full Path", 320, HorizontalAlignment.Left)
        ListView1.SmallImageList = image_list
        ListView1.FullRowSelect = True
        ListView1.View = View.Details
        ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
        For Each process As Process In process.GetProcesses
            If process.MainWindowTitle <> "" Then
                image_list.Images.Add(Icon.ExtractAssociatedIcon(process.MainModule.FileName))
                Dim lvi As New ListViewItem(process.ProcessName, image_list.Images.Count - 1)
                lvi.SubItems.Add(process.MainModule.FileName)
                ListView1.Items.Add(lvi)
            End If
        Next
        _buff(ListView1) ' Remove flickering of listview during scrolling of big amount of records
    End Sub

    Private Sub RunningAppsViewer_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        get_running_apps()
    End Sub

End Class