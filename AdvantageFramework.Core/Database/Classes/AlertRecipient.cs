using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Classes
{
    public partial class AlertRecipient
    {
        public int ID { get; set; } = 0;
        public int AlertID { get; set; } = 0;
        public string EmployeeCode { get; set; } = string.Empty;
        public string EmployeeEmail { get; set; } = string.Empty;
        public string EmployeeFullName { get; set; } = string.Empty;
        public byte[] EmployeeImage { get; set; }
        public bool IsCurrentRecipient { get; set; } = false;
        public bool IsCurrentNotify { get; set; } = false;
        public bool IsTaskEmployee { get; set; } = false;
        public bool IsTaskTempComplete { get; set; } = false;
        public int ClientContactID { get; set; } = 0;
        public bool IsClientContact { get; set; } = false;
        public bool CompletedDismissed { get; set; } = false;
        public int? AlertTemplateID { get; set; } = 0;
        public int? AlertStateID { get; set; } = 0;
        public bool? CurrentStateCompleted { get; set; } = false;
        public bool IsCurrentAssignee { get; set; } = false;

        public string Code
        {
            get
            {
                return EmployeeCode;
            }
        }

        public string FullName
        {
            get
            {
                return EmployeeFullName;
            }
        }

        public string Name
        {
            get
            {
                return EmployeeFullName;
            }
        }
    }
}
