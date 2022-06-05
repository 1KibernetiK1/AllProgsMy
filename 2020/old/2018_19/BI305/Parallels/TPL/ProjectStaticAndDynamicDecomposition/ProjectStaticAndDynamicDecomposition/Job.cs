using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStaticAndDynamicDecomposition
{
    public class Job
    {
        private int _duration;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="duration">длительность</param>
        public Job(int duration)
        {
            _duration = duration;
        }

        public void Do()
        {
            Thread.Sleep(_duration);
        }
    }
}
