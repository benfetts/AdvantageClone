Namespace ViewModels.Maintenance.Accounting

    Public Class SalesClassSetupViewModel

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
        Public Property SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)
        Public ReadOnly Property HasASelectedSalesClass As Boolean
            Get
                HasASelectedSalesClass = SelectedSalesClasses IsNot Nothing AndAlso SelectedSalesClasses.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedSalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

