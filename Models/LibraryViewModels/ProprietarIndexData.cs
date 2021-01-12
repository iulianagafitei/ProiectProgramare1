using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramareProiect.Models.LibraryViewModels
{
    public class ProprietarIndexData
    {
        public IEnumerable<Proprietar> Publishers { get; set; }
        public IEnumerable<Camera> Camere { get; set; }
        public IEnumerable<Rezervare> Rezervari { get; set; }
    }
}
