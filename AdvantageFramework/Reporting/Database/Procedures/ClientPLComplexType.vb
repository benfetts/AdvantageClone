Namespace Reporting.Database.Procedures.ClientPLComplexType

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

        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object)) As Generic.List(Of Database.Classes.ClientPL)

            Load = Load(ReportingDbContext, ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCREntries.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.OverheadSet.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.UserId.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.DirectExpenseFromExpenseOperatingOnly.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedClients.ToString), ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedDivisions.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedProducts.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod1Code.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod1Code.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod2Code.ToString),
                        ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod2Code.ToString)).ToList

        End Function
        Public Function Load(ByVal ReportingDbContext As Reporting.Database.DbContext, ByVal StartingPostPeriodCode As String,
                             ByVal EndingPostPeriodCode As String, ByVal Type As Integer, ByVal IncludeOffice As Boolean,
                             ByVal IncludeClient As Boolean, ByVal IncludeDivision As Boolean, ByVal IncludeProduct As Boolean,
                             ByVal IncludeType As Boolean, ByVal IncludeSalesClass As Boolean, ByVal IncludePostPeriod As Boolean,
                             ByVal IncludeYear As Boolean, ByVal IncludeCampaign As Boolean, ByVal IncludeManualInvoices As Boolean,
                             ByVal IncludeGLEntries As Boolean, ByVal IncludeBilledIncomeRecognized As Boolean, ByVal IncludeCREntries As Boolean,
                             ByVal IncludeAE As Boolean, ByVal IncludeProductUDF As Boolean,
                             ByVal CoopOption As Integer, ByVal HoursCost As Integer, ByVal FTEAllocation As Integer,
                             ByVal OverheadSet As String, ByVal UserId As String, ByVal ExcludeNewBusiness As Boolean,
                             ByVal DirectExpenseFromExpenseOperatingOnly As Boolean, ByVal SelectedOffices As Generic.List(Of String),
                             ByVal SelectedClients As Generic.List(Of String), ByVal SelectedDivisions As Generic.List(Of String),
                             ByVal SelectedProducts As Generic.List(Of String),
                             ByVal StartPeriod1 As String,
                             ByVal EndPeriod1 As String,
                             ByVal StartPeriod2 As String,
                             ByVal EndPeriod2 As String) As Generic.List(Of Database.Classes.ClientPL)

            'objects
            Dim SqlParameterStartPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStandard As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeOffice As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeClient As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeDivision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeProduct As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeSalesClass As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludePostPeriod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeCampaign As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeManualInvoices As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeGLEntries As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeBilledIncomeRecognized As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeCREntries As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeAE As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeProductUDF As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCoopOption As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHoursCost As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFTEAllocation As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOverheadSet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterExcludeNewBusiness As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDirectExpenseFromExpenseOperatingOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectedOffices As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterClientCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientDivisionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientDivisionProductCodeList As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterStartPeriod1 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod1 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartPeriod2 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndPeriod2 As System.Data.SqlClient.SqlParameter = Nothing

            Dim ClientPL As Generic.List(Of Database.Classes.ClientPL)

            SqlParameterStartPeriod = New System.Data.SqlClient.SqlParameter("@StartPeriod", SqlDbType.VarChar)
            SqlParameterEndPeriod = New System.Data.SqlClient.SqlParameter("@EndPeriod", SqlDbType.VarChar)
            SqlParameterStandard = New System.Data.SqlClient.SqlParameter("@Standard", SqlDbType.Int)
            SqlParameterIncludeOffice = New System.Data.SqlClient.SqlParameter("@IncludeOffice", SqlDbType.Bit)
            SqlParameterIncludeClient = New System.Data.SqlClient.SqlParameter("@IncludeClient", SqlDbType.Bit)
            SqlParameterIncludeDivision = New System.Data.SqlClient.SqlParameter("@IncludeDivision", SqlDbType.Bit)
            SqlParameterIncludeProduct = New System.Data.SqlClient.SqlParameter("@IncludeProduct", SqlDbType.Bit)
            SqlParameterIncludeType = New System.Data.SqlClient.SqlParameter("@IncludeType", SqlDbType.Bit)
            SqlParameterIncludeSalesClass = New System.Data.SqlClient.SqlParameter("@IncludeSalesClass", SqlDbType.Bit)
            SqlParameterIncludePostPeriod = New System.Data.SqlClient.SqlParameter("@IncludePostPeriod", SqlDbType.Bit)
            SqlParameterIncludeYear = New System.Data.SqlClient.SqlParameter("@IncludeYear", SqlDbType.Bit)
            SqlParameterIncludeCampaign = New System.Data.SqlClient.SqlParameter("@IncludeCampaign", SqlDbType.Bit)
            SqlParameterIncludeAE = New System.Data.SqlClient.SqlParameter("@IncludeAE", SqlDbType.Bit)
            SqlParameterIncludeProductUDF = New System.Data.SqlClient.SqlParameter("@IncludeProductUDF", SqlDbType.Bit)
            SqlParameterIncludeManualInvoices = New System.Data.SqlClient.SqlParameter("@IncludeManualInvoices", SqlDbType.Bit)
            SqlParameterIncludeGLEntries = New System.Data.SqlClient.SqlParameter("@IncludeGLEntries", SqlDbType.Bit)
            SqlParameterIncludeBilledIncomeRecognized = New System.Data.SqlClient.SqlParameter("@IncludeBilledIncomeRec", SqlDbType.Bit)
            SqlParameterIncludeCREntries = New System.Data.SqlClient.SqlParameter("@IncludeCREntries", SqlDbType.Bit)
            SqlParameterCoopOption = New System.Data.SqlClient.SqlParameter("@CoopOption", SqlDbType.Int)
            SqlParameterHoursCost = New System.Data.SqlClient.SqlParameter("@HoursCost", SqlDbType.Int)
            SqlParameterFTEAllocation = New System.Data.SqlClient.SqlParameter("@FTEAllocation", SqlDbType.Int)
            SqlParameterOverheadSet = New System.Data.SqlClient.SqlParameter("@OverheadSet", SqlDbType.VarChar)
            SqlParameterUserId = New System.Data.SqlClient.SqlParameter("@UserId", UserId)
            SqlParameterExcludeNewBusiness = New System.Data.SqlClient.SqlParameter("@ExcludeNewBusiness", SqlDbType.Bit)
            SqlParameterDirectExpenseFromExpenseOperatingOnly = New System.Data.SqlClient.SqlParameter("@DirectExpenseOperatingOnly", SqlDbType.Bit)
            SqlParameterSelectedOffices = New System.Data.SqlClient.SqlParameter("@OFFICE_LIST", SqlDbType.VarChar)
            SqlParameterClientCodeList = New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            SqlParameterClientDivisionCodeList = New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            SqlParameterClientDivisionProductCodeList = New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)

            SqlParameterStartPeriod1 = New System.Data.SqlClient.SqlParameter("@StartPeriod1", SqlDbType.VarChar)
            SqlParameterEndPeriod1 = New System.Data.SqlClient.SqlParameter("@EndPeriod1", SqlDbType.VarChar)
            SqlParameterStartPeriod2 = New System.Data.SqlClient.SqlParameter("@StartPeriod2", SqlDbType.VarChar)
            SqlParameterEndPeriod2 = New System.Data.SqlClient.SqlParameter("@EndPeriod2", SqlDbType.VarChar)

            SqlParameterStartPeriod.Value = StartingPostPeriodCode
            SqlParameterEndPeriod.Value = EndingPostPeriodCode
            SqlParameterStandard.Value = Type
            SqlParameterIncludeOffice.Value = IncludeOffice
            SqlParameterIncludeClient.Value = IncludeClient
            SqlParameterIncludeDivision.Value = IncludeDivision
            SqlParameterIncludeProduct.Value = IncludeProduct
            SqlParameterIncludeType.Value = IncludeType
            SqlParameterIncludeSalesClass.Value = IncludeSalesClass
            SqlParameterIncludePostPeriod.Value = IncludePostPeriod
            SqlParameterIncludeYear.Value = IncludeYear
            SqlParameterIncludeCampaign.Value = IncludeCampaign
            SqlParameterIncludeManualInvoices.Value = IncludeManualInvoices
            SqlParameterIncludeGLEntries.Value = IncludeGLEntries
            SqlParameterIncludeBilledIncomeRecognized.Value = IncludeBilledIncomeRecognized
            SqlParameterIncludeCREntries.Value = IncludeCREntries
            SqlParameterIncludeAE.Value = IncludeAE
            SqlParameterIncludeProductUDF.Value = IncludeProductUDF
            SqlParameterCoopOption.Value = CoopOption
            SqlParameterHoursCost.Value = HoursCost
            SqlParameterFTEAllocation.Value = FTEAllocation
            SqlParameterOverheadSet.Value = OverheadSet
            SqlParameterUserId.Value = UserId
            SqlParameterExcludeNewBusiness.Value = ExcludeNewBusiness
            SqlParameterDirectExpenseFromExpenseOperatingOnly.Value = DirectExpenseFromExpenseOperatingOnly

            If StartPeriod1 Is Nothing And StartPeriod2 IsNot Nothing Then
                StartPeriod1 = StartPeriod2
            End If
            If EndPeriod1 Is Nothing And EndPeriod2 IsNot Nothing Then
                EndPeriod1 = EndPeriod2
            End If

            If StartPeriod1 IsNot Nothing And EndPeriod1 Is Nothing Then
                EndPeriod1 = StartPeriod1
            End If
            If EndPeriod1 IsNot Nothing And StartPeriod1 Is Nothing Then
                StartPeriod1 = EndPeriod1
            End If
            If StartPeriod2 IsNot Nothing And EndPeriod2 Is Nothing Then
                EndPeriod2 = StartPeriod2
            End If
            If EndPeriod2 IsNot Nothing And StartPeriod2 Is Nothing Then
                StartPeriod2 = EndPeriod2
            End If

            SqlParameterStartPeriod1.Value = StartPeriod1
            SqlParameterEndPeriod1.Value = EndPeriod1
            SqlParameterStartPeriod2.Value = StartPeriod2
            SqlParameterEndPeriod2.Value = EndPeriod2

            If SqlParameterStartPeriod1.Value = Nothing Then
                SqlParameterStartPeriod1.Value = System.DBNull.Value
            End If
            If SqlParameterEndPeriod1.Value = Nothing Then
                SqlParameterEndPeriod1.Value = System.DBNull.Value
            End If
            If SqlParameterStartPeriod2.Value = Nothing Then
                SqlParameterStartPeriod2.Value = System.DBNull.Value
            End If
            If SqlParameterEndPeriod2.Value = Nothing Then
                SqlParameterEndPeriod2.Value = System.DBNull.Value
            End If

            If SelectedOffices Is Nothing Then

                SqlParameterSelectedOffices.Value = System.DBNull.Value

            ElseIf SelectedOffices.Count = 0 Then

                SqlParameterSelectedOffices.Value = System.DBNull.Value

            Else

                SqlParameterSelectedOffices.Value = Join(SelectedOffices.ToArray, ",")

            End If

            If SelectedClients Is Nothing Then

                SqlParameterClientCodeList.Value = System.DBNull.Value

            ElseIf SelectedClients.Count = 0 Then

                SqlParameterClientCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientCodeList.Value = Join(SelectedClients.ToArray, ",")

            End If

            If SelectedDivisions Is Nothing Then

                SqlParameterClientDivisionCodeList.Value = System.DBNull.Value

            ElseIf SelectedDivisions.Count = 0 Then

                SqlParameterClientDivisionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientDivisionCodeList.Value = Join(SelectedDivisions.ToArray, ",")

            End If

            If SelectedProducts Is Nothing Then

                SqlParameterClientDivisionProductCodeList.Value = System.DBNull.Value

            ElseIf SelectedProducts.Count = 0 Then

                SqlParameterClientDivisionProductCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientDivisionProductCodeList.Value = Join(SelectedProducts.ToArray, ",")

            End If


            ClientPL = ReportingDbContext.Database.SqlQuery(Of Database.Classes.ClientPL)("EXEC dbo.usp_wv_Gross_Income_CPL @StartPeriod, @EndPeriod, @Standard, @IncludeOffice, @IncludeClient, @IncludeDivision, @IncludeProduct, @IncludeType, @IncludeSalesClass, @IncludePostPeriod, @IncludeYear, @IncludeCampaign, @IncludeAE, @IncludeProductUDF, @IncludeManualInvoices, @IncludeGLEntries, @IncludeBilledIncomeRec, @IncludeCREntries, @CoopOption, @HoursCost, @FTEAllocation, @OverheadSet, @UserId, @ExcludeNewBusiness, @DirectExpenseOperatingOnly, @OFFICE_LIST, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @StartPeriod1, @EndPeriod1, @StartPeriod2, @EndPeriod2",
                                                                                        SqlParameterStartPeriod, SqlParameterEndPeriod, SqlParameterStandard, SqlParameterIncludeOffice, SqlParameterIncludeClient, SqlParameterIncludeDivision,
                                                                                        SqlParameterIncludeProduct, SqlParameterIncludeType, SqlParameterIncludeSalesClass, SqlParameterIncludePostPeriod, SqlParameterIncludeYear,
                                                                                        SqlParameterIncludeCampaign, SqlParameterIncludeManualInvoices, SqlParameterIncludeGLEntries, SqlParameterIncludeBilledIncomeRecognized, SqlParameterIncludeCREntries,
                                                                                        SqlParameterIncludeAE, SqlParameterIncludeProductUDF, SqlParameterCoopOption, SqlParameterHoursCost, SqlParameterFTEAllocation, SqlParameterOverheadSet,
                                                                                        SqlParameterUserId, SqlParameterExcludeNewBusiness, SqlParameterDirectExpenseFromExpenseOperatingOnly, SqlParameterSelectedOffices, SqlParameterClientCodeList, SqlParameterClientDivisionCodeList, SqlParameterClientDivisionProductCodeList,
                                                                                        SqlParameterStartPeriod1, SqlParameterEndPeriod1, SqlParameterStartPeriod2, SqlParameterEndPeriod2).ToList

            Load = ClientPL

        End Function

#End Region

    End Module

End Namespace
