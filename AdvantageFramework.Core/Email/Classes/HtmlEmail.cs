using AdvantageFramework.Core.Database.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvantageFramework.Core.Email.Classes
{
    [Serializable()]
    public class HtmlEmail
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const int _LeftColumnWidth = 110;
        private const string _HorizontalLine = "<hr style=\"width: 100% !important;\" width=\"100%\" />";
        // Private Const _HorizontalLine As String = "<table cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""width: 100% !important;""><tr><td align=""left"" valign=""top"" width=""100%"" height=""1"" style=""background-color: #696969; border-collapse:collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; mso-line-height-rule: exactly; line-height: 1px;""><!--[if gte mso 15]>&nbsp;<![endif]--></td></tr></table>"
        private const string _AdvantageLogoSmallImageTag = "<img alt=\"The Advantage Software Company\" src=\"{0}\" />";
        private const string _AdvantageLogoSmallBase64 = "data:image/png;base64,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";
        private const string _BulletSpacer = "&nbsp;&nbsp;•&nbsp;&nbsp;";

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public enum SeparatorLineType
        {
            Solid,
            Double,
            Dotted,
            Dashed
        }

        public enum EmailButtonType
        {
            Primary,
            Success,
            Danger,
            Secondary
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private StringBuilder _StringBuilderEmail = null;
        private bool _IncludeBodyTag = false;
        private bool _HeaderShowBottomBorder = false;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string AddComment(string WebvantageURL, string ClientPortalURL, string EmployeeFullName, string UserCode, DateTime? GeneratedDate, DateTime? CustodyEndDate, string Comment)
        {
            string CommentString = string.Empty;
            if (string.IsNullOrWhiteSpace(Comment) == false)
            {
                //AdvantageFramework.AlertSystem.UrlToHtmlLink(CommentString, WebvantageURL, ClientPortalURL);
                CommentString += "<div>";
                CommentString += WrapInFont(Comment.Replace(Environment.NewLine, "<br/>"));
                CommentString += "</div>";
                CommentString += "<div>";
                CommentString += "<strong>";
                if (string.IsNullOrEmpty(EmployeeFullName) == false)
                {

                    // CommentString &= EmployeeFullName & _BulletSpacer
                    CommentString += "-&nbsp;&nbsp;" + EmployeeFullName;
                }
                else if (string.IsNullOrEmpty(UserCode) == false)
                {
                    CommentString += UserCode + _BulletSpacer;
                    // CommentString &= UserCode & _BulletSpacer

                }

                if (GeneratedDate.HasValue)
                {
                    CommentString += ", " + string.Format("{0:G}", GeneratedDate);
                }

                if (CustodyEndDate.HasValue)
                {
                    CommentString += "&nbsp;-&nbsp;" + string.Format("{0:G}", CustodyEndDate);
                }

                CommentString += "</strong>";
                CommentString += "</div>";
                WrapInSmallFont(CommentString);
            }

            return CommentString;
        }

        public string TimeSheetLink(DateTime TimeSheetDate, string LinkText, bool FullWeek, string BaseURL, string EmployeeCode)
        {
            string HyperLink = string.Empty;
            if (TimeSheetDate != default)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(LinkText) == true)
                        LinkText = TimeSheetDate.ToShortDateString();
                    if (BaseURL.EndsWith("/") == true)
                        BaseURL = BaseURL.Substring(0, BaseURL.Length - 1);

                    // Dim URL As String = String.Format("{0}/Timesheet.aspx?sd={1}&flwk={2}", BaseURL, TimeSheetDate.ToShortDateString, FullWeek.ToString.ToLower)
                    string URL = "";
                    if (FullWeek == true)
                    {
                        URL = string.Format("{0}/Employee/Timesheet?sd={1}&emp={2}", BaseURL, TimeSheetDate.ToShortDateString(), EmployeeCode);
                    }
                    else
                    {
                        URL = string.Format("{0}/Employee/Timesheet?sd={1}&dtd=1&nav=4&isdd=1&emp={2}", BaseURL, TimeSheetDate.ToShortDateString(), EmployeeCode);
                    }

                    HyperLink = string.Format("<a href=\"{0}\">{1}</a>", URL, LinkText);
                }
                catch (Exception)
                {
                    HyperLink = LinkText;
                }
            }

            return HyperLink;
        }

        public string AlertLink(AdvantageFramework.Core.Database.Entities.Agency Agency, int AlertID, string LinkText, Web.Methods.DeepLinkType DeepLinkType, int AlertCategoryID = 0)
        {
            string HyperLink = string.Empty;
            string URL = string.Empty;
            if (string.IsNullOrWhiteSpace(LinkText) == true)
                LinkText = "Click to view this alert.";
            if (AlertCategoryID == 38)
            {
                URL = string.Format("Alert_View.aspx?AlertID={0}&openasassign=false", AlertID);
            }
            else
            {
                URL = string.Format("Desktop_AlertView?AlertID={0}&SprintID=0", AlertID);
            }

            URL = AdvantageFramework.Core.Web.Methods.BuildDeepLink(Agency, DeepLinkType, URL);
            HyperLink = string.Format("<a href=\"{0}\">{1}</a>", URL, LinkText);
            return HyperLink;
        }

        public string AssignmentLink(AdvantageFramework.Core.Database.Entities.Agency Agency, int AlertID, int SprintID, string LinkText, Web.Methods.DeepLinkType DeepLinkType)
        {
            string HyperLink = string.Empty;
            string URL = string.Empty;
            if (string.IsNullOrWhiteSpace(LinkText) == true)
                LinkText = "Click to view this assignment.";
            URL = string.Format("Desktop_AlertView?AlertID={0}&SprintID={1}", AlertID, SprintID);
            URL = AdvantageFramework.Core.Web.Methods.BuildDeepLink(Agency, DeepLinkType, URL);
            HyperLink = string.Format("<a href=\"{0}\">{1}</a>", URL, LinkText);
            return HyperLink;
        }

        public string ConceptShareReviewLink(AdvantageFramework.Core.Database.Entities.Agency Agency, int AlertID, int ConceptShareProjectID, int ConceptShareReviewID, string LinkText, Web.Methods.DeepLinkType DeepLinkType)
        {
            string HyperLink = string.Empty;
            string URL = string.Empty;
            if (string.IsNullOrWhiteSpace(LinkText) == true)
                LinkText = "Click to view this review.";
            URL = string.Format("Alert_DigitalAssetReview.aspx?alert={0}&a={0}&cspid={1}&csrid={2}", AlertID, ConceptShareProjectID, ConceptShareReviewID);
            URL = AdvantageFramework.Core.Web.Methods.BuildDeepLink(Agency, DeepLinkType, URL);
            HyperLink = string.Format("<a href=\"{0}\">{1}</a>", URL, LinkText);
            return HyperLink;
        }

        /* TODO ERROR */
        public string ExpenseApprovalModuleLink(AdvantageFramework.Core.Database.Entities.Agency Agency, string EmployeeCode, Web.Methods.DeepLinkType DeepLinkType)
        {
            string HyperLink = string.Empty;
            string URL = string.Empty;
            string LinkText = "Click here to navigate to the Expense Approval module (non-mobile).";
            string DateText = DateTime.Today.ToShortDateString();
            URL = string.Format("SupervisorApproval_Expense.aspx?sedate={0}&empcode={1}", DateText, EmployeeCode);
            /* TODO ERROR */
            URL = Web.Methods.BuildDeepLink(Agency, DeepLinkType, URL);
            HyperLink = string.Format("<a href=\"{0}\">{1}</a>", URL, LinkText);
            return HyperLink;
        }

        public string EmailButton(string URL, string ButtonText, string TitleText, EmailButtonType ButtonType)
        {
            string BorderColor = "";
            string BackgroundColor = "";
            string TextColor = "";
            switch (ButtonType)
            {
                case EmailButtonType.Success:
                    {

                        // BorderColor = "398439"
                        BorderColor = "5CB85C";
                        BackgroundColor = "5CB85C";
                        TextColor = "FFFFFF";
                        break;
                    }

                case EmailButtonType.Danger:
                    {

                        // BorderColor = "D43F3A"
                        BorderColor = "D9534F";
                        BackgroundColor = "D9534F";
                        TextColor = "FFFFFF";
                        break;
                    }

                case EmailButtonType.Secondary:
                    {
                        BorderColor = "F0F0F0";
                        BackgroundColor = "F0F0F0";
                        TextColor = "767676";
                        break;
                    }

                case EmailButtonType.Primary:
                    {
                        BorderColor = "2A579A";
                        BackgroundColor = "2A579A";
                        TextColor = "FFFFFF";
                        break;
                    }
            }

            return string.Format("<table width='115px' style='width:115px;'><tr><td style='width:115px;'><a href='{0}' title='{2}' style='text-decoration: none !important;'>" + "<div style='padding-top: 0px;width: 115px !important;max-width: 115px !important;min-width: 115px !important; height: 24px; border: 1px solid #{3};" + "border-radius:4px;text-align: center;vertical-align: middle;background-color:#{4};color:#{5};text-decoration: none !important;'>{1}</div></a></td></tr></table>", URL, ButtonText, TitleText, BorderColor, BackgroundColor, TextColor);
        }

        public static string Indent(int NumberOfSpaces = 1)
        {
            string s = "";

            for(int i = 0; i < NumberOfSpaces; i++)
            {
                s += Methods.NonBreakingSpace;
            }

            return s;
        }

        public void AddHeaderRow(string HeaderText)
        {
            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                /* TODO ERROR */
                withBlock.Append("<td colspan=\"2\" align=\"left\" valign=\"middle\" bgcolor=\"" + Methods.HeaderBackgroundColor + "\"");

                // If _HeaderShowBottomBorder = True Then .Append("style=""border-bottom: 1px solid " & HorizontalLineColor & " !important;""")

                withBlock.Append(">");
                withBlock.Append("<font size=\"" + Methods.HeaderFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.HeaderFontColor + "\">");
                withBlock.Append("");
                if (Methods.HeaderBold == true)
                    withBlock.Append("<strong>");
                withBlock.Append(HeaderText);
                if (Methods.HeaderBold == true)
                    withBlock.Append("</strong>");
                withBlock.Append("</font>");

                // 'If _HeaderShowBottomBorder = True Then
                // .Append("<hr style=""border-top: 1px solid #EEEEEE !important;"" />")
                // 'End If

                withBlock.Append(_HorizontalLine);
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        public void AddKeyValueRow(string Key, string Value)
        {
            if (Value is null)
            {
                Value = "";
            }

            if (string.IsNullOrEmpty(Key.Trim()))
            {
                Key = Methods.NonBreakingSpace;
            }

            if (string.IsNullOrEmpty(Value.Trim()))
            {
                Value = Methods.NonBreakingSpace;
            }

            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\" width=\"" + _LeftColumnWidth.ToString() + "\">");
                withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                withBlock.Append(Key);
                if (Key != Methods.NonBreakingSpace)
                {
                    withBlock.Append(":");
                }

                withBlock.Append("</font>");
                withBlock.Append("</td>");
                withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                withBlock.Append(Value);
                withBlock.Append("</font>");
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        public void AddKeyValueRowNoCell(string Key, string Value)
        {
            string Text = string.Empty;
            if (string.IsNullOrWhiteSpace(Value) == true)
            {
                Value = "--";
            }

            if (string.IsNullOrWhiteSpace(Key) == false)
            {
                if (Key.EndsWith(":") == false)
                {
                    Key = Key + ":";
                }

                Text = string.Format("{0}&nbsp;&nbsp;{1}", Key, Value);
            }
            else
            {
                Text = Value;
            }

            AddCustomRow(Text);
        }

        public void AddButtonLinkRow(string URL, string LinkText = "", string ToolTip = "")
        {
            string HtmlButton = "<a href=\"{0}\" target=\"_blank\" style=\"font-size: 12px; font-family:Arial, Helvetica, sans-serif; color: #ffffff; text-decoration: none; border-radius: 5px; -webkit-border-radius: 5px; -moz-border-radius: 5px; background-color: #5CB85C; border-top: 7px solid #5CB85C; border-bottom: 7px solid #5CB85C; border-right: 10px solid #5CB85C; border-left: 9px solid #5CB85C; display: inline-block;\" title=\"{2}\">&nbsp;&nbsp;{1}&nbsp;&nbsp;</a>";
            if (string.IsNullOrWhiteSpace(LinkText) == true)
            {
                LinkText = "Click Here";
            }

            if (string.IsNullOrWhiteSpace(ToolTip) == true)
            {
                ToolTip = "Click Here";
            }

            AddCustomRow(string.Format(HtmlButton, URL, LinkText, ToolTip));
        }

        public void AddHyperlinkRow(string URL, string LinkText = "")
        {
            var sb = new StringBuilder();
            sb.Append("<a href=\"" + URL + "\">");
            if (!string.IsNullOrEmpty(LinkText.Trim()))
            {
                sb.Append(LinkText);
            }
            else
            {
                sb.Append(URL);
            }

            sb.Append("</a>");
            AddCustomRow(sb.ToString());
        }

        public void AddBlankRow()
        {
            AddCustomRow("&nbsp;");
        }

        public void AddCustomRow(string RowContent)
        {
            if (string.IsNullOrWhiteSpace(RowContent) == true)
            {
                RowContent = "&nbsp;";
            }

            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                /* TODO ERROR */
                withBlock.Append("<td colspan=\"2\" align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                withBlock.Append(WrapInFont(RowContent));
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        public void AddCustomRowLeftPad(string RowContent, int Indent)
        {
            string CellPadForOutlook = "";
            string IndentText = "";
            if (string.IsNullOrWhiteSpace(RowContent) == true)
            {
                RowContent = "&nbsp;";
            }

            if (Indent > 0)
            {
                for (int i = 0, loopTo = Indent; i <= loopTo; i++)
                    IndentText += "&nbsp;&nbsp;&nbsp;";
            }

            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                /* TODO ERROR */
                withBlock.Append("<td colspan=\"2\" align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\"" + CellPadForOutlook + ">");
                withBlock.Append(string.Format("<table><tr><td>{0}</td><td>{1}</td></tr></table>", IndentText, WrapInFont(RowContent)));
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        private string WrapInFont(string Text)
        {
            string NewText = string.Empty;
            /* TODO ERROR */
            NewText = string.Format("<font size=\"{0}\" face=\"{1}\" color=\"{2}\">{3}</font>", Methods.RowFontSize, Methods.Font, Methods.RowFontColor, Text);
            return NewText;
        }

        private string WrapInSmallFont(string Text)
        {
            string NewText = string.Empty;
            /* TODO ERROR */
            NewText = string.Format("<font size=\"{0}\" face=\"{1}\" color=\"{2}\">{3}</font>", Methods.RowFontSizeSmall, Methods.Font, Methods.RowFontColor, Text);
            return NewText;
        }

        public void AddCustomRow(string RowBackgroundColor, string RowFontSize, string Font, string RowFontColor, string RowContent)
        {
            if (string.IsNullOrEmpty(RowContent.Trim()))
            {
                RowContent = "&nbsp;";
            }

            if (string.IsNullOrWhiteSpace(RowBackgroundColor))
            {
                RowBackgroundColor = AdvantageFramework.Core.Email.Methods.RowBackgroundColor;
            }

            if (string.IsNullOrWhiteSpace(RowFontSize))
            {
                RowFontSize = AdvantageFramework.Core.Email.Methods.RowFontSize.ToString();
            }

            if (string.IsNullOrWhiteSpace(Font))
            {
                Font = AdvantageFramework.Core.Email.Methods.Font;
            }

            if (string.IsNullOrWhiteSpace(RowFontColor))
            {
                RowFontColor = AdvantageFramework.Core.Email.Methods.RowFontColor;
            }

            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                withBlock.Append("<td colspan=\"2\" align=\"left\" valign=\"top\" bgcolor=\"" + RowBackgroundColor + "\">");
                withBlock.Append("<font size=\"" + RowFontSize + "\" face=\"" + Font + "\" color=\"" + RowFontColor + "\">");
                withBlock.Append(RowContent);
                withBlock.Append("</font>");
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        public void AddBoldKeyValueRow(string Key, string Value, bool IncludeColonSeparator = true, int? LeftColumnWidth = default)
        {
            int Width = _LeftColumnWidth;
            if (LeftColumnWidth.HasValue)
            {
                Width = LeftColumnWidth.Value;
            }

            if (Value is null)
            {
                Value = "";
            }

            if (string.IsNullOrEmpty(Key.Trim()))
            {
                Key = Methods.NonBreakingSpace;
            }

            if (string.IsNullOrEmpty(Value.Trim()))
            {
                Value = Methods.NonBreakingSpace;
            }

            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\" width=\"" + Width.ToString() + "\">");
                withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                withBlock.Append("<span style=\"font-weight:bold\">");
                withBlock.Append(Key);
                withBlock.Append("</span>");
                if (Key != Methods.NonBreakingSpace && IncludeColonSeparator)
                {
                    withBlock.Append(":");
                }

                withBlock.Append("</font>");
                withBlock.Append("</td>");
                withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                withBlock.Append(Value);
                withBlock.Append("</font>");
                withBlock.Append("</td>");
                withBlock.Append("</tr>");
            }
        }

        public void CustomTableRowStart(string[] HeaderColumnsText, bool Bold = true)
        {
            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                withBlock.Append("<td colspan=\"2\" align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                withBlock.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\" bgcolor=\"#FFFFFF\">");
                withBlock.Append("<tr>");
                foreach (string Header in HeaderColumnsText)
                {
                    withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                    withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                    if (Bold == true)
                        withBlock.Append("<strong>");
                    withBlock.Append(Header);
                    if (Bold == true)
                        withBlock.Append("</strong>");
                    withBlock.Append("</font>");
                    withBlock.Append("</td>");
                }

                withBlock.Append("</tr>");
            }
        }

        public void CustomTableRow(string[] ColumnsText, bool Red)
        {
            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("<tr>");
                foreach (string Value in ColumnsText)
                {
                    withBlock.Append("<td align=\"left\" valign=\"top\" bgcolor=\"" + Methods.RowBackgroundColor + "\">");
                    if (Red == true)
                    {
                        withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"#F44336\">");
                    }
                    else
                    {
                        withBlock.Append("<font size=\"" + Methods.RowFontSize + "\" face=\"" + Methods.Font + "\" color=\"" + Methods.RowFontColor + "\">");
                    }

                    withBlock.Append(Value);
                    withBlock.Append("</font>");
                    withBlock.Append("</td>");
                }

                withBlock.Append("</tr>");
            }
        }

        public void CustomTableEnd()
        {
            _StringBuilderEmail.Append("</table>");
            _StringBuilderEmail.Append("</font>");
            _StringBuilderEmail.Append("</td>");
            _StringBuilderEmail.Append("</tr>");
        }

        public void AddAdvantageLogoImageRow()
        {
            AddCustomRow(string.Format(_AdvantageLogoSmallImageTag, _AdvantageLogoSmallBase64));
        }

        public void Finish()
        {
            {
                var withBlock = _StringBuilderEmail;
                withBlock.Append("</table>");
                if (_IncludeBodyTag == true)
                {
                    withBlock.Append("</body>");
                }
            }
        }

        private void AppendListenerAlertId(int AlertId)
        {
            {
                var withBlock = _StringBuilderEmail;
                // .Append("<div style=""display:none !important;""><font color=""" & HeaderBackgroundColor & """ bgcolor=""" & HeaderBackgroundColor & """>")
                withBlock.Append(AppendListenerAlertIDToBody(AlertId, false));
                // .Append("</font></div>")
            }
        }

        public static string AppendListenerAlertIDToBody(int AlertId, bool HtmlWhiteOnWhite)
        {
            if (HtmlWhiteOnWhite == false)
            {
                return string.Format("<div style=\"display:none !important;\"><font color=\"#FFFFFF\" bgcolor=\"#FFFFFF\">##LISTENER_ALERT_ID:{0}##</font></div>", AlertId);
            }
            else
            {
                return string.Format("##LISTENER_ALERT_ID:{0}##", AlertId);
            }
        }

        public string ToString(int AlertId = 0)
        {
            if (AlertId > 0)
            {
                AppendListenerAlertId(AlertId);
            }

            return _StringBuilderEmail.ToString();
        }

        public HtmlEmail()
        {
            _StringBuilderEmail = new StringBuilder();
        }

        public HtmlEmail(bool IncludeBodyTag, bool ShowHeaderBottomBorder = true) : this()
        {
            _IncludeBodyTag = IncludeBodyTag;
            _HeaderShowBottomBorder = ShowHeaderBottomBorder;

            // start the email body
            {
                var withBlock = _StringBuilderEmail;
                if (IncludeBodyTag == true)
                {
                    withBlock.AppendLine("<body bgcolor=\"" + Methods.BodyBackgroundColor + "\">");
                }

                withBlock.AppendLine("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"2\" bgcolor=\"#FFFFFF\">");
            }
        }

        public void AddLatestVersionsThumbnails(AdvantageFramework.Core.Database.DbContext dbContext, int alertID)
        {
            List<AdvantageFramework.Core.Database.Entities.LatestVersion> Thumbs = null;

            var parameters = new[] {
                    new Microsoft.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = alertID },
                };

            Thumbs =  dbContext.LatestVersions.FromSqlRaw("EXEC [dbo].[advsp_proofing_load_latest_versions] @ALERT_ID;", parameters).ToList();

            if (Thumbs != null && Thumbs.Count > 0)
            {
                string ImageString = string.Empty;
                string ImageTitle = string.Empty;
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<div style=\"width: 95%;\">");
                foreach (LatestVersion Thumb in Thumbs)
                {
                    ImageString = string.Empty;
                    ImageTitle = string.Empty;

                    if (Thumb.Thumbnail != null)
                    {
                        try
                        {
                            ImageString = System.Convert.ToBase64String(Thumb.Thumbnail, 0, Thumb.Thumbnail.Length);
                        }
                        catch (Exception)
                        {
                            ImageString = string.Empty;
                        }
                        if (string.IsNullOrWhiteSpace(ImageString) == false)
                        {
                            sb.Append("<div style=\"display: inline-block; width: 105px;\">");
                            sb.Append("<div style=\"\">");
                            sb.AppendFormat("<img alt=\"{0}\" src=\"data:image/png;base64,{1}\" />", ImageTitle, ImageString);
                            sb.Append("</div>");
                            // sb.Append("<div style="""">");
                            // sb.AppendFormat("{0}, {1}", Thumb.Filename, Thumb.Version);
                            // sb.Append("</div>");
                            sb.Append("</div>");
                        }
                        sb.Append("<br/>");
                    }
                }
                sb.Append("</div>");
                AddCustomRow(sb.ToString());
            }
        }
        public void AddDocumentThumbnailRow(AdvantageFramework.Core.Database.DbContext DbContext, int DocumentID, ref string Filename)
        {
            AdvantageFramework.Core.Database.Entities.Document Document = default;
            Document = AdvantageFramework.Core.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID);
            if (Document is object)
            {
                string ImageString = string.Empty;
                byte[] ImageBytes = null;
                try
                {
                    ImageBytes = Document.Thumbnail;
                    if (ImageBytes is object)
                    {
                        ImageString = Convert.ToBase64String(ImageBytes, 0, ImageBytes.Length);
                    }
                }
                catch (Exception)
                {
                    ImageString = string.Empty;
                }

                if (string.IsNullOrWhiteSpace(ImageString) == false)
                {
                    Filename = Document.Filename;
                    AddImageRow(Filename, ImageString);
                }
            }
        }
        public void AddImageRow(string ImageTitle, string ImageBase64)
        {
            if (string.IsNullOrWhiteSpace(ImageBase64) == false)
            {
                AddCustomRow(string.Format("<img alt=\"{0}\" src=\"data:image/png;base64,{1}\" />", ImageTitle, ImageBase64));
            }
        }
        public string AddProofingURLLink(string URL)
        {
            return string.Format("<a href=\"{0}\">{1}</a>", URL, "Click to go to proofing tool.");
        }

    }
}
