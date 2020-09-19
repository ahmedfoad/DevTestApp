<%@ Page  Debug="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DevTestApp._Default" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v19.1, Version=19.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    
  
    <script type="text/javascript">
        debugger;
        function OnGridFocusedRowChanged() {
            debugger;
          
            grid.GetRowValues(grid.GetFocusedRowIndex(), 'Acc_Number', OnGetRowValues);
        }
        // Value array contains "EmployeeID" and "Notes" field values returned from the server
        function OnGetRowValues(value) {
            //  DetailImage.SetImageUrl("FocusedRow.aspx?Photo=" + values[0]);
            debugger;

            //pass the value to Web method
            DevTestApp.WebService1.GetAddition(value, SuccessCallback, OnfailureCallback);
        
        }
        //returns output from service 
        function SuccessCallback(AddResult) {
            //displaying output on alertbox 
            alert(AddResult);
        }
        //returns the error after web service failed to execute 
        function OnfailureCallback(error) {
            //displaying error on alert box
            alert(error);



        }
    </script>
    <form runat="server">
        
    <asp:ScriptManager runat="server">
        <Services>  
            <asp:ServiceReference Path="~/WebService1.asmx" />  
        </Services>  
        <Scripts>
            <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
            <%--Framework Scripts--%>
            <asp:ScriptReference Name="MsAjaxBundle" />
            <asp:ScriptReference Name="jquery" />
            <asp:ScriptReference Name="bootstrap" />
            <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
            <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
            <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
            <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
            <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
            <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
            <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
            <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
            <asp:ScriptReference Name="WebFormsBundle" />
            <%--Site Scripts--%>
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1"
                     runat="server">
    <ContentTemplate>
        <h1 style="color: #4169e1;"><b>Top Level Account using DivExpress Gridview</b></h1>
        <br/>
        
        <dx:ASPxGridView ID="grid" ClientInstanceName="grid" runat="server"
                         KeyFieldName="Acc_Number"  AutoGenerateColumns="False" EnableRowsCache="false" Width="100%">
            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />

            <SettingsPopup>
                <HeaderFilter MinHeight="140px"></HeaderFilter>
            </SettingsPopup>
            <Columns>
                <dx:GridViewDataColumn FieldName="Acc_Number">
                    <HeaderTemplate>
                        Top Level Account
                    </HeaderTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn FieldName="Balance">
                    <HeaderTemplate>
                        Total Balance
                    </HeaderTemplate>
                </dx:GridViewDataColumn>
            </Columns>
            <Settings ShowGroupPanel="true" />
            <SettingsAdaptivity AdaptivityMode="HideDataCells" />
            <SettingsBehavior AllowFocusedRow="true" />
            <ClientSideEvents FocusedRowChanged="function(s) { OnGridFocusedRowChanged(); }" />
        </dx:ASPxGridView>
   
   </ContentTemplate>
</asp:UpdatePanel>
    
    </form>
</asp:Content>
