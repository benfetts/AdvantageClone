Namespace Database.Procedures.PurchaseOrderComplexType

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

        Public Function Load(DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal UserID As String,
                             Optional ByVal OmitVoid As Boolean? = False, Optional ByVal OmitComplete As Boolean? = False,
                             Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                             Optional ByVal EmployeeCode As String = Nothing, Optional ByVal VendorCode As String = Nothing, Optional ByVal JobNumber As Integer? = Nothing,
                             Optional ByVal JobCompNumber As Short? = Nothing, Optional ByVal PODate As DateTime? = Nothing, Optional ByVal DueDate As DateTime? = Nothing) As System.Collections.Generic.List(Of Database.Classes.PurchaseOrderComplex)

            'objects
            Dim SqlParameterOmitVoid As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOmitComplete As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobCompNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPODate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDueDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOmitVoid = New System.Data.SqlClient.SqlParameter("@OMIT_VOID", SqlDbType.Bit)
            SqlParameterOmitComplete = New System.Data.SqlClient.SqlParameter("@OMIT_COMPLETE", SqlDbType.Bit)
            SqlParameterClientCode = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar)
            SqlParameterDivisionCode = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar)
            SqlParameterProductCode = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@VN_CODE", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterJobCompNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMP_NBR", SqlDbType.SmallInt)
            SqlParameterPODate = New System.Data.SqlClient.SqlParameter("@PO_DATE", SqlDbType.SmallDateTime)
            SqlParameterDueDate = New System.Data.SqlClient.SqlParameter("@PO_DUE_DATE", SqlDbType.SmallDateTime)
            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@USER_ID", SqlDbType.VarChar)

            SqlParameterOmitVoid.Value = If(OmitVoid, 1, 0)
            SqlParameterOmitComplete.Value = If(OmitComplete, 1, 0)

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

            If String.IsNullOrEmpty(EmployeeCode) = False Then

                SqlParameterEmployeeCode.Value = EmployeeCode

            Else

                SqlParameterEmployeeCode.Value = System.DBNull.Value

            End If

            If String.IsNullOrEmpty(VendorCode) = False Then

                SqlParameterVendorCode.Value = VendorCode

            Else

                SqlParameterVendorCode.Value = System.DBNull.Value

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

            If PODate.HasValue Then

                SqlParameterPODate.Value = PODate

            Else

                SqlParameterPODate.Value = System.DBNull.Value

            End If

            If DueDate.HasValue Then

                SqlParameterDueDate.Value = DueDate

            Else

                SqlParameterDueDate.Value = System.DBNull.Value

            End If

            SqlParameterUserID.Value = UserID

            Try

                Load = DbContext.Database.SqlQuery(Of Database.Classes.PurchaseOrderComplex)("exec dbo.advsp_load_po_list @OMIT_VOID, @OMIT_COMPLETE, @CL_CODE, @DIV_CODE, @PRD_CODE, @EMP_CODE, @VN_CODE, @JOB_NUMBER, @JOB_COMP_NBR, @PO_DATE, @PO_DUE_DATE, @USER_ID",
                    SqlParameterOmitVoid, SqlParameterOmitComplete, SqlParameterClientCode, SqlParameterDivisionCode, SqlParameterProductCode,
                    SqlParameterEmployeeCode, SqlParameterVendorCode, SqlParameterJobNumber, SqlParameterJobCompNumber,
                    SqlParameterPODate, SqlParameterDueDate, SqlParameterUserID).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
