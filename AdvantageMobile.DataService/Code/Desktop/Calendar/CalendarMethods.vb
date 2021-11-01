Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports AdvantageFramework.Security.Classes

Namespace AdvantageMobile.DataService.Calendar

    <System.Serializable()> Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _DataEntities As DataEntities
        Private Property _DataServiceUser As DataServiceUser
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""

#End Region

#Region " Methods "

        Public Function GetEmployeeSchedule(ByVal EmployeeCode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of CalendarItem)

            Dim DateStartDate As Date = CType(CType(StartDate, Date).ToShortDateString(), Date)
            Dim DateEndDate As Date = CType(CType(EndDate, Date).ToShortDateString(), Date)

            SearchValue = SearchValue.Trim().ToUpper()

            If SearchValue = "" Then
                GetEmployeeSchedule = (From CalendarItem In Me._DataEntities.GetCalendarItems(_UserCode, EmployeeCode, "", "", "", "", "", "", "", DateStartDate, DateEndDate, "", "N", "N", "", "D", "", 1, 1, 1, 1, "", "", 0, 0, "", 1, False)
                                       Select CalendarItem).OrderByDescending(Function(CalendarItem) CalendarItem.Priority).ThenBy(Function(CalendarItem) CalendarItem.StartDate).ThenBy(Function(CalendarItem) CalendarItem.StartTime).Skip(Skip).Take(Take)
            Else
                GetEmployeeSchedule = (From CalendarItem In Me._DataEntities.GetCalendarItems(_UserCode, EmployeeCode, "", "", "", "", "", "", "", DateStartDate, DateEndDate, "", "N", "N", "", "D", "", 1, 1, 1, 1, "", "", 0, 0, "", 1, False)
                                       Where CalendarItem.TaskNonTaskDisplay.ToUpper().Contains(SearchValue)
                                       Select CalendarItem).OrderByDescending(Function(CalendarItem) CalendarItem.Priority).ThenBy(Function(CalendarItem) CalendarItem.StartDate).ThenBy(Function(CalendarItem) CalendarItem.StartTime).Skip(Skip).Take(Take)
            End If

        End Function

        Sub New(ByVal DataSource As DataEntities, ByVal CurrentDataServiceUser As DataServiceUser)

            Me._DataEntities = DataSource
            Me._DataServiceUser = CurrentDataServiceUser
            Me._ConnectionString = CurrentDataServiceUser.ConnectionString
            Me._UserCode = Me._DataServiceUser.UserCode

        End Sub

#End Region

    End Class

End Namespace
