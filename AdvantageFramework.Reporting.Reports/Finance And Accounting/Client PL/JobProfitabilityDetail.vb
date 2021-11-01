Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class JobProfitabilityDetail
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Dim GrossBillingDetail As Decimal = 0.0
        Dim GrossIncomeDetail As Decimal = 0.0
        Dim GrossBillingGroup As Decimal = 0.0
        Dim GrossIncomeGroup As Decimal = 0.0
        Dim GrossBillingJob As Decimal = 0.0
        Dim GrossIncomeJob As Decimal = 0.0
        Dim GrossBillingClient As Decimal = 0.0
        Dim GrossIncomeClient As Decimal = 0.0
        Dim GrossBillingReport As Decimal = 0.0
        Dim GrossIncomeReport As Decimal = 0.0
        Dim GrossBillingDetailMargin As Decimal = 0.0
        Dim GrossIncomeDetailMargin As Decimal = 0.0
        Dim GrossBillingGroupMargin As Decimal = 0.0
        Dim GrossIncomeGroupMargin As Decimal = 0.0
        Dim GrossBillingJobMargin As Decimal = 0.0
        Dim GrossIncomeJobMargin As Decimal = 0.0
        Dim GrossBillingClientMargin As Decimal = 0.0
        Dim GrossIncomeClientMargin As Decimal = 0.0
        Dim GrossBillingReportMargin As Decimal = 0.0
        Dim GrossIncomeReportMargin As Decimal = 0.0

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientPLDetail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

        'Detail Percentage Income
        Private Sub XrLabel_GrossIncomePercentage_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel_GrossIncomePercentage.PrintOnPage
            If GrossBillingDetail <> 0 Then
                Me.XrLabel_GrossIncomePercentage.Text = String.Format("{0:#,##0.00%}", (GrossIncomeDetail / GrossBillingDetail))
            ElseIf GrossBillingDetail = 0 Or GrossIncomeDetail = 0 Then
                Me.XrLabel_GrossIncomePercentage.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label14_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label14.PrintOnPage
            If Me.label14.Text <> "" Then
                GrossIncomeDetail = CDec(Me.label14.Text)
            End If
        End Sub
        Private Sub label12_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label12.PrintOnPage
            If Me.label12.Text <> "" Then
                GrossBillingDetail = CDec(Me.label12.Text)
                GrossBillingDetailMargin = CDec(Me.label12.Text)
            End If
        End Sub

        'SubTotal Percentage Income
        Private Sub XrLabel2_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel2.PrintOnPage
            If GrossBillingGroup <> 0 Then
                Me.XrLabel2.Text = String.Format("{0:#,##0.00%}", (GrossIncomeGroup / GrossBillingGroup))
            ElseIf GrossBillingGroup = 0 Or GrossIncomeGroup = 0 Then
                Me.XrLabel2.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label28_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label28.PrintOnPage
            If Me.label28.Text <> "" Then
                GrossIncomeGroup = CDec(Me.label28.Text)
            End If
        End Sub
        Private Sub label26_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label26.PrintOnPage
            If Me.label26.Text <> "" Then
                GrossBillingGroup = CDec(Me.label26.Text)
                GrossBillingGroupMargin = CDec(Me.label26.Text)
            End If
        End Sub

        'Job Percentage Income
        Private Sub XrLabel3_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel3.PrintOnPage
            If GrossBillingJob <> 0 Then
                Me.XrLabel3.Text = String.Format("{0:#,##0.00%}", (GrossIncomeJob / GrossBillingJob))
            ElseIf GrossBillingJob = 0 Or GrossIncomeJob = 0 Then
                Me.XrLabel3.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label40_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label40.PrintOnPage
            If Me.label40.Text <> "" Then
                GrossIncomeJob = CDec(Me.label40.Text)
            End If
        End Sub
        Private Sub label34_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label34.PrintOnPage
            If Me.label34.Text <> "" Then
                GrossBillingJob = CDec(Me.label34.Text)
                GrossBillingJobMargin = CDec(Me.label34.Text)
            End If
        End Sub

        'Client Percentage Income
        Private Sub XrLabel4_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel4.PrintOnPage
            If GrossBillingClient <> 0 Then
                Me.XrLabel4.Text = String.Format("{0:#,##0.00%}", (GrossIncomeClient / GrossBillingClient))
            ElseIf GrossBillingClient = 0 Or GrossIncomeClient = 0 Then
                Me.XrLabel4.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label43_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label43.PrintOnPage
            If Me.label43.Text <> "" Then
                GrossIncomeClient = CDec(Me.label43.Text)
            End If
        End Sub
        Private Sub label49_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label49.PrintOnPage
            If Me.label49.Text <> "" Then
                GrossBillingClient = CDec(Me.label49.Text)
                GrossBillingClientMargin = CDec(Me.label49.Text)
            End If
        End Sub

        'Report Percentage Income
        Private Sub XrLabel5_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel5.PrintOnPage
            If GrossBillingReport <> 0 Then
                Me.XrLabel5.Text = String.Format("{0:#,##0.00%}", (GrossIncomeReport / GrossBillingReport))
            ElseIf GrossBillingReport = 0 Or GrossIncomeReport = 0 Then
                Me.XrLabel5.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label56_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label56.PrintOnPage
            If Me.label56.Text <> "" Then
                GrossIncomeReport = CDec(Me.label56.Text)
            End If
        End Sub
        Private Sub label50_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label50.PrintOnPage
            If Me.label50.Text <> "" Then
                GrossBillingReport = CDec(Me.label50.Text)
                GrossBillingReportMargin = CDec(Me.label50.Text)
            End If
        End Sub


        'Detail Percentage Margin
        Private Sub XrLabel1_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel1.PrintOnPage
            If GrossBillingDetailMargin <> 0 Then
                Me.XrLabel1.Text = String.Format("{0:#,##0.00%}", (GrossIncomeDetailMargin / GrossBillingDetailMargin))
            ElseIf GrossBillingDetailMargin = 0 Or GrossIncomeDetailMargin = 0 Then
                Me.XrLabel1.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label18_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label18.PrintOnPage
            If Me.label18.Text <> "" Then
                GrossIncomeDetailMargin = CDec(Me.label18.Text)
            End If
        End Sub

        'SubTotal Percentage Margin
        Private Sub XrLabel6_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel6.PrintOnPage
            If GrossBillingGroupMargin <> 0 Then
                Me.XrLabel6.Text = String.Format("{0:#,##0.00%}", (GrossIncomeGroupMargin / GrossBillingGroupMargin))
            ElseIf GrossBillingGroupMargin = 0 Or GrossIncomeGroupMargin = 0 Then
                Me.XrLabel6.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label32_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label32.PrintOnPage
            If Me.label32.Text <> "" Then
                GrossIncomeGroupMargin = CDec(Me.label32.Text)
            End If
        End Sub

        'Job Percentage Margin
        Private Sub XrLabel7_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel7.PrintOnPage
            If GrossBillingJobMargin <> 0 Then
                Me.XrLabel7.Text = String.Format("{0:#,##0.00%}", (GrossIncomeJobMargin / GrossBillingJobMargin))
            ElseIf GrossBillingJobMargin = 0 Or GrossIncomeJobMargin = 0 Then
                Me.XrLabel7.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label36_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label36.PrintOnPage
            If Me.label36.Text <> "" Then
                GrossIncomeJobMargin = CDec(Me.label36.Text)
            End If
        End Sub

        'Client Percentage Margin
        Private Sub XrLabel8_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel8.PrintOnPage
            If GrossBillingClientMargin <> 0 Then
                Me.XrLabel8.Text = String.Format("{0:#,##0.00%}", (GrossIncomeClientMargin / GrossBillingClientMargin))
            ElseIf GrossBillingClientMargin = 0 Or GrossIncomeClientMargin = 0 Then
                Me.XrLabel8.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label47_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label47.PrintOnPage
            If Me.label47.Text <> "" Then
                GrossIncomeClientMargin = CDec(Me.label47.Text)
            End If
        End Sub

        'Report Percentage Margin
        Private Sub XrLabel9_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles XrLabel9.PrintOnPage
            If GrossBillingReportMargin <> 0 Then
                Me.XrLabel9.Text = String.Format("{0:#,##0.00%}", (GrossIncomeReportMargin / GrossBillingReportMargin))
            ElseIf GrossBillingReportMargin = 0 Or GrossIncomeReportMargin = 0 Then
                Me.XrLabel9.Text = String.Format("{0:#,##0.00%}", 0)
            End If
        End Sub
        Private Sub label52_PrintOnPage(sender As Object, e As PrintOnPageEventArgs) Handles label52.PrintOnPage
            If Me.label52.Text <> "" Then
                GrossIncomeReportMargin = CDec(Me.label52.Text)
            End If
        End Sub

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace