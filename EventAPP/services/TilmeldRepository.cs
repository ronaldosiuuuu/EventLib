using EventLib.model;

namespace EventAPP.services
{
    public class TilmeldRepository : ITilmeld
    {
        private List<Tilmeld> _tilmeld = new List<Tilmeld>();

        public int AntalTilmeldte(int eventid)
        {
            throw new NotImplementedException();
        }

        public Tilmeld CreateTilmeld(Tilmeld tilmeld)
        {
            _tilmeld.Add(tilmeld);
            return tilmeld;
          
        }
    }
}
