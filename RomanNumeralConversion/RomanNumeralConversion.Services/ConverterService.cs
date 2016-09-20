using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNumeralConversion.Services
{
    public class ConverterService
    {        
        public string OutputMessage(string input)
        {            
            Regex rgx = new Regex("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            Dictionary<string, string> translation = new Dictionary<string, string>();
            translation.Add("I", "glob");
            translation.Add("V", "prok");
            translation.Add("X", "pish");
            translation.Add("L", "tegj");
            Dictionary<string, double> material = new Dictionary<string, double>();
            material.Add("silver", 17);
            material.Add("gold", 14450);
            material.Add("iron", 195.5);

            string outputMessage = input;
            input = input.ToLower();            
            double materialValue = 1;

            foreach (KeyValuePair<string, string> entry in translation)
            {
                input = input.Replace(entry.Value, entry.Key);
            }
            foreach (KeyValuePair<string, double> entry in material)
            {
                if (input.Contains(entry.Key))
                {
                    materialValue = entry.Value;
                    input = input.Replace(entry.Key, "");
                    break;
                }
            }

            input = Regex.Replace(input, @"\s+", "");

            if (!rgx.IsMatch(input) || string.IsNullOrEmpty(input))
            {
                return "I have no idea what you are talking about";                
            }            

            int outputValue = ConvertRNToInt(input);
            if (materialValue > 1)
            {
                double credits = outputValue * materialValue;
                return outputMessage + " is " + credits.ToString("n2") + " Credits";
            }
            else
            {
                return outputMessage + " is " + outputValue.ToString("n2");
            }
        }

        public int ConvertRNToInt(string input)
        {
            char[] array = input.ToCharArray();
            List<char> charList = new List<char>(array);
            List<int> intList = new List<int>();

            foreach (char x in charList)
            {
                switch (x.ToString())
                {
                    case "I":
                        intList.Add(1);
                        break;
                    case "V":
                        intList.Add(5);
                        break;
                    case "X":
                        intList.Add(10);
                        break;
                    case "L":
                        intList.Add(50);
                        break;
                    case "C":
                        intList.Add(100);
                        break;
                    case "D":
                        intList.Add(500);
                        break;
                    case "M":
                        intList.Add(1000);
                        break;
                }
            }

            int result = 0;

            for (int i = 0; i < intList.Count; i++)
            {
                if ((i != intList.Count - 1) && intList.Count >= 1)
                {
                    if (intList[i] < intList[i + 1])
                    {
                        result -= intList[i];
                    }
                    else
                    {
                        result += intList[i];
                    }
                }
                else
                {
                    result += intList[i];
                }
            }

            return result;
        }
    }
}
