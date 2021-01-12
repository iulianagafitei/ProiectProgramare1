using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgramareProiect.Models;

namespace ProgramareProiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();
            if (context.Camere.Any())
            {
                return; // BD a fost creata anterior
            }
            var camere = new Camera[]
            {
new Camera{CameraID=01,Etaj=0,TipPat="Matrimonial",PretNoapte=Decimal.Parse("300"),},
new Camera{CameraID=02,Etaj=1,TipPat="Simplu",PretNoapte=Decimal.Parse("250")},
new Camera{CameraID=03,Etaj=2,TipPat="Dublu",PretNoapte=Decimal.Parse("270")},
new Camera{CameraID=11,Etaj=3,TipPat="Matrimonial",PretNoapte=Decimal.Parse("270")},
new Camera{CameraID=21,Etaj=4,TipPat="Simplu",PretNoapte=Decimal.Parse("320")},
new Camera{CameraID=31,Etaj=5,TipPat="Matrimonial",PretNoapte=Decimal.Parse("400")}
            };
            foreach (Camera s in camere)
            {
                context.Camere.Add(s);
            }
            context.SaveChanges();
            var clienti = new Client[]
            {

new Client{ClientID=101,NumeClient="AndreiMaria",Sex="Feminin",DataDeNastere=DateTime.Parse("1989-10-07")},
new Client{ClientID=102,NumeClient="IonescuStefania",Sex="Feminin",DataDeNastere=DateTime.Parse("1998-11-07")},
new Client{ClientID=103,NumeClient="MihaiAndrei",Sex="Masculin",DataDeNastere=DateTime.Parse("1973-01-11")},
new Client{ClientID=104,NumeClient="DavidAnton",Sex="Masculin",DataDeNastere=DateTime.Parse("1990-02-03")},
new Client{ClientID=105,NumeClient="AntoniaStefan",Sex="Feminini",DataDeNastere=DateTime.Parse("2000-08-11")},
new Client{ClientID=106,NumeClient="VladConstantin",Sex="Masculin",DataDeNastere=DateTime.Parse("1995-07-05")}
            };

            foreach (Client c in clienti)
            {
                context.Clienti.Add(c);
            }
            context.SaveChanges();

            var rezervari = new Rezervare[]
            {
 new Rezervare{ClientID=101,CameraID=01,NumarNopti=1,DataRezervare=DateTime.Parse("03-15-2021")},
 new Rezervare{ClientID=102,CameraID=03,NumarNopti=4,DataRezervare=DateTime.Parse("11-13-2021")},
 new Rezervare{ClientID=103,CameraID=02,NumarNopti=5,DataRezervare=DateTime.Parse("08-23-2021")},
 new Rezervare{ClientID=106,CameraID=11,NumarNopti=10,DataRezervare=DateTime.Parse("02-21-2021")},
 new Rezervare{ClientID=104,CameraID=21,NumarNopti=3,DataRezervare=DateTime.Parse("08-14-2021")},
 new Rezervare{ClientID=105,CameraID=31,NumarNopti=7,DataRezervare=DateTime.Parse("06-17-2021")}
            };
            foreach (Rezervare e in rezervari)
            {
                context.Rezervari.Add(e);
            }
            context.SaveChanges();

            var facturi = new Factura[]
            {
new Factura{ClientID=101, Statut="PersoanaFizica",NumarNopti=1,PretNoapte=Decimal.Parse("270"),TotalFactura=Decimal.Parse("270")},
new Factura{ClientID=102, Statut="Persoajuridica",NumarNopti=10,PretNoapte=Decimal.Parse("270"),TotalFactura=Decimal.Parse("2700")}
            };
            foreach(Factura f in facturi)
            {
                context.Facturi.Add(f);
            }
            context.SaveChanges();

            var proprietari = new Proprietar[]
 {

 new Proprietar{NumeProprietar="Hotel International",Adress="Strada Palat 5A, Iași 700032"},
 new Proprietar{NumeProprietar="Hotel International1",Adress="Strada Palat 5A, Iași 700032"},
 new Proprietar{NumeProprietar="Hotel International2",Adress="Strada Palat 5A, Iași 700032"},
 new Proprietar{NumeProprietar="Hotel International3",Adress="Strada Palat 5A, Iași 700032"},
 new Proprietar{NumeProprietar="Hotel International4",Adress="Strada Palat 5A, Iași 700032"},
 new Proprietar{NumeProprietar="Hotel International5",Adress="Strada Palat 5A, Iași 700032"},
 };
            foreach (Proprietar p in proprietari)
            {
                context.Proprietari.Add(p);
            }
            context.SaveChanges();


            var camerainchiriata = new CameraInchiriata[]
            {
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 0 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International").ProprietarID},
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 1 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International1").ProprietarID},
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 2 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International2").ProprietarID},
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 3 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International3").ProprietarID},
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 4 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International4").ProprietarID},
new CameraInchiriata {CameraID = camere.Single(c => c.Etaj == 5 ).CameraID,ProprietarID = proprietari.Single(i => i.NumeProprietar =="Hotel International5").ProprietarID}
            };
            foreach (CameraInchiriata ci in camerainchiriata)
            {
                context.CamereInchiriate.Add(ci);
            }
            context.SaveChanges();
        }

    }
    }


