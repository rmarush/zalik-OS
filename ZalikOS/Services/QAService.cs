using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZalikOS.Models;

namespace ZalikOS.Services
{
    public class QAService
    {
        private static List<QuestionAnswerPair> _data = JsonService.LoadData<List<QuestionAnswerPair>>("QAData.json");
        
        public static string FindAnswer(string pattern)
        {
            var result = _data.Find(x => x.Question == pattern);
            return result.Answer;
        }
    }
}
