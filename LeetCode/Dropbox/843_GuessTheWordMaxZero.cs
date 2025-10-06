

using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetCode.Dropbox
{
    public class GuessTheWordMaxZero : GuessTheWordBase
    {
        public void FindSecretWord(string[] words, Master master)
        {
            //Master.guess(word)
            // an integer representing the number of exact matches (value and position) of your guess to the secret word.
            // You may call Master.guess(word) where word is a six-letter-long string, and it must be from words. 

            // Because secret has exactly x matches with word, we can just search in the candidates, 
            // and only keep the ones that have exact x matches with word.
            int matches = 0;
            int iterations = 0;
            while (matches != 6)
            {
                //string guess = GetGuessMaxZero(words);
                //string guess = GetGuessMaxMax(words);
                string guess = GetGuessMaxChar(words);
                matches = master.guess(guess);
                var newCandidates = new List<string>();
                foreach (var word in words)
                {
                    if (GetMCount(guess, word) == matches)
                    {
                        newCandidates.Add(word);
                    }
                }
                words = newCandidates.ToArray();
                iterations++;
            }
            Console.WriteLine(iterations);
        }

        private string GetGuessMaxZero(string[] words)
        {
            string guess = "";
            int cnt = -1;
            // int cnt = 0;
            for (int i=0; i < words.Length; i++)
            {
                int k = 0;
                for (int j=0; j < words.Length; j++)
                {
                    if (GetMCount(words[i], words[j]) == 0)
                    {
                        k++;
                    }
                }
                if (k > cnt)
                {
                    cnt = k;
                    guess = words[i];
                }
            }

            /*
            if (guess == "")
            {
                guess = words[new Random().Next(words.Length)];
            }
            */

            return guess;
        }

        private string GetGuessMaxMax(string[] words)
        {
            string guess = "";
            int cnt = -1;

            for (int i=0; i < words.Length; i++)
            {
                //Dictionary<int, int> matches = new Dictionary<int, int>(); // 0,1,2,3,4,5,6 : cnt
                int[] dict = new int[7];
                for (int j=0; j < words.Length; j++)
                {
                    int m = GetMCount(words[i], words[j]);
                    //int v = matches.ContainsKey(m) ? matches[m] : 0;
                    //matches[m] = v;
                    dict[m]++;
                }

                int k = -1;
                foreach (var key in dict)
                {
                    if (key > k)
                    {
                        k = key;
                    }
                }
                /* foreach (var key in matches.Keys)
                {
                    if (matches[key] > k)
                    {
                        k = matches[key];
                    }
                } */

                if (k > cnt)
                {
                    guess = words[i];
                    cnt = k;
                }
            }

            return guess;
        }

        private string GetGuessMaxChar(string[] words)
        {
            int[,] count = new int[6,26];
            
            foreach (var word in words)
            {
                for (int i = 0; i < 6; i++)
                {
                    count[i, (int)word[i] - (int)'a']++;
                }
            }

            string guess = "";
            int best = -1;

            foreach (var word in words)
            {
                int score = 0;
                for (int i = 0; i < 6; ++i)
                    score += count[i, (int)word[i] - (int)'a'];

                if (score > best)
                {
                    guess = word;
                    best = score;
                }
            }

            return guess;
        }

        private int GetMCount(string word1, string word2)
        {
            int cnt = 0;
            for (int i=0; i <6; i++)
            {
                if (word1[i] == word2[i])
                {
                    cnt++;
                }
            }
            return cnt;
        }

        [Test]
        public void Test1()
        {
            var words = new[] { "ccoyyo", "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master(words); // mock
            FindSecretWord(words, master);
        }

        [Test]
        public void Test2()
        {
            var words = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master(words); // mock
            FindSecretWord(words, master);
        }

        [Test]
        public void Test3()
        {
            var words = new[] { "xxxxxa", "xxxxxb", "xxxxxc", "xxxxxd"};
            var master = new Master(words); // mock
            FindSecretWord(words, master);
        }

        [Test]
        public void Test4()
        {
            var words = new[] { "pzrooh", "aaakrw", "vgvkxb", "ilaumf", "snzsrz", "qymapx", "hhjgwz", "mymxyu", "jglmrs", "yycsvl", "fuyzco", "ivfyfx", "hzlhqt", "ansstc", "ujkfnr", "jrekmp", "himbkv", "tjztqw", "jmcapu", "gwwwmd", "ffpond", "ytzssw", "afyjnp", "ttrfzi", "xkwmsz", "oavtsf", "krwjwb", "bkgjcs", "vsigmc", "qhpxxt", "apzrtt", "posjnv", "zlatkz", "zynlqc", "czajmi", "smmbhm", "rvlxav", "wkytta", "dzkfer", "urajfh", "lsroct", "gihvuu", "qtnlhu", "ucjgio", "xyycvd", "fsssoo", "kdtmux", "bxnppe", "usucra", "hvsmau", "gstvvg", "ypueay", "qdlvod", "djfbgs", "mcufib", "prohkc", "dsqgms", "eoasya", "kzplbv", "rcuevr", "iwapqf", "ucqdac", "anqomr", "msztnf", "tppefv", "mplbgz", "xnskvo", "euhxrh", "xrqxzw", "wraxvn", "zjhlou", "xwdvvl", "dkbiys", "zbtnuv", "gxrhjh", "ctrczk", "iwylwn", "wefuhr", "enlcrg", "eimtep", "xzvntq", "zvygyf", "tbzmzk", "xjptby", "uxyacb", "mbalze", "bjosah", "ckojzr", "ihboso", "ogxylw", "cfnatk", "zijwnl", "eczmmc", "uazfyo", "apywnl", "jiraqa", "yjksyd", "mrpczo", "qqmhnb", "xxvsbx" };
            // var master = new Master(words); // mock
            var master = new Master("anqomr"); // 14 > 11
            FindSecretWord(words, master);
        }

        [Test]
        public void Test5()
        {
            var words = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            // var master = new Master(words); // mock
            var master = new Master("ccoyyo"); // 11 > 10
            FindSecretWord(words, master);
        }
    }
}
