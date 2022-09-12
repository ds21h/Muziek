using System;
using System.Data;
using System.Data.SqlClient;

namespace Muziek {

    static class SQLHulp {
        internal static SqlParameter gParInit(string pNaam, int pWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.Int;
            lPar.Value = pWaarde;

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, int pWaarde, int pNullWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.Int;
            if (pWaarde == pNullWaarde) {
                lPar.Value = DBNull.Value;
            } else {
                lPar.Value = pWaarde;
            }

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, long pWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.BigInt;
            lPar.Value = pWaarde;

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, string pWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.NVarChar;
            lPar.Value = pWaarde;

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, string pWaarde, string pNullWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.NVarChar;
            if (pWaarde == pNullWaarde) {
                lPar.Value = DBNull.Value;
            } else {
                lPar.Value = pWaarde;
            }

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, bool pWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.Bit;
            lPar.Value = pWaarde;

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, DateTime pWaarde) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.DateTime;
            lPar.Value = pWaarde;

            return lPar;
        }

        internal static SqlParameter gParInit(string pNaam, DateTime pWaarde, bool pNull) {
            SqlParameter lPar = new SqlParameter();

            lPar.ParameterName = pNaam;
            lPar.SqlDbType = SqlDbType.DateTime;
            if (pNull) {
                lPar.Value = DBNull.Value;
            } else {
                lPar.Value = pWaarde;
            }

            return lPar;
        }
    }
}