using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Registry.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public partial class RegistryAttribute : Attribute
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _Section = "";
        private string _Key = "";
        private string _Default = "";

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string Section
        {
            get
            {
                string SectionRet = default;
                SectionRet = _Section;
                return SectionRet;
            }

            set
            {
                _Section = value;
            }
        }

        public string Key
        {
            get
            {
                string KeyRet = default;
                KeyRet = _Key;
                return KeyRet;
            }

            set
            {
                _Key = value;
            }
        }

        public string Default
        {
            get
            {
                string DefaultRet = default;
                DefaultRet = _Default;
                return DefaultRet;
            }

            set
            {
                _Default = value;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public RegistryAttribute(string Section, string Key, string Default)
        {
            _Section = Section;
            _Key = Key;
            _Default = Default;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
