Namespace Desktop.Presentation

    Public Class DynamicReportColumnEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn) = Nothing

#End Region

#Region " Properties "

        Private Property DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)
            Get
                DynamicReportColumnsList = _DynamicReportColumnsList
            End Get
            Set(ByVal value As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn))
                _DynamicReportColumnsList = value
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

            If DataGridViewForm_DynamicReportColumns.Columns("VisibleIndex") IsNot Nothing Then

                If DataGridViewForm_DynamicReportColumns.Columns("VisibleIndex").Visible Then

                    DataGridViewForm_DynamicReportColumns.Columns("VisibleIndex").Visible = False

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef DynamicReportColumnsList As Generic.List(Of AdvantageFramework.Database.Classes.DynamicReportColumn)) As Windows.Forms.DialogResult

            'objects
            Dim DynamicReportColumnEditDialog As AdvantageFramework.Desktop.Presentation.DynamicReportColumnEditDialog = Nothing

            DynamicReportColumnEditDialog = New AdvantageFramework.Desktop.Presentation.DynamicReportColumnEditDialog()

            DynamicReportColumnEditDialog.DynamicReportColumnsList = DynamicReportColumnsList

            ShowFormDialog = DynamicReportColumnEditDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                DynamicReportColumnsList = DynamicReportColumnEditDialog.DynamicReportColumnsList

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub DynamicReportColumnEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_DynamicReportColumns.DataSource = _DynamicReportColumnsList

            DataGridViewForm_DynamicReportColumns.CurrentView.BestFitColumns()

            DataGridViewForm_DynamicReportColumns.OptionsCustomization.AllowSort = True

            SetVisibleIndexColumn()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            _DynamicReportColumnsList = DataGridViewForm_DynamicReportColumns.DataSource.DataSource

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Reset.Click

            If _DynamicReportColumnsList IsNot Nothing Then

                For Each DynamicReportColumn In _DynamicReportColumnsList

                    If DynamicReportColumn.OriginalText <> "" Then
                        DynamicReportColumn.HeaderText = DynamicReportColumn.OriginalText
                    Else
                        DynamicReportColumn.HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(DynamicReportColumn.FieldName)
                    End If
                    DynamicReportColumn.IsVisible = True

                Next

                DataGridViewForm_DynamicReportColumns.DataSource = _DynamicReportColumnsList

                SetVisibleIndexColumn()

            End If

        End Sub
        Private Sub CheckBoxForm_ShowOnlyVisibleColumns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxForm_ShowOnlyVisibleColumns.CheckedChanged

            If _DynamicReportColumnsList IsNot Nothing Then

                If CheckBoxForm_ShowOnlyVisibleColumns.Checked Then

                    DataGridViewForm_DynamicReportColumns.CurrentView.AFActiveFilterString = "[IsVisible] = True"

                Else

                    DataGridViewForm_DynamicReportColumns.CurrentView.AFActiveFilterString = ""

                End If

            End If

        End Sub
        Private Sub ButtonForm_SelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_SelectAll.Click

            If _DynamicReportColumnsList IsNot Nothing Then

                For Each DynamicReportColumn In _DynamicReportColumnsList

                    DynamicReportColumn.IsVisible = True

                Next

                DataGridViewForm_DynamicReportColumns.DataSource = _DynamicReportColumnsList

                SetVisibleIndexColumn()

            End If

        End Sub
        Private Sub ButtonForm_DeselectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_DeselectAll.Click

            If _DynamicReportColumnsList IsNot Nothing Then

                For Each DynamicReportColumn In _DynamicReportColumnsList

                    DynamicReportColumn.IsVisible = False

                Next

                DataGridViewForm_DynamicReportColumns.DataSource = _DynamicReportColumnsList

                SetVisibleIndexColumn()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace