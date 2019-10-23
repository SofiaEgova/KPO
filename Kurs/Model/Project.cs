using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Model
{
    [DataContract]
    public class Project
    {
        [Required]
        [DataMember]
        public Guid ProjectId { get; set; }

        [Required]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }
        
        [ForeignKey("ProjectId")]
        public virtual List<Task> Tasks { get; set; }
    }
}
