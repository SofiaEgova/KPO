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
    public class Task
    {
        [Required]
        [DataMember]
        public Guid TaskId { get; set; }

        [Required]
        [DataMember]
        public Guid UserId { get; set; }
        
        [DataMember]
        public Guid? ProjectId { get; set; }
        
        [DataMember]
        public Guid? SubtaskId { get; set; }

        [Required]
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public byte[] Pdf { get; set; }

        [DataMember]
        public string PdfTitle { get; set; }

        public virtual User User { get; set; }

        public virtual Project Project { get; set; }

        public virtual Task TaskForSubtask { get; set; }

        [ForeignKey("SubtaskId")]
        public virtual List<Task> Subtasks { get; set; }
    }
}
