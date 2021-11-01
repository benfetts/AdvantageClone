Namespace Database.Entities
    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AGY_SETTINGS_APP")>
    Public Class SettingModule
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _Description As String = ""

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_APP", Storage:="_ID", DBType:="smallint"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="APP_DESC", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
