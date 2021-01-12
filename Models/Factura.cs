using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramareProiect.Models
{

    
    public class Factura
    {
        public int FacturaID { get; set; }
        public int ClientID { get; set; }
        public string Statut { get; set; }
        public int NumarNopti { get; set; }
        public decimal PretNoapte { get; set; }
        public decimal TotalFactura { get; set; }

      /*  public static double CalculTotal(int Total)
        {
            Total = NumarNopti * TotalFactura;
            return Total;
        } */

        public Client Client { get; set; }
        

        



    }
}
