using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Android.Media;
using ByteSizeLib;
using Xamarin.Forms;

using MamaApp.Models;
using MamaApp.Services;
using Plugin.Connectivity;

namespace MamaApp.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public bool HasNetworkAccess {
            get {
                return CrossConnectivity.Current.IsConnected;

            }
        }

        public string CurrentBandwidth {

            get {
                if (CrossConnectivity.Current.Bandwidths != null && CrossConnectivity.Current.Bandwidths.Any()) {
                    try {
                        var speed = CrossConnectivity.Current.Bandwidths.First().ToString();
                        var speedAsDouble = double.Parse(speed) / 8.0;
                        var speedAsLong = long.Parse(speedAsDouble.ToString());
                        var formattedSpeed = ByteSize.FromBits(speedAsLong).ToString(); // MB

                        return formattedSpeed;
                    } catch (Exception e) {
                        Debug.WriteLine(e);
                        return null;
                    }

                }

                return null;
            }
        }


        string title = string.Empty;
        public string Title {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null) {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
