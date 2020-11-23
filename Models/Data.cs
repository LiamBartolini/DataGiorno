using System;
using System.Collections.Generic;
using System.Text;

namespace Bartolini.Liam._4H.DataGiorno.Models
{
    class Data
    {
        // Istanzio una lista con il numero di giorni per ogni mese
        private static List<int> giorniMesi = new List<int>() { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        int _giorno;
        int _mese;
        int _anno;

        // Controllo la qualità dei dati attraverso le proprietà
        public int Giorno
        {
            get => _giorno;

            // se compreso tra 1 e 31 se è fuori imposto 1
            set => _giorno = (value >= 1 && value <= 31) ? value : 1;
        }
        
        public int Mese
        {
            get => _mese;

            // se non è compreso tra 1 e 31 imposto 1
            set => _mese = (value >= 1&& value <= 12) ? value : 1;
        }
        
        public int Anno
        {
            get => _anno;

            // se non è compreso tra 1 e 31 imposto 1
            set => _anno = (value >= 0 && value <= 2020) ? value : 2020;
        }
        
        public string Out() => $"{this.Giorno} / {this.Mese} / {this.Anno}";

        // Metodo per modificare la data
        public void Mod(int gg, int mm, int aa)
        {
            // Inserisco i nuovi dati dentro le proprietà e gia ricevono una filtrata
            Giorno = gg;
            Mese = mm;
            Anno = aa;

            // Richiamo il metodo Val per verifiarne la qualità in funzione del mese inserito
            string ret = Val();
            if (ret == "Sbagliata")
                throw new Exception("Modifica data non possibile! Errore nei dati inseriti rincotrollare");
        }

        // Controllo solo che il numero di giorni sia coerente con il mese
        public string Val()
        {
            // Utilizzo le liste per poter usare il metodo .Exists per la ricerca dei dati
            if (Mese > 0 && Mese <= 12)
                return giorniMesi.Exists(x => Giorno <= giorniMesi[Mese - 1]) ? "Corretta" : "Sbagliata";
            else
                return "Sbagliata";
        }

        public Data(string data)
        {
            // Splitto la stringa in input
            try
            {
                string[] input = data.Split(',');
                Giorno = Convert.ToInt32(input[0]);
                Mese = Convert.ToInt32(input[1]);
                Anno = Convert.ToInt32(input[2]);
            }
            catch (Exception)   // Se è sbagliata nella sintassi lancia un'eccezione
            { 
                throw new Exception("Dati inseriti non corretti ricontrollare la sintassi dell'input!");
            }

        }
        
        public Data()
        {

        }

    }
}