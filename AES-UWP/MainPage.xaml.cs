using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Security.Cryptography.Core;
using Windows.Security.Cryptography;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AES_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Random rnd = new Random();

            byte[] key = new byte[64];
            rnd.NextBytes(key);
            byte[] data = new byte[3] { 1, 2, 3 };

            SymmetricKeyAlgorithmProvider AES = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesEcbPkcs7);
            CryptographicKey cryKey = AES.CreateSymmetricKey(CryptographicBuffer.CreateFromByteArray(key));
            IBuffer buffData = CryptographicBuffer.CreateFromByteArray(data);

            IBuffer crypted = CryptographicEngine.Encrypt(cryKey, buffData, null);

            IBuffer decrypted = CryptographicEngine.Decrypt(cryKey, crypted, null);
            byte[] decryptedData = decrypted.ToArray();

        }
    }
}
