Namespace ViewModels.Maintenance.Accounting

    Public Class ClientDiscountViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AllowCodeEdit As Boolean
        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property DeleteEnabled As Boolean

        Public Property ClientDiscountExclusions_IsNewRow As Boolean
        Public Property ClientDiscountExclusions_DeleteEnabled As Boolean
        Public Property ClientDiscountExclusions_CancelEnabled As Boolean

        Public Property ClientDiscount As AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount
        Public Property ClientDiscountExclusions As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion)
        Public Property SelectedClientDiscountExclusions As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion)

        Public ReadOnly Property HasASelectedClientDiscountExclusion As Boolean
            Get
                HasASelectedClientDiscountExclusion = (Me.SelectedClientDiscountExclusions IsNot Nothing AndAlso Me.SelectedClientDiscountExclusions.Count > 0)
            End Get
        End Property

        Public Property Functions As Generic.List(Of AdvantageFramework.DTO.Function)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AllowCodeEdit = False
            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.DeleteEnabled = False

            Me.ClientDiscountExclusions_IsNewRow = False
            Me.ClientDiscountExclusions_DeleteEnabled = False
            Me.ClientDiscountExclusions_CancelEnabled = False

            Me.ClientDiscount = Nothing
            Me.ClientDiscountExclusions = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion)
            Me.SelectedClientDiscountExclusions = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion)

            Me.Functions = New Generic.List(Of AdvantageFramework.DTO.Function)

        End Sub

#End Region

    End Class

End Namespace
