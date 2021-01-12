using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProgramareProiect.Models.LibraryViewModels
{
    public class RezervareGrup
    {
        [DataType(DataType.Date)]
        public DateTime? DataRezervare { get; set; }
        public int NumarCamera { get; set; }

    }
}
