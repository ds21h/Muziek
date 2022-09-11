using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Muziek {
    public partial class FrmMuziek {
        private struct DispRij {
            public TextBox mTxtType;
            public TextBox mTxtPlNummer;
            public TextBox mTxtKant;
            public TextBox mTxtVolgNummer;
            public TextBox mTxtTitel;
        }

        private const string cSelectLabel45 = "SelectDragersLabel45";

        private Drager[] mDragers = new Drager[11];
        private int mMaxDrager = 10;
        private int mDragerTeller = -1;
        private int mHuidigDrager = -1;

        private DispRij[] mDispLijst = new DispRij[11];
        private int mDispMax = 10;
        private int mDispTeller = -1;

        private Artiest mSelArtiest;
        private Artiest mZoekArtiest;

        private PlaatId mSelPlaat;

        private int mRijHoogte;
        private int mRegelTop;
        private int mRechtMarge;
        private int mMinHoogte;
        private int mMinBreedte;

        private int mAantalRijen = 0;
        private int mEersteRij;
        private const int cRijMarge = 0;
        private const int cPagMarge = 5;

        private bool mGeladen = false;

        private PrintDocument mPrintDoc;
        private Font mPrintFont;

        internal FrmMuziek() {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                try {
                    lConn.Open();
                } catch (Exception ex) {
                    Interaction.MsgBox("SQL-server niet beschikbaar");
                    Environment.Exit(0);
                }
            }
            mZoekArtiest = null;
            mSelPlaat = new PlaatId();
            GlobalData.gArtiesten = new Artiesten();
            GlobalData.gDragers = new Dragers();
            sInitArtiesten();
            sArtiestMenu();

            mRijHoogte = TxtTypeV.Height + cRijMarge;
            mRegelTop = TxtTypeV.Location.Y;
        }

        private void sInitArtiesten() {
            int lIndex;

            sVulArtLijst();
            lIndex = GlobalData.gArtiesten.xArtiestPositie(mZoekArtiest);
            if (lIndex <= 0) {
                // LstArtiest.SelectedIndex = -1
                LstArtiest.SelectedIndex = lIndex;
            } else {
                mSelArtiest = null;
            }
        }

        private void sVulArtLijst() {

            LstArtiest.Items.Clear();
            for (int lTeller = 0, loopTo = GlobalData.gArtiesten.xAantal - 1; lTeller <= loopTo; lTeller++)
                LstArtiest.Items.Add(GlobalData.gArtiesten.xArtiest(lTeller).xNaam);
        }

        private void TxtArtiest_TextChanged(object sender, EventArgs e) {
            int lIndex;

            lIndex = GlobalData.gArtiesten.xArtiestPositie(Strings.Trim(TxtArtiest.Text));
            if (lIndex < 0) {
                mSelArtiest = null;
            } else {
                LstArtiest.SelectedIndex = lIndex;
            }
        }

        private void LstArtiest_SelectedIndexChanged(object sender, EventArgs e) {
            int lIndex;

            lIndex = LstArtiest.SelectedIndex;
            if (lIndex < 0) {
                mSelArtiest = null;
                sArtiestMenu();
            } else {
                mSelArtiest = GlobalData.gArtiesten.xArtiest(lIndex);
                mEersteRij = 0;
                sSchrijfSelectie();
            }
        }

        private void sArtiestMenu() {
            if (mSelArtiest == null) {
                TsmArtiest.Enabled = true;
                TsmArtNw.Enabled = true;
                TsmArtWz.Enabled = false;
                TsmArtVw.Enabled = false;
                TsmDrager.Enabled = false;
            } else {
                TsmArtWz.Enabled = true;
                TsmArtVw.Enabled = true;
                TsmDrager.Enabled = true;
                TsmDrNw.Enabled = true;
                if (mSelPlaat == new PlaatId()) {
                    TsmDrWz.Enabled = false;
                    TsmDrVw.Enabled = false;
                } else {
                    TsmDrWz.Enabled = true;
                    TsmDrVw.Enabled = true;
                }
            }
        }

        private void sSchrijfSelectie() {
            DragerOpname[] lOpname;
            int lRijIndex;
            int lRijTop;
            Point lPos;
            int lArtNr;
            string lTypeNr;
            string lVTypeNr = "";
            PlaatId lPlaatId;
            bool lEerste = true;

            mSelPlaat = new PlaatId();

            lArtNr = mSelArtiest.xArtiestNummer;
            LbArtiest.Text = mSelArtiest.xNummerNaam;
            LbArtiest.Visible = true;
            LbType.Visible = true;
            LbNr.Visible = true;
            LbKant.Visible = true;
            LbVnr.Visible = true;
            LbTitel.Visible = true;

            lOpname = mSelArtiest.xDragersMetArtiest;

            var loopTo = mDispTeller;
            for (lRijIndex = 0; lRijIndex <= loopTo; lRijIndex++) {
                mDispLijst[lRijIndex].mTxtType.Visible = false;
                mDispLijst[lRijIndex].mTxtPlNummer.Visible = false;
                mDispLijst[lRijIndex].mTxtKant.Visible = false;
                mDispLijst[lRijIndex].mTxtVolgNummer.Visible = false;
                mDispLijst[lRijIndex].mTxtTitel.Visible = false;
            }

            for (int lOpnIndex = mEersteRij, loopTo1 = lOpname.Length - 1; lOpnIndex <= loopTo1; lOpnIndex++) {
                lRijIndex = lOpnIndex - mEersteRij;
                if (lRijIndex > mAantalRijen - 1) {
                    break;
                }
                while (lRijIndex > mDispTeller) {
                    mDispTeller = mDispTeller + 1;
                    if (mDispTeller > mDispMax) {
                        mDispMax = mDispMax + 10;
                        Array.Resize(ref mDispLijst, mDispMax + 1);
                    }

                    lRijTop = mRegelTop + mDispTeller * mRijHoogte;

                    mDispLijst[mDispTeller].mTxtType = new TextBox();
                    mDispLijst[mDispTeller].mTxtType.Name = "TxtType" + Strings.Format(mDispTeller, "000");
                    mDispLijst[mDispTeller].mTxtType.Width = TxtTypeV.Width;
                    mDispLijst[mDispTeller].mTxtType.Visible = false;
                    mDispLijst[mDispTeller].mTxtType.Enter += hTxt_Enter;
                    mDispLijst[mDispTeller].mTxtType.KeyPress += hTxt_KeyPress;
                    SplMuziek.Panel2.Controls.Add(mDispLijst[mDispTeller].mTxtType);
                    lPos = new Point(TxtTypeV.Location.X, lRijTop);
                    mDispLijst[mDispTeller].mTxtType.Location = lPos;

                    mDispLijst[mDispTeller].mTxtPlNummer = new TextBox();
                    mDispLijst[mDispTeller].mTxtPlNummer.Name = "TxtPlNummer" + Strings.Format(mDispTeller, "000");
                    mDispLijst[mDispTeller].mTxtPlNummer.Width = TxtNrV.Width;
                    mDispLijst[mDispTeller].mTxtPlNummer.Visible = false;
                    mDispLijst[mDispTeller].mTxtPlNummer.Enter += hTxt_Enter;
                    mDispLijst[mDispTeller].mTxtPlNummer.KeyPress += hTxt_KeyPress;
                    SplMuziek.Panel2.Controls.Add(mDispLijst[mDispTeller].mTxtPlNummer);
                    lPos = new Point(TxtNrV.Location.X, lRijTop);
                    mDispLijst[mDispTeller].mTxtPlNummer.Location = lPos;

                    mDispLijst[mDispTeller].mTxtKant = new TextBox();
                    mDispLijst[mDispTeller].mTxtKant.Name = "TxtKant" + Strings.Format(mDispTeller, "000");
                    mDispLijst[mDispTeller].mTxtKant.Width = TxtKantV.Width;
                    mDispLijst[mDispTeller].mTxtKant.Visible = false;
                    mDispLijst[mDispTeller].mTxtKant.Enter += hTxt_Enter;
                    mDispLijst[mDispTeller].mTxtKant.KeyPress += hTxt_KeyPress;
                    SplMuziek.Panel2.Controls.Add(mDispLijst[mDispTeller].mTxtKant);
                    lPos = new Point(TxtKantV.Location.X, lRijTop);
                    mDispLijst[mDispTeller].mTxtKant.Location = lPos;

                    mDispLijst[mDispTeller].mTxtVolgNummer = new TextBox();
                    mDispLijst[mDispTeller].mTxtVolgNummer.Name = "TxtVolgNummer" + Strings.Format(mDispTeller, "000");
                    mDispLijst[mDispTeller].mTxtVolgNummer.Width = TxtVnrV.Width;
                    mDispLijst[mDispTeller].mTxtVolgNummer.Visible = false;
                    mDispLijst[mDispTeller].mTxtVolgNummer.Enter += hTxt_Enter;
                    mDispLijst[mDispTeller].mTxtVolgNummer.KeyPress += hTxt_KeyPress;
                    SplMuziek.Panel2.Controls.Add(mDispLijst[mDispTeller].mTxtVolgNummer);
                    lPos = new Point(TxtVnrV.Location.X, lRijTop);
                    mDispLijst[mDispTeller].mTxtVolgNummer.Location = lPos;

                    mDispLijst[mDispTeller].mTxtTitel = new TextBox();
                    mDispLijst[mDispTeller].mTxtTitel.Name = "TxtTitel" + Strings.Format(mDispTeller, "000");
                    mDispLijst[mDispTeller].mTxtTitel.Width = TxtTitelV.Width;
                    mDispLijst[mDispTeller].mTxtTitel.Visible = false;
                    mDispLijst[mDispTeller].mTxtTitel.Enter += hTxt_Enter;
                    mDispLijst[mDispTeller].mTxtTitel.KeyPress += hTxt_KeyPress;
                    SplMuziek.Panel2.Controls.Add(mDispLijst[mDispTeller].mTxtTitel);
                    lPos = new Point(TxtTitelV.Location.X, lRijTop);
                    mDispLijst[mDispTeller].mTxtTitel.Location = lPos;
                }

                lPlaatId = new PlaatId(lOpname[lOpnIndex].xDrType, lOpname[lOpnIndex].xDrPlaatNummer);
                if (lEerste) {
                    mSelPlaat = lPlaatId;
                    lEerste = false;
                }
                mDispLijst[lRijIndex].mTxtType.Text = lOpname[lOpnIndex].xDrType;
                mDispLijst[lRijIndex].mTxtType.Tag = lPlaatId;
                mDispLijst[lRijIndex].mTxtPlNummer.Text = lOpname[lOpnIndex].xDrPlaatNummer.ToString();
                mDispLijst[lRijIndex].mTxtPlNummer.Tag = lPlaatId;
                mDispLijst[lRijIndex].mTxtKant.Text = lOpname[lOpnIndex].xOpKant.ToString();
                mDispLijst[lRijIndex].mTxtKant.Tag = lPlaatId;
                mDispLijst[lRijIndex].mTxtVolgNummer.Text = lOpname[lOpnIndex].xOpVolgNummer.ToString();
                mDispLijst[lRijIndex].mTxtVolgNummer.Tag = lPlaatId;
                mDispLijst[lRijIndex].mTxtTitel.Text = lOpname[lOpnIndex].xOpTitel;
                mDispLijst[lRijIndex].mTxtTitel.Tag = lPlaatId;

                lTypeNr = lOpname[lOpnIndex].xDrType + lOpname[lOpnIndex].xDrPlaatNummer.ToString();
                if (lTypeNr != lVTypeNr) {
                    mDispLijst[lRijIndex].mTxtType.Visible = true;
                    mDispLijst[lRijIndex].mTxtPlNummer.Visible = true;
                    lVTypeNr = lTypeNr;
                }
                mDispLijst[lRijIndex].mTxtKant.Visible = true;
                mDispLijst[lRijIndex].mTxtVolgNummer.Visible = true;
                mDispLijst[lRijIndex].mTxtTitel.Visible = true;
            }

            if (lOpname.Length > mAantalRijen) {
                ScrSelectie.Minimum = 0;
                ScrSelectie.Value = mEersteRij;
                ScrSelectie.Maximum = lOpname.Length - 1;
                ScrSelectie.SmallChange = 1;
                ScrSelectie.LargeChange = mAantalRijen;
                ScrSelectie.Visible = true;
            } else {
                ScrSelectie.Visible = false;
            }

            sMarkeerSelectie();
            sArtiestMenu();
        }

        private void sMarkeerSelectie() {
            PlaatId lPlaatId;

            for (int lRijIndex = 0, loopTo = mDispTeller; lRijIndex <= loopTo; lRijIndex++) {
                lPlaatId = (PlaatId)mDispLijst[lRijIndex].mTxtType.Tag;
                if (lPlaatId == mSelPlaat) {
                    mDispLijst[lRijIndex].mTxtType.BackColor = TxtTypeV.BackColor;
                    mDispLijst[lRijIndex].mTxtType.ForeColor = TxtTypeV.ForeColor;
                    mDispLijst[lRijIndex].mTxtPlNummer.BackColor = TxtTypeV.BackColor;
                    mDispLijst[lRijIndex].mTxtPlNummer.ForeColor = TxtTypeV.ForeColor;
                } else {
                    mDispLijst[lRijIndex].mTxtType.BackColor = TxtTitelV.BackColor;
                    mDispLijst[lRijIndex].mTxtType.ForeColor = TxtTitelV.ForeColor;
                    mDispLijst[lRijIndex].mTxtPlNummer.BackColor = TxtTitelV.BackColor;
                    mDispLijst[lRijIndex].mTxtPlNummer.ForeColor = TxtTitelV.ForeColor;
                }
            }
        }

        private void Muziek_Load(object sender, EventArgs e) {
            mGeladen = true;
            mMinHoogte = this.Height;
            mMinBreedte = this.Width;
            mRechtMarge = SplMuziek.Panel2.Width - (TxtTitelV.Location.X + TxtTitelV.Width);
            sZetGrootte();
        }

        private void SplMuziek_Panel2_Resize(object sender, EventArgs e) {
            int lBreedteTitel;
            if (mGeladen) {
                lBreedteTitel = SplMuziek.Panel2.Width - TxtTitelV.Location.X - mRechtMarge;
                TxtTitelV.Width = lBreedteTitel;
                for (int lTeller = 0, loopTo = mDispTeller; lTeller <= loopTo; lTeller++)
                    mDispLijst[lTeller].mTxtTitel.Width = lBreedteTitel;
                sZetGrootte();
            }
        }

        private void sZetGrootte() {
            int lHoogte;

            lHoogte = SplMuziek.Panel2.Height - TxtTypeV.Location.Y - cPagMarge;
            mAantalRijen = (int)Math.Round(Conversion.Int(lHoogte / (double)mRijHoogte));

            if (mSelArtiest != null) {
                sSchrijfSelectie();
            }
        }

        private void ScrSelectie_ValueChanged(object sender, EventArgs e) {
            mEersteRij = ScrSelectie.Value;
            sSchrijfSelectie();
        }

        private void Muziek_Resize(object sender, EventArgs e) {
            if (mGeladen) {
                if (this.Height < mMinHoogte){
                    this.Height = mMinHoogte;
                }
                if (this.Width < mMinBreedte) {
                    this.Width = mMinBreedte;
                }
            }
        }

        private void TsmArtWz_Click(object sender, EventArgs e) {
            FrmArtiest lFrmArtiest;
            int lResult;

            lFrmArtiest = new FrmArtiest();
            if (lFrmArtiest.xInit(FrmArtiest.AktieWijzig, mSelArtiest) == Resultaat.ResultOK) {
                lResult = (int)lFrmArtiest.ShowDialog();
                if (lResult == (int)DialogResult.OK) {
                    mZoekArtiest = lFrmArtiest.xArtiest;
                    sInitArtiesten();
                }
            }
        }

        private void TsmArtNw_Click(object sender, EventArgs e) {
            FrmArtiest lFrmArtiest;
            int lResult;

            lFrmArtiest = new FrmArtiest();
            if (lFrmArtiest.xInit(FrmArtiest.AktieNieuw, null) == Resultaat.ResultOK) {
                lResult = (int)lFrmArtiest.ShowDialog();
                if (lResult == (int)DialogResult.OK) {
                    mZoekArtiest = lFrmArtiest.xArtiest;
                    sInitArtiesten();
                }
            }
        }

        private void TsmArtVw_Click(object sender, EventArgs e) {
            FrmArtiest lFrmArtiest;
            int lResult;
            string lNaam;

            lFrmArtiest = new FrmArtiest();
            if (lFrmArtiest.xInit(FrmArtiest.AktieVerwijder, mSelArtiest) == Resultaat.ResultOK) {
                lNaam = mSelArtiest.xAchterNaam;
                lResult = (int)lFrmArtiest.ShowDialog();
                if (lResult == (int)DialogResult.OK) {
                    mZoekArtiest = mSelArtiest;
                    sInitArtiesten();
                    TxtArtiest.Text = lNaam;
                }
            }
        }

        private void TsmDrNw_Click(object sender, EventArgs e) {
            FrmPlaat lFrmPlaat;
            int lResult;

            lFrmPlaat = new FrmPlaat();
            lFrmPlaat.xInit(FrmPlaat.AktieNieuw, null);
            lFrmPlaat.xArtiest = mSelArtiest;
            lResult = (int)lFrmPlaat.ShowDialog();
            if (lResult == (int)DialogResult.OK) {
                mZoekArtiest = lFrmPlaat.xArtiest;
                sInitArtiesten();
            }
        }

        private void TsmDrWz_Click(object sender, EventArgs e) {
            FrmPlaat lFrmPlaat;
            int lResult;

            lFrmPlaat = new FrmPlaat();
            lFrmPlaat.xInit(FrmPlaat.AktieWijzig, mSelPlaat);
            lResult = (int)lFrmPlaat.ShowDialog();
            if (lResult == (int)DialogResult.OK) {
                mZoekArtiest = lFrmPlaat.xArtiest;
                sInitArtiesten();
            }
        }

        private void TsmDrVw_Click(object sender, EventArgs e) {
            FrmPlaat lFrmPlaat;
            int lResult;

            lFrmPlaat = new FrmPlaat();
            lFrmPlaat.xInit(FrmPlaat.AktieVerwijder, mSelPlaat);
            lResult = (int)lFrmPlaat.ShowDialog();
            if (lResult == (int)DialogResult.OK) {
                mZoekArtiest = mSelArtiest;
                sInitArtiesten();
            }
        }

        private void TsmAfdrLb45_Click(object sender, EventArgs e) {
            DialogResult lResult;

            mPrintDoc = new PrintDocument();
            mPrintDoc.DefaultPageSettings.Landscape = false;
            mPrintDoc.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            mPrintDoc.BeginPrint += hDocument_Begin;
            mPrintDoc.PrintPage += hPage;
            mPrintFont = new Font("Script MT Bold", 13f);
            PrintDialog1.Document = mPrintDoc;
            lResult = PrintDialog1.ShowDialog();
            if (lResult == DialogResult.OK) {
                mPrintDoc.Print();
            }
        }

        private void hDocument_Begin(object sender, PrintEventArgs e) {
            var lComm = new SqlCommand();
            SqlDataReader lRdr;
            Drager lDrager;

            mDragerTeller = -1;

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cSelectLabel45;
                lRdr = lComm.ExecuteReader();

                if (lRdr.HasRows) {
                    while (lRdr.Read()) {
                        lDrager = GlobalData.gDragers.xMaakDrager(lRdr);
                        mDragerTeller = mDragerTeller + 1;
                        if (mDragerTeller > mMaxDrager) {
                            mMaxDrager = mMaxDrager + 10;
                            Array.Resize(ref mDragers, mMaxDrager + 1);
                        }
                        mDragers[mDragerTeller] = lDrager;
                    }
                }

                lRdr.Close();
            }
            mHuidigDrager = -1;
        }

        private void hPage(object pSender, PrintPageEventArgs pPageEvent) {
            bool lMeerPaginas;
            string lTitel1;
            string lTitel2;
            string lArtiest;
            var lArtiesten = new int[6];
            int lArtTeller;
            bool lNieuw;
            Drager lDrager;
            Opname lOpname;
            Artiest lArt;
            Point lPunt;
            int lOnder;
            var lGrootte = new Size(1, 1);

            lPunt = new Point(pPageEvent.MarginBounds.Left, pPageEvent.MarginBounds.Top);
            lOnder = pPageEvent.MarginBounds.Bottom;
            lMeerPaginas = false;
            for (int lTeller = mHuidigDrager + 1, loopTo = mDragerTeller; lTeller <= loopTo; lTeller++) {
                if (lPunt.Y + lGrootte.Height > lOnder) {
                    lMeerPaginas = true;
                    break;
                }
                mHuidigDrager = lTeller;
                lDrager = mDragers[lTeller];
                lTitel1 = "";
                lTitel2 = "";
                lArtiest = "";
                lArtTeller = -1;
                for (int lOpnameTel = 0, loopTo1 = lDrager.xAantalOpnames - 1; lOpnameTel <= loopTo1; lOpnameTel++) {
                    lOpname = lDrager.xOpname(lOpnameTel);
                    if (lOpname.xKant == 1) {
                        if (string.IsNullOrEmpty(lTitel1)) {
                            lTitel1 = lOpname.xTitel;
                        } else {
                            lTitel1 = lTitel1 + " / " + lOpname.xTitel;
                        }
                    } else if (string.IsNullOrEmpty(lTitel2)) {
                        lTitel2 = lOpname.xTitel;
                    } else {
                        lTitel2 = lTitel2 + " / " + lOpname.xTitel;
                    }
                    lNieuw = true;
                    for (int lXTeller = 0, loopTo2 = lArtTeller; lXTeller <= loopTo2; lXTeller++) {
                        if (lArtiesten[lXTeller] == lOpname.xArtiestNummer) {
                            lNieuw = false;
                            break;
                        }
                    }
                    if (lNieuw) {
                        if (lArtTeller < 5) {
                            lArtTeller = lArtTeller + 1;
                            lArtiesten[lArtTeller] = lOpname.xArtiestNummer;
                        }
                    }
                }
                for (int lXTeller = 0, loopTo3 = lArtTeller; lXTeller <= loopTo3; lXTeller++) {
                    lArt = GlobalData.gArtiesten.xZoekArtiest(lArtiesten[lXTeller]);
                    if (lArt != null) {
                        if (string.IsNullOrEmpty(lArtiest)) {
                            lArtiest = lDrager.xPlaatNummer + " " + lArt.xNaam;
                        } else {
                            lArtiest = lArtiest + " / " + lArt.xNaam;
                        }
                    }
                }
                lGrootte = sSchrijfLabel(lPunt, pPageEvent.Graphics, lTitel1, lTitel2, lArtiest);
                lDrager.xLabel = false;
                lDrager.xWijzigDrager();
                lPunt.X = lPunt.X + lGrootte.Width;
                if (lPunt.X + lGrootte.Width > pPageEvent.MarginBounds.Right) {
                    lPunt.X = pPageEvent.MarginBounds.Left;
                    lPunt.Y = lPunt.Y + lGrootte.Height;
                }
            }
            pPageEvent.HasMorePages = lMeerPaginas;
        }

        private Size sSchrijfLabel(Point pPunt, Graphics pGraphic, string pTitel1, string pTitel2, string pArtiest) {
            Size sSchrijfLabelRet = default;
            // Constanten voor formaat in tienden van millimeter!
            const int cBreedte = 780;
            const int cHoogte = 255;
            const int cMargeTitel = 25;
            const int cMargeArtiest = 35;
            const int cMargeRechts = 50;
            int lBreedte;
            int lHoogte;
            int lMargeTitel;
            int lMargeArtiest;
            int lMargeRechts;
            int lHoogteTitel;
            int lMargeTitelV;
            Size lGrootte;
            Pen lPen;
            string lTitel1;
            string lTitel2;
            string lArtiest;

            lBreedte = (int)Math.Round(Conversion.Int(cBreedte / 2.54d));
            lHoogte = (int)Math.Round(Conversion.Int(cHoogte / 2.54d));
            lMargeTitel = (int)Math.Round(Conversion.Int(cMargeTitel / 2.54d));
            lMargeArtiest = (int)Math.Round(Conversion.Int(cMargeArtiest / 2.54d));
            lMargeRechts = (int)Math.Round(Conversion.Int(cMargeRechts / 2.54d));
            lGrootte = new Size(lBreedte, lHoogte);
            lPen = new Pen(Color.Black, 1f);
            lPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            pGraphic.DrawRectangle(lPen, pPunt.X, pPunt.Y, lBreedte, lHoogte);

            lHoogteTitel = (int)Math.Round(Conversion.Int((lHoogte - mPrintFont.Height) / 2d));
            lMargeTitelV = (int)Math.Round(Conversion.Int((lHoogteTitel - mPrintFont.Height) / 2d));
            lPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            pGraphic.DrawLine(lPen, pPunt.X + lMargeTitel, pPunt.Y + lHoogteTitel, pPunt.X + lBreedte - lMargeRechts, pPunt.Y + lHoogteTitel);
            pGraphic.DrawLine(lPen, pPunt.X + lMargeTitel, pPunt.Y + lHoogteTitel + mPrintFont.Height, pPunt.X + lBreedte - lMargeRechts, pPunt.Y + lHoogteTitel + mPrintFont.Height);

            lTitel1 = sPasTekst(pTitel1, lBreedte - lMargeTitel - lMargeRechts, pGraphic);
            lTitel2 = sPasTekst(pTitel2, lBreedte - lMargeTitel - lMargeRechts, pGraphic);
            lArtiest = sPasTekst(pArtiest, lBreedte - lMargeArtiest - lMargeRechts, pGraphic);
            pGraphic.DrawString(lTitel1, mPrintFont, Brushes.Black, pPunt.X + lMargeTitel, pPunt.Y + lMargeTitelV, new StringFormat());
            pGraphic.DrawString(lArtiest, mPrintFont, Brushes.Black, pPunt.X + lMargeArtiest, pPunt.Y + lHoogteTitel, new StringFormat());
            pGraphic.DrawString(lTitel2, mPrintFont, Brushes.Black, pPunt.X + lMargeTitel, pPunt.Y + lHoogteTitel + mPrintFont.Height + lMargeTitelV, new StringFormat());

            sSchrijfLabelRet = lGrootte;
            return sSchrijfLabelRet;
        }

        private string sPasTekst(string pTekst, int pBreedte, Graphics pGraphic) {
            string sPasTekstRet = default;
            string lInvoer;
            string lWerk;
            SizeF lGrootte;

            lInvoer = pTekst;
            lWerk = lInvoer;
            do {
                lGrootte = pGraphic.MeasureString(lWerk, mPrintFont, pBreedte + 50, new StringFormat());
                if (lGrootte.Width < pBreedte) {
                    break;
                }
                lInvoer = Strings.Mid(lInvoer, 1, lInvoer.Length - 1);
                lWerk = lInvoer + " ...";
            }
            while (true);

            sPasTekstRet = lWerk;
            return sPasTekstRet;
        }

        private void hTxt_MouseClick(object sender, EventArgs e) {
            TextBox lText;
            PlaatId lPlaatId;

            lText = (TextBox)sender;
            lPlaatId = (PlaatId)lText.Tag;
        }

        private void hTxt_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void hTxt_Enter(object sender, EventArgs e) {
            TextBox lText;
            PlaatId lPlaatId;

            lText = (TextBox)sender;
            lPlaatId = (PlaatId)lText.Tag;

            mSelPlaat = lPlaatId;
            sMarkeerSelectie();
        }
    }
}