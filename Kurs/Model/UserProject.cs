using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.Model
{
    [DataContract]
    public class UserProject
    {
        [Required]
        [DataMember]
        public Guid UserProjectId { get; set; }

        [Required]
        [DataMember]
        public Guid UserId { get; set; }

        [Required]
        [DataMember]
        public Guid ProjectId { get; set; }
    }
}
