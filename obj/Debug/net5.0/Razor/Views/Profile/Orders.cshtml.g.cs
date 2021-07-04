#pragma checksum "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cbd24f6b6fa3d0cfff839584c38d89d4a40cc42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Orders), @"mvc.1.0.view", @"/Views/Profile/Orders.cshtml")]
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
#nullable restore
#line 1 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
using FoodService.Utils;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cbd24f6b6fa3d0cfff839584c38d89d4a40cc42", @"/Views/Profile/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e61dcc8ce942c9b62e6d41aab60db856b58d840", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FoodService.Models.DbEntities.Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
   
    string error = FoodService.Utils.MessageUtils.PopError(TempData);
    string successMessage = FoodService.Utils.MessageUtils.PopSuccessMessage(TempData);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n");
#nullable restore
#line 9 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
     if (error != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger\">");
#nullable restore
#line 11 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                                   Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 12 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
     if (successMessage != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success\">");
#nullable restore
#line 15 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                                    Write(successMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 16 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>Заказы: </h4>\r\n    <div>\r\n");
#nullable restore
#line 19 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
         if (Model.Count() == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4 class=\'text-center fst-italic\' style=\'text-decoration: underline;\'>Пусто</h4>\r\n");
#nullable restore
#line 22 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
         foreach (var order in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"bg-gray mt-2 p-3\">\r\n                <div>Дата: ");
#nullable restore
#line 26 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                      Write(order.OrderTimeStart.ToLocalTime().ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n                <div>\r\n                    Товары:\r\n                    <div>\r\n");
#nullable restore
#line 30 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                         foreach (var pack in order.ProductPacks)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span><a");
            BeginWriteAttribute("href", " href=\"", 1058, "\"", 1105, 2);
            WriteAttributeValue("", 1065, "/Home/Product?productId=", 1065, 24, true);
#nullable restore
#line 32 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
WriteAttributeValue("", 1089, pack.Product.Id, 1089, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                                                                                Write(pack.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>(");
#nullable restore
#line 32 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                                                                                                       Write(pack.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n");
#nullable restore
#line 33 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 1250, "\"", 1331, 2);
            WriteAttributeValue("", 1258, "font-weight-bold", 1258, 16, true);
#nullable restore
#line 36 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
WriteAttributeValue(" ", 1274, OrdersUtils.OrderStatusStyles[order.OrderStatus.Status], 1275, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    Статус: ");
#nullable restore
#line 37 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
                       Write(order.OrderStatus.StatusLocale);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 42 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Profile\Orders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FoodService.Models.DbEntities.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
