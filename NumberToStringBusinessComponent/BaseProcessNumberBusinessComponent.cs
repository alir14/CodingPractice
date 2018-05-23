using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    internal class BaseProcessNumberBusinessComponent
    {
        protected string _number;
        INumbersStringDataComponent _numbersStringList;

        public BaseProcessNumberBusinessComponent(INumbersStringDataComponent numbersStringList, string number)
        {
            this._numbersStringList = numbersStringList;

            this._number = number;
        }

        protected virtual string ProcessHundreds()
        {
            string result = string.Empty;

            result = _numbersStringList.GetBaseNumbersString(Convert.ToInt32(_number.Substring(0, 1)));

            if (!string.IsNullOrEmpty(result))
                result = string.Format("{0} hundred", result);

            return result;
        }

        protected virtual string ProcessTens()
        {
            string result = string.Empty;

            if (Convert.ToInt32(_number.Substring(1, 1)) == 1)
            {
                result = _numbersStringList.GetTensNumbersString(Convert.ToInt32(_number.Substring(1, 2)));
            }
            else if (Convert.ToInt32(_number.Substring(1, 1)) > 1)
            {
                result = _numbersStringList.GetTensNumbersString(Convert.ToInt32(_number.Substring(1, 1)));
            }

            return result;
        }

        protected virtual string ProcessOnes()
        {
            string result = string.Empty;

            result = _numbersStringList.GetBaseNumbersString(Convert.ToInt32(_number.Substring(2, 1)));

            return result;
        }

        protected virtual string PopulateResult()
        {
            string result = string.Empty;

            result = string.Format("{0} {1} {2}", ProcessHundreds(), ProcessTens(), ProcessOnes()).Trim();

            return result;
        }
    }
}
