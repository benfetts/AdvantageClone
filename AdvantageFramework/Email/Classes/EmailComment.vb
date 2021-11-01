
Namespace Email.Classes
    <Serializable> Public Class AlertComment
#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RowID As Integer
        Public Property CommentID As Integer
        Public Property AlertID As Integer
        Public Property GeneratedDate As Date?
        Public Property CustodyStartDate As Date?
        Public Property CustodyEndDate As Date?
        Public ReadOnly Property sGeneratedDate As String
            Get
                If GeneratedDate IsNot Nothing Then
                    Return GeneratedDate.ToString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public ReadOnly Property sCustodyStartDate As String
            Get
                If CustodyStartDate IsNot Nothing Then
                    Return CustodyStartDate.ToString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public ReadOnly Property sCustodyEndDate As String
            Get
                If CustodyEndDate IsNot Nothing Then
                    Return CustodyEndDate.ToString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public Property Comment As String
        Public Property UserName As String
        Public Property UserCode As String
        Public Property EmployeeCode As String
        Public Property EmployeeFullName As String
        Public Property EmployeeNickname As String
        Public Property AssignedEmployeeCode As String
        Public Property AssignedEmployeeFullName As String
        Public Property AssignedEmployeeNickname As String
        Public Property AlertTemplateID As Integer?
        Public Property AlertTemplateName As String
        Public Property AlertStateID As Integer?
        Public Property AlertStateName As String
        Public Property AssignmentChanged As Boolean
        Public Property IsUnassigned As Boolean
        Public Property ParentID As Integer
        Public Property ReplyLevel As Integer
        <System.Web.Script.Serialization.ScriptIgnore>
        Public Property DocumentList As String
        Public Property Documents As Generic.List(Of CommentDocument)
        Public Property Replies As Generic.List(Of AlertComment)
        Public Property ProofingExternalReviewerID As Integer?
        Public Property HasImage As Boolean? = False
        Public Property Initials As String = String.Empty

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

#Region " Classes "

        Public Class CommentDocument
            Public Property ID As Integer
            Public Property Name As String
        End Class

#End Region

    End Class

End Namespace
