Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.EMP_TIME_STAGING")>
    Public Class EmployeeTimeStaging

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            StartDate
            EndDate
            StartTime
            EndTime
            Hours
            EmployeeCode
            OutlookID
            GoogleID
            CalendarID
            Comments
        End Enum

#End Region

#Region " Variables "

        Private _ID As Long = 0
        Private _StartDate As DateTime = Nothing
        Private _EndDate As System.Nullable(Of DateTime) = Nothing
        Private _StartTime As System.Nullable(Of DateTime) = Nothing
        Private _EndTime As System.Nullable(Of DateTime) = Nothing
        Private _Hours As System.Nullable(Of Decimal) = 0
        Private _EmployeeCode As String = Nothing
        Private _OutlookID As String = Nothing
        Private _GoogleID As String = Nothing
        Private _CalendarID As String = Nothing
        Private _Comments As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ET_ID_STAGING", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY")>
        Public Property ID() As Long
            Get
                ID = _ID
            End Get
            Set(ByVal value As Long)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_DATE", Storage:="_StartDate", DbType:="smalldatetime")>
        Public Property StartDate() As DateTime
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As DateTime)
                _StartDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_DATE", Storage:="_EndDate", DbType:="smalldatetime")>
        Public Property EndDate() As System.Nullable(Of DateTime)
            Get
                EndDate = _EndDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_TIME", Storage:="_StartTime", DbType:="smalldatetime")>
        Public Property StartTime() As System.Nullable(Of DateTime)
            Get
                StartTime = _StartTime
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartTime = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_TIME", Storage:="_EndTime", DbType:="smalldatetime")>
        Public Property EndTime() As System.Nullable(Of DateTime)
            Get
                EndTime = _EndTime
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _EndTime = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HOURS", Storage:="_Hours", DbType:="decimal")>
        Public Property Hours() As System.Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DbType:="varchar")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
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
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMMENTS", Storage:="_Comments", DbType:="text")>
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
