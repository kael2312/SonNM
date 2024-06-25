using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Accounting.Models
{
    public class PersonIncomeModel
    {
        public string StaffCode { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string DOE { get; set; }
        public double YOE { get; set; }
        public int Depedent { get; set; }
        public double LeaveTaken { get; set; }
        public double KPI { get; set; }
        public string Email { get; set; }
        public double SalaryMonthly { get; set; }
        public double SalaryYearly { get; set; }
        public double BonusJun24Monthly { get; set; }
        public double BonusJun24Yearly { get; set; }
        public double BonusDec23Monthly { get; set; }
        public double BonusDec23Yearly { get; set; }
        public double PITMonthly { get; set; }
        public double PITYearly { get; set; }
        public double LunchMonthly { get; set; }
        public double LunchYearly { get; set; }
        public double MobileMonthly { get; set; }
        public double MobileYearly { get; set; }
        public double PetroMonthly { get; set; }
        public double PetroYearly { get; set; }
        public double TaxiMonthly { get; set; }
        public double TaxiYearly { get; set; }
        public double UniformMonthly { get; set; }
        public double UniformYearly { get; set; }
        public double MedicalInsuranceMonthly { get; set; }
        public double MedicalInsuranceYearly { get; set; }
        public double AccidentInsuranceMonthly { get; set; }
        public double AccidentInsuranceYearly { get; set; }
        public double HealthCheckupMonthly { get; set; }
        public double HealthCheckupYearly { get; set; }
        public double SocialInsuranceMonthly { get; set; }
        public double SocialInsuranceYearly { get; set; }
        public double TotalMonthly { get; set; }
        public double TotalYearly { get; set; }
        public double BasicSalary { get; set; }
        public double NewSalary { get; set; }
    }
}
