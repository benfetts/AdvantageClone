Namespace Database.Entities

	<Table("PO_PRINT_DEF")>
	Public Class PurchaseOrderPrintDefault
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			UserID
			DateToPrint
			ShippingInstructions
			PurchaseOrderInstructions
			FooterComment
			DetailDescription
			DetailInstruction
			VendorContact
			ClientName
			ProductName
			JobComponentNumber
			LocationID
			LogoPath
			ReportFormat
			FunctionDescription
			JobDescription
			UseEmployeeSignature
            VendorCode
            JobComponentDescription
            UseLocationName
            UseClientName

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserID() As String
		<Column("DATE_TO_PRINT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateToPrint() As Nullable(Of Short)
		<Column("SHP_INSTRUCTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShippingInstructions() As Nullable(Of Short)
		<Column("PO_INSTRUCTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PurchaseOrderInstructions() As Nullable(Of Short)
		<Column("FOOTER_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FooterComment() As Nullable(Of Short)
		<Column("DETAIL_DESCRIPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailDescription() As Nullable(Of Short)
		<Column("DETAIL_INSTRUCTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailInstruction() As Nullable(Of Short)
		<Column("VENDOR_CONTACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorContact() As Nullable(Of Short)
		<Column("CLIENT_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientName() As Nullable(Of Short)
		<Column("PRODUCT_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductName() As Nullable(Of Short)
		<Column("JOB_CMP_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("LOCATION_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LocationID() As String
		<MaxLength(254)>
		<Column("LOGO_PATH", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LogoPath() As String
		<MaxLength(50)>
		<Column("REPORT_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportFormat() As String
		<Column("FNC_DESCRIPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionDescription() As Nullable(Of Short)
		<Column("JOB_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobDescription() As Nullable(Of Short)
		<Column("USE_EMP_SIG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseEmployeeSignature() As Nullable(Of Short)
		<Column("VENDOR_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As Nullable(Of Integer)
        <Column("USE_USER_SIG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseUserSignature() As Nullable(Of Short)
        <Column("JOB_COMP_DESC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As Nullable(Of Short)
        <Column("USE_LOCATION_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseLocationName() As Nullable(Of Short)
        <Column("USE_CLIENT_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseClientName() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserID.ToString

        End Function

#End Region

	End Class

End Namespace
