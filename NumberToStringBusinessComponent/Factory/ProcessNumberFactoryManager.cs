using System;
using NumberToStringFramework;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent.Factory
{
    internal class ProcessNumberFactoryManager
    {
        string _number;
        INumbersStringDataComponent _numbersStringDataComponent;

        public ProcessNumberFactoryManager(string number, INumbersStringDataComponent numbersStringDataComponent)
        {
            this._number = number;
            this._numbersStringDataComponent = numbersStringDataComponent;
        }

        public IProcessNumberBusinessComponent CreateInstance(int type)
        {
            switch(type)
            {
                case (int)NumberGroupTypeEnums.Hundreds:
                    return new HundredProcessNumberBusinessComponent(this._numbersStringDataComponent, this._number);
                case (int)NumberGroupTypeEnums.Thousands:
                    return new ThausandsProcessNumberBusinessComponent(this._numbersStringDataComponent, this._number);
                case (int)NumberGroupTypeEnums.Millions:
                    return new MillionsProcessNumberBusinessComponent(this._numbersStringDataComponent, this._number);
                //case NumberGroupTypeEnums.Billions:
                //    return new BillionsProcessNumberBusinessComponent(this._numbersStringDataComponent, this._number);
                default:
                    return null;
            }   
        }
    }
}
