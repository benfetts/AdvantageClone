using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdvantageFramework.Core.Web.Classes
{
    [Serializable()]
    public partial class DeepLink
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum LinkType
        {
            Internal = 1,
            External = 2,
            ClientPortalExternal = 3
        }

        public enum LinkDisplay
        {
            Rename,
            ShowURL,
            Blank
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private AdvantageFramework.Core.Web.QueryString _QueryString;
        private string _WebvantageURL = string.Empty;
        private string _ClientPortalURL = string.Empty;
        /* TODO ERROR: */
        //private AdvantageFramework.Core.Security.Session _SecuritySession = default;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string URL { get; set; } = string.Empty;
        public AdvantageFramework.Core.Web.QueryString.ContentAreaName DeepLinkContentType { get; set; }

        public AdvantageFramework.Core.Web.QueryString QueryString
        {
            get
            {
                return _QueryString;
            }

            set
            {
                _QueryString = value;
            }
        }

        public bool ClientPortalVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_ClientPortalURL);
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        //public bool UrlToInternalLink(ref string TextString, ref System.Web.UI.WebControls.PlaceHolder PlaceHolder, LinkDisplay DisplayAs)
        //{
        //    bool HasInternalLink = false;
        //    if (string.IsNullOrWhiteSpace(TextString) == true || TextString.Contains("<img") == true || TextString.Contains("data:image") == true || TextString.Contains("Click here to navigate") == true)
        //    {
        //        HasInternalLink = false;
        //    }
        //    else
        //    {
        //        string FixedBodyText = string.Empty;
        //        string Splitter = "?dl=";
        //        string URL = string.Empty;
        //        System.Text.RegularExpressions.MatchCollection MatchCollection = null;
        //        string InternalPage = string.Empty;
        //        int Counter = 0;
        //        string ReferenceText = string.Empty;
        //        try
        //        {
        //            FixedBodyText = TextString;
        //            MatchCollection = AdvantageFramework.Core.AlertSystem.Methods.GetUrlMatchCollection(ref FixedBodyText, _WebvantageURL, _ClientPortalURL);
        //            if (MatchCollection is object)
        //            {
        //                var ListOpenLiteral = new System.Web.UI.WebControls.Literal();
        //                var ListCloseLiteral = new System.Web.UI.WebControls.Literal();
        //                ListOpenLiteral.Text = "<ul>";
        //                ListCloseLiteral.Text = "</ul>";
        //                if (PlaceHolder.Visible == true)
        //                    PlaceHolder.Controls.Add(ListOpenLiteral);
        //                foreach (var Match in MatchCollection.OfType<System.Text.RegularExpressions.Match>().Where(m => m.Success == true))
        //                {
        //                    InternalPage = string.Empty;
        //                    ReferenceText = string.Empty;
        //                    try
        //                    {
        //                        URL = Match.Value;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        URL = string.Empty;
        //                    }

        //                    if (string.IsNullOrWhiteSpace(URL) == false)
        //                    {
        //                        try
        //                        {
        //                            InternalPage = URL.Substring(URL.IndexOf(Splitter) + Splitter.Length, URL.Length - URL.IndexOf(Splitter) - Splitter.Length);
        //                            InternalPage = AdvantageFramework.Core.Web.Methods.DecryptDeepLinkString(InternalPage);
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            InternalPage = string.Empty;
        //                        }

        //                        if (string.IsNullOrWhiteSpace(InternalPage) == false)
        //                        {
        //                            Counter += 1;
        //                            switch (DisplayAs)
        //                            {
        //                                case LinkDisplay.Blank:
        //                                    {
        //                                        ReferenceText = string.Format("Link {0}", Counter.ToString());
        //                                        FixedBodyText = FixedBodyText.Replace(URL, string.Format("&nbsp;"));
        //                                        // FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>&nbsp;</div>"))
        //                                        if (PlaceHolder.Visible == true)
        //                                            AddInternalLinkToPlaceHolder(ref PlaceHolder, InternalPage, ReferenceText);
        //                                        break;
        //                                    }

        //                                case LinkDisplay.Rename:
        //                                    {
        //                                        ReferenceText = string.Format("Link {0}", Counter.ToString());
        //                                        FixedBodyText = FixedBodyText.Replace(URL, string.Format("{0}", ReferenceText));
        //                                        // FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", ReferenceText))
        //                                        if (PlaceHolder.Visible == true)
        //                                            AddInternalLinkToPlaceHolder(ref PlaceHolder, InternalPage, ReferenceText);
        //                                        break;
        //                                    }

        //                                case LinkDisplay.ShowURL:
        //                                    {
        //                                        FixedBodyText = FixedBodyText.Replace(URL, string.Format("{0}", URL));
        //                                        // FixedBodyText = FixedBodyText.Replace(URL, String.Format("<div>{0}</div>", URL))
        //                                        if (PlaceHolder.Visible == true)
        //                                            AddInternalLinkToPlaceHolder(ref PlaceHolder, InternalPage, URL);
        //                                        break;
        //                                    }
        //                            }

        //                            HasInternalLink = true;
        //                        }
        //                    }
        //                }

        //                if (PlaceHolder.Visible == true)
        //                    PlaceHolder.Controls.Add(ListCloseLiteral);
        //                TextString = FixedBodyText;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            HasInternalLink = false;
        //        }
        //    }

        //    return HasInternalLink;
        //}

        //private bool AddInternalLinkToPlaceHolder(ref System.Web.UI.WebControls.PlaceHolder PlaceHolder, string InternalPage, string ReferenceText)
        //{
        //    try
        //    {
        //        InternalPage = InternalPage.Replace(string.Format("{0}/", _WebvantageURL), "").Replace(string.Format("{0}/", _ClientPortalURL), "");
        //        var InternalLinkButton = new System.Web.UI.WebControls.LinkButton();
        //        var DivOpenLiteral = new System.Web.UI.WebControls.Literal();
        //        var DivCloseLiteral = new System.Web.UI.WebControls.Literal();
        //        DivOpenLiteral.Text = "<li style=\"display: block !important;word-break:break-all !important;font-size: 14px !important;\">";
        //        DivCloseLiteral.Text = "</li>";
        //        InternalLinkButton.CssClass = "permalink-text";
        //        InternalLinkButton.OnClientClick = string.Format("OpenRadWindow('', '" + InternalPage + "', 0, 0); return false;");
        //        InternalLinkButton.Text = ReferenceText;
        //        InternalLinkButton.ToolTip = "Click to open " + ReferenceText;
        //        PlaceHolder.Controls.Add(DivOpenLiteral);
        //        PlaceHolder.Controls.Add(InternalLinkButton);
        //        PlaceHolder.Controls.Add(DivCloseLiteral);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public string Build(AdvantageFramework.Core.Web.Methods.DeepLinkType Type, AdvantageFramework.Core.Web.QueryString DeepLinkQueryString)
        //{
        //    return AdvantageFramework.Core.Web.Methods.BuildDeepLink(_SecuritySession, Type, QueryString.ToString(true));
        //}

        public void BuildJavascriptFromQueryString(AdvantageFramework.Core.Web.QueryString DeepLinkQueryString, ref string WebvantageLink, ref string ClientPortalLink)
        {
            WebvantageLink = string.Empty;
            ClientPortalLink = string.Empty;
            BuildFromQueryString(DeepLinkQueryString, ref WebvantageLink, ref ClientPortalLink);
            if (string.IsNullOrWhiteSpace(WebvantageLink) == false)
            {
                WebvantageLink = string.Format("copyToClipboard('{0}');", WebvantageLink);
            }

            if (string.IsNullOrWhiteSpace(ClientPortalLink) == false)
            {
                ClientPortalLink = string.Format("copyToClipboard('{0}');", ClientPortalLink);
            }
        }

        public void BuildFromQueryString(AdvantageFramework.Core.Web.QueryString DeepLinkQueryString, ref string WebvantageLink, ref string ClientPortalLink)
        {
            WebvantageLink = string.Empty;
            ClientPortalLink = string.Empty;
            if (DeepLinkQueryString is object)
            {
                string Link = string.Empty; // DeepLinkQueryString.DeepLink
                try
                {
                    if (string.IsNullOrWhiteSpace(DeepLinkQueryString.Page) == false)
                    {
                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, _WebvantageURL, "", RegexOptions.IgnoreCase);
                        DeepLinkQueryString.Page = Regex.Replace(DeepLinkQueryString.Page, _ClientPortalURL, "", RegexOptions.IgnoreCase);
                        if (DeepLinkQueryString.Page.StartsWith("/") == true)
                        {
                            DeepLinkQueryString.Page = DeepLinkQueryString.Page.Substring(1, DeepLinkQueryString.Page.Length - 1);
                        }
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    if (string.IsNullOrWhiteSpace(DeepLinkQueryString.DeepLink) == true)
                    {
                        Link = AdvantageFramework.Core.Web.Methods.EncryptDeepLinkQueryString(DeepLinkQueryString.ToString(true));
                    }
                    else
                    {
                        Link = DeepLinkQueryString.DeepLink;
                    }
                }
                catch (Exception)
                {
                    Link = string.Empty;
                }

                if (string.IsNullOrWhiteSpace(Link) == false)
                {
                    if (string.IsNullOrWhiteSpace(_WebvantageURL) == false)
                    {
                        WebvantageLink = string.Format("{0}/NewApp?dl={1}", _WebvantageURL, Link);
                    }

                    if (string.IsNullOrWhiteSpace(_ClientPortalURL) == false)
                    {
                        ClientPortalLink = string.Format("{0}/NewApp?dl={1}", _ClientPortalURL, Link);
                    }
                }
            }
        }

        //public bool TextHasInternalLinks(string TextString)
        //{
        //    return AdvantageFramework.Core.AlertSystem.Methods.TextHasInternalLinks(TextString, _WebvantageURL, _ClientPortalURL);
        //}

        //private void SetApplicationURL()
        //{
        //    _WebvantageURL = string.Empty;
        //    _ClientPortalURL = string.Empty;
        //    if (_SecuritySession is object)
        //    {
        //        using (var DbContext = new AdvantageFramework.Core.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode))
        //        {
        //            AdvantageFramework.Core.Database.Entities.Agency Agency;
        //            Agency = default;
        //            Agency = AdvantageFramework.Core.Database.Procedures.Agency.Load(DbContext);
        //            if (Agency is object)
        //            {
        //                if (Agency.WebvantageUrl is object)
        //                    _WebvantageURL = Agency.WebvantageUrl;
        //                if (Agency.ClientportalUrl is object)
        //                    _ClientPortalURL = Agency.ClientportalUrl;
        //                CheckURLs();
        //            }
        //        }
        //    }
        //}

        private void CheckURLs()
        {
            if (_WebvantageURL.EndsWith("/") == true)
                _WebvantageURL = _WebvantageURL.Substring(0, _WebvantageURL.Length - 1);
            if (_ClientPortalURL.EndsWith("/") == true)
                _ClientPortalURL = _ClientPortalURL.Substring(0, _ClientPortalURL.Length - 1);
            if (_WebvantageURL.ToLower().StartsWith("http://") == false && _WebvantageURL.ToLower().StartsWith("https://") == false)
            {
                _WebvantageURL = "http://" + _WebvantageURL;
            }

            if (_ClientPortalURL.ToLower().StartsWith("http://") == false && _ClientPortalURL.ToLower().StartsWith("https://") == false)
            {
                _ClientPortalURL = "http://" + _ClientPortalURL;
            }

            // If Me._WebvantageURL.EndsWith("/") = False Then Me._WebvantageURL &= "/"
            // If Me._ClientPortalURL.EndsWith("/") = False Then Me._ClientPortalURL &= "/"

        }

        //public DeepLink(AdvantageFramework.Core.Security.Session SecuritySession)
        //{
        //    _SecuritySession = SecuritySession;
        //    _QueryString = new AdvantageFramework.Core.Web.QueryString();
        //    SetApplicationURL();
        //}

        //public DeepLink(AdvantageFramework.Core.Security.Session SecuritySession, AdvantageFramework.Core.Web.QueryString QueryString)
        //{
        //    _SecuritySession = SecuritySession;
        //    if (QueryString is object)
        //    {
        //        _QueryString = QueryString;
        //    }
        //    else
        //    {
        //        _QueryString = new AdvantageFramework.Core.Web.QueryString();
        //    }

        //    SetApplicationURL();
        //}

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}
