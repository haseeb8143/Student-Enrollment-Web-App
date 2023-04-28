<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab_8.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student add</title>
    <link rel="stylesheet" href="AddStyle.css">
</head>
<body>
    <h1 runat="server" id="mainhead">Students</h1>
    <br>
    <form id="form1" runat="server">
        <div>

            <label for="name">Student Name: </label>
            <input type="text" runat="server" id="name" name="name">
            <asp:RequiredFieldValidator runat="server" id="reqName" ForeColor="Red" controltovalidate="name" errormessage="Please enter a name." />
            <br>
            <br>

            <span id="stulabel" runat="server">Student Type: </span>
            <asp:DropDownList ID="choosetime" runat="server">
                <asp:ListItem Text="Select" Value="1"></asp:ListItem>
                <asp:ListItem Text="Full-Time" Value="2"></asp:ListItem>
                <asp:ListItem Text="Part-Time" Value="3"></asp:ListItem>
                <asp:ListItem Text="Co-op" Value="4"></asp:ListItem>
            </asp:DropDownList>

             <asp:RequiredFieldValidator ID="rqStudentLabel" runat="server"
                ErrorMessage="Please select a type."
                ForeColor="Red" ControlToValidate="choosetime"
                InitialValue="1" Display="Dynamic"></asp:RequiredFieldValidator>

            <br>

            <p id="err" runat="server"></p>

            <br>

            <asp:Button ID="addbtn" runat="server" Text="Add" />

            <br>
            <br>

            <table id="stutbl" runat="server">
                <tr>
                    <th>ID</th>
                    <th>Student</th>
                </tr>
                <tr id="rowtormv" runat="server">
                    <td id="coltormv" runat="server">No entries</td>
                </tr>
            </table>
        </div>

        <a href="RegisterCourse.aspx">Registration</a>
    </form>
</body>
</html>
