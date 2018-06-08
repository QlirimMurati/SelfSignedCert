using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using Pluralsight.Crypto;
using System.Runtime.InteropServices;
using System.Xml;
using System.Security.Cryptography.Xml;
namespace Pluralsight.Crypto.UI
{
    public partial class GenerateSelfSignedCertForm : Form
    {
        public GenerateSelfSignedCertForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            LoadStoreDropdownLists();
        }

        private void LoadStoreDropdownLists()
        {
            cboStoreLocation.Items.Clear();
            foreach (StoreLocation storeLocation in Enum.GetValues(typeof(StoreLocation)))
            {
                int index = cboStoreLocation.Items.Add(storeLocation);
                if (StoreLocation.LocalMachine == storeLocation)
                    cboStoreLocation.SelectedIndex = index;
            }
            
            cboStoreName.Items.Clear();
            foreach (StoreName storeName in Enum.GetValues(typeof(StoreName)))
            {
                int index = cboStoreName.Items.Add(storeName);
                if (StoreName.My == storeName)
                    cboStoreName.SelectedIndex = index;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void LoadSettings()
        {
            LoadDefaultSettings();
            
            XDocument doc = null;
            try
            {
                doc = XDocument.Load(SettingsFile);
            }
            catch (IOException) { }

            if (null != doc)
                LoadSettings(doc);
        }

        private void LoadDefaultSettings()
        {
            DateTime today = DateTime.Today;

            txtDN.Text = "cn=localhost";
            cboKeySize.Text = "4096";
            dtpValidFrom.Value = today.AddDays(-7); 
            dtpValidTo.Value = today.AddYears(10);
        }

        private void LoadSettings(XDocument doc)
        {
            txtDN.Text = GetSetting(doc, "dn", "");
            cboKeySize.Text = GetSetting(doc, "keySize", "4096");
        }

        private string GetSetting(XDocument doc, string elementName, string defaultValue)
        {
            XElement dnElement = doc.Root.Element(elementName);
            return (null != dnElement) ? dnElement.Value : defaultValue;
        }

        private void SaveSettings()
        {
            XDocument doc = new XDocument(
                new XElement("settings",
                    new XElement("dn", txtDN.Text),
                    new XElement("keySize", cboKeySize.Text)
                    ));
            try
            {
                doc.Save(SettingsFile);
            }
            catch (IOException)
            {
                throw;
            }
        }

        private string SettingsFile
        {
            get
            {
                return Path.Combine(Application.LocalUserAppDataPath, "settings.xml");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAsPFX_Click(object sender, EventArgs e)
        {
            if (!ValidateCertProperties())
                return;

            X509Certificate2 cert = GenerateCert();
            if (null == cert)
                return; 

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "PFX file (*.pfx)|*.pfx";

            if (DialogResult.OK == fileDialog.ShowDialog(this))
            {
                using (Stream outputStream = File.Create(fileDialog.FileName))
                {
                    byte[] pfx = cert.Export(X509ContentType.Pfx, txtPassword.Text.Length > 0 ? txtPassword.Text : null);
                    outputStream.Write(pfx, 0, pfx.Length);
                    outputStream.Close();
                }

                MessageBox.Show(this,
                    "Successfully saved a new self-signed certificate to "
                    + Path.GetFileName(fileDialog.FileName), "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool ValidateCertProperties()
        {
            if (!ValidateDN())
            {
                txtDN.SelectAll();
                txtDN.Focus();
                return false;
            }
            if (!ValidateKeySize())
            {
                cboKeySize.Focus();
                return false;
            }
            return true;
        }

        private void btnSaveToCertStore_Click(object sender, EventArgs e)
        {
            X509Store store = new X509Store((StoreName)cboStoreName.SelectedItem, (StoreLocation)cboStoreLocation.SelectedItem);
            store.Open(OpenFlags.ReadWrite);

            X509Certificate2 cert = GenerateCert();
            if (null != cert)
            {
                byte[] pfx = cert.Export(X509ContentType.Pfx);
                cert = new X509Certificate2(pfx, (string)null, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
                
                store.Add(cert);
            }
            store.Close();

            if (null != cert)
            {
                new CertDetailsForm
                {
                    Certificate = cert,
                    CertStoreLocation = (StoreLocation)cboStoreLocation.SelectedItem,
                    CertStoreName = (StoreName)cboStoreName.SelectedItem,
                }.ShowDialog();
            }
        }

        private X509Certificate2 GenerateCert()
        {
            
            BackgroundCertGenForm form = new BackgroundCertGenForm();
            form.CertProperties = new SelfSignedCertProperties
            {
                Name = new X500DistinguishedName(txtDN.Text),
                ValidFrom = dtpValidFrom.Value,
                ValidTo = dtpValidTo.Value,
                KeyBitLength = int.Parse(cboKeySize.Text),
                IsPrivateKeyExportable = true,
            };
            form.ShowDialog();

            return form.Certificate;
        }

        private void cboKeySize_Validating(object sender, CancelEventArgs e)
        {
            ValidateKeySize();
        }

        private void txtDN_Validating(object sender, CancelEventArgs e)
        {
            ValidateDN();
        }

        private bool ValidateDN()
        {
            try
            {
                new X500DistinguishedName(txtDN.Text);
                errorProvider.SetError(txtDN, "");
                return true;
            }
            catch (CryptographicException x)
            {
                errorProvider.SetError(txtDN, x.Message);
            }
            return false;
        }

        private bool ValidateKeySize()
        {
            string errorMsg = "";

            int keySize;
            if (int.TryParse(cboKeySize.Text, out keySize))
            {

                switch (keySize)
                {
                    case 384:
                    case 512:
                    case 1024:
                    case 2048:
                    case 4096:
                    case 8192:
                    case 16384:
                        break;
                    default:
                        errorMsg = "Invalid key size.";
                        break;
                }
            }
            else errorMsg = "Key size must be an integer value.";
            errorProvider.SetError(cboKeySize, errorMsg);

            return "" == errorMsg;
        }

        
        X509Certificate2 certifikata;
        private void btnUpload_Click(object sender, EventArgs e)
        {
            X509Store objStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            objStore.Open(OpenFlags.OpenExistingOnly);

            X509Certificate2Collection certCollection =
                X509Certificate2UI.SelectFromCollection(objStore.Certificates,
                "Choose Certificate for Signature", "Choose Certificate", X509SelectionFlag.SingleSelection);

            try
            {
                certifikata = certCollection[0];
                if (certifikata.HasPrivateKey)
                {
                    MessageBox.Show("Certificate has private key");

                    string strContent = "";
                    strContent += "Subject: " + certifikata.Subject + "\n";
                    strContent += "Issuer: " + certifikata.Issuer + "\n";
                    strContent += "Thumbprint: " + certifikata.Thumbprint;

                    MessageBox.Show("Certificate details:\n\n" + strContent);
                    txtCert.Text = certifikata.Thumbprint.ToString();
                }
            }
            catch { }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            
            savefile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                txtSave.Text = savefile.FileName;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            XmlDocument objXml = new XmlDocument();
            objXml.Load(txtFile.Text);

            SignedXml objSignedXml = new SignedXml(objXml);

            RSACryptoServiceProvider objRsa = (RSACryptoServiceProvider)certifikata.PrivateKey;
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
        
        

        
       

       private void toolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        
    }
}
