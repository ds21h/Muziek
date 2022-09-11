using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Muziek {

    internal class Artiesten {
        private const string cAlleArtiesten = "AlleArtiesten";

        private Artiest[] mArtiesten = Array.Empty<Artiest>();
        private bool mInit;

        private int mMaxArtiestNr;

        internal Artiesten() {
            mInit = false;
            mMaxArtiestNr = -1;
            sInitArtiesten();
        }

        internal int xMaxArtiestNummer {
            get {
                return mMaxArtiestNr;
            }
        }

        internal int xAantal {
            get {
                return mArtiesten.Length;
            }
        }

        private void sInitArtiesten() {
            Artiest lArtiest;
            int lArtNummer;
            string lAchterNaam;
            string lVoorNaam;
            int lMaxIndex;
            int lArtiestIndex;
            var lComm = new SqlCommand();
            SqlDataReader lRdr;

            mInit = false;

            lMaxIndex = mArtiesten.Length - 1;
            lArtiestIndex = 0;

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cAlleArtiesten;
                lRdr = lComm.ExecuteReader();

                if (lRdr.HasRows) {
                    while (lRdr.Read()) {
                        lArtNummer = lRdr.GetInt32(0);
                        if (lRdr.IsDBNull(1)) {
                            lAchterNaam = "";
                        } else {
                            lAchterNaam = lRdr.GetString(1);
                        }
                        if (lRdr.IsDBNull(2)) {
                            lVoorNaam = "";
                        } else {
                            lVoorNaam = lRdr.GetString(2);
                        }
                        lArtiest = new Artiest(lArtNummer, lAchterNaam, lVoorNaam);

                        if (lArtNummer > mMaxArtiestNr) {
                            mMaxArtiestNr = lArtNummer;
                        }

                        if (lArtiestIndex > lMaxIndex) {
                            lMaxIndex = lMaxIndex + 50;
                            Array.Resize(ref mArtiesten, lMaxIndex + 1);
                        }
                        mArtiesten[lArtiestIndex] = lArtiest;
                        lArtiestIndex = lArtiestIndex + 1;
                    }
                }

                lRdr.Close();
            }
            mInit = true;

            Array.Resize(ref mArtiesten, lArtiestIndex);
        }

        internal int xNieuweArtiest(Artiest pArtiest) {
            int lIndex;
            int lResult;

            lResult = pArtiest.xNieuweArtiest();
            if (lResult == Resultaat.ResultOK) {
                lIndex = mArtiesten.Length - 1;
                for (int bTeller = 0; bTeller < mArtiesten.Length; bTeller++) {
                    if (pArtiest < mArtiesten[bTeller]) {
                        lIndex = bTeller;
                        break;
                    }
                }

                Array.Resize(ref mArtiesten, mArtiesten.Length + 1);

                for (int bTeller = mArtiesten.Length - 2; bTeller >= lIndex; bTeller -= 1) {
                    mArtiesten[bTeller + 1] = mArtiesten[bTeller];
                }

                mArtiesten[lIndex] = pArtiest;

                if (pArtiest.xArtiestNummer > mMaxArtiestNr) {
                    mMaxArtiestNr = pArtiest.xArtiestNummer;
                }

                lResult = Resultaat.ResultOK;
            } else {
                lResult = Resultaat.ResultError;
            }

            return lResult;
        }

        internal int xWijzigArtiest(Artiest pArtiest) {
            int lPosOud;
            int lPosNieuw;
            int lResult;

            lPosOud = -1;
            lPosNieuw = -1;
            for (int lTeller = 0; lTeller < mArtiesten.Length; lTeller++) {
                if (lPosOud < 0) {
                    if (mArtiesten[lTeller] == pArtiest) {
                        lPosOud = lTeller;
                        if (lPosNieuw >= 0) {
                            break;
                        }
                    }
                }
                if (lPosNieuw < 0) {
                    if (pArtiest <= mArtiesten[lTeller]) {
                        lPosNieuw = lTeller;
                        if (lPosOud >= 0) {
                            break;
                        }
                    }
                }
            }

            if (lPosNieuw < 0) {
                lPosNieuw = mArtiesten.Length;
            }

            if (lPosOud < 0) {
                lResult = Resultaat.ResultBestaatNiet;
            } else {
                lResult = pArtiest.xWijzigArtiest();
                if (lResult == Resultaat.ResultOK) {
                    if (lPosOud == lPosNieuw) {
                        mArtiesten[lPosNieuw] = pArtiest;
                    } else {
                        if (lPosOud < lPosNieuw) {
                            lPosNieuw--;
                            for (int lTeller = lPosOud; lTeller < lPosNieuw; lTeller++) {
                                mArtiesten[lTeller] = mArtiesten[lTeller + 1];
                            }
                            mArtiesten[lPosNieuw] = pArtiest;
                        } else {
                            for (int lTeller = lPosOud; lTeller >= lPosNieuw + 1; lTeller -= 1) {
                                mArtiesten[lTeller] = mArtiesten[lTeller - 1];
                            }
                            mArtiesten[lPosNieuw] = pArtiest;
                        }
                    }
                }
            }

            return lResult;
        }

        internal int xVerwijderArtiest(Artiest pArtiest) {
            int lPos;
            int lResult;

            lPos = -1;
            for (int lTeller = 0; lTeller < mArtiesten.Length; lTeller++) {
                if (pArtiest == mArtiesten[lTeller]) {
                    lPos = lTeller;
                }
            }

            if (lPos < 0) {
                lResult = Resultaat.ResultBestaatNiet;
            } else {
                lResult = pArtiest.xVerwijderArtiest();
                if (lResult == Resultaat.ResultOK) {
                    for (int lTeller = lPos; lTeller < mArtiesten.Length - 1; lTeller++) {
                        mArtiesten[lTeller] = mArtiesten[lTeller + 1];
                    }
                    Array.Resize(ref mArtiesten, mArtiesten.Length - 2 + 1);
                    if (mMaxArtiestNr == pArtiest.xArtiestNummer) {
                        mMaxArtiestNr--;
                    }
                }
            }

            return lResult;
        }

        internal Artiest xArtiest(int pIndex) {
            Artiest lArtiest;

            if (pIndex < 0) {
                lArtiest = null;
            } else {
                if (pIndex > mArtiesten.Length - 1) {
                    lArtiest = null;
                } else {
                    lArtiest = mArtiesten[pIndex];
                }
            }

            return lArtiest;
        }

        internal int xArtiestPositie(Artiest pArtiest) {
            int lPos;

            lPos = -1;
            if (pArtiest != null) {
                for (int lTeller = 0; lTeller < mArtiesten.Length; lTeller++) {
                    if (mArtiesten[lTeller].xArtiestNummer == pArtiest.xArtiestNummer) {
                        lPos = lTeller;
                        break;
                    }
                }
            }

            return lPos;
        }

        internal int xArtiestPositie(string pAchterNaam) {
            int lOnder;
            int lBoven;
            int lHuidig = -1;
            string lZoekNaam;
            int lZoekLengte;
            string lTestNaam;
            bool lGevonden;
            bool lKlaar;
            int lIndex;

            lZoekNaam = pAchterNaam.ToLower();
            lZoekLengte = lZoekNaam.Length;

            lGevonden = false;
            lKlaar = false;
            do {
                lOnder = 0;
                lBoven = mArtiesten.Length - 1;
                while (lOnder <= lBoven) {
                    lHuidig = (int)((lOnder + lBoven) / 2d);
                    lTestNaam = mArtiesten[lHuidig].xAchterNaam.Substring(0, lZoekLengte).ToLower();
                    if (string.Compare(lZoekNaam, lTestNaam, false) == 0) {
                        lGevonden = true;
                        break;
                    } else {
                        if (string.Compare(lZoekNaam, lTestNaam, true) < 0) {
                            lBoven = lHuidig - 1;
                        } else {
                            lOnder = lHuidig + 1;
                        }
                    }
                }
                if (lGevonden) {
                    lKlaar = true;
                } else {
                    if (lZoekLengte > 1) {
                        lZoekLengte--;
                        lZoekNaam = lZoekNaam.Substring(0, lZoekLengte);
                    } else {
                        lKlaar = true;
                    }
                }
            }
            while (!lKlaar);

            if (lGevonden) {
                while (lHuidig > 0) {
                    lTestNaam = mArtiesten[lHuidig - 1].xAchterNaam.Substring(0, lZoekLengte).ToLower();
                    if (string.Compare(lTestNaam, lZoekNaam, false) == 0) {
                        lHuidig--;
                    } else {
                        break;
                    }
                }
                lIndex = lHuidig;
            } else {
                if (lHuidig > 0) {
                    lIndex = lHuidig - 1;
                } else {
                    lIndex = lHuidig;
                }
            }

            return lIndex;
        }

        internal Artiest[] xZoekArtiest(string pNaam) {
            var lArtiesten = new Artiest[11];
            int lMaxIndex = 10;
            int lIndex;
            string lRegexPattern;
            Regex lMatch;

            lIndex = 0;
            if (mInit) {
                lRegexPattern = "^" + Regex.Escape(pNaam).Replace("\\*", ".*").Replace("\\?", ".") + "$";
                lMatch = new Regex(lRegexPattern, RegexOptions.IgnoreCase);
                foreach (var lArtiest in mArtiesten) {
                    if (lMatch.IsMatch(lArtiest.xNaam)) {
                        if (lIndex > lMaxIndex) {
                            lMaxIndex = lMaxIndex + 10;
                            Array.Resize(ref lArtiesten, lMaxIndex + 1);
                        }
                        lArtiesten[lIndex] = lArtiest;
                        lIndex = lIndex + 1;
                    }
                }
            }
            Array.Resize(ref lArtiesten, lIndex);
            return lArtiesten;
        }

        internal Artiest xZoekArtiest(string pAchterNaam, string pVoorNaam) {
            Artiest lArtiest;
            string lAchterNaam;
            string lVoorNaam;
            string lArtAchterNaam;
            string lArtVoorNaam;

            lAchterNaam = pAchterNaam.ToLower();
            lVoorNaam = pVoorNaam.ToLower();

            lArtiest = null;
            if (mInit) {
                foreach (var lArt in mArtiesten) {
                    lArtAchterNaam = lArt.xAchterNaam.ToLower();
                    lArtVoorNaam = lArt.xVoorNaam.ToLower();
                    if (String.Compare(lAchterNaam, lArtAchterNaam) == 0) {
                        if (String.Compare(lVoorNaam, lArtVoorNaam) == 0) {
                            lArtiest = lArt;
                            break;
                        }
                    }
                }
            }

            return lArtiest;
        }

        internal Artiest xZoekArtiest(int pArtiestNummer) {
            Artiest lArtiest;

            lArtiest = null;
            if (mInit) {
                foreach (var lArt in mArtiesten) {
                    if (lArt.xArtiestNummer == pArtiestNummer) {
                        lArtiest = lArt;
                        break;
                    }
                }
            }

            return lArtiest;
        }
    }
}