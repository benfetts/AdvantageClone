Namespace ViewModels.Media

    <Serializable()>
    Public Class MediaManagerAdServingDetailViewModel
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AdServer
            GroupID
            IsCancelled
            RequiresUpdate
            ClientName
            DivisionName
            ProductDescription
            OrderNumber
            OrderDescription
            AdServerAdvertiserID
            AdServerCampaignID
            CampaignID
            CampaignCode
            CampaignName
            CampaignStartDate
            CampaignEndDate
            LandingPageName
            LandingPageURL
            VendorName
            AdServerSiteID
            InternetType
            InternetTypeDescription
            PlacementName
            MediaPlanDetailPackagePlacementNameID
            InternetCostType
            PricingType
            StartDate
            EndDate
            AdSizeCode
            ModifiedDate
            PackageParent
            AdServerPlacementGroupID
            PackageName
            AdServerPlacementID
            PackagePlacementIDs
            PlacementCreatedBy
            PlacementCreatedDate
            PlacementRevisionBy
            PlacementRevisionDate
            AdServerSizeID
            HasAdServerAdvertiserID
            HasAdServerCampaignID
            HasCampaignID
            HasAdServerSiteID
            IsPlacementArchived
            LineNumbers
            AdditionalAdSizeCount
            AdditionalAdSizes
        End Enum

#End Region

#Region " Variables "

        Private _InternetPackageDetails As Generic.List(Of AdvantageFramework.DTO.Media.InternetPackageDetail)
        Private _AdditionalAdSizes As String

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property AdServer As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Group" & vbCrLf & "ID")>
        Public Property GroupID As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Is" & vbCrLf & "Cancelled")>
        Public Property IsCancelled As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Requires" & vbCrLf & "Update", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property RequiresUpdate As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order Revised" & vbCrLf & "Date/Time", DisplayFormat:="G")>
        Public Property ModifiedDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Client" & vbCrLf & "Name")>
		Public Property ClientName() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Division" & vbCrLf & "Name")>
		Public Property DivisionName() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Product" & vbCrLf & "Description")>
		Public Property ProductDescription() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Number")>
		Public Property OrderNumber() As Integer

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Order" & vbCrLf & "Description")>
		Public Property OrderDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Advertiser", PropertyType:=BaseClasses.Methods.PropertyTypes.AdServerAdvertiserID)>
		Public Property AdServerAdvertiserID() As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Campaign", PropertyType:=BaseClasses.Methods.PropertyTypes.AdServerCampaignID)>
        Public Property AdServerCampaignID As Nullable(Of Long)

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Campaign" & vbCrLf & "ID", PropertyType:=BaseClasses.Methods.PropertyTypes.CampaignID)>
		Public Property CampaignID() As Nullable(Of Integer)

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Campaign" & vbCrLf & "Code")>
		Public Property CampaignCode() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Campaign" & vbCrLf & "Name")>
		Public Property CampaignName() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Campaign" & vbCrLf & "Start")>
		Public Property CampaignStartDate() As Nullable(Of Date)

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Campaign" & vbCrLf & "End")>
		Public Property CampaignEndDate() As Nullable(Of Date)

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Landing" & vbCrLf & "Page")>
		Public Property LandingPageName() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Landing" & vbCrLf & "URL")>
		Public Property LandingPageURL() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Vendor" & vbCrLf & "Name")>
        Public Property VendorName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Site", PropertyType:=BaseClasses.Methods.PropertyTypes.AdServerSiteID)>
        Public Property AdServerSiteID() As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Internet" & vbCrLf & "Type", PropertyType:=BaseClasses.Methods.PropertyTypes.InternetType)>
		Public Property InternetType() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Internet Type" & vbCrLf & "Description")>
		Public Property InternetTypeDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Placement" & vbCrLf & "Name")>
        Public Property PlacementName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailPackagePlacementNameID() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Internet" & vbCrLf & "Cost Type")>
		Public Property InternetCostType() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Pricing" & vbCrLf & "Type")>
		Public Property PricingType() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Start" & vbCrLf & "Date")>
        Public Property StartDate() As Date

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="End" & vbCrLf & "Date")>
        Public Property EndDate() As Date

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Size" & vbCrLf & "Code", PropertyType:=BaseClasses.Methods.PropertyTypes.AdSizeCode)>
		Public Property AdSizeCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Package" & vbCrLf & "Name")>
        Public Property PackageName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public ReadOnly Property AdditionalAdSizeCount() As Integer
            Get
                AdditionalAdSizeCount = _InternetPackageDetails.Select(Function(E) E.InternetPackageDetail.AdSizeCode).Distinct.Count
            End Get
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Add'l Ad Sizes/" & vbCrLf & "Pkg Details")>
        Public ReadOnly Property AdditionalAdSizes() As String
            Get
                AdditionalAdSizes = _AdditionalAdSizes
            End Get
        End Property

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Package" & vbCrLf & "Parent", ShowColumnInGrid:=False)>
        Public Property PackageParent As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Line" & vbCrLf & "Numbers")>
        Public Property LineNumbers() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Package" & vbCrLf & "ID")>
        Public Property AdServerPlacementGroupID As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Placement" & vbCrLf & "ID", PropertyType:=BaseClasses.Methods.PropertyTypes.AdServerPlacementID)>
        Public Property AdServerPlacementID As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Package" & vbCrLf & "Placement IDs")>
        Public Property PackagePlacementIDs As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Manual" & vbCrLf & "Placement")>
        Public Property AdServerPlacementManual As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Placement" & vbCrLf & "Archived")>
        Public Property IsPlacementArchived As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Placement" & vbCrLf & "Created By")>
        Public Property PlacementCreatedBy() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Placement" & vbCrLf & "Created Date", DisplayFormat:="G")>
        Public Property PlacementCreatedDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Placement" & vbCrLf & "Revision By")>
        Public Property PlacementRevisionBy() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Placement" & vbCrLf & "Revision Date", DisplayFormat:="G")>
        Public Property PlacementRevisionDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Ad Server" & vbCrLf & "Size ID")>
		Public Property AdServerSizeID As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasAdServerAdvertiserID() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasAdServerCampaignID() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasCampaignID() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property HasAdServerSiteID() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ReviseUpdateOrder() As Boolean

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property UpdateCampaignEntity() As Boolean

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ClientCode() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property DivisionCode() As String

		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property ProductCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClearedPlacementID() As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsNewPackage() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Quantity() As Nullable(Of Long)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Rate() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Cost() As Decimal

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Additional Ad Size" & vbCrLf & "Placement Count", ShowColumnInGrid:=False)>
        Public ReadOnly Property AdditionalAdSizePlacementCount() As Integer
            Get
                AdditionalAdSizePlacementCount = (From Entity In _InternetPackageDetails
                                                  Where Entity.InternetPackageDetail.AdServerPlacementID IsNot Nothing
                                                  Select Entity.InternetPackageDetail.AdServerPlacementID).Distinct.Count
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property InternetPackageDetails As Generic.List(Of AdvantageFramework.DTO.Media.InternetPackageDetail)
            Get
                InternetPackageDetails = _InternetPackageDetails
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property CreatePlacementEnabled As Boolean
            Get
                CreatePlacementEnabled = (Me.AdServerAdvertiserID.HasValue AndAlso
                                          Me.AdServerCampaignID.HasValue AndAlso
                                          Me.AdServerPlacementID.HasValue = False AndAlso
                                          Me.HasError = False AndAlso
                                          Me.IsNewPackage = False) OrElse
                                         (Me.AdServerAdvertiserID.HasValue AndAlso
                                          Me.AdServerCampaignID.HasValue AndAlso
                                          Me.AdditionalAdSizePlacementCount = 0 AndAlso
                                          Me.AdServerPlacementGroupID.HasValue = False AndAlso
                                          Me.HasError = False AndAlso
                                          Me.IsNewPackage = True)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property UpdatePlacementEnabled As Boolean
            Get
                UpdatePlacementEnabled = (Me.AdServerAdvertiserID.HasValue AndAlso
                                          Me.AdServerCampaignID.HasValue AndAlso
                                          Me.AdServerPlacementID.HasValue AndAlso
                                          Me.HasError = False AndAlso
                                          Me.AdServerPlacementManual = False AndAlso
                                          Me.IsNewPackage = False) OrElse
                                         (Me.AdServerAdvertiserID.HasValue AndAlso
                                          Me.AdServerCampaignID.HasValue AndAlso
                                          (Me.AdditionalAdSizePlacementCount > 0 OrElse
                                           Me.AdServerPlacementGroupID.HasValue = True OrElse
                                           Me.AdServerPlacementID.HasValue = True) AndAlso
                                          Me.HasError = False AndAlso
                                          Me.AdServerPlacementManual = False AndAlso
                                          Me.IsNewPackage = True)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False),
        System.ComponentModel.Browsable(False),
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property ClearPlacementEnabled As Boolean
            Get
                ClearPlacementEnabled = (Me.AdServerAdvertiserID.HasValue AndAlso
                                         Me.AdServerCampaignID.HasValue AndAlso
                                         Me.AdServerPlacementID.HasValue AndAlso
                                         Me.IsNewPackage = False) OrElse
                                        (Me.AdServerPlacementID.HasValue AndAlso
                                         Me.AdServerPlacementManual AndAlso
                                         Me.IsNewPackage = False) OrElse
                                        (Me.AdServerAdvertiserID.HasValue AndAlso
                                         Me.AdServerCampaignID.HasValue AndAlso
                                         (Me.AdditionalAdSizePlacementCount > 0 OrElse
                                          Me.AdServerPlacementGroupID.HasValue = True OrElse
                                          Me.AdServerPlacementID.HasValue = True) AndAlso
                                         Me.IsNewPackage = True)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _InternetPackageDetails = New Generic.List(Of AdvantageFramework.DTO.Media.InternetPackageDetail)

        End Sub
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerCampaignID.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignStartDate.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignEndDate.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.LandingPageName.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.LandingPageURL.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetType.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.PlacementName.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetCostType.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.PricingType.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.StartDate.ToString, Not Me.AdServerPlacementManual)
            SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.EndDate.ToString, Not Me.AdServerPlacementManual)

            If Me.IsNewPackage Then

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString, False)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSizeID.ToString, False)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.PlacementName.ToString, False)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdditionalAdSizes.ToString, True)

            Else

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString, Not Me.AdServerPlacementManual)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerSizeID.ToString, Not Me.AdServerPlacementManual)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.PlacementName.ToString, True)

                SetRequired(AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdditionalAdSizes.ToString, False)

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = ""
			Dim PropertyValue As Object = Nothing
            Dim Lines As IEnumerable(Of Short) = Nothing
            Dim AdSizeCodes As IEnumerable(Of String) = Nothing
            Dim AdditionalAdSizeCodes As Generic.List(Of String) = Nothing
            Dim Codes() As String = Nothing

            Select Case PropertyName

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdServerPlacementID.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If Not String.IsNullOrWhiteSpace(Me.LineNumbers) Then

                            Lines = Split(Me.LineNumbers, ",").Select(Function(LN) CShort(LN)).ToArray

                        End If

                        If PropertyValue IsNot Nothing AndAlso Lines IsNot Nothing AndAlso Lines.Count > 0 Then

                            If (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.InternetOrderDetail)
                                Where Entity.InternetOrderOrderNumber = Me.OrderNumber AndAlso
                                      LineNumbers.Contains(Entity.LineNumber) = False AndAlso
                                      Entity.AdServerPlacementID = DirectCast(PropertyValue, Long)).Any Then

                                IsValid = False

                                ErrorText = "Placement conflicts with other line numbers."

                                Me.RequiresUpdate = True

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.LandingPageURL.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing AndAlso PropertyValue.ToString.ToLower.StartsWith("http://") = False AndAlso PropertyValue.ToString.ToLower.StartsWith("https://") = False Then

                            IsValid = False

                            ErrorText = "URL must start with http:// or https://."

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, Me.ClientCode)
                                Where Entity.IsInactive = False AndAlso
                                      Entity.WebsiteAddress = DirectCast(PropertyValue, String)).Any = False Then

                            IsValid = False

                            ErrorText = "Cannot find active client website with this URL."

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.CampaignEndDate.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If DateDiff(DateInterval.Day, Now, DirectCast(PropertyValue, Date)) < 0 Then

                                IsValid = False

                                ErrorText = "Campaign end date must be today or later."

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.InternetTypeDescription.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If AdvantageFramework.DoubleClick.GetCompatibility.Contains(DirectCast(PropertyValue, String)) = False Then

                                IsValid = False

                                ErrorText = "Invalid internet type description."

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.PricingType.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If PropertyValue <> "PRICING_TYPE_CPA" AndAlso PropertyValue <> "PRICING_TYPE_CPC" AndAlso PropertyValue <> "PRICING_TYPE_CPM" AndAlso
                                    PropertyValue <> "PRICING_TYPE_CPM_ACTIVEVIEW" AndAlso PropertyValue <> "PRICING_TYPE_FLAT_RATE_CLICKS" AndAlso PropertyValue <> "PRICING_TYPE_FLAT_RATE_IMPRESSIONS" Then

                                IsValid = False

                                ErrorText = "Invalid pricing type."

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.StartDate.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing AndAlso Me.CampaignStartDate.HasValue AndAlso Me.CampaignEndDate.HasValue Then

                            If PropertyValue < Me.CampaignStartDate.Value OrElse PropertyValue > Me.CampaignEndDate.Value Then

                                IsValid = False

                                ErrorText = "Start date must be in campaign date range " & FormatDateTime(Me.CampaignStartDate.ToString, DateFormat.ShortDate) & " - " & FormatDateTime(Me.CampaignEndDate.ToString, DateFormat.ShortDate) & "."

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.EndDate.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing AndAlso Me.CampaignEndDate.HasValue Then

                            If PropertyValue < Me.StartDate OrElse PropertyValue > Me.CampaignEndDate.Value Then

                                IsValid = False

                                ErrorText = "End Date must be on or after start date " & FormatDateTime(Me.StartDate.ToString, DateFormat.ShortDate) & " and no later than the campaign end date " & FormatDateTime(Me.CampaignEndDate.ToString, DateFormat.ShortDate) & "."

                            End If

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdSizeCode.ToString

                    If Not Me.AdServerPlacementManual Then

                        PropertyValue = Value

                        If Not (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).AdSizes
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                      Entity.AdServerSizeID.HasValue AndAlso
                                      (Entity.IsInactive Is Nothing OrElse
                                       Entity.IsInactive = 0)
                                Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a valid ad size code."

                        End If

                    End If

                Case AdvantageFramework.ViewModels.Media.MediaManagerAdServingDetailViewModel.Properties.AdditionalAdSizes.ToString

                    If Me.IsNewPackage AndAlso _InternetPackageDetails.Count = 0 Then

                        IsValid = False

                        ErrorText = "A package must have at least one additional ad size."

                    ElseIf _InternetPackageDetails.Count > 0 Then

                        AdSizeCodes = _InternetPackageDetails.Select(Function(E) E.InternetPackageDetail.AdSizeCode).ToArray

                        If (From Entity In DirectCast(DbContext, AdvantageFramework.Database.DbContext).AdSizes
                            Where Entity.MediaType = "I" AndAlso
                                  AdSizeCodes.Contains(Entity.Code) AndAlso
                                  Entity.AdServerSizeID Is Nothing).Any Then

                            IsValid = False

                            ErrorText = "Invalid ad size code specified."

                        End If

                        AdditionalAdSizeCodes = New Generic.List(Of String)

                        For Each AdditionalAdSizeCode In _InternetPackageDetails.Where(Function(E) String.IsNullOrWhiteSpace(E.InternetPackageDetail.AdditionalAdSizeCodes) = False).Select(Function(E) E.InternetPackageDetail.AdditionalAdSizeCodes).Distinct.ToList

                            Codes = AdditionalAdSizeCode.Split(",")

                            If Codes IsNot Nothing Then

                                For Each Code In Codes

                                    If AdditionalAdSizeCodes.Contains(Code) = False Then

                                        AdditionalAdSizeCodes.Add(Code)

                                    End If

                                Next

                            End If

                        Next

                        If AdditionalAdSizeCodes.Count > 0 Then

                            If (From Entity In DirectCast(DbContext, AdvantageFramework.Database.DbContext).AdSizes
                                Where Entity.MediaType = "I" AndAlso
                                      AdditionalAdSizeCodes.Contains(Entity.Code) AndAlso
                                      Entity.AdServerSizeID Is Nothing).Any Then

                                IsValid = False

                                ErrorText = "Invalid ad size code specified."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Sub LoadAdditionalAdSizes(DbContext As AdvantageFramework.Database.DbContext)

            Dim LineNumber As String() = Nothing
            Dim Lines As Generic.List(Of Short) = Nothing
            Dim AdSizeCodes As Generic.List(Of String) = Nothing
            Dim AdSizes() As String = Nothing

            AdSizeCodes = New Generic.List(Of String)

            LineNumber = LineNumbers.Split(",")
            Lines = New Generic.List(Of Short)

            For i As Integer = 0 To UBound(LineNumber)

                Lines.Add(LineNumber(i))

            Next

            _InternetPackageDetails.Clear()

            _InternetPackageDetails.AddRange(From Entity In AdvantageFramework.Database.Procedures.InternetPackageDetail.LoadActiveRevisionsByOrderLines(DbContext, Me.OrderNumber, Lines).ToList
                                             Select New AdvantageFramework.DTO.Media.InternetPackageDetail(DbContext, Entity))

            Me.PackagePlacementIDs = String.Join(", ", _InternetPackageDetails.Where(Function(IPD) IPD.InternetPackageDetail.AdServerPlacementID.HasValue).Select(Function(IPD) IPD.InternetPackageDetail.AdServerPlacementID.Value).Distinct.ToArray)

            If String.IsNullOrWhiteSpace(Me.PlacementCreatedBy) Then

                Me.PlacementCreatedBy = _InternetPackageDetails.Where(Function(IPD) String.IsNullOrWhiteSpace(IPD.InternetPackageDetail.AdServerCreatedBy) = False).Select(Function(IPD) IPD.InternetPackageDetail.AdServerCreatedBy).FirstOrDefault

            End If

            If String.IsNullOrWhiteSpace(Me.PlacementRevisionBy) Then

                Me.PlacementRevisionBy = _InternetPackageDetails.Where(Function(IPD) String.IsNullOrWhiteSpace(IPD.InternetPackageDetail.AdServerLastModifiedBy) = False).Select(Function(IPD) IPD.InternetPackageDetail.AdServerLastModifiedBy).FirstOrDefault

            End If

            AdSizeCodes.AddRange(_InternetPackageDetails.Select(Function(Entity) Entity.InternetPackageDetail.AdSizeCode).Distinct.ToList)

            If _InternetPackageDetails.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.InternetPackageDetail.AdditionalAdSizeCodes) = False).Any Then

                For Each AddlAdSizeCode In _InternetPackageDetails.Select(Function(Entity) Entity.InternetPackageDetail.AdditionalAdSizeCodes).Distinct.ToList

                    If String.IsNullOrWhiteSpace(AddlAdSizeCode) = False Then

                        AdSizes = AddlAdSizeCode.Split(",")

                        For Each AdSize In AdSizes

                            If AdSizeCodes.Contains(AdSize) = False Then

                                AdSizeCodes.Add(AdSize)

                            End If

                        Next

                    End If

                Next

            End If

            _AdditionalAdSizes = String.Join(",", (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadByMediaType(DbContext, "I")
                                                   Where AdSizeCodes.Contains(Entity.Code)
                                                   Select Entity.Description))

            'If Not Me.RequiresUpdate Then

            '    Me.RequiresUpdate = AdditionalAdSizePlacementCount > 0 AndAlso (Me.AdditionalAdSizeCount <> Me.AdditionalAdSizePlacementCount)

            'End If

        End Sub
        Public Sub ClearAdditionalAdSizePlacements()

            For Each InternetPackageDetail In _InternetPackageDetails.Where(Function(IPD) IPD.InternetPackageDetail.AdServerPlacementID.HasValue)

                InternetPackageDetail.ClearedPlacementID = InternetPackageDetail.InternetPackageDetail.AdServerPlacementID.Value
                InternetPackageDetail.InternetPackageDetail.AdServerPlacementID = Nothing

            Next

        End Sub

#End Region

    End Class

End Namespace