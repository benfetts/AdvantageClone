<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="Disclaimer.aspx.vb" Inherits="Webvantage.Disclaimer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div id="DivQOTD" runat="server">
        The Quote of the Day object uses a publicly available
        <asp:HyperLink ID="HyperLink7" runat="server" Text="RSS" NavigateUrl="http://support.google.com/feedburner/bin/answer.py?hl=en&answer=79408" Target="_blank"></asp:HyperLink>
        feed from
        <asp:HyperLink ID="HyperLink2" runat="server" Text="TheQuotationsPage.com" NavigateUrl="http://www.quotationspage.com/" Target="_blank"></asp:HyperLink>. The feed is provided by
        <asp:HyperLink ID="HyperLink1" runat="server" Text="FeedBurner" NavigateUrl="http://www.feedburner.com" Target="_blank"></asp:HyperLink>, a Google company.<br />
        <br />
        <div style="font-style: italic">
            The Advantage Software Company is not in any way affiliated with TheQuotationsPage.com,
            FeedBurner, Google, or the quotes being provided by the aforementioned companies.  
            The content does not reflect the views, opinions, culture, or beliefs of The Advantage
            Software Company.
        </div>
        <br />
        If you find any content objectionable, please refrain from using this object.
        <br />
        <br />
    </div>
    <div id="DivRSS" runat="server">
        The News Reader object uses publicly available
                <asp:HyperLink ID="HyperLink3" runat="server" Text="RSS" NavigateUrl="http://support.google.com/feedburner/bin/answer.py?hl=en&answer=79408"
                    Target="_blank"></asp:HyperLink>
        feeds from the following sources:<br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink4" runat="server" Text="Feedzilla" NavigateUrl="http://www.feedzilla.com/gallery"
            Target="_blank"></asp:HyperLink><br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink5" runat="server" Text="AdsOfTheWorld.com"
            NavigateUrl="http://adsoftheworld.com/" Target="_blank"></asp:HyperLink><br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink6" runat="server" Text="Adobe.com" NavigateUrl="http://www.adobe.com/"
            Target="_blank"></asp:HyperLink><br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink8" runat="server" Text="MacWorld.com" NavigateUrl="http://www.macworld.com/"
            Target="_blank"></asp:HyperLink><br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink9" runat="server" Text="NyTimes.com" NavigateUrl="http://www.nytimes.com/"
            Target="_blank"></asp:HyperLink><br />
        &nbsp;&nbsp;<asp:HyperLink ID="HyperLink10" runat="server" Text="Reuters.com" NavigateUrl="http://www.reuters.com/"
            Target="_blank"></asp:HyperLink><br />
        <br />
        <div style="font-style: italic">
            The Advantage Software Company is not in any way affiliated with any of the sources
                providing the feeds nor the content that appears in feeds. The content does not
                reflect the views, opinions, culture, or beliefs of The Advantage Software Company.
        </div>
        <br />
        If you find any content objectionable, please refrain from subscribing to that source.
        <br />
        <br />
    </div>
    <div id="DivWOTD" runat="server">
        The Word of the Day object uses a publicly available
        <asp:HyperLink ID="HyperLink11" runat="server" Text="RSS" NavigateUrl="http://support.google.com/feedburner/bin/answer.py?hl=en&answer=79408"
            Target="_blank"></asp:HyperLink>
        feed from
        <asp:HyperLink ID="HyperLink12" runat="server" Text="TheFreeDictionary.com" NavigateUrl="http://www.thefreedictionary.com"
            Target="_blank"></asp:HyperLink>.<br />
        <br />
        <div style="font-style: italic">
            The Advantage Software Company is not in any way affiliated with TheFreeDictionary.com
        or the definitions being provided by TheFreeDictionary.com.  The content does not reflect the views, opinions, culture, or beliefs of The Advantage Software Company.
        </div>
        <br />
        If you find any content objectionable, please refrain from using this object.
        <br />
        <br />
    </div>
    <div class="bottom-buttons">
        <asp:Button ID="ButtonClose" runat="server" Text="Got it" OnClientClick="CloseThisWindow();; return false;" />
    </div>
</asp:Content>
