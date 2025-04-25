namespace CRM {
    public class Customer {
        public int Id{get;set;}
        public string Name{get;set;}
        public string ContactNumber{get;set;}
        public string Email{get;set;}
        public string Location{get;set;}
        public int Age{get;set;}

        public Customer(){}
        public Customer(string Name,string Email,string ContactNumber,string Location,int Age){
            this.Name = Name;
            this.Email = Email;
            this.ContactNumber = ContactNumber;
            this.Location = Location;
            this.Age = Age;
        }
        public Customer(int id, string Name,string Email,string ContactNumber,string Location,int Age){
            this.Id = id;
            this.Name = Name;
            this.Email = Email;
            this.ContactNumber = ContactNumber;
            this.Location = Location;
            this.Age = Age;
        }
        public Customer(int id, string Name,string Email,string ContactNumber){
            this.Id = id;
            this.Name = Name;
            this.Email = Email;
            this.ContactNumber = ContactNumber;
        }
    }
}