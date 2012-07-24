<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Client.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style title="Default" media="screen" type="text/css">
        #center {width:200px; height:100px; position:absolute; top:50%; left:50%; margin:-50px auto auto -100px; border:1px solid black; text-align:center;}
</style>
</head>
<body>
    <form id="formLogin" runat="server">
    <div id="center">
    <span>
        Enter Shop Name:
        <asp:TextBox runat="server" ID="txbName" autofocus></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvName" ControlToValidate="txbName">*</asp:RequiredFieldValidator>
        <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Monitor" />
    </span>
    </div>
    <%--<div id="silverlightControlHost">
        <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
            width="100%" height="100%">
            <param name="source" value="ClientBin/ClientDefault.xap" />
            <param name="onError" value="onSilverlightError" />
            <param name="background" value="white" />
            <param name="minRuntimeVersion" value="5.0.60401.0" />
            <param name="autoUpgrade" value="true" />
            <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=5.0.60401.0" style="text-decoration: none">
                <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight"
                    style="border-style: none" />
            </a>
        </object>
        <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
            border: 0px"></iframe>
    </div>--%>
    </form>
</body>
</html>
