Namespace Quickbooks.Classes

    Public Class QuickBooksSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            InvoiceEmployeeTimeItem
            InvoiceProductionItem
            InvoiceIncomeOnlyItem
            InvoiceOrderItem
            InvoiceNumberSuffix
            InvoiceLineProductionSalesClass
            InvoiceLineProductionJobNumber
            InvoiceLineProductionComponentNumber
            InvoiceLineProductionJobDescription
            InvoiceLineProductionComponentDescription
            InvoiceLineProductionFunctionDescription
            InvoiceLineMediaSalesClass
            InvoiceLineMediaOrderNumber
            InvoiceLineMediaOrderLineNumber
            InvoiceLineMediaOrderDescription
            BillMediaAccount
            BillNonClientAccount
            BillProductionAccount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property InvoiceEmployeeTimeItem As String
        Public Property InvoiceProductionItem As String
        Public Property InvoiceIncomeOnlyItem As String
        Public Property InvoiceOrderItem As String
        Public Property InvoiceNumberSuffix As String
        Public Property InvoiceLineProductionSalesClass As Boolean
        Public Property InvoiceLineProductionJobNumber As Boolean
        Public Property InvoiceLineProductionComponentNumber As Boolean
        Public Property InvoiceLineProductionJobDescription As Boolean
        Public Property InvoiceLineProductionComponentDescription As Boolean
        Public Property InvoiceLineProductionFunctionDescription As Boolean
        Public Property InvoiceLineMediaSalesClass As Boolean
        Public Property InvoiceLineMediaOrderNumber As Boolean
        Public Property InvoiceLineMediaOrderLineNumber As Boolean
        Public Property InvoiceLineMediaOrderDescription As Boolean
        Public Property BillMediaAccount As String
        Public Property BillNonClientAccount As String
        Public Property BillProductionAccount As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 1

        End Sub
        Public Sub New(QuickbooksSetting As AdvantageFramework.Database.Entities.QuickbooksSetting)

            Me.ID = QuickbooksSetting.ID
            Me.InvoiceEmployeeTimeItem = QuickbooksSetting.InvoiceEmployeeTimeItem
            Me.InvoiceProductionItem = QuickbooksSetting.InvoiceProductionItem
            Me.InvoiceIncomeOnlyItem = QuickbooksSetting.InvoiceIncomeOnlyItem
            Me.InvoiceOrderItem = QuickbooksSetting.InvoiceOrderItem
            Me.InvoiceNumberSuffix = QuickbooksSetting.InvoiceNumberSuffix
            Me.InvoiceLineProductionSalesClass = QuickbooksSetting.InvoiceLineProductionSalesClass
            Me.InvoiceLineProductionJobNumber = QuickbooksSetting.InvoiceLineProductionJobNumber
            Me.InvoiceLineProductionComponentNumber = QuickbooksSetting.InvoiceLineProductionComponentNumber
            Me.InvoiceLineProductionJobDescription = QuickbooksSetting.InvoiceLineProductionJobDescription
            Me.InvoiceLineProductionComponentDescription = QuickbooksSetting.InvoiceLineProductionComponentDescription
            Me.InvoiceLineProductionFunctionDescription = QuickbooksSetting.InvoiceLineProductionFunctionDescription
            Me.InvoiceLineMediaSalesClass = QuickbooksSetting.InvoiceLineMediaSalesClass
            Me.InvoiceLineMediaOrderNumber = QuickbooksSetting.InvoiceLineMediaOrderNumber
            Me.InvoiceLineMediaOrderLineNumber = QuickbooksSetting.InvoiceLineMediaOrderLineNumber
            Me.BillMediaAccount = QuickbooksSetting.BillMediaAccount
            Me.BillNonClientAccount = QuickbooksSetting.BillNonClientAccount
            Me.BillProductionAccount = QuickbooksSetting.BillProductionAccount

        End Sub
        Public Sub SaveToEntity(QuickbooksSetting As AdvantageFramework.Database.Entities.QuickbooksSetting)

            QuickbooksSetting.ID = 1
            QuickbooksSetting.InvoiceEmployeeTimeItem = Me.InvoiceEmployeeTimeItem
            QuickbooksSetting.InvoiceProductionItem = Me.InvoiceProductionItem
            QuickbooksSetting.InvoiceIncomeOnlyItem = Me.InvoiceIncomeOnlyItem
            QuickbooksSetting.InvoiceOrderItem = Me.InvoiceOrderItem
            QuickbooksSetting.InvoiceNumberSuffix = Me.InvoiceNumberSuffix
            QuickbooksSetting.InvoiceLineProductionSalesClass = Me.InvoiceLineProductionSalesClass
            QuickbooksSetting.InvoiceLineProductionJobNumber = Me.InvoiceLineProductionJobNumber
            QuickbooksSetting.InvoiceLineProductionComponentNumber = Me.InvoiceLineProductionComponentNumber
            QuickbooksSetting.InvoiceLineProductionJobDescription = Me.InvoiceLineProductionJobDescription
            QuickbooksSetting.InvoiceLineProductionComponentDescription = Me.InvoiceLineProductionComponentDescription
            QuickbooksSetting.InvoiceLineProductionFunctionDescription = Me.InvoiceLineProductionFunctionDescription
            QuickbooksSetting.InvoiceLineMediaSalesClass = Me.InvoiceLineMediaSalesClass
            QuickbooksSetting.InvoiceLineMediaOrderNumber = Me.InvoiceLineMediaOrderNumber
            QuickbooksSetting.InvoiceLineMediaOrderLineNumber = Me.InvoiceLineMediaOrderLineNumber
            QuickbooksSetting.BillMediaAccount = Me.BillMediaAccount
            QuickbooksSetting.BillNonClientAccount = Me.BillNonClientAccount
            QuickbooksSetting.BillProductionAccount = Me.BillProductionAccount

        End Sub

#End Region

    End Class

End Namespace
