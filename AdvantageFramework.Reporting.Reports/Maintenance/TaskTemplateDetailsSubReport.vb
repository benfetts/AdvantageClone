Namespace Maintenance

    Public Class TaskTemplateDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

        Private Sub Label_Task_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Task.BeforePrint

            'objects
            Dim TaskTemplateDetail As AdvantageFramework.Database.Views.TaskTemplateDetail = Nothing
            Dim TaskString As String = ""

            Try

                TaskTemplateDetail = Me.GetCurrentRow

            Catch ex As Exception
                TaskTemplateDetail = Nothing
            End Try

            If TaskTemplateDetail IsNot Nothing Then

                TaskString = String.Format("{0} - {1}", TaskTemplateDetail.TaskCode, TaskTemplateDetail.TaskDescription)

            End If

            Label_Task.Text = TaskString

        End Sub

    End Class

End Namespace
