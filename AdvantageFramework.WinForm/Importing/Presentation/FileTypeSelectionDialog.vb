Namespace Importing.Presentation

    Public Class FileTypeSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FileType As AdvantageFramework.Importing.FileTypes = AdvantageFramework.Importing.FileTypes.CSV

#End Region

#Region " Properties "

        Private ReadOnly Property FileType As AdvantageFramework.Importing.FileTypes
            Get
                FileType = _FileType
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef FileType As AdvantageFramework.Importing.FileTypes)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FileType = FileType

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef FileType As AdvantageFramework.Importing.FileTypes) As System.Windows.Forms.DialogResult

            'objects
            Dim FileTypeSelectionDialog As AdvantageFramework.Importing.Presentation.FileTypeSelectionDialog = Nothing

            FileTypeSelectionDialog = New AdvantageFramework.Importing.Presentation.FileTypeSelectionDialog(FileType)

            ShowFormDialog = FileTypeSelectionDialog.ShowDialog()

            FileType = FileTypeSelectionDialog.FileType

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub FileTypeSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ComboBoxForm_FileType.DisplayName = "File Type"

            ComboBoxForm_FileType.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Importing.FileTypes), False)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                If ComboBoxForm_FileType.HasASelectedValue Then

                    _FileType = ComboBoxForm_FileType.GetSelectedValue

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a file type.")

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