Namespace Maintenance.Client.Presentation

    Public Class DivisionReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _SelectedDivisionCodes() As String = Nothing
        Private _AvailableDivisionCodes() As String = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal AvailableDivisionCodes() As String, ByVal SelectedDivisionCodes() As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _SelectedDivisionCodes = SelectedDivisionCodes
            _AvailableDivisionCodes = AvailableDivisionCodes

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Divisions.DataSource = Nothing

            If _ClientCode IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DataGridViewForm_Divisions.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, Me.Session.UserCode).Include("Client")
                                                                Where Entity.ClientCode = _ClientCode
                                                                Select Entity

                        DataGridViewForm_Divisions.CurrentView.BestFitColumns()

                    End Using

                End Using

            End If

        End Sub
        Private Sub SelectGridRows()

            If _SelectedDivisionCodes IsNot Nothing Then

                DataGridViewForm_Divisions.CurrentView.BeginSelection()

                DataGridViewForm_Divisions.CurrentView.ClearSelection()

                For Each DivisionCode In _SelectedDivisionCodes

                    DataGridViewForm_Divisions.SelectRow(2, DivisionCode, False)

                Next

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, Optional ByVal AvailableDivisionCodes() As String = Nothing, Optional ByVal SelectedDivisionCodes() As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim DivisionReportsDialog As AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog = Nothing

            DivisionReportsDialog = New AdvantageFramework.Maintenance.Client.Presentation.DivisionReportsDialog(ClientCode, AvailableDivisionCodes, SelectedDivisionCodes)

            ShowFormDialog = DivisionReportsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DivisionReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            DataGridViewForm_Divisions.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim DivisionCodes As String() = Nothing

            If Me.Validator Then

                If DataGridViewForm_Divisions.HasASelectedRow Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DivisionCodes = (From Entity In DataGridViewForm_Divisions.GetAllSelectedRowsBookmarkValues().OfType(Of String)()
                                         Select Entity).ToArray

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        ReportType = Reporting.ReportTypes.DivisionDetail

                        DivisionList = (From Entity In AdvantageFramework.Database.Procedures.Division.Load(DbContext).Include("Client")
                                        Where DivisionCodes.Contains(Entity.Code) AndAlso
                                              Entity.ClientCode = _ClientCode
                                        Select Entity
                                        Order By Entity.Code).ToList

                        If DivisionList IsNot Nothing AndAlso DivisionList.Count > 0 Then

                            ParameterList.Add("DataSource", DivisionList)

                            AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing)

                        End If

                    End Using

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select at least one division.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace