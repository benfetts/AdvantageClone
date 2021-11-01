Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
'Imports AdvantageMobile.DataService

' Uncomment following class, rename it and add addributes to the corresponding contextual model
'<EntityType Name="Product" m:HasStream="true" xmlns:m="http://schemas.microsoft.com/ado/2007/08/dataservices/metadata">
'Partial Public Class Product
'    Implements IImageSource
'
'    Public ReadOnly Property Image As Byte() Implements IImageSource.Image
'        Get
'            Return ImageSource.Image
'        End Get
'    End Property
'End Class

Partial Public Class ExpenseSummary
    Public Property Employee() As String
    Public Property InvoiceNumber() As Integer
    Public Property InvoiceDate() As Nullable(Of Date)
    Public Property Description() As String
    Public Property Status() As Nullable(Of Integer)
    Public Property SubmittedTo() As String
    Public Property IsSubmitted() As Nullable(Of Short)
    Public Property IsApproved() As Nullable(Of Short)
    Public Property ApproverNotes() As String
    Public Property EmployeeCode() As String
    Public Property TotalExpense() As Nullable(Of Decimal)
    Public Property TotalPayable() As Nullable(Of Decimal)
    Public Property DocumentCount() As Nullable(Of Integer)
    Public Property DetailDescription() As String
End Class