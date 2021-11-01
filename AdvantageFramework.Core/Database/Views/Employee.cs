using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdvantageFramework.Core.Database.Views
{
    public partial class Employee
    {
        [Required]
        [Column("EMP_CODE")]
        [StringLength(6)]
        public string EmpCode { get; set; }
        [Column("DP_TM_CODE")]
        [StringLength(4)]
        public string DpTmCode { get; set; }
        [Column("EMP_LNAME")]
        [StringLength(30)]
        public string EmpLname { get; set; }
        [Column("EMP_FNAME")]
        [StringLength(30)]
        public string EmpFname { get; set; }
        [Column("EMP_MI")]
        [StringLength(1)]
        public string EmpMi { get; set; }
        [Column("EMP_COST_RATE", TypeName = "decimal(9, 2)")]
        public decimal? EmpCostRate { get; set; }
        [Column("EMP_ADDRESS1")]
        [StringLength(30)]
        public string EmpAddress1 { get; set; }
        [Column("EMP_ADDRESS2")]
        [StringLength(30)]
        public string EmpAddress2 { get; set; }
        [Column("EMP_ALPHA_SORT")]
        [StringLength(20)]
        public string EmpAlphaSort { get; set; }
        [Column("EMP_CITY")]
        [StringLength(20)]
        public string EmpCity { get; set; }
        [Column("EMP_COUNTRY")]
        [StringLength(20)]
        public string EmpCountry { get; set; }
        [Column("EMP_COUNTY")]
        [StringLength(20)]
        public string EmpCounty { get; set; }
        [Column("EMP_PAY_TO_ADDR1")]
        [StringLength(30)]
        public string EmpPayToAddr1 { get; set; }
        [Column("EMP_PAY_TO_ADDR2")]
        [StringLength(30)]
        public string EmpPayToAddr2 { get; set; }
        [Column("EMP_PAY_TO_CITY")]
        [StringLength(20)]
        public string EmpPayToCity { get; set; }
        [Column("EMP_PAY_TO_COUNTRY")]
        [StringLength(20)]
        public string EmpPayToCountry { get; set; }
        [Column("EMP_PAY_TO_COUNTY")]
        [StringLength(20)]
        public string EmpPayToCounty { get; set; }
        [Column("EMP_PAY_TO_STATE")]
        [StringLength(10)]
        public string EmpPayToState { get; set; }
        [Column("EMP_PAY_TO_ZIP")]
        [StringLength(10)]
        public string EmpPayToZip { get; set; }
        [Column("EMP_PHONE")]
        [StringLength(13)]
        public string EmpPhone { get; set; }
        [Column("EMP_STATE")]
        [StringLength(10)]
        public string EmpState { get; set; }
        [Column("EMP_OTHER_INFO")]
        [StringLength(20)]
        public string EmpOtherInfo { get; set; }
        [Column("EMP_ZIP")]
        [StringLength(10)]
        public string EmpZip { get; set; }
        [Column("EMP_DATE", TypeName = "smalldatetime")]
        public DateTime? EmpDate { get; set; }
        [Column("EMP_TERM_DATE", TypeName = "smalldatetime")]
        public DateTime? EmpTermDate { get; set; }
        [Column("EMP_BIRTH_DATE", TypeName = "smalldatetime")]
        public DateTime? EmpBirthDate { get; set; }
        [Column("EMP_LAST_INCREASE", TypeName = "smalldatetime")]
        public DateTime? EmpLastIncrease { get; set; }
        [Column("EMP_NEXT_REVIEW", TypeName = "smalldatetime")]
        public DateTime? EmpNextReview { get; set; }
        [Column("EMP_ANNUAL_SALARY", TypeName = "decimal(15, 2)")]
        public decimal? EmpAnnualSalary { get; set; }
        [Column("EMP_MONTHLY_SALARY", TypeName = "decimal(11, 2)")]
        public decimal? EmpMonthlySalary { get; set; }
        [Column("EMP_EMAIL")]
        [StringLength(50)]
        public string EmpEmail { get; set; }
        [Column("OFFICE_CODE")]
        [StringLength(4)]
        public string OfficeCode { get; set; }
        [Column("SUPERVISOR_CODE")]
        [StringLength(6)]
        public string SupervisorCode { get; set; }
        [Column("VAC_FROM_DATE", TypeName = "smalldatetime")]
        public DateTime? VacFromDate { get; set; }
        [Column("VAC_TO_DATE", TypeName = "smalldatetime")]
        public DateTime? VacToDate { get; set; }
        [Column("SICK_FROM_DATE", TypeName = "smalldatetime")]
        public DateTime? SickFromDate { get; set; }
        [Column("SICK_TO_DATE", TypeName = "smalldatetime")]
        public DateTime? SickToDate { get; set; }
        [Column("STD_WORK_HRS", TypeName = "decimal(9, 3)")]
        public decimal? StdWorkHrs { get; set; }
        [Column("EMP_WORK_DAYS")]
        [StringLength(30)]
        public string EmpWorkDays { get; set; }
        [Column("EMP_TIME_ALERT")]
        public short? EmpTimeAlert { get; set; }
        [Column("SMTP_SERVER")]
        [StringLength(40)]
        public string SmtpServer { get; set; }
        [Column("EMAIL_PWD")]
        public string EmailPwd { get; set; }
        [Column("MON_HRS", TypeName = "decimal(9, 3)")]
        public decimal? MonHrs { get; set; }
        [Column("TUE_HRS", TypeName = "decimal(9, 3)")]
        public decimal? TueHrs { get; set; }
        [Column("WED_HRS", TypeName = "decimal(9, 3)")]
        public decimal? WedHrs { get; set; }
        [Column("THU_HRS", TypeName = "decimal(9, 3)")]
        public decimal? ThuHrs { get; set; }
        [Column("FRI_HRS", TypeName = "decimal(9, 3)")]
        public decimal? FriHrs { get; set; }
        [Column("SAT_HRS", TypeName = "decimal(9, 3)")]
        public decimal? SatHrs { get; set; }
        [Column("SUN_HRS", TypeName = "decimal(9, 3)")]
        public decimal? SunHrs { get; set; }
        [Column("ALERT_EMAIL")]
        public short? AlertEmail { get; set; }
        [Column("MTH_HRS_GOAL", TypeName = "decimal(9, 3)")]
        public decimal? MthHrsGoal { get; set; }
        [Column("VAC_HRS", TypeName = "decimal(9, 3)")]
        public decimal? VacHrs { get; set; }
        [Column("SICK_HRS", TypeName = "decimal(9, 3)")]
        public decimal? SickHrs { get; set; }
        [Column("FREELANCE")]
        public short? Freelance { get; set; }
        [Column("PERS_HRS", TypeName = "decimal(9, 3)")]
        public decimal? PersHrs { get; set; }
        [Column("PERS_FROM_DATE", TypeName = "smalldatetime")]
        public DateTime? PersFromDate { get; set; }
        [Column("PERS_TO_DATE", TypeName = "smalldatetime")]
        public DateTime? PersToDate { get; set; }
        [Column("DEF_FNC_CODE")]
        [StringLength(6)]
        public string DefFncCode { get; set; }
        [Column("PO_LIMIT", TypeName = "decimal(15, 2)")]
        public decimal? PoLimit { get; set; }
        [Column("EMP_ACCOUNT_NBR")]
        [StringLength(30)]
        public string EmpAccountNbr { get; set; }
        [Column("EMP_PHONE_WORK")]
        [StringLength(13)]
        public string EmpPhoneWork { get; set; }
        [Column("EMP_PHONE_CELL")]
        [StringLength(13)]
        public string EmpPhoneCell { get; set; }
        [Column("EMP_PHONE_ALT")]
        [StringLength(13)]
        public string EmpPhoneAlt { get; set; }
        [Column("EMP_PHONE_WORK_EXT")]
        [StringLength(10)]
        public string EmpPhoneWorkExt { get; set; }
        [Column("STD_ANNUAL_HRS", TypeName = "decimal(9, 3)")]
        public decimal? StdAnnualHrs { get; set; }
        [Column("VN_CODE_EXP")]
        [StringLength(6)]
        public string VnCodeExp { get; set; }
        [Column("CC_NUMBER")]
        [StringLength(30)]
        public string CcNumber { get; set; }
        [Column("CC_DESC")]
        [StringLength(40)]
        public string CcDesc { get; set; }
        [Column("CC_GL_ACCOUNT")]
        [StringLength(30)]
        public string CcGlAccount { get; set; }
        [Column("EXP_APPR_REQ")]
        public short? ExpApprReq { get; set; }
        [Column("MISSING_TIME")]
        public short? MissingTime { get; set; }
        [Column("WEEKLY_TIME")]
        public short? WeeklyTime { get; set; }
        [Column("SIGNATURE_PATH")]
        [StringLength(256)]
        public string SignaturePath { get; set; }
        [Column("STATUS")]
        public short? Status { get; set; }
        [Column("DIRECT_HRS_PER", TypeName = "decimal(7, 4)")]
        public decimal? DirectHrsPer { get; set; }
        [Column("DEF_TRF_ROLE")]
        [StringLength(6)]
        public string DefTrfRole { get; set; }
        [Column("EMP_COMMENT", TypeName = "text")]
        public string EmpComment { get; set; }
        [Column("EMPLOYEE_TITLE_ID")]
        public int? EmployeeTitleId { get; set; }
        [Column("PO_APPR_RULE_CODE")]
        [StringLength(6)]
        public string PoApprRuleCode { get; set; }
        [Column("PO_GL_SELECTION")]
        public short? PoGlSelection { get; set; }
        [Column("PO_GL_LIMIT_BY_OFFICE")]
        public short? PoGlLimitByOffice { get; set; }
        [Column("SENIORITY")]
        public short? Seniority { get; set; }
        [Column("EMP_START_TIME", TypeName = "smalldatetime")]
        public DateTime? EmpStartTime { get; set; }
        [Column("EMP_END_TIME", TypeName = "smalldatetime")]
        public DateTime? EmpEndTime { get; set; }
        [Column("EMP_START_TIME_MON", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeMon { get; set; }
        [Column("EMP_END_TIME_MON", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeMon { get; set; }
        [Column("EMP_START_TIME_TUE", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeTue { get; set; }
        [Column("EMP_END_TIME_TUE", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeTue { get; set; }
        [Column("EMP_START_TIME_WED", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeWed { get; set; }
        [Column("EMP_END_TIME_WED", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeWed { get; set; }
        [Column("EMP_START_TIME_THU", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeThu { get; set; }
        [Column("EMP_END_TIME_THU", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeThu { get; set; }
        [Column("EMP_START_TIME_FRI", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeFri { get; set; }
        [Column("EMP_END_TIME_FRI", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeFri { get; set; }
        [Column("EMP_START_TIME_SAT", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeSat { get; set; }
        [Column("EMP_END_TIME_SAT", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeSat { get; set; }
        [Column("EMP_START_TIME_SUN", TypeName = "smalldatetime")]
        public DateTime? EmpStartTimeSun { get; set; }
        [Column("EMP_END_TIME_SUN", TypeName = "smalldatetime")]
        public DateTime? EmpEndTimeSun { get; set; }
        [Column("EMAIL_USERNAME")]
        [StringLength(50)]
        public string EmailUsername { get; set; }
        [Column("EMAIL_REPLY_TO")]
        [StringLength(50)]
        public string EmailReplyTo { get; set; }
        [Column("EMP_SIG", TypeName = "image")]
        public byte[] EmpSig { get; set; }
        [Column("WV_TMPLT_HDR_ID")]
        public int? WvTmpltHdrId { get; set; }
        [Column("ALT_COST_RATE", TypeName = "decimal(9, 2)")]
        public decimal? AltCostRate { get; set; }
        [Column("ALT_DATE_FRM", TypeName = "smalldatetime")]
        public DateTime? AltDateFrm { get; set; }
        [Column("ALT_DATE_TO", TypeName = "smalldatetime")]
        public DateTime? AltDateTo { get; set; }
        [Column("CREATED_BY")]
        [StringLength(100)]
        public string CreatedBy { get; set; }
        [Column("CREATED_DATE", TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }
        [Column("LAST_MODIFIED_BY")]
        [StringLength(100)]
        public string LastModifiedBy { get; set; }
        [Column("LAST_MODIFIED_DATE", TypeName = "smalldatetime")]
        public DateTime? LastModifiedDate { get; set; }
        [Column("METHOD")]
        [StringLength(1)]
        public string Method { get; set; }
        [Column("EXP_RPT_APPROVER")]
        [StringLength(6)]
        public string ExpRptApprover { get; set; }
        [Column("VAC_TIME_RULE_ID")]
        public int? VacTimeRuleId { get; set; }
        [Column("SICK_TIME_RULE_ID")]
        public int? SickTimeRuleId { get; set; }
        [Column("PERS_TIME_RULE_ID")]
        public int? PersTimeRuleId { get; set; }
        [Column("EMP_TITLE")]
        [StringLength(50)]
        public string EmpTitle { get; set; }
        [Column("TS_APPR_FLAG")]
        public bool? TsApprFlag { get; set; }
        [Column("IS_ACTIVE_FREELANCE")]
        public bool IsActiveFreelance { get; set; }
        [Column("SUGAR_PASSWORD")]
        [StringLength(100)]
        public string SugarPassword { get; set; }
        [Column("SUGAR_USERNAME")]
        [StringLength(100)]
        public string SugarUsername { get; set; }
        [Column("PROOFHQ_PASSWORD")]
        [StringLength(100)]
        public string ProofhqPassword { get; set; }
        [Column("PROOFHQ_USERNAME")]
        [StringLength(100)]
        public string ProofhqUsername { get; set; }
        [Column("IS_API_USER")]
        public string IsApiUser { get; set; }
        [Column("GOOGLE_TOKEN")]
        public string GoogleToken { get; set; }
        [Column("ADOBE_SIGNATURE_FILE")]
        public byte[] AdobeSignatureFile { get; set; }
        [Column("ADOBE_SIGNATURE_FILE_PASSWORD")]
        [StringLength(100)]
        public string AdobeSignatureFilePassword { get; set; }
        [Column("VCC_PASSWORD")]
        [StringLength(100)]
        public string VccPassword { get; set; }
        [Column("VCC_USERNAME")]
        [StringLength(100)]
        public string VccUsername { get; set; }
        [Column("CS_PASSWORD")]
        public string CsPassword { get; set; }
        [Column("CS_USERID")]
        public int? CsUserid { get; set; }
        [Column("EMP_OMIT_MISSING")]
        public short? EmpOmitMissing { get; set; }
        [Column("IGNORE_CALENDAR_SYNC")]
        public bool IgnoreCalendarSync { get; set; }
        [Column("TIME_ZONE_ID")]
        [StringLength(256)]
        public string TimeZoneId { get; set; }
        [Column("CULTURE_CODE")]
        [StringLength(10)]
        public string CultureCode { get; set; }
        [Column("CAL_TIME_TYPE")]
        public short? CalTimeType { get; set; }
        [Column("CAL_TIME_EMAIL")]
        [StringLength(50)]
        public string CalTimeEmail { get; set; }
        [Column("CAL_TIME_USERNAME")]
        [StringLength(50)]
        public string CalTimeUsername { get; set; }
        [Column("CAL_TIME_PASSWORD")]
        [StringLength(50)]
        public string CalTimePassword { get; set; }
        [Column("CAL_TIME_HOST")]
        [StringLength(500)]
        public string CalTimeHost { get; set; }
        [Column("CAL_TIME_PORT")]
        public int? CalTimePort { get; set; }
        [Column("CAL_TIME_SSL")]
        public bool? CalTimeSsl { get; set; }
        [Column("EMP_BILL_RATE", TypeName = "decimal(10, 3)")]
        public decimal? EmpBillRate { get; set; }

        public override string ToString()
        {
            string ToStringRet = default;
            if (this.EmpMi is object && this.EmpMi.Trim() != "")
            {
                ToStringRet = this.EmpFname + " " + this.EmpMi + ". " + this.EmpLname;
            }
            else
            {
                ToStringRet = this.EmpFname + " " + this.EmpLname;
            }

            return ToStringRet;
        }

    }
}
