<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddManager.aspx.cs" Inherits="WebApp.AddManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <table>
                <tr>
                    <td>名字 </td>
                    <td>
                        <input type="text" name="name" /></td>
                </tr>
                <tr>
                    <td>密码 </td>
                    <td>
                        <input type="password" name="pwd" /></td>
                </tr>
                <tr>
                    <td>职位 </td>
                    <td>
                        <select name="type">
                            <option value="1">经理</option>
                            <option value="2">员工</option>
                        </select></td>
                </tr>
            </table>
            <input type="submit" value="添加员工" />
        </div>
    </form>
</body>
</html>
