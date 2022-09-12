using System;
using System.Data;
using System.Data.SqlClient;

namespace Muziek {

    internal class Dragers {
        private const string cSelectDrager = "SelectDrager";
        private const string cMaxPlaatNummer = "MaxPlaatNummer";

        internal int xMaxSingle {
            get {
                return sMaxPlaatNummer(Drager.TypeSingle);
            }
        }

        private int sMaxPlaatNummer(string pType) {
            var lComm = new SqlCommand();
            SqlParameter lParType;
            int lPlaatNummer;
            object lAntwoord;

            lParType = SQLHulp.gParInit("@Type", pType);

            lComm.Parameters.Add(lParType);

            using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                lComm.Connection = lConn;
                lComm.CommandText = cMaxPlaatNummer;
                lComm.CommandType = CommandType.StoredProcedure;

                try {
                    lConn.Open();
                    lAntwoord = lComm.ExecuteScalar();
                    if (lAntwoord is DBNull) {
                        lPlaatNummer = 0;
                    } else {
                        lPlaatNummer = (int)lAntwoord;
                    }
                } catch (Exception) {
                    lPlaatNummer = -1;
                }

            }

            return lPlaatNummer;
        }

        internal int xNieuweDrager(Drager pDrager) {
            int lResult;

            lResult = pDrager.xNieuweDrager();

            return lResult;
        }

        internal Drager xSelectDrager(PlaatId pPlaatId) {
            Drager lDrager;
            var lComm = new SqlCommand();
            SqlDataReader lRdr;
            SqlParameter lParType;
            SqlParameter lParPlaatNummer;

            if (pPlaatId == null) {
                lDrager = null;
            } else {
                lParType = SQLHulp.gParInit("@Type", pPlaatId.xType);
                lParPlaatNummer = SQLHulp.gParInit("@PlaatNummer", pPlaatId.xPlaatNummer);

                lComm.Parameters.Add(lParType);
                lComm.Parameters.Add(lParPlaatNummer);

                using (var lConn = new SqlConnection(GlobalData.gConnStr)) {
                    lComm.Connection = lConn;
                    lComm.CommandText = cSelectDrager;
                    lComm.CommandType = CommandType.StoredProcedure;

                    try {
                        lConn.Open();
                        lRdr = lComm.ExecuteReader();

                        if (lRdr.HasRows) {
                            lRdr.Read();
                            lDrager = xMaakDrager(lRdr);
                        } else {
                            lDrager = null;
                        }

                        lRdr.Close();
                    } catch (Exception) {
                        lDrager = null;
                    }

                }
            }

            return lDrager;
        }

        internal Drager xMaakDrager(SqlDataReader pRdr) {
            Drager lDrager;
            string lType;
            int lPlaatNummer;
            string lTitel;
            int lAantal;
            string lBron;
            bool lLabel;
            bool lLabel2;

            lType = pRdr.GetString(0);
            lPlaatNummer = pRdr.GetInt32(1);
            if (pRdr.IsDBNull(2)) {
                lTitel = "";
            } else {
                lTitel = pRdr.GetString(2);
            }
            lAantal = pRdr.GetInt32(3);
            if (pRdr.IsDBNull(4)) {
                lBron = "";
            } else {
                lBron = pRdr.GetString(4);
            }
            lLabel = pRdr.GetBoolean(5);
            lLabel2 = pRdr.GetBoolean(6);

            lDrager = new Drager(lType, lPlaatNummer, lTitel, lAantal, lBron, lLabel, lLabel2);

            return lDrager;
        }
    }
}