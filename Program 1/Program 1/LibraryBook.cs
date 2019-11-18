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
    public class LibraryBook : LibraryItem
    {
        private string _author;     // The book's author

        public LibraryBook(string theTitle, string theAuthor, string thePublisher, int theCopyrightYear,
            int theLoanPeriod, string theCallNumber) : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber)
        {
            Author = theAuthor;
            ReturnToShelf();
        }


        public string Author
        {
            // Precondition:  None
            // Postcondition: The author has been returned
            get
            {
                return _author;
            }

            // Precondition:  None
            // Postcondition: The author has been set to the specified value
            set
            {
                // Since empty author is OK, just change null to empty string
                _author = (value == null ? string.Empty : value.Trim());
            }            
        }

        // Precondition:  None
        // Postcondition: Calculates the Fee that is owed
        public override decimal CalcLateFee(int DaysLate)
        {
            decimal BookLateFee = (Decimal)0.25;
            decimal Fee;
            Fee = DaysLate * BookLateFee;
            return Fee;
        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            return $"Title: {Title}{NL}Author: {Author}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period: {LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}{checkedOutBy}";
        }
    }
}
