using System.Security.Cryptography;
using CryptoAlgorithms.Ciphers;
using CryptoAlgorithms.Ciphers.CTR;
using CryptoAlgorithms.Hashes;
using CryptoApp.Services;
using CryptoFileSystem;

namespace CryptoApp;

public partial class MainForm : Form
{
    private const string AppLogTag = "APP";
    
    private FolderWatcherService? _folderWatcherService;
    private NetworkService? _networkService;

    private ICipher? _currentCipher;
    private IHash? _currentHasher;
    private Logger _logger;

    public MainForm()
    {
        _logger = new Logger();
        _logger.OnLog += OnActionLogged;
        InitializeComponent();
    }

    private void OnActionLogged(string log)
    {
        if (richTextBoxLog.InvokeRequired)
        {
            richTextBoxLog.Invoke(() => AppendToRichTextBox(log));
        }
        else
        {
            AppendToRichTextBox(log);
        }
    }

    private void AppendToRichTextBox(object message)
    {
        richTextBoxLog.AppendText(message + Environment.NewLine);
        richTextBoxLog.ScrollToCaret();
    }

    private bool AlgorithmsSelected() => CipherSelected() && HashSelected();
    private bool CipherSelected() => _currentCipher != null;
    private bool HashSelected() => _currentHasher != null;

    private void SetAlgorithms()
    {
        if (radioButtonSHA256.Checked)
        {
            _currentHasher = new Sha256();
        }
        else if (radioButtonSHA512.Checked)
        {
            _currentHasher = new Sha512();
        }
        else
        {
            return;
        }

        if (radioButtonTEA.Checked)
        {
            _currentCipher = new TeaCipher();
        } 
        else if (radioButtonLEA128.Checked)
        {
            _currentCipher = new Lea128Cipher();
        }
        else if (radioButtonLEA192.Checked)
        {
            _currentCipher = new Lea192Cipher();
        }
        else if (radioButtonLEA256.Checked)
        {
            _currentCipher = new Lea256Cipher();
        }
        else
        {
            return;
        }

        if (checkBoxCTR.Checked)
        {
            _currentCipher = new CtrModeCipher(_currentCipher, RandomNumberGenerator.GetBytes(_currentCipher.BlockSize));
        }
    }

    private bool InputForManualValid(string inputFile, string outputDirectory, string key)
    {
        if (!File.Exists(inputFile))
        {
            MessageBox.Show("Provided file does not exist.");
            return false;
        }
        if (!Directory.Exists(outputDirectory))
        {
            MessageBox.Show("Provided directory does not exist.");
            return false;
        }
        if (string.IsNullOrEmpty(key))
        {
            MessageBox.Show("Please enter a key.");
            return false;
        }
        if (!AlgorithmsSelected())
        {
            MessageBox.Show("Please select cipher and hash algorithm.");
            return false;
        }
        
        return true;
    }

    private bool InputForFswValid(string inputFolder, string outputFolder, string key)
    {
        if (!Directory.Exists(inputFolder))
        {
            MessageBox.Show("Input directory does not exist.");
            return false;
        }

        if (!Directory.Exists(outputFolder))
        {
            MessageBox.Show("Output directory does not exist.");
            return false;
        }

        if (string.IsNullOrEmpty(key))
        {
            MessageBox.Show("Please enter a key.");
            return false;
        }

        if (!AlgorithmsSelected())
        {
            MessageBox.Show("Please select cipher and hash algorithm.");
            return false;
        }
        
        return true;
    }
    
    private void ButtonInputFileManual_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxInputFileManual.Text = openFileDialog.FileName;
        }
    }

    private void ButtonBrowseOutputDirectoryManual_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxOutputDirectoryManual.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void EncryptManual()
    {
        string inputFile = textBoxInputFileManual.Text;
        string outputDirectory = textBoxOutputDirectoryManual.Text;
        string key = textBoxKeyManual.Text;
        
        SetAlgorithms();

        if (!InputForManualValid(inputFile, outputDirectory, key))
        {
            return;
        }

        ManualService.Encrypt(inputFile, outputDirectory, key, _currentCipher!, _currentHasher!, _logger);
    }

    private void ButtonEncryptManual_Click(object sender, EventArgs e)
    {
        Task.Run(EncryptManual);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        _logger.LogInfo(AppLogTag, "Application Started.");
        buttonStopFSW.Enabled = false;
        buttonStopNetwork.Enabled = false;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _folderWatcherService?.Stop();
        _networkService?.Stop();
        _logger.LogInfo(AppLogTag, "Application Stopped.");
        _logger.Dispose();
    }

    private void DecryptManual()
    {
        string inputFile = textBoxInputFileManual.Text;
        string outputDirectory = textBoxOutputDirectoryManual.Text;
        string key = textBoxKeyManual.Text;
        
        SetAlgorithms();
        
        if (!InputForManualValid(inputFile, outputDirectory, key))
        {
            return;
        }
        
        ManualService.Decrypt(inputFile, outputDirectory, key, _logger);
    }

    private void ButtonDecryptManual_Click(object sender, EventArgs e)
    {
        Task.Run(DecryptManual);
    }

    private void ButtonBrowseInputDirectoryFSW_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxInputDirectoryFSW.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void ButtonBrowseOutputDirectoryFSW_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxOutputDirectoryFSW.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void ButtonStartFSW_Click(object sender, EventArgs e)
    {
        string inputFolder = textBoxInputDirectoryFSW.Text;
        string outputFolder = textBoxOutputDirectoryFSW.Text;
        string key = textBoxKeyFSW.Text;

        SetAlgorithms();

        if (!InputForFswValid(inputFolder, outputFolder, key))
        {
            return;
        }

        byte[] hashedKey = new Sha256().ComputeHash(key);

        _folderWatcherService = new FolderWatcherService(inputFolder, outputFolder, hashedKey, _currentCipher!, _currentHasher!, _logger);
        _folderWatcherService.Start();

        buttonStartFSW.Enabled = false;
        buttonStopFSW.Enabled = true;
    }

    private void ButtonStopFSW_Click(object sender, EventArgs e)
    {
        _folderWatcherService?.Stop();
        
        buttonStartFSW.Enabled = true;
        buttonStopFSW.Enabled = false;
    }

    private void ButtonFileToSendNetwork_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxFileToSendNetwork.Text = openFileDialog.FileName;
        }
    }

    private void ButtonOutputDirectoryNetwork_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            textBoxOutputDirectoryNetwork.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private bool InputForNetworkReceivingValid(string outputDirectory, string key, string portStr)
    {
        if (!Directory.Exists(outputDirectory))
        {
            MessageBox.Show("Output directory does not exist.");
            return false;
        }
        if (string.IsNullOrEmpty(key))
        {
            MessageBox.Show("Please enter a key.");
            return false;
        }
        if (!int.TryParse(portStr, out _))
        {
            MessageBox.Show("Please enter a valid port number.");
            return false;
        }
        return true;
    }

    private void ButtonStartNetwork_Click(object sender, EventArgs e)
    {
        string outputDirectory = textBoxOutputDirectoryNetwork.Text;
        string key = textBoxKeyNetwork.Text;
        string portStr = textBoxPortReceivingNetwork.Text;

        if (!InputForNetworkReceivingValid(outputDirectory, key, portStr))
        {
            return;
        }

        byte[] hashedKey = new Sha256().ComputeHash(key);
        int port = int.Parse(portStr);

        _networkService = new NetworkService(outputDirectory, hashedKey, _logger);
        
        if (_networkService.Start(port))
        {
            buttonStartNetwork.Enabled = false;
            buttonStopNetwork.Enabled = true;
            buttonEncryptAndSendNetwork.Enabled = true;
        }
        else
        {
            _networkService = null;
        }
    }

    private void ButtonStopNetwork_Click(object sender, EventArgs e)
    {
        _networkService?.Stop();
        buttonStartNetwork.Enabled = true;
        buttonStopNetwork.Enabled = false;
        buttonEncryptAndSendNetwork.Enabled = false;
    }

    private bool InputForNetworkSendingValid(string inputFile, string ip, string portStr)
    {
        if (!File.Exists(inputFile))
        {
            MessageBox.Show("File to send does not exist.");
            return false;
        }
        if (string.IsNullOrEmpty(ip))
        {
            MessageBox.Show("Please enter a destination IP.");
            return false;
        }
        if (!int.TryParse(portStr, out _))
        {
            MessageBox.Show("Please enter a valid destination port.");
            return false;
        }
        if (!AlgorithmsSelected())
        {
            MessageBox.Show("Please select cipher and hash algorithm.");
            return false;
        }
        return true;
    }

    private async void ButtonEncryptAndSendNetwork_Click(object sender, EventArgs e)
    {
        if (_networkService == null)
        {
            MessageBox.Show("Network service must be started to send files.");
            return;
        }

        string inputFile = textBoxFileToSendNetwork.Text;
        string ip = textBoxIPNetwork.Text;
        string portStr = textBoxPortSendingNetwork.Text;

        SetAlgorithms();

        if (!InputForNetworkSendingValid(inputFile, ip, portStr))
        {
            return;
        }

        int port = int.Parse(portStr);
        
        string key = textBoxKeyNetwork.Text; 
        byte[] hashedKey = new Sha256().ComputeHash(key);

        try
        {
            await NetworkService.SendFileAsync(inputFile, ip, port, _currentCipher!, _currentHasher!, hashedKey, _logger);
        }
        catch (Exception ex)
        {
            _logger.LogError(AppLogTag, $"Failed to send file: {ex.Message}");
        }
    }

    private void textBoxPortReceivingNetwork_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void textBoxPortSendingNetwork_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void textBoxIPNetwork_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
        {
            e.Handled = true; 
        }

        TextBox tb = (sender as TextBox)!;
        
        if (e.KeyChar == '.' && (tb.Text.EndsWith(".") || tb.Text.Length == 0))
        {
            e.Handled = true;
        }
    }
}