Namespace FinanceAndAccounting

    Public Class ServiceFeeReconciliationDetailReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _FeeTimeFrom As Date = Nothing
        Private _FeeTimeTo As Date = Nothing
        Private _ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing
        Private _ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job
        Private _ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee
        Private _ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile = Nothing
        Private _ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

#End Region

#Region " Properties "

        Public Property ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles
            Get
                ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationSummaryStyle
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles)

                _ServiceFeeReconciliationSummaryStyle = value

                Try

                    FeeDetailSubReport.ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationSummaryStyle
                    TimeDetailSubReport.ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationSummaryStyle

                Catch ex As Exception

                End Try

            End Set
        End Property
        Public Property ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions
            Get
                ServiceFeeReconciliationGroupByOption = _ServiceFeeReconciliationGroupByOption
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions)

                _ServiceFeeReconciliationGroupByOption = value

                Try

                    LoadDetailGroupFields(_ServiceFeeReconciliationGroupByOption, GroupHeaderDetail, TableRowHeader_Header, _
                                          TableCellHeader_CampaignDescription, TableCellHeader_JobNumber, TableCellHeader_JobDescription, _
                                          TableCellHeader_ComponentNumber, TableCellHeader_ComponentDescription, TableCellHeader_FunctionDescription, _
                                          TableCellHeader_FeeQuantity, TableCellHeader_FeeAmount, TableCellHeader_TotalHours, _
                                          TableCellHeader_TotalAmount, TableCellHeader_FunctionConsolidation, TableCellHeader_FunctionHeading, _
                                          TableRowDetails_Details, TableCellDetails_CampaignDescription, _
                                          TableCellDetails_JobNumber, TableCellDetails_JobDescription, _
                                          TableCellDetails_ComponentNumber, TableCellDetails_ComponentDescription, TableCellDetails_FunctionDescription, _
                                          TableCellDetails_FeeQuantity, TableCellDetails_FeeAmount, TableCellDetails_TotalHours, _
                                          TableCellDetails_TotalAmount, TableCellDetails_FunctionConsolidation, TableCellDetails_FunctionHeading)

                Catch ex As Exception

                End Try

            End Set
        End Property
        Public Property ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting
            Get
                ServiceFeeReconciliationSetting = _ServiceFeeReconciliationSetting
            End Get
            Set(ByVal value As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting)

                _ServiceFeeReconciliationSetting = value

                Try

                    LoadCDPGroupFields(_ServiceFeeReconciliationSetting, GroupHeaderClientDivisionProduct, LabelClientDivisionProduct_Division, LabelClientDivisionProduct_DivisionData, LabelClientDivisionProduct_Product, LabelClientDivisionProduct_ProductData)

                Catch ex As Exception

                End Try

            End Set
        End Property
        Public Property FeeTimeTo As Date
            Get
                FeeTimeTo = _FeeTimeTo
            End Get
            Set(ByVal value As Date)
                _FeeTimeTo = value
            End Set
        End Property
        Public Property FeeTimeFrom As Date
            Get
                FeeTimeFrom = _FeeTimeFrom
            End Get
            Set(ByVal value As Date)
                _FeeTimeFrom = value
            End Set
        End Property
        Public Property FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod
            Get
                FeePostPeriodTo = _FeePostPeriodTo
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.PostPeriod)
                _FeePostPeriodTo = value
            End Set
        End Property
        Public Property FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod
            Get
                FeePostPeriodFrom = _FeePostPeriodFrom
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.PostPeriod)
                _FeePostPeriodFrom = value
            End Set
        End Property
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(ByVal value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeReconciliationDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

            ServiceFeeReconcileDetailList = Me.DataSource

            If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                SubreportDetail_TimePosted.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                      Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = False _
                                                                      Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcileDtl)).ToList

            Else

                SubreportDetail_TimePosted.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                      Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = False _
                                                                      Group ServiceFeeReconcileDtl By ServiceFeeReconcileDtl.Description Into ServiceFeeReconcile = Group _
                                                                      Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcile.ToList)).ToList

            End If

            If CType(SubreportDetail_TimePosted.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)).Count = 0 Then

                SubreportDetail_TimePosted.Visible = False

            End If

            If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                SubreportDetail_FeesPosted.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                      Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = True _
                                                                      Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcileDtl)).ToList

            Else

                SubreportDetail_FeesPosted.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                      Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = True _
                                                                      Group ServiceFeeReconcileDtl By ServiceFeeReconcileDtl.Description Into ServiceFeeReconcile = Group _
                                                                      Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcile.ToList)).ToList

            End If

            If CType(SubreportDetail_FeesPosted.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)).Count = 0 Then

                SubreportDetail_FeesPosted.Visible = False

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            Try

                LabelPageHeader_FeesBilledFrom.Text = String.Format(LabelPageHeader_FeesBilledFrom.Text, _FeePostPeriodFrom.Code, _FeePostPeriodTo.Code)
                LabelPageHeader_FeesTimePostedFrom.Text = String.Format(LabelPageHeader_FeesTimePostedFrom.Text, _FeeTimeFrom.ToShortDateString, _FeeTimeTo.ToShortDateString)

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
