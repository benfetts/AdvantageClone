Namespace Database.Core

    <Serializable()>
    Public Class Division
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            ClientCode
            Name
            IsActive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _ClientCode As String = Nothing
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
        Public Sub New(ByVal Division As Object)

            MyBase.SetValues(Division)

        End Sub

#End Region

    End Class

End Namespace