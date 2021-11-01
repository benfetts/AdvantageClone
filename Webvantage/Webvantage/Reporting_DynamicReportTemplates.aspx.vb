Public Class Reporting_DynamicReportTemplates
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Mode As Integer = 0
    Private _UserDefinedReportCategoriesList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) = Nothing

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

#End Region

#Region " Methods "

    Private Function UpdateDynamicReport(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim DynamicReportUpdated As Boolean = False

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, GridDataItem.GetDataKeyValue("ID"))

                If DynamicReport IsNot Nothing Then

                    DynamicReport.Description = CType(GridDataItem.FindControl("TextBoxDescription"), TextBox).Text.Trim

                    If IsNumeric(CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue) Then

                        DynamicReport.UserDefinedReportCategoryID = CType(GridDataItem.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        DynamicReport.UserDefinedReportCategoryID = Nothing

                    End If

                    DynamicReport.UpdatedDate = Now
                    DynamicReport.UpdatedByUserCode = _Session.UserCode

                    DynamicReportUpdated = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                End If

            End Using

        Catch ex As Exception
            DynamicReportUpdated = False
        Finally
            UpdateDynamicReport = DynamicReportUpdated
        End Try

    End Function
    Private Sub LoadDynamicReportTemplates()

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadGridDynamicReportTemplates.DataSource = (From DynamicReport In AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList
                                                            Select DynamicReport.ID,
                                                                   DynamicReport.UserDefinedReportCategoryID,
                                                                   [ReportCategory] = If(DynamicReport.UserDefinedReportCategory IsNot Nothing, DynamicReport.UserDefinedReportCategory.Description, ""),
                                                                   DynamicReport.Description,
                                                                   [Type] = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Reporting.DynamicReports), DynamicReport.Type),
                                                                   [CreatedBy] = DynamicReport.CreatedByUserCode,
                                                                   DynamicReport.CreatedDate,
                                                                   [UpdatedBy] = DynamicReport.UpdatedByUserCode,
                                                                   DynamicReport.UpdatedDate).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.Type).ToList

                RadGridDynamicReportTemplates.DataBind()

            End Using

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_DynamicReportTemplates_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            LoadDynamicReportTemplates()

        End If

        Try

            If Request.QueryString("Mode") IsNot Nothing Then

                _Mode = CType(Request.QueryString("Mode"), Integer)

            End If

        Catch ex As Exception
            _Mode = 0
        End Try

        If _Mode = 0 Then

            RadToolBarButtonSelect.Visible = True
            RadToolBarButtonCancel.Visible = True
            RadToolBarButtonDelete.Visible = False
            RadToolBarButtonClose.Visible = False

            Me.Title = "Select Report Template"

        Else

            RadToolBarButtonSelect.Visible = False
            RadToolBarButtonCancel.Visible = False
            RadToolBarButtonDelete.Visible = True
            RadToolBarButtonClose.Visible = True

            Me.Title = "Report Templates"

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportTemplates_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportTemplates.ButtonClick

        'objects
        Dim FunctionName As String = ""
        Dim DynamicReportTemplateID As Integer = 0
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonCancel.Value, RadToolBarButtonClose.Value

                Me.CloseThisWindow()

            Case RadToolBarButtonSelect.Value

                If RadGridDynamicReportTemplates.SelectedItems.Count > 0 Then

                    Try

                        DynamicReportTemplateID = RadGridDynamicReportTemplates.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).First.GetDataKeyValue("ID")

                    Catch ex As Exception
                        DynamicReportTemplateID = 0
                    End Try

                    If DynamicReportTemplateID > 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", DynamicReportTemplateID), True, True)

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select a template")

                End If

            Case RadToolBarButtonDelete.Value

                If RadGridDynamicReportTemplates.SelectedItems.Count > 0 Then

                    Try

                        DynamicReportTemplateID = RadGridDynamicReportTemplates.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem).First.GetDataKeyValue("ID")

                    Catch ex As Exception
                        DynamicReportTemplateID = 0
                    End Try

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DynamicReportTemplateID)

                            If DynamicReport IsNot Nothing Then

                                If AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport) Then

                                    LoadDynamicReportTemplates()

                                End If

                            End If

                        End Using

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select a template to delete")

                End If

        End Select

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDynamicReportTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridDynamicReportTemplates.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridDynamicReportTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateDynamicReport(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateDynamicReport(CurrentGridDataItem)

                End If

        End Select

        If Reload Then

            LoadDynamicReportTemplates()

        End If

    End Sub
    Private Sub RadGridDynamicReportTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDynamicReportTemplates.ItemDataBound

        'objects
        Dim DropDownListReportCategory As Telerik.Web.UI.RadComboBox = Nothing

        If _UserDefinedReportCategoriesList Is Nothing Then

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _UserDefinedReportCategoriesList = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext).ToList

            End Using

        End If

        Try

            DropDownListReportCategory = DirectCast(e.Item.FindControl("DropDownListReportCategory"), Telerik.Web.UI.RadComboBox)

            If DropDownListReportCategory IsNot Nothing Then

                DropDownListReportCategory.DataSource = (From UserDefinedReportCategory In _UserDefinedReportCategoriesList _
                                                         Select UserDefinedReportCategory.ID, _
                                                                UserDefinedReportCategory.Description).ToList

                DropDownListReportCategory.DataBind()

                DropDownListReportCategory.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    DropDownListReportCategory.SelectedValue = e.Item.DataItem.UserDefinedReportCategoryID

                End If

            End If

        Catch ex As Exception
            DropDownListReportCategory = Nothing
        End Try

    End Sub

#End Region

#End Region

End Class