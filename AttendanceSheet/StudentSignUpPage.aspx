<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentSignUpPage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Student SignUp page.</h1>
        <div style="text-align:center">
            <asp:Label ID="LabelErrorMsg" runat="server"></asp:Label>
        </div>
         <div>
            NEW USER SIGN UP:<br />
            <br />
            <br />
            <label>First Name:</label>
            <asp:TextBox ID="TextBoxFirstName" runat="server" required="required"></asp:TextBox><br />
             <label>Last Name:</label>
            <asp:TextBox ID="TextBoxLastName" runat="server" required="required"></asp:TextBox><br />
            <label for="TextRegistrationNo">Registration No:</label>
            <asp:TextBox ID="TextRegistrationNo" runat="server" TextMode="Phone" required="required"></asp:TextBox><br />
            <label for="DropDownListBranch">Branch:</label>
            <asp:DropDownList ID="DropDownListBranch" runat="server"></asp:DropDownList><br />
            <label for="TextEmail">Email:</label>
            <asp:TextBox ID="TextEmail" runat="server" TextMode="Email" required="required"></asp:TextBox><br />
            <label for="TextPassword">Password:</label>
            <asp:TextBox ID="TextPassword" runat="server" TextMode="Password" required="required"></asp:TextBox><br />
            <label for="TextPhoneNo">Phone No:</label>
            <asp:TextBox ID="TextPhoneNo" runat="server" TextMode="Phone" required="required"></asp:TextBox><br />
            <label for="TextAdress">Adress:</label>
            <asp:TextBox ID="TextAdress" runat="server" TextMode="MultiLine" Height="70px" Width="231px" required="required"></asp:TextBox><br />
             <label for="FileUploadPhoto">Photo:</label>
            <asp:FileUpload ID="FileUploadPhoto" runat="server" /><br />
            <asp:Button ID="Button1" runat="server" Text="SignUp" OnClick="Button1_Click" />
        </div>
    </div>
    </form>
</body>
</html>
