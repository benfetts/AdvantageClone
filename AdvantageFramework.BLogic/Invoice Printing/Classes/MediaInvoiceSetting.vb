Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaInvoiceHeaderFooterSetting
            MediaInvoiceMagazineSetting
            MediaInvoiceNewspaperSetting
            MediaInvoiceInternetSetting
            MediaInvoiceOutdoorSetting
            MediaInvoiceRadioSetting
            MediaInvoiceTVSetting
        End Enum

#End Region

#Region " Variables "

        Private _MediaInvoiceHeaderFooterSetting As MediaInvoiceHeaderFooterSetting = Nothing
        Private _MediaInvoiceMagazineSetting As MediaInvoiceMagazineSetting = Nothing
        Private _MediaInvoiceNewspaperSetting As MediaInvoiceNewspaperSetting = Nothing
        Private _MediaInvoiceInternetSetting As MediaInvoiceInternetSetting = Nothing
        Private _MediaInvoiceOutdoorSetting As MediaInvoiceOutdoorSetting = Nothing
        Private _MediaInvoiceRadioSetting As MediaInvoiceRadioSetting = Nothing
        Private _MediaInvoiceTVSetting As MediaInvoiceTVSetting = Nothing

        Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceHeaderFooterSetting As MediaInvoiceHeaderFooterSetting
            Get
                MediaInvoiceHeaderFooterSetting = _MediaInvoiceHeaderFooterSetting
            End Get
            Set(ByVal value As MediaInvoiceHeaderFooterSetting)
                _MediaInvoiceHeaderFooterSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceMagazineSetting As MediaInvoiceMagazineSetting
            Get
                MediaInvoiceMagazineSetting = _MediaInvoiceMagazineSetting
            End Get
            Set(ByVal value As MediaInvoiceMagazineSetting)
                _MediaInvoiceMagazineSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceNewspaperSetting As MediaInvoiceNewspaperSetting
            Get
                MediaInvoiceNewspaperSetting = _MediaInvoiceNewspaperSetting
            End Get
            Set(ByVal value As MediaInvoiceNewspaperSetting)
                _MediaInvoiceNewspaperSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceInternetSetting As MediaInvoiceInternetSetting
            Get
                MediaInvoiceInternetSetting = _MediaInvoiceInternetSetting
            End Get
            Set(ByVal value As MediaInvoiceInternetSetting)
                _MediaInvoiceInternetSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceOutdoorSetting As MediaInvoiceOutdoorSetting
            Get
                MediaInvoiceOutdoorSetting = _MediaInvoiceOutdoorSetting
            End Get
            Set(ByVal value As MediaInvoiceOutdoorSetting)
                _MediaInvoiceOutdoorSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceRadioSetting As MediaInvoiceRadioSetting
            Get
                MediaInvoiceRadioSetting = _MediaInvoiceRadioSetting
            End Get
            Set(ByVal value As MediaInvoiceRadioSetting)
                _MediaInvoiceRadioSetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property MediaInvoiceTVSetting As MediaInvoiceTVSetting
            Get
                MediaInvoiceTVSetting = _MediaInvoiceTVSetting
            End Get
            Set(ByVal value As MediaInvoiceTVSetting)
                _MediaInvoiceTVSetting = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _MediaInvoiceHeaderFooterSetting = New MediaInvoiceHeaderFooterSetting()
            _MediaInvoiceMagazineSetting = New MediaInvoiceMagazineSetting()
            _MediaInvoiceNewspaperSetting = New MediaInvoiceNewspaperSetting()
            _MediaInvoiceInternetSetting = New MediaInvoiceInternetSetting()
            _MediaInvoiceOutdoorSetting = New MediaInvoiceOutdoorSetting()
            _MediaInvoiceRadioSetting = New MediaInvoiceRadioSetting()
            _MediaInvoiceTVSetting = New MediaInvoiceTVSetting()

        End Sub
        Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            _MediaInvoiceHeaderFooterSetting = New MediaInvoiceHeaderFooterSetting(MediaInvoiceDefault)
            _MediaInvoiceMagazineSetting = New MediaInvoiceMagazineSetting(MediaInvoiceDefault)
            _MediaInvoiceNewspaperSetting = New MediaInvoiceNewspaperSetting(MediaInvoiceDefault)
            _MediaInvoiceInternetSetting = New MediaInvoiceInternetSetting(MediaInvoiceDefault)
            _MediaInvoiceOutdoorSetting = New MediaInvoiceOutdoorSetting(MediaInvoiceDefault)
            _MediaInvoiceRadioSetting = New MediaInvoiceRadioSetting(MediaInvoiceDefault)
            _MediaInvoiceTVSetting = New MediaInvoiceTVSetting(MediaInvoiceDefault)

            _MediaInvoiceDefault = MediaInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            _MediaInvoiceHeaderFooterSetting = New MediaInvoiceHeaderFooterSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceMagazineSetting = New MediaInvoiceMagazineSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceNewspaperSetting = New MediaInvoiceNewspaperSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceInternetSetting = New MediaInvoiceInternetSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceOutdoorSetting = New MediaInvoiceOutdoorSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceRadioSetting = New MediaInvoiceRadioSetting(InvoicePrintingMediaSetting)
            _MediaInvoiceTVSetting = New MediaInvoiceTVSetting(InvoicePrintingMediaSetting)

            _InvoicePrintingMediaSetting = InvoicePrintingMediaSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                GetEntity = _MediaInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _MediaInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                Save(_InvoicePrintingMediaSetting)

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                Save(_MediaInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            _MediaInvoiceHeaderFooterSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceMagazineSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceNewspaperSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceInternetSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceOutdoorSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceRadioSetting.Save(MediaInvoiceDefault)
            _MediaInvoiceTVSetting.Save(MediaInvoiceDefault)

        End Sub
        Public Sub Save(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            _MediaInvoiceHeaderFooterSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceMagazineSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceNewspaperSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceInternetSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceOutdoorSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceRadioSetting.Save(InvoicePrintingMediaSetting)
            _MediaInvoiceTVSetting.Save(InvoicePrintingMediaSetting)

        End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
