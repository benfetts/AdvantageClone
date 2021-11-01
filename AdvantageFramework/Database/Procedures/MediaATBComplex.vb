Namespace Database.Procedures.MediaATBComplex

    <HideModuleName()> _
    Public Module Methods

        Public Function Load(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, Optional ByVal ATBNumber As Integer = 0,
                             Optional ByVal Description As String = Nothing, Optional ByVal CampaignID As Integer = 0, Optional ByVal ClientCode As String = Nothing,
                             Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing, Optional ByVal ShowClosed As Boolean = False) As System.Collections.Generic.List(Of Database.Classes.MediaATBComplex)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterATBNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterShowClosed As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)
            SqlParameterATBNumber = New System.Data.SqlClient.SqlParameter("@ATB_NUMBER", SqlDbType.Int)
            SqlParameterDescription = New System.Data.SqlClient.SqlParameter("@DESCRIPTION", SqlDbType.VarChar)
            SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            SqlParameterShowClosed = New System.Data.SqlClient.SqlParameter("@SHOW_CLOSED", SqlDbType.Bit)

            SqlParameterUserCode.Value = UserCode

            If ATBNumber > 0 Then

                SqlParameterATBNumber.Value = ATBNumber

            Else

                SqlParameterATBNumber.Value = 0

            End If

            If String.IsNullOrEmpty(Description) = False Then

                SqlParameterDescription.Value = Description

            Else

                SqlParameterDescription.Value = ""

            End If

            If CampaignID > 0 Then

                SqlParameterCampaignID.Value = CampaignID

            Else

                SqlParameterCampaignID.Value = 0

            End If

            If String.IsNullOrEmpty(ClientCode) = False Then

                SqlParameterClientCode.Value = ClientCode

            Else

                SqlParameterClientCode.Value = ""

            End If

            If String.IsNullOrEmpty(DivisionCode) = False Then

                SqlParameterDivisionCode.Value = DivisionCode

            Else

                SqlParameterDivisionCode.Value = ""

            End If

            If String.IsNullOrEmpty(ProductCode) = False Then

                SqlParameterProductCode.Value = ProductCode

            Else

                SqlParameterProductCode.Value = ""

            End If

            SqlParameterShowClosed.Value = If(ShowClosed, 1, 0)

            Try

                Load = DbContext.Database.SqlQuery(Of Database.Classes.MediaATBComplex)("EXEC dbo.advsp_media_atb_load_orders @ATB_NUMBER, @DESCRIPTION, @CMP_IDENTIFIER, @CL_CODE, @DIV_CODE, @PRD_CODE, @SHOW_CLOSED, @USER_ID",
                    SqlParameterATBNumber, SqlParameterDescription, SqlParameterCampaignID, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode, SqlParameterShowClosed, SqlParameterUserCode).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

    End Module

End Namespace
