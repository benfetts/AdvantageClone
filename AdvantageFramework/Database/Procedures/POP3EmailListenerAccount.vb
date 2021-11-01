Namespace Database.Procedures.POP3EmailListenerAccount

    <HideModuleName()>
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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.POP3EmailListenerAccount)

            Load = From POP3EmailListenerAccount In DbContext.GetQuery(Of Database.Entities.POP3EmailListenerAccount)
                   Select POP3EmailListenerAccount

        End Function
        Public Function LoadAndIncludeAgencyDefault(ByVal DbContext As Database.DbContext) As System.Collections.Generic.List(Of Database.Entities.POP3EmailListenerAccount)

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            LoadAndIncludeAgencyDefault = LoadAndIncludeAgencyDefault(DbContext, Agency)

        End Function
        Public Function LoadAndIncludeAgencyDefault(ByVal DbContext As Database.DbContext, ByVal Agency As AdvantageFramework.Database.Entities.Agency) As System.Collections.Generic.List(Of Database.Entities.POP3EmailListenerAccount)

            Dim POP3EmailListenerAccounts As System.Collections.Generic.List(Of Database.Entities.POP3EmailListenerAccount) = Nothing

            POP3EmailListenerAccounts = New List(Of Entities.POP3EmailListenerAccount)

            POP3EmailListenerAccounts.AddRange(From Entity In Load(DbContext)
                                               Select Entity)

            POP3EmailListenerAccounts.Insert(0, New Entities.POP3EmailListenerAccount With {.ID = 0, .AccountType = 0, .Description = "Default", .UserName = Agency.POP3UserName, .Password = Agency.POP3Password, .ReplyTo = Agency.POP3DefaultReplyToEmail, .DeleteProcessed = Agency.POP3DeleteMessages})

            LoadAndIncludeAgencyDefault = POP3EmailListenerAccounts

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal POP3EmailListenerAccount As AdvantageFramework.Database.Entities.POP3EmailListenerAccount) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(POP3EmailListenerAccount)

                ErrorText = POP3EmailListenerAccount.ValidateEntity(IsValid)

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
