using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.EnumUtilities.Attributes
{
    public partial class EnumObjectAttribute : Attribute
    {

        #region  Constants 



        #endregion

        #region  Enum 



        #endregion

        #region  Variables 

        private string _Code = "";
        private string _Description = "";

        #endregion

        #region  Properties 

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

        #endregion

        #region  Methods 

        public EnumObjectAttribute(string Code, string Description)
        {
            _Code = Code;
            _Description = Description;
        }

        public override string ToString()
        {
            string ToStringRet = default;
            ToStringRet = Code + " - " + Description;
            return ToStringRet;
        }

        #endregion

    }
}
