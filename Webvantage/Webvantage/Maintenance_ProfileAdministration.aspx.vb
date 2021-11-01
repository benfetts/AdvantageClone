Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DevExpress
Imports Telerik.Web.UI

Public Class Maintenance_ProfileAdministration
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property CurrentNumberOfPages As Integer = 0
    Private Property CurrentPageNumber() As Integer
        Get
            Try
                Return CInt(ViewState("CurrentPageNumber"))
            Catch ex As Exception
                ViewState("CurrentPageNumber") = 0
                Return CInt(ViewState("CurrentPageNumber"))
            End Try
        End Get
        Set(ByVal value As Integer)
            ViewState("CurrentPageNumber") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridProfiles_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridProfiles.ItemCommand

        If e.Item IsNot Nothing Then

            Select Case e.CommandName
                Case "Remove"

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim ep As AdvantageFramework.Database.Entities.EmployeePicture

                        ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, e.CommandArgument)

                        If ep IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.EmployeePicture.Delete(DbContext, ep) = False Then

                                Me.ShowMessage("Delete failed")

                            End If

                        End If

                    End Using

            End Select

            Me.RadGridProfiles.Rebind()

        End If
    End Sub
    Private Sub RadGridProfiles_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProfiles.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim rbi As DevExpress.Web.ASPxBinaryImage
                Dim fbs() As Byte
                Dim m As New DocumentRepository("", True)
                Dim RemoveEmployeePictureLinkButton As LinkButton = e.Item.FindControl("LinkButtonRemoveEmployeePicture")
                Try
                    If RemoveEmployeePictureLinkButton IsNot Nothing Then
                        RemoveEmployeePictureLinkButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this image?');")
                    End If
                Catch ex As Exception
                End Try
                Try
                    rbi = CType(dataItem.FindControl("ASPxBinaryImageEmp"), DevExpress.Web.ASPxBinaryImage)
                    If Not rbi Is Nothing Then
                        If IsDBNull(dataItem.DataItem("EMP_IMAGE")) = False Then
                            rbi.Value = CType(dataItem.DataItem("EMP_IMAGE"), Byte())
                        Else
                            If RemoveEmployeePictureLinkButton IsNot Nothing Then
                                RemoveEmployeePictureLinkButton.Visible = False
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
                Try
                    rbi = CType(dataItem.FindControl("ASPxBinaryImageWP"), DevExpress.Web.ASPxBinaryImage)
                    If Not rbi Is Nothing Then
                        If IsDBNull(dataItem.DataItem("EMP_WALLPAPER")) = False Then
                            rbi.Value = CType(dataItem.DataItem("EMP_WALLPAPER"), Byte())
                        Else
                            'rbi.DataValue = fbs
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    Dim EmployeePictureUpload As Telerik.Web.UI.RadAsyncUpload
                    EmployeePictureUpload = CType(dataItem.FindControl("RadUploadEmployee"), Telerik.Web.UI.RadAsyncUpload)
                    m.SetRadAsyncUpload(EmployeePictureUpload, False)

                    EmployeePictureUpload.MaxFileSize = UserThemeSettings.EmployeeLimit
                Catch ex As Exception
                End Try
                Try
                    Dim EmployeeWallpaperUpload As Telerik.Web.UI.RadAsyncUpload
                    EmployeeWallpaperUpload = CType(dataItem.FindControl("RadUploadWP"), Telerik.Web.UI.RadAsyncUpload)
                    m.SetRadAsyncUpload(EmployeeWallpaperUpload, False)
                    EmployeeWallpaperUpload.MaxFileSize = UserThemeSettings.WallpaperLimit
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridProfiles_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProfiles.NeedDataSource
        Try

            Dim cEmp As New cEmployee(Session("ConnString"))
            Me.RadGridProfiles.DataSource = cEmp.GetEmployeeProfileDataTable("")

        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadGridProfiles_PreRender(sender As Object, e As EventArgs) Handles RadGridProfiles.PreRender
        Try

            Me.CurrentNumberOfPages = Me.RadGridProfiles.PageCount
            If Me.CurrentPageNumber <= Me.CurrentNumberOfPages Then

                Me.RadGridProfiles.CurrentPageIndex = Me.CurrentPageNumber

            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridProfiles_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridProfiles.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridProfiles.Rebind()

    End Sub


    Private Sub RadToolbarSchedule_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSchedule.ButtonClick
        Try
            Dim rbi As DevExpress.Web.ASPxBinaryImage
            Dim ru As Telerik.Web.UI.RadAsyncUpload
            Dim ruwp As Telerik.Web.UI.RadAsyncUpload
            Dim nn As System.Web.UI.WebControls.TextBox
            Dim cEmp As New cEmployee(Session("ConnString"))
            Dim fbs() As Byte
            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Select Case e.Item.Value
                Case "FixThumbs"

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.DocumentManager.FixEmployeeThumbnails(DbContext)

                    End Using

                    RadGridProfiles.Rebind()

                Case "Save"
                    Dim RowCount As Integer = Me.RadGridProfiles.MasterTableView.Items.Count
                    If RowCount > 0 Then
                        For i As Integer = 0 To RowCount - 1
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProfiles.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim CurrentPictureID As Integer = 0
                            Try
                                CurrentPictureID = CType(CurrentGridRow.GetDataKeyValue("EMP_PICTURE_ID"), Integer)
                            Catch ex As Exception
                                CurrentPictureID = 0
                            End Try
                            rbi = CType(CurrentGridRow.FindControl("ASPxBinaryImageEmp"), DevExpress.Web.ASPxBinaryImage)
                            ruwp = CType(CurrentGridRow.FindControl("RadUploadWP"), Telerik.Web.UI.RadAsyncUpload)
                            ru = CType(CurrentGridRow.FindControl("RadUploadEmployee"), Telerik.Web.UI.RadAsyncUpload)
                            nn = CType(CurrentGridRow.FindControl("TextBoxNickname"), TextBox)
                            If CurrentPictureID > 0 Then
                                Dim dr As SqlClient.SqlDataReader
                                dr = cEmp.GetEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"))
                                If dr.HasRows Then
                                    dr.Read()
                                    If IsDBNull(dr("EMP_IMAGE")) = False Then
                                        Dim FileBytes() As Byte = CType(dr("EMP_IMAGE"), Byte())
                                        rbi.Value = FileBytes
                                    End If
                                    If IsDBNull(dr("EMP_WALLPAPER")) = False Then
                                        fbs = CType(dr("EMP_WALLPAPER"), Byte())
                                    End If
                                    dr.Close()
                                End If
                                If ruwp.UploadedFiles.Count > 0 Then
                                    For j As Integer = 0 To ruwp.UploadedFiles.Count - 1

                                        If DocumentRepository.RadAsyncUploadFileTypeIsValid(ruwp.UploadedFiles(j)) = False Then

                                            Me.ShowMessage("Invalid file type.")
                                            Exit Sub

                                        End If
                                        Dim realFilename As String = ruwp.UploadedFiles(j).GetName
                                        Dim MIMEType As String = ruwp.UploadedFiles(j).ContentType
                                        Dim FileLength As Integer = ruwp.UploadedFiles(j).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes2(FileLength - 1) As Byte
                                            If FileBytes2.Length > 512000 Then
                                                Me.ShowMessage("Webvantage wallpaper file exceeded the file size limit.")
                                            Else
                                                If ruwp.UploadedFiles(j).InputStream.Read(FileBytes2, 0, FileLength) Then
                                                    fbs = FileBytes2
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                                If ru.UploadedFiles.Count > 0 Then
                                    For w As Integer = 0 To ru.UploadedFiles.Count - 1

                                        If DocumentRepository.RadAsyncUploadFileTypeIsValid(ru.UploadedFiles(w)) = False Then

                                            Me.ShowMessage("Invalid file type.")
                                            Exit Sub

                                        End If
                                        Dim realFilename As String = ru.UploadedFiles(w).GetName
                                        Dim MIMEType As String = ru.UploadedFiles(w).ContentType
                                        Dim FileLength As Integer = ru.UploadedFiles(w).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes(FileLength - 1) As Byte
                                            'If FileBytes.Length > 512000 Then
                                            '    Me.ShowMessage("File exceeded the file size limit.")
                                            'Else
                                            If ru.UploadedFiles(w).InputStream.Read(FileBytes, 0, FileLength) Then
                                                If Not fbs Is Nothing AndAlso fbs.Length > 0 Then
                                                    cEmp.UpdateEmployeeProfile(CurrentPictureID, FileBytes, nn.Text, fbs)
                                                Else
                                                    cEmp.UpdateEmployeeProfile(CurrentPictureID, FileBytes, nn.Text, fbs)
                                                End If
                                            End If
                                            'End If
                                        End If
                                    Next
                                Else
                                    cEmp.UpdateEmployeeProfile(CurrentPictureID, rbi.Value, nn.Text, fbs)
                                End If
                            Else
                                If ruwp.UploadedFiles.Count > 0 Then
                                    For j As Integer = 0 To ruwp.UploadedFiles.Count - 1
                                        Dim realFilename As String = ruwp.UploadedFiles(j).GetName
                                        Dim MIMEType As String = ruwp.UploadedFiles(j).ContentType
                                        Dim FileLength As Integer = ruwp.UploadedFiles(j).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes2(FileLength - 1) As Byte
                                            If FileBytes2.Length > 512000 Then
                                                Me.ShowMessage("Webvantage wallpaper file exceeded the file size limit.")
                                            Else
                                                If ruwp.UploadedFiles(j).InputStream.Read(FileBytes2, 0, FileLength) Then
                                                    fbs = FileBytes2
                                                End If
                                            End If
                                        End If
                                    Next
                                End If
                                If ru.UploadedFiles.Count > 0 Then
                                    For k As Integer = 0 To ru.UploadedFiles.Count - 1
                                        Dim realFilename As String = ru.UploadedFiles(k).GetName
                                        Dim MIMEType As String = ru.UploadedFiles(k).ContentType
                                        Dim FileLength As Integer = ru.UploadedFiles(k).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes(FileLength - 1) As Byte
                                            If FileBytes.Length > 512000 Then
                                                Me.ShowMessage("File exceeded the file size limit.")
                                            Else
                                                If ru.UploadedFiles(k).InputStream.Read(FileBytes, 0, FileLength) Then
                                                    cEmp.SaveEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"), FileBytes, nn.Text, fbs)
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    Dim dr As SqlClient.SqlDataReader
                                    dr = cEmp.GetEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"))
                                    If dr.HasRows Then
                                        dr.Read()
                                        If IsDBNull(dr("EMP_WALLPAPER")) = False Then
                                            fbs = CType(dr("EMP_WALLPAPER"), Byte())
                                        End If
                                        dr.Close()
                                    End If
                                    cEmp.SaveEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"), rbi.Value, nn.Text, fbs)
                                End If
                            End If
                            fbs = Nothing
                        Next
                        Me.RadGridProfiles.Rebind()
                    End If
                Case "Clear"

                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim count As Integer = 0

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridProfiles.MasterTableView.Items

                        chk = CType(gridDataItem("ColClientSelect").Controls(0), CheckBox)

                        If chk.Checked = True Then

                            Dim Filebytes() As Byte
                            cEmp.UpdateEmployeeProfile(gridDataItem.GetDataKeyValue("EMP_PICTURE_ID"), Filebytes, "", Filebytes)
                            count += 1

                        End If

                    Next

                    If count = 0 Then

                        Me.ShowMessage("No rows were selected.")

                    End If

                    Me.RadGridProfiles.Rebind()

                Case "Bookmark"
                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs = qs.FromCurrent()
                    qs.Page = "Maintenance_ProfileAdministration.aspx"
                    qs.Add("bm", "1")

                    With b
                        .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Maintenance_ProfileAdministration
                        .UserCode = Session("UserCode")
                        .Name = "Profile Administration"
                        .Description = "Profile Administration"
                        .PageURL = qs.ToString(True)
                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then
                        Me.ShowMessage(s)
                    End If

                    Me.RadGridProfiles.Rebind()

            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region " Page "

    Private Sub Maintenance_ProfileAdministration_Init(sender As Object, e As EventArgs) Handles Me.Init

        CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_ProfileAdministration, True)

    End Sub
    Protected Sub Maintenance_ProfileAdministration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("bm") Is Nothing Then
            Me.PageTitle = "Profile Administration"
        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try

                Me.RadGridProfiles.CurrentPageIndex = Me.CurrentPageNumber

            Catch ex As Exception

                Me.RadGridProfiles.CurrentPageIndex = 0

            End Try
        End If
    End Sub



#End Region

#End Region

End Class
