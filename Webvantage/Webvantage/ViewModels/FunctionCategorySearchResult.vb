Namespace ViewModels
    Public Class FunctionCategorySearchResult
#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property Code As String = String.Empty
        Public Property Description As String = String.Empty

        Public ReadOnly Property SearchText() As String
            Get
                Return (Me.Code + Space(1) + Me.Description).ToLower()
            End Get
        End Property
#End Region

#Region " Methods "

#End Region

    End Class
End Namespace

