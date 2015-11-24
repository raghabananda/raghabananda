<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentLogInpage.aspx.cs" Inherits="StudentLogInpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>StudentLogIn page.</h1>

            <div>
                Student LogIn:<br />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server"></asp:Label><br />
                <br />
                <div>
                    <label>Email ID: </label>
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" required="required"></asp:TextBox><br />
                    <br />
                    <label>PassWord : </label>
                    <asp:TextBox ID="TextBoxPassWord" runat="server" required="required"></asp:TextBox><br />
                    <br />
                    <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" /><br />
                    <br />
                    <a href="~/StudentSignUpPage.aspx">New User?Sign Up</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
