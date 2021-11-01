Namespace Media.Presentation

    Public Class MediaPlanDetailLevelsAndLinesDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _LoadingDateTime As Boolean = False
        Private _RowOriginalEndDates As Generic.Dictionary(Of Integer, Date) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.TagTypes = AdvantageFramework.MediaPlanning.TagTypes.Default
            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim Width As Integer = 0
            Dim MaxLength As Long = -1
            Dim MappingType As AdvantageFramework.MediaPlanning.MappingTypes = AdvantageFramework.MediaPlanning.MappingTypes.None

            DataGridViewForm_DetailLines.ClearGridCustomization()
            DataGridViewForm_DetailLines.ItemDescription = "Level/Line(s)"

            DataGridViewForm_DetailLines.DataSource = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable

            'Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '    Try

            '        MaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(GetType(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine), AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine.Properties.Description.ToString))

            '    Catch ex As Exception
            '        MaxLength = -1
            '    End Try

            'End Using

            'MaxLength = 100

            For Each GridColumn In DataGridViewForm_DetailLines.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            For Each DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)).ToList

                Try

                    GridColumn = DataGridViewForm_DetailLines.Columns(DataColumn.ColumnName)

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                            DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString Then

                        If DataColumn.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                            Try

                                GridColumn.Visible = _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel)

                            Catch ex As Exception

                            End Try

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                            Try

                                GridColumn.Visible = _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel)

                            Catch ex As Exception

                            End Try

                        ElseIf DataColumn.ColumnName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

                            Try

                                GridColumn.Visible = _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel) OrElse
                                    _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.AdSize)

                            Catch ex As Exception

                            End Try

                        Else

                            Try

                                GridColumn.Visible = True

                            Catch ex As Exception

                            End Try

                        End If

                        Try

                            Width = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.Width.ToString)

                        Catch ex As Exception
                            Width = 100
                        End Try

                        GridColumn.Width = Width

                        Try

                            TagType = CType(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString), AdvantageFramework.MediaPlanning.TagTypes)

                        Catch ex As Exception
                            TagType = AdvantageFramework.MediaPlanning.TagTypes.Default
                        End Try

                        If TagType <> AdvantageFramework.MediaPlanning.TagTypes.Default AndAlso
                                TagType <> MediaPlanning.TagTypes.StartDate AndAlso
                                TagType <> MediaPlanning.TagTypes.EndDate Then

                            GridColumn.Tag = DataColumn

                            AddSubItemTextBox(Me.Session, DataGridViewForm_DetailLines, GridColumn, MaxLength, True)

                        ElseIf TagType = MediaPlanning.TagTypes.StartDate OrElse
                                TagType = MediaPlanning.TagTypes.EndDate Then

                            GridColumn.Tag = DataColumn

                            GridColumn.DisplayFormat.FormatString = "d"
                            GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            SubItemDateInput = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemDateEdit()

                            SubItemDateInput.Name = TagType.ToString
                            SubItemDateInput.MinValue = _MediaPlan.StartDate
                            SubItemDateInput.MaxValue = _MediaPlan.EndDate
                            SubItemDateInput.DisplayFormat.FormatString = "d"
                            SubItemDateInput.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            SubItemDateInput.EditFormat.FormatString = "d"
                            SubItemDateInput.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            SubItemDateInput.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
                            SubItemDateInput.EditMask = ""
                            SubItemDateInput.Mask.UseMaskAsDisplayFormat = False

                            SubItemDateInput.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard

                            If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                                SubItemDateInput.FirstDayOfWeek = DayOfWeek.Monday

                            End If

                            DataGridViewForm_DetailLines.GridControl.RepositoryItems.Add(SubItemDateInput)

                            GridColumn.ColumnEdit = SubItemDateInput

                            AddHandler SubItemDateInput.EditValueChanged, AddressOf SubItemDateInput_EditValueChanged
                            AddHandler SubItemDateInput.DrawItem, AddressOf SubItemDateInput_DrawItem
                            AddHandler SubItemDateInput.DisableCalendarDate, AddressOf SubItemDateInput_DisableCalendarDate

                            If TagType = MediaPlanning.TagTypes.StartDate Then

                                AddHandler SubItemDateInput.Popup, AddressOf SubItemDateInputStartDate_Popup

                            ElseIf TagType = MediaPlanning.TagTypes.EndDate Then

                                AddHandler SubItemDateInput.Popup, AddressOf SubItemDateInputEndDate_Popup

                            End If

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

                            AddSubItemTextBoxForPackageDetails(Me.Session, DataGridViewForm_DetailLines, GridColumn)

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                            AddSubItemTextBoxForPackagePlacement(Me.Session, DataGridViewForm_DetailLines, GridColumn)

                        ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                            AddSubItemTextBoxForPackageName(Me.Session, DataGridViewForm_DetailLines, GridColumn, MaxLength)

                            'SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                            'SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                            'SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                            'SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                            'SubItemGridLookUpEditControl.NullText = ""
                            'SubItemGridLookUpEditControl.DisplayMember = "Name"
                            'SubItemGridLookUpEditControl.ValueMember = "Value"

                            'SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                            'SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                            'SubItemGridLookUpEditControl.DataSource = _MediaPlan.MediaPlanEstimate.PackageNames.Where(Function(PackageName) String.IsNullOrWhiteSpace(PackageName) = False).Select(Function(PackageName) New With {.Name = PackageName, .Value = PackageName}).ToList

                            'AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_QueryPopup
                            'AddHandler SubItemGridLookUpEditControl.EditValueChanging, AddressOf SubItemGridLookUpEditControl_EditValueChanging

                            'DataGridViewForm_DetailLines.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                            'GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                        Else

                            Try

                                MappingType = CType(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString), AdvantageFramework.MediaPlanning.MappingTypes)

                            Catch ex As Exception
                                MappingType = AdvantageFramework.MediaPlanning.MappingTypes.None
                            End Try

                            If _MediaPlan.MediaPlanEstimate.SalesClassType = "R" OrElse _MediaPlan.MediaPlanEstimate.SalesClassType = "T" Then

                                If MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Length Then

                                    AddSubItemTextBoxForLength(Me.Session, DataGridViewForm_DetailLines, GridColumn, MaxLength)

                                ElseIf MappingType = AdvantageFramework.MediaPlanning.MappingTypes.OrderComment OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Placement OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Instructions OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.OrderCopy OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.MaterialNotes OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.MiscInfo Then

                                    AddSubItemMemoItem(DataGridViewForm_DetailLines, GridColumn, Session)

                                Else

                                    AddSubItemTextBox(Me.Session, DataGridViewForm_DetailLines, GridColumn, MaxLength, False)

                                End If

                            Else

                                If MappingType = AdvantageFramework.MediaPlanning.MappingTypes.OrderComment OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Placement OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Instructions OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.OrderCopy OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.MaterialNotes OrElse
                                        MappingType = AdvantageFramework.MediaPlanning.MappingTypes.MiscInfo Then

                                    AddSubItemMemoItem(DataGridViewForm_DetailLines, GridColumn, Session)

                                ElseIf MappingType = AdvantageFramework.MediaPlanning.MappingTypes.Circulation Then

                                    AddSubItemTextBoxForCirculation(Me.Session, DataGridViewForm_DetailLines, GridColumn)

                                Else

                                    AddSubItemTextBox(Me.Session, DataGridViewForm_DetailLines, GridColumn, MaxLength, False)

                                End If

                            End If

                        End If

                    Else

                        GridColumn.Visible = False

                    End If

                End If

            Next

            For Each DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)).ToList

                If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

                    Try

                        GridColumn = DataGridViewForm_DetailLines.Columns(DataColumn.ColumnName)

                    Catch ex As Exception
                        GridColumn = Nothing
                    End Try

                    If GridColumn IsNot Nothing Then

                        Try

                            GridColumn.VisibleIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)

                        Catch ex As Exception
                            GridColumn.VisibleIndex = 0
                        End Try

                    End If

                End If

            Next

            If _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel) Then

                If DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString) IsNot Nothing Then

                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString).OptionsColumn.AllowShowHide = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString).OptionsColumn.AllowMove = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString).VisibleIndex = 0
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString).Caption = "Package Name"
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString).BestFit()

                End If

                If DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) IsNot Nothing Then

                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).OptionsColumn.AllowShowHide = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).OptionsColumn.AllowMove = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).VisibleIndex = 1
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).Caption = "Package Placement"

                    If _MediaPlan.MediaPlanEstimate.PackagePlacementWidth = -1 Then

                        DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).BestFit()

                    Else

                        DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).Width = _MediaPlan.MediaPlanEstimate.PackagePlacementWidth

                    End If

                End If

                If DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) IsNot Nothing Then

                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).OptionsColumn.AllowShowHide = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).OptionsColumn.AllowMove = False
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).VisibleIndex = 2
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Caption = "Package Details"
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).BestFit()

                End If

            ElseIf _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.AdSize) Then

                If DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) IsNot Nothing Then

                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).VisibleIndex = 0
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Caption = "Add'l Ad Sizes"
                    DataGridViewForm_DetailLines.Columns(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).BestFit()

                End If

            End If

        End Sub
        Private Sub AddStartOrEndDateTag(ByVal DataColumn As System.Data.DataColumn, ByVal RowIndex As Integer, ByVal [Date] As Date)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing

            Try

                MediaPlanDetailLevel = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = DataColumn.ColumnName)

            Catch ex As Exception
                MediaPlanDetailLevel = Nothing
            End Try

            If MediaPlanDetailLevel IsNot Nothing Then

                Try

                    MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = RowIndex)

                Catch ex As Exception
                    MediaPlanDetailLevelLine = Nothing
                End Try

                If MediaPlanDetailLevelLine IsNot Nothing Then

                    Try

                        If MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags IsNot Nothing Then

                            MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault

                        End If

                    Catch ex As Exception
                        MediaPlanDetailLevelLineTag = Nothing
                    End Try

                    If [Date] = Nothing Then

                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(DataColumn) = ""

                        If MediaPlanDetailLevelLineTag IsNot Nothing Then

                            MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.Remove(MediaPlanDetailLevelLineTag)

                            Try

                                _MediaPlan.DbContext.DeleteEntityObject(MediaPlanDetailLevelLineTag)

                            Catch ex As Exception
                                MediaPlanDetailLevelLineTag = Nothing
                            End Try

                        End If

                    Else

                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(DataColumn) = CDate([Date]).ToShortDateString

                        If MediaPlanDetailLevelLineTag Is Nothing Then

                            MediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                            MediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext

                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(MediaPlanDetailLevelLine, MediaPlanDetailLevelLineTag)

                        End If

                        If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate Then

                            MediaPlanDetailLevelLineTag.StartDate = CDate(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(DataColumn))

                        ElseIf MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                            MediaPlanDetailLevelLineTag.EndDate = CDate(_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows(RowIndex)(DataColumn))

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_DrawItem(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.CustomDrawDayNumberCellEventArgs)

            'objects
            Dim Brush As System.Drawing.Brush = Nothing
            Dim StringFormat As System.Drawing.StringFormat = Nothing
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False AndAlso e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    CalendarControl = PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().FirstOrDefault()

                    If CalendarControl IsNot Nothing Then

                        If IsInBroadcastMonth(e.Date, CalendarControl.DateTime.Month) Then

                            Brush = Drawing.Brushes.Black

                            StringFormat = New System.Drawing.StringFormat
                            StringFormat.Alignment = System.Drawing.StringAlignment.Center
                            StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                            e.Handled = True

                        Else

                            Brush = Drawing.Brushes.White

                            StringFormat = New System.Drawing.StringFormat
                            StringFormat.Alignment = System.Drawing.StringAlignment.Center
                            StringFormat.LineAlignment = System.Drawing.StringAlignment.Center

                            e.Graphics.DrawString(e.Date.Day.ToString(), e.Style.Font, Brush, e.Bounds, StringFormat)

                            e.Handled = True

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_DisableCalendarDate(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Calendar.DisableCalendarDateEventArgs)

            If _MediaPlan.MediaPlanEstimate IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False AndAlso e.View = DevExpress.XtraEditors.Controls.DateEditCalendarViewType.MonthInfo Then

                e.IsDisabled = False

            End If

        End Sub
        Private Sub SubItemDateInputStartDate_Popup(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            _LoadingDateTime = True

                            Try

                                If sender.EditValue <> Nothing Then

                                    If CDate(sender.EditValue).Day = 1 Then

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                    Else

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                    End If

                                Else

                                    If _MediaPlan.EndDate.Day = 1 Then

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(_MediaPlan.StartDate) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(_MediaPlan.StartDate))

                                    Else

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(_MediaPlan.StartDate) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(_MediaPlan.StartDate))

                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                            _LoadingDateTime = False

                        Next

                    Else

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            Try

                                If sender.EditValue <> Nothing Then

                                    CalendarControl.DateTime = sender.EditValue

                                Else

                                    CalendarControl.DateTime = _MediaPlan.StartDate

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInputEndDate_Popup(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim PopupControl As DevExpress.Utils.Win.IPopupControl = Nothing
            Dim PopupDateEditForm As DevExpress.XtraEditors.Popup.PopupDateEditForm = Nothing
            Dim CalendarControl As DevExpress.XtraEditors.Controls.CalendarControl = Nothing
            Dim DateTimeFormatInfo As System.Globalization.DateTimeFormatInfo = Nothing

            If _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                PopupControl = CType(sender, DevExpress.Utils.Win.IPopupControl)
                PopupDateEditForm = TryCast(PopupControl.PopupWindow, DevExpress.XtraEditors.Popup.PopupDateEditForm)

                If PopupDateEditForm IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.IsCalendarMonth = False Then

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            _LoadingDateTime = True

                            Try

                                If sender.EditValue <> Nothing Then

                                    If CDate(sender.EditValue).Day = 1 Then

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                    Else

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(sender.EditValue) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(sender.EditValue))

                                    End If

                                Else

                                    If _MediaPlan.EndDate.Day = 1 Then

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(_MediaPlan.EndDate) & "/01/" & _MediaPlan.MediaPlanEstimate.GetYear(_MediaPlan.EndDate))

                                    Else

                                        CalendarControl.DateTime = CDate(_MediaPlan.MediaPlanEstimate.GetMonth(_MediaPlan.EndDate) & "/02/" & _MediaPlan.MediaPlanEstimate.GetYear(_MediaPlan.EndDate))

                                    End If

                                End If

                            Catch ex As Exception

                            End Try

                            _LoadingDateTime = False

                        Next

                    Else

                        For Each CalendarControl In PopupDateEditForm.Controls.OfType(Of DevExpress.XtraEditors.Controls.CalendarControl)().ToList

                            Try

                                If sender.EditValue <> Nothing Then

                                    CalendarControl.DateTime = sender.EditValue

                                Else

                                    CalendarControl.DateTime = _MediaPlan.EndDate

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemDateInput_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim RowHandle As Integer = 0
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_DetailLines.IsNewItemRow = False Then

                    Try

                        GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

                    Catch ex As Exception
                        GridColumn = Nothing
                    End Try

                    If GridColumn IsNot Nothing Then

                        Try

                            RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                        Catch ex As Exception
                            RowHandle = 0
                        End Try

                        Try

                            DataColumn = GridColumn.Tag

                        Catch ex As Exception
                            DataColumn = Nothing
                        End Try

                        If DataColumn IsNot Nothing Then

                            AddStartOrEndDateTag(DataColumn, RowHandle, CType(sender, DevExpress.XtraEditors.DateEdit).EditValue)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub BestFitColumn(ByVal sender As Object, ByVal e As EventArgs)

            If DataGridViewForm_DetailLines.CurrentView.FocusedColumn.Visible Then

                DataGridViewForm_DetailLines.CurrentView.FocusedColumn.Width = DataGridViewForm_DetailLines.CurrentView.FocusedColumn.GetBestWidth

                SaveFieldWith(DataGridViewForm_DetailLines.CurrentView.FocusedColumn)

            End If

        End Sub
        Private Sub BestFitAllColumns(ByVal sender As Object, ByVal e As EventArgs)

            For Each GridColumn In DataGridViewForm_DetailLines.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Width = GridColumn.GetBestWidth

                SaveFieldWith(GridColumn)

            Next

        End Sub
        Private Sub AddNewLevel(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim Description As String = ""
            Dim TagType As Integer = 0
            Dim MappingType As Integer = 0
            Dim Message As String = Nothing

            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                AdvantageFramework.WinForm.MessageBox.Show(Message)

            Else

                If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelEditDialog.ShowFormDialog(WinForm.Presentation.FormActions.Adding, _MediaPlan, Description, TagType, MappingType, 0) = Windows.Forms.DialogResult.OK Then

                    _MediaPlan.AddLevelLineColumn(Description, TagType, MappingType)

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub EditLevel(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim Description As String = ""
            Dim TagType As Integer = 0
            Dim MappingType As Integer = 0
            Dim OrderNumber As Integer = 0
            Dim Message As String = Nothing

            If TypeOf sender Is DevExpress.Utils.Menu.DXMenuItem AndAlso
                    DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag IsNot Nothing AndAlso
                    TypeOf DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                GridColumn = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag

                If GridColumn IsNot Nothing Then

                    Try

                        DataColumn = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(GridColumn.FieldName)

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                            AdvantageFramework.WinForm.MessageBox.Show(Message)

                        Else

                            Description = DataColumn.ColumnName
                            TagType = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)
                            MappingType = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.MappingType.ToString)
                            OrderNumber = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)

                            If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelEditDialog.ShowFormDialog(WinForm.Presentation.FormActions.Modifying, _MediaPlan, Description, TagType, MappingType, OrderNumber) = Windows.Forms.DialogResult.OK Then

                                _MediaPlan.UpdateLevelLineColumn(GridColumn.FieldName, Description, TagType, MappingType)

                            End If

                            Me.FormAction = WinForm.Presentation.FormActions.Loading

                            Try

                                LoadGrid()

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.None

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DeleteLevel(ByVal sender As Object, ByVal e As EventArgs)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim Message As String = Nothing

            If TypeOf sender Is DevExpress.Utils.Menu.DXMenuItem AndAlso
                    DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag IsNot Nothing AndAlso
                    TypeOf DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag Is DevExpress.XtraGrid.Columns.GridColumn Then

                GridColumn = DirectCast(sender, DevExpress.Utils.Menu.DXMenuItem).Tag

                If GridColumn IsNot Nothing Then

                    Try

                        DataColumn = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns(GridColumn.FieldName)

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this level?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            If _MediaPlan.SyncDetailSettings AndAlso AdvantageFramework.MediaPlanning.IsAnyEstimateLockedForMediaPlanOtherThanSelectedEstimateID(Session, _MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID, Message) Then

                                AdvantageFramework.WinForm.MessageBox.Show(Message)

                            Else

                                _MediaPlan.RemoveLevelLineColumn(GridColumn.FieldName)

                                Me.FormAction = WinForm.Presentation.FormActions.Loading

                                If DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) = AdvantageFramework.MediaPlanning.TagTypes.Vendor Then

                                    For Each DataRow In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) = 0
                                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString) = String.Empty
                                        DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = 0

                                    Next

                                End If

                                Try

                                    LoadGrid()

                                Catch ex As Exception

                                End Try

                                Me.FormAction = WinForm.Presentation.FormActions.None

                                EnableOrDisableActions()

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub AddSubItemTextBox(ByVal Session As AdvantageFramework.Security.Session, ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                     ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn, ByVal MaxLength As Long, ByVal HasTagType As Boolean)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            If HasTagType Then

                RepositoryItemButtonEdit.ReadOnly = True

                If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                    RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

                Else

                    For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                        If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                            EditorButton.Visible = True
                            Exit For

                        End If

                    Next

                End If

            Else

                RepositoryItemButtonEdit.ReadOnly = False

                If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then

                    For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)().ToList

                        If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                            RepositoryItemButtonEdit.Buttons.RemoveAt(EditorButton.Index)
                            Exit For

                        End If

                    Next

                End If

            End If

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

            AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEdit_ButtonClick

        End Sub
        Private Sub AddSubItemTextBoxForPackageDetails(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                       GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = True

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

            Else

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        EditorButton.Visible = True
                        Exit For

                    End If

                Next

            End If

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

            AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEditPackageDetails_ButtonClick

        End Sub
        Private Sub AddSubItemTextBoxForPackagePlacement(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                         GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = True

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) = False Then

                RepositoryItemButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis))

            Else

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        EditorButton.Visible = True
                        Exit For

                    End If

                Next

            End If

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

            AddHandler RepositoryItemButtonEdit.ButtonClick, AddressOf RepositoryItemButtonEditPackagePlacement_ButtonClick

        End Sub
        Private Sub AddSubItemTextBoxForPackageName(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                    GridColumn As DevExpress.XtraGrid.Columns.GridColumn, MaxLength As Long)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = False

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)().ToList

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        RepositoryItemButtonEdit.Buttons.RemoveAt(EditorButton.Index)
                        Exit For

                    End If

                Next

            End If

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            RepositoryItemButtonEdit.Mask.BeepOnError = False
            RepositoryItemButtonEdit.Mask.IgnoreMaskBlank = False
            RepositoryItemButtonEdit.Mask.SaveLiteral = True
            RepositoryItemButtonEdit.Mask.ShowPlaceHolders = False
            RepositoryItemButtonEdit.Mask.UseMaskAsDisplayFormat = False
            RepositoryItemButtonEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
            RepositoryItemButtonEdit.Mask.EditMask = "[a-zA-Z0-9 _]*"

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

        End Sub
        Private Sub AddSubItemTextBoxForLength(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                               GridColumn As DevExpress.XtraGrid.Columns.GridColumn, MaxLength As Long)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = False

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)().ToList

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        RepositoryItemButtonEdit.Buttons.RemoveAt(EditorButton.Index)
                        Exit For

                    End If

                Next

            End If

            If MaxLength <> -1 Then

                RepositoryItemButtonEdit.MaxLength = MaxLength

            End If

            RepositoryItemButtonEdit.Mask.BeepOnError = False
            RepositoryItemButtonEdit.Mask.IgnoreMaskBlank = False
            RepositoryItemButtonEdit.Mask.SaveLiteral = True
            RepositoryItemButtonEdit.Mask.ShowPlaceHolders = False
            RepositoryItemButtonEdit.Mask.UseMaskAsDisplayFormat = False
            RepositoryItemButtonEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
            RepositoryItemButtonEdit.Mask.EditMask = "[0-9]*"

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

        End Sub
        Private Sub AddSubItemTextBoxForCirculation(Session As AdvantageFramework.Security.Session, DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView,
                                                    GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit = Nothing

            RepositoryItemButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

            RepositoryItemButtonEdit.ReadOnly = False

            If CheckForExistingButton(RepositoryItemButtonEdit, DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis) Then

                For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)().ToList

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        RepositoryItemButtonEdit.Buttons.RemoveAt(EditorButton.Index)
                        Exit For

                    End If

                Next

            End If

            RepositoryItemButtonEdit.MaxLength = 10

            RepositoryItemButtonEdit.Mask.BeepOnError = False
            RepositoryItemButtonEdit.Mask.IgnoreMaskBlank = False
            RepositoryItemButtonEdit.Mask.SaveLiteral = True
            RepositoryItemButtonEdit.Mask.ShowPlaceHolders = False
            RepositoryItemButtonEdit.Mask.UseMaskAsDisplayFormat = False
            RepositoryItemButtonEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
            RepositoryItemButtonEdit.Mask.EditMask = "[0-9]*"

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemButtonEdit)

            GridColumn.ColumnEdit = RepositoryItemButtonEdit

        End Sub
        Private Sub RepositoryItemButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim RowHandle As Integer = 0

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis AndAlso DataGridViewForm_DetailLines.IsNewItemRow = False Then

                Try

                    GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    Try

                        RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                    Catch ex As Exception
                        RowHandle = 0
                    End Try

                    Try

                        DataColumn = GridColumn.Tag

                    Catch ex As Exception
                        DataColumn = Nothing
                    End Try

                    If DataColumn IsNot Nothing Then

                        Try

                            MediaPlanDetailLevel = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.Description = DataColumn.ColumnName)

                        Catch ex As Exception

                        End Try

                        If MediaPlanDetailLevel IsNot Nothing Then

                            Try

                                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = RowHandle)

                            Catch ex As Exception

                            End Try

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagEditDialog.ShowFormDialog(_MediaPlan, MediaPlanDetailLevel, MediaPlanDetailLevelLine) = System.Windows.Forms.DialogResult.OK Then

                                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                                    Try

                                        LoadGrid()

                                    Catch ex As Exception

                                    End Try

                                    Me.FormAction = WinForm.Presentation.FormActions.None

                                    EnableOrDisableActions()

                                    Try

                                        DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle = RowHandle
                                        DataGridViewForm_DetailLines.CurrentView.FocusedColumn = DataGridViewForm_DetailLines.CurrentView.Columns(GridColumn.FieldName)
                                        DataGridViewForm_DetailLines.CurrentView.SelectCell(RowHandle, DataGridViewForm_DetailLines.CurrentView.FocusedColumn)

                                    Catch ex As Exception

                                    End Try

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub RepositoryItemButtonEditPackageDetails_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim RowHandle As Integer = 0

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis AndAlso DataGridViewForm_DetailLines.IsNewItemRow = False Then

                Try

                    GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    Try

                        RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                    Catch ex As Exception
                        RowHandle = 0
                    End Try

                    If AdvantageFramework.Media.Presentation.MediaPlanDetailPackageDetailsDialog.ShowFormDialog(_MediaPlan, RowHandle) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        EnableOrDisableActions()

                        Try

                            DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle = RowHandle
                            DataGridViewForm_DetailLines.CurrentView.FocusedColumn = DataGridViewForm_DetailLines.CurrentView.Columns(GridColumn.FieldName)
                            DataGridViewForm_DetailLines.CurrentView.SelectCell(RowHandle, DataGridViewForm_DetailLines.CurrentView.FocusedColumn)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

        End Sub
        Private Sub RepositoryItemButtonEditPackagePlacement_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim RowHandle As Integer = 0
            Dim [Continue] As Boolean = True

            If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis AndAlso DataGridViewForm_DetailLines.IsNewItemRow = False Then

                Try

                    GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

                Catch ex As Exception
                    GridColumn = Nothing
                End Try

                If GridColumn IsNot Nothing Then

                    Try

                        RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                    Catch ex As Exception
                        RowHandle = 0
                    End Try

                    Try

                        If String.IsNullOrWhiteSpace(DataGridViewForm_DetailLines.CurrentView.GetRowCellValue(RowHandle, DataGridViewForm_DetailLines.CurrentView.Columns("PackageName"))) Then

                            [Continue] = False

                        End If

                    Catch ex As Exception

                    End Try

                    If [Continue] AndAlso AdvantageFramework.Media.Presentation.MediaPlanDetailPackagePlacementDialog.ShowFormDialog(_MediaPlan, RowHandle) = System.Windows.Forms.DialogResult.OK Then

                        Me.FormAction = WinForm.Presentation.FormActions.Loading

                        Try

                            LoadGrid()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None

                        EnableOrDisableActions()

                        Try

                            DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle = RowHandle
                            DataGridViewForm_DetailLines.CurrentView.FocusedColumn = DataGridViewForm_DetailLines.CurrentView.Columns(GridColumn.FieldName)
                            DataGridViewForm_DetailLines.CurrentView.SelectCell(RowHandle, DataGridViewForm_DetailLines.CurrentView.FocusedColumn)

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End If

        End Sub
        Private Function CheckForExistingButton(ByVal RepositoryItemButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit, ByVal ButtonPredefines As DevExpress.XtraEditors.Controls.ButtonPredefines) As Boolean

            'objects
            Dim ButtonExists As Boolean = False

            For Each EditorButton In RepositoryItemButtonEdit.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                If EditorButton.Kind = ButtonPredefines Then

                    ButtonExists = True
                    Exit For

                End If

            Next

            CheckForExistingButton = ButtonExists

        End Function
        Private Sub FieldAreaIndexChanged(ByVal MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim MediaPlanDetailLevelsList As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing
            Dim OrderNumber As Integer = 0
            Dim LastOrderNumber As Integer = 0

            MediaPlanDetailLevelsList = MediaPlanEstimate.MediaPlanDetailLevels.ToList

            For Each GridColumn In DataGridViewForm_DetailLines.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                Try

                    MediaPlanDetailLevel = MediaPlanDetailLevelsList.SingleOrDefault(Function(Entity) Entity.Description = GridColumn.FieldName)

                Catch ex As Exception
                    MediaPlanDetailLevel = Nothing
                End Try

                If MediaPlanDetailLevel IsNot Nothing Then

                    If MediaPlanDetailLevel.IsVisible Then

                        MediaPlanDetailLevel.OrderNumber = OrderNumber

                        If MediaPlanEstimate.IsDataLoaded Then

                            MediaPlanEstimate.LevelsAndLinesDataTable.Columns(GridColumn.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = OrderNumber
                            MediaPlanEstimate.LevelsAndLinesDataTable.Columns(GridColumn.FieldName).SetOrdinal(OrderNumber + 6)
                            MediaPlanEstimate.EstimateDataTable.Columns(GridColumn.FieldName).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = OrderNumber

                        End If

                        If OrderNumber > LastOrderNumber Then

                            LastOrderNumber = OrderNumber

                        End If

                        OrderNumber += 1

                        MediaPlanDetailLevelsList.Remove(MediaPlanDetailLevel)

                    End If

                End If

            Next

            For Each MediaPlanDetailLevel In MediaPlanDetailLevelsList.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                LastOrderNumber += 1

                MediaPlanDetailLevel.OrderNumber = LastOrderNumber

                If MediaPlanEstimate.IsDataLoaded Then

                    MediaPlanEstimate.LevelsAndLinesDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = LastOrderNumber
                    MediaPlanEstimate.LevelsAndLinesDataTable.Columns(MediaPlanDetailLevel.Description).SetOrdinal(LastOrderNumber + 3)
                    MediaPlanEstimate.EstimateDataTable.Columns(MediaPlanDetailLevel.Description).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString) = LastOrderNumber

                End If

            Next

        End Sub
        Private Sub SaveFieldWith(ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing

            'If _MediaPlan.SyncDetailSettings Then

            '    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

            '        If GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

            '            MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString, True, GridColumn.Width)

            '        ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

            '            MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString, True, GridColumn.Width)

            '        Else

            '            MediaPlanEstimate.SaveFieldWidth(GridColumn.FieldName, True, GridColumn.Width)

            '        End If

            '    Next

            'ElseIf _MediaPlan.SyncDetailSettings = False AndAlso _MediaPlan.SyncFieldWidths = True Then

            '    For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

            '        If GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

            '            MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString, True, GridColumn.Width)

            '        ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

            '            MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString, True, GridColumn.Width)

            '        Else

            '            MediaPlanDetailLevel = MediaPlanEstimate.MediaPlanDetailLevels.FirstOrDefault(Function(Entity) Entity.OrderNumber = GridColumn.VisibleIndex)

            '            MediaPlanEstimate.SaveFieldWidth(GridColumn.FieldName, True, GridColumn.Width)

            '        End If

            '    Next

            'Else

            If GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowPackageLevels.ToString, True, GridColumn.Width)

            ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.PackagePlacementWidth.ToString, True, GridColumn.Width)

            ElseIf GridColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(AdvantageFramework.MediaPlanning.Settings.ShowAdSizes.ToString, True, GridColumn.Width)

            Else

                _MediaPlan.MediaPlanEstimate.SaveFieldWidth(GridColumn.FieldName, True, GridColumn.Width)

            End If

            _MediaPlan.MediaPlanEstimate.FieldsChanged()

            'End If

            _MediaPlan.EstimateChangedEvent()

        End Sub
        Private Function IsInBroadcastMonth(ByVal EntryDate As Date, ByVal Month As Integer) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim Year As Integer = 0
            Dim EntryDateMonth As Integer = 0

            EntryDateMonth = AdvantageFramework.MediaPlanning.GetMonthForEstimate(EntryDate, _MediaPlan.MediaPlanEstimate.IsCalendarMonth, _MediaPlan.BroadcastCalendarWeeks, Year)

            If EntryDateMonth = Month Then

                IsValid = True

            End If

            IsInBroadcastMonth = IsValid

        End Function
        Private Sub SubItemGridLookUpEditControl_QueryPopup(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim Vendor As String = String.Empty
            Dim PackageNames As Generic.List(Of String) = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim RowHandle As Integer = 0

            If TypeOf DataGridViewForm_DetailLines.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_DetailLines.CurrentView.ActiveEditor

                BindingSource = New System.Windows.Forms.BindingSource

                Try

                    RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                Catch ex As Exception
                    RowHandle = 0
                End Try

                Try

                    MediaPlanDetailLevel = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.SingleOrDefault(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor)

                Catch ex As Exception

                End Try

                If MediaPlanDetailLevel IsNot Nothing Then

                    Try

                        MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = RowHandle)

                    Catch ex As Exception

                    End Try

                    If MediaPlanDetailLevelLine IsNot Nothing Then

                        Vendor = MediaPlanDetailLevelLine.Description

                    End If

                End If

                PackageNames = New Generic.List(Of String)

                If String.IsNullOrWhiteSpace(Vendor) = False AndAlso MediaPlanDetailLevel IsNot Nothing Then

                    For Each DataRow In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                        If DataRow(MediaPlanDetailLevel.Description) = Vendor Then

                            If String.IsNullOrWhiteSpace(DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)) = False AndAlso
                                    PackageNames.Contains(DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString)) = False Then

                                PackageNames.Add(DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString))

                            End If

                        End If

                    Next

                End If

                BindingSource.DataSource = PackageNames.Select(Function(PackageName) New With {.Name = PackageName, .Value = PackageName}).ToList

                GridLookUpEdit.Properties.DataSource = BindingSource

                If TypeOf DataGridViewForm_DetailLines.CurrentView.FocusedColumn.ColumnEdit Is AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                    SubItemGridLookUpEditControl = DirectCast(DataGridViewForm_DetailLines.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl)

                    AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(GridLookUpEdit.Properties.DataSource, SubItemGridLookUpEditControl.DisplayMember, SubItemGridLookUpEditControl.ValueMember,
                                                                                                          "[" & AdvantageFramework.StringUtilities.GetNameAsWords(SubItemGridLookUpEditControl.ExtraComboBoxItem.ToString) & "]",
                                                                                                          String.Empty,
                                                                                                          True, True, Nothing)

                End If

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            If TypeOf e.NewValue Is System.DBNull Then

                e.NewValue = String.Empty

                'ElseIf String.IsNullOrWhiteSpace(e.NewValue) Then

                '    e.NewValue = String.Empty

            ElseIf _MediaPlan.MediaPlanEstimate.PackageNames.Contains(e.NewValue) = False Then

                e.NewValue = String.Empty

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim MediaPlanDetailLevelLineDataIDs() As Integer = Nothing

            If _MediaPlan.MediaPlanEstimate.SalesClassType = "I" AndAlso
                    _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                    _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor) Then

                RadioButtonForm_None.Enabled = True
                RadioButtonForm_AdSize.Enabled = True
                RadioButtonForm_PackageLevels.Enabled = True

            Else

                RadioButtonForm_None.Enabled = False
                RadioButtonForm_AdSize.Enabled = False
                RadioButtonForm_PackageLevels.Enabled = False

            End If

            If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable IsNot Nothing Then

                ButtonForm_AddRow.Enabled = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                                              DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                                              DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                                              DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                                              DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString AndAlso
                                                                                                                                                              DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Any

                If _MediaPlan.SyncDetailSettings Then

                    ButtonForm_CopyFrom.Enabled = True

                Else

                    ButtonForm_CopyFrom.Enabled = Not _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                                                        DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                                                        DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                                                        DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                                                        DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString AndAlso
                                                                                                                                                                        DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Any

                End If

                ButtonForm_CopyLines.Enabled = (_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count > 0)
                ButtonForm_SpellCheck.Enabled = (_MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count > 0)

                If DataGridViewForm_DetailLines.CustomDeleteButton IsNot Nothing Then

                    DataGridViewForm_DetailLines.CustomDeleteButton.Visible = True

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DbContext.Database.Connection.Open()

                        For Each DataRowView In DataGridViewForm_DetailLines.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).ToList

                            MediaPlanDetailLevelLineDataIDs = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = DataRowView.Item(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).
                                                                                                                                                 Select(Function(DR) CInt(DR(AdvantageFramework.MediaPlanning.DataColumns.MediaPlanDetailLevelLineDataID.ToString))).ToArray

                            MediaPlanDetailLevelLineDataIDs = MediaPlanDetailLevelLineDataIDs.Where(Function(ID) ID > 0).ToArray

                            MediaPlanDetailLevelLineDataIDs = MediaPlanDetailLevelLineDataIDs.Distinct.ToArray

                            If (From MediaPlanDetailLevelLineData In DbContext.GetQuery(Of Database.Entities.MediaPlanDetailLevelLineData)
                                Where MediaPlanDetailLevelLineDataIDs.Contains(MediaPlanDetailLevelLineData.ID)
                                Select MediaPlanDetailLevelLineData).Where(Function(MPDLLD) MPDLLD.OrderNumber IsNot Nothing OrElse MPDLLD.HasPendingOrders = True).Any Then

                                DataGridViewForm_DetailLines.CustomDeleteButton.Visible = False

                                Exit For

                            End If

                        Next

                    End Using

                End If

            Else

                ButtonForm_AddRow.Enabled = False
                ButtonForm_CopyFrom.Enabled = False
                ButtonForm_CopyLines.Enabled = False

                If DataGridViewForm_DetailLines.CustomDeleteButton IsNot Nothing Then

                    DataGridViewForm_DetailLines.CustomDeleteButton.Visible = False

                End If

                ButtonForm_SpellCheck.Enabled = False

            End If

        End Sub
        Private Sub MoveRowUp(DataRow As System.Data.DataRow, Index As Integer, OldIndex As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            Try

                If OldIndex > 0 Then

                    _MediaPlan.MediaPlanEstimate.IsLevelsAndLinesDataTableSaving = True

                    NewDataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow()

                    NewDataRow.ItemArray = DataRow.ItemArray

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Remove(DataRow)
                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.InsertAt(NewDataRow, Index)

                    _MediaPlan.MediaPlanEstimate.IsLevelsAndLinesDataTableSaving = False

                    _MediaPlan.MediaPlanEstimate.ChangeRowIndexes(OldIndex, Index)

                End If

            Catch ex As Exception

            End Try

            Try

                UpdateRowIndexes()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub MoveRowDown(DataRow As System.Data.DataRow, Index As Integer, OldIndex As Integer)

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing

            Try

                If OldIndex < _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Count - 1 Then

                    _MediaPlan.MediaPlanEstimate.IsLevelsAndLinesDataTableSaving = True

                    NewDataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow()

                    NewDataRow.ItemArray = DataRow.ItemArray

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Remove(DataRow)
                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.InsertAt(NewDataRow, Index)

                    _MediaPlan.MediaPlanEstimate.IsLevelsAndLinesDataTableSaving = False

                    _MediaPlan.MediaPlanEstimate.ChangeRowIndexes(OldIndex, Index)

                End If

            Catch ex As Exception

            End Try

            Try

                UpdateRowIndexes()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub UpdateRowIndexes()

            For Each LLDataRow In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Select()

                LLDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(LLDataRow)

            Next

        End Sub
        Private Sub SetPackageLevel()

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso
                    _MediaPlan IsNot Nothing AndAlso _MediaPlan.MediaPlanEstimate IsNot Nothing Then

                If RadioButtonForm_None.Checked Then

                    _MediaPlan.MediaPlanEstimate.ShowPackageLevels = AdvantageFramework.MediaPlanning.ShowPackageLevel.None

                ElseIf RadioButtonForm_AdSize.Checked Then

                    _MediaPlan.MediaPlanEstimate.ShowPackageLevels = AdvantageFramework.MediaPlanning.ShowPackageLevel.AdSize

                ElseIf RadioButtonForm_PackageLevels.Checked Then

                    _MediaPlan.MediaPlanEstimate.ShowPackageLevels = AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel

                End If

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None

            End If

        End Sub
        Private Sub AddSubItemMemoItem(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn,
                                       ByVal Session As AdvantageFramework.Security.Session)

            Dim SubItemMemoEdit As AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit = Nothing

            SubItemMemoEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemMemoEdit(Session, GridColumn.FieldName, Nothing)

            If SubItemMemoEdit IsNot Nothing Then

                DataGridView.GridControl.RepositoryItems.Add(SubItemMemoEdit)

                GridColumn.ColumnEdit = SubItemMemoEdit

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailLevelsAndLinesDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesDialog = Nothing

            MediaPlanDetailLevelsAndLinesDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesDialog(MediaPlan)

            ShowFormDialog = MediaPlanDetailLevelsAndLinesDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailLevelsAndLinesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaPlanDetailLevelsList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevel) = Nothing
            Dim MediaPlanDetailLevelLinesList As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine) = Nothing
            Dim RowIndex As Integer = -1

            Me.ShowUnsavedChangesOnFormClosing = False

            RadioButtonForm_None.Visible = (_MediaPlan.MediaPlanEstimate.SalesClassType = "I")
            RadioButtonForm_AdSize.Visible = (_MediaPlan.MediaPlanEstimate.SalesClassType = "I")
            RadioButtonForm_PackageLevels.Visible = (_MediaPlan.MediaPlanEstimate.SalesClassType = "I")

            DataGridViewForm_DetailLines.ItemDescription = "Level/Line(s)"

            DataGridViewForm_DetailLines.OptionsView.ShowFooter = False
            DataGridViewForm_DetailLines.UseEmbeddedNavigator = True 'Not _MediaPlan.IsApproved

            DataGridViewForm_DetailLines.CustomCancelEditButton.Visible = False

            DataGridViewForm_DetailLines.OptionsCustomization.AllowColumnMoving = True 'Not _MediaPlan.IsApproved
            DataGridViewForm_DetailLines.OptionsCustomization.AllowSort = False
            DataGridViewForm_DetailLines.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_DetailLines.OptionsCustomization.AllowGroup = False
            DataGridViewForm_DetailLines.OptionsCustomization.AllowFilter = False
            DataGridViewForm_DetailLines.OptionsCustomization.AllowRowSizing = False
            DataGridViewForm_DetailLines.OptionsCustomization.AllowColumnResizing = True 'Not _MediaPlan.IsApproved

            DataGridViewForm_DetailLines.OptionsMenu.EnableColumnMenu = True 'Not _MediaPlan.IsApproved

            DataGridViewForm_DetailLines.AllowDragAndDrop = True

            ButtonForm_MoveUp.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonForm_MoveDown.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonForm_AddLevel.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonForm_AddRow.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonForm_CopyLines.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonItemCopyLines_IncludeData.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonItemCopyLines_LinesOnly.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            ButtonForm_CopyFrom.SecurityEnabled = True 'Not _MediaPlan.IsApproved
            DataGridViewForm_DetailLines.OptionsBehavior.Editable = True 'Not _MediaPlan.IsApproved

            If DataGridViewForm_DetailLines.CustomDeleteButton IsNot Nothing Then

                DataGridViewForm_DetailLines.CustomDeleteButton.Enabled = True 'Not _MediaPlan.IsApproved

            End If

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            If _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.None) Then

                RadioButtonForm_None.Checked = True

            ElseIf _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.AdSize) Then

                RadioButtonForm_AdSize.Checked = True

            ElseIf _MediaPlan.MediaPlanEstimate.ShowPackageLevels.Equals(AdvantageFramework.MediaPlanning.ShowPackageLevel.PackageLevel) Then

                RadioButtonForm_PackageLevels.Checked = True

            End If

            _RowOriginalEndDates = New Generic.Dictionary(Of Integer, Date)

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanDetailLevelsAndLinesDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.TagTypes = AdvantageFramework.MediaPlanning.TagTypes.Default
            Dim SubItemDateInput As AdvantageFramework.WinForm.Presentation.Controls.SubItemDateInput = Nothing
            Dim Width As Integer = 0
            Dim MaxLength As Long = -1

            EnableOrDisableActions()

            'If CheckBoxForm_PackageLevels.Visible Then

            '    Me.FormAction = WinForm.Presentation.FormActions.Loading

            '    CheckBoxForm_PackageLevels.Checked = _MediaPlan.MediaPlanEstimate.ShowPackageLevels

            '    Me.FormAction = WinForm.Presentation.FormActions.None

            'End If

            If DataGridViewForm_DetailLines.HasASelectedRow Then

                For Each GridColumn In DataGridViewForm_DetailLines.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    TagType = MediaPlanning.TagTypes.Default

                    Try

                        If GridColumn.Tag IsNot Nothing AndAlso TypeOf GridColumn.Tag Is System.Data.DataColumn Then

                            TagType = CType(CType(GridColumn.Tag, System.Data.DataColumn).ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString), AdvantageFramework.MediaPlanning.TagTypes)

                        End If

                    Catch ex As Exception
                        TagType = AdvantageFramework.MediaPlanning.TagTypes.Default
                    End Try

                    If TagType = MediaPlanning.TagTypes.StartDate OrElse
                            TagType = MediaPlanning.TagTypes.EndDate Then

                        DataGridViewForm_DetailLines.CurrentView.FocusedColumn = GridColumn

                        DataGridViewForm_DetailLines.CurrentView.ShowEditor()

                        If TypeOf DataGridViewForm_DetailLines.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

                            CType(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).ShowPopup()
                            CType(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).ClosePopup()

                            Do Until DataGridViewForm_DetailLines.CurrentView.ActiveEditor Is Nothing OrElse CType(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).IsPopupOpen = False

                                DataGridViewForm_DetailLines.CurrentView.CloseEditor()

                            Loop

                        End If

                    End If

                Next

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_CopyFrom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_CopyFrom.Click

            'objects
            Dim ContinueCopying As Boolean = False
            Dim ErrorMessage As String = ""

            If _MediaPlan.HasChanged Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before copying levels\lines.  Do you want to save your changes now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = WinForm.MessageBox.DialogResults.Yes Then

                    ContinueCopying = _MediaPlan.Save(ErrorMessage)

                    If ContinueCopying = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Failed saving this media plan.  Please contact Software Support." & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            Else

                ContinueCopying = True

            End If

            If ContinueCopying Then

                If AdvantageFramework.Media.Presentation.MediaPlanDetailLevelsAndLinesCopyDialog.ShowFormDialog(_MediaPlan.ID, _MediaPlan.MediaPlanEstimate.ID) = Windows.Forms.DialogResult.OK Then

                    _MediaPlan.Refresh(_MediaPlan.MediaPlanEstimate.ID, False)

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None

                    _MediaPlan.EstimateChangedEvent()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_ColumnPositionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_DetailLines.ColumnPositionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewForm_DetailLines.CurrentView.FocusedColumn IsNot Nothing Then

                    If _MediaPlan.SyncDetailSettings Then

                        For Each MediaPlanEstimate In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).ToList

                            FieldAreaIndexChanged(MediaPlanEstimate)

                            MediaPlanEstimate.FieldsChanged()

                        Next

                    Else

                        FieldAreaIndexChanged(_MediaPlan.MediaPlanEstimate)

                        _MediaPlan.MediaPlanEstimate.FieldsChanged()

                    End If

                    _MediaPlan.EstimateChangedEvent()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_ColumnWidthChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ColumnEventArgs) Handles DataGridViewForm_DetailLines.ColumnWidthChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.Column IsNot Nothing Then

                    SaveFieldWith(e.Column)

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewForm_DetailLines.EmbeddedNavigatorButtonClick

            'objects
            Dim RowIndex As Integer = -1

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewForm_DetailLines.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete this row?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            Me.FormAction = WinForm.Presentation.FormActions.Deleting

                            Try

                                For Each DataRow In DataGridViewForm_DetailLines.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(Entity) Entity.Row).ToList

                                    RowIndex = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Remove(DataRow)

                                Next

                                For Each DataRow In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.OfType(Of System.Data.DataRow).ToList

                                    _MediaPlan.MediaPlanEstimate.ChangeRowIndexes(DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString), _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow))

                                    DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                                Next

                            Catch ex As Exception

                            End Try

                            Me.FormAction = WinForm.Presentation.FormActions.None

                            If DataGridViewForm_DetailLines.CheckForModifiedRows = False Then

                                Me.ClearChanged()

                            End If

                        End If

                        e.Handled = True

                End Select

                If e.Handled Then

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_PopupMenuShowingEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_DetailLines.PopupMenuShowingEvent

            'objects
            Dim DXMenuItem As DevExpress.Utils.Menu.DXMenuItem = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem).ToList

                    If TypeOf MenuItem.Tag Is DevExpress.XtraGrid.Localization.GridStringId Then

                        If MenuItem.Tag = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFit Then

                            AddHandler MenuItem.Click, AddressOf BestFitColumn

                            MenuItem.Visible = True

                        ElseIf MenuItem.Tag = DevExpress.XtraGrid.Localization.GridStringId.MenuColumnBestFitAllColumns Then

                            AddHandler MenuItem.Click, AddressOf BestFitAllColumns

                            MenuItem.Visible = True

                        Else

                            MenuItem.Visible = False

                        End If

                    Else

                        MenuItem.Visible = False

                    End If

                Next

                DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Add New Level", New EventHandler(AddressOf AddNewLevel))

                DXMenuItem.BeginGroup = True

                e.Menu.Items.Add(DXMenuItem)

                DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Edit Level", New EventHandler(AddressOf EditLevel))

                DXMenuItem.Tag = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column

                If e.HitInfo.Column Is Nothing Then

                    DXMenuItem.Enabled = False

                ElseIf e.HitInfo.Column IsNot Nothing AndAlso (e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString OrElse
                                                               e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString OrElse
                                                               e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) Then

                    DXMenuItem.Enabled = False

                Else

                    DXMenuItem.Enabled = True

                End If

                e.Menu.Items.Add(DXMenuItem)

                DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem("Delete Level", New EventHandler(AddressOf DeleteLevel))

                DXMenuItem.Tag = DirectCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewColumnMenu).Column

                If e.HitInfo.Column Is Nothing Then

                    DXMenuItem.Enabled = False

                ElseIf e.HitInfo.Column IsNot Nothing AndAlso (e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString OrElse
                                                               e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString OrElse
                                                               e.HitInfo.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) Then

                    DXMenuItem.Enabled = False

                ElseIf _MediaPlan.MediaPlanEstimate.HasMediaOrder Then

                    DXMenuItem.Enabled = False

                ElseIf _MediaPlan.SyncDetailSettings AndAlso _MediaPlan.HasMediaOrder Then

                    DXMenuItem.Enabled = False

                Else

                    DXMenuItem.Enabled = True

                End If

                e.Menu.Items.Add(DXMenuItem)

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_DetailLines.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_DetailLines_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_DetailLines.ShownEditorEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.TagTypes = AdvantageFramework.MediaPlanning.TagTypes.Default
            Dim MediaPlanDetailLevelID As Integer = 0
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim RowIndex As Integer = 0
            Dim ShowButton As Boolean = True

            Try

                GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

            Catch ex As Exception
                GridColumn = Nothing
            End Try

            If GridColumn IsNot Nothing Then

                Try

                    RowIndex = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                Catch ex As Exception
                    RowIndex = 0
                End Try

                Try

                    DataColumn = GridColumn.Tag

                Catch ex As Exception
                    DataColumn = Nothing
                End Try

                If DataColumn IsNot Nothing Then

                    Try

                        TagType = CInt(DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString))

                    Catch ex As Exception
                        TagType = AdvantageFramework.MediaPlanning.TagTypes.Default
                    End Try

                End If

            End If

            If TypeOf DataGridViewForm_DetailLines.CurrentView.ActiveEditor Is DevExpress.XtraEditors.DateEdit Then

                Me.FormAction = WinForm.Presentation.FormActions.Loading

                If TagType = AdvantageFramework.MediaPlanning.TagTypes.StartDate Then

                    If String.IsNullOrWhiteSpace(DataGridViewForm_DetailLines.CurrentView.FocusedValue) = False AndAlso IsDate(DataGridViewForm_DetailLines.CurrentView.FocusedValue) Then

                        DirectCast(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).EditValue = CDate(CDate(DataGridViewForm_DetailLines.CurrentView.FocusedValue).ToShortDateString)

                    End If

                ElseIf TagType = AdvantageFramework.MediaPlanning.TagTypes.EndDate Then

                    If _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = RowIndex).Any(Function(Entity) Entity.OrderNumber IsNot Nothing OrElse Entity.HasPendingOrders = True) Then

                        If String.IsNullOrWhiteSpace(DataGridViewForm_DetailLines.CurrentView.FocusedValue) = False AndAlso IsDate(DataGridViewForm_DetailLines.CurrentView.FocusedValue) Then

                            If _RowOriginalEndDates.ContainsKey(RowIndex) = False Then

                                _RowOriginalEndDates.Add(RowIndex, DataGridViewForm_DetailLines.CurrentView.FocusedValue)

                            End If

                        End If

                        If _RowOriginalEndDates.ContainsKey(RowIndex) Then

                            DirectCast(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = _RowOriginalEndDates(RowIndex)

                        End If

                    Else

                        DirectCast(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).Properties.MinValue = _MediaPlan.StartDate

                    End If

                    If String.IsNullOrWhiteSpace(DataGridViewForm_DetailLines.CurrentView.FocusedValue) = False AndAlso IsDate(DataGridViewForm_DetailLines.CurrentView.FocusedValue) Then

                        DirectCast(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.DateEdit).EditValue = CDate(CDate(DataGridViewForm_DetailLines.CurrentView.FocusedValue).ToShortDateString)

                    End If

                End If

                Me.FormAction = WinForm.Presentation.FormActions.None

            ElseIf TypeOf DataGridViewForm_DetailLines.CurrentView.ActiveEditor Is DevExpress.XtraEditors.ButtonEdit Then

                If TagType = MediaPlanning.Methods.TagTypes.Vendor Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        If AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailIDAndRowIndex(DbContext, _MediaPlan.MediaPlanEstimate.ID, DirectCast(DataGridViewForm_DetailLines.CurrentView.GetRow(DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle), System.Data.DataRowView).Item("RowIndex")).Where(Function(MPDLLD) MPDLLD.OrderNumber IsNot Nothing OrElse MPDLLD.HasPendingOrders = True).Any Then

                            ShowButton = False

                        Else

                            ShowButton = True

                        End If

                    End Using

                Else

                    ShowButton = True

                End If

                For Each EditorButton In DirectCast(DataGridViewForm_DetailLines.CurrentView.ActiveEditor, DevExpress.XtraEditors.ButtonEdit).Properties.Buttons.OfType(Of DevExpress.XtraEditors.Controls.EditorButton)()

                    If EditorButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis Then

                        EditorButton.Visible = ShowButton
                        Exit For

                    End If

                Next

            End If

        End Sub
        Private Sub ButtonForm_AddLevel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_AddLevel.Click

            AddNewLevel(sender, e)

        End Sub
        Private Sub ButtonForm_AddRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_AddRow.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim TagType As AdvantageFramework.MediaPlanning.TagTypes = MediaPlanning.TagTypes.Default

            If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).Where(Function(DC) DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                                                                                                                                 DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                                                                                                                 DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                                                                                                                                 DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                                                                                                                 DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString AndAlso
                                                                                                                                 DC.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).Any Then

                Me.FormAction = WinForm.Presentation.FormActions.Adding
                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding...")

                Try

                    DataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add()

                Catch ex As Exception

                End Try

                For Each DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                    Try

                        TagType = MediaPlanning.TagTypes.Default

                        If DataColumn.ExtendedProperties.Contains(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString) Then

                            TagType = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.TagType.ToString)

                            If TagType = MediaPlanning.TagTypes.StartDate Then

                                AddStartOrEndDateTag(DataColumn, DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString), _MediaPlan.StartDate)

                            ElseIf TagType = MediaPlanning.TagTypes.EndDate Then

                                AddStartOrEndDateTag(DataColumn, DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString), _MediaPlan.EndDate)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Next

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemCopyLines_LinesOnly_Click(sender As Object, e As EventArgs) Handles ButtonItemCopyLines_LinesOnly.Click

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing
            'Dim NewMediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Copying
            Me.ShowWaitForm()
            Me.ShowWaitForm("Copying...")

            Try

                For Each DataRow In DataGridViewForm_DetailLines.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(Entity) Entity.Row).ToList

                    NewDataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow()

                    For Each DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                        If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                            NewDataRow(DataColumn) = DataRow(DataColumn)

                        End If

                    Next

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(NewDataRow)

                    Try

                        For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.ToList

                            Try

                                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString))

                            Catch ex As Exception
                                MediaPlanDetailLevelLine = Nothing
                            End Try

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                Try

                                    NewMediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString))

                                Catch ex As Exception
                                    NewMediaPlanDetailLevelLine = Nothing
                                End Try

                                If NewMediaPlanDetailLevelLine IsNot Nothing Then

                                    NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                    NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                    'NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                    Try

                                        MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault

                                    Catch ex As Exception
                                        MediaPlanDetailLevelLineTag = Nothing
                                    End Try

                                    If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                        NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                        NewMediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext

                                        _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(NewMediaPlanDetailLevelLine, NewMediaPlanDetailLevelLineTag)

                                        NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                                        NewMediaPlanDetailLevelLineTag.MediaPlanID = _MediaPlan.ID
                                        NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                        NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode
                                        NewMediaPlanDetailLevelLineTag.VendorCommission = MediaPlanDetailLevelLineTag.VendorCommission
                                        NewMediaPlanDetailLevelLineTag.VendorMarkup = MediaPlanDetailLevelLineTag.VendorMarkup
                                        NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                        NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                        NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                        NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                        NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                        NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                        NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                        NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                        NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                        NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                        NewMediaPlanDetailLevelLineTag.CampaignID = MediaPlanDetailLevelLineTag.CampaignID
                                        NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                        NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                        NewMediaPlanDetailLevelLineTag.CreatedByUserCode = Session.UserCode
                                        NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                        NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                    End If

                                End If

                            End If

                        Next

                        For Each MediaPlanDetailPackageDetail In _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                            NewMediaPlanDetailPackageDetail = New AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail

                            NewMediaPlanDetailPackageDetail.MediaPlanID = _MediaPlan.ID
                            NewMediaPlanDetailPackageDetail.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                            NewMediaPlanDetailPackageDetail.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)
                            NewMediaPlanDetailPackageDetail.MediaType = MediaPlanDetailPackageDetail.MediaType
                            NewMediaPlanDetailPackageDetail.SizeCode = MediaPlanDetailPackageDetail.SizeCode
                            NewMediaPlanDetailPackageDetail.CreatedByUserCode = Me.Session.UserCode
                            NewMediaPlanDetailPackageDetail.CreatedDate = Now

                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackageDetail(NewMediaPlanDetailPackageDetail)

                        Next

                        'For Each MediaPlanDetailPackagePlacementName In _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                        '    NewMediaPlanDetailPackagePlacementName = New AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName

                        '    NewMediaPlanDetailPackagePlacementName.MediaPlanID = _MediaPlan.ID
                        '    NewMediaPlanDetailPackagePlacementName.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                        '    NewMediaPlanDetailPackagePlacementName.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)
                        '    NewMediaPlanDetailPackagePlacementName.PlacementName = MediaPlanDetailPackagePlacementName.PlacementName
                        '    NewMediaPlanDetailPackagePlacementName.CreatedByUserCode = Me.Session.UserCode
                        '    NewMediaPlanDetailPackagePlacementName.CreatedDate = Now

                        '    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackagePlacement(NewMediaPlanDetailPackagePlacementName)

                        'Next

                    Catch ex As Exception

                    End Try

                Next

                DataGridViewForm_DetailLines.CurrentView.RefreshData()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemCopyLines_IncludeData_Click(sender As Object, e As EventArgs) Handles ButtonItemCopyLines_IncludeData.Click

            'objects
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim EstimateDataRow As System.Data.DataRow = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MPDLLD As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing
            Dim MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel = Nothing
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim NewMediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim MediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailLevelLineTag As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag = Nothing
            Dim NewMediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing
            'Dim NewMediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Copying
            Me.ShowWaitForm()
            Me.ShowWaitForm("Copying...")

            Try

                For Each DataRow In DataGridViewForm_DetailLines.GetAllSelectedRowsDataBoundItems.OfType(Of System.Data.DataRowView).Select(Function(Entity) Entity.Row).ToList

                    NewDataRow = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.NewRow()

                    For Each DataColumn In _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).ToList

                        If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                                DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                                DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                            NewDataRow(DataColumn) = DataRow(DataColumn)

                        End If

                    Next

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Add(NewDataRow)

                    Try

                        For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.ToList

                            Try

                                MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString))

                            Catch ex As Exception
                                MediaPlanDetailLevelLine = Nothing
                            End Try

                            If MediaPlanDetailLevelLine IsNot Nothing Then

                                Try

                                    NewMediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString))

                                Catch ex As Exception
                                    NewMediaPlanDetailLevelLine = Nothing
                                End Try

                                If NewMediaPlanDetailLevelLine IsNot Nothing Then

                                    NewMediaPlanDetailLevelLine.IsCPM = MediaPlanDetailLevelLine.IsCPM
                                    NewMediaPlanDetailLevelLine.QuantityColumn = MediaPlanDetailLevelLine.QuantityColumn
                                    'NewMediaPlanDetailLevelLine.PackageName = MediaPlanDetailLevelLine.PackageName

                                    Try

                                        MediaPlanDetailLevelLineTag = MediaPlanDetailLevelLine.MediaPlanDetailLevelLineTags.SingleOrDefault

                                    Catch ex As Exception
                                        MediaPlanDetailLevelLineTag = Nothing
                                    End Try

                                    If MediaPlanDetailLevelLineTag IsNot Nothing Then

                                        NewMediaPlanDetailLevelLineTag = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineTag

                                        NewMediaPlanDetailLevelLineTag.DbContext = _MediaPlan.DbContext

                                        _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineTag(NewMediaPlanDetailLevelLine, NewMediaPlanDetailLevelLineTag)

                                        NewMediaPlanDetailLevelLineTag.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                                        NewMediaPlanDetailLevelLineTag.MediaPlanID = _MediaPlan.ID
                                        NewMediaPlanDetailLevelLineTag.MarketCode = MediaPlanDetailLevelLineTag.MarketCode
                                        NewMediaPlanDetailLevelLineTag.VendorCode = MediaPlanDetailLevelLineTag.VendorCode
                                        NewMediaPlanDetailLevelLineTag.VendorCommission = MediaPlanDetailLevelLineTag.VendorCommission
                                        NewMediaPlanDetailLevelLineTag.VendorMarkup = MediaPlanDetailLevelLineTag.VendorMarkup
                                        NewMediaPlanDetailLevelLineTag.MediaType = MediaPlanDetailLevelLineTag.MediaType
                                        NewMediaPlanDetailLevelLineTag.SizeCode = MediaPlanDetailLevelLineTag.SizeCode
                                        NewMediaPlanDetailLevelLineTag.InternetTypeCode = MediaPlanDetailLevelLineTag.InternetTypeCode
                                        NewMediaPlanDetailLevelLineTag.DaypartID = MediaPlanDetailLevelLineTag.DaypartID
                                        NewMediaPlanDetailLevelLineTag.StartDate = MediaPlanDetailLevelLineTag.StartDate
                                        NewMediaPlanDetailLevelLineTag.EndDate = MediaPlanDetailLevelLineTag.EndDate
                                        NewMediaPlanDetailLevelLineTag.OutOfHomeTypeCode = MediaPlanDetailLevelLineTag.OutOfHomeTypeCode
                                        NewMediaPlanDetailLevelLineTag.AdNumber = MediaPlanDetailLevelLineTag.AdNumber
                                        NewMediaPlanDetailLevelLineTag.JobNumber = MediaPlanDetailLevelLineTag.JobNumber
                                        NewMediaPlanDetailLevelLineTag.JobComponentNumber = MediaPlanDetailLevelLineTag.JobComponentNumber
                                        NewMediaPlanDetailLevelLineTag.CampaignID = MediaPlanDetailLevelLineTag.CampaignID
                                        NewMediaPlanDetailLevelLineTag.MediaChannelID = MediaPlanDetailLevelLineTag.MediaChannelID
                                        NewMediaPlanDetailLevelLineTag.MediaTacticID = MediaPlanDetailLevelLineTag.MediaTacticID

                                        NewMediaPlanDetailLevelLineTag.CreatedByUserCode = Session.UserCode
                                        NewMediaPlanDetailLevelLineTag.CreatedDate = Now
                                        NewMediaPlanDetailLevelLineTag.ModifiedByUserCode = Nothing
                                        NewMediaPlanDetailLevelLineTag.ModifiedDate = Nothing

                                    End If

                                End If

                            End If

                        Next

                        For Each MediaPlanDetailPackageDetail In _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                            NewMediaPlanDetailPackageDetail = New AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail

                            NewMediaPlanDetailPackageDetail.MediaPlanID = _MediaPlan.ID
                            NewMediaPlanDetailPackageDetail.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                            NewMediaPlanDetailPackageDetail.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)
                            NewMediaPlanDetailPackageDetail.MediaType = MediaPlanDetailPackageDetail.MediaType
                            NewMediaPlanDetailPackageDetail.SizeCode = MediaPlanDetailPackageDetail.SizeCode
                            NewMediaPlanDetailPackageDetail.CreatedByUserCode = Me.Session.UserCode
                            NewMediaPlanDetailPackageDetail.CreatedDate = Now

                            _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackageDetail(NewMediaPlanDetailPackageDetail)

                        Next

                        'For Each MediaPlanDetailPackagePlacementName In _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                        '    NewMediaPlanDetailPackagePlacementName = New AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName

                        '    NewMediaPlanDetailPackagePlacementName.MediaPlanID = _MediaPlan.ID
                        '    NewMediaPlanDetailPackagePlacementName.MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
                        '    NewMediaPlanDetailPackagePlacementName.RowIndex = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)
                        '    NewMediaPlanDetailPackagePlacementName.PlacementName = MediaPlanDetailPackagePlacementName.PlacementName
                        '    NewMediaPlanDetailPackagePlacementName.CreatedByUserCode = Me.Session.UserCode
                        '    NewMediaPlanDetailPackagePlacementName.CreatedDate = Now

                        '    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackagePlacement(NewMediaPlanDetailPackagePlacementName)

                        'Next

                    Catch ex As Exception

                    End Try

                    _MediaPlan.MediaPlanEstimate.IsEstimateDataTableSaving = True

                    Try

                        For Each MPDLLD In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.Where(Function(Entity) Entity.RowIndex = DataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString)).ToList

                            Try

                                EstimateDataRow = _MediaPlan.MediaPlanEstimate.EstimateDataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) = NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString) AndAlso DR(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString) = MPDLLD.StartDate)

                            Catch ex As Exception
                                EstimateDataRow = Nothing
                            End Try

                            If EstimateDataRow Is Nothing Then

                                EstimateDataRow = _MediaPlan.MediaPlanEstimate.AddDataRowToEstimateDataTable(Nothing, NewDataRow(AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString), MPDLLD.StartDate)

                                _MediaPlan.MediaPlanEstimate.RefreshEntryDates()

                            End If

                            If EstimateDataRow IsNot Nothing Then

                                Try

                                    MediaPlanDetailLevelLineData = _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(Entity) Entity.RowIndex = EstimateDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString) AndAlso Entity.StartDate = EstimateDataRow(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString))

                                Catch ex As Exception
                                    MediaPlanDetailLevelLineData = Nothing
                                End Try

                                If MediaPlanDetailLevelLineData Is Nothing Then

                                    MediaPlanDetailLevelLineData = New AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData

                                    _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, EstimateDataRow(AdvantageFramework.MediaPlanning.DataColumns.StartDate.ToString), EstimateDataRow(AdvantageFramework.MediaPlanning.DataColumns.RowIndex.ToString))

                                End If

                                MediaPlanDetailLevelLineData.EndDate = MPDLLD.EndDate
                                MediaPlanDetailLevelLineData.Demo1 = MPDLLD.Demo1
                                MediaPlanDetailLevelLineData.Demo2 = MPDLLD.Demo2
                                MediaPlanDetailLevelLineData.Units = MPDLLD.Units
                                MediaPlanDetailLevelLineData.Rate = MPDLLD.Rate
                                MediaPlanDetailLevelLineData.Clicks = MPDLLD.Clicks
                                MediaPlanDetailLevelLineData.Impressions = MPDLLD.Impressions
                                MediaPlanDetailLevelLineData.Dollars = MPDLLD.Dollars
                                MediaPlanDetailLevelLineData.AgencyFee = MPDLLD.AgencyFee
                                MediaPlanDetailLevelLineData.BillAmount = MPDLLD.BillAmount
                                MediaPlanDetailLevelLineData.NetCharge = MPDLLD.NetCharge
                                MediaPlanDetailLevelLineData.Columns = MPDLLD.Columns
                                MediaPlanDetailLevelLineData.InchesLines = MPDLLD.InchesLines
                                MediaPlanDetailLevelLineData.IsActualized = False

                                MediaPlanDetailLevelLineData.Note = MPDLLD.Note
                                MediaPlanDetailLevelLineData.Color = MPDLLD.Color

                                _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData, MediaPlanning.DataColumns.Color)

                            End If

                        Next

                    Catch ex As Exception

                    End Try

                    _MediaPlan.MediaPlanEstimate.IsEstimateDataTableSaving = False

                Next

                DataGridViewForm_DetailLines.CurrentView.RefreshData()

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonForm_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveUp.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_DetailLines.HasOnlyOneSelectedRow Then

                DataGridViewForm_DetailLines.CurrentView.CloseEditorForUpdating()

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Moving...")

                Try

                    DataRow = DirectCast(DataGridViewForm_DetailLines.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                    Index = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                    MoveRowUp(DataRow, Index - 1, Index)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonForm_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveDown.Click

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim NewDataRow As System.Data.DataRow = Nothing
            Dim Index As Integer = 0

            If DataGridViewForm_DetailLines.HasOnlyOneSelectedRow Then

                DataGridViewForm_DetailLines.CurrentView.CloseEditorForUpdating()

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Moving...")

                Try

                    DataRow = DirectCast(DataGridViewForm_DetailLines.GetFirstSelectedRowDataBoundItem, System.Data.DataRowView).Row

                    Index = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.IndexOf(DataRow)

                    MoveRowDown(DataRow, Index + 1, Index)

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_DetailLines.ColumnValueChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim RowHandle As Integer = 0
            Dim DataTable As System.Data.DataTable = Nothing
            Dim Matches As Integer = 0

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If IsNothing(e.Value) AndAlso e.Column IsNot Nothing AndAlso (e.Column.ColumnEditName = "StartDate" OrElse e.Column.ColumnEditName = "EndDate") Then

                    If DataGridViewForm_DetailLines.IsNewItemRow = False Then

                        Try

                            GridColumn = DataGridViewForm_DetailLines.CurrentView.FocusedColumn

                        Catch ex As Exception
                            GridColumn = Nothing
                        End Try

                        If GridColumn IsNot Nothing Then

                            Try

                                RowHandle = DataGridViewForm_DetailLines.CurrentView.FocusedRowHandle

                            Catch ex As Exception
                                RowHandle = 0
                            End Try

                            Try

                                DataColumn = GridColumn.Tag

                            Catch ex As Exception
                                DataColumn = Nothing
                            End Try

                            If DataColumn IsNot Nothing Then

                                AddStartOrEndDateTag(DataColumn, RowHandle, Nothing)

                            End If

                        End If

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                    DataTable = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable

                    If Not String.IsNullOrWhiteSpace(e.Value) Then ' DataTable.Columns("Vendor") IsNot Nothing Then

                        For Each row As System.Data.DataRow In DataTable.Rows

                            If row("PackageName").ToString.Trim.ToUpper = e.Value.ToString.Trim.ToUpper Then

                                Matches += 1

                            End If

                        Next

                        If Matches > 1 Then

                            AdvantageFramework.WinForm.MessageBox.Show("Package Name must be unique.")

                            DataGridViewForm_DetailLines.CurrentView.SetFocusedRowCellValue(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString, String.Empty)

                        End If

                        'If DataTable.Select(String.Format("PackageName ='{0}'", e.Value.ToString().Replace("'", "''"))).Count > 1 Then

                        'End If

                        'DataTable.Select("Vendor")
                        '    If e.Value Is System.DBNull.Value Then

                        '        Me.FormAction = WinForm.Presentation.FormActions.Saving

                        '        DataGridViewForm_DetailLines.CurrentView.SetFocusedRowCellValue(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString, String.Empty)

                        '        Me.FormAction = WinForm.Presentation.FormActions.None

                        '    End If

                    Else

                        _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackagePlacementNames.Clear()

                        DataGridViewForm_DetailLines.CurrentView.SetFocusedRowCellValue(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString, String.Empty)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_DetailLines.ShowingEditorEvent

            If DataGridViewForm_DetailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString Then

                If (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels Is Nothing) OrElse
                        (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                         _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor) = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_DetailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                If (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels Is Nothing) OrElse
                        (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                         _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor) = False) Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewForm_DetailLines.CurrentView.FocusedColumn.FieldName = AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString Then

                If (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels Is Nothing) OrElse
                        (_MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels IsNot Nothing AndAlso
                         _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.Any(Function(Entity) Entity.TagType = AdvantageFramework.MediaPlanning.TagTypes.Vendor) = False) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub ButtonForm_SpellCheck_Click(sender As Object, e As EventArgs) Handles ButtonForm_SpellCheck.Click

            DataGridViewForm_DetailLines.CurrentView.CloseEditorForUpdating()

            Me.SpellChecker.ShowSpellCheckCompleteMessage = False

            For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels

                If MediaPlanDetailLevel.TagType = AdvantageFramework.MediaPlanning.TagTypes.Default Then

                    For Each MediaPlanDetailLevelLine In MediaPlanDetailLevel.MediaPlanDetailLevelLines

                        MediaPlanDetailLevelLine.Description = Me.SpellChecker.Check(MediaPlanDetailLevelLine.Description)
                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(MediaPlanDetailLevelLine.RowIndex).Item(MediaPlanDetailLevel.Description) = MediaPlanDetailLevelLine.Description

                    Next

                End If

            Next

            AdvantageFramework.WinForm.MessageBox.Show("Spell Check Complete!")

        End Sub
        Private Sub DataGridViewForm_DetailLines_DragAndDropRowsEvent(TargetRowHandle As Object, RowHandles() As Integer) Handles DataGridViewForm_DetailLines.DragAndDropRowsEvent

            'objects
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1
            Dim NewTargetRowHandle As Integer = 0
            Dim DragAndDropRowHandles As Generic.List(Of Integer) = Nothing

            If RowHandles IsNot Nothing Then

                If RowHandles.All(Function(RH) RH < TargetRowHandle) Then

                    DragAndDropRowHandles = RowHandles.OrderByDescending(Function(RH) RH).ToList

                Else

                    DragAndDropRowHandles = RowHandles.OrderBy(Function(RH) RH).ToList

                End If

                NewTargetRowHandle = TargetRowHandle

                For Each RowHandle In DragAndDropRowHandles

                    Try

                        DataRow = DirectCast(DataGridViewForm_DetailLines.GetRowDataBoundItem(RowHandle), System.Data.DataRowView).Row

                    Catch ex As Exception
                        DataRow = Nothing
                    End Try

                    If DataRow IsNot Nothing Then

                        If RowHandle > NewTargetRowHandle Then

                            RowIndex = RowHandle

                            Do

                                DataRow = DirectCast(DataGridViewForm_DetailLines.GetRowDataBoundItem(RowIndex), System.Data.DataRowView).Row

                                MoveRowUp(DataRow, RowIndex - 1, RowIndex)

                                RowIndex -= 1

                            Loop Until RowIndex = NewTargetRowHandle

                        ElseIf RowHandle < TargetRowHandle Then

                            RowIndex = RowHandle

                            Do

                                DataRow = DirectCast(DataGridViewForm_DetailLines.GetRowDataBoundItem(RowIndex), System.Data.DataRowView).Row

                                MoveRowDown(DataRow, RowIndex + 1, RowIndex)

                                RowIndex += 1

                            Loop Until RowIndex = NewTargetRowHandle

                        End If

                    End If

                    If RowHandle < NewTargetRowHandle Then

                        NewTargetRowHandle -= 1

                    ElseIf RowHandle > NewTargetRowHandle Then

                        NewTargetRowHandle += 1

                    End If

                Next

            End If

        End Sub
        Private Sub RadioButtonForm_AdSize_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonForm_AdSize.CheckedChangedEx

            If e.NewChecked.Checked Then

                SetPackageLevel()

            End If

        End Sub
        Private Sub RadioButtonForm_None_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonForm_None.CheckedChangedEx

            If e.NewChecked.Checked Then

                SetPackageLevel()

            End If

        End Sub
        Private Sub RadioButtonForm_PackageLevels_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonForm_PackageLevels.CheckedChangedEx

            If e.NewChecked.Checked Then

                SetPackageLevel()

            End If

        End Sub
        Private Sub DataGridViewForm_DetailLines_DragObjectOverEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.DragObjectOverEventArgs) Handles DataGridViewForm_DetailLines.DragObjectOverEvent

            If TypeOf e.DragObject Is DevExpress.XtraGrid.Columns.GridColumn Then

                If RadioButtonForm_PackageLevels.Checked Then

                    If e.DropInfo.Index = 0 OrElse e.DropInfo.Index = 1 Then

                        e.DropInfo.Valid = False

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
