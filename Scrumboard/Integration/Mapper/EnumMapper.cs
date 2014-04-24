using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Scrumboard.Integration.Mapper
{
    public class EnumMapper
    {

        Dictionary<string, int?> mappings = new Dictionary<string, int?>();
        string filename;

        public EnumMapper(string filename)
        {
            this.filename = filename;
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            Stream src = Application.GetResourceStream(new Uri(string.Format("Scrumboard;component/Assets/Mappings/{0}",filename), UriKind.Relative)).Stream;
            StreamReader sr = new StreamReader(src);     
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                mappings.Add(values[0], Convert.ToInt32(values[1]));
            }
        }

        public int? GetMappedValue(string valuetomap)
        {
            int? outval = null;
            if (mappings.TryGetValue(valuetomap, out outval))
                return mappings[valuetomap];

            return outval;
        }
    }
}
