Namespace DTO.Media

    Public Class SpotMatchingSetting
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            VerifyRate
            VerifyNetwork
            VerifySchedule
            VerifyDay
            VerifyTime
            VerifyTimeSep
            VerifyAdNumber
            VerifyLength
            AdjacencyBefore
            AdjacencyAfter
            BookendMaxSeparation
            MediaTypeCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        '<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        'Public Property MediaBroadcastWorksheetID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client" & vbCrLf & "Code")>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Gross" & vbCrLf & "Rate")>
        Public Property VerifyRate() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Network")>
        Public Property VerifyNetwork() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Schedule" & vbCrLf & "Dates")>
        Public Property VerifySchedule() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Day of" & vbCrLf & "Week")>
        Public Property VerifyDay() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Time" & vbCrLf & "of Day")>
        Public Property VerifyTime() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Time" & vbCrLf & "Separation")>
        Public Property VerifyTimeSep() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Ad" & vbCrLf & "Number")>
        Public Property VerifyAdNumber() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Length")>
        Public Property VerifyLength() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", CustomColumnCaption:="Adjacency" & vbCrLf & "Before", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyBefore() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", CustomColumnCaption:="Adjacency" & vbCrLf & "After", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyAfter() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", CustomColumnCaption:="Bookend Max" & vbCrLf & "Separation", UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=5)>
        Public Property BookendMaxSeparation() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTypeCode() As String

        Public Overridable Property TimeSeparationSettings As Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)

#End Region

#Region " Methods "

        Public Sub New()

            TimeSeparationSettings = New List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)

        End Sub
        Public Sub New(MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)

            Me.New

            Me.ID = MediaBroadcastWorksheetSpotMatchingSetting.ID
            Me.VerifyRate = MediaBroadcastWorksheetSpotMatchingSetting.VerifyRate
            Me.VerifyNetwork = MediaBroadcastWorksheetSpotMatchingSetting.VerifyNetwork
            Me.VerifySchedule = MediaBroadcastWorksheetSpotMatchingSetting.VerifySchedule
            Me.VerifyDay = MediaBroadcastWorksheetSpotMatchingSetting.VerifyDay
            Me.VerifyTime = MediaBroadcastWorksheetSpotMatchingSetting.VerifyTime
            Me.VerifyTimeSep = MediaBroadcastWorksheetSpotMatchingSetting.VerifyTimeSep
            Me.VerifyAdNumber = MediaBroadcastWorksheetSpotMatchingSetting.VerifyAdNumber
            Me.VerifyLength = MediaBroadcastWorksheetSpotMatchingSetting.VerifyLength
            Me.AdjacencyBefore = MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyBefore
            Me.AdjacencyAfter = MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyAfter
            Me.BookendMaxSeparation = MediaBroadcastWorksheetSpotMatchingSetting.BookendMaxSeparation

            Me.MediaTypeCode = MediaBroadcastWorksheetSpotMatchingSetting.MediaBroadcastWorksheet.MediaTypeCode

            For Each MediaBroadcastWorksheetTimeSeparationSetting In MediaBroadcastWorksheetSpotMatchingSetting.MediaBroadcastWorksheetTimeSeparationSettings

                Me.TimeSeparationSettings.Add(New AdvantageFramework.DTO.Media.TimeSeparationSetting(MediaBroadcastWorksheetTimeSeparationSetting))

            Next

        End Sub
        Public Sub New(InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting)

            Me.New

            Me.ID = InvoiceMatchingSetting.ID
            Me.VerifyRate = InvoiceMatchingSetting.VerifyRate
            Me.VerifyNetwork = InvoiceMatchingSetting.VerifyNetwork
            Me.VerifySchedule = InvoiceMatchingSetting.VerifySchedule
            Me.VerifyDay = InvoiceMatchingSetting.VerifyDay
            Me.VerifyTime = InvoiceMatchingSetting.VerifyTime
            Me.VerifyTimeSep = InvoiceMatchingSetting.VerifyTimeSep
            Me.VerifyAdNumber = InvoiceMatchingSetting.VerifyAdNumber
            Me.VerifyLength = InvoiceMatchingSetting.VerifyLength
            Me.AdjacencyBefore = InvoiceMatchingSetting.AdjacencyBefore
            Me.AdjacencyAfter = InvoiceMatchingSetting.AdjacencyAfter
            Me.BookendMaxSeparation = InvoiceMatchingSetting.BookendMaxSeparation

            Me.MediaTypeCode = InvoiceMatchingSetting.MediaTypeCode
            Me.ClientCode = InvoiceMatchingSetting.ClientCode

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting)

            MediaBroadcastWorksheetSpotMatchingSetting.VerifyRate = Me.VerifyRate
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyNetwork = Me.VerifyNetwork
            MediaBroadcastWorksheetSpotMatchingSetting.VerifySchedule = Me.VerifySchedule
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyDay = Me.VerifyDay
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyTime = Me.VerifyTime
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyTimeSep = Me.VerifyTimeSep
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyAdNumber = Me.VerifyAdNumber
            MediaBroadcastWorksheetSpotMatchingSetting.VerifyLength = Me.VerifyLength
            MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyBefore = Me.AdjacencyBefore
            MediaBroadcastWorksheetSpotMatchingSetting.AdjacencyAfter = Me.AdjacencyAfter
            MediaBroadcastWorksheetSpotMatchingSetting.BookendMaxSeparation = Me.BookendMaxSeparation

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
