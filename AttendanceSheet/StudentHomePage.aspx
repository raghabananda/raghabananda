<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentHomePage.aspx.cs" Inherits="StudentHomePage" %>

<%@ PreviousPageType VirtualPath="~/StudentLogInpage.aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:LinkButton ID="LinkBtnEditProfile" runat="server" Text="EditProfile" OnClick="LinkBtnEditProfile_Click"></asp:LinkButton>
            <br />
            <a href="StudentLogInpage.aspx">Log Out</a>
        </nav>
        <div>
            <h1>Student Home Page.</h1>
            <label>Student Details:</label>
        </div>
        <div>
            <div>
                <asp:Image ID="Image1" runat="server" Height="300px" Width="344px"/>
            </div>
            <asp:Panel ID="Panel1" runat="server">
                <label>Name : </label>
                <asp:Label ID="LabelName" runat="server" Text=""></asp:Label><br />
                <br />
                <label>Email ID : </label>
                <asp:Label ID="LabeEmail" runat="server" Text=""></asp:Label><br />
                <br />
                <label>Registration No : </label>
                <asp:Label ID="LabelRegistrationNo" runat="server" Text=""></asp:Label><br />
                <br />
                <label>Phone : </label>
                <asp:Label ID="LabelPhone" runat="server" Text=""></asp:Label><br />
                <br />
                <label>Adress : </label>
                <asp:Label ID="LabelAdress" runat="server" Text=""></asp:Label><br />
                <br />
            </asp:Panel>

            <!--------------------------------------------------------------------------------------------------------------------------------->
            <!--------Edit Profile---------->
            <asp:Panel ID="Panel2" runat="server" Visible="false">
                <!--Change Password-->
                <asp:Panel ID="PanelPassword1" runat="server">
                    <asp:LinkButton ID="LinkBtnPassWord" runat="server" Text="Change PassWord"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="PanelPassword2" runat="server" Visible="false">
                    <label>New PassWord : </label>
                    <asp:TextBox ID="TextBoxNewPassWord" runat="server" required="required"></asp:TextBox><br />
                    <br />
                    <label>Confirm PassWord : </label>
                    <asp:TextBox ID="TextBoxConfirmPassWord" runat="server" required="required"></asp:TextBox><br />
                    <br />
                    <asp:Button ID="BtnUpdatePassword" runat="server" Text="Update" />
                </asp:Panel>
                <!--/Change Password-->

                <!--Change Phone No.-->
                <asp:Panel ID="PanelPhoneNo1" runat="server">
                    <asp:LinkButton ID="LinkBtnChangePassWord" runat="server" Text="Change Phone No"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="PanelPhoneNo2" runat="server" Visible="false">
                    <label>New Phone No : </label>
                    <asp:TextBox ID="TextBoxNewPhoneNo" runat="server" required="required"></asp:TextBox>
                </asp:Panel>
                <!--/Change Phone No.-->

                <!--Change Adress-->
                <asp:Panel ID="PanelChangeAdress1" runat="server">
                    <asp:LinkButton ID="LinkBtnChangeAdress" runat="server" Text="Change Adress"></asp:LinkButton>
                </asp:Panel>
                <asp:Panel ID="PanelChangeAdress2" runat="server" Visible="false">
                    <label>New Adress : </label>
                    <asp:TextBox ID="TextBoxNewAdress" runat="server" TextMode="MultiLine" Height="70px" Width="231px" required="required"></asp:TextBox>
                </asp:Panel>
                <!--/Change Adress-->
            </asp:Panel>
            <!------------------------------------------------------------------------------------------------------------------------------------------->
            <!-------Attendance Details--------->
            <div>
                <asp:Panel ID="Panel3" runat="server">
                    <asp:DropDownList ID="DropDownListBranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBranch_SelectedIndexChanged"></asp:DropDownList>
                     <asp:DropDownList ID="DropDownListSemistar" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSemistar_SelectedIndexChanged"></asp:DropDownList>
                     <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList>
                     <asp:Button  ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click"/>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Visible="false">
                        <Columns>
                            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                             <asp:BoundField DataField="Status" HeaderText="Attendance Status" SortExpression="Status" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

            </div>
        </div>
    </form>
</body>
</html>
