Namespace Database.Entities

	<Table("AD_NUMBER")>
	Public Class Ad
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Number
			Description
			IsInactive
			BlackplateCode1
			BlackplateCode2
            ClientCode
            DivisionCode
            ProductCode
            DocumentID
            Color
            MediaType
            Length
            StartDate
            ExpirationDate
			Client
			JobComponents
			Blackplates
			Blackplate1
			Blackplate2
			DigitalResults
            MediaPlanDetailLevelLineTags
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(30)>
		<Column("AD_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Ad Number")>
		Public Property Number() As String
		<Required>
		<MaxLength(60)>
		<Column("AD_NBR_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Description() As String
		<Column("ACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("DEF_BLKPLT_VER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Blackplate 1", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Blackplate)>
		Public Property BlackplateCode1() As String
		<MaxLength(6)>
		<Column("DEF_BLKPLT_VER2_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Blackplate 2", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Blackplate)>
		Public Property BlackplateCode2() As String
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <Column("DIV_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
        <MaxLength(6)>
        <Column("PRD_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
        <Column("DOCUMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
		Public Property DocumentID() As Nullable(Of Integer)
		<MaxLength(7)>
		<Column("COLOR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Color() As String
        <MaxLength(1)>
        <Column("MEDIA_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.MediaType)>
        Public Property MediaType() As String
        <Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Length() As Nullable(Of Integer)
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
        <Column("EXP_DT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExpirationDate() As Nullable(Of Date)

        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property JobComponents As ICollection(Of Database.Entities.JobComponent)
        <ForeignKey("BlackplateCode1")>
        Public Overridable Property Blackplate1 As Database.Entities.Blackplate
        <ForeignKey("BlackplateCode2")>
        Public Overridable Property Blackplate2 As Database.Entities.Blackplate
        Public Overridable Property DigitalResults As ICollection(Of Database.Entities.DigitalResult)
        Public Overridable Property MediaPlanDetailLevelLineTags As ICollection(Of Database.Entities.MediaPlanDetailLevelLineTag)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Number & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Ad.Properties.Number.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Ads
                            Where Entity.Number.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique ad number."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.Ad.Properties.StartDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.ExpirationDate.HasValue Then

                            If Me.ExpirationDate.Value < CDate(PropertyValue) Then

                                IsValid = False

                                ErrorText = "Please enter a valid start date."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.Ad.Properties.ExpirationDate.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If Me.StartDate.HasValue Then

                            If Me.StartDate.Value > CDate(PropertyValue) Then

                                IsValid = False

                                ErrorText = "Please enter a valid expiration date."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
