Namespace Security.Database.Entities

	<Table("CP_USER_WORKSPACE")>
	Public Class ClientPortalUserWorkspace
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientContactID
			Name
			Description
			SortOrder
			ClientContact
			ClientPortalWorkspaceObjects

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("WORKSPACE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("CDP_CONTACT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("SORT_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SortOrder() As Nullable(Of Integer)

        <ForeignKey("ClientContactID")>
        Public Overridable Property ClientContact As Database.Entities.ClientContact
        Public Overridable Property ClientPortalWorkspaceObjects As ICollection(Of Database.Entities.ClientPortalWorkspaceObject)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace.Properties.Name.ToString

                    If Me.IsEntityBeingAdded() Then

                        If AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserCodeAndName(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.ClientContactID, Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "You already have a workspace with this name"

                        End If

                    Else

                        UserWorkspace = AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserCodeAndName(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.ClientContactID, Value)

                        If UserWorkspace IsNot Nothing Then

                            If UserWorkspace.ID <> Me.ID Then

                                IsValid = False
                                ErrorText = "You already have a workspace with this name"

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
