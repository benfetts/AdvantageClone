Namespace Database.Classes

    <Serializable()>
    Public Class OfficeSalesTaxAccount
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SalesTaxCode
            SalesTaxDescription
            StateTaxGLACode
            StateTaxGLDescription
            CountyTaxGLACode
            CountyTaxGLDescription
            CityTaxGLACode
            CityTaxGLDescription
        End Enum

#End Region

#Region " Variables "

        Private _OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount = Nothing
        Private _SalesTaxDescription As String = Nothing
        Private _StateTaxGLDescription As String = Nothing
        Private _CountyTaxGLDescription As String = Nothing
        Private _CityTaxGLDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount
            Get
                OfficeSalesTaxAccount = _OfficeSalesTaxAccount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Tax Code", PropertyType:=BaseClasses.PropertyTypes.SalesTaxCode)>
        Public Property SalesTaxCode() As String
            Get
                SalesTaxCode = _OfficeSalesTaxAccount.SalesTaxCode
            End Get
            Set(value As String)
                _OfficeSalesTaxAccount.SalesTaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Tax Code Description", IsReadOnlyColumn:=True)>
        Public Property SalesTaxDescription() As String
            Get
                SalesTaxDescription = _SalesTaxDescription
            End Get
            Set(value As String)
                _SalesTaxDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="State Tax", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property StateTaxGLACode() As String
            Get
                StateTaxGLACode = _OfficeSalesTaxAccount.StateTaxGLACode
            End Get
            Set(ByVal value As String)
                _OfficeSalesTaxAccount.StateTaxGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="State Tax Description", IsReadOnlyColumn:=True)>
        Public Property StateTaxGLDescription() As String
            Get
                StateTaxGLDescription = _StateTaxGLDescription
            End Get
            Set(ByVal value As String)
                _StateTaxGLDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="County Tax", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property CountyTaxGLACode() As String
            Get
                CountyTaxGLACode = _OfficeSalesTaxAccount.CountyTaxGLACode
            End Get
            Set(ByVal value As String)
                _OfficeSalesTaxAccount.CountyTaxGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="County Tax Description", IsReadOnlyColumn:=True)>
        Public Property CountyTaxGLDescription() As String
            Get
                CountyTaxGLDescription = _CountyTaxGLDescription
            End Get
            Set(ByVal value As String)
                _CountyTaxGLDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="City Tax", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property CityTaxGLACode() As String
            Get
                CityTaxGLACode = _OfficeSalesTaxAccount.CityTaxGLACode
            End Get
            Set(ByVal value As String)
                _OfficeSalesTaxAccount.CityTaxGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="City Tax Description", IsReadOnlyColumn:=True)>
        Public Property CityTaxGLDescription() As String
            Get
                CityTaxGLDescription = _CityTaxGLDescription
            End Get
            Set(ByVal value As String)
                _CityTaxGLDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OfficeSalesTaxAccount = New AdvantageFramework.Database.Entities.OfficeSalesTaxAccount

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount)

            _OfficeSalesTaxAccount = OfficeSalesTaxAccount

            _SalesTaxDescription = OfficeSalesTaxAccount.SalesTax.Description

            _StateTaxGLDescription = Me.GetGLDescription(DbContext, OfficeSalesTaxAccount.StateTaxGLACode)
            _CountyTaxGLDescription = Me.GetGLDescription(DbContext, OfficeSalesTaxAccount.CountyTaxGLACode)
            _CityTaxGLDescription = Me.GetGLDescription(DbContext, OfficeSalesTaxAccount.CityTaxGLACode)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.SalesTaxCode

        End Function
        Public Function GetGLDescription(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GLACode As String)

            Dim GLDescription As String = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, GLACode)

            If GeneralLedgerAccount IsNot Nothing Then

                GLDescription = GeneralLedgerAccount.Description

            End If

            GetGLDescription = GLDescription

        End Function

#End Region

    End Class

End Namespace