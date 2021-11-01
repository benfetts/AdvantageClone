Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class Documents_AdvancedSearch
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum DocumentCriteria

        CDP
        Client
        Department
        Employee
        FunctionCode
        Job
        JobComponent
        MediaOrderLine
        Office
        Vendor

    End Enum
    Public Enum LevelGridColumn

        GridBoundColumnOfficeCode
        GridBoundColumnOfficeDescription
        GridBoundColumnClientCode
        GridBoundColumnClientName
        GridBoundColumnDivisionCode
        GridBoundColumnDivisionName
        GridBoundColumnProductCode
        GridBoundColumnProductDescription
        GridBoundColumnCampaignCode
        GridBoundColumnCampaignName
        GridBoundColumnJobNumber
        GridBoundColumnJobDescription
        GridBoundColumnJobComponentNumber
        GridBoundColumnJobComponentDescription
        GridBoundColumnVendorCode
        GridBoundColumnVendorName
        GridBoundColumnApInvoice
        GridBoundColumnApInvoiceDescription
        GridBoundColumnApID
        GridBoundColumnAdNumber
        GridBoundColumnAdNumberDescription

    End Enum

#End Region

#Region " Variables "

    Private _AccessPrivate As Boolean = False
    Private _LoadingDatasource As Boolean = False

    Protected WithEvents CheckBoxIncludeAttachments As CheckBox
    Protected WithEvents RadTextBoxSearchCriteria As Telerik.Web.UI.RadTextBox
    Protected WithEvents RadComboBoxLevel As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxCriteria As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxDocumentType As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxLabel As Telerik.Web.UI.RadComboBox

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

    Private Property CurrentGridPageIndex As Integer = 0

    Private Property _Level As String
        Get
            If ViewState("_Level") Is Nothing Then
                ViewState("_Level") = ""
            End If
            Return ViewState("_Level")
        End Get
        Set(value As String)
            ViewState("_Level") = value
        End Set
    End Property
    Private Property _Criteria As Integer
        Get
            If ViewState("_Criteria") Is Nothing Then
                ViewState("_Criteria") = 1
            End If
            Return CType(ViewState("_Criteria"), Integer)
        End Get
        Set(value As Integer)
            ViewState("_Criteria") = value
        End Set
    End Property
    Private Property _TypeID As Integer
        Get
            If ViewState("_TypeID") Is Nothing Then
                ViewState("_TypeID") = 0
            End If
            Return CType(ViewState("_TypeID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("_TypeID") = value
        End Set
    End Property
    Private Property _LabelID As Integer
        Get
            If ViewState("_LabelID") Is Nothing Then
                ViewState("_LabelID") = 0
            End If
            Return CType(ViewState("_LabelID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("_LabelID") = value
        End Set
    End Property
    Private Property _SearchText As String
        Get
            If ViewState("_SearchText") Is Nothing Then
                ViewState("_SearchText") = ""
            End If
            Return ViewState("_SearchText")
        End Get
        Set(value As String)
            ViewState("_SearchText") = value
        End Set
    End Property
    Private Property _IncludeAttachments As Boolean
        Get
            If ViewState("_IncludeAttachments") Is Nothing Then
                ViewState("_IncludeAttachments") = False
            End If
            Return CType(ViewState("_IncludeAttachments"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("_IncludeAttachments") = value
        End Set
    End Property


#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadComboBoxCriteria_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCriteria.SelectedIndexChanged

        Me.ClearSearchResults()

    End Sub
    Private Sub RadComboBoxDocumentType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDocumentType.SelectedIndexChanged

        Me.ClearSearchResults()

    End Sub
    Private Sub RadComboBoxLabel_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLabel.SelectedIndexChanged

        Me.ClearSearchResults()

    End Sub
    Private Sub RadComboBoxLevel_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLevel.SelectedIndexChanged

        Me.SetIncludeAttachmentsCheckBox()
        Me.LoadCriteriaRadComboBox()
        Me.ClearSearchResults()

    End Sub

    Private Sub RadGridDocumentsAdvancedSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDocumentsAdvancedSearch.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If
        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridDocumentsAdvancedSearch.ID, Me.RadGridDocumentsAdvancedSearch.PageSize)
            Exit Sub
        End If

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

        Select Case e.CommandName
            Case "Download"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)
            Case "ShowHistory"
                Dim URL As String = "Documents_History.aspx?" & e.CommandArgument 'Level=" & Me.FolderTreeView.SelectedNode.Attributes("Level") & "&FK=" & Me.FolderTreeView.SelectedNode.Attributes("FK") & "&filename=" & e.CommandArgument
                Me.OpenWindow("Document History", URL)
            Case "AddComments"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, e.CommandArgument)

                    If Document IsNot Nothing Then

                        If Document.FileName.ToUpper.EndsWith(".PDF") Then

                            Me.OpenWindow(Document.FileName, "Documents_PDFViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                            Me.OpenWindow(Document.FileName, "Documents_WordViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse
                                Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse
                                Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") OrElse
                                Document.FileName.ToUpper.EndsWith(".BMP") Then

                            Me.OpenWindow(Document.FileName, "Documents_ImageViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.EndsWith(".MSG") Then

                            Me.OpenWindow(Document.FileName, "Documents_MSGViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.Contains(".XLS") OrElse Document.FileName.ToUpper.Contains(".XLSX") Then

                            Me.OpenWindow(Document.FileName, "Documents_ExcelViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=0", 800, 1200)

                        End If

                    End If

                End Using

        End Select

    End Sub
    Private Sub RadGridDocumentsAdvancedSearch_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDocumentsAdvancedSearch.ItemDataBound

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

            If Not CurrentGridRow Is Nothing Then

                'objects
                Dim ImageButtonAddComments As System.Web.UI.WebControls.ImageButton = Nothing
                Dim AddCommentsButtonVisible As Boolean = False
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim SizeCell As Integer = 3
                Dim ForiegnKey As String = ""
                Dim Filename As String = ""
                Dim Description As String = ""

                Try

                    Select Case e.Item.DataItem("LEVEL")
                        Case "OF"
                            If IsDBNull(e.Item.DataItem("OFFICE_CODE")) = False Then ForiegnKey = e.Item.DataItem("OFFICE_CODE")
                        Case "CM"
                            If IsDBNull(e.Item.DataItem("CMP_CODE")) = False Then ForiegnKey = e.Item.DataItem("CMP_CODE")
                        Case "CL"
                            If IsDBNull(e.Item.DataItem("CL_CODE")) = False Then ForiegnKey = e.Item.DataItem("CL_CODE")
                        Case "DI"
                            If IsDBNull(e.Item.DataItem("DIV_CODE")) = False Then ForiegnKey = e.Item.DataItem("DIV_CODE")
                        Case "PR"
                            If IsDBNull(e.Item.DataItem("PRD_CODE")) = False Then ForiegnKey = e.Item.DataItem("PRD_CODE")
                        Case "JO"
                            If IsDBNull(e.Item.DataItem("JOB_NUMBER")) = False Then ForiegnKey = e.Item.DataItem("JOB_NUMBER")
                        Case "JC"
                            If IsDBNull(e.Item.DataItem("JOB_NUMBER")) = False AndAlso IsDBNull(e.Item.DataItem("JOB_COMPONENT_NBR")) = False Then ForiegnKey = e.Item.DataItem("JOB_NUMBER") & "," & e.Item.DataItem("JOB_COMPONENT_NBR")
                        Case "VN"
                            If IsDBNull(e.Item.DataItem("AP_ID")) = False Then ForiegnKey = e.Item.DataItem("AP_ID")
                        Case "AN"
                            If IsDBNull(e.Item.DataItem("AD_NBR")) = False Then ForiegnKey = e.Item.DataItem("AD_NBR")
                        Case "EX"
                            If IsDBNull(e.Item.DataItem("AP_INVOICE")) = False Then ForiegnKey = e.Item.DataItem("AP_INVOICE")
                    End Select

                Catch ex As Exception

                End Try

                If IsDBNull(e.Item.DataItem("FILENAME")) = False Then Filename = e.Item.DataItem("FILENAME")


                If IsDBNull(e.Item.DataItem("DESCRIPTION")) = False Then Description = e.Item.DataItem("DESCRIPTION")

                AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton),
                                                                                   DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                   Nothing, Nothing,
                                                                                   DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                   Nothing, Nothing, "",
                                                                                   CurrentGridRow("GridBoundColumnFileSize").Text,
                                                                                   e.Item.DataItem("DOCUMENT_ID"), e.Item.DataItem("MIME_TYPE"), Filename, e.Item.DataItem("REPOSITORY_FILENAME"), Description, e.Item.DataItem("FILE_SIZE"),
                                                                                   e.Item.DataItem("LEVEL"), ForiegnKey, 0)

                e.Item.Attributes.Add("DocumentId", e.Item.DataItem("DOCUMENT_ID"))
                CurrentGridRow("GridBoundColumnUploadedDate").Text = LoGlo.FormatDateTime(CurrentGridRow("GridBoundColumnUploadedDate").Text)


                AdvantageFramework.Web.Presentation.Controls.SetDocumentEditPopUp(CurrentGridRow.FindControl("ImageButtonEditDetails"), e.Item.DataItem("DOCUMENT_ID"), "Documents_AdvancedSearch.aspx")

            End If

        End If

    End Sub
    Private Sub RadGridDocumentsAdvancedSearch_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDocumentsAdvancedSearch.NeedDataSource

        If (Me.IsPostBack = True AndAlso Me.EventTarget.Contains("RadComboBoxLevel") = False AndAlso Me.EventTarget.Contains("RadComboBoxCriteria") = False AndAlso
            Me.EventTarget.Contains("RadComboBoxDocumentType") = False AndAlso Me.EventTarget.Contains("RadComboBoxLabel") = False) OrElse
            Me.CurrentQuerystring.IsBookmark = True OrElse Me.EventTarget.Contains("RadGridDocumentsAdvancedSearch") = True Then

            _LoadingDatasource = True

            Me.SetSearch()

            'Just test before moving proc to framework
            Try

                Dim arParams(9) As SqlParameter

                Dim pAPPLICATION_ID As New SqlParameter("@APPLICATION_ID", SqlDbType.Int)
                pAPPLICATION_ID.Value = 2
                arParams(0) = pAPPLICATION_ID

                Dim pUSER_CODE As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUSER_CODE.Value = _Session.UserCode
                arParams(1) = pUSER_CODE

                Dim pACCESS_PRIVATE As New SqlParameter("@ACCESS_PRIVATE", SqlDbType.Bit)
                pACCESS_PRIVATE.Value = Me._AccessPrivate
                arParams(2) = pACCESS_PRIVATE

                Dim pSEARCH_TEXT As New SqlParameter("@SEARCH_TEXT", SqlDbType.VarChar)
                pSEARCH_TEXT.Value = Me._SearchText
                arParams(3) = pSEARCH_TEXT

                Dim pLEVEL As New SqlParameter("@LEVEL", SqlDbType.VarChar, 50)
                pLEVEL.Value = Me._Level
                arParams(4) = pLEVEL

                Dim pCRITERIA_ENUM_VALUE As New SqlParameter("@CRITERIA_ENUM_VALUE", SqlDbType.SmallInt)
                pCRITERIA_ENUM_VALUE.Value = Me._Criteria
                arParams(5) = pCRITERIA_ENUM_VALUE

                Dim pDOCUMENT_TYPE_ID As New SqlParameter("@DOCUMENT_TYPE_ID", SqlDbType.Int)
                pDOCUMENT_TYPE_ID.Value = Me._TypeID
                arParams(6) = pDOCUMENT_TYPE_ID

                Dim pLABEL_ID As New SqlParameter("@LABEL_ID", SqlDbType.Int)
                pLABEL_ID.Value = Me._LabelID
                arParams(7) = pLABEL_ID

                Dim pINCLUDE_ATTACHMENTS As New SqlParameter("@INCLUDE_ATTACHMENTS", SqlDbType.Bit)
                pINCLUDE_ATTACHMENTS.Value = Me._IncludeAttachments
                arParams(8) = pINCLUDE_ATTACHMENTS

                Dim dt As New DataTable
                dt = SqlHelper.ExecuteDataTable(_Session.ConnectionString, CommandType.StoredProcedure, "advsp_advanced_document_search", "DtData", arParams)

                If dt IsNot Nothing Then

                    Me.RadGridDocumentsAdvancedSearch.DataSource = dt

                End If

            Catch ex As Exception

                Me.ShowMessage(ex.Message.ToString())

            End Try

            Dim DetailDocuments As Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument) = Nothing

            'Dim AdvancedSearch As New vAdvancedDocumentSearch(Session("ConnString"))
            'AdvancedSearch.Search(_SearchText, _Session.UserCode, Me._AccessPrivate)
            'Me.RadGridDocumentsAdvancedSearch.DataSource = AdvancedSearch.DefaultView

            '''''Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '''''    Dim DetailDocuments As Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument) = Nothing

            '''''    Try

            '''''        DetailDocuments = DbContext.ExecuteStoreQuery(Of AdvantageFramework.Database.Classes.DetailDocument)(String.Format("exec proc_AdvancedDocumentSearch '{0}', '{1}', {2}", _SearchText, _Session.UserCode, If(Me._AccessPrivate, 1, 0))).ToList

            '''''    Catch ex As Exception

            '''''        DetailDocuments = Nothing

            '''''    End Try

            '''''    If DetailDocuments Is Nothing Then

            '''''        DetailDocuments = New Generic.List(Of AdvantageFramework.Database.Classes.DetailDocument)

            '''''    End If

            '''''    Me.RadGridDocumentsAdvancedSearch.DataSource = DetailDocuments
            '''''    Me.RadGridDocumentsAdvancedSearch.CurrentPageIndex = Me.CurrentGridPageIndex
            '''''    Me.RadGridDocumentsAdvancedSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridDocumentsAdvancedSearch.ID)

            '''''End Using

            Me.RadGridDocumentsAdvancedSearch.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridDocumentsAdvancedSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridDocumentsAdvancedSearch.ID)

            Me.SetGridColumns()

        End If
        _LoadingDatasource = False
    End Sub
    Private Sub RadGridDocumentsAdvancedSearch_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridDocumentsAdvancedSearch.PageIndexChanged

        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridDocumentsAdvancedSearch.Rebind()

    End Sub
    Private Sub RadGridDocumentsAdvancedSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridDocumentsAdvancedSearch.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridDocumentsAdvancedSearch.ID, e.NewPageSize)

        End If

    End Sub

    Private Sub RadToolbarAdvancedSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAdvancedSearch.ButtonClick
        Dim FileName As String = String.Empty

        Select Case e.Item.Value
            Case "Clear"

                Me.ResetSearch()

            Case "Search"

                If String.Compare(Me.RadTextBoxSearchCriteria.Text.Trim(), "#Rick_Astley", False) = 0 Then

                    Me.OpenWindow("You have been Rick Rolled by Advantage!!!!", "http://www.youtube.com/embed/dQw4w9WgXcQ?autoplay=1", , , , True)

                End If

                Me.RadGridDocumentsAdvancedSearch.Rebind()

            Case "Bookmark"

                Me.SetSearch()

                Dim s As String = ""
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)
                Dim qs As New AdvantageFramework.Web.QueryString()
                Dim sb As New System.Text.StringBuilder
                Dim SearchText As String = IIf(String.IsNullOrWhiteSpace(Me.RadTextBoxSearchCriteria.Text) = True OrElse
                                               Me.RadTextBoxSearchCriteria.Text.Trim() = "%", "Any", Me.RadTextBoxSearchCriteria.Text)

                qs.Add("_Level", _Level)
                qs.Add("_Criteria", _Criteria)
                qs.Add("_TypeID", _TypeID)
                qs.Add("_LabelID", _LabelID)
                qs.Add("_SearchText", _SearchText)
                qs.Add("_IncludeAttachments", _IncludeAttachments)

                sb.Append("Level: ")
                sb.Append(Me.RadComboBoxLevel.SelectedItem.Text.Replace("[", "").Replace("]", ""))
                sb.Append(", ")
                sb.Append("Include Attachments: ")
                sb.Append(IIf(_IncludeAttachments = True, "Yes", "No"))
                sb.Append(", ")
                sb.Append("Criteria: ")
                sb.Append(Me.RadComboBoxLevel.SelectedItem.Text.Replace("[", "").Replace("]", ""))
                sb.Append(", ")
                sb.Append("Text: ")
                sb.Append(SearchText)
                sb.Append(", ")
                sb.Append("Type: ")
                sb.Append(Me.RadComboBoxLevel.SelectedItem.Text.Replace("[", "").Replace("]", ""))
                sb.Append(", ")
                sb.Append("Label: ")
                sb.Append(Me.RadComboBoxLevel.SelectedItem.Text.Replace("[", "").Replace("]", ""))

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.DocumentAdvancedSearch
                    .UserCode = _Session.UserCode
                    .Name = "Document Search: " & SearchText
                    .Description = sb.ToString()
                    .PageURL = "Documents_AdvancedSearch.aspx" & qs.ToString()

                End With

                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

                sb = Nothing

            Case "ExportToExcel" '735-2-1308 - ADV/WV-Document Manager-Add export capability to Document Manager Advanced Document Search
                Try
                    If Me.RadGridDocumentsAdvancedSearch.MasterTableView.Items.Count > 0 Then
                        FileName = "DocumentsAdvancedSearch" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True)
                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.Caption = "Documents Advanced Search"
                        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridDocumentsAdvancedSearch, FileName)

                        Me.RadGridDocumentsAdvancedSearch.ExportSettings.OpenInNewWindow = True
                        Me.RadGridDocumentsAdvancedSearch.ExportSettings.IgnorePaging = True
                        Me.RadGridDocumentsAdvancedSearch.ExportSettings.ExportOnlyData = False
                        Me.RadGridDocumentsAdvancedSearch.ExportSettings.Excel.Format = GridExcelExportFormat.Biff

                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumn("GridTemplateColumnLabels").Visible = False
                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumn("GridTemplateColumnDocumentType").Visible = False
                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumn("GridTemplateColumnDocumentHistory").Visible = False
                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumn("GridTemplateColumnAddComments").Visible = False

                        Me.RadGridDocumentsAdvancedSearch.MasterTableView.ExportToExcel()
                    Else
                        Me.ShowMessage("There is nothing to export!")
                    End If

                Catch ex As Exception
                End Try

        End Select
    End Sub

#End Region
#Region " Page "

    Private Sub AdvancedDocumentSearch_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager)

        Me.RadTextBoxSearchCriteria = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("RadTextBoxSearchCriteria"), Telerik.Web.UI.RadTextBox)

        Me.CheckBoxIncludeAttachments = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("CheckBoxIncludeAttachments"), CheckBox)
        Me.RadComboBoxLevel = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("RadComboBoxLevel"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBoxCriteria = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("RadComboBoxCriteria"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBoxDocumentType = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("RadComboBoxDocumentType"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBoxLabel = CType(Me.RadToolbarAdvancedSearch.Items.FindItemByValue("RadToolBarButtonSearch").FindControl("RadComboBoxLabel"), Telerik.Web.UI.RadComboBox)

        Me._AccessPrivate = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) = 1

        'This has to be called on every load  
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridDocumentsAdvancedSearch)

    End Sub
    Private Sub AdvancedDocumentSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.Page.IsPostBack = False AndAlso Me.Page.IsCallback = False Then

            Me.RadToolbarAdvancedSearch.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            'load combos
            Using oc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Me.LoadLevelRadComboBox()

                    If Me.CurrentQuerystring.IsBookmark = False Then

                        Me.LoadCriteriaRadComboBox()

                    End If

                    Me.RadComboBoxDocumentType.AppendDataBoundItems = True
                    Me.RadComboBoxDocumentType.DataSource = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(dc).OrderByDescending(Function(d) d.IsDefault).ThenBy(Function(d) d.Name).ToList()
                    Me.RadComboBoxDocumentType.DataTextField = "Name"
                    Me.RadComboBoxDocumentType.DataValueField = "ID"
                    Me.RadComboBoxDocumentType.DataBind()

                    Me.RadComboBoxLabel.AppendDataBoundItems = True
                    Me.RadComboBoxLabel.DataSource = AdvantageFramework.Database.Procedures.Label.LoadActive(dc).OrderBy(Function(d) d.Name).ToList()
                    Me.RadComboBoxLabel.DataTextField = "Name"
                    Me.RadComboBoxLabel.DataValueField = "ID"
                    Me.RadComboBoxLabel.DataBind()

                End Using

            End Using

            If Me.CurrentQuerystring.IsBookmark = True Then

                Try
                    Me._Level = Me.CurrentQuerystring.GetValue("_Level")
                Catch ex As Exception
                    Me._Level = ""
                End Try
                Try
                    Me._Criteria = Me.CurrentQuerystring.GetValue("_Criteria")
                Catch ex As Exception
                    Me._Criteria = 0
                End Try
                Try
                    Me._TypeID = Me.CurrentQuerystring.GetValue("_TypeID")
                Catch ex As Exception
                    Me._TypeID = 0
                End Try
                Try
                    Me._LabelID = Me.CurrentQuerystring.GetValue("_LabelID")
                Catch ex As Exception
                    Me._LabelID = 0
                End Try
                Try
                    Me._SearchText = Me.CurrentQuerystring.GetValue("_SearchText")
                Catch ex As Exception
                    Me._SearchText = ""
                End Try
                Try
                    Me._IncludeAttachments = Me.CurrentQuerystring.GetValue("_IncludeAttachments")
                Catch ex As Exception
                    Me._IncludeAttachments = False
                End Try

                Me.RadTextBoxSearchCriteria.Text = Me._SearchText

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxLevel, Me._Level, False)

                Me.SetIncludeAttachmentsCheckBox()

                Me.CheckBoxIncludeAttachments.Checked = Me._IncludeAttachments

                Me.LoadCriteriaRadComboBox()
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxCriteria, Me._Criteria, False)

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDocumentType, Me._TypeID, False)
                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxLabel, Me._LabelID, False)

                Me.RadGridDocumentsAdvancedSearch.Rebind()

            End If

        Else



        End If

    End Sub

#End Region

    Private Sub LoadLevelRadComboBox()

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_APInvoice, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ARInvoice, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation)) ' newly added
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AdNumber, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AgencyDesktop, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AlertAttachment.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AlertAttachment.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Campaign, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Contract, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ContractReport, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Division, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Employee, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExecutiveDesktop, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation))
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseDetail.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseDetail.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Job, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Office, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Product, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation))
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Vendor, False)) Then
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation)) ' newly added
            Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Abbreviation)) ' newly added
        End If
        'If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_VendorContract, False)) Then
        '    Me.RadComboBoxLevel.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Abbreviation)) ' newly added
        'End If


    End Sub
    Private Sub LoadCriteriaRadComboBox()

        Me._Level = Me.RadComboBoxLevel.SelectedItem.Value

        Dim DocumentSearchCriteriaEnumValue As Integer = 0

        Me.RadComboBoxCriteria.Items.Clear()

        If String.IsNullOrWhiteSpace(Me._Level) = False Then

            DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.AllCriteria, Integer)
            Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.NoCriteria, Integer)
            Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

        End If

        Select Case Me._Level

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Vendor, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.MediaOrderLine, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AlertAttachment.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Campaign, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.AlertSubject, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.MediaOrderLine, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Client, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Client, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Client, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientContract, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Client, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Division, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Client, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Division, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Employee, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseDetail.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Employee, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.FunctionCode, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Job, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.JobComponent, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientDivisionProduct, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Vendor, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Vendor, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                'DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.ClientContract, Integer)
                'Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                '                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Department, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Employee, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

                DocumentSearchCriteriaEnumValue = CType(AdvantageFramework.Database.Entities.DocumentSearchCriteria.Office, Integer)
                Me.RadComboBoxCriteria.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), DocumentSearchCriteriaEnumValue),
                                                                                    DocumentSearchCriteriaEnumValue))

            Case Else

                Dim DocumentSearchCriteriaDataTable As New DataTable

                DocumentSearchCriteriaDataTable = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.DocumentSearchCriteria), False, True)

                Me.RadComboBoxCriteria.DataSource = DocumentSearchCriteriaDataTable
                Me.RadComboBoxCriteria.DataTextField = "Name"
                Me.RadComboBoxCriteria.DataValueField = "Value"
                Me.RadComboBoxCriteria.DataBind()

        End Select

    End Sub

    Private Sub SetSearch()

        If Me.RadComboBoxLevel.SelectedItem IsNot Nothing Then Me._Level = Me.RadComboBoxLevel.SelectedItem.Value
        If Me.RadComboBoxCriteria.SelectedItem IsNot Nothing Then Me._Criteria = Me.RadComboBoxCriteria.SelectedItem.Value
        If Me.RadComboBoxDocumentType.SelectedItem IsNot Nothing Then Me._TypeID = Me.RadComboBoxDocumentType.SelectedItem.Value
        If Me.RadComboBoxLabel.SelectedItem IsNot Nothing Then Me._LabelID = Me.RadComboBoxLabel.SelectedItem.Value
        If Me.CheckBoxIncludeAttachments IsNot Nothing Then Me._IncludeAttachments = Me.CheckBoxIncludeAttachments.Checked

        Me._SearchText = IIf(String.IsNullOrWhiteSpace(Me.RadTextBoxSearchCriteria.Text) = True, "%", Me.RadTextBoxSearchCriteria.Text.Trim())

    End Sub
    Private Sub ResetSearch()

        Me.RadComboBoxLevel.SelectedIndex = 0
        Me.SetIncludeAttachmentsCheckBox()
        Me.LoadCriteriaRadComboBox()
        Me.RadTextBoxSearchCriteria.Text = ""
        Me.RadComboBoxDocumentType.SelectedIndex = 0
        Me.RadComboBoxLabel.SelectedIndex = 0

        Me.ClearSearchResults()

    End Sub
    Private Sub ClearSearchResults()

        For Each column As GridColumn In Me.RadGridDocumentsAdvancedSearch.MasterTableView.Columns

            column.CurrentFilterFunction = GridKnownFunction.NoFilter
            column.CurrentFilterValue = String.Empty

        Next

        Me.RadGridDocumentsAdvancedSearch.MasterTableView.FilterExpression = String.Empty

        Me.RadGridDocumentsAdvancedSearch.DataSource = Nothing
        Me.RadGridDocumentsAdvancedSearch.DataBind()

    End Sub
    Private Sub SetGridColumns()

        Dim IsVisible As Boolean = False

        If String.IsNullOrWhiteSpace(Me._Level) = False Then

            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoice").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoiceDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApID").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumberDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnExpenseHeaderDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeFullName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractReportDesc").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAlertSubject").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamDescription").Visible = IsVisible

            IsVisible = True

            Select Case Me._Level
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumberDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoice").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoiceDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApID").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AlertAttachment.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAlertSubject").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Contract.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ContractReport.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractReportDesc").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeFullName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation,
                     AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseDetail.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApID").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnExpenseHeaderDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeFullName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentNumber").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorName").Visible = IsVisible

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.VendorContract.Abbreviation

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible

                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractCode").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractDescription").Visible = IsVisible
                    'Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractReportDesc").Visible = IsVisible

                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorCode").Visible = IsVisible
                    Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorName").Visible = IsVisible

                Case Else

            End Select

        Else

            IsVisible = True

            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnOfficeDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnClientName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDivisionName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnProductDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnCampaignName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnJobComponentDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnVendorName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoice").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApInvoiceDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnApID").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumber").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAdNumberDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnExpenseHeaderDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnEmployeeFullName").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractDescription").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnContractReportDesc").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnAlertSubject").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamCode").Visible = IsVisible
            Me.RadGridDocumentsAdvancedSearch.MasterTableView.GetColumnSafe("GridBoundColumnDepartmentTeamDescription").Visible = IsVisible

        End If

    End Sub
    Private Sub SetIncludeAttachmentsCheckBox()

        If Me.RadComboBoxLevel.SelectedIndex = 0 Then 'All levels

            Me.CheckBoxIncludeAttachments.Checked = False
            Me.CheckBoxIncludeAttachments.Visible = True

        Else


            Select Case Me.RadComboBoxLevel.SelectedItem.Value
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AlertAttachment.Abbreviation

                    Me.CheckBoxIncludeAttachments.Checked = True

                Case Else

                    Me.CheckBoxIncludeAttachments.Checked = False

            End Select

            Me.CheckBoxIncludeAttachments.Visible = False

        End If

    End Sub


#End Region

End Class
