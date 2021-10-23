﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }

        public string AdminMail { get; set; }

        public string AdminPassword { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public ICollection<Admin> Admins { get; set; }


    }
}
