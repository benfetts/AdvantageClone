Imports Ionic.Zip
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Webvantage.SqlHelper
Imports System.Drawing
Imports System.Collections.Generic
Imports Telerik.Web.UI

Partial Public Class DocumentsPage
    Inherits Webvantage.BaseChildPage

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property

#Region " Declarations"
    Private ConnectionString As String
    Protected WithEvents SearchCriteriaTextBox As System.Web.UI.WebControls.TextBox


    Public access As Integer = 0
    Private IdxFilter As Integer = 0
    Private _IsJobDashboard As Boolean = False

    Private _ShowThumbnailsRadToolBarButton As RadToolBarButton

#End Region

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager)

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.IsJobDashboard = True Then

            _IsJobDashboard = True

        End If

        Me.SearchCriteriaTextBox = CType(Me.RadToolbarDocumentManager.FindItemByValue("RadToolBarButtonSearch").FindControl("SearchCriteriaTextBox"), TextBox)

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AdNumber, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_APInvoice, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ARInvoice, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation)) ' newly added
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Campaign, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Client, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Division, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Employee, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExpenseReceipts, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation))

        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Job, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation))

        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Office, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Product, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation))
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Vendor, False)) Then
            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation)) ' newly added
        End If

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AgencyDesktop, False)) OrElse
                Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExecutiveDesktop, False)) Then

            DocLevelDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation))

            If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AgencyDesktop, False)) Then
                ddlDesktopObject.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation))
            End If

            If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ExecutiveDesktop, False)) Then
                ddlDesktopObject.Items.Add(New Telerik.Web.UI.RadComboBoxItem(AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Title, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation))
            End If
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim IsProofHQEnabled As Boolean = False
        Dim RadToolBarItem As Telerik.Web.UI.RadToolBarItem = Nothing
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing

        'Me.PageTitle = "Document Manager"
        Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))

        Session("LookupForm") = String.Empty
        Me.ConnectionString = Session("ConnString")
        'Me.Title = "Document Manager"

        'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

        MiscFN.LimitTextbox(Me.txtEmp, 6)

        Dim stats As New DocumentRepository("", True)
        Dim s As String = String.Empty
        If stats.IsRepositoryLimitFeatureEnabled = True Then
            Try
                Dim Used As Long = stats.RepositoryUsed
                Dim Total As Long = stats.RepositoryMax
                Dim Perc As Decimal = 0
                If Total > 0 Then
                    Perc = Used / Total
                    s = "Using " & FormatNumber(Used / stats.MB, 0, TriState.True, TriState.True, TriState.True) & " MB of " & FormatNumber(Total / stats.MB, 0, TriState.True, TriState.True, TriState.True) & "MB.  (" & FormatPercent(Perc, 2, TriState.False, TriState.False, True) & ")"
                ElseIf Total = 0 Then
                    s = "Repository is disabled"
                ElseIf Total < 0 Then
                    s = "Repository is unlimited"
                End If
                With Me.RadToolbarDocumentManager.FindItemByValue("StorageLabel")
                    .ToolTip = s
                End With
            Catch ex As Exception
                Me.RadToolbarDocumentManager.FindItemByValue("StorageLabel").Visible = False
            End Try
        Else
            s = "Repository is unlimited"
            With Me.RadToolbarDocumentManager.FindItemByValue("StorageLabel")
                .ToolTip = s
            End With
        End If

        If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

            Me._ShowThumbnailsRadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")

        End If

        _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

        If _DbContext IsNot Nothing Then

            _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

        End If

        If Not Me.IsCallback And Not Me.IsPostBack Then

            Me.MyUnityContextMenu.Visible = False

            Session("errorMsg") = String.Empty

            Dim filterLevel As String = String.Empty
            Dim filterValue As String = String.Empty
            If Request.QueryString("filterlevel") = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation Then
                filterLevel = Request.QueryString("filterlevel")
                filterValue = Request.QueryString("filtervalue")
            End If

            access = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload)
            Dim ClearTheFilter As Boolean = True
            Try
                If Not Request.QueryString("cf") Is Nothing Then
                    If Request.QueryString("cf") = "0" Then
                        ClearTheFilter = False
                    End If
                End If
            Catch ex As Exception
                ClearTheFilter = True
            End Try
            If ClearTheFilter = True Then
                Me.ClearFilter()
            End If

            If access = 0 Then
                Me.RadToolbarDocumentManager.FindItemByValue("Upload").Visible = False
            Else
                Me.RadToolbarDocumentManager.FindItemByValue("Upload").Visible = True
            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                If IsProofHQEnabled AndAlso Me.IsClientPortal = False And Me._Agency.AllowProofHQ = True Then

                    RadToolBarItem = Me.RadToolbarDocumentManager.FindItemByValue("ProofHQUpload")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    RadToolBarItem = Me.RadToolbarDocumentManager.FindItemByValue("ProofHQDownload")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    RadToolBarItem = Me.RadToolbarDocumentManager.FindItemByValue("ProofHQDownloadSeparator")

                    If RadToolBarItem IsNot Nothing Then

                        RadToolBarItem.Visible = True

                    End If

                    GridColumn = RadGridDocuments.MasterTableView.GetColumn("GridTemplateColumnProofHQ")

                    If GridColumn IsNot Nothing Then

                        GridColumn.Visible = True

                    End If

                End If

            End Using

            If _IsJobDashboard = False Then Me.RadGridDocuments.MasterTableView.Caption = "Please select a folder level using the filter or Document Tree on the left"

            'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Attributes.Add("onclick", String.Format("realPostBack('{0}', ''); return false;", Me.RadToolbarDocumentManager.FindItemByValue("Delete").UniqueID))
            'Me.RadToolbarDocumentManager.FindItemByValue("Upload").Attributes.Add("onclick", String.Format("realPostBack('{0}', ''); return false;", Me.RadToolbarDocumentManager.FindItemByValue("Upload").UniqueID))
            Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

            Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=jobjacketnewdocs&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=docmgr&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=docmgr&type=campaign&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value + '&cmpID=' + document.forms[0]." & Me.hfCampaignID.ClientID & ".value);return false;")

            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=docmgr&IncludeJC=false&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=docmgr&type=jobcompjj&control=" & txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlVendor.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Vendor.aspx?form=document_search&type=vendor_and_contact&control=" & Me.txtVendor.ClientID & "');return false;")

            Me.hlDept.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtDept.ClientID & "&type=deptteam');return false;")
            Me.hlAdNumber.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAdNumber.ClientID & "&type=adnumber&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value);return false;")
            Me.hlExInv.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtExInv.ClientID & "&type=expinv&emp=' + document.forms[0]." & Me.txtEmp.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=370,height=300,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
            Me.HyperLink_AccountsReceivableInvoice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TextBox_AccountsReceivableInvoice.ClientID & "&type=arinvoice&client=' + document.forms[0]." & Me.TextBox_AccountsReceivableClient.ClientID & ".value);return false;")
            Me.HyperLink_AccountsReceivableClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.TextBox_AccountsReceivableClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.TextBox_AccountsReceivableClient.ClientID & ".value);return false;")

            Me.hlAPInvoice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtAPInvoice.ClientID & "&type=apinvoice&vendor=' + document.forms[0]." & Me.txtVendor.ClientID & ".value);return false;")

            Me.TrOffice.Visible = False
            Me.TrClient.Visible = False
            Me.TrDivision.Visible = False
            Me.TrProduct.Visible = False
            Me.TrCampaign.Visible = False
            Me.TrJob.Visible = False
            Me.TrComponent.Visible = False
            Me.TrVendor.Visible = False
            Me.TrAPInvoice.Visible = False
            Me.TrDesktopObject.Visible = False
            Me.TrDept.Visible = False
            Me.TrAdNumber.Visible = False
            Me.TrExInv.Visible = False
            Me.TrEmp.Visible = False
            Me.Div_AccountsReceivableInvoice.Visible = False

            If Session("DocFilterLevel") <> "" Then
                Me.DocLevelDropDownList.SelectedValue = Session("DocFilterLevel")
                If Session("DocFilterLevel") = AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation Then
                    If Session("DocDOFilterLevel") <> "" Then
                        Me.ddlDesktopObject.SelectedValue = Session("DocDOFilterLevel")
                        Me.setLevel()
                    End If
                ElseIf Session("DocFilterValue") <> "" Then
                    Me.setLevel()
                End If
            End If

            'Expense report docs
            If filterLevel <> "" Then
                Me.DocLevelDropDownList.SelectedValue = filterLevel
                If filterValue <> "" Then
                    Me.txtExInv.Text = filterValue
                    Me.setLevel()
                End If
            End If

            Try

                Me.hlEmp.Attributes.Remove("onclick")

            Catch ex As Exception
            End Try

            If TrDesktopObject.Visible AndAlso ddlDesktopObject.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation Then

                Me.hlEmp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtEmp.ClientID & "&type=empcode','PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            Else

                Me.hlEmp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.txtEmp.ClientID & "&type=empcodeall','PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            End If

            'Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
            'av.getAllAppVars()

            'If _ShowThumbnailsRadToolBarButton IsNot Nothing Then _ShowThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsAspx", "Boolean", "true").ToString.ToLower = "true"

        Else

            Try

                Me.hlEmp.Attributes.Remove("onclick")

            Catch ex As Exception
            End Try

            If TrDesktopObject.Visible AndAlso ddlDesktopObject.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation Then

                Me.hlEmp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.txtEmp.ClientID & "&type=empcode','PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            Else

                Me.hlEmp.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.txtEmp.ClientID & "&type=empcodeall','PopLookup','screenX=150,left=150,screenY=150,top=150,width=580,height=425,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

            End If

            If Page.IsPostBack Then
                If Me.DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then
                    Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=docmgr&IncludeJC=true&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
                Else
                    Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=docmgr&IncludeJC=false&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
                End If
                Select Case Me.EventArgument
                    Case "Refresh"
                        Me.RadGridDocuments.Rebind()
                    Case "Delete"
                        Me.DeleteFiles()
                    Case "HidePopups"
                    Case "HidePopUpRefresh"
                        Me.RadGridDocuments.Rebind()
                End Select

            End If
        End If

        'Ugly cluge to display error message if email does not send in modal page
        If Session("errorMsg") <> "" Then
            Me.ShowMessage(Session("errorMsg"))
            Session("errorMsg") = String.Empty
        End If

        'Me.RadWindowManager.Skin = Webvantage.MiscFN.SetRadWindowSkin


    End Sub

#Region " Grid"

    Private Function FillFileListFromFilter(ByVal TheLevel As String, ByVal TheValue As String) As Object
        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
        If Me.IsNTAuth = True Then
            currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
            impersonationContext = currentWindowsIdentity.Impersonate()
        End If
        Dim retDataView As System.Data.DataView
        Dim Criteria As String = String.Empty
        Criteria = SearchCriteriaTextBox.Text.Trim.ToLower

        Dim accessPrivate As Integer = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments)
        Dim CanAccessARInvoice As Boolean = False
        Dim CanAccessAPInvoice As Boolean = False

        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ARInvoice, False)) Then
            CanAccessARInvoice = True
        End If
        If Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_APInvoice, False)) Then
            CanAccessAPInvoice = True
        End If

        Select Case TheLevel
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim Documents As New vCurrentClientDocuments(Me.ConnectionString)
                    Documents.Where.CL_CODE.Value = TheValue
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("CL filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim Documents As New vCurrentDivisionDocuments(Me.ConnectionString)
                    If InStr(TheValue, ",") > 0 Then
                        Dim FKs() As String = TheValue.Split(",")
                        Documents.Where.CL_CODE.Value = FKs(0)
                        Documents.Where.DIV_CODE.Value = FKs(1)
                    Else
                        Documents.Where.DIV_CODE.Value = TheValue
                    End If
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("DI filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim Documents As New vCurrentProductDocuments(Me.ConnectionString)
                    Dim FKs() As String = TheValue.Split(",")
                    Documents.Where.CL_CODE.Value = FKs(0)
                    Documents.Where.DIV_CODE.Value = FKs(1)
                    Documents.Where.PRD_CODE.Value = FKs(2)
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("PR filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim myReq As cRequired = New cRequired(CStr(Session("ConnString")))
                    Dim Documents As New vCurrentCampaignDocuments(Me.ConnectionString)
                    Documents.Where.CMP_IDENTIFIER.Value = TheValue
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("CM filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = True
                    Dim Documents As New vCurrentJobDocuments(Me.ConnectionString)
                    Documents.Where.JOB_NUMBER.Value = CInt(TheValue)
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If CanAccessARInvoice = False And CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "'AR Invoice', 'AP Invoice'"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn
                    ElseIf CanAccessARInvoice = False Then
                        Documents.Where.LEVEL.Value = "AR Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    ElseIf CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "AP Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("JO filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = True
                    Dim Documents As New vCurrentJobComponentDocuments(Me.ConnectionString)
                    Dim FKs() As String = TheValue.Split(",")
                    Documents.Where.JOB_NUMBER.Value = CInt(FKs(0))
                    Documents.Where.JOB_COMPONENT_NUMBER.Value = CInt(FKs(1))
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If CanAccessARInvoice = False And CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "'AR Invoice', 'AP Invoice'"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotIn
                    ElseIf CanAccessARInvoice = False Then
                        Documents.Where.LEVEL.Value = "AR Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    ElseIf CanAccessAPInvoice = False Then
                        Documents.Where.LEVEL.Value = "AP Invoice"
                        Documents.Where.LEVEL.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load()
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("JC Filter error:" & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim Documents As New vCurrentOfficeDocuments(Me.ConnectionString)
                    Documents.Where.OFFICE_CODE.Value = TheValue
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("OF Filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim apid As Integer
                    Dim Documents As New vCurrentAPDocuments(Me.ConnectionString)
                    If TheValue <> "" Then
                        apid = CInt(TheValue)
                    End If
                    Documents.Where.AP_ID.Value = apid
                    Documents.Query.CaseSensitive = False
                    If accessPrivate = 0 Then
                        Documents.Where.PRIVATE_FLAG.Value = 1
                        Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                    End If
                    If Criteria <> "" Then
                        Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                        Documents.Query.OpenParenthesis()
                        Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                        Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                        Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                        Documents.Query.CloseParenthesis()
                        Documents.Query.Load("")
                    Else
                        Documents.Query.Load()
                    End If
                    Documents.Sort = "UPLOADED_DATE DESC"
                    Return Documents.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("VN Filter error: " & ex.Message.ToString())
                End Try
            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                Try

                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Dim documentRepo As Interfaces.IDocumentRepository = New Repositories.DocumentRepository(DataContext)
                        Dim DocumentResults = documentRepo.FindDocumentGridItemsByLevel(Me.DocLevelDropDownList.SelectedValue, Me.txtVendor.Text.Trim())

                        If accessPrivate = 0 Then

                            DocumentResults = DocumentResults.Where(Function(x) x.PRIVATE_FLAG = False).ToList

                        End If

                        Return DocumentResults

                    End Using
                Catch ex As Exception
                    Me.ShowMessage("VR Filter error: " & ex.Message.ToString())
                End Try

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                        Dim documentRepo As Interfaces.IDocumentRepository = New Repositories.DocumentRepository(DataContext)
                        Dim DocumentResults = documentRepo.FindDocumentGridItemsByLevel(Me.DocLevelDropDownList.SelectedValue, Me.TextBox_AccountsReceivableInvoice.Text.Trim())
                        If accessPrivate = 0 Then
                            DocumentResults = DocumentResults.Where(Function(x) x.PRIVATE_FLAG = False).ToList
                        End If

                        Return DocumentResults
                    End Using
                Catch ex As Exception
                    Me.ShowMessage("AR Filter error: " & ex.Message.ToString())
                End Try

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                        Dim documentRepo As Interfaces.IDocumentRepository = New Repositories.DocumentRepository(DataContext)
                        Dim DocumentResults = documentRepo.FindDocumentGridItemsByLevel(Me.DocLevelDropDownList.SelectedValue, Me.txtEmp.Text.Trim())
                        If accessPrivate = 0 Then
                            DocumentResults = DocumentResults.Where(Function(x) x.PRIVATE_FLAG = False).ToList
                        End If

                        Return DocumentResults
                    End Using
                Catch ex As Exception
                    Me.ShowMessage("VR Filter error: " & ex.Message.ToString())
                End Try

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = True
                Select Case Me.ddlDesktopObject.SelectedValue
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                        Try
                            Dim Documents As New vCurrentAgencyDesktopDocuments(Me.ConnectionString)
                            Dim FKs() As String = TheValue.Split(",")
                            If FKs(0) <> "" Then
                                Documents.Where.OFFICE_CODE.Value = FKs(0)
                            End If
                            If FKs(1) <> "" Then
                                Documents.Where.DP_TM_CODE.Value = FKs(1)
                            End If
                            Documents.Query.CaseSensitive = False
                            If accessPrivate = 0 Then
                                Documents.Where.PRIVATE_FLAG.Value = 1
                                Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                            End If
                            If Criteria <> "" Then
                                If FKs(0) <> "" Or FKs(1) <> "" Or accessPrivate = 0 Then
                                    Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                                End If
                                Documents.Query.OpenParenthesis()
                                Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Query.CloseParenthesis()
                                Documents.Query.Load("")
                            Else
                                Documents.Query.Load()
                            End If
                            Documents.Sort = "UPLOADED_DATE DESC"
                            Try
                                Dim sy As New cSecurity(Session("ConnString"))
                                Dim off_list As String = String.Empty
                                If sy.UserHasOfficeRestrictions(Session("EmpCode"), off_list) = True Then
                                    Dim dv As DataView = Documents.DefaultView
                                    dv.RowFilter = "OFFICE_CODE IN (" & off_list & ") OR OFFICE_CODE IS NULL"
                                    Return dv
                                Else
                                    Return Documents.DefaultView
                                End If
                            Catch ex As Exception
                                Return Documents.DefaultView
                            End Try
                        Catch ex As Exception
                            Me.ShowMessage("AD Filter error: " & ex.Message.ToString())
                        End Try
                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                        Try
                            Dim Documents As New vCurrentExecutiveDesktopDocuments(Me.ConnectionString)
                            Dim HasOffRestr As Boolean = False
                            Dim FKs() As String = TheValue.Split(",")
                            If FKs(0) <> "" Then
                                Documents.Where.OFFICE_CODE.Value = FKs(0)
                            End If
                            If FKs(1) <> "" Then
                                Documents.Where.EMP_CODE.Value = FKs(1)
                            End If
                            Documents.Query.CaseSensitive = False
                            If accessPrivate = 0 Then
                                Documents.Where.PRIVATE_FLAG.Value = 1
                                Documents.Where.PRIVATE_FLAG.Operator = MyGeneration.dOOdads.WhereParameter.Operand.NotEqual
                            End If

                            If Criteria <> "" Then
                                If FKs(0) <> "" Or FKs(1) <> "" Or accessPrivate = 0 Then
                                    Documents.Query.AddConjunction(MyGeneration.dOOdads.WhereParameter.Conj.AND_)
                                End If
                                Documents.Query.OpenParenthesis()
                                Documents.Where.KEYWORDS.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.KEYWORDS.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.KEYWORDS.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Where.FILENAME.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.FILENAME.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.FILENAME.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Where.DESCRIPTION.Value = "%" & Criteria.ToUpper & "%"
                                Documents.Where.DESCRIPTION.Operator = MyGeneration.dOOdads.WhereParameter.Operand.Like_
                                Documents.Where.DESCRIPTION.Conjuction = MyGeneration.dOOdads.WhereParameter.Conj.OR_
                                Documents.Query.CloseParenthesis()
                                Documents.Query.Load("")
                            Else
                                Documents.Query.Load()
                            End If
                            Documents.Sort = "UPLOADED_DATE DESC"
                            'Return Documents.DefaultView
                            Try
                                Dim sy As New cSecurity(Session("ConnString"))
                                Dim off_list As String = String.Empty
                                If sy.UserHasOfficeRestrictions(Session("EmpCode"), off_list) = True Then
                                    Dim dv As DataView = Documents.DefaultView
                                    dv.RowFilter = "OFFICE_CODE IN (" & off_list & ") OR OFFICE_CODE IS NULL"
                                    Return dv
                                Else
                                    Return Documents.DefaultView
                                End If

                            Catch ex As Exception
                                Return Documents.DefaultView
                            End Try
                        Catch ex As Exception
                            Me.ShowMessage("ED Filter error: " & ex.Message.ToString())
                        End Try
                End Select

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                Try
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim docs As New Document(Me.ConnectionString)

                    Dim dt As DataTable = docs.GetCurrentAdNumberDocument(TheValue, Session("DocClientValue"), accessPrivate)
                    Return dt.DefaultView
                Catch ex As Exception
                    Me.ShowMessage("AD Filter error: " & ex.Message.ToString())
                End Try

            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                Try
                    Dim emp As String = Me.txtEmp.Text
                    Me.RadGridDocuments.MasterTableView.GetColumn("GridBoundColumnLevel").Display = False
                    Dim docs As New Document(Me.ConnectionString)
                    Dim dt As DataTable
                    Dim ar() As String
                    ar = TheValue.Split("|")
                    TheValue = ar(1)
                    If Criteria <> "" Then
                        dt = docs.GetCurrentExpenseDocument(TheValue, emp, Criteria, 1, accessPrivate)
                    Else
                        dt = docs.GetCurrentExpenseDocument(TheValue, emp, "", 1, accessPrivate)
                    End If

                    Return dt.DefaultView

                Catch ex As Exception
                    Me.ShowMessage("Expense Filter error: " & ex.Message.ToString())
                End Try
            Case Else
                Me.ShowMessage("File List not implemented for " + TheLevel)

        End Select
        If Me.IsNTAuth = True Then
            impersonationContext.Undo()
        End If

    End Function

    Private Sub RadGridDocuments_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDocuments.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim URL As String = String.Empty

        Select Case e.CommandName
            Case "Download"

                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)

            Case "ShowHistory"

                If Me.DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation Then

                    URL = "Documents_History.aspx?Level=" & Me.DocLevelDropDownList.SelectedValue & "&FK=" & Me.txtExInv.Text & "&filename=" & e.CommandArgument & "&DOLevel=" & Session("DocDOFilterLevel")
                Else


                    URL = "Documents_History.aspx?Level=" & Me.DocLevelDropDownList.SelectedValue & "&FK=" & Session("HistoryFK") & "&filename=" & e.CommandArgument & "&DOLevel=" & Session("DocDOFilterLevel")
                End If

                Me.OpenWindow("Document History", URL)

            Case "AddComments"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, e.CommandArgument)

                    If Document IsNot Nothing Then

                        If Document.FileName.ToUpper.EndsWith(".PDF") Then

                            Me.OpenWindow(Document.FileName, "Documents_PDFViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.EndsWith(".DOC") OrElse Document.FileName.ToUpper.EndsWith(".DOCX") Then

                            Me.OpenWindow(Document.FileName, "Documents_WordViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.EndsWith(".GIF") OrElse Document.FileName.ToUpper.EndsWith(".JPEG") OrElse
                                Document.FileName.ToUpper.EndsWith(".PJPEG") OrElse Document.FileName.ToUpper.EndsWith(".PNG") OrElse
                                Document.FileName.ToUpper.EndsWith(".JPG") OrElse Document.FileName.ToUpper.EndsWith(".TIFF") OrElse
                                Document.FileName.ToUpper.EndsWith(".BMP") Then

                            Me.OpenWindow(Document.FileName, "Documents_ImageViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 2000)

                        ElseIf Document.FileName.ToUpper.EndsWith(".MSG") Then

                            Me.OpenWindow(Document.FileName, "Documents_MSGViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=1", 800, 1200)

                        ElseIf Document.FileName.ToUpper.Contains(".XLS") OrElse Document.FileName.ToUpper.Contains(".XLSX") Then

                            Me.OpenWindow(Document.FileName, "Documents_ExcelViewer.aspx?DocumentID=" & Document.ID & "&PageNumber=0", 800, 1200)

                        End If

                    End If

                End Using

            Case "ProofHQLink"

                Me.AddJavascriptToPage(String.Format("window.open('{0}', '_blank');", e.CommandArgument))

        End Select
    End Sub
    Private _HasImage As Boolean = False
    Private _DocumentRepository As DocumentRepository
    Private _DbContext As AdvantageFramework.Database.DbContext
    Private _Agency As AdvantageFramework.Database.Entities.Agency

    Private Sub RadGridDocuments_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDocuments.ItemDataBound

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header

                _DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)
                _DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                If _DbContext IsNot Nothing Then

                    _Agency = AdvantageFramework.Database.Procedures.Agency.Load(_DbContext)

                End If

                If Me._ShowThumbnailsRadToolBarButton Is Nothing Then

                    Me._ShowThumbnailsRadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")

                End If

                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If _ShowThumbnailsRadToolBarButton IsNot Nothing Then _ShowThumbnailsRadToolBarButton.Checked = av.getAppVar("DocumentsAspx", "Boolean", "true").ToString.ToLower = "true"

            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim CurrentRow As GridDataItem = e.Item
                Dim DocumentId As String = String.Empty
                Dim MimeType As String = String.Empty
                Dim FileName As String = String.Empty
                Dim RepositoryFileName As String = String.Empty
                Dim ProofHQUrl As String = String.Empty
                Dim Description As String = String.Empty
                Dim FileSize As String = String.Empty
                Dim Thumbnail As Byte()

                If CurrentRow.DataItem.GetType().ToString() = GetType(Webvantage.ViewModels.DocumentUploadGridItem).ToString() Then '"Webvantage.ViewModels.DocumentUploadGridItem" Then

                    Dim viewModel As ViewModels.DocumentUploadGridItem = DirectCast(CurrentRow.DataItem, ViewModels.DocumentUploadGridItem)

                    DocumentId = viewModel.DOCUMENT_ID
                    MimeType = viewModel.MIME_TYPE
                    FileName = viewModel.FILENAME
                    RepositoryFileName = viewModel.REPOSITORY_FILENAME
                    ProofHQUrl = viewModel.PROOFHQ_URL
                    Description = viewModel.DOCUMENT_TYPE_DESC
                    FileSize = viewModel.FILE_SIZE
                    Thumbnail = viewModel.THUMBNAIL

                Else

                    DocumentId = CurrentRow.DataItem("DOCUMENT_ID")
                    MimeType = CurrentRow.DataItem("MIME_TYPE")
                    RepositoryFileName = CurrentRow.DataItem("REPOSITORY_FILENAME")

                    Try

                        If Not IsDBNull(CurrentRow.DataItem("FILENAME")) Then FileName = CurrentRow.DataItem("FILENAME")

                    Catch ex As Exception
                        FileName = ""
                    End Try
                    Try

                        If Not IsDBNull(CurrentRow.DataItem("DESCRIPTION")) Then Description = CurrentRow.DataItem("DESCRIPTION")

                    Catch ex As Exception
                        Description = ""
                    End Try

                    FileSize = CurrentRow.DataItem("FILE_SIZE")

                    Try

                        If IsDBNull(CurrentRow.DataItem("PROOFHQ_URL")) = False AndAlso String.IsNullOrWhiteSpace(CurrentRow.DataItem("PROOFHQ_URL")) = False Then

                            ProofHQUrl = CurrentRow.DataItem("PROOFHQ_URL")

                        End If
                    Catch ex As Exception
                        ProofHQUrl = String.Empty
                    End Try

                    Try

                        If Not IsDBNull(CurrentRow.DataItem("THUMBNAIL")) Then Thumbnail = CurrentRow.DataItem("THUMBNAIL")

                    Catch ex As Exception
                        Thumbnail = Nothing
                    End Try

                End If

                AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(DirectCast(CurrentRow.FindControl("ImageButtonDelete"), ImageButton),
                                                                                   DirectCast(CurrentRow.FindControl("LinkButtonDownload"), LinkButton),
                                                                                   DirectCast(CurrentRow.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(CurrentRow.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                   Nothing, Nothing,
                                                                                   DirectCast(CurrentRow.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(CurrentRow.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                   DirectCast(CurrentRow.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(CurrentRow.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                   DirectCast(CurrentRow.FindControl("DivProofHQ"), HtmlControls.HtmlControl), DirectCast(CurrentRow.FindControl("LinkButtonProofHQ"), LinkButton), ProofHQUrl,
                                                                                   CurrentRow("GridBoundColumnFileSize").Text,
                                                                                   DocumentId, MimeType, FileName, RepositoryFileName, Description, FileSize,
                                                                                   "", "", 0)

                'DirectCast(CurrentRow.FindControl("SelectCheckBox"), CheckBox).Visible = Not MimeType.ToUpper().Contains("URL")

                CurrentRow.Attributes.Add("DocumentId", DocumentId)
                CurrentRow("GridBoundColumnUploadedDate").Text = LoGlo.FormatDateTime(CurrentRow("GridBoundColumnUploadedDate").Text)

                '''Set label tooltip:
                ''Try

                ''    Dim DivDocumentLabels As HtmlControls.HtmlControl = CurrentRow.FindControl("DivDocumentLabels")
                ''    Me.RadToolTipManagerLabels.TargetControls.Add(DivDocumentLabels.ClientID, DocumentId, True)

                ''Catch ex As Exception
                ''End Try

                AdvantageFramework.Web.Presentation.Controls.SetDocumentEditPopUp(CurrentRow.FindControl("ImageButtonEditDetails"), DocumentId, "Documents.aspx")

                Try

                    If Me._ShowThumbnailsRadToolBarButton IsNot Nothing AndAlso Me._ShowThumbnailsRadToolBarButton.Checked = True Then

                        Dim ThumbnailImageButton As ImageButton = CurrentRow.FindControl("ImageButtonThumbnail")

                        If ThumbnailImageButton IsNot Nothing Then

                            ThumbnailImageButton.Visible = False

                            If MimeType.ToLower.Contains("image") = True Then

                                If Thumbnail Is Nothing Then

                                    Try

                                        If _DbContext IsNot Nothing AndAlso _Agency IsNot Nothing Then

                                            AdvantageFramework.DocumentManager.UpdateDocumentThumbnail(_DbContext, _Agency, DocumentId, Thumbnail)

                                        End If

                                    Catch ex As Exception
                                        Thumbnail = Nothing
                                    End Try

                                End If

                                If Thumbnail IsNot Nothing AndAlso Thumbnail.Length > 0 Then

                                    ThumbnailImageButton.ImageUrl = String.Format("data:{0};base64,{1}", MimeType.ToLower, Convert.ToBase64String(Thumbnail))
                                    ThumbnailImageButton.Visible = True
                                    ThumbnailImageButton.ToolTip = FileName
                                    ThumbnailImageButton.CommandName = "Download"
                                    ThumbnailImageButton.CommandArgument = DocumentId

                                    _HasImage = True

                                End If

                            End If

                        End If

                    End If

                Catch ex As Exception
                End Try

            Case Telerik.Web.UI.GridItemType.Footer

                Try

                    Me.RadGridDocuments.MasterTableView.GetColumn("GridTemplateColumnThumbnail").Visible = _HasImage

                Catch ex As Exception
                End Try

        End Select

    End Sub

    Private Sub RadGridDocuments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDocuments.NeedDataSource
        Try
            Dim level As String = String.Empty
            If Not Session("DocFilterLevel") Is Nothing Then
                level = Session("DocFilterLevel")
            End If
            Dim filterValue As String = String.Empty
            If Not Session("DocFilterValue") Is Nothing Then
                filterValue = Session("DocFilterValue")
            End If
            If level <> "" Or filterValue <> "" Then
                Me.RadGridDocuments.DataSource = FillFileListFromFilter(level, filterValue)
            End If
        Catch ex As Exception
            Me.RadGridDocuments.DataSource = Nothing
        End Try
    End Sub

    Public Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

#End Region

#Region " Toolbar"

    Private Sub RadToolbarDocumentManager_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDocumentManager.ButtonClick

        Dim URL As String = String.Empty
        Dim dl As Telerik.Web.UI.RadComboBox
        Select Case e.Item.Value
            Case "LabelView"

                Me.OpenWindow("", "Documents_LabelView.aspx")

            Case "Upload"
                Me.ApplyFilter(True)
                If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then
                    Me.ShowMessage("Please select a level to attach the document")
                    Exit Sub
                Else
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.Page = "Documents_Upload.aspx"
                    qs.Add("caller", Me.PageFilename)
                    qs.Add("Level", Session("DocFilterLevel"))
                    qs.Add("FK", Session("HistoryFK"))
                    qs.Add("Value", Session("DocFilterValue"))
                    qs.Add("DOLevel", Session("DocDOFilterLevel"))

                    Select Case Session("DocDOFilterLevel")
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation, AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                            If Session("DocFilterLevel") = String.Empty Or Session("DocDOFilterLevel") <> Me.ddlDesktopObject.SelectedValue Then
                                Me.ShowMessage("Please select a level to attach the document")
                                Exit Sub
                            End If
                        Case Else
                            If Session("DocFilterLevel") = String.Empty Or Session("DocFilterValue") = String.Empty Then
                                Me.ShowMessage("Please select a level to attach the document")
                                Exit Sub
                            End If
                    End Select

                    Me.OpenWindow(qs, "Upload")
                    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
                    Me.RadGridDocuments.Rebind()

                End If

            Case "Refresh"

                Me.RadGridDocuments.Rebind()
                Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

            Case "Download"
                Select Case Me.RadGridDocuments.SelectedItems.Count
                    Case 0
                        Me.ShowMessage("No file(s) selected")
                    Case 1

                        Dim DocumentId As Integer = Me.RadGridDocuments.SelectedItems(0).Attributes("DocumentId")
                        Dim dt As DataTable
                        dt = Me.GetDoc(DocumentId)
                        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0)("MIME_TYPE").ToString().ToUpper().Contains("URL") = False Then

                            Me.DeliverFile(DocumentId)

                        Else

                            Me.ShowMessage("Cannot download a link")
                            Exit Sub

                        End If

                    Case Is > 1
                        Dim GridItem As Telerik.Web.UI.GridItem

                        ' 03/09/2007 RE - Changed to use in memory stream instead of temp file stream defect #157
                        'Dim TempFilename As String = Server.MapPath("~" & "\" & Guid.NewGuid.ToString()& ".zip")
                        'Dim OutputStream As New System.IO.FileStream(TempFilename, IO.FileMode.Create)
                        'Dim zipOutStream As New ZipOutputStream(OutputStream)

                        Dim outputStream As New System.IO.MemoryStream
                        'Dim zipOutStream As New ZipOutputStream(outputStream)
                        Dim zip As New ZipFile

                        'zipOutStream.SetLevel(5) ' Medium compression
                        Dim dt As DataTable

                        Dim DtRecs As New DataTable

                        Dim COL_DOC_ID As DataColumn = New DataColumn("DocId")
                        COL_DOC_ID.DataType = GetType(Int32)

                        Dim COL_MIME_TYPE As DataColumn = New DataColumn("MimeType")
                        COL_MIME_TYPE.DataType = GetType(String)

                        Dim COL_FILENAME As DataColumn = New DataColumn("Filename")
                        COL_FILENAME.DataType = GetType(String)

                        Dim COL_REPOSITORY_FILENAME As DataColumn = New DataColumn("RepositoryFilename")
                        COL_REPOSITORY_FILENAME.DataType = GetType(String)

                        Dim COL_UPLOADED_DATE As DataColumn = New DataColumn("UploadedDate")
                        COL_UPLOADED_DATE.DataType = GetType(DateTime)

                        With DtRecs.Columns

                            .Add(COL_DOC_ID)
                            .Add(COL_FILENAME)
                            .Add(COL_REPOSITORY_FILENAME)
                            .Add(COL_UPLOADED_DATE)

                        End With


                        For Each GridItem In Me.RadGridDocuments.SelectedItems

                            Dim DocumentId As Integer = GridItem.Attributes("DocumentId")
                            Dim Document As New Document(Me.ConnectionString)

                            dt = Me.GetDoc(DocumentId)

                            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso dt.Rows(0)("MIME_TYPE").ToString().ToUpper().Contains("URL") = False Then

                                If dt.Rows.Count > 0 Then

                                    Dim r As DataRow

                                    r = DtRecs.NewRow()

                                    r("DocId") = DocumentId
                                    r("Filename") = dt.Rows(0)("FILENAME").ToString()
                                    r("RepositoryFilename") = dt.Rows(0)("REPOSITORY_FILENAME").ToString()
                                    r("UploadedDate") = CType(dt.Rows(0)("UPLOADED_DATE"), DateTime)

                                    DtRecs.Rows.Add(r)

                                End If

                            End If

                        Next

                        If Not DtRecs Is Nothing Then

                            If DtRecs.Rows.Count > 0 Then

                                Dim rep As New DocumentRepository(Me.ConnectionString)
                                rep.GetDocuments(DtRecs, zip)
                            End If

                        End If

                        zip.Save(Response.OutputStream)

                        Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

                        With Response

                            .AddHeader("Content-Disposition", "attachment;filename=Webvantage_Files" & AdvantageFramework.StringUtilities.GUID_Date() & ".zip")
                            .ContentType = "application/zip"
                            .End()

                        End With

                End Select
            Case "Search"
                Me.RadGridDocuments.Rebind()
            Case "AdvancedSearch"
                Me.OpenWindow("", "Documents_AdvancedSearch.aspx", 0, 0)
            Case "Delete"
                Me.DeleteFiles()
                'Me.RadGridDocuments.Rebind()
            Case "ClearSearch"
                SearchCriteriaTextBox.Text = String.Empty
                Me.FocusControl(SearchCriteriaTextBox)
                Me.RadGridDocuments.Rebind()

            Case "ProofHQDownload"

                Me.ApplyFilter(True)

                If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                    Me.ShowMessage("Please select a level to attach the document")
                    Exit Sub

                Else

                    If Session("DocDOFilterLevel") <> AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation And Session("DocDOFilterLevel") <> AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation Then

                        If Session("DocFilterLevel") = String.Empty Or Session("DocFilterValue") = String.Empty Then

                            Me.ShowMessage("Please select a level to attach the document")
                            Exit Sub

                        Else

                            URL = "Documents_ProofHQDownload.aspx?Caller=" & Me.PageFilename & "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") & "&DocumentDOLevelCode=" & Session("DocDOFilterLevel")

                        End If

                    Else

                        If Session("DocFilterLevel") = String.Empty Or Session("DocDOFilterLevel") <> Me.ddlDesktopObject.SelectedValue Then

                            Me.ShowMessage("Please select a level to attach the document")
                            Exit Sub

                        Else

                            URL = "Documents_ProofHQDownload.aspx?Caller=" & Me.PageFilename & "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") & "&DocumentDOLevelCode=" & Session("DocDOFilterLevel")

                        End If

                    End If

                End If

                Me.OpenWindow("", URL)
                Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
                Me.RadGridDocuments.Rebind()

            Case "ProofHQUpload"

                If RadGridDocuments.SelectedItems.Count = 0 Then

                    Me.ShowMessage("Please select a document to upload")

                ElseIf RadGridDocuments.SelectedItems.Count > 1 Then

                    Me.ShowMessage("Please only select one document to upload")

                ElseIf RadGridDocuments.SelectedItems.Count = 1 Then

                    Me.ApplyFilter(False)

                    If Session("DocFilterLevel") Is Nothing Or Session("DocFilterValue") Is Nothing Then

                        Me.ShowMessage("Please select a level to attach the document")
                        Exit Sub

                    Else

                        If Session("DocDOFilterLevel") <> AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation And Session("DocDOFilterLevel") <> AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation Then

                            If Session("DocFilterLevel") = String.Empty Or Session("DocFilterValue") = String.Empty Then

                                Me.ShowMessage("Please select a level to attach the document")
                                Exit Sub

                            Else

                                URL = "Documents_ProofHQUpload.aspx?Caller=" & Me.PageFilename & "&DocumentID=" & RadGridDocuments.SelectedItems(0).Attributes("DocumentId") & "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") & "&DocumentDOLevelCode=" & Session("DocDOFilterLevel")

                            End If

                        Else

                            If Session("DocFilterLevel") = String.Empty Or Session("DocDOFilterLevel") <> Me.ddlDesktopObject.SelectedValue Then

                                Me.ShowMessage("Please select a level to attach the document")
                                Exit Sub

                            Else

                                URL = "Documents_ProofHQUpload.aspx?Caller=" & Me.PageFilename & "&DocumentID=" & RadGridDocuments.SelectedItems(0).Attributes("DocumentId") & "&DocumentLevelCode=" & Session("DocFilterLevel") & "&DocumentLevelValue=" & Session("DocFilterValue") & "&DocumentDOLevelCode=" & Session("DocDOFilterLevel")

                            End If

                        End If

                    End If

                    Me.OpenWindow("", URL)
                    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

                End If

            Case "ShowThumbnails"

                Dim ThumbnailsRadToolBarButton As RadToolBarButton = Me.RadToolbarDocumentManager.FindButtonByCommandName("ShowThumbnails")
                Dim av As New cAppVars(cAppVars.Application.DOC_THUMBNAILS)
                av.getAllAppVars()
                If ThumbnailsRadToolBarButton IsNot Nothing Then av.setAppVar("DocumentsAspx", ThumbnailsRadToolBarButton.Checked, "Boolean")

                Me.RadGridDocuments.Rebind()

            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                    qs.Page = "Documents.aspx"
                    qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Documents
                    .UserCode = Session("UserCode")
                    .Name = "Document Manager"
                    .Description = "Document Manager"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If

        End Select

        Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False

    End Sub

    Private Sub DeleteFiles()

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing

        Select Case Me.RadGridDocuments.SelectedItems.Count
            Case 0
                Me.ShowMessage("No file selected")
            Case Is > 0
                Dim i As Integer
                Dim ResultsText As String
                Dim files As String
                Dim filenames() As String

                For i = Me.RadGridDocuments.SelectedItems.Count - 1 To 0 Step -1
                    Dim Document As New Document(Me.ConnectionString)
                    Dim DocumentID As Integer = Me.RadGridDocuments.SelectedItems(i).Attributes("DocumentId")
                    Dim DocPath As String = String.Empty
                    Dim DocRepositoryID As String = String.Empty

                    CurrentGridRow = CType(Me.RadGridDocuments.SelectedItems(i), Telerik.Web.UI.GridDataItem)

                    Document.Where.DOCUMENT_ID.Value = DocumentID
                    If Document.Query.Load() Then
                        'If Document.USER_CODE <> Session("UserCode") And Session("Admin") = False Then
                        '    ResultsText += "Only Webvantage user " & Document.USER_CODE & " may delete " & Document.FILENAME
                        'Else
                        Select Case Me.DocLevelDropDownList.SelectedValue
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                                Dim office As New OfficeDocuments(Session("ConnString"))
                                office.Where.DOCUMENT_ID.Value = DocumentID
                                If office.Query.Load() Then
                                    office.MarkAsDeleted()
                                    office.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                                Dim client As New ClientDocuments(Session("ConnString"))
                                client.Where.DOCUMENT_ID.Value = DocumentID
                                If client.Query.Load() Then
                                    client.MarkAsDeleted()
                                    client.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                                Dim division As New DivisionDocuments(Session("ConnString"))
                                division.Where.DOCUMENT_ID.Value = DocumentID
                                If division.Query.Load() Then
                                    division.MarkAsDeleted()
                                    division.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                                Dim product As New ProductDocuments(Session("ConnString"))
                                product.Where.DOCUMENT_ID.Value = DocumentID
                                If product.Query.Load() Then
                                    product.MarkAsDeleted()
                                    product.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                                Dim campaign As New CampaignDocument(Session("ConnString"))
                                campaign.Where.DOCUMENT_ID.Value = DocumentID
                                If campaign.Query.Load() Then
                                    campaign.MarkAsDeleted()
                                    campaign.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                                Dim job As New JobDocument(Session("ConnString"))
                                job.Where.DOCUMENT_ID.Value = DocumentID
                                If job.Query.Load() Then
                                    job.MarkAsDeleted()
                                    job.Save()
                                End If
                                Dim alert As New AlertAttachment(Session("ConnString"))
                                alert.Where.DOCUMENT_ID.Value = DocumentID
                                If alert.Query.Load() Then
                                    alert.MarkAsDeleted()
                                    alert.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation

                                If CurrentGridRow("GridBoundColumnLevel").Text = "Task" OrElse
                                        CurrentGridRow("GridBoundColumnLevel").Text = "Job Component" Then

                                    Dim jobcomp As New JobComponentDocuments(Session("ConnString"))
                                    jobcomp.Where.DOCUMENT_ID.Value = DocumentID
                                    If jobcomp.Query.Load() Then
                                        jobcomp.MarkAsDeleted()
                                        jobcomp.Save()
                                    End If
                                    Dim alert As New AlertAttachment(Session("ConnString"))
                                    alert.Where.DOCUMENT_ID.Value = DocumentID
                                    If alert.Query.Load() Then
                                        alert.MarkAsDeleted()
                                        alert.Save()
                                    End If
                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                        Try

                                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[JOB_TRAFFIC_DET_DOCS] WHERE [DOCUMENT_ID] = {0}", DocumentID))

                                        Catch ex As Exception

                                        End Try

                                    End Using

                                Else

                                    Continue For

                                End If

                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                                Dim vendor As New APDocument(Session("ConnString"))
                                vendor.Where.DOCUMENT_ID.Value = DocumentID
                                If vendor.Query.Load() Then
                                    vendor.MarkAsDeleted()
                                    vendor.Save()
                                End If
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation,
                                    AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation,
                                    AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    Dim documentRepo As Interfaces.IDocumentRepository = New Repositories.DocumentRepository(DataContext)
                                    documentRepo.DeleteDocumentByLevel(DocLevelDropDownList.SelectedValue, DocumentID)
                                End Using
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                                Select Case Me.ddlDesktopObject.SelectedValue
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                                        Dim agency As New AgencyDesktopDocument(Session("ConnString"))
                                        agency.Where.DOCUMENT_ID.Value = DocumentID
                                        If agency.Query.Load() Then
                                            agency.MarkAsDeleted()
                                            agency.Save()
                                        End If
                                    Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                                        Dim executive As New ExecutiveDesktopDocument(Session("ConnString"))
                                        executive.Where.DOCUMENT_ID.Value = DocumentID
                                        If executive.Query.Load() Then
                                            executive.MarkAsDeleted()
                                            executive.Save()
                                        End If
                                End Select
                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                                Dim ad As New Document(Session("ConnString"))
                                Dim save As Boolean = ad.AddAdNumberDocument(Session("DocFilterValue"), 0)

                            Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                                Dim ad As New Document(Session("ConnString"))
                                Dim Invoice As String = String.Empty
                                Dim ar() As String
                                ar = Session("DocFilterValue").ToString().Split("|")
                                Dim deleted As Boolean = ad.DeleteExpenseDocument(DocumentID, ar(1))
                                If i = 0 Then
                                    Me.ApplyFilter(True)
                                End If

                            Case Else
                                ClientScript.RegisterStartupScript(Me.GetType, "alert_nothandled", "ShowMessage('" + Me.DocLevelDropDownList.SelectedValue + " file deletion not implemented!');", True)
                                Exit Sub
                        End Select

                        Dim DocumentName As String = Document.FILENAME
                        DocRepositoryID = Document.REPOSITORY_FILENAME
                        'DocPath = Document.REPOSITORY_FILENAME

                        'Check for multiple references to same document for job and job comp levels.
                        Dim JobRelatedDocuments As Integer = 0
                        Dim JobCompRelatedDocuments As Integer = 0

                        If Document.MIME_TYPE = "URL" Then
                            Document.MarkAsDeleted()
                            Document.Save()
                            ResultsText += "Deleted:  " & DocumentName & "\n"
                        Else
                            If Me.DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation Then
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    JobRelatedDocuments = AdvantageFramework.Database.Procedures.JobDocument.LoadRelatedbyRepositoryFilename(DataContext, Document.REPOSITORY_FILENAME)
                                End Using
                                If JobRelatedDocuments = 0 Then
                                    files &= DocRepositoryID & ","
                                End If
                            ElseIf Me.DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    JobCompRelatedDocuments = AdvantageFramework.Database.Procedures.JobComponentDocument.LoadRelatedbyRepositoryFilename(DataContext, Document.REPOSITORY_FILENAME)
                                End Using
                                If JobCompRelatedDocuments = 0 Then
                                    files &= DocRepositoryID & ","
                                End If
                            Else
                                files &= DocRepositoryID & ","
                            End If

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                AdvantageFramework.DocumentManager.DeleteAttachmentRecordsForDocument(DbContext, Document.DOCUMENT_ID)

                            End Using

                            Document.MarkAsDeleted()
                            Document.Save()
                            Dim documentRepository As New DocumentRepository(Me.ConnectionString)
                            DocPath = documentRepository.Path

                            'If documentRepositiory.DeleteDocument(DocumentID) Then
                            '    Document.Save()
                            'End If

                            ResultsText += "Deleted:  " & DocumentName & "\n"
                        End If

                        'DeleteXMLFile(DocPath & "\" & DocRepositoryID)                                    
                        'End If
                    End If

                Next
                Dim documentRepositiory As New DocumentRepository(Me.ConnectionString)
                If files <> "" Then
                    files = MiscFN.RemoveTrailingDelimiter(files, " Then,")
                    filenames = files.Split(",")

                    For i = 0 To filenames.Length - 1
                        If documentRepositiory.DeleteDocument(0, filenames(i)) Then
                            'Document.Save()
                        End If
                    Next
                End If

                Me.RadGridDocuments.Rebind()

                If ResultsText.Trim() <> "" Then Me.ShowMessage(ResultsText)

                'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
                'Me.ShowMessage(ResultsText)
        End Select

    End Sub
    Protected Sub ToggleRowSelection(ByVal sender As Object, ByVal e As EventArgs)

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = Nothing

        CurrentGridRow = CType(CType(sender, CheckBox).Parent.Parent, Telerik.Web.UI.GridDataItem)

        CurrentGridRow.Selected = CType(sender, CheckBox).Checked
        'Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = Me.RadGridDocuments.SelectedItems.Count > 0
        access = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload)

        If DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then

            For Counter = Me.RadGridDocuments.SelectedItems.Count - 1 To 0 Step -1

                CurrentGridRow = CType(Me.RadGridDocuments.SelectedItems(Counter), Telerik.Web.UI.GridDataItem)

                If CurrentGridRow("GridBoundColumnLevel").Text = "Task" OrElse
                        CurrentGridRow("GridBoundColumnLevel").Text = "Job Component" Then

                    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = ((access <> 0) AndAlso Me.RadGridDocuments.SelectedItems.Count > 0)

                    If Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False Then

                        Exit For

                    End If

                Else

                    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
                    Exit For

                End If

            Next

        Else

            Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = ((access <> 0) AndAlso Me.RadGridDocuments.SelectedItems.Count > 0)

        End If

        'If Me.access = 0 Then
        '    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
        'Else
        '    Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = Me.RadGridDocuments.SelectedItems.Count > 0
        'End If


        If RadGridDocuments.SelectedItems.Count = 0 Then

            Me.RadToolbarDocumentManager.FindItemByValue("ProofHQUpload").Enabled = False

        ElseIf RadGridDocuments.SelectedItems.Count > 1 Then

            Me.RadToolbarDocumentManager.FindItemByValue("ProofHQUpload").Enabled = False

        ElseIf RadGridDocuments.SelectedItems.Count = 1 And Me._Agency.AllowProofHQ = True Then

            Me.RadToolbarDocumentManager.FindItemByValue("ProofHQUpload").Enabled = True

        End If

    End Sub

#End Region

    Public Function GetDoc(ByVal DocumentID As String) As DataTable
        Dim dt As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterDocumentID As New SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
        parameterDocumentID.Value = DocumentID
        arParams(0) = parameterDocumentID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "proc_DOCUMENTSLoadByPrimaryKey", "tblcmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:Doc.aspx Routine:GetDoc", Err.Description)
        End Try

        Return dt
    End Function

#Region " Filter"
    Private Sub ClearFilter()
        Me.txtOffice.Text = String.Empty
        Me.txtClient.Text = String.Empty
        Me.txtDivision.Text = String.Empty
        Me.txtProduct.Text = String.Empty
        Me.txtCampaign.Text = String.Empty
        Me.txtJob.Text = String.Empty
        Me.txtComponent.Text = String.Empty
        Me.txtVendor.Text = String.Empty
        Me.txtAPInvoice.Text = String.Empty
        Me.txtDept.Text = String.Empty
        Me.txtAdNumber.Text = String.Empty
        Me.txtExInv.Text = String.Empty
        Me.txtEmp.Text = String.Empty
        Me.TextBox_AccountsReceivableClient.Text = String.Empty
        Me.TextBox_AccountsReceivableInvoice.Text = String.Empty

        Session("DocCaption") = String.Empty
        Session("DocFilterLevel") = String.Empty
        Session("DocFilterValue") = String.Empty
        Session("DocDOFilterLevel") = String.Empty
        Session("DocOfficeValue") = String.Empty
        Session("DocClientValue") = String.Empty
        Session("DocDivisionValue") = String.Empty
        Session("DocProductValue") = String.Empty
        Session("DocVenAP") = String.Empty
        Session("HistoryFK") = String.Empty

    End Sub

    Protected Sub ClearFilterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearFilterButton.Click
        ClearFilter()
    End Sub

    Private Sub DocLevelDropdownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DocLevelDropDownList.SelectedIndexChanged
        Session("DocFilterLevel") = String.Empty
        Session("DocFilterValue") = String.Empty
        Session("DocDOFilterLevel") = String.Empty
        Session("DocOfficeValue") = String.Empty
        Session("DocClientValue") = String.Empty
        Session("DocDivisionValue") = String.Empty
        Session("DocProductValue") = String.Empty
        Session("DocVenAP") = String.Empty
        Me.changeLevel()
    End Sub

    Private Sub ApplyFilterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ApplyFilterButton.Click
        Me.ApplyFilter(True)
    End Sub

    Private Function GetCampaignIdentifier(ByVal strCampaignCode As String) As String
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty

            Dim arParams(1) As SqlParameter

            Dim paramCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            paramCampaignCode.Value = strCampaignCode
            arParams(0) = paramCampaignCode

            strReturn = oSQL.ExecuteScalar(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetCampaignIdentifier", arParams)

            If strReturn <> "" And strReturn.Length > 0 Then
                Return strReturn
            Else
                Return String.Empty
            End If
        Catch ex As Exception

        Finally
        End Try
    End Function

    Private Sub ddlDesktopObject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDesktopObject.SelectedIndexChanged
        Session("DocFilterValue") = String.Empty
        Session("DocDOFilterLevel") = String.Empty
        Session("DocOfficeValue") = String.Empty
        Session("DocClientValue") = String.Empty
        Session("DocDivisionValue") = String.Empty
        Session("DocProductValue") = String.Empty
        Session("DocVenAP") = String.Empty
        Me.changeDOLevel()
    End Sub

    Private Sub ClearDocumentManagerSelectors()
        Me.TrAPInvoice.Visible = False
        Me.TrAdNumber.Visible = False
        Me.TrCampaign.Visible = False
        Me.TrClient.Visible = False
        Me.TrComponent.Visible = False
        Me.TrDept.Visible = False
        Me.TrDesktopObject.Visible = False
        Me.TrDivision.Visible = False
        Me.TrEmp.Visible = False
        Me.TrExInv.Visible = False
        Me.TrJob.Visible = False
        Me.TrOffice.Visible = False
        Me.TrProduct.Visible = False
        Me.TrVendor.Visible = False

        Me.Div_AccountsReceivableInvoice.Visible = False
        Me.TextBox_AccountsReceivableInvoice.Visible = False
        Me.txtAPInvoice.CssClass = Nothing
        Me.txtAdNumber.CssClass = Nothing
        Me.txtAdNumber.Text = String.Empty
        Me.txtCampaign.CssClass = Nothing
        Me.txtCampaign.Text = String.Empty
        Me.txtClient.CssClass = Nothing
        Me.txtClient.Text = String.Empty
        Me.txtComponent.CssClass = Nothing
        Me.txtComponent.Text = String.Empty
        Me.txtDept.Text = String.Empty
        Me.txtDivision.CssClass = Nothing
        Me.txtDivision.Text = String.Empty
        Me.txtEmp.Text = String.Empty
        Me.txtJob.CssClass = Nothing
        Me.txtJob.Text = String.Empty
        Me.txtOffice.CssClass = Nothing
        Me.txtOffice.Text = String.Empty
        Me.txtProduct.CssClass = Nothing
        Me.txtProduct.Text = String.Empty
        Me.txtVendor.CssClass = Nothing
    End Sub

    Private Sub changeLevel()
        Try

            ClearDocumentManagerSelectors()

            Select Case Me.DocLevelDropDownList.SelectedValue
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                    Me.txtOffice.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Me.txtOffice.Text = Session("DocFilterValue")
                    End If
                    Me.TrOffice.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                    Me.txtClient.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Me.txtClient.Text = Session("DocFilterValue")
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                    Me.txtClient.CssClass = "RequiredInput"
                    Me.txtDivision.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Dim FKs() As String = Session("DocFilterValue").Split(",")
                        Me.txtClient.Text = FKs(0)
                        Me.txtDivision.Text = FKs(1)
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                    Me.txtClient.CssClass = "RequiredInput"
                    Me.txtDivision.CssClass = "RequiredInput"
                    Me.txtProduct.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Dim FKs() As String = Session("DocFilterValue").Split(",")
                        Me.txtClient.Text = FKs(0)
                        Me.txtDivision.Text = FKs(1)
                        Me.txtProduct.Text = FKs(2)
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                    Me.txtClient.CssClass = "RequiredInput"
                    Me.txtCampaign.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Me.hfCampaignID.Value = Session("DocFilterValue")
                    End If
                    If Session("DocCampaignCode") <> "" Then
                        Me.txtCampaign.Text = Session("DocCampaignCode")
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    If Session("DocClientValue") <> "" Then
                        Me.txtClient.Text = Session("DocClientValue")
                    End If
                    If Session("DocDivisionValue") <> "" Then
                        Me.txtDivision.Text = Session("DocDivisionValue")
                    End If
                    If Session("DocProductValue") <> "" Then
                        Me.txtProduct.Text = Session("DocProductValue")
                    End If

                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrCampaign.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                    Me.txtJob.CssClass = "RequiredInput"
                    Me.txtComponent.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Me.txtJob.Text = Session("DocFilterValue")
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    If Session("DocClientValue") <> "" Then
                        Me.txtClient.Text = Session("DocClientValue")
                    End If
                    If Session("DocDivisionValue") <> "" Then
                        Me.txtDivision.Text = Session("DocDivisionValue")
                    End If
                    If Session("DocProductValue") <> "" Then
                        Me.txtProduct.Text = Session("DocProductValue")
                    End If
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrJob.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                    Me.txtJob.CssClass = "RequiredInput"
                    Me.txtComponent.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Dim FKs() As String = Session("DocFilterValue").Split(",")
                        Me.txtJob.Text = FKs(0)
                        Me.txtComponent.Text = FKs(1)
                    End If
                    If Session("DocOfficeValue") <> "" Then
                        Me.txtOffice.Text = Session("DocOfficeValue")
                    End If
                    If Session("DocClientValue") <> "" Then
                        Me.txtClient.Text = Session("DocClientValue")
                    End If
                    If Session("DocDivisionValue") <> "" Then
                        Me.txtDivision.Text = Session("DocDivisionValue")
                    End If
                    If Session("DocProductValue") <> "" Then
                        Me.txtProduct.Text = Session("DocProductValue")
                    End If
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrJob.Visible = True
                    Me.TrComponent.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                    Me.txtVendor.CssClass = "RequiredInput"
                    Me.txtAPInvoice.CssClass = "RequiredInput"

                    Me.TrVendor.Visible = True
                    Me.TrAPInvoice.Visible = True

                    If Session("DocVenAP") <> "" Then
                        Dim FKs() As String = Session("DocVenAP").Split(",")
                        Me.txtVendor.Text = FKs(0)
                        Me.txtAPInvoice.Text = FKs(1)
                    End If
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                    Me.txtVendor.CssClass = "RequiredInput"
                    Me.TrVendor.Visible = True

                    If Session("DocFilterValue") <> String.Empty Then
                        Me.txtVendor.Text = Session("DocFilterValue")
                    End If
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                    Me.TrDesktopObject.Visible = True

                    Select Case Me.ddlDesktopObject.SelectedValue
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                            Me.TrOffice.Visible = True
                            Me.TrEmp.Visible = False
                            Me.txtEmp.Text = String.Empty
                            Me.TrDept.Visible = True
                            Me.txtDept.Text = String.Empty
                            If Session("DocFilterValue") <> "" Then
                                Dim FKs() As String = Session("DocFilterValue").Split(",")
                                Me.txtOffice.Text = FKs(0)
                                Me.txtDept.Text = FKs(1)
                            End If
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                            Me.TrOffice.Visible = True
                            Me.TrEmp.Visible = True
                            Me.txtEmp.Text = String.Empty
                            Me.TrDept.Visible = False
                            Me.txtDept.Text = String.Empty
                            If Session("DocFilterValue") <> "" Then
                                Dim FKs() As String = Session("DocFilterValue").Split(",")
                                Me.txtOffice.Text = FKs(0)
                                Me.txtEmp.Text = FKs(1)
                            End If
                    End Select
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                    Me.txtAdNumber.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Me.txtAdNumber.Text = Session("DocFilterValue")
                    End If
                    If Session("DocClientValue") <> "" Then
                        Me.txtClient.Text = Session("DocClientValue")
                    End If

                    Me.TrClient.Visible = True
                    Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=docmgr&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value);return false;")

                    Me.TrAdNumber.Visible = True
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                    Me.txtExInv.CssClass = "RequiredInput"
                    Me.txtEmp.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Dim ar() As String
                        ar = Session("DocFilterValue").ToString().Split("|")
                        Me.txtEmp.Text = ar(0).ToString()
                        Me.txtExInv.Text = ar(1).ToString()
                    End If

                    Me.TrExInv.Visible = True
                    Me.TrEmp.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation

                    Me.txtEmp.CssClass = "RequiredInput"

                    If Session("DocFilterValue") <> "" Then
                        Dim ar() As String
                        ar = Session("DocFilterValue").ToString().Split("|")
                        Me.txtEmp.Text = ar(0)
                    End If

                    Me.TrEmp.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                    Me.TextBox_AccountsReceivableClient.CssClass = "RequiredInput"
                    Me.TextBox_AccountsReceivableInvoice.CssClass = "RequiredInput"

                    If Session("DocClientCode") <> String.Empty Then
                        Me.TextBox_AccountsReceivableClient.Text = Session("DocClientCode")
                    End If

                    If Session("DocFilterValue") <> "" Then
                        Dim ar() As String
                        ar = Session("DocFilterValue").ToString().Split("|")
                        Me.TextBox_AccountsReceivableInvoice.Text = ar(0)
                    End If

                    Me.Div_AccountsReceivableInvoice.Visible = True
                    Me.TextBox_AccountsReceivableInvoice.Visible = True

                Case ""
                    ' default level, do nothing :)
                Case Else
                    ClientScript.RegisterStartupScript(Me.GetType, "alert_nothandled", "ShowMessage('" + Me.DocLevelDropDownList.SelectedValue + " field selection not implemented!');", True)
                    ' Me.DocLevelDropDownList.SelectedValue not handled
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub changeDOLevel()
        Try
            Select Case Me.ddlDesktopObject.SelectedValue
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                    Me.TrOffice.Visible = True
                    Me.TrEmp.Visible = False
                    Me.txtEmp.Text = String.Empty
                    Me.TrDept.Visible = True
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                    Me.TrOffice.Visible = True
                    Me.TrEmp.Visible = True
                    Me.TrDept.Visible = False
                    Me.txtDept.Text = String.Empty
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub setLevel()
        Try
            Me.changeLevel()
            If Session("DocDOFilterLevel") <> "" Then
                Me.changeDOLevel()
            End If
            Me.ApplyFilter(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ApplyFilter(ByVal RebindGrid As Boolean)

        'objects
        Dim Job As AdvantageFramework.Database.Views.JobView = Nothing
        Dim JobComponent As AdvantageFramework.Database.Views.JobComponentView = Nothing
        Dim jobdata As AdvantageFramework.Database.Entities.Job = Nothing

        Session("DocVendorCode") = String.Empty
        Session("DocFilterLevel") = String.Empty
        Session("DocFilterValue") = String.Empty
        Session("DocDOFilterLevel") = String.Empty
        Session("DocOfficeValue") = String.Empty
        Session("DocClientValue") = String.Empty
        Session("DocDivisionValue") = String.Empty
        Session("DocProductValue") = String.Empty
        Session("DocVenAP") = String.Empty

        Me.MyUnityContextMenu.Visible = False
        Me.MyUnityContextMenu.JobNumber = 0
        Me.MyUnityContextMenu.JobComponentNumber = 0

        If Me.DocLevelDropDownList.SelectedIndex = 0 Then
            Me.ShowMessage("Please select filter level or use the Document Tree")
            Exit Sub
        Else
            SearchCriteriaTextBox.Text = String.Empty

            Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
            Dim myReq As cRequired = New cRequired(Session("ConnString"))
            Dim strCaption As String = String.Empty

            Select Case Me.DocLevelDropDownList.SelectedValue
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Office.Abbreviation
                    If Me.txtOffice.Text = String.Empty Then
                        Me.ShowMessage("Please enter an office code when filtering at the office level")
                        Exit Sub
                    End If
                    If myVal.ValidateOffice(Me.txtOffice.Text.Trim, True) = False Then
                        Me.ShowMessage("This is not a valid Office")
                        Exit Sub
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtOffice.Text
                    Session("HistoryFK") = Me.txtOffice.Text.Trim
                    strCaption &= "Office: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtOffice.Text.Trim)
                    Session("DocCaption") = String.Empty
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Client.Abbreviation
                    If Me.txtClient.Text = String.Empty Then
                        Me.ShowMessage("Please enter a client code when filtering at the client level")
                        Exit Sub
                    End If
                    If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                        Me.ShowMessage("This is not a valid Client")
                        Exit Sub
                    End If
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                        Me.ShowMessage("Access to this client is denied")
                        Exit Sub
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtClient.Text
                    Session("HistoryFK") = Me.txtClient.Text.Trim
                    Session("DocOfficeValue") = Me.txtOffice.Text
                    strCaption &= "Client: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtClient.Text.Trim)
                    Session("DocCaption") = String.Empty
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation
                    If Me.txtClient.Text = String.Empty Or Me.txtDivision.Text = String.Empty Then
                        Me.ShowMessage("Please enter a client and division code when filtering at the division level")
                        Exit Sub
                    End If
                    If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "", True) = False Then
                        Me.ShowMessage("This is not a valid Client, Division")
                        Exit Sub
                    End If
                    If myVal.ValidateCDPIsViewable(AdvantageFramework.DocumentManager.Classes.UploadLevels.Division.Abbreviation, Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, "") = False Then
                        Me.ShowMessage("Access to this division is denied")
                        Exit Sub
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtClient.Text & "," & Me.txtDivision.Text
                    Session("UploadFK") = Me.txtClient.Text & "," & Me.txtDivision.Text
                    Session("HistoryFK") = Me.txtClient.Text & "," & Me.txtDivision.Text
                    Session("DocOfficeValue") = Me.txtOffice.Text
                    strCaption &= "Division: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtClient.Text & "," & Me.txtDivision.Text)
                    Session("DocCaption") = String.Empty
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation
                    If Me.txtClient.Text = String.Empty Or Me.txtDivision.Text = String.Empty Or Me.txtProduct.Text = String.Empty Then
                        Me.ShowMessage("Please enter Client, Division, and Product codes when filtering at the product level")
                        Exit Sub
                    End If
                    If myVal.ValidateCDP(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, True) = False Then
                        Me.ShowMessage("This is not a valid Client, Division, Product")
                        Exit Sub
                    End If
                    If myVal.ValidateCDPIsViewable(AdvantageFramework.DocumentManager.Classes.UploadLevels.Product.Abbreviation, Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim) = False Then
                        Me.ShowMessage("Access to this product is denied")
                        Exit Sub
                    Else
                        Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                        Session("DocFilterValue") = Me.txtClient.Text & "," & Me.txtDivision.Text & "," & Me.txtProduct.Text
                        Session("UploadFK") = Me.txtClient.Text & "," & Me.txtDivision.Text & "," & Me.txtProduct.Text
                        Session("HistoryFK") = Me.txtClient.Text & "," & Me.txtDivision.Text & "," & Me.txtProduct.Text
                        Session("DocOfficeValue") = Me.txtOffice.Text
                        strCaption &= "Product: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtClient.Text & "," & Me.txtDivision.Text & "," & Me.txtProduct.Text)
                        Session("DocCaption") = String.Empty
                    End If
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Campaign.Abbreviation
                    If Me.txtClient.Text = String.Empty Or Me.txtCampaign.Text = String.Empty Then
                        Me.ShowMessage("Please enter Client and Campaign codes when filtering at the campaign level")
                        Exit Sub
                    End If
                    If myVal.ValidateCampaignFilter(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                        Me.ShowMessage("This is not a valid Campaign")
                        Exit Sub
                    End If
                    If myVal.ValidateCampaignIsViewable(Session("UserCode"), Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, Me.txtCampaign.Text.Trim) = False Then
                        Me.ShowMessage("Access to this campaign is denied")
                        Exit Sub
                    End If
                    'If Me.hfCampaignID.Value = String.Empty Then
                    Dim j As New cJobs(Session("ConnString"))
                    Me.hfCampaignID.Value = j.GetCampaignId(Me.txtCampaign.Text, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                    'End If
                    Dim cam As New CAMPAIGN(Session("ConnString"))
                    cam.LoadByPrimaryKey(Me.hfCampaignID.Value)
                    'If cam.Query.Load Then
                    If Me.txtDivision.Text = String.Empty Then
                        Me.txtDivision.Text = cam.DIV_CODE
                    End If
                    If Me.txtProduct.Text = String.Empty Then
                        Me.txtProduct.Text = cam.PRD_CODE
                    End If
                    'End If

                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocCampaignCode") = Me.txtCampaign.Text.Trim()
                    Session("DocFilterValue") = Me.hfCampaignID.Value   'Me.txtCampaign.Text
                    Session("DocOfficeValue") = Me.txtOffice.Text
                    Session("DocClientValue") = Me.txtClient.Text
                    Session("DocDivisionValue") = Me.txtDivision.Text
                    Session("DocProductValue") = Me.txtProduct.Text
                    Session("HistoryFK") = Me.hfCampaignID.Value    'GetCampaignIdentifier(Me.txtCampaign.Text.Trim) ', Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                    strCaption &= "Campaign: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtClient.Text & "," & Me.txtDivision.Text & "," & Me.txtProduct.Text & "," & Me.txtCampaign.Text)
                    Session("DocCaption") = String.Empty


                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Job.Abbreviation
                    If Me.txtJob.Text = String.Empty Then
                        Me.ShowMessage("Please enter a job number when filtering at the job level")
                        Exit Sub
                    End If
                    If IsNumeric(Me.txtJob.Text.Trim) = False Then
                        Me.ShowMessage("This is not a valid job number")
                        Exit Sub
                    End If
                    If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                        Me.ShowMessage("This job does not exist")
                    End If
                    If Me.txtJob.Text <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                            If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                                AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                                Me.ShowMessage("Access to this job is denied.")
                                Exit Sub
                            End If
                        End Using

                    End If
                    'If myVal.ValidateJobIsViewable(Session("Usercode"), Me.txtJob.Text.Trim) = False Then
                    '    Me.ShowMessage("Access to this job is denied")
                    '    Exit Sub
                    'End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtJob.Text
                    Session("HistoryFK") = Me.txtJob.Text

                    If String.IsNullOrWhiteSpace(Me.txtClient.Text) OrElse String.IsNullOrWhiteSpace(Me.txtDivision.Text) OrElse
                            String.IsNullOrWhiteSpace(Me.txtProduct.Text) OrElse String.IsNullOrWhiteSpace(Me.txtOffice.Text) Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                Job = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, Me.txtJob.Text)

                            Catch ex As Exception
                                Job = Nothing
                            End Try

                            If Job IsNot Nothing Then

                                Session("DocOfficeValue") = Job.OfficeCode
                                Session("DocClientValue") = Job.ClientCode
                                Session("DocDivisionValue") = Job.DivisionCode
                                Session("DocProductValue") = Job.ProductCode

                            End If

                        End Using

                    Else

                        Session("DocOfficeValue") = Me.txtOffice.Text
                        Session("DocClientValue") = Me.txtClient.Text
                        Session("DocDivisionValue") = Me.txtDivision.Text
                        Session("DocProductValue") = Me.txtProduct.Text

                    End If

                    strCaption &= "Job Number: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtJob.Text.Trim)
                    Session("DocCaption") = String.Empty
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation
                    If Me.txtJob.Text = String.Empty Or Me.txtComponent.Text = String.Empty Then
                        Me.ShowMessage("Please enter a job and job component number when filtering at the component level")
                        Exit Sub
                    End If
                    If IsNumeric(Me.txtJob.Text.Trim) = False Or IsNumeric(Me.txtComponent.Text.Trim) = False Then
                        Me.ShowMessage("This is not a valid job/comp number")
                        Exit Sub
                    End If
                    If myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                        Me.ShowMessage("This is not a valid job/component")
                        Exit Sub
                    End If
                    If Me.txtJob.Text <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            jobdata = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, txtJob.Text)
                            If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, _Session.User.EmployeeCode, txtJob.Text) = False AndAlso
                                AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, _Session.User.EmployeeCode, jobdata.ClientCode, jobdata.DivisionCode, jobdata.ProductCode) = False Then
                                Me.ShowMessage("Access to this job is denied.")
                                Exit Sub
                            End If
                        End Using

                    End If
                    'If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim, Me.txtComponent.Text.Trim) = False Then
                    '    Me.ShowMessage("Access to this job/component is denied")
                    '    Exit Sub
                    'End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtJob.Text & "," & Me.txtComponent.Text
                    Session("HistoryFK") = Me.txtJob.Text & "," & Me.txtComponent.Text

                    If String.IsNullOrWhiteSpace(Me.txtClient.Text) OrElse String.IsNullOrWhiteSpace(Me.txtDivision.Text) OrElse
                            String.IsNullOrWhiteSpace(Me.txtProduct.Text) OrElse String.IsNullOrWhiteSpace(Me.txtOffice.Text) Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                JobComponent = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, Me.txtJob.Text, Me.txtComponent.Text)

                            Catch ex As Exception
                                JobComponent = Nothing
                            End Try

                            If JobComponent IsNot Nothing Then

                                Session("DocOfficeValue") = JobComponent.OfficeCode
                                Session("DocClientValue") = JobComponent.ClientCode
                                Session("DocDivisionValue") = JobComponent.DivisionCode
                                Session("DocProductValue") = JobComponent.ProductCode

                            End If

                        End Using

                    Else

                        Session("DocOfficeValue") = Me.txtOffice.Text
                        Session("DocClientValue") = Me.txtClient.Text
                        Session("DocDivisionValue") = Me.txtDivision.Text
                        Session("DocProductValue") = Me.txtProduct.Text

                    End If

                    strCaption &= "Job/Comp Number: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtJob.Text.Trim & "," & Me.txtComponent.Text.Trim)
                    Session("DocCaption") = String.Empty

                    Me.MyUnityContextMenu.Visible = True

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsPayableInvoice.Abbreviation
                    If Me.txtVendor.Text = String.Empty Or Me.txtAPInvoice.Text = String.Empty Then
                        Me.ShowMessage("Please enter a Vendor and AP Invoice number when filtering at the Vendor level")
                        Exit Sub
                    End If
                    If myVal.ValidateVendor(Me.txtVendor.Text) = False Then
                        Me.ShowMessage("This is not a valid Vendor")
                        Exit Sub
                    End If
                    If myVal.ValidateAPInvoice(Me.txtAPInvoice.Text) = False Then
                        Me.ShowMessage("This is not a valid AP Invoice number")
                        Exit Sub
                    End If
                    If myVal.ValidateVendorAPInvoice(Me.txtAPInvoice.Text, Me.txtVendor.Text) = False Then
                        Me.ShowMessage("This is not a valid Vendor/AP Invoice number")
                        Exit Sub
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Dim desc As String
                    Dim dr As SqlDataReader = myReq.GetAPID(Me.txtAPInvoice.Text, Me.txtVendor.Text)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            Session("DocFilterValue") = dr.GetInt32(0).ToString
                            Session("HistoryFK") = dr.GetInt32(0).ToString
                            Session("DocVendorCode") = Me.txtVendor.Text
                            Session("DocVenAP") = Me.txtVendor.Text & "," & Me.txtAPInvoice.Text
                            desc = dr.GetString(4) & " - " & dr.GetString(5) & ", " & dr.GetString(1) & " - Inv #: " & dr.GetString(2) & " - " & dr.GetDateTime(3).ToShortDateString
                        Loop
                    End If
                    strCaption &= "Vendor/AP Invoice: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtVendor.Text.Trim & "," & Me.txtAPInvoice.Text.Trim)
                    Session("DocCaption") = desc
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AccountsReceivableInvoice.Abbreviation
                    If Me.TextBox_AccountsReceivableClient.Text = String.Empty Or Me.TextBox_AccountsReceivableInvoice.Text = String.Empty Then
                        Me.ShowMessage("Please enter a Client and Invoice number when filtering at the AR Invoice level")
                        Exit Sub
                    End If

                    'If myVal.ValidateAPInvoice(Me.TextBox_AccountsReceivableInvoice.Text) = False Then
                    '    Me.ShowMessage("This is not a valid AR Invoice number")
                    '    Exit Sub
                    'End If

                    Session("DocClientCode") = Me.TextBox_AccountsReceivableClient.Text.Trim()
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.TextBox_AccountsReceivableInvoice.Text.Trim()


                    Dim desc As String
                    'Dim dr As SqlDataReader = myReq.GetAPID(Me.txtAPInvoice.Text, Me.txtVendor.Text)
                    'If dr.HasRows = True Then
                    '    Do While dr.Read
                    '        Session("DocFilterValue") = dr.GetInt32(0).ToString
                    '        Session("HistoryFK") = dr.GetInt32(0).ToString
                    '        Session("DocVendorCode") = Me.txtVendor.Text
                    '        Session("DocVenAP") = Me.txtVendor.Text & "," & Me.txtAPInvoice.Text
                    '        desc = dr.GetString(4) & " - " & dr.GetString(5) & ", " & dr.GetString(1) & " - Inv #: " & dr.GetString(2) & " - " & dr.GetDateTime(3).ToShortDateString
                    '    Loop
                    'End If

                    strCaption &= "Client/AR Invoice: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.TextBox_AccountsReceivableClient.Text.Trim & "," & Me.TextBox_AccountsReceivableInvoice.Text.Trim)
                    Session("DocCaption") = desc
                    Session("HistoryFK") = TextBox_AccountsReceivableInvoice.Text.Trim()
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Vendor.Abbreviation
                    If Me.txtVendor.Text = String.Empty Then
                        Me.ShowMessage("Please enter a Vendor when filtering at the Vendor level")
                        Exit Sub
                    End If
                    If myVal.ValidateVendor(Me.txtVendor.Text) = False Then
                        Me.ShowMessage("This is not a valid Vendor")
                        Exit Sub
                    End If

                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtVendor.Text

                    Dim desc As String

                    strCaption &= "Vendor: " & myReq.GetDescription("VN2", Me.txtVendor.Text.Trim())
                    Session("DocCaption") = desc
                    Session("HistoryFK") = txtVendor.Text.Trim()
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.DesktopObject.Abbreviation
                    If Me.txtOffice.Text.Trim <> "" Then
                        If myVal.ValidateOffice(Me.txtOffice.Text.Trim, True) = False Then
                            Me.ShowMessage("This is not a valid Office")
                            Exit Sub
                        End If
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Select Case Me.ddlDesktopObject.SelectedValue
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AgencyDesktop.Abbreviation
                            Session("DocFilterValue") = Me.txtOffice.Text & "," & Me.txtDept.Text
                            Session("DocDOFilterLevel") = Me.ddlDesktopObject.SelectedValue
                            Session("HistoryFK") = Me.txtOffice.Text.Trim & "," & Me.txtDept.Text
                            strCaption &= "Agency Desktop: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtOffice.Text.Trim)
                        Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExecutiveDesktop.Abbreviation
                            Session("DocFilterValue") = Me.txtOffice.Text & "," & Me.txtEmp.Text
                            Session("DocDOFilterLevel") = Me.ddlDesktopObject.SelectedValue
                            Session("HistoryFK") = Me.txtOffice.Text.Trim & "," & Me.txtEmp.Text
                            strCaption &= "Executive Desktop: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtOffice.Text.Trim)
                    End Select
                    Session("DocCaption") = String.Empty
                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.AdNumber.Abbreviation
                    If Me.txtClient.Text <> "" Then
                        If myVal.ValidateCDP(Me.txtClient.Text.Trim, "", "", True) = False Then
                            Me.ShowMessage("This is not a valid Client")
                            Exit Sub
                        End If
                        If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim, "", "") = False Then
                            Me.ShowMessage("Access to this client is denied")
                            Exit Sub
                        End If
                    End If
                    If myVal.ValidateAdNumber(Me.txtAdNumber.Text) = False Then
                        Me.ShowMessage("This is not a valid Ad Number")
                        Exit Sub
                    End If
                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtAdNumber.Text
                    Session("HistoryFK") = Me.txtAdNumber.Text.Trim
                    Session("DocClientValue") = Me.txtClient.Text
                    strCaption &= "Ad Number: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtAdNumber.Text.Trim)
                    Session("DocCaption") = "Ad Number: " & Me.txtAdNumber.Text

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.ExpenseReceipt.Abbreviation
                    If Me.txtEmp.Text.Trim() = String.Empty Or Me.txtExInv.Text.Trim() = String.Empty Then
                        Me.ShowMessage("Please enter an Employee and Invoice number when filtering at the Expense Receipts level")
                        Exit Sub
                    Else

                        If myVal.ValidateEmpCode(Me.txtEmp.Text.Trim()) = False Then
                            Me.ShowMessage("This is not a valid Employee")
                            If Me.txtEmp.Text.Trim() = String.Empty Then
                                Me.txtExInv.Text = String.Empty
                            End If
                            Exit Sub
                        End If

                        If Not IsNumeric(Me.txtExInv.Text) Then
                            Me.ShowMessage("This is not a valid Invoice Number")
                            Exit Sub
                        Else
                            If myVal.ValidateExpenseInv(Me.txtExInv.Text, "") = False Then
                                Me.ShowMessage("This is not a valid Invoice Number")
                                Exit Sub
                            End If
                        End If

                    End If

                    'Validate valid Invoice for this employee
                    If myVal.ValidateExpenseInv(Me.txtExInv.Text, Me.txtEmp.Text) = False Then
                        Me.ShowMessage("This is not a valid Employee/Invoice Number")
                        Exit Sub
                    End If


                    'If myVal.ValidateDateTextBox(Me.txtdate, False) = False Then
                    '    Me.ShowMessage("This is not a valid Date")
                    '    Exit Sub
                    'End If

                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtEmp.Text.Trim() & "|" & Me.txtExInv.Text.Trim()
                    Session("HistoryFK") = Me.txtExInv.Text.Trim
                    strCaption &= "Expense Invoice Number: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtExInv.Text.Trim)
                    Session("DocCaption") = "Expense Invoice Number: " & Me.txtExInv.Text

                Case AdvantageFramework.DocumentManager.Classes.UploadLevels.Employee.Abbreviation
                    If Me.txtEmp.Text.Trim() = String.Empty Then
                        Me.ShowMessage("Please enter an Employee id when filtering at the Employee level")
                        Exit Sub
                    Else

                        If myVal.ValidateEmpCode(Me.txtEmp.Text.Trim()) = False Then
                            Me.ShowMessage("This is not a valid Employee")
                            If Me.txtEmp.Text.Trim() = String.Empty Then
                                Me.txtExInv.Text = String.Empty
                            End If
                            Exit Sub
                        End If

                    End If

                    Session("DocFilterLevel") = Me.DocLevelDropDownList.SelectedValue
                    Session("DocFilterValue") = Me.txtEmp.Text.Trim()
                    Session("HistoryFK") = Me.txtEmp.Text.Trim
                    strCaption &= "Employee: " & myReq.GetDescription(Me.DocLevelDropDownList.SelectedValue, Me.txtEmp.Text.Trim)
                    'strCaption = "Employee: " & Me.txtEmp.Text
                    Session("DocCaption") = "Employee: " & Me.txtEmp.Text

                Case Else
                    Session("DocFilterValue") = String.Empty
                    strCaption &= String.Empty

                    ' ClientScript.RegisterStartupScript(Me.GetType, "alert_nothandled", "alert('" + Me.DocLevelDropDownList.SelectedValue + " filter not implemented!');", True)
                    Exit Sub
            End Select
            'Me.RadGridDocuments.DataSource = FillFileListFromFilter(Session("DocFilterLevel"), Session("DocFilterValue"))
            If RebindGrid Then

                Me.RadGridDocuments.Rebind()
                Me.RadToolbarDocumentManager.FindItemByValue("Delete").Enabled = False
                If _IsJobDashboard = False Then Me.RadGridDocuments.MasterTableView.Caption = strCaption

            End If

        End If
    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        If Me.DocLevelDropDownList.SelectedValue IsNot Nothing AndAlso Me.DocLevelDropDownList.SelectedValue = AdvantageFramework.DocumentManager.Classes.UploadLevels.JobComponent.Abbreviation Then

            Me.MyUnityContextMenu.JobNumber = Me.txtJob.Text
            Me.MyUnityContextMenu.JobComponentNumber = Me.txtComponent.Text

        End If

    End Sub

#End Region

    ''#Region " Label Tooltip "

    ''    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)

    ''        Me.UpdateToolTip(args.Value, args.UpdatePanel)

    ''    End Sub
    ''    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)

    ''        Dim ctrl As System.Web.UI.Control = Page.LoadControl("Document_Label_Tree.ascx")
    ''        panel.ContentTemplateContainer.Controls.Add(ctrl)

    ''        Dim t As Document_Label_Tree_UC = DirectCast(ctrl, Document_Label_Tree_UC)
    ''        t.DocumentID = ArguementValue
    ''        t.LoadLabels()
    ''        t.LoadExistingLabelsForDocument()

    ''    End Sub

    ''#End Region

End Class
