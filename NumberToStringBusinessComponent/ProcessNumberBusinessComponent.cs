using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NumberToStringFramework.Interface;

namespace NumberToStringBusinessComponent
{
    public class ProcessNumberBusinessComponent
    {
        IProcessNumberBusinessComponent _processNumberComponent;

        public ProcessNumberBusinessComponent(IProcessNumberBusinessComponent processNumberComponent)
        {
            _processNumberComponent = processNumberComponent;
        }

        public void ProcessNumber()
        {
            // classify the number

            // process the group number

            // populatethe result()
        }

        
    }
}
