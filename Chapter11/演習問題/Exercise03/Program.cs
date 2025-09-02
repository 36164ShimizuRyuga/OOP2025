﻿using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            ];
foreach (var line in texts) {
    var matches = Regex.Matches(line, @"\btime\b", RegexOptions.IgnoreCase);

    foreach (Match match2 in matches) {
        Console.WriteLine($"{line},{match2.Index}");
    }

}

