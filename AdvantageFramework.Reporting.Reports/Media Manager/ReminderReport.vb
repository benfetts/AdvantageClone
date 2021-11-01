Namespace MediaManager

    Public Class ReminderReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ReminderContact As AdvantageFramework.MediaManager.Classes.ReminderContact = Nothing
        Private _VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
        Private _LocationCode As String = Nothing
        Private _Date As String = Nothing
        Private _LetterContent As String = Nothing
        Private _LogoPath As String = Nothing
        Private _LocationHeader As String = Nothing
        Private _OrderLinesOnReport As IEnumerable(Of String) = Nothing
        Private _ActualPrintedOrderLinesOnReport As Generic.List(Of String) = Nothing
        Private _ActualPrintedPONumbersOnReport As Generic.List(Of Integer) = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ReminderContact As AdvantageFramework.MediaManager.Classes.ReminderContact
            Set(ByVal value As AdvantageFramework.MediaManager.Classes.ReminderContact)
                _ReminderContact = value
            End Set
        End Property
        Public WriteOnly Property VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)
            Set(ByVal value As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder))
                _VCCOrders = value
            End Set
        End Property
        Public WriteOnly Property LocationCode As String
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        'Public ReadOnly Property OrderLinesOnReport As Generic.List(Of String)
        '    Get
        '        OrderLinesOnReport = _OrderLinesOnReport
        '    End Get
        'End Property
        Public ReadOnly Property ActualPrintedOrderLinesOnReport As Generic.List(Of String)
            Get
                ActualPrintedOrderLinesOnReport = _ActualPrintedOrderLinesOnReport
            End Get
        End Property
        Public ReadOnly Property ActualPrintedPONumbersOnReport As Generic.List(Of Integer)
            Get
                ActualPrintedPONumbersOnReport = _ActualPrintedPONumbersOnReport
            End Get
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ReminderReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

            _Date = System.DateTime.Now.ToString("MMMM dd, yyyy")

            Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.VCCREM_LETTER.ToString)

                Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, _LocationCode)

            End Using

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _LocationHeader = AdvantageFramework.Reporting.LoadLocationHeaderInfo(DbContext, _LocationCode)

            End Using

            If Setting IsNot Nothing AndAlso Setting.Value IsNot Nothing Then

                _LetterContent = Setting.Value.ToString

            End If

            If Location IsNot Nothing Then

                _LogoPath = Location.LogoPath

            End If

        End Sub
        Private Sub ReminderReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaManagerGeneratedReportIDs As IEnumerable(Of Integer) = Nothing
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim PONumbersOnReport As IEnumerable(Of Integer) = Nothing

            VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaManagerGeneratedReportIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportSentInfo.Load(DbContext)
                                                  Where Entity.VendorCode = _ReminderContact.VendorCode AndAlso
                                                        Entity.VendorRepresentativeCode = _ReminderContact.VendorRepCode
                                                  Select Entity.MediaManagerGeneratedReportID).ToArray

                _OrderLinesOnReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.Load(DbContext)
                                       Where MediaManagerGeneratedReportIDs.Contains(Entity.MediaManagerGeneratedReportID)
                                       Select CStr(Entity.MediaManagerGeneratedReport.OrderNumber) & "|" & CStr(Entity.LineNumber)).ToList

                VCCOrders.AddRange(From VCCOrder In _VCCOrders
                                   Where VCCOrder.OrderNumber.HasValue AndAlso
                                         VCCOrder.LineNumber.HasValue AndAlso
                                        _OrderLinesOnReport.Contains(VCCOrder.OrderNumber & "|" & VCCOrder.LineNumber)
                                   Select VCCOrder)

                PONumbersOnReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedPOReport.Load(DbContext)
                                     Where Entity.PurchaseOrder.VendorCode = _ReminderContact.VendorCode AndAlso
                                           Entity.VendorContactCode = _ReminderContact.VendorRepCode
                                     Select Entity.PONumber).ToArray

                VCCOrders.AddRange(From VCCOrder In _VCCOrders
                                   Where VCCOrder.PONumber.HasValue AndAlso
                                         PONumbersOnReport.Contains(VCCOrder.PONumber.Value)
                                   Select VCCOrder)

                Me.DataSource = VCCOrders

                _ActualPrintedOrderLinesOnReport = (From VCCOrder In VCCOrders
                                                    Where VCCOrder.OrderNumber.HasValue AndAlso
                                                          VCCOrder.LineNumber.HasValue
                                                    Select CStr(VCCOrder.OrderNumber.Value) & "|" & CStr(VCCOrder.LineNumber.Value)).ToList

                _ActualPrintedPONumbersOnReport = (From VCCOrder In VCCOrders
                                                   Where VCCOrder.PONumber.HasValue
                                                   Select VCCOrder.PONumber.Value).ToList

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderVendorCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderVendorCode.BeforePrint

            LabelGroupHeaderVendorCode_Date.Text = _Date

        End Sub
        Private Sub LabelGroupHeaderVendorCode_LetterContent_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderVendorCode_LetterContent.BeforePrint

            LabelGroupHeaderVendorCode_LetterContent.Text = _LetterContent

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If Not String.IsNullOrWhiteSpace(_LogoPath) Then

                If My.Computer.FileSystem.FileExists(_LogoPath) Then

                    XrPictureBoxHeaderLogo.ImageUrl = _LogoPath

                    Cancel = False

                End If

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub GroupHeaderEveryPageSubreportVendorAddressSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderVendorCodeSubreportVendorAddressSubReport.BeforePrint

            Dim VendorCode As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing

            VendorCode = Me.GetCurrentColumnValue(AdvantageFramework.MediaManager.Classes.VCCOrder.Properties.VendorCode.ToString)

            Try

                Vendors = New Generic.List(Of AdvantageFramework.Database.Entities.Vendor)

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Vendors.Add(AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode))

                End Using

            Catch ex As Exception
                Vendors = Nothing
            End Try

            If Vendors IsNot Nothing AndAlso Vendors.Count > 0 Then

                DirectCast(GroupHeaderVendorCodeSubreportVendorAddressSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorAddressSubReport).OmitEmail = True
                DirectCast(GroupHeaderVendorCodeSubreportVendorAddressSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorAddressSubReport).OmitFax = True
                DirectCast(GroupHeaderVendorCodeSubreportVendorAddressSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.VendorAddressSubReport).OmitPhone = True

                GroupHeaderVendorCodeSubreportVendorAddressSubReport.ReportSource.DataSource = Vendors

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelPageHeader_LocationHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_LocationHeader.BeforePrint

            LabelPageHeader_LocationHeader.Text = _LocationHeader

        End Sub

#End Region

#End Region

    End Class

End Namespace
