using System;
using System.Text.RegularExpressions;
using KMACSharp04Hak.Exceptions;

namespace KMACSharp04Hak.Models
{
    [Serializable]
    internal class Person

    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;
        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _name;

            }

            private set
            {
                _name = value;

            }
        }

        public string Surname
        {
            get
            {
                return _surname;

            }

            private set
            {
                _surname = value;

            }
        }

        public string Email
        {
            get
            {
                return _email;

            }

            private set
            {
                _email = value;

            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;

            }

            private set
            {
                _birthDate = value;

            }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
        }

        public string SunSign
        {
            get { return _sunSign; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
        }

        public bool IsBirthday
        {
            get { return _isBirthday; }
        }

        #endregion

        #region Constructors

        internal Person(string name, string surname, string email, DateTime birthDate)
        {
            if (!IsNameSurnameValid(name))
                throw new InvalidNameException(name);
            _name = name;
            if (!IsNameSurnameValid(surname))
                throw new InvalidSurnameException(surname);
            _surname = surname;
            if (!IsEmailValid(email))
                throw new InvalidEmailException(email);
            _email = email;
            _birthDate = birthDate;
            _isBirthday = CheckBirthDay();
            _isAdult = CheckAdult();
            _sunSign = ComputeWesternZodiac();
            _chineseSign = ComputeChineseZodiac();
        }

        internal Person(string name, string surname, string email) : this(name, surname, email, DateTime.Today) { }

        internal Person(string name, string surname, DateTime birthDate) : this(name, surname, "", birthDate) { }

        #endregion

        private bool IsNameSurnameValid(string name)
        {
            //allows words with length >=2 separated by - or space
            // for example for double names as "Betty Grace" or surnames with prefixes as "De Bakker"
            return Regex.IsMatch(name, "[A-Za-z]{2,}((-| )[A-Za-z]{2,})*", RegexOptions.IgnoreCase);
        }

        private bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, "\\w+@(\\w+.)+[a-z]{2,4}", RegexOptions.IgnoreCase);
        }

        private bool CheckBirthDay()
        {
            return BirthDate.Month == DateTime.Today.Month && BirthDate.Day == DateTime.Today.Day;
        }

        private bool CheckAdult()
        {
            DateTime today = DateTime.Today;
            int res = today.Year - BirthDate.Year;
            if (BirthDate.Month > today.Month ||
                (BirthDate.Month == today.Month && BirthDate.Day > today.Day))
                --res;
            if (res < 0)
                throw new BirthDateInFutureException(BirthDate);
            if (res > 135)
                throw new BirthDateInLongPastException(BirthDate);
            return res >= 18;
        }

        private string ComputeWesternZodiac()
        {
            if ((BirthDate.Month == 1 && BirthDate.Day >= 21) ||
                (BirthDate.Month == 2 && BirthDate.Day <= 20))
            {
                return "Aquarius";
            }
            if ((BirthDate.Month == 2 && BirthDate.Day >= 21) ||
                (BirthDate.Month == 3 && BirthDate.Day <= 20))
            {
                return "Pisces";
            }
            if ((BirthDate.Month == 3 && BirthDate.Day >= 21) ||
                (BirthDate.Month == 4 && BirthDate.Day <= 20))
            {
                return "Aries";
            }

            if ((BirthDate.Month == 4 && BirthDate.Day >= 21) ||
                (BirthDate.Month == 5 && BirthDate.Day <= 20))
            {
                return "Taurus";
            }
            if ((BirthDate.Month == 5 && BirthDate.Day >= 21) ||
                (BirthDate.Month == 6 && BirthDate.Day <= 21))
            {
                return "Gemini";
            }
            if ((BirthDate.Month == 6 && BirthDate.Day >= 22) ||
                (BirthDate.Month == 7 && BirthDate.Day <= 22))
            {
                return "Cancer";
            }
            if ((BirthDate.Month == 7 && BirthDate.Day >= 23) ||
                (BirthDate.Month == 8 && BirthDate.Day <= 23))
            {
                return "Leo";
            }
            if ((BirthDate.Month == 8 && BirthDate.Day >= 24) ||
                (BirthDate.Month == 9 && BirthDate.Day <= 23))
            {
                return "Virgo";
            }
            if ((BirthDate.Month == 9 && BirthDate.Day >= 24) ||
                (BirthDate.Month == 10 && BirthDate.Day <= 22))
            {
                return "Libra";
            }
            if ((BirthDate.Month == 10 && BirthDate.Day >= 23) ||
                (BirthDate.Month == 11 && BirthDate.Day <= 22))
            {
                return "Scorpio";
            }
            if ((BirthDate.Month == 11 && BirthDate.Day >= 23) ||
                (BirthDate.Month == 12 && BirthDate.Day <= 21))
            {
                return "Sagittarius";
            }
            return "Capricorn";
        }

        //[Jan21 to Feb20] there's 31 days, so the middle is 16th day. It's 5 Feb. So assume each year starts at 5 Feb.
        private string ComputeChineseZodiac()
        {
            int year = BirthDate.Year;
            if (BirthDate.Month <= 2 && BirthDate.Day < 5)
                --year;
            return $"{ChineseElemental(year)} {ChineseAnimal(year)}";
        }

        private string ChineseElemental(int year)
        {
            switch (year % 10)
            {
                case 0:
                case 1:
                    return "Metal";
                case 2:
                case 3:
                    return "Water";
                case 4:
                case 5:
                    return "Wood";
                case 6:
                case 7:
                    return "Fire";
                case 8:
                    return "Earth";
                default:
                    return "Earth";
            }
        }

        private string ChineseAnimal(int year)
        {
            switch (year % 12)
            {
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                case 11:
                    return "Goat";
                default:
                    return "Monkey";
            }
        }

    }

}