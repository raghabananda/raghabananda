<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogIn.aspx.cs" Inherits="AdminLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav>
                <asp:LinkButton ID="LinkBtnLogout" runat="server" Font-Bold="true" Text="Log Out" OnClick="LinkBtnLogout_Click" Visible="false"></asp:LinkButton>
                <div>
                    <asp:LinkButton ID="LinkBtnHome" runat="server" Text="Home" OnClick="LinkBtnHome_Click" Visible="false"></asp:LinkButton>
                </div>
            </nav>
        </div>
        <div>

            <h1>Admin:</h1>
        </div>
        <div>
            <asp:Panel ID="PanelLogIn" runat="server">
                <div style="text-align: center">
                    <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <label>Admin ID : </label>
                <asp:TextBox ID="TextBoxAdminId" runat="server" TextMode="Email" required="required"></asp:TextBox><br />
                <br />
                <label>PassWord : </label>
                <asp:TextBox ID="TextBoxPassWord" runat="server" TextMode="Password" required="required"></asp:TextBox><br />
                <br />
                <asp:Button ID="BtnLogIn" runat="server" Text="Submit" OnClick="BtnLogIn_Click" />
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="PanelAttendanceSheet" runat="server" Visible="false">
                <asp:Panel ID="PanelAttendanceSheet1" runat="server">
                    <label>Select Branch : </label>
                    <asp:DropDownList ID="DropDownListBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBranch_SelectedIndexChanged">
                    </asp:DropDownList><br />
                    <label>Select Semistar</label>
                    <asp:DropDownList ID="DropDownListSemistar" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="DropDownListSemistar_SelectedIndexChanged">
                    </asp:DropDownList><br />

                    <label>Select Subject : </label>
                    <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList><br />

                    <asp:Button ID="BtnSubmit1" runat="server" Text="Submit" OnClick="BtnSubmit1_Click" />
                </asp:Panel>
                <asp:Panel ID="PanelAttendanceSheet2" runat="server" Visible="false">
                    <label>Attendance Sheet:</label><br />
                    <br />
                    <asp:GridView ID="GridViewAttendanceSheet" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxStatus" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                                <ItemTemplate>
                                    <asp:Label ID="LabelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                            <asp:BoundField DataField="RegistrationNo" HeaderText="RegistrationNo" SortExpression="RegistrationNo" />
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="ButtonSubmitAttendance" runat="server" Text="Submit" OnClick="ButtonSubmitAttendance_Click" />
                </asp:Panel>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
