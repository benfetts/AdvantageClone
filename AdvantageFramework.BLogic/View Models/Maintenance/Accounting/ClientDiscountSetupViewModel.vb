Namespace ViewModels.Maintenance.Accounting

    Public Class ClientDiscountSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property SaveEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property RefreshEnabled As Boolean

        Public Property ClientDiscounts As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount)
        Public Property SelectedClientDiscount As AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount

        Public ReadOnly Property HasASelectedClientDiscount As Boolean
            Get
                HasASelectedClientDiscount = (Me.SelectedClientDiscount IsNot Nothing)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.DeleteEnabled = False
            Me.RefreshEnabled = True

            Me.ClientDiscounts = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount)
            Me.SelectedClientDiscount = Nothing

        End Sub

#End Region

    End Class

End Namespace
