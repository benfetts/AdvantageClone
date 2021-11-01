Namespace DTO.Media

    Public Class NielsenRadioPeriod
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
			Description
			NielsenRadioMarketNumber
			Year
            Month
            Source
            MonthName
            SortMonth
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Description() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property NielsenRadioMarketNumber() As Integer
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property Year() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Month() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketDescription() As String
        '<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        'Public ReadOnly Property MonthName() As String
        '    Get
        '        Dim Result As String = Nothing
        '        Select Case Me.Month
        '            Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
        '                Result = DateAndTime.MonthName(Me.Month)
        '            Case 13
        '                Result = "Winter Quarterly"
        '            Case 14
        '                Result = "Spring Quarterly"
        '            Case 15
        '                Result = "Summer Quarterly"
        '            Case 16
        '                Result = "Fall Quarterly"
        '            Case 17
        '                Result = "Spring Quarterly"
        '            Case 18
        '                Result = "Spring Quarterly"
        '            Case 19
        '                Result = "Summer Quarterly"
        '            Case 21
        '                Result = "Spring Quarterly"
        '            Case 22
        '                Result = "Fall Quarterly"
        '            Case 23
        '                Result = "Holiday"
        '        End Select
        '        MonthName = Result
        '    End Get
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SourceName() As String
            Get
                If Me.Source = AdvantageFramework.Nielsen.Database.Entities.Methods.RadioSource.Nielsen Then
                    SourceName = AdvantageFramework.Nielsen.Database.Entities.Methods.RadioSource.Nielsen.ToString
                Else
                    SourceName = AdvantageFramework.Nielsen.Database.Entities.Methods.RadioSource.Eastlan.ToString
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Name As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SortMonth() As Short
            Get
                Dim Sort As Short = 0
                Select Case Me.Description.Substring(0, 3)
                    Case "Hol"
                        Sort = 17
                    Case "Dec"
                        Sort = 16
                    Case "Nov"
                        Sort = 15
                    Case "Oct"
                        Sort = 14
                    Case "Fal"
                        Sort = 13
                    Case "Sep"
                        Sort = 12
                    Case "Aug"
                        Sort = 11
                    Case "Jul"
                        Sort = 10
                    Case "Sum"
                        Sort = 9
                    Case "Jun"
                        Sort = 8
                    Case "May"
                        Sort = 7
                    Case "Apr"
                        Sort = 6
                    Case "Spr"
                        Sort = 5
                    Case "Mar"
                        Sort = 4
                    Case "Feb"
                        Sort = 3
                    Case "Jan"
                        Sort = 2
                    Case "Win"
                        Sort = 1
                End Select
                SortMonth = Sort
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Description = String.Empty
            Me.NielsenRadioMarketNumber = 0
            Me.Year = 0
            Me.Month = 0
            Me.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen
            Me.StartDate = Nothing
            Me.EndDate = Nothing

        End Sub
        Public Sub New(NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod, Optional Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market) = Nothing)

            Me.ID = NielsenRadioPeriod.ID

            'Me.Description = NielsenRadioPeriod.Name
            Me.NielsenRadioMarketNumber = NielsenRadioPeriod.NielsenRadioMarketNumber
            Me.Year = NielsenRadioPeriod.ShortName.Substring(2, 4).ToString
            Me.Month = NielsenRadioPeriod.ShortName.Substring(0, 2)
            Me.Source = NielsenRadioPeriod.Source
            Me.StartDate = NielsenRadioPeriod.StartDate
            Me.EndDate = NielsenRadioPeriod.EndDate
            Me.Name = NielsenRadioPeriod.Name

            Select Case Me.Month

                Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
                    Me.Description = DateAndTime.MonthName(Me.Month, True) & Me.Year.ToString.Substring(2)

                Case 13, 14, 15, 16, 17, 18, 19, 23
                    Me.Description = NielsenRadioPeriod.Name.Substring(0, 1).ToUpper & NielsenRadioPeriod.Name.Substring(1, 2).ToLower & Me.Year.ToString.Substring(2)

                Case 21
                    Me.Description = "Spr" & Me.Year.ToString.Substring(2) & "/" & "Fal" & (Me.Year - 1).ToString.Substring(2)

                Case 22
                    Me.Description = "Fal" & Me.Year.ToString.Substring(2) & "/" & "Spr" & Me.Year.ToString.Substring(2)

            End Select

            If Markets IsNot Nothing Then

                SetMarketDescription(Markets)

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub SetMarketDescription(Markets As Generic.List(Of AdvantageFramework.Database.Entities.Market))

            Select Case Me.Month

                Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
                    Me.Description = DateAndTime.MonthName(Me.Month, True) & Me.Year.ToString.Substring(2)

                Case 13, 14, 15, 16, 17, 18, 19, 23
                    Me.Description = Me.Name.Substring(0, 1).ToUpper & Me.Name.Substring(1, 2).ToLower & Me.Year.ToString.Substring(2)

                Case 21
                    Me.Description = "Spr" & Me.Year.ToString.Substring(2) & "/" & "Fal" & (Me.Year - 1).ToString.Substring(2)

                Case 22
                    Me.Description = "Fal" & Me.Year.ToString.Substring(2) & "/" & "Spr" & Me.Year.ToString.Substring(2)

            End Select

            If Markets IsNot Nothing Then

                If Me.Source = AdvantageFramework.Nielsen.Database.Entities.Methods.RadioSource.Nielsen Then

                    If Markets.Where(Function(M) IsNumeric(M.NielsenRadioCode) AndAlso M.NielsenRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.NielsenRadioCode) AndAlso M.NielsenRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    ElseIf Markets.Where(Function(M) IsNumeric(M.NielsenBlackRadioCode) AndAlso M.NielsenBlackRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.NielsenBlackRadioCode) AndAlso M.NielsenBlackRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    ElseIf Markets.Where(Function(M) IsNumeric(M.NielsenHispanicRadioCode) AndAlso M.NielsenHispanicRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.NielsenHispanicRadioCode) AndAlso M.NielsenHispanicRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    End If

                ElseIf Me.Source = AdvantageFramework.Nielsen.Database.Entities.Methods.RadioSource.Eastlan Then

                    If Markets.Where(Function(M) IsNumeric(M.EastlanRadioCode) AndAlso M.EastlanRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.EastlanRadioCode) AndAlso M.EastlanRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    ElseIf Markets.Where(Function(M) IsNumeric(M.EastlanBlackRadioCode) AndAlso M.EastlanBlackRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.EastlanBlackRadioCode) AndAlso M.EastlanBlackRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    ElseIf Markets.Where(Function(M) IsNumeric(M.EastlanHispanicRadioCode) AndAlso M.EastlanHispanicRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Count = 1 Then

                        Me.MarketDescription = Markets.Where(Function(M) IsNumeric(M.EastlanHispanicRadioCode) AndAlso M.EastlanHispanicRadioCode = Me.NielsenRadioMarketNumber AndAlso M.IsInactive.GetValueOrDefault(0) = 0).Single.Description

                    End If

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
