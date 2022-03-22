Namespace Database.Procedures.AccountPayableProduction

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProduction)

            Load = From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                   Select AccountPayableProduction

        End Function
        Public Function LoadActiveByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProduction)

            LoadActiveByAccountPayableID = From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                                           Where AccountPayableProduction.AccountPayableID = AccountPayableID AndAlso
                                                 (AccountPayableProduction.ModifyDelete Is Nothing OrElse
                                                  AccountPayableProduction.ModifyDelete = 0)
                                           Select AccountPayableProduction

        End Function
        Public Function LoadAllByAccountPayableID(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProduction)

            LoadAllByAccountPayableID = From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                                        Where AccountPayableProduction.AccountPayableID = AccountPayableID
                                        Select AccountPayableProduction

        End Function
        Public Function LoadByAccountPayableIDAndLineNumber(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal LineNumber As Short) As Database.Entities.AccountPayableProduction

            Try

                LoadByAccountPayableIDAndLineNumber = (From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                                                       Where AccountPayableProduction.AccountPayableID = AccountPayableID AndAlso
                                                             AccountPayableProduction.LineNumber = LineNumber
                                                       Select AccountPayableProduction).SingleOrDefault

            Catch ex As Exception
                LoadByAccountPayableIDAndLineNumber = Nothing
            End Try

        End Function
        Public Function LoadByAccountPayableIDAndTransaction(ByVal DbContext As Database.DbContext, ByVal AccountPayableID As Integer, ByVal Transaction As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProduction)

            LoadByAccountPayableIDAndTransaction = From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                                                   Where AccountPayableProduction.AccountPayableID = AccountPayableID AndAlso
                                                         AccountPayableProduction.GLTransaction = Transaction
                                                   Select AccountPayableProduction

        End Function
        Public Function LoadAllActiveByPONumberAndPODetailLineNumber(ByVal DbContext As Database.DbContext, ByVal PONumber As Integer, ByVal PODetailLineNumber As Short) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayableProduction)

            LoadAllActiveByPONumberAndPODetailLineNumber = From AccountPayableProduction In DbContext.GetQuery(Of Database.Entities.AccountPayableProduction)
                                                           Where AccountPayableProduction.PONumber = PONumber AndAlso
                                                                 AccountPayableProduction.PODetailLineNumber = PODetailLineNumber AndAlso
                                                                 (AccountPayableProduction.ModifyDelete Is Nothing OrElse AccountPayableProduction.ModifyDelete = 0)
                                                           Select AccountPayableProduction

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AccountPayableProduction.ExtendedNonResaleTax.HasValue = False Then

                    AccountPayableProduction.ExtendedNonResaleTax = 0

                End If

                DbContext.AccountPayableProductions.Add(AccountPayableProduction)

                ErrorText = AccountPayableProduction.ValidateEntity(IsValid)

                If IsValid Then

                    SetNonBillableFlag(DbContext, AccountPayableProduction)

                    Try

                        AccountPayableProduction.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext)
                                                               Where Entity.AccountPayableID = AccountPayableProduction.AccountPayableID AndAlso
                                                                     Entity.AccountPayableSequenceNumber = 0
                                                               Select Entity.LineNumber).Max + 1

                    Catch ex As Exception
                        AccountPayableProduction.LineNumber = 1
                    End Try

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
        Public Function InsertWithoutValidate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                If AccountPayableProduction.ExtendedNonResaleTax.HasValue = False Then

                    AccountPayableProduction.ExtendedNonResaleTax = 0

                End If

                DbContext.AccountPayableProductions.Add(AccountPayableProduction)

                SetNonBillableFlag(DbContext, AccountPayableProduction)

                Try

                    AccountPayableProduction.LineNumber = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.Load(DbContext) _
                                                           Where Entity.AccountPayableID = AccountPayableProduction.AccountPayableID AndAlso _
                                                                 Entity.AccountPayableSequenceNumber = 0
                                                           Select Entity.LineNumber).Max + 1

                Catch ex As Exception
                    AccountPayableProduction.LineNumber = 1
                End Try

                DbContext.SaveChanges()

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                InsertWithoutValidate = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If AccountPayableProduction.ExtendedNonResaleTax.HasValue = False Then

                    AccountPayableProduction.ExtendedNonResaleTax = 0

                End If

                DbContext.UpdateObject(AccountPayableProduction)

                ErrorText = AccountPayableProduction.ValidateEntity(IsValid)

                If IsValid Then

                    SetNonBillableFlag(DbContext, AccountPayableProduction)

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
        Private Sub SetNonBillableFlag(DbContext As AdvantageFramework.Database.DbContext, ByRef AccountPayableProduction As AdvantageFramework.Database.Entities.AccountPayableProduction)

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            If String.IsNullOrWhiteSpace(AccountPayableProduction.OfficeCode) = False Then

                Office = DbContext.Offices.Find(AccountPayableProduction.OfficeCode)

                If Office IsNot Nothing Then

                    If AccountPayableProduction.GLACode = Office.ProductionWorkInProgressGLACode Then

                        AccountPayableProduction.IsNonBillable = 0

                    End If

                End If

            End If

        End Sub

#End Region

    End Module

End Namespace
