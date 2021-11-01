Namespace EmployeeUtilities.MyObjectsDefinition

#Region " Enum "

    Public Enum ObjectType

        FinanceAndAccounting = 1
        ProjectManagement = 2

    End Enum
    Public Enum Objects

        MyEmployeeTimeForecast = 1
        MyARCashForecast = 2
        MyClientAging = 3
        MyDirectExpenseAlert = 4
        ProjectViewpoint_MyProjects = 5
        MyProjects = 6
        MyQvA = 7
        AlertInbox_AllAssignments = 8
        'DynamicAlertGroup = 9

    End Enum
    Public Enum StaticDefinition

        AlertGroup = 1
        ScheduleAssignments = 2
        ScheduleManager = 3
        TaskAssignees = 4
        AccountExecutive = 5 'Can (and usually does) exist as a Management level in MGMT_LEVEL

    End Enum

#End Region

#Region " Objects "

    <Serializable()>
    Public Class [Object]

        Public Property Id As Integer = 0
        Public Property Description As String = ""
        Public Property [Type] As ObjectType

        Sub New()

        End Sub

    End Class
    <Serializable()>
    Public Class [Definition]

        Public Property Id As Integer = 0
        Public Property Description As String = ""
        Public Property IsStatic As Boolean = False

        Sub New()

        End Sub

    End Class
    <Serializable()>
    Public Class ObjectDefinition

        Public Property Id As Integer = 0
        Public Property [Object] As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Object
        Public Property [Definition] As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Definition
        Public Property Checked As Boolean = False

        Sub New()

            [Object] = New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Object
            [Definition] = New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Definition

        End Sub

    End Class

#End Region

#Region " Methods "

    <Serializable()>
    Public Class Methods

#Region " Constants "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""
        Private Property _HttpContext As Object = Nothing

#End Region

#Region " Methods "


        Public Function EmployeeHasDynamicRestriction(ByVal EmpCode As String, ByVal [Object] As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_MyObjectDef_EmployeeHasDynamicRestriction"
                        .Connection = MyConn
                    End With

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode

                    Dim pObjectId As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObjectId.Value = CType([Object], Integer)

                    MyCommand.Parameters.Add(pEmpCode)
                    MyCommand.Parameters.Add(pObjectId)

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar, Boolean)

                End Using

            Catch ex As Exception

                Return False

            End Try
        End Function
        Public Function LoadEmployeeDynamicRestrictionDatatable(ByVal [Object] As EmployeeUtilities.MyObjectsDefinition.Objects, ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As DataTable
            Try

                Dim MyDatatable As New DataTable

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM [dbo].[fn_my_objects_get_dynamic_restrictions](@OBJECT_ID, @EMP_CODE);"
                        .Connection = MyConn

                    End With

                    Dim pObjectId As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObjectId.Value = CType([Object], Integer)

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode

                    MyCommand.Parameters.Add(pObjectId)
                    MyCommand.Parameters.Add(pEmpCode)

                    Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCommand)

                    MyConn.Open()

                    MyAdapter.Fill(MyDatatable)

                End Using

                ErrorMessage = ""
                Return MyDatatable

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return Nothing

            End Try
        End Function

        Public Function ObjectHasStaticRestriction(ByVal [Object] As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT HAS_ACTIVE_RESTRICTION FROM [dbo].[fn_my_objects_get_static_restrictions] (@OBJECT_ID);"
                        .Connection = MyConn
                    End With

                    Dim pObject As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObject.Value = CType([Object], Integer)

                    MyCommand.Parameters.Add(pObject)

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar, Boolean)

                End Using

            Catch ex As Exception

                Return False

            End Try
        End Function
        Public Function ObjectHasAccountExecutiveRestriction(ByVal [Object] As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects) As Boolean
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT ACCOUNT_EXECUTIVE FROM [dbo].[fn_my_objects_get_static_restrictions] (@OBJECT_ID);"
                        .Connection = MyConn
                    End With

                    Dim pObject As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObject.Value = CType([Object], Integer)

                    MyCommand.Parameters.Add(pObject)

                    MyConn.Open()

                    Return CType(MyCommand.ExecuteScalar, Boolean)

                End Using

            Catch ex As Exception

                Return False

            End Try
        End Function
        Public Function LoadObjectStaticRestrictions(ByVal [Object] As EmployeeUtilities.MyObjectsDefinition.Objects,
                                                     Optional ByVal LoadAll As Boolean = False,
                                                     Optional ByRef ErrorMessage As String = "") As Generic.Dictionary(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition, Boolean)

            Dim dict As New Generic.Dictionary(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition, Boolean)

            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM [dbo].[fn_my_objects_get_static_restrictions] (@OBJECT_ID);"
                        .Connection = MyConn

                    End With

                    Dim pObject As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObject.Value = CType([Object], Integer)

                    MyCommand.Parameters.Add(pObject)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            If LoadAll = False Then

                                If CType(Reader.GetValue(Reader.GetOrdinal("ALERT_GROUP")), Boolean) = True Then

                                    dict.Add(StaticDefinition.AlertGroup, True)

                                End If
                                If CType(Reader.GetValue(Reader.GetOrdinal("SCHEDULE_ASSIGNMENTS")), Boolean) = True Then

                                    dict.Add(StaticDefinition.ScheduleAssignments, True)

                                End If
                                If CType(Reader.GetValue(Reader.GetOrdinal("SCHEDULE_MANAGER")), Boolean) = True Then

                                    dict.Add(StaticDefinition.ScheduleManager, True)

                                End If
                                If CType(Reader.GetValue(Reader.GetOrdinal("TASK_ASSIGNEES")), Boolean) = True Then

                                    dict.Add(StaticDefinition.TaskAssignees, True)

                                End If
                                If CType(Reader.GetValue(Reader.GetOrdinal("ACCOUNT_EXECUTIVE")), Boolean) = True Then

                                    dict.Add(StaticDefinition.AccountExecutive, True)

                                End If

                            Else

                                dict.Add(StaticDefinition.AlertGroup, CType(Reader.GetValue(Reader.GetOrdinal("ALERT_GROUP")), Boolean))
                                dict.Add(StaticDefinition.ScheduleAssignments, CType(Reader.GetValue(Reader.GetOrdinal("SCHEDULE_ASSIGNMENTS")), Boolean))
                                dict.Add(StaticDefinition.ScheduleManager, CType(Reader.GetValue(Reader.GetOrdinal("SCHEDULE_MANAGER")), Boolean))
                                dict.Add(StaticDefinition.TaskAssignees, CType(Reader.GetValue(Reader.GetOrdinal("TASK_ASSIGNEES")), Boolean))
                                dict.Add(StaticDefinition.AccountExecutive, CType(Reader.GetValue(Reader.GetOrdinal("ACCOUNT_EXECUTIVE")), Boolean))

                            End If

                        Loop

                    End If

                End Using


            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                'Return Nothing

            End Try

            Return dict

        End Function

        Public Function LoadObjects(ByVal Type As ObjectType, Optional ByRef ErrorMessage As String = "") As Generic.List(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Object)
            Try

                Dim list As New Generic.List(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Object)

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = "SELECT * FROM MY_OBJ_DEF_OBJECTS WITH(NOLOCK) WHERE [TYPE] = @TYPE AND (IS_INACTIVE = 0 OR IS_INACTIVE IS NULL);"
                        .Connection = MyConn

                    End With

                    Dim pType As New System.Data.SqlClient.SqlParameter("@TYPE", SqlDbType.Int)
                    pType.Value = CType(Type, Integer)

                    MyCommand.Parameters.Add(pType)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            Dim obj As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Object
                            With obj

                                .Id = Reader.GetInt32(Reader.GetOrdinal("ID"))
                                .Description = Reader.GetValue(Reader.GetOrdinal("DESCRIPTION"))
                                .Type = CType(Reader.GetInt32(Reader.GetOrdinal("TYPE")), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectType)

                            End With

                            list.Add(obj)
                            obj = Nothing

                        Loop

                    End If

                End Using

                ErrorMessage = ""
                Return list

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return Nothing

            End Try
        End Function
        Public Function LoadObjectDefinitions(ByVal ObjectId As Integer, ByVal ShowOnlyCheckedItems As Boolean,
                                              Optional ByRef ErrorMessage As String = "") As Generic.List(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectDefinition)

            Try

                Dim list As New Generic.List(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectDefinition)
                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_MyObjectDef_LoadObjectDefinitions"
                        .Connection = MyConn
                    End With

                    Dim pObjectId As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObjectId.Value = ObjectId

                    Dim pShowOnlyCheckedItems As New System.Data.SqlClient.SqlParameter("@SHOW_ONLY_CHECKED_DEFINITIONS", SqlDbType.Bit)
                    pShowOnlyCheckedItems.Value = ShowOnlyCheckedItems

                    MyCommand.Parameters.Add(pObjectId)
                    MyCommand.Parameters.Add(pShowOnlyCheckedItems)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            Dim od As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectDefinition
                            With od

                                .Id = Reader.GetInt32(Reader.GetOrdinal("ObjectDefinitionID"))

                                .Object.Id = Reader.GetInt32(Reader.GetOrdinal("ObjectID"))
                                .Object.Description = Reader.GetValue(Reader.GetOrdinal("ObjectDescription"))
                                .Object.Type = Reader.GetInt32(Reader.GetOrdinal("ObjectType"))

                                .Definition.Id = Reader.GetInt32(Reader.GetOrdinal("DefinitionID"))
                                .Definition.Description = Reader.GetValue(Reader.GetOrdinal("DefinitionDescription"))
                                .Definition.IsStatic = Reader.GetValue(Reader.GetOrdinal("IsStatic"))

                                .Checked = Reader.GetValue(Reader.GetOrdinal("Checked"))

                            End With

                            list.Add(od)
                            od = Nothing

                        Loop

                    End If

                End Using

                ErrorMessage = ""
                Return list

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return Nothing

            End Try
        End Function
        Public Overloads Function UpdateObjectDefinitionSetting(ByVal ObjDef As AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.ObjectDefinition,
                                                                Optional ByRef ErrorMessage As String = "") As Boolean

            Return Me.UpdateObjectDefinitionSetting(ObjDef.Id, ObjDef.Object.Id, ObjDef.Definition.Id,
                                                    ObjDef.Definition.IsStatic, ObjDef.Checked, ErrorMessage)


        End Function
        Public Overloads Function UpdateObjectDefinitionSetting(ByVal ObjectDefinitionsSettingsId As Integer, ByVal ObjectId As Integer, ByVal DefinitionId As Integer,
                                                      ByVal IsStatic As Boolean, ByVal Checked As Boolean, Optional ByRef ErrorMessage As String = "") As Boolean

            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_MyObjectDef_UpdateObjectDefinitionSetting"
                        .Connection = MyConn
                    End With

                    Dim pObjectDefinitionsSettingsId As New System.Data.SqlClient.SqlParameter("@OBJ_DEF_SETTINGS_ID", SqlDbType.Int)
                    pObjectDefinitionsSettingsId.Value = ObjectDefinitionsSettingsId
                    MyCommand.Parameters.Add(pObjectDefinitionsSettingsId)

                    Dim pObjectId As New System.Data.SqlClient.SqlParameter("@OBJECT_ID", SqlDbType.Int)
                    pObjectId.Value = ObjectId
                    MyCommand.Parameters.Add(pObjectId)

                    Dim pDefinitionId As New System.Data.SqlClient.SqlParameter("@DEFINITION_ID", SqlDbType.Int)
                    pDefinitionId.Value = DefinitionId
                    MyCommand.Parameters.Add(pDefinitionId)

                    Dim pIsStatic As New System.Data.SqlClient.SqlParameter("@IS_STATIC", SqlDbType.Bit)
                    pIsStatic.Value = IsStatic
                    MyCommand.Parameters.Add(pIsStatic)

                    Dim pChecked As New System.Data.SqlClient.SqlParameter("@CHECKED", SqlDbType.Bit)
                    pChecked.Value = Checked
                    MyCommand.Parameters.Add(pChecked)

                    MyConn.Open()

                    MyCommand.ExecuteScalar()

                End Using

                ErrorMessage = ""
                Return True

            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try

        End Function

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String, Optional ByVal HttpContext As Object = Nothing)

            _ConnectionString = ConnectionString
            _UserCode = UserCode
            _HttpContext = HttpContext

        End Sub

#End Region

    End Class

#End Region

End Namespace
