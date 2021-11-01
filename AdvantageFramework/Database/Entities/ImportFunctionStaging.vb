Namespace Database.Entities

	<Table("IMP_FUNCTION_STAGING")>
	Public Class ImportFunctionStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			IsNew
			IsOnHold
			Code
			Description
			Type
			DepartmentTeamCode
			LineConsolidation
			CPMFlag
			FunctionOrder
			IsInactive
			FunctionHeadingID
			EmployeeExpenseFlag
			NonBillableClientGLACode
			OverheadGLACode

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<Required>
		<Column("IS_NEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Boolean
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("FNC_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(1)>
		<Column("FNC_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As String
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Department / Team", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
		Public Property DepartmentTeamCode() As String
		<MaxLength(6)>
		<Column("FNC_CONSOLIDATION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Consolidation Code", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
		Public Property LineConsolidation() As String
		<Column("FNC_CPM_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="CPM", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property CPMFlag() As Nullable(Of Short)
		<Column("FNC_ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", UseMaxValue:=True, MaxValue:=999)>
        Public Property FunctionOrder() As Nullable(Of Short)
		<Column("FNC_INACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("FNC_HEADING_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Heading Description", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionHeadingID)>
		Public Property FunctionHeadingID() As Nullable(Of Integer)
		<Column("EX_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Expense", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property EmployeeExpenseFlag() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("NONBILL_CLI_GLACCT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Billable Client Account", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property NonBillableClientGLACode() As String
		<MaxLength(30)>
		<Column("OVERHEAD_GLACCT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Overhead Account", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property OverheadGLACode() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.Code.ToString

                    If Me.IsNew Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Functions _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper _
                                Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Function code already exists in the system."

                        Else

                            Try

                                If _DataContext IsNot Nothing Then

                                    _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                End If

                            Catch ex As Exception
                                _DataContext = Nothing
                            End Try

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(_DbContext, PropertyValue) Is Nothing Then

                            IsValid = False
                            ErrorText = "Function code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.Description.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a functions's description."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportFunctionStaging.Properties.Type.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a functions's type."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
