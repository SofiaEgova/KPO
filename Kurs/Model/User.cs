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
    public class User
    {
        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public string Login { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [DataMember]
        public bool IsActive { get; set; }
        
        [Required]
        [DataMember]
        public int UserRole { get; set; }

        [DataMember]
        public string Email { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Task> Tasks { get; set; }
    }
}
