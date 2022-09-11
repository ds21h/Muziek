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
            CmbType = new ComboBox();
            LbType = new Label();
            ChkEnkeleArtiest = new CheckBox();
            ChkEnkeleArtiest.CheckedChanged += new EventHandler(ChkEnkeleArtiest_CheckedChanged);
            LbSingleArtiest = new Label();
            BtnSelect = new Button();
            BtnSelect.Click += new EventHandler(BtnSelect_Click);
            TxtTitel = new TextBox();
            LbTitelH = new Label();
            LbVnrH = new Label();
            LbKantH = new Label();
            PnlHead = new Panel();
            LbPlaatNummer = new Label();
            TxtBron = new TextBox();
            LbBron = new Label();
            PnlFoot = new Panel();
            BtnCancel = new Button();
            BtnCancel.Click += new EventHandler(BtnCancel_Click);
            BtnOK = new Button();
            BtnOK.Click += new EventHandler(BtnOK_Click);
            PnlBody = new Panel();
            LbArtiestH = new Label();
            BtnArtiest = new Button();
            LbArtiest = new Label();
            BtnDown = new Button();
            BtnUp = new Button();
            BtnMin = new Button();
            BtnPlus = new Button();
            LbVnr = new Label();
            LbKant = new Label();
            ScrInhoud = new VScrollBar();
            ScrInhoud.ValueChanged += new EventHandler(ScrInhoud_ValueChanged);
            ChkLabel = new CheckBox();
            ChkLabel.CheckedChanged += new EventHandler(ChkLabel_CheckedChanged);
            PnlHead.SuspendLayout();
            PnlFoot.SuspendLayout();
            PnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // CmbType
            // 
            CmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbType.FormattingEnabled = true;
            CmbType.Location = new Point(52, 9);
            CmbType.Name = "CmbType";
            CmbType.Size = new Size(57, 21);
            CmbType.TabIndex = 0;
            // 
            // LbType
            // 
            LbType.AutoSize = true;
            LbType.Location = new Point(12, 12);
            LbType.Name = "LbType";
            LbType.Size = new Size(34, 13);
            LbType.TabIndex = 1;
            LbType.Text = "Type:";
            // 
            // ChkEnkeleArtiest
            // 
            ChkEnkeleArtiest.AutoSize = true;
            ChkEnkeleArtiest.Checked = true;
            ChkEnkeleArtiest.CheckState = CheckState.Checked;
            ChkEnkeleArtiest.Location = new Point(516, 11);
            ChkEnkeleArtiest.Name = "ChkEnkeleArtiest";
            ChkEnkeleArtiest.Size = new Size(91, 17);
            ChkEnkeleArtiest.TabIndex = 2;
            ChkEnkeleArtiest.Text = "Enkele Artiest";
            ChkEnkeleArtiest.UseVisualStyleBackColor = true;
            // 
            // LbSingleArtiest
            // 
            LbSingleArtiest.AutoSize = true;
            LbSingleArtiest.Location = new Point(307, 12);
            LbSingleArtiest.Name = "LbSingleArtiest";
            LbSingleArtiest.Size = new Size(36, 13);
            LbSingleArtiest.TabIndex = 3;
            LbSingleArtiest.Text = "Artiest";
            // 
            // BtnSelect
            // 
            BtnSelect.Location = new Point(463, 7);
            BtnSelect.Name = "BtnSelect";
            BtnSelect.Size = new Size(31, 23);
            BtnSelect.TabIndex = 4;
            BtnSelect.Text = "....";
            BtnSelect.UseVisualStyleBackColor = true;
            // 
            // TxtTitel
            // 
            TxtTitel.Location = new Point(292, 27);
            TxtTitel.Name = "TxtTitel";
            TxtTitel.Size = new Size(214, 20);
            TxtTitel.TabIndex = 16;
            TxtTitel.Text = "Titel";
            TxtTitel.Visible = false;
            // 
            // LbTitelH
            // 
            LbTitelH.AutoSize = true;
            LbTitelH.Location = new Point(291, 11);
            LbTitelH.Name = "LbTitelH";
            LbTitelH.Size = new Size(27, 13);
            LbTitelH.TabIndex = 13;
            LbTitelH.Text = "Titel";
            // 
            // LbVnrH
            // 
            LbVnrH.AutoSize = true;
            LbVnrH.Location = new Point(34, 11);
            LbVnrH.Name = "LbVnrH";
            LbVnrH.Size = new Size(26, 13);
            LbVnrH.TabIndex = 12;
            LbVnrH.Text = "Vnr.";
            // 
            // LbKantH
            // 
            LbKantH.AutoSize = true;
            LbKantH.Location = new Point(5, 11);
            LbKantH.Name = "LbKantH";
            LbKantH.Size = new Size(29, 13);
            LbKantH.TabIndex = 11;
            LbKantH.Text = "Kant";
            // 
            // PnlHead
            // 
            PnlHead.Controls.Add(ChkLabel);
            PnlHead.Controls.Add(LbPlaatNummer);
            PnlHead.Controls.Add(TxtBron);
            PnlHead.Controls.Add(LbBron);
            PnlHead.Controls.Add(LbType);
            PnlHead.Controls.Add(CmbType);
            PnlHead.Controls.Add(ChkEnkeleArtiest);
            PnlHead.Controls.Add(LbSingleArtiest);
            PnlHead.Controls.Add(BtnSelect);
            PnlHead.Dock = DockStyle.Top;
            PnlHead.Location = new Point(0, 0);
            PnlHead.Name = "PnlHead";
            PnlHead.Size = new Size(628, 67);
            PnlHead.TabIndex = 17;
            // 
            // LbPlaatNummer
            // 
            LbPlaatNummer.AutoSize = true;
            LbPlaatNummer.Location = new Point(115, 12);
            LbPlaatNummer.Name = "LbPlaatNummer";
            LbPlaatNummer.Size = new Size(31, 13);
            LbPlaatNummer.TabIndex = 7;
            LbPlaatNummer.Text = "1234";
            // 
            // TxtBron
            // 
            TxtBron.Location = new Point(53, 35);
            TxtBron.Name = "TxtBron";
            TxtBron.Size = new Size(145, 20);
            TxtBron.TabIndex = 6;
            // 
            // LbBron
            // 
            LbBron.AutoSize = true;
            LbBron.Location = new Point(12, 38);
            LbBron.Name = "LbBron";
            LbBron.Size = new Size(32, 13);
            LbBron.TabIndex = 5;
            LbBron.Text = "Bron:";
            // 
            // PnlFoot
            // 
            PnlFoot.Controls.Add(BtnCancel);
            PnlFoot.Controls.Add(BtnOK);
            PnlFoot.Dock = DockStyle.Bottom;
            PnlFoot.Location = new Point(0, 316);
            PnlFoot.Name = "PnlFoot";
            PnlFoot.Size = new Size(628, 36);
            PnlFoot.TabIndex = 18;
            // 
            // BtnCancel
            // 
            BtnCancel.DialogResult = DialogResult.Cancel;
            BtnCancel.Location = new Point(460, 6);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 23);
            BtnCancel.TabIndex = 1;
            BtnCancel.Text = "Annuleer";
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(541, 6);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 23);
            BtnOK.TabIndex = 0;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            // 
            // PnlBody
            // 
            PnlBody.BackgroundImageLayout = ImageLayout.Zoom;
            PnlBody.Controls.Add(LbArtiestH);
            PnlBody.Controls.Add(BtnArtiest);
            PnlBody.Controls.Add(LbArtiest);
            PnlBody.Controls.Add(BtnDown);
            PnlBody.Controls.Add(BtnUp);
            PnlBody.Controls.Add(BtnMin);
            PnlBody.Controls.Add(BtnPlus);
            PnlBody.Controls.Add(LbVnr);
            PnlBody.Controls.Add(LbKant);
            PnlBody.Controls.Add(ScrInhoud);
            PnlBody.Controls.Add(LbKantH);
            PnlBody.Controls.Add(LbVnrH);
            PnlBody.Controls.Add(LbTitelH);
            PnlBody.Controls.Add(TxtTitel);
            PnlBody.Dock = DockStyle.Fill;
            PnlBody.Location = new Point(0, 67);
            PnlBody.Name = "PnlBody";
            PnlBody.Size = new Size(628, 249);
            PnlBody.TabIndex = 19;
            // 
            // LbArtiestH
            // 
            LbArtiestH.AutoSize = true;
            LbArtiestH.Location = new Point(65, 11);
            LbArtiestH.Name = "LbArtiestH";
            LbArtiestH.Size = new Size(36, 13);
            LbArtiestH.TabIndex = 26;
            LbArtiestH.Text = "Artiest";
            // 
            // BtnArtiest
            // 
            BtnArtiest.Location = new Point(249, 27);
            BtnArtiest.Name = "BtnArtiest";
            BtnArtiest.Size = new Size(28, 20);
            BtnArtiest.TabIndex = 25;
            BtnArtiest.Text = "....";
            BtnArtiest.UseVisualStyleBackColor = true;
            BtnArtiest.Visible = false;
            // 
            // LbArtiest
            // 
            LbArtiest.AutoSize = true;
            LbArtiest.Location = new Point(65, 30);
            LbArtiest.Name = "LbArtiest";
            LbArtiest.Size = new Size(36, 13);
            LbArtiest.TabIndex = 24;
            LbArtiest.Text = "Artiest";
            LbArtiest.Visible = false;
            // 
            // BtnDown
            // 
//            BtnDown.Image = My.Resources.Resources._1449697559_emblem_downloads;
            BtnDown.Location = new Point(582, 27);
            BtnDown.Name = "BtnDown";
            BtnDown.Size = new Size(22, 20);
            BtnDown.TabIndex = 23;
            BtnDown.UseVisualStyleBackColor = true;
            BtnDown.Visible = false;
            // 
            // BtnUp
            // 
//            BtnUp.Image = My.Resources.Resources._1449697517_Stock_Index_Up;
            BtnUp.Location = new Point(559, 27);
            BtnUp.Name = "BtnUp";
            BtnUp.Size = new Size(22, 20);
            BtnUp.TabIndex = 22;
            BtnUp.UseVisualStyleBackColor = true;
            BtnUp.Visible = false;
            // 
            // BtnMin
            // 
//            BtnMin.Image = My.Resources.Resources._1449696978_minus;
            BtnMin.Location = new Point(536, 27);
            BtnMin.Name = "BtnMin";
            BtnMin.Size = new Size(22, 20);
            BtnMin.TabIndex = 21;
            BtnMin.UseVisualStyleBackColor = true;
            BtnMin.Visible = false;
            // 
            // BtnPlus
            // 
//            BtnPlus.Image = My.Resources.Resources._1449696909_plus;
            BtnPlus.Location = new Point(512, 27);
            BtnPlus.Name = "BtnPlus";
            BtnPlus.Size = new Size(22, 20);
            BtnPlus.TabIndex = 20;
            BtnPlus.UseVisualStyleBackColor = true;
            BtnPlus.Visible = false;
            // 
            // LbVnr
            // 
            LbVnr.Location = new Point(39, 30);
            LbVnr.Name = "LbVnr";
            LbVnr.Size = new Size(20, 13);
            LbVnr.TabIndex = 19;
            LbVnr.Text = "1";
            LbVnr.Visible = false;
            // 
            // LbKant
            // 
            LbKant.AutoSize = true;
            LbKant.Location = new Point(12, 30);
            LbKant.Name = "LbKant";
            LbKant.Size = new Size(13, 13);
            LbKant.TabIndex = 18;
            LbKant.Text = "1";
            LbKant.Visible = false;
            // 
            // ScrInhoud
            // 
            ScrInhoud.Dock = DockStyle.Right;
            ScrInhoud.Location = new Point(611, 0);
            ScrInhoud.Name = "ScrInhoud";
            ScrInhoud.Size = new Size(17, 249);
            ScrInhoud.TabIndex = 17;
            ScrInhoud.Visible = false;
            // 
            // ChkLabel
            // 
            ChkLabel.AutoSize = true;
            ChkLabel.Location = new Point(516, 37);
            ChkLabel.Name = "ChkLabel";
            ChkLabel.Size = new Size(87, 17);
            ChkLabel.TabIndex = 8;
            ChkLabel.Text = "Label printen";
            ChkLabel.UseVisualStyleBackColor = true;
            // 
            // FrmPlaat
            // 
            AcceptButton = BtnOK;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancel;
            ClientSize = new Size(628, 352);
            Controls.Add(PnlBody);
            Controls.Add(PnlFoot);
            Controls.Add(PnlHead);
            Name = "FrmPlaat";
            Text = "FrmDrager";
            PnlHead.ResumeLayout(false);
            PnlHead.PerformLayout();
            PnlFoot.ResumeLayout(false);
            PnlBody.ResumeLayout(false);
            PnlBody.PerformLayout();
            Load += new EventHandler(FrmPlaat_Load);
            ResumeLayout(false);

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