using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using Android.Media;
using ByteSizeLib;
using Xamarin.Forms;

using MamaApp.Models;
using MamaApp.Services;
using Plugin.Connectivity;

namespace MamaApp.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> selectorExpression) {
            if (selectorExpression == null)
                throw new ArgumentNullException("selectorExpression");
            MemberExpression body = selectorExpression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("The body must be a member expression");
            OnPropertyChanged(body.Member.Name);
        }

        protected bool SetField<T>(ref T field, T value, Expression<Func<T>> selectorExpression) {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(selectorExpression);
            return true;
        }

        protected void RaiseAllPropertiesChanged() {
            // By convention, an empty string indicates all properties are invalid.
            PropertyChanged(this, new PropertyChangedEventArgs(string.Empty));
        }

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propExpr) {
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged(prop.Name);
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetPropertyValue<T>(ref T storageField, T newValue, Expression<Func<T>> propExpr) {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged(prop.Name);

            return true;
        }

        protected bool SetPropertyValue<T>(ref T storageField, T newValue, [CallerMemberName] string propertyName = "") {
            if (Equals(storageField, newValue))
                return false;

            storageField = newValue;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

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
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
