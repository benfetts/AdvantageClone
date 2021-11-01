Namespace Media.Presentation

    Public Class BroadcastResearchBooksDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ShowBookType
            TV
            Radio
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.BroadcastResearchController = Nothing
        Private _ShowBook As ShowBookType = ShowBookType.TV

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ShowBook As ShowBookType)

            ' This call is required by the designer.
            InitializeComponent()

            _ShowBook = ShowBook

        End Sub
        Private Sub LoadViewModel()

            If _ShowBook = ShowBookType.TV Then

                _ViewModel = _Controller.AvailableBooks_LoadTV()

                DataGridViewForm_AvailableBooks.CurrentView.ObjectType = GetType(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                DataGridViewForm_AvailableBooks.DataSource = (From Entity In _ViewModel.AvailableBooks_NielsenTVBooks.OrderBy(Function(E) E.MarketDescription).ThenByDescending(Function(E) E.Year).ThenByDescending(Function(E) E.Month).ThenBy(Function(E) E.Stream)
                                                              Select New With {.NielsenMarketNumber = Entity.NielsenMarketNumber,
                                                                               .MarketDescription = Entity.MarketDescription,
                                                                               .MonthName = Entity.MonthName,
                                                                               .Year = Entity.Year,
                                                                               .Stream = Entity.Stream & If(Entity.ReportingService = "7" AndAlso Entity.Stream.EndsWith("-IM") = False, "-IM", ""),
                                                                               .Month = Entity.Month}).ToList

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.NielsenMarketNumber.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.NielsenMarketNumber.ToString).Caption = "Nielsen Mkt #"

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.MonthName.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.MonthName.ToString).Caption = "Month"

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.Month.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook.Properties.Month.ToString).Visible = False

                End If

            ElseIf _ShowBook = ShowBookType.Radio Then

                _ViewModel = _Controller.AvailableBooks_LoadRadio()

                DataGridViewForm_AvailableBooks.CurrentView.ObjectType = GetType(AdvantageFramework.DTO.Media.NielsenRadioPeriod)

                DataGridViewForm_AvailableBooks.DataSource = (From Entity In _ViewModel.AvailableBooks_NielsenRadioPeriods
                                                              Select Entity.NielsenRadioMarketNumber, Entity.MarketDescription, Entity.Description, Entity.Year, Entity.SourceName, Entity.Month, Entity.SortMonth).OrderBy(Function(E) E.MarketDescription).ThenByDescending(Function(E) E.Year).ThenByDescending(Function(E) E.SortMonth).ToList

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.NielsenRadioMarketNumber.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.NielsenRadioMarketNumber.ToString).Caption = "Nielsen Mkt #"

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.MonthName.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.MonthName.ToString).Caption = "Month"

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.Month.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.Month.ToString).Visible = False

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.Year.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.Year.ToString).Visible = False

                End If

                If DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.SortMonth.ToString) IsNot Nothing Then

                    DataGridViewForm_AvailableBooks.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.SortMonth.ToString).Visible = False

                End If

            End If

            DataGridViewForm_AvailableBooks.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ShowBook As ShowBookType) As System.Windows.Forms.DialogResult

            'objects
            Dim BroadcastResearchBooksDialog As BroadcastResearchBooksDialog = Nothing

            BroadcastResearchBooksDialog = New BroadcastResearchBooksDialog(ShowBook)

            ShowFormDialog = BroadcastResearchBooksDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastResearchBooksDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.BroadcastResearchController(Me.Session)

        End Sub
        Private Sub BroadcastResearchBooksDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
