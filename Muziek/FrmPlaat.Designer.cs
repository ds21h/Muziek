using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Muziek {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FrmPlaat : Form {

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
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.LbType = new System.Windows.Forms.Label();
            this.ChkEnkeleArtiest = new System.Windows.Forms.CheckBox();
            this.LbSingleArtiest = new System.Windows.Forms.Label();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.TxtTitel = new System.Windows.Forms.TextBox();
            this.LbTitelH = new System.Windows.Forms.Label();
            this.LbVnrH = new System.Windows.Forms.Label();
            this.LbKantH = new System.Windows.Forms.Label();
            this.PnlHead = new System.Windows.Forms.Panel();
            this.ChkLabel = new System.Windows.Forms.CheckBox();
            this.LbPlaatNummer = new System.Windows.Forms.Label();
            this.TxtBron = new System.Windows.Forms.TextBox();
            this.LbBron = new System.Windows.Forms.Label();
            this.PnlFoot = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.PnlBody = new System.Windows.Forms.Panel();
            this.LbArtiestH = new System.Windows.Forms.Label();
            this.BtnArtiest = new System.Windows.Forms.Button();
            this.LbArtiest = new System.Windows.Forms.Label();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnMin = new System.Windows.Forms.Button();
            this.BtnPlus = new System.Windows.Forms.Button();
            this.LbVnr = new System.Windows.Forms.Label();
            this.LbKant = new System.Windows.Forms.Label();
            this.ScrInhoud = new System.Windows.Forms.VScrollBar();
            this.PnlHead.SuspendLayout();
            this.PnlFoot.SuspendLayout();
            this.PnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbType
            // 
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(61, 10);
            this.CmbType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(66, 23);
            this.CmbType.TabIndex = 0;
            // 
            // LbType
            // 
            this.LbType.AutoSize = true;
            this.LbType.Location = new System.Drawing.Point(14, 14);
            this.LbType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbType.Name = "LbType";
            this.LbType.Size = new System.Drawing.Size(34, 15);
            this.LbType.TabIndex = 1;
            this.LbType.Text = "Type:";
            // 
            // ChkEnkeleArtiest
            // 
            this.ChkEnkeleArtiest.AutoSize = true;
            this.ChkEnkeleArtiest.Checked = true;
            this.ChkEnkeleArtiest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkEnkeleArtiest.Location = new System.Drawing.Point(602, 13);
            this.ChkEnkeleArtiest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChkEnkeleArtiest.Name = "ChkEnkeleArtiest";
            this.ChkEnkeleArtiest.Size = new System.Drawing.Size(97, 19);
            this.ChkEnkeleArtiest.TabIndex = 2;
            this.ChkEnkeleArtiest.Text = "Enkele Artiest";
            this.ChkEnkeleArtiest.UseVisualStyleBackColor = true;
            this.ChkEnkeleArtiest.CheckedChanged += new System.EventHandler(this.ChkEnkeleArtiest_CheckedChanged);
            // 
            // LbSingleArtiest
            // 
            this.LbSingleArtiest.AutoSize = true;
            this.LbSingleArtiest.Location = new System.Drawing.Point(358, 14);
            this.LbSingleArtiest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbSingleArtiest.Name = "LbSingleArtiest";
            this.LbSingleArtiest.Size = new System.Drawing.Size(41, 15);
            this.LbSingleArtiest.TabIndex = 3;
            this.LbSingleArtiest.Text = "Artiest";
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(540, 8);
            this.BtnSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(36, 27);
            this.BtnSelect.TabIndex = 4;
            this.BtnSelect.Text = "....";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // TxtTitel
            // 
            this.TxtTitel.Location = new System.Drawing.Point(341, 31);
            this.TxtTitel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtTitel.Name = "TxtTitel";
            this.TxtTitel.Size = new System.Drawing.Size(249, 23);
            this.TxtTitel.TabIndex = 16;
            this.TxtTitel.Text = "Titel";
            this.TxtTitel.Visible = false;
            // 
            // LbTitelH
            // 
            this.LbTitelH.AutoSize = true;
            this.LbTitelH.Location = new System.Drawing.Point(340, 13);
            this.LbTitelH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbTitelH.Name = "LbTitelH";
            this.LbTitelH.Size = new System.Drawing.Size(29, 15);
            this.LbTitelH.TabIndex = 13;
            this.LbTitelH.Text = "Titel";
            // 
            // LbVnrH
            // 
            this.LbVnrH.AutoSize = true;
            this.LbVnrH.Location = new System.Drawing.Point(40, 13);
            this.LbVnrH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbVnrH.Name = "LbVnrH";
            this.LbVnrH.Size = new System.Drawing.Size(28, 15);
            this.LbVnrH.TabIndex = 12;
            this.LbVnrH.Text = "Vnr.";
            // 
            // LbKantH
            // 
            this.LbKantH.AutoSize = true;
            this.LbKantH.Location = new System.Drawing.Point(6, 13);
            this.LbKantH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbKantH.Name = "LbKantH";
            this.LbKantH.Size = new System.Drawing.Size(31, 15);
            this.LbKantH.TabIndex = 11;
            this.LbKantH.Text = "Kant";
            // 
            // PnlHead
            // 
            this.PnlHead.Controls.Add(this.ChkLabel);
            this.PnlHead.Controls.Add(this.LbPlaatNummer);
            this.PnlHead.Controls.Add(this.TxtBron);
            this.PnlHead.Controls.Add(this.LbBron);
            this.PnlHead.Controls.Add(this.LbType);
            this.PnlHead.Controls.Add(this.CmbType);
            this.PnlHead.Controls.Add(this.ChkEnkeleArtiest);
            this.PnlHead.Controls.Add(this.LbSingleArtiest);
            this.PnlHead.Controls.Add(this.BtnSelect);
            this.PnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHead.Location = new System.Drawing.Point(0, 0);
            this.PnlHead.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlHead.Name = "PnlHead";
            this.PnlHead.Size = new System.Drawing.Size(733, 77);
            this.PnlHead.TabIndex = 17;
            // 
            // ChkLabel
            // 
            this.ChkLabel.AutoSize = true;
            this.ChkLabel.Location = new System.Drawing.Point(602, 43);
            this.ChkLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChkLabel.Name = "ChkLabel";
            this.ChkLabel.Size = new System.Drawing.Size(95, 19);
            this.ChkLabel.TabIndex = 8;
            this.ChkLabel.Text = "Label printen";
            this.ChkLabel.UseVisualStyleBackColor = true;
            this.ChkLabel.CheckedChanged += new System.EventHandler(this.ChkLabel_CheckedChanged);
            // 
            // LbPlaatNummer
            // 
            this.LbPlaatNummer.AutoSize = true;
            this.LbPlaatNummer.Location = new System.Drawing.Point(134, 14);
            this.LbPlaatNummer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbPlaatNummer.Name = "LbPlaatNummer";
            this.LbPlaatNummer.Size = new System.Drawing.Size(31, 15);
            this.LbPlaatNummer.TabIndex = 7;
            this.LbPlaatNummer.Text = "1234";
            // 
            // TxtBron
            // 
            this.TxtBron.Location = new System.Drawing.Point(62, 40);
            this.TxtBron.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtBron.Name = "TxtBron";
            this.TxtBron.Size = new System.Drawing.Size(168, 23);
            this.TxtBron.TabIndex = 6;
            // 
            // LbBron
            // 
            this.LbBron.AutoSize = true;
            this.LbBron.Location = new System.Drawing.Point(14, 44);
            this.LbBron.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbBron.Name = "LbBron";
            this.LbBron.Size = new System.Drawing.Size(35, 15);
            this.LbBron.TabIndex = 5;
            this.LbBron.Text = "Bron:";
            // 
            // PnlFoot
            // 
            this.PnlFoot.Controls.Add(this.BtnCancel);
            this.PnlFoot.Controls.Add(this.BtnOK);
            this.PnlFoot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFoot.Location = new System.Drawing.Point(0, 364);
            this.PnlFoot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlFoot.Name = "PnlFoot";
            this.PnlFoot.Size = new System.Drawing.Size(733, 42);
            this.PnlFoot.TabIndex = 18;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(537, 7);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(88, 27);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Annuleer";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(631, 7);
            this.BtnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(88, 27);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // PnlBody
            // 
            this.PnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PnlBody.Controls.Add(this.LbArtiestH);
            this.PnlBody.Controls.Add(this.BtnArtiest);
            this.PnlBody.Controls.Add(this.LbArtiest);
            this.PnlBody.Controls.Add(this.BtnDown);
            this.PnlBody.Controls.Add(this.BtnUp);
            this.PnlBody.Controls.Add(this.BtnMin);
            this.PnlBody.Controls.Add(this.BtnPlus);
            this.PnlBody.Controls.Add(this.LbVnr);
            this.PnlBody.Controls.Add(this.LbKant);
            this.PnlBody.Controls.Add(this.ScrInhoud);
            this.PnlBody.Controls.Add(this.LbKantH);
            this.PnlBody.Controls.Add(this.LbVnrH);
            this.PnlBody.Controls.Add(this.LbTitelH);
            this.PnlBody.Controls.Add(this.TxtTitel);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 77);
            this.PnlBody.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(733, 287);
            this.PnlBody.TabIndex = 19;
            // 
            // LbArtiestH
            // 
            this.LbArtiestH.AutoSize = true;
            this.LbArtiestH.Location = new System.Drawing.Point(76, 13);
            this.LbArtiestH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbArtiestH.Name = "LbArtiestH";
            this.LbArtiestH.Size = new System.Drawing.Size(41, 15);
            this.LbArtiestH.TabIndex = 26;
            this.LbArtiestH.Text = "Artiest";
            // 
            // BtnArtiest
            // 
            this.BtnArtiest.Location = new System.Drawing.Point(290, 31);
            this.BtnArtiest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnArtiest.Name = "BtnArtiest";
            this.BtnArtiest.Size = new System.Drawing.Size(33, 23);
            this.BtnArtiest.TabIndex = 25;
            this.BtnArtiest.Text = "....";
            this.BtnArtiest.UseVisualStyleBackColor = true;
            this.BtnArtiest.Visible = false;
            // 
            // LbArtiest
            // 
            this.LbArtiest.AutoSize = true;
            this.LbArtiest.Location = new System.Drawing.Point(76, 35);
            this.LbArtiest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbArtiest.Name = "LbArtiest";
            this.LbArtiest.Size = new System.Drawing.Size(41, 15);
            this.LbArtiest.TabIndex = 24;
            this.LbArtiest.Text = "Artiest";
            this.LbArtiest.Visible = false;
            // 
            // BtnDown
            // 
            this.BtnDown.Image = global::Muziek.MuziekRes._1449697559_emblem_downloads;
            this.BtnDown.Location = new System.Drawing.Point(679, 31);
            this.BtnDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(26, 23);
            this.BtnDown.TabIndex = 23;
            this.BtnDown.UseVisualStyleBackColor = true;
            this.BtnDown.Visible = false;
            // 
            // BtnUp
            // 
            this.BtnUp.Image = global::Muziek.MuziekRes._1449697517_Stock_Index_Up;
            this.BtnUp.Location = new System.Drawing.Point(652, 31);
            this.BtnUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(26, 23);
            this.BtnUp.TabIndex = 22;
            this.BtnUp.UseVisualStyleBackColor = true;
            this.BtnUp.Visible = false;
            // 
            // BtnMin
            // 
            this.BtnMin.Image = global::Muziek.MuziekRes._1449696978_minus;
            this.BtnMin.Location = new System.Drawing.Point(625, 31);
            this.BtnMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnMin.Name = "BtnMin";
            this.BtnMin.Size = new System.Drawing.Size(26, 23);
            this.BtnMin.TabIndex = 21;
            this.BtnMin.UseVisualStyleBackColor = true;
            this.BtnMin.Visible = false;
            // 
            // BtnPlus
            // 
            this.BtnPlus.Image = global::Muziek.MuziekRes._1449696909_plus;
            this.BtnPlus.Location = new System.Drawing.Point(597, 31);
            this.BtnPlus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnPlus.Name = "BtnPlus";
            this.BtnPlus.Size = new System.Drawing.Size(26, 23);
            this.BtnPlus.TabIndex = 20;
            this.BtnPlus.UseVisualStyleBackColor = true;
            this.BtnPlus.Visible = false;
            // 
            // LbVnr
            // 
            this.LbVnr.Location = new System.Drawing.Point(46, 35);
            this.LbVnr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbVnr.Name = "LbVnr";
            this.LbVnr.Size = new System.Drawing.Size(23, 15);
            this.LbVnr.TabIndex = 19;
            this.LbVnr.Text = "1";
            this.LbVnr.Visible = false;
            // 
            // LbKant
            // 
            this.LbKant.AutoSize = true;
            this.LbKant.Location = new System.Drawing.Point(14, 35);
            this.LbKant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LbKant.Name = "LbKant";
            this.LbKant.Size = new System.Drawing.Size(13, 15);
            this.LbKant.TabIndex = 18;
            this.LbKant.Text = "1";
            this.LbKant.Visible = false;
            // 
            // ScrInhoud
            // 
            this.ScrInhoud.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScrInhoud.Location = new System.Drawing.Point(716, 0);
            this.ScrInhoud.Name = "ScrInhoud";
            this.ScrInhoud.Size = new System.Drawing.Size(17, 287);
            this.ScrInhoud.TabIndex = 17;
            this.ScrInhoud.Visible = false;
            this.ScrInhoud.ValueChanged += new System.EventHandler(this.ScrInhoud_ValueChanged);
            // 
            // FrmPlaat
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(733, 406);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.PnlFoot);
            this.Controls.Add(this.PnlHead);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmPlaat";
            this.Text = "FrmDrager";
            this.Load += new System.EventHandler(this.FrmPlaat_Load);
            this.PnlHead.ResumeLayout(false);
            this.PnlHead.PerformLayout();
            this.PnlFoot.ResumeLayout(false);
            this.PnlBody.ResumeLayout(false);
            this.PnlBody.PerformLayout();
            this.ResumeLayout(false);

        }

        internal ComboBox CmbType;
        internal Label LbType;
        internal CheckBox ChkEnkeleArtiest;
        internal Label LbSingleArtiest;
        internal Button BtnSelect;
        internal TextBox TxtTitel;
        internal Label LbTitelH;
        internal Label LbVnrH;
        internal Label LbKantH;
        internal Panel PnlHead;
        internal Panel PnlFoot;
        internal Panel PnlBody;
        internal VScrollBar ScrInhoud;
        internal Label LbKant;
        internal Button BtnMin;
        internal Button BtnPlus;
        internal Label LbVnr;
        internal Button BtnDown;
        internal Button BtnUp;
        internal TextBox TxtBron;
        internal Label LbBron;
        internal Button BtnCancel;
        internal Button BtnOK;
        internal Label LbPlaatNummer;
        internal Label LbArtiest;
        internal Label LbArtiestH;
        internal Button BtnArtiest;
        internal CheckBox ChkLabel;
    }
}