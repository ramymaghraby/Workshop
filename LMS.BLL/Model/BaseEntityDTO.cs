using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Model
{
    public class BaseEntityDTO
    {
        public BaseEntityDTO() { 
            CreatedOn = DateTime.Now;
            IsActive = true;
        }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
