<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="WebTotem.View.CadastrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<script type="text/javascript">
    function mensagemErro() {
        window.alert("Confirmação de senha inválida!")
    }

    function mensagemSucesso() {
        window.alert("Usuário salvo com sucesso!")
    }
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="col-md-12">
                <div class="panel panel-danger">
                    <div class="panel-heading">Cadastro de Usuário</div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label1" runat="server" Text="Usuário:"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtSenha" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="Label3" runat="server" Text="Confirmar Senha:"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtConfirmarSenha" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label runat="server" Text="Perfil"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlPerfil" runat="server">
                                        <asp:ListItem Text="---Selecione---" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Gestor" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Usuário Comum" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <asp:LinkButton ID="btnSalvar" class="btn btn-danger form-control"
                                        runat="server" Width="400px" OnClick="btnSalvar_Click">                    
                                        <i class="glyphicon glyphicon-floppy-disk"></i>&nbsp;Salvar                    
                                    </asp:LinkButton>
                                </div>
                                <div class="col-md-6">
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
