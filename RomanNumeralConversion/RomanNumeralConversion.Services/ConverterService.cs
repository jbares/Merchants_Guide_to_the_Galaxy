using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Converter.Services
{
    public class ConverterService
    {        
        public string OutputMessage(string input)
        {
            //Regex to test a valid roman numeral string     
            Regex rgx = new Regex("^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            //Dictionary for alien language to roman numeral conversion  
            Dictionary<string, string> translation = new Dictionary<string, string>();
            translation.Add("I", "glob");
            translation.Add("V", "prok");
            translation.Add("X", "pish");
            translation.Add("L", "tegj");
            //Dictionary for material single unit to value conversion
            Dictionary<string, double> material = new Dictionary<string, double>();
            material.Add("silver", 17);
            material.Add("gold", 14450);
            material.Add("iron", 195.5);

            string outputMessage = input;
            input = input.ToLower();
            //Set to 1 so if no material is added we havea flag, this needs to change is a material is added with the value of 1            
            double materialValue = 1;

            //Convert input to roman numeral 
            foreach (KeyValuePair<string, string> entry in translation)
            {
                input = input.Replace(entry.Value, entry.Key);
            }
            //Flag material value and remove from string
            foreach (KeyValuePair<string, double> entry in material)
            {
                if (input.Contains(entry.Key))
                {
                    materialValue = entry.Value;
                    input = input.Replace(entry.Key, "");
                    break;
                }
            }

            //Remove any spaces before roman numeral conversion
            input = Regex.Replace(input, @"\s+", "");

            //Check if anythis is inputted and if the input is valid
            if (!rgx.IsMatch(input) || string.IsNullOrEmpty(input))
            {
                return "I have no idea what you are talking about";                
            }            

            int outputValue = ConvertRNToInt(input);

            //Depending on material either return a a whole number for a language conversion (e.g. pish tegj glob glob is 42) or a credit value if a material is present (e.g. glob prok Silver is 68 Credits) 
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
            //Split input strng into an array of each character
            char[] array = input.ToCharArray();
            List<char> charList = new List<char>(array);
            List<int> intList = new List<int>();

            //Loop over each character converting the romen numeral value to integer value
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
                //Check if the current index is at the end of the list and that the list has more then 0 indexs
                if ((i != intList.Count - 1) && intList.Count >= 1)
                {
                    //If the value of the current index value in the list is greater then then next input value in the list then remove the current index value from the total
                    if (intList[i] < intList[i + 1])
                    {
                        result -= intList[i];
                    }
                    //otherwise add the value to the current total
                    else
                    {
                        result += intList[i];
                    }
                }
                else
                {  
                    //The last value in the list always gets added to the total
                    result += intList[i];
                }
            }

            return result;
        }
    }
}
