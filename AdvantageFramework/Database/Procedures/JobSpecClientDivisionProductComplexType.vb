Namespace Database.Procedures.JobSpecClientDivisionProductComplexType

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DbContext As AdvantageFramework.BaseClasses.DbContext,
                             ByVal JobNumber As Integer) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.JobSpecClientDivisionProduct)

            'objects
            Dim JobNumberObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            JobNumberObjectParameter = New System.Data.Objects.ObjectParameter("JobNumber", JobNumber)

            Load = DbContext.ExecuteFunction(Of Database.ComplexTypes.JobSpecClientDivisionProduct)("LoadJobSpecClientDivisionProduct", JobNumberObjectParameter)

        End Function

#End Region

    End Module

End Namespace
