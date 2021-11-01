Namespace Importing.Presentation

    Public Class InvoiceDescriptionSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _APImportDefaultInvoiceDescription As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property APImportDefaultInvoiceDescription As String
            Get
                APImportDefaultInvoiceDescription = _APImportDefaultInvoiceDescription
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef APImportDefaultInvoiceDescription As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _APImportDefaultInvoiceDescription = APImportDefaultInvoiceDescription

            Me.ComboBoxForm_DefaultInvoiceDescription.ByPassUserEntryChanged = True

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef APImportDefaultInvoiceDescription As String) As System.Windows.Forms.DialogResult

            'objects
            Dim InvoiceDescriptionSelectionDialog As AdvantageFramework.Importing.Presentation.InvoiceDescriptionSelectionDialog = Nothing

            InvoiceDescriptionSelectionDialog = New AdvantageFramework.Importing.Presentation.InvoiceDescriptionSelectionDialog(APImportDefaultInvoiceDescription)

            ShowFormDialog = InvoiceDescriptionSelectionDialog.ShowDialog()

            APImportDefaultInvoiceDescription = InvoiceDescriptionSelectionDialog.APImportDefaultInvoiceDescription

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoiceDescriptionSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_DefaultInvoiceDescription.DisplayName = "Default Invoice Description"

            ComboBoxForm_DefaultInvoiceDescription.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Importing.APImportDefaultInvoiceDescription)) _
                                                                .Where(Function(Entity) Entity.Code <> AdvantageFramework.Importing.APImportDefaultInvoiceDescription.None.ToString)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ComboBoxForm_DefaultInvoiceDescription.SelectedValue = AdvantageFramework.Agency.GetOptionAPImportDefaultInvoiceDescription(DbContext)

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                If ComboBoxForm_DefaultInvoiceDescription.HasASelectedValue Then

                    _APImportDefaultInvoiceDescription = ComboBoxForm_DefaultInvoiceDescription.GetSelectedValue

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a default invoice description.")

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace