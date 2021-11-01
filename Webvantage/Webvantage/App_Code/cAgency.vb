Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

<Serializable()> Public Class cAgency

    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Shared Function IsUsingLabels() As Boolean

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "IsUsingLabels"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Using dc = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                IsValid = AdvantageFramework.Database.Procedures.Label.HasActiveLabels(dc)

            End Using

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function
    Public Function IsUsingAssignments() As Boolean

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "IsUsingAssignments"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim i As Integer = 1
            Try

                i = oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT COUNT(1) FROM ALERT_NOTIFY_HDR WHERE ACTIVE_FLAG IS NULL OR ACTIVE_FLAG = 1;")

            Catch
                i = 1
            End Try

            IsValid = i > 0

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function
    Public Function ApplyTaxUponBilling() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ApplyTaxUponBilling"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try

                IsValid = oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT CAST(ISNULL(INV_TAX_FLAG, 0) AS BIT) FROM AGENCY WITH(NOLOCK);")

            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function

    Public Function GetTimeSheetDays() As Integer

        Dim myReturn As Integer = 5
        Dim SessionKey As String = "GetTimeSheetDays"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim parameterDays As New SqlParameter("@Days", SqlDbType.Int, 4)
            parameterDays.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_GetTSDays", parameterDays)
                myReturn = CInt(parameterDays.Value)
            Catch
                myReturn = 5
            End Try

            HttpContext.Current.Session(SessionKey) = myReturn.ToString()

        Else

            myReturn = CType(HttpContext.Current.Session(SessionKey), Integer)

        End If

        Return myReturn

    End Function
    'Public Function GetPostPeriodCheck() As Boolean
    '    Dim IsValid As Boolean = False
    '    Dim SessionKey As String = "GetPostPeriodCheck"

    '    If HttpContext.Current.Session(SessionKey) Is Nothing Then
    '        Dim parameterPP As New SqlParameter("@PostPeriod", SqlDbType.Int, 4)
    '        parameterPP.Direction = ParameterDirection.Output

    '        Try
    '            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_postperiod", parameterPP)
    '            If parameterPP.Value = 1 Then
    '                IsValid = True
    '            Else
    '                IsValid = False
    '            End If
    '        Catch
    '            IsValid = False
    '        End Try

    '        HttpContext.Current.Session(SessionKey) = IsValid
    '    Else
    '        IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
    '    End If

    '    Return IsValid

    'End Function
    Public Function CheckTimeSupervisorApproval() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "CheckTimeSupervisorApproval"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterPP As New SqlParameter("@Approval", SqlDbType.Int, 4)
            parameterPP.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_TimeSupervisorApproval", parameterPP)

                If parameterPP.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function QvAQueryCheck() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "QvAQueryCheck"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterQvA As New SqlParameter("@QvA", SqlDbType.Int, 4)
            parameterQvA.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_QvAQuery", parameterQvA)

                If parameterQvA.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function JobTemplateEditOfficeCheck() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobTemplateEditOfficeCheck"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterEditOffice As New SqlParameter("@EditOffice", SqlDbType.Int, 4)
            parameterEditOffice.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_EditOfficeQuery", parameterEditOffice)

                If parameterEditOffice.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function JobTemplateOverrideAgencyCheck(ByVal Client As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobTemplateOverrideAgencyCheck" & Client

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim myReturn As Integer = 0
            Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar)
            parameterClient.Value = Client

            Try
                myReturn = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_agency_ClientOverrideQuery", parameterClient)

                If myReturn = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function JobTemplateNonBillableJCCheck() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobTemplateNonBillableJCCheck"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterEditOffice As New SqlParameter("@NonBilliable", SqlDbType.Int, 4)
            parameterEditOffice.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_JCNonbilliable", parameterEditOffice)

                If parameterEditOffice.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function JobTemplateMarkedTaxable() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "JobTemplateMarkedTaxable"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterTaxable As New SqlParameter("@Taxable", SqlDbType.Int, 4)
            parameterTaxable.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_MarkedTaxable", parameterTaxable)

                If parameterTaxable.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function NewAlertPDFOnlyCheck() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "NewAlertPDFOnlyCheck"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterPDFAlertOnly As New SqlParameter("@PDFAlertOnly", SqlDbType.Int, 4)
            parameterPDFAlertOnly.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_PDFAlertOnlyQuery", parameterPDFAlertOnly)

                If parameterPDFAlertOnly.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function NewAlertNotifyCheck() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "NewAlertNotifyCheck"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterAlertNotify As New SqlParameter("@AlertNotify", SqlDbType.Int, 4)
            parameterAlertNotify.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_AlertNotifyQuery", parameterAlertNotify)

                If parameterAlertNotify.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function AutoEstRevFlag() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "AutoEstRevFlag"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim myReturn As Integer = 0

            ' Add Parameters to SPROC
            Dim parameterAutoEstRev As New SqlParameter("@AutoEstRev", SqlDbType.Int, 4)
            parameterAutoEstRev.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_AutoEstRev", parameterAutoEstRev)

                If parameterAutoEstRev.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function CheckCopyTimeSheet() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "CheckCopyTimeSheet"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterPP As New SqlParameter("@copyts", SqlDbType.Int, 4)
            parameterPP.Direction = ParameterDirection.Output

            Try
                oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_agency_copy_timesheet", parameterPP)

                If parameterPP.Value = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function
    Public Function WebvantageURL() As String

        Dim CurrentURL As String = HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Host & "/" & HttpContext.Current.Request.ApplicationPath
        Dim URL As String
        Dim SessionKey As String = "WebvantageURL"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try

                URL = oSQL.ExecuteScalar(mConnString, CommandType.Text, "SELECT ISNULL(WEBVANTAGE_URL, '') FROM AGENCY WITH(NOLOCK);")

                If URL = "" Then URL = CurrentURL

            Catch

                URL = CurrentURL

            End Try

            HttpContext.Current.Session(SessionKey) = URL

        Else
            
            URL = HttpContext.Current.Session(SessionKey).ToString

        End If

        Return URL

    End Function

    'WV Agency Settings
    Public Function SaveBinaryImage(ByVal ID As String, ByVal desc As String, ByVal picture As Byte(), Optional ByVal app As Integer = 0) As Boolean
        Dim arParams(4) As SqlParameter

        Dim parameterID As New SqlParameter("@BINARY_IMAGE_CODE", SqlDbType.VarChar)
        parameterID.Value = ID
        arParams(0) = parameterID

        Dim parameterPicture As New SqlParameter("@BINARY_IMAGE_DESC", SqlDbType.VarChar)
        parameterPicture.Value = desc
        arParams(1) = parameterPicture

        Dim parameterValue As New SqlParameter("@BINARY_IMAGE_VALUE", SqlDbType.Image)
        parameterValue.Value = picture
        arParams(2) = parameterValue

        Dim parameterApp As New SqlParameter("@BINARY_IMAGE_APP", SqlDbType.SmallInt)
        If app = 0 Then
            parameterApp.Value = DBNull.Value
        Else
            parameterApp.Value = app
        End If
        arParams(3) = parameterApp

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_SaveAgencyImageSettings", arParams)
            Return True

        Catch

            Return False

        End Try

    End Function
    Public Function GetBinaryImage(ByVal ID As String)
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parameterID As New SqlParameter("@BINARY_IMAGE_CODE", SqlDbType.VarChar)
        parameterID.Value = ID
        arParams(0) = parameterID

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetAgencyImageSettings", arParams)
        Catch
            Return dr
        End Try

        Return dr

    End Function
    Public Function DeleteBinaryImage(ByVal WhichImage As UserThemeSettings.CustomImageId, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = "DELETE FROM AGY_BINARY_IMAGES WITH(ROWLOCK) WHERE BINARY_IMAGE_CODE = @BINARY_IMAGE_CODE;"
                    .Connection = MyConn
                End With

                Dim pBinaryImageCode As New SqlParameter("@BINARY_IMAGE_CODE", SqlDbType.VarChar, 20)
                pBinaryImageCode.Value = WhichImage.ToString()
                MyCommand.Parameters.Add(pBinaryImageCode)

                MyConn.Open()

                MyCommand.ExecuteScalar()

                Dim AgyStg As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)
                Dim FileName As String = ""

                Try

                    FileName = AgyStg.GetValue(AdvantageFramework.Agency.Settings.WV_BRND_BG, "")

                    If FileName <> "" Then

                        File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                    End If

                Catch ex As Exception
                End Try

                Select Case WhichImage
                    Case UserThemeSettings.CustomImageId.WV_DEFAULT_WP

                        Try

                            FileName = AgyStg.GetValue(AdvantageFramework.Agency.Settings.WV_BRND_BG, "")

                            If FileName <> "" Then

                                File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                            End If

                        Catch ex As Exception

                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            'Return False

                        End Try

                        AgyStg.UpdateValue(AdvantageFramework.Agency.Settings.WV_BRND_BG, "")

                    Case UserThemeSettings.CustomImageId.WV_DEFAULT_ICON

                        Try

                            FileName = AgyStg.GetValue(AdvantageFramework.Agency.Settings.WV_BRND_ICON, "")

                            If FileName <> "" Then

                                File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                            End If

                        Catch ex As Exception
                        End Try

                        AgyStg.UpdateValue(AdvantageFramework.Agency.Settings.WV_BRND_ICON, "")

                    Case UserThemeSettings.CustomImageId.WV_DEFAULT_LOGO

                        Try

                            FileName = AgyStg.GetValue(AdvantageFramework.Agency.Settings.WV_BRND_LOGO, "")

                            If FileName <> "" Then

                                File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                            End If

                        Catch ex As Exception
                        End Try

                        AgyStg.UpdateValue(AdvantageFramework.Agency.Settings.WV_BRND_LOGO, "")

                End Select

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function

    'client portal
    Public Function ClientPortal_SaveBinaryImage(ByVal ClCode As String, ByVal [Image] As Byte(), ByVal [Type] As UserThemeSettings.ImageType, Optional ByRef ErrorMessage As String = "") As Boolean

        Try

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_SaveClientPortalImage"
                    .Connection = MyConn
                End With

                Dim pClCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                If ClCode = "" Then
                    pClCode.Value = System.DBNull.Value
                Else
                    pClCode.Value = ClCode
                End If
                MyCommand.Parameters.Add(pClCode)

                Dim pImage As New SqlParameter("@IMAGE", SqlDbType.Image)
                If [Image].Length = 0 Then
                    pImage.Value = System.DBNull.Value
                Else
                    pImage.Value = [Image]
                End If
                MyCommand.Parameters.Add(pImage)

                Dim pImageType As New SqlParameter("@IMAGE_TYPE", SqlDbType.TinyInt)
                pImageType.Value = CType([Type], Integer)
                MyCommand.Parameters.Add(pImageType)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Public Function ClientPortal_DeleteBinaryImage(ByVal ClCode As String, ByVal [Type] As UserThemeSettings.ImageType, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim FileName As String = ""

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_DeleteClientPortalImage"
                    .Connection = MyConn
                End With

                Dim pClientCode As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                If ClCode = "" Then
                    pClientCode.Value = System.DBNull.Value
                Else
                    pClientCode.Value = ClCode
                End If
                MyCommand.Parameters.Add(pClientCode)

                Dim pImageType As New SqlParameter("@IMAGE_TYPE", SqlDbType.TinyInt)
                pImageType.Value = CType([Type], Integer)
                MyCommand.Parameters.Add(pImageType)

                MyConn.Open()

                FileName = MyCommand.ExecuteScalar()

                Try

                    If FileName <> "" Then

                        File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                    End If

                Catch ex As Exception
                End Try

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function

    'user
    Public Function User_SaveBinaryImage(ByVal EmpCode As String, ByVal UserCode As String, ByVal [Image] As Byte(), ByVal Filename As String, Optional ByRef ErrorMessage As String = "") As Boolean

        Try

            If EmpCode = "" Then

                ErrorMessage = "No employee code"
                Return False

            End If

            If UserCode = "" Then

                ErrorMessage = "No user code"
                Return False

            End If

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand

                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_SaveEmployeeWallpaper"
                    .Connection = MyConn

                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                MyCommand.Parameters.Add(pEmpCode)

                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = UserCode
                MyCommand.Parameters.Add(pUserCode)

                Dim pImage As New SqlParameter("@IMAGE", SqlDbType.Image)
                If [Image].Length = 0 Then

                    pImage.Value = System.DBNull.Value
                    Filename = ""

                Else

                    pImage.Value = [Image]

                End If
                MyCommand.Parameters.Add(pImage)

                Dim pFilename As New SqlParameter("@FILENAME", SqlDbType.VarChar)
                pFilename.Value = Filename
                MyCommand.Parameters.Add(pFilename)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Public Function User_DeleteBinaryImage(ByVal EmpCode As String, ByVal UserCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim FileName As String = ""

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_DeleteEmployeeCustomWallpaper"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                MyCommand.Parameters.Add(pEmpCode)

                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = UserCode
                MyCommand.Parameters.Add(pUserCode)

                MyConn.Open()

                FileName = MyCommand.ExecuteScalar()

                Try

                    If FileName <> "" Then

                        File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                    End If

                Catch ex As Exception
                End Try

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function

    'employee signature
    Public Function EmployeeSignature_SaveBinaryImage(ByVal EmpCode As String, ByVal [Image] As Byte(), Optional ByRef ErrorMessage As String = "") As Boolean

        Try

            If EmpCode = "" Then

                ErrorMessage = "No employee code"
                Return False

            End If

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "advsp_employee_save_signature"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                'If EmpCode = "" Then
                '    pEmpCode.Value = System.DBNull.Value
                'Else
                pEmpCode.Value = EmpCode
                'End If
                MyCommand.Parameters.Add(pEmpCode)

                Dim pImage As New SqlParameter("@IMAGE", SqlDbType.VarBinary, Image.Length)
                If [Image].Length = 0 Then
                    pImage.Value = System.DBNull.Value
                Else
                    pImage.Value = [Image]
                End If
                MyCommand.Parameters.Add(pImage)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Public Function EmployeeSignature_DeleteBinaryImage(ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim FileName As String = ""

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE dbo.EMPLOYEE SET EMP_SIG = NULL WHERE EMP_CODE = @EMP_CODE;"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                MyCommand.Parameters.Add(pEmpCode)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

                ''FileName = MyCommand.ExecuteScalar()

                ''Try

                ''    If FileName <> "" Then

                ''        File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                ''    End If

                ''Catch ex As Exception
                ''End Try

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function

    'employee picture
    Public Function EmployeePicture_SaveBinaryImage(ByVal EmpCode As String, ByVal [Image] As Byte(), Optional ByRef ErrorMessage As String = "") As Boolean

        Try

            If EmpCode = "" Then

                ErrorMessage = "No employee code"
                Return False

            End If

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_SaveEmployeePicture"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                'If EmpCode = "" Then
                '    pEmpCode.Value = System.DBNull.Value
                'Else
                pEmpCode.Value = EmpCode
                'End If
                MyCommand.Parameters.Add(pEmpCode)

                Dim pImage As New SqlParameter("@IMAGE", SqlDbType.Image)
                If [Image].Length = 0 Then
                    pImage.Value = System.DBNull.Value
                Else
                    pImage.Value = [Image]
                End If
                MyCommand.Parameters.Add(pImage)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Public Function EmployeePicture_DeleteBinaryImage(ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim FileName As String = ""

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.Text
                    .CommandText = "UPDATE EMPLOYEE_PICTURE SET EMP_IMAGE = NULL WHERE EMP_CODE = @EMP_CODE;"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                MyCommand.Parameters.Add(pEmpCode)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

                ''FileName = MyCommand.ExecuteScalar()

                ''Try

                ''    If FileName <> "" Then

                ''        File.Delete(HttpContext.Current.Request.PhysicalApplicationPath & "TEMP\" & FileName)

                ''    End If

                ''Catch ex As Exception
                ''End Try

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
