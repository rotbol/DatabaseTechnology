﻿using System;
using System.Data.SqlClient;

namespace Danair
{
    public class AdresseUsa : Adresse, IAdresse
    {
        private int KundeNummer;
        private string Land;
        public string Adresse { get; set; }
        public string Stat { get; set; }
        public int PostNummer { get; set; }
        public string TelefonNummer { get; set; }

        public AdresseUsa(int KundeNummer, string Land)
        {
            this.KundeNummer = KundeNummer;
            this.Land = Land;

            SqlConnection conn = new SqlConnection(@"
                server = .\sqlexpress; integrated security = true; database = Danair");

            string sqlstring = @"SELECT Adresse, Stat, PostNummer, TelefonNummer FROM Danair." + Land + " WHERE KundeNummer = " + this.KundeNummer;

            SqlCommand cmd = new SqlCommand(sqlstring, conn);

            try
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Adresse = rdr.GetValue(0).ToString(); Stat = rdr.GetValue(1).ToString(); PostNummer = int.Parse(rdr.GetValue(2).ToString()); TelefonNummer = rdr.GetValue(3).ToString();

                    Console.WriteLine("kunde nummer: {0} har følgende adresse\n{1}", KundeNummer, this.ToString());
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

        public override string ToString()
        {
            return Adresse + "\n" + Stat + "\n" + PostNummer + "\n" + TelefonNummer;
        }
    }
}
