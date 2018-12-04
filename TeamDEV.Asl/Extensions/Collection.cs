using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamDEV.Asl.Extensions {
    static class Collection {
        public static bool IsEmpty(this Array array) {
            return array.Length <= 0;
        }
    }
}