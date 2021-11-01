Namespace Database.Core

    <Serializable()>
    Public Class Product
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            ClientCode
            DivisionCode
            OfficeCode
            Name
            IsActive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _Name As String = Nothing
        Private _IsActive As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
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
        Public Property IsActive() As Nullable(Of Short)
            Get
                IsActive = _IsActive
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsActive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Product As Object)

            MyBase.SetValues(Product)

        End Sub

#End Region

    End Class

End Namespace