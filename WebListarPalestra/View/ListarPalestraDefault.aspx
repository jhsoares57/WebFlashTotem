<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPalestraDefault.aspx.cs" Inherits="WebListarPalestra.View.ListarPalestraDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   <%-- <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div >
                    <asp:Label ID="lblPalestra" runat="server" Text="Tipo de Palestra:"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                </div>
                <br />
                <div >
                    <asp:DropDownList ID="ddlPesquisa" runat="server">
                        <asp:ListItem Value="0" Text="Todas"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Saúde"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Jurídica"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Financeira"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <asp:GridView ID="gvListaPalestra" runat="server" HeaderStyle-BackColor="Salmon" AutoGenerateColumns="false" OnRowDataBound="gvListaPalestra_RowDataBound" Width="1025px">
                    <Columns>
                        <%--<asp:BoundField HeaderText="Código" DataField="Id" />--%>
                        <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                        <asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                        <asp:BoundField HeaderText="Palestrante" DataField="Palestrante" />
                        <asp:BoundField HeaderText="Data" DataField="Data" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
