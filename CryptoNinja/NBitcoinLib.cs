using System;
using NBitcoin;

namespace CryptoNinja
{
    using Helpers;

    /// <summary>
    /// NBitcoin Library
    /// </summary>
    public class NBitcoinLib
    {
        public static Key FromBrainwalletSeed(string seed, bool isCompressedKey = false, int sha256 = 1)
        {
            if (sha256 < 1)
                throw new InvalidOperationException();
            byte[] data = sha256 == 1 ? Hash.ComputeSha256(seed) : Hash.GetSha256Hash(seed, sha256);

            return new Key(data, fCompressedIn: isCompressedKey);
        }
    }
}
