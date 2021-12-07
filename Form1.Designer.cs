
namespace Esportatore
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TV = new System.Windows.Forms.TreeView();
            this.FB = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.flavio = new System.Windows.Forms.PictureBox();
            this.cmbConfigurazione = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ballon = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMessaggio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.flavio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon)).BeginInit();
            this.SuspendLayout();
            // 
            // TV
            // 
            this.TV.CheckBoxes = true;
            this.TV.Location = new System.Drawing.Point(12, 278);
            this.TV.Name = "TV";
            this.TV.Size = new System.Drawing.Size(625, 305);
            this.TV.TabIndex = 0;
            this.TV.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_NodeMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 599);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Esporta File Selezionati";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flavio
            // 
            this.flavio.BackColor = System.Drawing.Color.Transparent;
            this.flavio.Image = ((System.Drawing.Image)(resources.GetObject("flavio.Image")));
            this.flavio.Location = new System.Drawing.Point(12, 84);
            this.flavio.Name = "flavio";
            this.flavio.Size = new System.Drawing.Size(130, 188);
            this.flavio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.flavio.TabIndex = 2;
            this.flavio.TabStop = false;
            // 
            // cmbConfigurazione
            // 
            this.cmbConfigurazione.FormattingEnabled = true;
            this.cmbConfigurazione.Location = new System.Drawing.Point(264, 251);
            this.cmbConfigurazione.Name = "cmbConfigurazione";
            this.cmbConfigurazione.Size = new System.Drawing.Size(373, 21);
            this.cmbConfigurazione.TabIndex = 3;
            this.cmbConfigurazione.SelectedIndexChanged += new System.EventHandler(this.cmbConfigurazione_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 599);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(295, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Esporta e trasferisci file selezionati";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ambiente";
            // 
            // ballon
            // 
            this.ballon.BackColor = System.Drawing.Color.Transparent;
            this.ballon.Image = ((System.Drawing.Image)(resources.GetObject("ballon.Image")));
            this.ballon.Location = new System.Drawing.Point(112, 12);
            this.ballon.Name = "ballon";
            this.ballon.Size = new System.Drawing.Size(546, 199);
            this.ballon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballon.TabIndex = 6;
            this.ballon.TabStop = false;
            this.ballon.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMessaggio
            // 
            this.lblMessaggio.AcceptsReturn = true;
            this.lblMessaggio.AcceptsTab = true;
            this.lblMessaggio.BackColor = System.Drawing.Color.White;
            this.lblMessaggio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMessaggio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessaggio.Location = new System.Drawing.Point(210, 59);
            this.lblMessaggio.Multiline = true;
            this.lblMessaggio.Name = "lblMessaggio";
            this.lblMessaggio.ReadOnly = true;
            this.lblMessaggio.Size = new System.Drawing.Size(358, 78);
            this.lblMessaggio.TabIndex = 8;
            this.lblMessaggio.Visible = false;
            this.lblMessaggio.EnabledChanged += new System.EventHandler(this.lblMessaggio_EnabledChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 630);
            this.Controls.Add(this.lblMessaggio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbConfigurazione);
            this.Controls.Add(this.flavio);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TV);
            this.Controls.Add(this.ballon);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SVN E\' MEGLIO";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.flavio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ballon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TV;
        private System.Windows.Forms.FolderBrowserDialog FB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox flavio;
        private System.Windows.Forms.ComboBox cmbConfigurazione;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ballon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox lblMessaggio;
    }
}

