<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SessionRefresh.aspx.vb" Inherits="Webvantage.SessionRefresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Webvantage Refresh</title>
        <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
        <meta id="MetaRefresh" http-equiv="refresh" content="21600;url=SessionRefresh.aspx" runat="server" />
        <script type="text/javascript">
            window.status = "<%=WindowStatusText%>";
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
