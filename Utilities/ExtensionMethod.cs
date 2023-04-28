using System.Security.Cryptography;
using System.Text;

namespace Utilities
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Check Null or White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Check not Null and White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotBlank(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && !string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Encrypt password
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encrypt(this string text)
        {
            var data = Encoding.UTF8.GetBytes(text);

            using (var md5 = MD5.Create())
            {
                var keys = md5.ComputeHash(Encoding.UTF8.GetBytes("tofu"));
                using (var tripDes = TripleDES.Create())
                {
                    tripDes.Key = keys;
                    tripDes.Mode = CipherMode.ECB;
                    tripDes.Padding = PaddingMode.PKCS7;

                    var transform = tripDes.CreateEncryptor();
                    var results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        /// <summary>
        /// Decrypt password
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns></returns>
        public static string Decrypt(this string cipher)
        {
            var data = Convert.FromBase64String(cipher);
            using (var md5 = MD5.Create())
            {
                var keys = md5.ComputeHash(Encoding.UTF8.GetBytes("tofu"));

                using (var tripDes = TripleDES.Create())
                {
                    tripDes.Key = keys;
                    tripDes.Mode = CipherMode.ECB;
                    tripDes.Padding = PaddingMode.PKCS7;

                    var transform = tripDes.CreateDecryptor();
                    var results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}