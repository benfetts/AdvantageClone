Namespace Database.Procedures.ContractFee

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractFee)

            Load = From ContractFee In DbContext.GetQuery(Of Database.Entities.ContractFee)
                   Select ContractFee

        End Function
        Public Function LoadByContractIDAndServiceFeeTypeID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer, ByVal ServiceFeeTypeID As Integer) As Database.Entities.ContractFee

            Try
                LoadByContractIDAndServiceFeeTypeID = (From ContractFee In DbContext.GetQuery(Of Database.Entities.ContractFee)
                                                       Where ContractFee.ContractID = ContractID AndAlso
                                                             ContractFee.ServiceFeeTypeID = ServiceFeeTypeID
                                                       Select ContractFee).SingleOrDefault

            Catch ex As Exception
                LoadByContractIDAndServiceFeeTypeID = Nothing
            End Try

        End Function
        Public Function LoadByContractID(ByVal DbContext As Database.DbContext, ByVal ContractID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.ContractFee)

            LoadByContractID = From ContractFee In DbContext.GetQuery(Of Database.Entities.ContractFee)
                               Where ContractFee.ContractID = ContractID
                               Select ContractFee

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractFee As AdvantageFramework.Database.Entities.ContractFee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.ContractFees.Add(ContractFee)

                ErrorText = ContractFee.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.ContractFees.Any(Function(Entity) Entity.ContractID = ContractFee.ContractID AndAlso _
                                                                       Entity.ServiceFeeTypeID = ContractFee.ServiceFeeTypeID) = False Then

                        DbContext.SaveChanges()

                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please enter a unique fee type.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractFee As AdvantageFramework.Database.Entities.ContractFee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(ContractFee)

                ErrorText = ContractFee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ContractFee As AdvantageFramework.Database.Entities.ContractFee) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(ContractFee)

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
