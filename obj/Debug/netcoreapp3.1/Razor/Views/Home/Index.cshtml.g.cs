#pragma checksum "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7b80ba8a605ab6cf9b088ae0615c9a5142987d26"
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
#line 1 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/_ViewImports.cshtml"
using eudaci;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/_ViewImports.cshtml"
using eudaci.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b80ba8a605ab6cf9b088ae0615c9a5142987d26", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79e741d78f369c1029429d34c4b7ff25c2d88e25", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

    var countries = (IEnumerable<eudaci.Models.Country>)ViewData["countries"];
    var countryIds = string.Join(",", countries.Select(x => x.Id).ToList());
    var countryNames = string.Join(",", countries.Select(x => x.Name).ToList());

    var infected = ViewData["infected"];
    var deaths = ViewData["deaths"];
    var recovered = ViewData["recovered"];
    var hospitalisations = ViewData["hospitalisations"];

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <section id=""our-stats"">
        <div class=""row text-center"">
            <div class=""col"">
                <div class=""counter"">
                    <i class=""fas fa-virus fa-2x""></i>
                    <h2 class=""timer count-title count-number"" data-to=""100"" data-speed=""1500"">");
#nullable restore
#line 20 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                                                                                          Write(infected);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <p class=""count-text "">Infected</p>
                </div>
            </div>
            <div class=""col"">
                <div class=""counter"">
                    <i class=""fa fa-laugh-beam fa-2x""></i>
                    <h2 class=""timer count-title count-number"" data-to=""1700"" data-speed=""1500"">");
#nullable restore
#line 27 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                                                                                           Write(recovered);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <p class=""count-text "">Recovered</p>
                </div>
            </div>
            <div class=""col"">
                <div class=""counter"">
                    <i class=""fa fa-skull-crossbones fa-2x""></i>
                    <h2 class=""timer count-title count-number"" data-to=""11900"" data-speed=""1500"">");
#nullable restore
#line 34 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                                                                                            Write(recovered);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <p class=""count-text "">Deaths</p>
                </div>
            </div>
            <div class=""col"">
                <div class=""counter"">
                    <i class=""fa fa-hospital fa-2x""></i>
                    <h2 class=""timer count-title count-number"" data-to=""157"" data-speed=""1500"">
                        ");
#nullable restore
#line 42 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                   Write(hospitalisations);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                    <p class=""count-text "">Hospitalisations</p>
                </div>
            </div>
        </div>
    </section>
</div>

<div id=""message"">
</div>

<!-- CSSMap - Europe -->
<div id=""map-europe"">
    <ul class=""europe"">
        <li class=""eu1""><a href=""#albania"">Albania</a></li>
        <li class=""eu2""><a href=""#andorra"">Andorra</a></li>
        <li class=""eu3""><a href=""#austria"">Austria</a></li>
        <li class=""eu4""><a href=""#belarus"">Belarus</a></li>
        <li class=""eu5""><a href=""#belgium"">Belgium</a></li>
        <li class=""eu6""><a href=""#bosnia-and-herzegovina"">Bosnia and Herzegovina</a></li>
        <li class=""eu7""><a href=""#bulgaria"">Bulgaria</a></li>
        <li class=""eu8""><a href=""#croatia"">Croatia</a></li>
        <li class=""eu9""><a href=""#cyprus"">Cyprus</a></li>
        <li class=""eu10""><a href=""#czech-republic"">Czech Republic</a></li>
        <li class=""eu11""><a href=""#denmark"">Denmark</a></li>
        <li class=""eu12""><a href=""#estonia"">E");
            WriteLiteral(@"stonia</a></li>
        <li class=""eu13""><a href=""#france"">France</a></li>
        <li class=""eu14""><a href=""#finland"">Finland</a></li>
        <li class=""eu15""><a href=""#georgia"">Georgia</a></li>
        <li class=""eu16""><a href=""#germany"">Germany</a></li>
        <li class=""eu17""><a href=""#greece"">Greece</a></li>
        <li class=""eu18""><a href=""#hungary"">Hungary</a></li>
        <li class=""eu19""><a href=""#iceland"">Iceland</a></li>
        <li class=""eu20""><a href=""#ireland"">Ireland</a></li>
        <li class=""eu21""><a href=""#san-marino"">San Marino</a></li>
        <li class=""eu22""><a href=""#italy"">Italy</a></li>
        <li class=""eu23""><a href=""#kosovo"">Kosovo</a></li>
        <li class=""eu24""><a href=""#latvia"">Latvia</a></li>
        <li class=""eu25""><a href=""#liechtenstein"">Liechtenstein</a></li>
        <li class=""eu26""><a href=""#lithuania"">Lithuania</a></li>
        <li class=""eu27""><a href=""#luxembourg"">Luxembourg</a></li>
        <li class=""eu28""><a href=""#macedonia"">Macedonia <abbr");
            WriteLiteral(@"
                    title=""The Former Yugoslav Republic of Macedonia"">(F.Y.R.O.M.)</abbr></a></li>
        <li class=""eu29""><a href=""#malta"">Malta</a></li>
        <li class=""eu30""><a href=""#moldova"">Moldova</a></li>
        <li class=""eu31""><a href=""#monaco"">Monaco</a></li>
        <li class=""eu32""><a href=""#montenegro"">Montenegro</a></li>
        <li class=""eu33""><a href=""#netherlands"">Netherlands</a></li>
        <li class=""eu34""><a href=""#norway"">Norway</a></li>
        <li class=""eu35""><a href=""#poland"">Poland</a></li>
        <li class=""eu36""><a href=""#portugal"">Portugal</a></li>
        <li class=""eu37""><a href=""#romania"">Romania</a></li>
        <li class=""eu38""><a href=""#russian-federation"">Russian Federation</a></li>
        <li class=""eu39""><a href=""#serbia"">Serbia</a></li>
        <li class=""eu40""><a href=""#slovakia"">Slovakia</a></li>
        <li class=""eu41""><a href=""#slovenia"">Slovenia</a></li>
        <li class=""eu42""><a href=""#spain"">Spain</a></li>
        <li class=""eu43""><a ");
            WriteLiteral(@"href=""#sweden"">Sweden</a></li>
        <li class=""eu44""><a href=""#switzerland"">Switzerland</a></li>
        <li class=""eu45""><a href=""#turkey"">Turkey</a></li>
        <li class=""eu46""><a href=""#ukraine"">Ukraine</a></li>
        <li class=""eu47""><a href=""#united-kingdom"">United Kingdom</a></li>
    </ul>
</div>
<!-- END OF THE CSSMap - Europe -->

<script type=""text/javascript"">
    const countryNames = """);
#nullable restore
#line 109 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                     Write(countryNames);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\",\");\r\n    const countryIds = \"");
#nullable restore
#line 110 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Home/Index.cshtml"
                   Write(countryIds);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split("","");

    $(""#map-europe"").CSSMap({
        ""size"": 850,
        ""tooltips"": ""floating-top-center"",
        ""responsive"": ""auto"",
        ""cities"": true,
        ""onClick"": function (e) {
            const rLink = e.children(""A"").eq(0).attr(""href""),
                rText = e.children(""A"").eq(0).text(),
                rClass = e.attr(""class"").split("" "")[0];

            const i = countryNames.indexOf(rText);

            if (i != -1) {
                window.location.href = ""/Countries/Details/"" + countryIds[i];
            } else {
                $(""#message"").replaceWith('<div id=""message""><div class=""alert alert-danger"" role=""alert"">' + rText + ' - Country not supported</div></div>');
            }

        }
    });
</script>
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
