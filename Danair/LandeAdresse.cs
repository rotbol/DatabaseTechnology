namespace Danair
{
    public class LandeAdresse
    {
        public static IAdresse GetLandeAdresse(string Land, int KundeNummer)
        {
            if (Land == "Danmark")
            {
               return new AdresseDanmark(KundeNummer, Land);
            }
            else
            {
               return new AdresseUsa(KundeNummer, Land);
            }
        }
    }
}
