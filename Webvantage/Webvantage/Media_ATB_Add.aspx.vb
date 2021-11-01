Public Class Media_ATB_Add
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private _RevisionID As Integer = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

    Private Sub LoadLookups()

        Me.HlClient.Attributes.Add("onclick", "FocusTB('" & Me.TxtClientCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=mediaatb&control=" & Me.TxtClientCode.ClientID & "&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "FocusTB('" & Me.TxtDivisionCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=mediaatb&control=" & Me.TxtDivisionCode.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "FocusTB('" & Me.TxtProductCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=mediaatb&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")

        TxtClientCode.Attributes.Add("onkeyup", "javascript:ClearInputs(['" & TxtDivisionCode.ClientID & "','" & TxtProductCode.ClientID & "']);")
        TxtDivisionCode.Attributes.Add("onkeyup", "javascript:ClearInputs(['" & TxtProductCode.ClientID & "']);")

    End Sub

#Region "  Form Event Handlers "

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ATBNumber As Integer = Nothing

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

        Me.PageTitle = "New ATB"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            LoadLookups()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    ATBNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaATB.Load(DbContext)
                                 Select Entity.Number).Max + 1

                Catch ex As Exception
                    ATBNumber = 1
                End Try

                RadComboBox_SalesClass.DataTextField = "Description"
                RadComboBox_SalesClass.DataValueField = "Code"

                RadComboBox_SalesClass.DataSource = (From Entity In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                                     Where Entity.SalesClassTypeCode Is Nothing OrElse
                                                           Entity.SalesClassTypeCode = "I"
                                                     Select Entity.Code,
                                                            Entity.Description).ToList.Select(Function(SalesClass) New With {.Code = SalesClass.Code,
                                                                                                                             .Description = SalesClass.Code & " - " & SalesClass.Description}).ToList
                RadComboBox_SalesClass.DataBind()

                RadComboBox_SalesClass.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            End Using

            TextBox_OrderNumber.Text = AdvantageFramework.StringUtilities.PadWithCharacter(ATBNumber.ToString, 6, 0, True)

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub Button_CreateOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_CreateOrder.Click

        'objects
        Dim ErrorMessage As String = ""
        Dim Validator As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

        If Me.TxtClientCode.Text = "" Then

            ErrorMessage &= "Client Code is required.\n"

        End If

        If Me.TxtDivisionCode.Text = "" Then

            ErrorMessage &= "Division Code is required.\n"

        End If

        If Me.TxtProductCode.Text = "" Then

            ErrorMessage &= "Product Code is required.\n"

        End If

        If Me.TextBox_OrderDescription.Text.Trim = "" Then

            ErrorMessage &= "Description is required.\n"

        ElseIf Me.TextBox_OrderDescription.Text.Length > 40 Then

            ErrorMessage &= "Description exceeds the maximum length of " & 40 & ".\n"

        End If

        If Me.RadComboBox_SalesClass.SelectedValue = "" Then

            ErrorMessage &= "Sales Class is required.\n"

        End If

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)
            Exit Sub

        End If

        If Validator.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then

            ErrorMessage &= "Invalid Client!\n"

        End If

        If Validator.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then

            ErrorMessage &= "Access to this client is denied.\n"

        End If

        If Validator.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then

            ErrorMessage &= "Invalid Client, Division!\n"

        End If

        If Validator.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then

            ErrorMessage &= "Access to this division is denied.\n"

        End If

        If Validator.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then

            ErrorMessage &= "Invalid Client, Division, Product!\n"

        End If

        If Validator.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then

            ErrorMessage &= "Access to this product is denied.\n"

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then

                ErrorMessage &= "Access to this client, division, and product is denied.\n"

            End If

        End Using

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)
            Exit Sub

        End If

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATB = New AdvantageFramework.Database.Entities.MediaATB

                MediaATB.ClientCode = TxtClientCode.Text
                MediaATB.DivisionCode = TxtDivisionCode.Text
                MediaATB.ProductCode = TxtProductCode.Text

                If AdvantageFramework.Database.Procedures.MediaATB.Insert(DbContext, MediaATB) Then

                    MediaATBRevision = New AdvantageFramework.Database.Entities.MediaATBRevision

                    MediaATBRevision.Description = TextBox_OrderDescription.Text
                    MediaATBRevision.ATBNumber = MediaATB.Number
                    MediaATBRevision.SalesClassCode = RadComboBox_SalesClass.SelectedValue
                    MediaATBRevision.DateRequested = cEmployee.TimeZoneToday
                    MediaATBRevision.CreatedByUserCode = _Session.UserCode
                    MediaATBRevision.CreatedDate = cEmployee.TimeZoneToday

                    If AdvantageFramework.Database.Procedures.MediaATBRevision.Insert(DbContext, MediaATBRevision) Then

                        Me.CloseThisWindowAndOpenNewWindow("Media_ATB.aspx?ATBNbr=" & MediaATBRevision.ATBNumber & "&RevNbr=" & MediaATBRevision.RevisionNumber, True)

                    End If

                End If

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click

        Me.CloseThisWindow()

    End Sub

#End Region

#End Region

End Class