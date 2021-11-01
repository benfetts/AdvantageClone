Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class AccountPayable
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SelectByEntryOrInvoiceDate
            DateStart
            DateEnd
        End Enum

        Public Enum EntryDateOrInvoiceDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Entry Date")>
            EntryDate = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Invoice Date")>
            InvoiceDate = 1
        End Enum

#End Region

#Region " Variables "

        Private _SelectByEntryOrInvoiceDate As Short = Nothing
        Private _DateStart As Nullable(Of Date) = Nothing
        Private _DateEnd As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SelectByEntryOrInvoiceDate() As Short
            Get
                SelectByEntryOrInvoiceDate = _SelectByEntryOrInvoiceDate
            End Get
            Set(value As Short)
                _SelectByEntryOrInvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DateStart() As Nullable(Of Date)
            Get
                DateStart = _DateStart
            End Get
            Set(value As Nullable(Of Date))
                _DateStart = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(), _
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DateEnd() As Nullable(Of Date)
            Get
                DateEnd = _DateEnd
            End Get
            Set(value As Nullable(Of Date))
                _DateEnd = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            If Debugger.IsAttached Then

                _DateStart = DateSerial(Now.Year, 1, 1)
                _DateEnd = DateSerial(Now.Year, 12, 31)

            Else

                _DateStart = Nothing
                _DateEnd = Nothing

            End If

        End Sub
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            FilterString = String.Format("EXEC dbo.advsp_ap_export @DATE_START, @DATE_END, @ENTRY_OR_INVOICE_DATE")

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            If _DateStart Is Nothing Then

                ErrorMessage = "Please select a start date."

            ElseIf _DateEnd Is Nothing Then

                ErrorMessage = "Please select an end date."

            ElseIf _DateStart > _DateEnd Then

                ErrorMessage = "Please select a start date that is before the end date."

            Else

                IsValid = True

            End If

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
