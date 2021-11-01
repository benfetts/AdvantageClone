Imports System.Drawing.Printing

Namespace Employee

    Public Class EmployeeExpenseReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _PrintApproverName As Boolean = False
        Private _ExcludeEmployeeSignature As Boolean = False
        Private _ExcludeSupervisorSignature As Boolean = False
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public Property PrintApproverName As Boolean
            Get
                PrintApproverName = _PrintApproverName
            End Get
            Set(value As Boolean)
                _PrintApproverName = value
            End Set
        End Property
        Public Property ExcludeEmployeeSignature As Boolean
            Get
                ExcludeEmployeeSignature = _ExcludeEmployeeSignature
            End Get
            Set(value As Boolean)
                _ExcludeEmployeeSignature = value
            End Set
        End Property
        Public Property ExcludeSupervisorSignature As Boolean
            Get
                ExcludeSupervisorSignature = _ExcludeSupervisorSignature
            End Get
            Set(value As Boolean)
                _ExcludeSupervisorSignature = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeExpenseReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub SubreportExpenseItems_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubreportExpenseItems.BeforePrint

            'objects
            Dim InvoiceNumber As Integer = Nothing

            Try

                InvoiceNumber = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)).FirstOrDefault.InvoiceNumber

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SubreportExpenseItems.ReportSource.DataSource = AdvantageFramework.Reporting.Database.Procedures.ExpenseReportDetailReport.Load(ReportingDbContext, InvoiceNumber).OrderBy(Function(Item) Item.ItemDate).ToList

                End Using

            Catch ex As Exception
                SubreportExpenseItems.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub PictureBoxEmployeeSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PictureBoxEmployeeSignature.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If _ExcludeEmployeeSignature = False Then

                Try

                    ExpenseReport = Me.GetCurrentRow

                Catch ex As Exception
                    ExpenseReport = Nothing
                End Try

                If ExpenseReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.SignatureImage IsNot Nothing Then

                                Try

                                    MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                    PictureBoxEmployeeSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                Catch ex As Exception

                                End Try

                            Else

                                PictureBoxEmployeeSignature.Image = Nothing

                            End If

                        End If

                    End Using

                End If

            Else

                PictureBoxEmployeeSignature.Image = Nothing

            End If

        End Sub
        Private Sub LabelSignatureDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelSignatureDate.BeforePrint

            If _ExcludeEmployeeSignature Then

                LabelSignatureDate.Text = ""

            Else

                LabelSignatureDate.Text = System.DateTime.Today.ToShortDateString

            End If

        End Sub
        Private Sub LabelApproverSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelApproverSignature.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ApproverName As String = ""

            LabelApproverSignature.Lines = Nothing

            If _PrintApproverName Then

                Try

                    ExpenseReport = Me.GetCurrentRow

                Catch ex As Exception
                    ExpenseReport = Nothing
                End Try

                If ExpenseReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            If String.IsNullOrEmpty(ExpenseReport.SubmittedTo) = False Then

                                ApproverName = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.SubmittedTo).ToString

                            Else

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                                If Employee.AlternateApproverCode IsNot Nothing Then

                                    ApproverName = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.AlternateApproverCode).ToString

                                ElseIf Employee.SupervisorEmployeeCode IsNot Nothing Then

                                    ApproverName = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode).ToString

                                Else

                                    ApproverName = ""

                                End If

                            End If

                        Catch ex As Exception
                            ApproverName = ""
                        End Try

                    End Using

                End If

            End If

            If ApproverName <> "" Then

                LabelApproverSignature.Multiline = True
                LabelApproverSignature.Lines = {ApproverName, "", "Approver Signature / Date"}

            Else

                LabelApproverSignature.Lines = {"Approver Signature / Date"}

            End If

        End Sub
        Private Sub LabelEmployee_Employee_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelEmployee_Employee.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim EmployeeName As String = ""

            Try

                ExpenseReport = Me.GetCurrentRow

                EmployeeName = ExpenseReport.EmployeeCode

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString & " (" & Employee.Code & ")"

                    End If

                End Using

            Catch ex As Exception

                Try

                    EmployeeName = ExpenseReport.EmployeeCode

                Catch exc As Exception
                    EmployeeName = ""
                End Try

            End Try

            LabelEmployee_Employee.Text = EmployeeName

        End Sub
        Private Sub LabelStatus_Status_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelStatus_Status.BeforePrint

            LabelStatus_Status.Text = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(Me.GetCurrentRow).ToString)

        End Sub

        Private Sub PictureBoxApproverSignature_BeforePrint(sender As Object, e As PrintEventArgs) Handles PictureBoxApproverSignature.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If _ExcludeSupervisorSignature = False Then

                Try

                    ExpenseReport = Me.GetCurrentRow

                Catch ex As Exception
                    ExpenseReport = Nothing
                End Try

                If ExpenseReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, ExpenseReport.ApprovedBy)

                        If Employee IsNot Nothing Then

                            If Employee.SignatureImage IsNot Nothing Then

                                Try

                                    MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                    PictureBoxApproverSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                Catch ex As Exception

                                End Try

                            Else

                                PictureBoxApproverSignature.Image = Nothing

                            End If

                        End If

                    End Using

                End If

            Else

                PictureBoxApproverSignature.Image = Nothing

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace
