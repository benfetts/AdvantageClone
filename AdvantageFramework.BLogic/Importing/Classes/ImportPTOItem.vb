Namespace Importing.Classes

    <Serializable()>
    Public Class ImportPTOItem
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ImportID
            IsOnHold
            EmployeeCode
            EmployeeName
            EmployeeOffice
            Category
            Description
            ActivityStart
            Duration
            Status
            EmployeeEmail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
        Public Property ImportID() As Integer

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsOnHold() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.EmployeeCode, IsImportDefaultProperty:=True)>
        Public Property EmployeeCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.EmployeeName, IsReadOnlyColumn:=True)>
        Public Property EmployeeName() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property EmployeeOffice() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsImportDefaultProperty:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.IndirectCategory)>
        Public Property Category() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsImportDefaultProperty:=True, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Description() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ActivityStart() As System.Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property Duration() As System.Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Status() As Nullable(Of Short)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeEmail() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim Session As AdvantageFramework.Security.Session = Nothing
            Dim ShortDate As Date = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing
            Dim UsedOnBoardsCount As Integer

            Select Case PropertyName

                Case AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.EmployeeCode.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        If (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(Me.DbContext)
                            Where Entity.Code = DirectCast(PropertyValue, String)
                            Select Entity).Any = False Then

                            IsValid = False

                            ErrorText = "Employee code is not valid."

                        Else

                            Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Advantage, DbContext.ConnectionString, DbContext.UserCode, 0, DbContext.ConnectionString)

                            Using SecurityObjectContext As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                If (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Session, Me.DbContext, SecurityObjectContext)
                                    Where Entity.Code = DirectCast(PropertyValue, String)
                                    Select Entity).Any = False Then

                                    IsValid = False

                                    ErrorText = "You do not have rights to this employee or office."

                                End If

                            End Using

                        End If

                    End If

                Case AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Category.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.ActivityStart.HasValue AndAlso (Me.Status = 1) Then

                        ShortDate = Me.ActivityStart.Value.ToShortDateString

                        EmployeeTime = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                                        Where Entity.EmployeeCode = Me.EmployeeCode AndAlso
                                              Entity.Date = ShortDate
                                        Select Entity).SingleOrDefault

                        If EmployeeTime IsNot Nothing Then

                            If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByID(DbContext, EmployeeTime.ID)
                                Where Entity.Category = DirectCast(PropertyValue, String)
                                Select Entity).Any Then

                                IsValid = False

                                ErrorText = "This category already exists for this employee/activity date."

                            End If

                        End If

                        'Verify the category is active
                        If IsValid = True Then

                            UsedOnBoardsCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM TIME_CATEGORY WHERE CATEGORY = '{0}' AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL);", PropertyValue)).SingleOrDefault

                            If UsedOnBoardsCount = 0 Then

                                IsValid = False

                                ErrorText = "This category is inactive. Please activate this category or select a different category."

                            End If

                        End If

                    ElseIf PropertyValue IsNot Nothing AndAlso Me.ActivityStart.HasValue AndAlso (Me.Status = 2) Then

                            ShortDate = Me.ActivityStart.Value.ToShortDateString

                        EmployeeTime = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                                        Where Entity.EmployeeCode = Me.EmployeeCode AndAlso
                                              Entity.Date = ShortDate
                                        Select Entity).SingleOrDefault

                        If EmployeeTime Is Nothing Then

                            IsValid = False

                            ErrorText = "This category does not exist for this employee/activity date."

                        ElseIf EmployeeTime IsNot Nothing Then

                            If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.LoadByID(DbContext, EmployeeTime.ID)
                                Where Entity.Category = DirectCast(PropertyValue, String)
                                Select Entity).Any = False Then

                                IsValid = False

                                ErrorText = "This category does not exist for this employee/activity date."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.ActivityStart.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing Then

                        ShortDate = DirectCast(PropertyValue, Date).ToShortDateString

                        If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                            Where Entity.EmployeeCode = Me.EmployeeCode AndAlso
                                  Entity.Date = ShortDate AndAlso
                                  Entity.IsApproved = 1).Any Then

                            IsValid = False

                            ErrorText = "Cannot save to supervisor approved timesheet."

                        End If

                        UsedOnBoardsCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM POSTPERIOD WHERE ('{0}' BETWEEN PPSRTDATE AND PPENDDATE) AND (PPTECURMTH IS NULL OR PPTECURMTH = 'C');", ShortDate)).SingleOrDefault

                        If UsedOnBoardsCount = 0 Then

                            IsValid = False

                            ErrorText = "The Posting Period is closed for this date."

                        End If

                    End If

                Case AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Duration.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso (DirectCast(PropertyValue, Decimal) < 0 OrElse DirectCast(PropertyValue, Decimal) > 8) Then

                        IsValid = False

                        ErrorText = "Duration must be between 0 and 8."

                    End If

                Case AdvantageFramework.Importing.Classes.ImportPTOItem.Properties.Status.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso DirectCast(PropertyValue, Short) <> 1 AndAlso DirectCast(PropertyValue, Short) <> 2 Then

                        IsValid = False

                        ErrorText = "Status is not valid."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
