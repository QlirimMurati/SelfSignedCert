using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Pluralsight.Crypto.UI
{
    public partial class CertDetailsForm : Form
    {
        public StoreLocation CertStoreLocation { get; set; }
        public StoreName CertStoreName { get; set; }
        public X509Certificate2 Certificate { get; set; }

        public CertDetailsForm()
        {
            InitializeComponent();
        }

        private void CertDetailsForm_Load(object sender, EventArgs e)
        {
            txtStore.Text = string.Format("{0}/{1}", CertStoreLocation, CertStoreName);
            txtThumbprint.Text = Certificate.Thumbprint;

            RSACryptoServiceProvider privateKey = Certificate.PrivateKey as RSACryptoServiceProvider;
            if (null != privateKey)
            {
                string keyFile = privateKey.CspKeyContainerInfo.UniqueKeyContainerName;
                txtPrivateKeyFile.Text = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Crypto\RSA\MachineKeys"), keyFile);
            }
            else btnViewPrivateKeyFile.Enabled = false;
        }

        private void btnViewStore_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store(CertStoreName, CertStoreLocation);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2UI.SelectFromCollection(store.Certificates, txtStore.Text, "", X509SelectionFlag.SingleSelection);
        }

        private void btnViewCert_Click(object sender, EventArgs e)
        {
            X509Certificate2UI.DisplayCertificate(Certificate);
        }

        private void btnViewPrivateKeyFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + txtPrivateKeyFile.Text);
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = opf.FileName;
            }
        }

        private void txtStore_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            XmlDocument objXml = new XmlDocument();
            objXml.Load(txtFile.Text);

            SignedXml objSignedXml = new SignedXml(objXml);

            RSACryptoServiceProvider objRsa = (RSACryptoServiceProvider)Certificate.PrivateKey;
            objSignedXml.SigningKey = objRsa;

            Reference objReferenca = new Reference();
            objReferenca.Uri = "";

            XmlDsigEnvelopedSignatureTransform objTransform = new XmlDsigEnvelopedSignatureTransform();
            objReferenca.AddTransform(objTransform);

            objSignedXml.AddReference(objReferenca);

            KeyInfo objKI = new KeyInfo();
            objKI.AddClause(new RSAKeyValue(objRsa));

            objSignedXml.KeyInfo = objKI;

            objSignedXml.ComputeSignature();

            XmlElement SignatureTag = objSignedXml.GetXml();

            XmlElement rootNode = objXml.DocumentElement;
            rootNode.AppendChild(SignatureTag);

            objXml.Save(txtSave.Text);

           
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            XmlDocument objXml = new XmlDocument();
            objXml.Load(txtSave.Text);
            SignedXml objSignedXml = new SignedXml(objXml);

            XmlNodeList objListaSignatureElements = objXml.GetElementsByTagName("Signature");
            XmlElement objSignatureElement = (XmlElement)objListaSignatureElements[0];

            objSignedXml.LoadXml(objSignatureElement);

            if (objSignedXml.CheckSignature())
                MessageBox.Show("Signature is valid!");
            else
                MessageBox.Show("Signature is not valid!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                txtSave.Text = savefile.FileName;
            }
        }

        
    }
}
