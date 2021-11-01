Namespace Database.Entities

	<Table("PO_APPR_RULE_EMP")>
	Public Class PurchaseOrderApprovalRuleEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			PurchaseOrderApprovalRuleCode
			PurchaseOrderApprovalRuleDetailSequenceNumber
			EmployeeCode
			Order
			IsInactive
			PurchaseOrderRuleDetail
			POApprovals

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("PO_APPR_RULE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property PurchaseOrderApprovalRuleCode() As String
		<Required>
		<Column("SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property PurchaseOrderApprovalRuleDetailSequenceNumber() As Short
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Employee", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
		Public Property EmployeeCode() As String
		<Column("APPR_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Approver Type")>
		Public Property Order() As Nullable(Of Short)
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        <ForeignKey("PurchaseOrderApprovalRuleCode, PurchaseOrderApprovalRuleDetailSequenceNumber")>
        Public Overridable Property PurchaseOrderRuleDetail As Database.Entities.PurchaseOrderApprovalRuleDetail
        Public Overridable Property POApprovals As ICollection(Of Database.Entities.POApproval)

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

                Case AdvantageFramework.Database.Entities.PurchaseOrderApprovalRuleEmployee.Properties.EmployeeCode.ToString

                    PropertyValue = Value

                    If PropertyValue Is Nothing OrElse PropertyValue.ToString.Trim = "" Then

                        IsValid = False

                        ErrorText = "Employee is required."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
