using Spire.Pdf.Conversion;
using System;
using System.Windows.Forms;

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
                MessageBox.Show("使用方式： ofd2pdf.exe <ofdfile> ，或者配置为OFD文件打开方式", "OFD TO PDF 转换工具");
            }
            else
            {
                var ofdfile = args[0]; 
                if (ofdfile.EndsWith("ofd",true,null))
                {
                    Console.WriteLine($"#转换 {ofdfile}");
                    OfdConverter oc = new OfdConverter(ofdfile);
                    string newFilename = ofdfile.Replace(".ofd", ".pdf");
                    oc.ToPdf(newFilename);
                    Console.WriteLine($"#完成 {ofdfile}");

                }
                else
                {
                    MessageBox.Show($"{ofdfile} 不是OFD文件", "OFD TO PDF 转换工具");
                }
            }
        }
    }
}
