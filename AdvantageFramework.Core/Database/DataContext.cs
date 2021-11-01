
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AdvantageFramework.Core.Database.Entities;

namespace AdvantageFramework.Core.Database
{
    public partial class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DataContext(string connectionString, string userCode)
        {
            ConnectionString = connectionString;
            UserCode = userCode;
        }

        public virtual DbSet<LatestVersion> LatestVersions { get; set; }
        public virtual DbSet<ProofingAssetStatus> ProofingAssetStatuses { get; set; }
        public virtual DbSet<ProofingDocument> ProofingDocuments { get; set; }
        public virtual DbSet<ProofingExternal> ProofingExternals { get; set; }
        public virtual DbSet<ProofingMarkup> ProofingMarkups { get; set; }

        public virtual DbSet<Entities.Agency> Agency { get; set; }
        //public virtual DbSet<AgencySetting> AgencySettings { get; set; }
        public virtual DbSet<Alert> Alerts { get; set; }
        public virtual DbSet<AlertAttachment> AlertAttachments { get; set; }
        public virtual DbSet<AlertCategory> AlertCategories { get; set; }
        public virtual DbSet<AlertComment> AlertComments { get; set; }
        public virtual DbSet<AdvantageFramework.Core.AlertSystem.Classes.AlertComment> ComplexAlertComments { get; set; }

        public virtual DbSet<AlertEmployeeHour> AlertEmployeeHours { get; set; }
        public virtual DbSet<AlertGroup> AlertGroups { get; set; }
        public virtual DbSet<AlertRecipient> AlertRecipients { get; set; }
        public virtual DbSet<Classes.AlertRecipient> AlertRecipient { get; set; }
        public virtual DbSet<AlertRecipientDismissed> AlertRecipientDismisseds { get; set; }
        public virtual DbSet<AlertRecipientExternal> AlertRecipientExternals { get; set; }
        public virtual DbSet<AlertState> AlertStates { get; set; }
        public virtual DbSet<AlertType> AlertTypes { get; set; }
        public virtual DbSet<AppVar> AppVars { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<EmployeeDepartmentTeam> EmployeeDepartmentTeams { get; set; }
        public virtual DbSet<Views.Employee> Employees { get; set; }
        public virtual DbSet<EmployeePicture> EmployeePictures { get; set; }
        //public virtual DbSet<Employee> EmployeeMentions { get; set; }
        public virtual DbSet<JobComponent> JobComponents { get; set; }
        public virtual DbSet<JobComponentDocument> JobComponentDocuments { get; set; }
        public virtual DbSet<JobDocument> JobDocuments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<ProjectSchedule> ProjectSchedules { get; set; }
        public virtual DbSet<JobTrafficDet> JobTrafficDet { get; set; }
        public virtual DbSet<ProjectScheduleComment> ProjectScheduleComments { get; set; }
        public virtual DbSet<ProjectScheduleContact> ProjectScheduleContacts { get; set; }
        public virtual DbSet<ProjectScheduleDocument> ProjectScheduleDocuments { get; set; }
        public virtual DbSet<ProjectScheduleEmployee> ProjectScheduleEmployees { get; set; }
        public virtual DbSet<ProjectScheduleDetailPredecessor> ProjectScheduleDetailPredecessors { get; set; }
        public virtual DbSet<ProjectSchedulePredecessor> ProjectSchedulePredecessors { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDocument> ProductDocuments { get; set; }
        public virtual DbSet<SecurityUser> SecurityUsers { get; set; }
        public virtual DbSet<EmployeeCloak> EmployeeCloaks { get; set; }
        public virtual DbSet<CompleteAssignmentResult> CompleteAssignmentResult { get; set; }
        public virtual DbSet<Approval> Approvals { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<AlertRecipientLookup> AlertRecipientLookup { get; set; }        
        public virtual DbSet<Classes.AlertEmailRecipient> AlertEmailRecipient { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<MediaRFPHeader> MediaRfpHeaders { get; set; }
        public virtual DbSet<MediaTrafficVendor> MediaTrafficVendors { get; set; }
        public virtual DbSet<Views.AlertView> AlertViews { get; set; }
        public virtual DbSet<Views.AlertAttachmentView> AlertAttachmentViews { get; set; }
        public virtual DbSet<Views.ClientPortalAlertView> ClientPortalAlertView { get; set; }
        public virtual DbSet<ClientPortalAlertRecipient> ClientPortalAlertRecipients { get; set; }
        //public virtual DbSet<JobComponentTask> JobComponentTasks { get; set; }
        public virtual DbSet<ClientContact> ClientContacts { get; set; }
        public virtual DbSet<VendorRepresentative> VendorRepresentatives { get; set; }

        public string ConnectionString { get; }
        public string UserCode { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompleteAssignmentResult>().HasNoKey().ToView("__prevent__");
            modelBuilder.Entity<Approval>().HasNoKey().ToView("__prevent__2");
            modelBuilder.Entity<Comment>().HasNoKey().ToView("__prevent__3");
            modelBuilder.Entity<Classes.AlertEmailRecipient>().HasNoKey().ToView("__prevent__4");
            modelBuilder.Entity<AlertRecipientLookup>().HasNoKey().ToView("__prevent__5");
            modelBuilder.Entity<Classes.AlertRecipient>().HasNoKey().ToView("__prevent__6");

            modelBuilder.Entity<ProofingAssetStatus>(entity =>
            {
                entity.Property(e => e.EmpCode).IsUnicode(false);
            });

            modelBuilder.Entity<ProofingDocument>(entity =>
            {
                entity.Property(e => e.UserCode).IsUnicode(false);
            });

            modelBuilder.Entity<ProofingExternal>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<ProofingMarkup>(entity =>
            {
                entity.Property(e => e.DocumentId).HasComment("Base document ID");

                entity.Property(e => e.EmpCode)
                    .IsUnicode(false)
                    .HasComment("Employee code of wh marked it up");

                entity.Property(e => e.Generated).HasComment("Date markup created");

                entity.Property(e => e.Markup)
                    .IsUnicode(false)
                    .HasComment("Content of markup to redraw");
            });

            modelBuilder.Entity<Entities.Agency>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AccessRptPath).IsUnicode(false);

                entity.Property(e => e.AccessTmpPath).IsUnicode(false);

                entity.Property(e => e.Address1).IsUnicode(false);

                entity.Property(e => e.Address2).IsUnicode(false);

                entity.Property(e => e.ApImportType).IsUnicode(false);

                entity.Property(e => e.ApPoMessageText).IsUnicode(false);

                entity.Property(e => e.ApPoRejectText).IsUnicode(false);

                entity.Property(e => e.AutoAlertSuper).HasDefaultValueSql("(1)");

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.ClientportalUrl).IsUnicode(false);

                entity.Property(e => e.CoinText).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.County).IsUnicode(false);

                entity.Property(e => e.CrncyImportType).IsUnicode(false);

                entity.Property(e => e.CultureCode).IsUnicode(false);

                entity.Property(e => e.CurrencySymbol).IsUnicode(false);

                entity.Property(e => e.CurrencyText).IsUnicode(false);

                entity.Property(e => e.DbCultureCode).IsUnicode(false);

                entity.Property(e => e.DbTimezoneId).IsUnicode(false);

                entity.Property(e => e.DefEmailGroup).IsUnicode(false);

                entity.Property(e => e.DefEstRpt).IsUnicode(false);

                entity.Property(e => e.DefPoRpt).IsUnicode(false);

                entity.Property(e => e.DocRepositoryPath).IsUnicode(false);

                entity.Property(e => e.DocRepositoryUserDomain).IsUnicode(false);

                entity.Property(e => e.DocRepositoryUserName).IsUnicode(false);

                entity.Property(e => e.DocRepositoryUserPassword).IsUnicode(false);

                entity.Property(e => e.EmailPwd).IsUnicode(false);

                entity.Property(e => e.EmailReplyTo).IsUnicode(false);

                entity.Property(e => e.EmailUsername).IsUnicode(false);

                entity.Property(e => e.EmpNotes).HasDefaultValueSql("(0)");

                entity.Property(e => e.HomeCrncy).IsUnicode(false);

                entity.Property(e => e.ImportPath).IsUnicode(false);

                entity.Property(e => e.IoImportType).IsUnicode(false);

                entity.Property(e => e.ItContactEmail).IsUnicode(false);

                entity.Property(e => e.LicenseKey).IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.MacExport).IsUnicode(false);

                entity.Property(e => e.MbKey).IsUnicode(false);

                entity.Property(e => e.McAcctPwd).IsUnicode(false);

                entity.Property(e => e.McUrl).IsUnicode(false);

                entity.Property(e => e.MdInterface).IsUnicode(false);

                entity.Property(e => e.MrpDsn).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PdfGenerator).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Pop3Pwd).IsUnicode(false);

                entity.Property(e => e.Pop3ReplyTo).IsUnicode(false);

                entity.Property(e => e.Pop3Server).IsUnicode(false);

                entity.Property(e => e.Pop3Username).IsUnicode(false);

                entity.Property(e => e.SmtpSender).IsUnicode(false);

                entity.Property(e => e.SmtpSenderPwd).IsUnicode(false);

                entity.Property(e => e.SmtpServer).IsUnicode(false);

                entity.Property(e => e.SmtpUseEmpFrom).HasComputedColumnSql("([SMTP_USE_EMP_LOGIN])");

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.StrataPath).IsUnicode(false);

                entity.Property(e => e.TimezoneId).IsUnicode(false);

                entity.Property(e => e.TrTitle1)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(convert(varchar(20),[dbo].[udf_get_agy_setting]('TR_TITLE1')))");

                entity.Property(e => e.TrTitle2)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(convert(varchar(20),[dbo].[udf_get_agy_setting]('TR_TITLE2')))");

                entity.Property(e => e.TrTitle3)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(convert(varchar(20),[dbo].[udf_get_agy_setting]('TR_TITLE3')))");

                entity.Property(e => e.TrTitle4)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(convert(varchar(20),[dbo].[udf_get_agy_setting]('TR_TITLE4')))");

                entity.Property(e => e.TrTitle5)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(convert(varchar(20),[dbo].[udf_get_agy_setting]('TR_TITLE5')))");

                entity.Property(e => e.TrfCalcByCmp).HasComputedColumnSql("(convert(smallint,[dbo].[udf_get_agy_setting]('TRF_CALC_BY_CMP')))");

                entity.Property(e => e.TrfHrs).HasComputedColumnSql("(convert(decimal(9,3),[dbo].[udf_get_agy_setting]('TRF_HRS')))");

                entity.Property(e => e.TrfLockDate).HasComputedColumnSql("(convert(smallint,[dbo].[udf_get_agy_setting]('TRF_LOCK_DATE')))");

                entity.Property(e => e.TrfScheduleBy).HasComputedColumnSql("(convert(smallint,[dbo].[udf_get_agy_setting]('TRF_SCHEDULE_BY')))");

                entity.Property(e => e.WebvantageUrl).IsUnicode(false);

                entity.Property(e => e.Zip).IsUnicode(false);
            });

            //modelBuilder.Entity<AgencySetting>(entity =>
            //{
            //    entity.Property(e => e.AgySettingsCode).IsUnicode(false);

            //    entity.Property(e => e.AgySettingsDesc).IsUnicode(false);
            //});

            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasIndex(e => e.AlertStateId)
                    .HasDatabaseName("IDX_ALERT_0");

                entity.HasIndex(e => new { e.AlertId, e.AssignCompleted })
                    .HasDatabaseName("IDX_ALERT_ASSIGN_COMPLETED");

                entity.HasIndex(e => new { e.AlertId, e.JobNumber })
                    .HasDatabaseName("IDX_ALERT_ID_JOB");

                entity.HasIndex(e => new { e.AlertSeqNbr, e.JobComponentNbr, e.JobNumber, e.AlertId })
                    .HasDatabaseName("IDX_ALERT_1");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.AlertLevel, e.TaskSeqNbr })
                    .HasDatabaseName("IDX_ALERT_JN_JCN_AL_TSN");

                entity.HasIndex(e => new { e.AlertCatId, e.JobNumber, e.JobComponentNbr, e.TaskSeqNbr, e.AlertId })
                    .HasDatabaseName("IDX_ALERT_CAT_ID");

                entity.HasIndex(e => new { e.AlertId, e.EmpCode, e.AlertStateId, e.AlrtNotifyHdrId, e.AlertUser })
                    .HasDatabaseName("IDX_ALERT_ASSIGNMENT");

                entity.HasIndex(e => new { e.AlertId, e.JobComponentNbr, e.AlertLevel, e.IsWorkItem, e.IsDraft })
                    .HasDatabaseName("IDX_ACTIVE_WORKITEM");

                entity.HasIndex(e => new { e.AlertId, e.JobNumber, e.JobComponentNbr, e.AlertLevel, e.IsWorkItem, e.IsDraft })
                    .HasDatabaseName("IDX_ALERT_IS_WORK_ITEM_IS_DRAFT");

                entity.HasIndex(e => new { e.AlertId, e.EmpCode, e.LastUpdated, e.IsDraft, e.Generated, e.AssignedEmpCode, e.LastUpdatedUserCode, e.AssignCompleted })
                    .HasDatabaseName("IDX_ALERT_INBOX");

                entity.HasIndex(e => new { e.AlertId, e.DueDate, e.IsDraft, e.AssignCompleted, e.IsCsReview, e.StartDate, e.AlrtNotifyHdrId, e.AssignedEmpCode, e.IsWorkItem })
                    .HasDatabaseName("IDX_ALERT_ALRT_NOTIFY_HDR_ID");

                entity.HasIndex(e => new { e.AlertTypeId, e.AlertId, e.LastUpdated, e.AlertLevel, e.AssignedEmpCode, e.AlertStateId, e.AlrtNotifyHdrId, e.IsWorkItem, e.AssignCompleted, e.IsDraft, e.IsCsReview })
                    .HasDatabaseName("IDX_ALRT_MULTI_COLUMNS");

                entity.HasIndex(e => new { e.AlertId, e.Priority, e.JobNumber, e.JobComponentNbr, e.TaskSeqNbr, e.AlertStateId, e.AlrtNotifyHdrId, e.AssignCompleted, e.AlertLevel, e.AlertCatId, e.IsWorkItem, e.IsDraft, e.IsCsReview })
                    .HasDatabaseName("IDX_ALERT_ALERT_CAT_ID_IS_WORK_ITEM_IS_DRAFT_IS_CS_REVIEW");

                entity.Property(e => e.AlertId).ValueGeneratedNever();

                entity.Property(e => e.AlertLevel).IsUnicode(false);

                entity.Property(e => e.AlertUser).IsUnicode(false);

                entity.Property(e => e.AssignedEmpCode).IsUnicode(false);

                entity.Property(e => e.AssignedEmpFml).IsUnicode(false);

                entity.Property(e => e.Build).IsUnicode(false);

                entity.Property(e => e.Build2).IsUnicode(false);

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.CmpCode).IsUnicode(false);

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.Generated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastAssignedEmpCode).IsUnicode(false);

                entity.Property(e => e.LastUpdatedFml).IsUnicode(false);

                entity.Property(e => e.LastUpdatedUserCode).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.Property(e => e.TempPdfPath).IsUnicode(false);

                entity.Property(e => e.TimeDue).IsUnicode(false);

                entity.Property(e => e.Ver).IsUnicode(false);

                entity.Property(e => e.Ver2).IsUnicode(false);

                entity.Property(e => e.VnCode).IsUnicode(false);

                entity.HasOne(d => d.AlertCat)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.AlertCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_ALERT_CAT");

                entity.HasOne(d => d.AlertState)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.AlertStateId)
                    .HasConstraintName("FK_ALERT_ALERT_STATES");

                entity.HasOne(d => d.AlertType)
                    .WithMany(p => p.Alerts)
                    .HasForeignKey(d => d.AlertTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_ALERT_TYPE");
            });

            modelBuilder.Entity<AlertAttachment>(entity =>
            {
                entity.HasIndex(e => new { e.AlertId, e.DocumentId })
                    .HasDatabaseName("IDX_ALERT_ATTACHMENT_1");

                entity.HasIndex(e => new { e.DocumentId, e.AlertId, e.AttachmentId })
                    .HasDatabaseName("IDX_ALERT_ATTACHMENT_DOCUMENT");

                entity.HasIndex(e => new { e.AttachmentId, e.UserCode, e.DocumentId, e.UserCodeCp, e.AlertId, e.GeneratedDate })
                    .HasDatabaseName("IDX_ALERT_ATTACHMENT_0");

                entity.Property(e => e.Emailsent).HasDefaultValueSql("(0)");

                entity.Property(e => e.UserCode).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertAttachments)
                    .HasForeignKey(d => d.AlertId)
                    .HasConstraintName("FK_ALERT_ATTACHMENT_ALERT");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.AlertAttachments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_ATTACHMENT_DOCUMENTS");
            });

            modelBuilder.Entity<AlertCategory>(entity =>
            {
                entity.Property(e => e.AlertCatId).ValueGeneratedNever();

                entity.Property(e => e.AlertDesc).IsUnicode(false);

                entity.Property(e => e.ColorCode).IsUnicode(false);

                entity.Property(e => e.IsInactive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsUserDefined).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.AlertType)
                    .WithMany(p => p.AlertCategories)
                    .HasForeignKey(d => d.AlertTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_TYPE_CAT");
            });

            modelBuilder.Entity<AlertComment>(entity =>
            {
                entity.HasIndex(e => new { e.GeneratedDate, e.AlertId })
                    .HasDatabaseName("IDX_ALERT_ID_GEN_DATE");

                entity.HasIndex(e => new { e.GeneratedDate, e.UserCodeCp, e.AssignedEmpCode, e.DocumentList, e.AlrtNotifyHdrId, e.AlertStateId, e.AlertId, e.CommentId })
                    .HasDatabaseName("IDX_ALERT_COMMENT_COMMENT_ID");

                entity.Property(e => e.AssignedEmpCode).IsUnicode(false);

                entity.Property(e => e.Emailsent).HasDefaultValueSql("(0)");

                entity.Property(e => e.IsSystem).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserCode).IsUnicode(false);

                entity.Property(e => e.VcCode).IsUnicode(false);

                entity.Property(e => e.VrCode).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertComments)
                    .HasForeignKey(d => d.AlertId)
                    .HasConstraintName("FK_ALERT_COMMENT_ALERT");
            });

            modelBuilder.Entity<AlertEmployeeHour>(entity =>
            {
                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertEmpHours)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_EMP_HOURS_ALERT");
            });

            modelBuilder.Entity<AlertGroup>(entity =>
            {
                entity.HasKey(e => new { e.EGroup, e.AlertCatId });

                entity.Property(e => e.EGroup).IsUnicode(false);

                entity.HasOne(d => d.AlertCat)
                    .WithMany(p => p.AlertGroups)
                    .HasForeignKey(d => d.AlertCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_GROUP_CAT");
            });

            modelBuilder.Entity<AlertRecipient>(entity =>
            {
                entity.HasKey(e => new { e.AlertId, e.AlertRcptId })
                    .HasName("PK_ALERT_RCPT_1");

                entity.HasIndex(e => new { e.AlertId, e.ReadAlert, e.CardSeqNbr, e.EmpCode, e.CurrentNotify })
                    .HasDatabaseName("IDX_ALERT_RCPT_EMP2");

                entity.HasIndex(e => new { e.AlertId, e.EmpCode, e.Processed, e.NewAlert, e.ReadAlert, e.CurrentNotify })
                    .HasDatabaseName("IDX_ALERT_RCPT_1");

                entity.HasIndex(e => new { e.AlertId, e.EmpCode, e.ReadAlert, e.CurrentNotify, e.CurrentRcpt, e.Processed })
                    .HasDatabaseName("IDX_ALERTRCPT_ALERTID_CURRENTNOTIFY_EMPCODE");

                entity.HasIndex(e => new { e.AlertId, e.ReadAlert, e.CurrentRcpt, e.CurrentNotify, e.CardSeqNbr, e.EmpCode })
                    .HasDatabaseName("IDX_ALERT_RCPT_EMP");

                entity.HasIndex(e => new { e.Processed, e.NewAlert, e.ReadAlert, e.AlertId, e.EmpCode, e.CurrentNotify })
                    .HasDatabaseName("IDX_ALERT_RCPT_0");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertRcpts)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_RCPT");
            });

            modelBuilder.Entity<AlertRecipientDismissed>(entity =>
            {
                entity.HasKey(e => new { e.AlertId, e.AlertRcptId })
                    .HasName("PK__ALERT_RC__385FA47B4E03BF5E");

                entity.HasIndex(e => new { e.CurrentNotify, e.AlertId })
                    .HasDatabaseName("IDX_ALERT_RCPT_DISMISSED_CURRENT_NOTIFY");

                entity.HasIndex(e => new { e.AlertId, e.CurrentNotify, e.EmpCode, e.Processed })
                    .HasDatabaseName("IDX_ALERT_RCPT_DISMISSED_0");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertRcptDismisseds)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_RCPT_DISMISSED_ALERT");
            });

            modelBuilder.Entity<AlertRecipientExternal>(entity =>
            {
                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.AlertRcptExts)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALERT_RCPT_EXT_ALERT");
            });

            modelBuilder.Entity<AlertState>(entity =>
            {
                entity.HasIndex(e => new { e.AlertStateName, e.AlertStateId, e.ActiveFlag })
                    .HasDatabaseName("IDX_ALERT_STATES");

                entity.Property(e => e.AlertStateName).IsUnicode(false);

                entity.HasOne(d => d.DfltAlertCat)
                    .WithMany(p => p.AlertStates)
                    .HasForeignKey(d => d.DfltAlertCatId)
                    .HasConstraintName("FK_ALERT_STATES_DFLT_CAT");
            });

            modelBuilder.Entity<AlertType>(entity =>
            {
                entity.Property(e => e.AlertTypeId).ValueGeneratedNever();

                entity.Property(e => e.AlertTypeDesc).IsUnicode(false);
            });

            modelBuilder.Entity<AppVar>(entity =>
            {
                entity.HasIndex(e => new { e.Userid, e.Application, e.VariableName })
                    .HasDatabaseName("IDX_APP_VARS_SEARCH");

                entity.HasIndex(e => new { e.Userid, e.VariableValue, e.Application, e.VariableName })
                    .HasDatabaseName("IDX_APP_VARS_APPLICATION");

                entity.Property(e => e.Application).IsUnicode(false);

                entity.Property(e => e.Userid).IsUnicode(false);

                entity.Property(e => e.VariableGroup).IsUnicode(false);

                entity.Property(e => e.VariableName).IsUnicode(false);

                entity.Property(e => e.VariableType).IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => new { e.ReqTimeComment, e.ActiveFlag })
                    .HasDatabaseName("IDX_CLIENT_REQ_TIME_COMMENT");

                entity.HasIndex(e => new { e.ClCode, e.ClName, e.ActiveFlag })
                    .HasDatabaseName("IDX_CLCODE_CLNAME");

                entity.HasIndex(e => new { e.ClCode, e.ClName, e.NewBusiness, e.ActiveFlag })
                    .HasDatabaseName("IDX_CLIENT_ACTIVE_FLAG");

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.AvalaraScCode).IsUnicode(false);

                entity.Property(e => e.BatchName).IsUnicode(false);

                entity.Property(e => e.BillerEmpCode).IsUnicode(false);

                entity.Property(e => e.BinvFormat).IsUnicode(false);

                entity.Property(e => e.ClAddress1).IsUnicode(false);

                entity.Property(e => e.ClAddress2).IsUnicode(false);

                entity.Property(e => e.ClAlphaSort).IsUnicode(false);

                entity.Property(e => e.ClAttention).IsUnicode(false);

                entity.Property(e => e.ClBaddress1).IsUnicode(false);

                entity.Property(e => e.ClBaddress2).IsUnicode(false);

                entity.Property(e => e.ClBcity).IsUnicode(false);

                entity.Property(e => e.ClBcountry).IsUnicode(false);

                entity.Property(e => e.ClBcounty).IsUnicode(false);

                entity.Property(e => e.ClBstate).IsUnicode(false);

                entity.Property(e => e.ClBzip).IsUnicode(false);

                entity.Property(e => e.ClCity).IsUnicode(false);

                entity.Property(e => e.ClCountry).IsUnicode(false);

                entity.Property(e => e.ClCounty).IsUnicode(false);

                entity.Property(e => e.ClFooter).IsUnicode(false);

                entity.Property(e => e.ClMattention).IsUnicode(false);

                entity.Property(e => e.ClMfooter).IsUnicode(false);

                entity.Property(e => e.ClName).IsUnicode(false);

                entity.Property(e => e.ClSaddress1).IsUnicode(false);

                entity.Property(e => e.ClSaddress2).IsUnicode(false);

                entity.Property(e => e.ClScity).IsUnicode(false);

                entity.Property(e => e.ClScountry).IsUnicode(false);

                entity.Property(e => e.ClScounty).IsUnicode(false);

                entity.Property(e => e.ClSstate).IsUnicode(false);

                entity.Property(e => e.ClState).IsUnicode(false);

                entity.Property(e => e.ClSzip).IsUnicode(false);

                entity.Property(e => e.ClZip).IsUnicode(false);

                entity.Property(e => e.ClientDiscountCode).IsUnicode(false);

                entity.Property(e => e.CurrencyCode).IsUnicode(false);

                entity.Property(e => e.IinvFormat).IsUnicode(false);

                entity.Property(e => e.InvByJobOnNull).HasDefaultValueSql("((0))");

                entity.Property(e => e.InvFormat).IsUnicode(false);

                entity.Property(e => e.InvoiceLocationId).IsUnicode(false);

                entity.Property(e => e.OinvFormat).IsUnicode(false);

                entity.Property(e => e.PinvFormat).IsUnicode(false);

                entity.Property(e => e.PinvFormat2).IsUnicode(false);

                entity.Property(e => e.VatNumber).IsUnicode(false);

                entity.HasOne(d => d.AutomatedAssignmentJob)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => new { d.AutomatedAssignmentJobNumber, d.AutomatedAssignmentJobComponentNbr })
                    .HasConstraintName("FK_CLIENT_AUTOMATED_ASSIGNMENT_JOB_COMPONENT");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => new { e.ClCode, e.DivCode });

                entity.HasIndex(e => e.ClCode)
                    .HasDatabaseName("XDIV_CLIENT");

                entity.HasIndex(e => e.DivCode)
                    .HasDatabaseName("XDIV_DIVISION");

                entity.HasIndex(e => new { e.DivName, e.ClCode, e.DivCode })
                    .HasDatabaseName("IDX_DIVISION_CL_CODE");

                entity.HasIndex(e => new { e.ClCode, e.DivCode, e.DivName, e.ActiveFlag })
                    .HasDatabaseName("IDX_DIVISION_ACTIVE_FLAG");

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.BatchName).IsUnicode(false);

                entity.Property(e => e.DivAlphaSort).IsUnicode(false);

                entity.Property(e => e.DivAttention).IsUnicode(false);

                entity.Property(e => e.DivBaddress1).IsUnicode(false);

                entity.Property(e => e.DivBaddress2).IsUnicode(false);

                entity.Property(e => e.DivBcity).IsUnicode(false);

                entity.Property(e => e.DivBcountry).IsUnicode(false);

                entity.Property(e => e.DivBcounty).IsUnicode(false);

                entity.Property(e => e.DivBstate).IsUnicode(false);

                entity.Property(e => e.DivBzip).IsUnicode(false);

                entity.Property(e => e.DivName).IsUnicode(false);

                entity.Property(e => e.DivSaddress1).IsUnicode(false);

                entity.Property(e => e.DivSaddress2).IsUnicode(false);

                entity.Property(e => e.DivScity).IsUnicode(false);

                entity.Property(e => e.DivScountry).IsUnicode(false);

                entity.Property(e => e.DivScounty).IsUnicode(false);

                entity.Property(e => e.DivSstate).IsUnicode(false);

                entity.Property(e => e.DivSzip).IsUnicode(false);

                entity.HasOne(d => d.ClCodeNavigation)
                    .WithMany(p => p.Divisions)
                    .HasForeignKey(d => d.ClCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DIVISION_CLIENT");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.FileSize)
                    .HasDatabaseName("IDX_DOCUMENTS_FILE_SIZE");

                entity.HasIndex(e => new { e.Filename, e.DocumentId })
                    .HasDatabaseName("IDX_DOCUMENTS_DOCUMENT_ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);

                entity.Property(e => e.Keywords).IsUnicode(false);

                entity.Property(e => e.MimeType).IsUnicode(false);

                entity.Property(e => e.ProofhqUrl).IsUnicode(false);

                entity.Property(e => e.RepositoryFilename).IsUnicode(false);

                entity.Property(e => e.UserCode).IsUnicode(false);

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_DOCUMENT_DOC_TYPE");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.DocumentTypeId).ValueGeneratedNever();

                entity.Property(e => e.DocumentTypeDesc).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeDepartmentTeam>(entity =>
            {
                entity.HasKey(e => new { e.EmpCode, e.DpTmCode });

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.DpTmCode).IsUnicode(false);

                entity.Property(e => e.DpTmDesc).IsUnicode(false);
            });

            modelBuilder.Entity<Views.Employee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EMPLOYEE");

                entity.Property(e => e.AdobeSignatureFilePassword).IsUnicode(false);

                entity.Property(e => e.CalTimeEmail).IsUnicode(false);

                entity.Property(e => e.CalTimeHost).IsUnicode(false);

                entity.Property(e => e.CalTimePassword).IsUnicode(false);

                entity.Property(e => e.CalTimeUsername).IsUnicode(false);

                entity.Property(e => e.CcDesc).IsUnicode(false);

                entity.Property(e => e.CcGlAccount).IsUnicode(false);

                entity.Property(e => e.CcNumber).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.CsPassword).IsUnicode(false);

                entity.Property(e => e.CultureCode).IsUnicode(false);

                entity.Property(e => e.DefFncCode).IsUnicode(false);

                entity.Property(e => e.DefTrfRole).IsUnicode(false);

                entity.Property(e => e.DpTmCode).IsUnicode(false);

                entity.Property(e => e.EmailPwd).IsUnicode(false);

                entity.Property(e => e.EmailReplyTo).IsUnicode(false);

                entity.Property(e => e.EmailUsername).IsUnicode(false);

                entity.Property(e => e.EmpAccountNbr).IsUnicode(false);

                entity.Property(e => e.EmpAddress1).IsUnicode(false);

                entity.Property(e => e.EmpAddress2).IsUnicode(false);

                entity.Property(e => e.EmpAlphaSort).IsUnicode(false);

                entity.Property(e => e.EmpCity).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.EmpCountry).IsUnicode(false);

                entity.Property(e => e.EmpCounty).IsUnicode(false);

                entity.Property(e => e.EmpEmail).IsUnicode(false);

                entity.Property(e => e.EmpFname).IsUnicode(false);

                entity.Property(e => e.EmpLname).IsUnicode(false);

                entity.Property(e => e.EmpMi).IsUnicode(false);

                entity.Property(e => e.EmpPayToAddr1).IsUnicode(false);

                entity.Property(e => e.EmpPayToAddr2).IsUnicode(false);

                entity.Property(e => e.EmpPayToCity).IsUnicode(false);

                entity.Property(e => e.EmpPayToCountry).IsUnicode(false);

                entity.Property(e => e.EmpPayToCounty).IsUnicode(false);

                entity.Property(e => e.EmpPayToState).IsUnicode(false);

                entity.Property(e => e.EmpPayToZip).IsUnicode(false);

                entity.Property(e => e.EmpPhone).IsUnicode(false);

                entity.Property(e => e.EmpPhoneAlt).IsUnicode(false);

                entity.Property(e => e.EmpPhoneCell).IsUnicode(false);

                entity.Property(e => e.EmpPhoneWork).IsUnicode(false);

                entity.Property(e => e.EmpPhoneWorkExt).IsUnicode(false);

                //entity.Property(e => e.EmpSsNbr).IsUnicode(false);

                entity.Property(e => e.EmpState).IsUnicode(false);

                entity.Property(e => e.EmpTitle).IsUnicode(false);

                entity.Property(e => e.EmpWorkDays).IsUnicode(false);

                entity.Property(e => e.EmpZip).IsUnicode(false);

                entity.Property(e => e.ExpRptApprover).IsUnicode(false);

                entity.Property(e => e.GoogleToken).IsUnicode(false);

                entity.Property(e => e.IsApiUser).IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).IsUnicode(false);

                entity.Property(e => e.Method).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.PoApprRuleCode).IsUnicode(false);

                entity.Property(e => e.ProofhqPassword).IsUnicode(false);

                entity.Property(e => e.ProofhqUsername).IsUnicode(false);

                entity.Property(e => e.SignaturePath).IsUnicode(false);

                entity.Property(e => e.SmtpServer).IsUnicode(false);

                entity.Property(e => e.SugarPassword).IsUnicode(false);

                entity.Property(e => e.SugarUsername).IsUnicode(false);

                entity.Property(e => e.SupervisorCode).IsUnicode(false);

                entity.Property(e => e.TimeZoneId).IsUnicode(false);

                entity.Property(e => e.VccPassword).IsUnicode(false);

                entity.Property(e => e.VccUsername).IsUnicode(false);

                entity.Property(e => e.VnCodeExp).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeePicture>(entity =>
            {
                entity.HasIndex(e => new { e.EmpCode, e.EmpNickname, e.EmpPictureId })
                    .HasDatabaseName("IDX_EMPLOYEE_PICTURE_EMP_CODE");

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.EmpNickname).IsUnicode(false);
            });

            modelBuilder.Entity<JobComponent>(entity =>
            {
                entity.HasKey(e => new { e.JobNumber, e.JobComponentNbr });

                entity.HasIndex(e => e.JobNumber)
                    .HasDatabaseName("XJC_JOBNUMBER");

                entity.HasIndex(e => new { e.BccId, e.BillingUser })
                    .HasDatabaseName("IDX_JCBILLER");

                entity.HasIndex(e => new { e.EstimateNumber, e.EstComponentNbr })
                    .HasDatabaseName("IDX_JOB_COMPONENT_ESTIMATE_NUMBER");

                entity.HasIndex(e => new { e.JobNumber, e.EmpCode, e.JobProcessContrl })
                    .HasDatabaseName("IDX_JOB_COMPONENT_JN_EC_JPC");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.BccId })
                    .HasDatabaseName("IDX_BCC_ID");

                entity.HasIndex(e => new { e.JobFirstUseDate, e.JobCompDesc, e.JobProcessContrl, e.JobComponentNbr, e.JobNumber })
                    .HasDatabaseName("IDX_JC_JPC_JCN_JN");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.JobProcessContrl, e.JobCompDesc, e.EstimateNumber, e.EstComponentNbr })
                    .HasDatabaseName("IDX_JOBCOMPONENT_0");

                entity.Property(e => e.AcctNbr).IsUnicode(false);

                entity.Property(e => e.AdNbr).IsUnicode(false);

                entity.Property(e => e.AdjustUser).IsUnicode(false);

                entity.Property(e => e.BillingUser).IsUnicode(false);

                entity.Property(e => e.BlackpltVer2Code).IsUnicode(false);

                entity.Property(e => e.BlackpltVer2Desc).IsUnicode(false);

                entity.Property(e => e.BlackpltVerCode).IsUnicode(false);

                entity.Property(e => e.BlackpltVerDesc).IsUnicode(false);

                entity.Property(e => e.ClientDiscountCode).IsUnicode(false);

                entity.Property(e => e.DpTmCode).IsUnicode(false);

                entity.Property(e => e.EmailGrCode).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.FiscalPeriodCode).IsUnicode(false);

                entity.Property(e => e.JobAdSize).IsUnicode(false);

                entity.Property(e => e.JobClPoNbr).IsUnicode(false);

                entity.Property(e => e.JobCompDesc).IsUnicode(false);

                entity.Property(e => e.JobLayoutSpcExp).IsUnicode(false);

                entity.Property(e => e.JobSpecType).IsUnicode(false);

                entity.Property(e => e.JobTmpltCode).IsUnicode(false);

                entity.Property(e => e.JtCode).IsUnicode(false);

                entity.Property(e => e.MarketCode).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);

                entity.Property(e => e.PrdContCode)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[udf_get_cont_code]([CDP_CONTACT_ID]))");

                entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

                entity.Property(e => e.TaxCode).IsUnicode(false);

                entity.Property(e => e.Udv1Code).IsUnicode(false);

                entity.Property(e => e.Udv2Code).IsUnicode(false);

                entity.Property(e => e.Udv3Code).IsUnicode(false);

                entity.Property(e => e.Udv4Code).IsUnicode(false);

                entity.Property(e => e.Udv5Code).IsUnicode(false);

                entity.HasOne(d => d.JobNumberNavigation)
                    .WithMany(p => p.JobComponents)
                    .HasForeignKey(d => d.JobNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_COMPONENT_JOB");
            });

            modelBuilder.Entity<JobComponentDocument>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.JobNumber, e.JobComponentNumber })
                    .HasName("PK_JCD_COMPOSITE");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNumber })
                    .HasDatabaseName("IDX_JOB_COMPONENT_DOCUMENTS_0");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.JobComponentDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_COMP_DOCS_DOCS");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobComponentDocuments)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_COMP_DOCS_JOB_COMP");
            });

            modelBuilder.Entity<JobDocument>(entity =>
            {
                entity.HasIndex(e => e.JobNumber)
                    .HasDatabaseName("IDX_JOB_DOCUMENTS_JOB_NUMBER");

                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.HasOne(d => d.Document)
                    .WithOne(p => p.JobDocument)
                    .HasForeignKey<JobDocument>(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_DOCS_DOCS");

                entity.HasOne(d => d.JobNumberNavigation)
                    .WithMany(p => p.JobDocuments)
                    .HasForeignKey(d => d.JobNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_DOCS_JOB");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasIndex(e => e.ClCode)
                    .HasDatabaseName("XJOB_CLIENT");

                entity.HasIndex(e => e.CmpCode)
                    .HasDatabaseName("XJOB_CAMPAIGN");

                entity.HasIndex(e => e.DivCode)
                    .HasDatabaseName("XJOB_DIVISION");

                entity.HasIndex(e => e.OfficeCode)
                    .HasDatabaseName("XJOB_OFFICE");

                entity.HasIndex(e => e.PrdCode)
                    .HasDatabaseName("XJOB_PRODUCT");

                entity.HasIndex(e => e.ScCode)
                    .HasDatabaseName("XJOB_SALES");

                entity.HasIndex(e => new { e.JobNumber, e.JobDesc })
                    .HasDatabaseName("IDX_JOBLOG_1");

                entity.HasIndex(e => new { e.JobNumber, e.ClCode, e.DivCode, e.PrdCode })
                    .HasDatabaseName("IDX_JOB_LOG_0");

                entity.HasIndex(e => new { e.JobNumber, e.ClCode, e.DivCode, e.PrdCode, e.OfficeCode })
                    .HasDatabaseName("IDX_JOB_LOG_OFFICE_CODE");

                entity.HasIndex(e => new { e.JobNumber, e.OfficeCode, e.JobDesc, e.ClCode, e.DivCode, e.PrdCode })
                    .HasDatabaseName("IDX_JOB_LOG_CL_CODE_DIV_CODE_PRD_CODE");

                entity.HasIndex(e => new { e.JobNumber, e.OfficeCode, e.ClCode, e.DivCode, e.PrdCode, e.JobDesc, e.ScCode })
                    .HasDatabaseName("IDX_JOB_LOG_SC_CODE");

                entity.Property(e => e.JobNumber).ValueGeneratedNever();

                entity.Property(e => e.BillCoopCode).IsUnicode(false);

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.CmpCode).IsUnicode(false);

                entity.Property(e => e.CompOpen).HasComputedColumnSql("([dbo].[udf_get_comp_open]([JOB_NUMBER]))");

                entity.Property(e => e.ComplexCode).IsUnicode(false);

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.FormatCode).IsUnicode(false);

                entity.Property(e => e.FormatScCode).IsUnicode(false);

                entity.Property(e => e.JobBillComment).IsUnicode(false);

                entity.Property(e => e.JobCliRef).IsUnicode(false);

                entity.Property(e => e.JobDesc).IsUnicode(false);

                entity.Property(e => e.LockedUser).IsUnicode(false);

                entity.Property(e => e.ModifiedBy).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.Property(e => e.PromoCode).IsUnicode(false);

                entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

                entity.Property(e => e.ScCode).IsUnicode(false);

                entity.Property(e => e.Udv1Code).IsUnicode(false);

                entity.Property(e => e.Udv2Code).IsUnicode(false);

                entity.Property(e => e.Udv3Code).IsUnicode(false);

                entity.Property(e => e.Udv4Code).IsUnicode(false);

                entity.Property(e => e.Udv5Code).IsUnicode(false);

                entity.Property(e => e.UserId).IsUnicode(false);

                entity.HasOne(d => d.OfficeCodeNavigation)
                    .WithMany(p => p.JobLogs)
                    .HasForeignKey(d => d.OfficeCode)
                    .HasConstraintName("FK_JOB_LOG_OFFICE");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.JobLogs)
                    .HasForeignKey(d => new { d.ClCode, d.DivCode, d.PrdCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_LOG_PRODUCT");
            });

            modelBuilder.Entity<ProjectSchedule>(entity =>
            {
                entity.HasKey(e => new { e.JobNumber, e.JobComponentNbr });

                entity.HasIndex(e => new { e.CompletedDate, e.Assign4 })
                    .HasDatabaseName("IDX_JOB_TRAFFIC_COMPLETED_DATE");

                entity.HasIndex(e => new { e.JobNumber, e.CompletedDate, e.JobComponentNbr })
                    .HasDatabaseName("IDX_JOBTRAFFIC_0");

                entity.Property(e => e.Assign1).IsUnicode(false);

                entity.Property(e => e.Assign2).IsUnicode(false);

                entity.Property(e => e.Assign3).IsUnicode(false);

                entity.Property(e => e.Assign4).IsUnicode(false);

                entity.Property(e => e.Assign5).IsUnicode(false);

                entity.Property(e => e.LockUser).IsUnicode(false);

                entity.Property(e => e.LockedUser).IsUnicode(false);

                entity.Property(e => e.MgrEmpCode)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[udf_get_traffic_mgr]([JOB_NUMBER], [JOB_COMPONENT_NBR]))");

                entity.Property(e => e.ReceivedBy).IsUnicode(false);

                entity.Property(e => e.Reference).IsUnicode(false);

                entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

                entity.Property(e => e.TrfCode).IsUnicode(false);

                entity.Property(e => e.TrfPresetCode).IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithOne(p => p.JobTraffic)
                    .HasForeignKey<ProjectSchedule>(d => new { d.JobNumber, d.JobComponentNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_JOB_COMP");
            });

            modelBuilder.Entity<JobTrafficDet>(entity =>
            {
                entity.HasKey(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr });

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.FncCode, e.TaskDescription, e.TaskStartDate, e.JobRevisedDate, e.DueTime, e.TaskStatus, e.JobCompletedDate })
                    .HasDatabaseName("IDX_JOB_TRAFFIC_DET_JOB_COMPLETED_DATE");

                entity.HasIndex(e => new { e.DueTime, e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.FncCode, e.TaskDescription, e.TaskStartDate, e.JobRevisedDate, e.RevisedDueTime, e.TaskStatus, e.JobCompletedDate })
                    .HasDatabaseName("IDX_JOB_TRAFFIC_DET_JOB_COMPLETED_DATE_1");

                entity.Property(e => e.DueTime).IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[udf_get_task_employee]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

                entity.Property(e => e.FncCode).IsUnicode(false);

                entity.Property(e => e.FncEst).IsUnicode(false);

                entity.Property(e => e.HoursAssigned).HasComputedColumnSql("([dbo].[udf_get_task_hours]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

                entity.Property(e => e.ParentTask).IsUnicode(false);

                entity.Property(e => e.RevisedDueTime).IsUnicode(false);

                entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

                entity.Property(e => e.TaskDescription).IsUnicode(false);

                entity.Property(e => e.TaskStatus).IsUnicode(false);

                entity.Property(e => e.TempCompDate).HasComputedColumnSql("([dbo].[udf_get_temp_comp_date]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

                entity.Property(e => e.TrfRole).IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobTrafficDets)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRAFFIC_JOB_COMP");
            });

            modelBuilder.Entity<ProjectScheduleComment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreateUser).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.JobTrafficDet)
                    .WithMany()
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.SeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_CMTS_JOB_TRAFFIC_DET");
            });

            modelBuilder.Entity<ProjectScheduleContact>(entity =>
            {
                entity.HasOne(d => d.JobTrafficDet)
                    .WithMany(p => p.JobTrafficDetCnts)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.SeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_CNTS");
            });

            modelBuilder.Entity<ProjectScheduleDocument>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.JobNumber, e.JobComponentNbr, e.SeqNbr });

                entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.JobTrafficDetDocs)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_DOCS_DOCUMENT_ID");

                entity.HasOne(d => d.JobTrafficDet)
                    .WithMany(p => p.JobTrafficDetDocs)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.SeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_DOCS_JOB_TRAFFIC_DET");
            });

            modelBuilder.Entity<ProjectScheduleEmployee>(entity =>
            {
                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.HoursAllowed })
                    .HasDatabaseName("IDX_JTDE_JN_JC_SN_HA");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.TempCompDate })
                    .HasDatabaseName("IDX_JTDE_JN_JCN_SN_TCD");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.ReadAlert, e.EmpCode })
                    .HasDatabaseName("IDX_JTDE_SPRNT_READ_ALRT");

                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.TempCompDate, e.EmpCode })
                    .HasDatabaseName("IDX_JTDE_SPRNT");

                entity.HasIndex(e => new { e.HoursAllowed, e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.EmpCode, e.TempCompDate })
                    .HasDatabaseName("IDX_JTDE_JN_JCN_SN_EC_TCD");

                entity.HasIndex(e => new { e.CardSeqNbr, e.ReadAlert, e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.EmpCode, e.TempCompDate })
                    .HasDatabaseName("IDX_JOBTRAFFICDETEMPS_0");

                entity.HasIndex(e => new { e.TempCompDate, e.CardSeqNbr, e.ReadAlert, e.EmpCode, e.Id, e.JobNumber, e.JobComponentNbr, e.SeqNbr })
                    .HasDatabaseName("IDX_JOB_TRAFFIC_DET_EMPS_EMP_CODE");

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.HoursAllowed).HasDefaultValueSql("(0)");

                entity.HasOne(d => d.JobTrafficDet)
                    .WithMany(p => p.JobTrafficDetEmps)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.SeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_EMPS");
            });

            modelBuilder.Entity<ProjectScheduleDetailPredecessor>(entity =>
            {
                entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr })
                    .HasDatabaseName("IDX_JTDP_JN_JCN_SN");

                entity.HasIndex(e => new { e.PredecessorSeqNbr, e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.Id })
                    .HasDatabaseName("IDX_JTDP_JN_JCN_SN_ID");

                entity.HasOne(d => d.JobTrafficDet)
                    .WithMany(p => p.JobTrafficDetPredJobTrafficDets)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.PredecessorSeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_PRED");

                entity.HasOne(d => d.JobTrafficDetNavigation)
                    .WithMany(p => p.JobTrafficDetPredJobTrafficDetNavigations)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr, d.SeqNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_DET_SUCC");
            });

            modelBuilder.Entity<ProjectSchedulePredecessor>(entity =>
            {
                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobTrafficPreds)
                    .HasForeignKey(d => new { d.JobNumber, d.JobComponentNbr })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JOB_TRAFFIC_PREDS_JOB_TRAFFIC");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.AvataxCompanyCode).IsUnicode(false);

                entity.Property(e => e.GlacodeAp).IsUnicode(false);

                entity.Property(e => e.GlacodeApDisc).IsUnicode(false);

                entity.Property(e => e.GlacodeApWh).IsUnicode(false);

                entity.Property(e => e.GlacodeAr).IsUnicode(false);

                entity.Property(e => e.GlacodeCity).IsUnicode(false);

                entity.Property(e => e.GlacodeClientLatePaymentFee).IsUnicode(false);

                entity.Property(e => e.GlacodeCounty).IsUnicode(false);

                entity.Property(e => e.GlacodeCrncyGainLoss).IsUnicode(false);

                entity.Property(e => e.GlacodeState).IsUnicode(false);

                entity.Property(e => e.GlacodeSuspense).IsUnicode(false);

                entity.Property(e => e.GlacodeVolDisc).IsUnicode(false);

                entity.Property(e => e.MglacodeAccAp).IsUnicode(false);

                entity.Property(e => e.MglacodeAccCos).IsUnicode(false);

                entity.Property(e => e.MglacodeAccTax).IsUnicode(false);

                entity.Property(e => e.MglacodeCos).IsUnicode(false);

                entity.Property(e => e.MglacodeDefCos).IsUnicode(false);

                entity.Property(e => e.MglacodeDefSales).IsUnicode(false);

                entity.Property(e => e.MglacodeSales).IsUnicode(false);

                entity.Property(e => e.MglacodeWip).IsUnicode(false);

                entity.Property(e => e.OfficeName).IsUnicode(false);

                entity.Property(e => e.PglacodeAccAp).IsUnicode(false);

                entity.Property(e => e.PglacodeAccCos).IsUnicode(false);

                entity.Property(e => e.PglacodeAccTax).IsUnicode(false);

                entity.Property(e => e.PglacodeCos).IsUnicode(false);

                entity.Property(e => e.PglacodeDefCos).IsUnicode(false);

                entity.Property(e => e.PglacodeDefSales).IsUnicode(false);

                entity.Property(e => e.PglacodeSales).IsUnicode(false);

                entity.Property(e => e.PglacodeWip).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => new { e.ClCode, e.DivCode, e.PrdCode });

                entity.HasIndex(e => e.ClCode)
                    .HasDatabaseName("XPRD_CLIENT");

                entity.HasIndex(e => e.DivCode)
                    .HasDatabaseName("XPRD_DIVISION");

                entity.HasIndex(e => e.OfficeCode)
                    .HasDatabaseName("XPRD_OFFICE");

                entity.HasIndex(e => e.PrdCode)
                    .HasDatabaseName("XPRD_PRODUCT");

                entity.HasIndex(e => new { e.PrdDescription, e.ClCode, e.DivCode, e.PrdCode })
                    .HasDatabaseName("IDX_PRODUCT_CL_CODE");

                entity.HasIndex(e => new { e.ClCode, e.DivCode, e.PrdCode, e.PrdDescription, e.OfficeCode, e.ActiveFlag })
                    .HasDatabaseName("IDX_PRODUCT_ACTIVE_FLAG");

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.Property(e => e.BatchName).IsUnicode(false);

                entity.Property(e => e.CurrencyCode).IsUnicode(false);

                entity.Property(e => e.EmailGrCode).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.PrdAlphaSort).IsUnicode(false);

                entity.Property(e => e.PrdAttention).IsUnicode(false);

                entity.Property(e => e.PrdBillAddress1).IsUnicode(false);

                entity.Property(e => e.PrdBillAddress2).IsUnicode(false);

                entity.Property(e => e.PrdBillCity).IsUnicode(false);

                entity.Property(e => e.PrdBillCountry).IsUnicode(false);

                entity.Property(e => e.PrdBillCounty).IsUnicode(false);

                entity.Property(e => e.PrdBillEmpTime).HasComputedColumnSql("([dbo].[udf_get_prod_bill_emp_time]([CL_CODE], [DIV_CODE], [PRD_CODE]))");

                entity.Property(e => e.PrdBillExtention).IsUnicode(false);

                entity.Property(e => e.PrdBillFax).IsUnicode(false);

                entity.Property(e => e.PrdBillFaxExt).IsUnicode(false);

                entity.Property(e => e.PrdBillRate).HasComputedColumnSql("([dbo].[udf_get_prod_bill_rate]([CL_CODE], [DIV_CODE], [PRD_CODE]))");

                entity.Property(e => e.PrdBillState).IsUnicode(false);

                entity.Property(e => e.PrdBillTelephone).IsUnicode(false);

                entity.Property(e => e.PrdBillZip).IsUnicode(false);

                entity.Property(e => e.PrdDescription).IsUnicode(false);

                entity.Property(e => e.PrdMagTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdMediaBcycle).IsUnicode(false);

                entity.Property(e => e.PrdMiscTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdNewsTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdOtdrTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdProdBcycle).IsUnicode(false);

                entity.Property(e => e.PrdProdTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdRadioTaxCode).IsUnicode(false);

                entity.Property(e => e.PrdSfBcycle).IsUnicode(false);

                entity.Property(e => e.PrdSfReconCode).IsUnicode(false);

                entity.Property(e => e.PrdStateAddr1).IsUnicode(false);

                entity.Property(e => e.PrdStateAddr2).IsUnicode(false);

                entity.Property(e => e.PrdStateCity).IsUnicode(false);

                entity.Property(e => e.PrdStateCountry).IsUnicode(false);

                entity.Property(e => e.PrdStateCounty).IsUnicode(false);

                entity.Property(e => e.PrdStateExt).IsUnicode(false);

                entity.Property(e => e.PrdStateFax).IsUnicode(false);

                entity.Property(e => e.PrdStateFaxExt).IsUnicode(false);

                entity.Property(e => e.PrdStateState).IsUnicode(false);

                entity.Property(e => e.PrdStateTelephon).IsUnicode(false);

                entity.Property(e => e.PrdStateZip).IsUnicode(false);

                entity.Property(e => e.PrdTvTaxCode).IsUnicode(false);

                entity.Property(e => e.UserDefined1).IsUnicode(false);

                entity.Property(e => e.UserDefined2).IsUnicode(false);

                entity.Property(e => e.UserDefined3).IsUnicode(false);

                entity.Property(e => e.UserDefined4).IsUnicode(false);

                entity.HasOne(d => d.OfficeCodeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OfficeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_OFFICE");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => new { d.ClCode, d.DivCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_DIVISION");
            });

            modelBuilder.Entity<ProductDocument>(entity =>
            {
                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.HasOne(d => d.Document)
                    .WithOne(p => p.ProductDocument)
                    .HasForeignKey<ProductDocument>(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_DOCS_DOCS");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDocuments)
                    .HasForeignKey(d => new { d.ClCode, d.DivCode, d.PrdCode })
                    .HasConstraintName("FK_PRODUCT_DOCS_PRODUCT");
            });

            modelBuilder.Entity<SecurityUser>(entity =>
            {
                entity.HasIndex(e => e.UserCode)
                    .HasDatabaseName("UQ__SEC_USER__A039F1EE51B918BB")
                    .IsUnique();

                entity.HasIndex(e => new { e.EmpCode, e.UserCode })
                    .HasDatabaseName("IDX_SEC_USER_CODES");

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserCode).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.WebId).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeCloak>(entity =>
            {
                entity.HasKey(e => e.EmpCode)
                    .HasName("PK_EMPLOYEE");

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.AdobeSignatureFilePassword).IsUnicode(false);

                entity.Property(e => e.CalTimeEmail).IsUnicode(false);

                entity.Property(e => e.CalTimeHost).IsUnicode(false);

                entity.Property(e => e.CalTimePassword).IsUnicode(false);

                entity.Property(e => e.CalTimeUsername).IsUnicode(false);

                entity.Property(e => e.CcDesc).IsUnicode(false);

                entity.Property(e => e.CcGlAccount).IsUnicode(false);

                entity.Property(e => e.CcNumber).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.CsPassword).IsUnicode(false);

                entity.Property(e => e.CultureCode).IsUnicode(false);

                entity.Property(e => e.DefFncCode).IsUnicode(false);

                entity.Property(e => e.DefTrfRole).IsUnicode(false);

                entity.Property(e => e.DpTmCode).IsUnicode(false);

                entity.Property(e => e.EmailPwd).IsUnicode(false);

                entity.Property(e => e.EmailReplyTo).IsUnicode(false);

                entity.Property(e => e.EmailUsername).IsUnicode(false);

                entity.Property(e => e.EmpAccountNbr).IsUnicode(false);

                entity.Property(e => e.EmpAddress1).IsUnicode(false);

                entity.Property(e => e.EmpAddress2).IsUnicode(false);

                entity.Property(e => e.EmpAlphaSort).IsUnicode(false);

                entity.Property(e => e.EmpCity).IsUnicode(false);

                entity.Property(e => e.EmpCountry).IsUnicode(false);

                entity.Property(e => e.EmpCounty).IsUnicode(false);

                entity.Property(e => e.EmpEmail).IsUnicode(false);

                entity.Property(e => e.EmpFname).IsUnicode(false);

                entity.Property(e => e.EmpLname).IsUnicode(false);

                entity.Property(e => e.EmpMi).IsUnicode(false);

                entity.Property(e => e.EmpPayToAddr1).IsUnicode(false);

                entity.Property(e => e.EmpPayToAddr2).IsUnicode(false);

                entity.Property(e => e.EmpPayToCity).IsUnicode(false);

                entity.Property(e => e.EmpPayToCountry).IsUnicode(false);

                entity.Property(e => e.EmpPayToCounty).IsUnicode(false);

                entity.Property(e => e.EmpPayToState).IsUnicode(false);

                entity.Property(e => e.EmpPayToZip).IsUnicode(false);

                entity.Property(e => e.EmpPhone).IsUnicode(false);

                entity.Property(e => e.EmpPhoneAlt).IsUnicode(false);

                entity.Property(e => e.EmpPhoneCell).IsUnicode(false);

                entity.Property(e => e.EmpPhoneWork).IsUnicode(false);

                entity.Property(e => e.EmpPhoneWorkExt).IsUnicode(false);

                entity.Property(e => e.EmpSsNbr).IsUnicode(false);

                entity.Property(e => e.EmpState).IsUnicode(false);

                entity.Property(e => e.EmpTitle).IsUnicode(false);

                entity.Property(e => e.EmpWorkDays).IsUnicode(false);

                entity.Property(e => e.EmpZip).IsUnicode(false);

                entity.Property(e => e.ExpRptApprover).IsUnicode(false);

                entity.Property(e => e.GoogleToken).IsUnicode(false);

                entity.Property(e => e.IsApiUser).IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).IsUnicode(false);

                entity.Property(e => e.Method).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.PoApprRuleCode).IsUnicode(false);

                entity.Property(e => e.ProofhqPassword).IsUnicode(false);

                entity.Property(e => e.ProofhqUsername).IsUnicode(false);

                entity.Property(e => e.SignaturePath).IsUnicode(false);

                entity.Property(e => e.SmtpServer).IsUnicode(false);

                entity.Property(e => e.SugarPassword).IsUnicode(false);

                entity.Property(e => e.SugarUsername).IsUnicode(false);

                entity.Property(e => e.SupervisorCode).IsUnicode(false);

                entity.Property(e => e.TimeZoneId).IsUnicode(false);

                entity.Property(e => e.VccPassword).IsUnicode(false);

                entity.Property(e => e.VccUsername).IsUnicode(false);

                entity.Property(e => e.VnCodeExp).IsUnicode(false);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.AgySettingsCode).IsUnicode(false);

                entity.Property(e => e.AgySettingsDesc).IsUnicode(false);
            });

            modelBuilder.Entity<Views.AlertView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WV_MYALERTSLIST");

                entity.Property(e => e.AlertLevel).IsUnicode(false);

                entity.Property(e => e.AlertNotifyName).IsUnicode(false);

                entity.Property(e => e.AlertStateName).IsUnicode(false);

                entity.Property(e => e.AlertUser).IsUnicode(false);

                entity.Property(e => e.Build).IsUnicode(false);

                entity.Property(e => e.BuildId).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.ClName).IsUnicode(false);

                entity.Property(e => e.CmpCode).IsUnicode(false);

                entity.Property(e => e.CmpName).IsUnicode(false);

                entity.Property(e => e.CurrentNotifyEmpCode).IsUnicode(false);

                entity.Property(e => e.CurrentNotifyEmpFml).IsUnicode(false);

                entity.Property(e => e.DismissedDate)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.DivName).IsUnicode(false);

                entity.Property(e => e.EmpCode).IsUnicode(false);

                entity.Property(e => e.GrpCampaign).IsUnicode(false);

                entity.Property(e => e.GrpClient).IsUnicode(false);

                entity.Property(e => e.GrpComponent).IsUnicode(false);

                entity.Property(e => e.GrpDivision).IsUnicode(false);

                entity.Property(e => e.GrpDueDate).IsUnicode(false);

                entity.Property(e => e.GrpDueDateDisplay).IsUnicode(false);

                entity.Property(e => e.GrpEstimate).IsUnicode(false);

                entity.Property(e => e.GrpEstimateComponent).IsUnicode(false);

                entity.Property(e => e.GrpJob).IsUnicode(false);

                entity.Property(e => e.GrpOffice).IsUnicode(false);

                entity.Property(e => e.GrpPriority).IsUnicode(false);

                entity.Property(e => e.GrpProduct).IsUnicode(false);

                entity.Property(e => e.GrpTask).IsUnicode(false);

                entity.Property(e => e.JobCompDesc).IsUnicode(false);

                entity.Property(e => e.JobDesc).IsUnicode(false);

                entity.Property(e => e.LowerBody).IsUnicode(false);

                entity.Property(e => e.LowerSubject).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.OfficeName).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.Property(e => e.PrdDescription).IsUnicode(false);

                entity.Property(e => e.SenderEmpCode).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.Property(e => e.TaskFncCode).IsUnicode(false);

                entity.Property(e => e.TaskFncDesc).IsUnicode(false);

                entity.Property(e => e.TimeDue).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.Ver).IsUnicode(false);

                entity.Property(e => e.VersionId).IsUnicode(false);

                entity.Property(e => e.VnCode).IsUnicode(false);

                entity.Property(e => e.VnName).IsUnicode(false);
            });

            modelBuilder.Entity<Views.AlertAttachmentView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WV_ALERTATTACHMENTLIST");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.MimeType).IsUnicode(false);

                entity.Property(e => e.RealFileName).IsUnicode(false);

                entity.Property(e => e.RepositoryFilename).IsUnicode(false);

                entity.Property(e => e.UserCode).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<MediaRFPHeader>(entity =>
            {
                entity.HasIndex(e => new { e.MediaBroadcastWorksheetMarketId, e.VnCode })
                    .HasDatabaseName("MEDIA_RFP_HEADER_MEDIA_BROADCAST_WORKSHEET_MARKET_ID_VN_CODE");

                entity.Property(e => e.CommentToVendor).IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.TimeDue).IsUnicode(false);

                entity.Property(e => e.VnCode).IsUnicode(false);
            });

            modelBuilder.Entity<MediaTrafficVendor>(entity =>
            {
                entity.HasIndex(e => new { e.MediaTrafficRevisionId, e.VnCode })
                    .HasDatabaseName("MEDIA_TRAFFIC_VENDOR_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.VnCode).IsUnicode(false);
            });

            modelBuilder.Entity<Views.ClientPortalAlertView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CP_ALERTLIST");

                entity.Property(e => e.AlertLevel).IsUnicode(false);

                entity.Property(e => e.AlertUser).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.ClName).IsUnicode(false);

                entity.Property(e => e.CmpCode).IsUnicode(false);

                entity.Property(e => e.CmpName).IsUnicode(false);

                entity.Property(e => e.DismissedDate)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DivCode).IsUnicode(false);

                entity.Property(e => e.DivName).IsUnicode(false);

                entity.Property(e => e.JobCompDesc).IsUnicode(false);

                entity.Property(e => e.JobDesc).IsUnicode(false);

                entity.Property(e => e.LowerBody).IsUnicode(false);

                entity.Property(e => e.LowerSubject).IsUnicode(false);

                entity.Property(e => e.OfficeCode).IsUnicode(false);

                entity.Property(e => e.OfficeName).IsUnicode(false);

                entity.Property(e => e.PrdCode).IsUnicode(false);

                entity.Property(e => e.PrdDescription).IsUnicode(false);

                entity.Property(e => e.SenderEmpCode).IsUnicode(false);

                entity.Property(e => e.Subject).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);
            });

            modelBuilder.Entity<ClientPortalAlertRecipient>(entity =>
            {
                entity.HasKey(e => new { e.AlertId, e.AlertRcptId })
                    .HasName("PK_CP_ALERT_RCPT_1");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.HasOne(d => d.Alert)
                    .WithMany(p => p.ClientPortalAlertRecipients)
                    .HasForeignKey(d => d.AlertId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CP_ALERT_RCPT_ALERT");
            });

            //modelBuilder.Entity<JobComponentTask>(entity =>
            //{
            //    entity.HasKey(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr });

            //    entity.HasIndex(e => new { e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.FncCode, e.TaskDescription, e.TaskStartDate, e.JobRevisedDate, e.DueTime, e.TaskStatus, e.JobCompletedDate })
            //        .HasDatabaseName("IDX_JOB_TRAFFIC_DET_JOB_COMPLETED_DATE");

            //    entity.HasIndex(e => new { e.DueTime, e.JobNumber, e.JobComponentNbr, e.SeqNbr, e.FncCode, e.TaskDescription, e.TaskStartDate, e.JobRevisedDate, e.RevisedDueTime, e.TaskStatus, e.JobCompletedDate })
            //        .HasDatabaseName("IDX_JOB_TRAFFIC_DET_JOB_COMPLETED_DATE_1");

            //    entity.Property(e => e.DueTime).IsUnicode(false);

            //    entity.Property(e => e.EmpCode)
            //        .IsUnicode(false)
            //        .HasComputedColumnSql("([dbo].[udf_get_task_employee]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

            //    entity.Property(e => e.FncCode).IsUnicode(false);

            //    entity.Property(e => e.FncEst).IsUnicode(false);

            //    entity.Property(e => e.HoursAssigned).HasComputedColumnSql("([dbo].[udf_get_task_hours]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

            //    entity.Property(e => e.ParentTask).IsUnicode(false);

            //    entity.Property(e => e.RevisedDueTime).IsUnicode(false);

            //    entity.Property(e => e.Rowid).ValueGeneratedOnAdd();

            //    entity.Property(e => e.TaskDescription).IsUnicode(false);

            //    entity.Property(e => e.TaskStatus).IsUnicode(false);

            //    entity.Property(e => e.TempCompDate).HasComputedColumnSql("([dbo].[udf_get_temp_comp_date]([JOB_NUMBER], [JOB_COMPONENT_NBR], [SEQ_NBR]))");

            //    entity.Property(e => e.TrfRole).IsUnicode(false);
            //});

            modelBuilder.Entity<ClientContact>(entity =>
            {
                entity.HasIndex(e => new { e.ContCode, e.ClCode })
                    .HasDatabaseName("IDX_CDP_CONT_HDR_CL");

                entity.HasIndex(e => new { e.ClCode, e.CpUser, e.InactiveFlag })
                    .HasDatabaseName("IDX_CDP_CONTACT_HDR_CL_CODE");

                entity.HasIndex(e => new { e.ContFname, e.ContLname, e.ContMi, e.CdpContactId, e.ContCode })
                    .HasDatabaseName("IDX_CDP_CONTACT_HDR_0");

                entity.HasIndex(e => new { e.ContFname, e.ContLname, e.ContMi, e.CdpContactId, e.CpUser, e.EmailRcpt, e.EmailAddress })
                    .HasDatabaseName("IDX_CDP_CONTACT_HDR_1");

                entity.Property(e => e.CellPhone).IsUnicode(false);

                entity.Property(e => e.ClCode).IsUnicode(false);

                entity.Property(e => e.ContAddress1).IsUnicode(false);

                entity.Property(e => e.ContAddress2).IsUnicode(false);

                entity.Property(e => e.ContCity).IsUnicode(false);

                entity.Property(e => e.ContCode).IsUnicode(false);

                entity.Property(e => e.ContCountry).IsUnicode(false);

                entity.Property(e => e.ContCounty).IsUnicode(false);

                entity.Property(e => e.ContExtention).IsUnicode(false);

                entity.Property(e => e.ContFax).IsUnicode(false);

                entity.Property(e => e.ContFaxExtention).IsUnicode(false);

                entity.Property(e => e.ContFml)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(coalesce((rtrim([CONT_FNAME]) + ' '),' ') + coalesce((ltrim(rtrim([CONT_MI]))),'') + case when (datalength(ltrim(rtrim([CONT_MI]))) = 0) then '' when (datalength(ltrim(rtrim([CONT_MI]))) is null) then '' else '. ' end + coalesce([CONT_LNAME],''))");

                entity.Property(e => e.ContFname).IsUnicode(false);

                entity.Property(e => e.ContLf)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(coalesce(([CONT_LNAME] + ', '),'') + coalesce((rtrim([CONT_FNAME])),''))");

                entity.Property(e => e.ContLname).IsUnicode(false);

                entity.Property(e => e.ContMi).IsUnicode(false);

                entity.Property(e => e.ContState).IsUnicode(false);

                entity.Property(e => e.ContTelephone).IsUnicode(false);

                entity.Property(e => e.ContTitle).IsUnicode(false);

                entity.Property(e => e.ContZip).IsUnicode(false);

                entity.Property(e => e.DefaultTask).IsUnicode(false);

                entity.Property(e => e.EmailAddress).IsUnicode(false);
            });

            modelBuilder.Entity<VendorRepresentative>(entity =>
            {
                entity.HasKey(e => new { e.VnCode, e.VrCode });

                entity.HasIndex(e => new { e.VrFname, e.VrLname, e.VrMi, e.VnCode, e.VrCode })
                    .HasDatabaseName("IDX_VEN_REP_VN_CODE");

                entity.Property(e => e.VnCode).IsUnicode(false);

                entity.Property(e => e.VrCode).IsUnicode(false);

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.VrAddress1).IsUnicode(false);

                entity.Property(e => e.VrAddress2).IsUnicode(false);

                entity.Property(e => e.VrCity).IsUnicode(false);

                entity.Property(e => e.VrCountry).IsUnicode(false);

                entity.Property(e => e.VrCounty).IsUnicode(false);

                entity.Property(e => e.VrExtention).IsUnicode(false);

                entity.Property(e => e.VrFax).IsUnicode(false);

                entity.Property(e => e.VrFaxExtention).IsUnicode(false);

                entity.Property(e => e.VrFirmName).IsUnicode(false);

                entity.Property(e => e.VrFname).IsUnicode(false);

                entity.Property(e => e.VrLabel).IsUnicode(false);

                entity.Property(e => e.VrLname).IsUnicode(false);

                entity.Property(e => e.VrMi).IsUnicode(false);

                entity.Property(e => e.VrPhoneCell).IsUnicode(false);

                entity.Property(e => e.VrState).IsUnicode(false);

                entity.Property(e => e.VrTelephone).IsUnicode(false);

                entity.Property(e => e.VrZip).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
