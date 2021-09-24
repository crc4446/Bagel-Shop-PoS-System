<%@ Page Title="" Language="C#" MasterPageFile="~/MIS316/MasterPagecrc4446.master" AutoEventWireup="true" CodeFile="MP2B.aspx.cs" Inherits="MIS316_MP2B" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .underline {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1><em>Bagel Shop v2</em> [<span class="underline">Improved</span> Point of Sales System]</h1>
    <asp:Panel ID="pnlStart" runat="server">
        <table>
            <tr>
                <td>Customer Name:</td>
                <td><asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ControlToValidate="txtCustomerName" Display="Dynamic" ErrorMessage="* required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
    </td>
            </tr>
            <tr>
                <td>How Many Bagels?:</td>
                <td>
                    <asp:TextBox ID="txtNumberOfBagels" runat="server"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="rfvNumberOfBagels" runat="server" ControlToValidate="txtNumberOfBagels" Display="Dynamic" ErrorMessage="* required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvNumberOfBagels" runat="server" ControlToValidate="txtNumberOfBagels" Display="Dynamic" ErrorMessage="* enter a whole number between 1 and 25" ForeColor="Red" MaximumValue="25" MinimumValue="1" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
        </table>
        <p>
            <asp:RadioButtonList ID="rblOrderType" runat="server">
                <asp:ListItem Selected="True" Value="0.00">Carry Out</asp:ListItem>
                <asp:ListItem Value="0.07">Dine In</asp:ListItem>
            </asp:RadioButtonList>
        </p>
    <p>
        <asp:Button ID="btnStart" runat="server" Text="Start Order" OnClick="btnStart_Click" />
    </p>
    </asp:Panel>
    <asp:Panel ID="pnlOrderSelections" runat="server" Visible="False">

        <table>
            <tr>
                <td><strong>Order for:</strong></td>
                <td><asp:Label ID="lblCustomerName" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td><strong>Order Type:</strong></td>
                <td>
                    <asp:Label ID="lblOrderType" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Number of Bagels:</strong></td>
                <td>
                    <asp:Label ID="lblNumberOfBagels" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td><strong>Tax Rate:</strong></td>
                <td>
                    <asp:Label ID="lblTaxRate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Type of Bagel:</strong></td>
                <td>
                    <asp:DropDownList ID="ddlTypeOfBagel" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="2.75">Blueberry</asp:ListItem>
                        <asp:ListItem Value="3.25">Cheese</asp:ListItem>
                        <asp:ListItem Value="3.50">Everything</asp:ListItem>
                        <asp:ListItem Value="2.50">Jalopeno</asp:ListItem>
                        <asp:ListItem Value="2.00">Plain</asp:ListItem>
                        <asp:ListItem Value="3.00">Wheat</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTypeOfBagel" runat="server" ControlToValidate="ddlTypeOfBagel" Display="Dynamic" ErrorMessage="* required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="vertical-align: top">
                <td><strong>Additional Options:</strong></td>
                <td>
                    <asp:CheckBoxList ID="cblAdditionalOptions" runat="server">
                        <asp:ListItem Value="1.00">Cream Cheese</asp:ListItem>
                        <asp:ListItem Value="2.00">Nutella</asp:ListItem>
                        <asp:ListItem Value="0.50">Toasted</asp:ListItem>
                        <asp:ListItem Value="1.50">Peanut Butter</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><strong>Payment Type:</strong></td>
                <td>
                    <asp:RadioButtonList ID="rblPaymentType" runat="server" RepeatColumns="2">
                        <asp:ListItem Selected="True">Cash</asp:ListItem>
                        <asp:ListItem>Credit</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnFinish" runat="server" Text="Finish Order" OnClick="btnFinish_Click" />
    </asp:Panel>
    <asp:Panel ID="pnlReceipt" runat="server" Visible="False">
        <asp:Label ID="lblOrderSummary" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnNextCustomer" runat="server" Text="Next Customer" OnClick="btnNextCustomer_Click" />
    </asp:Panel>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

