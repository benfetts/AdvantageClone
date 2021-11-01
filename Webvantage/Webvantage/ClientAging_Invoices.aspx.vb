Public Class ClientAging_Invoices
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client, False))

        Try

            RadGridCA.Columns.FindByUniqueName("GridTemplateColumnDocuments").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Page.IsPostBack = False Then

            End If
            If Request.QueryString("from") = "mca" Then
                Me.Title = "My Client Aging Invoices"
            Else
                Me.Title = "Client Aging Invoices"
            End If
            Me.butPrint.Attributes.Add("onclick", "window.print();return false;")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCA_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCA.ItemDataBound
        Try
            Dim od As New cDesktopObjects(Session("ConnString"))
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                If e.Item.Cells(16).Text = "P" Then
                    e.Item.Cells(16).Text = "Production"
                End If
                If e.Item.Cells(16).Text = "N" Then
                    e.Item.Cells(16).Text = "Newspaper"
                End If
                If e.Item.Cells(16).Text = "M" And CurrentGridRow.GetDataKeyValue("ManualInvoice") = 1 Then
                    e.Item.Cells(16).Text = "Media"
                ElseIf e.Item.Cells(16).Text = "M" Then
                    e.Item.Cells(16).Text = "Magazine"
                End If
                If e.Item.Cells(16).Text = "O" Then
                    e.Item.Cells(16).Text = "Out of Home"
                End If
                If e.Item.Cells(16).Text = "I" Then
                    e.Item.Cells(16).Text = "Internet"
                End If
                If e.Item.Cells(16).Text = "R" Then
                    e.Item.Cells(16).Text = "Radio"
                End If
                If e.Item.Cells(16).Text = "T" Then
                    e.Item.Cells(16).Text = "TV"
                End If
                If e.Item.Cells(11).Text <> "" And e.Item.Cells(11).Text <> "&nbsp;" Then
                    e.Item.Cells(11).Text = CDate(e.Item.Cells(11).Text).ToShortDateString
                End If
                If e.Item.Cells(12).Text = "" Or e.Item.Cells(12).Text = "&nbsp;" Then
                    e.Item.Cells(12).Text = e.Item.Cells(11).Text
                End If
                If e.Item.Cells(12).Text <> "" And e.Item.Cells(12).Text <> "&nbsp;" Then
                    e.Item.Cells(12).Text = CDate(e.Item.Cells(12).Text).ToShortDateString
                End If
                e.Item.Cells(13).Text = e.Item.Cells(13).Text.PadLeft(6, "0")
                If e.Item.Cells(20).Text <> "" And e.Item.Cells(20).Text <> "&nbsp;" Then
                    e.Item.Cells(18).Text = "Job: " & e.Item.Cells(20).Text
                    If e.Item.Cells(22).Text <> "" And e.Item.Cells(22).Text <> "&nbsp;" Then
                        e.Item.Cells(18).Text = e.Item.Cells(18).Text & "/" & e.Item.Cells(22).Text
                    End If
                    If e.Item.Cells(22).Text <> "" And e.Item.Cells(22).Text <> "&nbsp;" Then
                        e.Item.Cells(18).Text = e.Item.Cells(18).Text & " - " & e.Item.Cells(23).Text
                    Else
                        e.Item.Cells(18).Text = e.Item.Cells(18).Text & " - " & e.Item.Cells(21).Text
                    End If
                End If
                Dim invnbr As Integer = CInt(e.Item.Cells(13).Text)
                Dim invseq As Integer = CInt(e.Item.Cells(14).Text)
                ' e.Item.Cells(19).Text = od.GetInvoiceComment(invnbr, invseq)

                Dim ViewLinkButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImgBtnClientContacts"), ImageButton)
                If Me.cbShowProducts.Checked = True Then
                    ViewLinkButton.Attributes.Add("onclick", "OpenRadWindow('Contacts','popContacts.aspx?from=ca&client=" & e.Item.DataItem("ClientCode") & "&division=" & e.Item.DataItem("DivisionCode") & "&product=" & e.Item.DataItem("ProductCode") & "',1200,400);return false;")
                Else
                    ViewLinkButton.Attributes.Add("onclick", "OpenRadWindow('Contacts','popContacts.aspx?from=ca&client=" & e.Item.DataItem("ClientCode") & "',1200,400);return false;")
                End If

                Dim DocumentsImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonDocuments"), ImageButton)

                If Not DocumentsImageButton Is Nothing Then

                    If CType(e.Item.DataItem("AttachmentCount"), Integer) > 0 Then

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Documents_List2.aspx"
                            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice
                            .InvoiceNumber = CurrentGridRow.GetDataKeyValue("InvoiceNo")
                            .InvoiceSequenceNumber = CurrentGridRow.GetDataKeyValue("InvoiceSeq")

                        End With

                        With DocumentsImageButton

                            .Attributes.Remove("onclick")
                            .Attributes.Add("onclick", Me.HookUpOpenWindow("Invoices", qs.ToString(True)))
                            .ToolTip = e.Item.DataItem("AttachmentCount") & " attachments"

                        End With

                    Else

                        Dim DocumentsDiv As HtmlControls.HtmlControl = CType(e.Item.FindControl("DivDocuments"), HtmlControls.HtmlControl)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DocumentsDiv)

                    End If

                End If

            End If
        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub

    Private Sub RadGridCA_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCA.NeedDataSource
        Try
            Dim client As String
            Dim office As String
            Dim division As String
            Dim product As String
            Dim group As Integer
            Dim from As String
            Dim cats As String
            If Me.Request.QueryString("client") <> "" Then
                client = Request.QueryString("client")
            Else
                client = "%"
            End If
            If Me.Request.QueryString("office") <> "" Then
                office = Request.QueryString("office")
            Else
                office = "%"
            End If
            If Me.Request.QueryString("division") <> "" Then
                division = Request.QueryString("division")
            Else
                division = "%"
            End If
            If Me.Request.QueryString("product") <> "" Then
                product = Request.QueryString("product")
            Else
                product = "%"
            End If
            group = CInt(Request.QueryString("Group"))
            from = Request.QueryString("from")
            cats = Request.QueryString("cat")
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Me.RadGridCA.DataSource = oDO.GetInvoices(Session("UserCode"), client, office, group, division, product, from, cats)
            If Me.cbShowProducts.Checked = True Then
                Me.RadGridCA.MasterTableView.GetColumn("column16").Display = True
                Me.RadGridCA.MasterTableView.GetColumn("column18").Display = True
            Else
                Me.RadGridCA.MasterTableView.GetColumn("column16").Display = False
                Me.RadGridCA.MasterTableView.GetColumn("column18").Display = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbShowProducts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowProducts.CheckedChanged
        Try
            Me.RadGridCA.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub butExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butExport.Click
        Try
            Dim str As String = ""
            str = "ClientAging" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridCA, str)
            RadGridCA.MasterTableView.ExportToExcel()
        Catch ex As Exception

        End Try
    End Sub

    <System.Web.Services.WebMethod(True)>
    Public Shared Sub UpdateCollectionNotes(ByVal InvoiceNumber As Integer, ByVal SequenceNumber As Short, ByVal Notes As String)

        'objects
        Dim AccountReceivableCollectionNote As AdvantageFramework.Database.Entities.AccountReceivableCollectionNote = Nothing
        Dim AccountReceivable As AdvantageFramework.Database.Entities.AccountReceivable = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                AccountReceivable = AdvantageFramework.Database.Procedures.AccountReceivable.LoadByInvoiceNumberAndSequenceNumber(DbContext, InvoiceNumber, SequenceNumber)

                If AccountReceivable IsNot Nothing Then

                    AccountReceivableCollectionNote = AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.LoadByARInvoiceNumberAndSequenceAndType(DbContext, AccountReceivable.InvoiceNumber, AccountReceivable.SequenceNumber, AccountReceivable.Type)

                    If AccountReceivableCollectionNote IsNot Nothing Then

                        If Not String.IsNullOrWhiteSpace(Notes) Then

                            AccountReceivableCollectionNote.Note = Notes

                            AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Update(DbContext, AccountReceivableCollectionNote)

                        Else

                            AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Delete(DbContext, AccountReceivableCollectionNote)

                        End If

                    Else

                        If Not String.IsNullOrWhiteSpace(Notes) Then

                            AccountReceivableCollectionNote = New AdvantageFramework.Database.Entities.AccountReceivableCollectionNote

                            With AccountReceivableCollectionNote

                                .ARInvoiceNumber = AccountReceivable.InvoiceNumber
                                .ARInvoiceSequenceNumber = AccountReceivable.SequenceNumber
                                .ARType = AccountReceivable.Type
                                .Note = Notes

                            End With

                            AdvantageFramework.Database.Procedures.AccountReceivableCollectionNote.Insert(DbContext, AccountReceivableCollectionNote)

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception

        Finally

        End Try

    End Sub

End Class
