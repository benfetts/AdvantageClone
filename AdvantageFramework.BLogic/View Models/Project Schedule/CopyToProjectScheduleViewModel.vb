Namespace ViewModels.ProjectSchedule

	Public Class CopyToProjectScheduleViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property PageSize As Integer
		Public Property IsValid As Boolean
		Public Property JobNumber As Integer
		Public Property JobComponentNumber As Short
		Public Property JobTypeCode As String
		Public Property JobComponents As Generic.List(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel)

#Region "  Form Entry"

		<System.ComponentModel.DisplayName("Add schedule if schedule doesn't exist")>
		Public Property AddScheduleIfScheduleDoesntExist As Boolean
		<System.ComponentModel.DisplayName("Update schedule if exist")>
		Public Property UpdateScheduleIfExists As Boolean
		<System.ComponentModel.DisplayName("Include schedule header data")>
		Public Property IncludeScheduleHeaderData As Boolean
		<System.ComponentModel.DisplayName("Include schedule detail data")>
		Public Property IncludeScheduleDetailData As Boolean
		<System.ComponentModel.DisplayName("Include schedule dates")>
		Public Property IncludeScheduleDetailScheduleDates As Boolean
		<System.ComponentModel.DisplayName("Include employee assignments")>
		Public Property IncludeScheduleDetailEmployeeAssignments As Boolean
		<System.ComponentModel.DisplayName("Include task comments")>
		Public Property IncludeScheduleDetailTaskComments As Boolean
		<System.ComponentModel.DisplayName("Include due date comments")>
		Public Property IncludeScheduleDetailDueDateComments As Boolean
		<System.ComponentModel.DisplayName("Update component budget")>
		Public Property IncludeScheduleRevsionComments As Boolean
		<System.ComponentModel.DisplayName("Include Revision Comments")>
		Public Property UpdateComponentBudget As Boolean

#End Region

#End Region

#Region " Methods "

		Public Sub New()

			JobComponents = New Generic.List(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel)

		End Sub

#End Region

	End Class

End Namespace
