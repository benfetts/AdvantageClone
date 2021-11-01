Namespace Database.Entities

	<Table("EMP_TIME_TMPLT")>
	Public Class EmployeeTimeTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeTimeTemplateID
			EmployeeCode
			JobNumber
			JobComponentNumber
			FunctionCode
			DefaultComment
			DepartmentTeamCode
			ProductCategoryCode
			EmployeeHours
			ApplyToDays
			DepartmentTeam

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("EMP_TIME_TMPLT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTimeTemplateID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Required>
		<MaxLength(10)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionCode() As String
		<Column("DFLT_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultComment() As String
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DepartmentTeamCode() As String
		<MaxLength(10)>
		<Column("PROD_CAT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCategoryCode() As String
		<Column("EMP_HOURS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeHours() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("APPLY_TO_DAYS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplyToDays() As String

        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTimeTemplateID.ToString

        End Function
        Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.EmployeeTimeTemplate.Properties.JobNumber.ToString,
                     AdvantageFramework.Database.Entities.EmployeeTimeTemplate.Properties.JobComponentNumber.ToString

                    SetRequired(PropertyName, Not Me.IsIndirectTime)

                Case AdvantageFramework.Database.Entities.EmployeeTimeTemplate.Properties.FunctionCode.ToString

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = PropertyName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Try

                            EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                        Catch ex As Exception
                            EntityAttribute = Nothing
                        End Try

                        If EntityAttribute IsNot Nothing Then

                            If Me.IsIndirectTime = True Then

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.IndirectCategory

                            Else

                                EntityAttribute.PropertyType = BaseClasses.PropertyTypes.FunctionCode

                            End If

                        End If

                    End If

            End Select

            ValidateEntityProperty = MyBase.ValidateEntityProperty(PropertyName, IsValid, Value)

        End Function
        Private Function IsIndirectTime() As Boolean

            'objects
            Dim IsIndirect As Boolean = False

            If Me.JobNumber.HasValue = False AndAlso Me.JobComponentNumber.HasValue = False Then

                IsIndirect = True

            End If

            IsIndirectTime = IsIndirect

        End Function

#End Region

	End Class

End Namespace
