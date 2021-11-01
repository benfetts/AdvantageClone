<%@ Page AutoEventWireup="false" CodeBehind="poplookup_contact.aspx.vb" Inherits="Webvantage.poplookup_contact"
    MasterPageFile="~/ChildPage.Master" Title="" Language="vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script> 
    //+++++++++++

    function filterlist(selectobj) {

      // VARIABLES

      // HTML SELECT object
      this.selectobj = selectobj;

      // Flags for regexp matching.
      // "i" = ignore case; "" = do not ignore case
      this.flags = "i";

      // Make a copy of the options array
      this.optionscopy = new Array();
      for (var i=0; i < selectobj.options.length; i++) {
        this.optionscopy[i] = new Option();
        this.optionscopy[i].text = selectobj.options[i].text;
        this.optionscopy[i].value = selectobj.options[i].value;
      }

      //==================================================
      // METHODS
      //==================================================

      //--------------------------------------------------
      this.reset = function() {
      // This method resets the select list to the original state.
      // It also unselects all of the options.

        this.set("");
      }

      //--------------------------------------------------
      this.set = function(pattern) {
      // This method removes all of the options from the select list,
      // then adds only the options that match the pattern regexp.
      // It also unselects all of the options.
      // In case of a regexp error, returns false

        var loop=0, index=0, regexp, e;

        // Clear the select list so nothing is displayed
        this.selectobj.options.length = 0;

        // Set up the regular expression
        try {
          regexp = new RegExp(pattern, this.flags);
        } catch(e) {
          return;
        }

        // Loop through the entire select list
        for (loop=0; loop < this.optionscopy.length; loop++) {

          // Check if we have a match
          if (regexp.test(this.optionscopy[loop].text)) {

            // We have a match, so add this option to the select list
            this.selectobj.options.length = index + 1;
            this.selectobj.options[index].text = this.optionscopy[loop].text;
            this.selectobj.options[index].value = this.optionscopy[loop].value;
            this.selectobj.options[index].selected = false;

            // Increment the index
            index++;
          }
        }
      }

      //--------------------------------------------------
      this.set_ignore_case = function(value) {
      // This method sets the regexp flags.
      // If value is true, sets the flags to "i".
      // If value is false, sets the flags to "".

        if (value) {
          this.flags = "i";
        } else {
          this.flags = "";
        }
      }

    }

    //++++++++
    //--> 
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
        Search List
        <table border="0" cellpadding="2">
            <tr>
                <td align="center" style="width: 305px">
                    <asp:TextBox ID="txtLookup" runat="server"  EnableViewState="True" SkinID="TextBoxStandard"
                        Width="300px"></asp:TextBox><br />
                </td>
            </tr>
            <tr>
                <td style="width: 305px">
                    <telerik:RadListBox ID="lbLookup" runat="server" AutoPostBack="False"  SkinID="TextBoxStandard"
                        EnableViewState="True" Height="200px" Width="300px"></telerik:RadListBox>
                </td>
            </tr>
            <tr>
                <td style="width: 305px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: center; width: 305px;">

                    <script type="text/javascript">
			            <!--
			            var myfilter = new filterlist(document.frmLookUp.lbLookup);
			            //-->
                    </script>

                    <asp:Button ID="butSelect" runat="server"  Text="Select" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input
                         onclick="JavaScript:window.close();" type="button" value="Cancel" />
                </td>
            </tr>
        </table>
        <input id="txtClient" runat="server" name="txtClient" type="hidden" />
        <input id="txtDivision" runat="server" name="txtDivision" type="hidden" />
        <input id="txtProduct" runat="server" name="txtProduct" type="hidden" />
        <input id="txtJob" runat="server" name="txtJob" type="hidden" />
        <input id="txtJobComp" runat="server" name="txtJobComp" type="hidden" />
        <input id="txtType" runat="server" name="txtType" type="hidden" /><br />
</asp:Content>
