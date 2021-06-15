#pragma checksum "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06c8945d7d458b3124586068e1b8330a2d6512de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Controls), @"mvc.1.0.view", @"/Views/Admin/Controls.cshtml")]
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
#line 1 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\_ViewImports.cshtml"
using FoodService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\_ViewImports.cshtml"
using FoodService.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06c8945d7d458b3124586068e1b8330a2d6512de", @"/Views/Admin/Controls.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e61dcc8ce942c9b62e6d41aab60db856b58d840", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Controls : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
  
    Layout = "_AdminLayout";
    ViewBag.Title = "Управление сервером";

    string error = FoodService.Utils.MessageUtils.PopError(TempData);
    string successMessage = FoodService.Utils.MessageUtils.PopSuccessMessage(TempData);

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
 if (error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">");
#nullable restore
#line 10 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
                               Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 11 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""h4 text-info"">Сервер</div>
<div><hr></div>
<div class=""mt-1""><a class=""btn btn-secondary"" type=""button"" href=""/Admin/RestartServer"">Перезапустить сервер</a></div>
<div><hr></div>
<div class=""h4 text-info mt-4"">База данных</div>
<div><hr></div>
<div class=""mt-1""><a class=""btn btn-secondary"" type=""button"" href=""/Admin/DbBackup"">Сделать резервную копию базы данных</a></div>
<div class=""mt-1""><a class=""btn btn-secondary"" type=""button"" href=""/Admin/DbRestore"">Восстановить базу данных из резервной копии</a></div>
<div><hr></div>

");
#nullable restore
#line 23 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
 if (successMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">");
#nullable restore
#line 25 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
                                Write(successMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 26 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Controls.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591