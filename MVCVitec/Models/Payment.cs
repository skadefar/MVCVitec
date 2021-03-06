﻿using System.ComponentModel.DataAnnotations;

namespace MVCVitec.Models
{
    public class Payment
    {
        public int ID { get; set; }

        [Display(Name = "Kort nummer")]
        public int CardNumber { get; set; }

        [Display(Name = "Udløbsmåned")]
        [Range(1, 2, ErrorMessage = "Ugyldig Måned indtastet")]
        public int ExperationMonth { get; set; }

        [Display(Name = "Udløbsår")]
        [Range(1850, 2099, ErrorMessage = "Ugyldigt år indtastet")]
        public int ExperationYear { get; set; }

        [Display(Name = "CWR")]
        [Range(001, 999, ErrorMessage = "Ugyldigt CWR indtastet")]
        public int CardCWR { get; set; }

        public string CardHolderName { get; set; }
    }
}
