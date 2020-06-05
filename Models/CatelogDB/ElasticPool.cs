using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular.Models.CatelogDB
{
    public class ElasticPool
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string PoolName { get; set; }
        [Required]
        public string ServerName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
