using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfieLottery.Models
{
    public class Registrazione
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public HttpPostedFileBase Foto { get; set; }

        public string Url { get; set; }
    }
}
