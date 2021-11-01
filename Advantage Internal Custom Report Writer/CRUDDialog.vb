Public Class CRUDDialog

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum [Type]
        AdvancedReportWriterReport
    End Enum

#End Region

#Region " Variables "

    Private _FormType As CRUDDialog.Type = CRUDDialog.Type.AdvancedReportWriterReport
    Private _IsSelecting As Boolean = False
    Private _ShowOnlyActiveObjects As Boolean = True
    Private _SelectedObjects As IEnumerable = Nothing
    Private _Title As String = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property SelectedObjects() As IEnumerable
        Get
            SelectedObjects = _SelectedObjects
        End Get
    End Property

#End Region

#Region " Methods "

    Private Sub New(ByVal FormType As AdvantageFramework.WinForm.Presentation.CRUDDialog.Type, ByVal IsSelecting As Boolean, ByVal ShowOnlyActiveObjects As Boolean, ByVal AllowMultiSelect As Boolean, ByVal Title As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _FormType = FormType
        _IsSelecting = IsSelecting
        _ShowOnlyActiveObjects = ShowOnlyActiveObjects
        DataGridViewForm_Objects.MultiSelect = AllowMultiSelect
        _Title = Title

    End Sub
    Private Sub SetupCRUD()

        Select Case _FormType

            Case Type.AdvancedReportWriterReport

                Me.Text = "Advanced Report Writer Reports"

                ButtonForm_Add.Visible = False
                ButtonForm_Edit.Visible = False
                ButtonForm_Delete.Visible = False

        End Select

        If _Title IsNot Nothing AndAlso _Title <> "" Then

            Me.Text = _Title

        End If

    End Sub
    Private Sub RefreshCRUD()

        Select Case _FormType

            Case Type.AdvancedReportWriterReport

                DataGridViewForm_Objects.ItemDescription = "Advanced Report Writer Report(s)"

                DataGridViewForm_Objects.DataSource = (From AdvancedReportWriterReport In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Reporting.AdvancedReportWriterReports)).OrderBy(Function(KeyValue) KeyValue.Value)
                                                       Select [ID] = AdvancedReportWriterReport.Key, _
                                                               [AdvancedReportWriterReport] = AdvancedReportWriterReport.Value _
                                                       Order By [AdvancedReportWriterReport]).ToList

                If DataGridViewForm_Objects.Columns("ID") IsNot Nothing Then

                    If DataGridViewForm_Objects.Columns("ID").Visible Then

                        DataGridViewForm_Objects.Columns("ID").Visible = False

                    End If

                End If

        End Select

        EnableButtons()

    End Sub
    Private Sub SelectRows()

        If DataGridViewForm_Objects.HasASelectedRow Then

            _SelectedObjects = DataGridViewForm_Objects.GetAllSelectedRowsDataBoundItems

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub
    Private Sub EnableButtons()

        ButtonForm_Edit.Enabled = DataGridViewForm_Objects.HasASelectedRow
        ButtonForm_Delete.Enabled = DataGridViewForm_Objects.HasASelectedRow
        ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

        ButtonForm_Edit.Enabled = Not DataGridViewForm_Objects.HasMultipleSelectedRows
        ButtonForm_Delete.Enabled = Not DataGridViewForm_Objects.HasMultipleSelectedRows

    End Sub

#Region "  Show Form Methods "

    Public Shared Function ShowFormDialog(ByVal FormType As CRUDDialog.Type, ByVal IsSelecting As Boolean, ByVal ShowOnlyActiveObjects As Boolean, Optional ByRef SelectedObjects As IEnumerable = Nothing, Optional ByVal AllowMultiSelect As Boolean = True, Optional ByVal Title As String = Nothing) As Windows.Forms.DialogResult

        'objects
        Dim CRUDDialog As CRUDDialog = Nothing

        CRUDDialog = New CRUDDialog(FormType, IsSelecting, ShowOnlyActiveObjects, AllowMultiSelect, Title)

        ShowFormDialog = CRUDDialog.ShowDialog()

        If IsSelecting Then

            SelectedObjects = CRUDDialog.SelectedObjects

        End If

    End Function

#End Region

#Region "  Form Event Handlers "

    Private Sub CRUDDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.ShowUnsavedChangesOnFormClosing = False

        If _IsSelecting Then

            ButtonForm_Select.Visible = True
            ButtonForm_Cancel.Visible = True
            ButtonForm_Close.Visible = False

        Else

            ButtonForm_Select.Visible = False
            ButtonForm_Cancel.Visible = False
            ButtonForm_Close.Visible = True

        End If

        SetupCRUD()

        RefreshCRUD()

        DataGridViewForm_Objects.CurrentView.BestFitColumns()

        If _ShowOnlyActiveObjects Then

            If DataGridViewForm_Objects.Columns("IsInactive") IsNot Nothing Then

                If DataGridViewForm_Objects.Columns("IsInactive").Visible Then

                    DataGridViewForm_Objects.Columns("IsInactive").Visible = False

                End If

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub DataGridViewForm_Objects_RowDoubleClickEvent() Handles DataGridViewForm_Objects.RowDoubleClickEvent

        If _IsSelecting Then

            SelectRows()

        Else

            ButtonForm_Edit.PerformClick()

        End If

    End Sub
    Private Sub DataGridViewForm_Objects_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Objects.SelectionChangedEvent

        EnableButtons()

    End Sub
    Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub ButtonForm_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Select.Click

        SelectRows()

    End Sub

#End Region

#End Region

End Class
