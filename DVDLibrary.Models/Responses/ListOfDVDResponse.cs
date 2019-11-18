using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Responses
{
    public class ListOfDVDResponse : Response
    {
        public List<DVDView> DVDs { get; set; }
    }
}
