Namespace Media.Presentation

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MediaManagerSelectBy
            AllOpenOrders = 0
            Client = 1
            ClientDivision = 2
            ClientDivisionProduct = 3
            Campaign = 4
            Job = 5
            JobComponent = 6
            Order = 7
            Buyer = 8
            AccountExecutiveDefault = 9
            AccountExecutiveJob = 10
            OrderStatus = 11
            Vendor = 12
            LastFour = 13
            PO = 14
        End Enum

#End Region

#Region " Variables "

        Private _SyncDetailSettings As Boolean = False
        Private _AddColumnsHeadersToAllEstimates As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub CustomFieldValueCells(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomFieldValueCellsEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim CellCounter As Integer = 0
            Dim FieldValueCell As DevExpress.XtraPivotGrid.FieldValueCell = Nothing

            If MediaPlanEstimate IsNot Nothing Then

                For CellCounter = e.GetCellCount(False) - 1 To 0 Step -1

                    FieldValueCell = e.GetCell(False, CellCounter)

                    If FieldValueCell IsNot Nothing AndAlso FieldValueCell.Field IsNot Nothing Then

                        If FieldValueCell.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso FieldValueCell.Field.AreaIndex = 0 Then

                            If MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.Description = FieldValueCell.Field.FieldName).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.Description = FieldValueCell.Value).Count <= 1 Then

                                e.Remove(FieldValueCell)

                            End If

                        ElseIf FieldValueCell.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total Then

                            e.Remove(FieldValueCell)

                        End If

                    End If

                Next CellCounter

            End If

        End Sub
        Public Sub CustomSummary(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim TotalDemo1 As Decimal = 0
            Dim TotalDemo2 As Decimal = 0
            Dim Demo1 As Decimal = 0
            Dim Demo2 As Decimal = 0
            Dim Units As Decimal = 0
            Dim Impressions As Decimal = 0
            Dim Clicks As Decimal = 0
            Dim Rate As Decimal = 0
            Dim Dollars As Decimal = 0
            Dim AgencyFee As Decimal = 0
            Dim BillAmount As Decimal = 0
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim NetAmount As Decimal = 0
            Dim VendorCommission As Nullable(Of Decimal) = Nothing
            Dim VendorMarkup As Nullable(Of Decimal) = Nothing
            Dim Quantity As Decimal = 0
            Dim DataColumns As Generic.List(Of System.Data.DataColumn) = Nothing
            Dim QuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim PreviousQuantityColumn As AdvantageFramework.MediaPlanning.DataColumns = AdvantageFramework.MediaPlanning.DataColumns.ID
            Dim UseAverageCalcuation As Boolean = False
            Dim LastRowFieldIndex As Integer = -1
            Dim LastColumnFieldIndex As Integer = -1
            Dim RowQuantityColumns As Hashtable = Nothing

            If MediaPlanEstimate IsNot Nothing Then

                If e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                    LastRowFieldIndex = CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.RowArea) - 1
                    LastColumnFieldIndex = CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).Fields.GetVisibleFieldCount(DevExpress.XtraPivotGrid.PivotArea.ColumnArea) - 1

                    If e.RowField Is Nothing OrElse e.ColumnField Is Nothing OrElse (e.RowField.AreaIndex = LastRowFieldIndex AndAlso e.ColumnField.AreaIndex = LastColumnFieldIndex) = False Then

                        Try

                            PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                        Catch ex As Exception
                            PivotDrillDownDataSource = Nothing
                        End Try

                        If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                            DataColumns = MediaPlanEstimate.EstimateDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString) = 3 AndAlso DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString) = True).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)).ToList

                            For Each DataColumn In DataColumns.ToList

                                If (DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString OrElse
                                            DataColumn.ColumnName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString) = False Then

                                    DataColumns.Remove(DataColumn)

                                End If

                            Next

                            RowQuantityColumns = New Hashtable

                            For Each PivotDrillDownDataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)

                                If RowQuantityColumns.ContainsKey(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) = False Then

                                    QuantityColumn = AdvantageFramework.MediaPlanning.GetQuantityColumn(MediaPlanEstimate, PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString),
                                                                                                        PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString),
                                                                                                        DataColumns)

                                    RowQuantityColumns(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) = QuantityColumn

                                Else

                                    QuantityColumn = RowQuantityColumns(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                                End If

                                If QuantityColumn <> AdvantageFramework.MediaPlanning.DataColumns.ID Then

                                    If QuantityColumn = MediaPlanning.Methods.DataColumns.Units Then

                                        If MediaPlanEstimate.CheckForUnitsQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                            If MediaPlanEstimate.CheckForUnitsCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        Else

                                            If MediaPlanEstimate.IsUnitsCPM Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        End If

                                    ElseIf QuantityColumn = MediaPlanning.Methods.DataColumns.Impressions Then

                                        If MediaPlanEstimate.CheckForImpressionsQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                            If MediaPlanEstimate.CheckForImpressionsCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        Else

                                            If MediaPlanEstimate.IsImpressionsCPM Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        End If

                                    ElseIf QuantityColumn = MediaPlanning.Methods.DataColumns.Clicks Then

                                        If MediaPlanEstimate.CheckForClicksQuantity(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                            If MediaPlanEstimate.CheckForClicksCPM(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        Else

                                            If MediaPlanEstimate.IsClicksCPM Then

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += (CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)) * 1000)

                                            Else

                                                Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                                Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                            End If

                                        End If

                                    ElseIf QuantityColumn = MediaPlanning.Methods.DataColumns.Columns Then

                                        Quantity += (CDec(PivotDrillDownDataRow(QuantityColumn.ToString)) * CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString)))
                                        Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                    Else

                                        Quantity += CDec(PivotDrillDownDataRow(QuantityColumn.ToString))
                                        Dollars += CDec(PivotDrillDownDataRow(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))

                                    End If

                                    If PreviousQuantityColumn = MediaPlanning.Methods.DataColumns.ID Then

                                        PreviousQuantityColumn = QuantityColumn

                                    ElseIf PreviousQuantityColumn <> QuantityColumn Then

                                        UseAverageCalcuation = True
                                        Exit For

                                    End If

                                End If

                            Next

                            If UseAverageCalcuation Then

                                e.CustomValue = e.SummaryValue.Average

                            Else

                                'Dollars = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)))

                                If Quantity <> 0 Then

                                    e.CustomValue = Dollars / Quantity

                                Else

                                    e.CustomValue = 0

                                End If

                            End If

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = e.SummaryValue.Average

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString AndAlso String.IsNullOrWhiteSpace(MediaPlanEstimate.GrossPercentageInTotalField) = False Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        If MediaPlanEstimate.GrossPercentageInTotalField = AdvantageFramework.MediaPlanning.GrossPercentInTotals.BillAmount.ToString AndAlso MediaPlanEstimate.MediaPlan.TotalBillAmount > 0 Then

                            e.CustomValue = (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(MediaPlanEstimate.GrossPercentageInTotalField))) / MediaPlanEstimate.MediaPlan.TotalBillAmount)

                        ElseIf MediaPlanEstimate.GrossPercentageInTotalField = AdvantageFramework.MediaPlanning.GrossPercentInTotals.Dollars.ToString AndAlso MediaPlanEstimate.MediaPlan.TotalDollars > 0 Then

                            e.CustomValue = (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(MediaPlanEstimate.GrossPercentageInTotalField))) / MediaPlanEstimate.MediaPlan.TotalDollars)

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Clicks = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString)))
                        Impressions = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString)))

                        If Impressions <> 0 Then

                            e.CustomValue = (Clicks / Impressions)

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Units = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)))
                        Clicks = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString)))

                        If Clicks <> 0 Then

                            e.CustomValue = (Units / Clicks)

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Dollars = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)))

                        For Each DataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().ToList

                            TotalDemo1 += (CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)) * CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)))

                        Next

                        If TotalDemo1 <> 0 Then

                            e.CustomValue = (Dollars / TotalDemo1)

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Dollars = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)))

                        For Each DataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().ToList

                            TotalDemo2 += (CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString)) * CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)))

                        Next

                        If TotalDemo2 <> 0 Then

                            e.CustomValue = (Dollars / TotalDemo2)

                        Else

                            e.CustomValue = 0

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        For Each DataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().ToList

                            TotalDemo1 += (CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString)) * CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)))

                        Next

                        e.CustomValue = TotalDemo1

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        For Each DataRow In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().ToList

                            TotalDemo2 += (CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString)) * CDec(DataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Units.ToString)))

                        Next

                        e.CustomValue = TotalDemo2

                    Else

                        e.CustomValue = 0

                    End If

                ElseIf e.DataField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource()

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

                        If MediaPlanDetailLevel IsNot Nothing Then

                            If MediaPlanEstimate.IsEstimateGrossAmount Then

                                e.CustomValue = 0

                                For Each VendorName In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CStr(PDDDR.Item(MediaPlanDetailLevel.Description))).Distinct.ToList

                                    For Each RowIndex In PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Select(Function(PDDDR) CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                                        VendorCommission = Nothing

                                        For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.Description = VendorName AndAlso Entity.RowIndex = RowIndex).ToList

                                            If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing AndAlso MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault IsNot Nothing Then

                                                VendorCommission = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.FirstOrDefault.VendorCommission

                                                If VendorCommission.HasValue = False OrElse VendorCommission.Value = 0 Then

                                                    NetAmount += (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Where(Function(PDDDR) CStr(PDDDR.Item(MediaPlanDetailLevel.Description)) = VendorName AndAlso CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) = RowIndex).
                                                                                                                                                                             Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))) * 0.85)

                                                Else

                                                    NetAmount += (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Where(Function(PDDDR) CStr(PDDDR.Item(MediaPlanDetailLevel.Description)) = VendorName AndAlso CInt(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString)) = RowIndex).
                                                                                                                                                                             Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))) * ((100 - VendorCommission.Value) / 100))

                                                End If

                                            Else

                                                NetAmount += (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Where(Function(PDDDR) PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = MediaPlanDetailLevelLine.RowIndex).
                                                                                                                                                                         Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))) * 0.85)

                                            End If

                                        Next

                                    Next

                                Next

                                e.CustomValue = NetAmount

                            Else

                                e.CustomValue = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)))

                            End If

                        Else

                            If MediaPlanEstimate.IsEstimateGrossAmount Then

                                e.CustomValue = (PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString))) * 0.85)

                            Else

                                e.CustomValue = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow)().Sum(Function(PDDDR) CDec(PDDDR.Item(AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString)))

                            End If

                        End If

                    Else

                        e.CustomValue = 0

                    End If

                End If

            End If

        End Sub
        Public Sub CustomUnboundFieldData(sender As Object, e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim RowIndex As Integer = -1
            Dim DaysOfWeeks As String = ""

            If e.Field IsNot Nothing AndAlso MediaPlanEstimate IsNot Nothing Then

                If e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                    Try

                        RowIndex = CInt(e.GetListSourceColumnValue(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                    Catch ex As Exception
                        RowIndex = -1
                    End Try

                    If RowIndex > -1 AndAlso MediaPlanEstimate.EntryDates IsNot Nothing Then

                        e.Value = AdvantageFramework.MediaPlanning.CreateDayOfWeeks(MediaPlanEstimate, New Integer() {RowIndex})

                    End If

                ElseIf e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString Then

                    Try

                        RowIndex = CInt(e.GetListSourceColumnValue(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                    Catch ex As Exception
                        RowIndex = -1
                    End Try

                    If RowIndex > -1 Then

                        e.Value = MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString))).FirstOrDefault

                    End If

                ElseIf e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                    Try

                        RowIndex = CInt(e.GetListSourceColumnValue(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                    Catch ex As Exception
                        RowIndex = -1
                    End Try

                    If RowIndex > -1 Then

                        e.Value = MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CStr(DR(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString))).FirstOrDefault

                    End If

                ElseIf e.Field.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                    Try

                        RowIndex = CInt(e.GetListSourceColumnValue(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                    Catch ex As Exception
                        RowIndex = -1
                    End Try

                    If RowIndex > -1 Then

                        e.Value = MediaPlanEstimate.GetDateRangeForRow(RowIndex)

                    End If

                End If

            End If

        End Sub
        Public Sub CustomDrawFieldValue(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim HasOnlyOneColumnField As Boolean = False
            Dim IsOnHiatusDate As Boolean = False

            If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso TypeOf sender Is DevExpress.XtraPivotGrid.PivotGridControl Then

                If e.Field Is Nothing Then

                    If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

                        HasOnlyOneColumnField = (CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.ColumnArea).Count = 1)

                        For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

                            If PGF.Visible AndAlso PGF.Options.ShowGrandTotal Then

                                'If HasOnlyOneColumnField Then
                                e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold
                                e.Info.Caption = "Grand Total" & System.Environment.NewLine & PGF.Caption

                                'Else

                                '    e.Info.Caption = "Grand Total" & System.Environment.NewLine & System.Environment.NewLine & PGF.Caption

                                'End If

                                Exit For

                            End If

                        Next

                    End If

                End If

            ElseIf e.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea AndAlso e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                If Date.MinValue <> e.Value AndAlso MediaPlanEstimate IsNot Nothing Then

                    If e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        IsOnHiatusDate = MediaPlanEstimate.IsOnWeekHiatusDate(e.Value)

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                            e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        IsOnHiatusDate = MediaPlanEstimate.IsOMonthHiatusDate(e.Value)

                    End If

                    If IsOnHiatusDate Then

                        e.Appearance.ForeColor = Drawing.Color.Red

                        e.DefaultDraw()

                        e.Handled = True

                    End If

                End If

            End If

        End Sub
        Public Sub CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)

            If e.Field IsNot Nothing Then

                If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea AndAlso e.ListSourceRowIndex1 > -1 AndAlso e.ListSourceRowIndex2 > -1 Then

                    e.Handled = True

                    If e.Value1 <> e.Value2 Then

                        If e.GetListSourceColumnValue(e.ListSourceRowIndex1, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) > e.GetListSourceColumnValue(e.ListSourceRowIndex2, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

                            e.Result = 1

                        ElseIf e.GetListSourceColumnValue(e.ListSourceRowIndex1, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) < e.GetListSourceColumnValue(e.ListSourceRowIndex2, AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) Then

                            e.Result = -1

                        Else

                            e.Result = 0

                        End If

                    Else

                        e.Result = 0

                    End If

                End If

            End If

        End Sub
        Public Sub CustomGroupInterval(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomGroupIntervalEventArgs,
                                       MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan,
                                       MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim EntryDate As Date = Nothing
            Dim Year As Integer = 0
            Dim Quarter As Integer = 0
            Dim Month As Integer = 0

            If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                Try

                    EntryDate = e.Value

                Catch ex As Exception
                    EntryDate = Nothing
                End Try

                If EntryDate <> Nothing Then

                    If e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                        'e.GroupValue = New Date(AdvantageFramework.MediaPlanning.GetYearForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlan.BroadcastCalendarWeeks), 1, 1)
                        e.GroupValue = EntryDate

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        'Quarter = AdvantageFramework.MediaPlanning.GetQuarterForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlan.BroadcastCalendarWeeks, Year)

                        'If Quarter = 1 Then

                        '	e.GroupValue = New Date(Year, 1, 1)

                        'ElseIf Quarter = 2 Then

                        '	e.GroupValue = New Date(Year, 4, 1)

                        'ElseIf Quarter = 3 Then

                        '	e.GroupValue = New Date(Year, 7, 1)

                        'ElseIf Quarter = 4 Then

                        '	e.GroupValue = New Date(Year, 10, 1)

                        'End If

                        e.GroupValue = EntryDate

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        'Month = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlan.BroadcastCalendarWeeks, Year)

                        'e.GroupValue = New Date(Year, Month, 1)
                        e.GroupValue = EntryDate

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        'e.GroupValue = AdvantageFramework.MediaPlanning.GetWeekDateForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlan.BroadcastCalendarWeeks, MediaPlanEstimate.SplitWeeks)
                        e.GroupValue = EntryDate

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

                        e.GroupValue = EntryDate

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                        e.GroupValue = EntryDate

                    End If

                End If

            End If

        End Sub
        Public Sub FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs, MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim Prefix As String = ""
            Dim FirstDate As Date = Nothing
            Dim EntryDate As Date = Nothing
            Dim MonthValue As Integer = 0
            Dim Month As AdvantageFramework.DateUtilities.Months = DateUtilities.Months.January

            If e.Field IsNot Nothing AndAlso e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                Try

                    EntryDate = e.Value

                Catch ex As Exception
                    EntryDate = Nothing
                End Try

                If EntryDate <> Nothing AndAlso MediaPlanEstimate IsNot Nothing Then

                    If e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                        e.DisplayText = AdvantageFramework.MediaPlanning.GetYearForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlanEstimate.MediaPlan.BroadcastCalendarWeeks)

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString Then

                        If e.Field.Tag Is Nothing Then

                            e.Field.Tag = MediaPlanEstimate.QuarterPrefix

                        End If

                        e.DisplayText = e.Field.Tag & AdvantageFramework.MediaPlanning.GetQuarterForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlanEstimate.MediaPlan.BroadcastCalendarWeeks)

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString Then

                        e.DisplayText = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlanEstimate.MediaPlan.BroadcastCalendarWeeks)

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                        MonthValue = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlanEstimate.MediaPlan.BroadcastCalendarWeeks)

                        If MonthValue > 0 AndAlso MonthValue < 13 Then

                            Month = MonthValue

                            e.DisplayText = Month.ToString

                        Else

                            e.DisplayText = ""

                        End If

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString Then

                        If e.Field.Tag Is Nothing Then

                            e.Field.Tag = MediaPlanEstimate.WeekDisplayType

                        End If

                        Try

                            If e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekNumber Then

                                e.DisplayText = AdvantageFramework.MediaPlanning.GetWeekForEstimate(EntryDate, MediaPlanEstimate.IsCalendarMonth, MediaPlanEstimate.MediaPlan.BroadcastCalendarWeeks)

                            Else

                                Try

                                    FirstDate = EntryDate

                                    If MediaPlanEstimate.IsCalendarMonth Then

                                        If MediaPlanEstimate.SplitWeeks = False Then

                                            Do Until FirstDate.DayOfWeek = DayOfWeek.Sunday

                                                FirstDate = FirstDate.AddDays(-1)

                                            Loop

                                        End If

                                    Else

                                        Do Until FirstDate.DayOfWeek = DayOfWeek.Monday

                                            FirstDate = FirstDate.AddDays(-1)

                                        Loop

                                    End If

                                Catch ex As Exception
                                    FirstDate = Nothing
                                End Try

                                If FirstDate <> Nothing Then

                                    If e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDate Then

                                        e.DisplayText = Format(FirstDate.Month, "0#") & "/" & Format(FirstDate.Day, "0#")

                                    ElseIf e.Field.Tag = AdvantageFramework.MediaPlanning.WeekDisplayTypes.WeekStartDay Then

                                        e.DisplayText = FirstDate.Day

                                    Else

                                        e.DisplayText = e.Value

                                    End If

                                Else

                                    e.DisplayText = e.Value

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    ElseIf e.Field.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString Then

                        e.DisplayText = EntryDate.Day

                    End If

                End If

            End If

        End Sub
        Private Function DoesPivotGridHaveOnlyOneVisibleDataField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl) As Boolean

            'objects
            Dim HasOnlyOneVisibleDataField As Boolean = False
            Dim Count As Integer = 0

            For Each PGF In PivotGridControl.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

                If PGF.Visible AndAlso PGF.Options.ShowGrandTotal Then

                    Count += 1

                End If

            Next

            If Count = 1 Then

                HasOnlyOneVisibleDataField = True

            End If

            DoesPivotGridHaveOnlyOneVisibleDataField = HasOnlyOneVisibleDataField

        End Function
        Private Sub SetTotalsOptionsOnPivotGridControl(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'PivotGridControl.BeginUpdate()

            Try

                PivotGridControl.OptionsView.ShowColumnGrandTotalHeader = MediaPlanEstimate.ShowColumnGrandTotals
                PivotGridControl.OptionsView.ShowColumnGrandTotals = MediaPlanEstimate.ShowColumnGrandTotals

                PivotGridControl.OptionsView.ShowColumnTotals = MediaPlanEstimate.ShowColumnTotals

                PivotGridControl.OptionsView.ShowRowGrandTotalHeader = MediaPlanEstimate.ShowRowGrandTotals
                PivotGridControl.OptionsView.ShowRowGrandTotals = MediaPlanEstimate.ShowRowGrandTotals

                PivotGridControl.OptionsView.ShowRowTotals = MediaPlanEstimate.ShowRowTotals

            Catch ex As Exception

            End Try

            'PivotGridControl.EndUpdate()

        End Sub
        Public Sub LoadPivotGrid(ByVal Session As AdvantageFramework.Security.Session, ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl,
                                 ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim PivotGridAreaDictionary As Generic.Dictionary(Of Long, String) = Nothing
            Dim PivotGridAllowedAreaName As String = Nothing
            Dim SubItemNumericInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemNumericInput = Nothing

            If MediaPlanEstimate IsNot Nothing Then

                PivotGridControl.Appearance.FieldValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
                PivotGridControl.Appearance.FieldHeader.FontStyleDelta = Drawing.FontStyle.Bold
                PivotGridControl.Appearance.FieldValue.FontStyleDelta = Drawing.FontStyle.Bold
                PivotGridControl.Appearance.FieldValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

                PivotGridControl.OptionsView.ShowTotalsForSingleValues = True

                If MediaPlanEstimate.FreezeLevels Then

                    PivotGridControl.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.CellsArea

                Else

                    PivotGridControl.OptionsBehavior.HorizontalScrolling = DevExpress.XtraPivotGrid.PivotGridScrolling.Control

                End If

                Try

                    PivotGridControl.Fields.Clear()
                    'PivotGridControl.DataSource = Nothing

                Catch ex As Exception

                End Try

                PivotGridControl.DataSource = MediaPlanEstimate.EstimateDataTable

                LoadCalculatedFieldsToPivotGrid(PivotGridControl, MediaPlanEstimate)

                PivotGridAreaDictionary = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(DevExpress.XtraPivotGrid.PivotArea))

                For Each PivotGridField In PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField)().ToList

                    PivotGridField.UseNativeFormat = DevExpress.Utils.DefaultBoolean.False

                    PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
                    PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
                    PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
                    PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

                    Try

                        DataColumn = MediaPlanEstimate.EstimateDataTable.Columns(PivotGridField.FieldName)

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.MediaPlanDetailLevelID.ToString) = False Then

                            Try

                                PivotGridAllowedAreaName = PivotGridAreaDictionary.SingleOrDefault(Function(KVP) KVP.Key = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString)).Value

                            Catch ex As Exception

                            End Try

                            PivotGridField.Caption = DataColumn.Caption
                            PivotGridField.Area = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Area.ToString)
                            PivotGridField.AreaIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)

                            Try

                                PivotGridField.AllowedAreas = AdvantageFramework.EnumUtilities.GetValue(GetType(DevExpress.XtraPivotGrid.PivotGridAllowedAreas), PivotGridAllowedAreaName)

                            Catch ex As Exception

                            End Try

                            PivotGridField.Visible = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.IsVisible.ToString)
                            PivotGridField.Index = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Index.ToString)
                            PivotGridField.SortOrder = DevExpress.XtraPivotGrid.PivotSortOrder.Ascending
                            PivotGridField.Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.Width.ToString)

                            If PivotGridField.Visible = False AndAlso PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea Then

                                PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
                                PivotGridField.Options.ShowInCustomizationForm = False
                                PivotGridField.Options.ShowInPrefilter = False

                            End If

                            If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                                PivotGridField.Options.AllowExpand = DevExpress.Utils.DefaultBoolean.True
                                PivotGridField.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Default

                            End If

                            If PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea Then

                                PivotGridField.Options.ShowGrandTotal = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInGrandTotals.ToString)
                                PivotGridField.Options.ShowTotals = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInTotals.ToString)
                                PivotGridField.Options.ShowValues = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.ShowInValues.ToString)

                                PivotGridField.Options.AllowFilter = DevExpress.Utils.DefaultBoolean.False
                                PivotGridField.Options.AllowFilterBySummary = DevExpress.Utils.DefaultBoolean.False

                            End If

                            If PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.[Date].ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                                PivotGridField.CellFormat.FormatString = "d"
                                PivotGridField.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                                PivotGridField.ValueFormat.FormatString = "d"
                                PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                                    PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                                    PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString Then

                                PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                                    PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                                    PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString Then

                                PivotGridField.FilterValues.FilterType = DevExpress.XtraPivotGrid.PivotFilterType.Excluded
                                PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n1"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n1"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "c2"
                                PivotGridField.Options.AllowEdit = False

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "c2"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "c2"
                                'PivotGridField.Options.AllowEdit = Not MediaPlanEstimate.CalculateDollars

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "c2"
                                'PivotGridField.Options.AllowEdit = Not MediaPlanEstimate.CalculateDollars

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n0"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Rate.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "c2"
                                PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Currency, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n0"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n0"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Columns.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n2"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.InchesLines.ToString Then

                                PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                PivotGridField.CellFormat.FormatString = "n2"

                                AdvantageFramework.WinForm.Presentation.Controls.AddSubItemNumericInput(Session, PivotGridControl, PivotGridField, WinForm.Presentation.Controls.SubItemNumericInput.Type.Decimal, GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData), True, DbContext)

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Note.ToString Then

                                PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Max
                                PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
                                PivotGridField.Options.ShowInCustomizationForm = False
                                PivotGridField.Options.ShowInPrefilter = False
                                PivotGridField.Visible = False

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Color.ToString Then

                                PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
                                PivotGridField.Options.ShowInCustomizationForm = False
                                PivotGridField.Options.ShowInPrefilter = False
                                PivotGridField.Visible = False

                            ElseIf PivotGridField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString Then

                                PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
                                PivotGridField.Options.ShowInCustomizationForm = False
                                PivotGridField.Options.ShowInPrefilter = False

                            End If

                        Else

                            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
                            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
                            PivotGridField.Visible = True
                            PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
                            PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
                            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.True
                            PivotGridField.Options.ShowInCustomizationForm = True
                            PivotGridField.Options.ShowInPrefilter = True
                            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
                            PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom
                            PivotGridField.Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString)

                        End If

                    End If

                Next

                For Each MediaPlanDetailField In MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 3).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                    PivotGridField = PivotGridControl.Fields(MediaPlanDetailField.FieldID)

                    If PivotGridField IsNot Nothing Then

                        PivotGridField.Visible = MediaPlanDetailField.IsVisible
                        PivotGridField.AreaIndex = MediaPlanDetailField.AreaIndex
                        PivotGridField.Visible = MediaPlanDetailField.IsVisible

                    End If

                Next

                For Each PivotGridField In PivotGridControl.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.RowArea)

                    Try

                        DataColumn = MediaPlanEstimate.LevelsAndLinesDataTable.Columns(PivotGridField.FieldName)

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        PivotGridField.AreaIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)
                        PivotGridField.Visible = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.IsVisible.ToString)

                        'If PivotGridField.AreaIndex = 0 Then

                        '    PivotGridField.Options.ShowTotals = True

                        'Else

                        '    PivotGridField.Options.ShowTotals = False

                        'End If

                    End If

                Next

                For Each UnboundedField In MediaPlanEstimate.GetUnboundFieldsInOrder

                    If UnboundedField = AdvantageFramework.MediaPlanning.Settings.ShowPackageName.ToString Then

                        ShowPackageLevelsField(PivotGridControl, MediaPlanEstimate)

                    ElseIf UnboundedField = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString Then

                        ShowDateRangeField(PivotGridControl, MediaPlanEstimate)

                    ElseIf UnboundedField = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString Then

                        ShowAdSizesField(PivotGridControl, MediaPlanEstimate)

                    ElseIf UnboundedField = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString Then

                        AddDaysOfWeekField(PivotGridControl, MediaPlanEstimate)

                    End If

                Next

                For Each PivotGridField In PivotGridControl.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

                    If String.IsNullOrWhiteSpace(PivotGridField.FieldName) = False Then

                        Try

                            DataColumn = MediaPlanEstimate.EstimateDataTable.Columns(PivotGridField.FieldName)

                        Catch ex As Exception
                            DataColumn = Nothing
                        End Try

                        If DataColumn IsNot Nothing Then

                            PivotGridField.AreaIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailField.Properties.AreaIndex.ToString)

                        End If

                    Else

                        If PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.CTRIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.ConversionRateIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.NetDollarsIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.CPIIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.CPP1Index

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.CPP2Index

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.TotalDemo1Index

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.TotalDemo2Index

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.TotalNetIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.CommissionIndex

                        ElseIf PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString Then

                            PivotGridField.AreaIndex = MediaPlanEstimate.GrossPercentageInTotalsIndex

                        End If

                    End If

                Next

                PivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always

                PivotGridControl.OptionsCustomization.AllowEdit = True 'Not _MediaPlan.IsApproved

                PivotGridControl.OptionsCustomization.AllowPrefilter = False
                PivotGridControl.OptionsCustomization.AllowSortInCustomizationForm = False

            End If

        End Sub
        Public Sub SetExpandedValuesForPivotGrid(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            'PivotGridControl.BeginUpdate()

            For Each PivotGridField In PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField)().Where(Function(PGF) PGF.Visible AndAlso PGF.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea).ToList

                Try

                    MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) PivotGridField.FieldName = Entity.Description)

                Catch ex As Exception
                    MediaPlanDetailLevel = Nothing
                End Try

                If MediaPlanDetailLevel IsNot Nothing AndAlso MediaPlanDetailLevel.MediaPlanDetailLevelLines IsNot Nothing Then

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines.ToList

                        Try

                            If MediaPlanDetailLevelLine.Expanded Then

                                If PivotGridControl.IsObjectCollapsed(PivotGridField, MediaPlanDetailLevelLine.RowIndex) Then

                                    PivotGridField.ExpandValue(MediaPlanDetailLevelLine.Description)

                                End If

                            Else

                                If PivotGridControl.IsObjectCollapsed(PivotGridField, MediaPlanDetailLevelLine.RowIndex) = False Then

                                    PivotGridField.CollapseValue(MediaPlanDetailLevelLine.Description)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                End If

            Next

            'PivotGridControl.EndUpdate()

        End Sub
        Public Sub LoadCalculatedFieldsToPivotGrid(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl,
                                                   ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            AddGrossPercentageInTotalsField(PivotGridControl, MediaPlanEstimate)
            AddNetDollarsField(PivotGridControl, MediaPlanEstimate)
            AddCPP1Field(PivotGridControl, MediaPlanEstimate)
            AddCPP2Field(PivotGridControl, MediaPlanEstimate)
            AddCPIField(PivotGridControl, MediaPlanEstimate)
            AddCTRField(PivotGridControl, MediaPlanEstimate)
            AddConversionRateField(PivotGridControl, MediaPlanEstimate)
            AddTotalDemo1Field(PivotGridControl, MediaPlanEstimate)
            AddTotalDemo2Field(PivotGridControl, MediaPlanEstimate)
            AddTotalNetField(PivotGridControl, MediaPlanEstimate)
            AddCommissionField(PivotGridControl, MediaPlanEstimate)

        End Sub
        Public Sub AddGrossPercentageInTotalsField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl,
                                                   ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.GrossPercentageInTotals.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.GrossPercentageInTotalsIndex
            PivotGridField.Caption = MediaPlanEstimate.GrossPercentageInTotalsCaption
            PivotGridField.Width = MediaPlanEstimate.GrossPercentageInTotalsWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "P"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.GrossPercentageInTotalsShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.GrossPercentageInTotals

        End Sub
        Public Sub AddNetDollarsField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'If MediaPlanEstimate.IsEstimateGrossAmount Then

            '    PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString & "] * 0.85"

            'Else

            '    PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString & "]"

            'End If

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.NetDollarsIndex
            PivotGridField.Caption = MediaPlanEstimate.NetDollarsCaption
            PivotGridField.Width = MediaPlanEstimate.NetDollarsWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.NetDollarsShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False
            PivotGridField.Visible = MediaPlanEstimate.NetDollars

        End Sub
        Public Sub AddCPP1Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP1.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString & "]"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.CPP1Index
            PivotGridField.Caption = MediaPlanEstimate.CPP1Caption
            PivotGridField.Width = MediaPlanEstimate.CPP1Width

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.CPP1ShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.CPP1

        End Sub
        Public Sub AddCPP2Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPP2.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString & "]"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.CPP2Index
            PivotGridField.Caption = MediaPlanEstimate.CPP2Caption
            PivotGridField.Width = MediaPlanEstimate.CPP2Width

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.CPP2ShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.CPP2

        End Sub
        Public Sub AddCPIField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues
            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CPI.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average

            If MediaPlanEstimate.IsImpressionsCPM Then

                PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / ([" & AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString & "] / 1000)"

            Else

                PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString & "]"

            End If

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.CPIIndex
            PivotGridField.Caption = MediaPlanEstimate.CPICaption
            PivotGridField.Width = MediaPlanEstimate.CPIWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.CPIShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False
            PivotGridField.Visible = MediaPlanEstimate.CPI

        End Sub
        Public Sub AddCTRField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.CTR.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "([" & AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString & "])"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.CTRIndex
            PivotGridField.Caption = MediaPlanEstimate.CTRCaption
            PivotGridField.Width = MediaPlanEstimate.CTRWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "P"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.CTRShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.CTR

        End Sub
        Public Sub AddConversionRateField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ConversionRate.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "([" & AdvantageFramework.MediaPlanning.DataColumns.Units.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString & "])"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.ConversionRateIndex
            PivotGridField.Caption = MediaPlanEstimate.ConversionRateCaption
            PivotGridField.Width = MediaPlanEstimate.ConversionRateWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "P"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.ConversionRateShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.ConversionRate

        End Sub
        Public Sub AddTotalDemo1Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo1.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "([" & AdvantageFramework.MediaPlanning.DataColumns.Units.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString & "])"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.TotalDemo1Index
            PivotGridField.Caption = MediaPlanEstimate.TotalDemo1Caption
            PivotGridField.Width = MediaPlanEstimate.TotalDemo1Width

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "n1"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.TotalDemo1ShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.TotalDemo1

        End Sub
        Public Sub AddTotalDemo2Field(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalDemo2.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            'PivotGridField.UnboundExpression = "([" & AdvantageFramework.MediaPlanning.DataColumns.Units.ToString & "] / [" & AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString & "])"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.TotalDemo2Index
            PivotGridField.Caption = MediaPlanEstimate.TotalDemo2Caption
            PivotGridField.Width = MediaPlanEstimate.TotalDemo2Width

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "n1"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.TotalDemo2ShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.TotalDemo2

        End Sub
        Public Sub AddTotalNetField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues
            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.TotalNet.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum

            PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString & "] + [" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "]"
            'PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "]"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.TotalNetIndex
            PivotGridField.Caption = MediaPlanEstimate.TotalNetCaption
            PivotGridField.Width = MediaPlanEstimate.TotalNetWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.TotalNetShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.TotalNet

        End Sub
        Public Sub AddCommissionField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundExpressionMode = DevExpress.XtraPivotGrid.UnboundExpressionMode.UseSummaryValues
            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.Commission.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
            PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum

            If MediaPlanEstimate.IsEstimateGrossAmount Then

                PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString & "] - [" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "]"

            Else

                PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.DataColumns.BillAmount.ToString & "] - [" & AdvantageFramework.MediaPlanning.DataColumns.Dollars.ToString & "]"

            End If
            'PivotGridField.UnboundExpression = "[" & AdvantageFramework.MediaPlanning.Settings.NetDollars.ToString & "]"

            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.DataArea

            PivotGridField.AreaIndex = MediaPlanEstimate.CommissionIndex
            PivotGridField.Caption = MediaPlanEstimate.CommissionCaption
            PivotGridField.Width = MediaPlanEstimate.CommissionWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            PivotGridField.CellFormat.FormatString = "c2"

            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowValues = False
            PivotGridField.Options.ShowTotals = MediaPlanEstimate.CommissionShowTotals
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.ShowGrandTotal = True
            PivotGridField.Options.AllowEdit = False

            PivotGridField.Visible = MediaPlanEstimate.Commission

        End Sub
        Public Sub AddDaysOfWeekField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.DaysOfWeek.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.String
            'PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
            PivotGridField.Caption = MediaPlanEstimate.DaysOfWeekCaption
            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.None

            PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowEdit = False
            PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom

            If MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.AsLevel Then

                PivotGridField.Visible = True

            Else

                PivotGridField.Visible = False

            End If

        End Sub
        Public Sub ShowPackageLevelsField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Visible = MediaPlanEstimate.ShowPackageName

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.String
            'PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea

            If MediaPlanEstimate.ShowPackageName AndAlso MediaPlanEstimate.PackageLevelIndex = -1 Then


            ElseIf MediaPlanEstimate.ShowPackageName Then

                PivotGridField.SetAreaPosition(DevExpress.XtraPivotGrid.PivotArea.RowArea, MediaPlanEstimate.PackageLevelIndex)

            End If
            'PivotGridField.AreaIndex = MediaPlanEstimate.PackageLevelIndex
            PivotGridField.Caption = MediaPlanEstimate.PackageNameCaption
            PivotGridField.Width = MediaPlanEstimate.PackageLevelWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.None

            PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowEdit = False
            PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom

        End Sub
        Public Sub ShowDateRangeField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Visible = MediaPlanEstimate.ShowDateRange

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowDateRange.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.String
            'PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea

            If MediaPlanEstimate.ShowDateRange AndAlso MediaPlanEstimate.DateRangeIndex = -1 Then


            ElseIf MediaPlanEstimate.ShowDateRange Then

                PivotGridField.SetAreaPosition(DevExpress.XtraPivotGrid.PivotArea.RowArea, MediaPlanEstimate.DateRangeIndex)

            End If

            'PivotGridField.AreaIndex = MediaPlanEstimate.DateRangeIndex
            PivotGridField.Caption = MediaPlanEstimate.DateRangeCaption
            PivotGridField.Width = MediaPlanEstimate.DateRangeWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.None

            PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowEdit = False
            PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom

        End Sub
        Public Sub ShowAdSizesField(ByVal PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            Try

                PivotGridField = PivotGridControl.Fields.OfType(Of DevExpress.XtraPivotGrid.PivotGridField).SingleOrDefault(Function(PGF) PGF.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString)

            Catch ex As Exception
                PivotGridField = Nothing
            End Try

            If PivotGridField Is Nothing Then

                PivotGridField = PivotGridControl.Fields.Add()

            End If

            PivotGridField.Visible = MediaPlanEstimate.ShowAdSizes

            PivotGridField.Appearance.Header.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.Value.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueGrandTotal.FontStyleDelta = Drawing.FontStyle.Bold
            PivotGridField.Appearance.ValueTotal.FontStyleDelta = Drawing.FontStyle.Bold

            PivotGridField.UnboundFieldName = AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString
            PivotGridField.UnboundType = DevExpress.Data.UnboundColumnType.String
            'PivotGridField.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom

            PivotGridField.AllowedAreas = DevExpress.XtraPivotGrid.PivotGridAllowedAreas.RowArea
            PivotGridField.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea

            If MediaPlanEstimate.ShowAdSizes AndAlso MediaPlanEstimate.AdSizesIndex = -1 Then


            ElseIf MediaPlanEstimate.ShowAdSizes Then

                PivotGridField.SetAreaPosition(DevExpress.XtraPivotGrid.PivotArea.RowArea, MediaPlanEstimate.AdSizesIndex)

            End If

            'PivotGridField.AreaIndex = MediaPlanEstimate.AdSizesIndex
            PivotGridField.Caption = MediaPlanEstimate.AdSizesCaption
            PivotGridField.Width = MediaPlanEstimate.AdSizesWidth

            PivotGridField.CellFormat.FormatType = DevExpress.Utils.FormatType.None

            PivotGridField.Options.AllowSort = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowSortBySummary = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.AllowDragInCustomizationForm = DevExpress.Utils.DefaultBoolean.False
            PivotGridField.Options.ShowInCustomizationForm = False
            PivotGridField.Options.ShowInPrefilter = False
            PivotGridField.Options.AllowDrag = DevExpress.Utils.DefaultBoolean.True
            PivotGridField.Options.AllowEdit = False
            PivotGridField.SortMode = DevExpress.XtraPivotGrid.PivotSortMode.Custom

        End Sub
        Private Sub PivotGridControl_FirstPivotGridCustomExportCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportCellEventArgs)

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Color As Integer = 0
            Dim HasNote As Boolean = False
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim FilteredMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim IsActualized As Boolean = False

            Try

                If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso
                        e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        PivotDrillDownDataSource = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex)

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            MediaPlanEstimate = sender.Tag

                        Catch ex As Exception
                            MediaPlanEstimate = Nothing
                        End Try

                        If MediaPlanEstimate IsNot Nothing Then

                            Try

                                RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Catch ex As Exception
                                RowIndexes = Nothing
                            End Try

                            Try

                                EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).Distinct.ToList

                            Catch ex As Exception
                                EntryDates = Nothing
                            End Try

                            Try

                                MediaPlanDetailLevelLineDatas = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).ToList

                            Catch ex As Exception
                                MediaPlanDetailLevelLineDatas = Nothing
                            End Try

                            FilteredMediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                            If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

                                Try

                                    For Each EntryDate In EntryDates

                                        For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatas

                                            If EntryDate >= MediaPlanDetailLevelLineData.StartDate AndAlso EntryDate <= MediaPlanDetailLevelLineData.EndDate Then

                                                FilteredMediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                                            End If

                                        Next

                                    Next

                                Catch ex As Exception

                                End Try

                            End If

                            If FilteredMediaPlanDetailLevelLineDatas IsNot Nothing AndAlso FilteredMediaPlanDetailLevelLineDatas.Count > 0 Then

                                Try

                                    If FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.Color <> 0) Then

                                        Color = FilteredMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.Color <> 0).Max(Function(Entity) Entity.Color)

                                    End If

                                Catch ex As Exception
                                    Color = 0
                                End Try

                                Try

                                    IsActualized = FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)

                                Catch ex As Exception
                                    IsActualized = False
                                End Try

                            End If

                            If Color <> 0 Then

                                e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                            Else

                                e.Appearance.BackColor = System.Drawing.Color.White

                            End If

                            If IsActualized Then

                                e.Appearance.FontStyleDelta = Drawing.FontStyle.Italic

                            Else

                                e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                            End If

                        Else

                            Try

                                Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) <> 0).Max(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString))

                            Catch ex As Exception
                                Color = 0
                            End Try

                            If Color <> 0 Then

                                e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                            Else

                                e.Appearance.BackColor = System.Drawing.Color.White

                            End If

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                        End If

                        Try

                            If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

                                HasNote = True

                            End If

                        Catch ex As Exception
                            HasNote = False
                        End Try

                    End If

                End If

            Catch ex As Exception

            End Try

            Try

                If e.DataField IsNot Nothing Then

                    If (e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                            e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) AndAlso HasNote = False Then

                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsExportNativeFormat = DevExpress.Utils.DefaultBoolean.True
                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsxFormatString = "0.0"

                    End If

                End If

            Catch ex As Exception

            End Try

            If (e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse
                    e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal))) AndAlso e.Value IsNot Nothing Then

                If e.Value.GetType.Equals(GetType(System.Int32)) AndAlso e.Value = 0 Then

                    e.Brick.TextValue = Nothing

                ElseIf DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 Then

                    e.Brick.TextValue = Nothing

                End If

            End If

            If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                e.Appearance.BackColor = System.Drawing.Color.LightCyan
                e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

            ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                e.Appearance.BackColor = System.Drawing.Color.LightCyan
                e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

            End If

            If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

            ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

            End If

        End Sub
        Private Sub PivotGridControl_CustomExportCell(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportCellEventArgs)

            'objects
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim Color As Integer = 0
            Dim HasData As Boolean = False
            Dim ColumnHeadingCount As Integer = 0
            Dim HasNote As Boolean = False
            Dim CellDates As Generic.List(Of Date) = Nothing
            Dim HasOrders As Boolean = False
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim EntryDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim FilteredMediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing
            Dim IsActualized As Boolean = False

            Try

                If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso
                        e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        PivotDrillDownDataSource = DirectCast(sender, DevExpress.XtraPivotGrid.PivotGridControl).CreateDrillDownDataSource(e.ColumnIndex, e.RowIndex)

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            MediaPlanEstimate = sender.Tag

                        Catch ex As Exception
                            MediaPlanEstimate = Nothing
                        End Try

                        If MediaPlanEstimate IsNot Nothing Then

                            Try

                                RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).Distinct.ToList

                            Catch ex As Exception
                                RowIndexes = Nothing
                            End Try

                            Try

                                EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).Distinct.ToList

                            Catch ex As Exception
                                EntryDates = Nothing
                            End Try

                            Try

                                MediaPlanDetailLevelLineDatas = MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) RowIndexes.Contains(Entity.RowIndex)).ToList

                            Catch ex As Exception
                                MediaPlanDetailLevelLineDatas = Nothing
                            End Try

                            FilteredMediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

                            If MediaPlanDetailLevelLineDatas IsNot Nothing AndAlso MediaPlanDetailLevelLineDatas.Count > 0 Then

                                Try

                                    For Each EntryDate In EntryDates

                                        For Each MediaPlanDetailLevelLineData In MediaPlanDetailLevelLineDatas

                                            If EntryDate >= MediaPlanDetailLevelLineData.StartDate AndAlso EntryDate <= MediaPlanDetailLevelLineData.EndDate Then

                                                FilteredMediaPlanDetailLevelLineDatas.Add(MediaPlanDetailLevelLineData)

                                            End If

                                        Next

                                    Next

                                Catch ex As Exception

                                End Try

                            End If

                            If FilteredMediaPlanDetailLevelLineDatas IsNot Nothing AndAlso FilteredMediaPlanDetailLevelLineDatas.Count > 0 Then

                                Try

                                    If FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.Color <> 0) Then

                                        Color = FilteredMediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.Color <> 0).Max(Function(Entity) Entity.Color)

                                    End If

                                Catch ex As Exception
                                    Color = 0
                                End Try

                                Try

                                    IsActualized = FilteredMediaPlanDetailLevelLineDatas.Any(Function(Entity) Entity.IsActualized = True)

                                Catch ex As Exception
                                    IsActualized = False
                                End Try

                            End If

                            If Color <> 0 Then

                                e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                            Else

                                e.Appearance.BackColor = System.Drawing.Color.White

                            End If

                            If IsActualized Then

                                e.Appearance.FontStyleDelta = Drawing.FontStyle.Italic

                            Else

                                e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                            End If

                        Else

                            Try

                                Color = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString) <> 0).Max(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Color.ToString))

                            Catch ex As Exception
                                Color = 0
                            End Try

                            If Color <> 0 Then

                                e.Appearance.BackColor = System.Drawing.Color.FromArgb(Color)

                            Else

                                e.Appearance.BackColor = System.Drawing.Color.White

                            End If

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Regular

                        End If

                        Try

                            If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

                                HasNote = True

                            End If

                        Catch ex As Exception
                            HasNote = False
                        End Try

                    End If

                End If

            Catch ex As Exception

            End Try

            Try

                If e.DataField IsNot Nothing Then

                    If (e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                            e.DataField.FieldName = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString) AndAlso HasNote = False Then

                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsExportNativeFormat = DevExpress.Utils.DefaultBoolean.True
                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).XlsxFormatString = "0.0"

                    End If

                End If

            Catch ex As Exception

            End Try

            If (e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse
                    e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal))) AndAlso e.Value IsNot Nothing Then

                If e.Value.GetType.Equals(GetType(System.Int32)) AndAlso e.Value = 0 Then

                    e.Brick.TextValue = Nothing

                ElseIf DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 Then

                    e.Brick.TextValue = Nothing

                End If

            End If

            If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                e.Appearance.BackColor = System.Drawing.Color.LightCyan
                e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

            ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso
                    (e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value OrElse e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total) Then

                e.Appearance.BackColor = System.Drawing.Color.LightCyan
                e.Appearance.BackColor2 = System.Drawing.Color.LightCyan

            End If

            If e.RowValue IsNot Nothing AndAlso e.RowValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

            ElseIf e.ColumnValue IsNot Nothing AndAlso e.ColumnValue.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(155, 200, 230)

            End If

        End Sub
        Private Sub PivotGridControl_SyncedCustomExportFieldValue(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportFieldValueEventArgs)

            'objects
            Dim ColumnHeadingCount As Integer = 0
            Dim NewY As Integer = 0
            Dim HasOnlyOneColumnField As Boolean = False

            If e.Field IsNot Nothing Then

                If e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea OrElse e.Field.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea Then

                    If TypeOf e.Brick Is DevExpress.XtraPrinting.PanelBrick Then

                        DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = False
                        DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).CanPublish = False
                        DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Size = New System.Drawing.Size(0, 0)

                    Else

                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = False
                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).CanPublish = False
                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Size = New System.Drawing.Size(0, 0)

                    End If

                End If

            Else

                If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal Then

                    If TypeOf e.Brick Is DevExpress.XtraPrinting.PanelBrick Then

                        DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = Not e.IsTopMost
                        DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).CanPublish = Not e.IsTopMost

                        If DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).IsVisible = False Then

                            DirectCast(e.Brick, DevExpress.XtraPrinting.PanelBrick).Size = New System.Drawing.Size(0, 0)

                        Else

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

                        End If

                    Else

                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = Not e.IsTopMost
                        DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).CanPublish = Not e.IsTopMost

                        If DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).IsVisible = False Then

                            DirectCast(e.Brick, DevExpress.XtraPrinting.TextBrick).Size = New System.Drawing.Size(0, 0)

                        Else

                            e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub PivotGridControl_CustomExportFieldValue(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportFieldValueEventArgs)

            If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso TypeOf sender Is DevExpress.XtraPivotGrid.PivotGridControl Then

                If e.Field Is Nothing Then

                    e.Appearance.FontStyleDelta = Drawing.FontStyle.Bold

                End If

            End If

        End Sub
        Private Sub PivotGridControl_CustomCellDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellDisplayTextEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim PivotDrillDownDataSource As DevExpress.XtraPivotGrid.PivotDrillDownDataSource = Nothing
            Dim DisplayText As String = ""
            Dim RowIndexes() As Integer = Nothing
            Dim EntryDates() As Date = Nothing

            Try

                If e.ColumnField IsNot Nothing AndAlso e.RowField IsNot Nothing AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value AndAlso
                        e.GetColumnFields.Last Is e.ColumnField AndAlso e.GetRowFields.Last Is e.RowField Then

                    Try

                        PivotDrillDownDataSource = e.CreateDrillDownDataSource

                    Catch ex As Exception
                        PivotDrillDownDataSource = Nothing
                    End Try

                    If PivotDrillDownDataSource IsNot Nothing AndAlso PivotDrillDownDataSource.RowCount > 0 Then

                        Try

                            If PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Any(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "") Then

                                DisplayText = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Where(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) IsNot Nothing AndAlso PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString) <> "").Select(Function(PivotDrillDownDataRow) PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.Note.ToString)).Max()

                            End If

                        Catch ex As Exception
                            DisplayText = ""
                        End Try
                        'DO NOT CHANGE THIS IF STATEMENT IN ANYWAY
                        If String.IsNullOrEmpty(DisplayText) = False Then

                            e.DisplayText = DisplayText

                        Else

                            Try

                                MediaPlanEstimate = sender.Tag

                            Catch ex As Exception
                                MediaPlanEstimate = Nothing
                            End Try

                            If MediaPlanEstimate IsNot Nothing AndAlso (MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithMerge OrElse
                                                                        MediaPlanEstimate.DaysOfWeekType = AdvantageFramework.MediaPlanning.DaysOfWeeksType.OverrideDataWithoutMerge) Then

                                Try

                                    RowIndexes = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CInt(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))).ToArray

                                Catch ex As Exception
                                    RowIndexes = Nothing
                                End Try

                                Try

                                    EntryDates = PivotDrillDownDataSource.OfType(Of DevExpress.XtraPivotGrid.PivotDrillDownDataRow).Select(Function(PivotDrillDownDataRow) CDate(PivotDrillDownDataRow.Item(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))).ToArray

                                Catch ex As Exception
                                    EntryDates = Nothing
                                End Try

                                If RowIndexes IsNot Nothing AndAlso RowIndexes.Count > 0 AndAlso EntryDates IsNot Nothing AndAlso EntryDates.Count > 0 Then

                                    DisplayText = AdvantageFramework.MediaPlanning.CreateDayOfWeeks(MediaPlanEstimate, RowIndexes, EntryDates)

                                    If String.IsNullOrWhiteSpace(DisplayText) = False Then

                                        e.DisplayText = DisplayText

                                    End If

                                End If

                            End If

                        End If

                    End If

                ElseIf e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Total AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        MediaPlanEstimate = sender.Tag

                    Catch ex As Exception
                        MediaPlanEstimate = Nothing
                    End Try

                    If MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.ShowRowTotalsValues = False Then

                        e.DisplayText = String.Empty

                    End If

                ElseIf e.RowValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso e.ColumnValueType = DevExpress.XtraPivotGrid.PivotGridValueType.Value Then

                    Try

                        MediaPlanEstimate = sender.Tag

                    Catch ex As Exception
                        MediaPlanEstimate = Nothing
                    End Try

                    If MediaPlanEstimate IsNot Nothing AndAlso MediaPlanEstimate.ShowRowGrandTotalsValues = False Then

                        e.DisplayText = String.Empty

                    End If

                End If

                If (e.DataField IsNot Nothing AndAlso e.DataField.ActualDataType Is GetType(System.Decimal) OrElse
                        e.DataField.ActualDataType Is GetType(Nullable(Of System.Decimal))) AndAlso e.Value IsNot Nothing Then

                    If e.Value.GetType.Equals(GetType(System.Int32)) AndAlso e.Value = 0 AndAlso String.IsNullOrWhiteSpace(DisplayText) Then

                        e.DisplayText = ""

                    ElseIf DirectCast(e.Value, Nullable(Of Decimal)).GetValueOrDefault(0) = 0 AndAlso String.IsNullOrWhiteSpace(DisplayText) Then

                        e.DisplayText = ""

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub PivotGridControl_CustomFieldSort(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotGridCustomFieldSortEventArgs)

            CustomFieldSort(sender, e)

        End Sub
        Private Sub PivotGridControl_CustomGroupInterval(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomGroupIntervalEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                CustomGroupInterval(sender, e, MediaPlanEstimate.MediaPlan, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_FieldValueDisplayText(sender As Object, e As DevExpress.XtraPivotGrid.PivotFieldDisplayTextEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                FieldValueDisplayText(sender, e, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_CustomUnboundFieldData(sender As Object, e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                CustomUnboundFieldData(sender, e, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_CustomSummary(sender As Object, e As DevExpress.XtraPivotGrid.PivotGridCustomSummaryEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                CustomSummary(sender, e, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_CustomFieldValueCells(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomFieldValueCellsEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                CustomFieldValueCells(sender, e, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_CustomDrawFieldValue(sender As Object, e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs)

            'objects
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing

            Try

                MediaPlanEstimate = sender.Tag

            Catch ex As Exception
                MediaPlanEstimate = Nothing
            End Try

            If MediaPlanEstimate IsNot Nothing Then

                CustomDrawFieldValue(sender, e, MediaPlanEstimate)

            End If

        End Sub
        Private Sub PivotGridControl_CustomExportFieldValueCaptionFix(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.CustomExportFieldValueEventArgs)

            'objects
            Dim ColumnHeadingCount As Integer = 0
            Dim NewY As Integer = 0

            If e.Field Is Nothing Then

                If e.ValueType = DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal AndAlso e.IsColumn Then

                    If DoesPivotGridHaveOnlyOneVisibleDataField(sender) Then

                        For Each PGF In CType(sender, DevExpress.XtraPivotGrid.PivotGridControl).GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)

                            If PGF.Visible AndAlso PGF.Options.ShowGrandTotal AndAlso e.DataField.Caption = PGF.Caption Then

                                e.Brick.Text = " Grand Total" & System.Environment.NewLine & System.Environment.NewLine & " " & PGF.Caption
                                Exit For

                            End If

                        Next

                    End If

                End If

            End If

        End Sub
        Public Sub CreateOutput(ByVal Session As AdvantageFramework.Security.Session, ByVal CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink, ByVal PrintingSystem As DevExpress.XtraPrinting.PrintingSystem,
                                ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                                ByRef FirstPivotGrid As Boolean, ByVal ShowHiatusDates As Boolean, ByVal AddColumnsHeadersToAllEstimates As Boolean)

            'objects
            Dim PivotGridControl As AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl = Nothing
            Dim PrintableComponentLink As DevExpress.XtraPrinting.PrintableComponentLink = Nothing
            Dim PivotGridField As DevExpress.XtraPivotGrid.PivotGridField = Nothing

            _SyncDetailSettings = MediaPlan.SyncDetailSettings
            _AddColumnsHeadersToAllEstimates = AddColumnsHeadersToAllEstimates

            PivotGridControl = New AdvantageFramework.WinForm.Presentation.Controls.PivotGridControl

            PivotGridControl.Tag = MediaPlanEstimate

            AddHandler PivotGridControl.CustomCellDisplayText, AddressOf PivotGridControl_CustomCellDisplayText
            AddHandler PivotGridControl.CustomFieldSort, AddressOf PivotGridControl_CustomFieldSort
            AddHandler PivotGridControl.CustomGroupInterval, AddressOf PivotGridControl_CustomGroupInterval
            AddHandler PivotGridControl.FieldValueDisplayText, AddressOf PivotGridControl_FieldValueDisplayText
            AddHandler PivotGridControl.CustomUnboundFieldData, AddressOf PivotGridControl_CustomUnboundFieldData
            AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_CustomExportFieldValueCaptionFix
            AddHandler PivotGridControl.CustomSummary, AddressOf PivotGridControl_CustomSummary
            AddHandler PivotGridControl.CustomFieldValueCells, AddressOf PivotGridControl_CustomFieldValueCells

            If FirstPivotGrid Then

                AddHandler PivotGridControl.CustomExportCell, AddressOf PivotGridControl_FirstPivotGridCustomExportCell
                AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_CustomExportFieldValue

            Else

                AddHandler PivotGridControl.CustomExportCell, AddressOf PivotGridControl_CustomExportCell

                If MediaPlan.SyncDetailSettings AndAlso AddColumnsHeadersToAllEstimates = False Then

                    AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_SyncedCustomExportFieldValue

                Else

                    AddHandler PivotGridControl.CustomExportFieldValue, AddressOf PivotGridControl_CustomExportFieldValue

                End If

            End If

            PivotGridControl.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click
            PivotGridControl.OptionsCustomization.AllowHideFields = DevExpress.XtraPivotGrid.AllowHideFieldsType.Always
            PivotGridControl.OptionsCustomization.AllowPrefilter = False
            PivotGridControl.OptionsView.ShowColumnTotals = False
            PivotGridControl.OptionsView.ShowFilterHeaders = False
            PivotGridControl.OptionsView.ShowFilterSeparatorBar = False
            PivotGridControl.OptionsView.ShowGrandTotalsForSingleValues = True
            PivotGridControl.OptionsView.ShowRowGrandTotalHeader = False
            PivotGridControl.OptionsView.ShowRowGrandTotals = False
            PivotGridControl.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False
            PivotGridControl.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False
            PivotGridControl.OptionsPrint.PrintHeadersOnEveryPage = True
            PivotGridControl.OptionsPrint.MergeColumnFieldValues = True
            PivotGridControl.OptionsPrint.UsePrintAppearance = True

            If FirstPivotGrid Then

                FirstPivotGrid = False

                PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

            Else

                If MediaPlan.SyncDetailSettings Then

                    If AddColumnsHeadersToAllEstimates Then

                        PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

                    Else

                        PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.False

                    End If

                Else

                    PivotGridControl.OptionsPrint.PrintRowHeaders = DevExpress.Utils.DefaultBoolean.True

                End If

            End If

            PivotGridControl.BeginUpdate()

            SetTotalsOptionsOnPivotGridControl(PivotGridControl, MediaPlanEstimate)

            LoadPivotGrid(Session, PivotGridControl, MediaPlan.DbContext, MediaPlanEstimate)

            'AddDaysOfWeekField(PivotGridControl, MediaPlanEstimate)
            'ShowPackageLevelsField(PivotGridControl, MediaPlanEstimate)
            'ShowDateRangeField(PivotGridControl, MediaPlanEstimate)
            'ShowAdSizesField(PivotGridControl, MediaPlanEstimate)

            If ShowHiatusDates = False Then

                Try

                    PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.Week.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    For Each HiatusDate In MediaPlanEstimate.HiatusWeeks.ToList

                        PivotGridField.FilterValues.Add(HiatusDate)

                    Next

                End If

                Try

                    PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.Month.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    For Each HiatusDate In MediaPlanEstimate.HiatusMonths.ToList

                        PivotGridField.FilterValues.Add(HiatusDate)

                    Next

                End If

                Try

                    PivotGridField = PivotGridControl.Fields(AdvantageFramework.MediaPlanning.DataColumns.MonthName.ToString)

                Catch ex As Exception
                    PivotGridField = Nothing
                End Try

                If PivotGridField IsNot Nothing Then

                    For Each HiatusDate In MediaPlanEstimate.HiatusMonths.ToList

                        PivotGridField.FilterValues.Add(HiatusDate)

                    Next

                End If

            End If

            PivotGridControl.EndUpdate()

            SetExpandedValuesForPivotGrid(PivotGridControl, MediaPlanEstimate)

            PrintableComponentLink = New DevExpress.XtraPrinting.PrintableComponentLink(PrintingSystem)

            PrintableComponentLink.Component = PivotGridControl

            CompositeLink.Links.Add(PrintableComponentLink)

        End Sub
        Public Sub Print(ByVal UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, ByVal Session As AdvantageFramework.Security.Session,
                         ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, ByVal MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate),
                         ByVal ShowHiatusDates As Boolean, ByVal AddRowHeadersToAllEstimates As Boolean)

            'objects
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
            Dim PlanHeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim FooterLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim FirstPivotGrid As Boolean = True
            Dim ImagesList As Generic.List(Of System.Drawing.Image) = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim KeepLoading As Boolean = True

            Try

                PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
                CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP = 1 Then

                            If My.Computer.FileSystem.DirectoryExists(Agency.ImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")

                                End If

                            End If

                            PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = MediaPlan.Description & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                            PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\")
                            PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                            PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                            PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Session, If(String.IsNullOrWhiteSpace(Agency.ImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.ImportPath.Trim, "\") & "Reports\"), MediaPlan.Description))

                            'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                            PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        End If

                    End If

                End Using

                If KeepLoading Then

                    PlanHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                    PlanHeaderLink.Tag = MediaPlan

                    AddHandler PlanHeaderLink.CreateDetailArea, AddressOf PlanHeaderLink_CreateDetailArea

                    CompositeLink.Links.Add(PlanHeaderLink)

                    FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                    AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                    CompositeLink.Links.Add(FooterLink)

                    For Each MediaPlanEstimate In MediaPlanEstimates

                        'ButtonItemShowHideColumnTotals_GrandTotals.Checked = MediaPlanEstimate.ShowColumnGrandTotals
                        'ButtonItemShowHideRowTotals_GrandTotals.Checked = MediaPlanEstimate.ShowRowGrandTotals

                        'ButtonItemShowHideColumnTotals_Totals.Checked = MediaPlanEstimate.ShowColumnTotals
                        'ButtonItemShowHideRowTotals_Totals.Checked = MediaPlanEstimate.ShowRowTotals

                        If MediaPlanEstimate.IsDataLoaded = False Then

                            MediaPlanEstimate.CreateEstimateDataTable()

                        End If

                        HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                        HeaderLink.Tag = MediaPlanEstimate

                        AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

                        CompositeLink.Links.Add(HeaderLink)

                        AdvantageFramework.Media.Presentation.CreateOutput(Session, CompositeLink, PrintingSystem, MediaPlan, MediaPlanEstimate, FirstPivotGrid, ShowHiatusDates, AddRowHeadersToAllEstimates)

                        FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                        AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                        CompositeLink.Links.Add(FooterLink)

                    Next

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ImagesList = New Generic.List(Of System.Drawing.Image)

                        For Each ImageEntity In AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

                            MemoryStream = New System.IO.MemoryStream(ImageEntity.Bytes)

                            ImagesList.Add(System.Drawing.Image.FromStream(MemoryStream))

                            Try

                                MemoryStream.Close()
                                MemoryStream.Dispose()

                                MemoryStream = Nothing

                            Catch ex As Exception
                                MemoryStream = Nothing
                            End Try

                        Next

                    End Using

                    CompositeLink.Landscape = True

                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(MediaPlan.Description)

                    If ImagesList IsNot Nothing Then

                        For Each Image In ImagesList

                            CompositeLink.Images.Add(Image)

                        Next

                    End If

                    'CompositeLink.ShowRibbonPreviewDialog(UserLookAndFeel)

                    MediaPlanPrintingDialog.ShowFormDialog(CompositeLink, False, MediaPlanEstimates, Nothing)

                End If

                If MediaPlan.MediaPlanEstimate IsNot Nothing Then

                    'ButtonItemShowHideColumnTotals_GrandTotals.Checked = MediaPlan.MediaPlanEstimate.ShowColumnGrandTotals
                    'ButtonItemShowHideRowTotals_GrandTotals.Checked = MediaPlan.MediaPlanEstimate.ShowRowGrandTotals

                    'ButtonItemShowHideColumnTotals_Totals.Checked = MediaPlan.MediaPlanEstimate.ShowColumnTotals
                    'ButtonItemShowHideRowTotals_Totals.Checked = MediaPlan.MediaPlanEstimate.ShowRowTotals

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Sub PrintMasterPlan(ByVal UserLookAndFeel As DevExpress.LookAndFeel.UserLookAndFeel, ByVal Session As AdvantageFramework.Security.Session,
                                   ByVal MediaPlanMasterPlanID As Integer, ByVal ShowHiatusDates As Boolean, ByVal AddColumnsHeadersToAllEstimates As Boolean, ByVal GroupByMediaTypes As Boolean)

            'objects
            Dim PrintingSystem As DevExpress.XtraPrinting.PrintingSystem = Nothing
            Dim CompositeLink As DevExpress.XtraPrintingLinks.CompositeLink = Nothing
            Dim MasterPlanHeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim CDPHeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim HeaderLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim FooterLink As AdvantageFramework.Reporting.Reports.CustomLink = Nothing
            Dim FirstPivotGrid As Boolean = True
            Dim ImagesList As Generic.List(Of System.Drawing.Image) = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim AgencyImportPath As String = ""
            Dim DbContext As AdvantageFramework.Database.DbContext = Nothing
            Dim PrevMediaPlanID As Integer = 0
            Dim MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) = Nothing

            Try

                PrintingSystem = New DevExpress.XtraPrinting.PrintingSystem
                CompositeLink = New DevExpress.XtraPrintingLinks.CompositeLink(PrintingSystem)

                DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaPlanMasterPlan = AdvantageFramework.Database.Procedures.MediaPlanMasterPlan.LoadByMediaPlanMasterPlanID(DbContext, MediaPlanMasterPlanID)

                If MediaPlanMasterPlan IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                            If My.Computer.FileSystem.DirectoryExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\") = False Then

                                My.Computer.FileSystem.CreateDirectory(AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")

                            End If

                        End If

                        PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = MediaPlanMasterPlan.Description & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")
                        PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\")
                        PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Session, If(String.IsNullOrWhiteSpace(AgencyImportPath), "", AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\") & "Reports\"), MediaPlanMasterPlan.Description))

                        'PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                        PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                    End If

                    MasterPlanHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                    MasterPlanHeaderLink.Tag = MediaPlanMasterPlan

                    AddHandler MasterPlanHeaderLink.CreateDetailArea, AddressOf MasterPlanHeaderLink_CreateDetailArea

                    CompositeLink.Links.Add(MasterPlanHeaderLink)

                    FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                    AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                    CompositeLink.Links.Add(FooterLink)

                    If GroupByMediaTypes Then

                        MediaPlanEstimates = MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlanID).
                                                                                            Select(Function(ID) New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Session.ConnectionString, Session.UserCode, ID)).
                                                                                            OrderBy(Function(MP) MP.ClientCode).ThenBy(Function(MP) MP.DivisionCode).ThenBy(Function(MP) MP.ProductCode).
                                                                                            SelectMany(Function(MP) MP.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList).
                                                                                            OrderBy(Function(MPE) MPE.SalesClassType).ThenBy(Function(MPE) MPE.MediaPlan.StartDate).ToList


                    Else

                        MediaPlanEstimates = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

                        For Each MediaPlan In MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlanID).Select(Function(ID) New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Session.ConnectionString, Session.UserCode, ID)).OrderBy(Function(MP) MP.StartDate).ToList

                            MediaPlanEstimates.AddRange(MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(MPE) MPE.OrderNumber).ToList)

                        Next

                    End If

                    If GroupByMediaTypes Then

                        For Each MediaPlanEstimate In MediaPlanEstimates

                            CDPHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            CDPHeaderLink.Tag = MediaPlanEstimate

                            AddHandler CDPHeaderLink.CreateDetailArea, AddressOf GroupByMediaTypesHeaderLink_CreateDetailArea

                            CompositeLink.Links.Add(CDPHeaderLink)

                            FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                            CompositeLink.Links.Add(FooterLink)

                            If MediaPlanEstimate.IsDataLoaded = False Then

                                MediaPlanEstimate.CreateEstimateDataTable()

                            End If

                            'HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            'HeaderLink.Tag = MediaPlanEstimate

                            'AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

                            'CompositeLink.Links.Add(HeaderLink)

                            AdvantageFramework.Media.Presentation.CreateOutput(Session, CompositeLink, PrintingSystem, MediaPlanEstimate.MediaPlan, MediaPlanEstimate, FirstPivotGrid, ShowHiatusDates, AddColumnsHeadersToAllEstimates)

                            FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                            CompositeLink.Links.Add(FooterLink)

                        Next

                    Else

                        For Each MediaPlanEstimate In MediaPlanEstimates

                            If PrevMediaPlanID <> MediaPlanEstimate.MediaPlan.ID Then

                                CDPHeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                                CDPHeaderLink.Tag = MediaPlanEstimate.MediaPlan

                                AddHandler CDPHeaderLink.CreateDetailArea, AddressOf CDPHeaderLink_CreateDetailArea

                                CompositeLink.Links.Add(CDPHeaderLink)

                                PrevMediaPlanID = MediaPlanEstimate.MediaPlan.ID

                                FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                                AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                                CompositeLink.Links.Add(FooterLink)

                            End If

                            If MediaPlanEstimate.IsDataLoaded = False Then

                                MediaPlanEstimate.CreateEstimateDataTable()

                            End If

                            HeaderLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            HeaderLink.Tag = MediaPlanEstimate

                            AddHandler HeaderLink.CreateDetailArea, AddressOf HeaderLink_CreateDetailArea

                            CompositeLink.Links.Add(HeaderLink)

                            AdvantageFramework.Media.Presentation.CreateOutput(Session, CompositeLink, PrintingSystem, MediaPlanEstimate.MediaPlan, MediaPlanEstimate, FirstPivotGrid, ShowHiatusDates, AddColumnsHeadersToAllEstimates)

                            FooterLink = New AdvantageFramework.Reporting.Reports.CustomLink

                            AddHandler FooterLink.CreateDetailArea, AddressOf FooterLink_CreateDetailArea

                            CompositeLink.Links.Add(FooterLink)

                        Next

                    End If

                    ImagesList = New Generic.List(Of System.Drawing.Image)

                    For Each ImageEntity In AdvantageFramework.Database.Procedures.Image.Load(DbContext).ToList

                        MemoryStream = New System.IO.MemoryStream(ImageEntity.Bytes)

                        ImagesList.Add(System.Drawing.Image.FromStream(MemoryStream))

                        Try

                            MemoryStream.Close()
                            MemoryStream.Dispose()

                            MemoryStream = Nothing

                        Catch ex As Exception
                            MemoryStream = Nothing
                        End Try

                    Next

                End If

                If MediaPlanMasterPlan IsNot Nothing Then

                    CompositeLink.Landscape = True

                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultSendFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXls
                    CompositeLink.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = AdvantageFramework.FileSystem.CreateValidFileName(MediaPlanMasterPlan.Description)

                    If ImagesList IsNot Nothing Then

                        For Each Image In ImagesList

                            CompositeLink.Images.Add(Image)

                        Next

                    End If

                    MediaPlanPrintingDialog.ShowFormDialog(CompositeLink, True, MediaPlanEstimates, DbContext)

                End If

            Catch ex As Exception

            End Try

            Try

                If DbContext IsNot Nothing Then

                    DbContext.Dispose()
                    DbContext = Nothing

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub MasterPlanHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim VeritcalLocation As Integer = 0
            Dim MediaPlanMasterPlan As AdvantageFramework.Database.Entities.MediaPlanMasterPlan = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim BillingTotal As Decimal = 0
            Dim GrossBudgetAmount As Decimal = 0

            Try

                MediaPlanMasterPlan = CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag

            Catch ex As Exception
                MediaPlanMasterPlan = Nothing
            End Try

            If MediaPlanMasterPlan IsNot Nothing Then

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = MediaPlanMasterPlan.Description

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    StartDate = MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlan.StartDate).Min

                Catch ex As Exception
                    StartDate = Now
                End Try

                Try

                    EndDate = MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlan.EndDate).Max

                Catch ex As Exception
                    EndDate = Now
                End Try

                Try

                    For Each MediaPlan In MediaPlanMasterPlan.MediaPlanMasterPlanDetails.Select(Function(Entity) Entity.MediaPlan).ToList

                        GrossBudgetAmount += MediaPlan.GrossBudgetAmount.GetValueOrDefault(0)

                        BillingTotal += MediaPlan.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                    Next

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Start Date: " & StartDate.ToShortDateString

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "End Date: " & EndDate.ToShortDateString

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Budget: " & FormatCurrency(GrossBudgetAmount)

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Billing Total: " & FormatCurrency(BillingTotal)

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(MediaPlanMasterPlan.Comment) = False Then

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & MediaPlanMasterPlan.Comment)

                    Else

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "")

                    End If

                    e.Graph.DrawBrick(TextBrick)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub CDPHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim VeritcalLocation As Integer = 0
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing

            Try

                MediaPlan = CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag

            Catch ex As Exception
                MediaPlan = Nothing
            End Try

            If MediaPlan IsNot Nothing Then

                Try


                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(MediaPlan.DbContext, MediaPlan.ClientCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(MediaPlan.DbContext, MediaPlan.ClientCode, MediaPlan.DivisionCode)

                    Product = MediaPlan.Product

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = MediaPlan.Description

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Client: " & Client.Name

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Division: " & If(Division IsNot Nothing, Division.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Product: " & If(Product IsNot Nothing, Product.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub PlanHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim BillingTotal As Decimal = 0
            Dim VeritcalLocation As Integer = 0
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing

            Try

                MediaPlan = CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag

            Catch ex As Exception
                MediaPlan = Nothing
            End Try

            If MediaPlan IsNot Nothing Then

                Try


                    ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(MediaPlan.DbContext, MediaPlan.ClientContactID.GetValueOrDefault(0))

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(MediaPlan.DbContext, MediaPlan.ClientCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(MediaPlan.DbContext, MediaPlan.ClientCode, MediaPlan.DivisionCode)

                    Product = MediaPlan.Product

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = MediaPlan.Description

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Client: " & Client.Name

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Division: " & If(Division IsNot Nothing, Division.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Product: " & If(Product IsNot Nothing, Product.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    If ClientContact IsNot Nothing Then

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                        TextBrick.Text = "Client Contact: " & ClientContact.ToString

                        e.Graph.DrawBrick(TextBrick)

                        VeritcalLocation += 15

                    End If

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Start Date: " & MediaPlan.StartDate.ToShortDateString

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "End Date: " & MediaPlan.EndDate.ToShortDateString

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Budget: " & FormatCurrency(MediaPlan.GrossBudgetAmount.GetValueOrDefault(0))

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    For Each MediaPlanEstimate In MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)()

                        BillingTotal += MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.BillAmount.GetValueOrDefault(0)).Sum

                    Next

                    TextBrick.Text = "Billing Total: " & FormatCurrency(BillingTotal)

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Variance: " & FormatCurrency(MediaPlan.GrossBudgetAmount.GetValueOrDefault(0) - BillingTotal)

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(MediaPlan.Comment) = False Then

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & MediaPlan.Comment)

                    Else

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "")

                    End If

                    e.Graph.DrawBrick(TextBrick)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub GroupByMediaTypesHeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim VeritcalLocation As Integer = 0
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing

            Try

                MediaPlan = CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).MediaPlan

            Catch ex As Exception
                MediaPlan = Nothing
            End Try

            If MediaPlan IsNot Nothing Then

                Try


                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(MediaPlan.DbContext, MediaPlan.ClientCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(MediaPlan.DbContext, MediaPlan.ClientCode, MediaPlan.DivisionCode)

                    Product = MediaPlan.Product

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = MediaPlan.Description

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Client: " & Client.Name

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Division: " & If(Division IsNot Nothing, Division.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = "Product: " & If(Product IsNot Nothing, Product.Name, "")

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, 15)

                    TextBrick.Text = CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Name

                    e.Graph.DrawBrick(TextBrick)

                    VeritcalLocation += 15

                Catch ex As Exception

                End Try

                Try

                    If String.IsNullOrWhiteSpace(CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes) = False Then

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes)

                    Else

                        TextBrick = CreateTextBrick(0, VeritcalLocation, e.Graph.ClientPageSize.Width, e.Graph, "")

                    End If

                    e.Graph.DrawBrick(TextBrick)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub HeaderLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            Try

                TextBrick = CreateTextBrick(0, 0, e.Graph.ClientPageSize.Width, 15)

                TextBrick.Text = CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Name

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrWhiteSpace(CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes) = False Then

                    TextBrick = CreateTextBrick(0, 15, e.Graph.ClientPageSize.Width, e.Graph, "Comment: " & CType(CType(sender, AdvantageFramework.Reporting.Reports.CustomLink).Tag, AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).Notes)

                Else

                    TextBrick = CreateTextBrick(0, 15, e.Graph.ClientPageSize.Width, e.Graph, "")

                End If

                e.Graph.DrawBrick(TextBrick)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FooterLink_CreateDetailArea(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.CreateAreaEventArgs)

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(0, 0, e.Graph.ClientPageSize.Width, 15)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

            TextBrick.Text = ""

            e.Graph.DrawBrick(TextBrick)

        End Sub
        Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal BrickGraphics As DevExpress.XtraPrinting.BrickGraphics,
                                 ByVal OutputString As String) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing

            SizeF = BrickGraphics.MeasureString(OutputString, Width)

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, CInt(SizeF.Height))
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

            TextBrick.Text = OutputString

            CreateTextBrick = TextBrick

        End Function
        Private Function CreateTextBrick(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As DevExpress.XtraPrinting.TextBrick

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing

            TextBrick = New DevExpress.XtraPrinting.TextBrick

            TextBrick.Rect = New System.Drawing.Rectangle(X, Y, Width, Height)
            TextBrick.BackColor = System.Drawing.Color.White
            TextBrick.BorderWidth = 0
            TextBrick.BorderStyle = DevExpress.XtraPrinting.BrickBorderStyle.Inset
            TextBrick.Font = New System.Drawing.Font("Tahoma", TextBrick.Font.Size)

            CreateTextBrick = TextBrick

        End Function
        Public Function CreateFileName(UserCode As String, OrderNumber As Integer) As String

            'objects
            Dim FileName As String = ""

            FileName = Format(OrderNumber, "00000000#") & "_" & UserCode

            CreateFileName = FileName

        End Function
        Public Function CreateFileName(ClientName As String, VendorName As String, UserCode As String, OrderNumber As Integer) As String

            'objects
            Dim FileName As String = ""

            FileName = ClientName & "_" & VendorName & "_" & Format(OrderNumber, "00000000#") & "_" & UserCode

            CreateFileName = FileName

        End Function
        Public Function CheckForOpenMediaPlan(MdiParent As Windows.Forms.Form, MediaPlanID As Integer, MediaPlanDetailID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is AdvantageFramework.Media.Presentation.MediaPlanEditForm Then

                        If DirectCast(MdiChildForm, AdvantageFramework.Media.Presentation.MediaPlanEditForm).MediaPlanID = MediaPlanID Then

                            If MediaPlanDetailID <> 0 AndAlso DirectCast(MdiChildForm, AdvantageFramework.Media.Presentation.MediaPlanEditForm).MediaPlanEstimateID = MediaPlanDetailID Then

                                MdiChildForm.Activate()

                                IsOpened = True
                                Exit For

                            End If

                            'If IsUpdatingMediaPlan Then

                            '    DirectCast(MdiChildForm, AdvantageFramework.Media.Presentation.MediaPlanEditForm).OpenMediaPlanUpdate()

                            'ElseIf MediaPlanDetailID <> 0 Then

                            '    DirectCast(MdiChildForm, AdvantageFramework.Media.Presentation.MediaPlanEditForm).OpenEstimate(MediaPlanDetailID)

                            'End If

                        End If

                    End If

                Next

            End If

            CheckForOpenMediaPlan = IsOpened

        End Function
        Public Function CheckForOpenWorksheet(MdiParent As Windows.Forms.Form, SelectedWorksheetID As Integer, SelectedWorksheetMarketID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False
            Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing

            MediaBroadcastWorksheetMarketDetailForm = GetOpenWorksheetForm(MdiParent, SelectedWorksheetID, SelectedWorksheetMarketID)

            If MediaBroadcastWorksheetMarketDetailForm IsNot Nothing Then

                MediaBroadcastWorksheetMarketDetailForm.Activate()

                IsOpened = True

            End If

            CheckForOpenWorksheet = IsOpened

        End Function
        Public Function GetOpenWorksheetForm(MdiParent As Windows.Forms.Form, SelectedWorksheetID As Integer, SelectedWorksheetMarketID As Integer) As MediaBroadcastWorksheetMarketDetailForm

            'objects
            Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is MediaBroadcastWorksheetMarketDetailForm Then

                        If DirectCast(MdiChildForm, MediaBroadcastWorksheetMarketDetailForm).MediaBroadcastWorksheetID = SelectedWorksheetID AndAlso
                                DirectCast(MdiChildForm, MediaBroadcastWorksheetMarketDetailForm).MediaBroadcastWorksheetMarketID = SelectedWorksheetMarketID Then

                            MediaBroadcastWorksheetMarketDetailForm = MdiChildForm

                            Exit For

                        End If

                    End If

                Next

            End If

            GetOpenWorksheetForm = MediaBroadcastWorksheetMarketDetailForm

        End Function
        Public Function IsAnyWorksheetMarketOpen(MdiParent As Windows.Forms.Form, SelectedWorksheetID As Integer) As Boolean

            'objects
            Dim MediaBroadcastWorksheetMarketDetailForm As MediaBroadcastWorksheetMarketDetailForm = Nothing
            Dim IsOpen As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is MediaBroadcastWorksheetMarketDetailForm Then

                        If DirectCast(MdiChildForm, MediaBroadcastWorksheetMarketDetailForm).MediaBroadcastWorksheetID = SelectedWorksheetID Then

                            IsOpen = True

                            Exit For

                        End If

                    End If

                Next

            End If

            IsAnyWorksheetMarketOpen = IsOpen

        End Function
        Public Function IsMediaPlanDetailCalendarMonth(ByVal DbContext As AdvantageFramework.Database.DbContext, MediaPlanDetailID As Integer) As Boolean

            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim IsCalendarMonth As Boolean = False

            MediaPlanDetail = AdvantageFramework.Database.Procedures.MediaPlanDetail.LoadByMediaPlanDetailID(DbContext, MediaPlanDetailID)

            If MediaPlanDetail IsNot Nothing Then

                IsCalendarMonth = MediaPlanDetail.IsCalendarMonth

            End If

            IsMediaPlanDetailCalendarMonth = IsCalendarMonth

        End Function
        Public Sub SetBroadcastMonthYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= MediaPlanningData.StartDate
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    MediaPlanningData.Month = BroadcastCalendarWeek.Month
                    MediaPlanningData.Year = BroadcastCalendarWeek.Year

                End If

            End If

        End Sub
        Public Sub SetBroadcastQuarterYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= MediaPlanningData.StartDate
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    Select Case BroadcastCalendarWeek.Month

                        Case 1, 2, 3

                            MediaPlanningData.Quarter = 1

                        Case 4, 5, 6

                            MediaPlanningData.Quarter = 2

                        Case 7, 8, 9

                            MediaPlanningData.Quarter = 3

                        Case 10, 11, 12

                            MediaPlanningData.Quarter = 4

                    End Select

                    MediaPlanningData.Year = BroadcastCalendarWeek.Year

                End If

            End If

        End Sub
        Public Sub SetBroadcastWeekYearForDate(ByVal BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek), ByVal MediaPlanningData As AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

            Dim MaxWeekDate As Nullable(Of Date) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            MaxWeekDate = (From Dates In BroadcastCalendarWeeks
                           Where Dates.WeekDate <= MediaPlanningData.StartDate
                           Select Dates.WeekDate).Max

            If MaxWeekDate IsNot Nothing Then

                BroadcastCalendarWeek = (From Dates In BroadcastCalendarWeeks
                                         Where Dates.WeekDate = MaxWeekDate).SingleOrDefault

                If BroadcastCalendarWeek IsNot Nothing Then

                    MediaPlanningData.Year = BroadcastCalendarWeek.Year

                End If

            End If

        End Sub
        Public Function GetImportOrderList(Session As AdvantageFramework.Security.Session, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, DataFilter As AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData,
                                           OrderGroupingLevelLinesDataTable As System.Data.DataTable, MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData),
                                           EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings, CreateOrderBroadcastCalendarType As AdvantageFramework.MediaPlanning.CreateOrderBroadcastCalendarType
                                           ) As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

            Dim ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder) = Nothing
            Dim IsCalendarMonth As Boolean = False
            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim MediaPlanningDatas As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData) = Nothing
            Dim MediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings = Nothing
            Dim Package As String = String.Empty

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.Connection.Open()

                IsCalendarMonth = AdvantageFramework.Media.Presentation.IsMediaPlanDetailCalendarMonth(DbContext, CType(DataFilter, AdvantageFramework.Exporting.DataFilterClasses.MediaPlanningData).EstimateID)

                BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

                ImportOrderList = New Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder)

                For Each DataRow In OrderGroupingLevelLinesDataTable.Select

                    MediaPlanningDatas = MediaPlanningDataList.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                    If DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) > 0 Then

                        MediaPlanOrderGrouping = DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)

                    Else

                        MediaPlanOrderGrouping = EstimateMediaPlanOrderGrouping

                    End If

                    Select Case MediaPlanOrderGrouping

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.FullFlight

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildFullFlightOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter))

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByDay

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildDayOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter, CreateOrderBroadcastCalendarType))

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByMonth

                            If Not IsCalendarMonth Then

                                For Each MediaPlanningData In MediaPlanningDatas

                                    AdvantageFramework.Media.Presentation.SetBroadcastMonthYearForDate(BroadcastCalendarWeeks, MediaPlanningData)

                                Next

                            End If

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildMonthOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter, CreateOrderBroadcastCalendarType, BroadcastCalendarWeeks))

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByQuarter

                            If Not IsCalendarMonth Then

                                For Each MediaPlanningData In MediaPlanningDatas

                                    AdvantageFramework.Media.Presentation.SetBroadcastQuarterYearForDate(BroadcastCalendarWeeks, MediaPlanningData)

                                Next

                            End If

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildQuarterOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter, CreateOrderBroadcastCalendarType, BroadcastCalendarWeeks))

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.ByWeek

                            If Not IsCalendarMonth Then

                                For Each MediaPlanningData In MediaPlanningDatas

                                    AdvantageFramework.Media.Presentation.SetBroadcastWeekYearForDate(BroadcastCalendarWeeks, MediaPlanningData)

                                Next

                            End If

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildWeekOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter, CreateOrderBroadcastCalendarType, BroadcastCalendarWeeks))

                        Case AdvantageFramework.Exporting.MediaPlanOrderGroupings.Period

                            ImportOrderList.AddRange(AdvantageFramework.MediaPlanning.BuildPeriodOrderList(MediaPlan, MediaPlanningDatas, Session, DataFilter))

                    End Select

                Next

                For Each RowIndex In ImportOrderList.Select(Function(Entity) Entity.MediaPlanRowIndex).Distinct

                    'ParentPackage = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageParent.ToString)
                    Package = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)

                    For Each ImportOrder In ImportOrderList.Where(Function(Entity) Entity.MediaPlanRowIndex = RowIndex)

                        'ImportOrder.MediaPlanParentPackage = ParentPackage
                        ImportOrder.MediaPlanPackage = Package

                    Next

                Next

                DbContext.Database.Connection.Close()

            End Using

            GetImportOrderList = ImportOrderList

        End Function
        Public Function MediaPlanCreateOrders(ImportOrderList As Generic.List(Of AdvantageFramework.Media.Classes.ImportOrder), CreateOrderOption As AdvantageFramework.MediaPlanning.CreateOrderOptions,
                                              MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings,
                                              MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData), OrderGroupingLevelLinesDataTable As System.Data.DataTable
                                              ) As Boolean

            Dim Created As Boolean = False
            Dim MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail = Nothing
            Dim MediaPlanDetailLevelLineDataIDs() As Integer = Nothing
            Dim DataRow As System.Data.DataRow = Nothing

            If ImportOrderList.Count > 0 Then

                If AdvantageFramework.Importing.Presentation.ImportCreateOrderDialog.ShowFormDialog(ImportOrderList, CreateOrderOption, False) = Windows.Forms.DialogResult.OK Then

                    MediaPlan.Refresh(MediaPlan.MediaPlanEstimate.ID, False)

                    MediaPlanDetail = MediaPlan.MediaPlanEstimate.GetEntity

                    If MediaPlanDetail IsNot Nothing Then

                        MediaPlanDetail.OrderGrouping = EstimateMediaPlanOrderGrouping

                        MediaPlanDetail.CreateOrderOption = CreateOrderOption

                        MediaPlan.DbContext.UpdateObject(MediaPlanDetail)

                        Try

                            MediaPlanDetailLevelLineDataIDs = MediaPlanningDataList.Select(Function(Entity) Entity.MediaPlanDetailLevelLineDataID).Distinct.ToArray

                        Catch ex As Exception
                            MediaPlanDetailLevelLineDataIDs = Nothing
                        End Try

                        If MediaPlanDetailLevelLineDataIDs IsNot Nothing Then

                            For Each MediaPlanDetailLevelLineData In MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) MediaPlanDetailLevelLineDataIDs.Contains(Entity.ID) = True).ToList

                                If MediaPlanDetailLevelLineData.OrderNumber IsNot Nothing Then

                                    MediaPlanDetailLevelLineData.HasPendingOrders = True

                                    MediaPlan.DbContext.UpdateObject(MediaPlanDetailLevelLineData)

                                End If

                            Next

                            For Each RowIndex In MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) MediaPlanDetailLevelLineDataIDs.Contains(Entity.ID) = True AndAlso
                                                                                                                                                       Entity.HasPendingOrders = True).Select(Function(Entity) Entity.RowIndex).Distinct.ToList

                                DataRow = OrderGroupingLevelLinesDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex) = RowIndex)

                                If DataRow IsNot Nothing Then

                                    For Each MediaPlanDetailLevelLine In MediaPlanDetail.MediaPlanDetailLevelLines.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex)).ToList

                                        If DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString) = 0 Then

                                            MediaPlanDetailLevelLine.OrderGrouping = EstimateMediaPlanOrderGrouping

                                        Else

                                            MediaPlanDetailLevelLine.OrderGrouping = DataRow(AdvantageFramework.MediaPlanning.OrderGroupingLevelLinesColumns.GroupBy.ToString)

                                        End If

                                        MediaPlan.DbContext.UpdateObject(MediaPlanDetailLevelLine)

                                    Next

                                End If

                            Next

                        End If

                        Try

                            MediaPlan.DbContext.SaveChanges()

                            Created = True

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("No Orders to create.")

            End If

            MediaPlanCreateOrders = Created

        End Function
        Public Function OkayToCreateMediaPlanOrders(DataTable As System.Data.DataTable, OrderGroupingLevelLinesDataTable As System.Data.DataTable,
                                                    EstimateMediaPlanOrderGrouping As AdvantageFramework.Exporting.MediaPlanOrderGroupings,
                                                    ByRef MediaPlanningDataList As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData), ByRef ErrorMessage As String) As Boolean

            Dim IsOkay As Boolean = True
            Dim ExportDataSourceRows() As System.Data.DataRow = Nothing

            ExportDataSourceRows = DataTable.Select()

            Try

                MediaPlanningDataList = AdvantageFramework.Exporting.ConvertExportDataSourceToIEnumerable(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData)(AdvantageFramework.Exporting.ExportTypes.MediaPlanData, ExportDataSourceRows)

            Catch ex As Exception
                MediaPlanningDataList = Nothing
            End Try

            If MediaPlanningDataList IsNot Nothing AndAlso MediaPlanningDataList.Count > 0 Then

                MediaPlanningDataList = MediaPlanningDataList.OrderBy(Function(MPA) MPA.MediaTypeCode).ThenBy(Function(MPA) MPA.SalesClassCode).ThenBy(Function(MPA) MPA.VendorCode).ToList

                IsOkay = AdvantageFramework.MediaPlanning.ValidateGroupingFieldsHaveData(MediaPlanningDataList, OrderGroupingLevelLinesDataTable, EstimateMediaPlanOrderGrouping, ErrorMessage)

                If Not IsOkay Then

                    'Me.FormAction = WinForm.Presentation.FormActions.None
                    'Me.CloseWaitForm()

                    If AdvantageFramework.WinForm.MessageBox.Show("Some rows in this estimate do not include a vendor.  Rows without a vendor will not be included when orders are created.  Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.OKCancel) = WinForm.MessageBox.DialogResults.OK Then

                        IsOkay = True

                        'Me.FormAction = WinForm.Presentation.FormActions.Loading
                        'Me.ShowWaitForm("Loading...")

                    End If

                End If

            Else

                ErrorMessage = "No Orders to create."

                IsOkay = False

            End If

            OkayToCreateMediaPlanOrders = IsOkay

        End Function
        Public Sub SetDigitalEstimateDetailSummaryColumns(DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView)

            DataGridView.CurrentView.OptionsView.ShowFooter = True

            If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString) IsNot Nothing Then

                If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.OrigPlanSpend.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString) IsNot Nothing Then

                If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.PlanSpend.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualSpend.ToString) IsNot Nothing Then

                If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualSpend.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualSpend.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.ActualSpend.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

            If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.RemainingSpend.ToString) IsNot Nothing Then

                If DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.RemainingSpend.ToString).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.RemainingSpend.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    DataGridView.Columns(AdvantageFramework.DTO.Media.DigitalCampaignManager.DigitalEstimateDetail.Properties.RemainingSpend.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                End If

            End If

        End Sub
        Public Function GetDataColumnFromPeriodType(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As AdvantageFramework.MediaPlanning.DataColumns

            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = Nothing

            If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                DataColumn = MediaPlanning.Methods.DataColumns.Month

            ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                DataColumn = MediaPlanning.Methods.DataColumns.Week

            ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                DataColumn = MediaPlanning.Methods.DataColumns.Day

            ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                DataColumn = MediaPlanning.Methods.DataColumns.Week

            End If

            GetDataColumnFromPeriodType = DataColumn

        End Function
        Public Function AllocateBudget(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, _RowIndex As Integer, Dollars As Decimal, FromDate As Date, ToDate As Date,
                                       DataColumn As AdvantageFramework.MediaPlanning.DataColumns, Update As Boolean, AddMissingDates As Boolean) As Generic.List(Of Date)

            'objects
            Dim Color As Integer = 0
            Dim StartDatesList As Generic.List(Of Date) = Nothing
            Dim FromDateDay As Integer = 1
            Dim FromDateMonth As Integer = 1
            Dim FromDateYear As Integer = 1
            Dim DateDifferenceCount As Integer = 0
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DataEntryMediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            DataEntryMediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData
            DataEntryMediaPlanDetailLevelLineData.Dollars = Dollars

            Try

                Color = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = _RowIndex).Select(Function(Entity) Entity.Color).Max

            Catch ex As Exception
                Color = 0
            End Try

            StartDatesList = New Generic.List(Of Date)

            FromDateDay = FromDate.Day

            If (MediaPlan.MediaPlanEstimate.SalesClassType <> "R" AndAlso MediaPlan.MediaPlanEstimate.SalesClassType <> "T") AndAlso
                    MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month AndAlso
                    FromDate.Day <> 1 Then

                Do Until FromDate >= ToDate

                    If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                        StartDatesList.Add(FromDate)

                    End If

                    If FromDate.Month = 12 Then

                        FromDateMonth = 1
                        FromDateYear = FromDate.Year + 1

                    Else

                        FromDateMonth = FromDate.Month + 1
                        FromDateYear = FromDate.Year

                    End If

                    If Date.DaysInMonth(FromDateYear, FromDateMonth) < FromDateDay Then

                        FromDate = New Date(FromDateYear, FromDateMonth, Date.DaysInMonth(FromDateYear, FromDateMonth))

                    Else

                        FromDate = New Date(FromDateYear, FromDateMonth, FromDateDay)

                    End If

                Loop

            Else

                If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                    StartDatesList.Add(FromDate)

                End If

                FromDate = FromDate.AddDays(1)

                Do While FromDate < ToDate.AddDays(1)

                    If DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                        If MediaPlan.MediaPlanEstimate.GetYear(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetYear(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                StartDatesList.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                        If MediaPlan.MediaPlanEstimate.GetQuarter(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetQuarter(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                StartDatesList.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                            DataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                        If MediaPlan.MediaPlanEstimate.GetMonth(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetMonth(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                StartDatesList.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                        If MediaPlan.MediaPlanEstimate.GetWeek(FromDate.AddDays(-1)) <> MediaPlan.MediaPlanEstimate.GetWeek(FromDate) Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                StartDatesList.Add(FromDate)

                            End If

                        End If

                    ElseIf DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day OrElse DataColumn = AdvantageFramework.MediaPlanning.DataColumns.Date Then

                        If FromDate.AddDays(-1).Day <> FromDate.Day Then

                            If MediaPlan.MediaPlanEstimate.IsOnHiatusDate(FromDate) = False Then

                                StartDatesList.Add(FromDate)

                            End If

                        End If

                    End If

                    FromDate = FromDate.AddDays(1)

                Loop

            End If

            MediaPlan.MediaPlanEstimate.SaveHiatusMonths()
            MediaPlan.MediaPlanEstimate.SaveHiatusWeeks()

            DateDifferenceCount = StartDatesList.Count

            For Each StartDate In StartDatesList

                Try

                    MediaPlanDetailLevelLineData = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = _RowIndex AndAlso Entity.StartDate = StartDate)

                Catch ex As Exception
                    MediaPlanDetailLevelLineData = Nothing
                End Try

                If MediaPlanDetailLevelLineData Is Nothing AndAlso AddMissingDates Then

                    MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                    MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, StartDate, _RowIndex)

                    If MediaPlan.MediaPlanEstimate.PeriodType <> AdvantageFramework.MediaPlanning.PeriodTypes.None Then

                        If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                            MediaPlanDetailLevelLineData.EndDate = MediaPlan.MediaPlanEstimate.GetLastDayOfWeek(StartDate)

                        ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month Then

                            If FromDateDay = 1 Then

                                MediaPlanDetailLevelLineData.EndDate = MediaPlan.MediaPlanEstimate.GetLastDayOfMonth(StartDate)

                            Else

                                If StartDate.Month = 12 Then

                                    FromDateMonth = 1
                                    FromDateYear = StartDate.Year + 1

                                Else

                                    FromDateMonth = StartDate.Month + 1
                                    FromDateYear = StartDate.Year

                                End If

                                If Date.DaysInMonth(FromDateYear, FromDateMonth) < FromDateDay Then

                                    MediaPlanDetailLevelLineData.EndDate = New Date(FromDateYear, FromDateMonth, Date.DaysInMonth(FromDateYear, FromDateMonth) - 1)

                                Else

                                    MediaPlanDetailLevelLineData.EndDate = New Date(FromDateYear, FromDateMonth, FromDateDay - 1)

                                End If

                            End If

                        ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                            MediaPlanDetailLevelLineData.EndDate = StartDate.AddDays(27)

                        End If

                        If MediaPlanDetailLevelLineData.EndDate > MediaPlan.EndDate Then

                            MediaPlanDetailLevelLineData.EndDate = MediaPlan.EndDate

                        End If

                    End If

                    MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                    'MediaPlanDetailLevelLineData.Sunday = DataEntryMediaPlanDetailLevelLineData.Sunday
                    'MediaPlanDetailLevelLineData.Monday = DataEntryMediaPlanDetailLevelLineData.Monday
                    'MediaPlanDetailLevelLineData.Tuesday = DataEntryMediaPlanDetailLevelLineData.Tuesday
                    'MediaPlanDetailLevelLineData.Wednesday = DataEntryMediaPlanDetailLevelLineData.Wednesday
                    'MediaPlanDetailLevelLineData.Thursday = DataEntryMediaPlanDetailLevelLineData.Thursday
                    'MediaPlanDetailLevelLineData.Friday = DataEntryMediaPlanDetailLevelLineData.Friday
                    'MediaPlanDetailLevelLineData.Saturday = DataEntryMediaPlanDetailLevelLineData.Saturday

                    If Color = 0 Then

                        Color = MediaPlan.MediaPlanEstimate.Color

                    End If

                    MediaPlanDetailLevelLineData.Color = Color

                    If Update = False Then

                        AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, DateDifferenceCount)

                    Else

                        AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

                    End If

                ElseIf MediaPlanDetailLevelLineData IsNot Nothing Then

                    If Update = False Then

                        AdvantageFramework.MediaPlanning.AllocateDataOnMediaPlanDetailLevelLineData(MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData, DateDifferenceCount)

                    Else

                        AdvantageFramework.MediaPlanning.UpdateDataOnMediaPlanDetailLevelLineData(MediaPlan, MediaPlanDetailLevelLineData, DataEntryMediaPlanDetailLevelLineData)

                    End If

                End If

            Next

            AllocateBudget = StartDatesList

        End Function
        Public Sub BalanceBudgetDollars(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToDollars As Decimal)

            Dim TotalDollars As Decimal = 0
            Dim TotalRowCount As Integer = 0
            Dim UpdateAmount As Decimal = 0

            TotalDollars = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                      DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Sum(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)))

            TotalRowCount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                            DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Count

            UpdateAmount = FormatNumber((BalanceToDollars - TotalDollars) / TotalRowCount, 2)

            If Math.Abs(UpdateAmount) < 1 Then

                BalanceBudgetDollarsMicro(MediaPlan, RowIndex, BalanceToDollars)

            Else

                BalanceBudgetDollarsMacro(MediaPlan, RowIndex, BalanceToDollars)

            End If

        End Sub
        Private Sub BalanceBudgetDollarsMicro(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToDollars As Decimal)

            Dim RowIndexes As IEnumerable(Of Integer) = Nothing
            Dim TotalDollars As Decimal = 0

            TotalDollars = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                   DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))).Sum()

            If TotalDollars < BalanceToDollars Then

                Do Until TotalDollars = BalanceToDollars

                    For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                                DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderBy(Function(DR) DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))

                        DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) += 0.01

                        TotalDollars += 0.01

                        If TotalDollars = BalanceToDollars Then

                            Exit For

                        End If

                    Next

                Loop

            ElseIf TotalDollars > BalanceToDollars Then

                Do Until TotalDollars = BalanceToDollars

                    For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                                DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderByDescending(Function(DR) DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))

                        DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) -= 0.01

                        TotalDollars -= 0.01

                        If TotalDollars = BalanceToDollars Then

                            Exit For

                        End If

                    Next

                Loop

            End If

        End Sub
        Private Sub BalanceBudgetDollarsMacro(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToDollars As Decimal)

            Dim TotalDollars As Decimal = 0
            Dim TotalRowCount As Integer = 0
            Dim UpdateAmount As Decimal = 0
            Dim Remainder As Decimal = 0
            Dim RowCount As Integer = 0

            TotalDollars = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                   DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Select(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))).Sum()

            TotalRowCount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                   DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Count

            If TotalDollars < BalanceToDollars Then

                UpdateAmount = FormatNumber((BalanceToDollars - TotalDollars) / TotalRowCount, 2)

                Remainder = FormatNumber(TotalDollars - (UpdateAmount * TotalRowCount), 2)

                'Do Until TotalDollars = BalanceToDollars

                For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                            DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderBy(Function(DR) DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))

                    RowCount += 1

                    DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) += UpdateAmount

                    TotalDollars += UpdateAmount

                    If RowCount = TotalRowCount AndAlso TotalDollars <> BalanceToDollars Then

                        If TotalDollars < BalanceToDollars Then

                            DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) += (BalanceToDollars - TotalDollars)

                        Else

                            DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) += (TotalDollars - BalanceToDollars)

                        End If

                    End If
                    'DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) += 0.01

                    'TotalDollars += 0.01

                    'If TotalDollars = BalanceToDollars Then

                    '    Exit For

                    'End If

                Next

                'Loop

            ElseIf TotalDollars > BalanceToDollars Then

                UpdateAmount = FormatNumber((TotalDollars - BalanceToDollars) / TotalRowCount, 2)

                Remainder = FormatNumber(TotalDollars - (UpdateAmount * TotalRowCount), 2)

                'Do Until TotalDollars = BalanceToDollars

                For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.Dollars.ToString)) = False AndAlso
                                                                                                                            DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderByDescending(Function(DR) DR(MediaPlanning.Methods.DataColumns.Dollars.ToString))

                    RowCount += 1

                    DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) -= UpdateAmount

                    TotalDollars -= UpdateAmount

                    If RowCount = TotalRowCount AndAlso TotalDollars <> BalanceToDollars Then

                        If TotalDollars < BalanceToDollars Then

                            DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) -= (BalanceToDollars - TotalDollars)

                        Else

                            DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) -= (TotalDollars - BalanceToDollars)

                        End If

                    End If
                    'DataRow(MediaPlanning.Methods.DataColumns.Dollars.ToString) -= 0.01

                    'TotalDollars -= 0.01

                    'If TotalDollars = BalanceToDollars Then

                    '    Exit For

                    'End If

                Next

                'Loop

            End If

        End Sub
        'Public Sub BalanceBudgetBillAmount(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToBillAmount As Decimal)

        '    Dim TotalBillAmount As Decimal = 0
        '    Dim TotalRowCount As Integer = 0
        '    Dim UpdateAmount As Decimal = 0

        '    TotalBillAmount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                              DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Sum(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)))

        '    TotalRowCount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                    DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Count

        '    UpdateAmount = FormatNumber((BalanceToBillAmount - TotalBillAmount) / TotalRowCount, 2)

        '    If Math.Abs(UpdateAmount) < 1 Then

        '        BalanceBudgetBillAmountMicro(MediaPlan, RowIndex, BalanceToBillAmount)

        '    Else

        '        BalanceBudgetBillAmountMacro(MediaPlan, RowIndex, BalanceToBillAmount)

        '    End If

        'End Sub
        'Private Sub BalanceBudgetBillAmountMicro(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToBillAmount As Decimal)

        '    Dim RowIndexes As IEnumerable(Of Integer) = Nothing
        '    Dim TotalBillAmount As Decimal = 0

        '    TotalBillAmount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                              DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Sum(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)))

        '    If TotalBillAmount < BalanceToBillAmount Then

        '        Do Until TotalBillAmount = BalanceToBillAmount

        '            For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                        DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderBy(Function(DR) DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString))

        '                DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) += 0.01

        '                TotalBillAmount += 0.01

        '                If TotalBillAmount = BalanceToBillAmount Then

        '                    Exit For

        '                End If

        '            Next

        '        Loop

        '    ElseIf TotalBillAmount > BalanceToBillAmount Then

        '        Do Until TotalBillAmount = BalanceToBillAmount

        '            For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                        DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderByDescending(Function(DR) DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString))

        '                DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) -= 0.01

        '                TotalBillAmount -= 0.01

        '                If TotalBillAmount = BalanceToBillAmount Then

        '                    Exit For

        '                End If

        '            Next

        '        Loop

        '    End If

        'End Sub
        'Private Sub BalanceBudgetBillAmountMacro(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer, BalanceToBillAmount As Decimal)

        '    Dim TotalBillAmount As Decimal = 0
        '    Dim TotalRowCount As Integer = 0
        '    Dim UpdateAmount As Decimal = 0
        '    Dim Remainder As Decimal = 0
        '    Dim RowCount As Integer = 0

        '    TotalBillAmount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                              DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Sum(Function(DR) CDec(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)))

        '    TotalRowCount = MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                    DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).Count

        '    If TotalBillAmount < BalanceToBillAmount Then

        '        UpdateAmount = FormatNumber((BalanceToBillAmount - TotalBillAmount) / TotalRowCount, 2)

        '        Remainder = FormatNumber(TotalBillAmount - (UpdateAmount * TotalRowCount), 2)

        '        'Do Until TotalBillAmount = BalanceToBillAmount

        '        For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                    DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderBy(Function(DR) DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString))

        '            RowCount += 1

        '            DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) += UpdateAmount

        '            TotalBillAmount += UpdateAmount

        '            If RowCount = TotalRowCount AndAlso TotalBillAmount <> BalanceToBillAmount Then

        '                If TotalBillAmount < BalanceToBillAmount Then

        '                    DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) += (BalanceToBillAmount - TotalBillAmount)

        '                Else

        '                    DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) += (TotalBillAmount - BalanceToBillAmount)

        '                End If

        '            End If
        '            'DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) += 0.01

        '            'TotalBillAmount += 0.01

        '            'If TotalBillAmount = BalanceToBillAmount Then

        '            '    Exit For

        '            'End If

        '        Next

        '        'Loop

        '    ElseIf TotalBillAmount > BalanceToBillAmount Then

        '        UpdateAmount = FormatNumber((TotalBillAmount - BalanceToBillAmount) / TotalRowCount, 2)

        '        Remainder = FormatNumber(TotalBillAmount - (UpdateAmount * TotalRowCount), 2)

        '        'Do Until TotalBillAmount = BalanceToBillAmount

        '        For Each DataRow In MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString)) = False AndAlso
        '                                                                                                                    DR(MediaPlanning.Methods.DataColumns.RowIndex.ToString) = RowIndex).OrderByDescending(Function(DR) DR(MediaPlanning.Methods.DataColumns.BillAmount.ToString))

        '            RowCount += 1

        '            DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) -= UpdateAmount

        '            TotalBillAmount -= UpdateAmount

        '            If RowCount = TotalRowCount AndAlso TotalBillAmount <> BalanceToBillAmount Then

        '                If TotalBillAmount < BalanceToBillAmount Then

        '                    DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) -= (BalanceToBillAmount - TotalBillAmount)

        '                Else

        '                    DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) -= (TotalBillAmount - BalanceToBillAmount)

        '                End If

        '            End If
        '            'DataRow(MediaPlanning.Methods.DataColumns.BillAmount.ToString) -= 0.01

        '            'TotalBillAmount -= 0.01

        '            'If TotalBillAmount = BalanceToBillAmount Then

        '            '    Exit For

        '            'End If

        '        Next

        '        'Loop

        '    End If

        'End Sub
        Private Sub HideFieldBasedOnPeriodType(MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            If MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Month OrElse
                    MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.OOH4Week Then

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    MediaPlanDetailField.IsVisible = False

                End If

            ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Week Then

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Day.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    MediaPlanDetailField.IsVisible = False

                End If

            ElseIf MediaPlan.MediaPlanEstimate.PeriodType = AdvantageFramework.MediaPlanning.PeriodTypes.Day Then

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Quarter.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Year.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Week.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Month.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Date.ToString Then

                    MediaPlanDetailField.IsVisible = False

                End If

            End If

        End Sub
        Private Sub HideInternetFields(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            For Each MediaPlanDetailField In MediaPlan.MediaPlanEstimate.MediaPlanDetailFields

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.AgencyFee.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.NetCharge.ToString Then

                    MediaPlanDetailField.IsVisible = False

                Else

                    HideFieldBasedOnPeriodType(MediaPlanDetailField, MediaPlan)

                End If

            Next

        End Sub
        Private Sub HideMagazineFields(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            For Each MediaPlanDetailField In MediaPlan.MediaPlanEstimate.MediaPlanDetailFields

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                    MediaPlanDetailField.IsVisible = False

                Else

                    HideFieldBasedOnPeriodType(MediaPlanDetailField, MediaPlan)

                End If

            Next

        End Sub
        Private Sub HideNewspaperFields(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            For Each MediaPlanDetailField In MediaPlan.MediaPlanEstimate.MediaPlanDetailFields

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                    MediaPlanDetailField.IsVisible = False

                Else

                    HideFieldBasedOnPeriodType(MediaPlanDetailField, MediaPlan)

                End If

            Next

        End Sub
        Private Sub HideOutOfHomeFields(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            For Each MediaPlanDetailField In MediaPlan.MediaPlanEstimate.MediaPlanDetailFields

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo1.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString Then

                    MediaPlanDetailField.IsVisible = False

                Else

                    HideFieldBasedOnPeriodType(MediaPlanDetailField, MediaPlan)

                End If

            Next

        End Sub
        Private Sub HideBroadcastFields(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            For Each MediaPlanDetailField In MediaPlan.MediaPlanEstimate.MediaPlanDetailFields

                If MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Units.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Clicks.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Impressions.ToString OrElse
                        MediaPlanDetailField.FieldID = AdvantageFramework.MediaPlanning.DataColumns.Demo2.ToString Then

                    MediaPlanDetailField.IsVisible = False

                Else

                    HideFieldBasedOnPeriodType(MediaPlanDetailField, MediaPlan)

                End If

            Next

        End Sub
        Public Sub AddEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaType As String, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session,
                                                BudgetAmount As Decimal, AddBroadcastData As Boolean)

            If MediaType = "I" AndAlso
                    MediaPlan IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.MediaPlanDetailFields IsNot Nothing Then

                HideInternetFields(MediaPlan)

                AddInternetEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID, MediaPlan, Session, BudgetAmount)

            ElseIf MediaType = "M" AndAlso
                    MediaPlan IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.MediaPlanDetailFields IsNot Nothing Then

                HideMagazineFields(MediaPlan)

                AddMagazineEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID, MediaPlan, Session)

            ElseIf MediaType = "N" AndAlso
                    MediaPlan IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.MediaPlanDetailFields IsNot Nothing Then

                HideNewspaperFields(MediaPlan)

                AddNewspaperEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID, MediaPlan, Session)

            ElseIf MediaType = "O" AndAlso
                    MediaPlan IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.MediaPlanDetailFields IsNot Nothing Then

                HideOutOfHomeFields(MediaPlan)

                AddOutOfHomeEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID, MediaPlan, Session)

            ElseIf {"R", "T"}.Contains(MediaType) AndAlso
                    MediaPlan IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso MediaPlan.MediaPlanEstimate.MediaPlanDetailFields IsNot Nothing Then

                HideBroadcastFields(MediaPlan)

                AddBroadcastEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID, MediaPlan, Session, AddBroadcastData)

            End If

        End Sub
        Private Sub AddInternetEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session,
                                                         BudgetAmount As Decimal)

            'objects
            Dim Message As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            '            Dim RateDatas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim Dollars As Decimal = 0
            Dim BillAmount As Decimal = 0
            Dim DataColumn As AdvantageFramework.MediaPlanning.DataColumns = Nothing
            Dim TotalDollars As Decimal = 0
            Dim TotalBillAmount As Decimal = 0
            Dim MediaPlanDetailSetting As AdvantageFramework.Database.Entities.MediaPlanDetailSetting = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim RowIndex As Integer = 0
            Dim BalanceToBudget As Decimal = 0
            Dim StartDatesList As Generic.List(Of Date) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'add levels
                    MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()
                    MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    MediaPlan.MediaPlanEstimate.ShowColumnGrandTotals = True
                    MediaPlan.MediaPlanEstimate.ShowRowGrandTotals = True

                    If MediaPlan.MediaPlanEstimate.MediaPlanDetailSettings IsNot Nothing Then

                        MediaPlanDetailSetting = MediaPlan.MediaPlanEstimate.MediaPlanDetailSettings.Where(Function(Entity) Entity.Setting = AdvantageFramework.MediaPlanning.Settings.IsImpressionsCPM.ToString).SingleOrDefault

                        If MediaPlanDetailSetting IsNot Nothing Then

                            MediaPlanDetailSetting.BooleanValue = True

                        End If

                    End If

                    'RateDatas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}, 1", MediaPlanEstimateTemplateID)).ToList

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    Datas = Datas.Where(Function(D) D.PercentageOrRate <> 0).OrderBy(Function(D) D.VendorName).ThenBy(Function(D) D.SuggestedVendorName).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateVendorID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0) Then

                        If Datas.Any(Function(D) String.IsNullOrWhiteSpace(D.VendorName) = False) Then

                            MediaPlan.AddLevelLineColumn("Vendor", AdvantageFramework.MediaPlanning.TagTypes.Vendor, AdvantageFramework.MediaPlanning.MappingTypes.None)

                        End If

                        If Datas.Any(Function(D) String.IsNullOrWhiteSpace(D.VendorName) = True) Then

                            MediaPlan.AddLevelLineColumn("Suggested Vendor", AdvantageFramework.MediaPlanning.TagTypes.Default, AdvantageFramework.MediaPlanning.MappingTypes.None)

                        End If

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateMediaTacticID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateTactics.Count > 0) Then

                        If Datas.Any(Function(D) String.IsNullOrWhiteSpace(D.TacticDescription) = False) Then

                            MediaPlan.AddLevelLineColumn("Tactic", AdvantageFramework.MediaPlanning.TagTypes.MediaTactic, AdvantageFramework.MediaPlanning.MappingTypes.MediaTactic)

                        End If

                        If Datas.Any(Function(D) String.IsNullOrWhiteSpace(D.TacticDescription) = True) Then

                            MediaPlan.AddLevelLineColumn("Suggested Tactic", AdvantageFramework.MediaPlanning.TagTypes.Default, AdvantageFramework.MediaPlanning.MappingTypes.None)

                        End If

                    End If

                    'If RateDatas IsNot Nothing AndAlso RateDatas.Any(Function(RD) RD.ID.HasValue) Then

                    MediaPlan.AddLevelLineColumn("Internet Type", AdvantageFramework.MediaPlanning.TagTypes.InternetType, AdvantageFramework.MediaPlanning.MappingTypes.InternetType)

                    'End If

                    'add data
                    For Each DataDTO In Datas

                        DataRow = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                        If DataDTO.MediaPlanEstimateTemplateVendorID.HasValue AndAlso String.IsNullOrWhiteSpace(DataDTO.VendorName) = False Then

                            DataRow("Vendor") = DataDTO.VendorName

                        End If

                        If String.IsNullOrWhiteSpace(DataDTO.VendorName) AndAlso String.IsNullOrWhiteSpace(DataDTO.SuggestedVendorName) = False Then

                            DataRow("Suggested Vendor") = DataDTO.SuggestedVendorName

                        End If

                        If DataDTO.MediaPlanEstimateTemplateMediaTacticID.HasValue AndAlso String.IsNullOrWhiteSpace(DataDTO.TacticDescription) = False Then

                            DataRow("Tactic") = DataDTO.TacticDescription

                        End If

                        If String.IsNullOrWhiteSpace(DataDTO.TacticDescription) AndAlso String.IsNullOrWhiteSpace(DataDTO.SuggestedTacticDescription) = False Then

                            DataRow("Suggested Tactic") = DataDTO.SuggestedTacticDescription

                        End If

                        MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)
                        RowIndex = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                        If DataDTO.MediaPlanEstimateTemplateVendorID.HasValue AndAlso String.IsNullOrWhiteSpace(DataDTO.VendorName) = False Then

                            MediaPlanDetailLevelLine = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, DataDTO.VendorCode)

                                MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                MediaPlanDetailLevelLineTag.DbContext = MediaPlan.DbContext
                                MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                MediaPlanDetailLevelLineTag.CreatedDate = Now
                                MediaPlanDetailLevelLineTag.VendorCode = DataDTO.VendorCode

                                If Vendor IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag.VendorMarkup = Vendor.Markup
                                    MediaPlanDetailLevelLineTag.VendorCommission = Vendor.Commission

                                End If

                                MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                            End If

                        End If

                        If DataDTO.MediaPlanEstimateTemplateMediaTacticID.HasValue AndAlso String.IsNullOrWhiteSpace(DataDTO.TacticDescription) = False Then

                            MediaPlanDetailLevelLine = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.MediaTactic).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                MediaPlanDetailLevelLineTag.DbContext = MediaPlan.DbContext
                                MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                MediaPlanDetailLevelLineTag.CreatedDate = Now
                                MediaPlanDetailLevelLineTag.MediaTacticID = DataDTO.MediaTacticID

                                MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                            End If

                        End If

                        If MediaPlan.MediaPlanEstimate.IsEstimateGrossAmount = False Then

                            Dollars = Math.Round(BudgetAmount * DataDTO.PercentageOrRate / 100.0 * 0.85, 2, MidpointRounding.AwayFromZero)
                            BillAmount = Math.Round(BudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)

                        Else

                            Dollars = Math.Round(BudgetAmount * DataDTO.PercentageOrRate / 100.0, 2, MidpointRounding.AwayFromZero)
                            BillAmount = Dollars

                        End If

                        TotalDollars += Dollars
                        TotalBillAmount += BillAmount

                        DataColumn = AdvantageFramework.Media.Presentation.GetDataColumnFromPeriodType(MediaPlan)

                        StartDatesList = AdvantageFramework.Media.Presentation.AllocateBudget(MediaPlan, MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars, MediaPlan.StartDate, MediaPlan.EndDate, DataColumn, False, True)

                        If StartDatesList.Count > 0 Then 'Dollars <> 0 AndAlso BillAmount <> 0 Then

                            If Datas.Last.Equals(DataDTO) Then

                                BalanceToBudget = FormatNumber(Dollars - (TotalDollars - (Math.Round(MediaPlan.MediaPlanEstimate.GrossBudgetAmount * 0.85, 2, MidpointRounding.AwayFromZero))), 2)

                                If BalanceToBudget <> 0 Then

                                    AdvantageFramework.Media.Presentation.BalanceBudgetDollars(MediaPlan, MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BalanceToBudget)

                                End If

                                'If BillAmount - (TotalBillAmount - BudgetAmount) <> 0 Then

                                '    AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(MediaPlan, MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount - (TotalBillAmount - BudgetAmount))

                                'End If

                            Else

                                AdvantageFramework.Media.Presentation.BalanceBudgetDollars(MediaPlan, MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), Dollars)

                                'AdvantageFramework.Media.Presentation.BalanceBudgetBillAmount(MediaPlan, MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow), BillAmount)

                            End If

                        End If

                    Next

                End Using

                If MediaPlan.Save(Message) = False AndAlso String.IsNullOrWhiteSpace(Message) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                End If

            End If

        End Sub
        Private Sub AddMagazineEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session)

            'objects
            Dim Message As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing

            If MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'MediaPlan.MediaPlanEstimate.ShowColumnGrandTotals = True
                    'MediaPlan.MediaPlanEstimate.ShowRowGrandTotals = True

                    'add levels
                    MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()
                    MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    Datas = Datas.OrderBy(Function(D) D.VendorName).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateVendorID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Vendor", AdvantageFramework.MediaPlanning.TagTypes.Vendor, AdvantageFramework.MediaPlanning.MappingTypes.None)

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateAdSizeID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("AdSize", AdvantageFramework.MediaPlanning.TagTypes.AdSize, AdvantageFramework.MediaPlanning.MappingTypes.AdSizeDescription)

                    End If

                    'add data
                    'For Each DataDTO In Datas

                    '    DataRow = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                    '    If DataDTO.MediaPlanEstimateTemplateVendorID.HasValue Then

                    '        DataRow("Vendor") = DataDTO.VendorName

                    '    End If

                    '    If DataDTO.MediaPlanEstimateTemplateAdSizeID.HasValue Then

                    '        DataRow("AdSize") = DataDTO.AdSize

                    '    End If

                    '    MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)

                    '    'For Each DR In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex = " & _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                    '    '    If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                    '    '        If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        End If

                    '    '    Else

                    '    '        DR("Rate") = DataDTO.PercentageOrRate

                    '    '    End If

                    '    'Next

                    'Next

                End Using

                If MediaPlan.Save(Message) = False AndAlso String.IsNullOrWhiteSpace(Message) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                End If

            End If

        End Sub
        Private Sub AddNewspaperEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session)

            'objects
            Dim Message As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing

            If MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'add levels
                    MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()
                    MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    Datas = Datas.OrderBy(Function(D) D.VendorName).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateVendorID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Vendor", AdvantageFramework.MediaPlanning.TagTypes.Vendor, AdvantageFramework.MediaPlanning.MappingTypes.None)

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateAdSizeID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateAdSizes.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("AdSize", AdvantageFramework.MediaPlanning.TagTypes.AdSize, AdvantageFramework.MediaPlanning.MappingTypes.AdSizeDescription)

                    End If

                    'add data
                    'For Each DataDTO In Datas

                    '    DataRow = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                    '    If DataDTO.MediaPlanEstimateTemplateVendorID.HasValue Then

                    '        DataRow("Vendor") = DataDTO.VendorName

                    '    End If

                    '    If DataDTO.MediaPlanEstimateTemplateAdSizeID.HasValue Then

                    '        DataRow("AdSize") = DataDTO.AdSize

                    '    End If

                    '    MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)

                    '    'For Each DR In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex = " & _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                    '    '    If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                    '    '        If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        End If

                    '    '    Else

                    '    '        DR("Rate") = DataDTO.PercentageOrRate

                    '    '    End If

                    '    'Next

                    'Next

                End Using

                If MediaPlan.Save(Message) = False AndAlso String.IsNullOrWhiteSpace(Message) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                End If

            End If

        End Sub
        Private Sub AddOutOfHomeEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session)

            'objects
            Dim Message As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing

            If MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'add levels
                    MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()
                    MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    Datas = Datas.OrderBy(Function(D) D.VendorName).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateVendorID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateVendors.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Vendor", AdvantageFramework.MediaPlanning.TagTypes.Vendor, AdvantageFramework.MediaPlanning.MappingTypes.None)

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateOutdoorTypeID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateOutdoorTypes.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Out of Home Type", AdvantageFramework.MediaPlanning.TagTypes.OutOfHomeType, AdvantageFramework.MediaPlanning.MappingTypes.OutOfHomeType)

                    End If

                    'add data
                    'For Each DataDTO In Datas

                    '    DataRow = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                    '    If DataDTO.MediaPlanEstimateTemplateVendorID.HasValue Then

                    '        DataRow("Vendor") = DataDTO.VendorName

                    '    End If

                    '    If DataDTO.MediaPlanEstimateTemplateOutdoorTypeID.HasValue Then

                    '        DataRow("Out of Home Type") = DataDTO.OutOfHomeType

                    '    End If

                    '    MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)

                    '    'For Each DR In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex = " & _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                    '    '    If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                    '    '        If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DR("Date")).Month) Then

                    '    '            DR("Rate") = DataDTO.PercentageOrRate

                    '    '        End If

                    '    '    Else

                    '    '        DR("Rate") = DataDTO.PercentageOrRate

                    '    '    End If

                    '    'Next

                    'Next

                End Using

                If MediaPlan.Save(Message) = False AndAlso String.IsNullOrWhiteSpace(Message) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                End If

            End If

        End Sub
        Private Sub AddBroadcastEstimateLevelsLinesBudget(MediaPlanEstimateTemplateID As Integer, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, Session As AdvantageFramework.Security.Session, AddData As Boolean)

            'objects
            Dim Message As String = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Datas As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data) = Nothing
            Dim MediaPlanEstimateTemplate As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplate = Nothing
            Dim RowIndex As Integer = 0
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing

            If MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, MediaPlan.ID, MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    DbContext.Database.Connection.Open()

                    'add levels
                    MediaPlan.MediaPlanEstimate.CreateLevelsAndLinesDataTable()
                    MediaPlan.MediaPlanEstimate.CreateEstimateDataTable()

                    Datas = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Data)(String.Format("exec advsp_media_type_template_data {0}", MediaPlanEstimateTemplateID)).ToList

                    Datas = Datas.OrderBy(Function(D) D.Market).ThenBy(Function(D) D.SpotLength).ThenBy(Function(D) D.DaypartDescription).ToList

                    MediaPlanEstimateTemplate = DbContext.MediaPlanEstimateTemplates.Find(MediaPlanEstimateTemplateID)

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateMarketID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateMarkets.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Market", AdvantageFramework.MediaPlanning.TagTypes.Market, AdvantageFramework.MediaPlanning.MappingTypes.Market)

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateSpotLengthID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateSpotLengths.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Length", AdvantageFramework.MediaPlanning.TagTypes.Default, AdvantageFramework.MediaPlanning.MappingTypes.Length)

                    End If

                    If (Datas IsNot Nothing AndAlso Datas.Any(Function(D) D.MediaPlanEstimateTemplateDaypartID.HasValue)) OrElse
                            (MediaPlanEstimateTemplate IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts IsNot Nothing AndAlso MediaPlanEstimateTemplate.MediaPlanEstimateTemplateDayparts.Count > 0) Then

                        MediaPlan.AddLevelLineColumn("Daypart", AdvantageFramework.MediaPlanning.TagTypes.Daypart, AdvantageFramework.MediaPlanning.MappingTypes.Daypart)

                    End If

                    If AddData Then

                        'add data
                        For Each DataDTO In Datas

                            DataRow = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow

                            If DataDTO.MediaPlanEstimateTemplateMarketID.HasValue Then

                                DataRow("Market") = DataDTO.Market

                            End If

                            If DataDTO.MediaPlanEstimateTemplateSpotLengthID.HasValue Then

                                DataRow("Length") = DataDTO.SpotLength

                            End If

                            If DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue Then

                                DataRow("Daypart") = DataDTO.DaypartDescription

                            End If

                            MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(DataRow)
                            RowIndex = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                            If DataDTO.MediaPlanEstimateTemplateMarketID.HasValue AndAlso String.IsNullOrWhiteSpace(DataDTO.MarketCode) = False Then

                                MediaPlanDetailLevelLine = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Market).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                If MediaPlanDetailLevelLine IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                    MediaPlanDetailLevelLineTag.DbContext = MediaPlan.DbContext
                                    MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                    MediaPlanDetailLevelLineTag.CreatedDate = Now
                                    MediaPlanDetailLevelLineTag.MarketCode = DataDTO.MarketCode

                                    MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                End If

                            End If

                            If DataDTO.MediaPlanEstimateTemplateDaypartID.HasValue AndAlso DataDTO.DaypartID.HasValue Then

                                MediaPlanDetailLevelLine = MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Daypart).SelectMany(Function(Entity) Entity.MediaPlanDetailLevelLines).Where(Function(Entity) Entity.RowIndex = RowIndex).FirstOrDefault

                                If MediaPlanDetailLevelLine IsNot Nothing Then

                                    MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag
                                    MediaPlanDetailLevelLineTag.DbContext = MediaPlan.DbContext
                                    MediaPlanDetailLevelLineTag.CreatedByUserCode = DbContext.UserCode
                                    MediaPlanDetailLevelLineTag.CreatedDate = Now
                                    MediaPlanDetailLevelLineTag.DaypartID = DataDTO.DaypartID

                                    MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                                End If

                            End If

                            'For Each DR In _MediaPlan.MediaPlanEstimate.EstimateDataTable.Select("RowIndex = " & _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                            '    If String.IsNullOrWhiteSpace(DataDTO.Quarter) = False Then

                            '        If DataDTO.Quarter = "Q1" AndAlso {1, 2, 3}.Contains(CDate(DR("Date")).Month) Then

                            '            DR("Rate") = DataDTO.PercentageOrRate

                            '        ElseIf DataDTO.Quarter = "Q2" AndAlso {4, 5, 6}.Contains(CDate(DR("Date")).Month) Then

                            '            DR("Rate") = DataDTO.PercentageOrRate

                            '        ElseIf DataDTO.Quarter = "Q3" AndAlso {7, 8, 9}.Contains(CDate(DR("Date")).Month) Then

                            '            DR("Rate") = DataDTO.PercentageOrRate

                            '        ElseIf DataDTO.Quarter = "Q4" AndAlso {10, 11, 12}.Contains(CDate(DR("Date")).Month) Then

                            '            DR("Rate") = DataDTO.PercentageOrRate

                            '        End If

                            '    Else

                            '        DR("Rate") = DataDTO.PercentageOrRate

                            '    End If

                            'Next

                        Next

                    End If

                End Using

                If MediaPlan.Save(Message) = False AndAlso String.IsNullOrWhiteSpace(Message) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(Message)

                End If

            End If

        End Sub
        Private Function IsMissingMappings(Session As AdvantageFramework.Security.Session, MediaPlanEstimateTemplateID As Integer) As Boolean

            Dim IsMissing As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_VENDOR WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND VN_CODE IS NULL", MediaPlanEstimateTemplateID)).First > 0 OrElse
                        DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM dbo.MEDIA_PLAN_ESTIMATE_TEMPLATE_TACTIC WHERE MEDIA_PLAN_ESTIMATE_TEMPLATE_ID = {0} AND MEDIA_TACTIC_ID IS NULL", MediaPlanEstimateTemplateID)).First > 0 Then

                    IsMissing = True

                End If

            End Using

            IsMissingMappings = IsMissing

        End Function
        Public Function CheckMappings(Session As AdvantageFramework.Security.Session, MediaPlanEstimateTemplateID As Nullable(Of Integer), MediaType As String) As Boolean

            Dim Checked As Boolean = True

            If MediaType = "I" AndAlso MediaPlanEstimateTemplateID.HasValue AndAlso IsMissingMappings(Session, MediaPlanEstimateTemplateID.Value) Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to map missing vendor/tactics now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Missing System Template Mappings") = WinForm.MessageBox.DialogResults.Yes Then

                    AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateMappingDialog.ShowFormDialog()
                    Checked = False

                End If

            End If

            CheckMappings = Checked

        End Function
        Public Function CreateMediaRFPFileName(VendorName As String, UserCode As String, WorksheetMarketID As Integer) As String

            'objects
            Dim FileName As String = ""

            FileName = VendorName & "_" & WorksheetMarketID.ToString & "_" & UserCode

            CreateMediaRFPFileName = FileName

        End Function

#End Region

    End Module

End Namespace


