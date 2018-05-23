using System;
using NumberToStringFramework;

namespace NumberToStringBusinessComponent
{
    internal class ClassifyInputNumberBusinessComponent
    {
        decimal Number { get; set; }
        NumberGroupTypeEnums Type { get; set; }

        public ClassifyInputNumberBusinessComponent(string number, NumberGroupTypeEnums type)
        {
            Number = Convert.ToDecimal(number);
            Type = type;
        }

        public string ClassifyGivenNumber()
        {
            string decimalNum = string.Empty;

            for (int i = 0; i < (int)Type; i++)
            {
                var tempNumber = (Number / 1000).ToString();

                decimalNum = tempNumber.Split('.')[1];

                Number = int.Parse(tempNumber.Split('.')[0]);
            }

            //always return the numbers in group  of 3 
            if(decimalNum.Length < 3)
            {
                while(decimalNum.Length < 3)
                {
                    decimalNum = string.Format("{0}0", decimalNum);
                }
            }


            return decimalNum;
        }
    }
}
