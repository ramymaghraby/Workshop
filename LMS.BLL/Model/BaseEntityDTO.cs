using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.BLL.Model
{
    public class BaseEntityDTO
    {
        public BaseEntityDTO() 
        {
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
