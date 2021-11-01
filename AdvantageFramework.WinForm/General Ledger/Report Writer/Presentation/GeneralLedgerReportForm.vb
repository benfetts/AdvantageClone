Namespace GeneralLedger.ReportWriter.Presentation

    Public Class GeneralLedgerReportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FromInternalReportExport As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal FromInternalReportExport As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FromInternalReportExport = FromInternalReportExport

        End Sub
        Private Sub LoadGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewForm_GLReportTemplates.DataSource = AdvantageFramework.Database.Procedures.GLReportTemplate.Load(DbContext)

            End Using

            DataGridViewForm_GLReportTemplates.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_View.Enabled = DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow
            ButtonItemTemplates_Add.Enabled = True
            ButtonItemTemplates_Delete.Enabled = DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow()
            ButtonItemTemplates_Copy.Enabled = DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow()
            ButtonItemTemplates_Export.Enabled = DataGridViewForm_GLReportTemplates.HasASelectedRow

        End Sub
        Public Sub RefreshForm()

            LoadGrid()

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

        Public Shared Sub ShowForm(Optional ByVal FromInternalReportExport As Boolean = False)

            'objects
            Dim GeneralLedgerReportForm As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm = Nothing

            GeneralLedgerReportForm = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm(FromInternalReportExport)

            GeneralLedgerReportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GeneralLedgerReportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_View.Image = My.Resources.ViewImage
            ButtonItemTemplates_Add.Image = My.Resources.AddImage
            ButtonItemTemplates_Delete.Image = My.Resources.DeleteImage
            ButtonItemTemplates_Copy.Image = My.Resources.CopyImage
            ButtonItemTemplates_Export.Image = My.Resources.DatabaseExportImage
            ButtonItemTemplates_Import.Image = My.Resources.DatabaseImportImage

            DataGridViewForm_GLReportTemplates.MultiSelect = _FromInternalReportExport

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_View.Click

            'objects
            Dim GLReportTemplateID As Integer = 0
            Dim IsTemplateOpen As Boolean = False

            If DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow Then

                GLReportTemplateID = DataGridViewForm_GLReportTemplates.GetFirstSelectedRowBookmarkValue()

                If GLReportTemplateID <> 0 Then

                    For Each MdiChild In Me.ParentForm.MdiChildren

                        If TypeOf MdiChild Is AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm Then

                            If DirectCast(MdiChild, AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm).GLReportTemplateID = GLReportTemplateID Then

                                IsTemplateOpen = True
                                MdiChild.Activate()
                                Exit For

                            End If

                        End If

                    Next

                    If IsTemplateOpen = False Then

                        AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm.ShowForm(GLReportTemplateID)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemTemplates_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplates_Add.Click

            AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportTemplateSetupForm.ShowForm()

        End Sub
        Private Sub ButtonItemTemplates_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplates_Copy.Click

            'objects
            Dim GLReportTemplateID As Integer = 0
            Dim NewGLReportTemplateID As Integer = 0
            Dim Copied As Boolean = False

            If DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow Then

                GLReportTemplateID = DataGridViewForm_GLReportTemplates.GetFirstSelectedRowBookmarkValue()

                If GLReportTemplateID <> 0 Then

                    Me.FormAction = WinForm.Presentation.FormActions.Copying
                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Copying...")

                    Try

                        Copied = CopyGLReportTemplate(Me.Session, GLReportTemplateID, NewGLReportTemplateID)

                    Catch ex As Exception
                        Copied = False
                    End Try

                    If Copied Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                            DataGridViewForm_GLReportTemplates.SelectRow(NewGLReportTemplateID)

                            EnableOrDisableActions()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    Else

                        Me.CloseWaitForm()

                        AdvantageFramework.WinForm.MessageBox.Show("Failed copying GL report template.  Please contact Software Support.")

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemTemplates_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemTemplates_Delete.Click

            'objects
            Dim GLReportTemplateID As Integer = 0
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing

            If DataGridViewForm_GLReportTemplates.HasOnlyOneSelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this GL report template?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    GLReportTemplateID = DataGridViewForm_GLReportTemplates.GetFirstSelectedRowBookmarkValue()

                    If GLReportTemplateID <> 0 Then

                        Me.FormAction = WinForm.Presentation.FormActions.Deleting
                        Me.ShowWaitForm()

                        Me.ShowWaitForm("Deleting...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.LoadByGLReportTemplateID(DbContext, GLReportTemplateID)

                                If GLReportTemplate IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.GLReportTemplate.Delete(DbContext, GLReportTemplate)

                                End If

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GLReportTemplates_RowDoubleClickEvent() Handles DataGridViewForm_GLReportTemplates.RowDoubleClickEvent

            ButtonItemActions_View.RaiseClick()

        End Sub
        Private Sub DataGridViewForm_GLReportTemplates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_GLReportTemplates.SelectionChangedEvent

            If Me.FormShown Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemTemplates_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplates_Export.Click

            'objects
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim GLReportTemplate As AdvantageFramework.Database.Entities.GLReportTemplate = Nothing
            Dim GLReportTemplateXML As AdvantageFramework.Database.Classes.GLReportTemplateXML = Nothing
            Dim GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport = Nothing
            Dim GLReportTemplateID As Integer = 0
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

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each GLReportTemplateID In DataGridViewForm_GLReportTemplates.GetAllSelectedRowsBookmarkValues(0)

                        GLReportTemplate = AdvantageFramework.Database.Procedures.GLReportTemplate.Load(DbContext).Include("GLReportTemplateColumns").Include("GLReportTemplateRows").
                                                                                                                   Include("GLReportTemplateRows.GLReportTemplateRowRelations").Include("GLReportTemplateDepartmentTeamPresets").
                                                                                                                   Include("GLReportTemplateOfficePresets").Include("GLReportTemplatePctOfRowColumnRelations").
                                                                                                                   Where(Function(Entity) Entity.ID = GLReportTemplateID).SingleOrDefault

                        If GLReportTemplate IsNot Nothing Then

                            GLReportTemplateXML = New Database.Classes.GLReportTemplateXML(GLReportTemplate)

                            XMLString = CreateXML(GLReportTemplateXML, GetType(AdvantageFramework.Database.Classes.GLReportTemplateColumnXML),
                                                  GetType(AdvantageFramework.Database.Classes.GLReportTemplateRowXML), GetType(AdvantageFramework.Database.Classes.GLReportTemplateRowRelationXML),
                                                  GetType(AdvantageFramework.Database.Classes.GLReportTemplateDepartmentTeamPresetXML), GetType(AdvantageFramework.Database.Classes.GLReportTemplateOfficePresetXML),
                                                  GetType(AdvantageFramework.Database.Classes.GLReportTemplatePctOfRowColumnRelationXML))

                            My.Computer.FileSystem.WriteAllText(Folder & AdvantageFramework.FileSystem.CreateValidFileName(GLReportTemplate.Description) & ".xml", XMLString, False)

                            If GLReportTemplate.GLReportUserDefReportID.GetValueOrDefault(0) > 0 Then

                                GLReportUserDefReport = AdvantageFramework.Database.Procedures.GLReportUserDefReport.LoadByGLReportUserDefReportID(DbContext, GLReportTemplate.GLReportUserDefReportID)

                                If GLReportUserDefReport IsNot Nothing Then

                                    Try

                                        XtraReport = CreateUserDefinedReport(GLReportUserDefReport)

                                    Catch ex As Exception
                                        XtraReport = Nothing
                                    End Try

                                    If XtraReport IsNot Nothing Then

                                        XtraReport.SaveLayout(Folder & AdvantageFramework.FileSystem.CreateValidFileName(XtraReport.DisplayName) & ".repx")

                                    End If

                                End If

                            End If

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub ButtonItemTemplates_Import_Click(sender As Object, e As EventArgs) Handles ButtonItemTemplates_Import.Click

            If AdvantageFramework.Reporting.Presentation.GLReportTemplateImportForm.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
