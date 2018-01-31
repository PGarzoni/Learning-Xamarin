using System.Text;

namespace PhonewordApp
{
    public static class Translate
    {
        public static string ToNumber(string t)
        {
            if (string.IsNullOrEmpty(t))
                return "";
            else
                t = t.ToUpper();

            StringBuilder sb = new StringBuilder();
            foreach(char c in t)
            {
                switch (c)
                {
                    case ' ':
                    case '-':
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        sb.Append(c);
                        break;
                    default:
                        var ch = TranslateToNumber(c);
                        if(ch != null)
                            sb.Append(ch);
                        break;
                }
            }

            return sb.ToString();
        }

        private static char? TranslateToNumber(char c)
        {
            switch (c)
            {
                case 'A':
                case 'B':
                case 'C':
                    return '2';
                case 'D':
                case 'E':
                case 'F':
                    return '3';
                case 'G':
                case 'H':
                case 'I':
                    return '4';
                case 'J':
                case 'K':
                case 'L':
                    return '5';
                case 'M':
                case 'N':
                case 'O':
                    return '6';
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                    return '7';
                case 'T':
                case 'U':
                case 'V':
                    return '8';
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return '9';
                default:
                    return null;
            }
        }
    }
}