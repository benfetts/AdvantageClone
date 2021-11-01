Namespace DTO.Media.SpotTV

    Public Class NielsenTVBook
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Description
            Year
            Month
            Stream
            FullStreamName
            StreamSort
            StartDateTime
            EndDateTime
            MonthName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NielsenMarketNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Month() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Stream() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property FullStreamName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property StreamSort() As Short
            Get

                Dim SortOrder As Short = 0

                Select Case Me.Stream

                    Case "LO"

                        SortOrder = 1

                    Case "LS"

                        SortOrder = 2

                    Case "L1"

                        SortOrder = 3

                    Case "L3"

                        SortOrder = 4

                    Case "L7"

                        SortOrder = 5

                End Select

                StreamSort = SortOrder

            End Get
        End Property
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDateTime() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDateTime() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ReportingService() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MonthName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CollectionMethod() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Ethnicity() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Exclusion() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RawStream() As String

#End Region

#Region " Methods "

        Private Function AppendToStream(NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook) As String

            AppendToStream = If(NielsenTVBook.ReportingService = "7", "-IM", "") & If(NielsenTVBook.Ethnicity.ToUpper = "HISP", "-H", "") &
                If(NielsenTVBook.Ethnicity.ToUpper = "AF-AM", "-B", "") & If(NielsenTVBook.Ethnicity.ToUpper = "ASIAN", "-A", "") &
                If(NielsenTVBook.Exclusion = "EX", "-OL", "")

        End Function

        Public Sub New()



        End Sub
        Public Sub New(NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook, Optional Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing)

            Me.RawStream = NielsenTVBook.Stream

            Select Case NielsenTVBook.Stream

                Case "LO"

                    Me.FullStreamName = "Live"
                    Me.Stream = "L" & AppendToStream(NielsenTVBook)

                Case "LS"

                    Me.FullStreamName = "Live Same Day"
                    Me.Stream = "LS" & AppendToStream(NielsenTVBook)

                Case "L1"

                    Me.FullStreamName = "Live+1"
                    Me.Stream = "L1" & AppendToStream(NielsenTVBook)

                Case "L3"

                    Me.FullStreamName = "Live+3"
                    Me.Stream = "L3" & AppendToStream(NielsenTVBook)

                Case "L7"

                    Me.FullStreamName = "Live+7"
                    Me.Stream = "L7" & AppendToStream(NielsenTVBook)

            End Select

            Me.ID = NielsenTVBook.ID
            Me.NielsenMarketNumber = NielsenTVBook.NielsenMarketNumber

            Me.Year = NielsenTVBook.Year.ToString.Substring(2)
            Me.Month = NielsenTVBook.Month
            Me.StartDateTime = NielsenTVBook.StartDateTime
            Me.EndDateTime = NielsenTVBook.EndDateTime
            Me.ReportingService = NielsenTVBook.ReportingService

            Me.MonthName = DateAndTime.MonthName(Me.Month, True)

            Me.Description = DateAndTime.MonthName(NielsenTVBook.Month, True) & Me.Year & "-" & Me.Stream

            If Markets IsNot Nothing AndAlso Markets.Where(Function(M) IsNumeric(M.NielsenTVCode) AndAlso M.NielsenTVCode = NielsenTVBook.NielsenMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.NielsenTVCode) AndAlso M.NielsenTVCode = NielsenTVBook.NielsenMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

            End If

            Me.CollectionMethod = NielsenTVBook.CollectionMethod
            Me.Ethnicity = NielsenTVBook.Ethnicity
            Me.Exclusion = NielsenTVBook.Exclusion

        End Sub
        Public Sub New(ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook)

            Me.RawStream = ComscoreTVBook.Stream

            Select Case ComscoreTVBook.Stream

                Case "LO"

                    Me.FullStreamName = "Live"
                    Me.Stream = "L"

                Case "LS"

                    Me.FullStreamName = "Live Same Day"
                    Me.Stream = "LS"

                Case "L1"

                    Me.FullStreamName = "Live+1"
                    Me.Stream = "L1"

                Case "L3"

                    Me.FullStreamName = "Live+3"
                    Me.Stream = "L3"

                Case "L7"

                    Me.FullStreamName = "Live+7"
                    Me.Stream = "L7"

            End Select

            Me.ID = ComscoreTVBook.ID
            'Me.NielsenMarketNumber = NielsenTVBook.NielsenMarketNumber

            Me.Year = ComscoreTVBook.Year.ToString.Substring(2)
            Me.Month = ComscoreTVBook.Month
            Me.StartDateTime = ComscoreTVBook.StartDateTime
            Me.EndDateTime = ComscoreTVBook.EndDateTime

            Me.MonthName = DateAndTime.MonthName(Me.Month, True)

            Me.Description = DateAndTime.MonthName(ComscoreTVBook.Month, True) & Me.Year.ToString & "-" & Me.Stream

            Me.Ethnicity = String.Empty
            Me.Exclusion = String.Empty

        End Sub
        Public Sub SetMarketDescription(Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market))

            If Markets IsNot Nothing AndAlso Markets.Where(Function(M) IsNumeric(M.NielsenTVCode) AndAlso M.NielsenTVCode = Me.NielsenMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.NielsenTVCode) AndAlso M.NielsenTVCode = Me.NielsenMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

            End If

        End Sub

#End Region

    End Class

End Namespace
