Namespace Database.Entities

    <System.Data.Linq.Mapping.Table(Name:="dbo.IMP_PTO_STAGING")>
    Public Class ImportPTOStaging
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportID
            BatchName
            IsOnHold
            EmployeeCode
            Category
            Description
            ActivityDate
            ActivityStart
            Duration
            Status
        End Enum

#End Region

#Region " Variables "

        Private _ImportID As Integer = 0
        Private _BatchName As String = Nothing
        Private _IsOnHold As Boolean = False
        Private _EmployeeCode As String = Nothing
        Private _Category As String = Nothing
        Private _Description As String = Nothing
        Private _ActivityDate As System.Nullable(Of DateTime) = Nothing
        Private _ActivityStart As System.Nullable(Of DateTime) = Nothing
        Private _Duration As System.Nullable(Of Decimal) = Nothing
        Private _Status As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ID", Storage:="_ImportID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DbType:="int NOT NULL IDENTITY"),
        System.ComponentModel.DisplayName("ImportID")>
        Public Property ImportID() As Integer
            Get
                ImportID = _ImportID
            End Get
            Set(ByVal value As Integer)
                _ImportID = value
            End Set
        End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="BATCH_NAME", Storage:="_BatchName", DbType:="varchar"),
		System.ComponentModel.DisplayName("BatchName"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property BatchName() As String
			Get
				BatchName = _BatchName
			End Get
			Set(ByVal value As String)
				_BatchName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ON_HOLD", Storage:="_IsOnHold", DbType:="bit"),
		System.ComponentModel.DisplayName("IsOnHold")>
		Public Property IsOnHold() As Boolean
			Get
				IsOnHold = _IsOnHold
			End Get
			Set(ByVal value As Boolean)
				_IsOnHold = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("EmployeeCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property EmployeeCode() As String
			Get
				EmployeeCode = _EmployeeCode
			End Get
			Set(ByVal value As String)
				_EmployeeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CATEGORY", Storage:="_Category", DbType:="varchar"),
		System.ComponentModel.DisplayName("Category"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property Category() As String
			Get
				Category = _Category
			End Get
			Set(ByVal value As String)
				_Category = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DESCRIPTION", Storage:="_Description", DbType:="varchar"),
		System.ComponentModel.DisplayName("Description"),
		System.ComponentModel.DataAnnotations.MaxLength(60)>
		Public Property Description() As String
			Get
				Description = _Description
			End Get
			Set(ByVal value As String)
				_Description = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ACTIVITY_DATE", Storage:="_ActivityDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("ActivityDate")>
		Public Property ActivityDate() As System.Nullable(Of DateTime)
			Get
				ActivityDate = _ActivityDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_ActivityDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ACTIVITY_START", Storage:="_ActivityStart", DbType:="datetime"),
		System.ComponentModel.DisplayName("ActvityStart")>
		Public Property ActivityStart() As System.Nullable(Of DateTime)
			Get
				ActivityStart = _ActivityStart
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_ActivityStart = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DURATION", Storage:="_Duration", DbType:="decimal"),
		System.ComponentModel.DisplayName("Duration")>
		Public Property Duration() As System.Nullable(Of Decimal)
			Get
				Duration = _Duration
			End Get
			Set(ByVal value As System.Nullable(Of Decimal))
				_Duration = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="STATUS", Storage:="_Status", DbType:="varchar"),
		System.ComponentModel.DisplayName("Status"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
