@ModelType AdvantageFramework.ViewModels.Maintenance.General.EmailSettingsViewModel
@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
 
End Section

<div style="margin-top: 10px;">

    @(Html.Kendo.ToolBar().Name("Toolbar").Items(Sub(ToolBar)

                                                     ToolBar.Add().Type(CommandType.Button).Text("Save").Click("Submit").HtmlAttributes(New With {.form = "SaveEmailSettings", .type = "submit"})

                                                 End Sub))

</div>

<div style="padding: 20px;">

    @Using Html.BeginForm("Save", "EmailSettings", FormMethod.Post, New With {.ID = "SaveEmailSettings", .class = "form-horizontal", .role = "form"})

        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;align-content:center">
                Authentication Method: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="0">

                @( Html.EJ().DropDownList("SMTPAuthenticationMethodType").Width("100%").Height("23px").Datasource(Model.SMTPAuthenticationMethodTypes).
                                                                                                            DropDownListFields(Function(Field)
                                                                                                                                   Return Field.Value("Value").Text("Display")
                                                                                                                               End Function).Value(CStr(Model.SMTPAuthenticationMethodType)).
                                                                                                                ClientSideEvents(Sub([Event])
                                                                                                                                     [Event].Change("SMTPAuthenticationMethodTypes_Changed")
                                                                                                                                 End Sub))

            </div>
        </div>
        '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
        '=======================
        @<div style="display:flex;align-items:center;width:75%;">

            <div style="display:inline-block;width:15%;">
                Port Number: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:15%;" tabindex="1">

                @Html.EJ().NumericTextBoxFor(Function(Model) Model.SMTPPortNumber).DecimalPlaces(0).ShowSpinButton(False).Height("23px")

            </div>
            <div style="display:inline-block;width:45%;" tabindex="2">

                @Html.EJ().RadioButton("SMTPSecurityType_UseSSL").Name("SMTPSecurityType").Size(RadioButtonSize.Small).Text("Use SSL").Checked(If(Model.SMTPSecurityType = 1, True, False))
                &nbsp;
                &nbsp;
                &nbsp;
                @Html.EJ().RadioButton("SMTPSecurityType_UseTLS").Name("SMTPSecurityType").Size(RadioButtonSize.Small).Text("Use TLS").Checked(If(Model.SMTPSecurityType = 2, True, False))
                &nbsp;
                &nbsp;
                &nbsp;
                @Html.EJ().RadioButton("SMTPSecurityType_NoSecureProtocol").Name("SMTPSecurityType").Size(RadioButtonSize.Small).Text("No Secure Protocol").Checked(If(Model.SMTPSecurityType = 0, True, False))

            </div>

        </div>
        '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
        '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                Outgoing Server Address: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="3">

                @Html.EJ().MaskEditTextBoxFor(Function(Model) Model.SMTPServer).InputMode(Syncfusion.JavaScript.InputMode.Text).Height("23px").Width("100%")

            </div>
        </div>
                    '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
                    '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                Default Sender Address: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="4">

                @Html.EJ().MaskEditTextBoxFor(Function(Model) Model.SMTPUserName).InputMode(Syncfusion.JavaScript.InputMode.Text).Height("23px").Width("100%")

            </div>
        </div>
                    '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
                    '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                Default Sender User Name: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="5">

                @Html.EJ().MaskEditTextBoxFor(Function(Model) Model.EmailUserName).InputMode(Syncfusion.JavaScript.InputMode.Text).Height("23px").Width("100%")

            </div>
        </div>
        '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
        '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                Default Sender Password: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="6">

                <input id="HasAgencyOAuth2Key" type="hidden" value="@Model.HasAgencyOAuth2Key.ToString">

                <div id="OAuth2Authorize" @CStr(If(Model.SMTPAuthenticationMethodType = 6 AndAlso Model.HasAgencyOAuth2Key = False, "", "hidden='hidden'"))>

                    Account is not authorized. &nbsp;&nbsp; <button id="AuthOAuth2" type="button">Authorize</button>

                </div>

                <div id="OAuth2Deauthorize" @CStr(If(Model.SMTPAuthenticationMethodType = 6 AndAlso Model.HasAgencyOAuth2Key = True, "", "hidden='hidden'"))>
                    Account is authorized. &nbsp;&nbsp;
                    @Html.ActionLink("Deauthorize", "DisableOAuth2")

                </div>

                <div id="Password" @CStr(If(Model.SMTPAuthenticationMethodType <> 6, "", "hidden='hidden'"))>

                    @Html.EJ().MaskEditTextBoxFor(Function(Model) Model.EmailPassword).InputMode(Syncfusion.JavaScript.InputMode.Password).Height("23px").Width("100%").HtmlAttributes(New Dictionary(Of String, Object) From {{"autocomplete", "off"}})

                </div>

            </div>
        </div>
                    '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
                    '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                Default Reply To Address: &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block;width:60%" tabindex="7">

                @Html.EJ().MaskEditTextBoxFor(Function(Model) Model.ReplyToEmail).InputMode(Syncfusion.JavaScript.InputMode.Text).Height("23px").Width("100%")

            </div>
        </div>
                    '=======================
        @<div style="height:5px">
            &nbsp;&nbsp;&nbsp;
        </div>
                    '=======================
        @<div style="display:flex;align-items:center;width:75%;">
            <div style="display:inline-block;width:15%;">
                &nbsp;&nbsp;&nbsp;
            </div>
            <div style="display:inline-block; width:60%;" tabindex="8">

                @Html.EJ().CheckBoxFor(Function(Model) Model.UseEmployeeLogin).Text("Use Employee SMTP Login @ 'From' Address")
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                &nbsp;
                @Html.EJ().CheckBoxFor(Function(Model) Model.UseSMTPToSendPDF).Text("Enable PDF E-Mail Attachments")

            </div>
        </div>


                    End Using

</div>
@Code

    Dim SettingsDialog = Html.EJ().Dialog("settingsDialog")
    SettingsDialog.ShowOnInit(False)
    SettingsDialog.ContentType("iframe")
    SettingsDialog.ShowFooter(True)
    SettingsDialog.Render()

End Code

<script>
    function Submit() {
        document.getElementById("SaveEmailSettings").submit();
    }

    function RefreshEmailSettings() {

        window.location.reload(true);

    }
    function closeSettingsDialog() {
        $("#settingsDialog").ejDialog("close");
    }
    $(document).ready(function () {


        $('#AuthOAuth2').click(function () {

            var SMTPAuthenticationMethodType = "";

            SMTPAuthenticationMethodType = $("#SMTPAuthenticationMethodType")[0].value + "";

            console.log($("#SMTPAuthenticationMethodType"));
            console.log(SMTPAuthenticationMethodType);

            $.ajax({
                type: 'POST',
                url: 'EmailSettings/SaveSMTPAuthenticationMethodType',
                data: { SMTPAuthenticationMethodType: SMTPAuthenticationMethodType },
                error: function () {
                    ////console.log('CopyTo', 'failed');
                    //kendo.ui.progress($('body'), false);
                },
                success: function (response) {
                    //kendo.ui.progress($('body'), false);
                    //dialog.data("kendoDialog").open();
                    //showKendoAlert("Project Schedules have been created/updated.");
                    //CloseThisWindow();
                }
            });

            //OpenRadWindow('', 'Google_Authentication.aspx?AgencyOnly=true', 300, 500, true);
            $("#settingsDialog").ejDialog("destroy");
            $("#settingsDialog").ejDialog({
                contentUrl: window.appBase +"Google_Authentication.aspx?AgencyOnly=true",
                title:   "Google Authorization",
                closeOnEscape: true,
                showOnInit: false,
                contentType: "iframe",
                height: 300,
                width: 500,
                showFooter: false,
                enableModal: false,
                backgroundScroll: false,
                enableResize: true,
                close: function (e) {
                    RefreshEmailSettings();
                }
            });
            $("#settingsDialog").ejDialog("open");

        });

    });

    function SMTPAuthenticationMethodTypes_Changed() {

        var SMTPAuthenticationMethodType = "";
        var HasAgencyOAuth2Key = false;

        SMTPAuthenticationMethodType = $("#SMTPAuthenticationMethodType")[0].value + "";

        if (SMTPAuthenticationMethodType == "6") {

            //console.log($("#HasAgencyOAuth2Key"));

            HasAgencyOAuth2Key = $("#HasAgencyOAuth2Key")[0].value;

            //console.log('HasAgencyOAuth2Key' + HasAgencyOAuth2Key);

            if (HasAgencyOAuth2Key === true) {

                $("#OAuth2Deauthorize").show();
                $("#OAuth2Authorize").hide();
                $("#Password").hide();

            } else {

                $("#OAuth2Deauthorize").hide();
                $("#OAuth2Authorize").show();
                $("#Password").hide();

            }

        } else {

            $("#OAuth2Deauthorize").hide();
            $("#OAuth2Authorize").hide();
            $("#Password").show();

        }

    }
</script>
