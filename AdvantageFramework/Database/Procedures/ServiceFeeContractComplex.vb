Namespace Database.Procedures.ServiceFeeContractComplex

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(DbContext As Database.DbContext, UserCode As String,
                             Optional ByVal JobServiceFeeID As Integer? = Nothing, Optional ByVal ClientCode As String = Nothing,
                             Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                             Optional ByVal JobNumber As Integer? = Nothing, Optional ByVal JobComponentNumber As Short? = Nothing) As System.Collections.Generic.List(Of Database.Classes.ServiceFeeContractComplex)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobServiceFeeID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
            SqlParameterJobServiceFeeID = New System.Data.SqlClient.SqlParameter("@JOB_SERVICE_FEE_ID", SqlDbType.Int)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)

            SqlParameterUserCode.Value = UserCode

            If JobServiceFeeID.GetValueOrDefault(0) > 0 Then

                SqlParameterJobServiceFeeID.Value = JobServiceFeeID.Value

            Else

                SqlParameterJobServiceFeeID.Value = 0

            End If

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                SqlParameterClientCode.Value = ClientCode

            Else

                SqlParameterClientCode.Value = System.DBNull.Value

            End If

            If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                SqlParameterDivisionCode.Value = DivisionCode

            Else

                SqlParameterDivisionCode.Value = System.DBNull.Value

            End If

            If String.IsNullOrWhiteSpace(ProductCode) = False Then

                SqlParameterProductCode.Value = ProductCode

            Else

                SqlParameterProductCode.Value = System.DBNull.Value

            End If

            If JobNumber.GetValueOrDefault(0) > 0 Then

                SqlParameterJobNumber.Value = JobNumber.Value

            Else

                SqlParameterJobNumber.Value = 0

            End If

            If JobComponentNumber.GetValueOrDefault(0) > 0 Then

                SqlParameterJobComponentNumber.Value = JobComponentNumber.Value

            Else

                SqlParameterJobComponentNumber.Value = 0

            End If

            Load = DbContext.Database.SqlQuery(Of Database.Classes.ServiceFeeContractComplex)("EXEC dbo.advsp_job_component_service_fee_contract_load @JOB_SERVICE_FEE_ID, @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @USER_CODE",
                SqlParameterJobServiceFeeID, SqlParameterClientCode, SqlParameterDivisionCode,
                SqlParameterProductCode, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterUserCode).ToList

        End Function

#End Region

    End Module

End Namespace
