Namespace Employee

    Public Class EmployeeDetailListingWithHRReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty
        Private _SortedBy As String = ""

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
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentEmployee() As AdvantageFramework.Database.Views.Employee

            Try

                LoadCurrentEmployee = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Views.Employee)

            Catch ex As Exception
                LoadCurrentEmployee = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeDetailListingWithHRReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub Label_ReportMissingTime_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_ReportMissingTime.BeforePrint

            Try

                Label_ReportMissingTime.Text = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ReportMissingTime)).ToList _
                                                  Where Entity.Code = LoadCurrentEmployee.WeeklyTimeType.ToString _
                                                  Select Entity.Description).FirstOrDefault

            Catch ex As Exception
                Label_ReportMissingTime.Text = "Agency Default"
            End Try

        End Sub
        Private Sub SubreportDepartmentTeam_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubreportDepartmentTeam.BeforePrint

            Try

                SubreportDepartmentTeam.ReportSource.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Views.Employee)).Where(Function(Employee) Employee.Code = LoadCurrentEmployee.Code).FirstOrDefault.EmployeeDepartments.ToList

            Catch ex As Exception
                SubreportDepartmentTeam.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub CheckBox_ReceivesEmail_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_ReceivesEmail.BeforePrint

            Select Case LoadCurrentEmployee.AlertNotificationType.GetValueOrDefault(0)

                Case 1

                    CheckBox_ReceivesEmail.Checked = True

                Case 2

                    CheckBox_ReceivesEmail.Checked = False

                Case 3

                    CheckBox_ReceivesEmail.Checked = True

                Case Else

                    CheckBox_ReceivesEmail.Checked = False

            End Select

        End Sub
        Private Sub CheckBox_ReceivesAlerts_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_ReceivesAlerts.BeforePrint

            Select Case LoadCurrentEmployee.AlertNotificationType.GetValueOrDefault(0)

                Case 1, 2, 3

                    CheckBox_ReceivesAlerts.Checked = True

                Case Else

                    CheckBox_ReceivesAlerts.Checked = False

            End Select

        End Sub
        Private Sub CheckBox_EmployeeSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_EmployeeSignature.BeforePrint

            If LoadCurrentEmployee.SignatureImage IsNot Nothing Then

                CheckBox_EmployeeSignature.Checked = True

            Else

                CheckBox_EmployeeSignature.Checked = False

            End If

        End Sub
        Private Sub XrCheckBoxAdobeDigitalSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrCheckBoxAdobeDigitalSignature.BeforePrint

            If LoadCurrentEmployee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(LoadCurrentEmployee.AdobeSignatureFilePassword) = False Then

                XrCheckBoxAdobeDigitalSignature.Checked = True

            Else

                XrCheckBoxAdobeDigitalSignature.Checked = False

            End If

        End Sub
        Private Sub Label_WeeklyTimeTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_WeeklyTimeTotal.BeforePrint

            Dim TotalHours As Decimal = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Employee = DirectCast(Me.GetCurrentRow(), AdvantageFramework.Database.Views.Employee)

            TotalHours = Employee.MondayHours.GetValueOrDefault(0) + Employee.TuesdayHours.GetValueOrDefault(0) + Employee.WednesdayHours.GetValueOrDefault(0) _
                            + Employee.ThursdayHours.GetValueOrDefault(0) + Employee.FridayHours.GetValueOrDefault(0) + Employee.SaturdayHours.GetValueOrDefault(0) _
                            + Employee.SundayHours.GetValueOrDefault(0)

            Label_WeeklyTimeTotal.Text = TotalHours

        End Sub
        Private Sub Label_AlternateApproverCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_AlternateApproverCode.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If LoadCurrentEmployee.AlternateApproverCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LoadCurrentEmployee.AlternateApproverCode)

                End Using

            End If

            If Employee IsNot Nothing Then

                Label_AlternateApproverCode.Text = Employee.Code & " - " & Employee.FirstName & " " & Employee.LastName

            Else

                Label_AlternateApproverCode.Text = ""

            End If

        End Sub
        Private Sub CheckBoxNA_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBoxNA.BeforePrint

            If LoadCurrentEmployee.Status.GetValueOrDefault(0) = 0 Then

                CheckBoxNA.Checked = True

            Else

                CheckBoxNA.Checked = False

            End If

        End Sub
        Private Sub CheckBoxNonExempt_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBoxNonExempt.BeforePrint

            If LoadCurrentEmployee.Status.GetValueOrDefault(0) = 2 Then

                CheckBoxNonExempt.Checked = True

            Else

                CheckBoxNonExempt.Checked = False

            End If

        End Sub
        Private Sub CheckBoxExempt_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBoxExempt.BeforePrint

            If LoadCurrentEmployee.Status.GetValueOrDefault(0) = 1 Then

                CheckBoxExempt.Checked = True

            Else

                CheckBoxExempt.Checked = False

            End If

        End Sub
        Private Sub Label_VendorCodeCrossRef_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_VendorCodeCrossRef.BeforePrint

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If LoadCurrentEmployee.EmployeeVendorCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, LoadCurrentEmployee.EmployeeVendorCode)

                End Using

            End If

            If Vendor IsNot Nothing Then

                Label_VendorCodeCrossRef.Text = Vendor.ToString

            Else

                Label_VendorCodeCrossRef.Text = ""

            End If

        End Sub
        Private Sub Label_Supervisor_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Supervisor.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If LoadCurrentEmployee.SupervisorEmployeeCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, LoadCurrentEmployee.SupervisorEmployeeCode)

                End Using

            End If

            If Employee IsNot Nothing Then

                Label_Supervisor.Text = Employee.Code & " - " & Employee.FirstName & " " & Employee.LastName

            Else

                Label_Supervisor.Text = ""

            End If

        End Sub
        Private Sub Label_EmailAddress_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_EmailAddress.BeforePrint

            Dim Factor As Integer = Nothing
            Dim Graphics As System.Drawing.Graphics = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing

            Graphics = System.Drawing.Graphics.FromHwnd(System.IntPtr.Zero)

            If Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.HundredthsOfAnInch Then

                Graphics.PageUnit = Drawing.GraphicsUnit.Inch
                Factor = 100

            Else

                Graphics.PageUnit = Drawing.GraphicsUnit.Millimeter
                Factor = 10

            End If

            SizeF = Graphics.MeasureString(CType(sender, DevExpress.XtraReports.UI.XRLabel).Text, CType(sender, DevExpress.XtraReports.UI.XRLabel).Font)

            CType(sender, DevExpress.XtraReports.UI.XRLabel).WidthF = SizeF.Width * Factor

        End Sub
        Private Sub Label_POApprovalRule_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_POApprovalRule.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim LabelText As String = ""

            Try

                Employee = LoadCurrentEmployee()

                If Employee IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LabelText = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Load(DbContext)
                                     Where Entity.Code = Employee.PurchaseOrderApprovalRuleCode
                                     Select [Code] = Entity.Code & " - " & Entity.Description).SingleOrDefault

                    End Using

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                Label_POApprovalRule.Text = LabelText
            End Try

        End Sub
        Private Sub CheckBox_SupervisorApprovalRequired_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles CheckBox_SupervisorApprovalRequired.BeforePrint

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Checked As Boolean = False

            Try

                Employee = LoadCurrentEmployee()

                If Employee IsNot Nothing Then

                    Checked = CBool(Employee.SupervisorApprovalRequired.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_SupervisorApprovalRequired.Checked = Checked
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
