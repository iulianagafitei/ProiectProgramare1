using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgramareProiect.Models
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientID { get; set; }
        public string NumeClient { get; set; }
        public string Sex { get; set; }
        public DateTime DataDeNastere { get; set; }
        public ICollection<Rezervare> Rezervari { get; set; }

    }
}
