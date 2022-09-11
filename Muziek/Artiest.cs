using System;
using System.Data;
using System.Data.SqlClient;

namespace Muziek {

    internal class Artiest {
        private const string cPlatenMetArtiest = "DragerOpnamesMetArtiest";
        private const string cWijzigArtiest = "WijzigArtiest";
        private const string cNieuweArtiest = "NieuweArtiest";
        private const string cVerwijderArtiest = "VerwijderArtiest";

        private int mArtiestNummer;
        private string mAchterNaam;
        private string mVoorNaam;
        private string mSortKey;

        public static bool operator ==(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 is null) { // Note: The == operator cannot be used here as it would result a recursive call to this same module 
                if (pArtiest2 is null) {
                    lResult = true;
                } else {
                    lResult = false;
                }
            } else {
                if (pArtiest2 is null) { // Note: The == operator cannot be used here as it would result a recursive call to this same module 
                    lResult = false;
                } else {
                    if (pArtiest1.mArtiestNummer == pArtiest2.mArtiestNummer) {
                        lResult = true;
                    } else {
                        lResult = false;
                    }
                }
            }

            return lResult;
        }

        public static bool operator !=(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 is null) { // Note: The == operator cannot be used here as it would result a recursive call to this same module 
                if (pArtiest2 is null) {
                    lResult = false;
                } else {
                    lResult = true;
                }
            } else {
                if (pArtiest2 is null) { // Note: The == operator cannot be used here as it would result a recursive call to this same module 
                    lResult = true;
                } else {
                    if (pArtiest1.mArtiestNummer == pArtiest2.mArtiestNummer) {
                        lResult = false;
                    } else {
                        lResult = true;
                    }
                }
            }

            return lResult;
        }

        public static bool operator >(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 is null) {
                lResult = false;
            } else {
                if (pArtiest2 is null) {
                    lResult = true;
                } else {
                    if (string.Compare(pArtiest1.mSortKey, pArtiest2.mSortKey, false) > 0) {
                        lResult = true;
                    } else {
                        lResult = false;
                    }
                }
            }

            return lResult;
        }

        public static bool operator >=(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 > pArtiest2 || pArtiest1 == pArtiest2) {
                lResult = true;
            } else {
                lResult = false;
            }

            return lResult;
        }

        public static bool operator <(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 is null) {
                lResult = true;
            } else {
                if (pArtiest2 is null) {
                    lResult = false;
                } else {
                    if (string.Compare(pArtiest1.mSortKey, pArtiest2.mSortKey, false) < 0) {
                        lResult = true;
                    } else {
                        lResult = false;
                    }
                }
            }

            return lResult;
        }

        public static bool operator <=(Artiest pArtiest1, Artiest pArtiest2) {
            bool lResult;

            if (pArtiest1 < pArtiest2 || pArtiest1 == pArtiest2) {
                lResult = true;
            } else {
                lResult = false;
            }

            return lResult;
        }

        internal Artiest() {
            mArtiestNummer = -1;
            mAchterNaam = "";
            mVoorNaam = "";
            mSortKey = "";
        }

        internal Artiest(int pArtiestNummer, string pAchterNaam, string pVoorNaam) {
            mArtiestNummer = pArtiestNummer;
            mAchterNaam = pAchterNaam.Trim();
            mVoorNaam = pVoorNaam.Trim();
            mSortKey = mAchterNaam.ToLower() + " " + mVoorNaam.ToLower();
        }

        internal int xArtiestNummer {
            get {
                return mArtiestNummer;
            }
        }

        internal string xAchterNaam {
            get {
                return mAchterNaam;
            }
            set {
                mAchterNaam = value.Trim();
                mSortKey = mAchterNaam.ToLower() + " " + mVoorNaam.ToLower();
            }
        }

        internal string xVoorNaam {
            get {
                return mVoorNaam;
            }
            set {
                mVoorNaam = value.Trim();
                mSortKey = mAchterNaam.ToLower() + " " + mVoorNaam.ToLower();
            }
        }

        internal string xNaam {
            get {
                string lResult;

                if (string.IsNullOrEmpty(mVoorNaam)) {
                    lResult = mAchterNaam;
                } else {
                    lResult = mVoorNaam + " " + mAchterNaam;
                }

                return lResult;
            }
        }

        internal string xNummerNaam {
            get {
                string lResult;

                lResult = mArtiestNummer.ToString() + " - " + xNaam;
                return lResult;
            }
        }

        internal DragerOpname[] xDragersMetArtiest {
            get {
                DragerOpname[] lResult;

                lResult = sDragerOpname();
                return lResult;
            }
        }

        internal DragerOpname[] sDragerOpname() {
            var lOpname = new DragerOpname[11];
            int lOpnTeller = -1;
            int lOpnMax = 10;
            string lDrType;
            int lDrPlaatNummer;
            int lOpKant;
            int lOpVolgNummer;
            string lOpTitel;
            var lComm = new SqlCommand();
            SqlDataReader lRdr;
            SqlParameter lParArtiestNummer;

            lParArtiestNummer = SQLHulp.gParInit("@ArtiestNummer", mArtiestNummer);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                try {
                    lConn.Open();
                    lComm.Parameters.Add(lParArtiestNummer);
                    lComm.Connection = lConn;
                    lComm.CommandText = cPlatenMetArtiest;
                    lComm.CommandType = CommandType.StoredProcedure;
                    lRdr = lComm.ExecuteReader();

                    if (lRdr.HasRows) {
                        while (lRdr.Read()) {
                            lOpnTeller++;
                            if (lOpnTeller > lOpnMax) {
                                lOpnMax = lOpnMax + 10;
                                Array.Resize(ref lOpname, lOpnMax + 1);
                            }
                            lDrType = lRdr.GetString(0);
                            lDrPlaatNummer = lRdr.GetInt32(1);
                            lOpKant = lRdr.GetInt32(2);
                            lOpVolgNummer = lRdr.GetInt32(3);
                            lOpTitel = lRdr.GetString(4);

                            lOpname[lOpnTeller] = new DragerOpname(lDrType, lDrPlaatNummer, lOpKant, lOpVolgNummer, lOpTitel);
                        }
                    }
                    lRdr.Close();
                } catch (Exception) {

                }
            }

            Array.Resize(ref lOpname, lOpnTeller + 1);
            return lOpname;

        }

        internal int xWijzigArtiest() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParArtiestNummer;
            SqlParameter lParVoorNaam;
            SqlParameter lParAchterNaam;

            lParArtiestNummer = SQLHulp.gParInit("@ArtiestNummer", mArtiestNummer);
            lParVoorNaam = SQLHulp.gParInit("@VoorNaam", mVoorNaam, "");
            lParAchterNaam = SQLHulp.gParInit("@AchterNaam", mAchterNaam, "");

            lComm.Parameters.Add(lParArtiestNummer);
            lComm.Parameters.Add(lParVoorNaam);
            lComm.Parameters.Add(lParAchterNaam);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cWijzigArtiest;
                lComm.CommandType = CommandType.StoredProcedure;
                try {
                    lComm.ExecuteNonQuery();
                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultError;
                }

            }

            return lResult;
        }

        internal int xNieuweArtiest() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParArtiestNummer;
            SqlParameter lParVoorNaam;
            SqlParameter lParAchterNaam;

            lParArtiestNummer = SQLHulp.gParInit("@ArtiestNummer", mArtiestNummer);
            lParVoorNaam = SQLHulp.gParInit("@VoorNaam", mVoorNaam, "");
            lParAchterNaam = SQLHulp.gParInit("@AchterNaam", mAchterNaam, "");

            lComm.Parameters.Add(lParArtiestNummer);
            lComm.Parameters.Add(lParVoorNaam);
            lComm.Parameters.Add(lParAchterNaam);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cNieuweArtiest;
                lComm.CommandType = CommandType.StoredProcedure;
                try {
                    lComm.ExecuteNonQuery();
                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultError;
                }

            }

            return lResult;
        }

        internal int xVerwijderArtiest() {
            DragerOpname[] lDragersOpname;
            int lResult;

            lDragersOpname = sDragerOpname();
            if (lDragersOpname.Length > 0) {
                lResult = Resultaat.ResultAfhankelijk;
            } else {
                lResult = sVerwijderArtiest();
            }

            return lResult;
        }

        private int sVerwijderArtiest() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParArtiestNummer;

            lParArtiestNummer = SQLHulp.gParInit("@ArtiestNummer", mArtiestNummer);

            lComm.Parameters.Add(lParArtiestNummer);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cVerwijderArtiest;
                lComm.CommandType = CommandType.StoredProcedure;
                try {
                    lComm.ExecuteNonQuery();
                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultError;
                }

            }

            return lResult;
        }
    }
}