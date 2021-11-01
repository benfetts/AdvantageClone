Namespace Controller.Employee

    Public Class ExpenseReportSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AllowedJobProcessControlNumbers As Integer() = {1, 3, 4, 8, 9, 13}

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub

#Region " Expense Report Header Methods "
        Public Function Load() As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel

            Dim ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel = Nothing

            ExpenseReportSetupViewModel = New AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReportSetupViewModel.ExpenseReports = GetExpenseReports(DbContext)

            End Using

            Load = ExpenseReportSetupViewModel

        End Function
        Public Function GetExpenseReports() As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetExpenseReports(DbContext)

            End Using

        End Function
        Public Function GetExpenseReports(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)

            Return AdvantageFramework.Database.Procedures.ExpenseReport.Load(DbContext).ToList

        End Function

        Public Function ExpenseReportExists(InvoiceNumber As Integer) As Boolean

            ExpenseReportExists = False

            Dim ExpenseReports As List(Of Database.Entities.ExpenseReport) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReports = GetExpenseReports(DbContext).Where(Function(x) x.InvoiceNumber = InvoiceNumber)

            End Using

            If ExpenseReports.Count > 0 Then

                ExpenseReportExists = True

            End If

        End Function
        Public Function Add(ByRef ExpenseReports As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReport)) As Boolean

            Dim Added As Boolean = False

            'set the created by
            'SetCreatedBy(ExpenseReports)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For x = 0 To ExpenseReports.Count - 1 Step +1

                    Dim ExpenseReportEntities As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport) = New List(Of AdvantageFramework.Database.Entities.ExpenseReport)

                    ExpenseReportEntities.Add(ExpenseReports(x).ToEntity(Nothing))

                    Added = Add(DbContext, ExpenseReportEntities.ToList)

                    ExpenseReports(x).InvoiceNumber = ExpenseReportEntities(0).InvoiceNumber

                Next

            End Using

            Return Added

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each ExpenseReport In ExpenseReports

                If ExpenseReport.IsEntityBeingAdded() Then

                    ExpenseReport.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        Public Function Save(ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, ExpenseReportSetupViewModel.ExpenseReports)

            End Using

        End Function
        Public Function Save(ByVal ExpenseReports As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReport)) As Boolean

            'set the modified by
            SetModifiedBy(ExpenseReports)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, ExpenseReports.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each ExpenseReport In ExpenseReports

                If AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ExpenseReport In ExpenseReportSetupViewModel.SelectedExpenseReports

                    If Delete(DbContext, ExpenseReport) Then

                        Deleted = True

                        If ExpenseReportSetupViewModel.ExpenseReports.Remove(ExpenseReport) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each ExpenseReport In ExpenseReports

                If Delete(DbContext, ExpenseReport) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal ExpenseReports As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReport)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ExpenseReport In ExpenseReports.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, ExpenseReport) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.ExpenseReport.Delete(DbContext, ExpenseReport)

            End Using

        End Function


        Public Function UpdateIsSubmittedFlag(ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If ExpenseReport IsNot Nothing Then

                Try

                    ExpenseReport.IsSubmitted = Convert.ToInt16(Value)

                Catch ex As Exception
                    ExpenseReport.IsSubmitted = ExpenseReport.IsSubmitted
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateIsSubmittedFlag = Saved

        End Function

        Public Function UpdateIsApprovedFlag(ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If ExpenseReport IsNot Nothing Then

                Try

                    ExpenseReport.IsApproved = Convert.ToInt16(Value)

                Catch ex As Exception
                    ExpenseReport.IsApproved = ExpenseReport.IsSubmitted
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.ExpenseReport.Update(DbContext, ExpenseReport)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateIsApprovedFlag = Saved

        End Function

        Public Sub CancelNewItemRow(ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel)

            ExpenseReportSetupViewModel.IsNewRow = False
            ExpenseReportSetupViewModel.CancelEnabled = False
            ExpenseReportSetupViewModel.DeleteEnabled = ExpenseReportSetupViewModel.HasASelectedExpenseReport

        End Sub
        Public Sub InitNewRowEvent(ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel)

            ExpenseReportSetupViewModel.IsNewRow = True
            ExpenseReportSetupViewModel.CancelEnabled = True
            ExpenseReportSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub ExpenseReportSelectionChanged(ExpenseReportSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedExpenseReports As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReport))

            ExpenseReportSetupViewModel.IsNewRow = IsNewItemRow
            ExpenseReportSetupViewModel.CancelEnabled = IsNewItemRow
            ExpenseReportSetupViewModel.DeleteEnabled = Not IsNewItemRow

            ExpenseReportSetupViewModel.SelectedExpenseReports = SelectedExpenseReports

        End Sub

#End Region

#Region " Expense Report Details Methods "

        'Public Function LoadDetails() As AdvantageFramework.ViewModels.Employee.ExpenseReportDetailSetupViewModel

        '    Dim ExpenseReportDetailSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportDetailSetupViewModel = Nothing

        '    ExpenseReportDetailSetupViewModel = New AdvantageFramework.ViewModels.Employee.ExpenseReportDetailSetupViewModel

        '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '        ExpenseReportDetailSetupViewModel.ExpenseReportDetails = GetExpenseReportDetails(DbContext)

        '    End Using

        '    Load = ExpenseReportDetailSetupViewModel

        'End Function

        Public Function LoadDetails(ByVal IncludeSystemGenerated) As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)

            Return GetExpenseReportDetails(IncludeSystemGenerated)

        End Function

        Public Function GetExpenseReportDetails(ByVal IncludeSystemGenerated) As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetExpenseReportDetails(DbContext, IncludeSystemGenerated)

            End Using

        End Function
        Public Function GetExpenseReportDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IncludeSystemGenerated As Boolean) As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)

            Return AdvantageFramework.Database.Procedures.ExpenseReportDetail.Load(DbContext, IncludeSystemGenerated).ToList

        End Function

        Public Function ExpenseReportDetailExists(ID As Integer) As Boolean

            ExpenseReportDetailExists = False

            Dim ExpenseReportDetails As List(Of Database.Entities.ExpenseReportDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ExpenseReportDetails = GetExpenseReportDetails(DbContext).Where(Function(x) x.ID = ID)

            End Using

            If ExpenseReportDetails.Count > 0 Then

                ExpenseReportDetailExists = True

            End If

        End Function
        Public Function AddDetails(ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail), Optional ByVal isImported As Boolean = False) As Boolean

            'set the created by user
            SetCreatedBy(ExpenseReportDetails)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AddDetails = AddExpenseReportDetail(DbContext, ExpenseReportDetails.Select(Function(d) d.ToEntity(Nothing)).ToList, isImported)

            End Using

        End Function

        Public Function AddExpenseReportDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail), Optional ByVal isImported As Boolean = False) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each ExpenseReportDetail In ExpenseReportDetails

                If ExpenseReportDetail.IsEntityBeingAdded() Then

                    If ExpenseReportDetail.ClientCode Is Nothing Then
                        If ExpenseReportDetail.JobNumber IsNot Nothing Then
                            Dim job As AdvantageFramework.Database.Entities.Job = Nothing
                            job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ExpenseReportDetail.JobNumber)

                            If job IsNot Nothing Then
                                ExpenseReportDetail.ClientCode = job.ClientCode
                                ExpenseReportDetail.DivisionCode = job.DivisionCode
                                ExpenseReportDetail.ProductCode = job.ProductCode
                            End If

                        End If
                    End If

                    If isImported = True Then
                        ExpenseReportDetail.IsImported = True
                    End If

                    If ExpenseReportDetail.PaymentType = 1 Then
                        ExpenseReportDetail.CreditCardFlag = 0
                    Else
                        ExpenseReportDetail.CreditCardFlag = 1
                    End If

                    ExpenseReportDetail.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Insert(DbContext, ExpenseReportDetail) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        'Public Function SaveDetails(ExpenseReportDetailSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportDetailSetupViewModel) As Boolean

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        SaveDetails = SaveDetails(DbContext, ExpenseReportDetailSetupViewModel.ExpenseReportDetails)

        '    End Using

        'End Function
        Public Function SaveDetails(ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)) As Boolean

            'set the modified by
            SetModifiedBy(ExpenseReportDetails)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SaveDetails = SaveDetails(DbContext, ExpenseReportDetails.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function SaveDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each ExpenseReportDetail In ExpenseReportDetails

                If ExpenseReportDetail.PaymentType = 1 Then
                    ExpenseReportDetail.CreditCardFlag = 0
                Else
                    ExpenseReportDetail.CreditCardFlag = 1
                End If

                If AdvantageFramework.Database.Procedures.ExpenseReportDetail.Update(DbContext, ExpenseReportDetail) = False Then

                    Saved = False

                End If

            Next

            SaveDetails = Saved

        End Function
        'Public Function DeleteDetails(ExpenseReportDetailSetupViewModel As AdvantageFramework.ViewModels.Employee.ExpenseReportDetailSetupViewModel) As Boolean

        '    'objects
        '    Dim Deleted As Boolean = True
        '    Dim ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        For Each ExpenseReportDetail In ExpenseReportDetailSetupViewModel.SelectedExpenseReportDetails

        '            If DeleteDetails(DbContext, ExpenseReportDetail) Then

        '                Deleted = True

        '                If ExpenseReportDetailSetupViewModel.ExpenseReportDetails.Remove(ExpenseReportDetail) = False Then

        '                    Deleted = False

        '                End If

        '            End If

        '        Next

        '    End Using

        '    DeleteDetails = Deleted

        'End Function
        Public Function DeleteDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.ExpenseReportDetail)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each ExpenseReportDetail In ExpenseReportDetails

                If DeleteDetails(DbContext, ExpenseReportDetail) Then

                    Deleted = True

                End If

            Next

            DeleteDetails = Deleted

        End Function
        Public Function DeleteDetailsByID(ByVal ExpenseReportDetailIDs As Generic.List(Of Integer)) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim StrDtl As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    StrDtl = String.Join(",", ExpenseReportDetailIDs.ToArray)

                Catch ex As Exception
                    StrDtl = String.Empty
                End Try
                If String.IsNullOrWhiteSpace(StrDtl) = False Then

                    Try

                        Dim SQL As String = "DELETE FROM EXPENSE_DETAIL WITH(ROWLOCK) WHERE EXPDETAILID IN ({0});"

                        DbContext.Database.ExecuteSqlCommand(String.Format(SQL, StrDtl))

                    Catch ex As Exception
                        Deleted = False
                    End Try

                End If

            End Using

            DeleteDetailsByID = Deleted

        End Function

        Public Function DeleteDetails(ByVal ExpenseReportDetails As Generic.List(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each ExpenseReportDetail In ExpenseReportDetails.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If DeleteDetails(DbContext, ExpenseReportDetail) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            DeleteDetails = Deleted

        End Function
        Public Function DeleteDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExpenseReportDetail As AdvantageFramework.Database.Entities.ExpenseReportDetail) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.ExpenseReportDetail.Delete(DbContext, ExpenseReportDetail)

            End Using

        End Function


#End Region

#Region " Metadata Functions "
        Public Function LoadFunctionCodes() As Generic.List(Of AdvantageFramework.Database.Entities.Function)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeExpenseVendorFunctions(DbContext).ToList

            End Using

        End Function
        Public Function LoadClients() As Generic.List(Of AdvantageFramework.Database.Entities.Client)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

            End Using

        End Function

        Public Function LoadJobs(ClientCode As String) As Generic.List(Of AdvantageFramework.DTO.JobComponent)

            Dim JobEntities As Generic.IEnumerable(Of AdvantageFramework.Database.Entities.Job)
            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                JobEntities = AdvantageFramework.Database.Procedures.Job.LoadByClientCode(DbContext, ClientCode)

                JobComponents = (From Item In JobEntities
                                 Where Item.IsOpen = 1
                                 Select New AdvantageFramework.DTO.JobComponent() With {
                                     .ClientCode = Item.ClientCode,
                                     .ClientName = Item.Client.Name,
                                     .DivisionCode = Item.DivisionCode,
                                     .DivisionName = Item.Division.Name,
                                     .JobComponentDescription = Item.JobComponents.FirstOrDefault().Description,
                                     .JobComponentNumber = Item.JobComponents.FirstOrDefault().Number,
                                     .JobDescription = Item.Description,
                                     .JobNumber = Item.Number,
                                     .ProductCode = Item.ProductCode,
                                     .ProductName = Item.Product.Name}).ToList

            End Using

            Return JobComponents

        End Function

        Public Function LoadAllJobs() As Generic.List(Of AdvantageFramework.DTO.JobComponent)

            'Dim JobEntities As Generic.IEnumerable(Of AdvantageFramework.Database.Entities.Job)
            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    'JobEntities = AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext)
                    'JobComponents = (From Item In JobEntities
                    '                 Where Item.IsOpen = 1
                    '                 Select New AdvantageFramework.DTO.JobComponent() With {
                    '                     .ClientCode = Item.ClientCode,
                    '                     .ClientName = Item.Client.Name,
                    '                     .DivisionCode = Item.DivisionCode,
                    '                     .DivisionName = Item.Division.Name,
                    '                     .JobComponentDescription = Item.JobComponents.FirstOrDefault().Description,
                    '                     .JobComponentNumber = Item.JobComponents.FirstOrDefault().Number,
                    '                     .JobDescription = Item.Description,
                    '                     .JobNumber = Item.Number,
                    '                     .ProductCode = Item.ProductCode,
                    '                     .ProductName = Item.Product.Name}).ToList


                    JobComponents = (From Item In AdvantageFramework.ExpenseReports.LoadAvailableJobComponents(DbContext, SecurityDbContext)
                                     Select New AdvantageFramework.DTO.JobComponent() With {.ClientCode = Item.ClientCode,
                                                                                          .ClientName = Item.ClientName,
                                                                                          .DivisionCode = Item.DivisionCode,
                                                                                          .DivisionName = Item.DivisionName,
                                                                                          .ProductCode = Item.ProductCode,
                                                                                          .ProductName = Item.ProductDescription,
                                                                                          .JobNumber = Item.JobNumber,
                                                                                          .JobComponentNumber = Item.JobComponentNumber,
                                                                                          .JobComponentDescription = Item.JobComponentDescription,
                                                                                          .JobDescription = Item.JobDescription}).OrderByDescending(Function(item) item.JobNumber).ThenBy(Function(item) item.JobComponentNumber).ToList

                End Using
            End Using

            Return JobComponents

        End Function

        Public Function LoadJobComponents(JobNumber As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.JobComponent.LoadAllByJobNumber(DbContext, JobNumber).ToList

            End Using

        End Function

        Public Function LoadDivisions(ClientCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Division)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).ToList

            End Using

        End Function

        Public Function LoadProducts(ClientCode As String, DivisionCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Product)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList

            End Using

        End Function

        Public Function GetPaymentTypes() As IEnumerable

            'objects
            Dim PaymentTypes As IEnumerable = Nothing

            Dim items As Array

            items = System.Enum.GetValues(GetType(AdvantageFramework.Database.Entities.ExpenseItemPaymentType))

            'get the values and descriptions
            PaymentTypes = (From item In items
                            Select New With {.Value = CType(item, Int32),
                                             .Description = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ExpenseItemPaymentType), CType(item, Int32))
                                             }).ToList

            'sort by the descriptions
            PaymentTypes = (From item In PaymentTypes
                            Order By item.Description
                            Select item).ToList


            GetPaymentTypes = PaymentTypes

        End Function

#End Region

#End Region

#Region " Private "

        Private Sub SetCreatedBy(ExpenseReports As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReport))

            For Each Item As AdvantageFramework.DTO.Employee.ExpenseReport In ExpenseReports
                Item.CreatedBy = _Session.UserCode
            Next

        End Sub

        Private Sub SetCreatedBy(ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail))

            For Each Item As AdvantageFramework.DTO.Employee.ExpenseReportDetail In ExpenseReportDetails
                Item.CreatedBy = _Session.UserCode
            Next

        End Sub

        Private Sub SetModifiedBy(ExpenseReports As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReport))

            For Each Item As AdvantageFramework.DTO.Employee.ExpenseReport In ExpenseReports
                Item.ModifiedBy = _Session.UserCode
            Next

        End Sub

        Private Sub SetModifiedBy(ExpenseReportDetails As IEnumerable(Of AdvantageFramework.DTO.Employee.ExpenseReportDetail))

            For Each Item As AdvantageFramework.DTO.Employee.ExpenseReportDetail In ExpenseReportDetails
                Item.ModifiedBy = _Session.UserCode
            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace
