Namespace Calendar.Outlook

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "

        Public ExtendedPropertyGUID As Guid = New Guid("{C11FF724-AA03-4555-9952-8FA248A11C3E}")
        Public Const ExtendedPropertyName As String = "BillingInformation"

#End Region

#Region " Enum "

        Public Enum EmailSubjects
            AdvantageCalendarSyncEmail
            AdvantageTaskSyncEmail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function RedirectionCallback(URL As String) As Boolean

            If URL IsNot Nothing Then

                RedirectionCallback = URL.ToLower().Equals("https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml")

            Else

                RedirectionCallback = False

            End If

        End Function
        Public Function SyncEmployeeNonTask(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTaskID As Integer, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                        Syncd = SyncEmployeeNonTask(DbContext, SecurityDbContext, UserCode, AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID), IsDeleting)

                    End Using

                End Using

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function SyncEmployeeNonTask(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileBytes() As Byte = Nothing
            Dim FileName As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Attachments As Generic.List(Of AdvantageFramework.Email.Classes.Attachment) = Nothing

            Try

                If DbContext IsNot Nothing Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If EmployeeNonTask IsNot Nothing AndAlso Agency IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeNonTask.EmployeeCode)

						If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso Employee.IgnoreCalendarSync = False Then

							If IsDeleting Then

								Syncd = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency, Employee, "", AdvantageFramework.StringUtilities.GetNameAsWords(EmailSubjects.AdvantageCalendarSyncEmail.ToString), "Delete Calender Item: " & EmployeeNonTask.Type & EmployeeNonTask.ID, 2, 0)

							Else

								FileName = Now.ToFileTimeUtc.ToString() & ".xml"

								Try

									FileBytes = New System.Text.UnicodeEncoding().GetBytes(EmployeeNonTask.CreateXML)

								Catch ex As Exception
									FileBytes = Nothing
								End Try

								If FileBytes IsNot Nothing Then

									Attachments = New Generic.List(Of AdvantageFramework.Email.Classes.Attachment)

									Attachments.Add(New AdvantageFramework.Email.Classes.Attachment(FileName, FileBytes))

									Syncd = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency, Employee, Attachments, AdvantageFramework.StringUtilities.GetNameAsWords(EmailSubjects.AdvantageCalendarSyncEmail.ToString), "", 1, 0)

								End If

							End If

						End If

					End If

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function SyncEmployeeNonTaskExchangeServer(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTaskID As Integer, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                        Syncd = SyncEmployeeNonTaskExchangeServer(DbContext, SecurityDbContext, UserCode, AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID), IsDeleting)

                    End Using

                End Using

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTaskExchangeServer = Syncd
            End Try

        End Function
        Public Function SyncEmployeeNonTaskExchangeServer(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask, ByVal IsDeleting As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileBytes() As Byte = Nothing
            Dim FileName As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ExchangeService As Microsoft.Exchange.WebServices.Data.ExchangeService = Nothing
            Dim CalendarFolder As Microsoft.Exchange.WebServices.Data.CalendarFolder = Nothing
            Dim CalendarView As Microsoft.Exchange.WebServices.Data.CalendarView = Nothing
            Dim Appointments As Microsoft.Exchange.WebServices.Data.FindItemsResults(Of Microsoft.Exchange.WebServices.Data.Appointment) = Nothing
            Dim Appointment As Microsoft.Exchange.WebServices.Data.Appointment = Nothing
            Dim ExtendedProperty As Microsoft.Exchange.WebServices.Data.ExtendedProperty = Nothing

            Try

                If DbContext IsNot Nothing Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If EmployeeNonTask IsNot Nothing AndAlso Agency IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeNonTask.EmployeeCode)

						If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso Employee.IgnoreCalendarSync = False Then

							ExchangeService = New Microsoft.Exchange.WebServices.Data.ExchangeService(Microsoft.Exchange.WebServices.Data.ExchangeVersion.Exchange2007_SP1)

                            ExchangeService.Credentials = New Microsoft.Exchange.WebServices.Data.WebCredentials(Employee.Email, AdvantageFramework.Security.Encryption.Decrypt(Employee.EmailPassword))
                            ExchangeService.AutodiscoverUrl(Employee.Email, AddressOf RedirectionCallback)

                            If String.IsNullOrEmpty(EmployeeNonTask.OutlookID) = False Then

                                Appointment = Microsoft.Exchange.WebServices.Data.Appointment.Bind(ExchangeService, New Microsoft.Exchange.WebServices.Data.ItemId(EmployeeNonTask.OutlookID))

                                'Try

                                '    Appointment = Appointments.SingleOrDefault(Function(Appt) Appt.Id.UniqueId = EmployeeNonTask.OutlookID)

                                'Catch ex As Exception
                                '    Appointment = Nothing
                                'End Try

                            Else

                                CalendarFolder = Microsoft.Exchange.WebServices.Data.CalendarFolder.Bind(ExchangeService, Microsoft.Exchange.WebServices.Data.WellKnownFolderName.Calendar)

                                CalendarView = New Microsoft.Exchange.WebServices.Data.CalendarView(EmployeeNonTask.StartDate.Value.AddDays(-1), EmployeeNonTask.EndDate.Value.AddDays(1))

                                Appointments = CalendarFolder.FindAppointments(CalendarView)

                                For Each CalAppt In Appointments

									Try

										ExtendedProperty = CalAppt.ExtendedProperties.SingleOrDefault(Function(EP) EP.PropertyDefinition.Name = ExtendedPropertyName)

									Catch ex As Exception
										ExtendedProperty = Nothing
									End Try

									If ExtendedProperty IsNot Nothing AndAlso IsNothing(ExtendedProperty.Value) AndAlso IsNumeric(ExtendedProperty.Value) Then

										If ExtendedProperty.Value = EmployeeNonTask.ID Then

											Appointment = CalAppt
											Exit For

										End If

									End If

								Next

							End If

							If Appointment IsNot Nothing Then

								If IsDeleting Then

									Appointment.Delete(Microsoft.Exchange.WebServices.Data.DeleteMode.MoveToDeletedItems)

									Syncd = True

								Else

                                    Appointment.IsAllDayEvent = EmployeeNonTask.IsAllDay
									Appointment.Start = EmployeeNonTask.StartDateAndTime.Value
									Appointment.End = EmployeeNonTask.EndDateAndTime.Value
									Appointment.Subject = EmployeeNonTask.Description
									Appointment.Body = EmployeeNonTask.Description
									Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeNonTask.ID)

									Appointment.Update(Microsoft.Exchange.WebServices.Data.ConflictResolutionMode.AlwaysOverwrite)

									If Appointment.Id IsNot Nothing AndAlso String.IsNullOrEmpty(Appointment.Id.UniqueId) = False Then

										EmployeeNonTask.OutlookID = Appointment.Id.UniqueId

										Syncd = AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask)

									End If

								End If

							Else

								If IsDeleting = False AndAlso String.IsNullOrEmpty(EmployeeNonTask.OutlookID) Then

									Appointment = New Microsoft.Exchange.WebServices.Data.Appointment(ExchangeService)

									Appointment.IsAllDayEvent = EmployeeNonTask.IsAllDay
									Appointment.Start = EmployeeNonTask.StartDateAndTime.Value
									Appointment.End = EmployeeNonTask.EndDateAndTime.Value
									Appointment.Subject = EmployeeNonTask.Description
									Appointment.Body = EmployeeNonTask.Description
									Appointment.SetExtendedProperty(New Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition(AdvantageFramework.Calendar.Outlook.ExtendedPropertyGUID, AdvantageFramework.Calendar.Outlook.ExtendedPropertyName, Microsoft.Exchange.WebServices.Data.MapiPropertyType.Integer), EmployeeNonTask.ID)

									Appointment.Save()

									If Appointment.Id IsNot Nothing AndAlso String.IsNullOrEmpty(Appointment.Id.UniqueId) = False Then

										EmployeeNonTask.OutlookID = Appointment.Id.UniqueId

										Syncd = AdvantageFramework.Database.Procedures.EmployeeNonTask.Update(DbContext, EmployeeNonTask)

									End If

								End If

							End If

						End If

					End If

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTaskExchangeServer = Syncd
            End Try

        End Function
        Public Function IsSyncWithOutlookEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SyncWithOutlook As Boolean = True

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_OUTLOOK.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) Then

                    If Setting.Value = 0 Then

                        SyncWithOutlook = False

                    End If

                End If

            End If

            IsSyncWithOutlookEnabled = SyncWithOutlook

        End Function
        Public Function OutlookExchangeServerEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim UseOutlookExchangeServer As Boolean = False

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_OUTLOOK_USE_EX.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) Then

                    If Setting.Value = 1 Then

                        UseOutlookExchangeServer = True

                    End If

                End If

            End If

            OutlookExchangeServerEnabled = UseOutlookExchangeServer

        End Function

#End Region

    End Module

End Namespace
