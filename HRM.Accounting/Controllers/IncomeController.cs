using HRM.Accounting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HRM.Accounting.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Import()
        {
            var lstPersonIncome = new List<PersonIncomeModel>();
            var form = await HttpContext.Request.ReadFormAsync();
            var file = form.Files[0];

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets[0];
                    var rowCount = ws.Dimension.Rows;
                    for (int i = 3; i <= rowCount; i++)
                    {
                        if (ws.Cells[i, 2].Value != null)
                        {

                            lstPersonIncome.Add(new PersonIncomeModel
                            {
                                StaffCode = !string.IsNullOrEmpty(ws.Cells[i, 2].Value.ToString().Trim()) ? ws.Cells[i, 2].Value.ToString().Trim() : null,
                                FullName = !string.IsNullOrEmpty(ws.Cells[i, 3].Value.ToString().Trim()) ? ws.Cells[i, 3].Value.ToString().Trim() : null,
                                Department = !string.IsNullOrEmpty(ws.Cells[i, 4].Value.ToString().Trim()) ? ws.Cells[i, 4].Value.ToString().Trim() : null,
                                Position = !string.IsNullOrEmpty(ws.Cells[i, 5].Value.ToString().Trim()) ? ws.Cells[i, 5].Value.ToString().Trim() : null,
                                DOE = !string.IsNullOrEmpty(ws.Cells[i, 6].Value.ToString().Trim()) ? ws.Cells[i, 6].Value.ToString().Trim() : null,
                                YOE = !string.IsNullOrEmpty(ws.Cells[i, 7].Value.ToString().Trim()) ?  Double.Parse(ws.Cells[i, 7].Value.ToString().Trim()) : 0,
                                Depedent  = !string.IsNullOrEmpty(ws.Cells[i, 8].Value.ToString().Trim()) ? Int32.Parse(ws.Cells[i, 8].Value.ToString().Trim()) : 0,
                                LeaveTaken = !string.IsNullOrEmpty(ws.Cells[i, 9].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 9].Value.ToString().Trim()) : 0,
                                KPI = !string.IsNullOrEmpty(ws.Cells[i,10].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 10].Value.ToString().Trim()) : 0,
                                Email = !string.IsNullOrEmpty(ws.Cells[i, 11].Value.ToString().Trim()) ? ws.Cells[i, 11].Value.ToString().Trim() : null,
                                SalaryMonthly = !string.IsNullOrEmpty(ws.Cells[i, 12].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 12].Value.ToString().Trim()) : 0,
                                SalaryYearly = !string.IsNullOrEmpty(ws.Cells[i, 13].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 13].Value.ToString().Trim()) : 0,
                                BonusJun24Monthly = !string.IsNullOrEmpty(ws.Cells[i, 14].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 14].Value.ToString().Trim()) : 0,
                                BonusJun24Yearly = !string.IsNullOrEmpty(ws.Cells[i, 15].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 15].Value.ToString().Trim()) : 0,
                                BonusDec23Monthly = !string.IsNullOrEmpty(ws.Cells[i, 16].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 16].Value.ToString().Trim()) : 0,
                                BonusDec23Yearly = !string.IsNullOrEmpty(ws.Cells[i, 17].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 17].Value.ToString().Trim()) : 0,
                                PITMonthly = !string.IsNullOrEmpty(ws.Cells[i, 18].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 18].Value.ToString().Trim()) : 0,
                                PITYearly = !string.IsNullOrEmpty(ws.Cells[i, 19].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 19].Value.ToString().Trim()) : 0,
                                LunchMonthly = !string.IsNullOrEmpty(ws.Cells[i, 20].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 20].Value.ToString().Trim()) : 0,
                                LunchYearly = !string.IsNullOrEmpty(ws.Cells[i, 21].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 21].Value.ToString().Trim()) : 0,
                                MobileMonthly = !string.IsNullOrEmpty(ws.Cells[i, 22].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 22].Value.ToString().Trim()) : 0,
                                MobileYearly = !string.IsNullOrEmpty(ws.Cells[i, 23].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 23].Value.ToString().Trim()) : 0,
                                PetroMonthly = !string.IsNullOrEmpty(ws.Cells[i, 24].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 24].Value.ToString().Trim()) : 0,
                                PetroYearly = !string.IsNullOrEmpty(ws.Cells[i, 25].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 25].Value.ToString().Trim()) : 0,
                                TaxiMonthly = !string.IsNullOrEmpty(ws.Cells[i, 26].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 26].Value.ToString().Trim()) : 0,
                                TaxiYearly = !string.IsNullOrEmpty(ws.Cells[i, 27].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 27].Value.ToString().Trim()) : 0,
                                UniformMonthly = !string.IsNullOrEmpty(ws.Cells[i, 28].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 28].Value.ToString().Trim()) : 0,
                                UniformYearly = !string.IsNullOrEmpty(ws.Cells[i, 29].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 29].Value.ToString().Trim()) : 0,
                                MedicalInsuranceMonthly = !string.IsNullOrEmpty(ws.Cells[i, 30].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 30].Value.ToString().Trim()) : 0,
                                MedicalInsuranceYearly = !string.IsNullOrEmpty(ws.Cells[i, 31].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 31].Value.ToString().Trim()) : 0,
                                AccidentInsuranceMonthly = !string.IsNullOrEmpty(ws.Cells[i, 32].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 32].Value.ToString().Trim()) : 0,
                                AccidentInsuranceYearly = !string.IsNullOrEmpty(ws.Cells[i, 33].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 33].Value.ToString().Trim()) : 0,
                                HealthCheckupMonthly = !string.IsNullOrEmpty(ws.Cells[i, 34].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 34].Value.ToString().Trim()) : 0,
                                HealthCheckupYearly = !string.IsNullOrEmpty(ws.Cells[i, 35].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 35].Value.ToString().Trim()) : 0,
                                SocialInsuranceMonthly = !string.IsNullOrEmpty(ws.Cells[i, 36].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 36].Value.ToString().Trim()) : 0,
                                SocialInsuranceYearly = !string.IsNullOrEmpty(ws.Cells[i, 37].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 37].Value.ToString().Trim()) : 0,
                                TotalMonthly = !string.IsNullOrEmpty(ws.Cells[i, 38].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 38].Value.ToString().Trim()) : 0,
                                TotalYearly = !string.IsNullOrEmpty(ws.Cells[i, 39].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 39].Value.ToString().Trim()) : 0,
                                BasicSalary = !string.IsNullOrEmpty(ws.Cells[i, 40].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 40].Value.ToString().Trim()) : 0,
                                NewSalary = !string.IsNullOrEmpty(ws.Cells[i, 41].Value.ToString().Trim()) ? Double.Parse(ws.Cells[i, 41].Value.ToString().Trim()) : 0,
                            });
                        }
                    }
                }
                return Json(lstPersonIncome);
            }
        }
    }
}
