namespace ConsoleApp25.Models;

public static class StringExtensions
{
    public static bool IsValidEmail(this string email)
    {
        if (email.Contains("@") && email[0] != '@' && email[email.Length - 1] != '@')
            return true;
        return false;
    }
    public static string ToTitleCase(string s)
    {
        return s.ToLower();
    }
    public static bool IsNullOrEmpty(string s)
    {
        if (s == null || s.Length == 0)
            return true;
        else
            return false;
    }
}



