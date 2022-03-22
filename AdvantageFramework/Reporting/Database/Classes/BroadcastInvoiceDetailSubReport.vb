Option Strict On

Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BroadcastInvoiceDetailSubReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Line
            Days
            Times
            Program
            AdNumber
            DPLength
            Rate
            Date1
            Date2
            Date3
            Date4
            Date5
            Spots1
            Spots2
            Spots3
            Spots4
            Spots5
            TotalSpots
            IsApproved
            IsOrdered
            OrderedSpots1
            OrderedSpots2
            OrderedSpots3
            OrderedSpots4
            OrderedSpots5
            OrderedSpotsTotal
            ApprovedSpots1
            ApprovedSpots2
            ApprovedSpots3
            ApprovedSpots4
            ApprovedSpots5
            ApprovedSpotsTotal
            MissedSpots1
            MissedSpots2
            MissedSpots3
            MissedSpots4
            MissedSpots5
            MissedSpotsTotal
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property Line As Nullable(Of Integer)
        Public Property Days As String
        Public Property Times As String
        Public Property Program As String
        Public Property AdNumber As String
        Public Property DPLength As String
        Public Property Rate As Nullable(Of Decimal)
        Public Property VariantCode As String
        Public Property Date1 As Nullable(Of Date)
        Public Property Date2 As Nullable(Of Date)
        Public Property Date3 As Nullable(Of Date)
        Public Property Date4 As Nullable(Of Date)
        Public Property Date5 As Nullable(Of Date)
        Public Property Spots1 As Nullable(Of Integer)
        Public Property Spots2 As Nullable(Of Integer)
        Public Property Spots3 As Nullable(Of Integer)
        Public Property Spots4 As Nullable(Of Integer)
        Public Property Spots5 As Nullable(Of Integer)
        Public ReadOnly Property TotalSpots As Integer
            Get
                TotalSpots = Me.Spots1.GetValueOrDefault(0) + Me.Spots2.GetValueOrDefault(0) + Me.Spots3.GetValueOrDefault(0) + Me.Spots4.GetValueOrDefault(0) + Me.Spots5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property IsApproved As Boolean
        Public Property IsOrdered As Boolean
        Public Property OrderedSpots1 As Nullable(Of Integer)
        Public Property OrderedSpots2 As Nullable(Of Integer)
        Public Property OrderedSpots3 As Nullable(Of Integer)
        Public Property OrderedSpots4 As Nullable(Of Integer)
        Public Property OrderedSpots5 As Nullable(Of Integer)
        Public ReadOnly Property OrderedSpotsTotal As Integer
            Get
                OrderedSpotsTotal = Me.OrderedSpots1.GetValueOrDefault(0) + Me.OrderedSpots2.GetValueOrDefault(0) + Me.OrderedSpots3.GetValueOrDefault(0) + Me.OrderedSpots4.GetValueOrDefault(0) + Me.OrderedSpots5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property ApprovedSpots1 As Nullable(Of Integer)
        Public Property ApprovedSpots2 As Nullable(Of Integer)
        Public Property ApprovedSpots3 As Nullable(Of Integer)
        Public Property ApprovedSpots4 As Nullable(Of Integer)
        Public Property ApprovedSpots5 As Nullable(Of Integer)
        Public ReadOnly Property ApprovedSpotsTotal As Integer
            Get
                ApprovedSpotsTotal = Me.ApprovedSpots1.GetValueOrDefault(0) + Me.ApprovedSpots2.GetValueOrDefault(0) + Me.ApprovedSpots3.GetValueOrDefault(0) + Me.ApprovedSpots4.GetValueOrDefault(0) + Me.ApprovedSpots5.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpots1 As Nullable(Of Integer)
            Get
                MissedSpots1 = Me.ApprovedSpots1.GetValueOrDefault(0) - Me.OrderedSpots1.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpots2 As Nullable(Of Integer)
            Get
                MissedSpots2 = Me.ApprovedSpots2.GetValueOrDefault(0) - Me.OrderedSpots2.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpots3 As Nullable(Of Integer)
            Get
                MissedSpots3 = Me.ApprovedSpots3.GetValueOrDefault(0) - Me.OrderedSpots3.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpots4 As Nullable(Of Integer)
            Get
                MissedSpots4 = Me.ApprovedSpots4.GetValueOrDefault(0) - Me.OrderedSpots4.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpots5 As Nullable(Of Integer)
            Get
                MissedSpots5 = Me.ApprovedSpots5.GetValueOrDefault(0) - Me.OrderedSpots5.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedSpotsTotal As Integer
            Get
                MissedSpotsTotal = Me.MissedSpots1.GetValueOrDefault(0) + Me.MissedSpots2.GetValueOrDefault(0) + Me.MissedSpots3.GetValueOrDefault(0) + Me.MissedSpots4.GetValueOrDefault(0) + Me.MissedSpots5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property UnmatchedSpots1 As Nullable(Of Integer)
        Public Property UnmatchedSpots2 As Nullable(Of Integer)
        Public Property UnmatchedSpots3 As Nullable(Of Integer)
        Public Property UnmatchedSpots4 As Nullable(Of Integer)
        Public Property UnmatchedSpots5 As Nullable(Of Integer)
        Public ReadOnly Property UnmatchedSpotsTotal As Integer
            Get
                UnmatchedSpotsTotal = Me.UnmatchedSpots1.GetValueOrDefault(0) + Me.UnmatchedSpots2.GetValueOrDefault(0) + Me.UnmatchedSpots3.GetValueOrDefault(0) + Me.UnmatchedSpots4.GetValueOrDefault(0) + Me.UnmatchedSpots5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property ApprovedGross1 As Nullable(Of Decimal)
        Public Property ApprovedGross2 As Nullable(Of Decimal)
        Public Property ApprovedGross3 As Nullable(Of Decimal)
        Public Property ApprovedGross4 As Nullable(Of Decimal)
        Public Property ApprovedGross5 As Nullable(Of Decimal)
        Public ReadOnly Property ApprovedGrossTotal As Decimal
            Get
                ApprovedGrossTotal = Me.ApprovedGross1.GetValueOrDefault(0) + Me.ApprovedGross2.GetValueOrDefault(0) + Me.ApprovedGross3.GetValueOrDefault(0) + Me.ApprovedGross4.GetValueOrDefault(0) + Me.ApprovedGross5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property UnmatchedGross1 As Nullable(Of Decimal)
        Public Property UnmatchedGross2 As Nullable(Of Decimal)
        Public Property UnmatchedGross3 As Nullable(Of Decimal)
        Public Property UnmatchedGross4 As Nullable(Of Decimal)
        Public Property UnmatchedGross5 As Nullable(Of Decimal)
        Public ReadOnly Property UnmatchedGrossTotal As Decimal
            Get
                UnmatchedGrossTotal = Me.UnmatchedGross1.GetValueOrDefault(0) + Me.UnmatchedGross2.GetValueOrDefault(0) + Me.UnmatchedGross3.GetValueOrDefault(0) + Me.UnmatchedGross4.GetValueOrDefault(0) + Me.UnmatchedGross5.GetValueOrDefault(0)
            End Get
        End Property
        Public Property OrderedGross1 As Nullable(Of Decimal)
        Public Property OrderedGross2 As Nullable(Of Decimal)
        Public Property OrderedGross3 As Nullable(Of Decimal)
        Public Property OrderedGross4 As Nullable(Of Decimal)
        Public Property OrderedGross5 As Nullable(Of Decimal)
        Public ReadOnly Property OrderedGrossTotal As Decimal
            Get
                OrderedGrossTotal = Me.OrderedGross1.GetValueOrDefault(0) + Me.OrderedGross2.GetValueOrDefault(0) + Me.OrderedGross3.GetValueOrDefault(0) + Me.OrderedGross4.GetValueOrDefault(0) + Me.OrderedGross5.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGross1 As Decimal
            Get
                MissedGross1 = Me.ApprovedGross1.GetValueOrDefault(0) - Me.OrderedGross1.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGross2 As Decimal
            Get
                MissedGross2 = Me.ApprovedGross2.GetValueOrDefault(0) - Me.OrderedGross2.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGross3 As Decimal
            Get
                MissedGross3 = Me.ApprovedGross3.GetValueOrDefault(0) - Me.OrderedGross3.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGross4 As Decimal
            Get
                MissedGross4 = Me.ApprovedGross4.GetValueOrDefault(0) - Me.OrderedGross4.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGross5 As Decimal
            Get
                MissedGross5 = Me.ApprovedGross5.GetValueOrDefault(0) - Me.OrderedGross5.GetValueOrDefault(0)
            End Get
        End Property
        Public ReadOnly Property MissedGrossTotal As Decimal
            Get
                MissedGrossTotal = Me.MissedGross1 + MissedGross2 + MissedGross3 + MissedGross4 + MissedGross5
            End Get
        End Property
        Public ReadOnly Property OrderedNet1 As Decimal
            Get
                OrderedNet1 = Me.OrderedGross1.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property OrderedNet2 As Decimal
            Get
                OrderedNet2 = Me.OrderedGross2.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property OrderedNet3 As Decimal
            Get
                OrderedNet3 = Me.OrderedGross3.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property OrderedNet4 As Decimal
            Get
                OrderedNet4 = Me.OrderedGross4.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property OrderedNet5 As Decimal
            Get
                OrderedNet5 = Me.OrderedGross5.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property OrderedNetTotal As Decimal
            Get
                OrderedNetTotal = Me.OrderedNet1 + Me.OrderedNet2 + Me.OrderedNet3 + Me.OrderedNet4 + Me.OrderedNet5
            End Get
        End Property
        Public ReadOnly Property ApprovedNet1 As Decimal
            Get
                ApprovedNet1 = Me.ApprovedGross1.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property ApprovedNet2 As Decimal
            Get
                ApprovedNet2 = Me.ApprovedGross2.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property ApprovedNet3 As Decimal
            Get
                ApprovedNet3 = Me.ApprovedGross3.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property ApprovedNet4 As Decimal
            Get
                ApprovedNet4 = Me.ApprovedGross4.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property ApprovedNet5 As Decimal
            Get
                ApprovedNet5 = Me.ApprovedGross5.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property ApprovedNetTotal As Decimal
            Get
                ApprovedNetTotal = Me.ApprovedNet1 + Me.ApprovedNet2 + Me.ApprovedNet3 + Me.ApprovedNet4 + Me.ApprovedNet5
            End Get
        End Property
        Public ReadOnly Property MissedNet1 As Decimal
            Get
                MissedNet1 = Me.MissedGross1 * 0.85D
            End Get
        End Property
        Public ReadOnly Property MissedNet2 As Decimal
            Get
                MissedNet2 = Me.MissedGross2 * 0.85D
            End Get
        End Property
        Public ReadOnly Property MissedNet3 As Decimal
            Get
                MissedNet3 = Me.MissedGross3 * 0.85D
            End Get
        End Property
        Public ReadOnly Property MissedNet4 As Decimal
            Get
                MissedNet4 = Me.MissedGross4 * 0.85D
            End Get
        End Property
        Public ReadOnly Property MissedNet5 As Decimal
            Get
                MissedNet5 = Me.MissedGross5 * 0.85D
            End Get
        End Property
        Public ReadOnly Property MissedNetTotal As Decimal
            Get
                MissedNetTotal = Me.MissedNet1 + Me.MissedNet2 + Me.MissedNet3 + Me.MissedNet4 + Me.MissedNet5
            End Get
        End Property
        Public ReadOnly Property UnmatchedNet1 As Decimal
            Get
                UnmatchedNet1 = Me.UnmatchedGross1.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property UnmatchedNet2 As Decimal
            Get
                UnmatchedNet2 = Me.UnmatchedGross2.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property UnmatchedNet3 As Decimal
            Get
                UnmatchedNet3 = Me.UnmatchedGross3.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property UnmatchedNet4 As Decimal
            Get
                UnmatchedNet4 = Me.UnmatchedGross4.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property UnmatchedNet5 As Decimal
            Get
                UnmatchedNet5 = Me.UnmatchedGross5.GetValueOrDefault(0) * 0.85D
            End Get
        End Property
        Public ReadOnly Property UnmatchedNetTotal As Decimal
            Get
                UnmatchedNetTotal = Me.UnmatchedNet1 + Me.UnmatchedNet2 + Me.UnmatchedNet3 + Me.UnmatchedNet4 + Me.UnmatchedNet5
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(Line As Integer, Days As String, Times As String, Program As String, DayPart As String, Length As Integer?, Rate As Decimal?)

            Me.Line = Line
            Me.Days = Days
            Me.Times = Times
            Me.Program = Program
            Me.DPLength = DayPart & "/" & If(Length.HasValue, Length.Value.ToString, "")
            Me.Rate = Rate
            Me.IsApproved = False
            Me.IsOrdered = True

        End Sub
        Public Sub New(Line As Integer?, Days As String, Times As String, Program As String, AdNumber As String, SpotVariant As String, Rate As Decimal?, IsApproved As Boolean, Length As Short?)

            Me.Line = Line.GetValueOrDefault(Int32.MaxValue)
            Me.Days = Days
            Me.Times = Times
            Me.Program = Program
            Me.AdNumber = AdNumber
            Me.VariantCode = SpotVariant
            Me.Rate = Rate
            Me.IsApproved = IsApproved
            Me.IsOrdered = False
            Me.DPLength = If(Length.HasValue, Length.Value.ToString, "")

        End Sub

#End Region

    End Class

End Namespace
