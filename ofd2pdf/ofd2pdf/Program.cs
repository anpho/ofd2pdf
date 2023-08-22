using Spire.Pdf.Conversion;
using System;
using System.Windows.Forms;

namespace ofd2pdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Spire.PDF 的 License 部分，此前使用的是个人临时License，需要自行替换
             */
            string currentFolder=System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string licenseFile = System.IO.Path.Combine(currentFolder, "license.elic.xml");
            if (System.IO.File.Exists(licenseFile) ) {
                Spire.Pdf.License.LicenseProvider.SetLicenseFileName(licenseFile);
            }
            else
            {
                Console.WriteLine("Spire.PDF License 文件(license.elic.xml)未找到");
                MessageBox.Show("Spire.PDF License 文件(license.elic.xml)未找到");
            }
            
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
