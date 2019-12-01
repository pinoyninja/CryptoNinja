using NUnit.Framework;
using System.Diagnostics;
using NBitcoin;

namespace CryptoNinja.Tests
{
    /// <summary>
    /// NBitcoin Library Tests
    /// </summary>
    [TestFixture]
    public class NBitcoinLibTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        /// <summary>
        /// Address from Key Tests
        /// </summary>
        /// <param name="seed">Brainwallet seed</param>
        /// <param name="expectedPubKey">Expected public key</param>
        /// <param name="expectedSecKey">Expected secret key</param>
        /// <param name="isTestNet">Is test network?</param>
        /// <param name="isCompressed">Is compressed?</param>
        [TestCase("Pinoy Ninja Main Network Uncompressed Key Tests",
                              "17qUpgKp1DqU7yhDW2Ri7HL56nNSnpH6ty",
                              "5K1kHcfPaL9f8KbSKUENfPHMrPw9B5QKTisZKYUTT53psGUzt88",
                              false,
                              false)]
        [TestCase("Pinoy Ninja Main Network Compressed Key Tests",
                              "1AabZgqBppJHwHp1KZGMo8Vfu8o2heZcHH",
                              "KyxF2URjiMo5nJkdCEsWXHodeiPdJaFkWe2GR3huwZ1GyVT7CXX5",
                              false,
                              true)]
        [TestCase("Pinoy Ninja Test Network Uncompressed Key Tests",
                              "n1MnQSzGUohqWcsa8CmYtYfg7PgQExErR1",
                              "9242M5VEtBwKHdFjuXeZiaotRPrSVMNfQe2tZUd3tG2vH9UDEmv",
                              true,
                              false)]
        [TestCase("Pinoy Ninja Test Network Compressed Key Tests",
            "mkCsRDNPuUCeRvT7vD2p23iQbhhvaDvz7m",
            "cQdX6Yxf36cMwAynMU1RRbdYKKStZJNji8u9PQaqnUxEz7ta3RmC",
            true,
            true)]
        public void AddressFromKeyTest(string seed,
                                              string expectedPubKey,
                                              string expectedSecKey,
                                              bool isTestNet,
                                              bool isCompressed)
        {
            string actualPubKey, actualSecKey;
            var network = isTestNet ? Network.TestNet : Network.Main;
            GetAddress(seed, out actualPubKey, out actualSecKey, network, isCompressed);
            Assert.AreEqual(expectedPubKey, actualPubKey);
            Assert.AreEqual(expectedSecKey, actualSecKey);
        }

        /// <summary>
        /// Get Address Simulation
        /// </summary>
        /// <param name="seed">Brainwallet seed</param>
        /// <param name="pubKey">Public key</param>
        /// <param name="secKey">Secret key</param>
        /// <param name="network">Network type</param>
        /// <param name="isCompressed">is compressed?</param>
        private static void GetAddress(string seed, out string pubKey, out string secKey, Network network, bool isCompressed)
        {
            var key = NBitcoinLib.FromBrainwalletSeed(seed, isCompressed);
            secKey = key.GetBitcoinSecret(network).ToString();
            pubKey = key.PubKey.GetAddress(ScriptPubKeyType.Legacy, network).ToString();
        }
    }
}
