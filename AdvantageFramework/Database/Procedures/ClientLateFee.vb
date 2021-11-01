Namespace Database.Procedures.ClientLateFee

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ClientLateFee)

            Load = From ClientLateFee In DbContext.GetQuery(Of Database.Entities.ClientLateFee)
                   Select ClientLateFee

        End Function
        Public Function Insert(DbContext As AdvantageFramework.Database.DbContext, ClientLateFee As AdvantageFramework.Database.Entities.ClientLateFee,
                               ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ClientLateFees.Add(ClientLateFee)

                ErrorText = ClientLateFee.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = ex.Message
            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
