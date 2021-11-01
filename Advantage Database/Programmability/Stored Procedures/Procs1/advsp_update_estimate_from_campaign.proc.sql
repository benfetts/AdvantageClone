if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_update_estimate_from_campaign]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_update_estimate_from_campaign]
GO

CREATE PROCEDURE [dbo].[advsp_update_estimate_from_campaign] 
(
@JobNumber int,
@JobComponentNumber smallint,
@EstimateNumber int,
@EstimateComponentNunber int,
@EstimateQuote int,
@EstimateRevision int
)
AS

DECLARE @Campaign_Code varchar(6), @JobNumber_Master int, @JobComponentNumber_Master smallint, @FunctionCode varchar(6), @FunctionType varchar(1),
		@CPM int, @Qty decimal(15,2), @Rate decimal(15,4), @ExtAmount decimal(15,2), @TaxCode varchar(4), @MarkupPct decimal(9,3), @ContPct decimal(6,3),
		@CPU int, @TaxStatePct decimal(7,4), @TaxCountyPct decimal(7,4), @TaxCityPct decimal(7,4), @TaxComm int, @TaxCommOnly int, @TaxResale int,
		@MarkupAmount decimal(14,2), @ContAmount decimal(14,2), @ContMUAmount decimal(14,2),
		@LineTotalCont decimal(14,2), @LineTotal decimal(14,2), @TaxResaleState decimal(14,2), @TaxResaleCounty decimal(14,2), @TaxResaleCity decimal(14,2),
		@TaxMarkupState decimal(14,2), @TaxMarkupCounty decimal(14,2), @TaxMarkupCity decimal(14,2), @TaxContState decimal(14,2), @TaxContCounty decimal(14,2), @TaxContCity decimal(14,2),
		@TaxNonResaleState decimal(14,2), @TaxNonResaleCounty decimal(14,2), @TaxNonResaleCity decimal(14,2), @SeqNbr int
		
SET @CPM = 0
SET @Qty = 0
SET @Rate = 0
SET @ExtAmount = 0
SET @TaxCode = ''
SET @MarkupPct = 0
SET @ContPct = 0
SET @CPU = 0
SET @TaxStatePct = 0
SET @TaxCountyPct = 0
SET @TaxCityPct = 0
SET @TaxComm = 0 
SET @TaxCommOnly = 0 
SET @TaxResale = 0
SET @MarkupAmount = 0
SET @ContAmount = 0
SET @ContMUAmount = 0
SET @LineTotalCont = 0
SET @LineTotal = 0
SET @TaxResaleState = 0
SET @TaxResaleCounty = 0
SET @TaxResaleCity = 0
SET @TaxMarkupState = 0
SET @TaxMarkupCounty = 0
SET @TaxMarkupCity = 0
SET @TaxContState = 0
SET @TaxContCounty = 0
SET @TaxContCity = 0
SET @TaxNonResaleState = 0
SET @TaxNonResaleCounty = 0
SET @TaxNonResaleCity = 0

SELECT @Campaign_Code = c.CMP_CODE, @JobNumber_Master = c.JOB_NUMBER, @JobComponentNumber_Master = c.JOB_COMPONENT_NBR
  FROM CAMPAIGN c LEFT OUTER JOIN JOB_LOG jl ON jl.CMP_CODE = c.CMP_CODE
WHERE jl.JOB_NUMBER = @JobNumber

if @JobNumber_Master > 0
BEGIN
	DECLARE MY_ROWS                        CURSOR  
        FOR
	        SELECT [FNC_CODE]
	        FROM ESTIMATE_REV_DET
			WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision
        ;
        OPEN MY_ROWS;
        FETCH NEXT FROM MY_ROWS INTO @FunctionCode;
        WHILE @@FETCH_STATUS = 0
        BEGIN
	        UPDATE ESTIMATE_REV_DET 
			SET EST_REV_RATE = (SELECT er.EST_REV_RATE
								 FROM dbo.ESTIMATE_REV_DET er
									INNER JOIN dbo.V_ESTIMATEAPPR ea ON ea.ESTIMATE_NUMBER = er.ESTIMATE_NUMBER
											AND ea.EST_COMPONENT_NBR = er.EST_COMPONENT_NBR 
											AND ea.EST_QUOTE_NBR = er.EST_QUOTE_NBR
											AND ea.EST_REVISION_NBR = er.EST_REV_NBR    
								 WHERE er.SEQ_NBR = (SELECT MAX(er2.SEQ_NBR) FROM dbo.ESTIMATE_REV_DET AS er2
											WHERE er.ESTIMATE_NUMBER = er2.ESTIMATE_NUMBER
											AND er.EST_COMPONENT_NBR = er2.EST_COMPONENT_NBR 
											AND er.EST_QUOTE_NBR = er2.EST_QUOTE_NBR
											AND er.EST_REV_NBR = er2.EST_REV_NBR
											AND er.FNC_CODE = er2.FNC_CODE)
									AND ea.JOB_NUMBER = @JobNumber_Master 
									AND ea.JOB_COMPONENT_NBR = @JobComponentNumber_Master
									AND er.FNC_CODE = @FunctionCode
									)
			WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision AND FNC_CODE = @FunctionCode
			
			--GO TO NEXT EVENT
	        FETCH NEXT FROM MY_ROWS INTO  @FunctionCode;
        END
        CLOSE MY_ROWS;
        DEALLOCATE MY_ROWS;		

		--Update all rows based on rate change.
		DECLARE MY_ROWS_UPDATE                        CURSOR  
        FOR
	        SELECT [FNC_CODE], [SEQ_NBR]
	        FROM ESTIMATE_REV_DET
			WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision;
        OPEN MY_ROWS_UPDATE;
        FETCH NEXT FROM MY_ROWS_UPDATE INTO @FunctionCode, @SeqNbr;
        WHILE @@FETCH_STATUS = 0
        BEGIN
			SELECT @CPM = ISNULL(EST_CPM_FLAG,0), @Qty = EST_REV_QUANTITY, @Rate = E.EST_REV_RATE, @ExtAmount = E.EST_REV_EXT_AMT, @TaxCode = E.TAX_CODE, @MarkupPct = E.EST_REV_COMM_PCT, @ContPct = E.EST_REV_CONT_PCT,
				   @CPU = ISNULL(E.INCL_CPU,0), @TaxStatePct = ISNULL(E.TAX_STATE_PCT, 0.00), @TaxCountyPct = ISNULL(E.TAX_COUNTY_PCT, 0.00), 
                   @TaxCityPct = ISNULL(E.TAX_CITY_PCT, 0.00), @TaxComm = E.TAX_COMM, @TaxCommOnly = E.TAX_COMM_ONLY, @TaxResale = E.TAX_RESALE, @FunctionType = EST_FNC_TYPE
			FROM ESTIMATE_REV_DET E
			WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision AND FNC_CODE = @FunctionCode AND SEQ_NBR = @SeqNbr

			--Select @CPM, @Qty, @Rate, @ExtAmount, @TaxCode, @MarkupPct, @ContPct,
			--	   @CPU, @TaxStatePct, @TaxCountyPct, 
   --                @TaxCityPct, @TaxComm, @TaxCommOnly, @TaxResale, @FunctionType

			if @CPM = 1
				Begin
					SET @ExtAmount = (@Qty / 1000) * @Rate
				End
			Else
				Begin
					SET @ExtAmount = @Qty * @Rate
				End

			if @MarkupPct <> 0
			Begin
				SET @MarkupAmount = @ExtAmount * (@MarkupPct / 100)
			End

			if @ContPct <> 0
			Begin
				SET @ContAmount = @ExtAmount * (@ContPct / 100)
				SET @ContMUAmount = (@MarkupAmount * (@ContPct / 100))
				SET @LineTotalCont = @LineTotalCont + @ContAmount + @ContMUAmount
			End

			If @TaxCode <> ''
			Begin
				if @TaxResale = 1
				Begin
					If @TaxCommOnly <> 1
					Begin
						SET @TaxResaleState = @ExtAmount * (@TaxStatePct / 100)
						SET @TaxResaleCounty = @ExtAmount * (@TaxCountyPct / 100)
						SET @TaxResaleCity = @ExtAmount * (@TaxCityPct / 100)
						SET @LineTotal = @LineTotal + @TaxResaleState + @TaxResaleCounty + @TaxResaleCity
					End
					If @TaxComm = 1
					Begin
						If @MarkupAmount <> 0
						Begin
							SET @TaxMarkupState = @MarkupAmount * (@TaxStatePct / 100)
							SET @TaxMarkupCounty = @MarkupAmount * (@TaxCountyPct / 100)
							SET @TaxMarkupCity = @MarkupAmount * (@TaxCityPct / 100)
							SET @LineTotal = @LineTotal + @TaxMarkupState + @TaxMarkupCounty + @TaxMarkupCity
						End
					End

					If @ContAmount <> 0
					Begin
						If @TaxComm = 1 AND @TaxCommOnly = 1
						Begin
							SET @ContAmount = @ContMUAmount
						End
						Else If @TaxComm = 1
						Begin
							SET @ContAmount = @ContAmount + @ContMUAmount
						End
						SET @TaxContState = @ContAmount * (@TaxStatePct / 100)
						SET @TaxContCounty = @ContAmount * (@TaxCountyPct / 100)
						SET @TaxContCity = @ContAmount * (@TaxCityPct / 100)
						SET @LineTotalCont = @LineTotal + @TaxContState + @TaxContCounty + @TaxContCity
					End
				End
				if @TaxResale <> 1
				Begin
					If @FunctionType = 'V'
					Begin
						If @TaxCommOnly <> 1
						Begin
							SET @TaxNonResaleState = @ExtAmount * (@TaxStatePct / 100)
							SET @TaxNonResaleCounty = @ExtAmount * (@TaxCountyPct / 100)
							SET @TaxNonResaleCity = @ExtAmount * (@TaxCityPct / 100)
							SET @LineTotal = @LineTotal + @TaxNonResaleState + @TaxNonResaleCounty + @TaxNonResaleCity
						End
						If @ContAmount <> 0
						Begin
							If @TaxComm = 1 AND @TaxCommOnly = 1
							Begin
								SET @ContAmount = @ContMUAmount
							End
							Else If @TaxComm = 1
							Begin
								SET @ContAmount = @ContAmount + @ContMUAmount
							End
							SET @TaxContState = @ContAmount * (@TaxStatePct / 100)
							SET @TaxContCounty = @ContAmount * (@TaxCountyPct / 100)
							SET @TaxContCity = @ContAmount * (@TaxCityPct / 100)
							SET @LineTotalCont = @LineTotal + @TaxContState + @TaxContCounty + @TaxContCity
						End
					End
					Else If @FunctionType = 'E' Or @FunctionType = 'I'
					Begin
						If @TaxCommOnly <> 1
						Begin
							SET @TaxResaleState = @ExtAmount * (@TaxStatePct / 100)
							SET @TaxResaleCounty = @ExtAmount * (@TaxCountyPct / 100)
							SET @TaxResaleCity = @ExtAmount * (@TaxCityPct / 100)
							SET @LineTotal = @LineTotal + @TaxResaleState + @TaxResaleCounty + @TaxResaleCity
						End
						If @ContAmount <> 0
						Begin
							If @TaxComm = 1 AND @TaxCommOnly = 1
							Begin
								SET @ContAmount = @ContMUAmount
							End
							Else If @TaxComm = 1
							Begin
								SET @ContAmount = @ContAmount + @ContMUAmount
							End
							SET @TaxContState = @ContAmount * (@TaxStatePct / 100)
							SET @TaxContCounty = @ContAmount * (@TaxCountyPct / 100)
							SET @TaxContCity = @ContAmount * (@TaxCityPct / 100)
							SET @LineTotalCont = @LineTotal + @TaxContState + @TaxContCounty + @TaxContCity
						End
					End
					If @TaxComm = 1
					Begin
						If @MarkupAmount <> 0
						Begin
							SET @TaxMarkupState = @MarkupAmount * (@TaxStatePct / 100)
							SET @TaxMarkupCounty = @MarkupAmount * (@TaxCountyPct / 100)
							SET @TaxMarkupCity = @MarkupAmount * (@TaxCityPct / 100)
							SET @LineTotal = @LineTotal + @TaxMarkupState + @TaxMarkupCounty + @TaxMarkupCity
						End
					End
				End
			End

			UPDATE ESTIMATE_REV_DET 
			SET EST_REV_EXT_AMT = @ExtAmount,
				EXT_MARKUP_AMT = @MarkupAmount,
				EXT_CONTINGENCY = @ContAmount,
				EXT_MU_CONT = @ContMUAmount,
				LINE_TOTAL = @LineTotal,
				LINE_TOTAL_CONT = @LineTotalCont
			WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision AND FNC_CODE = @FunctionCode

			If @TaxCode <> ''
			Begin
				UPDATE ESTIMATE_REV_DET 
				SET EXT_STATE_RESALE = @TaxResaleState + @TaxMarkupState,
					EXT_COUNTY_RESALE = @TaxResaleCounty + @TaxMarkupCounty,
					EXT_CITY_RESALE = @TaxResaleCity + @TaxMarkupCity,
					EXT_STATE_CONT = @TaxContState,
					EXT_COUNTY_CONT = @TaxContCounty,
					EXT_CITY_CONT = @TaxContCity,
					EXT_NONRESALE_TAX = @TaxNonResaleCity + @TaxNonResaleCounty + @TaxNonResaleState,
					EXT_NR_CONT = @TaxContCity + @TaxContCity + @TaxContState
				WHERE ESTIMATE_NUMBER = @EstimateNumber AND EST_COMPONENT_NBR = @EstimateComponentNunber AND EST_QUOTE_NBR = @EstimateQuote AND EST_REV_NBR = @EstimateRevision AND FNC_CODE = @FunctionCode
			End

			SET @CPM = 0 
			SET @Qty = 0
			SET @Rate  = 0
			SET @ExtAmount = 0
			SET @MarkupPct = 0
			SET @ContPct = 0
			SET @CPU = 0
			SET @TaxStatePct = 0
			SET @TaxCountyPct = 0
			SET @TaxCityPct = 0
			SET @TaxComm = 0
			SET @TaxCommOnly = 0
			SET @TaxResale = 0
			SET @MarkupAmount = 0
			SET @ContAmount = 0
			SET @ContMUAmount = 0
			SET @LineTotalCont = 0
			SET @LineTotal = 0
			SET @TaxCode = ''
			SET @TaxResaleState = 0
			SET @TaxResaleCounty = 0
			SET @TaxResaleCity = 0
			SET @TaxMarkupState = 0
			SET @TaxMarkupCounty = 0
			SET @TaxMarkupCity = 0
			SET @TaxContState = 0
			SET @TaxContCounty = 0
			SET @TaxContCity = 0
			SET @TaxNonResaleState = 0
			SET @TaxNonResaleCounty = 0
			SET @TaxNonResaleCity = 0

			--GO TO NEXT EVENT
	        FETCH NEXT FROM MY_ROWS_UPDATE INTO  @FunctionCode, @SeqNbr;
        END
        CLOSE MY_ROWS_UPDATE;
        DEALLOCATE MY_ROWS_UPDATE;

END