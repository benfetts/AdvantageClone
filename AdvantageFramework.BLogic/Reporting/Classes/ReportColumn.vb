Namespace Reporting.Classes

    Public Class ReportColumn

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Index As Integer
        Public Property ColumnName As String
        Public Property ReportColumnType As ReportColumnType
        Public ReadOnly Property HasDefinedColumn As Boolean
            Get

                If ReportColumnType = ReportColumnType.JobDetailItem Then

                    Select Case Me.ColumnName

                        Case AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.CurrentHours.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.CurrentHoursAmount.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.CurrentIncomeOnlyCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.CurrentVendorCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.CurrentTotal.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorHours.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorHoursAmount.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorIncomeOnlyCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorVendorCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorTotal.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.TotalToDateHours.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.TotalToDateHoursAmount.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.TotalToDateIncomeOnlyCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.TotalToDateVendorCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.TotalToDate.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorYearHours.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorYearHoursAmount.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorYearIncomeOnlyCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorYearVendorCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.PriorYearTotal.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.EstimateIncomeOnlyCharges.ToString,
                                AdvantageFramework.Reporting.Database.Classes.JobDetailItemReport.Properties.BilledIncomeOnlyCharges.ToString

                            HasDefinedColumn = False

                        Case Else

                            HasDefinedColumn = True

                    End Select

                Else

                    HasDefinedColumn = True

                End If

            End Get
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace

