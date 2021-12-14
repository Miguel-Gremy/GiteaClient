using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace GiteaClient.Core.ViewModels.About
{
    public class ShowLogViewModel : MvxViewModel
    {
        #region Attribute
        protected ILogger<ShowLogViewModel> _logger { get; set; }

        private ObservableCollection<string> _logs = new();
        #endregion
        #region Accessor
        public ObservableCollection<string> Logs
        {
            get { return _logs; }
            set => SetProperty(ref _logs, value);
        }
        #endregion
        #region Constructor
        public ShowLogViewModel(ILogger<ShowLogViewModel> logger)
        {
            _logger = logger;
        }
        #endregion
        #region Command
        #endregion
        #region Method
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            try
            {
                // Create copy of the log files to temp folder
                var fileEntries = Directory.GetFiles("log/");
                var timeNow = DateTime.Now.ToFileTime();
                var tempFolderName = Path.GetTempPath() + @$"TempGiteaClient-{timeNow}\";
                Directory.CreateDirectory(tempFolderName + @"log\");
                foreach (var item in fileEntries)
                {
                    File.Copy(item, tempFolderName + item);
                }
                fileEntries = Directory.GetFiles(tempFolderName + @"log\");

                // Adn read temp folder's log files
                foreach (var item in fileEntries)
                {
                    try
                    {
                        foreach (var log in File.ReadAllText(item).Split(Environment.NewLine + Environment.NewLine))
                        {
                            Logs.Add(log);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }
        }
        #endregion
    }
}
