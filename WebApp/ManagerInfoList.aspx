<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerInfoList.aspx.cs" Inherits="WebApp.ManagerInfoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/tableStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="AddManager.aspx">添加人员</a>
        <table class="table">
            <tr>
                <th>编号</th><th>用户名</th><th>密码</th><th>职位</th><th>编辑</th><th>删除</th>
            </tr>
            <%=listStr %>
        </table>
    </div>
    </form>
</body>
</html>
