Namespace Database.Views

    <Table("V_BRDCAST_ORDER_DTL_VERIFICATION")>
    Public Class BroadcastOrderDetailVerificationView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            DetailID
            MediaType
            VendorCode
            VendorName
            Vendor
            MonthYear
            OrderNumber
            OrderLineNumber
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
            IsSpotsPositiveVerified
            IsSpotsNegativeVerified
            OrderMonthNumber
            OrderYearNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <Column("DetailID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DetailID() As Integer
        <Column("MediaType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=True, CustomColumnCaption:="Media" & vbCrLf & "Type")>
        Public Property MediaType() As String
        <Column("VendorCode", TypeName:="varchar")>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
        <Column("VendorName", TypeName:="varchar")>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorName() As String
        <Column("Vendor", TypeName:="varchar")>
        <MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Vendor() As String
        <NotMapped>
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
        <Column("OrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
        <Column("OrderLineNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line" & vbCrLf & "Number", PropertyType:=BaseClasses.Methods.PropertyTypes.BroadcastOrderLineNumber)>
        Public Property OrderLineNumber() As Short?
        <Column("RunDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RunDate() As Date
        <Column("RunTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", ShowColumnInGrid:=False)>
        Public Property RunTime() As TimeSpan
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", CustomColumnCaption:="Run Time", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Time)>
        Public Property RunDateTime() As Date
            Get
                Return New Date(Now.Year, Now.Month, Now.Day, Me.RunTime.Hours, Me.RunTime.Minutes, 0)
            End Get
            Set(value As Date)
                Me.RunTime = New TimeSpan(value.Hour, value.Minute, 0)
            End Set
        End Property
        <Column("DayOfWeek", TypeName:="varchar")>
        <MaxLength(2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Day of" & vbCrLf & "Week")>
        Public Property DayOfWeek() As String
        <Column("DayOfWeekNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DayOfWeekNumber() As Short?
        <Column("Length")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Length() As Short?
        <Column("AdNumber", TypeName:="varchar")>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
        <Column("NetworkID", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NetworkID() As String
        <Column("GrossRate")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property GrossRate() As Decimal
        <Column("VariantCodes", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VariantCodes() As String
        <Column("Approved")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.StandardCheckBox)>
        Public Property Approved() As Short?
        <Column("Comment", TypeName:="varchar")>
        <MaxLength(254)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
        <Column("IsLineNumberVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsLineNumberVerified() As Boolean
        <Column("IsRateVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsRateVerified() As Boolean
        <Column("IsNetworkVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsNetworkVerified() As Boolean
        <Column("IsScheduleVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsScheduleVerified() As Boolean
        <Column("IsDayOfWeekVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsDayOfWeekVerified() As Boolean
        <Column("IsTimeVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsTimeVerified() As Boolean
        <Column("IsTimeSeparationVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsTimeSeparationVerified() As Boolean
        <Column("IsAdNumberVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsAdNumberVerified() As Boolean
        <Column("IsLengthVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsLengthVerified() As Boolean
        <Column("IsSpotsPositiveVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsSpotsPositiveVerified() As Boolean
        <Column("IsSpotsNegativeVerified")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsSpotsNegativeVerified() As Boolean
        <Column("OrderMonthNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OrderMonthNumber As Short?
        <Column("OrderYearNumber")>
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
