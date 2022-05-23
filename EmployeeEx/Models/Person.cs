namespace EmployeeEx.Models {
    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string  LastName { get; set; }
        public string BankNo { get; set; }
        public bool IsEmployed { get; set; }

        public void PrintDetails() {
            System.Console.WriteLine("ID : {0}", Id);
            System.Console.WriteLine("First Name : {0}", FirstName);
            System.Console.WriteLine("Middle Name : {0}", MiddleName);
            System.Console.WriteLine("Last Name : {0}", LastName);
            System.Console.WriteLine("Bank No. : {0}", BankNo);
            System.Console.WriteLine("IsEmployed : {0}", IsEmployed? "True" : "False");
        }

    }
}
