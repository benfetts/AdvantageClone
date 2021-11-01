Namespace Employee

    Public Class EmployeeDetailListingReport

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

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub EmployeeDetailListingReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Function LoadCurrentEmployee() As AdvantageFramework.Database.Views.Employee

            Try

                LoadCurrentEmployee = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Views.Employee)

            Catch ex As Exception
                LoadCurrentEmployee = Nothing
            End Try

        End Function
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub Label_ReportMissingTime_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_ReportMissingTime.BeforePrint

            Try

                Label_ReportMissingTime.Text = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ReportMissingTime)).ToList
                                                Where Entity.Code = LoadCurrentEmployee.WeeklyTimeType.ToString
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

                Case 1, 3

                    CheckBox_ReceivesEmail.Checked = True

                Case 2

                    CheckBox_ReceivesEmail.Checked = False

                Case Else

                    CheckBox_ReceivesEmail.Checked = False

            End Select

        End Sub
        Private Sub CheckBox_ReceivesAlerts_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_ReceivesAlerts.BeforePrint

            Select Case LoadCurrentEmployee.AlertNotificationType.GetValueOrDefault(0)

                Case 1, 3

                    CheckBox_ReceivesAlerts.Checked = True

                Case 2

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

            Employee = LoadCurrentEmployee()

            TotalHours = Employee.MondayHours.GetValueOrDefault(0) + Employee.TuesdayHours.GetValueOrDefault(0) + Employee.WednesdayHours.GetValueOrDefault(0) _
                            + Employee.ThursdayHours.GetValueOrDefault(0) + Employee.FridayHours.GetValueOrDefault(0) + Employee.SaturdayHours.GetValueOrDefault(0) _
                            + Employee.SundayHours.GetValueOrDefault(0)

            Label_WeeklyTimeTotal.Text = TotalHours

        End Sub

#End Region

#End Region

    End Class

End Namespace
