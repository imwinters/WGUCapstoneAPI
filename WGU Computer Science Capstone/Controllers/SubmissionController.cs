
using Core.SubmissionObjects;
using CovidRecognitionModel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using static CovidRecognitionModel.XRayModel;

namespace WGU_Computer_Science_Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ILogger<SubmissionController> _logger;
        public SubmissionController(ILogger<SubmissionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitImageForProcessing(ImageSubmission imageSubmission)
        {
            try
            {
                const string targetUri = "https://isaacwinterscapstoneui.azurewebsites.net";

                // Go get the image from the site
                Stream? content = null;

                var client = new HttpClient();
                var response = await client.GetAsync(targetUri + imageSubmission.ImagePath);
                if (response.IsSuccessStatusCode)
                {
                    content = response.Content.ReadAsStream();
                        
                }



                var fileName = Path.GetTempFileName();

                ModelOutput? result = null;

                using (var fileStream = System.IO.File.Create(fileName))
                {
                    content.Seek(0, SeekOrigin.Begin);
                    content.CopyTo(fileStream);

                    fileStream.Close();

                    ModelInput modelInput = new XRayModel.ModelInput()
                    {
                        ImageSource = fileName,
                        Label = imageSubmission.SuspectedPositive ? "Positive" : "Negative"
                    };

                    result = Predict(modelInput);

                }


                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("/metrics")]
        public IActionResult GetAccuracyMetrics()
        {
            AccuracyDTO accuracy = new AccuracyDTO()
            {
                FileCount = 30482,
                Accuracy = 96.83,
                Positive = 2158,
                Negative = 28324
            };

            return Ok(accuracy);
        }

    }
}
