'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class DepartmentTeam
    Public Property Code As String
    Public Property Name As String
    Public Property IsInactive As Nullable(Of Short)
    Public Property DIRECT_HRS_PER_GOAL As Nullable(Of Decimal)
    Public Property CATEGORY As String
    Public Property PO_APPR_RULE_CODE As String
    Public Property SERVICE_FEE_TYPE_CODE As String
    Public Property COLOR_CODE As String

    Public Overridable Property [Function] As ICollection(Of [Function]) = New HashSet(Of [Function])
    Public Overridable Property EmployeeTimeDetail As ICollection(Of EmployeeTimeDetail) = New HashSet(Of EmployeeTimeDetail)
    Public Overridable Property EmployeeTimeIndirect As ICollection(Of EmployeeTimeIndirect) = New HashSet(Of EmployeeTimeIndirect)
    Public Overridable Property EmployeeTimeTemplate As ICollection(Of EmployeeTimeTemplate) = New HashSet(Of EmployeeTimeTemplate)

End Class
