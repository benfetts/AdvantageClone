Namespace MediaManager

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

#Region " Private "

        Private Sub SaveInternetComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.INTERNET_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SaveMagazineComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPositionInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCloseInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRateInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInHouseComments As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)
            SqlParameterPositionInfo = New System.Data.SqlClient.SqlParameter("@POSITION_INFO", SqlDbType.VarChar)
            SqlParameterCloseInfo = New System.Data.SqlClient.SqlParameter("@CLOSE_INFO", SqlDbType.VarChar)
            SqlParameterRateInfo = New System.Data.SqlClient.SqlParameter("@RATE_INFO", SqlDbType.VarChar)
            SqlParameterInHouseComments = New System.Data.SqlClient.SqlParameter("@IN_HOUSE_CMTS", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.MAGAZINE_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES, POSITION_INFO = @POSITION_INFO, CLOSE_INFO = @CLOSE_INFO, RATE_INFO = @RATE_INFO, IN_HOUSE_CMTS = @IN_HOUSE_CMTS WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)
            SetSqlParamaterValue(SqlParameterPositionInfo, MediaManagerOrderLineComment.PositionInformation)
            SetSqlParamaterValue(SqlParameterCloseInfo, MediaManagerOrderLineComment.CloseInformation)
            SetSqlParamaterValue(SqlParameterRateInfo, MediaManagerOrderLineComment.RateInformation)
            SetSqlParamaterValue(SqlParameterInHouseComments, MediaManagerOrderLineComment.InHouseComments)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes,
                                       SqlParameterPositionInfo, SqlParameterCloseInfo, SqlParameterRateInfo, SqlParameterInHouseComments, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SaveNewspaperComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPositionInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCloseInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRateInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInHouseComments As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)
            SqlParameterPositionInfo = New System.Data.SqlClient.SqlParameter("@POSITION_INFO", SqlDbType.VarChar)
            SqlParameterCloseInfo = New System.Data.SqlClient.SqlParameter("@CLOSE_INFO", SqlDbType.VarChar)
            SqlParameterRateInfo = New System.Data.SqlClient.SqlParameter("@RATE_INFO", SqlDbType.VarChar)
            SqlParameterInHouseComments = New System.Data.SqlClient.SqlParameter("@IN_HOUSE_CMTS", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.NEWSPAPER_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES, POSITION_INFO = @POSITION_INFO, CLOSE_INFO = @CLOSE_INFO, RATE_INFO = @RATE_INFO, IN_HOUSE_CMTS = @IN_HOUSE_CMTS WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)
            SetSqlParamaterValue(SqlParameterPositionInfo, MediaManagerOrderLineComment.PositionInformation)
            SetSqlParamaterValue(SqlParameterCloseInfo, MediaManagerOrderLineComment.CloseInformation)
            SetSqlParamaterValue(SqlParameterRateInfo, MediaManagerOrderLineComment.RateInformation)
            SetSqlParamaterValue(SqlParameterInHouseComments, MediaManagerOrderLineComment.InHouseComments)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes,
                                       SqlParameterPositionInfo, SqlParameterCloseInfo, SqlParameterRateInfo, SqlParameterInHouseComments, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SaveOutOfHomeComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.OUTDOOR_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SaveRadioComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPositionInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCloseInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRateInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInHouseComments As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)
            SqlParameterPositionInfo = New System.Data.SqlClient.SqlParameter("@POSITION_INFO", SqlDbType.VarChar)
            SqlParameterCloseInfo = New System.Data.SqlClient.SqlParameter("@CLOSE_INFO", SqlDbType.VarChar)
            SqlParameterRateInfo = New System.Data.SqlClient.SqlParameter("@RATE_INFO", SqlDbType.VarChar)
            SqlParameterInHouseComments = New System.Data.SqlClient.SqlParameter("@IN_HOUSE_CMTS", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.RADIO_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES, POSITION_INFO = @POSITION_INFO, CLOSE_INFO = @CLOSE_INFO, RATE_INFO = @RATE_INFO, IN_HOUSE_CMTS = @IN_HOUSE_CMTS WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)
            SetSqlParamaterValue(SqlParameterPositionInfo, MediaManagerOrderLineComment.PositionInformation)
            SetSqlParamaterValue(SqlParameterCloseInfo, MediaManagerOrderLineComment.CloseInformation)
            SetSqlParamaterValue(SqlParameterRateInfo, MediaManagerOrderLineComment.RateInformation)
            SetSqlParamaterValue(SqlParameterInHouseComments, MediaManagerOrderLineComment.InHouseComments)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes,
                                       SqlParameterPositionInfo, SqlParameterCloseInfo, SqlParameterRateInfo, SqlParameterInHouseComments, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SaveTVComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                  ByVal MediaManagerOrderLineComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInstructions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMiscInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderCopy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMatlNotes As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPositionInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCloseInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRateInfo As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInHouseComments As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterInstructions = New System.Data.SqlClient.SqlParameter("@INSTRUCTIONS", SqlDbType.VarChar)
            SqlParameterMiscInfo = New System.Data.SqlClient.SqlParameter("@MISC_INFO", SqlDbType.VarChar)
            SqlParameterOrderCopy = New System.Data.SqlClient.SqlParameter("@ORDER_COPY", SqlDbType.VarChar)
            SqlParameterMatlNotes = New System.Data.SqlClient.SqlParameter("@MATL_NOTES", SqlDbType.VarChar)
            SqlParameterPositionInfo = New System.Data.SqlClient.SqlParameter("@POSITION_INFO", SqlDbType.VarChar)
            SqlParameterCloseInfo = New System.Data.SqlClient.SqlParameter("@CLOSE_INFO", SqlDbType.VarChar)
            SqlParameterRateInfo = New System.Data.SqlClient.SqlParameter("@RATE_INFO", SqlDbType.VarChar)
            SqlParameterInHouseComments = New System.Data.SqlClient.SqlParameter("@IN_HOUSE_CMTS", SqlDbType.VarChar)

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@LINE_NBR", SqlDbType.SmallInt)
            SqlParameterOrderNumber.Value = MediaManagerOrderLineComment.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerOrderLineComment.LineNumber

            CommandText = "UPDATE dbo.TV_COMMENTS SET INSTRUCTIONS = @INSTRUCTIONS, MISC_INFO = @MISC_INFO, ORDER_COPY = @ORDER_COPY, MATL_NOTES = @MATL_NOTES, POSITION_INFO = @POSITION_INFO, CLOSE_INFO = @CLOSE_INFO, RATE_INFO = @RATE_INFO, IN_HOUSE_CMTS = @IN_HOUSE_CMTS WHERE ORDER_NBR = @ORDER_NBR AND LINE_NBR = @LINE_NBR"

            SetSqlParamaterValue(SqlParameterInstructions, MediaManagerOrderLineComment.Instructions)
            SetSqlParamaterValue(SqlParameterMiscInfo, MediaManagerOrderLineComment.MiscellaneousInformation)
            SetSqlParamaterValue(SqlParameterOrderCopy, MediaManagerOrderLineComment.OrderCopy)
            SetSqlParamaterValue(SqlParameterMatlNotes, MediaManagerOrderLineComment.MaterialNotes)
            SetSqlParamaterValue(SqlParameterPositionInfo, MediaManagerOrderLineComment.PositionInformation)
            SetSqlParamaterValue(SqlParameterCloseInfo, MediaManagerOrderLineComment.CloseInformation)
            SetSqlParamaterValue(SqlParameterRateInfo, MediaManagerOrderLineComment.RateInformation)
            SetSqlParamaterValue(SqlParameterInHouseComments, MediaManagerOrderLineComment.InHouseComments)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterInstructions, SqlParameterMiscInfo, SqlParameterOrderCopy, SqlParameterMatlNotes,
                                       SqlParameterPositionInfo, SqlParameterCloseInfo, SqlParameterRateInfo, SqlParameterInHouseComments, SqlParameterOrderNumber, SqlParameterLineNumber)

        End Sub
        Private Sub SetSqlParamaterValue(ByVal SqlParameter As System.Data.SqlClient.SqlParameter,
                                         ByVal StringValue As String)

            If String.IsNullOrWhiteSpace(StringValue) Then

                SqlParameter.Value = System.DBNull.Value

            Else

                SqlParameter.Value = StringValue

            End If

        End Sub
        Private Sub SaveInternetOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.INTERNET_HEADER SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Sub SaveMagazineOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.MAGAZINE_HEADER SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Sub SaveNewspaperOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.NEWSPAPER_HEADER SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Sub SaveOutOfHomeOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.OUTDOOR_HEADER SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Sub SaveRadioOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.RADIO_HDR SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Sub SaveTVOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal MediaManagerOrderComment As AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderComment As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHouseComment As System.Data.SqlClient.SqlParameter = Nothing

            CommandText = "UPDATE dbo.TV_HDR SET ORDER_COMMENT = @ORDER_COMMENT, HOUSE_COMMENT = @HOUSE_COMMENT WHERE ORDER_NBR = @ORDER_NBR"

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@ORDER_NBR", SqlDbType.Int)
            SqlParameterOrderComment = New System.Data.SqlClient.SqlParameter("@ORDER_COMMENT", SqlDbType.VarChar)
            SqlParameterHouseComment = New System.Data.SqlClient.SqlParameter("@HOUSE_COMMENT", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = MediaManagerOrderComment.OrderNumber
            SetSqlParamaterValue(SqlParameterOrderComment, MediaManagerOrderComment.OrderComment)
            SetSqlParamaterValue(SqlParameterHouseComment, MediaManagerOrderComment.InHouseComment)

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterOrderComment, SqlParameterHouseComment, SqlParameterOrderNumber)

        End Sub
        Private Function CreateImportAccountPayable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BatchName As String,
                                                    ByVal Vendor As AdvantageFramework.Database.Entities.Vendor, ByVal GetOptionDefaultAPDescriptionFromVendorAccount As Boolean,
                                                    ByVal InvoiceTotalNet As Decimal, ByVal ImportTemplateID As Short,
                                                    ByVal InvoiceNumber As String, ByVal InvoiceDate As Date) As AdvantageFramework.Database.Entities.ImportAccountPayable

            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing

            ImportAccountPayable = New AdvantageFramework.Database.Entities.ImportAccountPayable
            ImportAccountPayable.DbContext = DbContext

            ImportAccountPayable.BatchName = BatchName
            ImportAccountPayable.VendorCode = Vendor.Code
            ImportAccountPayable.InvoiceNumber = InvoiceNumber

            If GetOptionDefaultAPDescriptionFromVendorAccount Then

                ImportAccountPayable.InvoiceDescription = Vendor.AccountNumber

            End If

            ImportAccountPayable.InvoiceDate = InvoiceDate
            ImportAccountPayable.InvoiceTotalNet = InvoiceTotalNet
            ImportAccountPayable.OfficeCode = Vendor.OfficeCode
            ImportAccountPayable.IsOnHold = False
            ImportAccountPayable.ImportTemplateID = ImportTemplateID
            ImportAccountPayable.GLAccount = Vendor.DefaultAPAccount
            ImportAccountPayable.SourceCode = "OT"

            CreateImportAccountPayable = ImportAccountPayable

        End Function
        Private Sub InsertImportAccountPayableMediaDetail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                                          ByVal ImportAccountPayableID As Integer)

            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing

            ImportAccountPayableMedia = New AdvantageFramework.Database.Entities.ImportAccountPayableMedia
            ImportAccountPayableMedia.DbContext = DbContext

            ImportAccountPayableMedia.ImportAccountPayableID = ImportAccountPayableID
            ImportAccountPayableMedia.MediaType = MediaManagerReviewDetail.MediaFrom.Substring(0, 1)
            ImportAccountPayableMedia.OrderNumber = MediaManagerReviewDetail.OrderNumber
            ImportAccountPayableMedia.SalesClassCode = MediaManagerReviewDetail.SalesClassCode
            ImportAccountPayableMedia.OrderLineNumber = MediaManagerReviewDetail.LineNumber

            If String.IsNullOrWhiteSpace(MediaManagerReviewDetail.MonthYear) = False AndAlso MediaManagerReviewDetail.MonthYear.Contains(" ") Then

                ImportAccountPayableMedia.Month = MediaManagerReviewDetail.MonthYear.Substring(0, MediaManagerReviewDetail.MonthYear.IndexOf(" "))
                ImportAccountPayableMedia.Year = MediaManagerReviewDetail.MonthYear.Substring(MediaManagerReviewDetail.MonthYear.IndexOf(" "))

            End If

            ImportAccountPayableMedia.MediaQuantity = MediaManagerReviewDetail.Spots
            ImportAccountPayableMedia.MediaNetAmount = MediaManagerReviewDetail.NetAmount.GetValueOrDefault(0) + MediaManagerReviewDetail.DiscountAmount.GetValueOrDefault(0)
            ImportAccountPayableMedia.MediaNetCharge = MediaManagerReviewDetail.NetChargeAmount
            ImportAccountPayableMedia.MediaVendorTax = MediaManagerReviewDetail.NonResaleTax

            If MediaManagerReviewDetail.CommissionAmount.HasValue AndAlso MediaManagerReviewDetail.CommissionAmount.Value <> 0 AndAlso MediaManagerReviewDetail.NetAmount.HasValue Then

                ImportAccountPayableMedia.MediaMarkupPercent = MediaManagerReviewDetail.CommissionAmount.Value * 100 / MediaManagerReviewDetail.NetAmount.Value

            End If

            ImportAccountPayableMedia.MediaAddAmount = MediaManagerReviewDetail.AdditionalChargeAmount

            ImportAccountPayableMedia.ClientCode = MediaManagerReviewDetail.ClientCode
            ImportAccountPayableMedia.ClientName = MediaManagerReviewDetail.ClientName
            ImportAccountPayableMedia.DivisionCode = MediaManagerReviewDetail.DivisionCode
            ImportAccountPayableMedia.DivisionName = MediaManagerReviewDetail.DivisionName
            ImportAccountPayableMedia.ProductCode = MediaManagerReviewDetail.ProductCode
            ImportAccountPayableMedia.ProductName = MediaManagerReviewDetail.ProductDescription

            ImportAccountPayableMedia.OfficeCodeDetail = MediaManagerReviewDetail.OfficeCode

            If AdvantageFramework.Database.Procedures.ImportAccountPayableMedia.Insert(DbContext, ImportAccountPayableMedia) = False Then

                Throw New Exception("Failed inserting into IMP_AP_MEDIA.")

            End If

        End Sub
        Private Sub InsertImportAccountPayableMediaDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal MediaManagerReviewDetails As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail),
                                                           ByVal ImportAccountPayableID As Integer)

            Dim ImportAccountPayableMedia As AdvantageFramework.Database.Entities.ImportAccountPayableMedia = Nothing

            For Each MediaManagerReviewDetail In MediaManagerReviewDetails

                InsertImportAccountPayableMediaDetail(DbContext, MediaManagerReviewDetail, ImportAccountPayableID)

            Next

        End Sub

#End Region

#Region " Public "

        Public Function LoadMediaManagerAPInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal OrderNumber As Integer,
                                                   ByVal LineNumbers As IEnumerable(Of Integer),
                                                   ByVal MediaType As String) As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice)

            Dim MediaManagerAPInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice) = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@OrderNumber", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@OrderLineNumbers", SqlDbType.VarChar)
            SqlParameterMediaType = New System.Data.SqlClient.SqlParameter("@MediaType", SqlDbType.VarChar)

            SqlParameterOrderNumber.Value = OrderNumber
            SqlParameterLineNumber.Value = String.Join(",", LineNumbers.ToArray)
            SqlParameterMediaType.Value = MediaType.Substring(0, 1).ToUpper

            MediaManagerAPInvoices = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.MediaManagerAPInvoice)("EXEC advsp_media_manager_load_ap_invoices @OrderNumber, @OrderLineNumbers, @MediaType",
                                                                SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterMediaType).ToList()

            LoadMediaManagerAPInvoices = MediaManagerAPInvoices

        End Function
        Public Function LoadMediaManagerSearchResults(DbContext As AdvantageFramework.Database.DbContext,
                                                      SelectBy As Short, Newspaper As Boolean, Magazine As Boolean, Internet As Boolean,
                                                      OutOfHome As Boolean, Radio As Boolean, Television As Boolean,
                                                      IncludeOrder As Boolean, IncludeQuote As Boolean, IncludeClosedOrders As Boolean,
                                                      LineStartDate As Date?, LineEndDate As Date?, JobMediaStartDate As Date?, JobMediaEndDate As Date?,
                                                      MediaMonthStartDate As Date?, MediaMonthEndDate As Date?, FilterBy As AdvantageFramework.Database.Entities.MediaManagerSearchFilterType,
                                                      PO As Boolean) As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)

            Dim MediaManagerSearchResults As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterSelectBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewspaper As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMagazine As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterInternet As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOutOfHome As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRadio As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterTelevision As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeOrder As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeQuote As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIncludeClosedOrders As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobMediaEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaMonthStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaMonthEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterFilterBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPO As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterSelectBy = New System.Data.SqlClient.SqlParameter("@select_by", SqlDbType.SmallInt)
            SqlParameterNewspaper = New System.Data.SqlClient.SqlParameter("@newspaper", SqlDbType.Bit)
            SqlParameterMagazine = New System.Data.SqlClient.SqlParameter("@magazine", SqlDbType.Bit)
            SqlParameterInternet = New System.Data.SqlClient.SqlParameter("@internet", SqlDbType.Bit)
            SqlParameterOutOfHome = New System.Data.SqlClient.SqlParameter("@out_of_home", SqlDbType.Bit)
            SqlParameterRadio = New System.Data.SqlClient.SqlParameter("@radio", SqlDbType.Bit)
            SqlParameterTelevision = New System.Data.SqlClient.SqlParameter("@television", SqlDbType.Bit)
            SqlParameterIncludeOrder = New System.Data.SqlClient.SqlParameter("@include_order", SqlDbType.Bit)
            SqlParameterIncludeQuote = New System.Data.SqlClient.SqlParameter("@include_quote", SqlDbType.Bit)
            SqlParameterIncludeClosedOrders = New System.Data.SqlClient.SqlParameter("@include_closed_orders", SqlDbType.Bit)
            SqlParameterLineStartDate = New System.Data.SqlClient.SqlParameter("@order_line_start_date", SqlDbType.SmallDateTime)
            SqlParameterLineEndDate = New System.Data.SqlClient.SqlParameter("@order_line_end_date", SqlDbType.SmallDateTime)
            SqlParameterJobMediaStartDate = New System.Data.SqlClient.SqlParameter("@job_media_start_date", SqlDbType.SmallDateTime)
            SqlParameterJobMediaEndDate = New System.Data.SqlClient.SqlParameter("@job_media_end_date", SqlDbType.SmallDateTime)
            SqlParameterMediaMonthStartDate = New System.Data.SqlClient.SqlParameter("@media_month_start_date", SqlDbType.Int)
            SqlParameterMediaMonthEndDate = New System.Data.SqlClient.SqlParameter("@media_month_end_date", SqlDbType.Int)
            SqlParameterFilterBy = New System.Data.SqlClient.SqlParameter("@filter_by", SqlDbType.SmallInt)
            SqlParameterPO = New System.Data.SqlClient.SqlParameter("@po", SqlDbType.Bit)

            SqlParameterUserID.Value = DbContext.UserCode
            SqlParameterSelectBy.Value = SelectBy
            SqlParameterNewspaper.Value = Newspaper
            SqlParameterMagazine.Value = Magazine
            SqlParameterInternet.Value = Internet
            SqlParameterOutOfHome.Value = OutOfHome
            SqlParameterRadio.Value = Radio
            SqlParameterTelevision.Value = Television
            SqlParameterIncludeOrder.Value = IncludeOrder
            SqlParameterIncludeQuote.Value = IncludeQuote
            SqlParameterIncludeClosedOrders.Value = IncludeClosedOrders

            If LineStartDate.HasValue Then

                SqlParameterLineStartDate.Value = LineStartDate.Value

            Else

                SqlParameterLineStartDate.Value = System.DBNull.Value

            End If

            If LineEndDate.HasValue Then

                SqlParameterLineEndDate.Value = LineEndDate.Value

            Else

                SqlParameterLineEndDate.Value = System.DBNull.Value

            End If

            If JobMediaStartDate.HasValue Then

                SqlParameterJobMediaStartDate.Value = JobMediaStartDate.Value

            Else

                SqlParameterJobMediaStartDate.Value = System.DBNull.Value

            End If

            If JobMediaEndDate.HasValue Then

                SqlParameterJobMediaEndDate.Value = JobMediaEndDate.Value

            Else

                SqlParameterJobMediaEndDate.Value = System.DBNull.Value

            End If

            If MediaMonthStartDate.HasValue Then

                SqlParameterMediaMonthStartDate.Value = MediaMonthStartDate.Value.Year.ToString & MediaMonthStartDate.Value.Month.ToString.PadLeft(2, "0")

            Else

                SqlParameterMediaMonthStartDate.Value = System.DBNull.Value

            End If

            If MediaMonthEndDate.HasValue Then

                SqlParameterMediaMonthEndDate.Value = MediaMonthEndDate.Value.Year.ToString & MediaMonthEndDate.Value.Month.ToString.PadLeft(2, "0")

            Else

                SqlParameterMediaMonthEndDate.Value = System.DBNull.Value

            End If

            SqlParameterFilterBy.Value = FilterBy

            SqlParameterPO.Value = PO

            MediaManagerSearchResults = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)("EXEC advsp_media_manager_load_search_results @user_id, @select_by, @newspaper, @magazine, @internet, @out_of_home, @radio, @television, @include_order, @include_quote, @include_closed_orders, @order_line_start_date, @order_line_end_date, @job_media_start_date, @job_media_end_date, @media_month_start_date, @media_month_end_date, @filter_by, @po",
                                                                             SqlParameterUserID, SqlParameterSelectBy, SqlParameterNewspaper, SqlParameterMagazine, SqlParameterInternet,
                                                                             SqlParameterOutOfHome, SqlParameterRadio, SqlParameterTelevision, SqlParameterIncludeOrder,
                                                                             SqlParameterIncludeQuote, SqlParameterIncludeClosedOrders, SqlParameterLineStartDate, SqlParameterLineEndDate,
                                                                             SqlParameterJobMediaStartDate, SqlParameterJobMediaEndDate, SqlParameterMediaMonthStartDate, SqlParameterMediaMonthEndDate,
                                                                             SqlParameterFilterBy, SqlParameterPO).ToList()

            If MediaManagerSearchResults Is Nothing Then

                MediaManagerSearchResults = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerSearchResult)

            End If

            LoadMediaManagerSearchResults = MediaManagerSearchResults

        End Function
        Public Function LoadMediaManagerReminderContacts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal OrderNumberLineNumberList As IEnumerable(Of String),
                                                         PONumberList As IEnumerable(Of Integer)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.ReminderContact)

            'objects
            Dim ReminderContacts As Generic.List(Of AdvantageFramework.MediaManager.Classes.ReminderContact) = Nothing
            Dim SqlParameterOrderNumberLineNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterPONumberList As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderNumberLineNumberList = New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)
            SqlParameterPONumberList = New System.Data.SqlClient.SqlParameter("@PONumberList", SqlDbType.VarChar)

            SqlParameterOrderNumberLineNumberList.Value = If(OrderNumberLineNumberList IsNot Nothing, String.Join(",", OrderNumberLineNumberList.ToArray), System.DBNull.Value)
            SqlParameterPONumberList.Value = If(PONumberList IsNot Nothing, String.Join(",", PONumberList.ToArray), System.DBNull.Value)

            ReminderContacts = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.ReminderContact)("EXEC advsp_media_manager_load_reminder_contacts @OrderNumberLineNumberList, @PONumberList",
                                                                                                                       SqlParameterOrderNumberLineNumberList, SqlParameterPONumberList).ToList()

            LoadMediaManagerReminderContacts = ReminderContacts

        End Function
        Public Function LoadMediaManagerReviewDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal CampaignIDList As IEnumerable(Of Integer),
                                                      ByVal ClientCodeList As IEnumerable(Of String),
                                                      ByVal ClientDivisionCodeList As IEnumerable(Of String),
                                                      ByVal ClientDivisionCodeProductList As IEnumerable(Of String),
                                                      ByVal JobNumbers As IEnumerable(Of Integer),
                                                      ByVal JobNumberComponentNumbers As IEnumerable(Of String),
                                                      ByVal OrderNumbers As IEnumerable(Of Integer),
                                                      ByVal OrderLines As IEnumerable(Of String),
                                                      ByVal OrderStatuses As IEnumerable(Of Short),
                                                      ByVal AEDefaultEmployeeCodes As IEnumerable(Of String),
                                                      ByVal AEJobEmployeeCodes As IEnumerable(Of String),
                                                      ByVal LoadForProcessControl As Boolean,
                                                      VendorCodes As IEnumerable(Of String),
                                                      SelectForServiceRefresh As Boolean,
                                                      BuyerEmpCodes As IEnumerable(Of String),
                                                      LoadLockedOrders As Boolean,
                                                      LoadForMediaPlanOrWorksheet As Boolean) As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            'objects
            Dim MediaManagerDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)
            Dim SqlParameterCampaignIDList As New System.Data.SqlClient.SqlParameter("@CampaignIDList", SqlDbType.VarChar)
            Dim SqlParameterClientList As New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            Dim SqlParameterClientDivisionList As New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            Dim SqlParameterClientDivisionProductList As New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)
            Dim SqlParameterJobNumberList As New System.Data.SqlClient.SqlParameter("@JobNumberList", SqlDbType.VarChar)
            Dim SqlParameterJobNumberComponentNumberList As New System.Data.SqlClient.SqlParameter("@JobNumberComponentNumberList", SqlDbType.VarChar)
            Dim SqlParameterOrderNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberList", SqlDbType.VarChar)
            Dim SqlParameterOrderNumberLineNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)
            Dim SqlParameterOrderStatusList As New System.Data.SqlClient.SqlParameter("@OrderStatusList", SqlDbType.VarChar)
            Dim SqlParameterAEDefaultEmployeeCodeList As New System.Data.SqlClient.SqlParameter("@AEDefaultEmployeeCodeList", SqlDbType.VarChar)
            Dim SqlParameterAEJobEmployeeCodeList As New System.Data.SqlClient.SqlParameter("@AEJobEmployeeCodeList", SqlDbType.VarChar)
            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar)
            Dim SqlParameterUserLoadForProcessControl As New System.Data.SqlClient.SqlParameter("@LoadForProcessControl", SqlDbType.Bit)
            Dim SqlParameterVendorCodeList As New System.Data.SqlClient.SqlParameter("@VendorCodeList", SqlDbType.VarChar)
            Dim SqlParameterSelectForServiceRefresh As New System.Data.SqlClient.SqlParameter("@SelectForServiceRefresh", SqlDbType.Bit)
            Dim SqlParameterBuyerEmpCodeList As New System.Data.SqlClient.SqlParameter("@BuyerEmpCodeList", SqlDbType.VarChar)
            Dim SqlParameterLoadLockedOrders As New System.Data.SqlClient.SqlParameter("@LoadLockedOrders", SqlDbType.Bit)
            Dim SqlParameterLoadForMediaPlanOrWorksheet As New System.Data.SqlClient.SqlParameter("@LoadForMediaPlanOrWorksheet", SqlDbType.Bit)

            SqlParameterCampaignIDList.Value = If(CampaignIDList IsNot Nothing, String.Join(",", CampaignIDList.ToArray), System.DBNull.Value)
            SqlParameterClientList.Value = If(ClientCodeList IsNot Nothing, String.Join(",", ClientCodeList.ToArray), System.DBNull.Value)
            SqlParameterClientDivisionList.Value = If(ClientDivisionCodeList IsNot Nothing, String.Join(",", ClientDivisionCodeList.ToArray), System.DBNull.Value)
            SqlParameterClientDivisionProductList.Value = If(ClientDivisionCodeProductList IsNot Nothing, String.Join(",", ClientDivisionCodeProductList.ToArray), System.DBNull.Value)
            SqlParameterJobNumberList.Value = If(JobNumbers IsNot Nothing, String.Join(",", JobNumbers.ToArray), System.DBNull.Value)
            SqlParameterJobNumberComponentNumberList.Value = If(JobNumberComponentNumbers IsNot Nothing, String.Join(",", JobNumberComponentNumbers.ToArray), System.DBNull.Value)
            SqlParameterOrderNumberList.Value = If(OrderNumbers IsNot Nothing, String.Join(",", OrderNumbers.ToArray), System.DBNull.Value)
            SqlParameterOrderNumberLineNumberList.Value = If(OrderLines IsNot Nothing, String.Join(",", OrderLines.ToArray), System.DBNull.Value)
            SqlParameterOrderStatusList.Value = If(OrderStatuses IsNot Nothing, String.Join(",", OrderStatuses.ToArray), System.DBNull.Value)
            SqlParameterAEDefaultEmployeeCodeList.Value = If(AEDefaultEmployeeCodes IsNot Nothing, String.Join(",", AEDefaultEmployeeCodes.ToArray), System.DBNull.Value)
            SqlParameterAEJobEmployeeCodeList.Value = If(AEJobEmployeeCodes IsNot Nothing, String.Join(",", AEJobEmployeeCodes.ToArray), System.DBNull.Value)
            SqlParameterUserCode.Value = If(SelectForServiceRefresh, System.DBNull.Value, DbContext.UserCode)
            SqlParameterUserLoadForProcessControl.Value = LoadForProcessControl
            SqlParameterVendorCodeList.Value = If(VendorCodes IsNot Nothing, String.Join(",", VendorCodes.ToArray), System.DBNull.Value)
            SqlParameterSelectForServiceRefresh.Value = SelectForServiceRefresh
            SqlParameterBuyerEmpCodeList.Value = If(BuyerEmpCodes IsNot Nothing, String.Join(",", BuyerEmpCodes.ToArray), System.DBNull.Value)
            SqlParameterLoadLockedOrders.Value = LoadLockedOrders
            SqlParameterLoadForMediaPlanOrWorksheet.Value = LoadForMediaPlanOrWorksheet

            MediaManagerDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)("EXEC advsp_media_manager_load_review_details @CampaignIDList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @JobNumberList, @JobNumberComponentNumberList, @OrderNumberList, @OrderNumberLineNumberList, @OrderStatusList, @AEDefaultEmployeeCodeList, @AEJobEmployeeCodeList, @UserCode, @LoadForProcessControl, @VendorCodeList, @SelectForServiceRefresh, @BuyerEmpCodeList, @LoadLockedOrders, @LoadForMediaPlanOrWorksheet",
                SqlParameterCampaignIDList, SqlParameterClientList, SqlParameterClientDivisionList, SqlParameterClientDivisionProductList, SqlParameterJobNumberList,
                SqlParameterJobNumberComponentNumberList, SqlParameterOrderNumberList, SqlParameterOrderNumberLineNumberList, SqlParameterOrderStatusList, SqlParameterAEDefaultEmployeeCodeList,
                SqlParameterAEJobEmployeeCodeList, SqlParameterUserCode, SqlParameterUserLoadForProcessControl, SqlParameterVendorCodeList, SqlParameterSelectForServiceRefresh,
                SqlParameterBuyerEmpCodeList, SqlParameterLoadLockedOrders, SqlParameterLoadForMediaPlanOrWorksheet).ToList()

            LoadMediaManagerReviewDetails = MediaManagerDetails

        End Function
        Public Function LoadMediaManagerOrderHeaderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal OrderNumberList As IEnumerable(Of Integer)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)

            Dim MediaManagerOrderComments As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)
            Dim SqlParameterOrderNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberList", SqlDbType.VarChar)

            SqlParameterOrderNumberList.Value = If(OrderNumberList IsNot Nothing, String.Join(",", OrderNumberList.ToArray), System.DBNull.Value)

            MediaManagerOrderComments = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment)("EXEC advsp_media_manager_load_order_comments @OrderNumberList",
                                                                                                                                   SqlParameterOrderNumberList).ToList()

            LoadMediaManagerOrderHeaderComments = MediaManagerOrderComments

        End Function
        Public Function LoadMediaManagerOrderLineComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal OrderNumberLineNumberList As IEnumerable(Of String)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)

            Dim MediaManagerOrderLineComments As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)
            Dim SqlParameterOrderNumberLineNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)

            SqlParameterOrderNumberLineNumberList.Value = If(OrderNumberLineNumberList IsNot Nothing, String.Join(",", OrderNumberLineNumberList.ToArray), System.DBNull.Value)

            MediaManagerOrderLineComments = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment)("EXEC advsp_media_manager_load_order_line_comments @OrderNumberLineNumberList",
                                                                                                                                                 SqlParameterOrderNumberLineNumberList).ToList()

            LoadMediaManagerOrderLineComments = MediaManagerOrderLineComments

        End Function
        Public Function LoadMediaManagerOrderStatus(DbContext As AdvantageFramework.Database.DbContext, MediaFrom As String,
                                                    OrderNumber As Integer, OrderDescription As String,
                                                    LineNumbers As IEnumerable(Of Integer),
                                                    TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset) As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus)

            'objects
            Dim MediaManagerOrderStatusList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus) = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing

            MediaManagerOrderStatusList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus)

            Select Case MediaFrom.Substring(0, 1)

                Case "I"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset))

                Case "M"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset))

                Case "N"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset))

                Case "O"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset))

                Case "R"

                    RadioOrderDetails = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset, RadioOrderDetails))

                Case "T"

                    TVOrderDetails = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberLines(DbContext, OrderNumber, LineNumbers).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, OrderDescription, TimezoneOffset, TVOrderDetails))

            End Select

            LoadMediaManagerOrderStatus = MediaManagerOrderStatusList.OrderBy(Function(MMOS) MMOS.LineNumber).ThenByDescending(Function(MMOS) MMOS.RevisedDate).ThenBy(Function(MMOS) MMOS.OrderStatusDescription).ToList

        End Function
        Public Function LoadMediaManagerOrderStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal OrderType As String, ByVal OrderNumber As Integer, ByVal LineNumber As Short,
                                                    Optional ByVal TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset = Nothing) As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus)

            'objects
            Dim MediaManagerOrderStatusList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus) = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing

            MediaManagerOrderStatusList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus)

            If TimezoneOffset Is Nothing Then

                TimezoneOffset = AdvantageFramework.VCC.GetTimezoneOffset(DbContext)

            End If

            Select Case OrderType

                Case "1"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset))

                Case "2"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset))

                Case "3"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset))

                Case "4"

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset))

                Case "5"

                    RadioOrderDetails = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset, RadioOrderDetails))

                Case "6"

                    TVOrderDetails = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

                    MediaManagerOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, LineNumber).Include("OrderStatus").ToList
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerOrderStatus(OS, Nothing, TimezoneOffset, TVOrderDetails))

            End Select

            LoadMediaManagerOrderStatus = MediaManagerOrderStatusList

        End Function
        Public Function LoadMediaManagerPurchaseOrderStatus(DbContext As AdvantageFramework.Database.DbContext,
                                                            MediaManagerPODetail As AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail,
                                                            PONumbers As IEnumerable(Of Integer),
                                                            TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset) As IEnumerable(Of AdvantageFramework.MediaManager.Classes.MediaManagerPurchaseOrderStatus)

            Dim MediaManagerPurchaseOrderStatusList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerPurchaseOrderStatus) = Nothing

            MediaManagerPurchaseOrderStatusList = New Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerPurchaseOrderStatus)

            MediaManagerPurchaseOrderStatusList.AddRange(From OS In AdvantageFramework.Database.Procedures.PurchaseOrderStatus.Load(DbContext).Include("OrderStatus").ToList
                                                         Where OS.PONumber = MediaManagerPODetail.PONumber
                                                         Select New AdvantageFramework.MediaManager.Classes.MediaManagerPurchaseOrderStatus(OS, MediaManagerPODetail.PODescription, TimezoneOffset))

            LoadMediaManagerPurchaseOrderStatus = MediaManagerPurchaseOrderStatusList.OrderByDescending(Function(Entity) Entity.RevisedDate).ThenBy(Function(Entity) Entity.OrderStatusDescription).ToList

        End Function
        Public Sub SaveOrderLineComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal MediaManagerOrderLineCommentList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderLineComment))

            For Each MediaManagerOrderLineComment In MediaManagerOrderLineCommentList

                Select Case MediaManagerOrderLineComment.OrderType

                    Case "I"

                        SaveInternetComment(DbContext, MediaManagerOrderLineComment)

                    Case "M"

                        SaveMagazineComment(DbContext, MediaManagerOrderLineComment)

                    Case "N"

                        SaveNewspaperComment(DbContext, MediaManagerOrderLineComment)

                    Case "O"

                        SaveOutOfHomeComment(DbContext, MediaManagerOrderLineComment)

                    Case "R"

                        SaveRadioComment(DbContext, MediaManagerOrderLineComment)

                    Case "T"

                        SaveTVComment(DbContext, MediaManagerOrderLineComment)

                End Select

            Next

        End Sub
        Public Sub SaveOrderComments(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal MediaManagerOrderCommentList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerOrderComment))

            For Each MediaManagerOrderComment In MediaManagerOrderCommentList

                Select Case MediaManagerOrderComment.OrderType

                    Case "I"

                        SaveInternetOrderComments(DbContext, MediaManagerOrderComment)

                    Case "M"

                        SaveMagazineOrderComments(DbContext, MediaManagerOrderComment)

                    Case "N"

                        SaveNewspaperOrderComments(DbContext, MediaManagerOrderComment)

                    Case "O"

                        SaveOutOfHomeOrderComments(DbContext, MediaManagerOrderComment)

                    Case "R"

                        SaveRadioOrderComments(DbContext, MediaManagerOrderComment)

                    Case "T"

                        SaveTVOrderComments(DbContext, MediaManagerOrderComment)

                End Select

            Next

        End Sub
        Public Function CreateAPImportStagingInvoices(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail),
                                                      ByVal GroupVendorsOnSameInvoice As Boolean,
                                                      ByRef BatchName As String) As Boolean

            Dim Created As Boolean = False
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim GetOptionDefaultAPDescriptionFromVendorAccount As Boolean = False
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim ImportAccountPayable As AdvantageFramework.Database.Entities.ImportAccountPayable = Nothing
            Dim SqlParameterBatchName As SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As SqlClient.SqlParameter = Nothing

            ImportTemplate = (From Entity In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic)
                              Where Entity.IsSystemTemplate = True AndAlso
                                    Entity.Name = "Advantage Generic CSV"
                              Select Entity).SingleOrDefault

            If ImportTemplate IsNot Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                    GetOptionDefaultAPDescriptionFromVendorAccount = AdvantageFramework.Agency.GetOptionDefaultAPDescriptionFromVendorAccount(DataContext)

                End Using

                BatchName = "Media Manager " & Format(CInt(Now.Month), "0#") & Format(CInt(Now.Day), "0#") & Format(CInt(Now.Year), "000#") & Format(CInt(Now.Hour), "0#") & Format(CInt(Now.Minute), "0#") & Format(CInt(Now.Second), "0#") & " " & Mid(DbContext.UserCode, 1, 20)

                Using TransactionScope As New System.Transactions.TransactionScope()

                    If GroupVendorsOnSameInvoice Then

                        VendorCodes = (From MMRD In MediaManagerReviewDetailList
                                       Select MMRD.VendorCode).Distinct.ToList

                        For Each VendorCode In VendorCodes

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                            If Vendor IsNot Nothing Then

                                ImportAccountPayable = CreateImportAccountPayable(DbContext, BatchName, Vendor, GetOptionDefaultAPDescriptionFromVendorAccount, MediaManagerReviewDetailList.Where(Function(MMRD) MMRD.VendorCode = VendorCode).Sum(Function(MMRD) MMRD.NetAmount.GetValueOrDefault(0) + MMRD.NonResaleTax.GetValueOrDefault(0) + MMRD.DiscountAmount.GetValueOrDefault(0) + MMRD.NetChargeAmount.GetValueOrDefault(0)), ImportTemplate.ID, Now.ToShortDateString & " " & Vendor.Code, Now.ToShortDateString)

                                If AdvantageFramework.Database.Procedures.ImportAccountPayable.Insert(DbContext, ImportAccountPayable) Then

                                    InsertImportAccountPayableMediaDetails(DbContext, MediaManagerReviewDetailList.Where(Function(MMRD) MMRD.VendorCode = VendorCode).ToList, ImportAccountPayable.ID)

                                Else

                                    Throw New Exception("Failed inserting into IMP_AP_HEADER.")

                                End If

                            Else

                                Throw New Exception("Cannot find vendor: " & VendorCode)

                            End If

                        Next

                    Else

                        For Each MediaManagerReviewDetail In MediaManagerReviewDetailList

                            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaManagerReviewDetail.VendorCode)

                            If Vendor IsNot Nothing Then

                                ImportAccountPayable = CreateImportAccountPayable(DbContext, BatchName, Vendor, GetOptionDefaultAPDescriptionFromVendorAccount, MediaManagerReviewDetail.NetAmount.GetValueOrDefault(0) + MediaManagerReviewDetail.NonResaleTax.GetValueOrDefault(0) + MediaManagerReviewDetail.DiscountAmount.GetValueOrDefault(0) + MediaManagerReviewDetail.NetChargeAmount.GetValueOrDefault(0), ImportTemplate.ID, MediaManagerReviewDetail.OrderNumber & "/" & MediaManagerReviewDetail.LineNumber & " " & MediaManagerReviewDetail.StartDate.Value.ToShortDateString, MediaManagerReviewDetail.StartDate.Value)

                                If AdvantageFramework.Database.Procedures.ImportAccountPayable.Insert(DbContext, ImportAccountPayable) Then

                                    InsertImportAccountPayableMediaDetail(DbContext, MediaManagerReviewDetail, ImportAccountPayable.ID)

                                Else

                                    Throw New Exception("Failed inserting into IMP_AP_HEADER.")

                                End If

                            Else

                                Throw New Exception("Cannot find vendor: " & MediaManagerReviewDetail.VendorCode)

                            End If

                        Next

                    End If

                    SqlParameterBatchName = New SqlClient.SqlParameter("@batch_name", SqlDbType.VarChar)
                    SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

                    SqlParameterBatchName.Value = BatchName
                    SqlParameterUserCode.Value = DbContext.UserCode

                    DbContext.Database.ExecuteSqlCommand("exec advsp_ap_import_validate_staging_tables @batch_name, @user_code", SqlParameterBatchName, SqlParameterUserCode)

                    TransactionScope.Complete()

                    Created = True

                End Using

            Else

                Throw New Exception("Cannot generic AP Import template 'Advantage Generic CSV'.")

            End If

            CreateAPImportStagingInvoices = Created

        End Function
        Public Sub CreateBillingApprovals(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail))

            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each MediaManagerReviewDetail In MediaManagerReviewDetailList

                    If Not MediaManagerReviewDetail.HasBillingApprovalStatus Then

                        Select Case MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

                            Case "I"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus
                                    InternetOrderStatus.DbContext = DbContext

                                    InternetOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    InternetOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    InternetOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    InternetOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    InternetOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    InternetOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    InternetOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.InternetOrderStatus.Insert(DbContext, InternetOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.InternetOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                            Case "M"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus
                                    MagazineOrderStatus.DbContext = DbContext

                                    MagazineOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    MagazineOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    MagazineOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    MagazineOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    MagazineOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    MagazineOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    MagazineOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.MagazineOrderStatus.Insert(DbContext, MagazineOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.MagazineOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                            Case "N"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus
                                    NewspaperOrderStatus.DbContext = DbContext

                                    NewspaperOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    NewspaperOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    NewspaperOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    NewspaperOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    NewspaperOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    NewspaperOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    NewspaperOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Insert(DbContext, NewspaperOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.NewspaperOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                            Case "O"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus
                                    OutOfHomeOrderStatus.DbContext = DbContext

                                    OutOfHomeOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    OutOfHomeOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    OutOfHomeOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    OutOfHomeOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    OutOfHomeOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    OutOfHomeOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    OutOfHomeOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Insert(DbContext, OutOfHomeOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                            Case "R"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus
                                    RadioOrderStatus.DbContext = DbContext

                                    RadioOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    RadioOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    RadioOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    RadioOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    RadioOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    RadioOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    RadioOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.RadioOrderStatus.Insert(DbContext, RadioOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                            Case "T"

                                If Not (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                        Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                              Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                        Select Entity).Any Then

                                    TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus
                                    TVOrderStatus.DbContext = DbContext

                                    TVOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                                    TVOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                                    TVOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                                    TVOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                    TVOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                                    TVOrderStatus.RevisedByUserCode = DbContext.UserCode
                                    TVOrderStatus.RevisedByName = Session.EmployeeName

                                    AdvantageFramework.Database.Procedures.TVOrderStatus.Insert(DbContext, TVOrderStatus)

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " & Session.UserCode

                                Else

                                    MediaManagerReviewDetail.BillingApprovedDateBy = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext).ToShortDateString & " " &
                                        (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)
                                         Where Entity.RevisionNumber = MediaManagerReviewDetail.RevisionNumber AndAlso
                                               Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.ApprovedForBilling
                                         Select Entity).FirstOrDefault.RevisedByUserCode

                                End If

                        End Select

                        MediaManagerReviewDetail.HasBillingApprovalStatus = True

                    End If

                Next

            End Using

        End Sub
        Public Sub DeleteBillingApprovals(ByVal Session As AdvantageFramework.Security.Session, ByVal MediaManagerReviewDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail))

            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each MediaManagerReviewDetail In MediaManagerReviewDetailList

                    If MediaManagerReviewDetail.HasBillingApprovalStatus Then

                        Select Case MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

                            Case "I"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.INTERNET_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                            Case "M"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.MAGAZINE_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                            Case "N"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.NEWSPAPER_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                            Case "O"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.OUTDOOR_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                            Case "R"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                            Case "T"

                                DbContext.Database.ExecuteSqlCommand("DELETE dbo.TV_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND STATUS = 11", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)

                        End Select

                        MediaManagerReviewDetail.HasBillingApprovalStatus = False
                        MediaManagerReviewDetail.BillingApprovedDateBy = Nothing

                    End If

                Next

            End Using

        End Sub
        Public Function LoadBroadcastOrder(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As String, ByVal MediaFrom As String,
                                           Optional ShowEmptyWeeks As Boolean = False, Optional ExchangeRate As Nullable(Of Decimal) = Nothing) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", DbContext.UserCode)
            Dim OrderNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@OrderNumber", OrderNumber)
            Dim LineNumbersParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@LineNumbers", LineNumbers)
            Dim MediaFromParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@MediaFrom", MediaFrom)
            Dim ShowEmptyWeeksParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ShowEmptyWeeks", ShowEmptyWeeks)
            Dim ExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRate", If(ExchangeRate.HasValue = False, 1, ExchangeRate))

            LoadBroadcastOrder = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.BroadcastOrder)("EXEC dbo.advsp_media_manager_load_broadcast_order @UserCode, @OrderNumber, @LineNumbers, @MediaFrom, @ShowEmptyWeeks, @ExchangeRate", UserCodeParameter, OrderNumberParameter, LineNumbersParameter, MediaFromParameter, ShowEmptyWeeksParameter, ExchangeRateParameter)

        End Function
        Public Function LoadPrintOrder(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As String, ByVal MediaFrom As String, Optional ExchangeRate As Nullable(Of Decimal) = Nothing) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.MediaManager.Classes.PrintOrder)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", DbContext.UserCode)
            Dim OrderNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@OrderNumber", OrderNumber)
            Dim LineNumbersParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@LineNumbers", LineNumbers)
            Dim MediaFromParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@MediaFrom", MediaFrom)
            Dim ExchangeRateParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@ExchangeRate", If(ExchangeRate.HasValue = False, 1, ExchangeRate))

            LoadPrintOrder = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.PrintOrder)("EXEC dbo.advsp_media_manager_load_print_order @UserCode, @OrderNumber, @LineNumbers, @MediaFrom, @ExchangeRate", UserCodeParameter, OrderNumberParameter, LineNumbersParameter, MediaFromParameter, ExchangeRateParameter)

        End Function
        Public Function LoadEnhancedInternetOrderReport(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OrderNumber As Integer, ByVal LineNumbers As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport)

            Dim UserCodeParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", DbContext.UserCode)
            Dim OrderNumberParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@OrderNumber", OrderNumber)
            Dim LineNumbersParameter As System.Data.SqlClient.SqlParameter = New System.Data.SqlClient.SqlParameter("@LineNumbers", LineNumbers)

            LoadEnhancedInternetOrderReport = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.InternetOrderReport)("EXEC dbo.advsp_media_manager_load_internet_order_report @UserCode, @OrderNumber, @LineNumbers", UserCodeParameter, OrderNumberParameter, LineNumbersParameter)

        End Function
        Public Function LoadVendorReps(Session As AdvantageFramework.Security.Session, VendorCode As String, OrderNumber As Integer) As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorRep)

            Dim VendorReps As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorRep) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                VendorReps = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.VendorRep)(String.Format("exec dbo.advsp_media_manager_load_vendor_reps '{0}', {1}", VendorCode, OrderNumber)).ToList

            End Using

            LoadVendorReps = VendorReps

        End Function
        Public Function ReviseOrder(ByVal Session As AdvantageFramework.Security.Session, ByVal CalculateOnly As Boolean,
                                    ByRef MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                    ByRef ErrorMessage As String,
                                    Optional ByVal ReviseOrderTo As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.DoNotReviseAmount) As Boolean

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterUserId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAmount As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAmountSource As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCalculateOnly As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAddlCharge As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterForceRevision As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterNewOrderDescription As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewClientPO As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewBuyer As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewBuyerEmpCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewEndDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewCloseDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMaterialCloseDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewExtCloseDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewExtMatlCloseDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewDateToBill As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAdNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewCampaignID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMarketCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMarkupPct As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewRebatePct As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewProgramming As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewRemarks As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewStartTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewEndTime As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewLength As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewHeadline As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewAdSizeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMaterial As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetPlacement1 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetPlacement2 As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetURL As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewInternetTargetAudience As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewEditionIssue As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewProductionSize As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMGCirculation As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewSection As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewPrintColumns As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewPrintInches As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewPrintLines As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewRateType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewNPCirculation As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewCopyArea As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewLocation As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewOutdoorType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewRate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewNetcharge As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewBillCoopCode As System.Data.SqlClient.SqlParameter = Nothing
            'Dim SqlParameterNewSpots As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewCostType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewProjImpressions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewGuaranteedImpress As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewActualImpressions As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNewMatCompDate As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterRateOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNonresaleOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRebateOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCommissionOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBillableAmtOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUnbilledAmountOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterActualImpressionsOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNetAmountOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterGrossAmountOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNetchargeOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDiscountOut As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEndDateOut As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterRetval As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetvalString As System.Data.SqlClient.SqlParameter = Nothing
            Dim Okay As Boolean = False

            SqlParameterUserId = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr_in", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr_in", SqlDbType.SmallInt)
            SqlParameterOrderType = New System.Data.SqlClient.SqlParameter("@order_type_in", SqlDbType.VarChar)
            SqlParameterNewAmount = New System.Data.SqlClient.SqlParameter("@new_amount", SqlDbType.Decimal)
            SqlParameterNewAmountSource = New System.Data.SqlClient.SqlParameter("@new_amt_source", SqlDbType.SmallInt)
            SqlParameterCalculateOnly = New System.Data.SqlClient.SqlParameter("@calculate_only", SqlDbType.Bit)
            SqlParameterNewAddlCharge = New System.Data.SqlClient.SqlParameter("@new_addl_charge", SqlDbType.Decimal)
            SqlParameterForceRevision = New System.Data.SqlClient.SqlParameter("@force_revision", SqlDbType.Bit)

            SqlParameterNewOrderDescription = New System.Data.SqlClient.SqlParameter("@new_order_description", SqlDbType.VarChar)
            SqlParameterNewClientPO = New System.Data.SqlClient.SqlParameter("@new_client_po_number", SqlDbType.VarChar)
            SqlParameterNewBuyer = New System.Data.SqlClient.SqlParameter("@new_buyer", SqlDbType.VarChar)
            SqlParameterNewBuyerEmpCode = New System.Data.SqlClient.SqlParameter("@new_buyer_emp_code", SqlDbType.VarChar)
            SqlParameterNewStartDate = New System.Data.SqlClient.SqlParameter("@new_start_date", SqlDbType.SmallDateTime)
            SqlParameterNewEndDate = New System.Data.SqlClient.SqlParameter("@new_end_date", SqlDbType.SmallDateTime)
            SqlParameterNewCloseDate = New System.Data.SqlClient.SqlParameter("@new_close_date", SqlDbType.SmallDateTime)
            SqlParameterNewMaterialCloseDate = New System.Data.SqlClient.SqlParameter("@new_matl_close_date", SqlDbType.SmallDateTime)
            SqlParameterNewExtCloseDate = New System.Data.SqlClient.SqlParameter("@new_ext_close_date", SqlDbType.SmallDateTime)
            SqlParameterNewExtMatlCloseDate = New System.Data.SqlClient.SqlParameter("@new_ext_matl_date", SqlDbType.SmallDateTime)
            SqlParameterNewDateToBill = New System.Data.SqlClient.SqlParameter("@new_date_to_bill", SqlDbType.SmallDateTime)
            SqlParameterNewAdNumber = New System.Data.SqlClient.SqlParameter("@new_ad_number", SqlDbType.VarChar)
            SqlParameterNewCampaignID = New System.Data.SqlClient.SqlParameter("@new_campaign_id", SqlDbType.Int)
            SqlParameterNewJobNumber = New System.Data.SqlClient.SqlParameter("@new_job_number", SqlDbType.Int)
            SqlParameterNewJobComponentNumber = New System.Data.SqlClient.SqlParameter("@new_job_component_nbr", SqlDbType.SmallInt)
            SqlParameterNewMarketCode = New System.Data.SqlClient.SqlParameter("@new_market_code", SqlDbType.VarChar)
            SqlParameterNewMarkupPct = New System.Data.SqlClient.SqlParameter("@new_markup_percent", SqlDbType.Decimal)
            SqlParameterNewRebatePct = New System.Data.SqlClient.SqlParameter("@new_rebate_percent", SqlDbType.Decimal)
            SqlParameterNewProgramming = New System.Data.SqlClient.SqlParameter("@new_programming", SqlDbType.VarChar)
            SqlParameterNewRemarks = New System.Data.SqlClient.SqlParameter("@new_remarks", SqlDbType.VarChar)
            SqlParameterNewStartTime = New System.Data.SqlClient.SqlParameter("@new_start_time", SqlDbType.VarChar)
            SqlParameterNewEndTime = New System.Data.SqlClient.SqlParameter("@new_end_time", SqlDbType.VarChar)
            SqlParameterNewLength = New System.Data.SqlClient.SqlParameter("@new_length", SqlDbType.SmallInt)
            SqlParameterNewHeadline = New System.Data.SqlClient.SqlParameter("@new_headline", SqlDbType.VarChar)
            SqlParameterNewAdSizeCode = New System.Data.SqlClient.SqlParameter("@new_ad_size_code", SqlDbType.VarChar)
            SqlParameterNewMaterial = New System.Data.SqlClient.SqlParameter("@new_material", SqlDbType.VarChar)
            SqlParameterNewInternetPlacement1 = New System.Data.SqlClient.SqlParameter("@new_internet_placement1", SqlDbType.VarChar)
            SqlParameterNewInternetPlacement2 = New System.Data.SqlClient.SqlParameter("@new_internet_placement2", SqlDbType.VarChar)
            SqlParameterNewInternetType = New System.Data.SqlClient.SqlParameter("@new_internet_type", SqlDbType.VarChar)
            SqlParameterNewInternetURL = New System.Data.SqlClient.SqlParameter("@new_url", SqlDbType.VarChar)
            SqlParameterNewInternetTargetAudience = New System.Data.SqlClient.SqlParameter("@new_target_audience", SqlDbType.VarChar)
            SqlParameterNewEditionIssue = New System.Data.SqlClient.SqlParameter("@new_edition_issue", SqlDbType.VarChar)
            SqlParameterNewProductionSize = New System.Data.SqlClient.SqlParameter("@new_production_size", SqlDbType.VarChar)
            SqlParameterNewMGCirculation = New System.Data.SqlClient.SqlParameter("@new_mg_circulation", SqlDbType.Int)
            SqlParameterNewSection = New System.Data.SqlClient.SqlParameter("@new_section", SqlDbType.VarChar)
            SqlParameterNewPrintColumns = New System.Data.SqlClient.SqlParameter("@new_print_columns", SqlDbType.Decimal)
            SqlParameterNewPrintInches = New System.Data.SqlClient.SqlParameter("@new_print_inches", SqlDbType.Decimal)
            SqlParameterNewPrintLines = New System.Data.SqlClient.SqlParameter("@new_print_lines", SqlDbType.Decimal)
            SqlParameterNewRateType = New System.Data.SqlClient.SqlParameter("@new_rate_type", SqlDbType.VarChar)
            SqlParameterNewNPCirculation = New System.Data.SqlClient.SqlParameter("@new_np_circulation", SqlDbType.Int)
            SqlParameterNewCopyArea = New System.Data.SqlClient.SqlParameter("@new_copy_area", SqlDbType.VarChar)
            SqlParameterNewLocation = New System.Data.SqlClient.SqlParameter("@new_location", SqlDbType.VarChar)
            SqlParameterNewOutdoorType = New System.Data.SqlClient.SqlParameter("@new_outdoor_type", SqlDbType.VarChar)
            SqlParameterNewRate = New System.Data.SqlClient.SqlParameter("@new_rate", SqlDbType.Decimal)
            SqlParameterNewNetcharge = New System.Data.SqlClient.SqlParameter("@new_netcharge", SqlDbType.Decimal)
            SqlParameterNewBillCoopCode = New System.Data.SqlClient.SqlParameter("@new_bill_coop_code", SqlDbType.VarChar)
            'SqlParameterNewSpots = New System.Data.SqlClient.SqlParameter("@new_spots", SqlDbType.SmallInt)
            SqlParameterNewCostType = New System.Data.SqlClient.SqlParameter("@new_cost_type", SqlDbType.VarChar)
            SqlParameterNewProjImpressions = New System.Data.SqlClient.SqlParameter("@new_proj_impressions", SqlDbType.Int)
            SqlParameterNewGuaranteedImpress = New System.Data.SqlClient.SqlParameter("@new_guaranteed_impress", SqlDbType.Int)
            SqlParameterNewActualImpressions = New System.Data.SqlClient.SqlParameter("@new_actual_impressions", SqlDbType.Int)
            SqlParameterNewMatCompDate = New System.Data.SqlClient.SqlParameter("@new_mat_comp_date", SqlDbType.SmallDateTime)

            SqlParameterRateOut = New System.Data.SqlClient.SqlParameter("@rate_out", SqlDbType.Decimal)
            SqlParameterRateOut.Direction = ParameterDirection.Output
            SqlParameterRateOut.Precision = 16
            SqlParameterRateOut.Scale = 4
            SqlParameterRateOut.Value = MediaManagerReviewDetail.Rate.GetValueOrDefault(0)

            SqlParameterNonresaleOut = New System.Data.SqlClient.SqlParameter("@nonresale_tax_out", SqlDbType.Decimal)
            SqlParameterNonresaleOut.Direction = ParameterDirection.Output
            SqlParameterNonresaleOut.Precision = 16
            SqlParameterNonresaleOut.Scale = 2
            SqlParameterNonresaleOut.Value = MediaManagerReviewDetail.NonResaleTax.GetValueOrDefault(0)

            SqlParameterRebateOut = New System.Data.SqlClient.SqlParameter("@rebate_amount_out", SqlDbType.Decimal)
            SqlParameterRebateOut.Direction = ParameterDirection.Output
            SqlParameterRebateOut.Precision = 16
            SqlParameterRebateOut.Scale = 2
            SqlParameterRebateOut.Value = MediaManagerReviewDetail.RebateAmount.GetValueOrDefault(0)

            SqlParameterCommissionOut = New System.Data.SqlClient.SqlParameter("@commission_amount_out", SqlDbType.Decimal)
            SqlParameterCommissionOut.Direction = ParameterDirection.Output
            SqlParameterCommissionOut.Precision = 16
            SqlParameterCommissionOut.Scale = 2
            SqlParameterCommissionOut.Value = MediaManagerReviewDetail.CommissionAmount.GetValueOrDefault(0)

            SqlParameterBillableAmtOut = New System.Data.SqlClient.SqlParameter("@billable_amount_out", SqlDbType.Decimal)
            SqlParameterBillableAmtOut.Direction = ParameterDirection.Output
            SqlParameterBillableAmtOut.Precision = 16
            SqlParameterBillableAmtOut.Scale = 2
            SqlParameterBillableAmtOut.Value = MediaManagerReviewDetail.BillableAmount

            SqlParameterUnbilledAmountOut = New System.Data.SqlClient.SqlParameter("@unbilled_amount_out", SqlDbType.Decimal)
            SqlParameterUnbilledAmountOut.Direction = ParameterDirection.Output
            SqlParameterUnbilledAmountOut.Precision = 16
            SqlParameterUnbilledAmountOut.Scale = 2
            SqlParameterUnbilledAmountOut.Value = MediaManagerReviewDetail.UnbilledTotal.GetValueOrDefault(0)

            SqlParameterActualImpressionsOut = New System.Data.SqlClient.SqlParameter("@actual_impressions_out", SqlDbType.Int)
            SqlParameterActualImpressionsOut.Direction = ParameterDirection.Output
            SqlParameterActualImpressionsOut.Value = MediaManagerReviewDetail.ActualImpressions.GetValueOrDefault(0)

            SqlParameterNetAmountOut = New System.Data.SqlClient.SqlParameter("@net_amount_out", SqlDbType.Decimal)
            SqlParameterNetAmountOut.Direction = ParameterDirection.Output
            SqlParameterNetAmountOut.Precision = 16
            SqlParameterNetAmountOut.Scale = 2
            SqlParameterNetAmountOut.Value = MediaManagerReviewDetail.NetAmount.GetValueOrDefault(0)

            SqlParameterGrossAmountOut = New System.Data.SqlClient.SqlParameter("@gross_amount_out", SqlDbType.Decimal)
            SqlParameterGrossAmountOut.Direction = ParameterDirection.Output
            SqlParameterGrossAmountOut.Precision = 16
            SqlParameterGrossAmountOut.Scale = 2
            SqlParameterGrossAmountOut.Value = MediaManagerReviewDetail.GrossAmount.GetValueOrDefault(0)

            SqlParameterNetchargeOut = New System.Data.SqlClient.SqlParameter("@netcharge_out", SqlDbType.Decimal)
            SqlParameterNetchargeOut.Direction = ParameterDirection.Output
            SqlParameterNetchargeOut.Precision = 16
            SqlParameterNetchargeOut.Scale = 2
            SqlParameterNetchargeOut.Value = MediaManagerReviewDetail.NetChargeAmount.GetValueOrDefault(0)

            SqlParameterDiscountOut = New System.Data.SqlClient.SqlParameter("@discount_out", SqlDbType.Decimal)
            SqlParameterDiscountOut.Direction = ParameterDirection.Output
            SqlParameterDiscountOut.Precision = 16
            SqlParameterDiscountOut.Scale = 2
            SqlParameterDiscountOut.Value = MediaManagerReviewDetail.DiscountAmount.GetValueOrDefault(0)

            SqlParameterEndDateOut = New System.Data.SqlClient.SqlParameter("@end_date_out", SqlDbType.SmallDateTime)
            SqlParameterEndDateOut.Direction = ParameterDirection.Output
            SqlParameterEndDateOut.Value = If(MediaManagerReviewDetail.EndDate.HasValue, MediaManagerReviewDetail.EndDate.Value, System.DBNull.Value)

            SqlParameterRetval = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.Int)
            SqlParameterRetval.Direction = ParameterDirection.Output
            SqlParameterRetval.Value = 0

            SqlParameterRetvalString = New System.Data.SqlClient.SqlParameter("@ret_val_s", SqlDbType.VarChar, -1)
            SqlParameterRetvalString.Direction = ParameterDirection.Output
            SqlParameterRetvalString.Value = ""

            SqlParameterUserId.Value = Session.UserCode
            SqlParameterOrderNumber.Value = MediaManagerReviewDetail.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerReviewDetail.LineNumber
            SqlParameterOrderType.Value = MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

            If ReviseOrderTo = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.DoNotReviseAmount Then

                If MediaManagerReviewDetail.NetGross = "Net" Then

                    SqlParameterNewAmount.Value = MediaManagerReviewDetail.NetAmount.GetValueOrDefault(0)

                Else

                    SqlParameterNewAmount.Value = MediaManagerReviewDetail.GrossAmount.GetValueOrDefault(0)

                End If

            ElseIf ReviseOrderTo = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.ActualAmountPosted Then

                SqlParameterNewAmount.Value = MediaManagerReviewDetail.ActualAmountPosted.Value

            ElseIf ReviseOrderTo = AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.VendorCollected Then

                SqlParameterNewAmount.Value = MediaManagerReviewDetail.VendorCollected.Value

            End If

            SqlParameterNewAmountSource.Value = CShort(ReviseOrderTo)

            SqlParameterCalculateOnly.Value = If(CalculateOnly, 1, 0)

            SqlParameterNewAddlCharge.Value = MediaManagerReviewDetail.AdditionalChargeAmount.GetValueOrDefault(0)
            SqlParameterForceRevision.Value = If(MediaManagerReviewDetail.ForceRevision, 1, 0)

            SqlParameterNewOrderDescription.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.OrderDescription), System.DBNull.Value, MediaManagerReviewDetail.OrderDescription)

            SqlParameterNewClientPO.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.ClientPO), System.DBNull.Value, MediaManagerReviewDetail.ClientPO)

            SqlParameterNewBuyer.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.Buyer), System.DBNull.Value, MediaManagerReviewDetail.Buyer)
            SqlParameterNewBuyerEmpCode.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BuyerEmployeeCode), System.DBNull.Value, MediaManagerReviewDetail.BuyerEmployeeCode)
            SqlParameterNewStartDate.Value = MediaManagerReviewDetail.StartDate.Value
            SqlParameterNewEndDate.Value = If(MediaManagerReviewDetail.EndDate.HasValue, MediaManagerReviewDetail.EndDate.Value, System.DBNull.Value)

            SqlParameterNewCloseDate.Value = If(MediaManagerReviewDetail.CloseDate.HasValue, MediaManagerReviewDetail.CloseDate, System.DBNull.Value)
            SqlParameterNewMaterialCloseDate.Value = If(MediaManagerReviewDetail.MaterialDate.HasValue, MediaManagerReviewDetail.MaterialDate, System.DBNull.Value)
            SqlParameterNewExtCloseDate.Value = If(MediaManagerReviewDetail.ExtendedCloseDate.HasValue, MediaManagerReviewDetail.ExtendedCloseDate, System.DBNull.Value)
            SqlParameterNewExtMatlCloseDate.Value = If(MediaManagerReviewDetail.ExtendedMaterialDate.HasValue, MediaManagerReviewDetail.ExtendedMaterialDate, System.DBNull.Value)

            SqlParameterNewDateToBill.Value = If(MediaManagerReviewDetail.DateToBill.HasValue, MediaManagerReviewDetail.DateToBill, System.DBNull.Value)
            SqlParameterNewAdNumber.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.AdNumber), System.DBNull.Value, MediaManagerReviewDetail.AdNumber)
            SqlParameterNewCampaignID.Value = If(MediaManagerReviewDetail.CampaignID.HasValue, MediaManagerReviewDetail.CampaignID, System.DBNull.Value)
            SqlParameterNewJobNumber.Value = If(MediaManagerReviewDetail.JobNumber.HasValue, MediaManagerReviewDetail.JobNumber, System.DBNull.Value)
            SqlParameterNewJobComponentNumber.Value = If(MediaManagerReviewDetail.JobComponentNumber.HasValue, MediaManagerReviewDetail.JobComponentNumber, System.DBNull.Value)
            SqlParameterNewMarketCode.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.MarketCode), System.DBNull.Value, MediaManagerReviewDetail.MarketCode)
            SqlParameterNewMarkupPct.Value = If(MediaManagerReviewDetail.MarkupPercent.HasValue, MediaManagerReviewDetail.MarkupPercent, System.DBNull.Value)
            SqlParameterNewRebatePct.Value = If(MediaManagerReviewDetail.RebatePercent.HasValue, MediaManagerReviewDetail.RebatePercent, System.DBNull.Value)
            SqlParameterNewProgramming.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BroadcastProgramming), System.DBNull.Value, MediaManagerReviewDetail.BroadcastProgramming)
            SqlParameterNewRemarks.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BroadcastRemarks), System.DBNull.Value, MediaManagerReviewDetail.BroadcastRemarks)
            SqlParameterNewStartTime.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BroadcastStartTime), System.DBNull.Value, MediaManagerReviewDetail.BroadcastStartTime)
            SqlParameterNewEndTime.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BroadcastEndTime), System.DBNull.Value, MediaManagerReviewDetail.BroadcastEndTime)
            SqlParameterNewLength.Value = If(MediaManagerReviewDetail.BroadcastLength.HasValue, MediaManagerReviewDetail.BroadcastLength, System.DBNull.Value)
            SqlParameterNewHeadline.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.Headline), System.DBNull.Value, MediaManagerReviewDetail.Headline)
            SqlParameterNewAdSizeCode.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.AdSizeCode), System.DBNull.Value, MediaManagerReviewDetail.AdSizeCode)
            SqlParameterNewMaterial.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.Material), System.DBNull.Value, MediaManagerReviewDetail.Material)
            SqlParameterNewInternetPlacement1.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetPlacement1), System.DBNull.Value, MediaManagerReviewDetail.InternetPlacement1)
            SqlParameterNewInternetPlacement2.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetPlacement2), System.DBNull.Value, MediaManagerReviewDetail.InternetPlacement2)
            SqlParameterNewInternetType.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetType), System.DBNull.Value, MediaManagerReviewDetail.InternetType)
            SqlParameterNewInternetURL.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetURL), System.DBNull.Value, MediaManagerReviewDetail.InternetURL)
            SqlParameterNewInternetTargetAudience.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetTargetAudience), System.DBNull.Value, MediaManagerReviewDetail.InternetTargetAudience)

            SqlParameterNewEditionIssue.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.Issue), System.DBNull.Value, MediaManagerReviewDetail.Issue)
            SqlParameterNewProductionSize.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.ProductionSize), System.DBNull.Value, MediaManagerReviewDetail.ProductionSize)
            SqlParameterNewMGCirculation.Value = If(MediaManagerReviewDetail.MagazineCirculationQTY.HasValue, MediaManagerReviewDetail.MagazineCirculationQTY, System.DBNull.Value)

            SqlParameterNewSection.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.NewspaperSection), System.DBNull.Value, MediaManagerReviewDetail.NewspaperSection)

            If MediaManagerReviewDetail.NewspaperCost = "CPI" AndAlso MediaManagerReviewDetail.NewspaperColumns.HasValue Then

                SqlParameterNewPrintColumns.Value = MediaManagerReviewDetail.NewspaperColumns.Value

            Else

                SqlParameterNewPrintColumns.Value = System.DBNull.Value

            End If

            If MediaManagerReviewDetail.NewspaperCost = "CPI" AndAlso MediaManagerReviewDetail.NewspaperInches.HasValue Then

                SqlParameterNewPrintInches.Value = MediaManagerReviewDetail.NewspaperInches.Value

            Else

                SqlParameterNewPrintInches.Value = System.DBNull.Value

            End If

            If (MediaManagerReviewDetail.NewspaperCost = "CPL" OrElse MediaManagerReviewDetail.NewspaperCost = "CPM") AndAlso MediaManagerReviewDetail.NewspaperCirculationQTY.HasValue Then

                SqlParameterNewPrintLines.Value = MediaManagerReviewDetail.NewspaperCirculationQTY.Value

            Else

                SqlParameterNewPrintLines.Value = System.DBNull.Value

            End If

            If MediaManagerReviewDetail.MediaFrom = "Newspaper" Then

                SqlParameterNewRateType.Value = MediaManagerReviewDetail.NewspaperRate

            Else

                SqlParameterNewRateType.Value = System.DBNull.Value

            End If

            SqlParameterNewNPCirculation.Value = If(MediaManagerReviewDetail.NewspaperCirculation.HasValue, MediaManagerReviewDetail.NewspaperCirculation.Value, System.DBNull.Value)

            SqlParameterNewCopyArea.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.OutdoorCopyArea), System.DBNull.Value, MediaManagerReviewDetail.OutdoorCopyArea)
            SqlParameterNewLocation.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.OutdoorLocation), System.DBNull.Value, MediaManagerReviewDetail.OutdoorLocation)
            SqlParameterNewOutdoorType.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.OutdoorType), System.DBNull.Value, MediaManagerReviewDetail.OutdoorType)
            SqlParameterNewRate.Value = If(MediaManagerReviewDetail.Rate.HasValue, MediaManagerReviewDetail.Rate, System.DBNull.Value)
            SqlParameterNewNetcharge.Value = If(MediaManagerReviewDetail.NetChargeAmount.HasValue, MediaManagerReviewDetail.NetChargeAmount, System.DBNull.Value)
            SqlParameterNewBillCoopCode.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.BillCoopCode), System.DBNull.Value, MediaManagerReviewDetail.BillCoopCode)
            'SqlParameterNewSpots.Value = If(MediaManagerReviewDetail.Spots.HasValue, MediaManagerReviewDetail.Spots, System.DBNull.Value)

            If MediaManagerReviewDetail.MediaFrom = "Internet" Then

                SqlParameterNewCostType.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.InternetCostType), System.DBNull.Value, MediaManagerReviewDetail.InternetCostType)

            ElseIf MediaManagerReviewDetail.MediaFrom = "Newspaper" Then

                SqlParameterNewCostType.Value = If(String.IsNullOrWhiteSpace(MediaManagerReviewDetail.NewspaperCost), System.DBNull.Value, MediaManagerReviewDetail.NewspaperCost)

            Else

                SqlParameterNewCostType.Value = System.DBNull.Value

            End If

            SqlParameterNewProjImpressions.Value = If(MediaManagerReviewDetail.ProjectedImpressions.HasValue, MediaManagerReviewDetail.ProjectedImpressions, System.DBNull.Value)
            SqlParameterNewGuaranteedImpress.Value = If(MediaManagerReviewDetail.GuaranteedImpressions.HasValue, MediaManagerReviewDetail.GuaranteedImpressions, System.DBNull.Value)
            SqlParameterNewActualImpressions.Value = If(MediaManagerReviewDetail.ActualImpressions.HasValue, MediaManagerReviewDetail.ActualImpressions, System.DBNull.Value)
            SqlParameterNewMatCompDate.Value = If(MediaManagerReviewDetail.MatCompDate.HasValue, MediaManagerReviewDetail.MatCompDate.Value, System.DBNull.Value)

            CommandText = "exec dbo.advsp_revise_order_media_mgr @user_id, @order_nbr_in, @line_nbr_in, @order_type_in, @new_amount, @new_amt_source, @calculate_only, @new_addl_charge, " &
                "@force_revision, @new_order_description, @new_client_po_number, @new_buyer, @new_buyer_emp_code, @new_start_date, @new_end_date, @new_close_date, @new_matl_close_date, @new_ext_close_date, @new_ext_matl_date, " &
                "@new_date_to_bill, @new_ad_number, @new_campaign_id, @new_job_number, @new_job_component_nbr, @new_market_code, @new_markup_percent, @new_rebate_percent, " &
                "@new_programming, @new_remarks, @new_start_time, @new_end_time, " &
                "@new_length, @new_headline, @new_ad_size_code, @new_material, @new_internet_placement1, @new_internet_placement2, @new_internet_type, @new_url, @new_target_audience, " &
                "@new_edition_issue, @new_production_size, @new_mg_circulation, @new_section, @new_print_columns, @new_print_inches, @new_print_lines, @new_rate_type, @new_np_circulation, @new_copy_area, " &
                "@new_location, @new_outdoor_type, @new_rate, @new_netcharge, @new_bill_coop_code, @new_cost_type, @new_proj_impressions, @new_guaranteed_impress, @new_actual_impressions, @new_mat_comp_date," &
                "@rate_out OUTPUT, @nonresale_tax_out OUTPUT, @rebate_amount_out OUTPUT, @commission_amount_out OUTPUT, @billable_amount_out OUTPUT, @unbilled_amount_out OUTPUT, " &
                "@actual_impressions_out OUTPUT, @net_amount_out OUTPUT, @gross_amount_out OUTPUT, @netcharge_out OUTPUT, @discount_out OUTPUT, @end_date_out OUTPUT, @ret_val OUTPUT, @ret_val_s OUTPUT"

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterUserId, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterOrderType,
                        SqlParameterNewAmount, SqlParameterNewAmountSource, SqlParameterCalculateOnly, SqlParameterNewAddlCharge, SqlParameterForceRevision,
                        SqlParameterNewOrderDescription, SqlParameterNewClientPO, SqlParameterNewBuyer, SqlParameterNewBuyerEmpCode, SqlParameterNewStartDate, SqlParameterNewEndDate, SqlParameterNewCloseDate, SqlParameterNewMaterialCloseDate,
                        SqlParameterNewExtCloseDate, SqlParameterNewExtMatlCloseDate, SqlParameterNewDateToBill, SqlParameterNewAdNumber, SqlParameterNewCampaignID, SqlParameterNewJobNumber,
                        SqlParameterNewJobComponentNumber, SqlParameterNewMarketCode, SqlParameterNewMarkupPct, SqlParameterNewRebatePct, SqlParameterNewProgramming, SqlParameterNewRemarks, SqlParameterNewStartTime, SqlParameterNewEndTime, SqlParameterNewLength,
                        SqlParameterNewHeadline, SqlParameterNewAdSizeCode, SqlParameterNewMaterial, SqlParameterNewInternetPlacement1, SqlParameterNewInternetPlacement2, SqlParameterNewInternetType,
                        SqlParameterNewInternetURL, SqlParameterNewInternetTargetAudience, SqlParameterNewEditionIssue, SqlParameterNewProductionSize, SqlParameterNewMGCirculation,
                        SqlParameterNewSection,
                        SqlParameterNewPrintColumns, SqlParameterNewPrintInches, SqlParameterNewPrintLines, SqlParameterNewRateType, SqlParameterNewNPCirculation, SqlParameterNewCopyArea, SqlParameterNewLocation,
                        SqlParameterNewOutdoorType, SqlParameterNewRate, SqlParameterNewNetcharge, SqlParameterNewBillCoopCode, SqlParameterNewCostType,
                        SqlParameterNewProjImpressions, SqlParameterNewGuaranteedImpress, SqlParameterNewActualImpressions, SqlParameterNewMatCompDate,
                        SqlParameterRateOut,
                        SqlParameterNonresaleOut, SqlParameterRebateOut, SqlParameterCommissionOut, SqlParameterBillableAmtOut,
                        SqlParameterUnbilledAmountOut, SqlParameterActualImpressionsOut, SqlParameterNetAmountOut, SqlParameterGrossAmountOut,
                        SqlParameterNetchargeOut, SqlParameterDiscountOut, SqlParameterEndDateOut, SqlParameterRetval, SqlParameterRetvalString)

                    If SqlParameterRetval.Value <> 0 Then

                        ErrorMessage = SqlParameterRetvalString.Value

                    Else

                        Okay = True

                    End If

                    If Okay AndAlso CalculateOnly Then

                        MediaManagerReviewDetail.GrossAmount = SqlParameterGrossAmountOut.Value
                        MediaManagerReviewDetail.NetAmount = SqlParameterNetAmountOut.Value
                        MediaManagerReviewDetail.Rate = SqlParameterRateOut.Value
                        MediaManagerReviewDetail.NonResaleTax = SqlParameterNonresaleOut.Value
                        MediaManagerReviewDetail.RebateAmount = SqlParameterRebateOut.Value
                        MediaManagerReviewDetail.CommissionAmount = SqlParameterCommissionOut.Value
                        MediaManagerReviewDetail.BillableAmount = SqlParameterBillableAmtOut.Value
                        MediaManagerReviewDetail.UnbilledTotal = SqlParameterUnbilledAmountOut.Value
                        MediaManagerReviewDetail.NetChargeAmount = SqlParameterNetchargeOut.Value
                        MediaManagerReviewDetail.DiscountAmount = SqlParameterDiscountOut.Value

                        If SqlParameterEndDateOut.Value.Equals(System.DBNull.Value) Then

                            MediaManagerReviewDetail.EndDate = Nothing

                        Else

                            MediaManagerReviewDetail.EndDate = SqlParameterEndDateOut.Value

                        End If

                        If MediaManagerReviewDetail.MediaFrom.Substring(0, 1) = "I" AndAlso
                                ReviseOrderTo <> AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail.ReviseOrderToAmount.DoNotReviseAmount Then

                            MediaManagerReviewDetail.ActualImpressions = SqlParameterActualImpressionsOut.Value

                        End If

                    End If

                Catch ex As Exception
                    If CalculateOnly Then
                        ErrorMessage = "Failed trying to recalculate order. Please contact software support."
                    Else
                        ErrorMessage = "Failed trying to save data to the database. Please contact software support."
                    End If
                    ErrorMessage += vbCrLf & ex.Message
                    Okay = False
                End Try

            End Using

            ReviseOrder = Okay

        End Function
        Public Function CanOrderChangeToQuote(ByVal DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String, Update As Boolean) As Boolean

            Dim CanChange As Boolean = False
            Dim SqlResult As Integer = 0

            SqlResult = DbContext.Database.SqlQuery(Of Integer)(String.Format("exec dbo.advsp_media_manager_can_order_change_to_quote {0}, '{1}', {2}", OrderNumber, MediaFrom, Update)).SingleOrDefault

            If SqlResult = 1 Then

                CanChange = True

            End If

            CanOrderChangeToQuote = CanChange

        End Function
        Public Sub UpdateQuoteToOrder(ByVal DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String)

            Select Case MediaFrom

                Case "I"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.INTERNET_HEADER SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

                Case "M"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MAGAZINE_HEADER SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

                Case "N"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.NEWSPAPER_HEADER SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

                Case "O"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.OUTDOOR_HEADER SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

                Case "R"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.RADIO_HDR SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

                Case "T"

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.TV_HDR SET STATUS = 0 WHERE ORDER_NBR = {0}", OrderNumber))

            End Select

        End Sub
        Public Sub SaveOrderSelection(DbContext As AdvantageFramework.Database.DbContext,
                                      ClientCodes As IEnumerable(Of String), ClientDivisionCodes As IEnumerable(Of String), ClientDivisionProductCodes As IEnumerable(Of String),
                                      CampaignIDs As IEnumerable(Of Integer), JobNumbers As IEnumerable(Of Integer), JobComponents As IEnumerable(Of String), OrderNumbers As IEnumerable(Of Integer),
                                      AccountExecutiveCodesDefault As IEnumerable(Of String), AccountExecutiveCodesJob As IEnumerable(Of String),
                                      OrderStatuses As IEnumerable(Of Short),
                                      VendorCodes As IEnumerable(Of String), Buyers As IEnumerable(Of String))

            'objects
            Dim SqlParameterUserID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumbersList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterCampaignIDList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterClientCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDivisionCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterProductCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumberList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterJobNumberComponentsList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAEdefaultList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAEjobsList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderStatusList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVendorCodeList As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterBuyerList As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserID = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterOrderNumbersList = New System.Data.SqlClient.SqlParameter("@order_numbers_in_list", SqlDbType.VarChar)
            SqlParameterCampaignIDList = New System.Data.SqlClient.SqlParameter("@cmp_id_in_list", SqlDbType.VarChar)
            SqlParameterClientCodeList = New System.Data.SqlClient.SqlParameter("@cl_code_in_list", SqlDbType.VarChar)
            SqlParameterDivisionCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_code_in_list", SqlDbType.VarChar)
            SqlParameterProductCodeList = New System.Data.SqlClient.SqlParameter("@cl_div_prd_code_in_list", SqlDbType.VarChar)
            SqlParameterJobNumberList = New System.Data.SqlClient.SqlParameter("@job_numbers_in_list", SqlDbType.VarChar)
            SqlParameterJobNumberComponentsList = New System.Data.SqlClient.SqlParameter("@job_numbers_components_in_list", SqlDbType.VarChar)
            SqlParameterAEdefaultList = New System.Data.SqlClient.SqlParameter("@ae_emp_codes_executive_in_list", SqlDbType.VarChar)
            SqlParameterAEjobsList = New System.Data.SqlClient.SqlParameter("@ae_emp_codes_executive_jobs_in_list", SqlDbType.VarChar)
            SqlParameterOrderStatusList = New System.Data.SqlClient.SqlParameter("@order_status_in_list", SqlDbType.VarChar)
            SqlParameterVendorCodeList = New System.Data.SqlClient.SqlParameter("@vendor_code_in_list", SqlDbType.VarChar)
            SqlParameterBuyerList = New System.Data.SqlClient.SqlParameter("@buyer_emp_codes_in_list", SqlDbType.VarChar)

            SqlParameterUserID.Value = DbContext.UserCode

            If OrderNumbers Is Nothing Then

                SqlParameterOrderNumbersList.Value = System.DBNull.Value

            Else

                SqlParameterOrderNumbersList.Value = String.Join(",", OrderNumbers.ToArray)

            End If

            If CampaignIDs Is Nothing Then

                SqlParameterCampaignIDList.Value = System.DBNull.Value

            Else

                SqlParameterCampaignIDList.Value = String.Join(",", CampaignIDs.ToArray)

            End If

            If ClientCodes Is Nothing Then

                SqlParameterClientCodeList.Value = System.DBNull.Value

            Else

                SqlParameterClientCodeList.Value = String.Join(",", ClientCodes.ToArray)

            End If

            If ClientDivisionCodes Is Nothing Then

                SqlParameterDivisionCodeList.Value = System.DBNull.Value

            Else

                SqlParameterDivisionCodeList.Value = String.Join(",", ClientDivisionCodes.ToArray)

            End If

            If ClientDivisionProductCodes Is Nothing Then

                SqlParameterProductCodeList.Value = System.DBNull.Value

            Else

                SqlParameterProductCodeList.Value = String.Join(",", ClientDivisionProductCodes.ToArray)

            End If

            If JobNumbers Is Nothing Then

                SqlParameterJobNumberList.Value = System.DBNull.Value

            Else

                SqlParameterJobNumberList.Value = String.Join(",", JobNumbers.ToArray)

            End If

            If JobComponents Is Nothing Then

                SqlParameterJobNumberComponentsList.Value = System.DBNull.Value

            Else

                SqlParameterJobNumberComponentsList.Value = String.Join(",", JobComponents.ToArray)

            End If

            If AccountExecutiveCodesDefault Is Nothing Then

                SqlParameterAEdefaultList.Value = System.DBNull.Value

            Else

                SqlParameterAEdefaultList.Value = String.Join(",", AccountExecutiveCodesDefault.ToArray)

            End If

            If AccountExecutiveCodesJob Is Nothing Then

                SqlParameterAEjobsList.Value = System.DBNull.Value

            Else

                SqlParameterAEjobsList.Value = String.Join(",", AccountExecutiveCodesJob.ToArray)

            End If

            If OrderStatuses Is Nothing Then

                SqlParameterOrderStatusList.Value = System.DBNull.Value

            Else

                SqlParameterOrderStatusList.Value = String.Join(",", OrderStatuses.ToArray)

            End If

            If VendorCodes Is Nothing Then

                SqlParameterVendorCodeList.Value = System.DBNull.Value

            Else

                SqlParameterVendorCodeList.Value = String.Join(",", VendorCodes.ToArray)

            End If

            If Buyers Is Nothing Then

                SqlParameterBuyerList.Value = System.DBNull.Value

            Else

                SqlParameterBuyerList.Value = String.Join(",", Buyers.ToArray)

            End If

            DbContext.Database.ExecuteSqlCommand("exec advsp_media_manager_save_selections @user_id, @order_numbers_in_list, @cmp_id_in_list, @cl_code_in_list, @cl_div_code_in_list, @cl_div_prd_code_in_list, @job_numbers_in_list, @job_numbers_components_in_list, @ae_emp_codes_executive_in_list, @ae_emp_codes_executive_jobs_in_list, @order_status_in_list, @vendor_code_in_list, @buyer_emp_codes_in_list",
                SqlParameterUserID, SqlParameterOrderNumbersList, SqlParameterCampaignIDList, SqlParameterClientCodeList, SqlParameterDivisionCodeList, SqlParameterProductCodeList, SqlParameterJobNumberList,
                SqlParameterJobNumberComponentsList, SqlParameterAEdefaultList, SqlParameterAEjobsList, SqlParameterOrderStatusList, SqlParameterVendorCodeList, SqlParameterBuyerList)

        End Sub
        Public Sub DeleteOrderSelection(ByVal DbContext As AdvantageFramework.Database.DbContext)

            DbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_media_manager_delete_selections '{0}'", DbContext.UserCode))

        End Sub
        Public Function LoadOtherUserSelections(ByVal Session As AdvantageFramework.Security.Session) As Generic.List(Of AdvantageFramework.MediaManager.Classes.OtherUserSelection)

            Dim OtherUserSelections As Generic.List(Of AdvantageFramework.MediaManager.Classes.OtherUserSelection) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                OtherUserSelections = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.OtherUserSelection)(String.Format("exec dbo.advsp_media_manager_load_other_user_selections '{0}'", Session.UserCode)).ToList

            End Using

            LoadOtherUserSelections = OtherUserSelections

        End Function
        Public Function LoadVendorCollectedDetails(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal OrderNumberLineNumbers As IEnumerable(Of String)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail)

            Dim VendorCollectedDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail) = Nothing
            Dim SqlParameterOrderNumberLineNumbers As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderNumberLineNumbers = New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumbers", SqlDbType.VarChar)

            SqlParameterOrderNumberLineNumbers.Value = String.Join(",", OrderNumberLineNumbers.ToArray)

            VendorCollectedDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail)("EXEC advsp_media_manager_load_vendor_collected_details @OrderNumberLineNumbers",
                                                                SqlParameterOrderNumberLineNumbers).ToList()

            LoadVendorCollectedDetails = VendorCollectedDetails

        End Function
        Public Function GetAdNumberDatasource(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Ad)

            GetAdNumberDatasource = AdvantageFramework.Database.Procedures.Ad.LoadAllActiveByClientCodeAndNotExpired(DbContext, ClientCode).ToList

        End Function
        Public Function GetAdSizeCodeDatasource(DbContext As AdvantageFramework.Database.DbContext, MediaFrom As String) As Generic.List(Of AdvantageFramework.Database.Entities.AdSize)

            GetAdSizeCodeDatasource = (From AdSize In AdvantageFramework.Database.Procedures.AdSize.LoadByMediaType(DbContext, MediaFrom.Substring(0, 1))
                                       Select AdSize).ToList

        End Function
        Public Function GetCampaignIDDatasource(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Campaign)

            GetCampaignIDDatasource = (From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadAllByClientDivisionAndProduct(DbContext, ClientCode, DivisionCode, ProductCode).ToList
                                       Where Entity.IsClosed.GetValueOrDefault(0) = 0 AndAlso
                                             Entity.CampaignType = 2
                                       Select Entity).ToList

        End Function
        Public Function GetJobNumberDatasource(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Job)

            GetJobNumberDatasource = (From Job In AdvantageFramework.Database.Procedures.Job.LoadAllOpenByClientCode(DbContext, ClientCode)
                                      Where Job.DivisionCode = DivisionCode AndAlso
                                            Job.ProductCode = ProductCode
                                      Select Job).ToList

        End Function
        Public Function GetJobComponentNumberDatasource(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String, JobNumber As Integer) As Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)

            GetJobComponentNumberDatasource = AdvantageFramework.Database.Procedures.JobComponent.LoadAndFilterByClientDivisionProductAndJob(DbContext, ClientCode, DivisionCode, ProductCode, JobNumber).ToList

        End Function
        Public Function GetBroadcastMonthYear(DbContext As AdvantageFramework.Database.DbContext, StartDate As Date) As String

            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing
            Dim MonthYear As String = Nothing

            BroadcastCalendarWeeks = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)("EXEC dbo.advsp_broadcast_calendar_load").ToList

            BroadcastCalendarWeek = BroadcastCalendarWeeks.Where(Function(BCW) BCW.WeekDate <= StartDate).OrderByDescending(Function(BCW) BCW.WeekDate).FirstOrDefault

            If BroadcastCalendarWeek IsNot Nothing Then

                MonthYear = MonthName(BroadcastCalendarWeek.Month, True).ToUpper & " " & BroadcastCalendarWeek.Year.ToString

            End If

            GetBroadcastMonthYear = MonthYear

        End Function
        Public Function LoadMediaManagerApproveInvoiceOrders(DbContext As AdvantageFramework.Database.DbContext,
                                                             OrderLines As IEnumerable(Of String)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder)

            Dim ApproveInvoiceOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder)
            Dim SqlParameterOrderNumberLineNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)

            SqlParameterOrderNumberLineNumberList.Value = If(OrderLines IsNot Nothing, String.Join(",", OrderLines.ToArray), System.DBNull.Value)

            ApproveInvoiceOrders = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.ApproveInvoiceOrder)("EXEC advsp_media_manager_load_approve_invoice_orders @OrderNumberLineNumberList",
                SqlParameterOrderNumberLineNumberList).ToList()

            LoadMediaManagerApproveInvoiceOrders = ApproveInvoiceOrders

        End Function
        Public Function LoadMediaManagerApproveInvoices(DbContext As AdvantageFramework.Database.DbContext,
                                                        OrderLines As IEnumerable(Of String)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)

            Dim ApproveInvoices As Generic.List(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)
            Dim SqlParameterOrderNumberLineNumberList As New System.Data.SqlClient.SqlParameter("@OrderNumberLineNumberList", SqlDbType.VarChar)

            SqlParameterOrderNumberLineNumberList.Value = If(OrderLines IsNot Nothing, String.Join(",", OrderLines.ToArray), System.DBNull.Value)

            ApproveInvoices = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.ApproveInvoice)("EXEC advsp_media_manager_load_approve_invoice @OrderNumberLineNumberList",
                SqlParameterOrderNumberLineNumberList).ToList()

            LoadMediaManagerApproveInvoices = ApproveInvoices

        End Function
        Public Sub SaveVendorCollectedDetails(DbContext As AdvantageFramework.Database.DbContext,
                                              VendorCollectedDetailList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VendorCollectedDetail))

            Dim CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation = Nothing

            For Each VendorCollectedDetail In VendorCollectedDetailList

                Try

                    CollectedCostInformation = DbContext.CollectedCostInformations.Find(VendorCollectedDetail.ID)

                Catch ex As Exception
                    CollectedCostInformation = Nothing
                End Try

                If CollectedCostInformation IsNot Nothing Then

                    CollectedCostInformation.Comments = VendorCollectedDetail.Comments

                    DbContext.Entry(CollectedCostInformation).State = Entity.EntityState.Modified

                End If

            Next

            DbContext.SaveChanges()

        End Sub
        Public Function GetClientPODatasource(DataContext As AdvantageFramework.Database.DataContext, ClientCode As String,
                                              DivisionCode As String, ProductCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.ClientPO)

            GetClientPODatasource = (From ClientPO In AdvantageFramework.Database.Procedures.ClientPO.Load(DataContext)
                                     Where ClientPO.ClientCode = ClientCode AndAlso
                                           ClientPO.DivisionCode = DivisionCode AndAlso
                                           ClientPO.ProductCode = ProductCode AndAlso
                                           ClientPO.IsInactive = False
                                     Select ClientPO).ToList

        End Function
        Public Function LoadOrderDate(DbContext As AdvantageFramework.Database.DbContext, OrderType As String,
                                      StartDate As Date, NetGross As Int16, VendorCode As String) As AdvantageFramework.MediaManager.Classes.OrderDate

            Dim OrderDate As AdvantageFramework.MediaManager.Classes.OrderDate
            Dim SqlParameterOrderType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterStartDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRateCardId As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterNetGross As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterVendorCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAction As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUnits As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterOrderType = New System.Data.SqlClient.SqlParameter("@order_type", SqlDbType.VarChar)
            SqlParameterStartDate = New System.Data.SqlClient.SqlParameter("@start_date", SqlDbType.SmallDateTime)
            SqlParameterRateCardId = New System.Data.SqlClient.SqlParameter("@rate_card_id", SqlDbType.Int)
            SqlParameterNetGross = New System.Data.SqlClient.SqlParameter("@net_gross", SqlDbType.Int)
            SqlParameterVendorCode = New System.Data.SqlClient.SqlParameter("@vn_code", SqlDbType.VarChar)
            SqlParameterAction = New System.Data.SqlClient.SqlParameter("@action", SqlDbType.VarChar)
            SqlParameterUnits = New System.Data.SqlClient.SqlParameter("@units", SqlDbType.VarChar)

            If OrderType = "N" Then

                SqlParameterOrderType.Value = "NP"

            ElseIf OrderType = "M" Then

                SqlParameterOrderType.Value = "MA"

            Else

                SqlParameterOrderType.Value = OrderType

            End If

            SqlParameterStartDate.Value = StartDate
            SqlParameterRateCardId.Value = System.DBNull.Value
            SqlParameterNetGross.Value = NetGross
            SqlParameterVendorCode.Value = VendorCode
            SqlParameterAction.Value = System.DBNull.Value
            SqlParameterUnits.Value = System.DBNull.Value

            OrderDate = DbContext.Database.SqlQuery(Of AdvantageFramework.MediaManager.Classes.OrderDate)("SELECT * FROM [dbo].[advtf_med_set_dates](@order_type, @start_date, @rate_card_id, @net_gross, @vn_code, @action, @units)",
                                                                             SqlParameterOrderType, SqlParameterStartDate, SqlParameterRateCardId, SqlParameterNetGross, SqlParameterVendorCode,
                                                                             SqlParameterAction, SqlParameterUnits).SingleOrDefault

            If OrderDate Is Nothing Then

                OrderDate = New AdvantageFramework.MediaManager.Classes.OrderDate

            End If

            LoadOrderDate = OrderDate

        End Function
        Public Sub CreateOrderAccepted(Session As AdvantageFramework.Security.Session, MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            'objects
            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If Not MediaManagerReviewDetail.OrderAccepted Then

                    Select Case MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

                        Case "I"

                            InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus
                            InternetOrderStatus.DbContext = DbContext

                            InternetOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            InternetOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            InternetOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            InternetOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            InternetOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            InternetOrderStatus.RevisedByUserCode = DbContext.UserCode
                            InternetOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.InternetOrderStatus.Insert(DbContext, InternetOrderStatus)

                        Case "M"

                            MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus
                            MagazineOrderStatus.DbContext = DbContext

                            MagazineOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            MagazineOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            MagazineOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            MagazineOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            MagazineOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            MagazineOrderStatus.RevisedByUserCode = DbContext.UserCode
                            MagazineOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.MagazineOrderStatus.Insert(DbContext, MagazineOrderStatus)

                        Case "N"

                            NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus
                            NewspaperOrderStatus.DbContext = DbContext

                            NewspaperOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            NewspaperOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            NewspaperOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            NewspaperOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            NewspaperOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            NewspaperOrderStatus.RevisedByUserCode = DbContext.UserCode
                            NewspaperOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.NewspaperOrderStatus.Insert(DbContext, NewspaperOrderStatus)

                        Case "O"

                            OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus
                            OutOfHomeOrderStatus.DbContext = DbContext

                            OutOfHomeOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            OutOfHomeOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            OutOfHomeOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            OutOfHomeOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            OutOfHomeOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            OutOfHomeOrderStatus.RevisedByUserCode = DbContext.UserCode
                            OutOfHomeOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.OutOfHomeOrderStatus.Insert(DbContext, OutOfHomeOrderStatus)

                        Case "R"

                            RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus
                            RadioOrderStatus.DbContext = DbContext

                            RadioOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            RadioOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            RadioOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            RadioOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            RadioOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            RadioOrderStatus.RevisedByUserCode = DbContext.UserCode
                            RadioOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.RadioOrderStatus.Insert(DbContext, RadioOrderStatus)

                            AddToMediaManagerGeneratedReportDetail(DbContext, RadioOrderStatus.OrderNumber, RadioOrderStatus.LineNumber, RadioOrderStatus.RevisionNumber)

                        Case "T"

                            TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus
                            TVOrderStatus.DbContext = DbContext

                            TVOrderStatus.OrderNumber = MediaManagerReviewDetail.OrderNumber
                            TVOrderStatus.LineNumber = MediaManagerReviewDetail.LineNumber
                            TVOrderStatus.RevisionNumber = MediaManagerReviewDetail.RevisionNumber
                            TVOrderStatus.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted
                            TVOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                            TVOrderStatus.RevisedByUserCode = DbContext.UserCode
                            TVOrderStatus.RevisedByName = Session.EmployeeName

                            AdvantageFramework.Database.Procedures.TVOrderStatus.Insert(DbContext, TVOrderStatus)

                            AddToMediaManagerGeneratedReportDetail(DbContext, TVOrderStatus.OrderNumber, TVOrderStatus.LineNumber, TVOrderStatus.RevisionNumber)

                    End Select

                    MediaManagerReviewDetail.OrderAccepted = True
                    MediaManagerReviewDetail.RevisedBy = DbContext.UserCode

                    RefreshOrderLineStatusAndAcceptanceDetails(DbContext, MediaManagerReviewDetail)

                End If

            End Using

        End Sub
        Public Sub RemoveOrderAccepted(Session As AdvantageFramework.Security.Session, MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            'objects
            Dim Status As Integer = 0

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaManagerReviewDetail.OrderAccepted Then

                    Status = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                    Select Case MediaManagerReviewDetail.MediaFrom.Substring(0, 1)

                        Case "I"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.INTERNET_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                        Case "M"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MAGAZINE_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                        Case "N"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.NEWSPAPER_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                        Case "O"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.OUTDOOR_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                        Case "R"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.RADIO_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                        Case "T"

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.TV_ORDER_STATUS WHERE ORDER_NBR = {0} AND LINE_NBR = {1} AND REV_NBR = {2} AND [STATUS] = {3}", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber, Status))

                    End Select

                    MediaManagerReviewDetail.OrderAccepted = False
                    MediaManagerReviewDetail.RevisedBy = Nothing

                    RefreshOrderLineStatusAndAcceptanceDetails(DbContext, MediaManagerReviewDetail)

                End If

            End Using

        End Sub
        Public Function LoadMediaManagerPODetails(DbContext As AdvantageFramework.Database.DbContext,
                                                  CampaignIDList As IEnumerable(Of Integer),
                                                  ClientCodeList As IEnumerable(Of String),
                                                  ClientDivisionCodeList As IEnumerable(Of String),
                                                  ClientDivisionCodeProductList As IEnumerable(Of String),
                                                  JobNumbers As IEnumerable(Of Integer),
                                                  JobNumberComponentNumbers As IEnumerable(Of String),
                                                  PONumbers As IEnumerable(Of Integer),
                                                  AEDefaultEmployeeCodes As IEnumerable(Of String),
                                                  AEJobEmployeeCodes As IEnumerable(Of String),
                                                  VendorCodes As IEnumerable(Of String),
                                                  SelectForServiceRefresh As Boolean) As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)

            Dim MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)
            Dim SqlParameterCampaignIDList As New System.Data.SqlClient.SqlParameter("@CampaignIDList", SqlDbType.VarChar)
            Dim SqlParameterClientList As New System.Data.SqlClient.SqlParameter("@ClientCodeList", SqlDbType.VarChar)
            Dim SqlParameterClientDivisionList As New System.Data.SqlClient.SqlParameter("@ClientDivisionCodeList", SqlDbType.VarChar)
            Dim SqlParameterClientDivisionProductList As New System.Data.SqlClient.SqlParameter("@ClientDivisionProductCodeList", SqlDbType.VarChar)
            Dim SqlParameterJobNumberList As New System.Data.SqlClient.SqlParameter("@JobNumberList", SqlDbType.VarChar)
            Dim SqlParameterJobNumberComponentNumberList As New System.Data.SqlClient.SqlParameter("@JobNumberComponentNumberList", SqlDbType.VarChar)
            Dim SqlParameterPONumberList As New System.Data.SqlClient.SqlParameter("@PONumberList", SqlDbType.VarChar)
            Dim SqlParameterAEDefaultEmployeeCodeList As New System.Data.SqlClient.SqlParameter("@AEDefaultEmployeeCodeList", SqlDbType.VarChar)
            Dim SqlParameterAEJobEmployeeCodeList As New System.Data.SqlClient.SqlParameter("@AEJobEmployeeCodeList", SqlDbType.VarChar)
            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar)
            Dim SqlParameterVendorCodeList As New System.Data.SqlClient.SqlParameter("@VendorCodeList", SqlDbType.VarChar)
            Dim SqlParameterSelectForServiceRefresh As New System.Data.SqlClient.SqlParameter("@SelectForServiceRefresh", SqlDbType.Bit)

            SqlParameterCampaignIDList.Value = If(CampaignIDList IsNot Nothing, String.Join(",", CampaignIDList.ToArray), System.DBNull.Value)
            SqlParameterClientList.Value = If(ClientCodeList IsNot Nothing, String.Join(",", ClientCodeList.ToArray), System.DBNull.Value)
            SqlParameterClientDivisionList.Value = If(ClientDivisionCodeList IsNot Nothing, String.Join(",", ClientDivisionCodeList.ToArray), System.DBNull.Value)
            SqlParameterClientDivisionProductList.Value = If(ClientDivisionCodeProductList IsNot Nothing, String.Join(",", ClientDivisionCodeProductList.ToArray), System.DBNull.Value)
            SqlParameterJobNumberList.Value = If(JobNumbers IsNot Nothing, String.Join(",", JobNumbers.ToArray), System.DBNull.Value)
            SqlParameterJobNumberComponentNumberList.Value = If(JobNumberComponentNumbers IsNot Nothing, String.Join(",", JobNumberComponentNumbers.ToArray), System.DBNull.Value)
            SqlParameterPONumberList.Value = If(PONumbers IsNot Nothing, String.Join(",", PONumbers.ToArray), System.DBNull.Value)
            SqlParameterAEDefaultEmployeeCodeList.Value = If(AEDefaultEmployeeCodes IsNot Nothing, String.Join(",", AEDefaultEmployeeCodes.ToArray), System.DBNull.Value)
            SqlParameterAEJobEmployeeCodeList.Value = If(AEJobEmployeeCodes IsNot Nothing, String.Join(",", AEJobEmployeeCodes.ToArray), System.DBNull.Value)
            SqlParameterUserCode.Value = If(SelectForServiceRefresh, System.DBNull.Value, DbContext.UserCode)
            SqlParameterVendorCodeList.Value = If(VendorCodes IsNot Nothing, String.Join(",", VendorCodes.ToArray), System.DBNull.Value)
            SqlParameterSelectForServiceRefresh.Value = SelectForServiceRefresh

            MediaManagerPODetails = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)("EXEC advsp_media_manager_load_po_details @CampaignIDList, @ClientCodeList, @ClientDivisionCodeList, @ClientDivisionProductCodeList, @JobNumberList, @JobNumberComponentNumberList, @PONumberList, @AEDefaultEmployeeCodeList, @AEJobEmployeeCodeList, @UserCode, @VendorCodeList, @SelectForServiceRefresh",
                SqlParameterCampaignIDList, SqlParameterClientList, SqlParameterClientDivisionList, SqlParameterClientDivisionProductList, SqlParameterJobNumberList,
                SqlParameterJobNumberComponentNumberList, SqlParameterPONumberList, SqlParameterAEDefaultEmployeeCodeList,
                SqlParameterAEJobEmployeeCodeList, SqlParameterUserCode, SqlParameterVendorCodeList, SqlParameterSelectForServiceRefresh).ToList()

            LoadMediaManagerPODetails = MediaManagerPODetails

        End Function
        Public Function LoadVCCOrders(Session As AdvantageFramework.Security.Session, TimezoneOffset As AdvantageFramework.VCC.Classes.TimezoneOffset,
                                      MediaManagerReviewDetails As Generic.List(Of AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail),
                                      MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)) As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            'objects
            Dim VCCOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder) = Nothing
            Dim VCCCardIDs As IEnumerable(Of Integer) = Nothing
            Dim VCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim PONumbers As IEnumerable(Of Integer) = Nothing
            Dim VCCCardPOs As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO) = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing

            VCCOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder)

            VCCCardIDs = MediaManagerReviewDetails.Where(Function(RD) RD.VCCCardID.HasValue).Select(Function(RD) RD.VCCCardID.Value).ToArray

            PONumbers = MediaManagerPODetails.Select(Function(POD) POD.PONumber).ToArray

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                VCCCards = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCard).Include("VCCCardDetails").Include("VCCCardNotes")
                            Where VCCCardIDs.Contains(Entity.ID)
                            Select Entity).ToList

                If VCCCards IsNot Nothing Then

                    For Each MMRD In MediaManagerReviewDetails

                        VCCCard = (From Entity In VCCCards
                                   Where Entity.OrderNumber = MMRD.OrderNumber AndAlso
                                         Entity.LineNumber = MMRD.LineNumber
                                   Select Entity).SingleOrDefault

                        If VCCCard IsNot Nothing Then

                            VCCOrders.Add(New AdvantageFramework.MediaManager.Classes.VCCOrder(MMRD, VCCCard, TimezoneOffset))

                        End If

                    Next

                End If

                VCCCardPOs = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCardPO).Include("VCCCardPODetails").Include("VCCCardPONotes")
                              Where PONumbers.Contains(Entity.PONumber)
                              Select Entity).ToList

                If VCCCardPOs IsNot Nothing Then

                    For Each MMPOD In MediaManagerPODetails

                        VCCCardPO = (From Entity In VCCCardPOs
                                     Where Entity.PONumber = MMPOD.PONumber
                                     Select Entity).SingleOrDefault

                        If VCCCardPO IsNot Nothing Then

                            VCCOrders.Add(New AdvantageFramework.MediaManager.Classes.VCCOrder(MMPOD, VCCCardPO, TimezoneOffset))

                        End If

                    Next

                End If

            End Using

            LoadVCCOrders = VCCOrders

        End Function
        Public Function AddVCCNote(Session As AdvantageFramework.Security.Session, VCCOrder As AdvantageFramework.MediaManager.Classes.VCCOrder, ByRef IVCCCardNote As AdvantageFramework.Database.Interfaces.IVCCCardNote,
                                   ByRef ErrorMessage As String) As Boolean

            'objects
            Dim VCCCardNote As AdvantageFramework.Database.Entities.VCCCardNote = Nothing
            Dim VCCCardPONote As AdvantageFramework.Database.Entities.VCCCardPONote = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                    VCCCardNote = New AdvantageFramework.Database.Entities.VCCCardNote
                    VCCCardNote.DbContext = DbContext

                    VCCCardNote.Note = IVCCCardNote.Note
                    VCCCardNote.CreatedByUserCode = DbContext.UserCode
                    VCCCardNote.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                    VCCCardNote.VCCCardID = VCCOrder.GetVCCCardEntity.ID

                    Added = AdvantageFramework.Database.Procedures.VCCCardNote.Insert(DbContext, VCCCardNote, ErrorMessage)

                    If Added Then

                        IVCCCardNote.ID = VCCCardNote.ID

                    End If

                ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                    VCCCardPONote = New AdvantageFramework.Database.Entities.VCCCardPONote
                    VCCCardPONote.DbContext = DbContext

                    VCCCardPONote.Note = IVCCCardNote.Note
                    VCCCardPONote.CreatedByUserCode = DbContext.UserCode
                    VCCCardPONote.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                    VCCCardPONote.VCCCardPOID = VCCOrder.GetVCCCardEntity.ID

                    Added = AdvantageFramework.Database.Procedures.VCCCardPONote.Insert(DbContext, VCCCardPONote, ErrorMessage)

                    If Added Then

                        IVCCCardNote.ID = VCCCardPONote.ID

                    End If

                End If

            End Using

            AddVCCNote = Added

        End Function
        Public Sub UpdateVCCNote(Session As AdvantageFramework.Security.Session, IVCCCardNote As AdvantageFramework.Database.Interfaces.IVCCCardNote)

            'objects
            Dim VCCCardNote As AdvantageFramework.Database.Entities.VCCCardNote = Nothing
            Dim VCCCardPONote As AdvantageFramework.Database.Entities.VCCCardPONote = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If IVCCCardNote.NoteType = Database.Interfaces.IVCCCardNote.EnumNoteType.MediaOrder Then

                    VCCCardNote = DbContext.VCCCardNotes.Find(IVCCCardNote.ID)

                    If VCCCardNote IsNot Nothing Then

                        VCCCardNote.Note = IVCCCardNote.Note

                        DbContext.Entry(VCCCardNote).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                    End If

                ElseIf IVCCCardNote.NoteType = Database.Interfaces.IVCCCardNote.EnumNoteType.PurchaseOrder Then

                    VCCCardPONote = DbContext.VCCCardPONotes.Find(IVCCCardNote.ID)

                    If VCCCardPONote IsNot Nothing Then

                        VCCCardPONote.Note = IVCCCardNote.Note

                        DbContext.Entry(VCCCardPONote).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                    End If

                End If

            End Using

        End Sub
        Public Function DeleteVCCNote(Session As AdvantageFramework.Security.Session, IVCCCardNote As AdvantageFramework.Database.Interfaces.IVCCCardNote,
                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim VCCCardNote As AdvantageFramework.Database.Entities.VCCCardNote = Nothing
            Dim VCCCardPONote As AdvantageFramework.Database.Entities.VCCCardPONote = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If IVCCCardNote.NoteType = Database.Interfaces.IVCCCardNote.EnumNoteType.MediaOrder Then

                    VCCCardNote = DbContext.VCCCardNotes.Find(IVCCCardNote.ID)

                    If VCCCardNote IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.VCCCardNote.Delete(DbContext, VCCCardNote, ErrorMessage)

                    End If

                ElseIf IVCCCardNote.NoteType = Database.Interfaces.IVCCCardNote.EnumNoteType.PurchaseOrder Then

                    VCCCardPONote = DbContext.VCCCardPONotes.Find(IVCCCardNote.ID)

                    If VCCCardPONote IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.VCCCardPONote.Delete(DbContext, VCCCardPONote, ErrorMessage)

                    End If

                End If

            End Using

            DeleteVCCNote = Deleted

        End Function
        Public Sub UpdateCollectedCost(DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session,
                                       OrderNumber As Integer, LineNumber As Integer, RevisionNumber As Nullable(Of Integer), Quote As Boolean,
                                       VendorCollected As Decimal, VendorCollectedCopy As Nullable(Of Decimal), VCCCardID As Nullable(Of Integer),
                                       ByRef VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard))

            Dim CollectedCostInformation As AdvantageFramework.Database.Entities.CollectedCostInformation = Nothing
            Dim ErrorMessage As String = Nothing
            Dim UpdateCard As Boolean = False
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing

            CollectedCostInformation = AdvantageFramework.Database.Procedures.CollectedCostInformation.LoadByOrderNumberLineNumberRevisionNumberIsQuote(DbContext, OrderNumber, LineNumber, RevisionNumber, Quote)

            If CollectedCostInformation IsNot Nothing AndAlso CollectedCostInformation.NetAmount <> VendorCollected Then

                CollectedCostInformation.DbContext = DbContext

                CollectedCostInformation.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                CollectedCostInformation.GrossAmount = 0
                CollectedCostInformation.CommissionPercentage = 0
                CollectedCostInformation.NetAmount = VendorCollected
                CollectedCostInformation.Notes = "Modified by user.  Original Authorization by " & CollectedCostInformation.AuthorizedByName & "."
                CollectedCostInformation.AuthorizedBy = DbContext.UserCode
                CollectedCostInformation.AuthorizedByName = Session.EmployeeName

                If AdvantageFramework.Database.Procedures.CollectedCostInformation.Update(DbContext, CollectedCostInformation, ErrorMessage) = False Then

                    Throw New Exception("Failed to update CollectedCostInformation.  " & ErrorMessage)

                End If

                UpdateCard = True

            ElseIf CollectedCostInformation Is Nothing AndAlso VendorCollected <> VendorCollectedCopy Then

                CollectedCostInformation = New AdvantageFramework.Database.Entities.CollectedCostInformation
                CollectedCostInformation.DbContext = DbContext

                CollectedCostInformation.OrderNumber = OrderNumber
                CollectedCostInformation.LineNumber = LineNumber
                CollectedCostInformation.RevisionNumber = RevisionNumber
                CollectedCostInformation.GrossAmount = 0
                CollectedCostInformation.CommissionPercentage = 0
                CollectedCostInformation.NetAmount = VendorCollected
                CollectedCostInformation.Notes = "User Authorized"
                CollectedCostInformation.AuthorizedBy = DbContext.UserCode
                CollectedCostInformation.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                CollectedCostInformation.AuthorizedByName = Session.EmployeeName
                CollectedCostInformation.IsQuote = Quote

                If AdvantageFramework.Database.Procedures.CollectedCostInformation.Insert(DbContext, CollectedCostInformation, ErrorMessage) = False Then

                    Throw New Exception("Failed to save CollectedCostInformation.  " & ErrorMessage)

                End If

                UpdateCard = True

            End If

            If UpdateCard AndAlso VCCCardID.HasValue Then

                VCCCard = DbContext.VCCCards.Find(VCCCardID)

                If VCCCard IsNot Nothing Then

                    VCCCard.CardAmount = VendorCollected
                    VCCCardList.Add(VCCCard)

                End If

            End If

        End Sub
        Public Sub SaveCards(DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session, VCCOrderList As Generic.List(Of AdvantageFramework.MediaManager.Classes.VCCOrder),
                             ByRef ErrorMessage As String, ByRef VCCCardList As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard))

            'objects
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing

            Try

                For Each VCCOrder In VCCOrderList

                    If VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.MediaOrder Then

                        VCCCard = DbContext.VCCCards.Find(VCCOrder.GetVCCCardEntity.ID)

                        If VCCCard IsNot Nothing Then

                            VCCCard.DbContext = DbContext
                            VCCCard.ModifiedByUserCode = DbContext.UserCode
                            VCCCard.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                            VCCCard.FollowupDate = VCCOrder.FollowupDate
                            VCCCard.Reviewed = VCCOrder.Reviewed
                            VCCCard.Resolved = VCCOrder.Resolved

                            If Not AdvantageFramework.Database.Procedures.VCCCard.Update(DbContext, VCCCard, ErrorMessage) Then

                                Throw New Exception(ErrorMessage)

                            End If

                        End If

                        UpdateCollectedCost(DbContext, Session, VCCOrder.OrderNumber.Value, VCCOrder.LineNumber.Value, VCCOrder.RevisionNumber, VCCOrder.Quote, VCCOrder.VendorCollected, VCCOrder.VendorCollectedCopy, VCCOrder.VCCCardID, VCCCardList)

                    ElseIf VCCOrder.GetVCCCardEntity.CardType = Database.Interfaces.IVCCCard.EnumCardType.PurchaseOrder Then

                        VCCCardPO = DbContext.VCCCardPOs.Find(VCCOrder.GetVCCCardEntity.ID)

                        If VCCCardPO IsNot Nothing Then

                            VCCCardPO.DbContext = DbContext
                            VCCCardPO.ModifiedByUserCode = DbContext.UserCode
                            VCCCardPO.ModifiedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                            VCCCardPO.FollowupDate = VCCOrder.FollowupDate
                            VCCCardPO.Reviewed = VCCOrder.Reviewed
                            VCCCardPO.Resolved = VCCOrder.Resolved

                            If Not AdvantageFramework.Database.Procedures.VCCCardPO.Update(DbContext, VCCCardPO, ErrorMessage) Then

                                Throw New Exception(ErrorMessage)

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

        End Sub
        Public Function ReconcileToActualAmountPosted(ByVal Session As AdvantageFramework.Security.Session, MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterModifiedComments As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReconcileBy As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReconcileMethod As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRollForwardMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterRetVal As System.Data.SqlClient.SqlParameter = Nothing
            Dim Success As Boolean = False

            SqlParameterMediaType = New SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
            SqlParameterOrderNumber = New SqlClient.SqlParameter("@order_nbr", SqlDbType.Int)
            SqlParameterLineNumber = New SqlClient.SqlParameter("@line_nbr", SqlDbType.Int)
            SqlParameterModifiedComments = New SqlClient.SqlParameter("@modified_comments", SqlDbType.VarChar)
            SqlParameterReconcileBy = New SqlClient.SqlParameter("@reconcile_by", SqlDbType.VarChar)
            SqlParameterReconcileMethod = New SqlClient.SqlParameter("@reconcile_method", SqlDbType.VarChar)
            SqlParameterYear = New SqlClient.SqlParameter("@year", SqlDbType.VarChar)
            SqlParameterMonth = New SqlClient.SqlParameter("@month", SqlDbType.VarChar)
            SqlParameterRollForwardMonth = New SqlClient.SqlParameter("@roll_forward_month", SqlDbType.Int)
            SqlParameterUserCode = New SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)
            SqlParameterRetVal = New System.Data.SqlClient.SqlParameter("@ret_value", SqlDbType.VarChar)

            SqlParameterMediaType.Value = MediaManagerReviewDetail.MediaFrom.Substring(0, 1)
            SqlParameterOrderNumber.Value = MediaManagerReviewDetail.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerReviewDetail.LineNumber
            SqlParameterModifiedComments.Value = "MM update to actual"
            SqlParameterReconcileBy.Value = "L"
            SqlParameterReconcileMethod.Value = ""
            SqlParameterYear.Value = System.DBNull.Value
            SqlParameterMonth.Value = System.DBNull.Value
            SqlParameterRollForwardMonth.Value = System.DBNull.Value

            SqlParameterUserCode.Value = Session.UserCode
            SqlParameterRetVal.Direction = ParameterDirection.Output
            SqlParameterRetVal.Size = 254
            SqlParameterRetVal.Value = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    DbContext.Database.ExecuteSqlCommand("exec advsp_ap_media_reconcile_revise @media_type, @order_nbr, @line_nbr, @modified_comments, @reconcile_by, @reconcile_method, @year, @month, @roll_forward_month, @user_code, @ret_value OUTPUT",
                        SqlParameterMediaType, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterModifiedComments, SqlParameterReconcileBy, SqlParameterReconcileMethod,
                        SqlParameterYear, SqlParameterMonth, SqlParameterRollForwardMonth, SqlParameterUserCode, SqlParameterRetVal)

                    If SqlParameterRetVal.Value = "---" Then

                        Success = True

                    Else

                        ErrorMessage = SqlParameterRetVal.Value

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            ReconcileToActualAmountPosted = Success

        End Function
        Public Function WriteUpDown(Session As AdvantageFramework.Security.Session, MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail,
                                    AdditionalChargeAmount As Decimal, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim SqlParameterMediaType As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOrderNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterLineNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAddlCharge As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim Success As Boolean = True

            SqlParameterMediaType = New System.Data.SqlClient.SqlParameter("@media_type", SqlDbType.VarChar)
            SqlParameterOrderNumber = New System.Data.SqlClient.SqlParameter("@order_nbr", SqlDbType.Int)
            SqlParameterLineNumber = New System.Data.SqlClient.SqlParameter("@line_nbr", SqlDbType.SmallInt)
            SqlParameterAddlCharge = New System.Data.SqlClient.SqlParameter("@addl_charge", SqlDbType.Decimal)
            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_code", SqlDbType.VarChar)

            SqlParameterMediaType.Value = MediaManagerReviewDetail.MediaFrom.Substring(0, 1)
            SqlParameterOrderNumber.Value = MediaManagerReviewDetail.OrderNumber
            SqlParameterLineNumber.Value = MediaManagerReviewDetail.LineNumber
            SqlParameterAddlCharge.Value = AdditionalChargeAmount
            SqlParameterUserCode.Value = Session.UserCode

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Try

                    ErrorMessage = DbContext.Database.SqlQuery(Of String)("exec advsp_media_mananger_writeupdown @media_type, @order_nbr, @line_nbr, @addl_charge, @user_code", SqlParameterMediaType, SqlParameterOrderNumber, SqlParameterLineNumber, SqlParameterAddlCharge, SqlParameterUserCode).FirstOrDefault

                    If ErrorMessage <> "" Then

                        Success = False

                    End If

                Catch ex As Exception
                    Success = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            WriteUpDown = Success

        End Function

#Region "  Agency Settings "

        Public Function LoadDefaultRepType(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As Short

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim RepType As Short = 0

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerRepresentativeTypes.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                RepType = UserSetting.StringValue

            End If

            LoadDefaultRepType = RepType

        End Function
        Public Function SaveDefaultRepType(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, RepType As Short) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerRepresentativeTypes.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = RepType

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerRepresentativeTypes.ToString, RepType, Nothing, Nothing, UserSetting)

            End If

            SaveDefaultRepType = Saved

        End Function
        Public Function LoadContactTypes(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As String

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim ContactTypes As String = Nothing

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerContactTypes.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                ContactTypes = UserSetting.StringValue

            End If

            LoadContactTypes = ContactTypes

        End Function
        Public Function SaveContactTypes(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, ContactTypes As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerContactTypes.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = ContactTypes

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerContactTypes.ToString, ContactTypes, Nothing, Nothing, UserSetting)

            End If

            SaveContactTypes = Saved

        End Function
        Public Function LoadDocumentTypes(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As String

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim DocumentTypes As String = Nothing

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerDocumentTypes.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                DocumentTypes = UserSetting.StringValue

            End If

            LoadDocumentTypes = DocumentTypes

        End Function
        Public Function SaveDocumentTypes(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, DocumentTypes As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerDocumentTypes.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = DocumentTypes

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerDocumentTypes.ToString, DocumentTypes, Nothing, Nothing, UserSetting)

            End If

            SaveDocumentTypes = Saved

        End Function
        Public Function LoadDefaultEmailSubject(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As String

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim EmailSubject As String = ""

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailSubject.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                EmailSubject = UserSetting.StringValue

            End If

            LoadDefaultEmailSubject = EmailSubject

        End Function
        Public Function LoadDefaultEmailBody(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As String

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim EmailBody As String = ""

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailBody.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                EmailBody = UserSetting.StringValue

            End If

            LoadDefaultEmailBody = EmailBody

        End Function
        Public Function LoadDefaultCCSender(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim CCSender As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerCCSender.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                CCSender = If(UserSetting.StringValue = "Y", True, False)

            End If

            LoadDefaultCCSender = CCSender

        End Function
        Public Function LoadDefaultUploadDocumentManager(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim UploadDocumentManager As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerSendToDocumentManager.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                UploadDocumentManager = If(UserSetting.StringValue = "Y", True, False)

            End If

            LoadDefaultUploadDocumentManager = UploadDocumentManager

        End Function
        Public Function LoadDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim UploadAndSignDocumentWhenSubmitted As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerUploadAndSignDocumentWhenSubmitted.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                UploadAndSignDocumentWhenSubmitted = If(UserSetting.StringValue = "Y", True, False)

            End If

            LoadDefaultUploadAndSignDocumentWhenSubmitted = UploadAndSignDocumentWhenSubmitted

        End Function
        Public Function LoadDefaultEmailExecutedCopyToVendor(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim EmailExecutedCopyToVendor As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailExecutedCopyToVendor.ToString)

            If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                EmailExecutedCopyToVendor = If(UserSetting.StringValue = "Y", True, False)

            End If

            LoadDefaultEmailExecutedCopyToVendor = EmailExecutedCopyToVendor

        End Function
        Public Function SaveDefaultEmailSubject(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, EmailSubject As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailSubject.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = EmailSubject

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailSubject.ToString, EmailSubject, Nothing, Nothing, UserSetting)

            End If

            SaveDefaultEmailSubject = Saved

        End Function
        Public Function SaveDefaultEmailBody(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, EmailBody As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailBody.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = EmailBody

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailBody.ToString, EmailBody, Nothing, Nothing, UserSetting)

            End If

            SaveDefaultEmailBody = Saved

        End Function
        Public Function SaveDefaultCCSender(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, CCSender As Boolean) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerCCSender.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = If(CCSender, "Y", "N")

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerCCSender.ToString, If(CCSender, "Y", "N"), Nothing, Nothing, UserSetting)

            End If

            SaveDefaultCCSender = Saved

        End Function
        Public Function SaveDefaultUploadDocumentManager(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, UploadDocumentManager As Boolean) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerSendToDocumentManager.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = If(UploadDocumentManager, "Y", "N")

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerSendToDocumentManager.ToString, If(UploadDocumentManager, "Y", "N"), Nothing, Nothing, UserSetting)

            End If

            SaveDefaultUploadDocumentManager = Saved

        End Function
        Public Function SaveDefaultUploadAndSignDocumentWhenSubmitted(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, UploadAndSignDocumentWhenSubmitted As Boolean) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerUploadAndSignDocumentWhenSubmitted.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = If(UploadAndSignDocumentWhenSubmitted, "Y", "N")

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerUploadAndSignDocumentWhenSubmitted.ToString, If(UploadAndSignDocumentWhenSubmitted, "Y", "N"), Nothing, Nothing, UserSetting)

            End If

            SaveDefaultUploadAndSignDocumentWhenSubmitted = Saved

        End Function
        Public Function SaveDefaultEmailExecutedCopyToVendor(SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserID As Integer, EmailExecutedCopyToVendor As Boolean) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailExecutedCopyToVendor.ToString)

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = If(EmailExecutedCopyToVendor, "Y", "N")

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            ElseIf UserSetting Is Nothing Then

                Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserID, AdvantageFramework.Security.UserSettings.MediaManagerEmailExecutedCopyToVendor.ToString, If(EmailExecutedCopyToVendor, "Y", "N"), Nothing, Nothing, UserSetting)

            End If

            SaveDefaultEmailExecutedCopyToVendor = Saved

        End Function

#End Region

#Region "  Orders "

        Public Function CheckForVaildOrders(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder),
                                            SendToOrderReps As Boolean, ContactTypes() As Integer) As Boolean

            'objects
            Dim CheckCompleted As Boolean = True
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing

            If Session IsNot Nothing AndAlso GenerateOrders IsNot Nothing Then

                For Each GenerateOrder In GenerateOrders

                    GenerateOrder.Status = True
                    GenerateOrder.OrderMessage = ""

                Next

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            DataContext.Connection.Open()
                            DbContext.Database.Connection.Open()

                            For Each GenerateOrder In GenerateOrders.Where(Function(Entity) Entity.Status.GetValueOrDefault(False) = True).ToList

                                If GenerateOrder.DefaultCorrespondenceMethod.GetValueOrDefault(0) > 0 Then

                                    CheckForOrderToSend(DbContext, DataContext, GenerateOrder, SendToOrderReps, ContactTypes)

                                Else

                                    GenerateOrder.Status = False
                                    GenerateOrder.OrderMessage = "No correspondence method selected."

                                End If

                            Next

                        End Using

                    End Using

                Catch ex As Exception
                    CheckCompleted = False
                End Try

            End If

            CheckForVaildOrders = CheckCompleted

        End Function
        Public Function CreateUpdateVCCCardsForOrders(Session As AdvantageFramework.Security.Session, GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)) As Boolean

            'objects
            Dim CardCreationComplete As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim CardAmount As Decimal = 0
            Dim VCCCard As AdvantageFramework.Database.Entities.VCCCard = Nothing
            Dim AddGenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
            Dim UpdateVCCCards As Generic.List(Of AdvantageFramework.Database.Entities.VCCCard) = Nothing
            Dim ErrorMessage As String = Nothing

            If Session IsNot Nothing AndAlso GenerateOrders IsNot Nothing Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        AddGenerateOrders = New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder)
                        UpdateVCCCards = New Generic.List(Of AdvantageFramework.Database.Entities.VCCCard)

                        For Each GenerateOrder In GenerateOrders

                            If GenerateOrder.Status AndAlso GenerateOrder.Quote = False AndAlso GenerateOrder.Cancelled = False Then

                                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, GenerateOrder.VendorCode)

                                If Vendor IsNot Nothing Then

                                    If Vendor.VCCStatus.HasValue AndAlso Vendor.VCCStatus = AdvantageFramework.Database.Entities.VCCStatuses.Accepted AndAlso Vendor.SendVCCWithMediaOrder Then

                                        If GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0) > 0 Then

                                            CardAmount = GenerateOrder.TotalCostPayableToVendor.GetValueOrDefault(0)

                                        ElseIf GenerateOrder.VCCLimit.GetValueOrDefault(0) > 0 Then

                                            CardAmount = GenerateOrder.VCCLimit.GetValueOrDefault(0)

                                        End If

                                        If CardAmount > 0 Then

                                            Try

                                                VCCCard = AdvantageFramework.Database.Procedures.VCCCard.Load(DbContext).SingleOrDefault(Function(Entity) Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso Entity.LineNumber = GenerateOrder.LineNumber)

                                            Catch ex As Exception
                                                VCCCard = Nothing
                                            End Try

                                            If VCCCard Is Nothing Then

                                                AddGenerateOrders.Add(GenerateOrder)

                                            Else

                                                VCCCard.CardAmount = CardAmount
                                                UpdateVCCCards.Add(VCCCard)

                                            End If

                                        End If

                                    End If

                                End If

                            End If

                        Next

                    End Using

                Catch ex As Exception

                    CardCreationComplete = False

                    For Each GenerateOrder In GenerateOrders

                        If GenerateOrder.Status Then

                            GenerateOrder.Status = False
                            GenerateOrder.OrderMessage = "Failed to checking for card info on card creation."

                        End If

                    Next

                End Try

                If CardCreationComplete Then

                    If AddGenerateOrders IsNot Nothing AndAlso AddGenerateOrders.Count > 0 Then

                        AdvantageFramework.VCC.CreateVCCCreditCard(Session, AddGenerateOrders, 99)

                    End If

                    If UpdateVCCCards IsNot Nothing AndAlso UpdateVCCCards.Count > 0 Then

                        CardCreationComplete = AdvantageFramework.VCC.UpdateVCCCreditCard(Session, UpdateVCCCards, ErrorMessage)

                    End If

                End If

            End If

            CreateUpdateVCCCardsForOrders = CardCreationComplete

        End Function
        'Public Sub AddVendorRepsToGenerateOrder(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
        '                                        GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), ByVal SendToOrderReps As Boolean, ContactTypes() As Integer)

        '    'objects
        '    Dim Sending As Boolean = False
        '    Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
        '    Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
        '    Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
        '    Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
        '    Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
        '    Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
        '    Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        '    Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
        '    Dim HasVendorRep As Boolean = False
        '    Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing

        '    If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso GenerateOrders IsNot Nothing Then

        '        For Each GenerateOrder In GenerateOrders

        '            Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, GenerateOrder.VendorCode)
        '            VendorRepresentatives = New Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative)

        '            If GenerateOrder.MediaFrom.ToUpper.StartsWith("M") Then

        '                MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("N") Then

        '                NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("I") Then

        '                InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("O") Then

        '                OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("R") Then

        '                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("T") Then

        '                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

        '            End If

        '            If SendToOrderReps Then

        '                If GenerateOrder.MediaFrom.ToUpper.StartsWith("M") Then

        '                    If MagazineOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(MagazineOrder.VendorRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MagazineOrder.VendorRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(MagazineOrder.VendorRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, MagazineOrder.VendorRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("N") Then

        '                    If NewspaperOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(NewspaperOrder.VendorRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, NewspaperOrder.VendorRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(NewspaperOrder.VendorRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, NewspaperOrder.VendorRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("I") Then

        '                    If InternetOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(InternetOrder.VendorRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, InternetOrder.VendorRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(InternetOrder.VendorRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, InternetOrder.VendorRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("O") Then

        '                    If OutOfHomeOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(OutOfHomeOrder.VenderRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, OutOfHomeOrder.VenderRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(OutOfHomeOrder.VenderRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, OutOfHomeOrder.VenderRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("R") Then

        '                    If RadioOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(RadioOrder.VendorRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, RadioOrder.VendorRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(RadioOrder.VendorRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, RadioOrder.VendorRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("T") Then

        '                    If TVOrder IsNot Nothing Then

        '                        If String.IsNullOrEmpty(TVOrder.VendorRepCode1) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, TVOrder.VendorRepCode1, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                        If String.IsNullOrEmpty(TVOrder.VendorRepCode2) = False Then

        '                            VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, TVOrder.VendorRepCode2, Vendor.Code)

        '                            If VendorRepresentative IsNot Nothing Then

        '                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                Else

        '                                    VendorRepresentatives.Add(VendorRepresentative)

        '                                End If

        '                            End If

        '                        End If

        '                    End If

        '                End If

        '            Else

        '                If Vendor IsNot Nothing Then

        '                    If AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByVendorCode(DataContext, Vendor.Code).Any Then

        '                        For Each VendorRepresentative In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByVendorCode(DataContext, Vendor.Code).ToList

        '                            If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

        '                                If MagazineOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                ElseIf NewspaperOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                ElseIf InternetOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                ElseIf OutOfHomeOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                ElseIf RadioOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                ElseIf TVOrder IsNot Nothing Then

        '                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

        '                                        VendorRepresentatives.Add(VendorRepresentative)

        '                                    End If

        '                                End If

        '                            Else

        '                                VendorRepresentatives.Add(VendorRepresentative)

        '                            End If

        '                        Next

        '                    End If

        '                End If

        '            End If

        '            If VendorRepresentatives.Any AndAlso GenerateOrder.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

        '                For Each VendorRepresentative In VendorRepresentatives.ToList

        '                    If String.IsNullOrEmpty(VendorRepresentative.EmailAddress) OrElse AdvantageFramework.StringUtilities.IsValidEmailAddress(VendorRepresentative.EmailAddress) = False Then

        '                        VendorRepresentatives.Remove(VendorRepresentative)

        '                        GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, False, SendToOrderReps)

        '                    End If

        '                Next

        '            End If

        '            If VendorRepresentatives.Any AndAlso ContactTypes IsNot Nothing AndAlso ContactTypes.Count > 0 Then

        '                For Each VendorRepresentative In VendorRepresentatives.ToList

        '                    If ContactTypes.Contains(VendorRepresentative.ContactTypeID.GetValueOrDefault(0)) = False Then

        '                        VendorRepresentatives.Remove(VendorRepresentative)

        '                        GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, False, SendToOrderReps)

        '                    End If

        '                Next

        '            End If

        '            For Each VendorRepresentative In VendorRepresentatives

        '                GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, True, SendToOrderReps)

        '            Next

        '        Next

        '    End If

        'End Sub
        Private Sub CheckForOrderToSend(DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext,
                                        GenerateOrder As AdvantageFramework.MediaManager.Classes.GenerateOrder, ByVal SendToOrderReps As Boolean, ContactTypes() As Integer)

            'objects
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim HasVendorRep As Boolean = False
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso GenerateOrder IsNot Nothing Then

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, GenerateOrder.VendorCode)
                VendorRepresentatives = New Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative)

                If GenerateOrder.MediaFrom.ToUpper.StartsWith("M") Then

                    MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("N") Then

                    NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("I") Then

                    InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("O") Then

                    OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("R") Then

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("T") Then

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, GenerateOrder.OrderNumber)

                End If

                If SendToOrderReps Then

                    If GenerateOrder.MediaFrom.ToUpper.StartsWith("M") Then

                        If MagazineOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(MagazineOrder.VendorRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, MagazineOrder.VendorRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(MagazineOrder.VendorRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, MagazineOrder.VendorRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("N") Then

                        If NewspaperOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(NewspaperOrder.VendorRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, NewspaperOrder.VendorRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(NewspaperOrder.VendorRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, NewspaperOrder.VendorRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("I") Then

                        If InternetOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(InternetOrder.VendorRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, InternetOrder.VendorRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(InternetOrder.VendorRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, InternetOrder.VendorRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("O") Then

                        If OutOfHomeOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(OutOfHomeOrder.VenderRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, OutOfHomeOrder.VenderRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(OutOfHomeOrder.VenderRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, OutOfHomeOrder.VenderRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("R") Then

                        If RadioOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(RadioOrder.VendorRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, RadioOrder.VendorRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(RadioOrder.VendorRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, RadioOrder.VendorRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    ElseIf GenerateOrder.MediaFrom.ToUpper.StartsWith("T") Then

                        If TVOrder IsNot Nothing Then

                            If String.IsNullOrEmpty(TVOrder.VendorRepCode1) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, TVOrder.VendorRepCode1, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                            If String.IsNullOrEmpty(TVOrder.VendorRepCode2) = False Then

                                VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByCodeAndVendorCode(DataContext, TVOrder.VendorRepCode2, Vendor.Code)

                                If VendorRepresentative IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    Else

                                        VendorRepresentatives.Add(VendorRepresentative)

                                    End If

                                End If

                            End If

                        End If

                    End If

                    If VendorRepresentatives.Count = 0 Then

                        GenerateOrder.Status = False
                        GenerateOrder.OrderMessage = "No valid vendor rep on the order."

                    End If

                Else

                    If Vendor IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Vendor.Code).Any Then

                            For Each VendorRepresentative In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Vendor.Code).ToList

                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode).Any Then

                                    If MagazineOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, MagazineOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    ElseIf NewspaperOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, NewspaperOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    ElseIf InternetOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, InternetOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    ElseIf OutOfHomeOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, OutOfHomeOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    ElseIf RadioOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, RadioOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    ElseIf TVOrder IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, VendorRepresentative.Code, VendorRepresentative.VendorCode, TVOrder.ClientCode) IsNot Nothing Then

                                            VendorRepresentatives.Add(VendorRepresentative)

                                        End If

                                    End If

                                Else

                                    VendorRepresentatives.Add(VendorRepresentative)

                                End If

                            Next

                        End If

                    End If

                    If VendorRepresentatives.Count = 0 Then

                        GenerateOrder.Status = False
                        GenerateOrder.OrderMessage = "No valid vendor rep on associated with the vendor."

                    End If

                End If

                If GenerateOrder.Status = True Then

                    If VendorRepresentatives.Any AndAlso GenerateOrder.DefaultCorrespondenceMethod = AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods.Email Then

                        For Each VendorRepresentative In VendorRepresentatives.ToList

                            If String.IsNullOrEmpty(VendorRepresentative.EmailAddress) OrElse AdvantageFramework.StringUtilities.IsValidEmailAddress(VendorRepresentative.EmailAddress) = False Then

                                VendorRepresentatives.Remove(VendorRepresentative)

                                GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, False, SendToOrderReps)

                            End If

                        Next

                        If VendorRepresentatives.Count = 0 Then

                            GenerateOrder.Status = False
                            GenerateOrder.OrderMessage = "No valid email address on the vendor rep."

                        End If

                    End If

                End If

                If GenerateOrder.Status = True Then

                    If VendorRepresentatives.Any AndAlso ContactTypes IsNot Nothing AndAlso ContactTypes.Count > 0 Then

                        For Each VendorRepresentative In VendorRepresentatives.ToList

                            If ContactTypes.Contains(VendorRepresentative.ContactTypeID.GetValueOrDefault(0)) = False Then

                                VendorRepresentatives.Remove(VendorRepresentative)

                                GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, False, SendToOrderReps)

                            End If

                        Next

                        If VendorRepresentatives.Count = 0 Then

                            GenerateOrder.Status = False
                            GenerateOrder.OrderMessage = "No valid vendor rep contact on the order."

                        End If

                    End If

                End If

                If GenerateOrder.Status = True Then

                    For Each VendorRepresentative In VendorRepresentatives

                        GenerateOrder.AddOrUpdateGenerateOrderVendorReps(VendorRepresentative, True, SendToOrderReps)

                    Next

                End If

            End If

        End Sub
        Public Function CheckToSeeIfGeneratedOrderReportHasBeenCreated(Session As AdvantageFramework.Security.Session, ByVal OrderNumber As Integer, ByVal GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), ByVal MediaFrom As String) As Integer

            'objects
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim IsQuote As Boolean = False
            Dim FoundAllLineItems As Boolean = True

            IsQuote = GenerateOrders.Any(Function(Entity) Entity.Quote = True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext).Any(Function(Entity) Entity.OrderNumber = OrderNumber AndAlso Entity.IsQuote = IsQuote) Then

                    For Each MediaManagerGeneratedReport In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReport).Include("MediaManagerGeneratedReportDetails").Where(Function(Entity) Entity.OrderNumber = OrderNumber).ToList

                        FoundAllLineItems = True

                        For Each GenerateOrder In GenerateOrders

                            If MediaManagerGeneratedReport.MediaManagerGeneratedReportDetails.Any(Function(Entity) GenerateOrder.OrderNumber = Entity.MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                                                                   GenerateOrder.Quote = Entity.MediaManagerGeneratedReport.IsQuote AndAlso
                                                                                                                   GenerateOrder.LineNumber = CInt(Entity.LineNumber) AndAlso
                                                                                                                   GenerateOrder.RevisionNumber = CInt(Entity.RevisionNumber) AndAlso
                                                                                                                   GenerateOrder.Cancelled = Entity.IsCancelled) = False Then

                                FoundAllLineItems = False
                                Exit For

                            End If

                        Next

                        If FoundAllLineItems = True Then

                            For Each MediaManagerGeneratedReportDetail In MediaManagerGeneratedReport.MediaManagerGeneratedReportDetails.ToList

                                If GenerateOrders.Any(Function(Entity) MediaManagerGeneratedReportDetail.MediaManagerGeneratedReport.OrderNumber = Entity.OrderNumber AndAlso
                                                                       MediaManagerGeneratedReportDetail.MediaManagerGeneratedReport.IsQuote = Entity.Quote AndAlso
                                                                       CInt(MediaManagerGeneratedReportDetail.LineNumber) = Entity.LineNumber AndAlso
                                                                       CInt(MediaManagerGeneratedReportDetail.RevisionNumber) = Entity.RevisionNumber AndAlso
                                                                       MediaManagerGeneratedReportDetail.IsCancelled = Entity.Cancelled) = False Then

                                    FoundAllLineItems = False
                                    Exit For

                                End If

                            Next

                        End If

                        If FoundAllLineItems = True Then

                            MediaManagerGeneratedReportID = MediaManagerGeneratedReport.ID
                            Exit For

                        End If

                    Next

                End If

            End Using

            CheckToSeeIfGeneratedOrderReportHasBeenCreated = MediaManagerGeneratedReportID

        End Function
        Public Function CreateUpdateGeneratedOrderReport(Session As AdvantageFramework.Security.Session, ByVal OrderNumber As Integer, ByVal GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), ByVal MediaFrom As String) As Integer

            'objects
            Dim MediaManagerGeneratedReportID As Integer = 0
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaManagerGeneratedReportDetail As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail = Nothing

            MediaManagerGeneratedReportID = CheckToSeeIfGeneratedOrderReportHasBeenCreated(Session, OrderNumber, GenerateOrders, MediaFrom)

            If MediaManagerGeneratedReportID = 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        MediaManagerGeneratedReport = New AdvantageFramework.Database.Entities.MediaManagerGeneratedReport

                        MediaManagerGeneratedReport.OrderNumber = OrderNumber
                        MediaManagerGeneratedReport.MediaFrom = MediaFrom
                        MediaManagerGeneratedReport.IsQuote = GenerateOrders.Any(Function(Entity) Entity.Quote = True)
                        MediaManagerGeneratedReport.CreatedByUserCode = Session.UserCode
                        MediaManagerGeneratedReport.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)
                        MediaManagerGeneratedReport.LastGeneratedDate = MediaManagerGeneratedReport.CreatedDate

                        DbContext.MediaManagerGeneratedReports.Add(MediaManagerGeneratedReport)

                        If DbContext.SaveChanges() > 0 Then

                            For Each GenerateOrder In GenerateOrders

                                MediaManagerGeneratedReportDetail = New AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail

                                MediaManagerGeneratedReportDetail.LineNumber = GenerateOrder.LineNumber
                                MediaManagerGeneratedReportDetail.RevisionNumber = GenerateOrder.RevisionNumber
                                MediaManagerGeneratedReportDetail.IsCancelled = GenerateOrder.Cancelled
                                MediaManagerGeneratedReportDetail.MediaManagerGeneratedReportID = MediaManagerGeneratedReport.ID

                                DbContext.MediaManagerGeneratedReportDetails.Add(MediaManagerGeneratedReportDetail)

                            Next

                            DbContext.SaveChanges()

                            MediaManagerGeneratedReportID = MediaManagerGeneratedReport.ID

                        End If

                    End Using

                Catch ex As Exception

                End Try

            Else

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        MediaManagerGeneratedReport = AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID)

                        If MediaManagerGeneratedReport IsNot Nothing Then

                            MediaManagerGeneratedReport.LastGeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                            AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Update(DbContext, MediaManagerGeneratedReport, "")

                        End If

                    End Using

                Catch ex As Exception

                End Try

            End If

            If MediaManagerGeneratedReportID > 0 AndAlso MediaManagerGeneratedReport IsNot Nothing Then

                For Each GenerateOrder In GenerateOrders

                    GenerateOrder.SetReportDates(MediaManagerGeneratedReport.CreatedDate, MediaManagerGeneratedReport.LastGeneratedDate)

                Next

            End If

            CreateUpdateGeneratedOrderReport = MediaManagerGeneratedReportID

        End Function
        Public Function CreateGeneratedOrderReportSentInfo(Session As AdvantageFramework.Security.Session, ByVal MediaManagerGeneratedReportID As Integer, ByVal VendorCode As String, ByVal VendorRepresentativeCode As String, ByVal Email As String) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaManagerGeneratedReportSentInfo As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        MediaManagerGeneratedReport = AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext).Include("MediaManagerGeneratedReportSentInfos").SingleOrDefault(Function(Entity) Entity.ID = MediaManagerGeneratedReportID)

                    Catch ex As Exception
                        MediaManagerGeneratedReport = Nothing
                    End Try

                    If MediaManagerGeneratedReport IsNot Nothing Then

                        If MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos Is Nothing OrElse MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos.Any(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.VendorRepresentativeCode = VendorRepresentativeCode) = False Then

                            MediaManagerGeneratedReportSentInfo = New AdvantageFramework.Database.Entities.MediaManagerGeneratedReportSentInfo

                            MediaManagerGeneratedReportSentInfo.MediaManagerGeneratedReportID = MediaManagerGeneratedReportID
                            MediaManagerGeneratedReportSentInfo.VendorCode = VendorCode
                            MediaManagerGeneratedReportSentInfo.VendorRepresentativeCode = VendorRepresentativeCode
                            MediaManagerGeneratedReportSentInfo.Email = Email

                            DbContext.MediaManagerGeneratedReportSentInfos.Add(MediaManagerGeneratedReportSentInfo)

                            Created = (DbContext.SaveChanges() > 0)

                        Else

                            For Each MediaManagerGeneratedReportSentInfo In MediaManagerGeneratedReport.MediaManagerGeneratedReportSentInfos.Where(Function(Entity) Entity.VendorCode = VendorCode AndAlso Entity.VendorRepresentativeCode = VendorRepresentativeCode)

                                MediaManagerGeneratedReportSentInfo.Email = Email

                                DbContext.Entry(MediaManagerGeneratedReportSentInfo).State = Entity.EntityState.Modified
                                DbContext.SaveChanges()

                            Next

                        End If

                    End If

                End Using

            Catch ex As Exception
                Created = False
            End Try

            CreateGeneratedOrderReportSentInfo = Created

        End Function
        Public Function SetOrderStatusGenerated(Session As AdvantageFramework.Security.Session, ByVal GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), ByVal MediaFrom As String) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
            Dim RevisedDate As Date = Nothing

            If Session IsNot Nothing AndAlso String.IsNullOrWhiteSpace(MediaFrom) = False AndAlso GenerateOrders IsNot Nothing AndAlso GenerateOrders.Count > 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                        If MediaFrom.ToUpper.StartsWith("M") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                MagazineOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    MagazineOrderStatus = (From Entity In DbContext.MagazineOrderStatuses
                                                           Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                                 Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                                 Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                                 Entity.OrderStatusID = OrderStatusType
                                                           Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    MagazineOrderStatus = Nothing
                                End Try

                                If MagazineOrderStatus Is Nothing Then

                                    MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus

                                    MagazineOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    MagazineOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    MagazineOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    MagazineOrderStatus.OrderStatusID = OrderStatusType
                                    MagazineOrderStatus.RevisedByUserCode = Session.UserCode
                                    MagazineOrderStatus.RevisedByName = Session.EmployeeName
                                    MagazineOrderStatus.RevisedDate = RevisedDate

                                    DbContext.MagazineOrderStatuses.Add(MagazineOrderStatus)

                                Else

                                    MagazineOrderStatus.RevisedByUserCode = Session.UserCode
                                    MagazineOrderStatus.RevisedByName = Session.EmployeeName
                                    MagazineOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(MagazineOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                NewspaperOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    NewspaperOrderStatus = (From Entity In DbContext.NewspaperOrderStatuses
                                                            Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                             Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                             Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                             Entity.OrderStatusID = OrderStatusType
                                                            Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    NewspaperOrderStatus = Nothing
                                End Try

                                If NewspaperOrderStatus Is Nothing Then

                                    NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus

                                    NewspaperOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    NewspaperOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    NewspaperOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    NewspaperOrderStatus.OrderStatusID = OrderStatusType
                                    NewspaperOrderStatus.RevisedByUserCode = Session.UserCode
                                    NewspaperOrderStatus.RevisedByName = Session.EmployeeName
                                    NewspaperOrderStatus.RevisedDate = RevisedDate

                                    DbContext.NewspaperOrderStatuses.Add(NewspaperOrderStatus)

                                Else

                                    NewspaperOrderStatus.RevisedByUserCode = Session.UserCode
                                    NewspaperOrderStatus.RevisedByName = Session.EmployeeName
                                    NewspaperOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(NewspaperOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                InternetOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    InternetOrderStatus = (From Entity In DbContext.InternetOrderStatuses
                                                           Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                             Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                             Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                             Entity.OrderStatusID = OrderStatusType
                                                           Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    InternetOrderStatus = Nothing
                                End Try

                                If InternetOrderStatus Is Nothing Then

                                    InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

                                    InternetOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    InternetOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    InternetOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    InternetOrderStatus.OrderStatusID = OrderStatusType
                                    InternetOrderStatus.RevisedByUserCode = Session.UserCode
                                    InternetOrderStatus.RevisedByName = Session.EmployeeName
                                    InternetOrderStatus.RevisedDate = RevisedDate

                                    DbContext.InternetOrderStatuses.Add(InternetOrderStatus)

                                Else

                                    InternetOrderStatus.RevisedByUserCode = Session.UserCode
                                    InternetOrderStatus.RevisedByName = Session.EmployeeName
                                    InternetOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(InternetOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                OutOfHomeOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    OutOfHomeOrderStatus = (From Entity In DbContext.OutOfHomeOrderStatuses
                                                            Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                                  Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                                  Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                                  Entity.OrderStatusID = OrderStatusType
                                                            Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    OutOfHomeOrderStatus = Nothing
                                End Try

                                If OutOfHomeOrderStatus Is Nothing Then

                                    OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus

                                    OutOfHomeOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    OutOfHomeOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    OutOfHomeOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    OutOfHomeOrderStatus.OrderStatusID = OrderStatusType
                                    OutOfHomeOrderStatus.RevisedByUserCode = Session.UserCode
                                    OutOfHomeOrderStatus.RevisedByName = Session.EmployeeName
                                    OutOfHomeOrderStatus.RevisedDate = RevisedDate

                                    DbContext.OutOfHomeOrderStatuses.Add(OutOfHomeOrderStatus)

                                Else

                                    OutOfHomeOrderStatus.RevisedByUserCode = Session.UserCode
                                    OutOfHomeOrderStatus.RevisedByName = Session.EmployeeName
                                    OutOfHomeOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(OutOfHomeOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                RadioOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    RadioOrderStatus = (From Entity In DbContext.RadioOrderStatuses
                                                        Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                             Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                             Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                             Entity.OrderStatusID = OrderStatusType
                                                        Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    RadioOrderStatus = Nothing
                                End Try

                                If RadioOrderStatus Is Nothing Then

                                    RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus

                                    RadioOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    RadioOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    RadioOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    RadioOrderStatus.OrderStatusID = OrderStatusType
                                    RadioOrderStatus.RevisedByUserCode = Session.UserCode
                                    RadioOrderStatus.RevisedByName = Session.EmployeeName
                                    RadioOrderStatus.RevisedDate = RevisedDate

                                    DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

                                Else

                                    RadioOrderStatus.RevisedByUserCode = Session.UserCode
                                    RadioOrderStatus.RevisedByName = Session.EmployeeName
                                    RadioOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(RadioOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                            For Each GenerateOrder In GenerateOrders

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                TVOrderStatus = Nothing

                                If GenerateOrder.Quote Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteGenerated

                                ElseIf GenerateOrder.Cancelled Then

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationGenerated

                                Else

                                    OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated

                                End If

                                Try

                                    TVOrderStatus = (From Entity In DbContext.TVOrderStatuses
                                                     Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
                                                             Entity.LineNumber = GenerateOrder.LineNumber AndAlso
                                                             Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
                                                             Entity.OrderStatusID = OrderStatusType
                                                     Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    TVOrderStatus = Nothing
                                End Try

                                If TVOrderStatus Is Nothing Then

                                    TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus

                                    TVOrderStatus.OrderNumber = GenerateOrder.OrderNumber
                                    TVOrderStatus.LineNumber = GenerateOrder.LineNumber
                                    TVOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
                                    TVOrderStatus.OrderStatusID = OrderStatusType
                                    TVOrderStatus.RevisedByUserCode = Session.UserCode
                                    TVOrderStatus.RevisedByName = Session.EmployeeName
                                    TVOrderStatus.RevisedDate = RevisedDate

                                    DbContext.TVOrderStatuses.Add(TVOrderStatus)

                                Else

                                    TVOrderStatus.RevisedByUserCode = Session.UserCode
                                    TVOrderStatus.RevisedByName = Session.EmployeeName
                                    TVOrderStatus.RevisedDate = RevisedDate

                                    DbContext.Entry(TVOrderStatus).State = Entity.EntityState.Modified

                                End If

                                GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                            Next

                        End If

                        DbContext.SaveChanges()

                        OrderStatusSet = True

                    End Using

                Catch ex As Exception
                    OrderStatusSet = False
                End Try

            End If

            SetOrderStatusGenerated = OrderStatusSet

        End Function
        'Public Function SetOrderStatusPrinted(Session As AdvantageFramework.Security.Session, ByVal GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), ByVal MediaFrom As String) As Boolean

        '    'objects
        '    Dim OrderStatusSet As Boolean = False
        '    Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
        '    Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
        '    Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
        '    Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
        '    Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
        '    Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing
        '    Dim OrderStatus As AdvantageFramework.Database.Entities.OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Pending

        '    If Session IsNot Nothing AndAlso String.IsNullOrWhiteSpace(MediaFrom) = False AndAlso GenerateOrders IsNot Nothing AndAlso GenerateOrders.Count > 0 Then

        '        Try

        '            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

        '                If MediaFrom.ToUpper.StartsWith("M") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        MagazineOrderStatus = Nothing

        '                        Try

        '                            MagazineOrderStatus = (From Entity In DbContext.MagazineOrderStatuses
        '                                                   Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                     Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                     Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                     Entity.OrderStatusID = OrderStatus
        '                                                   Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            MagazineOrderStatus = Nothing
        '                        End Try

        '                        If MagazineOrderStatus Is Nothing Then

        '                            MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus

        '                            MagazineOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            MagazineOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            MagazineOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            MagazineOrderStatus.OrderStatusID = OrderStatus
        '                            MagazineOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.MagazineOrderStatuses.Add(MagazineOrderStatus)

        '                        Else

        '                            MagazineOrderStatus.RevisedByUserCode = Session.UserCode
        '                            MagazineOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(MagazineOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                ElseIf MediaFrom.ToUpper.StartsWith("N") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        NewspaperOrderStatus = Nothing

        '                        Try

        '                            NewspaperOrderStatus = (From Entity In DbContext.NewspaperOrderStatuses
        '                                                    Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                     Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                     Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                     Entity.OrderStatusID = OrderStatus
        '                                                    Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            NewspaperOrderStatus = Nothing
        '                        End Try

        '                        If NewspaperOrderStatus Is Nothing Then

        '                            NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus

        '                            NewspaperOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            NewspaperOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            NewspaperOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            NewspaperOrderStatus.OrderStatusID = OrderStatus
        '                            NewspaperOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.NewspaperOrderStatuses.Add(NewspaperOrderStatus)

        '                        Else

        '                            NewspaperOrderStatus.RevisedByUserCode = Session.UserCode
        '                            NewspaperOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(NewspaperOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                ElseIf MediaFrom.ToUpper.StartsWith("I") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        InternetOrderStatus = Nothing

        '                        Try

        '                            InternetOrderStatus = (From Entity In DbContext.InternetOrderStatuses
        '                                                   Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                     Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                     Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                     Entity.OrderStatusID = OrderStatus
        '                                                   Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            InternetOrderStatus = Nothing
        '                        End Try

        '                        If InternetOrderStatus Is Nothing Then

        '                            InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

        '                            InternetOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            InternetOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            InternetOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            InternetOrderStatus.OrderStatusID = OrderStatus
        '                            InternetOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.InternetOrderStatuses.Add(InternetOrderStatus)

        '                        Else

        '                            InternetOrderStatus.RevisedByUserCode = Session.UserCode
        '                            InternetOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(InternetOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                ElseIf MediaFrom.ToUpper.StartsWith("O") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        OutOfHomeOrderStatus = Nothing

        '                        Try

        '                            OutOfHomeOrderStatus = (From Entity In DbContext.OutOfHomeOrderStatuses
        '                                                    Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                          Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                          Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                          Entity.OrderStatusID = OrderStatus
        '                                                    Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            OutOfHomeOrderStatus = Nothing
        '                        End Try

        '                        If OutOfHomeOrderStatus Is Nothing Then

        '                            OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus

        '                            OutOfHomeOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            OutOfHomeOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            OutOfHomeOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            OutOfHomeOrderStatus.OrderStatusID = OrderStatus
        '                            OutOfHomeOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.OutOfHomeOrderStatuses.Add(OutOfHomeOrderStatus)

        '                        Else

        '                            OutOfHomeOrderStatus.RevisedByUserCode = Session.UserCode
        '                            OutOfHomeOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(OutOfHomeOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                ElseIf MediaFrom.ToUpper.StartsWith("R") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        RadioOrderStatus = Nothing

        '                        Try

        '                            RadioOrderStatus = (From Entity In DbContext.RadioOrderStatuses
        '                                                Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                     Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                     Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                     Entity.OrderStatusID = OrderStatus
        '                                                Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            RadioOrderStatus = Nothing
        '                        End Try

        '                        If RadioOrderStatus Is Nothing Then

        '                            RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus

        '                            RadioOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            RadioOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            RadioOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            RadioOrderStatus.OrderStatusID = OrderStatus
        '                            RadioOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

        '                        Else

        '                            RadioOrderStatus.RevisedByUserCode = Session.UserCode
        '                            RadioOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(RadioOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                ElseIf MediaFrom.ToUpper.StartsWith("T") Then

        '                    For Each GenerateOrder In GenerateOrders

        '                        OrderStatus = AdvantageFramework.Database.Entities.OrderStatus.Printed
        '                        TVOrderStatus = Nothing

        '                        Try

        '                            TVOrderStatus = (From Entity In DbContext.TVOrderStatuses
        '                                             Where Entity.OrderNumber = GenerateOrder.OrderNumber AndAlso
        '                                                     Entity.LineNumber = GenerateOrder.LineNumber AndAlso
        '                                                     Entity.RevisionNumber = GenerateOrder.RevisionNumber AndAlso
        '                                                     Entity.OrderStatusID = OrderStatus
        '                                             Select Entity).SingleOrDefault

        '                        Catch ex As Exception
        '                            TVOrderStatus = Nothing
        '                        End Try

        '                        If TVOrderStatus Is Nothing Then

        '                            TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus

        '                            TVOrderStatus.OrderNumber = GenerateOrder.OrderNumber
        '                            TVOrderStatus.LineNumber = GenerateOrder.LineNumber
        '                            TVOrderStatus.RevisionNumber = GenerateOrder.RevisionNumber
        '                            TVOrderStatus.OrderStatusID = OrderStatus
        '                            TVOrderStatus.RevisedByUserCode = Session.UserCode

        '                            DbContext.TVOrderStatuses.Add(TVOrderStatus)

        '                        Else

        '                            TVOrderStatus.RevisedByUserCode = Session.UserCode
        '                            TVOrderStatus.RevisedDate = Now

        '                            DbContext.Entry(TVOrderStatus).State = Entity.EntityState.Modified

        '                        End If

        '                        GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = OrderStatus.ToString

        '                    Next

        '                End If

        '                DbContext.SaveChanges()

        '                OrderStatusSet = True

        '            End Using

        '        Catch ex As Exception
        '            OrderStatusSet = False
        '        End Try

        '    End If

        '    SetOrderStatusPrinted = OrderStatusSet

        'End Function
        Public Function SetOrderStatusReceived(ConnectionString As String, UserCode As String, MediaManagerGeneratedReportID As Integer, Quote As Boolean, Cancelled As Boolean, RevisiedByName As String) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
            Dim MediaFrom As String = ""

            If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso String.IsNullOrWhiteSpace(UserCode) = False AndAlso MediaManagerGeneratedReportID > 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                        MediaManagerGeneratedReport = DbContext.MediaManagerGeneratedReports.Find(MediaManagerGeneratedReportID)

                        If MediaManagerGeneratedReport IsNot Nothing Then

                            MediaFrom = MediaManagerGeneratedReport.MediaFrom

                        End If

                        If MediaFrom.ToUpper.StartsWith("M") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                MagazineOrder = Nothing
                                MagazineOrderStatus = Nothing

                                MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If MagazineOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        MagazineOrderStatus = (From Entity In DbContext.MagazineOrderStatuses
                                                               Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                     Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                     Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                     Entity.OrderStatusID = OrderStatusType
                                                               Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        MagazineOrderStatus = Nothing
                                    End Try

                                    If MagazineOrderStatus Is Nothing Then

                                        MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus

                                        MagazineOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        MagazineOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        MagazineOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        MagazineOrderStatus.OrderStatusID = OrderStatusType
                                        MagazineOrderStatus.RevisedByName = RevisiedByName
                                        MagazineOrderStatus.RevisedDate = Now

                                        DbContext.MagazineOrderStatuses.Add(MagazineOrderStatus)

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                NewspaperOrder = Nothing
                                NewspaperOrderStatus = Nothing

                                NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If NewspaperOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        NewspaperOrderStatus = (From Entity In DbContext.NewspaperOrderStatuses
                                                                Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                      Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                      Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                      Entity.OrderStatusID = OrderStatusType
                                                                Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        NewspaperOrderStatus = Nothing
                                    End Try

                                    If NewspaperOrderStatus Is Nothing Then

                                        NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus

                                        NewspaperOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        NewspaperOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        NewspaperOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        NewspaperOrderStatus.OrderStatusID = OrderStatusType
                                        NewspaperOrderStatus.RevisedByName = RevisiedByName
                                        NewspaperOrderStatus.RevisedDate = Now

                                        DbContext.NewspaperOrderStatuses.Add(NewspaperOrderStatus)

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                InternetOrder = Nothing
                                InternetOrderStatus = Nothing

                                InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If InternetOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        InternetOrderStatus = (From Entity In DbContext.InternetOrderStatuses
                                                               Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                     Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                     Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                     Entity.OrderStatusID = OrderStatusType
                                                               Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        InternetOrderStatus = Nothing
                                    End Try

                                    If InternetOrderStatus Is Nothing Then

                                        InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

                                        InternetOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        InternetOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        InternetOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        InternetOrderStatus.OrderStatusID = OrderStatusType
                                        InternetOrderStatus.RevisedByName = RevisiedByName
                                        InternetOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.InternetOrderStatuses.Add(InternetOrderStatus)

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                OutOfHomeOrder = Nothing
                                OutOfHomeOrderStatus = Nothing

                                OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If OutOfHomeOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        OutOfHomeOrderStatus = (From Entity In DbContext.OutOfHomeOrderStatuses
                                                                Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                      Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                      Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                      Entity.OrderStatusID = OrderStatusType
                                                                Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        OutOfHomeOrderStatus = Nothing
                                    End Try

                                    If OutOfHomeOrderStatus Is Nothing Then

                                        OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus

                                        OutOfHomeOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        OutOfHomeOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        OutOfHomeOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        OutOfHomeOrderStatus.OrderStatusID = OrderStatusType
                                        OutOfHomeOrderStatus.RevisedByName = RevisiedByName
                                        OutOfHomeOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.OutOfHomeOrderStatuses.Add(OutOfHomeOrderStatus)

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                RadioOrder = Nothing
                                RadioOrderStatus = Nothing

                                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If RadioOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        RadioOrderStatus = (From Entity In DbContext.RadioOrderStatuses
                                                            Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                  Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                  Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                  Entity.OrderStatusID = OrderStatusType
                                                            Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        RadioOrderStatus = Nothing
                                    End Try

                                    If RadioOrderStatus Is Nothing Then

                                        RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus

                                        RadioOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        RadioOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        RadioOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        RadioOrderStatus.OrderStatusID = OrderStatusType
                                        RadioOrderStatus.RevisedByName = RevisiedByName
                                        RadioOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                TVOrder = Nothing
                                TVOrderStatus = Nothing

                                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If TVOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteRecieved

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationRecieved

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved

                                    End If

                                    Try

                                        TVOrderStatus = (From Entity In DbContext.TVOrderStatuses
                                                         Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                               Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                               Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                               Entity.OrderStatusID = OrderStatusType
                                                         Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        TVOrderStatus = Nothing
                                    End Try

                                    If TVOrderStatus Is Nothing Then

                                        TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus

                                        TVOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        TVOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        TVOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        TVOrderStatus.OrderStatusID = OrderStatusType
                                        TVOrderStatus.RevisedByName = RevisiedByName
                                        TVOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.TVOrderStatuses.Add(TVOrderStatus)

                                    End If

                                End If

                            Next

                        End If

                        DbContext.SaveChanges()

                        OrderStatusSet = True

                    End Using

                Catch ex As Exception
                    OrderStatusSet = False
                End Try

            End If

            SetOrderStatusReceived = OrderStatusSet

        End Function
        Public Function SetOrderStatusAccepted(ConnectionString As String, UserCode As String, MediaManagerGeneratedReportID As Integer, Quote As Boolean, Cancelled As Boolean, RevisiedByName As String) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim MagazineOrderStatus As AdvantageFramework.Database.Entities.MagazineOrderStatus = Nothing
            Dim NewspaperOrderStatus As AdvantageFramework.Database.Entities.NewspaperOrderStatus = Nothing
            Dim InternetOrderStatus As AdvantageFramework.Database.Entities.InternetOrderStatus = Nothing
            Dim OutOfHomeOrderStatus As AdvantageFramework.Database.Entities.OutOfHomeOrderStatus = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing
            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
            Dim MediaFrom As String = ""

            If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso String.IsNullOrWhiteSpace(UserCode) = False AndAlso MediaManagerGeneratedReportID > 0 Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                        MediaManagerGeneratedReport = DbContext.MediaManagerGeneratedReports.Find(MediaManagerGeneratedReportID)

                        If MediaManagerGeneratedReport IsNot Nothing Then

                            MediaFrom = MediaManagerGeneratedReport.MediaFrom

                        End If

                        If MediaFrom.ToUpper.StartsWith("M") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                MagazineOrder = Nothing
                                MagazineOrderStatus = Nothing

                                MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If MagazineOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        MagazineOrderStatus = (From Entity In DbContext.MagazineOrderStatuses
                                                               Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                     Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                     Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                     Entity.OrderStatusID = OrderStatusType
                                                               Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        MagazineOrderStatus = Nothing
                                    End Try

                                    If MagazineOrderStatus Is Nothing Then

                                        MagazineOrderStatus = New AdvantageFramework.Database.Entities.MagazineOrderStatus

                                        MagazineOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        MagazineOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        MagazineOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        MagazineOrderStatus.OrderStatusID = OrderStatusType
                                        MagazineOrderStatus.RevisedByName = RevisiedByName
                                        MagazineOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.MagazineOrderStatuses.Add(MagazineOrderStatus)

                                    Else

                                        MagazineOrderStatus.RevisedByName = RevisiedByName
                                        MagazineOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(MagazineOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                NewspaperOrder = Nothing
                                NewspaperOrderStatus = Nothing

                                NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If NewspaperOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        NewspaperOrderStatus = (From Entity In DbContext.NewspaperOrderStatuses
                                                                Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                      Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                      Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                      Entity.OrderStatusID = OrderStatusType
                                                                Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        NewspaperOrderStatus = Nothing
                                    End Try

                                    If NewspaperOrderStatus Is Nothing Then

                                        NewspaperOrderStatus = New AdvantageFramework.Database.Entities.NewspaperOrderStatus

                                        NewspaperOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        NewspaperOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        NewspaperOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        NewspaperOrderStatus.OrderStatusID = OrderStatusType
                                        NewspaperOrderStatus.RevisedByName = RevisiedByName
                                        NewspaperOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.NewspaperOrderStatuses.Add(NewspaperOrderStatus)

                                    Else

                                        NewspaperOrderStatus.RevisedByName = RevisiedByName
                                        NewspaperOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(NewspaperOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                InternetOrder = Nothing
                                InternetOrderStatus = Nothing

                                InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If InternetOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        InternetOrderStatus = (From Entity In DbContext.InternetOrderStatuses
                                                               Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                     Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                     Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                     Entity.OrderStatusID = OrderStatusType
                                                               Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        InternetOrderStatus = Nothing
                                    End Try

                                    If InternetOrderStatus Is Nothing Then

                                        InternetOrderStatus = New AdvantageFramework.Database.Entities.InternetOrderStatus

                                        InternetOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        InternetOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        InternetOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        InternetOrderStatus.OrderStatusID = OrderStatusType
                                        InternetOrderStatus.RevisedByName = RevisiedByName
                                        InternetOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.InternetOrderStatuses.Add(InternetOrderStatus)

                                    Else

                                        InternetOrderStatus.RevisedByName = RevisiedByName
                                        InternetOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(InternetOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                OutOfHomeOrder = Nothing
                                OutOfHomeOrderStatus = Nothing

                                OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If OutOfHomeOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        OutOfHomeOrderStatus = (From Entity In DbContext.OutOfHomeOrderStatuses
                                                                Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                      Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                      Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                      Entity.OrderStatusID = OrderStatusType
                                                                Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        OutOfHomeOrderStatus = Nothing
                                    End Try

                                    If OutOfHomeOrderStatus Is Nothing Then

                                        OutOfHomeOrderStatus = New AdvantageFramework.Database.Entities.OutOfHomeOrderStatus

                                        OutOfHomeOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        OutOfHomeOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        OutOfHomeOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        OutOfHomeOrderStatus.OrderStatusID = OrderStatusType
                                        OutOfHomeOrderStatus.RevisedByName = RevisiedByName
                                        OutOfHomeOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.OutOfHomeOrderStatuses.Add(OutOfHomeOrderStatus)

                                    Else

                                        OutOfHomeOrderStatus.RevisedByName = RevisiedByName
                                        OutOfHomeOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(OutOfHomeOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                RadioOrder = Nothing
                                RadioOrderStatus = Nothing

                                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If RadioOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        RadioOrderStatus = (From Entity In DbContext.RadioOrderStatuses
                                                            Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                                  Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                                  Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                                  Entity.OrderStatusID = OrderStatusType
                                                            Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        RadioOrderStatus = Nothing
                                    End Try

                                    If RadioOrderStatus Is Nothing Then

                                        RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus

                                        RadioOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        RadioOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        RadioOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        RadioOrderStatus.OrderStatusID = OrderStatusType
                                        RadioOrderStatus.RevisedByName = RevisiedByName
                                        RadioOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

                                    Else

                                        RadioOrderStatus.RevisedByName = RevisiedByName
                                        RadioOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(RadioOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                            For Each MediaManagerGeneratedReportDetail In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.LoadByMediaManagerGeneratedReportID(DbContext, MediaManagerGeneratedReportID).ToList

                                OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.Pending
                                TVOrder = Nothing
                                TVOrderStatus = Nothing

                                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, MediaManagerGeneratedReport.OrderNumber)

                                If TVOrder IsNot Nothing Then

                                    If MediaManagerGeneratedReport.IsQuote Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.QuoteAccepted

                                    ElseIf MediaManagerGeneratedReportDetail.IsCancelled Then

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.CancellationAccepted

                                    Else

                                        OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

                                    End If

                                    Try

                                        TVOrderStatus = (From Entity In DbContext.TVOrderStatuses
                                                         Where Entity.OrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso
                                                               Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso
                                                               Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso
                                                               Entity.OrderStatusID = OrderStatusType
                                                         Select Entity).SingleOrDefault

                                    Catch ex As Exception
                                        TVOrderStatus = Nothing
                                    End Try

                                    If TVOrderStatus Is Nothing Then

                                        TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus

                                        TVOrderStatus.OrderNumber = MediaManagerGeneratedReport.OrderNumber
                                        TVOrderStatus.LineNumber = MediaManagerGeneratedReportDetail.LineNumber
                                        TVOrderStatus.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                        TVOrderStatus.OrderStatusID = OrderStatusType
                                        TVOrderStatus.RevisedByName = RevisiedByName
                                        TVOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.TVOrderStatuses.Add(TVOrderStatus)

                                    Else

                                        TVOrderStatus.RevisedByName = RevisiedByName
                                        TVOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                                        DbContext.Entry(TVOrderStatus).State = Entity.EntityState.Modified

                                    End If

                                End If

                            Next

                        End If

                        DbContext.SaveChanges()

                        OrderStatusSet = True

                    End Using

                Catch ex As Exception
                    OrderStatusSet = False
                End Try

            End If

            SetOrderStatusAccepted = OrderStatusSet

        End Function
        Private Function IsLineCancelled(DbContext As AdvantageFramework.Database.DbContext, MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport, MediaManagerGeneratedReportDetail As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail) As Boolean

            'objects
            Dim LineCancelled As Boolean = False
            Dim MediaFrom As String = ""

            If MediaManagerGeneratedReport IsNot Nothing Then

                MediaFrom = MediaManagerGeneratedReport.MediaFrom

            End If

            If MediaFrom.ToUpper.StartsWith("M") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.MagazineOrderDetail.Load(DbContext).Any(Function(Entity) Entity.MagazineOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            ElseIf MediaFrom.ToUpper.StartsWith("N") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Load(DbContext).Any(Function(Entity) Entity.NewspaperOrderOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            ElseIf MediaFrom.ToUpper.StartsWith("I") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext).Any(Function(Entity) Entity.InternetOrderOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            ElseIf MediaFrom.ToUpper.StartsWith("O") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext).Any(Function(Entity) Entity.OutofHomeOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            ElseIf MediaFrom.ToUpper.StartsWith("R") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext).Any(Function(Entity) Entity.RadioOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                Try

                    LineCancelled = AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext).Any(Function(Entity) Entity.TVOrderNumber = MediaManagerGeneratedReport.OrderNumber AndAlso Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber AndAlso Entity.IsLineCancelled = 1)

                Catch ex As Exception
                    LineCancelled = False
                End Try

            End If

            IsLineCancelled = LineCancelled

        End Function
        Public Sub UpdateJobComponentMediaBillDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            'objects
            Dim CommandText As String = Nothing
            Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMediaBillDate As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            SqlParameterComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            SqlParameterMediaBillDate = New System.Data.SqlClient.SqlParameter("@MEDIA_BILL_DATE", SqlDbType.SmallDateTime)

            SqlParameterJobNumber.Value = MediaManagerReviewDetail.JobNumber.Value
            SqlParameterComponentNumber.Value = MediaManagerReviewDetail.JobComponentNumber.Value
            SqlParameterMediaBillDate.Value = If(MediaManagerReviewDetail.JobMediaBillDate.HasValue, MediaManagerReviewDetail.JobMediaBillDate.Value, System.DBNull.Value)

            CommandText = "UPDATE dbo.JOB_COMPONENT SET MEDIA_BILL_DATE = @MEDIA_BILL_DATE WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR"

            DbContext.Database.ExecuteSqlCommand(CommandText, SqlParameterJobNumber, SqlParameterComponentNumber, SqlParameterMediaBillDate)

        End Sub
        Public Function GetCardStatusDatasource() As List(Of EnumUtilities.Attributes.EnumObjectAttribute)

            Dim EnumObjectAttributeList As List(Of EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            EnumObjectAttributeList = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VCCStatus))
                                       Where Entity.Code <> "B"
                                       Select Entity).ToList

            GetCardStatusDatasource = EnumObjectAttributeList

        End Function
        Public Function GetOrderClientAndVendor(DbContext As AdvantageFramework.Database.DbContext, MediaType As String, OrderNumber As Integer, ByRef ClientName As String, ByRef VendorName As String) As Boolean

            Dim OrderFound As Boolean = False
            Dim InternetOrder As AdvantageFramework.Database.Entities.InternetOrder = Nothing
            Dim MagazineOrder As AdvantageFramework.Database.Entities.MagazineOrder = Nothing
            Dim NewspaperOrder As AdvantageFramework.Database.Entities.NewspaperOrder = Nothing
            Dim OutOfHomeOrder As AdvantageFramework.Database.Entities.OutOfHomeOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing

            Select Case MediaType

                Case "I"

                    InternetOrder = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If InternetOrder IsNot Nothing Then

                        ClientName = InternetOrder.Product.Client.Name
                        VendorName = InternetOrder.Vendor.Name
                        OrderFound = True

                    End If

                Case "M"

                    MagazineOrder = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If MagazineOrder IsNot Nothing Then

                        ClientName = MagazineOrder.Product.Client.Name
                        VendorName = MagazineOrder.Vendor.Name
                        OrderFound = True

                    End If

                Case "N"

                    NewspaperOrder = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If NewspaperOrder IsNot Nothing Then

                        ClientName = NewspaperOrder.Product.Client.Name
                        VendorName = NewspaperOrder.Vendor.Name
                        OrderFound = True

                    End If

                Case "O"

                    OutOfHomeOrder = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If OutOfHomeOrder IsNot Nothing Then

                        ClientName = OutOfHomeOrder.Product.Client.Name
                        VendorName = OutOfHomeOrder.Vendor.Name
                        OrderFound = True

                    End If

                Case "R"

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If RadioOrder IsNot Nothing Then

                        ClientName = RadioOrder.Product.Client.Name
                        VendorName = RadioOrder.Vendor.Name
                        OrderFound = True

                    End If

                Case "T"

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing Then

                        ClientName = TVOrder.Product.Client.Name
                        VendorName = TVOrder.Vendor.Name
                        OrderFound = True

                    End If

            End Select

            GetOrderClientAndVendor = OrderFound

        End Function
        Private Function GetRevisedBy(UserCode As String, OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType) As String

            Dim RevisedBy As String = Nothing

            If OrderStatusType = Database.Entities.Methods.OrderStatusType.OrderRecieved OrElse
                    OrderStatusType = Database.Entities.Methods.OrderStatusType.MakegoodOfferSubmitted OrElse
                    OrderStatusType = Database.Entities.Methods.OrderStatusType.OrderAccepted OrElse
                    OrderStatusType = Database.Entities.Methods.OrderStatusType.OrderRejected Then

                RevisedBy = Nothing

            Else

                RevisedBy = UserCode

            End If


            GetRevisedBy = RevisedBy

        End Function
        Public Sub AddUpdateOrderStatus(MediaType As String, OrderNumber As Integer, ConnectionString As String, UserCode As String, SalesRep As String, OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType,
                                        Optional OrderLineNumbers As IEnumerable(Of Integer) = Nothing)

            'objects
            Dim MediaManagerGeneratedReportDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail) = Nothing
            Dim RadioOrderDetail As AdvantageFramework.Database.Entities.RadioOrderDetail = Nothing
            Dim RadioOrderStatus As AdvantageFramework.Database.Entities.RadioOrderStatus = Nothing
            Dim TVOrderDetail As AdvantageFramework.Database.Entities.TVOrderDetail = Nothing
            Dim TVOrderStatus As AdvantageFramework.Database.Entities.TVOrderStatus = Nothing
            Dim RevisedDate As Date = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                For Each MediaManagerGeneratedReportDetail In (From MMGR In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.Load(DbContext)
                                                               Where MMGR.MediaManagerGeneratedReport.OrderNumber = OrderNumber
                                                               Group MMGR By MMGR.LineNumber Into Group
                                                               Select New With {.LineNumber = LineNumber,
                                                                                .RevisionNumber = Group.Max(Function(Entity) Entity.RevisionNumber)}).ToList

                    If OrderLineNumbers Is Nothing OrElse OrderLineNumbers.Contains(MediaManagerGeneratedReportDetail.LineNumber) Then

                        If MediaType = "R" Then

                            RadioOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                                Where Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber 'AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                                Select Entity).SingleOrDefault

                            If RadioOrderDetail IsNot Nothing Then

                                RadioOrderStatus = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, RadioOrderDetail.LineNumber)
                                                    Where Entity.OrderStatusID = OrderStatusType AndAlso
                                                          Entity.RevisionNumber = RadioOrderDetail.RevisionNumber
                                                    Select Entity).SingleOrDefault

                                If RadioOrderStatus IsNot Nothing Then

                                    If OrderStatusType <> Database.Entities.Methods.OrderStatusType.OrderRecieved Then

                                        RadioOrderStatus.RevisedDate = RevisedDate
                                        RadioOrderStatus.RevisedByName = SalesRep
                                        RadioOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                        DbContext.TryAttach(RadioOrderStatus)

                                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.RadioOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, RadioOrderDetail.LineNumber)
                                            Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated AndAlso
                                                  Entity.RevisionNumber = RadioOrderDetail.RevisionNumber AndAlso
                                                  Entity.RevisedDate > RadioOrderStatus.RevisedDate
                                            Select Entity).Any Then

                                        RadioOrderStatus.RevisedDate = RevisedDate
                                        RadioOrderStatus.RevisedByName = SalesRep
                                        RadioOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                        DbContext.TryAttach(RadioOrderStatus)

                                    End If

                                Else

                                    RadioOrderStatus = New AdvantageFramework.Database.Entities.RadioOrderStatus
                                    RadioOrderStatus.DbContext = DbContext

                                    RadioOrderStatus.OrderNumber = OrderNumber
                                    RadioOrderStatus.LineNumber = RadioOrderDetail.LineNumber
                                    RadioOrderStatus.RevisionNumber = RadioOrderDetail.RevisionNumber
                                    RadioOrderStatus.OrderStatusID = OrderStatusType
                                    RadioOrderStatus.RevisedDate = RevisedDate
                                    RadioOrderStatus.RevisedByName = SalesRep
                                    RadioOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                    DbContext.RadioOrderStatuses.Add(RadioOrderStatus)

                                End If

                            End If

                        ElseIf MediaType = "T" Then

                            TVOrderDetail = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                             Where Entity.LineNumber = MediaManagerGeneratedReportDetail.LineNumber 'AndAlso Entity.RevisionNumber = MediaManagerGeneratedReportDetail.RevisionNumber
                                             Select Entity).SingleOrDefault

                            If TVOrderDetail IsNot Nothing Then

                                TVOrderStatus = (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, TVOrderDetail.LineNumber)
                                                 Where Entity.OrderStatusID = OrderStatusType AndAlso
                                                       Entity.RevisionNumber = TVOrderDetail.RevisionNumber
                                                 Select Entity).SingleOrDefault

                                If TVOrderStatus IsNot Nothing Then

                                    If OrderStatusType <> Database.Entities.Methods.OrderStatusType.OrderRecieved Then

                                        TVOrderStatus.RevisedDate = RevisedDate
                                        TVOrderStatus.RevisedByName = SalesRep
                                        TVOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                        DbContext.TryAttach(TVOrderStatus)

                                    ElseIf (From Entity In AdvantageFramework.Database.Procedures.TVOrderStatus.LoadByOrderNumberAndLineNumber(DbContext, OrderNumber, TVOrderDetail.LineNumber)
                                            Where Entity.OrderStatusID = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated AndAlso
                                                  Entity.RevisionNumber = TVOrderDetail.RevisionNumber AndAlso
                                                  Entity.RevisedDate > TVOrderStatus.RevisedDate
                                            Select Entity).Any Then

                                        TVOrderStatus.RevisedDate = RevisedDate
                                        TVOrderStatus.RevisedByName = SalesRep
                                        TVOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                        DbContext.TryAttach(TVOrderStatus)

                                    End If

                                Else

                                    TVOrderStatus = New AdvantageFramework.Database.Entities.TVOrderStatus
                                    TVOrderStatus.DbContext = DbContext

                                    TVOrderStatus.OrderNumber = OrderNumber
                                    TVOrderStatus.LineNumber = TVOrderDetail.LineNumber
                                    TVOrderStatus.RevisionNumber = TVOrderDetail.RevisionNumber
                                    TVOrderStatus.OrderStatusID = OrderStatusType
                                    TVOrderStatus.RevisedDate = RevisedDate
                                    TVOrderStatus.RevisedByName = SalesRep
                                    TVOrderStatus.RevisedByUserCode = GetRevisedBy(UserCode, OrderStatusType)

                                    DbContext.TVOrderStatuses.Add(TVOrderStatus)

                                End If

                            End If

                        End If

                    End If

                Next

                DbContext.SaveChanges()

            End Using

        End Sub
        Private Sub AddToMediaManagerGeneratedReportDetail(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, LineNumber As Integer, RevisionNumber As Integer)

            Dim MediaManagerGeneratedReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedReport = Nothing
            Dim MediaManagerGeneratedReportDetail As AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail = Nothing

            If (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReportDetail.Load(DbContext).Include("MediaManagerGeneratedReport")
                Where Entity.MediaManagerGeneratedReport.OrderNumber = OrderNumber AndAlso
                      Entity.LineNumber = LineNumber AndAlso
                      Entity.RevisionNumber = RevisionNumber).Any = False Then

                MediaManagerGeneratedReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                                               Where Entity.OrderNumber = OrderNumber
                                               Select Entity).OrderByDescending(Function(MMGR) MMGR.ID).FirstOrDefault

                If MediaManagerGeneratedReport IsNot Nothing Then

                    MediaManagerGeneratedReportDetail = New AdvantageFramework.Database.Entities.MediaManagerGeneratedReportDetail
                    MediaManagerGeneratedReportDetail.DbContext = DbContext

                    MediaManagerGeneratedReportDetail.MediaManagerGeneratedReportID = MediaManagerGeneratedReport.ID
                    MediaManagerGeneratedReportDetail.LineNumber = LineNumber
                    MediaManagerGeneratedReportDetail.RevisionNumber = RevisionNumber
                    MediaManagerGeneratedReportDetail.IsCancelled = False

                    DbContext.MediaManagerGeneratedReportDetails.Add(MediaManagerGeneratedReportDetail)
                    DbContext.SaveChanges()

                End If

            End If

        End Sub
        Private Sub RefreshOrderLineStatusAndAcceptanceDetails(DbContext As AdvantageFramework.Database.DbContext, ByRef MediaManagerReviewDetail As AdvantageFramework.MediaManager.Classes.MediaManagerReviewDetail)

            MediaManagerReviewDetail.OrderLineStatus = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 OS.STATUS_DESC 
							                                                                                 FROM
								                                                                                (
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.INTERNET_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                UNION
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.MAGAZINE_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                UNION
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.NEWSPAPER_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                UNION
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.OUTDOOR_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                UNION
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.RADIO_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                UNION
								                                                                                SELECT REC_ID, ORDER_NBR, LINE_NBR, REV_NBR, [STATUS], REVISED_DATE FROM dbo.TV_ORDER_STATUS WHERE [STATUS] <> 11
								                                                                                ) Statuses
									                                                                                INNER JOIN dbo.ORDER_STATUS OS ON Statuses.[STATUS] = OS.[STATUS] 
							                                                                                 WHERE ORDER_NBR = {0} and LINE_NBR = {1} AND REV_NBR = {2}
							                                                                                 ORDER BY REVISED_DATE DESC, REC_ID DESC", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber, MediaManagerReviewDetail.RevisionNumber)).FirstOrDefault

            MediaManagerReviewDetail.AcceptanceDetails = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 'Rev ' + CAST(Statuses.REV_NBR as varchar) + ' - ' + convert(varchar, Statuses.REVISED_DATE, 101) + ' ' + ltrim(right(convert(varchar(32),Statuses.REVISED_DATE,100),8)) + ' - by ' + Statuses.REVISED_BY_NAME
								                                                                               FROM
									                                                                                (
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.INTERNET_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                UNION
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.MAGAZINE_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                UNION
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.NEWSPAPER_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                UNION
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.OUTDOOR_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                UNION
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.RADIO_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                UNION
									                                                                                SELECT ORDER_NBR, LINE_NBR, REV_NBR, REVISED_DATE, REVISED_BY_NAME FROM dbo.TV_ORDER_STATUS WHERE [STATUS] = 5 AND ORDER_NBR = {0} and LINE_NBR = {1}
									                                                                                ) Statuses
								                                                                               ORDER BY REVISED_DATE DESC", MediaManagerReviewDetail.OrderNumber, MediaManagerReviewDetail.LineNumber)).FirstOrDefault

        End Sub

#End Region

#Region "  Purchase Orders "

        Public Function CreateUpdateVCCCardsForPurchaseOrders(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)) As Boolean

            'objects
            Dim CreateUpdateVCCCards As Boolean = True
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing
            Dim AddMediaManagerGeneratePurchaseOrderVendorContacts As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) = Nothing
            Dim UpdateVCCCardPOs As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO) = Nothing
            Dim ErrorMessage As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AddMediaManagerGeneratePurchaseOrderVendorContacts = New Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact)
                UpdateVCCCardPOs = New Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO)

                For Each MediaManagerGeneratePurchaseOrderVendorContact In MediaManagerGeneratePurchaseOrderVendorContacts

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, MediaManagerGeneratePurchaseOrderVendorContact.VendorCode)

                    If Vendor IsNot Nothing Then

                        If Vendor.VCCStatus.HasValue AndAlso Vendor.VCCStatus = AdvantageFramework.Database.Entities.VCCStatuses.Accepted AndAlso Vendor.SendVCCWithMediaOrder Then

                            If MediaManagerGeneratePurchaseOrderVendorContact.POAmount > 0 Then

                                VCCCardPO = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPO.Load(DbContext)
                                             Where Entity.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber
                                             Select Entity).SingleOrDefault

                                If VCCCardPO Is Nothing Then

                                    AddMediaManagerGeneratePurchaseOrderVendorContacts.Add(MediaManagerGeneratePurchaseOrderVendorContact)

                                Else

                                    VCCCardPO.CardAmount = MediaManagerGeneratePurchaseOrderVendorContact.POAmount
                                    UpdateVCCCardPOs.Add(VCCCardPO)

                                End If

                            End If

                        End If

                    End If

                Next

            End Using

            If AddMediaManagerGeneratePurchaseOrderVendorContacts IsNot Nothing AndAlso AddMediaManagerGeneratePurchaseOrderVendorContacts.Count > 0 Then

                AdvantageFramework.VCC.CreateVCCCreditCard(Session, AddMediaManagerGeneratePurchaseOrderVendorContacts, 99)

            End If

            If UpdateVCCCardPOs IsNot Nothing AndAlso UpdateVCCCardPOs.Count > 0 Then

                CreateUpdateVCCCards = AdvantageFramework.VCC.UpdateVCCCreditCard(Session, UpdateVCCCardPOs, ErrorMessage)

            End If

            CreateUpdateVCCCardsForPurchaseOrders = CreateUpdateVCCCards

        End Function
        Public Function CreateUpdateGeneratedPOReport(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContact As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) As Integer

            'objects
            Dim MediaManagerGeneratedPOReportID As Integer = 0
            Dim MediaManagerGeneratedPOReport As AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerGeneratedPOReport = (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedPOReport.Load(DbContext)
                                                 Where Entity.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber
                                                 Select Entity).SingleOrDefault

                If MediaManagerGeneratedPOReport IsNot Nothing Then

                    MediaManagerGeneratedPOReportID = MediaManagerGeneratedPOReport.ID

                    MediaManagerGeneratedPOReport.PORevision = MediaManagerGeneratePurchaseOrderVendorContact.Revision
                    MediaManagerGeneratedPOReport.VendorContactCode = MediaManagerGeneratePurchaseOrderVendorContact.VendorContactCode
                    MediaManagerGeneratedPOReport.Email = MediaManagerGeneratePurchaseOrderVendorContact.VendorContactEmail
                    MediaManagerGeneratedPOReport.LastGeneratedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                    AdvantageFramework.Database.Procedures.MediaManagerGeneratedPOReport.Update(DbContext, MediaManagerGeneratedPOReport, "")

                Else

                    MediaManagerGeneratedPOReport = New AdvantageFramework.Database.Entities.MediaManagerGeneratedPOReport

                    MediaManagerGeneratedPOReport.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber
                    MediaManagerGeneratedPOReport.CreatedByUserCode = Session.UserCode
                    MediaManagerGeneratedPOReport.CreatedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                    MediaManagerGeneratedPOReport.PORevision = MediaManagerGeneratePurchaseOrderVendorContact.Revision
                    MediaManagerGeneratedPOReport.VendorContactCode = MediaManagerGeneratePurchaseOrderVendorContact.VendorContactCode
                    MediaManagerGeneratedPOReport.Email = MediaManagerGeneratePurchaseOrderVendorContact.VendorContactEmail
                    MediaManagerGeneratedPOReport.LastGeneratedDate = MediaManagerGeneratedPOReport.CreatedDate

                    DbContext.MediaManagerGeneratedPOReports.Add(MediaManagerGeneratedPOReport)

                    If DbContext.SaveChanges() > 0 Then

                        MediaManagerGeneratedPOReportID = MediaManagerGeneratedPOReport.ID

                    End If

                End If


            End Using

            CreateUpdateGeneratedPOReport = MediaManagerGeneratedPOReportID

        End Function
        Public Function SetPurchaseOrderStatusGenerated(Session As AdvantageFramework.Security.Session, MediaManagerGeneratePurchaseOrderVendorContact As AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrderVendorContact) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim PurchaseOrderStatus As AdvantageFramework.Database.Entities.PurchaseOrderStatus = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderGenerated
            Dim RevisionNumber As Short = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RevisionNumber = MediaManagerGeneratePurchaseOrderVendorContact.Revision.GetValueOrDefault(0)

                PurchaseOrderStatus = (From Entity In DbContext.PurchaseOrderStatuses
                                       Where Entity.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber AndAlso
                                             Entity.RevisionNumber = RevisionNumber AndAlso
                                             Entity.OrderStatusID = OrderStatusType
                                       Select Entity).SingleOrDefault

                If PurchaseOrderStatus Is Nothing Then

                    PurchaseOrderStatus = New AdvantageFramework.Database.Entities.PurchaseOrderStatus

                    PurchaseOrderStatus.PONumber = MediaManagerGeneratePurchaseOrderVendorContact.PONumber
                    PurchaseOrderStatus.RevisionNumber = RevisionNumber
                    PurchaseOrderStatus.OrderStatusID = OrderStatusType
                    PurchaseOrderStatus.RevisedByUserCode = Session.UserCode
                    PurchaseOrderStatus.RevisedByName = Session.EmployeeName
                    PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                    DbContext.PurchaseOrderStatuses.Add(PurchaseOrderStatus)

                Else

                    PurchaseOrderStatus.RevisedByUserCode = Session.UserCode
                    PurchaseOrderStatus.RevisedByName = Session.EmployeeName
                    PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                    DbContext.Entry(PurchaseOrderStatus).State = Entity.EntityState.Modified

                End If

                'GenerateOrder.GetMediaManagerReviewDetail.OrderLineStatus = AdvantageFramework.StringUtilities.GetNameAsWords(OrderStatusType.ToString)

                DbContext.SaveChanges()

                OrderStatusSet = True

            End Using

            SetPurchaseOrderStatusGenerated = OrderStatusSet

        End Function
        Public Function SetPurchaseOrderStatusOrderRecieved(DbContext As AdvantageFramework.Database.DbContext, PONumber As Integer, RevisionNumber As Short, UserCode As String) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim PurchaseOrderStatus As AdvantageFramework.Database.Entities.PurchaseOrderStatus = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderRecieved
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = String.Empty

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, UserCode)

            If Employee IsNot Nothing Then

                EmployeeName = Employee.FirstName & " " & Employee.LastName

            End If

            PurchaseOrderStatus = (From Entity In DbContext.PurchaseOrderStatuses
                                   Where Entity.PONumber = PONumber AndAlso
                                             Entity.RevisionNumber = RevisionNumber AndAlso
                                             Entity.OrderStatusID = OrderStatusType
                                   Select Entity).SingleOrDefault

            If PurchaseOrderStatus Is Nothing Then

                PurchaseOrderStatus = New AdvantageFramework.Database.Entities.PurchaseOrderStatus

                PurchaseOrderStatus.PONumber = PONumber
                PurchaseOrderStatus.RevisionNumber = RevisionNumber
                PurchaseOrderStatus.OrderStatusID = OrderStatusType
                PurchaseOrderStatus.RevisedByUserCode = DbContext.UserCode
                PurchaseOrderStatus.RevisedByName = EmployeeName
                PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                DbContext.PurchaseOrderStatuses.Add(PurchaseOrderStatus)

            Else

                PurchaseOrderStatus.RevisedByUserCode = DbContext.UserCode
                PurchaseOrderStatus.RevisedByName = EmployeeName
                PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                DbContext.Entry(PurchaseOrderStatus).State = Entity.EntityState.Modified

            End If

            DbContext.SaveChanges()

            OrderStatusSet = True

            SetPurchaseOrderStatusOrderRecieved = OrderStatusSet

        End Function
        Public Function SetPurchaseOrderStatusOrderAccepted(DbContext As AdvantageFramework.Database.DbContext, PONumber As Integer, RevisionNumber As Short, RevisedByName As String) As Boolean

            'objects
            Dim OrderStatusSet As Boolean = False
            Dim PurchaseOrderStatus As AdvantageFramework.Database.Entities.PurchaseOrderStatus = Nothing
            Dim OrderStatusType As AdvantageFramework.Database.Entities.OrderStatusType = AdvantageFramework.Database.Entities.OrderStatusType.OrderAccepted

            PurchaseOrderStatus = (From Entity In DbContext.PurchaseOrderStatuses
                                   Where Entity.PONumber = PONumber AndAlso
                                         Entity.RevisionNumber = RevisionNumber AndAlso
                                         Entity.OrderStatusID = OrderStatusType
                                   Select Entity).SingleOrDefault

            If PurchaseOrderStatus Is Nothing Then

                PurchaseOrderStatus = New AdvantageFramework.Database.Entities.PurchaseOrderStatus

                PurchaseOrderStatus.PONumber = PONumber
                PurchaseOrderStatus.RevisionNumber = RevisionNumber
                PurchaseOrderStatus.OrderStatusID = OrderStatusType
                PurchaseOrderStatus.RevisedByUserCode = DbContext.UserCode
                PurchaseOrderStatus.RevisedByName = RevisedByName
                PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                DbContext.PurchaseOrderStatuses.Add(PurchaseOrderStatus)

            Else

                PurchaseOrderStatus.RevisedByUserCode = DbContext.UserCode
                PurchaseOrderStatus.RevisedByName = RevisedByName
                PurchaseOrderStatus.RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTime(DbContext)

                DbContext.Entry(PurchaseOrderStatus).State = Entity.EntityState.Modified

            End If

            DbContext.SaveChanges()

            OrderStatusSet = True

            SetPurchaseOrderStatusOrderAccepted = OrderStatusSet

        End Function
        Public Sub SetPrintedPOFlag(Session As AdvantageFramework.Security.Session, PONumber As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PURCHASE_ORDER SET PO_PRINTED = 1 WHERE PO_NUMBER = {0}", PONumber))

            End Using

        End Sub

#End Region

#End Region

#End Region

    End Module

End Namespace
