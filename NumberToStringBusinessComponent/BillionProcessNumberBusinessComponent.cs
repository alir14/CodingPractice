﻿using System;
using NumberToStringFramework;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    internal class BillionProcessNumberBusinessComponent : BaseProcessNumberBusinessComponent, IProcessNumberBusinessComponent
    {
        public BillionProcessNumberBusinessComponent(INumbersStringDataComponent numbersStringList, string number)
            :base(numbersStringList, number)
        {
        }

        public string ProcessGivenNumber()
        {
            var classifier = new ClassifyInputNumberBusinessComponent(base._number, NumberGroupTypeEnums.Billions);

            base._number = classifier.ClassifyGivenNumber();

            return PopulateResult();
        }

        protected override string PopulateResult()
        {
            return string.Format("{0} billion ", base.PopulateResult());
        }
    }
}
