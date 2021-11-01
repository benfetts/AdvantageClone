using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Database.Core
{
    [Serializable()]
    public partial class Job //: AdvantageFramework.BaseClasses.BaseCore
    {

        #region  Constants 



        #endregion

        #region  Enum 

        public enum Properties
        {
            Number,
            OfficeCode,
            ClientCode,
            DivisionCode,
            ProductCode,
            Description,
            IsActive
        }

        #endregion

        #region  Variables 

        private int _Number = default;
        private string _OfficeCode = null;
        private string _ClientCode = null;
        private string _DivisionCode = null;
        private string _ProductCode = null;
        private string _Description = null;
        private int? _IsOpen = default;

        #endregion

        #region  Properties 

        public int Number
        {
            get
            {
                int NumberRet = default;
                NumberRet = _Number;
                return NumberRet;
            }

            set
            {
                _Number = value;
            }
        }

        public string OfficeCode
        {
            get
            {
                string OfficeCodeRet = default;
                OfficeCodeRet = _OfficeCode;
                return OfficeCodeRet;
            }

            set
            {
                _OfficeCode = value;
            }
        }

        public string ClientCode
        {
            get
            {
                string ClientCodeRet = default;
                ClientCodeRet = _ClientCode;
                return ClientCodeRet;
            }

            set
            {
                _ClientCode = value;
            }
        }

        public string DivisionCode
        {
            get
            {
                string DivisionCodeRet = default;
                DivisionCodeRet = _DivisionCode;
                return DivisionCodeRet;
            }

            set
            {
                _DivisionCode = value;
            }
        }

        public string ProductCode
        {
            get
            {
                string ProductCodeRet = default;
                ProductCodeRet = _ProductCode;
                return ProductCodeRet;
            }

            set
            {
                _ProductCode = value;
            }
        }

        public string Description
        {
            get
            {
                string DescriptionRet = default;
                DescriptionRet = _Description;
                return DescriptionRet;
            }

            set
            {
                _Description = value;
            }
        }

        public int? IsOpen
        {
            get
            {
                int? IsOpenRet = default;
                IsOpenRet = _IsOpen;
                return IsOpenRet;
            }

            set
            {
                _IsOpen = value;
            }
        }

        #endregion

        #region  Methods 

        public string ToString(bool WithDescription)
        {
            string ToStringRet = default;
            if (WithDescription)
            {
                ToStringRet = (AdvantageFramework.Core.StringUtilities.Methods.PadWithCharacter(Number.ToString(), 6, "0", true, true) + " - " + Description).Trim();
            }
            else
            {
                ToStringRet = AdvantageFramework.Core.StringUtilities.Methods.PadWithCharacter(Number.ToString(), 6, "0", true, true).Trim();
            }

            return ToStringRet;
        }

        public Job()
        {
        }

        public Job(object Job)
        {
            //base.SetValues(Job);
        }

        #endregion

    }
}
