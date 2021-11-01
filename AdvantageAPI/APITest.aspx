<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="APITest.aspx.vb" Inherits="AdvantageAPI.APITest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Advantage API</title>
    
    <link rel="stylesheet" href="Content/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
        
    <script src="Content/js/jquery.min.js"></script>
    <script src="Content/js/bootstrap.min.js"></script>
    
    <script>

        function getAllParameters() {
            var query = $('#DropDownListMethodList').val() + '?';
            $('#ParameterList tbody input[type=text], #ParameterList tbody select').each(function () {
                var propName;
                var propValue;
                propName = $(this).attr('name');
                propValue = $(this).val();
                if (propName) {
                    query += propName + '=' + propValue + '&';
                }
            });
            if (query) {
                $('input[name=TestButton]').prop('disabled', true);
                $('#messageCenter').html('');
                $('#loader').show();
                $('#divURL').hide();
                $('#divResults').hide();
                var fullURL = location.href.substring(0, location.href.lastIndexOf("/") + 1) + 'APIService.svc/REST/' + query;
                fullURL = fullURL.substring(0, fullURL.length - 1);
                $.ajax({
                    url: fullURL,
                    complete: function () {
                        $('#loader').hide();
                        $('input[name=TestButton]').prop('disabled', false);
                    },
                    error: function (data) {
                        var message = $(data.responseText).filter('title').text();
                        var alertHTML = '<div class="alert alert-danger">' +
			                            '   <span>' + message + '</span>' +
			                            '   <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> ' +
		                                '</div>';
                        $('#messageCenter').html(alertHTML);
                    }
                })
                .then(function (data) {
                    $('#divURL').show();
                    $('#divResults').show();
                    $('#url').html(fullURL);
                    $('#results').html(JSON.stringify(data, null, 2));
                });
            }
        }

        $(document).ready(function () {
            $('#TestButton').click(function () {
                getAllParameters();
            });
            $('#divURL').hide();
            $('#divResults').hide();
            $('#loader').hide();
        });

        function forceNumeric() {
            return event.charCode >= 48 && event.charCode <= 57;
        }

    </script>

    <style type="text/css">
        div.content {
            width: 950px;
            margin: 10px auto;
        }
        div.pre {
            margin-top: 20px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" role="form">
    <div class="content">

        <div class="form-group">
            <label for="DropDownListMethodList">Select Method:</label>
            <asp:DropDownList ID="DropDownListMethodList" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="something">Parameters:</label>
            <asp:Table ID="ParameterList" runat="server" CssClass="table table-striped">
                <asp:TableHeaderRow TableSection="TableHeader">
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Value</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>ServerName</asp:TableCell>
                    <asp:TableCell>System.String</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="ServerName" runat="server" ClientIDMode="Static" CssClass="form-control" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>DatabaseName</asp:TableCell>
                    <asp:TableCell>System.String</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="DatabaseName" runat="server" ClientIDMode="Static" CssClass="form-control" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>UseWindowsAuthentication</asp:TableCell>
                    <asp:TableCell>System.Integer</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="UseWindowsAuthentication" runat="server" onkeypress="return forceNumeric()" ClientIDMode="Static" CssClass="form-control" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>UserName</asp:TableCell>
                    <asp:TableCell>System.String</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="UserName" runat="server" ClientIDMode="Static" CssClass="form-control" /></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Password</asp:TableCell>
                    <asp:TableCell>System.String</asp:TableCell>
                    <asp:TableCell><asp:TextBox ID="Password" runat="server" ClientIDMode="Static" CssClass="form-control" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>            
        </div>
        <input type="button" name="TestButton" id="TestButton" value="Test API" class="btn btn-primary btn-lg btn-block" />
        <div style="height:20px;"></div>
        
        <div id="messageCenter">

        </div>
		
        <div class="panel panel-default" id="divURL">
            <div class="panel-heading">URL</div>
            <div class="panel-body"><pre id="url"></pre></div>
        </div>

        <div class="panel panel-default" id="divResults">
            <div class="panel-heading">Results</div>
            <div class="panel-body"><pre id="results"></pre></div>
        </div>

        <div style="text-align:center;" id="loader">
            <span class="fa fa-refresh fa-spin" style="font-size:100px; text-align:center;"></span>
        </div>

    </div>
    </form>
</body>
</html>
