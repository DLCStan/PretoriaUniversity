#pragma checksum "C:\Users\Joe\source\repos\GendacMVCForAPI\GendacMVCForAPI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3525cedd94fa28d1780c75f807621ee68fb7b970"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Joe\source\repos\GendacMVCForAPI\GendacMVCForAPI\Views\_ViewImports.cshtml"
using GendacMVCForAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Joe\source\repos\GendacMVCForAPI\GendacMVCForAPI\Views\_ViewImports.cshtml"
using GendacMVCForAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3525cedd94fa28d1780c75f807621ee68fb7b970", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4722697a544f34723d484daad4f6d512eeed5add", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Joe\source\repos\GendacMVCForAPI\GendacMVCForAPI\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- <div class=""text-center""> -->
<div class=""jumbotron"">
    <h1 class=""display-4"">Gendac API Assignment</h1>
    <h2>done by Joe Mahlokozela</h2>
    <p>Learn more about <a href=""https://www.gendac.co.za"">Gendac</a>.</p>

</div>

<div class=""row"">
    <div class=""col-md-4"">
        <h2>Description</h2>
        <p>
            The Application fetches data from the Gendac API and
            seeds in into the database. The application has CRUD features for
            the user to manipulate Products.
        </p>
    </div>

    <div class=""col-md-4"">
        <h2>Additional features</h2>
        <p>
            The application has input validation for the entered fields and the
            culture of the application is South African.
        </p>
    </div>

    <div class=""col-md-4"">
        <h2>Download the ReadMe.txt file</h2>
        <p>
            This section will contain the link to my .txt file
        </p>
    </div>
</div>
");
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
