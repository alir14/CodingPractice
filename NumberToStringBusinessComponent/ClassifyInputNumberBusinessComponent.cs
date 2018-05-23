using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToStringFramework;
using System.Collections.Generic;

namespace NumberToStringBusinessComponent
{
    public class ClassifyInputNumberBusinessComponent
    {
        decimal Number { get; set; }
        NumberGroupTypeEnums Type { get; set; }

        public ClassifyInputNumberBusinessComponent(int number, NumberGroupTypeEnums type)
        {
            Number = Convert.ToDecimal(number);
            Type = type;
        }

        public string ClassifyGivenNumber()
        {
            string decimalNum = string.Empty;

            if (Type == NumberGroupTypeEnums.Hundreds)
                return Number.ToString();

            for (int i = 0; i < (int)Type; i++)
            {
                var tempNumber = (Number / 1000).ToString();

                decimalNum = tempNumber.Split('.')[1];

                Number = int.Parse(tempNumber.Split('.')[0]);
            }

            return decimalNum;
        }
    }
}
