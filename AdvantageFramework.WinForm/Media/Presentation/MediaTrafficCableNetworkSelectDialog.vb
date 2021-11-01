Namespace Media.Presentation

    Public Class MediaTrafficCableNetworkSelectDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CableNetworkStationList As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation) = Nothing
        Private _SelectedCableNetworks As Generic.List(Of String) = Nothing
        Private _RequireSelection As Boolean = False
        Private _NewSelectedCableNetworks As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property NewSelectedCableNetworks As String
            Get
                NewSelectedCableNetworks = String.Join(",", (From Entity In DataGridViewForm_CableNetwork.GetAllRowsDataBoundItems
                                                             Where Entity.IsSelected = True
                                                             Select Entity.Code).ToList)
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(CableNetworkStationList As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation), SelectedCableNetworks As String, RequireSelection As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _CableNetworkStationList = CableNetworkStationList

            If String.IsNullOrWhiteSpace(SelectedCableNetworks) Then

                _SelectedCableNetworks = New Generic.List(Of String)

            Else

                _SelectedCableNetworks = SelectedCableNetworks.Split(",").ToList

            End If

            _RequireSelection = RequireSelection

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_CableNetwork.DataSource = (From Entity In _CableNetworkStationList.OrderBy(Function(CNS) CNS.Code)
                                                        Select New With {.IsSelected = _SelectedCableNetworks.Contains(Entity.Code),
                                                                         .Code = Entity.Code,
                                                                         .Description = Entity.Description}).ToList

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_CableNetwork.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_CableNetwork.SetupForEditableGrid()

            DataGridViewForm_CableNetwork.ShowSelectDeselectAllButtons = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(CableNetworkStationList As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation), SelectedCableNetworks As String, RequireSelection As Boolean,
                                              ByRef NewSelectedCableNetworks As String) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficCableNetworkSelectDialog As MediaTrafficCableNetworkSelectDialog = Nothing

            MediaTrafficCableNetworkSelectDialog = New MediaTrafficCableNetworkSelectDialog(CableNetworkStationList, SelectedCableNetworks, RequireSelection)

            ShowFormDialog = MediaTrafficCableNetworkSelectDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                NewSelectedCableNetworks = MediaTrafficCableNetworkSelectDialog.NewSelectedCableNetworks

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficCableNetworkSelectDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            SetControlPropertySettings()

            LoadGrid()

        End Sub
        Private Sub MediaTrafficCableNetworkSelectDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_CableNetwork.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            If _RequireSelection AndAlso String.IsNullOrWhiteSpace(Me.NewSelectedCableNetworks) Then ' Me.DataGridViewForm_CableNetwork.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CableNetworkStation).Any(Function(CN) CN.IsInactive) Then

                AdvantageFramework.WinForm.MessageBox.Show("You must select at least one network when editing.")

            Else

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_CableNetwork_DeselectAllEvent() Handles DataGridViewForm_CableNetwork.DeselectAllEvent

            For Each Item In DataGridViewForm_CableNetwork.GetAllRowsDataBoundItems()

                Item.IsSelected = False

            Next

            DataGridViewForm_CableNetwork.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewForm_CableNetwork_SelectAllEvent() Handles DataGridViewForm_CableNetwork.SelectAllEvent

            For Each Item In DataGridViewForm_CableNetwork.GetAllRowsDataBoundItems()

                Item.IsSelected = True

            Next

            DataGridViewForm_CableNetwork.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewForm_CableNetwork_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_CableNetwork.ShowingEditorEvent

            If DataGridViewForm_CableNetwork.CurrentView.FocusedColumn.FieldName <> "IsSelected" Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace