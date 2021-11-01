Namespace Estimate.Printing

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ReportFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "001 - One Quote per Page")>
            OneQuotePerPage = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "002 - Side by Side Quote")>
            SideBySideQuote = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "003 - Revision Comparison")>
            RevisionComparison = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "004 - Revision Comparison w/Variance")>
            RevisionComparisonWithVariance = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "005 - Revision Comparison w/Var, No Actual")>
            RevisionComparisonWithVarianceNoActual = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "006 - Revision Comparison, No Actual")>
            RevisionComparisonNoActual = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "007 - Revision Comparison, Prev/Last Revisions")>
            RevisionComparisonPrevLastRevisions = 7
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("008", "008 - Campaign Estimate Totals by Estimate Component")>
            'CampaignEstimateTotalsByEstimateComponent = 8
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("009", "009 - Campaign Estimate by Function Heading")>
            'CampaignEstimateByFunctionHeading = 9
            
        End Enum

        Public Enum CustomReportFormats
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("300", "300 - SSX - Campaign Estimate")>
            SSXCampaignEstimate = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("301", "301 - SSX - Estimate")>
            SSXEstimate = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("302", "302 - Quarry - Campaign Estimate")>
            QuarryCampaignEstimate = 12
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("303", "303 - All Components, Subtotal Components")>
            AllComponentsSubtotalComponents = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("304", "304 - Original/Final Comparison w/Var, No Actual")>
            OriginalFinalComparisonWithVarianceNoActual = 14
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("305", "305 - Original/Final Comparison, No Actual")>
            OriginalFinalComparisonNoActual = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("306", "306 - Infinity Estimate")>
            InfinityEstimate = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("307", "307 - BWD Estimate Form")>
            BWDEstimateForm = 17
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("308", "308 - BWD Client Estimate Form")>
            BWDClientEstimateForm = 18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("309", "309 - TPN Custom Estimate Form")>
            TPNCustomEstimateForm = 19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("310", "310 - TPN Custom Estimate Form 2")>
            TPNCustomEstimateForm2 = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("311", "311 - Tap Campaign Estimate")>
            TapCampaignEstimate = 21
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("312", "312 - Tap Campaign Estimate (Job)")>
            TapCampaignEstimateJob = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("313", "313 - Revision Comparison w/Var, Prev/Last Revisions")>
            RevisionComparisonWithVariancePrevLastRevisions = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("314", "314 - Side by Side Quote with Function Comments")>
            SideBySideQuoteWithFunctionComments = 24
        End Enum

        Public Enum EstimateFormatTypes As Integer
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client/Product Default")>
            ClientDefault = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "User")>
            UserDefault = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Agency")>
            Agency = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "One-Time")>
            OneTime = 4
        End Enum

        Public Enum AddressBlockTypes
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Client", "Client Address")>
            ClientAddress = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Division", "Division Address")>
            DivisionAddress = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Product", "Product Address")>
            ProductAddress = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("Contact", "Job Contact Address")>
            JobContactAddress = 4
        End Enum

        <System.ComponentModel.TypeConverter(GetType(AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute))>
        Public Enum Signatures As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "None")>
            NoSignature = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "001 - Standard Signature")>
            StandardSignature = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "002 - Agency, 2 Client Signatures")>
            Agency2ClientSignature = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "003 - Agency Name, Client Authorization")>
            AgencyNameClientAuthorization = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "004 - Agency, 5 Client Signatures")>
            Agency5ClientSignatures = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "005 - Standard Signature with Client PO Line")>
            StandardSignatureWithClientPOLine = 6
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "006 - Agency, 2 Client w/Titles")>
            'Agency2ClientTitles = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "007 - Agency and Client Signature")>
            AgencyAndClientSignature = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "008 - Manager, AE, and Client Signature")>
            ManagerAEClientSignature = 9
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("10", "009 - Agency, Printed Name, and Title")>
            AgencyPrintedNameTitleClientSignature = 10
        End Enum

        Public Enum FunctionOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("F", "Function Code")>
            FunctionCode = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Consolidation Code")>
            ConsolidationCode = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("T", "Total Only")>
            TotalOnly = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("R", "Rate")>
            Rate = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("N", "None")>
            None = 5
        End Enum

        Public Enum GroupOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "None")>
            None = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Function Type")>
            FunctionType = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Function Heading")>
            FunctionHeading = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Function Heading Total Only")>
            FunctionHeadingTotalOnly = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Inside/Outside")>
            InsideOutside = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Phase")>
            Phase = 6
        End Enum

        Public Enum SortOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("C", "Function Code")>
            FunctionCode = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("O", "Function Order")>
            FunctionOrder = 2
        End Enum

        Public Enum SelectByOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "By Job Component")>
            JobComponent = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "By Estimate")>
            Estimate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "By Campaign")>
            Campaign = 3
        End Enum

        Public Enum GroupByOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Job Component")>
            JobComponent = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Estimate")>
            Estimate = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Campaign")>
            Campaign = 3
        End Enum

        Public Enum SummaryOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Campaign")>
            'Campaign = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Job")>
            Job = 2
        End Enum

        Public Enum ContactType
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "None")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Attention Line")>
            Attention = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Estimate | Job | Attn")>
            EstimateJobAttn = 2
        End Enum
        Public Enum PackageTypes
            None = 0
            OneZip = 1
            OneZipPerInvoice = 2
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadEstimatePrintDetails(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                 ByVal GroupOption As String, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    If combine = 2 Then
                        LoadEstimatePrintDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_Report_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @GroupBy, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, GroupByParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_FH_Report @EstNo, @EstCompNo, @UserID, @Quotes, @PrintID",
                                                                                                                                                    EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, PrintIDParameter)
                    End If

                Else
                    If combine = 2 Then
                        LoadEstimatePrintDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_Report_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @GroupBy, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, GroupByParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_Report @EstNo, @EstCompNo, @UserID, @Quotes, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, PrintIDParameter)
                    End If
                End If
            Catch ex As Exception
                LoadEstimatePrintDetails = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetailsWV(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                 ByVal GroupOption As String, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    LoadEstimatePrintDetailsWV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_FH_Report @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                    EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                Else
                    If combine = 1 Then
                        LoadEstimatePrintDetailsWV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_Report_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @GroupBy, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, GroupByParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetailsWV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_Report @EstNo, @EstCompNo, @UserID, @Quotes, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, PrintIDParameter)
                    End If
                End If
            Catch ex As Exception
                LoadEstimatePrintDetailsWV = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetails002(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                    ByVal GroupOption As String, ByVal ReportType As Integer, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim ReportTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ReportType", ReportType)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    LoadEstimatePrintDetails002 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_FH @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                Else
                    If combine = 2 Then
                        LoadEstimatePrintDetails002 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_Report002_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails002 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_Report002 @EstNo, @EstCompNo, @UserID, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    End If

                End If

            Catch ex As Exception
                LoadEstimatePrintDetails002 = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetails002WV(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                    ByVal GroupOption As String, ByVal ReportType As Integer, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim ReportTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ReportType", ReportType)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    LoadEstimatePrintDetails002WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_FH @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                Else
                    If combine = 1 Then
                        LoadEstimatePrintDetails002WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_Report002_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails002WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail002)("EXEC dbo.usp_wv_Estimating_Print_Details_Report002 @EstNo, @EstCompNo, @UserID, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    End If

                End If

            Catch ex As Exception
                LoadEstimatePrintDetails002WV = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetails003(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                    ByVal GroupOption As String, ByVal ReportType As Integer, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim ReportTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("ReportType", ReportType)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    LoadEstimatePrintDetails003 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_FH @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                Else
                    If combine = 2 Then
                        LoadEstimatePrintDetails003 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_Report003_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails003 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_Report003 @EstNo, @EstCompNo, @UserID, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    End If

                End If

            Catch ex As Exception
                LoadEstimatePrintDetails003 = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetails003WV(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer,
                                                    ByVal GroupOption As String, ByVal ReportType As Integer, Optional QuoteNumbers As String = "", Optional combine As Integer = 0, Optional CompNumbers As String = "", Optional PrintID As Integer = 0) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim ReportTypeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("ReportType", ReportType)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                Dim CompsParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("Comps", CompNumbers)
                Dim GroupByParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@Groupby", "cb")
                Dim PrintIDParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@PrintID", PrintID)
                If GroupOption = "4" Then
                    LoadEstimatePrintDetails003WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_FH @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                Else
                    If combine = 1 Then
                        LoadEstimatePrintDetails003WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_Report003_Combined @EstNo, @EstCompNo, @UserID, @Comps, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, CompsParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    Else
                        LoadEstimatePrintDetails003WV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail003)("EXEC dbo.usp_wv_Estimating_Print_Details_Report003 @EstNo, @EstCompNo, @UserID, @Quotes, @ReportType, @PrintID",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter, ReportTypeParameter, PrintIDParameter)
                    End If

                End If

            Catch ex As Exception
                LoadEstimatePrintDetails003WV = Nothing
            End Try

        End Function
        Public Function LoadEstimatePrintDetailsSS2(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, EstimateQuoteNumber As Integer, ByVal GroupOption As String, Optional QuoteNumbers As String = "") As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail301)
            Try
                Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                Dim EstimateNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstNo", EstimateNumber)
                Dim EstimateComponentNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@EstCompNo", EstimateComponentNumber)
                Dim QuotesParameter As System.Data.SqlClient.SqlParameter
                If QuoteNumbers <> "" Then
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", QuoteNumbers)
                Else
                    QuotesParameter = New System.Data.SqlClient.SqlParameter("@Quotes", EstimateQuoteNumber.ToString & ",")
                End If
                If GroupOption = "4" Then
                    'LoadEstimatePrintDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)("EXEC dbo.usp_wv_Estimating_Print_Details_FH_Report @EstNo, @EstCompNo, @UserID, @Quotes", _
                    'EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                    LoadEstimatePrintDetailsSS2 = Nothing
                Else
                    LoadEstimatePrintDetailsSS2 = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail301)("EXEC dbo.usp_wv_Estimating_Print_Details_Report301 @EstNo, @EstCompNo, @UserID, @Quotes",
                                                                                                                                                      EstimateNumberParameter, EstimateComponentNumberParameter, QuotesParameter, UserCodeParameter)
                End If

            Catch ex As Exception
                LoadEstimatePrintDetailsSS2 = Nothing
            End Try

        End Function
        Public Function SaveEstimate(DbContext As AdvantageFramework.Database.DbContext, EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                'DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ACCT_REC SET DUE_DATE = {0}, INV_CAT = {1} WHERE AR_INV_NBR = {2} AND [AR_INV_SEQ] = {3} AND [AR_TYPE] = '{4}'", _
                '                                                If(AccountReceivableInvoice.DueDate.HasValue, "'" & AccountReceivableInvoice.DueDate.Value.ToShortDateString & "'", "NULL"), _
                '                                                If(String.IsNullOrWhiteSpace(AccountReceivableInvoice.InvoiceCategoryCode) = False, "'" & AccountReceivableInvoice.InvoiceCategoryCode & "'", "NULL"),
                '                                                AccountReceivableInvoice.InvoiceNumber, AccountReceivableInvoice.InvoiceSequenceNumber, AccountReceivableInvoice.InvoiceType))

                If EstimateQuote.EstimateNumber > 0 Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_LOG] SET EST_LOG_COMMENT = {1}, EST_LOG_COMMENT_HTML = {1}, EST_CREATE_DATE = {2} WHERE [ESTIMATE_NUMBER] = {0}",
                                                                    EstimateQuote.EstimateNumber,
                                                                    If(String.IsNullOrWhiteSpace(EstimateQuote.EstimateComment) = False, "'" & EstimateQuote.EstimateComment.Replace("'", "''") & "'", "NULL"),
                                                                    If(String.IsNullOrWhiteSpace(EstimateQuote.EstimateDate) = False, "'" & EstimateQuote.EstimateDate.ToShortDateString & "'", "NULL")))

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_COMPONENT] SET EST_COMP_COMMENT = {2}, EST_COMP_COMMENT_HTML = {2}, CDP_CONTACT_ID = {3} WHERE [ESTIMATE_NUMBER] = {0} AND [EST_COMPONENT_NBR] = {1}",
                                                                    EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber,
                                                                    If(String.IsNullOrWhiteSpace(EstimateQuote.EstimateComponentComment) = False, "'" & EstimateQuote.EstimateComponentComment.Replace("'", "''") & "'", "NULL"),
                                                                    If(EstimateQuote.EstimateContact.HasValue, EstimateQuote.EstimateContact.Value, "NULL")))

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ESTIMATE_QUOTE] SET EST_QTE_COMMENT = {3}, EST_QTE_COMMENT_HTML = {3} WHERE [ESTIMATE_NUMBER] = {0} AND [EST_COMPONENT_NBR] = {1} AND [EST_QUOTE_NBR] = {2}",
                                                                   EstimateQuote.EstimateNumber, EstimateQuote.EstimateComponentNumber, EstimateQuote.QuoteNumber,
                                                                   If(String.IsNullOrWhiteSpace(EstimateQuote.EstimateQuoteComment) = False, "'" & EstimateQuote.EstimateQuoteComment.Replace("'", "''") & "'", "NULL")))



                End If

                Saved = True

            Catch ex As Exception
                Saved = False
            End Try

            SaveEstimate = Saved

        End Function
        Public Function LoadEstimatePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, IsOneTime As Boolean, EstimateFormatType As AdvantageFramework.Estimate.Printing.EstimateFormatTypes) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)
            Try

                Dim IsOneTimeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsOneTime", IsOneTime)
                Dim EstimateType As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ClientOrProduct", EstimateFormatType)

                LoadEstimatePrintingSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)("EXEC dbo.advsp_estimate_printing_settings @IsOneTime, @ClientOrProduct", IsOneTimeParameter, EstimateType)

            Catch ex As Exception
                LoadEstimatePrintingSettings = Nothing
            End Try

        End Function

        Public Function LoadEstimatePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, EstimateFormatType As EstimateFormatTypes, Optional ClientCode As String = Nothing, Optional ProductCode As String = Nothing, Optional ByVal UserID As String = Nothing) As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

                EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                If EstimateDefault Is Nothing Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)
                    ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting
                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintingSetting.Save(ProductionEstimateDefault)
                    ProductionEstimateDefault.ClientOrDefault = 1
                    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                End If

                If EstimateFormatType = EstimateFormatTypes.ClientDefault Then

                    If String.IsNullOrWhiteSpace(ProductCode) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).Where(Function(Entity) Entity.CDP = ProductCode).ToList

                    ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 2).ToList

                        If EstimatePrintingSettings.Count = 0 Then

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 1).ToList

                        End If

                    Else

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).ToList

                    End If

                ElseIf EstimateFormatType = EstimateFormatTypes.UserDefault Then

                    If String.IsNullOrWhiteSpace(UserID) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).Where(Function(Entity) Entity.UserID = UserID).ToList

                    Else

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, EstimateFormatType).ToList

                    End If

                ElseIf EstimateFormatType = EstimateFormatTypes.Agency Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                    If EstimateDefault Is Nothing Then

                        EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)
                        ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting
                        EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                        EstimatePrintingSetting.Save(ProductionEstimateDefault)
                        ProductionEstimateDefault.ClientOrDefault = 1
                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                    End If

                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting
                    EstimatePrintingSetting.Save(EstimatePrintSetting)

                    EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)({EstimatePrintingSetting})

                ElseIf EstimateFormatType = EstimateFormatTypes.OneTime Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

                    If EstimateDefault Is Nothing Then

                        EstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                    End If

                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting
                    EstimatePrintingSetting.Save(EstimatePrintSetting)

                    EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)({EstimatePrintingSetting})

                End If

            End If

            LoadEstimatePrintingSettings = EstimatePrintingSettings

        End Function
        Public Function LoadEstimatePrintingSettingsWebvantage(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, EstimateFormatType As String, Optional ClientCode As String = Nothing, Optional ProductCode As String = Nothing, Optional ByVal UserID As String = Nothing) As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            'objects
            Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
            Dim EstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionEstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

                EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                If EstimateDefault Is Nothing Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)
                    ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting
                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintingSetting.Save(ProductionEstimateDefault)
                    ProductionEstimateDefault.ClientOrDefault = 1
                    AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                End If

                If EstimateFormatType = "Client" Then

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 2).ToList

                        If EstimatePrintingSettings.Count = 0 Then

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 1).ToList

                        End If

                    Else

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).ToList

                    End If

                ElseIf EstimateFormatType = "Product" Then

                    If String.IsNullOrWhiteSpace(ProductCode) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).Where(Function(Entity) Entity.CDP = ProductCode).ToList

                    ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 2).ToList

                        If EstimatePrintingSettings.Count = 0 Then

                            EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.Type = 1).ToList

                        End If

                    Else

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 1).ToList

                    End If

                ElseIf EstimateFormatType = "User" Then

                    If String.IsNullOrWhiteSpace(UserID) = False Then

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 2).Where(Function(Entity) Entity.UserID = UserID).ToList

                    Else

                        EstimatePrintingSettings = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, 2).ToList

                    End If

                ElseIf EstimateFormatType = "Agency" Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

                    If EstimateDefault Is Nothing Then

                        EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)
                        ProductionEstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting
                        EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                        EstimatePrintingSetting.Save(ProductionEstimateDefault)
                        ProductionEstimateDefault.ClientOrDefault = 1
                        AdvantageFramework.Database.Procedures.EstimatePrintingSetting.Insert(DataContext, ProductionEstimateDefault)

                    End If

                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting
                    EstimatePrintingSetting.Save(EstimatePrintSetting)

                    EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)({EstimatePrintingSetting})

                ElseIf EstimateFormatType = "OneTime" Then

                    EstimateDefault = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

                    If EstimateDefault Is Nothing Then

                        EstimateDefault = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

                    End If

                    EstimatePrintingSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting(EstimateDefault)
                    EstimatePrintSetting = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting
                    EstimatePrintingSetting.Save(EstimatePrintSetting)

                    EstimatePrintingSettings = New Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)({EstimatePrintingSetting})

                End If

            End If

            LoadEstimatePrintingSettingsWebvantage = EstimatePrintingSettings

        End Function
        'Public Function LoadEstimatePrintingSettings(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, EstimateFormatType As EstimateFormatTypes, Optional ClientCode As String = Nothing, Optional DivisionCode As String = Nothing, Optional ProductCode As String = Nothing, Optional ByVal UserID As String = Nothing) As AdvantageFramework.Database.Entities.EstimatePrintingSetting

        '    'objects
        '    Dim EstimatePrintingSettings As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting) = Nothing
        '    Dim EstimateDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        '    Dim EstimateSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        '    Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        '    Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

        '    If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

        '        If EstimateFormatType = EstimateFormatTypes.ClientDefault Then

        '            If String.IsNullOrWhiteSpace(ClientCode) = False And String.IsNullOrWhiteSpace(DivisionCode) = False And String.IsNullOrWhiteSpace(ProductCode) = False Then

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientDivisionProduct(DataContext, ClientCode, DivisionCode, ProductCode)

        '                If EstimateSetting Is Nothing Then

        '                    EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientCode(DataContext, ClientCode)

        '                End If

        '                If EstimateSetting IsNot Nothing AndAlso EstimateSetting.UseAgencySetting = 1 Then

        '                    EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

        '                End If

        '            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingClientCode(DataContext, ClientCode)

        '                If EstimateSetting IsNot Nothing AndAlso EstimateSetting.UseAgencySetting = 1 Then

        '                    EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

        '                End If

        '            Else

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

        '            End If


        '        ElseIf EstimateFormatType = EstimateFormatTypes.UserDefault Then

        '            If String.IsNullOrWhiteSpace(UserID) = False Then

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadByEstimatePrintingSettingUser(DataContext, UserID)

        '            Else

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

        '            End If

        '        ElseIf EstimateFormatType = EstimateFormatTypes.Agency Then

        '            EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadAgencyDefault(DataContext)

        '            If EstimateSetting Is Nothing Then

        '                EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

        '            End If

        '        ElseIf EstimateFormatType = EstimateFormatTypes.OneTime Then

        '            EstimateSetting = AdvantageFramework.Database.Procedures.EstimatePrintingSetting.LoadOneTimeSettings(DataContext)

        '            If EstimateSetting Is Nothing Then

        '                EstimateSetting = New AdvantageFramework.Database.Entities.EstimatePrintingSetting

        '            End If

        '        End If

        '    End If

        '    LoadEstimatePrintingSettings = EstimateSetting

        'End Function
        Public Function LoadEstimatePrintingSettingsWV(DbContext As AdvantageFramework.Database.DbContext, IsOneTime As Boolean, UserCode As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting)
            Try

                Dim IsOneTimeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@IsOneTime", IsOneTime)
                Dim UserParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserID", UserCode)
                LoadEstimatePrintingSettingsWV = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting)("EXEC dbo.advsp_estimate_printing_settings_wv @IsOneTime, @UserID", IsOneTimeParameter, UserParameter)

            Catch ex As Exception
                LoadEstimatePrintingSettingsWV = Nothing
            End Try

        End Function
        Public Function LoadEstimateFooter(DbContext As AdvantageFramework.Database.DbContext, EstimateNumber As Integer, EstimateComponentNumber As Integer, UserCode As String, ByRef FooterType As String, ByRef FooterFont As Integer) As String
            Try
                Dim DataTable As System.Data.DataTable = Nothing
                Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
                Dim StandardComments As Generic.List(Of AdvantageFramework.Database.Entities.StandardComment) = Nothing

                Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
                Dim OfficeCode As String = ""
                Dim JobNumber As Integer = 0
                Dim StandardFooterComments As String = Nothing

                Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                Dim Footer As String = ""
                'Dim FooterFont As Integer
                Dim FFont As String = "<span style=""font-family: Arial; font-size: 8.25pt;"">"
                Dim FFont2 As String = "</span>"
                Try

                    Using SqlCommand = DbContext.CreateCommand()

                        DataTable = New System.Data.DataTable

                        SqlCommand.CommandType = CommandType.StoredProcedure
                        SqlCommand.CommandText = "usp_wv_Estimating_Data"

                        SqlCommand.Parameters.AddWithValue("EstNo", EstimateNumber)
                        SqlCommand.Parameters.AddWithValue("EstCompNo", EstimateComponentNumber)
                        SqlCommand.Parameters.AddWithValue("JobNo", 0)
                        SqlCommand.Parameters.AddWithValue("JobCompNo", 0)
                        SqlCommand.Parameters.AddWithValue("UserID", UserCode)

                        SqlCommand.Connection.Open()

                        Try

                            DataTable.Load(SqlCommand.ExecuteReader)

                        Catch ex As Exception
                            DataTable = Nothing
                        Finally
                            SqlCommand.Connection.Close()
                        End Try

                    End Using

                Catch ex As Exception

                End Try

                If DataTable.Rows.Count > 0 Then

                    If IsDBNull(DataTable.Rows(0)("JOB_NUMBER")) = False Then
                        JobNumber = DataTable.Rows(0)("JOB_NUMBER")
                    End If

                    StandardComments = AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Estimates").ToList

                    If StandardComments IsNot Nothing AndAlso StandardComments.Count > 0 Then
                        If JobNumber > 0 Then
                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                            OfficeCode = Job.OfficeCode
                        Else
                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, DataTable.Rows(0)("CL_CODE").ToString, DataTable.Rows(0)("DIV_CODE").ToString, DataTable.Rows(0)("PRD_CODE").ToString)
                            OfficeCode = Product.OfficeCode
                        End If

                        For Each ClientComment In StandardComments
                            If OfficeCode = ClientComment.OfficeCode And DataTable.Rows(0)("CL_CODE").ToString = ClientComment.ClientCode Then
                                StandardFooterComments &= ClientComment.Comment
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next

                        If StandardComment Is Nothing Then
                            For Each ClientComment In StandardComments
                                If OfficeCode = ClientComment.OfficeCode And ClientComment.ClientCode Is Nothing Then
                                    StandardFooterComments &= ClientComment.Comment
                                    StandardComment = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                        If StandardComment Is Nothing Then
                            For Each ClientComment In StandardComments
                                If ClientComment.OfficeCode Is Nothing And DataTable.Rows(0)("CL_CODE").ToString = ClientComment.ClientCode Then
                                    StandardFooterComments &= ClientComment.Comment
                                    StandardComment = ClientComment
                                    Exit For
                                End If
                            Next
                        End If

                    End If

                    If StandardComment Is Nothing Then
                        For Each ClientComment In StandardComments
                            If ClientComment.ClientCode Is Nothing And ClientComment.OfficeCode Is Nothing Then
                                StandardFooterComments &= ClientComment.Comment
                                StandardComment = ClientComment
                                Exit For
                            End If
                        Next
                    End If

                    If IsDBNull(DataTable.Rows(0)("EST_FTR_COMMENT_HTML")) = False Then

                        If DataTable.Rows(0)("EST_FTR_COMMENT_HTML").ToString() = "Standard Comment" Then

                            If StandardComment IsNot Nothing Then

                                Footer = StandardComment.Comment
                                FooterFont = StandardComment.FontSize.GetValueOrDefault(0)
                                FooterType = "Standard Comment"

                            Else
                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                                Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                                FooterFont = 0
                                FooterType = "Agency Defined"

                            End If

                        ElseIf DataTable.Rows(0)("EST_FTR_COMMENT_HTML").ToString() = "Agency Defined" Then
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                            Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                            FooterFont = 0
                            FooterType = "Agency Defined"
                        Else

                            Footer = FFont & DataTable.Rows(0)("EST_FTR_COMMENT_HTML") & FFont2
                            FooterFont = 0

                        End If



                    ElseIf IsDBNull(DataTable.Rows(0)("EST_FTR_COMMENT")) = False Then

                        If DataTable.Rows(0)("EST_FTR_COMMENT").ToString() = "Standard Comment" Then

                            If StandardComment IsNot Nothing Then

                                Footer = StandardComment.Comment
                                FooterFont = StandardComment.FontSize.GetValueOrDefault(0)
                                FooterType = "Standard Comment"

                            Else
                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                                Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                                FooterFont = 0
                                FooterType = "Agency Defined"

                            End If

                        ElseIf DataTable.Rows(0)("EST_FTR_COMMENT").ToString() = "Agency Defined" Then
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                            Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                            FooterFont = 0
                            FooterType = "Agency Defined"
                        Else

                            Footer = DataTable.Rows(0)("EST_FTR_COMMENT")
                            FooterFont = 0

                        End If

                    Else

                        If StandardComment IsNot Nothing Then

                            Footer = StandardComment.Comment
                            FooterFont = StandardComment.FontSize.GetValueOrDefault(0)
                            FooterType = "Standard Comment"

                        Else
                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                            Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                            FooterFont = 0
                            FooterType = "Agency Defined"

                        End If

                    End If

                Else

                    If StandardComment IsNot Nothing Then

                        Footer = StandardComment.Comment
                        FooterFont = StandardComment.FontSize.GetValueOrDefault(0)
                        FooterType = "Standard Comment"

                    Else
                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        Footer = Agency.EstimateDefaultComments 'oReports.GetAgencyEstComment()
                        FooterFont = 0
                        FooterType = "Agency Defined"

                    End If

                End If

                LoadEstimateFooter = Footer

            Catch ex As Exception
                LoadEstimateFooter = Nothing
            End Try
        End Function

        Public Function LoadAvailableEstimateReports(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of Generic.KeyValuePair(Of Long, String))

            'objects
            Dim EstimateReportDataSetsList As Generic.List(Of Generic.KeyValuePair(Of Long, String)) = Nothing

            EstimateReportDataSetsList = New Generic.List(Of Generic.KeyValuePair(Of Long, String))

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Estimate.Printing.ReportFormats)).OrderBy(Function(KeyValue) KeyValue.Value)

                    'If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, _PreDynamicReportModuleCode & KeyValuePair.Value.Replace(" ", "") & "DRPT", Session.User.ID) Then

                    EstimateReportDataSetsList.Add(KeyValuePair)

                    ' End If

                Next

            End Using

            LoadAvailableEstimateReports = EstimateReportDataSetsList

        End Function

        Public Function LoadEstimateQuotes(DbContext As AdvantageFramework.Database.DbContext, UserCode As String, StartDate As Date, EndDate As Date) As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)

            'objects
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            Try

                EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_load] '{0}', '{1}', '{2}'",
                                                                                                                                                                  UserCode, StartDate.ToShortDateString, EndDate.ToShortDateString)).ToList

            Catch ex As Exception
                EstimateQuotes = Nothing
            End Try

            LoadEstimateQuotes = EstimateQuotes

        End Function
#End Region

    End Module

End Namespace
