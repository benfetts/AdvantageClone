Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class PurchaseOrder
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SelectByDate
            DateStart
            DateEnd
        End Enum

        Public Enum SelectByDates
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Create Date")>
            CreateDate = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "PO Date")>
            PODate = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "PO Due Date")>
            PoDueDate = 2
        End Enum

#End Region

#Region " Variables "

        Private _SelectByDate As Short = Nothing
        Private _DateStart As Nullable(Of Date) = Nothing
        Private _DateEnd As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SelectByDate() As Short
            Get
                SelectByDate = _SelectByDate
            End Get
            Set(value As Short)
                _SelectByDate = value
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

            If Me.DateStart.HasValue AndAlso Me.DateEnd.HasValue Then

                FilterString = String.Format("EXEC dbo.advsp_po_export '{0}', '{1}', {2}", Me.DateStart.ToString(), Me.DateEnd.ToString(), Me.SelectByDate)

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
