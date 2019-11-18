using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DVDLibrary.Models
{
    [Table("Rating")]
    public class Rating
    {
        /// <summary>
        /// 
        /// </summary>
        public Rating()
        {
            DVDs = new HashSet<DVD>();
        }

        public int ratingId { get; set; }
        [Required]
        public string ratingName { get; set; }

        public virtual ICollection<DVD> DVDs {get; set;}
    }
}
