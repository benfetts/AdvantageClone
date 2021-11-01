Namespace Security.Database.Procedures.ClientPortalUser

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

        Public Function LoadConceptShareUserByEmailAddress(ByVal DbContext As Database.DbContext, ByVal EmailAddress As String) As Security.Database.Entities.ClientPortalUser

            Try

                LoadConceptShareUserByEmailAddress = (From ClientPortalUser In DbContext.GetQuery(Of Database.Entities.ClientPortalUser)
                                                      Join Contact In DbContext.GetQuery(Of Database.Entities.ClientContact) On ClientPortalUser.ClientContactID Equals Contact.ContactID
                                                      Where (ClientPortalUser.EmailAddress = EmailAddress Or Contact.EmailAddress = EmailAddress) And ClientPortalUser.ConceptShareUserID IsNot Nothing
                                                      Select ClientPortalUser).SingleOrDefault

            Catch ex As Exception
                LoadConceptShareUserByEmailAddress = Nothing
            End Try

        End Function

        Public Function LoadByUserName(ByVal DbContext As Database.DbContext, ByVal UserName As String) As Security.Database.Entities.ClientPortalUser

            Try

                LoadByUserName = (From ClientPortalUser In DbContext.GetQuery(Of Database.Entities.ClientPortalUser)
                                  Where ClientPortalUser.UserName.ToUpper() = UserName.ToUpper()
                                  Select ClientPortalUser).SingleOrDefault

            Catch ex As Exception
                LoadByUserName = Nothing
            End Try

        End Function
        Public Function LoadByClientPortalUserIDs(ByVal DbContext As Database.DbContext, ByVal ClientPortalUserIDs() As System.Guid) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUser)

            LoadByClientPortalUserIDs = From ClientPortalUser In DbContext.ClientPortalUsers.AsQueryable
                                        Where ClientPortalUserIDs.Contains(ClientPortalUser.ID)
                                        Select ClientPortalUser

        End Function
		Public Function LoadByClientPortalUserID(ByVal DbContext As Database.DbContext, ByVal ClientPortalUserID As System.Guid) As Security.Database.Entities.ClientPortalUser

			Try

				LoadByClientPortalUserID = (From ClientPortalUser In DbContext.GetQuery(Of Database.Entities.ClientPortalUser)
											Where ClientPortalUser.ID = ClientPortalUserID
											Select ClientPortalUser).SingleOrDefault

			Catch ex As Exception
				LoadByClientPortalUserID = Nothing
			End Try

		End Function
		Public Function LoadByClientContactID(ByVal DbContext As Database.DbContext, ByVal ClientContactID As Integer) As Security.Database.Entities.ClientPortalUser

			Try

				LoadByClientContactID = (From ClientPortalUser In DbContext.GetQuery(Of Database.Entities.ClientPortalUser)
										 Where ClientPortalUser.ClientContactID = ClientContactID
										 Select ClientPortalUser).SingleOrDefault

			Catch ex As Exception
				LoadByClientContactID = Nothing
			End Try

		End Function
		Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Entities.ClientPortalUser)

            Load = From ClientPortalUser In DbContext.GetQuery(Of Database.Entities.ClientPortalUser)
                   Select ClientPortalUser

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Application As AdvantageFramework.Security.Database.Entities.Application = Nothing
            Dim ClientContactDetail As AdvantageFramework.Security.Database.Entities.ClientContactDetail = Nothing
            Dim Product As AdvantageFramework.Security.Database.Entities.Product = Nothing
            Dim Division As AdvantageFramework.Security.Database.Entities.Division = Nothing

            Try

                DbContext.ClientPortalUsers.Add(ClientPortalUser)

                ErrorText = ClientPortalUser.ValidateEntity(IsValid)

                If IsValid Then

                    ClientPortalUser.ID = System.Guid.NewGuid

                    DbContext.SaveChanges()

                    Inserted = True

                    For Each Application In AdvantageFramework.Security.Database.Procedures.Application.Load(DbContext).ToList

                        If Application.ID = AdvantageFramework.Security.Application.Client_Portal Then

                            AdvantageFramework.Security.Database.Procedures.ClientPortalUserApplicationAccess.Insert(DbContext, ClientPortalUser.ID, Application.ID, False, Nothing)

                        Else

                            AdvantageFramework.Security.Database.Procedures.ClientPortalUserApplicationAccess.Insert(DbContext, ClientPortalUser.ID, Application.ID, True, Nothing)

                        End If

                    Next

                    DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_CPUSER_MODACCESS([SEC_MODULE_ID], [CPUSER_GUID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " & _
                                                      "SELECT [SEC_MODULE_ID], '" & ClientPortalUser.ID.ToString & "', 0, 1, 1, 1, 0, 0 FROM dbo.SEC_MODULE WHERE SEC_MODULE_ID IN (SELECT SEC_MODULE_ID FROM dbo.SEC_APPLICATION_MOD WHERE SEC_APPLICATION_ID = " & CInt(AdvantageFramework.Security.Application.Client_Portal) & ")")

                    DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.SEC_CPUSER_MODACCESS([SEC_MODULE_ID], [CPUSER_GUID], [IS_BLOCKED], [CAN_ADD], [CAN_PRINT], [CAN_UPDATE], [CUSTOM1], [CUSTOM2]) " & _
                                                      "SELECT [SEC_MODULE_ID], '" & ClientPortalUser.ID.ToString & "', 1, 1, 1, 1, 0, 0 FROM dbo.SEC_MODULE WHERE SEC_MODULE_ID NOT IN (SELECT SEC_MODULE_ID FROM dbo.SEC_APPLICATION_MOD WHERE SEC_APPLICATION_ID = " & CInt(AdvantageFramework.Security.Application.Client_Portal) & ")")

                    If ClientPortalUser.DesktopTemplate > 0 Then
                        ApplyWorkspaceTemplate(DbContext, ClientPortalUser)
                    End If

                    DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = " & ClientPortalUser.ClientContactID)

                    If AdvantageFramework.Security.Database.Procedures.ClientContactDetail.LoadByClientContactID(DbContext, ClientPortalUser.ClientContactID).Count > 0 Then

                        For Each ClientContactDetail In AdvantageFramework.Security.Database.Procedures.ClientContactDetail.LoadByClientContactID(DbContext, ClientPortalUser.ClientContactID).ToList

                            If ClientContactDetail.ProductCode Is Nothing OrElse ClientContactDetail.ProductCode = "" Then

                                For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoadAllActive(DbContext).Where(Function(Prod) Prod.ClientCode = ClientPortalUser.ClientCode AndAlso Prod.DivisionCode = ClientContactDetail.DivisionCode).ToList

                                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
                                                                                    "VALUES({0}, '{1}', '{2}', '{3}')", ClientPortalUser.ClientContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

                                Next

                            Else

                                DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
                                                                                "VALUES({0}, '{1}', '{2}', '{3}')", ClientPortalUser.ClientContactID, ClientPortalUser.ClientCode, ClientContactDetail.DivisionCode, ClientContactDetail.ProductCode))

                            End If

                        Next

                    Else

                        For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoadAllActive(DbContext).Where(Function(Prod) Prod.ClientCode = ClientPortalUser.ClientCode).ToList

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
                                                                            "VALUES({0}, '{1}', '{2}', '{3}')", ClientPortalUser.ClientContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

                        Next

                        For Each Division In AdvantageFramework.Security.Database.Procedures.Division.LoadAllActive(DbContext).Where(Function(Div) Div.ClientCode = ClientPortalUser.ClientCode AndAlso Div.Products.Count = 0).ToList

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE])" & _
                                                                            "VALUES({0}, '{1}', '{2}')", ClientPortalUser.ClientContactID, Division.ClientCode, Division.Code))

                        Next

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser, Optional ByVal UpdateWorkspace As Boolean = False) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Try

                If UpdateWorkspace = True Then

                    ApplyWorkspaceTemplate(DbContext, ClientPortalUser)

                End If

                DbContext.UpdateObject(ClientPortalUser)

                ErrorText = ClientPortalUser.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim ClientPortalUserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing

            Try

                If IsValid Then

                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUserApplicationAccess.DeleteByClientPortalUserID(DbContext, ClientPortalUser.ID) Then

                        If AdvantageFramework.Security.Database.Procedures.ClientPortalUserModuleAccess.DeleteByClientPortalUserID(DbContext, ClientPortalUser.ID) Then

                            If DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = {0}", ClientPortalUser.ClientContactID)) >= 0 Then

                                DbContext.DeleteEntityObject(ClientPortalUser)

                                DbContext.SaveChanges()

                                Deleted = True

                            End If

                        End If

                    End If

                    If Deleted Then

                        For Each ClientPortalUserWorkspace In AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserID(DbContext, ClientPortalUser.ClientContactID).ToList

                            AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Delete(DbContext, ClientPortalUserWorkspace)

                        Next

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Private Function ApplyWorkspaceTemplate(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser)
            Try
                Dim ClientPortalUserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
                Dim WorkspaceTemplate As AdvantageFramework.Security.Database.Entities.WorkspaceTemplate = Nothing
                Dim WorkspaceTemplateDetailsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplateDetail) = Nothing
                Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
                Dim WorkspaceTemplateDetail As AdvantageFramework.Security.Database.Entities.WorkspaceTemplateDetail = Nothing
                Dim WorkspaceTemplateItem As AdvantageFramework.Security.Database.Entities.WorkspaceTemplateItem = Nothing

                WorkspaceTemplate = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByWorkspaceTemplateID(DbContext, ClientPortalUser.DesktopTemplate)

                For Each ClientPortalUserWorkspace In AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserID(DbContext, ClientPortalUser.ClientContactID).ToList

                    AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Delete(DbContext, ClientPortalUserWorkspace)

                Next

                WorkspaceTemplateDetailsList = WorkspaceTemplate.WorkspaceTemplateDetails.ToList

                For Each WorkspaceTemplateDetail In WorkspaceTemplateDetailsList

                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Insert(DbContext, ClientPortalUser.ClientContactID, WorkspaceTemplateDetail.Name, WorkspaceTemplateDetail.Description, WorkspaceTemplateDetail.SortOrder, ClientPortalUserWorkspace) Then

                        For Each WorkspaceTemplateItem In WorkspaceTemplateDetail.WorkspaceTemplateItems

                            AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.Insert(DbContext, ClientPortalUserWorkspace.ID, WorkspaceTemplateItem.ModuleID, WorkspaceTemplateItem.ZoneID, WorkspaceTemplateItem.Height, WorkspaceTemplateItem.Width, WorkspaceTemplateItem.TopCoordinate, WorkspaceTemplateItem.LeftCoordinate, WorkspaceTemplateItem.SortOrder, Nothing)

                        Next

                    End If

                Next

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End Region

    End Module

End Namespace
