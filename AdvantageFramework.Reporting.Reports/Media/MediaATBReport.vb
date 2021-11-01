Namespace Media

    Public Class MediaATBReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _Date As String = String.Empty
        Private _ReportTitle As String = ""
        Private _DefaultLocation As AdvantageFramework.Database.Entities.Location = Nothing
        Private _LocationHeaderInfo As String = ""

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
        Public WriteOnly Property DefaultLocation As AdvantageFramework.Database.Entities.Location
            Set(value As AdvantageFramework.Database.Entities.Location)
                _DefaultLocation = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentRevision() As AdvantageFramework.Database.Entities.MediaATBRevision

            Try

                LoadCurrentRevision = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.MediaATBRevision)

            Catch ex As Exception
                LoadCurrentRevision = Nothing
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaATBReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

            If _DefaultLocation IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _LocationHeaderInfo = AdvantageFramework.Reporting.LoadLocationHeaderInfo(DbContext, _DefaultLocation.ID)

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeader_Main_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader_Main.BeforePrint

            'objects
            Dim PictureBoxHeight As Single = Nothing

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

        End Sub
        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            'objects
            Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim ProductView As AdvantageFramework.Database.Views.ProductView = Nothing
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

            MediaATBRevision = LoadCurrentRevision()

            If MediaATBRevision IsNot Nothing Then

                Label_Number.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True)
                Label_Revision.Text = AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, MediaATBRevision.ATBNumber)

                    If MediaATB IsNot Nothing Then

                        Try

                            ProductView = (From Entity In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                           Where Entity.ClientCode = MediaATB.ClientCode AndAlso
                                                 Entity.DivisionCode = MediaATB.DivisionCode AndAlso
                                                 Entity.ProductCode = MediaATB.ProductCode
                                           Select Entity).SingleOrDefault

                        Catch ex As Exception
                            ProductView = Nothing
                        End Try

                        If ProductView IsNot Nothing Then

                            Label_Client.Text = ProductView.ClientCode & " - " & ProductView.ClientName
                            Label_Division.Text = ProductView.DivisionCode & " - " & ProductView.DivisionName
                            Label_Product.Text = ProductView.ProductCode & " - " & ProductView.ProductDescription

                        End If

                        If MediaATB.IsInactive.GetValueOrDefault(0) = 1 Then

                            LabelHeader_Canceled.Text = "CANCELED"
                            LabelHeader_Canceled.Visible = True

                        Else

                            LabelHeader_Canceled.Text = ""
                            LabelHeader_Canceled.Visible = False

                        End If

                    End If

                    If MediaATBRevision.CampaignID.HasValue Then

                        Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, MediaATBRevision.CampaignID)

                        If Campaign IsNot Nothing Then

                            Label_Campaign.Text = Campaign.ID & " - " & Campaign.Code & " - " & Campaign.Name

                        End If

                    End If

                    If String.IsNullOrEmpty(MediaATBRevision.SalesClassCode) = False Then

                        SalesClass = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, MediaATBRevision.SalesClassCode)

                        If SalesClass IsNot Nothing Then

                            Label_SalesClass.Text = SalesClass.Code & " - " & SalesClass.Description

                        End If

                    End If

                    LabelBillingInformation_BillingMethod.Text = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(AdvantageFramework.Database.Entities.MediaATBBillingMethod), MediaATBRevision.BillingMethod.GetValueOrDefault(0)))

                End Using

            End If

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs)

            LabelPageHeader_Agency.Text = _AgencyName

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
