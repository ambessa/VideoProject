using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoOnDemandWPF.ViewModels
{
    public class UserPageViewModel : BaseViewModel
    {
        private ICommand _navigateToSearchPageCommand;

        public ICommand navigateToSearchPageCommand
        {
            get { 
                    if(_navigateToSearchPageCommand == null)
                    {
                        _navigateToSearchPageCommand = new Command(navigateToSearchPage, canNavigateToSearchPage);
                    }
                    return _navigateToSearchPageCommand;
            }
            set { _navigateToSearchPageCommand = value; }
        }

        private void navigateToSearchPage()
        {
            WindowViewModel windowPageModel = App.Current.MainWindow.DataContext as WindowViewModel;
            windowPageModel.page = "SearchPage.xaml";
        }

        private bool canNavigateToSearchPage()
        {   
            return true;
        }
        

    }
}
