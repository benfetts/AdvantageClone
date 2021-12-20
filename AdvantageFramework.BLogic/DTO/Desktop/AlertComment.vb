Namespace DTO.Desktop
    <Serializable> Public Class AlertComment
#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            RowID
            CommentID
            AlertID
            GeneratedDate
            CustodyStartDate
            CustodyEndDate
            sGeneratedDate
            sCustodyStartDate
            sCustodyEndDate
            Comment
            UserName
            UserCode
            EmployeeCode
            EmployeeFullName
            EmployeeNickname
            AssignedEmployeeCode
            AssignedEmployeeFullName
            AssignedEmployeeNickname
            AlertTemplateID
            AlertTemplateName
            AlertStateID
            AlertStateName
            AssignmentChanged
            IsUnassigned
            ParentID
            ReplyLevel
            DocumentList
            Documents
            Replies
            MarkupID
            MarkupXML
            Markup
            MarkupDocumentID
            MarkupGeneratedDate
            MarkupTypeID
            MarkupThumbnail

        End Enum


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
        Public Property ParentID As Integer?
        Public Property ReplyLevel As Integer?
        <System.Web.Script.Serialization.ScriptIgnore>
        Public Property DocumentList As String
        Public Property Documents As Generic.List(Of CommentDocument)
        Public Property Replies As Generic.List(Of AlertComment)
        Public Property MarkupID As Integer?
        Public Property MarkupXML As String
        Public Property Markup As String
        Public Property MarkupDocumentID As Integer?
        Public Property MarkupGeneratedDate As Date?
        Public ReadOnly Property sMarkupGeneratedDate As String
            Get
                If MarkupGeneratedDate IsNot Nothing Then
                    Return MarkupGeneratedDate.ToString
                Else
                    Return String.Empty
                End If
            End Get
        End Property
        Public Property MarkupTypeID As Integer?
        Public Property MarkupThumbnail As Byte()
        Public Property ProofingExternalReviewerID As Integer?
        Public Property HasImage As Boolean? = False
        Public Property Initials As String = String.Empty
        Public Property DocumentID As Integer? = 0
        Public Property IsMyComment As Boolean? = False

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

#Region " Classes "

        <Serializable> Public Class CommentDocument

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
            Public Property ID As Integer
            Public Property Name As String
            Public Property Title As String
            Public Property Link As String
            Public Property MimeType As String

#End Region

#Region " Methods "
            Sub New()

            End Sub

#End Region

        End Class

#End Region

    End Class

End Namespace
