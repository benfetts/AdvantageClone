Namespace Security

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GroupPermissionSubReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabelCanPrintData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelIsBlockedData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCustom2Data = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCanUpdateData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelModuleData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCustom1Data = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCanAddData = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrLabelModule = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCanUpdate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCustom1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCanPrint = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCanAdd = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelCustom2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelIsBlocked = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelCanPrintData, Me.XrLabelIsBlockedData, Me.XrLabelCustom2Data, Me.XrLabelCanUpdateData, Me.XrLabelModuleData, Me.XrLabelCustom1Data, Me.XrLabelCanAddData})
            Me.Detail.HeightF = 23.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelCanPrintData
            '
            Me.XrLabelCanPrintData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CanPrint")})
            Me.XrLabelCanPrintData.LocationFloat = New DevExpress.Utils.PointFloat(244.5835!, 0.0!)
            Me.XrLabelCanPrintData.Name = "XrLabelCanPrintData"
            Me.XrLabelCanPrintData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanPrintData.SizeF = New System.Drawing.SizeF(47.0!, 18.0!)
            Me.XrLabelCanPrintData.Text = "XrLabelCanPrintData"
            '
            'XrLabelIsBlockedData
            '
            Me.XrLabelIsBlockedData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "IsBlocked")})
            Me.XrLabelIsBlockedData.LocationFloat = New DevExpress.Utils.PointFloat(195.4167!, 0.0!)
            Me.XrLabelIsBlockedData.Name = "XrLabelIsBlockedData"
            Me.XrLabelIsBlockedData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelIsBlockedData.SizeF = New System.Drawing.SizeF(49.16675!, 18.0!)
            Me.XrLabelIsBlockedData.Text = "[IsBlocked]"
            '
            'XrLabelCustom2Data
            '
            Me.XrLabelCustom2Data.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Custom2")})
            Me.XrLabelCustom2Data.LocationFloat = New DevExpress.Utils.PointFloat(432.5834!, 0.0!)
            Me.XrLabelCustom2Data.Name = "XrLabelCustom2Data"
            Me.XrLabelCustom2Data.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCustom2Data.SizeF = New System.Drawing.SizeF(47.0!, 18.0!)
            Me.XrLabelCustom2Data.Text = "XrLabelCustom2Data"
            '
            'XrLabelCanUpdateData
            '
            Me.XrLabelCanUpdateData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CanUpdate")})
            Me.XrLabelCanUpdateData.LocationFloat = New DevExpress.Utils.PointFloat(291.5834!, 0.0!)
            Me.XrLabelCanUpdateData.Name = "XrLabelCanUpdateData"
            Me.XrLabelCanUpdateData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanUpdateData.SizeF = New System.Drawing.SizeF(47.0!, 18.0!)
            Me.XrLabelCanUpdateData.Text = "XrLabelCanUpdateData"
            '
            'XrLabelModuleData
            '
            Me.XrLabelModuleData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Module")})
            Me.XrLabelModuleData.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabelModuleData.Name = "XrLabelModuleData"
            Me.XrLabelModuleData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelModuleData.SizeF = New System.Drawing.SizeF(195.4167!, 18.0!)
            Me.XrLabelModuleData.Text = "XrLabelModuleData"
            '
            'XrLabelCustom1Data
            '
            Me.XrLabelCustom1Data.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Custom1")})
            Me.XrLabelCustom1Data.LocationFloat = New DevExpress.Utils.PointFloat(385.5834!, 0.0!)
            Me.XrLabelCustom1Data.Name = "XrLabelCustom1Data"
            Me.XrLabelCustom1Data.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCustom1Data.SizeF = New System.Drawing.SizeF(47.0!, 18.0!)
            Me.XrLabelCustom1Data.Text = "XrLabelCustom1Data"
            '
            'XrLabelCanAddData
            '
            Me.XrLabelCanAddData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CanAdd")})
            Me.XrLabelCanAddData.LocationFloat = New DevExpress.Utils.PointFloat(338.5834!, 0.0!)
            Me.XrLabelCanAddData.Name = "XrLabelCanAddData"
            Me.XrLabelCanAddData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanAddData.SizeF = New System.Drawing.SizeF(47.0!, 18.0!)
            Me.XrLabelCanAddData.Text = "XrLabelCanAddData"
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 2.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelModule
            '
            Me.XrLabelModule.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelModule.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelModule.ForeColor = System.Drawing.Color.Black
            Me.XrLabelModule.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0.5417029!)
            Me.XrLabelModule.Name = "XrLabelModule"
            Me.XrLabelModule.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelModule.SizeF = New System.Drawing.SizeF(195.4167!, 37.99999!)
            Me.XrLabelModule.StylePriority.UseBorders = False
            Me.XrLabelModule.StylePriority.UseFont = False
            Me.XrLabelModule.StylePriority.UseForeColor = False
            Me.XrLabelModule.StylePriority.UseTextAlignment = False
            Me.XrLabelModule.Text = "Module"
            Me.XrLabelModule.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCanUpdate
            '
            Me.XrLabelCanUpdate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCanUpdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCanUpdate.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCanUpdate.LocationFloat = New DevExpress.Utils.PointFloat(291.4168!, 0.541687!)
            Me.XrLabelCanUpdate.Name = "XrLabelCanUpdate"
            Me.XrLabelCanUpdate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanUpdate.SizeF = New System.Drawing.SizeF(47.0!, 38.0!)
            Me.XrLabelCanUpdate.StylePriority.UseBorders = False
            Me.XrLabelCanUpdate.StylePriority.UseFont = False
            Me.XrLabelCanUpdate.StylePriority.UseForeColor = False
            Me.XrLabelCanUpdate.StylePriority.UseTextAlignment = False
            Me.XrLabelCanUpdate.Text = "Can Update"
            Me.XrLabelCanUpdate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCustom1
            '
            Me.XrLabelCustom1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCustom1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCustom1.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCustom1.LocationFloat = New DevExpress.Utils.PointFloat(385.4168!, 0.541687!)
            Me.XrLabelCustom1.Name = "XrLabelCustom1"
            Me.XrLabelCustom1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCustom1.SizeF = New System.Drawing.SizeF(47.0!, 38.0!)
            Me.XrLabelCustom1.StylePriority.UseBorders = False
            Me.XrLabelCustom1.StylePriority.UseFont = False
            Me.XrLabelCustom1.StylePriority.UseForeColor = False
            Me.XrLabelCustom1.StylePriority.UseTextAlignment = False
            Me.XrLabelCustom1.Text = "Custom 1"
            Me.XrLabelCustom1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCanPrint
            '
            Me.XrLabelCanPrint.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCanPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCanPrint.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCanPrint.LocationFloat = New DevExpress.Utils.PointFloat(244.4168!, 0.5417029!)
            Me.XrLabelCanPrint.Name = "XrLabelCanPrint"
            Me.XrLabelCanPrint.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanPrint.SizeF = New System.Drawing.SizeF(47.0!, 38.0!)
            Me.XrLabelCanPrint.StylePriority.UseBorders = False
            Me.XrLabelCanPrint.StylePriority.UseFont = False
            Me.XrLabelCanPrint.StylePriority.UseForeColor = False
            Me.XrLabelCanPrint.StylePriority.UseTextAlignment = False
            Me.XrLabelCanPrint.Text = "Can Print"
            Me.XrLabelCanPrint.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCanAdd
            '
            Me.XrLabelCanAdd.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCanAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCanAdd.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCanAdd.LocationFloat = New DevExpress.Utils.PointFloat(338.4168!, 0.541687!)
            Me.XrLabelCanAdd.Name = "XrLabelCanAdd"
            Me.XrLabelCanAdd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCanAdd.SizeF = New System.Drawing.SizeF(47.0!, 38.0!)
            Me.XrLabelCanAdd.StylePriority.UseBorders = False
            Me.XrLabelCanAdd.StylePriority.UseFont = False
            Me.XrLabelCanAdd.StylePriority.UseForeColor = False
            Me.XrLabelCanAdd.StylePriority.UseTextAlignment = False
            Me.XrLabelCanAdd.Text = "Can Add"
            Me.XrLabelCanAdd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelCustom2
            '
            Me.XrLabelCustom2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelCustom2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCustom2.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCustom2.LocationFloat = New DevExpress.Utils.PointFloat(432.4168!, 0.541687!)
            Me.XrLabelCustom2.Name = "XrLabelCustom2"
            Me.XrLabelCustom2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelCustom2.SizeF = New System.Drawing.SizeF(47.0!, 38.0!)
            Me.XrLabelCustom2.StylePriority.UseBorders = False
            Me.XrLabelCustom2.StylePriority.UseFont = False
            Me.XrLabelCustom2.StylePriority.UseForeColor = False
            Me.XrLabelCustom2.StylePriority.UseTextAlignment = False
            Me.XrLabelCustom2.Text = "Custom 2"
            Me.XrLabelCustom2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrLabelIsBlocked
            '
            Me.XrLabelIsBlocked.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabelIsBlocked.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelIsBlocked.ForeColor = System.Drawing.Color.Black
            Me.XrLabelIsBlocked.LocationFloat = New DevExpress.Utils.PointFloat(195.4168!, 0.541687!)
            Me.XrLabelIsBlocked.Name = "XrLabelIsBlocked"
            Me.XrLabelIsBlocked.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabelIsBlocked.SizeF = New System.Drawing.SizeF(49.0!, 38.0!)
            Me.XrLabelIsBlocked.StylePriority.UseBorders = False
            Me.XrLabelIsBlocked.StylePriority.UseFont = False
            Me.XrLabelIsBlocked.StylePriority.UseForeColor = False
            Me.XrLabelIsBlocked.StylePriority.UseTextAlignment = False
            Me.XrLabelIsBlocked.Text = "Is Blocked"
            Me.XrLabelIsBlocked.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelCustom2, Me.XrLabelCanAdd, Me.XrLabelIsBlocked, Me.XrLabelCanPrint, Me.XrLabelCustom1, Me.XrLabelCanUpdate, Me.XrLabelModule})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 38.5417!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Security.Database.Views.GroupPermissionsReport)
            '
            'GroupPermissionSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 370, 0, 2)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents XrLabelCanPrintData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelIsBlockedData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCustom2Data As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCanUpdateData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelModuleData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCustom1Data As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCanAddData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCanAdd As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCustom2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelIsBlocked As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCanPrint As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelModule As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCanUpdate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelCustom1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
    End Class

End Namespace