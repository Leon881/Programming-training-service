using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBRepository.Interfaces
{
    public interface IArticleRepository
    {
		//Task AddArticle(int ArticleId);
		Article GetArticle(int ArticleId);
		//Task DeleteArticle(int ArticleId);
	}
}
