Namespace ViewModels.ProjectSchedule

	Public Class CopyToProjectScheduleJobComponentViewModel

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			OfficeCode
			OfficeName
			ClientCode
			ClientName
			DivisionCode
			DivisionName
			ProductCode
			ProductDescription
			JobNumber
			JobDescription
			JobComponentNumber
			JobComponentDescription
			SalesClassCode
			SalesClassDescription
			JobTypeCode
            JobTypeDescription
            PromotionType
            IsOpen
            JobProcessControl
            CopyFromJobNumber
            CopyFromJobComponentNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property Selected As Boolean
		Public Property ID() As Integer
		Public Property OfficeCode() As String
		Public Property OfficeName() As String
		Public Property ClientCode() As String
		Public Property ClientName() As String
		Public Property DivisionCode() As String
		Public Property DivisionName() As String
		Public Property ProductCode() As String
		Public Property ProductDescription() As String
		Public Property JobNumber() As Integer
		Public Property JobDescription() As String
		Public Property JobComponentNumber() As Short
		Public Property JobComponentDescription() As String
		Public Property SalesClassCode() As String
		Public Property SalesClassDescription() As String
		Public Property JobTypeCode() As String
        Public Property JobTypeDescription() As String
        Public Property PromotionType() As String
        Public Property IsOpen() As Integer
		Public Property JobProcessControl() As Nullable(Of Short)
		Public Property CopyFromJobNumber As Nullable(Of Integer)
		Public Property CopyFromJobComponentNumber As Nullable(Of Short)

#End Region

#Region " Methods "

		Public Sub New()



		End Sub

#End Region

	End Class

End Namespace
