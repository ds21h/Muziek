
namespace Muziek {
    public class PlaatId {
        private string mType;
        private int mPlaatNummer;

        public static bool operator ==(PlaatId pPlaat1, PlaatId pPlaat2) {
            bool lResult;
            if (pPlaat1 is null) {
                lResult = false;
            } else if (pPlaat2 is null) {
                lResult = false;
            } else if ((pPlaat1.mType ?? "") == (pPlaat2.mType ?? "")) {
                if (pPlaat1.mPlaatNummer == pPlaat2.mPlaatNummer) {
                    lResult = true;
                } else {
                    lResult = false;
                }
            } else {
                lResult = false;
            }

            return lResult;
        }

        public static bool operator !=(PlaatId pPlaat1, PlaatId pPlaat2) {
            bool lResult;
            if (pPlaat1 is null) {
                lResult = false;
            } else if (pPlaat2 is null) {
                lResult = false;
            } else if ((pPlaat1.mType ?? "") == (pPlaat2.mType ?? "")) {
                if (pPlaat1.mPlaatNummer == pPlaat2.mPlaatNummer) {
                    lResult = false;
                } else {
                    lResult = true;
                }
            } else {
                lResult = true;
            }

            return lResult;
        }

        public string xType {
            get {
                string xTypeRet = default;
                xTypeRet = mType;
                return xTypeRet;
            }
        }

        public int xPlaatNummer {
            get {
                int xPlaatNummerRet = default;
                xPlaatNummerRet = mPlaatNummer;
                return xPlaatNummerRet;
            }
        }

        public PlaatId() {
            mType = "";
            mPlaatNummer = 0;
        }

        public PlaatId(string pType, int pPlaatNummer) {
            mType = pType;
            mPlaatNummer = pPlaatNummer;
        }
    }
}