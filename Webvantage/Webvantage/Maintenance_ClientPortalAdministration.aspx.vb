Imports System.Data.Sql
Imports System.Data.SqlClient
Imports DevExpress
Public Class Maintenance_ClientPortalAdministration
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub RadGridProfiles_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProfiles.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim rbi As DevExpress.Web.ASPxBinaryImage
                Dim ri As DevExpress.Web.ASPxImage
                Dim fbs() As Byte
                Try
                    rbi = CType(dataItem.FindControl("ASPxBinaryImageCPLogo"), DevExpress.Web.ASPxBinaryImage)
                    If Not rbi Is Nothing Then
                        If IsDBNull(dataItem.DataItem("BINARY_IMAGE_LOGO")) = False Then
                            rbi.Value = CType(dataItem.DataItem("BINARY_IMAGE_LOGO"), Byte())
                        Else
                            rbi.Visible = False
                        End If
                    End If
                Catch ex As Exception
                End Try
                Try
                    rbi = CType(dataItem.FindControl("ASPxBinaryImageCPWallpaper"), DevExpress.Web.ASPxBinaryImage)
                    If Not rbi Is Nothing Then
                        If IsDBNull(dataItem.DataItem("BINARY_IMAGE_WP")) = False Then
                            rbi.Value = CType(dataItem.DataItem("BINARY_IMAGE_WP"), Byte())
                        Else
                            'rbi.DataValue = fbs
                        End If
                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(dataItem.FindControl("DropDownListWVWallpaper"), Telerik.Web.UI.RadComboBox)
                    If IsDBNull(dataItem.DataItem("BINARY_IMAGE_WV_WP")) = False Then
                        ddl.SelectedValue = dataItem.DataItem("BINARY_IMAGE_WV_WP")
                    End If
                    ddl = CType(dataItem.FindControl("DropDownListTheme"), Telerik.Web.UI.RadComboBox)
                    If IsDBNull(dataItem.DataItem("BINARY_IMAGE_WV_THEME")) = False Then
                        ddl.SelectedValue = dataItem.DataItem("BINARY_IMAGE_WV_THEME")
                    End If
                    Dim rc As Telerik.Web.UI.RadColorPicker = CType(dataItem.FindControl("RadColorPickerBackground"), Telerik.Web.UI.RadColorPicker)
                    If IsDBNull(dataItem.DataItem("BINARY_IMAGE_WV_SC")) = False Then
                        rc.SelectedColor = Drawing.ColorTranslator.FromHtml(dataItem.DataItem("BINARY_IMAGE_WV_SC").ToString)
                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim rbwp As RadioButton = CType(dataItem.FindControl("RadioButtonWallpaper"), RadioButton)
                    Dim rbsc As RadioButton = CType(dataItem.FindControl("RadioButtonSolidColor"), RadioButton)
                    If IsDBNull(dataItem.DataItem("BINARY_BACKGROUND")) = False Then
                        If dataItem.DataItem("BINARY_BACKGROUND").ToString = "Wallpaper" Then
                            rbwp.Checked = True
                        ElseIf dataItem.DataItem("BINARY_BACKGROUND").ToString = "Solid" Then
                            rbsc.Checked = True
                        Else
                            rbwp.Checked = True
                        End If
                    Else
                        rbwp.Checked = True
                    End If
                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridProfiles_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProfiles.NeedDataSource
        Try
            Dim dr As SqlClient.SqlDataReader
            Dim oSecurity As New cSecurity(Session("ConnString"))
            dr = oSecurity.GetCPProfiles("")
            If dr.HasRows Then
                Me.RadGridProfiles.DataSource = dr
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolbarSchedule_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSchedule.ButtonClick
        Try
            Dim rbi As DevExpress.Web.ASPxBinaryImage
            Dim ru As Telerik.Web.UI.RadUpload
            Dim ruwp As Telerik.Web.UI.RadUpload
            Dim ddlWP As Telerik.Web.UI.RadComboBox
            Dim ddlTheme As Telerik.Web.UI.RadComboBox
            Dim rc As Telerik.Web.UI.RadColorPicker
            Dim rbwp As RadioButton
            Dim rbsc As RadioButton
            Dim oSecurity As New cSecurity(Session("ConnString"))
            Dim fbs() As Byte
            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            Dim wp As String
            Dim sc As String
            Dim theme As String
            Dim bg As String
            Dim bgrb As String = "Wallpaper"
            Select Case e.Item.Value
                Case "Save"
                    Dim RowCount As Integer = Me.RadGridProfiles.MasterTableView.Items.Count
                    If RowCount > 0 Then
                        For i As Integer = 0 To RowCount - 1
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProfiles.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim CurrentPictureID As Integer = 0
                            Try
                                CurrentPictureID = CType(CurrentGridRow.GetDataKeyValue("BINARY_IMAGE_ID"), Integer)
                            Catch ex As Exception
                                CurrentPictureID = 0
                            End Try
                            Dim CurrentClientCode As String = ""
                            Try
                                CurrentClientCode = CType(CurrentGridRow.GetDataKeyValue("CL_CODE"), String)
                            Catch ex As Exception
                                CurrentClientCode = ""
                            End Try
                            rbi = CType(CurrentGridRow.FindControl("ASPxBinaryImageCPLogo"), DevExpress.Web.ASPxBinaryImage)
                            ruwp = CType(CurrentGridRow.FindControl("RadUploadCPWallpaper"), Telerik.Web.UI.RadUpload)
                            ru = CType(CurrentGridRow.FindControl("RadUploadCPLogo"), Telerik.Web.UI.RadUpload)
                            ddlWP = CType(CurrentGridRow.FindControl("DropDownListWVWallpaper"), Telerik.Web.UI.RadComboBox)
                            ddlTheme = CType(CurrentGridRow.FindControl("DropDownListTheme"), Telerik.Web.UI.RadComboBox)
                            rbwp = CType(CurrentGridRow.FindControl("RadioButtonWallpaper"), RadioButton)
                            rbsc = CType(CurrentGridRow.FindControl("RadioButtonSolidColor"), RadioButton)
                            rc = CType(CurrentGridRow.FindControl("RadColorPickerBackground"), Telerik.Web.UI.RadColorPicker)
                            If rbwp.Checked Then
                                bgrb = "Wallpaper"
                            ElseIf rbsc.Checked Then
                                bgrb = "Solid"
                            End If
                            If CurrentPictureID > 0 Then
                                Dim dr As SqlClient.SqlDataReader
                                dr = oSecurity.GetBinaryImageCP(CurrentClientCode)
                                If dr.HasRows Then
                                    dr.Read()
                                    If IsDBNull(dr("BINARY_IMAGE_LOGO")) = False Then
                                        Dim FileBytes() As Byte = CType(dr("BINARY_IMAGE_LOGO"), Byte())
                                        rbi.Value = FileBytes
                                    End If
                                    If IsDBNull(dr("BINARY_IMAGE_WP")) = False Then
                                        fbs = CType(dr("BINARY_IMAGE_WP"), Byte())
                                    End If
                                    If IsDBNull(dr("BINARY_IMAGE_WV_WP")) = False Then
                                        wp = dr("BINARY_IMAGE_WV_WP")
                                    End If
                                    If IsDBNull(dr("BINARY_IMAGE_WV_THEME")) = False Then
                                        theme = dr("BINARY_IMAGE_WV_THEME")
                                    End If
                                    If IsDBNull(dr("BINARY_IMAGE_WV_THEME")) = False Then
                                        bg = dr("BINARY_BACKGROUND")
                                    End If
                                    If IsDBNull(dr("BINARY_IMAGE_WV_SC")) = False Then
                                        sc = dr("BINARY_IMAGE_WV_SC")
                                    End If
                                    dr.Close()
                                End If
                                If ruwp.UploadedFiles.Count > 0 Then
                                    For j As Integer = 0 To ruwp.UploadedFiles.Count - 1
                                        Dim realFilename As String = ruwp.UploadedFiles(j).GetName
                                        Dim MIMEType As String = ruwp.UploadedFiles(j).ContentType
                                        Dim FileLength As Integer = ruwp.UploadedFiles(j).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes2(FileLength - 1) As Byte
                                            If FileBytes2.Length > 500000 Then
                                                ShowError("Client Portal wallpaper file exceeded the file size limit.")
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
                                        Dim realFilename As String = ru.UploadedFiles(w).GetName
                                        Dim MIMEType As String = ru.UploadedFiles(w).ContentType
                                        Dim FileLength As Integer = ru.UploadedFiles(w).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes(FileLength - 1) As Byte
                                            If FileBytes.Length > 204800 Then
                                                ShowError("File exceeded the file size limit.")
                                            Else
                                                If ru.UploadedFiles(w).InputStream.Read(FileBytes, 0, FileLength) Then
                                                    If Not fbs Is Nothing AndAlso fbs.Length > 0 Then
                                                        'cEmp.UpdateEmployeeProfile(CurrentPictureID, FileBytes, nn.Text, fbs)
                                                        oSecurity.SaveBinaryImageCP(CurrentClientCode, FileBytes, fbs, wp, sc, theme, bg)
                                                    Else
                                                        'cEmp.UpdateEmployeeProfile(CurrentPictureID, FileBytes, nn.Text, fbs)
                                                        oSecurity.SaveBinaryImageCP(CurrentClientCode, FileBytes, fbs, wp, sc, theme, bg)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    'cEmp.UpdateEmployeeProfile(CurrentPictureID, rbi.Value, nn.Text, fbs)
                                    oSecurity.SaveBinaryImageCP(CurrentClientCode, rbi.Value, fbs, ddlWP.SelectedValue, Drawing.ColorTranslator.ToHtml(rc.SelectedColor).ToString(), ddlTheme.SelectedValue, bgrb)
                                End If
                            Else
                                If ruwp.UploadedFiles.Count > 0 Then
                                    For j As Integer = 0 To ruwp.UploadedFiles.Count - 1
                                        Dim realFilename As String = ruwp.UploadedFiles(j).GetName
                                        Dim MIMEType As String = ruwp.UploadedFiles(j).ContentType
                                        Dim FileLength As Integer = ruwp.UploadedFiles(j).InputStream.Length
                                        If FileLength > 0 Then
                                            Dim FileBytes2(FileLength - 1) As Byte
                                            If FileBytes2.Length > 500000 Then
                                                ShowError("Client Portal wallpaper file exceeded the file size limit.")
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
                                            If FileBytes.Length > 32765 Then
                                                ShowError("File exceeded the file size limit.")
                                            Else
                                                If ru.UploadedFiles(k).InputStream.Read(FileBytes, 0, FileLength) Then
                                                    'cEmp.SaveEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"), FileBytes, nn.Text, fbs)
                                                    oSecurity.SaveBinaryImageCP(CurrentClientCode, FileBytes, fbs, ddlWP.SelectedValue, Drawing.ColorTranslator.ToHtml(rc.SelectedColor).ToString(), ddlTheme.SelectedValue, bgrb)
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    Dim dr As SqlClient.SqlDataReader
                                    dr = oSecurity.GetBinaryImageCP(CurrentClientCode)
                                    If dr.HasRows Then
                                        dr.Read()
                                        If IsDBNull(dr("BINARY_IMAGE_WP")) = False Then
                                            fbs = CType(dr("BINARY_IMAGE_WP"), Byte())
                                        End If
                                        dr.Close()
                                    End If
                                    'cEmp.SaveEmployeeProfile(CurrentGridRow.GetDataKeyValue("EMP_CODE"), rbi.Value, nn.Text, fbs)
                                    oSecurity.SaveBinaryImageCP(CurrentClientCode, rbi.Value, fbs, ddlWP.SelectedValue, Drawing.ColorTranslator.ToHtml(rc.SelectedColor).ToString(), ddlTheme.SelectedValue, bgrb)
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
                            'cEmp.UpdateEmployeeProfile(gridDataItem.GetDataKeyValue("EMP_PICTURE_ID"), Filebytes, "", Filebytes)
                            oSecurity.SaveBinaryImageCP(gridDataItem.GetDataKeyValue("CL_CODE"), Filebytes, Filebytes, "", "", "", "")
                            count += 1
                        End If
                    Next
                    If count = 0 Then
                        Me.ShowError("No rows were selected.")
                        Me.RadGridProfiles.Rebind()
                        Exit Sub
                    End If
                    Me.RadGridProfiles.Rebind()
            End Select
        Catch ex As Exception

        End Try
    End Sub

End Class