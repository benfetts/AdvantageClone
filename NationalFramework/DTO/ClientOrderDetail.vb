Namespace DTO

    Public Class ClientOrderDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientOrderID
            DataType
            TimeType
            IsHispanic
            Detail
            September
            October
            November
            December
            January
            February
            March
            April
            May
            June
            July
            August
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ClientOrderID() As Integer

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property DataType() As String

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property TimeType() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property IsHispanic() As Boolean

        Public ReadOnly Property Detail() As String
            Get
                Detail = If(Me.IsHispanic, "Hispanic ", "") & Me.DataType & If(Me.TimeType = "C", " ACM", "")
            End Get
        End Property

        Public Property September() As Boolean
        Public Property October() As Boolean
        Public Property November() As Boolean
        Public Property December() As Boolean
        Public Property January() As Boolean
        Public Property February() As Boolean
        Public Property March() As Boolean
        Public Property April() As Boolean
        Public Property May() As Boolean
        Public Property June() As Boolean
        Public Property July() As Boolean
        Public Property August() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property HasAtLeastOneMonthChecked() As Boolean
            Get
                HasAtLeastOneMonthChecked = Me.January OrElse Me.February OrElse Me.March OrElse Me.April OrElse Me.May OrElse Me.June OrElse
                    Me.July OrElse Me.August OrElse Me.September OrElse Me.October OrElse Me.November OrElse Me.December
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(DataType As String, TimeType As String, IsHispanic As Boolean)

            Me.DataType = DataType
            Me.TimeType = TimeType
            Me.IsHispanic = IsHispanic

        End Sub
        Public Sub New(ClientOrderDetail As Database.Entities.ClientOrderDetail)

            Me.ID = ClientOrderDetail.ID
            Me.ClientOrderID = ClientOrderDetail.ClientOrderID
            Me.DataType = ClientOrderDetail.DataType
            Me.TimeType = ClientOrderDetail.TimeType
            Me.IsHispanic = ClientOrderDetail.IsHispanic
            Me.September = ClientOrderDetail.September
            Me.October = ClientOrderDetail.October
            Me.November = ClientOrderDetail.November
            Me.December = ClientOrderDetail.December
            Me.January = ClientOrderDetail.January
            Me.February = ClientOrderDetail.February
            Me.March = ClientOrderDetail.March
            Me.April = ClientOrderDetail.April
            Me.May = ClientOrderDetail.May
            Me.June = ClientOrderDetail.June
            Me.July = ClientOrderDetail.July
            Me.August = ClientOrderDetail.August

        End Sub
        Public Sub SaveToEntity(ByRef ClientOrderDetail As Database.Entities.ClientOrderDetail)

            ClientOrderDetail.ID = Me.ID
            ClientOrderDetail.ClientOrderID = Me.ClientOrderID
            ClientOrderDetail.DataType = Me.DataType
            ClientOrderDetail.TimeType = Me.TimeType
            ClientOrderDetail.IsHispanic = Me.IsHispanic
            ClientOrderDetail.September = Me.September
            ClientOrderDetail.October = Me.October
            ClientOrderDetail.November = Me.November
            ClientOrderDetail.December = Me.December
            ClientOrderDetail.January = Me.January
            ClientOrderDetail.February = Me.February
            ClientOrderDetail.March = Me.March
            ClientOrderDetail.April = Me.April
            ClientOrderDetail.May = Me.May
            ClientOrderDetail.June = Me.June
            ClientOrderDetail.July = Me.July
            ClientOrderDetail.August = Me.August

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
