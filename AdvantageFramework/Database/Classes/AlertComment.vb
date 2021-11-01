Namespace Database.Classes

    <Serializable()>
    Public Class AlertComment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CommentID
            Comment
            ShortComment
            IsTruncated
            UserName
            EmployeeCode
            GeneratedDate
            EmployeeFullName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property RowID() As Integer
        Public Property CommentID() As Integer
        Public Property GeneratedDate() As Nullable(Of Date)
        Public Property Comment() As String
        Public Property ShortComment() As String
        Public Property IsTruncated() As Nullable(Of Integer)
        Public Property IsClientPortalComment As Nullable(Of Boolean)
        Public Property UserName() As String
        Public Property UserCode() As String
        Public Property EmployeeCode() As String
        Public Property AssignedEmployeeCode() As String
        Public Property AlertTemplateID As Nullable(Of Integer)
        Public Property AlertTemplateName() As String
        Public Property AlertStateID As Nullable(Of Integer)
        Public Property AlertStateName() As String
        Public Property AssignmentChanged As Nullable(Of Boolean)
        Public Property IsUnassigned As Nullable(Of Boolean)
        Public Property DocumentList() As String
        Public Property EmployeeFullName() As String
        Public Property EmployeeNickname() As String
        Public Property EmployeeImage As Byte()
        Public Property AssignedFullName() As String
        Public Property AssignedEmployeeNickname() As String
        Public Property AssignedEmployeeImage As Byte()
        Public Property CustodyStartDate As Nullable(Of Date)
        Public Property CustodyEndDate As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.CommentID.ToString

        End Function

#End Region

    End Class

End Namespace
