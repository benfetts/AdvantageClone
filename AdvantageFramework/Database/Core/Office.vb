Namespace Database.Core

    <Serializable()>
    Public Class Office
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _IsInactive As Nullable(Of Short) = Nothing

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
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Nullable(Of Short))
                _IsInactive = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Office As Object)

            MyBase.SetValues(Office)

        End Sub

#End Region

    End Class

End Namespace