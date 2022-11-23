using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TypeValues
{
    public class ReturnResults
    {
        public List<Result> Results = new();

        public bool IsOk()
        {
            return !Results.Any(x => x.Type == ResultType.Fail);
        }

        public void AddNew(Result result)
        {
            Results.Add(result);
        }

    }

    public class Result
    {
        public string Message { get; set; }
        public ResultType Type { get; set; }

        public Result(ResultType type, string message)
        {
            Message = message;
            Type = type;
        }   
    }

    public enum ResultType
    {
        Ok,
        Information,
        Warning,
        Fail
    }
}
