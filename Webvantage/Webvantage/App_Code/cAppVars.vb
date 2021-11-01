Imports System.Data
Imports System.Data.SqlClient

<Serializable()> Public Class cAppVars
#Region " Constants "



#End Region

#Region " Enum "

    Public Enum [Application]

        ALERT_INBOX
        ALERT_VIEW
        SCHEDULE_PRINT
        CALENDAR
        GRID_PAGE_SIZE
        PROJECTVIEWPOINT
        GRID_SETTINGS
        BILLING_APPROVAL
        BILL_APPR_BATCH_VIEW
        BILL_APPR_APPR_VIEW
        CALENDAR_NEW_ACTIVITY
        CAMPAIGN_PRINT
        CREATIVEBRIEF_PRINT
        MY_SETTINGS
        JOB_ALERTS_DOCS
        MY_ALERT_DTO
        MY_QVA_DTO
        ALL_QVA_DTO
        JOB_INBOX
        QVA
        JOBSPECS
        JOBSPECS_PRINT
        JOBVERSIONS
        JOBVERSIONS_PRINT
        MEDIAORDER_LIST
        TIMESHEET
        RISK_ANAL_GRAPH
        RISK_ANAL_SUM
        SCHED_BY_DAY_RPT
        TASK_ROLE_RPT
        TASK_RPT
        MY_SETTINGS_CP
        ALERT_ASSIGNMENT_MAINT
        MY_TASK_LIST_RPT
        TASK_LIST_RPT
        PROJECT_SCHEDULE
        PROJECT_HRS_RPT
        PROJECT_SUM_RPT
        SUPR_APPR_EXP
        SUPR_APPR_TS
        CONTENT_PAGE
        JOB_FORECAST
        EXPENSE_REPORT
        DFLT_WRKSPCE
        ALERT_ASSIGNMENT_CARDS
        ALERT_CARDS
        ASSIGNMENT_CARDS
        TASK_CARDS
        CALENDAR_MEDIA
        PMD_CALENDAR
        REVIEW_CARDS
        DOC_THUMBNAILS
        CARD_SETTINGS
        REPORT_MEDIACOMPCLIENTTYPE
        ESTIMATE_QUOTE
        AR_STATEMENTS

    End Enum

#End Region

#Region " Variables "

    Private mConnString As String = ""
    Private mUserID As String = ""
    Private mEmpCode As String = ""
    Private mApplication As String = ""
    Private mGroup As String = ""
    Private oAppVars As New AppVarCollection
    Private oSql As SqlHelper

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Function getAllAppVars() As String
        If HttpContext.Current.Session("AppVarCollection" & mApplication) Is Nothing Then
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim dr As SqlDataReader
            Dim oAppVar As AppVar

            With SbSQL
                .Append("SELECT VARIABLE_NAME, ISNULL(VARIABLE_VALUE,'') FROM APP_VARS WHERE USERID = '")
                .Append(mUserID)
                .Append("' AND APPLICATION = '")
                .Append(mApplication)
                .Append("';")
            End With

            StrSQL = SbSQL.ToString()

            Try
                dr = oSql.ExecuteReader(mConnString, CommandType.Text, StrSQL)
            Catch
                Err.Raise(Err.Number, "Class:cAppVars.vb Routine:getAllAppVars", Err.Description)
            Finally
            End Try

            Do While dr.Read
                oAppVar = New AppVar
                oAppVar.Name = dr.GetString(0)
                oAppVar.Value = dr.GetString(1)
                oAppVars.Add(oAppVar)
            Loop
            dr.Close()

            HttpContext.Current.Session("AppVarCollection" & mApplication) = oAppVars

        Else
            oAppVars = CType(HttpContext.Current.Session("AppVarCollection" & mApplication), AppVarCollection)
        End If
    End Function
    Public Function getAppVar(ByVal VariableName As String, Optional ByVal VarType As String = "", Optional ByVal defaultValue As String = "") As String
        Dim value As String = ""
        Dim idx As Integer

        If oAppVars.Count > 0 Then
            For idx = 0 To oAppVars.Count - 1
                If oAppVars.Item(idx).Name = VariableName Then
                    value = oAppVars.Item(idx).Value
                    VarType = oAppVars.Item(idx).Type
                    Exit For
                End If
            Next
        End If

        Try
            If value = "" Then
                If defaultValue = "" Then
                    Select Case VarType
                        Case "Boolean", "System.Boolean"

                            value = "False"

                        Case "Number"

                            value = "0"

                        Case "Date"

                            value = Nothing

                        Case Else
                            value = ""
                    End Select

                Else
                    value = defaultValue
                End If

            End If

            Return value

        Catch
            Err.Raise(Err.Number, "Class:cAppVars.vb Routine:getAppVarDB", Err.Description)
        Finally
        End Try

        'If Type = "System.Boolean" Or Type = "Boolean" Then
        '    If value = "" Then
        '        value = "False"
        '    End If
        'End If

        'If Type = "Number" Then
        '    If value = "" Then
        '        value = "0"
        '    End If
        'End If

        'If Type = "Date" Then
        '    If value = "" Then
        '        value = "1/1/1900"
        '    End If
        'End If

        Return value

    End Function

    Public Function AddAppVar(ByVal VariableName As String, ByVal varValue As String, Optional ByVal varType As String = "")
        Dim oAppVar As AppVar

        oAppVar = New AppVar
        oAppVar.Name = VariableName
        oAppVar.Value = varValue
        oAppVar.Type = varType
        oAppVars.Add(oAppVar)

    End Function

    Public Function setAppVar(ByVal VariableName As String, ByVal varValue As String, Optional ByVal varType As String = "")
        Dim value As String = ""
        Dim name As String
        Dim idx As Integer
        Dim found As Boolean = False
        Dim oappVar As New AppVar

        If oAppVars.Count > 0 Then
            For idx = 0 To oAppVars.Count - 1
                If oAppVars.Item(idx).Name = VariableName Then
                    oappVar.Name = VariableName
                    oappVar.Value = varValue
                    oappVar.Type = varType

                    oAppVars.Item(idx) = oappVar
                    found = True
                End If
            Next
        End If

        If found = False Then
            AddAppVar(VariableName, varValue, varType)
        End If

    End Function

    Public Function SaveAllAppVars()

        Dim SbSQL As New System.Text.StringBuilder
        Dim StrSQL As String = ""
        Dim sName, sValue, sType As String
        Dim idx As Integer

        Try
            ' clear out existing data first:
            With SbSQL
                .Append("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '")
                .Append(mUserID)
                .Append("' AND APPLICATION = '")
                .Append(mApplication)
                .Append("';")
            End With

            'Save:
            Using MyConn As New SqlConnection(mConnString)

                MyConn.Open()

                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction

                If oAppVars.Count > 0 Then

                    For idx = 0 To oAppVars.Count - 1

                        sName = oAppVars.Item(idx).Name
                        sValue = oAppVars.Item(idx).Value
                        sType = oAppVars.Item(idx).Type

                        With SbSQL

                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES ('")
                            .Append(mUserID)
                            .Append("','")
                            .Append(mApplication)
                            .Append("','0','")
                            .Append(sName)
                            .Append("','")
                            .Append(sType)
                            .Append("',@VARIABLE_VALUE")
                            .Append(idx.ToString())
                            .Append(");")

                        End With

                    Next

                End If

                StrSQL = SbSQL.ToString()

                Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)

                If oAppVars.Count > 0 Then

                    For idx = 0 To oAppVars.Count - 1

                        sName = oAppVars.Item(idx).Name
                        sValue = oAppVars.Item(idx).Value
                        sType = oAppVars.Item(idx).Type
                        Dim P As New SqlParameter("@VARIABLE_VALUE" & idx.ToString(), SqlDbType.VarChar)
                        P.Value = sValue
                        MyCmd.Parameters.Add(P)

                    Next

                End If


                If StrSQL.Trim() <> "" Then

                    Try

                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                        HttpContext.Current.Session("AppVarCollection" & mApplication) = Nothing

                    Catch ex As Exception

                        MyTrans.Rollback()
                        Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()

                    Finally

                        If MyConn.State = ConnectionState.Open Then MyConn.Close()

                    End Try

                End If
            End Using
        Catch ex As Exception
            Return "Error saving variables to database: &nbsp;&nbsp;" & ex.Message.ToString()
        End Try

    End Function

    Public Function getAppVarDB(ByVal VariableName As String, Optional ByVal vartype As String = "", Optional ByVal defaultValue As String = "") As String
        Dim VariableValue As String = ""
        Dim SessionKey As String = "getAppVarDB" & mApplication & VariableName & vartype

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim dr As SqlDataReader

            With SbSQL
                .Append("SELECT ISNULL(VARIABLE_VALUE,'') FROM APP_VARS WHERE USERID = '")
                .Append(mUserID)
                .Append("' AND APPLICATION = '")
                .Append(mApplication)
                .Append("' AND VARIABLE_NAME = '")
                .Append(VariableName)
                .Append("';")
            End With

            StrSQL = SbSQL.ToString()

            Try
                dr = oSql.ExecuteReader(mConnString, CommandType.Text, StrSQL)
                If dr.HasRows Then
                    dr.Read()
                    VariableValue = dr.GetString(0)
                Else
                    If defaultValue = "" Then
                        Select Case vartype
                            Case "Boolean", "System.Boolean"
                                VariableValue = "False"
                            Case "Number"
                                VariableValue = "0"
                            Case "Date"
                                VariableValue = Nothing
                            Case Else
                                VariableValue = ""
                        End Select
                    Else
                        VariableValue = defaultValue
                    End If
                End If
            Catch
                Err.Raise(Err.Number, "Class:cAppVars.vb Routine:getAppVarDB", Err.Description)
            Finally
            End Try
            HttpContext.Current.Session(SessionKey) = VariableValue
        Else
            VariableValue = HttpContext.Current.Session(SessionKey)
        End If

        Return VariableValue

    End Function
    Public Function setAppVarDB(ByVal VariableName As String, ByVal VariableValue As String, Optional ByVal varType As String = "") As String
        Dim SessionKey As String = "getAppVarDB" & mApplication & VariableName & varType
        Try
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""

            ' clear out existing data first:
            With SbSQL
                .Append("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '")
                .Append(mUserID)
                .Append("' AND APPLICATION = '")
                .Append(mApplication)
                .Append("' AND VARIABLE_NAME = '")
                .Append(VariableName)
                .Append("';")
            End With

            With SbSQL
                .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES ('")
                .Append(mUserID)
                .Append("','")
                .Append(mApplication)
                .Append("','0','")
                .Append(VariableName)
                .Append("','")
                .Append(varType)
                .Append("','")
                .Append(VariableValue)
                .Append("');")
            End With

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(mConnString)
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                        HttpContext.Current.Session(SessionKey) = Nothing
                        HttpContext.Current.Session("AppVarCollection" & mApplication) = Nothing
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Return ""

        Catch ex As Exception
            Return "Error saving " & VariableName & ":&nbsp;&nbsp;" & ex.Message.ToString()
        End Try
    End Function

    Public Function HasAppVar(ByVal VariableName As String) As Boolean

        Dim found As Boolean = False
        Dim idx As Integer

        If oAppVars.Count > 0 Then
            For idx = 0 To oAppVars.Count - 1
                If oAppVars.Item(idx).Name = VariableName Then
                    found = True
                    Exit For
                End If
            Next
        End If

        Return found

    End Function

    Public Function HasAppVars() As Boolean

        Dim found As Boolean = False
        Dim idx As Integer

        If oAppVars.Count > 0 Then
            found = True
        End If

        Return found

    End Function

    Public Sub Clear()

        HttpContext.Current.Session("AppVarCollection" & mApplication) = Nothing

    End Sub

    Public Sub New(ByVal App As cAppVars.Application, Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")

        mApplication = App.ToString()
        mConnString = HttpContext.Current.Session("ConnString")

        Try
            If UserID <> "" Then
                mUserID = UserID
            Else
                mUserID = HttpContext.Current.Session("UserCode")
            End If
        Catch ex As Exception
            mUserID = ""
        End Try
        Try
            If EmpCode <> "" Then
                mEmpCode = EmpCode
            Else
                mEmpCode = HttpContext.Current.Session("EmpCode")
            End If
        Catch ex As Exception
            mEmpCode = ""
        End Try

    End Sub

#End Region

    <Serializable()> Public Class AppVar

        Private mName As String
        Private mValue As String
        Private mGroup As String
        Private mType As String
        Private mOrder As Integer

        Public Property Name() As String
            Get
                Return mName
            End Get
            Set(ByVal Value As String)
                mName = Value
            End Set
        End Property
        Public Property Value() As String
            Get
                Return mValue
            End Get
            Set(ByVal Value As String)
                mValue = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Return mType
            End Get
            Set(ByVal Type As String)
                mType = Type
            End Set
        End Property
        Public Property Order() As String
            Get
                Return mOrder
            End Get
            Set(ByVal Order As String)
                mOrder = Order
            End Set
        End Property

    End Class
    <Serializable()> Public Class AppVarCollection
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As AppVar
            Get
                Return CType(List(index), AppVar)
            End Get
            Set(ByVal Value As AppVar)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As AppVar) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As AppVar) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As AppVar)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As AppVar)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As AppVar) As Boolean
            Return List.Contains(value)
        End Function

        Public Sub New()
        End Sub

    End Class

End Class






