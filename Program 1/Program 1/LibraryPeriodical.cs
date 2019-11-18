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
    public abstract class LibraryPeriodical : LibraryItem
    {
        private int _volume; // The volume number
        private int _number; // The Number

        public LibraryPeriodical(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
            string theCallNumber, int theVolume, int theNumber) : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Volume = theVolume;
            Number = theNumber;
        }

        public int Volume
        {
            // Precondition:  None
            // Postcondition: Returns the volume
            get
            {
                return _volume;
            }

            // Precondition:  Must be greater than 0
            // Postcondition: Sets the volume to the value
            set
            {
                if (value >= 0)
                    _volume = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Volume)}", value,
                        $"{nameof(Volume)} must be >= 0");
            }
        }

        public int Number
        {
            // Precondition:  None
            // Postcondition: Returns the number
            get
            {
                return _number;
            }

            // Precondition:  Must be greater than 0
            // Postcondition: Sets the number to value
            set
            {
                if (value >= 0)
                    _number = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Number)}", value,
                        $"{nameof(Number)} must be >= 0");
            }

        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period: {LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}" +
                $"Volume: {Volume}{NL}" +
                $"Number: {Number}{NL} {checkedOutBy}";
        }
    }
}
