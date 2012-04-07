<%@ Page Title="" Language="C#" MasterPageFile="../Shared/AdminPlugin.Master" Inherits="System.Web.Mvc.ViewPage<FortuneCookie.PageTypeSecurityOverview.Models.OverviewPageViewModel>" %>
<%@ Import Namespace="EPiServer.Cms.Shell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <style type="text/css">
        table.epi-default tr td.unavailable { background-color: #eee;}     
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1 class="epi-prefix"><%=Html.Translate("/pagetypesecurityoverview/title")%></h1>
    <p class="EP-systemInfo"><%=Html.Translate("/pagetypesecurityoverview/description")%></p>


  
    <table class="epi-default" cellspacing="0" border="0" style="border-style:None;border-collapse:collapse;">
    <tbody>
	   <tr>
	      <th><%=Html.Translate("/pagetypesecurityoverview/pagetype")%></th>
          <th><%=Html.Translate("/pagetypesecurityoverview/available")%></th>
          <th colspan="2"><%=Html.Translate("/pagetypesecurityoverview/principals")%></th> 
          <th><%=Html.Translate("/pagetypesecurityoverview/allowable")%></th>
	   </tr>
       
       <% foreach (var pageType in Model.PageTypeModels)
          { %>
           <tr>
               <td class="<%=pageType.AvailableCssName %>"><a name="<%=pageType.Name %>"></a><a title="<%=Html.Translate("/pagetypesecurityoverview/edit")%>" href="<%=Model.EditPageTypeUrl %>?typeId=<%=pageType.Id %>"><%=pageType.Name %></a></td>
               <td class="<%=pageType.AvailableCssName %>"><%=pageType.IsAvailable %></td>
               <td class="<%=pageType.AvailableCssName %>"><img src="/App_Themes/Default/Images/SecurityTypes/Role.gif"></td>
               <td class="<%=pageType.AvailableCssName %>">
                   <% foreach (var childPageType in pageType.AccessControlList)
                      { %>
                            <%=childPageType %><br />
                   <% } %>
               </td>
               <td class="<%=pageType.AvailableCssName %>"><% foreach (var childPageType in pageType.AllowablePageTypeNames)
                      { %>
                            <a href="#<%=childPageType %>" title="<%=Html.Translate("/pagetypesecurityoverview/skipto")%>"><%=childPageType %></a><br />
                   <% } %>
                </td>
           </tr>
         <% } %>
        </tbody>
   </table> 

</asp:Content>
