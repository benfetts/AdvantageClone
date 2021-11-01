Imports DevComponents.AdvTree

Namespace WinForm.Presentation.Controls

    Public Class ComboBox
        Inherits DevComponents.DotNetBar.Controls.ComboBoxEx
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event ReloadComboBox()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ExtraComboBoxItems As Short
            [Nothing] = 0
            PleaseSelect = -1
            None = -2
            AgencyDefault = -3
            Open = -4
        End Enum

        Public Enum [Type]
            [Default]
            Database
            DatabaseServerInstance
            DaysOfWeek
            Employee
            DatabaseProfile
            Application
            SQLUser
            QvAAlertServiceSendAlertTo
            QvAAlertServiceSetAlertLevel
            QvAAlertServiceShowLevel
            Client
            WorkspaceTemplate
            Role
            AlertGroup
            ClientPortalUser
            ClientContact
            Month
            TaxCode
            Office
            SortKey
            Division
            Vendor
            Product
            Report
            InvoiceFormat
            StandardCommentApplication
            StandardCommentType
            FontSize
            POP3AuthenticationMethod
            ImportFileType
            MediaImportOption
            CurrencyCode
            ShortNumeric
            LongNumeric
            Ad
            Market
            JobAndJobComponent
            GeneralLedgerAccount
            VendorTerm
            CheckFormat
            ServiceFeeReconciliationReport
            PrintSpecRegion
            Yes1No0
            PostPeriod
            ServiceFeeReconciliationGroupByOptions
            ServiceFeeReconciliationSummaryStyles
            ExportSystem
            ReportMissingTime
            POApprovalRule
            BillingRateLevel
            EmployeeTitle
            [Function]
            User
            Job
            SalesClass
            MediaType
            ResourceType
            EnumDataTable
            AlertCategory
            DocumentType
            EmployeeTimeForecast
            EmployeeTimeForecastOfficeDetailRevision
            ImportTemplate
            EmployeeOfficeGroup
            JobSpecificationVendorTab
            AdSize
            Campaign
            EnumObjects
            JobVersionTemplateDetail
            UserDefinedReportCategory
            Cycle
            JobVersionTemplate
            Bank
            AccountGroup
            JobComponent
            KeyValuePair
            AlertState
            AlertAssignmentTemplate
            ExportTemplate
            IndirectCategory
            RecordSource
            InvoiceCategory
            [Date]
            EstimateReport
            JobProcess
            Status
            ContactType
            VendorInvoiceCategory
            Image
            Country
            MediaPlanTemplate
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As ComboBox.Type = ComboBox.Type.Default
        Protected _FormSettingsLoaded As Boolean = False
        Protected _DisableMouseWheel As Boolean = False
        Protected _ExtraComboBoxItem As ExtraComboBoxItems = ExtraComboBoxItems.Nothing
        Protected _IsRequired As Boolean = False
        Protected _BookmarkingEnabled As Boolean = False
        Protected _CurrentBookmark As Object = Nothing
        Protected _DisplayName As String = ""
        Protected _ErrorIconAlignment As System.Windows.Forms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
        Protected _EntityDataType As System.Type = Nothing
        Protected _AddedItemsToDataSource As Generic.List(Of Object) = Nothing
        Protected _AddInactiveItemsOnSelectedValue As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _IsDataSourceLoading As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _ReadOnly As Boolean = False
        Protected _Visible As Boolean = True
        Protected _TextBox As AdvantageFramework.WinForm.Presentation.Controls.TextBox = Nothing
        Protected _AutoSelectSingleItemDatasource As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _AutoFindItemInDataSource As Boolean = False
        Private _SecurityEnabled As Boolean = True
        Protected _ClientCode As String = ""
        Protected _DivisionCode As String = ""
        Protected _TabOnEnter As Boolean = True

#End Region

#Region " Properties "

        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get
                UserEntryChanged = _UserEntryChanged
            End Get
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)
                _SuspendedForLoading = value
            End Set
        End Property
        Public Property DisplayName As String
            Get
                DisplayName = _DisplayName
            End Get
            Set(ByVal value As String)
                _DisplayName = value
            End Set
        End Property
        Public Property ControlType() As ComboBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As ComboBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.DataSource
            End Get
            Set(ByVal value As Object)
                _IsDataSourceLoading = True
                LoadDataSource(value)
                _IsDataSourceLoading = False

                If _AutoSelectSingleItemDatasource Then

                    SelectSingleItemDataSource()

                End If

            End Set
        End Property
        Public Property ExtraComboBoxItem() As ExtraComboBoxItems
            Get
                ExtraComboBoxItem = _ExtraComboBoxItem
            End Get
            Set(ByVal value As ExtraComboBoxItems)
                _ExtraComboBoxItem = value
            End Set
        End Property
        Public Property BookmarkingEnabled() As Boolean
            Get
                BookmarkingEnabled = _BookmarkingEnabled
            End Get
            Set(ByVal value As Boolean)
                _BookmarkingEnabled = value
            End Set
        End Property
        Public Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
            Get
                ErrorIconAlignment = _ErrorIconAlignment
            End Get
            Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
                _ErrorIconAlignment = value
            End Set
        End Property
        Public Shadows Property SelectedValue As Object
            Get
                SelectedValue = MyBase.SelectedValue
            End Get
            Set(ByVal value As Object)

                Dim Failed As Boolean = False
                Dim Entity As AdvantageFramework.BaseClasses.Entity = Nothing

                Try

                    If IsNothing(value) = False Then

                        MyBase.SelectedValue = value

                    Else

                        Failed = True

                    End If

                Catch ex As Exception
                    Failed = True
                End Try

                If Failed OrElse MyBase.SelectedValue Is Nothing Then

                    Try

                        If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing AndAlso Me.Items.Count > 0 Then

                            Me.SelectedIndex = 0

                        Else

                            Me.SelectedIndex = -1

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If (value IsNot Nothing OrElse value <> Nothing) AndAlso Me.HasASelectedValue = False AndAlso _AddInactiveItemsOnSelectedValue Then

                            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                                If CType(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormShown AndAlso _Session IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Select Case _ControlType

                                            Case ComboBox.Type.EmployeeTitle

                                                Entity = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, value)

                                            Case ComboBox.Type.Office

                                                Entity = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, value)

                                            Case ComboBox.Type.Employee

                                                Entity = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, value)

                                            Case ComboBox.Type.Function

                                                Entity = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, value)

                                            Case ComboBox.Type.Vendor

                                                Entity = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, value)

                                            Case ComboBox.Type.Client

                                                Entity = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, value)

                                            Case ComboBox.Type.Division

                                                Entity = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, value)

                                            Case ComboBox.Type.Product

                                                Entity = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, value)

                                            Case Type.GeneralLedgerAccount

                                                Entity = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, value)

                                            Case Type.PostPeriod

                                                Entity = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, value)

                                            Case Type.SalesClass

                                                Entity = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, value)

                                        End Select

                                        If Entity IsNot Nothing Then

                                            Me.AddComboItemToExistingDataSource(Entity.ToString, value, False)
                                            MyBase.SelectedValue = value

                                            If Me.HasASelectedValue = False Then

                                                Me.SelectedIndex = 0

                                            End If

                                        End If

                                    End Using

                                End If

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                End If

            End Set
        End Property
        Public Property DisableMouseWheel() As Boolean
            Get
                DisableMouseWheel = _DisableMouseWheel
            End Get
            Set(ByVal value As Boolean)
                _DisableMouseWheel = value
            End Set
        End Property
        Public Property AddInactiveItemsOnSelectedValue() As Boolean
            Get
                AddInactiveItemsOnSelectedValue = _AddInactiveItemsOnSelectedValue
            End Get
            Set(ByVal value As Boolean)
                _AddInactiveItemsOnSelectedValue = value
            End Set
        End Property
        Public ReadOnly Property IsDataSourceLoading As Boolean
            Get
                IsDataSourceLoading = _IsDataSourceLoading
            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)
                _ByPassUserEntryChanged = value
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)

                If value <> _ReadOnly Then

                    _ReadOnly = value

                    ShowControl()

                End If

            End Set
        End Property
        Public Shadows Property Visible As Boolean
            Get
                Visible = _Visible
            End Get
            Set(ByVal value As Boolean)
                _Visible = value
                ShowControl()
            End Set
        End Property
        Public Property AutoSelectSingleItemDatasource As Boolean
            Get
                AutoSelectSingleItemDatasource = _AutoSelectSingleItemDatasource
            End Get
            Set(ByVal value As Boolean)
                _AutoSelectSingleItemDatasource = value
            End Set
        End Property
        Public Property AutoFindItemInDataSource As Boolean
            Get
                AutoFindItemInDataSource = _AutoFindItemInDataSource
            End Get
            Set(value As Boolean)
                _AutoFindItemInDataSource = value
            End Set
        End Property
        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(ByVal value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

                End If

                If Not MyBase.Enabled Then

                    Me.UseCustomBackColor = False

                Else

                    SetRequired(_IsRequired)

                End If

            End Set
        End Property
        Public Property SecurityEnabled As Boolean
            Get
                SecurityEnabled = _SecurityEnabled
            End Get
            Set(ByVal value As Boolean)
                _SecurityEnabled = value
                Me.Enabled = value
            End Set
        End Property
        Public Property TabOnEnter() As Boolean
            Get
                TabOnEnter = _TabOnEnter
            End Get
            Set(ByVal value As Boolean)
                _TabOnEnter = value
            End Set
        End Property
        Public Overrides Property SelectedIndex() As Integer
            Get
                SelectedIndex = MyBase.SelectedIndex
            End Get
            Set(ByVal value As Integer)

                If value = 0 Then

                    If Me.Items.Count > 0 Then

                        MyBase.SelectedIndex = 0

                    Else

                        MyBase.SelectedIndex = -1

                    End If

                Else

                    MyBase.SelectedIndex = value

                End If

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.DropDownStyle = Windows.Forms.ComboBoxStyle.DropDown
            Me.ItemHeight = 14
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
            Me.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
            Me.FocusHighlightEnabled = True
            'Me.PreventEnterBeep = False  ' removed so that Enter will function like the TAB key
            Me.WatermarkEnabled = True
            Me.FlatStyle = Windows.Forms.FlatStyle.Flat
            Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            Me.FocusHighlightColor = System.Drawing.Color.FromArgb(255, 230, 141)

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

            _AddedItemsToDataSource = New Generic.List(Of Object)
            _TextBox = New AdvantageFramework.WinForm.Presentation.Controls.TextBox

        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged

            _UserEntryChanged = False

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor), ByVal EnumProperty As [Enum])

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = PropertyDescriptorsList.SingleOrDefault(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper)

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor)

        End Sub
        Public Sub SetPropertySettings(Optional ByVal DisplayName As String = Nothing, Optional ByVal EntityDataType As System.Type = Nothing, Optional ByVal IsRequired As Boolean = False)

            If String.IsNullOrEmpty(DisplayName) = False Then

                _DisplayName = DisplayName

            End If

            _EntityDataType = EntityDataType

            SetRequired(IsRequired)

        End Sub
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                End Try

                If EntityAttribute IsNot Nothing Then

                    SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name), PropertyDescriptor.PropertyType, EntityAttribute.IsRequired)

                Else

                    SetPropertySettings(AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name), PropertyDescriptor.PropertyType)

                End If

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal EnumProperty As [Enum])

            'objects
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            End Try

            SetPropertySettings(PropertyDescriptor)

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.UseCustomBackColor = True
                Me.BackColor = Drawing.Color.Cyan

            Else

                Me.UseCustomBackColor = False
                Me.BackColor = Drawing.Color.White

            End If

        End Sub
        Protected Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form) Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl.LoadFormSettings

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.ErrorProvider.SetIconAlignment(Me, _ErrorIconAlignment)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case ComboBox.Type.Default

                    Me.ValueMember = ""
                    Me.DisplayMember = ""
                    Me.WatermarkText = ""

                Case ComboBox.Type.Database

                    Me.ValueMember = "ID"
                    Me.DisplayMember = "Name"
                    Me.WatermarkText = "Select Database"

                Case ComboBox.Type.DatabaseServerInstance

                    Me.ValueMember = "ServerAndInstanceName"
                    Me.DisplayMember = "ServerAndInstanceName"
                    Me.WatermarkText = "Select Server"

                Case ComboBox.Type.DaysOfWeek

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Day"

                Case ComboBox.Type.Employee

                    Me.DisplayMember = "FullName"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Employee"

                Case ComboBox.Type.DatabaseProfile

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ConnectionString"
                    Me.WatermarkText = "Select Database Profile"

                Case ComboBox.Type.Application

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Application"

                Case ComboBox.Type.SQLUser

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select SQL User"

                Case ComboBox.Type.QvAAlertServiceSendAlertTo

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Send Alert To"

                Case ComboBox.Type.QvAAlertServiceSetAlertLevel

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Set Alert Level"

                Case ComboBox.Type.QvAAlertServiceShowLevel

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Level"

                Case ComboBox.Type.Client

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Client"

                Case ComboBox.Type.WorkspaceTemplate

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Workspace Template"

                Case ComboBox.Type.Role

                    Me.DisplayMember = "CodeAndDescription"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Role"

                Case ComboBox.Type.AlertGroup

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Alert Group"

                Case ComboBox.Type.ClientContact

                    Me.DisplayMember = "FullNameFML"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Client Contact"

                Case ComboBox.Type.ClientPortalUser

                    Me.DisplayMember = "FullNameFML"
                    Me.ValueMember = "ClientContactID"
                    Me.WatermarkText = "Select Client Portal User"

                Case ComboBox.Type.Month

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Month"

                Case ComboBox.Type.TaxCode

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Tax Code"

                Case ComboBox.Type.Office

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Office"

                Case ComboBox.Type.SortKey

                    Me.DisplayMember = "SortKey"
                    Me.ValueMember = "SortKey"
                    Me.WatermarkText = "Select Sort Key"

                Case ComboBox.Type.Division

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Division"

                Case ComboBox.Type.Vendor

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Vendor"

                Case ComboBox.Type.Product

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Product"

                Case ComboBox.Type.Report

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Report"

                Case ComboBox.Type.InvoiceFormat

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Invoice Format"

                Case ComboBox.Type.StandardCommentApplication

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Application"

                Case ComboBox.Type.StandardCommentType

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Type"

                Case ComboBox.Type.FontSize

                    Me.DisplayMember = "FontSize"
                    Me.ValueMember = "FontSize"
                    Me.WatermarkText = "Select Font Size"

                Case ComboBox.Type.POP3AuthenticationMethod

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Authentication Method"

                Case ComboBox.Type.ImportFileType

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Import File Type"

                Case ComboBox.Type.MediaImportOption

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Media Import Option"

                Case ComboBox.Type.CurrencyCode

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Currency Code"

                Case ComboBox.Type.ShortNumeric

                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.LongNumeric

                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.Ad

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select Ad"

                Case ComboBox.Type.Market

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Market"

                Case ComboBox.Type.JobAndJobComponent

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "JobComponent"
                    Me.WatermarkText = "Select Job Component"

                Case ComboBox.Type.GeneralLedgerAccount

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select General Ledger Account"

                Case ComboBox.Type.VendorTerm

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Term"

                Case ComboBox.Type.CheckFormat

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select Check Format"

                Case ComboBox.Type.ServiceFeeReconciliationReport

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Service Fee Reconciliation Report Template"

                Case ComboBox.Type.PrintSpecRegion

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Region"

                Case ComboBox.Type.Yes1No0

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.PostPeriod

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Post Period"

                Case ComboBox.Type.ServiceFeeReconciliationGroupByOptions

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Group By Option"

                Case ComboBox.Type.ServiceFeeReconciliationSummaryStyles

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Summary Style"

                Case ComboBox.Type.ExportSystem

                    Me.DisplayMember = "Label"
                    Me.ValueMember = "Name"
                    Me.WatermarkText = "Select Export System"

                Case ComboBox.Type.ReportMissingTime

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Select Report Missing Time"

                Case ComboBox.Type.POApprovalRule

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select PO Approval Rule"

                Case ComboBox.Type.BillingRateLevel

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Billing Rate Level"

                Case ComboBox.Type.EmployeeTitle

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Employee Title"

                Case ComboBox.Type.Function

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Function"

                Case ComboBox.Type.User

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select User"

                Case ComboBox.Type.Job

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select Job"

                Case ComboBox.Type.SalesClass

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Job"

                Case ComboBox.Type.MediaType

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Media Type"

                Case ComboBox.Type.ResourceType

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Resource Type"

                Case ComboBox.Type.EnumDataTable

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Value"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.AlertCategory

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Alert Category"

                Case ComboBox.Type.DocumentType

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Document Type"

                Case ComboBox.Type.EmployeeTimeForecast

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Employee Time Forecast"

                Case ComboBox.Type.EmployeeTimeForecastOfficeDetailRevision

                    Me.DisplayMember = "RevisionNumber"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Employee Time Forecast"

                Case ComboBox.Type.ImportTemplate

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Import Template"

                Case ComboBox.Type.EmployeeOfficeGroup

                    Me.DisplayMember = "FullName"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Employee Office Group"

                Case ComboBox.Type.JobSpecificationVendorTab

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Job Specification Vendor Tab"

                Case ComboBox.Type.AdSize

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Ad Size"

                Case ComboBox.Type.Campaign

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Campaign"

                Case ComboBox.Type.EnumObjects

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.JobVersionTemplateDetail

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.UserDefinedReportCategory

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Report Category"

                Case ComboBox.Type.Cycle

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Cycle"

                Case ComboBox.Type.JobVersionTemplate

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Job Version Template"

                Case ComboBox.Type.Bank

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Bank"

                Case ComboBox.Type.AccountGroup

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Account Group"

                Case ComboBox.Type.JobComponent

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Number"
                    Me.WatermarkText = "Select Job Component"

                Case ComboBox.Type.KeyValuePair

                    Me.DisplayMember = "Value"
                    Me.ValueMember = "Key"
                    Me.WatermarkText = "Please Select"

                Case ComboBox.Type.AlertState

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Alert State"

                Case ComboBox.Type.AlertAssignmentTemplate

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Please Alert Assignment Template"

                Case ComboBox.Type.ExportTemplate

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Export Template"

                Case ComboBox.Type.IndirectCategory

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Indirect Category"

                Case ComboBox.Type.RecordSource

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Record Source"

                Case ComboBox.Type.InvoiceCategory

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Invoice Category"

                Case ComboBox.Type.Date

                    Me.DisplayMember = "Date"
                    Me.ValueMember = "Date"
                    Me.WatermarkText = "Select"

                Case ComboBox.Type.EstimateReport

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Custom Report"

                Case ComboBox.Type.JobProcess

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Job Process"

                Case ComboBox.Type.Status

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.WatermarkText = "Select Status"

                Case ComboBox.Type.ContactType

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Contact Type"

                Case ComboBox.Type.VendorInvoiceCategory

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Vendor Invoice Category"

                Case ComboBox.Type.Image

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Image"

                Case ComboBox.Type.Country

                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Country"

                Case ComboBox.Type.MediaPlanTemplate

                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.WatermarkText = "Select Template"

            End Select

        End Sub
        'Protected Function LoadDataSourceView(ByVal EmployeeTimeForecastOfficeDetails As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)) As Object

        '    If _ControlType = Type.EmployeeTimeForecastOfficeDetailRevision Then

        '        LoadDataSourceView = (From EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetails.ToList _
        '                              Select [RevisionNumber] = AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True), _
        '                                     [ID] = EmployeeTimeForecastOfficeDetail.ID).ToList

        '    Else

        '        LoadDataSourceView = (From EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetails.ToList _
        '                              Select [Description] = EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description & " - Revision: " & AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetail.RevisionNumber, 3, "0", True), _
        '                                     [ID] = EmployeeTimeForecastOfficeDetail.ID).ToList

        '    End If

        'End Function
        'Protected Function LoadDataSourceView(ByVal PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)) As Object

        '    LoadDataSourceView = (From PostPeriod In PostPeriods.ToList _
        '                          Select [Code] = PostPeriod.Code, _
        '                                 [Description] = PostPeriod.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ServiceFeeReconciliationReports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)) As Object

        '    LoadDataSourceView = (From ServiceFeeReconciliationReport In ServiceFeeReconciliationReports.ToList _
        '                          Select [ID] = ServiceFeeReconciliationReport.ID, _
        '                                 [Description] = ServiceFeeReconciliationReport.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal VendorTerms As IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)) As Object

        '    LoadDataSourceView = (From VendorTerm In VendorTerms.ToList _
        '                          Select [Code] = VendorTerm.Code, _
        '                                 [Description] = VendorTerm.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Object

        '    LoadDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts _
        '                          Select GeneralLedgerAccount.Code,
        '                                 [Description] = GeneralLedgerAccount.ToString).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
        '                                                                                                                         .Description = Entity.Description})

        '    'LoadDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts.ToList _
        '    '                      Select [Code] = GeneralLedgerAccount.Code, _
        '    '                             [Description] = GeneralLedgerAccount.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

        '    LoadDataSourceView = (From JobComponent In JobComponents.ToList _
        '                          Select [JobComponent] = JobComponent.ToString(True, False), _
        '                                 [Description] = JobComponent.ToString(True, True)).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

        '    LoadDataSourceView = (From Job In Jobs.ToList _
        '                          Select [ID] = Job.ID, _
        '                                 [Description] = Job.ToString(True)).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.Database.Entities.Market)) As Object

        '    LoadDataSourceView = (From Market In Markets.ToList _
        '                          Select [Code] = Market.Code, _
        '                                 [Description] = Market.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Ads As IEnumerable(Of AdvantageFramework.Database.Entities.Ad)) As Object

        '    LoadDataSourceView = (From Ad In Ads.ToList _
        '                          Select [Number] = Ad.Number, _
        '                                 [Description] = Ad.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Campaigns As IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)) As Object

        '    LoadDataSourceView = (From Campaign In Campaigns _
        '                          Select [Code] = Campaign.Code, _
        '                                 [Name] = Campaign.Name).ToList.Select(Function(Entity) New With {.[Code] = Entity.Code, _
        '                                                                                                  .[Name] = Entity.Name}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal AdSizes As IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)) As Object

        '    LoadDataSourceView = (From AdSize In AdSizes.ToList _
        '                          Select [Code] = AdSize.Code, _
        '                                 [Description] = AdSize.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal AlertGroups As IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)) As Object

        '    LoadDataSourceView = (From AlertGroup In AlertGroups.ToList _
        '                          Select [Code] = AlertGroup.Code, _
        '                                 [Name] = AlertGroup.Code).Distinct.ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As Object

        '    LoadDataSourceView = (From Division In Divisions _
        '                          Select [Code] = Division.Code, _
        '                                 [Name] = Division.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
        '                                                                                                  .Name = Entity.Code & " - " & Entity.Name}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ProductSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)) As Object

        '    LoadDataSourceView = (From ProductSortKey In ProductSortKeys.ToList _
        '                          Select [SortKey] = ProductSortKey.SortKey).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal DivisionSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)) As Object

        '    LoadDataSourceView = (From DivisionSortKey In DivisionSortKeys.ToList _
        '                          Select [SortKey] = DivisionSortKey.SortKey).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ClientSortKeys As IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)) As Object

        '    LoadDataSourceView = (From ClientSortKey In ClientSortKeys.ToList _
        '                          Select [SortKey] = ClientSortKey.SortKey).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal WorkspaceTemplates As IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)) As Object

        '    LoadDataSourceView = (From WorkspaceTemplate In WorkspaceTemplates.ToList _
        '                          Select [ID] = WorkspaceTemplate.ID, _
        '                                 [Name] = WorkspaceTemplate.Name).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Security.Database.Views.SecurityEmployee)) As Object

        '    LoadDataSourceView = (From Employee In Employees.ToList _
        '                          Select [Code] = Employee.Code, _
        '                                 [FullName] = Employee.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

        '    Select Case _ControlType

        '        Case Type.EmployeeOfficeGroup

        '            LoadDataSourceView = (From Employee In Employees.ToList _
        '                                  Select [Code] = Employee.Code, _
        '                                         [FullName] = Employee.Code & " - " & Employee.ToString).ToList

        '        Case Else

        '            LoadDataSourceView = (From Employee In Employees.ToList _
        '                                  Select [Code] = Employee.Code, _
        '                                         [FullName] = Employee.ToString).ToList

        '    End Select

        'End Function
        'Protected Function LoadDataSourceView(ByVal ServerSQLUsers As IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)) As Object

        '    LoadDataSourceView = (From ServerSQLUser In ServerSQLUsers.ToList _
        '                          Select [ID] = ServerSQLUser.ID, _
        '                                 [Name] = ServerSQLUser.Name).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

        '    LoadDataSourceView = (From Client In Clients _
        '                          Select [Code] = Client.Code,
        '                                 [Name] = Client.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
        '                                                                                                .Name = Entity.Code & " - " & Entity.Name}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role)) As Object

        '    LoadDataSourceView = (From Role In Roles.ToList _
        '                          Select [Code] = Role.Code,
        '                                 [CodeAndDescription] = Role.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Applications As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)) As Object

        '    LoadDataSourceView = (From Application In Applications.ToList _
        '                          Select Application.ID,
        '                                 Application.Name).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ClientContacts As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)) As Object

        '    LoadDataSourceView = (From ClientContact In ClientContacts.ToList _
        '                          Select ClientContact.ID,
        '                                 ClientContact.FullNameFML).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ClientPortalUsers As IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)) As Object

        '    LoadDataSourceView = (From ClientPortalUser In ClientPortalUsers.ToList _
        '                          Select ClientPortalUser.ClientContactID,
        '                                 ClientPortalUser.ClientContact.FullNameFML).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal SalesTaxes As IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)) As Object

        '    LoadDataSourceView = (From SalesTax In SalesTaxes.ToList _
        '                          Select [ID] = SalesTax.TaxCode,
        '                                 [Name] = SalesTax.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

        '    LoadDataSourceView = (From Office In Offices.ToList _
        '                          Select Office.Code,
        '                                 [Name] = Office.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

        '    LoadDataSourceView = (From Vendor In Vendors.ToList _
        '                          Select [Code] = Vendor.Code,
        '                                 [Name] = Vendor.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

        '    LoadDataSourceView = (From Product In Products _
        '                          Select [Code] = Product.Code,
        '                                 [Name] = Product.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
        '                                                                                                 .Name = Entity.Code & " - " & Entity.Name}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal CustomReports As IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)) As Object

        '    LoadDataSourceView = (From CustomReport In CustomReports.ToList _
        '                          Select [Code] = CustomReport.Name, _
        '                                 [Name] = CustomReport.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Reports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)) As Object

        '    If _ControlType = Type.CheckFormat Then

        '        LoadDataSourceView = (From Report In Reports.ToList _
        '                              Select [Name] = Report.ToString,
        '                                     [Number] = Report.Number).ToList

        '    Else

        '        LoadDataSourceView = (From Report In Reports.ToList _
        '                              Select [Name] = Report.ToString,
        '                                     [Code] = Report.Code).ToList

        '    End If

        'End Function
        'Protected Function LoadDataSourceView(ByVal CurrencyCodes As IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)) As Object

        '    LoadDataSourceView = (From CurrencyCode In CurrencyCodes.ToList _
        '                          Select [Code] = CurrencyCode.Code, _
        '                                 [Description] = CurrencyCode.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal PrintSpecRegions As IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)) As Object

        '    LoadDataSourceView = (From PrintSpecRegion In PrintSpecRegions.ToList _
        '                          Select [Code] = PrintSpecRegion.Code, _
        '                                 [Description] = PrintSpecRegion.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ShortNumericList As IEnumerable(Of Int16)) As Object

        '    LoadDataSourceView = From Number In ShortNumericList _
        '                         Select New With {.[Number] = Number}

        'End Function
        'Protected Function LoadDataSourceView(ByVal LongNumericList As IEnumerable(Of Int32)) As Object

        '    LoadDataSourceView = From Number In LongNumericList _
        '                         Select New With {.[Number] = Number}

        'End Function
        'Protected Function LoadDataSourceView(ByVal ExportSystems As IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)) As Object

        '    LoadDataSourceView = (From ExportSystem In ExportSystems.ToList _
        '                          Select [Name] = ExportSystem.Name, _
        '                                 [Label] = ExportSystem.Label).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal PurchaseOrderApprovalRules As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)) As Object

        '    LoadDataSourceView = (From PurchaseOrderApprovalRule In PurchaseOrderApprovalRules.ToList _
        '                          Select [Code] = PurchaseOrderApprovalRule.Code, _
        '                                 [Description] = PurchaseOrderApprovalRule.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal BillingRateLevels As IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)) As Object

        '    LoadDataSourceView = (From BillingRateLevel In BillingRateLevels _
        '                          Select BillingRateLevel.ID, _
        '                                 BillingRateLevel.Number, _
        '                                 BillingRateLevel.Description).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
        '                                                                                                        .Description = Entity.Number & " - " & Entity.Description}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal EmployeeTitles As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As Object

        '    LoadDataSourceView = (From EmployeeTitle In EmployeeTitles.ToList _
        '                          Select [ID] = EmployeeTitle.ID, _
        '                                 [Description] = EmployeeTitle.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Functions As IEnumerable(Of AdvantageFramework.Database.Entities.Function)) As Object

        '    LoadDataSourceView = (From [Function] In Functions.ToList _
        '                          Select [Code] = [Function].Code, _
        '                                 [Description] = [Function].ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Users As IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)) As Object

        '    LoadDataSourceView = (From User In Users.ToList _
        '                          Select [ID] = User.ID, _
        '                                 [Name] = User.UserCode).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal SalesClasses As IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)) As Object

        '    LoadDataSourceView = (From SalesClass In SalesClasses.ToList _
        '                          Select [Code] = SalesClass.Code, _
        '                                 [Description] = SalesClass.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ResourceTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)) As Object

        '    LoadDataSourceView = (From ResourceType In ResourceTypes.ToList _
        '                          Select [Code] = ResourceType.Code,
        '                                 [Description] = ResourceType.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal AlertCategories As IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)) As Object

        '    LoadDataSourceView = (From AlertCategory In AlertCategories.ToList _
        '                          Select [ID] = AlertCategory.ID,
        '                                 [Description] = AlertCategory.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal DocumentTypes As IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)) As Object

        '    LoadDataSourceView = (From DocumentType In DocumentTypes.ToList _
        '                          Select [ID] = DocumentType.ID,
        '                                 [Description] = DocumentType.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ImportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)) As Object

        '    LoadDataSourceView = (From ImportTemplate In ImportTemplates.ToList _
        '                          Select [ID] = ImportTemplate.ID,
        '                                 [Name] = ImportTemplate.Name).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal JobSpecificationVendorTabs As IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)) As Object

        '    LoadDataSourceView = (From JobSpecificationVendorTab In JobSpecificationVendorTabs.ToList _
        '                          Select [ID] = JobSpecificationVendorTab.ID,
        '                                 [Description] = JobSpecificationVendorTab.Description).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Value As Object) As Object

        '    'objects
        '    Dim View As Object = Nothing

        '    If TypeOf Value Is IEnumerable Then

        '        If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Employee) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Employee)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.SecurityEmployee) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.SecurityEmployee)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Views.ServerSQLUser)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Application)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplate)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Role) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Role)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientContact)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ClientPortalUser)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ProductSortKey)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DivisionSortKey)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ClientSortKey)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Division) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Division)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CustomReport)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertGroup)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.CurrencyCode)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Ad) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Ad)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Market) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Market)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.VendorTerm)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ExportSystem)))

        '        ElseIf TypeOf Value Is IEnumerable(Of Int16) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of Int16)))

        '        ElseIf TypeOf Value Is IEnumerable(Of Int32) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of Int32)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.BillingRateLevel)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTitle)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Function) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Function)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.User) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.User)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesClass)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ResourceType)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AlertCategory)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.DocumentType)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobSpecificationVendorTab)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.AdSize) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.AdSize)))

        '        ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Campaign) Then

        '            View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Campaign)))

        '        Else

        '            View = Value

        '        End If

        '    Else

        '        View = Value

        '    End If

        '    LoadDataSourceView = View

        'End Function
        Protected Function LoadDataSourceView(ByVal Reports As IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)) As Object

            If _ControlType = Type.CheckFormat Then

                LoadDataSourceView = (From Report In Reports.ToList
                                      Select [Name] = Report.ToString,
                                             [Number] = Report.Number).ToList

            Else

                LoadDataSourceView = (From Report In Reports.ToList
                                      Select [Name] = Report.ToString,
                                             [Code] = Report.Code).ToList

            End If

        End Function
        Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

            LoadDataSourceView = (From Product In Products
                                  Select [Code] = Product.Code,
                                         [Name] = Product.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                         .Name = Entity.Code & " - " & Entity.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Core.Product)) As Object

            LoadDataSourceView = (From Product In Products
                                  Select New With {.Code = Product.Code,
                                                   .Name = Product.Code & " - " & Product.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

            LoadDataSourceView = (From Vendor In Vendors
                                  Select Vendor.Code,
                                         Vendor.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                               .Name = Entity.Code & " - " & Entity.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Core.Vendor)) As Object

            LoadDataSourceView = (From Vendor In Vendors
                                  Select New With {.Code = Vendor.Code,
                                                   .Name = Vendor.Code & " - " & Vendor.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

            LoadDataSourceView = (From Office In Offices
                                  Select [Code] = Office.Code,
                                         [Name] = Office.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                        .Name = Entity.Code & " - " & Entity.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Core.Office)) As Object

            LoadDataSourceView = (From Office In Offices
                                  Select New With {.Code = Office.Code,
                                                   .Name = Office.Code & " - " & Office.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal SalesTaxes As IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)) As Object

            LoadDataSourceView = (From SalesTax In SalesTaxes.ToList
                                  Select [ID] = SalesTax.TaxCode,
                                         [Name] = SalesTax.ToString).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Roles As IEnumerable(Of AdvantageFramework.Database.Entities.Role)) As Object

            LoadDataSourceView = (From Role In Roles.ToList
                                  Select [Code] = Role.Code,
                                         [CodeAndDescription] = Role.ToString).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

            LoadDataSourceView = (From Client In Clients
                                  Select [Code] = Client.Code,
                                         [Name] = Client.Name).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                        .Name = Entity.Code & " - " & Entity.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Core.Client)) As Object

            LoadDataSourceView = (From Client In Clients
                                  Select New With {.Code = Client.Code,
                                                           .Name = Client.Code & " - " & Client.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Banks As IEnumerable(Of AdvantageFramework.Database.Entities.Bank)) As Object

            LoadDataSourceView = (From Bank In Banks
                                  Select New With {.Code = Bank.Code,
                                                   .Description = Bank.Code & " - " & Bank.Description}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Core.Employee)) As Object

            Select Case _ControlType

                Case Type.EmployeeOfficeGroup

                    'LoadDataSourceView = (From Employee In Employees.ToList _
                    '                      Select [Code] = Employee.Code, _
                    '                             [FullName] = Employee.Code & " - " & Employee.ToString).ToList

                    LoadDataSourceView = Employees.Select(Function(Entity) New With {Entity.Code,
                                                                                     Entity.FirstName,
                                                                                     Entity.LastName,
                                                                                     Entity.MiddleInitial,
                                                                                     Entity.TerminationDate}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                .FullName = Entity.Code & " - " & If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial.Trim <> "",
                                                                                                                                                                                  Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName,
                                                                                                                                                                                  Entity.FirstName & " " & Entity.LastName)}).ToList

                Case Else

                    'LoadDataSourceView = (From Employee In Employees.ToList _
                    '                      Select [Code] = Employee.Code, _
                    '                             [FullName] = Employee.ToString).ToList

                    LoadDataSourceView = Employees.Select(Function(Entity) New With {Entity.Code,
                                                                                     Entity.FirstName,
                                                                                     Entity.LastName,
                                                                                     Entity.MiddleInitial,
                                                                                     Entity.TerminationDate}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                .FullName = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial.Trim <> "",
                                                                                                                                                            Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName,
                                                                                                                                                            Entity.FirstName & " " & Entity.LastName)}).ToList

            End Select

        End Function
        Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

            Select Case _ControlType

                Case Type.EmployeeOfficeGroup

                    'LoadDataSourceView = (From Employee In Employees.ToList _
                    '                      Select [Code] = Employee.Code, _
                    '                             [FullName] = Employee.Code & " - " & Employee.ToString).ToList

                    LoadDataSourceView = Employees.Select(Function(Entity) New With {Entity.Code,
                                                                                     Entity.FirstName,
                                                                                     Entity.LastName,
                                                                                     Entity.MiddleInitial,
                                                                                     Entity.TerminationDate}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                .FullName = Entity.Code & " - " & If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial.Trim <> "",
                                                                                                                                                                                  Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName,
                                                                                                                                                                                  Entity.FirstName & " " & Entity.LastName)}).ToList

                Case Else

                    'LoadDataSourceView = (From Employee In Employees.ToList _
                    '                      Select [Code] = Employee.Code, _
                    '                             [FullName] = Employee.ToString).ToList

                    LoadDataSourceView = Employees.Select(Function(Entity) New With {Entity.Code,
                                                                                     Entity.FirstName,
                                                                                     Entity.LastName,
                                                                                     Entity.MiddleInitial,
                                                                                     Entity.TerminationDate}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                .FullName = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial.Trim <> "",
                                                                                                                                                            Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName,
                                                                                                                                                            Entity.FirstName & " " & Entity.LastName)}).ToList

            End Select

        End Function
        Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

            If _ControlType = Type.JobComponent Then

                LoadDataSourceView = (From JobComponent In JobComponents
                                      Select JobComponent.Number,
                                             JobComponent.Description).ToList.Select(Function(JobComponent) New With {.Number = JobComponent.Number & "",
                                                                                                                      .Description = JobComponent.Number & "- " & JobComponent.Description}).ToList

            Else

                LoadDataSourceView = (From JobComponent In JobComponents.ToList
                                      Select [JobComponent] = JobComponent.ToString(True, False),
                                             [Description] = JobComponent.ToString(True, True)).ToList
            End If

        End Function
        Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)) As Object

            If _ControlType = Type.JobComponent Then

                LoadDataSourceView = (From JobComponent In JobComponents
                                      Select Number = JobComponent.JobComponentNumber,
                                             Description = JobComponent.JobComponentDescription).ToList.Select(Function(JobComponent) New With {.Number = JobComponent.Number & "",
                                                                                                                                                .Description = JobComponent.Number & "- " & JobComponent.Description}).ToList

            Else

                LoadDataSourceView = (From JobComponent In JobComponents.ToList
                                      Select [JobComponent] = JobComponent.ToString(True, False),
                                             [Description] = JobComponent.ToString(True, True)).ToList
            End If

        End Function
        Protected Function LoadDataSourceView(ByVal ImportTemplates As IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)) As Object

            LoadDataSourceView = (From ImportTemplate In ImportTemplates
                                  Select ImportTemplate.ID,
                                         ImportTemplate.Name).ToList.Select(Function(ImportTemplate) New With {.ID = ImportTemplate.ID,
                                                                                                               .Name = ImportTemplate.Name}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

            LoadDataSourceView = (From Job In Jobs
                                  Select Job.ID,
                                         Job.Number,
                                         Job.Description).ToList.Select(Function(Job) New With {.ID = Job.ID,
                                                                                                .Number = Job.Number,
                                                                                                .Description = Job.Number.ToString & " - " & Job.Description}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal EmployeeTimeForecastOfficeDetails As IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)) As Object

            If _ControlType = Type.EmployeeTimeForecastOfficeDetailRevision Then

                LoadDataSourceView = (From EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetails
                                      Select EmployeeTimeForecastOfficeDetail.RevisionNumber,
                                             EmployeeTimeForecastOfficeDetail.ID).ToList.Select(Function(Entity) New With {.RevisionNumber = AdvantageFramework.StringUtilities.PadWithCharacter(Entity.RevisionNumber, 3, "0", True),
                                                                                                                           .ID = Entity.ID}).ToList

            Else

                LoadDataSourceView = (From EmployeeTimeForecastOfficeDetail In EmployeeTimeForecastOfficeDetails
                                      Select EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description,
                                             EmployeeTimeForecastOfficeDetail.RevisionNumber,
                                             EmployeeTimeForecastOfficeDetail.ID).ToList.Select(Function(Entity) New With {.ID = Entity.ID,
                                                                                                                           .Description = Entity.Description & " - Revision: " &
                                                                                                                                          AdvantageFramework.StringUtilities.PadWithCharacter(Entity.RevisionNumber, 3, "0", True)}).ToList

            End If

        End Function
        Private Function LoadDataSourceView(ByVal IndirectCategories As IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)) As Object

            LoadDataSourceView = (From IndirectCategory In IndirectCategories
                                  Select New With {.Code = IndirectCategory.Code,
                                                   .Description = IndirectCategory.Description}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal InvoiceCategories As IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)) As Object

            LoadDataSourceView = (From InvoiceCategory In InvoiceCategories
                                  Select New With {.Code = InvoiceCategory.Code,
                                                   .Description = InvoiceCategory.Description}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal RecordSources As IEnumerable(Of AdvantageFramework.Database.Entities.RecordSource)) As Object

            LoadDataSourceView = (From RecordSource In RecordSources
                                  Select New With {.ID = RecordSource.ID,
                                                   .Name = RecordSource.Name}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal JobProcesses As IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess)) As Object

            LoadDataSourceView = (From JobProcess In JobProcesses
                                  Select New With {.ID = JobProcess.ID,
                                                   .Description = JobProcess.Description}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal Statuses As IEnumerable(Of AdvantageFramework.Database.Entities.Status)) As Object

            LoadDataSourceView = (From Status In Statuses
                                  Select New With {.Code = Status.Code,
                                                   .Description = Status.Description}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal ContactTypes As IEnumerable(Of AdvantageFramework.Database.Entities.ContactType)) As Object

            LoadDataSourceView = (From ContactType In ContactTypes
                                  Select New With {.ID = ContactType.ID,
                                                   .Description = ContactType.Description}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal Countries As IEnumerable(Of AdvantageFramework.Database.Entities.Country)) As Object

            LoadDataSourceView = (From Country In Countries
                                  Select New With {.ID = Country.ID,
                                                   .Name = Country.Name}).ToList

        End Function
        Private Function LoadDataSourceView(ByVal MediaPlanTemplateHeaders As IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)) As Object

            LoadDataSourceView = (From MediaPlanTemplateHeader In MediaPlanTemplateHeaders
                                  Select New With {.ID = MediaPlanTemplateHeader.ID,
                                                   .Description = MediaPlanTemplateHeader.Description}).ToList

        End Function
        Protected Function LoadDataSourceView(ByVal Value As Object) As Object

            'objects
            Dim View As Object = Nothing

            If TypeOf Value Is IEnumerable Then

                If TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Job) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Job)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Views.Employee) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Views.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Employee) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Employee)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Client) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Client) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Client)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Role) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Role)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.SalesTax)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Office) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Office) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Office)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Vendor) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Vendor) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Vendor)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Product) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Core.Product) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Core.Product)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Security.Database.Entities.Report)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Bank) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Bank)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ImportTemplate)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.IndirectCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.InvoiceCategory)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.RecordSource) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.RecordSource)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.JobProcess)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Status) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Status)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.ContactType) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.ContactType)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.Country) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.Country)))

                ElseIf TypeOf Value Is IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader) Then

                    View = LoadDataSourceView(DirectCast(Value, IEnumerable(Of AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)))

                Else

                    View = AdvantageFramework.WinForm.Presentation.Controls.LoadComboBoxDataSourceView(Value)

                End If

            Else

                View = Value

            End If

            LoadDataSourceView = View

        End Function
        Protected Sub LoadDataSource(ByRef Value As Object)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                Me.BeginUpdate()

                LoadBookmarks()

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = LoadDataSourceView(Value)

                If Value IsNot Nothing Then

                    If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                        If Me.DisplayMember = "" Then

                            Me.SetControlType()

                        End If

                        LoadExtraComboItem(_ExtraComboBoxItem, BindingSource)

                    End If

                End If

                MyBase.DataSource = BindingSource

                SetBookmarks()

                If Me.DisplayMember = "" Then

                    Me.SetControlType()

                End If

                Me.ClearChanged()

                Me.EndUpdate()

            End If

        End Sub
        Protected Sub LoadExtraComboItem(ByVal ExtraComboItem As ExtraComboBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", Nothing, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

        End Sub
        Public Sub AddComboItemToExistingDataSource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean, Optional ByVal PostionIndex As Integer = -1)

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.DisplayMember, Me.ValueMember, DisplayValue, Value, InsertInFirstPosition, False, _AddedItemsToDataSource, PostionIndex)

        End Sub
        Public Sub RemoveAddedItemsFromDataSource()

            RemoveAddedItemsFromDataSource(Me.DataSource)

        End Sub
        Private Sub RemoveAddedItemsFromDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource)

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

            Try

                For Each AddedItem In _AddedItemsToDataSource

                    BindingSource.Remove(AddedItem)

                Next

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

        End Sub
        Protected Friend Function Validate(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True

            Try

                If _IsRequired Then

                    If Me.GetSelectedValue Is Nothing Then

                        If _DisplayName = "" Then

                            ErrorMessage = AdvantageFramework.StringUtilities.GetNameAsWords(_ControlType.ToString) & " is required."

                        Else

                            ErrorMessage = _DisplayName & " is required."

                        End If

                        IsValid = False

                    End If

                End If

                Select Case _ControlType

                    Case Else

                        If Me.Text <> "" AndAlso Me.GetSelectedValue Is Nothing AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.None.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.PleaseSelect.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.AgencyDefault.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.Open.ToString) & "]" Then

                            If _DisplayName = "" Then

                                ErrorMessage = "Please select a valid " & AdvantageFramework.StringUtilities.GetNameAsWords(_ControlType.ToString)

                            Else

                                ErrorMessage = "Please select a valid " & _DisplayName

                            End If

                            IsValid = False

                        End If

                End Select

            Catch ex As Exception
                IsValid = False
            Finally
                Validate = IsValid
            End Try

        End Function
        Protected Sub LoadBookmarks()

            If _BookmarkingEnabled AndAlso
                Me.SelectedItem IsNot Nothing Then

                _CurrentBookmark = Me.SelectedItem

            Else

                _CurrentBookmark = Nothing

            End If

        End Sub
        Protected Sub SetBookmarks()

            If _BookmarkingEnabled AndAlso
                _CurrentBookmark IsNot Nothing Then

                Me.SelectedItem = _CurrentBookmark

            End If

        End Sub
        Public Function HasASelectedValue() As Boolean

            'objects
            Dim DoesHaveASelectedValue As Boolean = False

            If Me.SelectedValue IsNot Nothing Then

                If Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                    DoesHaveASelectedValue = True

                Else

                    If Me.ExtraComboBoxItem = ExtraComboBoxItems.PleaseSelect Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.PleaseSelect) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.None Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.None) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.AgencyDefault) Then

                            DoesHaveASelectedValue = True

                        End If

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.Open Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.Open) Then

                            DoesHaveASelectedValue = True

                        End If

                    End If

                End If

            End If

            HasASelectedValue = DoesHaveASelectedValue

        End Function
        Public Function GetSelectedValue() As Object

            'objects
            Dim SelectedValue As Object = Nothing
            Dim SystemType As System.Type = Nothing

            If Me.HasASelectedValue Then

                Try

                    If _EntityDataType IsNot Nothing Then

                        If Nullable.GetUnderlyingType(_EntityDataType) IsNot Nothing Then

                            SystemType = Nullable.GetUnderlyingType(_EntityDataType)

                        Else

                            SystemType = _EntityDataType

                        End If

                        If SystemType = GetType(Short) OrElse SystemType = GetType(Integer) OrElse SystemType = GetType(Long) OrElse
                                SystemType = GetType(Decimal) OrElse SystemType = GetType(Single) OrElse SystemType = GetType(Double) Then

                            If IsNumeric(Me.SelectedValue) Then

                                SelectedValue = Convert.ChangeType(Me.SelectedValue, SystemType)

                            Else

                                SelectedValue = Me.SelectedValue

                            End If

                        Else

                            SelectedValue = Convert.ChangeType(Me.SelectedValue, SystemType)

                        End If

                    Else

                        SelectedValue = Me.SelectedValue

                    End If

                Catch ex As Exception
                    SelectedValue = Me.SelectedValue
                End Try

            End If

            GetSelectedValue = SelectedValue

        End Function
        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

            MyBase.OnResize(e)

            Me.SelectionLength = 0

        End Sub
        Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)

            Dim HandledMouseEventArgs As System.Windows.Forms.HandledMouseEventArgs = Nothing

            If _DisableMouseWheel Then

                HandledMouseEventArgs = DirectCast(e, System.Windows.Forms.HandledMouseEventArgs)

                HandledMouseEventArgs.Handled = True

            End If

        End Sub
        Private Sub ShowControl()

            If _ReadOnly Then

                _TextBox.Location = Me.Location
                _TextBox.Size = Me.Size
                _TextBox.Visible = _Visible AndAlso Me.Enabled
                MyBase.Visible = _Visible AndAlso Not Me.Enabled
                _TextBox.Text = Me.Text

            Else

                _TextBox.Visible = False
                MyBase.Visible = _Visible

            End If

        End Sub
        Private Sub AddTextbox()

            _TextBox.ReadOnly = True
            _TextBox.Location = Me.Location
            _TextBox.Size = Me.Size
            _TextBox.Dock = Me.Dock
            _TextBox.Anchor = Me.Anchor
            _TextBox.Enabled = Me.Enabled
            _TextBox.Visible = (_ReadOnly AndAlso _Visible AndAlso Me.Enabled)
            _TextBox.RightToLeft = Me.RightToLeft
            _TextBox.Font = Me.Font
            _TextBox.Text = Me.Text
            _TextBox.TabStop = False
            _TextBox.TabIndex = Me.TabIndex
            _TextBox.BackColor = System.Drawing.SystemColors.Control
            _TextBox.ByPassUserEntryChanged = True

        End Sub
        Public Shadows Sub Show()

            Me.Visible = True

        End Sub
        Public Shadows Sub Hide()

            Me.Visible = False

        End Sub
        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)

            MyBase.OnParentChanged(e)

            If Parent IsNot Nothing Then

                AddTextbox()
                _TextBox.Parent = Me.Parent

            End If

        End Sub
        Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)

            MyBase.OnSelectedIndexChanged(e)

            If Me.SelectedIndex = -1 Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub
        Protected Overrides Sub OnSelectedValueChanged(ByVal e As System.EventArgs)

            MyBase.OnSelectedValueChanged(e)

            If Me.SelectedValue Is Nothing Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub
        Protected Overrides Sub OnDropDownStyleChanged(ByVal e As System.EventArgs)

            MyBase.OnDropDownStyleChanged(e)

            _TextBox.Text = Me.Text

        End Sub
        Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)

            MyBase.OnFontChanged(e)

            _TextBox.Font = Me.Font

        End Sub
        Protected Overrides Sub OnDockChanged(ByVal e As System.EventArgs)

            MyBase.OnDockChanged(e)

            _TextBox.Dock = Me.Dock

        End Sub
        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)

            MyBase.OnEnabledChanged(e)

            ShowControl()

        End Sub
        Protected Overrides Sub OnRightToLeftChanged(ByVal e As System.EventArgs)

            MyBase.OnRightToLeftChanged(e)

            _TextBox.RightToLeft = Me.RightToLeft

        End Sub
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)

            MyBase.OnTextChanged(e)

            _TextBox.Text = Me.Text

        End Sub
        Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)

            MyBase.OnLocationChanged(e)

            _TextBox.Location = Me.Location

        End Sub
        Protected Overrides Sub OnTabIndexChanged(ByVal e As System.EventArgs)

            MyBase.OnTabIndexChanged(e)

            _TextBox.TabIndex = Me.TabIndex

        End Sub
        Public Function SelectSingleItemDataSource() As Boolean

            'objects
            Dim Selected As Boolean = False

            Try

                If Me.Items.Count = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                    Me.SelectedIndex = 1
                    Selected = True

                ElseIf Me.Items.Count = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                    Me.SelectedIndex = 0
                    Selected = True

                End If

            Catch ex As Exception
                Selected = False
            Finally
                SelectSingleItemDataSource = Selected
            End Try

        End Function
        Protected Sub SetUserEntryChanged()

            If _ByPassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If Me.DroppedDown = False AndAlso _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = False Then

                    Me.FindForm.SelectNextControl(Me, True, True, True, True)

                ElseIf e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

        End Sub

#Region "  Control Event Handlers "

        Private Sub ComboBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged

            'objects
            'Dim ParentForm As System.Windows.Forms.Form = Nothing
            'Dim ItemIndex As Integer = -1

            'If Me.Focused AndAlso Me.SelectedItem Is Nothing Then

            '    ItemIndex = Me.FindStringExac(Me.Text)

            '    If ItemIndex <> -1 Then

            '        Me.SelectedItem = Me.Items(ItemIndex)

            '        SetUserEntryChanged()

            '    End If

            '    ParentForm = Me.FindForm

            '    If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

            '        DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me)

            '    End If

            'End If

        End Sub
        Private Sub ComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectionChangeCommitted

            'SetUserEntryChanged()

        End Sub
        Private Sub ComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles Me.SelectedValueChanged

            SetUserEntryChanged()

        End Sub
        Private Sub ComboBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

            _TextBox.Size = Me.Size

        End Sub
        Private Sub ComboBox_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Validating

            Dim ParentForm As System.Windows.Forms.Form = Nothing
            Dim Item As Object = Nothing

            If Me.SelectedItem Is Nothing AndAlso Me.Text <> "" Then

                If Me.ValueMember = "Code" Then

                    For ItemIndex = 0 To Me.Items.Count - 1

                        If Me.Items(ItemIndex).Code.ToString.ToUpper = Me.Text.ToUpper Then

                            Me.SelectedItem = Me.Items(ItemIndex)

                            SetUserEntryChanged()

                            ParentForm = Me.FindForm

                            If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                                DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me)

                            End If

                            Exit For

                        End If

                    Next

                ElseIf _AutoFindItemInDataSource Then

                    Try

                        Item = AdvantageFramework.WinForm.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, Me.Text)

                    Catch ex As Exception
                        Item = Nothing
                    End Try

                    If Item IsNot Nothing Then

                        Me.SelectedItem = Item

                        SetUserEntryChanged()

                        ParentForm = Me.FindForm

                        If ParentForm IsNot Nothing AndAlso TypeOf ParentForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                            DirectCast(ParentForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ValidateControl(Me)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ComboBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

            Me.DroppedDown = False

        End Sub

#End Region

#Region "  Custom Control Event Handlers "


#End Region

#End Region

    End Class

End Namespace
