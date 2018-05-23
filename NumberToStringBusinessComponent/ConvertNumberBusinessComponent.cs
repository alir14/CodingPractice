using System;
using System.Text;
using NumberToStringFramework.Interface;
using NumberToStringBusinessComponent.Factory;

namespace NumberToStringBusinessComponent
{
    public class ConvertNumberBusinessComponent
    {
        string _number;
        ProcessNumberFactoryManager processNumberFactoryManager;

        public ConvertNumberBusinessComponent(string number, INumbersStringDataComponent numbersStringDataComponent)
        {
            processNumberFactoryManager = new ProcessNumberFactoryManager(number, numbersStringDataComponent);

            this._number = number;
        }

        public string ConvertNumber()
        {
            var result = string.Empty;

            if(ValidateNumber())
            {
                int counter = 0;

                decimal value = decimal.Parse(this._number);

                do
                {
                    counter++;

                    value = (value / 1000);

                } while (value > 1);

                for (int i = counter; i > 0 ; i--)
                {
                    IProcessNumberBusinessComponent process = processNumberFactoryManager.CreateInstance(i);

                    result += process.ProcessGivenNumber();
                }
            }

            return result;
        }

        private bool ValidateNumber()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(this._number) && int.TryParse(this._number, out int value))
            {
                result = true;
            }

            return result;
        }
        
    }
}
