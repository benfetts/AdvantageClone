Namespace WinForm.Presentation.BaseForms.Interfaces

    Public Interface IBaseForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        ReadOnly Property SpellChecker As AdvantageFramework.WinForm.Presentation.Controls.SpellChecker
        ReadOnly Property DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
        ReadOnly Property IsFormClosing As Boolean
        ReadOnly Property Session As AdvantageFramework.Security.Session
        ReadOnly Property HasLoaded As Boolean
        ReadOnly Property FormShown As Boolean
        Property ShowUnsavedChangesOnFormClosing As Boolean
        Property FormAction As FormActions
        ReadOnly Property ErrorProvider As System.Windows.Forms.ErrorProvider
        ReadOnly Property SuperValidator As DevComponents.DotNetBar.Validator.SuperValidator
        WriteOnly Property SuspendedForLoading As Boolean
        ReadOnly Property Highlighter As DevComponents.DotNetBar.Validator.Highlighter
        ReadOnly Property IsFormModal As Boolean

#End Region

#Region " Methods "

        Function ValidateControl(ByVal Control As System.Windows.Forms.Control) As Boolean
        Sub ClearValidations()
        Sub SetFormActionAndShowWaitForm(ByVal FormAction As WinForm.Presentation.FormActions, Optional ByVal Message As String = Nothing)

#End Region

    End Interface

End Namespace