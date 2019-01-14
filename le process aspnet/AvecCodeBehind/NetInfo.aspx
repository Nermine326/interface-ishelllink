<%@ Page Language="vb" AutoEventWireup="false" Codebehind="NetInfo.aspx.vb" Inherits="NetInfo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//FR">
<HTML>
	<HEAD>
		<title>NetInfo</title>
	</HEAD>
	<body bgColor="whitesmoke" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<P align="center"><asp:label id="Label1" runat="server" Width="100%" ForeColor="Navy" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Font-Underline="True">Status des Derniers lancements du Process ASPNET</asp:label></P>
			<br>
				<table width="100%">
					<tr>
						<td width="20%"><b>Machine : </b>
						</td>
						<td><asp:Label id="LabelMachine" runat="server" Width="100%">Label</asp:Label></td>
					</tr>
					<tr>
						<td width="20%"><b>Host Header Name : </b>
						</td>
						<td><asp:Label id="LabelHostname" runat="server" Width="100%">Label</asp:Label></td>
					</tr>
					<TR>
						<td width="20%"><b>IP : </b>
						</td>
						<td><asp:Label id="LabelIP" runat="server" Width="100%">Label</asp:Label></td>
					</TR>
					<TR>
						<td width="20%"><b>Uptime : </b>
						</td>
						<td><asp:Label id="LabelUptime" runat="server" Width="100%">Label</asp:Label></td>
					</TR>
				</table>
			<br>
			<p>
				<asp:Table id="tbProcess" runat="server" CellPadding="1" BorderStyle="Double" BorderColor="Gray" BackColor="LightGray" ForeColor="Navy" HorizontalAlign="Center" Width="95%"></asp:Table></p>
		</form>
	</body>
</HTML>
