using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProgramareProiect.Models
{
    public class Proprietar
    {
        public int ProprietarID { get; set; }
        [Required]
        [Display(Name = "Nume Proprietar")]
        [StringLength(50)]
        public string NumeProprietar { get; set; }

        [StringLength(70)]
        public string Adress { get; set; }
        public ICollection<CameraInchiriata> CamereInchiriate { get; set; }
    }
}
