Namespace DTO.Desktop

    <Serializable()>
    Public Class Alert

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AlertLevel
            AlertLevelDisplay
            AlertTypeID
            AlertTypeDescription
            GeneratedDate
            OriginatedDate
            IsCPAlert
            UserName
            UserCode
            GeneratedByEmployeeCode
            GeneratedByEmployeeName
            EmployeeCode
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            CampaignID
            CampaignCode
            CampaignName
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            TaskFunctionDescription
            AlertCategoryID
            AlertCategoryDescription
            PriorityLevel
            PriorityDescription
            DueDate
            TimeDue
            Subject
            Body
            EmailBody
            AlertAssignmentTemplateID
            AlertAssignmentTemplateName
            AlertStateID
            AlertStateName
            AlertSequenceNumber
            DisplayID
            IsAlertAssignment
            CommentCount
            Version
            VersionName
            Build
            BuildName
            AttachmentCount
            TaskCode
            TaskSequenceNumber
            TaskStatus
            AccountPayableID
            AccountPayableSequenceNumber
            IsCompleted
            IsMyAlertOpen
            IsMyAlertDismissed
            MyAlertDismissedDate
            IsMyAssignmentOpen
            IsMyAssignmentCompleted
            MediaATBRevisionID
            MediaATBNumber
            MediaATBDescription
            WasMarkedRead
            WvPermaLink
            CpPermaLink
            SprintID
            SprintDescription
            BoardID
            BoardName
            BoardHeaderID
            BoardHeaderDescription
            BoardStateID
            BoardStateName
            IsWorkItem
            AssignedEmployeeCode
            AssignedEmployeeName
            HoursAllowed
            HoursPosted
            HoursAllocated
            HoursAllocatedBalance
            HoursBalance
            UploadedFiles
            Recipients
            Assignees
            LinkedDocuments
            GroupKey
            CardGroupingPriorityText
            ReadAlert
            ReadAlertText
            CurrentNotify
            IsCC
            CurrentNotifyEmployeeCode
            CurrentNotifyEmployeeFML
            IsDraft
            CardSequenceNumber
            IsDismissed
            IsCSReview
            CSProjectID
            CSReviewID
            CSNumberReviewer
            CSNumberCMP
            CSNumberReject
            CSNumberDefer
            CSNumberApproval
            CurrentRecipient
            StartDate
            Checklist
            StartDateString
            DueDateString
            CompletedDateString

            TaskComment
            EstimateNumber
            EstimateComponentNumber
            TaskStatusCode
            TaskStatusDescription

            SelectedDocumentID

        End Enum

#End Region

#Region " Variables "

#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property AlertLevel As String
        Public Property AlertLevelDisplay As String
        Public Property AlertTypeID As Integer
        Public Property AlertTypeDescription As String
        Public Property GeneratedDate As Nullable(Of Date)
        Public Property OriginatedDate As Nullable(Of Date)
        Public Property IsCPAlert As Nullable(Of Short)
        Public Property UserName As String
        Public Property UserCode As String
        Public Property GeneratedByEmployeeCode As String
        Public Property GeneratedByEmployeeName As String
        Public Property EmployeeCode As String
        Public Property OfficeCode As String
        Public Property OfficeName As String
        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property CampaignID As Nullable(Of Integer)
        Public Property CampaignCode As String
        Public Property CampaignName As String
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String
        Public Property JobComponentNumber As Nullable(Of Short)
        Public Property JobComponentDescription As String
        Public Property TaskFunctionDescription As String
        Public Property AlertCategoryID As Integer
        Public Property AlertCategoryDescription As String
        Public Property PriorityLevel As Nullable(Of Short)
        Public Property PriorityDescription As String
        Public Property DueDate As Nullable(Of Date)
        Public Property TimeDue As String
        Public Property Subject As String
        Public Property Body As String
        Public Property EmailBody As String
        Public Property AlertAssignmentTemplateID As Nullable(Of Integer)
        Public Property AlertAssignmentTemplateName As String
        Public Property AlertStateID As Nullable(Of Integer)
        Public Property AlertStateName As String
        Public Property AlertSequenceNumber As Nullable(Of Short)
        Public Property DisplayID As Integer
        Public Property IsAlertAssignment As Boolean
        Public Property CommentCount As Integer
        Public Property Version As String
        Public Property VersionName As String
        Public Property Build As String
        Public Property BuildName As String
        Public Property AttachmentCount As Integer
        Public Property TaskCode As String
        Public Property TaskSequenceNumber As Nullable(Of Short)
        Public Property TaskStatus As String
        Public Property AccountPayableID As Nullable(Of Integer)
        Public Property AccountPayableSequenceNumber As Nullable(Of Short)
        Public Property IsCompleted As Boolean
        Public Property CompletedDate As Nullable(Of Date)
        Public Property DueDateLocked As Boolean
        Public Property IsTask As Boolean
        Public Property IsMyTask As Boolean
        Public Property IsMyTaskTempComplete As Boolean

        Public Property IsMyAlert As Boolean
        Public Property IsMyAlertOpen As Boolean
        Public Property IsMyAlertDismissed As Boolean
        Public Property MyAlertDismissedDate As Date?
        Public Property IsMyAssignment As Boolean
        Public Property IsMyAssignmentOpen As Boolean
        Public Property IsMyAssignmentCompleted As Boolean
        Public Property MediaATBRevisionID As Nullable(Of Integer)
        Public Property MediaATBNumber As Nullable(Of Integer)
        Public Property MediaATBDescription As String
        Public Property WasMarkedRead As Boolean
        Public Property WvPermaLink As String
        Public Property CpPermaLink As String
        Public Property SprintID As Nullable(Of Integer)
        Public Property SprintDescription As String
        Public Property BoardID As Integer?
        Public Property BoardName As String
        Public Property BoardHeaderID As Integer?
        Public Property BoardHeaderDescription As String
        Public Property BoardStateID As Nullable(Of Integer)
        Public Property BoardStateName As String
        Public Property IsWorkItem As Boolean
        Public Property AssignedEmployeeCode As String
        Public Property AssignedEmployeeName As String
        Public Property JobHours As Decimal?
        Public Property HoursAllowed As Decimal?
        Public Property HoursPosted As Decimal?
        Public Property HoursAllocated As Decimal?
        Public Property HoursAllocatedBalance As Decimal?
        Public Property HoursBalance As Decimal?
        Public Property SendAssignmentComment As String
        Public Property UploadedFiles As String()
        Public Property Recipients As String()
        Public Property Assignees As String()
        Public Property LinkedDocuments As Integer()
        Public Property GroupKey As String
        Public Property CardGroupingPriorityText As String
        Public Property ReadAlert As Short?
        Public Property ReadAlertText As String
        Public Property IsProof As Boolean?
        Public Property SelectedDocumentID As Integer?
        Public ReadOnly Property IsRead As Boolean
            Get
                Try
                    If ReadAlert Is Nothing Then
                        Return True
                    Else
                        If ReadAlert = 1 Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                Catch ex As Exception
                    Return True
                End Try
            End Get
        End Property
        Public Property CurrentNotify As Short?
        Public Property IsCC As Short?
        Public Property CurrentNotifyEmployeeCode As String
        Public Property CurrentNotifyEmployeeFML As String
        Public Property IsDraft As Boolean?
        Public Property CardSequenceNumber As Integer?
        Public Property IsDismissed As Integer?
        Public Property IsCSReview As Boolean?
        Public Property CSProjectID As Integer?
        Public Property CSReviewID As Integer?
        Public Property CSNumberReviewer As Integer?
        Public Property CSNumberCMP As Integer?
        Public Property CSNumberReject As Integer?
        Public Property CSNumberDefer As Integer?
        Public Property CSNumberApproval As Integer?
        Public Property CurrentRecipient As Short?
        Public Property StartDate As Nullable(Of Date)
        Public Property Checklists As ChecklistHeader()
        Public Property CheckListTotal As Integer?
        Public Property CheckListComplete As Integer?
        Public Property CheckListCompleted As Integer?
        Public Property TaskComment As String
        Public Property EstimateNumber As Nullable(Of Integer)
        Public Property EstimateComponentNumber As Nullable(Of Short)
        Public Property TaskFunctionComment As String

        'For report attachments:
        Public Property CallingPage As String
        Public Property IncludeAttachments As Boolean? = True
        'Public Property JobVersionHeaderID As Integer?
        'Public Property JobVersionClientContactID As Integer?
        Public Property IsMultiRoute As Boolean? = False
        Public Property IsRouted As Boolean? = False
        Public Property IsAutoRoute As Boolean? = False

        'Read Only
        Public ReadOnly Property StartDateString As String
            Get
                Dim Val As String = String.Empty
                If StartDate IsNot Nothing Then
                    Val = CType(StartDate, Date).ToShortDateString
                End If
                Return Val
            End Get
        End Property
        Public ReadOnly Property DueDateString As String
            Get
                Dim Val As String = String.Empty
                If DueDate IsNot Nothing Then
                    Val = CType(DueDate, Date).ToShortDateString
                End If
                Return Val
            End Get
        End Property
        Public ReadOnly Property CompletedDateString As String
            Get
                Dim Val As String = String.Empty
                If CompletedDate IsNot Nothing Then
                    Val = CType(CompletedDate, Date).ToShortDateString
                End If
                Return Val
            End Get
        End Property
        Public ReadOnly Property JobAndComponentNumbers As String
            Get

                Dim s As String = String.Empty

                If JobNumber IsNot Nothing Then

                    s = JobNumber.ToString.PadLeft(6, "0")

                    If JobComponentNumber IsNot Nothing Then

                        s &= "/" & JobComponentNumber.ToString.PadLeft(3, "0")

                    End If

                End If

                Return s

            End Get
        End Property
        Public Property IsAlertCC As Boolean
        Public Property LastUpdatedFullName As String
        Public Property LastUpdatedDateTime As Date
        Public Property TaskStatusCode As String
        Public Property TaskStatusDescription As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Shared Function FromMainAlertQuery(ByVal DataRow As System.Data.DataRow, ByVal GroupBy As String) As Alert

            'objects
            Dim NewAlert As Alert = Nothing

            NewAlert = New Alert

            With NewAlert

                .ID = NewAlert.GetDataRowValue(DataRow, "ALERT_ID", GetType(Integer))
                .Subject = NewAlert.GetDataRowValue(DataRow, "SUBJECT", GetType(String))
                .GeneratedDate = NewAlert.GetDataRowValue(DataRow, "GENERATED", GetType(Date))
                .UserName = NewAlert.GetDataRowValue(DataRow, "USER_NAME", GetType(String))
                .PriorityLevel = NewAlert.GetDataRowValue(DataRow, "PRIORITY", GetType(Short))
                .CardGroupingPriorityText = NewAlert.GetDataRowValue(DataRow, "CARD_GROUPING_PRIORITY_TEXT", GetType(String))
                .AlertTypeDescription = NewAlert.GetDataRowValue(DataRow, "TYPE", GetType(String))
                .AlertCategoryDescription = NewAlert.GetDataRowValue(DataRow, "CATEGORY", GetType(String))
                .AttachmentCount = NewAlert.GetDataRowValue(DataRow, "ATTACHMENTCOUNT", GetType(Integer))
                .DueDate = NewAlert.GetDataRowValue(DataRow, "DUE_DATE", GetType(Date))
                .ClientCode = NewAlert.GetDataRowValue(DataRow, "CL_CODE", GetType(String))
                .DivisionCode = NewAlert.GetDataRowValue(DataRow, "DIV_CODE", GetType(String))
                .ProductCode = NewAlert.GetDataRowValue(DataRow, "PRD_CODE", GetType(String))
                .ClientName = NewAlert.GetDataRowValue(DataRow, "CL_NAME", GetType(String))
                .Version = NewAlert.GetDataRowValue(DataRow, "VERSION", GetType(String))
                .Build = NewAlert.GetDataRowValue(DataRow, "BUILD", GetType(String))
                .Version = NewAlert.GetDataRowValue(DataRow, "VERSION_BUILD", GetType(String))
                .AlertStateName = NewAlert.GetDataRowValue(DataRow, "ALERT_STATE_NAME", GetType(String))
                .ReadAlert = NewAlert.GetDataRowValue(DataRow, "READ_ALERT", GetType(Short))
                .ReadAlertText = NewAlert.GetDataRowValue(DataRow, "READ_ALERT_TEXT", GetType(String))
                .CurrentNotify = NewAlert.GetDataRowValue(DataRow, "CURRENT_NOTIFY", GetType(Short))
                .IsCC = NewAlert.GetDataRowValue(DataRow, "IS_CC", GetType(Short))
                .CurrentNotifyEmployeeCode = NewAlert.GetDataRowValue(DataRow, "CURRENT_NOTIFY_EMP_CODE", GetType(String))
                .CurrentNotifyEmployeeFML = NewAlert.GetDataRowValue(DataRow, "CURRENT_NOTIFY_EMP_FML", GetType(String))
                .GroupKey = NewAlert.GetGroupKey(DataRow, GroupBy) ' GetDataRowValue(DataRow, "GRP_COMPONENT", GetType(String)),
                .DisplayID = NewAlert.GetDataRowValue(DataRow, "ID", GetType(Integer))
                .IsAlertAssignment = NewAlert.GetDataRowValue(DataRow, "IS_ASSIGNMENT", GetType(Boolean))
                .JobNumber = NewAlert.GetDataRowValue(DataRow, "JOB_NUMBER", GetType(Integer))
                .JobComponentNumber = NewAlert.GetDataRowValue(DataRow, "JOB_COMPONENT_NBR", GetType(Short))
                .TaskSequenceNumber = NewAlert.GetDataRowValue(DataRow, "TASK_SEQ_NBR", GetType(Short))
                .TaskStatus = NewAlert.GetDataRowValue(DataRow, "TASK_STATUS", GetType(String))
                .AlertLevelDisplay = NewAlert.GetDataRowValue(DataRow, "ALERT_LEVEL_TEXT", GetType(String))
                .TimeDue = NewAlert.GetDataRowValue(DataRow, "TIME_DUE", GetType(String))
                .JobDescription = NewAlert.GetDataRowValue(DataRow, "JOB_DESC", GetType(String))
                .JobComponentDescription = NewAlert.GetDataRowValue(DataRow, "JOB_COMP_DESC", GetType(String))
                .IsDraft = NewAlert.GetDataRowValue(DataRow, "IS_DRAFT", GetType(Boolean))
                .CardSequenceNumber = NewAlert.GetDataRowValue(DataRow, "CARD_SEQ_NBR", GetType(Integer))
                .IsDismissed = NewAlert.GetDataRowValue(DataRow, "IS_DISMISSED", GetType(Integer))
                .IsCSReview = NewAlert.GetDataRowValue(DataRow, "IS_CS_REVIEW", GetType(Boolean))
                .CSProjectID = NewAlert.GetDataRowValue(DataRow, "CS_PROJECT_ID", GetType(Integer))
                .CSReviewID = NewAlert.GetDataRowValue(DataRow, "CS_REVIEW_ID", GetType(Integer))
                .CSNumberReviewer = NewAlert.GetDataRowValue(DataRow, "CS_NUM_REVIEWER", GetType(Integer))
                .CSNumberCMP = NewAlert.GetDataRowValue(DataRow, "CS_NUM_CMPLT", GetType(Integer))
                .CSNumberReject = NewAlert.GetDataRowValue(DataRow, "CS_NUM_REJECT", GetType(Integer))
                .CSNumberDefer = NewAlert.GetDataRowValue(DataRow, "CS_NUM_DEFER", GetType(Integer))
                .CSNumberApproval = NewAlert.GetDataRowValue(DataRow, "CS_NUM_APPR", GetType(Integer))
                .IsWorkItem = NewAlert.GetDataRowValue(DataRow, "IS_WORK_ITEM", GetType(Boolean))
                .CurrentRecipient = NewAlert.GetDataRowValue(DataRow, "CURRENT_RCPT", GetType(Short))
                .StartDate = NewAlert.GetDataRowValue(DataRow, "START_DATE", GetType(Date))
                .CheckListTotal = NewAlert.GetDataRowValue(DataRow, "CHECK_LIST_TOTAL", GetType(Integer))
                .CheckListComplete = NewAlert.GetDataRowValue(DataRow, "CHECK_LIST_COMPLETE", GetType(Integer))
                .CheckListCompleted = NewAlert.GetDataRowValue(DataRow, "CHECK_LIST_COMPLETE", GetType(Integer))
                .TaskComment = NewAlert.GetDataRowValue(DataRow, "FNC_COMMENTS", GetType(String))
                .IsMyTaskTempComplete = If(NewAlert.GetDataRowValue(DataRow, "TEMP_COMP_DATE", GetType(Date)) IsNot Nothing, True, False)
                .EstimateNumber = NewAlert.GetDataRowValue(DataRow, "ESTIMATE_NUMBER", GetType(Integer))
                .EstimateComponentNumber = NewAlert.GetDataRowValue(DataRow, "EST_COMPONENT_NBR", GetType(Short))

            End With

            Return NewAlert

        End Function
        Private Function GetDataRowValue(ByVal DataRow As System.Data.DataRow, FieldName As String, ConvertToType As Type) As Object

            'objects
            Dim Value As Object = Nothing

            Try

                If Not IsDBNull(DataRow(FieldName)) AndAlso DataRow(FieldName) IsNot Nothing Then

                    Value = Convert.ChangeType(DataRow(FieldName), ConvertToType)

                End If

            Catch ex As Exception

            End Try

            Return Value

        End Function
        Private Function GetGroupKey(ByVal DataRow As System.Data.DataRow, ByVal GroupType As String) As String

            'objects
            Dim FieldName As String = Nothing

            If GroupType = "" Then

                Return ""

            Else

                Select Case GroupType

                    Case "O"

                        FieldName = "GRP_OFFICE"

                    Case "C"

                        FieldName = "GRP_CLIENT"

                    Case "CD"

                        FieldName = "GRP_DIVISION"

                    Case "CDP"

                        FieldName = "GRP_PRODUCT"

                    Case "CDPJ"

                        FieldName = "GRP_JOB"

                    Case "CDPJC"

                        FieldName = "GRP_COMPONENT"

                    Case "CM"

                        FieldName = "GRP_CAMPAIGN"

                    Case "PST"

                        FieldName = "GRP_TASK"

                    Case "ES"

                        FieldName = "GRP_ESTIMATE"

                    Case "EST"

                        FieldName = "GRP_ESTIMATE_COMPONENT"

                    Case "DUE_DATE", "DUE_DATE_ASC"

                        FieldName = "GRP_DUE_DATE_DISPLAY"

                    Case "PRIORITY"

                        FieldName = "CARD_GROUPING_PRIORITY_TEXT" ' "GRP_PRIORITY"

                    Case "AB"

                        FieldName = "GRP_ATB"

                    Case "LAST_UPD"

                        FieldName = "GRP_LAST_UPD"

                    Case "VER_BLD"

                        FieldName = "VERSION_BUILD" ' "GRP_VER_BLD"

                    Case "CAT"

                        FieldName = "CATEGORY"

                    Case "NEW_UNREAD"

                        FieldName = "READ_ALERT_TEXT"

                    Case "STATE"

                        FieldName = "ALERT_STATE_NAME"

                    Case Else

                        FieldName = "END_SELECT_CLAUSE"

                End Select

                Return GetDataRowValue(DataRow, FieldName, GetType(String))

            End If

        End Function

#End Region

#Region " Classes "

        <Serializable()>
        Public Class SoftwareVersion

            Public Property ID As Integer = 0
            Public ReadOnly Property Key As String
                Get
                    Return ID.ToString
                End Get
            End Property
            Public Property Name As String
            Public Property Description As String
            Public Property IsActive As Boolean? = False

            Public Sub New()

            End Sub
            Public Sub New(ByVal Item As AdvantageFramework.Database.Entities.SoftwareVersion)

                Me.ID = Item.ID
                Me.Name = Item.Name
                Me.Description = Item.Description
                Me.IsActive = Item.IsActive

            End Sub

        End Class

        <Serializable()>
        Public Class SoftwareBuild

            Public Property ID As Integer = 0
            Public Property VersionID As Integer = 0
            Public ReadOnly Property Key As String
                Get
                    Return ID.ToString
                End Get
            End Property
            Public Property Name As String
            Public Property Description As String
            Public Property IsActive As Boolean? = False

            Public Sub New()


            End Sub
            Public Sub New(ByVal Item As AdvantageFramework.Database.Entities.SoftwareBuild)

                Me.ID = Item.ID
                Me.VersionID = Item.VersionID
                Me.Name = Item.Name
                Me.Description = Item.Description
                Me.IsActive = Item.IsActive

            End Sub

        End Class

        <Serializable()>
        Public Class AlertState

            Public Property ID As Integer = 0
            Public Property Name As String

            Public Sub New()

            End Sub
            Public Sub New(ByVal Item As AdvantageFramework.Database.Entities.AlertState)

                Me.ID = Item.ID
                Me.Name = Item.Name

            End Sub

        End Class

        <Serializable()>
        Public Class AlertTemplateState
            Inherits AlertState

            Public Property DefaultEmployeeCode As String
            Public Property IsDefault As Boolean = False
            Public Property IsCompleted As Boolean = False

            Public Sub New()

            End Sub

        End Class

        <Serializable()>
        Public Class AlertTemplateStateEmployee
            Public Property Code As String = String.Empty
            Public Property Name As String = String.Empty
            Public Property IsDefault As Boolean = False
            Public Property IsSelected As Boolean = False
            Public Property IsCompleted As Boolean = False
            Public Property ProofingStatusID As Integer? = Nothing
            Public Sub New()

            End Sub
        End Class

        <Serializable()>
        Public Class AlertTemplate

            Public Property ID As Integer = 0
            Public Property Name As String
            Public Property ActiveFlag As Short = 0
            Public Property HasStates As Boolean = False
            Public Property HasEmployees As Boolean = False

        End Class

        <Serializable()>
        Public Class AlertCategory

            Public Property ID As Integer = 0
            Public Property AlertTypeID As Integer = 0
            Public Property Description As String

            Public Sub New()

            End Sub

        End Class

        <Serializable()>
        Public Class BoardState

            Public Property ID As Integer = 0
            Public Property Name As String
            Public Property SequenceNumber As Short?
            Public Property BoardDetailID As Integer = 0
            Public Property BoardColumnID As Integer = 0
            Public Property BoardColumnName As String
            Public Property BoardColumnSequenceNumber As Short?

            Public Sub New()


            End Sub

        End Class

        <Serializable()>
        Public Class ChecklistHeader

            Public Property ID As Integer
            Public Property Description As String
            Public Property CreatedBy As String
            Public Property CreatedDate As Date?
            Public Property ChecklistItems As Generic.List(Of ChecklistDetail)

            Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.ChecklistHeader) As ChecklistHeader

                'objects
                Dim Header = New ChecklistHeader

                With Header

                    .ID = Entity.ID
                    .Description = Entity.Description
                    .CreatedBy = Entity.CreatedBy
                    .CreatedDate = Entity.CreatedDate

                End With

                Return Header

            End Function
            Public Sub New()

                Me.ChecklistItems = New Generic.List(Of ChecklistDetail)

            End Sub

        End Class

        <Serializable()>
        Public Class ChecklistDetail

            Public Property ID As Integer
            Public Property Description As String
            Public Property IsChecked As Boolean?
            Public Property SortOrder As Short?
            Public Property CreatedBy As String
            Public Property CreatedDate As Date?
            Public Property ModifiedBy As String
            Public Property ModifiedDate As Date?
            Public Property ChecklistHeaderID As Integer

            Public Shared Function FromEntity(ByVal Entity As AdvantageFramework.Database.Entities.ChecklistDetail) As ChecklistDetail

                'objects
                Dim Detail As ChecklistDetail = Nothing

                Detail = New ChecklistDetail

                With Detail

                    .ID = Entity.ID
                    .Description = Entity.Description
                    .IsChecked = Entity.IsChecked
                    '.SortOrder = Entity.sort
                    .CreatedBy = Entity.CreatedBy
                    .CreatedDate = Entity.CreatedDate
                    .ModifiedBy = Entity.ModifiedBy
                    .ModifiedDate = Entity.ModifiedDate
                    .ChecklistHeaderID = Entity.ChecklistID

                End With

                Return Detail

            End Function
            Public Sub New()



            End Sub

        End Class

#End Region

    End Class

End Namespace

