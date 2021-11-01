Namespace Employee

    Public Class EmployeeTimesheetDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _ExcludeEmployeeSignature As Boolean = False
        Private _Date As String = String.Empty
        Private _WeekOfDate As Date = Nothing
        Private _UseProductCategory As Boolean = False

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
        Public Property ExcludeEmployeeSignature As Boolean
            Get
                ExcludeEmployeeSignature = _ExcludeEmployeeSignature
            End Get
            Set(value As Boolean)
                _ExcludeEmployeeSignature = value
            End Set
        End Property
        Public ReadOnly Property StartDate As Date
            Get

                Try

                    If Me.DataSource IsNot Nothing Then

                        StartDate = (From Entity In DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex))
                                     Select Entity.EmployeeDate).Min

                    Else

                        StartDate = Nothing

                    End If

                Catch ex As Exception
                    StartDate = Nothing
                End Try

            End Get
        End Property
        Public ReadOnly Property EndDate As Date
            Get

                Try

                    If Me.DataSource IsNot Nothing Then

                        EndDate = (From Entity In DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex))
                                   Select Entity.EmployeeDate).Max

                    Else

                        EndDate = Nothing

                    End If

                Catch ex As Exception
                    EndDate = Nothing
                End Try

            End Get
        End Property
        Public Property UseProductCategory As Boolean
            Get
                UseProductCategory = _UseProductCategory
            End Get
            Set(value As Boolean)
                _UseProductCategory = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function GetCurrentEmployee() As AdvantageFramework.Database.Views.Employee

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

            Try

                EmployeeTimeComplex = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Classes.EmployeeTimeComplex)

                If EmployeeTimeComplex IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EmployeeTime = AdvantageFramework.Database.Procedures.EmployeeTime.LoadByID(DbContext, EmployeeTimeComplex.EmployeeTimeID)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeTime.EmployeeCode)

                    End Using

                End If

            Catch ex As Exception
                Employee = Nothing
            Finally
                GetCurrentEmployee = Employee
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub LabelPageHeader_Title_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Title.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim LabelText As String = Nothing

            Try

                Employee = GetCurrentEmployee()

                If Employee IsNot Nothing Then

                    LabelText = "Timesheet for (" & Employee.Code & ") " & Employee.ToString

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelPageHeader_Title.Text = LabelText
            End Try

        End Sub
        Private Sub EmployeeTimesheetDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim FileName As String = Nothing

            Try

                Employee = GetCurrentEmployee()

            Catch ex As Exception
                Employee = Nothing
            End Try

            FileName = "TIMESHEET"

            If Employee IsNot Nothing Then

                FileName &= "_" & Employee.Code.ToUpper

            End If

            FileName &= "_" & System.DateTime.Today.Year.ToString & System.DateTime.Today.Month.ToString & System.DateTime.Today.Day.ToString

            Me.ExportOptions.PrintPreview.DefaultFileName = FileName

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = "For Dates " & Me.StartDate.ToShortDateString & " thru " & Me.EndDate.ToShortDateString

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub LabelSignatureDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelSignatureDate.BeforePrint

            If _ExcludeEmployeeSignature Then

                LabelSignatureDate.Text = ""

            Else

                LabelSignatureDate.Text = System.DateTime.Today.ToShortDateString

            End If

        End Sub
        Private Sub Label_ProductCategory_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductCategory.BeforePrint

            Label_ProductCategory.Visible = _UseProductCategory

        End Sub
        Private Sub LabelGroup_ProductCategory_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroup_ProductCategory.BeforePrint

            LabelGroup_ProductCategory.Visible = _UseProductCategory

        End Sub
        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeSignatureImage As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim TotalLabelText As String = Nothing

            Try

                Employee = GetCurrentEmployee()

                If Employee IsNot Nothing Then

                    If _ExcludeEmployeeSignature = False Then

                        If Employee.SignatureImage IsNot Nothing Then

                            Try

                                MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                EmployeeSignatureImage = System.Drawing.Image.FromStream(MemoryStream)

                            Catch ex As Exception
                                EmployeeSignatureImage = Nothing
                            End Try

                        End If

                    End If

                    TotalLabelText = "Total for " & Employee.ToString & ":"

                Else

                    EmployeeSignatureImage = Nothing
                    TotalLabelText = "Total:"

                End If

                If _ExcludeEmployeeSignature = False Then

                    PictureBoxEmployeeSignature.Image = EmployeeSignatureImage

                Else

                    PictureBoxEmployeeSignature.Image = Nothing

                End If

                LabelDetail_Total.Text = TotalLabelText

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
