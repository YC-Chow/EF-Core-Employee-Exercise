namespace EmployeeEx.Models {
    public class Customer {
        public int Id { get; set; }
        public string  FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int YrsOfPatronage { get; set; }

        public void PrintDetails() {
            System.Console.WriteLine("ID : {0}", Id);
            System.Console.WriteLine("FName : {0}", FName);
            System.Console.WriteLine("MName : {0}", MName);
            System.Console.WriteLine("LName : {0}", LName);
            System.Console.WriteLine("Address : {0}", Address);
            System.Console.WriteLine("YrsOfPatronage : {0}", YrsOfPatronage);
        }
    }
}
