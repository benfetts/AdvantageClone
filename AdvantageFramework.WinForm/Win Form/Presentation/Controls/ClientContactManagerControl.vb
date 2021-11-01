Namespace WinForm.Presentation.Controls

    Public Class ClientContactManagerControl

        Public Event RowCountChangedEvent()
        Public Event SelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _DoesUserHaveAccessToClientContactMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ContactsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                ContactsDataGridView = DataGridViewControl_Contacts
            End Get
        End Property
        Public ReadOnly Property HasASelectedContact As Boolean
            Get
                HasASelectedContact = DataGridViewControl_Contacts.HasASelectedRow
            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedContact As Boolean
            Get
                HasOnlyOneSelectedContact = DataGridViewControl_Contacts.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DoesUserHaveAccessToClientContactMaintenance As Boolean
            Get
                DoesUserHaveAccessToClientContactMaintenance = _DoesUserHaveAccessToClientContactMaintenance
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

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

                    If _Session IsNot Nothing Then

                        _DoesUserHaveAccessToClientContactMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, Security.Modules.Maintenance_Client_ClientContact)

                        DataGridViewControl_Contacts.MultiSelect = False

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadClientContacts()

            Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
            Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
            Dim ClientContactDetailList As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                ClientContactIDs = New Generic.List(Of Integer)

                If String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) = False Then

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = _DivisionCode AndAlso
                                                     Entity.ProductCode = _ProductCode
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = _DivisionCode AndAlso
                                                     Entity.ProductCode Is Nothing
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).Include("ClientContactDetail")
                                               Where Entity.ClientContactDetail.Count = 0
                                               Select Entity.ContactID).ToArray)

                    ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                    ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode)
                                      Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                ElseIf String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) Then

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = _DivisionCode
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).Include("ClientContactDetail")
                                               Where Entity.ClientContactDetail.Count = 0
                                               Select Entity.ContactID).ToArray)

                    ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                    ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode)
                                      Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                ElseIf String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) AndAlso String.IsNullOrEmpty(_ProductCode) Then

                    ClientContacts = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).ToList

                End If

                DataGridViewControl_Contacts.DataSource = (From ClientContact In ClientContacts
                                                           Select New AdvantageFramework.Database.Classes.ClientContactManager(ClientContact)).ToList

                DataGridViewControl_Contacts.OptionsNavigation.UseTabKey = False
                DataGridViewControl_Contacts.CurrentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

                DataGridViewControl_Contacts.CurrentView.BestFitColumns()

                DbContext.Database.Connection.Close()

            End Using

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            LoadClientContacts()

            DataGridViewControl_Contacts.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub AddClientContact()

            If AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode) = Windows.Forms.DialogResult.OK Then

                LoadClientContacts()

            End If

        End Sub
        Public Sub EditSelectedClientContact()

            Dim ClientContactID As Integer = 0

            If _DoesUserHaveAccessToClientContactMaintenance Then

                ClientContactID = DataGridViewControl_Contacts.GetFirstSelectedRowBookmarkValue(0)

                If AdvantageFramework.Maintenance.Client.Presentation.ClientContactEditDialog.ShowFormDialog(_ClientCode, ClientContactID) = Windows.Forms.DialogResult.OK Then

                    LoadClientContacts()

                End If

            End If

        End Sub
        Public Function DeleteSelectedClientContact() As Boolean

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ContactID As Long = 0
            Dim Deleted As Boolean = False

            If DataGridViewControl_Contacts.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContactID = DataGridViewControl_Contacts.GetFirstSelectedRowBookmarkValue(0)

                            ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ContactID)

                            If ClientContact IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.ClientContact.Delete(DbContext, ClientContact) Then

                                    Deleted = True

                                End If

                            End If

                            LoadClientContacts()

                        End Using

                    Catch ex As Exception
                        Deleted = False
                    End Try

                    Me.CloseWaitForm()

                End If

            End If

            DeleteSelectedClientContact = Deleted

        End Function
        Public Sub ClearControl()

            DataGridViewControl_Contacts.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientContactManagerControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_Contacts_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Contacts.RowCountChangedEvent

            RaiseEvent RowCountChangedEvent()

        End Sub
        Private Sub DataGridViewControl_Contacts_RowDoubleClickEvent() Handles DataGridViewControl_Contacts.RowDoubleClickEvent

            EditSelectedClientContact()

        End Sub
        Private Sub DataGridViewControl_Contacts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_Contacts.SelectionChangedEvent

            RaiseEvent SelectionChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
