Imports System.ComponentModel.DataAnnotations

Namespace ViewModels

    Public Class JobForecastModel

        <Required>
        Public Property JobForecastID As Integer
        Public Property JobForecastRevisionID As Integer
        Public Property JobComponents As Generic.List(Of JobComponent)

        Public Sub New()

            Me.JobComponents = New Generic.List(Of JobComponent)

        End Sub

        Public Class JobComponent

            Public Property JobNumber As Integer
            Public Property JobComponentNumber As Short

        End Class

        Public Class ActualizeSettings

            Public Property Components As Generic.List(Of JobComponent)
            <Required(AllowEmptyStrings:=False, ErrorMessage:="Please enter a valid post period.")>
            <Display(Name:="Post Period")>
            Public Property PostPeriodCode As String
            Public Property RollForwardBalances As Boolean

        End Class

    End Class

End Namespace
