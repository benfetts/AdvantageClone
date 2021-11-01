Namespace Reporting.Database.Procedures.BroadcastOrderBySpotReport


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

        Public Function Load(ByVal DbContext As Database.DbContext, ByVal Order As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrderBySpotReport)

            Load = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.BroadcastOrderBySpotReport) _
                            ("EXEC dbo.advsp_media_broadcast_schedule_report_detail @Order", Order)

        End Function
        Private Function IntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Integer)) As System.Data.SqlClient.SqlParameter

            Dim SqlParamIntegerList As Generic.List(Of String) = Nothing
            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            SqlParamIntegerList = New Generic.List(Of String)
            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else

                For Each IntegerElement In IntegerListElements
                    SqlParamIntegerList.Add(IntegerElement)
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function
        Private Function NullableIntegerListToSqlParameter(ByVal ParamName As String, IntegerListElements As Generic.List(Of Nullable(Of Integer))) As System.Data.SqlClient.SqlParameter

            Dim SqlParamIntegerList As Generic.List(Of String) = Nothing
            Dim IntegerSqlParameter As System.Data.SqlClient.SqlParameter

            SqlParamIntegerList = New Generic.List(Of String)
            IntegerSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (IntegerListElements Is Nothing) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            ElseIf (IntegerListElements.Count = 0) Then
                IntegerSqlParameter.Value = System.DBNull.Value
            Else

                For Each IntegerElement In IntegerListElements
                    If (IntegerElement.HasValue) Then
                        SqlParamIntegerList.Add(IntegerElement.Value)
                    Else
                        SqlParamIntegerList.Add("")
                    End If
                Next

                IntegerSqlParameter.Value = Join(SqlParamIntegerList.ToArray, ",")
            End If
            Return IntegerSqlParameter

        End Function
        Private Function BooleanListToSqlParameter(ByVal ParamName As String, BooleanListElements As Generic.List(Of Boolean)) As System.Data.SqlClient.SqlParameter

            Dim SqlParamBooleanList As Generic.List(Of String) = Nothing
            Dim BooleanSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            SqlParamBooleanList = New Generic.List(Of String)
            BooleanSqlParameter = New System.Data.SqlClient.SqlParameter(ParamName, SqlDbType.VarChar)

            If (BooleanListElements Is Nothing) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            ElseIf (BooleanListElements.Count = 0) Then
                BooleanSqlParameter.Value = System.DBNull.Value
            Else

                For Each BooleanElement In BooleanListElements
                    If (BooleanElement = True) Then
                        SqlParamBooleanList.Add("1")
                    Else
                        SqlParamBooleanList.Add("0")
                    End If

                Next

                BooleanSqlParameter.Value = Join(SqlParamBooleanList.ToArray, ",")
            End If
            BooleanListToSqlParameter = BooleanSqlParameter

        End Function

#End Region

    End Module

End Namespace

