using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace testesenior.Domain.Enums
{
     public enum EnumExamesStatus
    {
        [EnumMember]
        [Display(Name = "Aguaradando liberação")]
        [Description("Aguaradando Liberação")]
        AguaradandoLiberacao = 0,
        [EnumMember]
        [Display(Name = "Liberado")]
        [Description("Liberado")]
        Liberado = 1,
        [EnumMember]
        [Display(Name = "Enviado")]
        [Description("Enviado")]
        Enviado = 2

    }
}
