Namespace Database.Core

    <Serializable()>
    Public Class DepartmentTeam
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Description As String = Nothing
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
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
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

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal DepartmentTeam As Object)

            MyBase.SetValues(DepartmentTeam)

        End Sub

#End Region

    End Class

End Namespace