Namespace Database

    <Serializable()>
    Public Class SimpleDatabaseProfile
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ServerName
            DatabaseName
        End Enum

#End Region

#Region " Variables "

        Private _ServerName As String = Nothing
        Private _DatabaseName As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ServerName() As String
            Get
                ServerName = _ServerName
            End Get
            Set(ByVal value As String)
                _ServerName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DatabaseName() As String
            Get
                DatabaseName = _DatabaseName
            End Get
            Set(ByVal value As String)
                _DatabaseName = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Me.ServerName, "\") & Me.DatabaseName

        End Function

#End Region

    End Class

End Namespace

