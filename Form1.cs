using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WinSCP;
using System.Threading;

namespace Esportatore
{
    public partial class Form1 : Form
    {
        Configurazione[] configurazioni = null;
        int confSelezionata = -1;
        string selectedPath = "";
        string server = "";
        string user = "";
        string pwd = "";
        string fingerprint = "";
        string[] radiceIstanze = null;
        public Form1()
        {
            Thread trd = new Thread(new ThreadStart(Form1_Run));
            trd.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            trd.Abort();
        }

        private void Form1_Run()
        {
            Application.Run(new Splashscreen());
        }

        private void scanIniFile(string iniFile)
        {
            string[] parts = iniFile.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 5)
                return;

            server = parts[0];
            user = parts[1];
            pwd = parts[2];
            fingerprint = parts[3];
            radiceIstanze = parts[4].Replace("[","").Replace("]","").Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        }
        private void ShowBallonMessage(string message)
        {
            string[] precoda = new string[]
            {
                "Guarda non so come dirtelo, ma ",
                "Lo sapevi che ",
                "Devo dirti una cosa: "
            };
            string[] accoda = new string[]
            {
                "...\r\n Questo è molto INQUIETANTE!",
                ". \r\nSai, sto costruendo un Barchino Divergente!",
                "; \r\nCerto che scoccy è una checca isterica!",
                "... \r\nVorrei essere un insegnante",
                ". \r\nSapete quanto guadagna un muratore?!?",
                "...\r\nDevo andare in Norvegia... Lì tutti lavorano il legno..."
            };
            lblMessaggio.Text = precoda[(new Random(DateTime.UtcNow.Millisecond)).Next(precoda.Length)] + message + accoda[(new Random(DateTime.UtcNow.Millisecond)).Next(accoda.Length)];
            ballon.Visible = lblMessaggio.Visible = true;
            timer1.Enabled = true;
            timer1.Interval = 12000;
            timer1.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string iniFile = Application.StartupPath + "\\configurazioni.ini";

                StreamReader file = new StreamReader(iniFile);
                string contentIniFile = file.ReadToEnd();
                file.Close();
                configurazioni = Configurazione.getConfigurazioni(contentIniFile);
                if (configurazioni == null)
                {
                    ShowBallonMessage("Non posso aprire il file delle configurazioni");
                    //MessageBox.Show("Impossibile importare configurazioni.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (Configurazione c in configurazioni)
                        cmbConfigurazione.Items.Add(c.nome);
                }
            }
            catch(Exception ex)
            {
                ShowBallonMessage(ex.Message);
            }

        }
        private void popolaTree(TreeNode node, string thePath)
        {
            if (thePath != "")
            {
                string[] allDirs = Directory.GetDirectories(thePath);
                if (allDirs.Length > 0)
                {
                    foreach (string s in allDirs)
                    {
                        
                        TreeNode tn = new TreeNode(s.Replace(thePath + "\\", ""));
                        DateTime data = File.GetLastWriteTime(s);
                        
                        tn.ToolTipText = " modificato: " + data.ToShortDateString() + " " + data.ToShortTimeString();
                        tn.ImageKey = "dir";
                        tn.Tag = s;
                        node.Nodes.Add(tn);
                        popolaTree(tn, s);
                    }
                }
                string[] all = Directory.GetFiles(thePath);
                if (all.Length > 0)
                {
                    foreach (string s in all)
                    {
                        TreeNode tn = new TreeNode(s.Replace(thePath + "\\", ""));
                        tn.Tag = s;
                        DateTime data = File.GetLastWriteTime(s);
                        tn.ToolTipText += " modificato: " + data.ToShortDateString() + " " + data.ToShortTimeString();
                        node.Nodes.Add(tn);
                    }
                }

            }
        }
        private void checkNodeBackOnly(bool status, TreeNode node)
        {
            node.Checked = status;
            if (node.Parent != null)
            {
                TreeNodeCollection siblings = node.Parent.Nodes;
                bool canDoCheck = true;
                foreach (TreeNode t in siblings)
                    if (t != node && t.Checked && !status)
                        canDoCheck = false;
                if (canDoCheck)
                    checkNodeBackOnly(status, node.Parent);
                
            }
        }
        private void checkNodeForward(bool status, TreeNode node, int level)
        {
            node.Checked = status;
            if (node.Nodes.Count > 0 )
                foreach (TreeNode tn in node.Nodes)
                    checkNodeForward(status, tn, level + 1);
        }
        private void TV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Node.Tag == null) //file
            bool status = !e.Node.Checked;
                checkNodeBackOnly(status, e.Node);
            if (!String.IsNullOrEmpty(e.Node.ImageKey) && e.Node.ImageKey == "dir") {
                checkNodeForward(status, e.Node, 0);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ShowBallonMessage("dovresti scegliere una cartella di destinazione");
                FB.ShowDialog();
                string destination = FB.SelectedPath;
                if (destination != selectedPath)
                {
                    string theBase = destination;
                    TreeNode root = TV.Nodes[0];
                    foreach (TreeNode tn in root.Nodes)
                    {
                        creaTree(tn, theBase);

                    }
                }
                ShowBallonMessage("l'operazione è terminata con successo!");

            }
            catch (Exception ex)
            {
                ShowBallonMessage(ex.Message);
            }
        }

        private void creaTree(TreeNode t, string basePath)
        {
            string path = basePath + "\\" + t.Text;
            if (t.Checked)
            {
                if (String.IsNullOrEmpty(t.ImageKey))
                {
                    //è un file, creo il percorso con la directory
                    Directory.CreateDirectory(basePath);
                    File.Copy(t.Tag.ToString(), path);
                }
                else
                {
                    foreach (TreeNode tn in t.Nodes)
                        creaTree(tn, path);

                }
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            FB.ShowDialog();
            selectedPath = FB.SelectedPath;
            TreeNode radice = TV.Nodes.Add("*root*");

            popolaTree(radice, selectedPath);
        }

        private void TrasferisciFiles()
        {
            if (configurazioni != null && confSelezionata != -1)
            {
                Configurazione c = configurazioni[confSelezionata];
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = c.server,
                    UserName = c.user,
                    Password = c.pwd,
                    SshHostKeyFingerprint = c.fingerprint
                };

                string destination = Application.StartupPath + "\\tmp\\";
                try
                {
                    Directory.Delete(destination, true);
                }
                catch(Exception ex)
                {
                }
                //creo la directory tmp se non esistente
                Directory.CreateDirectory(destination);
                try
                {
                    if (destination != selectedPath)
                    {
                        string theBase = destination;
                        TreeNode root = TV.Nodes[0];
                        foreach (TreeNode tn in root.Nodes)
                        {
                            creaTree(tn, theBase);

                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                try
                {
                    using (Session session = new Session())
                    {
                        // Connect
                        session.Open(sessionOptions);
                        TransferOptions transferOptions = new TransferOptions();
                        transferOptions.TransferMode = TransferMode.Binary;
                        foreach (string radiceIstanza in c.radiceIstanze)
                        {
                            TransferOperationResult transferResult;
                            // Upload files
                            transferResult = session.PutFiles(destination + "*", radiceIstanza + "/*", false, transferOptions);
                            transferResult.Check();
                        }
                    }
                }
                catch (Exception ex) { ShowBallonMessage(ex.Message); }

                Directory.Delete(destination, true);
                ShowBallonMessage("l'operazione è terminata con successo!");
            }
            else
                ShowBallonMessage("c'è un problema: devi selezionare un ambiente su cui portare i file. Stai attento, che Michela Brivido si arrabbia.");
        }

        private void cmbConfigurazione_SelectedIndexChanged(object sender, EventArgs e)
        {
            confSelezionata = cmbConfigurazione.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowBallonMessage("questa è un'operazione inqueitante: sto per portare i files!");
            TrasferisciFiles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ballon.Visible = lblMessaggio.Visible = false;
            timer1.Enabled = false;
        }

        private void lblMessaggio_EnabledChanged(object sender, EventArgs e)
        {
            lblMessaggio.BackColor = Color.White;
        }
    }

    /**
     * 
     *FILE DI CONFIGURAZIONE configurazioni.ini:
     *
     *NOME AMBIENTE
     *indirizzo (ip/URL)
     *username
     *password
     *fingerprint
     *[istanze,separate,da,virgola]
     * carattere "-" per 133 volte (funge da separatore)
     */
    public class Configurazione
    {
        public string nome = "";
        public string server = "";
        public string user = "";
        public string pwd = "";
        public string fingerprint = "";
        public string[] radiceIstanze = null;

        public static Configurazione[] getConfigurazioni(string confList)
        {
            try
            {
                List<Configurazione> configs = new List<Configurazione>();

                string[] confs = confList.Split(new String[] { "".PadLeft(133, '-') }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string conf in confs)
                {
                    string[] righe = conf.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    if (righe.Length == 6)
                    {
                        Configurazione c = new Configurazione();
                        c.nome = righe[0];
                        c.server = righe[1];
                        c.user = righe[2];
                        c.pwd = righe[3];
                        c.fingerprint = righe[4];
                        c.radiceIstanze = righe[5].Replace("[", "").Replace("]", "").Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        configs.Add(c);
                    }

                }
                return configs.ToArray();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }

}
