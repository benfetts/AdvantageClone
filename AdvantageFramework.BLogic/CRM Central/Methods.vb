Namespace CRMCentral

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "

        Public Enum GridColumnOptions
            Both = 1
            Descriptions = 2
            Codes = 3
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function SaveDataGridViewUserSetting(ByVal Session As AdvantageFramework.Security.Session, ByVal GridColumnOption As GridColumnOptions) As Boolean

            SaveDataGridViewUserSetting = AdvantageFramework.Security.SaveUserSetting(Session, Session.User.ID, Security.UserSettings.GridColumnOptionsInCRMCentral, CInt(GridColumnOption))

        End Function
        Public Function LoadDataGridViewUserSetting(ByVal Session As AdvantageFramework.Security.Session) As GridColumnOptions

            'objects
            Dim GridColumnOption As GridColumnOptions = GridColumnOptions.Codes

            Try

                GridColumnOption = AdvantageFramework.Security.LoadUserSetting(Session, Session.User.ID, Security.UserSettings.GridColumnOptionsInCRMCentral)

            Catch ex As Exception
                GridColumnOption = GridColumnOptions.Codes
            End Try

            LoadDataGridViewUserSetting = GridColumnOption

        End Function
        Public Function IsColumnVisible(ByVal FieldName As String, ByVal GridColumnOption As GridColumnOptions) As Boolean

            'objects
            Dim Visible As Boolean = False

            Select Case FieldName

                Case AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString

                    If GridColumnOption = GridColumnOptions.Both Then

                        Visible = True

                    ElseIf GridColumnOption = GridColumnOptions.Descriptions Then

                        Visible = True

                    Else

                        Visible = False

                    End If

                Case AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString

                    If GridColumnOption = GridColumnOptions.Both Then

                        Visible = True

                    ElseIf GridColumnOption = GridColumnOptions.Codes Then

                        Visible = True

                    Else

                        Visible = False

                    End If

                Case AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString,
                     AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString

                    Visible = True

                Case Else

                    Visible = False

            End Select

            IsColumnVisible = Visible

        End Function

#End Region

    End Module

End Namespace
