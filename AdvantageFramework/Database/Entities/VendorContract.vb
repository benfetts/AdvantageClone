Namespace Database.Entities

    Public Class VendorContract
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            VendorCode
            Description
            StartDate
            EndDate
            Comments
            IsInactive
            CreatedByUserCode
            CreateDate
            ModifiedByUserCode
            ModifiedDate
            RenewalAlertSentDate
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

		<System.ComponentModel.DataAnnotations.Required(),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String

		<System.ComponentModel.DataAnnotations.Required(),
		System.ComponentModel.DataAnnotations.MaxLength(6),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property VendorCode() As String

		<System.ComponentModel.DataAnnotations.Required(),
		System.ComponentModel.DataAnnotations.MaxLength(100),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String

		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property StartDate() As Nullable(Of Date)

		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property EndDate() As Nullable(Of Date)

		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property Comments() As String

		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Boolean

		<System.ComponentModel.DataAnnotations.MaxLength(100),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreatedByUserCode() As String

		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property CreateDate() As Date

		<System.ComponentModel.DataAnnotations.MaxLength(100),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ModifiedByUserCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RenewalAlertSentDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Overridable Property VendorContractContacts As ICollection(Of Database.Entities.VendorContractContact)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Overridable Property VendorContractDocuments As ICollection(Of Database.Entities.VendorContractDocument)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
