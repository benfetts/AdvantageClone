Namespace WinForm.Presentation.BaseForms

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)>
        Public Function GetForegroundWindow() As IntPtr
        End Function
        Public Sub SetSuspendedForLoading(ByVal SuspendedForLoading As Boolean, BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm)

            If BaseForm.FormShown Then

                BaseForm.SuspendedForLoading = SuspendedForLoading

                AdvantageFramework.WinForm.Presentation.Controls.SetSuspendedForLoading(BaseForm, SuspendedForLoading)

            End If

            BaseForm.SuspendedForLoading = SuspendedForLoading

        End Sub
        Public Sub ClearValidations(BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm)

            If BaseForm.SuperValidator IsNot Nothing Then

                BaseForm.SuperValidator.ClearFailedValidations()

            End If

        End Sub
        Public Function ValidateControl(ByVal Control As System.Windows.Forms.Control, BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm) As Boolean

            Dim IsValid As Boolean = True

            If BaseForm.SuperValidator IsNot Nothing Then

                IsValid = BaseForm.SuperValidator.Validate(Control)

            End If

            ValidateControl = IsValid

        End Function
        Public Function Validator(BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm) As Boolean

            'objects
            Dim IsValid As Boolean = True

            If BaseForm.SuperValidator IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.CloseEditorsOnDataGridViews(BaseForm)

                IsValid = BaseForm.SuperValidator.Validate()

            End If

            Validator = IsValid

        End Function
        Public Function GetComboBoxControls(ByVal ControlCollection As Windows.Forms.Control.ControlCollection) As List(Of AdvantageFramework.WinForm.Presentation.Controls.ComboBox)

            'objects
            Dim ComboBoxList As Generic.List(Of AdvantageFramework.WinForm.Presentation.Controls.ComboBox) = Nothing

            ComboBoxList = New Generic.List(Of AdvantageFramework.WinForm.Presentation.Controls.ComboBox)

            For Each Control In ControlCollection

                If Control.[GetType]().Equals(GetType(AdvantageFramework.WinForm.Presentation.Controls.ComboBox)) Then

                    ComboBoxList.Add(Control)

                End If

                If Control.Controls.Count > 0 Then

                    ComboBoxList.AddRange(GetComboBoxControls(Control.Controls))

                End If

            Next

            GetComboBoxControls = ComboBoxList

        End Function

#End Region

    End Module

End Namespace
