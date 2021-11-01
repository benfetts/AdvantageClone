Namespace Database.Procedures.VendorCrossReference

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

        Public Function LoadByRecordSourceID(ByVal DbContext As Database.DbContext, ByVal RecordSourceID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorCrossReference)

            LoadByRecordSourceID = From VendorCrossReference In DbContext.GetQuery(Of Database.Entities.VendorCrossReference)
                                   Where VendorCrossReference.RecordSourceID = RecordSourceID
                                   Select VendorCrossReference

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorCrossReference)

            Load = From VendorCrossReference In DbContext.GetQuery(Of Database.Entities.VendorCrossReference)
                   Select VendorCrossReference

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorCrossReferences.Add(VendorCrossReference)

                ErrorText = VendorCrossReference.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(VendorCrossReference)

                ErrorText = VendorCrossReference.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(VendorCrossReference)

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
