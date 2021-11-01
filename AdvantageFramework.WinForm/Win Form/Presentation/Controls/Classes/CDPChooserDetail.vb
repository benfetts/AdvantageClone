Namespace WinForm.Presentation.Controls.Classes

    <Serializable()>
    Public Class CDPChooserDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            Client
            DivisionCode
            Division
            ProductCode
            Product
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _Client As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _Division As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Product As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Client As String
            Get
                Client = _Client
            End Get
            Set(value As String)
                _Client = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Division As String
            Get
                Division = _Division
            End Get
            Set(value As String)
                _Division = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Product As String
            Get
                Product = _Product
            End Get
            Set(value As String)
                _Product = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ClientCode As String, Client As String, Optional DivisionCode As String = Nothing, Optional Division As String = Nothing, Optional ProductCode As String = Nothing, Optional Product As String = Nothing)

            _ClientCode = ClientCode
            _Client = Client
            _DivisionCode = DivisionCode
            _Division = Division
            _ProductCode = ProductCode
            _Product = Product

        End Sub

#End Region

    End Class

End Namespace
