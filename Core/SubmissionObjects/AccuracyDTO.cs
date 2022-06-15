using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SubmissionObjects
{
    public class AccuracyDTO
    {
        public int FileCount { get; set; }
        public double Accuracy { get; set; }
        public int Negative { get; set; }
        public int Positive { get; set; }
    }
}
