Namespace Database.Procedures.QuoteVsActualSummaryComplexType

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
                             ByVal UserCode As String, ByVal JobNumber As String,
                             ByVal JobComponentNumber As String) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.QuoteVsActualSummary)

            'objects
            Dim UserCodeObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim JobNumberObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim JobComponentNumberObjectParameter As System.Data.Objects.ObjectParameter = Nothing
            Dim EmployeeCodesObjectParameter As System.Data.Objects.ObjectParameter = Nothing

            If UserCode IsNot Nothing Then

                UserCodeObjectParameter = New System.Data.Objects.ObjectParameter("UserID", UserCode)

            Else

                UserCodeObjectParameter = New System.Data.Objects.ObjectParameter("UserID", GetType(String))

            End If

            If JobNumber IsNot Nothing Then

                JobNumberObjectParameter = New System.Data.Objects.ObjectParameter("JobNum", JobNumber)

            Else

                JobNumberObjectParameter = New System.Data.Objects.ObjectParameter("JobNum", GetType(String))

            End If

            If JobComponentNumber IsNot Nothing Then

                JobComponentNumberObjectParameter = New System.Data.Objects.ObjectParameter("JobComp", JobComponentNumber)

            Else

                JobComponentNumberObjectParameter = New System.Data.Objects.ObjectParameter("JobComp", GetType(String))

            End If

            EmployeeCodesObjectParameter = New System.Data.Objects.ObjectParameter("Emps", "")

            Load = DbContext.ExecuteFunction(Of Database.ComplexTypes.QuoteVsActualSummary)("LoadQuoteVsActualSummary", UserCodeObjectParameter, JobNumberObjectParameter, JobComponentNumberObjectParameter, EmployeeCodesObjectParameter)

        End Function

#End Region

    End Module

End Namespace

