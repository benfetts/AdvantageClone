using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Database.Entities
{
    public class CompleteAssignmentResult
    {
        #region Constants



        #endregion

        #region Enum
        public enum Properties
        {
            AlertID,
            IsCompleting,
            IsRouted,
            IsTask,
            IsAutoRoute,
            InitialAlertTemplateID,
            InitialAlertStateID,
            FinalAlertTemplateID,
            FinalAlertStateID,
            AutoRouteChangedState,
            CurrentAssigneesString,
            CurrentAssigneesArray,
            CurrentAssigneesList,
            Success,
            Message,
            AssignmentFullyCompleted
        }

        #endregion

        #region Variables



        #endregion

        #region Properties

        public int? AlertID { get; set; } = 0;
        public bool? IsCompleting { get; set; } = false;
        public bool? IsRouted { get; set; } = false;
        public bool? IsTask { get; set; } = false;
        public bool? IsAutoRoute { get; set; } = false;
        public int? InitialAlertTemplateID { get; set; } = 0;
        public int? InitialAlertStateID { get; set; } = 0;
        public int? FinalAlertTemplateID { get; set; } = 0;
        public int? FinalAlertStateID { get; set; } = 0;
        public bool? AutoRouteChangedState { get; set; } = false;
        public string CurrentAssigneesString { get; set; } = string.Empty;

        public string[] CurrentAssigneesArray
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CurrentAssigneesString) == false)
                {
                    return CurrentAssigneesString.Split(",");
                }
                else
                {
                    return null;
                }
            }
        }

        public List<string> CurrentAssigneesList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CurrentAssigneesString) == false)
                {
                    return CurrentAssigneesString.Split(",").ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public bool? Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public bool? AssignmentFullyCompleted { get; set; } = false;
        public bool? IsProof { get; set; } = false;

        #endregion

        #region Methods

        public CompleteAssignmentResult()
        {
        }
        #endregion
    }
}
