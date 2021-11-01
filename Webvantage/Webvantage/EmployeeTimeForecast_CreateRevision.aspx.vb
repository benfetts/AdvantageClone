Public Class EmployeeTimeForecast_CreateRevision
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal LoadWithOptions As Boolean)

        'objects
        Dim EmployeeTimeForecastOfficeDetailID As Integer = 0

        If _EmployeeTimeForecastOfficeDetail Is Nothing Then

            If DbContext IsNot Nothing Then

                Try

                    If Request.QueryString("EmployeeTimeForecastOfficeDetailID") IsNot Nothing Then

                        EmployeeTimeForecastOfficeDetailID = CType(Request.QueryString("EmployeeTimeForecastOfficeDetailID"), Integer)

                    End If

                Catch ex As Exception
                    EmployeeTimeForecastOfficeDetailID = 0
                End Try

                If LoadWithOptions Then

                    _EmployeeTimeForecastOfficeDetail = AdvantageFramework.EmployeeTimeForecast.LoadEmployeeTimeForecastOfficeDetailWithOptions(DbContext, EmployeeTimeForecastOfficeDetailID)

                Else

                    _EmployeeTimeForecastOfficeDetail = AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.LoadByEmployeeTimeForecastOfficeDetailID(DbContext, EmployeeTimeForecastOfficeDetailID)

                End If

            End If

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_CreateRevision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext, False)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    RadToolBarButtonCreateRevision.Enabled = True

                Else

                    RadToolBarButtonCreateRevision.Enabled = False

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecast_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecast.ButtonClick

        'objects
        Dim NewEmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail = Nothing
        Dim RevisionCreated As Boolean = False

        Select Case e.Item.Value

            Case "CreateRevision"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadEmployeeTimeForecastOfficeDetail(DbContext, True)

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        RevisionCreated = AdvantageFramework.EmployeeTimeForecast.CreateRevisionForEmployeeTimeForecastOfficeDetail(DbContext, Session("ConnString").ToString(), _EmployeeTimeForecastOfficeDetail, NewEmployeeTimeForecastOfficeDetail, CheckBoxUpdateEmployeeRates.Checked, CheckBoxUpdateRevenueAmounts.Checked, CheckBoxExcludeHoursEnteredInCopy.Checked)

                    End If

                    If RevisionCreated Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("EmployeeTimeForecast_Edit.aspx?EmployeeTimeForecastOfficeDetailID={0}", NewEmployeeTimeForecastOfficeDetail.ID), True, True)

                    Else

                        Me.CloseThisWindow()

                    End If

                End Using

            Case "Cancel"

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class