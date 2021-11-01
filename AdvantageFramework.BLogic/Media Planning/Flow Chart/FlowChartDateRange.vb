Namespace MediaPlanning.FlowChart

    Public Class FlowChartDateRange

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property StartDate() As Date
        Public ReadOnly Property EndDate() As Date

#End Region

#Region " Methods "

        Public Sub New(StartDate As Date, EndDate As Date)

            Me.StartDate = StartDate
            Me.EndDate = EndDate

        End Sub

#End Region

    End Class

End Namespace