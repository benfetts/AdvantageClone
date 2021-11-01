Namespace Media.Presentation

    Public Class MediaManagerForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SearchSettingsLoaded As Boolean = False
        Private _CanUserCustom1 As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            Dim SelectBy As Short = Nothing
            Dim IncludeOrder As Boolean = False
            Dim IncludeQuote As Boolean = False
            Dim MediaMonthStart As Date? = Nothing
            Dim MediaMonthEnd As Date? = Nothing

            Me.ShowWaitForm("Loading...")

            IncludeOrder = RadioButtonInclude_OrdersOnly.Checked OrElse RadioButtonInclude_Both.Checked
            IncludeQuote = RadioButtonInclude_QuotesOnly.Checked OrElse RadioButtonInclude_Both.Checked

            SelectBy = GetSelectBy()

            DataGridViewRightSection_Selections.ClearGridCustomization()
            DataGridViewRightSection_Selections.ShowSelectDeselectAllButtons = True

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If RadioButtonSelectBy_AllOpenOrders.Checked Then

                    DataGridViewRightSection_Selections.DataSource = Nothing
                    DataGridViewRightSection_Selections.ShowSelectDeselectAllButtons = False

                Else

                    If SearchableComboBoxForm_FilterBy.GetSelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth Then

                        MediaMonthStart = DateSerial(NumericInputMediaByMonth_YearFrom.GetValue, ComboBoxMediaByMonth_MonthFrom.GetSelectedValue, 1)
                        MediaMonthEnd = DateSerial(NumericInputMediaByMonth_YearTo.GetValue, ComboBoxMediaByMonth_MonthTo.GetSelectedValue, 1)

                    End If

                    DataGridViewRightSection_Selections.DataSource = AdvantageFramework.MediaManager.LoadMediaManagerSearchResults(DbContext, SelectBy, CheckBoxMediaType_Newspaper.Checked,
                        CheckBoxMediaType_Magazine.Checked, CheckBoxMediaType_Internet.Checked, CheckBoxMediaType_OutOfHome.Checked, CheckBoxMediaType_Radio.Checked, CheckBoxMediaType_Television.Checked,
                        IncludeOrder, IncludeQuote, CheckBoxInclude_ClosedOrders.Checked, DateTimePickerOrderLine_DateFrom.GetValue, DateTimePickerOrderLine_DateTo.GetValue, DateTimePickerJob_DateFrom.GetValue,
                        DateTimePickerJob_DateTo.GetValue, MediaMonthStart, MediaMonthEnd, SearchableComboBoxForm_FilterBy.GetSelectedValue, CheckBoxMediaType_PurchaseOrder.Checked)

                    If _CanUserCustom1 Then

                        For Each MediaSelectionAvailable In DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)

                            MediaSelectionAvailable.IsSelected = False

                        Next

                        DataGridViewRightSection_Selections.CurrentView.RefreshData()

                    End If

                End If

            End Using

            ToggleColumnVisibility()

            Me.CloseWaitForm()

        End Sub
        Private Function GetSelectBy() As Short

            Dim SelectBy As Short = Nothing

            For Each RadioButtonControl In GroupBoxSearch_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    SelectBy = RadioButtonControl.Tag
                    Exit For

                End If

            Next

            GetSelectBy = SelectBy

        End Function
        Private Sub LoadSearchSettings()

            Dim MediaManagerSearchSetting As AdvantageFramework.Database.Entities.MediaManagerSearchSetting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerSearchSetting = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaManagerSearchSetting).Where(Function(MMSS) MMSS.UserCode = Session.UserCode).FirstOrDefault

            End Using

            If MediaManagerSearchSetting IsNot Nothing Then

                _SearchSettingsLoaded = True

                For Each RadioButtonControl In GroupBoxSearch_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                    If RadioButtonControl.Tag = MediaManagerSearchSetting.SelectBy Then

                        RadioButtonControl.Checked = True
                        Exit For

                    End If

                Next

                CheckBoxMediaType_Internet.Checked = MediaManagerSearchSetting.SelectInternet
                CheckBoxMediaType_Magazine.Checked = MediaManagerSearchSetting.SelectMagazine
                CheckBoxMediaType_Newspaper.Checked = MediaManagerSearchSetting.SelectNewspaper
                CheckBoxMediaType_OutOfHome.Checked = MediaManagerSearchSetting.SelectOutOfHome
                CheckBoxMediaType_Radio.Checked = MediaManagerSearchSetting.SelectRadio
                CheckBoxMediaType_Television.Checked = MediaManagerSearchSetting.SelectTV
                CheckBoxMediaType_PurchaseOrder.Checked = MediaManagerSearchSetting.SelectPO

                Select Case MediaManagerSearchSetting.IncludeOrderQuoteBoth

                    Case 1

                        RadioButtonInclude_OrdersOnly.Checked = True

                    Case 2

                        RadioButtonInclude_QuotesOnly.Checked = True

                    Case 3

                        RadioButtonInclude_Both.Checked = True

                End Select

                SearchableComboBoxForm_FilterBy.SelectedValue = MediaManagerSearchSetting.FilterBy

                If MediaManagerSearchSetting.FilterBy = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.OrderLineDateRange Then

                    DateTimePickerOrderLine_DateFrom.ValueObject = MediaManagerSearchSetting.OrderLineStartDate
                    DateTimePickerOrderLine_DateTo.ValueObject = MediaManagerSearchSetting.OrderLineEndDate

                End If

                If MediaManagerSearchSetting.FilterBy = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.JoborMediaDatetoBill Then

                    DateTimePickerJob_DateFrom.ValueObject = MediaManagerSearchSetting.JobMediaStartDate
                    DateTimePickerJob_DateTo.ValueObject = MediaManagerSearchSetting.JobMediaEndDate

                End If

                CheckBoxInclude_ClosedOrders.Checked = MediaManagerSearchSetting.IncludeClosedOrders

                If MediaManagerSearchSetting.MediaMonthStart.HasValue Then

                    ComboBoxMediaByMonth_MonthFrom.SelectedValue = CLng(MediaManagerSearchSetting.MediaMonthStart.Value.Month)
                    NumericInputMediaByMonth_YearFrom.Value = MediaManagerSearchSetting.MediaMonthStart.Value.Year

                End If

                If MediaManagerSearchSetting.MediaMonthEnd.HasValue Then

                    ComboBoxMediaByMonth_MonthTo.SelectedValue = CLng(MediaManagerSearchSetting.MediaMonthEnd.Value.Month)
                    NumericInputMediaByMonth_YearTo.Value = MediaManagerSearchSetting.MediaMonthEnd.Value.Year

                End If

            Else

                RadioButtonSelectBy_AllOpenOrders.Checked = True

                SearchableComboBoxForm_FilterBy.SelectedValue = CStr(AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)

                SetLastSelectedFilterBy()

            End If

        End Sub
        Private Sub SaveSearchSettings(ByPassLockOrder As Boolean)

            Dim MediaManagerSearchSetting As AdvantageFramework.Database.Entities.MediaManagerSearchSetting = Nothing
            Dim IsNew As Boolean = False
            Dim ErrorMessage As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerSearchSetting = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaManagerSearchSetting).Where(Function(MMSS) MMSS.UserCode = Session.UserCode).FirstOrDefault

                If MediaManagerSearchSetting Is Nothing Then

                    MediaManagerSearchSetting = New AdvantageFramework.Database.Entities.MediaManagerSearchSetting
                    MediaManagerSearchSetting.DbContext = DbContext
                    MediaManagerSearchSetting.UserCode = Session.UserCode

                    IsNew = True

                End If

                LoadMediaManagerSearchSettingEntity(MediaManagerSearchSetting)

                If IsNew Then

                    AdvantageFramework.Database.Procedures.MediaManagerSearchSetting.Insert(DbContext, MediaManagerSearchSetting, ErrorMessage)

                Else

                    AdvantageFramework.Database.Procedures.MediaManagerSearchSetting.Update(DbContext, MediaManagerSearchSetting, ErrorMessage)

                End If

                If Not ByPassLockOrder Then

                    SaveSelections(DbContext)

                End If

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End Using

        End Sub
        Private Sub LoadMediaManagerSearchSettingEntity(ByRef MediaManagerSearchSetting As AdvantageFramework.Database.Entities.MediaManagerSearchSetting)

            MediaManagerSearchSetting.SelectBy = GetSelectBy()
            MediaManagerSearchSetting.SelectInternet = CheckBoxMediaType_Internet.Checked
            MediaManagerSearchSetting.SelectMagazine = CheckBoxMediaType_Magazine.Checked
            MediaManagerSearchSetting.SelectNewspaper = CheckBoxMediaType_Newspaper.Checked
            MediaManagerSearchSetting.SelectOutOfHome = CheckBoxMediaType_OutOfHome.Checked
            MediaManagerSearchSetting.SelectRadio = CheckBoxMediaType_Radio.Checked
            MediaManagerSearchSetting.SelectTV = CheckBoxMediaType_Television.Checked
            MediaManagerSearchSetting.SelectPO = CheckBoxMediaType_PurchaseOrder.Checked

            If RadioButtonInclude_OrdersOnly.Checked Then

                MediaManagerSearchSetting.IncludeOrderQuoteBoth = 1

            ElseIf RadioButtonInclude_QuotesOnly.Checked Then

                MediaManagerSearchSetting.IncludeOrderQuoteBoth = 2

            ElseIf RadioButtonInclude_Both.Checked Then

                MediaManagerSearchSetting.IncludeOrderQuoteBoth = 3

            End If

            MediaManagerSearchSetting.FilterBy = SearchableComboBoxForm_FilterBy.GetSelectedValue

            If MediaManagerSearchSetting.FilterBy = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth Then

                MediaManagerSearchSetting.MediaMonthStart = DateSerial(NumericInputMediaByMonth_YearFrom.GetValue, ComboBoxMediaByMonth_MonthFrom.GetSelectedValue, 1)
                MediaManagerSearchSetting.MediaMonthEnd = DateSerial(NumericInputMediaByMonth_YearTo.GetValue, ComboBoxMediaByMonth_MonthTo.GetSelectedValue, 1)

            Else

                MediaManagerSearchSetting.MediaMonthStart = Nothing
                MediaManagerSearchSetting.MediaMonthEnd = Nothing

            End If

            If MediaManagerSearchSetting.FilterBy = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.OrderLineDateRange Then

                MediaManagerSearchSetting.IncludeOrderLineDates = True

                MediaManagerSearchSetting.OrderLineStartDate = DateTimePickerOrderLine_DateFrom.GetValue
                MediaManagerSearchSetting.OrderLineEndDate = DateTimePickerOrderLine_DateTo.GetValue

            Else

                MediaManagerSearchSetting.OrderLineStartDate = Nothing
                MediaManagerSearchSetting.OrderLineEndDate = Nothing

            End If

            If MediaManagerSearchSetting.FilterBy = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.JoborMediaDatetoBill Then

                MediaManagerSearchSetting.IncludeJobMediaDateToBill = True

                MediaManagerSearchSetting.JobMediaStartDate = DateTimePickerJob_DateFrom.GetValue
                MediaManagerSearchSetting.JobMediaEndDate = DateTimePickerJob_DateTo.GetValue

            Else

                MediaManagerSearchSetting.JobMediaStartDate = Nothing
                MediaManagerSearchSetting.JobMediaEndDate = Nothing

            End If

            MediaManagerSearchSetting.IncludeClosedOrders = CheckBoxInclude_ClosedOrders.Checked

        End Sub
        Private Sub SetVisibleIndex(FieldName As String, VisibleIndex As Integer, Optional Visible As Boolean = True)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = DataGridViewRightSection_Selections.CurrentView.Columns(FieldName)

            If GridColumn IsNot Nothing AndAlso GridColumn.FieldName = FieldName Then

                GridColumn.VisibleIndex = VisibleIndex
                GridColumn.Visible = Visible

            End If

        End Sub
        Private Sub ToggleColumnVisibility()

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim IsVisible As Boolean = False

            If RadioButtonSelectBy_Campaign.Checked Then

                For Each GridColumn In DataGridViewRightSection_Selections.Columns

                    GridColumn.VisibleIndex = -1
                    GridColumn.Visible = False

                Next

                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.IsSelected.ToString, 0)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString, 1)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString, 2)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString, 3)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString, 4, ButtonItemView_ShowDescriptions.Checked)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString, 5)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString, 6, ButtonItemView_ShowDescriptions.Checked)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString, 7)
                SetVisibleIndex(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString, 8, ButtonItemView_ShowDescriptions.Checked)

            Else

                IsVisible = ButtonItemView_ShowDescriptions.Checked

                For Each GridColumn In DataGridViewRightSection_Selections.Columns

                    If RadioButtonSelectBy_AllOpenOrders.Checked Then

                        If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString) AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_Client.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_ClientDivision.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_ClientDivisionProduct.Checked Then

                        If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString) AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_Job.Checked Then

                        If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString) AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_JobComponent.Checked Then

                        If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString) AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_Order.Checked Then

                        If (GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString) AndAlso
                            Not IsVisible Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_Buyer.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_AccountExecutiveDefault.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_AccountExecutiveJob.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_OrderStatus.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VendorName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_Vendor.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.LineNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.MediaFrom.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    ElseIf RadioButtonSelectBy_LastFour.Checked Then

                        If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ClientName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DivisionName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.ProductDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignID.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.CampaignName.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentNumber.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.JobComponentDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatus.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderStatusDescription.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.EmployeeCode.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.AccountExecutive.ToString OrElse
                            GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.Buyer.ToString Then

                            GridColumn.VisibleIndex = -1
                            GridColumn.Visible = False

                        Else

                            GridColumn.VisibleIndex = VisibleIndex
                            VisibleIndex += 1
                            GridColumn.Visible = True

                        End If

                    End If

                    If GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VCCCardNumber.ToString Then

                        GridColumn.VisibleIndex = -1
                        GridColumn.Visible = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.VCCLastFour.ToString AndAlso Not RadioButtonSelectBy_LastFour.Checked Then

                        GridColumn.VisibleIndex = -1
                        GridColumn.Visible = False

                    ElseIf GridColumn.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.DisplayPONumber.ToString Then

                        GridColumn.VisibleIndex = -1
                        GridColumn.Visible = False

                    End If

                Next

            End If

            DataGridViewRightSection_Selections.CurrentView.BestFitColumns()

        End Sub
        Private Sub DeleteBatch()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Clearing

            DeleteSearchSettings()

            RadioButtonSelectBy_AllOpenOrders.Checked = True

            CheckBoxMediaType_Newspaper.Checked = False
            CheckBoxMediaType_Internet.Checked = False
            CheckBoxMediaType_Magazine.Checked = False
            CheckBoxMediaType_OutOfHome.Checked = False
            CheckBoxMediaType_Radio.Checked = False
            CheckBoxMediaType_Television.Checked = False

            RadioButtonInclude_Both.Checked = True

            SetDefaultFilterByDates()

            SearchableComboBoxForm_FilterBy.SelectedValue = CStr(AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)

            SetLastSelectedFilterBy()

            DataGridViewRightSection_Selections.ClearDatasource()

            ToggleColumnVisibility()

            Me.ClearValidations()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub DeleteSearchSettings()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.MediaManager.DeleteOrderSelection(DbContext)

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_MGR_SEARCH_SETTING WHERE MEDIA_MGR_SEARCH_SETTING_USER_CODE = '{0}'", Session.UserCode))

                _SearchSettingsLoaded = False

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemActions_Save.Enabled = Me.UserEntryChanged

                ButtonItemActions_Delete.Enabled = _SearchSettingsLoaded

                ButtonItemView_Review.Enabled = (_CanUserCustom1 OrElse Not Me.UserEntryChanged) AndAlso
                    ((DataGridViewRightSection_Selections.HasRows AndAlso DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Any) OrElse
                    RadioButtonSelectBy_AllOpenOrders.Checked AndAlso (CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse
                                                                       CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_Radio.Checked OrElse CheckBoxMediaType_Television.Checked OrElse CheckBoxMediaType_PurchaseOrder.Checked))

                GroupBoxSearch_SelectBy.Enabled = GroupBoxForm_SelectMediaTypes.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox).Where(Function(chk) chk.Checked = True).Any

                NumericInputSelectBy_OrderNumber.Visible = RadioButtonSelectBy_Order.Checked AndAlso Not ((CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse
                        CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_Radio.Checked OrElse CheckBoxMediaType_Television.Checked) AndAlso CheckBoxMediaType_PurchaseOrder.Checked)

                TextBoxSelectBy_LastFour.Visible = RadioButtonSelectBy_LastFour.Checked

                'If (CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse
                '        CheckBoxMediaType_OutOfHome.Checked OrElse CheckBoxMediaType_Radio.Checked OrElse CheckBoxMediaType_Television.Checked) AndAlso CheckBoxMediaType_PurchaseOrder.Checked Then

                '    RadioButtonSelectBy_Order.Enabled = False

                'Else

                '    RadioButtonSelectBy_Order.Enabled = True

                'End If

            End If

        End Sub
        Private Sub RadioButtonSelectBy_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormAction = WinForm.Presentation.FormActions.None AndAlso e.NewChecked.Checked Then

                LoadGrid()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonInclude_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            SetToAllOpenOrders()

            CheckBoxInclude_ClosedOrders.Enabled = RadioButtonInclude_Both.Checked OrElse RadioButtonInclude_OrdersOnly.Checked

            If e.NewChecked.Name = RadioButtonInclude_QuotesOnly.Name Then

                CheckBoxInclude_ClosedOrders.Checked = False
                RadioButtonSelectBy_LastFour.Visible = False

            Else

                RadioButtonSelectBy_LastFour.Visible = True

            End If

        End Sub
        Private Sub SaveSelections(DbContext As AdvantageFramework.Database.DbContext)

            Dim AccountExecutiveDefaults As IEnumerable(Of String) = Nothing
            Dim AccountExecutiveJobs As IEnumerable(Of String) = Nothing
            Dim CampaignIDs As IEnumerable(Of Integer) = Nothing
            Dim Clients As IEnumerable(Of String) = Nothing
            Dim ClientDivisions As IEnumerable(Of String) = Nothing
            Dim ClientDivisionProducts As IEnumerable(Of String) = Nothing
            Dim JobNumbers As IEnumerable(Of Integer) = Nothing
            Dim JobNumbersComponents As IEnumerable(Of String) = Nothing
            Dim OrderNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderStatuses As IEnumerable(Of Short) = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim Buyers As IEnumerable(Of String) = Nothing

            For Each RadioButtonControl In GroupBoxSearch_SelectBy.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)()

                If RadioButtonControl.Checked Then

                    Select Case CInt(RadioButtonControl.Tag)

                        Case MediaManagerSelectBy.AccountExecutiveDefault

                            AccountExecutiveDefaults = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.EmployeeCode).ToList

                        Case MediaManagerSelectBy.AccountExecutiveJob

                            AccountExecutiveJobs = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.EmployeeCode).ToList

                        Case MediaManagerSelectBy.Campaign

                            CampaignIDs = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.CampaignID.Value).ToList

                        Case MediaManagerSelectBy.Client

                            Clients = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.ClientCode).ToList

                        Case MediaManagerSelectBy.ClientDivision

                            ClientDivisions = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode).ToList

                        Case MediaManagerSelectBy.ClientDivisionProduct

                            ClientDivisionProducts = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.ClientCode + "|" + Entity.DivisionCode + "|" + Entity.ProductCode).ToList

                        Case MediaManagerSelectBy.Job

                            JobNumbers = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.JobNumber.Value).ToList

                        Case MediaManagerSelectBy.JobComponent

                            JobNumbersComponents = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) CStr(Entity.JobNumber.Value) + "|" + CStr(Entity.JobComponentNumber.Value)).ToList

                        Case MediaManagerSelectBy.Order

                            OrderNumbers = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.OrderNumber.Value).ToList

                        Case MediaManagerSelectBy.OrderStatus

                            OrderStatuses = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.OrderStatus.Value).ToList

                        Case MediaManagerSelectBy.Vendor

                            VendorCodes = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.VendorCode).ToList

                        Case MediaManagerSelectBy.LastFour

                            OrderNumbers = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.OrderNumber.Value).ToList

                        Case MediaManagerSelectBy.Buyer

                            Buyers = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)().Where(Function(Entity) Entity.IsSelected = True).Select(Function(Entity) Entity.EmployeeCode).ToList

                    End Select

                    AdvantageFramework.MediaManager.DeleteOrderSelection(DbContext)

                    AdvantageFramework.MediaManager.SaveOrderSelection(DbContext, Clients, ClientDivisions, ClientDivisionProducts, CampaignIDs, JobNumbers, JobNumbersComponents, OrderNumbers, AccountExecutiveDefaults, AccountExecutiveJobs, OrderStatuses, VendorCodes, Buyers)

                    Exit For

                End If

            Next

        End Sub
        Private Sub SetToAllOpenOrders()

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Me.FormAction = WinForm.Presentation.Methods.FormActions.Clearing

                RadioButtonSelectBy_AllOpenOrders.Checked = True

                DataGridViewRightSection_Selections.ClearGridCustomization()

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SetMediaCheckboxes(ByVal Checked As Boolean)

            CheckBoxMediaType_Internet.Checked = Checked
            CheckBoxMediaType_Magazine.Checked = Checked
            CheckBoxMediaType_Newspaper.Checked = Checked
            CheckBoxMediaType_OutOfHome.Checked = Checked
            CheckBoxMediaType_Radio.Checked = Checked
            CheckBoxMediaType_Television.Checked = Checked

            If CheckBoxMediaType_PurchaseOrder.Visible Then

                CheckBoxMediaType_PurchaseOrder.Checked = Checked

            End If

            SetToAllOpenOrders()

        End Sub
        Private Sub SaveLastSelectedFilterBy()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerSearchFilterBy.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso SearchableComboBoxForm_FilterBy.HasASelectedValue Then

                    UserSetting.StringValue = SearchableComboBoxForm_FilterBy.GetSelectedValue

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing AndAlso SearchableComboBoxForm_FilterBy.HasASelectedValue Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerSearchFilterBy.ToString, SearchableComboBoxForm_FilterBy.GetSelectedValue, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Private Sub SetLastSelectedFilterBy()

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaManagerSearchFilterBy.ToString)

                Catch ex As Exception
                    UserSetting = Nothing
                End Try

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    SearchableComboBoxForm_FilterBy.SelectedValue = UserSetting.StringValue

                End If

            End Using

        End Sub
        Private Sub SetDefaultFilterByDates()

            DateTimePickerOrderLine_DateFrom.Value = DateSerial(Now.Year, Now.Month, 1)
            DateTimePickerOrderLine_DateTo.Value = DateSerial(Now.Year, Now.Month + 1, 0)

            DateTimePickerJob_DateFrom.ValueObject = Nothing
            DateTimePickerJob_DateTo.ValueObject = Nothing

            NumericInputMediaByMonth_YearFrom.EditValue = Now.Year
            NumericInputMediaByMonth_YearTo.EditValue = Now.Year

            ComboBoxMediaByMonth_MonthFrom.SelectedValue = CLng(Now.Month)
            ComboBoxMediaByMonth_MonthTo.SelectedValue = CLng(Now.Month)

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaManagerForm As AdvantageFramework.Media.Presentation.MediaManagerForm = Nothing

            MediaManagerForm = New AdvantageFramework.Media.Presentation.MediaManagerForm()

            MediaManagerForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerForm_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler RadioButtonSelectBy_AccountExecutiveDefault.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_AccountExecutiveJob.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_AllOpenOrders.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Job.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_JobComponent.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Order.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_OrderStatus.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Vendor.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_LastFour.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            RemoveHandler RadioButtonSelectBy_Buyer.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx

            RemoveHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Radio.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_Television.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            RemoveHandler CheckBoxMediaType_PurchaseOrder.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            RemoveHandler RadioButtonInclude_OrdersOnly.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx
            RemoveHandler RadioButtonInclude_QuotesOnly.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx
            RemoveHandler RadioButtonInclude_Both.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx

        End Sub
        Private Sub MediaManagerForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If (Me.ChildForms Is Nothing OrElse (Me.ChildForms IsNot Nothing AndAlso Me.ChildForms.Count = 0)) AndAlso (_SearchSettingsLoaded OrElse _CanUserCustom1) Then

                SaveLastSelectedFilterBy()

                If _CanUserCustom1 Then

                    DeleteSearchSettings()

                ElseIf AdvantageFramework.WinForm.MessageBox.Show("Would you like to delete this media manager batch?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    DeleteSearchSettings()

                End If

            End If

        End Sub
        Private Sub MediaManagerForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            ButtonItemView_OtherUserSelections.Image = AdvantageFramework.My.Resources.DepartmentTeamImage
            ButtonItemView_ShowDescriptions.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage
            ButtonItemView_Review.Image = AdvantageFramework.My.Resources.ViewImage

            AddHandler RadioButtonSelectBy_AccountExecutiveDefault.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_AccountExecutiveJob.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_AllOpenOrders.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Campaign.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Client.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_ClientDivision.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_ClientDivisionProduct.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Job.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_JobComponent.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Order.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_OrderStatus.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Vendor.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_LastFour.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx
            AddHandler RadioButtonSelectBy_Buyer.CheckedChangedEx, AddressOf RadioButtonSelectBy_CheckedChangedEx

            AddHandler CheckBoxMediaType_Newspaper.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Magazine.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_OutOfHome.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Internet.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Radio.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_Television.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx
            AddHandler CheckBoxMediaType_PurchaseOrder.CheckedChangedEx, AddressOf CheckBoxMediaType_CheckedChangedEx

            AddHandler RadioButtonInclude_OrdersOnly.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx
            AddHandler RadioButtonInclude_QuotesOnly.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx
            AddHandler RadioButtonInclude_Both.CheckedChangedEx, AddressOf RadioButtonInclude_CheckedChangedEx

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            NumericInputSelectBy_OrderNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
            NumericInputSelectBy_OrderNumber.EditValue = Nothing

            TextBoxSelectBy_LastFour.Text = Nothing

            RadioButtonSelectBy_AccountExecutiveDefault.Tag = MediaManagerSelectBy.AccountExecutiveDefault
            RadioButtonSelectBy_AccountExecutiveJob.Tag = MediaManagerSelectBy.AccountExecutiveJob
            RadioButtonSelectBy_AllOpenOrders.Tag = MediaManagerSelectBy.AllOpenOrders
            RadioButtonSelectBy_Campaign.Tag = MediaManagerSelectBy.Campaign
            RadioButtonSelectBy_Client.Tag = MediaManagerSelectBy.Client
            RadioButtonSelectBy_ClientDivision.Tag = MediaManagerSelectBy.ClientDivision
            RadioButtonSelectBy_ClientDivisionProduct.Tag = MediaManagerSelectBy.ClientDivisionProduct
            RadioButtonSelectBy_Job.Tag = MediaManagerSelectBy.Job
            RadioButtonSelectBy_JobComponent.Tag = MediaManagerSelectBy.JobComponent
            RadioButtonSelectBy_Order.Tag = MediaManagerSelectBy.Order
            RadioButtonSelectBy_OrderStatus.Tag = MediaManagerSelectBy.OrderStatus
            RadioButtonSelectBy_Vendor.Tag = MediaManagerSelectBy.Vendor
            RadioButtonSelectBy_LastFour.Tag = MediaManagerSelectBy.LastFour
            RadioButtonSelectBy_Buyer.Tag = MediaManagerSelectBy.Buyer

            DataGridViewRightSection_Selections.ShowSelectDeselectAllButtons = True
            DataGridViewRightSection_Selections.OptionsMenu.EnableColumnMenu = False
            DataGridViewRightSection_Selections.MultiSelect = False

            ComboBoxMediaByMonth_MonthFrom.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))
            ComboBoxMediaByMonth_MonthTo.DataSource = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.AbbreviatedMonths))

            SearchableComboBoxForm_FilterBy.HideValueMemberColumn = True
            SearchableComboBoxForm_FilterBy.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaManagerSearchFilterType))
                                                          Select Entity.Code,
                                                                 [Description] = Entity.Description).ToList

            SearchableComboBoxForm_FilterBy.SetRequired(True)

            SetDefaultFilterByDates()

            GroupBoxForm_DateRanges.Visible = False
            GroupBoxForm_JobMediaDateToBillDateRange.Visible = False
            GroupBoxForm_MediaByMonth.Visible = False

            _CanUserCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Session, AdvantageFramework.Security.Modules.Media_MediaManager)

            If _CanUserCustom1 Then

                RibbonBarOptions_Actions.Visible = False
                Me.ShowUnsavedChangesOnFormClosing = False

            End If

            If AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Media_MediaManager_Actions_Include_PurchaseOrders) Then

                GroupBoxForm_SelectMediaTypes.Height = 102
                CheckBoxMediaType_PurchaseOrder.Visible = True

            Else

                GroupBoxForm_SelectMediaTypes.Height = 76
                CheckBoxMediaType_PurchaseOrder.Visible = False

                GroupBoxForm_Include.Location = New System.Drawing.Point(GroupBoxForm_Include.Location.X, GroupBoxForm_Include.Location.Y - 26)
                LabelForm_FilterBy.Location = New System.Drawing.Point(LabelForm_FilterBy.Location.X, LabelForm_FilterBy.Location.Y - 26)
                SearchableComboBoxForm_FilterBy.Location = New System.Drawing.Point(SearchableComboBoxForm_FilterBy.Location.X, SearchableComboBoxForm_FilterBy.Location.Y - 26)
                GroupBoxForm_MediaByMonth.Location = New System.Drawing.Point(GroupBoxForm_MediaByMonth.Location.X, GroupBoxForm_MediaByMonth.Location.Y - 26)
                GroupBoxForm_JobMediaDateToBillDateRange.Location = New System.Drawing.Point(GroupBoxForm_JobMediaDateToBillDateRange.Location.X, GroupBoxForm_JobMediaDateToBillDateRange.Location.Y - 26)
                GroupBoxForm_DateRanges.Location = New System.Drawing.Point(GroupBoxForm_DateRanges.Location.X, GroupBoxForm_DateRanges.Location.Y - 26)
                GroupBoxSearch_SelectBy.Location = New System.Drawing.Point(GroupBoxSearch_SelectBy.Location.X, GroupBoxSearch_SelectBy.Location.Y - 26)

            End If

        End Sub
        Private Sub MediaManagerForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If AdvantageFramework.Security.IsMediaToolUser(Me.Session, Me.Session.User.ID) Then

                LoadSearchSettings()

                LoadGrid()

                Me.ClearChanged()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                EnableOrDisableActions()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("You must be a Media Tools User to access this module.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            DeleteBatch()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = ""

            GroupBoxSearch_SelectBy.Focus()

            If Me.Validator Then

                If CheckBoxMediaType_Internet.Checked OrElse CheckBoxMediaType_Magazine.Checked OrElse CheckBoxMediaType_Newspaper.Checked OrElse CheckBoxMediaType_OutOfHome.Checked OrElse
                        CheckBoxMediaType_Radio.Checked OrElse CheckBoxMediaType_Television.Checked OrElse CheckBoxMediaType_PurchaseOrder.Checked Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving

                    SaveSearchSettings(False)

                    LoadSearchSettings()

                    LoadGrid()

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    Me.ClearChanged()

                    EnableOrDisableActions()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one media type.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemMediaTypes_CheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaTypes_CheckAll.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying

            SetMediaCheckboxes(True)

            Me.FormAction = WinForm.Presentation.FormActions.None

            SetToAllOpenOrders()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemMediaTypes_UncheckAll_Click(sender As Object, e As EventArgs) Handles ButtonItemMediaTypes_UncheckAll.Click

            Me.FormAction = WinForm.Presentation.FormActions.Modifying

            SetMediaCheckboxes(False)

            Me.FormAction = WinForm.Presentation.FormActions.None

            SetToAllOpenOrders()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemView_Review_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Review.Click

            Dim MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult) = Nothing
            Dim SelectBy As Short = Nothing

            DataGridViewRightSection_Selections.CurrentView.CloseEditorForUpdating()

            MediaManagerSearchResults = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).Where(Function(MMS) MMS.IsSelected = True).ToList

            If MediaManagerSearchResults.Count > 0 OrElse RadioButtonSelectBy_AllOpenOrders.Checked Then

                SelectBy = GetSelectBy()

                If _CanUserCustom1 Then

                    SaveSearchSettings(True)

                End If

                If Me.ChildForms IsNot Nothing AndAlso Me.ChildForms.Count > 0 Then

                    For Each ChildForm In Me.ChildForms

                        If ChildForm.GetType Is GetType(AdvantageFramework.Media.Presentation.MediaManagerReviewDialog) Then

                            ChildForm.Activate()
                            Exit For

                        End If

                    Next

                Else

                    AdvantageFramework.Media.Presentation.MediaManagerReviewDialog.ShowForm(Me, SelectBy, MediaManagerSearchResults)

                End If

            End If

        End Sub
        Private Sub ButtonItemView_OtherUserSelections_Click(sender As Object, e As EventArgs) Handles ButtonItemView_OtherUserSelections.Click

            'objects
            Dim OtherUserSelections As Generic.List(Of AdvantageFramework.MediaManager.Classes.OtherUserSelection) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                OtherUserSelections = AdvantageFramework.MediaManager.LoadOtherUserSelections(Session).ToList

            End Using

            If OtherUserSelections.Count = 0 Then

                AdvantageFramework.WinForm.MessageBox.Show("There are no selections for other users.")

            Else

                AdvantageFramework.Media.Presentation.MediaManagerOtherUsersSelectionsDialog.ShowFormDialog(OtherUserSelections)

            End If

        End Sub
        Private Sub ButtonItemView_ShowDescriptions_Click(sender As Object, e As EventArgs) Handles ButtonItemView_ShowDescriptions.Click

            ToggleColumnVisibility()

        End Sub
        Private Sub CheckBoxInclude_ClosedOrders_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxInclude_ClosedOrders.CheckedChanged

            SetToAllOpenOrders()

        End Sub
        Private Sub CheckBoxMediaType_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            SetToAllOpenOrders()

        End Sub
        Private Sub ComboBoxMediaByMonth_MonthFrom_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaByMonth_MonthFrom.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub ComboBoxMediaByMonth_MonthTo_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxMediaByMonth_MonthTo.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub DataGridViewRightSection_Selections_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_Selections.CellValueChangingEvent

            Dim MediaManagerSearchResults As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult) = Nothing
            Dim OrderNumber As Integer = Nothing

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.IsSelected.ToString Then

                DirectCast(DataGridViewRightSection_Selections.CurrentView.GetRow(DataGridViewRightSection_Selections.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).IsSelected = e.Value

                If DataGridViewRightSection_Selections.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString).Visible Then

                    OrderNumber = DirectCast(DataGridViewRightSection_Selections.CurrentView.GetRow(DataGridViewRightSection_Selections.CurrentView.FocusedRowHandle), AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).OrderNumber.Value

                    MediaManagerSearchResults = DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).Where(Function(MMSR) MMSR.OrderNumber = OrderNumber).ToList

                    For Each MediaManagerSearchResult In MediaManagerSearchResults

                        MediaManagerSearchResult.IsSelected = e.Value

                    Next

                End If

                DataGridViewRightSection_Selections.CurrentView.RefreshData()

                DataGridViewRightSection_Selections.SetUserEntryChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_Selections_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewRightSection_Selections.CustomColumnDisplayTextEvent

            If e.Column.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.OrderNumber.ToString AndAlso RadioButtonSelectBy_Order.Checked AndAlso e.Column.View.GetRowHandle(e.ListSourceRowIndex) >= 0 Then

                If DirectCast(DataGridViewRightSection_Selections.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).MediaFrom = "PO" AndAlso
                        IsNumeric(DirectCast(DataGridViewRightSection_Selections.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).DisplayPONumber) = False Then

                    e.DisplayText = DirectCast(DataGridViewRightSection_Selections.CurrentView.GetRow(e.Column.View.GetRowHandle(e.ListSourceRowIndex)), AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).DisplayPONumber

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_Selections_DeselectAllEvent() Handles DataGridViewRightSection_Selections.DeselectAllEvent

            For Each MediaSelectionAvailable In DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).ToList

                MediaSelectionAvailable.IsSelected = False

            Next

            DataGridViewRightSection_Selections.CurrentView.RefreshData()

            DataGridViewRightSection_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_Selections_SelectAllEvent() Handles DataGridViewRightSection_Selections.SelectAllEvent

            For Each MediaSelectionAvailable In DataGridViewRightSection_Selections.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult).ToList

                MediaSelectionAvailable.IsSelected = True

            Next

            DataGridViewRightSection_Selections.CurrentView.RefreshData()

            DataGridViewRightSection_Selections.SetUserEntryChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_Selections_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightSection_Selections.ShowingEditorEvent

            If DataGridViewRightSection_Selections.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult.Properties.IsSelected.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerJob_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJob_DateFrom.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerJob_DateFrom.ValueObject IsNot Nothing AndAlso (DateTimePickerJob_DateTo.ValueObject Is Nothing OrElse DateTimePickerJob_DateFrom.GetValue > DateTimePickerJob_DateTo.GetValue) Then

                    DateTimePickerJob_DateTo.Value = DateAdd(DateInterval.Day, 6, DateTimePickerJob_DateFrom.Value)

                End If

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub DateTimePickerJob_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerJob_DateTo.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerJob_DateTo.ValueObject IsNot Nothing AndAlso (DateTimePickerJob_DateFrom.ValueObject Is Nothing OrElse DateTimePickerJob_DateTo.GetValue < DateTimePickerJob_DateFrom.GetValue) Then

                    DateTimePickerJob_DateFrom.Value = DateAdd(DateInterval.Day, -6, DateTimePickerJob_DateTo.Value)

                End If

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub DateTimePickerOrderLine_DateFrom_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerOrderLine_DateFrom.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerOrderLine_DateFrom.GetValue > DateTimePickerOrderLine_DateTo.GetValue Then

                    DateTimePickerOrderLine_DateTo.Value = DateTimePickerOrderLine_DateFrom.Value

                End If

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub DateTimePickerOrderLine_DateTo_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerOrderLine_DateTo.ValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If DateTimePickerOrderLine_DateTo.GetValue < DateTimePickerOrderLine_DateFrom.GetValue Then

                    DateTimePickerOrderLine_DateFrom.Value = DateTimePickerOrderLine_DateTo.Value

                End If

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub NumericInputMediaByMonth_YearFrom_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputMediaByMonth_YearFrom.EditValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub NumericInputMediaByMonth_YearTo_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputMediaByMonth_YearTo.EditValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                SetToAllOpenOrders()

            End If

        End Sub
        Private Sub NumericInputSelectBy_OrderNumber_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles NumericInputSelectBy_OrderNumber.EditValueChanging

            If Me.FormShown AndAlso IsNumeric(e.NewValue) AndAlso e.NewValue = 0 Then

                e.NewValue = Nothing
                e.Cancel = True

            End If

        End Sub
        Private Sub NumericInputSelectBy_OrderNumber_Leave(sender As Object, e As EventArgs) Handles NumericInputSelectBy_OrderNumber.Leave

            'objects
            Dim OrderNumber As Integer = Nothing
            Dim MediaManagerSearchResult As AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult = Nothing
            Dim OrderNumberFound As Boolean = False

            If NumericInputSelectBy_OrderNumber.EditValue IsNot Nothing Then

                If RadioButtonSelectBy_AllOpenOrders.Checked OrElse RadioButtonSelectBy_Order.Checked Then

                    OrderNumber = NumericInputSelectBy_OrderNumber.EditValue

                    For Each RowHandlesAndDataBoundItem In DataGridViewRightSection_Selections.GetAllRowsRowHandlesAndDataBoundItems

                        Try

                            MediaManagerSearchResult = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            MediaManagerSearchResult = Nothing
                        End Try

                        If MediaManagerSearchResult IsNot Nothing AndAlso MediaManagerSearchResult.OrderNumber = OrderNumber Then

                            MediaManagerSearchResult.IsSelected = 1
                            DataGridViewRightSection_Selections.CurrentView.MakeRowVisible(RowHandlesAndDataBoundItem.Key)
                            OrderNumberFound = True

                        End If

                    Next

                    DataGridViewRightSection_Selections.CurrentView.RefreshData()

                End If

                NumericInputSelectBy_OrderNumber.EditValue = Nothing
                NumericInputSelectBy_OrderNumber.Focus()

                If Not OrderNumberFound Then

                    AdvantageFramework.WinForm.MessageBox.Show("Order number '" & OrderNumber & "' is either locked or otherwise unavailable.")

                End If

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_FilterBy_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_FilterBy.EditValueChanged

            If Me.FormShown Then

                GroupBoxForm_DateRanges.Visible = (SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.OrderLineDateRange)
                GroupBoxForm_JobMediaDateToBillDateRange.Visible = (SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.JoborMediaDatetoBill)
                GroupBoxForm_MediaByMonth.Visible = (SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)

                DateTimePickerJob_DateFrom.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.JoborMediaDatetoBill)
                DateTimePickerJob_DateTo.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.JoborMediaDatetoBill)

                DateTimePickerOrderLine_DateFrom.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.OrderLineDateRange)
                DateTimePickerOrderLine_DateTo.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.OrderLineDateRange)

                ComboBoxMediaByMonth_MonthFrom.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)
                ComboBoxMediaByMonth_MonthTo.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)
                NumericInputMediaByMonth_YearFrom.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)
                NumericInputMediaByMonth_YearTo.SetRequired(SearchableComboBoxForm_FilterBy.SelectedValue = AdvantageFramework.Database.Entities.MediaManagerSearchFilterType.MediaByMonth)

                SetDefaultFilterByDates()

                SetToAllOpenOrders()

                Me.ClearValidations()

            End If

        End Sub
        Private Sub TextBoxSelectBy_LastFour_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSelectBy_LastFour.KeyPress

            If Char.IsNumber(e.KeyChar) = False AndAlso e.KeyChar <> ChrW(System.Windows.Forms.Keys.Back) Then

                e.Handled = True

            End If

        End Sub
        Private Sub TextBoxSelectBy_LastFour_Leave(sender As Object, e As EventArgs) Handles TextBoxSelectBy_LastFour.Leave

            'objects
            Dim LastFour As String = Nothing
            Dim MediaManagerSearchResult As AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult = Nothing
            Dim LastFourFound As Boolean = False

            If Not String.IsNullOrWhiteSpace(TextBoxSelectBy_LastFour.Text) Then

                If RadioButtonSelectBy_LastFour.Checked Then

                    LastFour = TextBoxSelectBy_LastFour.Text

                    For Each RowHandlesAndDataBoundItem In DataGridViewRightSection_Selections.GetAllRowsRowHandlesAndDataBoundItems

                        Try

                            MediaManagerSearchResult = RowHandlesAndDataBoundItem.Value

                        Catch ex As Exception
                            MediaManagerSearchResult = Nothing
                        End Try

                        If MediaManagerSearchResult IsNot Nothing AndAlso MediaManagerSearchResult.VCCLastFour = LastFour Then

                            MediaManagerSearchResult.IsSelected = 1
                            DataGridViewRightSection_Selections.CurrentView.MakeRowVisible(RowHandlesAndDataBoundItem.Key)
                            LastFourFound = True

                        End If

                    Next

                    DataGridViewRightSection_Selections.CurrentView.RefreshData()

                End If

                TextBoxSelectBy_LastFour.Text = Nothing
                TextBoxSelectBy_LastFour.Focus()

                If Not LastFourFound Then

                    AdvantageFramework.WinForm.MessageBox.Show("VCC last four '" & LastFour & "' is either locked or otherwise unavailable.")

                End If

                EnableOrDisableActions()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace