
namespace Muziek {
    public class PlaatId {
        private string mType;
        private int mPlaatNummer;

        public static bool operator ==(PlaatId pPlaat1, PlaatId pPlaat2) {
            bool lResult;

            if (pPlaat1 is null) {
                if (pPlaat2 is null) {
                    lResult = true;
                } else {
                    lResult = false;
                }
            } else {
                if (pPlaat2 is null) {
                    lResult = false;
                } else {
                    if (pPlaat1.mType == pPlaat2.mType) {
                        if (pPlaat1.mPlaatNummer == pPlaat2.mPlaatNummer) {
                            lResult = true;
                        } else {
                            lResult = false;
                        }
                    } else {
                        lResult = false;
                    }
                }
            }

            return lResult;
        }

        public static bool operator !=(PlaatId pPlaat1, PlaatId pPlaat2) {
            bool lResult;

            lResult = !(pPlaat1 == pPlaat2);    

            return lResult;
        }

        public string xType {
            get {
                return mType;
            }
        }

        public int xPlaatNummer {
            get {
                return mPlaatNummer;
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