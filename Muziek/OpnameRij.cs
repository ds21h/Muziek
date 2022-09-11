
namespace Muziek {
    public class OpnameRij {
        private int mRij;
        private Artiest mArtiest;
        private Opname mOpname;

        internal OpnameRij(int pRij, Artiest pArtiest, Opname pOpname) {
            mRij = pRij;
            mArtiest = pArtiest;
            mOpname = pOpname;
        }

        public int xRij {
            get {
                int xRijRet = default;
                xRijRet = mRij;
                return xRijRet;
            }
        }

        internal Artiest xArtiest {
            get {
                Artiest xArtiestRet = default;
                xArtiestRet = mArtiest;
                return xArtiestRet;
            }
            set {
                mArtiest = value;
            }
        }

        public Opname xOpname {
            get {
                Opname xOpnameRet = default;
                xOpnameRet = mOpname;
                return xOpnameRet;
            }
        }
    }
}