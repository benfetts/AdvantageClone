Namespace ViewModels.Reporting

    Public Class MediaTrafficInstructionsCriteriaViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property StartDate As Date
        Public Property EndDate As Date

        Public Property IncludeInactiveWorksheets As Boolean
        Public Property IncludeAllMediaTrafficRevisions As Boolean

        Public Property MediaBroadcastWorksheets As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Worksheet) = Nothing
        Public Property IsMissingInstructionsDataset As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            _StartDate = Now.ToString("MM/dd/yyyy")
            _EndDate = DateAdd(DateInterval.Day, 60, _StartDate).ToString("MM/dd/yyyy")

            _IncludeInactiveWorksheets = False

            _MediaBroadcastWorksheets = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)

            _IsMissingInstructionsDataset = False

        End Sub

#End Region

    End Class

End Namespace