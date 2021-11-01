Namespace Database.Classes

    Public Class BroadcastOrderDetailVerification

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DetailID
            MediaType
            VendorCode
            VendorName
            Vendor
            MonthYear
            OrderNumber
            OrderLineNumber
            WeekOf
            RunDate
            RunTime
            RunDateTime
            DayOfWeek
            DayOfWeekNumber
            Length
            AdNumber
            NetworkID
            GrossRate
            VariantCodes
            Approved
            Comment
            IsLineNumberVerified
            IsRateVerified
            IsNetworkVerified
            IsScheduleVerified
            IsDayOfWeekVerified
            IsTimeVerified
            IsTimeSeparationVerified
            IsAdNumberVerified
            IsLengthVerified
            IsBookendVerified
            OrderMonthNumber
            OrderYearNumber
            EstimatedGRP
            ActualGRP
            RatingIndex
            EstimatedImpressions
            ActualImpressions
            ImpressionIndex
            Book
            ProgramName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DetailID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property MonthYear() As String
            Get
                If Me.OrderMonthNumber.HasValue AndAlso Me.OrderYearNumber.HasValue Then
                    MonthYear = MonthName(Me.OrderMonthNumber, True).ToUpper & Space(1) & Me.OrderYearNumber.ToString
                Else
                    MonthYear = Nothing
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line" & vbCrLf & "Number", PropertyType:=BaseClasses.Methods.PropertyTypes.BroadcastOrderLineNumber)>
        Public Property OrderLineNumber() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Week Of")>
        Public Property WeekOf() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RunDate() As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetworkID() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Day of" & vbCrLf & "Week")>
        Public Property DayOfWeek() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", ShowColumnInGrid:=False)>
        Public Property RunTime() As TimeSpan
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", CustomColumnCaption:="Run Time", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Time)>
        Public Property RunDateTime() As Date
            Get
                Return New Date(Now.Year, Now.Month, Now.Day, Me.RunTime.Hours, Me.RunTime.Minutes, 0)
            End Get
            Set(value As Date)
                Me.RunTime = New TimeSpan(value.Hour, value.Minute, 0)
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Rate")>
        Public Property GrossRate() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VariantCodes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.StandardCheckBox)>
        Public Property Approved() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Program" & vbCrLf & "Name")>
        Public Property ProgramName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Est RTG")>
        Public Property EstimatedGRP() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Act RTG")>
        Public Property ActualGRP() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", CustomColumnCaption:="RTG Index")>
        Public Property RatingIndex() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1", CustomColumnCaption:="Est GIMP" & vbCrLf & "(000)")>
        Public Property EstimatedImpressions() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n1", CustomColumnCaption:="Act GIMP" & vbCrLf & "(000)")>
        Public Property ActualImpressions() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0", CustomColumnCaption:="GIMP Index")>
        Public Property ImpressionIndex() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Book")>
        Public Property Book() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DayOfWeekNumber() As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsLineNumberVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsRateVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsNetworkVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsScheduleVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsDayOfWeekVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsTimeVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsTimeSeparationVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsAdNumberVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsLengthVerified() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsBookendVerified() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderMonthNumber As Short?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderYearNumber As Short?

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function
        Public Function GetAccountPayableBroadcastDetail(ByVal DbContext As AdvantageFramework.Database.DbContext) As Object

            'objects
            Dim AccountPayableRadioBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableRadioBroadcastDetail = Nothing
            Dim AccountPayableTVBroadcastDetail As AdvantageFramework.Database.Entities.AccountPayableTVBroadcastDetail = Nothing
            Dim AccountPayableBroadcastDetail As Object = Nothing

            Try

                If Me.MediaType = "Radio" Then

                    AccountPayableRadioBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableRadioBroadcastDetail.LoadByID(DbContext, Me.DetailID)

                    If AccountPayableRadioBroadcastDetail IsNot Nothing Then

                        With AccountPayableRadioBroadcastDetail

                            .OrderLineNumber = Me.OrderLineNumber
                            .IsApproved = Me.Approved
                            .Comment = Me.Comment

                        End With

                    End If

                    AccountPayableBroadcastDetail = AccountPayableRadioBroadcastDetail

                ElseIf Me.MediaType = "TV" Then

                    AccountPayableTVBroadcastDetail = AdvantageFramework.Database.Procedures.AccountPayableTVBroadcastDetail.LoadByID(DbContext, Me.DetailID)

                    If AccountPayableTVBroadcastDetail IsNot Nothing Then

                        With AccountPayableTVBroadcastDetail

                            .OrderLineNumber = Me.OrderLineNumber
                            .IsApproved = Me.Approved
                            .Comment = Me.Comment

                        End With

                    End If

                    AccountPayableBroadcastDetail = AccountPayableTVBroadcastDetail

                End If

            Catch ex As Exception
                AccountPayableBroadcastDetail = Nothing
            Finally
                GetAccountPayableBroadcastDetail = AccountPayableBroadcastDetail
            End Try

        End Function

#End Region

    End Class

End Namespace
