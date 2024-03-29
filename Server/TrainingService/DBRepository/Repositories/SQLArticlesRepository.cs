﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TrainingService.Models;
using TrainingService.Models.ResponsesModels;
using TrainingService.DBRepository.Interfaces;

namespace TrainingService.DBRepository.Repositories
{
    public class SQLArticlesRepository : IArticleRepository
    {
		private TrainingServiceContext db;
		public SQLArticlesRepository (TrainingServiceContext _db)
		{
			db = _db;
		}

		public Article GetArticle (int articleId)
		{

			var result = db.Articles.FirstOrDefault(article => article.Id==articleId);
			return result;
		}

		public List<ArticleResponse> GetArticlesList()
		{
           return db.Articles.Select(article => article)
                         .Join(db.Users,
                                 article => article.UserId,
                                 user => user.Id,
                                 (article, user) => new ArticleResponse { 
									 Id = article.Id, 
									 Image = article.ImagePath, 
									 Title = article.Title, 
									 Description = article.Description, 
									 Date=article.Date,
									 Author=user.Email })
                                 .ToList();
        }

		public void AddArticle(Article newArticle)
		{
			db.Articles.Add(newArticle);
			db.SaveChanges();
		}

	}
}
