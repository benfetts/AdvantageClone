Namespace GeneralLedger.ReportWriter.Presentation

    <HideModuleName()> _
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

        Public Function CreateUserDefinedReport(ByVal GLReportUserDefReport As AdvantageFramework.Database.Entities.GLReportUserDefReport) As DevExpress.XtraReports.UI.XtraReport

            'objects
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing

            Try

                Using MemoryStream = New System.IO.MemoryStream

                    Using StreamWriter = New System.IO.StreamWriter(MemoryStream)

                        StreamWriter.Write(GLReportUserDefReport.ReportDefinition)
                        StreamWriter.Flush()

                        MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                        XtraReport = DevExpress.XtraReports.UI.XtraReport.FromStream(MemoryStream, True)

                        XtraReport.DisplayName = GLReportUserDefReport.Description

                    End Using

                End Using

            Catch ex As Exception
                XtraReport = Nothing
            End Try

            CreateUserDefinedReport = XtraReport

        End Function
        Public Sub DataGridViewRowCellStyleEvent(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs, _
                                                 ByVal RowsDataTable As DataTable, ByVal ColumnsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable)

            'objects
            Dim ID As Integer = -1
            Dim RowID As Integer = -1
            Dim IsBold As Boolean = False
            Dim UnderlineAmount As Boolean = False
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing
            Dim Font As System.Drawing.Font = Nothing
            Dim IsLastRowInRowGroup As Boolean = False
            Dim ColumnType As ColumnTypes = ColumnTypes.Data

            Try

                ColumnDataRow = ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & e.Column.FieldName & "'").SingleOrDefault

            Catch ex As Exception
                ColumnDataRow = Nothing
            End Try

            If ColumnDataRow IsNot Nothing Then

                ColumnType = ColumnDataRow(ColumnFields.Type.ToString)

            End If

            RowID = CType(GridView.GetRowCellValue(e.RowHandle, GridView.Columns(StatementFields.RowID.ToString)), Integer)

            If RowID >= 0 Then

                ID = CType(GridView.GetRowCellValue(e.RowHandle, GridView.Columns(StatementFields.ID.ToString)), Integer)

                Try

                    If CType(CType(GridView.DataSource, System.Windows.Forms.BindingSource).DataSource, System.Data.DataTable).Compute("MAX(" & StatementFields.ID.ToString & ")", StatementFields.RowID.ToString & " = " & RowID) = ID Then

                        IsLastRowInRowGroup = True

                    End If

                Catch ex As Exception

                End Try

                Try

                    RowDataRow = RowsDataTable.Select(RowFields.ID.ToString & " = " & RowID).FirstOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                If RowDataRow IsNot Nothing Then

                    IsBold = RowDataRow(RowFields.IsBold.ToString)
                    UnderlineAmount = RowDataRow(RowFields.UnderlineAmount.ToString)

                    If UnderlineAmount Then

                        If ColumnType = ColumnTypes.PercentOfRow OrElse ColumnType = ColumnTypes.PercentVariance Then

                            'UnderlineAmount = False

                        End If

                    End If

                    If e.Column.FieldName = StatementFields.Description.ToString Then

                        If IsBold Then

                            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

                        End If

                    Else

                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                        If IsBold OrElse UnderlineAmount Then

                            If IsBold AndAlso UnderlineAmount Then

                                If IsLastRowInRowGroup Then

                                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                                Else

                                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

                                End If

                            ElseIf IsBold = False AndAlso UnderlineAmount Then

                                If IsLastRowInRowGroup Then

                                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Underline)

                                End If

                            ElseIf IsBold AndAlso UnderlineAmount = False Then

                                e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

                            End If

                        End If

                    End If

                End If

            ElseIf RowID = -3 Then

                If ColumnDataRow IsNot Nothing AndAlso ColumnDataRow.HasErrors Then

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)
                    e.Appearance.ForeColor = Drawing.Color.Red

                End If

            ElseIf RowID = -2 Then

                If ColumnDataRow IsNot Nothing Then

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far

                    If ColumnDataRow(ColumnFields.UnderlineColumnHeader.ToString) Then

                        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold Or Drawing.FontStyle.Underline)

                    Else

                        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

                    End If

                Else

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Bold)

                End If

            End If

        End Sub
        Public Sub DataGridViewCustomColumnDisplayTextEvent(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                                            ByVal RowHandle As Integer, ByVal Value As Object, ByRef DisplayText As String,
                                                            ByVal RowsDataTable As DataTable, ByVal ColumnsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable,
                                                            Optional ByVal CurrencySymbol As String = Nothing)

            'objects
            Dim ID As Integer = -1
            Dim RowID As Integer = -1
            Dim RowDataRow As System.Data.DataRow = Nothing
            Dim ColumnDataRow As System.Data.DataRow = Nothing
            Dim PercentOfRowColumnDataRow As System.Data.DataRow = Nothing

            RowID = CType(GridView.GetRowCellValue(RowHandle, GridView.Columns(StatementFields.RowID.ToString)), Integer)

            If RowID >= 0 Then

                ID = CType(GridView.GetRowCellValue(RowHandle, GridView.Columns(StatementFields.ID.ToString)), Integer)

                Try

                    RowDataRow = RowsDataTable.Select(RowFields.ID.ToString & " = " & RowID).FirstOrDefault

                Catch ex As Exception
                    RowDataRow = Nothing
                End Try

                If RowDataRow IsNot Nothing Then

                    If IsNumeric(Value) Then

                        If RowDataRow(RowFields.UseCurrencyFormat.ToString) Then

                            If String.IsNullOrWhiteSpace(CurrencySymbol) Then

                                DisplayText = FormatCurrency(CDec(Value), RowDataRow(RowFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                            Else

                                DisplayText = CurrencySymbol & FormatNumber(CDec(Value), RowDataRow(RowFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                            End If

                        Else

                            DisplayText = FormatNumber(CDec(Value), RowDataRow(RowFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                        End If

                    End If

                End If

                Try

                    ColumnDataRow = ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & GridColumn.FieldName & "'").SingleOrDefault

                Catch ex As Exception
                    ColumnDataRow = Nothing
                End Try

                If ColumnDataRow IsNot Nothing Then

                    If ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.Blank Then

                        DisplayText = ""

                    ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentVariance Then

                        If IsNumeric(Value) Then

                            DisplayText = FormatPercent(Value, ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                        End If

                    ElseIf ColumnDataRow(ColumnFields.Type.ToString) = ColumnTypes.PercentOfRow Then

                        If IsNumeric(Value) Then

                            Try

                                PercentOfRowColumnDataRow = PercentOfRowColumnDataTable.Select(PercentOfRowColumnFields.ColumnID.ToString & " = " & ColumnDataRow(ColumnFields.ID.ToString) & " AND " & PercentOfRowColumnFields.RowID.ToString & " = " & RowDataRow(RowFields.ID.ToString)).SingleOrDefault

                            Catch ex As Exception
                                PercentOfRowColumnDataRow = Nothing
                            End Try

                            If PercentOfRowColumnDataRow IsNot Nothing Then

                                If PercentOfRowColumnDataRow(PercentOfRowColumnFields.PercentOfRowID.ToString) Is System.DBNull.Value Then

                                    DisplayText = ""

                                Else

                                    DisplayText = FormatPercent(Value, ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                End If

                            Else

                                DisplayText = FormatPercent(Value, ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                            End If

                        End If

                    Else

                        If IsNumeric(Value) Then

                            If ColumnDataRow(ColumnFields.UseCurrencyFormat.ToString) Then

                                If String.IsNullOrWhiteSpace(CurrencySymbol) Then

                                    DisplayText = FormatCurrency(CDec(Value), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                Else

                                    DisplayText = CurrencySymbol & FormatNumber(CDec(Value), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                                End If

                            Else

                                DisplayText = FormatNumber(CDec(Value), ColumnDataRow(ColumnFields.NumberOfDecimalPlaces.ToString), TriState.True, TriState.True, TriState.True)

                            End If

                        End If

                    End If

                End If

            ElseIf RowID = -3 Then

                Try

                    ColumnDataRow = ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & GridColumn.FieldName & "'").SingleOrDefault

                Catch ex As Exception
                    ColumnDataRow = Nothing
                End Try

                If ColumnDataRow IsNot Nothing AndAlso ColumnDataRow.HasErrors Then

                    DisplayText = ColumnDataRow.RowError

                End If

            ElseIf RowID = -2 Then

                Try

                    ColumnDataRow = ColumnsDataTable.Select(ColumnFields.Name.ToString & " = '" & GridColumn.FieldName & "'").SingleOrDefault

                Catch ex As Exception
                    ColumnDataRow = Nothing
                End Try

                If ColumnDataRow IsNot Nothing Then

                    DisplayText = ColumnDataRow(ColumnFields.Description.ToString)

                End If

            Else

                DisplayText = ""

            End If

        End Sub
        Public Sub DataGridViewCustomColumnDisplayTextEvent(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs,
                                                            ByVal RowsDataTable As DataTable, ByVal ColumnsDataTable As System.Data.DataTable, ByVal PercentOfRowColumnDataTable As System.Data.DataTable,
                                                            Optional ByVal CurrencySymbol As String = Nothing)

            DataGridViewCustomColumnDisplayTextEvent(GridView, e.Column, GridView.GetRowHandle(e.ListSourceRowIndex), e.Value, e.DisplayText, RowsDataTable, ColumnsDataTable, PercentOfRowColumnDataTable, CurrencySymbol)

        End Sub
        Public Sub UpdateGLReportWriterGLRowFormatGLAccountList(DbContext As AdvantageFramework.Database.DbContext, ByRef GLReportWriterGLRowFormatReportList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport),
                                                                DepartmentTeamPresetsDataTable As System.Data.DataTable, OfficePresetsDataTable As System.Data.DataTable, EmployeeCode As String)

            'objects
            Dim FullGLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim EmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
            Dim GLReportWriterAccountReportList As Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport) = Nothing
            Dim GLACoreList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim GLACore As AdvantageFramework.Database.Core.GeneralLedgerAccount = Nothing

            FullGLACoreList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).ToList

            EmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Include("Office").Include("Office.GeneralLedgerOfficeCrossReferences").ToList

            For Each GLReportWriterGLRowFormat In GLReportWriterGLRowFormatReportList

                If GLReportWriterGLRowFormat.GLReportTemplateRow.Type = CInt(RowTypes.Account) Then

                    GLReportWriterAccountReportList = New Generic.List(Of AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport)

                    If GLReportWriterGLRowFormat.GLReportTemplateRow.LinkType = LinkTypes.AccountType Then

                        GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(Entity) Entity.Type = GLReportWriterGLRowFormat.GLReportTemplateRow.AccountType).ToList, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList)

                        GLReportWriterAccountReportList.AddRange(From Entity In GLACoreList
                                                                 Select New AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport(Entity.Type, Entity.Code, Entity.Description))

                    ElseIf GLReportWriterGLRowFormat.GLReportTemplateRow.LinkType = LinkTypes.AccountGroup Then

                        GLACoreList = New Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)

                        AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, GLReportWriterGLRowFormat.GLReportTemplateRow.AccountGroupCode)

                        If AccountGroup IsNot Nothing Then

                            For Each AccountGroupDetail In AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, AccountGroup.Code).ToList

                                If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) = False Then

                                    If AccountGroup.Type = 1 Then

                                        Try

                                            GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = AccountGroupDetail.GLACode)

                                        Catch ex As Exception
                                            GLACore = Nothing
                                        End Try

                                        If GLACore IsNot Nothing Then

                                            GLACoreList.Add(GLACore)

                                        End If

                                    ElseIf AccountGroup.Type = 2 Then

                                        GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode = AccountGroupDetail.GLACode))

                                    End If

                                End If

                                If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                                    If AccountGroup.Type = 1 Then

                                        GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.Code >= AccountGroupDetail.GLACodeFrom AndAlso Entity.Code <= AccountGroupDetail.GLACodeTo))

                                    ElseIf AccountGroup.Type = 2 Then

                                        GLACoreList.AddRange(FullGLACoreList.Where(Function(Entity) Entity.BaseCode >= AccountGroupDetail.GLACodeFrom AndAlso Entity.BaseCode <= AccountGroupDetail.GLACodeTo))

                                    End If

                                End If

                            Next

                            GLACoreList = FilterGLAsByPresets(GLACoreList, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList)

                            GLReportWriterAccountReportList.AddRange(From Entity In GLACoreList
                                                                     Select New AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport(Entity.Type, Entity.Code, Entity.Description))

                        End If

                    ElseIf GLReportWriterGLRowFormat.GLReportTemplateRow.LinkType = LinkTypes.Account Then

                        Try

                            GLACore = FullGLACoreList.SingleOrDefault(Function(Entity) Entity.Code = GLReportWriterGLRowFormat.GLReportTemplateRow.GLACode)

                        Catch ex As Exception
                            GLACore = Nothing
                        End Try

                        If GLACore IsNot Nothing AndAlso AllowGLAccount(GLACore, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList) Then

                            GLReportWriterAccountReportList.Add(New AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport(GLACore.Type, GLACore.Code, GLACore.Description))

                        End If

                    ElseIf GLReportWriterGLRowFormat.GLReportTemplateRow.LinkType = LinkTypes.AccountRange Then

                        If GLReportWriterGLRowFormat.GLReportTemplateRow.UseBaseAccountCodes Then

                            GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.BaseCode >= GLReportWriterGLRowFormat.GLReportTemplateRow.GLACodeRangeStart AndAlso ECore.BaseCode <= GLReportWriterGLRowFormat.GLReportTemplateRow.GLACodeRangeTo).ToList, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList)

                        Else

                            GLACoreList = FilterGLAsByPresets(FullGLACoreList.Where(Function(ECore) ECore.Code >= GLReportWriterGLRowFormat.GLReportTemplateRow.GLACodeRangeStart AndAlso ECore.Code <= GLReportWriterGLRowFormat.GLReportTemplateRow.GLACodeRangeTo).ToList, DepartmentTeamPresetsDataTable, OfficePresetsDataTable, EmployeeOfficeList)

                        End If

                        GLReportWriterAccountReportList.AddRange(From Entity In GLACoreList
                                                                 Select New AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterAccountReport(Entity.Type, Entity.Code, Entity.Description))

                    End If

                    GLReportWriterGLRowFormat.SetGLA(GLReportWriterAccountReportList)

                End If

            Next

        End Sub

#End Region

    End Module

End Namespace

