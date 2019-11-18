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
    class LibraryMusic : LibraryMediaItem
    {
        private string _artist; // The song's artist
        private int _numtracks; // The number of tracks
        private MediaType _medium; // The medium that the music is stored on

        public LibraryMusic(string theTitle, string thePublisher, int theCopyRightYear, int theLoanPeriod, string theCallNumber,
            double theDuration, string theArtist, MediaType theMedium, int theNumTracks) : base(theTitle, thePublisher, theCopyRightYear,
                theLoanPeriod, theCallNumber, theDuration)
        {
            Artist = theArtist;
            Medium = theMedium;
            NumTracks = theNumTracks;
        }
        public string Artist
        {
            // Precondition:  None
            // Postcondition: Returns the artist
            get
            {
                return _artist;
            }

            // Precondition:  Must be filled in
            // Postcondition: Set the artist to the value
            set
            {
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Artist)}", value,
                        $"{nameof(Artist)} must not be null or empty");
                else
                    _artist = value.Trim();
            }
        }
        public int NumTracks
        {
            // Precondition:  None
            // Postcondition: Returns the number of tracks
            get
            {
                return _numtracks;
            }

            // Precondition:  Must be greater than 0
            // Postcondition: Sets the number of tracks to the value
            set
            {
                if (value >= 0)
                    _numtracks = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(NumTracks)}", value,
                        $"{nameof(NumTracks)} must be >= 0");
            }

        }
        public override MediaType Medium
        {
            // Precondition:  None
            // Postcondition: Returns the value
            get
            {
                return _medium;
            }
            // Precondition: Must be SACD, VHS, VINYL
            // Postcondition: Sets the medium to SACD, VHS, VINYL
            set
            {
                if (_medium >= MediaType.SACD)
                {
                    _medium = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Medium)}", value,
                        $"{nameof(Medium)} must be a SACD, VHS, VINYL");
                }
                    
            }
        }
        decimal LateFee = (Decimal).5;
        decimal Fee;
        decimal MaxFee = 25;
        // Precondition:  None
        // Postcondition: Calculates the Late fee due
        public override decimal CalcLateFee(int DaysLate)
        {
            Fee = DaysLate * LateFee;
            if (Fee > MaxFee)
            {
                return MaxFee;
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

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Loan Period: {LoanPeriod}{NL}" +
                $"Call Number: {CallNumber}{NL}" +
                $"Duration: {Duration}{NL}" +
                $"Artist: {Artist}{NL} Medium: {Medium}{NL}" +
                $"Number of Tracks: {NumTracks}{NL}{checkedOutBy}";
        }
    }
}

