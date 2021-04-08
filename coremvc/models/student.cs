using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coremvc.models
{
    public class student
    {
         [Required(ErrorMessage ="isminizi giriniz.")]
        public string name { get; set; }
        [Required(ErrorMessage = "mail adresini giriniz.")]
        [EmailAddress(ErrorMessage = "lütfen e mail adresinizi düzgün giriniz")]
        public string email { get; set; }
        [Required(ErrorMessage = "telefon giriniz")]
        public string phone { get; set; }
        [Required(ErrorMessage = "kursa katılıp katılmayacğını belli olsun isteriz")]
        public bool willattend { get; set; }
    }
}
