Namespace Database.Procedures.ComscoreTVBook

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

        Public Function LoadByID(DbContext As Database.DbContext, ID As Integer) As Database.Entities.ComscoreTVBook

            LoadByID = (From ComscoreTVBook In DbContext.GetQuery(Of Database.Entities.ComscoreTVBook)
                        Where ComscoreTVBook.ID = ID
                        Select ComscoreTVBook).SingleOrDefault

        End Function
        Public Function LoadAvailable(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreTVBook)

            'objects
            Dim EndDateTime As Date = Nothing

            EndDateTime = Now.AddDays(-13)

            LoadAvailable = From ComscoreTVBook In DbContext.GetQuery(Of Database.Entities.ComscoreTVBook)
                            Where ComscoreTVBook.EndDateTime <= EndDateTime
                            Select ComscoreTVBook

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ComscoreTVBook)

            Load = From ComscoreTVBook In DbContext.GetQuery(Of Database.Entities.ComscoreTVBook)
                   Select ComscoreTVBook

        End Function

#End Region

    End Module

End Namespace
