using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Class
{
    public static class RtfHelper
    {
        public enum FontColorEnum
        {
            Green = 1,
            White = 2,
            OffWhite = 3,
            Blue = 4,
            Black = 5,
            Red = 6,
            Yellow = 7,
            Purple = 8,
            Orange = 9,
            Brown = 10
        }

        public static string RtfFont()
        {
            return @"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset0 Arial;}}";
        }

        public static string RtfColorTable()
        {
            return @"{\colortbl;
                      \red22\green181\blue50;
                      \red255\green255\blue255;
                      \red230\green255\blue230;
                      \red99\green184\blue255;
                      \red0\green0\blue0;
                      \red250\green22\blue22;
                      \red0\green122\blue110;
                      \red202\green153\blue255;
                      \red255\green170\blue79;
                      \red179\green142\blue104;
                      }";
        }

        public static string PlainTextToRtf(string plainText)
        {
            string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}").Replace("   ", "");
            string rtf = @"{\rtf1\ansi{ "; //\fonttbl\f0\froman Tms Rmn;}\f0\pard
            rtf += escapedPlainText.Replace(Environment.NewLine, "").Replace(@"\\r\\n", @"\par\par");
            rtf += " }";
            return rtf;
        }

        public static string Begin()
        {
            return @"{\rtf1\ansi{ ";
        }

        public static string ConvertText(ref string rtf, string plainText)
        {
            string escapedPlainText = plainText.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}").Replace("   ", "");
            rtf += escapedPlainText.Replace(Environment.NewLine, "").Replace(@"\\r\\n", @"\par\par ");
            return rtf;
        }

        public static string End(ref string rtf)
        {
            rtf += " }";
            return rtf;
        }

        public static string EndLine(ref string rtf)
        {
            rtf += @"\par ";
            return rtf;
        }

        public static string Bold(ref string rtf, string text)
        {
            rtf += String.Format(@"\b {0} \b0 ", text);
            return text;
        }
    }
}
