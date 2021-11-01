Namespace Security

    Public Class GroupPermissionSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub XrLabelIsBlockedData_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelIsBlockedData.BeforePrint

            If XrLabelIsBlockedData.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelIsBlockedData.Text = "Y"

            Else

                XrLabelIsBlockedData.Text = "N"

            End If

        End Sub
        Private Sub XrLabelCanPrintData_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCanPrintData.BeforePrint

            If Convert.ToBoolean(Me.GetCurrentColumnValue("ModuleHasCustomPermission")) AndAlso XrLabelCanPrintData.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelCanPrintData.Text = "Y"

            Else

                XrLabelCanPrintData.Text = ""

            End If

        End Sub
        Private Sub XrLabelCanUpdateData_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCanUpdateData.BeforePrint

            If Convert.ToBoolean(Me.GetCurrentColumnValue("ModuleHasCustomPermission")) AndAlso XrLabelCanUpdateData.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelCanUpdateData.Text = "Y"

            Else

                XrLabelCanUpdateData.Text = ""

            End If

        End Sub
        Private Sub XrLabelCanAddData_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCanAddData.BeforePrint

            If Convert.ToBoolean(Me.GetCurrentColumnValue("ModuleHasCustomPermission")) AndAlso XrLabelCanAddData.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelCanAddData.Text = "Y"

            Else

                XrLabelCanAddData.Text = ""

            End If

        End Sub
        Private Sub XrLabelCustom1Data_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCustom1Data.BeforePrint

            If Convert.ToBoolean(Me.GetCurrentColumnValue("ModuleHasCustomPermission")) AndAlso XrLabelCustom1Data.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelCustom1Data.Text = "Y"

            Else

                XrLabelCustom1Data.Text = ""

            End If

        End Sub
        Private Sub XrLabelCustom2Data_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCustom2Data.BeforePrint

            If Convert.ToBoolean(Me.GetCurrentColumnValue("ModuleHasCustomPermission")) AndAlso XrLabelCustom2Data.Text.ToUpper = Boolean.TrueString.ToUpper Then

                XrLabelCustom2Data.Text = "Y"

            Else

                XrLabelCustom2Data.Text = ""

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
