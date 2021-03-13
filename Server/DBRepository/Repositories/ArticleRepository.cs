using System;
using System.Collections.Generic;
using System.Text;
using DBRepository.Interfaces;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBRepository.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
		public ArticleRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public Article GetArticle(int ArticleId)
		{
			var result = new Article();

			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				result = context.Articles.Where(Article => Article.ArticleId == ArticleId).ToList()[0];
				return result;
			}
		}
	}
}
