namespace LeetCode.Dropbox
{
    public class GuessTheWordRandom : GuessTheWordBase
    {
        public void FindSecretWord(string[] words, Master master)
        {
            Random rnd = new Random();
            // int month = rnd.Next(1, 13);  // creates a number between 1 and 12
            for (int i = 0, matches = 0; i < 30 && matches != 6; i++) // 10 <= allowedGuesses <= 30
            {
                string guess = words[rnd.Next(words.Length)]; // get a word randomly
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


    }
}
