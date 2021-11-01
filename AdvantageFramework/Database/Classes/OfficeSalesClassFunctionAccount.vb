Namespace Database.Classes

    <Serializable()>
    Public Class OfficeSalesClassFunctionAccount
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            FunctionDescription
            ProductionSalesGLACode
            ProductionSalesGLDescription
            ProductionCostOfSalesGLACode
            ProductionCostOfSalesGLDescription
        End Enum

#End Region

#Region " Variables "

        Private _OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount = Nothing
        Private _FunctionDescription As String = Nothing
        Private _ProductionSalesGLDescription As String = Nothing
        Private _ProductionCostOfSalesGLDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public ReadOnly Property OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount
            Get
                OfficeSalesClassFunctionAccount = _OfficeSalesClassFunctionAccount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _OfficeSalesClassFunctionAccount.FunctionCode
            End Get
            Set(value As String)
                _OfficeSalesClassFunctionAccount.FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.FunctionDescription)>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Sales Acct", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property ProductionSalesGLACode() As String
            Get
                ProductionSalesGLACode = _OfficeSalesClassFunctionAccount.ProductionSalesGLACode
            End Get
            Set(ByVal value As String)
                _OfficeSalesClassFunctionAccount.ProductionSalesGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Acct Description", IsReadOnlyColumn:=True)>
        Public Property ProductionSalesGLDescription() As String
            Get
                ProductionSalesGLDescription = _ProductionSalesGLDescription
            End Get
            Set(ByVal value As String)
                _ProductionSalesGLDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="COS Acct", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property ProductionCostOfSalesGLACode() As String
            Get
                ProductionCostOfSalesGLACode = _OfficeSalesClassFunctionAccount.ProductionCostOfSalesGLACode
            End Get
            Set(ByVal value As String)
                _OfficeSalesClassFunctionAccount.ProductionCostOfSalesGLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="COS Acct Description", IsReadOnlyColumn:=True)>
        Public Property ProductionCostOfSalesGLDescription() As String
            Get
                ProductionCostOfSalesGLDescription = _ProductionCostOfSalesGLDescription
            End Get
            Set(ByVal value As String)
                _ProductionCostOfSalesGLDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _OfficeSalesClassFunctionAccount = New AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount

        End Sub
        Public Sub New(ByVal OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount)

            _OfficeSalesClassFunctionAccount = OfficeSalesClassFunctionAccount

            _FunctionDescription = _OfficeSalesClassFunctionAccount.Function.Description
            _ProductionSalesGLDescription = _OfficeSalesClassFunctionAccount.GeneralLedgerAccount2.Description
            _ProductionCostOfSalesGLDescription = _OfficeSalesClassFunctionAccount.GeneralLedgerAccount.Description

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.FunctionCode

        End Function

#End Region

    End Class

End Namespace