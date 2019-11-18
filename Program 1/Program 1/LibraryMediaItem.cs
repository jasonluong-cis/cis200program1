// Program 1
// CIS 200-01
// By: Z9467
// Due: 1/29/2018
// Program 1 is the creation of a hiearchy between classes and polymorphism

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_1
{
    public abstract class LibraryMediaItem : LibraryItem
    {
        public LibraryMediaItem(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod, string theCallNumber,
            double theDuration) : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Duration = theDuration;
        }

        public enum MediaType { DVD, BLURAY, CD, VHS, SACD, VINYL};

        private double _duration;
        public double Duration
        {
            // Precondition:  None
            // Postcondition: The duration is returned
            get
            {
                return _duration;
            }

            // Precondition:  Must be greater than 1
            // Postcondition: Duration is set to the value
            set
            {
                if (value >= 0)
                    _duration = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Duration)}", value,
                        $"{nameof(Duration)} must be >= 0");
            }
        }

        // Precondition:  None
        // Postcondition: Get or sets the medium
        public abstract MediaType Medium{ get; set;}

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period:{LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}{checkedOutBy}";
        }
    }
}
