using System;
using NumberToStringFramework;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    internal class MillionsProcessNumberBusinessComponent : BaseProcessNumberBusinessComponent, IProcessNumberBusinessComponent
    {
        public MillionsProcessNumberBusinessComponent(INumbersStringDataComponent numbersStringList, string number)
            : base(numbersStringList, number)
        {
        }

        public string ProcessGivenNumber()
        {
            var classifier = new ClassifyInputNumberBusinessComponent(base._number, NumberGroupTypeEnums.Millions);

            base._number = classifier.ClassifyGivenNumber();

            return PopulateResult();
        }

        protected override string PopulateResult()
        {
            return string.Format("{0} million ", base.PopulateResult());
        }


    }
}
