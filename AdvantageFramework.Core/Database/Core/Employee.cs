using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Core
{
    public partial class Employee //: AdvantageFramework.BaseClasses.BaseCore
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum Properties
        {
            Code,
            FirstName,
            MiddleInitial,
            LastName,
            TerminationDate
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _Code = null;
        private string _FirstName = null;
        private string _MiddleInitial = null;
        private string _LastName = null;
        private DateTime? _TerminationDate = default;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string Code
        {
            get
            {
                string CodeRet = default;
                CodeRet = _Code;
                return CodeRet;
            }

            set
            {
                _Code = value;
            }
        }

        public string FirstName
        {
            get
            {
                string FirstNameRet = default;
                FirstNameRet = _FirstName;
                return FirstNameRet;
            }

            set
            {
                _FirstName = value;
            }
        }

        public string MiddleInitial
        {
            get
            {
                string MiddleInitialRet = default;
                MiddleInitialRet = _MiddleInitial;
                return MiddleInitialRet;
            }

            set
            {
                _MiddleInitial = value;
            }
        }

        public string LastName
        {
            get
            {
                string LastNameRet = default;
                LastNameRet = _LastName;
                return LastNameRet;
            }

            set
            {
                _LastName = value;
            }
        }

        public DateTime? TerminationDate
        {
            get
            {
                DateTime? TerminationDateRet = default;
                TerminationDateRet = _TerminationDate;
                return TerminationDateRet;
            }

            set
            {
                _TerminationDate = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override string ToString()
        {
            string ToStringRet = default;
            if (MiddleInitial is object && !string.IsNullOrEmpty(MiddleInitial.Trim()))
            {
                ToStringRet = FirstName + " " + MiddleInitial + ". " + LastName;
            }
            else
            {
                ToStringRet = FirstName + " " + LastName;
            }

            return ToStringRet;
        }

        public Employee()
        {
        }

        public Employee(object Employee)
        {
            //base.SetValues(Employee);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
