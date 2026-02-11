namespace CryptoApp;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBoxCiphers = new System.Windows.Forms.GroupBox();
        checkBoxCTR = new System.Windows.Forms.CheckBox();
        radioButtonLEA256 = new System.Windows.Forms.RadioButton();
        radioButtonLEA192 = new System.Windows.Forms.RadioButton();
        radioButtonLEA128 = new System.Windows.Forms.RadioButton();
        radioButtonTEA = new System.Windows.Forms.RadioButton();
        groupBoxHashes = new System.Windows.Forms.GroupBox();
        radioButtonSHA512 = new System.Windows.Forms.RadioButton();
        radioButtonSHA256 = new System.Windows.Forms.RadioButton();
        textBoxInputDirectoryFSW = new System.Windows.Forms.TextBox();
        labelInputDirectoryFSW = new System.Windows.Forms.Label();
        buttonInputDirectoryFSW = new System.Windows.Forms.Button();
        labelOutputDirectoryFSW = new System.Windows.Forms.Label();
        textBoxOutputDirectoryFSW = new System.Windows.Forms.TextBox();
        buttonOutputDirectoryFSW = new System.Windows.Forms.Button();
        labelInputFileManual = new System.Windows.Forms.Label();
        textBoxInputFileManual = new System.Windows.Forms.TextBox();
        tabControlMode = new System.Windows.Forms.TabControl();
        tabPageManual = new System.Windows.Forms.TabPage();
        buttonDecryptManual = new System.Windows.Forms.Button();
        buttonEncryptManual = new System.Windows.Forms.Button();
        labelKeyManual = new System.Windows.Forms.Label();
        textBoxKeyManual = new System.Windows.Forms.TextBox();
        buttonInputFileManual = new System.Windows.Forms.Button();
        textBoxOutputDirectoryManual = new System.Windows.Forms.TextBox();
        buttonBrowseOutputDirectoryManual = new System.Windows.Forms.Button();
        labelOutputDirectoryManual = new System.Windows.Forms.Label();
        tabPageFSW = new System.Windows.Forms.TabPage();
        buttonStopFSW = new System.Windows.Forms.Button();
        buttonStartFSW = new System.Windows.Forms.Button();
        labelKeyFSW = new System.Windows.Forms.Label();
        textBoxKeyFSW = new System.Windows.Forms.TextBox();
        tabPageNetwork = new System.Windows.Forms.TabPage();
        groupBoxSendingNetwork = new System.Windows.Forms.GroupBox();
        labelPortSendingNetwork = new System.Windows.Forms.Label();
        labelIPNetwork = new System.Windows.Forms.Label();
        textBoxPortSendingNetwork = new System.Windows.Forms.TextBox();
        textBoxIPNetwork = new System.Windows.Forms.TextBox();
        buttonEncryptAndSendNetwork = new System.Windows.Forms.Button();
        textBoxFileToSendNetwork = new System.Windows.Forms.TextBox();
        labelFileToSendNetwork = new System.Windows.Forms.Label();
        buttonFileToSendNetwork = new System.Windows.Forms.Button();
        groupBoxReceivingNetwork = new System.Windows.Forms.GroupBox();
        labelOutputDirectoryNetwork = new System.Windows.Forms.Label();
        labelKeyNetwork = new System.Windows.Forms.Label();
        buttonStartNetwork = new System.Windows.Forms.Button();
        textBoxKeyNetwork = new System.Windows.Forms.TextBox();
        buttonStopNetwork = new System.Windows.Forms.Button();
        labelPortReceivingNetwork = new System.Windows.Forms.Label();
        buttonOutputDirectoryNetwork = new System.Windows.Forms.Button();
        textBoxOutputDirectoryNetwork = new System.Windows.Forms.TextBox();
        textBoxPortReceivingNetwork = new System.Windows.Forms.TextBox();
        richTextBoxLog = new System.Windows.Forms.RichTextBox();
        openFileDialog = new System.Windows.Forms.OpenFileDialog();
        folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
        groupBoxCiphers.SuspendLayout();
        groupBoxHashes.SuspendLayout();
        tabControlMode.SuspendLayout();
        tabPageManual.SuspendLayout();
        tabPageFSW.SuspendLayout();
        tabPageNetwork.SuspendLayout();
        groupBoxSendingNetwork.SuspendLayout();
        groupBoxReceivingNetwork.SuspendLayout();
        SuspendLayout();
        // 
        // groupBoxCiphers
        // 
        groupBoxCiphers.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        groupBoxCiphers.Controls.Add(checkBoxCTR);
        groupBoxCiphers.Controls.Add(radioButtonLEA256);
        groupBoxCiphers.Controls.Add(radioButtonLEA192);
        groupBoxCiphers.Controls.Add(radioButtonLEA128);
        groupBoxCiphers.Controls.Add(radioButtonTEA);
        groupBoxCiphers.Location = new System.Drawing.Point(696, 46);
        groupBoxCiphers.Name = "groupBoxCiphers";
        groupBoxCiphers.Size = new System.Drawing.Size(173, 207);
        groupBoxCiphers.TabIndex = 0;
        groupBoxCiphers.TabStop = false;
        groupBoxCiphers.Text = "Cipher Algorithms";
        // 
        // checkBoxCTR
        // 
        checkBoxCTR.AutoSize = true;
        checkBoxCTR.Location = new System.Drawing.Point(6, 174);
        checkBoxCTR.Name = "checkBoxCTR";
        checkBoxCTR.Size = new System.Drawing.Size(121, 29);
        checkBoxCTR.TabIndex = 4;
        checkBoxCTR.Text = "CTR Mode";
        checkBoxCTR.UseVisualStyleBackColor = true;
        // 
        // radioButtonLEA256
        // 
        radioButtonLEA256.Location = new System.Drawing.Point(6, 138);
        radioButtonLEA256.Name = "radioButtonLEA256";
        radioButtonLEA256.Size = new System.Drawing.Size(161, 30);
        radioButtonLEA256.TabIndex = 3;
        radioButtonLEA256.Text = "LEA-256";
        radioButtonLEA256.UseVisualStyleBackColor = true;
        // 
        // radioButtonLEA192
        // 
        radioButtonLEA192.Location = new System.Drawing.Point(6, 102);
        radioButtonLEA192.Name = "radioButtonLEA192";
        radioButtonLEA192.Size = new System.Drawing.Size(161, 30);
        radioButtonLEA192.TabIndex = 2;
        radioButtonLEA192.Text = "LEA-192";
        radioButtonLEA192.UseVisualStyleBackColor = true;
        // 
        // radioButtonLEA128
        // 
        radioButtonLEA128.Location = new System.Drawing.Point(6, 66);
        radioButtonLEA128.Name = "radioButtonLEA128";
        radioButtonLEA128.Size = new System.Drawing.Size(161, 30);
        radioButtonLEA128.TabIndex = 1;
        radioButtonLEA128.Text = "LEA-128";
        radioButtonLEA128.UseVisualStyleBackColor = true;
        // 
        // radioButtonTEA
        // 
        radioButtonTEA.Checked = true;
        radioButtonTEA.Location = new System.Drawing.Point(6, 30);
        radioButtonTEA.Name = "radioButtonTEA";
        radioButtonTEA.Size = new System.Drawing.Size(161, 30);
        radioButtonTEA.TabIndex = 0;
        radioButtonTEA.TabStop = true;
        radioButtonTEA.Text = "TEA";
        radioButtonTEA.UseVisualStyleBackColor = true;
        // 
        // groupBoxHashes
        // 
        groupBoxHashes.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        groupBoxHashes.Controls.Add(radioButtonSHA512);
        groupBoxHashes.Controls.Add(radioButtonSHA256);
        groupBoxHashes.Location = new System.Drawing.Point(696, 259);
        groupBoxHashes.Name = "groupBoxHashes";
        groupBoxHashes.Size = new System.Drawing.Size(173, 101);
        groupBoxHashes.TabIndex = 1;
        groupBoxHashes.TabStop = false;
        groupBoxHashes.Text = "Hash Algorithms";
        // 
        // radioButtonSHA512
        // 
        radioButtonSHA512.AutoSize = true;
        radioButtonSHA512.Location = new System.Drawing.Point(6, 65);
        radioButtonSHA512.Name = "radioButtonSHA512";
        radioButtonSHA512.Size = new System.Drawing.Size(109, 29);
        radioButtonSHA512.TabIndex = 1;
        radioButtonSHA512.Text = "SHA-512";
        radioButtonSHA512.UseVisualStyleBackColor = true;
        // 
        // radioButtonSHA256
        // 
        radioButtonSHA256.AutoSize = true;
        radioButtonSHA256.Checked = true;
        radioButtonSHA256.Location = new System.Drawing.Point(6, 30);
        radioButtonSHA256.Name = "radioButtonSHA256";
        radioButtonSHA256.Size = new System.Drawing.Size(109, 29);
        radioButtonSHA256.TabIndex = 0;
        radioButtonSHA256.TabStop = true;
        radioButtonSHA256.Text = "SHA-256";
        radioButtonSHA256.UseVisualStyleBackColor = true;
        // 
        // textBoxInputDirectoryFSW
        // 
        textBoxInputDirectoryFSW.Location = new System.Drawing.Point(6, 37);
        textBoxInputDirectoryFSW.Name = "textBoxInputDirectoryFSW";
        textBoxInputDirectoryFSW.Size = new System.Drawing.Size(540, 31);
        textBoxInputDirectoryFSW.TabIndex = 4;
        // 
        // labelInputDirectoryFSW
        // 
        labelInputDirectoryFSW.AutoSize = true;
        labelInputDirectoryFSW.Location = new System.Drawing.Point(6, 9);
        labelInputDirectoryFSW.Name = "labelInputDirectoryFSW";
        labelInputDirectoryFSW.Size = new System.Drawing.Size(135, 25);
        labelInputDirectoryFSW.TabIndex = 5;
        labelInputDirectoryFSW.Text = "Input Directory:";
        // 
        // buttonInputDirectoryFSW
        // 
        buttonInputDirectoryFSW.Location = new System.Drawing.Point(552, 36);
        buttonInputDirectoryFSW.Name = "buttonInputDirectoryFSW";
        buttonInputDirectoryFSW.Size = new System.Drawing.Size(112, 32);
        buttonInputDirectoryFSW.TabIndex = 6;
        buttonInputDirectoryFSW.Text = "Browse";
        buttonInputDirectoryFSW.UseVisualStyleBackColor = true;
        buttonInputDirectoryFSW.Click += ButtonBrowseInputDirectoryFSW_Click;
        // 
        // labelOutputDirectoryFSW
        // 
        labelOutputDirectoryFSW.AutoSize = true;
        labelOutputDirectoryFSW.Location = new System.Drawing.Point(6, 71);
        labelOutputDirectoryFSW.Name = "labelOutputDirectoryFSW";
        labelOutputDirectoryFSW.Size = new System.Drawing.Size(150, 25);
        labelOutputDirectoryFSW.TabIndex = 7;
        labelOutputDirectoryFSW.Text = "Output Directory:";
        // 
        // textBoxOutputDirectoryFSW
        // 
        textBoxOutputDirectoryFSW.Location = new System.Drawing.Point(6, 99);
        textBoxOutputDirectoryFSW.Name = "textBoxOutputDirectoryFSW";
        textBoxOutputDirectoryFSW.Size = new System.Drawing.Size(540, 31);
        textBoxOutputDirectoryFSW.TabIndex = 8;
        // 
        // buttonOutputDirectoryFSW
        // 
        buttonOutputDirectoryFSW.Location = new System.Drawing.Point(552, 98);
        buttonOutputDirectoryFSW.Name = "buttonOutputDirectoryFSW";
        buttonOutputDirectoryFSW.Size = new System.Drawing.Size(112, 32);
        buttonOutputDirectoryFSW.TabIndex = 9;
        buttonOutputDirectoryFSW.Text = "Browse";
        buttonOutputDirectoryFSW.UseVisualStyleBackColor = true;
        buttonOutputDirectoryFSW.Click += ButtonBrowseOutputDirectoryFSW_Click;
        // 
        // labelInputFileManual
        // 
        labelInputFileManual.AutoSize = true;
        labelInputFileManual.Location = new System.Drawing.Point(6, 9);
        labelInputFileManual.Name = "labelInputFileManual";
        labelInputFileManual.Size = new System.Drawing.Size(195, 25);
        labelInputFileManual.TabIndex = 10;
        labelInputFileManual.Text = "File to encrypt/decrypt:";
        // 
        // textBoxInputFileManual
        // 
        textBoxInputFileManual.Location = new System.Drawing.Point(6, 37);
        textBoxInputFileManual.Name = "textBoxInputFileManual";
        textBoxInputFileManual.Size = new System.Drawing.Size(540, 31);
        textBoxInputFileManual.TabIndex = 11;
        // 
        // tabControlMode
        // 
        tabControlMode.Controls.Add(tabPageManual);
        tabControlMode.Controls.Add(tabPageFSW);
        tabControlMode.Controls.Add(tabPageNetwork);
        tabControlMode.Location = new System.Drawing.Point(12, 12);
        tabControlMode.Name = "tabControlMode";
        tabControlMode.SelectedIndex = 0;
        tabControlMode.Size = new System.Drawing.Size(678, 388);
        tabControlMode.TabIndex = 13;
        // 
        // tabPageManual
        // 
        tabPageManual.Controls.Add(buttonDecryptManual);
        tabPageManual.Controls.Add(buttonEncryptManual);
        tabPageManual.Controls.Add(labelKeyManual);
        tabPageManual.Controls.Add(textBoxKeyManual);
        tabPageManual.Controls.Add(buttonInputFileManual);
        tabPageManual.Controls.Add(textBoxOutputDirectoryManual);
        tabPageManual.Controls.Add(buttonBrowseOutputDirectoryManual);
        tabPageManual.Controls.Add(labelOutputDirectoryManual);
        tabPageManual.Controls.Add(labelInputFileManual);
        tabPageManual.Controls.Add(textBoxInputFileManual);
        tabPageManual.Location = new System.Drawing.Point(4, 34);
        tabPageManual.Name = "tabPageManual";
        tabPageManual.Padding = new System.Windows.Forms.Padding(3);
        tabPageManual.Size = new System.Drawing.Size(670, 350);
        tabPageManual.TabIndex = 0;
        tabPageManual.Text = "Manual";
        tabPageManual.UseVisualStyleBackColor = true;
        // 
        // buttonDecryptManual
        // 
        buttonDecryptManual.Location = new System.Drawing.Point(544, 152);
        buttonDecryptManual.Name = "buttonDecryptManual";
        buttonDecryptManual.Size = new System.Drawing.Size(120, 40);
        buttonDecryptManual.TabIndex = 19;
        buttonDecryptManual.Text = "Decrypt";
        buttonDecryptManual.UseVisualStyleBackColor = true;
        buttonDecryptManual.Click += ButtonDecryptManual_Click;
        // 
        // buttonEncryptManual
        // 
        buttonEncryptManual.Location = new System.Drawing.Point(418, 152);
        buttonEncryptManual.Name = "buttonEncryptManual";
        buttonEncryptManual.Size = new System.Drawing.Size(120, 40);
        buttonEncryptManual.TabIndex = 18;
        buttonEncryptManual.Text = "Encrypt";
        buttonEncryptManual.UseVisualStyleBackColor = true;
        buttonEncryptManual.Click += ButtonEncryptManual_Click;
        // 
        // labelKeyManual
        // 
        labelKeyManual.AutoSize = true;
        labelKeyManual.Location = new System.Drawing.Point(6, 133);
        labelKeyManual.Name = "labelKeyManual";
        labelKeyManual.Size = new System.Drawing.Size(44, 25);
        labelKeyManual.TabIndex = 16;
        labelKeyManual.Text = "Key:";
        // 
        // textBoxKeyManual
        // 
        textBoxKeyManual.Location = new System.Drawing.Point(6, 161);
        textBoxKeyManual.Name = "textBoxKeyManual";
        textBoxKeyManual.Size = new System.Drawing.Size(312, 31);
        textBoxKeyManual.TabIndex = 17;
        // 
        // buttonInputFileManual
        // 
        buttonInputFileManual.Location = new System.Drawing.Point(552, 36);
        buttonInputFileManual.Name = "buttonInputFileManual";
        buttonInputFileManual.Size = new System.Drawing.Size(112, 32);
        buttonInputFileManual.TabIndex = 15;
        buttonInputFileManual.Text = "Browse";
        buttonInputFileManual.UseVisualStyleBackColor = true;
        buttonInputFileManual.Click += ButtonInputFileManual_Click;
        // 
        // textBoxOutputDirectoryManual
        // 
        textBoxOutputDirectoryManual.Location = new System.Drawing.Point(6, 99);
        textBoxOutputDirectoryManual.Name = "textBoxOutputDirectoryManual";
        textBoxOutputDirectoryManual.Size = new System.Drawing.Size(540, 31);
        textBoxOutputDirectoryManual.TabIndex = 13;
        // 
        // buttonBrowseOutputDirectoryManual
        // 
        buttonBrowseOutputDirectoryManual.Location = new System.Drawing.Point(552, 98);
        buttonBrowseOutputDirectoryManual.Name = "buttonBrowseOutputDirectoryManual";
        buttonBrowseOutputDirectoryManual.Size = new System.Drawing.Size(112, 32);
        buttonBrowseOutputDirectoryManual.TabIndex = 14;
        buttonBrowseOutputDirectoryManual.Text = "Browse";
        buttonBrowseOutputDirectoryManual.UseVisualStyleBackColor = true;
        buttonBrowseOutputDirectoryManual.Click += ButtonBrowseOutputDirectoryManual_Click;
        // 
        // labelOutputDirectoryManual
        // 
        labelOutputDirectoryManual.AutoSize = true;
        labelOutputDirectoryManual.Location = new System.Drawing.Point(6, 71);
        labelOutputDirectoryManual.Name = "labelOutputDirectoryManual";
        labelOutputDirectoryManual.Size = new System.Drawing.Size(150, 25);
        labelOutputDirectoryManual.TabIndex = 12;
        labelOutputDirectoryManual.Text = "Output Directory:";
        // 
        // tabPageFSW
        // 
        tabPageFSW.Controls.Add(buttonStopFSW);
        tabPageFSW.Controls.Add(buttonStartFSW);
        tabPageFSW.Controls.Add(labelKeyFSW);
        tabPageFSW.Controls.Add(textBoxKeyFSW);
        tabPageFSW.Controls.Add(textBoxOutputDirectoryFSW);
        tabPageFSW.Controls.Add(textBoxInputDirectoryFSW);
        tabPageFSW.Controls.Add(labelInputDirectoryFSW);
        tabPageFSW.Controls.Add(buttonInputDirectoryFSW);
        tabPageFSW.Controls.Add(buttonOutputDirectoryFSW);
        tabPageFSW.Controls.Add(labelOutputDirectoryFSW);
        tabPageFSW.Location = new System.Drawing.Point(4, 34);
        tabPageFSW.Name = "tabPageFSW";
        tabPageFSW.Padding = new System.Windows.Forms.Padding(3);
        tabPageFSW.Size = new System.Drawing.Size(670, 350);
        tabPageFSW.TabIndex = 1;
        tabPageFSW.Text = "FSW";
        tabPageFSW.UseVisualStyleBackColor = true;
        // 
        // buttonStopFSW
        // 
        buttonStopFSW.Location = new System.Drawing.Point(544, 156);
        buttonStopFSW.Name = "buttonStopFSW";
        buttonStopFSW.Size = new System.Drawing.Size(120, 40);
        buttonStopFSW.TabIndex = 16;
        buttonStopFSW.Text = "Stop";
        buttonStopFSW.UseVisualStyleBackColor = true;
        buttonStopFSW.Click += ButtonStopFSW_Click;
        // 
        // buttonStartFSW
        // 
        buttonStartFSW.Location = new System.Drawing.Point(418, 156);
        buttonStartFSW.Name = "buttonStartFSW";
        buttonStartFSW.Size = new System.Drawing.Size(120, 40);
        buttonStartFSW.TabIndex = 14;
        buttonStartFSW.Text = "Start";
        buttonStartFSW.UseVisualStyleBackColor = true;
        buttonStartFSW.Click += ButtonStartFSW_Click;
        // 
        // labelKeyFSW
        // 
        labelKeyFSW.AutoSize = true;
        labelKeyFSW.Location = new System.Drawing.Point(6, 133);
        labelKeyFSW.Name = "labelKeyFSW";
        labelKeyFSW.Size = new System.Drawing.Size(44, 25);
        labelKeyFSW.TabIndex = 12;
        labelKeyFSW.Text = "Key:";
        // 
        // textBoxKeyFSW
        // 
        textBoxKeyFSW.Location = new System.Drawing.Point(6, 161);
        textBoxKeyFSW.Name = "textBoxKeyFSW";
        textBoxKeyFSW.Size = new System.Drawing.Size(312, 31);
        textBoxKeyFSW.TabIndex = 13;
        // 
        // tabPageNetwork
        // 
        tabPageNetwork.Controls.Add(groupBoxSendingNetwork);
        tabPageNetwork.Controls.Add(groupBoxReceivingNetwork);
        tabPageNetwork.Location = new System.Drawing.Point(4, 34);
        tabPageNetwork.Name = "tabPageNetwork";
        tabPageNetwork.Size = new System.Drawing.Size(670, 350);
        tabPageNetwork.TabIndex = 2;
        tabPageNetwork.Text = "Network";
        tabPageNetwork.UseVisualStyleBackColor = true;
        // 
        // groupBoxSendingNetwork
        // 
        groupBoxSendingNetwork.Controls.Add(labelPortSendingNetwork);
        groupBoxSendingNetwork.Controls.Add(labelIPNetwork);
        groupBoxSendingNetwork.Controls.Add(textBoxPortSendingNetwork);
        groupBoxSendingNetwork.Controls.Add(textBoxIPNetwork);
        groupBoxSendingNetwork.Controls.Add(buttonEncryptAndSendNetwork);
        groupBoxSendingNetwork.Controls.Add(textBoxFileToSendNetwork);
        groupBoxSendingNetwork.Controls.Add(labelFileToSendNetwork);
        groupBoxSendingNetwork.Controls.Add(buttonFileToSendNetwork);
        groupBoxSendingNetwork.Location = new System.Drawing.Point(3, 175);
        groupBoxSendingNetwork.Name = "groupBoxSendingNetwork";
        groupBoxSendingNetwork.Size = new System.Drawing.Size(664, 172);
        groupBoxSendingNetwork.TabIndex = 23;
        groupBoxSendingNetwork.TabStop = false;
        groupBoxSendingNetwork.Text = "Sending";
        // 
        // labelPortSendingNetwork
        // 
        labelPortSendingNetwork.Location = new System.Drawing.Point(265, 95);
        labelPortSendingNetwork.Name = "labelPortSendingNetwork";
        labelPortSendingNetwork.Size = new System.Drawing.Size(55, 28);
        labelPortSendingNetwork.TabIndex = 23;
        labelPortSendingNetwork.Text = "Port:";
        // 
        // labelIPNetwork
        // 
        labelIPNetwork.Location = new System.Drawing.Point(3, 95);
        labelIPNetwork.Name = "labelIPNetwork";
        labelIPNetwork.Size = new System.Drawing.Size(44, 28);
        labelIPNetwork.TabIndex = 22;
        labelIPNetwork.Text = "IP:";
        // 
        // textBoxPortSendingNetwork
        // 
        textBoxPortSendingNetwork.Location = new System.Drawing.Point(265, 126);
        textBoxPortSendingNetwork.MaxLength = 5;
        textBoxPortSendingNetwork.Name = "textBoxPortSendingNetwork";
        textBoxPortSendingNetwork.PlaceholderText = "e.g.5557";
        textBoxPortSendingNetwork.Size = new System.Drawing.Size(122, 31);
        textBoxPortSendingNetwork.TabIndex = 21;
        textBoxPortSendingNetwork.KeyPress += textBoxPortSendingNetwork_KeyPress;
        // 
        // textBoxIPNetwork
        // 
        textBoxIPNetwork.Location = new System.Drawing.Point(3, 126);
        textBoxIPNetwork.Name = "textBoxIPNetwork";
        textBoxIPNetwork.PlaceholderText = "e.g. 192.168.0.83";
        textBoxIPNetwork.Size = new System.Drawing.Size(256, 31);
        textBoxIPNetwork.TabIndex = 20;
        // 
        // buttonEncryptAndSendNetwork
        // 
        buttonEncryptAndSendNetwork.Location = new System.Drawing.Point(408, 117);
        buttonEncryptAndSendNetwork.Enabled = false;
        buttonEncryptAndSendNetwork.Name = "buttonEncryptAndSendNetwork";
        buttonEncryptAndSendNetwork.Size = new System.Drawing.Size(250, 40);
        buttonEncryptAndSendNetwork.TabIndex = 19;
        buttonEncryptAndSendNetwork.Text = "Encrypt and send\r\n";
        buttonEncryptAndSendNetwork.UseVisualStyleBackColor = true;
        buttonEncryptAndSendNetwork.Click += ButtonEncryptAndSendNetwork_Click;
        // 
        // textBoxFileToSendNetwork
        // 
        textBoxFileToSendNetwork.Location = new System.Drawing.Point(3, 61);
        textBoxFileToSendNetwork.Name = "textBoxFileToSendNetwork";
        textBoxFileToSendNetwork.Size = new System.Drawing.Size(537, 31);
        textBoxFileToSendNetwork.TabIndex = 17;
        // 
        // labelFileToSendNetwork
        // 
        labelFileToSendNetwork.AutoSize = true;
        labelFileToSendNetwork.Location = new System.Drawing.Point(3, 33);
        labelFileToSendNetwork.Name = "labelFileToSendNetwork";
        labelFileToSendNetwork.Size = new System.Drawing.Size(107, 25);
        labelFileToSendNetwork.TabIndex = 16;
        labelFileToSendNetwork.Text = "File to send:";
        // 
        // buttonFileToSendNetwork
        // 
        buttonFileToSendNetwork.Location = new System.Drawing.Point(546, 60);
        buttonFileToSendNetwork.Name = "buttonFileToSendNetwork";
        buttonFileToSendNetwork.Size = new System.Drawing.Size(112, 32);
        buttonFileToSendNetwork.TabIndex = 18;
        buttonFileToSendNetwork.Text = "Browse";
        buttonFileToSendNetwork.UseVisualStyleBackColor = true;
        buttonFileToSendNetwork.Click += ButtonFileToSendNetwork_Click;
        // 
        // groupBoxReceivingNetwork
        // 
        groupBoxReceivingNetwork.Controls.Add(labelOutputDirectoryNetwork);
        groupBoxReceivingNetwork.Controls.Add(labelKeyNetwork);
        groupBoxReceivingNetwork.Controls.Add(buttonStartNetwork);
        groupBoxReceivingNetwork.Controls.Add(textBoxKeyNetwork);
        groupBoxReceivingNetwork.Controls.Add(buttonStopNetwork);
        groupBoxReceivingNetwork.Controls.Add(labelPortReceivingNetwork);
        groupBoxReceivingNetwork.Controls.Add(buttonOutputDirectoryNetwork);
        groupBoxReceivingNetwork.Controls.Add(textBoxOutputDirectoryNetwork);
        groupBoxReceivingNetwork.Controls.Add(textBoxPortReceivingNetwork);
        groupBoxReceivingNetwork.Location = new System.Drawing.Point(3, 3);
        groupBoxReceivingNetwork.Name = "groupBoxReceivingNetwork";
        groupBoxReceivingNetwork.Size = new System.Drawing.Size(664, 166);
        groupBoxReceivingNetwork.TabIndex = 22;
        groupBoxReceivingNetwork.TabStop = false;
        groupBoxReceivingNetwork.Text = "Receiving";
        // 
        // labelOutputDirectoryNetwork
        // 
        labelOutputDirectoryNetwork.AutoSize = true;
        labelOutputDirectoryNetwork.Location = new System.Drawing.Point(3, 27);
        labelOutputDirectoryNetwork.Name = "labelOutputDirectoryNetwork";
        labelOutputDirectoryNetwork.Size = new System.Drawing.Size(150, 25);
        labelOutputDirectoryNetwork.TabIndex = 10;
        labelOutputDirectoryNetwork.Text = "Output Directory:";
        // 
        // labelKeyNetwork
        // 
        labelKeyNetwork.AutoSize = true;
        labelKeyNetwork.Location = new System.Drawing.Point(3, 93);
        labelKeyNetwork.Name = "labelKeyNetwork";
        labelKeyNetwork.Size = new System.Drawing.Size(44, 25);
        labelKeyNetwork.TabIndex = 20;
        labelKeyNetwork.Text = "Key:";
        // 
        // buttonStartNetwork
        // 
        buttonStartNetwork.Location = new System.Drawing.Point(412, 112);
        buttonStartNetwork.Name = "buttonStartNetwork";
        buttonStartNetwork.Size = new System.Drawing.Size(120, 40);
        buttonStartNetwork.TabIndex = 0;
        buttonStartNetwork.Text = "Start";
        buttonStartNetwork.UseVisualStyleBackColor = true;
        buttonStartNetwork.Click += ButtonStartNetwork_Click;
        // 
        // textBoxKeyNetwork
        // 
        textBoxKeyNetwork.Location = new System.Drawing.Point(3, 121);
        textBoxKeyNetwork.Name = "textBoxKeyNetwork";
        textBoxKeyNetwork.Size = new System.Drawing.Size(256, 31);
        textBoxKeyNetwork.TabIndex = 21;
        // 
        // buttonStopNetwork
        // 
        buttonStopNetwork.Location = new System.Drawing.Point(538, 112);
        buttonStopNetwork.Name = "buttonStopNetwork";
        buttonStopNetwork.Size = new System.Drawing.Size(120, 40);
        buttonStopNetwork.TabIndex = 1;
        buttonStopNetwork.Text = "Stop";
        buttonStopNetwork.UseVisualStyleBackColor = true;
        buttonStopNetwork.Click += ButtonStopNetwork_Click;
        // 
        // labelPortReceivingNetwork
        // 
        labelPortReceivingNetwork.Location = new System.Drawing.Point(265, 93);
        labelPortReceivingNetwork.Name = "labelPortReceivingNetwork";
        labelPortReceivingNetwork.Size = new System.Drawing.Size(122, 30);
        labelPortReceivingNetwork.TabIndex = 19;
        labelPortReceivingNetwork.Text = "Port:";
        // 
        // buttonOutputDirectoryNetwork
        // 
        buttonOutputDirectoryNetwork.Location = new System.Drawing.Point(546, 55);
        buttonOutputDirectoryNetwork.Name = "buttonOutputDirectoryNetwork";
        buttonOutputDirectoryNetwork.Size = new System.Drawing.Size(112, 32);
        buttonOutputDirectoryNetwork.TabIndex = 12;
        buttonOutputDirectoryNetwork.Text = "Browse";
        buttonOutputDirectoryNetwork.UseVisualStyleBackColor = true;
        buttonOutputDirectoryNetwork.Click += ButtonOutputDirectoryNetwork_Click;
        // 
        // textBoxOutputDirectoryNetwork
        // 
        textBoxOutputDirectoryNetwork.Location = new System.Drawing.Point(3, 55);
        textBoxOutputDirectoryNetwork.Name = "textBoxOutputDirectoryNetwork";
        textBoxOutputDirectoryNetwork.Size = new System.Drawing.Size(537, 31);
        textBoxOutputDirectoryNetwork.TabIndex = 11;
        // 
        // textBoxPortReceivingNetwork
        // 
        textBoxPortReceivingNetwork.Location = new System.Drawing.Point(265, 122);
        textBoxPortReceivingNetwork.MaxLength = 5;
        textBoxPortReceivingNetwork.Name = "textBoxPortReceivingNetwork";
        textBoxPortReceivingNetwork.PlaceholderText = "e.g. 5556";
        textBoxPortReceivingNetwork.Size = new System.Drawing.Size(122, 31);
        textBoxPortReceivingNetwork.TabIndex = 13;
        textBoxPortReceivingNetwork.KeyPress += textBoxPortReceivingNetwork_KeyPress;
        // 
        // richTextBoxLog
        // 
        richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        richTextBoxLog.Location = new System.Drawing.Point(12, 406);
        richTextBoxLog.Name = "richTextBoxLog";
        richTextBoxLog.Size = new System.Drawing.Size(857, 262);
        richTextBoxLog.TabIndex = 14;
        richTextBoxLog.Text = "";
        richTextBoxLog.WordWrap = false;
        // 
        // openFileDialog
        // 
        openFileDialog.InitialDirectory = "C:\\\\";
        openFileDialog.RestoreDirectory = true;
        // 
        // folderBrowserDialog
        // 
        folderBrowserDialog.InitialDirectory = "C:\\\\";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(881, 680);
        Controls.Add(richTextBoxLog);
        Controls.Add(tabControlMode);
        Controls.Add(groupBoxHashes);
        Controls.Add(groupBoxCiphers);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Text = "Zaštita informacija - Veljko Tošić";
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        groupBoxCiphers.ResumeLayout(false);
        groupBoxCiphers.PerformLayout();
        groupBoxHashes.ResumeLayout(false);
        groupBoxHashes.PerformLayout();
        tabControlMode.ResumeLayout(false);
        tabPageManual.ResumeLayout(false);
        tabPageManual.PerformLayout();
        tabPageFSW.ResumeLayout(false);
        tabPageFSW.PerformLayout();
        tabPageNetwork.ResumeLayout(false);
        groupBoxSendingNetwork.ResumeLayout(false);
        groupBoxSendingNetwork.PerformLayout();
        groupBoxReceivingNetwork.ResumeLayout(false);
        groupBoxReceivingNetwork.PerformLayout();
        ResumeLayout(false);
    }

    private GroupBox groupBoxReceivingNetwork;
    private GroupBox groupBoxSendingNetwork;
    private GroupBox groupBoxCiphers;
    private GroupBox groupBoxHashes;
    
    private RadioButton radioButtonTEA;
    private RadioButton radioButtonLEA128;
    private RadioButton radioButtonLEA192;
    private RadioButton radioButtonLEA256;
    private RadioButton radioButtonSHA256;
    private RadioButton radioButtonSHA512;
    
    private CheckBox checkBoxCTR;
    
    private Label labelKeyFSW;
    private Label labelOutputDirectoryManual;
    private Label labelKeyManual;
    private Label labelInputDirectoryFSW;
    private Label labelOutputDirectoryFSW;
    private Label labelInputFileManual;
    private Label labelPortReceivingNetwork;
    private Label labelKeyNetwork;
    private Label labelFileToSendNetwork;
    private Label labelOutputDirectoryNetwork;
    private Label labelIPNetwork;
    private Label labelPortSendingNetwork;
    
    private Button buttonInputFileManual;
    private Button buttonDecryptManual;
    private Button buttonInputDirectoryFSW;
    private Button buttonOutputDirectoryFSW;
    private Button buttonEncryptManual;
    private Button buttonBrowseOutputDirectoryManual;
    private Button buttonStopFSW;
    private Button buttonStartFSW;
    private System.Windows.Forms.Button buttonStartNetwork;
    private Button buttonStopNetwork;
    private System.Windows.Forms.Button buttonOutputDirectoryNetwork;
    private System.Windows.Forms.Button buttonFileToSendNetwork;
    private System.Windows.Forms.Button buttonEncryptAndSendNetwork;
    
    private TextBox textBoxInputDirectoryFSW;
    private TextBox textBoxOutputDirectoryFSW;
    private TextBox textBoxInputFileManual;
    private TextBox textBoxKeyFSW;
    private TextBox textBoxKeyManual;
    private System.Windows.Forms.TextBox textBoxIPNetwork;
    private System.Windows.Forms.TextBox textBoxPortSendingNetwork;
    private TextBox textBoxOutputDirectoryManual;
    private TextBox textBoxFileToSendNetwork;
    private System.Windows.Forms.TextBox textBoxKeyNetwork;
    private TextBox textBoxOutputDirectoryNetwork;
    private System.Windows.Forms.TextBox textBoxPortReceivingNetwork;
    
    private TabControl tabControlMode;
    
    private TabPage tabPageManual;
    private TabPage tabPageFSW;
    private TabPage tabPageNetwork;
    
    private RichTextBox richTextBoxLog;
    
    private OpenFileDialog openFileDialog;
 
    private FolderBrowserDialog folderBrowserDialog;
    
    #endregion
}