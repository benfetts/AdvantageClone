Option Strict On

Namespace Media

    Public Class BroadcastInvoiceSummaryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ParameterDictionary As Dictionary(Of String, Object)
            Set(ByVal value As Dictionary(Of String, Object))
                _ParameterDictionary = value
            End Set
        End Property
        Public WriteOnly Property LocationEntity As AdvantageFramework.Database.Entities.Location
            Set(ByVal value As AdvantageFramework.Database.Entities.Location)
                _LocationEntity = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastInvoiceSummaryReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim StartPeriod As String = Nothing
            Dim EndPeriod As String = Nothing

            StartPeriod = CStr(_ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.StartPeriod.ToString))
            EndPeriod = CStr(_ParameterDictionary(AdvantageFramework.Reporting.BroadcastInvoiceSummaryParameters.EndPeriod.ToString))

            If String.IsNullOrWhiteSpace(StartPeriod) = False AndAlso String.IsNullOrWhiteSpace(EndPeriod) = False AndAlso StartPeriod.Length = 6 AndAlso EndPeriod.Length = 6 Then

                Me.LabelPageHeader_DateRange.Text = StartPeriod.Substring(4, 2) & "/" & StartPeriod.Substring(0, 4) & " - " & EndPeriod.Substring(4, 2) & "/" & EndPeriod.Substring(0, 4)

            Else

                Me.LabelPageHeader_DateRange.Text = StartPeriod & Space(1) & EndPeriod

            End If

        End Sub
        Private Sub BroadcastInvoiceSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.DataSource = AdvantageFramework.Reporting.LoadBroadcastInvoiceSummary(DbContext, _ParameterDictionary).OrderBy(Function(BIS) BIS.CDP).ThenBy(Function(BIS) BIS.VendorCode).ToList

                End Using

            Else

                Me.DataSource = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.BroadcastInvoiceSummary)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub

#End Region

#End Region

    End Class

End Namespace
