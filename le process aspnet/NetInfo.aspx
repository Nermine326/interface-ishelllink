<%@ Page Language="VB" ClientTarget="downlevel" %>
<%@ Import Namespace="System.Web" %>
<%@ Import Namespace="System.Net.Sockets" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Diagnostics" %>

<script language="VB" runat="server">

' -----------------------------------------------------
Sub Page_Load(obj As object, e As eventargs)
 ' Chargement au démarrage de la page pour récuperer les informations
 AffProcessInfo()
 LabelMachine.Text = Server.MachineName
 LabelHostname.Text = Request.ServerVariables("SERVER_NAME")
 LabelIP.Text = IP(Server.MachineName)
 LabelUptime.Text = RecupUtime()

End Sub

    ' -----------------------------------------------------
    Private Sub AffProcessInfo()
        ' Lancement de la récupération des informations depuis le Serveur

        ' Déclaration des Objets nécessaires
        Dim mP As New ProcessModelInfo()
        Dim mPITab As ProcessInfo()
        Dim mPi As ProcessInfo
        Dim trET As New TableRow()
        Dim i As Integer = 1

        ' Chargement de l'historique (les 10 derniers lancements) des données sur le process ASP_NET
        mPITab = mP.GetHistory(10)

        ' Mise en forme de la Premiere ligne
        trET.BackColor = System.Drawing.Color.Beige
        trET.Font.Bold = True
        trET.ForeColor = System.Drawing.Color.DarkBlue

        ' Ajout des Noms de Colonne et Ajout de la ligne dans le Tableau
        AddCell(trET, "N°")
        AddCell(trET, "ID")
        AddCell(trET, "Age")
        AddCell(trET, "Mémoire max utilisée")
        AddCell(trET, "Nbr requêtes")
        AddCell(trET, "Date début")
        AddCell(trET, "Statut")
        AddCell(trET, "Raison échec")
        tbProcess.Rows.Add(trET)

        ' Boucle de lecture et d'affichage dans le tableau des Informations sur les Process
        For Each mPi In mPITab
            Dim tr As New TableRow()

            AddCell(tr, i) ' Ajoute le N° de l'historique
            AddCell(tr, mPi.ProcessID.ToString) ' Affiche l'ID du process
            AddCell(tr, AfficheAge(mPi.Age)) 'Affiche l'âge du process en Détail
            AddCell(tr, AfficheTaille(mPi.PeakMemoryUsed)) 'Affiche la mémoire maximale utilisée
            AddCell(tr, mPi.RequestCount.ToString) 'nombre de requête traitées
            AddCell(tr, mPi.StartTime.ToString) 'la date du début du process
            AddCell(tr, mPi.Status.ToString) 'son statut
            AddCell(tr, mPi.ShutdownReason.ToString) 'la raison de son arrêt

            tbProcess.Rows.Add(tr)
            i += 1
        Next
    End Sub

    ' -----------------------------------------------------
    Private Sub AddCell(ByVal tr As TableRow, ByVal sM As String)
        'Ajoute une cellule dans la ligne du tableau
        Dim td As New TableCell()
        td.Text = sM
        tr.Cells.Add(td)
    End Sub

    ' -----------------------------------------------------
    Private Function AfficheAge(ByVal LeTimeSpan As TimeSpan) As String
        ' Affiche le temps en détail de vie du process ASPNET
        Dim Retour As String = ""
        Retour = TestZero(LeTimeSpan.Days, "J", False)
        Retour &= " " & TestZero(LeTimeSpan.Hours, "H", False)
        Retour &= " " & TestZero(LeTimeSpan.Minutes, "M", False)
        Retour &= " " & TestZero(LeTimeSpan.Seconds, "S", False)
        Retour &= " " & TestZero(LeTimeSpan.Milliseconds, "mS", False)

        Return Retour
    End Function

    ' -----------------------------------------------------
    Private Function AfficheTaille(ByVal TailleMemoire As Integer) As String
        ' Crée le détail de la taille des données 
        Dim TailleGO As Double = 0
        Dim TailleMO As Double = 0
        Dim TailleKO As Double = 0
        Dim Retour As String = ""

        TailleGO = (TailleMemoire / 1048576) ' Nombre de Giga Octets
        TailleMO = (TailleGO - Int(TailleGO)) * 1024 ' Nombre de Mega Octets
        TailleKO = (TailleMO - Int(TailleMO)) * 1024 ' Nombre de Kilo Octets

        Retour = TestZero(TailleGO, "Go", False)
        Retour &= " " & TestZero(TailleMO, "Mo", False)
        Retour &= " " & TestZero(TailleKO, "Ko", False)

        Return Retour
    End Function

    ' -----------------------------------------------------
    Private Function TestZero(ByVal Lavaleur As Integer, ByVal LUnite As String, ByVal TestPlur As Boolean) As String
        ' Vérifie la valeur est supérieure à 1 et affiche le pluriel
        If Lavaleur > 1 And TestPlur = True Then
            Return Lavaleur & " " & LUnite & "s"
        ElseIf Lavaleur > 0 Then
            Return Lavaleur & " " & LUnite
        End If
    End Function

    ' -----------------------------------------------------
    Private Function IP(ByVal adIp As String) As String
        ' Recupère l'IP de la machine
        Dim myIP As IPHostEntry = Dns.Resolve(adIp)
        Dim sIP As String
        'sIP = ("HostName :" & myIP.HostName & "<br>")
        sIP += (myIP.AddressList(0).ToString)

        Return sIP
    End Function

    ' -----------------------------------------------------
    Private Function RecupUtime() As String
        ' Recupère l'Uptime de la machine
        Dim retour As String = ""
        Dim pc As New PerformanceCounter("System", "System Up Time")
        pc.NextValue()

        Dim ts As TimeSpan = TimeSpan.FromSeconds(pc.NextValue())
        retour = TestZero(ts.Days, "Jour", True)
        retour &= " " & TestZero(ts.Hours, "Heure", True)
        retour &= " " & TestZero(ts.Minutes, "Minute", True)
        retour &= " " & TestZero(ts.Seconds, "Seconde", True)
        retour &= " " & TestZero(ts.Milliseconds, "MilliSeconde", True)

        Return retour
    End Function
    ' -----------------------------------------------------

</script>
<html>
<head>
<title>Process Info</title>
</head>
<body bgColor="whitesmoke">
 <form id="Form1" method="post" runat="server">
  <P align="center"><asp:label id="Label1" runat="server" Width="100%" ForeColor="Navy" Font-Bold="True" Font-Names="Times New Roman" Font-Size="Medium" Font-Underline="True">Status des Derniers lancements du Process ASPNET</asp:label></P>
  <br>
   <table width="100%">
   <tr>
    <td width="20%"><b>Machine : </b></td>
    <td><asp:Label id="LabelMachine" runat="server" Width="100%">Label</asp:Label></td>
   </tr>
   <tr>
    <td width="20%"><b>Host Header Name : </b></td>
    <td><asp:Label id="LabelHostname" runat="server" Width="100%">Label</asp:Label></td>
   </tr>
   <TR>
    <td width="20%"><b>IP : </b></td>
    <td><asp:Label id="LabelIP" runat="server" Width="100%">Label</asp:Label></td>
   </TR>
   <TR>
    <td width="20%"><b>Uptime : </b></td>
    <td><asp:Label id="LabelUptime" runat="server" Width="100%">Label</asp:Label></td>
   </TR>
  </table>
  <br><p>
  <asp:Table id="tbProcess" runat="server" CellPadding="1" BorderStyle="Double" BorderColor="Gray" BackColor="LightGray" ForeColor="Navy" HorizontalAlign="Center" Width="95%"></asp:Table></p> </form>
</body>
</html>
