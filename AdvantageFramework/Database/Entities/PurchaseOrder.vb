Namespace Database.Entities

	<Table("PURCHASE_ORDER")>
	Public Class PurchaseOrder
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			CreatedDate
			UserCode
			VendorCode
			EmployeeCode
			[Date]
			DueDate
			Description
			MainInstruction
			IsComplete
			DeliveryInstruction
			IsVoid
			VoidedByUserCode
			VoidDate
			Revision
			IsWorkComplete
			IsArchived
			VendorContactCode
			Footer
			WVFlag
			ApprovalFlag
			IsPrinted
			PurchaseOrderApprovalRuleCode
			ExceedFlag
			LockUserCode
			ModifiedByUserCode
			ModifiedDate
			PurchaseOrderApprovalRule
			POApprovals
			PurchaseOrderDetails
			Vendor

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Column("PO_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Number() As Integer
		<Column("PO_CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property VendorCode() As String
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Column("PO_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property [Date]() As Nullable(Of Date)
		<Column("PO_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DueDate() As Nullable(Of Date)
		<MaxLength(40)>
		<Column("PO_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("PO_MAIN_INSTRUCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MainInstruction() As String
		<Column("PO_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsComplete() As Nullable(Of Short)
		<Column("DEL_INSTRUCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeliveryInstruction() As String
		<Column("VOID_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsVoid() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("VOIDED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidedByUserCode() As String
		<Column("VOID_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VoidDate() As Nullable(Of Date)
		<Column("PO_REVISION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMinValue:=True, MinValue:=0, UseMaxValue:=True, MaxValue:=999)>
        Public Property Revision() As Nullable(Of Short)
		<Column("PO_WORK_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsWorkComplete() As Nullable(Of Short)
		<Column("ARCHIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsArchived() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("VN_CONT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorContactCode() As String
		<Column("PO_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Footer() As String
		<Required>
		<Column("WV_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WVFlag() As Short
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)>
		<Column("PO_APPROVAL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovalFlag() As Nullable(Of Short)
		<Column("PO_PRINTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsPrinted() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PurchaseOrderApprovalRuleCode() As String
		<Column("EXCEED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExceedFlag() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("LOCK_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LockUserCode() As String
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)

        Public Overridable Property PurchaseOrderApprovalRule As Database.Entities.PurchaseOrderApprovalRule
        Public Overridable Property POApprovals As ICollection(Of Database.Entities.POApproval)
        Public Overridable Property PurchaseOrderDetails As ICollection(Of Database.Entities.PurchaseOrderDetail)
        Public Overridable Property Vendor As Database.Entities.Vendor

#End Region

#Region " Methods "

        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.PurchaseOrder.Properties.VendorContactCode.ToString

                    PropertyValue = Value

                    If Not String.IsNullOrWhiteSpace(DirectCast(PropertyValue, String)) Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).VendorContacts
                            Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                              Entity.VendorCode = Me.VendorCode AndAlso
                              (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Please enter a valid vendor contact."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ToString() As String

            ToString = Me.Number.ToString

        End Function

#End Region

	End Class

End Namespace
