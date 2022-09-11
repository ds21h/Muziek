using System;
using System.Drawing;
using System.Windows.Forms;

namespace Muziek {
    public partial class FrmPlaat {
        internal const string AktieNieuw = "Nieuw";
        internal const string AktieWijzig = "Wijzig";
        internal const string AktieVerwijder = "Verwijder";
        private const string AktieNull = "";

        private struct DispRij {
            public Label mLbKant;
            public Label mLbVolgNummer;
            public Label mLbArtiest;
            public Button mBtnArtiest;
            public TextBox mTxtTitel;
            public Button mBtnPlus;
            public Button mBtnMin;
            public Button mBtnUp;
            public Button mBtnDown;
        }

        private string mAktie;
        private bool mWijzigen;
        private bool mNieuw;

        private Drager mDrager;
        private PlaatId mPlaatId;

        private DispRij[] mDispLijst = new DispRij[6];
        private int mDispMax = 5;
        private int mDispTeller = -1;

        private Artiest mArtiest;

        private bool mVullen = false;

        private int mRijHoogte;
        private int mRegelTop;
        private int mAantalRijen = 0;
        private int mEersteRij;

        private const int cRijMarge = 1;
        private const int cPagMarge = 5;

        internal Artiest xArtiest {
            get {
                return mArtiest;
            }
            set {
                mArtiest = value;
                if (mArtiest == null) {
                    LbSingleArtiest.Text = "";
                } else {
                    LbSingleArtiest.Text = mArtiest.xNummerNaam;
                    if (mDrager != null) {
                        mDrager.xArtiestNummer = mArtiest.xArtiestNummer;
                    }
                }
            }
        }

        internal FrmPlaat() {
            int lTel;
            var lIndex = default(int);

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            mAktie = AktieNull;
            mWijzigen = false;
            mNieuw = false;
            mPlaatId = new PlaatId();
            mDrager = null;
            mArtiest = null;

            CmbType.Items.Clear();
            for (lTel = 0; lTel < Drager.TypeOmschrijving.Length; lTel++) {
                CmbType.Items.Add(Drager.TypeOmschrijving[lTel]);
                if ((Drager.Type[lTel]) == Drager.TypeSingle) {
                    lIndex = lTel;
                }
            }
            CmbType.SelectedIndex = lIndex;

            ChkEnkeleArtiest.Checked = true;

            LbPlaatNummer.Text = "";
            LbSingleArtiest.Text = "";
            TxtBron.Text = "";

            mRijHoogte = TxtTitel.Height + cRijMarge;
            mRegelTop = TxtTitel.Location.Y;
        }

        internal int xInit(string pAktie, PlaatId pPlaatId) {
            int lResult;

            switch (pAktie) {
                case AktieNieuw: {
                        mPlaatId = new PlaatId();
                        mDrager = new Drager();
                        if (mArtiest != null) {
                            mDrager.xArtiestNummer = mArtiest.xArtiestNummer;
                        }
                        mDrager.xAantal = 1;
                        mDrager.xNieuweOpname(0);
                        ChkEnkeleArtiest.Checked = mDrager.xEnkeleArtiest;
                        ChkLabel.Checked = mDrager.xLabel;
                        mAktie = pAktie;
                        mWijzigen = true;
                        Text = "Nieuwe plaat";
                        CmbType.Enabled = true;
                        lResult = Resultaat.ResultOK;
                        break;
                    }
                case AktieWijzig: {
                        if (pPlaatId == null) {
                            mAktie = AktieNull;
                            mWijzigen = false;
                            lResult = Resultaat.ResultBestaatNiet;
                        } else {
                            mPlaatId = pPlaatId;
                            mDrager = GlobalData.gDragers.xSelectDrager(mPlaatId);
                            if (mDrager == null) {
                                mAktie = AktieNull;
                                mWijzigen = false;
                                lResult = Resultaat.ResultBestaatNiet;
                            } else {
                                mAktie = pAktie;
                                mWijzigen = true;
                                LbPlaatNummer.Text = mDrager.xPlaatNummer.ToString();
                                ChkEnkeleArtiest.Checked = mDrager.xEnkeleArtiest;
                                ChkLabel.Checked = mDrager.xLabel;
                                mArtiest = GlobalData.gArtiesten.xZoekArtiest(mDrager.xArtiestNummer);
                                if (mArtiest == null) {
                                    LbSingleArtiest.Text = "";
                                } else {
                                    LbSingleArtiest.Text = mArtiest.xNummerNaam;
                                }
                                Text = "Wijzig plaat";
                                CmbType.Enabled = false;
                                lResult = Resultaat.ResultOK;
                            }
                        }

                        break;
                    }
                case AktieVerwijder: {
                        if (pPlaatId == null) {
                            mAktie = AktieNull;
                            lResult = Resultaat.ResultBestaatNiet;
                        } else {
                            mPlaatId = pPlaatId;
                            mDrager = GlobalData.gDragers.xSelectDrager(mPlaatId);
                            if (mDrager == null) {
                                mAktie = AktieNull;
                                lResult = Resultaat.ResultBestaatNiet;
                            } else {
                                mAktie = pAktie;
                                LbPlaatNummer.Text = mDrager.xPlaatNummer.ToString();
                                ChkEnkeleArtiest.Checked = mDrager.xEnkeleArtiest;
                                ChkLabel.Checked = mDrager.xLabel;
                                mArtiest = GlobalData.gArtiesten.xZoekArtiest(mDrager.xArtiestNummer);
                                if (mArtiest == null) {
                                    LbSingleArtiest.Text = "";
                                } else {
                                    LbSingleArtiest.Text = mArtiest.xNummerNaam;
                                }
                                Text = "Verwijder plaat";
                                CmbType.Enabled = false;
                                lResult = Resultaat.ResultOK;
                            }
                        }
                        mWijzigen = false;
                        break;
                    }

                default: {
                        mAktie = AktieNull;
                        mWijzigen = false;
                        lResult = Resultaat.ResultError;
                        break;
                    }
            }

            BtnSelect.Enabled = mWijzigen;
            ChkEnkeleArtiest.Enabled = mWijzigen;
            TxtBron.Enabled = mWijzigen;

            return lResult;

        }

        private void sVulOpnames() {
            int lRijIndex;
            Opname lOpname;
            int lVKant = -1;
            Artiest lArtiest;
            OpnameRij lOpnameRij;

            mVullen = true;

            for (lRijIndex = 0; lRijIndex <= mDispTeller; lRijIndex++) {
                mDispLijst[lRijIndex].mLbKant.Visible = false;
                mDispLijst[lRijIndex].mLbVolgNummer.Visible = false;
                mDispLijst[lRijIndex].mLbArtiest.Visible = false;
                mDispLijst[lRijIndex].mBtnArtiest.Visible = false;
                mDispLijst[lRijIndex].mTxtTitel.Visible = false;
                mDispLijst[lRijIndex].mBtnPlus.Visible = false;
                mDispLijst[lRijIndex].mBtnMin.Visible = false;
                mDispLijst[lRijIndex].mBtnUp.Visible = false;
                mDispLijst[lRijIndex].mBtnDown.Visible = false;
            }

            for (int lOpnIndex = mEersteRij; lOpnIndex < mDrager.xAantalOpnames; lOpnIndex++) {
                lRijIndex = lOpnIndex - mEersteRij;
                if (lRijIndex > mAantalRijen - 1) {
                    break;
                }
                while (lRijIndex > mDispTeller) {
                    sDefRij();
                }

                lOpname = mDrager.xOpname(lOpnIndex);
                lArtiest = GlobalData.gArtiesten.xZoekArtiest(lOpname.xArtiestNummer);
                lOpnameRij = new OpnameRij(lRijIndex, lArtiest, lOpname);

                if (lOpname.xKant == lVKant) {
                    mDispLijst[lRijIndex].mLbKant.Text = "";
                } else {
                    mDispLijst[lRijIndex].mLbKant.Text = lOpname.xKant.ToString();
                    lVKant = lOpname.xKant;
                }
                mDispLijst[lRijIndex].mLbVolgNummer.Text = lOpname.xVolgNummer.ToString();
                if (lArtiest == null) {
                    mDispLijst[lRijIndex].mLbArtiest.Text = "Onbekend!!!!";
                } else {
                    mDispLijst[lRijIndex].mLbArtiest.Text = lArtiest.xNummerNaam;
                }
                mDispLijst[lRijIndex].mBtnArtiest.Tag = lOpnameRij;
                mDispLijst[lRijIndex].mTxtTitel.Text = lOpname.xTitel;
                mDispLijst[lRijIndex].mTxtTitel.Tag = lOpnameRij;

                mDispLijst[lRijIndex].mLbKant.Visible = true;
                mDispLijst[lRijIndex].mLbVolgNummer.Visible = true;
                mDispLijst[lRijIndex].mTxtTitel.Visible = true;
                sZetRij(lRijIndex);
                mDispLijst[lRijIndex].mBtnPlus.Visible = mWijzigen;
                mDispLijst[lRijIndex].mBtnPlus.Tag = lOpnameRij;
                mDispLijst[lRijIndex].mBtnMin.Visible = mWijzigen;
                mDispLijst[lRijIndex].mBtnMin.Tag = lOpnameRij;
                mDispLijst[lRijIndex].mBtnUp.Visible = mWijzigen;
                mDispLijst[lRijIndex].mBtnUp.Tag = lOpnameRij;
                mDispLijst[lRijIndex].mBtnDown.Visible = mWijzigen;
                mDispLijst[lRijIndex].mBtnDown.Tag = lOpnameRij;
            }

            if (mDrager.xAantalOpnames > mAantalRijen) {
                ScrInhoud.Minimum = 0;
                ScrInhoud.Value = mEersteRij;
                ScrInhoud.Maximum = mDrager.xAantalOpnames - 1;
                ScrInhoud.SmallChange = 1;
                ScrInhoud.LargeChange = mAantalRijen;
                ScrInhoud.Visible = true;
            } else {
                ScrInhoud.Visible = false;
            }

            mVullen = false;
        }

        private void sDefRij() {
            int lRijTop;
            Point lPos;

            mDispTeller++;
            if (mDispTeller > mDispMax) {
                mDispMax += 5;
                Array.Resize(ref mDispLijst, mDispMax + 1);
            }

            lRijTop = mRegelTop + mDispTeller * mRijHoogte;

            mDispLijst[mDispTeller].mLbKant = new Label();
            mDispLijst[mDispTeller].mLbKant.Name = "LbKant" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mLbKant.Width = LbKant.Width;
            mDispLijst[mDispTeller].mLbKant.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mLbKant);
            lPos = new Point(LbKant.Location.X, lRijTop);
            mDispLijst[mDispTeller].mLbKant.Location = lPos;

            mDispLijst[mDispTeller].mLbVolgNummer = new Label();
            mDispLijst[mDispTeller].mLbVolgNummer.Name = "LbVolgNummer" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mLbVolgNummer.Width = LbVnr.Width;
            mDispLijst[mDispTeller].mLbVolgNummer.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mLbVolgNummer);
            lPos = new Point(LbVnr.Location.X, lRijTop);
            mDispLijst[mDispTeller].mLbVolgNummer.Location = lPos;

            mDispLijst[mDispTeller].mLbArtiest = new Label();
            mDispLijst[mDispTeller].mLbArtiest.Name = "LbArtiest" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mLbArtiest.Width = LbArtiest.Width;
            mDispLijst[mDispTeller].mLbArtiest.AutoSize = LbArtiest.AutoSize;
            mDispLijst[mDispTeller].mLbArtiest.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mLbArtiest);
            lPos = new Point(LbArtiest.Location.X, lRijTop);
            mDispLijst[mDispTeller].mLbArtiest.Location = lPos;

            mDispLijst[mDispTeller].mBtnArtiest = new Button();
            mDispLijst[mDispTeller].mBtnArtiest.Name = "BtnArtiest" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mBtnArtiest.Width = BtnArtiest.Width;
            mDispLijst[mDispTeller].mBtnArtiest.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mBtnArtiest);
            lPos = new Point(BtnArtiest.Location.X, lRijTop);
            mDispLijst[mDispTeller].mBtnArtiest.Location = lPos;
            mDispLijst[mDispTeller].mBtnArtiest.Text = BtnArtiest.Text;
            mDispLijst[mDispTeller].mBtnArtiest.Click += hBtnArtiest_Click;

            mDispLijst[mDispTeller].mTxtTitel = new TextBox();
            mDispLijst[mDispTeller].mTxtTitel.Name = "TxtTitel" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mTxtTitel.Width = TxtTitel.Width;
            mDispLijst[mDispTeller].mTxtTitel.Visible = false;
            mDispLijst[mDispTeller].mTxtTitel.Enabled = mWijzigen;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mTxtTitel);
            lPos = new Point(TxtTitel.Location.X, lRijTop);
            mDispLijst[mDispTeller].mTxtTitel.Location = lPos;
            mDispLijst[mDispTeller].mTxtTitel.Leave += hTxtTitel_Leave;
            mDispLijst[mDispTeller].mTxtTitel.DoubleClick += hTxtTitel_DoubleClick;

            mDispLijst[mDispTeller].mBtnPlus = new Button();
            mDispLijst[mDispTeller].mBtnPlus.Name = "BtnPlus" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mBtnPlus.Width = BtnPlus.Width;
            mDispLijst[mDispTeller].mBtnPlus.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mBtnPlus);
            lPos = new Point(BtnPlus.Location.X, lRijTop);
            mDispLijst[mDispTeller].mBtnPlus.Location = lPos;
            mDispLijst[mDispTeller].mBtnPlus.Image = BtnPlus.Image;
            mDispLijst[mDispTeller].mBtnPlus.Click += hBtnPlus_Click;

            mDispLijst[mDispTeller].mBtnMin = new Button();
            mDispLijst[mDispTeller].mBtnMin.Name = "BtnMin" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mBtnMin.Width = BtnMin.Width;
            mDispLijst[mDispTeller].mBtnMin.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mBtnMin);
            lPos = new Point(BtnMin.Location.X, lRijTop);
            mDispLijst[mDispTeller].mBtnMin.Location = lPos;
            mDispLijst[mDispTeller].mBtnMin.Image = BtnMin.Image;
            mDispLijst[mDispTeller].mBtnMin.Click += hBtnMin_Click;

            mDispLijst[mDispTeller].mBtnUp = new Button();
            mDispLijst[mDispTeller].mBtnUp.Name = "BtnUp" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mBtnUp.Width = BtnUp.Width;
            mDispLijst[mDispTeller].mBtnUp.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mBtnUp);
            lPos = new Point(BtnUp.Location.X, lRijTop);
            mDispLijst[mDispTeller].mBtnUp.Location = lPos;
            mDispLijst[mDispTeller].mBtnUp.Image = BtnUp.Image;
            mDispLijst[mDispTeller].mBtnUp.Click += hBtnUp_Click;

            mDispLijst[mDispTeller].mBtnDown = new Button();
            mDispLijst[mDispTeller].mBtnDown.Name = "BtnDown" + mDispTeller.ToString("000");
            mDispLijst[mDispTeller].mBtnDown.Width = BtnDown.Width;
            mDispLijst[mDispTeller].mBtnDown.Visible = false;
            PnlBody.Controls.Add(mDispLijst[mDispTeller].mBtnDown);
            lPos = new Point(BtnDown.Location.X, lRijTop);
            mDispLijst[mDispTeller].mBtnDown.Location = lPos;
            mDispLijst[mDispTeller].mBtnDown.Image = BtnDown.Image;
            mDispLijst[mDispTeller].mBtnDown.Click += hBtnDown_Click;
        }

        private void BtnSelect_Click(object sender, EventArgs e) {
            Artiest lArtiest;

            lArtiest = sSelectArtiest(mArtiest);
            if (lArtiest != null) {
                mArtiest = lArtiest;
                LbSingleArtiest.Text = mArtiest.xNummerNaam;
                mDrager.xArtiestNummer = mArtiest.xArtiestNummer;
            }
        }

        private Artiest sSelectArtiest(Artiest pArtiest) {
            Artiest lArtiest;
            FrmSelectArtiest lFrmSelectArtiest;
            DialogResult lResult;

            lFrmSelectArtiest = new FrmSelectArtiest(pArtiest);
            lResult = lFrmSelectArtiest.ShowDialog();
            if (lResult == DialogResult.OK) {
                lArtiest = lFrmSelectArtiest.xArtiest;
            } else {
                lArtiest = null;
            }

            return lArtiest;
        }

        private void FrmPlaat_Load(object sender, EventArgs e) {
            int lHoogte;

            lHoogte = PnlBody.Height - TxtTitel.Location.Y - cPagMarge;
            mAantalRijen = lHoogte / mRijHoogte;

            mEersteRij = 0;
            sVulOpnames();

        }

        private void hBtnPlus_Click(object sender, EventArgs e) {
            Button lButton;
            OpnameRij lOpnameRij;
            int lIndex;
            int lOpnIndex;
            int lResult;

            lButton = (Button)sender;
            lOpnameRij = (OpnameRij)lButton.Tag;
            lIndex = lOpnameRij.xRij;

            if (lIndex >= 0) {
                lOpnIndex = lIndex + mEersteRij + 1;
                lResult = mDrager.xNieuweOpname(lOpnIndex);
                if (lResult == Resultaat.ResultOK) {
                    sVulOpnames();
                }
            }
        }

        private void hBtnMin_Click(object sender, EventArgs e) {
            Button lButton;
            OpnameRij lOpnameRij;
            int lIndex;
            int lOpnIndex;
            int lResult;

            lButton = (Button)sender;
            lOpnameRij = (OpnameRij)lButton.Tag;
            lIndex = lOpnameRij.xRij;

            if (mDrager.xAantalOpnames > 1) {
                if (lIndex >= 0) {
                    lOpnIndex = lIndex + mEersteRij;
                    lResult = mDrager.xVerwijderOpname(lOpnIndex);
                    if (lResult == Resultaat.ResultOK) {
                        sVulOpnames();
                    }
                }
            }
        }

        private void hBtnUp_Click(object sender, EventArgs e) {
            Button lButton;
            OpnameRij lOpnameRij;
            int lIndex;
            int lOpnIndex;
            int lResult;

            lButton = (Button)sender;
            lOpnameRij = (OpnameRij)lButton.Tag;
            lIndex = lOpnameRij.xRij;

            if (lIndex >= 0) {
                lOpnIndex = lIndex + mEersteRij;
                lResult = mDrager.xVerwisselOpname(lOpnIndex, lOpnIndex - 1);
                if (lResult == Resultaat.ResultOK) {
                    sVulOpnames();
                }
            }
        }

        private void hBtnDown_Click(object sender, EventArgs e) {
            Button lButton;
            OpnameRij lOpnameRij;
            int lIndex;
            int lOpnIndex;
            int lResult;

            lButton = (Button)sender;
            lOpnameRij = (OpnameRij)lButton.Tag;
            lIndex = lOpnameRij.xRij;

            if (lIndex >= 0) {
                lOpnIndex = lIndex + mEersteRij;
                lResult = mDrager.xVerwisselOpname(lOpnIndex, lOpnIndex + 1);
                if (lResult == Resultaat.ResultOK) {
                    sVulOpnames();
                }
            }
        }

        private void hTxtTitel_Leave(object sender, EventArgs e) {
            TextBox lTxtTitel;
            OpnameRij lOpnameRij;
            Opname lOpname;

            lTxtTitel = (TextBox)sender;
            lOpnameRij = (OpnameRij)lTxtTitel.Tag;
            lOpname = lOpnameRij.xOpname;
            mDrager.xOpnameGewijzigd = true;
            lOpname.xTitel = lTxtTitel.Text.Trim();
        }

        private void hTxtTitel_DoubleClick(object sender, EventArgs e) {
            TextBox lTxtTitel;
            OpnameRij lOpnameRij;
            int lIndex;
            int lOpnIndex;

            lTxtTitel = (TextBox)sender;
            lOpnameRij = (OpnameRij)lTxtTitel.Tag;
            lIndex = lOpnameRij.xRij;

            if (mWijzigen) {
                if (lIndex >= 0) {
                    lOpnIndex = lIndex + mEersteRij;
                    mDrager.xTripKant(lOpnIndex);
                    sVulOpnames();
                }
            }

        }

        private void hBtnArtiest_Click(object sender, EventArgs e) {
            Button lBtnArtiest;
            OpnameRij lOpnameRij;
            int lRij;
            Artiest lArtiest;
            Opname lOpname;
            Artiest lArtiestNieuw;

            lBtnArtiest = (Button)sender;
            lOpnameRij = (OpnameRij)lBtnArtiest.Tag;
            lArtiest = lOpnameRij.xArtiest;
            lArtiestNieuw = sSelectArtiest(lArtiest);
            if (lArtiestNieuw != null) {
                lRij = lOpnameRij.xRij;
                mDispLijst[lRij].mLbArtiest.Text = lArtiestNieuw.xNummerNaam;
                lOpname = lOpnameRij.xOpname;
                lOpname.xArtiestNummer = lArtiestNieuw.xArtiestNummer;
                lOpnameRij.xArtiest = lArtiestNieuw;
                mDrager.xOpnameGewijzigd = true;
            }
        }

        private void ScrInhoud_ValueChanged(object sender, EventArgs e) {
            if (!mVullen) {
                mEersteRij = ScrInhoud.Value;
                sVulOpnames();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            if (mAktie == AktieWijzig) {
                if (mNieuw) {
                    DialogResult = DialogResult.OK;
                } else {
                    DialogResult = DialogResult.Cancel;
                }
            } else {
                DialogResult = DialogResult.Cancel;
            }
            Hide();
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            string lType;
            int lPlaatNummer;
            int lResult;
            var lKlaar = default(bool);
            PlaatId lPlaatId;

            switch (mAktie) {
                case AktieNieuw: {
                        lType = Drager.TypeSingle;
                        lPlaatNummer = GlobalData.gDragers.xMaxSingle + 1;
                        if (lPlaatNummer > 0) {
                            mDrager.xType = lType;
                            mDrager.xPlaatNummer = lPlaatNummer;
                            lResult = GlobalData.gDragers.xNieuweDrager(mDrager);
                            if (lResult == Resultaat.ResultOK) {
                                lPlaatId = new PlaatId(lType, lPlaatNummer);
                                lResult = xInit(AktieWijzig, lPlaatId);
                                mNieuw = true;
                                lKlaar = false;
                            } else {
                                lKlaar = true;
                            }
                        } else {
                            lKlaar = true;
                        }

                        break;
                    }
                case AktieWijzig: {
                        lResult = mDrager.xWijzigDrager();
                        lKlaar = true;
                        break;
                    }
                case AktieVerwijder: {
                        lResult = mDrager.xVerwijderDrager();
                        lKlaar = true;
                        break;
                    }
            }

            if (lKlaar) {
                DialogResult = DialogResult.OK;
                Hide();
            }
        }

        private void ChkEnkeleArtiest_CheckedChanged(object sender, EventArgs e) {
            if (ChkEnkeleArtiest.Checked) {
                LbSingleArtiest.Visible = true;
                BtnSelect.Visible = true;
                LbArtiestH.Visible = false;
                LbTitelH.Left = LbArtiest.Left;
            } else {
                LbSingleArtiest.Visible = false;
                BtnSelect.Visible = false;
                LbArtiestH.Visible = true;
                LbTitelH.Left = TxtTitel.Left;
            }

            for (int lTeller = 0; lTeller <= mDispTeller; lTeller++)
                sZetRij(lTeller);
        }

        private void sZetRij(int pIndex) {
            if (ChkEnkeleArtiest.Checked) {
                mDispLijst[pIndex].mLbArtiest.Visible = false;
                mDispLijst[pIndex].mBtnArtiest.Visible = false;

                mDispLijst[pIndex].mTxtTitel.Left = LbArtiest.Left;
                mDispLijst[pIndex].mTxtTitel.Width = TxtTitel.Left + TxtTitel.Width - LbArtiest.Left;
            } else {
                mDispLijst[pIndex].mLbArtiest.Visible = mDispLijst[pIndex].mTxtTitel.Visible;
                if (mDispLijst[pIndex].mTxtTitel.Visible) {
                    mDispLijst[pIndex].mBtnArtiest.Visible = mWijzigen;
                } else {
                    mDispLijst[pIndex].mBtnArtiest.Visible = false;
                }

                mDispLijst[pIndex].mTxtTitel.Left = TxtTitel.Left;
                mDispLijst[pIndex].mTxtTitel.Width = TxtTitel.Width;
            }
        }

        private void ChkLabel_CheckedChanged(object sender, EventArgs e) {
            mDrager.xLabel = ChkLabel.Checked;
        }
    }
}