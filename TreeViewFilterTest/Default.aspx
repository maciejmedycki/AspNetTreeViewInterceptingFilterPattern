<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TreeViewFilterTest.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater runat="server" ID="FilterRepeater">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="CriteriaCheckBox" Text='<%# DataBinder.Eval(Container.DataItem,"Name") %>' AutoPostBack="true" />
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:TreeView runat="server" ID="MainTreeView" OnTreeNodeDataBound="MainTreeView_TreeNodeDataBound">
                <DataBindings>
                    <asp:TreeNodeBinding ShowCheckBox="true" TextField="Name" />
                </DataBindings>
            </asp:TreeView>
        </div>
        <div>
            <asp:Button runat="server" ID="TestButton" Text="Text" />
        </div>
    </form>
</body>
</html>