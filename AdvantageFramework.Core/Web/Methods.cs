using System;
using System.Collections.Generic;
using System.Text;

namespace AdvantageFramework.Core.Web
{
    public static partial class Methods
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum DeepLinkType
        {
            Internal = 1,
            External = 2,
            ClientPortalExternal = 3
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        // Public Function GenerateAPIQueryString(ByVal InputQueryString As AdvantageFramework.Web.QueryString) As AdvantageFramework.Web.QueryString

        // Dim OutputQueryString As New AdvantageFramework.Web.QueryString

        // Return OutputQueryString

        // End Function
        // Public Function ParseAPIQueryString(ByVal InputQueryString As AdvantageFramework.Web.QueryString) As AdvantageFramework.Web.QueryString

        // Dim OutputQueryString As New AdvantageFramework.Web.QueryString

        // Return OutputQueryString

        // End Function

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        //public static string BuildDeepLink(AdvantageFramework.Core.Security.Session Session, DeepLinkType Type, string QueryString)
        //{
        //    using (var DbContext = new AdvantageFramework.Core.Database.DbContext(Session.ConnectionString, Session.UserCode))
        //    {
        //        return BuildDeepLink(DbContext, Type, QueryString);
        //    }
        //}

        public static string BuildDeepLink(AdvantageFramework.Core.Database.DbContext DbContext, DeepLinkType Type, string QueryString)
        {

            // objects
            AdvantageFramework.Core.Database.Entities.Agency Agency = default;
            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
            return BuildDeepLink(Agency, Type, QueryString);
        }

        public static string BuildDeepLink(AdvantageFramework.Core.Database.Entities.Agency Agency, DeepLinkType Type, string QueryString)
        {
            string Value = string.Empty;
            string DeepLinkString = string.Empty; // Me.Encrypt(DeepLinkQueryString)
            string WebvantageURL = "";
            string ClientPortalURL = "";
            if (Agency.WebvantageUrl is object)
                WebvantageURL = Agency.WebvantageUrl;
            if (Agency.ClientportalUrl is object)
                ClientPortalURL = Agency.ClientportalUrl;
            WebvantageURL = FormatAgencyWebvantageURL(WebvantageURL);
            ClientPortalURL = FormatAgencyWebvantageURL(ClientPortalURL);
            DeepLinkString = DeepLinkString.Replace(WebvantageURL, "").Replace(ClientPortalURL, "");
            DeepLinkString = EncryptDeepLinkQueryString(QueryString);
            switch (Type)
            {
                case DeepLinkType.External:
                    {
                        if (string.IsNullOrWhiteSpace(WebvantageURL) == false)
                        {
                            Value = string.Format("{0}/NewApp?dl={1}", WebvantageURL, DeepLinkString);
                        }

                        break;
                    }

                case DeepLinkType.ClientPortalExternal:
                    {
                        if (string.IsNullOrWhiteSpace(ClientPortalURL) == false)
                        {
                            Value = string.Format("{0}/NewApp?dl={1}", ClientPortalURL, DeepLinkString);
                        }

                        break;
                    }
            }

            return Value;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static string EncryptDeepLinkQueryString(string QueryString)
        {
            return AdvantageFramework.Core.Security.Encryption.RijndaelSimpleEncrypt(QueryString) + "A";
        }

        public static string DecryptDeepLinkString(string DeepLink)
        {
            return AdvantageFramework.Core.Security.Encryption.RijndaelSimpleDecrypt(DeepLink.Substring(0, DeepLink.Length - 1));
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private static string FormatAgencyWebvantageURL(string Url)
        {
            string FormattedURL = Url;
            if (FormattedURL.EndsWith("/") == true)
                FormattedURL = FormattedURL.Substring(0, FormattedURL.Length - 1);
            if (FormattedURL.ToLower().StartsWith("http://") == false && FormattedURL.ToLower().StartsWith("https://") == false)
            {
                FormattedURL = "http://" + FormattedURL;
            }

            return FormattedURL;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
