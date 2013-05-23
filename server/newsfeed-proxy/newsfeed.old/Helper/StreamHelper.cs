using System.IO;

namespace newsfeed.Helper
{
    public class StreamHelper
    {
        /// <summary>
        /// Copies the stream - avoiding long memery leaks on the server
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[short.MaxValue]; // 32768
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }
    }
}