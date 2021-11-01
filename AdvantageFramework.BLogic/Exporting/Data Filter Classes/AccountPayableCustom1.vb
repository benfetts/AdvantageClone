Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class AccountPayableCustom1
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SelectByEntryOrInvoiceOrExportDate
            DateStart
            DateEnd
        End Enum
        Public Enum EntryInvoiceExportDate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Entry Date")>
            EntryDate = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Invoice Date")>
            InvoiceDate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Export Date")>
            ExportDate = 2
        End Enum

#End Region

#Region " Variables "

        Private _SelectByEntryOrInvoiceOrExportDate As Short = Nothing
        Private _DateStart As Nullable(Of Date) = Nothing
        Private _DateEnd As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Entry/Invoice/Export Date")>
        Public Property SelectByEntryOrInvoiceOrExportDate() As Short
            Get
                SelectByEntryOrInvoiceOrExportDate = _SelectByEntryOrInvoiceOrExportDate
            End Get
            Set(value As Short)
                _SelectByEntryOrInvoiceOrExportDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DateStart() As Nullable(Of Date)
            Get
                DateStart = _DateStart
            End Get
            Set(value As Nullable(Of Date))
                _DateStart = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
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



        End Sub
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            If Me.DateStart.HasValue AndAlso Me.DateEnd.HasValue Then

                FilterString = String.Format("EXEC dbo.advsp_ap_export_custom1 {0}, '{1}', '{2}'", Me.SelectByEntryOrInvoiceOrExportDate, Me.DateStart.ToString(), Me.DateEnd.ToString())

            Else

                FilterString = String.Format("EXEC dbo.advsp_ap_export_custom1 2")

            End If

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
