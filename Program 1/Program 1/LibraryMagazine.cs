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
    public class LibraryMagazine : LibraryPeriodical
    {
        public LibraryMagazine(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
            string theCallNumber, int theVolume, int theNumber)
            : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theVolume, theNumber)
        {

        }

        decimal Fee; // Fee
        const decimal LateFee = (Decimal).25; // Late Fee
        const decimal MaxFee = 25; // Max Fee

        // Precondition:  None
        // Postcondition: Calculate the Fee
        public override decimal CalcLateFee(int DaysLate)
        {
            Fee = LateFee * DaysLate;
            if (Fee > MaxFee)
            {
                return MaxFee;
            }
            else
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

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period: {LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}" +
                $"Volume: {Volume}{NL} Number: {Number}{NL}{checkedOutBy}";
        }
    }
}
