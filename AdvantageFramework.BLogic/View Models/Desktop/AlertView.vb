Namespace ViewModels.Desktop

    <Serializable>
    Public Class AlertView

        Public Property CanUpdate As Boolean = True
        Public Property CanAdd As Boolean = True
        Public Property CanPrint As Boolean = True
        Public Property CanCustom1 As Boolean = True
        Public Property CanCustom2 As Boolean = True
        Public Property AutoClose As Boolean = False
        Public Property HideSystemComments As Boolean = False
        Public Property ShowChecklistsOnCards As Boolean = False
        Public Property DetailsExpanded As Boolean = False
        Public Property WidgetLayout As String()
        Public Property Alert As AdvantageFramework.DTO.Desktop.Alert
        Public Property AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)
        Public Property AlertAttachments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertAttachment)
        Public Property AlertTemplateStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState)
        Public Property AlertCategories As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertCategory)
        Public Property BoardStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.BoardState)
        Public Property HasBoard As Boolean = False
        Public Property UploadDocumentManager As Boolean = False
        Public Property TaskStatusCode As String = String.Empty
        Public Property TaskStatusDescription As String = String.Empty
        Public Sub New()

        End Sub

    End Class
    <Serializable>
    Public Class AlertSecurityViewModel

        Public Property CanUpdate As Boolean = True
        Public Property CanAdd As Boolean = True
        Public Property CanPrint As Boolean = True
        Public Property CanCustom1 As Boolean = True
        Public Property CanCustom2 As Boolean = True

        Sub New()

        End Sub

    End Class
    <Serializable>
    Public Class AlertSettingsViewModel

        Public Property AutoClose As Boolean = False
        Public Property HideSystemComments As Boolean = False
        Public Property ShowChecklistsOnCards As Boolean = False
        Public Property DetailsExpanded As Boolean = False
        Public Property WidgetLayout As String()
        Public Property UploadDocumentManager As Boolean = False

        Sub New()

        End Sub

    End Class
    <Serializable>
    Public Class ActiveEmployeeViewModel


        Public Property ClientContactID As Integer = 0
        Public Property Code As String = String.Empty
        Public Property Name As String = String.Empty

        Sub New()

        End Sub

    End Class
    <Serializable>
    Public Class AlertCategoryViewModel

        Public Property ID As Integer
        Public Property AlertTypeID As Integer
        Public Property Description As String

        Sub New()

        End Sub

    End Class
    <Serializable>
    Public Class AlertAssignmentViewModel
        Public Property AlertTemplateID As Integer
        Public Property AlertTemplateName As String
        Public Property States As Generic.List(Of AlertStateViewModel)

        Sub New()

            States = New List(Of AlertStateViewModel)

        End Sub

    End Class
    <Serializable>
    Public Class AlertStateViewModel
        Public Property AlertStateID As Integer
        Public Property AlertStateName As String
        Public Property Employees As Generic.List(Of AlertStateEmployeeViewModel)
        Public Property CanEdit As Boolean? = False

        Sub New()

            Employees = New List(Of AlertStateEmployeeViewModel)

        End Sub

    End Class
    <Serializable>
    Public Class AlertStateEmployeeViewModel
        Public Property AlertTemplateID As Integer? = 0
        Public Property AlertStateID As Integer? = 0
        Public Property EmployeeCode As String
        Public Property FullName As String
        Public Property IsDefault As Boolean? = False
        Public Property IsSelected As Boolean? = False
        Public Property CanDelete As Boolean? = False
        Public Property ProofingStatusID As Integer? = 0
        Public ReadOnly Property ProofingStatusText As String
            Get
                Dim s As String = String.Empty
                If ProofingStatusID IsNot Nothing Then
                    Select Case ProofingStatusID
                        Case 1
                            s = "Approved"
                        Case 2
                            s = "Rejected"
                        Case 3
                            s = "Deferred"
                        Case Else
                            s = "Not Set"
                    End Select
                End If
                Return s
            End Get
        End Property
        Public Property StatusDate As DateTime? = Nothing
        Public ReadOnly Property StatusDateText As String
            Get
                If StatusDate IsNot Nothing Then
                    Return CType(StatusDate, DateTime).ToShortDateString & " " & CType(StatusDate, DateTime).ToShortTimeString
                Else
                    Return String.Empty
                End If
            End Get
        End Property

        Public Property CssClass As String
        Sub New()

        End Sub
    End Class
    <Serializable>
    Public Class AlertTemplateQueryResultViewModel
        Public Property RowID As Integer = 0
        Public Property AlertID As Integer = 0
        Public Property AlertTemplateID As Integer = 0
        Public Property AlertTemplateName As String = String.Empty
        Public Property AlertStateID As Integer = 0
        Public Property AlertStateName As String = String.Empty
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeFullName As String = String.Empty
        Public Property IsDefaultEmployee As Boolean = False
        Public Property IsEmployeeSelected As Boolean = False
        Public Property ProofingStatusID As Integer? = 0
        Public Property ProofingStatusDate As DateTime? = Nothing
        Public Property StateOrder As Short = 0
        Public Property IsCurrentState As Boolean? = False
        Public Property CanEditStateEmployees As Boolean? = False
        Public Property CanDeleteEmployee As Boolean? = False
        Public Property TemporaryID As String = String.Empty
        Public Property TotalMarkupCount As Integer? = 0
        Public ReadOnly Property ProofingStatusText As String
            Get
                Dim s As String = String.Empty
                If ProofingStatusID IsNot Nothing Then
                    Select Case ProofingStatusID
                        Case 1
                            s = "Approved"
                        Case 2
                            s = "Rejected"
                        Case 3
                            s = "Deferred"
                        Case Else
                            s = "Not Set"
                    End Select
                End If
                Return s
            End Get
        End Property
        Public ReadOnly Property StatusDateText As String
            Get
                If ProofingStatusDate IsNot Nothing Then
                    Return CType(ProofingStatusDate, DateTime).ToShortDateString & " " & CType(ProofingStatusDate, DateTime).ToShortTimeString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Sub New()

        End Sub
    End Class
    <Serializable>
    Public Class ExternalReviewerViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ProofingExternalReviewerID As Integer
        Public Property Email As String = String.Empty
        Public Property Name As String = String.Empty
        Public Property ProofingStatusID As Integer?
        Public Property ProofingStatusName As String = String.Empty
        Public Property ProofingStatusDate As DateTime? = Nothing
        Public Property IsSelected As Boolean = False
        Public Property CanDelete As Boolean = False
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductDescription As String = String.Empty
        Public Property CDP As String = String.Empty
        Public ReadOnly Property StatusDateText As String
            Get
                If ProofingStatusDate IsNot Nothing AndAlso IsDate(ProofingStatusDate) = True Then
                    Return CDate(ProofingStatusDate).ToShortDateString() & " " & CDate(ProofingStatusDate).ToShortTimeString()
                Else
                    Return ""
                End If
            End Get
        End Property
        Public ReadOnly Property FullName As String
            Get
                Return Name
            End Get
        End Property

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class
    <Serializable>
    Public Class AlertRecipientExternalViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer?
        Public Property AlertID As Integer?
        Public Property ProofingExternalID As Integer?
        Public Property AlertTemplateID As Integer?
        Public Property AlertStateID As Integer?
        Public Property ProofingStatusID As Integer?
        Public Property IsRead As Boolean? = False

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class
    <Serializable>
    Public Class AlertRecipientExternalDismissedViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer?
        Public Property AlertID As Integer?
        Public Property ProofingExternalID As Integer?
        Public Property AlertTemplateID As Integer?
        Public Property AlertStateID As Integer?
        Public Property ProofingStatusID As Integer?
        Public Property IsRead As Boolean? = False

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace





