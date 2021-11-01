Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels

Namespace Interfaces

    Public Interface IEmployeeRepository
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "
        Function GetDefaultEmployeeFunction(EmployeeCode As String) As String
        Function SearchFunctionCategories(ByVal searchCriteria As ViewModels.LookupObjects.FunctionCategory) As List(Of FunctionCategorySearchResult)
#End Region

    End Interface
End Namespace

