using AironAir_Kapitaalbeheer.Classes.Entiteiten;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AironAir_Kapitaalbeheer.Classes
{
    internal class MedewerkerFunctions
    {

        private DBCon mysql = new DBCon();

        public string hasher(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void addGebruiker(string volNaam, string email, int telNR, string rekNR, string pinCodeHash, bool isJongerennRekening)
        {
            mysql.conn.Open();
            string sql = "INSERT INTO gebruiker (VolNaam, Email, TelNR, RekNR, PinCodeHash, IsJongerenRekening) VALUES ('"+volNaam+"','"+email+"', "+telNR+", '"+rekNR+"', '"+hasher(pinCodeHash)+"', "+isJongerennRekening+")";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            cmd.ExecuteNonQuery();
            mysql.conn.Close();
            
        }

        public void remGebruiker(int UID)
        {
            mysql.conn.Open();
            string sql = "DELETE FROM gebruiker WHERE GID="+UID;
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            cmd.ExecuteNonQuery();
            mysql.conn.Close();
        }

        public void editGebruiker(int UID, string volNaam, string email, int telNR, string rekNR, string pinCodeHash, bool isJongerennRekening)
        {
            mysql.conn.Open();
            string sql = "UPDATE gebruiker SET VolNaam = '" + volNaam + "', Email = '" + email + "', TelNR = " + telNR + ", RekNR = '" + rekNR + "', PinCodeHash = '" + hasher(pinCodeHash) + "', IsJongerenRekening = " + isJongerennRekening + " WHERE GID=" + UID;
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            cmd.ExecuteNonQuery();
            mysql.conn.Close();
        }

        public Gebruiker getGebruiker(int UID)
        {
            Gebruiker temp = new Gebruiker();
            mysql.conn.Open();
            string sql = "SELECT * FROM gebruiker WHERE GID=" + UID;
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //You can get values from column names
                temp.GID = int.Parse(reader["GID"].ToString());
                temp.TelNR = int.Parse(reader["TelNR"].ToString());
                temp.VolNaam = reader["VolNaam"].ToString();
                temp.Email = reader["Email"].ToString();
                temp.pinCodeHash = reader["PinCodeHash"].ToString();
                temp.RekNR = reader["RekNR"].ToString();
                temp.IsJongerenRekening = (bool)reader["IsJongerenRekening"];
                break;
            }
            mysql.conn.Close();

            return temp;
        }

        public void addMedewerker(string volNaam, string email, string wachtwoordHash)
        {
            mysql.conn.Open();
            string sql = "INSERT INTO medewerker (VolNaam, Email, WachtwoordHash) VALUES ('" + volNaam + "','" + email + "', '" + hasher(wachtwoordHash) + "')";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            cmd.ExecuteNonQuery();
            mysql.conn.Close();
        }

        public Medewerker getMedewerker(int MID)
        {
            Medewerker temp = new Medewerker();
            mysql.conn.Open();
            string sql = "SELECT * FROM medewerker WHERE MID=" + MID;
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //You can get values from column names
                temp.MID = int.Parse(reader["MID"].ToString());
                temp.VolNaam = reader["VolNaam"].ToString();
                temp.Email = reader["Email"].ToString();
                temp.WachtwoordHash = reader["WachtwoordHash"].ToString();
                break;
            }
            mysql.conn.Close();

            return temp;
        }

        private int getMIDbyEmail(string email)
        {
            int temp = 0;
            mysql.conn.Open();
            string sql = "SELECT * FROM medewerker WHERE Email='" + email + "'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp = int.Parse(reader["MID"].ToString());
            }
            mysql.conn.Close();

            return temp;
        }

        public bool loginMW(string email, string password)
        {
            Medewerker mw = getMedewerker(getMIDbyEmail(email));

            if (hasher(password) == mw.WachtwoordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getUIDbyRekNR(string reknr)
        {
            int temp = 0;
            mysql.conn.Open();
            string sql = "SELECT * FROM gebruiker WHERE RekNR='" + reknr + "'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                temp = int.Parse(reader["GID"].ToString());
            }
            mysql.conn.Close();

            return temp;
        }

        public string genRekNR()
        {
            // genereer rekeningnummer
            bool temp = false;
            string totalstr = "";
            while (temp == false)
            {
                Random _random = new Random();
                long randnr1 = _random.Next(0, 99999);
                string randnrstr1 = randnr1.ToString("D5");
                long randnr2 = _random.Next(0, 99999);
                string randnrstr2 = randnr2.ToString("D5");
                totalstr = "NL69AIRN" + randnrstr1 + randnrstr2;
                   
                if(getUIDbyRekNR(totalstr) == 0)
                {
                    temp = true;
                }
            }
            return totalstr;
        }

        public Gebruiker[] getGebArrByName(string naam)
        {
            List<Gebruiker> temp2 = new List<Gebruiker>();
            mysql.conn.Open();
            string sql = "SELECT * FROM gebruiker WHERE VolNaam LIKE '%" + naam + "%'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Gebruiker temp = new Gebruiker();
                //You can get values from column names
                temp.GID = int.Parse(reader["GID"].ToString());
                temp.TelNR = int.Parse(reader["TelNR"].ToString());
                temp.VolNaam = reader["VolNaam"].ToString();
                temp.Email = reader["Email"].ToString();
                temp.pinCodeHash = reader["PinCodeHash"].ToString();
                temp.RekNR = reader["RekNR"].ToString();
                if (reader["IsJongerenRekening"].ToString() == "true")
                {
                    temp.IsJongerenRekening = true;
                }
                else
                {
                    temp.IsJongerenRekening = false;
                }
                Console.WriteLine(temp.VolNaam);
                temp2.Add(temp);
            }
            mysql.conn.Close();

            return temp2.ToArray();
        }
    }
}
