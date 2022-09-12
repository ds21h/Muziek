
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
                return mRij;
            }
        }

        internal Artiest xArtiest {
            get {
                return mArtiest;
            }
            set {
                mArtiest = value;
            }
        }

        public Opname xOpname {
            get {
                return mOpname;
            }
        }
    }
}