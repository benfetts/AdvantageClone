Namespace Security.Database.Classes

    <Serializable()>
    Public Class SQLLogin

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            HasBeenAddedToDatabase
        End Enum

#End Region

#Region " Variables "

        Private _DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
        Private _ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser = Nothing
        Private _Name As String = String.Empty
        Private _ID As Integer = 0
        Private _HasBeenAddedToDatabase As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get

                If _DatabaseSQLUser IsNot Nothing Then

                    ID = _DatabaseSQLUser.ID

                ElseIf _ServerSQLUser IsNot Nothing Then

                    ID = _ServerSQLUser.ID

                Else

                    ID = _ID

                End If

            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Name() As String
            Get
                Name = _Name
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property HasBeenAddedToDatabase() As Boolean
            Get

                If _DatabaseSQLUser IsNot Nothing Then

                    HasBeenAddedToDatabase = True

                ElseIf _ServerSQLUser IsNot Nothing Then

                    HasBeenAddedToDatabase = False

                Else

                    HasBeenAddedToDatabase = _HasBeenAddedToDatabase

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ID As Integer, Name As String, HasBeenAddedToDatabase As Boolean)

            _ID = ID
            _Name = Name
            _HasBeenAddedToDatabase = HasBeenAddedToDatabase

        End Sub
        Public Sub New(ByVal DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser)

            _DatabaseSQLUser = DatabaseSQLUser
            _Name = DatabaseSQLUser.Name

        End Sub
        Public Sub New(ByVal ServerSQLUser As AdvantageFramework.Security.Database.Views.ServerSQLUser)

            _ServerSQLUser = ServerSQLUser
            _Name = ServerSQLUser.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Name

        End Function

#End Region

    End Class

End Namespace
