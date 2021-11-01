Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels

Namespace Interfaces
    Public Interface IJobJacketRepository
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "

        Function CommentsRequired() As Boolean
        Function CommentsRequiredForJob(JobNumber As Integer) As Boolean
        Function CommentsRequiredForApproval() As Boolean
        Function CommentsRequiredAgencyLevel() As Boolean

        Function ValidateCDPEntry(ValidationRequest As TimesheetValidationRequest) As TimesheetValidationResult

        Function GetTimesheetTotals(ValidationRequest As TimesheetValidationRequest) As ViewModels.TimesheetTotalsResult

        Function CommentsDisplayMode() As String

        '    Function PostingPeriodClosed(SundayDate As String) As Boolean
#End Region



    End Interface
End Namespace

