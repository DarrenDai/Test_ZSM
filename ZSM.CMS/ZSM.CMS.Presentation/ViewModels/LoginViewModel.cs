using DDSoft.Common;
using DDSoft.Framework;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using ZSM.CMS.Presentation.Views;

namespace ZSM.CMS.Presentation.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IUnityContainer container, IRegionManager regionManage, IEventAggregator eventAggregator, Login view)
            : base(view)
        {
            Container = container;
            RegionManager = regionManage;
            EventAggregator = eventAggregator;
        }

        public string UserName { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public override void InitializeCommands()
        {
            base.InitializeCommands();
            LoginCommand = new DelegateCommand<object>(new Action<object>(Login));
        }

        private void Login(object payload)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                Logger.Warn(string.Format("Login attemp failed for user {0}", UserName));
                MessageBox.Show("用户名或者密码不能为空！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (AccessDbHelper helper = new AccessDbHelper())
            {
                object passObject = null;
                try
                {
                    passObject = helper.ExecuteScalar(string.Format("SELECT [PASSWORD] FROM [USER] WHERE USERNAME='{0}'", UserName));

                }
                catch (Exception)
                {
                    Logger.Warn(string.Format("Login attemp failed for user {0}", UserName));
                    //Noting to do
                    //Password can't be got.
                }

                if (passObject != null && passObject.ToString() == Password)
                {
                    Logger.Info(string.Format("User {0} login.", UserName));
                    AppContext.CurrentUser.UserName = UserName;
                    //AppContext.CurrentUser = new Entity.UserEntity() { UserName = UserName };
                    OnBack("");
                }
                else
                {
                    Logger.Warn(string.Format("Login attemp failed for user {0}", UserName));
                    MessageBox.Show("用户名或者密码不正确！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //int count = (int)helper.ExecuteScalar(string.Format("select count(*) from [user] where username='{0}' and password='{1}'", UserName, Password));

                //if (count > 0)
                //{
                //    OnBack("");
                //}
                //else
                //{
                //    Logger.Warn(string.Format("Login attemp failed for user {0}", UserName));
                //    MessageBox.Show("用户名或者密码不正确！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
            }
        }
    }
}
