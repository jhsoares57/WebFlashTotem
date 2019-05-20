<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarPalestra.aspx.cs" Inherits="WebTotem.View.ListarPalestra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        //Cadastrar Palestra
        function CadastrarPalestra() {
            var url = 'CadastrarPalestra.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

         function CadastrarUser() {
            var url = 'CadastrarUsuario.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

        //Edição da Palestra
        function EditarPalestra(id) {
            var url = 'CadastrarPalestra.aspx?PalestraId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

       <%-- //Excluir Palestra
        function ExcluirPessoa(id) {
            bootbox.confirm({
                message: "Deseja realmente excluir esta pessoa?",
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    //console.log('This was logged in the callback: ' + result);
                    if (result) {
                        $("#<%=hdnId.ClientID%>").val(id);
                        $("#<%=btnExcluir.ClientID%>").click();
                    }
                }
            });

        }

        //Fechar PopUp Atualizando GridView
        function FecharPopUp() {
            $("#frmModalUrl").attr("src", "about:blank");
            $("#frmModal").modal('hide');

            $("#<%=btnCarregarPessoas.ClientID%>").click();
        }

        //http://jsfiddle.net/ddan/jx1f4grL/
        //https://codeseven.github.io/toastr/demo.html
        //http://bootboxjs.com/examples.html#bb-alert-dialog
}
        //Exibir Mensagem de erro
        function ExibirMensagemErro(msg) {
            // make it not dissappear
            toastr.error(msg, "Cadastro de Pessoas informa:", {
                //"timeOut": "0",
                "extendedTImeout": "0",
                "progressBar": true
            });
        }

        //Exibir Mensagem de sucesso
        function ExibirMensagemSucesso(msg) {
            // make it not dissappear
            toastr.success(msg, "Cadastro de Pessoas informa:", {
                //"timeOut": "0",
                "extendedTImeout": "0",
                "progressBar": true
            });
        }--%>

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">

        <div class="panel panel-danger">
            <div class="panel-heading">Lista de Palestras</div>
            <div class="panel-body">
                <div class="container">

                    <div style="visibility: hidden;">
                        <asp:Button ID="btnCarregarPessoas" runat="server" Text="Carregar Pessoas" OnClick="btnCarregarPessoas_Click" />
                        <asp:Button ID="btnExcluir" runat="server" Text="Excluir Pessoa" OnClick="btnExcluir_Click" />
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                    <!--Inicio do Modal-->
                    <div id="frmModal" class="modal fade" role="dialog">
                        <div class="modal-dialog modal-lg">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div>
                                    <iframe src="javascript:" id="frmModalUrl" frameborder="0" class="frame-param" style="border: 0; width: 900px; height: 530px"
                                        scrolling="auto" marginheight="0" marginwidth="0"></iframe>

                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Fechar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4">
                            <button type="button" name="btnNovo" id="btnNovo" class="btn btn-danger form-control"
                                value="Nova Palestra" onclick="CadastrarPalestra()">
                                <i class="glyphicon glyphicon-pencil"></i>&nbsp;Novo 
                            </button>
                            &nbsp;
                            &nbsp;
                          
                            <br />
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:GridView ID="gvPalestra" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvCadastroPessoa_RowDataBound"  Width="815px">
                                        <Columns>
                                            <asp:BoundField HeaderText="Código" DataField="Id" />
                                            <asp:BoundField HeaderText="Titulo da Palestra" DataField="Titulo" />
                                            <asp:BoundField HeaderText="Palestrante" DataField="Palestrante" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Panel ID="pnlEditar" runat="server">
                                                        <button class="btn btn-warning btn-sm" title="Alterar Palestra" style="height: 30px"
                                                            type="button" onclick='EditarPalestra(<%# Eval("Id") %>); return false;'>

                                                            <i class="glyphicon glyphicon-pencil"></i>
                                                        </button>
                                                    </asp:Panel>
                                                   

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
