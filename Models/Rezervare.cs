using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramareProiect.Models
{
    public class Rezervare
    {
        public int RezervareID { get; set; }
        public int ClientID { get; set; }
        public int CameraID { get; set; }
        public int NumarNopti { get; set; }
        public DateTime DataRezervare { get; set; }

        public Camera Camera { get; set; }
        public Client Client { get; set; }

    }
}
