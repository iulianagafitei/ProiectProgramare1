using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramareProiect.Models
{
    public class CameraInchiriata
    {
        public int ProprietarID { get; set; }
        public int CameraID { get; set; }
        public Proprietar Proprietar { get; set; }
        public Camera Camera { get; set; }
    }
}
