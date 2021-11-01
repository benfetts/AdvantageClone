Namespace Security.Database.Classes

    <Serializable()>
    Public Class ClientContactDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            DivisionCode
            ProductCode
            Client
            Division
            Product
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Client As String = Nothing
        Private _Division As String = Nothing
        Private _Product As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Client() As String
            Get
                Client = _Client
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Division() As String
            Get
                Division = _Division
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Product() As String
            Get
                Product = _Product
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal SecurityDivision As AdvantageFramework.Security.Database.Entities.Division)

            _ClientCode = SecurityDivision.ClientCode
            _DivisionCode = SecurityDivision.Code
            _ProductCode = ""
            _Client = SecurityDivision.Client.ToString
            _Division = SecurityDivision.ToString
            _Product = Nothing

        End Sub
        Public Sub New(ByVal SecurityProduct As AdvantageFramework.Security.Database.Entities.Product)

            _ClientCode = SecurityProduct.ClientCode
            _DivisionCode = SecurityProduct.DivisionCode
            _ProductCode = SecurityProduct.Code
            _Client = SecurityProduct.Client.ToString
            _Division = SecurityProduct.Division.ToString
            _Product = SecurityProduct.ToString

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

    End Class

End Namespace
