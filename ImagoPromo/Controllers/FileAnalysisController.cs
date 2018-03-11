using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ImagoPromo.Managers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ImagoPromo.Controllers
{
    [Route("api/[controller]")]
    public class FileAnalysisController : Controller
    {
        private readonly IFileProcessingManager _fileProcessingManager;
        public FileAnalysisController(IFileProcessingManager fileProcessingManager)
        {
            _fileProcessingManager = fileProcessingManager;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var mappings = _fileProcessingManager.ProcessPath(Directory.GetCurrentDirectory());
            return JsonConvert.SerializeObject(mappings);
        }

        // GET api/values/5
        [HttpGet("{directory}")]
        public string Get(string directory)
        {
            var mappings = _fileProcessingManager.ProcessPath(directory);
            return JsonConvert.SerializeObject(mappings);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
