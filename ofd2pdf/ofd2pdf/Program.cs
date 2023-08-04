using Spire.Pdf.Conversion;
using System;

namespace ofd2pdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("OFD TO PDF 转换工具");
                Console.WriteLine("使用方式： ofd2pdf.exe <ofdfile>");
            }
            else
            {
                var ofdfile = args[0]; 
                if (ofdfile.EndsWith("ofd",true,null))
                {
                    Console.WriteLine($"#转换 {ofdfile}");
                    OfdConverter oc = new OfdConverter(ofdfile);
                    oc.ToPdf(ofdfile+".pdf");
                    Console.WriteLine($"#完成 {ofdfile}");
                }
                else
                {
                    Console.WriteLine($"{ofdfile} 不是OFD文件");
                }
            }
        }
    }
}
