using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class GuessTheWordByLetter : GuessTheWordBase
    {

        public void FindSecretWord(string[] words, Master master)
        {
            HashSet<char> misses = new HashSet<char>();
            HashSet<char> guessed = new HashSet<char>(); // in mask
            char[] mask = new char[] { ' ', ' ', ' ', ' ', ' ', ' ' };
            _words = words.ToList();
            int iterations = 0;
            FindSecretWord(master, misses, guessed, mask, iterations);
        }

        private List<string> _words = new List<string>();

        public void FindSecretWord(Master master, HashSet<char> misses, HashSet<char> guessed, char[] mask, int iterations)
        {
            iterations++;
            var words = GetWordsMatchingMask(_words, mask, misses);
            if (words.Count == 1)
            {
                Console.WriteLine("Mastre secret is " + master.secret);
                Console.WriteLine("Secret is " + words[0] + " number of guesses: " + iterations);
                return;
            }

            var secret = master.secret; // DEBUG

            var charToGuess = GetMostFrequientChar(words.ToArray(), mask, misses);
            if (charToGuess == ' ') // should never happen
            {
                Console.WriteLine(master.secret);
                Console.WriteLine(iterations);
                Console.WriteLine(string.Join("", mask));
                Console.WriteLine(string.Join(",", misses));
                return;
            }
            
            //var positions = master.IsSecretContainsChar(charToGuess);
            // var positions = master.IsSecretContainsCharSabotageLetter(charToGuess, words, mask, misses);
            var positions = master.IsSecretContainsCharSabotageWord(charToGuess, mask, misses);
            if (positions.Length == 0)
            {
                misses.Add(charToGuess);
            }
            else
            {
                guessed.Add(charToGuess);
                foreach (int p in positions) // update mask
                {
                    mask[p] = charToGuess;
                }
            }
            FindSecretWord(master, misses, guessed, mask, iterations);
        }

        private char GetMostFrequientChar(string[] words, char[] mask, HashSet<char> misses)
        {
            var dict = new Dictionary<char, int>(); // char : count
            foreach (var word in words)
            {
                for (int i=0; i < 6; i++)
                {
                    if (mask[i] == ' ' && !misses.Contains(word[i])) // no guessed position and not in misses
                    {
                        int cnt = dict.ContainsKey(word[i]) ? dict[word[i]] + 1 : 1;
                        dict[word[i]] = cnt;
                    }
                }
            }

            char charToGuess = ' ';
            int max = -1;

            foreach (var key in dict.Keys)
            {
                if (dict[key] > max)
                {
                    max = dict[key];
                    charToGuess = key;
                }
            }

            return charToGuess;
        }


        [Test]
        public void Test1()
        {
            var words = new[] { "acckzz", "ccbazz", "eiowzz", "abcczz" };
            var master = new Master(words); // mock
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test1_diff()
        {
            var words = new[] { "coldun", "cardel", "cordim", "wardof" };
            var master = new Master(words); // mock
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test2()
        {
            var words = new[] { "ccoyyo", "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            var master = new Master(words); // mock
            // var master = new Master("ktgmfn");
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test3()
        {
            var words = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi", "hsygda", "vyuica", "mbnagm", "uinqur", "pikenp", "szgupv", "qpxmsw", "vunxdn", "jahhfn", "kmbeok", "biywow", "yvgwho", "hwzodo", "loffxk", "xavzqd", "vwzpfe", "uairjw", "itufkt", "kaklud", "jjinfa", "kqbttl", "zocgux", "ucwjig", "meesxb", "uysfyc", "kdfvtw", "vizxrv", "rpbdjh", "wynohw", "lhqxvx", "kaadty", "dxxwut", "vjtskm", "yrdswc", "byzjxm", "jeomdc", "saevda", "himevi", "ydltnu", "wrrpoc", "khuopg", "ooxarg", "vcvfry", "thaawc", "bssybb", "ccoyyo", "ajcwbj", "arwfnl", "nafmtm", "xoaumd", "vbejda", "kaefne", "swcrkh", "reeyhj", "vmcwaf", "chxitv", "qkwjna", "vklpkp", "xfnayl", "ktgmfn", "xrmzzm", "fgtuki", "zcffuv", "srxuus", "pydgmq" };
            //var words = new[] { "wichbx", "oahwep", "tpulot", "eqznzs", "vvmplb", "eywinm", "dqefpt", "kmjmxr", "ihkovg", "trbzyb", "xqulhc", "bcsbfw", "rwzslk", "abpjhw", "mpubps", "viyzbc", "kodlta", "ckfzjh", "phuepp", "rokoro", "nxcwmo", "awvqlr", "uooeon", "hhfuzz", "sajxgr", "oxgaix", "fnugyu", "lkxwru", "mhtrvb", "xxonmg", "tqxlbr", "euxtzg", "tjwvad", "uslult", "rtjosi" };
            var master = new Master(words); // mock
            // var master = new Master("srxuus");            
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test2_diff()
        {
            var words = new[] { "qazwsx", "edcrfv", "tgbyhn", "ujmiko" };
            var master = new Master(words); // mock
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test3_similar()
        {
            var words = new[] { "qwerty", "qwertu", "qwerti", "qwerto" };
            var master = new Master(words); // mock
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }

        [Test]
        public void Test3_similar2()
        {
            var words = new[] { "qwerty", "qwertu", "qwerti", "qwerto", "qwertp", "qwerta", "qwerts", "qwertd", "qwertf", "qwertg", "qwerth", "qwertj", "qwertk", "qwertl" };
            var master = new Master(words); // mock
            Console.WriteLine("Master secret: " + master.secret);
            FindSecretWord(words, master);
        }
    }
}