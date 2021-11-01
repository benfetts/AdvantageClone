Namespace ViewModels

    <Serializable()>
    Public Class LookupDisplayObject
        Inherits BaseLookupDisplayObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Columns As Generic.List(Of ViewModels.LookupDisplayObject.Column)
        Public Property Results As Generic.IEnumerable(Of ViewModels.LookupObjects.BaseLookupObject)
        Public Property DisplayName As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Columns = New Generic.List(Of ViewModels.LookupDisplayObject.Column)
            Me.Results = New Generic.List(Of ViewModels.LookupObjects.BaseLookupObject)

        End Sub
        Public Sub AddColumn(ByVal FieldName As String, Optional ByVal HeaderText As String = "")

            'objects
            Dim Column As New Column With {.FieldName = FieldName}

            If String.IsNullOrWhiteSpace(HeaderText) Then

                HeaderText = AdvantageFramework.StringUtilities.GetNameAsWords(FieldName)

            End If

            Column.HeaderText = HeaderText

            Me.Columns.Add(Column)

        End Sub

#End Region

#Region "  Classes "

        <Serializable()>
        Public Class Column

            Public Property FieldName As String
            Public Property HeaderText As String

        End Class
        <Serializable()>
        Public Class WorkItemDisplayObject
            Public Property AlertID As Integer = 0
            Public Property Description As String = String.Empty
            Sub New()

            End Sub
        End Class

#End Region

    End Class

    <Serializable()>
    Public Class Lookup

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber As Integer = 0
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentNumber As Short = 0
        Public Property JobComponentDescription As String = String.Empty
        Public Property Key As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property OfficeCode As String = String.Empty
        Public Property OfficeName As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductDescription As String = String.Empty
        Public Property SalesClassCode As String = String.Empty
        Public Property SalesClassDescription As String = String.Empty
        Public Property ManagerCode As String = String.Empty
        Public Property ManagerName As String = String.Empty
        Public Property AccountExecutiveCode As String = String.Empty
        Public Property AccountExecutiveName As String = String.Empty
        Public Property JobTypeCode As String = String.Empty
        Public Property JobTypeDescription As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

