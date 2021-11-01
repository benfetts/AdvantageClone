Public Class CustomReportWriterForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ConnectionString As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub CustomReportWriterForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        XrDesignMdiController1.AddCommandHandler(New ReportCommandHandler(XrDesignMdiController1))

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub XrTabbedMdiManager1_AnyDocumentActivated(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs) Handles XrTabbedMdiManager1.AnyDocumentActivated

        DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).BeginSort()

        DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).SortOrder = Windows.Forms.SortOrder.Ascending
        DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).ShowComplexProperties = DevExpress.XtraReports.Design.ShowComplexProperties.Last

        DirectCast(FieldListDockPanel1_Container.Controls(0), DevExpress.XtraReports.UserDesigner.XRDesignFieldList).EndSort()

    End Sub
    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick

        'objects
        Dim SelectedObjects As IEnumerable = Nothing
        Dim AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvantageFramework.Reporting.AdvancedReportWriterReports.Alerts

        If CRUDDialog.ShowFormDialog(CRUDDialog.Type.AdvancedReportWriterReport, True, False, SelectedObjects) = System.Windows.Forms.DialogResult.OK Then

            Try

                AdvancedReportWriterReport = (From Entity In SelectedObjects _
                                              Select Entity.ID).First

            Catch ex As Exception
                AdvancedReportWriterReport = Nothing
            Finally

                Try

                    If AdvancedReportWriterReport <> Nothing Then

                        XrDesignMdiController1.OpenReport(AdvantageFramework.Reporting.Reports.CreateAdvancedReportWriterReport(AdvancedReportWriterReport))

                    End If

                Catch ex As Exception

                End Try

            End Try

        End If

    End Sub

#End Region

#End Region

End Class
