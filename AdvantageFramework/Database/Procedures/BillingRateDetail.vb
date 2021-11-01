Namespace Database.Procedures.BillingRateDetail

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

        Public Function LoadByBillingRateDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateDetailID As String) As Database.Entities.BillingRateDetail

            Try

                LoadByBillingRateDetailID = (From BillingRateDetail In DbContext.GetQuery(Of Database.Entities.BillingRateDetail)
                                             Where BillingRateDetail.ID = BillingRateDetailID
                                             Select BillingRateDetail).SingleOrDefault

            Catch ex As Exception
                LoadByBillingRateDetailID = Nothing
            End Try

        End Function
        Public Function LoadByBillingRateLevelID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateLevelID As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingRateDetail)

            LoadByBillingRateLevelID = From BillingRateDetail In DbContext.GetQuery(Of Database.Entities.BillingRateDetail)
                                       Where BillingRateDetail.BillingRateLevelID = BillingRateLevelID
                                       Select BillingRateDetail

        End Function
        Public Function LoadByEmployeeOnlyDetailsByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As Database.Entities.BillingRateDetail

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            BillingRateLevel = AdvantageFramework.Database.Procedures.BillingRateLevel.LoadEmployeeOnlyBillingRateLevel(DbContext)

            If BillingRateLevel IsNot Nothing Then

                Try

                    LoadByEmployeeOnlyDetailsByEmployeeCode = (From BillingRateDetail In DbContext.GetQuery(Of Database.Entities.BillingRateDetail)
                                                               Where BillingRateDetail.BillingRateLevelID = BillingRateLevel.ID AndAlso
                                                                     BillingRateDetail.EmployeeCode = EmployeeCode
                                                               Select BillingRateDetail).SingleOrDefault

                Catch ex As Exception
                    LoadByEmployeeOnlyDetailsByEmployeeCode = Nothing
                End Try

            Else

                LoadByEmployeeOnlyDetailsByEmployeeCode = Nothing

            End If

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingRateDetail)

            Load = From BillingRateDetail In DbContext.GetQuery(Of Database.Entities.BillingRateDetail)
                   Select BillingRateDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                               ByVal BillingRateLevelID As Short, ByVal EmployeeCode As String, ByVal FunctionCode As String, _
                               ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, _
                               ByVal SalesClassCode As String, ByVal EffectiveDate As Nullable(Of Date), ByVal RateAmount As Nullable(Of Decimal), _
                               ByVal IsNonBillable As Nullable(Of Short), ByVal IsFeeTime As Nullable(Of Short), ByVal IsTaxCommission As Nullable(Of Short), _
                               ByVal IsCommission As Nullable(Of Decimal), ByVal IsTax As Nullable(Of Short), ByVal TaxCode As String, _
                               ByVal IsInactive As Nullable(Of Short), ByVal EmployeeTitleID As Nullable(Of Integer), _
                               ByRef BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                BillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                BillingRateDetail.DbContext = DbContext
                BillingRateDetail.BillingRateLevelID = BillingRateLevelID
                BillingRateDetail.EmployeeCode = EmployeeCode
                BillingRateDetail.FunctionCode = FunctionCode
                BillingRateDetail.ClientCode = ClientCode
                BillingRateDetail.DivisionCode = DivisionCode
                BillingRateDetail.ProductCode = ProductCode
                BillingRateDetail.SalesClassCode = SalesClassCode
                BillingRateDetail.EffectiveDate = EffectiveDate
                BillingRateDetail.RateAmount = RateAmount
                BillingRateDetail.IsNonBillable = IsNonBillable
                BillingRateDetail.IsFeeTime = IsFeeTime
                BillingRateDetail.IsTaxCommission = IsTaxCommission
                BillingRateDetail.IsCommission = IsCommission
                BillingRateDetail.IsTax = IsTax
                BillingRateDetail.TaxCode = TaxCode
                BillingRateDetail.IsInactive = IsInactive
                BillingRateDetail.EmployeeTitleID = EmployeeTitleID

                Inserted = Insert(DbContext, BillingRateDetail)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BillingRateDetails.Add(BillingRateDetail)

                ErrorText = BillingRateDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BillingRateDetail)

                ErrorText = BillingRateDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(BillingRateDetail)

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
