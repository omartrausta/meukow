<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayShowBlog.aspx.cs" Inherits="DisplayShowBlog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Repeater ID="m_blogRepeater" runat="server">
<ItemTemplate>
    <div class="blog">
      <h3>
      <asp:HyperLink ID="id1" runat="server" NavigateUrl="~/DisplayEnterBlog.aspx">Skrifa blogfærslu</asp:HyperLink>
      </h3>
      <h3><%#  Eval( "ID" ) %>
        <%# Eval( "Title" )%>
       </h3>
      <h4>
        <%# Eval( "BlogDate" ) %>
      </h4>
      <p>
        <%# Eval("Content")%>
      </p>
    </div>
  </ItemTemplate>
</asp:Repeater>
</asp:Content>

