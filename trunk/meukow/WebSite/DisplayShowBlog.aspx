<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayShowBlog.aspx.cs" Inherits="DisplayShowBlog" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:FormView ID="FormView1" runat="server"> 
    <ItemTemplate>
    <div class="blog">
      <h3>
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
  </asp:FormView>
</asp:Content>

