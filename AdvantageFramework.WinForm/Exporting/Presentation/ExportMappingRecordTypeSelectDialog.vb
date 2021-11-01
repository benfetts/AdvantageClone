Namespace Exporting.Presentation

    Public Class ExportMappingRecordTypeSelectDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MappingTypes
            GeneralLedger
        End Enum

#End Region

#Region " Variables "

        Private _MappingType As MappingTypes = MappingTypes.GeneralLedger
        Private _RecordSourceID As Integer = 0

#End Region

#Region " Properties "

        Private ReadOnly Property RecordSourceID As Integer
            Get
                RecordSourceID = _RecordSourceID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal MappingType As MappingTypes)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MappingType = MappingType

        End Sub


#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MappingType As MappingTypes, ByRef RecordSourceID As Integer) As Windows.Forms.DialogResult

            'objects
            Dim ExportMappingRecordTypeSelectDialog As AdvantageFramework.Exporting.Presentation.ExportMappingRecordTypeSelectDialog = Nothing

            ExportMappingRecordTypeSelectDialog = New AdvantageFramework.Exporting.Presentation.ExportMappingRecordTypeSelectDialog(MappingType)

            ShowFormDialog = ExportMappingRecordTypeSelectDialog.ShowDialog()

            RecordSourceID = ExportMappingRecordTypeSelectDialog.RecordSourceID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportMappingRecordTypeSelectDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ComboBoxForm_RecordSource.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                _RecordSourceID = CInt(ComboBoxForm_RecordSource.GetSelectedValue)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace