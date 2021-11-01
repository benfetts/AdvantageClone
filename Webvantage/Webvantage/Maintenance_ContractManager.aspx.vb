Public Class Maintenance_ContractManager
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _IsCRMUser As Boolean = False
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadContractsTab()

        Dim Contracts As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

            Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

        ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

            Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionCode(_DbContext, _ClientCode, _DivisionCode).ToList

        ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

            Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientCode(_DbContext, _ClientCode).ToList

        Else

            Contracts = New Generic.List(Of AdvantageFramework.Database.Entities.Contract)

        End If


        RadGridContracts.DataSource = Contracts

        RadGridContracts.DataBind()

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ContractManager_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        _DbContext.Database.Connection.Open()

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller").ToString

        End If

        If Request.QueryString("ClientCode") IsNot Nothing Then

            _ClientCode = Request.QueryString("ClientCode").ToString

        End If

        If Request.QueryString("DivisionCode") IsNot Nothing Then

            _DivisionCode = Request.QueryString("DivisionCode").ToString

        End If

        If Request.QueryString("ProductCode") IsNot Nothing Then

            _ProductCode = Request.QueryString("ProductCode").ToString

        End If

    End Sub
    Private Sub Maintenance_ContractManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Contract Manager"

        RadToolBarButtonAdd.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadGridContracts.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            LoadContractsTab()

        End If

    End Sub
    Private Sub Maintenance_ContractManager_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        _DbContext.Database.Connection.Close()

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarContract_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarContract.ButtonClick

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonAdd.Value

                Me.OpenWindow("New Contract", "Maintenance_ContractEdit.aspx?Caller=Maintenance_ContractManager&Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

        End Select

    End Sub
    Private Sub RadGridContracts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContracts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContracts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                Me.OpenWindow("Contract Edit", "Maintenance_ContractEdit.aspx?Caller=Maintenance_ContractManager&Mode=Open&ContractID=" & CurrentGridDataItem.GetDataKeyValue("ID") & "&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(_DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                    If Contract IsNot Nothing Then

                        Reload = AdvantageFramework.Database.Procedures.Contract.Delete(_DbContext, Contract)

                    End If

                End If

        End Select

        If Reload Then

            LoadContractsTab()

        End If

    End Sub
    Private Sub RadGridContracts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContracts.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageDocuments As System.Web.UI.WebControls.Image = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            Dim Item As Telerik.Web.UI.GridDataItem = e.Item

            Select Case e.Item.ItemType

                Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                    Dim DivDocuments As HtmlControls.HtmlControl = e.Item.FindControl("divDocuments")
                    ImageDocuments = DirectCast(e.Item.FindControl("DocumentsImage"), Image)

                    Dim ContractDocuments As Generic.List(Of AdvantageFramework.Database.Entities.ContractDocument) = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ContractDocuments = AdvantageFramework.Database.Procedures.ContractDocument.LoadByContractID(DbContext, Item.GetDataKeyValue("ID")).ToList

                    End Using

                    If ContractDocuments.Count = 0 Then

                        DivDocuments.Visible = False

                    Else

                        If ImageDocuments IsNot Nothing Then

                            ImageDocuments.ToolTip = ContractDocuments.Count.ToString & " Documents"

                        End If

                    End If

            End Select

        Catch ex As Exception

        End Try







    End Sub

#End Region

#End Region

End Class
