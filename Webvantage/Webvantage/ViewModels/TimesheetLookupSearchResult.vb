Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace ViewModels
    Public Class TimesheetLookupSearchResult

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobId As String = String.Empty
        Public Property JobCode As String = String.Empty
        Public Property JobName As String = String.Empty
        Public Property ComponentId As String = String.Empty
        Public Property ComponentCode As String = String.Empty
        Public Property ComponentName As String = String.Empty
        Public Property ProductCategoryCode As String = String.Empty
        Public Property ProductCategoryName As String = String.Empty
        Public Property IsActive As Boolean = False
        Public Property IsOpen As Boolean = False

        Public ReadOnly Property SearchText() As String
            Get
                Return (Me.ClientCode + Space(1) + Me.ClientName + Space(1) + Me.DivisionCode + Space(1) + Me.DivisionName + Space(1) + Me.ProductCode + Space(1) + Me.ProductName + Space(1) + Me.JobCode + Space(1) + Me.JobName + Space(1) + Me.ComponentCode + Space(1) + Me.ComponentName + Space(1) + Me.ProductCategoryCode + Space(1) + Me.ProductCategoryName).ToLower()
            End Get

        End Property
#End Region

#Region " Methods "

#End Region


    End Class
End Namespace
