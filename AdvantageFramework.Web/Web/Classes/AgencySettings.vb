Imports System.Data.SqlClient
Imports System.Data
Imports System.Web
Imports System.Configuration
Imports System.Web.UI
Imports System.IO
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports System.Globalization
Imports System.Web.SessionState

Namespace Web.AgencySettings

    <Serializable()> _
    Public Class Methods

#Region " Constants "



#End Region

#Region " Enum "

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Property _ConnString As String = ""
        Private Property _UserCode As String = ""
        Private Property _HttpContext As Object = Nothing

        Public Property SettingsDictionary As Dictionary(Of AdvantageFramework.Agency.Settings, String)

#End Region

#Region " Methods "

        Public Function GetMaxEmailSize() As Integer
            Dim i As String = ""

            i = Me.GetValue(AdvantageFramework.Agency.Settings.MAX_EMAIL_SIZE, "")

            If IsNumeric(i) = True Then

                Return CType(i, Integer)

            Else

                Return 0

            End If

        End Function

        Public Function GetValue(ByVal Setting As AdvantageFramework.Agency.Settings, Optional ByRef ErrorMessage As String = "") As String

            Dim Value As String = ""

            If _HttpContext Is Nothing Then

                Value = AdvantageFramework.Agency.GetValue(_ConnString, _UserCode, Setting)

            Else

                Value = Me.GetValueFromSession(Setting, ErrorMessage)

            End If

            Return Value

        End Function

        Private Function GetValueFromSession(ByVal Setting As AdvantageFramework.Agency.Settings, Optional ByRef ErrorMessage As String = "") As String
            Dim Value As String = ""

            Dim SessionKey As String = "AGY_SETTING_" & Setting.ToString

            If Not _HttpContext.Session(SessionKey) Is Nothing Then

                Value = _HttpContext.Session(SessionKey).ToString()

            Else

                Value = AdvantageFramework.Agency.GetValue(_ConnString, _UserCode, Setting)
                _HttpContext.Session(SessionKey) = Value

            End If

            Return Value

        End Function
        Private Function GetValueFromDatabase(ByVal SettingName As AdvantageFramework.Agency.Settings, Optional ByRef ErrorMessage As String = "") As String
            Try
                Dim Value As String = ""

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = "SELECT ISNULL(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF) AS AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) " & _
                                       "WHERE AGY_SETTINGS_CODE = @AGY_SETTINGS_CODE;"
                        .Connection = MyConn

                    End With

                    Dim pSettingCode As New SqlParameter("@AGY_SETTINGS_CODE", SqlDbType.VarChar, 20)
                    pSettingCode.Value = SettingName.ToString()

                    MyCommand.Parameters.Add(pSettingCode)

                    MyConn.Open()

                    Value = MyCommand.ExecuteScalar()

                End Using

                Return Value
                ErrorMessage = ""

            Catch ex As Exception

                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return ""

            End Try
        End Function
        Public Sub GetValuesFromDatabase(ByVal AgencySettingApp As AdvantageFramework.Agency.SettingApps)

            If String.IsNullOrWhiteSpace(Me._ConnString) = False Then

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT AGY_SETTINGS_CODE, ISNULL(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF) AS AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_APP = @AGY_SETTINGS_APP;"
                        .Connection = MyConn
                    End With

                    Dim pSettingApp As New SqlParameter("@AGY_SETTINGS_APP", SqlDbType.SmallInt)
                    pSettingApp.Value = CType(AgencySettingApp, Integer)

                    MyCommand.Parameters.Add(pSettingApp)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            Dim ThisKey As String = ""
                            Dim ThisValue As String = ""

                            If IsDBNull(Reader.GetValue(Reader.GetOrdinal("AGY_SETTINGS_CODE"))) = False Then

                                ThisKey = Reader.GetValue(Reader.GetOrdinal("AGY_SETTINGS_CODE")).ToString()

                            End If
                            If IsDBNull(Reader.GetValue(Reader.GetOrdinal("AGY_SETTINGS_VALUE"))) = False Then

                                ThisValue = Reader.GetValue(Reader.GetOrdinal("AGY_SETTINGS_VALUE")).ToString()

                            End If

                            If ThisKey <> "" Then

                                Dim ThisSetting As AdvantageFramework.Agency.Settings
                                ThisSetting = DirectCast([Enum].Parse(GetType(AdvantageFramework.Agency.Settings), ThisKey), AdvantageFramework.Agency.Settings)

                                SettingsDictionary.Add(ThisSetting, ThisValue)

                            End If

                        Loop

                    End If

                End Using

            End If

        End Sub

        Public Function UpdateValue(ByVal SettingName As AdvantageFramework.Agency.Settings, _
                                          ByVal [Value] As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @AGY_SETTINGS_VALUE WHERE AGY_SETTINGS_CODE = @AGY_SETTINGS_CODE;"
                        .Connection = MyConn
                    End With

                    Dim pSettingCode As New SqlParameter("@AGY_SETTINGS_CODE", SqlDbType.VarChar, 20)
                    pSettingCode.Value = SettingName.ToString()

                    Dim pSettingValue As New SqlParameter("@AGY_SETTINGS_VALUE", SqlDbType.Variant)
                    If [Value].Trim() = "" Then
                        pSettingValue.Value = System.DBNull.Value
                    Else
                        pSettingValue.Value = [Value].Trim()
                    End If

                    MyCommand.Parameters.Add(pSettingCode)
                    MyCommand.Parameters.Add(pSettingValue)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                End Using

                Try

                    If Not _HttpContext Is Nothing Then

                        _HttpContext.Session("AGY_SETTING_" & SettingName.ToString) = [Value].Trim()

                    End If

                Catch ex As Exception

                End Try

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Return False
            End Try
        End Function
        Public Function UpdateValues(Optional ByRef ErrorMessage As String = "") As Boolean

            If Not SettingsDictionary Is Nothing AndAlso SettingsDictionary.Count > 0 Then

                Using MyConn As New SqlConnection(Me._ConnString)

                    Dim MyCommand As New SqlCommand()

                    With MyCommand

                        .CommandType = CommandType.Text
                        .Connection = MyConn

                    End With


                    Dim SQL As New System.Text.StringBuilder
                    Dim i As Integer = 0
                    Dim HasValue As Boolean = False
                    Dim ThisKey As String = ""
                    Dim ThisValue As String = ""

                    For Each item As KeyValuePair(Of AdvantageFramework.Agency.Settings, String) In SettingsDictionary

                        Dim pKey As New SqlParameter("@KEY_" & i, SqlDbType.VarChar, 20)
                        Dim pValue As New SqlParameter("@VALUE_" & i, SqlDbType.Variant)

                        ThisKey = item.Key.ToString()
                        ThisValue = item.Value.Trim()

                        If ThisValue.ToLower() = "true" Then
                            ThisValue = "1"
                        End If
                        If ThisValue.ToLower() = "false" Then
                            ThisValue = "0"
                        End If

                        pKey.Value = ThisKey

                        If ThisValue = "" Then
                            pValue.Value = System.DBNull.Value
                        Else
                            pValue.Value = ThisValue
                        End If

                        MyCommand.Parameters.Add(pKey)
                        MyCommand.Parameters.Add(pValue)

                        SQL.Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = ")
                        SQL.Append(pValue.ParameterName)
                        SQL.Append(" WHERE AGY_SETTINGS_CODE = ")
                        SQL.Append(pKey.ParameterName)
                        SQL.Append(";")

                        i += 1
                        HasValue = True
                        ThisKey = ""
                        ThisValue = ""
                        pKey = Nothing
                        pValue = Nothing

                        Try

                            If Not _HttpContext Is Nothing Then

                                _HttpContext.Session("AGY_SETTING_" & ThisKey) = ThisValue

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                    If HasValue = True Then

                        MyCommand.CommandText = SQL.ToString()
                        MyConn.Open()
                        MyCommand.ExecuteNonQuery()

                        If MyConn.State = ConnectionState.Open Then MyConn.Close()

                    End If

                End Using

            End If

            ErrorMessage = ""
            Return True

        End Function

        Public Function RestoreToDefault(Optional ByRef ErrorMessage As String = "") As Boolean

            If Not SettingsDictionary Is Nothing AndAlso SettingsDictionary.Count > 0 Then

                Dim SQL As New System.Text.StringBuilder
                Dim i As Integer = 0
                Dim HasValue As Boolean = False
                Dim ThisKey As String = ""
                Dim ThisValue As String = ""

                For Each item As KeyValuePair(Of AdvantageFramework.Agency.Settings, String) In SettingsDictionary

                    'Dim pKey As New SqlParameter
                    'pKey.ParameterName = "pKey" & i
                    'pKey.SqlDbType = SqlDbType.VarChar

                    ThisKey = item.Key.ToString()

                    SQL.Append("UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = AGY_SETTINGS_DEF")
                    SQL.Append(" WHERE AGY_SETTINGS_CODE = '")
                    SQL.Append(ThisKey)
                    SQL.Append("';")

                    i += 1
                    HasValue = True
                    ThisKey = ""
                    ThisValue = ""

                Next

                If HasValue = True Then

                    Dim s As String = SQL.ToString()

                End If

            End If

            ErrorMessage = ""
            Return True

        End Function

        Public Sub New(ByVal ConnectionString As String, ByVal UserCode As String, Optional ByVal HttpContext As Object = Nothing)

            _ConnString = ConnectionString
            _UserCode = UserCode
            _HttpContext = HttpContext

            SettingsDictionary = New Dictionary(Of AdvantageFramework.Agency.Settings, String)

        End Sub

#End Region

    End Class

End Namespace
