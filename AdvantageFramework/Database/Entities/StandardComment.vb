Namespace Database.Entities

	<Table("STD_COMMENT")>
	Public Class StandardComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientCode
			DivisionCode
			ProductCode
			VendorCode
			ApplicationCode
			CommentType
			Comment
			FontSize
            OfficeCode
            HtmlComment
            MediaType
            Client
			Division
			Product
			Vendor
            Office
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("COMMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("CLIENT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIVISION_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRODUCT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(6)>
		<Column("VENDOR_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<Required>
		<MaxLength(50)>
		<Column("APP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Application")>
		Public Property ApplicationCode() As String
		<Required>
		<MaxLength(50)>
		<Column("COMMENT_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CommentType() As String
		<Required>
		<Column("STD_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Comment() As String
		<Column("FONT_SIZE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property FontSize() As Nullable(Of Short)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
        <Column("HTML_COMMENT", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HtmlComment() As String
        <MaxLength(1)>
        <Column("MEDIA_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String

        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Vendor As Database.Entities.Vendor
        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.IsEntityBeingAdded() Then

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).StandardComments.ToList
                        Where Entity.ApplicationCode = Me.ApplicationCode AndAlso
                              Entity.CommentType = Me.CommentType AndAlso
                              Entity.OfficeCode = Me.OfficeCode AndAlso
                              Entity.ClientCode = Me.ClientCode AndAlso
                              Entity.DivisionCode = Me.DivisionCode AndAlso
                              Entity.ProductCode = Me.ProductCode AndAlso
                              Entity.VendorCode = Me.VendorCode AndAlso
                              Entity.MediaType = Me.MediaType
                        Select Entity).Any Then

                        IsValid = False
                        ErrorText = "Please enter a unique standard comment."

                    End If

                Else

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).StandardComments.ToList
                        Where Entity.ID <> Me.ID AndAlso
                              Entity.ApplicationCode = Me.ApplicationCode AndAlso
                              Entity.CommentType = Me.CommentType AndAlso
                              Entity.OfficeCode = Me.OfficeCode AndAlso
                              Entity.ClientCode = Me.ClientCode AndAlso
                              Entity.DivisionCode = Me.DivisionCode AndAlso
                              Entity.ProductCode = Me.ProductCode AndAlso
                              Entity.VendorCode = Me.VendorCode AndAlso
                              Entity.MediaType = Me.MediaType
                        Select Entity).Any Then

                        IsValid = False
                        ErrorText = "The standard comment already exists in the system."

                    End If

                End If
                
            End If

            ValidateEntity = ErrorText

        End Function

#End Region

	End Class

End Namespace
