Namespace Database.Procedures.UserDefinedLabel

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

        Public Function LoadByUserDefinedLabelTable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserDefinedLabelTable As String) As AdvantageFramework.Database.Entities.UserDefinedLabel

            Try

                LoadByUserDefinedLabelTable = (From UserDefinedLabel In DbContext.UserDefinedLabel _
                                               Where UserDefinedLabel.AssociatedTable = UserDefinedLabelTable _
                                               Select UserDefinedLabel).SingleOrDefault

            Catch ex As Exception
                LoadByUserDefinedLabelTable = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.UserDefinedLabel)

            Load = From UserDefinedLabel In DbContext.UserDefinedLabel
                   Select UserDefinedLabel

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UserDefinedLabel.Add(UserDefinedLabel)

                ErrorText = UserDefinedLabel.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(UserDefinedLabel)

                ErrorText = UserDefinedLabel.ValidateEntity(IsValid)

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
