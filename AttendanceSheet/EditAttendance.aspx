<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAttendance.aspx.cs" Inherits="EditAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>Enter Registration No.</label>
        <asp:TextBox ID="TextBoxRegistrationNo" runat="server"></asp:TextBox><br />
        <label>Select Semistar</label>
        <asp:DropDownList ID="DropDownListSemistar" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
        <label>Select Subject</label>
        <asp:DropDownList ID="DropDownListSubject" runat="server"></asp:DropDownList>
        <asp:Button ID="BtnSubmit" runat="server" Text="Enter" />
    </div>
    </form>
</body>
</html>
