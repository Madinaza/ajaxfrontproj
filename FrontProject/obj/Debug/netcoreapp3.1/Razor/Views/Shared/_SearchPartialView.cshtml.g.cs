#pragma checksum "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6d530ab6fe53c9f5eba6dcbedb1b3a992eeb78b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchPartialView), @"mvc.1.0.view", @"/Views/Shared/_SearchPartialView.cshtml")]
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
#line 1 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\_ViewImports.cshtml"
using FrontProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\_ViewImports.cshtml"
using FrontProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\_ViewImports.cshtml"
using FrontProject.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6d530ab6fe53c9f5eba6dcbedb1b3a992eeb78b", @"/Views/Shared/_SearchPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"818c083b310699943b2d3dc3779a7290a68f493f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Flower>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
 if (Model.Count > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
     foreach (Flower flower in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            ");
#nullable restore
#line 10 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
       Write(flower.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n");
#nullable restore
#line 12 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>Netice tapilmadi</li>\r\n");
#nullable restore
#line 17 "C:\Users\User\Desktop\Yeni qovluq\FrontProject\Views\Shared\_SearchPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Flower>> Html { get; private set; }
    }
}
#pragma warning restore 1591
