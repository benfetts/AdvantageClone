Namespace Client

    Public Class DivisionDetailReport

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

        Private Function LoadCurrentDivision() As AdvantageFramework.Database.Entities.Division

            Try

                LoadCurrentDivision = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Division)

            Catch ex As Exception
                LoadCurrentDivision = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub DivisionDetailReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

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
        Private Sub DetailReportContacts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportContacts.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ClientContactList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
            Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
            Dim ClientContactDetailList As Integer() = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Division).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Division).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContactIDs = New Generic.List(Of Integer)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                               Where Entity.DivisionCode = DivisionCode
                                               Select Entity.ContactID).ToArray)

                    ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode).Include("ClientContactDetail")
                                               Where Entity.ClientContactDetail.Count = 0
                                               Select Entity.ContactID).ToArray)

                    ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                    ClientContactList = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, ClientCode)
                                         Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                    BindingSourceClientContact.DataSource = ClientContactList

                End Using

            Catch ex As Exception
                DetailReportContacts.DataSource = Nothing
            End Try

            If DetailReportContacts.DataSource Is Nothing OrElse ClientContactList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportProducts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportProducts.BeforePrint

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing

            Try

                ClientCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Division).ClientCode
                DivisionCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Division).Code

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ProductList = New Generic.List(Of AdvantageFramework.Database.Entities.Product)

                    ProductList.AddRange(AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).Include("Office").ToList)

                    BindingSourceProduct.DataSource = ProductList

                End Using

            Catch ex As Exception
                DetailReportProducts.DataSource = Nothing
            End Try

            If DetailReportProducts.DataSource Is Nothing OrElse ProductList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Label_DivisionStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_DivisionStatus.BeforePrint

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Status As String = ""

            Try

                Division = LoadCurrentDivision()

                If Division IsNot Nothing Then

                    Status = If(Division.IsActive.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_DivisionStatus.Text = Status
            End Try

        End Sub
        Private Sub Label_DivisionContactStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_DivisionContactStatus.BeforePrint

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
                Label_DivisionContactStatus.Text = Status
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
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim CityStateZip As String = ""

            Try

                Division = LoadCurrentDivision()

                If Division IsNot Nothing Then

                    CityStateZip = Division.BillingCity & ", " & Division.BillingState & "  " & Division.BillingZip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelBilling_CityStateZip.Text = CityStateZip
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
        Private Sub LabelStatement_CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelStatement_CityStateZip.BeforePrint

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim CityStateZip As String = ""

            Try

                Division = LoadCurrentDivision()

                If Division IsNot Nothing Then

                    CityStateZip = Division.City & ", " & Division.State & "  " & Division.Zip

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                LabelStatement_CityStateZip.Text = CityStateZip
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
