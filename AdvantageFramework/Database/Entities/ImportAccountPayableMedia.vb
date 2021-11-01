Namespace Database.Entities

	<Table("IMP_AP_MEDIA")>
	Public Class ImportAccountPayableMedia
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ImportAccountPayableID
			MediaType
			OrderID
			OrderNumber
			Month
			Year
			SalesClassCode
			OrderLineNumber
			LineDate
			MediaQuantity
			MediaNetAmount
			MediaVendorTax
			MediaNetCharge
			MediaMarkupPercent
			MediaAddAmount
			ID
			ClientCode
			ClientName
			DivisionCode
			DivisionName
			ProductCode
			ProductName
			OfficeCodeDetail
			PreviouslyPostedNetAmount
			OrderNetAmount
			OrderNetVariance
			IsLegacyBroadcastOrder
			OrderLineID
			DaypartCode
			Length
            DaypartID
            DaysOfWeek
            StartTime
            EndTime
            RateDetail
            LineStartDate
            LineEndDate
            PlanCode
            PackageCode
            CampaignID
            Comment
            ImportAccountPayable
			ImportAccountPayableErrors
            Daypart
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableID() As Integer
		<MaxLength(2)>
		<Column("MEDIA_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaType() As String
		<Column("ORDER_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderID() As Nullable(Of Integer)
		<Column("ORDER_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<MaxLength(3)>
		<Column("MONTH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Month() As String
		<Column("YEAR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Year() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("SALES_CLASS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SalesClassCode() As String
		<Column("ORDER_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineNumber() As Nullable(Of Short)
		<Column("LINE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 2)>
        <Column("MEDIA_QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaQuantity() As Nullable(Of Decimal)
        <Column("MEDIA_GROSS_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property MediaGrossRate() As Nullable(Of Decimal)
        <Column("MEDIA_NET_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(16, 4)>
        Public Property MediaNetRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("MEDIA_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("MEDIA_VN_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaVendorTax() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("MEDIA_NET_CHARGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaNetCharge() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("MEDIA_MARKUP_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaMarkupPercent() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("MEDIA_ADD_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaAddAmount() As Nullable(Of Decimal)
		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(40)>
		<Column("CLIENT_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientName() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(40)>
		<Column("DIVISION_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionName() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(40)>
		<Column("PRODUCT_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductName() As String
		<MaxLength(4)>
		<Column("OFFICE_CODE_DTL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCodeDetail() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("PREV_POSTED_NET_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PreviouslyPostedNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ORDER_NET_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OrderNetAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("ORDER_NET_VARIANCE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNetVariance() As Nullable(Of Decimal)
		<Required>
		<Column("IS_BROADCAST_LEGACY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsLegacyBroadcastOrder() As Boolean
		<Column("ORDER_LINE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineID() As Nullable(Of Integer)
		<MaxLength(6)>
		<Column("DAYPART_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DaypartCode() As String
		<Column("LENGTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Length() As Nullable(Of Integer)
		<Column("DAY_PART_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DaypartID() As Nullable(Of Integer)
        <Column("DAYS_OF_WEEK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DaysOfWeek() As String
        <Column("START_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartTime() As TimeSpan?
        <Column("END_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndTime() As TimeSpan?
        <Column("RATE_DETAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RateDetail() As String
        <Column("LINE_START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineStartDate() As Date?
        <Column("LINE_END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineEndDate() As Date?
        <Column("PLAN_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PlanCode() As String
        <Column("PACKAGE_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PackageCode() As String
        <Column("COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As Nullable(Of Integer)

        <NotMapped>
        Public ReadOnly Property Monday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 0 AndAlso {"M", "Y"}.Contains(Me.DaysOfWeek.Substring(0, 1)) Then
                    Monday = True
                Else
                    Monday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Tuesday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 1 AndAlso {"T", "Y"}.Contains(Me.DaysOfWeek.Substring(1, 1)) Then
                    Tuesday = True
                Else
                    Tuesday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Wednesday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 2 AndAlso {"W", "Y"}.Contains(Me.DaysOfWeek.Substring(2, 1)) Then
                    Wednesday = True
                Else
                    Wednesday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Thursday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 3 AndAlso {"T", "Y"}.Contains(Me.DaysOfWeek.Substring(3, 1)) Then
                    Thursday = True
                Else
                    Thursday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Friday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 4 AndAlso {"F", "Y"}.Contains(Me.DaysOfWeek.Substring(4, 1)) Then
                    Friday = True
                Else
                    Friday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Saturday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 5 AndAlso {"S", "Y"}.Contains(Me.DaysOfWeek.Substring(5, 1)) Then
                    Saturday = True
                Else
                    Saturday = False
                End If
            End Get
        End Property
        <NotMapped>
        Public ReadOnly Property Sunday As Boolean
            Get
                If String.IsNullOrWhiteSpace(Me.DaysOfWeek) = False AndAlso Me.DaysOfWeek.Length > 6 AndAlso {"S", "Y"}.Contains(Me.DaysOfWeek.Substring(6, 1)) Then
                    Sunday = True
                Else
                    Sunday = False
                End If
            End Get
        End Property

        <ForeignKey("ImportAccountPayableID")>
        Public Overridable Property ImportAccountPayable As Database.Entities.ImportAccountPayable

        <ForeignKey("DaypartID")>
        Public Overridable Property Daypart As Database.Entities.Daypart

        Public Overridable Property ImportAccountPayableErrors As ICollection(Of Database.Entities.ImportAccountPayableError)
        Public Overridable Property ImportAccountPayableBroadcastDetails As ICollection(Of Database.Entities.ImportAccountPayableBroadcastDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ImportAccountPayableID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.ImportAccountPayableMedia

            Dim EntityCopy As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.ImportAccountPayableMedia

            With EntityCopy
                .ImportAccountPayableID = Me.ImportAccountPayableID
                .MediaType = Me.MediaType
                .OrderID = Me.OrderID
                .OrderNumber = Me.OrderNumber
                .Month = Me.Month
                .Year = Me.Year
                .SalesClassCode = Me.SalesClassCode
                .OrderLineNumber = Me.OrderLineNumber
                .LineDate = Me.LineDate
                .MediaQuantity = Me.MediaQuantity
                .MediaGrossRate = Me.MediaGrossRate
                .MediaNetRate = Me.MediaNetRate
                .MediaNetAmount = Me.MediaNetAmount
                .MediaVendorTax = Me.MediaVendorTax
                .MediaNetCharge = Me.MediaNetCharge
                .MediaMarkupPercent = Me.MediaMarkupPercent
                .MediaAddAmount = Me.MediaAddAmount
                .ID = Me.ID
                .ClientCode = Me.ClientCode
                .ClientName = Me.ClientName
                .DivisionCode = Me.DivisionCode
                .DivisionName = Me.DivisionName
                .ProductCode = Me.ProductCode
                .ProductName = Me.ProductName
                .OfficeCodeDetail = Me.OfficeCodeDetail
                .PreviouslyPostedNetAmount = Me.PreviouslyPostedNetAmount
                .OrderNetAmount = Me.OrderNetAmount
                .OrderNetVariance = Me.OrderNetVariance
                .IsLegacyBroadcastOrder = Me.IsLegacyBroadcastOrder
                .OrderLineID = Me.OrderLineID
                .Length = Me.Length
                .DaypartID = Me.DaypartID
            End With

            Copy = EntityCopy

        End Function
        Public Sub New()

            Me.ImportAccountPayableBroadcastDetails = New HashSet(Of Database.Entities.ImportAccountPayableBroadcastDetail)

        End Sub

#End Region

    End Class

End Namespace
