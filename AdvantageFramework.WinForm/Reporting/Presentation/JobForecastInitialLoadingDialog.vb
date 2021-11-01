Namespace Reporting.Presentation

    Public Class JobForecastInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim JobForecastInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.JobForecastInitialLoadingDialog = Nothing

            JobForecastInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.JobForecastInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = JobForecastInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = JobForecastInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobForecastInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Years As Generic.List(Of Short) = Nothing
            Dim SearchDate As Date = Nothing

            ComboBoxForm_Month.SetRequired(True)
            ComboBoxForm_Year.SetRequired(True)

            Years = New Generic.List(Of Short)

            For I = (System.DateTime.Today.Year - 5) To (System.DateTime.Today.Year + 5)

                Years.Add(I)

            Next

            ComboBoxForm_Month.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months))
            ComboBoxForm_Year.DataSource = Years

            If _ParameterDictionary IsNot Nothing Then

                Try

                    SearchDate = _ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.SearchDate.ToString)

                Catch ex As Exception
                    SearchDate = Nothing
                End Try

                If SearchDate <> Nothing Then

                    Try

                        ComboBoxForm_Month.SelectedValue = SearchDate.Month

                    Catch ex As Exception

                    End Try

                    Try

                        ComboBoxForm_Year.SelectedValue = SearchDate.Year

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SearchDate As Date = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                SearchDate = New Date(ComboBoxForm_Year.SelectedValue, ComboBoxForm_Month.SelectedValue, 1)

                _ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.SearchDate.ToString) = SearchDate
                _ParameterDictionary(AdvantageFramework.Reporting.JobForecastParameters.BreakoutPostPeriods.ToString) = CheckBoxForm_BreakoutPostPeriods.Checked

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
