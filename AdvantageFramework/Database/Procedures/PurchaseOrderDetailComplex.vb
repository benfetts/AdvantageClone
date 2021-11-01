Namespace Database.Procedures.PurchaseOrderDetailsComplex

    <HideModuleName()>
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

        Public Function Load(DbContext As AdvantageFramework.BaseClasses.DbContext, Optional ByVal PONumber? As Integer = Nothing, Optional ByVal ClientCode As String = Nothing,
                             Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing, Optional ByVal JobNumber? As Integer = Nothing,
                             Optional ByVal JobCompNumber? As Short = Nothing) As System.Collections.Generic.List(Of Database.Classes.PurchaseOrderDetailsComplex)

            'objects
            Dim SqlParameterPONumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobCompNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterPONumber = New System.Data.SqlClient.SqlParameter("@PO_NUMBER", SqlDbType.Int)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobCompNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMP_NBR", SqlDbType.SmallInt)

            If PONumber.HasValue Then

                SqlParameterPONumber.Value = PONumber

            Else

                SqlParameterPONumber.Value = 0

            End If

            If String.IsNullOrEmpty(ClientCode) = False Then

                SqlParameterClientCode.Value = ClientCode

            Else

                SqlParameterClientCode.Value = System.DBNull.Value

            End If

            If String.IsNullOrEmpty(DivisionCode) = False Then

                SqlParameterDivisionCode.Value = DivisionCode

            Else

                SqlParameterDivisionCode.Value = System.DBNull.Value

            End If

            If String.IsNullOrEmpty(ProductCode) = False Then

                SqlParameterProductCode.Value = ProductCode

            Else

                SqlParameterProductCode.Value = System.DBNull.Value

            End If

            If JobNumber.HasValue Then

                SqlParameterJobNumber.Value = JobNumber

            Else

                SqlParameterJobNumber.Value = 0

            End If

            If JobCompNumber.HasValue Then

                SqlParameterJobCompNumber.Value = JobCompNumber

            Else

                SqlParameterJobCompNumber.Value = 0

            End If

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", DbContext.UserCode)

            Try

                Load = DbContext.Database.SqlQuery(Of Database.Classes.PurchaseOrderDetailsComplex)("EXEC dbo.advsp_load_po_details_advanced @PO_NUMBER, @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @JOB_COMP_NBR, @USER_CODE",
                                                                                                    SqlParameterPONumber, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode,
                                                                                                    SqlParameterJobNumber, SqlParameterJobCompNumber, SqlParameterUserCode).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
