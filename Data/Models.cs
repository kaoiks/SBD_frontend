using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data
{

    public class Insurance
    {
        public string insurance_number { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public double amount { get; set; }
        public string vehicle { get; set; }
    }

    public class Repair
    {
        public int id { get; set; }
        public List<RepairCost> repair_costs { get; set; }
        public string repair_date { get; set; }
        public string description { get; set; }
        public string vehicle { get; set; }
    }

    public class RepairCost
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string date { get; set; }
        public string invoice_id { get; set; }
        public int repair { get; set; }
    }

    public class Vehicle
    {
        public string vin { get; set; }
        public List<Repair> repairs { get; set; }
        public List<Insurance> insurances { get; set; }
        public int year_of_production { get; set; }
        public string car_review { get; set; }
        public double fuel_usage { get; set; }
        public int kilometers_done { get; set; }
    }

    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public int type { get; set; }
    }

    public class Invoice
    {
        public int id { get; set; }
        public double amount { get; set; }
        public string invoice_number { get; set; }
        public string date { get; set; }

        public string contractor_name { get; set; }


    }

    public class Contractor
    {
        public string nip { get; set; }
        public Address address { get; set; }
        public List<Invoice> invoices { get; set; }

        
        public string name { get; set; }
        public string country_id { get; set; }
    }


    public class FormVehicle
    {
        [Required(ErrorMessage = "VIN is required.")]
        [MinLength(17, ErrorMessage = "VIN consists of 17 capital letters and digits.")]
        [MaxLength(17, ErrorMessage = "VIN consists of 17 capital letters and digits.")]
        [RegularExpression(@"[A-Z0-9]+", ErrorMessage = "VIN consists of capital letters and digits.")]
        public string vin { get; set; }
        [Required(ErrorMessage = "Year of Production is required.")]
        [Range(1850, 3000, ErrorMessage = "Accepted years are between 1850 and 3000.")]
     
        public int year_of_production { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime car_review { get; set; }
        public double fuel_usage { get; set; }
        [Required(ErrorMessage = "Kilometers are required.")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Kilometeres should be higher or equal 0.")]
        public int kilometers_done { get; set; }
    }

    public class FormContractor
    {
        [BindProperty]
        [Required(ErrorMessage = "NIP is required.")]
        [MinLength(10, ErrorMessage = "NIP consists of 10 digits.")]
        [MaxLength(10, ErrorMessage = "NIP consists of 10 digits.")]
        [RegularExpression(@"\d+", ErrorMessage = "NIP consists of numbers only.")]
        [PageRemote(HttpMethod ="post", 
            PageHandler ="CheckNIP",ErrorMessage ="This NIP already exists!")]
        public string nip { get; set; }

        public int address { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(256, ErrorMessage = "Name is too long.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Country ID is required.")]
        [MinLength(2, ErrorMessage = "Country ID consists of 2 letters.")]
        [MaxLength(2, ErrorMessage = "Country ID consists of 2 letters.")]
        [RegularExpression(@"[A-Z]+", ErrorMessage = "Country ID consists of capital letters.")]
        public string country_id { get; set; }

       
    }

    public class FormAddress
    {
        // public int id { get; set; }
        [Required(ErrorMessage = "Street is required.")]
        [MaxLength(256, ErrorMessage = "Street is too long.")]
        public string street { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [MaxLength(140, ErrorMessage = "City is too long.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "City consists of letters.")]
        public string city { get; set; }
        [Required(ErrorMessage = "Postal Code is required.")]
        [MaxLength(10, ErrorMessage = "Postal Code is too long.")]
        public string postal_code { get; set; }
        public int type { get; set; }
    }

    public class FormInvoice
    {
        [Required(ErrorMessage = "Amount is required.")]
        
        public double amount { get; set; }
        [Required(ErrorMessage = "Invoice Number Number is required.")]
        [MaxLength(100, ErrorMessage = "Invoice Number is too long.")]
        public string invoice_number { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Contractor is required.")]
        [MinLength(5, ErrorMessage = "Contractor is required.")]
        public string contractor { get; set; }
    }

    public class FormInsurance
    {
        [Required(ErrorMessage = "Insurance Number is required.")]
        public string insurance_number { get; set; }
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime start_date { get; set; }
        [Required(ErrorMessage = "End Date is required.")]
        public DateTime end_date { get; set; }
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, Int32.MaxValue, ErrorMessage = "Amount has to be higher or equal to 0.01")]
        public double amount { get; set; }
        [Required(ErrorMessage = "VIN is required.")]
        [MinLength(10, ErrorMessage = "VIN is required.")]
        public string vin { get; set; }
    }

    public class FormRepair
    {


        //public DateTime repair_date { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string description { get; set; }
        [Required(ErrorMessage = "VIN is required.")]
        [MinLength(10, ErrorMessage = "VIN is required.")]
        public string vin { get; set; }
    }

    public class FormRepairCost
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, Int32.MaxValue, ErrorMessage="Amount has to be higher or equal to 0.01")]
        public double amount { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Invoice ID is required.")]
        public string invoice_id { get; set; }
        public int repair { get; set; }
    }

    public class Driver
    {
        public string pesel { get; set; }
        public Address address { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string date_of_birth { get; set; }
        public string driver_license_number { get; set; }
        public string date_qualification_certificate { get; set; }

        public string date_bhp_course { get; set; }
    }

    public class FormDriver
    {
        [Required(ErrorMessage = "PESEL is required.")]
        [MinLength(11, ErrorMessage = "PESEL consists of 11 digits.")]
        [MaxLength(11, ErrorMessage = "PESEL consists of 11 digits.")]
        [RegularExpression(@"\d+", ErrorMessage = "PESEL consists of numbers only.")]
        public string pesel { get; set; }
        public int address { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Name is too long.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Name consists of letters.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        [MaxLength(200, ErrorMessage = "Surname is too long.")]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Surname consists of letters.")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public DateTime date_of_birth { get; set; }
        [Required(ErrorMessage = "Driver License Number is required.")]
        [RegularExpression(@"[A-Z0-9]+", ErrorMessage = "Driver License Number consists of capital letters and digits.")]
        [MaxLength(100, ErrorMessage = "Driver License Number is too long.")]
        public string driver_license_number { get; set; }
        [Required(ErrorMessage = "Qualification Certificate Expiration Date is required.")]
        public DateTime date_qualification_certificate { get; set; }
        [Required(ErrorMessage = "BHP Course Expiration Date is required.")]

        public DateTime date_bhp_course { get; set; }
    }

    public class Trail
    {
        public int route_id { get; set; }
        public string date { get; set; }
        public string begin { get; set; }
        public string end { get; set; }
        public int distance { get; set; }
        public Driver driver { get; set; }
        public Contractor contractor { get; set; }

        public Vehicle vehicle { get; set; }
    }

    public class FormTrail
    {
        [Required(ErrorMessage = "Date is required.")]
        public DateTime date { get; set; }
        [Required(ErrorMessage = "Begin is required.")]
        [MaxLength(100, ErrorMessage = "Begin is too long.")]
        public string begin { get; set; }
        [Required(ErrorMessage = "End is required.")]
        [MaxLength(100, ErrorMessage = "End is too long.")]
        public string end { get; set; }
        [Required(ErrorMessage = "Distance is required.")]
        public int distance { get; set; }
        [Required(ErrorMessage = "Driver is required.")]
        [MinLength(10, ErrorMessage = "Driver is required.")]
        public string driver { get; set; }
        [Required(ErrorMessage = "Contractor is required.")]
        [MinLength(10, ErrorMessage = "Contractor is required.")]
        public string contractor { get; set; }
        [Required(ErrorMessage = "VIN is required.")]
        [MinLength(10, ErrorMessage = "VIN is required.")]

        public string vehicle { get; set; }
    }

    public class Settlement
    {
        public int id { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int days_stationary { get; set; }
        public int days_leave { get; set; }
        public int saturdays { get; set; }
        public double rate_for_kilometer { get; set; }

        public int kilometers_done { get; set; }
        public string driver { get; set; }
    }
    public class FormSettlement
    {
       
        public int month { get; set; }
        public int year { get; set; }
        public int days_stationary { get; set; }
        public int days_leave { get; set; }
        public int saturdays { get; set; }
        public double rate_for_kilometer { get; set; }

        public int kilometers_done { get; set; }
        public string driver { get; set; }
    }






}
