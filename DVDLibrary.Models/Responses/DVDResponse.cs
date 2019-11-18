using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Responses
{
    public class DVDResponse : Response
    {
        public DVDView DVDView { get; set; }
        public DVD DVD { get; set; }
        public List<DVD> DVDList { get; set; }

    }
}
