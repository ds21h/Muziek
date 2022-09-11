using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Muziek {

    internal class Drager {
        internal const string TypeSingle = "S";
        internal const string Type78T = "78T";
        internal static readonly string[] Type = new string[] { TypeSingle, Type78T };
        internal static readonly string[] TypeOmschrijving = new string[] { "Single", "78 toeren" };

        private struct OpnWerk {
            public bool mNwKant;
            public Opname mOpname;
        }

        private const string cNieuweDrager = "NieuweDrager";
        private const string cWijzigDrager = "WijzigDrager";
        private const string cVerwijderDrager = "VerwijderDrager";
        private const string cOpnamesBijDrager = "SelectOpnamesBijDrager";
        private const string cVerwijderOpnames = "VerwijderOpnames";

        private bool mNieuw;

        private string mType;
        private int mPlaatNummer;
        private string mTitel;
        private int mAantal;
        private string mBron;
        private bool mLabel;
        private bool mLabel2;

        private bool mEnkeleArtiest;
        private int mArtiestNummer;

        private OpnWerk[] mOpnames;
        private int mOpnameMax;
        private int mOpnameTel;
        private const int mOpnameIncr = 5;

        private bool mGewijzigd;
        private bool mOpnameGewijzigd;

        internal Drager() {
            mType = "";
            mPlaatNummer = -1;
            mTitel = "";
            mAantal = 0;
            mBron = "";
            mLabel = false;
            mLabel2 = false;

            mEnkeleArtiest = true;
            mArtiestNummer = -1;

            mNieuw = true;
            mOpnameMax = -1;
            mOpnameTel = -1;

            mGewijzigd = true;
            mOpnameGewijzigd = true;
        }

        internal Drager(string pType, int pPlaatNummer, string pTitel, int pAantal, string pBron, bool pLabel, bool pLabel2) {
            mType = pType;
            mPlaatNummer = pPlaatNummer;
            mTitel = pTitel;
            mAantal = pAantal;
            mBron = pBron;
            mLabel = pLabel;
            mLabel2 = pLabel2;

            mNieuw = false;
            mOpnameMax = -1;
            sHaalOpnames();

            mGewijzigd = false;
            mOpnameGewijzigd = false;
        }

        internal string xType {
            get {
                return mType;
            }
            set {
                if (mNieuw) {
                    if (Type.Contains(value)) {
                        mType = value;
                        for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++)
                            mOpnames[lTeller].mOpname.xType = mType;
                    }
                }
            }
        }

        internal int xPlaatNummer {
            get {
                return mPlaatNummer;
            }
            set {
                if (mNieuw) {
                    if (value > 0) {
                        mPlaatNummer = value;
                        for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++)
                            mOpnames[lTeller].mOpname.xPlaatNummer = mPlaatNummer;
                    }
                }
            }
        }

        internal string xTitel {
            get {
                return mTitel;
            }
            set {
                mTitel = value;
                mGewijzigd = true;
            }
        }

        internal int xAantal {
            get {
                return mAantal;
            }
            set {
                if (value >= 0) {
                    mAantal = value;
                    mGewijzigd = true;
                }
            }
        }

        internal string xBron {
            get {
                return mBron;
            }
            set {
                mBron = value;
                mGewijzigd = true;
            }
        }

        internal bool xLabel {
            get {
                return mLabel;
            }
            set {
                mLabel = value;
                mGewijzigd = true;
            }
        }

        internal bool xLabel2 {
            get {
                return mLabel2;
            }
            set {
                mLabel2 = value;
                mGewijzigd = true;
            }
        }

        internal int xAantalOpnames {
            get {
                return mOpnameTel + 1;
            }
        }

        internal bool xEnkeleArtiest {
            get {
                return mEnkeleArtiest;
            }
            set {
                mEnkeleArtiest = value;
                if (mEnkeleArtiest) {
                    for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++)
                        mOpnames[lTeller].mOpname.xArtiestNummer = mArtiestNummer;
                    mOpnameGewijzigd = true;
                }
            }
        }

        internal int xArtiestNummer {
            get {
                return mArtiestNummer;
            }
            set {
                mArtiestNummer = value;
                if (mEnkeleArtiest) {
                    for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++) {
                        mOpnames[lTeller].mOpname.xArtiestNummer = mArtiestNummer;
                        mOpnameGewijzigd = true;
                    }
                }
            }
        }

        internal bool xOpnameGewijzigd {
            set {
                mOpnameGewijzigd = value;
            }
        }

        internal int xNieuweDrager() {
            int lResult;

            if (mNieuw) {
                lResult = sTestDrager();
                if (lResult == Resultaat.ResultOK) {
                    lResult = sNieuweDrager();
                    if (lResult == Resultaat.ResultOK) {
                        mNieuw = false;
                        for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++) {
                            lResult = mOpnames[lTeller].mOpname.xNieuweOpname();
                            if (lResult != Resultaat.ResultOK) {
                                break;
                            }
                        }
                    }
                }
            } else {
                lResult = Resultaat.ResultNietToegestaan;
            }

            return lResult;
        }

        private int sTestDrager() {
            int lResult;

            lResult = Resultaat.ResultObjectNietCorrect;
            if (Type.Contains(mType)) {
                if (mPlaatNummer > 0) {
                    if (mAantal >= 0) {
                        lResult = Resultaat.ResultOK;
                    }
                }
            }

            return lResult;
        }

        internal int xWijzigDrager() {
            int lResult;

            if (mNieuw) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                if (mGewijzigd) {
                    lResult = sWijzigDrager();
                } else {
                    lResult = Resultaat.ResultOK;
                }
                if (lResult == Resultaat.ResultOK) {
                    if (mOpnameGewijzigd) {
                        lResult = sVerwijderOpnames();
                        if (lResult == Resultaat.ResultOK) {
                            for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++) {
                                lResult = mOpnames[lTeller].mOpname.xNieuweOpname();
                                if (lResult != Resultaat.ResultOK) {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (lResult == Resultaat.ResultOK) {
                mGewijzigd = false;
                mOpnameGewijzigd = false;
            }
            return lResult;
        }

        internal int xVerwijderDrager() {
            int lResult;

            if (mNieuw) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                lResult = sVerwijderOpnames();
                if (lResult == Resultaat.ResultOK) {
                    mOpnameTel = -1;
                    lResult = sVerwijderDrager();
                    if (lResult == Resultaat.ResultOK) {
                        mNieuw = true;
                    }
                }
            }
            return lResult;
        }

        private int sNieuweDrager() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;
            SqlParameter lParTitel;
            SqlParameter lParAantal;
            SqlParameter lParBron;
            SqlParameter lParLabel;
            SqlParameter lParLabel2;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);
            lParTitel = SQLHulp.gParInit("@Titel", mTitel, "");
            lParAantal = SQLHulp.gParInit("@Aantal", mAantal);
            lParBron = SQLHulp.gParInit("@Bron", mBron, "");
            lParLabel = SQLHulp.gParInit("@Label", mLabel);
            lParLabel2 = SQLHulp.gParInit("@Label2", mLabel2);

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);
            lComm.Parameters.Add(lParTitel);
            lComm.Parameters.Add(lParAantal);
            lComm.Parameters.Add(lParBron);
            lComm.Parameters.Add(lParLabel);
            lComm.Parameters.Add(lParLabel2);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cNieuweDrager;
                lComm.CommandType = CommandType.StoredProcedure;
                try {
                    lComm.ExecuteNonQuery();
                    lResult = Resultaat.ResultOK;
                } catch (Exception Ex) {
                    if (Ex.HResult == -2146232060) {
                        lResult = Resultaat.ResultBestaatAl;
                    } else {
                        lResult = Resultaat.ResultDBError;
                    }
                }

            }

            return lResult;
        }

        private int sWijzigDrager() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;
            SqlParameter lParTitel;
            SqlParameter lParAantal;
            SqlParameter lParBron;
            SqlParameter lParLabel;
            SqlParameter lParLabel2;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);
            lParTitel = SQLHulp.gParInit("@Titel", mTitel, "");
            lParAantal = SQLHulp.gParInit("@Aantal", mAantal);
            lParBron = SQLHulp.gParInit("@Bron", mBron, "");
            lParLabel = SQLHulp.gParInit("@Label", mLabel);
            lParLabel2 = SQLHulp.gParInit("@Label2", mLabel2);

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);
            lComm.Parameters.Add(lParTitel);
            lComm.Parameters.Add(lParAantal);
            lComm.Parameters.Add(lParBron);
            lComm.Parameters.Add(lParLabel);
            lComm.Parameters.Add(lParLabel2);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cWijzigDrager;
                lComm.CommandType = CommandType.StoredProcedure;
                try {
                    lComm.ExecuteNonQuery();
                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultDBError;
                }

            }

            return lResult;
        }

        private int sVerwijderDrager() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lComm.Connection = lConn;
                lComm.CommandType = CommandType.StoredProcedure;
                lComm.CommandText = cVerwijderDrager;

                try {
                    lConn.Open();
                    lComm.ExecuteNonQuery();

                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultDBError;
                }

            }

            return lResult;
        }

        internal Opname xOpname(int pIndex) {
            Opname lOpname;

            if (pIndex > mOpnameTel) {
                lOpname = null;
            } else {
                lOpname = mOpnames[pIndex].mOpname;
            }

            return lOpname;
        }

        internal int xNieuweOpname(int pIndex) {
            int lResult;
            int lOpnameTel;
            Opname lOpname;

            lOpnameTel = mOpnameTel + 1;
            if (pIndex < 0) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                if (pIndex > lOpnameTel) {
                    lResult = Resultaat.ResultNietToegestaan;
                } else {
                    if (lOpnameTel > mOpnameMax) {
                        mOpnameMax += mOpnameIncr;
                        Array.Resize(ref mOpnames, mOpnameMax + 1);
                    }
                    for (int bTeller = mOpnameTel; bTeller >= pIndex; bTeller--) {
                        mOpnames[bTeller + 1] = mOpnames[bTeller];
                    }
                    mOpnameTel = lOpnameTel;
                    lOpname = new Opname(mType, mPlaatNummer);
                    if (mEnkeleArtiest) {
                        lOpname.xArtiestNummer = mArtiestNummer;
                    }
                    mOpnames[pIndex].mNwKant = false;
                    mOpnames[pIndex].mOpname = lOpname;

                    sZetKantVnr();
                    lResult = Resultaat.ResultOK;
                }
            }

            return lResult;
        }

        internal int xVerwijderOpname(int pIndex) {
            int lResult;

            if (pIndex < 0) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                if (pIndex > mOpnameTel) {
                    lResult = Resultaat.ResultNietToegestaan;
                } else {
                    for (int bTeller = pIndex; bTeller < mOpnameTel; bTeller++) {
                        mOpnames[bTeller] = mOpnames[bTeller + 1];
                    }
                    mOpnameTel = mOpnameTel - 1;
                    sZetKantVnr();
                    lResult = Resultaat.ResultOK;
                }
            }

            return lResult;
        }

        internal int xVerwisselOpname(int pIndex1, int pIndex2) {
            int lResult;
            OpnWerk lOpnWerk;

            if (pIndex1 < 0) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                if (pIndex1 > mOpnameTel) {
                    lResult = Resultaat.ResultNietToegestaan;
                } else {
                    lResult = Resultaat.ResultOK;
                }
            }

            if (lResult == Resultaat.ResultOK) {
                if (pIndex2 < 0) {
                    lResult = Resultaat.ResultNietToegestaan;
                } else {
                    if (pIndex2 > mOpnameTel) {
                        lResult = Resultaat.ResultNietToegestaan;
                    } else {
                        lResult = Resultaat.ResultOK;
                    }
                }
            }

            if (lResult == Resultaat.ResultOK) {
                lOpnWerk = mOpnames[pIndex1];
                mOpnames[pIndex1] = mOpnames[pIndex2];
                mOpnames[pIndex2] = lOpnWerk;

                sZetKantVnr();
                lResult = Resultaat.ResultOK;
            }

            return lResult;
        }

        internal int xTripKant(int pIndex) {
            int lResult;

            if (pIndex < 0) {
                lResult = Resultaat.ResultNietToegestaan;
            } else {
                if (pIndex > mOpnameTel) {
                    lResult = Resultaat.ResultNietToegestaan;
                } else {
                    mOpnames[pIndex].mNwKant = !mOpnames[pIndex].mNwKant;
                    sZetKantVnr();
                    lResult = Resultaat.ResultOK;
                }
            }

            return lResult;
        }

        private void sZetKantVnr() {
            int lKant;
            int lVolgNummer;

            lKant = 1;
            lVolgNummer = 0;
            for (int lTeller = 0; lTeller <= mOpnameTel; lTeller++) {
                if (mOpnames[lTeller].mNwKant) {
                    lKant++;
                    lVolgNummer = 1;
                } else {
                    lVolgNummer++;
                }
                mOpnames[lTeller].mOpname.xKant = lKant;
                mOpnames[lTeller].mOpname.xVolgNummer = lVolgNummer;
            }
            mOpnameGewijzigd = true;
        }

        private int sHaalOpnames() {
            int lResult;
            Opname lOpname;
            SqlDataReader lRdr;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;
            int lKant;
            int lVKant = 1;
            int lVolgNummer;
            int lArtiestNummer;
            string lTitel;
            string lUitvoering;
            bool lEerste = true;

            mEnkeleArtiest = true;
            mArtiestNummer = -1;
            mOpnameTel = -1;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lComm.Connection = lConn;
                lComm.CommandType = CommandType.StoredProcedure;
                lComm.CommandText = cOpnamesBijDrager;

                try {
                    lConn.Open();
                    lRdr = lComm.ExecuteReader();

                    if (lRdr.HasRows) {
                        while (lRdr.Read()) {
                            lKant = lRdr.GetInt32(0);
                            lVolgNummer = lRdr.GetInt32(1);
                            lArtiestNummer = lRdr.GetInt32(2);
                            if (lRdr.IsDBNull(3)) {
                                lTitel = "";
                            } else {
                                lTitel = lRdr.GetString(3);
                            }
                            if (lRdr.IsDBNull(4)) {
                                lUitvoering = "";
                            } else {
                                lUitvoering = lRdr.GetString(4);
                            }

                            lOpname = new Opname(mType, mPlaatNummer, lKant, lVolgNummer, lArtiestNummer, lTitel, lUitvoering);

                            mOpnameTel++;
                            if (mOpnameTel > mOpnameMax) {
                                mOpnameMax += mOpnameIncr;
                                Array.Resize(ref mOpnames, mOpnameMax + 1);
                            }
                            if (lKant == lVKant) {
                                mOpnames[mOpnameTel].mNwKant = false;
                            } else {
                                mOpnames[mOpnameTel].mNwKant = true;
                                lVKant = lKant;
                            }
                            if (lEerste) {
                                lEerste = false;
                                mArtiestNummer = lArtiestNummer;
                            } else if (lArtiestNummer != mArtiestNummer) {
                                mEnkeleArtiest = false;
                            }
                            mOpnames[mOpnameTel].mOpname = lOpname;
                        }
                    }

                    lRdr.Close();
                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultDBError;
                }
            }

            return lResult;
        }

        private int sVerwijderOpnames() {
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lComm.Connection = lConn;
                lComm.CommandType = CommandType.StoredProcedure;
                lComm.CommandText = cVerwijderOpnames;

                try {
                    lConn.Open();
                    lComm.ExecuteNonQuery();

                    lResult = Resultaat.ResultOK;
                } catch (Exception) {
                    lResult = Resultaat.ResultDBError;
                }

            }

            return lResult;
        }
    }
}