Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.MISSING_TIME_HDR")>
    Public Class MissingTime
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            LastUpdatedDate
            IsMissingTimeOnly
            StartDate
            EndDate
            ExcludeHolidaysAndWeekends
        End Enum

#End Region

#Region " Variables "

        Private _LastUpdatedDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _IsMissingTimeOnly As System.Nullable(Of Long) = 0
        Private _StartDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _EndDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _ExcludeHolidaysAndWeekends As System.Nullable(Of Long) = 0

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LAST_DATE_UPDATED", Storage:="_LastUpdatedDate", DbType:="datetime"),
		System.ComponentModel.DisplayName("Last Updated Date"),
		System.ComponentModel.DataAnnotations.MaxLength(8)>
		Public Property LastUpdatedDate() As System.Nullable(Of DateTime)
			Get
				LastUpdatedDate = _LastUpdatedDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_LastUpdatedDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="MISSING_TIME_ONLY", Storage:="_IsMissingTimeOnly", DbType:="smallint"),
		System.ComponentModel.DisplayName("Is Missing Time Only"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property IsMissingTimeOnly() As System.Nullable(Of Long)
			Get
				IsMissingTimeOnly = _IsMissingTimeOnly
			End Get
			Set(ByVal value As System.Nullable(Of Long))
				_IsMissingTimeOnly = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="START_DATE", Storage:="_StartDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Start Date"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property StartDate() As System.Nullable(Of DateTime)
			Get
				StartDate = _StartDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_StartDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="END_DATE", Storage:="_EndDate", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("End Date"),
		System.ComponentModel.DataAnnotations.MaxLength(4)>
		Public Property EndDate() As System.Nullable(Of DateTime)
			Get
				EndDate = _EndDate
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_EndDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCLUDE_HOL_WKENDS", Storage:="_ExcludeHolidaysAndWeekends", DbType:="smallint"),
		System.ComponentModel.DisplayName("Exclude Holidays And Weekends"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property ExcludeHolidaysAndWeekends() As System.Nullable(Of Long)
            Get
                ExcludeHolidaysAndWeekends = _ExcludeHolidaysAndWeekends
            End Get
            Set(ByVal value As System.Nullable(Of Long))
                _ExcludeHolidaysAndWeekends = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
