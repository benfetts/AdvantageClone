Public Class APITest
    Inherits System.Web.UI.Page

    Private Function GetMethods() As Reflection.MethodInfo()

        Return GetType(AdvantageAPI.APIService).GetMethods().Where(Function(MTH) MTH.IsPublic = True).ToArray

    End Function
    Private Sub LoadSelectedMethod()

        Dim MethodInfo As Reflection.MethodInfo = Nothing
        Dim MethodParameterList As List(Of MethodParameter) = Nothing
        Dim NotAllowParameters As String() = {"ServerName", "DatabaseName", "UseWindowsAuthentication", "UserName", "Password"}

        If Not String.IsNullOrWhiteSpace(DropDownListMethodList.SelectedValue) Then

            Try

                MethodInfo = (From Item In Me.GetMethods()
                              Where Item.Name = DropDownListMethodList.SelectedValue
                              Select Item).FirstOrDefault

            Catch ex As Exception
                MethodInfo = Nothing
            End Try

            If MethodInfo IsNot Nothing Then

                MethodParameterList = (From ParameterInfo In MethodInfo.GetParameters()
                                       Where Not NotAllowParameters.Contains(ParameterInfo.Name)
                                       Select New MethodParameter With {.Name = ParameterInfo.Name, .Type = ParameterInfo.ParameterType}).ToList

            End If

        End If

        For Each MethodParameter In MethodParameterList

            Dim TableRow As TableRow = Nothing
            Dim Editor As String = Nothing

            TableRow = New TableRow
            TableRow.Cells.Add(New TableCell With {.Text = MethodParameter.Name})
            TableRow.Cells.Add(New TableCell With {.Text = MethodParameter.Type.ToString})

            If MethodParameter.Type Is GetType(Boolean) Then

                Editor = String.Format("<select name='{0}' class='form-control'><option value='False'>False</option><option value='True'>True</option></select> ", MethodParameter.Name, "")

            Else

                If MethodInfo.Name = "AddInternetOrder" Then

                    If MethodParameter.Name = "OrderNumber" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' {1} class='form-control' />", MethodParameter.Name, "onkeypress='return forceNumeric()'")

                    ElseIf MethodParameter.Name = "OrderDescription" Then

                        Editor = String.Format("<input type='text' name='{0}' value='API ORDER TEST' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "ClientCode" Then

                        Editor = String.Format("<input type='text' name='{0}' value='mcd' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "DivisionCode" Then

                        Editor = String.Format("<input type='text' name='{0}' value='mcd' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "ProductCode" Then

                        Editor = String.Format("<input type='text' name='{0}' value='mcd' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "CampaignCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "SalesClassCode" Then

                        Editor = String.Format("<input type='text' name='{0}' value='sem' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "VendorCode" Then

                        Editor = String.Format("<input type='text' name='{0}' value='facebk' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "VendorRepresentativeCode1" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "VendorRepresentativeCode2" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "ClientPO" Then

                        Editor = String.Format("<input type='text' name='{0}' value='1134' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "BuyerName" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "BuyerEmployeeCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "OrderDate" Then

                        Editor = String.Format("<input type='text' name='{0}' value='3/10/2018' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "OrderComment" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "HouseComment" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "MarketCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "StartDate" Then

                        Editor = String.Format("<input type='text' name='{0}' value='4/10/2018' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "EndDate" Then

                        Editor = String.Format("<input type='text' name='{0}' value='4/29/2018' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "IsNetAmount" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "OrderLineNumber" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "AdNumber" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "Headline" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "AdSizeCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "JobNumber" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "JobComponentNumber" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "InternetTypeCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "URL" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "TargetAudience" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "Placement1" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "Placement2" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "ProjectedImpressions" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "GuaranteedImpressions" Then

                        Editor = String.Format("<input type='text' name='{0}' value='1' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "ActualImpressions" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "LineMarketCode" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "Rate" Then

                        Editor = String.Format("<input type='text' name='{0}' value='100' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "NetCharge" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "AdditionalCharge" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "CostType" Then

                        Editor = String.Format("<input type='text' name='{0}' value='NA' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "MarkupPercentage" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "RebatePercentage" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "RebateAmount" Then

                        Editor = String.Format("<input type='text' name='{0}' value='0' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "Instructions" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "MiscInfo" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "OrderCopy" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    ElseIf MethodParameter.Name = "MaterialNotes" Then

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    End If

                ElseIf MethodInfo.Name = "UpdateInternetOrderHeader" OrElse
                        MethodInfo.Name = "ReviseInternetOrderLine" OrElse
                        MethodInfo.Name = "UpdateInternetOrderLine" Then

                    Editor = String.Format("<input type='text' name='{0}' value='*' class='form-control' />", MethodParameter.Name)

                Else

                    If MethodParameter.Type Is GetType(Integer) OrElse MethodParameter.Type Is GetType(Short) OrElse MethodParameter.Type Is GetType(Decimal) Then

                        Editor = String.Format("<input type='text' name='{0}' {1} class='form-control' />", MethodParameter.Name, "onkeypress='return forceNumeric()'")

                    Else

                        Editor = String.Format("<input type='text' name='{0}' class='form-control' />", MethodParameter.Name)

                    End If

                End If

            End If

            TableRow.Cells.Add(New TableCell With {.Text = Editor})

            ParameterList.Rows.Add(TableRow)

        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim MethodInfos As Reflection.MethodInfo() = Nothing

        If Not Me.IsPostBack Then

            ServerName.Text = "YOUR-SERVER"
            DatabaseName.Text = "YOUR-DB"
            UseWindowsAuthentication.Text = "0"
            UserName.Text = "YOUR-USERNAME"
            Password.Text = "YOUR-PASSWORD"

            MethodInfos = Me.GetMethods()

            DropDownListMethodList.DataValueField = "Name"
            DropDownListMethodList.DataTextField = "Name"
            DropDownListMethodList.DataSource = (From Item In MethodInfos
                                                 Order By Item.Name
                                                 Select New With {.Name = Item.Name}).ToList
            DropDownListMethodList.DataBind()

            LoadSelectedMethod()

        End If

    End Sub

    Private Sub DropDownListMethodList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownListMethodList.SelectedIndexChanged
        LoadSelectedMethod()
    End Sub

End Class

Public Class MethodParameter
    Public Property Name As String
    Public Property Type As System.Type
    Public Property Value As String
End Class