Namespace DTO.Media.National

    Public Class ResearchResult
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Network
            ProgramName
            ProgramType
            MediaDemoID
            Demographic
            DemographicOrder
            HPUT
            HPUTPercent
            Impressions
            Rating
            Share
            VPVH
            Universe
            Airings
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Network() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProgramName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProgramType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property MediaDemoID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DemographicOrder As Short

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property HPUT() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HPUTPercent() As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Impressions() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Rating() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property Share() As Decimal
            Get
                Share = FormatNumber(If(Me.HPUT = 0, 0, Me.Impressions * 100 / Me.HPUT), 2)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property VPVH() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Universe() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Airings() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property YYYYMM() As Integer

        Public ReadOnly Property MonthYear As String
            Get
                If YYYYMM = 0 Then 'not set for ranker reports
                    MonthYear = ""
                Else
                    MonthYear = MonthName(Me.YYYYMM.ToString.Substring(4, 2), True) & Me.YYYYMM.ToString.Substring(0, 4)
                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rank() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
