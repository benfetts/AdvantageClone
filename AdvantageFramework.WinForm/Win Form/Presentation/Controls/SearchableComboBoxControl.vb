Namespace WinForm.Presentation.Controls

    Public Class SearchableComboBox
        Inherits DevExpress.XtraEditors.SearchLookUpEdit
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserControl

        Public Event ReloadComboBox()
        Public Event QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean)
        Public Event DataSourceChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ExtraComboBoxItems As Short
            [Nothing] = 0
            PleaseSelect = -1
            None = -2
            AgencyDefault = -3
            All = -4
        End Enum

        Public Enum [Type]
            [Default]
            Employee
            Client
            Office
            Division
            Vendor
            Product
            Market
            GeneralLedgerAccount
            PrintSpecRegion
            PostPeriod
            Job
            InvoiceNumber
            PurchaseOrder
            Industry
            Specialty
            Source
            Rating
            VendorContact
            EmployeesIncludingTerminated
            Location
            JobComponent
            Campaign
            DepartmentTeam
            CheckNumber
            Bank
            Status
            SalesClass
            AdNumber
            Account
            Task
            ClientContact
            Phase
            [Function]
            TaskStatus
            Role
            EnumObjects
            BillingApprovalBatch
            TaxCode
            ServiceFeeType
            JobServiceFeeContract
            VendorServiceTax
            OfficeOverheadSet
            CheckFormat
            CurrencyCode
            ExportSystem
            ContactType
            EmployeeTitle
            POApprovalRule
            User
            VendorTerm
            AdSize
            CustomReport
            ResourceType
            AlertGroup
            PaymentType
            ClientType1
            ClientType2
            ClientType3
            ClientWebsite
            AdServerType
            NielsenTVStation
            NielsenRadioStation
            AlertAssignmentTemplate
            AlertAssignmentState
            NCCTVSyscode
            ClientDiscount
            ComscoreTVStation
            MediaPlanEstimateTemplate
            MediaDemographic
            QuickbookCustomer
            CheckRegister
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As SearchableComboBox.Type = SearchableComboBox.Type.Default
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
        Protected _BypassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _HasValidDataSource As Boolean = False
        Protected _ShowAllRowsOnInitialSearch As Boolean = False
        Protected _ActiveFilterString As String = ""
        Protected _ActiveFilterEnabled As Boolean = False
        Protected _HideValueMemberColumn As Boolean = False
        Protected _UseAlternateView As Boolean = False
        Protected _SecurityEnabled As Boolean = True
        Protected _AutoFillMode As Boolean = False
        Protected _TabOnEnter As Boolean = True
        Protected _ReadOnly As Boolean = False
        Protected _TextBox As AdvantageFramework.WinForm.Presentation.Controls.TextBox = Nothing
        Protected _Visible As Boolean = True

#End Region

#Region " Properties "

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
        Public Property ControlType() As SearchableComboBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SearchableComboBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.Properties.DataSource
            End Get
            Set(ByVal value As Object)
                _IsDataSourceLoading = True
                LoadDataSource(value)
                _IsDataSourceLoading = False
            End Set
        End Property
        Public Property ExtraComboBoxItem() As ExtraComboBoxItems
            Get
                ExtraComboBoxItem = _ExtraComboBoxItem
            End Get
            Set(ByVal value As ExtraComboBoxItems)

                _ExtraComboBoxItem = value

                If _ExtraComboBoxItem = ExtraComboBoxItems.PleaseSelect Then

                    Me.Properties.ShowClearButton = True

                Else

                    Me.Properties.ShowClearButton = False

                End If

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
        Public Overloads Property ErrorIconAlignment() As System.Windows.Forms.ErrorIconAlignment
            Get
                ErrorIconAlignment = _ErrorIconAlignment
            End Get
            Set(ByVal value As System.Windows.Forms.ErrorIconAlignment)
                _ErrorIconAlignment = value
            End Set
        End Property
        Public Shadows Property SelectedValue As Object
            Get
                SelectedValue = MyBase.EditValue
            End Get
            Set(ByVal value As Object)

                Dim Failed As Boolean = False
                Dim Entity As Object = Nothing

                Try

                    MyBase.EditValue = value

                Catch ex As Exception

                End Try

                If _Session IsNot Nothing AndAlso Me.DataSource IsNot Nothing AndAlso
                        CType(Me.DataSource, System.Windows.Forms.BindingSource).DataSource Is Nothing AndAlso
                        value IsNot Nothing Then

                    LoadMinimalDataSource(value)

                ElseIf _Session IsNot Nothing AndAlso
                        Not _HasValidDataSource AndAlso
                        value IsNot Nothing Then

                    LoadMinimalDataSource(value)

                ElseIf TypeOf Me.DataSource Is System.Windows.Forms.BindingSource AndAlso
                                        CType(Me.DataSource, System.Windows.Forms.BindingSource).DataSource IsNot Nothing AndAlso
                                        CType(Me.DataSource, System.Windows.Forms.BindingSource).Count > 0 AndAlso
                                        Me.Properties.DisplayMember <> "" Then

                    Try

                        If AdvantageFramework.BaseClasses.ApplyWhere(CType(Me.DataSource, System.Windows.Forms.BindingSource).List.AsQueryable, Me.Properties.ValueMember, BaseClasses.OperatorTypes.IsEqualTo, MyBase.EditValue).Cast(Of Object).Any = False Then

                            Me.EditValue = Nothing

                            Failed = True

                        End If

                    Catch ex As Exception

                    End Try

                ElseIf TypeOf Me.DataSource Is System.Windows.Forms.BindingSource AndAlso
                       CType(Me.DataSource, System.Windows.Forms.BindingSource).DataSource IsNot Nothing AndAlso
                       CType(Me.DataSource, System.Windows.Forms.BindingSource).Count = 0 Then

                    Me.EditValue = Nothing
                    Failed = True

                End If

                If Failed Then

                    Try

                        If ((value IsNot Nothing OrElse value <> Nothing) AndAlso Me.HasASelectedValue = False AndAlso _AddInactiveItemsOnSelectedValue) Then

                            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                                If CType(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormShown AndAlso _Session IsNot Nothing Then

                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Select Case _ControlType

                                            Case SearchableComboBox.Type.Office

                                                Entity = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, value)

                                            Case SearchableComboBox.Type.Employee

                                                Entity = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, value)

                                            Case SearchableComboBox.Type.Vendor

                                                Entity = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, value)

                                            Case SearchableComboBox.Type.GeneralLedgerAccount

                                                Entity = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, value)

                                            Case SearchableComboBox.Type.Client

                                                Entity = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, value)

                                            Case Type.Job

                                                Entity = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, value)

                                            Case Type.Bank

                                                Entity = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, value)

                                            Case Type.SalesClass

                                                Entity = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, value)

                                            Case Type.PaymentType

                                                Entity = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.LoadByID(DbContext, value)

                                            Case Type.ClientType1

                                                Entity = AdvantageFramework.Database.Procedures.ClientType1.LoadByID(DbContext, value).FirstOrDefault

                                            Case Type.ClientType2

                                                Entity = AdvantageFramework.Database.Procedures.ClientType2.LoadByID(DbContext, value).FirstOrDefault

                                            Case Type.ClientType3

                                                Entity = AdvantageFramework.Database.Procedures.ClientType3.LoadByID(DbContext, value).FirstOrDefault

                                            Case Type.Market

                                                Entity = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, value)

                                        End Select

                                        If Entity IsNot Nothing Then

                                            If TypeOf Entity Is AdvantageFramework.Database.Entities.Job Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.Job).ToString(True), value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Bank Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.Bank).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.SalesClass Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.SalesClass).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.CashReceiptPaymentType Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.CashReceiptPaymentType).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.ClientType1 Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.ClientType1).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.ClientType2 Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.ClientType2).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.ClientType3 Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.ClientType3).Description, value, False)

                                            ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Market Then

                                                Me.AddComboItemToExistingDataSource(DirectCast(Entity, AdvantageFramework.Database.Entities.Market).Description, value, False)

                                            Else

                                                Me.AddComboItemToExistingDataSource(Entity.ToString, value, False)

                                            End If

                                            ' Me.RefreshEditValue()
                                            MyBase.EditValue = value

                                        Else

                                            Try

                                                If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                                                    Me.Properties.View.FocusedRowHandle = 0

                                                Else

                                                    Me.Properties.View.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle

                                                End If

                                            Catch ex As Exception

                                            End Try

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
                _BypassUserEntryChanged = value
            End Set
        End Property
        Public Property ActiveFilterString As String
            Get
                ActiveFilterString = _ActiveFilterString
            End Get
            Set(ByVal value As String)
                _ActiveFilterString = value
                _ActiveFilterEnabled = True
            End Set
        End Property
        Public WriteOnly Property HideValueMemberColumn As Boolean
            Set(value As Boolean)
                _HideValueMemberColumn = value
            End Set
        End Property
        Public WriteOnly Property UseAlternateView As Boolean
            Set(value As Boolean)
                _UseAlternateView = value
            End Set
        End Property
        Public Shadows Property Enabled As Boolean
            Get
                Enabled = MyBase.Enabled
            End Get
            Set(value As Boolean)

                If _SecurityEnabled Then

                    MyBase.Enabled = value

                Else

                    MyBase.Enabled = False

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
        Public Property AutoFillMode As Boolean
            Get
                AutoFillMode = _AutoFillMode
            End Get
            Set(value As Boolean)
                _AutoFillMode = value
            End Set
        End Property
        Public Overrides Property EnterMoveNextControl As Boolean
            Get
                Return _TabOnEnter
            End Get
            Set(value As Boolean)
                _TabOnEnter = value
            End Set
        End Property
        Public Overloads Property [ReadOnly] As Boolean
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

#End Region

#Region " Methods "

        Public Sub New()

            'Me.Properties.View = New AdvantageFramework.WinForm.Presentation.Controls.GridView(True)
            'DirectCast(Me.Properties.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).ControlType = DataGridView.Type.NonEditableGrid
            'DirectCast(Me.Properties.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).OptionsView.ShowFooter = False
            'DirectCast(Me.Properties.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).OptionsView.ShowViewCaption = False

            Me.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.Properties.PopupSizeable = True

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DoubleBuffered = True

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
        Public Sub SetPropertySettings(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor)

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing

            If PropertyDescriptor IsNot Nothing Then

                _DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)
                _EntityDataType = PropertyDescriptor.PropertyType

                Try

                    EntityAttribute = PropertyDescriptor.Attributes.OfType(Of AdvantageFramework.BaseClasses.Attributes.EntityAttribute).SingleOrDefault

                Catch ex As Exception
                    EntityAttribute = Nothing
                Finally

                    If EntityAttribute IsNot Nothing Then

                        SetRequired(EntityAttribute.IsRequired)

                    End If

                End Try

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

                Me.Properties.Appearance.BackColor = Drawing.Color.Cyan

            Else

                Me.Properties.Appearance.BackColor = Drawing.Color.White

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

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub LoadMinimalDataSource(ByVal value As Object)

            Dim Objects As IEnumerable(Of Object) = Nothing
            Dim ValueString As String = ""

            Me.DataSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case _ControlType

                    Case SearchableComboBox.Type.GeneralLedgerAccount

                        Try

                            ValueString = value.ToString

                        Catch ex As Exception
                            ValueString = ""
                        End Try

                        Objects = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                   Where GeneralLedgerAccount.Code = ValueString
                                   Select GeneralLedgerAccount).ToList

                        LoadDataSource(Objects)

                        If Objects.Count = 0 Then

                            MyBase.EditValue = Nothing

                        End If

                        _HasValidDataSource = False

                    Case SearchableComboBox.Type.Vendor

                        Try

                            ValueString = value.ToString

                        Catch ex As Exception
                            ValueString = ""
                        End Try

                        Objects = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                   Where Vendor.Code = ValueString
                                   Select Vendor).ToList

                        LoadDataSource(Objects)

                        If Objects.Count = 0 Then

                            MyBase.EditValue = Nothing

                        End If

                        _HasValidDataSource = False

                End Select

            End Using

        End Sub
        Protected Sub SetControlType()

            Me.Properties.View.Columns.Clear()

            Select Case _ControlType

                Case SearchableComboBox.Type.Default

                    Me.Properties.ValueMember = ""
                    Me.Properties.DisplayMember = ""
                    Me.Properties.NullText = ""

                Case SearchableComboBox.Type.Employee

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Employee"

                Case SearchableComboBox.Type.Client

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Client"

                Case SearchableComboBox.Type.Office

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Office"

                Case SearchableComboBox.Type.Division

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Division"

                Case SearchableComboBox.Type.Vendor

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Vendor"

                Case SearchableComboBox.Type.Product

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Product"

                Case SearchableComboBox.Type.Market

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Market"

                Case SearchableComboBox.Type.GeneralLedgerAccount

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select General Ledger Account"

                Case SearchableComboBox.Type.PrintSpecRegion

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Region"

                Case SearchableComboBox.Type.PostPeriod

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Post Period"

                Case SearchableComboBox.Type.Job

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Job"

                Case SearchableComboBox.Type.InvoiceNumber

                    Me.Properties.DisplayMember = "InvoiceNumber"
                    Me.Properties.ValueMember = "InvoiceNumber"
                    Me.Properties.NullText = "Select Invoice"

                Case SearchableComboBox.Type.PurchaseOrder

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select PO"

                Case SearchableComboBox.Type.Industry

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Industry"

                Case SearchableComboBox.Type.Specialty

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Specialty"

                Case SearchableComboBox.Type.Source

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Source"

                Case SearchableComboBox.Type.Rating

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Rating"

                Case SearchableComboBox.Type.VendorContact

                    Me.Properties.DisplayMember = "FullName"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Vendor Contact"

                Case SearchableComboBox.Type.EmployeesIncludingTerminated

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Employee"

                Case SearchableComboBox.Type.Location

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Location"

                Case SearchableComboBox.Type.JobComponent

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Job Component"

                Case SearchableComboBox.Type.Campaign

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Campaign"

                Case SearchableComboBox.Type.DepartmentTeam

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Department / Team"

                Case SearchableComboBox.Type.CheckNumber

                    Me.Properties.DisplayMember = "CheckNumber"
                    Me.Properties.ValueMember = "CheckNumber"
                    Me.Properties.NullText = "Select Check Number"

                Case SearchableComboBox.Type.Bank

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Bank"

                Case SearchableComboBox.Type.Status

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Status"

                Case SearchableComboBox.Type.SalesClass

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Sales Class"

                Case SearchableComboBox.Type.AdNumber

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Ad Number"

                Case SearchableComboBox.Type.Account

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Account"

                Case SearchableComboBox.Type.Task

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Task"

                Case SearchableComboBox.Type.ClientContact

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Client Contact"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.Phase

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Phase"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.Function

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Function"

                Case SearchableComboBox.Type.TaskStatus

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Task Status"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.Role

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Role"

                Case SearchableComboBox.Type.EnumObjects

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select"

                Case SearchableComboBox.Type.BillingApprovalBatch

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Batch"

                Case SearchableComboBox.Type.TaxCode

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "TaxCode"
                    Me.Properties.NullText = "Select Tax Code"

                Case SearchableComboBox.Type.ServiceFeeType

                    Me.Properties.DisplayMember = "CodeAndDescription"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Service Fee Type"

                Case SearchableComboBox.Type.JobServiceFeeContract

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Service Fee Contract"

                Case SearchableComboBox.Type.VendorServiceTax

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "CodeAndDescription"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Vendor Service Tax"

                Case SearchableComboBox.Type.OfficeOverheadSet

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Overhead Set"

                Case SearchableComboBox.Type.CheckFormat

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Number"
                    Me.Properties.NullText = "Select Check Format"

                Case SearchableComboBox.Type.CurrencyCode

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Currency Code"

                Case SearchableComboBox.Type.ExportSystem

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Label"
                    Me.Properties.ValueMember = "Name"
                    Me.Properties.NullText = "Select Export System"

                Case SearchableComboBox.Type.ContactType

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Contact Type"

                Case SearchableComboBox.Type.EmployeeTitle

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Employee Title"

                Case SearchableComboBox.Type.POApprovalRule

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select PO Approval Rule"

                Case SearchableComboBox.Type.User

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select User"

                Case SearchableComboBox.Type.VendorTerm

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Term"

                Case SearchableComboBox.Type.AdSize

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Ad Size"

                Case SearchableComboBox.Type.CustomReport

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Report"

                Case SearchableComboBox.Type.ResourceType

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Resource Type"

                Case SearchableComboBox.Type.AlertGroup

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Alert Group"

                Case SearchableComboBox.Type.PaymentType

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Payment Type"

                Case SearchableComboBox.Type.ClientType1

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Client Type1"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.ClientType2

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Client Type2"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.ClientType3

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Client Type3"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.ClientWebsite

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Website"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.AdServerType

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Ad Server"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.NielsenTVStation

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select TV Station"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.NielsenRadioStation

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ComboID"
                    Me.Properties.NullText = "Select Radio Station"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.AlertAssignmentTemplate

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Alert Assignment Template"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.AlertAssignmentState

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Alert Assignment State"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.NCCTVSyscode

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Syscode"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.ClientDiscount

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "Code"
                    Me.Properties.NullText = "Select Client Discount"

                Case SearchableComboBox.Type.ComscoreTVStation

                    Me.HideValueMemberColumn = False
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select TV Station"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.MediaPlanEstimateTemplate

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Template"

                Case SearchableComboBox.Type.MediaDemographic

                    Me.Properties.DisplayMember = "Description"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Demographic"

                Case SearchableComboBox.Type.QuickbookCustomer

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "DisplayName"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Customer"

<<<<<<< HEAD
=======
                Case SearchableComboBox.Type.Network

                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Network"

                Case SearchableComboBox.Type.NielsenTVPuertoRicoStation

                    Me.HideValueMemberColumn = True
                    Me.Properties.DisplayMember = "Name"
                    Me.Properties.ValueMember = "ID"
                    Me.Properties.NullText = "Select Puerto Rico TV Station"
                    _HideValueMemberColumn = True

                Case SearchableComboBox.Type.CheckRegister

                    Me.Properties.DisplayMember = "CheckRunID"
                    Me.Properties.ValueMember = "CheckRunID"
                    Me.Properties.NullText = "Select Check Run ID"

>>>>>>> 114af89e (** MERGE DN **)
            End Select

        End Sub
        'Protected Function LoadDataSourceView(ByVal Locations As IEnumerable(Of AdvantageFramework.Database.Entities.Location)) As Object

        '    LoadDataSourceView = (From Location In Locations.ToList _
        '                          Select [ID] = Location.ID, _
        '                                 [Name] = Location.Name).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal VendorContacts As IEnumerable(Of AdvantageFramework.Database.Entities.VendorContact)) As Object

        '    LoadDataSourceView = (From VendorContact In VendorContacts.ToList _
        '                              Select [Code] = VendorContact.Code, _
        '                                     [FullName] = VendorContact.FirstName & If(VendorContact.MiddleInitial <> "", VendorContact.MiddleInitial & ". ", " ") & VendorContact.LastName).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod)) As Object

        '    LoadDataSourceView = (From PostPeriod In PostPeriods.ToList _
        '                          Select [Code] = PostPeriod.Code, _
        '                                 [Description] = PostPeriod.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal GeneralLedgerAccounts As IEnumerable(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)) As Object

        '    LoadDataSourceView = (From GeneralLedgerAccount In GeneralLedgerAccounts.ToList _
        '                          Select [Code] = GeneralLedgerAccount.Code, _
        '                                 [Description] = GeneralLedgerAccount.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal JobComponents As IEnumerable(Of AdvantageFramework.Database.Entities.JobComponent)) As Object

        '    If ControlType = Type.JobComponent Then

        '        LoadDataSourceView = (From JobComponent In JobComponents _
        '                              Select JobComponent.Number,
        '                                     JobComponent.Description).ToList.Select(Function(JobComponent) New With {.Number = JobComponent.Number & "",
        '                                                                                                              .Description = JobComponent.Number & "- " & JobComponent.Description}).ToList

        '    Else

        '        LoadDataSourceView = (From JobComponent In JobComponents.ToList _
        '                              Select [JobComponent] = JobComponent.ToString(True, False), _
        '                                     [Description] = JobComponent.ToString(True, True)).ToList

        '    End If

        'End Function
        'Protected Function LoadDataSourceView(ByVal Jobs As IEnumerable(Of AdvantageFramework.Database.Entities.Job)) As Object

        '    LoadDataSourceView = (From Job In Jobs _
        '                          Select New With {.Number = Job.Number, _
        '                                           .Description = Job.Number & " - " & Job.Description}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Markets As IEnumerable(Of AdvantageFramework.Database.Entities.Market)) As Object

        '    LoadDataSourceView = (From Market In Markets.ToList _
        '                          Select [Code] = Market.Code, _
        '                                 [Description] = Market.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Divisions As IEnumerable(Of AdvantageFramework.Database.Entities.Division)) As Object

        '    LoadDataSourceView = (From Division In Divisions.ToList _
        '                          Select [Code] = Division.Code, _
        '                                 [Name] = Division.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee)) As Object

        '    LoadDataSourceView = (From Employee In Employees _
        '                          Select New With {.Code = Employee.Code, _
        '                                           .FullName = Employee.ToString}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Classes.Employee)) As Object

        '    LoadDataSourceView = (From Employee In Employees.ToList _
        '                                Select [Code] = Employee.Code, _
        '                                       [FullName] = Employee.Name, _
        '                                       [Terminated] = Employee.Terminated).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Clients As IEnumerable(Of AdvantageFramework.Database.Entities.Client)) As Object

        '    LoadDataSourceView = (From Client In Clients.ToList _
        '                          Select [Code] = Client.Code,
        '                                 [Name] = Client.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Offices As IEnumerable(Of AdvantageFramework.Database.Entities.Office)) As Object

        '    LoadDataSourceView = (From Office In Offices.ToList _
        '                          Select Office.Code,
        '                                 [Name] = Office.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Vendors As IEnumerable(Of AdvantageFramework.Database.Entities.Vendor)) As Object

        '    LoadDataSourceView = (From Vendor In Vendors _
        '                          Select Vendor.Code,
        '                                 Vendor.Name) _
        '                          .Select(Function(Entity) New With {.Code = Entity.Code, _
        '                                                             .Name = Entity.Name}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Products As IEnumerable(Of AdvantageFramework.Database.Entities.Product)) As Object

        '    LoadDataSourceView = (From Product In Products.ToList _
        '                          Select [Code] = Product.Code,
        '                                 [Name] = Product.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal ProductViews As IEnumerable(Of AdvantageFramework.Database.Views.ProductView)) As Object

        '    LoadDataSourceView = (From ProductView In ProductViews.ToList _
        '                          Select [Code] = ProductView.ProductCode,
        '                                 [Name] = ProductView.ProductCode & " - " & ProductView.ProductDescription).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal PrintSpecRegions As IEnumerable(Of AdvantageFramework.Database.Entities.PrintSpecRegion)) As Object

        '    LoadDataSourceView = (From PrintSpecRegion In PrintSpecRegions.ToList _
        '                          Select [Code] = PrintSpecRegion.Code, _
        '                                 [Description] = PrintSpecRegion.ToString).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal AccountPayables As IEnumerable(Of AdvantageFramework.Database.Entities.AccountPayable)) As Object

        '    LoadDataSourceView = (From AccountPayable In AccountPayables.ToList _
        '                          Select [InvoiceNumber] = AccountPayable.InvoiceNumber,
        '                                 [InvoiceDate] = AccountPayable.InvoiceDate,
        '                                 [Description] = AccountPayable.InvoiceDescription,
        '                                 [IsDeleted] = CBool(AccountPayable.Deleted.GetValueOrDefault(0))).OrderByDescending(Function(ap) ap.InvoiceDate).ThenByDescending(Function(ap) ap.InvoiceNumber).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal PurchaseOrders As IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)) As Object

        '    LoadDataSourceView = (From PurchaseOrder In PurchaseOrders.ToList _
        '                          Select [Number] = PurchaseOrder.Number,
        '                                 [Description] = PurchaseOrder.Description).OrderByDescending(Function(PO) PO.Number).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Industries As IEnumerable(Of AdvantageFramework.Database.Entities.Industry)) As Object

        '    LoadDataSourceView = (From Industry In Industries _
        '                          Select Industry.ID,
        '                                 Industry.Description) _
        '                          .Select(Function(Entity) New With {.ID = Entity.ID, _
        '                                                             .Description = Entity.Description}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Specialties As IEnumerable(Of AdvantageFramework.Database.Entities.Specialty)) As Object

        '    LoadDataSourceView = (From Specialty In Specialties _
        '                          Select Specialty.ID,
        '                                 Specialty.Description) _
        '                          .Select(Function(Entity) New With {.ID = Entity.ID, _
        '                                                             .Description = Entity.Description}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Sources As IEnumerable(Of AdvantageFramework.Database.Entities.Source)) As Object

        '    LoadDataSourceView = (From Source In Sources _
        '                          Select Source.ID,
        '                                 Source.Description) _
        '                          .Select(Function(Entity) New With {.ID = Entity.ID, _
        '                                                             .Description = Entity.Description}).ToList

        'End Function
        'Protected Function LoadDataSourceView(ByVal Ratings As IEnumerable(Of AdvantageFramework.Database.Entities.Rating)) As Object

        '    LoadDataSourceView = (From Rating In Ratings _
        '                          Select Rating.ID,
        '                                 Rating.Description) _
        '                          .Select(Function(Entity) New With {.ID = Entity.ID, _
        '                                                             .Description = Entity.Description}).ToList

        'End Function
        Protected Sub LoadDataSource(ByRef Value As Object)

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                LoadBookmarks()

                BindingSource = New System.Windows.Forms.BindingSource

                If _UseAlternateView = True Then

                    BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceAlternateView(Value)

                Else

                    BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Value)

                End If

                If Value IsNot Nothing Then

                    _HasValidDataSource = True

                    If _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                        If Me.Properties.DisplayMember = "" Then

                            Me.SetControlType()

                        End If

                        LoadExtraComboItem(_ExtraComboBoxItem, BindingSource)

                    End If

                Else

                    _HasValidDataSource = False

                End If

                MyBase.Properties.DataSource = BindingSource

                MyBase.Properties.View.BestFitColumns()

                SetBookmarks()

                If Me.Properties.DisplayMember = "" Then

                    Me.SetControlType()

                End If

                Me.ClearChanged()

                RaiseEvent DataSourceChangedEvent()

            End If

        End Sub
        Protected Sub LoadExtraComboItem(ByVal ExtraComboItem As ExtraComboBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault Then

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", Nothing, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

            Me.Properties.NullText = "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]"

        End Sub
        Public Sub AddComboItemToExistingDataSource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean)

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.Properties.DisplayMember, Me.Properties.ValueMember, DisplayValue, Value, InsertInFirstPosition, False, _AddedItemsToDataSource)

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

                    Case Type.InvoiceNumber


                    Case Else

                        If Me.Text <> "" AndAlso Me.GetSelectedValue Is Nothing AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.None.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.PleaseSelect.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.AgencyDefault.ToString) & "]" AndAlso
                                Me.Text <> "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboBoxItems.All.ToString) & "]" AndAlso
                                Me.Text <> Me.Properties.NullText Then

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
                Me.EditValue IsNot Nothing Then

                _CurrentBookmark = Me.EditValue

            Else

                _CurrentBookmark = Nothing

            End If

        End Sub
        Protected Sub SetBookmarks()

            If _BookmarkingEnabled AndAlso
                _CurrentBookmark IsNot Nothing Then

                Me.EditValue = _CurrentBookmark

            End If

        End Sub
        Public Function HasASelectedValue() As Boolean

            'objects
            Dim DoesHaveASelectedValue As Boolean = False

            If Me.EditValue IsNot Nothing Then ' Me.Properties.View.FocusedRowHandle > -1 Then

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

                    ElseIf Me.ExtraComboBoxItem = ExtraComboBoxItems.All Then

                        If IsNumeric(Me.SelectedValue) = False OrElse (IsNumeric(Me.SelectedValue) AndAlso Me.SelectedValue <> ExtraComboBoxItems.All) Then

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
        Public Function GetSelectedRowCellValue(ByVal FieldName As String) As Object

            'objects
            Dim RowCellValue As Object = Nothing

            If Me.HasASelectedValue Then

                For RowHandle = 0 To Me.Properties.View.RowCount - 1

                    Try

                        If Me.Properties.View.GetRowCellValue(RowHandle, Me.Properties.ValueMember.ToString) = Me.GetSelectedValue Then

                            If Me.Properties.View.Columns(FieldName) IsNot Nothing Then

                                RowCellValue = Me.Properties.View.GetRowCellValue(RowHandle, FieldName)
                                Exit For

                            End If

                        End If

                    Catch ex As Exception
                        RowCellValue = Nothing
                    End Try

                Next

            End If

            GetSelectedRowCellValue = RowCellValue

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
        Public Function SelectSingleItemDataSource() As Boolean

            'objects
            Dim Selected As Boolean = False
            Dim RowCount As Integer = Nothing
            Dim DataSource As IEnumerable = Nothing
            Dim SelectedItem As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                If Me.DataSource IsNot Nothing Then

                    If TypeOf Me.DataSource Is System.Windows.Forms.BindingSource Then

                        Try

                            DataSource = DirectCast(DirectCast(Me.DataSource, System.Windows.Forms.BindingSource).DataSource, IEnumerable)

                        Catch ex As Exception
                            DataSource = Nothing
                        End Try

                        If DataSource IsNot Nothing Then

                            RowCount = (From Item In DataSource
                                        Select Item).Count

                            If RowCount = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                                Try

                                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties((From Item In DataSource Select Item).FirstOrDefault).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = Me.Properties.ValueMember).SingleOrDefault

                                Catch ex As Exception
                                    PropertyDescriptor = Nothing
                                End Try

                                If PropertyDescriptor IsNot Nothing Then

                                    For Each Item In DataSource

                                        If Not (IsNumeric(PropertyDescriptor.GetValue(Item)) AndAlso PropertyDescriptor.GetValue(Item) = Me.ExtraComboBoxItem) Then

                                            SelectedItem = Item
                                            Exit For

                                        End If

                                    Next

                                End If

                            ElseIf RowCount = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                                SelectedItem = (From Item In DataSource
                                                Select Item).SingleOrDefault

                                Try

                                    PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(SelectedItem).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = Me.Properties.ValueMember).SingleOrDefault

                                Catch ex As Exception
                                    PropertyDescriptor = Nothing
                                End Try

                            End If

                            If PropertyDescriptor IsNot Nothing Then

                                Me.Properties.View.ClearSelection()
                                Me.SelectedValue = PropertyDescriptor.GetValue(SelectedItem)
                                Selected = True

                            End If

                        End If

                    End If

                End If

                'If Me.Properties.View.RowCount = 2 AndAlso Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                '    Me.Properties.View.SelectRow(1)
                '    Selected = True

                'ElseIf Me.Properties.View.RowCount = 1 AndAlso Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing Then

                '    Me.Properties.View.SelectRow(0)
                '    Selected = True

                'End If

            Catch ex As Exception
                Selected = False
            Finally
                SelectSingleItemDataSource = Selected
            End Try

        End Function
        Protected Overrides Sub OnKeyDown(e As Windows.Forms.KeyEventArgs)

            If _TabOnEnter Then

                If e.KeyCode = System.Windows.Forms.Keys.Enter AndAlso e.Shift = True Then

                    Me.FindForm.SelectNextControl(Me, False, True, True, True)

                End If

            End If

            MyBase.OnKeyDown(e)

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
        Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)

            MyBase.OnEnabledChanged(e)

            ShowControl()

        End Sub
        Protected Overrides Sub OnParentChanged(ByVal e As System.EventArgs)

            MyBase.OnParentChanged(e)

            If Parent IsNot Nothing Then

                AddTextbox()
                _TextBox.Parent = Me.Parent

            End If

        End Sub
        Protected Overrides Sub OnEditValueChanged()

            MyBase.OnEditValueChanged()

            If Me.EditValue Is Nothing Then

                _TextBox.Clear()

            Else

                _TextBox.Text = Me.Text

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub ModifyRepositoryItems()

            For Each GridColumn In MyBase.Properties.View.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.RealColumnEdit IsNot Nothing Then

                    If TypeOf GridColumn.RealColumnEdit Is DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Then

                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueChecked = "Yes"
                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueUnchecked = "No"
                        DirectCast(GridColumn.RealColumnEdit, DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit).DisplayValueGrayed = "No"

                    End If

                End If

            Next

        End Sub
        Private Sub SearchableComboBox_CloseUp(sender As Object, e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles Me.CloseUp

            If e.Value IsNot Nothing AndAlso
               IsNumeric(e.Value) AndAlso
               CDbl(e.Value) < 0 AndAlso e.Value.ToString.StartsWith("-") = True Then

                e.Value = Nothing

            End If

        End Sub
        Private Sub SearchableComboBox_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles Me.CustomDisplayText

            If e.Value IsNot Nothing AndAlso
                    (_ControlType <> Type.Industry AndAlso _ControlType <> Type.Specialty AndAlso _ControlType <> Type.Source AndAlso
                     _ControlType <> Type.Rating AndAlso _ControlType <> Type.InvoiceNumber AndAlso _ControlType <> Type.CheckNumber AndAlso
                     _ControlType <> Type.PaymentType AndAlso _ControlType <> Type.ClientType1 AndAlso _ControlType <> Type.ClientType2 AndAlso _ControlType <> Type.ClientType3 AndAlso
                     _ControlType <> Type.ClientWebsite AndAlso _ControlType <> Type.AdServerType) Then

                If _HideValueMemberColumn Then

                    If _ControlType = Type.Campaign Then

                        e.DisplayText = Me.Properties.View.GetFocusedRowCellValue("Code").ToString & " - " & e.DisplayText

                    Else

                        e.DisplayText = e.DisplayText

                    End If

                Else

                    If Me.Properties.DisplayMember <> Me.Properties.ValueMember Then

                        e.DisplayText = e.Value & " - " & e.DisplayText

                    End If

                End If

            ElseIf e.Value Is Nothing AndAlso _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                Select Case _ExtraComboBoxItem

                    Case ExtraComboBoxItems.Nothing


                    Case ExtraComboBoxItems.None

                        e.DisplayText = ""

                    Case Else

                        e.DisplayText = "[" & AdvantageFramework.StringUtilities.GetNameAsWords(_ExtraComboBoxItem.ToString) & "]"

                End Select

            End If

        End Sub
        Private Sub SearchableComboBox_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EditValueChanged

            If _BypassUserEntryChanged = False AndAlso _SuspendedForLoading = False Then

                _UserEntryChanged = True

                AdvantageFramework.WinForm.Presentation.Controls.UserEntryChanged(Me)

            End If

        End Sub
        Private Sub SearchableComboBox_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Private Sub SearchableComboBox_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

            'RemoveHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

            If DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow IsNot Nothing AndAlso DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls.Count > 2 Then

                RemoveHandler DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.TextChanged, AddressOf TextBox_TextChanged

            End If

            RemoveHandler Me.Properties.View.CustomRowFilter, AddressOf GridView_CustomRowFilter
            RemoveHandler Me.Properties.View.RowClick, AddressOf GridView_RowClick
            RemoveHandler Me.Properties.View.RowCountChanged, AddressOf GridView_RowCountChanged
            RemoveHandler Me.Properties.View.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText
            RemoveHandler Me.Properties.View.ShowFilterPopupListBox, AddressOf GridView_ShowFilterPopupListBox

            MyBase.Dispose()

        End Sub
        Private Sub SearchableComboBox_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Popup

            'objects
            Dim TextBoxText As String = Nothing

            If IsNothing(MyBase.EditValue) = False AndAlso MyBase.EditValue.ToString <> "" Then

                If _ControlType = Type.Industry OrElse _ControlType = Type.Specialty OrElse _ControlType = Type.Source OrElse _ControlType = Type.Rating OrElse _ControlType = Type.PaymentType OrElse
                        _ControlType = Type.ClientType1 OrElse _ControlType = Type.ClientType2 OrElse _ControlType = Type.ClientType3 Then

                    If IsNumeric(MyBase.EditValue) AndAlso MyBase.EditValue < 0 Then

                        TextBoxText = ""

                    Else

                        TextBoxText = MyBase.Text

                    End If

                Else

                    If _HideValueMemberColumn = True Then

                        If Me.Properties.View.GetFocusedRowCellValue(Me.Properties.View.VisibleColumns(0)) IsNot Nothing Then

                            TextBoxText = Me.Properties.View.GetFocusedRowCellValue(Me.Properties.View.VisibleColumns(0)).ToString

                        End If

                    Else

                        TextBoxText = MyBase.EditValue

                    End If

                End If

                If String.IsNullOrEmpty(_ActiveFilterString) = False Then

                    TextBoxText = ""

                    If _ActiveFilterEnabled Then

                        Me.Properties.View.ApplyColumnsFilter()

                    End If

                End If

                DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.Text = TextBoxText
                DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.SelectAll()
                DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.Focus()

                _ShowAllRowsOnInitialSearch = True

                AddHandler DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.TextChanged, AddressOf TextBox_TextChanged

            End If

        End Sub
        Private Sub TextBox_TextChanged(sender As Object, e As EventArgs)

            _ShowAllRowsOnInitialSearch = False

        End Sub
        Private Sub SearchableComboBox_PropertiesChanged(sender As Object, e As EventArgs) Handles Me.PropertiesChanged

            AddHandler Me.Properties.View.CustomRowFilter, AddressOf GridView_CustomRowFilter
            AddHandler Me.Properties.View.RowClick, AddressOf GridView_RowClick
            AddHandler Me.Properties.View.RowCountChanged, AddressOf GridView_RowCountChanged
            AddHandler Me.Properties.View.CustomColumnDisplayText, AddressOf GridView_CustomColumnDisplayText
            AddHandler Me.Properties.View.ShowFilterPopupListBox, AddressOf GridView_ShowFilterPopupListBox

            If TypeOf Me.Properties.View Is AdvantageFramework.WinForm.Presentation.Controls.GridView Then

                Try

                    DirectCast(Me.Properties.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).IsInGridLookupEditControl = True

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub SearchableComboBox_QueryCloseUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.QueryCloseUp

            _ActiveFilterString = MyBase.Properties.View.ActiveFilterString
            _ActiveFilterEnabled = MyBase.Properties.View.ActiveFilterEnabled

        End Sub
        Private Sub SearchableComboBox_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.QueryPopUp

            'objects
            Dim ColumnsToHide As String() = Nothing

            If Not Me.Properties.ReadOnly Then

                If _ControlType = Type.InvoiceNumber Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.APViewDeletedInvoices(DbContext) = False Then

                            ColumnsToHide = {"IsDeleted"}

                        End If

                    End Using

                ElseIf _ControlType = Type.Industry OrElse _ControlType = Type.Specialty OrElse _ControlType = Type.Source OrElse _ControlType = Type.Rating OrElse _ControlType = Type.PaymentType OrElse
                        _ControlType = Type.ClientType1 OrElse _ControlType = Type.ClientType2 OrElse _ControlType = Type.ClientType3 OrElse _ControlType = Type.ClientWebsite OrElse
                        _ControlType = Type.AdServerType OrElse _ControlType = Type.MediaDemographic Then

                    ColumnsToHide = {"ID"}

                ElseIf _ControlType = Type.JobComponent Then

                    ColumnsToHide = {"ID"}

                ElseIf _ControlType = Type.ServiceFeeType Then

                    ColumnsToHide = {"ID", "CodeAndDescription"}

                ElseIf _ControlType = Type.CheckFormat Then

                    ColumnsToHide = {"Code"}

                ElseIf _ControlType = Type.[Function] Then

                    ColumnsToHide = {"Type"}

                ElseIf _ControlType = Type.Market Then

                    ColumnsToHide = {"IsInactive", "CountryID"}

                End If

                If ColumnsToHide IsNot Nothing AndAlso ColumnsToHide.Count > 0 Then

                    For Each ColumnToHide In ColumnsToHide

                        If Me.Properties.View.Columns(ColumnToHide) IsNot Nothing Then

                            Me.Properties.View.Columns(ColumnToHide).Visible = False

                        End If

                    Next

                End If

                If Me.Properties.View.Columns(Me.Properties.ValueMember) IsNot Nothing Then

                    Me.Properties.View.Columns(Me.Properties.ValueMember).Visible = Not _HideValueMemberColumn

                End If

                MyBase.Properties.View.BestFitColumns()

                ModifyRepositoryItems()

                If Not _HasValidDataSource OrElse _ControlType = Type.BillingApprovalBatch OrElse _ControlType = Type.NielsenTVStation OrElse _ControlType = Type.NielsenRadioStation OrElse
                        _ControlType = Type.NCCTVSyscode OrElse _ControlType = Type.ComscoreTVStation OrElse _ControlType = Type.Market Then

                    RaiseEvent QueryPopupNeedDataSource(_HasValidDataSource)

                End If

                MyBase.Properties.View.ActiveFilterString = _ActiveFilterString
                MyBase.Properties.View.ActiveFilterEnabled = _ActiveFilterEnabled

            End If

        End Sub
        Private Sub GridView_CustomRowFilter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs)

            If _ShowAllRowsOnInitialSearch Then

                e.Visible = True

                If _ActiveFilterEnabled = False OrElse String.IsNullOrEmpty(_ActiveFilterString) Then

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub GridView_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            Try

                If e.Button = Windows.Forms.MouseButtons.Left Then

                    If e.Clicks = 2 Then

                        GridHitInfo = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(e.Location)

                        If GridHitInfo.InRowCell Then

                            If DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).IsRowSelected(GridHitInfo.RowHandle) = False Then

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).ClearSelection()

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).SelectRow(GridHitInfo.RowHandle)

                            End If

                            Me.ClosePopup()

                            e.Handled = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub GridView_RowCountChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            If TypeOf (sender) Is AdvantageFramework.WinForm.Presentation.Controls.GridView Then

                If DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).RowCount = 1 AndAlso
                        Me.Properties.View.IsRowVisible(Me.Properties.View.FocusedRowHandle) = DevExpress.XtraGrid.Views.Grid.RowVisibleState.Visible Then

                    DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).Focus()

                    DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).SelectRow(DirectCast(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).FocusedRowHandle)

                    Me.ClosePopup()

                End If

            End If

        End Sub
        Private Sub GridView_ShowFilterPopupListBox(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventArgs)

            DirectCast(DirectCast(Me, DevExpress.Utils.Win.IPopupControl).PopupWindow.Controls(3), DevExpress.XtraGrid.Editors.SearchEditLookUpPopup).FindTextBox.Text = String.Empty

        End Sub
        Private Sub SearchableComboBox_Resize(sender As Object, e As EventArgs) Handles Me.Resize

            If _TextBox IsNot Nothing Then

                _TextBox.Width = Me.Width

            End If

        End Sub
        Private Sub GridView_CustomColumnDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)

            If IsNumeric(e.DisplayText) AndAlso Decimal.TryParse(e.DisplayText, 0) AndAlso CDec(e.DisplayText) < 0 AndAlso e.DisplayText.StartsWith("-") = True Then

                If Not Me.ExtraComboBoxItem.Equals(ExtraComboBoxItems.Nothing) Then

                    e.DisplayText = ""

                End If

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
