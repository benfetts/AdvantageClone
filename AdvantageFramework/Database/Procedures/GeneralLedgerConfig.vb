Namespace Database.Procedures.GeneralLedgerConfig

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As Database.Entities.GeneralLedgerConfig

            Load = (From GeneralLedgerConfig In DbContext.GetQuery(Of Database.Entities.GeneralLedgerConfig)
                    Select GeneralLedgerConfig).SingleOrDefault

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.GeneralLedgerConfigs.Add(GeneralLedgerConfig)

                ErrorMessage = GeneralLedgerConfig.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(GeneralLedgerConfig).State = Entity.EntityState.Modified

                ErrorMessage = GeneralLedgerConfig.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
#End Region

    End Module

End Namespace
