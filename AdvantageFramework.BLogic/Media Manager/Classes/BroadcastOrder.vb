Namespace MediaManager.Classes

    <Serializable()>
    Public Class BroadcastOrder
#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            ClientName
            DivisionName
            ProductionDescription
            CampaignName
            FlightDates
            MarketName
            Buyer
            OrderDescription
            NetGross
            VendorCode
            VendorName
            VendorRepCode1
            VendorRepCode2
            PrintDate
            AgencyComment
            AgencyCommentFontSize
            MaxRevision
            OrderLabel
            LocationHeader
            LocationFooter
            ShowShippingAddress
            PageHeaderLogoPath
            IncludeRep1
            RepLabel1
            IncludeRep2
            RepLabel2
            DefaultRep1Label
            DefaultRep2Label
            ExcludeEmployeeSignature
            OrderHeaderComment
            Cycle
            Programming
            Days
            AirTime
            Length
            CostRate
            StartWeek
            StartWeek2
            StartWeek3
            StartWeek4
            StartWeek5
            StartWeek6
            StartWeek7
            StartWeek8
            StartWeek9
            StartWeek10
            StartWeek11
            StartWeek12
            StartWeek13
            'NetChargeDescription
            'DiscountDescription
            ChargeTo

            SpotsWeek1
            SpotsWeek2
            SpotsWeek3
            SpotsWeek4
            SpotsWeek5
            SpotsWeek6
            SpotsWeek7
            SpotsWeek8
            SpotsWeek9
            SpotsWeek10
            SpotsWeek11
            SpotsWeek12
            SpotsWeek13
            TotalSpots
            OrderHeaderCommentOption
            BuyerEmployeeCode
            CableNetwork
            Daypart
            AddedValue
            Bookend
            Remarks
            LineNumber
            PrimaryRating
            PrimaryCPP
            Demographic
            SeparationPolicy
            MakeGoodNumber
            CreatedFromWorkSheet
            MaxWeekdate
            ShowNielsenCopyright
            ReportLineNumber
            PrimaryCPM
            PrimaryImpressions
            GRP
            Amount
            DisplayImpressions
            LineCancelled
            ClientAddress1
            ClientAddress2
            ClientCSZ
        End Enum

#End Region

#Region " Variables "

        Private _TotalSpots As Integer = 0
        Private _Amount As Decimal = 0

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderNumber As Integer = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductionDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FlightDates As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetGross As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode1 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorRepCode2 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDate As Nullable(Of Date) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AgencyComment As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek1 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek2 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek3 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek4 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek5 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek6 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek7 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek8 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek9 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek10 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek11 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek12 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SpotsWeek13 As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek As Nullable(Of Date) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Cycle As Nullable(Of Integer) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Programming As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Days As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AirTime As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Length As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostRate As Nullable(Of Decimal) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaxRevision As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderLabel As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationHeader As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationFooter As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalSpots As Integer
            Get
                TotalSpots = If(_TotalSpots <= 0, 0, _TotalSpots)
            End Get
            Set(value As Integer)
                _TotalSpots = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property NetChargeDescription As String = Nothing
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property DiscountDescription As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowShippingAddress As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ChargeTo As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeRep1 As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RepLabel1 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeRep2 As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RepLabel2 As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultRep1Label As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultRep2Label As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExcludeEmployeeSignature As Boolean = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderHeaderComment As String = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AgencyCommentFontSize As Nullable(Of Short) = Nothing
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek2 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek3 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek4 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek5 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek6 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek7 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek8 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek9 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek10 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek11 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek12 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartWeek13 As Date?
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderHeaderCommentOption As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BuyerEmployeeCode As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CableNetwork As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Daypart As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddedValue As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Bookend As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remarks As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrimaryRating As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrimaryCPP As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Demographic As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SeparationPolicy As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MakeGoodNumber As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreatedFromWorkSheet As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaxWeekdate As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowNielsenCopyright As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property ReportLineNumber As String
            Get
                ReportLineNumber = Me.LineNumber.ToString & If(Me.MakeGoodNumber.HasValue And Me.MakeGoodNumber.Value <> 0, "-" & Me.MakeGoodNumber.Value.ToString, "")
            End Get
        End Property

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrimaryCPM As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrimaryImpressions As Nullable(Of Long)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GRP As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Amount As Decimal
            Get
                Amount = If(_Amount < 0, 0, _Amount)
            End Get
            Set(value As Decimal)
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property CPP As Decimal
            Get
                CPP = If(Me.GRP = 0, 0, Me.Amount / Me.GRP)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property CPM As Decimal
            Get
                Dim TotalImpressions As Long = 0

                TotalImpressions = Me.TotalSpots * Me.PrimaryImpressions.GetValueOrDefault(0)

                If TotalImpressions = 0 Then

                    CPM = 0

                Else

                    CPM = Me.Amount / TotalImpressions * 1000

                End If

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property GrossImpressions As Long
            Get
                GrossImpressions = Me.TotalSpots * Me.PrimaryImpressions.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaType As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property DisplayImpressions As Decimal
            Get

                If Me.MediaType = "R" Then

                    DisplayImpressions = FormatNumber(Me.PrimaryImpressions.GetValueOrDefault(0) / 100, 0)

                Else

                    DisplayImpressions = FormatNumber(Me.PrimaryImpressions.GetValueOrDefault(0) / 1000, 1)

                End If

            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property TotalDisplayImpressions As Long
            Get
                TotalDisplayImpressions = Me.TotalSpots * Me.DisplayImpressions
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientAddress1 As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientAddress2 As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCity As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientState As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientZip As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property ClientCSZ As String
            Get
                If Trim(Me.ClientCity & ", " & Me.ClientState & Space(2) & Me.ClientZip & "") = "," Then
                    ClientCSZ = Nothing
                Else
                    ClientCSZ = Me.ClientCity & ", " & Me.ClientState & Space(2) & Me.ClientZip & ""
                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
