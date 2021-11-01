CREATE PROCEDURE dbo.advsp_traffic_schedule_UpdatePredsByLevel
	@JobNumber Int,
	@JobComponentNumber Smallint,
	@SequenceNumber Smallint,
	@PredLevelList varchar(max)
AS
BEGIN
		
	Declare @PredTable Table (SequenceNumber smallint,
							  [Level] varchar(50),
							  PredExists bit)

	If Exists (Select
					*
				From 
					dbo.advtf_traffic_schedule_GetHierarchyDates(@JobNumber, @JobComponentNumber) ht
				Where
					ht.SEQ_NBR = @SequenceNumber And
					ht.HAS_CHILDREN = 0)
	Begin

		Select @PredLevelList = REPLACE(@PredLevelList, ' ', '')

		Insert Into @PredTable
		Select 
			HT.SEQ_NBR,
			HT.[LEVEL],
			0
		From 
			dbo.udf_split_list(@PredLevelList, ',') Pred
		Join
			dbo.advtf_traffic_schedule_GetHierarchyDates(@JobNumber, @JobComponentNumber) HT On Pred.items = HT.[LEVEL]
		Where
			HT.HAS_CHILDREN = 0 And -- Parent tasks cannot be nor have a predecessor!
			HT.SEQ_NBR <> @SequenceNumber -- Cannot make task predecessor of itself!


		-- Remove Predecessors that do not exist in current list
		Delete From	
			dbo.JOB_TRAFFIC_DET_PREDS
		Where
			JOB_NUMBER = @JobNumber And
			JOB_COMPONENT_NBR = @JobComponentNumber And
			SEQ_NBR = @SequenceNumber And
			PREDECESSOR_SEQ_NBR Not In (Select
											SequenceNumber
										From
											@PredTable)

		Update
			@PredTable
		Set
			PredExists = 1
		Where	
			SequenceNumber In (Select 
									PREDECESSOR_SEQ_NBR
								From
									dbo.JOB_TRAFFIC_DET_PREDS
								Where	
									JOB_NUMBER = @JobNumber And
									JOB_COMPONENT_NBR = @JobComponentNumber And
									SEQ_NBR = @SequenceNumber)

		-- only seqNum left in @PredTable should be those not in db. Create them.
		Insert Into 
			dbo.JOB_TRAFFIC_DET_PREDS (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, PREDECESSOR_SEQ_NBR)
		Select
			@JobNumber,
			@JobComponentNumber,
			@SequenceNumber,
			Pt.SequenceNumber
		From 
			@PredTable Pt 
		Join
			dbo.advtf_traffic_schedule_GetHierarchyDates(@JobNumber, @JobComponentNumber) HT ON Pt.SequenceNumber = HT.SEQ_NBR 
		Where
			HT.HAS_CHILDREN = 0 AND -- parent tasks cannot be nor have predecessors!
			Pt.PredExists = 0 -- Only create those that do not exist

	End

	Select * From @PredTable

END