Imports Webvantage.wvTimeSheet

Public Class Timesheet_Template_Add
    Inherits Webvantage.BaseChildPage

    Private EmpCode As String = ""
    Private ProductCategoryColumnIsVisible As Boolean = False

    Private Sub Timesheet_Template_Add_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.EmpCode = Me.CurrentQuerystring.EmployeeCode
            If String.IsNullOrWhiteSpace(Me.EmpCode) = True AndAlso Not Request.QueryString("EmployeeCode") Is Nothing Then Me.EmpCode = Request.QueryString("EmployeeCode")
            If String.IsNullOrWhiteSpace(Me.EmpCode) = True Then Me.EmpCode = Session("EmpCode")

        Catch ex As Exception
            Me.EmpCode = Session("EmpCode")
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))

            Me.ProductCategoryColumnIsVisible = ovisible.ProductCategoryVisible()
            Me.TdProductCategoryLabel.Visible = Me.ProductCategoryColumnIsVisible
            Me.TdProductCategoryInput.Visible = Me.ProductCategoryColumnIsVisible
            Me.LoadLookups()

            Dim ts As New cTimeSheet(Session("ConnString"))
            ts.GetTimesheetSettings(Session("UserCode"), , , ,
                                    Me.hlDivision.Text, Me.hlProduct.Text, Me.hlProdCat.Text, Me.hlJob.Text, Me.hlJobComp.Text, Me.hlFuncCat.Text, )

        End If

    End Sub

    Private Sub LoadLookups()

        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        'st: change code path
        Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tsta&calledfrom=custom&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
        Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tsta&calledfrom=custom&control=" & Me.txtDivision.ClientID & "&type=division&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
        Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tsta&calledfrom=custom&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")

        Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?type=job&form=tsta&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
        Me.hlJobComp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?type=jobcomp&form=tsta&control=txtJobComp&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=500,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

        Me.hlFuncCat.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=tsta&type=funccatwithemp&emp=" & Me.EmpCode & "&control=" & Me.txtFuncCat.ClientID & "&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtJobComp.ClientID & ".value);return false;")
        Me.hlProdCat.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=tsta&control=" & Me.txtProdCat.ClientID & "&type=productcategory&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

        With Me.RadComboBoxDepartment
            .Items.Clear()
            .DataSource = odd.GetDeptsByEmpCodeWithDefault(Me.EmpCode)
            .DataTextField = "Description"
            .DataValueField = "Code"
            .DataBind()
        End With
        Try
            If Me.RadComboBoxDepartment.Items.Count <= 1 Then
                Me.RadComboBoxDepartment.Enabled = False
            ElseIf Me.RadComboBoxDepartment.Items.Count > 1 Then
                For i As Integer = 0 To Me.RadComboBoxDepartment.Items.Count - 1
                    If Me.RadComboBoxDepartment.Items(i).Text.IndexOf("*") > -1 Then
                        Me.RadComboBoxDepartment.Items(i).Selected = True
                        Me.RadComboBoxDepartment.Items(i).Text = Me.RadComboBoxDepartment.Items(i).Text.Replace("*", "")
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

        Me.txtFuncCat.Text = oTS.GetDefaultFunction(CStr(Me.EmpCode))

    End Sub

    Private Sub ButtonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If Me.ValidateInput() = True Then
            Dim tst As New Webvantage.wvTimeSheet.TimeSheetTemplate()
            Dim JobNumber As Integer = 0 '
            Dim JobComponentNbr As Integer = 0 'CType(Me.txtJobComp.Text.Trim(), Integer)
            Dim FncCode As String = Me.txtFuncCat.Text.Trim()
            Dim DefaultComment As String = Me.RadTextBoxDefaultComment.Text
            Dim DpTmCode As String = Me.RadComboBoxDepartment.SelectedValue
            Dim ProdCatCode As String = Me.txtProdCat.Text.Trim()
            Dim Hours As Decimal = 0.0
            Dim DaysToApply As String = MiscFN.GetWeekString(Me.CheckBoxListDays)
            If IsNumeric(Me.txtJob.Text.Trim()) = True Then
                JobNumber = CType(Me.txtJob.Text.Trim(), Integer)
            End If
            If IsNumeric(Me.txtJobComp.Text.Trim()) = True Then
                JobComponentNbr = CType(Me.txtJobComp.Text.Trim(), Integer)
            End If
            Try
                Hours = Me.RadNumericTextBoxHours.Value
            Catch ex As Exception
                Hours = 0.0
            End Try
            Dim s As String = tst.SaveToTemplate(JobNumber, JobComponentNbr, FncCode, DefaultComment, Me.EmpCode, DpTmCode, ProdCatCode, Hours, DaysToApply)
            If IsNumeric(s) = True Then
                ''sucess
                Me.CloseThisWindowAndRefreshCaller("Timesheet_CopyFrom.aspx?v=2&empcode=" & Me.EmpCode, True)

            Else
                'failed 
                ''Me.ShowMessage("Error:\n" & s))
            End If
        End If
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        Me.txtClient.Text = ""
        Me.txtDivision.Text = ""
        Me.txtProduct.Text = ""
        Me.txtJob.Text = ""
        Me.txtJobComp.Text = ""
        Me.txtFuncCat.Text = ""
        Me.txtProdCat.Text = ""
        Me.RadTextBoxDefaultComment.Text = ""
        If Me.RadComboBoxDepartment.Items.Count > 0 Then
            Me.RadComboBoxDepartment.SelectedIndex = 0
        End If
        Me.RadNumericTextBoxHours.Value = Nothing
        For i As Integer = 0 To Me.CheckBoxListDays.Items.Count - 1
            Me.CheckBoxListDays.Items(i).Selected = False
        Next
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Function ValidateInput() As Boolean
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim oReq As cRequired = New cRequired(CStr(Session("ConnString")))
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

        Dim ThisClient As String = ""
        Dim ThisDiv As String = ""
        Dim ThisProd As String = ""
        Dim ThisJob As Integer = 0
        Dim ThisJobComp As Integer = 0
        Dim ThisFuncCat As String = ""
        Dim ThisDept As String = ""
        Dim ThisProdCat As String = ""
        Dim ThisHours As String = ""
        Dim strError As String = ""

        Try
            If Me.txtJob.Text <> "" Then
                If IsNumeric(Me.txtJob.Text.Trim) = False Then
                    Me.txtJob.Focus()
                    Me.ShowMessage("Job number is not a number")
                    Return False
                Else
                    ThisJob = CInt(Me.txtJob.Text)
                End If
                If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                    Me.txtJob.Focus()
                    Me.ShowMessage("This job does not exist")
                    Return False
                End If
            End If
        Catch ex As Exception
            ThisJob = 0
        End Try

        Try
            If Me.txtJobComp.Text <> "" Then
                If IsNumeric(Me.txtJobComp.Text.Trim) = False Then
                    Me.txtJobComp.Focus()
                    Me.ShowMessage("Job component number is not a number")
                    Return False
                Else
                    ThisJobComp = CInt(Me.txtJobComp.Text)
                End If
            End If
        Catch ex As Exception
        End Try


        If ThisJob > 0 And ThisJobComp = 0 Then
            Me.txtJobComp.Focus()
            Me.ShowMessage("Job selected without a component")
            Return False
        End If


        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                Me.txtJob.Focus()
                Me.ShowMessage("Invalid Job and Job Component")
                Return False
            Else
                Me.txtClient.Text = ThisClient
                Me.txtDivision.Text = ThisDiv
                Me.txtProduct.Text = ThisProd
            End If
            If myVal.ValidateJobIsOpen(ThisJob, ThisJobComp) = False Then
                Me.txtJob.Focus()
                Me.ShowMessage("This job/comp is closed")
                Return False
            End If

            If myVal.ValidateJobCompNumber(ThisJob, ThisJobComp) = False Then
                Me.txtJob.Focus()
                Me.ShowMessage("This is not a valid job/component")
                Return False
            End If
            If myVal.ValidateJobCompIsEditable(ThisJob, ThisJobComp) = False Then
                Me.txtJob.Focus()
                Me.ShowMessage("Job/comp process control does not allow access")
                Return False
            End If
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), ThisJob, ThisJobComp, "ts") = False Then
                Me.txtJob.Focus()
                Me.ShowMessage("Access to this job/comp is denied")
                Return False
            End If
        End If


        If Me.txtClient.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim(), "", "", "ts") = False Then
                Me.txtClient.Focus()
                Me.ShowMessage("Access to this client is denied")
                Return False
            End If
        End If
        If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), "", "ts") = False Then
                Me.txtDivision.Focus()
                Me.ShowMessage("Access to this division is denied")
                Return False
            End If
        End If
        If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim, "ts") = False Then
                Me.txtProduct.Focus()
                Me.ShowMessage("Access to this product is denied")
                Return False
            End If
        End If

        ThisFuncCat = Me.txtFuncCat.Text.Trim()
        If ThisFuncCat = "" Then
            Me.txtFuncCat.Focus()
            Me.ShowMessage("Function is a required field")
            Return False
        End If

        If Me.txtJob.Text = "" And Me.txtJobComp.Text = "" And Me.txtFuncCat.Text <> "" Then
            'it is a category and not a function
            If myVal.ValidateFunctionCategoryAll(Me.EmpCode, ThisFuncCat, "V", True) = False Then
                Me.txtFuncCat.Focus()
                Me.ShowMessage("Invalid Function/Category")
                Return False
            End If
        End If

        Dim CurrDefaultFN As String = oTS.GetDefaultFunction(Me.EmpCode)
        If Me.txtFuncCat.Text = CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(Me.EmpCode, CurrDefaultFN) = False Then
                Me.txtFuncCat.Focus()
                Me.ShowMessage("This employee does not have access to his/her own default function")
                Return False
            End If
        End If
        If Me.txtJob.Text <> "" And Me.txtJobComp.Text <> "" And Me.txtFuncCat.Text <> "" And Me.txtFuncCat.Text <> CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(Me.EmpCode, ThisFuncCat) = False Then
                Me.txtFuncCat.Focus()
                Me.ShowMessage("Invalid Function/Category")
                Return False
            End If
        End If


        ThisDept = Me.RadComboBoxDepartment.SelectedValue

        If ovisible.ProductCategoryVisible() = True Then
            ThisProdCat = Me.txtProdCat.Text.Trim
            If ThisProdCat = "" Then
                If oReq.ProductCategoryRequired(ThisClient) = True Then
                    Me.txtProdCat.Focus()
                    Me.ShowMessage("Product Category is required")
                    Return False
                End If
            Else
                If myVal.ValidateProductCategory(ThisProdCat, ThisClient, ThisDiv, ThisProd) = False Then
                    Me.txtProdCat.Focus()
                    Me.ShowMessage("Invalid Product Category")
                    Return False
                End If
            End If
        End If

        Return True
    End Function

End Class
