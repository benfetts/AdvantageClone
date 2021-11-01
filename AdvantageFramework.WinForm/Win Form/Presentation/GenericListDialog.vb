Namespace WinForm.Presentation

    Public Class GenericListDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            DatabaseSQLUser
        End Enum

#End Region

#Region " Variables "

        Private _FormType As AdvantageFramework.WinForm.Presentation.GenericListDialog.Type = Type.DatabaseSQLUser
        Private _SelectedObject As Object = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedObject() As Object
            Get
                SelectedObject = _SelectedObject
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal FormType As AdvantageFramework.WinForm.Presentation.GenericListDialog.Type, ByVal DataSource As Object)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FormType = FormType
            Me.Text = "Select " & AdvantageFramework.StringUtilities.GetNameAsWords(FormType.ToString)

            RadTreeViewForm_List.DataSource = DataSource

            If _FormType = Type.DatabaseSQLUser Then

                RadTreeViewForm_List.DisplayMember = "Name"

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal FormType As AdvantageFramework.WinForm.Presentation.GenericListDialog.Type, ByVal DataSource As Object, ByRef SelectedObject As Object) As Windows.Forms.DialogResult

            'objects
            Dim GenericListDialog As AdvantageFramework.WinForm.Presentation.GenericListDialog = Nothing

            GenericListDialog = New AdvantageFramework.WinForm.Presentation.GenericListDialog(FormType, DataSource)

            ShowFormDialog = GenericListDialog.ShowDialog()

            SelectedObject = GenericListDialog.SelectedObject

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub GenericListDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonForm_Select.Enabled = RadTreeViewForm_List.CheckedNodes.Any

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RadTreeViewForm_List_NodeCheckedChanged(sender As Object, e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles RadTreeViewForm_List.NodeCheckedChanged

            ButtonForm_Select.Enabled = RadTreeViewForm_List.CheckedNodes.Any

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            _SelectedObject = Nothing

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Select.Click

            If RadTreeViewForm_List.CheckedNodes.Any Then

                _SelectedObject = RadTreeViewForm_List.CheckedNodes(0).DataBoundItem

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an item in the list.")

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace