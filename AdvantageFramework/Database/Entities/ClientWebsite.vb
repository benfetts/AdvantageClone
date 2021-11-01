Namespace Database.Entities

    <Table("CL_WEBSITE")>
    Public Class ClientWebsite
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            WebsiteTypeCode
            WebsiteAddress
            WebsiteName
            IsInactive
            Client
            WebsiteType

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Key>
        <Required>
        <Column("WEBSITE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(2147483647)>
        <Column("WEBSITE_ADDRESS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WebsiteAddress() As String
        <Required>
        <MaxLength(6)>
        <Column("WEBSITE_TYPE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Website Type", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.WebsiteTypeCode)>
        Public Property WebsiteTypeCode() As String
        <MaxLength(255)>
        <Column("WEBSITE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WebsiteName() As String
        <Required>
        <Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean

        Public Overridable Property Client As Database.Entities.Client
        Public Overridable Property WebsiteType As Database.Entities.WebsiteType

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.WebsiteTypeCode

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ClientWebsite.Properties.WebsiteAddress.ToString

                    If IsValid Then

                        If Me.IsEntityBeingAdded() Then

                            PropertyValue = Value

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientWebsites
                                Where Entity.WebsiteAddress.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso
                                      Entity.ClientCode.ToUpper = DirectCast(Me.ClientCode, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "Please enter a unique website address."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
