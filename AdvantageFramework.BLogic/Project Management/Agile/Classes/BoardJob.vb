Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class BoardJob

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Public Property Key As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property Client As String = String.Empty
        Public Property IsOnBoard As Boolean = False
        Public Property SalesClassCode As String = String.Empty
        Public Property SalesClassDescription As String = String.Empty
        Public Property ManagerCode As String = String.Empty
        Public Property ManagerName As String = String.Empty
        Public Property AccountExecutiveCode As String = String.Empty
        Public Property AccountExecutiveName As String = String.Empty
        Public Property JobTypeCode As String = String.Empty
        Public Property JobTypeDescription As String = String.Empty
        'Public ReadOnly Property AutoCompleteBandedDescription As String
        '    Get
        '        Dim Desc As String = String.Empty
        '        Try

        '            Desc = String.Format("<div class='auto-complete-primary'>{0}</div><div class='auto-complete-secondary'>{1} ({2}, {3}, {4})</div>",
        '                                 Description, Client, ClientCode, DivisionCode, ProductCode)

        '        Catch ex As Exception
        '            Desc = Description
        '        End Try
        '        Return Desc
        '    End Get
        'End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace