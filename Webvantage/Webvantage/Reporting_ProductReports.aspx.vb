Public Class Reporting_ProductReports
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

    Private Sub LoadReports()

        Dim EnumObjectAttributeList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

        EnumObjectAttributeList = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.ProductReportTypes)).ToList

        If _IsCRMUser Then

            For Each EnumObjectAttribute In EnumObjectAttributeList.ToList

                If EnumObjectAttribute.Code = "36" Then

                    EnumObjectAttributeList.Remove(EnumObjectAttribute)
                    Exit For

                End If

            Next

        End If

        RadListBoxReportFormats.DataSource = EnumObjectAttributeList
        RadListBoxReportFormats.DataBind()

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_ProductReports_Init(sender As Object, e As EventArgs) Handles Me.Init

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
    Private Sub Reporting_ProductReports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Product Reports"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            LoadReports()

        End If

    End Sub
    Private Sub Reporting_ProductReports_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        _DbContext.Database.Connection.Close()

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarProductReports_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProductReports.ButtonClick

        'objects
        Dim ProductReportType As AdvantageFramework.Reporting.ProductReportTypes = -1
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
        Dim ContractList As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing
        Dim ShowReport As Boolean = False

        Select Case e.Item.Value

            Case RadToolBarButtonPrint.Value

                If String.IsNullOrEmpty(RadListBoxReportFormats.SelectedValue) = False AndAlso IsNumeric(RadListBoxReportFormats.SelectedValue) Then

                    Try

                        ProductReportType = [Enum].Parse(GetType(AdvantageFramework.Reporting.ProductReportTypes), RadListBoxReportFormats.SelectedValue)

                    Catch ex As Exception
                        ProductReportType = -1
                    End Try

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    Select Case ProductReportType

                        Case AdvantageFramework.Reporting.ProductReportTypes.Detail

                            ProductList = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(_DbContext).Include("Office").Include("Client").Include("Division").Include("AccountExecutives")
                                           Where Entity.Code = _ProductCode AndAlso
                                                 Entity.ClientCode = _ClientCode AndAlso
                                                 Entity.DivisionCode = _DivisionCode
                                           Select Entity
                                           Order By Entity.Code).ToList

                            ParameterDictionary.Add("DataSource", ProductList)
                            ShowReport = True

                        Case AdvantageFramework.Reporting.ProductReportTypes.CRMDetailedInformation

                            ProductList = (From Entity In AdvantageFramework.Database.Procedures.Product.Load(_DbContext).Include("Client")
                                           Where Entity.Code = _ProductCode AndAlso
                                                 Entity.ClientCode = _ClientCode AndAlso
                                                 Entity.DivisionCode = _DivisionCode
                                           Select Entity
                                           Order By Entity.Code).ToList

                            ParameterDictionary.Add("DataSource", ProductList)
                            ShowReport = True

                        Case AdvantageFramework.Reporting.ProductReportTypes.ClientContractAndOpportunityDetail

                            ContractList = (From Entity In AdvantageFramework.Database.Procedures.Contract.Load(_DbContext).Include("Product").
                                                                                                                                Include("Product.Client").
                                                                                                                                Include("ContractFees").
                                                                                                                                Include("ContractFees.ServiceFeeType").
                                                                                                                                Include("ContractContacts").
                                                                                                                                Include("ContractReports").
                                                                                                                                Include("ContractReports.Cycle").
                                                                                                                                Include("ContractValueAddeds")
                                            Where Entity.ProductCode = _ProductCode AndAlso
                                                  Entity.ClientCode = _ClientCode AndAlso
                                                  Entity.DivisionCode = _DivisionCode
                                            Select Entity
                                            Order By Entity.Code).ToList

                            If ContractList IsNot Nothing AndAlso ContractList.Count > 0 Then

                                ParameterDictionary.Add("DataSource", ContractList)
                                ShowReport = True

                            Else

                                Me.ShowMessage("No contracts/opportunities to print.")
                                ShowReport = False

                            End If

                    End Select

                    If ShowReport = True Then

                        Session("Report_ParameterDictionary") = ParameterDictionary

                        Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & ProductReportType, True)

                    End If

                Else

                    Me.ShowMessage("Please select a report format.")

                End If

        End Select

    End Sub

#End Region

#End Region

End Class