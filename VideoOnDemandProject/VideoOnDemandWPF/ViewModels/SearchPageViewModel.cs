using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoOnDemandProjectDay1;
using VideoOnDemandWPF.ViewModels;
using VideosOnDemandEntityDatabase;


namespace VideoOnDemandWPF.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        FilmRepository filmRepo;
        TelevisionRepository tvRepo;

        private string _searchFilm;
        public string searchFilm
        {
            get { return _searchFilm; }
            set {
                    _searchFilm = value;
                    OnPropertyChanged("searchFilm");
                }
        }

        private string _searchTV;
        public string searchTV
        {
            get { return _searchTV; }
            set
            {
                _searchTV = value;
                OnPropertyChanged("searchTV");
            }
        }

        private ObservableCollection<film> _films;
        public ObservableCollection<film> films
        {
            get { return _films; }
            set 
            { 
                _films = value;
                OnPropertyChanged("films");
            }
        }

        private ObservableCollection<television> _tvShow;
        public ObservableCollection<television> tvShow
        {
            get { return _tvShow; }
            set
            {
                _tvShow = value;
                OnPropertyChanged("tvShow");
            }
        }

        private ICommand _searchFilmButtonCommand;
        public ICommand searchFilmButtonCommand
        {
            get {   if(_searchFilmButtonCommand == null)
                    {
                        _searchFilmButtonCommand = new Command(SearchFilm, canSearchFilmButton);
                    }
                    return _searchFilmButtonCommand; 
            }
            set { _searchFilmButtonCommand = value; }
        }


        private ICommand _searchTVButtonCommand;
        public ICommand searchTVButtonCommand
        {
            get
            {
                if (_searchTVButtonCommand == null)
                {
                    _searchTVButtonCommand = new Command(SearchTV, canSearchTVButton);
                }
                return _searchTVButtonCommand;
            }
            set { _searchTVButtonCommand = value; }
        }

        private bool canSearchTVButton()
        {
            return true;
        }

        private bool canSearchFilmButton()
        {
            return true;
        }     
        

        public SearchPageViewModel()
        {
            filmRepo = new FilmRepository(new videosOnDemandEntities());
            tvRepo = new TelevisionRepository(new videosOnDemandEntities());
        }

        public void SearchFilm()
        {
            List<film> foundFilms = filmRepo.GetAllFilms().FindAll(f => f.name == searchFilm);
            films = new ObservableCollection<film>(foundFilms);


        }

        private void SearchTV()
        {
            List<television> foundTvShows = tvRepo.GetAllTelevisionShows().FindAll(t => t.name == searchTV);
            tvShow = new ObservableCollection<television>(foundTvShows);
        }
    }
}
