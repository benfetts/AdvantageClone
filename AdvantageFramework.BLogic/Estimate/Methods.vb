Namespace Estimate

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

        Public Function CalculateGrossIncomeByEstimateRevision(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateRevision As AdvantageFramework.Database.Entities.EstimateRevision) As Decimal

            'objects
            Dim GrossIncome As Decimal = 0

            Try

                If DbContext IsNot Nothing Then

                    If EstimateRevision IsNot Nothing Then

                        For Each EstimateRevisionDetail In EstimateRevision.EstimateRevisionDetails

                            GrossIncome += CalculateGrossIncomeByEstimateRevisionDetail(DbContext, EstimateRevisionDetail)

                        Next

                    End If

                End If

            Catch ex As Exception
                GrossIncome = 0
            Finally
                CalculateGrossIncomeByEstimateRevision = GrossIncome
            End Try

        End Function
        Public Function CalculateGrossIncomeByEstimateRevisionDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EstimateRevisionDetail As AdvantageFramework.Database.Entities.EstimateRevisionDetail) As Decimal

            'objects
            Dim GrossIncome As Decimal = 0

            Try

                If DbContext IsNot Nothing Then

                    If EstimateRevisionDetail IsNot Nothing Then

                        If EstimateRevisionDetail.Function.Type = AdvantageFramework.Database.Entities.FunctionTypes.E.ToString OrElse
                                EstimateRevisionDetail.Function.Type = AdvantageFramework.Database.Entities.FunctionTypes.I.ToString Then

                            GrossIncome = EstimateRevisionDetail.TotalAmount

                        ElseIf EstimateRevisionDetail.Function.Type = AdvantageFramework.Database.Entities.FunctionTypes.V.ToString Then

                            GrossIncome = EstimateRevisionDetail.MarkupAmount

                        ElseIf EstimateRevisionDetail.Function.Type = AdvantageFramework.Database.Entities.FunctionTypes.C.ToString Then

                            GrossIncome = 0

                        End If

                    End If

                End If

            Catch ex As Exception
                GrossIncome = 0
            Finally
                CalculateGrossIncomeByEstimateRevisionDetail = GrossIncome
            End Try

        End Function

        Public Function LoadFunctions(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Function)

            Try

                LoadFunctions = From Item In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                Select Item

            Catch ex As Exception
                LoadFunctions = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
