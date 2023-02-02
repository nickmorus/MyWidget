using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWidget.Models
{
    public class SystemUptimeMonitor
    {
        public event Action<TimeSpan>? UptimeChanged;
        public void Start()
        {
            Task.Run(async () =>
            {
                TimeSpan uptime = GetUpTime();
                while (true)
                {
                    await Task.Delay(1000);
                    uptime = uptime.Add(TimeSpan.FromSeconds(1));
                    UptimeChanged?.Invoke(uptime);
                }
            });
        }

        private static TimeSpan GetUpTime()
        {
            using (var uptime = new PerformanceCounter("System", "System Up Time"))
            {
                uptime.NextValue();
                return TimeSpan.FromSeconds(uptime.NextValue());
            }
        }
    }
}
