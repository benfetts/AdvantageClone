Namespace WinForm.Presentation

    Public Class AutoFillDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _SelectedItemIndex As Integer = Nothing
        Private _NumberOfItems As Integer = Nothing
        Private _AutoFillItems As IEnumerable = Nothing
        Private _NotVisibleFieldNames As IEnumerable(Of String) = Nothing
        Private _AutoFillItemsCopy As Generic.List(Of Object) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property AutoFillItems As IEnumerable
            Get
                AutoFillItems = _AutoFillItems
            End Get
        End Property
        Public ReadOnly Property SelectedObject As Object
            Get
                SelectedObject = PropertyGridControlForm_Properties.SelectedObject
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef AutoFillItems As IEnumerable, Optional ByVal NotVisibleFieldNames As IEnumerable(Of String) = Nothing)

            ' This call is required by the designer.
            InitializeComponent()

            _AutoFillItems = AutoFillItems
            _NotVisibleFieldNames = NotVisibleFieldNames

            _AutoFillItemsCopy = New Generic.List(Of Object)

            For Each AutoFillItem In AutoFillItems

                If TypeOf AutoFillItem Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).Copy)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment).Copy)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment).Copy)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.MediaManager.Classes.VCCOrder Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.VCCOrder).Clone)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).DuplicateEntity)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).DuplicateEntity)

                ElseIf TypeOf AutoFillItem Is AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice Then

                    _AutoFillItemsCopy.Add(DirectCast(AutoFillItem, AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).Clone)

                End If

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            If RadioButtonControlForm_FromBlank.Checked Then

                ButtonForm_SelectFirst.Visible = False
                ButtonForm_SelectLast.Visible = False
                ButtonForm_SelectNext.Visible = False
                ButtonForm_SelectPrevious.Visible = False

            Else

                ButtonForm_SelectFirst.Visible = True
                ButtonForm_SelectLast.Visible = True
                ButtonForm_SelectNext.Visible = True
                ButtonForm_SelectPrevious.Visible = True

                ButtonForm_SelectFirst.Enabled = Convert.ToBoolean(_SelectedItemIndex)
                ButtonForm_SelectLast.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectNext.Enabled = If(_SelectedItemIndex + 1 < _NumberOfItems, True, False)
                ButtonForm_SelectPrevious.Enabled = Convert.ToBoolean(_SelectedItemIndex)

            End If

        End Sub
        Private Sub LoadObject()

            'objects
            Dim SelectedObject = Nothing
            Dim AutoFillItem As Object = Nothing

            If RadioButtonControlForm_FromBlank.Checked Then

                Try

                    AutoFillItem = (From Item In _AutoFillItems
                                    Select Item).FirstOrDefault

                Catch ex As Exception
                    AutoFillItem = Nothing
                End Try

                If AutoFillItem IsNot Nothing Then

                    Try

                        If AutoFillItem.GetType.GetConstructor(Type.EmptyTypes) IsNot Nothing Then

                            SelectedObject = System.Activator.CreateInstance(AutoFillItem.GetType)

                        End If

                        If TypeOf SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then 'set values needed for QueryPopupNeedDatasource

                            DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ClientCode = AutoFillItem.ClientCode
                            DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).DivisionCode = AutoFillItem.DivisionCode
                            DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ProductCode = AutoFillItem.ProductCode
                            DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom = AutoFillItem.MediaFrom

                        End If

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

            Else

                Try

                    AutoFillItem = _AutoFillItemsCopy(_SelectedItemIndex)

                Catch ex As Exception
                    AutoFillItem = Nothing
                End Try

                If AutoFillItem IsNot Nothing Then

                    Try

                        SelectedObject = AutoFillItem

                    Catch ex As Exception
                        SelectedObject = Nothing
                    End Try

                End If

            End If

            PropertyGridControlForm_Properties.SelectedObject = SelectedObject

            PropertyGridControlForm_Properties.HideRowsByFieldName(_NotVisibleFieldNames)

            If TypeOf SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                HideMediaManagerReviewDetailRows(SelectedObject)

            ElseIf TypeOf SelectedObject Is AdvantageFramework.Database.Entities.Market Then

                RadioButtonControlForm_UpdateFromSelected.Visible = False

                PropertyGridControlForm_Properties.Rows(0).Visible = True

                If PropertyGridControlForm_Properties.Rows(0).ChildRows IsNot Nothing AndAlso PropertyGridControlForm_Properties.Rows(0).ChildRows.Count > 0 Then

                    PropertyGridControlForm_Properties.Rows(0).ChildRows(0).Visible = True

                End If

            ElseIf TypeOf SelectedObject Is AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice Then

                If DirectCast(_AutoFillItems, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)).AsQueryable.Select(Function(ARI) ARI.ClientCode).Distinct.Count > 1 Then

                    PropertyGridControlForm_Properties.Rows(0).ChildRows(3).Visible = False

                End If

            End If
            
        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef AutoFillItems As IEnumerable, Optional ByVal NotVisibleFieldNames As IEnumerable(Of String) = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim AutoFillDialog As AdvantageFramework.WinForm.Presentation.AutoFillDialog = Nothing

            AutoFillDialog = New AdvantageFramework.WinForm.Presentation.AutoFillDialog(AutoFillItems, NotVisibleFieldNames)

            ShowFormDialog = AutoFillDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                AutoFillItems = AutoFillDialog.AutoFillItems

            End If

        End Function
        Public Shared Function ShowFormDialog(AutoFillItems As IEnumerable, ByRef SelectedObject As Object) As System.Windows.Forms.DialogResult

            'objects
            Dim AutoFillDialog As AdvantageFramework.WinForm.Presentation.AutoFillDialog = Nothing

            AutoFillDialog = New AdvantageFramework.WinForm.Presentation.AutoFillDialog(AutoFillItems)

            ShowFormDialog = AutoFillDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                SelectedObject = AutoFillDialog.SelectedObject

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AutoFillDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _NumberOfItems = (From Item In AutoFillItems
                              Select Item).Count

            RadioButtonControlForm_FromBlank.Checked = True

            PropertyGridControlForm_Properties.ControlType = WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.AutoFill

            PropertyGridControlForm_Properties.AutoFilterLookupColumns = True
            PropertyGridControlForm_Properties.AutoloadRepositoryDatasource = True

            If (From Item In AutoFillItems
                Select Item).Count > 0 AndAlso TypeOf AutoFillItems(0) Is AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification Then

                RadioButtonControlForm_FromBlank.Enabled = False
                RadioButtonControlForm_UpdateFromSelected.Checked = True

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim SelectedObject As Object = Nothing
            Dim Value As Object = Nothing
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If Me.Validator Then

                Me.ShowWaitForm("Auto Filling ...")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    SelectedObject = PropertyGridControlForm_Properties.SelectedObject

                    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(SelectedObject).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                    For Each AutoFillItem In (From Entity In _AutoFillItems
                                              Select Entity).ToList

                        For Each PropertyDescriptor In PropertyDescriptors

                            Try

                                EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                            Catch ex As Exception
                                EntityAttribute = Nothing
                            End Try

                            If PropertyGridControlForm_Properties.VisibleRows.OfType(Of DevExpress.XtraVerticalGrid.Rows.EditorRow).Any(Function(EditorRow) EditorRow.Properties.FieldName = PropertyDescriptor.Name) Then

                                Value = PropertyDescriptor.GetValue(SelectedObject)

                                If Value IsNot Nothing Then

                                    Try

                                        If TypeOf SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail AndAlso
                                                    (PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.StartDate.ToString OrElse
                                                     PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString OrElse
                                                     PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString OrElse
                                                     PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString OrElse
                                                     PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString OrElse
                                                     PropertyDescriptor.Name = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString) Then

                                            FillMediaManagerReviewDetailColumn(DbContext, SelectedObject, AutoFillItem, PropertyDescriptor.Name)

                                        ElseIf Value.GetType Is GetType(String) Then

                                            If String.IsNullOrEmpty(Value) = False Then

                                                PropertyDescriptor.SetValue(AutoFillItem, PropertyDescriptor.GetValue(SelectedObject))

                                            End If

                                        Else

                                            PropertyDescriptor.SetValue(AutoFillItem, PropertyDescriptor.GetValue(SelectedObject))

                                        End If

                                        If TypeOf SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail AndAlso
                                                PropertyDescriptor.Name <> AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString Then

                                            DirectCast(AutoFillItem, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ReviseUpdateOrder = True

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If

                            End If

                        Next

                    Next

                End Using

                Me.CloseWaitForm()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonControlForm_UpdateFromSelected_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonControlForm_UpdateFromSelected.CheckedChanged

            LoadObject()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectFirst_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectFirst.Click

            _SelectedItemIndex = 0

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectLast_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectLast.Click

            If _NumberOfItems > 0 Then

                _SelectedItemIndex = _NumberOfItems - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectNext_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectNext.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex + 1 < _NumberOfItems Then

                _SelectedItemIndex = _SelectedItemIndex + 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_SelectPrevious_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_SelectPrevious.Click

            If _NumberOfItems > 0 AndAlso _SelectedItemIndex - 1 >= 0 Then

                _SelectedItemIndex = _SelectedItemIndex - 1

            Else

                _SelectedItemIndex = 0

            End If

            LoadObject()
            EnableOrDisableActions()

        End Sub
        Private Sub PropertyGridControlForm_Properties_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles PropertyGridControlForm_Properties.QueryPopupNeedDatasource

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                MediaManagerReviewDetail_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

            ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.VCCOrder Then

                VCCOrder_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

            ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine Then

                MediaRFPAvailLine_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

            ElseIf TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice Then

                AccountReceivableInvoice_QueryPopupNeedDatasource(FieldName, OverrideDefaultDatasource, Datasource)

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_RowChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.RowChangedEventArgs) Handles PropertyGridControlForm_Properties.RowChanged

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                MediaManagerReviewDetail_RowChanged(e)

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_ShowingEditor(sender As Object, e As ComponentModel.CancelEventArgs) Handles PropertyGridControlForm_Properties.ShowingEditor

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                MediaManagerReviewDetail_ShowingEditor(e)

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_SubItemTextBoxButtonClickEvent(SelectedObject As Object) Handles PropertyGridControlForm_Properties.SubItemTextBoxButtonClickEvent

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail Then

                MediaManagerReviewDetail_SubItemTextBoxButtonClickEvent(SelectedObject)

            End If

        End Sub

#End Region

#Region " MediaManagerReviewDetail "

        Private Sub FillMediaManagerReviewDetailColumn(DbContext As AdvantageFramework.Database.DbContext,
                                                       SelectedObject As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                                       ByRef AutoFillItem As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                                       FieldName As String)

            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.StartDate.ToString Then

                AutoFillItem.StartDate = SelectedObject.StartDate

                If AutoFillItem.MediaFrom = "TV" OrElse AutoFillItem.MediaFrom = "Radio" Then

                    AutoFillItem.MonthYear = AdvantageFramework.MediaManager.GetBroadcastMonthYear(DbContext, SelectedObject.StartDate.Value)

                Else

                    AutoFillItem.MonthYear = MonthName(DatePart(DateInterval.Month, SelectedObject.StartDate.Value), True).ToUpper & " " & DatePart(DateInterval.Year, SelectedObject.StartDate.Value)

                End If

                AutoFillItem.SetCloseAndMaterialDates(DbContext)

                If AutoFillItem.MediaFrom = "Newspaper" OrElse AutoFillItem.MediaFrom = "Magazine" Then

                    AutoFillItem.EndDate = SelectedObject.StartDate.Value

                ElseIf AutoFillItem.MediaFrom = "Radio" OrElse AutoFillItem.MediaFrom = "TV" Then

                    If AutoFillItem.EndDate.HasValue AndAlso SelectedObject.StartDate.Value > AutoFillItem.EndDate Then

                        AutoFillItem.EndDate = Nothing

                    End If

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString AndAlso SelectedObject.JobNumber.HasValue AndAlso Not SelectedObject.JobMediaBillDate.HasValue Then

                AutoFillItem.JobComponentNumber = SelectedObject.JobComponentNumber

                JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, SelectedObject.JobNumber.Value, SelectedObject.JobComponentNumber)

                If JobComponent IsNot Nothing Then

                    AutoFillItem.JobMediaBillDate = JobComponent.MediaBillDate

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobMediaBillDate.ToString Then

                If SelectedObject.JobNumber.HasValue AndAlso SelectedObject.JobComponentNumber.HasValue Then

                    AutoFillItem.JobMediaBillDate = SelectedObject.JobMediaBillDate
                    AutoFillItem.JobMediaBillDateColumnUpdated = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString Then

                If AutoFillItem.NetGross = "Gross" Then

                    AutoFillItem.RebatePercent = SelectedObject.RebatePercent

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString Then

                If AutoFillItem.NetGross = "Net" Then

                    AutoFillItem.MarkupPercent = SelectedObject.MarkupPercent

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString Then

                If AutoFillItem.AdServerPlacementID.HasValue = False Then

                    AutoFillItem.InternetType = SelectedObject.InternetType

                End If

            End If

        End Sub
        Private Sub HideMediaManagerReviewDetailRows(ByVal SelectedObject As Object)

            If (From Item In _AutoFillItems
                Select DirectCast(Item, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).ClientCode).Distinct.Count > 1 Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobNumber.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Internet" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetURL.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetTargetAudience.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement1.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetPlacement2.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Newspaper" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperSection.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculation.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Magazine" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MagazineCirculationQTY.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Newspaper" AndAlso
                        DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Magazine" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Material.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ProductionSize.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Issue.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Out Of Home" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorCopyArea.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorLocation.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.OutdoorType.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom = "Radio" OrElse
                        DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom = "TV" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Headline.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Radio" AndAlso
                    DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "TV" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastProgramming.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastStartTime.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastEndTime.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastLength.ToString)
                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BroadcastRemarks.ToString)

            End If

            If DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom = "Newspaper" Then

                If (From Item In _AutoFillItems
                    Where DirectCast(Item, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).IsDailyNewspaper = False
                    Select Item).Any Then

                    PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.EndDate.ToString)

                End If

            ElseIf DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Out Of Home" AndAlso
                        DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail).MediaFrom <> "Internet" Then

                PropertyGridControlForm_Properties.HideRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.EndDate.ToString)

            End If

        End Sub
        Private Sub MediaManagerReviewDetail_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing

            MediaManagerReviewDetail = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            If FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetAdNumberDatasource(DbContext, MediaManagerReviewDetail.ClientCode)

                End Using

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.CampaignID.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetCampaignIDDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode)

                End Using

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobNumber.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetJobNumberDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode)

                End Using

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString Then

                OverrideDefaultDatasource = True

                If MediaManagerReviewDetail.JobNumber.HasValue Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Datasource = AdvantageFramework.MediaManager.GetJobComponentNumberDatasource(DbContext, MediaManagerReviewDetail.ClientCode, MediaManagerReviewDetail.DivisionCode, MediaManagerReviewDetail.ProductCode, MediaManagerReviewDetail.JobNumber)

                    End Using

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetAdSizeCodeDatasource(DbContext, MediaManagerReviewDetail.MediaFrom)

                End Using

            End If

        End Sub
        Private Sub MediaManagerReviewDetail_RowChanged(e As DevExpress.XtraVerticalGrid.Events.RowChangedEventArgs)

            'objects
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim MediaBuyer As AdvantageFramework.Database.Entities.MediaBuyer = Nothing

            MediaManagerReviewDetail = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            If e.Row.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.BuyerEmployeeCode.ToString AndAlso
                    Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BuyerEmployeeCode) Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaBuyer = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaBuyer).Where(Function(MB) MB.EmployeeCode = MediaManagerReviewDetail.BuyerEmployeeCode).FirstOrDefault

                    If MediaBuyer IsNot Nothing AndAlso MediaBuyer.Employee IsNot Nothing Then

                        MediaManagerReviewDetail.Buyer = MediaBuyer.Employee.ToString

                    End If

                End Using

            End If

        End Sub
        Private Sub MediaManagerReviewDetail_ShowingEditor(e As ComponentModel.CancelEventArgs)

            'objects
            Dim FieldName As String = Nothing
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim GrossExists As Boolean = False
            Dim NetExists As Boolean = False

            MediaManagerReviewDetail = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            FieldName = PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName

            If FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdditionalChargeAmount.ToString Then

                e.Cancel = Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillingUser)

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Rate.ToString AndAlso
                    MediaManagerReviewDetail.MediaFrom = "Internet" AndAlso MediaManagerReviewDetail.InternetCostType = "NA" Then

                e.Cancel = True

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperCirculationQTY.ToString Then

                If MediaManagerReviewDetail.MediaFrom <> "Newspaper" OrElse (MediaManagerReviewDetail.MediaFrom = "Newspaper" AndAlso
                        (MediaManagerReviewDetail.NewspaperCost = "NA" OrElse MediaManagerReviewDetail.NewspaperCost = "CPI")) Then

                    e.Cancel = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperColumns.ToString OrElse
                    FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.NewspaperInches.ToString Then

                If MediaManagerReviewDetail.MediaFrom <> "Newspaper" OrElse (MediaManagerReviewDetail.MediaFrom = "Newspaper" AndAlso MediaManagerReviewDetail.NewspaperCost <> "CPI") Then

                    e.Cancel = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.JobComponentNumber.ToString AndAlso
                    Not MediaManagerReviewDetail.JobNumber.HasValue Then

                e.Cancel = True

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.RebatePercent.ToString Then

                For Each MediaManagerReviewDetail In _AutoFillItemsCopy

                    If MediaManagerReviewDetail.NetGross = "Gross" Then

                        GrossExists = True
                        Exit For

                    End If

                Next

                If Not GrossExists Then

                    e.Cancel = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.MarkupPercent.ToString Then

                For Each MediaManagerReviewDetail In _AutoFillItemsCopy

                    If MediaManagerReviewDetail.NetGross = "Net" Then

                        NetExists = True
                        Exit For

                    End If

                Next

                If Not NetExists Then

                    e.Cancel = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.Buyer.ToString Then

                If Not String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BuyerEmployeeCode) Then

                    e.Cancel = True

                End If

            ElseIf FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.InternetType.ToString AndAlso
                    MediaManagerReviewDetail.AdServerPlacementID.HasValue Then

                e.Cancel = True

            End If

        End Sub
        Private Sub MediaManagerReviewDetail_SubItemTextBoxButtonClickEvent(SelectedObject As Object)

            'objects
            Dim MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim SelectedClientPOs As IEnumerable = Nothing
            Dim ClientPO As String = Nothing
            Dim BaseRow As DevExpress.XtraVerticalGrid.Rows.BaseRow = Nothing
            Dim SelectedAdNumbers As IEnumerable = Nothing
            Dim AdNumber As String = Nothing
            Dim SelectedAdSizeCodes As IEnumerable = Nothing
            Dim AdSizeCode As String = Nothing

            MediaManagerReviewDetail = DirectCast(SelectedObject, AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            If PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)
                ParameterDictionary.Add("ClientCode", MediaManagerReviewDetail.ClientCode)
                ParameterDictionary.Add("DivisionCode", MediaManagerReviewDetail.DivisionCode)
                ParameterDictionary.Add("ProductCode", MediaManagerReviewDetail.ProductCode)

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.ClientPO, True, True, SelectedClientPOs, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                    If SelectedClientPOs IsNot Nothing Then

                        Try

                            ClientPO = (From Entity In SelectedClientPOs
                                        Select Entity.ClientPONumber).FirstOrDefault

                        Catch ex As Exception
                            ClientPO = Nothing
                        End Try

                        If ClientPO IsNot Nothing Then

                            SelectedObject.ClientPO = ClientPO

                        End If

                        Try

                            BaseRow = PropertyGridControlForm_Properties.GetRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.ClientPO.ToString)

                        Catch ex As Exception
                            BaseRow = Nothing
                        End Try

                        If BaseRow IsNot Nothing Then

                            BaseRow.Properties.Value = ClientPO

                        End If

                    End If

                End If

            ElseIf PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)
                ParameterDictionary.Add("ClientCode", MediaManagerReviewDetail.ClientCode)

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.AdNumber, True, True, SelectedAdNumbers, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                    If SelectedAdNumbers IsNot Nothing Then

                        Try

                            AdNumber = (From Entity In SelectedAdNumbers
                                        Select Entity.Number).FirstOrDefault

                        Catch ex As Exception
                            AdNumber = Nothing
                        End Try

                        If AdNumber IsNot Nothing Then

                            SelectedObject.AdNumber = AdNumber

                        End If

                        Try

                            BaseRow = PropertyGridControlForm_Properties.GetRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdNumber.ToString)

                        Catch ex As Exception
                            BaseRow = Nothing
                        End Try

                        If BaseRow IsNot Nothing Then

                            BaseRow.Properties.Value = AdNumber

                        End If

                    End If

                End If

            ElseIf PropertyGridControlForm_Properties.FocusedRow.Properties.FieldName = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString Then

                ParameterDictionary = New Generic.Dictionary(Of String, Object)
                ParameterDictionary.Add("MediaType", MediaManagerReviewDetail.MediaFrom.Substring(0, 1))

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.AdSizeCode, True, True, SelectedAdSizeCodes, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                    If SelectedAdSizeCodes IsNot Nothing Then

                        Try

                            AdSizeCode = (From Entity In SelectedAdSizeCodes
                                          Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            AdSizeCode = Nothing
                        End Try

                        If AdSizeCode IsNot Nothing Then

                            SelectedObject.AdSizeCode = AdSizeCode

                        End If

                        Try

                            BaseRow = PropertyGridControlForm_Properties.GetRowByFieldName(AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.Properties.AdSizeCode.ToString)

                        Catch ex As Exception
                            BaseRow = Nothing
                        End Try

                        If BaseRow IsNot Nothing Then

                            BaseRow.Properties.Value = AdSizeCode

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#Region " VCC Order "

        Private Sub VCCOrder_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder = Nothing

            VCCOrder = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.MediaManager.Classes.VCCOrder)

            If FieldName = AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.CardStatus.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.MediaManager.GetCardStatusDatasource()

                End Using

            End If

        End Sub

#End Region

#Region " MediaRFPAvailLine "

        Private Sub MediaRFPAvailLine_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim MediaRFPAvailLine As AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine = Nothing
            Dim MediaRequestForProposalController As AdvantageFramework.Controller.Media.MediaRequestForProposalController = Nothing
            Dim MediaTypeCode As String = Nothing

            MediaRFPAvailLine = DirectCast(PropertyGridControlForm_Properties.SelectedObject, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

            MediaTypeCode = DirectCast(_AutoFillItemsCopy.FirstOrDefault, AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine).MediaTypeCode

            If FieldName = AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine.Properties.DaypartID.ToString Then

                OverrideDefaultDatasource = True

                MediaRequestForProposalController = New AdvantageFramework.Controller.Media.MediaRequestForProposalController(Me.Session)

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = MediaRequestForProposalController.GetDaypartRepositoryByMediaTypeCode(DbContext, MediaTypeCode)

                End Using

            End If

        End Sub
        Private Sub PropertyGridControlForm_Properties_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles PropertyGridControlForm_Properties.ValidatingEditor

            If TypeOf PropertyGridControlForm_Properties.SelectedObject Is AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification Then

                If Not _AutoFillItemsCopy.OfType(Of AdvantageFramework.MediaManager.Classes.BroadcastOrderVerification).Where(Function(Entity) Entity.OrderLineNumber = e.Value).Any Then

                    e.Valid = False
                    e.ErrorText = "Invalid Line Number"

                Else

                    e.Valid = True
                    e.ErrorText = ""

                End If

            End If

        End Sub

#End Region

#Region " AccountReceivableInvoice "

        Private Sub AccountReceivableInvoice_QueryPopupNeedDatasource(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object)

            'objects
            Dim ClientCode As String = Nothing

            ClientCode = DirectCast(_AutoFillItems(0), AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ClientCode

            If FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Datasource = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, ClientCode).ToList

                End Using

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace