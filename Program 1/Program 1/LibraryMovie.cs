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
    class LibraryMovie : LibraryMediaItem
    {
        private string _director; // The movie's director
        private MediaType _medium; // The movie's medium

        public LibraryMovie(string theTitle, string thePublisher, int theCopyrightYear, int theLoanPeriod,
            string theCallNumber, double theDuration, string theDirector, MediaType theMedium, MPAARating theRating)
            : base(theTitle, thePublisher, theCopyrightYear, theLoanPeriod, theCallNumber, theDuration)
        {
            Director = theDirector;
            Medium = theMedium;
            Rating = theRating;
        }
        // Precondition:  None
        // Postcondition: Range of ratings
        public enum MPAARating { G, PG, PG13, R, NC17, U }

        // Precondition:  None
        // Postcondition: Sets the Rating
        public MPAARating Rating
        {
            get;
            set;
        }

        public string Director
        {
            // Precondition:  None
            // Postcondition: Returns the director 
            get
            {
                return _director;
            }

            // Precondition:  Must be filled in
            // Postcondition: Sets Director to the value
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Director)}", value,
                        $"{nameof(Director)} must not be null or empty");
                else
                    _director = value.Trim();
            }
        }

        public override MediaType Medium
        {
            get
            {
                return _medium;
            }
            set
            {
                if (_medium < MediaType.SACD)
                {
                    _medium = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Medium)}", value,
                            $"{nameof(Medium)} must be a BLURAY, CD, DVD");
                }
            }
        }

        decimal DVDVHSLate = (Decimal)1.0;
        decimal BLURAYLate = (Decimal)1.5;
        decimal Fee;
        decimal MaxFee = 25;

        // Precondition:  None
        // Postcondition: Calculates the Fee that is due
        public override decimal CalcLateFee(int DaysLate)
        {
            if (Medium == MediaType.VHS || Medium == MediaType.CD)
            {
                Fee = DaysLate * DVDVHSLate;
                if (Fee > MaxFee)
                {
                    return MaxFee;
                }
                else
                    return Fee;
            }
            else
                if (Medium == MediaType.BLURAY)
            {
                Fee = DaysLate * BLURAYLate;
                if (Fee > MaxFee)
                {
                    return MaxFee;
                }
                else
                    return Fee;
            }
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
                $"Duration: {Duration}{NL}" +
                $"Director: {Director}{NL}" +
                $"Medium: {Medium}{NL}" +
                $"Rating: {Rating}{NL}{checkedOutBy}";
        }
    }
}
