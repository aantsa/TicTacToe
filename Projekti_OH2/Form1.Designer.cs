namespace Projekti_OH2
{
    partial class frmTicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTicTacToe));
            this.msNavigointi = new System.Windows.Forms.MenuStrip();
            this.stripAloita = new System.Windows.Forms.ToolStripMenuItem();
            this.stripUusiPeli = new System.Windows.Forms.ToolStripMenuItem();
            this.stripSulje = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAsetukset = new System.Windows.Forms.ToolStripMenuItem();
            this.stripTietoa = new System.Windows.Forms.ToolStripMenuItem();
            this.ohjeetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.panelFouri = new System.Windows.Forms.Panel();
            this.panelSix = new System.Windows.Forms.Panel();
            this.panelNine = new System.Windows.Forms.Panel();
            this.panelFive = new System.Windows.Forms.Panel();
            this.panelEight = new System.Windows.Forms.Panel();
            this.panelThree = new System.Windows.Forms.Panel();
            this.panelOne = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFour = new System.Windows.Forms.Panel();
            this.panelTwo = new System.Windows.Forms.Panel();
            this.panelSeven = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAloita = new System.Windows.Forms.Label();
            this.lblEtunimi = new System.Windows.Forms.Label();
            this.lblSyntymaVuosi = new System.Windows.Forms.Label();
            this.lblSukunimi = new System.Windows.Forms.Label();
            this.tbEtunimi = new System.Windows.Forms.TextBox();
            this.tbSukunimi = new System.Windows.Forms.TextBox();
            this.tbSyntymaVuosi = new System.Windows.Forms.TextBox();
            this.btnAloita = new System.Windows.Forms.Button();
            this.statusStrippi = new System.Windows.Forms.StatusStrip();
            this.statusVuoro = new System.Windows.Forms.ToolStripStatusLabel();
            this.chTietokone = new System.Windows.Forms.CheckBox();
            this.chKaksinTaistelu = new System.Windows.Forms.CheckBox();
            this.lblValitse = new System.Windows.Forms.Label();
            this.epSyntymavuosi = new System.Windows.Forms.ErrorProvider(this.components);
            this.epEtunimi = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSukunimi = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbEtunimi2 = new System.Windows.Forms.TextBox();
            this.tbSyntymaVuosi2 = new System.Windows.Forms.TextBox();
            this.tbSukunimi2 = new System.Windows.Forms.TextBox();
            this.lblPelaaja1 = new System.Windows.Forms.Label();
            this.lblPelaaja2 = new System.Windows.Forms.Label();
            this.epEtunimi2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSukunimi2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSyntymaVuosi2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblPelaaja1Vuoro = new System.Windows.Forms.Label();
            this.lblPelaaja2Vuoro = new System.Windows.Forms.Label();
            this.lblVuoro = new System.Windows.Forms.Label();
            this.lblOnneksiOlkoon = new System.Windows.Forms.Label();
            this.TimerTietokone = new System.Windows.Forms.Timer(this.components);
            this.lblEiVoittajaa = new System.Windows.Forms.Label();
            this.dgvHenkilot = new System.Windows.Forms.DataGridView();
            this.btnSyotaTiedot = new System.Windows.Forms.Button();
            this.timerMiettii = new System.Windows.Forms.Timer(this.components);
            this.lblTietokoneMiettii = new System.Windows.Forms.Label();
            this.lblTietokoneVoitti = new System.Windows.Forms.Label();
            this.timerKesto = new System.Windows.Forms.Timer(this.components);
            this.msNavigointi.SuspendLayout();
            this.panelCanvas.SuspendLayout();
            this.panelOne.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSeven.SuspendLayout();
            this.statusStrippi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSyntymavuosi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEtunimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSukunimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEtunimi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSukunimi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSyntymaVuosi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHenkilot)).BeginInit();
            this.SuspendLayout();
            // 
            // msNavigointi
            // 
            this.msNavigointi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msNavigointi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripAloita,
            this.stripAsetukset});
            this.msNavigointi.Location = new System.Drawing.Point(0, 0);
            this.msNavigointi.Name = "msNavigointi";
            this.msNavigointi.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.msNavigointi.Size = new System.Drawing.Size(556, 24);
            this.msNavigointi.TabIndex = 0;
            this.msNavigointi.Text = "menuStrip1";
            // 
            // stripAloita
            // 
            this.stripAloita.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripUusiPeli,
            this.stripSulje});
            this.stripAloita.Name = "stripAloita";
            this.stripAloita.Size = new System.Drawing.Size(65, 20);
            this.stripAloita.Text = "Tiedosto";
            // 
            // stripUusiPeli
            // 
            this.stripUusiPeli.Name = "stripUusiPeli";
            this.stripUusiPeli.Size = new System.Drawing.Size(119, 22);
            this.stripUusiPeli.Text = "Uusi peli";
            this.stripUusiPeli.Click += new System.EventHandler(this.StripUusiPeli_Click);
            // 
            // stripSulje
            // 
            this.stripSulje.Name = "stripSulje";
            this.stripSulje.Size = new System.Drawing.Size(119, 22);
            this.stripSulje.Text = "Sulje";
            this.stripSulje.Click += new System.EventHandler(this.StripSulje_Click);
            // 
            // stripAsetukset
            // 
            this.stripAsetukset.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripTietoa,
            this.ohjeetToolStripMenuItem});
            this.stripAsetukset.Name = "stripAsetukset";
            this.stripAsetukset.Size = new System.Drawing.Size(70, 20);
            this.stripAsetukset.Text = "Asetukset";
            // 
            // stripTietoa
            // 
            this.stripTietoa.Name = "stripTietoa";
            this.stripTietoa.Size = new System.Drawing.Size(109, 22);
            this.stripTietoa.Text = "Tietoa";
            this.stripTietoa.Click += new System.EventHandler(this.StripTietoa_Click);
            // 
            // ohjeetToolStripMenuItem
            // 
            this.ohjeetToolStripMenuItem.Name = "ohjeetToolStripMenuItem";
            this.ohjeetToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.ohjeetToolStripMenuItem.Text = "Ohjeet";
            this.ohjeetToolStripMenuItem.Click += new System.EventHandler(this.OhjeetToolStripMenuItem_Click);
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.Color.Transparent;
            this.panelCanvas.Controls.Add(this.panelFouri);
            this.panelCanvas.Controls.Add(this.panelSix);
            this.panelCanvas.Controls.Add(this.panelNine);
            this.panelCanvas.Controls.Add(this.panelFive);
            this.panelCanvas.Controls.Add(this.panelEight);
            this.panelCanvas.Controls.Add(this.panelThree);
            this.panelCanvas.Controls.Add(this.panelOne);
            this.panelCanvas.Controls.Add(this.panelTwo);
            this.panelCanvas.Controls.Add(this.panelSeven);
            this.panelCanvas.Location = new System.Drawing.Point(37, 187);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(478, 420);
            this.panelCanvas.TabIndex = 1;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCanvas_Paint);
            // 
            // panelFouri
            // 
            this.panelFouri.BackColor = System.Drawing.Color.Transparent;
            this.panelFouri.Location = new System.Drawing.Point(0, 140);
            this.panelFouri.Name = "panelFouri";
            this.panelFouri.Size = new System.Drawing.Size(159, 140);
            this.panelFouri.TabIndex = 6;
            this.panelFouri.Click += new System.EventHandler(this.PanelFivee_Click);
            // 
            // panelSix
            // 
            this.panelSix.BackColor = System.Drawing.Color.Transparent;
            this.panelSix.Location = new System.Drawing.Point(319, 140);
            this.panelSix.Name = "panelSix";
            this.panelSix.Size = new System.Drawing.Size(159, 140);
            this.panelSix.TabIndex = 5;
            this.panelSix.Click += new System.EventHandler(this.PanelSix_Click);
            // 
            // panelNine
            // 
            this.panelNine.BackColor = System.Drawing.Color.Transparent;
            this.panelNine.Location = new System.Drawing.Point(319, 280);
            this.panelNine.Name = "panelNine";
            this.panelNine.Size = new System.Drawing.Size(159, 140);
            this.panelNine.TabIndex = 4;
            this.panelNine.Click += new System.EventHandler(this.PanelNine_Click);
            // 
            // panelFive
            // 
            this.panelFive.BackColor = System.Drawing.Color.Transparent;
            this.panelFive.Location = new System.Drawing.Point(160, 140);
            this.panelFive.Name = "panelFive";
            this.panelFive.Size = new System.Drawing.Size(159, 140);
            this.panelFive.TabIndex = 3;
            this.panelFive.Click += new System.EventHandler(this.PanelFive_Click);
            // 
            // panelEight
            // 
            this.panelEight.BackColor = System.Drawing.Color.Transparent;
            this.panelEight.Location = new System.Drawing.Point(160, 280);
            this.panelEight.Name = "panelEight";
            this.panelEight.Size = new System.Drawing.Size(159, 140);
            this.panelEight.TabIndex = 2;
            this.panelEight.Click += new System.EventHandler(this.PanelEight_Click);
            // 
            // panelThree
            // 
            this.panelThree.BackColor = System.Drawing.Color.Transparent;
            this.panelThree.Location = new System.Drawing.Point(319, 0);
            this.panelThree.Name = "panelThree";
            this.panelThree.Size = new System.Drawing.Size(159, 140);
            this.panelThree.TabIndex = 1;
            this.panelThree.Click += new System.EventHandler(this.PanelThree_Click);
            // 
            // panelOne
            // 
            this.panelOne.BackColor = System.Drawing.Color.Transparent;
            this.panelOne.Controls.Add(this.panel2);
            this.panelOne.Controls.Add(this.panel1);
            this.panelOne.Controls.Add(this.panelFour);
            this.panelOne.Location = new System.Drawing.Point(3, 0);
            this.panelOne.Name = "panelOne";
            this.panelOne.Size = new System.Drawing.Size(159, 140);
            this.panelOne.TabIndex = 1;
            this.panelOne.Click += new System.EventHandler(this.PanelOne_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSalmon;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(0, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 140);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Location = new System.Drawing.Point(0, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(159, 140);
            this.panel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Location = new System.Drawing.Point(0, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(159, 140);
            this.panel1.TabIndex = 2;
            // 
            // panelFour
            // 
            this.panelFour.BackColor = System.Drawing.Color.Transparent;
            this.panelFour.Location = new System.Drawing.Point(0, 140);
            this.panelFour.Name = "panelFour";
            this.panelFour.Size = new System.Drawing.Size(159, 140);
            this.panelFour.TabIndex = 0;
            // 
            // panelTwo
            // 
            this.panelTwo.BackColor = System.Drawing.Color.Transparent;
            this.panelTwo.Location = new System.Drawing.Point(163, 0);
            this.panelTwo.Name = "panelTwo";
            this.panelTwo.Size = new System.Drawing.Size(159, 140);
            this.panelTwo.TabIndex = 0;
            this.panelTwo.Click += new System.EventHandler(this.PanelTwo_Click);
            // 
            // panelSeven
            // 
            this.panelSeven.BackColor = System.Drawing.Color.Transparent;
            this.panelSeven.Controls.Add(this.panel5);
            this.panelSeven.Location = new System.Drawing.Point(3, 280);
            this.panelSeven.Name = "panelSeven";
            this.panelSeven.Size = new System.Drawing.Size(159, 140);
            this.panelSeven.TabIndex = 1;
            this.panelSeven.Click += new System.EventHandler(this.PanelSeven_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkRed;
            this.panel5.Location = new System.Drawing.Point(0, 146);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(159, 140);
            this.panel5.TabIndex = 2;
            // 
            // lblAloita
            // 
            this.lblAloita.AutoSize = true;
            this.lblAloita.Font = new System.Drawing.Font("Candara", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAloita.Location = new System.Drawing.Point(102, 41);
            this.lblAloita.Name = "lblAloita";
            this.lblAloita.Size = new System.Drawing.Size(364, 36);
            this.lblAloita.TabIndex = 2;
            this.lblAloita.Text = "Aloita peli syöttämällä tietosi";
            // 
            // lblEtunimi
            // 
            this.lblEtunimi.AutoSize = true;
            this.lblEtunimi.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEtunimi.Location = new System.Drawing.Point(10, 93);
            this.lblEtunimi.Name = "lblEtunimi";
            this.lblEtunimi.Size = new System.Drawing.Size(71, 23);
            this.lblEtunimi.TabIndex = 3;
            this.lblEtunimi.Text = "Etunimi";
            // 
            // lblSyntymaVuosi
            // 
            this.lblSyntymaVuosi.AutoSize = true;
            this.lblSyntymaVuosi.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSyntymaVuosi.Location = new System.Drawing.Point(10, 145);
            this.lblSyntymaVuosi.Name = "lblSyntymaVuosi";
            this.lblSyntymaVuosi.Size = new System.Drawing.Size(122, 23);
            this.lblSyntymaVuosi.TabIndex = 4;
            this.lblSyntymaVuosi.Text = "Syntymävuosi";
            // 
            // lblSukunimi
            // 
            this.lblSukunimi.AutoSize = true;
            this.lblSukunimi.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSukunimi.Location = new System.Drawing.Point(10, 120);
            this.lblSukunimi.Name = "lblSukunimi";
            this.lblSukunimi.Size = new System.Drawing.Size(83, 23);
            this.lblSukunimi.TabIndex = 5;
            this.lblSukunimi.Text = "Sukunimi";
            // 
            // tbEtunimi
            // 
            this.tbEtunimi.Location = new System.Drawing.Point(129, 99);
            this.tbEtunimi.Name = "tbEtunimi";
            this.tbEtunimi.Size = new System.Drawing.Size(97, 20);
            this.tbEtunimi.TabIndex = 1;
            this.tbEtunimi.Validating += new System.ComponentModel.CancelEventHandler(this.TbEtunimi_Validating);
            this.tbEtunimi.Validated += new System.EventHandler(this.TbEtunimi_Validated);
            // 
            // tbSukunimi
            // 
            this.tbSukunimi.Location = new System.Drawing.Point(129, 124);
            this.tbSukunimi.Name = "tbSukunimi";
            this.tbSukunimi.Size = new System.Drawing.Size(97, 20);
            this.tbSukunimi.TabIndex = 2;
            this.tbSukunimi.Validating += new System.ComponentModel.CancelEventHandler(this.TbSukunimi_Validating);
            this.tbSukunimi.Validated += new System.EventHandler(this.TbSukunimi_Validated);
            // 
            // tbSyntymaVuosi
            // 
            this.tbSyntymaVuosi.Location = new System.Drawing.Point(129, 150);
            this.tbSyntymaVuosi.Name = "tbSyntymaVuosi";
            this.tbSyntymaVuosi.Size = new System.Drawing.Size(97, 20);
            this.tbSyntymaVuosi.TabIndex = 3;
            this.tbSyntymaVuosi.Validating += new System.ComponentModel.CancelEventHandler(this.TbSyntymaVuosi_Validating);
            this.tbSyntymaVuosi.Validated += new System.EventHandler(this.TbSyntymaVuosi_Validated);
            // 
            // btnAloita
            // 
            this.btnAloita.Font = new System.Drawing.Font("Candara", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAloita.Location = new System.Drawing.Point(466, 113);
            this.btnAloita.Name = "btnAloita";
            this.btnAloita.Size = new System.Drawing.Size(79, 37);
            this.btnAloita.TabIndex = 9;
            this.btnAloita.Text = "Aloita!";
            this.btnAloita.UseVisualStyleBackColor = true;
            this.btnAloita.Click += new System.EventHandler(this.BtnAloita_Click);
            // 
            // statusStrippi
            // 
            this.statusStrippi.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrippi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusVuoro});
            this.statusStrippi.Location = new System.Drawing.Point(0, 647);
            this.statusStrippi.Name = "statusStrippi";
            this.statusStrippi.Size = new System.Drawing.Size(556, 22);
            this.statusStrippi.TabIndex = 10;
            this.statusStrippi.Text = "statusStrip1";
            // 
            // statusVuoro
            // 
            this.statusVuoro.Font = new System.Drawing.Font("Candara", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusVuoro.ForeColor = System.Drawing.Color.Black;
            this.statusVuoro.Name = "statusVuoro";
            this.statusVuoro.Size = new System.Drawing.Size(76, 17);
            this.statusVuoro.Text = "Anton vuoro";
            this.statusVuoro.Visible = false;
            // 
            // chTietokone
            // 
            this.chTietokone.AutoSize = true;
            this.chTietokone.Location = new System.Drawing.Point(375, 104);
            this.chTietokone.Name = "chTietokone";
            this.chTietokone.Size = new System.Drawing.Size(74, 17);
            this.chTietokone.TabIndex = 7;
            this.chTietokone.Text = "Tietokone";
            this.chTietokone.UseVisualStyleBackColor = true;
            this.chTietokone.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // chKaksinTaistelu
            // 
            this.chKaksinTaistelu.AutoSize = true;
            this.chKaksinTaistelu.Location = new System.Drawing.Point(375, 127);
            this.chKaksinTaistelu.Name = "chKaksinTaistelu";
            this.chKaksinTaistelu.Size = new System.Drawing.Size(74, 17);
            this.chKaksinTaistelu.TabIndex = 8;
            this.chKaksinTaistelu.Text = "Kaksinpeli";
            this.chKaksinTaistelu.UseVisualStyleBackColor = true;
            this.chKaksinTaistelu.CheckedChanged += new System.EventHandler(this.ChKaksinTaistelu_CheckedChanged);
            // 
            // lblValitse
            // 
            this.lblValitse.AutoSize = true;
            this.lblValitse.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValitse.Location = new System.Drawing.Point(350, 78);
            this.lblValitse.Name = "lblValitse";
            this.lblValitse.Size = new System.Drawing.Size(152, 23);
            this.lblValitse.TabIndex = 13;
            this.lblValitse.Text = "Valitse vastustaja:";
            // 
            // epSyntymavuosi
            // 
            this.epSyntymavuosi.ContainerControl = this;
            // 
            // epEtunimi
            // 
            this.epEtunimi.ContainerControl = this;
            // 
            // epSukunimi
            // 
            this.epSukunimi.ContainerControl = this;
            // 
            // tbEtunimi2
            // 
            this.tbEtunimi2.Location = new System.Drawing.Point(242, 99);
            this.tbEtunimi2.Margin = new System.Windows.Forms.Padding(2);
            this.tbEtunimi2.Name = "tbEtunimi2";
            this.tbEtunimi2.Size = new System.Drawing.Size(101, 20);
            this.tbEtunimi2.TabIndex = 4;
            this.tbEtunimi2.Validating += new System.ComponentModel.CancelEventHandler(this.TbEtunimi2_Validating);
            this.tbEtunimi2.Validated += new System.EventHandler(this.TbEtunimi2_Validated);
            // 
            // tbSyntymaVuosi2
            // 
            this.tbSyntymaVuosi2.Location = new System.Drawing.Point(242, 150);
            this.tbSyntymaVuosi2.Margin = new System.Windows.Forms.Padding(2);
            this.tbSyntymaVuosi2.Name = "tbSyntymaVuosi2";
            this.tbSyntymaVuosi2.Size = new System.Drawing.Size(101, 20);
            this.tbSyntymaVuosi2.TabIndex = 6;
            this.tbSyntymaVuosi2.Validating += new System.ComponentModel.CancelEventHandler(this.TbSyntymaVuosi2_Validating);
            this.tbSyntymaVuosi2.Validated += new System.EventHandler(this.TbSyntymaVuosi2_Validated);
            // 
            // tbSukunimi2
            // 
            this.tbSukunimi2.Location = new System.Drawing.Point(242, 124);
            this.tbSukunimi2.Margin = new System.Windows.Forms.Padding(2);
            this.tbSukunimi2.Name = "tbSukunimi2";
            this.tbSukunimi2.Size = new System.Drawing.Size(101, 20);
            this.tbSukunimi2.TabIndex = 5;
            this.tbSukunimi2.Validating += new System.ComponentModel.CancelEventHandler(this.TbSukunimi2_Validating);
            this.tbSukunimi2.Validated += new System.EventHandler(this.TbSukunimi2_Validated);
            // 
            // lblPelaaja1
            // 
            this.lblPelaaja1.AutoSize = true;
            this.lblPelaaja1.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja1.Location = new System.Drawing.Point(152, 79);
            this.lblPelaaja1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPelaaja1.Name = "lblPelaaja1";
            this.lblPelaaja1.Size = new System.Drawing.Size(58, 17);
            this.lblPelaaja1.TabIndex = 17;
            this.lblPelaaja1.Text = "Pelaaja 1";
            // 
            // lblPelaaja2
            // 
            this.lblPelaaja2.AutoSize = true;
            this.lblPelaaja2.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja2.Location = new System.Drawing.Point(262, 80);
            this.lblPelaaja2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPelaaja2.Name = "lblPelaaja2";
            this.lblPelaaja2.Size = new System.Drawing.Size(59, 17);
            this.lblPelaaja2.TabIndex = 18;
            this.lblPelaaja2.Text = "Pelaaja 2";
            // 
            // epEtunimi2
            // 
            this.epEtunimi2.ContainerControl = this;
            // 
            // epSukunimi2
            // 
            this.epSukunimi2.ContainerControl = this;
            // 
            // epSyntymaVuosi2
            // 
            this.epSyntymaVuosi2.ContainerControl = this;
            // 
            // lblPelaaja1Vuoro
            // 
            this.lblPelaaja1Vuoro.AutoSize = true;
            this.lblPelaaja1Vuoro.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja1Vuoro.Location = new System.Drawing.Point(80, 47);
            this.lblPelaaja1Vuoro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPelaaja1Vuoro.Name = "lblPelaaja1Vuoro";
            this.lblPelaaja1Vuoro.Size = new System.Drawing.Size(91, 27);
            this.lblPelaaja1Vuoro.TabIndex = 19;
            this.lblPelaaja1Vuoro.Text = "Pelaaja 1";
            this.lblPelaaja1Vuoro.Visible = false;
            // 
            // lblPelaaja2Vuoro
            // 
            this.lblPelaaja2Vuoro.AutoSize = true;
            this.lblPelaaja2Vuoro.Font = new System.Drawing.Font("Candara", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelaaja2Vuoro.Location = new System.Drawing.Point(388, 47);
            this.lblPelaaja2Vuoro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPelaaja2Vuoro.Name = "lblPelaaja2Vuoro";
            this.lblPelaaja2Vuoro.Size = new System.Drawing.Size(95, 27);
            this.lblPelaaja2Vuoro.TabIndex = 20;
            this.lblPelaaja2Vuoro.Text = "Pelaaja 2";
            this.lblPelaaja2Vuoro.Visible = false;
            // 
            // lblVuoro
            // 
            this.lblVuoro.AutoSize = true;
            this.lblVuoro.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuoro.ForeColor = System.Drawing.Color.Red;
            this.lblVuoro.Location = new System.Drawing.Point(94, 78);
            this.lblVuoro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVuoro.Name = "lblVuoro";
            this.lblVuoro.Size = new System.Drawing.Size(51, 19);
            this.lblVuoro.TabIndex = 21;
            this.lblVuoro.Text = "Vuoro";
            this.lblVuoro.Visible = false;
            // 
            // lblOnneksiOlkoon
            // 
            this.lblOnneksiOlkoon.AutoSize = true;
            this.lblOnneksiOlkoon.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnneksiOlkoon.ForeColor = System.Drawing.Color.Red;
            this.lblOnneksiOlkoon.Location = new System.Drawing.Point(179, 119);
            this.lblOnneksiOlkoon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOnneksiOlkoon.Name = "lblOnneksiOlkoon";
            this.lblOnneksiOlkoon.Size = new System.Drawing.Size(177, 29);
            this.lblOnneksiOlkoon.TabIndex = 0;
            this.lblOnneksiOlkoon.Text = "Onneksi olkoon!";
            this.lblOnneksiOlkoon.Visible = false;
            // 
            // TimerTietokone
            // 
            this.TimerTietokone.Interval = 1300;
            this.TimerTietokone.Tick += new System.EventHandler(this.TimerTietokone_Tick);
            // 
            // lblEiVoittajaa
            // 
            this.lblEiVoittajaa.AutoSize = true;
            this.lblEiVoittajaa.Font = new System.Drawing.Font("Candara", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEiVoittajaa.ForeColor = System.Drawing.Color.Gray;
            this.lblEiVoittajaa.Location = new System.Drawing.Point(205, 119);
            this.lblEiVoittajaa.Name = "lblEiVoittajaa";
            this.lblEiVoittajaa.Size = new System.Drawing.Size(151, 36);
            this.lblEiVoittajaa.TabIndex = 0;
            this.lblEiVoittajaa.Text = "Ei voittajaa";
            this.lblEiVoittajaa.Visible = false;
            // 
            // dgvHenkilot
            // 
            this.dgvHenkilot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHenkilot.Location = new System.Drawing.Point(25, 244);
            this.dgvHenkilot.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHenkilot.Name = "dgvHenkilot";
            this.dgvHenkilot.RowHeadersWidth = 51;
            this.dgvHenkilot.RowTemplate.Height = 24;
            this.dgvHenkilot.Size = new System.Drawing.Size(508, 381);
            this.dgvHenkilot.TabIndex = 22;
            this.dgvHenkilot.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHenkilot_CellClick);
            // 
            // btnSyotaTiedot
            // 
            this.btnSyotaTiedot.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyotaTiedot.Location = new System.Drawing.Point(370, 150);
            this.btnSyotaTiedot.Margin = new System.Windows.Forms.Padding(2);
            this.btnSyotaTiedot.Name = "btnSyotaTiedot";
            this.btnSyotaTiedot.Size = new System.Drawing.Size(90, 26);
            this.btnSyotaTiedot.TabIndex = 23;
            this.btnSyotaTiedot.Text = "Syötä tiedot";
            this.btnSyotaTiedot.UseVisualStyleBackColor = true;
            this.btnSyotaTiedot.Click += new System.EventHandler(this.BtnSyotaTiedot_Click);
            // 
            // timerMiettii
            // 
            this.timerMiettii.Interval = 300;
            this.timerMiettii.Tick += new System.EventHandler(this.TimerMiettii_Tick);
            // 
            // lblTietokoneMiettii
            // 
            this.lblTietokoneMiettii.AutoSize = true;
            this.lblTietokoneMiettii.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTietokoneMiettii.Location = new System.Drawing.Point(390, 106);
            this.lblTietokoneMiettii.Name = "lblTietokoneMiettii";
            this.lblTietokoneMiettii.Size = new System.Drawing.Size(89, 13);
            this.lblTietokoneMiettii.TabIndex = 24;
            this.lblTietokoneMiettii.Text = "Vastustaja miettii";
            this.lblTietokoneMiettii.Visible = false;
            // 
            // lblTietokoneVoitti
            // 
            this.lblTietokoneVoitti.AutoSize = true;
            this.lblTietokoneVoitti.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTietokoneVoitti.Location = new System.Drawing.Point(371, 93);
            this.lblTietokoneVoitti.Name = "lblTietokoneVoitti";
            this.lblTietokoneVoitti.Size = new System.Drawing.Size(121, 38);
            this.lblTietokoneVoitti.TabIndex = 25;
            this.lblTietokoneVoitti.Text = "Tietokone voitti \r\n         ihmisen";
            this.lblTietokoneVoitti.Visible = false;
            // 
            // timerKesto
            // 
            this.timerKesto.Interval = 1000;
            this.timerKesto.Tick += new System.EventHandler(this.TimerKesto_Tick);
            // 
            // frmTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(556, 669);
            this.Controls.Add(this.lblTietokoneVoitti);
            this.Controls.Add(this.lblTietokoneMiettii);
            this.Controls.Add(this.btnSyotaTiedot);
            this.Controls.Add(this.btnAloita);
            this.Controls.Add(this.dgvHenkilot);
            this.Controls.Add(this.lblEiVoittajaa);
            this.Controls.Add(this.lblOnneksiOlkoon);
            this.Controls.Add(this.lblVuoro);
            this.Controls.Add(this.lblPelaaja2Vuoro);
            this.Controls.Add(this.lblPelaaja1Vuoro);
            this.Controls.Add(this.lblPelaaja2);
            this.Controls.Add(this.lblPelaaja1);
            this.Controls.Add(this.tbSukunimi2);
            this.Controls.Add(this.tbSyntymaVuosi2);
            this.Controls.Add(this.tbEtunimi2);
            this.Controls.Add(this.lblValitse);
            this.Controls.Add(this.chKaksinTaistelu);
            this.Controls.Add(this.chTietokone);
            this.Controls.Add(this.statusStrippi);
            this.Controls.Add(this.tbSyntymaVuosi);
            this.Controls.Add(this.tbSukunimi);
            this.Controls.Add(this.tbEtunimi);
            this.Controls.Add(this.lblSukunimi);
            this.Controls.Add(this.lblSyntymaVuosi);
            this.Controls.Add(this.lblEtunimi);
            this.Controls.Add(this.lblAloita);
            this.Controls.Add(this.panelCanvas);
            this.Controls.Add(this.msNavigointi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msNavigointi;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(572, 708);
            this.MinimumSize = new System.Drawing.Size(572, 708);
            this.Name = "frmTicTacToe";
            this.Text = "TicTacToe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTicTacToe_FormClosing);
            this.Load += new System.EventHandler(this.FrmTicTacToe_Load);
            this.msNavigointi.ResumeLayout(false);
            this.msNavigointi.PerformLayout();
            this.panelCanvas.ResumeLayout(false);
            this.panelOne.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelSeven.ResumeLayout(false);
            this.statusStrippi.ResumeLayout(false);
            this.statusStrippi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epSyntymavuosi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEtunimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSukunimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epEtunimi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSukunimi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSyntymaVuosi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHenkilot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msNavigointi;
        private System.Windows.Forms.ToolStripMenuItem stripAloita;
        private System.Windows.Forms.ToolStripMenuItem stripAsetukset;
        private System.Windows.Forms.ToolStripMenuItem stripUusiPeli;
        private System.Windows.Forms.ToolStripMenuItem stripSulje;
        private System.Windows.Forms.ToolStripMenuItem stripTietoa;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Panel panelOne;
        private System.Windows.Forms.Panel panelSix;
        private System.Windows.Forms.Panel panelNine;
        private System.Windows.Forms.Panel panelFive;
        private System.Windows.Forms.Panel panelEight;
        private System.Windows.Forms.Panel panelThree;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSeven;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelFour;
        private System.Windows.Forms.Panel panelTwo;
        private System.Windows.Forms.Label lblAloita;
        private System.Windows.Forms.Label lblEtunimi;
        private System.Windows.Forms.Label lblSyntymaVuosi;
        private System.Windows.Forms.Label lblSukunimi;
        private System.Windows.Forms.TextBox tbEtunimi;
        private System.Windows.Forms.TextBox tbSukunimi;
        private System.Windows.Forms.TextBox tbSyntymaVuosi;
        private System.Windows.Forms.Button btnAloita;
        private System.Windows.Forms.StatusStrip statusStrippi;
        private System.Windows.Forms.ToolStripStatusLabel statusVuoro;
        private System.Windows.Forms.CheckBox chTietokone;
        private System.Windows.Forms.CheckBox chKaksinTaistelu;
        private System.Windows.Forms.Label lblValitse;
        private System.Windows.Forms.ErrorProvider epSyntymavuosi;
        private System.Windows.Forms.ErrorProvider epEtunimi;
        private System.Windows.Forms.ErrorProvider epSukunimi;
        private System.Windows.Forms.Panel panelFouri;
        private System.Windows.Forms.Label lblPelaaja2;
        private System.Windows.Forms.Label lblPelaaja1;
        private System.Windows.Forms.TextBox tbSukunimi2;
        private System.Windows.Forms.TextBox tbSyntymaVuosi2;
        private System.Windows.Forms.TextBox tbEtunimi2;
        private System.Windows.Forms.ToolStripMenuItem ohjeetToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider epEtunimi2;
        private System.Windows.Forms.ErrorProvider epSukunimi2;
        private System.Windows.Forms.ErrorProvider epSyntymaVuosi2;
        private System.Windows.Forms.Label lblPelaaja2Vuoro;
        private System.Windows.Forms.Label lblPelaaja1Vuoro;
        private System.Windows.Forms.Label lblVuoro;
        private System.Windows.Forms.Label lblOnneksiOlkoon;
        private System.Windows.Forms.Timer TimerTietokone;
        private System.Windows.Forms.Label lblEiVoittajaa;
        private System.Windows.Forms.DataGridView dgvHenkilot;
        private System.Windows.Forms.Button btnSyotaTiedot;
        private System.Windows.Forms.Timer timerMiettii;
        private System.Windows.Forms.Label lblTietokoneMiettii;
        private System.Windows.Forms.Label lblTietokoneVoitti;
        private System.Windows.Forms.Timer timerKesto;
    }
}

