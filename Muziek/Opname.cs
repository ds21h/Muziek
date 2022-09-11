using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualBasic;

namespace Muziek {

    public class Opname {
        private const string cNieuweOpname = "NieuweOpname";

        private string mType;
        private int mPlaatNummer;
        private int mKant;
        private int mVolgNummer;
        private int mArtiestNummer;
        private string mTitel;
        private string mUitvoering;

        public string xType {
            get {
                string xTypeRet = default;
                xTypeRet = mType;
                return xTypeRet;
            }
            set {
                mType = value;
            }
        }

        public int xPlaatNummer {
            get {
                int xPlaatNummerRet = default;
                xPlaatNummerRet = mPlaatNummer;
                return xPlaatNummerRet;
            }
            set {
                mPlaatNummer = value;
            }
        }

        public int xKant {
            get {
                int xKantRet = default;
                xKantRet = mKant;
                return xKantRet;
            }
            set {
                if (value > 0) {
                    mKant = value;
                }
            }
        }

        public int xVolgNummer {
            get {
                int xVolgNummerRet = default;
                xVolgNummerRet = mVolgNummer;
                return xVolgNummerRet;
            }
            set {
                if (value > 0) {
                    mVolgNummer = value;
                }
            }
        }

        public int xArtiestNummer {
            get {
                int xArtiestNummerRet = default;
                xArtiestNummerRet = mArtiestNummer;
                return xArtiestNummerRet;
            }
            set {
                mArtiestNummer = value;
            }
        }

        public string xTitel {
            get {
                string xTitelRet = default;
                xTitelRet = mTitel;
                return xTitelRet;
            }
            set {
                mTitel = Strings.Trim(value);
            }
        }

        public Opname(string pType, int pPlaatNummer) {
            mType = pType;
            mPlaatNummer = pPlaatNummer;
            mKant = 0;
            mVolgNummer = 0;
            mArtiestNummer = 0;
            mTitel = "";
            mUitvoering = "";
        }

        public Opname(string pType, int pPlaatNummer, int pKant, int pVolgNummer, int pArtiestNummer, string pTitel, string pUitvoering) {
            mType = pType;
            mPlaatNummer = pPlaatNummer;
            mKant = pKant;
            mVolgNummer = pVolgNummer;
            mArtiestNummer = pArtiestNummer;
            mTitel = Strings.Trim(pTitel);
            mUitvoering = Strings.Trim(pUitvoering);
        }


        public int xNieuweOpname() {
            int xNieuweOpnameRet = default;
            int lResult;

            lResult = sTestOpname();
            if (lResult == Resultaat.ResultOK) {
                lResult = sNieuweOpname();
            }

            xNieuweOpnameRet = lResult;
            return xNieuweOpnameRet;
        }

        private int sTestOpname() {
            int sTestOpnameRet = default;
            int lResult;

            lResult = Resultaat.ResultObjectNietCorrect;
            if (Drager.Type.Contains(mType)) {
                if (mPlaatNummer > 0) {
                    if (mVolgNummer > 0) {
                        if (mKant > 0) {
                            if (mArtiestNummer > 0) {
                                lResult = Resultaat.ResultOK;
                            }
                        }
                    }
                }
            }

            sTestOpnameRet = lResult;
            return sTestOpnameRet;
        }

        private int sNieuweOpname() {
            int sNieuweOpnameRet = default;
            int lResult;
            var lComm = new SqlCommand();
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;
            SqlParameter lParKant;
            SqlParameter lParVolgNummer;
            SqlParameter lParArtiestNummer;
            SqlParameter lParTitel;
            SqlParameter lParUitvoering;

            lParType = SQLHulp.gParInit("@Type", mType);
            lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", mPlaatNummer);
            lParKant = SQLHulp.gParInit("@Kant", mKant);
            lParVolgNummer = SQLHulp.gParInit("@VolgNummer", mVolgNummer);
            lParArtiestNummer = SQLHulp.gParInit("@ArtiestNummer", mArtiestNummer);
            lParTitel = SQLHulp.gParInit("@Titel", mTitel, "");
            lParUitvoering = SQLHulp.gParInit("@Uitvoering", mUitvoering, "");

            lComm.Parameters.Add(lParType);
            lComm.Parameters.Add(lParPlaatNummer);
            lComm.Parameters.Add(lParKant);
            lComm.Parameters.Add(lParVolgNummer);
            lComm.Parameters.Add(lParArtiestNummer);
            lComm.Parameters.Add(lParTitel);
            lComm.Parameters.Add(lParUitvoering);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lConn.Open();
                lComm.Connection = lConn;
                lComm.CommandText = cNieuweOpname;
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

            sNieuweOpnameRet = lResult;
            return sNieuweOpnameRet;
        }

    }
}