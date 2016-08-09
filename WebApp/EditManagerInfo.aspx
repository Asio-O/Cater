<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditManagerInfo.aspx.cs" Inherits="WebApp.EditManagerInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>名字 </td>
                    <td>
                        <input type="text" name="name" value="<%=mi.MName %>"/></td>
                </tr>
                <tr>
                    <td>密码 </td>
                    <td>
                        <input type="password" name="pwd" value="<%=mi.MPwd %>"/></td>
                </tr>
                <tr>
                    <td>职位 </td>
                    <td>
                        <select name="type">
                            <option value="1" <%=mi.Mtype==1?"selected='selected'":"" %>>经理</option>
                            <option value="2" <%=mi.Mtype==1?"":"selected='selected'" %>>员工</option>
                        </select></td>
                </tr>
            </table>
            <input type="hidden" value="<%=mi.Mid %>" name="id" />
            <input type="submit" value="确认修改" />
        </div>
    </form>
</body>
</html>
