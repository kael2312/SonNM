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
                                StaffCode = ws.Cells[i, 2].Value.ToString().Trim(),
                                FullName = ws.Cells[i, 3].Value.ToString().Trim(),
                                Department = ws.Cells[i, 4].Value.ToString().Trim(),
                                Position = ws.Cells[i, 5].Value.ToString().Trim(),
                                DOE = ws.Cells[i, 6].Value.ToString().Trim(),
                                YOE = ws.Cells[i, 7].Value.ToString().Trim(),
                                Depedent  = ws.Cells[i, 8].Value.ToString().Trim(),
                                LeaveTaken = ws.Cells[i, 9].Value.ToString().Trim(),
                                KPI = ws.Cells[i, 10].Value.ToString().Trim(),
                                SalaryMonthly = ws.Cells[i, 11].Value.ToString().Trim(),
                                SalaryYearly = ws.Cells[i, 12].Value.ToString().Trim(),
                                BonusJun24Monthly = ws.Cells[i, 13].Value.ToString().Trim(),
                                BonusJun24Yearly = ws.Cells[i, 14].Value.ToString().Trim(),
                                BonusDec23Monthly = ws.Cells[i, 15].Value.ToString().Trim(),
                                BonusDec23Yearly = ws.Cells[i, 16].Value.ToString().Trim(),
                                PITMonthly = ws.Cells[i, 17].Value.ToString().Trim(),
                                LunchMonthly = ws.Cells[i, 18].Value.ToString().Trim(),
                                LunchYearly = ws.Cells[i, 19].Value.ToString().Trim(),
                                MobileMonthly = ws.Cells[i, 20].Value.ToString().Trim(),
                                MobileYearly = ws.Cells[i, 21].Value.ToString().Trim(),
                                PetroMonthly = ws.Cells[i, 22].Value.ToString().Trim(),
                                PetroYearly = ws.Cells[i, 23].Value.ToString().Trim(),
                                TaxiMonthly = ws.Cells[i, 24].Value.ToString().Trim(),
                                TaxiYearly = ws.Cells[i, 25].Value.ToString().Trim(),
                                UniformMonthLy = ws.Cells[i, 26].Value.ToString().Trim(),
                                UniformYearly = ws.Cells[i, 27].Value.ToString().Trim(),
                                MedicalInsuranceMonthly = ws.Cells[i, 28].Value.ToString().Trim(),
                                MedicalInsuranceYearly = ws.Cells[i, 29].Value.ToString().Trim(),
                                AccidentInsuranceMonthly = ws.Cells[i, 30].Value.ToString().Trim(),
                                AccidentInsuranceYearly = ws.Cells[i, 31].Value.ToString().Trim(),
                                HealthCheckupMonthly = ws.Cells[i, 32].Value.ToString().Trim(),
                                HealthCheckupYearly = ws.Cells[i, 33].Value.ToString().Trim(),
                                SocialInsuranceMonthly = ws.Cells[i, 34].Value.ToString().Trim(),
                                SocialInsuranceYearly = ws.Cells[i, 35].Value.ToString().Trim(),
                                TotalMonthly = ws.Cells[i, 36].Value.ToString().Trim(),
                                TotalYearly = ws.Cells[i, 37].Value.ToString().Trim(),
                                BasicSalary = ws.Cells[i, 38].Value.ToString().Trim(),
                                NewSalary = ws.Cells[i, 39].Value.ToString().Trim(),
                            });
                        }
                    }
                }
                return Json(lstPersonIncome);
            }
            return Json(null);
        }
    }
}
