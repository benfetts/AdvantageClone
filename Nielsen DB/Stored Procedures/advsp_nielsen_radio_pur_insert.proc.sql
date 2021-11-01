﻿CREATE PROCEDURE [dbo].[advsp_nielsen_radio_pur_insert]
	@NIELSEN_RADIO_PERIOD_ID int,
	@GEO_INDICATOR smallint
AS

INSERT INTO [dbo].[NIELSEN_RADIO_PUR]
           ([NIELSEN_RADIO_SEGMENT_PARENT_ID],[NIELSEN_RADIO_SEGMENT_CHILD_ID],[FEMALES_6TO11_PUR],[FEMALES_12TO17_PUR]
           ,[FEMALES_18TO20_PUR],[FEMALES_18TO24_PUR],[FEMALES_21TO24_PUR],[FEMALES_25TO34_PUR],[FEMALES_35TO44_PUR]
           ,[FEMALES_35TO49_PUR],[FEMALES_45TO49_PUR],[FEMALES_50TO54_PUR],[FEMALES_55TO64_PUR],[FEMALES_65PLUS_PUR]
           ,[MALES_6TO11_PUR],[MALES_12TO17_PUR],[MALES_18TO20_PUR],[MALES_18TO24_PUR],[MALES_21TO24_PUR]
           ,[MALES_25TO34_PUR],[MALES_35TO44_PUR],[MALES_35TO49_PUR],[MALES_45TO49_PUR],[MALES_50TO54_PUR]
           ,[MALES_55TO64_PUR],[MALES_65PLUS_PUR])
SELECT 
			NIELSEN_RADIO_SEGMENT_PARENT_ID, NIELSEN_RADIO_SEGMENT_CHILD_ID,COALESCE([FEMALES_6TO11_PUR],0),COALESCE([FEMALES_12TO17_PUR],0),
			COALESCE([FEMALES_18TO20_PUR],0),COALESCE([FEMALES_18TO24_PUR],0),COALESCE([FEMALES_21TO24_PUR],0),COALESCE([FEMALES_25TO34_PUR],0),COALESCE([FEMALES_35TO44_PUR],0),
			COALESCE([FEMALES_35TO49_PUR],0),COALESCE([FEMALES_45TO49_PUR],0),COALESCE([FEMALES_50TO54_PUR],0),COALESCE([FEMALES_55TO64_PUR],0),COALESCE([FEMALES_65PLUS_PUR],0),
			COALESCE([MALES_6TO11_PUR],0),COALESCE([MALES_12TO17_PUR],0),COALESCE([MALES_18TO20_PUR],0),COALESCE([MALES_18TO24_PUR],0),COALESCE([MALES_21TO24_PUR],0),
			COALESCE([MALES_25TO34_PUR],0),COALESCE([MALES_35TO44_PUR],0),COALESCE([MALES_35TO49_PUR],0),COALESCE([MALES_45TO49_PUR],0),COALESCE([MALES_50TO54_PUR],0),
			COALESCE([MALES_55TO64_PUR],0),COALESCE([MALES_65PLUS_PUR],0)
FROM (
		SELECT
			NIELSEN_RADIO_SEGMENT_PARENT_ID = (
												SELECT NIELSEN_RADIO_SEGMENT_PARENT_ID 
												FROM dbo.NIELSEN_RADIO_SEGMENT_PARENT
												WHERE NIELSEN_RADIO_PERIOD_ID = @NIELSEN_RADIO_PERIOD_ID
												AND GEO_INDICATOR = @GEO_INDICATOR
												AND NIELSEN_RADIO_QUALITATIVE_ID = q.NIELSEN_RADIO_QUALITATIVE_ID 
												),
			s.NIELSEN_RADIO_SEGMENT_CHILD_ID,
			[Demographic] = dbo.[advfn_nielsen_radio_columnname_pur](q.CODE,DEMO_ID),
			[PUR] = CASE 
						WHEN q.CODE = 'All' AND DEMO_ID = 1 THEN PUR_AUD 
						WHEN q.CODE = 'All' AND DEMO_ID = 3 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 4 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 5 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 6 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 7 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 8 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 10 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 11 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 12 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 13 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 14 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 15 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 82 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 251 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 254 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 255 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 264 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 267 THEN PUR_AUD
						WHEN q.CODE = 'All' AND DEMO_ID = 268 THEN PUR_AUD

						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 448 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 461 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 479 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 488 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 501 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 514 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 533 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 544 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 561 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 570 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 583 THEN PUR_AUD
						WHEN q.CODE = 'CHILDREN' AND DEMO_ID = 596 THEN PUR_AUD
						
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 441 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 455 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 469 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 483 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 496 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 509 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 526 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 539 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 552 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 565 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 578 THEN PUR_AUD
						WHEN q.CODE = 'COLLEGE +' AND DEMO_ID = 591 THEN PUR_AUD
						
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 449 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 463 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 473 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 490 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 503 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 516 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 534 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 546 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 556 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 572 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 585 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 1' AND DEMO_ID = 598 THEN PUR_AUD
						
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 450 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 464 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 474 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 491 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 504 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 517 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 530 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 531 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 547 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 573 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 586 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 2' AND DEMO_ID = 599 THEN PUR_AUD
						
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 451 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 465 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 475 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 492 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 505 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 518 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 535 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 548 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 557 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 574 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 587 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 3' AND DEMO_ID = 600 THEN PUR_AUD
						
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 452 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 466 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 476 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 493 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 506 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 519 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 536 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 549 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 558 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 575 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 588 THEN PUR_AUD
						WHEN q.CODE = 'HH SIZE 4+' AND DEMO_ID = 601 THEN PUR_AUD
						
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 453 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 467 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 481 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 494 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 507 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 520 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 537 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 550 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 563 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 576 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 589 THEN PUR_AUD
						WHEN q.CODE = 'HS GRAD' AND DEMO_ID = 602 THEN PUR_AUD
						
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 460 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 472 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 478 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 487 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 500 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 513 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 541 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 555 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 560 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 569 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 582 THEN PUR_AUD
						WHEN q.CODE = 'INC $75K+' AND DEMO_ID = 595 THEN PUR_AUD

						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 442 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 456 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 470 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 484 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 497 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 510 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 527 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 540 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 553 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 566 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 579 THEN PUR_AUD
						WHEN q.CODE = 'INC <$25K' AND DEMO_ID = 592 THEN PUR_AUD
								
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 443 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 458 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 471 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 485 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 498 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 511 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 528 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 542 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 554 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 567 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 580 THEN PUR_AUD
						WHEN q.CODE = 'INC 25-49K' AND DEMO_ID = 593 THEN PUR_AUD
								
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 444 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 459 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 477 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 486 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 499 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 512 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 529 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 543 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 559 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 568 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 581 THEN PUR_AUD
						WHEN q.CODE = 'INC 50-74K' AND DEMO_ID = 594 THEN PUR_AUD
								
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 447 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 462 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 480 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 489 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 502 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 515 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 532 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 545 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 562 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 571 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 584 THEN PUR_AUD
						WHEN q.CODE = 'NO CHILDRN' AND DEMO_ID = 597 THEN PUR_AUD
							
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 440 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 454 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 468 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 482 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 495 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 508 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 524 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 538 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 551 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 564 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 577 THEN PUR_AUD
						WHEN q.CODE = 'SOME COLL' AND DEMO_ID = 590 THEN PUR_AUD
									
					END
		FROM dbo.NIELSEN_RADIO_V_STAGING s
			INNER JOIN dbo.NIELSEN_RADIO_DEMOGRAPHIC d ON s.DEMO_ID = d.NUMBER 
			INNER JOIN dbo.NIELSEN_RADIO_QUALITATIVE q ON q.CODE = d.QUALITATIVE_CODE 
		WHERE s.ESTIMATE_TYPE = 1 
		AND s.STATION_COMBO_ID = '999999'
		AND s.GEO_INDICATOR = @GEO_INDICATOR
		) sourcetable
PIVOT
	(
	SUM(PUR)
	FOR [Demographic] IN ([FEMALES_6TO11_PUR],[FEMALES_12TO17_PUR],[FEMALES_18TO20_PUR],[FEMALES_18TO24_PUR],[FEMALES_21TO24_PUR],
						[FEMALES_25TO34_PUR],[FEMALES_35TO44_PUR],[FEMALES_35TO49_PUR],[FEMALES_45TO49_PUR],[FEMALES_50TO54_PUR],[FEMALES_55TO64_PUR],[FEMALES_65PLUS_PUR],
						[MALES_6TO11_PUR],[MALES_12TO17_PUR],[MALES_18TO20_PUR],[MALES_18TO24_PUR],[MALES_21TO24_PUR],
						[MALES_25TO34_PUR],[MALES_35TO44_PUR],[MALES_35TO49_PUR],[MALES_45TO49_PUR],[MALES_50TO54_PUR],[MALES_55TO64_PUR],[MALES_65PLUS_PUR])
	) as p
GO

GRANT EXEC ON [advsp_nielsen_radio_pur_insert] TO PUBLIC
GO