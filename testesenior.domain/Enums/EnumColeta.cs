using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace testesenior.Domain.Enums
{
    
    public enum EnumColeta
    {
        [EnumMember]
        [Display(Name = "Recebido")]
        [Description("Recebido")]
        Recebido = 0,
        [EnumMember]
        [Display(Name = "Recoleta")]
        [Description("Recoleta")]
        Recoleta = 1,
        [EnumMember]
        [Display(Name = "Não Coletado")]
        [Description("Não Coletado")]
        NaoColetado = 2

    }
}
