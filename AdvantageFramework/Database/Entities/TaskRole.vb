Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.TASK_TRAFFIC_ROLE")>
    Public Class TaskRole
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TaskCode
            RoleCode
        End Enum

#End Region

#Region " Variables "

        Private _TaskCode As String = ""
        Private _RoleCode As String = ""

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TRF_CODE", Storage:="_TaskCode", DbType:="varchar NOT NULL", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Task Code"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property TaskCode() As String
			Get
				TaskCode = _TaskCode
			End Get
			Set(ByVal value As String)
				_TaskCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ROLE_CODE", Storage:="_RoleCode", DbType:="varchar NOT NULL", IsPrimaryKey:=True),
		System.ComponentModel.DisplayName("Role Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property RoleCode() As String
            Get
                RoleCode = _RoleCode
            End Get
            Set(ByVal value As String)
                _RoleCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.TaskCode & " - " & Me.RoleCode

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String
            'objects
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.DatabaseAction = Action.Inserting Then

                    If AdvantageFramework.Database.Procedures.TaskRole.LoadByTaskCodeAndRoleCode(DataContext, Me.TaskCode, Me.RoleCode) IsNot Nothing Then

                        IsValid = False
                        ErrorText = "Task already exits with this role."

                    End If

                End If

            End If

            ValidateEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.TaskRole.Properties.TaskCode.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a task code."

                    End If

                    If IsValid Then

                        If AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Please enter a valid task code."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.TaskRole.Properties.RoleCode.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a role code."

                    End If

                    If IsValid Then

                        If AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Please enter a valid role code."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
