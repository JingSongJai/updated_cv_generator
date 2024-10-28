using iText.StyledXmlParser.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGenerateCVWPF.Data
{
    public class Languages
    {
        private string level; 

        public string Name { get; set; }
        public string Level
        {
            get { return level; }
            set
            {
                if (value == "Very Good") level = "▣▣▣▣";
                else if (value == "Good") level = "▣▣▣▢";
                else if (value == "Medium") level = "▣▣▢▢";
                else if (value == "Weak") level = "▣▢▢▢";
            }
        }

    }
}
