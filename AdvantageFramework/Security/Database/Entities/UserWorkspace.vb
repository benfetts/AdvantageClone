Namespace Security.Database.Entities

	<Table("WV_USER_WORKSPACE")>
	Public Class UserWorkspace
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserCode
			Name
			Description
			SortOrder
			IsClientPortal
			WorkspaceObjects

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
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
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
		<Column("CP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsClientPortal() As Nullable(Of Integer)

        Public Overridable Property WorkspaceObjects As ICollection(Of Database.Entities.WorkspaceObject)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Security.Database.Entities.UserWorkspace.Properties.Name.ToString

                    If Me.IsEntityBeingAdded() Then

                        If IsClientPortal = 1 Then

                            If AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCodeAndNameCP(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.UserCode, Value, 1) IsNot Nothing Then

                                IsValid = False
                                ErrorText = "You already have a workspace with this name"

                            End If

                        Else

                            If AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCodeAndName(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.UserCode, Value) IsNot Nothing Then

                                IsValid = False
                                ErrorText = "You already have a workspace with this name"

                            End If

                        End If

                    Else

                        If IsClientPortal = 1 Then

                            UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCodeAndNameCP(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.UserCode, Value, 1)

                        Else

                            UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCodeAndName(DirectCast(_DbContext, AdvantageFramework.Security.Database.DbContext), Me.UserCode, Value)

                        End If

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
