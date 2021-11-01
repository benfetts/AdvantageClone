Namespace Database.Procedures.ExportDataComplexType

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

        'Public Function Load(ByVal DbContext As Database.DbContext, ByVal IncludeVendorData As Boolean,
        '                     ByVal IncludeTVOrderData As Boolean, ByVal IncludeRadOrderData As Boolean, ByVal IncludeNewsOrderData As Boolean,
        '                     ByVal IncludeOohOorderData As Boolean, ByVal IncludeMagOrderData As Boolean, ByVal IncludeInetOrderData As Boolean,
        '                     ByVal IncludeProdPOData As Boolean, ByVal IncludeAcctPayData As Boolean, ByVal IncludeEapPmtHistData As Boolean,
        '                     ByVal IncludejobData As Boolean, ByVal VendorCategories As String, ByVal ClientCodes As String,
        '                     ByVal CampaignCoces As String, ByVal CreatedDateStart As Date, ByVal CreatedDateEnd As Date,
        '                     ByVal ModifiedDateStart As Date, ByVal ModifiedDateEnd As Date, ByVal IncludeColumnTitles As Boolean,
        '                     ByRef ReturnValue As Integer) As System.Collections.Generic.List(Of Database.Classes.ExportData)

        '    'objects
        '    Dim IncludeVendorDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeTVOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeRadOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeNewsOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeOohOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeMagOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeInetOrderDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeProdPODataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeAcctPayDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeEapPmtHistDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludejobDataObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim VendorCategoriesObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim ClientCodesObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim CampaignCocesObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim CreatedDateStartObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim CreatedDateEndObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim ModifiedDateStartObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim ModifiedDateEndObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim IncludeColumnTitlesObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
        '    Dim ReturnValueObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

        '    IncludeVendorDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("vendor_data", IncludeVendorData)
        '    IncludeTVOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("tv_order_data", IncludeTVOrderData)
        '    IncludeRadOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("rad_order_data", IncludeRadOrderData)
        '    IncludeNewsOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("news_order_data", IncludeNewsOrderData)
        '    IncludeOohOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ooh_order_data", IncludeOohOorderData)
        '    IncludeMagOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("mag_order_data", IncludeMagOrderData)
        '    IncludeInetOrderDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("inet_order_data", IncludeInetOrderData)
        '    IncludeProdPODataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("prod_po_data", IncludeProdPOData)
        '    IncludeAcctPayDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("acct_pay_data", IncludeAcctPayData)
        '    IncludeEapPmtHistDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ap_pmt_hist_data", IncludeEapPmtHistData)
        '    IncludejobDataObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("job_data", IncludejobData)
        '    VendorCategoriesObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("vn_category_in", VendorCategories)
        '    ClientCodesObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("cli_list", ClientCodes)
        '    CampaignCocesObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("cmp_list", CampaignCoces)
        '    CreatedDateStartObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("create_date_start", CreatedDateStart)
        '    CreatedDateEndObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("create_date_end", CreatedDateEnd)
        '    ModifiedDateStartObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("modified_date_start", ModifiedDateStart)
        '    ModifiedDateEndObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("modified_date_end", ModifiedDateEnd)
        '    IncludeColumnTitlesObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("inc_col_titles", IncludeColumnTitles)
        '    ReturnValueObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ret_val", ReturnValue)

        '    Load = DbContext.ExecuteFunction(Of Database.Classes.ExportData)("LoadExportData", IncludeVendorDataObjectParameter, IncludeTVOrderDataObjectParameter,
        '                                                                                                IncludeRadOrderDataObjectParameter, IncludeNewsOrderDataObjectParameter,
        '                                                                                                IncludeOohOrderDataObjectParameter, IncludeMagOrderDataObjectParameter,
        '                                                                                                IncludeInetOrderDataObjectParameter, IncludeProdPODataObjectParameter,
        '                                                                                                IncludeAcctPayDataObjectParameter, IncludeEapPmtHistDataObjectParameter,
        '                                                                                                IncludejobDataObjectParameter, VendorCategoriesObjectParameter,
        '                                                                                                ClientCodesObjectParameter, CampaignCocesObjectParameter,
        '                                                                                                CreatedDateStartObjectParameter, CreatedDateEndObjectParameter,
        '                                                                                                ModifiedDateStartObjectParameter, ModifiedDateEndObjectParameter,
        '                                                                                                IncludeColumnTitlesObjectParameter, ReturnValueObjectParameter)

        '    ReturnValue = ReturnValueObjectParameter.Value

        'End Function
        Public Function Load(DbContext As Database.DbContext, IncludeVendorData As Boolean,
                             IncludeTVOrderData As Boolean, IncludeRadOrderData As Boolean, IncludeNewsOrderData As Boolean,
                             IncludeOohOorderData As Boolean, IncludeMagOrderData As Boolean, IncludeInetOrderData As Boolean,
                             IncludeProdPOData As Boolean, IncludeAcctPayData As Boolean, IncludeEapPmtHistData As Boolean,
                             IncludejobData As Boolean, VendorCategories As String, ClientCodes As String,
                             CampaignCoces As String, CreatedDateStart As Date, CreatedDateEnd As Date,
                             ModifiedDateStart As Date, ModifiedDateEnd As Date, IncludeColumnTitles As Boolean,
                             ByRef ReturnValue As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.ExportData)

            'objects
            Dim SqlParameterVendorData As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTV As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOutdoor As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProduction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAccoutPayable As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPPaymentHistory As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobData As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVendorCategory As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignCodes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCreatedDateStart As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCreatedDateEnd As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterModifiedDateStart As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterModifiedDateEnd As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeColumnTitles As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterVendorData = New System.Data.SqlClient.SqlParameter("@vendor_data", SqlDbType.Bit)
            SqlParameterTV = New System.Data.SqlClient.SqlParameter("@tv_order_data", SqlDbType.Bit)
            SqlParameterRadio = New System.Data.SqlClient.SqlParameter("@rad_order_data", SqlDbType.Bit)
            SqlParameterNewspaper = New System.Data.SqlClient.SqlParameter("@news_order_data", SqlDbType.Bit)
            SqlParameterOutdoor = New System.Data.SqlClient.SqlParameter("@ooh_order_data", SqlDbType.Bit)
            SqlParameterMagazine = New System.Data.SqlClient.SqlParameter("@mag_order_data", SqlDbType.Bit)
            SqlParameterInternet = New System.Data.SqlClient.SqlParameter("@inet_order_data", SqlDbType.Bit)
            SqlParameterProduction = New System.Data.SqlClient.SqlParameter("@prod_po_data", SqlDbType.Bit)
            SqlParameterAccoutPayable = New System.Data.SqlClient.SqlParameter("@acct_pay_data", SqlDbType.Bit)
            SqlParameterAPPaymentHistory = New System.Data.SqlClient.SqlParameter("@ap_pmt_hist_data", SqlDbType.Bit)
            SqlParameterJobData = New System.Data.SqlClient.SqlParameter("@job_data", SqlDbType.Bit)
            SqlParameterVendorCategory = New System.Data.SqlClient.SqlParameter("@vn_category_in", SqlDbType.VarChar)
            SqlParameterClientCodes = New System.Data.SqlClient.SqlParameter("@cli_list", SqlDbType.VarChar)
            SqlParameterCampaignCodes = New System.Data.SqlClient.SqlParameter("@cmp_list", SqlDbType.VarChar)
            SqlParameterCreatedDateStart = New System.Data.SqlClient.SqlParameter("@create_date_start", SqlDbType.SmallDateTime)
            SqlParameterCreatedDateEnd = New System.Data.SqlClient.SqlParameter("@create_date_end", SqlDbType.SmallDateTime)
            SqlParameterModifiedDateStart = New System.Data.SqlClient.SqlParameter("@modified_date_start", SqlDbType.SmallDateTime)
            SqlParameterModifiedDateEnd = New System.Data.SqlClient.SqlParameter("@modified_date_end", SqlDbType.SmallDateTime)
            SqlParameterIncludeColumnTitles = New System.Data.SqlClient.SqlParameter("@inc_col_titles", SqlDbType.Bit)
            SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterReturnValue.Direction = ParameterDirection.Output

            SqlParameterVendorData.Value = IncludeVendorData
            SqlParameterTV.Value = IncludeTVOrderData
            SqlParameterRadio.Value = IncludeRadOrderData
            SqlParameterNewspaper.Value = IncludeNewsOrderData
            SqlParameterOutdoor.Value = IncludeOohOorderData
            SqlParameterMagazine.Value = IncludeMagOrderData
            SqlParameterInternet.Value = IncludeInetOrderData
            SqlParameterProduction.Value = IncludeProdPOData
            SqlParameterAccoutPayable.Value = IncludeAcctPayData
            SqlParameterAPPaymentHistory.Value = IncludeEapPmtHistData
            SqlParameterJobData.Value = IncludejobData
            SqlParameterVendorCategory.Value = VendorCategories
            SqlParameterClientCodes.Value = ClientCodes
            SqlParameterCampaignCodes.Value = CampaignCoces
            SqlParameterCreatedDateStart.Value = CreatedDateStart
            SqlParameterCreatedDateEnd.Value = CreatedDateEnd
            SqlParameterModifiedDateStart.Value = ModifiedDateStart
            SqlParameterModifiedDateEnd.Value = ModifiedDateEnd
            SqlParameterIncludeColumnTitles.Value = IncludeColumnTitles
            SqlParameterReturnValue.Value = 0

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ExportData)("EXEC dbo.advsp_csv_export @vendor_data, @tv_order_data, @rad_order_data, @news_order_data, @ooh_order_data, @mag_order_data, @inet_order_data, @prod_po_data, @acct_pay_data, @ap_pmt_hist_data, @job_data, @vn_category_in, @cli_list, @cmp_list, @create_date_start, @create_date_end, @modified_date_start, @modified_date_end, @inc_col_titles, @ret_val",
                SqlParameterVendorData, SqlParameterTV, SqlParameterRadio, SqlParameterNewspaper, SqlParameterOutdoor, SqlParameterMagazine, SqlParameterInternet, SqlParameterProduction,
                SqlParameterAccoutPayable, SqlParameterAPPaymentHistory, SqlParameterJobData, SqlParameterVendorCategory, SqlParameterClientCodes, SqlParameterCampaignCodes, SqlParameterCreatedDateStart,
                SqlParameterCreatedDateEnd, SqlParameterModifiedDateStart, SqlParameterModifiedDateEnd, SqlParameterIncludeColumnTitles, SqlParameterReturnValue).ToList

            ReturnValue = SqlParameterReturnValue.Value

        End Function

#End Region

    End Module

End Namespace
