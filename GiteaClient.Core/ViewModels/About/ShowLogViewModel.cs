using GiteaClient.Core.Assets;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
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
        public static string CopyToTempLogFile()
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
            return tempFolderName + @"log\";
        }
        public ICollection<string> GetLogAsStringList(string folder)
        {
            // Read temp folder's log files
            var fileEntries = Directory.GetFiles(folder);
            var logs = new Collection<string>();
            foreach (var item in fileEntries)
            {
                try
                {
                    foreach (var log in File.ReadAllText(item).Split(Environment.NewLine + Environment.NewLine))
                    {
                        logs.Add(log);
                    }
                    logs.Remove(string.Empty);
                }
                catch (Exception e)
                {
                    _logger.LogWarning(e.Message);
                }
            }

            return logs;
        }
        #endregion
        #region Override_Method
        public override void Prepare()
        {
            base.Prepare();
            try
            {
                Logs = GlobalFunc.ListToReversedObservable(GetLogAsStringList(CopyToTempLogFile()));
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }
        }
        #endregion
    }
}
