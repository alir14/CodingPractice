using NumberToStringFramework;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    internal class HundredProcessNumberBusinessComponent : BaseProcessNumberBusinessComponent, IProcessNumberBusinessComponent
    {
        public HundredProcessNumberBusinessComponent(INumbersStringDataComponent numbersStringList, string number)
            :base(numbersStringList, number)
        {
        }

        public string ProcessGivenNumber()
        {
            var classifier = new ClassifyInputNumberBusinessComponent(base._number, NumberGroupTypeEnums.Hundreds);

            base._number = classifier.ClassifyGivenNumber();

            return base.PopulateResult();
        }
        
    }
}
