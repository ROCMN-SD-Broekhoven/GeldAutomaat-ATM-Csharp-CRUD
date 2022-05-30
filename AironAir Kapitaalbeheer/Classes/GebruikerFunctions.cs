using AironAir_Kapitaalbeheer.Classes.Entiteiten;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer.Classes
{
    internal class GebruikerFunctions
    {
        MedewerkerFunctions mwf = new MedewerkerFunctions();
        private DBCon mysql = new DBCon();

        //haal op basis van de UserID de laatste 3 transacties op
        public Transactie[] get3LaatsteTransacties(int UID)
        {
            List<Transactie> trans = new List<Transactie>();
            mysql.conn.Open();
            string sql = "SELECT * FROM transactie WHERE GID=" + UID + " ORDER BY UNIX_TIMESTAMP(DatumTijd) DESC LIMIT 3";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Transactie tempvar = new Transactie();
                tempvar.TID = int.Parse(reader["TID"].ToString());
                tempvar.GID = int.Parse(reader["GID"].ToString());
                tempvar.Saldo = float.Parse(reader["Saldo"].ToString());
                tempvar.Omschrijving = reader["Omschrijving"].ToString();
                tempvar.DatumTijd = Convert.ToDateTime(reader["DatumTijd"]);
                trans.Add(tempvar);
            }

            Transactie[] trArr = trans.ToArray();

            return trArr;
        }

        //haal op basis van de UserID het rekeningsaldo op
        public float getSaldo(int UID)
        {
            float saldo = 0;
            mysql.conn.Open();
            string sql = "SELECT Saldo FROM transactie WHERE GID=" + UID;
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                saldo += float.Parse(reader["Saldo"].ToString());
            }
            mysql.conn.Close();

            return saldo;
        }

        public bool loginGB(string reknr, string pin)
        {

            Gebruiker mw = mwf.getGebruiker(mwf.getUIDbyRekNR(reknr));

            if (mwf.hasher(pin) == mw.pinCodeHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void makeTransaction(int UID, float Saldo, string Desc)
        {
            mysql.conn.Open();
            string sql = "INSERT INTO transactie (GID, Saldo, Omschrijving) VALUES (" + UID + "," + Saldo + ", '" + Desc + "')";
            MySqlCommand cmd = new MySqlCommand(sql, mysql.conn);
            cmd.ExecuteNonQuery();
            mysql.conn.Close();
        }

        //geld storten
        public void deposit(int UID, float bedrag)
        {
            makeTransaction(UID, bedrag, "Contant geld gestort");

            //voltooid melding
        }

        //geld opnemen
        public void withdraw(int UID, float bedrag)
        {

            bool jongerenRek = mwf.getGebruiker(UID).IsJongerenRekening;

            if (getSaldo(UID) > 0 || jongerenRek == false) 
            {
                makeTransaction(UID, -bedrag, "Geld contant opgenomen");

                //voltooid melding
            }
            else
            {
                //foutmelding
            }
        }

        //maak geld over naar een andere rekening
        public void sendTransfer(int UID, string destRekNR, float bedrag)
        {
            bool jongerenRek = mwf.getGebruiker(UID).IsJongerenRekening;

            if (getSaldo(UID) > 0 || jongerenRek == false)
            {
                makeTransaction(UID, -bedrag, ("Geld overgemaakt naar: " + destRekNR));

                makeTransaction(mwf.getUIDbyRekNR(destRekNR), bedrag, ("Geld ontvangen van: " + mwf.getGebruiker(UID).RekNR));

                //voltooid melding
            }
            else
            {
                //foutmelding
            }
        }
    }
}
