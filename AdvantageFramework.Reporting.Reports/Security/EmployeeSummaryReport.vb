Namespace Security

    Public Class EmployeeSummaryReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserSettingsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(ByVal value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EmployeeSummary
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

        Private Sub EmployeeSummaryReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _UserSettingsList = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadBySettingCode(SecurityDbContext, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString).Include("User").ToList

                End Using

            Catch ex As Exception
                _UserSettingsList = Nothing
            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub XrCheckBoxWebvantageOnly_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrCheckBoxWebvantageOnly.BeforePrint

            'objects
            Dim IsWebvantageOnly As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.User.UserCode = Me.GetCurrentColumnValue("UserCode"))

                If UserSetting IsNot Nothing Then

                    IsWebvantageOnly = (UserSetting.StringValue = "Y")

                End If

            Catch ex As Exception
                IsWebvantageOnly = False
            End Try

            XrCheckBoxWebvantageOnly.Checked = IsWebvantageOnly

        End Sub

#End Region

#End Region

    End Class

End Namespace
