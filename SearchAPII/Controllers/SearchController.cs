using ConsoleSearch;
using Microsoft.AspNetCore.Mvc;

namespace SearchAPII.Controllers
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

        [HttpGet("{id}")]
        public int ActionResult<GetIdOf>(string word)
        {
            if (mWords.ContainsKey(word))
                return mWords[word];
            return -1;
        }
        [HttpGet("{Keyvaluepair}")]
        public ActionResult<List<KeyValuePair<int, int>>> GetDocuments(List<int> wordIds)
        {
            return mDatabase.GetDocuments(wordIds);
        }
        [HttpGet("{getdocumentdetails}")]
        public ActionResult<List<string>> GetDocumentDetails(List<int> docIds)
        {
            return mDatabase.GetDocDetails(docIds);
        }
    }
}
