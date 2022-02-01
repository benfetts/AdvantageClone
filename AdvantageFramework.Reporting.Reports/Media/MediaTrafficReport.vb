Namespace Media

    Public Class MediaTrafficReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _MediaTrafficVendorID As Integer = 0
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _Guidelines As String = Nothing
        Private _HasBookends As Boolean = False
        Private _IsLogoSet As Boolean = False

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property MediaTrafficVendorID As Integer
            Set(ByVal value As Integer)
                _MediaTrafficVendorID = value
            End Set
        End Property
        Public WriteOnly Property LocationEntity As AdvantageFramework.Database.Entities.Location
            Set(ByVal value As AdvantageFramework.Database.Entities.Location)
                _LocationEntity = value
            End Set
        End Property
        Public WriteOnly Property Guidelines As String
            Set(ByVal value As String)
                _Guidelines = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            Dim MediaTrafficInstructionReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport) = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaTrafficInstructionReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport)(String.Format("exec advsp_media_traffic_instruction_report {0}, '{1}'", _MediaTrafficVendorID, _Session.UserCode)).ToList

                    _IsLogoSet = AdvantageFramework.Reporting.Reports.SetReportHeaderLogoLandscape(DbContext, _LocationEntity, Me.XrPictureBoxHeaderLogo)

                End Using

            Else

                MediaTrafficInstructionReports = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport)

            End If

            If (From Entity In MediaTrafficInstructionReports
                Where String.IsNullOrWhiteSpace(Entity.DetailBookendName) = False
                Select Entity).Any Then

                _HasBookends = True

            End If

            Me.DataSource = MediaTrafficInstructionReports

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelPageHeader_Title_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Title.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport.Properties.RevisionNumber.ToString) > 0 Then

                LabelPageHeader_Title.Text = "REVISED TRAFFIC INSTRUCTION"

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Date.BeforePrint

            LabelGroupHeaderStation_Date.Text = Now.ToString("M/d/yyyy h:mm tt")

        End Sub
        Private Sub LabelCableNetworkGroup_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelCableNetworkGroup.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport.Properties.CableNetworkGroup.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelCableNetworkGroup_Label_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelCableNetworkGroup_Label.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaTrafficInstructionReport.Properties.CableNetworkGroup.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            If _IsLogoSet = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelPageHeader_Bookend_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Bookend.BeforePrint

            If _HasBookends = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelPageHeader_Pos_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Pos.BeforePrint

            If _HasBookends = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Location_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Location.BeforePrint

            If _HasBookends = False Then

                LabelDetail_Location.WidthF = 423

            End If

        End Sub
        Private Sub ReportFooterRichText_Guidelines_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooterRichText_Guidelines.BeforePrint

            Dim Font As Drawing.Font = New System.Drawing.Font("Arial", 8.0!)

            If String.IsNullOrWhiteSpace(_Guidelines) Then

                e.Cancel = True

            Else

                ReportFooterRichText_Guidelines.Html = _Guidelines
                ReportFooterRichText_Guidelines.Font = Font

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
