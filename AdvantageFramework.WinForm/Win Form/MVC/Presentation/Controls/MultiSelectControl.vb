Namespace WinForm.Presentation.MVCControls

    Public Class MultiSelectControl

        Public Event SelectedObjectsChangedEvent()
        Public Event ObjectAddedEvent(ByVal ObjectAdded As Object)
        Public Event ObjectRemovedEvent(ByVal ObjectRemoved As Object)

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            Employee
            ClientContact
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AllAvailableObjects As IEnumerable = Nothing
        Private _SelectedObjects As IEnumerable = Nothing
        Private _IsControlClearing As Boolean = False
        Private _ControlType As WinForm.Presentation.MVCControls.MultiSelectControl.Type = Nothing
        Private _ValueMemberColumn As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property AvailableDataGridView As AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView
            Get
                AvailableDataGridView = DataGridViewLeftSection_AvailableObjects
            End Get
        End Property
        Public ReadOnly Property SelectedObjectsDataGridView As AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView
            Get
                SelectedObjectsDataGridView = DataGridViewRightSection_SelectedObjects
            End Get
        End Property
        Public Property ControlType As WinForm.Presentation.MVCControls.MultiSelectControl.Type
            Get
                ControlType = _ControlType
            End Get
            Set(value As WinForm.Presentation.MVCControls.MultiSelectControl.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public ReadOnly Property SelectedObjectsCodeString As String
            Get
                SelectedObjectsCodeString = GetSelectObjectsString()
            End Get
        End Property
        Public Property ValueMemberColumn As String
            Get
                ValueMemberColumn = _ValueMemberColumn
            End Get
            Set(value As String)
                _ValueMemberColumn = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.MVCControls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.MVCBaseForms.Interfaces.IMVCBaseForm).Session

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)



                    End Using

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub SetControlType()

            Select Case _ControlType

                Case Type.Employee

                    DataGridViewLeftSection_AvailableObjects.ItemDescription = "Available Employee(s)"
                    DataGridViewRightSection_SelectedObjects.ItemDescription = "Selected Employee(s)"

                Case Type.ClientContact

                    DataGridViewLeftSection_AvailableObjects.ItemDescription = "Available Client Contact(s)"
                    DataGridViewRightSection_SelectedObjects.ItemDescription = "Selected Client Contact(s)"

            End Select

        End Sub
        Private Sub LoadObjects()

            If _AllAvailableObjects IsNot Nothing Then

                Select Case _ControlType

                    Case Type.Employee

                        LoadObjects_Employee()

                    Case Type.ClientContact

                        LoadObjects_ClientContact()

                End Select

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddObject.Enabled = DataGridViewLeftSection_AvailableObjects.HasASelectedRow
            ButtonRightSection_RemoveObject.Enabled = DataGridViewRightSection_SelectedObjects.HasASelectedRow

        End Sub
        Private Function GetRowObject(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.MVCControls.DataGridView, ByVal RowHandle As Integer) As Object

            'objects
            Dim RowObject As Object = Nothing
            Dim RowKey As Object = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim FieldName As String = Nothing
            Dim ObjectType As System.Type = Nothing

            Try

                ObjectType = (From Entity In _AllAvailableObjects Select Entity).FirstOrDefault.GetType

                Select Case _ControlType

                    Case Type.Employee

                        FieldName = AdvantageFramework.Database.Views.Employee.Properties.Code.ToString

                    Case Type.ClientContact

                        FieldName = AdvantageFramework.Database.Entities.ClientContact.Properties.ContactID.ToString

                End Select

                RowKey = DataGridView.CurrentView.GetRowCellValue(RowHandle, FieldName)

                PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(ObjectType).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(Prop) Prop.Name = FieldName).SingleOrDefault

                For Each AvailableObject In _AllAvailableObjects

                    If PropertyDescriptor.GetValue(AvailableObject) = RowKey Then

                        RowObject = AvailableObject
                        Exit For

                    End If

                Next

            Catch ex As Exception
                RowObject = Nothing
            Finally
                GetRowObject = RowObject
            End Try

        End Function
        Private Function GetSelectObjectsString() As String

            'objects
            Dim ObjectString As String = Nothing
            Dim ValueColumnIndex As Int16 = Nothing

            Try

                If DataGridViewRightSection_SelectedObjects.HasRows Then

                    If String.IsNullOrEmpty(_ValueMemberColumn) = False Then

                        If DataGridViewRightSection_SelectedObjects.CurrentView.Columns(_ValueMemberColumn) IsNot Nothing Then

                            ValueColumnIndex = DataGridViewRightSection_SelectedObjects.CurrentView.Columns(_ValueMemberColumn).AbsoluteIndex

                            ObjectString = String.Join(",", (From BookmarkValue In DataGridViewRightSection_SelectedObjects.GetAllRowsCellValues(ValueColumnIndex)
                                                             Select CStr(BookmarkValue)).ToArray)

                        End If

                    Else

                        ObjectString = String.Join(",", (From BookmarkValue In DataGridViewRightSection_SelectedObjects.GetAllRowsBookmarkValues
                                                         Select CStr(BookmarkValue)).ToArray)

                    End If

                End If

            Catch ex As Exception
                ObjectString = Nothing
            End Try

            GetSelectObjectsString = ObjectString

        End Function
        Private Sub AddOrRemoveSelectedObjects(ByVal SelectedObject As Object, ByVal RemoveObject As Boolean)

            'objects
            Dim AddedOrRemoved As Boolean = False

            If SelectedObject IsNot Nothing Then

                Select Case _ControlType

                    Case Type.Employee

                        AddedOrRemoved = AddOrRemoveSelectedObjects_Employee(DirectCast(SelectedObject, AdvantageFramework.Database.Views.Employee), RemoveObject)

                    Case Type.ClientContact

                        AddedOrRemoved = AddOrRemoveSelectedObjects_ClientContact(DirectCast(SelectedObject, AdvantageFramework.Database.Entities.ClientContact), RemoveObject)

                End Select

                If AddedOrRemoved Then

                    If RemoveObject Then

                        RaiseEvent ObjectRemovedEvent(SelectedObject)

                    Else

                        RaiseEvent ObjectAddedEvent(SelectedObject)

                    End If

                End If

            End If

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal AllAvailableObjects As IEnumerable, ByVal SelectedCodeList As Generic.List(Of String)) As Boolean

            'objects
            Dim Loaded As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AllAvailableObjects IsNot Nothing Then

                    _AllAvailableObjects = AllAvailableObjects

                    If SelectedCodeList IsNot Nothing Then

                        Select Case _ControlType

                            Case Type.Employee

                                _SelectedObjects = (From Entity In DirectCast(AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee))
                                                    Where SelectedCodeList.Contains(Entity.Code) = True
                                                    Select Entity).ToList

                            Case Type.ClientContact

                                _SelectedObjects = (From Entity In DirectCast(AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))
                                                    Where SelectedCodeList.Contains(Entity.ContactCode) = True
                                                    Select Entity).ToList

                        End Select

                    End If

                    LoadObjects()

                Else

                    Loaded = False

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.MVCControls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            _AllAvailableObjects = Nothing
            _SelectedObjects = Nothing

            DataGridViewLeftSection_AvailableObjects.DataSource = Nothing
            DataGridViewRightSection_SelectedObjects.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.MVCControls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub MultiSelectControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonRightSection_AddObject_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddObject.Click

            'objects
            Dim SelectedObject As Object = Nothing

            If DataGridViewLeftSection_AvailableObjects.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                For Each SelectedRowHandle In DataGridViewLeftSection_AvailableObjects.CurrentView.GetSelectedRows

                    SelectedObject = GetRowObject(DataGridViewLeftSection_AvailableObjects, SelectedRowHandle)

                    AddOrRemoveSelectedObjects(SelectedObject, False)

                Next

                Try

                    LoadObjects()

                Catch ex As Exception

                End Try

                RaiseEvent SelectedObjectsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveObject_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_RemoveObject.Click

            'objects 
            Dim SelectedObject As Object = Nothing

            If DataGridViewRightSection_SelectedObjects.HasASelectedRow Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                For Each SelectedRowHandle In DataGridViewRightSection_SelectedObjects.CurrentView.GetSelectedRows

                    SelectedObject = GetRowObject(DataGridViewRightSection_SelectedObjects, SelectedRowHandle)

                    AddOrRemoveSelectedObjects(SelectedObject, True)

                Next

                Try

                    LoadObjects()

                Catch ex As Exception

                End Try

                RaiseEvent SelectedObjectsChangedEvent()

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableObjects_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableObjects.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedObjects_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_SelectedObjects.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Employee "

        Private Function AddOrRemoveSelectedObjects_Employee(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal RemoveObject As Boolean) As Boolean

            'objects
            Dim SelectedEmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim AddedOrRemoved As Boolean = False

            Try

                If _SelectedObjects Is Nothing Then

                    SelectedEmployeeList = New Generic.List(Of AdvantageFramework.Database.Views.Employee)

                Else

                    SelectedEmployeeList = _SelectedObjects

                End If

                If RemoveObject Then

                    If SelectedEmployeeList.Contains(Employee) Then

                        AddedOrRemoved = SelectedEmployeeList.Remove(Employee)

                    End If

                Else

                    If SelectedEmployeeList.Contains(Employee) = False Then

                        SelectedEmployeeList.Add(Employee)

                        AddedOrRemoved = True

                    End If

                End If

                _SelectedObjects = SelectedEmployeeList

            Catch ex As Exception
                AddedOrRemoved = False
            Finally
                AddOrRemoveSelectedObjects_Employee = AddedOrRemoved
            End Try

        End Function
        Private Sub LoadObjects_Employee()

            If _SelectedObjects IsNot Nothing Then

                DataGridViewLeftSection_AvailableObjects.DataSource = (From AvailableObject In DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee))
                                                                       Where (From Entity In DirectCast(_SelectedObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee))
                                                                              Select Entity).ToList.Contains(AvailableObject) = False
                                                                       Select AvailableObject).ToList

                DataGridViewRightSection_SelectedObjects.DataSource = (From AvailableObject In DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee))
                                                                       Where (From Entity In DirectCast(_SelectedObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee))
                                                                              Select Entity).ToList.Contains(AvailableObject) = True
                                                                       Select AvailableObject).ToList

            Else

                DataGridViewLeftSection_AvailableObjects.DataSource = DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee)).ToList

                DataGridViewRightSection_SelectedObjects.DataSource = DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Views.Employee)).ToList.Take(0)

            End If

            DataGridViewLeftSection_AvailableObjects.CurrentView.BestFitColumns()
            DataGridViewRightSection_SelectedObjects.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Client Contact "

        Private Function AddOrRemoveSelectedObjects_ClientContact(ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact, ByVal RemoveObject As Boolean) As Boolean

            'objects
            Dim SelectedClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
            Dim AddedOrRemoved As Boolean = False

            Try

                If _SelectedObjects Is Nothing Then

                    SelectedClientContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)

                Else

                    SelectedClientContactList = _SelectedObjects

                End If

                If RemoveObject Then

                    If SelectedClientContactList.Contains(ClientContact) Then

                        AddedOrRemoved = SelectedClientContactList.Remove(ClientContact)

                    End If

                Else

                    If SelectedClientContactList.Contains(ClientContact) = False Then

                        SelectedClientContactList.Add(ClientContact)

                        AddedOrRemoved = True

                    End If

                End If

                _SelectedObjects = SelectedClientContactList

            Catch ex As Exception
                AddedOrRemoved = False
            Finally
                AddOrRemoveSelectedObjects_ClientContact = AddedOrRemoved
            End Try

        End Function
        Private Sub LoadObjects_ClientContact()

            If _SelectedObjects IsNot Nothing Then

                DataGridViewLeftSection_AvailableObjects.DataSource = (From AvailableObject In DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))
                                                                       Where (From Entity In DirectCast(_SelectedObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))
                                                                              Select Entity).ToList.Contains(AvailableObject) = False
                                                                       Select AvailableObject).ToList

                DataGridViewRightSection_SelectedObjects.DataSource = (From AvailableObject In DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))
                                                                       Where (From Entity In DirectCast(_SelectedObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact))
                                                                              Select Entity).ToList.Contains(AvailableObject) = True
                                                                       Select AvailableObject).ToList

            Else

                DataGridViewLeftSection_AvailableObjects.DataSource = DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)).ToList

                DataGridViewRightSection_SelectedObjects.DataSource = DirectCast(_AllAvailableObjects, Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)).ToList.Take(0)

            End If

            DataGridViewLeftSection_AvailableObjects.CurrentView.BestFitColumns()
            DataGridViewRightSection_SelectedObjects.CurrentView.BestFitColumns()

        End Sub

#End Region

#End Region

    End Class

End Namespace
