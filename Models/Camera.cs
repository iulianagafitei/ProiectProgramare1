using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProgramareProiect.Models
{
    public class Camera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CameraID { get; set; }
        public int Etaj { get; set; }
        public string TipPat { get; set; }

        [Column(TypeName = "decimal(6, 2)")]

        public decimal PretNoapte { get; set; }
        public ICollection<Rezervare> Rezervari { get; set; }
        public ICollection<CameraInchiriata> CamereInchiriate { get; set; }



    }
}
