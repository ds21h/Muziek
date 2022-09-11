using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Muziek {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    internal partial class FrmArtiest : Form {

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
            Panel1 = new Panel();
            Panel2 = new Panel();
            BttnOK = new Button();
            BttnOK.Click += new EventHandler(BttnOK_Click);
            BttnCancel = new Button();
            BttnCancel.Click += new EventHandler(BttnCancel_Click);
            LbVoorNaam = new Label();
            LbAchterNaam = new Label();
            TxtVoorNaam = new TextBox();
            TxtVoorNaam.TextChanged += new EventHandler(TxtNaam_TextChanged);
            TxtAchterNaam = new TextBox();
            TxtAchterNaam.TextChanged += new EventHandler(TxtNaam_TextChanged);
            LbNaam = new Label();
            LbArtNummer = new Label();
            LbFout = new Label();
            Panel1.SuspendLayout();
            Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Panel1
            // 
            Panel1.Controls.Add(Panel2);
            Panel1.Dock = DockStyle.Bottom;
            Panel1.Location = new Point(0, 221);
            Panel1.Name = "Panel1";
            Panel1.Size = new Size(478, 34);
            Panel1.TabIndex = 0;
            // 
            // Panel2
            // 
            Panel2.Controls.Add(BttnOK);
            Panel2.Controls.Add(BttnCancel);
            Panel2.Dock = DockStyle.Right;
            Panel2.Location = new Point(315, 0);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(163, 34);
            Panel2.TabIndex = 0;
            // 
            // BttnOK
            // 
            BttnOK.Location = new Point(84, 3);
            BttnOK.Name = "BttnOK";
            BttnOK.Size = new Size(75, 23);
            BttnOK.TabIndex = 0;
            BttnOK.Text = "OK";
            BttnOK.UseVisualStyleBackColor = true;
            // 
            // BttnCancel
            // 
            BttnCancel.DialogResult = DialogResult.Cancel;
            BttnCancel.Location = new Point(3, 3);
            BttnCancel.Name = "BttnCancel";
            BttnCancel.Size = new Size(75, 23);
            BttnCancel.TabIndex = 1;
            BttnCancel.Text = "Cancel";
            BttnCancel.UseVisualStyleBackColor = true;
            // 
            // LbVoorNaam
            // 
            LbVoorNaam.AutoSize = true;
            LbVoorNaam.Location = new Point(12, 37);
            LbVoorNaam.Name = "LbVoorNaam";
            LbVoorNaam.Size = new Size(58, 13);
            LbVoorNaam.TabIndex = 1;
            LbVoorNaam.Text = "Voornaam:";
            // 
            // LbAchterNaam
            // 
            LbAchterNaam.AutoSize = true;
            LbAchterNaam.Location = new Point(12, 63);
            LbAchterNaam.Name = "LbAchterNaam";
            LbAchterNaam.Size = new Size(67, 13);
            LbAchterNaam.TabIndex = 2;
            LbAchterNaam.Text = "Achternaam:";
            // 
            // TxtVoorNaam
            // 
            TxtVoorNaam.Location = new Point(85, 34);
            TxtVoorNaam.Name = "TxtVoorNaam";
            TxtVoorNaam.Size = new Size(100, 20);
            TxtVoorNaam.TabIndex = 3;
            // 
            // TxtAchterNaam
            // 
            TxtAchterNaam.Location = new Point(85, 60);
            TxtAchterNaam.Name = "TxtAchterNaam";
            TxtAchterNaam.Size = new Size(100, 20);
            TxtAchterNaam.TabIndex = 4;
            // 
            // LbNaam
            // 
            LbNaam.AutoSize = true;
            LbNaam.Location = new Point(82, 9);
            LbNaam.Name = "LbNaam";
            LbNaam.Size = new Size(35, 13);
            LbNaam.TabIndex = 5;
            LbNaam.Text = "Naam";
            // 
            // LbArtNummer
            // 
            LbArtNummer.AutoSize = true;
            LbArtNummer.Location = new Point(12, 9);
            LbArtNummer.Name = "LbArtNummer";
            LbArtNummer.Size = new Size(25, 13);
            LbArtNummer.TabIndex = 6;
            LbArtNummer.Text = "123";
            // 
            // LbFout
            // 
            LbFout.AutoSize = true;
            LbFout.Font = new Font("Microsoft Sans Serif", 12.0f, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbFout.ForeColor = Color.Red;
            LbFout.Location = new Point(12, 104);
            LbFout.Name = "LbFout";
            LbFout.Size = new Size(57, 20);
            LbFout.TabIndex = 7;
            LbFout.Text = "Label1";
            LbFout.Visible = false;
            // 
            // FrmArtiest
            // 
            AcceptButton = BttnOK;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BttnCancel;
            ClientSize = new Size(478, 255);
            Controls.Add(LbFout);
            Controls.Add(LbArtNummer);
            Controls.Add(LbNaam);
            Controls.Add(TxtAchterNaam);
            Controls.Add(TxtVoorNaam);
            Controls.Add(LbAchterNaam);
            Controls.Add(LbVoorNaam);
            Controls.Add(Panel1);
            Name = "FrmArtiest";
            Text = "FrmArtiest";
            Panel1.ResumeLayout(false);
            Panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }
        internal Panel Panel1;
        internal Panel Panel2;
        internal Button BttnOK;
        internal Button BttnCancel;
        internal Label LbVoorNaam;
        internal Label LbAchterNaam;
        internal TextBox TxtVoorNaam;
        internal TextBox TxtAchterNaam;
        internal Label LbNaam;
        internal Label LbArtNummer;
        internal Label LbFout;
    }
}