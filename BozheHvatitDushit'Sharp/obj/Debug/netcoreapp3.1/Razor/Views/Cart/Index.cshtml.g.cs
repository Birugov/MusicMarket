#pragma checksum "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d45d8a2cc03ef5415207939fe1ae9e66f6c7eca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\_ViewImports.cshtml"
using BozheHvatitDushit_Sharp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\_ViewImports.cshtml"
using BozheHvatitDushit_Sharp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d45d8a2cc03ef5415207939fe1ae9e66f6c7eca1", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf2756e29700ce356d933327aba7e68f69e98971", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BozheHvatitDushitSharp.ViewModels.CartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container\">\r\n");
#nullable restore
#line 3 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\Cart\Index.cshtml"
     foreach (var elem in Model.shopCart.cartItems)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning mt-3\">\r\n            <p>");
#nullable restore
#line 6 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\Cart\Index.cshtml"
          Write(elem.item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p>");
#nullable restore
#line 7 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\Cart\Index.cshtml"
          Write(elem.item.price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 9 "C:\Users\asema\source\repos\MusicMarket\BozheHvatitDushit'Sharp\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\r\n    <div class=\"btn btn-danger\" asp-controller=\"Order\">Оплатить</div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BozheHvatitDushitSharp.ViewModels.CartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591