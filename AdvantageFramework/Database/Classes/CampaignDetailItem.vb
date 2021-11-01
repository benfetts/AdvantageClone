Namespace Database.Classes

    <Serializable()>
    Public Class CampaignDetailItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CampaignID
            Type
            Number
            Description
            Vendor
            SalesClass
            [Date]
            DetailItem
        End Enum

#End Region

#Region " Variables "

        Private _CampaignID As Integer = Nothing
        Private _Type As String = Nothing
        Private _Number As String = Nothing
        Private _Description As String = Nothing
        Private _Vendor As String = Nothing
        Private _SalesClass As String = Nothing
        Private _Date As Date = Nothing
        Private _DetailItem As Object = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CampaignID() As Integer
            Get
                CampaignID = _CampaignID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Type() As String
            Get
                Type = _Type
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Number() As String
            Get
                Number = _Number
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Description() As String
            Get
                Description = _Description
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property Vendor() As String
            Get
                Vendor = _Vendor
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property SalesClass() As String
            Get
                SalesClass = _SalesClass
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public ReadOnly Property [Date]() As Date
            Get
                [Date] = _Date
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property DetailItem() As Object
            Get
                DetailItem = _DetailItem
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Job As AdvantageFramework.Database.Entities.Job)

            _CampaignID = Job.CampaignID.GetValueOrDefault(0)
            _Type = "Job"
            _Number = Job.ToString(False)
            _Description = Job.Description
            _Vendor = ""
            _SalesClass = If(Job.SalesClass Is Nothing, "", Job.SalesClass.ToString)
            _Date = Job.OpenedDate.GetValueOrDefault("01/01/1900")
            _DetailItem = Job

        End Sub
        Public Sub New(ByVal InternetOrder As AdvantageFramework.Database.Entities.InternetOrder)

            _CampaignID = InternetOrder.CampaignID.GetValueOrDefault(0)
            _Type = "Internet Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(InternetOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = InternetOrder.Description
            _Vendor = If(InternetOrder.Vendor Is Nothing, "", InternetOrder.Vendor.ToString)
            _SalesClass = If(InternetOrder.SalesClass Is Nothing, "", InternetOrder.SalesClass.ToString)
            _Date = InternetOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = InternetOrder

        End Sub
        Public Sub New(ByVal MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder)

            _CampaignID = MagazineOrder.CampaignID.GetValueOrDefault(0)
            _Type = "Magazine Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(MagazineOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = MagazineOrder.Description
            _Vendor = If(MagazineOrder.Vendor Is Nothing, "", MagazineOrder.Vendor.ToString)
            _SalesClass = If(MagazineOrder.SalesClass Is Nothing, "", MagazineOrder.SalesClass.ToString)
            _Date = MagazineOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = MagazineOrder

        End Sub
        Public Sub New(ByVal NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder)

            _CampaignID = NewspaperOrder.CampaignID.GetValueOrDefault(0)
            _Type = "Newspaper Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(NewspaperOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = NewspaperOrder.Description
            _Vendor = If(NewspaperOrder.Vendor Is Nothing, "", NewspaperOrder.Vendor.ToString)
            _SalesClass = If(NewspaperOrder.SalesClass Is Nothing, "", NewspaperOrder.SalesClass.ToString)
            _Date = NewspaperOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = NewspaperOrder

        End Sub
        Public Sub New(ByVal OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder)

            _CampaignID = OutOfHomeOrder.CampaignID.GetValueOrDefault(0)
            _Type = "Out Of Home Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(OutOfHomeOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = OutOfHomeOrder.Description
            _Vendor = If(OutOfHomeOrder.Vendor Is Nothing, "", OutOfHomeOrder.Vendor.ToString)
            _SalesClass = If(OutOfHomeOrder.SalesClass Is Nothing, "", OutOfHomeOrder.SalesClass.ToString)
            _Date = OutOfHomeOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = OutOfHomeOrder

        End Sub
        Public Sub New(ByVal RadioOrder As AdvantageFramework.Database.Entities.RadioOrder)

            _CampaignID = RadioOrder.CampaignID.GetValueOrDefault(0)
            _Type = "Radio Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(RadioOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = RadioOrder.Description
            _Vendor = If(RadioOrder.Vendor Is Nothing, "", RadioOrder.Vendor.ToString)
            _SalesClass = If(RadioOrder.SalesClass Is Nothing, "", RadioOrder.SalesClass.ToString)
            _Date = RadioOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = RadioOrder

        End Sub
        Public Sub New(ByVal TVOrder As AdvantageFramework.Database.Entities.TVOrder)

            _CampaignID = TVOrder.CampaignID.GetValueOrDefault(0)
            _Type = "TV Order"
            _Number = CStr(AdvantageFramework.StringUtilities.PadWithCharacter(TVOrder.OrderNumber, 6, "0", True, True)).Trim
            _Description = TVOrder.Description
            _Vendor = If(TVOrder.Vendor Is Nothing, "", TVOrder.Vendor.ToString)
            _SalesClass = If(TVOrder.SalesClass Is Nothing, "", TVOrder.SalesClass.ToString)
            _Date = TVOrder.OrderDate.GetValueOrDefault("01/01/1900")
            _DetailItem = TVOrder

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Number

        End Function

#End Region

    End Class

End Namespace

