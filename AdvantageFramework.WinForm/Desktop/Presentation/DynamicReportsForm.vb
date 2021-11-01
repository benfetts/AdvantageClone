Namespace Desktop.Presentation

    Public Class DynamicReportsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim UserDefinedReportCategoryID As Integer = 0

            Try

                UserDefinedReportCategoryID = ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.SelectedValue

            Catch ex As Exception
                UserDefinedReportCategoryID = 0
            End Try

            If UserDefinedReportCategoryID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, Session.Application, Session.User.ID).Where(Function(Entity) Entity.UserDefinedReportCategoryID.GetValueOrDefault(0) = UserDefinedReportCategoryID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                        End Using

                    End Using

                End Using

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DataGridViewForm_Reports.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(SecurityDbContext, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList, Session.Application, Session.User.ID).Select(Function(Entity) New AdvantageFramework.Database.Classes.UDReport(Entity)).OrderBy(Function(Entity) Entity.ReportCategory).ThenBy(Function(Entity) Entity.Description).ThenBy(Function(Entity) Entity.DatasetType).ToList

                        End Using

                    End Using

                End Using

            End If

            DataGridViewForm_Reports.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Add.Enabled = True

            ButtonItemActions_View.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_UpdateInfo.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_EditReport.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow
            ButtonItemActions_Delete.Enabled = DataGridViewForm_Reports.HasASelectedRow
            ButtonItemActions_Copy.Enabled = DataGridViewForm_Reports.HasOnlyOneSelectedRow

            ButtonItemActions_Refresh.Enabled = True

        End Sub
        Private Sub ViewDynamicReport()

            'objects
            Dim UDReport As AdvantageFramework.Database.Classes.UDReport = Nothing

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        UDReport = DataGridViewForm_Reports.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        UDReport = Nothing
                    End Try

                    If UDReport IsNot Nothing Then

                        AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(False, UDReport.ID, True)

                    End If

                End Using

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a report to view.")

            End If

        End Sub
        Private Function CreateXML(ByVal AFObject As Object, ParamArray ExtraTypes() As System.Type) As String

            'objects
            Dim XmlSerializer As System.Xml.Serialization.XmlSerializer = Nothing
            Dim XmlAttributeOverrides As System.Xml.Serialization.XmlAttributeOverrides = Nothing
            Dim XmlAttributes As System.Xml.Serialization.XmlAttributes = Nothing
            Dim XmlElementAttribute As System.Xml.Serialization.XmlElementAttribute = Nothing
            Dim StringWriter As System.IO.StringWriter = Nothing
            Dim XML As String = ""

            Try

                XmlAttributeOverrides = New System.Xml.Serialization.XmlAttributeOverrides

                For Each ExtraType In ExtraTypes

                    XmlAttributes = New System.Xml.Serialization.XmlAttributes

                    XmlElementAttribute = New System.Xml.Serialization.XmlElementAttribute

                    XmlElementAttribute.ElementName = ExtraType.Name & "s"
                    XmlElementAttribute.Type = ExtraType

                    XmlAttributes.XmlElements.Add(XmlElementAttribute)

                    XmlAttributeOverrides.Add(AFObject.GetType, XmlElementAttribute.ElementName, XmlAttributes)

                Next

                XmlSerializer = New System.Xml.Serialization.XmlSerializer(AFObject.GetType, XmlAttributeOverrides)
                StringWriter = New System.IO.StringWriter

                XmlSerializer.Serialize(StringWriter, AFObject)

                StringWriter.Close()

            Catch ex As Exception

                If StringWriter IsNot Nothing Then

                    StringWriter.Close()
                    StringWriter = Nothing

                End If

            Finally

                If StringWriter IsNot Nothing Then

                    XML = StringWriter.ToString

                End If

                CreateXML = XML

            End Try

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DynamicReportsForm As DynamicReportsForm = Nothing

            DynamicReportsForm = New DynamicReportsForm

            DynamicReportsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DynamicReportsForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedReportCategoryBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_View.Image = My.Resources.DynamicReportImage
            ButtonItemActions_Add.Image = My.Resources.AddImage
            ButtonItemActions_UpdateInfo.Image = My.Resources.UpdateReportInfoImage
            ButtonItemActions_EditReport.Image = My.Resources.ReportEditImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = My.Resources.RefreshImage
            ButtonItemActions_Export.Image = My.Resources.DatabaseExportImage
            ButtonItemActions_Import.Image = My.Resources.DatabaseImportImage

            DataGridViewForm_Reports.MultiSelect = True

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember = "Description"
                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember = "ID"

                    UserDefinedReportCategoryBindingSource = New System.Windows.Forms.BindingSource

                    UserDefinedReportCategoryBindingSource.DataSource = (From UserDefinedReportCategory In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext)
                                                                         Select New With {.ID = UserDefinedReportCategory.ID,
                                                                                          .Description = UserDefinedReportCategory.Description}).OrderBy(Function(c) c.Description).ToList

                    AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(UserDefinedReportCategoryBindingSource, ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DisplayMember,
                                                                                                      ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.ValueMember,
                                                                                                      "[All]", -1, True, True)

                    ComboBoxItemReportCategory_ReportCategory.ComboBoxEx.DataSource = UserDefinedReportCategoryBindingSource

                    ComboBoxItemReportCategory_ReportCategory.SelectedIndex = 0

                End Using

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemReportCategory_ReportCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemReportCategory_ReportCategory.SelectedIndexChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewDynamicReport()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(False, 0, False)

        End Sub
        Private Sub ButtonItemActions_EditReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_EditReport.Click

            'objects
            Dim ReportID As Integer = 0

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            If ReportID > 0 Then

                AdvantageFramework.Desktop.Presentation.DynamicReportEditForm.ShowForm(False, ReportID, False)

            End If

        End Sub
        Private Sub ButtonItemActions_UpdateInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_UpdateInfo.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            Try

                ReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

            Catch ex As Exception
                ReportID = 0
            End Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

            End Using

            If DynamicReport IsNot Nothing Then

                If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Dynamic, DynamicReport.ID, DynamicReport.Type, DynamicReport.Description, DynamicReport.UserDefinedReportCategoryID, False) = Windows.Forms.DialogResult.OK Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DynamicReport.UpdatedByUserCode = Me.Session.UserCode
                        DynamicReport.UpdatedDate = Now

                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                    End Using

                End If

            End If

            If ReloadGrid Then

                LoadGrid()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim ReportID As Integer = 0
            Dim ReloadGrid As Boolean = False

            If DataGridViewForm_Reports.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this report?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm()

                    Try

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                For Each ReportID In DataGridViewForm_Reports.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                                    Try

                                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, ReportID)

                                    Catch ex As Exception
                                        DynamicReport = Nothing
                                    End Try

                                    If DynamicReport IsNot Nothing Then

                                        ReloadGrid = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

                                    End If

                                Next

                            End Using

                        End Using

                        If ReloadGrid Then

                            LoadGrid()

                        End If

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If
           
        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Reports_RowDoubleClickEvent() Handles DataGridViewForm_Reports.RowDoubleClickEvent

            If DataGridViewForm_Reports.HasOnlyOneSelectedRow Then

                ViewDynamicReport()

            End If

        End Sub
        Private Sub DataGridViewForm_Reports_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Reports.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim UserDefinedReportID As Integer = 0
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim DynamicReportXML As AdvantageFramework.Reporting.Database.Classes.DynamicReportXML = Nothing
            Dim DynamicReportID As Integer = 0
            Dim Folder As String = ""
            Dim XMLString As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim ContinueSave As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            If Agency.IsASP.GetValueOrDefault(0) = 0 Then

                ContinueSave = AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder)

            Else

                Folder = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)

                If My.Computer.FileSystem.DirectoryExists(Folder) Then

                    ContinueSave = True

                End If

            End If

            If ContinueSave Then

                Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        DynamicReportID = DataGridViewForm_Reports.GetFirstSelectedRowBookmarkValue(0)

                    Catch ex As Exception
                        DynamicReportID = 0
                    End Try

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("DynamicReportColumns").Include("DynamicReportSummaryItems").Include("DynamicReportUnboundColumns").Where(Function(Entity) Entity.ID = DynamicReportID).SingleOrDefault

                    If DynamicReport IsNot Nothing Then

                        DynamicReportXML = New Reporting.Database.Classes.DynamicReportXML(DynamicReport)

                        XMLString = CreateXML(DynamicReportXML, GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportColumnXML),
                                              GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportSummaryItemXML), GetType(AdvantageFramework.Reporting.Database.Classes.DynamicReportUnboundColumnXML))

                        My.Computer.FileSystem.WriteAllText(Folder & AdvantageFramework.FileSystem.CreateValidFileName(DynamicReport.Description) & ".xml", XMLString, False)

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Import.Click

            If AdvantageFramework.Reporting.Presentation.DynamicReportImportForm.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
