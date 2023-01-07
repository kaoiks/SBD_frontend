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
        public string date { get; set; }
    }















}
