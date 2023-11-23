using LogsReader.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogsReader
{
    public class ChatGameHandler : IHandler
    {
        private string? _Result { get; set; }
        public ChatGameHandler()
        {
            _Result = string.Empty;

        }

        public string Handle(string logLine, string pattern)
        {
            if (logLine.Contains("Guess expression"))
            {
                string expression;
                try {
                    Match match = Regex.Match(logLine, pattern);
                     expression = match.Groups[1].Value;
                    _Result = ExpressionCalculator.Calculate(expression, " ").ToString();
                }
                catch(FormatException ex) {
                    _Result = string.Empty;
                    /* throw new Exception("expression not found", ex);*/ }
                
            }
            else if (logLine.Contains("Guess word"))
            {
                foreach (KeyValuePair<string, string> pair in Quiz.QuizList)
                {
                    if (logLine.Contains(pair.Key))
                    {
                        _Result = pair.Value;
                    }
                }
            }
            return _Result;
        }


    }
}
