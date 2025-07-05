using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Velera_Skriner.Model;

namespace Velera_Skriner.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CryptoPair> Pairs { get; set; } = new();

        private readonly BinanceService _binanceService = new();

        public async Task LoadDataAsync()
        {
            var data = await _binanceService.GetCryptoPairsAsync();

            Pairs.Clear();
            foreach (var pair in data)
                Pairs.Add(pair);
        }

        // INotifyPropertyChanged реалізація:
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
