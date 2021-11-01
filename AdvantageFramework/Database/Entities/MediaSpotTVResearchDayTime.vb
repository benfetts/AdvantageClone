Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_RESEARCH_DAYTIME")>
    Public Class MediaSpotTVResearchDayTime
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVResearchID
            Monday
            Tuesday
            Wednesday
            Thursday
            Friday
            Saturday
            Sunday
            StartTime
            EndTime
            StartHour
            EndHour
            Days
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_DAYTIME_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVResearchID() As Integer
        <Required>
        <Column("MONDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Monday() As Boolean
        <Required>
        <Column("TUESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Tuesday() As Boolean
        <Required>
        <Column("WEDNESDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Wednesday() As Boolean
        <Required>
        <Column("THURSDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Thursday() As Boolean
        <Required>
        <Column("FRIDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Friday() As Boolean
        <Required>
        <Column("SATURDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Saturday() As Boolean
        <Required>
        <Column("SUNDAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Sunday() As Boolean
        <Required>
        <Column("START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartTime() As String
        <Required>
        <Column("END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndTime() As String
        <Required>
        <Column("START_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartHour() As Short
        <Required>
        <Column("END_HOUR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndHour() As Short
        <Required>
        <MaxLength(100)>
        <Column("DAYS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Days() As String

        <ForeignKey("MediaSpotTVResearchID")>
        Public Overridable Property MediaSpotTVResearch As Database.Entities.MediaSpotTVResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        'Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    'objects
        '    Dim ErrorText As String = ""
        '    'Dim PropertyValue As Object = Nothing
        '    Dim DaysValue As String = Nothing
        '    Dim CharPosition As Integer = 0
        '    Dim ValidDays As IEnumerable(Of String) = Nothing
        '    Dim DashPos As Integer = -1

        '    Select Case PropertyName

        '        Case AdvantageFramework.Database.Entities.MediaSpotTVResearchDayTime.Properties.Days.ToString

        '            If Value IsNot Nothing Then

        '                DaysValue = Replace(DirectCast(Value, String).ToUpper.Trim, " ", "")

        '                DashPos = InStr(DaysValue, "-")

        '                If DashPos > 0 AndAlso InStr(DaysValue, DashPos + 1) = 0 Then

        '                    ValidDays = {"M", "TU", "W", "TH", "F", "SA", "SU"}

        '                    If Not (ValidDays.Contains(Left(DaysValue, DashPos - 1)) AndAlso ValidDays.Contains(Mid(DaysValue, DashPos + 1))) Then

        '                        IsValid = False

        '                    End If

        '                Else

        '                    ValidDays = {"M", "T", "W", "F", "S", "-"}

        '                    CharPosition = 1

        '                    Do Until CharPosition > DaysValue.Length OrElse IsValid = False

        '                        If ValidDays.Contains(Mid(DaysValue, CharPosition, 1)) Then

        '                            Select Case Mid(DaysValue, CharPosition, 1)

        '                                Case "T"

        '                                    If DaysValue.Length >= CharPosition + 1 AndAlso (Mid(DaysValue, CharPosition + 1, 1) = "U" OrElse
        '                                                                                 Mid(DaysValue, CharPosition + 1, 1) = "H") Then

        '                                        CharPosition += 1

        '                                    Else

        '                                        IsValid = False

        '                                    End If

        '                                Case "S"

        '                                    If DaysValue.Length >= CharPosition + 1 AndAlso (Mid(DaysValue, CharPosition + 1, 1) = "A" OrElse
        '                                                                                 Mid(DaysValue, CharPosition + 1, 1) = "U") Then

        '                                        CharPosition += 1

        '                                    Else

        '                                        IsValid = False

        '                                    End If

        '                                Case Else

        '                            End Select

        '                        Else

        '                            IsValid = False

        '                        End If

        '                        CharPosition += 1

        '                    Loop

        '                End If

        '                If Not IsValid Then

        '                    ErrorText = "Invalid day(s) specified."

        '                ElseIf CountString("M", DaysValue) > 1 OrElse CountString("TU", DaysValue) > 1 OrElse CountString("W", DaysValue) > 1 OrElse CountString("TH", DaysValue) > 1 OrElse
        '                        CountString("F", DaysValue) > 1 OrElse CountString("SA", DaysValue) > 1 OrElse CountString("SU", DaysValue) > 1 OrElse
        '                        CountString("-", DaysValue) > 1 OrElse DaysValue.StartsWith("-") OrElse DaysValue.EndsWith("-") Then

        '                    IsValid = False

        '                    ErrorText = "Invalid day(s) specified."

        '                End If

        '            End If

        '    End Select

        '    ValidateCustomProperties = ErrorText

        'End Function
        'Public Function CountString(StringToBeSearchedInsideTheInputString As String, InputString As String) As Integer

        '    Return System.Text.RegularExpressions.Regex.Split(InputString, StringToBeSearchedInsideTheInputString).Length - 1

        'End Function

#End Region

    End Class

End Namespace
