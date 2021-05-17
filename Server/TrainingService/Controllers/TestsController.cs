using Microsoft.AspNetCore.Mvc;
using TrainingService.DBRepository.Interfaces;
using TrainingService.DBRepository.Repositories;
using TrainingService.DBRepository;
using Microsoft.AspNetCore.Identity;
using TrainingService.Models;
using TrainingService.Models.RequestsModels;
using System.IO;
using Newtonsoft.Json;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class TestsController : Controller
    {
        
        ITestRepository _testRepository;
        private readonly UserManager<User> _userManager;
        public TestsController(UserManager<User> userManager, TrainingServiceContext dbcontext)
        {
            _userManager = userManager;
            _testRepository = new SQLTestsRepository(dbcontext);
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetTestsWithUserRating()
        {
            return new JsonResult(_testRepository.GetTestsWithUserRating(_userManager.GetUserId(User)));
        }
        [Route("{testId:int}")]
        [HttpGet]
        public JsonResult GetTestsWithUserRating(int testId)
        {
            return new JsonResult(_testRepository.GetTestWithQuestions(testId));
        }
        [Route("updaterating")]
        [HttpGet]
        public JsonResult UpdateRating(int testId, int newRating)
        {
            _testRepository.UpdateRating(_userManager.GetUserId(User), testId, newRating);
            return new JsonResult("success");
        }
    }
}
