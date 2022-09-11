
namespace Muziek {
    internal class DragerOpname {
        private string mDrType;
        private int mDrPlaatNummer;
        private int mOpKant;
        private int mOpVolgNummer;
        private string mOpTitel;

        internal string xDrType {
            get {
                return mDrType;
            }
        }

        internal int xDrPlaatNummer {
            get {
                return mDrPlaatNummer;
            }
        }

        internal int xOpKant {
            get {
                return mOpKant;
            }
        }

        internal int xOpVolgNummer {
            get {
                return mOpVolgNummer;
            }
        }

        internal string xOpTitel {
            get {
                return mOpTitel;
            }
        }

        internal DragerOpname(string pDrType, int pDrPlaatNummer, int pOpKant, int pOpVolgNummer, string pOpTitel) {
            mDrType = pDrType;
            mDrPlaatNummer = pDrPlaatNummer;
            mOpKant = pOpKant;
            mOpVolgNummer = pOpVolgNummer;
            mOpTitel = pOpTitel;
        }
    }
}