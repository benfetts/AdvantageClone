﻿<%@ Page Title="About" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="About.aspx.vb" Inherits="Webvantage.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
 <style>
    html, Body, th, td {
    font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
    font-size: 16px !important;
    color: #767676 !important;
    }
    .field-set{
        background: #ffffff !important;
        background-color: #ffffff !important;
        border-radius: 2px !important;
    }
</style>
   <div style="width:100%; vertical-align: top;">
        <h3 style="margin-top: 0;">
            <asp:Label ID="LabelVersion" runat="server"></asp:Label>
        </h3>
        <div style="display: inline-block; width: 60%; margin-right: 2px; vertical-align: top;">
            <fieldset style="background: #ffffff !important;">
                <legend>Application</legend>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" width="49%">
                            <asp:Label ID="LabelApplicationTitle" runat="server" Visible="False"></asp:Label>
                            Agency Name:
                        </td>
                        <td align="center" width="2%">
                            &nbsp;
                        </td>
                        <td align="left" width="49%">
                            <asp:Label ID="LabelAgencyName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Licensed Power Users:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLKPowerUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Power Users in Use:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelPowerUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Licensed Webvantage Only Users:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLKTimeEntryUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Webvantage Only Users in Use:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelTimeEntryUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Licensed Client Portal Users:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLKClientPortalUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Client Portal Users in Use:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelClientPortalUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Licensed Media Tools Users:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLKMediaToolsUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Licensed API Users:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLKAPIUsers" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Proofing Tool Enabled:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelProofingToolEnabled" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Webvantage Software Version:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelSoftwareVersion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Webvantage Database Version:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelDatabaseVersion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Advantage Database Version:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelAdvantageDatabaseVersion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Last Advantage DB Update:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLastADvantageUpdate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="TrDatabaseServer">
                        <td align="right">
                            Current Database Server:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelDBServer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Current Database Name:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelDBName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            SQL Server App Name:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelSQLAppName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Locale:
                        </td>
                        <td align="center">
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Label ID="LabelLocale" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div style="display: inline-block; width: 39%; vertical-align: top;">
            <fieldset style="background: #ffffff !important;">
                <legend>Browser</legend>
                <asp:Label ID="LabelBrowserInfo" runat="server"></asp:Label>
            </fieldset>
        </div>
        <fieldset runat="server" id="FieldsetThirdParty" style="background: #ffffff !important;">
            <legend>Third Party Licensing</legend>
            <table style="width: 100%;">
                <tr>
                    <td style="width: 280px;">
                        <div>
                            <div>
                                Webvantage uses the following third party tools licensed under the MIT Open Source License
                            </div>
                            <ul>
                                <li><a href="#" onclick="showLicense('AngularUI')" title="Click to view license">AngularUI</a></li>
                                <li><a href="#" onclick="showLicense('Aurelia')" title="Click to view license">Aurelia</a></li>
                                <li><a href="#" onclick="showLicense('Bootstrap')" title="Click to view license">Bootstrap</a></li>
                                <li><a href="#" onclick="showLicense('JQuery')" title="Click to view license">JQuery</a></li>
                                <li><a href="#" onclick="showLicense('Jquery_Validate')" title="Click to view license">Jquery.Validate</a></li>
                                <li><a href="#" onclick="showLicense('JsCookie')" title="Click to view license">JsCookie</a></li>
                                <li><a href="#" onclick="showLicense('JsRender')" title="Click to view license">JsRender</a></li>
                                <li><a href="#" onclick="showLicense('Pako')" title="Click to view license">Pako</a></li>
                                <li><a href="#" onclick="showLicense('DarkReader')" title="Click to view license">DarkReader</a></li>
                                <li><a href="#" onclick="showLicense('Json_NET')" title="Click to view license">Json.NET (Newtonsoft.Json)</a></li>
                                <li><a href="#" onclick="showLicense('HandSanitizer')" title="Click to view license">HandSanitizer</a></li>
                                <li><a href="#" onclick="showLicense('MyGeneration')" title="Click to view license">MyGeneration</a></li>
                                <li><a href="#" onclick="showLicense('HtmlAgilityPack')" title="Click to view license">HtmlAgilityPack</a></li>
                                <li><a href="#" onclick="showLicense('CsQuery')" title="Click to view license">CsQuery</a></li>
                                <li><a href="#" onclick="showLicense('System_Net_FtpClient')" title="Click to view license">System.Net.FtpClient (FluentFTP)</a></li>
                            </ul>
                        </div>
                        <div>
                            <div>
                                Webvantage uses the following third party tools licensed under the Apache Open Source License
                            </div>
                            <ul>
                                <li><a href="#" onclick="showLicense('SignalR')" title="Click to view license">SignalR</a></li>
                                <li><a href="#" onclick="showLicense('Google_Apis')" title="Click to view license">Google.Apis</a></li>
                                <li><a href="#" onclick="showLicense('Log4net')" title="Click to view license">Log4net</a></li>
                                <li><a href="#" onclick="showLicense('EntityFramework')" title="Click to view license">EntityFramework</a></li>
                                <li><a href="#" onclick="showLicense('Owin')" title="Click to view license">Owin</a></li>
                                <li><a href="#" onclick="showLicense('RestSharp')" title="Click to view license">RestSharp</a></li>
                            </ul>
                        </div>
                        <div>
                            <div>
                                Webvantage uses the following third party tools licensed under the MIT Open Source License and GPL Open Source License
                            </div>
                            <ul>
                               <li><a href="#" onclick="showLicense('JQuery_HotKeys')" title="Click to view license">JQuery.HotKeys</a></li>
                                <li><a href="#" onclick="showLicense('JSzip')" title="Click to view license">JSzip</a></li>
                            </ul>
                        </div>
                        <div>
                            <div>
                                Webvantage uses the following third party tools licensed under the Microsoft PL (Public License)
                            </div>
                            <ul>
                               <li><a href="#" onclick="showLicense('DotNetZip')" title="Click to view license">DotNetZip</a></li>
                                <li><a href="#" onclick="showLicense('DotNetOpenAuth_AspNet')" title="Click to view license">DotNetOpenAuth.AspNet</a></li>
                                <li><a href="#" onclick="showLicense('Ionic_Zip_DotNetZip')" title="Click to view license">Ionic.Zip/DotNetZip</a></li>
                            </ul>
                        </div>
                        <div>
                            <div>
                                Webvantage uses the following third party tools licensed under the BSD Open Source License
                            </div>
                            <ul>
                                <li><a href="#" onclick="showLicense('Antlr')" title="Click to view license">Antlr</a></li>
                                <li><a href="#" onclick="showLicense('MyGeneration')" title="Click to view license">MyGeneration</a></li>
                            </ul>
                        </div>
                    </td>
                    <td style="vertical-align: top;">
                        <div id="licenseDiv" style="width: 575px; height: 750px; overflow-x:hidden; overflow-y:auto; padding: 0px 18px 0px 18px; vertical-align: top;">
                        </div>
                        <div id="AngularUILicense" style="display: none;">
                            The MIT License
                            <br />
                            Copyright (c) 2010-2020 Google, Inc. http://angularjs.org
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="AureliaLicense" style="display: none;">
                            The MIT License
                            <br />
                            Copyright (c) https://aurelia.io/docs/overview/what-is-aurelia#what-is-aurelia
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="BootstrapLicense" style="display: none;">
                            The MIT License (MIT)
                            <br />
                            Copyright (c) 2011-2020 Twitter, Inc.
                            Copyright (c) 2011-2020 The Bootstrap Authors
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="JQueryLicense" style="display: none;">
                            The MIT License (MIT)
                            <br />
                            Copyright (c) -2020 JS Foundation
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="JqueryValidateLicense" style="display: none;">
                            The MIT License (MIT)
                            <br />
                            Copyright (c) -2020 Jörn Zaefferer
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                    </div>
                        <div id="JsCookieLicense" style="display: none;">
                            MIT License
                            <br />
                            Copyright (c) 2018 Copyright 2018 Klaus Hartl, Fagner Brack, GitHub Contributors
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all
                            copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                            SOFTWARE.
                        </div>
                        <div id="JsRenderLicense" style="display: none;">
                            MIT License
                            <br />
                            ﻿Copyright (c) 2019 Boris Moore https://github.com/BorisMoore/jsrender
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining
                            a copy of this software and associated documentation files (the
                            "Software"), to deal in the Software without restriction, including
                            without limitation the rights to use, copy, modify, merge, publish,
                            distribute, sublicense, and/or sell copies of the Software, and to
                            permit persons to whom the Software is furnished to do so, subject to
                            the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be
                            included in all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
                            EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
                            MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
                            NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
                            LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
                            OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
                            WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
                            © 2020 GitHub, Inc.
                        </div>
                        <div id="PakoLicense" style="display: none;">
                            The MIT License
                            <br />
                            Copyright (C) 2014-2017 by Vitaly Puzrin and Andrei Tuputcyn
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="DarkReaderLicense" style="display: none;">
                            The MIT License
                            <br />
                            Copyright (c) Microsoft Corporation https://darkreader.org/
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id="Json_NETLicense" style="display: none;">
                            The MIT License (MIT)
                            <br />
                            Copyright (c) 2007 James Newton-King
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                        </div>
                        <div id="HandSanitizerLicense" style="display: none;">
                            The MIT License (MIT)
                            <br />
                            Copyright (c) 2013-2016 Michael Ganss and HtmlSanitizer contributors
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                        </div>
                        <div id="HtmlAgilityPackLicense" style="display: none;">
                            The MIT License (MIT)
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all
                            copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
                            SOFTWARE.
                        </div>
                        <div id="CsQueryLicense" style="display: none;">
                            Code use license for CsQuery 
                            <br />
                            Copyright (c) 2012 James Treworgy
                            <br />
                            LICENSE (MIT License)
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy 
                            of this software and associated documentation files (the "Software"), to deal 
                            in the Software without restriction, including without limitation the rights to 
                            use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
                            of the Software, and to permit persons to whom the Software is furnished to do 
                            so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all 
                            copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
                            INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
                            PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
                            HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
                            OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
                            SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
                            © 2020 GitHub, Inc.
                        </div>
                        <div id="System_Net_FtpClientLicense" style="display: none;">
                            robinrodricks/FluentFTP is licensed under the MIT License
                            <br />
                            A short and simple permissive license with conditions only requiring preservation of copyright and license notices. Licensed works, modifications, and larger works may be distributed under different terms and without source code.
                            <br />
                            Permissions:
                            <br />
                                - Commercial use
                            <br />
                                - Modification
                            <br />
                                - Distribution
                            <br />
                                - Private use
                            <br />
                            Limitations
                            <br />
                                - Liability
                            <br />
                                - Warranty                        
                            <br />
                            Copyright (c) 2015 Robin Rodricks and FluentFTP Contributors
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.                        
                        </div>


                        <div id="SignalRLicense" style="display: none;">
                            Copyright (c) .NET Foundation. All rights reserved.
                            <br />
                            Licensed under the Apache License, Version 2.0 (the "License"); you may not use
                            these files except in compliance with the License. You may obtain a copy of the
                            License at
                            <br />
                            http://www.apache.org/licenses/LICENSE-2.0
                            <br />
                            Unless required by applicable law or agreed to in writing, software distributed
                            under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
                            CONDITIONS OF ANY KIND, either express or implied. See the License for the
                            specific language governing permissions and limitations under the License. 
                        </div>
                        <div id="Google_ApisLicense" style="display: none;">
                                                                                      Apache License
                            <br />
                                                    Version 2.0, January 2004
                            <br />
                                                 http://www.apache.org/licenses/
                            <br />

                            TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION
                            <br />

                            1. Definitions.
                            <br />

                               "License" shall mean the terms and conditions for use, reproduction,
                               and distribution as defined by Sections 1 through 9 of this document.
                            <br />

                               "Licensor" shall mean the copyright owner or entity authorized by
                               the copyright owner that is granting the License.
                            <br />

                               "Legal Entity" shall mean the union of the acting entity and all
                               other entities that control, are controlled by, or are under common
                               control with that entity. For the purposes of this definition,
                               "control" means (i) the power, direct or indirect, to cause the
                               direction or management of such entity, whether by contract or
                               otherwise, or (ii) ownership of fifty percent (50%) or more of the
                               outstanding shares, or (iii) beneficial ownership of such entity.
                            <br />

                               "You" (or "Your") shall mean an individual or Legal Entity
                               exercising permissions granted by this License.
                            <br />

                               "Source" form shall mean the preferred form for making modifications,
                               including but not limited to software source code, documentation
                               source, and configuration files.
                            <br />

                               "Object" form shall mean any form resulting from mechanical
                               transformation or translation of a Source form, including but
                               not limited to compiled object code, generated documentation,
                               and conversions to other media types.
                            <br />

                               "Work" shall mean the work of authorship, whether in Source or
                               Object form, made available under the License, as indicated by a
                               copyright notice that is included in or attached to the work
                               (an example is provided in the Appendix below).
                            <br />

                               "Derivative Works" shall mean any work, whether in Source or Object
                               form, that is based on (or derived from) the Work and for which the
                               editorial revisions, annotations, elaborations, or other modifications
                               represent, as a whole, an original work of authorship. For the purposes
                               of this License, Derivative Works shall not include works that remain
                               separable from, or merely link (or bind by name) to the interfaces of,
                               the Work and Derivative Works thereof.
                            <br />

                               "Contribution" shall mean any work of authorship, including
                               the original version of the Work and any modifications or additions
                               to that Work or Derivative Works thereof, that is intentionally
                               submitted to Licensor for inclusion in the Work by the copyright owner
                               or by an individual or Legal Entity authorized to submit on behalf of
                               the copyright owner. For the purposes of this definition, "submitted"
                               means any form of electronic, verbal, or written communication sent
                               to the Licensor or its representatives, including but not limited to
                               communication on electronic mailing lists, source code control systems,
                               and issue tracking systems that are managed by, or on behalf of, the
                               Licensor for the purpose of discussing and improving the Work, but
                               excluding communication that is conspicuously marked or otherwise
                               designated in writing by the copyright owner as "Not a Contribution."
                            <br />

                               "Contributor" shall mean Licensor and any individual or Legal Entity
                               on behalf of whom a Contribution has been received by Licensor and
                               subsequently incorporated within the Work.
                            <br />

                            2. Grant of Copyright License. Subject to the terms and conditions of
                               this License, each Contributor hereby grants to You a perpetual,
                               worldwide, non-exclusive, no-charge, royalty-free, irrevocable
                               copyright license to reproduce, prepare Derivative Works of,
                               publicly display, publicly perform, sublicense, and distribute the
                               Work and such Derivative Works in Source or Object form.
                            <br />

                            3. Grant of Patent License. Subject to the terms and conditions of
                               this License, each Contributor hereby grants to You a perpetual,
                               worldwide, non-exclusive, no-charge, royalty-free, irrevocable
                               (except as stated in this section) patent license to make, have made,
                               use, offer to sell, sell, import, and otherwise transfer the Work,
                               where such license applies only to those patent claims licensable
                               by such Contributor that are necessarily infringed by their
                               Contribution(s) alone or by combination of their Contribution(s)
                               with the Work to which such Contribution(s) was submitted. If You
                               institute patent litigation against any entity (including a
                               cross-claim or counterclaim in a lawsuit) alleging that the Work
                               or a Contribution incorporated within the Work constitutes direct
                               or contributory patent infringement, then any patent licenses
                               granted to You under this License for that Work shall terminate
                               as of the date such litigation is filed.
                            <br />

                            4. Redistribution. You may reproduce and distribute copies of the
                               Work or Derivative Works thereof in any medium, with or without
                               modifications, and in Source or Object form, provided that You
                               meet the following conditions:
                            <br />

                               (a) You must give any other recipients of the Work or
                                   Derivative Works a copy of this License; and
                            <br />

                               (b) You must cause any modified files to carry prominent notices
                                   stating that You changed the files; and
                            <br />

                               (c) You must retain, in the Source form of any Derivative Works
                                   that You distribute, all copyright, patent, trademark, and
                                   attribution notices from the Source form of the Work,
                                   excluding those notices that do not pertain to any part of
                                   the Derivative Works; and
                            <br />

                               (d) If the Work includes a "NOTICE" text file as part of its
                                   distribution, then any Derivative Works that You distribute must
                                   include a readable copy of the attribution notices contained
                                   within such NOTICE file, excluding those notices that do not
                                   pertain to any part of the Derivative Works, in at least one
                                   of the following places: within a NOTICE text file distributed
                                   as part of the Derivative Works; within the Source form or
                                   documentation, if provided along with the Derivative Works; or,
                                   within a display generated by the Derivative Works, if and
                                   wherever such third-party notices normally appear. The contents
                                   of the NOTICE file are for informational purposes only and
                                   do not modify the License. You may add Your own attribution
                                   notices within Derivative Works that You distribute, alongside
                                   or as an addendum to the NOTICE text from the Work, provided
                                   that such additional attribution notices cannot be construed
                                   as modifying the License.
                            <br />

                               You may add Your own copyright statement to Your modifications and
                               may provide additional or different license terms and conditions
                               for use, reproduction, or distribution of Your modifications, or
                               for any such Derivative Works as a whole, provided Your use,
                               reproduction, and distribution of the Work otherwise complies with
                               the conditions stated in this License.
                            <br />

                            5. Submission of Contributions. Unless You explicitly state otherwise,
                               any Contribution intentionally submitted for inclusion in the Work
                               by You to the Licensor shall be under the terms and conditions of
                               this License, without any additional terms or conditions.
                               Notwithstanding the above, nothing herein shall supersede or modify
                               the terms of any separate license agreement you may have executed
                               with Licensor regarding such Contributions.
                            <br />

                            6. Trademarks. This License does not grant permission to use the trade
                               names, trademarks, service marks, or product names of the Licensor,
                               except as required for reasonable and customary use in describing the
                               origin of the Work and reproducing the content of the NOTICE file.
                            <br />

                            7. Disclaimer of Warranty. Unless required by applicable law or
                               agreed to in writing, Licensor provides the Work (and each
                               Contributor provides its Contributions) on an "AS IS" BASIS,
                               WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
                               implied, including, without limitation, any warranties or conditions
                               of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A
                               PARTICULAR PURPOSE. You are solely responsible for determining the
                               appropriateness of using or redistributing the Work and assume any
                               risks associated with Your exercise of permissions under this License.
                            <br />

                            8. Limitation of Liability. In no event and under no legal theory,
                               whether in tort (including negligence), contract, or otherwise,
                               unless required by applicable law (such as deliberate and grossly
                               negligent acts) or agreed to in writing, shall any Contributor be
                               liable to You for damages, including any direct, indirect, special,
                               incidental, or consequential damages of any character arising as a
                               result of this License or out of the use or inability to use the
                               Work (including but not limited to damages for loss of goodwill,
                               work stoppage, computer failure or malfunction, or any and all
                               other commercial damages or losses), even if such Contributor
                               has been advised of the possibility of such damages.
                            <br />

                            9. Accepting Warranty or Additional Liability. While redistributing
                               the Work or Derivative Works thereof, You may choose to offer,
                               and charge a fee for, acceptance of support, warranty, indemnity,
                               or other liability obligations and/or rights consistent with this
                               License. However, in accepting such obligations, You may act only
                               on Your own behalf and on Your sole responsibility, not on behalf
                               of any other Contributor, and only if You agree to indemnify,
                               defend, and hold each Contributor harmless for any liability
                               incurred by, or claims asserted against, such Contributor by reason
                               of your accepting any such warranty or additional liability.
                            <br />

                        </div>
                        <div id="Log4netLicense" style="display: none;">
                                                             Apache License
                            <br />
                                                       Version 2.0, January 2004
                            <br />
                                                    http://www.apache.org/licenses/
                            <br />

                               TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION
                            <br />

                               1. Definitions.
                            <br />

                                  "License" shall mean the terms and conditions for use, reproduction,
                                  and distribution as defined by Sections 1 through 9 of this document.
                            <br />

                                  "Licensor" shall mean the copyright owner or entity authorized by
                                  the copyright owner that is granting the License.
                            <br />

                                  "Legal Entity" shall mean the union of the acting entity and all
                                  other entities that control, are controlled by, or are under common
                                  control with that entity. For the purposes of this definition,
                                  "control" means (i) the power, direct or indirect, to cause the
                                  direction or management of such entity, whether by contract or
                                  otherwise, or (ii) ownership of fifty percent (50%) or more of the
                                  outstanding shares, or (iii) beneficial ownership of such entity.
                            <br />

                                  "You" (or "Your") shall mean an individual or Legal Entity
                                  exercising permissions granted by this License.
                            <br />

                                  "Source" form shall mean the preferred form for making modifications,
                                  including but not limited to software source code, documentation
                                  source, and configuration files.
                            <br />

                                  "Object" form shall mean any form resulting from mechanical
                                  transformation or translation of a Source form, including but
                                  not limited to compiled object code, generated documentation,
                                  and conversions to other media types.
                            <br />

                                  "Work" shall mean the work of authorship, whether in Source or
                                  Object form, made available under the License, as indicated by a
                                  copyright notice that is included in or attached to the work
                                  (an example is provided in the Appendix below).
                            <br />

                                  "Derivative Works" shall mean any work, whether in Source or Object
                                  form, that is based on (or derived from) the Work and for which the
                                  editorial revisions, annotations, elaborations, or other modifications
                                  represent, as a whole, an original work of authorship. For the purposes
                                  of this License, Derivative Works shall not include works that remain
                                  separable from, or merely link (or bind by name) to the interfaces of,
                                  the Work and Derivative Works thereof.
                            <br />

                                  "Contribution" shall mean any work of authorship, including
                                  the original version of the Work and any modifications or additions
                                  to that Work or Derivative Works thereof, that is intentionally
                                  submitted to Licensor for inclusion in the Work by the copyright owner
                                  or by an individual or Legal Entity authorized to submit on behalf of
                                  the copyright owner. For the purposes of this definition, "submitted"
                                  means any form of electronic, verbal, or written communication sent
                                  to the Licensor or its representatives, including but not limited to
                                  communication on electronic mailing lists, source code control systems,
                                  and issue tracking systems that are managed by, or on behalf of, the
                                  Licensor for the purpose of discussing and improving the Work, but
                                  excluding communication that is conspicuously marked or otherwise
                                  designated in writing by the copyright owner as "Not a Contribution."
                            <br />

                                  "Contributor" shall mean Licensor and any individual or Legal Entity
                                  on behalf of whom a Contribution has been received by Licensor and
                                  subsequently incorporated within the Work.
                            <br />

                               2. Grant of Copyright License. Subject to the terms and conditions of
                                  this License, each Contributor hereby grants to You a perpetual,
                                  worldwide, non-exclusive, no-charge, royalty-free, irrevocable
                                  copyright license to reproduce, prepare Derivative Works of,
                                  publicly display, publicly perform, sublicense, and distribute the
                                  Work and such Derivative Works in Source or Object form.
                            <br />

                               3. Grant of Patent License. Subject to the terms and conditions of
                                  this License, each Contributor hereby grants to You a perpetual,
                                  worldwide, non-exclusive, no-charge, royalty-free, irrevocable
                                  (except as stated in this section) patent license to make, have made,
                                  use, offer to sell, sell, import, and otherwise transfer the Work,
                                  where such license applies only to those patent claims licensable
                                  by such Contributor that are necessarily infringed by their
                                  Contribution(s) alone or by combination of their Contribution(s)
                                  with the Work to which such Contribution(s) was submitted. If You
                                  institute patent litigation against any entity (including a
                                  cross-claim or counterclaim in a lawsuit) alleging that the Work
                                  or a Contribution incorporated within the Work constitutes direct
                                  or contributory patent infringement, then any patent licenses
                                  granted to You under this License for that Work shall terminate
                                  as of the date such litigation is filed.
                            <br />

                               4. Redistribution. You may reproduce and distribute copies of the
                                  Work or Derivative Works thereof in any medium, with or without
                                  modifications, and in Source or Object form, provided that You
                                  meet the following conditions:
                            <br />

                                  (a) You must give any other recipients of the Work or
                                      Derivative Works a copy of this License; and
                            <br />

                                  (b) You must cause any modified files to carry prominent notices
                                      stating that You changed the files; and
                            <br />

                                  (c) You must retain, in the Source form of any Derivative Works
                                      that You distribute, all copyright, patent, trademark, and
                                      attribution notices from the Source form of the Work,
                                      excluding those notices that do not pertain to any part of
                                      the Derivative Works; and
                            <br />

                                  (d) If the Work includes a "NOTICE" text file as part of its
                                      distribution, then any Derivative Works that You distribute must
                                      include a readable copy of the attribution notices contained
                                      within such NOTICE file, excluding those notices that do not
                                      pertain to any part of the Derivative Works, in at least one
                                      of the following places: within a NOTICE text file distributed
                                      as part of the Derivative Works; within the Source form or
                                      documentation, if provided along with the Derivative Works; or,
                                      within a display generated by the Derivative Works, if and
                                      wherever such third-party notices normally appear. The contents
                                      of the NOTICE file are for informational purposes only and
                                      do not modify the License. You may add Your own attribution
                                      notices within Derivative Works that You distribute, alongside
                                      or as an addendum to the NOTICE text from the Work, provided
                                      that such additional attribution notices cannot be construed
                                      as modifying the License.
                            <br />

                                  You may add Your own copyright statement to Your modifications and
                                  may provide additional or different license terms and conditions
                                  for use, reproduction, or distribution of Your modifications, or
                                  for any such Derivative Works as a whole, provided Your use,
                                  reproduction, and distribution of the Work otherwise complies with
                                  the conditions stated in this License.
                            <br />

                               5. Submission of Contributions. Unless You explicitly state otherwise,
                                  any Contribution intentionally submitted for inclusion in the Work
                                  by You to the Licensor shall be under the terms and conditions of
                                  this License, without any additional terms or conditions.
                                  Notwithstanding the above, nothing herein shall supersede or modify
                                  the terms of any separate license agreement you may have executed
                                  with Licensor regarding such Contributions.
                            <br />

                               6. Trademarks. This License does not grant permission to use the trade
                                  names, trademarks, service marks, or product names of the Licensor,
                                  except as required for reasonable and customary use in describing the
                                  origin of the Work and reproducing the content of the NOTICE file.
                            <br />

                               7. Disclaimer of Warranty. Unless required by applicable law or
                                  agreed to in writing, Licensor provides the Work (and each
                                  Contributor provides its Contributions) on an "AS IS" BASIS,
                                  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
                                  implied, including, without limitation, any warranties or conditions
                                  of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A
                                  PARTICULAR PURPOSE. You are solely responsible for determining the
                                  appropriateness of using or redistributing the Work and assume any
                                  risks associated with Your exercise of permissions under this License.
                            <br />

                               8. Limitation of Liability. In no event and under no legal theory,
                                  whether in tort (including negligence), contract, or otherwise,
                                  unless required by applicable law (such as deliberate and grossly
                                  negligent acts) or agreed to in writing, shall any Contributor be
                                  liable to You for damages, including any direct, indirect, special,
                                  incidental, or consequential damages of any character arising as a
                                  result of this License or out of the use or inability to use the
                                  Work (including but not limited to damages for loss of goodwill,
                                  work stoppage, computer failure or malfunction, or any and all
                                  other commercial damages or losses), even if such Contributor
                                  has been advised of the possibility of such damages.
                            <br />

                               9. Accepting Warranty or Additional Liability. While redistributing
                                  the Work or Derivative Works thereof, You may choose to offer,
                                  and charge a fee for, acceptance of support, warranty, indemnity,
                                  or other liability obligations and/or rights consistent with this
                                  License. However, in accepting such obligations, You may act only
                                  on Your own behalf and on Your sole responsibility, not on behalf
                                  of any other Contributor, and only if You agree to indemnify,
                                  defend, and hold each Contributor harmless for any liability
                                  incurred by, or claims asserted against, such Contributor by reason
                                  of your accepting any such warranty or additional liability.
                            <br />

                               END OF TERMS AND CONDITIONS
                            <br />

                               APPENDIX: How to apply the Apache License to your work.
                            <br />

                                  To apply the Apache License to your work, attach the following
                                  boilerplate notice, with the fields enclosed by brackets "[]"
                                  replaced with your own identifying information. (Don't include
                                  the brackets!)  The text should be enclosed in the appropriate
                                  comment syntax for the file format. We also recommend that a
                                  file or class name and description of purpose be included on the
                                  same "printed page" as the copyright notice for easier
                                  identification within third-party archives.
                            <br />

                               Copyright [yyyy] [name of copyright owner]
                            <br />

                               Licensed under the Apache License, Version 2.0 (the "License");
                               you may not use this file except in compliance with the License.
                               You may obtain a copy of the License at
                            <br />

                                   http://www.apache.org/licenses/LICENSE-2.0
                            <br />

                               Unless required by applicable law or agreed to in writing, software
                               distributed under the License is distributed on an "AS IS" BASIS,
                               WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
                               See the License for the specific language governing permissions and
                               limitations under the License.
                            <br />
                            <br />
                               **
                            <br />
                               **  NOTICE file corresponding to the section 4 (d) of the Apache License, 
                            <br />
                               **  Version 2.0, in this case for the Apache log4net distribution.
                            <br />
                               **
                            <br />
                            <br />

                               This product includes software developed by
                               The Apache Software Foundation (http://www.apache.org/).
                            <br />

                               Please read the LICENSE files present in the root directory of this 
                               distribution.
                            <br />

                               The names "log4net" and "Apache Software Foundation" must not be used to
                               endorse  or promote  products derived  from this  software without prior
                               written permission. For written permission, please contact
                               apache@apache.org.		
                            <br />
                        </div>
                        <div id="EntityFrameworkLicense" style="display: none;">
                            MICROSOFT SOFTWARE SUPPLEMENTAL LICENSE TERMS
                            <br />
                            ENTITY FRAMEWORK 5.0 FOR MICROSOFT WINDOWS OPERATING SYSTEM
                            <br />
                            Microsoft Corporation (or based on where you live, one of its affiliates) licenses this supplement to you. If you are licensed to use Microsoft Windows Operating System software (the "software"), you may use this supplement. You may not use it if you do not have a license for the software. You may use this supplement with each validly licensed copy of the software.
                            <br />
                            The following license terms describe additional use terms for this supplement. These terms and the license terms for the software apply to your use of the supplement. If there is a conflict, these supplemental license terms apply.
                            <br />
                            By using this supplement, you accept these terms. If you do not accept them, do not use this supplement.
                            <br />
                            If you comply with these license terms, you have the rights below.
                            <br />
                            1. DISTRIBUTABLE CODE. The supplement is comprised of Distributable Code. "Distributable Code" is code that you are permitted to distribute in programs you develop if you comply with the terms below.
                            <br />
                            a. Right to Use and Distribute.
                            <br />
                            You may copy and distribute the object code form of the supplement.
                            Third Party Distribution. You may permit distributors of your programs to copy and distribute the Distributable Code as part of those programs.
                            <br />
                            b. Distribution Requirements. For any Distributable Code you distribute, you must
                            <br />
                            add significant primary functionality to it in your programs;
                            for any Distributable Code having a filename extension of .lib, distribute only the results of running such Distributable Code through a linker with your program;
                            distribute Distributable Code included in a setup program only as part of that setup program without modification;
                            require distributors and external end users to agree to terms that protect it at least as much as this agreement;
                            display your valid copyright notice on your programs; and
                            indemnify, defend, and hold harmless Microsoft from any claims, including attorneys' fees, related to the distribution or use of your programs.
                            <br />
                            c. Distribution Restrictions. You may not
                            <br />
                            alter any copyright, trademark or patent notice in the Distributable Code;
                            use Microsoft's trademarks in your programs' names or in a way that suggests your programs come from or are endorsed by Microsoft;
                            distribute Distributable Code to run on a platform other than the Windows platform;
                            include Distributable Code in malicious, deceptive or unlawful programs; or
                            modify or distribute the source code of any Distributable Code so that any part of it becomes subject to an Excluded License. An Excluded License is one that requires, as a condition of use, modification or distribution, that
                            the code be disclosed or distributed in source code form; or
                            others have the right to modify it.
                            <br />
                            2. SUPPORT SERVICES FOR SUPPLEMENT. Microsoft provides support services for this software as described at https://www.support.microsoft.com/common/international.aspx.
                        </div>
                        <div id="OwinLicense" style="display: none;">
                            Apache-2.0
                            <br />
                            License text
                             Apache License
                            <br />
                            Version 2.0, January 2004
                            <br />
                            http://www.apache.org/licenses/ TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION
                            <br />
                               1. Definitions.
                            <br />
                                  "License" shall mean the terms and conditions for use, reproduction, and distribution as defined by Sections 1 through 9 of this document.
                            <br />
                                  "Licensor" shall mean the copyright owner or entity authorized by the copyright owner that is granting the License.
                            <br />
                                  "Legal Entity" shall mean the union of the acting entity and all other entities that control, are controlled by, or are under common control with that entity. For the purposes of this definition, "control" means (i) the power, direct or indirect, to cause the direction or management of such entity, whether by contract or otherwise, or (ii) ownership of fifty percent (50%) or more of the outstanding shares, or (iii) beneficial ownership of such entity.
                            <br />
                                  "You" (or "Your") shall mean an individual or Legal Entity exercising permissions granted by this License.
                            <br />
                                  "Source" form shall mean the preferred form for making modifications, including but not limited to software source code, documentation source, and configuration files.
                            <br />
                                  "Object" form shall mean any form resulting from mechanical transformation or translation of a Source form, including but not limited to compiled object code, generated documentation, and conversions to other media types.
                            <br />
                                  "Work" shall mean the work of authorship, whether in Source or Object form, made available under the License, as indicated by a copyright notice that is included in or attached to the work (an example is provided in the Appendix below).
                            <br />
                                  "Derivative Works" shall mean any work, whether in Source or Object form, that is based on (or derived from) the Work and for which the editorial revisions, annotations, elaborations, or other modifications represent, as a whole, an original work of authorship. For the purposes of this License, Derivative Works shall not include works that remain separable from, or merely link (or bind by name) to the interfaces of, the Work and Derivative Works thereof.
                            <br />
                                  "Contribution" shall mean any work of authorship, including the original version of the Work and any modifications or additions to that Work or Derivative Works thereof, that is intentionally submitted to Licensor for inclusion in the Work by the copyright owner or by an individual or Legal Entity authorized to submit on behalf of the copyright owner. For the purposes of this definition, "submitted" means any form of electronic, verbal, or written communication sent to the Licensor or its representatives, including but not limited to communication on electronic mailing lists, source code control systems, and issue tracking systems that are managed by, or on behalf of, the Licensor for the purpose of discussing and improving the Work, but excluding communication that is conspicuously marked or otherwise designated in writing by the copyright owner as "Not a Contribution."
                            <br />
                                  "Contributor" shall mean Licensor and any individual or Legal Entity on behalf of whom a Contribution has been received by Licensor and subsequently incorporated within the Work.

                               2. Grant of Copyright License. Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable copyright license to reproduce, prepare Derivative Works of, publicly display, publicly perform, sublicense, and distribute the Work and such Derivative Works in Source or Object form.
                            <br />
                               3. Grant of Patent License. Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, offer to sell, sell, import, and otherwise transfer the Work, where such license applies only to those patent claims licensable by such Contributor that are necessarily infringed by their Contribution(s) alone or by combination of their Contribution(s) with the Work to which such Contribution(s) was submitted. If You institute patent litigation against any entity (including a cross-claim or counterclaim in a lawsuit) alleging that the Work or a Contribution incorporated within the Work constitutes direct or contributory patent infringement, then any patent licenses granted to You under this License for that Work shall terminate as of the date such litigation is filed.
                            <br />
                               4. Redistribution. You may reproduce and distribute copies of the Work or Derivative Works thereof in any medium, with or without modifications, and in Source or Object form, provided that You meet the following conditions:
                            <br />
                                  (a) You must give any other recipients of the Work or Derivative Works a copy of this License; and
                            <br />

                                  (b) You must cause any modified files to carry prominent notices stating that You changed the files; and
                            <br />

                                  (c) You must retain, in the Source form of any Derivative Works that You distribute, all copyright, patent, trademark, and attribution notices from the Source form of the Work, excluding those notices that do not pertain to any part of the Derivative Works; and
                            <br />

                                  (d) If the Work includes a "NOTICE" text file as part of its distribution, then any Derivative Works that You distribute must include a readable copy of the attribution notices contained within such NOTICE file, excluding those notices that do not pertain to any part of the Derivative Works, in at least one of the following places: within a NOTICE text file distributed as part of the Derivative Works; within the Source form or documentation, if provided along with the Derivative Works; or, within a display generated by the Derivative Works, if and wherever such third-party notices normally appear. The contents of the NOTICE file are for informational purposes only and do not modify the License. You may add Your own attribution notices within Derivative Works that You distribute, alongside or as an addendum to the NOTICE text from the Work, provided that such additional attribution notices cannot be construed as modifying the License.
                            <br />

                                  You may add Your own copyright statement to Your modifications and may provide additional or different license terms and conditions for use, reproduction, or distribution of Your modifications, or for any such Derivative Works as a whole, provided Your use, reproduction, and distribution of the Work otherwise complies with the conditions stated in this License.
                            <br />

                               5. Submission of Contributions. Unless You explicitly state otherwise, any Contribution intentionally submitted for inclusion in the Work by You to the Licensor shall be under the terms and conditions of this License, without any additional terms or conditions. Notwithstanding the above, nothing herein shall supersede or modify the terms of any separate license agreement you may have executed with Licensor regarding such Contributions.
                            <br />

                               6. Trademarks. This License does not grant permission to use the trade names, trademarks, service marks, or product names of the Licensor, except as required for reasonable and customary use in describing the origin of the Work and reproducing the content of the NOTICE file.
                            <br />

                               7. Disclaimer of Warranty. Unless required by applicable law or agreed to in writing, Licensor provides the Work (and each Contributor provides its Contributions) on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied, including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE. You are solely responsible for determining the appropriateness of using or redistributing the Work and assume any risks associated with Your exercise of permissions under this License.
                            <br />

                               8. Limitation of Liability. In no event and under no legal theory, whether in tort (including negligence), contract, or otherwise, unless required by applicable law (such as deliberate and grossly negligent acts) or agreed to in writing, shall any Contributor be liable to You for damages, including any direct, indirect, special, incidental, or consequential damages of any character arising as a result of this License or out of the use or inability to use the Work (including but not limited to damages for loss of goodwill, work stoppage, computer failure or malfunction, or any and all other commercial damages or losses), even if such Contributor has been advised of the possibility of such damages.
                            <br />

                               9. Accepting Warranty or Additional Liability. While redistributing the Work or Derivative Works thereof, You may choose to offer, and charge a fee for, acceptance of support, warranty, indemnity, or other liability obligations and/or rights consistent with this License. However, in accepting such obligations, You may act only on Your own behalf and on Your sole responsibility, not on behalf of any other Contributor, and only if You agree to indemnify, defend, and hold each Contributor harmless for any liability incurred by, or claims asserted against, such Contributor by reason of your accepting any such warranty or additional liability. END OF TERMS AND CONDITIONS
                            <br />

                            APPENDIX: How to apply the Apache License to your work.
                            <br />

                            To apply the Apache License to your work, attach the following boilerplate notice, with the fields enclosed by brackets "[]" replaced with your own identifying information. (Don't include the brackets!) The text should be enclosed in the appropriate comment syntax for the file format. We also recommend that a file or class name and description of purpose be included on the same "printed page" as the copyright notice for easier identification within third-party archives.
                            <br />

                            Copyright _____
                            <br />

                            Licensed under the Apache License, Version 2.0 (the "License");
                            <br />

                            you may not use this file except in compliance with the License.
                            <br />

                            You may obtain a copy of the License at
                            <br />

                            http://www.apache.org/licenses/LICENSE-2.0
                            <br />

                            Unless required by applicable law or agreed to in writing, software
                            <br />

                            distributed under the License is distributed on an "AS IS" BASIS,
                            <br />

                            WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
                            <br />

                            See the License for the specific language governing permissions and
                            <br />

                            limitations under the License.
                            <br />
 
                        </div>
                        <div id="RestSharpLicense" style="display: none;">
                            Apache License
                            Version 2.0, January 2004
                            http://www.apache.org/licenses/
                            <br />

                            TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION
                            <br />

                            1. Definitions.
                            <br />

                            "License" shall mean the terms and conditions for use, reproduction, and distribution as defined by Sections 1 through 9 of this document.
                            <br />

                            "Licensor" shall mean the copyright owner or entity authorized by the copyright owner that is granting the License.
                            <br />

                            "Legal Entity" shall mean the union of the acting entity and all other entities that control, are controlled by, or are under common control with that entity. For the purposes of this definition, "control" means (i) the power, direct or indirect, to cause the direction or management of such entity, whether by contract or otherwise, or (ii) ownership of fifty percent (50%) or more of the outstanding shares, or (iii) beneficial ownership of such entity.
                            <br />

                            "You" (or "Your") shall mean an individual or Legal Entity exercising permissions granted by this License.
                            <br />

                            "Source" form shall mean the preferred form for making modifications, including but not limited to software source code, documentation source, and configuration files.
                            <br />

                            "Object" form shall mean any form resulting from mechanical transformation or translation of a Source form, including but not limited to compiled object code, generated documentation, and conversions to other media types.
                            <br />

                            "Work" shall mean the work of authorship, whether in Source or Object form, made available under the License, as indicated by a copyright notice that is included in or attached to the work (an example is provided in the Appendix below).
                            <br />

                            "Derivative Works" shall mean any work, whether in Source or Object form, that is based on (or derived from) the Work and for which the editorial revisions, annotations, elaborations, or other modifications represent, as a whole, an original work of authorship. For the purposes of this License, Derivative Works shall not include works that remain separable from, or merely link (or bind by name) to the interfaces of, the Work and Derivative Works thereof.
                            <br />

                            "Contribution" shall mean any work of authorship, including the original version of the Work and any modifications or additions to that Work or Derivative Works thereof, that is intentionally submitted to Licensor for inclusion in the Work by the copyright owner or by an individual or Legal Entity authorized to submit on behalf of the copyright owner. For the purposes of this definition, "submitted" means any form of electronic, verbal, or written communication sent to the Licensor or its representatives, including but not limited to communication on electronic mailing lists, source code control systems, and issue tracking systems that are managed by, or on behalf of, the Licensor for the purpose of discussing and improving the Work, but excluding communication that is conspicuously marked or otherwise designated in writing by the copyright owner as "Not a Contribution."
                            <br />

                            "Contributor" shall mean Licensor and any individual or Legal Entity on behalf of whom a Contribution has been received by Licensor and subsequently incorporated within the Work.
                            <br />

                            2. Grant of Copyright License.
                            <br />

                            Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable copyright license to reproduce, prepare Derivative Works of, publicly display, publicly perform, sublicense, and distribute the Work and such Derivative Works in Source or Object form.
                            <br />

                            3. Grant of Patent License.
                            <br />

                            Subject to the terms and conditions of this License, each Contributor hereby grants to You a perpetual, worldwide, non-exclusive, no-charge, royalty-free, irrevocable (except as stated in this section) patent license to make, have made, use, offer to sell, sell, import, and otherwise transfer the Work, where such license applies only to those patent claims licensable by such Contributor that are necessarily infringed by their Contribution(s) alone or by combination of their Contribution(s) with the Work to which such Contribution(s) was submitted. If You institute patent litigation against any entity (including a cross-claim or counterclaim in a lawsuit) alleging that the Work or a Contribution incorporated within the Work constitutes direct or contributory patent infringement, then any patent licenses granted to You under this License for that Work shall terminate as of the date such litigation is filed.
                            <br />

                            4. Redistribution.
                            <br />

                            You may reproduce and distribute copies of the Work or Derivative Works thereof in any medium, with or without modifications, and in Source or Object form, provided that You meet the following conditions:
                            <br />

                            You must give any other recipients of the Work or Derivative Works a copy of this License; and
                            You must cause any modified files to carry prominent notices stating that You changed the files; and
                            You must retain, in the Source form of any Derivative Works that You distribute, all copyright, patent, trademark, and attribution notices from the Source form of the Work, excluding those notices that do not pertain to any part of the Derivative Works; and
                            If the Work includes a "NOTICE" text file as part of its distribution, then any Derivative Works that You distribute must include a readable copy of the attribution notices contained within such NOTICE file, excluding those notices that do not pertain to any part of the Derivative Works, in at least one of the following places: within a NOTICE text file distributed as part of the Derivative Works; within the Source form or documentation, if provided along with the Derivative Works; or, within a display generated by the Derivative Works, if and wherever such third-party notices normally appear. The contents of the NOTICE file are for informational purposes only and do not modify the License. You may add Your own attribution notices within Derivative Works that You distribute, alongside or as an addendum to the NOTICE text from the Work, provided that such additional attribution notices cannot be construed as modifying the License.
                            You may add Your own copyright statement to Your modifications and may provide additional or different license terms and conditions for use, reproduction, or distribution of Your modifications, or for any such Derivative Works as a whole, provided Your use, reproduction, and distribution of the Work otherwise complies with the conditions stated in this License.
                            <br />

                            5. Submission of Contributions.
                            <br />

                            Unless You explicitly state otherwise, any Contribution intentionally submitted for inclusion in the Work by You to the Licensor shall be under the terms and conditions of this License, without any additional terms or conditions. Notwithstanding the above, nothing herein shall supersede or modify the terms of any separate license agreement you may have executed with Licensor regarding such Contributions.
                            <br />

                            6. Trademarks.
                            <br />

                            This License does not grant permission to use the trade names, trademarks, service marks, or product names of the Licensor, except as required for reasonable and customary use in describing the origin of the Work and reproducing the content of the NOTICE file.
                            <br />

                            7. Disclaimer of Warranty.
                            <br />

                            Unless required by applicable law or agreed to in writing, Licensor provides the Work (and each Contributor provides its Contributions) on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied, including, without limitation, any warranties or conditions of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A PARTICULAR PURPOSE. You are solely responsible for determining the appropriateness of using or redistributing the Work and assume any risks associated with Your exercise of permissions under this License.
                            <br />

                            8. Limitation of Liability.
                            <br />

                            In no event and under no legal theory, whether in tort (including negligence), contract, or otherwise, unless required by applicable law (such as deliberate and grossly negligent acts) or agreed to in writing, shall any Contributor be liable to You for damages, including any direct, indirect, special, incidental, or consequential damages of any character arising as a result of this License or out of the use or inability to use the Work (including but not limited to damages for loss of goodwill, work stoppage, computer failure or malfunction, or any and all other commercial damages or losses), even if such Contributor has been advised of the possibility of such damages.
                            <br />

                            9. Accepting Warranty or Additional Liability.
                            <br />

                            While redistributing the Work or Derivative Works thereof, You may choose to offer, and charge a fee for, acceptance of support, warranty, indemnity, or other liability obligations and/or rights consistent with this License. However, in accepting such obligations, You may act only on Your own behalf and on Your sole responsibility, not on behalf of any other Contributor, and only if You agree to indemnify, defend, and hold each Contributor harmless for any liability incurred by, or claims asserted against, such Contributor by reason of your accepting any such warranty or additional liability.
                            <br />

                            END OF TERMS AND CONDITIONS
                            <br />

                        </div>


                        <div id="JQuery_HotKeysLicense" style="display: none;">
                            The MIT License
                            <br />
                            Copyright (c) 2008-2014 Tzury Bar Yochay
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                        </div>
                        <div id ="JSzipLicense" style="display: none;">
                            JSZip is dual licensed. You may use it under the MIT license *or* the GPLv3
                            license.
                            <br />
                            The MIT License
                            <br />
                            Copyright (c) 2009-2016 Stuart Knightley, David Duponchel, Franz Buchinger, António Afonso
                            <br />
                            Permission is hereby granted, free of charge, to any person obtaining a copy
                            of this software and associated documentation files (the "Software"), to deal
                            in the Software without restriction, including without limitation the rights
                            to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
                            copies of the Software, and to permit persons to whom the Software is
                            furnished to do so, subject to the following conditions:
                            <br />
                            The above copyright notice and this permission notice shall be included in
                            all copies or substantial portions of the Software.
                            <br />
                            THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
                            IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
                            FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
                            AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
                            LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
                            OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
                            THE SOFTWARE.
                            <br />
                            <br />
                            GPL version 3
                            =============
                            <br />
                                                GNU GENERAL PUBLIC LICENSE
                                                   Version 3, 29 June 2007
                            <br />
                             Copyright (C) 2007 Free Software Foundation, Inc. <http://fsf.org/>
                             Everyone is permitted to copy and distribute verbatim copies
                             of this license document, but changing it is not allowed.
                            <br />
                                                        Preamble
                            <br />
                              The GNU General Public License is a free, copyleft license for
                            software and other kinds of works.
                            <br />
                              The licenses for most software and other practical works are designed
                            to take away your freedom to share and change the works.  By contrast,
                            the GNU General Public License is intended to guarantee your freedom to
                            share and change all versions of a program--to make sure it remains free
                            software for all its users.  We, the Free Software Foundation, use the
                            GNU General Public License for most of our software; it applies also to
                            any other work released this way by its authors.  You can apply it to
                            your programs, too.
                            <br />
                              When we speak of free software, we are referring to freedom, not
                            price.  Our General Public Licenses are designed to make sure that you
                            have the freedom to distribute copies of free software (and charge for
                            them if you wish), that you receive source code or can get it if you
                            want it, that you can change the software or use pieces of it in new
                            free programs, and that you know you can do these things.
                            <br />
                              To protect your rights, we need to prevent others from denying you
                            these rights or asking you to surrender the rights.  Therefore, you have
                            certain responsibilities if you distribute copies of the software, or if
                            you modify it: responsibilities to respect the freedom of others.
                            <br />
                              For example, if you distribute copies of such a program, whether
                            gratis or for a fee, you must pass on to the recipients the same
                            freedoms that you received.  You must make sure that they, too, receive
                            or can get the source code.  And you must show them these terms so they
                            know their rights.
                            <br />
                              Developers that use the GNU GPL protect your rights with two steps:
                            (1) assert copyright on the software, and (2) offer you this License
                            giving you legal permission to copy, distribute and/or modify it.
                            <br />
                              For the developers' and authors' protection, the GPL clearly explains
                            that there is no warranty for this free software.  For both users' and
                            authors' sake, the GPL requires that modified versions be marked as
                            changed, so that their problems will not be attributed erroneously to
                            authors of previous versions.
                            <br />
                              Some devices are designed to deny users access to install or run
                            modified versions of the software inside them, although the manufacturer
                            can do so.  This is fundamentally incompatible with the aim of
                            protecting users' freedom to change the software.  The systematic
                            pattern of such abuse occurs in the area of products for individuals to
                            use, which is precisely where it is most unacceptable.  Therefore, we
                            have designed this version of the GPL to prohibit the practice for those
                            products.  If such problems arise substantially in other domains, we
                            stand ready to extend this provision to those domains in future versions
                            of the GPL, as needed to protect the freedom of users.
                            <br />
                              Finally, every program is threatened constantly by software patents.
                            States should not allow patents to restrict development and use of
                            software on general-purpose computers, but in those that do, we wish to
                            avoid the special danger that patents applied to a free program could
                            make it effectively proprietary.  To prevent this, the GPL assures that
                            patents cannot be used to render the program non-free.
                            <br />
                              The precise terms and conditions for copying, distribution and
                            modification follow.
                            <br />
                                                   TERMS AND CONDITIONS
                            <br />
                              0. Definitions.
                            <br />
                              "This License" refers to version 3 of the GNU General Public License.
                            <br />
                              "Copyright" also means copyright-like laws that apply to other kinds of
                            works, such as semiconductor masks.
                            <br />
                              "The Program" refers to any copyrightable work licensed under this
                            License.  Each licensee is addressed as "you".  "Licensees" and
                            "recipients" may be individuals or organizations.
                            <br />
                              To "modify" a work means to copy from or adapt all or part of the work
                            in a fashion requiring copyright permission, other than the making of an
                            exact copy.  The resulting work is called a "modified version" of the
                            earlier work or a work "based on" the earlier work.
                            <br />
                              A "covered work" means either the unmodified Program or a work based
                            on the Program.
                            <br />
                              To "propagate" a work means to do anything with it that, without
                            permission, would make you directly or secondarily liable for
                            infringement under applicable copyright law, except executing it on a
                            computer or modifying a private copy.  Propagation includes copying,
                            distribution (with or without modification), making available to the
                            public, and in some countries other activities as well.
                            <br />
                              To "convey" a work means any kind of propagation that enables other
                            parties to make or receive copies.  Mere interaction with a user through
                            a computer network, with no transfer of a copy, is not conveying.
                            <br />
                              An interactive user interface displays "Appropriate Legal Notices"
                            to the extent that it includes a convenient and prominently visible
                            feature that (1) displays an appropriate copyright notice, and (2)
                            tells the user that there is no warranty for the work (except to the
                            extent that warranties are provided), that licensees may convey the
                            work under this License, and how to view a copy of this License.  If
                            the interface presents a list of user commands or options, such as a
                            menu, a prominent item in the list meets this criterion.
                            <br />
                              1. Source Code.
                            <br />
                              The "source code" for a work means the preferred form of the work
                            for making modifications to it.  "Object code" means any non-source
                            form of a work.
                            <br />
                              A "Standard Interface" means an interface that either is an official
                            standard defined by a recognized standards body, or, in the case of
                            interfaces specified for a particular programming language, one that
                            is widely used among developers working in that language.
                            <br />
                              The "System Libraries" of an executable work include anything, other
                            than the work as a whole, that (a) is included in the normal form of
                            packaging a Major Component, but which is not part of that Major
                            Component, and (b) serves only to enable use of the work with that
                            Major Component, or to implement a Standard Interface for which an
                            implementation is available to the public in source code form.  A
                            "Major Component", in this context, means a major essential component
                            (kernel, window system, and so on) of the specific operating system
                            (if any) on which the executable work runs, or a compiler used to
                            produce the work, or an object code interpreter used to run it.
                            <br />
                              The "Corresponding Source" for a work in object code form means all
                            the source code needed to generate, install, and (for an executable
                            work) run the object code and to modify the work, including scripts to
                            control those activities.  However, it does not include the work's
                            System Libraries, or general-purpose tools or generally available free
                            programs which are used unmodified in performing those activities but
                            which are not part of the work.  For example, Corresponding Source
                            includes interface definition files associated with source files for
                            the work, and the source code for shared libraries and dynamically
                            linked subprograms that the work is specifically designed to require,
                            such as by intimate data communication or control flow between those
                            subprograms and other parts of the work.
                            <br />
                              The Corresponding Source need not include anything that users
                            can regenerate automatically from other parts of the Corresponding
                            Source.
                            <br />
                              The Corresponding Source for a work in source code form is that
                            same work.
                            <br />
                              2. Basic Permissions.
                            <br />
                              All rights granted under this License are granted for the term of
                            copyright on the Program, and are irrevocable provided the stated
                            conditions are met.  This License explicitly affirms your unlimited
                            permission to run the unmodified Program.  The output from running a
                            covered work is covered by this License only if the output, given its
                            content, constitutes a covered work.  This License acknowledges your
                            rights of fair use or other equivalent, as provided by copyright law.
                            <br />
                              You may make, run and propagate covered works that you do not
                            convey, without conditions so long as your license otherwise remains
                            in force.  You may convey covered works to others for the sole purpose
                            of having them make modifications exclusively for you, or provide you
                            with facilities for running those works, provided that you comply with
                            the terms of this License in conveying all material for which you do
                            not control copyright.  Those thus making or running the covered works
                            for you must do so exclusively on your behalf, under your direction
                            and control, on terms that prohibit them from making any copies of
                            your copyrighted material outside their relationship with you.
                            <br />
                              Conveying under any other circumstances is permitted solely under
                            the conditions stated below.  Sublicensing is not allowed; section 10
                            makes it unnecessary.
                            <br />
                              3. Protecting Users' Legal Rights From Anti-Circumvention Law.
                            <br />
                              No covered work shall be deemed part of an effective technological
                            measure under any applicable law fulfilling obligations under article
                            11 of the WIPO copyright treaty adopted on 20 December 1996, or
                            similar laws prohibiting or restricting circumvention of such
                            measures.
                            <br />
                              When you convey a covered work, you waive any legal power to forbid
                            circumvention of technological measures to the extent such circumvention
                            is effected by exercising rights under this License with respect to
                            the covered work, and you disclaim any intention to limit operation or
                            modification of the work as a means of enforcing, against the work's
                            users, your or third parties' legal rights to forbid circumvention of
                            technological measures.
                            <br />
                              4. Conveying Verbatim Copies.
                            <br />
                              You may convey verbatim copies of the Program's source code as you
                            receive it, in any medium, provided that you conspicuously and
                            appropriately publish on each copy an appropriate copyright notice;
                            keep intact all notices stating that this License and any
                            non-permissive terms added in accord with section 7 apply to the code;
                            keep intact all notices of the absence of any warranty; and give all
                            recipients a copy of this License along with the Program.
                            <br />
                              You may charge any price or no price for each copy that you convey,
                            and you may offer support or warranty protection for a fee.
                            <br />
                              5. Conveying Modified Source Versions.
                            <br />
                              You may convey a work based on the Program, or the modifications to
                            produce it from the Program, in the form of source code under the
                            terms of section 4, provided that you also meet all of these conditions:
                            <br />
                                a) The work must carry prominent notices stating that you modified
                                it, and giving a relevant date.
                            <br />
                                b) The work must carry prominent notices stating that it is
                                released under this License and any conditions added under section
                                7.  This requirement modifies the requirement in section 4 to
                                "keep intact all notices".
                            <br />
                                c) You must license the entire work, as a whole, under this
                                License to anyone who comes into possession of a copy.  This
                                License will therefore apply, along with any applicable section 7
                                additional terms, to the whole of the work, and all its parts,
                                regardless of how they are packaged.  This License gives no
                                permission to license the work in any other way, but it does not
                                invalidate such permission if you have separately received it.
                            <br />
                                d) If the work has interactive user interfaces, each must display
                                Appropriate Legal Notices; however, if the Program has interactive
                                interfaces that do not display Appropriate Legal Notices, your
                                work need not make them do so.
                            <br />
                              A compilation of a covered work with other separate and independent
                            works, which are not by their nature extensions of the covered work,
                            and which are not combined with it such as to form a larger program,
                            in or on a volume of a storage or distribution medium, is called an
                            "aggregate" if the compilation and its resulting copyright are not
                            used to limit the access or legal rights of the compilation's users
                            beyond what the individual works permit.  Inclusion of a covered work
                            in an aggregate does not cause this License to apply to the other
                            parts of the aggregate.
                            <br />
                              6. Conveying Non-Source Forms.
                            <br />
                              You may convey a covered work in object code form under the terms
                            of sections 4 and 5, provided that you also convey the
                            machine-readable Corresponding Source under the terms of this License,
                            in one of these ways:
                            <br />
                                a) Convey the object code in, or embodied in, a physical product
                                (including a physical distribution medium), accompanied by the
                                Corresponding Source fixed on a durable physical medium
                                customarily used for software interchange.
                            <br />
                                b) Convey the object code in, or embodied in, a physical product
                                (including a physical distribution medium), accompanied by a
                                written offer, valid for at least three years and valid for as
                                long as you offer spare parts or customer support for that product
                                model, to give anyone who possesses the object code either (1) a
                                copy of the Corresponding Source for all the software in the
                                product that is covered by this License, on a durable physical
                                medium customarily used for software interchange, for a price no
                                more than your reasonable cost of physically performing this
                                conveying of source, or (2) access to copy the
                                Corresponding Source from a network server at no charge.
                            <br />
                                c) Convey individual copies of the object code with a copy of the
                                written offer to provide the Corresponding Source.  This
                                alternative is allowed only occasionally and noncommercially, and
                                only if you received the object code with such an offer, in accord
                                with subsection 6b.
                            <br />
                                d) Convey the object code by offering access from a designated
                                place (gratis or for a charge), and offer equivalent access to the
                                Corresponding Source in the same way through the same place at no
                                further charge.  You need not require recipients to copy the
                                Corresponding Source along with the object code.  If the place to
                                copy the object code is a network server, the Corresponding Source
                                may be on a different server (operated by you or a third party)
                                that supports equivalent copying facilities, provided you maintain
                                clear directions next to the object code saying where to find the
                                Corresponding Source.  Regardless of what server hosts the
                                Corresponding Source, you remain obligated to ensure that it is
                                available for as long as needed to satisfy these requirements.
                            <br />
                                e) Convey the object code using peer-to-peer transmission, provided
                                you inform other peers where the object code and Corresponding
                                Source of the work are being offered to the general public at no
                                charge under subsection 6d.
                            <br />
                              A separable portion of the object code, whose source code is excluded
                            from the Corresponding Source as a System Library, need not be
                            included in conveying the object code work.
                            <br />
                              A "User Product" is either (1) a "consumer product", which means any
                            tangible personal property which is normally used for personal, family,
                            or household purposes, or (2) anything designed or sold for incorporation
                            into a dwelling.  In determining whether a product is a consumer product,
                            doubtful cases shall be resolved in favor of coverage.  For a particular
                            product received by a particular user, "normally used" refers to a
                            typical or common use of that class of product, regardless of the status
                            of the particular user or of the way in which the particular user
                            actually uses, or expects or is expected to use, the product.  A product
                            is a consumer product regardless of whether the product has substantial
                            commercial, industrial or non-consumer uses, unless such uses represent
                            the only significant mode of use of the product.
                            <br />
                              "Installation Information" for a User Product means any methods,
                            procedures, authorization keys, or other information required to install
                            and execute modified versions of a covered work in that User Product from
                            a modified version of its Corresponding Source.  The information must
                            suffice to ensure that the continued functioning of the modified object
                            code is in no case prevented or interfered with solely because
                            modification has been made.
                            <br />
                              If you convey an object code work under this section in, or with, or
                            specifically for use in, a User Product, and the conveying occurs as
                            part of a transaction in which the right of possession and use of the
                            User Product is transferred to the recipient in perpetuity or for a
                            fixed term (regardless of how the transaction is characterized), the
                            Corresponding Source conveyed under this section must be accompanied
                            by the Installation Information.  But this requirement does not apply
                            if neither you nor any third party retains the ability to install
                            modified object code on the User Product (for example, the work has
                            been installed in ROM).
                            <br />
                              The requirement to provide Installation Information does not include a
                            requirement to continue to provide support service, warranty, or updates
                            for a work that has been modified or installed by the recipient, or for
                            the User Product in which it has been modified or installed.  Access to a
                            network may be denied when the modification itself materially and
                            adversely affects the operation of the network or violates the rules and
                            protocols for communication across the network.
                            <br />
                              Corresponding Source conveyed, and Installation Information provided,
                            in accord with this section must be in a format that is publicly
                            documented (and with an implementation available to the public in
                            source code form), and must require no special password or key for
                            unpacking, reading or copying.
                            <br />
                              7. Additional Terms.
                            <br />
                              "Additional permissions" are terms that supplement the terms of this
                            License by making exceptions from one or more of its conditions.
                            Additional permissions that are applicable to the entire Program shall
                            be treated as though they were included in this License, to the extent
                            that they are valid under applicable law.  If additional permissions
                            apply only to part of the Program, that part may be used separately
                            under those permissions, but the entire Program remains governed by
                            this License without regard to the additional permissions.
                            <br />
                              When you convey a copy of a covered work, you may at your option
                            remove any additional permissions from that copy, or from any part of
                            it.  (Additional permissions may be written to require their own
                            removal in certain cases when you modify the work.)  You may place
                            additional permissions on material, added by you to a covered work,
                            for which you have or can give appropriate copyright permission.
                            <br />
                              Notwithstanding any other provision of this License, for material you
                            add to a covered work, you may (if authorized by the copyright holders of
                            that material) supplement the terms of this License with terms:
                            <br />
                                a) Disclaiming warranty or limiting liability differently from the
                                terms of sections 15 and 16 of this License; or
                            <br />
                                b) Requiring preservation of specified reasonable legal notices or
                                author attributions in that material or in the Appropriate Legal
                                Notices displayed by works containing it; or
                            <br />
                                c) Prohibiting misrepresentation of the origin of that material, or
                                requiring that modified versions of such material be marked in
                                reasonable ways as different from the original version; or
                            <br />
                                d) Limiting the use for publicity purposes of names of licensors or
                                authors of the material; or
                            <br />
                                e) Declining to grant rights under trademark law for use of some
                                trade names, trademarks, or service marks; or
                            <br />
                                f) Requiring indemnification of licensors and authors of that
                                material by anyone who conveys the material (or modified versions of
                                it) with contractual assumptions of liability to the recipient, for
                                any liability that these contractual assumptions directly impose on
                                those licensors and authors.
                            <br />
                              All other non-permissive additional terms are considered "further
                            restrictions" within the meaning of section 10.  If the Program as you
                            received it, or any part of it, contains a notice stating that it is
                            governed by this License along with a term that is a further
                            restriction, you may remove that term.  If a license document contains
                            a further restriction but permits relicensing or conveying under this
                            License, you may add to a covered work material governed by the terms
                            of that license document, provided that the further restriction does
                            not survive such relicensing or conveying.
                            <br />
                              If you add terms to a covered work in accord with this section, you
                            must place, in the relevant source files, a statement of the
                            additional terms that apply to those files, or a notice indicating
                            where to find the applicable terms.
                            <br />
                              Additional terms, permissive or non-permissive, may be stated in the
                            form of a separately written license, or stated as exceptions;
                            the above requirements apply either way.
                            <br />
                              8. Termination.
                            <br />
                              You may not propagate or modify a covered work except as expressly
                            provided under this License.  Any attempt otherwise to propagate or
                            modify it is void, and will automatically terminate your rights under
                            this License (including any patent licenses granted under the third
                            paragraph of section 11).
                            <br />
                              However, if you cease all violation of this License, then your
                            license from a particular copyright holder is reinstated (a)
                            provisionally, unless and until the copyright holder explicitly and
                            finally terminates your license, and (b) permanently, if the copyright
                            holder fails to notify you of the violation by some reasonable means
                            prior to 60 days after the cessation.
                            <br />
                              Moreover, your license from a particular copyright holder is
                            reinstated permanently if the copyright holder notifies you of the
                            violation by some reasonable means, this is the first time you have
                            received notice of violation of this License (for any work) from that
                            copyright holder, and you cure the violation prior to 30 days after
                            your receipt of the notice.
                            <br />
                              Termination of your rights under this section does not terminate the
                            licenses of parties who have received copies or rights from you under
                            this License.  If your rights have been terminated and not permanently
                            reinstated, you do not qualify to receive new licenses for the same
                            material under section 10.
                            <br />
                              9. Acceptance Not Required for Having Copies.
                            <br />
                              You are not required to accept this License in order to receive or
                            run a copy of the Program.  Ancillary propagation of a covered work
                            occurring solely as a consequence of using peer-to-peer transmission
                            to receive a copy likewise does not require acceptance.  However,
                            nothing other than this License grants you permission to propagate or
                            modify any covered work.  These actions infringe copyright if you do
                            not accept this License.  Therefore, by modifying or propagating a
                            covered work, you indicate your acceptance of this License to do so.
                            <br />
                              10. Automatic Licensing of Downstream Recipients.
                            <br />
                              Each time you convey a covered work, the recipient automatically
                            receives a license from the original licensors, to run, modify and
                            propagate that work, subject to this License.  You are not responsible
                            for enforcing compliance by third parties with this License.
                            <br />
                              An "entity transaction" is a transaction transferring control of an
                            organization, or substantially all assets of one, or subdividing an
                            organization, or merging organizations.  If propagation of a covered
                            work results from an entity transaction, each party to that
                            transaction who receives a copy of the work also receives whatever
                            licenses to the work the party's predecessor in interest had or could
                            give under the previous paragraph, plus a right to possession of the
                            Corresponding Source of the work from the predecessor in interest, if
                            the predecessor has it or can get it with reasonable efforts.
                            <br />
                              You may not impose any further restrictions on the exercise of the
                            rights granted or affirmed under this License.  For example, you may
                            not impose a license fee, royalty, or other charge for exercise of
                            rights granted under this License, and you may not initiate litigation
                            (including a cross-claim or counterclaim in a lawsuit) alleging that
                            any patent claim is infringed by making, using, selling, offering for
                            sale, or importing the Program or any portion of it.
                            <br />
                              11. Patents.
                            <br />
                              A "contributor" is a copyright holder who authorizes use under this
                            License of the Program or a work on which the Program is based.  The
                            work thus licensed is called the contributor's "contributor version".
                            <br />
                              A contributor's "essential patent claims" are all patent claims
                            owned or controlled by the contributor, whether already acquired or
                            hereafter acquired, that would be infringed by some manner, permitted
                            by this License, of making, using, or selling its contributor version,
                            but do not include claims that would be infringed only as a
                            consequence of further modification of the contributor version.  For
                            purposes of this definition, "control" includes the right to grant
                            patent sublicenses in a manner consistent with the requirements of
                            this License.
                            <br />
                              Each contributor grants you a non-exclusive, worldwide, royalty-free
                            patent license under the contributor's essential patent claims, to
                            make, use, sell, offer for sale, import and otherwise run, modify and
                            propagate the contents of its contributor version.
                            <br />
                              In the following three paragraphs, a "patent license" is any express
                            agreement or commitment, however denominated, not to enforce a patent
                            (such as an express permission to practice a patent or covenant not to
                            sue for patent infringement).  To "grant" such a patent license to a
                            party means to make such an agreement or commitment not to enforce a
                            patent against the party.
                            <br />
                              If you convey a covered work, knowingly relying on a patent license,
                            and the Corresponding Source of the work is not available for anyone
                            to copy, free of charge and under the terms of this License, through a
                            publicly available network server or other readily accessible means,
                            then you must either (1) cause the Corresponding Source to be so
                            available, or (2) arrange to deprive yourself of the benefit of the
                            patent license for this particular work, or (3) arrange, in a manner
                            consistent with the requirements of this License, to extend the patent
                            license to downstream recipients.  "Knowingly relying" means you have
                            actual knowledge that, but for the patent license, your conveying the
                            covered work in a country, or your recipient's use of the covered work
                            in a country, would infringe one or more identifiable patents in that
                            country that you have reason to believe are valid.
                            <br />
                              If, pursuant to or in connection with a single transaction or
                            arrangement, you convey, or propagate by procuring conveyance of, a
                            covered work, and grant a patent license to some of the parties
                            receiving the covered work authorizing them to use, propagate, modify
                            or convey a specific copy of the covered work, then the patent license
                            you grant is automatically extended to all recipients of the covered
                            work and works based on it.
                            <br />
                              A patent license is "discriminatory" if it does not include within
                            the scope of its coverage, prohibits the exercise of, or is
                            conditioned on the non-exercise of one or more of the rights that are
                            specifically granted under this License.  You may not convey a covered
                            work if you are a party to an arrangement with a third party that is
                            in the business of distributing software, under which you make payment
                            to the third party based on the extent of your activity of conveying
                            the work, and under which the third party grants, to any of the
                            parties who would receive the covered work from you, a discriminatory
                            patent license (a) in connection with copies of the covered work
                            conveyed by you (or copies made from those copies), or (b) primarily
                            for and in connection with specific products or compilations that
                            contain the covered work, unless you entered into that arrangement,
                            or that patent license was granted, prior to 28 March 2007.
                            <br />
                              Nothing in this License shall be construed as excluding or limiting
                            any implied license or other defenses to infringement that may
                            otherwise be available to you under applicable patent law.
                            <br />
                              12. No Surrender of Others' Freedom.
                            <br />
                              If conditions are imposed on you (whether by court order, agreement or
                            otherwise) that contradict the conditions of this License, they do not
                            excuse you from the conditions of this License.  If you cannot convey a
                            covered work so as to satisfy simultaneously your obligations under this
                            License and any other pertinent obligations, then as a consequence you may
                            not convey it at all.  For example, if you agree to terms that obligate you
                            to collect a royalty for further conveying from those to whom you convey
                            the Program, the only way you could satisfy both those terms and this
                            License would be to refrain entirely from conveying the Program.
                            <br />
                              13. Use with the GNU Affero General Public License.
                            <br />
                              Notwithstanding any other provision of this License, you have
                            permission to link or combine any covered work with a work licensed
                            under version 3 of the GNU Affero General Public License into a single
                            combined work, and to convey the resulting work.  The terms of this
                            License will continue to apply to the part which is the covered work,
                            but the special requirements of the GNU Affero General Public License,
                            section 13, concerning interaction through a network will apply to the
                            combination as such.
                            <br />
                              14. Revised Versions of this License.
                            <br />
                              The Free Software Foundation may publish revised and/or new versions of
                            the GNU General Public License from time to time.  Such new versions will
                            be similar in spirit to the present version, but may differ in detail to
                            address new problems or concerns.
                            <br />
                              Each version is given a distinguishing version number.  If the
                            Program specifies that a certain numbered version of the GNU General
                            Public License "or any later version" applies to it, you have the
                            option of following the terms and conditions either of that numbered
                            version or of any later version published by the Free Software
                            Foundation.  If the Program does not specify a version number of the
                            GNU General Public License, you may choose any version ever published
                            by the Free Software Foundation.
                            <br />
                              If the Program specifies that a proxy can decide which future
                            versions of the GNU General Public License can be used, that proxy's
                            public statement of acceptance of a version permanently authorizes you
                            to choose that version for the Program.
                            <br />
                              Later license versions may give you additional or different
                            permissions.  However, no additional obligations are imposed on any
                            author or copyright holder as a result of your choosing to follow a
                            later version.
                            <br />
                              15. Disclaimer of Warranty.
                            <br />
                              THERE IS NO WARRANTY FOR THE PROGRAM, TO THE EXTENT PERMITTED BY
                            APPLICABLE LAW.  EXCEPT WHEN OTHERWISE STATED IN WRITING THE COPYRIGHT
                            HOLDERS AND/OR OTHER PARTIES PROVIDE THE PROGRAM "AS IS" WITHOUT WARRANTY
                            OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO,
                            THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
                            PURPOSE.  THE ENTIRE RISK AS TO THE QUALITY AND PERFORMANCE OF THE PROGRAM
                            IS WITH YOU.  SHOULD THE PROGRAM PROVE DEFECTIVE, YOU ASSUME THE COST OF
                            ALL NECESSARY SERVICING, REPAIR OR CORRECTION.
                            <br />
                              16. Limitation of Liability.
                            <br />
                              IN NO EVENT UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING
                            WILL ANY COPYRIGHT HOLDER, OR ANY OTHER PARTY WHO MODIFIES AND/OR CONVEYS
                            THE PROGRAM AS PERMITTED ABOVE, BE LIABLE TO YOU FOR DAMAGES, INCLUDING ANY
                            GENERAL, SPECIAL, INCIDENTAL OR CONSEQUENTIAL DAMAGES ARISING OUT OF THE
                            USE OR INABILITY TO USE THE PROGRAM (INCLUDING BUT NOT LIMITED TO LOSS OF
                            DATA OR DATA BEING RENDERED INACCURATE OR LOSSES SUSTAINED BY YOU OR THIRD
                            PARTIES OR A FAILURE OF THE PROGRAM TO OPERATE WITH ANY OTHER PROGRAMS),
                            EVEN IF SUCH HOLDER OR OTHER PARTY HAS BEEN ADVISED OF THE POSSIBILITY OF
                            SUCH DAMAGES.
                            <br />
                              17. Interpretation of Sections 15 and 16.
                            <br />
                              If the disclaimer of warranty and limitation of liability provided
                            above cannot be given local legal effect according to their terms,
                            reviewing courts shall apply local law that most closely approximates
                            an absolute waiver of all civil liability in connection with the
                            Program, unless a warranty or assumption of liability accompanies a
                            copy of the Program in return for a fee.
                            <br />
                         END OF TERMS AND CONDITIONS
                        </div>


                        <div id="DotNetZipLicense" style="display: none;">
                            Microsoft Public License (Ms-PL)
                            <br />

                            This license governs use of the accompanying software, the DotNetZip library ("the software"). If you use the software, you accept this license. If you do not accept the license, do not use the software.
                            <br />

                            1. Definitions
                            <br />

                            The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
                            <br />

                            A "contribution" is the original software, or any additions or changes to the software.
                            <br />

                            A "contributor" is any person that distributes its contribution under this license.
                            <br />

                            "Licensed patents" are a contributor's patent claims that read directly on its contribution.
                            <br />

                            2. Grant of Rights
                            <br />

                            (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
                            <br />

                            (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
                            <br />

                            3. Conditions and Limitations
                            <br />

                            (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
                            <br />

                            (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
                            <br />

                            (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
                            <br />

                            (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
                            <br />

                            (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement. 
                            <br />


                        </div>
                        <div id="DotNetOpenAuth.AspNetLicense" style="display: none;">
                            Microsoft Public License (MS-PL)
                            <br />
                            This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
                            <br />

                            1. Definitions
                            The terms "reproduce," "reproduction," "derivative works," and "distribution" have the
                            same meaning here as under U.S. copyright law.
                            <br />

                            A "contribution" is the original software, or any additions or changes to the software.
                            <br />

                            A "contributor" is any person that distributes its contribution under this license.
                            <br />

                            "Licensed patents" are a contributor's patent claims that read directly on its contribution.
                            <br />

                            2. Grant of Rights
                            <br />

                            (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
                            <br />

                            (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
                            <br />

                            3. Conditions and Limitations
                            <br />

                            (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
                            <br />

                            (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
                            <br />

                            (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
                            <br />

                            (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
                            <br />

                            (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
                            <br />
                        </div>
                        <div id="Ionic_Zip_DotNetZipLicense" style="display: none;">
                            Microsoft Public License (MS-PL)
                            <br />
                            This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
                            <br />

                            1. Definitions
                            The terms "reproduce," "reproduction," "derivative works," and "distribution" have the
                            same meaning here as under U.S. copyright law.
                            <br />

                            A "contribution" is the original software, or any additions or changes to the software.
                            <br />

                            A "contributor" is any person that distributes its contribution under this license.
                            <br />

                            "Licensed patents" are a contributor's patent claims that read directly on its contribution.
                            <br />

                            2. Grant of Rights
                            <br />

                            (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
                            <br />

                            (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
                            <br />

                            3. Conditions and Limitations
                            <br />

                            (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
                            <br />

                            (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
                            <br />

                            (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
                            <br />

                            (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
                            <br />

                            (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
                            <br />
                        </div>


                        <div id="AntlrLicense" style="display: none;">
                            ANTLR 4 License
                            <br />
                            [The BSD License]
                            <br />
                            Copyright (c) 2012 Terence Parr and Sam Harwell
                            <br />
                            All rights reserved.
                            <br />
                            Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
                            <br />

                            Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
                            <br />
                            Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
                            <br />
                            Neither the name of the author nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
                            <br />
                            THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
                            <br />
                        </div>
                        <div id="MyGenerationLicense" style="display: none;">
                            Copyright (c) 2008, MyGeneration Software
                            <br />
                            All rights reserved.
                            <br />

                            Redistribution and use in source and binary forms, with or without
                            modification, are permitted provided that the following conditions are met:
                            <br />

                            * Redistributions of source code must retain the above copyright notice, this
                              list of conditions and the following disclaimer.
                            <br />

                            * Redistributions in binary form must reproduce the above copyright notice,
                              this list of conditions and the following disclaimer in the documentation
                              and/or other materials provided with the distribution.
                            <br />

                            * Neither the name of the copyright holder nor the names of its
                              contributors may be used to endorse or promote products derived from
                              this software without specific prior written permission.
                            <br />

                            THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
                            AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
                            IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
                            DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
                            FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
                            DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
                            SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
                            CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
                            OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
                            OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
                        </div>


                    </td>
                </tr>
            </table>
            <script>
                var licenseShowing = false;
                function showLicense(id) {
                    var lic;
                    lic = $("#" + id + "License").html();
                    $("#licenseDiv").html(lic);
                }
            </script>
        </fieldset>
        <fieldset style="background: #ffffff !important;">
            <legend><image src="Images/Logos/pdftron_logo.png" title="PDFTron™ Systems Inc." /></legend>
            <div style="width: 100%;">
                PDF technology powered by PDFTron WebViewer SDK copyright © PDFTron™ Systems Inc., 2001-<%= Now.Date.Year %>,
and distributed by The Advantage Software Company, LLC under license. All rights reserved.
            </div>
            <div style="width: 100%; text-align: right; display: none !important;">
                <image src="Images/Logos/pdftron_logo.png" />
            </div>
        </fieldset>
        <fieldset style="background: #ffffff !important;">
            <legend>Notice</legend>This computer program is protected by copyright law and international
            treaties. Unauthorized reproduction or distribution of this program, or portions
            of it, may result in severe civil and criminal penalties. Violations will be prosecuted
            to the maximum extent possible under the law.
        </fieldset>
        <fieldset runat="server" id="FieldsetTestEmail" style="background: #ffffff !important;">
            <legend>Test Email and SMTP Settings</legend>
            <table border="0" cellpadding="0" cellspacing="2">
                <tr>
                    <td align="right" valign="bottom" width="165">
                        &nbsp;
                    </td>
                    <td width="255">
                        Use:<asp:RadioButtonList ID="RadioButtonListUseSettings" runat="server" AutoPostBack="true">
                            <Items>
                                <asp:ListItem Value="0" Text="Database SMTP Settings">
                                </asp:ListItem>
                                <asp:ListItem Value="1" Text="Manual SMTP Settings">
                                </asp:ListItem>
                            </Items>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="bottom">
                        Server:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTestEmailServer" runat="server" CssClass="RequiredInput" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        User Name:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTestEmailUsername" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                            Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        Password:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTestEmailPassword" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                            Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        E-mail Address (Send to):
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxTestEmailTo" runat="server" CssClass="RequiredInput" Width="250px" SkinID="TextBoxStandard"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="ButtonTestEmail" runat="server" CausesValidation="False" Text="Send Test Email" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelEmailSettings" runat="server"></asp:Label>
                        <asp:Label ID="LabelEmailResults" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
       </fieldset>
        <div class="centered" style="margin-top: 20px;">
            <div><asp:Image ID="ImageLogo" ImageAlign="Top" runat="server" Visible="false" /></div>
            <div style="cursor: help;"><image src="Images/Logos/adv_logo.png" title="The Advantage Software Company" onclick="window.open('http://www.gotoadvantage.com/', '_blank')" /></div>
            <div title="powered by">powered by</div>
            <div style="cursor: help;"><image src="Images/Logos/simplifi_logo.png" title="Simpli.fi" onclick="window.open('https://simpli.fi/', '_blank')" /></div>
            <div>Copyright ©, <%= Now.Date.Year %></div>
        </div>
    </div>

</asp:Content>
