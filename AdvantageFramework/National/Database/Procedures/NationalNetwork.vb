Namespace National.Database.Procedures.NationalNetwork

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

        Public Function Load(DbContext As National.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of National.Database.Entities.NationalNetwork)

            Load = From NationalNetwork In DbContext.GetQuery(Of National.Database.Entities.NationalNetwork)
                   Select NationalNetwork

        End Function
        Public Function Insert(ByVal DbContext As National.Database.DbContext, ByVal NationalNetwork As AdvantageFramework.National.Database.Entities.NationalNetwork) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.NationalNetworks.Add(NationalNetwork)

                ErrorText = NationalNetwork.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

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
