using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoOnDemandProjectDay1;
using VideoOnDemandWPF.ViewModels;

namespace VideoOnDemandWPF.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        private ObservableCollection<FilmRepository> _films;

        public ObservableCollection<FilmRepository> films
        {
            get { return _films; }
            set { _films = value; }
        }

        public SearchPageViewModel()
        {
            films = new ObservableCollection<FilmRepository>();
            
        }
    }
}
