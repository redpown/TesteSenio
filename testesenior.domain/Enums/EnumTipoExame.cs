using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace testesenior.Domain.Enums
{
  
    public enum EnumTipoExame
    {
        [EnumMember]
        [Display(Name = "Interno")]
        [Description("Interno")]
        Interno = 0,
        [EnumMember]
        [Display(Name = "Externo")]
        [Description("Externo")]
        Externo = 1

    }
}
