using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework.Utills;

    public class Format
    {
        public static string FormatCell(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
                text = " ";

            if (text.Length > width)
                text = text.Substring(0, width - 1) + "…";

            return text.PadRight(width);
        }
    }

