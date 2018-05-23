using NumberToStringBusinessComponent;
using NumberToStringFramework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        private static void test()
        {
            var classsfier = new ClassifyInputNumberBusinessComponent(10,NumberGroupTypeEnums.Hundreds);
            var temp = classsfier.ClassifyGivenNumber();
            var processor = new HundredsProcessNumberBusinessComponent();
            processor.ProcessGivenGroup(temp);

            //classsfier = new ClassifyInputNumberBusinessComponent(1234567, NumberGroupTypeEnums.Thousands);
            //temp = classsfier.ClassifyGivenNumber();

            //classsfier = new ClassifyInputNumberBusinessComponent(1234567, NumberGroupTypeEnums.Millions);
            //temp = classsfier.ClassifyGivenNumber();

        }
    }
}
