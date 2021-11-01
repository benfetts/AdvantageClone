Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Text
Imports System.Web
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

<Serializable()> Public Class cMaintenanceApps
    Private mConnString As String
    Private mUserID As String
    Private mEmpCode As String
    Private oSQL As SqlHelper

    Public Sub New(Optional ByVal UserID As String = "", Optional ByVal EmpCode As String = "")
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

#Region " Ad Number "

    Public Function AdNumber_Detail_Get(ByVal AdNumber As String) As DataTable
        Try
            Dim arParams(1) As SqlParameter
            Dim pAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
            pAD_NBR.Value = AdNumber
            arParams(0) = pAD_NBR
            Return oSQL.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_AD_NUMBER_GET_DETAILS", "DtAdNumberDetails", arParams)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AdNumber_Detail_Update(ByVal AdNbr As String, ByVal AdNbrDesc As String, ByVal IsActive As Boolean, _
                                           ByVal DefBlkpltVerCode As String, ByVal DefBlkpltVer2Code As String, _
                                           ByVal ClCode As String, ByVal ColorHex As String) As String
        Dim arParams(7) As SqlParameter

        Dim pAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
        pAD_NBR.Value = AdNbr
        arParams(0) = pAD_NBR

        Dim pAD_NBR_DESC As New SqlParameter("@AD_NBR_DESC", SqlDbType.VarChar, 60)
        pAD_NBR_DESC.Value = AdNbrDesc
        arParams(1) = pAD_NBR_DESC

        Dim pACTIVE As New SqlParameter("@ACTIVE", SqlDbType.SmallInt)
        If IsActive = True Then
            pACTIVE.Value = 0
        Else
            pACTIVE.Value = 1
        End If
        arParams(2) = pACTIVE

        Dim pDEF_BLKPLT_VER_CODE As New SqlParameter("@DEF_BLKPLT_VER_CODE", SqlDbType.VarChar, 6)
        If DefBlkpltVerCode = "" Or DefBlkpltVerCode = "[None]" Then
            pDEF_BLKPLT_VER_CODE.Value = System.DBNull.Value
        Else
            pDEF_BLKPLT_VER_CODE.Value = DefBlkpltVerCode
        End If
        arParams(3) = pDEF_BLKPLT_VER_CODE

        Dim pDEF_BLKPLT_VER2_CODE As New SqlParameter("@DEF_BLKPLT_VER2_CODE", SqlDbType.VarChar, 6)
        If DefBlkpltVer2Code = "" Or DefBlkpltVer2Code = "[None]" Then
            pDEF_BLKPLT_VER2_CODE.Value = System.DBNull.Value
        Else
            pDEF_BLKPLT_VER2_CODE.Value = DefBlkpltVer2Code
        End If
        arParams(4) = pDEF_BLKPLT_VER2_CODE

        Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        If ClCode.Trim() = "" Then
            pCL_CODE.Value = System.DBNull.Value
        Else
            pCL_CODE.Value = ClCode
        End If
        arParams(5) = pCL_CODE

        Dim pCOLOR As New SqlParameter("@COLOR", SqlDbType.VarChar, 7)
        If ColorHex.Trim() = "" Then 'Or ColorHex = "#FFFFFF" Then
            pCOLOR.Value = System.DBNull.Value
        Else
            pCOLOR.Value = ColorHex
        End If
        arParams(6) = pCOLOR

        Try
            Dim i As Integer = oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_AD_NUMBER_UPDATE", arParams)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try


    End Function

    Public Function AdNumber_Detail_Insert(ByVal AdNbr As String, ByVal AdNbrDesc As String, ByVal IsActive As Boolean, _
                                           ByVal DefBlkpltVerCode As String, ByVal DefBlkpltVer2Code As String, _
                                           ByVal ClCode As String, ByVal ColorHex As String) As String
        Dim arParams(7) As SqlParameter

        Dim pAD_NBR As New SqlParameter("@AD_NBR", SqlDbType.VarChar, 30)
        pAD_NBR.Value = AdNbr
        arParams(0) = pAD_NBR

        Dim pAD_NBR_DESC As New SqlParameter("@AD_NBR_DESC", SqlDbType.VarChar, 60)
        pAD_NBR_DESC.Value = AdNbrDesc
        arParams(1) = pAD_NBR_DESC

        Dim pACTIVE As New SqlParameter("@ACTIVE", SqlDbType.SmallInt)
        If IsActive = True Then
            pACTIVE.Value = 0
        Else
            pACTIVE.Value = 1
        End If
        arParams(2) = pACTIVE

        Dim pDEF_BLKPLT_VER_CODE As New SqlParameter("@DEF_BLKPLT_VER_CODE", SqlDbType.VarChar, 6)
        If DefBlkpltVerCode = "" Or DefBlkpltVerCode = "[None]" Then
            pDEF_BLKPLT_VER_CODE.Value = System.DBNull.Value
        Else
            pDEF_BLKPLT_VER_CODE.Value = DefBlkpltVerCode
        End If
        arParams(3) = pDEF_BLKPLT_VER_CODE

        Dim pDEF_BLKPLT_VER2_CODE As New SqlParameter("@DEF_BLKPLT_VER2_CODE", SqlDbType.VarChar, 6)
        If DefBlkpltVer2Code = "" Or DefBlkpltVer2Code = "[None]" Then
            pDEF_BLKPLT_VER2_CODE.Value = System.DBNull.Value
        Else
            pDEF_BLKPLT_VER2_CODE.Value = DefBlkpltVer2Code
        End If
        arParams(4) = pDEF_BLKPLT_VER2_CODE

        Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
        If ClCode.Trim() = "" Then
            pCL_CODE.Value = System.DBNull.Value
        Else
            pCL_CODE.Value = ClCode
        End If
        arParams(5) = pCL_CODE

        Dim pCOLOR As New SqlParameter("@COLOR", SqlDbType.VarChar, 7)
        If ColorHex.Trim() = "" Then 'Or ColorHex = "#FFFFFF" Then
            pCOLOR.Value = System.DBNull.Value
        Else
            pCOLOR.Value = ColorHex
        End If
        arParams(6) = pCOLOR

        Try
            Dim str As String = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_AD_NUMBER_INSERT", arParams)
            If str <> "0" Then
                If str = "1" Then
                    Return "Ad Number already exists"
                End If
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try

    End Function

#End Region

#Region " Agency Settings "

    Public Function AgencySettingGet(ByVal Setting_Name As String) As String
        Try
            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                MyConn.Open()
                Dim MyCmd As New SqlCommand("SELECT AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = '" & Setting_Name & "';", MyConn)
                Try
                    Return MyCmd.ExecuteScalar()
                Catch ex As Exception
                    Return "ERROR:" & ex.Message.ToString()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
            Return "ERROR:" & ex.Message.ToString()
        End Try
    End Function

    Public Overloads Function AgencySettingSet(ByVal AgySettingsCode As String, ByVal AgySettingsDesc As String, ByVal AgySettingsValue As String, ByVal AgySettingsDefaultValue As String) As String
        Try
            Dim arP(4) As SqlParameter

            Dim pAGY_SETTINGS_CODE As New SqlParameter("@AGY_SETTINGS_CODE", SqlDbType.VarChar, 20)
            pAGY_SETTINGS_CODE.Value = AgySettingsCode
            arP(0) = pAGY_SETTINGS_CODE

            Dim pAGY_SETTINGS_DESC As New SqlParameter("@AGY_SETTINGS_DESC", SqlDbType.VarChar, 100)
            pAGY_SETTINGS_DESC.Value = AgySettingsDesc
            arP(1) = pAGY_SETTINGS_DESC

            Dim pAGY_SETTINGS_VALUE As New SqlParameter("@AGY_SETTINGS_VALUE", SqlDbType.Variant)
            pAGY_SETTINGS_VALUE.Value = AgySettingsValue
            arP(2) = pAGY_SETTINGS_VALUE

            Dim pAGY_SETTINGS_DEF As New SqlParameter("@AGY_SETTINGS_DEF", SqlDbType.Variant)
            pAGY_SETTINGS_DEF.Value = AgySettingsDefaultValue
            arP(3) = pAGY_SETTINGS_DEF

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.StoredProcedure, "usp_wv_AGY_SETTINGS_INSERT_UPDATE", arP)
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Overloads Function AgencySettingSet(ByVal AgySettingsCode As String, ByVal AgySettingsValue As String) As String
        Try
            Dim arP(2) As SqlParameter

            Dim pAGY_SETTINGS_CODE As New SqlParameter("@AGY_SETTINGS_CODE", SqlDbType.VarChar, 20)
            pAGY_SETTINGS_CODE.Value = AgySettingsCode
            arP(0) = pAGY_SETTINGS_CODE

            Dim pAGY_SETTINGS_VALUE As New SqlParameter("@AGY_SETTINGS_VALUE", SqlDbType.Variant)
            pAGY_SETTINGS_VALUE.Value = AgySettingsValue
            arP(1) = pAGY_SETTINGS_VALUE

            SqlHelper.ExecuteNonQuery(Me.mConnString, CommandType.Text, "UPDATE AGY_SETTINGS WITH(ROWLOCK) SET AGY_SETTINGS_VALUE = @AGY_SETTINGS_VALUE WHERE AGY_SETTINGS_CODE = @AGY_SETTINGS_CODE;", arP)
            Return ""

        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

#End Region

End Class
