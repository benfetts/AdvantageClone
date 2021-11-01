Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.DYNAMIC_REPORT_SET")>
    Public Class DynamicReportSettings
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DynamicReportSettingID
            DynamicReportID
            DynamicReportSettingName
            DynamicReportSettingValue
        End Enum

#End Region

#Region " Variables "

        Private _DynamicReportSettingID As Long = 0
        Private _DynamicReportID As Long = 0
        Private _DynamicReportSettingName As String = ""
        Private _DynamicReportSettingValue As Object = Nothing

#End Region

#Region " Properties "


        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DYNAMIC_REPORT_SET_ID", Storage:="_DynamicReportSettingID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property DynamicReportSettingID() As Long
            Get
                DynamicReportSettingID = _DynamicReportSettingID
            End Get
            Set(ByVal value As Long)
                _DynamicReportSettingID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DYNAMIC_REPORT_ID", Storage:="_DynamicReportID", DBType:="int NOT NULL"), _
        System.ComponentModel.DisplayName("Report ID")> _
        Public Property DynamicReportID() As Long
            Get
                DynamicReportID = _DynamicReportID
            End Get
            Set(ByVal value As Long)
                _DynamicReportID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DYNAMIC_REPORT_SET_NAME", Storage:="_DynamicReportSettingName", DbType:="varchar"),
	   System.ComponentModel.DisplayName("Description"),
	   System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property DynamicReportSettingName() As String
            Get
                DynamicReportSettingName = _DynamicReportSettingName
            End Get
            Set(ByVal value As String)
                _DynamicReportSettingName = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DYNAMIC_REPORT_SET_VALUE", Storage:="_DynamicReportSettingValue", DBType:="sql_variant"), _
        System.ComponentModel.DisplayName("Value")> _
        Public Property DynamicReportSettingValue() As Object
            Get
                DynamicReportSettingValue = _DynamicReportSettingValue
            End Get
            Set(ByVal value As Object)
                _DynamicReportSettingValue = value
            End Set
        End Property

#End Region

#Region " Methods "

#End Region

    End Class

End Namespace
