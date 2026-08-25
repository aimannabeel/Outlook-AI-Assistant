using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookAddIn1
{
    public class EmailGenerationRequest
    {
        public string Instructions { get; set; }
        public string Length { get; set; }

        public string Tone { get; set; }
    }
}
