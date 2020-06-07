using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenancyAngular
{
    public class Tenant
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Key]
        public string HostUrl { get; set; }
        [Required]
        public string ApiKey { get; set; }
        [Required]
        public string SecretKey { get; set; }
        [Required]
        public string DbConnectionString { get; set; }
        [Required]
        public string StorageConnectionString { get; set; }
        [Required]
        public int isActive { get; set; }

    }
}
