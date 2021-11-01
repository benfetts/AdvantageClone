Namespace Database.Core

    <Serializable()>
    Public Class Campaign
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            IsClosed
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _IsClosed As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsClosed() As Nullable(Of Short)
            Get
                IsClosed = _IsClosed
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsClosed = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Campaign As Object)

            MyBase.SetValues(Campaign)

        End Sub

#End Region

    End Class

End Namespace
