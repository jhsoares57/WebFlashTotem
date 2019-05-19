<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPalestraDefault.aspx.cs" Inherits="WebListarPalestra.View.ListarPalestraDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-top: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="row">
                 

                <asp:GridView ID="gvListaPalestra" runat="server" HeaderStyle-BackColor="#BE7DFF" AutoGenerateColumns="false" OnRowDataBound="gvListaPalestra_RowDataBound" Width="1025px"  CellPadding="10" Font-Bold="False" Font-Size="Large" Font-Strikeout="False"  GridLines="Horizontal" Font-Overline="False" Font-Italic="False" CssClass="auto-style1" Font-Names="sans-serif">
                    <Columns>
                        <asp:BoundField HeaderText="Titulo" DataField="Titulo" />
                        <asp:BoundField HeaderText="Descrição" DataField="Descricao" />
                        <asp:BoundField HeaderText="Palestrante" DataField="Palestrante" />
                        <asp:BoundField HeaderText="Local" DataField="LocalPalestra" />
                        <asp:BoundField HeaderText="Data" DataField="Data" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                    </Columns>
                </asp:GridView>
            </div>
    </form>
</body>
</html>
