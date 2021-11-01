Namespace Database.Procedures.Associate

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

        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Associate)

            Try

                LoadByClientAndDivisionAndProductCode = From Associate In DbContext.GetQuery(Of Database.Entities.Associate)
                                                        Where Associate.ClientCode = ClientCode AndAlso
                                                              Associate.DivisionCode = DivisionCode AndAlso
                                                              Associate.ProductCode = ProductCode
                                                        Select Associate

            Catch ex As Exception
                LoadByClientAndDivisionAndProductCode = Nothing
            End Try

        End Function
        Public Function LoadByClientAndDivisionCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Associate)

            Try

                LoadByClientAndDivisionCode = From Associate In DbContext.GetQuery(Of Database.Entities.Associate)
                                              Where Associate.ClientCode = ClientCode AndAlso
                                                    Associate.DivisionCode = DivisionCode AndAlso
                                                    Associate.ProductCode = Nothing
                                              Select Associate

            Catch ex As Exception
                LoadByClientAndDivisionCode = Nothing
            End Try

        End Function
        Public Function LoadByClientCode(ByVal DbContext As Database.DbContext, ByVal ClientCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Associate)

            Try

                LoadByClientCode = From Associate In DbContext.GetQuery(Of Database.Entities.Associate)
                                   Where Associate.ClientCode = ClientCode AndAlso
                                         Associate.DivisionCode = Nothing AndAlso
                                         Associate.ProductCode = Nothing
                                   Select Associate

            Catch ex As Exception
                LoadByClientCode = Nothing
            End Try

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal AssociateID As String) As Database.Entities.Associate

            Try

                LoadByID = (From Associate In DbContext.GetQuery(Of Database.Entities.Associate)
                            Where Associate.ID = AssociateID
                            Select Associate).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Associate)

            Load = From Associate In DbContext.GetQuery(Of Database.Entities.Associate)
                   Select Associate

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Associate As AdvantageFramework.Database.Entities.Associate) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim AssociateID As Integer = Nothing

            Try

                Try

                    AssociateID = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Associate).Select(Function(Assoc) Assoc.ID).Max + 1

                Catch ex As Exception
                    AssociateID = 1
                End Try

                Associate.ID = AssociateID

                DbContext.Associates.Add(Associate)

                ErrorText = Associate.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Associate As AdvantageFramework.Database.Entities.Associate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Associate)

                ErrorText = Associate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Associate As AdvantageFramework.Database.Entities.Associate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(Associate)

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
