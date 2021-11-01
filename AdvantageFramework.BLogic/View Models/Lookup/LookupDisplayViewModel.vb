Namespace ViewModels.Lookup

    <Serializable()>
    Public Class LookupDisplayViewModel
        Inherits BaseLookupDisplayViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Columns As Generic.List(Of LookupDisplayViewModel.Column)
        Public Property Results As Generic.IEnumerable(Of ViewModels.Lookup.BaseLookupDisplayViewModel)
        Public Property DisplayName As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Columns = New Generic.List(Of LookupDisplayViewModel.Column)
            Me.Results = New Generic.List(Of ViewModels.Lookup.BaseLookupDisplayViewModel)

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

            Sub New()
            End Sub

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

End Namespace
