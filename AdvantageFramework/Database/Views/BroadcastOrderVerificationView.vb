Namespace Database.Views

    <Table("V_BRDCAST_ORDER_VERIFICATION")>
    Public Class BroadcastOrderVerificationView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaType
            VendorCode
            VendorName
            Vendor
            OrderNumber
            OrderLineNumber
            RevisionNumber
            SequenceNumber
            StartDate
            EndDate
            StartTime
            EndTime
            StartDateTime
            EndDateTime
            DaysOfWeek
            Length
            AdNumber
            NetworkID
            GrossRate
            Spots
            ActualSpots
            MatchedSpots
            VariantCodes
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
        <Column("OrderNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Order" & vbCrLf & "Number")>
        Public Property OrderNumber() As Integer
        <Column("OrderLineNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Line" & vbCrLf & "Number")>
        Public Property OrderLineNumber() As Short?
        <Column("RevisionNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RevisionNumber() As Short
        <Column("SequenceNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
        <Column("StartDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Column("EndDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Column("StartTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", ShowColumnInGrid:=False)>
        Public Property StartTime() As TimeSpan?
        <Column("EndTime")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", ShowColumnInGrid:=False)>
        Public Property EndTime() As TimeSpan?
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", CustomColumnCaption:="Start Time", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Time)>
        Public Property StartDateTime As Date?
            Get
                If Me.StartTime.HasValue Then
                    Return New Date(Now.Year, Now.Month, Now.Day, Me.StartTime.Value.Hours, Me.StartTime.Value.Minutes, 0)
                Else
                    Return Nothing
                End If
            End Get
            Set(value As Date?)
                If value.HasValue Then
                    Me.StartTime = New TimeSpan(0, value.Value.Hour, value.Value.Minute, 0, 0)
                Else
                    Me.StartTime = Nothing
                End If
            End Set
        End Property
        <NotMapped>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="t", CustomColumnCaption:="End Time", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Time)>
        Public Property EndDateTime As Date?
            Get
                If Me.EndTime.HasValue Then
                    Return New Date(Now.Year, Now.Month, Now.Day, Me.EndTime.Value.Hours, Me.EndTime.Value.Minutes, 0)
                Else
                    Return Nothing
                End If
            End Get
            Set(value As Date?)
                If value.HasValue Then
                    Me.EndTime = New TimeSpan(0, value.Value.Hour, value.Value.Minute, 0, 0)
                Else
                    Me.EndTime = Nothing
                End If
            End Set
        End Property
        <Column("DaysOfWeek", TypeName:="varchar")>
        <MaxLength(20)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaysOfWeek() As String
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
        <Column("Spots")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ordered" & vbCrLf & "Spots")>
        Public Property Spots() As Integer?
        <Column("ActualSpots")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Actual" & vbCrLf & "Spots")>
        Public Property ActualSpots() As Integer?
        <Column("MatchedSpots")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Matched" & vbCrLf & "Spots")>
        Public Property MatchedSpots() As Integer?
        <Column("VariantCodes", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VariantCodes() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
