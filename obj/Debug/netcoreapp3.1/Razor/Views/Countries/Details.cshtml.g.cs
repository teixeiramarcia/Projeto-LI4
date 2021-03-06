#pragma checksum "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0af68af2595abec66dc409e86aa5bb42e7615d09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Countries_Details), @"mvc.1.0.view", @"/Views/Countries/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0af68af2595abec66dc409e86aa5bb42e7615d09", @"/Views/Countries/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79e741d78f369c1029429d34c4b7ff25c2d88e25", @"/Views/_ViewImports.cshtml")]
    public class Views_Countries_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
  
    var country = (eudaci.Models.Country)ViewData["country"];
    var vaccination = (eudaci.Models.Vaccination)ViewData["vaccination"];
    var pandemic = (eudaci.Models.Pandemic)ViewData["pandemic"];
    var pandemics = (IEnumerable<eudaci.Models.Pandemic>)ViewData["pandemics"];

    var no_vaccins = country.Population - vaccination.QuantityFirstDose - vaccination.QuantitySecondDose;

    var dates = string.Join(",", pandemics.Select(x => x.Date.ToShortDateString()).ToList());

    var infected = string.Join(",", pandemics.Select(x => x.Infected).ToList());
    var deaths = string.Join(",", pandemics.Select(x => x.Deaths).ToList());
    var recovered = string.Join(",", pandemics.Select(x => x.Recovered).ToList());

    ViewData["Title"] = country.Name;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <section id=\"our-stats\">\r\n        <div class=\"row mb-5\">\r\n            <div class=\"col text-center\">\r\n                <h2 class=\"text-green h1 text-center\">");
#nullable restore
#line 22 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                                                 Write(country.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 22 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                                                               Write(pandemic.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Overview</h2>
            </div>
        </div>
        <div class=""row text-center"">
            <div class=""col"">
                <div class=""counter"">
                    <i class=""fas fa-virus fa-2x""></i>
                    <h2 class=""timer count-title count-number"" data-to=""100"" data-speed=""1500"">");
#nullable restore
#line 29 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                                                                                          Write(pandemic.Infected);

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
#line 36 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                                                                                           Write(pandemic.Recovered);

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
#line 43 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                                                                                            Write(pandemic.Deaths);

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
#line 51 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                   Write(pandemic.Hospitalisations);

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

<canvas id=""lineChart""></canvas>

<div class=""container pt-5"">
    <div class=""row"">
        <div class=""col-sm"">
            <canvas id=""panChart""></canvas>
        </div>
        <div class=""col-sm"">
            <canvas id=""deathChart""></canvas>
        </div>
    </div>
</div>

<div class=""container pt-5"">
    <div class=""row"">
        <div class=""col"">
        </div>
        <div class=""col"">
            <canvas id=""vaccChart""></canvas>
        </div>
        <div class=""col"">
        </div>
    </div>
</div>

<script>
    line();
    death();
    pandemic();
    vaccination();

    function vaccination() {
        const labels = [""Fully Vaccinated"", ""Vaccinated"", ""Other""];

        const data = {
            labels: labels,
            datasets: [
                {
                    data: [
                  ");
            WriteLiteral("      \"");
#nullable restore
#line 98 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                    Write(vaccination.QuantitySecondDose);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                        \"");
#nullable restore
#line 99 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                    Write(vaccination.QuantityFirstDose);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n                        \"");
#nullable restore
#line 100 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                    Write(no_vaccins);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
                    ],
                    backgroundColor: [
                        'rgb(75, 192, 192, 0.35)',
                        'rgb(54, 162, 235, 0.35)',
                        'rgb(255, 99, 132, 0.35)'
                    ]
                }
            ]
        };

        const config = {
            type: 'doughnut',
            data: data,
            options: {},
        };

        var myChart = new Chart(
            document.getElementById('vaccChart'),
            config
        );
    }

    function line() {
        const labels = """);
#nullable restore
#line 124 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                   Write(dates);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split(',');

        const data = {
            labels: labels,
            datasets: [
                {
                    label: 'Confirmed Cases',
                    backgroundColor: 'rgb(254, 142, 22, 0.25)',
                    borderColor: 'rgb(254, 142, 22)',
                    data: """);
#nullable restore
#line 133 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                      Write(infected);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split(','),
                    fill: true
                }
            ]
        };
        const config = {
            type: 'line',
            data,
            options: {}
        };

        var myChart = new Chart(
            document.getElementById('lineChart'),
            config
        );
    }

    function death() {
        const labels = """);
#nullable restore
#line 151 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                   Write(dates);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\',\');\r\n\r\n        const data = {\r\n            labels: labels,\r\n            datasets: [\r\n                {\r\n                    label: \'Deaths\',\r\n                    data: \"");
#nullable restore
#line 158 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                      Write(deaths);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split(','),
                    fill: true,
                    backgroundColor: 'rgb(255, 0, 0, 0.25)',
                    borderColor: 'rgb(255, 0, 0)',
                }
            ]
        };
        const config = {
            type: 'line',
            data,
            options: {}
        };

        var myChart = new Chart(
            document.getElementById('deathChart'),
            config
        );
    }

    function pandemic() {
        const labels = """);
#nullable restore
#line 178 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                   Write(dates);

#line default
#line hidden
#nullable disable
            WriteLiteral("\".split(\',\');\r\n\r\n        const data = {\r\n            labels: labels,\r\n            datasets: [\r\n                {\r\n                    label: \'Infected\',\r\n                    data: \"");
#nullable restore
#line 185 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                      Write(infected);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split(','),
                    fill: true,
                    backgroundColor: 'rgb(255, 177, 193, 0.5)',
                    borderColor: 'rgb(255, 177, 193)',
                },
                {
                    label: 'Recovered',
                    data: """);
#nullable restore
#line 192 "/Users/marciateixeira/Desktop/LI4/eudaci/Views/Countries/Details.cshtml"
                      Write(recovered);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""".split(','),
                    fill: true,
                    backgroundColor: 'rgb(154, 208, 245, 0.5)',
                    borderColor: 'rgb(154, 208, 245)',
                }
            ]
        };

        const config = {
            type: 'bar',
            data: data,
            options: {},
        };

        var myChart = new Chart(
            document.getElementById('panChart'),
            config
        );
    }
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
