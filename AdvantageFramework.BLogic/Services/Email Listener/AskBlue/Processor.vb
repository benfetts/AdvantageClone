Namespace Services.EmailListener.AskBlue

    <Serializable()> _
    Public Class Processor

#Region " Constants "

        Private Const _DelimiterForId As String = ":"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = 0
        Private _JobComponentNbr As Integer = 0
        Private _DelimiterForJobAndComponent As String() = {"/", "-"}
        Private _AvailableCommands As List(Of Services.EmailListener.AskBlue.Command) = Nothing
        Private _AvailableActions As List(Of Services.EmailListener.AskBlue.Action) = Nothing
        Private _Message As MailBee.Mime.MailMessage = Nothing
        'Private _MessageText As String = ""
        Private _SubjectText As String = ""
        Private _BodyText As String = ""
        Private _ObjectIdentifier As String = ""
        Private _DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ProcessEmailForCommand(ByRef Message As MailBee.Mime.MailMessage) As Boolean
            If Not Message Is Nothing Then

                _Message = Message
                Return ProcessTextForCommand()

            Else

                Services.EmailListener.WriteToEventLog("Cannot get email message")
                Return False

            End If
        End Function
        Private Function ProcessTextForCommand() As Boolean
            If Not _Message Is Nothing Then

                Dim Command As Services.EmailListener.AskBlue.Command = Nothing

                If _Message.Subject IsNot Nothing AndAlso _Message.Subject.Trim() <> "" Then

                    _SubjectText = _Message.Subject

                End If

                If Not _Message.BodyPlainText Is Nothing Then

                    _BodyText = _Message.BodyPlainText

                Else

                    _BodyText = _Message.BodyHtmlText

                End If

                Command = GetCommand(_SubjectText)

                If Not Command Is Nothing Then

                    Return ProcessCommand(Command)

                Else

                    Return False

                End If

            Else

                Return False

            End If
        End Function

        Private Function GetCommand(ByVal Text As String) As Services.EmailListener.AskBlue.Command

            Dim Command As Services.EmailListener.AskBlue.Command = Nothing
            Dim HasCommand As String = ""

            Try

                For Each AvailableCommand As Services.EmailListener.AskBlue.Command In _AvailableCommands

                    If Text.IndexOf(AvailableCommand.Phrase, StringComparison.CurrentCultureIgnoreCase) > -1 Then

                        Command = New Services.EmailListener.AskBlue.Command(AvailableCommand.Type, AvailableCommand.Action, Text)

                        If Command.Action = Action.AddFromIdentifier Then

                            GetIdentifier()

                        End If

                        Services.EmailListener.WriteToEventLog("AskBlue command found")

                        Exit For

                    End If

                Next

            Catch ex As Exception
                Command = Nothing
            End Try

            GetCommand = Command

        End Function
        Private Sub GetIdentifier()

            Dim IDParts() As String = Nothing

            _ObjectIdentifier = ""

            If _SubjectText.IndexOf(_DelimiterForId) > -1 Then

                IDParts = _SubjectText.Split(_DelimiterForId)

                If IDParts.Length > 1 Then

                    For i As Integer = 0 To IDParts.Length - 1

                        If IsNumeric(IDParts(i).Trim()) Or IsDate(IDParts(i)) Then

                            _ObjectIdentifier = IDParts(i)

                            'Else

                            '    For Each s As String In _DelimiterForJobAndComponent

                            '        If ar(i).Contains(s) = True Then

                            '            _ObjectIdentifier = ar(i)

                            '            Dim js() As String
                            '            js = ar(i).Split(s)

                            '            If js.Length = 1 Then

                            '                If IsNumeric(js(0).Trim()) = True Then

                            '                    _JobNumber = CType(js(0).Trim(), Integer)

                            '                End If

                            '            ElseIf js.Length = 2 Then

                            '                If IsNumeric(js(0).Trim()) = True Then

                            '                    _JobNumber = CType(js(0).Trim(), Integer)

                            '                End If
                            '                If IsNumeric(js(1).Trim()) = True Then

                            '                    _JobComponentNbr = CType(js(1).Trim(), Integer)

                            '                End If

                            '            End If

                            '        End If

                            '    Next

                        End If

                    Next

                End If

            End If

        End Sub
        Private Function ProcessCommand(ByRef Command As Services.EmailListener.AskBlue.Command) As Boolean

            Dim ProcessedCommand As Boolean = False

            Select Case Command.Type

                Case CommandType.Expense

                    If _Message.Attachments.Count = 0 Then

                        Services.EmailListener.WriteToEventLog("AskBlue Expense Command found, but no attachments to upload")
                        Return False

                    Else

                        ProcessedCommand = ProcessExpenseAction(Command)

                    End If

                Case CommandType.Alert

                    ProcessedCommand = ProcessAlertAction(Command)

                Case CommandType.Timesheet

                    ProcessedCommand = False

            End Select

            ProcessCommand = ProcessedCommand

        End Function

        Private Function ProcessExpenseAction(ByVal Command As Services.EmailListener.AskBlue.Command) As Boolean

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing
            Dim ExpenseReportDocument As AdvantageFramework.Database.Entities.ExpenseReportDocument = Nothing
            Dim ExpenseReportDocumentUnassigned As AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ExpenseDate As Date = Nothing
            Dim FileSystemFile As String = ""
            Dim FilenameToSave As String = ""
            Dim ProcessedExpenseAction As Boolean = False
            Dim ErrorMessage As String = ""

            If Command.Type = CommandType.Expense Then

                ExpenseDate = IIf(IsDate(_Message.Date), CType(CType(_Message.Date, Date).ToShortDateString(), Date), CType(Now.Date.ToShortDateString(), Date))
                Document = New AdvantageFramework.Database.Entities.Document

                Services.EmailListener.WriteToEventLog("Expense Command found")

                Using DbContext = New AdvantageFramework.Database.DbContext(_DatabaseProfile.ConnectionString, _DatabaseProfile.DatabaseUserName)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency Is Nothing Then

                        Services.EmailListener.WriteToEventLog("Cannot load Agency")
                        Return False

                    End If

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, _Message.From.Email)

                    If Employee Is Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, _Message.From.Email.ToLower)

                        If Employee Is Nothing Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeEmail(DbContext, _Message.From.Email.ToUpper)

                            If Employee Is Nothing Then

                                Try

                                    Employee = (From Entity In DbContext.Employees
                                                Where Entity.Email.ToUpper = _Message.From.Email.ToUpper
                                                Select Entity).FirstOrDefault

                                Catch ex As Exception
                                    Employee = Nothing
                                End Try

                            End If

                        End If

                    End If

                    If Employee Is Nothing Then

                        Services.EmailListener.WriteToEventLog("Cannot load Employee")
                        Return False

                    End If

                    Select Case Command.Action

                        Case Services.EmailListener.AskBlue.Action.Unassigned

                            For Each Attachment As MailBee.Mime.Attachment In _Message.Attachments.OfType(Of MailBee.Mime.Attachment)()

                                If Attachment.IsInline = False Then

                                    FileSystemFile = ""
                                    ErrorMessage = ""

                                    If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                        FilenameToSave = AdvantageFramework.FileSystem.AddDateGUID(Attachment.Filename)

                                        If Attachment.SaveToFolder(My.Application.Info.DirectoryPath, True) Then

                                            If AdvantageFramework.FileSystem.Add(Agency, AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") &
                                                                                 FilenameToSave, "", "", Employee.Code, "Expense",
                                                                                 "Attached Doc", FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Attachment.GetData()) Then

                                                Document = New AdvantageFramework.Database.Entities.Document

                                                With Document

                                                    .DbContext = DbContext
                                                    .FileName = FilenameToSave
                                                    .MIMEType = Attachment.ContentType
                                                    .FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(FileSystemFile)
                                                    .FileSize = Attachment.Size
                                                    .DocumentTypeID = 3
                                                    .IsPrivate = 0
                                                    .UploadedDate = Now
                                                    .UserCode = _DatabaseProfile.DatabaseUserName
                                                    .Description = "Expense Receipt for " & Employee.Code

                                                End With

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                    ExpenseReportDocumentUnassigned = New AdvantageFramework.Database.Entities.ExpenseReportDocumentUnassigned

                                                    With ExpenseReportDocumentUnassigned

                                                        .DbContext = DbContext
                                                        .DocumentID = Document.ID
                                                        .EmployeeCode = Employee.Code

                                                    End With

                                                    If AdvantageFramework.Database.Procedures.ExpenseReportDocumentUnassigned.Insert(DbContext, ExpenseReportDocumentUnassigned) = True Then

                                                        Services.EmailListener.WriteToEventLog("Document added for unassigned")

                                                    End If

                                                End If

                                            End If

                                            Try

                                                My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & FilenameToSave)

                                            Catch ex As Exception

                                            End Try

                                        End If

                                    Else

                                        Services.EmailListener.WriteToEventLog("Document failed to add for unassigned:  Reason: " & ErrorMessage)

                                    End If

                                End If

                            Next

                        Case Services.EmailListener.AskBlue.Action.Insert

                            ExpenseReport = New AdvantageFramework.Database.Entities.ExpenseReport

                            If Employee IsNot Nothing Then

                                With ExpenseReport

                                    .EmployeeCode = Employee.Code
                                    .CreatedDate = ExpenseDate
                                    .InvoiceDate = ExpenseDate
                                    .VendorCode = Employee.EmployeeVendorCode
                                    .Description = "Created from AskBlue command"

                                End With

                                If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) = False Then

                                    Services.EmailListener.WriteToEventLog("Cannot insert expense report")
                                    ExpenseReport = Nothing

                                End If

                            End If

                        Case Services.EmailListener.AskBlue.Action.Update

                            'look for existing expense report
                            ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadFirstOpenForMonthByEmployeeCode(DbContext, Employee.Code, ExpenseDate)

                            If ExpenseReport Is Nothing Then

                                Services.EmailListener.WriteToEventLog("Open, existing expense report not found; inserting new")
                                ExpenseReport = New AdvantageFramework.Database.Entities.ExpenseReport

                                If Employee IsNot Nothing Then

                                    With ExpenseReport

                                        .EmployeeCode = Employee.Code
                                        .CreatedDate = ExpenseDate
                                        .InvoiceDate = ExpenseDate
                                        .VendorCode = Employee.EmployeeVendorCode
                                        .Description = "Created from AskBlue command"

                                    End With

                                    If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) = False Then

                                        Services.EmailListener.WriteToEventLog("Cannot insert expense report")
                                        ExpenseReport = Nothing

                                    End If

                                End If

                            Else

                                Services.EmailListener.WriteToEventLog("Open, existing expense report found")

                            End If

                        Case Services.EmailListener.AskBlue.Action.AddFromIdentifier

                            If IsNumeric(_ObjectIdentifier) = True Then

                                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _ObjectIdentifier)

                            ElseIf IsDate(_ObjectIdentifier) = True Then

                                ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByEmployeeCodeAndDate(DbContext, Employee.Code, CType(_ObjectIdentifier, Date))

                            End If

                    End Select

                    If ExpenseReport IsNot Nothing AndAlso Employee IsNot Nothing AndAlso _Message IsNot Nothing Then

                        For Each Attachment As MailBee.Mime.Attachment In _Message.Attachments.OfType(Of MailBee.Mime.Attachment)()

                            If Attachment.IsInline = False Then

                                FileSystemFile = ""
                                ErrorMessage = ""

                                If AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                                    FilenameToSave = AdvantageFramework.FileSystem.AddDateGUID(Attachment.Filename)

                                    If Attachment.SaveToFolder(My.Application.Info.DirectoryPath, True) Then

                                        If AdvantageFramework.FileSystem.Add(Agency, AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") &
                                                                             FilenameToSave, "", "", ExpenseReport.EmployeeCode, "Expense",
                                                                             "Attached Doc", FileSystem.DocumentSource.DocumentUpload, FileSystemFile, Attachment.GetData()) Then

                                            Document = New AdvantageFramework.Database.Entities.Document

                                            With Document

                                                .DbContext = DbContext
                                                .FileName = FilenameToSave
                                                .MIMEType = Attachment.ContentType
                                                .FileSystemFileName = AdvantageFramework.FileSystem.GetFileName(FileSystemFile)
                                                .FileSize = Attachment.Size
                                                .DocumentTypeID = 3
                                                .IsPrivate = 0
                                                .UploadedDate = Now
                                                .UserCode = _DatabaseProfile.DatabaseUserName
                                                .Description = "Invoice Number: " & ExpenseReport.InvoiceNumber

                                            End With

                                            If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, Document) Then

                                                ExpenseReportDocument = New AdvantageFramework.Database.Entities.ExpenseReportDocument

                                                With ExpenseReportDocument

                                                    .DbContext = DbContext
                                                    .DocumentID = Document.ID
                                                    .InvoiceNumber = ExpenseReport.InvoiceNumber

                                                End With

                                                If AdvantageFramework.Database.Procedures.ExpenseReportDocument.Insert(DbContext, ExpenseReportDocument) = True Then

                                                    Services.EmailListener.WriteToEventLog("Document added for expense report: " & ExpenseReport.InvoiceNumber)

                                                End If

                                            End If

                                        End If

                                        Try

                                            My.Computer.FileSystem.DeleteFile(AdvantageFramework.StringUtilities.AppendTrailingCharacter(My.Application.Info.DirectoryPath, "\") & FilenameToSave)

                                        Catch ex As Exception

                                        End Try

                                    End If

                                Else

                                    Services.EmailListener.WriteToEventLog("Document failed to add for expense report: " & ExpenseReport.InvoiceNumber & "Reason: " & ErrorMessage)

                                End If

                            End If

                        Next

                    End If

                End Using

                ProcessedExpenseAction = True

            Else

                ProcessedExpenseAction = False

            End If

            ProcessExpenseAction = ProcessedExpenseAction

        End Function
        'Private Function InsertExpense(ByVal er As AdvantageFramework.Database.Entities.ExpenseReport) As Boolean

        '    With ExpenseReport

        '        .EmployeeCode = Employee.Code
        '        .CreatedDate = ExpenseDate
        '        .InvoiceDate = ExpenseDate
        '        .VendorCode = Employee.EmployeeVendorCode
        '        .Description = "Created from AskBlue command"

        '    End With

        '    If AdvantageFramework.Database.Procedures.ExpenseReport.Insert(DbContext, ExpenseReport) = False Then

        '        Services.EmailListener.WriteToEventLog("Cannot insert expense report")
        '        ExpenseReport = Nothing

        '    End If

        'End Function

        Private Function ProcessAlertAction(ByVal Command As Services.EmailListener.AskBlue.Command) As Boolean

            Dim JobIDParts() As String = Nothing
            Dim SplitFound As Boolean = False

            Services.EmailListener.WriteToEventLog("Alert Command found")

            If _JobNumber = 0 Or _JobComponentNbr = 0 Then

                For Each Delimiter As String In _DelimiterForJobAndComponent

                    If _ObjectIdentifier.Contains(Delimiter) = True Then

                        SplitFound = True

                        JobIDParts = _ObjectIdentifier.Split(Delimiter)

                        If JobIDParts.Length = 1 Then

                            If IsNumeric(JobIDParts(0).Trim()) = True Then

                                _JobNumber = CType(JobIDParts(0).Trim(), Integer)

                            End If

                        ElseIf JobIDParts.Length = 2 Then

                            If IsNumeric(JobIDParts(0).Trim()) = True Then

                                _JobNumber = CType(JobIDParts(0).Trim(), Integer)

                            End If
                            If IsNumeric(JobIDParts(1).Trim()) = True Then

                                _JobComponentNbr = CType(JobIDParts(1).Trim(), Integer)

                            End If

                        End If

                    End If

                Next

                If SplitFound = False And IsNumeric(_ObjectIdentifier) = True And _JobNumber = 0 Then _JobNumber = CType(_ObjectIdentifier, Integer)

            End If

            If _JobNumber = 0 And _JobComponentNbr = 0 Then

                Services.EmailListener.WriteToEventLog("Could not get valid identifier for Alert Command")
                Services.EmailListener.WriteToEventLog("AskBlue Alert Command found, but no actions taken")
                Return False

            Else

                Return NewAlert()

            End If

        End Function
        Private Function NewAlert() As Boolean

            If _JobNumber > 0 And _JobComponentNbr = 0 Then

                'create job level alert

                Services.EmailListener.WriteToEventLog("New Job Alert created")
                Return True

            ElseIf _JobNumber > 0 And _JobComponentNbr > 0 Then

                'create job component level alert

                Services.EmailListener.WriteToEventLog("New Job Component Alert created")
                Return True

            Else

                Services.EmailListener.WriteToEventLog("Could not get valid identifier for Alert Command")
                Services.EmailListener.WriteToEventLog("AskBlue Alert Command found, but no actions taken")
                Return False

            End If

            Return False

        End Function

        Sub New(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile)

            _DatabaseProfile = DatabaseProfile

            _AvailableCommands = New List(Of Services.EmailListener.AskBlue.Command)

            With _AvailableCommands

                .Add(New Services.EmailListener.AskBlue.Command(CommandType.Expense, Services.EmailListener.AskBlue.Action.Insert, "add exp"))
                .Add(New Services.EmailListener.AskBlue.Command(CommandType.Expense, Services.EmailListener.AskBlue.Action.Update, "update exp"))
                .Add(New Services.EmailListener.AskBlue.Command(CommandType.Expense, Services.EmailListener.AskBlue.Action.AddFromIdentifier, "exp:"))
                .Add(New Services.EmailListener.AskBlue.Command(CommandType.Expense, Services.EmailListener.AskBlue.Action.Unassigned, "receipts"))

                .Add(New Services.EmailListener.AskBlue.Command(CommandType.Alert, Action.AddFromIdentifier, "alert:"))

            End With

        End Sub

#End Region

    End Class

End Namespace
