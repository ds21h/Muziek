using System;
using System.Windows.Forms;

namespace Muziek {
    internal partial class FrmArtiest {
        internal const string AktieNieuw = "Nieuw";
        internal const string AktieWijzig = "Wijzig";
        internal const string AktieVerwijder = "Verwijder";
        private const string AktieNull = "";

        private const string cFoutBestaat = "Een artiest met de opgegeven naam bestaat al!";
        private const string cFoutBestaatNiet = "De artiest bestaat niet!";
        private const string cFoutAfhankelijk = "De artiest heeft nog afhankelijkheden";
        private const string cFoutUpdate = "Wijzigen artiest mislukt!";
        private const string cFoutNieuw = "Aanmaken nieuwe artiest mislukt!";
        private const string cFoutVerwijder = "Verwijderen artiest mislukt!";

        private Artiest mArtiest;
        private string mAktie;

        internal FrmArtiest() {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            mArtiest = null;
            mAktie = AktieNull;
            LbNaam.Text = "";
            LbArtNummer.Text = "";
        }

        internal Artiest xArtiest {
            get {
                return mArtiest;
            }
        }

        internal int xInit(string pAktie, Artiest pArtiest) {
            int lResult;

            switch (pAktie) {
                case AktieNieuw: {
                        TxtVoorNaam.Enabled = true;
                        TxtAchterNaam.Enabled = true;
                        mAktie = pAktie;
                        mArtiest = null;
                        LbArtNummer.Text = "";
                        TxtVoorNaam.Text = "";
                        TxtAchterNaam.Text = "";
                        lResult = Resultaat.ResultOK;
                        break;
                    }
                case AktieWijzig: {
                        if (pArtiest == null) {
                            lResult = Resultaat.ResultBestaatNiet;
                        } else {
                            TxtVoorNaam.Enabled = true;
                            TxtAchterNaam.Enabled = true;
                            mAktie = pAktie;
                            mArtiest = pArtiest;
                            LbArtNummer.Text = mArtiest.xArtiestNummer.ToString();
                            TxtVoorNaam.Text = mArtiest.xVoorNaam;
                            TxtAchterNaam.Text = mArtiest.xAchterNaam;
                            lResult = Resultaat.ResultOK;
                        }

                        break;
                    }
                case AktieVerwijder: {
                        if (pArtiest == null) {
                            lResult = Resultaat.ResultBestaatNiet;
                        } else {
                            TxtVoorNaam.Enabled = false;
                            TxtAchterNaam.Enabled = false;
                            mAktie = pAktie;
                            mArtiest = pArtiest;
                            LbArtNummer.Text = mArtiest.xArtiestNummer.ToString();
                            TxtVoorNaam.Text = mArtiest.xVoorNaam;
                            TxtAchterNaam.Text = mArtiest.xAchterNaam;
                            lResult = Resultaat.ResultOK;
                        }

                        break;
                    }

                default: {
                        lResult = Resultaat.ResultError;
                        break;
                    }
            }
            return lResult;
        }


        private int sVerwerkSchermWijzig() {
            Artiest lArtiest;
            bool lBestaat;
            int lResult;

            lArtiest = GlobalData.gArtiesten.xZoekArtiest(TxtAchterNaam.Text.Trim(), TxtVoorNaam.Text.Trim());
            if (lArtiest == null) {
                lBestaat = false;
            } else {
                if (lArtiest.xArtiestNummer == mArtiest.xArtiestNummer) {
                    lBestaat = false;
                } else {
                    lBestaat = true;
                }
            }

            if (lBestaat) {
                LbFout.Text = cFoutBestaat;
                lResult = Resultaat.ResultBestaatAl;
            } else {
                lArtiest = new Artiest(mArtiest.xArtiestNummer, TxtAchterNaam.Text.Trim(), TxtVoorNaam.Text.Trim());
                lResult = GlobalData.gArtiesten.xWijzigArtiest(lArtiest);
                switch (lResult) {
                    case Resultaat.ResultOK: {
                            LbFout.Text = "";
                            mArtiest = lArtiest;
                            break;
                        }
                    case Resultaat.ResultBestaatNiet: {
                            LbFout.Text = cFoutBestaatNiet;
                            break;
                        }

                    default: {
                            LbFout.Text = cFoutUpdate;
                            break;
                        }
                }
            }

            return lResult;
        }

        private int sVerwerkSchermNieuw() {
            Artiest lArtiest;
            int lResult;

            lArtiest = GlobalData.gArtiesten.xZoekArtiest(TxtAchterNaam.Text.Trim(), TxtVoorNaam.Text.Trim());
            if (lArtiest == null) {
                mArtiest = new Artiest(GlobalData.gArtiesten.xMaxArtiestNummer + 1, TxtAchterNaam.Text.Trim(), TxtVoorNaam.Text.Trim());
                lResult = GlobalData.gArtiesten.xNieuweArtiest(mArtiest);
                if (lResult != Resultaat.ResultOK) {
                    LbFout.Text = cFoutNieuw;
                }
            } else {
                LbFout.Text = cFoutBestaat;
                lResult = Resultaat.ResultBestaatAl;
            }

            return lResult;

        }

        private int sVerwerkSchermVerwijder() {
            int lResult;

            if (mArtiest != null) {
                lResult = GlobalData.gArtiesten.xVerwijderArtiest(mArtiest);
                switch (lResult) {
                    case Resultaat.ResultOK: {
                            LbFout.Text = "";
                            break;
                        }
                    case Resultaat.ResultBestaatNiet: {
                            LbFout.Text = cFoutBestaatNiet;
                            break;
                        }
                    case Resultaat.ResultAfhankelijk: {
                            LbFout.Text = cFoutAfhankelijk;
                            break;
                        }

                    default: {
                            LbFout.Text = cFoutVerwijder;
                            break;
                        }
                }
            } else {
                LbFout.Text = cFoutBestaatNiet;
                lResult = Resultaat.ResultBestaatNiet;
            }

            return lResult;

        }

        private void BttnOK_Click(object sender, EventArgs e) {
            int lResult;

            LbFout.Visible = false;
            switch (mAktie) {
                case AktieNieuw: {
                        lResult = sVerwerkSchermNieuw();
                        break;
                    }
                case AktieWijzig: {
                        lResult = sVerwerkSchermWijzig();
                        break;
                    }
                case AktieVerwijder: {
                        lResult = sVerwerkSchermVerwijder();
                        break;
                    }

                default: {
                        lResult = Resultaat.ResultOK;
                        break;
                    }
            }

            if (lResult == Resultaat.ResultOK) {
                mAktie = AktieNull;
                DialogResult = DialogResult.OK;
                Hide();
            } else {
                LbFout.Visible = true;
            }
        }

        private void BttnCancel_Click(object sender, EventArgs e) {
            LbFout.Visible = false;
            mAktie = AktieNull;
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void TxtNaam_TextChanged(object sender, EventArgs e) {
            LbNaam.Text = TxtVoorNaam.Text.Trim() + " " + TxtAchterNaam.Text.Trim();
        }
    }
}