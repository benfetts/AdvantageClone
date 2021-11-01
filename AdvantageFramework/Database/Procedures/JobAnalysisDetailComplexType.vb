Namespace Database.Procedures.JobAnalysisDetailComplexType

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

        Public Function Load(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                             Optional ByVal ExcludeNonBillableTime As Boolean = True, Optional ByVal ExcludeZeroMarkupAmount As Boolean = True,
                             Optional ByVal IncludeClientOOP As Boolean = True, Optional ByVal IncludeEmployeeTime As Boolean = True,
                             Optional ByVal IncludeProduction As Boolean = True, Optional ByVal IncludeIncomeOnly As Boolean = True,
                             Optional ByVal IncludeAdvanceBilling As Boolean = True, Optional ByVal IncludeEstimate As Boolean = True,
                             Optional ByVal IncludeOpenPO As Boolean = True, Optional ByVal StartDate As String = Nothing,
                             Optional ByVal EndDate As String = Nothing) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.JobAnalysisDetail)

            'objects
            Dim ExcludeNonBillableTimeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim ExcludeZeroMarkupAmountObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeClientOOPObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeEmployeeTimeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeProductionObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeIncomeOnlyObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeAdvanceBillingObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeEstimateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeOpenPOObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim StartDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EndDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            ExcludeNonBillableTimeObjectParameter = New System.Data.Objects.ObjectParameter("ExcludeNBTimeFnc", ExcludeNonBillableTime)
            ExcludeZeroMarkupAmountObjectParameter = New System.Data.Objects.ObjectParameter("ExcludeZeroMUAmt", ExcludeZeroMarkupAmount)
            IncludeEmployeeTimeObjectParameter = New System.Data.Objects.ObjectParameter("IncludeEmployeeTime", IncludeEmployeeTime)
            IncludeClientOOPObjectParameter = New System.Data.Objects.ObjectParameter("IncludeClientOOP", IncludeClientOOP)
            IncludeEmployeeTimeObjectParameter = New System.Data.Objects.ObjectParameter("IncludeEmployeeTime", IncludeEmployeeTime)
            IncludeProductionObjectParameter = New System.Data.Objects.ObjectParameter("IncludeProduction", IncludeProduction)
            IncludeIncomeOnlyObjectParameter = New System.Data.Objects.ObjectParameter("IncludeIncomeOnly", IncludeIncomeOnly)
            IncludeAdvanceBillingObjectParameter = New System.Data.Objects.ObjectParameter("IncludeAdvanceBilling", IncludeAdvanceBilling)
            IncludeEstimateObjectParameter = New System.Data.Objects.ObjectParameter("IncludeEstimate", IncludeEstimate)
            IncludeOpenPOObjectParameter = New System.Data.Objects.ObjectParameter("IncludeOpenPO", IncludeOpenPO)

            If StartDate Is Nothing Then

                StartDateObjectParameter = New System.Data.Objects.ObjectParameter("StartDate", GetType(String))

            Else

                StartDateObjectParameter = New System.Data.Objects.ObjectParameter("StartDate", StartDate)

            End If

            If EndDate Is Nothing Then

                EndDateObjectParameter = New System.Data.Objects.ObjectParameter("EndDate", GetType(String))

            Else

                EndDateObjectParameter = New System.Data.Objects.ObjectParameter("EndDate", EndDate)

            End If

            Load = DbContext.ExecuteFunction(Of Database.ComplexTypes.JobAnalysisDetail)("LoadJobAnalysisDetails", ExcludeNonBillableTimeObjectParameter, ExcludeZeroMarkupAmountObjectParameter,
                                                                                             IncludeClientOOPObjectParameter, IncludeEmployeeTimeObjectParameter,
                                                                                             IncludeProductionObjectParameter, IncludeIncomeOnlyObjectParameter,
                                                                                             IncludeAdvanceBillingObjectParameter, IncludeEstimateObjectParameter,
                                                                                             IncludeOpenPOObjectParameter)

        End Function

#End Region

    End Module

End Namespace

