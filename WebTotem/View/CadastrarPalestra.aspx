<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarPalestra.aspx.cs" Inherits="WebTotem.View.CadastrarPalestra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
</head>
<script type="text/javascript">
    jQuery(function ($) {
        $("#txtData").mask("99/99/9999");
        $("#txtHora").mask('00:00');
    });
    function ChamarFecharPopUp() {
        parent.FecharPopUP();
    }
    function ChamarExibirMensagemErro(msg) {
        parent.ExibirMensagemErro(msg);
    }
    function ChamarExibirMensagemSucesso(msg) {
        parent.ChamarExibirMensagemSucesso(msg);
    }
    function mensagem() {
        window.alert("Registro Salvo com sucesso!")
    }


    function mensagemUPDT() {
        window.alert("Registro atualizado com sucesso!")
    }

    function EditarPessoa(id, nome) {
        var url = 'LancarSecao.aspx?PalestraId=' + id;
        $("#frmModalUrl").attr("src", url);
        $("#frmModal").modal();
        return false;
    }

</script>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="col-md-12">
                <div class="panel panel-danger">
                    <div class="panel-heading">FlashTotem</div>
                    <div class="panel-body">
                        <h1>Cadastro de Palestra</h1>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblIdPalestra" runat="server" Text="Código"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtCodigo" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="col-md-8">
                                <asp:HiddenField ID="hdnIDPessoa" runat="server" />
                            </div>
                            <br />
                            <div class="col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Tipo de área sa palestra"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlTipoPalestra" runat="server">
                                    <asp:ListItem Value="0" Text="Selecione" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Saúde"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Jurídica"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Financeira"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-6">
                                <asp:Label ID="lblTitulo" runat="server" Text="Título da Palestra:"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDescricao" runat="server" Width="717px"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblPalestrabte" runat="server" Text="Palestrante:"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtPalestrante" runat="server" Width="345px"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblData" runat="server" Text="Data da Palestra:"></asp:Label>
                                &nbsp
                            &nbsp
                            &nbsp
                            &nbsp
                            <asp:Label ID="lblHora" runat="server" Text="Horário da Palestra:"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
                                &nbsp
                            &nbsp
                            
                            <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:LinkButton ID="btnSalvar" class="btn btn-danger form-control"
                                        runat="server" Width="717px" OnClick="btnSalvar_Click">                    
                            <i class="glyphicon glyphicon-floppy-disk"></i>&nbsp;Salvar                    
                                    </asp:LinkButton>
                                </div>
                                <div class="col-md-8">
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
