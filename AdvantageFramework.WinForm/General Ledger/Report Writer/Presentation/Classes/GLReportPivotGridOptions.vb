Namespace GeneralLedger.ReportWriter.Presentation.Classes

    Public Class GLReportPivotGridOptions

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ColumnTotalsLocation
            RowTotalsLocation
            HeaderHeightOffset
            HeaderWidthOffset
            RowTreeOffset
            RowTreeWidth
            ShowColumnGrandTotalHeader
            ShowColumnGrandTotals
            ShowColumnHeaders
            ShowColumnTotals
            ShowCustomTotalsForSingleValues
            ShowDataHeaders
            ShowGrandTotalsForSingleValues
            ShowHorzLines
            ShowRowGrandTotalHeader
            ShowRowGrandTotals
            ShowRowHeaders
            ShowRowTotals
            ShowTotalsForSingleValues
            ShowVertLines
        End Enum

#End Region

#Region " Variables "

        Private _PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl = Nothing
        Private _RunningTotalsInColumns As Boolean = True
        Private _HasChanged As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the location of the column totals."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ColumnTotalsLocation As DevExpress.XtraPivotGrid.PivotTotalsLocation
            Get
                ColumnTotalsLocation = _PivotGridControl.OptionsView.ColumnTotalsLocation
            End Get
            Set(value As DevExpress.XtraPivotGrid.PivotTotalsLocation)
                _PivotGridControl.OptionsView.ColumnTotalsLocation = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the location of the totals and grand totals."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RowTotalsLocation As DevExpress.XtraPivotGrid.PivotRowTotalsLocation
            Get
                RowTotalsLocation = _PivotGridControl.OptionsView.RowTotalsLocation
            End Get
            Set(value As DevExpress.XtraPivotGrid.PivotRowTotalsLocation)
                _PivotGridControl.OptionsView.RowTotalsLocation = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the distance (vertical) between field headers."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HeaderHeightOffset() As Integer
            Get
                HeaderHeightOffset = _PivotGridControl.OptionsView.HeaderHeightOffset
            End Get
            Set(value As Integer)
                _PivotGridControl.OptionsView.HeaderHeightOffset = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the distance (horizontal) between field headers."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HeaderWidthOffset() As Integer
            Get
                HeaderWidthOffset = _PivotGridControl.OptionsView.HeaderWidthOffset
            End Get
            Set(value As Integer)
                _PivotGridControl.OptionsView.HeaderWidthOffset = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the tree offset."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Overridable Property RowTreeOffset() As Integer
            Get
                RowTreeOffset = _PivotGridControl.OptionsView.RowTreeOffset
            End Get
            Set(value As Integer)
                _PivotGridControl.OptionsView.RowTreeOffset = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets the width of the innermost row field values."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Overridable Property RowTreeWidth() As Integer
            Get
                RowTreeWidth = _PivotGridControl.OptionsView.RowTreeWidth
            End Get
            Set(value As Integer)
                _PivotGridControl.OptionsView.RowTreeWidth = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether the Grand Total column header is visible when there are two or more data fields."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowColumnGrandTotalHeader() As Boolean
            Get
                ShowColumnGrandTotalHeader = _PivotGridControl.OptionsView.ShowColumnGrandTotalHeader
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowColumnGrandTotalHeader = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether column Grand Totals are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowColumnGrandTotals() As Boolean
            Get
                ShowColumnGrandTotals = _PivotGridControl.OptionsView.ShowColumnGrandTotals
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowColumnGrandTotals = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description(" Gets or sets whether column headers are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowColumnHeaders() As Boolean
            Get
                ShowColumnHeaders = _PivotGridControl.OptionsView.ShowColumnHeaders
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowColumnHeaders = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description(" Gets or sets whether column automatic Totals are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowColumnTotals() As Boolean
            Get
                ShowColumnTotals = _PivotGridControl.OptionsView.ShowColumnTotals
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowColumnTotals = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether custom totals are displayed for the field values which contain a single nesting field value."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowCustomTotalsForSingleValues() As Boolean
            Get
                ShowCustomTotalsForSingleValues = _PivotGridControl.OptionsView.ShowCustomTotalsForSingleValues
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowCustomTotalsForSingleValues = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether data headers are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowDataHeaders() As Boolean
            Get
                ShowDataHeaders = _PivotGridControl.OptionsView.ShowDataHeaders
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowDataHeaders = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether grand totals are displayed when the control lists a single value of an outer column field or row field along its left or top edge."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowGrandTotalsForSingleValues() As Boolean
            Get
                ShowGrandTotalsForSingleValues = _PivotGridControl.OptionsView.ShowGrandTotalsForSingleValues
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowGrandTotalsForSingleValues = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether horizontal grid lines are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowHorzLines() As Boolean
            Get
                ShowHorzLines = _PivotGridControl.OptionsView.ShowHorzLines
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowHorzLines = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether the Grand Total row header is visible when there are two or more data fields."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowRowGrandTotalHeader() As Boolean
            Get
                ShowRowGrandTotalHeader = _PivotGridControl.OptionsView.ShowRowGrandTotalHeader
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowRowGrandTotalHeader = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether row Grand Totals are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowRowGrandTotals() As Boolean
            Get
                ShowRowGrandTotals = _PivotGridControl.OptionsView.ShowRowGrandTotals
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowRowGrandTotals = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether row headers are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowRowHeaders() As Boolean
            Get
                ShowRowHeaders = _PivotGridControl.OptionsView.ShowRowHeaders
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowRowHeaders = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether row automatic Totals are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowRowTotals() As Boolean
            Get
                ShowRowTotals = _PivotGridControl.OptionsView.ShowRowTotals
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowRowTotals = value
                _HasChanged = True
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether automatic totals are displayed for the field values which contain a single nesting field value."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowTotalsForSingleValues() As Boolean
            Get
                ShowTotalsForSingleValues = _PivotGridControl.OptionsView.ShowTotalsForSingleValues
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowTotalsForSingleValues = value
                _HasChanged = True
            End Set
        End Property
        ''' <summary>
        '''   Gets or sets whether vertical grid lines are displayed.
        ''' </summary>
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether vertical grid lines are displayed."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ShowVertLines() As Boolean
            Get
                ShowVertLines = _PivotGridControl.OptionsView.ShowVertLines
            End Get
            Set(value As Boolean)
                _PivotGridControl.OptionsView.ShowVertLines = value
                _HasChanged = True
            End Set
        End Property
        ''' <summary>
        '''   Gets or sets whether vertical grid lines are displayed.
        ''' </summary>
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Description("Gets or sets whether the running total is displayed in each data column."),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RunningTotalsInColumns() As Boolean
            Get
                RunningTotalsInColumns = _RunningTotalsInColumns
            End Get
            Set(value As Boolean)
                _RunningTotalsInColumns = value
                _HasChanged = True
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal PivotGridControl As DevExpress.XtraPivotGrid.PivotGridControl, ByVal RunningTotalsInColumns As Boolean)

            _PivotGridControl = PivotGridControl
            _RunningTotalsInColumns = RunningTotalsInColumns

        End Sub
        Public Function HasChanged() As Boolean

            HasChanged = _HasChanged

        End Function

#End Region

    End Class

End Namespace

