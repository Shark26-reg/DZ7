using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ7
{
    public class ExampleClass
    {
        [CustomName("CustomFieldName")]
        public int I = 0;

        // Дополнительные поля для тестирования
        public string S = "default";
    }
}
