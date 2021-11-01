Imports System.ComponentModel
Imports System.IO
Imports System.Reflection

Public Class dbInstaller

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Installer overrides dispose to clean up the component list.
    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

    Public Function GetSql(ByVal Name As String) As String
        Try

            ' Gets the current assembly.
            ' Dim Asm As [Assembly] = [Assembly].GetExecutingAssembly()

            ' Resources are named using a fully qualified name.
            'Dim strm As Stream = Asm.GetManifestResourceStream(Asm.GetName().Name & "." & Name)
            'Dim strm As Stream = Asm.GetManifestResourceStream(Name)

            ' Reads the contents of the embedded file.
            Dim reader As StreamReader = New StreamReader(Name)
            Return reader.ReadToEnd()
        Catch ex As Exception
            MsgBox("In GetSQL: " & ex.Message)
            Throw ex
        End Try

    End Function
    Public Sub ExecuteSql(ByVal strServer As String, ByVal DatabaseName As String, ByVal UserID As String, ByVal Password As String, ByVal Sql As String, ByVal blnNT As Boolean)
        Dim ConnString As String
        If blnNT Then
            ConnString = "integrated security=SSPI;data source=" & strServer & ";persist security info=False;initial catalog=" & DatabaseName
        Else
            ConnString = "Persist Security Info=False;Data Source=" & strServer
            ConnString &= ";Initial Catalog=" & DatabaseName
            ConnString &= ";User ID=" & UserID & ";Password=" & Password
        End If
        'ConnString = "integrated security=SSPI;data source=" & strServer & ";persist security info=False;initial catalog=" & DatabaseName
        'ConnString = "Persist Security Info=False;Data Source=" & strServer
        'ConnString &= ";Initial Catalog=" & DatabaseName
        'ConnString &= ";User ID=" & UserID & ";Password=" & Password

        Dim SQLConn As New SqlClient.SqlConnection(ConnString)
        Dim Command As New SqlClient.SqlCommand(Sql, SQLConn)

        Command.Connection.Open()
        Command.Connection.ChangeDatabase(DatabaseName)
        Try
            Command.ExecuteNonQuery()
        Finally
            ' Finally, blocks are a great way to ensure that the connection 
            ' is always closed.
            Command.Connection.Close()
        End Try
    End Sub
    Public Sub UpdateDB(ByVal strServer As String, ByVal strDBName As String, ByVal UserID As String, ByVal Password As String)
        Try
            ExecuteSQLScript(strServer, strDBName, UserID, Password, GetSql("sql.txt"), True)
        Catch ex As Exception
            ' Reports any errors and abort.
            MsgBox("In exception handler: " & ex.Message)
            Throw ex
        End Try
    End Sub

    Public Sub ExecuteSQLScript(ByVal strServer As String, ByVal DatabaseName As String, ByVal UserID As String, ByVal Password As String, ByVal Sql As String, ByVal blnNT As Boolean)
        Dim MySQLBatch As New System.IO.StringWriter
        Dim MySQLScriptLine As String
        Dim MySQLScript As New System.IO.StringReader(GetSql(Sql))
        Try
            Do While MySQLScript.Peek > -1
                MySQLScriptLine = MySQLScript.ReadLine
                If MySQLScriptLine.Compare(MySQLScriptLine.Trim, "GO", True) = 0 Then
                    ExecuteSQLBatch(strServer, DatabaseName, UserID, Password, MySQLBatch.ToString, blnNT)
                    MySQLBatch.Close()
                    MySQLBatch = New System.IO.StringWriter
                Else
                    MySQLBatch.WriteLine(MySQLScriptLine)
                End If
            Loop

            ExecuteSQLBatch(strServer, DatabaseName, UserID, Password, MySQLBatch.ToString, blnNT)
        Catch
            MsgBox(Err.Number & " " & Err.Description)
        End Try

    End Sub
    Public Sub ExecuteSQLBatch(ByVal strServer As String, ByVal DatabaseName As String, ByVal UserID As String, ByVal Password As String, ByVal MySQLBatch As String, ByVal blnNT As Boolean)
        If MySQLBatch.Compare(MySQLBatch.Trim, "", True) Then
            ExecuteSql(strServer, DatabaseName, UserID, Password, MySQLBatch, blnNT)
        End If
    End Sub


    ' Execute an array of sql script files with batch statements,
    '  by using the OSQL utility
    '   - dbName is the name of the destination database
    '   - isWinAuth, login and pwd specify whether to use the integrated Windows 
    ' authentication, or the SQL Server's login-password otherwise
    '
    ' Example:
    '   Dim script1 As String = "C:\Scripts\CreateDbTables.sql"
    '   Dim script2 As String = "C:\Scripts\CreateDbSprocs.sql"
    '   Dim script3 As String = "C:\Scripts\InsertData.sql"
    '   ' use Windows integrated security
    '   ExecuteSqlScriptsWithOsql("TestDB", True, "", "", script1, script2, script3) 
    '   ' use SQL Server's security 
    '   ExecuteSqlScriptsWithOsql("TestDB", False, "loginname", "pwd", script1, 
    '  script2, script3)

    Sub ExecuteSqlScriptsWithOsql(ByVal dbName As String, _
        ByVal isWinAuth As Boolean, ByVal login As String, ByVal pwd As String, _
        ByVal ParamArray scriptFiles() As String)
        Dim osqlParams As String = ""
        ' the OSQL utility requires different parameters if using the Win or SQL 
        ' server security
        If (isWinAuth) Then
            osqlParams = String.Format("-E -d {0} -i ", dbName)
        Else
            osqlParams = String.Format("-U {0} -P {1} -d {2} -i ", login, pwd, _
                dbName)
        End If
        ' execute each script file in the scripts array
        Dim proc As New Process
        proc.StartInfo.FileName = "osql.exe"
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Dim scriptFile As String
        For Each scriptFile In scriptFiles
            proc.StartInfo.Arguments = osqlParams & """" & scriptFile & """"
            proc.Start()
            ' wait until the scrip execution ends
            proc.WaitForExit()
        Next
    End Sub

End Class
