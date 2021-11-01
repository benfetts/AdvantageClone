Namespace ViewModels.Media

    Public Class MediaRFPVendorDaypartCrossReferenceViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsNewRow As Boolean
        Public Property SaveEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public ReadOnly Property HasASelectedMediaRFPVendorDaypartCrossReference As Boolean
            Get
                HasASelectedMediaRFPVendorDaypartCrossReference = (Me.SelectedMediaRFPVendorDaypartCrossReference IsNot Nothing)
            End Get
        End Property

        Public Property SelectedMediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference

        Public Property RepositoryDaypartList As Generic.List(Of AdvantageFramework.DTO.Daypart)
        Public Property MediaRFPVendorDaypartCrossReferenceList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference)

#End Region

#Region " Methods "

        Public Sub New()

            RepositoryDaypartList = New Generic.List(Of AdvantageFramework.DTO.Daypart)
            MediaRFPVendorDaypartCrossReferenceList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference)

        End Sub

#End Region

    End Class

End Namespace