<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true"
    CodeFile="Bovenhoek.aspx.cs" Inherits="admin.Settings.Picasa" %>

<%@ Register Src="Menu.ascx" TagName="TabMenu" TagPrefix="menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <div class="content-box-outer">
        <div class="content-box-right">
            <menu:TabMenu ID="TabMenu" runat="server" />
        </div>
        <div class="content-box-left">
            <div class="settingsxx">
                <h1>
                    Reclame in de bovenhoek</h1>
                <h2>
                    Acties</h2>
                <div id="formContainer" runat="server" class="mgr">
                    <div id="spamExtension" style="width: 800px; padding: 5px; margin-bottom: 5px;">
                        <table>
                            <tr>
                                <td>
                                    <label for="TxtUrl">
                                        Url</label>
                                </td>
                                <td>
                                    <asp:TextBox Width="400" ID="TxtUrl" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="TxtImageUrl">
                                        Image URL</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtImageUrl" Width="400" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="TxtTarget">Target</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTarget" Width="400" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="margin-left: 0">
                        <asp:Button ID="btnSave" class="btn primary" runat="server" OnClick="BtnSaveClick" />
                        <%=Resources.labels.or %>
                        <a href="~/admin/Extension Manager/default.aspx" runat="server">
                            <%=Resources.labels.cancel %></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
