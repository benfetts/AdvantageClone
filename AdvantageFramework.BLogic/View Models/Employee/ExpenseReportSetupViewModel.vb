Namespace ViewModels.Employee

    Public Class ExpenseReportSetupViewModel

        'Public Event SelectionChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property ExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)
        Public ReadOnly Property HasASelectedExpenseReport As Boolean
            Get
                HasASelectedExpenseReport = SelectedExpenseReports IsNot Nothing AndAlso SelectedExpenseReports.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

