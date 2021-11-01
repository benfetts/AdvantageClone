Namespace Database.Procedures.MediaInvoiceDefault

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaInvoiceDefault)

            Load = From MediaInvoiceDefault In DbContext.GetQuery(Of Database.Entities.MediaInvoiceDefault)
                   Select MediaInvoiceDefault

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As Database.Entities.MediaInvoiceDefault

            Try

                LoadByClientCode = (From MediaInvoiceDefault In DbContext.GetQuery(Of Database.Entities.MediaInvoiceDefault)
                                    Where MediaInvoiceDefault.ClientOrDefault = 2 AndAlso
                                          MediaInvoiceDefault.ClientCode = ClientCode
                                    Select MediaInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadOneTimeSettings(ByVal DbContext As Database.DbContext) As Database.Entities.MediaInvoiceDefault

            Try

                LoadOneTimeSettings = (From MediaInvoiceDefault In DbContext.GetQuery(Of Database.Entities.MediaInvoiceDefault)
                                       Where MediaInvoiceDefault.ClientOrDefault = 0
                                       Select MediaInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadOneTimeSettings = Nothing
            End Try

        End Function
        Public Function LoadAgencyDefault(ByVal DbContext As Database.DbContext) As Database.Entities.MediaInvoiceDefault

            Try

                LoadAgencyDefault = (From MediaInvoiceDefault In DbContext.GetQuery(Of Database.Entities.MediaInvoiceDefault)
                                     Where MediaInvoiceDefault.ClientOrDefault = 1
                                     Select MediaInvoiceDefault).SingleOrDefault

            Catch ex As Exception
                LoadAgencyDefault = Nothing
            End Try

        End Function
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault) As Boolean

            'objects
            Dim Reseted As Boolean = False

            Reseted = ResetToDefaults(DbContext, MediaInvoiceDefault.ID)

            ResetToDefaults = Reseted

        End Function
        Public Function ResetToDefaults(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaInvoiceDefaultID As Integer) As Boolean

            'objects
            Dim Reseted As Boolean = False

            Try

                Reseted = (DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[advsp_media_invoice_format_reset_defaults] {0}", MediaInvoiceDefaultID)) > 0)

            Catch ex As Exception
                Reseted = False
            End Try

            ResetToDefaults = Reseted

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaInvoiceDefaults.Add(MediaInvoiceDefault)

                ErrorText = MediaInvoiceDefault.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaInvoiceDefault)

                ErrorText = MediaInvoiceDefault.ValidateEntity(IsValid)

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
