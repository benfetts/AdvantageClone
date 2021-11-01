Namespace Nielsen.Database.Procedures.NielsenRadioMarket

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

        Public Function LoadByNumber(DbContext As Nielsen.Database.DbContext, Number As Integer) As Nielsen.Database.Entities.NielsenRadioMarket

            LoadByNumber = (From NielsenRadioMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioMarket)
                            Where NielsenRadioMarket.Number = Number
                            Select NielsenRadioMarket).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NielsenRadioMarket)

            Load = From NielsenRadioMarket In DbContext.GetQuery(Of Nielsen.Database.Entities.NielsenRadioMarket)
                   Select NielsenRadioMarket

        End Function
        Public Function Insert(DbContext As Nielsen.Database.DbContext, NielsenRadioMarket As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket, ByRef ErrorText As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.NielsenRadioMarkets.Add(NielsenRadioMarket)

                ErrorText = NielsenRadioMarket.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                While ex.InnerException IsNot Nothing

                    ex = ex.InnerException

                End While

                ErrorText = ex.Message

            Finally
                Insert = Inserted
            End Try

        End Function

#End Region

    End Module

End Namespace
