Namespace Database.Procedures.CashReceiptPaymentType

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

        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)

            LoadAllActive = From CashReceiptPaymentType In DbContext.GetQuery(Of Database.Entities.CashReceiptPaymentType)
                            Where CashReceiptPaymentType.IsInactive = False
                            Select CashReceiptPaymentType

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.CashReceiptPaymentType

            LoadByID = (From CashReceiptPaymentType In DbContext.GetQuery(Of Database.Entities.CashReceiptPaymentType)
                        Where CashReceiptPaymentType.ID = ID
                        Select CashReceiptPaymentType).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.CashReceiptPaymentType)()

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.CashReceiptPaymentTypes.Add(CashReceiptPaymentType)

                ErrorMessage = CashReceiptPaymentType.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(CashReceiptPaymentType).State = Entity.EntityState.Modified

                ErrorMessage = CashReceiptPaymentType.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CashReceiptPaymentType As AdvantageFramework.Database.Entities.CashReceiptPaymentType) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(CashReceiptPaymentType).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
