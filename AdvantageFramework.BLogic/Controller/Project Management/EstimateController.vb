Imports System.Data.SqlClient

Namespace Controller.ProjectManagement

    <Serializable()>
    Public Class EstimateController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function GetEstimates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal UserCode As String,
                                     ByVal OfficeCode As String,
                                     ByVal ClientCode As String,
                                     ByVal DivisionCode As String,
                                     ByVal ProductCode As String,
                                     ByVal SalesClassCode As String,
                                     ByVal EstimateNumber As Integer,
                                     ByVal EstimateComponentNumber As Short,
                                     ByVal JobNumber As Integer,
                                     ByVal JobComponentNumber As Short,
                                     ByVal CampaignID As Integer,
                                     ByVal ShowAll As Boolean) As Generic.List(Of ViewModels.ProjectManagement.Estimate.EstimateSearchViewModel)

            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@OfficeCode", OfficeCode))
            arParams.Add(New SqlParameter("@ClientCode", ClientCode))
            arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
            arParams.Add(New SqlParameter("@ProductCode", ProductCode))
            arParams.Add(New SqlParameter("@SalesClassCode", SalesClassCode))
            arParams.Add(New SqlParameter("@UserCode", UserCode))
            arParams.Add(New SqlParameter("@EstimateNumber", EstimateNumber))
            arParams.Add(New SqlParameter("@EstimateComponentNumber", EstimateComponentNumber))
            arParams.Add(New SqlParameter("@JobNumber", JobNumber))
            arParams.Add(New SqlParameter("@JobComponentNumber", JobComponentNumber))
            arParams.Add(New SqlParameter("@CampaignID", CampaignID))
            arParams.Add(New SqlParameter("@ShowAll", If(ShowAll, 1, 0)))


            GetEstimates = DbContext.Database.SqlQuery(Of ViewModels.ProjectManagement.Estimate.EstimateSearchViewModel)("EXEC [dbo].[usp_wv_Estimating_GetAllEstimates] @OfficeCode,
                                                                                                    @ClientCode, @DivisionCode, @ProductCode, @SalesClassCode,@UserCode,@EstimateNumber,
                                                                                                    @EstimateComponentNumber,@JobNumber, @JobComponentNumber,@CampaignID,@ShowAll",
                                                                                                    arParams.ToArray).ToList

        End Function


        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub

#End Region

    End Class

End Namespace
