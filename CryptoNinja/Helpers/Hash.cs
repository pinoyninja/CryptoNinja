using System.Text;
using Org.BouncyCastle.Crypto.Digests;
using System.Security.Cryptography;

namespace CryptoNinja.Helpers
{
    /// <summary>
    /// Hash Helper
    /// </summary>
    class Hash
    {
        /// <summary>
        /// ComputeSha256 of string
        /// </summary>
        /// <param name="stringToHash">String to Hash</param>
        /// <returns>SHA256 Hash</returns>
        public static byte[] ComputeSha256(string stringToHash)
        {
            UTF8Encoding utf8 = new UTF8Encoding(false);
            return ComputeSha256(utf8.GetBytes(stringToHash));
        }

        /// <summary>
        /// Compute SHA256 of bytes
        /// </summary>
        /// <param name="bytesToHash"></param>
        /// <returns>SHA256 Hash</returns>
        public static byte[] ComputeSha256(byte[] bytesToHash)
        {
            Sha256Digest sha256 = new Sha256Digest();
            sha256.BlockUpdate(bytesToHash, 0, bytesToHash.Length);
            byte[] rv = new byte[32];
            sha256.DoFinal(rv, 0);
            return rv;
        }

        /// <summary>
        /// Get SHA256 Hashs
        /// </summary>
        /// <param name="stringToHash">String to Hash</param>
        /// <param name="hashdeep">Hash Deep</param>
        /// <returns>SHA256 Hash</returns>
        public static byte[] GetSha256Hash(string stringToHash, int hashdeep = 1)
        {
            string hash = stringToHash;
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashdeep - 1; i++)
            {
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(hash), 0, Encoding.UTF8.GetByteCount(hash));
                foreach (byte theByte in crypto)
                {
                    stringBuilder.Append(theByte.ToString("x2"));
                }
                hash = stringBuilder.ToString();
                stringBuilder.Clear();
            }

            return ComputeSha256(hash);
        }
    }
}
