using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Strings
{
    class _929_UniqueEmailAddresses
    {
        public int NumUniqueEmails(string[] emails)
        {
            if (emails == null) return 0;

            var list = new List<string>();
            foreach (var email in emails)
            {
                list.Add(CleanEmail(email));
            }

            return list.Distinct().Count();
        }

        private string CleanEmail(string email)
        {
            var sb = new StringBuilder();

            bool ignore = false;
            bool meet = false;
            foreach (var ch in email)
            {
                if (ch == '.' && !meet) continue;
                if (ch == '+') ignore = true;
                if (ch == '@') { ignore = false; meet = true; }

                if (!ignore) sb.Append(ch);
            }

            return sb.ToString();
        }
    }
}
