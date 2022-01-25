Namespace FinanceAndAccounting

    Public Class Standard1099NECFormReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Private _FederalTaxID As String = Nothing
        Private _CompanyName As String = Nothing
        Private _StateID As String = Nothing

#End Region

#Region " Properties "

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



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub Standard1099NECFormReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                _CompanyName = _Agency.Name

                Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.FEDERAL_TAX_ID.ToString)

                    If Setting IsNot Nothing Then

                        _FederalTaxID = Setting.Value

                    End If

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_COMPANYNAME.ToString)

                    If Setting IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(Setting.Value) = False Then

                            _CompanyName = Setting.Value

                        End If

                    End If

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.AGY_1099_STATE_ID.ToString)

                    If Setting IsNot Nothing Then

                        _StateID = Setting.Value

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            Label_CompanyName.Text = _CompanyName
            Label_CompanyAddress.Text = _Agency.Address
            Label_CompanyCityStateZip.Text = _Agency.City & ", " & _Agency.State & "  " & _Agency.Zip
            Label_CompanyTelephone.Text = _Agency.Phone
            Label_CompanyFederalTaxID.Text = _FederalTaxID

            Label_NonEmpComp.Text = Nothing

            Label_NonEmpComp.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.IRS1099Processing).TotalAmountPaid

        End Sub
        Private Sub Label_Box17_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_StateID.BeforePrint

            Label_StateID.Text = _StateID

        End Sub

#End Region

#End Region

    End Class

End Namespace
