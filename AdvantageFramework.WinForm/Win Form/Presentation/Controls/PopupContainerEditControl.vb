Namespace WinForm.Presentation.Controls

    Public Class PopupContainerEditControl
        Implements AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ControlTypes
            [Default]
            GeneralLedger
        End Enum


#End Region

#Region " Variables "

        Protected _FormSettingsLoaded As Boolean = False
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ReadOnly As Boolean = False
        Protected _UserEntryChanged As Boolean = False
        Protected _ByPassUserEntryChanged As Boolean = False
        Protected _SuspendedForLoading As Boolean = False
        Protected _IsRequired As Boolean = False
        Protected _DisplayName As String = ""
        Protected _PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = BaseClasses.PropertyTypes.Default
        Protected _EntityDataType As System.Type = Nothing
        Protected _SharedPopupContainerControl As DevExpress.XtraEditors.PopupContainerControl = Nothing
        Protected _DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
        Protected _ControlType As AdvantageFramework.WinForm.Presentation.Controls.PopupContainerEditControl.ControlTypes = ControlTypes.Default
        Protected _QueryableSource As IEnumerable = Nothing

#End Region

#Region " Properties "

        Public Property QueryableSource As IEnumerable
            Get
                QueryableSource = _QueryableSource
            End Get
            Set(value As IEnumerable)
                _QueryableSource = value
            End Set
        End Property
        Public Property ControlType As AdvantageFramework.WinForm.Presentation.Controls.PopupContainerEditControl.ControlTypes
            Get
                ControlType = _ControlType
            End Get
            Set(value As AdvantageFramework.WinForm.Presentation.Controls.PopupContainerEditControl.ControlTypes)
                _ControlType = value
            End Set
        End Property
        Public WriteOnly Property SharedPopupContainerControl As DevExpress.XtraEditors.PopupContainerControl
            Set(value As DevExpress.XtraEditors.PopupContainerControl)
                _SharedPopupContainerControl = value
                SetupPopupContainerControl()
            End Set
        End Property
        Public Property [ReadOnly] As Boolean
            Get
                [ReadOnly] = _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                SetReadOnly()
            End Set
        End Property
        Public ReadOnly Property UserEntryChanged As Boolean Implements Interfaces.IUserEntryControl.UserEntryChanged
            Get

                Dim EntryChanged As Boolean = False

                If _ByPassUserEntryChanged = False Then

                    For Each Control In _SharedPopupContainerControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                        If Control.UserEntryChanged Then

                            EntryChanged = True
                            Exit For

                        End If

                    Next

                End If

                UserEntryChanged = EntryChanged

            End Get
        End Property
        Public WriteOnly Property ByPassUserEntryChanged As Boolean Implements Controls.Interfaces.IUserEntryControl.ByPassUserEntryChanged
            Set(ByVal value As Boolean)

                For Each Control In _SharedPopupContainerControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.ByPassUserEntryChanged = value

                Next

                _ByPassUserEntryChanged = value

            End Set
        End Property
        Public WriteOnly Property SuspendedForLoading As Boolean Implements Interfaces.IUserEntryControl.SuspendedForLoading
            Set(value As Boolean)

                For Each Control In _SharedPopupContainerControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl).ToList

                    Control.SuspendedForLoading = value

                Next

                _SuspendedForLoading = value

            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Public Sub SetPropertySettings(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByVal EnumProperty As [Enum])

            'objects
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            Try

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(System.ComponentModel.TypeDescriptor.GetReflectionType(EnumProperty.GetType).DeclaringType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name.ToUpper = EnumProperty.ToString.ToUpper).SingleOrDefault

            Catch ex As Exception
                PropertyDescriptor = Nothing
            Finally

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

            End Try

        End Sub
        Public Sub SetRequired(ByVal IsRequired As Boolean)

            _IsRequired = IsRequired

            If _IsRequired Then

                Me.BackColor = Drawing.Color.Cyan

            End If

        End Sub
        Public Sub ClearControl()


        End Sub
        Protected Sub SetReadOnly()



        End Sub
        Public Sub ClearChanged() Implements Interfaces.IUserEntryControl.ClearChanged


            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Protected Sub SetupPopupContainerControl()

            Dim Control As System.Windows.Forms.Control = Nothing

            Try

                Control = (From Con In _SharedPopupContainerControl.Controls
                           Select Con).FirstOrDefault

            Catch ex As Exception
                Control = Nothing
            End Try

            If Control IsNot Nothing Then

                If TypeOf Control Is AdvantageFramework.WinForm.Presentation.Controls.DataGridView Then

                    _DataGridView = DirectCast(Control, AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

                    AddHandler _DataGridView.RowDoubleClickEvent, AddressOf DataGridView_RowDoubleClickEvent

                End If

            End If

        End Sub
        Private Sub DataGridView_RowDoubleClickEvent()

            If PopupContainerEditMain_PoupContainerEdit.IsPopupOpen Then

                If _DataGridView IsNot Nothing Then

                    PopupContainerEditMain_PoupContainerEdit.EditValue = _DataGridView.GetFirstSelectedRowBookmarkValue
                    PopupContainerEditMain_PoupContainerEdit.ClosePopup()

                End If

            End If

        End Sub

#Region "  Control Event Handlers "

        Private Sub AddressControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub PopupContainerEditMain_PoupContainerEdit_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles PopupContainerEditMain_PoupContainerEdit.CustomDisplayText

            Try

                Select Case _ControlType

                    Case ControlTypes.Default

                        e.DisplayText = e.Value

                    Case ControlTypes.GeneralLedger

                        e.DisplayText = (From Entity In DirectCast(_SharedPopupContainerControl.Tag, Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount)) _
                                         Where Entity.Code = e.Value _
                                         Select Entity.Code & " - " & Entity.Description).FirstOrDefault

                    Case Else

                        e.DisplayText = e.Value

                End Select

            Catch ex As Exception
                e.DisplayText = e.Value
            End Try

        End Sub
        Private Sub PopupContainerEditMain_PoupContainerEdit_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupContainerEditMain_PoupContainerEdit.QueryPopUp

            PopupContainerEditMain_PoupContainerEdit.Properties.PopupControl = _SharedPopupContainerControl

            If _DataGridView IsNot Nothing Then

                _DataGridView.SelectRow(PopupContainerEditMain_PoupContainerEdit.EditValue)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
