Imports System.Collections.Generic

Namespace ViewModels


    Public Class ImportTemplateDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer = Nothing
        Public Property TemplateID As Short = Nothing
        Public Property CSVPosition As Nullable(Of Short) = Nothing
        Public Property CSVField As String = String.Empty
        Public Property FieldName As String = String.Empty
        Public Property DateFormat As String = String.Empty


#End Region

#Region " Methods "
        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
