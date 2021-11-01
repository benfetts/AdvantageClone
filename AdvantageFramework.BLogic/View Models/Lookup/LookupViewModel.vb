Namespace ViewModels.Lookup

    <Serializable()>
    Public Class LookupViewModel

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
        Public ReadOnly Property ClientDivisionProduct As String
            Get

                Return AdvantageFramework.Database.Procedures.Product.BuildClientDivisionProductDisplay(ClientName, DivisionName, ProductDescription)

            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
