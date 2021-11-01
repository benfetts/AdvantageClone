Namespace Database.Procedures.ComscoreCacheHeader

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreCacheHeader)

            Load = From ComscoreCacheHeader In DbContext.GetQuery(Of Database.Entities.ComscoreCacheHeader)
                   Select ComscoreCacheHeader

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ComscoreCacheHeader As AdvantageFramework.Database.Entities.ComscoreCacheHeader) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ComscoreCacheHeaders.Add(ComscoreCacheHeader)

                ErrorText = ComscoreCacheHeader.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
