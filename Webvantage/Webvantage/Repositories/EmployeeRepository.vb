Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System.Data.SqlClient

Namespace Repositories
    Public Class EmployeeRepository
        Implements Interfaces.IEmployeeRepository


#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "
        Private _Session As AdvantageFramework.Security.Session = Nothing
#End Region

#Region " Properties "

#End Region

#Region " Methods "
        Public Sub New()

        End Sub

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)
            _Session = Session
        End Sub

        Public Function GetDefaultEmployeeFunction(EmployeeCode As String) As String Implements Interfaces.IEmployeeRepository.GetDefaultEmployeeFunction

            Dim EmployeeFunction As String = Nothing
            EmployeeFunction = ""

            Using SQLConnection As New SqlConnection(_Session.ConnectionString)
                Using SQLCommand As New SqlCommand
                    With SQLCommand
                        .Connection = SQLConnection
                        .Connection.Open()
                        .CommandText = "usp_wv_ts_get_default_function"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@EmpCode", EmployeeCode))
                        .Parameters.Add(New SqlParameter("@Function", SqlDbType.VarChar, 100))
                    End With

                    SQLCommand.Parameters(1).Direction = ParameterDirection.Output

                    SQLCommand.ExecuteNonQuery()

                    EmployeeFunction = SQLCommand.Parameters(1).Value.ToString()
                End Using
            End Using

            GetDefaultEmployeeFunction = EmployeeFunction
        End Function

        Public Function SearchFunctionCategories(searchCriteria As ViewModels.LookupObjects.FunctionCategory) As List(Of FunctionCategorySearchResult) Implements Interfaces.IEmployeeRepository.SearchFunctionCategories

            Dim Results As New List(Of FunctionCategorySearchResult)
            Dim ParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim ParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim ParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumber As Integer = 0

            Using SQLConnection As New SqlConnection(_Session.ConnectionString)
                If (String.IsNullOrEmpty(searchCriteria.JobCode) = False) Then

                    ParameterEmployeeCode = New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6) With {.Value = searchCriteria.EmployeeCode}

                    Try

                        If String.IsNullOrWhiteSpace(searchCriteria.JobCode) = False AndAlso IsNumeric(searchCriteria.JobCode) Then

                            JobNumber = CType(searchCriteria.JobCode, Integer)

                        End If

                    Catch ex As Exception
                        JobNumber = 0
                    End Try

                    If JobNumber = 0 Then

                        ParameterJobNumber = New SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = 0}

                    Else

                        ParameterJobNumber = New SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber}

                    End If

                    ParameterClientCode = New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6) With {.Value = System.DBNull.Value}

                    Using SQLCommand As New SqlCommand
                        With SQLCommand
                            .Connection = SQLConnection
                            .Connection.Open()
                            .CommandText = "usp_wv_dd_GetFunctions_ByEmpCode"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(ParameterEmployeeCode)
                            .Parameters.Add(ParameterJobNumber)
                            .Parameters.Add(ParameterClientCode)
                        End With

                        Using Reader As SqlDataReader = SQLCommand.ExecuteReader()
                            While Reader.Read()
                                Results.Add(New FunctionCategorySearchResult() With {.Code = Reader("Code"), .Description = Reader("DescriptionOnly")})
                            End While
                        End Using
                    End Using
                Else
                    Using SQLCommand As New SqlCommand
                        With SQLCommand
                            .Connection = SQLConnection
                            .Connection.Open()
                            .CommandText = "usp_wv_dd_GetCategories"
                            .CommandType = CommandType.StoredProcedure
                        End With

                        Using Reader As SqlDataReader = SQLCommand.ExecuteReader()
                            While Reader.Read()
                                Results.Add(New FunctionCategorySearchResult() With {.Code = Reader("Code"), .Description = Reader("DescriptionOnly")})
                            End While
                        End Using
                    End Using
                End If
            End Using

            If (String.IsNullOrEmpty(searchCriteria.SearchText) = False) Then
                Results = (From r In Results
                          Where r.Code.ToLower().Contains(searchCriteria.SearchText.ToLower()) _
                          Or r.Description.ToLower().Contains(searchCriteria.SearchText.ToLower())
                          Select r).ToList()
            End If

            SearchFunctionCategories = Results
        End Function

#End Region



    End Class
End Namespace

