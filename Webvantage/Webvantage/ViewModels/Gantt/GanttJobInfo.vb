Namespace ViewModels.Gantt
    Public Class GanttJobInfo
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property Index As Integer
        Public Property JobComponentNumber As Integer
        Public Property JobNumber As Integer
        Public Property JobDescription As String = ""
        Public Property StartDate As Date?
        Public Property IsRelatedJob As Boolean = False
        Public Property HasNullTaskDates As Boolean = False
        Public Property CalculatedHeight As Integer = 0
#End Region

#Region " Methods "

#End Region

    End Class
End Namespace