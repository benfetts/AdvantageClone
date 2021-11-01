Namespace Database.Procedures.AdSizeLabel

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

        Public Function LoadByMediaType(ByVal DbContext As Database.DbContext, ByVal MediaType As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdSizeLabel)

            LoadByMediaType = From AdSizeLabel In DbContext.GetQuery(Of Database.Entities.AdSizeLabel)
                              Where AdSizeLabel.MediaType = MediaType
                              Select AdSizeLabel

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AdSizeLabel)

            Load = From AdSizeLabel In DbContext.GetQuery(Of Database.Entities.AdSizeLabel)
                   Select AdSizeLabel

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdSizeLabel As AdvantageFramework.Database.Entities.AdSizeLabel) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AdSizeLabels.Add(AdSizeLabel)

                ErrorText = AdSizeLabel.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AdSizeLabel As AdvantageFramework.Database.Entities.AdSizeLabel) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AdSizeLabel)

                ErrorText = AdSizeLabel.ValidateEntity(IsValid)

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
