Namespace Database.Entities

	<Table("TRAFFIC_PHASE")>
	Public Class Phase
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			OrderNumber
			IsInactive
			JobComponentTasks

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("TRAFFIC_PHASE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        Public Property ID() As Integer
		<Required>
		<MaxLength(40)>
		<Column("PHASE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Description() As String
		<Column("PHASE_ORDER")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Short

        Public Overridable Property JobComponentTasks As ICollection(Of Database.Entities.JobComponentTask)

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

                Case AdvantageFramework.Database.Entities.Phase.Properties.Description.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a phase description."

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Phases
                                Where Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique phase description."

                            End If

                        Else

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Phases _
                                   Where Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper AndAlso _
                                         Entity.ID <> Me.ID _
                                   Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique phase description."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
