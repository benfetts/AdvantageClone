Namespace Database.Entities

    <Table("MARKET")>
    Public Class Market
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
            NielsenTVCode
            NielsenTVDMACode
            NielsenRadioCode
            NielsenBlackRadioCode
            NielsenHispanicRadioCode
            IsCable
            EastlanRadioCode
            EastlanBlackRadioCode
            EastlanHispanicRadioCode
            ComscoreMarketNumber
            ComscoreNewMarketNumber
            CountryID
            StateID
            IsPuertoRico
            InternetOrders
            JobComponents
            MagazineOrders
            NewspaperOrders
            OutOfHomeOrders
            RadioOrders
            TVOrders
            Partners
            Vendors
            MediaPlanDetailLevelLineTags
            RadioOrderLegacies
            TVOrderLegacies
            DigitalResults
            Country
            State
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Code() As String
        <MaxLength(40)>
        <Column("MARKET_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
        <Column("NIELSEN_TV_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenTVCode As String
        <Column("NIELSEN_TV_DMA_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Nielsen TV DMA Code")>
        Public Property NielsenTVDMACode As String
        <Column("NIELSEN_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenRadioCode As String
        <Column("NIELSEN_BLACK_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenBlackRadioCode As String
        <Column("NIELSEN_HISPANIC_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenHispanicRadioCode As String
        <Column("IS_CABLE")>
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsCable As Boolean
        <Column("EASTLAN_RADIO_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=1, UseMaxValue:=True, MaxValue:=999)>
        Public Property EastlanRadioCode As Nullable(Of Short)
        <Column("EASTLAN_BLACK_RADIO_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=1, UseMaxValue:=True, MaxValue:=999)>
        Public Property EastlanBlackRadioCode As Nullable(Of Short)
        <Column("EASTLAN_HISPANIC_RADIO_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=1, UseMaxValue:=True, MaxValue:=999)>
        Public Property EastlanHispanicRadioCode As Nullable(Of Short)
        <Column("COMSCORE_MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Comscore", IsReadOnlyColumn:=True)>
        Public Property ComscoreMarketNumber As Nullable(Of Short)
        <Column("COMSCORE_NEW_MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Comscore", IsReadOnlyColumn:=True)>
        Public Property ComscoreNewMarketNumber As Nullable(Of Short)
        <Column("COUNTRY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Country", IsAutoFillProperty:=True)>
        Public Property CountryID As Nullable(Of Integer)
        <Column("STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="State/Province")>
        Public Property StateID As Nullable(Of Integer)
        <Required>
        <Column("IS_PUERTO_RICO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsPuertoRico() As Boolean

        Public Overridable Property InternetOrders As ICollection(Of Database.Entities.InternetOrder)
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
        Public Overridable Property MagazineOrders As ICollection(Of Database.Entities.MagazineOrder)
        Public Overridable Property NewspaperOrders As ICollection(Of Database.Entities.NewspaperOrder)
        Public Overridable Property OutOfHomeOrders As ICollection(Of Database.Entities.OutOfHomeOrder)
        Public Overridable Property RadioOrders As ICollection(Of Database.Entities.RadioOrder)
        Public Overridable Property TVOrders As ICollection(Of Database.Entities.TVOrder)
        Public Overridable Property Partners As ICollection(Of Database.Entities.Partner)
        Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)
        Public Overridable Property RadioOrderLegacies As ICollection(Of Database.Entities.RadioOrderLegacy)
        Public Overridable Property TVOrderLegacies As ICollection(Of Database.Entities.TVOrderLegacy)
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property Country As Database.Entities.Country
        Public Overridable Property State As Database.Entities.State

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Market.Properties.Code.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Markets
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique code."

                        End If

                    End If

                    'Case AdvantageFramework.Database.Entities.Market.Properties.EastlanRadioCode.ToString

                    '    PropertyValue = Value

                    '    If Not IsNumeric(PropertyValue) OrElse PropertyValue <= 0 Then

                    '        IsValid = False

                    '        ErrorText = "Please enter a numeric value greater than zero."

                    '    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
