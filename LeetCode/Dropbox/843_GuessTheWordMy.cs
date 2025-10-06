
using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class GuessTheWordMy : GuessTheWordBase
    {

        public void FindSecretWordFirst(string[] words, Master master)
        {
            var guesses = new HashSet<string>();

            for (int i = 0, matches = 0; i < 30 && matches != 6; i++) // 10 <= allowedGuesses <= 30
            {
                //string guess = words[0]; // get first word
                string guess = GetWord(guesses, words);
                guesses.Add(guess);

                matches = master.guess(guess);
                var newCandidates = new List<string>();
                foreach (var word in words)
                {
                    if (GetMatchCount(word, guess) == matches)
                    {
                        newCandidates.Add(word);
                    }
                }
                words = newCandidates.ToArray();
            }
        }

        private string GetWord(HashSet<string> guesses, string[] words)
        {
            foreach (var word in words)
            {
                if (!guesses.Contains(word))
                {
                    return word;
                }
            }
            return words[0];
        }


        public void FindSecretWordMy(string[] words, Master master)
        {
            int overral = 0;
            int matches = 0;
            // var s = master.secret;
            var guesss = new HashSet<string>();
            int type = 0;

            while (matches != 6)
            {
                // get max character  occurrence
                // build a word based on max character occurrence
                string guess = GetGuess(words, type);
                if (guesss.Contains(guess))
                {
                    type = 1 - type;
                    guess = GetGuess(words, type);
                }

                guesss.Add(guess);

                matches = master.guess(guess);
                var newCandidates = new List<string>();
                foreach (var word in words)
                {
                    if (GetMatchCount(word, guess) == matches)
                    {
                        newCandidates.Add(word);
                    }
                }
                words = newCandidates.ToArray();
                overral++;
            }
            Console.WriteLine(overral);
        }

        private string GetGuess(string[] words, int type)
        {
            Dictionary<char, int>[] dicts = new Dictionary<char, int>[6];
            for(int i=0; i < dicts.Length; i++)
            {
                dicts[i] = new Dictionary<char, int>();
            }

            foreach (var word in words)
            {
                for (int i = 0; i < 6; i++)
                {
                    int cnt = dicts[i].ContainsKey(word[i]) ? word[i] : 0;
                    dicts[i][word[i]] = cnt + 1;
                }
            }

            return type == 0 ? GetMaxGuess(dicts) : GetMixGuess(dicts);
        }

        private string GetMaxGuess(Dictionary<char, int>[] dicts)
        {
            string guess = "";
            foreach (var d in dicts)
            {
                char ch = ' ';
                int cnt = int.MinValue;
                foreach (var k in d.Keys)
                {
                    if (d[k] > cnt)
                    {
                        cnt = d[k];
                        ch = k;
                    }
                }
                guess = guess + ch;
            }

            return guess;
        }

        private string GetMixGuess(Dictionary<char, int>[] dicts)
        {
            string guess = "";
            foreach (var d in dicts)
            {
                char ch = ' ';
                int cnt = int.MaxValue;
                foreach (var k in d.Keys)
                {
                    if (d[k] < cnt)
                    {
                        cnt = d[k];
                        ch = k;
                    }
                }
                guess = guess + ch;
            }

            return guess;
        }


        [Test]
        public void TestGetGuess()
        {
            var words = new[] { "acckzz", "ccbazz", "eiowzz", "abcczz" };
            Console.WriteLine(GetGuess(words, 0));
        }

        [Test]
        public void TestFindSecretWordMy()
        {
            var words = new[] { "ccoyyo", "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master(words); // mock
            FindSecretWordMy(words, master);
        }

        [Test]
        public void TestFindSecretWordFirst()
        {
            var words = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master(words); // mock
            FindSecretWordFirst(words, master);
        }
    }
}
