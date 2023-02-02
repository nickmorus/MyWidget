using MyWidget.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyWidget.ViewModels
{
    internal class MyWidgetViewModel : BindableBase
    {
        private SystemUptimeMonitor monitor = new();
        public MyWidgetViewModel()
        {
            monitor.Start();
            monitor.UptimeChanged += (uptime)=> SystemUpTime = uptime.ToString("hh\\:mm\\:ss");
        }

        private string systemUptime = "Loading...";
        public string SystemUpTime
        {
            set => SetProperty<string>(ref systemUptime, value); 
            get => systemUptime;
        }
    }
}
