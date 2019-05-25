<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcessoWeb.aspx.cs" Inherits="WebTotem.View.AcessoWeb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
     
        .auto-style1 {
            width: 471px;
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
        }
     
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="auto-style1">
                <div class="form-login" >
                    <div class="panel panel-danger">
                        <div class="panel-heading">
                            <div class="panel-title">Login do Sistema</div>
                        </div>
                        <div style="padding-top: 30px" class="panel-body">
                            <div style="display: none" id="result" class="alert 
                    alert-danger col-sm-12">
                            </div>
                            <div align="center">
                                <asp:Label ID="Label1" runat="server" Text="Usuário:" Font-Size="Medium"></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control " border-radius="24px" placeholder="Usuario"></asp:TextBox>
                                </div>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Senha:" Font-Size="Medium" ></asp:Label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control input_pass" border-radius="24px" placeholder="Senha" Type="password" Style="left: 0px; top: 0px"></asp:TextBox>
                                </div>
                                <br />
                                <div class="input-group">
                                    <asp:LinkButton ID="btnAcessar" runat="server" CssClass="btn btn-danger form-control" OnClick="btnAcessar_Click" style="left: 0px; top: 0px; width: 125%">Acessar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
