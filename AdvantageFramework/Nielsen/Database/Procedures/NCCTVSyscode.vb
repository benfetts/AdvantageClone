Namespace Nielsen.Database.Procedures.NCCTVSyscode

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

        Public Function GetMaxID(DbContext As Nielsen.Database.DbContext) As Long

            If (From NCCTVSyscode In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVSyscode)
                Select NCCTVSyscode.ID).Any Then

                GetMaxID = (From NCCTVSyscode In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVSyscode)
                            Select NCCTVSyscode.ID).Max

            Else

                GetMaxID = 0

            End If

        End Function
        Public Function GetSyscodesByMarket(DbContext As Nielsen.Database.DbContext, MarketNielsenTVCode As String) As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)

            If Not String.IsNullOrWhiteSpace(MarketNielsenTVCode) Then

                GetSyscodesByMarket = DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)(String.Format("exec advsp_ncc_tv_market_syscodes {0}", MarketNielsenTVCode)).ToList

            Else

                GetSyscodesByMarket = DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)("exec advsp_ncc_tv_market_syscodes NULL").ToList

            End If

        End Function
        Public Function GetSyscodesByMarketHosted(DbContext As Nielsen.Database.DbContext, NielsenClientCodeForHosted As String, MarketNielsenTVCode As String) As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)

            If Not String.IsNullOrWhiteSpace(MarketNielsenTVCode) Then

                GetSyscodesByMarketHosted = DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)(String.Format("exec advsp_hosted_ncc_tv_market_syscodes '{0}', {1}", NielsenClientCodeForHosted, MarketNielsenTVCode)).ToList

            Else

                GetSyscodesByMarketHosted = DbContext.Database.SqlQuery(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)(String.Format("exec advsp_hosted_ncc_tv_market_syscodes '{0}', NULL", NielsenClientCodeForHosted)).ToList

            End If

        End Function
        Public Function LoadByID(DbContext As Nielsen.Database.DbContext, ID As Integer) As Nielsen.Database.Entities.NCCTVSyscode

            LoadByID = (From NCCTVSyscode In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVSyscode)
                        Where NCCTVSyscode.ID = ID
                        Select NCCTVSyscode).SingleOrDefault

        End Function
        Public Function LoadBySyscode(DbContext As Nielsen.Database.DbContext, Syscode As Short) As Nielsen.Database.Entities.NCCTVSyscode

            LoadBySyscode = (From NCCTVSyscode In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVSyscode)
                             Where NCCTVSyscode.Syscode = Syscode
                             Select NCCTVSyscode).SingleOrDefault

        End Function
        Public Function Load(DbContext As Nielsen.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Nielsen.Database.Entities.NCCTVSyscode)

            Load = From NCCTVSyscode In DbContext.GetQuery(Of Nielsen.Database.Entities.NCCTVSyscode)
                   Select NCCTVSyscode

        End Function

#End Region

    End Module

End Namespace
