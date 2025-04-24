using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_by_NikiZhu
{

    public class PluginConfigEntry
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }

    public class PluginConfig
    {
        public List<PluginConfigEntry> Plugins { get; set; } = new List<PluginConfigEntry>();
    }
}
