// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Test.Cryptography;
using Xunit;

namespace System.Security.Cryptography.Hashing.Algorithms.Tests
{
    public class HmacGost3411_2012_256Tests : HmacTests
    {
        private static readonly byte[][] s_testKeys =
        {
            null,
            ByteUtils.HexToByteArray("292608554026988F6F29F1F21F55520FB42C5705275721749E986E4469AFE6CE"),
            ByteUtils.HexToByteArray("579A2759D9FEE3C757AC072BD09E49816AFF631F85CC3B938879AE1E1EDF6CA7"),
            ByteUtils.HexToByteArray("832D54BF4EE0D3BEBFD9D400BB2A34C6BF17DE642C80962714398710732F6EDA"),
            ByteUtils.HexToByteArray("62682149CA5D093ECC0D9CA4B866CAFE79E27B49B678D6220F8DCF336DF073E9"),
            ByteUtils.HexToByteArray("852BCCFD5ECA1B21AC4CF4715115354DBDE13413476CB430604F6734D2CBF71D"),
            ByteUtils.HexToByteArray("B1929E8BCB8F353C9FEA467337AABF8014590CD437A2892962269617B83230E6"),
            ByteUtils.HexToByteArray("A6E521A0AC024F2444F7B8016C756695BAA81EC91DBF2DF79EE4EF58B0C6CDF1"),
        };

        private static readonly byte[][] s_testData =
        {
            null,
            ByteUtils.RepeatByte(0x00, 0),
            ByteUtils.HexToByteArray("B3B1E6464596201EF0D5A3100EB42357FAD1D20B07D23371EA38D5F2B29395B115472437CBF9742AF65C87940AC80001CDE7E27F92E44C9613"),
            ByteUtils.HexToByteArray("5677FA0E00D55710E2E0E16C65AB0CC1321DED118641B5C5A6F25714113F81EB5C28C9CBD656EAF34A20FACA64388A15FEB385D4212D0ED172DAB2F7EC5F2DF0"),
            ByteUtils.HexToByteArray("428C9EB4EB886A29A4C29020557C9E03FA7ABBB10A7B67595CC14DBB17A61838AD982EDFBB0E54DBA7426AA0B5F144A3989133D5D97A7F863417E8DF3F979BE8BCA356BA00C67A194893F2EEBD2954678EB29AA1F063F1"),
            ByteUtils.HexToByteArray("4A6144AB0FAC2CBC9D3D99E6758AB4D037D3A06D3070007AFF4F336240B3B6E172DA55324ACF6E7FF3393166B534D4D475A7ABC6BABFDDBBFBDDDAF4C0DCB5C4D8CA22B644E017D284436BD161D9AF4065437316560B47ABFB260D59697EF3D4031E39494791CA38A2F0ED38B37B21E635ED32288D3701760E1281ED9EE67A98CE71C0BB13CD1DB97F860ECFF72AC5072DF889F2CDABF2E8F461A1BB146775C785E23B58C855A6265C9DBB8C8729901D65BDDAE9D55263B4BDAD2F246CF6C4BC98A1EAE6506BCE01CCB0875B81CD17749F05F4717679474C13B7990831ECD152691B61E37F593B0383679259222FECF8073830AAB12788300D4D2C70272E12A0BF92F2C2EA4FBF5B237563C945ADD0160A0906ED78DC2B6D4934AE9D0BC5DAB4"),
            ByteUtils.HexToByteArray("92E2B05629E1A140DED8A482AE72E7AEFFA9A37CB117E8F549CF8CBC1940E2805D11D554A3043704157343FE71DF0150E445E1E045C21768E2"),
            ByteUtils.HexToByteArray("66C98B0029B4BC9180DB8AA25A1E9D7C85DDD240A08FBA759E49144586A823971143ACE0DDE5E0255A44EBB497D1FFF3C7354498FABE2BF89C33B749D9195030"),
        };

        public HmacGost3411_2012_256Tests()
            : base(s_testKeys, s_testData)
        {
        }

        protected override HMAC Create()
        {
            return new HMACGost3411_2012_256();
        }

        protected override HashAlgorithm CreateHashAlgorithm()
        {
            return Gost3411_2012_256.Create();
        }

        protected override int BlockSize { get { return 32; } }

        [Fact]
        public void HmacGost3411_2012_256_Byte_Constructors()
        {
            byte[] key = (byte[])s_testKeys[1].Clone();
            string digest = "FDAF889FFD2B99B5F90D230F9826B445FE7080DDF386A8AC99A12C08F8B45420";

            using (HMACGost3411_2012_256 h1 = new HMACGost3411_2012_256(key))
            {
                VerifyHmac_KeyAlreadySet(h1, 1, digest);
                using (HMACGost3411_2012_256 h2 = new HMACGost3411_2012_256(key))
                {
                    VerifyHmac_KeyAlreadySet(h2, 1, digest);
                    Assert.Equal(h1.Key, h2.Key);
                }
            }
        }

        [Fact]
        public void HmacGost3411_2012_256_1()
        {
            VerifyHmac(1, "FDAF889FFD2B99B5F90D230F9826B445FE7080DDF386A8AC99A12C08F8B45420");
        }

        [Fact]
        public void HmacGost3411_2012_256_2()
        {
            VerifyHmac(2, "04A8B3F3887C1EB183B99A3BC909E12830452CA9D3B4972DBDF173870B34F58F");
        }

        [Fact]
        public void HmacGost3411_2012_256_3()
        {
            VerifyHmac(3, "0705A5EC819DA86B7B31A653B099634F97FB769BB9FA493678F5E2931371700C");
        }

        [Fact]
        public void HmacGost3411_2012_256_4()
        {
            VerifyHmac(4, "5D55E345F4AFF03EE9134A4A5F7B7A27B8619DED80EB9A460B245B1FF04B4FB2");
        }

        [Fact]
        public void HmacGost3411_2012_256_5()
        {
            VerifyHmac(5, "8687DF19E837BA07E235B4403A82B0577565060C2A5A447E56DD874EE2B02CE4");
        }

        [Fact]
        public void HmacGost3411_2012_256_6()
        {
            VerifyHmac(6, "14FDA99BE76397CC9E1589043ACDB9F87D6C605CFCB3E1D34890E07EE0BFAA59");
        }

        [Fact]
        public void HmacGost3411_2012_256_7()
        {
            VerifyHmac(7, "FB1809BC0F9764E780C9827540186B6A9DA8618F1514128816A14342104BF6AA");
        }

        [Fact]
        public void HmacGost3411_2012_256_Rfc2104_2()
        {
            VerifyHmacRfc2104_2();
        }
    }
}
