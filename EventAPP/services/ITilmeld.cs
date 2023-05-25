using EventLib.model;

namespace EventAPP.services
{
    public interface ITilmeld
    {

        public Tilmeld CreateTilmeld(Tilmeld tilmeld);

        public int AntalTilmeldte(int eventid);
    }
}
