using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular.Models.CatelogDB
{
    public class Server
    {
        [Required]
        [Key]
        public int id { get; set; }
        public string ServerName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Port { get; set; }
    }
}
