using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TicketStore.Data.Models
{
    public class AvailableTicketType
    {
	    public int Id { get; set; }
		public string Name { get; set; }

	    public double Price { get; set; }
		public int AvailablePlaces { get; set; }

		public AvailableTicketType()
	    {
		    //Id = Guid.NewGuid();
	    }
    }
}
