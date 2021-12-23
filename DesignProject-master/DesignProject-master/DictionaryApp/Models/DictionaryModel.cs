using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryApp.Models
{
    public class DictionaryModel
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public string WordUpper
        { get
            {
                return Word.ToUpper();
            }
                
        }
    }
}
