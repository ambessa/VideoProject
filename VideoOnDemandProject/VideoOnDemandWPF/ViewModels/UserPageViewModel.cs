using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoOnDemandProjectDay1;
using VideosOnDemandEntityDatabase;

namespace VideoOnDemandWPF.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        UsernameRepository userRepo;

        private string _usernameSign;

        public string usernameSign
        {
            get { return _usernameSign; }
            set { _usernameSign = value; }
        }


        private string _usernameLog;

        public string usernameLog
        {
            get { return _usernameLog; }
            set { _usernameLog = value; }
        }

        private string _passwordSign;

        public string passwordSign
        {
            get { return _passwordSign; }
            set { _passwordSign = value; }
        }
        private string _passwordLog;

        public string passwordLog
        {
            get { return _passwordLog; }
            set { _passwordLog = value; }
        }

        private ICommand _checkUserNavigateToSearchCommand;

        public ICommand checkUserNavigateToSearchCommand
        {
            get { 
                    if(_checkUserNavigateToSearchCommand == null)
                    {
                        _checkUserNavigateToSearchCommand = new Command(checkUserNavigateToSearch, canCheckUserNavigateToSearch);
                    }
                    return _checkUserNavigateToSearchCommand;
            }
            set { _checkUserNavigateToSearchCommand = value; }
        }

        private ICommand _loginThenNavigateToSearchCommand;

        public ICommand loginThenNavigateToSearchCommand
        {
            get { 
                    if(_loginThenNavigateToSearchCommand == null)
                    {
                        _loginThenNavigateToSearchCommand = new Command(loginThenNavigateToSearch, canLoginThenNavigateToSearch);
                    }
                    return _loginThenNavigateToSearchCommand; 
            }
            set { _loginThenNavigateToSearchCommand = value; }
        }

        private bool canLoginThenNavigateToSearch()
        {
            return true;
        }

        private void loginThenNavigateToSearch()
        {
            var list = userRepo.GetUsernames().FindAll(a => a.name == usernameLog);
            if()
        }
        


        public UserPageViewModel()
        {
            userRepo = new UsernameRepository(new videosOnDemandEntities());
        }

        private void checkUserNavigateToSearch()
        {
            userRepo.AddUser(usernameSign, passwordSign);
            WindowViewModel windowPageModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowPageModel.page = "MediaManager.xaml";
        }

        private bool canCheckUserNavigateToSearch()
        {
            return true;
        }

        

        private void navigateToSearchPage()
        {

            WindowViewModel windowPageModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowPageModel.page = "MediaManager.xaml";
        }

        private bool canNavigateToSearchPage()
        {   
            return true;
        }
        

    }
}
