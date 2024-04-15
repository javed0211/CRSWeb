using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace CRSWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TowersController : ControllerBase
    {
        // Fetch main directories (towers)
        [HttpGet]
        public IActionResult GetTowers()
        {
            var directoryPath = @"C:\Execution Data\AzurePipeline";
            return Ok(GetDirectories(directoryPath));
        }

        // Fetch subdirectories (projects) for a specific tower
        [HttpGet("{towerName}")]
        public IActionResult GetProjects(string towerName)
        {
            var directoryPath = Path.Combine(@"C:\Execution Data\AzurePipeline", towerName);
            return Ok(GetDirectories(directoryPath));
        }

        // Fetch sub-subdirectories (further subfolders) for a specific project
        [HttpGet("{towerName}/{projectName}")]
        public IActionResult GetSubFolders(string towerName, string projectName)
        {
            var directoryPath = Path.Combine(@"C:\Execution Data\AzurePipeline", towerName, projectName);
            if (!Directory.Exists(directoryPath))
            {
                return NotFound("Directory not found");
            }

            return Ok(GetDirectories(directoryPath));
        }

        private List<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path).Select(Path.GetFileName).ToList();
        }
    }
}
