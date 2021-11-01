Namespace Database.Procedures.NielsenRadioPeriod

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

        Public Function LoadByMarketCode(DbContext As Database.DbContext, MarketCode As String) As System.Collections.Generic.List(Of Database.Entities.NielsenRadioPeriod)

            'objects
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing
            Dim NielsenRadioPeriodIDs As IEnumerable(Of Integer) = Nothing

            Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

            If Market IsNot Nothing AndAlso IsNumeric(Market.NielsenRadioCode) Then

                NielsenRadioPeriodIDs = (From NielsenRadioSegmentParent In DbContext.GetQuery(Of Database.Entities.NielsenRadioSegmentParent)
                                         Where NielsenRadioSegmentParent.NielsenRadioMarketNumber = CInt(Market.NielsenRadioCode)
                                         Select NielsenRadioSegmentParent.NielsenRadioPeriodID).Distinct.ToArray

                If NielsenRadioPeriodIDs IsNot Nothing AndAlso NielsenRadioPeriodIDs.Count > 0 Then

                    LoadByMarketCode = (From NielsenRadioPeriod In DbContext.GetQuery(Of Database.Entities.NielsenRadioPeriod)
                                        Where NielsenRadioPeriodIDs.Contains(NielsenRadioPeriod.ID)
                                        Select NielsenRadioPeriod).ToList

                Else

                    LoadByMarketCode = New System.Collections.Generic.List(Of Database.Entities.NielsenRadioPeriod)

                End If

            Else

                LoadByMarketCode = New System.Collections.Generic.List(Of Database.Entities.NielsenRadioPeriod)

            End If

        End Function
        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.NielsenRadioPeriod)

            Load = From NielsenRadioPeriod In DbContext.GetQuery(Of Database.Entities.NielsenRadioPeriod)
                   Select NielsenRadioPeriod

        End Function

#End Region

    End Module

End Namespace
