#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using GiteaClient.Core.Assets;
using Microsoft.Extensions.Logging;
using MvvmCross.ViewModels;

#endregion

namespace GiteaClient.Core.ViewModels.About
{
    public class ShowLogViewModel : MvxViewModel
    {
        #region Constructor

        public ShowLogViewModel(ILogger<ShowLogViewModel> logger)
        {
            Logger = logger;
        }

        #endregion

        #region Accessor

        public ObservableCollection<string> Logs
        {
            get => _logs;
            private set => SetProperty(ref _logs, value);
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
                Logger.LogWarning(e, "An error occured : {e.Message}", e.Message);
            }
        }

        #endregion

        #region Attribute

        private ILogger<ShowLogViewModel> Logger { get; set; }

        private ObservableCollection<string> _logs = new();

        #endregion

        #region Command

        #endregion

        #region Method

        private static string CopyToTempLogFile()
        {
            // Create copy of the log files to temp folder
            var fileEntries = Directory.GetFiles("log/");
            var timeNow = DateTime.Now.ToFileTime();
            var tempFolderName = Path.GetTempPath() + @$"TempGiteaClient-{timeNow}\";
            Directory.CreateDirectory(tempFolderName + @"log\");
            foreach (var item in fileEntries) File.Copy(item, tempFolderName + item);
            return tempFolderName + @"log\";
        }

        private IEnumerable<string> GetLogAsStringList(string folder)
        {
            // Read temp folder's log files
            var fileEntries = Directory.GetFiles(folder);
            var logs = new Collection<string>();
            foreach (var item in fileEntries)
                try
                {
                    foreach (var log in File.ReadAllText(item)
                        .Split("End of log"))
                        logs.Add(log);
                    logs.Remove(string.Empty);
                }
                catch (Exception e)
                {
                    Logger.LogWarning(e, "An error occured : {e.Message}", e.Message);
                }

            return logs;
        }

        #endregion
    }
}