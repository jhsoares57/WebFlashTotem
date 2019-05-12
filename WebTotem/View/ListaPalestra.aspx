<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPalestra.aspx.cs" Inherits="WebTotem.View.ListaPalestra" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //Cadastro da Palestra
        function CadastrarPalestra() {
            var url = 'CadastrarPalestra.aspx';
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

        function CadastroContato(id) {
            var url = 'CadastroContato.aspx?PessoaId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

        //Edição da Palestra
        function EditarPessoa(id) {
            var url = 'CadastroPessoa.aspx?PessoaId=' + id;
            $("#frmModalUrl").attr("src", url);
            $("#frmModal").modal();
            return false;
        }

        

    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="container">
        <!--Abaixo do context de conteúdo -->
        <div style="visibility: hidden;">
            <asp:Button ID="btnCarregarPessoas" runat="server" Text="Carregar Pessoas" OnClick="btnCarregarPessoas_Click" />
            <asp:Button ID="btnExcluir" runat="server" Text="Excluir Pessoa" OnClick="btnExcluir_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>

        <div id="frmModal" class="modal fade" role="dialog">
            <div class="modal-dialog modal-lg">
                <!-- Modal content-->
                <div class="modal-content">
                    <div>
                        <iframe src="javascript:" id="frmModalUrl" frameborder="0" class="frame-param" style="border: 0; width: 800px; height: 600px"
                            scrolling="auto" marginheight="0" marginwidth="0"></iframe>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Fechar</button>
                    </div>
                </div>
            </div>
        </div>

        <h1>Lista Pessoa</h1>
        <div class="row">
            <div class="col-md-4">
                <button type="button" name="btnNovo" id="btnNovo" class="btn btn-primary form-control"
                    value="Novo" onclick="CadastrarPalestra()">
                    <i class="glyphicon glyphicon-pencil"></i>&nbsp;Novo 
                </button>

                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvListaPalestra" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvListaPalestra_RowDataBound">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="Id" />
                                <asp:BoundField HeaderText="Titulo da Palestra" DataField="Titulo" />
                                <asp:BoundField HeaderText="Palestrante" DataField="Palestrante" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlEditar" runat="server">
                                            <button class="btn btn-warning btn-sm" title="Editar Palestra" style="height: 30px"
                                                type="button" onclick='EditarPessoa(<%# Eval("Id") %>); return false;'>

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

</asp:Content>
