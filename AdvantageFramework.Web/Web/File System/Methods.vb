Namespace Web.FileSystem

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetDocumentLevelFromCode(ByVal DocumentLevelCode As String, Optional ByVal DocumentDOLevelCode As String = "") As AdvantageFramework.Database.Entities.DocumentLevel

            'objects
            Dim DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel = Nothing

            Select Case DocumentLevelCode
                Case "AN"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                Case "AR"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountReceivableInvoice

                Case "CL"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Client

                Case "CM"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                Case "DI"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Division

                Case "DO"
                    If DocumentDOLevelCode = "AD" Then
                        DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop
                    ElseIf DocumentDOLevelCode = "ED" Then
                        DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop
                    End If

                Case "EM"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Employee

                Case "EX"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                Case "JC"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                Case "JO"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Job

                Case "OF"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Office

                Case "PR"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Product

                Case "VN"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                Case "VR"
                    DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Vendor

				Case "OR"
					DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

			End Select

            GetDocumentLevelFromCode = DocumentLevel

        End Function
        Public Sub LoadDocumentLevelSetting(ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel, ByRef DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting, _
                                            ByVal DocumentLevelValue As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short)

            'objects
            Dim DocumentLevelValueSections() As String = Nothing

            Select Case DocumentLevel

				Case AdvantageFramework.Database.Entities.DocumentLevel.Office, AdvantageFramework.Database.Entities.DocumentLevel.Campaign, AdvantageFramework.Database.Entities.DocumentLevel.Job,
					AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice, AdvantageFramework.Database.Entities.DocumentLevel.AdNumber,
					AdvantageFramework.Database.Entities.DocumentLevel.Employee, AdvantageFramework.Database.Entities.DocumentLevel.Vendor

					Select Case DocumentLevel

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Office

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Office)
                            DocumentLevelSetting.OfficeCode = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Campaign

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Campaign)
                            DocumentLevelSetting.CampaignID = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Job

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Job)
                            DocumentLevelSetting.JobNumber = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AccountPayableInvoice)
                            DocumentLevelSetting.AccountPayableID = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Employee

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Employee)
                            DocumentLevelSetting.EmployeeCode = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.Vendor

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Vendor)
                            DocumentLevelSetting.VendorCode = DocumentLevelValue

                        Case AdvantageFramework.Database.Entities.DocumentLevel.AdNumber

                            DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber)
                            DocumentLevelSetting.AdNumber = DocumentLevelValue

					End Select

                Case AdvantageFramework.Database.Entities.DocumentLevel.Client

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Client)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False Then

                        DocumentLevelSetting.ClientCode = DocumentLevelValue

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False Then

                            DocumentLevelSetting.ClientCode = System.Web.HttpContext.Current.Session("UploadFK").ToString

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.Division

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Division)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

                            DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

                        End If

                    End If

                    If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                        DocumentLevelSetting.ClientCode = DocumentLevelValueSections(0)
                        DocumentLevelSetting.DivisionCode = DocumentLevelValueSections(1)

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.Product

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Product)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

                            DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

                        End If

                    End If

                    If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                        DocumentLevelSetting.ClientCode = DocumentLevelValueSections(0)
                        DocumentLevelSetting.DivisionCode = DocumentLevelValueSections(1)
                        DocumentLevelSetting.ProductCode = DocumentLevelValueSections(2)

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.JobComponent

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.JobComponent)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                        If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                            DocumentLevelSetting.JobNumber = DocumentLevelValueSections(0)
                            DocumentLevelSetting.JobComponentNumber = DocumentLevelValueSections(1)

                        End If

                    Else

                        DocumentLevelSetting.JobNumber = JobNumber
                        DocumentLevelSetting.JobComponentNumber = JobComponentNumber

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AgencyDesktop)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

                            DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

                        End If

                    End If

                    If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                        DocumentLevelSetting.OfficeCode = DocumentLevelValueSections(0)
                        DocumentLevelSetting.DepartmentCode = DocumentLevelValueSections(1)

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExecutiveDesktop)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

                            DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

                        End If

                    End If

                    If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                        DocumentLevelSetting.OfficeCode = DocumentLevelValueSections(0)
                        DocumentLevelSetting.EmployeeCode = DocumentLevelValueSections(1)

                    End If

                Case AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.ExpenseReceipts)

                    If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

                        DocumentLevelValueSections = DocumentLevelValue.Split(",")

                    Else

                        If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

                            DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

                        End If

                    End If

                    If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

                        DocumentLevelSetting.EmployeeCode = DocumentLevelValueSections(0)
                        DocumentLevelSetting.ExpenseReportInvoiceNumber = DocumentLevelValueSections(1)

                    End If

				Case AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder

					DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.MediaOrder)

					If String.IsNullOrWhiteSpace(DocumentLevelValue) = False AndAlso DocumentLevelValue.Contains(",") Then

						DocumentLevelValueSections = DocumentLevelValue.Split(",")

					Else

						If String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session("UploadFK").ToString) = False AndAlso System.Web.HttpContext.Current.Session("UploadFK").ToString.Contains(",") Then

							DocumentLevelValueSections = System.Web.HttpContext.Current.Session("UploadFK").ToString.Split(",")

						End If

					End If

					If DocumentLevelValueSections IsNot Nothing AndAlso DocumentLevelValueSections.Count > 0 Then

						DocumentLevelSetting.OrderNumber = DocumentLevelValueSections(0)
						DocumentLevelSetting.MediaType = DocumentLevelValueSections(1)

					End If

			End Select

        End Sub

#End Region

    End Module

End Namespace