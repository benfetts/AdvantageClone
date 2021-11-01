Namespace WinForm.Presentation.Controls

    Public Class SubItemComboBox
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemComboBox

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            ExceedEstimateOption
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As SubItemComboBox.Type = SubItemComboBox.Type.Default
        Protected _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property ControlType() As SubItemComboBox.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemComboBox.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case SubItemComboBox.Type.Default



                Case SubItemComboBox.Type.ExceedEstimateOption

                    For Each KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ExceedEstimateOptions))

                        Me.Items.Add(KeyValuePair.Value)

                    Next

            End Select

        End Sub

#Region "  Control Event Handlers "

        Private Sub SubItemComboBoxControl_ParseEditValue(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

            Select Case _ControlType

                Case SubItemComboBox.Type.ExceedEstimateOption

                    e.Value = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Database.Entities.ExceedEstimateOptions), e.Value)

                    e.Handled = True

            End Select

        End Sub

#End Region

#Region "  Custom Control Event Handlers "


#End Region

#End Region

    End Class

End Namespace