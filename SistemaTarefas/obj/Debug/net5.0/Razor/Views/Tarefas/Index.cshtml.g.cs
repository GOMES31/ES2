#pragma checksum "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6abfd3d1c819ea74885ff56b98eced806eceb82"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tarefas_Index), @"mvc.1.0.view", @"/Views/Tarefas/Index.cshtml")]
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
#line 1 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\_ViewImports.cshtml"
using SistemaTarefas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\_ViewImports.cshtml"
using SistemaTarefas.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6abfd3d1c819ea74885ff56b98eced806eceb82", @"/Views/Tarefas/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8d110121a47d04b6cd70076a338bbea9e2dd0ed", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Tarefas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaTarefas.Entities.Tarefa>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
  
    ViewData["Title"] = "Projetos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Tarefas</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6abfd3d1c819ea74885ff56b98eced806eceb824992", async() => {
                WriteLiteral("Criar nova tarefa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.id_tarefa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.hora_inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.hora_fim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.precohora));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Projetos.nomeProjeto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Users.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            \r\n");
            WriteLiteral("            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 48 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.id_tarefa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.hora_inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.hora_fim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <th>\r\n                ");
#nullable restore
#line 63 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 66 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.precohora));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <td>\r\n                ");
#nullable restore
#line 69 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Projetos.nomeProjeto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 72 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Users.name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6abfd3d1c819ea74885ff56b98eced806eceb8213045", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
                                       WriteLiteral(item.id_tarefa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" | \r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6abfd3d1c819ea74885ff56b98eced806eceb8215296", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
                                          WriteLiteral(item.id_tarefa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6abfd3d1c819ea74885ff56b98eced806eceb8217552", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
                                         WriteLiteral(item.id_tarefa);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 80 "C:\Users\dugom\OneDrive\Ambiente de Trabalho\Geral\Uni\ES2_TP_Goncalo_Joao\ES2_TP_Goncalo_Joao\Es2\Es\Demo Project\SistemaTarefas\Views\Tarefas\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaTarefas.Entities.Tarefa>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591