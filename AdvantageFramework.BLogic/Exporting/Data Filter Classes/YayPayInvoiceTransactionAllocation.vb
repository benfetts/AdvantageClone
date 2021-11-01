Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class YayPayInvoiceTransactionAllocation
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            StartDate
            EndDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndDate() As Date

#End Region

#Region " Methods "

        Public Sub New()

            Me.StartDate = Now
            Me.EndDate = Me.StartDate

        End Sub
        Public Sub New(StartDate As Date, EndDate As Date)

            Me.StartDate = StartDate
            Me.EndDate = EndDate

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.StartDate.ToShortDateString & " To " & Me.EndDate.ToShortDateString

        End Function
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            FilterString = String.Format("EXEC dbo.advsp_yaypay_invoices_transaction_allocations_export '{0}', '{1}'", Me.StartDate.ToShortDateString, Me.EndDate.ToShortDateString)

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            If Me.StartDate > Me.EndDate Then

                ErrorMessage = "Please select a start date that is before the end date."

            Else

                IsValid = True

            End If

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
