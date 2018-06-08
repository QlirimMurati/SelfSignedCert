
using System;
using Pluralsight.Crypto.UI;
using System.Windows.Forms;
using Pluralsight.Crypto;
using System.Security.Cryptography.X509Certificates;

namespace GenSelfSignedCert
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            new GenerateSelfSignedCertForm().ShowDialog();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).ToString());
        }

        static void GenSelfSignedCert()
        {
            using (CryptContext ctx = new CryptContext())
            {
                ctx.Open();

                X509Certificate2 cert = ctx.CreateSelfSignedCertificate(
                    new SelfSignedCertProperties
                    {
                        IsPrivateKeyExportable = true,
                        KeyBitLength = 4096,
                        Name = new X500DistinguishedName("localhost"),
                        ValidFrom = DateTime.Today.AddDays(-1),
                        ValidTo = DateTime.Today.AddYears(1),
                    });

                X509Certificate2UI.DisplayCertificate(cert);
            }
        }
    }
}
