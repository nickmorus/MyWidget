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
        private const int updateDelay = 1;
        public void Start()
        {
            Task.Run(async () =>
            {
                TimeSpan uptime = GetUpTime();
                while (true)
                {
                    TimeSpan span = TimeSpan.FromSeconds(updateDelay);
                    await Task.Delay(span);
                    uptime = uptime.Add(span);
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
