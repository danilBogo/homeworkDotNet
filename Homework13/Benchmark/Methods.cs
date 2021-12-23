namespace Benchmark
{
    public class Methods
    {
        public void Common(string str)
        {
            for (var i = 0; i < 1; i++)
                str += str;
        }

        public virtual void Virtual(string str)
        {
            for (var i = 0; i < 1; i++)
                str += str;
        }

        public static void Static(string str)
        {
            for (var i = 0; i < 1; i++)
                str += str;
        }

        public void Generic<T>(T str)
        {
            var currentString = str?.ToString();
            for (var i = 0; i < 1; i++)
                currentString += str;
        }

        public void Dynamic(dynamic str)
        {
            for (var i = 0; i < 1; i++)
                str += str;
        }

        public void Reflection(string str)
        {
            for (var i = 0; i < 1; i++)
                str += str;
        }
    }
}