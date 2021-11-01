Namespace Exporting.DataFilterClasses

    <Serializable()>
    Public Class PurchaseOrderCustom1
        Implements AdvantageFramework.Exporting.Interfaces.IExportDataFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CreateDateStart
            CreateDateEnd
        End Enum

#End Region

#Region " Variables "

        Private _CreateDateStart As Nullable(Of Date) = Nothing
        Private _CreateDateEnd As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreateDateStart() As Nullable(Of Date)
            Get
                CreateDateStart = _CreateDateStart
            End Get
            Set(value As Nullable(Of Date))
                _CreateDateStart = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CreateDateEnd() As Nullable(Of Date)
            Get
                CreateDateEnd = _CreateDateEnd
            End Get
            Set(value As Nullable(Of Date))
                _CreateDateEnd = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _CreateDateStart = Now.ToShortDateString
            _CreateDateEnd = DateAdd(DateInterval.Day, 1, Now).ToShortDateString

        End Sub
        Public Sub New(ByVal CreateDateStart As Date, ByVal CreateDateEnd As Date)

            _CreateDateStart = CreateDateStart
            _CreateDateEnd = CreateDateEnd

        End Sub
        Public Function EntityFilterString() As String Implements Interfaces.IExportDataFilter.EntityFilterString

            'objects
            Dim FilterString As String = ""

            If Me.CreateDateStart.HasValue AndAlso Me.CreateDateEnd.HasValue Then

                FilterString = String.Format("EXEC dbo.advsp_po_export_custom1 '{0}', '{1}'", Me.CreateDateStart.ToString(), Me.CreateDateEnd.ToString())

            End If

            EntityFilterString = FilterString

        End Function
        Public Function Validate(ByRef ErrorMessage As String) As Boolean Implements Interfaces.IExportDataFilter.Validate

            'objects
            Dim IsValid As Boolean = False

            If _CreateDateStart Is Nothing Then

                ErrorMessage = "Please select a create start date."

            ElseIf _CreateDateEnd Is Nothing Then

                ErrorMessage = "Please select an create end date."

            ElseIf _CreateDateStart > _CreateDateEnd Then

                ErrorMessage = "Please select a create start date that is before the create end date."

            Else

                IsValid = True

            End If

            Validate = IsValid

        End Function

#End Region

    End Class

End Namespace
