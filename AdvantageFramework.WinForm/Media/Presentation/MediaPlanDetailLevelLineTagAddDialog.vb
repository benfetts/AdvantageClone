Namespace Media.Presentation

    Public Class MediaPlanDetailLevelLineTagAddDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Media.MediaPlanningController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanningViewModel = Nothing
        Private _TagType As AdvantageFramework.MediaPlanning.TagTypes = MediaPlanning.TagTypes.AdNumber
        Private _ClientCode As String = Nothing
        Private _MediaType As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Code As String
            Get
                Code = If(_ViewModel IsNot Nothing, _ViewModel.Code, Nothing)
            End Get
        End Property
        Public ReadOnly Property Description As String
            Get
                Description = If(_ViewModel IsNot Nothing, _ViewModel.Description, Nothing)
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(TagType As AdvantageFramework.MediaPlanning.TagTypes, ClientCode As String, MediaType As String)

            ' This call is required by the designer.
            InitializeComponent()

            _TagType = TagType
            _ClientCode = ClientCode
            _MediaType = MediaType

        End Sub
        Private Sub SaveViewModel()

            _ViewModel = New AdvantageFramework.ViewModels.Media.MediaPlanningViewModel

            _ViewModel.Code = TextBoxForm_Code.GetText
            _ViewModel.Description = TextBoxForm_Description.GetText

            _ViewModel.TagType = _TagType

            If _TagType = MediaPlanning.Methods.TagTypes.AdNumber Then

                _ViewModel.ClientCode = _ClientCode

            ElseIf _TagType = MediaPlanning.Methods.TagTypes.AdSize Then

                _ViewModel.MediaType = _MediaType

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(TagType As AdvantageFramework.MediaPlanning.TagTypes, ClientCode As String, MediaType As String,
                                              ByRef Code As String, ByRef Description As String) As Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailLevelLineTagAddDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagAddDialog = Nothing

            MediaPlanDetailLevelLineTagAddDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagAddDialog(TagType, ClientCode, MediaType)

            ShowFormDialog = MediaPlanDetailLevelLineTagAddDialog.ShowDialog()

            Code = MediaPlanDetailLevelLineTagAddDialog.Code
            Description = MediaPlanDetailLevelLineTagAddDialog.Description

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailLevelLineTagAddDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

            If _TagType = MediaPlanning.Methods.TagTypes.AdNumber Then

                TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Ad.Properties.Number)
                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.Ad.Properties.Description)

                LabelForm_Code.Text = "Number"

                Me.Text = "Add Ad Number"

            ElseIf _TagType = MediaPlanning.Methods.TagTypes.AdSize Then

                TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.AdSize.Properties.Code)
                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.AdSize.Properties.Description)

                Me.Text = "Add Ad Size"

            End If

            _Controller = New AdvantageFramework.Controller.Media.MediaPlanningController(Me.Session)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            If Me.Validator Then

                SaveViewModel()

                If _Controller.AddTag(_ViewModel) Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace