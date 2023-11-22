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

                Match match = Regex.Match(logLine, pattern);
                string expression = match.Groups[1].Value;
                _Result = ExpressionCalculator.Calculate(expression, " ").ToString();
            }
            else if (logLine.Contains("Guess word"))
            {
                foreach (KeyValuePair<string, string> pair in Quiz.VertebralHeights)
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
