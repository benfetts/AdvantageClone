Namespace Media

    Public Class MediaATBFormReport
        Inherits DevExpress.XtraReports.UI.XtraReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _ReportTitle As String = ""
        Private _SignatureLines As Integer = 0
        Private _DefaultLocation As AdvantageFramework.Database.Entities.Location = Nothing
        Private _LocationHeaderInfo As String = ""
        Private _LocationFooterInfo As String = ""

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
        Public WriteOnly Property ReportTitle As String
            Set(value As String)
                _ReportTitle = value
            End Set
        End Property
        Public WriteOnly Property SignatureLines As Integer
            Set(value As Integer)

                If value < 0 Then

                    _SignatureLines = 0

                Else

                    _SignatureLines = value

                End If

            End Set
        End Property
        Public WriteOnly Property DefaultLocation As AdvantageFramework.Database.Entities.Location
            Set(value As AdvantageFramework.Database.Entities.Location)
                _DefaultLocation = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentRevision() As AdvantageFramework.Database.Entities.MediaATBRevision

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            Try

                MediaATBRevision = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.MediaATBRevision)

            Catch ex As Exception
                MediaATBRevision = Nothing
            Finally
                LoadCurrentRevision = MediaATBRevision
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaATBFormReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim FileName As String = Nothing

            Try

                MediaATBRevision = DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Database.Entities.MediaATBRevision)).SingleOrDefault

            Catch ex As Exception
                MediaATBRevision = Nothing
            End Try

            If MediaATBRevision IsNot Nothing Then

                FileName = "ATB_" & AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True, False)

                FileName = FileName & "_REV_" & AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True, False)

                Me.ExportOptions.PrintPreview.DefaultFileName = FileName

            End If

            DetailReportSignatureLines.ReportPrintOptions.DetailCountOnEmptyDataSource = _SignatureLines

            If _SignatureLines = 0 Then

                DetailReportSignatureLines.ReportPrintOptions.PrintOnEmptyDataSource = False

            End If

            DetailReportSignatureLines.DataSource = Nothing

            If _DefaultLocation IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _LocationHeaderInfo = AdvantageFramework.Reporting.LoadLocationHeaderInfo(DbContext, _DefaultLocation.ID)
                    _LocationFooterInfo = AdvantageFramework.Reporting.LoadLocationFooterInfo(DbContext, _DefaultLocation.ID)

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupFooter_PageInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter_PageInfo.BeforePrint

            If String.IsNullOrWhiteSpace(_LocationFooterInfo) = False Then

                XrLabelLocationFooterInfo.Text = _LocationFooterInfo

            End If

            If _DefaultLocation IsNot Nothing Then

                Try

                    If String.IsNullOrEmpty(_DefaultLocation.FooterLogoPath) = False Then

                        XrPictureBoxFooterLogo.Image = System.Drawing.Image.FromFile(_DefaultLocation.FooterLogoPath)

                    End If

                Catch ex As Exception
                    XrPictureBoxFooterLogo.Image = Nothing
                End Try

            End If

        End Sub
        Private Sub GroupHeader_Main_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader_Main.BeforePrint

            'objects
            Dim PictureBoxHeight As Single = Nothing
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing

            If String.IsNullOrEmpty(_ReportTitle) = False Then

                LabelPageHeader_Title.Text = _ReportTitle

            End If

            If String.IsNullOrWhiteSpace(_LocationHeaderInfo) = False Then

                XrLabelLocationHeaderInfo.Text = _LocationHeaderInfo

            End If

            If _DefaultLocation IsNot Nothing Then

                Try

                    If String.IsNullOrEmpty(_DefaultLocation.LogoLocation) = False Then

                        PictureBoxHeader_Logo.Image = System.Drawing.Image.FromFile(_DefaultLocation.LogoPath)

                    End If

                Catch ex As Exception
                    PictureBoxHeader_Logo.Image = Nothing
                End Try

            Else

                PictureBoxHeight = PictureBoxHeader_Logo.HeightF
                PictureBoxHeader_Logo.SizeF = New System.Drawing.SizeF(PictureBoxHeader_Logo.WidthF, 1)
                PictureBoxHeader_Logo.Visible = False

                For Each XRControl In GroupHeader_Main.Controls.OfType(Of DevExpress.XtraReports.UI.XRControl)()

                    If XRControl IsNot PictureBoxHeader_Logo Then

                        XRControl.LocationF = New System.Drawing.PointF(XRControl.LocationF.X, (XRControl.LocationF.Y - PictureBoxHeight))

                    End If

                Next

                GroupHeader_Main.HeightF = GroupHeader_Main.HeightF - PictureBoxHeight

            End If

            MediaATBRevision = LoadCurrentRevision()

            If MediaATBRevision IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, MediaATBRevision.ATBNumber)

                    If MediaATB.IsInactive.GetValueOrDefault(0) = 1 Then

                        LabelHeader_Canceled.Visible = True
                        LabelHeader_Canceled.Text = "CANCELED"

                    Else

                        LabelHeader_Canceled.Visible = False
                        LabelHeader_Canceled.Text = ""

                    End If

                End Using

            End If

        End Sub
        'Private Sub PictureBoxHeader_Logo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBoxHeader_Logo.BeforePrint

        '    'objects
        '    Dim LogoSize As System.Drawing.SizeF = Nothing
        '    Dim LogoImage As System.Drawing.Image = Nothing

        '    LogoSize = New System.Drawing.SizeF(PictureBoxHeader_Logo.SizeF.Width, 1)

        '    If _DefaultLocation IsNot Nothing Then

        '        Try

        '            If String.IsNullOrEmpty(_DefaultLocation.LogoLocation) = False Then

        '                LogoSize.Height = 136
        '                LogoImage = System.Drawing.Image.FromFile(_DefaultLocation.LogoPath)

        '            End If

        '        Catch ex As Exception
        '            LogoSize.Height = 1
        '            LogoImage = Nothing
        '        End Try

        '    Else

        '        PictureBoxHeader_Logo.Visible = False

        '    End If

        '    PictureBoxHeader_Logo.SizeF = LogoSize
        '    PictureBoxHeader_Logo.Image = LogoImage

        'End Sub
        Private Sub Label_ATBNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ATBNumber.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            MediaATBRevision = LoadCurrentRevision()

            If MediaATBRevision IsNot Nothing Then

                Label_ATBNumber.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True) & " - " & AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True)

            End If

        End Sub
        Private Sub Label_ATB_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ATB.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            MediaATBRevision = LoadCurrentRevision()

            If MediaATBRevision IsNot Nothing Then

                Label_ATB.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True) & " - " & MediaATBRevision.Description

            End If

        End Sub
        Private Sub Label_Revision_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Revision.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            MediaATBRevision = LoadCurrentRevision()

            If MediaATBRevision IsNot Nothing Then

                Label_Revision.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True)

            End If

        End Sub
        Private Sub Label_ProductBillingInformation_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ProductBillingInformation.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim BillingAddress As Generic.List(Of String) = Nothing
            Dim CityStateZip As String = Nothing

            MediaATBRevision = LoadCurrentRevision()

            BillingAddress = New Generic.List(Of String)

            Try

                If MediaATBRevision IsNot Nothing Then

                    If MediaATBRevision.MediaATB IsNot Nothing Then

                        Client = MediaATBRevision.MediaATB.Client
                        Product = MediaATBRevision.MediaATB.Product

                        If Client IsNot Nothing Then

                            BillingAddress.Add(Client.Name)

                            If MediaATBRevision.MediaATB.Product IsNot Nothing Then

                                If String.IsNullOrEmpty(Product.AttentionTo) = False Then

                                    BillingAddress.Add(Product.AttentionTo)

                                End If

                            End If

                            If String.IsNullOrEmpty(Client.BillingAddress) = False Then

                                BillingAddress.Add(Client.BillingAddress)

                            End If

                            If String.IsNullOrEmpty(Client.BillingAddress2) = False Then

                                BillingAddress.Add(Client.BillingAddress2)

                            End If

                            If String.IsNullOrEmpty(Client.BillingCity) = False Then

                                CityStateZip = Client.BillingCity & ", "

                            End If

                            If String.IsNullOrEmpty(Client.BillingState) = False Then

                                CityStateZip &= Client.BillingState & " "

                            End If

                            If String.IsNullOrEmpty(Client.BillingZip) = False Then

                                CityStateZip &= Client.BillingZip

                            End If

                            If String.IsNullOrEmpty(CityStateZip) = False Then

                                BillingAddress.Add(CityStateZip)

                            End If

                            If String.IsNullOrEmpty(Client.Country) = False Then

                                BillingAddress.Add(Client.Country)

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                BillingAddress = Nothing
            Finally

                If BillingAddress IsNot Nothing AndAlso BillingAddress.Count > 0 Then

                    Label_ProductBillingInformation.Lines = BillingAddress.ToArray

                Else

                    Label_ProductBillingInformation.Text = ""

                End If

            End Try

        End Sub
        Private Sub DetailReportSignatureLines_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportSignatureLines.BeforePrint

            If DetailReportSignatureLines.ReportPrintOptions.PrintOnEmptyDataSource = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub SubReport_RevisionDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles SubReport_RevisionDetails.BeforePrint

            'objects
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim MediaATBRevisionDetailList As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail) = Nothing

            Try

                MediaATBRevision = LoadCurrentRevision()

                If MediaATBRevision IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        MediaATBRevisionDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevisionDetail)

                        MediaATBRevisionDetailList.AddRange(AdvantageFramework.Database.Procedures.MediaATBRevisionDetail.LoadByRevisionID(DbContext, MediaATBRevision.RevisionID).Include("Vendor").ToList)

                        DirectCast(SubReport_RevisionDetails.ReportSource, AdvantageFramework.Reporting.Reports.Media.MediaATBDetailsSubReport).MediaATBRevision = MediaATBRevision

                        SubReport_RevisionDetails.ReportSource.DataSource = MediaATBRevisionDetailList

                    End Using

                End If

            Catch ex As Exception
                SubReport_RevisionDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
