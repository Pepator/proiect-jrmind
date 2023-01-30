using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problema_3
{
    public class Match : IMatch
    {
        private bool succes;
        private string text;

        public Match(bool succes, string text)
        {
            this.succes = succes;
            this.text = text;
        }
        
        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return succes;
        }
    }
}
