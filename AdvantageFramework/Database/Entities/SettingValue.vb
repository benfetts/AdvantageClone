Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.AGY_SETTINGS_LOOKUP")>
    Public Class SettingValue
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SettingCode
            DisplayText
            Value
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _SettingCode As String = ""
        Private _DisplayText As String = ""
        Private _Value As Object = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOOKUP_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_CODE", Storage:="_SettingCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Setting Code"),
		System.ComponentModel.DataAnnotations.MaxLength(20)>
		Public Property SettingCode() As String
			Get
				SettingCode = _SettingCode
			End Get
			Set(ByVal value As String)
				_SettingCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOOKUP_DISPLAY", Storage:="_DisplayText", DbType:="varchar"),
		System.ComponentModel.DisplayName("Display Text"),
		System.ComponentModel.DataAnnotations.MaxLength(250)>
		Public Property DisplayText() As String
            Get
                DisplayText = _DisplayText
            End Get
            Set(ByVal value As String)
                _DisplayText = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOOKUP_VALUE", Storage:="_Value", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("Value")> _
        Public Property Value() As Object
            Get
                Value = _Value
            End Get
            Set(ByVal value As Object)
                _Value = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DisplayText

        End Function

#End Region

    End Class

End Namespace
