Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketVendorOrderCommentsCopyToAnotherVendorViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CopyFromVendorCode As String

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarketDetailVendor
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarketDetailVendor As Boolean
            Get
                HasASelectedWorksheetMarketDetailVendor = (Me.WorksheetMarketDetailVendors IsNot Nothing AndAlso Me.WorksheetMarketDetailVendors.Where(Function(Entity) Entity.Selected = True).Count > 0)
            End Get
        End Property

        Public Property WorksheetMarketDetailVendors As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)

#End Region

#Region " Methods "

        Public Sub New()

            Me.CopyFromVendorCode = String.Empty

            Me.WorksheetMarketDetailVendors = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendor)

        End Sub

#End Region

    End Class

End Namespace
