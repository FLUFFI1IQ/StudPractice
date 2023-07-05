using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using StudPractice.Models;
using StudPractice.Repositories;
using System.Data.SqlClient;

namespace StudPractice.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        public void LoadCurrentUserData()
        {
            UserRepository userRepository = new UserRepository();
            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null)
            {
                var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

                if (user != null)
                {
                    CurrentUserAccount.Username = user.Username;
                    CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.Surname} {user.Email}";
                    CurrentUserAccount.ProfilePicture = null;
                }
                else
                {
                    CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                }
            }
            
        }

        
    }
}
