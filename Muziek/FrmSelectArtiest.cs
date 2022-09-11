using System;
using System.Windows.Forms;
//using Microsoft.VisualBasic;

namespace Muziek {
    public partial class FrmSelectArtiest {
        private Artiest mArtiest;

        internal Artiest xArtiest {
            get {
                return mArtiest;
            }
        }

        internal FrmSelectArtiest(Artiest pArtiest) {
            int lIndex;

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            sVulArtLijst();
            mArtiest = pArtiest;

            lIndex = GlobalData.gArtiesten.xArtiestPositie(mArtiest);
            if (lIndex >= 0) {
                LstArtiest.SelectedIndex = lIndex;
            }

        }

        private void sVulArtLijst() {

            LstArtiest.Items.Clear();
            for (int lTeller = 0; lTeller < GlobalData.gArtiesten.xAantal; lTeller++)
                LstArtiest.Items.Add(GlobalData.gArtiesten.xArtiest(lTeller).xNaam);
        }

        private void TxtArtiest_TextChanged(object sender, EventArgs e) {
            int lIndex;

            lIndex = GlobalData.gArtiesten.xArtiestPositie(TxtArtiest.Text.Trim());
            if (lIndex >= 0) {
                LstArtiest.SelectedIndex = lIndex;
            }

        }

        private void LstArtiest_SelectedIndexChanged(object sender, EventArgs e) {
            int lIndex;

            lIndex = LstArtiest.SelectedIndex;
            if (lIndex < 0) {
                mArtiest = null;
                LbArt.Text = "";
            } else {
                mArtiest = GlobalData.gArtiesten.xArtiest(lIndex);
                LbArt.Text = mArtiest.xNummerNaam;
            }

        }

        private void BtnSelecteer_Click(object sender, EventArgs e) {
            if (mArtiest == null) {
                DialogResult = DialogResult.Cancel;
            } else {
                DialogResult = DialogResult.OK;
            }
            Hide();
        }

        private void BtnAnnuleer_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}