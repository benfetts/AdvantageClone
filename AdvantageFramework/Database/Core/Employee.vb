Namespace Database.Core

    <Serializable()>
    Public Class Employee
        Inherits AdvantageFramework.BaseClasses.BaseCore

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            FirstName
            MiddleInitial
            LastName
            TerminationDate
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _FirstName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _LastName As String = Nothing
        Private _TerminationDate As Nullable(Of Date) = Nothing

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
        Public Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
            Set(ByVal value As String)
                _FirstName = value
            End Set
        End Property
        Public Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
            Set(ByVal value As String)
                _MiddleInitial = value
            End Set
        End Property
        Public Property LastName() As String
            Get
                LastName = _LastName
            End Get
            Set(ByVal value As String)
                _LastName = value
            End Set
        End Property
        Public Property TerminationDate() As Nullable(Of Date)
            Get
                TerminationDate = _TerminationDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _TerminationDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            If Me.MiddleInitial IsNot Nothing AndAlso Me.MiddleInitial.Trim <> "" Then

                ToString = Me.FirstName & " " & Me.MiddleInitial & ". " & Me.LastName

            Else

                ToString = Me.FirstName & " " & Me.LastName

            End If

        End Function
        Public Sub New()


        End Sub
        Public Sub New(ByVal Employee As Object)

            MyBase.SetValues(Employee)

        End Sub

#End Region

    End Class

End Namespace