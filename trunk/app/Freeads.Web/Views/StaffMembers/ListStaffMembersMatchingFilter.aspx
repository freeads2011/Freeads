<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ViewPage<IEnumerable<StaffMember>>" %>
<%@ Import Namespace="Freeads.Core" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<p>Matching Staff Members:</p>
    <ul>
        <%
        foreach (StaffMember staffMember in ViewData.Model) { %>
         <li><%= staffMember.EmployeeNumber %></li><%
        }
        %>
    </ul>
</asp:Content>
