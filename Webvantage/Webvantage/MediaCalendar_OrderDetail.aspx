<%@ Page AutoEventWireup="false" CodeBehind="MediaCalendar_OrderDetail.aspx.vb" Inherits="Webvantage.MediaCalendar_OrderDetail"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div class="telerik-aqua-body" style="margin-top: 7px!important;">
            <asp:Panel ID="apnlMagazine" runat="server" Width="100%">
        
        <asp:DataList ID="dlMagTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'> 
                            </asp:Label>
                        </div>
                        <div id="divDocumentsMagazine" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsMagazine" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div> 
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Market:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMarket" runat="server" Text='<%# Eval("MARKET_CODE") + "|" + Eval("MARKET_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Publication:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Accepted:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAccepted" runat="server" Text='<%#Eval("ORDER_ACCEPTED")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Insert Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblInsertDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Number:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdNumber" runat="server" Text='<%#Eval("AD_NUMBER") + "|" + Eval("AD_NBR_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Headline:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblHeadline" runat="server" Text='<%#Eval("HEADLINE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Issue:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblIssue" runat="server" Text='<%#Eval("EDITION_ISSUE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterial" runat="server" Text='<%#Eval("MATERIAL")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdSize" runat="server" Text='<%# Eval("SIZE_CODE").ToString() + "|" + Eval("SIZE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Production Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProductionSize" runat="server" Text='<%#Eval("PRODUCTION_SIZE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLineTotal" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Billing Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BILLING_AMT", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="Javascript:window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                        </div>
                    </div>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="apnlNewspaper" runat="server" Width="100%">
        <asp:DataList ID="dlNewsTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'>
                            </asp:Label>
                        </div>
                        <div id="divDocumentsNewspaper" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsNewspaper" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div> 
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Market:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMarket" runat="server" Text='<%# Eval("MARKET_CODE") + "|" + Eval("MARKET_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Publication:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Accepted:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAccepted" runat="server" Text='<%#Eval("ORDER_ACCEPTED")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Insert Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblInsertDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Number:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdNumber" runat="server" Text='<%#Eval("AD_NUMBER") + "|" + Eval("AD_NBR_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">Headline:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblHeadline" runat="server" Text='<%#Eval("HEADLINE")%>'>
                            </asp:Label>
                       </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">Edition/Issue:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblIssue" runat="server" Text='<%#Eval("EDITION_ISSUE")%>'>
                            </asp:Label>
                       </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">Section:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("SECTION")%>'>
                            </asp:Label>
                       </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">Material:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterial" runat="server" Text='<%#Eval("MATERIAL")%>'>
                            </asp:Label>
                       </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdSize" runat="server" Text='<%# Eval("SIZE_CODE").ToString() + "|" + Eval("SIZE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Production Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProductionSize" runat="server" Text='<%#Eval("PRODUCTION_SIZE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Qty/Circulation:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblQtyCirculation" runat="server" Text='<%#Eval("PRINT_LINES")%>'
                            Visible="false">
                            </asp:Label>
                            <asp:Label ID="lblCostType" runat="server" Text='<%#Eval("COST_TYPE")%>' Visible="false">
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLineTotal" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Billing Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BILLING_AMT", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                       </div>
                    </div>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="apnlInternet" runat="server" Width="100%">
        <asp:DataList ID="dlInternetTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'>
                            </asp:Label>
                        </div>
                        <div id="divDocumentsInternet" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsInternet" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div> 
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Market:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMarket" runat="server" Text='<%# Eval("MARKET_CODE") + "|" + Eval("MARKET_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Vendor:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Accepted:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAccepted" runat="server" Text='<%#Eval("ORDER_ACCEPTED")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Start Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblInsertDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            End Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("END_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Number:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdNumber" runat="server" Text='<%#Eval("AD_NUMBER") + "|" + Eval("AD_NBR_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            URL:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblURL" runat="server" Text='<%#Eval("URL")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Headline:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblHeadline" runat="server" Text='<%#Eval("HEADLINE")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            File Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblIssue" runat="server" Text='<%#Eval("COPY_AREA")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Target Audience:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterial" runat="server" Text='<%#Eval("TARGET_AUDIENCE")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Creative Size:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCreativeSize" runat="server" Text='<%#Eval("SIZE") + "|" + Eval("CREATIVE_SIZE")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Placement 1:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblPlacement1" runat="server" Text='<%#Eval("PLACEMENT_1")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Placement 2:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblPlacement2" runat="server" Text='<%#Eval("PLACEMENT_2")%>'>
                            </asp:Label>
                        </div>
                    </div>
	                <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("INTERNET_TYPE") + "|" + Eval("OD_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Guaranteed Impressions:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblGuaranteedImpressions" runat="server" Text='<%#Eval("IMPRESSIONS")%>'
                                Visible="false">
                            </asp:Label>
                            <asp:Label ID="lblCostType" runat="server" Text='<%#Eval("COST_TYPE")%>' Visible="false">
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLineTotal" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Billing Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BILLING_AMT", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                       </div>
                    </div>
                </fieldset>
           </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="apnlOutdoor" runat="server" Width="100%">
        <asp:DataList ID="dlOutTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'>
                            </asp:Label>
                        </div>
                        <div id="divDocumentsOutdoor" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsOutdoor" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div>  
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Market:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMarket" runat="server" Text='<%# Eval("MARKET_CODE") + "|" + Eval("MARKET_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Vendor:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Accepted:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAccepted" runat="server" Text='<%#Eval("ORDER_ACCEPTED")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                     <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Post Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblInsertDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            End Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("END_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Ad Number:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblAdNumber" runat="server" Text='<%#Eval("AD_NUMBER") + "|" + Eval("AD_NBR_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Location:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("LOCATION")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Headline:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblHeadline" runat="server" Text='<%#Eval("HEADLINE")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Copy Area:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblCopyArea" runat="server" Text='<%#Eval("COPY_AREA")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Type:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("OUTDOOR_TYPE") + "|" + Eval("OD_DESC")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Size:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblSize" runat="server" Text='<%# Eval("SIZE") + "|" + Eval("OD_SIZE")%>'>
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLineTotal" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Billing Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BILLING_AMT", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                       </div>
                    </div>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="apnlRadio" runat="server" Width="100%">
        <asp:DataList ID="dlRadioTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'>
                            </asp:Label>
                        </div>
                        <div id="divDocumentsRadio" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsRadio" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div>  
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Flight Range:
                        </div>
                        <div class="code-description-description">
                            <asp:Label   ID="lblFlight" runat="server" Text='<%# Eval("FLIGHT_FROM") + " to " + Eval("FLIGHT_TO")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Station:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Start Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
						<div class="code-description-label">
                            Programming:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblProgram" runat="server" Text='<%#Eval("PROGRAMMING")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Start Time:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("START_TIME")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            End Time:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("END_TIME")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Length:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblLength" runat="server" Text='<%#Eval("LENGTH")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Remarks:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("REMARKS")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Material Notes:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblMatNotes" runat="server" Text='<%# Eval("MATL_NOTES")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Tag:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblTag" runat="server" Text='<%# Eval("TAG")%>'>
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Total Spots:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblTotalSpots" runat="server" Text='<%#Eval("TOTAL_SPOTS")%>'>
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Billing Total:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="Javascript:window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2&RevNo=<%# Eval("REV_NBR")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                        </div>
                    </div>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <asp:Panel ID="apnlTV" runat="server" Width="100%">
        <asp:DataList ID="dlTVTask" runat="server" Width="100%">
            <ItemTemplate>
                <fieldset>
                    <legend>Client Info
                    </legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClient" runat="server" Text='<%# Eval("CL_CODE") + "|" + Eval("CL_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Division:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblDivision" runat="server" Text='<%# Eval("DIV_CODE") + "|" + Eval("DIV_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Product:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("PRD_CODE") + "|" + Eval("PRD_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Info</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">     
                            Order:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("ORDER_NBR").ToString() + "|" + Eval("ORDER_DESC")%>'>
                            </asp:Label>
                        </div>
                        <div id="divDocumentsTV" runat="server" style="float:right; align-content:center; margin-right: 10px" class='icon-background background-color-sidebar standard-light-green'>
                            <asp:ImageButton ID="ImageButtonDocumentsTV" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/documents_empty.png" ToolTip="Order Documents" OnClick="ImageButtonDocs_Click" />
                        </div>                    
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Order Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("ORDER_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Campaign:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCampaign" runat="server" Text='<%# Eval("CMP_CODE") + "|" + Eval("CMP_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("TYPE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Media Type:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMediaType" runat="server" Text='<%#Eval("MEDIA_TYPE") + "|" + Eval("SC_DESCRIPTION")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Flight Range:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblFlight" runat="server" Text='<%# Eval("FLIGHT_FROM") + " to " + Eval("FLIGHT_TO")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendor.aspx?Type=<%#Eval("TYPE")%>&VnCode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=435,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Station:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendor" runat="server" Text='<%# Eval("VN_CODE") + "|" + Eval("VN_NAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=1&Vrcode=<%# Eval("VR_CODE")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 1:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep1" runat="server" Text='<%# Eval("VR_CODE") + "|" + Eval("VR_FNAME") + " " + Eval("VR_LNAME")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            <a href="#" onclick="window.open('mediavendorrep.aspx?RepNo=2&Vrcode=<%# Eval("VR_CODE2")%>&Vncode=<%# Eval("VN_CODE")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">Rep 2:
                            </a>
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblVendorRep2" runat="server" Text='<%# Eval("VR_CODE2").ToString() + "|" + Eval("VR_FNAME2").ToString() + " " + Eval("VR_LNAME2")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Link ID:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLinkID" runat="server" Text='<%# Eval("LINK_ID")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Buyer:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblBuyer" runat="server" Text='<%#Eval("BUYER")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Client PO:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblClientPO" runat="server" Text='<%#Eval("CLIENT_PO")%>'> 
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments
                            </a>
                        </div>
                    </div>
                </fieldset>
                <fieldset>
                    <legend>Order Details</legend>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Line:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblLine" runat="server" Text='<%# Eval("LINE_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Revision:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblRevision" runat="server" Text='<%# Eval("REV_NBR")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Start Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("START_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCloseDate" runat="server" Text='<%# Eval("CLOSE_DATE")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Close Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtCloseDate" runat="server" Text='<%#Eval("EXT_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblMaterialDate" runat="server" Text='<%#Eval("MATL_CLOSE_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Extended Material Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblExtMaterialDate" runat="server" Text='<%# Eval("EXT_MATL_DATE") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Completed Date:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblCompletedDate" runat="server" Text='<%# Eval("MAT_COMP") %>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                    </div>
                    <div class="code-description-container">
						<div class="code-description-label">
                            Programming:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblProgram" runat="server" Text='<%#Eval("PROGRAMMING")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Start Time:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("START_TIME")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            End Time:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("END_TIME")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Length:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblLength" runat="server" Text='<%#Eval("LENGTH")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Remarks:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("REMARKS")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Material Notes:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblMatNotes" runat="server" Text='<%# Eval("MATL_NOTES")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Tag:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblTag" runat="server" Text='<%# Eval("TAG")%>'>
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Job:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJob" runat="server" Text='<%# Eval("JOB_NUMBER").ToString() + "|" + Eval("JOB_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                            Component:
                        </div>
                        <div class="code-description-description">
                            <asp:Label ID="lblJobComp" runat="server" Text='<%#Eval("JOB_COMPONENT_NBR").ToString() + "|" + Eval("JOB_COMP_DESC")%>'>
                            </asp:Label>
                        </div>
                    </div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Total Spots:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblLineTotal" runat="server" Text='<%#Eval("TOTAL_SPOTS")%>'>
                            </asp:Label>
						</div>
					</div>
					<div class="code-description-container">
						<div class="code-description-label">
                            Billing Total:
						</div>
						<div class="code-description-description">
                            <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("LINE_TOTAL", "{0:C}")%>'>
                            </asp:Label>
						</div>
					</div>
                    <div class="code-description-container">
                        <div class="code-description-label">
                        </div>
                        <div class="code-description-description">
                            <a href="#" onclick="window.open('mediacomments.aspx?Type=<%#Eval("TYPE")%>&OrdNo=<%# Eval("ORDER_NBR")%>&LineNo=<%# Eval("LINE_NBR")%>&Com=2&RevNo=<%# Eval("REV_NBR")%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=650,height=600,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;">View Comments</a>
                       </div>
                    </div>
                </fieldset>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>
    <div style="text-align: center; margin: 20px 0px 10px 0px;">
        <asp:Button ID="butMarkCompleted" runat="server" Width="160" Text="Mark Completed" />
        <asp:Button ID="butMarkNotCompleted" runat="server" Width="160" Text="Mark Not Completed" />
        &nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Close" />
    </div>
    </div>
</asp:Content>
