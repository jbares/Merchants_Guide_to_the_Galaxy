using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralConversion.Services;

namespace RomanNumeralConversion.Test
{
    [TestClass]
    public class ConverterTest
    {
        ConverterService converter = new ConverterService();

        //Test OutputMessage method
        [TestMethod]
        public void OutputMessage_Success_1()
        {
            string result = converter.OutputMessage("pish tegj glob glob");
            Assert.AreEqual("pish tegj glob glob is 42.00", result);
        }

        [TestMethod]
        public void OutputMessage_Success_2()
        {
            string result = converter.OutputMessage("glob prok Silver");
            Assert.AreEqual("glob prok Silver is 68.00 Credits", result);
        }

        [TestMethod]
        public void OutputMessage_Success_3()
        {
            string result = converter.OutputMessage("glob prok Gold");
            Assert.AreEqual("glob prok Gold is 57,800.00 Credits", result);
        }

        [TestMethod]
        public void OutputMessage_Success_4()
        {
            string result = converter.OutputMessage("glob prok Iron");
            Assert.AreEqual("glob prok Iron is 782.00 Credits", result);
        }

        [TestMethod]
        public void OutputMessage_Invalid_1()
        {
            string result = converter.OutputMessage("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            Assert.AreEqual("I have no idea what you are talking about", result);
        }

        [TestMethod]
        public void OutputMessage_Invalid_2()
        {
            string result = converter.OutputMessage("pish pish pish pish pish pish pish pish pish pish pish pish pish pish");
            Assert.AreEqual("I have no idea what you are talking about", result);
        }

        //Test ConvertRNToInt method
        [TestMethod]
        public void ConvertRNToInt_Success_1()
        {
            int result = converter.ConvertRNToInt("XIX");
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void ConvertRNToInt_Invalid_1()
        {
            int result = converter.ConvertRNToInt("test");
            Assert.AreEqual(0, result);
        }
    }
}
