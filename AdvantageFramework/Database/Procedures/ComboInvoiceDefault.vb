Namespace Database.Procedures.ComboInvoiceDefault

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

        Public Function LoadByClientCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As Entities.ComboInvoiceDefault

            Try

                LoadByClientCode = (From ComboInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ComboInvoiceDefault)
                                    Where ComboInvoiceDefault.ClientCode = ClientCode
                                    Select ComboInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadOneTimeSettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As Entities.ComboInvoiceDefault

            Try

                LoadOneTimeSettings = (From ComboInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ComboInvoiceDefault)
                                       Where ComboInvoiceDefault.ClientOrDefault = 0
                                       Select ComboInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadOneTimeSettings = Nothing
            End Try

        End Function
        Public Function LoadAgencyDefault(ByVal DbContext As AdvantageFramework.Database.DbContext) As Entities.ComboInvoiceDefault

            Try

                LoadAgencyDefault = (From ComboInvoiceDefault In DbContext.GetQuery(Of Database.Entities.ComboInvoiceDefault)
                                     Where ComboInvoiceDefault.ClientOrDefault = 1
                                     Select ComboInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadAgencyDefault = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Entities.ComboInvoiceDefault)

            Load = DbContext.Set(Of Entities.ComboInvoiceDefault)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ComboInvoiceDefaults.Add(ComboInvoiceDefault)

                ErrorText = ComboInvoiceDefault.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Entry(ComboInvoiceDefault).State = Entity.EntityState.Modified

                ErrorText = ComboInvoiceDefault.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ComboInvoiceDefault).State = Entity.EntityState.Deleted

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

#End Region

    End Module

End Namespace
