Namespace Employee.Presentation

    Public Class TimesheetDetailsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Integer = Nothing
        Private _FunctionCode As String = Nothing
        Private _EmployeeCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Public ReadOnly Property JobComponentNumber As Integer
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Public ReadOnly Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal FunctionCode As String, ByVal EmployeeCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _FunctionCode = FunctionCode
            _EmployeeCode = EmployeeCode

            ClearPlaceholderText()

        End Sub
        Private Sub ClearPlaceholderText()

            LabelQuoteVsActual_Client.Text = ""
            LabelQuoteVsActual_Job.Text = ""
            LabelQuoteVsActual_Component.Text = ""
            LabelQuoteVsActual_Estimate.Text = ""
            LabelQuoteVsActual_Quote.Text = ""
            LabelQuoteVsActual_Revision.Text = ""
            LabelQuoteVsActual_Function.Text = ""
            LabelQuoteVsActual_HoursQuoted.Text = ""
            LabelQuoteVsActual_HoursPosted.Text = ""
            LabelQuoteVsActual_HoursRemaining.Text = ""
            LabelQuoteVsActual_AmountQuoted.Text = ""
            LabelQuoteVsActual_AmountPosted.Text = ""
            LabelQuoteVsActual_AmountRemaining.Text = ""

            LabelTrafficHours_Client.Text = ""
            LabelTrafficHours_Job.Text = ""
            LabelTrafficHours_Component.Text = ""
            LabelTrafficHours_Function.Text = ""
            LabelTrafficHours_HoursPosted.Text = ""
            LabelTrafficHours_HoursRemaining.Text = ""
            LabelTrafficHours_HoursAllowed.Text = ""

        End Sub
        Private Sub LoadDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is Nothing Then

                For Each TabItem In TabControlForm_Details.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                TabItem = TabControlForm_Details.SelectedTab

            End If

            If TabItem.Tag = False Then

                If TabItem Is TabItemDetails_QuoteVsActualTab Then

                    LoadQuoteVsActual()

                ElseIf TabItem Is TabItemDetails_TrafficHoursTab Then

                    LoadTrafficHours()

                End If

            End If

        End Sub
        Private Sub LoadQuoteVsActual()

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim EstimateComponent As Short = Nothing
            Dim TimesheetEstimateList As Generic.List(Of AdvantageFramework.Database.Classes.TimesheetEstimate)
            Dim HoursQuoted As Decimal = Nothing
            Dim AmountQuoted As Decimal = Nothing
            Dim AmountPosted As Decimal = Nothing
            Dim HoursPosted As Decimal = Nothing

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _JobNumber)
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)
                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Job.ClientCode)
                    [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, _FunctionCode)

                    LabelQuoteVsActual_Client.Text = Client.Code & " - " & Client.Name
                    LabelQuoteVsActual_Job.Text = Job.Number & " - " & Job.Description
                    LabelQuoteVsActual_Component.Text = JobComponent.Number & " - " & JobComponent.Description
                    LabelQuoteVsActual_Function.Text = [Function].Code & " - " & [Function].Description

                    Try

                        TimesheetEstimateList = AdvantageFramework.Database.Procedures.TimesheetEstimate.Load(DbContext, _JobNumber, _JobComponentNumber, _FunctionCode, _EmployeeCode, CheckBoxQuoteVsActual_EmployeeOnly.Checked).ToList

                    Catch ex As Exception
                        TimesheetEstimateList = Nothing
                    End Try

                    If TimesheetEstimateList IsNot Nothing Then

                        For Each TimesheetEstimate In TimesheetEstimateList

                            HoursQuoted = HoursQuoted + TimesheetEstimate.TotalEstimateQuantity
                            AmountQuoted += TimesheetEstimate.EstimateAmount.GetValueOrDefault(0) + TimesheetEstimate.Contingency.GetValueOrDefault(0)

                            EstimateComponent = TimesheetEstimate.EstimateComponentNumber

                            LabelQuoteVsActual_Estimate.Text = TimesheetEstimate.EstimateNumber
                            LabelQuoteVsActual_Quote.Text = TimesheetEstimate.EstimateQuoteNumber
                            LabelQuoteVsActual_Revision.Text = TimesheetEstimate.EstimateRevisionNumber

                        Next

                    End If

                    DataGridViewQuoteVsActual_ActualHours.DataSource = AdvantageFramework.Database.Procedures.TimesheetQuoteVsActual.Load(DbContext, _JobNumber, _JobComponentNumber, _FunctionCode, _EmployeeCode, CheckBoxQuoteVsActual_EmployeeOnly.Checked, 0).ToList
                    DataGridViewQuoteVsActual_ActualHours.CurrentView.BestFitColumns()

                    Try

                        HoursPosted = (From Entity In DataGridViewQuoteVsActual_ActualHours.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TimesheetQuoteVsActual)()
                                       Select Entity.TotalEmployeeHours.GetValueOrDefault(0)).Sum

                    Catch ex As Exception
                        HoursPosted = Nothing
                    End Try

                    LabelQuoteVsActual_HoursQuoted.Text = HoursQuoted.ToString
                    LabelQuoteVsActual_HoursPosted.Text = HoursPosted.ToString
                    LabelQuoteVsActual_HoursRemaining.Text = (HoursQuoted - HoursPosted).ToString

                    Try

                        AmountPosted = (From Entity In DataGridViewQuoteVsActual_ActualHours.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TimesheetQuoteVsActual)()
                                        Select Entity.Amount.GetValueOrDefault(0)).Sum

                    Catch ex As Exception
                        AmountPosted = Nothing
                    End Try

                    LabelQuoteVsActual_AmountQuoted.Text = AmountQuoted.ToString
                    LabelQuoteVsActual_AmountPosted.Text = AmountPosted.ToString
                    LabelQuoteVsActual_AmountRemaining.Text = (AmountQuoted - AmountPosted).ToString

                    If CDec(LabelQuoteVsActual_AmountRemaining.Text) < 0 Then

                        LabelQuoteVsActual_AmountRemaining.ForeColor = Drawing.Color.Red

                    Else

                        LabelQuoteVsActual_AmountRemaining.ForeColor = (New AdvantageFramework.WinForm.Presentation.Controls.Label).ForeColor

                    End If

                    If CDec(LabelQuoteVsActual_HoursRemaining.Text) < 0 Then

                        LabelQuoteVsActual_HoursRemaining.ForeColor = Drawing.Color.Red

                    Else

                        LabelQuoteVsActual_HoursRemaining.ForeColor = (New AdvantageFramework.WinForm.Presentation.Controls.Label).ForeColor

                    End If

                End Using

                TabItemDetails_QuoteVsActualTab.Tag = True

            End If

        End Sub
        Private Sub LoadTrafficHours()

            'objects
            Dim TimesheetTrafficHours As Generic.List(Of AdvantageFramework.Database.Classes.TimesheetTrafficHour) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim Hours As Decimal = Nothing
            Dim HoursPosted As Decimal = Nothing
            Dim HoursAllowed As Decimal = Nothing

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        TimesheetTrafficHours = AdvantageFramework.Database.Procedures.TimesheetTrafficHour.Load(DbContext, _JobNumber, _JobComponentNumber, _FunctionCode, _EmployeeCode, CheckBoxQuoteVsActual_EmployeeOnly.Checked).ToList

                    Catch ex As Exception
                        TimesheetTrafficHours = Nothing
                    End Try

                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, _JobNumber)
                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber)
                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Job.ClientCode)
                    [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, _FunctionCode)

                    LabelTrafficHours_Client.Text = Client.Code & " - " & Client.Name
                    LabelTrafficHours_Job.Text = Job.Number & " - " & Job.Description
                    LabelTrafficHours_Component.Text = JobComponent.Number & " - " & JobComponent.Description
                    LabelTrafficHours_Function.Text = [Function].Code & " - " & [Function].Description

                    DataGridViewTrafficHours_ActualHours.DataSource = AdvantageFramework.Database.Procedures.TimesheetQuoteVsActual.Load(DbContext, _JobNumber, _JobComponentNumber, _FunctionCode, _EmployeeCode, CheckBoxQuoteVsActual_EmployeeOnly.Checked, 1).ToList
                    DataGridViewTrafficHours_ActualHours.CurrentView.BestFitColumns()

                    If TimesheetTrafficHours IsNot Nothing AndAlso TimesheetTrafficHours.Count > 0 Then

                        DataGridViewTrafficHours_TrafficHours.Visible = True
                        LabelTrafficHours_NoTrafficHours.Visible = False
                        DataGridViewTrafficHours_TrafficHours.DataSource = TimesheetTrafficHours
                        DataGridViewTrafficHours_TrafficHours.CurrentView.BestFitColumns()
                        HoursAllowed = (From Entity In TimesheetTrafficHours
                                        Select Entity.TotalJobHours.GetValueOrDefault(0)).Sum

                    Else

                        DataGridViewTrafficHours_TrafficHours.Visible = False
                        LabelTrafficHours_NoTrafficHours.Visible = True
                        DataGridViewTrafficHours_TrafficHours.DataSource = Nothing
                        DataGridViewTrafficHours_TrafficHours.CurrentView.BestFitColumns()

                    End If

                    Try

                        HoursPosted = (From Entity In DataGridViewTrafficHours_ActualHours.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.TimesheetQuoteVsActual)()
                                       Select Entity.TotalEmployeeHours.GetValueOrDefault(0)).Sum

                    Catch ex As Exception
                        HoursPosted = Nothing
                    End Try

                    LabelTrafficHours_HoursAllowed.Text = HoursAllowed.ToString
                    LabelTrafficHours_HoursPosted.Text = HoursPosted.ToString
                    LabelTrafficHours_HoursRemaining.Text = (HoursAllowed - HoursPosted).ToString

                    If CDec(LabelTrafficHours_HoursRemaining.Text) >= 0 Then

                        LabelTrafficHours_HoursRemaining.ForeColor = (New AdvantageFramework.WinForm.Presentation.Controls.Label).ForeColor

                    Else

                        LabelTrafficHours_HoursRemaining.ForeColor = Drawing.Color.Red

                    End If

                End Using

                TabItemDetails_TrafficHoursTab.Tag = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal FunctionCode As String, ByVal EmployeeCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim TimesheetDetailsDialog As AdvantageFramework.Employee.Presentation.TimesheetDetailsDialog = Nothing

            TimesheetDetailsDialog = New AdvantageFramework.Employee.Presentation.TimesheetDetailsDialog(JobNumber, JobComponentNumber, FunctionCode, EmployeeCode)

            ShowFormDialog = TimesheetDetailsDialog.ShowDialog()

            JobNumber = TimesheetDetailsDialog.JobNumber
            JobComponentNumber = TimesheetDetailsDialog.JobComponentNumber
            FunctionCode = TimesheetDetailsDialog.FunctionCode
            EmployeeCode = TimesheetDetailsDialog.EmployeeCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub TimesheetDetailsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim EmployeeTimeIDs As Integer() = Nothing
            Dim QvAAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim TrafficAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim EmpOnlyAppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Me.ByPassUserEntryChanged = True
                CheckBoxQuoteVsActual_EmployeeOnly.ByPassUserEntryChanged = True

                LabelQuoteVsActual_HoursRemaining.TextAlignment = Drawing.StringAlignment.Far
                LabelQuoteVsActual_HoursPosted.TextAlignment = Drawing.StringAlignment.Far
                LabelQuoteVsActual_HoursQuoted.TextAlignment = Drawing.StringAlignment.Far

                LabelQuoteVsActual_AmountPosted.TextAlignment = Drawing.StringAlignment.Far
                LabelQuoteVsActual_AmountQuoted.TextAlignment = Drawing.StringAlignment.Far
                LabelQuoteVsActual_AmountRemaining.TextAlignment = Drawing.StringAlignment.Far

                LabelTrafficHours_HoursAllowed.TextAlignment = Drawing.StringAlignment.Far
                LabelTrafficHours_HoursPosted.TextAlignment = Drawing.StringAlignment.Far
                LabelTrafficHours_HoursRemaining.TextAlignment = Drawing.StringAlignment.Far

                Try

                    EmployeeTimeIDs = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                                       Where Entity.EmployeeCode = _EmployeeCode
                                       Select Entity.ID).ToArray

                Catch ex As Exception
                    EmployeeTimeIDs = Nothing
                End Try

                If EmployeeTimeIDs IsNot Nothing AndAlso EmployeeTimeIDs.Count > 0 Then

                    If (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext)
                        Where EmployeeTimeIDs.Contains(Entity.EmployeeTimeID) AndAlso
                              Entity.JobNumber = _JobNumber AndAlso
                              Entity.JobComponentNumber = _JobComponentNumber AndAlso
                              Entity.FunctionCode = _FunctionCode
                        Select Entity).Any = True Then

                        For Each AppVar In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "TimesheetQVA").ToList

                            If AppVar.Name = "EmpOnly" Then

                                EmpOnlyAppVar = AppVar

                            End If

                            If AppVar.Name = "TrafficHours" Then

                                TrafficAppVar = AppVar

                            End If

                            If AppVar.Name = "QVA" Then

                                QvAAppVar = AppVar

                            End If

                            If EmpOnlyAppVar IsNot Nothing AndAlso TrafficAppVar IsNot Nothing AndAlso QvAAppVar IsNot Nothing Then

                                Exit For

                            End If

                        Next

                        If QvAAppVar IsNot Nothing AndAlso QvAAppVar.Value = "True" Then

                            TabControlForm_Details.SelectedTab = TabItemDetails_QuoteVsActualTab

                        ElseIf TrafficAppVar IsNot Nothing AndAlso TrafficAppVar.Value = "True" Then

                            TabControlForm_Details.SelectedTab = TabItemDetails_TrafficHoursTab

                        End If

                        If EmpOnlyAppVar IsNot Nothing Then

                            If EmpOnlyAppVar.Value = "True" Then

                                CheckBoxQuoteVsActual_EmployeeOnly.Checked = True

                            End If

                        End If

                        LoadDetails(Nothing)

                    Else

                        Loaded = False

                    End If

                Else

                    Loaded = False

                End If

            End Using

            Me.FormAction = WinForm.Presentation.FormActions.None

            If Loaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("There was a problem loading details for the selected record.")

                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim VariableNames As String() = Nothing
            Dim VariableValue As String = Nothing

            VariableNames = {"QVA", "TrafficHours", "EmpOnly"}

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each VariableName In VariableNames

                    Select Case VariableName

                        Case "QVA"

                            VariableValue = (TabControlForm_Details.SelectedTab Is TabItemDetails_QuoteVsActualTab).ToString

                        Case "TrafficHours"

                            VariableValue = (TabControlForm_Details.SelectedTab Is TabItemDetails_TrafficHoursTab).ToString

                        Case "EmpOnly"

                            VariableValue = CheckBoxQuoteVsActual_EmployeeOnly.Checked.ToString

                    End Select

                    Try

                        AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "TimesheetQVA")
                                  Where Entity.Name = VariableName
                                  Select Entity).SingleOrDefault

                    Catch ex As Exception
                        AppVar = Nothing
                    End Try

                    If AppVar Is Nothing Then

                        AppVar = New AdvantageFramework.Database.Entities.AppVars
                        AppVar.UserCode = Me.Session.UserCode
                        AppVar.Application = "TimesheetQVA"
                        AppVar.Group = 0
                        AppVar.Name = VariableName
                        AppVar.Value = VariableValue

                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    Else

                        AppVar.Value = VariableValue
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    End If

                Next

            End Using

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

        Private Sub TabControlForm_Details_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Details.SelectedTabChanging

            If Me.FormShown = True Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    LoadDetails(e.NewTab)

                End If

            End If

        End Sub
        Private Sub CheckBoxQuoteVsActual_EmployeeOnly_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxQuoteVsActual_EmployeeOnly.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                LoadQuoteVsActual()

            End If

        End Sub
        Private Sub DataGridViewQuoteVsActual_ActualHours_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewQuoteVsActual_ActualHours.DataSourceChangedEvent

            DataGridViewQuoteVsActual_ActualHours.OptionsView.ShowViewCaption = False
            DataGridViewQuoteVsActual_ActualHours.OptionsView.ShowFooter = True

            If DataGridViewQuoteVsActual_ActualHours.Columns.Count > 0 Then

                If DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString) IsNot Nothing Then

                    DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString).SummaryItem.DisplayFormat = "{0:N2}"

                End If

                If DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString) IsNot Nothing Then

                    DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewQuoteVsActual_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString).SummaryItem.DisplayFormat = "{0:N2}"

                End If

            End If

        End Sub
        Private Sub DataGridViewTrafficHours_ActualHours_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTrafficHours_ActualHours.DataSourceChangedEvent

            DataGridViewTrafficHours_ActualHours.OptionsView.ShowViewCaption = False
            DataGridViewTrafficHours_ActualHours.OptionsView.ShowFooter = True

            If DataGridViewTrafficHours_ActualHours.Columns.Count > 0 Then

                If DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString) IsNot Nothing Then

                    DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.TotalEmployeeHours.ToString).SummaryItem.DisplayFormat = "{0:N2}"

                End If

                If DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString) IsNot Nothing Then

                    DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewTrafficHours_ActualHours.Columns(AdvantageFramework.Database.Classes.TimesheetQuoteVsActual.Properties.Amount.ToString).SummaryItem.DisplayFormat = "{0:N2}"

                End If

            End If

        End Sub
        Private Sub DataGridViewTrafficHours_TrafficHours_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewTrafficHours_TrafficHours.DataSourceChangedEvent

            DataGridViewTrafficHours_TrafficHours.OptionsView.ShowViewCaption = False
            DataGridViewTrafficHours_TrafficHours.OptionsView.ShowFooter = True

            If DataGridViewTrafficHours_TrafficHours.Columns.Count > 0 Then

                If DataGridViewTrafficHours_TrafficHours.Columns(AdvantageFramework.Database.Classes.TimesheetTrafficHour.Properties.TotalJobHours.ToString) IsNot Nothing Then

                    DataGridViewTrafficHours_TrafficHours.Columns(AdvantageFramework.Database.Classes.TimesheetTrafficHour.Properties.TotalJobHours.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridViewTrafficHours_TrafficHours.Columns(AdvantageFramework.Database.Classes.TimesheetTrafficHour.Properties.TotalJobHours.ToString).SummaryItem.DisplayFormat = "{0:N2}"

                End If

            End If

        End Sub

    End Class

End Namespace