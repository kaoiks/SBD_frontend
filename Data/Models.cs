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
        public string amount { get; set; }
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
        public string amount { get; set; }
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
        public string vin { get; set; }
        public int year_of_production { get; set; }
        public DateTime car_review { get; set; }
        public double fuel_usage { get; set; }
        public int kilometers_done { get; set; }
    }

    public class FormContractor
    {
        public string nip { get; set; }

        public int address { get; set; }
        public string name { get; set; }
        public string country_id { get; set; }
    }

    public class FormAddress
    {
       // public int id { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public int type { get; set; }
    }

    public class FormInvoice
    {
        public string amount { get; set; }
        public string invoice_number { get; set; }
        public DateTime date { get; set; }

        public string contractor { get; set; }
    }

    public class FormInsurance
    {
        public string insurance_number { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public double amount { get; set; }
        public string vin { get; set; }
    }

    public class FormRepair
    {
       
        
        //public DateTime repair_date { get; set; }
        public string description { get; set; }
        public string vin { get; set; }
    }

    public class FormRepairCost
    {
        public double amount { get; set; }
        public DateTime date { get; set; }
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
        public string pesel { get; set; }
        public int address { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime date_of_birth { get; set; }
        public string driver_license_number { get; set; }
        public DateTime date_qualification_certificate { get; set; }

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
       
        public DateTime date { get; set; }
        public string begin { get; set; }
        public string end { get; set; }
        public int distance { get; set; }
        public string driver { get; set; }
        public string contractor { get; set; }

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
