Namespace Templates

    Public Class AdvantageAPI

#Region " Enum "

        Public Enum ApiMethods
            CheckForValidSettings
            'CopyJob
            'CopyJobComponent
            'CreateJob
            'CreateJobComponent
            'CreateJobComponentFromExistingJob
            LoadAccountExecutives
            LoadAlertGroups
            LoadAPInvoices
            LoadAPInvoiceDetails
            LoadARInvoices
            LoadBanks
            LoadBillingCoops
            LoadCampaigns
            'LoadClientDiscounts  /* not working ? */
            LoadClients
            LoadClientTypes
            LoadContactClients
            LoadContactTypes
            LoadDepartmentTeams
            LoadDivisions
            LoadEmployees
            LoadEmployeeTimeRecords
            LoadFunctions
            LoadIndirectCategories
            LoadJob
            LoadJobs
            LoadJobComponent
            LoadJobComponents
            LoadJobLogUserDefinedValues
            LoadJobTypes
            LoadMarkets
            LoadMediaOrders
            LoadMediaOrderStatuses
            LoadProducts
            LoadSalesClasses
            LoadScheduleStatuses
            LoadTasks
            LoadUsers
            LoadVendorVCCStatuses
            LoadVendorCategories
            LoadVendorContacts
            LoadVendorRepresentatives
            LoadVendors
            LoadVendorterms

            'SaveEmployeeJobTime
            'SaveEmployeeNonProductionTime
            'SaveTask
            'AddCampaign
            'AddClientDivisionProduct
            'UpdateClientDivisionProduct
            'UpdateProjectScheduleDueDate
            'UpdateProjectScheduleStatus
        End Enum

#End Region

#Region " Methods "

        Private Function GetDocumentationMethods() As Reflection.MethodInfo()

            Return GetType(APIService).GetMethods().Where(Function(m) [Enum].GetNames(GetType(ApiMethods)).Contains(m.Name)).OrderBy(Function(m) m.Name).ToArray

        End Function
        Private Function GetFriendlyTypeName(ByVal Type As System.Type) As String

            If Type = GetType(Int32) OrElse Type = GetType(Integer) OrElse Type = GetType(Int32?) OrElse Type = GetType(Integer?) Then

                Return "Integer"

            ElseIf Type = GetType(Int16) OrElse Type = GetType(Short) OrElse Type = GetType(Int16?) OrElse Type = GetType(Short?) Then

                Return "Short"

            Else

                Return Type.Name.ToString

            End If

        End Function

#End Region

#Region " Event Handlers "

        Private Sub AdvantageAPI_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            'Dim Bitmap As Drawing.Bitmap = New Drawing.Bitmap(My.Application.Info.DirectoryPath & "\Images\APIClassDiagramLoads.png")
            'Dim Height As Integer = Nothing

            'Try

            'If Bitmap.Width > PictureBoxPage2_PublicClassLayout.SizeF.Width Then

            '    Height = CInt((Bitmap.Height * PictureBoxPage2_PublicClassLayout.SizeF.Width) / Bitmap.Width)
            '    PictureBoxPage2_PublicClassLayout.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze

            'Else

            '    Height = Bitmap.Height
            '    PictureBoxPage2_PublicClassLayout.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Normal

            'End If

            'PictureBoxPage2_PublicClassLayout.SizeF = New Drawing.SizeF(PictureBoxPage2_PublicClassLayout.SizeF.Width, Height)
            'PictureBoxPage2_PublicClassLayout.Image = Bitmap

            'Catch ex As Exception

            'End Try

        End Sub
        Private Sub TablePage3_Methods_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TablePage3_Methods.BeforePrint

            'objects
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim ParameterInfos As Reflection.ParameterInfo() = Nothing
            Dim Parameters As Generic.List(Of String) = Nothing
            Dim ReturnType As String = Nothing
            Dim Counter As Integer = 1

            TablePage3_Methods.DeleteRow(TableRowMethodsTable_TempRow1)
            TablePage3_Methods.DeleteRow(TableRowMethodsTable_TempRow2)

            For Each MethodInfo In GetDocumentationMethods()

                Parameters = New List(Of String)

                XRTableRow = TablePage3_Methods.InsertRowBelow(TablePage3_Methods.Rows.LastRow)

                XRTableRow.Cells(1).Multiline = True

                ParameterInfos = MethodInfo.GetParameters()

                If ParameterInfos IsNot Nothing AndAlso ParameterInfos.Count > 0 Then

                    For Each ParameterInfo In ParameterInfos

                        Parameters.Add(ParameterInfo.Name & " as " & GetFriendlyTypeName(ParameterInfo.ParameterType))

                    Next

                End If

                ReturnType = MethodInfo.ReturnType.Name.ToString()

                Try

                    If MethodInfo.ReturnType.IsGenericType AndAlso MethodInfo.ReturnType.GetGenericTypeDefinition() = GetType(List(Of )) Then

                        ReturnType = "Array Of " & MethodInfo.ReturnType.GetGenericArguments().First.Name.ToString

                    End If

                Catch ex As Exception

                End Try

                If Counter Mod 2 = 1 Then

                    XRTableRow.Styles.Style = OddStyle

                Else

                    XRTableRow.Styles.Style = EvenStyle

                End If

                XRTableRow.Cells(0).Text = MethodInfo.Name
                XRTableRow.Cells(1).Text = String.Join(", " & vbCrLf, Parameters)
                XRTableRow.Cells(2).Text = ReturnType

                Counter += 1

            Next

        End Sub
        Private Sub TablePage4_Method_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles TablePage4_Method.BeforePrint

            'objects
            Dim XRTableRow As DevExpress.XtraReports.UI.XRTableRow = Nothing
            Dim ParameterInfos As Reflection.ParameterInfo() = Nothing
            Dim Parameters As Generic.List(Of String) = Nothing
            Dim Counter As Integer = 1

            TablePage4_Method.DeleteRow(TableRowMethod_TempRow1)
            TablePage4_Method.DeleteRow(TableRowMethod_TempRow2)

            For Each MethodInfo In GetDocumentationMethods()

                Parameters = New List(Of String)

                XRTableRow = TablePage4_Method.InsertRowBelow(TablePage4_Method.Rows.LastRow)

                ParameterInfos = MethodInfo.GetParameters()

                If ParameterInfos IsNot Nothing AndAlso ParameterInfos.Count > 0 Then

                    For Each ParameterInfo In ParameterInfos

                        Parameters.Add(ParameterInfo.Name & "={" & ParameterInfo.Name.ToUpper & "}")

                    Next

                End If

                If Counter Mod 2 = 1 Then

                    XRTableRow.Styles.Style = OddStyle

                Else

                    XRTableRow.Styles.Style = EvenStyle

                End If

                XRTableRow.Cells(0).Text = MethodInfo.Name & "?" & String.Join("&", Parameters)

                Counter += 1

            Next

        End Sub


#End Region

    End Class

End Namespace
