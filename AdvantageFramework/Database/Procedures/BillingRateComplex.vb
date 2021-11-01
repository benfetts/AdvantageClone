Namespace Database.Procedures.BillingRateComplex

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

        Public Function Load(ByVal DbContext As Database.DbContext, Optional ByVal EmployeeCode As String = Nothing,
                             Optional ByVal EffectiveDate As Nullable(Of DateTime) = Nothing, Optional ByVal FunctionCode As String = Nothing,
                             Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing,
                             Optional ByVal ProductCode As String = Nothing, Optional ByVal SalesClassCode As String = Nothing,
                             Optional ByVal FunctionType As String = Nothing, Optional ByVal JobNumber As Nullable(Of Integer) = Nothing,
                             Optional ByVal JobComponentNumber As Nullable(Of Short) = Nothing) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.ComplexTypes.BillingRateComplex)

            'objects
            Dim EmployeeCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EffectiveDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim ClientCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim DivisionCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim ProductCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim SalesClassCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim FunctionCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim FunctionTypeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim JobNumberObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim JobComponentNumberObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim ParameterList As System.Collections.Generic.List(Of System.Data.Objects.ObjectParameter) = Nothing

            ParameterList = New System.Collections.Generic.List(Of System.Data.Objects.ObjectParameter)

            EmployeeCodeObjectParameter = New System.Data.Objects.ObjectParameter("emp_code", If(EmployeeCode Is Nothing, DBNull.Value, EmployeeCode))
            EffectiveDateObjectParameter = New System.Data.Objects.ObjectParameter("eff_date", If(EffectiveDate Is Nothing, DBNull.Value, EffectiveDate))
            FunctionCodeObjectParameter = New System.Data.Objects.ObjectParameter("fnc_code", If(FunctionCode Is Nothing, DBNull.Value, FunctionCode))
            ClientCodeObjectParameter = New System.Data.Objects.ObjectParameter("cl_code", If(ClientCode Is Nothing, DBNull.Value, ClientCode))
            DivisionCodeObjectParameter = New System.Data.Objects.ObjectParameter("div_code", If(DivisionCode Is Nothing, DBNull.Value, DivisionCode))
            ProductCodeObjectParameter = New System.Data.Objects.ObjectParameter("prd_code", If(ProductCode Is Nothing, DBNull.Value, ProductCode))
            SalesClassCodeObjectParameter = New System.Data.Objects.ObjectParameter("sc_code", If(SalesClassCode Is Nothing, DBNull.Value, SalesClassCode))
            FunctionTypeObjectParameter = New System.Data.Objects.ObjectParameter("fnc_type", If(FunctionType Is Nothing, DBNull.Value, FunctionType))
            JobNumberObjectParameter = New System.Data.Objects.ObjectParameter("job_number", If(JobNumber Is Nothing, DBNull.Value, JobNumber))
            JobComponentNumberObjectParameter = New System.Data.Objects.ObjectParameter("job_component_nbr", If(JobComponentNumber Is Nothing, DBNull.Value, JobComponentNumber))

            ParameterList.Add(EmployeeCodeObjectParameter)
            ParameterList.Add(EffectiveDateObjectParameter)
            ParameterList.Add(FunctionCodeObjectParameter)
            ParameterList.Add(ClientCodeObjectParameter)
            ParameterList.Add(DivisionCodeObjectParameter)
            ParameterList.Add(ProductCodeObjectParameter)
            ParameterList.Add(SalesClassCodeObjectParameter)
            ParameterList.Add(FunctionTypeObjectParameter)
            ParameterList.Add(JobNumberObjectParameter)
            ParameterList.Add(JobComponentNumberObjectParameter)

            Load = DbContext.Database.SqlQuery(Of Database.ComplexTypes.BillingRateComplex)("LoadBillingRateComplex", ParameterList.ToArray)

        End Function

#End Region

    End Module

End Namespace
