Namespace AlertSystem.Classes

	Public Class BasicJobInfo

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property JobNumber As Integer
		Public Property JobComponentNumber As Short

		Public ReadOnly Property HasData As Boolean
		Public ReadOnly Property JobDescription As String
			Get
				Return _JobDescription
			End Get
		End Property
		Public ReadOnly Property JobComponentDescription As String
			Get
				Return _JobComponentDescription
			End Get
		End Property
		Public ReadOnly Property OfficeCode As String
			Get
				Return _OfficeCode
			End Get
		End Property
		Public ReadOnly Property OfficeName As String
			Get
				Return _OfficeName
			End Get
		End Property
		Public ReadOnly Property ClientCode As String
			Get
				Return _ClientCode
			End Get
		End Property
		Public ReadOnly Property ClientName As String
			Get
				Return _ClientName
			End Get
		End Property
		Public ReadOnly Property DivisionCode As String
			Get
				Return _DivisionCode
			End Get
		End Property
		Public ReadOnly Property DivisionName As String
			Get
				Return _DivisionName
			End Get
		End Property
		Public ReadOnly Property ProductCode As String
			Get
				Return _ProductCode
			End Get
		End Property
		Public ReadOnly Property ProductDescription As String
			Get
				Return _ProductDescription
			End Get
		End Property
		Public ReadOnly Property SalesClassCode As String
			Get
				Return _SalesClassCode
			End Get
		End Property
		Public ReadOnly Property CampaignCode As String
			Get
				Return _CampaignCode
			End Get
		End Property
		Public ReadOnly Property CampaignIdentifier As Integer
			Get
				Return _CampaignIdentifier
			End Get
		End Property
		Public ReadOnly Property ClientContactID As String
			Get
				Return _ClientContactID
			End Get
		End Property
		Public ReadOnly Property ProductContactCode As String
			Get
				Return _ProductContactCode
			End Get
		End Property
		Public ReadOnly Property ContactFullName As String
			Get
				Return _ContactFullName
			End Get
		End Property
		Public ReadOnly Property NextAlertSequenceNumber As Integer
			Get
				Return _NextAlertSequenceNumber
			End Get
		End Property
		Public ReadOnly Property AccountExecutive As String
			Get
				Return _AccountExecutive
			End Get
		End Property
		Public ReadOnly Property JobAndComponentDescription As String
			Get
				Return _JobNumber.ToString.PadLeft(6, "0") & "/" & _JobComponentNumber.ToString.PadLeft(2, "0") & " - " & _JobComponentDescription
			End Get
		End Property
		Private Property _JobDescription As String = String.Empty
		Private Property _JobComponentDescription As String = String.Empty
		Private Property _OfficeCode As String = String.Empty
		Private Property _OfficeName As String = String.Empty
		Private Property _ClientCode As String = String.Empty
		Private Property _ClientName As String = String.Empty
		Private Property _DivisionCode As String = String.Empty
		Private Property _DivisionName As String = String.Empty
		Private Property _ProductCode As String = String.Empty
		Private Property _ProductDescription As String = String.Empty
		Private Property _SalesClassCode As String = String.Empty
		Private Property _CampaignCode As String = String.Empty
		Private Property _CampaignIdentifier As Integer = 0
		Private Property _ClientContactID As String = String.Empty
		Private Property _ProductContactCode As String = String.Empty
		Private Property _ContactFullName As String = String.Empty
		Private Property _NextAlertSequenceNumber As Integer = 0
		Private Property _AccountExecutive As String = String.Empty

#End Region

#Region " Methods "

		Sub New(ConnectionString As String, JobNumber As Integer, JobComponentNumber As Short)

			Me.JobNumber = JobNumber
			Me.JobComponentNumber = JobComponentNumber

			Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

				Dim SqlParameterJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
				SqlParameterJobNumber.Value = JobNumber

				Dim SqlParameterJobComponentNumber As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
				SqlParameterJobComponentNumber.Value = JobComponentNumber

				Dim MyCommand As New System.Data.SqlClient.SqlCommand()

				With MyCommand

					.CommandType = CommandType.StoredProcedure
					.CommandText = "usp_wv_dd_popup_get_info_from_jc"
					.Connection = MyConn

					.Parameters.Add(SqlParameterJobNumber)
					.Parameters.Add(SqlParameterJobComponentNumber)

				End With

				MyConn.Open()

				Dim Reader As System.Data.SqlClient.SqlDataReader
				Reader = MyCommand.ExecuteReader()

				If Reader.HasRows = True Then

					_HasData = True

					Do While Reader.Read()

						If Reader.IsDBNull(Reader.GetOrdinal("JOB_DESC")) = False Then _JobDescription = Reader.GetValue(Reader.GetOrdinal("JOB_DESC"))
						If Reader.IsDBNull(Reader.GetOrdinal("JOB_COMP_DESC")) = False Then _JobComponentDescription = Reader.GetValue(Reader.GetOrdinal("JOB_COMP_DESC"))
						If Reader.IsDBNull(Reader.GetOrdinal("OFFICE_CODE")) = False Then _OfficeCode = Reader.GetValue(Reader.GetOrdinal("OFFICE_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("OFFICE_NAME")) = False Then _OfficeName = Reader.GetValue(Reader.GetOrdinal("OFFICE_NAME"))
						If Reader.IsDBNull(Reader.GetOrdinal("CL_CODE")) = False Then _ClientCode = Reader.GetValue(Reader.GetOrdinal("CL_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("CL_NAME")) = False Then _ClientName = Reader.GetValue(Reader.GetOrdinal("CL_NAME"))
						If Reader.IsDBNull(Reader.GetOrdinal("DIV_CODE")) = False Then _DivisionCode = Reader.GetValue(Reader.GetOrdinal("DIV_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("DIV_NAME")) = False Then _DivisionName = Reader.GetValue(Reader.GetOrdinal("DIV_NAME"))
						If Reader.IsDBNull(Reader.GetOrdinal("PRD_CODE")) = False Then _ProductCode = Reader.GetValue(Reader.GetOrdinal("PRD_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("PRD_DESCRIPTION")) = False Then _ProductDescription = Reader.GetValue(Reader.GetOrdinal("PRD_DESCRIPTION"))
						If Reader.IsDBNull(Reader.GetOrdinal("SC_CODE")) = False Then _SalesClassCode = Reader.GetValue(Reader.GetOrdinal("SC_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("CMP_CODE")) = False Then _CampaignCode = Reader.GetValue(Reader.GetOrdinal("CMP_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("CMP_IDENTIFIER")) = False Then _CampaignIdentifier = Reader.GetValue(Reader.GetOrdinal("CMP_IDENTIFIER"))
						If Reader.IsDBNull(Reader.GetOrdinal("CDP_CONTACT_ID")) = False Then _ClientContactID = Reader.GetValue(Reader.GetOrdinal("CDP_CONTACT_ID"))
						If Reader.IsDBNull(Reader.GetOrdinal("PRD_CONT_CODE")) = False Then _ProductContactCode = Reader.GetValue(Reader.GetOrdinal("PRD_CONT_CODE"))
						If Reader.IsDBNull(Reader.GetOrdinal("CONT_FML")) = False Then _ContactFullName = Reader.GetValue(Reader.GetOrdinal("CONT_FML"))
						If Reader.IsDBNull(Reader.GetOrdinal("NEXT_ALERT_SEQ_NBR")) = False Then _NextAlertSequenceNumber = Reader.GetValue(Reader.GetOrdinal("NEXT_ALERT_SEQ_NBR"))
						If Reader.IsDBNull(Reader.GetOrdinal("EMP_CODE")) = False Then _AccountExecutive = Reader.GetValue(Reader.GetOrdinal("EMP_CODE"))

					Loop

				End If

			End Using

		End Sub
		'Sub New(Session As AdvantageFramework.Security.Session, JobNumber As Integer)

		'End Sub

#End Region

	End Class

End Namespace
