Namespace BillingSystem

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum QtyRateAmount
            Quantity
            Rate
            Amount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function CalculateQuantity(ByVal Rate As Decimal, ByVal Amount As Decimal, ByVal QuantityScale As Short, Optional ByVal UseCPM As Boolean = False) As Object

            'objects
            Dim CalculatedQuantity As Object = Nothing

            Try

                CalculatedQuantity = Math.Round(Convert.ToDecimal((Amount / Rate) * If(UseCPM, 1000, 1)), If(QuantityScale > 0, QuantityScale, 0), MidpointRounding.AwayFromZero)

                If QuantityScale <= 0 Then

                    CalculatedQuantity = Convert.ToInt32(CalculatedQuantity)

                End If

            Catch ex As Exception
                CalculatedQuantity = Nothing
            Finally
                CalculateQuantity = CalculatedQuantity
            End Try

        End Function
        Public Function CalculateRate(ByVal Quantity As Object, ByVal Amount As Decimal, ByVal RateScale As Short, Optional ByVal UseCPM As Boolean = False) As Decimal

            'objects
            Dim CalculatedRate As Decimal = Nothing

            Try

                CalculatedRate = Convert.ToDecimal((Amount / Quantity) * If(UseCPM, 1000, 1))

                If RateScale >= 0 Then

                    CalculatedRate = Math.Round(CalculatedRate, RateScale, MidpointRounding.AwayFromZero)

                End If

            Catch ex As Exception
                CalculatedRate = Nothing
            Finally
                CalculateRate = CalculatedRate
            End Try

        End Function
        Public Function CalculateAmount(ByVal Quantity As Object, ByVal Rate As Decimal, ByVal AmountScale As Short, Optional ByVal UseCPM As Boolean = False) As Decimal

            'Objects
            Dim RealRate As Decimal = 0

            Try

                If UseCPM Then

                    RealRate = Rate / 1000

                Else

                    RealRate = Rate

                End If

                If AmountScale >= 0 Then

                    CalculateAmount = Math.Round(Convert.ToDecimal(Quantity * RealRate), AmountScale, MidpointRounding.AwayFromZero)

                Else

                    CalculateAmount = Convert.ToDecimal(Quantity * RealRate)

                End If

            Catch ex As Exception
                CalculateAmount = Nothing
            End Try

        End Function
        Public Sub CalculateQuantityRateAndAmount(ByRef Quantity As Object, ByRef Rate As Object, ByRef Amount As Object, ByVal FieldChanged As QtyRateAmount,
                                                  Optional ByVal QuantityScale As Short = 0, Optional ByVal RateScale As Short = 4, Optional ByVal AmountScale As Short = 2,
                                                  Optional ByVal UseCPM As Boolean = False)

            If (Quantity Is Nothing OrElse IsNumeric(Quantity)) AndAlso (Rate Is Nothing OrElse IsNumeric(Rate)) AndAlso (Amount Is Nothing OrElse IsNumeric(Amount)) Then

                Try

                    Select Case FieldChanged

                        Case QtyRateAmount.Quantity, QtyRateAmount.Rate

                            If Quantity IsNot Nothing AndAlso Rate IsNot Nothing Then

                                Amount = CalculateAmount(Quantity, Rate, AmountScale, UseCPM)

                            ElseIf Quantity Is Nothing AndAlso Rate IsNot Nothing AndAlso Rate <> 0 Then

                                Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                                If CalculateAmount(Quantity, Rate, AmountScale) <> Amount Then

                                    Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                                End If

                            ElseIf Rate Is Nothing AndAlso Quantity IsNot Nothing AndAlso Quantity <> 0 Then

                                Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                            End If
                            
                        Case QtyRateAmount.Amount

                            If Quantity IsNot Nothing AndAlso Quantity > 0 Then

                                Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                            ElseIf Rate IsNot Nothing AndAlso Rate > 0 Then

                                Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                                If CalculateAmount(Quantity, Rate, AmountScale) <> Amount Then

                                    Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                                End If

                            Else

                                Quantity = Nothing
                                Rate = Nothing

                            End If

                    End Select

                Catch ex As Exception

                End Try

            End If

        End Sub
        Public Function LoadBillingRate(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByRef FoundBillingRate As Boolean, _
                                        ByVal BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel, _
                                        Optional ByVal FunctionCode As String = Nothing, _
                                        Optional ByVal EmployeeCode As String = Nothing, Optional ByVal ClientCode As String = Nothing, _
                                        Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing, _
                                        Optional ByVal SalesClassCode As String = Nothing, Optional ByVal EffectiveDate As Nullable(Of Date) = Nothing, _
                                        Optional ByVal IsNonBillable As Nullable(Of Short) = Nothing, Optional ByVal IsFeeTime As Nullable(Of Short) = Nothing, _
                                        Optional ByVal IsTaxCommission As Nullable(Of Short) = Nothing, Optional ByVal IsCommission As Nullable(Of Decimal) = Nothing, _
                                        Optional ByVal IsTax As Nullable(Of Short) = Nothing, Optional ByVal TaxCode As String = Nothing, _
                                        Optional ByVal EmployeeTitleID As Nullable(Of Integer) = Nothing) As Decimal

            'objects
            Dim BillingRate As Decimal = 0
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim BillingRateDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing

            FoundBillingRate = False

            Try

                BillingRateDetailsList = BillingRateLevel.BillingRateDetails.ToList

                If FunctionCode IsNot Nothing AndAlso FunctionCode <> "" Then

                    BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.FunctionCode = FunctionCode).ToList

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If EmployeeCode IsNot Nothing AndAlso EmployeeCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.EmployeeCode = EmployeeCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If ClientCode IsNot Nothing AndAlso ClientCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.ClientCode = ClientCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If DivisionCode IsNot Nothing AndAlso DivisionCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.DivisionCode = DivisionCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If ProductCode IsNot Nothing AndAlso ProductCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.ProductCode = ProductCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If SalesClassCode IsNot Nothing AndAlso SalesClassCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.SalesClassCode = SalesClassCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If EffectiveDate IsNot Nothing AndAlso EffectiveDate.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.EffectiveDate = EffectiveDate).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If IsNonBillable IsNot Nothing AndAlso IsNonBillable.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.IsNonBillable = IsNonBillable).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If IsFeeTime IsNot Nothing AndAlso IsFeeTime.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.IsFeeTime = IsFeeTime).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If IsTaxCommission IsNot Nothing AndAlso IsTaxCommission.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.IsTaxCommission = IsTaxCommission).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If IsCommission IsNot Nothing AndAlso IsCommission.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.IsCommission = IsCommission).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If IsTax IsNot Nothing AndAlso IsTax.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.IsTax = IsTax).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If TaxCode IsNot Nothing AndAlso TaxCode <> "" Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.TaxCode = TaxCode).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    If EmployeeTitleID IsNot Nothing AndAlso EmployeeTitleID.HasValue Then

                        BillingRateDetailsList = BillingRateDetailsList.Where(Function(RateDetail) RateDetail.EmployeeTitleID = EmployeeTitleID).ToList

                    End If

                End If

                If BillingRateDetailsList IsNot Nothing AndAlso BillingRateDetailsList.Count > 0 Then

                    BillingRateDetail = BillingRateDetailsList.FirstOrDefault

                End If

            Catch ex As Exception
                BillingRateDetail = Nothing
            End Try

            If BillingRateDetail IsNot Nothing Then

                BillingRate = BillingRateDetail.RateAmount.GetValueOrDefault(0)
                FoundBillingRate = True

            End If

            LoadBillingRate = BillingRate

        End Function
        Public Function LoadBillingRate(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext, ByRef FoundBillingRate As Boolean, Optional ByVal FunctionCode As String = Nothing, _
                                        Optional ByVal EmployeeCode As String = Nothing, Optional ByVal ClientCode As String = Nothing, _
                                        Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing, _
                                        Optional ByVal SalesClassCode As String = Nothing, Optional ByVal EffectiveDate As Nullable(Of Date) = Nothing, _
                                        Optional ByVal IsNonBillable As Nullable(Of Short) = Nothing, Optional ByVal IsFeeTime As Nullable(Of Short) = Nothing, _
                                        Optional ByVal IsTaxCommission As Nullable(Of Short) = Nothing, Optional ByVal IsCommission As Nullable(Of Decimal) = Nothing, _
                                        Optional ByVal IsTax As Nullable(Of Short) = Nothing, Optional ByVal TaxCode As String = Nothing, _
                                        Optional ByVal EmployeeTitleID As Nullable(Of Integer) = Nothing) As Decimal

            'objects
            Dim BillingRate As Decimal = 0
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim BillingRateDetailsList As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing

            FoundBillingRate = False

            For Each RateLevel In AdvantageFramework.Database.Procedures.BillingRateLevel.LoadAllActive(DbContext).OrderBy(Function(BillingRateLevel) BillingRateLevel.Number)

                BillingRate = LoadBillingRate(DbContext, FoundBillingRate, RateLevel, FunctionCode, EmployeeCode, ClientCode, DivisionCode, _
                                              ProductCode, SalesClassCode, EffectiveDate, IsNonBillable, IsFeeTime, IsTaxCommission, IsCommission, _
                                              IsTax, TaxCode, EmployeeTitleID)

            Next

            LoadBillingRate = BillingRate

        End Function
        Public Function IsPropertyRequired(ByVal PropertyName As String, ByVal BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel) As Boolean

            'object
            Dim IsRequired As Boolean = False

            Try

                Select Case PropertyName

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.FunctionType.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ClientCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.DivisionCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.ProductCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.SalesClassCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EffectiveDate.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.RateAmount.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsNonBillable.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsFeeTime.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTaxCommission.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsCommission.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.IsTax.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.TaxCode.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))

                    Case AdvantageFramework.Database.Classes.BillingRateDetail.Properties.EmployeeTitleID.ToString

                        IsRequired = Convert.ToBoolean(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0))

                End Select

            Catch ex As Exception
                IsRequired = False
            Finally
                IsPropertyRequired = IsRequired
            End Try

        End Function
        Public Sub APInternetCalculateQuantityRateAndAmount(ByRef Quantity As Object, ByRef Rate As Object, ByRef Amount As Object, ByVal FieldChanged As QtyRateAmount,
                                                            Optional ByVal QuantityScale As Short = 0, Optional ByVal RateScale As Short = 4, Optional ByVal AmountScale As Short = 2,
                                                            Optional ByVal UseCPM As Boolean = False)

            If (Quantity Is Nothing OrElse IsNumeric(Quantity)) AndAlso (Rate Is Nothing OrElse IsNumeric(Rate)) AndAlso (Amount Is Nothing OrElse IsNumeric(Amount)) Then

                Try

                    Select Case FieldChanged

                        Case QtyRateAmount.Quantity, QtyRateAmount.Rate

                            If Quantity IsNot Nothing AndAlso Rate IsNot Nothing Then

                                Amount = CalculateAmount(Quantity, Rate, AmountScale, UseCPM)

                            ElseIf Quantity Is Nothing AndAlso Rate IsNot Nothing AndAlso Rate <> 0 Then

                                Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                                If CalculateAmount(Quantity, Rate, AmountScale) <> Amount Then

                                    Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                                End If

                            ElseIf Rate Is Nothing AndAlso Quantity IsNot Nothing AndAlso Quantity <> 0 Then

                                Rate = CalculateRate(Quantity, Amount, RateScale, UseCPM)

                            End If

                        Case QtyRateAmount.Amount

                            If Rate IsNot Nothing AndAlso Rate > 0 Then

                                Quantity = CalculateQuantity(Rate, Amount, QuantityScale, UseCPM)

                            Else

                                Quantity = Nothing
                                Rate = Nothing

                            End If

                    End Select

                Catch ex As Exception

                End Try

            End If

        End Sub

#End Region

    End Module

End Namespace
