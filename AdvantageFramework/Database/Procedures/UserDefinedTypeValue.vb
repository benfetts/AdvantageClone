Namespace Database.Procedures.UserDefinedTypeValue

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.UserDefinedTypeValue)

            Load = From UserDefinedTypeValue In DbContext.GetQuery(Of Database.Entities.UserDefinedTypeValue)
                   Select UserDefinedTypeValue

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserDefinedTypeValue As AdvantageFramework.Database.Entities.UserDefinedTypeValue) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserDefinedTypeValues.Add(UserDefinedTypeValue)

                ErrorText = UserDefinedTypeValue.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserDefinedTypeValue As AdvantageFramework.Database.Entities.UserDefinedTypeValue) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserDefinedTypeValue)

                ErrorText = UserDefinedTypeValue.ValidateEntity(IsValid)

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
