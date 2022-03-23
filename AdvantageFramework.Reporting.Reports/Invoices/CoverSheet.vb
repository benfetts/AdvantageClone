Namespace Invoices

    Public Class CoverSheet
        Implements AdvantageFramework.Reporting.Reports.ICustomReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Private _UserCode As String = Nothing
        Private _IsDraft As Boolean = False
        Private _CoversheetLayout As AdvantageFramework.InvoicePrinting.CoversheetLayouts = AdvantageFramework.InvoicePrinting.CoversheetLayouts.Default
        Private _CoversheetContact As AdvantageFramework.InvoicePrinting.CoversheetContacts = AdvantageFramework.InvoicePrinting.CoversheetContacts.None
        Private _ContactTypeID As Integer = -1
        Private _CoversheetContactLocation As AdvantageFramework.InvoicePrinting.CoversheetContactLocations = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AttnLine
        Private _CoversheetTitle As String = String.Empty
        Private _ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
        Private _HeaderLocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
        Private _FooterLocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
        Private _IsMultiCurrencyEnabled As Boolean = False
        Private _HasMultiCurrenciesInDataset As Boolean = False
        Private _CurrencyCode As String = String.Empty
        Private _CurrencySymbol As String = String.Empty

#End Region

#Region " Properties "

        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements ICustomReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
            Set(value As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice))
                _AccountReceivableInvoices = value
            End Set
        End Property
        Public WriteOnly Property UserCode As String
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        Public WriteOnly Property IsDraft As Boolean
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub CoverSheet_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                _CoversheetLayout = AdvantageFramework.InvoicePrinting.LoadCoversheetLayout(DataContext)

                _CoversheetTitle = AdvantageFramework.InvoicePrinting.LoadCoversheetTitle(DataContext)

                _CoversheetContact = AdvantageFramework.InvoicePrinting.LoadCoversheetContact(DataContext)
                _ContactTypeID = AdvantageFramework.InvoicePrinting.LoadCoversheetContactType(DataContext)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _CoversheetContact = AdvantageFramework.InvoicePrinting.CoversheetContacts.ContactType Then

                        If _ContactTypeID > 0 Then

                            Try

                                _ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, _AccountReceivableInvoices(0).ClientCode).FirstOrDefault(Function(Entity) Entity.ContactTypeID = _ContactTypeID)

                            Catch ex As Exception
                                _ClientContact = Nothing
                            End Try

                        End If

                    ElseIf _CoversheetContact = AdvantageFramework.InvoicePrinting.CoversheetContacts.FirstFound Then

                        Try

                            _ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, _AccountReceivableInvoices(0).ClientCode).FirstOrDefault()

                        Catch ex As Exception
                            _ClientContact = Nothing
                        End Try

                    End If

                End Using

                _CoversheetContactLocation = AdvantageFramework.InvoicePrinting.LoadCoversheetContactLocation(DataContext)

            End Using

        End Sub
        Private Sub CoverSheet_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim CoverSheets As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet) = Nothing
            Dim OrderedCoverSheets As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet) = Nothing
            Dim PreviousCurrencyCode As String = String.Empty
            Dim Batches As Generic.List(Of String) = Nothing

            If _AccountReceivableInvoices IsNot Nothing AndAlso _Session IsNot Nothing Then

                If _IsDraft Then

                    Batches = _AccountReceivableInvoices.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.Batch) = False).Select(Function(Entity) Entity.Batch).Distinct.ToList

                Else

                    Batches = New Generic.List(Of String)

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

                    CoverSheets = AdvantageFramework.InvoicePrinting.LoadCoverSheet(DbContext, _UserCode,
                                                                                    Join(_AccountReceivableInvoices.Select(Function(Entity) CStr(Entity.InvoiceNumber)).ToList.ToArray(), ","),
                                                                                    _IsDraft,
                                                                                    Join(Batches.ToArray(), ",")).ToList

                End Using

            Else

                CoverSheets = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet)

            End If

            For Each CoverSheet In CoverSheets.ToList

                If CoverSheet.InvoiceSequenceNumber = 99 Then

                    CoverSheets.Remove(CoverSheet)

                End If

            Next

            For Each CoverSheet In CoverSheets

                If String.IsNullOrWhiteSpace(CoverSheet.RecordType) OrElse CoverSheet.RecordType = "S" Then

                    CoverSheet.SortOrder = 0

                Else

                    CoverSheet.SortOrder = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.InvoicePrinting.MediaTypeSortOrder), CoverSheet.RecordType)

                End If

            Next

            If _AccountReceivableInvoices IsNot Nothing AndAlso CoverSheets.Count > 0 Then

                OrderedCoverSheets = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CoverSheet)

                If _IsMultiCurrencyEnabled Then

                    If _AccountReceivableInvoices.TrueForAll(Function(Entity) String.IsNullOrWhiteSpace(Entity.CurrencyCode) = True) Then

                        _HasMultiCurrenciesInDataset = False
                        _CurrencyCode = String.Empty
                        _CurrencySymbol = String.Empty

                    ElseIf _AccountReceivableInvoices.TrueForAll(Function(Entity) Entity.CurrencyCode = _AccountReceivableInvoices(0).CurrencyCode) Then

                        _HasMultiCurrenciesInDataset = False
                        _CurrencyCode = _AccountReceivableInvoices(0).CurrencyCode
                        _CurrencySymbol = _AccountReceivableInvoices(0).CurrencySymbol

                    Else

                        _HasMultiCurrenciesInDataset = True
                        _CurrencyCode = "*MULTI*"
                        _CurrencySymbol = String.Empty

                    End If

                    If String.IsNullOrWhiteSpace(_CurrencySymbol) = False Then

                        XrLabelGrandTotal.TextFormatString = _CurrencySymbol & "{0:n2}"

                    Else

                        XrLabelGrandTotal.TextFormatString = "{0:c2}"

                    End If

                    If String.IsNullOrWhiteSpace(_CurrencyCode) = False Then

                        For Each AccountReceivableInvoice In _AccountReceivableInvoices.ToList

                            For Each CoverSheet In CoverSheets.Where(Function(Entity) Entity.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber AndAlso Entity.InvoiceSequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber).ToList

                                If String.IsNullOrWhiteSpace(AccountReceivableInvoice.CurrencyCode) = False Then

                                    CoverSheet.InvoiceAmount = AccountReceivableInvoice.CurrencyAmount.GetValueOrDefault(0)

                                End If

                                OrderedCoverSheets.Add(CoverSheet)

                            Next

                        Next

                    Else

                        For Each AccountReceivableInvoice In _AccountReceivableInvoices.ToList

                            OrderedCoverSheets.AddRange(CoverSheets.Where(Function(Entity) Entity.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber AndAlso Entity.InvoiceSequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber))

                        Next

                    End If

                Else

                    _HasMultiCurrenciesInDataset = False
                    _CurrencyCode = String.Empty
                    _CurrencySymbol = String.Empty

                    XrLabelGrandTotal.TextFormatString = "{0:c2}"

                    For Each AccountReceivableInvoice In _AccountReceivableInvoices.ToList

                        OrderedCoverSheets.AddRange(CoverSheets.Where(Function(Entity) Entity.InvoiceNumber = AccountReceivableInvoice.InvoiceNumber AndAlso Entity.InvoiceSequenceNumber = AccountReceivableInvoice.InvoiceSequenceNumber))

                    Next

                End If

            Else

                OrderedCoverSheets = CoverSheets

            End If

            If OrderedCoverSheets IsNot Nothing AndAlso OrderedCoverSheets.Count > 0 Then

                If String.IsNullOrWhiteSpace(OrderedCoverSheets(0).LocationCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        _HeaderLocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, OrderedCoverSheets(0).LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                        _FooterLocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, OrderedCoverSheets(0).LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.FooterPortrait)

                    End Using

                Else

                    _HeaderLocationLogo = Nothing
                    _FooterLocationLogo = Nothing

                End If

            End If

            Me.DataSource = OrderedCoverSheets

        End Sub
        Private Sub XrLabelInvoiceDateData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceDateData.BeforePrint

            XrLabelInvoiceDateData.Text = Now.ToShortDateString

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            'objects
            Dim CoverSheet As AdvantageFramework.InvoicePrinting.Classes.CoverSheet = Nothing

            Try

                CoverSheet = Me.GetCurrentRow

            Catch ex As Exception
                CoverSheet = Nothing
            End Try

            If CoverSheet IsNot Nothing Then

                If CoverSheet.ShowPageHeaderLogo Then

                    If String.IsNullOrWhiteSpace(CoverSheet.PageHeaderLogoPath) = False Then

                        If My.Computer.FileSystem.FileExists(CoverSheet.PageHeaderLogoPath) Then

                            XrPictureBoxHeaderLogo.ImageUrl = CoverSheet.PageHeaderLogoPath

                        End If

                    ElseIf _HeaderLocationLogo IsNot Nothing AndAlso _HeaderLocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_HeaderLocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub XrPictureBoxFooterLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxFooterLogo.BeforePrint

            'objects
            Dim CoverSheet As AdvantageFramework.InvoicePrinting.Classes.CoverSheet = Nothing

            Try

                CoverSheet = Me.GetCurrentRow

            Catch ex As Exception
                CoverSheet = Nothing
            End Try

            If CoverSheet IsNot Nothing Then

                If CoverSheet.ShowPageFooterLogo Then

                    If String.IsNullOrWhiteSpace(CoverSheet.PageFooterLogoPath) = False Then

                        If My.Computer.FileSystem.FileExists(CoverSheet.PageFooterLogoPath) Then

                            XrPictureBoxFooterLogo.ImageUrl = CoverSheet.PageFooterLogoPath

                        End If

                    ElseIf _FooterLocationLogo IsNot Nothing AndAlso _FooterLocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_FooterLocationLogo.Image)

                            XrPictureBoxFooterLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub XrLabelLocationHeaderInfo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelLocationHeaderInfo.BeforePrint

            'objects
            Dim CoverSheet As AdvantageFramework.InvoicePrinting.Classes.CoverSheet = Nothing

            Try

                CoverSheet = Me.GetCurrentRow

            Catch ex As Exception
                CoverSheet = Nothing
            End Try

            If CoverSheet IsNot Nothing Then

                XrLabelLocationHeaderInfo.Text = CoverSheet.PageHeaderComment

            End If

        End Sub
        Private Sub XrLabelLocationFooterInfo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelLocationFooterInfo.BeforePrint

            'objects
            Dim CoverSheet As AdvantageFramework.InvoicePrinting.Classes.CoverSheet = Nothing

            Try

                CoverSheet = Me.GetCurrentRow

            Catch ex As Exception
                CoverSheet = Nothing
            End Try

            If CoverSheet IsNot Nothing Then

                XrLabelLocationFooterInfo.Text = CoverSheet.PageFooterComment

            End If

        End Sub
        Private Sub XrLabelTitle_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelTitle.BeforePrint

            If String.IsNullOrWhiteSpace(_CoversheetTitle) Then

                XrLabelTitle.Text = "Invoice Cover Sheet"

            Else

                XrLabelTitle.Text = _CoversheetTitle

            End If

        End Sub
        Private Sub XrLabelAddress_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelAddress.BeforePrint

            'objects
            Dim ClientContactFullName As String = String.Empty

            If _ClientContact IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_ClientContact.MiddleInitial) Then

                    ClientContactFullName = _ClientContact.FirstName & " " & _ClientContact.LastName

                Else

                    ClientContactFullName = _ClientContact.FirstName & " " & _ClientContact.MiddleInitial & ". " & _ClientContact.LastName

                End If

                ClientContactFullName = ClientContactFullName.Trim

            End If

            If _CoversheetContactLocation = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AttnLine Then

                XrLabelAddress.Text &= System.Environment.NewLine & "Attn: " & ClientContactFullName

            ElseIf _CoversheetContactLocation = AdvantageFramework.InvoicePrinting.CoversheetContactLocations.AddressBlock Then

                XrLabelAddress.Text = ClientContactFullName & System.Environment.NewLine & XrLabelAddress.Text

            End If

        End Sub
        Private Sub XrLabelGrandTotalHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelGrandTotalHeader.BeforePrint

            If String.IsNullOrWhiteSpace(_CurrencyCode) = False Then

                XrLabelGrandTotalHeader.Text = "Total Amount (" & _CurrencyCode & ") :"

            Else

                XrLabelGrandTotalHeader.Text = "Total Amount:"

            End If

        End Sub

#End Region

    End Class

End Namespace
