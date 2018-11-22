<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeApp.Employee" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Registration</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Employee Id</th>
                        <th>Employee Name</th>
                        <th>Designation</th>
                        
                    </tr>
                </thead>
                <tbody>
                <% foreach (DataRow row in table.Rows) { %>
                        
                        <tr>
                           <td>
                               <% =row["EmployeeId"] %>
                           </td>
                            <td>
                               <% =row["EmployeeName"] %>
                           </td>
                            <td>
                               <% =row["EmployeeDesig"] %>
                           </td>
                        </tr>
                
               <% }%>
                </tbody>
            </table>
        </div>

        <table>
            <tr>
                <td>Employee Name</td>
                <td> 
                    <asp:TextBox ID="txtEmpName" placeholder="Employee Name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Designation</td>
                <td> <asp:TextBox ID="txtDesig"  placeholder="Employee Designation" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="Submit" runat="server" OnClick="EmployeeSubmit" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
