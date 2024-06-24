#pragma checksum "C:\Users\minhs\source\repos\HRM.Accounting\HRM.Accounting\Views\Income\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c28ad4a2aba037d8807f8f6d8be01730a1068369"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Income_Index), @"mvc.1.0.view", @"/Views/Income/Index.cshtml")]
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
#line 1 "C:\Users\minhs\source\repos\HRM.Accounting\HRM.Accounting\Views\_ViewImports.cshtml"
using HRM.Accounting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\minhs\source\repos\HRM.Accounting\HRM.Accounting\Views\_ViewImports.cshtml"
using HRM.Accounting.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c28ad4a2aba037d8807f8f6d8be01730a1068369", @"/Views/Income/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e02a089ff2c04ff2a7f0ccc5f8423a75593931e", @"/Views/_ViewImports.cshtml")]
    public class Views_Income_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\minhs\source\repos\HRM.Accounting\HRM.Accounting\Views\Income\Index.cshtml"
  
    ViewData["Title"] = "Total income summary";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""https://cdn.datatables.net/2.0.8/css/dataTables.dataTables.css"" />
<script src=""https://cdn.datatables.net/2.0.8/js/dataTables.js""></script>

<div class=""card card-custom"">
    <table id=""myTable"" class=""display"">
    </table>
</div>
<input type=""file"" id=""import-document"" accept="".xlsx"" />

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        var ctbl_table;
        $(document).ready(function () {

            $('#btnImport').on('click', function () {
                $('#import-document').trigger('click');
            })

            $('#import-document').on('change', function () {
                if ($('#import-document').prop('files').length > 0) {
                    importDocument($('#import-document').prop('files')[0]);
                } else {
                    $('#import-document').trigger('click');
                }
            })
        });

        function importDocument(file) {
            var dataFr = new FormData();

            dataFr.append('file', file);
            $.ajax({
                url: """);
#nullable restore
#line 36 "C:\Users\minhs\source\repos\HRM.Accounting\HRM.Accounting\Views\Income\Index.cshtml"
                 Write(Url.Action("Import"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                type: ""POST"",
                data: dataFr,
                processData: false,
                contentType: false,
                enctype: ""multipart/form-data"",
                success: function (data) {
                    if (data != null) {
                        ctbl_table = $('#myTable').DataTable({
                            scrollCollapse: true,
                            scrollX: true,
                            scrollY: 300,
                            data: data,
                            columns: [
                                { data: 'fullName', title: 'Full Name', width: '20%' },
                                { data: 'department', title: 'Department' },
                                { data: 'position', title: 'Position' },
                                {
                                    data: null, title: 'DOE',
                                    render: function (data, type) {
                                        debugger
         ");
                WriteLiteral(@"                               data = data.doe + '\n' + data.yoe
                                        return data;
                                    }
                                },
                                {
                                    data: null, title: 'DOE',
                                    render: function (data, type) {
                                        debugger
                                        data = data.doe + '\n' + data.yoe
                                        return data;
                                    }
                                },
                                { data: 'depedent', title: 'Depedent' },
                                { data: 'leaveTaken', title: 'Leave taken' },
                                { data: 'kpi', title: 'KPI' },
                                { data: 'email', title: 'Email' },
                                { data: null, title: 'Salary' },
                                { data: null, title: 'Bon");
                WriteLiteral(@"us (Jul, 2024)' },
                                { data: null, title: 'Bonus (Dec, 2023)' },
                                { data: null, title: 'PIT' },
                                { data: null, title: 'Lunch' },
                                { data: null, title: 'Mobile' },
                                { data: null, title: 'Petro' },
                                { data: null, title: 'Taxi' },
                                { data: null, title: 'Uniform' },
                                { data: null, title: 'Medical Insurance' },
                                { data: null, title: 'Accident Insurance' },
                                { data: null, title: 'Health Checkup' },
                                { data: null, title: 'Social Insurance' },
                                { data: null, title: 'Basic Salary (30 Jun 24)' },
                                { data: null, title: 'Salary (30 Jun 24)' },
                                { data: null, title: 'Total' },
     ");
                WriteLiteral(@"                       ]
                        });
                    }
                },
                error: function (xhr) {
                    console.warn('xhr', xhr);
                }
            });
        }

        $('#myTable').on('click', 'tr', function () {
            console.log('clicked: ' + ctbl_table.row(this).data())
        })
    </script>
");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Toolbar", async() => {
                WriteLiteral(@"
    <a id=""btnImport"" href=""#"" class=""btn btn-sm btn-success mr-1"">
        <span class=""svg-icon svg-icon-sm mr-0"">
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"">
                <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                    <rect x=""0"" y=""0"" width=""24"" height=""24"" />
                    <path d=""M8.43296491,7.17429118 L9.40782327,7.85689436 C9.49616631,7.91875282 9.56214077,8.00751728 9.5959027,8.10994332 C9.68235021,8.37220548 9.53982427,8.65489052 9.27756211,8.74133803 L5.89079566,9.85769242 C5.84469033,9.87288977 5.79661753,9.8812917 5.74809064,9.88263369 C5.4720538,9.8902674 5.24209339,9.67268366 5.23445968,9.39664682 L5.13610134,5.83998177 C5.13313425,5.73269078 5.16477113,5.62729274 5.22633424,5.53937151 C5.384723,5.31316892 5.69649589,5.25819495 5.92269848,5.4165837 L6.72910242,5.98123382 C8.16546398,4.72182424 10.0239806,4 12,4 C16.418278,4 20,");
                WriteLiteral(@"7.581722 20,12 C20,16.418278 16.418278,20 12,20 C7.581722,20 4,16.418278 4,12 L6,12 C6,15.3137085 8.6862915,18 12,18 C15.3137085,18 18,15.3137085 18,12 C18,8.6862915 15.3137085,6 12,6 C10.6885336,6 9.44767246,6.42282109 8.43296491,7.17429118 Z"" fill=""#000000"" fill-rule=""nonzero"" />
                </g>
            </svg>
        </span>
        <span class=""d-none d-sm-inline"">Import</span>
    </a>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
