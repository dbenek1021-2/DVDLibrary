using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    [Table("Director")]
    public class Director
    {
        /// <summary>
        /// Used a HashSet to collect any new directors & to prevent
        /// any duplicates cuz HashSet collection can not contain
        /// duplicate elements
        /// </summary>
        public Director()
        {
            DVDs = new HashSet<DVD>();
        }

        public int directorId { get; set; }
        public string directorName { get; set; }
        public virtual ICollection<DVD> DVDs { get; set; }
    }
}
