#pragma checksum "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "433673363a09be179ade3fbc86b7396c2a2ad77f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edificio_Index), @"mvc.1.0.view", @"/Views/Edificio/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\_ViewImports.cshtml"
using TesteSenior.Asp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\_ViewImports.cshtml"
using TesteSenior.Asp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"433673363a09be179ade3fbc86b7396c2a2ad77f", @"/Views/Edificio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e5d5d2d5311b9a621825700d8fc78271c8054d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Edificio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<testesenior.Domain.DTO.TabelaApartamentoDTO>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
  
    ViewData["Title"] = "Apartamentos";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">Código Apartamento</th>
            <th scope=""col"">Numero de Quartos</th>
            <th scope=""col"">Metragem</th>
            <th scope=""col"">Andar</th>
        </tr>
    </thead>
    <tbody>

");
#nullable restore
#line 18 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
           foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("onclick", " onclick=\"", 473, "\"", 514, 3);
            WriteAttributeValue("", 483, "Editar(", 483, 7, true);
#nullable restore
#line 20 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
WriteAttributeValue("", 490, item.codigoApartamento, 490, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 513, ")", 513, 1, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"cursor:pointer\">\r\n                    <td>");
#nullable restore
#line 21 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
                   Write(item.codigoApartamento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 22 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
                   Write(item.numeroQuartos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 23 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
                   Write(item.metragem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
                   Write(item.andar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 26 "E:\Projetos\VisualStudio\TesteSenior\TesteSenior.Asp\Views\Edificio\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

    </tbody>
</table>


<script>

    function Editar(Codigo) {
        window.location = window.origin + ""/Apartamento/Apartamento/"" + Codigo;
        console.log(""Editar"")
    }

    function Cadastrar() {
        window.location = window.origin + ""/Apartamento/Cadastrar"";
    }

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<testesenior.Domain.DTO.TabelaApartamentoDTO>> Html { get; private set; }
    }
}
#pragma warning restore 1591