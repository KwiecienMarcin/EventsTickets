using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TicketStore.Business.Models
{
    public class AvailableTicketTypeBl
    {
	    public int Id { get; set; }
		public string Name;
        public double Price;
        public int AvailablePlaces;
        
    }

}
