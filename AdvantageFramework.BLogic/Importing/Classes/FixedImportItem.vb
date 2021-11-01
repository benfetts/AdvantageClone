Namespace Importing.Classes

    Public Class FixedImportItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PropertyID
            PropertyName
            Begin
            [End]
            Terminated
            AccountExecutive
        End Enum

#End Region

#Region " Variables "

        Private _PropertyID As Integer = -1
        Private _PropertyName As String = ""
        Private _Begin As Integer = 0
        Private _End As Integer = 0

#End Region

#Region " Properties "

        Public Property PropertyID() As Integer
            Get
                PropertyID = _PropertyID
            End Get
            Set(ByVal value As Integer)
                _PropertyID = value
            End Set
        End Property
        Public Property PropertyName() As String
            Get
                PropertyName = _PropertyName
            End Get
            Set(ByVal value As String)
                _PropertyName = value
            End Set
        End Property
        Public Property Begin() As Integer
            Get
                Begin = _Begin
            End Get
            Set(ByVal value As Integer)
                _Begin = value
            End Set
        End Property
        Public Property [End]() As Integer
            Get
                [End] = _End
            End Get
            Set(ByVal value As Integer)
                _End = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal [Property] As [Enum], ByVal Begin As Integer, ByVal [End] As Integer)

            _PropertyID = [Enum].ToObject([Property].GetType, [Property])
            _PropertyName = [Property].ToString()
            _Begin = Begin
            _End = [End]

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.PropertyName

        End Function

#End Region

    End Class

End Namespace

