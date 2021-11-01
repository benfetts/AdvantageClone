Namespace Client

    Public Class ClientDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentClient() As AdvantageFramework.Database.Entities.Client

            Try

                LoadCurrentClient = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Client)

            Catch ex As Exception
                LoadCurrentClient = Nothing
            End Try

        End Function
        Private Function GetMediaInvoiceFormat(ByVal LegacyModuleCode As String) As String

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim CustomReport As AdvantageFramework.Database.Entities.CustomReport = Nothing
            Dim MediaInvoiceFormat As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                        If MediaInvoiceDefault IsNot Nothing Then

                            Select Case LegacyModuleCode

                                Case "MI"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.MagazineCustomFormat
                                                    Select Entity).SingleOrDefault

                                Case "NI"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.NewspaperCustomFormat
                                                    Select Entity).SingleOrDefault

                                Case "II"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.InternetCustomFormat
                                                    Select Entity).SingleOrDefault

                                Case "OI"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.OutOfHomeCustomFormat
                                                    Select Entity).SingleOrDefault

                                Case "RI"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.RadioCustomFormat
                                                    Select Entity).SingleOrDefault

                                Case "TI"

                                    CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                    Where Entity.LegacyModuleCode = LegacyModuleCode AndAlso
                                                          Entity.Name = MediaInvoiceDefault.TVCustomFormat
                                                    Select Entity).SingleOrDefault

                            End Select

                            If CustomReport IsNot Nothing Then

                                MediaInvoiceFormat = CustomReport.Description

                            Else

                                MediaInvoiceFormat = "Agency Default"

                            End If

                        Else

                            MediaInvoiceFormat = "Agency Default"

                        End If

                    End Using

                End If

            Catch ex As Exception
                MediaInvoiceFormat = "Agency Default"
            Finally
                GetMediaInvoiceFormat = MediaInvoiceFormat
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

        End Sub
        Private Sub Label_ProductionInvoiceBy_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductionInvoiceBy.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ProductionInvoiceBy As String = Nothing

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    Select Case Client.AssignProductionInvoicesBy.GetValueOrDefault(0)

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Job

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Job.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.JobComponent

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.JobComponent.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.ProductSalesClass

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.ProductSalesClass.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Campaign

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Campaign.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.PurchaseOrder

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.PurchaseOrder.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Client

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Client.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Division

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Division.ToString

                        Case AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Product

                            ProductionInvoiceBy = AdvantageFramework.Database.Entities.AssignProductionInvoicesBy.Product.ToString

                    End Select

                End If

            Catch ex As Exception
                ProductionInvoiceBy = ""
            Finally
                Label_ProductionInvoiceBy.Text = ProductionInvoiceBy
            End Try

        End Sub
        Private Sub Label_ProductionInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductionInvoiceFormat.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim CustomReport As AdvantageFramework.Database.Entities.CustomReport = Nothing
            Dim ProductionInvoiceFormat As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, Client.Code)

                        If ProductionInvoiceDefault IsNot Nothing Then

                            Try

                                CustomReport = (From Entity In AdvantageFramework.Database.Procedures.CustomReport.Load(DbContext)
                                                Where Entity.LegacyModuleCode = "PI" AndAlso
                                                      Entity.Name = ProductionInvoiceDefault.CustomFormatName
                                                Select Entity).SingleOrDefault

                                ProductionInvoiceFormat = CustomReport.Description

                            Catch ex As Exception
                                ProductionInvoiceFormat = "Agency Default"
                            End Try

                        Else

                            ProductionInvoiceFormat = "Agency Default"

                        End If

                    End Using

                End If

            Catch ex As Exception
                ProductionInvoiceFormat = "Agency Default"
            Finally
                Label_ProductionInvoiceFormat.Text = ProductionInvoiceFormat
            End Try

        End Sub
        Private Sub Label_MediaInvoiceBy_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_MediaInvoiceBy.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim MediaInvoiceBy As String = Nothing

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    Select Case Client.AssignMediaInvoicesBy.GetValueOrDefault(0)

                        Case 1

                            MediaInvoiceBy = "Sales Class"

                        Case 2

                            MediaInvoiceBy = "Client P.O."

                        Case 3

                            MediaInvoiceBy = "Market"

                        Case 4

                            MediaInvoiceBy = "Order #"

                        Case 5

                            MediaInvoiceBy = "Campaign"

                        Case 6

                            MediaInvoiceBy = "Order Type"

                    End Select

                End If

            Catch ex As Exception
                MediaInvoiceBy = ""
            Finally
                Label_MediaInvoiceBy.Text = MediaInvoiceBy
            End Try

        End Sub
        Private Sub Label_MagazineInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_MagazineInvoiceFormat.BeforePrint

            Label_MagazineInvoiceFormat.Text = GetMediaInvoiceFormat("MI")

        End Sub
        Private Sub Label_InternetInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_InternetInvoiceFormat.BeforePrint

            Label_InternetInvoiceFormat.Text = GetMediaInvoiceFormat("II")

        End Sub
        Private Sub Label_NewspaperInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_NewspaperInvoiceFormat.BeforePrint

            Label_NewspaperInvoiceFormat.Text = GetMediaInvoiceFormat("NI")

        End Sub
        Private Sub Label_OutofHomeInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_OutofHomeInvoiceFormat.BeforePrint

            Label_OutofHomeInvoiceFormat.Text = GetMediaInvoiceFormat("OI")

        End Sub
        Private Sub Label_RadioInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_RadioInvoiceFormat.BeforePrint

            Label_RadioInvoiceFormat.Text = GetMediaInvoiceFormat("RI")

        End Sub
        Private Sub Label_TVInvoiceFormat_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_TVInvoiceFormat.BeforePrint

            Label_TVInvoiceFormat.Text = GetMediaInvoiceFormat("TI")

        End Sub
        Private Sub DetailReportWebsites_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportWebsites.BeforePrint

            Dim ClientCode As String = Nothing
            Dim ClientWebsiteList As Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Client).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientWebsiteList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientWebsite)

                    ClientWebsiteList.AddRange(AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, ClientCode).Include("WebsiteType").ToList)

                    BindingSourceClientWebsite.DataSource = ClientWebsiteList

                End Using

            Catch ex As Exception
                DetailReportWebsites.DataSource = Nothing
            End Try

            If DetailReportWebsites.DataSource Is Nothing OrElse ClientWebsiteList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportContacts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportContacts.BeforePrint

            Dim ClientCode As String = Nothing
            Dim ClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Client).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)

                    ClientContactList.AddRange(AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode).ToList)

                    BindingSourceClientContact.DataSource = ClientContactList

                End Using

            Catch ex As Exception
                DetailReportContacts.DataSource = Nothing
            End Try

            If DetailReportContacts.DataSource Is Nothing OrElse ClientContactList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportDivisionsProducts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportDivisions.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Client).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DivisionList = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

                    DivisionList.AddRange(AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).ToList)

                    BindingSourceDivision.DataSource = DivisionList

                End Using

            Catch ex As Exception
                DetailReportDivisions.DataSource = Nothing
            End Try

            If DetailReportDivisions.DataSource Is Nothing OrElse DivisionList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportProducts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportProducts.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Client).Code
                DivisionCode = DirectCast(Me.DetailReportDivisions.GetCurrentRow, AdvantageFramework.Database.Entities.Division).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ProductList = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

                    ProductList.AddRange(AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList)

                    BindingSourceProduct.DataSource = ProductList

                End Using

            Catch ex As Exception
                DetailReportProducts.DataSource = Nothing
            End Try

            If DetailReportProducts.DataSource Is Nothing OrElse ProductList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Label_FiscalStartMonth_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_FiscalStartMonth.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Month As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    If Client.FiscalStart.GetValueOrDefault(0) <> 0 Then

                        Month = MonthName(Client.FiscalStart)

                    End If

                End If

            Catch ex As Exception
                Month = ""
            Finally
                Label_FiscalStartMonth.Text = Month
            End Try

        End Sub
        Private Sub Label_ClientStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ClientStatus.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Status As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    Status = If(Client.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_ClientStatus.Text = Status
            End Try

        End Sub
        Private Sub LabelGeneral_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGeneral_CityStateZip.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim CityStateZip As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    CityStateZip = Client.City & ", " & Client.State & "  " & Client.Zip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelGeneral_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub Label_WebsiteStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_WebsiteStatus.BeforePrint

            'objects
            Dim ClientWebsite As AdvantageFramework.Database.Entities.ClientWebsite = Nothing
            Dim Status As String = ""

            Try

                ClientWebsite = TryCast(Me.DetailReportWebsites.GetCurrentRow, AdvantageFramework.Database.Entities.ClientWebsite)

                If ClientWebsite IsNot Nothing Then

                    Status = If(ClientWebsite.IsInactive, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_WebsiteStatus.Text = Status
            End Try

        End Sub
        Private Sub Label_ClientContactStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ClientContactStatus.BeforePrint

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim Status As String = ""

            Try

                ClientContact = TryCast(Me.DetailReportContacts.GetCurrentRow, AdvantageFramework.Database.Entities.ClientContact)

                If ClientContact IsNot Nothing Then

                    Status = If(ClientContact.IsInactive.GetValueOrDefault(0) = 1, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_ClientContactStatus.Text = Status
            End Try

        End Sub
        Private Sub Label_DivisionStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_DivisionStatus.BeforePrint

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Status As String = ""

            Try

                Division = TryCast(Me.DetailReportDivisions.GetCurrentRow, AdvantageFramework.Database.Entities.Division)

                If Division IsNot Nothing Then

                    Status = If(Division.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_DivisionStatus.Text = Status
            End Try

        End Sub
        Private Sub Label_ProductStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductStatus.BeforePrint

            'objects
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Status As String = ""

            Try

                Product = TryCast(Me.DetailReportProducts.GetCurrentRow, AdvantageFramework.Database.Entities.Product)

                If Product IsNot Nothing Then

                    Status = If(Product.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_ProductStatus.Text = Status
            End Try

        End Sub
        Private Sub LabelBilling_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelBilling_CityStateZip.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim CityStateZip As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    CityStateZip = Client.BillingCity & ", " & Client.BillingState & "  " & Client.BillingZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelBilling_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub LabelBilling_StatementCityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelBilling_StatementCityStateZip.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim CityStateZip As String = ""

            Try

                Client = LoadCurrentClient()

                If Client IsNot Nothing Then

                    CityStateZip = Client.StatementCity & ", " & Client.StatementState & "  " & Client.StatementZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelBilling_StatementCityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub LabelContact_ContactName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelContact_ContactName.BeforePrint

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ContactName As String = ""

            Try

                ClientContact = TryCast(DetailReportContacts.GetCurrentRow, AdvantageFramework.Database.Entities.ClientContact)

                If ClientContact IsNot Nothing Then

                    ContactName = ClientContact.ToString

                End If

            Catch ex As Exception
                ContactName = ""
            Finally
                LabelContact_ContactName.Text = ContactName
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
