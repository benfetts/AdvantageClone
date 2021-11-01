Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeReconciliationReportColumnEditDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GridViews
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Main Grid View")>
            MainGridView = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Sub Grid View Tab 1")>
            SubGridViewTab1 = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Sub Grid View Tab 2")>
            SubGridViewTab2 = 2
        End Enum

#End Region

#Region " Variables "

        Private _MainGridViewColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
        Private _SubGridViewTab1ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
        Private _SubGridViewTab2ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn) = Nothing
        Private _SelectedGridView As GridViews = GridViews.MainGridView

#End Region

#Region " Properties "

        Private Property MainGridViewColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)
            Get
                MainGridViewColumnsList = _MainGridViewColumnsList
            End Get
            Set(ByVal value As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn))
                _MainGridViewColumnsList = value
            End Set
        End Property
        Private Property SubGridViewTab1ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)
            Get
                SubGridViewTab1ColumnsList = _SubGridViewTab1ColumnsList
            End Get
            Set(ByVal value As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn))
                _SubGridViewTab1ColumnsList = value
            End Set
        End Property
        Private Property SubGridViewTab2ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)
            Get
                SubGridViewTab2ColumnsList = _SubGridViewTab2ColumnsList
            End Get
            Set(ByVal value As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn))
                _SubGridViewTab2ColumnsList = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub SetVisibleIndexColumn()

            If DataGridViewForm_ServiceFeeReconciliationReportColumns.Columns("VisibleIndex") IsNot Nothing Then

                If DataGridViewForm_ServiceFeeReconciliationReportColumns.Columns("VisibleIndex").Visible Then

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.Columns("VisibleIndex").Visible = False

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef MainGridViewColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn), _
                                              ByRef SubGridViewTab1ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn), _
                                              ByRef SubGridViewTab2ColumnsList As Generic.List(Of AdvantageFramework.Security.Database.Classes.ServiceFeeReconciliationReportColumn)) As Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeReconciliationReportColumnEditDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportColumnEditDialog = Nothing

            ServiceFeeReconciliationReportColumnEditDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportColumnEditDialog()

            ServiceFeeReconciliationReportColumnEditDialog.MainGridViewColumnsList = MainGridViewColumnsList
            ServiceFeeReconciliationReportColumnEditDialog.SubGridViewTab1ColumnsList = SubGridViewTab1ColumnsList
            ServiceFeeReconciliationReportColumnEditDialog.SubGridViewTab2ColumnsList = SubGridViewTab2ColumnsList

            ShowFormDialog = ServiceFeeReconciliationReportColumnEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                MainGridViewColumnsList = ServiceFeeReconciliationReportColumnEditDialog.MainGridViewColumnsList
                SubGridViewTab1ColumnsList = ServiceFeeReconciliationReportColumnEditDialog.SubGridViewTab1ColumnsList
                SubGridViewTab2ColumnsList = ServiceFeeReconciliationReportColumnEditDialog.SubGridViewTab2ColumnsList

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeReconciliationReportColumnEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _MainGridViewColumnsList

            ComboBoxForm_GridView.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(GridViews))

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ComboBoxForm_GridView_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_GridView.SelectedValueChanged

            If ComboBoxForm_GridView.HasASelectedValue Then

                If _SelectedGridView = GridViews.MainGridView Then

                    _MainGridViewColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

                ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                    _SubGridViewTab1ColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

                ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                    _SubGridViewTab2ColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

                End If

                _SelectedGridView = ComboBoxForm_GridView.GetSelectedValue

                If _SelectedGridView = GridViews.MainGridView Then

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _MainGridViewColumnsList

                ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab1ColumnsList

                ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab2ColumnsList

                End If

                DataGridViewForm_ServiceFeeReconciliationReportColumns.CurrentView.BestFitColumns()

                DataGridViewForm_ServiceFeeReconciliationReportColumns.OptionsCustomization.AllowSort = True

                SetVisibleIndexColumn()

            End If

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If _SelectedGridView = GridViews.MainGridView Then

                _MainGridViewColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

            ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                _SubGridViewTab1ColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

            ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                _SubGridViewTab2ColumnsList = DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource.DataSource

            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Reset.Click

            If _SelectedGridView = GridViews.MainGridView Then
                
                If _MainGridViewColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _MainGridViewColumnsList

                        ServiceFeeReconciliationReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(ServiceFeeReconciliationReportColumn.FieldName)
                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _MainGridViewColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                If _SubGridViewTab1ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab1ColumnsList

                        ServiceFeeReconciliationReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(ServiceFeeReconciliationReportColumn.FieldName)
                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab1ColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                If _SubGridViewTab2ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab2ColumnsList

                        ServiceFeeReconciliationReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(ServiceFeeReconciliationReportColumn.FieldName)
                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab2ColumnsList

                    SetVisibleIndexColumn()

                End If

            End If

        End Sub
        Private Sub CheckBoxForm_ShowOnlyVisibleColumns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxForm_ShowOnlyVisibleColumns.CheckedChanged

            If CheckBoxForm_ShowOnlyVisibleColumns.Checked Then

                DataGridViewForm_ServiceFeeReconciliationReportColumns.CurrentView.AFActiveFilterString = "[IsVisible] = True"

            Else

                DataGridViewForm_ServiceFeeReconciliationReportColumns.CurrentView.AFActiveFilterString = ""

            End If

        End Sub
        Private Sub ButtonForm_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_SelectAll.Click

            If _SelectedGridView = GridViews.MainGridView Then

                If _MainGridViewColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _MainGridViewColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _MainGridViewColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                If _SubGridViewTab1ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab1ColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab1ColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                If _SubGridViewTab2ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab2ColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = True

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab2ColumnsList

                    SetVisibleIndexColumn()

                End If

            End If

        End Sub
        Private Sub ButtonForm_DeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_DeselectAll.Click

            If _SelectedGridView = GridViews.MainGridView Then

                If _MainGridViewColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _MainGridViewColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = False

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _MainGridViewColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab1 Then

                If _SubGridViewTab1ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab1ColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = False

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab1ColumnsList

                    SetVisibleIndexColumn()

                End If

            ElseIf _SelectedGridView = GridViews.SubGridViewTab2 Then

                If _SubGridViewTab2ColumnsList IsNot Nothing Then

                    For Each ServiceFeeReconciliationReportColumn In _SubGridViewTab2ColumnsList

                        ServiceFeeReconciliationReportColumn.IsVisible = False

                    Next

                    DataGridViewForm_ServiceFeeReconciliationReportColumns.DataSource = _SubGridViewTab2ColumnsList

                    SetVisibleIndexColumn()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace