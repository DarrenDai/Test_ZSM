using DDSoft.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ZSM.CMS.Presentation.Models;

namespace ZSM.CMS.Presentation
{
    public class ApplicationContext : NotifyPropertyChangedObject
    {
        #region Private fields

        private static ApplicationContext _applicationContext = new ApplicationContext();
        private Configuration _configuration = new Configuration();
        private ILog _logger = log4net.LogManager.GetLogger(typeof(ApplicationContext));
        private UserModel _currentUser = new UserModel() { UserName = "Debug User" };

        #endregion

        #region Constructor

        private ApplicationContext()
        {
        }

        #endregion

        #region Public Properties

        public static ApplicationContext Current
        {
            get
            {
                return _applicationContext;
            }
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public UserModel CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                //OnPropertyChanged(() => CurrentUser);
            }
        }

        public ILog Logger
        {
            get
            {
                return _logger;
            }
        }

        #endregion
    }

    public class Configuration
    {
        public bool IsDebugMode
        {
            get
            {
#if DEBUG
                return true;
#else
 return false;
#endif
            }
        }

        public string CompanyName
        {
            get
            {
                return "河南正视美科技有限公司";
            }
        }

        public string DBLocation
        {
            get
            {
                var localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var softPath = string.Format(@"{0}\DDSoft", localDataPath);

                if (!Directory.Exists(softPath))
                {
                    Directory.CreateDirectory(softPath);
                }

                var dbPath = string.Format(@"{0}\DataBase", softPath);
                if (!Directory.Exists(dbPath))
                {
                    Directory.CreateDirectory(dbPath);
                }

                return string.Format(@"{0}\dd", dbPath);
            }
        }
    }
}
