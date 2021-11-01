Namespace Database.Entities

	<Table("ALERT_COMMENT")>
	Public Class AlertComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            AlertID
            UserCode
            GeneratedDate
            Comment
            HasEmailBeenSent
            ClientContactID
            DocumentList
            AssignedEmployeeCode
            AlertTemplateID
            AlertStateID
            ParentID
            IsDraft
            ConceptShareProjectID
            ConceptShareReviewID
            ConceptShareCommentID
            ConceptShareReplyID
            ConceptShareMarkupImage
            CustodyStart
            CustodyEnd
            BoardHeaderID
            BoardColumnID
            BoardDetailID
            BoardID
            IsSystem
            VendorRepresentativeCode
            VendorContactCode
            DocumentID
            ProofingStatusID
            Alert
            ProofingExternalReviewerID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("COMMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("ALERT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertID() As Integer
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("GENERATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneratedDate() As Nullable(Of Date)
		<Column("COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<Required>
		<Column("EMAILSENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HasEmailBeenSent() As Boolean
		<Column("USER_CODE_CP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Nullable(Of Integer)
		<MaxLength(6)>
		<Column("ASSIGNED_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedEmployeeCode() As String
        <Column("CS_PROJECT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareProjectID() As Nullable(Of Integer)
        <Column("CS_REVIEW_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareReviewID() As Nullable(Of Integer)
        <Column("CS_COMMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareCommentID() As Nullable(Of Integer)
        <Column("CS_REPLY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareReplyID() As Nullable(Of Integer)

        <Column("ALRT_NOTIFY_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertAssignmentTemplateID() As Nullable(Of Integer)
        <Column("ALERT_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertStateID() As Nullable(Of Integer)

        <Column("PARENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ParentID() As Nullable(Of Integer)
        <Column("IS_DRAFT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDraft() As Nullable(Of Boolean)
        <Column("CS_MARKUP_IMAGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareMarkupImage() As Byte()
        <Column("CUSTODY_START")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CustodyStart() As Nullable(Of Date)
        <Column("CUSTODY_END")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CustodyEnd() As Nullable(Of Date)
        <Column("BOARD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardID() As Nullable(Of Integer)
        <Column("BOARD_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardHeaderID() As Nullable(Of Integer)
        <Column("BOARD_COL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardColumnID() As Nullable(Of Integer)
        <Column("BOARD_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardDetailID() As Nullable(Of Integer)
        <Column("IS_SYSTEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsSystem() As Nullable(Of Boolean)
        <Column("VR_CODE", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorRepresentativeCode() As String
        <Column("VC_CODE", TypeName:="varchar")>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorContactCode() As String
        <Column("DOCUMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DocumentID() As Nullable(Of Integer)
        <Column("PROOFING_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProofingStatusID() As Nullable(Of Integer)
        <Column("PROOFING_X_REVIEWER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProofingExternalReviewerID() As Nullable(Of Integer)

        Public Overridable Property Alert As Database.Entities.Alert

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AlertComment.Properties.AlertID.ToString

                    Try

                        If Me.DbContext IsNot Nothing AndAlso Value IsNot Nothing AndAlso IsNumeric(Value) = True Then

                            If AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(Me.DbContext, Value) Is Nothing Then

                                IsValid = False
                                ErrorText = "Must assign comment to a valid alert."

                            End If

                        End If

                    Catch ex As Exception
                        IsValid = True
                    End Try

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
