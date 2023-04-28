<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab_8.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="RegisterStyle.css" rel="stylesheet" />
</head>
<body>
    <h1 runat="server" id="mainhead">Registration</h1>
    <br>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Select a student:" runat="server" />
            <asp:DropDownList class="input" ID="studentList" OnSelectedIndexChanged="StudentChanged" runat="server" Width="150px" AutoPostBack="true">
                <asp:ListItem Text="Select..." Value="0" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqStudentList" runat="server"
                ErrorMessage="Please select a student!"
                ForeColor="Red" ControlToValidate="studentList"
                InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
            <br />
            <br />
        </div>

        <div>
            <asp:Label Text="" ID="confirm" CssClass="distinct" runat="server" />

            <br>

            <asp:Label Text="" ID="error" CssClass="distinct" runat="server" style="color:red"/>
        </div>

        <div>
            <br>
            <div id="title" runat="server">Following Courses are available for registration:</div>
            <br>
            <asp:CheckBoxList ID="chklist" runat="server">
            </asp:CheckBoxList>
        </div>

        <br />
        <asp:Button ID="button" class="button" Text="Save" OnClick="SaveEvent" runat="server" />
        <br />
    </form>
    <br>
    <a href="./AddStudent.aspx">Add Student</a>
</body>
</html>
