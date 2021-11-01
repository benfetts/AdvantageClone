Namespace Database.Procedures.Activity

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Activity)

            Load = From Activity In DbContext.GetQuery(Of Database.Entities.Activity)
                   Select Activity

        End Function
        Public Function LoadByClientAndDivisionAndProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As AdvantageFramework.Database.Entities.Activity

            Try

                LoadByClientAndDivisionAndProductCode = (From Activity In DbContext.GetQuery(Of Database.Entities.Activity)
                                                         Where Activity.ClientCode = ClientCode AndAlso
                                                               Activity.DivisionCode = DivisionCode AndAlso
                                                               Activity.ProductCode = ProductCode
                                                         Select Activity).SingleOrDefault
            Catch ex As Exception
                LoadByClientAndDivisionAndProductCode = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Activity As AdvantageFramework.Database.Entities.Activity) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.Activities.Add(Activity)

                ErrorText = Activity.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Activity As AdvantageFramework.Database.Entities.Activity) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(Activity)

                ErrorText = Activity.ValidateEntity(IsValid)

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
