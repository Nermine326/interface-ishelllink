Imports System.Net.Sockets
Imports System.Net
Imports System.Diagnostics

Public Class NetInfo
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents LabelMachine As System.Web.UI.WebControls.Label
    Protected WithEvents LabelHostname As System.Web.UI.WebControls.Label
    Protected WithEvents LabelIP As System.Web.UI.WebControls.Label
    Protected WithEvents LabelUptime As System.Web.UI.WebControls.Label
    Protected WithEvents tbProcess As System.Web.UI.WebControls.Table

#Region " Code g�n�r� par le Concepteur Web Form "

    'Cet appel est requis par le Concepteur Web Form.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN�: cet appel de m�thode est requis par le Concepteur Web Form
        'Ne le modifiez pas en utilisant l'�diteur de code.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AffProcessInfo()

        LabelMachine.Text = Server.MachineName
        LabelHostname.Text = Request.ServerVariables("SERVER_NAME")
        LabelIP.Text = IP(Server.MachineName)
        LabelUptime.Text = RecupUtime()
    End Sub

    ' -----------------------------------------------------
    Private Sub AffProcessInfo()
        ' Lancement de la r�cup�ration des informations depuis le Serveur

        ' D�claration des Objets n�cessaires
        Dim mP As New ProcessModelInfo()
        Dim mPITab As ProcessInfo()
        Dim mPi As ProcessInfo
        Dim trET As New TableRow()
        Dim i As Integer = 1

        ' Chargement de l'historique (les 10 derniers lancements) des donn�es sur le process ASP_NET
        mPITab = mP.GetHistory(10)

        ' Mise en forme de la Premiere ligne
        trET.BackColor = System.Drawing.Color.Beige
        trET.Font.Bold = True
        trET.ForeColor = System.Drawing.Color.DarkBlue

        ' Ajout des Noms de Colonne et Ajout de la ligne dans le Tableau
        AddCell(trET, "N�")
        AddCell(trET, "ID")
        AddCell(trET, "Age")
        AddCell(trET, "M�moire max utilis�e")
        AddCell(trET, "Nbr requ�tes")
        AddCell(trET, "Date d�but")
        AddCell(trET, "Statut")
        AddCell(trET, "Raison �chec")
        tbProcess.Rows.Add(trET)

        ' Boucle de lecture et d'affichage dans le tableau des Informations sur les Process
        For Each mPi In mPITab
            Dim tr As New TableRow()

            AddCell(tr, i) ' Ajoute le N� de l'historique
            AddCell(tr, mPi.ProcessID.ToString) ' Affiche l'ID du process
            AddCell(tr, AfficheAge(mPi.Age)) 'Affiche l'�ge du process en D�tail
            AddCell(tr, AfficheTaille(mPi.PeakMemoryUsed)) 'Affiche la m�moire maximale utilis�e
            AddCell(tr, mPi.RequestCount.ToString) 'nombre de requ�te trait�es
            AddCell(tr, mPi.StartTime.ToString) 'la date du d�but du process
            AddCell(tr, mPi.Status.ToString) 'son statut
            AddCell(tr, mPi.ShutdownReason.ToString) 'la raison de son arr�t

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
        ' Affiche le temps en d�tail de vie du process ASPNET
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
        ' Cr�e le d�tail de la taille des donn�es 
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
        ' V�rifie la valeur est sup�rieure � 1 et affiche le pluriel
        If Lavaleur > 1 And TestPlur = True Then
            Return Lavaleur & " " & LUnite & "s"
        ElseIf Lavaleur > 0 Then
            Return Lavaleur & " " & LUnite
        End If
    End Function

    ' -----------------------------------------------------
    Private Function IP(ByVal adIp As String) As String
        ' Recup�re l'IP de la machine
        Dim myIP As IPHostEntry = Dns.Resolve(adIp)
        Dim sIP As String
        'sIP = ("HostName :" & myIP.HostName & "<br>")
        sIP += (myIP.AddressList(0).ToString)

        Return sIP
    End Function

    ' -----------------------------------------------------
    Private Function RecupUtime() As String
        ' Recup�re l'Uptime de la machine
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

End Class
