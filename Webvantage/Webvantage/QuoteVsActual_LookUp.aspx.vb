Public Class QuoteVsActual_LookUp
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Form Event Handlers "

    Private Sub QuoteVsActual_LookUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim UserClientDivisionProductAccessesList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserClientDivisionProductAccess) = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                UserClientDivisionProductAccessesList = AdvantageFramework.Security.Database.Procedures.UserClientDivisionProductAccess.LoadByUserCode(SecurityDbContext, _Session.UserCode).ToList
                UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                ASPxGridViewQuoteVsActualLookUp.AutoGenerateColumns = True

                If UserClientDivisionProductAccessesList.Count = 0 Then

                    If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                        'JobComponentViewList = JobComponentViewList.Where(Function(JobCompView) UserEmployeeOfficeList.Any(Function(OfficeAccess) OfficeAccess.OfficeCode = JobCompView.OfficeCode))
                        ASPxGridViewQuoteVsActualLookUp.DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").ToList
                                                                      Where UserEmployeeOfficeList.Any(Function(UsrOfficeAccess) UsrOfficeAccess.OfficeCode = JobComponent.Job.OfficeCode) = True
                                                                      Select [Office] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Office IsNot Nothing, JobComponent.Job.Office.ToString, Nothing),
                                                                             [Client] = JobComponent.Job.Client.ToString,
                                                                             [Division] = JobComponent.Job.Division.ToString,
                                                                             [Product] = JobComponent.Job.Product.ToString,
                                                                             [Job] = JobComponent.Job.ToString(True),
                                                                             [JobComponent] = JobComponent.ToString(False, True),
                                                                             [JobComp] = JobComponent.ToString(True, False)).ToList

                    Else

                        ASPxGridViewQuoteVsActualLookUp.DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").ToList
                                                                      Select [Office] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Office IsNot Nothing, JobComponent.Job.Office.ToString, Nothing),
                                                                             [Client] = JobComponent.Job.Client.ToString,
                                                                             [Division] = JobComponent.Job.Division.ToString,
                                                                             [Product] = JobComponent.Job.Product.ToString,
                                                                             [Job] = JobComponent.Job.ToString(True),
                                                                             [JobComponent] = JobComponent.ToString(False, True),
                                                                             [JobComp] = JobComponent.ToString(True, False)).ToList

                    End If



                Else

                    If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                        'JobComponentViewList = JobComponentViewList.Where(Function(JobCompView) UserEmployeeOfficeList.Any(Function(OfficeAccess) OfficeAccess.OfficeCode = JobCompView.OfficeCode))
                        ASPxGridViewQuoteVsActualLookUp.DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").ToList
                                                                      Where UserClientDivisionProductAccessesList.Any(Function(UsrCDPAccess) UsrCDPAccess.ProductCode = JobComponent.Job.ProductCode AndAlso
                                                                                                                                         UsrCDPAccess.DivisionCode = JobComponent.Job.DivisionCode AndAlso
                                                                                                                                         UsrCDPAccess.ClientCode = JobComponent.Job.ClientCode) = True And
                                                                          UserEmployeeOfficeList.Any(Function(UsrOfficeAccess) UsrOfficeAccess.OfficeCode = JobComponent.Job.OfficeCode) = True
                                                                      Select [Office] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Office IsNot Nothing, JobComponent.Job.Office.ToString, Nothing),
                                                                         [Client] = JobComponent.Job.Client.ToString,
                                                                         [Division] = JobComponent.Job.Division.ToString,
                                                                         [Product] = JobComponent.Job.Product.ToString,
                                                                         [Job] = JobComponent.Job.ToString(True),
                                                                         [JobComponent] = JobComponent.ToString(False, True),
                                                                         [JobComp] = JobComponent.ToString(True, False)).ToList

                    Else

                        ASPxGridViewQuoteVsActualLookUp.DataSource = (From JobComponent In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext).Include("Job").Include("Job.Office").Include("Job.Client").Include("Job.Division").Include("Job.Product").ToList
                                                                      Where UserClientDivisionProductAccessesList.Any(Function(UsrCDPAccess) UsrCDPAccess.ProductCode = JobComponent.Job.ProductCode AndAlso
                                                                                                                                         UsrCDPAccess.DivisionCode = JobComponent.Job.DivisionCode AndAlso
                                                                                                                                         UsrCDPAccess.ClientCode = JobComponent.Job.ClientCode) = True
                                                                      Select [Office] = If(JobComponent.Job IsNot Nothing AndAlso JobComponent.Job.Office IsNot Nothing, JobComponent.Job.Office.ToString, Nothing),
                                                                         [Client] = JobComponent.Job.Client.ToString,
                                                                         [Division] = JobComponent.Job.Division.ToString,
                                                                         [Product] = JobComponent.Job.Product.ToString,
                                                                         [Job] = JobComponent.Job.ToString(True),
                                                                         [JobComponent] = JobComponent.ToString(False, True),
                                                                         [JobComp] = JobComponent.ToString(True, False)).ToList

                    End If

                End If

                ASPxGridViewQuoteVsActualLookUp.KeyFieldName = "JobComp"
                ASPxGridViewQuoteVsActualLookUp.DataBind()

                If ASPxGridViewQuoteVsActualLookUp.Columns("JobComp") IsNot Nothing Then

                    ASPxGridViewQuoteVsActualLookUp.Columns("JobComp").Visible = False

                End If

            End Using

        End Using

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim FullNameParts() As String = Nothing

        If sourceControl Is ASPxGridViewQuoteVsActualLookUp AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            FullNameParts = ASPxGridViewQuoteVsActualLookUp.GetRowValues(Integer.Parse(eventArgument.Split(":"c)(1)), "JobComp").ToString.Split("-")

            Me.OpenWindow("Quote Vs. Actual Summary", "QuoteVsActualSummaryPopup.aspx?JobNo=" & FullNameParts(0).Trim & "&JobComp=" & FullNameParts(1).Trim)

        Else

            MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarQuoteVsActualLookUp_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarQuoteVsActualLookUp.ButtonClick

        'objects
        Dim FullNameParts() As String = Nothing

        Select Case e.Item.Value
            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "QuoteVSActual_LookUp.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_QuotevsActuals
                    .UserCode = Session("UserCode")
                    .Name = "Quote vs Actuals"
                    .Description = "Quote vs Actuals"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If

            Case RadToolBarButtonSelect.Value

                If ASPxGridViewQuoteVsActualLookUp.Selection.Count > 0 Then

                    FullNameParts = ASPxGridViewQuoteVsActualLookUp.GetSelectedFieldValues("JobComp")(0).ToString.Split("-")

                    Me.OpenWindow("Quote Vs. Actual Summary", "QuoteVsActualSummaryPopup.aspx?JobNo=" & FullNameParts(0).Trim & "&JobComp=" & FullNameParts(1).Trim)

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select a job component")

                End If

        End Select

    End Sub

#End Region

#End Region

End Class
