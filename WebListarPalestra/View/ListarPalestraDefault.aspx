<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPalestraDefault.aspx.cs" Inherits="WebListarPalestra.View.ListarPalestraDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
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
