using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TrainingService.Models;
using TrainingService.Models.ResponsesModels;
using TrainingService.DBRepository.Interfaces;
using System;

namespace TrainingService.DBRepository.Repositories
{
    public class SQLTestsRepository : ITestRepository
    {
        private TrainingServiceContext db;

        public SQLTestsRepository(TrainingServiceContext _db)
        {
            db = _db;
        }
        public List<TestResponse> GetTestsWithUserRating(string userId, string topicName)
        {
            int topicId = db.Topics.FirstOrDefault(topic => topic.Name == topicName).Id;
            List<TestResponse> result = db.Tests.Where(test => test.TopicId== topicId).Select(test => new TestResponse { Id = test.Id, Image = test.ImagePath, Title = test.Title, Rating = 0 }).ToList();
            if (result == null) return result;
            List<UserTest> usersTestsList = db.UsersTests.Where(userTest => userTest.UserId==userId).ToList();
            foreach (var usertest in usersTestsList)
            {
                var test = result.Find(testResp => testResp.Id == usertest.TestId);
                if (test == null) continue;
                else test.Rating = usertest.Rating;
            }
            return result;              
        }

        public TestWithQuestionsResponse GetTestWithQuestions(int testId)
        {
            string[] questionSeparator = { "&&&" };
            var questions = db.Questions.Where(question => question.TestId==testId)
                                        .Select(question => new QuestionResponse { 
                                            Id = question.Id, Question= question.QuestionText, 
                                            Type= Convert.ToInt32(question.Type), 
                                            Correct= question.Correct,
                                            Options = question.Options.Split(questionSeparator, System.StringSplitOptions.RemoveEmptyEntries).ToList()})
                                        .ToList();
            return new TestWithQuestionsResponse { Id = testId, Questions = questions };        
        }


        public void UpdateRating (string userId, int testId, int newRating)
        {
            var userTest = db.UsersTests.FirstOrDefault(userTest => userTest.UserId == userId && userTest.TestId == testId);
            if (userTest == null)
            {
                db.UsersTests.Add(new UserTest { UserId = userId, TestId = testId, Rating = newRating });
                Save();
                return;
            }
            userTest.Rating = newRating; 
            db.UsersTests.Update(userTest);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}




//context.UsersTests.Where(usertest => usertest.UserId == userId)
//                     .Join(context.Tests,
//                           usertest => usertest.TestId,
//                           test => test.Id,
//                           (usertest, test) => new TestResponse { Id = test.Id, Image = test.ImagePath, Title = test.Title, Rating = usertest.Rating })
//                     .ToList();
