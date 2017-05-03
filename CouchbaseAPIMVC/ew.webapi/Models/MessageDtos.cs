using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ew.webapi.Models
{
    public class Request_SendMailRegisterSuccessDto
    {
        //public string MailFrom { get; set; }
        [Required]
        public string MailTo { get; set; }
        public string MailBccs { get; set; }
        //[Required]
        //public string Subject { get; set; }
        //[Required]
        //public string Body { get; set; }
    }

    public class Request_SendMailDto
    {
        //public string MailFrom { get; set; }
        [Required]
        public string MailTo { get; set; }
        public string MailBccs { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}