<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<%@ Register Src="~/UserControl/ucPager2.ascx" TagPrefix="uc1" TagName="ucPager2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click" />
    <asp:Literal runat="server" ID="ltlTotal"></asp:Literal>
    <asp:GridView ID="gvAccountList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccountList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Caption" HeaderText="標題" />
            <asp:BoundField DataField="Amount" HeaderText="金額" />
            <asp:TemplateField HeaderText="In/Out">
                <ItemTemplate>
                    <%--   <%# (int)Eval("ActType") == 0 ? "支出":"收入" %>   --%>
                    <!-- 0=支出 ; 非0=收入 -->
                    <%--<asp:Literal ID="ltlActType" runat="server"></asp:Literal>--%>
                    <asp:Label ID="lblActType" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CreateDate" HeaderText="建立日期" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:Image runat="server" ID="imgCover" Width="80" Height="50" Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Act">
                <ItemTemplate>
                    <%-- <asp:Image runat="server" ID="imgCover" Width="80" Height="50"
                                        Visible='<%# Eval("CoverImage") != null %>'
                                        ImageUrl='<%# "../FileDownload/Accounting/" + Eval("CoverImage") %>'/>--%>
                    <%--<asp:Image runat="server" ID="imgCover" Width="80" Height="50" Visible="false" />--%>

                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID") %>">Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>

    <asp:Literal ID="ltlPager" runat="server"></asp:Literal>

    <div style="background-color: aliceblue" align="center">
        <uc1:ucpager2 runat="server" id="ucPager2" pagesize="10" CurrentPage="1" TotalSize="10" url="/SystemAdmin/AccountingList.aspx" />
    </div>
    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
        <p style="color: red; background-color: cornflowerblue">
            No data in your AccountingNote
        </p>
    </asp:PlaceHolder>

</asp:Content>
