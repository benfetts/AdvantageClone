Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels

Namespace Interfaces

    Public Interface IContractRepository
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "
        Function SearchContracts(searchCriteria As ContractSearchCriteria) As List(Of OfficeToProductContractSearchResult)
#End Region
    End Interface

End Namespace