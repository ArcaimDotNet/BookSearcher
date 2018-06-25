namespace BookSearcher.Extensions
{
    public static class RegexExtensions
    {
        public static string Match(this string input, string start, string end)
        {
            int startTmp, endTmp;
            if (input.Contains(start) && input.Contains(end))
            {
                startTmp = input.IndexOf(start, 0) + start.Length;
                endTmp = input.IndexOf(end, startTmp);
                return input.Substring(startTmp, endTmp - startTmp);
            }
            else
            {
                return "";
            }
        }
    }
}