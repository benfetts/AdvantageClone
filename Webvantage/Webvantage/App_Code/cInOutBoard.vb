Imports System.Data
Imports System.Data.SqlClient
Public Class cInOutBoard
        Dim oSQL As Webvantage.SqlHelper

#Region "Constructors"
        Public Sub New(ByVal ConnectionString As String)
            _ConnectionString = ConnectionString.Trim
        End Sub
#End Region

#Region "Properties"
    Public Property InOut_RefID() As Integer
        Get
            Return Me._InOut_Ref
        End Get
        Set(ByVal value As Integer)
            Me._InOut_Ref = value
        End Set
    End Property
    Public Property InOut_Status() As Int16
        Get
            Return Me._InOut_Status
        End Get
        Set(ByVal value As Int16)
            Me._InOut_Status = value
        End Set
    End Property
    Public Property InOut_DateTime() As DateTime
        Get
            Return Me._InOut_DateTime
        End Get
        Set(ByVal value As DateTime)
            Me._InOut_DateTime = value
        End Set
    End Property
    Public Property InOut_DateStr() As String
        Get
            Return Me._InOut_DateStr.Trim
        End Get
        Set(ByVal value As String)
            Me._InOut_DateStr = value.Trim
        End Set
    End Property
    Public Property InOut_TimeStr() As String
        Get
            Return Me._InOut_TimeStr
        End Get
        Set(ByVal value As String)
            Me._InOut_TimeStr = value.Trim
        End Set
    End Property
    Public ReadOnly Property InOut_Description() As String
        Get
            Return Me._InOut_Description.Trim
        End Get
    End Property
    Public ReadOnly Property InOut_Full_Description() As String
        Get
            Return Me._InOut_Full_Description.Trim
        End Get
    End Property

#End Region

#Region "Private Class Variables"

    Private _ConnectionString As String
    Private _InOut_Ref As Int32

    Private _InOut_Status As Int16
    Private _InOut_DateTime As DateTime
    Private _InOut_DateStr As String
    Private _InOut_TimeStr As String
    Private _InOut_Description As String
    Private _InOut_Full_Description As String


#End Region

#Region "Database Functions"
    'Public Function Insert_Status(ByVal EmpCode As String, ByVal NewStatus As Int16, ByVal InOutTime As DateTime, ByVal CategoryID As Int16, ByVal All_Day_Flg As Int16) As Integer
    Public Function Insert_Status(ByVal EmpCode As String, ByVal NewStatus As Int16, ByVal InOutTime As DateTime, ByVal Comment As String, ByVal ReturnDate As DateTime) As Integer
        Dim arParams(6) As SqlParameter

        Dim P0 As New SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4)
        P0.Value = 0
        P0.Direction = ParameterDirection.ReturnValue
        arParams(0) = P0

        Dim P1 As New SqlParameter("@empcode", SqlDbType.Char, 6)
        P1.Value = EmpCode.Trim
        arParams(1) = P1

        Dim P2 As New SqlParameter("@new_status", SqlDbType.Int, 2)
        P2.Value = NewStatus
        arParams(2) = P2

        Dim P3 As New SqlParameter("@inout_time", SqlDbType.DateTime)
        P3.IsNullable = True
        P3.Value = InOutTime
        arParams(3) = P3

        Dim P4 As New SqlParameter("@comment", SqlDbType.VarChar, 50)
        P4.IsNullable = True
        P4.Value = Comment
        arParams(4) = P4

        Dim P5 As New SqlParameter("@return", SqlDbType.DateTime)
        P5.IsNullable = True
        If NewStatus = 0 Then
            P5.Value = DBNull.Value
        Else
            P5.Value = ReturnDate.Date
        End If
        arParams(5) = P5

        'Dim P4 As New SqlParameter("@inout_category_id", SqlDbType.Int, 4)
        'P4.IsNullable = True
        'P4.Value = CategoryID
        'arParams(4) = P4

        'Dim P5 As New SqlParameter("@all_day_flg", SqlDbType.Int, 2)
        'P5.IsNullable = True
        'P5.Value = All_Day_Flg
        'arParams(5) = P5


        Try
            oSQL.ExecuteNonQuery(_ConnectionString, CommandType.StoredProcedure, "usp_wv_dto_insert_emp_status", arParams)
            '  Return 0
        Catch
            Err.Raise(Err.Number, "Class:cInOutBoard Routine:usp_wv_dto_insert_emp_status", Err.Description)
            ' Return 1
        End Try


    End Function

#End Region

End Class



