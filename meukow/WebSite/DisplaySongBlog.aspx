<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplaySongBlog.aspx.cs" Inherits="DisplaySongBlog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Repeater ID="m_blogRepeater" runat="server">
  <ItemTemplate>
    <div class="blog">
      <h3><a href="ShowBlog.aspx?BlogID=<%#  Eval( "ID" ) %>">
        <%# Eval( "Title" )%>
        </a></h3>
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

