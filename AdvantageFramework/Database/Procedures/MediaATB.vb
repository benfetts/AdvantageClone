Namespace Database.Procedures.MediaATB

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATB)

            Load = From MediaATB In DbContext.GetQuery(Of Database.Entities.MediaATB)
                   Select MediaATB

        End Function
        Public Function LoadByATBNumber(ByVal DbContext As Database.DbContext, ByVal ATBNumber As Integer) As Database.Entities.MediaATB

            Try

                LoadByATBNumber = (From MediaATB In DbContext.GetQuery(Of Database.Entities.MediaATB)
                                   Where MediaATB.Number = ATBNumber
                                   Select MediaATB).SingleOrDefault

            Catch ex As Exception
                LoadByATBNumber = Nothing
            End Try

        End Function
        Public Function LoadByClientDivisionProduct(ByVal DbContext As Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaATB)

            LoadByClientDivisionProduct = From MediaATB In DbContext.GetQuery(Of Database.Entities.MediaATB)
                                          Where MediaATB.ClientCode = ClientCode AndAlso
                                                MediaATB.DivisionCode = DivisionCode AndAlso
                                                MediaATB.ProductCode = ProductCode
                                          Select MediaATB

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaATBs.Add(MediaATB)

                ErrorText = MediaATB.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaATB)

                ErrorText = MediaATB.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaATB As AdvantageFramework.Database.Entities.MediaATB) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaATB)

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
