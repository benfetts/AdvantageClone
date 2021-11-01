Public Class EmployeeTimeForecast_AddIndirectCategories
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

    Private Sub LoadEmployeeTimeForecastOfficeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext)

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

                Try

                    _EmployeeTimeForecastOfficeDetail = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail).Include("EmployeeTimeForecastOfficeDetailIndirectCategories").
                                                                                                                                                                     Include("EmployeeTimeForecastOfficeDetailIndirectCategories.IndirectCategory")
                                                         Where Entity.ID = EmployeeTimeForecastOfficeDetailID
                                                         Select Entity).Single

                Catch ex As Exception
                    _EmployeeTimeForecastOfficeDetail = Nothing
                End Try

            End If

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub EmployeeTimeForecast_AddIndirectCategories_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
        Dim AvailableIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
        Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadEmployeeTimeForecastOfficeDetail(DbContext)

                If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                    CurrentIndirectCategoriesList = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.Select(Function(EmployeeTimeForecastOfficeDetailIndirectCategory) EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategory).ToList
                    AvailableIndirectCategoriesList = AdvantageFramework.EmployeeTimeForecast.LoadAvailableIndirectCategoriesOnEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail)

                    RadListBoxAvailableIndirectCategories.DataSource = AvailableIndirectCategoriesList.Select(Function(AvailableIndirectCategory) New With {.Code = AvailableIndirectCategory.Code,
                                                                                                                                                            .Description = AvailableIndirectCategory.Description})
                    RadListBoxCurrentIndirectCategories.DataSource = CurrentIndirectCategoriesList.Select(Function(CurrentIndirectCategory) New With {.Code = CurrentIndirectCategory.Code,
                                                                                                                                                      .Description = CurrentIndirectCategory.Description})

                    RadListBoxAvailableIndirectCategories.DataBind()
                    RadListBoxCurrentIndirectCategories.DataBind()

                End If

            End Using

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarEmployeeTimeForecastIndirectCategory_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarEmployeeTimeForecastIndirectCategory.ButtonClick

        'objects
        Dim CurrentIndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory) = Nothing
        Dim EmployeeTimeForecastOfficeDetailIndirectCategory As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
        Dim IndirectCategoriesList As Generic.List(Of AdvantageFramework.Database.Entities.IndirectCategory) = Nothing
        Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

        Select Case e.Item.Value

            Case "Done"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadEmployeeTimeForecastOfficeDetail(DbContext)

                    If _EmployeeTimeForecastOfficeDetail IsNot Nothing Then

                        CurrentIndirectCategoriesList = _EmployeeTimeForecastOfficeDetail.EmployeeTimeForecastOfficeDetailIndirectCategories.ToList
                        IndirectCategoriesList = AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext).ToList

                        For Each RadListBoxItem In RadListBoxCurrentIndirectCategories.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                            Try

                                EmployeeTimeForecastOfficeDetailIndirectCategory = (From Entity In CurrentIndirectCategoriesList
                                                                                    Where Entity.IndirectCategoryCode = RadListBoxItem.Value
                                                                                    Select Entity).Single

                            Catch ex As Exception
                                EmployeeTimeForecastOfficeDetailIndirectCategory = Nothing
                            End Try

                            If EmployeeTimeForecastOfficeDetailIndirectCategory IsNot Nothing Then

                                If CurrentIndirectCategoriesList.Any(Function(Entity) Entity.IndirectCategoryCode = EmployeeTimeForecastOfficeDetailIndirectCategory.IndirectCategoryCode) Then

                                    CurrentIndirectCategoriesList.Remove(EmployeeTimeForecastOfficeDetailIndirectCategory)

                                    AdvantageFramework.EmployeeTimeForecast.SyncIndirectCategoryOnEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory)

                                End If

                            Else

                                Try

                                    IndirectCategory = IndirectCategoriesList.Single(Function(Entity) Entity.Code = RadListBoxItem.Value)

                                Catch ex As Exception

                                End Try

                                If IndirectCategory IsNot Nothing Then

                                    AdvantageFramework.EmployeeTimeForecast.InsertIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, IndirectCategory)

                                End If

                            End If

                        Next

                        For Each EmployeeTimeForecastOfficeDetailIndirectCategory In CurrentIndirectCategoriesList

                            AdvantageFramework.EmployeeTimeForecast.DeleteIndirectCategoryInEmployeeTimeForecastOfficeDetail(DbContext, _EmployeeTimeForecastOfficeDetail, EmployeeTimeForecastOfficeDetailIndirectCategory)

                        Next

                        _EmployeeTimeForecastOfficeDetail.ModifiedDate = Now
                        _EmployeeTimeForecastOfficeDetail.ModifiedByUserCode = DbContext.UserCode

                        AdvantageFramework.Database.Procedures.EmployeeTimeForecastOfficeDetail.Update(DbContext, _EmployeeTimeForecastOfficeDetail)

                    End If

                End Using

                Me.CloseThisWindow()

        End Select

    End Sub

#End Region

#End Region

End Class