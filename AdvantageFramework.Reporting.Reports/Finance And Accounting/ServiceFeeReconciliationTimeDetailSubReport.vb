Namespace FinanceAndAccounting

    Public Class ServiceFeeReconciliationTimeDetailSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Date_Employee

#End Region

#Region " Properties "

        Public Property ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles
            Get
                ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationSummaryStyle
            End Get
            Set(ByVal value As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles)
                _ServiceFeeReconciliationSummaryStyle = value

                Try

                    LoadDetailGroupFields()

                Catch ex As Exception

                End Try

            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub LoadDetailGroupFields()

            If _ServiceFeeReconciliationSummaryStyle = AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles.Employee Then

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FeeDate)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FeeDate)

                TableRowHeader_Header.Cells.Remove(TableCellHeader_FeeTimeType)
                TableRowDetails_Details.Cells.Remove(TableCellDetails_FeeTimeType)

                Do Until TableCellHeader_Description.WidthF >= 500

                    TableCellHeader_Description.WidthF = 500
                    TableCellHeader_TotalHours.WidthF = 100
                    TableCellHeader_TotalAmount.WidthF = 100

                Loop

                Do Until TableCellDetails_Description.WidthF >= 500

                    TableCellDetails_Description.WidthF = 500
                    TableCellDetails_TotalHours.WidthF = 100
                    TableCellDetails_TotalAmount.WidthF = 100

                Loop

                LabelGroupFooterDetail_TotalAmount.WidthF = 100
                LabelGroupFooterDetail_TotalAmount.LocationF = New System.Drawing.PointF(600, 2)

                LabelGroupFooterDetail_TotalHours.WidthF = 100
                LabelGroupFooterDetail_TotalHours.LocationF = New System.Drawing.PointF(500, 2)

                LabelGroupFooterDetail_Totals.WidthF = 500
                LabelGroupFooterDetail_Totals.LocationF = New System.Drawing.PointF(0, 2)

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
