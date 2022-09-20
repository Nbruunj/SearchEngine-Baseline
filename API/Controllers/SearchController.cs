using ConsoleSearch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        Database mDatabase;
        Dictionary<string, int> mWords;
        public SearchController(Database database)
        {
            mDatabase = database;
            mWords = mDatabase.GetAllWords();
        }

        [HttpGet("[controller]/GetIdOf/{word}")]
        public ActionResult<int> GetIdOf(string word)
        {
            if (mWords.ContainsKey(word))
            {
                return mWords[word];
            }
            return -1;
        }

        [Route("[controller]/GetDocuments")]
        [HttpGet]
        public List<KeyValuePair<int, int>> GetDocuments([FromQuery] List<int> wordIds)
        {
            return mDatabase.GetDocuments(wordIds);
        }
        [Route("[controller]/GetDocumentDetails")]
        [HttpGet]
        public List<string> GetDocumentDetails([FromQuery] List<int> docIds)
        {
            return mDatabase.GetDocDetails(docIds);
        }
    }
}
