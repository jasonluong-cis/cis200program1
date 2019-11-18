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
    public class LibraryJournal : LibraryPeriodical
    {
        private string _discipline; // The Discipline
        private string _editor; // The editor

        public LibraryJournal(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
            string theCallNumber, int theVolume, int theNumber, string theDiscipline,
            string theEditor) : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber,theVolume, theNumber)
        {
            Discipline = theDiscipline;
            Editor = theEditor;
        }

        public string Discipline
        {
            // Precondition:  None
            // Postcondition: Returns the Discipline
            get
            {
                return _discipline;
            }

            // Precondition:  Must be Filled in
            // Postcondition: Set the discipline to the value
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Discipline)}", value,
                        $"{nameof(Discipline)} must not be null or empty");
                else
                    _discipline = value.Trim();
            }
        }
        public string Editor
        {
            // Precondition:  None
            // Postcondition: Returns the Editor
            get
            {
                return _editor;
            }

            // Precondition:  Must be filled
            // Postcondition: Set the editor to the value
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Editor)}", value,
                        $"{nameof(Editor)} must not be null or empty");
                else
                    _editor = value.Trim();
            }
        }
        decimal Fee; // Fee
        decimal LateFee = (Decimal).75; // Fee cost

        // Precondition:  None
        // Postcondition: Calculate the cost of fee
        public override decimal CalcLateFee(int DaysLate)
        {
            Fee = LateFee * DaysLate;
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

            return $"Title: {Title}{NL}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period: {LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}" +
                $"Volume: {Volume}{NL}Number: {Number}{NL}" +
                $"Discipline: {Discipline}{NL}" +
                $"Editor: {Editor}{NL} {checkedOutBy}";
        }
    }
}
