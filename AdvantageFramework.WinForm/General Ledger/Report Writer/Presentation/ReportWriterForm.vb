Namespace GeneralLedger.ReportWriter.Presentation

    Public Class ReportWriterForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GeneralLedgerReportList As Generic.List(Of AdvantageFramework.Database.Views.GeneralLedgerReport) = Nothing
        Private WithEvents _GridViewGLATypeSummary As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewAccountSummary As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewAccountTransactions As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Private WithEvents _GridViewAccountTransactionDetails As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadReport()

            'objects
            Dim FromPostPeriod As String = ""
            Dim ToPostPeriod As String = ""
            Dim YearEndPostPeriods As Generic.List(Of String) = Nothing

            Dim YearEndPostPeriod As String = ""
            Dim CategoryDictionary As Generic.Dictionary(Of String, Double) = Nothing

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                YearEndPostPeriods = New Generic.List(Of String)

                If RadioButtonForm_YearToDate.Checked Then

                    FromPostPeriod = ComboBoxForm_YearToDatePostPeriods.GetSelectedValue.ToString.Substring(0, 4) & "01"
                    ToPostPeriod = ComboBoxForm_YearToDatePostPeriods.GetSelectedValue

                    YearEndPostPeriods.Add(ComboBoxForm_YearToDatePostPeriods.GetSelectedValue.ToString.Substring(0, 4) & "YE")

                Else

                    FromPostPeriod = TextBoxForm_PostPeriodFrom.Text
                    ToPostPeriod = TextBoxForm_PostPeriodTo.Text

                    YearEndPostPeriod = TextBoxForm_PostPeriodTo.Text.Substring(0, 4) & "YE"

                    YearEndPostPeriods.Add(YearEndPostPeriod)

                    Do Until YearEndPostPeriod = TextBoxForm_PostPeriodFrom.Text.Substring(0, 4) & "YE"

                        YearEndPostPeriod = CStr(CInt(YearEndPostPeriod.Substring(0, 4)) - 1) & "YE"

                        YearEndPostPeriods.Add(YearEndPostPeriod)

                    Loop

                End If

                _GeneralLedgerReportList = (From GeneralLedgerReport In AdvantageFramework.Database.Procedures.GeneralLedgerReportView.Load(ObjectContext) _
                                            Where GeneralLedgerReport.PostPeriodCode >= FromPostPeriod AndAlso _
                                                  GeneralLedgerReport.PostPeriodCode <= ToPostPeriod _
                                            Select GeneralLedgerReport).ToList

                _GeneralLedgerReportList = (From GeneralLedgerReport In AdvantageFramework.Database.Procedures.GeneralLedgerReportView.Load(ObjectContext) _
                                            Where YearEndPostPeriods.Any(Function(YEPostPeriod) GeneralLedgerReport.PostPeriodCode = YEPostPeriod) = True _
                                            Select GeneralLedgerReport).ToList.Union(_GeneralLedgerReportList).ToList

                CategoryDictionary = New Generic.Dictionary(Of String, Double)

                If ButtonItemReportTypes_BalanceSheet.Checked Then

                    CategoryDictionary("Assets") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Assets").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Liabilities") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Liabilities").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Equity") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Equity").Sum(Function(GLR) GLR.Total)

                    DataGridViewForm_ReportWriter.DataSource = (From KeyValuePair In CategoryDictionary _
                                                                Select Category = KeyValuePair.Key, _
                                                                       Total = KeyValuePair.Value).ToList

                    DataGridViewForm_ReportWriter.CurrentView.ViewCaption = "Balance Sheet"

                ElseIf ButtonItemReportTypes_IncomeStatement.Checked Then

                    CategoryDictionary("Revenue") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Revenue").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Expenses") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Expenses").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Income From Operations") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Income From Operations").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Income Before Income Taxes") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Income Before Income Taxes").Sum(Function(GLR) GLR.Total)

                    DataGridViewForm_ReportWriter.DataSource = (From KeyValuePair In CategoryDictionary _
                                                                Select Category = KeyValuePair.Key, _
                                                                       Total = KeyValuePair.Value).ToList

                    DataGridViewForm_ReportWriter.CurrentView.ViewCaption = "Income Statement"

                Else

                    CategoryDictionary("Assets") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Assets").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Liabilities") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Liabilities").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Equity") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Equity").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Revenue") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Revenue").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Expenses") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Expenses").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Income From Operations") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Income From Operations").Sum(Function(GLR) GLR.Total)
                    CategoryDictionary("Income Before Income Taxes") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Category = "Income Before Income Taxes").Sum(Function(GLR) GLR.Total)

                    DataGridViewForm_ReportWriter.DataSource = (From KeyValuePair In CategoryDictionary _
                                                                Select Category = KeyValuePair.Key, _
                                                                       Total = KeyValuePair.Value).ToList

                    DataGridViewForm_ReportWriter.CurrentView.ViewCaption = "All"

                End If

            End Using

            DataGridViewForm_ReportWriter.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDetailViews()

            'objects
            Dim GLATypeSummaryGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing
            Dim AccountSummaryGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing
            Dim AccountTransactionsGridLevelNode As DevExpress.XtraGrid.GridLevelNode = Nothing

            DataGridViewForm_ReportWriter.CurrentView.BeginUpdate()

            _GridViewGLATypeSummary = New AdvantageFramework.WinForm.Presentation.Controls.GridView
            _GridViewAccountSummary = New AdvantageFramework.WinForm.Presentation.Controls.GridView
            _GridViewAccountTransactions = New AdvantageFramework.WinForm.Presentation.Controls.GridView
            _GridViewAccountTransactionDetails = New AdvantageFramework.WinForm.Presentation.Controls.GridView

            GLATypeSummaryGridLevelNode = DataGridViewForm_ReportWriter.GridControl.LevelTree.Nodes.Add("GLATypeSummary", _GridViewGLATypeSummary)

            AccountSummaryGridLevelNode = GLATypeSummaryGridLevelNode.Nodes.Add("AccountSummary", _GridViewAccountSummary)

            AccountTransactionsGridLevelNode = AccountSummaryGridLevelNode.Nodes.Add("AccountTransactions", _GridViewAccountTransactions)

            AccountSummaryGridLevelNode.Nodes.Add("AccountTransactionDetails", _GridViewAccountTransactionDetails)

            _GridViewGLATypeSummary.LevelIndent = 1
            _GridViewGLATypeSummary.ChildGridLevelName = "GLATypeSummary"
            _GridViewGLATypeSummary.GridControl = DataGridViewForm_ReportWriter.GridControl
            _GridViewGLATypeSummary.Name = "_GridViewGLATypeSummary"

            _GridViewAccountSummary.LevelIndent = 2
            _GridViewAccountSummary.ChildGridLevelName = "AccountSummary"
            _GridViewAccountSummary.GridControl = DataGridViewForm_ReportWriter.GridControl
            _GridViewAccountSummary.Name = "_GridViewAccountSummary"

            _GridViewAccountTransactions.LevelIndent = 3
            _GridViewAccountSummary.ChildGridLevelName = "AccountTransactions"
            _GridViewAccountTransactions.GridControl = DataGridViewForm_ReportWriter.GridControl
            _GridViewAccountTransactions.Name = "_GridViewAccountTransactions"

            _GridViewAccountTransactionDetails.LevelIndent = 4
            _GridViewAccountTransactionDetails.GridControl = DataGridViewForm_ReportWriter.GridControl
            _GridViewAccountTransactionDetails.Name = "_GridViewAccountTransactionDetails"

            _GridViewGLATypeSummary.Session = Me.Session
            _GridViewAccountSummary.Session = Me.Session
            _GridViewAccountTransactions.Session = Me.Session
            _GridViewAccountTransactionDetails.Session = Me.Session

            _GridViewGLATypeSummary.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            _GridViewAccountSummary.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            _GridViewAccountTransactions.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            _GridViewAccountTransactionDetails.ControlType = WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid

            _GridViewGLATypeSummary.ObjectType = GetType(AdvantageFramework.Database.Views.GeneralLedgerReport)
            _GridViewAccountSummary.ObjectType = GetType(AdvantageFramework.Database.Views.GeneralLedgerReport)
            _GridViewAccountTransactions.ObjectType = GetType(AdvantageFramework.Database.Views.GeneralLedgerReport)
            _GridViewAccountTransactionDetails.ObjectType = GetType(AdvantageFramework.Database.Views.GeneralLedgerReport)

            _GridViewGLATypeSummary.OptionsView.ShowViewCaption = False
            _GridViewAccountSummary.OptionsView.ShowViewCaption = False
            _GridViewAccountTransactions.OptionsView.ShowViewCaption = False
            _GridViewAccountTransactionDetails.OptionsView.ShowViewCaption = False

            _GridViewGLATypeSummary.OptionsView.ShowFooter = False
            _GridViewAccountSummary.OptionsView.ShowFooter = False
            _GridViewAccountTransactions.OptionsView.ShowFooter = False
            _GridViewAccountTransactionDetails.OptionsView.ShowFooter = False

            _GridViewGLATypeSummary.OptionsDetail.ShowDetailTabs = False
            _GridViewAccountSummary.OptionsDetail.ShowDetailTabs = False
            _GridViewAccountTransactions.OptionsDetail.ShowDetailTabs = False
            _GridViewAccountTransactionDetails.OptionsDetail.ShowDetailTabs = False

            _GridViewGLATypeSummary.ViewCaption = "Type Summary"
            _GridViewAccountSummary.ViewCaption = "Account Summary"
            _GridViewAccountTransactions.ViewCaption = "Account Transactions"
            _GridViewAccountTransactionDetails.ViewCaption = "Transaction Details"

            '_GridViewGLATypeSummary.CreateColumnsBasedOnObjectType()
            '_GridViewAccountSummary.CreateColumnsBasedOnObjectType()

            '_GridViewGLATypeSummary.BestFitColumns()
            '_GridViewAccountSummary.BestFitColumns()

            DataGridViewForm_ReportWriter.OptionsDetail.ShowDetailTabs = False

            DataGridViewForm_ReportWriter.CurrentView.EndUpdate()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ReportWriterForm As AdvantageFramework.GeneralLedger.ReportWriter.Presentation.ReportWriterForm = Nothing

            ReportWriterForm = New AdvantageFramework.GeneralLedger.ReportWriter.Presentation.ReportWriterForm()

            ReportWriterForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportWriterForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemReportTypes_BalanceSheet.Image = AdvantageFramework.My.Resources.BalanceSheetImage
            ButtonItemReportTypes_IncomeStatement.Image = AdvantageFramework.My.Resources.IncomeStatementImage
            ButtonItemReportTypes_All.Image = AdvantageFramework.My.Resources.OtherCashReceiptsImage

            LoadDetailViews()

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_YearToDatePostPeriods.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(ObjectContext).OrderByDescending(Function(Entity) Entity.Year).ThenBy(Function(Entity) Entity.Month).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _GridViewAccountTransactions_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles _GridViewAccountTransactions.MasterRowExpanded

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_ReportWriter.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub _GridViewAccountTransactions_MasterRowEmpty(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles _GridViewAccountTransactions.MasterRowEmpty

            'e.IsEmpty = ((From GeneralLedgerReport In _GeneralLedgerReportList _
            '              Order By GeneralLedgerReport.TransactionID, _
            '                       GeneralLedgerReport.SequenceNumber _
            '              Where GeneralLedgerReport.GeneralLedgerAccount = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "GeneralLedgerAccount") AndAlso _
            '                    GeneralLedgerReport.SourceDocument = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "SourceDocument") AndAlso _
            '                    GeneralLedgerReport.TransactionID = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "TransactionID") _
            '              Select GeneralLedgerReport.SequenceNumber, _
            '                     GeneralLedgerReport.GeneralLedgerAccount, _
            '                     GeneralLedgerReport.Debit, _
            '                     GeneralLedgerReport.Credit, _
            '                     GeneralLedgerReport.Reference).Any = False)

        End Sub
        Private Sub _GridViewAccountTransactions_MasterRowGetChildList(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles _GridViewAccountTransactions.MasterRowGetChildList

            'e.ChildList = (From GeneralLedgerReport In _GeneralLedgerReportList _
            '               Order By GeneralLedgerReport.TransactionID, _
            '                        GeneralLedgerReport.SequenceNumber _
            '               Where GeneralLedgerReport.GeneralLedgerAccount = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "GeneralLedgerAccount") AndAlso _
            '                     GeneralLedgerReport.SourceDocument = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "SourceDocument") AndAlso _
            '                     GeneralLedgerReport.TransactionID = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "TransactionID") _
            '               Select GeneralLedgerReport.SequenceNumber, _
            '                      GeneralLedgerReport.GeneralLedgerAccount, _
            '                      GeneralLedgerReport.Debit, _
            '                      GeneralLedgerReport.Credit, _
            '                      GeneralLedgerReport.Reference).ToList

        End Sub
        Private Sub _GridViewAccountTransactions_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles _GridViewAccountTransactions.MasterRowGetRelationCount

            e.RelationCount = 1

        End Sub
        Private Sub _GridViewAccountTransactions_MasterRowGetRelationName(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles _GridViewAccountTransactions.MasterRowGetRelationName

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "AccountTransactionDetails"

            End Select

        End Sub
        Private Sub _GridViewAccountTransactions_MasterRowGetLevelDefaultView(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles _GridViewAccountTransactions.MasterRowGetLevelDefaultView

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewAccountTransactionDetails

            End Select

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles _GridViewAccountSummary.MasterRowExpanded

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_ReportWriter.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowEmpty(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles _GridViewAccountSummary.MasterRowEmpty

            'e.IsEmpty = ((From GeneralLedgerReport In _GeneralLedgerReportList _
            '              Order By GeneralLedgerReport.TransactionID _
            '              Where GeneralLedgerReport.GLACode = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "GLACode") _
            '              Group GeneralLedgerReport By GeneralLedgerReport.GeneralLedgerAccount, GeneralLedgerReport.TransactionID, GeneralLedgerReport.SourceDocument, GeneralLedgerReport.Description Into GLAReport = Group _
            '              Select GeneralLedgerAccount, _
            '                     TransactionID, _
            '                     SourceDocument, _
            '                     Description, _
            '                     [Total] = GLAReport.Sum(Function(GLARptDtl) GLARptDtl.Total)).Any = False)

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowGetChildList(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles _GridViewAccountSummary.MasterRowGetChildList

            'e.ChildList = (From GeneralLedgerReport In _GeneralLedgerReportList _
            '               Order By GeneralLedgerReport.TransactionID _
            '               Where GeneralLedgerReport.GLACode = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "GLACode") _
            '               Group GeneralLedgerReport By GeneralLedgerReport.GeneralLedgerAccount, GeneralLedgerReport.TransactionID, GeneralLedgerReport.SourceDocument, GeneralLedgerReport.Description Into GLAReport = Group _
            '               Select GeneralLedgerAccount, _
            '                      TransactionID, _
            '                      SourceDocument, _
            '                      Description, _
            '                      [Total] = GLAReport.Sum(Function(GLARptDtl) GLARptDtl.Total)).ToList

            'e.ChildList = (From GeneralLedgerReport In _GeneralLedgerReportList _
            '               Order By GeneralLedgerReport.TransactionID, _
            '                        GeneralLedgerReport.SequenceNumber _
            '               Where GeneralLedgerReport.GeneralLedgerAccount = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "GeneralLedgerAccount") AndAlso _
            '                     GeneralLedgerReport.SourceDocument = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "SourceDocument") AndAlso _
            '                     GeneralLedgerReport.TransactionID = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "TransactionID") _
            '               Select GeneralLedgerReport.SequenceNumber, _
            '                      GeneralLedgerReport.GeneralLedgerAccount, _
            '                      GeneralLedgerReport.Debit, _
            '                      GeneralLedgerReport.Credit, _
            '                      GeneralLedgerReport.Reference).ToList

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles _GridViewAccountSummary.MasterRowGetRelationCount

            e.RelationCount = 1

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowGetRelationName(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles _GridViewAccountSummary.MasterRowGetRelationName

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "AccountTransactions"

            End Select

        End Sub
        Private Sub _GridViewAccountSummary_MasterRowGetLevelDefaultView(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles _GridViewAccountSummary.MasterRowGetLevelDefaultView

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewAccountTransactions

            End Select

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowExpanded(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles _GridViewGLATypeSummary.MasterRowExpanded

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_ReportWriter.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowEmpty(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles _GridViewGLATypeSummary.MasterRowEmpty

            ''objects
            'Dim GLAType As String = ""

            'GLAType = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "Type")

            'e.IsEmpty = ((From GeneralLedgerReport In _GeneralLedgerReportList _
            '              Order By GeneralLedgerReport.TransactionID _
            '              Where GeneralLedgerReport.Type = GLAType _
            '              Group GeneralLedgerReport By GeneralLedgerReport.GLACode, GeneralLedgerReport.GLADescription, GeneralLedgerReport.GeneralLedgerAccount Into GLAReport = Group _
            '              Select GLACode, _
            '                     GLADescription, _
            '                     GeneralLedgerAccount, _
            '                     [Total] = GLAReport.Sum(Function(GLARptDtl) GLARptDtl.Total)).Any = False)

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowGetChildList(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles _GridViewGLATypeSummary.MasterRowGetChildList

            'objects
            Dim GLAType As String = ""

            GLAType = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(e.RowHandle, "Type")

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If GLAType = "Non-Current Asset" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "1" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Current Asset" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "2" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Fixed Asset" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "3" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Current Liability" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "5" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Non-Current Liability" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "4" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Equity" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "20" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Income" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "8" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Expense - COS" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "13" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Expense - Operating" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "14" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Income - Other" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "9" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Expense - Taxes" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "16" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                ElseIf GLAType = "Expense - Other" Then

                    e.ChildList = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(ObjectContext).ToList _
                                   Where GeneralLedgerAccount.Type = "15" _
                                   Group Join GLReport In _GeneralLedgerReportList On GLReport.GLACode Equals GeneralLedgerAccount.Code Into Group, [Total] = Sum(GLReport.Total) _
                                   Select [GLACode] = GeneralLedgerAccount.Code, _
                                          [GLADescription] = GeneralLedgerAccount.Description, _
                                          [GeneralLedgerAccount] = GeneralLedgerAccount.ToString, _
                                          [Total]).ToList

                End If

            End Using

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowGetRelationCount(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles _GridViewGLATypeSummary.MasterRowGetRelationCount

            e.RelationCount = 1

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowGetRelationName(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles _GridViewGLATypeSummary.MasterRowGetRelationName

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "AccountSummary"

            End Select

        End Sub
        Private Sub _GridViewGLATypeSummary_MasterRowGetLevelDefaultView(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles _GridViewGLATypeSummary.MasterRowGetLevelDefaultView

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewAccountSummary

            End Select

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowEmptyEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowEmptyEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowEmptyEvent

            e.IsEmpty = False

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowGetChildListEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetChildListEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowGetChildListEvent

            'objects
            Dim ReportCategory As String = ""
            Dim GLATypeDictionary As Generic.Dictionary(Of String, Double) = Nothing

            Using ObjectContext = New AdvantageFramework.Database.ObjectContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ReportCategory = DataGridViewForm_ReportWriter.CurrentView.GetRowCellValue(e.RowHandle, "Category")

                GLATypeDictionary = New Generic.Dictionary(Of String, Double)

                If ReportCategory = "Assets" Then

                    GLATypeDictionary("Current Asset") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Current Asset").Sum(Function(GLR) GLR.Total)
                    GLATypeDictionary("Non-Current Asset") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Non-Current Asset").Sum(Function(GLR) GLR.Total)
                    GLATypeDictionary("Fixed Asset") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Fixed Asset").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Liabilities" Then

                    GLATypeDictionary("Current Liability") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Current Liability").Sum(Function(GLR) GLR.Total)
                    GLATypeDictionary("Non-Current Liability") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Non-Current Liability").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Equity" Then

                    GLATypeDictionary("Equity") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Equity").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Revenue" Then

                    GLATypeDictionary("Income") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Income").Sum(Function(GLR) GLR.Total)
                    GLATypeDictionary("Expense - COS") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Expense - COS").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Expenses" Then

                    GLATypeDictionary("Expense - Operating") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Expense - Operating").Sum(Function(GLR) GLR.Total)
                    GLATypeDictionary("Expense - Other") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Expense - Other").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Income From Operations" Then

                    GLATypeDictionary("Income - Other") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Income - Other").Sum(Function(GLR) GLR.Total)

                ElseIf ReportCategory = "Income Before Income Taxes" Then

                    GLATypeDictionary("Expense - Taxes") = _GeneralLedgerReportList.Where(Function(GLR) GLR.Type = "Expense - Taxes").Sum(Function(GLR) GLR.Total)

                End If

                e.ChildList = (From KeyValuePair In GLATypeDictionary _
                               Select [Type] = KeyValuePair.Key, _
                                      [Total] = KeyValuePair.Value).ToList

            End Using

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowGetRelationCountEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationCountEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowGetRelationCountEvent

            e.RelationCount = 1

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowGetRelationNameEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetRelationNameEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowGetRelationNameEvent

            Select Case e.RelationIndex

                Case 0

                    e.RelationName = "GLATypeSummary"

            End Select

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowExpandedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowExpandedEvent

            'objects
            Dim BaseView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing

            BaseView = DataGridViewForm_ReportWriter.CurrentView.GetDetailView(e.RowHandle, e.RelationIndex)

            If BaseView IsNot Nothing AndAlso TypeOf BaseView Is DevExpress.XtraGrid.Views.Grid.GridView Then

                BaseView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_ReportWriter_MasterRowGetLevelDefaultViewEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.MasterRowGetLevelDefaultViewEventArgs) Handles DataGridViewForm_ReportWriter.MasterRowGetLevelDefaultViewEvent

            Select Case e.RelationIndex

                Case 0

                    e.DefaultView = _GridViewGLATypeSummary

            End Select

        End Sub
        Private Sub RadioButtonForm_YearToDate_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_YearToDate.CheckedChanged

            If Me.HasLoaded Then

                If RadioButtonForm_YearToDate.Checked Then

                    ComboBoxForm_YearToDatePostPeriods.Enabled = True
                    ComboBoxForm_YearToDatePostPeriods.SelectedIndex = 0

                    TextBoxForm_PostPeriodFrom.Enabled = False
                    TextBoxForm_PostPeriodTo.Enabled = False

                    TextBoxForm_PostPeriodFrom.Text = ""
                    TextBoxForm_PostPeriodTo.Text = ""

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_PostPeriod_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonForm_PostPeriod.CheckedChanged

            If Me.HasLoaded Then

                If RadioButtonForm_PostPeriod.Checked Then

                    ComboBoxForm_YearToDatePostPeriods.Enabled = False
                    ComboBoxForm_YearToDatePostPeriods.SelectedIndex = 0

                    TextBoxForm_PostPeriodFrom.Enabled = True
                    TextBoxForm_PostPeriodTo.Enabled = True

                    TextBoxForm_PostPeriodFrom.Text = ""
                    TextBoxForm_PostPeriodTo.Text = ""

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_YearToDatePostPeriods_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_YearToDatePostPeriods.SelectedValueChanged

            ButtonItemActions_Process.Enabled = ComboBoxForm_YearToDatePostPeriods.HasASelectedValue

        End Sub
        Private Sub TextBoxForm_PostPeriodFrom_TagObjectChanged() Handles TextBoxForm_PostPeriodFrom.TagObjectChanged

            If (TextBoxForm_PostPeriodFrom.Tag IsNot Nothing AndAlso TypeOf TextBoxForm_PostPeriodFrom.Tag Is AdvantageFramework.Database.Entities.PostPeriod) AndAlso _
                    (TextBoxForm_PostPeriodTo.Tag IsNot Nothing AndAlso TypeOf TextBoxForm_PostPeriodTo.Tag Is AdvantageFramework.Database.Entities.PostPeriod) Then

                ButtonItemActions_Process.Enabled = True

            Else

                ButtonItemActions_Process.Enabled = False

            End If

        End Sub
        Private Sub TextBoxForm_PostPeriodTo_TagObjectChanged() Handles TextBoxForm_PostPeriodTo.TagObjectChanged

            If (TextBoxForm_PostPeriodFrom.Tag IsNot Nothing AndAlso TypeOf TextBoxForm_PostPeriodFrom.Tag Is AdvantageFramework.Database.Entities.PostPeriod) AndAlso _
                    (TextBoxForm_PostPeriodTo.Tag IsNot Nothing AndAlso TypeOf TextBoxForm_PostPeriodTo.Tag Is AdvantageFramework.Database.Entities.PostPeriod) Then

                ButtonItemActions_Process.Enabled = True

            Else

                ButtonItemActions_Process.Enabled = False

            End If

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Process.Click

            LoadReport()

        End Sub

#End Region

#End Region

    End Class

End Namespace