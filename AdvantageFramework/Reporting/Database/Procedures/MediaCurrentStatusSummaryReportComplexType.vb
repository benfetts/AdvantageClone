Namespace Reporting.Database.Procedures.MediaCurrentStatusSummaryReportComplexType

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

        Public Function Load(ByVal ReportingObjectContext As Reporting.Database.ObjectContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.MediaCurrentStatusSummaryReport)

            Load = Load(ReportingObjectContext, ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.OrderStatus.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartDate.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartMonth.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.StartYear.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndDate.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndMonth.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.EndYear.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeInternet.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeMagazine.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeNewspaper.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeOutOfHome.ToString), ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeRadio.ToString), _
                        ParameterDictionary(AdvantageFramework.Reporting.MediaCurrentStatusSummaryParameters.IncludeTelevision.ToString))

        End Function
        Public Function Load(ByVal ReportingObjectContext As Reporting.Database.ObjectContext, Optional ByVal OrderStatus As String = "O", Optional ByVal StartDate As Date = #1/1/1900#, _
                             Optional ByVal StartMonth As Integer = 1, Optional ByVal StartYear As Integer = 1900, Optional ByVal EndDate As Date = #1/1/1900#, _
                             Optional ByVal EndMonth As Integer = 1, Optional ByVal EndYear As Integer = 1900, Optional ByVal IncludeInternet As Boolean = True, _
                             Optional ByVal IncludeMagazine As Boolean = True, Optional ByVal IncludeNewspaper As Boolean = True, Optional ByVal IncludeOutOfHome As Boolean = True, _
                             Optional ByVal IncludeRadio As Boolean = True, Optional ByVal IncludeTelevision As Boolean = True) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.MediaCurrentStatusSummaryReport)

            'objects
            Dim OrderStatusObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim StartDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim StartMonthObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim StartYearObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EndDateObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EndMonthObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EndYearObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeInternetObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeMagazineObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeNewspaperObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeOutOfHomeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeRadioObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim IncludeTelevisionObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            OrderStatusObjectParameter = New System.Data.Objects.ObjectParameter("order_status", OrderStatus)
            StartDateObjectParameter = New System.Data.Objects.ObjectParameter("start_date", StartDate)
            StartMonthObjectParameter = New System.Data.Objects.ObjectParameter("start_month", StartMonth)
            StartYearObjectParameter = New System.Data.Objects.ObjectParameter("start_year", StartYear)
            EndDateObjectParameter = New System.Data.Objects.ObjectParameter("end_date", EndDate)
            EndMonthObjectParameter = New System.Data.Objects.ObjectParameter("end_month", EndMonth)
            EndYearObjectParameter = New System.Data.Objects.ObjectParameter("end_year", EndYear)
            IncludeInternetObjectParameter = New System.Data.Objects.ObjectParameter("include_internet", IncludeInternet)
            IncludeMagazineObjectParameter = New System.Data.Objects.ObjectParameter("include_magazine", IncludeMagazine)
            IncludeNewspaperObjectParameter = New System.Data.Objects.ObjectParameter("include_newspaper", IncludeNewspaper)
            IncludeOutOfHomeObjectParameter = New System.Data.Objects.ObjectParameter("include_outofhome", IncludeOutOfHome)
            IncludeRadioObjectParameter = New System.Data.Objects.ObjectParameter("include_radio", IncludeRadio)
            IncludeTelevisionObjectParameter = New System.Data.Objects.ObjectParameter("include_television", IncludeTelevision)

            Load = ReportingObjectContext.ExecuteFunction(Of Database.ComplexTypes.MediaCurrentStatusSummaryReport)("LoadMediaCurrentStatusSummaryReport", OrderStatusObjectParameter, StartDateObjectParameter, _
                                                                                                            StartMonthObjectParameter, StartYearObjectParameter, EndDateObjectParameter, _
                                                                                                            EndMonthObjectParameter, EndYearObjectParameter, IncludeInternetObjectParameter, _
                                                                                                            IncludeMagazineObjectParameter, IncludeNewspaperObjectParameter, IncludeOutOfHomeObjectParameter, _
                                                                                                            IncludeRadioObjectParameter, IncludeTelevisionObjectParameter)

        End Function

#End Region

    End Module

End Namespace
