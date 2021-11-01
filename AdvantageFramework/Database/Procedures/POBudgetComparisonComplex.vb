Namespace Database.Procedures.POBudgetComparisonComplex

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

        Public Function Load(DbContext As AdvantageFramework.BaseClasses.DbContext,
                             GLACode As String, PODate As System.DateTime) As System.Collections.Generic.List(Of Database.Classes.POBudgetComparison)

            'objects
            Dim SqlParameterPODate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGLACode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterPODate = New System.Data.SqlClient.SqlParameter("@PODate", SqlDbType.DateTime)
            SqlParameterGLACode = New System.Data.SqlClient.SqlParameter("@GlaCode", SqlDbType.VarChar)

            SqlParameterPODate.Value = PODate
            SqlParameterGLACode.Value = If(String.IsNullOrEmpty(GLACode), "", GLACode)

            Try

                Load = DbContext.Database.SqlQuery(Of Database.Classes.POBudgetComparison)("EXEC dbo.proc_WV_PO_Budget_Comparisons @PODate, @GlaCode",
                    SqlParameterPODate, SqlParameterGLACode).ToList

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
