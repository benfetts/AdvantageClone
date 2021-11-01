Namespace Database.Procedures.ClientContactDetail

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

        Public Function LoadByContactID(ByVal DbContext As Database.DbContext, ByVal ContactID As Int32) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContactDetail)

            LoadByContactID = From ClientContactDetail In DbContext.GetQuery(Of Database.Entities.ClientContactDetail)
                              Where ClientContactDetail.ContactID = ContactID
                              Select ClientContactDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientContactDetail)

            Load = From ClientContactDetail In DbContext.GetQuery(Of Database.Entities.ClientContactDetail)
                   Select ClientContactDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                DbContext.ClientContactDetails.Add(ClientContactDetail)

                ErrorText = ClientContactDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, ClientContactDetail.ContactID).Count = 0 Then

                        ClientContactDetail.SequenceNumber = 1

                    Else

                        ClientContactDetail.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, ClientContactDetail.ContactID) _
                                                              Select Entity.SequenceNumber).Max + 1

                    End If

                    DbContext.SaveChanges()

                    If ClientContactDetail.ProductCode Is Nothing OrElse ClientContactDetail.ProductCode = "" Then

                        For Each Product In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext).Where(Function(Prod) Prod.ClientCode = ClientContactDetail.ClientContact.ClientCode AndAlso Prod.DivisionCode = ClientContactDetail.DivisionCode).ToList

                            DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
                                                                            "VALUES({0}, '{1}', '{2}', '{3}')", ClientContactDetail.ContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

                        Next

                    Else

                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" & _
                                                                        "VALUES({0}, '{1}', '{2}', '{3}')", ClientContactDetail.ContactID, ClientContactDetail.ClientContact.ClientCode, ClientContactDetail.DivisionCode, ClientContactDetail.ProductCode))

                    End If

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.DeleteEntityObject(ClientContactDetail)

                ErrorText = ClientContactDetail.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientContactDetail As AdvantageFramework.Database.Entities.ClientContactDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ClientContactDetail)

                ErrorText = ClientContactDetail.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
