﻿using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var target = "C# programming";
            var isExists = target.All(c => char.IsLower(c));
            
        }
    }
}
