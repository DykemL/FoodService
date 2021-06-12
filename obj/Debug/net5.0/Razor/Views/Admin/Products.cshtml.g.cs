#pragma checksum "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a98c1c3839cdffcca3e3213617418ea6c04b4138"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Products), @"mvc.1.0.view", @"/Views/Admin/Products.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a98c1c3839cdffcca3e3213617418ea6c04b4138", @"/Views/Admin/Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e61dcc8ce942c9b62e6d41aab60db856b58d840", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FoodService.Models.DbEntities.Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("image-show"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("imageImg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/DefaultImage.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/admin-products.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
  
    Layout = "_AdminLayout";
    ViewBag.Title = "Товары";

    int counter = 1;
    string error = FoodService.Utils.MessageUtils.PopError(TempData);
    string successMessage = FoodService.Utils.MessageUtils.PopSuccessMessage(TempData);

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
 if (error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger\">");
#nullable restore
#line 12 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                               Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 13 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
 if (successMessage != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">");
#nullable restore
#line 16 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                                Write(successMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 17 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-row"">
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#addProductModal"">Добавить товар</button>
</div>

<table class=""table table-sm mt-2"">
    <thead>
        <tr>
            <th>#</th>
            <th>Название</th>
            <th width=""370px"" style=""word-wrap: break-word"">Описание</th>
            <th>Магазин</th>
            <th>Цена</th>
            <th>Изображение</th>
            <th width=""250px"">Действия</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 36 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\'row\'>");
#nullable restore
#line 39 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                           Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 40 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
               Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"word-break: break-all;\">");
#nullable restore
#line 41 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                                              Write(product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <th style=\"font-weight: normal\">");
#nullable restore
#line 42 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                                           Write(product.Shop.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 43 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("&#8381</th>\r\n                <td>\r\n                    <span type=\"button\" class=\"cursor-pointer text-info image-link\" data-toggle=\"modal\" data-target=\"#showImage\" data-imageLink=\"");
#nullable restore
#line 45 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                                                                                                                                            Write(product.Image.Path);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        <i class=\"fa fa-image\"></i>\r\n                        ");
#nullable restore
#line 47 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
                   Write(product.Image.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </span>\r\n                </td>\r\n                <td>\r\n                    <div class=\"row ml-auto\">\r\n                        <a class=\"btn btn-sm btn-danger cursor-pointer\" type=\"button\"");
            BeginWriteAttribute("href", " href=\"", 1874, "\"", 1923, 2);
            WriteAttributeValue("", 1881, "/Admin/DeleteProduct?productId=", 1881, 31, true);
#nullable restore
#line 52 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
WriteAttributeValue("", 1912, product.Id, 1912, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Удалить</a>\r\n                        <a class=\"btn btn-sm btn-secondary cursor-pointer\" type=\"button\" href=\"/Admin/ChangeProduct\">Изменить</a>\r\n                    </div>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 57 "D:\Repository\Visual Studio 2019\C#\.Net Core ASP\FoodService\Views\Admin\Products.cshtml"
            counter++;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<!-- Modal add product -->
<div class=""modal fade"" id=""addProductModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Добавление товара</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a98c1c3839cdffcca3e3213617418ea6c04b413813336", async() => {
                WriteLiteral(@"
                <div class=""modal-body"">

                    <div class=""form-group"">
                        <label for=""productName"">Название</label>
                        <input type=""text"" class=""form-control"" id=""productName"" name=""name"">
                    </div>
                    <div class=""form-group"">
                        <label for=""productDescription"">Описание</label>
                        <textarea type=""text"" class=""form-control"" id=""productDescription"" name=""description""></textarea>
                    </div>
                    <div class=""form-group"">
                        <label for=""productPrice"">Стоимость</label>
                        <input type=""text"" class=""form-control"" id=""productPrice"" name=""price"">
                    </div>
                    <div class=""form-group"">
                        <label for=""productShopName"">Название магазина</label>
                        <input type=""text"" class=""form-control"" id=""productShopName"" name=""shopName"">
  ");
                WriteLiteral(@"                  </div>
                    <div class=""form-group"">
                        <label for=""productImage"">Картинка</label>
                        <input type=""file"" class=""form-control-file"" id=""productImage"" name=""image"">
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" class=""btn btn-primary"">Добавить</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>

<!-- Modal show image -->
<div class=""modal fade"" id=""showImage"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""imageLabel""></h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""d-flex justify-content-center"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a98c1c3839cdffcca3e3213617418ea6c04b413817583", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a98c1c3839cdffcca3e3213617418ea6c04b413819055", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FoodService.Models.DbEntities.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
