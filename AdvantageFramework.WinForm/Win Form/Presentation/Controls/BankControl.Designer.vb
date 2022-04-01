Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BankControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BankControl))
            Me.TabControlControl_BankDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelPaymentManager_PaymentManager = New DevComponents.DotNetBar.TabControlPanel()
            Me.ButtonPaymentManager_FTPPrivateKeyDelete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonPaymentManager_FTPPrivateKeySelect = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelPaymentManager_FTPPrivateKey = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxPaymentManager_FTPSecure = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelPaymentManager_FTPSecure = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxPaymentManager_UseSSL = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxPaymentManager_FTPPort = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_FTPPort = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_FTPExportFolder = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_FTPAddress = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_FTPAddress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_FTPExportPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_FTPFolder = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_FTPUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_FTPTargetFolder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_FTPPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_FTPUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_FTPSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxPaymentManager_ExportType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView11 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelPaymentManager_CompanyEntryDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_CompanyName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxPaymentManager_StandardEntryClassCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxPaymentManager_ServiceClassCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxPaymentManager_CompanyEntryDescription = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_CompanyName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_DestinationName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_StandardEntryClassCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_ServiceClassCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_DestinationName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_ACHSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_ComDataPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_ComDataAccountCode = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_Password = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_AccountCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_CSITargetFolder = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_CSIPassword = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_CSIUserName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_CSITargetFolder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_CSIPassword = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_CSIUserName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_CSIPreferredPartnerSettings = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_FileOutputDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_FTPClient = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_Word = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPaymentManager_CustomerID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_FileOutputDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_FTPClient = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_Word = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_CustomerID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPaymentManager_ExportType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPaymentManager_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPaymentManager_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_PaymentManager = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCheckExport2_CheckExport2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelCheckExport2TableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxCheckExport2_TrailerRecord = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelTrailerRecord_Export = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTrailerRecord_RecordCountCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_RecordCountEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_RecordCountBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_TotalFlagEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_RecordCountExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTrailerRecord_TotalFlagExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_TotalFlag = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_RecordCount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_ExportAmountEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_FileDateEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_FileDateCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_FileDateBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_ExportAmountExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTrailerRecord_FileDateExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_FileDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_ExportAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTrailerRecord_Filler4FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTrailerRecord_Filler4EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_Filler4BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_Filler4Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_Filler4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTrailerRecord_Filler3FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTrailerRecord_Filler3EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_Filler3BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_Filler3Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_Filler3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTrailerRecord_Filler2FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxTrailerRecord_Filler1FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTrailerRecord_Filler2EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_Filler2BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_Filler2Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputTrailerRecord_Filler1EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_Filler1BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_Filler1Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_AccountNumberEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_BankIDEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_BankIDCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTrailerRecord_BankIDBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTrailerRecord_AccountNumberExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_Filler2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTrailerRecord_BankIDExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTrailerRecord_Filler1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_FillValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_BankID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_CSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTrailerRecord_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelCheckExport2TableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxCheckExport2_TotalRecord = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelTotalRecord_Export = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTotalRecord_RecordCountCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_RecordCountEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_RecordCountBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_TotalFlagEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_TotalFlagCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_TotalFlagBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_RecordCountExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTotalRecord_TotalFlagExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_TotalFlag = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_RecordCount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputTotalRecord_ExportAmountCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_ExportAmountEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_ExportAmountBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_FileDateEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_FileDateCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_FileDateBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_ExportAmountExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxTotalRecord_FileDateExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_FileDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_ExportAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTotalRecord_Filler4FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTotalRecord_Filler4EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_Filler4BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_Filler4Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_Filler4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTotalRecord_Filler3FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTotalRecord_Filler3EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_Filler3BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_Filler3Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_Filler3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTotalRecord_Filler2FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxTotalRecord_Filler1FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputTotalRecord_Filler2EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_Filler2BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_Filler2Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputTotalRecord_Filler1EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_Filler1BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_Filler1Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputTotalRecord_AccountNumberCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_AccountNumberEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_AccountNumberBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_BankIDEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_BankIDCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputTotalRecord_BankIDBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxTotalRecord_AccountNumberExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_Filler2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxTotalRecord_BankIDExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelTotalRecord_Filler1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_FillValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_BankID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_CSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTotalRecord_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_CheckExport2 = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCheckExport_CheckExport = New DevComponents.DotNetBar.TabControlPanel()
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelCheckExportTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxCheckExport_DetailRecord = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelDetailRecord_Export = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDetailRecord_PayeeCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_PayeeEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_PayeeBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_PayeeExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_Payee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDetailRecord_VoidFlagCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_VoidFlagEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_VoidFlagBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckAmountEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckAmountCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckAmountBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_VoidFlagExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDetailRecord_CheckAmountExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_CheckAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_VoidFlag = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDetailRecord_CheckDateCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckDateEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckDateBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckNumberEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckNumberCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_CheckNumberBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_CheckDateExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxDetailRecord_CheckNumberExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_CheckDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDetailRecord_Filler4FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputDetailRecord_Filler4EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_Filler4BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_Filler4Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_Filler4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDetailRecord_Filler3FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputDetailRecord_Filler3EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_Filler3BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_Filler3Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_Filler3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDetailRecord_Filler2FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxDetailRecord_Filler1FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputDetailRecord_Filler2EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_Filler2BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_Filler2Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputDetailRecord_Filler1EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_Filler1BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_Filler1Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputDetailRecord_AccountNumberCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_AccountNumberEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_AccountNumberBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_BankIDEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_BankIDCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDetailRecord_BankIDBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxDetailRecord_AccountNumberExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_Filler2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxDetailRecord_BankIDExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDetailRecord_Filler1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_FillValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_BankID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_CSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDetailRecord_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelCheckExportTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.GroupBoxCheckExport_HeaderRecord = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxHeaderRecord_Filler2FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxHeaderRecord_Filler1FillValue = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputHeaderRecord_Filler2EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_Filler2BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxHeaderRecord_Filler2Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputHeaderRecord_Filler1EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_Filler1BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxHeaderRecord_Filler1Export = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputHeaderRecord_CreateDateCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_CreateDateEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_CreateDateBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_AgencyEndPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_AgencyCSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputHeaderRecord_AgencyBeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.CheckBoxHeaderRecord_CreateDateExport = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelHeaderRecord_Filler2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxHeaderRecord_ExportAgency = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelHeaderRecord_Filler1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_FillValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_Export = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_Agency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_CSVOrder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_EndPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_CreateDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelHeaderRecord_BeginPosition = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxCheckExport_UseHeaderRecord = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RadioButtonControlCheckExport_CSV = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlCheckExport_Fixed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelCheckExport_ExportFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_CheckExport = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCheckImport_CheckImport = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxCheckImport_ImportFileName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TableLayoutPanelCheckImport_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.NumericInputRightColumn_NumberOfDecimals = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRightColumn_Length = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputRightColumn_ColumnStart = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelRightColumn_NumberOfDecimals = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightColumn_Length = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightColumn_ColumnStart = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightColumn_CheckAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.NumericInputLeftColumn_Length = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputLeftColumn_ColumnStart = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelCheckImport_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftColumn_Length = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelLeftColumn_ColumnStart = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckImport_ImportFileName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_CheckImport = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCurrency_Currency = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView10 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView9 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCurrency_Currency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView7 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelCurrency_CurrencyExchangeRealizedAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCurrency_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_Currency = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSetup_Setup = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSetup_CheckWritingInProgress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxSetup_DigitalSignatureFontSize = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSetup_DigitalSignatureFontSize = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxSetup_DigitalSignatureFont = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSetup_DigitalSignatureFont = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_DigitalSignatureText = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_DigitalSignatureText = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSetup_DigitalSignatureActive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelSetup_DigitalSignature = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxSetup_APComputerCheckFormat = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_APDiscAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_APCashAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_ARCashAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxSetup_PaymentManager = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSetup_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxSetup_CheckAmountInWords = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.NumericInputSetup_LastComputerCheckIssued = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputSetup_LastManualCheckIssued = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputSetup_CheckTemplateID = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputSetup_RoutingNumber = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxSetup_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_BankID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_ACHCompanyID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_CheckTemplateID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_CheckAmountInWords = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_APComputerCheckFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_InterestEarnedGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_ServiceChargeGLAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_APDiscAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_APCashAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_ARCashAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_LastComputerCheckIssued = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_LastManualCheckIssued = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_BankID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_ACHCompanyID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_RoutingNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_AccountNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemBankDetails_Setup = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_BankDetails, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlControl_BankDetails.SuspendLayout
            Me.TabControlPanelPaymentManager_PaymentManager.SuspendLayout
            CType(Me.SearchableComboBoxPaymentManager_ExportType.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelCheckExport2_CheckExport2.SuspendLayout
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.SuspendLayout
            Me.PanelCheckExport2TableLayout_RightColumn.SuspendLayout
            CType(Me.GroupBoxCheckExport2_TrailerRecord, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckExport2_TrailerRecord.SuspendLayout
            CType(Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_FileDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelCheckExport2TableLayout_LeftColumn.SuspendLayout
            CType(Me.GroupBoxCheckExport2_TotalRecord, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckExport2_TotalRecord.SuspendLayout
            CType(Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_RecordCountEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_FileDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_FileDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_FileDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputTotalRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelCheckExport_CheckExport.SuspendLayout
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.SuspendLayout
            Me.PanelCheckExportTableLayout_RightColumn.SuspendLayout
            CType(Me.GroupBoxCheckExport_DetailRecord, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckExport_DetailRecord.SuspendLayout
            CType(Me.NumericInputDetailRecord_PayeeCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_PayeeEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_PayeeBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputDetailRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelCheckExportTableLayout_LeftColumn.SuspendLayout
            CType(Me.GroupBoxCheckExport_HeaderRecord, System.ComponentModel.ISupportInitialize).BeginInit
            Me.GroupBoxCheckExport_HeaderRecord.SuspendLayout
            CType(Me.NumericInputHeaderRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_AgencyEndPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelCheckImport_CheckImport.SuspendLayout
            Me.TableLayoutPanelCheckImport_TableLayout.SuspendLayout
            Me.PanelTableLayout_RightColumn.SuspendLayout
            CType(Me.NumericInputRightColumn_NumberOfDecimals.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputRightColumn_Length.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputRightColumn_ColumnStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.PanelTableLayout_LeftColumn.SuspendLayout
            CType(Me.NumericInputLeftColumn_Length.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputLeftColumn_ColumnStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelCurrency_Currency.SuspendLayout
            CType(Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxCurrency_Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).BeginInit
            Me.TabControlPanelSetup_Setup.SuspendLayout
            CType(Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_APDiscAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_APCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_ARCashAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBoxSetup_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputSetup_LastComputerCheckIssued.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputSetup_LastManualCheckIssued.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputSetup_CheckTemplateID.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            CType(Me.NumericInputSetup_RoutingNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit
            Me.SuspendLayout
            '
            'TabControlControl_BankDetails
            '
            Me.TabControlControl_BankDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_BankDetails.CanReorderTabs = False
            Me.TabControlControl_BankDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_BankDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelPaymentManager_PaymentManager)
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelSetup_Setup)
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelCheckExport2_CheckExport2)
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelCheckExport_CheckExport)
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelCheckImport_CheckImport)
            Me.TabControlControl_BankDetails.Controls.Add(Me.TabControlPanelCurrency_Currency)
            Me.TabControlControl_BankDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_BankDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_BankDetails.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlControl_BankDetails.Name = "TabControlControl_BankDetails"
            Me.TabControlControl_BankDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_BankDetails.SelectedTabIndex = 0
            Me.TabControlControl_BankDetails.Size = New System.Drawing.Size(1883, 1564)
            Me.TabControlControl_BankDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_BankDetails.TabIndex = 1
            Me.TabControlControl_BankDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_Setup)
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_Currency)
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_CheckImport)
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_CheckExport)
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_CheckExport2)
            Me.TabControlControl_BankDetails.Tabs.Add(Me.TabItemBankDetails_PaymentManager)
            Me.TabControlControl_BankDetails.Text = "TabControl1"
            '
            'TabControlPanelPaymentManager_PaymentManager
            '
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.ButtonPaymentManager_FTPPrivateKeyDelete)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.ButtonPaymentManager_FTPPrivateKeySelect)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPPrivateKey)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.ComboBoxPaymentManager_FTPSecure)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPSecure)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.CheckBoxPaymentManager_UseSSL)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPPort)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPPort)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPExportFolder)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPAddress)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPAddress)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPExportPath)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPFolder)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPPassword)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPUserName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPTargetFolder)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPPassword)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPUserName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPSettings)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.SearchableComboBoxPaymentManager_ExportType)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CompanyEntryDescription)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CompanyName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.ComboBoxPaymentManager_StandardEntryClassCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.ComboBoxPaymentManager_ServiceClassCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CompanyEntryDescription)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CompanyName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_DestinationName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_StandardEntryClassCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_ServiceClassCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_DestinationName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_ACHSettings)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_ComDataPassword)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_ComDataAccountCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_Password)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_AccountCode)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CSITargetFolder)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CSIPassword)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CSIUserName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CSITargetFolder)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CSIPassword)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CSIUserName)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CSIPreferredPartnerSettings)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FileOutputDirectory)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_FTPClient)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_Word)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_CustomerID)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FileOutputDirectory)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_FTPClient)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_Word)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_CustomerID)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_ExportType)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.TextBoxPaymentManager_AccountNumber)
            Me.TabControlPanelPaymentManager_PaymentManager.Controls.Add(Me.LabelPaymentManager_AccountNumber)
            Me.TabControlPanelPaymentManager_PaymentManager.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelPaymentManager_PaymentManager.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelPaymentManager_PaymentManager.Enabled = False
            Me.TabControlPanelPaymentManager_PaymentManager.Location = New System.Drawing.Point(0, 56)
            Me.TabControlPanelPaymentManager_PaymentManager.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelPaymentManager_PaymentManager.Name = "TabControlPanelPaymentManager_PaymentManager"
            Me.TabControlPanelPaymentManager_PaymentManager.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelPaymentManager_PaymentManager.Size = New System.Drawing.Size(1883, 1508)
            Me.TabControlPanelPaymentManager_PaymentManager.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelPaymentManager_PaymentManager.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelPaymentManager_PaymentManager.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelPaymentManager_PaymentManager.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelPaymentManager_PaymentManager.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelPaymentManager_PaymentManager.Style.GradientAngle = 90
            Me.TabControlPanelPaymentManager_PaymentManager.TabIndex = 5
            Me.TabControlPanelPaymentManager_PaymentManager.TabItem = Me.TabItemBankDetails_PaymentManager
            '
            'ButtonPaymentManager_FTPPrivateKeyDelete
            '
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Location = New System.Drawing.Point(635, 1433)
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Name = "ButtonPaymentManager_FTPPrivateKeyDelete"
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.SecurityEnabled = True
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Size = New System.Drawing.Size(200, 48)
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.TabIndex = 52
            Me.ButtonPaymentManager_FTPPrivateKeyDelete.Text = "Delete"
            '
            'ButtonPaymentManager_FTPPrivateKeySelect
            '
            Me.ButtonPaymentManager_FTPPrivateKeySelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonPaymentManager_FTPPrivateKeySelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Location = New System.Drawing.Point(419, 1433)
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Name = "ButtonPaymentManager_FTPPrivateKeySelect"
            Me.ButtonPaymentManager_FTPPrivateKeySelect.SecurityEnabled = True
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Size = New System.Drawing.Size(200, 48)
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonPaymentManager_FTPPrivateKeySelect.TabIndex = 51
            Me.ButtonPaymentManager_FTPPrivateKeySelect.Text = "Select"
            '
            'LabelPaymentManager_FTPPrivateKey
            '
            Me.LabelPaymentManager_FTPPrivateKey.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPPrivateKey.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPPrivateKey.Location = New System.Drawing.Point(16, 1433)
            Me.LabelPaymentManager_FTPPrivateKey.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPPrivateKey.Name = "LabelPaymentManager_FTPPrivateKey"
            Me.LabelPaymentManager_FTPPrivateKey.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPPrivateKey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPPrivateKey.TabIndex = 50
            Me.LabelPaymentManager_FTPPrivateKey.Text = "Private Key:"
            '
            'ComboBoxPaymentManager_FTPSecure
            '
            Me.ComboBoxPaymentManager_FTPSecure.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPaymentManager_FTPSecure.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPaymentManager_FTPSecure.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPaymentManager_FTPSecure.AutoFindItemInDataSource = False
            Me.ComboBoxPaymentManager_FTPSecure.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPaymentManager_FTPSecure.BookmarkingEnabled = False
            Me.ComboBoxPaymentManager_FTPSecure.ClientCode = ""
            Me.ComboBoxPaymentManager_FTPSecure.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxPaymentManager_FTPSecure.DisableMouseWheel = False
            Me.ComboBoxPaymentManager_FTPSecure.DisplayMember = "Description"
            Me.ComboBoxPaymentManager_FTPSecure.DisplayName = ""
            Me.ComboBoxPaymentManager_FTPSecure.DivisionCode = ""
            Me.ComboBoxPaymentManager_FTPSecure.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPaymentManager_FTPSecure.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxPaymentManager_FTPSecure.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxPaymentManager_FTPSecure.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPaymentManager_FTPSecure.FocusHighlightEnabled = True
            Me.ComboBoxPaymentManager_FTPSecure.FormattingEnabled = True
            Me.ComboBoxPaymentManager_FTPSecure.ItemHeight = 14
            Me.ComboBoxPaymentManager_FTPSecure.Location = New System.Drawing.Point(1181, 1312)
            Me.ComboBoxPaymentManager_FTPSecure.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxPaymentManager_FTPSecure.Name = "ComboBoxPaymentManager_FTPSecure"
            Me.ComboBoxPaymentManager_FTPSecure.ReadOnly = False
            Me.ComboBoxPaymentManager_FTPSecure.SecurityEnabled = True
            Me.ComboBoxPaymentManager_FTPSecure.Size = New System.Drawing.Size(375, 20)
            Me.ComboBoxPaymentManager_FTPSecure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPaymentManager_FTPSecure.TabIndex = 47
            Me.ComboBoxPaymentManager_FTPSecure.TabOnEnter = True
            Me.ComboBoxPaymentManager_FTPSecure.ValueMember = "Code"
            Me.ComboBoxPaymentManager_FTPSecure.WatermarkText = "Select"
            '
            'LabelPaymentManager_FTPSecure
            '
            Me.LabelPaymentManager_FTPSecure.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPSecure.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPSecure.Location = New System.Drawing.Point(883, 1312)
            Me.LabelPaymentManager_FTPSecure.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPSecure.Name = "LabelPaymentManager_FTPSecure"
            Me.LabelPaymentManager_FTPSecure.Size = New System.Drawing.Size(283, 48)
            Me.LabelPaymentManager_FTPSecure.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPSecure.TabIndex = 46
            Me.LabelPaymentManager_FTPSecure.Text = "SSL for FTP Mode:"
            '
            'CheckBoxPaymentManager_UseSSL
            '
            Me.CheckBoxPaymentManager_UseSSL.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxPaymentManager_UseSSL.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxPaymentManager_UseSSL.CheckValue = 1
            Me.CheckBoxPaymentManager_UseSSL.CheckValueChecked = 0
            Me.CheckBoxPaymentManager_UseSSL.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxPaymentManager_UseSSL.CheckValueUnchecked = 1
            Me.CheckBoxPaymentManager_UseSSL.ChildControls = Nothing
            Me.CheckBoxPaymentManager_UseSSL.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked0Unchecked1
            Me.CheckBoxPaymentManager_UseSSL.Location = New System.Drawing.Point(651, 1312)
            Me.CheckBoxPaymentManager_UseSSL.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxPaymentManager_UseSSL.Name = "CheckBoxPaymentManager_UseSSL"
            Me.CheckBoxPaymentManager_UseSSL.OldestSibling = Nothing
            Me.CheckBoxPaymentManager_UseSSL.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.CheckBoxPaymentManager_UseSSL.SecurityEnabled = True
            Me.CheckBoxPaymentManager_UseSSL.SiblingControls = Nothing
            Me.CheckBoxPaymentManager_UseSSL.Size = New System.Drawing.Size(216, 48)
            Me.CheckBoxPaymentManager_UseSSL.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxPaymentManager_UseSSL.TabIndex = 45
            Me.CheckBoxPaymentManager_UseSSL.TabOnEnter = True
            Me.CheckBoxPaymentManager_UseSSL.Text = "Use SSH"
            '
            'TextBoxPaymentManager_FTPPort
            '
            Me.TextBoxPaymentManager_FTPPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPPort.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPPort.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPPort.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPPort.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPPort.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPPort.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPPort.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPPort.Location = New System.Drawing.Point(419, 1312)
            Me.TextBoxPaymentManager_FTPPort.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPPort.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPPort.MaximumSize = New System.Drawing.Size(216, 0)
            Me.TextBoxPaymentManager_FTPPort.Name = "TextBoxPaymentManager_FTPPort"
            Me.TextBoxPaymentManager_FTPPort.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPPort.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPPort.Size = New System.Drawing.Size(216, 38)
            Me.TextBoxPaymentManager_FTPPort.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPPort.TabIndex = 44
            Me.TextBoxPaymentManager_FTPPort.TabOnEnter = True
            '
            'LabelPaymentManager_FTPPort
            '
            Me.LabelPaymentManager_FTPPort.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPPort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPPort.Location = New System.Drawing.Point(16, 1312)
            Me.LabelPaymentManager_FTPPort.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPPort.Name = "LabelPaymentManager_FTPPort"
            Me.LabelPaymentManager_FTPPort.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPPort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPPort.TabIndex = 43
            Me.LabelPaymentManager_FTPPort.Text = "FTP Port:"
            '
            'TextBoxPaymentManager_FTPExportFolder
            '
            Me.TextBoxPaymentManager_FTPExportFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPExportFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPExportFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPExportFolder.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPExportFolder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPExportFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPExportFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPExportFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPExportFolder.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPExportFolder.Location = New System.Drawing.Point(419, 1374)
            Me.TextBoxPaymentManager_FTPExportFolder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPExportFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPExportFolder.Name = "TextBoxPaymentManager_FTPExportFolder"
            Me.TextBoxPaymentManager_FTPExportFolder.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPExportFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPExportFolder.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPExportFolder.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPExportFolder.TabIndex = 49
            Me.TextBoxPaymentManager_FTPExportFolder.TabOnEnter = True
            '
            'TextBoxPaymentManager_FTPAddress
            '
            Me.TextBoxPaymentManager_FTPAddress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPAddress.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPAddress.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPAddress.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPAddress.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPAddress.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPAddress.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPAddress.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPAddress.Location = New System.Drawing.Point(419, 1250)
            Me.TextBoxPaymentManager_FTPAddress.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPAddress.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPAddress.Name = "TextBoxPaymentManager_FTPAddress"
            Me.TextBoxPaymentManager_FTPAddress.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPAddress.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPAddress.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPAddress.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPAddress.TabIndex = 42
            Me.TextBoxPaymentManager_FTPAddress.TabOnEnter = True
            '
            'LabelPaymentManager_FTPAddress
            '
            Me.LabelPaymentManager_FTPAddress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPAddress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPAddress.Location = New System.Drawing.Point(16, 1250)
            Me.LabelPaymentManager_FTPAddress.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPAddress.Name = "LabelPaymentManager_FTPAddress"
            Me.LabelPaymentManager_FTPAddress.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPAddress.TabIndex = 41
            Me.LabelPaymentManager_FTPAddress.Text = "FTP Address:"
            '
            'LabelPaymentManager_FTPExportPath
            '
            Me.LabelPaymentManager_FTPExportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPExportPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPExportPath.Location = New System.Drawing.Point(16, 1371)
            Me.LabelPaymentManager_FTPExportPath.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPExportPath.Name = "LabelPaymentManager_FTPExportPath"
            Me.LabelPaymentManager_FTPExportPath.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPExportPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPExportPath.TabIndex = 48
            Me.LabelPaymentManager_FTPExportPath.Text = "Export Folder:"
            '
            'TextBoxPaymentManager_FTPFolder
            '
            Me.TextBoxPaymentManager_FTPFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPFolder.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPFolder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPFolder.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPFolder.Location = New System.Drawing.Point(419, 1188)
            Me.TextBoxPaymentManager_FTPFolder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPFolder.Name = "TextBoxPaymentManager_FTPFolder"
            Me.TextBoxPaymentManager_FTPFolder.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPFolder.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPFolder.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPFolder.TabIndex = 40
            Me.TextBoxPaymentManager_FTPFolder.TabOnEnter = True
            '
            'TextBoxPaymentManager_FTPPassword
            '
            Me.TextBoxPaymentManager_FTPPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPPassword.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPPassword.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPPassword.Location = New System.Drawing.Point(419, 1126)
            Me.TextBoxPaymentManager_FTPPassword.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPPassword.Name = "TextBoxPaymentManager_FTPPassword"
            Me.TextBoxPaymentManager_FTPPassword.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPPassword.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPPassword.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPPassword.TabIndex = 38
            Me.TextBoxPaymentManager_FTPPassword.TabOnEnter = True
            Me.TextBoxPaymentManager_FTPPassword.UseSystemPasswordChar = True
            '
            'TextBoxPaymentManager_FTPUserName
            '
            Me.TextBoxPaymentManager_FTPUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPUserName.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPUserName.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPUserName.Location = New System.Drawing.Point(419, 1064)
            Me.TextBoxPaymentManager_FTPUserName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPUserName.Name = "TextBoxPaymentManager_FTPUserName"
            Me.TextBoxPaymentManager_FTPUserName.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPUserName.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPUserName.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPUserName.TabIndex = 36
            Me.TextBoxPaymentManager_FTPUserName.TabOnEnter = True
            '
            'LabelPaymentManager_FTPTargetFolder
            '
            Me.LabelPaymentManager_FTPTargetFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPTargetFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPTargetFolder.Location = New System.Drawing.Point(16, 1188)
            Me.LabelPaymentManager_FTPTargetFolder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPTargetFolder.Name = "LabelPaymentManager_FTPTargetFolder"
            Me.LabelPaymentManager_FTPTargetFolder.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPTargetFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPTargetFolder.TabIndex = 39
            Me.LabelPaymentManager_FTPTargetFolder.Text = "FTP Folder:"
            '
            'LabelPaymentManager_FTPPassword
            '
            Me.LabelPaymentManager_FTPPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPPassword.Location = New System.Drawing.Point(16, 1126)
            Me.LabelPaymentManager_FTPPassword.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPPassword.Name = "LabelPaymentManager_FTPPassword"
            Me.LabelPaymentManager_FTPPassword.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPPassword.TabIndex = 37
            Me.LabelPaymentManager_FTPPassword.Text = "Password:"
            '
            'LabelPaymentManager_FTPUserName
            '
            Me.LabelPaymentManager_FTPUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPUserName.Location = New System.Drawing.Point(16, 1064)
            Me.LabelPaymentManager_FTPUserName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPUserName.Name = "LabelPaymentManager_FTPUserName"
            Me.LabelPaymentManager_FTPUserName.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPUserName.TabIndex = 35
            Me.LabelPaymentManager_FTPUserName.Text = "User Name:"
            '
            'LabelPaymentManager_FTPSettings
            '
            Me.LabelPaymentManager_FTPSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPaymentManager_FTPSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_FTPSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPaymentManager_FTPSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPaymentManager_FTPSettings.Location = New System.Drawing.Point(16, 1004)
            Me.LabelPaymentManager_FTPSettings.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPSettings.Name = "LabelPaymentManager_FTPSettings"
            Me.LabelPaymentManager_FTPSettings.Size = New System.Drawing.Size(1851, 48)
            Me.LabelPaymentManager_FTPSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPSettings.TabIndex = 34
            Me.LabelPaymentManager_FTPSettings.Text = "Automated FTP Settings"
            '
            'SearchableComboBoxPaymentManager_ExportType
            '
            Me.SearchableComboBoxPaymentManager_ExportType.ActiveFilterString = ""
            Me.SearchableComboBoxPaymentManager_ExportType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxPaymentManager_ExportType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxPaymentManager_ExportType.AutoFillMode = False
            Me.SearchableComboBoxPaymentManager_ExportType.BookmarkingEnabled = False
            Me.SearchableComboBoxPaymentManager_ExportType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ExportSystem
            Me.SearchableComboBoxPaymentManager_ExportType.DataSource = Nothing
            Me.SearchableComboBoxPaymentManager_ExportType.DisableMouseWheel = False
            Me.SearchableComboBoxPaymentManager_ExportType.DisplayName = ""
            Me.SearchableComboBoxPaymentManager_ExportType.EnterMoveNextControl = True
            Me.SearchableComboBoxPaymentManager_ExportType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxPaymentManager_ExportType.Location = New System.Drawing.Point(419, 76)
            Me.SearchableComboBoxPaymentManager_ExportType.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxPaymentManager_ExportType.Name = "SearchableComboBoxPaymentManager_ExportType"
            Me.SearchableComboBoxPaymentManager_ExportType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPaymentManager_ExportType.Properties.DisplayMember = "Label"
            Me.SearchableComboBoxPaymentManager_ExportType.Properties.NullText = "Select Export System"
            Me.SearchableComboBoxPaymentManager_ExportType.Properties.PopupView = Me.GridView11
            Me.SearchableComboBoxPaymentManager_ExportType.Properties.ValueMember = "Name"
            Me.SearchableComboBoxPaymentManager_ExportType.SecurityEnabled = True
            Me.SearchableComboBoxPaymentManager_ExportType.SelectedValue = Nothing
            Me.SearchableComboBoxPaymentManager_ExportType.Size = New System.Drawing.Size(1448, 48)
            Me.SearchableComboBoxPaymentManager_ExportType.TabIndex = 3
            '
            'GridView11
            '
            Me.GridView11.AFActiveFilterString = ""
            Me.GridView11.AllowExtraItemsInGridLookupEdits = True
            Me.GridView11.AutoFilterLookupColumns = False
            Me.GridView11.AutoloadRepositoryDatasource = True
            Me.GridView11.DataSourceClearing = False
            Me.GridView11.DetailHeight = 835
            Me.GridView11.EnableDisabledRows = False
            Me.GridView11.FixedLineWidth = 5
            Me.GridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView11.Name = "GridView11"
            Me.GridView11.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView11.OptionsView.ShowGroupPanel = False
            Me.GridView11.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView11.RunStandardValidation = True
            Me.GridView11.SkipAddingControlsOnModifyColumn = False
            Me.GridView11.SkipSettingFontOnModifyColumn = False
            '
            'LabelPaymentManager_CompanyEntryDescription
            '
            Me.LabelPaymentManager_CompanyEntryDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CompanyEntryDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CompanyEntryDescription.Location = New System.Drawing.Point(16, 572)
            Me.LabelPaymentManager_CompanyEntryDescription.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CompanyEntryDescription.Name = "LabelPaymentManager_CompanyEntryDescription"
            Me.LabelPaymentManager_CompanyEntryDescription.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CompanyEntryDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CompanyEntryDescription.TabIndex = 21
            Me.LabelPaymentManager_CompanyEntryDescription.Text = "Company Entry Description:"
            '
            'LabelPaymentManager_CompanyName
            '
            Me.LabelPaymentManager_CompanyName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CompanyName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CompanyName.Location = New System.Drawing.Point(16, 510)
            Me.LabelPaymentManager_CompanyName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CompanyName.Name = "LabelPaymentManager_CompanyName"
            Me.LabelPaymentManager_CompanyName.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CompanyName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CompanyName.TabIndex = 19
            Me.LabelPaymentManager_CompanyName.Text = "Company Name:"
            '
            'ComboBoxPaymentManager_StandardEntryClassCode
            '
            Me.ComboBoxPaymentManager_StandardEntryClassCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxPaymentManager_StandardEntryClassCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPaymentManager_StandardEntryClassCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPaymentManager_StandardEntryClassCode.AutoFindItemInDataSource = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.BookmarkingEnabled = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ClientCode = ""
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxPaymentManager_StandardEntryClassCode.DisableMouseWheel = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.DisplayMember = "Description"
            Me.ComboBoxPaymentManager_StandardEntryClassCode.DisplayName = ""
            Me.ComboBoxPaymentManager_StandardEntryClassCode.DivisionCode = ""
            Me.ComboBoxPaymentManager_StandardEntryClassCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxPaymentManager_StandardEntryClassCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPaymentManager_StandardEntryClassCode.FocusHighlightEnabled = True
            Me.ComboBoxPaymentManager_StandardEntryClassCode.FormattingEnabled = True
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ItemHeight = 14
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Location = New System.Drawing.Point(1216, 448)
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Name = "ComboBoxPaymentManager_StandardEntryClassCode"
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ReadOnly = False
            Me.ComboBoxPaymentManager_StandardEntryClassCode.SecurityEnabled = True
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Size = New System.Drawing.Size(644, 20)
            Me.ComboBoxPaymentManager_StandardEntryClassCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPaymentManager_StandardEntryClassCode.TabIndex = 18
            Me.ComboBoxPaymentManager_StandardEntryClassCode.TabOnEnter = True
            Me.ComboBoxPaymentManager_StandardEntryClassCode.ValueMember = "Code"
            Me.ComboBoxPaymentManager_StandardEntryClassCode.WatermarkText = "Select"
            '
            'ComboBoxPaymentManager_ServiceClassCode
            '
            Me.ComboBoxPaymentManager_ServiceClassCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPaymentManager_ServiceClassCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPaymentManager_ServiceClassCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPaymentManager_ServiceClassCode.AutoFindItemInDataSource = False
            Me.ComboBoxPaymentManager_ServiceClassCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPaymentManager_ServiceClassCode.BookmarkingEnabled = False
            Me.ComboBoxPaymentManager_ServiceClassCode.ClientCode = ""
            Me.ComboBoxPaymentManager_ServiceClassCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxPaymentManager_ServiceClassCode.DisableMouseWheel = False
            Me.ComboBoxPaymentManager_ServiceClassCode.DisplayMember = "Description"
            Me.ComboBoxPaymentManager_ServiceClassCode.DisplayName = ""
            Me.ComboBoxPaymentManager_ServiceClassCode.DivisionCode = ""
            Me.ComboBoxPaymentManager_ServiceClassCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPaymentManager_ServiceClassCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxPaymentManager_ServiceClassCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxPaymentManager_ServiceClassCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPaymentManager_ServiceClassCode.FocusHighlightEnabled = True
            Me.ComboBoxPaymentManager_ServiceClassCode.FormattingEnabled = True
            Me.ComboBoxPaymentManager_ServiceClassCode.ItemHeight = 14
            Me.ComboBoxPaymentManager_ServiceClassCode.Location = New System.Drawing.Point(419, 448)
            Me.ComboBoxPaymentManager_ServiceClassCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxPaymentManager_ServiceClassCode.Name = "ComboBoxPaymentManager_ServiceClassCode"
            Me.ComboBoxPaymentManager_ServiceClassCode.ReadOnly = False
            Me.ComboBoxPaymentManager_ServiceClassCode.SecurityEnabled = True
            Me.ComboBoxPaymentManager_ServiceClassCode.Size = New System.Drawing.Size(375, 20)
            Me.ComboBoxPaymentManager_ServiceClassCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPaymentManager_ServiceClassCode.TabIndex = 16
            Me.ComboBoxPaymentManager_ServiceClassCode.TabOnEnter = True
            Me.ComboBoxPaymentManager_ServiceClassCode.ValueMember = "Code"
            Me.ComboBoxPaymentManager_ServiceClassCode.WatermarkText = "Select"
            '
            'TextBoxPaymentManager_CompanyEntryDescription
            '
            Me.TextBoxPaymentManager_CompanyEntryDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_CompanyEntryDescription.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CompanyEntryDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CompanyEntryDescription.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CompanyEntryDescription.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CompanyEntryDescription.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CompanyEntryDescription.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CompanyEntryDescription.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CompanyEntryDescription.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CompanyEntryDescription.Location = New System.Drawing.Point(419, 572)
            Me.TextBoxPaymentManager_CompanyEntryDescription.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CompanyEntryDescription.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CompanyEntryDescription.Name = "TextBoxPaymentManager_CompanyEntryDescription"
            Me.TextBoxPaymentManager_CompanyEntryDescription.SecurityEnabled = True
            Me.TextBoxPaymentManager_CompanyEntryDescription.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CompanyEntryDescription.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_CompanyEntryDescription.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CompanyEntryDescription.TabIndex = 22
            Me.TextBoxPaymentManager_CompanyEntryDescription.TabOnEnter = True
            '
            'TextBoxPaymentManager_CompanyName
            '
            Me.TextBoxPaymentManager_CompanyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_CompanyName.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CompanyName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CompanyName.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CompanyName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CompanyName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CompanyName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CompanyName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CompanyName.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CompanyName.Location = New System.Drawing.Point(419, 510)
            Me.TextBoxPaymentManager_CompanyName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CompanyName.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CompanyName.Name = "TextBoxPaymentManager_CompanyName"
            Me.TextBoxPaymentManager_CompanyName.SecurityEnabled = True
            Me.TextBoxPaymentManager_CompanyName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CompanyName.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_CompanyName.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CompanyName.TabIndex = 20
            Me.TextBoxPaymentManager_CompanyName.TabOnEnter = True
            '
            'TextBoxPaymentManager_DestinationName
            '
            Me.TextBoxPaymentManager_DestinationName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_DestinationName.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_DestinationName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_DestinationName.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_DestinationName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_DestinationName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_DestinationName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_DestinationName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_DestinationName.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_DestinationName.Location = New System.Drawing.Point(419, 386)
            Me.TextBoxPaymentManager_DestinationName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_DestinationName.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_DestinationName.Name = "TextBoxPaymentManager_DestinationName"
            Me.TextBoxPaymentManager_DestinationName.SecurityEnabled = True
            Me.TextBoxPaymentManager_DestinationName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_DestinationName.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_DestinationName.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_DestinationName.TabIndex = 14
            Me.TextBoxPaymentManager_DestinationName.TabOnEnter = True
            '
            'LabelPaymentManager_StandardEntryClassCode
            '
            Me.LabelPaymentManager_StandardEntryClassCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_StandardEntryClassCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_StandardEntryClassCode.Location = New System.Drawing.Point(816, 448)
            Me.LabelPaymentManager_StandardEntryClassCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_StandardEntryClassCode.Name = "LabelPaymentManager_StandardEntryClassCode"
            Me.LabelPaymentManager_StandardEntryClassCode.Size = New System.Drawing.Size(384, 48)
            Me.LabelPaymentManager_StandardEntryClassCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_StandardEntryClassCode.TabIndex = 17
            Me.LabelPaymentManager_StandardEntryClassCode.Text = "Standard Entry Class Code:"
            '
            'LabelPaymentManager_ServiceClassCode
            '
            Me.LabelPaymentManager_ServiceClassCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_ServiceClassCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_ServiceClassCode.Location = New System.Drawing.Point(16, 448)
            Me.LabelPaymentManager_ServiceClassCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_ServiceClassCode.Name = "LabelPaymentManager_ServiceClassCode"
            Me.LabelPaymentManager_ServiceClassCode.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_ServiceClassCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_ServiceClassCode.TabIndex = 15
            Me.LabelPaymentManager_ServiceClassCode.Text = "Service Class Code:"
            '
            'LabelPaymentManager_DestinationName
            '
            Me.LabelPaymentManager_DestinationName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_DestinationName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_DestinationName.Location = New System.Drawing.Point(16, 386)
            Me.LabelPaymentManager_DestinationName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_DestinationName.Name = "LabelPaymentManager_DestinationName"
            Me.LabelPaymentManager_DestinationName.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_DestinationName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_DestinationName.TabIndex = 13
            Me.LabelPaymentManager_DestinationName.Text = "Destination Name:"
            '
            'LabelPaymentManager_ACHSettings
            '
            Me.LabelPaymentManager_ACHSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPaymentManager_ACHSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_ACHSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_ACHSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPaymentManager_ACHSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPaymentManager_ACHSettings.Location = New System.Drawing.Point(16, 324)
            Me.LabelPaymentManager_ACHSettings.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_ACHSettings.Name = "LabelPaymentManager_ACHSettings"
            Me.LabelPaymentManager_ACHSettings.Size = New System.Drawing.Size(1851, 48)
            Me.LabelPaymentManager_ACHSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_ACHSettings.TabIndex = 12
            Me.LabelPaymentManager_ACHSettings.Text = "ACH Settings"
            '
            'TextBoxPaymentManager_ComDataPassword
            '
            Me.TextBoxPaymentManager_ComDataPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_ComDataPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_ComDataPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_ComDataPassword.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_ComDataPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_ComDataPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_ComDataPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_ComDataPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_ComDataPassword.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_ComDataPassword.Location = New System.Drawing.Point(419, 942)
            Me.TextBoxPaymentManager_ComDataPassword.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_ComDataPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_ComDataPassword.Name = "TextBoxPaymentManager_ComDataPassword"
            Me.TextBoxPaymentManager_ComDataPassword.SecurityEnabled = True
            Me.TextBoxPaymentManager_ComDataPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_ComDataPassword.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_ComDataPassword.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_ComDataPassword.TabIndex = 33
            Me.TextBoxPaymentManager_ComDataPassword.TabOnEnter = True
            Me.TextBoxPaymentManager_ComDataPassword.UseSystemPasswordChar = True
            '
            'TextBoxPaymentManager_ComDataAccountCode
            '
            Me.TextBoxPaymentManager_ComDataAccountCode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_ComDataAccountCode.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_ComDataAccountCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_ComDataAccountCode.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_ComDataAccountCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_ComDataAccountCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_ComDataAccountCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_ComDataAccountCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_ComDataAccountCode.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_ComDataAccountCode.Location = New System.Drawing.Point(419, 880)
            Me.TextBoxPaymentManager_ComDataAccountCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_ComDataAccountCode.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_ComDataAccountCode.Name = "TextBoxPaymentManager_ComDataAccountCode"
            Me.TextBoxPaymentManager_ComDataAccountCode.SecurityEnabled = True
            Me.TextBoxPaymentManager_ComDataAccountCode.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_ComDataAccountCode.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_ComDataAccountCode.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_ComDataAccountCode.TabIndex = 31
            Me.TextBoxPaymentManager_ComDataAccountCode.TabOnEnter = True
            '
            'LabelPaymentManager_Password
            '
            Me.LabelPaymentManager_Password.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_Password.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_Password.Location = New System.Drawing.Point(16, 942)
            Me.LabelPaymentManager_Password.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_Password.Name = "LabelPaymentManager_Password"
            Me.LabelPaymentManager_Password.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_Password.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_Password.TabIndex = 32
            Me.LabelPaymentManager_Password.Text = "Password:"
            '
            'LabelPaymentManager_AccountCode
            '
            Me.LabelPaymentManager_AccountCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_AccountCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_AccountCode.Location = New System.Drawing.Point(16, 880)
            Me.LabelPaymentManager_AccountCode.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_AccountCode.Name = "LabelPaymentManager_AccountCode"
            Me.LabelPaymentManager_AccountCode.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_AccountCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_AccountCode.TabIndex = 30
            Me.LabelPaymentManager_AccountCode.Text = "Account Code:"
            '
            'TextBoxPaymentManager_CSITargetFolder
            '
            Me.TextBoxPaymentManager_CSITargetFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_CSITargetFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CSITargetFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CSITargetFolder.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CSITargetFolder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CSITargetFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CSITargetFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CSITargetFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CSITargetFolder.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CSITargetFolder.Location = New System.Drawing.Point(419, 818)
            Me.TextBoxPaymentManager_CSITargetFolder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CSITargetFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CSITargetFolder.Name = "TextBoxPaymentManager_CSITargetFolder"
            Me.TextBoxPaymentManager_CSITargetFolder.SecurityEnabled = True
            Me.TextBoxPaymentManager_CSITargetFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CSITargetFolder.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_CSITargetFolder.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CSITargetFolder.TabIndex = 29
            Me.TextBoxPaymentManager_CSITargetFolder.TabOnEnter = True
            '
            'TextBoxPaymentManager_CSIPassword
            '
            Me.TextBoxPaymentManager_CSIPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_CSIPassword.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CSIPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CSIPassword.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CSIPassword.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CSIPassword.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CSIPassword.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CSIPassword.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CSIPassword.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CSIPassword.Location = New System.Drawing.Point(419, 756)
            Me.TextBoxPaymentManager_CSIPassword.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CSIPassword.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CSIPassword.Name = "TextBoxPaymentManager_CSIPassword"
            Me.TextBoxPaymentManager_CSIPassword.SecurityEnabled = True
            Me.TextBoxPaymentManager_CSIPassword.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CSIPassword.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_CSIPassword.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CSIPassword.TabIndex = 27
            Me.TextBoxPaymentManager_CSIPassword.TabOnEnter = True
            Me.TextBoxPaymentManager_CSIPassword.UseSystemPasswordChar = True
            '
            'TextBoxPaymentManager_CSIUserName
            '
            Me.TextBoxPaymentManager_CSIUserName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_CSIUserName.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CSIUserName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CSIUserName.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CSIUserName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CSIUserName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CSIUserName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CSIUserName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CSIUserName.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CSIUserName.Location = New System.Drawing.Point(419, 694)
            Me.TextBoxPaymentManager_CSIUserName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CSIUserName.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CSIUserName.Name = "TextBoxPaymentManager_CSIUserName"
            Me.TextBoxPaymentManager_CSIUserName.SecurityEnabled = True
            Me.TextBoxPaymentManager_CSIUserName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CSIUserName.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_CSIUserName.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CSIUserName.TabIndex = 25
            Me.TextBoxPaymentManager_CSIUserName.TabOnEnter = True
            '
            'LabelPaymentManager_CSITargetFolder
            '
            Me.LabelPaymentManager_CSITargetFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CSITargetFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CSITargetFolder.Location = New System.Drawing.Point(16, 818)
            Me.LabelPaymentManager_CSITargetFolder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CSITargetFolder.Name = "LabelPaymentManager_CSITargetFolder"
            Me.LabelPaymentManager_CSITargetFolder.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CSITargetFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CSITargetFolder.TabIndex = 28
            Me.LabelPaymentManager_CSITargetFolder.Text = "Target Folder:"
            '
            'LabelPaymentManager_CSIPassword
            '
            Me.LabelPaymentManager_CSIPassword.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CSIPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CSIPassword.Location = New System.Drawing.Point(16, 756)
            Me.LabelPaymentManager_CSIPassword.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CSIPassword.Name = "LabelPaymentManager_CSIPassword"
            Me.LabelPaymentManager_CSIPassword.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CSIPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CSIPassword.TabIndex = 26
            Me.LabelPaymentManager_CSIPassword.Text = "Password:"
            '
            'LabelPaymentManager_CSIUserName
            '
            Me.LabelPaymentManager_CSIUserName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CSIUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CSIUserName.Location = New System.Drawing.Point(16, 694)
            Me.LabelPaymentManager_CSIUserName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CSIUserName.Name = "LabelPaymentManager_CSIUserName"
            Me.LabelPaymentManager_CSIUserName.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CSIUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CSIUserName.TabIndex = 24
            Me.LabelPaymentManager_CSIUserName.Text = "User Name:"
            '
            'LabelPaymentManager_CSIPreferredPartnerSettings
            '
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Location = New System.Drawing.Point(16, 634)
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Name = "LabelPaymentManager_CSIPreferredPartnerSettings"
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Size = New System.Drawing.Size(1851, 48)
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.TabIndex = 23
            Me.LabelPaymentManager_CSIPreferredPartnerSettings.Text = "CSI Preferred Partner Settings"
            '
            'TextBoxPaymentManager_FileOutputDirectory
            '
            Me.TextBoxPaymentManager_FileOutputDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FileOutputDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FileOutputDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FileOutputDirectory.ButtonCustom.Visible = True
            Me.TextBoxPaymentManager_FileOutputDirectory.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FileOutputDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxPaymentManager_FileOutputDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FileOutputDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FileOutputDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FileOutputDirectory.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FileOutputDirectory.Location = New System.Drawing.Point(419, 262)
            Me.TextBoxPaymentManager_FileOutputDirectory.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FileOutputDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FileOutputDirectory.Name = "TextBoxPaymentManager_FileOutputDirectory"
            Me.TextBoxPaymentManager_FileOutputDirectory.SecurityEnabled = True
            Me.TextBoxPaymentManager_FileOutputDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FileOutputDirectory.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FileOutputDirectory.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FileOutputDirectory.TabIndex = 11
            Me.TextBoxPaymentManager_FileOutputDirectory.TabOnEnter = True
            '
            'TextBoxPaymentManager_FTPClient
            '
            Me.TextBoxPaymentManager_FTPClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_FTPClient.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_FTPClient.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_FTPClient.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_FTPClient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_FTPClient.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_FTPClient.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_FTPClient.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_FTPClient.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_FTPClient.Location = New System.Drawing.Point(419, 200)
            Me.TextBoxPaymentManager_FTPClient.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_FTPClient.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_FTPClient.Name = "TextBoxPaymentManager_FTPClient"
            Me.TextBoxPaymentManager_FTPClient.SecurityEnabled = True
            Me.TextBoxPaymentManager_FTPClient.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_FTPClient.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_FTPClient.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_FTPClient.TabIndex = 9
            Me.TextBoxPaymentManager_FTPClient.TabOnEnter = True
            '
            'TextBoxPaymentManager_Word
            '
            Me.TextBoxPaymentManager_Word.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_Word.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_Word.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_Word.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_Word.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_Word.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_Word.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_Word.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_Word.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_Word.Location = New System.Drawing.Point(877, 138)
            Me.TextBoxPaymentManager_Word.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_Word.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_Word.Name = "TextBoxPaymentManager_Word"
            Me.TextBoxPaymentManager_Word.SecurityEnabled = True
            Me.TextBoxPaymentManager_Word.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_Word.Size = New System.Drawing.Size(989, 38)
            Me.TextBoxPaymentManager_Word.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_Word.TabIndex = 7
            Me.TextBoxPaymentManager_Word.TabOnEnter = True
            '
            'TextBoxPaymentManager_CustomerID
            '
            '
            '
            '
            Me.TextBoxPaymentManager_CustomerID.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_CustomerID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_CustomerID.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_CustomerID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_CustomerID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_CustomerID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_CustomerID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_CustomerID.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_CustomerID.Location = New System.Drawing.Point(419, 138)
            Me.TextBoxPaymentManager_CustomerID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_CustomerID.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_CustomerID.MaximumSize = New System.Drawing.Size(216, 0)
            Me.TextBoxPaymentManager_CustomerID.Name = "TextBoxPaymentManager_CustomerID"
            Me.TextBoxPaymentManager_CustomerID.SecurityEnabled = True
            Me.TextBoxPaymentManager_CustomerID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_CustomerID.Size = New System.Drawing.Size(216, 38)
            Me.TextBoxPaymentManager_CustomerID.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_CustomerID.TabIndex = 5
            Me.TextBoxPaymentManager_CustomerID.TabOnEnter = True
            '
            'LabelPaymentManager_FileOutputDirectory
            '
            Me.LabelPaymentManager_FileOutputDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FileOutputDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FileOutputDirectory.Location = New System.Drawing.Point(16, 262)
            Me.LabelPaymentManager_FileOutputDirectory.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FileOutputDirectory.Name = "LabelPaymentManager_FileOutputDirectory"
            Me.LabelPaymentManager_FileOutputDirectory.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FileOutputDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FileOutputDirectory.TabIndex = 10
            Me.LabelPaymentManager_FileOutputDirectory.Text = "File Output Directory:"
            '
            'LabelPaymentManager_FTPClient
            '
            Me.LabelPaymentManager_FTPClient.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_FTPClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_FTPClient.Location = New System.Drawing.Point(16, 200)
            Me.LabelPaymentManager_FTPClient.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_FTPClient.Name = "LabelPaymentManager_FTPClient"
            Me.LabelPaymentManager_FTPClient.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_FTPClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_FTPClient.TabIndex = 8
            Me.LabelPaymentManager_FTPClient.Text = "FTP Client:"
            '
            'LabelPaymentManager_Word
            '
            Me.LabelPaymentManager_Word.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_Word.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_Word.Location = New System.Drawing.Point(651, 138)
            Me.LabelPaymentManager_Word.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_Word.Name = "LabelPaymentManager_Word"
            Me.LabelPaymentManager_Word.Size = New System.Drawing.Size(211, 48)
            Me.LabelPaymentManager_Word.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_Word.TabIndex = 6
            Me.LabelPaymentManager_Word.Text = "Word:"
            '
            'LabelPaymentManager_CustomerID
            '
            Me.LabelPaymentManager_CustomerID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_CustomerID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_CustomerID.Location = New System.Drawing.Point(16, 138)
            Me.LabelPaymentManager_CustomerID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_CustomerID.Name = "LabelPaymentManager_CustomerID"
            Me.LabelPaymentManager_CustomerID.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_CustomerID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_CustomerID.TabIndex = 4
            Me.LabelPaymentManager_CustomerID.Text = "Customer ID:"
            '
            'LabelPaymentManager_ExportType
            '
            Me.LabelPaymentManager_ExportType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_ExportType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_ExportType.Location = New System.Drawing.Point(16, 76)
            Me.LabelPaymentManager_ExportType.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_ExportType.Name = "LabelPaymentManager_ExportType"
            Me.LabelPaymentManager_ExportType.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_ExportType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_ExportType.TabIndex = 2
            Me.LabelPaymentManager_ExportType.Text = "Export Type:"
            '
            'TextBoxPaymentManager_AccountNumber
            '
            Me.TextBoxPaymentManager_AccountNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPaymentManager_AccountNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxPaymentManager_AccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPaymentManager_AccountNumber.CheckSpellingOnValidate = False
            Me.TextBoxPaymentManager_AccountNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPaymentManager_AccountNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxPaymentManager_AccountNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPaymentManager_AccountNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPaymentManager_AccountNumber.FocusHighlightEnabled = True
            Me.TextBoxPaymentManager_AccountNumber.Location = New System.Drawing.Point(419, 14)
            Me.TextBoxPaymentManager_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxPaymentManager_AccountNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxPaymentManager_AccountNumber.Name = "TextBoxPaymentManager_AccountNumber"
            Me.TextBoxPaymentManager_AccountNumber.SecurityEnabled = True
            Me.TextBoxPaymentManager_AccountNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPaymentManager_AccountNumber.Size = New System.Drawing.Size(1448, 38)
            Me.TextBoxPaymentManager_AccountNumber.StartingFolderName = Nothing
            Me.TextBoxPaymentManager_AccountNumber.TabIndex = 1
            Me.TextBoxPaymentManager_AccountNumber.TabOnEnter = True
            '
            'LabelPaymentManager_AccountNumber
            '
            Me.LabelPaymentManager_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPaymentManager_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPaymentManager_AccountNumber.Location = New System.Drawing.Point(16, 14)
            Me.LabelPaymentManager_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelPaymentManager_AccountNumber.Name = "LabelPaymentManager_AccountNumber"
            Me.LabelPaymentManager_AccountNumber.Size = New System.Drawing.Size(387, 48)
            Me.LabelPaymentManager_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPaymentManager_AccountNumber.TabIndex = 0
            Me.LabelPaymentManager_AccountNumber.Text = "Account Number:"
            '
            'TabItemBankDetails_PaymentManager
            '
            Me.TabItemBankDetails_PaymentManager.AttachedControl = Me.TabControlPanelPaymentManager_PaymentManager
            Me.TabItemBankDetails_PaymentManager.Name = "TabItemBankDetails_PaymentManager"
            Me.TabItemBankDetails_PaymentManager.Text = "Payment Manager"
            Me.TabItemBankDetails_PaymentManager.Visible = False
            '
            'TabControlPanelCheckExport2_CheckExport2
            '
            Me.TabControlPanelCheckExport2_CheckExport2.Controls.Add(Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout)
            Me.TabControlPanelCheckExport2_CheckExport2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCheckExport2_CheckExport2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCheckExport2_CheckExport2.Location = New System.Drawing.Point(0, 56)
            Me.TabControlPanelCheckExport2_CheckExport2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelCheckExport2_CheckExport2.Name = "TabControlPanelCheckExport2_CheckExport2"
            Me.TabControlPanelCheckExport2_CheckExport2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelCheckExport2_CheckExport2.Size = New System.Drawing.Size(1883, 1508)
            Me.TabControlPanelCheckExport2_CheckExport2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCheckExport2_CheckExport2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCheckExport2_CheckExport2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCheckExport2_CheckExport2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCheckExport2_CheckExport2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCheckExport2_CheckExport2.Style.GradientAngle = 90
            Me.TabControlPanelCheckExport2_CheckExport2.TabIndex = 4
            Me.TabControlPanelCheckExport2_CheckExport2.TabItem = Me.TabItemBankDetails_CheckExport2
            '
            'TableLayoutPanelCheckExport2_CheckExport2TableLayout
            '
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.ColumnCount = 2
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Controls.Add(Me.PanelCheckExport2TableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Controls.Add(Me.PanelCheckExport2TableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Name = "TableLayoutPanelCheckExport2_CheckExport2TableLayout"
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.RowCount = 1
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.Size = New System.Drawing.Size(1883, 837)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.TabIndex = 0
            '
            'PanelCheckExport2TableLayout_RightColumn
            '
            Me.PanelCheckExport2TableLayout_RightColumn.Controls.Add(Me.GroupBoxCheckExport2_TrailerRecord)
            Me.PanelCheckExport2TableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelCheckExport2TableLayout_RightColumn.Location = New System.Drawing.Point(941, 0)
            Me.PanelCheckExport2TableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelCheckExport2TableLayout_RightColumn.Name = "PanelCheckExport2TableLayout_RightColumn"
            Me.PanelCheckExport2TableLayout_RightColumn.Size = New System.Drawing.Size(942, 837)
            Me.PanelCheckExport2TableLayout_RightColumn.TabIndex = 1
            '
            'GroupBoxCheckExport2_TrailerRecord
            '
            Me.GroupBoxCheckExport2_TrailerRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_Export)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_BeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_RecordCountCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_RecordCountEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_RecordCountBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_TotalFlagEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_TotalFlagCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_TotalFlagBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_RecordCountExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_TotalFlagExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_TotalFlag)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_RecordCount)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_ExportAmountCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_ExportAmountEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_ExportAmountBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_FileDateEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_FileDateCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_FileDateBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_ExportAmountExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_FileDateExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_FileDate)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_ExportAmount)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.TextBoxTrailerRecord_Filler4FillValue)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler4EndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler4BeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_Filler4Export)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_Filler4)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.TextBoxTrailerRecord_Filler3FillValue)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler3EndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler3BeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_Filler3Export)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_Filler3)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.TextBoxTrailerRecord_Filler2FillValue)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.TextBoxTrailerRecord_Filler1FillValue)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler2EndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler2BeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_Filler2Export)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler1EndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_Filler1BeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_Filler1Export)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_AccountNumberCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_AccountNumberEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_AccountNumberBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_BankIDEndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_BankIDCSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.NumericInputTrailerRecord_BankIDBeginPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_AccountNumberExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_Filler2)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.CheckBoxTrailerRecord_BankIDExport)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_Filler1)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_FillValue)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_BankID)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_CSVOrder)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_EndPosition)
            Me.GroupBoxCheckExport2_TrailerRecord.Controls.Add(Me.LabelTrailerRecord_AccountNumber)
            Me.GroupBoxCheckExport2_TrailerRecord.Location = New System.Drawing.Point(8, 14)
            Me.GroupBoxCheckExport2_TrailerRecord.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.GroupBoxCheckExport2_TrailerRecord.Name = "GroupBoxCheckExport2_TrailerRecord"
            Me.GroupBoxCheckExport2_TrailerRecord.Size = New System.Drawing.Size(918, 811)
            Me.GroupBoxCheckExport2_TrailerRecord.TabIndex = 0
            Me.GroupBoxCheckExport2_TrailerRecord.Text = "Trailer Record"
            '
            'LabelTrailerRecord_Export
            '
            Me.LabelTrailerRecord_Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_Export.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTrailerRecord_Export.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTrailerRecord_Export.Location = New System.Drawing.Point(235, 62)
            Me.LabelTrailerRecord_Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_Export.Name = "LabelTrailerRecord_Export"
            Me.LabelTrailerRecord_Export.Size = New System.Drawing.Size(88, 48)
            Me.LabelTrailerRecord_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_Export.TabIndex = 0
            Me.LabelTrailerRecord_Export.Text = "Export"
            '
            'LabelTrailerRecord_BeginPosition
            '
            Me.LabelTrailerRecord_BeginPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_BeginPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_BeginPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTrailerRecord_BeginPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTrailerRecord_BeginPosition.Location = New System.Drawing.Point(341, 62)
            Me.LabelTrailerRecord_BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_BeginPosition.Name = "LabelTrailerRecord_BeginPosition"
            Me.LabelTrailerRecord_BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelTrailerRecord_BeginPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_BeginPosition.TabIndex = 1
            Me.LabelTrailerRecord_BeginPosition.Text = "Beg Pos"
            '
            'NumericInputTrailerRecord_RecordCountCSVOrder
            '
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Location = New System.Drawing.Point(667, 434)
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Name = "NumericInputTrailerRecord_RecordCountCSVOrder"
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_RecordCountCSVOrder.TabIndex = 33
            '
            'NumericInputTrailerRecord_RecordCountEndPosition
            '
            Me.NumericInputTrailerRecord_RecordCountEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_RecordCountEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_RecordCountEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Location = New System.Drawing.Point(504, 434)
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Name = "NumericInputTrailerRecord_RecordCountEndPosition"
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_RecordCountEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_RecordCountEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_RecordCountEndPosition.TabIndex = 32
            '
            'NumericInputTrailerRecord_RecordCountBeginPosition
            '
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Location = New System.Drawing.Point(341, 434)
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Name = "NumericInputTrailerRecord_RecordCountBeginPosition"
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_RecordCountBeginPosition.TabIndex = 31
            '
            'NumericInputTrailerRecord_TotalFlagEndPosition
            '
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Location = New System.Drawing.Point(504, 372)
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Name = "NumericInputTrailerRecord_TotalFlagEndPosition"
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_TotalFlagEndPosition.TabIndex = 27
            '
            'NumericInputTrailerRecord_TotalFlagCSVOrder
            '
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Location = New System.Drawing.Point(667, 372)
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Name = "NumericInputTrailerRecord_TotalFlagCSVOrder"
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_TotalFlagCSVOrder.TabIndex = 28
            '
            'NumericInputTrailerRecord_TotalFlagBeginPosition
            '
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Location = New System.Drawing.Point(341, 372)
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Name = "NumericInputTrailerRecord_TotalFlagBeginPosition"
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_TotalFlagBeginPosition.TabIndex = 26
            '
            'CheckBoxTrailerRecord_RecordCountExport
            '
            Me.CheckBoxTrailerRecord_RecordCountExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_RecordCountExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_RecordCountExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_RecordCountExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_RecordCountExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_RecordCountExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_RecordCountExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_RecordCountExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_RecordCountExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_RecordCountExport.Location = New System.Drawing.Point(235, 434)
            Me.CheckBoxTrailerRecord_RecordCountExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_RecordCountExport.Name = "CheckBoxTrailerRecord_RecordCountExport"
            Me.CheckBoxTrailerRecord_RecordCountExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_RecordCountExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_RecordCountExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_RecordCountExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_RecordCountExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_RecordCountExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_RecordCountExport.TabIndex = 30
            Me.CheckBoxTrailerRecord_RecordCountExport.TabOnEnter = True
            '
            'CheckBoxTrailerRecord_TotalFlagExport
            '
            Me.CheckBoxTrailerRecord_TotalFlagExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_TotalFlagExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_TotalFlagExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_TotalFlagExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_TotalFlagExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_TotalFlagExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_TotalFlagExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_TotalFlagExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_TotalFlagExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_TotalFlagExport.Location = New System.Drawing.Point(235, 372)
            Me.CheckBoxTrailerRecord_TotalFlagExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_TotalFlagExport.Name = "CheckBoxTrailerRecord_TotalFlagExport"
            Me.CheckBoxTrailerRecord_TotalFlagExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_TotalFlagExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_TotalFlagExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_TotalFlagExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_TotalFlagExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_TotalFlagExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_TotalFlagExport.TabIndex = 25
            Me.CheckBoxTrailerRecord_TotalFlagExport.TabOnEnter = True
            '
            'LabelTrailerRecord_TotalFlag
            '
            Me.LabelTrailerRecord_TotalFlag.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_TotalFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_TotalFlag.Location = New System.Drawing.Point(16, 372)
            Me.LabelTrailerRecord_TotalFlag.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_TotalFlag.Name = "LabelTrailerRecord_TotalFlag"
            Me.LabelTrailerRecord_TotalFlag.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_TotalFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_TotalFlag.TabIndex = 24
            Me.LabelTrailerRecord_TotalFlag.Text = "Total Flag:"
            '
            'LabelTrailerRecord_RecordCount
            '
            Me.LabelTrailerRecord_RecordCount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_RecordCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_RecordCount.Location = New System.Drawing.Point(16, 434)
            Me.LabelTrailerRecord_RecordCount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_RecordCount.Name = "LabelTrailerRecord_RecordCount"
            Me.LabelTrailerRecord_RecordCount.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_RecordCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_RecordCount.TabIndex = 29
            Me.LabelTrailerRecord_RecordCount.Text = "Record Count:"
            '
            'NumericInputTrailerRecord_ExportAmountCSVOrder
            '
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Location = New System.Drawing.Point(667, 310)
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Name = "NumericInputTrailerRecord_ExportAmountCSVOrder"
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_ExportAmountCSVOrder.TabIndex = 23
            '
            'NumericInputTrailerRecord_ExportAmountEndPosition
            '
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Location = New System.Drawing.Point(504, 310)
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Name = "NumericInputTrailerRecord_ExportAmountEndPosition"
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_ExportAmountEndPosition.TabIndex = 22
            '
            'NumericInputTrailerRecord_ExportAmountBeginPosition
            '
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Location = New System.Drawing.Point(341, 310)
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Name = "NumericInputTrailerRecord_ExportAmountBeginPosition"
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_ExportAmountBeginPosition.TabIndex = 21
            '
            'NumericInputTrailerRecord_FileDateEndPosition
            '
            Me.NumericInputTrailerRecord_FileDateEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_FileDateEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_FileDateEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_FileDateEndPosition.Location = New System.Drawing.Point(504, 248)
            Me.NumericInputTrailerRecord_FileDateEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_FileDateEndPosition.Name = "NumericInputTrailerRecord_FileDateEndPosition"
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_FileDateEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_FileDateEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_FileDateEndPosition.TabIndex = 17
            '
            'NumericInputTrailerRecord_FileDateCSVOrder
            '
            Me.NumericInputTrailerRecord_FileDateCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_FileDateCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_FileDateCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Location = New System.Drawing.Point(667, 248)
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Name = "NumericInputTrailerRecord_FileDateCSVOrder"
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_FileDateCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_FileDateCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_FileDateCSVOrder.TabIndex = 18
            '
            'NumericInputTrailerRecord_FileDateBeginPosition
            '
            Me.NumericInputTrailerRecord_FileDateBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_FileDateBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_FileDateBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Location = New System.Drawing.Point(341, 248)
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Name = "NumericInputTrailerRecord_FileDateBeginPosition"
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_FileDateBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_FileDateBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_FileDateBeginPosition.TabIndex = 16
            '
            'CheckBoxTrailerRecord_ExportAmountExport
            '
            Me.CheckBoxTrailerRecord_ExportAmountExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_ExportAmountExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_ExportAmountExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_ExportAmountExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_ExportAmountExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_ExportAmountExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_ExportAmountExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_ExportAmountExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_ExportAmountExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_ExportAmountExport.Location = New System.Drawing.Point(235, 310)
            Me.CheckBoxTrailerRecord_ExportAmountExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_ExportAmountExport.Name = "CheckBoxTrailerRecord_ExportAmountExport"
            Me.CheckBoxTrailerRecord_ExportAmountExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_ExportAmountExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_ExportAmountExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_ExportAmountExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_ExportAmountExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_ExportAmountExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_ExportAmountExport.TabIndex = 20
            Me.CheckBoxTrailerRecord_ExportAmountExport.TabOnEnter = True
            '
            'CheckBoxTrailerRecord_FileDateExport
            '
            Me.CheckBoxTrailerRecord_FileDateExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_FileDateExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_FileDateExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_FileDateExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_FileDateExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_FileDateExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_FileDateExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_FileDateExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_FileDateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_FileDateExport.Location = New System.Drawing.Point(235, 248)
            Me.CheckBoxTrailerRecord_FileDateExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_FileDateExport.Name = "CheckBoxTrailerRecord_FileDateExport"
            Me.CheckBoxTrailerRecord_FileDateExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_FileDateExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_FileDateExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_FileDateExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_FileDateExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_FileDateExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_FileDateExport.TabIndex = 15
            Me.CheckBoxTrailerRecord_FileDateExport.TabOnEnter = True
            '
            'LabelTrailerRecord_FileDate
            '
            Me.LabelTrailerRecord_FileDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_FileDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_FileDate.Location = New System.Drawing.Point(16, 248)
            Me.LabelTrailerRecord_FileDate.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_FileDate.Name = "LabelTrailerRecord_FileDate"
            Me.LabelTrailerRecord_FileDate.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_FileDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_FileDate.TabIndex = 14
            Me.LabelTrailerRecord_FileDate.Text = "File Date:"
            '
            'LabelTrailerRecord_ExportAmount
            '
            Me.LabelTrailerRecord_ExportAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_ExportAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_ExportAmount.Location = New System.Drawing.Point(16, 310)
            Me.LabelTrailerRecord_ExportAmount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_ExportAmount.Name = "LabelTrailerRecord_ExportAmount"
            Me.LabelTrailerRecord_ExportAmount.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_ExportAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_ExportAmount.TabIndex = 19
            Me.LabelTrailerRecord_ExportAmount.Text = "Export Amt:"
            '
            'TextBoxTrailerRecord_Filler4FillValue
            '
            '
            '
            '
            Me.TextBoxTrailerRecord_Filler4FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTrailerRecord_Filler4FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTrailerRecord_Filler4FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTrailerRecord_Filler4FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTrailerRecord_Filler4FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTrailerRecord_Filler4FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTrailerRecord_Filler4FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTrailerRecord_Filler4FillValue.FocusHighlightEnabled = True
            Me.TextBoxTrailerRecord_Filler4FillValue.Location = New System.Drawing.Point(667, 744)
            Me.TextBoxTrailerRecord_Filler4FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTrailerRecord_Filler4FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTrailerRecord_Filler4FillValue.Name = "TextBoxTrailerRecord_Filler4FillValue"
            Me.TextBoxTrailerRecord_Filler4FillValue.SecurityEnabled = True
            Me.TextBoxTrailerRecord_Filler4FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTrailerRecord_Filler4FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTrailerRecord_Filler4FillValue.StartingFolderName = Nothing
            Me.TextBoxTrailerRecord_Filler4FillValue.TabIndex = 54
            Me.TextBoxTrailerRecord_Filler4FillValue.TabOnEnter = True
            '
            'NumericInputTrailerRecord_Filler4EndPosition
            '
            Me.NumericInputTrailerRecord_Filler4EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler4EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler4EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler4EndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler4EndPosition.Location = New System.Drawing.Point(504, 744)
            Me.NumericInputTrailerRecord_Filler4EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler4EndPosition.Name = "NumericInputTrailerRecord_Filler4EndPosition"
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler4EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler4EndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler4EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler4EndPosition.TabIndex = 53
            '
            'NumericInputTrailerRecord_Filler4BeginPosition
            '
            Me.NumericInputTrailerRecord_Filler4BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler4BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler4BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler4BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Location = New System.Drawing.Point(341, 744)
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Name = "NumericInputTrailerRecord_Filler4BeginPosition"
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler4BeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler4BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler4BeginPosition.TabIndex = 52
            '
            'CheckBoxTrailerRecord_Filler4Export
            '
            Me.CheckBoxTrailerRecord_Filler4Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_Filler4Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_Filler4Export.CheckValue = 0
            Me.CheckBoxTrailerRecord_Filler4Export.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_Filler4Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_Filler4Export.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_Filler4Export.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler4Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler4Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_Filler4Export.Location = New System.Drawing.Point(235, 744)
            Me.CheckBoxTrailerRecord_Filler4Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_Filler4Export.Name = "CheckBoxTrailerRecord_Filler4Export"
            Me.CheckBoxTrailerRecord_Filler4Export.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_Filler4Export.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_Filler4Export.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler4Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler4Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_Filler4Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_Filler4Export.TabIndex = 51
            Me.CheckBoxTrailerRecord_Filler4Export.TabOnEnter = True
            '
            'LabelTrailerRecord_Filler4
            '
            Me.LabelTrailerRecord_Filler4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_Filler4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_Filler4.Location = New System.Drawing.Point(16, 744)
            Me.LabelTrailerRecord_Filler4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_Filler4.Name = "LabelTrailerRecord_Filler4"
            Me.LabelTrailerRecord_Filler4.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_Filler4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_Filler4.TabIndex = 50
            Me.LabelTrailerRecord_Filler4.Text = "Filler 4:"
            '
            'TextBoxTrailerRecord_Filler3FillValue
            '
            '
            '
            '
            Me.TextBoxTrailerRecord_Filler3FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTrailerRecord_Filler3FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTrailerRecord_Filler3FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTrailerRecord_Filler3FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTrailerRecord_Filler3FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTrailerRecord_Filler3FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTrailerRecord_Filler3FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTrailerRecord_Filler3FillValue.FocusHighlightEnabled = True
            Me.TextBoxTrailerRecord_Filler3FillValue.Location = New System.Drawing.Point(667, 682)
            Me.TextBoxTrailerRecord_Filler3FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTrailerRecord_Filler3FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTrailerRecord_Filler3FillValue.Name = "TextBoxTrailerRecord_Filler3FillValue"
            Me.TextBoxTrailerRecord_Filler3FillValue.SecurityEnabled = True
            Me.TextBoxTrailerRecord_Filler3FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTrailerRecord_Filler3FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTrailerRecord_Filler3FillValue.StartingFolderName = Nothing
            Me.TextBoxTrailerRecord_Filler3FillValue.TabIndex = 49
            Me.TextBoxTrailerRecord_Filler3FillValue.TabOnEnter = True
            '
            'NumericInputTrailerRecord_Filler3EndPosition
            '
            Me.NumericInputTrailerRecord_Filler3EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler3EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler3EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler3EndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler3EndPosition.Location = New System.Drawing.Point(504, 682)
            Me.NumericInputTrailerRecord_Filler3EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler3EndPosition.Name = "NumericInputTrailerRecord_Filler3EndPosition"
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler3EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler3EndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler3EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler3EndPosition.TabIndex = 48
            '
            'NumericInputTrailerRecord_Filler3BeginPosition
            '
            Me.NumericInputTrailerRecord_Filler3BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler3BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler3BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler3BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Location = New System.Drawing.Point(341, 682)
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Name = "NumericInputTrailerRecord_Filler3BeginPosition"
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler3BeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler3BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler3BeginPosition.TabIndex = 47
            '
            'CheckBoxTrailerRecord_Filler3Export
            '
            Me.CheckBoxTrailerRecord_Filler3Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_Filler3Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_Filler3Export.CheckValue = 0
            Me.CheckBoxTrailerRecord_Filler3Export.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_Filler3Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_Filler3Export.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_Filler3Export.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler3Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler3Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_Filler3Export.Location = New System.Drawing.Point(235, 682)
            Me.CheckBoxTrailerRecord_Filler3Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_Filler3Export.Name = "CheckBoxTrailerRecord_Filler3Export"
            Me.CheckBoxTrailerRecord_Filler3Export.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_Filler3Export.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_Filler3Export.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler3Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler3Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_Filler3Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_Filler3Export.TabIndex = 46
            Me.CheckBoxTrailerRecord_Filler3Export.TabOnEnter = True
            '
            'LabelTrailerRecord_Filler3
            '
            Me.LabelTrailerRecord_Filler3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_Filler3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_Filler3.Location = New System.Drawing.Point(16, 682)
            Me.LabelTrailerRecord_Filler3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_Filler3.Name = "LabelTrailerRecord_Filler3"
            Me.LabelTrailerRecord_Filler3.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_Filler3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_Filler3.TabIndex = 45
            Me.LabelTrailerRecord_Filler3.Text = "Filler 3:"
            '
            'TextBoxTrailerRecord_Filler2FillValue
            '
            '
            '
            '
            Me.TextBoxTrailerRecord_Filler2FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTrailerRecord_Filler2FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTrailerRecord_Filler2FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTrailerRecord_Filler2FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTrailerRecord_Filler2FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTrailerRecord_Filler2FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTrailerRecord_Filler2FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTrailerRecord_Filler2FillValue.FocusHighlightEnabled = True
            Me.TextBoxTrailerRecord_Filler2FillValue.Location = New System.Drawing.Point(667, 620)
            Me.TextBoxTrailerRecord_Filler2FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTrailerRecord_Filler2FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTrailerRecord_Filler2FillValue.Name = "TextBoxTrailerRecord_Filler2FillValue"
            Me.TextBoxTrailerRecord_Filler2FillValue.SecurityEnabled = True
            Me.TextBoxTrailerRecord_Filler2FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTrailerRecord_Filler2FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTrailerRecord_Filler2FillValue.StartingFolderName = Nothing
            Me.TextBoxTrailerRecord_Filler2FillValue.TabIndex = 44
            Me.TextBoxTrailerRecord_Filler2FillValue.TabOnEnter = True
            '
            'TextBoxTrailerRecord_Filler1FillValue
            '
            '
            '
            '
            Me.TextBoxTrailerRecord_Filler1FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTrailerRecord_Filler1FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTrailerRecord_Filler1FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTrailerRecord_Filler1FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTrailerRecord_Filler1FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTrailerRecord_Filler1FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTrailerRecord_Filler1FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTrailerRecord_Filler1FillValue.FocusHighlightEnabled = True
            Me.TextBoxTrailerRecord_Filler1FillValue.Location = New System.Drawing.Point(667, 558)
            Me.TextBoxTrailerRecord_Filler1FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTrailerRecord_Filler1FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTrailerRecord_Filler1FillValue.Name = "TextBoxTrailerRecord_Filler1FillValue"
            Me.TextBoxTrailerRecord_Filler1FillValue.SecurityEnabled = True
            Me.TextBoxTrailerRecord_Filler1FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTrailerRecord_Filler1FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTrailerRecord_Filler1FillValue.StartingFolderName = Nothing
            Me.TextBoxTrailerRecord_Filler1FillValue.TabIndex = 39
            Me.TextBoxTrailerRecord_Filler1FillValue.TabOnEnter = True
            '
            'NumericInputTrailerRecord_Filler2EndPosition
            '
            Me.NumericInputTrailerRecord_Filler2EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler2EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler2EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler2EndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler2EndPosition.Location = New System.Drawing.Point(504, 620)
            Me.NumericInputTrailerRecord_Filler2EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler2EndPosition.Name = "NumericInputTrailerRecord_Filler2EndPosition"
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler2EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler2EndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler2EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler2EndPosition.TabIndex = 43
            '
            'NumericInputTrailerRecord_Filler2BeginPosition
            '
            Me.NumericInputTrailerRecord_Filler2BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler2BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler2BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler2BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Location = New System.Drawing.Point(341, 620)
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Name = "NumericInputTrailerRecord_Filler2BeginPosition"
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler2BeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler2BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler2BeginPosition.TabIndex = 42
            '
            'CheckBoxTrailerRecord_Filler2Export
            '
            Me.CheckBoxTrailerRecord_Filler2Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_Filler2Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_Filler2Export.CheckValue = 0
            Me.CheckBoxTrailerRecord_Filler2Export.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_Filler2Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_Filler2Export.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_Filler2Export.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler2Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler2Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_Filler2Export.Location = New System.Drawing.Point(235, 620)
            Me.CheckBoxTrailerRecord_Filler2Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_Filler2Export.Name = "CheckBoxTrailerRecord_Filler2Export"
            Me.CheckBoxTrailerRecord_Filler2Export.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_Filler2Export.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_Filler2Export.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler2Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler2Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_Filler2Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_Filler2Export.TabIndex = 41
            Me.CheckBoxTrailerRecord_Filler2Export.TabOnEnter = True
            '
            'NumericInputTrailerRecord_Filler1EndPosition
            '
            Me.NumericInputTrailerRecord_Filler1EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler1EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler1EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler1EndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler1EndPosition.Location = New System.Drawing.Point(504, 558)
            Me.NumericInputTrailerRecord_Filler1EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler1EndPosition.Name = "NumericInputTrailerRecord_Filler1EndPosition"
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler1EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler1EndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler1EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler1EndPosition.TabIndex = 38
            '
            'NumericInputTrailerRecord_Filler1BeginPosition
            '
            Me.NumericInputTrailerRecord_Filler1BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_Filler1BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_Filler1BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler1BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Location = New System.Drawing.Point(341, 558)
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Name = "NumericInputTrailerRecord_Filler1BeginPosition"
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_Filler1BeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_Filler1BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_Filler1BeginPosition.TabIndex = 37
            '
            'CheckBoxTrailerRecord_Filler1Export
            '
            Me.CheckBoxTrailerRecord_Filler1Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_Filler1Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_Filler1Export.CheckValue = 0
            Me.CheckBoxTrailerRecord_Filler1Export.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_Filler1Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_Filler1Export.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_Filler1Export.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler1Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler1Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_Filler1Export.Location = New System.Drawing.Point(235, 558)
            Me.CheckBoxTrailerRecord_Filler1Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_Filler1Export.Name = "CheckBoxTrailerRecord_Filler1Export"
            Me.CheckBoxTrailerRecord_Filler1Export.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_Filler1Export.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_Filler1Export.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_Filler1Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_Filler1Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_Filler1Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_Filler1Export.TabIndex = 36
            Me.CheckBoxTrailerRecord_Filler1Export.TabOnEnter = True
            '
            'NumericInputTrailerRecord_AccountNumberCSVOrder
            '
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Location = New System.Drawing.Point(667, 186)
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Name = "NumericInputTrailerRecord_AccountNumberCSVOrder"
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_AccountNumberCSVOrder.TabIndex = 13
            '
            'NumericInputTrailerRecord_AccountNumberEndPosition
            '
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Location = New System.Drawing.Point(504, 186)
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Name = "NumericInputTrailerRecord_AccountNumberEndPosition"
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_AccountNumberEndPosition.TabIndex = 12
            '
            'NumericInputTrailerRecord_AccountNumberBeginPosition
            '
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Location = New System.Drawing.Point(341, 186)
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Name = "NumericInputTrailerRecord_AccountNumberBeginPosition"
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_AccountNumberBeginPosition.TabIndex = 11
            '
            'NumericInputTrailerRecord_BankIDEndPosition
            '
            Me.NumericInputTrailerRecord_BankIDEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_BankIDEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_BankIDEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDEndPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_BankIDEndPosition.Location = New System.Drawing.Point(504, 124)
            Me.NumericInputTrailerRecord_BankIDEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_BankIDEndPosition.Name = "NumericInputTrailerRecord_BankIDEndPosition"
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_BankIDEndPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_BankIDEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_BankIDEndPosition.TabIndex = 7
            '
            'NumericInputTrailerRecord_BankIDCSVOrder
            '
            Me.NumericInputTrailerRecord_BankIDCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_BankIDCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_BankIDCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Location = New System.Drawing.Point(667, 124)
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Name = "NumericInputTrailerRecord_BankIDCSVOrder"
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_BankIDCSVOrder.SecurityEnabled = True
            Me.NumericInputTrailerRecord_BankIDCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_BankIDCSVOrder.TabIndex = 8
            '
            'NumericInputTrailerRecord_BankIDBeginPosition
            '
            Me.NumericInputTrailerRecord_BankIDBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTrailerRecord_BankIDBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTrailerRecord_BankIDBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Location = New System.Drawing.Point(341, 124)
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Name = "NumericInputTrailerRecord_BankIDBeginPosition"
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTrailerRecord_BankIDBeginPosition.SecurityEnabled = True
            Me.NumericInputTrailerRecord_BankIDBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTrailerRecord_BankIDBeginPosition.TabIndex = 6
            '
            'CheckBoxTrailerRecord_AccountNumberExport
            '
            Me.CheckBoxTrailerRecord_AccountNumberExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_AccountNumberExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_AccountNumberExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_AccountNumberExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_AccountNumberExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_AccountNumberExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_AccountNumberExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_AccountNumberExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_AccountNumberExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_AccountNumberExport.Location = New System.Drawing.Point(235, 186)
            Me.CheckBoxTrailerRecord_AccountNumberExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_AccountNumberExport.Name = "CheckBoxTrailerRecord_AccountNumberExport"
            Me.CheckBoxTrailerRecord_AccountNumberExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_AccountNumberExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_AccountNumberExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_AccountNumberExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_AccountNumberExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_AccountNumberExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_AccountNumberExport.TabIndex = 10
            Me.CheckBoxTrailerRecord_AccountNumberExport.TabOnEnter = True
            '
            'LabelTrailerRecord_Filler2
            '
            Me.LabelTrailerRecord_Filler2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_Filler2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_Filler2.Location = New System.Drawing.Point(16, 620)
            Me.LabelTrailerRecord_Filler2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_Filler2.Name = "LabelTrailerRecord_Filler2"
            Me.LabelTrailerRecord_Filler2.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_Filler2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_Filler2.TabIndex = 40
            Me.LabelTrailerRecord_Filler2.Text = "Filler 2:"
            '
            'CheckBoxTrailerRecord_BankIDExport
            '
            Me.CheckBoxTrailerRecord_BankIDExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTrailerRecord_BankIDExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTrailerRecord_BankIDExport.CheckValue = 0
            Me.CheckBoxTrailerRecord_BankIDExport.CheckValueChecked = 1
            Me.CheckBoxTrailerRecord_BankIDExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTrailerRecord_BankIDExport.CheckValueUnchecked = 0
            Me.CheckBoxTrailerRecord_BankIDExport.ChildControls = CType(resources.GetObject("CheckBoxTrailerRecord_BankIDExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_BankIDExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTrailerRecord_BankIDExport.Location = New System.Drawing.Point(235, 124)
            Me.CheckBoxTrailerRecord_BankIDExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTrailerRecord_BankIDExport.Name = "CheckBoxTrailerRecord_BankIDExport"
            Me.CheckBoxTrailerRecord_BankIDExport.OldestSibling = Nothing
            Me.CheckBoxTrailerRecord_BankIDExport.SecurityEnabled = True
            Me.CheckBoxTrailerRecord_BankIDExport.SiblingControls = CType(resources.GetObject("CheckBoxTrailerRecord_BankIDExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTrailerRecord_BankIDExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTrailerRecord_BankIDExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTrailerRecord_BankIDExport.TabIndex = 5
            Me.CheckBoxTrailerRecord_BankIDExport.TabOnEnter = True
            '
            'LabelTrailerRecord_Filler1
            '
            Me.LabelTrailerRecord_Filler1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_Filler1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_Filler1.Location = New System.Drawing.Point(16, 558)
            Me.LabelTrailerRecord_Filler1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_Filler1.Name = "LabelTrailerRecord_Filler1"
            Me.LabelTrailerRecord_Filler1.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_Filler1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_Filler1.TabIndex = 35
            Me.LabelTrailerRecord_Filler1.Text = "Filler 1:"
            '
            'LabelTrailerRecord_FillValue
            '
            Me.LabelTrailerRecord_FillValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_FillValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_FillValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTrailerRecord_FillValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTrailerRecord_FillValue.Location = New System.Drawing.Point(667, 496)
            Me.LabelTrailerRecord_FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_FillValue.Name = "LabelTrailerRecord_FillValue"
            Me.LabelTrailerRecord_FillValue.Size = New System.Drawing.Size(147, 48)
            Me.LabelTrailerRecord_FillValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_FillValue.TabIndex = 34
            Me.LabelTrailerRecord_FillValue.Text = "Fill Value"
            '
            'LabelTrailerRecord_BankID
            '
            Me.LabelTrailerRecord_BankID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_BankID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_BankID.Location = New System.Drawing.Point(16, 124)
            Me.LabelTrailerRecord_BankID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_BankID.Name = "LabelTrailerRecord_BankID"
            Me.LabelTrailerRecord_BankID.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_BankID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_BankID.TabIndex = 4
            Me.LabelTrailerRecord_BankID.Text = "Bank ID:"
            '
            'LabelTrailerRecord_CSVOrder
            '
            Me.LabelTrailerRecord_CSVOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_CSVOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_CSVOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTrailerRecord_CSVOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTrailerRecord_CSVOrder.Location = New System.Drawing.Point(667, 62)
            Me.LabelTrailerRecord_CSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_CSVOrder.Name = "LabelTrailerRecord_CSVOrder"
            Me.LabelTrailerRecord_CSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.LabelTrailerRecord_CSVOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_CSVOrder.TabIndex = 3
            Me.LabelTrailerRecord_CSVOrder.Text = "CSV Order"
            '
            'LabelTrailerRecord_EndPosition
            '
            Me.LabelTrailerRecord_EndPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTrailerRecord_EndPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_EndPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTrailerRecord_EndPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTrailerRecord_EndPosition.Location = New System.Drawing.Point(504, 62)
            Me.LabelTrailerRecord_EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_EndPosition.Name = "LabelTrailerRecord_EndPosition"
            Me.LabelTrailerRecord_EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelTrailerRecord_EndPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_EndPosition.TabIndex = 2
            Me.LabelTrailerRecord_EndPosition.Text = "End Pos"
            '
            'LabelTrailerRecord_AccountNumber
            '
            Me.LabelTrailerRecord_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTrailerRecord_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTrailerRecord_AccountNumber.Location = New System.Drawing.Point(16, 186)
            Me.LabelTrailerRecord_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTrailerRecord_AccountNumber.Name = "LabelTrailerRecord_AccountNumber"
            Me.LabelTrailerRecord_AccountNumber.Size = New System.Drawing.Size(203, 48)
            Me.LabelTrailerRecord_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTrailerRecord_AccountNumber.TabIndex = 9
            Me.LabelTrailerRecord_AccountNumber.Text = "Acct No:"
            '
            'PanelCheckExport2TableLayout_LeftColumn
            '
            Me.PanelCheckExport2TableLayout_LeftColumn.Controls.Add(Me.GroupBoxCheckExport2_TotalRecord)
            Me.PanelCheckExport2TableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelCheckExport2TableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelCheckExport2TableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelCheckExport2TableLayout_LeftColumn.Name = "PanelCheckExport2TableLayout_LeftColumn"
            Me.PanelCheckExport2TableLayout_LeftColumn.Size = New System.Drawing.Size(941, 837)
            Me.PanelCheckExport2TableLayout_LeftColumn.TabIndex = 0
            '
            'GroupBoxCheckExport2_TotalRecord
            '
            Me.GroupBoxCheckExport2_TotalRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_Export)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_BeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_RecordCountCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_RecordCountEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_RecordCountBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_TotalFlagEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_TotalFlagCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_TotalFlagBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_RecordCountExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_TotalFlagExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_TotalFlag)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_RecordCount)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_ExportAmountCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_ExportAmountEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_ExportAmountBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_FileDateEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_FileDateCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_FileDateBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_ExportAmountExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_FileDateExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_FileDate)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_ExportAmount)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.TextBoxTotalRecord_Filler4FillValue)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler4EndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler4BeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_Filler4Export)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_Filler4)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.TextBoxTotalRecord_Filler3FillValue)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler3EndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler3BeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_Filler3Export)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_Filler3)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.TextBoxTotalRecord_Filler2FillValue)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.TextBoxTotalRecord_Filler1FillValue)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler2EndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler2BeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_Filler2Export)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler1EndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_Filler1BeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_Filler1Export)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_AccountNumberCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_AccountNumberEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_AccountNumberBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_BankIDEndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_BankIDCSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.NumericInputTotalRecord_BankIDBeginPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_AccountNumberExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_Filler2)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.CheckBoxTotalRecord_BankIDExport)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_Filler1)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_FillValue)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_BankID)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_CSVOrder)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_EndPosition)
            Me.GroupBoxCheckExport2_TotalRecord.Controls.Add(Me.LabelTotalRecord_AccountNumber)
            Me.GroupBoxCheckExport2_TotalRecord.Location = New System.Drawing.Point(16, 14)
            Me.GroupBoxCheckExport2_TotalRecord.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.GroupBoxCheckExport2_TotalRecord.Name = "GroupBoxCheckExport2_TotalRecord"
            Me.GroupBoxCheckExport2_TotalRecord.Size = New System.Drawing.Size(917, 811)
            Me.GroupBoxCheckExport2_TotalRecord.TabIndex = 0
            Me.GroupBoxCheckExport2_TotalRecord.Text = "Total Record"
            '
            'LabelTotalRecord_Export
            '
            Me.LabelTotalRecord_Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_Export.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTotalRecord_Export.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTotalRecord_Export.Location = New System.Drawing.Point(235, 62)
            Me.LabelTotalRecord_Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_Export.Name = "LabelTotalRecord_Export"
            Me.LabelTotalRecord_Export.Size = New System.Drawing.Size(88, 48)
            Me.LabelTotalRecord_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_Export.TabIndex = 0
            Me.LabelTotalRecord_Export.Text = "Export"
            '
            'LabelTotalRecord_BeginPosition
            '
            Me.LabelTotalRecord_BeginPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_BeginPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_BeginPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTotalRecord_BeginPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTotalRecord_BeginPosition.Location = New System.Drawing.Point(341, 62)
            Me.LabelTotalRecord_BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_BeginPosition.Name = "LabelTotalRecord_BeginPosition"
            Me.LabelTotalRecord_BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelTotalRecord_BeginPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_BeginPosition.TabIndex = 1
            Me.LabelTotalRecord_BeginPosition.Text = "Beg Pos"
            '
            'NumericInputTotalRecord_RecordCountCSVOrder
            '
            Me.NumericInputTotalRecord_RecordCountCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_RecordCountCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_RecordCountCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Location = New System.Drawing.Point(667, 434)
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Name = "NumericInputTotalRecord_RecordCountCSVOrder"
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_RecordCountCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_RecordCountCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_RecordCountCSVOrder.TabIndex = 33
            '
            'NumericInputTotalRecord_RecordCountEndPosition
            '
            Me.NumericInputTotalRecord_RecordCountEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_RecordCountEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_RecordCountEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_RecordCountEndPosition.Location = New System.Drawing.Point(504, 434)
            Me.NumericInputTotalRecord_RecordCountEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_RecordCountEndPosition.Name = "NumericInputTotalRecord_RecordCountEndPosition"
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_RecordCountEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_RecordCountEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_RecordCountEndPosition.TabIndex = 32
            '
            'NumericInputTotalRecord_RecordCountBeginPosition
            '
            Me.NumericInputTotalRecord_RecordCountBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_RecordCountBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_RecordCountBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Location = New System.Drawing.Point(341, 434)
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Name = "NumericInputTotalRecord_RecordCountBeginPosition"
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_RecordCountBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_RecordCountBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_RecordCountBeginPosition.TabIndex = 31
            '
            'NumericInputTotalRecord_TotalFlagEndPosition
            '
            Me.NumericInputTotalRecord_TotalFlagEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_TotalFlagEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_TotalFlagEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Location = New System.Drawing.Point(504, 372)
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Name = "NumericInputTotalRecord_TotalFlagEndPosition"
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_TotalFlagEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_TotalFlagEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_TotalFlagEndPosition.TabIndex = 27
            '
            'NumericInputTotalRecord_TotalFlagCSVOrder
            '
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Location = New System.Drawing.Point(667, 372)
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Name = "NumericInputTotalRecord_TotalFlagCSVOrder"
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_TotalFlagCSVOrder.TabIndex = 28
            '
            'NumericInputTotalRecord_TotalFlagBeginPosition
            '
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Location = New System.Drawing.Point(341, 372)
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Name = "NumericInputTotalRecord_TotalFlagBeginPosition"
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_TotalFlagBeginPosition.TabIndex = 26
            '
            'CheckBoxTotalRecord_RecordCountExport
            '
            Me.CheckBoxTotalRecord_RecordCountExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_RecordCountExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_RecordCountExport.CheckValue = 0
            Me.CheckBoxTotalRecord_RecordCountExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_RecordCountExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_RecordCountExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_RecordCountExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_RecordCountExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_RecordCountExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_RecordCountExport.Location = New System.Drawing.Point(235, 434)
            Me.CheckBoxTotalRecord_RecordCountExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_RecordCountExport.Name = "CheckBoxTotalRecord_RecordCountExport"
            Me.CheckBoxTotalRecord_RecordCountExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_RecordCountExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_RecordCountExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_RecordCountExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_RecordCountExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_RecordCountExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_RecordCountExport.TabIndex = 30
            Me.CheckBoxTotalRecord_RecordCountExport.TabOnEnter = True
            '
            'CheckBoxTotalRecord_TotalFlagExport
            '
            Me.CheckBoxTotalRecord_TotalFlagExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_TotalFlagExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_TotalFlagExport.CheckValue = 0
            Me.CheckBoxTotalRecord_TotalFlagExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_TotalFlagExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_TotalFlagExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_TotalFlagExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_TotalFlagExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_TotalFlagExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_TotalFlagExport.Location = New System.Drawing.Point(235, 372)
            Me.CheckBoxTotalRecord_TotalFlagExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_TotalFlagExport.Name = "CheckBoxTotalRecord_TotalFlagExport"
            Me.CheckBoxTotalRecord_TotalFlagExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_TotalFlagExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_TotalFlagExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_TotalFlagExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_TotalFlagExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_TotalFlagExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_TotalFlagExport.TabIndex = 25
            Me.CheckBoxTotalRecord_TotalFlagExport.TabOnEnter = True
            '
            'LabelTotalRecord_TotalFlag
            '
            Me.LabelTotalRecord_TotalFlag.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_TotalFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_TotalFlag.Location = New System.Drawing.Point(16, 372)
            Me.LabelTotalRecord_TotalFlag.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_TotalFlag.Name = "LabelTotalRecord_TotalFlag"
            Me.LabelTotalRecord_TotalFlag.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_TotalFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_TotalFlag.TabIndex = 24
            Me.LabelTotalRecord_TotalFlag.Text = "Total Flag:"
            '
            'LabelTotalRecord_RecordCount
            '
            Me.LabelTotalRecord_RecordCount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_RecordCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_RecordCount.Location = New System.Drawing.Point(16, 434)
            Me.LabelTotalRecord_RecordCount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_RecordCount.Name = "LabelTotalRecord_RecordCount"
            Me.LabelTotalRecord_RecordCount.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_RecordCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_RecordCount.TabIndex = 29
            Me.LabelTotalRecord_RecordCount.Text = "Record Count:"
            '
            'NumericInputTotalRecord_ExportAmountCSVOrder
            '
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Location = New System.Drawing.Point(667, 310)
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Name = "NumericInputTotalRecord_ExportAmountCSVOrder"
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_ExportAmountCSVOrder.TabIndex = 23
            '
            'NumericInputTotalRecord_ExportAmountEndPosition
            '
            Me.NumericInputTotalRecord_ExportAmountEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_ExportAmountEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_ExportAmountEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Location = New System.Drawing.Point(504, 310)
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Name = "NumericInputTotalRecord_ExportAmountEndPosition"
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_ExportAmountEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_ExportAmountEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_ExportAmountEndPosition.TabIndex = 22
            '
            'NumericInputTotalRecord_ExportAmountBeginPosition
            '
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Location = New System.Drawing.Point(341, 310)
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Name = "NumericInputTotalRecord_ExportAmountBeginPosition"
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_ExportAmountBeginPosition.TabIndex = 21
            '
            'NumericInputTotalRecord_FileDateEndPosition
            '
            Me.NumericInputTotalRecord_FileDateEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_FileDateEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_FileDateEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_FileDateEndPosition.Location = New System.Drawing.Point(504, 248)
            Me.NumericInputTotalRecord_FileDateEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_FileDateEndPosition.Name = "NumericInputTotalRecord_FileDateEndPosition"
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_FileDateEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_FileDateEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_FileDateEndPosition.TabIndex = 17
            '
            'NumericInputTotalRecord_FileDateCSVOrder
            '
            Me.NumericInputTotalRecord_FileDateCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_FileDateCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_FileDateCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_FileDateCSVOrder.Location = New System.Drawing.Point(667, 248)
            Me.NumericInputTotalRecord_FileDateCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_FileDateCSVOrder.Name = "NumericInputTotalRecord_FileDateCSVOrder"
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_FileDateCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_FileDateCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_FileDateCSVOrder.TabIndex = 18
            '
            'NumericInputTotalRecord_FileDateBeginPosition
            '
            Me.NumericInputTotalRecord_FileDateBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_FileDateBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_FileDateBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_FileDateBeginPosition.Location = New System.Drawing.Point(341, 248)
            Me.NumericInputTotalRecord_FileDateBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_FileDateBeginPosition.Name = "NumericInputTotalRecord_FileDateBeginPosition"
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_FileDateBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_FileDateBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_FileDateBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_FileDateBeginPosition.TabIndex = 16
            '
            'CheckBoxTotalRecord_ExportAmountExport
            '
            Me.CheckBoxTotalRecord_ExportAmountExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_ExportAmountExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_ExportAmountExport.CheckValue = 0
            Me.CheckBoxTotalRecord_ExportAmountExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_ExportAmountExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_ExportAmountExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_ExportAmountExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_ExportAmountExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_ExportAmountExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_ExportAmountExport.Location = New System.Drawing.Point(235, 310)
            Me.CheckBoxTotalRecord_ExportAmountExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_ExportAmountExport.Name = "CheckBoxTotalRecord_ExportAmountExport"
            Me.CheckBoxTotalRecord_ExportAmountExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_ExportAmountExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_ExportAmountExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_ExportAmountExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_ExportAmountExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_ExportAmountExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_ExportAmountExport.TabIndex = 20
            Me.CheckBoxTotalRecord_ExportAmountExport.TabOnEnter = True
            '
            'CheckBoxTotalRecord_FileDateExport
            '
            Me.CheckBoxTotalRecord_FileDateExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_FileDateExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_FileDateExport.CheckValue = 0
            Me.CheckBoxTotalRecord_FileDateExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_FileDateExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_FileDateExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_FileDateExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_FileDateExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_FileDateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_FileDateExport.Location = New System.Drawing.Point(235, 248)
            Me.CheckBoxTotalRecord_FileDateExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_FileDateExport.Name = "CheckBoxTotalRecord_FileDateExport"
            Me.CheckBoxTotalRecord_FileDateExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_FileDateExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_FileDateExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_FileDateExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_FileDateExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_FileDateExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_FileDateExport.TabIndex = 15
            Me.CheckBoxTotalRecord_FileDateExport.TabOnEnter = True
            '
            'LabelTotalRecord_FileDate
            '
            Me.LabelTotalRecord_FileDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_FileDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_FileDate.Location = New System.Drawing.Point(16, 248)
            Me.LabelTotalRecord_FileDate.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_FileDate.Name = "LabelTotalRecord_FileDate"
            Me.LabelTotalRecord_FileDate.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_FileDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_FileDate.TabIndex = 14
            Me.LabelTotalRecord_FileDate.Text = "File Date:"
            '
            'LabelTotalRecord_ExportAmount
            '
            Me.LabelTotalRecord_ExportAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_ExportAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_ExportAmount.Location = New System.Drawing.Point(16, 310)
            Me.LabelTotalRecord_ExportAmount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_ExportAmount.Name = "LabelTotalRecord_ExportAmount"
            Me.LabelTotalRecord_ExportAmount.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_ExportAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_ExportAmount.TabIndex = 19
            Me.LabelTotalRecord_ExportAmount.Text = "Export Amt:"
            '
            'TextBoxTotalRecord_Filler4FillValue
            '
            '
            '
            '
            Me.TextBoxTotalRecord_Filler4FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTotalRecord_Filler4FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTotalRecord_Filler4FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTotalRecord_Filler4FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTotalRecord_Filler4FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTotalRecord_Filler4FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTotalRecord_Filler4FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTotalRecord_Filler4FillValue.FocusHighlightEnabled = True
            Me.TextBoxTotalRecord_Filler4FillValue.Location = New System.Drawing.Point(667, 744)
            Me.TextBoxTotalRecord_Filler4FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTotalRecord_Filler4FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTotalRecord_Filler4FillValue.Name = "TextBoxTotalRecord_Filler4FillValue"
            Me.TextBoxTotalRecord_Filler4FillValue.SecurityEnabled = True
            Me.TextBoxTotalRecord_Filler4FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTotalRecord_Filler4FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTotalRecord_Filler4FillValue.StartingFolderName = Nothing
            Me.TextBoxTotalRecord_Filler4FillValue.TabIndex = 54
            Me.TextBoxTotalRecord_Filler4FillValue.TabOnEnter = True
            '
            'NumericInputTotalRecord_Filler4EndPosition
            '
            Me.NumericInputTotalRecord_Filler4EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler4EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler4EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler4EndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler4EndPosition.Location = New System.Drawing.Point(504, 744)
            Me.NumericInputTotalRecord_Filler4EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler4EndPosition.Name = "NumericInputTotalRecord_Filler4EndPosition"
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler4EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler4EndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler4EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler4EndPosition.TabIndex = 53
            '
            'NumericInputTotalRecord_Filler4BeginPosition
            '
            Me.NumericInputTotalRecord_Filler4BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler4BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler4BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler4BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler4BeginPosition.Location = New System.Drawing.Point(341, 744)
            Me.NumericInputTotalRecord_Filler4BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler4BeginPosition.Name = "NumericInputTotalRecord_Filler4BeginPosition"
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler4BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler4BeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler4BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler4BeginPosition.TabIndex = 52
            '
            'CheckBoxTotalRecord_Filler4Export
            '
            Me.CheckBoxTotalRecord_Filler4Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_Filler4Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_Filler4Export.CheckValue = 0
            Me.CheckBoxTotalRecord_Filler4Export.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_Filler4Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_Filler4Export.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_Filler4Export.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler4Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler4Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_Filler4Export.Location = New System.Drawing.Point(235, 744)
            Me.CheckBoxTotalRecord_Filler4Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_Filler4Export.Name = "CheckBoxTotalRecord_Filler4Export"
            Me.CheckBoxTotalRecord_Filler4Export.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_Filler4Export.SecurityEnabled = True
            Me.CheckBoxTotalRecord_Filler4Export.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler4Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler4Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_Filler4Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_Filler4Export.TabIndex = 51
            Me.CheckBoxTotalRecord_Filler4Export.TabOnEnter = True
            '
            'LabelTotalRecord_Filler4
            '
            Me.LabelTotalRecord_Filler4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_Filler4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_Filler4.Location = New System.Drawing.Point(16, 744)
            Me.LabelTotalRecord_Filler4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_Filler4.Name = "LabelTotalRecord_Filler4"
            Me.LabelTotalRecord_Filler4.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_Filler4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_Filler4.TabIndex = 50
            Me.LabelTotalRecord_Filler4.Text = "Filler 4:"
            '
            'TextBoxTotalRecord_Filler3FillValue
            '
            '
            '
            '
            Me.TextBoxTotalRecord_Filler3FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTotalRecord_Filler3FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTotalRecord_Filler3FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTotalRecord_Filler3FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTotalRecord_Filler3FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTotalRecord_Filler3FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTotalRecord_Filler3FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTotalRecord_Filler3FillValue.FocusHighlightEnabled = True
            Me.TextBoxTotalRecord_Filler3FillValue.Location = New System.Drawing.Point(667, 682)
            Me.TextBoxTotalRecord_Filler3FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTotalRecord_Filler3FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTotalRecord_Filler3FillValue.Name = "TextBoxTotalRecord_Filler3FillValue"
            Me.TextBoxTotalRecord_Filler3FillValue.SecurityEnabled = True
            Me.TextBoxTotalRecord_Filler3FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTotalRecord_Filler3FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTotalRecord_Filler3FillValue.StartingFolderName = Nothing
            Me.TextBoxTotalRecord_Filler3FillValue.TabIndex = 49
            Me.TextBoxTotalRecord_Filler3FillValue.TabOnEnter = True
            '
            'NumericInputTotalRecord_Filler3EndPosition
            '
            Me.NumericInputTotalRecord_Filler3EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler3EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler3EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler3EndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler3EndPosition.Location = New System.Drawing.Point(504, 682)
            Me.NumericInputTotalRecord_Filler3EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler3EndPosition.Name = "NumericInputTotalRecord_Filler3EndPosition"
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler3EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler3EndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler3EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler3EndPosition.TabIndex = 48
            '
            'NumericInputTotalRecord_Filler3BeginPosition
            '
            Me.NumericInputTotalRecord_Filler3BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler3BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler3BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler3BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler3BeginPosition.Location = New System.Drawing.Point(341, 682)
            Me.NumericInputTotalRecord_Filler3BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler3BeginPosition.Name = "NumericInputTotalRecord_Filler3BeginPosition"
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler3BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler3BeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler3BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler3BeginPosition.TabIndex = 47
            '
            'CheckBoxTotalRecord_Filler3Export
            '
            Me.CheckBoxTotalRecord_Filler3Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_Filler3Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_Filler3Export.CheckValue = 0
            Me.CheckBoxTotalRecord_Filler3Export.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_Filler3Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_Filler3Export.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_Filler3Export.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler3Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler3Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_Filler3Export.Location = New System.Drawing.Point(235, 682)
            Me.CheckBoxTotalRecord_Filler3Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_Filler3Export.Name = "CheckBoxTotalRecord_Filler3Export"
            Me.CheckBoxTotalRecord_Filler3Export.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_Filler3Export.SecurityEnabled = True
            Me.CheckBoxTotalRecord_Filler3Export.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler3Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler3Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_Filler3Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_Filler3Export.TabIndex = 46
            Me.CheckBoxTotalRecord_Filler3Export.TabOnEnter = True
            '
            'LabelTotalRecord_Filler3
            '
            Me.LabelTotalRecord_Filler3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_Filler3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_Filler3.Location = New System.Drawing.Point(16, 682)
            Me.LabelTotalRecord_Filler3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_Filler3.Name = "LabelTotalRecord_Filler3"
            Me.LabelTotalRecord_Filler3.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_Filler3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_Filler3.TabIndex = 45
            Me.LabelTotalRecord_Filler3.Text = "Filler 3:"
            '
            'TextBoxTotalRecord_Filler2FillValue
            '
            '
            '
            '
            Me.TextBoxTotalRecord_Filler2FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTotalRecord_Filler2FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTotalRecord_Filler2FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTotalRecord_Filler2FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTotalRecord_Filler2FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTotalRecord_Filler2FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTotalRecord_Filler2FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTotalRecord_Filler2FillValue.FocusHighlightEnabled = True
            Me.TextBoxTotalRecord_Filler2FillValue.Location = New System.Drawing.Point(667, 620)
            Me.TextBoxTotalRecord_Filler2FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTotalRecord_Filler2FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTotalRecord_Filler2FillValue.Name = "TextBoxTotalRecord_Filler2FillValue"
            Me.TextBoxTotalRecord_Filler2FillValue.SecurityEnabled = True
            Me.TextBoxTotalRecord_Filler2FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTotalRecord_Filler2FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTotalRecord_Filler2FillValue.StartingFolderName = Nothing
            Me.TextBoxTotalRecord_Filler2FillValue.TabIndex = 44
            Me.TextBoxTotalRecord_Filler2FillValue.TabOnEnter = True
            '
            'TextBoxTotalRecord_Filler1FillValue
            '
            '
            '
            '
            Me.TextBoxTotalRecord_Filler1FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxTotalRecord_Filler1FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTotalRecord_Filler1FillValue.CheckSpellingOnValidate = False
            Me.TextBoxTotalRecord_Filler1FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTotalRecord_Filler1FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxTotalRecord_Filler1FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTotalRecord_Filler1FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTotalRecord_Filler1FillValue.FocusHighlightEnabled = True
            Me.TextBoxTotalRecord_Filler1FillValue.Location = New System.Drawing.Point(667, 558)
            Me.TextBoxTotalRecord_Filler1FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxTotalRecord_Filler1FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxTotalRecord_Filler1FillValue.Name = "TextBoxTotalRecord_Filler1FillValue"
            Me.TextBoxTotalRecord_Filler1FillValue.SecurityEnabled = True
            Me.TextBoxTotalRecord_Filler1FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTotalRecord_Filler1FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxTotalRecord_Filler1FillValue.StartingFolderName = Nothing
            Me.TextBoxTotalRecord_Filler1FillValue.TabIndex = 39
            Me.TextBoxTotalRecord_Filler1FillValue.TabOnEnter = True
            '
            'NumericInputTotalRecord_Filler2EndPosition
            '
            Me.NumericInputTotalRecord_Filler2EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler2EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler2EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler2EndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler2EndPosition.Location = New System.Drawing.Point(504, 620)
            Me.NumericInputTotalRecord_Filler2EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler2EndPosition.Name = "NumericInputTotalRecord_Filler2EndPosition"
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler2EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler2EndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler2EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler2EndPosition.TabIndex = 43
            '
            'NumericInputTotalRecord_Filler2BeginPosition
            '
            Me.NumericInputTotalRecord_Filler2BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler2BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler2BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler2BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler2BeginPosition.Location = New System.Drawing.Point(341, 620)
            Me.NumericInputTotalRecord_Filler2BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler2BeginPosition.Name = "NumericInputTotalRecord_Filler2BeginPosition"
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler2BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler2BeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler2BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler2BeginPosition.TabIndex = 42
            '
            'CheckBoxTotalRecord_Filler2Export
            '
            Me.CheckBoxTotalRecord_Filler2Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_Filler2Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_Filler2Export.CheckValue = 0
            Me.CheckBoxTotalRecord_Filler2Export.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_Filler2Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_Filler2Export.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_Filler2Export.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler2Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler2Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_Filler2Export.Location = New System.Drawing.Point(235, 620)
            Me.CheckBoxTotalRecord_Filler2Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_Filler2Export.Name = "CheckBoxTotalRecord_Filler2Export"
            Me.CheckBoxTotalRecord_Filler2Export.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_Filler2Export.SecurityEnabled = True
            Me.CheckBoxTotalRecord_Filler2Export.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler2Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler2Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_Filler2Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_Filler2Export.TabIndex = 41
            Me.CheckBoxTotalRecord_Filler2Export.TabOnEnter = True
            '
            'NumericInputTotalRecord_Filler1EndPosition
            '
            Me.NumericInputTotalRecord_Filler1EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler1EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler1EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler1EndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler1EndPosition.Location = New System.Drawing.Point(504, 558)
            Me.NumericInputTotalRecord_Filler1EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler1EndPosition.Name = "NumericInputTotalRecord_Filler1EndPosition"
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler1EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler1EndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler1EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler1EndPosition.TabIndex = 38
            '
            'NumericInputTotalRecord_Filler1BeginPosition
            '
            Me.NumericInputTotalRecord_Filler1BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_Filler1BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_Filler1BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler1BeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_Filler1BeginPosition.Location = New System.Drawing.Point(341, 558)
            Me.NumericInputTotalRecord_Filler1BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_Filler1BeginPosition.Name = "NumericInputTotalRecord_Filler1BeginPosition"
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_Filler1BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_Filler1BeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_Filler1BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_Filler1BeginPosition.TabIndex = 37
            '
            'CheckBoxTotalRecord_Filler1Export
            '
            Me.CheckBoxTotalRecord_Filler1Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_Filler1Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_Filler1Export.CheckValue = 0
            Me.CheckBoxTotalRecord_Filler1Export.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_Filler1Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_Filler1Export.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_Filler1Export.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler1Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler1Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_Filler1Export.Location = New System.Drawing.Point(235, 558)
            Me.CheckBoxTotalRecord_Filler1Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_Filler1Export.Name = "CheckBoxTotalRecord_Filler1Export"
            Me.CheckBoxTotalRecord_Filler1Export.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_Filler1Export.SecurityEnabled = True
            Me.CheckBoxTotalRecord_Filler1Export.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_Filler1Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_Filler1Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_Filler1Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_Filler1Export.TabIndex = 36
            Me.CheckBoxTotalRecord_Filler1Export.TabOnEnter = True
            '
            'NumericInputTotalRecord_AccountNumberCSVOrder
            '
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Location = New System.Drawing.Point(667, 186)
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Name = "NumericInputTotalRecord_AccountNumberCSVOrder"
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_AccountNumberCSVOrder.TabIndex = 13
            '
            'NumericInputTotalRecord_AccountNumberEndPosition
            '
            Me.NumericInputTotalRecord_AccountNumberEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_AccountNumberEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_AccountNumberEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Location = New System.Drawing.Point(504, 186)
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Name = "NumericInputTotalRecord_AccountNumberEndPosition"
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_AccountNumberEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_AccountNumberEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_AccountNumberEndPosition.TabIndex = 12
            '
            'NumericInputTotalRecord_AccountNumberBeginPosition
            '
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Location = New System.Drawing.Point(341, 186)
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Name = "NumericInputTotalRecord_AccountNumberBeginPosition"
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_AccountNumberBeginPosition.TabIndex = 11
            '
            'NumericInputTotalRecord_BankIDEndPosition
            '
            Me.NumericInputTotalRecord_BankIDEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_BankIDEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_BankIDEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDEndPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_BankIDEndPosition.Location = New System.Drawing.Point(504, 124)
            Me.NumericInputTotalRecord_BankIDEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_BankIDEndPosition.Name = "NumericInputTotalRecord_BankIDEndPosition"
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_BankIDEndPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_BankIDEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_BankIDEndPosition.TabIndex = 7
            '
            'NumericInputTotalRecord_BankIDCSVOrder
            '
            Me.NumericInputTotalRecord_BankIDCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_BankIDCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_BankIDCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDCSVOrder.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_BankIDCSVOrder.Location = New System.Drawing.Point(667, 124)
            Me.NumericInputTotalRecord_BankIDCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_BankIDCSVOrder.Name = "NumericInputTotalRecord_BankIDCSVOrder"
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_BankIDCSVOrder.SecurityEnabled = True
            Me.NumericInputTotalRecord_BankIDCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_BankIDCSVOrder.TabIndex = 8
            '
            'NumericInputTotalRecord_BankIDBeginPosition
            '
            Me.NumericInputTotalRecord_BankIDBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputTotalRecord_BankIDBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputTotalRecord_BankIDBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDBeginPosition.EnterMoveNextControl = True
            Me.NumericInputTotalRecord_BankIDBeginPosition.Location = New System.Drawing.Point(341, 124)
            Me.NumericInputTotalRecord_BankIDBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputTotalRecord_BankIDBeginPosition.Name = "NumericInputTotalRecord_BankIDBeginPosition"
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputTotalRecord_BankIDBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputTotalRecord_BankIDBeginPosition.SecurityEnabled = True
            Me.NumericInputTotalRecord_BankIDBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputTotalRecord_BankIDBeginPosition.TabIndex = 6
            '
            'CheckBoxTotalRecord_AccountNumberExport
            '
            Me.CheckBoxTotalRecord_AccountNumberExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_AccountNumberExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_AccountNumberExport.CheckValue = 0
            Me.CheckBoxTotalRecord_AccountNumberExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_AccountNumberExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_AccountNumberExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_AccountNumberExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_AccountNumberExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_AccountNumberExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_AccountNumberExport.Location = New System.Drawing.Point(235, 186)
            Me.CheckBoxTotalRecord_AccountNumberExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_AccountNumberExport.Name = "CheckBoxTotalRecord_AccountNumberExport"
            Me.CheckBoxTotalRecord_AccountNumberExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_AccountNumberExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_AccountNumberExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_AccountNumberExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_AccountNumberExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_AccountNumberExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_AccountNumberExport.TabIndex = 10
            Me.CheckBoxTotalRecord_AccountNumberExport.TabOnEnter = True
            '
            'LabelTotalRecord_Filler2
            '
            Me.LabelTotalRecord_Filler2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_Filler2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_Filler2.Location = New System.Drawing.Point(16, 620)
            Me.LabelTotalRecord_Filler2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_Filler2.Name = "LabelTotalRecord_Filler2"
            Me.LabelTotalRecord_Filler2.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_Filler2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_Filler2.TabIndex = 40
            Me.LabelTotalRecord_Filler2.Text = "Filler 2:"
            '
            'CheckBoxTotalRecord_BankIDExport
            '
            Me.CheckBoxTotalRecord_BankIDExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxTotalRecord_BankIDExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxTotalRecord_BankIDExport.CheckValue = 0
            Me.CheckBoxTotalRecord_BankIDExport.CheckValueChecked = 1
            Me.CheckBoxTotalRecord_BankIDExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxTotalRecord_BankIDExport.CheckValueUnchecked = 0
            Me.CheckBoxTotalRecord_BankIDExport.ChildControls = CType(resources.GetObject("CheckBoxTotalRecord_BankIDExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_BankIDExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxTotalRecord_BankIDExport.Location = New System.Drawing.Point(235, 124)
            Me.CheckBoxTotalRecord_BankIDExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxTotalRecord_BankIDExport.Name = "CheckBoxTotalRecord_BankIDExport"
            Me.CheckBoxTotalRecord_BankIDExport.OldestSibling = Nothing
            Me.CheckBoxTotalRecord_BankIDExport.SecurityEnabled = True
            Me.CheckBoxTotalRecord_BankIDExport.SiblingControls = CType(resources.GetObject("CheckBoxTotalRecord_BankIDExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxTotalRecord_BankIDExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxTotalRecord_BankIDExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxTotalRecord_BankIDExport.TabIndex = 5
            Me.CheckBoxTotalRecord_BankIDExport.TabOnEnter = True
            '
            'LabelTotalRecord_Filler1
            '
            Me.LabelTotalRecord_Filler1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_Filler1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_Filler1.Location = New System.Drawing.Point(16, 558)
            Me.LabelTotalRecord_Filler1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_Filler1.Name = "LabelTotalRecord_Filler1"
            Me.LabelTotalRecord_Filler1.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_Filler1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_Filler1.TabIndex = 35
            Me.LabelTotalRecord_Filler1.Text = "Filler 1:"
            '
            'LabelTotalRecord_FillValue
            '
            Me.LabelTotalRecord_FillValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_FillValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_FillValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_FillValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTotalRecord_FillValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTotalRecord_FillValue.Location = New System.Drawing.Point(667, 496)
            Me.LabelTotalRecord_FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_FillValue.Name = "LabelTotalRecord_FillValue"
            Me.LabelTotalRecord_FillValue.Size = New System.Drawing.Size(147, 48)
            Me.LabelTotalRecord_FillValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_FillValue.TabIndex = 34
            Me.LabelTotalRecord_FillValue.Text = "Fill Value"
            '
            'LabelTotalRecord_BankID
            '
            Me.LabelTotalRecord_BankID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_BankID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_BankID.Location = New System.Drawing.Point(16, 124)
            Me.LabelTotalRecord_BankID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_BankID.Name = "LabelTotalRecord_BankID"
            Me.LabelTotalRecord_BankID.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_BankID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_BankID.TabIndex = 4
            Me.LabelTotalRecord_BankID.Text = "Bank ID:"
            '
            'LabelTotalRecord_CSVOrder
            '
            Me.LabelTotalRecord_CSVOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_CSVOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_CSVOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTotalRecord_CSVOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTotalRecord_CSVOrder.Location = New System.Drawing.Point(667, 62)
            Me.LabelTotalRecord_CSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_CSVOrder.Name = "LabelTotalRecord_CSVOrder"
            Me.LabelTotalRecord_CSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.LabelTotalRecord_CSVOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_CSVOrder.TabIndex = 3
            Me.LabelTotalRecord_CSVOrder.Text = "CSV Order"
            '
            'LabelTotalRecord_EndPosition
            '
            Me.LabelTotalRecord_EndPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelTotalRecord_EndPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_EndPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelTotalRecord_EndPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelTotalRecord_EndPosition.Location = New System.Drawing.Point(504, 62)
            Me.LabelTotalRecord_EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_EndPosition.Name = "LabelTotalRecord_EndPosition"
            Me.LabelTotalRecord_EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelTotalRecord_EndPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_EndPosition.TabIndex = 2
            Me.LabelTotalRecord_EndPosition.Text = "End Pos"
            '
            'LabelTotalRecord_AccountNumber
            '
            Me.LabelTotalRecord_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTotalRecord_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTotalRecord_AccountNumber.Location = New System.Drawing.Point(16, 186)
            Me.LabelTotalRecord_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelTotalRecord_AccountNumber.Name = "LabelTotalRecord_AccountNumber"
            Me.LabelTotalRecord_AccountNumber.Size = New System.Drawing.Size(203, 48)
            Me.LabelTotalRecord_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTotalRecord_AccountNumber.TabIndex = 9
            Me.LabelTotalRecord_AccountNumber.Text = "Acct No:"
            '
            'TabItemBankDetails_CheckExport2
            '
            Me.TabItemBankDetails_CheckExport2.AttachedControl = Me.TabControlPanelCheckExport2_CheckExport2
            Me.TabItemBankDetails_CheckExport2.Name = "TabItemBankDetails_CheckExport2"
            Me.TabItemBankDetails_CheckExport2.Text = "Check Export 2"
            '
            'TabControlPanelCheckExport_CheckExport
            '
            Me.TabControlPanelCheckExport_CheckExport.Controls.Add(Me.TableLayoutPanelCheckExport_CheckExportTableLayout)
            Me.TabControlPanelCheckExport_CheckExport.Controls.Add(Me.CheckBoxCheckExport_UseHeaderRecord)
            Me.TabControlPanelCheckExport_CheckExport.Controls.Add(Me.RadioButtonControlCheckExport_CSV)
            Me.TabControlPanelCheckExport_CheckExport.Controls.Add(Me.RadioButtonControlCheckExport_Fixed)
            Me.TabControlPanelCheckExport_CheckExport.Controls.Add(Me.LabelCheckExport_ExportFormat)
            Me.TabControlPanelCheckExport_CheckExport.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCheckExport_CheckExport.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCheckExport_CheckExport.Location = New System.Drawing.Point(0, 56)
            Me.TabControlPanelCheckExport_CheckExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelCheckExport_CheckExport.Name = "TabControlPanelCheckExport_CheckExport"
            Me.TabControlPanelCheckExport_CheckExport.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelCheckExport_CheckExport.Size = New System.Drawing.Size(1883, 1508)
            Me.TabControlPanelCheckExport_CheckExport.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCheckExport_CheckExport.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCheckExport_CheckExport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCheckExport_CheckExport.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCheckExport_CheckExport.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCheckExport_CheckExport.Style.GradientAngle = 90
            Me.TabControlPanelCheckExport_CheckExport.TabIndex = 6
            Me.TabControlPanelCheckExport_CheckExport.TabItem = Me.TabItemBankDetails_CheckExport
            '
            'TableLayoutPanelCheckExport_CheckExportTableLayout
            '
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.ColumnCount = 2
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Controls.Add(Me.PanelCheckExportTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Controls.Add(Me.PanelCheckExportTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Location = New System.Drawing.Point(0, 138)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Name = "TableLayoutPanelCheckExport_CheckExportTableLayout"
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.RowCount = 1
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.Size = New System.Drawing.Size(1883, 875)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.TabIndex = 4
            '
            'PanelCheckExportTableLayout_RightColumn
            '
            Me.PanelCheckExportTableLayout_RightColumn.Controls.Add(Me.GroupBoxCheckExport_DetailRecord)
            Me.PanelCheckExportTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelCheckExportTableLayout_RightColumn.Location = New System.Drawing.Point(941, 0)
            Me.PanelCheckExportTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelCheckExportTableLayout_RightColumn.Name = "PanelCheckExportTableLayout_RightColumn"
            Me.PanelCheckExportTableLayout_RightColumn.Size = New System.Drawing.Size(942, 875)
            Me.PanelCheckExportTableLayout_RightColumn.TabIndex = 1
            '
            'GroupBoxCheckExport_DetailRecord
            '
            Me.GroupBoxCheckExport_DetailRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Export)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_BeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_PayeeCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_PayeeEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_PayeeBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_PayeeExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Payee)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_VoidFlagCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_VoidFlagEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_VoidFlagBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckAmountEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckAmountCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckAmountBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_VoidFlagExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_CheckAmountExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_CheckAmount)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_VoidFlag)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckDateCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckDateEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckDateBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckNumberEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckNumberCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_CheckNumberBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_CheckDateExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_CheckNumberExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_CheckNumber)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_CheckDate)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.TextBoxDetailRecord_Filler4FillValue)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler4EndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler4BeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_Filler4Export)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Filler4)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.TextBoxDetailRecord_Filler3FillValue)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler3EndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler3BeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_Filler3Export)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Filler3)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.TextBoxDetailRecord_Filler2FillValue)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.TextBoxDetailRecord_Filler1FillValue)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler2EndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler2BeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_Filler2Export)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler1EndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_Filler1BeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_Filler1Export)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_AccountNumberCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_AccountNumberEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_AccountNumberBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_BankIDEndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_BankIDCSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.NumericInputDetailRecord_BankIDBeginPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_AccountNumberExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Filler2)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.CheckBoxDetailRecord_BankIDExport)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_Filler1)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_FillValue)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_BankID)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_CSVOrder)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_EndPosition)
            Me.GroupBoxCheckExport_DetailRecord.Controls.Add(Me.LabelDetailRecord_AccountNumber)
            Me.GroupBoxCheckExport_DetailRecord.Location = New System.Drawing.Point(8, 0)
            Me.GroupBoxCheckExport_DetailRecord.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.GroupBoxCheckExport_DetailRecord.Name = "GroupBoxCheckExport_DetailRecord"
            Me.GroupBoxCheckExport_DetailRecord.Size = New System.Drawing.Size(918, 870)
            Me.GroupBoxCheckExport_DetailRecord.TabIndex = 0
            Me.GroupBoxCheckExport_DetailRecord.Text = "Detail Record"
            '
            'LabelDetailRecord_Export
            '
            Me.LabelDetailRecord_Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_Export.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetailRecord_Export.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDetailRecord_Export.Location = New System.Drawing.Point(235, 62)
            Me.LabelDetailRecord_Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Export.Name = "LabelDetailRecord_Export"
            Me.LabelDetailRecord_Export.Size = New System.Drawing.Size(88, 48)
            Me.LabelDetailRecord_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Export.TabIndex = 1
            Me.LabelDetailRecord_Export.Text = "Export"
            '
            'LabelDetailRecord_BeginPosition
            '
            Me.LabelDetailRecord_BeginPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_BeginPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_BeginPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetailRecord_BeginPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDetailRecord_BeginPosition.Location = New System.Drawing.Point(339, 62)
            Me.LabelDetailRecord_BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_BeginPosition.Name = "LabelDetailRecord_BeginPosition"
            Me.LabelDetailRecord_BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelDetailRecord_BeginPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_BeginPosition.TabIndex = 2
            Me.LabelDetailRecord_BeginPosition.Text = "Beg Pos"
            '
            'NumericInputDetailRecord_PayeeCSVOrder
            '
            Me.NumericInputDetailRecord_PayeeCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_PayeeCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_PayeeCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_PayeeCSVOrder.Location = New System.Drawing.Point(664, 496)
            Me.NumericInputDetailRecord_PayeeCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_PayeeCSVOrder.Name = "NumericInputDetailRecord_PayeeCSVOrder"
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_PayeeCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_PayeeCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_PayeeCSVOrder.TabIndex = 39
            '
            'NumericInputDetailRecord_PayeeEndPosition
            '
            Me.NumericInputDetailRecord_PayeeEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_PayeeEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_PayeeEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_PayeeEndPosition.Location = New System.Drawing.Point(501, 496)
            Me.NumericInputDetailRecord_PayeeEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_PayeeEndPosition.Name = "NumericInputDetailRecord_PayeeEndPosition"
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_PayeeEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_PayeeEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_PayeeEndPosition.TabIndex = 38
            '
            'NumericInputDetailRecord_PayeeBeginPosition
            '
            Me.NumericInputDetailRecord_PayeeBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_PayeeBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_PayeeBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_PayeeBeginPosition.Location = New System.Drawing.Point(339, 496)
            Me.NumericInputDetailRecord_PayeeBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_PayeeBeginPosition.Name = "NumericInputDetailRecord_PayeeBeginPosition"
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_PayeeBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_PayeeBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_PayeeBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_PayeeBeginPosition.TabIndex = 37
            '
            'CheckBoxDetailRecord_PayeeExport
            '
            Me.CheckBoxDetailRecord_PayeeExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_PayeeExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_PayeeExport.CheckValue = 0
            Me.CheckBoxDetailRecord_PayeeExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_PayeeExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_PayeeExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_PayeeExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_PayeeExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_PayeeExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_PayeeExport.Location = New System.Drawing.Point(235, 496)
            Me.CheckBoxDetailRecord_PayeeExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_PayeeExport.Name = "CheckBoxDetailRecord_PayeeExport"
            Me.CheckBoxDetailRecord_PayeeExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_PayeeExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_PayeeExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_PayeeExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_PayeeExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_PayeeExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_PayeeExport.TabIndex = 36
            Me.CheckBoxDetailRecord_PayeeExport.TabOnEnter = True
            '
            'LabelDetailRecord_Payee
            '
            Me.LabelDetailRecord_Payee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Payee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Payee.Location = New System.Drawing.Point(16, 496)
            Me.LabelDetailRecord_Payee.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Payee.Name = "LabelDetailRecord_Payee"
            Me.LabelDetailRecord_Payee.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_Payee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Payee.TabIndex = 35
            Me.LabelDetailRecord_Payee.Text = "Payee:"
            '
            'NumericInputDetailRecord_VoidFlagCSVOrder
            '
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Location = New System.Drawing.Point(664, 434)
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Name = "NumericInputDetailRecord_VoidFlagCSVOrder"
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_VoidFlagCSVOrder.TabIndex = 34
            '
            'NumericInputDetailRecord_VoidFlagEndPosition
            '
            Me.NumericInputDetailRecord_VoidFlagEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_VoidFlagEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_VoidFlagEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Location = New System.Drawing.Point(501, 434)
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Name = "NumericInputDetailRecord_VoidFlagEndPosition"
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_VoidFlagEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_VoidFlagEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_VoidFlagEndPosition.TabIndex = 33
            '
            'NumericInputDetailRecord_VoidFlagBeginPosition
            '
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Location = New System.Drawing.Point(339, 434)
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Name = "NumericInputDetailRecord_VoidFlagBeginPosition"
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_VoidFlagBeginPosition.TabIndex = 32
            '
            'NumericInputDetailRecord_CheckAmountEndPosition
            '
            Me.NumericInputDetailRecord_CheckAmountEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckAmountEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckAmountEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Location = New System.Drawing.Point(501, 372)
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Name = "NumericInputDetailRecord_CheckAmountEndPosition"
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckAmountEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckAmountEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckAmountEndPosition.TabIndex = 28
            '
            'NumericInputDetailRecord_CheckAmountCSVOrder
            '
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Location = New System.Drawing.Point(664, 372)
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Name = "NumericInputDetailRecord_CheckAmountCSVOrder"
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckAmountCSVOrder.TabIndex = 29
            '
            'NumericInputDetailRecord_CheckAmountBeginPosition
            '
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Location = New System.Drawing.Point(339, 372)
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Name = "NumericInputDetailRecord_CheckAmountBeginPosition"
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckAmountBeginPosition.TabIndex = 27
            '
            'CheckBoxDetailRecord_VoidFlagExport
            '
            Me.CheckBoxDetailRecord_VoidFlagExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_VoidFlagExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_VoidFlagExport.CheckValue = 0
            Me.CheckBoxDetailRecord_VoidFlagExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_VoidFlagExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_VoidFlagExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_VoidFlagExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_VoidFlagExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_VoidFlagExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_VoidFlagExport.Location = New System.Drawing.Point(235, 434)
            Me.CheckBoxDetailRecord_VoidFlagExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_VoidFlagExport.Name = "CheckBoxDetailRecord_VoidFlagExport"
            Me.CheckBoxDetailRecord_VoidFlagExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_VoidFlagExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_VoidFlagExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_VoidFlagExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_VoidFlagExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_VoidFlagExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_VoidFlagExport.TabIndex = 31
            Me.CheckBoxDetailRecord_VoidFlagExport.TabOnEnter = True
            '
            'CheckBoxDetailRecord_CheckAmountExport
            '
            Me.CheckBoxDetailRecord_CheckAmountExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_CheckAmountExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_CheckAmountExport.CheckValue = 0
            Me.CheckBoxDetailRecord_CheckAmountExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_CheckAmountExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_CheckAmountExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_CheckAmountExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckAmountExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckAmountExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_CheckAmountExport.Location = New System.Drawing.Point(235, 372)
            Me.CheckBoxDetailRecord_CheckAmountExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_CheckAmountExport.Name = "CheckBoxDetailRecord_CheckAmountExport"
            Me.CheckBoxDetailRecord_CheckAmountExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_CheckAmountExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_CheckAmountExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckAmountExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckAmountExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_CheckAmountExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_CheckAmountExport.TabIndex = 26
            Me.CheckBoxDetailRecord_CheckAmountExport.TabOnEnter = True
            '
            'LabelDetailRecord_CheckAmount
            '
            Me.LabelDetailRecord_CheckAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_CheckAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_CheckAmount.Location = New System.Drawing.Point(16, 372)
            Me.LabelDetailRecord_CheckAmount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_CheckAmount.Name = "LabelDetailRecord_CheckAmount"
            Me.LabelDetailRecord_CheckAmount.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_CheckAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_CheckAmount.TabIndex = 25
            Me.LabelDetailRecord_CheckAmount.Text = "Check Amt:"
            '
            'LabelDetailRecord_VoidFlag
            '
            Me.LabelDetailRecord_VoidFlag.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_VoidFlag.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_VoidFlag.Location = New System.Drawing.Point(16, 434)
            Me.LabelDetailRecord_VoidFlag.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_VoidFlag.Name = "LabelDetailRecord_VoidFlag"
            Me.LabelDetailRecord_VoidFlag.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_VoidFlag.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_VoidFlag.TabIndex = 30
            Me.LabelDetailRecord_VoidFlag.Text = "Void Flag:"
            '
            'NumericInputDetailRecord_CheckDateCSVOrder
            '
            Me.NumericInputDetailRecord_CheckDateCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckDateCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckDateCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Location = New System.Drawing.Point(664, 310)
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Name = "NumericInputDetailRecord_CheckDateCSVOrder"
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckDateCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckDateCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckDateCSVOrder.TabIndex = 24
            '
            'NumericInputDetailRecord_CheckDateEndPosition
            '
            Me.NumericInputDetailRecord_CheckDateEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckDateEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckDateEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckDateEndPosition.Location = New System.Drawing.Point(501, 310)
            Me.NumericInputDetailRecord_CheckDateEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckDateEndPosition.Name = "NumericInputDetailRecord_CheckDateEndPosition"
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckDateEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckDateEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckDateEndPosition.TabIndex = 23
            '
            'NumericInputDetailRecord_CheckDateBeginPosition
            '
            Me.NumericInputDetailRecord_CheckDateBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckDateBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckDateBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Location = New System.Drawing.Point(339, 310)
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Name = "NumericInputDetailRecord_CheckDateBeginPosition"
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckDateBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckDateBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckDateBeginPosition.TabIndex = 22
            '
            'NumericInputDetailRecord_CheckNumberEndPosition
            '
            Me.NumericInputDetailRecord_CheckNumberEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckNumberEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckNumberEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Location = New System.Drawing.Point(501, 248)
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Name = "NumericInputDetailRecord_CheckNumberEndPosition"
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckNumberEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckNumberEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckNumberEndPosition.TabIndex = 18
            '
            'NumericInputDetailRecord_CheckNumberCSVOrder
            '
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Location = New System.Drawing.Point(664, 248)
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Name = "NumericInputDetailRecord_CheckNumberCSVOrder"
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckNumberCSVOrder.TabIndex = 19
            '
            'NumericInputDetailRecord_CheckNumberBeginPosition
            '
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Location = New System.Drawing.Point(339, 248)
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Name = "NumericInputDetailRecord_CheckNumberBeginPosition"
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_CheckNumberBeginPosition.TabIndex = 17
            '
            'CheckBoxDetailRecord_CheckDateExport
            '
            Me.CheckBoxDetailRecord_CheckDateExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_CheckDateExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_CheckDateExport.CheckValue = 0
            Me.CheckBoxDetailRecord_CheckDateExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_CheckDateExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_CheckDateExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_CheckDateExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckDateExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckDateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_CheckDateExport.Location = New System.Drawing.Point(235, 310)
            Me.CheckBoxDetailRecord_CheckDateExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_CheckDateExport.Name = "CheckBoxDetailRecord_CheckDateExport"
            Me.CheckBoxDetailRecord_CheckDateExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_CheckDateExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_CheckDateExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckDateExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckDateExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_CheckDateExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_CheckDateExport.TabIndex = 21
            Me.CheckBoxDetailRecord_CheckDateExport.TabOnEnter = True
            '
            'CheckBoxDetailRecord_CheckNumberExport
            '
            Me.CheckBoxDetailRecord_CheckNumberExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_CheckNumberExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_CheckNumberExport.CheckValue = 0
            Me.CheckBoxDetailRecord_CheckNumberExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_CheckNumberExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_CheckNumberExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_CheckNumberExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckNumberExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckNumberExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_CheckNumberExport.Location = New System.Drawing.Point(235, 248)
            Me.CheckBoxDetailRecord_CheckNumberExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_CheckNumberExport.Name = "CheckBoxDetailRecord_CheckNumberExport"
            Me.CheckBoxDetailRecord_CheckNumberExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_CheckNumberExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_CheckNumberExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_CheckNumberExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_CheckNumberExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_CheckNumberExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_CheckNumberExport.TabIndex = 16
            Me.CheckBoxDetailRecord_CheckNumberExport.TabOnEnter = True
            '
            'LabelDetailRecord_CheckNumber
            '
            Me.LabelDetailRecord_CheckNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_CheckNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_CheckNumber.Location = New System.Drawing.Point(16, 248)
            Me.LabelDetailRecord_CheckNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_CheckNumber.Name = "LabelDetailRecord_CheckNumber"
            Me.LabelDetailRecord_CheckNumber.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_CheckNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_CheckNumber.TabIndex = 15
            Me.LabelDetailRecord_CheckNumber.Text = "Check No:"
            '
            'LabelDetailRecord_CheckDate
            '
            Me.LabelDetailRecord_CheckDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_CheckDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_CheckDate.Location = New System.Drawing.Point(16, 310)
            Me.LabelDetailRecord_CheckDate.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_CheckDate.Name = "LabelDetailRecord_CheckDate"
            Me.LabelDetailRecord_CheckDate.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_CheckDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_CheckDate.TabIndex = 20
            Me.LabelDetailRecord_CheckDate.Text = "Check Dt:"
            '
            'TextBoxDetailRecord_Filler4FillValue
            '
            '
            '
            '
            Me.TextBoxDetailRecord_Filler4FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxDetailRecord_Filler4FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetailRecord_Filler4FillValue.CheckSpellingOnValidate = False
            Me.TextBoxDetailRecord_Filler4FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetailRecord_Filler4FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetailRecord_Filler4FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetailRecord_Filler4FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetailRecord_Filler4FillValue.FocusHighlightEnabled = True
            Me.TextBoxDetailRecord_Filler4FillValue.Location = New System.Drawing.Point(664, 806)
            Me.TextBoxDetailRecord_Filler4FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxDetailRecord_Filler4FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxDetailRecord_Filler4FillValue.Name = "TextBoxDetailRecord_Filler4FillValue"
            Me.TextBoxDetailRecord_Filler4FillValue.SecurityEnabled = True
            Me.TextBoxDetailRecord_Filler4FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetailRecord_Filler4FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxDetailRecord_Filler4FillValue.StartingFolderName = Nothing
            Me.TextBoxDetailRecord_Filler4FillValue.TabIndex = 60
            Me.TextBoxDetailRecord_Filler4FillValue.TabOnEnter = True
            '
            'NumericInputDetailRecord_Filler4EndPosition
            '
            Me.NumericInputDetailRecord_Filler4EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler4EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler4EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler4EndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler4EndPosition.Location = New System.Drawing.Point(501, 806)
            Me.NumericInputDetailRecord_Filler4EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler4EndPosition.Name = "NumericInputDetailRecord_Filler4EndPosition"
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler4EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler4EndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler4EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler4EndPosition.TabIndex = 59
            '
            'NumericInputDetailRecord_Filler4BeginPosition
            '
            Me.NumericInputDetailRecord_Filler4BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler4BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler4BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler4BeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler4BeginPosition.Location = New System.Drawing.Point(339, 806)
            Me.NumericInputDetailRecord_Filler4BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler4BeginPosition.Name = "NumericInputDetailRecord_Filler4BeginPosition"
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler4BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler4BeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler4BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler4BeginPosition.TabIndex = 58
            '
            'CheckBoxDetailRecord_Filler4Export
            '
            Me.CheckBoxDetailRecord_Filler4Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_Filler4Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_Filler4Export.CheckValue = 0
            Me.CheckBoxDetailRecord_Filler4Export.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_Filler4Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_Filler4Export.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_Filler4Export.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler4Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler4Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_Filler4Export.Location = New System.Drawing.Point(235, 806)
            Me.CheckBoxDetailRecord_Filler4Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_Filler4Export.Name = "CheckBoxDetailRecord_Filler4Export"
            Me.CheckBoxDetailRecord_Filler4Export.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_Filler4Export.SecurityEnabled = True
            Me.CheckBoxDetailRecord_Filler4Export.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler4Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler4Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_Filler4Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_Filler4Export.TabIndex = 57
            Me.CheckBoxDetailRecord_Filler4Export.TabOnEnter = True
            '
            'LabelDetailRecord_Filler4
            '
            Me.LabelDetailRecord_Filler4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Filler4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Filler4.Location = New System.Drawing.Point(16, 806)
            Me.LabelDetailRecord_Filler4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Filler4.Name = "LabelDetailRecord_Filler4"
            Me.LabelDetailRecord_Filler4.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_Filler4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Filler4.TabIndex = 56
            Me.LabelDetailRecord_Filler4.Text = "Filler 4:"
            '
            'TextBoxDetailRecord_Filler3FillValue
            '
            '
            '
            '
            Me.TextBoxDetailRecord_Filler3FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxDetailRecord_Filler3FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetailRecord_Filler3FillValue.CheckSpellingOnValidate = False
            Me.TextBoxDetailRecord_Filler3FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetailRecord_Filler3FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetailRecord_Filler3FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetailRecord_Filler3FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetailRecord_Filler3FillValue.FocusHighlightEnabled = True
            Me.TextBoxDetailRecord_Filler3FillValue.Location = New System.Drawing.Point(664, 744)
            Me.TextBoxDetailRecord_Filler3FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxDetailRecord_Filler3FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxDetailRecord_Filler3FillValue.Name = "TextBoxDetailRecord_Filler3FillValue"
            Me.TextBoxDetailRecord_Filler3FillValue.SecurityEnabled = True
            Me.TextBoxDetailRecord_Filler3FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetailRecord_Filler3FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxDetailRecord_Filler3FillValue.StartingFolderName = Nothing
            Me.TextBoxDetailRecord_Filler3FillValue.TabIndex = 55
            Me.TextBoxDetailRecord_Filler3FillValue.TabOnEnter = True
            '
            'NumericInputDetailRecord_Filler3EndPosition
            '
            Me.NumericInputDetailRecord_Filler3EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler3EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler3EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler3EndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler3EndPosition.Location = New System.Drawing.Point(501, 744)
            Me.NumericInputDetailRecord_Filler3EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler3EndPosition.Name = "NumericInputDetailRecord_Filler3EndPosition"
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler3EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler3EndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler3EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler3EndPosition.TabIndex = 54
            '
            'NumericInputDetailRecord_Filler3BeginPosition
            '
            Me.NumericInputDetailRecord_Filler3BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler3BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler3BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler3BeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler3BeginPosition.Location = New System.Drawing.Point(339, 744)
            Me.NumericInputDetailRecord_Filler3BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler3BeginPosition.Name = "NumericInputDetailRecord_Filler3BeginPosition"
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler3BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler3BeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler3BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler3BeginPosition.TabIndex = 53
            '
            'CheckBoxDetailRecord_Filler3Export
            '
            Me.CheckBoxDetailRecord_Filler3Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_Filler3Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_Filler3Export.CheckValue = 0
            Me.CheckBoxDetailRecord_Filler3Export.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_Filler3Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_Filler3Export.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_Filler3Export.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler3Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler3Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_Filler3Export.Location = New System.Drawing.Point(235, 744)
            Me.CheckBoxDetailRecord_Filler3Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_Filler3Export.Name = "CheckBoxDetailRecord_Filler3Export"
            Me.CheckBoxDetailRecord_Filler3Export.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_Filler3Export.SecurityEnabled = True
            Me.CheckBoxDetailRecord_Filler3Export.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler3Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler3Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_Filler3Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_Filler3Export.TabIndex = 52
            Me.CheckBoxDetailRecord_Filler3Export.TabOnEnter = True
            '
            'LabelDetailRecord_Filler3
            '
            Me.LabelDetailRecord_Filler3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Filler3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Filler3.Location = New System.Drawing.Point(16, 744)
            Me.LabelDetailRecord_Filler3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Filler3.Name = "LabelDetailRecord_Filler3"
            Me.LabelDetailRecord_Filler3.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_Filler3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Filler3.TabIndex = 51
            Me.LabelDetailRecord_Filler3.Text = "Filler 3:"
            '
            'TextBoxDetailRecord_Filler2FillValue
            '
            '
            '
            '
            Me.TextBoxDetailRecord_Filler2FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxDetailRecord_Filler2FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetailRecord_Filler2FillValue.CheckSpellingOnValidate = False
            Me.TextBoxDetailRecord_Filler2FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetailRecord_Filler2FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetailRecord_Filler2FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetailRecord_Filler2FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetailRecord_Filler2FillValue.FocusHighlightEnabled = True
            Me.TextBoxDetailRecord_Filler2FillValue.Location = New System.Drawing.Point(664, 682)
            Me.TextBoxDetailRecord_Filler2FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxDetailRecord_Filler2FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxDetailRecord_Filler2FillValue.Name = "TextBoxDetailRecord_Filler2FillValue"
            Me.TextBoxDetailRecord_Filler2FillValue.SecurityEnabled = True
            Me.TextBoxDetailRecord_Filler2FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetailRecord_Filler2FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxDetailRecord_Filler2FillValue.StartingFolderName = Nothing
            Me.TextBoxDetailRecord_Filler2FillValue.TabIndex = 50
            Me.TextBoxDetailRecord_Filler2FillValue.TabOnEnter = True
            '
            'TextBoxDetailRecord_Filler1FillValue
            '
            '
            '
            '
            Me.TextBoxDetailRecord_Filler1FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxDetailRecord_Filler1FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetailRecord_Filler1FillValue.CheckSpellingOnValidate = False
            Me.TextBoxDetailRecord_Filler1FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetailRecord_Filler1FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetailRecord_Filler1FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetailRecord_Filler1FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetailRecord_Filler1FillValue.FocusHighlightEnabled = True
            Me.TextBoxDetailRecord_Filler1FillValue.Location = New System.Drawing.Point(664, 620)
            Me.TextBoxDetailRecord_Filler1FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxDetailRecord_Filler1FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxDetailRecord_Filler1FillValue.Name = "TextBoxDetailRecord_Filler1FillValue"
            Me.TextBoxDetailRecord_Filler1FillValue.SecurityEnabled = True
            Me.TextBoxDetailRecord_Filler1FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetailRecord_Filler1FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxDetailRecord_Filler1FillValue.StartingFolderName = Nothing
            Me.TextBoxDetailRecord_Filler1FillValue.TabIndex = 45
            Me.TextBoxDetailRecord_Filler1FillValue.TabOnEnter = True
            '
            'NumericInputDetailRecord_Filler2EndPosition
            '
            Me.NumericInputDetailRecord_Filler2EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler2EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler2EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler2EndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler2EndPosition.Location = New System.Drawing.Point(501, 682)
            Me.NumericInputDetailRecord_Filler2EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler2EndPosition.Name = "NumericInputDetailRecord_Filler2EndPosition"
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler2EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler2EndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler2EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler2EndPosition.TabIndex = 49
            '
            'NumericInputDetailRecord_Filler2BeginPosition
            '
            Me.NumericInputDetailRecord_Filler2BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler2BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler2BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler2BeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler2BeginPosition.Location = New System.Drawing.Point(339, 682)
            Me.NumericInputDetailRecord_Filler2BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler2BeginPosition.Name = "NumericInputDetailRecord_Filler2BeginPosition"
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler2BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler2BeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler2BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler2BeginPosition.TabIndex = 48
            '
            'CheckBoxDetailRecord_Filler2Export
            '
            Me.CheckBoxDetailRecord_Filler2Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_Filler2Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_Filler2Export.CheckValue = 0
            Me.CheckBoxDetailRecord_Filler2Export.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_Filler2Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_Filler2Export.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_Filler2Export.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler2Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler2Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_Filler2Export.Location = New System.Drawing.Point(235, 682)
            Me.CheckBoxDetailRecord_Filler2Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_Filler2Export.Name = "CheckBoxDetailRecord_Filler2Export"
            Me.CheckBoxDetailRecord_Filler2Export.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_Filler2Export.SecurityEnabled = True
            Me.CheckBoxDetailRecord_Filler2Export.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler2Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler2Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_Filler2Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_Filler2Export.TabIndex = 47
            Me.CheckBoxDetailRecord_Filler2Export.TabOnEnter = True
            '
            'NumericInputDetailRecord_Filler1EndPosition
            '
            Me.NumericInputDetailRecord_Filler1EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler1EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler1EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler1EndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler1EndPosition.Location = New System.Drawing.Point(501, 620)
            Me.NumericInputDetailRecord_Filler1EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler1EndPosition.Name = "NumericInputDetailRecord_Filler1EndPosition"
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler1EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler1EndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler1EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler1EndPosition.TabIndex = 44
            '
            'NumericInputDetailRecord_Filler1BeginPosition
            '
            Me.NumericInputDetailRecord_Filler1BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_Filler1BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_Filler1BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler1BeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_Filler1BeginPosition.Location = New System.Drawing.Point(339, 620)
            Me.NumericInputDetailRecord_Filler1BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_Filler1BeginPosition.Name = "NumericInputDetailRecord_Filler1BeginPosition"
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_Filler1BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_Filler1BeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_Filler1BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_Filler1BeginPosition.TabIndex = 43
            '
            'CheckBoxDetailRecord_Filler1Export
            '
            Me.CheckBoxDetailRecord_Filler1Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_Filler1Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_Filler1Export.CheckValue = 0
            Me.CheckBoxDetailRecord_Filler1Export.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_Filler1Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_Filler1Export.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_Filler1Export.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler1Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler1Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_Filler1Export.Location = New System.Drawing.Point(235, 620)
            Me.CheckBoxDetailRecord_Filler1Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_Filler1Export.Name = "CheckBoxDetailRecord_Filler1Export"
            Me.CheckBoxDetailRecord_Filler1Export.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_Filler1Export.SecurityEnabled = True
            Me.CheckBoxDetailRecord_Filler1Export.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_Filler1Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_Filler1Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_Filler1Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_Filler1Export.TabIndex = 42
            Me.CheckBoxDetailRecord_Filler1Export.TabOnEnter = True
            '
            'NumericInputDetailRecord_AccountNumberCSVOrder
            '
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Location = New System.Drawing.Point(664, 186)
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Name = "NumericInputDetailRecord_AccountNumberCSVOrder"
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_AccountNumberCSVOrder.TabIndex = 14
            '
            'NumericInputDetailRecord_AccountNumberEndPosition
            '
            Me.NumericInputDetailRecord_AccountNumberEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_AccountNumberEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_AccountNumberEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Location = New System.Drawing.Point(501, 186)
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Name = "NumericInputDetailRecord_AccountNumberEndPosition"
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_AccountNumberEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_AccountNumberEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_AccountNumberEndPosition.TabIndex = 13
            '
            'NumericInputDetailRecord_AccountNumberBeginPosition
            '
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Location = New System.Drawing.Point(339, 186)
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Name = "NumericInputDetailRecord_AccountNumberBeginPosition"
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_AccountNumberBeginPosition.TabIndex = 12
            '
            'NumericInputDetailRecord_BankIDEndPosition
            '
            Me.NumericInputDetailRecord_BankIDEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_BankIDEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_BankIDEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDEndPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_BankIDEndPosition.Location = New System.Drawing.Point(501, 124)
            Me.NumericInputDetailRecord_BankIDEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_BankIDEndPosition.Name = "NumericInputDetailRecord_BankIDEndPosition"
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_BankIDEndPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_BankIDEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_BankIDEndPosition.TabIndex = 8
            '
            'NumericInputDetailRecord_BankIDCSVOrder
            '
            Me.NumericInputDetailRecord_BankIDCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_BankIDCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_BankIDCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDCSVOrder.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_BankIDCSVOrder.Location = New System.Drawing.Point(664, 124)
            Me.NumericInputDetailRecord_BankIDCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_BankIDCSVOrder.Name = "NumericInputDetailRecord_BankIDCSVOrder"
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_BankIDCSVOrder.SecurityEnabled = True
            Me.NumericInputDetailRecord_BankIDCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_BankIDCSVOrder.TabIndex = 9
            '
            'NumericInputDetailRecord_BankIDBeginPosition
            '
            Me.NumericInputDetailRecord_BankIDBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDetailRecord_BankIDBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputDetailRecord_BankIDBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDBeginPosition.EnterMoveNextControl = True
            Me.NumericInputDetailRecord_BankIDBeginPosition.Location = New System.Drawing.Point(339, 124)
            Me.NumericInputDetailRecord_BankIDBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputDetailRecord_BankIDBeginPosition.Name = "NumericInputDetailRecord_BankIDBeginPosition"
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputDetailRecord_BankIDBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputDetailRecord_BankIDBeginPosition.SecurityEnabled = True
            Me.NumericInputDetailRecord_BankIDBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputDetailRecord_BankIDBeginPosition.TabIndex = 7
            '
            'CheckBoxDetailRecord_AccountNumberExport
            '
            Me.CheckBoxDetailRecord_AccountNumberExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_AccountNumberExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_AccountNumberExport.CheckValue = 0
            Me.CheckBoxDetailRecord_AccountNumberExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_AccountNumberExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_AccountNumberExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_AccountNumberExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_AccountNumberExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_AccountNumberExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_AccountNumberExport.Location = New System.Drawing.Point(235, 186)
            Me.CheckBoxDetailRecord_AccountNumberExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_AccountNumberExport.Name = "CheckBoxDetailRecord_AccountNumberExport"
            Me.CheckBoxDetailRecord_AccountNumberExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_AccountNumberExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_AccountNumberExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_AccountNumberExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_AccountNumberExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_AccountNumberExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_AccountNumberExport.TabIndex = 11
            Me.CheckBoxDetailRecord_AccountNumberExport.TabOnEnter = True
            '
            'LabelDetailRecord_Filler2
            '
            Me.LabelDetailRecord_Filler2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Filler2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Filler2.Location = New System.Drawing.Point(16, 682)
            Me.LabelDetailRecord_Filler2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Filler2.Name = "LabelDetailRecord_Filler2"
            Me.LabelDetailRecord_Filler2.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_Filler2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Filler2.TabIndex = 46
            Me.LabelDetailRecord_Filler2.Text = "Filler 2:"
            '
            'CheckBoxDetailRecord_BankIDExport
            '
            Me.CheckBoxDetailRecord_BankIDExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDetailRecord_BankIDExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDetailRecord_BankIDExport.CheckValue = 0
            Me.CheckBoxDetailRecord_BankIDExport.CheckValueChecked = 1
            Me.CheckBoxDetailRecord_BankIDExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDetailRecord_BankIDExport.CheckValueUnchecked = 0
            Me.CheckBoxDetailRecord_BankIDExport.ChildControls = CType(resources.GetObject("CheckBoxDetailRecord_BankIDExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_BankIDExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDetailRecord_BankIDExport.Location = New System.Drawing.Point(235, 124)
            Me.CheckBoxDetailRecord_BankIDExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxDetailRecord_BankIDExport.Name = "CheckBoxDetailRecord_BankIDExport"
            Me.CheckBoxDetailRecord_BankIDExport.OldestSibling = Nothing
            Me.CheckBoxDetailRecord_BankIDExport.SecurityEnabled = True
            Me.CheckBoxDetailRecord_BankIDExport.SiblingControls = CType(resources.GetObject("CheckBoxDetailRecord_BankIDExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDetailRecord_BankIDExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxDetailRecord_BankIDExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDetailRecord_BankIDExport.TabIndex = 6
            Me.CheckBoxDetailRecord_BankIDExport.TabOnEnter = True
            '
            'LabelDetailRecord_Filler1
            '
            Me.LabelDetailRecord_Filler1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_Filler1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_Filler1.Location = New System.Drawing.Point(16, 620)
            Me.LabelDetailRecord_Filler1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_Filler1.Name = "LabelDetailRecord_Filler1"
            Me.LabelDetailRecord_Filler1.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_Filler1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_Filler1.TabIndex = 41
            Me.LabelDetailRecord_Filler1.Text = "Filler 1:"
            '
            'LabelDetailRecord_FillValue
            '
            Me.LabelDetailRecord_FillValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_FillValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_FillValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_FillValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetailRecord_FillValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDetailRecord_FillValue.Location = New System.Drawing.Point(664, 558)
            Me.LabelDetailRecord_FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_FillValue.Name = "LabelDetailRecord_FillValue"
            Me.LabelDetailRecord_FillValue.Size = New System.Drawing.Size(147, 48)
            Me.LabelDetailRecord_FillValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_FillValue.TabIndex = 40
            Me.LabelDetailRecord_FillValue.Text = "Fill Value"
            '
            'LabelDetailRecord_BankID
            '
            Me.LabelDetailRecord_BankID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_BankID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_BankID.Location = New System.Drawing.Point(16, 124)
            Me.LabelDetailRecord_BankID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_BankID.Name = "LabelDetailRecord_BankID"
            Me.LabelDetailRecord_BankID.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_BankID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_BankID.TabIndex = 5
            Me.LabelDetailRecord_BankID.Text = "Bank ID:"
            '
            'LabelDetailRecord_CSVOrder
            '
            Me.LabelDetailRecord_CSVOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_CSVOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_CSVOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetailRecord_CSVOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDetailRecord_CSVOrder.Location = New System.Drawing.Point(664, 62)
            Me.LabelDetailRecord_CSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_CSVOrder.Name = "LabelDetailRecord_CSVOrder"
            Me.LabelDetailRecord_CSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.LabelDetailRecord_CSVOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_CSVOrder.TabIndex = 4
            Me.LabelDetailRecord_CSVOrder.Text = "CSV Order"
            '
            'LabelDetailRecord_EndPosition
            '
            Me.LabelDetailRecord_EndPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelDetailRecord_EndPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_EndPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetailRecord_EndPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelDetailRecord_EndPosition.Location = New System.Drawing.Point(501, 62)
            Me.LabelDetailRecord_EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_EndPosition.Name = "LabelDetailRecord_EndPosition"
            Me.LabelDetailRecord_EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelDetailRecord_EndPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_EndPosition.TabIndex = 3
            Me.LabelDetailRecord_EndPosition.Text = "End Pos"
            '
            'LabelDetailRecord_AccountNumber
            '
            Me.LabelDetailRecord_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDetailRecord_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDetailRecord_AccountNumber.Location = New System.Drawing.Point(16, 186)
            Me.LabelDetailRecord_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelDetailRecord_AccountNumber.Name = "LabelDetailRecord_AccountNumber"
            Me.LabelDetailRecord_AccountNumber.Size = New System.Drawing.Size(203, 48)
            Me.LabelDetailRecord_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDetailRecord_AccountNumber.TabIndex = 10
            Me.LabelDetailRecord_AccountNumber.Text = "Acct No:"
            '
            'PanelCheckExportTableLayout_LeftColumn
            '
            Me.PanelCheckExportTableLayout_LeftColumn.Controls.Add(Me.GroupBoxCheckExport_HeaderRecord)
            Me.PanelCheckExportTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelCheckExportTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelCheckExportTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelCheckExportTableLayout_LeftColumn.Name = "PanelCheckExportTableLayout_LeftColumn"
            Me.PanelCheckExportTableLayout_LeftColumn.Size = New System.Drawing.Size(941, 875)
            Me.PanelCheckExportTableLayout_LeftColumn.TabIndex = 0
            '
            'GroupBoxCheckExport_HeaderRecord
            '
            Me.GroupBoxCheckExport_HeaderRecord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.TextBoxHeaderRecord_Filler2FillValue)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.TextBoxHeaderRecord_Filler1FillValue)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_Filler2EndPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_Filler2BeginPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.CheckBoxHeaderRecord_Filler2Export)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_Filler1EndPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_Filler1BeginPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.CheckBoxHeaderRecord_Filler1Export)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_CreateDateCSVOrder)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_CreateDateEndPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_CreateDateBeginPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_AgencyEndPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_AgencyCSVOrder)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.NumericInputHeaderRecord_AgencyBeginPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.CheckBoxHeaderRecord_CreateDateExport)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_Filler2)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.CheckBoxHeaderRecord_ExportAgency)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_Filler1)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_FillValue)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_Export)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_Agency)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_CSVOrder)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_EndPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_CreateDate)
            Me.GroupBoxCheckExport_HeaderRecord.Controls.Add(Me.LabelHeaderRecord_BeginPosition)
            Me.GroupBoxCheckExport_HeaderRecord.Location = New System.Drawing.Point(16, 0)
            Me.GroupBoxCheckExport_HeaderRecord.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.GroupBoxCheckExport_HeaderRecord.Name = "GroupBoxCheckExport_HeaderRecord"
            Me.GroupBoxCheckExport_HeaderRecord.Size = New System.Drawing.Size(917, 439)
            Me.GroupBoxCheckExport_HeaderRecord.TabIndex = 0
            Me.GroupBoxCheckExport_HeaderRecord.Text = "Header Record"
            '
            'TextBoxHeaderRecord_Filler2FillValue
            '
            '
            '
            '
            Me.TextBoxHeaderRecord_Filler2FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxHeaderRecord_Filler2FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeaderRecord_Filler2FillValue.CheckSpellingOnValidate = False
            Me.TextBoxHeaderRecord_Filler2FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxHeaderRecord_Filler2FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeaderRecord_Filler2FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeaderRecord_Filler2FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeaderRecord_Filler2FillValue.FocusHighlightEnabled = True
            Me.TextBoxHeaderRecord_Filler2FillValue.Location = New System.Drawing.Point(664, 372)
            Me.TextBoxHeaderRecord_Filler2FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxHeaderRecord_Filler2FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxHeaderRecord_Filler2FillValue.Name = "TextBoxHeaderRecord_Filler2FillValue"
            Me.TextBoxHeaderRecord_Filler2FillValue.SecurityEnabled = True
            Me.TextBoxHeaderRecord_Filler2FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxHeaderRecord_Filler2FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxHeaderRecord_Filler2FillValue.StartingFolderName = Nothing
            Me.TextBoxHeaderRecord_Filler2FillValue.TabIndex = 24
            Me.TextBoxHeaderRecord_Filler2FillValue.TabOnEnter = True
            '
            'TextBoxHeaderRecord_Filler1FillValue
            '
            '
            '
            '
            Me.TextBoxHeaderRecord_Filler1FillValue.Border.Class = "TextBoxBorder"
            Me.TextBoxHeaderRecord_Filler1FillValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxHeaderRecord_Filler1FillValue.CheckSpellingOnValidate = False
            Me.TextBoxHeaderRecord_Filler1FillValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxHeaderRecord_Filler1FillValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxHeaderRecord_Filler1FillValue.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxHeaderRecord_Filler1FillValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxHeaderRecord_Filler1FillValue.FocusHighlightEnabled = True
            Me.TextBoxHeaderRecord_Filler1FillValue.Location = New System.Drawing.Point(664, 310)
            Me.TextBoxHeaderRecord_Filler1FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxHeaderRecord_Filler1FillValue.MaxFileSize = CType(0, Long)
            Me.TextBoxHeaderRecord_Filler1FillValue.Name = "TextBoxHeaderRecord_Filler1FillValue"
            Me.TextBoxHeaderRecord_Filler1FillValue.SecurityEnabled = True
            Me.TextBoxHeaderRecord_Filler1FillValue.ShowSpellCheckCompleteMessage = True
            Me.TextBoxHeaderRecord_Filler1FillValue.Size = New System.Drawing.Size(147, 40)
            Me.TextBoxHeaderRecord_Filler1FillValue.StartingFolderName = Nothing
            Me.TextBoxHeaderRecord_Filler1FillValue.TabIndex = 19
            Me.TextBoxHeaderRecord_Filler1FillValue.TabOnEnter = True
            '
            'NumericInputHeaderRecord_Filler2EndPosition
            '
            Me.NumericInputHeaderRecord_Filler2EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_Filler2EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_Filler2EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler2EndPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_Filler2EndPosition.Location = New System.Drawing.Point(501, 372)
            Me.NumericInputHeaderRecord_Filler2EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_Filler2EndPosition.Name = "NumericInputHeaderRecord_Filler2EndPosition"
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler2EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_Filler2EndPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_Filler2EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_Filler2EndPosition.TabIndex = 23
            '
            'NumericInputHeaderRecord_Filler2BeginPosition
            '
            Me.NumericInputHeaderRecord_Filler2BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_Filler2BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_Filler2BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler2BeginPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Location = New System.Drawing.Point(339, 372)
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Name = "NumericInputHeaderRecord_Filler2BeginPosition"
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_Filler2BeginPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_Filler2BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_Filler2BeginPosition.TabIndex = 22
            '
            'CheckBoxHeaderRecord_Filler2Export
            '
            Me.CheckBoxHeaderRecord_Filler2Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxHeaderRecord_Filler2Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeaderRecord_Filler2Export.CheckValue = 0
            Me.CheckBoxHeaderRecord_Filler2Export.CheckValueChecked = 1
            Me.CheckBoxHeaderRecord_Filler2Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxHeaderRecord_Filler2Export.CheckValueUnchecked = 0
            Me.CheckBoxHeaderRecord_Filler2Export.ChildControls = CType(resources.GetObject("CheckBoxHeaderRecord_Filler2Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_Filler2Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeaderRecord_Filler2Export.Location = New System.Drawing.Point(235, 372)
            Me.CheckBoxHeaderRecord_Filler2Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxHeaderRecord_Filler2Export.Name = "CheckBoxHeaderRecord_Filler2Export"
            Me.CheckBoxHeaderRecord_Filler2Export.OldestSibling = Nothing
            Me.CheckBoxHeaderRecord_Filler2Export.SecurityEnabled = True
            Me.CheckBoxHeaderRecord_Filler2Export.SiblingControls = CType(resources.GetObject("CheckBoxHeaderRecord_Filler2Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_Filler2Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxHeaderRecord_Filler2Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeaderRecord_Filler2Export.TabIndex = 21
            Me.CheckBoxHeaderRecord_Filler2Export.TabOnEnter = True
            '
            'NumericInputHeaderRecord_Filler1EndPosition
            '
            Me.NumericInputHeaderRecord_Filler1EndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_Filler1EndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_Filler1EndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler1EndPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_Filler1EndPosition.Location = New System.Drawing.Point(501, 310)
            Me.NumericInputHeaderRecord_Filler1EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_Filler1EndPosition.Name = "NumericInputHeaderRecord_Filler1EndPosition"
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler1EndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_Filler1EndPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_Filler1EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_Filler1EndPosition.TabIndex = 18
            '
            'NumericInputHeaderRecord_Filler1BeginPosition
            '
            Me.NumericInputHeaderRecord_Filler1BeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_Filler1BeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_Filler1BeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler1BeginPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Location = New System.Drawing.Point(339, 310)
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Name = "NumericInputHeaderRecord_Filler1BeginPosition"
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_Filler1BeginPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_Filler1BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_Filler1BeginPosition.TabIndex = 17
            '
            'CheckBoxHeaderRecord_Filler1Export
            '
            Me.CheckBoxHeaderRecord_Filler1Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxHeaderRecord_Filler1Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeaderRecord_Filler1Export.CheckValue = 0
            Me.CheckBoxHeaderRecord_Filler1Export.CheckValueChecked = 1
            Me.CheckBoxHeaderRecord_Filler1Export.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxHeaderRecord_Filler1Export.CheckValueUnchecked = 0
            Me.CheckBoxHeaderRecord_Filler1Export.ChildControls = CType(resources.GetObject("CheckBoxHeaderRecord_Filler1Export.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_Filler1Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeaderRecord_Filler1Export.Location = New System.Drawing.Point(235, 310)
            Me.CheckBoxHeaderRecord_Filler1Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxHeaderRecord_Filler1Export.Name = "CheckBoxHeaderRecord_Filler1Export"
            Me.CheckBoxHeaderRecord_Filler1Export.OldestSibling = Nothing
            Me.CheckBoxHeaderRecord_Filler1Export.SecurityEnabled = True
            Me.CheckBoxHeaderRecord_Filler1Export.SiblingControls = CType(resources.GetObject("CheckBoxHeaderRecord_Filler1Export.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_Filler1Export.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxHeaderRecord_Filler1Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeaderRecord_Filler1Export.TabIndex = 16
            Me.CheckBoxHeaderRecord_Filler1Export.TabOnEnter = True
            '
            'NumericInputHeaderRecord_CreateDateCSVOrder
            '
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Location = New System.Drawing.Point(664, 186)
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Name = "NumericInputHeaderRecord_CreateDateCSVOrder"
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.SecurityEnabled = True
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_CreateDateCSVOrder.TabIndex = 13
            '
            'NumericInputHeaderRecord_CreateDateEndPosition
            '
            Me.NumericInputHeaderRecord_CreateDateEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_CreateDateEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_CreateDateEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateEndPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Location = New System.Drawing.Point(501, 186)
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Name = "NumericInputHeaderRecord_CreateDateEndPosition"
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_CreateDateEndPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_CreateDateEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_CreateDateEndPosition.TabIndex = 12
            '
            'NumericInputHeaderRecord_CreateDateBeginPosition
            '
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Location = New System.Drawing.Point(339, 186)
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Name = "NumericInputHeaderRecord_CreateDateBeginPosition"
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_CreateDateBeginPosition.TabIndex = 11
            '
            'NumericInputHeaderRecord_AgencyEndPosition
            '
            Me.NumericInputHeaderRecord_AgencyEndPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_AgencyEndPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_AgencyEndPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyEndPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_AgencyEndPosition.Location = New System.Drawing.Point(501, 124)
            Me.NumericInputHeaderRecord_AgencyEndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_AgencyEndPosition.Name = "NumericInputHeaderRecord_AgencyEndPosition"
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyEndPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_AgencyEndPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_AgencyEndPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_AgencyEndPosition.TabIndex = 7
            '
            'NumericInputHeaderRecord_AgencyCSVOrder
            '
            Me.NumericInputHeaderRecord_AgencyCSVOrder.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_AgencyCSVOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_AgencyCSVOrder.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyCSVOrder.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Location = New System.Drawing.Point(664, 124)
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Name = "NumericInputHeaderRecord_AgencyCSVOrder"
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_AgencyCSVOrder.SecurityEnabled = True
            Me.NumericInputHeaderRecord_AgencyCSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_AgencyCSVOrder.TabIndex = 8
            '
            'NumericInputHeaderRecord_AgencyBeginPosition
            '
            Me.NumericInputHeaderRecord_AgencyBeginPosition.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputHeaderRecord_AgencyBeginPosition.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputHeaderRecord_AgencyBeginPosition.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyBeginPosition.EnterMoveNextControl = True
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Location = New System.Drawing.Point(339, 124)
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Name = "NumericInputHeaderRecord_AgencyBeginPosition"
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.IsFloatValue = False
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.Mask.EditMask = "n0"
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputHeaderRecord_AgencyBeginPosition.SecurityEnabled = True
            Me.NumericInputHeaderRecord_AgencyBeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.NumericInputHeaderRecord_AgencyBeginPosition.TabIndex = 6
            '
            'CheckBoxHeaderRecord_CreateDateExport
            '
            Me.CheckBoxHeaderRecord_CreateDateExport.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxHeaderRecord_CreateDateExport.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeaderRecord_CreateDateExport.CheckValue = 0
            Me.CheckBoxHeaderRecord_CreateDateExport.CheckValueChecked = 1
            Me.CheckBoxHeaderRecord_CreateDateExport.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxHeaderRecord_CreateDateExport.CheckValueUnchecked = 0
            Me.CheckBoxHeaderRecord_CreateDateExport.ChildControls = CType(resources.GetObject("CheckBoxHeaderRecord_CreateDateExport.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_CreateDateExport.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeaderRecord_CreateDateExport.Location = New System.Drawing.Point(235, 186)
            Me.CheckBoxHeaderRecord_CreateDateExport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxHeaderRecord_CreateDateExport.Name = "CheckBoxHeaderRecord_CreateDateExport"
            Me.CheckBoxHeaderRecord_CreateDateExport.OldestSibling = Nothing
            Me.CheckBoxHeaderRecord_CreateDateExport.SecurityEnabled = True
            Me.CheckBoxHeaderRecord_CreateDateExport.SiblingControls = CType(resources.GetObject("CheckBoxHeaderRecord_CreateDateExport.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_CreateDateExport.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxHeaderRecord_CreateDateExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeaderRecord_CreateDateExport.TabIndex = 10
            Me.CheckBoxHeaderRecord_CreateDateExport.TabOnEnter = True
            '
            'LabelHeaderRecord_Filler2
            '
            Me.LabelHeaderRecord_Filler2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_Filler2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_Filler2.Location = New System.Drawing.Point(16, 372)
            Me.LabelHeaderRecord_Filler2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_Filler2.Name = "LabelHeaderRecord_Filler2"
            Me.LabelHeaderRecord_Filler2.Size = New System.Drawing.Size(203, 48)
            Me.LabelHeaderRecord_Filler2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_Filler2.TabIndex = 20
            Me.LabelHeaderRecord_Filler2.Text = "Filler 2:"
            '
            'CheckBoxHeaderRecord_ExportAgency
            '
            Me.CheckBoxHeaderRecord_ExportAgency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxHeaderRecord_ExportAgency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxHeaderRecord_ExportAgency.CheckValue = 0
            Me.CheckBoxHeaderRecord_ExportAgency.CheckValueChecked = 1
            Me.CheckBoxHeaderRecord_ExportAgency.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxHeaderRecord_ExportAgency.CheckValueUnchecked = 0
            Me.CheckBoxHeaderRecord_ExportAgency.ChildControls = CType(resources.GetObject("CheckBoxHeaderRecord_ExportAgency.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_ExportAgency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxHeaderRecord_ExportAgency.Location = New System.Drawing.Point(235, 124)
            Me.CheckBoxHeaderRecord_ExportAgency.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxHeaderRecord_ExportAgency.Name = "CheckBoxHeaderRecord_ExportAgency"
            Me.CheckBoxHeaderRecord_ExportAgency.OldestSibling = Nothing
            Me.CheckBoxHeaderRecord_ExportAgency.SecurityEnabled = True
            Me.CheckBoxHeaderRecord_ExportAgency.SiblingControls = CType(resources.GetObject("CheckBoxHeaderRecord_ExportAgency.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxHeaderRecord_ExportAgency.Size = New System.Drawing.Size(88, 48)
            Me.CheckBoxHeaderRecord_ExportAgency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxHeaderRecord_ExportAgency.TabIndex = 5
            Me.CheckBoxHeaderRecord_ExportAgency.TabOnEnter = True
            '
            'LabelHeaderRecord_Filler1
            '
            Me.LabelHeaderRecord_Filler1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_Filler1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_Filler1.Location = New System.Drawing.Point(16, 310)
            Me.LabelHeaderRecord_Filler1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_Filler1.Name = "LabelHeaderRecord_Filler1"
            Me.LabelHeaderRecord_Filler1.Size = New System.Drawing.Size(203, 48)
            Me.LabelHeaderRecord_Filler1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_Filler1.TabIndex = 15
            Me.LabelHeaderRecord_Filler1.Text = "Filler 1:"
            '
            'LabelHeaderRecord_FillValue
            '
            Me.LabelHeaderRecord_FillValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_FillValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_FillValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderRecord_FillValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHeaderRecord_FillValue.Location = New System.Drawing.Point(664, 248)
            Me.LabelHeaderRecord_FillValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_FillValue.Name = "LabelHeaderRecord_FillValue"
            Me.LabelHeaderRecord_FillValue.Size = New System.Drawing.Size(147, 48)
            Me.LabelHeaderRecord_FillValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_FillValue.TabIndex = 14
            Me.LabelHeaderRecord_FillValue.Text = "Fill Value"
            '
            'LabelHeaderRecord_Export
            '
            Me.LabelHeaderRecord_Export.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_Export.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_Export.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderRecord_Export.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHeaderRecord_Export.Location = New System.Drawing.Point(235, 62)
            Me.LabelHeaderRecord_Export.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_Export.Name = "LabelHeaderRecord_Export"
            Me.LabelHeaderRecord_Export.Size = New System.Drawing.Size(88, 48)
            Me.LabelHeaderRecord_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_Export.TabIndex = 0
            Me.LabelHeaderRecord_Export.Text = "Export"
            '
            'LabelHeaderRecord_Agency
            '
            Me.LabelHeaderRecord_Agency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_Agency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_Agency.Location = New System.Drawing.Point(16, 124)
            Me.LabelHeaderRecord_Agency.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_Agency.Name = "LabelHeaderRecord_Agency"
            Me.LabelHeaderRecord_Agency.Size = New System.Drawing.Size(203, 48)
            Me.LabelHeaderRecord_Agency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_Agency.TabIndex = 4
            Me.LabelHeaderRecord_Agency.Text = "Agency:"
            '
            'LabelHeaderRecord_CSVOrder
            '
            Me.LabelHeaderRecord_CSVOrder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_CSVOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_CSVOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderRecord_CSVOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHeaderRecord_CSVOrder.Location = New System.Drawing.Point(664, 62)
            Me.LabelHeaderRecord_CSVOrder.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_CSVOrder.Name = "LabelHeaderRecord_CSVOrder"
            Me.LabelHeaderRecord_CSVOrder.Size = New System.Drawing.Size(147, 48)
            Me.LabelHeaderRecord_CSVOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_CSVOrder.TabIndex = 3
            Me.LabelHeaderRecord_CSVOrder.Text = "CSV Order"
            '
            'LabelHeaderRecord_EndPosition
            '
            Me.LabelHeaderRecord_EndPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_EndPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_EndPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderRecord_EndPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHeaderRecord_EndPosition.Location = New System.Drawing.Point(501, 62)
            Me.LabelHeaderRecord_EndPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_EndPosition.Name = "LabelHeaderRecord_EndPosition"
            Me.LabelHeaderRecord_EndPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelHeaderRecord_EndPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_EndPosition.TabIndex = 2
            Me.LabelHeaderRecord_EndPosition.Text = "End Pos"
            '
            'LabelHeaderRecord_CreateDate
            '
            Me.LabelHeaderRecord_CreateDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_CreateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_CreateDate.Location = New System.Drawing.Point(16, 186)
            Me.LabelHeaderRecord_CreateDate.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_CreateDate.Name = "LabelHeaderRecord_CreateDate"
            Me.LabelHeaderRecord_CreateDate.Size = New System.Drawing.Size(203, 48)
            Me.LabelHeaderRecord_CreateDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_CreateDate.TabIndex = 9
            Me.LabelHeaderRecord_CreateDate.Text = "Create Date:"
            '
            'LabelHeaderRecord_BeginPosition
            '
            Me.LabelHeaderRecord_BeginPosition.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelHeaderRecord_BeginPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelHeaderRecord_BeginPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderRecord_BeginPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelHeaderRecord_BeginPosition.Location = New System.Drawing.Point(339, 62)
            Me.LabelHeaderRecord_BeginPosition.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelHeaderRecord_BeginPosition.Name = "LabelHeaderRecord_BeginPosition"
            Me.LabelHeaderRecord_BeginPosition.Size = New System.Drawing.Size(147, 48)
            Me.LabelHeaderRecord_BeginPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelHeaderRecord_BeginPosition.TabIndex = 1
            Me.LabelHeaderRecord_BeginPosition.Text = "Beg Pos"
            '
            'CheckBoxCheckExport_UseHeaderRecord
            '
            Me.CheckBoxCheckExport_UseHeaderRecord.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCheckExport_UseHeaderRecord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCheckExport_UseHeaderRecord.CheckValue = 0
            Me.CheckBoxCheckExport_UseHeaderRecord.CheckValueChecked = 1
            Me.CheckBoxCheckExport_UseHeaderRecord.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCheckExport_UseHeaderRecord.CheckValueUnchecked = 0
            Me.CheckBoxCheckExport_UseHeaderRecord.ChildControls = CType(resources.GetObject("CheckBoxCheckExport_UseHeaderRecord.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckExport_UseHeaderRecord.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCheckExport_UseHeaderRecord.Location = New System.Drawing.Point(16, 76)
            Me.CheckBoxCheckExport_UseHeaderRecord.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxCheckExport_UseHeaderRecord.Name = "CheckBoxCheckExport_UseHeaderRecord"
            Me.CheckBoxCheckExport_UseHeaderRecord.OldestSibling = Nothing
            Me.CheckBoxCheckExport_UseHeaderRecord.SecurityEnabled = True
            Me.CheckBoxCheckExport_UseHeaderRecord.SiblingControls = CType(resources.GetObject("CheckBoxCheckExport_UseHeaderRecord.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCheckExport_UseHeaderRecord.Size = New System.Drawing.Size(349, 48)
            Me.CheckBoxCheckExport_UseHeaderRecord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCheckExport_UseHeaderRecord.TabIndex = 3
            Me.CheckBoxCheckExport_UseHeaderRecord.TabOnEnter = True
            Me.CheckBoxCheckExport_UseHeaderRecord.Text = "Use Header Record"
            '
            'RadioButtonControlCheckExport_CSV
            '
            Me.RadioButtonControlCheckExport_CSV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonControlCheckExport_CSV.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlCheckExport_CSV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlCheckExport_CSV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlCheckExport_CSV.Location = New System.Drawing.Point(437, 14)
            Me.RadioButtonControlCheckExport_CSV.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.RadioButtonControlCheckExport_CSV.Name = "RadioButtonControlCheckExport_CSV"
            Me.RadioButtonControlCheckExport_CSV.SecurityEnabled = True
            Me.RadioButtonControlCheckExport_CSV.Size = New System.Drawing.Size(1429, 48)
            Me.RadioButtonControlCheckExport_CSV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlCheckExport_CSV.TabIndex = 2
            Me.RadioButtonControlCheckExport_CSV.TabOnEnter = True
            Me.RadioButtonControlCheckExport_CSV.TabStop = False
            Me.RadioButtonControlCheckExport_CSV.Text = "CSV"
            '
            'RadioButtonControlCheckExport_Fixed
            '
            Me.RadioButtonControlCheckExport_Fixed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlCheckExport_Fixed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlCheckExport_Fixed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlCheckExport_Fixed.Location = New System.Drawing.Point(251, 14)
            Me.RadioButtonControlCheckExport_Fixed.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.RadioButtonControlCheckExport_Fixed.Name = "RadioButtonControlCheckExport_Fixed"
            Me.RadioButtonControlCheckExport_Fixed.SecurityEnabled = True
            Me.RadioButtonControlCheckExport_Fixed.Size = New System.Drawing.Size(171, 48)
            Me.RadioButtonControlCheckExport_Fixed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlCheckExport_Fixed.TabIndex = 1
            Me.RadioButtonControlCheckExport_Fixed.TabOnEnter = True
            Me.RadioButtonControlCheckExport_Fixed.TabStop = False
            Me.RadioButtonControlCheckExport_Fixed.Text = "Fixed"
            '
            'LabelCheckExport_ExportFormat
            '
            Me.LabelCheckExport_ExportFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckExport_ExportFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckExport_ExportFormat.Location = New System.Drawing.Point(16, 14)
            Me.LabelCheckExport_ExportFormat.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCheckExport_ExportFormat.Name = "LabelCheckExport_ExportFormat"
            Me.LabelCheckExport_ExportFormat.Size = New System.Drawing.Size(219, 48)
            Me.LabelCheckExport_ExportFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckExport_ExportFormat.TabIndex = 0
            Me.LabelCheckExport_ExportFormat.Text = "Export Format:"
            '
            'TabItemBankDetails_CheckExport
            '
            Me.TabItemBankDetails_CheckExport.AttachedControl = Me.TabControlPanelCheckExport_CheckExport
            Me.TabItemBankDetails_CheckExport.Name = "TabItemBankDetails_CheckExport"
            Me.TabItemBankDetails_CheckExport.Text = "Check Export"
            '
            'TabControlPanelCheckImport_CheckImport
            '
            Me.TabControlPanelCheckImport_CheckImport.Controls.Add(Me.TextBoxCheckImport_ImportFileName)
            Me.TabControlPanelCheckImport_CheckImport.Controls.Add(Me.TableLayoutPanelCheckImport_TableLayout)
            Me.TabControlPanelCheckImport_CheckImport.Controls.Add(Me.LabelCheckImport_ImportFileName)
            Me.TabControlPanelCheckImport_CheckImport.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCheckImport_CheckImport.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCheckImport_CheckImport.Location = New System.Drawing.Point(0, 56)
            Me.TabControlPanelCheckImport_CheckImport.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelCheckImport_CheckImport.Name = "TabControlPanelCheckImport_CheckImport"
            Me.TabControlPanelCheckImport_CheckImport.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelCheckImport_CheckImport.Size = New System.Drawing.Size(1883, 1508)
            Me.TabControlPanelCheckImport_CheckImport.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCheckImport_CheckImport.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCheckImport_CheckImport.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCheckImport_CheckImport.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCheckImport_CheckImport.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCheckImport_CheckImport.Style.GradientAngle = 90
            Me.TabControlPanelCheckImport_CheckImport.TabIndex = 2
            Me.TabControlPanelCheckImport_CheckImport.TabItem = Me.TabItemBankDetails_CheckImport
            '
            'TextBoxCheckImport_ImportFileName
            '
            Me.TextBoxCheckImport_ImportFileName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxCheckImport_ImportFileName.Border.Class = "TextBoxBorder"
            Me.TextBoxCheckImport_ImportFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCheckImport_ImportFileName.CheckSpellingOnValidate = False
            Me.TextBoxCheckImport_ImportFileName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCheckImport_ImportFileName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCheckImport_ImportFileName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCheckImport_ImportFileName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCheckImport_ImportFileName.FocusHighlightEnabled = True
            Me.TextBoxCheckImport_ImportFileName.Location = New System.Drawing.Point(291, 14)
            Me.TextBoxCheckImport_ImportFileName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxCheckImport_ImportFileName.MaxFileSize = CType(0, Long)
            Me.TextBoxCheckImport_ImportFileName.Name = "TextBoxCheckImport_ImportFileName"
            Me.TextBoxCheckImport_ImportFileName.SecurityEnabled = True
            Me.TextBoxCheckImport_ImportFileName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCheckImport_ImportFileName.Size = New System.Drawing.Size(1576, 38)
            Me.TextBoxCheckImport_ImportFileName.StartingFolderName = Nothing
            Me.TextBoxCheckImport_ImportFileName.TabIndex = 1
            Me.TextBoxCheckImport_ImportFileName.TabOnEnter = True
            '
            'TableLayoutPanelCheckImport_TableLayout
            '
            Me.TableLayoutPanelCheckImport_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelCheckImport_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelCheckImport_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelCheckImport_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckImport_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckImport_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelCheckImport_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelCheckImport_TableLayout.Location = New System.Drawing.Point(0, 76)
            Me.TableLayoutPanelCheckImport_TableLayout.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TableLayoutPanelCheckImport_TableLayout.Name = "TableLayoutPanelCheckImport_TableLayout"
            Me.TableLayoutPanelCheckImport_TableLayout.RowCount = 1
            Me.TableLayoutPanelCheckImport_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelCheckImport_TableLayout.Size = New System.Drawing.Size(1883, 265)
            Me.TableLayoutPanelCheckImport_TableLayout.TabIndex = 2
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.NumericInputRightColumn_NumberOfDecimals)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.NumericInputRightColumn_Length)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.NumericInputRightColumn_ColumnStart)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelRightColumn_NumberOfDecimals)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelRightColumn_Length)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelRightColumn_ColumnStart)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelRightColumn_CheckAmount)
            Me.PanelTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(941, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(942, 265)
            Me.PanelTableLayout_RightColumn.TabIndex = 1
            '
            'NumericInputRightColumn_NumberOfDecimals
            '
            Me.NumericInputRightColumn_NumberOfDecimals.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRightColumn_NumberOfDecimals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRightColumn_NumberOfDecimals.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputRightColumn_NumberOfDecimals.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRightColumn_NumberOfDecimals.EnterMoveNextControl = True
            Me.NumericInputRightColumn_NumberOfDecimals.Location = New System.Drawing.Point(221, 191)
            Me.NumericInputRightColumn_NumberOfDecimals.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputRightColumn_NumberOfDecimals.Name = "NumericInputRightColumn_NumberOfDecimals"
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.IsFloatValue = False
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.Mask.EditMask = "n0"
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputRightColumn_NumberOfDecimals.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputRightColumn_NumberOfDecimals.SecurityEnabled = True
            Me.NumericInputRightColumn_NumberOfDecimals.Size = New System.Drawing.Size(705, 48)
            Me.NumericInputRightColumn_NumberOfDecimals.TabIndex = 6
            '
            'NumericInputRightColumn_Length
            '
            Me.NumericInputRightColumn_Length.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRightColumn_Length.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRightColumn_Length.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputRightColumn_Length.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRightColumn_Length.EnterMoveNextControl = True
            Me.NumericInputRightColumn_Length.Location = New System.Drawing.Point(221, 129)
            Me.NumericInputRightColumn_Length.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputRightColumn_Length.Name = "NumericInputRightColumn_Length"
            Me.NumericInputRightColumn_Length.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputRightColumn_Length.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_Length.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputRightColumn_Length.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_Length.Properties.IsFloatValue = False
            Me.NumericInputRightColumn_Length.Properties.Mask.EditMask = "n0"
            Me.NumericInputRightColumn_Length.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRightColumn_Length.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputRightColumn_Length.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputRightColumn_Length.SecurityEnabled = True
            Me.NumericInputRightColumn_Length.Size = New System.Drawing.Size(705, 48)
            Me.NumericInputRightColumn_Length.TabIndex = 4
            '
            'NumericInputRightColumn_ColumnStart
            '
            Me.NumericInputRightColumn_ColumnStart.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputRightColumn_ColumnStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputRightColumn_ColumnStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputRightColumn_ColumnStart.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputRightColumn_ColumnStart.EnterMoveNextControl = True
            Me.NumericInputRightColumn_ColumnStart.Location = New System.Drawing.Point(221, 67)
            Me.NumericInputRightColumn_ColumnStart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputRightColumn_ColumnStart.Name = "NumericInputRightColumn_ColumnStart"
            Me.NumericInputRightColumn_ColumnStart.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputRightColumn_ColumnStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_ColumnStart.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputRightColumn_ColumnStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputRightColumn_ColumnStart.Properties.IsFloatValue = False
            Me.NumericInputRightColumn_ColumnStart.Properties.Mask.EditMask = "n0"
            Me.NumericInputRightColumn_ColumnStart.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputRightColumn_ColumnStart.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputRightColumn_ColumnStart.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputRightColumn_ColumnStart.SecurityEnabled = True
            Me.NumericInputRightColumn_ColumnStart.Size = New System.Drawing.Size(705, 48)
            Me.NumericInputRightColumn_ColumnStart.TabIndex = 2
            '
            'LabelRightColumn_NumberOfDecimals
            '
            Me.LabelRightColumn_NumberOfDecimals.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightColumn_NumberOfDecimals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightColumn_NumberOfDecimals.Location = New System.Drawing.Point(8, 191)
            Me.LabelRightColumn_NumberOfDecimals.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelRightColumn_NumberOfDecimals.Name = "LabelRightColumn_NumberOfDecimals"
            Me.LabelRightColumn_NumberOfDecimals.Size = New System.Drawing.Size(197, 48)
            Me.LabelRightColumn_NumberOfDecimals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightColumn_NumberOfDecimals.TabIndex = 5
            Me.LabelRightColumn_NumberOfDecimals.Text = "# of Decimals:"
            '
            'LabelRightColumn_Length
            '
            Me.LabelRightColumn_Length.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightColumn_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightColumn_Length.Location = New System.Drawing.Point(8, 129)
            Me.LabelRightColumn_Length.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelRightColumn_Length.Name = "LabelRightColumn_Length"
            Me.LabelRightColumn_Length.Size = New System.Drawing.Size(197, 48)
            Me.LabelRightColumn_Length.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightColumn_Length.TabIndex = 3
            Me.LabelRightColumn_Length.Text = "Length:"
            '
            'LabelRightColumn_ColumnStart
            '
            Me.LabelRightColumn_ColumnStart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightColumn_ColumnStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightColumn_ColumnStart.Location = New System.Drawing.Point(8, 67)
            Me.LabelRightColumn_ColumnStart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelRightColumn_ColumnStart.Name = "LabelRightColumn_ColumnStart"
            Me.LabelRightColumn_ColumnStart.Size = New System.Drawing.Size(197, 48)
            Me.LabelRightColumn_ColumnStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightColumn_ColumnStart.TabIndex = 1
            Me.LabelRightColumn_ColumnStart.Text = "Column Start:"
            '
            'LabelRightColumn_CheckAmount
            '
            Me.LabelRightColumn_CheckAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelRightColumn_CheckAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelRightColumn_CheckAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightColumn_CheckAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelRightColumn_CheckAmount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelRightColumn_CheckAmount.Location = New System.Drawing.Point(8, 5)
            Me.LabelRightColumn_CheckAmount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelRightColumn_CheckAmount.Name = "LabelRightColumn_CheckAmount"
            Me.LabelRightColumn_CheckAmount.Size = New System.Drawing.Size(918, 48)
            Me.LabelRightColumn_CheckAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightColumn_CheckAmount.TabIndex = 0
            Me.LabelRightColumn_CheckAmount.Text = "Check Amount"
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputLeftColumn_Length)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.NumericInputLeftColumn_ColumnStart)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelCheckImport_CheckNumber)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelLeftColumn_Length)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.LabelLeftColumn_ColumnStart)
            Me.PanelTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(941, 265)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
            '
            'NumericInputLeftColumn_Length
            '
            Me.NumericInputLeftColumn_Length.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputLeftColumn_Length.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputLeftColumn_Length.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputLeftColumn_Length.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLeftColumn_Length.EnterMoveNextControl = True
            Me.NumericInputLeftColumn_Length.Location = New System.Drawing.Point(229, 129)
            Me.NumericInputLeftColumn_Length.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputLeftColumn_Length.Name = "NumericInputLeftColumn_Length"
            Me.NumericInputLeftColumn_Length.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputLeftColumn_Length.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftColumn_Length.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputLeftColumn_Length.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftColumn_Length.Properties.IsFloatValue = False
            Me.NumericInputLeftColumn_Length.Properties.Mask.EditMask = "n0"
            Me.NumericInputLeftColumn_Length.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLeftColumn_Length.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputLeftColumn_Length.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputLeftColumn_Length.SecurityEnabled = True
            Me.NumericInputLeftColumn_Length.Size = New System.Drawing.Size(704, 48)
            Me.NumericInputLeftColumn_Length.TabIndex = 4
            '
            'NumericInputLeftColumn_ColumnStart
            '
            Me.NumericInputLeftColumn_ColumnStart.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputLeftColumn_ColumnStart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputLeftColumn_ColumnStart.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputLeftColumn_ColumnStart.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputLeftColumn_ColumnStart.EnterMoveNextControl = True
            Me.NumericInputLeftColumn_ColumnStart.Location = New System.Drawing.Point(229, 67)
            Me.NumericInputLeftColumn_ColumnStart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputLeftColumn_ColumnStart.Name = "NumericInputLeftColumn_ColumnStart"
            Me.NumericInputLeftColumn_ColumnStart.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputLeftColumn_ColumnStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftColumn_ColumnStart.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputLeftColumn_ColumnStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputLeftColumn_ColumnStart.Properties.IsFloatValue = False
            Me.NumericInputLeftColumn_ColumnStart.Properties.Mask.EditMask = "n0"
            Me.NumericInputLeftColumn_ColumnStart.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputLeftColumn_ColumnStart.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputLeftColumn_ColumnStart.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputLeftColumn_ColumnStart.SecurityEnabled = True
            Me.NumericInputLeftColumn_ColumnStart.Size = New System.Drawing.Size(704, 48)
            Me.NumericInputLeftColumn_ColumnStart.TabIndex = 2
            '
            'LabelCheckImport_CheckNumber
            '
            Me.LabelCheckImport_CheckNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelCheckImport_CheckNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelCheckImport_CheckNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckImport_CheckNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCheckImport_CheckNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelCheckImport_CheckNumber.Location = New System.Drawing.Point(16, 5)
            Me.LabelCheckImport_CheckNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCheckImport_CheckNumber.Name = "LabelCheckImport_CheckNumber"
            Me.LabelCheckImport_CheckNumber.Size = New System.Drawing.Size(917, 48)
            Me.LabelCheckImport_CheckNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckImport_CheckNumber.TabIndex = 0
            Me.LabelCheckImport_CheckNumber.Text = "Check Number"
            '
            'LabelLeftColumn_Length
            '
            Me.LabelLeftColumn_Length.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftColumn_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftColumn_Length.Location = New System.Drawing.Point(16, 129)
            Me.LabelLeftColumn_Length.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelLeftColumn_Length.Name = "LabelLeftColumn_Length"
            Me.LabelLeftColumn_Length.Size = New System.Drawing.Size(197, 48)
            Me.LabelLeftColumn_Length.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftColumn_Length.TabIndex = 3
            Me.LabelLeftColumn_Length.Text = "Length:"
            '
            'LabelLeftColumn_ColumnStart
            '
            Me.LabelLeftColumn_ColumnStart.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelLeftColumn_ColumnStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLeftColumn_ColumnStart.Location = New System.Drawing.Point(16, 67)
            Me.LabelLeftColumn_ColumnStart.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelLeftColumn_ColumnStart.Name = "LabelLeftColumn_ColumnStart"
            Me.LabelLeftColumn_ColumnStart.Size = New System.Drawing.Size(197, 48)
            Me.LabelLeftColumn_ColumnStart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLeftColumn_ColumnStart.TabIndex = 1
            Me.LabelLeftColumn_ColumnStart.Text = "Column Start:"
            '
            'LabelCheckImport_ImportFileName
            '
            Me.LabelCheckImport_ImportFileName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckImport_ImportFileName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckImport_ImportFileName.Location = New System.Drawing.Point(16, 14)
            Me.LabelCheckImport_ImportFileName.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCheckImport_ImportFileName.Name = "LabelCheckImport_ImportFileName"
            Me.LabelCheckImport_ImportFileName.Size = New System.Drawing.Size(259, 48)
            Me.LabelCheckImport_ImportFileName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckImport_ImportFileName.TabIndex = 0
            Me.LabelCheckImport_ImportFileName.Text = "Import File Name:"
            '
            'TabItemBankDetails_CheckImport
            '
            Me.TabItemBankDetails_CheckImport.AttachedControl = Me.TabControlPanelCheckImport_CheckImport
            Me.TabItemBankDetails_CheckImport.Name = "TabItemBankDetails_CheckImport"
            Me.TabItemBankDetails_CheckImport.Text = "Check Import"
            '
            'TabControlPanelCurrency_Currency
            '
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.SearchableComboBoxCurrency_ExchangeRealizedAccount)
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount)
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.SearchableComboBoxCurrency_Currency)
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.LabelCurrency_CurrencyExchangeRealizedAccount)
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.LabelCurrency_CurrencyExchangeUnrealizedAccount)
            Me.TabControlPanelCurrency_Currency.Controls.Add(Me.LabelCurrency_Currency)
            Me.TabControlPanelCurrency_Currency.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCurrency_Currency.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCurrency_Currency.Location = New System.Drawing.Point(0, 56)
            Me.TabControlPanelCurrency_Currency.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelCurrency_Currency.Name = "TabControlPanelCurrency_Currency"
            Me.TabControlPanelCurrency_Currency.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelCurrency_Currency.Size = New System.Drawing.Size(1883, 1508)
            Me.TabControlPanelCurrency_Currency.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCurrency_Currency.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCurrency_Currency.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCurrency_Currency.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCurrency_Currency.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCurrency_Currency.Style.GradientAngle = 90
            Me.TabControlPanelCurrency_Currency.TabIndex = 1
            Me.TabControlPanelCurrency_Currency.TabItem = Me.TabItemBankDetails_Currency
            '
            'SearchableComboBoxCurrency_ExchangeRealizedAccount
            '
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.ActiveFilterString = ""
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.AutoFillMode = False
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.DataSource = Nothing
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.DisableMouseWheel = False
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.DisplayName = ""
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Location = New System.Drawing.Point(680, 76)
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Name = "SearchableComboBoxCurrency_ExchangeRealizedAccount"
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties.PopupView = Me.GridView10
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.SecurityEnabled = True
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.SelectedValue = Nothing
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Size = New System.Drawing.Size(1187, 48)
            Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.TabIndex = 3
            '
            'GridView10
            '
            Me.GridView10.AFActiveFilterString = ""
            Me.GridView10.AllowExtraItemsInGridLookupEdits = True
            Me.GridView10.AutoFilterLookupColumns = False
            Me.GridView10.AutoloadRepositoryDatasource = True
            Me.GridView10.DataSourceClearing = False
            Me.GridView10.DetailHeight = 835
            Me.GridView10.EnableDisabledRows = False
            Me.GridView10.FixedLineWidth = 5
            Me.GridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView10.Name = "GridView10"
            Me.GridView10.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView10.OptionsView.ShowGroupPanel = False
            Me.GridView10.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView10.RunStandardValidation = True
            Me.GridView10.SkipAddingControlsOnModifyColumn = False
            Me.GridView10.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxCurrency_ExchangeUnrealizedAccount
            '
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.ActiveFilterString = ""
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.AutoFillMode = False
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.DataSource = Nothing
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.DisableMouseWheel = False
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.DisplayName = ""
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Location = New System.Drawing.Point(680, 138)
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Name = "SearchableComboBoxCurrency_ExchangeUnrealizedAccount"
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties.PopupView = Me.GridView9
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SecurityEnabled = True
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.SelectedValue = Nothing
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Size = New System.Drawing.Size(1187, 48)
            Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.TabIndex = 5
            '
            'GridView9
            '
            Me.GridView9.AFActiveFilterString = ""
            Me.GridView9.AllowExtraItemsInGridLookupEdits = True
            Me.GridView9.AutoFilterLookupColumns = False
            Me.GridView9.AutoloadRepositoryDatasource = True
            Me.GridView9.DataSourceClearing = False
            Me.GridView9.DetailHeight = 835
            Me.GridView9.EnableDisabledRows = False
            Me.GridView9.FixedLineWidth = 5
            Me.GridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView9.Name = "GridView9"
            Me.GridView9.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView9.OptionsView.ShowGroupPanel = False
            Me.GridView9.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView9.RunStandardValidation = True
            Me.GridView9.SkipAddingControlsOnModifyColumn = False
            Me.GridView9.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxCurrency_Currency
            '
            Me.SearchableComboBoxCurrency_Currency.ActiveFilterString = ""
            Me.SearchableComboBoxCurrency_Currency.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxCurrency_Currency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCurrency_Currency.AutoFillMode = False
            Me.SearchableComboBoxCurrency_Currency.BookmarkingEnabled = False
            Me.SearchableComboBoxCurrency_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxCurrency_Currency.DataSource = Nothing
            Me.SearchableComboBoxCurrency_Currency.DisableMouseWheel = False
            Me.SearchableComboBoxCurrency_Currency.DisplayName = ""
            Me.SearchableComboBoxCurrency_Currency.EnterMoveNextControl = True
            Me.SearchableComboBoxCurrency_Currency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxCurrency_Currency.Location = New System.Drawing.Point(680, 14)
            Me.SearchableComboBoxCurrency_Currency.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxCurrency_Currency.Name = "SearchableComboBoxCurrency_Currency"
            Me.SearchableComboBoxCurrency_Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCurrency_Currency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCurrency_Currency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxCurrency_Currency.Properties.PopupView = Me.GridView7
            Me.SearchableComboBoxCurrency_Currency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCurrency_Currency.SecurityEnabled = True
            Me.SearchableComboBoxCurrency_Currency.SelectedValue = Nothing
            Me.SearchableComboBoxCurrency_Currency.Size = New System.Drawing.Size(1187, 48)
            Me.SearchableComboBoxCurrency_Currency.TabIndex = 1
            '
            'GridView7
            '
            Me.GridView7.AFActiveFilterString = ""
            Me.GridView7.AllowExtraItemsInGridLookupEdits = True
            Me.GridView7.AutoFilterLookupColumns = False
            Me.GridView7.AutoloadRepositoryDatasource = True
            Me.GridView7.DataSourceClearing = False
            Me.GridView7.DetailHeight = 835
            Me.GridView7.EnableDisabledRows = False
            Me.GridView7.FixedLineWidth = 5
            Me.GridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView7.Name = "GridView7"
            Me.GridView7.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView7.OptionsView.ShowGroupPanel = False
            Me.GridView7.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView7.RunStandardValidation = True
            Me.GridView7.SkipAddingControlsOnModifyColumn = False
            Me.GridView7.SkipSettingFontOnModifyColumn = False
            '
            'LabelCurrency_CurrencyExchangeRealizedAccount
            '
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Location = New System.Drawing.Point(16, 76)
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Name = "LabelCurrency_CurrencyExchangeRealizedAccount"
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Size = New System.Drawing.Size(648, 48)
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.TabIndex = 2
            Me.LabelCurrency_CurrencyExchangeRealizedAccount.Text = "Currency Exchange Realized:"
            '
            'LabelCurrency_CurrencyExchangeUnrealizedAccount
            '
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Location = New System.Drawing.Point(16, 138)
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Name = "LabelCurrency_CurrencyExchangeUnrealizedAccount"
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Size = New System.Drawing.Size(648, 48)
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.TabIndex = 4
            Me.LabelCurrency_CurrencyExchangeUnrealizedAccount.Text = "Currency Exchange Unrealized:"
            '
            'LabelCurrency_Currency
            '
            Me.LabelCurrency_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrency_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrency_Currency.Location = New System.Drawing.Point(16, 14)
            Me.LabelCurrency_Currency.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCurrency_Currency.Name = "LabelCurrency_Currency"
            Me.LabelCurrency_Currency.Size = New System.Drawing.Size(648, 48)
            Me.LabelCurrency_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrency_Currency.TabIndex = 0
            Me.LabelCurrency_Currency.Text = "Currency:"
            '
            'TabItemBankDetails_Currency
            '
            Me.TabItemBankDetails_Currency.AttachedControl = Me.TabControlPanelCurrency_Currency
            Me.TabItemBankDetails_Currency.Name = "TabItemBankDetails_Currency"
            Me.TabItemBankDetails_Currency.Text = "Currency"
            '
            'TabControlPanelSetup_Setup
            '
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_CheckWritingInProgress)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ComboBoxSetup_DigitalSignatureFontSize)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_DigitalSignatureFontSize)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ComboBoxSetup_DigitalSignatureFont)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_DigitalSignatureFont)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_DigitalSignatureText)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_DigitalSignatureText)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.CheckBoxSetup_DigitalSignatureActive)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_DigitalSignature)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_APComputerCheckFormat)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_InterestEarnedGLAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_ServiceChargeGLAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_APDiscAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_APCashAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_ARCashAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_Office)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.CheckBoxSetup_PaymentManager)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.CheckBoxSetup_Inactive)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ComboBoxSetup_CheckAmountInWords)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.NumericInputSetup_LastComputerCheckIssued)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.NumericInputSetup_LastManualCheckIssued)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.NumericInputSetup_CheckTemplateID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.NumericInputSetup_RoutingNumber)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_Name)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Name)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_Code)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Code)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_BankID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_ACHCompanyID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_AccountNumber)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_CheckTemplateID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_CheckAmountInWords)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_APComputerCheckFormat)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_InterestEarnedGLAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_ServiceChargeGLAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_APDiscAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_APCashAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_ARCashAccount)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Office)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_LastComputerCheckIssued)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_LastManualCheckIssued)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_BankID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_ACHCompanyID)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_RoutingNumber)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_AccountNumber)
            Me.TabControlPanelSetup_Setup.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSetup_Setup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSetup_Setup.Location = New System.Drawing.Point(0, 43)
            Me.TabControlPanelSetup_Setup.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TabControlPanelSetup_Setup.Name = "TabControlPanelSetup_Setup"
            Me.TabControlPanelSetup_Setup.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.TabControlPanelSetup_Setup.Size = New System.Drawing.Size(1883, 1521)
            Me.TabControlPanelSetup_Setup.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSetup_Setup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSetup_Setup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSetup_Setup.Style.GradientAngle = 90
            Me.TabControlPanelSetup_Setup.TabIndex = 0
            Me.TabControlPanelSetup_Setup.TabItem = Me.TabItemBankDetails_Setup
            '
            'LabelSetup_CheckWritingInProgress
            '
            Me.LabelSetup_CheckWritingInProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_CheckWritingInProgress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_CheckWritingInProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_CheckWritingInProgress.ForeColor = System.Drawing.Color.Red
            Me.LabelSetup_CheckWritingInProgress.Location = New System.Drawing.Point(8, 768)
            Me.LabelSetup_CheckWritingInProgress.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_CheckWritingInProgress.Name = "LabelSetup_CheckWritingInProgress"
            Me.LabelSetup_CheckWritingInProgress.Size = New System.Drawing.Size(1859, 48)
            Me.LabelSetup_CheckWritingInProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_CheckWritingInProgress.TabIndex = 48
            Me.LabelSetup_CheckWritingInProgress.Text = "* Note: Check related information is locked during an active Check Run."
            '
            'ComboBoxSetup_DigitalSignatureFontSize
            '
            Me.ComboBoxSetup_DigitalSignatureFontSize.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSetup_DigitalSignatureFontSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSetup_DigitalSignatureFontSize.AutoFindItemInDataSource = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.BookmarkingEnabled = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.ClientCode = ""
            Me.ComboBoxSetup_DigitalSignatureFontSize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.FontSize
            Me.ComboBoxSetup_DigitalSignatureFontSize.DisableMouseWheel = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.DisplayMember = "FontSize"
            Me.ComboBoxSetup_DigitalSignatureFontSize.DisplayName = ""
            Me.ComboBoxSetup_DigitalSignatureFontSize.DivisionCode = ""
            Me.ComboBoxSetup_DigitalSignatureFontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSetup_DigitalSignatureFontSize.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSetup_DigitalSignatureFontSize.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSetup_DigitalSignatureFontSize.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSetup_DigitalSignatureFontSize.FocusHighlightEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFontSize.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSetup_DigitalSignatureFontSize.FormattingEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFontSize.ItemHeight = 16
            Me.ComboBoxSetup_DigitalSignatureFontSize.Location = New System.Drawing.Point(1240, 754)
            Me.ComboBoxSetup_DigitalSignatureFontSize.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxSetup_DigitalSignatureFontSize.Name = "ComboBoxSetup_DigitalSignatureFontSize"
            Me.ComboBoxSetup_DigitalSignatureFontSize.ReadOnly = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.SecurityEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFontSize.Size = New System.Drawing.Size(340, 22)
            Me.ComboBoxSetup_DigitalSignatureFontSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSetup_DigitalSignatureFontSize.TabIndex = 47
            Me.ComboBoxSetup_DigitalSignatureFontSize.TabOnEnter = True
            Me.ComboBoxSetup_DigitalSignatureFontSize.ValueMember = "FontSize"
            Me.ComboBoxSetup_DigitalSignatureFontSize.Visible = False
            Me.ComboBoxSetup_DigitalSignatureFontSize.WatermarkText = "Select Font Size"
            '
            'LabelSetup_DigitalSignatureFontSize
            '
            Me.LabelSetup_DigitalSignatureFontSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_DigitalSignatureFontSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_DigitalSignatureFontSize.Location = New System.Drawing.Point(792, 756)
            Me.LabelSetup_DigitalSignatureFontSize.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_DigitalSignatureFontSize.Name = "LabelSetup_DigitalSignatureFontSize"
            Me.LabelSetup_DigitalSignatureFontSize.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_DigitalSignatureFontSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_DigitalSignatureFontSize.TabIndex = 46
            Me.LabelSetup_DigitalSignatureFontSize.Text = "Font Size:"
            Me.LabelSetup_DigitalSignatureFontSize.Visible = False
            '
            'ComboBoxSetup_DigitalSignatureFont
            '
            Me.ComboBoxSetup_DigitalSignatureFont.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSetup_DigitalSignatureFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSetup_DigitalSignatureFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSetup_DigitalSignatureFont.AutoFindItemInDataSource = False
            Me.ComboBoxSetup_DigitalSignatureFont.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSetup_DigitalSignatureFont.BookmarkingEnabled = False
            Me.ComboBoxSetup_DigitalSignatureFont.ClientCode = ""
            Me.ComboBoxSetup_DigitalSignatureFont.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxSetup_DigitalSignatureFont.DisableMouseWheel = False
            Me.ComboBoxSetup_DigitalSignatureFont.DisplayMember = "Description"
            Me.ComboBoxSetup_DigitalSignatureFont.DisplayName = ""
            Me.ComboBoxSetup_DigitalSignatureFont.DivisionCode = ""
            Me.ComboBoxSetup_DigitalSignatureFont.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSetup_DigitalSignatureFont.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSetup_DigitalSignatureFont.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxSetup_DigitalSignatureFont.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSetup_DigitalSignatureFont.FocusHighlightEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFont.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxSetup_DigitalSignatureFont.FormattingEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFont.ItemHeight = 16
            Me.ComboBoxSetup_DigitalSignatureFont.Location = New System.Drawing.Point(419, 754)
            Me.ComboBoxSetup_DigitalSignatureFont.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxSetup_DigitalSignatureFont.Name = "ComboBoxSetup_DigitalSignatureFont"
            Me.ComboBoxSetup_DigitalSignatureFont.ReadOnly = False
            Me.ComboBoxSetup_DigitalSignatureFont.SecurityEnabled = True
            Me.ComboBoxSetup_DigitalSignatureFont.Size = New System.Drawing.Size(351, 22)
            Me.ComboBoxSetup_DigitalSignatureFont.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSetup_DigitalSignatureFont.TabIndex = 45
            Me.ComboBoxSetup_DigitalSignatureFont.TabOnEnter = True
            Me.ComboBoxSetup_DigitalSignatureFont.ValueMember = "Code"
            Me.ComboBoxSetup_DigitalSignatureFont.Visible = False
            Me.ComboBoxSetup_DigitalSignatureFont.WatermarkText = "Select"
            '
            'LabelSetup_DigitalSignatureFont
            '
            Me.LabelSetup_DigitalSignatureFont.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_DigitalSignatureFont.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_DigitalSignatureFont.Location = New System.Drawing.Point(16, 756)
            Me.LabelSetup_DigitalSignatureFont.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_DigitalSignatureFont.Name = "LabelSetup_DigitalSignatureFont"
            Me.LabelSetup_DigitalSignatureFont.Size = New System.Drawing.Size(387, 48)
            Me.LabelSetup_DigitalSignatureFont.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_DigitalSignatureFont.TabIndex = 44
            Me.LabelSetup_DigitalSignatureFont.Text = "Font:"
            Me.LabelSetup_DigitalSignatureFont.Visible = False
            '
            'TextBoxSetup_DigitalSignatureText
            '
            Me.TextBoxSetup_DigitalSignatureText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_DigitalSignatureText.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_DigitalSignatureText.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_DigitalSignatureText.CheckSpellingOnValidate = False
            Me.TextBoxSetup_DigitalSignatureText.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_DigitalSignatureText.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_DigitalSignatureText.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_DigitalSignatureText.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_DigitalSignatureText.FocusHighlightEnabled = True
            Me.TextBoxSetup_DigitalSignatureText.Location = New System.Drawing.Point(1240, 694)
            Me.TextBoxSetup_DigitalSignatureText.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_DigitalSignatureText.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_DigitalSignatureText.Name = "TextBoxSetup_DigitalSignatureText"
            Me.TextBoxSetup_DigitalSignatureText.SecurityEnabled = True
            Me.TextBoxSetup_DigitalSignatureText.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_DigitalSignatureText.Size = New System.Drawing.Size(627, 38)
            Me.TextBoxSetup_DigitalSignatureText.StartingFolderName = Nothing
            Me.TextBoxSetup_DigitalSignatureText.TabIndex = 43
            Me.TextBoxSetup_DigitalSignatureText.TabOnEnter = True
            Me.TextBoxSetup_DigitalSignatureText.Visible = False
            '
            'LabelSetup_DigitalSignatureText
            '
            Me.LabelSetup_DigitalSignatureText.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_DigitalSignatureText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_DigitalSignatureText.Location = New System.Drawing.Point(792, 694)
            Me.LabelSetup_DigitalSignatureText.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_DigitalSignatureText.Name = "LabelSetup_DigitalSignatureText"
            Me.LabelSetup_DigitalSignatureText.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_DigitalSignatureText.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_DigitalSignatureText.TabIndex = 42
            Me.LabelSetup_DigitalSignatureText.Text = "Signature:"
            Me.LabelSetup_DigitalSignatureText.Visible = False
            '
            'CheckBoxSetup_DigitalSignatureActive
            '
            Me.CheckBoxSetup_DigitalSignatureActive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSetup_DigitalSignatureActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSetup_DigitalSignatureActive.CheckValue = 0
            Me.CheckBoxSetup_DigitalSignatureActive.CheckValueChecked = 1
            Me.CheckBoxSetup_DigitalSignatureActive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSetup_DigitalSignatureActive.CheckValueUnchecked = 0
            Me.CheckBoxSetup_DigitalSignatureActive.ChildControls = CType(resources.GetObject("CheckBoxSetup_DigitalSignatureActive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_DigitalSignatureActive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSetup_DigitalSignatureActive.Location = New System.Drawing.Point(16, 694)
            Me.CheckBoxSetup_DigitalSignatureActive.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxSetup_DigitalSignatureActive.Name = "CheckBoxSetup_DigitalSignatureActive"
            Me.CheckBoxSetup_DigitalSignatureActive.OldestSibling = Nothing
            Me.CheckBoxSetup_DigitalSignatureActive.SecurityEnabled = True
            Me.CheckBoxSetup_DigitalSignatureActive.SiblingControls = CType(resources.GetObject("CheckBoxSetup_DigitalSignatureActive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_DigitalSignatureActive.Size = New System.Drawing.Size(760, 48)
            Me.CheckBoxSetup_DigitalSignatureActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSetup_DigitalSignatureActive.TabIndex = 41
            Me.CheckBoxSetup_DigitalSignatureActive.TabOnEnter = True
            Me.CheckBoxSetup_DigitalSignatureActive.Text = "Active"
            Me.CheckBoxSetup_DigitalSignatureActive.Visible = False
            '
            'LabelSetup_DigitalSignature
            '
            Me.LabelSetup_DigitalSignature.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_DigitalSignature.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_DigitalSignature.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_DigitalSignature.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_DigitalSignature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSetup_DigitalSignature.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSetup_DigitalSignature.Location = New System.Drawing.Point(16, 632)
            Me.LabelSetup_DigitalSignature.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_DigitalSignature.Name = "LabelSetup_DigitalSignature"
            Me.LabelSetup_DigitalSignature.Size = New System.Drawing.Size(1851, 48)
            Me.LabelSetup_DigitalSignature.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_DigitalSignature.TabIndex = 40
            Me.LabelSetup_DigitalSignature.Text = "Digital Signature"
            Me.LabelSetup_DigitalSignature.Visible = False
            '
            'ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown
            '
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoFindItemInDataSource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.BookmarkingEnabled = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ClientCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisableMouseWheel = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisplayMember = "Description"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DisplayName = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DivisionCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FocusHighlightEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.FormattingEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ItemHeight = 16
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Location = New System.Drawing.Point(1240, 570)
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Name = "ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ReadOnly = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.SecurityEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Size = New System.Drawing.Size(340, 22)
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.TabIndex = 39
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.TabOnEnter = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.ValueMember = "Code"
            Me.ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown.WatermarkText = "Select"
            '
            'ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp
            '
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoFindItemInDataSource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.BookmarkingEnabled = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ClientCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisableMouseWheel = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisplayMember = "Description"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DisplayName = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DivisionCode = ""
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FocusHighlightEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.FormattingEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ItemHeight = 16
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Location = New System.Drawing.Point(1240, 510)
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Name = "ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ReadOnly = False
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.SecurityEnabled = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Size = New System.Drawing.Size(340, 22)
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.TabIndex = 37
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.TabOnEnter = True
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.ValueMember = "Code"
            Me.ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp.WatermarkText = "Select"
            '
            'LabelCheckFormatSettings_AdjustCheckBodyLinesDown
            '
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Location = New System.Drawing.Point(792, 572)
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Name = "LabelCheckFormatSettings_AdjustCheckBodyLinesDown"
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Size = New System.Drawing.Size(432, 48)
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.TabIndex = 38
            Me.LabelCheckFormatSettings_AdjustCheckBodyLinesDown.Text = "Adjust Check Body Lines Down:"
            '
            'LabelCheckFormatSettings_AdjustCheckStubLinesUp
            '
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Location = New System.Drawing.Point(792, 510)
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Name = "LabelCheckFormatSettings_AdjustCheckStubLinesUp"
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Size = New System.Drawing.Size(432, 48)
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.TabIndex = 36
            Me.LabelCheckFormatSettings_AdjustCheckStubLinesUp.Text = "Adjust Check Stub Lines Up:"
            '
            'SearchableComboBoxSetup_APComputerCheckFormat
            '
            Me.SearchableComboBoxSetup_APComputerCheckFormat.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_APComputerCheckFormat.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_APComputerCheckFormat.AutoFillMode = False
            Me.SearchableComboBoxSetup_APComputerCheckFormat.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_APComputerCheckFormat.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CheckFormat
            Me.SearchableComboBoxSetup_APComputerCheckFormat.DataSource = Nothing
            Me.SearchableComboBoxSetup_APComputerCheckFormat.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_APComputerCheckFormat.DisplayName = ""
            Me.SearchableComboBoxSetup_APComputerCheckFormat.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_APComputerCheckFormat.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Location = New System.Drawing.Point(1240, 448)
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Name = "SearchableComboBoxSetup_APComputerCheckFormat"
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties.NullText = "Select Check Format"
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties.ValueMember = "Number"
            Me.SearchableComboBoxSetup_APComputerCheckFormat.SecurityEnabled = True
            Me.SearchableComboBoxSetup_APComputerCheckFormat.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_APComputerCheckFormat.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_APComputerCheckFormat.TabIndex = 35
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.DetailHeight = 835
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FixedLineWidth = 5
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView6.RunStandardValidation = True
            Me.GridView6.SkipAddingControlsOnModifyColumn = False
            Me.GridView6.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_InterestEarnedGLAccount
            '
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.AutoFillMode = False
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.DataSource = Nothing
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.DisplayName = ""
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Location = New System.Drawing.Point(1240, 386)
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Name = "SearchableComboBoxSetup_InterestEarnedGLAccount"
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.SecurityEnabled = True
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_InterestEarnedGLAccount.TabIndex = 33
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.DetailHeight = 835
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FixedLineWidth = 5
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView5.RunStandardValidation = True
            Me.GridView5.SkipAddingControlsOnModifyColumn = False
            Me.GridView5.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_ServiceChargeGLAccount
            '
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.AutoFillMode = False
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.DataSource = Nothing
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.DisplayName = ""
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Location = New System.Drawing.Point(1240, 324)
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Name = "SearchableComboBoxSetup_ServiceChargeGLAccount"
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.SecurityEnabled = True
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_ServiceChargeGLAccount.TabIndex = 31
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.DetailHeight = 835
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FixedLineWidth = 5
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            Me.GridView4.SkipAddingControlsOnModifyColumn = False
            Me.GridView4.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_APDiscAccount
            '
            Me.SearchableComboBoxSetup_APDiscAccount.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_APDiscAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_APDiscAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_APDiscAccount.AutoFillMode = False
            Me.SearchableComboBoxSetup_APDiscAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_APDiscAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSetup_APDiscAccount.DataSource = Nothing
            Me.SearchableComboBoxSetup_APDiscAccount.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_APDiscAccount.DisplayName = ""
            Me.SearchableComboBoxSetup_APDiscAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_APDiscAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_APDiscAccount.Location = New System.Drawing.Point(1240, 262)
            Me.SearchableComboBoxSetup_APDiscAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_APDiscAccount.Name = "SearchableComboBoxSetup_APDiscAccount"
            Me.SearchableComboBoxSetup_APDiscAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_APDiscAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_APDiscAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxSetup_APDiscAccount.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxSetup_APDiscAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_APDiscAccount.SecurityEnabled = True
            Me.SearchableComboBoxSetup_APDiscAccount.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_APDiscAccount.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_APDiscAccount.TabIndex = 29
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.DetailHeight = 835
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FixedLineWidth = 5
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            Me.GridView3.SkipAddingControlsOnModifyColumn = False
            Me.GridView3.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_APCashAccount
            '
            Me.SearchableComboBoxSetup_APCashAccount.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_APCashAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_APCashAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_APCashAccount.AutoFillMode = False
            Me.SearchableComboBoxSetup_APCashAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_APCashAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSetup_APCashAccount.DataSource = Nothing
            Me.SearchableComboBoxSetup_APCashAccount.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_APCashAccount.DisplayName = ""
            Me.SearchableComboBoxSetup_APCashAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_APCashAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_APCashAccount.Location = New System.Drawing.Point(1240, 200)
            Me.SearchableComboBoxSetup_APCashAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_APCashAccount.Name = "SearchableComboBoxSetup_APCashAccount"
            Me.SearchableComboBoxSetup_APCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_APCashAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_APCashAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxSetup_APCashAccount.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxSetup_APCashAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_APCashAccount.SecurityEnabled = True
            Me.SearchableComboBoxSetup_APCashAccount.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_APCashAccount.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_APCashAccount.TabIndex = 27
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.DetailHeight = 835
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FixedLineWidth = 5
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_ARCashAccount
            '
            Me.SearchableComboBoxSetup_ARCashAccount.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_ARCashAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_ARCashAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_ARCashAccount.AutoFillMode = False
            Me.SearchableComboBoxSetup_ARCashAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_ARCashAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSetup_ARCashAccount.DataSource = Nothing
            Me.SearchableComboBoxSetup_ARCashAccount.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_ARCashAccount.DisplayName = ""
            Me.SearchableComboBoxSetup_ARCashAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_ARCashAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_ARCashAccount.Location = New System.Drawing.Point(1240, 138)
            Me.SearchableComboBoxSetup_ARCashAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_ARCashAccount.Name = "SearchableComboBoxSetup_ARCashAccount"
            Me.SearchableComboBoxSetup_ARCashAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_ARCashAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_ARCashAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxSetup_ARCashAccount.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxSetup_ARCashAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_ARCashAccount.SecurityEnabled = True
            Me.SearchableComboBoxSetup_ARCashAccount.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_ARCashAccount.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_ARCashAccount.TabIndex = 25
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.DetailHeight = 835
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FixedLineWidth = 5
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSetup_Office
            '
            Me.SearchableComboBoxSetup_Office.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_Office.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_Office.AutoFillMode = False
            Me.SearchableComboBoxSetup_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxSetup_Office.DataSource = Nothing
            Me.SearchableComboBoxSetup_Office.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_Office.DisplayName = ""
            Me.SearchableComboBoxSetup_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_Office.Location = New System.Drawing.Point(1240, 76)
            Me.SearchableComboBoxSetup_Office.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.SearchableComboBoxSetup_Office.Name = "SearchableComboBoxSetup_Office"
            Me.SearchableComboBoxSetup_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSetup_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxSetup_Office.Properties.PopupView = Me.SearchableComboBox1View
            Me.SearchableComboBoxSetup_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_Office.SecurityEnabled = True
            Me.SearchableComboBoxSetup_Office.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_Office.Size = New System.Drawing.Size(627, 48)
            Me.SearchableComboBoxSetup_Office.TabIndex = 23
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.AFActiveFilterString = ""
            Me.SearchableComboBox1View.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1View.AutoFilterLookupColumns = False
            Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1View.DataSourceClearing = False
            Me.SearchableComboBox1View.DetailHeight = 835
            Me.SearchableComboBox1View.EnableDisabledRows = False
            Me.SearchableComboBox1View.FixedLineWidth = 5
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1View.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBox1View.RunStandardValidation = True
            Me.SearchableComboBox1View.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBox1View.SkipSettingFontOnModifyColumn = False
            '
            'CheckBoxSetup_PaymentManager
            '
            Me.CheckBoxSetup_PaymentManager.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxSetup_PaymentManager.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSetup_PaymentManager.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSetup_PaymentManager.CheckValue = 0
            Me.CheckBoxSetup_PaymentManager.CheckValueChecked = 1
            Me.CheckBoxSetup_PaymentManager.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSetup_PaymentManager.CheckValueUnchecked = 0
            Me.CheckBoxSetup_PaymentManager.ChildControls = CType(resources.GetObject("CheckBoxSetup_PaymentManager.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_PaymentManager.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSetup_PaymentManager.Location = New System.Drawing.Point(1560, 14)
            Me.CheckBoxSetup_PaymentManager.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxSetup_PaymentManager.Name = "CheckBoxSetup_PaymentManager"
            Me.CheckBoxSetup_PaymentManager.OldestSibling = Nothing
            Me.CheckBoxSetup_PaymentManager.SecurityEnabled = True
            Me.CheckBoxSetup_PaymentManager.SiblingControls = CType(resources.GetObject("CheckBoxSetup_PaymentManager.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_PaymentManager.Size = New System.Drawing.Size(307, 48)
            Me.CheckBoxSetup_PaymentManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSetup_PaymentManager.TabIndex = 5
            Me.CheckBoxSetup_PaymentManager.TabOnEnter = True
            Me.CheckBoxSetup_PaymentManager.Text = "Payment Manager"
            '
            'CheckBoxSetup_Inactive
            '
            Me.CheckBoxSetup_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxSetup_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSetup_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSetup_Inactive.CheckValue = 0
            Me.CheckBoxSetup_Inactive.CheckValueChecked = 1
            Me.CheckBoxSetup_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSetup_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxSetup_Inactive.ChildControls = CType(resources.GetObject("CheckBoxSetup_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSetup_Inactive.Location = New System.Drawing.Point(1320, 14)
            Me.CheckBoxSetup_Inactive.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.CheckBoxSetup_Inactive.Name = "CheckBoxSetup_Inactive"
            Me.CheckBoxSetup_Inactive.OldestSibling = Nothing
            Me.CheckBoxSetup_Inactive.SecurityEnabled = True
            Me.CheckBoxSetup_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxSetup_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_Inactive.Size = New System.Drawing.Size(224, 48)
            Me.CheckBoxSetup_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSetup_Inactive.TabIndex = 4
            Me.CheckBoxSetup_Inactive.TabOnEnter = True
            Me.CheckBoxSetup_Inactive.Text = "Inactive"
            '
            'ComboBoxSetup_CheckAmountInWords
            '
            Me.ComboBoxSetup_CheckAmountInWords.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSetup_CheckAmountInWords.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSetup_CheckAmountInWords.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSetup_CheckAmountInWords.AutoFindItemInDataSource = False
            Me.ComboBoxSetup_CheckAmountInWords.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSetup_CheckAmountInWords.BookmarkingEnabled = False
            Me.ComboBoxSetup_CheckAmountInWords.ClientCode = ""
            Me.ComboBoxSetup_CheckAmountInWords.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Yes1No0
            Me.ComboBoxSetup_CheckAmountInWords.DisableMouseWheel = False
            Me.ComboBoxSetup_CheckAmountInWords.DisplayMember = "Description"
            Me.ComboBoxSetup_CheckAmountInWords.DisplayName = ""
            Me.ComboBoxSetup_CheckAmountInWords.DivisionCode = ""
            Me.ComboBoxSetup_CheckAmountInWords.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSetup_CheckAmountInWords.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxSetup_CheckAmountInWords.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.AgencyDefault
            Me.ComboBoxSetup_CheckAmountInWords.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSetup_CheckAmountInWords.FocusHighlightEnabled = True
            Me.ComboBoxSetup_CheckAmountInWords.FormattingEnabled = True
            Me.ComboBoxSetup_CheckAmountInWords.ItemHeight = 14
            Me.ComboBoxSetup_CheckAmountInWords.Location = New System.Drawing.Point(421, 448)
            Me.ComboBoxSetup_CheckAmountInWords.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.ComboBoxSetup_CheckAmountInWords.Name = "ComboBoxSetup_CheckAmountInWords"
            Me.ComboBoxSetup_CheckAmountInWords.ReadOnly = False
            Me.ComboBoxSetup_CheckAmountInWords.SecurityEnabled = True
            Me.ComboBoxSetup_CheckAmountInWords.Size = New System.Drawing.Size(348, 20)
            Me.ComboBoxSetup_CheckAmountInWords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSetup_CheckAmountInWords.TabIndex = 19
            Me.ComboBoxSetup_CheckAmountInWords.TabOnEnter = True
            Me.ComboBoxSetup_CheckAmountInWords.ValueMember = "Code"
            Me.ComboBoxSetup_CheckAmountInWords.WatermarkText = "Select"
            '
            'NumericInputSetup_LastComputerCheckIssued
            '
            Me.NumericInputSetup_LastComputerCheckIssued.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSetup_LastComputerCheckIssued.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSetup_LastComputerCheckIssued.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSetup_LastComputerCheckIssued.EnterMoveNextControl = True
            Me.NumericInputSetup_LastComputerCheckIssued.Location = New System.Drawing.Point(421, 386)
            Me.NumericInputSetup_LastComputerCheckIssued.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputSetup_LastComputerCheckIssued.Name = "NumericInputSetup_LastComputerCheckIssued"
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.IsFloatValue = False
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.Mask.EditMask = "n0"
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputSetup_LastComputerCheckIssued.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSetup_LastComputerCheckIssued.SecurityEnabled = True
            Me.NumericInputSetup_LastComputerCheckIssued.Size = New System.Drawing.Size(355, 48)
            Me.NumericInputSetup_LastComputerCheckIssued.TabIndex = 17
            '
            'NumericInputSetup_LastManualCheckIssued
            '
            Me.NumericInputSetup_LastManualCheckIssued.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSetup_LastManualCheckIssued.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSetup_LastManualCheckIssued.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSetup_LastManualCheckIssued.EnterMoveNextControl = True
            Me.NumericInputSetup_LastManualCheckIssued.Location = New System.Drawing.Point(421, 324)
            Me.NumericInputSetup_LastManualCheckIssued.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputSetup_LastManualCheckIssued.Name = "NumericInputSetup_LastManualCheckIssued"
            Me.NumericInputSetup_LastManualCheckIssued.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputSetup_LastManualCheckIssued.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputSetup_LastManualCheckIssued.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputSetup_LastManualCheckIssued.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_LastManualCheckIssued.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputSetup_LastManualCheckIssued.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_LastManualCheckIssued.Properties.IsFloatValue = False
            Me.NumericInputSetup_LastManualCheckIssued.Properties.Mask.EditMask = "n0"
            Me.NumericInputSetup_LastManualCheckIssued.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSetup_LastManualCheckIssued.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputSetup_LastManualCheckIssued.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSetup_LastManualCheckIssued.SecurityEnabled = True
            Me.NumericInputSetup_LastManualCheckIssued.Size = New System.Drawing.Size(355, 48)
            Me.NumericInputSetup_LastManualCheckIssued.TabIndex = 15
            '
            'NumericInputSetup_CheckTemplateID
            '
            Me.NumericInputSetup_CheckTemplateID.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSetup_CheckTemplateID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSetup_CheckTemplateID.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSetup_CheckTemplateID.EnterMoveNextControl = True
            Me.NumericInputSetup_CheckTemplateID.Location = New System.Drawing.Point(421, 510)
            Me.NumericInputSetup_CheckTemplateID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputSetup_CheckTemplateID.Name = "NumericInputSetup_CheckTemplateID"
            Me.NumericInputSetup_CheckTemplateID.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputSetup_CheckTemplateID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_CheckTemplateID.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputSetup_CheckTemplateID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_CheckTemplateID.Properties.IsFloatValue = False
            Me.NumericInputSetup_CheckTemplateID.Properties.Mask.EditMask = "n0"
            Me.NumericInputSetup_CheckTemplateID.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSetup_CheckTemplateID.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputSetup_CheckTemplateID.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSetup_CheckTemplateID.SecurityEnabled = True
            Me.NumericInputSetup_CheckTemplateID.Size = New System.Drawing.Size(355, 48)
            Me.NumericInputSetup_CheckTemplateID.TabIndex = 21
            '
            'NumericInputSetup_RoutingNumber
            '
            Me.NumericInputSetup_RoutingNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputSetup_RoutingNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputSetup_RoutingNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputSetup_RoutingNumber.EnterMoveNextControl = True
            Me.NumericInputSetup_RoutingNumber.Location = New System.Drawing.Point(421, 138)
            Me.NumericInputSetup_RoutingNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.NumericInputSetup_RoutingNumber.Name = "NumericInputSetup_RoutingNumber"
            Me.NumericInputSetup_RoutingNumber.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputSetup_RoutingNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputSetup_RoutingNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputSetup_RoutingNumber.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputSetup_RoutingNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_RoutingNumber.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputSetup_RoutingNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputSetup_RoutingNumber.Properties.IsFloatValue = False
            Me.NumericInputSetup_RoutingNumber.Properties.Mask.EditMask = "n0"
            Me.NumericInputSetup_RoutingNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputSetup_RoutingNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputSetup_RoutingNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputSetup_RoutingNumber.SecurityEnabled = True
            Me.NumericInputSetup_RoutingNumber.Size = New System.Drawing.Size(355, 48)
            Me.NumericInputSetup_RoutingNumber.TabIndex = 9
            '
            'TextBoxSetup_Name
            '
            Me.TextBoxSetup_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Name.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Name.FocusHighlightEnabled = True
            Me.TextBoxSetup_Name.Location = New System.Drawing.Point(488, 14)
            Me.TextBoxSetup_Name.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Name.Name = "TextBoxSetup_Name"
            Me.TextBoxSetup_Name.SecurityEnabled = True
            Me.TextBoxSetup_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Name.Size = New System.Drawing.Size(816, 38)
            Me.TextBoxSetup_Name.StartingFolderName = Nothing
            Me.TextBoxSetup_Name.TabIndex = 3
            Me.TextBoxSetup_Name.TabOnEnter = True
            '
            'LabelSetup_Name
            '
            Me.LabelSetup_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Name.Location = New System.Drawing.Point(360, 14)
            Me.LabelSetup_Name.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_Name.Name = "LabelSetup_Name"
            Me.LabelSetup_Name.Size = New System.Drawing.Size(112, 48)
            Me.LabelSetup_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Name.TabIndex = 2
            Me.LabelSetup_Name.Text = "Name:"
            '
            'TextBoxSetup_Code
            '
            '
            '
            '
            Me.TextBoxSetup_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Code.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Code.FocusHighlightEnabled = True
            Me.TextBoxSetup_Code.Location = New System.Drawing.Point(144, 14)
            Me.TextBoxSetup_Code.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Code.Name = "TextBoxSetup_Code"
            Me.TextBoxSetup_Code.SecurityEnabled = True
            Me.TextBoxSetup_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Code.Size = New System.Drawing.Size(200, 38)
            Me.TextBoxSetup_Code.StartingFolderName = Nothing
            Me.TextBoxSetup_Code.TabIndex = 1
            Me.TextBoxSetup_Code.TabOnEnter = True
            '
            'LabelSetup_Code
            '
            Me.LabelSetup_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Code.Location = New System.Drawing.Point(16, 14)
            Me.LabelSetup_Code.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_Code.Name = "LabelSetup_Code"
            Me.LabelSetup_Code.Size = New System.Drawing.Size(112, 48)
            Me.LabelSetup_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Code.TabIndex = 0
            Me.LabelSetup_Code.Text = "Code:"
            '
            'TextBoxSetup_BankID
            '
            '
            '
            '
            Me.TextBoxSetup_BankID.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_BankID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_BankID.CheckSpellingOnValidate = False
            Me.TextBoxSetup_BankID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_BankID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_BankID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_BankID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_BankID.FocusHighlightEnabled = True
            Me.TextBoxSetup_BankID.Location = New System.Drawing.Point(421, 262)
            Me.TextBoxSetup_BankID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_BankID.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_BankID.Name = "TextBoxSetup_BankID"
            Me.TextBoxSetup_BankID.SecurityEnabled = True
            Me.TextBoxSetup_BankID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_BankID.Size = New System.Drawing.Size(355, 38)
            Me.TextBoxSetup_BankID.StartingFolderName = Nothing
            Me.TextBoxSetup_BankID.TabIndex = 13
            Me.TextBoxSetup_BankID.TabOnEnter = True
            Me.TextBoxSetup_BankID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'TextBoxSetup_ACHCompanyID
            '
            '
            '
            '
            Me.TextBoxSetup_ACHCompanyID.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_ACHCompanyID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_ACHCompanyID.CheckSpellingOnValidate = False
            Me.TextBoxSetup_ACHCompanyID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_ACHCompanyID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_ACHCompanyID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_ACHCompanyID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_ACHCompanyID.FocusHighlightEnabled = True
            Me.TextBoxSetup_ACHCompanyID.Location = New System.Drawing.Point(421, 200)
            Me.TextBoxSetup_ACHCompanyID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_ACHCompanyID.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_ACHCompanyID.Name = "TextBoxSetup_ACHCompanyID"
            Me.TextBoxSetup_ACHCompanyID.SecurityEnabled = True
            Me.TextBoxSetup_ACHCompanyID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_ACHCompanyID.Size = New System.Drawing.Size(355, 38)
            Me.TextBoxSetup_ACHCompanyID.StartingFolderName = Nothing
            Me.TextBoxSetup_ACHCompanyID.TabIndex = 11
            Me.TextBoxSetup_ACHCompanyID.TabOnEnter = True
            Me.TextBoxSetup_ACHCompanyID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'TextBoxSetup_AccountNumber
            '
            '
            '
            '
            Me.TextBoxSetup_AccountNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_AccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_AccountNumber.CheckSpellingOnValidate = False
            Me.TextBoxSetup_AccountNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_AccountNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_AccountNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_AccountNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_AccountNumber.FocusHighlightEnabled = True
            Me.TextBoxSetup_AccountNumber.Location = New System.Drawing.Point(421, 76)
            Me.TextBoxSetup_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.TextBoxSetup_AccountNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_AccountNumber.Name = "TextBoxSetup_AccountNumber"
            Me.TextBoxSetup_AccountNumber.SecurityEnabled = True
            Me.TextBoxSetup_AccountNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_AccountNumber.Size = New System.Drawing.Size(355, 38)
            Me.TextBoxSetup_AccountNumber.StartingFolderName = Nothing
            Me.TextBoxSetup_AccountNumber.TabIndex = 7
            Me.TextBoxSetup_AccountNumber.TabOnEnter = True
            Me.TextBoxSetup_AccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'LabelSetup_CheckTemplateID
            '
            Me.LabelSetup_CheckTemplateID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_CheckTemplateID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_CheckTemplateID.Location = New System.Drawing.Point(16, 510)
            Me.LabelSetup_CheckTemplateID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_CheckTemplateID.Name = "LabelSetup_CheckTemplateID"
            Me.LabelSetup_CheckTemplateID.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_CheckTemplateID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_CheckTemplateID.TabIndex = 20
            Me.LabelSetup_CheckTemplateID.Text = "Check Template ID:"
            '
            'LabelSetup_CheckAmountInWords
            '
            Me.LabelSetup_CheckAmountInWords.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_CheckAmountInWords.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_CheckAmountInWords.Location = New System.Drawing.Point(16, 448)
            Me.LabelSetup_CheckAmountInWords.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_CheckAmountInWords.Name = "LabelSetup_CheckAmountInWords"
            Me.LabelSetup_CheckAmountInWords.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_CheckAmountInWords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_CheckAmountInWords.TabIndex = 18
            Me.LabelSetup_CheckAmountInWords.Text = "Check Amount in Words:"
            '
            'LabelSetup_APComputerCheckFormat
            '
            Me.LabelSetup_APComputerCheckFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_APComputerCheckFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_APComputerCheckFormat.Location = New System.Drawing.Point(792, 448)
            Me.LabelSetup_APComputerCheckFormat.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_APComputerCheckFormat.Name = "LabelSetup_APComputerCheckFormat"
            Me.LabelSetup_APComputerCheckFormat.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_APComputerCheckFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_APComputerCheckFormat.TabIndex = 34
            Me.LabelSetup_APComputerCheckFormat.Text = "A/P Computer Check Format:"
            '
            'LabelSetup_InterestEarnedGLAccount
            '
            Me.LabelSetup_InterestEarnedGLAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_InterestEarnedGLAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_InterestEarnedGLAccount.Location = New System.Drawing.Point(792, 384)
            Me.LabelSetup_InterestEarnedGLAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_InterestEarnedGLAccount.Name = "LabelSetup_InterestEarnedGLAccount"
            Me.LabelSetup_InterestEarnedGLAccount.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_InterestEarnedGLAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_InterestEarnedGLAccount.TabIndex = 32
            Me.LabelSetup_InterestEarnedGLAccount.Text = "Interest Earned GL Account:"
            '
            'LabelSetup_ServiceChargeGLAccount
            '
            Me.LabelSetup_ServiceChargeGLAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_ServiceChargeGLAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_ServiceChargeGLAccount.Location = New System.Drawing.Point(792, 324)
            Me.LabelSetup_ServiceChargeGLAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_ServiceChargeGLAccount.Name = "LabelSetup_ServiceChargeGLAccount"
            Me.LabelSetup_ServiceChargeGLAccount.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_ServiceChargeGLAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_ServiceChargeGLAccount.TabIndex = 30
            Me.LabelSetup_ServiceChargeGLAccount.Text = "Service Charge GL Account:"
            '
            'LabelSetup_APDiscAccount
            '
            Me.LabelSetup_APDiscAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_APDiscAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_APDiscAccount.Location = New System.Drawing.Point(792, 262)
            Me.LabelSetup_APDiscAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_APDiscAccount.Name = "LabelSetup_APDiscAccount"
            Me.LabelSetup_APDiscAccount.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_APDiscAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_APDiscAccount.TabIndex = 28
            Me.LabelSetup_APDiscAccount.Text = "A/P Disc Account:"
            '
            'LabelSetup_APCashAccount
            '
            Me.LabelSetup_APCashAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_APCashAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_APCashAccount.Location = New System.Drawing.Point(792, 200)
            Me.LabelSetup_APCashAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_APCashAccount.Name = "LabelSetup_APCashAccount"
            Me.LabelSetup_APCashAccount.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_APCashAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_APCashAccount.TabIndex = 26
            Me.LabelSetup_APCashAccount.Text = "A/P Cash Account:"
            '
            'LabelSetup_ARCashAccount
            '
            Me.LabelSetup_ARCashAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_ARCashAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_ARCashAccount.Location = New System.Drawing.Point(792, 138)
            Me.LabelSetup_ARCashAccount.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_ARCashAccount.Name = "LabelSetup_ARCashAccount"
            Me.LabelSetup_ARCashAccount.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_ARCashAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_ARCashAccount.TabIndex = 24
            Me.LabelSetup_ARCashAccount.Text = "A/R Cash Account:"
            '
            'LabelSetup_Office
            '
            Me.LabelSetup_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Office.Location = New System.Drawing.Point(792, 76)
            Me.LabelSetup_Office.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_Office.Name = "LabelSetup_Office"
            Me.LabelSetup_Office.Size = New System.Drawing.Size(432, 48)
            Me.LabelSetup_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Office.TabIndex = 22
            Me.LabelSetup_Office.Text = "Office:"
            '
            'LabelSetup_LastComputerCheckIssued
            '
            Me.LabelSetup_LastComputerCheckIssued.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_LastComputerCheckIssued.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_LastComputerCheckIssued.Location = New System.Drawing.Point(16, 386)
            Me.LabelSetup_LastComputerCheckIssued.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_LastComputerCheckIssued.Name = "LabelSetup_LastComputerCheckIssued"
            Me.LabelSetup_LastComputerCheckIssued.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_LastComputerCheckIssued.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_LastComputerCheckIssued.TabIndex = 16
            Me.LabelSetup_LastComputerCheckIssued.Text = "Last Computer Check Issued:"
            '
            'LabelSetup_LastManualCheckIssued
            '
            Me.LabelSetup_LastManualCheckIssued.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_LastManualCheckIssued.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_LastManualCheckIssued.Location = New System.Drawing.Point(16, 324)
            Me.LabelSetup_LastManualCheckIssued.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_LastManualCheckIssued.Name = "LabelSetup_LastManualCheckIssued"
            Me.LabelSetup_LastManualCheckIssued.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_LastManualCheckIssued.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_LastManualCheckIssued.TabIndex = 14
            Me.LabelSetup_LastManualCheckIssued.Text = "Last Manual Check Issued:"
            '
            'LabelSetup_BankID
            '
            Me.LabelSetup_BankID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_BankID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_BankID.Location = New System.Drawing.Point(16, 262)
            Me.LabelSetup_BankID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_BankID.Name = "LabelSetup_BankID"
            Me.LabelSetup_BankID.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_BankID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_BankID.TabIndex = 12
            Me.LabelSetup_BankID.Text = "Bank ID:"
            '
            'LabelSetup_ACHCompanyID
            '
            Me.LabelSetup_ACHCompanyID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_ACHCompanyID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_ACHCompanyID.Location = New System.Drawing.Point(16, 200)
            Me.LabelSetup_ACHCompanyID.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_ACHCompanyID.Name = "LabelSetup_ACHCompanyID"
            Me.LabelSetup_ACHCompanyID.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_ACHCompanyID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_ACHCompanyID.TabIndex = 10
            Me.LabelSetup_ACHCompanyID.Text = "ACH Company ID:"
            '
            'LabelSetup_RoutingNumber
            '
            Me.LabelSetup_RoutingNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_RoutingNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_RoutingNumber.Location = New System.Drawing.Point(16, 138)
            Me.LabelSetup_RoutingNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_RoutingNumber.Name = "LabelSetup_RoutingNumber"
            Me.LabelSetup_RoutingNumber.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_RoutingNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_RoutingNumber.TabIndex = 8
            Me.LabelSetup_RoutingNumber.Text = "Routing Number:"
            '
            'LabelSetup_AccountNumber
            '
            Me.LabelSetup_AccountNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_AccountNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_AccountNumber.Location = New System.Drawing.Point(16, 76)
            Me.LabelSetup_AccountNumber.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
            Me.LabelSetup_AccountNumber.Name = "LabelSetup_AccountNumber"
            Me.LabelSetup_AccountNumber.Size = New System.Drawing.Size(389, 48)
            Me.LabelSetup_AccountNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_AccountNumber.TabIndex = 6
            Me.LabelSetup_AccountNumber.Text = "Account Number:"
            '
            'TabItemBankDetails_Setup
            '
            Me.TabItemBankDetails_Setup.AttachedControl = Me.TabControlPanelSetup_Setup
            Me.TabItemBankDetails_Setup.Name = "TabItemBankDetails_Setup"
            Me.TabItemBankDetails_Setup.Text = "Setup"
            '
            'BankControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_BankDetails)
            Me.Margin = New System.Windows.Forms.Padding(21, 17, 21, 17)
            Me.Name = "BankControl"
            Me.Size = New System.Drawing.Size(1883, 1564)
            CType(Me.TabControlControl_BankDetails, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlControl_BankDetails.ResumeLayout(False)
            Me.TabControlPanelPaymentManager_PaymentManager.ResumeLayout(False)
            CType(Me.SearchableComboBoxPaymentManager_ExportType.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelCheckExport2_CheckExport2.ResumeLayout(False)
            Me.TableLayoutPanelCheckExport2_CheckExport2TableLayout.ResumeLayout(False)
            Me.PanelCheckExport2TableLayout_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxCheckExport2_TrailerRecord, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckExport2_TrailerRecord.ResumeLayout(False)
            CType(Me.NumericInputTrailerRecord_RecordCountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_RecordCountEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_RecordCountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_TotalFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_TotalFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_TotalFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_ExportAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_ExportAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_ExportAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_FileDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_FileDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_FileDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTrailerRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelCheckExport2TableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxCheckExport2_TotalRecord, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckExport2_TotalRecord.ResumeLayout(False)
            CType(Me.NumericInputTotalRecord_RecordCountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_RecordCountEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_RecordCountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_TotalFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_TotalFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_TotalFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_ExportAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_ExportAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_ExportAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_FileDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_FileDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_FileDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputTotalRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelCheckExport_CheckExport.ResumeLayout(False)
            Me.TableLayoutPanelCheckExport_CheckExportTableLayout.ResumeLayout(False)
            Me.PanelCheckExportTableLayout_RightColumn.ResumeLayout(False)
            CType(Me.GroupBoxCheckExport_DetailRecord, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckExport_DetailRecord.ResumeLayout(False)
            CType(Me.NumericInputDetailRecord_PayeeCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_PayeeEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_PayeeBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_VoidFlagCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_VoidFlagEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_VoidFlagBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckAmountEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckAmountCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckAmountBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_CheckNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler4EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler4BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler3EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler3BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_AccountNumberCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_AccountNumberEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_AccountNumberBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_BankIDEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_BankIDCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputDetailRecord_BankIDBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelCheckExportTableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.GroupBoxCheckExport_HeaderRecord, System.ComponentModel.ISupportInitialize).EndInit
            Me.GroupBoxCheckExport_HeaderRecord.ResumeLayout(False)
            CType(Me.NumericInputHeaderRecord_Filler2EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_Filler2BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_Filler1EndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_Filler1BeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_CreateDateCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_CreateDateEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_CreateDateBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_AgencyEndPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_AgencyCSVOrder.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputHeaderRecord_AgencyBeginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelCheckImport_CheckImport.ResumeLayout(False)
            Me.TableLayoutPanelCheckImport_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            CType(Me.NumericInputRightColumn_NumberOfDecimals.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputRightColumn_Length.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputRightColumn_ColumnStart.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            CType(Me.NumericInputLeftColumn_Length.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputLeftColumn_ColumnStart.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelCurrency_Currency.ResumeLayout(False)
            CType(Me.SearchableComboBoxCurrency_ExchangeRealizedAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCurrency_ExchangeUnrealizedAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxCurrency_Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView7, System.ComponentModel.ISupportInitialize).EndInit
            Me.TabControlPanelSetup_Setup.ResumeLayout(False)
            CType(Me.SearchableComboBoxSetup_APComputerCheckFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_InterestEarnedGLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_ServiceChargeGLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_APDiscAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_APCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_ARCashAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBoxSetup_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputSetup_LastComputerCheckIssued.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputSetup_LastManualCheckIssued.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputSetup_CheckTemplateID.Properties, System.ComponentModel.ISupportInitialize).EndInit
            CType(Me.NumericInputSetup_RoutingNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_BankDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSetup_Setup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBankDetails_Setup As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCurrency_Currency As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBankDetails_Currency As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelPaymentManager_PaymentManager As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBankDetails_PaymentManager As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCheckExport2_CheckExport2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBankDetails_CheckExport2 As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelCheckImport_CheckImport As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBankDetails_CheckImport As DevComponents.DotNetBar.TabItem
        Friend WithEvents TextBoxSetup_BankID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_ACHCompanyID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_CheckTemplateID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_CheckAmountInWords As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_APComputerCheckFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_InterestEarnedGLAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_ServiceChargeGLAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_APDiscAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_APCashAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_ARCashAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_LastComputerCheckIssued As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_LastManualCheckIssued As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_BankID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_ACHCompanyID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_RoutingNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxSetup_CheckAmountInWords As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxPaymentManager_FileOutputDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_FTPClient As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_Word As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_CustomerID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPaymentManager_FileOutputDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_FTPClient As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_Word As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CustomerID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_ExportType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPaymentManager_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPaymentManager_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxSetup_PaymentManager As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSetup_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxSetup_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrency_CurrencyExchangeRealizedAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrency_CurrencyExchangeUnrealizedAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCurrency_Currency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputSetup_RoutingNumber As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputSetup_CheckTemplateID As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelCheckImport_ImportFileName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxCheckImport_ImportFileName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TableLayoutPanelCheckImport_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents NumericInputRightColumn_NumberOfDecimals As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRightColumn_Length As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputRightColumn_ColumnStart As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelRightColumn_NumberOfDecimals As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightColumn_Length As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightColumn_ColumnStart As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightColumn_CheckAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents NumericInputLeftColumn_Length As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputLeftColumn_ColumnStart As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelCheckImport_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftColumn_Length As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLeftColumn_ColumnStart As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxCheckExport2_TotalRecord As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelTotalRecord_Export As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTotalRecord_RecordCountCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_RecordCountEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_RecordCountBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_TotalFlagEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_TotalFlagCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_TotalFlagBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_RecordCountExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTotalRecord_TotalFlagExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_TotalFlag As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_RecordCount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTotalRecord_ExportAmountCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_ExportAmountEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_ExportAmountBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_FileDateEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_FileDateCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_FileDateBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_ExportAmountExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTotalRecord_FileDateExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_FileDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_ExportAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTotalRecord_Filler4FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTotalRecord_Filler4EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_Filler4BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_Filler4Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_Filler4 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTotalRecord_Filler3FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTotalRecord_Filler3EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_Filler3BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_Filler3Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_Filler3 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTotalRecord_Filler2FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxTotalRecord_Filler1FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTotalRecord_Filler2EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_Filler2BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_Filler2Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputTotalRecord_Filler1EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_Filler1BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_Filler1Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputTotalRecord_AccountNumberCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_AccountNumberEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_AccountNumberBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_BankIDEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_BankIDCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTotalRecord_BankIDBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTotalRecord_AccountNumberExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_Filler2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxTotalRecord_BankIDExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTotalRecord_Filler1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_FillValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_BankID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_CSVOrder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_EndPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTotalRecord_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxCheckExport2_TrailerRecord As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelTrailerRecord_Export As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTrailerRecord_RecordCountCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_RecordCountEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_RecordCountBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_TotalFlagEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_TotalFlagCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_TotalFlagBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_RecordCountExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTrailerRecord_TotalFlagExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_TotalFlag As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_RecordCount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputTrailerRecord_ExportAmountCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_ExportAmountEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_ExportAmountBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_FileDateEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_FileDateCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_FileDateBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_ExportAmountExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxTrailerRecord_FileDateExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_FileDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_ExportAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTrailerRecord_Filler4FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTrailerRecord_Filler4EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_Filler4BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_Filler4Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_Filler4 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTrailerRecord_Filler3FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTrailerRecord_Filler3EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_Filler3BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_Filler3Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_Filler3 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTrailerRecord_Filler2FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxTrailerRecord_Filler1FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputTrailerRecord_Filler2EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_Filler2BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_Filler2Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputTrailerRecord_Filler1EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_Filler1BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_Filler1Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputTrailerRecord_AccountNumberCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_AccountNumberEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_AccountNumberBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_BankIDEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_BankIDCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputTrailerRecord_BankIDBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxTrailerRecord_AccountNumberExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_Filler2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxTrailerRecord_BankIDExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelTrailerRecord_Filler1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_FillValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_BankID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_CSVOrder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_EndPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelTrailerRecord_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TableLayoutPanelCheckExport2_CheckExport2TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelCheckExport2TableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelCheckExport2TableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents TabControlPanelCheckExport_CheckExport As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TableLayoutPanelCheckExport_CheckExportTableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelCheckExportTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxCheckExport_DetailRecord As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelDetailRecord_Export As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDetailRecord_PayeeCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_PayeeEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_PayeeBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_PayeeExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_Payee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDetailRecord_VoidFlagCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_VoidFlagEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_VoidFlagBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckAmountEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckAmountCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckAmountBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_VoidFlagExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDetailRecord_CheckAmountExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_CheckAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_VoidFlag As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDetailRecord_CheckDateCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckDateEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckDateBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckNumberEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckNumberCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_CheckNumberBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_CheckDateExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxDetailRecord_CheckNumberExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_CheckDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDetailRecord_Filler4FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputDetailRecord_Filler4EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_Filler4BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_Filler4Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_Filler4 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDetailRecord_Filler3FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputDetailRecord_Filler3EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_Filler3BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_Filler3Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_Filler3 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDetailRecord_Filler2FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxDetailRecord_Filler1FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputDetailRecord_Filler2EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_Filler2BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_Filler2Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputDetailRecord_Filler1EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_Filler1BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_Filler1Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputDetailRecord_AccountNumberCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_AccountNumberEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_AccountNumberBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_BankIDEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_BankIDCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDetailRecord_BankIDBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxDetailRecord_AccountNumberExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_Filler2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxDetailRecord_BankIDExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelDetailRecord_Filler1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_FillValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_BankID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_CSVOrder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_EndPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDetailRecord_AccountNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelCheckExportTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents GroupBoxCheckExport_HeaderRecord As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxHeaderRecord_Filler2FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxHeaderRecord_Filler1FillValue As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputHeaderRecord_Filler2EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_Filler2BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxHeaderRecord_Filler2Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputHeaderRecord_Filler1EndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_Filler1BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxHeaderRecord_Filler1Export As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputHeaderRecord_CreateDateCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_CreateDateEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_CreateDateBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_AgencyEndPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_AgencyCSVOrder As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputHeaderRecord_AgencyBeginPosition As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxHeaderRecord_CreateDateExport As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelHeaderRecord_Filler2 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxHeaderRecord_ExportAgency As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelHeaderRecord_Filler1 As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_FillValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_Export As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_Agency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_CSVOrder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_EndPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_CreateDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelHeaderRecord_BeginPosition As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxCheckExport_UseHeaderRecord As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlCheckExport_CSV As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlCheckExport_Fixed As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelCheckExport_ExportFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemBankDetails_CheckExport As DevComponents.DotNetBar.TabItem
        Friend WithEvents NumericInputSetup_LastComputerCheckIssued As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputSetup_LastManualCheckIssued As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelSetup_CheckWritingInProgress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPaymentManager_CSITargetFolder As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_CSIPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_CSIUserName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPaymentManager_CSITargetFolder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CSIPassword As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CSIUserName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CSIPreferredPartnerSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPaymentManager_ComDataPassword As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_ComDataAccountCode As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPaymentManager_Password As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_AccountCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_ACHSettings As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CompanyEntryDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_CompanyName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxPaymentManager_StandardEntryClassCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxPaymentManager_ServiceClassCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TextBoxPaymentManager_CompanyEntryDescription As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_CompanyName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPaymentManager_DestinationName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPaymentManager_StandardEntryClassCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_ServiceClassCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPaymentManager_DestinationName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSetup_InterestEarnedGLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_ServiceChargeGLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_APDiscAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_APCashAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_ARCashAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_APComputerCheckFormat As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView6 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCurrency_Currency As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView7 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCurrency_ExchangeRealizedAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView10 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCurrency_ExchangeUnrealizedAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView9 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPaymentManager_ExportType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView11 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ComboBoxCheckFormatSettings_AdjustCheckBodyLinesDown As ComboBox
        Friend WithEvents ComboBoxCheckFormatSettings_AdjustCheckStubLinesUp As ComboBox
        Friend WithEvents LabelCheckFormatSettings_AdjustCheckBodyLinesDown As Label
        Friend WithEvents LabelCheckFormatSettings_AdjustCheckStubLinesUp As Label
        Friend WithEvents ComboBoxSetup_DigitalSignatureFont As ComboBox
        Friend WithEvents LabelSetup_DigitalSignatureFont As Label
        Friend WithEvents TextBoxSetup_DigitalSignatureText As TextBox
        Friend WithEvents LabelSetup_DigitalSignatureText As Label
        Friend WithEvents CheckBoxSetup_DigitalSignatureActive As CheckBox
        Friend WithEvents LabelSetup_DigitalSignature As Label
        Friend WithEvents ComboBoxSetup_DigitalSignatureFontSize As ComboBox
        Friend WithEvents LabelSetup_DigitalSignatureFontSize As Label
        Friend WithEvents CheckBoxPaymentManager_UseSSL As CheckBox
        Friend WithEvents TextBoxPaymentManager_FTPPort As TextBox
        Friend WithEvents LabelPaymentManager_FTPPort As Label
        Friend WithEvents TextBoxPaymentManager_FTPExportFolder As TextBox
        Friend WithEvents TextBoxPaymentManager_FTPAddress As TextBox
        Friend WithEvents LabelPaymentManager_FTPAddress As Label
        Friend WithEvents LabelPaymentManager_FTPExportPath As Label
        Friend WithEvents TextBoxPaymentManager_FTPFolder As TextBox
        Friend WithEvents TextBoxPaymentManager_FTPPassword As TextBox
        Friend WithEvents TextBoxPaymentManager_FTPUserName As TextBox
        Friend WithEvents LabelPaymentManager_FTPTargetFolder As Label
        Friend WithEvents LabelPaymentManager_FTPPassword As Label
        Friend WithEvents LabelPaymentManager_FTPUserName As Label
        Friend WithEvents LabelPaymentManager_FTPSettings As Label
        Friend WithEvents ComboBoxPaymentManager_FTPSecure As ComboBox
        Friend WithEvents LabelPaymentManager_FTPSecure As Label
        Friend WithEvents LabelPaymentManager_FTPPrivateKey As Label
        Friend WithEvents ButtonPaymentManager_FTPPrivateKeyDelete As Button
        Friend WithEvents ButtonPaymentManager_FTPPrivateKeySelect As Button
    End Class

End Namespace
