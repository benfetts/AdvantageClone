Namespace AdvancedReportWriterReports

    Public Class BillingInvoiceDetail
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _BillingInvoiceDetails As Generic.List(Of Database.Classes.BillingInvoiceDetail) = Nothing
        Private _CurrentDataLine As Database.Classes.BillingInvoiceDetail = Nothing

        Public Property ParameterDictionary As Dictionary(Of String, Object)
        Public Property Session As AdvantageFramework.Security.Session
#End Region

#Region " Properties "

        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Campaign
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property



#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "
        Private Sub BillingInvoiceDetail_DataSourceDemanded(sender As Object, e As EventArgs) Handles MyBase.DataSourceDemanded

            Dim AP_ID As Integer
            Dim Worksheets As List(Of Integer)
            Dim Invoices As List(Of Integer)
            Dim LocationName As String = ""
            Dim EntryStart As Date
            Dim EntryEnd As Date
            Dim InvoiceStart As Date
            Dim InvoiceEnd As Date
            Dim Clients As List(Of String)
            Dim Divisions As List(Of String)
            Dim Products As List(Of String)
            Dim Markets As List(Of String)
            Dim Vendors As List(Of String)


            Worksheets = New List(Of Integer)
            Invoices = New List(Of Integer)

            Clients = New List(Of String)
            Divisions = New List(Of String)
            Products = New List(Of String)
            Vendors = New List(Of String)
            Markets = New List(Of String)

            Try
                If ParameterDictionary.ContainsKey("AP_ID") Then
                    AP_ID = ParameterDictionary("AP_ID")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("Worksheets") Then
                    Worksheets = ParameterDictionary("Worksheets")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("Invoices") Then
                    Invoices = ParameterDictionary("Invoices")
                End If
            Catch ex As Exception

            End Try


            Try
                If ParameterDictionary.ContainsKey("LocationName") Then
                    LocationName = ParameterDictionary("LocationName")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("EntryStart") Then
                    EntryStart = ParameterDictionary("EntryStart")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("EntryEnd") Then
                    EntryEnd = ParameterDictionary("EntryEnd")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("InvoiceStart") Then
                    InvoiceStart = ParameterDictionary("InvoiceStart")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("InvoiceEnd") Then
                    InvoiceEnd = ParameterDictionary("InvoiceEnd")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("Clients") Then
                    Clients = ParameterDictionary("Clients")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("Divisions") Then
                    Divisions = ParameterDictionary("Divisions")
                End If
            Catch ex As Exception

            End Try


            Try
                If ParameterDictionary.ContainsKey("Products") Then
                    Products = ParameterDictionary("Products")
                End If
            Catch ex As Exception

            End Try

            Try
                If ParameterDictionary.ContainsKey("Markets") Then
                    Markets = ParameterDictionary("Markets")
                End If
            Catch ex As Exception

            End Try


            Try
                If ParameterDictionary.ContainsKey("Vendors") Then
                    Vendors = ParameterDictionary("Vendors")
                End If
            Catch ex As Exception

            End Try

            Try

                Using DbContext = New Database.DbContext(Session.ConnectionString, Session.UserCode)
                    _BillingInvoiceDetails = Reporting.Database.Procedures.BillingInvoice _
                        .LoadBillingInvoiceDetail(DbContext, AP_ID, Worksheets, Invoices, LocationName, EntryStart, EntryEnd, InvoiceStart, InvoiceEnd, Clients, Divisions, Products, Markets, Vendors).ToList()
                End Using

                Me.DataSource = _BillingInvoiceDetails

                If (_BillingInvoiceDetails IsNot Nothing) Then
                    If (_BillingInvoiceDetails.Count > 0) Then
                        _CurrentDataLine = _BillingInvoiceDetails.FirstOrDefault
                    Else
                        _CurrentDataLine = New Database.Classes.BillingInvoiceDetail
                    End If
                Else
                    _CurrentDataLine = New Database.Classes.BillingInvoiceDetail
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub BillingInvoiceDetail_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles MyBase.DataSourceRowChanged

        End Sub
#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
