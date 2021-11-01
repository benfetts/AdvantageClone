Namespace Database.Procedures.TimesheetDayApprovalStatus

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StartDate As Date,
                             ByVal EndDate As Date, ByVal EmployeeCode As String, ByVal Status As Short) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.TimesheetDayApprovalStatus)

            'objects
            Dim StartDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EndDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EmployeeCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim StatusObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            StartDateObjectParameter = New System.Data.Objects.ObjectParameter("START_DATE", StartDate)
            EndDateObjectParameter = New System.Data.Objects.ObjectParameter("END_DATE", EndDate)
            EmployeeCodeObjectParameter = New System.Data.Objects.ObjectParameter("EMP_CODE", EmployeeCode)
            StatusObjectParameter = New System.Data.Objects.ObjectParameter("STATUS", Status)

            Load = DbContext.ExecuteFunction(Of Database.ComplexTypes.TimesheetDayApprovalStatus)("LoadTimesheetDayApprovalStatus", StartDateObjectParameter, EndDateObjectParameter, EmployeeCodeObjectParameter, StatusObjectParameter)

        End Function

#End Region

    End Module

End Namespace

