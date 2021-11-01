Public Class ReportCommandHandler
    Implements DevExpress.XtraReports.UserDesigner.ICommandHandler

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _XRDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New(ByVal XrDesignMdiController As DevExpress.XtraReports.UserDesigner.XRDesignMdiController)

        _XRDesignMdiController = XrDesignMdiController

    End Sub
    Public Overridable Function CanHandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByRef useNextHandler As Boolean) As Boolean Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.CanHandleCommand

        If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then

            CanHandleCommand = True

        ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then

            CanHandleCommand = True

        Else

            CanHandleCommand = False

        End If

    End Function
    Public Overridable Sub HandleCommand(ByVal ReportCommand As DevExpress.XtraReports.UserDesigner.ReportCommand, ByVal Args() As Object) Implements DevExpress.XtraReports.UserDesigner.ICommandHandler.HandleCommand

        'objects
        Dim File As String = ""
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

        If ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.NewReport Then

            _XRDesignMdiController.OpenReport(New XtraReportUDR)

        ElseIf ReportCommand = DevExpress.XtraReports.UserDesigner.ReportCommand.OpenFile Then

            File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen(, AdvantageFramework.FileSystem.LoadFileFilterString(AdvantageFramework.FileSystem.FileFilters.REPX), )

            If File <> "" AndAlso My.Computer.FileSystem.FileExists(File) Then

                XtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile(File, True)

                If TypeOf XtraReport Is AdvantageFramework.Reporting.Reports.IUserDefinedReport Then

                    _XRDesignMdiController.OpenReport(XtraReport)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a Advantage Custom Report!")

                End If

            End If

        End If

    End Sub

#End Region

End Class

