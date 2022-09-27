using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Classes
{
    internal class Class1
    {
        public static EF.LiveChatEntities Context { get; } = new EF.LiveChatEntities();
    }
}
