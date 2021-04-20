<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Fleadh_Admin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpHeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <div class="generalcontainer">
        <div class="generalsection">

            <asp:UpdatePanel ID="UP_Login" runat="server">
                <ContentTemplate>
            
                <h2>Login</h2>
                <p>Welcome to the Galway Fleadh administration web site.</p>
                <p>Please login to use the site.</p>
                <div class="onecontrol">
                    <div>
                        <h3>User name:</h3>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="usercontrol" 
                            TabIndex="1" ToolTip="Enter user name" ></asp:TextBox>
                    </div>

                    <div>
                        <h3>Password:</h3>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="usercontrol" 
                            TabIndex="2" ToolTip="Enter password" TextMode="Password" ></asp:TextBox>
                    </div>
                                
                    <div>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" 
                            TabIndex="3" onclick="btnLogin_Click" />
                    </div>

                    <div>
                        <asp:Label ID="lblLoginFailure" runat="server"></asp:Label>    
                    </div>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
