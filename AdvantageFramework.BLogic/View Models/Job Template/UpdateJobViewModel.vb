Namespace ViewModels.JobTemplate

    Public Class UpdateJobViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectedCriteria As String
        Public Property EmployeeCodeAE As String
        <StringLength(6)>
        Public Property AlertGroupJob As String
        <StringLength(50)>
        Public Property SelectedJobComponents As String
        Public Property IsDefaultAE As Boolean
        Public Property Log As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            Log = New Generic.List(Of String)

        End Sub

#End Region

    End Class

End Namespace
