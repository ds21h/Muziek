using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Muziek {
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class FrmSelectArtiest : Form {

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
            LbArt = new Label();
            LstArtiest = new ListBox();
            LstArtiest.SelectedIndexChanged += new EventHandler(LstArtiest_SelectedIndexChanged);
            PnlHead = new Panel();
            TxtArtiest = new TextBox();
            TxtArtiest.TextChanged += new EventHandler(TxtArtiest_TextChanged);
            PnlFoot = new Panel();
            PnlKnoppen = new Panel();
            BtnAnnuleer = new Button();
            BtnAnnuleer.Click += new EventHandler(BtnAnnuleer_Click);
            BtnSelecteer = new Button();
            BtnSelecteer.Click += new EventHandler(BtnSelecteer_Click);
            PnlHead.SuspendLayout();
            PnlFoot.SuspendLayout();
            PnlKnoppen.SuspendLayout();
            SuspendLayout();
            // 
            // LbArt
            // 
            LbArt.AutoSize = true;
            LbArt.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbArt.Location = new Point(3, 5);
            LbArt.Name = "LbArt";
            LbArt.Size = new Size(61, 24);
            LbArt.TabIndex = 0;
            LbArt.Text = "Artiest";
            // 
            // LstArtiest
            // 
            LstArtiest.Dock = DockStyle.Fill;
            LstArtiest.FormattingEnabled = true;
            LstArtiest.HorizontalScrollbar = true;
            LstArtiest.Location = new Point(0, 35);
            LstArtiest.Name = "LstArtiest";
            LstArtiest.Size = new Size(479, 341);
            LstArtiest.TabIndex = 1;
            // 
            // PnlHead
            // 
            PnlHead.Controls.Add(LbArt);
            PnlHead.Dock = DockStyle.Top;
            PnlHead.Location = new Point(0, 0);
            PnlHead.Name = "PnlHead";
            PnlHead.Size = new Size(479, 35);
            PnlHead.TabIndex = 2;
            // 
            // TxtArtiest
            // 
            TxtArtiest.Location = new Point(3, 7);
            TxtArtiest.Name = "TxtArtiest";
            TxtArtiest.Size = new Size(207, 20);
            TxtArtiest.TabIndex = 3;
            // 
            // PnlFoot
            // 
            PnlFoot.Controls.Add(PnlKnoppen);
            PnlFoot.Controls.Add(TxtArtiest);
            PnlFoot.Dock = DockStyle.Bottom;
            PnlFoot.Location = new Point(0, 376);
            PnlFoot.Name = "PnlFoot";
            PnlFoot.Size = new Size(479, 39);
            PnlFoot.TabIndex = 4;
            // 
            // PnlKnoppen
            // 
            PnlKnoppen.Controls.Add(BtnAnnuleer);
            PnlKnoppen.Controls.Add(BtnSelecteer);
            PnlKnoppen.Dock = DockStyle.Right;
            PnlKnoppen.Location = new Point(305, 0);
            PnlKnoppen.Name = "PnlKnoppen";
            PnlKnoppen.Size = new Size(174, 39);
            PnlKnoppen.TabIndex = 5;
            // 
            // BtnAnnuleer
            // 
            BtnAnnuleer.DialogResult = DialogResult.Cancel;
            BtnAnnuleer.Location = new Point(12, 5);
            BtnAnnuleer.Name = "BtnAnnuleer";
            BtnAnnuleer.Size = new Size(75, 23);
            BtnAnnuleer.TabIndex = 5;
            BtnAnnuleer.Text = "Annuleren";
            BtnAnnuleer.UseVisualStyleBackColor = true;
            // 
            // BtnSelecteer
            // 
            BtnSelecteer.Location = new Point(94, 5);
            BtnSelecteer.Name = "BtnSelecteer";
            BtnSelecteer.Size = new Size(75, 23);
            BtnSelecteer.TabIndex = 4;
            BtnSelecteer.Text = "Selecteren";
            BtnSelecteer.UseVisualStyleBackColor = true;
            // 
            // FrmSelectArtiest
            // 
            AcceptButton = BtnSelecteer;
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnAnnuleer;
            ClientSize = new Size(479, 415);
            Controls.Add(LstArtiest);
            Controls.Add(PnlHead);
            Controls.Add(PnlFoot);
            Name = "FrmSelectArtiest";
            Text = "FrmSelectArtiest";
            PnlHead.ResumeLayout(false);
            PnlHead.PerformLayout();
            PnlFoot.ResumeLayout(false);
            PnlFoot.PerformLayout();
            PnlKnoppen.ResumeLayout(false);
            ResumeLayout(false);

        }

        internal Label LbArt;
        internal ListBox LstArtiest;
        internal Panel PnlHead;
        internal TextBox TxtArtiest;
        internal Panel PnlFoot;
        internal Panel PnlKnoppen;
        internal Button BtnAnnuleer;
        internal Button BtnSelecteer;
    }
}