Namespace FinanceAndAccounting

    Public Class ServiceFeeReconciliationReport
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
        Private _ShowTimePostedDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
        Private _ShowFeesBilledDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
        Private _ShowDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ServiceFeeReconciliation
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

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ShowTimePostedDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)
            _ShowFeesBilledDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)
            _ShowDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)

        End Sub
        Private Function LoadDataSources(ByVal ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile) As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile)

            'objects
            Dim JobComponent As String = ""
            Dim FunctionCode As String = ""
            Dim JobNumber As Integer = 0
            Dim CampaignCode As String = ""
            Dim SalesClassCode As String = ""
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
            Dim FunctionConsolidation As String = ""
            Dim FunctionHeading As String = ""

            ServiceFeeReconcileDetailList = CType(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

            If _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job Then

                Try

                    JobNumber = ServiceFeeReconcileDetail.JobNumber

                Catch ex As Exception
                    JobNumber = 0
                End Try

                If JobNumber = 0 Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber).ToList

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component Then

                Try

                    JobComponent = ServiceFeeReconcileDetail.JobComponent

                Catch ex As Exception
                    JobComponent = ""
                End Try

                If JobComponent Is Nothing OrElse JobComponent = "" Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent).ToList

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_Function Then

                Try

                    JobComponent = ServiceFeeReconcileDetail.JobComponent
                    FunctionCode = ServiceFeeReconcileDetail.FunctionCode

                Catch ex As Exception
                    JobComponent = ""
                    FunctionCode = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode).ToList

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Function Then

                Try

                    JobNumber = ServiceFeeReconcileDetail.JobNumber
                    FunctionCode = ServiceFeeReconcileDetail.FunctionCode

                Catch ex As Exception
                    JobNumber = 0
                    FunctionCode = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionCode Is Nothing OrElse FunctionCode = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionCode = FunctionCode).ToList

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Campaign Then

                Try

                    CampaignCode = ServiceFeeReconcileDetail.CampaignCode

                Catch ex As Exception
                    CampaignCode = ""
                End Try

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.CampaignCode = CampaignCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                End If

            ElseIf _ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Function Then

                Try

                    FunctionCode = ServiceFeeReconcileDetail.FunctionCode

                Catch ex As Exception
                    FunctionCode = ""
                End Try

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionCode = FunctionCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                Try

                    JobNumber = ServiceFeeReconcileDetail.JobNumber
                    FunctionConsolidation = ServiceFeeReconcileDetail.FunctionConsolidation

                Catch ex As Exception
                    JobNumber = 0
                    FunctionConsolidation = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionConsolidation Then

                Try

                    JobComponent = ServiceFeeReconcileDetail.JobComponent
                    FunctionConsolidation = ServiceFeeReconcileDetail.FunctionConsolidation

                Catch ex As Exception
                    JobComponent = ""
                    FunctionConsolidation = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionConsolidation Is Nothing OrElse FunctionConsolidation = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionConsolidation Then

                Try

                    FunctionConsolidation = ServiceFeeReconcileDetail.FunctionConsolidation

                Catch ex As Exception
                    FunctionConsolidation = ""
                End Try

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionConsolidation = FunctionConsolidation AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_FunctionConsolidation Then

                Try

                    JobNumber = ServiceFeeReconcileDetail.JobNumber
                    FunctionHeading = ServiceFeeReconcileDetail.FunctionHeading

                Catch ex As Exception
                    JobNumber = 0
                    FunctionHeading = ""
                End Try

                If JobNumber = 0 AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobNumber.GetValueOrDefault(0) = JobNumber AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.Job_Component_FunctionHeading Then

                Try

                    JobComponent = ServiceFeeReconcileDetail.JobComponent
                    FunctionHeading = ServiceFeeReconcileDetail.FunctionHeading

                Catch ex As Exception
                    JobComponent = ""
                    FunctionHeading = ""
                End Try

                If (JobComponent Is Nothing OrElse JobComponent = "") AndAlso (FunctionHeading Is Nothing OrElse FunctionHeading = "") Then

                    Try

                        SalesClassCode = ServiceFeeReconcileDetail.SalesClassCode

                    Catch ex As Exception
                        SalesClassCode = ""
                    End Try

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.SalesClassCode = SalesClassCode AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                Else

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.JobComponent = JobComponent AndAlso ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading).ToList

                End If

            ElseIf ServiceFeeReconciliationGroupByOption = AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions.FunctionHeading Then

                Try

                    FunctionHeading = ServiceFeeReconcileDetail.FunctionHeading

                Catch ex As Exception
                    FunctionHeading = ""
                End Try

                If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                    ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.FunctionHeading = FunctionHeading AndAlso ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                End If

            End If

            LoadDataSources = ServiceFeeReconcileDetailList

        End Function
        Private Function ShouldShowDetail(ByVal ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile) As Boolean

            ShouldShowDetail = _ShowDetailsList.Contains(ServiceFeeReconcileDetail)

        End Function
        Private Function ShouldShowTimePostedDetail(ByVal ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile) As Boolean

            ShouldShowTimePostedDetail = _ShowTimePostedDetailsList.Contains(ServiceFeeReconcileDetail)

        End Function
        Private Function ShouldShowFeesBilledDetail(ByVal ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile) As Boolean

            ShouldShowFeesBilledDetail = _ShowFeesBilledDetailsList.Contains(ServiceFeeReconcileDetail)

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeReconciliationReport_DataSourceRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles Me.DataSourceRowChanged

            'objects
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing

            Try

                'CType(sender, DevExpress.XtraReports.UI.XRLabel).Tag = Me.GetCurrentRow

                If ShouldShowDetail(Me.GetCurrentRow) Then

                    'CType(sender, DevExpress.XtraReports.UI.XRLabel).Text = "-"

                    ServiceFeeReconcileDetailList = Me.LoadDataSources(Me.GetCurrentRow)

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

                    If CType(SubreportDetail_TimePosted.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)).Count > 0 Then

                        _ShowTimePostedDetailsList.Add(Me.GetCurrentRow)

                    End If

                    If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee Then

                        SubreportDetail_FeesBilled.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                              Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = True _
                                                                              Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcileDtl)).ToList

                    Else

                        SubreportDetail_FeesBilled.ReportSource.DataSource = (From ServiceFeeReconcileDtl In ServiceFeeReconcileDetailList _
                                                                              Where ServiceFeeReconcileDtl.FeeTimeType.Contains("Billed") = True _
                                                                              Group ServiceFeeReconcileDtl By ServiceFeeReconcileDtl.Description Into ServiceFeeReconcile = Group _
                                                                              Select New AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail(ServiceFeeReconcile.ToList)).ToList

                    End If

                    If CType(SubreportDetail_FeesBilled.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)).Count > 0 Then

                        _ShowFeesBilledDetailsList.Add(Me.GetCurrentRow)

                    End If

                Else

                    'CType(sender, DevExpress.XtraReports.UI.XRLabel).Text = "+"

                End If

            Catch ex As Exception

            End Try

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
        Private Sub LabelDetail_DrillDown_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_DrillDown.BeforePrint

            Try

                CType(sender, DevExpress.XtraReports.UI.XRLabel).Tag = Me.GetCurrentRow

                If ShouldShowDetail(Me.GetCurrentRow) Then

                    CType(sender, DevExpress.XtraReports.UI.XRLabel).Text = "-"

                Else

                    CType(sender, DevExpress.XtraReports.UI.XRLabel).Text = "+"

                End If

            Catch ex As Exception

            End Try

        End Sub
        'Private Sub PictureBoxDetail_DrillDownWindow_PreviewClick(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.PreviewMouseEventArgs)

        '    'objects
        '    Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

        '    ParameterDictionary = New Generic.Dictionary(Of String, Object)

        '    ParameterDictionary("ServiceFeeReconciliationSetting") = Me.ServiceFeeReconciliationSetting
        '    ParameterDictionary("FeePostPeriodFrom") = Me.FeePostPeriodFrom
        '    ParameterDictionary("FeePostPeriodTo") = Me.FeePostPeriodTo
        '    ParameterDictionary("FeeTimeFrom") = Me.FeeTimeFrom
        '    ParameterDictionary("FeeTimeTo") = Me.FeeTimeTo
        '    ParameterDictionary("ServiceFeeReconciliationGroupByOption") = Me.ServiceFeeReconciliationGroupByOption
        '    ParameterDictionary("ServiceFeeReconciliationSummaryStyle") = Me.ServiceFeeReconciliationSummaryStyle

        '    ParameterDictionary("DataSource") = Me.LoadDataSources(e.Brick.Value)

        '    AdvantageFramework.Navigation.ShowReportViewer(Me.Session, ReportTypes.ServiceFeeReconciliationDetailReport, ParameterDictionary)

        'End Sub
        Private Sub LabelDetail_DrillDown_PreviewClick(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles LabelDetail_DrillDown.PreviewClick

            Try

                If ShouldShowDetail(e.Brick.Value) Then

                    _ShowDetailsList.Remove(e.Brick.Value)

                    If _ShowTimePostedDetailsList.Contains(e.Brick.Value) Then

                        _ShowTimePostedDetailsList.Remove(e.Brick.Value)

                    End If

                    If _ShowFeesBilledDetailsList.Contains(e.Brick.Value) Then

                        _ShowFeesBilledDetailsList.Remove(e.Brick.Value)

                    End If

                Else

                    _ShowDetailsList.Add(e.Brick.Value)

                End If

                CreateDocument()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LabelDetail_DrillDown_PreviewMouseMove(ByVal sender As Object, ByVal e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles LabelDetail_DrillDown.PreviewMouseMove

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand

        End Sub
        Private Sub SubreportDetail_TimePosted_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles SubreportDetail_TimePosted.BeforePrint

            'objects
            Dim IsVisible As Boolean = False

            Try

                If ShouldShowDetail(Me.GetCurrentRow) AndAlso ShouldShowTimePostedDetail(Me.GetCurrentRow) Then

                    IsVisible = True

                End If

                SubreportDetail_TimePosted.Visible = IsVisible

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SubreportDetail_FeesPosted_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles SubreportDetail_FeesBilled.BeforePrint

            'objects
            Dim IsVisible As Boolean = False

            Try

                If ShouldShowDetail(Me.GetCurrentRow) AndAlso ShouldShowFeesBilledDetail(Me.GetCurrentRow) Then

                    IsVisible = True

                End If

                SubreportDetail_FeesBilled.Visible = IsVisible

            Catch ex As Exception

            End Try

        End Sub
        Public Sub ExpandCollapseAllDetails(ByVal Expand As Boolean)

            Try

                If Expand Then

                    For Each ServiceFeeReconcileDetail In CType(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

                        _ShowDetailsList.Add(ServiceFeeReconcileDetail)

                    Next

                Else

                    For Each ServiceFeeReconcileDetail In CType(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

                        _ShowDetailsList.Remove(ServiceFeeReconcileDetail)

                        If _ShowTimePostedDetailsList.Contains(ServiceFeeReconcileDetail) Then

                            _ShowTimePostedDetailsList.Remove(ServiceFeeReconcileDetail)

                        End If

                        If _ShowFeesBilledDetailsList.Contains(ServiceFeeReconcileDetail) Then

                            _ShowFeesBilledDetailsList.Remove(ServiceFeeReconcileDetail)

                        End If

                    Next

                End If

                CreateDocument()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LabelClientDivisionProduct_ReconcileIndicator_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles LabelClientDivisionProduct_ReconcileIndicator.BeforePrint

            'objects
            Dim ServiceFeeReconcileDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile) = Nothing
            Dim ServiceFeeReconcileDetail As AdvantageFramework.Database.Classes.ServiceFeeReconcile = Nothing

            Try

                If TypeOf Me.GetCurrentRow Is AdvantageFramework.Database.Classes.ServiceFeeReconcile Then

                    ServiceFeeReconcileDetail = Me.GetCurrentRow

                    ServiceFeeReconcileDetailList = CType(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.ServiceFeeReconcile))

                    If _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode).ToList

                    ElseIf _ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        ServiceFeeReconcileDetailList = ServiceFeeReconcileDetailList.Where(Function(ServiceFeeReconcileDtl) ServiceFeeReconcileDtl.ClientCode = ServiceFeeReconcileDetail.ClientCode AndAlso ServiceFeeReconcileDtl.DivisionCode = ServiceFeeReconcileDetail.DivisionCode AndAlso ServiceFeeReconcileDtl.ProductCode = ServiceFeeReconcileDetail.ProductCode).ToList

                    End If

                    If ServiceFeeReconcileDetailList.Sum(Function(Entity) Entity.ReconciledAmount) > 0 Then

                        TableCellHeader_RowHeader.Text = "Reconciled and Un-reconciled"

                    Else

                        TableCellHeader_RowHeader.Text = "Un-reconciled Only"

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
