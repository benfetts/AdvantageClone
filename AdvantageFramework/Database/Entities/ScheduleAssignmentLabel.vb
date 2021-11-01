Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table()>
    Public Class ScheduleAssignmentLabel
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SettingCode
            SettingValue
        End Enum

#End Region

#Region " Variables "

        Private _SettingCode As String = ""
        Private _SettingValue As String = ""

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_CODE", Storage:="_SettingCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("SettingCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SettingCode() As String
			Get
				SettingCode = _SettingCode
			End Get
			Set(ByVal value As String)
				_SettingCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AGY_SETTINGS_VALUE", Storage:="_SettingValue", DbType:="varchar"),
		System.ComponentModel.DisplayName("SettingValue"),
		System.ComponentModel.DataAnnotations.MaxLength(40)>
		Public Property SettingValue() As String
            Get
                SettingValue = _SettingValue
            End Get
            Set(ByVal value As String)
                _SettingValue = value
            End Set
        End Property

#End Region

#Region " Methods "

#End Region

    End Class

End Namespace

