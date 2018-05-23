using System;
using NumberToStringFramework;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    internal class ThausandsProcessNumberBusinessComponent : BaseProcessNumberBusinessComponent, IProcessNumberBusinessComponent
    {
        public ThausandsProcessNumberBusinessComponent(INumbersStringDataComponent numbersStringList, string number)
            : base(numbersStringList, number)
        {
        }

        public string ProcessGivenNumber()
        {
            var classifier = new ClassifyInputNumberBusinessComponent(base._number, NumberGroupTypeEnums.Thousands);

            base._number = classifier.ClassifyGivenNumber();

            return PopulateResult();
        }

        protected override string PopulateResult()
        {
            return string.Format("{0} thousand ", base.PopulateResult());
        }
    }
}
