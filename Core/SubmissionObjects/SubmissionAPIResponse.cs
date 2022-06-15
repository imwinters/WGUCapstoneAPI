
using Core.SubmissionObjects;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Core
{
    public class SubmissionAPIResponse
    {

        public Guid SubmissionID { get; set; }
        public ImageSubmission? SubmittedImage { get; set; }
        public bool IsDiseasePositive {get; set;}

        public SubmissionAPIResponse(ImageSubmission imageSubmission)
        {
            SubmissionID = Guid.NewGuid();
            SubmittedImage = imageSubmission;
            IsDiseasePositive = false;
        }
    }
}