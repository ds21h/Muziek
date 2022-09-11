using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Muziek {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FrmMuziek : Form {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing) {
            try {
                if (disposing && components is not null) {
                    components.Dispose();
                }
            } finally {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent() {
            this.LstArtiest = new System.Windows.Forms.ListBox();
            this.SplMuziek = new System.Windows.Forms.SplitContainer();
            this.PnlHead = new System.Windows.Forms.Panel();
            this.LbArt = new System.Windows.Forms.Label();
            this.TxtArtiest = new System.Windows.Forms.TextBox();
            this.ScrSelectie = new System.Windows.Forms.VScrollBar();
            this.TxtTitelV = new System.Windows.Forms.TextBox();
            this.TxtVnrV = new System.Windows.Forms.TextBox();
            this.TxtKantV = new System.Windows.Forms.TextBox();
            this.TxtNrV = new System.Windows.Forms.TextBox();
            this.TxtTypeV = new System.Windows.Forms.TextBox();
            this.LbTitel = new System.Windows.Forms.Label();
            this.LbVnr = new System.Windows.Forms.Label();
            this.LbKant = new System.Windows.Forms.Label();
            this.LbNr = new System.Windows.Forms.Label();
            this.LbType = new System.Windows.Forms.Label();
            this.LbArtiest = new System.Windows.Forms.Label();
            this.MnuHoofd = new System.Windows.Forms.MenuStrip();
            this.TsmArtiest = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmArtNw = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmArtWz = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmArtVw = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmDrager = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmDrNw = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmDrWz = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmDrVw = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAfdrukken = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmAfdrLb45 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.PrintDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.SplMuziek)).BeginInit();
            this.SplMuziek.Panel1.SuspendLayout();
            this.SplMuziek.Panel2.SuspendLayout();
            this.SplMuziek.SuspendLayout();
            this.PnlHead.SuspendLayout();
            this.MnuHoofd.SuspendLayout();
            this.ToolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstArtiest
            // 
            this.LstArtiest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstArtiest.FormattingEnabled = true;
            this.LstArtiest.HorizontalScrollbar = true;
            this.LstArtiest.Location = new System.Drawing.Point(0, 35);
            this.LstArtiest.Name = "LstArtiest";
            this.LstArtiest.Size = new System.Drawing.Size(207, 266);
            this.LstArtiest.TabIndex = 0;
            this.LstArtiest.SelectedIndexChanged += new System.EventHandler(this.LstArtiest_SelectedIndexChanged);
            // 
            // SplMuziek
            // 
            this.SplMuziek.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SplMuziek.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplMuziek.Location = new System.Drawing.Point(0, 27);
            this.SplMuziek.Name = "SplMuziek";
            // 
            // SplMuziek.Panel1
            // 
            this.SplMuziek.Panel1.Controls.Add(this.LstArtiest);
            this.SplMuziek.Panel1.Controls.Add(this.PnlHead);
            this.SplMuziek.Panel1.Controls.Add(this.TxtArtiest);
            // 
            // SplMuziek.Panel2
            // 
            this.SplMuziek.Panel2.Controls.Add(this.ScrSelectie);
            this.SplMuziek.Panel2.Controls.Add(this.TxtTitelV);
            this.SplMuziek.Panel2.Controls.Add(this.TxtVnrV);
            this.SplMuziek.Panel2.Controls.Add(this.TxtKantV);
            this.SplMuziek.Panel2.Controls.Add(this.TxtNrV);
            this.SplMuziek.Panel2.Controls.Add(this.TxtTypeV);
            this.SplMuziek.Panel2.Controls.Add(this.LbTitel);
            this.SplMuziek.Panel2.Controls.Add(this.LbVnr);
            this.SplMuziek.Panel2.Controls.Add(this.LbKant);
            this.SplMuziek.Panel2.Controls.Add(this.LbNr);
            this.SplMuziek.Panel2.Controls.Add(this.LbType);
            this.SplMuziek.Panel2.Controls.Add(this.LbArtiest);
            this.SplMuziek.Size = new System.Drawing.Size(623, 321);
            this.SplMuziek.SplitterDistance = 207;
            this.SplMuziek.TabIndex = 1;
            // 
            // PnlHead
            // 
            this.PnlHead.Controls.Add(this.LbArt);
            this.PnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHead.Location = new System.Drawing.Point(0, 0);
            this.PnlHead.Name = "PnlHead";
            this.PnlHead.Size = new System.Drawing.Size(207, 35);
            this.PnlHead.TabIndex = 0;
            // 
            // LbArt
            // 
            this.LbArt.AutoSize = true;
            this.LbArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbArt.Location = new System.Drawing.Point(3, 5);
            this.LbArt.Name = "LbArt";
            this.LbArt.Size = new System.Drawing.Size(61, 24);
            this.LbArt.TabIndex = 0;
            this.LbArt.Text = "Artiest";
            // 
            // TxtArtiest
            // 
            this.TxtArtiest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TxtArtiest.Location = new System.Drawing.Point(0, 301);
            this.TxtArtiest.Name = "TxtArtiest";
            this.TxtArtiest.Size = new System.Drawing.Size(207, 20);
            this.TxtArtiest.TabIndex = 0;
            this.TxtArtiest.TextChanged += new System.EventHandler(this.TxtArtiest_TextChanged);
            // 
            // ScrSelectie
            // 
            this.ScrSelectie.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScrSelectie.Location = new System.Drawing.Point(397, 0);
            this.ScrSelectie.Name = "ScrSelectie";
            this.ScrSelectie.Size = new System.Drawing.Size(15, 321);
            this.ScrSelectie.TabIndex = 11;
            this.ScrSelectie.Visible = false;
            this.ScrSelectie.ValueChanged += new System.EventHandler(this.ScrSelectie_ValueChanged);
            // 
            // TxtTitelV
            // 
            this.TxtTitelV.Location = new System.Drawing.Point(131, 51);
            this.TxtTitelV.Name = "TxtTitelV";
            this.TxtTitelV.Size = new System.Drawing.Size(260, 20);
            this.TxtTitelV.TabIndex = 10;
            this.TxtTitelV.Text = "Titel";
            this.TxtTitelV.Visible = false;
            // 
            // TxtVnrV
            // 
            this.TxtVnrV.Location = new System.Drawing.Point(102, 51);
            this.TxtVnrV.Name = "TxtVnrV";
            this.TxtVnrV.Size = new System.Drawing.Size(25, 20);
            this.TxtVnrV.TabIndex = 9;
            this.TxtVnrV.Text = "1";
            this.TxtVnrV.Visible = false;
            // 
            // TxtKantV
            // 
            this.TxtKantV.Location = new System.Drawing.Point(73, 51);
            this.TxtKantV.Name = "TxtKantV";
            this.TxtKantV.Size = new System.Drawing.Size(25, 20);
            this.TxtKantV.TabIndex = 8;
            this.TxtKantV.Text = "1";
            this.TxtKantV.Visible = false;
            // 
            // TxtNrV
            // 
            this.TxtNrV.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtNrV.Location = new System.Drawing.Point(36, 51);
            this.TxtNrV.Name = "TxtNrV";
            this.TxtNrV.Size = new System.Drawing.Size(35, 20);
            this.TxtNrV.TabIndex = 7;
            this.TxtNrV.Text = "1273";
            this.TxtNrV.Visible = false;
            // 
            // TxtTypeV
            // 
            this.TxtTypeV.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TxtTypeV.Enabled = false;
            this.TxtTypeV.Location = new System.Drawing.Point(9, 51);
            this.TxtTypeV.Name = "TxtTypeV";
            this.TxtTypeV.Size = new System.Drawing.Size(25, 20);
            this.TxtTypeV.TabIndex = 6;
            this.TxtTypeV.Text = "S";
            this.TxtTypeV.Visible = false;
            // 
            // LbTitel
            // 
            this.LbTitel.AutoSize = true;
            this.LbTitel.Location = new System.Drawing.Point(130, 35);
            this.LbTitel.Name = "LbTitel";
            this.LbTitel.Size = new System.Drawing.Size(27, 13);
            this.LbTitel.TabIndex = 5;
            this.LbTitel.Text = "Titel";
            this.LbTitel.Visible = false;
            // 
            // LbVnr
            // 
            this.LbVnr.AutoSize = true;
            this.LbVnr.Location = new System.Drawing.Point(102, 35);
            this.LbVnr.Name = "LbVnr";
            this.LbVnr.Size = new System.Drawing.Size(26, 13);
            this.LbVnr.TabIndex = 4;
            this.LbVnr.Text = "Vnr.";
            this.LbVnr.Visible = false;
            // 
            // LbKant
            // 
            this.LbKant.AutoSize = true;
            this.LbKant.Location = new System.Drawing.Point(73, 35);
            this.LbKant.Name = "LbKant";
            this.LbKant.Size = new System.Drawing.Size(29, 13);
            this.LbKant.TabIndex = 3;
            this.LbKant.Text = "Kant";
            this.LbKant.Visible = false;
            // 
            // LbNr
            // 
            this.LbNr.AutoSize = true;
            this.LbNr.Location = new System.Drawing.Point(37, 35);
            this.LbNr.Name = "LbNr";
            this.LbNr.Size = new System.Drawing.Size(21, 13);
            this.LbNr.TabIndex = 2;
            this.LbNr.Text = "Nr.";
            this.LbNr.Visible = false;
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(6, 35);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(31, 13);
            this.LbType.TabIndex = 1;
            this.LbType.Text = "Type";
            this.LbType.Visible = false;
            // 
            // LbArtiest
            // 
            this.LbArtiest.AutoSize = true;
            this.LbArtiest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbArtiest.Location = new System.Drawing.Point(8, 7);
            this.LbArtiest.Name = "LbArtiest";
            this.LbArtiest.Size = new System.Drawing.Size(61, 24);
            this.LbArtiest.TabIndex = 0;
            this.LbArtiest.Text = "Artiest";
            this.LbArtiest.Visible = false;
            // 
            // MnuHoofd
            // 
            this.MnuHoofd.Dock = System.Windows.Forms.DockStyle.None;
            this.MnuHoofd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmArtiest,
            this.TsmDrager,
            this.TsmAfdrukken});
            this.MnuHoofd.Location = new System.Drawing.Point(0, 0);
            this.MnuHoofd.Name = "MnuHoofd";
            this.MnuHoofd.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MnuHoofd.Size = new System.Drawing.Size(623, 24);
            this.MnuHoofd.TabIndex = 12;
            this.MnuHoofd.Text = "MenuStrip1";
            // 
            // TsmArtiest
            // 
            this.TsmArtiest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmArtNw,
            this.TsmArtWz,
            this.TsmArtVw});
            this.TsmArtiest.Name = "TsmArtiest";
            this.TsmArtiest.Size = new System.Drawing.Size(53, 20);
            this.TsmArtiest.Text = "Artiest";
            // 
            // TsmArtNw
            // 
            this.TsmArtNw.Name = "TsmArtNw";
            this.TsmArtNw.Size = new System.Drawing.Size(122, 22);
            this.TsmArtNw.Text = "Nieuw";
            this.TsmArtNw.Click += new System.EventHandler(this.TsmArtNw_Click);
            // 
            // TsmArtWz
            // 
            this.TsmArtWz.Name = "TsmArtWz";
            this.TsmArtWz.Size = new System.Drawing.Size(122, 22);
            this.TsmArtWz.Text = "Wijzig";
            this.TsmArtWz.Click += new System.EventHandler(this.TsmArtWz_Click);
            // 
            // TsmArtVw
            // 
            this.TsmArtVw.Name = "TsmArtVw";
            this.TsmArtVw.Size = new System.Drawing.Size(122, 22);
            this.TsmArtVw.Text = "Verwijder";
            this.TsmArtVw.Click += new System.EventHandler(this.TsmArtVw_Click);
            // 
            // TsmDrager
            // 
            this.TsmDrager.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmDrNw,
            this.TsmDrWz,
            this.TsmDrVw});
            this.TsmDrager.Name = "TsmDrager";
            this.TsmDrager.Size = new System.Drawing.Size(54, 20);
            this.TsmDrager.Text = "Drager";
            // 
            // TsmDrNw
            // 
            this.TsmDrNw.Name = "TsmDrNw";
            this.TsmDrNw.Size = new System.Drawing.Size(122, 22);
            this.TsmDrNw.Text = "Nieuw";
            this.TsmDrNw.Click += new System.EventHandler(this.TsmDrNw_Click);
            // 
            // TsmDrWz
            // 
            this.TsmDrWz.Name = "TsmDrWz";
            this.TsmDrWz.Size = new System.Drawing.Size(122, 22);
            this.TsmDrWz.Text = "Wijzig";
            this.TsmDrWz.Click += new System.EventHandler(this.TsmDrWz_Click);
            // 
            // TsmDrVw
            // 
            this.TsmDrVw.Name = "TsmDrVw";
            this.TsmDrVw.Size = new System.Drawing.Size(122, 22);
            this.TsmDrVw.Text = "Verwijder";
            this.TsmDrVw.Click += new System.EventHandler(this.TsmDrVw_Click);
            // 
            // TsmAfdrukken
            // 
            this.TsmAfdrukken.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmAfdrLb45});
            this.TsmAfdrukken.Name = "TsmAfdrukken";
            this.TsmAfdrukken.Size = new System.Drawing.Size(74, 20);
            this.TsmAfdrukken.Text = "Afdrukken";
            // 
            // TsmAfdrLb45
            // 
            this.TsmAfdrLb45.Name = "TsmAfdrLb45";
            this.TsmAfdrLb45.Size = new System.Drawing.Size(128, 22);
            this.TsmAfdrLb45.Text = "Labels 45T";
            this.TsmAfdrLb45.Click += new System.EventHandler(this.TsmAfdrLb45_Click);
            // 
            // ToolStripContainer1
            // 
            // 
            // ToolStripContainer1.ContentPanel
            // 
            this.ToolStripContainer1.ContentPanel.Size = new System.Drawing.Size(623, 0);
            this.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer1.Name = "ToolStripContainer1";
            this.ToolStripContainer1.Size = new System.Drawing.Size(623, 21);
            this.ToolStripContainer1.TabIndex = 13;
            this.ToolStripContainer1.Text = "ToolStripContainer1";
            // 
            // ToolStripContainer1.TopToolStripPanel
            // 
            this.ToolStripContainer1.TopToolStripPanel.Controls.Add(this.MnuHoofd);
            // 
            // PrintDialog1
            // 
            this.PrintDialog1.UseEXDialog = true;
            // 
            // Muziek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 348);
            this.Controls.Add(this.ToolStripContainer1);
            this.Controls.Add(this.SplMuziek);
            this.MainMenuStrip = this.MnuHoofd;
            this.Name = "Muziek";
            this.Text = "Muziek";
            this.Load += new System.EventHandler(this.Muziek_Load);
            this.Resize += new System.EventHandler(this.Muziek_Resize);
            this.SplMuziek.Panel1.ResumeLayout(false);
            this.SplMuziek.Panel1.PerformLayout();
            this.SplMuziek.Panel2.ResumeLayout(false);
            this.SplMuziek.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplMuziek)).EndInit();
            this.SplMuziek.ResumeLayout(false);
            this.PnlHead.ResumeLayout(false);
            this.PnlHead.PerformLayout();
            this.MnuHoofd.ResumeLayout(false);
            this.MnuHoofd.PerformLayout();
            this.ToolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer1.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer1.ResumeLayout(false);
            this.ToolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }
        internal ListBox LstArtiest;
        internal SplitContainer SplMuziek;
        internal Panel PnlHead;
        internal Label LbArt;
        internal TextBox TxtArtiest;
        internal Label LbArtiest;
        internal Label LbNr;
        internal Label LbType;
        internal Label LbTitel;
        internal Label LbVnr;
        internal Label LbKant;
        internal TextBox TxtTitelV;
        internal TextBox TxtVnrV;
        internal TextBox TxtKantV;
        internal TextBox TxtNrV;
        internal TextBox TxtTypeV;
        internal VScrollBar ScrSelectie;
        internal MenuStrip MnuHoofd;
        internal ToolStripMenuItem TsmArtiest;
        internal ToolStripMenuItem TsmArtNw;
        internal ToolStripMenuItem TsmArtWz;
        internal ToolStripMenuItem TsmArtVw;
        internal ToolStripMenuItem TsmDrager;
        internal ToolStripMenuItem TsmDrNw;
        internal ToolStripMenuItem TsmDrWz;
        internal ToolStripMenuItem TsmDrVw;
        internal ToolStripContainer ToolStripContainer1;
        internal ToolStripMenuItem TsmAfdrukken;
        internal ToolStripMenuItem TsmAfdrLb45;
        internal PrintDialog PrintDialog1;
    }
}