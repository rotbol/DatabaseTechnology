using System;
using System.Data.SqlClient;

namespace Danair
{
    public class Kunde
    {
        public int KundeNummer { get; set; }
        public string ForNavn { get; set; }
        public string EfterNavn { get; set; }
        public string Land { get; set; }
        public int? PasNummer { get; set; }
        public string Email { get; set; }

        public Kunde(int KundeNummerI)
        {
            SqlConnection conn = new SqlConnection(@"
                server = .\sqlexpress; integrated security = true; database = Danair");

            string sqlstring = @"SELECT * FROM Danair.Kunde WHERE KundeNummer = " + KundeNummerI;

            SqlCommand cmd = new SqlCommand(sqlstring, conn);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    KundeNummer = int.Parse(rdr.GetValue(0).ToString()); ForNavn = rdr.GetValue(1).ToString();
                    EfterNavn = rdr.GetValue(2).ToString(); Land = rdr.GetValue(3).ToString(); Email = rdr.GetValue(5).ToString();
                    
                    Console.WriteLine("kunde objekt oprettet med værdierne {0} {1} {2} {3} {4} {5}",
                        rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public object GetAdresse()
        {
            //CountryAdress LandeAdresse = new CountryAdress();
            IAdresse adresse;

            return adresse = LandeAdresse.GetLandeAdresse(Land, KundeNummer);
        }

        public static void ListKunder()
        {
            SqlConnection conn = new SqlConnection(@"
                server = .\sqlexpress; integrated security = true; database = Danair");

            string sqlstring = @"SELECT * FROM Danair.Kunde";

            SqlCommand cmd = new SqlCommand(sqlstring, conn);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3));
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
