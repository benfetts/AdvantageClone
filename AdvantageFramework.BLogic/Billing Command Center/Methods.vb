Namespace BillingCommandCenter

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MediaDateToUse
            SelectMediaByDateToBill = 1
            SelectMediaByDate = 2
            SelectMediaByJobOrMediaDateToBill = 3
        End Enum

        Public Enum ProductionBillHoldStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Clear")>
            Clear = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Temporary")>
            Temporary_Job = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Permanent")>
            Permanent_Job = 2
        End Enum

        Public Enum ProductionReconcileStatus
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Interim Reconcile All")>
            Interim_Reconcile_All = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Interim Reconcile Approved")>
            Interim_Reconcile_Approved = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Final Reconcile to Actual & Bill")>
            Final_Reconcile_To_Actual = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Final Reconcile to Quote & Bill")>
            Final_Reconcile_To_Quote = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Final Reconcile to Billed")>
            Final_Reconcile_To_Billed = 5
        End Enum

        Public Enum TransferEmployeeTimeBillingRate
            RecalculateFromHierarchy = 1
            TransferAsIs = 2
        End Enum

        Public Enum TransferMarkupPercent
            RecalculateFromHierarchy = 1
            TransferAsIs = 2
        End Enum

        Public Enum BillStatus
            ProgressBill = 1
            AdvanceBill = 2
            JobOnPermanentBillHold = 3
            JobOnTemporaryBillHold = 4
            JobDetailsOnHold = 5
            Reconciled = 6
        End Enum

        Public Enum ProductionSelectFor As Short
            Transfer = 1
            Reconcile = 2
            BCCJobDetailGrid = 3
        End Enum

        Public Enum IncomeOnlySelectFor As Short
            Transfer = 1
            Reconcile = 2
            BCCJobDetailGrid = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region "  Billing Command Center "

        Public Function DeleteBillingSelection(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingUser As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.Output

            SqlParameterBillingUser.Value = BillingUser

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_bill_select_delete @billing_user, @ret_val OUTPUT", SqlParameterBillingUser, SqlParameterRetVal)

            DeleteBillingSelection = SqlParameterRetVal.Value

        End Function
        Public Sub DeleteMediaSelection(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer, ByVal BillingUser As String)

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_delete_billing_cmd_center_media '{0}', 0", BillingUser))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.W_AR_FUNCTION WHERE BILLING_USER = '{0}'", BillingUser))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_bcc_clear_billing_user {0}, '{1}', {2}, {3}, 0", BillingCommandCenterID, BillingUser, 0, 1))

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    BillingCommandCenter.IsMedia = False
                    BillingCommandCenter.MediaSelectBy = Nothing
                    BillingCommandCenter.MediaEndDate = Nothing
                    BillingCommandCenter.IsNewspaper = False
                    BillingCommandCenter.IsMagazine = False
                    BillingCommandCenter.IsRadio = False
                    BillingCommandCenter.IsTelevision = False
                    BillingCommandCenter.IsOutOfHome = False
                    BillingCommandCenter.IsInternet = False
                    BillingCommandCenter.MediaBroadcastMonthStart = Nothing
                    BillingCommandCenter.MediaBroadcastMonthEnd = Nothing
                    BillingCommandCenter.IncludeZeroSpots = Nothing

                    BillingCommandCenter.MediaStartDate = Nothing
                    BillingCommandCenter.DateCuttoffToUseFlag = Nothing
                    BillingCommandCenter.IncludeUnbilledOrdersOnly = Nothing
                    BillingCommandCenter.IsRadioDaily = Nothing
                    BillingCommandCenter.IsTelevisionDaily = Nothing
                    BillingCommandCenter.IsRadioMonthly = Nothing
                    BillingCommandCenter.IsTelevisionMonthly = Nothing

                    AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Update(BCCDbContext, BillingCommandCenter)

                End If

            End Using

        End Sub
        Public Sub DeleteProductionSelection(ByVal Session As AdvantageFramework.Security.Session, ByVal BillingCommandCenterID As Integer, ByVal BillingUser As String)

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_clear_temp_bill_hold {0}, 0, 0", BillingCommandCenterID))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_delete_billing_cmd_center_prod '{0}', 0", BillingUser))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.W_AR_FUNCTION WHERE BILLING_USER = '{0}'", BillingUser))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_bcc_clear_billing_user {0}, '{1}', 1, 0, 0", BillingCommandCenterID, BillingUser))

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    BillingCommandCenter.ProductionSelectBy = Nothing
                    BillingCommandCenter.IsProduction = False
                    BillingCommandCenter.EmployeeTimeDateCutoff = Nothing
                    BillingCommandCenter.IncomeOnlyDateCutoff = Nothing
                    BillingCommandCenter.APPostPeriodCodeCutoff = Nothing
                    BillingCommandCenter.BillingApprovalBatchID = Nothing
                    BillingCommandCenter.ProductionSelectionOption = Nothing

                    AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.Update(BCCDbContext, BillingCommandCenter)

                End If

            End Using

        End Sub
        Public Function PopulateARFunction(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingUser As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user_in", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.Output

            SqlParameterBillingUser.Value = BillingUser

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_bcc_populate_ar_function @billing_user_in, @ret_val OUTPUT", SqlParameterBillingUser, SqlParameterRetVal)

            PopulateARFunction = SqlParameterRetVal.Value

        End Function
        Public Function PopulateARCoopTmp(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingUser As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.Output

            SqlParameterBillingUser.Value = BillingUser

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_ar_np_coop_bill @billing_user, @ret_val OUTPUT", SqlParameterBillingUser, SqlParameterRetVal)

            PopulateARCoopTmp = SqlParameterRetVal.Value

        End Function
        Public Sub UpdateMediaSelection(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer, ByVal BillingUser As String,
                                        ByVal SelectBy As Integer, ByVal CampaignIDs As IEnumerable(Of Integer), ByVal ClientCodes As IEnumerable(Of String), ByVal DivisionCodes As IEnumerable(Of String), ByVal ProductCodes As IEnumerable(Of String),
                                        ByVal OrderNumbers As IEnumerable(Of Integer), ByVal OrderLineNumbers As IEnumerable(Of String), ByVal ClientPOs As IEnumerable(Of String), ByVal MarketCodes As IEnumerable(Of String), ByVal IncludeUnbilledOnly As Boolean,
                                        ByVal IncludeZeroSpots As Boolean, ByVal DateToUse As Short, ByVal Newspaper As Boolean, ByVal Magazine As Boolean, ByVal Internet As Boolean,
                                        ByVal OutOfHome As Boolean, ByVal Radio As Boolean, ByVal RadioDaily As Boolean, ByVal RadioMonthly As Boolean, ByVal TV As Boolean, ByVal TVDaily As Boolean,
                                        ByVal TVMonthly As Boolean, ByVal MediaStartDate As Nullable(Of Date), ByVal MediaEndDate As Nullable(Of Date), ByVal BroadcastStartDate As Nullable(Of Date), ByVal BroadcastEndDate As Nullable(Of Date),
                                        ByVal IncludeLegacy As Boolean, ByVal JobMediaDateFrom As Nullable(Of Date), ByVal JobMediaDateTo As Nullable(Of Date), ByVal ClientBillers As IEnumerable(Of String))

            'objects
            Dim SqlParameterBillingCommandCenterID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignIDList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderLineNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientPOList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMarketCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeUnbilledOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeZeroSpots As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateToUse As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOutofHome As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadioDaily As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadioMonthly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevisionDaily As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevisionMonthly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeLegacy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateFrom As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateTo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientBillerList As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingCommandCenterID = New System.Data.SqlClient.SqlParameter("@bcc_id_in", SqlDbType.Int)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterSelectBy = New System.Data.SqlClient.SqlParameter("@m_select_by", SqlDbType.SmallInt)
            SqlParameterCampaignIDList = New System.Data.SqlClient.SqlParameter("@cmp_id_in_list", SqlDbType.VarChar)
            SqlParameterClientCodeList = New System.Data.SqlClient.SqlParameter("@cl_code_in_list", SqlDbType.VarChar)
            SqlParameterDivisionCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_code_in_list", SqlDbType.VarChar)
            SqlParameterProductCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_prd_code_in_list", SqlDbType.VarChar)
            SqlParameterOrderNumberList = New System.Data.SqlClient.SqlParameter("@order_number_in_list", SqlDbType.VarChar)
            SqlParameterOrderLineNumberList = New System.Data.SqlClient.SqlParameter("@order_line_number_in_list", SqlDbType.VarChar)
            SqlParameterClientPOList = New System.Data.SqlClient.SqlParameter("@client_po_in_list", SqlDbType.VarChar)
            SqlParameterMarketCodeList = New System.Data.SqlClient.SqlParameter("@market_code_in_list", SqlDbType.VarChar)
            SqlParameterIncludeUnbilledOnly = New System.Data.SqlClient.SqlParameter("@incl_unbilled_only", SqlDbType.Bit)
            SqlParameterIncludeZeroSpots = New System.Data.SqlClient.SqlParameter("@incl_zero_spots", SqlDbType.Bit)
            SqlParameterDateToUse = New System.Data.SqlClient.SqlParameter("@date_to_use", SqlDbType.SmallInt)
            SqlParameterNewspaper = New System.Data.SqlClient.SqlParameter("@newspaper", SqlDbType.Bit)
            SqlParameterMagazine = New System.Data.SqlClient.SqlParameter("@magazine", SqlDbType.Bit)
            SqlParameterInternet = New System.Data.SqlClient.SqlParameter("@internet", SqlDbType.Bit)
            SqlParameterOutofHome = New System.Data.SqlClient.SqlParameter("@out_of_home", SqlDbType.Bit)
            SqlParameterRadio = New System.Data.SqlClient.SqlParameter("@radio", SqlDbType.Bit)
            SqlParameterRadioDaily = New System.Data.SqlClient.SqlParameter("@radio_daily", SqlDbType.Bit)
            SqlParameterRadioMonthly = New System.Data.SqlClient.SqlParameter("@radio_monthly", SqlDbType.Bit)
            SqlParameterTelevision = New System.Data.SqlClient.SqlParameter("@television", SqlDbType.Bit)
            SqlParameterTelevisionDaily = New System.Data.SqlClient.SqlParameter("@tv_daily", SqlDbType.Bit)
            SqlParameterTelevisionMonthly = New System.Data.SqlClient.SqlParameter("@tv_monthly", SqlDbType.Bit)
            SqlParameterMediaStartDate = New System.Data.SqlClient.SqlParameter("@m_start_date", SqlDbType.SmallDateTime)
            SqlParameterMediaEndDate = New System.Data.SqlClient.SqlParameter("@m_cutoff_date", SqlDbType.SmallDateTime)
            SqlParameterBroadcastStartDate = New System.Data.SqlClient.SqlParameter("@brdcast_date1", SqlDbType.SmallDateTime)
            SqlParameterBroadcastEndDate = New System.Data.SqlClient.SqlParameter("@brdcast_date2", SqlDbType.SmallDateTime)
            SqlParameterIncludeLegacy = New System.Data.SqlClient.SqlParameter("@incl_legacy", SqlDbType.Bit)
            SqlParameterJobMediaDateFrom = New System.Data.SqlClient.SqlParameter("@job_media_date_from", SqlDbType.SmallDateTime)
            SqlParameterJobMediaDateTo = New System.Data.SqlClient.SqlParameter("@job_media_date_to", SqlDbType.SmallDateTime)
            SqlParameterClientBillerList = New System.Data.SqlClient.SqlParameter("@biller_emp_code_list", SqlDbType.VarChar)

            SqlParameterBillingCommandCenterID.Value = BillingCommandCenterID
            SqlParameterBillingUser.Value = BillingUser
            SqlParameterSelectBy.Value = SelectBy

            If CampaignIDs Is Nothing Then

                SqlParameterCampaignIDList.Value = System.DBNull.Value

            Else

                SqlParameterCampaignIDList.Value = String.Join(",", CampaignIDs.ToArray)

            End If

            If ClientCodes Is Nothing Then

                SqlParameterClientCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientCodeList.Value = String.Join(",", ClientCodes.ToArray)

            End If

            If DivisionCodes Is Nothing Then

                SqlParameterDivisionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterDivisionCodeList.Value = String.Join(",", DivisionCodes.ToArray)

            End If

            If ProductCodes Is Nothing Then

                SqlParameterProductCodeList.Value = System.DBNull.Value

            Else

                SqlParameterProductCodeList.Value = String.Join(",", ProductCodes.ToArray)

            End If

            If OrderNumbers Is Nothing Then

                SqlParameterOrderNumberList.Value = System.DBNull.Value

            Else

                SqlParameterOrderNumberList.Value = String.Join(",", OrderNumbers.ToArray)

            End If

            If OrderLineNumbers Is Nothing Then

                SqlParameterOrderLineNumberList.Value = System.DBNull.Value

            Else

                SqlParameterOrderLineNumberList.Value = String.Join(",", OrderLineNumbers.ToArray)

            End If

            If ClientPOs Is Nothing Then

                SqlParameterClientPOList.Value = System.DBNull.Value

            Else

                SqlParameterClientPOList.Value = String.Join(",", ClientPOs.ToArray)

            End If

            If MarketCodes Is Nothing Then

                SqlParameterMarketCodeList.Value = System.DBNull.Value

            Else

                SqlParameterMarketCodeList.Value = String.Join(",", MarketCodes.ToArray)

            End If

            If ClientBillers Is Nothing Then

                SqlParameterClientBillerList.Value = System.DBNull.Value

            Else

                SqlParameterClientBillerList.Value = String.Join(",", ClientBillers.ToArray)

            End If

            SqlParameterIncludeUnbilledOnly.Value = IncludeUnbilledOnly
            SqlParameterIncludeZeroSpots.Value = IncludeZeroSpots
            SqlParameterDateToUse.Value = DateToUse
            SqlParameterNewspaper.Value = Newspaper
            SqlParameterMagazine.Value = Magazine
            SqlParameterInternet.Value = Internet
            SqlParameterOutofHome.Value = OutOfHome
            SqlParameterRadio.Value = Radio
            SqlParameterRadioDaily.Value = RadioDaily
            SqlParameterRadioMonthly.Value = RadioMonthly
            SqlParameterTelevision.Value = TV
            SqlParameterTelevisionDaily.Value = TVDaily
            SqlParameterTelevisionMonthly.Value = TVMonthly
            SqlParameterMediaStartDate.Value = If(MediaStartDate.HasValue, MediaStartDate.Value, System.DBNull.Value)
            SqlParameterMediaEndDate.Value = If(MediaEndDate.HasValue, MediaEndDate.Value, System.DBNull.Value)
            SqlParameterBroadcastStartDate.Value = If(BroadcastStartDate.HasValue, BroadcastStartDate.Value, System.DBNull.Value)
            SqlParameterBroadcastEndDate.Value = If(BroadcastEndDate.HasValue, BroadcastEndDate.Value, System.DBNull.Value)
            SqlParameterIncludeLegacy.Value = IncludeLegacy
            SqlParameterJobMediaDateFrom.Value = If(JobMediaDateFrom.HasValue, JobMediaDateFrom, System.DBNull.Value)
            SqlParameterJobMediaDateTo.Value = If(JobMediaDateTo.HasValue, JobMediaDateTo, System.DBNull.Value)

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_update_billing_cmd_center_media @bcc_id_in, @billing_user, @m_select_by, @cmp_id_in_list, @cl_code_in_list, @cl_div_code_in_list, @cl_div_prd_code_in_list, @order_number_in_list, @order_line_number_in_list, @client_po_in_list, @market_code_in_list, @incl_unbilled_only, @incl_zero_spots, @date_to_use, @newspaper, @magazine, @internet, @out_of_home, @radio, @radio_daily, @radio_monthly, @television, @tv_daily, @tv_monthly, @m_start_date, @m_cutoff_date, @brdcast_date1, @brdcast_date2, @incl_legacy, @job_media_date_from, @job_media_date_to, @biller_emp_code_list",
                                                 SqlParameterBillingCommandCenterID, SqlParameterBillingUser, SqlParameterSelectBy, SqlParameterCampaignIDList, SqlParameterClientCodeList, SqlParameterDivisionCodeList, SqlParameterProductCodeList, SqlParameterOrderNumberList,
                                                 SqlParameterOrderLineNumberList, SqlParameterClientPOList, SqlParameterMarketCodeList, SqlParameterIncludeUnbilledOnly, SqlParameterIncludeZeroSpots, SqlParameterDateToUse, SqlParameterNewspaper, SqlParameterMagazine,
                                                 SqlParameterInternet, SqlParameterOutofHome, SqlParameterRadio, SqlParameterRadioDaily, SqlParameterRadioMonthly, SqlParameterTelevision, SqlParameterTelevisionDaily, SqlParameterTelevisionMonthly, SqlParameterMediaStartDate,
                                                 SqlParameterMediaEndDate, SqlParameterBroadcastStartDate, SqlParameterBroadcastEndDate, SqlParameterIncludeLegacy, SqlParameterJobMediaDateFrom, SqlParameterJobMediaDateTo, SqlParameterClientBillerList)

        End Sub
        Public Function UpdateProductionBillHoldStatus(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                       ByVal BillingUser As String, ByVal HoldAction As Integer) As Integer

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHoldAction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterHoldAction = New System.Data.SqlClient.SqlParameter("@hold_action", SqlDbType.SmallInt)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterBillingUser.Value = BillingUser
            SqlParameterHoldAction.Value = HoldAction
            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_bill_hold @job_number, @job_component_nbr, @billing_user, @hold_action, @ret_val OUTPUT", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterBillingUser, SqlParameterHoldAction, SqlParameterRetVal)

            UpdateProductionBillHoldStatus = SqlParameterRetVal.Value

        End Function
        Public Function UpdateProductionJobProcessControl(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                          ByVal JobProcessID As Short, ByVal Comments As String) As Integer

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobProcessID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = BCCDbContext.UserCode

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterJobProcessID = New System.Data.SqlClient.SqlParameter("@job_process_control_in", SqlDbType.SmallInt)
            SqlParameterComments = New System.Data.SqlClient.SqlParameter("@comments", SqlDbType.Text)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterJobProcessID.Value = JobProcessID

            If Comments Is Nothing Then

                SqlParameterComments.Value = System.DBNull.Value

            Else

                SqlParameterComments.Value = Comments

            End If

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_update_job_process_control @job_number, @job_component_nbr, @job_process_control_in, @comments, @ret_val OUTPUT, @user_id", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterJobProcessID, SqlParameterComments, SqlParameterRetVal, SqlParameterUserCode)

            UpdateProductionJobProcessControl = SqlParameterRetVal.Value

        End Function
        Public Function UpdateProductionJobProcessScheduleStatus(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                                 ByVal StatusCode As String) As Integer

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStatusCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterStatusCode = New System.Data.SqlClient.SqlParameter("@trf_code_in", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterStatusCode.Value = StatusCode

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_update_job_traffic_status @job_number, @job_component_nbr, @trf_code_in, @ret_val OUTPUT", SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterStatusCode, SqlParameterRetVal)

            UpdateProductionJobProcessScheduleStatus = SqlParameterRetVal.Value

        End Function
        Public Sub UpdateProductionSelection(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer, ByVal BillingUser As String,
                                             ByVal SelectBy As Integer, ByVal ClientCodes As IEnumerable(Of String), ByVal ClientDivisionCodes As IEnumerable(Of String), ByVal ClientDivisionProductCodes As IEnumerable(Of String),
                                             ByVal SelectionOption As Integer, ByVal EmployeeDate As Date, ByVal IncomeOnlyDate As Date, ByVal APPostPeriodCode As String,
                                             ByVal CampaignIDs As IEnumerable(Of Integer), ByVal JobNumbers As IEnumerable(Of Integer), ByVal JobComponentRowIDs As IEnumerable(Of Integer), ByVal BatchID As Integer,
                                             ByVal BillingApprovalHeaderIDs As IEnumerable(Of Integer), ByVal AccountExecutiveCodes As IEnumerable(Of String), ByVal TypeOfJob As Integer, ByVal SalesClassCodes As IEnumerable(Of String),
                                             ByVal BillerEmployeeCodes As IEnumerable(Of String), ByVal JobMediaDateToBillStart As Nullable(Of Date), ByVal JobMediaDateToBillEnd As Nullable(Of Date))

            'objects
            Dim SqlParameterBillingCommandCenterID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectionOption As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncomeOnlyDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPPostPeriodCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignIDList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentRowIDList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingApprovalHeaderIDList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAccountExecutiveCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSalesClassCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillerEmployeeCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateFrom As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateTo As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingCommandCenterID = New System.Data.SqlClient.SqlParameter("@bcc_id_in", SqlDbType.Int)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterSelectBy = New System.Data.SqlClient.SqlParameter("@select_by", SqlDbType.SmallInt)
            SqlParameterClientCodeList = New System.Data.SqlClient.SqlParameter("@cl_code_list", SqlDbType.VarChar)
            SqlParameterDivisionCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_code_list", SqlDbType.VarChar)
            SqlParameterProductCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_prd_code_list", SqlDbType.VarChar)
            SqlParameterSelectionOption = New System.Data.SqlClient.SqlParameter("@sel_option", SqlDbType.SmallInt)
            SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@emp_date_in", SqlDbType.SmallDateTime)
            SqlParameterIncomeOnlyDate = New System.Data.SqlClient.SqlParameter("@io_date_in", SqlDbType.SmallDateTime)
            SqlParameterAPPostPeriodCode = New System.Data.SqlClient.SqlParameter("@ap_post_period_in", SqlDbType.VarChar)
            SqlParameterCampaignIDList = New System.Data.SqlClient.SqlParameter("@cmp_id_list", SqlDbType.VarChar)
            SqlParameterJobNumberList = New System.Data.SqlClient.SqlParameter("@job_number_list", SqlDbType.VarChar)
            SqlParameterJobComponentRowIDList = New System.Data.SqlClient.SqlParameter("@job_comp_rowid_list", SqlDbType.VarChar)
            SqlParameterBatchID = New System.Data.SqlClient.SqlParameter("@batch_id_in", SqlDbType.Int)
            SqlParameterBillingApprovalHeaderIDList = New System.Data.SqlClient.SqlParameter("@ba_hdr_id_list", SqlDbType.VarChar)
            SqlParameterAccountExecutiveCodeList = New System.Data.SqlClient.SqlParameter("@acct_exec_list", SqlDbType.VarChar)
            SqlParameterJobType = New System.Data.SqlClient.SqlParameter("@job_type", SqlDbType.Int)
            SqlParameterSalesClassCode = New System.Data.SqlClient.SqlParameter("@sc_code_list", SqlDbType.VarChar)
            SqlParameterBillerEmployeeCodeList = New System.Data.SqlClient.SqlParameter("@biller_emp_code_list", SqlDbType.VarChar)
            SqlParameterJobMediaDateFrom = New System.Data.SqlClient.SqlParameter("@job_media_date_from", SqlDbType.SmallDateTime)
            SqlParameterJobMediaDateTo = New System.Data.SqlClient.SqlParameter("@job_media_date_to", SqlDbType.SmallDateTime)

            SqlParameterBillingCommandCenterID.Value = BillingCommandCenterID
            SqlParameterBillingUser.Value = BillingUser
            SqlParameterSelectBy.Value = SelectBy

            If ClientCodes Is Nothing Then

                SqlParameterClientCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientCodeList.Value = String.Join(",", ClientCodes.ToArray)

            End If

            If ClientDivisionCodes Is Nothing Then

                SqlParameterDivisionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterDivisionCodeList.Value = String.Join(",", ClientDivisionCodes.ToArray)

            End If

            If ClientDivisionProductCodes Is Nothing Then

                SqlParameterProductCodeList.Value = System.DBNull.Value

            Else

                SqlParameterProductCodeList.Value = String.Join(",", ClientDivisionProductCodes.ToArray)

            End If

            SqlParameterSelectionOption.Value = SelectionOption
            SqlParameterEmployeeDate.Value = EmployeeDate
            SqlParameterIncomeOnlyDate.Value = IncomeOnlyDate
            SqlParameterAPPostPeriodCode.Value = APPostPeriodCode

            If CampaignIDs Is Nothing Then

                SqlParameterCampaignIDList.Value = System.DBNull.Value

            Else

                SqlParameterCampaignIDList.Value = String.Join(",", CampaignIDs.ToArray)

            End If

            If JobNumbers Is Nothing Then

                SqlParameterJobNumberList.Value = System.DBNull.Value

            Else

                SqlParameterJobNumberList.Value = String.Join(",", JobNumbers.ToArray)

            End If

            If JobComponentRowIDs Is Nothing Then

                SqlParameterJobComponentRowIDList.Value = System.DBNull.Value

            Else

                SqlParameterJobComponentRowIDList.Value = String.Join(",", JobComponentRowIDs.ToArray)

            End If

            SqlParameterBatchID.Value = BatchID

            If BillingApprovalHeaderIDs Is Nothing Then

                SqlParameterBillingApprovalHeaderIDList.Value = System.DBNull.Value

            Else

                SqlParameterBillingApprovalHeaderIDList.Value = String.Join(",", BillingApprovalHeaderIDs.ToArray)

            End If

            If AccountExecutiveCodes Is Nothing Then

                SqlParameterAccountExecutiveCodeList.Value = System.DBNull.Value

            Else

                SqlParameterAccountExecutiveCodeList.Value = String.Join(",", AccountExecutiveCodes.ToArray)

            End If

            SqlParameterJobType.Value = TypeOfJob

            If SalesClassCodes Is Nothing Then

                SqlParameterSalesClassCode.Value = System.DBNull.Value

            Else

                SqlParameterSalesClassCode.Value = String.Join(",", SalesClassCodes.ToArray)

            End If

            If BillerEmployeeCodes Is Nothing Then

                SqlParameterBillerEmployeeCodeList.Value = System.DBNull.Value

            Else

                SqlParameterBillerEmployeeCodeList.Value = String.Join(",", BillerEmployeeCodes.ToArray)

            End If

            If JobMediaDateToBillStart.HasValue Then

                SqlParameterJobMediaDateFrom.Value = JobMediaDateToBillStart.Value

            Else

                SqlParameterJobMediaDateFrom.Value = System.DBNull.Value

            End If

            If JobMediaDateToBillEnd.HasValue Then

                SqlParameterJobMediaDateTo.Value = JobMediaDateToBillEnd.Value

            Else

                SqlParameterJobMediaDateTo.Value = System.DBNull.Value

            End If

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_update_billing_cmd_center_production @bcc_id_in, @billing_user, @select_by, @cl_code_list, @cl_div_code_list, @cl_div_prd_code_list, @sel_option, @emp_date_in, @io_date_in, @ap_post_period_in, @cmp_id_list, @job_number_list, @job_comp_rowid_list, @batch_id_in, @ba_hdr_id_list, @acct_exec_list, @job_type, @sc_code_list, @biller_emp_code_list, @job_media_date_from, @job_media_date_to",
                SqlParameterBillingCommandCenterID, SqlParameterBillingUser, SqlParameterSelectBy, SqlParameterClientCodeList, SqlParameterDivisionCodeList, SqlParameterProductCodeList,
                SqlParameterSelectionOption, SqlParameterEmployeeDate, SqlParameterIncomeOnlyDate, SqlParameterAPPostPeriodCode, SqlParameterCampaignIDList,
                SqlParameterJobNumberList, SqlParameterJobComponentRowIDList, SqlParameterBatchID, SqlParameterBillingApprovalHeaderIDList, SqlParameterAccountExecutiveCodeList,
                SqlParameterJobType, SqlParameterSalesClassCode, SqlParameterBillerEmployeeCodeList, SqlParameterJobMediaDateFrom, SqlParameterJobMediaDateTo)

        End Sub
        Public Function InterimReconcile(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                         ByVal ProductionReconcileInterimDetail As AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionReconcileInterimDetail,
                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String

            'objects
            Dim ReturnValue As String = ""
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterItemID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPSeq As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAdvanceBillingID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOpenNetAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMarkupAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStateAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCountyAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCityAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNonResaleAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOpenAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSalesAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMethod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGLACodeState As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGLACodeCounty As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGLACodeCity As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTaxCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterItemID = New System.Data.SqlClient.SqlParameter("@item_id", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_number", SqlDbType.SmallInt)
            SqlParameterAPSeq = New System.Data.SqlClient.SqlParameter("@ap_seq", SqlDbType.SmallInt)
            SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@fnc_code", SqlDbType.VarChar)
            SqlParameterFunctionType = New System.Data.SqlClient.SqlParameter("@fnc_type", SqlDbType.VarChar)
            SqlParameterAdvanceBillingID = New System.Data.SqlClient.SqlParameter("@ab_id", SqlDbType.Int)
            SqlParameterAdvanceBillingID.Direction = ParameterDirection.Output
            SqlParameterOpenNetAmount = New System.Data.SqlClient.SqlParameter("@open_net_amt", SqlDbType.Decimal)
            SqlParameterMarkupAmount = New System.Data.SqlClient.SqlParameter("@markup_amt", SqlDbType.Decimal)
            SqlParameterStateAmount = New System.Data.SqlClient.SqlParameter("@state_amt", SqlDbType.Decimal)
            SqlParameterCountyAmount = New System.Data.SqlClient.SqlParameter("@county_amt", SqlDbType.Decimal)
            SqlParameterCityAmount = New System.Data.SqlClient.SqlParameter("@city_amt", SqlDbType.Decimal)
            SqlParameterNonResaleAmount = New System.Data.SqlClient.SqlParameter("@nonresale_amt", SqlDbType.Decimal)
            SqlParameterOpenAmount = New System.Data.SqlClient.SqlParameter("@open_amt", SqlDbType.Decimal)
            SqlParameterSalesAmount = New System.Data.SqlClient.SqlParameter("@sales_amt", SqlDbType.Decimal)
            SqlParameterMethod = New System.Data.SqlClient.SqlParameter("@method", SqlDbType.SmallInt)
            SqlParameterGLACodeState = New System.Data.SqlClient.SqlParameter("@glacode_state", SqlDbType.VarChar)
            SqlParameterGLACodeCounty = New System.Data.SqlClient.SqlParameter("@glacode_county", SqlDbType.VarChar)
            SqlParameterGLACodeCity = New System.Data.SqlClient.SqlParameter("@glacode_city", SqlDbType.VarChar)
            SqlParameterTaxCode = New System.Data.SqlClient.SqlParameter("@tax_code", SqlDbType.VarChar)
            SqlParameterBillDate = New System.Data.SqlClient.SqlParameter("@bill_date", SqlDbType.SmallDateTime)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.Output

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterItemID.Value = ProductionReconcileInterimDetail.ITEM_ID
            SqlParameterLineNumber.Value = ProductionReconcileInterimDetail.LINE_NUMBER
            SqlParameterAPSeq.Value = ProductionReconcileInterimDetail.AP_SEQ
            SqlParameterFunctionCode.Value = ProductionReconcileInterimDetail.FNC_CODE
            SqlParameterFunctionType.Value = ProductionReconcileInterimDetail.FNC_TYPE
            SqlParameterAdvanceBillingID.Value = DBNull.Value
            SqlParameterOpenNetAmount.Value = If(ProductionReconcileInterimDetail.EXT_AMOUNT Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_AMOUNT)
            SqlParameterMarkupAmount.Value = If(ProductionReconcileInterimDetail.EXT_MARKUP_AMT Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_MARKUP_AMT)
            SqlParameterStateAmount.Value = If(ProductionReconcileInterimDetail.EXT_STATE_RESALE Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_STATE_RESALE)
            SqlParameterCountyAmount.Value = If(ProductionReconcileInterimDetail.EXT_COUNTY_RESALE Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_COUNTY_RESALE)
            SqlParameterCityAmount.Value = If(ProductionReconcileInterimDetail.EXT_CITY_RESALE Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_CITY_RESALE)
            SqlParameterNonResaleAmount.Value = If(ProductionReconcileInterimDetail.EXT_NONRESALE_TAX Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.EXT_NONRESALE_TAX)
            SqlParameterOpenAmount.Value = If(ProductionReconcileInterimDetail.LINE_TOTAL Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.LINE_TOTAL)
            SqlParameterSalesAmount.Value = If(ProductionReconcileInterimDetail.AMOUNT Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.AMOUNT)
            SqlParameterMethod.Value = 0
            SqlParameterGLACodeState.Value = If(ProductionReconcileInterimDetail.GLACODE_STATE Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.GLACODE_STATE)
            SqlParameterGLACodeCounty.Value = If(ProductionReconcileInterimDetail.GLACODE_CNTY Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.GLACODE_CNTY)
            SqlParameterGLACodeCity.Value = If(ProductionReconcileInterimDetail.GLACODE_CITY Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.GLACODE_CITY)
            SqlParameterTaxCode.Value = If(ProductionReconcileInterimDetail.TAX_CODE Is Nothing, DBNull.Value, ProductionReconcileInterimDetail.TAX_CODE)
            SqlParameterBillDate.Value = Now.ToShortDateString
            SqlParameterBillingUser.Value = BCCDbContext.UserCode 'OK - not billinguser with 01
            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_bill_cmd_ctr_interim_reconcile @job_number, @job_component_nbr, @item_id, @line_number, @ap_seq, @fnc_code, @fnc_type, @ab_id OUTPUT, @open_net_amt, @markup_amt, @state_amt, @county_amt, @city_amt, @nonresale_amt, @open_amt, @sales_amt, @method, @glacode_state, @glacode_county, @glacode_city, @tax_code, @bill_date, @billing_user, @ret_val OUTPUT",
                                                SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterItemID, SqlParameterLineNumber, SqlParameterAPSeq, SqlParameterFunctionCode, SqlParameterFunctionType,
                                                SqlParameterAdvanceBillingID, SqlParameterOpenNetAmount, SqlParameterMarkupAmount, SqlParameterStateAmount, SqlParameterCountyAmount, SqlParameterCityAmount, SqlParameterNonResaleAmount, SqlParameterOpenAmount, SqlParameterSalesAmount, SqlParameterMethod, SqlParameterGLACodeState, SqlParameterGLACodeCounty, SqlParameterGLACodeCity, SqlParameterTaxCode, SqlParameterBillDate, SqlParameterBillingUser, SqlParameterRetVal)

            Select Case SqlParameterRetVal.Value

                Case -2

                    ReturnValue = "Reconciliation failed.  Job is not billable."

                Case -3

                    ReturnValue = "Reconciliation failed.  Job process control does not allow final reconciliation."

                Case -4

                    ReturnValue = "Reconciliation failed.  Job is on bill hold."

                Case -5

                    ReturnValue = "Reconciliation failed.  Job is selected for billing by another user."

                Case -6

                    ReturnValue = "Reconciliation failed.  Billing date not specified."

                Case -7

                    ReturnValue = "Reconciliation failed.  Reconciliation is already finalized for this job."

                Case -9

                    ReturnValue = "Reconciliation failed.  Billing is pending for this job."

                Case -10

                    ReturnValue = "Reconciliation failed.  This is not an advance billed job."

                Case -11

                    ReturnValue = "Reconciliation failed.  Job is set up for recognition upon initial billing."

            End Select

            InterimReconcile = ReturnValue

            '*  -2	Job is not billable
            '*  -3	Job process control does not allow final reconciliation
            '*  -4	Job is on bill hold
            '*  -5	Job is selected for billing by another user 
            '*  -6	Billing date not specified
            '*  -7	Reconciliation is already finalized for this job
            '*  -9	Billing is pending for this job
            '* -10	This is not an advance billed job
            '* -11	Job is set up for recognition upon initial billing
        End Function
        Public Function AdvanceBillReconcile(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal RecType As Short, ByVal BillingCommandCenterID As Integer) As String

            'objects
            Dim ReturnValue As String = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAdvanceBillingID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRecType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingCommandCenterID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterAdvanceBillingID = New System.Data.SqlClient.SqlParameter("@ab_id_in", SqlDbType.Int)
            SqlParameterBillDate = New System.Data.SqlClient.SqlParameter("@bill_date", SqlDbType.SmallDateTime)
            SqlParameterRecType = New System.Data.SqlClient.SqlParameter("@rec_type", SqlDbType.TinyInt)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterBillingCommandCenterID = New System.Data.SqlClient.SqlParameter("@bcc_id", SqlDbType.Int)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.Output

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterAdvanceBillingID.Value = 0
            SqlParameterBillDate.Value = Now.ToShortDateString
            SqlParameterRecType.Value = RecType
            SqlParameterBillingUser.Value = BCCDbContext.UserCode 'OK - not billinguser with 01
            SqlParameterBillingCommandCenterID.Value = BillingCommandCenterID
            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_adv_bill_reconcile @job_number, @job_component_nbr, @ab_id_in, @bill_date, @rec_type, @billing_user, @bcc_id, @ret_val OUTPUT",
                                                 SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterAdvanceBillingID, SqlParameterBillDate, SqlParameterRecType,
                                                 SqlParameterBillingUser, SqlParameterBillingCommandCenterID, SqlParameterRetVal)

            Select Case SqlParameterRetVal.Value

                Case 0

                    ReturnValue = "Reconciled/recognized successfully."

                Case -2

                    ReturnValue = "Reconciliation failed.  Job is not billable."

                Case -3

                    ReturnValue = "Reconciliation failed.  Job process control does not allow final reconciliation."

                Case -4

                    ReturnValue = "Reconciliation failed.  Job is on bill hold."

                Case -5

                    ReturnValue = "Reconciliation failed.  Job is selected for billing by another user."

                Case -6

                    ReturnValue = "Reconciliation failed.  Billing date not specified."

                Case -7

                    ReturnValue = "Reconciliation failed.  Reconciliation is already finalized for this job."

                Case -9

                    ReturnValue = "Reconciliation failed.  Billing is pending for this job."

            End Select

            AdvanceBillReconcile = ReturnValue

            '*  -2	Job is not billable
            '*  -3	Job process control does not allow final reconciliation
            '*  -4	Job is on bill hold
            '*  -5	Job is selected for billing by another user 
            '*  -6	Billing date not specified
            '*  -7	Reconciliation is already finalized for this job
            '*  -9	Billing is pending for this job
            '* -10	This is not an advance billed job  
        End Function
        'Public Function RecognizeIncome(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, _
        '                                ByVal ProductionReconcileRecognize As AdvantageFramework.BillingCommandCenter.Classes.ProductionReconcileRecognize, _
        '                                ByVal BillingUser As String) As String

        '    'objects
        '    Dim ReturnValue As String = Nothing
        '    Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterBillDate As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterAdvanceBillBalanceAmount As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterRecognitionAmount As System.Data.SqlClient.SqlParameter = Nothing
        '    Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

        '    SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
        '    SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
        '    SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
        '    SqlParameterBillDate = New System.Data.SqlClient.SqlParameter("@bill_date", SqlDbType.SmallDateTime)
        '    SqlParameterAdvanceBillBalanceAmount = New System.Data.SqlClient.SqlParameter("@ab_balance_amt", SqlDbType.Decimal)
        '    SqlParameterRecognitionAmount = New System.Data.SqlClient.SqlParameter("@recognition_amt", SqlDbType.Decimal)
        '    SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
        '    SqlParameterRetVal.Direction = ParameterDirection.Output

        '    SqlParameterJobNumber.Value = ProductionReconcileRecognize.JobNumber
        '    SqlParameterJobComponentNumber.Value = ProductionReconcileRecognize.ComponentNumber
        '    SqlParameterBillingUser.Value = BillingUser
        '    SqlParameterBillDate.Value = Now.ToShortDateString
        '    SqlParameterAdvanceBillBalanceAmount.Value = ProductionReconcileRecognize.AdvanceBilledAmount.GetValueOrDefault(0)
        '    SqlParameterRecognitionAmount.Value = ProductionReconcileRecognize.AmountToRecognize.GetValueOrDefault(0)

        '    SqlParameterRetVal.Value = 0

        '    BCCDbContext.Database.ExecuteSqlCommand("exec advsp_bill_cmd_ctr_income_recognition @job_number, @job_component_nbr, @billing_user, @bill_date, @ab_balance_amt, @recognition_amt, @ret_val OUTPUT", _
        '                                         SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterBillingUser, SqlParameterBillDate, SqlParameterAdvanceBillBalanceAmount, _
        '                                         SqlParameterRecognitionAmount, SqlParameterRetVal)

        '    Select Case SqlParameterRetVal.Value

        '        Case 0

        '            ReturnValue = "Reconciled/recognized successfully."

        '        Case -1

        '            ReturnValue = "Recognition failed.  There is nothing to recognize for this job."

        '        Case -2

        '            ReturnValue = "Recognition failed.  Job is not billable."

        '        Case -3

        '            ReturnValue = "Recognition failed.  Job process control does not allow income recognition."

        '        Case -4

        '            ReturnValue = "Recognition failed.  Job is on bill hold."

        '        Case -5

        '            ReturnValue = "Recognition failed.  Job is selected for billing by another user."

        '        Case -6

        '            ReturnValue = "Recognition failed.  Billing date not specified."

        '        Case -7

        '            ReturnValue = "Recognition failed.  Reconciliation is finalized for this job."

        '        Case -9

        '            ReturnValue = "Recognition failed.  Advance billing is pending for this job."

        '        Case -10

        '            ReturnValue = "Recognition failed.  This is not an advance billed job."

        '        Case -11

        '            ReturnValue = "Recognition failed.  Job is set up for recognition upon initial billing."

        '        Case -12

        '            ReturnValue = "Recognition failed.  Job has no advance bill balance amount."

        '    End Select

        '    RecognizeIncome = ReturnValue

        '    '*  -1	There is nothing to recognize for this job
        '    '*  -2	Job is not billable
        '    '*  -3	Job process control does not allow income recognition
        '    '*  -4	Job is on bill hold
        '    '*  -5	Job is selected for billing by another user 
        '    '*  -6	Billing date not specified
        '    '*  -7	Reconciliation is finalized for this job
        '    '*  -9	Advance billing is pending for this job
        '    '* -10	This is not an advance billed job
        '    '* -11	Job is set up for recognition upon initial billing
        '    '* -12	Job has no advance bill balance amount
        'End Function
        Public Sub CreateNewBatch(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                  ByVal BatchName As String, ByRef BillingCommandCenterID As Nullable(Of Integer), ByRef ErrorMessage As String)

            'objects
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchName As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingCommandCenterID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterErrorMessage As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar)
            SqlParameterBatchName = New System.Data.SqlClient.SqlParameter("@BatchName", SqlDbType.VarChar)

            SqlParameterBillingCommandCenterID = New System.Data.SqlClient.SqlParameter("@BCCID", SqlDbType.Int)
            SqlParameterBillingCommandCenterID.Direction = ParameterDirection.Output

            SqlParameterErrorMessage = New System.Data.SqlClient.SqlParameter("@ErrorMessage ", SqlDbType.VarChar, 200)
            SqlParameterErrorMessage.Direction = ParameterDirection.InputOutput

            SqlParameterUserCode.Value = BCCDbContext.UserCode
            SqlParameterBatchName.Value = BatchName
            SqlParameterBillingCommandCenterID.Value = 0
            SqlParameterErrorMessage.Value = ""

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_bcc_create_user_batch @UserCode, @BatchName, @BCCID OUTPUT, @ErrorMessage OUTPUT",
                                                 SqlParameterUserCode, SqlParameterBatchName, SqlParameterBillingCommandCenterID, SqlParameterErrorMessage)

            If Not System.DBNull.Value.Equals(SqlParameterBillingCommandCenterID.Value) Then

                BillingCommandCenterID = SqlParameterBillingCommandCenterID.Value

            End If

            ErrorMessage = SqlParameterErrorMessage.Value

        End Sub
        Public Function BillingSelectMarkJobComponent(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                      ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter,
                                                      ByVal InvoiceDate As Date, ByVal PostPeriodCode As String,
                                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                      ByRef BillingSelectionResult As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingInvoiceDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPostPeriodCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPPostPeriodCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncomeOnlyDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBatchID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterBillingInvoiceDate = New System.Data.SqlClient.SqlParameter("@inv_date_in", SqlDbType.SmallDateTime)
            SqlParameterPostPeriodCode = New System.Data.SqlClient.SqlParameter("@post_period_in", SqlDbType.VarChar)
            SqlParameterAPPostPeriodCode = New System.Data.SqlClient.SqlParameter("@ap_post_period_in", SqlDbType.VarChar)
            SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@emp_date_in", SqlDbType.SmallDateTime)
            SqlParameterIncomeOnlyDate = New System.Data.SqlClient.SqlParameter("@io_date_in", SqlDbType.SmallDateTime)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number_in", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_comp_in", SqlDbType.SmallInt)
            SqlParameterBatchID = New System.Data.SqlClient.SqlParameter("@batch_id_in", SqlDbType.Int)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterBillingUser.Value = BillingCommandCenter.BillingUser
            SqlParameterBillingInvoiceDate.Value = InvoiceDate
            SqlParameterPostPeriodCode.Value = PostPeriodCode
            SqlParameterAPPostPeriodCode.Value = BillingCommandCenter.APPostPeriodCodeCutoff
            SqlParameterEmployeeDate.Value = BillingCommandCenter.EmployeeTimeDateCutoff.Value
            SqlParameterIncomeOnlyDate.Value = BillingCommandCenter.IncomeOnlyDateCutoff.Value
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber

            If BillingCommandCenter.BillingApprovalBatchID Is Nothing Then

                SqlParameterBatchID.Value = System.DBNull.Value

            Else

                SqlParameterBatchID.Value = BillingCommandCenter.BillingApprovalBatchID

            End If

            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_bill_select_mark_items @billing_user, @inv_date_in, @post_period_in, @ap_post_period_in, @emp_date_in, @io_date_in, @job_number_in, @job_comp_in, @batch_id_in, @ret_val OUTPUT",
                SqlParameterBillingUser, SqlParameterBillingInvoiceDate, SqlParameterPostPeriodCode, SqlParameterAPPostPeriodCode, SqlParameterEmployeeDate, SqlParameterIncomeOnlyDate,
                SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterBatchID, SqlParameterRetVal)

            Select Case SqlParameterRetVal.Value

                Case 0

                    BillingSelectionResult = "Selected."

                Case -1

                    BillingSelectionResult = "Not selected. The job has no qualifying detail."

                Case -2

                    BillingSelectionResult = "Billing Selection failed. The job/component status has changed since it was retrieved."

                Case -3

                    BillingSelectionResult = "Billing Selection failed. Invoices have already been assigned by your user ID."

                Case -4

                    BillingSelectionResult = "Billing Selection failed. Current billing run was created in Billing Selection application."

                Case -5

                    BillingSelectionResult = "Billing Selection failed. There is no record in the billing table for your user ID."

                Case -6

                    BillingSelectionResult = "Billing Selection failed. There is no production record in the billing table for your user ID."

                Case -7

                    BillingSelectionResult = "Billing Selection failed. Production billing setup is not complete."

                Case Else

                    BillingSelectionResult = "Billing Selection failed."

            End Select

            BillingSelectMarkJobComponent = SqlParameterRetVal.Value

        End Function
        Public Function BillingSelectUnmarkJobComponent(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                        ByVal BillingUser As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                        ByRef BillingSelectionResult As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number_in", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_comp_in", SqlDbType.SmallInt)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterBillingUser.Value = BillingUser
            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_bill_select_unmark_items @billing_user, @job_number_in, @job_comp_in, @ret_val OUTPUT",
                SqlParameterBillingUser, SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterRetVal)

            Select Case SqlParameterRetVal.Value

                Case 0

                    BillingSelectionResult = "Deselected."

                Case -3

                    BillingSelectionResult = "Billing Deselection failed. Invoices have already been assigned by your user ID."

                Case Else

                    BillingSelectionResult = "Billing Deselection failed."

            End Select

            BillingSelectUnmarkJobComponent = SqlParameterRetVal.Value

        End Function
        Public Function AssignInvoices(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingUser As String) As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.AssignInvoices)

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user_in", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val ", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterBillingUser.Value = BillingUser
            SqlParameterRetVal.Value = 0

            AssignInvoices = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.AssignInvoices)("exec dbo.advsp_billing @billing_user_in, @ret_val OUTPUT", SqlParameterBillingUser, SqlParameterRetVal).ToList()

        End Function
        Public Function GetRejectedCoopJobs(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BillingUser As String) As IEnumerable(Of String)

            'objects
            Dim Output As IEnumerable(Of String) = Nothing

            Output = (From Entity In AdvantageFramework.Database.Procedures.WorkARFunction.LoadByBillingUserCode(DataContext, BillingUser).ToList
                      Where Entity.IsRejectedByOffice = 1 AndAlso
                            Entity.JobNumber IsNot Nothing AndAlso
                            Entity.JobComponentNumber IsNot Nothing
                      Select Entity.JobNumber.Value.ToString + "-" + Entity.JobComponentNumber.Value.ToString.PadLeft(3, "0")).Distinct.ToList

            GetRejectedCoopJobs = Output

        End Function
        Public Function GetRejectedCoopOrders(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BillingUser As String) As IEnumerable(Of String)

            'objects
            Dim Output As IEnumerable(Of String) = Nothing

            Output = (From Entity In AdvantageFramework.Database.Procedures.WorkARFunction.LoadByBillingUserCode(DataContext, BillingUser).ToList
                      Where Entity.IsRejectedByOffice = 1 AndAlso
                            Entity.OrderNumber IsNot Nothing AndAlso
                            Entity.OrderLineNumber IsNot Nothing
                      Select Entity.OrderNumber.Value.ToString + "-" + Entity.OrderLineNumber.Value.ToString.PadLeft(3, "0")).Distinct.ToList

            GetRejectedCoopOrders = Output

        End Function
        Public Function Finish(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                               BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter) As Boolean

            'objects
            Dim ReturnValue As Boolean = True

            Try

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET ADJUST_USER = NULL WHERE BCC_ID = {0}", BillingCommandCenter.ID))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.AR_COOP_TMP WHERE BILLING_USER = '{0}'", BillingCommandCenter.BillingUser))

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.BILLING WHERE INV_ASSIGN = 1 AND BILLING_USER = '{0}'", BillingCommandCenter.BillingUser))

            Catch ex As Exception
                ReturnValue = False
            End Try

            Finish = ReturnValue

        End Function
        Public Sub UpdateBillingSelectionInvoiceDatePostPeriodCode(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal InvoiceDate As Date,
                                                                   ByVal PostPeriodCode As String, ByVal BillingUser As String,
                                                                   Optional BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing)

            'objects
            Dim SqlParameterInvoiceDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPostPeriodCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUseCombo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterComboInvBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductionInvBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaInvBy As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInvoiceDate = New System.Data.SqlClient.SqlParameter("@INV_DATE", SqlDbType.SmallDateTime)
            SqlParameterPostPeriodCode = New System.Data.SqlClient.SqlParameter("@POST_PERIOD", SqlDbType.VarChar)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@BILLING_USER", SqlDbType.VarChar)

            SqlParameterInvoiceDate.Value = InvoiceDate
            SqlParameterPostPeriodCode.Value = PostPeriodCode
            SqlParameterBillingUser.Value = BillingUser

            If BillingSelectionCriteria IsNot Nothing Then

                SqlParameterUseCombo = New System.Data.SqlClient.SqlParameter("@USE_COMBO_BILLING_OVERRIDE", SqlDbType.Bit)
                SqlParameterComboInvBy = New System.Data.SqlClient.SqlParameter("@COMBO_INV_BY_OVERRIDE", SqlDbType.SmallInt)
                SqlParameterProductionInvBy = New System.Data.SqlClient.SqlParameter("@CL_INV_BY_OVERRIDE", SqlDbType.SmallInt)
                SqlParameterMediaInvBy = New System.Data.SqlClient.SqlParameter("@CL_MINV_BY_OVERRIDE", SqlDbType.SmallInt)

                If BillingSelectionCriteria.UseComboBilling Then

                    SqlParameterUseCombo.Value = 1
                    SqlParameterComboInvBy.Value = BillingSelectionCriteria.ComboAssignInvoicesBy
                    SqlParameterProductionInvBy.Value = System.DBNull.Value
                    SqlParameterMediaInvBy.Value = System.DBNull.Value

                Else

                    SqlParameterUseCombo.Value = 0
                    SqlParameterComboInvBy.Value = System.DBNull.Value
                    SqlParameterProductionInvBy.Value = If(String.IsNullOrWhiteSpace(BillingSelectionCriteria.ProductionAssignInvoicesBy), System.DBNull.Value, BillingSelectionCriteria.ProductionAssignInvoicesBy)
                    SqlParameterMediaInvBy.Value = If(String.IsNullOrWhiteSpace(BillingSelectionCriteria.MediaAssignInvoicesBy), System.DBNull.Value, BillingSelectionCriteria.MediaAssignInvoicesBy)

                End If

                BCCDbContext.Database.ExecuteSqlCommand("UPDATE dbo.BILLING SET INV_DATE = @INV_DATE, POST_PERIOD = @POST_PERIOD, USE_COMBO_BILLING_OVERRIDE = @USE_COMBO_BILLING_OVERRIDE, COMBO_INV_BY_OVERRIDE= @COMBO_INV_BY_OVERRIDE, CL_INV_BY_OVERRIDE = @CL_INV_BY_OVERRIDE, CL_MINV_BY_OVERRIDE = @CL_MINV_BY_OVERRIDE WHERE BILLING_USER = @BILLING_USER",
                                                        SqlParameterInvoiceDate, SqlParameterPostPeriodCode, SqlParameterBillingUser, SqlParameterUseCombo, SqlParameterComboInvBy, SqlParameterProductionInvBy, SqlParameterMediaInvBy)

            Else

                BCCDbContext.Database.ExecuteSqlCommand("UPDATE dbo.BILLING SET INV_DATE = @INV_DATE, POST_PERIOD = @POST_PERIOD WHERE BILLING_USER = @BILLING_USER", SqlParameterInvoiceDate, SqlParameterPostPeriodCode, SqlParameterBillingUser)

            End If

        End Sub
        Public Sub UpdateBillingSetInvoicesProcessedFlag(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingUser As String, ByVal Processed As Boolean)

            BCCDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET INV_PROCESSED = {1} WHERE BILLING_USER = '{0}'", BillingUser, If(Processed, 1, 0)))

        End Sub
        Public Sub UpdateBillingApprovalDetailClientComment(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal ClientComment As String, ByVal BillingApprovalDetailID As Integer)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterClientComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingApprovalDetailID As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.BILL_APPR_DTL SET CLIENT_COMMENTS = @ClientComment WHERE BA_DTL_ID = @BillingApprovalDetailID"

            SqlParameterClientComment = New System.Data.SqlClient.SqlParameter("@ClientComment", SqlDbType.VarChar)
            SqlParameterBillingApprovalDetailID = New System.Data.SqlClient.SqlParameter("@BillingApprovalDetailID", SqlDbType.Int)

            If String.IsNullOrWhiteSpace(ClientComment) Then

                SqlParameterClientComment.Value = System.DBNull.Value

            Else

                SqlParameterClientComment.Value = ClientComment

            End If

            SqlParameterBillingApprovalDetailID.Value = BillingApprovalDetailID

            BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterClientComment, SqlParameterBillingApprovalDetailID)

        End Sub
        Public Sub UpdateBillingApprovalHeaderClientComment(ByVal Session As AdvantageFramework.Security.Session, ByVal ClientComment As String, ByVal BillingApprovalHeaderID As Integer)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterClientComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingApprovalHeaderID As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.BILL_APPR_HDR SET CLIENT_COMMENTS = @ClientComment WHERE BA_HDR_ID = @BillingApprovalHeaderID"

            SqlParameterClientComment = New System.Data.SqlClient.SqlParameter("@ClientComment", SqlDbType.VarChar)
            SqlParameterBillingApprovalHeaderID = New System.Data.SqlClient.SqlParameter("@BillingApprovalHeaderID", SqlDbType.Int)

            If String.IsNullOrWhiteSpace(ClientComment) Then

                SqlParameterClientComment.Value = System.DBNull.Value

            Else

                SqlParameterClientComment.Value = ClientComment

            End If

            SqlParameterBillingApprovalHeaderID.Value = BillingApprovalHeaderID

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterClientComment, SqlParameterBillingApprovalHeaderID)

            End Using

        End Sub
        Public Sub UpdateWorkARFunctionAmounts(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal ARFunctionID As Integer,
                                               ByVal CostAmount As Decimal, ByVal IncomeAmount As Decimal, ByVal BillingUser As String)

            'objects
            Dim SqlParameterARFunctionID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCostAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncomeAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterARFunctionID = New System.Data.SqlClient.SqlParameter("@ARFunctionID", SqlDbType.Int)

            SqlParameterCostAmount = New System.Data.SqlClient.SqlParameter("@CostAmount", SqlDbType.Decimal)
            SqlParameterCostAmount.Precision = 18
            SqlParameterCostAmount.Scale = 2

            SqlParameterIncomeAmount = New System.Data.SqlClient.SqlParameter("@IncomeAmount", SqlDbType.Decimal)
            SqlParameterIncomeAmount.Precision = 18
            SqlParameterIncomeAmount.Scale = 2

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@BillingUser", SqlDbType.VarChar)

            SqlParameterARFunctionID.Value = ARFunctionID
            SqlParameterCostAmount.Value = CostAmount
            SqlParameterIncomeAmount.Value = IncomeAmount
            SqlParameterBillingUser.Value = BillingUser

            BCCDbContext.Database.ExecuteSqlCommand("exec dbo.advsp_bcc_update_coop @ARFunctionID, @CostAmount, @IncomeAmount, @BillingUser",
                                                 SqlParameterARFunctionID, SqlParameterCostAmount, SqlParameterIncomeAmount, SqlParameterBillingUser)

        End Sub
        Public Function GetBillingStatus(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer) As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing

            BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

            If BillingCommandCenter IsNot Nothing Then

                Try

                    BillingStatus = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus)(String.Format("exec dbo.advsp_get_billing_status '{0}'", BillingCommandCenter.BillingUser)).FirstOrDefault

                Catch ex As Exception
                    BillingStatus = Nothing
                End Try

            End If

            GetBillingStatus = BillingStatus

        End Function
        Public Function GetReconcileStatus(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Integer

            Dim ReconcileStatus As Integer = Nothing

            ReconcileStatus = CInt(BCCDbContext.Database.SqlQuery(Of Byte)(String.Format("SELECT [dbo].[advfn_adv_bill_reconcile_status] ({0}, {1})", JobNumber, JobComponentNumber)).SingleOrDefault)

            GetReconcileStatus = ReconcileStatus

        End Function
        Public Function BillingSelectMarkMediaItem(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                   ByVal BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter,
                                                   ByVal MediaSummary As AdvantageFramework.BillingCommandCenter.Classes.MediaSummary,
                                                   ByVal InvoiceDate As Date, ByVal PostPeriodCode As String,
                                                   ByRef BillingSelectionResult As String, ByRef AmountSelectedforBilling As Decimal) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingInvoiceDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPostPeriodCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOutOfHome As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCutoffDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateToUse As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastDate1 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastDate2 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeZeroSpots As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAmountSelectedforBilling As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_number_in", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_number_in", SqlDbType.SmallInt)
            SqlParameterBillingInvoiceDate = New System.Data.SqlClient.SqlParameter("@inv_date_in", SqlDbType.SmallDateTime)
            SqlParameterPostPeriodCode = New System.Data.SqlClient.SqlParameter("@post_period_in", SqlDbType.VarChar)
            SqlParameterRadio = New System.Data.SqlClient.SqlParameter("@radio_in", SqlDbType.SmallInt)
            SqlParameterTelevision = New System.Data.SqlClient.SqlParameter("@television_in", SqlDbType.SmallInt)
            SqlParameterMagazine = New System.Data.SqlClient.SqlParameter("@magazine_in", SqlDbType.SmallInt)
            SqlParameterInternet = New System.Data.SqlClient.SqlParameter("@internet_in", SqlDbType.SmallInt)
            SqlParameterOutOfHome = New System.Data.SqlClient.SqlParameter("@out_of_home_in", SqlDbType.SmallInt)
            SqlParameterNewspaper = New System.Data.SqlClient.SqlParameter("@newspaper_in", SqlDbType.SmallInt)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@m_start_date_in", SqlDbType.SmallDateTime)
            SqlParameterCutoffDate = New System.Data.SqlClient.SqlParameter("@m_cutoff_date_in", SqlDbType.SmallDateTime)
            SqlParameterDateToUse = New System.Data.SqlClient.SqlParameter("@date_to_use_in", SqlDbType.SmallInt)
            SqlParameterBroadcastDate1 = New System.Data.SqlClient.SqlParameter("@brdcast_date1_in", SqlDbType.SmallDateTime)
            SqlParameterBroadcastDate2 = New System.Data.SqlClient.SqlParameter("@brdcast_date2_in", SqlDbType.SmallDateTime)
            SqlParameterIncludeZeroSpots = New System.Data.SqlClient.SqlParameter("@incl_zero_spots_in", SqlDbType.Bit)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput
            SqlParameterAmountSelectedforBilling = New System.Data.SqlClient.SqlParameter("@amount_selected_for_billing", SqlDbType.Decimal)
            SqlParameterAmountSelectedforBilling.Precision = 18
            SqlParameterAmountSelectedforBilling.Scale = 2
            SqlParameterAmountSelectedforBilling.Direction = ParameterDirection.InputOutput

            SqlParameterBillingUser.Value = BillingCommandCenter.BillingUser
            SqlParameterOrderNumber.Value = MediaSummary.OrderNumber
            SqlParameterLineNumber.Value = If(MediaSummary.LineNumber.HasValue, MediaSummary.LineNumber.Value, System.DBNull.Value)
            SqlParameterBillingInvoiceDate.Value = InvoiceDate
            SqlParameterPostPeriodCode.Value = PostPeriodCode
            SqlParameterRadio.Value = CBool(BillingCommandCenter.IsRadio.GetValueOrDefault(False))
            SqlParameterTelevision.Value = CBool(BillingCommandCenter.IsTelevision.GetValueOrDefault(False))
            SqlParameterMagazine.Value = CBool(BillingCommandCenter.IsMagazine.GetValueOrDefault(False))
            SqlParameterInternet.Value = CBool(BillingCommandCenter.IsInternet.GetValueOrDefault(False))
            SqlParameterOutOfHome.Value = CBool(BillingCommandCenter.IsOutOfHome.GetValueOrDefault(False))
            SqlParameterNewspaper.Value = CBool(BillingCommandCenter.IsNewspaper.GetValueOrDefault(False))
            SqlParameterStartDate.Value = If(BillingCommandCenter.MediaStartDate.HasValue, BillingCommandCenter.MediaStartDate.Value, System.DBNull.Value)
            SqlParameterCutoffDate.Value = If(BillingCommandCenter.MediaEndDate.HasValue, BillingCommandCenter.MediaEndDate.Value, System.DBNull.Value)
            SqlParameterDateToUse.Value = If(BillingCommandCenter.DateCuttoffToUseFlag.HasValue, BillingCommandCenter.DateCuttoffToUseFlag.Value, System.DBNull.Value)
            SqlParameterBroadcastDate1.Value = If(BillingCommandCenter.MediaBroadcastMonthStart.HasValue, BillingCommandCenter.MediaBroadcastMonthStart.Value, System.DBNull.Value)
            SqlParameterBroadcastDate2.Value = If(BillingCommandCenter.MediaBroadcastMonthEnd.HasValue, BillingCommandCenter.MediaBroadcastMonthEnd.Value, System.DBNull.Value)
            SqlParameterIncludeZeroSpots.Value = CBool(BillingCommandCenter.IncludeZeroSpots.GetValueOrDefault(False))
            SqlParameterRetVal.Value = 0
            SqlParameterAmountSelectedforBilling.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_bill_select_mark_media_items @billing_user, @order_number_in, @line_number_in, @inv_date_in, @post_period_in, @radio_in, @television_in, @magazine_in, @internet_in, @out_of_home_in, @newspaper_in, @m_start_date_in, @m_cutoff_date_in,	@date_to_use_in, @brdcast_date1_in, @brdcast_date2_in, @incl_zero_spots_in, @ret_val OUTPUT, @amount_selected_for_billing OUTPUT"),
                SqlParameterBillingUser, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterBillingInvoiceDate, SqlParameterPostPeriodCode, SqlParameterRadio, SqlParameterTelevision, SqlParameterMagazine, SqlParameterInternet, SqlParameterOutOfHome,
                SqlParameterNewspaper, SqlParameterStartDate, SqlParameterCutoffDate, SqlParameterDateToUse, SqlParameterBroadcastDate1, SqlParameterBroadcastDate2, SqlParameterIncludeZeroSpots, SqlParameterRetVal, SqlParameterAmountSelectedforBilling)

            Select Case SqlParameterRetVal.Value

                Case 0

                    BillingSelectionResult = "Selected."
                    AmountSelectedforBilling = SqlParameterAmountSelectedforBilling.Value

                Case -1

                    BillingSelectionResult = "Not selected. The order has no qualifying detail."

                Case -2

                    BillingSelectionResult = "Billing Selection failed. The current order process control does not allow billing."

                Case -3

                    BillingSelectionResult = "Billing Selection failed. Invoices have already been assigned by your user ID."

                Case -4

                    BillingSelectionResult = "Billing Selection failed. Current billing run was created in Billing Selection application."

                Case -5

                    BillingSelectionResult = "Billing Selection failed. The current order was created in a previous version of broadcast orders. " & vbCrLf &
                        "You must use the Billing Selection application to bill this order."

                Case -6
                    BillingSelectionResult = "Billing Selection failed. An error occurred while attempting to retrieve the product record."

                Case -11, -12

                    BillingSelectionResult = "Billing Selection failed. An error occurred while attempting to update the radio detail record(s)."

                Case -13, -14

                    BillingSelectionResult = "Billing Selection failed. An error occurred while attempting to update the television detail record(s)."

                Case -20, -22

                    BillingSelectionResult = "Billing Selection failed. An error occurred while attempting to delete from the temporary broadcast table."

                Case -21, -23

                    BillingSelectionResult = "Billing Selection failed. An error occurred while attempting to insert into the temporary broadcast table."

                Case -25

                    BillingSelectionResult = "Billing Selection failed. Order not found."

                Case -30

                    BillingSelectionResult = "Billing Selection failed. Media billing setup is not complete."

                Case Else

                    BillingSelectionResult = "Billing Selection failed."

            End Select

            BillingSelectMarkMediaItem = SqlParameterRetVal.Value

        End Function
        Public Function BillingSelectUnmarkMediaItem(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                     ByVal BillingUser As String, ByVal OrderNumber As Integer, ByVal LineNumber As Short,
                                                     ByRef BillingSelectionResult As String) As Integer

            'objects
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_number_in", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_number_in", SqlDbType.SmallInt)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetVal.Direction = ParameterDirection.InputOutput

            SqlParameterBillingUser.Value = BillingUser
            SqlParameterOrderNumber.Value = OrderNumber
            SqlParameterLineNumber.Value = LineNumber
            SqlParameterRetVal.Value = 0

            BCCDbContext.Database.ExecuteSqlCommand("exec advsp_bill_select_unmark_m_items @billing_user, @order_number_in, @line_number_in, @ret_val OUTPUT",
                SqlParameterBillingUser, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterRetVal)

            Select Case SqlParameterRetVal.Value

                Case 0

                    BillingSelectionResult = "Deselected."

                Case -3

                    BillingSelectionResult = "Billing Deselection failed. Invoices have already been assigned."

                Case Else

                    BillingSelectionResult = "Billing Deselection failed."

            End Select

            BillingSelectUnmarkMediaItem = SqlParameterRetVal.Value

        End Function
        Public Sub UpdateCampaignComment(ByVal Session As AdvantageFramework.Security.Session, ByVal CampaignComment As String, ByVal CampaignID As Integer)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterCampaignComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignID As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.CAMPAIGN SET CMP_COMMENTS = @CampaignComment WHERE CMP_IDENTIFIER = @CampaignID"

            SqlParameterCampaignComment = New System.Data.SqlClient.SqlParameter("@CampaignComment", SqlDbType.VarChar)
            SqlParameterCampaignID = New System.Data.SqlClient.SqlParameter("@CampaignID", SqlDbType.Int)

            If String.IsNullOrWhiteSpace(CampaignComment) Then

                SqlParameterCampaignComment.Value = System.DBNull.Value

            Else

                SqlParameterCampaignComment.Value = CampaignComment

            End If

            SqlParameterCampaignID.Value = CampaignID

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterCampaignComment, SqlParameterCampaignID)

            End Using

        End Sub
        Public Sub UpdateJobComment(ByVal Session As AdvantageFramework.Security.Session, ByVal JobComment As String, ByVal JobNumber As Integer)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterJobComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.JOB_LOG SET JOB_COMMENTS = @JobComment WHERE JOB_NUMBER = @JobNumber"

            SqlParameterJobComment = New System.Data.SqlClient.SqlParameter("@JobComment", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)

            If String.IsNullOrWhiteSpace(JobComment) Then

                SqlParameterJobComment.Value = System.DBNull.Value

            Else

                SqlParameterJobComment.Value = JobComment

            End If

            SqlParameterJobNumber.Value = JobNumber

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterJobComment, SqlParameterJobNumber)

            End Using

        End Sub
        Public Sub UpdateJobComponentComment(ByVal Session As AdvantageFramework.Security.Session, ByVal JobComponentComment As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterJobComponentComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.JOB_COMPONENT SET JOB_COMP_COMMENTS = @JobComponentComment WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber"

            SqlParameterJobComponentComment = New System.Data.SqlClient.SqlParameter("@JobComponentComment", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)

            If String.IsNullOrWhiteSpace(JobComponentComment) Then

                SqlParameterJobComponentComment.Value = System.DBNull.Value

            Else

                SqlParameterJobComponentComment.Value = JobComponentComment

            End If

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterJobComponentComment, SqlParameterJobNumber, SqlParameterJobComponentNumber)

            End Using

        End Sub
        Public Function ValidateBillingSelectionCriteria(ByVal Session As AdvantageFramework.Security.Session, ByVal InvoiceDate As Date, ByVal PostPeriodCode As String, ByRef ErrorMessage As String) As Boolean

            Dim BillingSelectionCriteria As AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria = Nothing
            Dim IsValid As Boolean = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingSelectionCriteria = New AdvantageFramework.BillingCommandCenter.Classes.BillingSelectionCriteria(InvoiceDate, PostPeriodCode)
                BillingSelectionCriteria.DbContext = DbContext
                ErrorMessage = BillingSelectionCriteria.ValidateEntity(IsValid)

            End Using

            ValidateBillingSelectionCriteria = IsValid

        End Function
        Public Function GetJournalEntiresByTransactionList(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                           ByVal GLTransactions As IEnumerable(Of Integer)) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JournalEntry)

            'objects
            Dim JournalEntryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JournalEntry) = Nothing
            Dim SqlParameterGLTransactionList As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterGLTransactionList = New System.Data.SqlClient.SqlParameter("@GLTransactionList", SqlDbType.VarChar)

            SqlParameterGLTransactionList.Value = String.Join(",", GLTransactions.ToArray)

            JournalEntryList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.JournalEntry)("exec advsp_bcc_get_journal_entries_by_transaction @GLTransactionList", SqlParameterGLTransactionList).ToList

            GetJournalEntiresByTransactionList = JournalEntryList

        End Function
        Public Function GetMediaSelectionAvailable(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer,
                                                   ByVal BillingUser As String, ByVal SelectBy As Integer, ByVal IncludeUnbilledOnly As Boolean, ByVal IncludeZeroSpots As Boolean,
                                                   ByVal DateToUse As Short, ByVal Newspaper As Boolean, ByVal Magazine As Boolean, ByVal Internet As Boolean, ByVal OutOfHome As Boolean,
                                                   ByVal Radio As Boolean, ByVal RadioDaily As Boolean, ByVal RadioMonthly As Boolean,
                                                   ByVal TV As Boolean, ByVal TVDaily As Boolean, ByVal TVMonthly As Boolean,
                                                   ByVal MediaStartDate As Nullable(Of Date), ByVal MediaEndDate As Nullable(Of Date), ByVal BroadcastStartDate As Nullable(Of Date), ByVal BroadcastEndDate As Nullable(Of Date),
                                                   ByVal IncludeLegacy As Boolean, ByVal JobMediaDateFrom As Nullable(Of Date), ByVal JobMediaDateTo As Nullable(Of Date)) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)

            'objects
            Dim SqlParameterBillingCommandCenterID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingUser As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeUnbilledOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeZeroSpots As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDateToUse As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOutofHome As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadioDaily As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadioMonthly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevisionDaily As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevisionMonthly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBroadcastEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeLegacy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateFrom As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaDateTo As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaSelectionAvailableList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable) = Nothing

            SqlParameterBillingCommandCenterID = New System.Data.SqlClient.SqlParameter("@bcc_id_in", SqlDbType.Int)
            SqlParameterBillingUser = New System.Data.SqlClient.SqlParameter("@billing_user", SqlDbType.VarChar)
            SqlParameterSelectBy = New System.Data.SqlClient.SqlParameter("@m_select_by", SqlDbType.SmallInt)
            SqlParameterIncludeUnbilledOnly = New System.Data.SqlClient.SqlParameter("@incl_unbilled_only", SqlDbType.Bit)
            SqlParameterIncludeZeroSpots = New System.Data.SqlClient.SqlParameter("@incl_zero_spots", SqlDbType.Bit)
            SqlParameterDateToUse = New System.Data.SqlClient.SqlParameter("@date_to_use", SqlDbType.SmallInt)
            SqlParameterNewspaper = New System.Data.SqlClient.SqlParameter("@newspaper", SqlDbType.Bit)
            SqlParameterMagazine = New System.Data.SqlClient.SqlParameter("@magazine", SqlDbType.Bit)
            SqlParameterInternet = New System.Data.SqlClient.SqlParameter("@internet", SqlDbType.Bit)
            SqlParameterOutofHome = New System.Data.SqlClient.SqlParameter("@out_of_home", SqlDbType.Bit)
            SqlParameterRadio = New System.Data.SqlClient.SqlParameter("@radio", SqlDbType.Bit)
            SqlParameterRadioDaily = New System.Data.SqlClient.SqlParameter("@radio_daily", SqlDbType.Bit)
            SqlParameterRadioMonthly = New System.Data.SqlClient.SqlParameter("@radio_monthly", SqlDbType.Bit)
            SqlParameterTelevision = New System.Data.SqlClient.SqlParameter("@television", SqlDbType.Bit)
            SqlParameterTelevisionDaily = New System.Data.SqlClient.SqlParameter("@tv_daily", SqlDbType.Bit)
            SqlParameterTelevisionMonthly = New System.Data.SqlClient.SqlParameter("@tv_monthly", SqlDbType.Bit)
            SqlParameterMediaStartDate = New System.Data.SqlClient.SqlParameter("@m_start_date", SqlDbType.SmallDateTime)
            SqlParameterMediaEndDate = New System.Data.SqlClient.SqlParameter("@m_cutoff_date", SqlDbType.SmallDateTime)
            SqlParameterBroadcastStartDate = New System.Data.SqlClient.SqlParameter("@brdcast_date1", SqlDbType.SmallDateTime)
            SqlParameterBroadcastEndDate = New System.Data.SqlClient.SqlParameter("@brdcast_date2", SqlDbType.SmallDateTime)
            SqlParameterIncludeLegacy = New System.Data.SqlClient.SqlParameter("@incl_legacy", SqlDbType.Bit)
            SqlParameterJobMediaDateFrom = New System.Data.SqlClient.SqlParameter("@job_media_date_from", SqlDbType.SmallDateTime)
            SqlParameterJobMediaDateTo = New System.Data.SqlClient.SqlParameter("@job_media_date_to", SqlDbType.SmallDateTime)

            SqlParameterBillingCommandCenterID.Value = BillingCommandCenterID
            SqlParameterBillingUser.Value = BillingUser
            SqlParameterSelectBy.Value = SelectBy
            SqlParameterIncludeUnbilledOnly.Value = IncludeUnbilledOnly
            SqlParameterIncludeZeroSpots.Value = IncludeZeroSpots
            SqlParameterDateToUse.Value = DateToUse
            SqlParameterNewspaper.Value = Newspaper
            SqlParameterMagazine.Value = Magazine
            SqlParameterInternet.Value = Internet
            SqlParameterOutofHome.Value = OutOfHome
            SqlParameterRadio.Value = Radio
            SqlParameterRadioDaily.Value = RadioDaily
            SqlParameterRadioMonthly.Value = RadioMonthly
            SqlParameterTelevision.Value = TV
            SqlParameterTelevisionDaily.Value = TVDaily
            SqlParameterTelevisionMonthly.Value = TVMonthly
            SqlParameterMediaStartDate.Value = If(MediaStartDate.HasValue, MediaStartDate.Value, System.DBNull.Value)
            SqlParameterMediaEndDate.Value = If(MediaEndDate.HasValue, MediaEndDate.Value, System.DBNull.Value)
            SqlParameterBroadcastStartDate.Value = If(BroadcastStartDate.HasValue, BroadcastStartDate.Value, System.DBNull.Value)
            SqlParameterBroadcastEndDate.Value = If(BroadcastEndDate.HasValue, BroadcastEndDate.Value, System.DBNull.Value)
            SqlParameterIncludeLegacy.Value = IncludeLegacy
            SqlParameterJobMediaDateFrom.Value = If(JobMediaDateFrom.HasValue, JobMediaDateFrom, System.DBNull.Value)
            SqlParameterJobMediaDateTo.Value = If(JobMediaDateTo.HasValue, JobMediaDateTo, System.DBNull.Value)

            MediaSelectionAvailableList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSelectionAvailable)("SET ARITHABORT ON; exec dbo.advsp_bcc_get_media_available @bcc_id_in, @billing_user, @m_select_by, @incl_unbilled_only, @incl_zero_spots, @date_to_use, @newspaper, @magazine, @internet, @out_of_home, @radio, @radio_daily, @radio_monthly, @television, @tv_daily, @tv_monthly, @m_start_date, @m_cutoff_date, @brdcast_date1, @brdcast_date2, @incl_legacy, @job_media_date_from, @job_media_date_to",
                                                 SqlParameterBillingCommandCenterID, SqlParameterBillingUser, SqlParameterSelectBy, SqlParameterIncludeUnbilledOnly, SqlParameterIncludeZeroSpots, SqlParameterDateToUse, SqlParameterNewspaper, SqlParameterMagazine,
                                                 SqlParameterInternet, SqlParameterOutofHome, SqlParameterRadio, SqlParameterRadioDaily, SqlParameterRadioMonthly, SqlParameterTelevision, SqlParameterTelevisionDaily, SqlParameterTelevisionMonthly, SqlParameterMediaStartDate,
                                                 SqlParameterMediaEndDate, SqlParameterBroadcastStartDate, SqlParameterBroadcastEndDate, SqlParameterIncludeLegacy, SqlParameterJobMediaDateFrom, SqlParameterJobMediaDateTo).ToList

            GetMediaSelectionAvailable = MediaSelectionAvailableList

        End Function
        Public Function GetOpenPO(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                  JobNumber As Integer, JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem)

            Dim OpenPOItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem) = Nothing

            OpenPOItemList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.OpenPOItem) _
                                                                (String.Format("exec dbo.advsp_bcc_job_details_get_open_po {0}, {1}, {2}",
                                                                BillingCommandCenterID, JobNumber, JobComponentNumber)).ToList

            GetOpenPO = OpenPOItemList

        End Function
        Public Function GetProductionSummary(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer,
                                             ByVal IncludeContingency As Boolean,
                                             Optional ByVal JobNumber As Nullable(Of Integer) = Nothing, Optional ByVal JobComponentNumber As Nullable(Of Short) = Nothing) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)

            Dim ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing

            ProductionSummaryList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) _
                                                                                (String.Format("SET ARITHABORT ON; exec dbo.advsp_bcc_get_production_summary {0}, {1}, 0, {2}, {3}",
                                                                                BillingCommandCenterID, If(IncludeContingency, 1, 0),
                                                                                If(JobNumber.HasValue, JobNumber.Value, "NULL"), If(JobComponentNumber.HasValue, JobComponentNumber, "NULL"))).ToList

            GetProductionSummary = ProductionSummaryList

        End Function
        Public Function GetProductionSummaryByFunction(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal BillingCommandCenterID As Integer,
                                                       ByVal IncludeContingency As Boolean,
                                                       Optional ByVal JobNumber As Nullable(Of Integer) = Nothing, Optional ByVal JobComponentNumber As Nullable(Of Short) = Nothing) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail)

            Dim JobComponentFunctionDetailList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) = Nothing

            JobComponentFunctionDetailList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail) _
                                                                                (String.Format("SET ARITHABORT ON; exec dbo.advsp_bcc_get_production_summary {0}, {1}, 1, {2}, {3}",
                                                                                BillingCommandCenterID, If(IncludeContingency, 1, 0),
                                                                                If(JobNumber.HasValue, JobNumber.Value, "NULL"), If(JobComponentNumber.HasValue, JobComponentNumber, "NULL"))).ToList

            GetProductionSummaryByFunction = JobComponentFunctionDetailList

        End Function
        Public Function GetClientCashReceiptPaymentsByInvoiceNumber(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                                                    ByVal InvoiceNumber As Integer) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ClientCashReceiptPayment)

            'objects
            Dim ClientCashReceiptPaymentList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ClientCashReceiptPayment) = Nothing

            ClientCashReceiptPaymentList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.ClientCashReceiptPayment)(String.Format("exec dbo.advsp_clientcashreceipt_invoice_payments {0}", InvoiceNumber)).ToList

            GetClientCashReceiptPaymentsByInvoiceNumber = ClientCashReceiptPaymentList

        End Function
        Public Function GetMediaBillingHistory(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As IEnumerable(Of Integer)) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory)

            'objects
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumbers As System.Data.SqlClient.SqlParameter = Nothing
            Dim MediaBillingHistoryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory) = Nothing

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@OrderNumber", SqlDbType.Int)
            SqlParameterLineNumbers = New System.Data.SqlClient.SqlParameter("@LineNumbers", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = OrderNumber
            SqlParameterLineNumbers.Value = String.Join(",", LineNumbers.ToArray)

            MediaBillingHistoryList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.MediaBillingHistory) _
                                                                                ("exec dbo.advsp_bcc_get_media_billing_history @OrderNumber, @LineNumbers",
                                                                                SqlParameterOrderNumber, SqlParameterLineNumbers).ToList

            GetMediaBillingHistory = MediaBillingHistoryList

        End Function
        Public Sub AddAdvanceBillingRows(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval,
                                         ByVal AdvanceBillPercentToQuote As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillPercentToQuote,
                                         ByVal JobComponentFunctionDetails As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail),
                                         ByRef AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem),
                                         ByVal Session As AdvantageFramework.Security.Session, ByVal IncludeContingency As Boolean)

            Dim EstimateRevisionDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EstimateRevisionDetail) = Nothing
            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling = Nothing
            Dim CalcPercent As Decimal = 0
            Dim JobComponentFunctionDetail As AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail = Nothing
            Dim JobComponentFunctionCodes As IEnumerable(Of String) = Nothing
            Dim NetAmount As Decimal = 0
            Dim MarkupAmount As Decimal = 0
            Dim AdvanceBilledNonResaleAmount As Decimal = Nothing
            Dim EstimateFunctionCodes As IEnumerable(Of String) = Nothing
            Dim FunctionCodesWithoutEstimate As IEnumerable(Of String) = Nothing
            Dim EstimateRevisionDetail As AdvantageFramework.Database.Entities.EstimateRevisionDetail = Nothing

            CalcPercent = If(AdvanceBillPercentToQuote.PercentToQuote > 100, 100, AdvanceBillPercentToQuote.PercentToQuote)

            JobComponentFunctionCodes = (From Entity In JobComponentFunctionDetails
                                         Select Entity.FunctionCode).ToList

            If AdvanceBillPercentToQuote.ExcludeNonbillableFunctions Then

                JobComponentFunctionCodes = (From ERD In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                             Where ERD.EstimateNumber = EstimateApproval.EstimateNumber AndAlso
                                                   ERD.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber AndAlso
                                                   ERD.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber AndAlso
                                                   ERD.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber AndAlso
                                                   (ERD.IsNonBillable Is Nothing OrElse ERD.IsNonBillable = 0)
                                             Select ERD.FunctionCode).ToList

            End If

            EstimateRevisionDetailList = (From ERD In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                          Where ERD.EstimateNumber = EstimateApproval.EstimateNumber AndAlso
                                                ERD.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber AndAlso
                                                ERD.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber AndAlso
                                                ERD.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber AndAlso
                                                JobComponentFunctionCodes.Contains(ERD.FunctionCode) AndAlso
                                                ERD.FunctionType <> "C"
                                          Select ERD).ToList

            For Each JobComponentFunctionCode In JobComponentFunctionCodes

                AdvanceBilling = Nothing

                If AdvanceBillingItemList IsNot Nothing AndAlso AdvanceBillingItemList.Count > 0 Then

                    AdvanceBillingItem = (From Entity In AdvanceBillingItemList
                                          Where Entity.FunctionCode = JobComponentFunctionCode
                                          Select Entity).SingleOrDefault

                    If AdvanceBillingItem IsNot Nothing AndAlso AdvanceBillingItem.AdvanceBilling IsNot Nothing Then

                        AdvanceBilling = AdvanceBillingItem.AdvanceBilling

                        If AdvanceBillingItem.AdvanceBilling.FunctionCode Is Nothing Then

                            InitializeAdvanceBilling(AdvanceBilling, EstimateApproval, JobComponentFunctionCode,
                                                     JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = JobComponentFunctionCode).FirstOrDefault.FunctionType,
                                                     Session.UserCode)

                        End If

                    End If

                End If

                If AdvanceBilling Is Nothing Then

                    AdvanceBilling = New AdvantageFramework.Database.Entities.AdvanceBilling

                    InitializeAdvanceBilling(AdvanceBilling, EstimateApproval, JobComponentFunctionCode,
                                             JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = JobComponentFunctionCode).FirstOrDefault.FunctionType,
                                             Session.UserCode)

                    AdvanceBillingItem = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem(AdvanceBilling, DbContext)

                    AdvanceBillingItemList.Add(AdvanceBillingItem)

                End If

                JobComponentFunctionDetail = (From JCFD In JobComponentFunctionDetails
                                              Where JCFD.JobNumber = AdvanceBilling.JobNumber AndAlso
                                                    JCFD.ComponentNumber = AdvanceBilling.JobComponentNumber AndAlso
                                                    JCFD.FunctionCode = AdvanceBilling.FunctionCode
                                              Select JCFD).FirstOrDefault

                AdvanceBilledNonResaleAmount = (From AB In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                                                Where AB.ARInvoiceNumber IsNot Nothing AndAlso
                                                      AB.JobNumber = AdvanceBilling.JobNumber AndAlso
                                                      AB.JobComponentNumber = AdvanceBilling.JobComponentNumber AndAlso
                                                      AB.FunctionCode = AdvanceBilling.FunctionCode).ToList.Sum(Function(AB) AB.ExtendedNonResaleTax.GetValueOrDefault(0))

                If IncludeContingency Then

                    NetAmount = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Sum(Function(ERD) ERD.ExtendedAmount.GetValueOrDefault(0) + ERD.ContingencyAmount.GetValueOrDefault(0))
                    MarkupAmount = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Sum(Function(ERD) ERD.MarkupAmount.GetValueOrDefault(0) + ERD.ContingencyMarkupAmount.GetValueOrDefault(0))

                    AdvanceBilling.UseContingency = 1

                Else

                    NetAmount = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Sum(Function(ERD) ERD.ExtendedAmount.GetValueOrDefault(0))
                    MarkupAmount = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Sum(Function(ERD) ERD.MarkupAmount.GetValueOrDefault(0))

                    AdvanceBilling.UseContingency = 0

                End If

                AdvanceBilling.NetAmount = FormatNumber((NetAmount * CalcPercent / 100) _
                    - If(JobComponentFunctionDetail IsNot Nothing, JobComponentFunctionDetail.BilledNet.GetValueOrDefault(0) + JobComponentFunctionDetail.AdvanceBilledNetAmount.GetValueOrDefault(0), 0) _
                    + AdvanceBilledNonResaleAmount, 2)

                AdvanceBilling.ExtendedMarkupAmount = FormatNumber((MarkupAmount * CalcPercent / 100) _
                    - If(JobComponentFunctionDetail IsNot Nothing, JobComponentFunctionDetail.BilledMarkup.GetValueOrDefault(0) + JobComponentFunctionDetail.AdvanceBilledMarkupAmount.GetValueOrDefault(0), 0), 2)

                AdvanceBilling.EstimateNumber = EstimateApproval.EstimateNumber
                AdvanceBilling.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber
                AdvanceBilling.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber
                AdvanceBilling.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber

                AdvanceBillingItem.SetBillingRate(DbContext)

                If CalcPercent = 100 AndAlso EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Count = 1 Then

                    AdvanceBilling.QuantityHours = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Single.Quantity
                    AdvanceBilling.Rate = EstimateRevisionDetailList.Where(Function(ERD) ERD.FunctionCode = JobComponentFunctionCode).Single.RateAmount

                    If AdvanceBilling.QuantityHours = 0 Then

                        AdvanceBilling.QuantityHours = Nothing

                    End If

                Else

                    AdvanceBilling.QuantityHours = Nothing
                    AdvanceBilling.Rate = Nothing

                End If

                AdvanceBillingItem.CalculateAdvanceBilling(Session, True, True)

                If AdvanceBillingItem.MarkupPercent.HasValue AndAlso AdvanceBillingItem.MarkupPercent.Value > 999999.999 Then

                    AdvanceBillingItem.MarkupPercent = 0

                End If

            Next

            EstimateFunctionCodes = (From EST In EstimateRevisionDetailList
                                     Select EST.FunctionCode).ToList

            FunctionCodesWithoutEstimate = (From Entity In JobComponentFunctionDetails
                                            Where EstimateFunctionCodes.Contains(Entity.FunctionCode) = False
                                            Select Entity.FunctionCode).ToList

            For Each FunctionCode In FunctionCodesWithoutEstimate

                If JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode AndAlso JCF.BilledTotal.GetValueOrDefault(0) <> 0).SingleOrDefault IsNot Nothing Then

                    AdvanceBillingItem = AdvanceBillingItemList.Where(Function(AB) AB.FunctionCode = FunctionCode).FirstOrDefault

                    If AdvanceBillingItem IsNot Nothing Then

                        AdvanceBillingItem.QuantityHours = Nothing
                        AdvanceBillingItem.Rate = Nothing

                        AdvanceBillingItem.NetAmount = -JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.TotalBilledAmount
                        AdvanceBillingItem.ExtendedMarkupAmount = -JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.BilledMarkup.GetValueOrDefault(0)

                        AdvanceBillingItem.CalculateAdvanceBilling(Session, True, True)

                    Else

                        AdvanceBilling = Nothing

                        AdvanceBilling = New AdvantageFramework.Database.Entities.AdvanceBilling

                        AdvanceBillingItem = New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem()

                        AdvanceBillingItem.InitializeAdvanceBilling(Session.UserCode, JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.JobNumber, JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.ComponentNumber)

                        AdvanceBillingItem.SetAdvanceBillingFunctionCode(DbContext, FunctionCode)

                        AdvanceBillingItem.NetAmount = -JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.TotalBilledAmount
                        AdvanceBillingItem.ExtendedMarkupAmount = -JobComponentFunctionDetails.Where(Function(JCF) JCF.FunctionCode = FunctionCode).SingleOrDefault.BilledMarkup.GetValueOrDefault(0)

                        AdvanceBillingItem.CalculateAdvanceBilling(Session, True, True)

                        AdvanceBillingItem.AdvanceBilling.CalculatePercent = AdvanceBillPercentToQuote.PercentToQuote

                        AdvanceBillingItemList.Add(AdvanceBillingItem)

                    End If

                    If AdvanceBillingItem.MarkupPercent.HasValue AndAlso AdvanceBillingItem.MarkupPercent.Value > 999999.999 Then

                        AdvanceBillingItem.MarkupPercent = 0

                    End If

                End If

            Next

        End Sub
        Public Sub InitializeAdvanceBilling(ByRef AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling, ByVal EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval,
                                             ByVal FunctionCode As String, ByVal FunctionType As String, ByVal UserCode As String)

            AdvanceBilling.DatabaseAction = AdvantageFramework.Database.Action.Inserting

            AdvanceBilling.BillDate = Now.ToShortDateString
            AdvanceBilling.AdvanceBillFlag = 2
            AdvanceBilling.CreateDate = Now.ToShortDateString
            AdvanceBilling.UserCode = UserCode
            AdvanceBilling.JobNumber = EstimateApproval.JobNumber
            AdvanceBilling.JobComponentNumber = EstimateApproval.JobComponentNumber
            AdvanceBilling.FunctionCode = FunctionCode
            AdvanceBilling.FunctionType = FunctionType

        End Sub
        Public Sub SaveAdvanceBilling(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal JobNumber As Integer, JobComponentNumber As Short,
                                      ByVal AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem),
                                      ByVal BillingCommandCenterID As Integer, ByVal CalculatePercent As Decimal)

            Dim AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem = Nothing
            Dim AdvanceBillingID As Integer = 0
            Dim AdvanceBilling As AdvantageFramework.Database.Entities.AdvanceBilling = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ABIncomeFlag As Short = Nothing

            AdvanceBillingID = GetExistingAdvanceBillingID(DbContext, JobNumber, JobComponentNumber)

            For Each AdvanceBillingItem In AdvanceBillingItemList

                AdvanceBilling = AdvanceBillingItem.AdvanceBilling
                AdvanceBilling.DbContext = DbContext

                AdvanceBilling.CalculatePercent = CalculatePercent

                If AdvanceBilling.ID = 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.LineTotal.GetValueOrDefault(0) <> 0 Then

                    If AdvanceBilling.ID = 0 AndAlso AdvanceBillingID <> 0 Then

                        AdvanceBilling.ID = AdvanceBillingID

                    End If

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    AdvanceBilling.BillingCommandCenterID = BillingCommandCenterID
                    AdvanceBilling.BillingUserCode = If(JobComponent IsNot Nothing, JobComponent.BillingUserCode, Nothing)

                    If AdvantageFramework.Database.Procedures.AdvanceBilling.Insert(DbContext, AdvanceBilling) = False Then

                        Throw New Exception("Failed to insert advance billing.")

                    ElseIf AdvanceBillingID = 0 Then

                        AdvanceBillingID = AdvanceBilling.ID

                    End If

                ElseIf AdvanceBilling.ID <> 0 AndAlso AdvanceBilling.SequenceNumber <> 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.LineTotal.GetValueOrDefault(0) <> 0 Then

                    If AdvantageFramework.Database.Procedures.AdvanceBilling.Update(DbContext, AdvanceBilling) = False Then

                        Throw New Exception("Failed to update advance billing.")

                    End If

                ElseIf AdvanceBilling.ID <> 0 AndAlso AdvanceBilling.SequenceNumber <> 0 AndAlso String.IsNullOrWhiteSpace(AdvanceBilling.FunctionCode) = False AndAlso AdvanceBilling.LineTotal.GetValueOrDefault(0) = 0 Then

                    If AdvantageFramework.Database.Procedures.AdvanceBilling.Delete(DbContext, AdvanceBilling) = False Then

                        Throw New Exception("Failed to delete from advance billing.")

                    End If

                End If

            Next

            Try

                ABIncomeFlag = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber).Office.ProductionAdvancedBillingIncome.GetValueOrDefault(1)

            Catch ex As Exception
                ABIncomeFlag = 1
            End Try

            UpdateJobComponentBasedOnAdvanceBilling(DbContext, JobNumber, JobComponentNumber, ABIncomeFlag, False)

        End Sub
        Public Function GetExistingAdvanceBillingID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Integer

            Dim AdvanceBillingID As Integer = 0

            AdvanceBillingID = DbContext.Database.SqlQuery(Of Integer)(String.Format("select [dbo].[advfn_bcc_get_advance_billing_id] ({0},{1})", JobNumber, JobComponentNumber)).SingleOrDefault

            GetExistingAdvanceBillingID = AdvanceBillingID

        End Function
        Public Sub UpdateJobComponentBasedOnAdvanceBilling(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                           ByVal ABIncomeFlag As Short, ForceIncomeMethodUpdate As Boolean)

            Dim AdvanceBillRowsExist As Boolean = True

            If AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext).Where(Function(AB) AB.JobNumber = JobNumber AndAlso AB.JobComponentNumber = JobComponentNumber AndAlso AB.ARInvoiceNumber Is Nothing).Any = False AndAlso
                    AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext).Where(Function(IR) IR.JobNumber = JobNumber AndAlso IR.JobComponentNumber = JobComponentNumber AndAlso IR.ARInvoiceNumber Is Nothing).Any = False Then

                If AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext).Where(Function(AB) AB.JobNumber = JobNumber AndAlso AB.JobComponentNumber = JobComponentNumber AndAlso (AB.ARInvoiceIsVoided Is Nothing OrElse AB.ARInvoiceIsVoided = 0)).Any OrElse
                        AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext).Where(Function(IR) IR.JobNumber = JobNumber AndAlso IR.JobComponentNumber = JobComponentNumber AndAlso (IR.IsVoided Is Nothing OrElse IR.IsVoided = 0)).Any Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET AB_FLAG = 2 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber))

                    AdvantageFramework.BillingCommandCenter.SetAdvanceBillFlagInDetailTables(DbContext, JobNumber, JobComponentNumber)

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET AB_FLAG = 0, PRD_AB_INCOME = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber))

                    AdvantageFramework.BillingCommandCenter.ClearAdvanceBillFlagInDetailTables(DbContext, JobNumber, JobComponentNumber)

                    AdvanceBillRowsExist = False

                End If

            Else

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET AB_FLAG = 2 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber))

                AdvantageFramework.BillingCommandCenter.SetAdvanceBillFlagInDetailTables(DbContext, JobNumber, JobComponentNumber)

            End If

            If ForceIncomeMethodUpdate AndAlso AdvanceBillRowsExist Then

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET PRD_AB_INCOME = {2} WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber, ABIncomeFlag))

            ElseIf AdvanceBillRowsExist Then

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_COMPONENT SET PRD_AB_INCOME = CASE WHEN PRD_AB_INCOME IS NULL THEN {2} ELSE PRD_AB_INCOME END WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber, ABIncomeFlag))

            End If

        End Sub
        Public Function GetBillingCommandCenterInvoiceDatePostPeriod(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingUserCode As String) As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod

            Dim BillingCommandCenterInvoiceDatePostPeriod As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod = Nothing

            Try

                BillingCommandCenterInvoiceDatePostPeriod = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingCommandCenterInvoiceDatePostPeriod)(String.Format("exec dbo.advsp_bill_cmd_ctr_inv_pp '{0}'", BillingUserCode)).FirstOrDefault

            Catch ex As Exception
                BillingCommandCenterInvoiceDatePostPeriod = Nothing
            End Try

            GetBillingCommandCenterInvoiceDatePostPeriod = BillingCommandCenterInvoiceDatePostPeriod

        End Function
        Public Function GetBillingHistory(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, JobNumber As Integer, JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory)

            Dim BillingHistoryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory) = Nothing

            Try

                BillingHistoryList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.BillingHistory)(String.Format("exec dbo.advsp_bcc_get_billing_history {0}, {1}", JobNumber, JobComponentNumber)).ToList

            Catch ex As Exception
                BillingHistoryList = Nothing
            End Try

            GetBillingHistory = BillingHistoryList

        End Function
        Public Function GetInvoiceAssigned(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingUser As String) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned)

            Dim InvoiceAssignedList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned) = Nothing

            Try

                InvoiceAssignedList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssigned)(String.Format("exec dbo.advsp_bcc_get_inv_assigned '{0}'", BillingUser)).ToList

            Catch ex As Exception
                InvoiceAssignedList = Nothing
            End Try

            GetInvoiceAssigned = InvoiceAssignedList

        End Function
        Public Function GetInvoiceAssignedCoop(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingUser As String,
                                               JobNumber As Integer, JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoop)

            Dim InvoiceAssignedCoopList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoop) = Nothing

            Try

                InvoiceAssignedCoopList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoop)(String.Format("exec dbo.advsp_get_bcc_coop_dist_prod '{0}', {1}, {2}", BillingUser, JobNumber, JobComponentNumber)).ToList

            Catch ex As Exception
                InvoiceAssignedCoopList = Nothing
            End Try

            GetInvoiceAssignedCoop = InvoiceAssignedCoopList

        End Function
        Public Function GetInvoiceAssignedCoopJob(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingUser As String) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoopJob)

            Dim InvoiceAssignedCoopJobList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoopJob) = Nothing

            Try

                InvoiceAssignedCoopJobList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedCoopJob)(String.Format("exec dbo.advsp_bcc_get_coop_jobs '{0}'", BillingUser)).ToList

            Catch ex As Exception
                InvoiceAssignedCoopJobList = Nothing
            End Try

            GetInvoiceAssignedCoopJob = InvoiceAssignedCoopJobList

        End Function
        Public Function GetInvoiceAssignedJournalEntry(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingUser As String) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedJournalEntry)

            Dim InvoiceAssignedJournalEntryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedJournalEntry) = Nothing

            Try

                InvoiceAssignedJournalEntryList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.InvoiceAssignedJournalEntry)(String.Format("exec dbo.advsp_bcc_get_journal_entries '{0}'", BillingUser)).ToList

            Catch ex As Exception
                InvoiceAssignedJournalEntryList = Nothing
            End Try

            GetInvoiceAssignedJournalEntry = InvoiceAssignedJournalEntryList

        End Function
        Public Function GetOtherUsersMediaSelection(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection)

            Dim OtherUsersMediaSelectionList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection) = Nothing

            Try

                OtherUsersMediaSelectionList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersMediaSelection)(String.Format("exec dbo.advsp_bcc_other_user_media {0}", BillingCommandCenterID)).ToList

            Catch ex As Exception
                OtherUsersMediaSelectionList = Nothing
            End Try

            GetOtherUsersMediaSelection = OtherUsersMediaSelectionList

        End Function
        Public Function GetOtherUsersProductionSelection(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection)

            Dim OtherUsersProductionSelectionList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection) = Nothing

            Try

                OtherUsersProductionSelectionList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.OtherUsersProductionSelection)(String.Format("exec dbo.advsp_bcc_other_user_prod {0}", BillingCommandCenterID)).ToList

            Catch ex As Exception
                OtherUsersProductionSelectionList = Nothing
            End Try

            GetOtherUsersProductionSelection = OtherUsersProductionSelectionList

        End Function
        Public Function GetProductionJob(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionJob)

            Dim ProductionJobList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionJob) = Nothing

            Try

                ProductionJobList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionJob)(String.Format("exec dbo.advsp_bill_cmd_ctr_prod_job_list {0}", BillingCommandCenterID)).ToList

            Catch ex As Exception
                ProductionJobList = Nothing
            End Try

            GetProductionJob = ProductionJobList

        End Function
        Public Function GetProductionReconcileInterimDetail(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, JobNumber As Integer,
                                                            JobComponentNumber As Short, BillingApprovalID As Integer?,
                                                            EmployeeTimeDateCutoff As Date?, IncomeOnlyDateCutoff As Date?, APPostPeriodCutoff As String) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionReconcileInterimDetail)

            'objects
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingApprovalID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeTimeDateCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncomeOnlyDateCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPPostPeriodCutoff As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@job_number", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@job_component_nbr", SqlDbType.SmallInt)
            SqlParameterBillingApprovalID = New System.Data.SqlClient.SqlParameter("@ba_id", SqlDbType.Int)
            SqlParameterEmployeeTimeDateCutoff = New System.Data.SqlClient.SqlParameter("@et_cutoff_date", SqlDbType.SmallDateTime)
            SqlParameterIncomeOnlyDateCutoff = New System.Data.SqlClient.SqlParameter("@io_cutoff_date", SqlDbType.SmallDateTime)
            SqlParameterAPPostPeriodCutoff = New System.Data.SqlClient.SqlParameter("@ap_cutoff_pp", SqlDbType.VarChar)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber

            If BillingApprovalID IsNot Nothing Then

                SqlParameterBillingApprovalID.Value = BillingApprovalID

            Else

                SqlParameterBillingApprovalID.Value = System.DBNull.Value

            End If

            If EmployeeTimeDateCutoff IsNot Nothing Then

                SqlParameterEmployeeTimeDateCutoff.Value = EmployeeTimeDateCutoff

            Else

                SqlParameterEmployeeTimeDateCutoff.Value = System.DBNull.Value

            End If

            If IncomeOnlyDateCutoff IsNot Nothing Then

                SqlParameterIncomeOnlyDateCutoff.Value = IncomeOnlyDateCutoff

            Else

                SqlParameterIncomeOnlyDateCutoff.Value = System.DBNull.Value

            End If

            If APPostPeriodCutoff IsNot Nothing Then

                SqlParameterAPPostPeriodCutoff.Value = APPostPeriodCutoff

            Else

                SqlParameterAPPostPeriodCutoff.Value = System.DBNull.Value

            End If

            GetProductionReconcileInterimDetail = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionReconcileInterimDetail)("exec dbo.advsp_populate_interim_rec_dtl @job_number, @job_component_nbr, @ba_id, @et_cutoff_date, @io_cutoff_date, @ap_cutoff_pp",
                SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterBillingApprovalID, SqlParameterEmployeeTimeDateCutoff, SqlParameterIncomeOnlyDateCutoff, SqlParameterAPPostPeriodCutoff).ToList

        End Function
        Public Function GetProductionSelectionByAccountExecutive(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                                 MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByAccountExecutive)

            Dim ProductionSelectionByAccountExecutiveList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByAccountExecutive) = Nothing

            Try

                ProductionSelectionByAccountExecutiveList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByAccountExecutive) _
                    (String.Format("exec dbo.advsp_bill_select_acct_exec {0}, {1}, {2}", BillingCommandCenterID, If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByAccountExecutiveList = Nothing
            End Try

            GetProductionSelectionByAccountExecutive = ProductionSelectionByAccountExecutiveList

        End Function
        Public Function GetProductionSelectionByBillingApproval(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                                BillApprovalBatchID As Integer?, Finished As Boolean, MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval)

            Dim ProductionSelectionByBillingApprovalList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval) = Nothing

            Try

                ProductionSelectionByBillingApprovalList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByBillingApproval) _
                    (String.Format("exec dbo.advsp_bill_select_bill_appr {0}, {1}, {2}, {3}, {4}", BillingCommandCenterID, If(BillApprovalBatchID.HasValue, BillApprovalBatchID, "NULL"), If(Finished, 1, 0),
                                    If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByBillingApprovalList = Nothing
            End Try

            GetProductionSelectionByBillingApproval = ProductionSelectionByBillingApprovalList

        End Function
        Public Function GetProductionSelectionByClient(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                       BillApprovalBatchID As Integer?, MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClient)

            Dim ProductionSelectionByClientList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClient) = Nothing

            Try

                ProductionSelectionByClientList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClient) _
                    (String.Format("exec dbo.advsp_bill_select_client {0}, {1}, {2}, {3}", BillingCommandCenterID, If(BillApprovalBatchID.HasValue, BillApprovalBatchID, "NULL"),
                            If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByClientList = Nothing
            End Try

            GetProductionSelectionByClient = ProductionSelectionByClientList

        End Function
        Public Function GetProductionSelectionByClientDivision(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                               MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision)

            Dim ProductionSelectionByClientDivisionList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision) = Nothing

            Try

                ProductionSelectionByClientDivisionList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivision) _
                    (String.Format("exec dbo.advsp_bill_select_cli_div {0}, {1}, {2}", BillingCommandCenterID, If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByClientDivisionList = Nothing
            End Try

            GetProductionSelectionByClientDivision = ProductionSelectionByClientDivisionList

        End Function
        Public Function GetProductionSelectionByClientDivisionProduct(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                                      MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct)

            Dim ProductionSelectionByClientDivisionProductList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct) = Nothing

            Try

                ProductionSelectionByClientDivisionProductList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientDivisionProduct) _
                    (String.Format("exec dbo.advsp_bill_select_cli_div_prd {0}, {1}, {2}", BillingCommandCenterID, If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByClientDivisionProductList = Nothing
            End Try

            GetProductionSelectionByClientDivisionProduct = ProductionSelectionByClientDivisionProductList

        End Function
        Public Function GetProductionSelectionByCampaign(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                         MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign)

            Dim ProductionSelectionByCampaignList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign) = Nothing

            Try

                ProductionSelectionByCampaignList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByCampaign) _
                    (String.Format("exec dbo.advsp_bill_select_campaign {0}, {1}, {2}", BillingCommandCenterID,
                                    If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByCampaignList = Nothing
            End Try

            GetProductionSelectionByCampaign = ProductionSelectionByCampaignList

        End Function
        Public Function GetProductionSelectionBySalesClass(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                           MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass)

            Dim ProductionSelectionBySalesClassList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass) = Nothing

            Try

                ProductionSelectionBySalesClassList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionBySalesClass) _
                    (String.Format("exec dbo.advsp_bill_select_sales_class {0}, {1}, {2}", BillingCommandCenterID, If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionBySalesClassList = Nothing
            End Try

            GetProductionSelectionBySalesClass = ProductionSelectionBySalesClassList

        End Function
        Public Function GetProductionSelectionByJob(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                    BillApprovalBatchID As Integer?, MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob)

            Dim ProductionSelectionByJobList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob) = Nothing

            Try

                ProductionSelectionByJobList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJob) _
                    (String.Format("exec dbo.advsp_bill_select_job {0}, {1}, {2}, {3}", BillingCommandCenterID, If(BillApprovalBatchID.HasValue, BillApprovalBatchID, "NULL"),
                                    If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByJobList = Nothing
            End Try

            GetProductionSelectionByJob = ProductionSelectionByJobList

        End Function
        Public Function GetProductionSelectionByJobComponent(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                    BillApprovalBatchID As Integer?, BillingUserCode As String, MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent)

            Dim ProductionSelectionByJobComponentList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent) = Nothing

            Try

                ProductionSelectionByJobComponentList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByJobComponent) _
                    (String.Format("exec dbo.advsp_bill_select_comp {0}, {1}, '{2}', {3}, {4}", BillingCommandCenterID, If(BillApprovalBatchID.HasValue, BillApprovalBatchID, "NULL"), BillingUserCode,
                                    If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByJobComponentList = Nothing
            End Try

            GetProductionSelectionByJobComponent = ProductionSelectionByJobComponentList

        End Function
        Public Function OkayToDeleteBatch(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, BillingCommandCenterID As Integer, BillingUser As String, BatchName As String,
                                          ByRef Message As String) As Boolean

            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
            Dim Billing As AdvantageFramework.Database.Entities.Billing = Nothing
            Dim OkayToDelete As Boolean = False

            BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, BillingCommandCenterID)

            If BillingCommandCenter IsNot Nothing Then

                BillingStatus = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingStatusComplexType.Load(BCCDbContext, BillingUser)

                If BillingStatus IsNot Nothing AndAlso BillingStatus.IsAssigned = 1 Then

                    AdvantageFramework.Navigation.ShowMessageBox("Invoice numbers have been assigned.  Billing must be finished before the selection can be modified or deleted.")

                Else

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete batch '" & BatchName & "'?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        OkayToDelete = True

                        Billing = AdvantageFramework.Database.Procedures.Billing.LoadByBillingUserCode(DataContext, BillingUser)

                        If Billing IsNot Nothing AndAlso (Billing.IsMedia.GetValueOrDefault(0) = 1 OrElse Billing.IsProduction.GetValueOrDefault(0) = 1) Then

                            Message = "You currently have items selected for billing."

                            If Billing.IsMedia.GetValueOrDefault(0) = 1 AndAlso Billing.IsProduction.GetValueOrDefault(0) = 1 Then

                                Message += "  If you continue, your media billing selection will be cleared, any temporary bill holds will be removed, and any co-op modifications will be reset to the job default."

                            ElseIf Billing.IsMedia.GetValueOrDefault(0) = 1 Then

                                Message += "  If you continue, your media billing selection will be cleared."

                            ElseIf Billing.IsProduction.GetValueOrDefault(0) = 1 Then

                                Message += "  If you continue, your billing selection will be cleared, any temporary bill holds will be removed, and any co-op modifications will be reset to the job default."

                            End If

                            Message += "   Are you sure you wish to delete the current selection?"

                        ElseIf BillingCommandCenter.IsProduction.GetValueOrDefault(False) = True Then

                            Message = "If you continue, any temporary bill holds will be removed."

                        End If

                    End If

                End If

            End If

            OkayToDeleteBatch = OkayToDelete

        End Function
        Public Sub UpdateJobComponentClientPO(ByVal Session As AdvantageFramework.Security.Session, ByVal JobComponentClientPO As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterJobComponentClientPO As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.JOB_COMPONENT SET JOB_CL_PO_NBR = @JobComponentClientPO WHERE JOB_NUMBER = @JobNumber AND JOB_COMPONENT_NBR = @JobComponentNumber"

            SqlParameterJobComponentClientPO = New System.Data.SqlClient.SqlParameter("@JobComponentClientPO", SqlDbType.VarChar)
            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)

            If String.IsNullOrWhiteSpace(JobComponentClientPO) Then

                SqlParameterJobComponentClientPO.Value = System.DBNull.Value

            Else

                SqlParameterJobComponentClientPO.Value = JobComponentClientPO

            End If

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BCCDbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterJobComponentClientPO, SqlParameterJobNumber, SqlParameterJobComponentNumber)

            End Using

        End Sub
        Public Function GetProductionSelectionByClientBiller(BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, BillingCommandCenterID As Integer,
                                                             BillApprovalBatchID As Integer?, BillingUserCode As String, MediaDateFrom As Date?, MediaDateTo As Date?) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientBiller)

            Dim ProductionSelectionByClientBillerList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientBiller) = Nothing

            Try

                ProductionSelectionByClientBillerList = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Database.Classes.ProductionSelectionByClientBiller) _
                    (String.Format("exec dbo.advsp_bill_select_client_biller {0}, {1}, {2}, {3}", BillingCommandCenterID, If(BillApprovalBatchID.HasValue, BillApprovalBatchID, "NULL"),
                    If(MediaDateFrom.HasValue, "'" & MediaDateFrom.Value & "'", "NULL"), If(MediaDateTo.HasValue, "'" & MediaDateTo.Value & "'", "NULL"))).ToList

            Catch ex As Exception
                ProductionSelectionByClientBillerList = Nothing
            End Try

            GetProductionSelectionByClientBiller = ProductionSelectionByClientBillerList

        End Function

#End Region

#Region "  Adjustments & Transfers "

        Public Function GetAccountPayableProductionItems(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                         ByVal FunctionCodeList As IEnumerable(Of String), ByVal APPostPeriodCodeCutoff As String,
                                                         SelectMode As AdvantageFramework.BillingCommandCenter.ProductionSelectFor,
                                                         ProductionLock As Boolean) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)

            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAPPostPeriodCodeCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectMode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingProductionLock As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
            SqlParameterAPPostPeriodCodeCutoff = New System.Data.SqlClient.SqlParameter("@APPostPeriodCodeCutoff", SqlDbType.VarChar)
            SqlParameterFunctionCodeList = New System.Data.SqlClient.SqlParameter("@FunctionCode", SqlDbType.VarChar)
            SqlParameterSelectMode = New System.Data.SqlClient.SqlParameter("@SelectMode", SqlDbType.SmallInt)
            SqlParameterBillingProductionLock = New System.Data.SqlClient.SqlParameter("@ProductionLock", SqlDbType.Bit)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterAPPostPeriodCodeCutoff.Value = APPostPeriodCodeCutoff
            SqlParameterSelectMode.Value = CShort(SelectMode)
            SqlParameterBillingProductionLock.Value = ProductionLock

            If FunctionCodeList Is Nothing Then

                SqlParameterFunctionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterFunctionCodeList.Value = String.Join("|", FunctionCodeList.ToArray)

            End If

            GetAccountPayableProductionItems = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem)("exec dbo.advsp_bcc_job_details_get_vendor_ap @JobNumber, @JobComponentNumber, @APPostPeriodCodeCutoff, @FunctionCode, @SelectMode, @ProductionLock",
                                                                               SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterAPPostPeriodCodeCutoff, SqlParameterFunctionCodeList, SqlParameterSelectMode, SqlParameterBillingProductionLock).ToList

        End Function
        Public Function GetEmployeeTimeItems(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext,
                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                             ByVal FunctionCodeList As IEnumerable(Of String), ByVal EmployeeTimeDateCutoff As Date,
                                             ProductionLock As Boolean) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)

            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeTimeDateCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingProductionLock As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
            SqlParameterEmployeeTimeDateCutoff = New System.Data.SqlClient.SqlParameter("@EmployeeTimeDateCutoff", SqlDbType.SmallDateTime)
            SqlParameterFunctionCodeList = New System.Data.SqlClient.SqlParameter("@FunctionCode", SqlDbType.VarChar)
            SqlParameterBillingProductionLock = New System.Data.SqlClient.SqlParameter("@ProductionLock", SqlDbType.Bit)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterEmployeeTimeDateCutoff.Value = EmployeeTimeDateCutoff
            SqlParameterBillingProductionLock.Value = ProductionLock

            If FunctionCodeList Is Nothing Then

                SqlParameterFunctionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterFunctionCodeList.Value = String.Join("|", FunctionCodeList.ToArray)

            End If

            GetEmployeeTimeItems = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem)("exec dbo.advsp_bcc_job_details_get_employee_time @JobNumber, @JobComponentNumber, @EmployeeTimeDateCutoff, @FunctionCode, @ProductionLock",
                                                                   SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterEmployeeTimeDateCutoff, SqlParameterFunctionCodeList, SqlParameterBillingProductionLock).ToList

        End Function
        Public Function GetIncomeOnlyItems(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                           ByVal FunctionCodeList As IEnumerable(Of String), ByVal IncomeOnlyDateCutoff As Date,
                                           ProductionLock As Boolean,
                                           SelectMode As AdvantageFramework.BillingCommandCenter.IncomeOnlySelectFor) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)

            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncomeOnlyDateCutoff As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFunctionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillingProductionLock As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectMode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
            SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
            SqlParameterIncomeOnlyDateCutoff = New System.Data.SqlClient.SqlParameter("@IncomeOnlyDateCutoff", SqlDbType.SmallDateTime)
            SqlParameterFunctionCodeList = New System.Data.SqlClient.SqlParameter("@FunctionCode", SqlDbType.VarChar)
            SqlParameterBillingProductionLock = New System.Data.SqlClient.SqlParameter("@ProductionLock", SqlDbType.Bit)
            SqlParameterSelectMode = New System.Data.SqlClient.SqlParameter("@SelectMode", SqlDbType.SmallInt)

            SqlParameterJobNumber.Value = JobNumber
            SqlParameterJobComponentNumber.Value = JobComponentNumber
            SqlParameterIncomeOnlyDateCutoff.Value = IncomeOnlyDateCutoff
            SqlParameterBillingProductionLock.Value = ProductionLock
            SqlParameterSelectMode.Value = CShort(SelectMode)

            If FunctionCodeList Is Nothing Then

                SqlParameterFunctionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterFunctionCodeList.Value = String.Join("|", FunctionCodeList.ToArray)

            End If

            GetIncomeOnlyItems = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem)("exec dbo.advsp_bcc_job_details_get_income_only @JobNumber, @JobComponentNumber, @IncomeOnlyDateCutoff, @FunctionCode, @ProductionLock, @SelectMode",
                                                                 SqlParameterJobNumber, SqlParameterJobComponentNumber, SqlParameterIncomeOnlyDateCutoff, SqlParameterFunctionCodeList, SqlParameterBillingProductionLock, SqlParameterSelectMode).ToList

        End Function
        Public Sub TransferAP(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCommandCenterID As Integer,
                              ByVal AccountPayableProductionItem As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableProductionItem,
                              ByVal TransferToClientCode As String, ByVal TransferToDivisionCode As String, ByVal TransferToProductCode As String, ByVal TransferToJobNumber As Integer,
                              ByVal TransferToJobComponentNumber As Short, ByVal TransferToFunctionCode As String, ByVal TransferToGLACode As String, ByVal PostPeriodCode As String, ByVal AgencyInvoiceTaxFlag As Boolean,
                              Optional ByVal TransferMarkupPercent As Nullable(Of AdvantageFramework.BillingCommandCenter.TransferMarkupPercent) = Nothing,
                              Optional ByVal TransferToAmount As Nullable(Of Decimal) = Nothing,
                              Optional ByVal AdjustmentComments As String = Nothing,
                              Optional ByVal TransferToQuantity As Nullable(Of Decimal) = Nothing,
                              Optional ByVal TransferToRate As Nullable(Of Decimal) = Nothing)

            'objects
            Dim GLSourceCode As String = Nothing
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim GLDescription As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim AccountPayableProductionDistributionDetail As AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim AccountPayableProductionTransferTo As AdvantageFramework.Database.Entities.AccountPayableProduction = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim Remark As String = Nothing
            Dim IsBalanced As Integer = -1
            Dim JobComponents As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing
            Dim HasVendorTax As Boolean = False
            Dim CommentToTransfer As String = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            GLSourceCode = "BT"

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableProductionItem.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            If AccountPayable Is Nothing Then

                Throw New Exception("Cannot find AP record.")

            End If

            AccountPayableProduction = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext).Include("Job")
                                        Where Entity.AccountPayableID = AccountPayableProductionItem.AccountPayableID AndAlso
                                              Entity.LineNumber = AccountPayableProductionItem.LineNumber AndAlso
                                              (Entity.ModifyDelete Is Nothing OrElse Entity.ModifyDelete = 0)
                                        Select Entity).SingleOrDefault

            If AccountPayableProduction Is Nothing Then

                Throw New Exception("Cannot find AP to transfer.")

            End If

            AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)

            AccountPayableProductionDistributionDetail = New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, AccountPayableProduction, Session)
            AccountPayableProductionDistributionDetail.AccountPayableProduction.AdjustmentComments = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferAdjustmentDate = Now
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferAdjustmentUserCode = DbContext.UserCode
            AccountPayableProductionDistributionDetail.AccountPayableProduction.PostPeriodCode = PostPeriodCode
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromJobNumber = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromJobComponentNumber = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromFunctionCode = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromAccountPayableID = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromAccountPayableSequenceNumber = Nothing
            AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferFromLineNumber = Nothing

            If TransferToAmount.HasValue AndAlso AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0) <> TransferToAmount Then

                AccountPayableProductionDistributionDetail.ExtendedAmount = AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) - TransferToAmount

                If TransferToQuantity.HasValue AndAlso AccountPayableProductionDistributionDetail.Quantity.HasValue Then

                    AccountPayableProductionDistributionDetail.Quantity = AccountPayableProductionDistributionDetail.Quantity - TransferToQuantity

                End If

                AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount, AccountPayableProductionDistributionDetail, DbContext)

                AccountPayableProductionDistributionDetail.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionDistributionDetail.ExtendedAmount.GetValueOrDefault(0) *
                                                                                               AccountPayableProductionDistributionDetail.CommissionPercent.GetValueOrDefault(0) / 100, 2)

                AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTax(DbContext, AccountPayableProductionDistributionDetail.AccountPayableProduction)

                SetBillingCommandCenterIDandUser(DbContext, BillingCommandCenterID, AccountPayableProductionDistributionDetail.JobNumber, AccountPayableProductionDistributionDetail.JobComponentNumber, AccountPayableProductionDistributionDetail.AccountPayableProduction.BillingCommandCenterID, AccountPayableProductionDistributionDetail.AccountPayableProduction.BillingUserCode)

                AccountPayableProductionDistributionDetail.AccountPayableProduction.CreatedBy = DbContext.UserCode
                AccountPayableProductionDistributionDetail.AccountPayableProduction.CreateDate = Now

            Else

                AccountPayableProductionDistributionDetail.IsDeleted = True

            End If

            AccountPayableProductionDistributionDetailList.Add(AccountPayableProductionDistributionDetail)

            CommentToTransfer = AccountPayableProductionDistributionDetail.Comment

            'GL Header
            GLDescription = "A/P Transfer - Vendor:" & AccountPayable.VendorCode & ", Inv:" & AccountPayable.InvoiceNumber & ", Frm Job/Comp:" &
                AccountPayableProduction.JobNumber & "/" & AccountPayableProduction.JobComponentNumber

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, Nothing) = False Then

                Throw New Exception("Failed trying to save data to General Ledger.")

            End If

            AccountPayableProductionDistributionDetailList.AddRange(From APP In AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayableProductionItem.AccountPayableID).ToList
                                                                    Where APP.LineNumber <> AccountPayableProductionDistributionDetail.LineNumber
                                                                    Select New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, APP, Session))

            JobComponents = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            'new row (Transfer To)
            If TransferToFunctionCode Is Nothing Then

                TransferToFunctionCode = AccountPayableProduction.FunctionCode

            End If

            AccountPayableProductionTransferTo = New AdvantageFramework.Database.Entities.AccountPayableProduction

            AccountPayableProductionTransferTo.AccountPayableID = AccountPayableProduction.AccountPayableID

            AccountPayableProductionTransferTo.GLTransaction = AccountPayableProduction.GLTransaction
            AccountPayableProductionTransferTo.GLSequenceNumber = AccountPayableProduction.GLSequenceNumber
            AccountPayableProductionTransferTo.AccountPayableSequenceNumber = AccountPayableProduction.AccountPayableSequenceNumber
            AccountPayableProductionTransferTo.DepartmentTeamCode = AccountPayableProduction.DepartmentTeamCode

            If AccountPayableProduction.PONumber.HasValue Then

                If (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, AccountPayableProduction.PONumber.Value)
                    Where Entity.JobNumber IsNot Nothing AndAlso Entity.JobNumber = TransferToJobNumber).Any = False Then

                    AccountPayableProductionTransferTo.PONumber = Nothing
                    AccountPayableProductionTransferTo.PODetailLineNumber = Nothing
                    AccountPayableProductionTransferTo.IsPOComplete = Nothing

                Else

                    AccountPayableProductionTransferTo.PONumber = AccountPayableProduction.PONumber
                    AccountPayableProductionTransferTo.PODetailLineNumber = AccountPayableProduction.PODetailLineNumber
                    AccountPayableProductionTransferTo.IsPOComplete = AccountPayableProduction.IsPOComplete

                End If

            End If

            'If (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByJobNumber(DbContext, TransferToJobNumber).ToList
            '    Where Entity.IsComplete.GetValueOrDefault(0) = 0).Any = False Then

            '    AccountPayableProductionTransferTo.IsPOComplete = True

            'Else

            '    AccountPayableProductionTransferTo.IsPOComplete = False

            'End If

            AccountPayableProductionTransferTo.JobNumber = TransferToJobNumber
            AccountPayableProductionTransferTo.JobComponentNumber = TransferToJobComponentNumber
            AccountPayableProductionTransferTo.FunctionCode = TransferToFunctionCode

            AccountPayableProductionTransferTo.ExtendedAmount = If(TransferToAmount Is Nothing, AccountPayableProduction.ExtendedAmount.GetValueOrDefault(0), TransferToAmount)
            AccountPayableProductionTransferTo.Quantity = If(TransferToQuantity Is Nothing, AccountPayableProduction.Quantity, TransferToQuantity)
            AccountPayableProductionTransferTo.Rate = If(TransferToRate Is Nothing, AccountPayableProduction.Rate, TransferToRate)

            AccountPayableProductionTransferTo.AdjustmentComments = AdjustmentComments

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TransferToJobNumber)

            If Job Is Nothing Then

                Throw New Exception("Cannot find job.")

            End If

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, TransferToJobNumber, TransferToJobComponentNumber)

            If JobComponent Is Nothing Then

                Throw New Exception("Cannot find job component.")

            End If

            AccountPayableProductionTransferTo.IsAdvanceBilling = If(JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)

            'TransferMarkupPercent is only passed when transferring multiple AP items - we will only calculate BillingRate in this case, its already done in the transfer single item routine
            If TransferMarkupPercent IsNot Nothing Then

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, TransferToFunctionCode, TransferToClientCode, TransferToDivisionCode, TransferToProductCode, TransferToJobNumber, TransferToJobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                If TransferMarkupPercent = Methods.TransferMarkupPercent.RecalculateFromHierarchy Then

                    If BillingRate IsNot Nothing Then

                        AccountPayableProductionTransferTo.CommissionPercent = BillingRate.COMM.GetValueOrDefault(0)
                        AccountPayableProductionTransferTo.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        AccountPayableProductionTransferTo.SalesTaxCode = BillingRate.TAX_CODE
                        AccountPayableProductionTransferTo.TaxCommissions = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        AccountPayableProductionTransferTo.TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        AccountPayableProductionTransferTo.CommissionPercent = 0
                        AccountPayableProductionTransferTo.IsNonBillable = 0
                        AccountPayableProductionTransferTo.SalesTaxCode = Nothing
                        AccountPayableProductionTransferTo.TaxCommissions = 0
                        AccountPayableProductionTransferTo.TaxCommissionsOnly = 0

                    End If

                ElseIf TransferMarkupPercent = Methods.TransferMarkupPercent.TransferAsIs Then

                    AccountPayableProductionTransferTo.CommissionPercent = AccountPayableProductionItem.CommissionPercent

                    If BillingRate IsNot Nothing Then

                        AccountPayableProductionTransferTo.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        AccountPayableProductionTransferTo.SalesTaxCode = BillingRate.TAX_CODE
                        AccountPayableProductionTransferTo.TaxCommissions = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        AccountPayableProductionTransferTo.TaxCommissionsOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        AccountPayableProductionTransferTo.IsNonBillable = 0
                        AccountPayableProductionTransferTo.SalesTaxCode = Nothing
                        AccountPayableProductionTransferTo.TaxCommissions = 0
                        AccountPayableProductionTransferTo.TaxCommissionsOnly = 0

                    End If

                End If

                If AccountPayableProduction.ExtendedNonResaleTax.GetValueOrDefault(0) <> 0 Then

                    HasVendorTax = True

                    AccountPayableProductionTransferTo.ExtendedNonResaleTax = AccountPayableProductionItem.ExtendedNonResaleTax

                ElseIf AccountPayableProduction.ExtendedNonResaleTax.HasValue = False Then

                    AccountPayableProduction.ExtendedNonResaleTax = 0

                End If

                If AccountPayableProductionTransferTo.IsNonBillable.GetValueOrDefault(0) = 1 Then

                    AccountPayableProductionTransferTo.GLACode = TransferToGLACode

                Else

                    AccountPayableProductionTransferTo.GLACode = Job.Office.ProductionWorkInProgressGLACode

                End If

            Else

                AccountPayableProductionTransferTo.TaxCommissions = AccountPayableProductionItem.TaxCommissions
                AccountPayableProductionTransferTo.TaxCommissionsOnly = AccountPayableProductionItem.TaxCommissionsOnly
                AccountPayableProductionTransferTo.CommissionPercent = AccountPayableProductionItem.CommissionPercent
                AccountPayableProductionTransferTo.IsNonBillable = AccountPayableProductionItem.IsNonBillable
                AccountPayableProductionTransferTo.SalesTaxCode = AccountPayableProductionItem.SalesTaxCode

                AccountPayableProductionTransferTo.ExtendedNonResaleTax = AccountPayableProductionItem.ExtendedNonResaleTax

                AccountPayableProductionTransferTo.GLACode = TransferToGLACode

            End If

            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, AccountPayableProductionTransferTo.GLACode)

            If GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference IsNot Nothing Then

                AccountPayableProductionTransferTo.OfficeCode = GeneralLedgerAccount.GeneralLedgerOfficeCrossReference.OfficeCode

            ElseIf GeneralLedgerAccount IsNot Nothing AndAlso GeneralLedgerAccount.GeneralLedgerOfficeCrossReference Is Nothing Then

                Office = AdvantageFramework.Database.Procedures.Office.Load(DbContext).FirstOrDefault

                If Office IsNot Nothing Then

                    AccountPayableProductionTransferTo.OfficeCode = Office.Code

                End If

            End If

            AccountPayableProductionTransferTo.ExtendedMarkupAmount = FormatNumber(AccountPayableProductionTransferTo.CommissionPercent.GetValueOrDefault(0) * AccountPayableProductionTransferTo.ExtendedAmount.GetValueOrDefault(0) / 100, 2)

            AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTaxForTransfer(DbContext, AccountPayableProductionTransferTo.SalesTaxCode, AccountPayableProductionTransferTo, HasVendorTax, -1)

            AccountPayableProductionTransferTo.PostPeriodCode = PostPeriodCode

            AccountPayableProductionTransferTo.TransferFromJobNumber = AccountPayableProduction.JobNumber
            AccountPayableProductionTransferTo.TransferFromJobComponentNumber = AccountPayableProduction.JobComponentNumber
            AccountPayableProductionTransferTo.TransferFromFunctionCode = AccountPayableProduction.FunctionCode
            AccountPayableProductionTransferTo.TransferFromAccountPayableID = AccountPayableProduction.AccountPayableID
            AccountPayableProductionTransferTo.TransferFromAccountPayableSequenceNumber = AccountPayableProduction.AccountPayableSequenceNumber
            AccountPayableProductionTransferTo.TransferFromLineNumber = AccountPayableProduction.LineNumber

            AccountPayableProductionTransferTo.TransferAdjustmentUserCode = DbContext.UserCode
            AccountPayableProductionTransferTo.TransferAdjustmentDate = Now
            AccountPayableProductionTransferTo.SetLineTotal()

            AccountPayableProductionTransferTo.CreatedBy = DbContext.UserCode
            AccountPayableProductionTransferTo.CreateDate = Now

            SetBillingCommandCenterIDandUser(DbContext, BillingCommandCenterID, AccountPayableProductionTransferTo.JobNumber, AccountPayableProductionTransferTo.JobComponentNumber, AccountPayableProductionTransferTo.BillingCommandCenterID, AccountPayableProductionTransferTo.BillingUserCode)

            AccountPayableProductionTransferTo.ExtendedAmountForeign = 0
            AccountPayableProductionTransferTo.RateForeign = 0
            AccountPayableProductionTransferTo.NonResidentTaxForeign = 0
            AccountPayableProductionTransferTo.AmountExchange = 0

            AccountPayableProductionDistributionDetail = New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(Session)
            AccountPayableProductionDistributionDetail.SetValuesFromAccountPayableProduction(DbContext, AccountPayableProductionTransferTo)
            AccountPayableProductionDistributionDetail.Comment = CommentToTransfer

            AccountPayableProductionDistributionDetailList.Add(AccountPayableProductionDistributionDetail)

            Remark = "Transfers - Vendor:" & AccountPayable.VendorCode & ", Inv:" & AccountPayable.InvoiceNumber &
                ", Frm C/D/P:" & AccountPayableProduction.Job.ClientCode & "/" & AccountPayableProduction.Job.DivisionCode & "/" & AccountPayableProduction.Job.ProductCode &
                ", Frm Job/Comp:" & AccountPayableProduction.JobNumber & "/" & AccountPayableProduction.JobComponentNumber & ", Frm Fnc:" & AccountPayableProduction.FunctionCode

            AdvantageFramework.AccountPayable.SaveProduction(DbContext, GeneralLedger.Transaction, AccountPayable, AccountPayable.Vendor.Name, False, -1, AccountPayableProductionDistributionDetailList, JobComponents, OfficeCodeList, DueFromSeqNo, DueToSeqNo, AgencyInvoiceTaxFlag, GLSourceCode, Nothing, Remark, PostPeriodCode)

            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayableProduction.AccountPayableID, GeneralLedger.Transaction)).FirstOrDefault

            If IsBalanced <> 1 Then

                Throw New Exception("Cannot transfer.  Invoice out of balance.")

            End If

        End Sub
        Private Sub CalculateEmployeeTimeAmounts(ByRef EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail)

            'objects
            Dim TaxableAmount As Decimal = 0

            EmployeeTimeDetail.TotalCostAmount = FormatNumber(EmployeeTimeDetail.CostRate.GetValueOrDefault(0) * EmployeeTimeDetail.Hours, 2)

            EmployeeTimeDetail.TotalBilledAmount = FormatNumber(EmployeeTimeDetail.Hours * EmployeeTimeDetail.BillableRate.GetValueOrDefault(0), 2)

            EmployeeTimeDetail.MarkupAmount = FormatNumber(EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) * EmployeeTimeDetail.CommissionPercentage.GetValueOrDefault(0) / 100, 2)

            If EmployeeTimeDetail.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                TaxableAmount = EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0)

            ElseIf EmployeeTimeDetail.TaxCommission.GetValueOrDefault(0) = 1 Then

                TaxableAmount = EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) + EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0)

            Else

                TaxableAmount = EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0)

            End If

            EmployeeTimeDetail.StateResaleAmount = FormatNumber(EmployeeTimeDetail.SalesTaxStatePercentage.GetValueOrDefault(0) * TaxableAmount / 100, 2)
            EmployeeTimeDetail.CountyResaleAmount = FormatNumber(EmployeeTimeDetail.SalesTaxCountyPercentage.GetValueOrDefault(0) * TaxableAmount / 100, 2)
            EmployeeTimeDetail.CityResaleAmount = FormatNumber(EmployeeTimeDetail.SalesTaxCityPercentage.GetValueOrDefault(0) * TaxableAmount / 100, 2)

            EmployeeTimeDetail.TotalAmount = EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0) + EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0) + EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0) +
                                             EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0) + EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0)

        End Sub
        Private Sub ReverseEmployeeTime(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef EmployeeTimeDetailReversal As AdvantageFramework.Database.Entities.EmployeeTimeDetail)

            If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Insert(DbContext, EmployeeTimeDetailReversal) = False Then

                Throw New Exception("Failed to insert into employee time detail.")

            End If

        End Sub
        Public Sub TransferEmployeeTime(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingCommandCenterID As Integer,
                                        ByVal EmployeeTimeItem As AdvantageFramework.BillingCommandCenter.Classes.EmployeeTimeItem,
                                        ByVal TransferToClientCode As String, ByVal TransferToDivisionCode As String, ByVal TransferToProductCode As String,
                                        ByVal TransferToJobNumber As Integer, ByVal TransferToJobComponentNumber As Short, ByVal TransferToFunctionCode As String, ByVal AgencyInvoiceTaxFlag As Boolean,
                                        Optional ByVal TransferBillingRate As Nullable(Of TransferEmployeeTimeBillingRate) = Nothing, Optional ByVal TransferMarkupPercent As Nullable(Of TransferMarkupPercent) = Nothing,
                                        Optional ByVal TransferToHours As Nullable(Of Decimal) = Nothing,
                                        Optional ByVal AdjustmentComments As String = Nothing,
                                        Optional ByVal TransferToQuantity As Nullable(Of Decimal) = Nothing,
                                        Optional ByVal TransferToRate As Nullable(Of Decimal) = Nothing,
                                        Optional ByVal TransferToTaskCode As String = Nothing)

            'objects
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeDetailReversal As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeDetailNew As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeDetailTransferTo As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeComment As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim EmployeeTimeCommentNew As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing

            EmployeeTimeDetail = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeID(DbContext, EmployeeTimeItem.EmployeeTimeID)
                                  Where Entity.EmployeeTimeDetailID = EmployeeTimeItem.EmployeeTimeDetailID AndAlso Entity.SequenceNumber = EmployeeTimeItem.SequenceNumber).SingleOrDefault

            If EmployeeTimeDetail Is Nothing Then

                Throw New Exception("Cannot find employee time detail to transfer.")

            End If

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, TransferToJobNumber, TransferToJobComponentNumber)

            If JobComponent Is Nothing Then

                Throw New Exception("Cannot find transfer to job component.")

            End If

            EmployeeTimeDetailReversal = DirectCast(EmployeeTimeDetail.DuplicateEntity, AdvantageFramework.Database.Entities.EmployeeTimeDetail)
            EmployeeTimeDetailReversal.Hours = -1 * EmployeeTimeDetail.Hours
            EmployeeTimeDetailReversal.UserCode = DbContext.UserCode
            EmployeeTimeDetailReversal.AdjusterComments = Nothing
            EmployeeTimeDetailReversal.TotalCostAmount = -1 * EmployeeTimeDetail.TotalCostAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.TotalBilledAmount = -1 * EmployeeTimeDetail.TotalBilledAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.MarkupAmount = -1 * EmployeeTimeDetail.MarkupAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.StateResaleAmount = -1 * EmployeeTimeDetail.StateResaleAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.CountyResaleAmount = -1 * EmployeeTimeDetail.CountyResaleAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.CityResaleAmount = -1 * EmployeeTimeDetail.CityResaleAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.TotalAmount = -1 * EmployeeTimeDetail.TotalAmount.GetValueOrDefault(0)
            EmployeeTimeDetailReversal.HasBeenEdited = 1
            EmployeeTimeDetailReversal.TransferAdjustmentDate = Now
            EmployeeTimeDetailReversal.TransferAdjustmentUserCode = DbContext.UserCode
            EmployeeTimeDetailReversal.IsReconciled = 0

            ReverseEmployeeTime(DbContext, EmployeeTimeDetailReversal)

            'EmployeeTimeComment = (From ETC In AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeID(DbContext, EmployeeTimeDetail.EmployeeTimeID)
            '                       Where ETC.EmployeeTimeDetailID = EmployeeTimeDetail.EmployeeTimeDetailID AndAlso
            '                             ETC.EmployeeTimeSource = "D"
            '                       Select ETC).FirstOrDefault

            EmployeeTimeComment = (From ETC In AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeID(DbContext, EmployeeTimeDetail.EmployeeTimeID)
                                   Where ETC.EmployeeTimeDetailID = EmployeeTimeDetail.EmployeeTimeDetailID AndAlso
                                         ETC.SequenceNumber = EmployeeTimeDetail.SequenceNumber AndAlso
                                         ETC.EmployeeTimeSource = "D"
                                   Select ETC).SingleOrDefault

            If TransferToHours.HasValue AndAlso EmployeeTimeDetail.Hours <> TransferToHours.Value Then

                EmployeeTimeDetailNew = DirectCast(EmployeeTimeDetail.DuplicateEntity, AdvantageFramework.Database.Entities.EmployeeTimeDetail)
                EmployeeTimeDetailNew.Hours = EmployeeTimeDetail.Hours - TransferToHours.Value
                EmployeeTimeDetailNew.UserCode = DbContext.UserCode
                EmployeeTimeDetailNew.AdjusterComments = Nothing
                EmployeeTimeDetailNew.TransferAdjustmentDate = Now
                EmployeeTimeDetailNew.TransferAdjustmentUserCode = DbContext.UserCode

                CalculateEmployeeTimeAmounts(EmployeeTimeDetailNew)

                If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Insert(DbContext, EmployeeTimeDetailNew) = False Then

                    Throw New Exception("Failed to insert employee time detail.")

                End If

                If EmployeeTimeComment IsNot Nothing Then

                    EmployeeTimeCommentNew = New AdvantageFramework.Database.Entities.EmployeeTimeComment

                    EmployeeTimeCommentNew.EmployeeTimeID = EmployeeTimeDetailNew.EmployeeTimeID
                    EmployeeTimeCommentNew.EmployeeTimeDetailID = EmployeeTimeDetailNew.EmployeeTimeDetailID
                    EmployeeTimeCommentNew.SequenceNumber = EmployeeTimeDetailNew.SequenceNumber
                    EmployeeTimeCommentNew.EmployeeTimeSource = "D"
                    EmployeeTimeCommentNew.EmployeeComments = EmployeeTimeComment.EmployeeComments

                    If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Insert(DbContext, EmployeeTimeCommentNew) = False Then

                        Throw New Exception("Failed to insert into employee time detail comment table.")

                    End If

                End If

            End If

            EmployeeTimeDetailTransferTo = New AdvantageFramework.Database.Entities.EmployeeTimeDetail

            EmployeeTimeDetailTransferTo.IsAdvancedBill = CShort(If(JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2))
            EmployeeTimeDetailTransferTo.EmployeeTimeID = EmployeeTimeDetail.EmployeeTimeID
            EmployeeTimeDetailTransferTo.EmployeeTimeDetailID = 0
            EmployeeTimeDetailTransferTo.JobNumber = TransferToJobNumber
            EmployeeTimeDetailTransferTo.JobComponentNumber = TransferToJobComponentNumber

            If TransferToFunctionCode Is Nothing Then

                TransferToFunctionCode = EmployeeTimeDetail.FunctionCode

            End If

            EmployeeTimeDetailTransferTo.FunctionCode = TransferToFunctionCode
            EmployeeTimeDetailTransferTo.CostRate = EmployeeTimeDetail.CostRate
            EmployeeTimeDetailTransferTo.Hours = CDec(If(TransferToHours.HasValue, TransferToHours.Value, EmployeeTimeDetail.Hours))
            EmployeeTimeDetailTransferTo.UserCode = EmployeeTimeDetail.UserCode
            EmployeeTimeDetailTransferTo.EnteredDate = EmployeeTimeDetail.EnteredDate
            EmployeeTimeDetailTransferTo.DepartmentTeamCode = EmployeeTimeDetail.DepartmentTeamCode
            EmployeeTimeDetailTransferTo.EmployeeTitleID = EmployeeTimeDetail.EmployeeTitleID

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TransferToJobNumber)

            If Job Is Nothing Then

                Throw New Exception("Cannot find job.")

            End If

            'TransferMarkupPercent is only passed when transferring multiple items - we will only calculate BillingRate in this case, its already done in the transfer single item routine
            If TransferMarkupPercent IsNot Nothing OrElse TransferBillingRate IsNot Nothing Then

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, TransferToFunctionCode, TransferToClientCode,
                                                                                TransferToDivisionCode, TransferToProductCode, TransferToJobNumber,
                                                                                TransferToJobComponentNumber, Job.SalesClassCode, EmployeeTimeItem.EmployeeCode, EmployeeTimeItem.EmployeeDate)

                If TransferMarkupPercent = Methods.TransferMarkupPercent.RecalculateFromHierarchy Then

                    If BillingRate IsNot Nothing Then

                        EmployeeTimeDetailTransferTo.CommissionPercentage = BillingRate.COMM.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.SalesTaxCode = BillingRate.TAX_CODE
                        EmployeeTimeDetailTransferTo.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        EmployeeTimeDetailTransferTo.CommissionPercentage = 0
                        EmployeeTimeDetailTransferTo.IsNonBillable = 0
                        EmployeeTimeDetailTransferTo.SalesTaxCode = Nothing
                        EmployeeTimeDetailTransferTo.TaxCommission = 0
                        EmployeeTimeDetailTransferTo.TaxCommissionOnly = 0

                    End If

                ElseIf TransferMarkupPercent = Methods.TransferMarkupPercent.TransferAsIs Then

                    EmployeeTimeDetailTransferTo.CommissionPercentage = EmployeeTimeItem.CommissionPercentage

                    If BillingRate IsNot Nothing Then

                        EmployeeTimeDetailTransferTo.IsNonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.SalesTaxCode = BillingRate.TAX_CODE
                        EmployeeTimeDetailTransferTo.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        EmployeeTimeDetailTransferTo.IsNonBillable = 0
                        EmployeeTimeDetailTransferTo.SalesTaxCode = Nothing
                        EmployeeTimeDetailTransferTo.TaxCommission = 0
                        EmployeeTimeDetailTransferTo.TaxCommissionOnly = 0

                    End If

                End If

                If TransferBillingRate = TransferEmployeeTimeBillingRate.RecalculateFromHierarchy Then

                    If BillingRate IsNot Nothing Then

                        EmployeeTimeDetailTransferTo.FeeTimeType = BillingRate.FEE_TIME_FLAG.GetValueOrDefault(0)
                        EmployeeTimeDetailTransferTo.BillableRate = CDec(FormatNumber(BillingRate.BILLING_RATE.GetValueOrDefault(0), 2))

                        If BillingRate.RATE_LEVEL = 9999 Then

                            EmployeeTimeDetailTransferTo.EmployeeRateFrom = "Approved Estimate"

                        Else

                            Try

                                If BillingRate.RATE_LEVEL.HasValue Then

                                    BillingRateLevel = (From Entity In AdvantageFramework.Database.Procedures.BillingRateLevel.Load(DbContext)
                                                        Where Entity.Number = BillingRate.RATE_LEVEL
                                                        Select Entity).FirstOrDefault

                                End If

                            Catch ex As Exception
                                BillingRateLevel = Nothing
                            End Try

                            If BillingRateLevel IsNot Nothing Then

                                EmployeeTimeDetailTransferTo.EmployeeRateFrom = BillingRateLevel.Description

                            End If

                        End If

                    Else

                        EmployeeTimeDetailTransferTo.FeeTimeType = 0
                        EmployeeTimeDetailTransferTo.BillableRate = Nothing

                    End If

                ElseIf TransferBillingRate = TransferEmployeeTimeBillingRate.TransferAsIs Then

                    EmployeeTimeDetailTransferTo.FeeTimeType = EmployeeTimeDetail.FeeTimeType
                    EmployeeTimeDetailTransferTo.BillableRate = EmployeeTimeDetail.BillableRate

                End If

                If String.IsNullOrWhiteSpace(TransferToTaskCode) Then

                    EmployeeTimeDetailTransferTo.TaskCode = EmployeeTimeDetail.TaskCode

                Else

                    EmployeeTimeDetailTransferTo.TaskCode = TransferToTaskCode

                End If

            Else

                EmployeeTimeDetailTransferTo.TaxCommission = EmployeeTimeItem.TaxCommission
                EmployeeTimeDetailTransferTo.TaxCommissionOnly = EmployeeTimeItem.TaxCommissionOnly
                EmployeeTimeDetailTransferTo.CommissionPercentage = EmployeeTimeItem.CommissionPercentage
                EmployeeTimeDetailTransferTo.IsNonBillable = EmployeeTimeItem.IsNonBillable
                EmployeeTimeDetailTransferTo.SalesTaxCode = EmployeeTimeItem.SalesTaxCode
                EmployeeTimeDetailTransferTo.FeeTimeType = EmployeeTimeItem.FeeTimeType
                EmployeeTimeDetailTransferTo.BillableRate = EmployeeTimeItem.BillableRate

                EmployeeTimeDetailTransferTo.TaskCode = EmployeeTimeItem.TaskCode

            End If

            If EmployeeTimeDetailTransferTo.SalesTaxCode IsNot Nothing AndAlso AgencyInvoiceTaxFlag = False Then

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, EmployeeTimeDetailTransferTo.SalesTaxCode)

                If SalesTax Is Nothing Then

                    Throw New Exception("Cannot find SalesTax.")

                Else

                    EmployeeTimeDetailTransferTo.SalesTaxStatePercentage = SalesTax.StatePercent
                    EmployeeTimeDetailTransferTo.SalesTaxCountyPercentage = SalesTax.CountyPercent
                    EmployeeTimeDetailTransferTo.SalesTaxCityPercentage = SalesTax.CityPercent
                    EmployeeTimeDetailTransferTo.SalesTaxResale = SalesTax.Resale

                End If

            Else

                EmployeeTimeDetailTransferTo.SalesTaxCode = Nothing
                EmployeeTimeDetailTransferTo.SalesTaxStatePercentage = 0
                EmployeeTimeDetailTransferTo.SalesTaxCountyPercentage = 0
                EmployeeTimeDetailTransferTo.SalesTaxCityPercentage = 0
                EmployeeTimeDetailTransferTo.SalesTaxResale = Nothing

            End If

            CalculateEmployeeTimeAmounts(EmployeeTimeDetailTransferTo)

            EmployeeTimeDetailTransferTo.TransferFromJobNumber = EmployeeTimeDetail.JobNumber
            EmployeeTimeDetailTransferTo.TransferFromJobComponentNumber = EmployeeTimeDetail.JobComponentNumber
            EmployeeTimeDetailTransferTo.TransferFromFunctionCode = EmployeeTimeDetail.FunctionCode
            EmployeeTimeDetailTransferTo.TransferFromEmployeeTimeID = EmployeeTimeDetail.EmployeeTimeID
            EmployeeTimeDetailTransferTo.TransferFromSequenceNumber = EmployeeTimeDetail.SequenceNumber

            EmployeeTimeDetailTransferTo.AdjusterComments = AdjustmentComments
            EmployeeTimeDetailTransferTo.TransferAdjustmentUserCode = DbContext.UserCode
            EmployeeTimeDetailTransferTo.TransferAdjustmentDate = Now

            SetBillingCommandCenterIDandUser(DbContext, BillingCommandCenterID, EmployeeTimeDetailTransferTo.JobNumber, EmployeeTimeDetailTransferTo.JobComponentNumber, EmployeeTimeDetailTransferTo.BillingCommandCenterID, EmployeeTimeDetailTransferTo.BillingUserCode)

            If EmployeeTimeDetailTransferTo.IsNonBillable.GetValueOrDefault(0) = 1 Then

                EmployeeTimeDetailTransferTo.BillingUserCode = Nothing

            End If

            EmployeeTimeDetailTransferTo.IsReconciled = 0
            EmployeeTimeDetailTransferTo.AlertID = EmployeeTimeDetail.AlertID

            EmployeeTimeDetail.HasBeenEdited = 1

            If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Update(DbContext, EmployeeTimeDetail) = False Then

                Throw New Exception("Failed to update employee time detail.")

            End If

            If AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Insert(DbContext, EmployeeTimeDetailTransferTo) = False Then

                Throw New Exception("Failed to insert into employee time detail.")

            End If

            If EmployeeTimeComment IsNot Nothing Then

                InsertUpdateEmployeeTimeComment(DbContext, EmployeeTimeDetailTransferTo.EmployeeTimeID, EmployeeTimeDetailTransferTo.EmployeeTimeDetailID, EmployeeTimeComment.EmployeeComments, EmployeeTimeDetailTransferTo.SequenceNumber)

            End If

            If DbContext.Database.SqlQuery(Of Decimal)(String.Format("SELECT SUM(EMP_HOURS) FROM dbo.EMP_TIME_DTL (NOLOCK) WHERE ET_ID = {0} AND EDIT_FLAG = 1", EmployeeTimeDetail.EmployeeTimeID)).First <> 0.00 Then

                Throw New Exception("Failed to transfer employee time, hours not in balance.")

            End If

        End Sub
        Private Sub InsertUpdateEmployeeTimeComment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Short,
                                                    ByVal EmployeeComments As String, SequenceNumber As Short)

            Dim EmployeeTimeCommentNew As AdvantageFramework.Database.Entities.EmployeeTimeComment = Nothing

            EmployeeTimeCommentNew = (From ETC In AdvantageFramework.Database.Procedures.EmployeeTimeComment.LoadByEmployeeTimeID(DbContext, EmployeeTimeID)
                                      Where ETC.EmployeeTimeDetailID = EmployeeTimeDetailID AndAlso
                                            ETC.SequenceNumber = SequenceNumber AndAlso
                                            ETC.EmployeeTimeSource = "D"
                                      Select ETC).SingleOrDefault

            If EmployeeTimeCommentNew IsNot Nothing Then

                EmployeeTimeCommentNew.EmployeeComments = EmployeeComments

                If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Update(DbContext, EmployeeTimeCommentNew) = False Then

                    Throw New Exception("Failed to update employee time detail comment table.")

                End If

            Else

                EmployeeTimeCommentNew = New AdvantageFramework.Database.Entities.EmployeeTimeComment

                EmployeeTimeCommentNew.EmployeeTimeID = EmployeeTimeID
                EmployeeTimeCommentNew.EmployeeTimeDetailID = EmployeeTimeDetailID
                EmployeeTimeCommentNew.SequenceNumber = SequenceNumber
                EmployeeTimeCommentNew.EmployeeTimeSource = "D"
                EmployeeTimeCommentNew.EmployeeComments = EmployeeComments

                If AdvantageFramework.Database.Procedures.EmployeeTimeComment.Insert(DbContext, EmployeeTimeCommentNew) = False Then

                    Throw New Exception("Failed to insert into employee time detail comment table.")

                End If

            End If

        End Sub
        Public Sub TransferIncomeOnly(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BillingCommandCenterID As Integer, ByVal IncomeOnlyItem As AdvantageFramework.BillingCommandCenter.Classes.IncomeOnlyItem,
                                      ByVal TransferToClientCode As String, ByVal TransferToDivisionCode As String, ByVal TransferToProductCode As String, ByVal TransferToJobNumber As Integer,
                                      ByVal TransferToJobComponentNumber As Short, ByVal TransferToFunctionCode As String, ByVal AgencyInvoiceTaxFlag As Boolean,
                                      Optional ByVal TransferMarkupPercent As Nullable(Of TransferMarkupPercent) = Nothing,
                                      Optional ByVal TransferToAmount As Nullable(Of Decimal) = Nothing,
                                      Optional ByVal AdjustmentComments As String = Nothing,
                                      Optional ByVal TransferToQuantity As Nullable(Of Decimal) = Nothing,
                                      Optional ByVal TransferToRate As Nullable(Of Decimal) = Nothing)

            'objects
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim IncomeOnlyReversalOverride As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim IncomeOnlyNew As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim IncomeOnlyTransferTo As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing
            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim TaxableAmount As Decimal = 0
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            IncomeOnly = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DbContext, IncomeOnlyItem.ID, IncomeOnlyItem.SequenceNumber)

            If IncomeOnly Is Nothing Then

                Throw New Exception("Cannot find income only to transfer.")

            End If

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, TransferToJobNumber, TransferToJobComponentNumber)

            If JobComponent Is Nothing Then

                Throw New Exception("Cannot find transfer to job component.")

            End If

            IncomeOnlyReversalOverride = New AdvantageFramework.Database.Entities.IncomeOnly

            IncomeOnlyReversalOverride.BillingUser = IncomeOnly.BillingUser
            IncomeOnlyReversalOverride.BillingCommandCenterID = IncomeOnly.BillingCommandCenterID
            IncomeOnlyReversalOverride.TransferAdjustedDate = Now
            IncomeOnlyReversalOverride.TransferAdjustedUser = DbContext.UserCode
            IncomeOnlyReversalOverride.AdjusterComments = AdjustmentComments

            If AdvantageFramework.Database.Procedures.IncomeOnly.Reverse(DbContext, IncomeOnly, AdvantageFramework.Database.Procedures.IncomeOnly.ReverseAction.Modify, IncomeOnlyReversalOverride) = False Then

                Throw New Exception("Failed to reverse Income Only.")

            End If

            'write a row for the difference or a zero row
            IncomeOnlyNew = New AdvantageFramework.Database.Entities.IncomeOnly

            IncomeOnlyNew.ID = IncomeOnly.ID
            IncomeOnlyNew.ReferenceNumber = IncomeOnly.ReferenceNumber
            IncomeOnlyNew.JobNumber = IncomeOnly.JobNumber
            IncomeOnlyNew.JobComponentNumber = IncomeOnly.JobComponentNumber
            IncomeOnlyNew.FunctionCode = IncomeOnly.FunctionCode
            IncomeOnlyNew.InvoiceDate = IncomeOnly.InvoiceDate

            If TransferToAmount.HasValue Then

                IncomeOnlyNew.Amount = IncomeOnly.Amount - TransferToAmount.Value

                If TransferToQuantity.HasValue Then

                    IncomeOnlyNew.Quantity = IncomeOnly.Quantity - TransferToQuantity.Value

                    AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(IncomeOnlyNew.Quantity, IncomeOnlyNew.Rate, IncomeOnlyNew.Amount, BillingSystem.QtyRateAmount.Amount, 2)

                End If

            Else

                IncomeOnlyNew.Amount = 0

            End If

            IncomeOnlyNew.IsModified = If(IncomeOnlyNew.Amount = 0, Nothing, 1)

            IncomeOnlyNew.Description = IncomeOnly.Description
            IncomeOnlyNew.CommissionPercent = IncomeOnly.CommissionPercent
            IncomeOnlyNew.BillHoldFlag = IncomeOnly.BillHoldFlag
            IncomeOnlyNew.BillingUser = IncomeOnly.BillingUser

            IncomeOnlyNew.TaxCode = IncomeOnly.TaxCode
            IncomeOnlyNew.TaxStatePercent = IncomeOnly.TaxStatePercent
            IncomeOnlyNew.TaxCountyPercent = IncomeOnly.TaxCountyPercent
            IncomeOnlyNew.TaxCityPercent = IncomeOnly.TaxCityPercent
            IncomeOnlyNew.TaxCommission = IncomeOnly.TaxCommission
            IncomeOnlyNew.TaxCommissionOnly = IncomeOnly.TaxCommissionOnly
            IncomeOnlyNew.TaxResale = IncomeOnly.TaxResale

            IncomeOnlyNew.AdjusterComments = AdjustmentComments
            IncomeOnlyNew.AdvanceBillFlag = IncomeOnly.AdvanceBillFlag
            IncomeOnlyNew.DepartmentTeamCode = IncomeOnly.DepartmentTeamCode

            IncomeOnlyNew.ExtendedMarkupAmount = FormatNumber(IncomeOnlyNew.CommissionPercent.GetValueOrDefault(0) * IncomeOnlyNew.Amount / 100, 2)

            AdvantageFramework.IncomeOnly.CalculateTaxes(AgencyInvoiceTaxFlag, IncomeOnlyNew.Amount,
                IncomeOnlyNew.ExtendedMarkupAmount, IncomeOnlyNew.TaxCityPercent, IncomeOnlyNew.TaxCountyPercent, IncomeOnlyNew.TaxStatePercent, CBool(IncomeOnlyNew.TaxCommission.GetValueOrDefault(0)),
                CBool(IncomeOnlyNew.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnlyNew.ExtendedCityResale, IncomeOnlyNew.ExtendedCountyResale, IncomeOnlyNew.ExtendedStateResale)

            IncomeOnlyNew.LineTotal = IncomeOnlyNew.Amount.GetValueOrDefault(0) + IncomeOnlyNew.ExtendedMarkupAmount.GetValueOrDefault(0) +
                IncomeOnlyNew.ExtendedCityResale.GetValueOrDefault(0) + IncomeOnlyNew.ExtendedCountyResale.GetValueOrDefault(0) + IncomeOnlyNew.ExtendedStateResale.GetValueOrDefault(0)

            IncomeOnlyNew.NonBillable = IncomeOnly.NonBillable
            IncomeOnlyNew.AdvanceBillID = IncomeOnly.AdvanceBillID
            IncomeOnlyNew.Comment = IncomeOnly.Comment
            IncomeOnlyNew.CampaignUpdatedInvoiceDate = IncomeOnly.CampaignUpdatedInvoiceDate
            IncomeOnlyNew.CampaignUpdatedPostPeriod = IncomeOnly.CampaignUpdatedPostPeriod
            IncomeOnlyNew.FeeInvoice = IncomeOnly.FeeInvoice
            IncomeOnlyNew.BillingCommandCenterID = IncomeOnly.BillingCommandCenterID
            IncomeOnlyNew.JobServiceFeeID = IncomeOnly.JobServiceFeeID
            IncomeOnlyNew.TransferAdjustedDate = Now
            IncomeOnlyNew.TransferAdjustedUser = DbContext.UserCode

            If AdvantageFramework.Database.Procedures.IncomeOnly.Insert(DbContext, IncomeOnlyNew) = False Then

                Throw New Exception("Failed to insert Income Only.")

            End If

            If TransferToFunctionCode Is Nothing Then

                TransferToFunctionCode = IncomeOnly.FunctionCode

            End If

            IncomeOnlyTransferTo = New AdvantageFramework.Database.Entities.IncomeOnly

            IncomeOnlyTransferTo.AdvanceBillFlag = If(JobComponent.IsAdvanceBilling.GetValueOrDefault(0) = 0, 0, 2)
            IncomeOnlyTransferTo.ID = 0
            IncomeOnlyTransferTo.Description = IncomeOnly.Description
            IncomeOnlyTransferTo.ReferenceNumber = IncomeOnly.ReferenceNumber
            IncomeOnlyTransferTo.JobNumber = TransferToJobNumber
            IncomeOnlyTransferTo.JobComponentNumber = TransferToJobComponentNumber
            IncomeOnlyTransferTo.FunctionCode = TransferToFunctionCode
            IncomeOnlyTransferTo.InvoiceDate = IncomeOnly.InvoiceDate
            IncomeOnlyTransferTo.TaxResale = IncomeOnly.TaxResale
            IncomeOnlyTransferTo.DepartmentTeamCode = IncomeOnly.DepartmentTeamCode
            IncomeOnlyTransferTo.FeeInvoice = IncomeOnly.FeeInvoice
            IncomeOnlyTransferTo.BillingApprovalID = IncomeOnly.BillingApprovalID
            IncomeOnlyTransferTo.Comment = IncomeOnly.Comment

            IncomeOnlyTransferTo.Amount = If(TransferToAmount Is Nothing, IncomeOnlyItem.Amount, TransferToAmount)
            IncomeOnlyTransferTo.Quantity = If(TransferToQuantity Is Nothing, IncomeOnlyItem.Quantity, TransferToQuantity)
            IncomeOnlyTransferTo.Rate = If(TransferToRate Is Nothing, IncomeOnlyItem.Rate, TransferToRate)

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TransferToJobNumber)

            If Job Is Nothing Then

                Throw New Exception("Cannot find job.")

            End If

            'TransferMarkupPercent is only passed when transferring multiple items - we will only calculate BillingRate in this case, its already done in the transfer single item routine
            If TransferMarkupPercent IsNot Nothing Then

                BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, TransferToFunctionCode, TransferToClientCode, TransferToDivisionCode, TransferToProductCode, TransferToJobNumber, TransferToJobComponentNumber, Job.SalesClassCode, Nothing, Nothing)

                If TransferMarkupPercent = Methods.TransferMarkupPercent.RecalculateFromHierarchy Then

                    If BillingRate IsNot Nothing Then

                        IncomeOnlyTransferTo.CommissionPercent = BillingRate.COMM.GetValueOrDefault(0)
                        IncomeOnlyTransferTo.NonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        IncomeOnlyTransferTo.TaxCode = BillingRate.TAX_CODE
                        IncomeOnlyTransferTo.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        IncomeOnlyTransferTo.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        IncomeOnlyTransferTo.CommissionPercent = 0
                        IncomeOnlyTransferTo.NonBillable = 0
                        IncomeOnlyTransferTo.TaxCode = Nothing
                        IncomeOnlyTransferTo.TaxCommission = 0
                        IncomeOnlyTransferTo.TaxCommissionOnly = 0

                    End If

                ElseIf TransferMarkupPercent = Methods.TransferMarkupPercent.TransferAsIs Then

                    IncomeOnlyTransferTo.CommissionPercent = IncomeOnlyItem.CommissionPercent

                    If BillingRate IsNot Nothing Then

                        IncomeOnlyTransferTo.NonBillable = BillingRate.NOBILL_FLAG.GetValueOrDefault(0)
                        IncomeOnlyTransferTo.TaxCode = BillingRate.TAX_CODE
                        IncomeOnlyTransferTo.TaxCommission = BillingRate.TAX_COMM.GetValueOrDefault(0)
                        IncomeOnlyTransferTo.TaxCommissionOnly = BillingRate.TAX_COMM_ONLY.GetValueOrDefault(0)

                    Else

                        IncomeOnlyTransferTo.NonBillable = 0
                        IncomeOnlyTransferTo.TaxCode = Nothing
                        IncomeOnlyTransferTo.TaxCommission = 0
                        IncomeOnlyTransferTo.TaxCommissionOnly = 0

                    End If

                End If

            Else 'this is a single item transfer, take what was passed for these

                IncomeOnlyTransferTo.TaxCommission = If(IncomeOnlyItem.TaxCommission, 1, 0)
                IncomeOnlyTransferTo.TaxCommissionOnly = If(IncomeOnlyItem.TaxCommissionOnly, 1, 0)
                IncomeOnlyTransferTo.CommissionPercent = IncomeOnlyItem.CommissionPercent
                IncomeOnlyTransferTo.NonBillable = If(IncomeOnlyItem.IsNonBillable, 1, 0)
                IncomeOnlyTransferTo.TaxCode = IncomeOnlyItem.SalesTaxCode

            End If

            IncomeOnlyTransferTo.ExtendedMarkupAmount = FormatNumber(IncomeOnlyTransferTo.CommissionPercent.GetValueOrDefault(0) * IncomeOnlyTransferTo.Amount.GetValueOrDefault(0) / 100, 2)

            If AgencyInvoiceTaxFlag Then

                IncomeOnlyTransferTo.TaxCommission = 0
                IncomeOnlyTransferTo.TaxCommissionOnly = 0
                IncomeOnlyTransferTo.TaxCode = Nothing

            End If

            If IncomeOnlyTransferTo.TaxCode IsNot Nothing Then

                SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, IncomeOnlyTransferTo.TaxCode)

                If SalesTax Is Nothing Then

                    Throw New Exception("Cannot find SalesTax.")

                Else

                    If IncomeOnlyTransferTo.TaxCommissionOnly.GetValueOrDefault(0) = 1 Then

                        TaxableAmount = IncomeOnlyTransferTo.ExtendedMarkupAmount.GetValueOrDefault(0)

                    ElseIf IncomeOnlyTransferTo.TaxCommission.GetValueOrDefault(0) = 1 Then

                        TaxableAmount = IncomeOnlyTransferTo.Amount.GetValueOrDefault(0) + IncomeOnlyTransferTo.ExtendedMarkupAmount.GetValueOrDefault(0)

                    Else

                        TaxableAmount = IncomeOnlyTransferTo.Amount.GetValueOrDefault(0)

                    End If

                    IncomeOnlyTransferTo.ExtendedStateResale = FormatNumber(SalesTax.StatePercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                    IncomeOnlyTransferTo.ExtendedCountyResale = FormatNumber(SalesTax.CountyPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)
                    IncomeOnlyTransferTo.ExtendedCityResale = FormatNumber(SalesTax.CityPercent.GetValueOrDefault(0) * TaxableAmount / 100, 2)

                    IncomeOnlyTransferTo.TaxStatePercent = SalesTax.StatePercent
                    IncomeOnlyTransferTo.TaxCountyPercent = SalesTax.CountyPercent
                    IncomeOnlyTransferTo.TaxCityPercent = SalesTax.CityPercent
                    IncomeOnlyTransferTo.TaxResale = SalesTax.Resale

                End If

            Else

                IncomeOnlyTransferTo.ExtendedStateResale = 0
                IncomeOnlyTransferTo.ExtendedCountyResale = 0
                IncomeOnlyTransferTo.ExtendedCityResale = 0

                IncomeOnlyTransferTo.TaxStatePercent = 0
                IncomeOnlyTransferTo.TaxCountyPercent = 0
                IncomeOnlyTransferTo.TaxCityPercent = 0
                IncomeOnlyTransferTo.TaxResale = 0

            End If

            IncomeOnlyTransferTo.LineTotal = IncomeOnlyTransferTo.Amount.GetValueOrDefault(0) + IncomeOnlyTransferTo.ExtendedMarkupAmount.GetValueOrDefault(0) + IncomeOnlyTransferTo.ExtendedStateResale.GetValueOrDefault(0) + IncomeOnlyTransferTo.ExtendedCountyResale.GetValueOrDefault(0) + IncomeOnlyTransferTo.ExtendedCityResale.GetValueOrDefault(0)

            IncomeOnlyTransferTo.TransferFromJob = IncomeOnly.JobNumber
            IncomeOnlyTransferTo.TransferFromJobComponent = IncomeOnly.JobComponentNumber
            IncomeOnlyTransferTo.TransferFromFunction = IncomeOnly.FunctionCode
            IncomeOnlyTransferTo.TransferFromIncomeOnlyID = IncomeOnly.ID
            IncomeOnlyTransferTo.TransferFromSequenceNumber = IncomeOnly.SequenceNumber

            IncomeOnlyTransferTo.AdjusterComments = AdjustmentComments
            IncomeOnlyTransferTo.TransferAdjustedUser = DbContext.UserCode
            IncomeOnlyTransferTo.TransferAdjustedDate = Now

            SetBillingCommandCenterIDandUser(DbContext, BillingCommandCenterID, IncomeOnlyTransferTo.JobNumber, IncomeOnlyTransferTo.JobComponentNumber, IncomeOnlyTransferTo.BillingCommandCenterID, IncomeOnlyTransferTo.BillingUser)

            If IncomeOnlyTransferTo.NonBillable.GetValueOrDefault(0) = 1 Then

                IncomeOnlyTransferTo.BillingUser = Nothing

            End If

            If AdvantageFramework.Database.Procedures.IncomeOnly.Insert(DbContext, IncomeOnlyTransferTo) = False Then

                Throw New Exception("Failed to insert into income only.")

            End If

        End Sub
        Private Sub SetBillingCommandCenterIDandUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CurrentBillingCommandCenterID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                     ByRef BillingCommandCenterID As Nullable(Of Integer), ByRef BillingUser As String)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, CInt(JobComponentNumber))

            If JobComponent IsNot Nothing AndAlso JobComponent.BillingCommandCenterID.HasValue AndAlso CurrentBillingCommandCenterID = JobComponent.BillingCommandCenterID.Value Then

                BillingCommandCenterID = JobComponent.BillingCommandCenterID
                BillingUser = JobComponent.BillingUserCode

            End If

        End Sub

#End Region

#Region "  Advance Billing "

        Public Function GetAdvanceBillingItems(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal JobNumber As Integer,
                                               ByVal JobComponentNumber As Short) As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            Dim FunctionCodes As IEnumerable(Of String) = Nothing
            Dim Functions As IEnumerable(Of AdvantageFramework.Database.Core.Function) = Nothing
            Dim AdvanceBillingItemList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem) = Nothing
            Dim FunctionCore As AdvantageFramework.Database.Core.Function = Nothing

            FunctionCodes = (From Entity In AdvantageFramework.Database.Procedures.AdvanceBilling.Load(DbContext)
                             Where Entity.JobNumber = JobNumber AndAlso
                                   Entity.JobComponentNumber = JobComponentNumber AndAlso
                                   (Entity.ARInvoiceIsVoided Is Nothing OrElse
                                    Entity.ARInvoiceIsVoided = 0)
                             Select Entity.FunctionCode).ToList.Union(
                            (From Entity In AdvantageFramework.Database.Procedures.IncomeRecognize.Load(DbContext)
                             Where Entity.JobNumber = JobNumber AndAlso
                                   Entity.JobComponentNumber = JobComponentNumber AndAlso
                                   (Entity.IsVoided Is Nothing OrElse
                                    Entity.IsVoided = 0)
                             Select Entity.FunctionCode).ToList).ToList

            Functions = (From Fnc In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                         Where FunctionCodes.Contains(Fnc.Code)
                         Select Fnc).ToList

            AdvanceBillingItemList = New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            For Each FunctionCode In FunctionCodes

                FunctionCore = Functions.Where(Function(F) F.Code = FunctionCode).SingleOrDefault

                AdvanceBillingItemList.Add(New AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem(DbContext, FunctionCode, FunctionCore, JobNumber, JobComponentNumber))

            Next

            GetAdvanceBillingItems = AdvanceBillingItemList

        End Function
        Public Sub CalculateQuantityRateAndAmount(ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount,
                                                  ByRef AdvanceBillingItem As AdvantageFramework.BillingCommandCenter.Classes.AdvanceBillingItem)

            If AdvanceBillingItem.QuantityHours IsNot Nothing AndAlso AdvanceBillingItem.Rate IsNot Nothing Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AdvanceBillingItem.QuantityHours, AdvanceBillingItem.Rate, AdvanceBillingItem.NetAmount, FieldChanged, 2, 4)

            ElseIf FieldChanged = BillingSystem.QtyRateAmount.Quantity OrElse FieldChanged = BillingSystem.QtyRateAmount.Rate Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AdvanceBillingItem.QuantityHours, AdvanceBillingItem.Rate, AdvanceBillingItem.NetAmount, FieldChanged, 2, 4)

            ElseIf FieldChanged = BillingSystem.QtyRateAmount.Amount Then

                AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(AdvanceBillingItem.QuantityHours, AdvanceBillingItem.Rate, AdvanceBillingItem.NetAmount, FieldChanged, 2, 4)

            End If

        End Sub
        Public Function GetIncomeRecognitionSalesGeneralLedgerAccount(ByVal BCCDbContext As AdvantageFramework.BillingCommandCenter.Database.DbContext, ByVal JobNumber As Integer, ByVal FunctionCode As String) As String

            'objects
            Dim GLACode As String = Nothing

            Try

                GLACode = BCCDbContext.Database.SqlQuery(Of String)(String.Format("SELECT [dbo].[advfn_income_rec_get_gl_sales_account]({0}, '{1}')", JobNumber, FunctionCode)).SingleOrDefault

            Catch ex As Exception
                GLACode = Nothing
            Finally
                GetIncomeRecognitionSalesGeneralLedgerAccount = GLACode
            End Try

        End Function
        Public Function GetIncomeRecognitionDeferredSalesGeneralLedgerAccount(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As String

            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim GLACode As String = Nothing

            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

            If Job IsNot Nothing AndAlso Job.Office IsNot Nothing Then

                GLACode = Job.Office.ProductionDeferredSalesGLACode

            End If

            GetIncomeRecognitionDeferredSalesGeneralLedgerAccount = GLACode

        End Function
        Public Sub ClearAdvanceBillFlagInDetailTables(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_PRODUCTION SET AB_FLAG = 0 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_DTL SET AB_FLAG = 0 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INCOME_ONLY SET AB_FLAG = 0 WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

        End Sub
        Public Sub SetAdvanceBillFlagInDetailTables(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AP_PRODUCTION SET AB_FLAG = 2, AP_PROD_BILL_HOLD = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMP_TIME_DTL SET AB_FLAG = 2, BILL_HOLD_FLG = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INCOME_ONLY SET AB_FLAG = 2, BILL_HOLD_FLAG = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND AR_INV_NBR IS NULL", JobNumber, JobComponentNumber))

        End Sub
        Public Function GetLatestReconcileMethod(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String

            Dim Method As String = Nothing

            Method = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 METHOD_DESC FROM dbo.ADVANCE_BILLING WHERE FINAL_AB_ID IS NOT NULL AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND METHOD_DESC IS NOT NULL AND (AR_INV_VOID IS NULL OR AR_INV_VOID = 0) ORDER BY AR_INV_NBR DESC", JobNumber, JobComponentNumber)).FirstOrDefault

            If Method IsNot Nothing Then

                Select Case Method.ToUpper

                    Case "RECONCILE TO QUOTE"

                        Method = "Reconciled to Quote"

                    Case "RECONCILE TO BILLED"

                        Method = "Reconciled to Billed"

                    Case "RECONCILE TO ACTUAL"

                        Method = "Reconciled to Actual"

                End Select

            End If

            GetLatestReconcileMethod = Method

        End Function

#End Region

#Region "  Write Off "

        Public Sub WriteOffAP(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableWriteoff As AdvantageFramework.BillingCommandCenter.Classes.AccountPayableWriteoff,
                              Session As AdvantageFramework.Security.Session)

            'objects
            Dim GLSourceCode As String = Nothing
            Dim AgencyInvoiceTaxFlag As Boolean = False
            Dim AccountPayable As AdvantageFramework.Database.Entities.AccountPayable = Nothing
            Dim GLDescription As String = Nothing
            Dim GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) = Nothing
            Dim Remark As String = Nothing
            Dim JobComponent As Collection = Nothing
            Dim OfficeCodeList As Generic.List(Of String) = Nothing
            Dim DueFromSeqNo As Collection = Nothing
            Dim DueToSeqNo As Collection = Nothing
            Dim IsBalanced As Integer = -1

            JobComponent = New Collection
            OfficeCodeList = New Generic.List(Of String)
            DueFromSeqNo = New Collection
            DueToSeqNo = New Collection

            GLSourceCode = "BW"

            AgencyInvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

            AccountPayable = (From AP In AdvantageFramework.Database.Procedures.AccountPayable.LoadAllByAccountPayableID(DbContext, AccountPayableWriteoff.AccountPayableID)
                              Select AP).OrderByDescending(Function(AP) AP.SequenceNumber).FirstOrDefault

            If AccountPayable Is Nothing Then

                Throw New Exception("Cannot find AP record.")

            End If

            GLDescription = "A/P Write Off - Vendor:" & AccountPayable.VendorCode & ", Invoice:" & AccountPayableWriteoff.InvoiceNumber & ", Job/Comp:" &
                AccountPayableWriteoff.AccountPayableProductionDistributionDetail.JobNumber & "/" & AccountPayableWriteoff.AccountPayableProductionDistributionDetail.JobComponentNumber

            If AdvantageFramework.GeneralLedger.InsertGeneralLedger(GeneralLedger, DbContext, AccountPayableWriteoff.PostPeriodCode, DbContext.UserCode, GLDescription, GLSourceCode, Nothing) = False Then

                Throw New Exception("Failed trying to save data to General Ledger.")

            End If

            AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)

            AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferAdjustmentUserCode = DbContext.UserCode
            AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.TransferAdjustmentDate = Now

            AccountPayableProductionDistributionDetailList.Add(AccountPayableWriteoff.AccountPayableProductionDistributionDetail)
            'modify original row
            If AccountPayableWriteoff.OriginalQuantity.HasValue AndAlso AccountPayableWriteoff.Quantity.HasValue Then

                AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.Quantity -= AccountPayableWriteoff.Quantity.Value

            End If

            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.ExtendedAmount -= AccountPayableWriteoff.NetAmount.GetValueOrDefault(0)

            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.ExtendedMarkupAmount = FormatNumber(AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.ExtendedAmount.GetValueOrDefault(0) *
                                                                                                                          AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.CommissionPercent.GetValueOrDefault(0) / 100, 2)

            AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateQuantityRateAndAmount(BillingSystem.QtyRateAmount.Amount, AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal, DbContext)

            'AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail.CalculateTax(DbContext, AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction)

            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedNonResaleTax = AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedNonResaleTax -
                AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.ExtendedNonResaleTax

            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedStateResale = AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedStateResale -
                AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.ExtendedStateResale
            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedCountyResale = AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedCountyResale -
                AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.ExtendedCountyResale
            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedCityResale = AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.ExtendedCityResale -
                AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.ExtendedCityResale

            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.PostPeriodCode = AccountPayableWriteoff.PostPeriodCode
            AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.CreateDate = Now

            AccountPayableProductionDistributionDetailList.AddRange(From APP In AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadActiveByAccountPayableID(DbContext, AccountPayableWriteoff.AccountPayableID).ToList
                                                                    Where APP.LineNumber <> AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.LineNumber
                                                                    Select New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, APP, Session))

            AccountPayableProductionDistributionDetailList.Add(AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal)

            Remark = "Write Off - Vendor:" & AccountPayable.VendorCode & ", Invoice:" & AccountPayableWriteoff.InvoiceNumber &
                ", C/D/P:" & AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.Job.ClientCode & "/" &
                AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.Job.DivisionCode & "/" &
                AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.AccountPayableProduction.Job.ProductCode &
                ", Job/Comp:" & AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.JobNumber & "/" & AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.JobComponentNumber & ", Function:" & AccountPayableWriteoff.AccountPayableProductionDistributionDetailOriginal.FunctionCode

            AdvantageFramework.AccountPayable.SaveProduction(DbContext, GeneralLedger.Transaction, AccountPayable, AccountPayable.Vendor.Name, False, -1, AccountPayableProductionDistributionDetailList, JobComponent, OfficeCodeList, DueFromSeqNo, DueToSeqNo, AgencyInvoiceTaxFlag, GLSourceCode, Nothing, Remark, AccountPayableWriteoff.PostPeriodCode, True)

            IsBalanced = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec [advsp_ap_invoice_balanced] {0}, {1}", AccountPayableWriteoff.AccountPayableProductionDistributionDetail.AccountPayableProduction.AccountPayableID, GeneralLedger.Transaction)).FirstOrDefault

            If IsBalanced <> 1 Then

                Throw New Exception("Cannot write off.  Invoice out of balance.")

            End If

        End Sub

#End Region

#End Region

    End Module

End Namespace
