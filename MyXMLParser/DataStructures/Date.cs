﻿namespace MyXMLParser.DataStructures
{
    [Serializable]
    public struct Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return Day + "/" + Month + "/" + Year;
        }
    }
}