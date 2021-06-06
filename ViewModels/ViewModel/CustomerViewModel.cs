using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        public CustomerViewModel()
        {
            DOB = DateTime.Now;
            Coins = new ObservableCollection<Coin>();

            Coins.Add(new Coin("Coin 1"));
            Coins.Add(new Coin("Coin 2"));
            Coins.Add(new Coin("Coin 3"));
            Coins.Add(new Coin("Coin 4"));
            Coins.Add(new Coin("Coin 5"));

            FirstName = "A name here";
            Title = "Customer View Model";
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(); }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }

        private DateTime? dob;

        public DateTime? DOB
        {
            get { return dob; }
            set { dob = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Coin> coins;

        public ObservableCollection<Coin> Coins
        {
            get { return coins; }
            set { coins = value; OnPropertyChanged(); }
        }
    }

    public class Coin
    {
        public string Symbol { get; set; }
        public string Color2 { get; set; }
        public double PriceChangeInPercentDailyDisplay { get; set; }

        public Coin(string symbol)
        {
            this.Symbol = symbol;
            this.Color2 = "Transparent";
            PriceChangeInPercentDailyDisplay = 0.03;
        }
    }
}
