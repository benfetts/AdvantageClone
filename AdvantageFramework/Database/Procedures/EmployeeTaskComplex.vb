Namespace Database.Procedures.EmployeeTaskComplex

    <HideModuleName()>
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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext,
                         ByVal UserCode As String, ByVal EmployeeCode As String, ByVal StartDate As Nullable(Of Date),
                         ByVal TaskStatus As String, ByVal TaskShow As String, ByVal SearchValue As String,
                         ByVal IsClientPortal As Nullable(Of Integer), ByVal ClientContactID As Nullable(Of Integer),
                         ByVal Skip As Integer, ByVal Take As Integer) As IEnumerable(Of Database.ComplexTypes.EmployeeTaskComplex)

            If StartDate Is Nothing Then StartDate = Today.Date
            If IsClientPortal Is Nothing OrElse IsClientPortal.HasValue = False Then IsClientPortal = 0
            If ClientContactID Is Nothing OrElse ClientContactID.HasValue = False Then ClientContactID = 0

            Load = (From Tasks In Load(DbContext, UserCode, EmployeeCode, StartDate, TaskStatus, TaskShow, SearchValue, IsClientPortal, ClientContactID)).Skip(Skip).Take(Take)

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                 ByVal UserCode As String, ByVal EmployeeCode As String, ByVal StartDate As Nullable(Of Date),
                                 ByVal TaskStatus As String, ByVal TaskShow As String, ByVal SearchValue As String,
                                 ByVal IsClientPortal As Nullable(Of Integer), ByVal ClientContactID As Nullable(Of Integer)) As System.Data.Objects.ObjectResult(Of Database.ComplexTypes.EmployeeTaskComplex)

            If StartDate Is Nothing Then StartDate = Today.Date
            If IsClientPortal Is Nothing OrElse IsClientPortal.HasValue = False Then IsClientPortal = 0
            If ClientContactID Is Nothing OrElse ClientContactID.HasValue = False Then ClientContactID = 0

            Dim UserCodeObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("UserID", UserCode)
            Dim EmployeeCodeObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("EmpCode", EmployeeCode)
            Dim StartDateObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("StartDate", StartDate)
            Dim TaskStatusObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("TaskStatus", TaskStatus)
            Dim TaskShowObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("TaskShow", TaskShow)
            Dim SearchValueObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("Search", SearchValue)
            Dim IsClientPortalObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("CP", IsClientPortal)
            Dim ClientContactIDObjectParameter As System.Data.Objects.ObjectParameter = New System.Data.Objects.ObjectParameter("CPID", ClientContactID)

            Try

                Load = DbContext.ExecuteFunction(Of Database.ComplexTypes.EmployeeTaskComplex)("LoadEmployeeTask", UserCodeObjectParameter, EmployeeCodeObjectParameter, StartDateObjectParameter, TaskStatusObjectParameter,
                                                                                               TaskShowObjectParameter, SearchValueObjectParameter, IsClientPortalObjectParameter, ClientContactIDObjectParameter)

            Catch ex As Exception

                Load = Nothing

            End Try

        End Function

#End Region

    End Module

End Namespace
