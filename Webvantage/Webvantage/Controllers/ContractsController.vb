Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json

Public Class ContractsController
    Inherits MVCControllerBase


    Function Search() As ActionResult
        Return View()
    End Function

    '<AcceptVerbs("POST")> _
    'Function SearchContracts(searchCriteriaText As String) As ActionResult
    '    Dim results As New List(Of OfficeToProductContractSearchResult)
    '    ''  Dim activeSearchLevels As New List(Of String)

    '    Dim searchCriteria As ContractSearchCriteria = JsonConvert.DeserializeObject(Of ContractSearchCriteria)(searchCriteriaText)

    '    searchCriteria.SearchText = searchCriteria.SearchText.Trim()

    '    Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
    '        Dim documentRepo As Interfaces.IContractRepository = New Repositories.ContractRepository(DataContext)
    '        results = documentRepo.SearchContracts(searchCriteria)
    '    End Using

    '    Return Json(results)
    'End Function
End Class
