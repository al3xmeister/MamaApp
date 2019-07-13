using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MamaApp.Models;
using MamaApp.Utility;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Linq;

namespace MamaApp.ViewModels
{
    public class ȘtiriPageViewModel : BaseViewModel
    {
        public ICommand AppearingCommand { get; set; }

        public ȘtiriPageViewModel()
        {
           
        }

        private ObservableCollection<Models.article> articles = new ObservableCollection<Models.article>();
        public ObservableCollection<Models.article> Articles {
            get {
                return articles;
            }
            set {
                if (articles != value)
                {
                    articles = value;
                    OnPropertyChanged(nameof(Articles));

                }
            }
        }
        
     
        public class Grouping<K, T> : ObservableCollection<T>
        {

            public K Key { get; set; }

            public Grouping(K key, IEnumerable<T> items)
            {
                Key = key;

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
        }

    }
}
