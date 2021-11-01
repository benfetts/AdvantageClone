Namespace FinanceAndAccounting.Presentation

    Public Class EmployeeTimeForecastComparisonDashboardForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.


        End Sub
        Private Sub LoadComparisonDashboard()

            'objects
            Dim Month As Integer = 0
            Dim Year As Integer = 0
            Dim PostPeriodMonth As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    Year = ComboBoxItemBottomSection_Year.ComboBoxEx.SelectedValue

                Catch ex As Exception
                    Year = 0
                End Try

                Try

                    Month = ComboBoxItemTopSection_Month.ComboBoxEx.SelectedValue

                Catch ex As Exception
                    Month = 0
                End Try

                TreeListForm_ComparisonDashboard.DataSource = Nothing

                TreeListForm_ComparisonDashboard.Columns.Clear()
                TreeListForm_ComparisonDashboard.Nodes.Clear()

                If Year <> 0 Then

                    TreeListForm_ComparisonDashboard.DataSource = AdvantageFramework.EmployeeTimeForecast.BuildEmployeeTimeForecastComparisonDashbaordDataTable(Me.Session, DbContext, Year, Month, ButtonItemRightSection_ShowForecastedUtilization.Checked, ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.Checked)

                    For Each TreeListColumn In TreeListForm_ComparisonDashboard.Columns.OfType(Of DevExpress.XtraTreeList.Columns.TreeListColumn)().ToList

                        If TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentOfficeCode.ToString Then

                            TreeListColumn.Visible = False

                        ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeCode.ToString Then

                            TreeListColumn.Visible = False

                        ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeName.ToString Then

                            TreeListColumn.Visible = True
                            TreeListColumn.Width = 200

                        ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ParentClientCode.ToString Then

                            TreeListColumn.Visible = False

                        ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientCode.ToString Then

                            TreeListColumn.Visible = False

                        ElseIf TreeListColumn.FieldName = AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.ClientName.ToString Then

                            TreeListColumn.Visible = True
                            TreeListColumn.Width = 200

                        Else

                            TreeListColumn.Visible = True
                            TreeListColumn.Width = 125

                            If IsNumeric(TreeListColumn.FieldName) Then

                                Try

                                    PostPeriodMonth = CInt(TreeListColumn.FieldName.Replace(Year.ToString, ""))

                                Catch ex As Exception
                                    PostPeriodMonth = 0
                                End Try

                                If PostPeriodMonth < Month Then

                                    TreeListColumn.AppearanceCell.BackColor = Drawing.Color.White

                                Else

                                    TreeListColumn.AppearanceCell.BackColor = Drawing.Color.LightYellow

                                End If

                            End If

                        End If

                    Next

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim EmployeeTimeForecastComparisonDashboardForm As AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastComparisonDashboardForm = Nothing

            EmployeeTimeForecastComparisonDashboardForm = New AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastComparisonDashboardForm()

            EmployeeTimeForecastComparisonDashboardForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimeForecastComparisonDashboardForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MonthBindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim YearBindingSource As System.Windows.Forms.BindingSource = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxItemTopSection_Month.ComboBoxEx.DisplayMember = "Value"
                ComboBoxItemTopSection_Month.ComboBoxEx.ValueMember = "Key"

                MonthBindingSource = New System.Windows.Forms.BindingSource

                MonthBindingSource.DataSource = (From Entity In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months)).ToList
                                                 Select Entity.Key,
                                                        Entity.Value).ToList
                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(MonthBindingSource, ComboBoxItemTopSection_Month.ComboBoxEx.DisplayMember,
                                                                                                  ComboBoxItemTopSection_Month.ComboBoxEx.ValueMember,
                                                                                                  "[" & AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                                                                                                  0, True, True)
                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(MonthBindingSource, ComboBoxItemTopSection_Month.ComboBoxEx.DisplayMember,
                                                                                                  ComboBoxItemTopSection_Month.ComboBoxEx.ValueMember,
                                                                                                  "[All]",
                                                                                                  13, False, True)

                ComboBoxItemTopSection_Month.ComboBoxEx.DataSource = MonthBindingSource

                '-------------------------------------------------------------

                ComboBoxItemBottomSection_Year.ComboBoxEx.DisplayMember = "YearString"
                ComboBoxItemBottomSection_Year.ComboBoxEx.ValueMember = "Year"

                YearBindingSource = New System.Windows.Forms.BindingSource

                YearBindingSource.DataSource = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                                                Select New With {.[Year] = CInt(Entity.Year)}).OrderByDescending(Function(Entity) Entity.Year).ToList.Select(Function(Entity) New With {.[YearString] = CStr(Entity.Year),
                                                                                                                                                                                        .[Year] = CStr(Entity.Year)}).ToList
                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(YearBindingSource, ComboBoxItemBottomSection_Year.ComboBoxEx.DisplayMember,
                                                                                                  ComboBoxItemBottomSection_Year.ComboBoxEx.ValueMember,
                                                                                                  "[" & AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect.ToString) & "]",
                                                                                                  "", True, True)

                ComboBoxItemBottomSection_Year.ComboBoxEx.DataSource = YearBindingSource

                '-------------------------------------------------------------

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxItemBottomSection_Year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemBottomSection_Year.SelectedIndexChanged

            If Me.FormShown Then

                LoadComparisonDashboard()

            End If

        End Sub
        Private Sub ComboBoxItemTopSection_Month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxItemTopSection_Month.SelectedIndexChanged

            If Me.FormShown Then

                LoadComparisonDashboard()

            End If

        End Sub
        Private Sub ButtonItemRightSection_ShowForecastedUtilization_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRightSection_ShowForecastedUtilization.CheckedChanged

            If Me.FormShown Then

                LoadComparisonDashboard()

            End If

        End Sub
        Private Sub ButtonItemRightSection_ShowResultsForForecastedProjectsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRightSection_ShowResultsForForecastedProjectsOnly.CheckedChanged

            If Me.FormShown Then

                LoadComparisonDashboard()

            End If

        End Sub
        Private Sub TreeListForm_ComparisonDashboard_CustomDrawNodeCell(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs) Handles TreeListForm_ComparisonDashboard.CustomDrawNodeCell

            If e.Node.ParentNode Is Nothing Then

                e.Appearance.BackColor = Drawing.Color.LightGray
                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font.FontFamily.Name, e.Appearance.Font.Size, Drawing.FontStyle.Bold)

                If e.Node.GetValue(AdvantageFramework.EmployeeTimeForecast.StaticComparisonDashboardColumn.OfficeCode.ToString) = "ETFCDGrandTotals" Then

                    e.CellText = ""

                End If

            ElseIf e.Node.ParentNode IsNot Nothing AndAlso e.Node.HasChildren Then

                e.Appearance.BackColor = Drawing.Color.WhiteSmoke
                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font.FontFamily.Name, e.Appearance.Font.Size, Drawing.FontStyle.Bold)

            End If

        End Sub
        Private Sub ButtonItemETF_ExpandAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemETF_ExpandAll.Click

            TreeListForm_ComparisonDashboard.ExpandAll()

        End Sub
        Private Sub ButtonItemETF_CollapseAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemETF_CollapseAll.Click

            TreeListForm_ComparisonDashboard.CollapseAll()

        End Sub
        Private Sub ButtonItemOffice_ExpandOfficeLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOffice_ExpandOfficeLevel.Click

            For Each Node In TreeListForm_ComparisonDashboard.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = True

            Next

        End Sub
        Private Sub ButtonItemOffice_CollapseOfficeLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemOffice_CollapseOfficeLevel.Click

            For Each Node In TreeListForm_ComparisonDashboard.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = False

            Next

        End Sub
        Private Sub ButtonItemClient_ExpandClientLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemClient_ExpandClientLevel.Click

            For Each Node In TreeListForm_ComparisonDashboard.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                Node.Expanded = True

                For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                    If SubNode.HasChildren Then

                        SubNode.Expanded = True

                    End If

                Next

            Next

        End Sub
        Private Sub ButtonItemClient_CollapseClientLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemClient_CollapseClientLevel.Click

            For Each Node In TreeListForm_ComparisonDashboard.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                For Each SubNode In Node.Nodes.OfType(Of DevExpress.XtraTreeList.Nodes.TreeListNode).ToList

                    If SubNode.HasChildren Then

                        SubNode.Expanded = False

                    End If

                Next

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace