using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace testesenior.Domain.Enums
{

    public enum EnumExames
    {
        [EnumMember ]
        [Display(Name = "Ureia")]
        [Description("Ureia")]
        Ureia = 0,
        [EnumMember]
        [Display(Name = "Creatinina")]
        [Description("Creatinina")] 
        Creatinina = 1,
        [EnumMember]
        [Display(Name = "Urina 1")]
        [Description("Urina 1")] 
        Urina1 = 2,
        [EnumMember]
        [Display(Name = "Hemograma")]
        [Description("Hemograma")] 
        Hemograma = 3,
        [EnumMember]
        [Display(Name = "LDH")]
        [Description("LDH")] 
        LDH = 4,
        [EnumMember]
        [Display(Name = "Ácido Úrico")]
        [Description("Ácido Úrico")] 
        AcidoUrico = 5,
        [EnumMember]
        [Display(Name = "HIV")]
        [Description("HIV")] HIV = 6,
        [EnumMember]
        [Display(Name = "HBSAG")]
        [Description("HBSAG")] HBSAG = 7

    }
}
