using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ew.webapi.Models
{
    public class CreateRepositoryDto
    {
        [Required]
        public string AccountId { get; set; }
        [Required]
        public string RepositoryName { get; set; }
    }
}