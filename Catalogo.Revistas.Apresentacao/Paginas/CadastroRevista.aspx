<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroRevista.aspx.cs" Inherits="Catalogo.Revistas.Apresentacao.Paginas.CadastroRevista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="IdHiddenField" runat="server" />
        <table>
            <tr>
                <td>
                    <asp:Label ID="TituloLabel" runat="server" Text="Titulo" />
                </td>
                <td>
                    <asp:TextBox ID="TituloTextBox" runat="server" Width="337px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="SubTituloLabel" runat="server" Text="Subtitulo: " />
                </td>
                <td>
                    <asp:TextBox ID="SubTituloTextBox" runat="server" Width="429px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ArcoLabel" runat="server" Text="Arco: " />
                </td>
                <td>
                    <asp:TextBox ID="ArcoTextBox" runat="server" Width="429px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="AnoLabel" runat="server" Text="Ano: " />
                </td>
                <td>
                    <asp:TextBox ID="AnoTextBox" runat="server" Width="118px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="ValorLabel" runat="server" Text="Valor: " />
                </td>
                <td>
                    <asp:TextBox ID="ValorTextBox" runat="server" Width="118px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="GravarButton" runat="server" Text="Gravar" OnClick="GravarButton_Click" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="RevistasGridView" DataKeyNames="Id" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanging="RevistasGridView_SelectedIndexChanging" OnRowDeleting="RevistasGridView_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                <asp:BoundField DataField="SubTitulo" HeaderText="Subtitulo" />
                <asp:BoundField DataField="Arco" HeaderText="Arco" />
                <asp:BoundField DataField="Ano" HeaderText="Ano" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowSelectButton="True" DeleteText="Deletar" EditText="Editar" SelectText="Selecionar" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
