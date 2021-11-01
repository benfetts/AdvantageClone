Namespace Database.Procedures.StandardComment

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

        Public Function LoadByCommentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CommentID As Integer) As AdvantageFramework.Database.Entities.StandardComment

            Try

                LoadByCommentID = (From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                                   Where StandardComment.ID = CommentID
                                   Select StandardComment).SingleOrDefault

            Catch ex As Exception
                LoadByCommentID = Nothing
            End Try

        End Function
        Public Function LoadByVendorCodeAndApplicationCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCode As String, ByVal ApplicationCode As String) As AdvantageFramework.Database.Entities.StandardComment

            Try

                LoadByVendorCodeAndApplicationCode = (From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                                                      Where StandardComment.VendorCode = VendorCode AndAlso
                                                             StandardComment.ApplicationCode = ApplicationCode
                                                      Select StandardComment).SingleOrDefault

            Catch ex As Exception
                LoadByVendorCodeAndApplicationCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCodeAndApplicationCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal ApplicationCode As String) As AdvantageFramework.Database.Entities.StandardComment

            Try

                LoadByClientCodeAndApplicationCode = (From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                                                      Where StandardComment.ClientCode = ClientCode AndAlso
                                                             StandardComment.ApplicationCode = ApplicationCode
                                                      Select StandardComment).SingleOrDefault

            Catch ex As Exception
                LoadByClientCodeAndApplicationCode = Nothing
            End Try

        End Function
        Public Function LoadByOfficeCodeAndApplicationCode(DbContext As AdvantageFramework.Database.DbContext, OfficeCode As String, ApplicationCode As String) As AdvantageFramework.Database.Entities.StandardComment

            'objects
            Dim STDComment As AdvantageFramework.Database.Entities.StandardComment = Nothing

            STDComment = (From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                          Where StandardComment.OfficeCode = OfficeCode AndAlso
                                StandardComment.ApplicationCode = ApplicationCode
                          Select StandardComment).SingleOrDefault

            If STDComment Is Nothing Then

                STDComment = (From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                              Where StandardComment.ApplicationCode = ApplicationCode
                              Select StandardComment).FirstOrDefault

            End If

            LoadByOfficeCodeAndApplicationCode = STDComment

        End Function
        Public Function LoadByApplicationCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ApplicationCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.StandardComment)

            LoadByApplicationCode = From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                                    Where StandardComment.ApplicationCode = ApplicationCode
                                    Select StandardComment

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.StandardComment)

            Load = From StandardComment In DbContext.GetQuery(Of Database.Entities.StandardComment)
                   Select StandardComment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StandardComment As AdvantageFramework.Database.Entities.StandardComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.StandardComments.Add(StandardComment)

                ErrorText = StandardComment.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StandardComment As AdvantageFramework.Database.Entities.StandardComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(StandardComment)

                ErrorText = StandardComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal StandardComment As AdvantageFramework.Database.Entities.StandardComment) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(StandardComment)

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
