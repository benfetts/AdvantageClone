Namespace Web.Presentation.Controls

    Public Class EmployeeInformationTemplateMenu
        Implements System.Web.UI.ITemplate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

            'Dim DataString As String = ""
            'Try

            '    Dim sb As New System.Text.StringBuilder
            '    Dim AlertCount As Integer = 0
            '    Dim HighPriorityAlertCount As Integer = 0
            '    Dim AssignmentCount As Integer = 0
            '    Dim a As New cAlerts()
            '    Dim dt As New DataTable
            '    dt = a.GetAlertSummary(HttpContext.Current.Session("EmpCode"))
            '    If Not dt Is Nothing Then
            '        If dt.Rows.Count > 0 Then
            '            If Not IsDBNull(dt.Rows(0)("TOTAL_ALERTS")) = True Then
            '                AlertCount = CType(dt.Rows(0)("TOTAL_ALERTS"), Integer)
            '            End If
            '            If Not IsDBNull(dt.Rows(0)("HIGH_PRIORITY_ALERTS")) = True Then
            '                HighPriorityAlertCount = CType(dt.Rows(0)("HIGH_PRIORITY_ALERTS"), Integer)
            '            End If
            '            If Not IsDBNull(dt.Rows(0)("TOTAL_ASSIGNMENTS")) = True Then
            '                AssignmentCount = CType(dt.Rows(0)("TOTAL_ASSIGNMENTS"), Integer)
            '            End If
            '        End If
            '    End If

            '    With sb
            '        .Append("<table width=""100%"" border=""0"" cellspacing=""2"" cellpadding=""0"" align=""left"">")
            '        .Append("    <tr>")
            '        .Append("        <td align=""right"">")
            '        .Append("            Server:&nbsp;")
            '        .Append(HttpContext.Current.Session("DBServerName").ToString())
            '        .Append("        </td>")
            '        .Append("    </tr>")
            '        .Append("    <tr>")
            '        .Append("        <td align=""right"">")
            '        .Append("            Database:&nbsp;")
            '        .Append(HttpContext.Current.Session("DBName").ToString())
            '        .Append("        </td>")
            '        .Append("    </tr>")

            '        If AlertCount > 0 Then
            '            .Append("    <tr>")
            '            .Append("        <td align=""right"">")
            '            .Append("            New Alerts:&nbsp;")
            '            .Append(AlertCount)
            '            .Append("        </td>")
            '            .Append("    </tr>")
            '        End If

            '        If HighPriorityAlertCount > 0 Then
            '            .Append("    <tr>")
            '            .Append("        <td align=""right"">")
            '            .Append("            High Priority Alerts:&nbsp;")
            '            .Append(HighPriorityAlertCount)
            '            .Append("        </td>")
            '            .Append("    </tr>")
            '        End If

            '        If AssignmentCount > 0 Then
            '            .Append("    <tr>")
            '            .Append("        <td align=""right"">")
            '            .Append("           Assignments:&nbsp;")
            '            .Append(AssignmentCount)
            '            .Append("        </td>")
            '            .Append("    </tr>")
            '        End If

            '        .Append("</table>")
            '    End With
            '    DataString = sb.ToString().Trim()
            'Catch ex As Exception
            '    DataString = ""
            'End Try
            'Dim lit As New Literal
            'If DataString.Trim() = "" Then
            '    lit.Text = "No weather data available"
            'Else
            '    lit.Text = DataString
            'End If
            'container.Controls.Add(lit)

        End Sub

#End Region

    End Class

End Namespace