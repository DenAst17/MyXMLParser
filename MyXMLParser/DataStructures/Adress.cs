namespace MyXMLParser.DataStructures
{
    public struct Adress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Flour { get; set; }
        public int FlatNumber { get; set; }

        public Date DateIn { get; set; }
        public Date DateOut { get; set; }

        public Adress(string city, string street, string houseNumber, string flour, int flatNumber, Date dateIn, Date dateOut)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            Flour = flour;
            FlatNumber = flatNumber;
            DateIn = dateIn;
            DateOut = dateOut;
        }

        public override string ToString()
        {
            return City + " " + Street + " " + HouseNumber + " " + Flour + " " + FlatNumber + " " + DateIn + "\n" + DateOut + "\n";
        }
    }
}