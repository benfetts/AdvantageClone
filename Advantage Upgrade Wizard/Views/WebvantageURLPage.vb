Partial Public Class WebvantageURLPage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property WebvantageURL As String
        Get
            WebvantageURL = TextEditForm_WVURL.Text
        End Get
        Set(value As String)
            TextEditForm_WVURL.Text = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub Save()

        SimpleButtonForm_Save.PerformClick()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Save_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Save.Click

        Dim HasRequiredInput As Boolean = True

        DxErrorProvider1.ClearErrors()

        If String.IsNullOrWhiteSpace(TextEditForm_WVURL.Text) Then

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("WebvantageURL", "Webvantage URL is required.")

            Else

                DxErrorProvider1.SetError(TextEditForm_WVURL, "Webvantage URL is required.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

            End If

            HasRequiredInput = False

        End If

        If HasRequiredInput Then

            If System.Uri.IsWellFormedUriString(TextEditForm_WVURL.Text, UriKind.RelativeOrAbsolute) = False Then

                If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                    CType(Me.WizardViewModel, WizardViewModel).AddToErrors("WebvantageURL", "Webvantage URL is not a valid URL.")

                Else

                    DxErrorProvider1.SetError(TextEditForm_WVURL, "Webvantage URL is not a valid URL.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical)

                End If

                HasRequiredInput = False

            End If

        End If

        If HasRequiredInput Then

            Me.WizardViewModel.WizardInputs.WebvantageURL = TextEditForm_WVURL.Text

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGENCY SET WEBVANTAGE_URL = '{0}'", TextEditForm_WVURL.Text))

            End Using

            CType(PageViewModel, WebvantageURLViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            CType(PageViewModel, WebvantageURLViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub


#End Region

#End Region

End Class
