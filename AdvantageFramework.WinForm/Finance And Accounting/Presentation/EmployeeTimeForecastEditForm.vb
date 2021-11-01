Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastEditForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeTimeForecastOfficeDetailID As Integer = 0
        Private _SettingsList As Generic.List(Of AdvantageFramework.Database.Entities.Setting) = Nothing
        Private _EmployeeStandardHoursDetailList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeStandardHoursDetail) = Nothing
        Private _LoadingETFInformation As Boolean = False
        Private _ETFApproved As Boolean = False
        Private _ETFOfficeEmployeeCodes As Generic.List(Of String) = Nothing
        Private _ETFNonOfficeEmployeeCodes As Generic.List(Of String) = Nothing
        Private _ETFOfficeAlternateEmployeeIDs As Generic.List(Of String) = Nothing
        Private _ETFNonOfficeAlternateEmployeeIDs As Generic.List(Of String) = Nothing
        Private _ExpandedTreeListNodesList As Generic.List(Of DevExpress.XtraTreeList.Nodes.TreeListNode) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeTimeForecastOfficeDetailID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _EmployeeTimeForecastOfficeDetailID = EmployeeTimeForecastOfficeDetailID

        End Sub
        Private Function LoadEmployeeTimeForecastOfficeDetail() As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecast").
                                                                                                                                                                    Include("EmployeeTimeForecast.PostPeriod").
                                                                                                                                                                    Include("Office").
                                                                                                                                                                    Include("AssignedToEmployee").
                                                                                                                                                                    Include("ApprovedByEmployee").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailAlternateEmployees.EmployeeTitle").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailEmployees.Employee").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailIndirectCategories").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponents").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees").
                                                                                                                                                                    Include("EmployeeTimeForecastOfficeDetailJobComponentEmployees")
                                                        Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                        Select Entity).SingleOrDefault

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End Using

            LoadEmployeeTimeForecastOfficeDetail = EmployeeTimeForecastOfficeDetail

        End Function
        Private Sub LoadEmployeeTimeForecastsInformation(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            'objects
            Dim EmployeeTimeForecastOfficeDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) = Nothing

            _LoadingETFInformation = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If EmployeeTimeForecastOfficeDetail Is Nothing Then

                    EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                End If

                Me.Text = "ETF - " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description

                ButtonItemActions_Save.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_JobComponents.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_Employees.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_AlternateEmployees.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_IndirectCategories.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_Approve.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_Unapprove.Visible = EmployeeTimeForecastOfficeDetail.IsApproved
                ButtonItemActions_Delete.Visible = Not EmployeeTimeForecastOfficeDetail.IsApproved

                _ETFApproved = EmployeeTimeForecastOfficeDetail.IsApproved

                EmployeeTimeForecastOfficeDetailsList = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode).ToList

                ComboBoxForm_RevisionNumber.DataSource = EmployeeTimeForecastOfficeDetailsList

                ComboBoxForm_RevisionNumber.SelectedValue = EmployeeTimeForecastOfficeDetail.ID

                If EmployeeTimeForecastOfficeDetailsList.Count = 1 Then

                    ButtonItemActions_Delete.Text = "Delete"

                Else

                    ButtonItemActions_Delete.Text = "Delete " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Revision"

                End If

                TextBoxForm_Description.Enabled = Not EmployeeTimeForecastOfficeDetail.IsApproved
                TextBoxForm_Comment.Enabled = Not EmployeeTimeForecastOfficeDetail.IsApproved

                LabelForm_PostPeriod.Text = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Code & " - " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Description
                LabelForm_AssignedEmployee.Text = EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString
                LabelForm_Office.Text = EmployeeTimeForecastOfficeDetail.Office.Name
                TextBoxForm_Description.Text = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description
                TextBoxForm_Comment.Text = EmployeeTimeForecastOfficeDetail.Comment

                LabelForm_CreatedBy.Text = ""

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If EmployeeTimeForecastOfficeDetail.CreatedByUserCode <> "" Then

                        LabelForm_CreatedBy.Text = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, EmployeeTimeForecastOfficeDetail.CreatedByUserCode).Employee.ToString & " on " & EmployeeTimeForecastOfficeDetail.CreatedDate

                    End If

                    LabelForm_ModifiedBy.Text = ""

                    If EmployeeTimeForecastOfficeDetail.ModifiedByUserCode IsNot Nothing Then

                        LabelForm_ModifiedBy.Text = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, EmployeeTimeForecastOfficeDetail.ModifiedByUserCode).Employee.ToString & " on " & EmployeeTimeForecastOfficeDetail.ModifiedDate

                    End If

                End Using

                LabelForm_ApprovedBy.Text = ""

                If EmployeeTimeForecastOfficeDetail.ApprovedByEmployee IsNot Nothing Then

                    LabelForm_ApprovedBy.Text = EmployeeTimeForecastOfficeDetail.ApprovedByEmployee.ToString() & " on " & EmployeeTimeForecastOfficeDetail.ApprovedDate

                End If

                If Me.FormShown Then

                    RibbonBarOptions_Actions.ResetCachedContentSize()

                    RibbonBarOptions_Actions.Refresh()

                    RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

                    RibbonBarOptions_Actions.Refresh()

                    If Me.MdiParent IsNot Nothing Then

                        Me.MdiParent.Refresh()

                    End If

                    Me.Refresh()

                End If

            End Using

            Me.ClearChanged()

            _LoadingETFInformation = False

        End Sub
        Private Sub LoadEmployeeTimeForecastsTreeListData(ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If EmployeeTimeForecastOfficeDetail Is Nothing Then

                        EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                    End If

                    If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        If _ExpandedTreeListNodesList Is Nothing Then

                            _ExpandedTreeListNodesList = New Generic.List(Of DevExpress.XtraTreeList.Nodes.TreeListNode)

                        End If

                        For Each TreeListNode In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)().ToList

                            GetAllExpandedNodes(TreeListNode)

                        Next

                        _ETFOfficeEmployeeCodes = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.EmployeeCode).ToList
                        _ETFNonOfficeEmployeeCodes = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.EmployeeCode).ToList
                        _ETFOfficeAlternateEmployeeIDs = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.ID.ToString).ToList
                        _ETFNonOfficeAlternateEmployeeIDs = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).Select(Function(Entity) Entity.ID.ToString).ToList

                        DataTable = AdvantageFramework.EmployeeTimeForecast.BuildEmployeeTimeForecastOfficeDetailsDataTable(DbContext, DataContext, _EmployeeTimeForecastOfficeDetailID)

                        For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow).ToList

                            If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "" Then

                                DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = "****"

                            End If

                            If DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).ToString.Contains("$") Then

                                DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString) = DataRow(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString).ToString.Replace("$", "")

                            End If

                            For Each EmployeeCode In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Select(Function(OfficeDetailEmployee) OfficeDetailEmployee.EmployeeCode).ToList

                                If DataRow(EmployeeCode).ToString.Contains("$") Then

                                    DataRow(EmployeeCode) = DataRow(EmployeeCode).ToString.Replace("$", "")

                                End If

                            Next

                            For Each EmployeeTimeForecastOfficeDetailAlternateEmployeeID In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Select(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.ID).ToList

                                If DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString).ToString.Contains("$") Then

                                    DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString) = DataRow(EmployeeTimeForecastOfficeDetailAlternateEmployeeID.ToString).ToString.Replace("$", "")

                                End If

                            Next

                        Next

                        For Each DataColumn In DataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                            If DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString OrElse
                                    DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString OrElse
                                    DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString OrElse
                                    DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ClientName.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.DivisionName.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ProductDescription.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString Then

                                DataColumn.ReadOnly = True

                            ElseIf DataColumn.ColumnName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString Then

                                DataColumn.ReadOnly = True

                            End If

                        Next

                        TreeListForm_ETF.DataSource = Nothing

                        TreeListForm_ETF.Columns.Clear()
                        TreeListForm_ETF.Nodes.Clear()

                        TreeListForm_ETF.RootValue = "****"

                        TreeListForm_ETF.DataSource = DataTable

                        TreeListForm_ETF.BestFitColumns(False)

                        For Each TreeListColumn In TreeListForm_ETF.Columns.OfType(Of DevExpress.XtraTreeList.Columns.TreeListColumn)().ToList

                            TreeListColumn.OptionsColumn.AllowMove = False
                            TreeListColumn.OptionsColumn.AllowMoveToCustomizationForm = False
                            TreeListColumn.OptionsColumn.AllowSort = False
                            TreeListColumn.OptionsColumn.ShowInCustomizationForm = False

                            If TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString OrElse
                                    TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString OrElse
                                    TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString OrElse
                                    TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString Then

                                TreeListColumn.Visible = False
                                TreeListColumn.OptionsColumn.ReadOnly = True

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString Then

                                TreeListColumn.Caption = "Office"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.Width = 200

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ClientName.ToString Then

                                TreeListColumn.Caption = "Client"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.Width = 100

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.DivisionName.ToString Then

                                TreeListColumn.Caption = "Division"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.Width = 100

                                If AdvantageFramework.EmployeeTimeForecast.LoadHideDivisionColumnSetting(DataContext, _SettingsList) Then

                                    TreeListColumn.Visible = False

                                End If

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ProductDescription.ToString Then

                                TreeListColumn.Caption = "Product"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.Width = 100

                                If AdvantageFramework.EmployeeTimeForecast.LoadHideProductColumnSetting(DataContext, _SettingsList) Then

                                    TreeListColumn.Visible = False

                                End If

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString Then

                                TreeListColumn.Caption = "Job/Component"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.Width = 200

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString Then

                                TreeListColumn.Caption = "Revenue"
                                TreeListColumn.OptionsColumn.AllowEdit = True
                                TreeListColumn.OptionsColumn.ReadOnly = False
                                TreeListColumn.Width = 100

                                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                                SubItemNumericInput.ControlType = WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency

                                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                                SubItemNumericInput.SetFormatString("c2")

                                TreeListForm_ETF.RepositoryItems.Add(SubItemNumericInput)

                                TreeListColumn.ColumnEdit = SubItemNumericInput

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString Then

                                TreeListColumn.Caption = "Revenue Share"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                                TreeListColumn.Width = 100

                                If AdvantageFramework.EmployeeTimeForecast.LoadHideRevenueShareInformationSetting(DataContext, _SettingsList) Then

                                    TreeListColumn.Visible = False

                                Else

                                    TreeListColumn.Visible = True

                                End If

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString Then

                                TreeListColumn.Caption = "w/ Revenue Share"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                                TreeListColumn.Width = 100

                                If AdvantageFramework.EmployeeTimeForecast.LoadHideRevenueShareInformationSetting(DataContext, _SettingsList) Then

                                    TreeListColumn.Visible = False

                                Else

                                    TreeListColumn.Visible = True

                                End If

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString Then

                                TreeListColumn.Caption = "Utilization"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                                TreeListColumn.Width = 100

                            ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString Then

                                TreeListColumn.AppearanceCell.BackColor = Drawing.Color.DarkGray
                                TreeListColumn.Caption = "Total Hours"
                                TreeListColumn.OptionsColumn.ReadOnly = True
                                TreeListColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                                TreeListColumn.Width = 100

                            End If

                        Next

                        For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).
                                                                                                                                                                                                OrderBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.FirstName).
                                                                                                                                                                                                ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.MiddleInitial).
                                                                                                                                                                                                ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.LastName).ToList

                            If TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) IsNot Nothing Then

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).AppearanceCell.BackColor = Drawing.Color.LightYellow
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Caption = EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).OptionsColumn.ReadOnly = False
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).OptionsColumn.AllowEdit = True
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Width = 100

                                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                                SubItemNumericInput.ControlType = WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal

                                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                                SubItemNumericInput.SetFormatString("n2")

                                SubItemNumericInput.MaxValue = 999.99
                                SubItemNumericInput.MinValue = 0

                                TreeListForm_ETF.RepositoryItems.Add(SubItemNumericInput)

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).ColumnEdit = SubItemNumericInput

                            End If

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode).ToList

                            If TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) IsNot Nothing Then

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).AppearanceCell.BackColor = Drawing.Color.LightYellow
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Caption = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).OptionsColumn.ReadOnly = False
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).OptionsColumn.AllowEdit = True
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Width = 100

                                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                                SubItemNumericInput.ControlType = WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal

                                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                                SubItemNumericInput.SetFormatString("n2")

                                SubItemNumericInput.MaxValue = 999.99
                                SubItemNumericInput.MinValue = 0

                                TreeListForm_ETF.RepositoryItems.Add(SubItemNumericInput)

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).ColumnEdit = SubItemNumericInput

                            End If

                        Next

                        For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees.Where(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).
                                                                                                                                                                                                OrderBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.FirstName).
                                                                                                                                                                                                ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.MiddleInitial).
                                                                                                                                                                                                ThenBy(Function(OfficeDetailEmployee) OfficeDetailEmployee.Employee.LastName).ToList

                            If TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode) IsNot Nothing Then

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).AppearanceCell.BackColor = Drawing.Color.LightBlue
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Caption = EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).OptionsColumn.ReadOnly = False
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).OptionsColumn.AllowEdit = True
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).Width = 100

                                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                                SubItemNumericInput.ControlType = WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal

                                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                                SubItemNumericInput.SetFormatString("n2")

                                SubItemNumericInput.MaxValue = 999.99
                                SubItemNumericInput.MinValue = 0

                                TreeListForm_ETF.RepositoryItems.Add(SubItemNumericInput)

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode).ColumnEdit = SubItemNumericInput

                            End If

                        Next

                        For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees.Where(Function(OfficeDetailAlternateEmployee) OfficeDetailAlternateEmployee.OfficeCode <> EmployeeTimeForecastOfficeDetail.OfficeCode).ToList

                            If TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString) IsNot Nothing Then

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).AppearanceCell.BackColor = Drawing.Color.LightBlue
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Caption = EmployeeTimeForecastOfficeDetailAlternateEmployee.ToString
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).OptionsColumn.ReadOnly = False
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).OptionsColumn.AllowEdit = True
                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).Width = 100

                                SubItemNumericInput = New AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput

                                SubItemNumericInput.ControlType = WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal

                                SubItemNumericInput.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                                SubItemNumericInput.SetFormatString("n2")

                                SubItemNumericInput.MaxValue = 999.99
                                SubItemNumericInput.MinValue = 0

                                TreeListForm_ETF.RepositoryItems.Add(SubItemNumericInput)

                                TreeListForm_ETF.Columns(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString).ColumnEdit = SubItemNumericInput

                            End If

                        Next

                        For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                            If Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                                Node.Expanded = True

                            End If

                        Next

                        For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                            CheckToExpandNode(Node)

                        Next

                        If _ExpandedTreeListNodesList.Any = False Then

                            TreeListForm_ETF.ExpandAll()

                        End If

                        _ExpandedTreeListNodesList.Clear()

                    End If

                End Using

            End Using

            Me.ClearChanged()

        End Sub
        Private Sub GetAllExpandedNodes(ByVal TreeListNode As DevExpress.XtraTreeList.Nodes.TreeListNode)

            If TreeListNode.Expanded Then

                _ExpandedTreeListNodesList.Add(TreeListNode)

            End If

            If TreeListNode.HasChildren Then

                For Each SubTreeListNode In TreeListNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode)().ToList

                    GetAllExpandedNodes(SubTreeListNode)

                Next

            End If

        End Sub
        Private Sub CheckToExpandNode(ByVal Node As DevExpress.XtraTreeList.Nodes.TreeListNode)

            For Each TreeListNode In _ExpandedTreeListNodesList

                If Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) = TreeListNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString) AndAlso
                        Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = TreeListNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) Then

                    Node.Expanded = True
                    Exit For

                End If

            Next

            If Node.HasChildren Then

                For Each TreeListNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                    CheckToExpandNode(TreeListNode)

                Next

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal EmployeeTimeForecastOfficeDetailID As Integer)

            'objects
            Dim EmployeeTimeForecastEditForm As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEditForm = Nothing

            EmployeeTimeForecastEditForm = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEditForm(EmployeeTimeForecastOfficeDetailID)

            EmployeeTimeForecastEditForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastEditForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            ButtonItemActions_Save.Image = My.Resources.SaveImage
            ButtonItemActions_JobComponents.Image = My.Resources.JobComponentAddImage
            ButtonItemActions_Employees.Image = My.Resources.EmployeesImage
            ButtonItemActions_AlternateEmployees.Image = My.Resources.AlternateEmployeesImage
            ButtonItemActions_IndirectCategories.Image = My.Resources.IndirectCategoryImage
            ButtonItemActions_CreateRevision.Image = My.Resources.RevisionImage
            ButtonItemActions_Delete.Image = My.Resources.DeleteImage
            ButtonItemActions_Approve.Image = My.Resources.ApproveImage
            ButtonItemActions_Unapprove.Image = My.Resources.UnapproveImage

            ButtonItemPrint_Export.Image = My.Resources.DatabaseExportImage

            TreeListForm_ETF.OptionsBehavior.EnableFiltering = False
            TreeListForm_ETF.OptionsMenu.EnableColumnMenu = False
            TreeListForm_ETF.OptionsMenu.EnableFooterMenu = False
            TreeListForm_ETF.AllowDrop = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description)

                _EmployeeStandardHoursDetailList = AdvantageFramework.Database.Procedures.EmployeeStandardHoursDetail.LoadByUserCode(DbContext, DbContext.UserCode).ToList

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(DataContext)

            End Using

            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                LoadEmployeeTimeForecastsTreeListData(EmployeeTimeForecastOfficeDetail)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Employee Time Forecast you are trying to access is not valid.")
                Me.Close()

            End If

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub EmployeeTimeForecastEditForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub EmployeeTimeForecastEditForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_RevisionNumber_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_RevisionNumber.SelectedValueChanged

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            If Me.FormShown AndAlso _LoadingETFInformation = False AndAlso ComboBoxForm_RevisionNumber.HasASelectedValue Then

                _EmployeeTimeForecastOfficeDetailID = ComboBoxForm_RevisionNumber.GetSelectedValue

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                LoadEmployeeTimeForecastsTreeListData(EmployeeTimeForecastOfficeDetail)

            End If

        End Sub
        Private Sub TreeListForm_ETF_BeforeCollapse(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles TreeListForm_ETF.BeforeCollapse

            If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                e.CanCollapse = False

            End If

        End Sub
        Private Sub TreeListForm_ETF_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CellValueChangedEventArgs) Handles TreeListForm_ETF.CellValueChanged

            _UserEntryChanged = True

            Me.RaiseUserEntryChangedEvent(Me)

        End Sub
        Private Sub TreeListForm_ETF_CustomDrawNodeCell(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs) Handles TreeListForm_ETF.CustomDrawNodeCell

            'objects
            Dim RevenueAmount As Decimal = 0
            Dim UtilizationAmount As Decimal = 0

            If e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString Then

                If IsNumeric(e.CellValue) Then

                    e.CellText = FormatCurrency(e.CellValue)

                End If

            End If

            If e.Node.ParentNode Is Nothing Then

                e.Appearance.BackColor = Drawing.Color.DarkGray
                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font.FontFamily.Name, e.Appearance.Font.Size, Drawing.FontStyle.Bold)

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                    e.CellText = ""

                End If

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString Then

                    If _ETFNonOfficeEmployeeCodes.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                        e.CellText = ""

                    End If

                End If

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString.StartsWith("&other") Then

                    If _ETFOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                        e.CellText = ""

                    End If

                End If

            ElseIf e.Node.ParentNode IsNot Nothing AndAlso e.Node.HasChildren Then

                e.Appearance.BackColor = Drawing.Color.LightGray
                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font.FontFamily.Name, e.Appearance.Font.Size, Drawing.FontStyle.Bold)

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString.StartsWith("&other") Then

                    If _ETFOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                        e.CellText = ""

                    End If

                End If

            ElseIf e.Node.ParentNode IsNot Nothing AndAlso e.Node.HasChildren = False Then

                If e.Node.Level = 2 Then

                    If e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString Then

                        If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString.StartsWith("&other") = False Then

                            Try

                                RevenueAmount = e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString)

                            Catch ex As Exception
                                RevenueAmount = 0
                            End Try

                            Try

                                UtilizationAmount = e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString)

                            Catch ex As Exception
                                UtilizationAmount = 0
                            End Try

                            If UtilizationAmount > RevenueAmount Then



                                e.Appearance.ForeColor = Drawing.Color.Red

                            End If

                        End If

                    End If

                    If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString.StartsWith("&other") Then

                        If _ETFOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                            e.CellText = ""

                        End If

                    End If

                Else

                    If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                        If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalRevenue.ToString Then

                            If IsNumeric(e.CellValue) Then

                                e.CellText = FormatCurrency(e.CellValue)

                            End If

                        ElseIf e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString Then

                            If IsNumeric(e.CellValue) Then

                                e.CellText = FormatCurrency(e.CellValue)

                            End If

                        ElseIf e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.TotalHours.ToString Then

                            If _ETFOfficeEmployeeCodes.Contains(e.Column.FieldName) OrElse _ETFNonOfficeEmployeeCodes.Contains(e.Column.FieldName) Then

                                If e.CellValue > AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(_EmployeeStandardHoursDetailList, e.Column.FieldName) Then

                                    e.Appearance.ForeColor = Drawing.Color.Red

                                End If

                            End If

                        End If

                    ElseIf e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString Then

                        If _ETFNonOfficeEmployeeCodes.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                            e.CellText = ""

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub TreeListForm_ETF_CustomNodeCellEditForEditing(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs) Handles TreeListForm_ETF.CustomNodeCellEditForEditing

            If e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeName.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ClientName.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.DivisionName.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ProductDescription.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.JobAndJobComponentDescription.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString Then

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString.StartsWith("&other") = False Then

                    If e.Node.Level = 2 Then

                        e.RepositoryItem.ReadOnly = _ETFApproved

                    Else

                        e.RepositoryItem.ReadOnly = True

                    End If

                Else

                    e.RepositoryItem.ReadOnly = True

                End If

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueShareAmount.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.WithRevenueShareAmount.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.UtilizationAmount.ToString Then

                e.RepositoryItem.ReadOnly = True

            ElseIf e.Column.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.TotalHours.ToString Then

                e.RepositoryItem.ReadOnly = True

            Else

                If e.Node.Level = 2 Then

                    If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString.StartsWith("&other") = False Then

                        e.RepositoryItem.ReadOnly = _ETFApproved

                    Else

                        e.RepositoryItem.ReadOnly = True

                    End If

                Else

                    If e.Node.Level = 1 Then

                        If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then

                            If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate.ToString Then

                                e.RepositoryItem.ReadOnly = _ETFApproved

                            Else

                                e.RepositoryItem.ReadOnly = True

                            End If

                        ElseIf e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.ParentOfficeCode.ToString).ToString = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString Then

                            If _ETFNonOfficeEmployeeCodes.Contains(e.Column.FieldName) OrElse _ETFNonOfficeAlternateEmployeeIDs.Contains(e.Column.FieldName) Then

                                e.RepositoryItem.ReadOnly = True

                            Else

                                e.RepositoryItem.ReadOnly = _ETFApproved

                            End If

                        Else

                            e.RepositoryItem.ReadOnly = True

                        End If

                    Else

                        e.RepositoryItem.ReadOnly = True

                    End If

                End If

            End If

        End Sub
        Private Sub TreeListForm_ETF_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles TreeListForm_ETF.FocusedNodeChanged

            If e.Node IsNot Nothing AndAlso e.Node.HasChildren Then

                TreeListForm_ETF.MoveNext()

            End If

        End Sub
        Private Sub ButtonItemETF_ExpandAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemETF_ExpandAll.Click

            TreeListForm_ETF.ExpandAll()

        End Sub
        Private Sub ButtonItemETF_CollapseAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemETF_CollapseAll.Click

            TreeListForm_ETF.CollapseAll()

        End Sub
        Private Sub ButtonItemOffice_ExpandOfficeLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOffice_ExpandOfficeLevel.Click

            For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = True

            Next

        End Sub
        Private Sub ButtonItemOffice_CollapseOfficeLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOffice_CollapseOfficeLevel.Click

            For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = False

            Next

        End Sub
        Private Sub ButtonItemClient_ExpandClientLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemClient_ExpandClientLevel.Click

            For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = True

                For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                    If SubNode.HasChildren Then

                        SubNode.Expanded = True

                    End If

                Next

            Next

        End Sub
        Private Sub ButtonItemClient_CollapseClientLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemClient_CollapseClientLevel.Click

            For Each Node In TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                    If SubNode.HasChildren Then

                        SubNode.Expanded = False

                    End If

                Next

            Next

        End Sub
        Private Sub ButtonItemActions_JobComponents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_JobComponents.Click

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastJobComponentsDialog.ShowFormDialog(_EmployeeTimeForecastOfficeDetailID) = Windows.Forms.DialogResult.OK Then

                LoadEmployeeTimeForecastsTreeListData(Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_Employees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Employees.Click

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastEmployeesDialog.ShowFormDialog(_EmployeeTimeForecastOfficeDetailID) = Windows.Forms.DialogResult.OK Then

                LoadEmployeeTimeForecastsTreeListData(Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_AlternateEmployees_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_AlternateEmployees.Click

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastAlternateEmployeesDialog.ShowFormDialog(_EmployeeTimeForecastOfficeDetailID) = Windows.Forms.DialogResult.OK Then

                LoadEmployeeTimeForecastsTreeListData(Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_IndirectCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_IndirectCategories.Click

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastIndirectCategoriesDialog.ShowFormDialog(_EmployeeTimeForecastOfficeDetailID) = Windows.Forms.DialogResult.OK Then

                LoadEmployeeTimeForecastsTreeListData(Nothing)

            End If

        End Sub
        Private Sub ButtonItemActions_Approve_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Approve.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim ApprovedEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim WarningMessage As String = ""
            Dim ApproveETF As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, _EmployeeTimeForecastOfficeDetailID)

                If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    Try

                        ApprovedEmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).ToList.Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode).ToList.Where(Function(OfficeDetail) OfficeDetail.IsApproved).SingleOrDefault

                    Catch ex As Exception
                        ApprovedEmployeeTimeForecastOfficeDetail = Nothing
                    Finally

                        If ApprovedEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                            WarningMessage = "Approval of revision (" & AdvantageFramework.StringUtilities.PadWithCharacter(ApprovedEmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True) & ") will be " &
                                                "removed and this revision (" & AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True) & ") will be approved."

                        End If

                    End Try

                    If WarningMessage <> "" Then

                        If AdvantageFramework.WinForm.MessageBox.Show(WarningMessage, WinForm.MessageBox.MessageBoxButtons.OKCancel, "Approve?") = WinForm.MessageBox.DialogResults.OK Then

                            ApproveETF = True

                        End If

                    Else

                        ApproveETF = True

                    End If

                    If ApproveETF Then

                        If ApprovedEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                            ApprovedEmployeeTimeForecastOfficeDetail.IsApproved = False
                            ApprovedEmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Nothing
                            ApprovedEmployeeTimeForecastOfficeDetail.ApprovedDate = Nothing

                            AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, ApprovedEmployeeTimeForecastOfficeDetail)

                        End If

                        EmployeeTimeForecastOfficeDetail.IsApproved = True
                        EmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Me.Session.User.EmployeeCode
                        EmployeeTimeForecastOfficeDetail.ApprovedDate = Now

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                        LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                    End If

                End If

            End Using

        End Sub
        Private Sub ButtonItemActions_CreateRevision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_CreateRevision.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            If AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastCreateRevisionDialog.ShowFormDialog(_EmployeeTimeForecastOfficeDetailID) = Windows.Forms.DialogResult.OK Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                LoadEmployeeTimeForecastsTreeListData(EmployeeTimeForecastOfficeDetail)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim OpenETFMainForm As Boolean = True

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.EmployeeTimeForecast.DeleteRevisionForEmployeeTimeForecastOfficeDetail(DbContext, EmployeeTimeForecastOfficeDetail) Then

                        Try

                            _EmployeeTimeForecastOfficeDetailID = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByPostPeriodCode(DbContext, EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriodCode).Where(Function(ETFOD) ETFOD.EmployeeTimeForecastID = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastID AndAlso ETFOD.OfficeCode = EmployeeTimeForecastOfficeDetail.OfficeCode AndAlso ETFOD.AssignedToEmployeeCode = EmployeeTimeForecastOfficeDetail.AssignedToEmployeeCode AndAlso ETFOD.ID <> _EmployeeTimeForecastOfficeDetailID).OrderByDescending(Function(Entity) Entity.ID).Select(Function(Entity) Entity.ID).FirstOrDefault()

                        Catch ex As Exception
                            _EmployeeTimeForecastOfficeDetailID = 0
                        End Try

                        If _EmployeeTimeForecastOfficeDetailID <> 0 Then

                            EmployeeTimeForecastOfficeDetail = LoadEmployeeTimeForecastOfficeDetail()

                            LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                            LoadEmployeeTimeForecastsTreeListData(EmployeeTimeForecastOfficeDetail)

                        Else

                            If TypeOf Me.MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                                For Each MDIChildForm In Me.MdiParent.MdiChildren.OfType(Of AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ToList

                                    If TypeOf MDIChildForm Is AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm Then

                                        CType(MDIChildForm, AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm).RefreshETFs()
                                        OpenETFMainForm = False
                                        Exit For

                                    End If

                                Next

                                If OpenETFMainForm Then

                                    CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast)

                                End If

                                Me.Close()

                            Else

                                Me.Close()

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Unapprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Unapprove.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to unapprove this Forecast?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, _EmployeeTimeForecastOfficeDetailID)

                    EmployeeTimeForecastOfficeDetail.IsApproved = False
                    EmployeeTimeForecastOfficeDetail.ApprovedByEmployeeCode = Nothing
                    EmployeeTimeForecastOfficeDetail.ApprovedDate = Nothing

                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, EmployeeTimeForecastOfficeDetail)

                    LoadEmployeeTimeForecastsInformation(EmployeeTimeForecastOfficeDetail)

                End Using

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponent As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent = Nothing
            Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailAlternateEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee = Nothing
            Dim EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal) = Nothing
            Dim AutoAlertHoursChangedForSupervisedEmployee As Boolean = False
            Dim AutoAlertHoursOverbookedForEmployee As Boolean = False
            Dim SubNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim JobNode As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
            Dim SaveEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
            Dim TreeListNodesList As Generic.List(Of DevExpress.XtraTreeList.Nodes.TreeListNode) = Nothing
            Dim ETFIndirectCategoryEmployees As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee) = Nothing
            Dim ETFIndirectCategoryAlternateEmployees As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee) = Nothing
            Dim ETFJobComponentEmployees As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee) = Nothing
            Dim ETFJobComponentAlternateEmployees As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee) = Nothing
            Dim UpdateRateIfZero As Boolean = False
            Dim FoundEmployeeTitleBillingRate As Boolean = False
            Dim EmployeeTitleOnlyBillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRate As Decimal = 0

            TreeListForm_ETF.CloseEditor()

            TreeListNodesList = TreeListForm_ETF.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
            Me.ShowWaitForm()
            Me.ShowWaitForm("Saving...")

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Configuration.AutoDetectChangesEnabled = False
                        DbContext.Database.Connection.Open()

                        Try

                            EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.EmployeeTimeForecastOfficeDetails.Include("EmployeeTimeForecast").
                                                                                                                           Include("EmployeeTimeForecast.PostPeriod").
                                                                                                                           Include("Office").
                                                                                                                           Include("AssignedToEmployee").
                                                                                                                           Include("ApprovedByEmployee").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailAlternateEmployees").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailAlternateEmployees.EmployeeTitle").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailEmployees").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailEmployees.Employee").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailIndirectCategories").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailJobComponents").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees").
                                                                                                                           Include("EmployeeTimeForecastOfficeDetailJobComponentEmployees")
                                                                Where Entity.ID = _EmployeeTimeForecastOfficeDetailID
                                                                Select Entity).SingleOrDefault

                        Catch ex As Exception
                            EmployeeTimeForecastOfficeDetail = Nothing
                        End Try

                        If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                _SettingsList = AdvantageFramework.EmployeeTimeForecast.LoadSettings(DataContext)

                                AutoAlertHoursChangedForSupervisedEmployee = AdvantageFramework.EmployeeTimeForecast.LoadAutoAlertHoursChangedForSupervisedEmployeeSetting(DataContext, _SettingsList)

                                AutoAlertHoursOverbookedForEmployee = AdvantageFramework.EmployeeTimeForecast.LoadAutoAlertHoursOverbookedForEmployeeSetting(DataContext, _SettingsList)

                                If AdvantageFramework.EmployeeTimeForecast.LoadUseEmployeeTitleBillingRateSetting(DataContext, _SettingsList) Then

                                    UpdateRateIfZero = True

                                End If

                            End Using

                            EmployeeTitleOnlyBillingRateLevel = AdvantageFramework.Database.Procedures.BillingRateLevel.LoadEmployeeTitleOnlyBillingRateLevel(DbContext)

                            EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary = New Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal)
                            ETFIndirectCategoryEmployees = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees.ToList
                            ETFIndirectCategoryAlternateEmployees = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees.ToList
                            ETFJobComponentEmployees = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentEmployees.ToList
                            ETFJobComponentAlternateEmployees = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees.ToList

                            For Each Node In TreeListNodesList

                                If Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.IndirectCategories.ToString Then
                                    '========================================================================================
                                    '
                                    'INDIRECT CATEGORIES
                                    '
                                    '========================================================================================
                                    For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                                        Try

                                            EmployeeTimeForecastOfficeDetailIndirectCategory = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.SingleOrDefault(Function(Entity) Entity.ID = SubNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString))

                                        Catch ex As Exception
                                            EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
                                        End Try

                                        If EmployeeTimeForecastOfficeDetailIndirectCategory IsNot Nothing Then

                                            For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                                                Try

                                                    EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = ETFIndirectCategoryEmployees.SingleOrDefault(Function(OfficeDetailIndirectCategoryEmployee) OfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategory.ID AndAlso
                                                                                                                                                                                                           OfficeDetailIndirectCategoryEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID)

                                                Catch ex As Exception
                                                    EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee = Nothing
                                                Finally

                                                    If EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee IsNot Nothing Then

                                                        Try

                                                            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours = SubNode.GetValue(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                                                        Catch ex As Exception
                                                            EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours = EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee.Hours
                                                        End Try

                                                        'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

                                                    End If

                                                End Try

                                            Next

                                            For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                                Try

                                                    EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = ETFIndirectCategoryAlternateEmployees.SingleOrDefault(Function(OfficeDetailIndirectCategoryAlternateEmployee) OfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailIndirectCategoryID = EmployeeTimeForecastOfficeDetailIndirectCategory.ID AndAlso
                                                                                                                                                                                                                                      OfficeDetailIndirectCategoryAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)

                                                Catch ex As Exception
                                                    EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee = Nothing
                                                Finally

                                                    If EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee IsNot Nothing Then

                                                        Try

                                                            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours = SubNode.GetValue(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())

                                                        Catch ex As Exception
                                                            EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours = EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee.Hours
                                                        End Try

                                                        'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)

                                                    End If

                                                End Try

                                            Next

                                        End If

                                    Next
                                    '========================================================================================
                                    '
                                    'INDIRECT CATEGORIES
                                    '
                                    '========================================================================================
                                ElseIf Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.OfficeCode.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastHeaderItem.GrandTotals.ToString Then
                                    '========================================================================================
                                    '
                                    'GRAND TOTALS
                                    '
                                    '========================================================================================
                                    For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                                        Try

                                            If SubNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate AndAlso
                                                    SubNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailIndirectCategoryID.ToString) = AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastSubItem.BillableRate Then

                                                For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                                                    Try

                                                        EmployeeTimeForecastOfficeDetailEmployee.BillRate = SubNode.GetValue(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                                                    Catch ex As Exception
                                                        EmployeeTimeForecastOfficeDetailEmployee.BillRate = EmployeeTimeForecastOfficeDetailEmployee.BillRate
                                                    End Try

                                                    'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailEmployee)

                                                    If UpdateRateIfZero = True AndAlso EmployeeTimeForecastOfficeDetailEmployee.BillRate = 0 Then

                                                        FoundEmployeeTitleBillingRate = False
                                                        BillingRate = 0

                                                        If EmployeeTitleOnlyBillingRateLevel IsNot Nothing Then

                                                            BillingRate = AdvantageFramework.BillingSystem.LoadBillingRate(DbContext, FoundEmployeeTitleBillingRate,
                                                                                                                           EmployeeTitleOnlyBillingRateLevel,
                                                                                                                           Nothing, Nothing, Nothing,
                                                                                                                           Nothing, Nothing, Nothing, Nothing,
                                                                                                                           Nothing, Nothing, Nothing, Nothing,
                                                                                                                           Nothing, Nothing, EmployeeTimeForecastOfficeDetailEmployee.Employee.EmployeeTitleID)

                                                            If FoundEmployeeTitleBillingRate = False Then

                                                                BillingRate = EmployeeTimeForecastOfficeDetailEmployee.Employee.BillRate.GetValueOrDefault(0)

                                                            End If

                                                        Else

                                                            BillingRate = EmployeeTimeForecastOfficeDetailEmployee.Employee.BillRate.GetValueOrDefault(0)

                                                        End If

                                                        EmployeeTimeForecastOfficeDetailEmployee.BillRate = BillingRate

                                                    End If

                                                Next

                                                For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                                    Try

                                                        EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate = SubNode.GetValue(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString())

                                                    Catch ex As Exception
                                                        EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate = EmployeeTimeForecastOfficeDetailAlternateEmployee.BillRate
                                                    End Try

                                                    'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailAlternateEmployee)

                                                Next

                                            End If

                                        Catch ex As Exception

                                        End Try

                                    Next
                                    '========================================================================================
                                    '
                                    'GRAND TOTALS
                                    '
                                    '========================================================================================
                                Else
                                    '========================================================================================
                                    '
                                    'JOBS
                                    '
                                    '========================================================================================
                                    For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                                        For Each JobNode In SubNode.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                                            Try

                                                EmployeeTimeForecastOfficeDetailJobComponent = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailJobComponents.SingleOrDefault(Function(Entity) Entity.ID = JobNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.EmployeeTimeForecastOfficeDetailJobComponentID.ToString))

                                            Catch ex As Exception
                                                EmployeeTimeForecastOfficeDetailJobComponent = Nothing
                                            End Try

                                            If EmployeeTimeForecastOfficeDetailJobComponent IsNot Nothing Then

                                                EmployeeTimeForecastOfficeDetailJobComponent.RevenueAmount = JobNode.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticEmployeeTimeForecastColumn.RevenueAmount.ToString)

                                                'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponent)

                                                For Each EmployeeTimeForecastOfficeDetailEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailEmployees

                                                    Try

                                                        EmployeeTimeForecastOfficeDetailJobComponentEmployee = ETFJobComponentEmployees.SingleOrDefault(Function(OfficeDetailJobComponentEmployee) OfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                   OfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployeeID = EmployeeTimeForecastOfficeDetailEmployee.ID)

                                                    Catch ex As Exception
                                                        EmployeeTimeForecastOfficeDetailJobComponentEmployee = Nothing
                                                    Finally

                                                        If EmployeeTimeForecastOfficeDetailJobComponentEmployee IsNot Nothing Then

                                                            If AutoAlertHoursChangedForSupervisedEmployee Then

                                                                If AdvantageFramework.EmployeeTimeForecast.CheckToSendAlert(DbContext, SecurityDbContext, EmployeeTimeForecastOfficeDetailJobComponentEmployee, JobNode.GetValue(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)) Then

                                                                    EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary(EmployeeTimeForecastOfficeDetailJobComponentEmployee) = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours

                                                                End If

                                                            End If

                                                            Try

                                                                EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours = JobNode.GetValue(EmployeeTimeForecastOfficeDetailEmployee.EmployeeCode)

                                                            Catch ex As Exception
                                                                EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours = EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours
                                                            End Try

                                                            'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentEmployee)

                                                        End If

                                                    End Try

                                                Next

                                                For Each EmployeeTimeForecastOfficeDetailAlternateEmployee In EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailAlternateEmployees

                                                    Try

                                                        EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = ETFJobComponentAlternateEmployees.SingleOrDefault(Function(OfficeDetailJobComponentAlternateEmployee) OfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailJobComponentID = EmployeeTimeForecastOfficeDetailJobComponent.ID AndAlso
                                                                                                                                                                                                                              OfficeDetailJobComponentAlternateEmployee.EmployeeTimeForecastOfficeDetailAlternateEmployeeID = EmployeeTimeForecastOfficeDetailAlternateEmployee.ID)

                                                    Catch ex As Exception
                                                        EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee = Nothing
                                                    Finally

                                                        If EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee IsNot Nothing Then

                                                            Try

                                                                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours = JobNode.GetValue(EmployeeTimeForecastOfficeDetailAlternateEmployee.ID.ToString)

                                                            Catch ex As Exception
                                                                EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours = EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee.Hours
                                                            End Try

                                                            'DbContext.UpdateObject(EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)

                                                        End If

                                                    End Try

                                                Next

                                            End If

                                        Next

                                    Next
                                    '========================================================================================
                                    '
                                    'JOBS
                                    '
                                    '========================================================================================
                                End If

                            Next

                            DbContext.Configuration.AutoDetectChangesEnabled = True

                            Try

                                DbContext.SaveChanges()

                            Catch ex As Exception
                                EmployeeTimeForecastOfficeDetail = Nothing
                            End Try

                            If EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                                SaveEmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetail.ID)

                                If SaveEmployeeTimeForecastOfficeDetail IsNot Nothing Then

                                    SaveEmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                                    SaveEmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode
                                    SaveEmployeeTimeForecastOfficeDetail.Comment = TextBoxForm_Comment.Text

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, SaveEmployeeTimeForecastOfficeDetail)

                                End If

                                EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                                EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode
                                EmployeeTimeForecastOfficeDetail.Comment = TextBoxForm_Comment.Text

                                If SaveEmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso SaveEmployeeTimeForecastOfficeDetail.EmployeeTimeForecast IsNot Nothing Then

                                    SaveEmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description = TextBoxForm_Description.Text

                                    AdvantageFramework.Database.Procedures.EmployeeTimeForecast.Update(DbContext, SaveEmployeeTimeForecastOfficeDetail.EmployeeTimeForecast)

                                End If

                                EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description = TextBoxForm_Description.Text

                                If SaveEmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso AutoAlertHoursChangedForSupervisedEmployee Then

                                    AdvantageFramework.EmployeeTimeForecast.SendAlert(DbContext, SecurityDbContext, SaveEmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary)

                                End If

                                If SaveEmployeeTimeForecastOfficeDetail IsNot Nothing AndAlso AutoAlertHoursOverbookedForEmployee Then

                                    AdvantageFramework.EmployeeTimeForecast.SendAlert(DbContext, SecurityDbContext, SaveEmployeeTimeForecastOfficeDetail)

                                End If

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            Me.ShowWaitForm("Loading...")

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadEmployeeTimeForecastsInformation(Nothing)

                LoadEmployeeTimeForecastsTreeListData(Nothing)

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemPrint_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemPrint_Export.Click

            'objects
            Dim ComponentResourceManager As System.ComponentModel.ComponentResourceManager = Nothing
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageFramework.Desktop.Presentation.DynamicReportEditForm))

            PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
            PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = "ETF" & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                            PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), "ETF"))

                            'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

            End If

            If KeepLoading Then

                PrintingSystem.Links.AddRange(New Object() {PrintableComponentLink})

                PrintableComponentLink.ImageCollection.ImageStream = CType(ComponentResourceManager.GetObject("PrintableComponentLink.ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
                PrintableComponentLink.PrintingSystem = PrintingSystem

                PrintableComponentLink.Component = TreeListForm_ETF

                PrintableComponentLink.CreateDocument()

                PrintableComponentLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                PrintableComponentLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls

                PrintableComponentLink.ShowRibbonPreviewDialog(DefaultLookAndFeel.LookAndFeel)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
