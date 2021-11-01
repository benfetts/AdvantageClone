Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.EMP_TIME_STAGING_IDS")>
    Public Class EmployeeTimeStagingIDs

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OutlookID
            GoogleID
            CalendarID
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _OutlookID As String = Nothing
        Private _GoogleID As String = Nothing
        Private _CalendarID As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ET_ID_STAGING_ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OUTLOOK_ID", Storage:="_OutlookID", DbType:="varchar")>
        Public Property OutlookID() As String
            Get
                OutlookID = _OutlookID
            End Get
            Set(ByVal value As String)
                _OutlookID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GOOGLE_ID", Storage:="_GoogleID", DbType:="varchar")>
        Public Property GoogleID() As String
            Get
                GoogleID = _GoogleID
            End Get
            Set(ByVal value As String)
                _GoogleID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CALENDAR_ID", Storage:="_CalendarID", DbType:="varchar")>
        Public Property CalendarID() As String
            Get
                CalendarID = _CalendarID
            End Get
            Set(ByVal value As String)
                _CalendarID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
