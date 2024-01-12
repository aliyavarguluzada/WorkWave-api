using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWaveApp.Domain.Entities
{
    public class ContactInfo : BaseEntity
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public int StatusId { get; set; }
        public  Status Status { get; set; }

    }
}
