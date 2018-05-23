using NumberToStringDataComponent;
using NumberToStringFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToStringBusinessComponent
{
    public class HundredsProcessNumberBusinessComponent : IProcessNumberBusinessComponent
    {
        public string Hundreds { get; set; }
        public string Tens { get; set; }
        public string Ones { get; set; }

        public string ProcessGivenGroup(string givenGroup)
        {
            var numbersStringList = new NumbersStringDataComponent();

            Hundreds = numbersStringList.GetBaseNumbersString(Convert.ToInt32(givenGroup.Substring(0,1)));

            if(Convert.ToInt32(givenGroup.Substring(1, 1)) > 1)
            {
                Tens = numbersStringList.GetTensNumbersString(Convert.ToInt32(givenGroup.Substring(1, 1)));
                Ones = numbersStringList.GetBaseNumbersString(Convert.ToInt32(givenGroup.Substring(2, 1)));
            }
            else
            {
                Tens = numbersStringList.GetTensNumbersString(Convert.ToInt32(givenGroup.Substring(1, 2)));
            }

            return string.Format("{0} hundred {1} {2}", Hundreds,Tens,Ones).Trim();
        }
    }
}
