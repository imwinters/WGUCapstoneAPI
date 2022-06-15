using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.SubmissionObjects
{
    public class ImageSubmission
    {
        public string ImageID { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateSubmitted { get; set; }
        public bool SuspectedPositive { get; set; }
    }
}
