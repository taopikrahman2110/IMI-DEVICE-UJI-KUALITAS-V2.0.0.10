using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using MRZReader;
using MRZReader.Model;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Drawing.Imaging;
using System.Reflection;
using MMM.Readers.FullPage;
using System.Configuration;
using System.Security.Principal;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.NetworkInformation;

namespace HLNonBlockingExample.NET
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{

        private static List<WebSocket> connectedClients = new List<WebSocket>();
        private ServerSocket mServerSocket;
        string msgCodeRequest = "";
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MainMenu MainMenu;
		private System.Windows.Forms.MenuItem FileMenu;
		private System.Windows.Forms.MenuItem StateMenu;
		private System.Windows.Forms.MenuItem SettingsMenu;
		private System.Windows.Forms.MenuItem SettingsLogging;
		private System.Windows.Forms.MenuItem SettingsDataToSend;
		private System.Windows.Forms.MenuItem StateEnabled;
		private System.Windows.Forms.MenuItem StateDisabled;
        private System.Windows.Forms.MenuItem StateAsleep;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem FileExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuItem StateSuspend;
		private System.Windows.Forms.StatusBarPanel StatePanel;
        private System.Windows.Forms.StatusBarPanel TimePanel;
		private MenuItem LoggingOff;
		private MenuItem LoggingErrorsOnly;
		private MenuItem LoggingLowDetail;
		private MenuItem LoggingMediumDetail;
		private MenuItem LoggingHighDetail;
		private MenuItem LoggingHighestDetail;
		private MenuItem SettingsRFID;
		private MenuItem SettingsSaveLastImage;
		private MenuItem SettingsSeperator;
        private MenuItem SettingsSave;
        private MenuItem WriteSettingsTextfile;
        private TabPage TimingsTab;
        private ListView TimingsList;
        private ColumnHeader Time;
        private ColumnHeader MessageName;
        private ColumnHeader MessageSize;
        private ColumnHeader Data;
        private TabPage UHFTab;
        private GroupBox EPCGroupBox;
        private Label EPCField;
        private GroupBox groupBox4;
        private Label SerialNumberValue;
        private Label SerialNumberLabel;
        private Label ModelNumberValue;
        private Label ModelNumberLabel;
        private Label MaskDesignerIDValue;
        private Label MaskDesignerIDLabel;
        private Label ManufacturerIDValue;
        private Label ManufacturerIDLabel;
        private TabPage tabPage1;
        private ListView dataFileList;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView validatedList;
        private ColumnHeader dataItem;
        private ColumnHeader validated;
        private GroupBox groupBox3;
        private Label lblBACStatus;
        private Label lblChipId;
        private Label lblAirBaudRate;
        private Label label7;
        private Label label6;
        private Label label4;
        private GroupBox gbPhotoAndMRTD;
        private Label lblRFDocNumber;
        private Label lblRFDateOfBirth;
        private Label lblRFSex;
        private Label lblRFNationality;
        private Label lblRFForenames;
        private Label lblRFSurname;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label13;
        private Label lblRFCodeline;
        private PictureBox rfImage;
        private TabPage ImagesTab;
        private GroupBox groupBox1;
        private RichTextBox richTextBoxCodeline;
        private Label lblDocumentType;
        private Label lblDocumentNumber;
        private Label lblDateOfBirth;
        private Label lblSex;
        private Label lblNationality;
        private Label lblForenames;
        private Label lblSurname;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label3;
        private PictureBox photoImage;
        private Label label5;
        private PictureBox irImage;
        private PictureBox visibleImage;
        private Label label1;
        private PictureBox uvImage;
        private Label label2;
        private TabControl tabControl;
        private TabPage ImagesRearTab;
        private Label label92;
        private PictureBox irImageRear;
        private PictureBox visibleImageRear;
        private Label label93;
        private PictureBox uvImageRear;
        private Label label94;
        private TabPage tabPage2;
        private GroupBox groupBox5;
        private RichTextBox richTextBox1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label label31;
        private PictureBox pictureBox1;
        private Label label32;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label33;
        private PictureBox pictureBox4;
        private Label label34;
        private TabPage tabPage3;
        private ListView listView1;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ListView listView2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private GroupBox groupBox6;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label40;
        private GroupBox groupBox7;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private PictureBox pictureBox5;
        private TabPage tabPage4;
        private GroupBox groupBox8;
        private Label label54;
        private GroupBox groupBox9;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label60;
        private Label label61;
        private Label label62;
        private TabPage tabPage5;
        private ListView listView3;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private GroupBox groupBox10;
        private RichTextBox richTextBox2;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private PictureBox pictureBox6;
        private Label label76;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private Label label77;
        private PictureBox pictureBox9;
        private Label label78;
        private Label lblSACStatus;
        private Label label80;
        private GroupBox groupBox11;
        private Label label79;
        private TextBox tbNoPermohonan;
        private TextBox tbTglLahir;
        private Label label82;
        private TextBox tbNamaPemohon;
        private Label label81;

        private string cancelReallocate;
        private string exchange;
        private string reallocate;
        private string saveReallocation;
        private string failTest;
        private string successTest;
        private string setStatus;
        private string notify;
        private string urlSailsLock;
        private string login;
        private string urlSentData;
        private string urlUpdateUserId;
        private string noPermohonan;
        private string namaPemohon;
        private string tglLahir;
        private string userId;
        private string noPassport;
        private string idUji;
        private string idAlokasi;
        private string pasporName = "paspor.jpg";
        private string codeline1;
        private string codeline2;

        private Button btnZoomIr;
        private Button btnZoomUv;
        private Button btnZoomVis;
        private Label lblIssuingState;
        private Label label83;
        private Label lblSecurityCheck;
        private Label lblChecksum;
        private Label lblRFIssuingState;
        private Label label85;
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private GroupBox gbPassport;
        private GroupBox gbEPassport;
        private Label label87;
        private TextBox tbNoPassport;
        private Button btnSerahkan;
        private Button btnCetakUlang;
        private TextBox tbHasilUji;
        private Label label88;
        private GroupBox groupBox12;
        private Label lblTAStatus;
        private Label label98;
        private Label lblCAStatus;
        private Label label96;
        private Label lblAAStatus;
        private Label label91;
        private Label lblPAStatus;
        private Label label8;
        private RichTextBox rtbLog;
        private Label label99;
        private FlowLayoutPanel flowLayoutPanel1;
        private HTTPHelper http = new HTTPHelper();
        private SentTestData testId = new SentTestData();

        private string tempPath;
        private string exeFolderPath;
        private string iauth;
        private string oldStatus;
        private string oldStatusDetail;
        private string tipe;
        private Button btnClose;
        private Button btnEdit;

        private bool isCloseFromEdit = false;
        private bool isEpaspor = false;
        private GroupBox gbJari;
        private PictureBox pbFinger2;
        private PictureBox pbFinger1;
        private Label lblFinger2Type;
        private Label lblFinger1Type;
        private Button btnZoomFinger2;
        private Button btnZoomFinger1;

        private string base64UV;
        private string base64IR;
        private string base64VIS;
        private string forename;
        private string surname;
        private string kewarganegaraan;
        private string issuingState;
        private string gender;
        private string dob;
        private string docNumber;
        private string docType;
        private string validationResult;
        private string resultState;
        private string resultStateDetail;

        private string AAstatus;
        private string PAstatus;
        private string CAstatus;
        private string TAstatus;
        private string SACstatus;
        private string DOC_Signer;
        private string base64Finger1;
        private string base64Finger2;
        private string ChipId;



        private string nomorPermohonan;
        private string nomorPaspor;
        private string namaLengkap;
        private string tanggalLahir;
        private string JenisPaspor;
        DataModel data;
        private Button BtnHapus;

        //private Button btnClose;
        //private Button button2;

        // Helper control to get around .NET 2.0 threadsafe control problem
        private Control _threadHelperControl;

		public MainForm(string[] args)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            exeFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            InitTempDirectory(exeFolderPath);

            Thread t = new Thread(new ThreadStart(StartServer));
            t.Start();
            // Get all network interfaces on the system
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            string serverUrl = null;

            foreach (NetworkInterface networkInterface in interfaces)
            {
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                    UnicastIPAddressInformationCollection ipAddresses = ipProperties.UnicastAddresses;

                    foreach (UnicastIPAddressInformation ipAddress in ipAddresses)
                    {
                        if (ipAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                            !ipAddress.Address.IsIPv6LinkLocal &&
                            !ipAddress.Address.IsIPv6Multicast &&
                            !ipAddress.Address.IsIPv6SiteLocal &&
                            !IPAddress.IsLoopback(ipAddress.Address))
                        {
                            Console.WriteLine("Local IP Address: " + ipAddress.Address);
                            serverUrl = $"http://{ipAddress.Address}:4477/";
                            break; // Found a suitable IP address, exit the loop
                        }
                    }

                    if (serverUrl != null)
                    {
                        break; // Found a suitable IP address, exit the outer loop
                    }
                }
            }

            if (serverUrl != null)
            {
                Console.WriteLine($"Starting WebSocket server at: {serverUrl}");
                StartWebSocketServer("http://localhost:4477/", args);
            }
            else
            {
                Console.WriteLine("No suitable IP address found.");
            }


            // Initialize helper control to get around .NET 2.0 threadsafe control problem
            _threadHelperControl = new Control();
            _threadHelperControl.CreateControl();
        }
        public void ProsesData(DataModel data)
        {
            Console.WriteLine("Data Proses ", data);

           namaPemohon = data.NamaLengkap;
            noPermohonan = data.NomorPermohonan;
            tglLahir = data.TanggalLahir;
            noPassport = data.NomorPaspor;

            string Jpaspor = data.JenisPaspor;

            if (Jpaspor.Contains("ELEKTRONIK"))
            {
                tipe = "ELEKTRONIK";
            }else
            {
                tipe = "BIASA";
            }


            //BIASA, ELEKTRONIK, POLICARBONAT KALAU POLI sama dengan ELEKTRONIK
            if (tipe == "ELEKTRONIK")
            {
                isEpaspor = true;
            }

           

            if (String.IsNullOrEmpty(noPermohonan))
            {
                noPermohonan = "-";
            }

            if (String.IsNullOrEmpty(namaPemohon))
            {
                namaPemohon = "-";
            }

            if (String.IsNullOrEmpty(tglLahir))
            {
                tglLahir = "-";
            }

            if (String.IsNullOrEmpty(userId))
            {
                userId = "-";
            }

            if (String.IsNullOrEmpty(noPassport))
            {
                noPassport = "-";
            }

            if (String.IsNullOrEmpty(idUji))
            {
                idUji = "-";
            }

            if (String.IsNullOrEmpty(idAlokasi))
            {
                idAlokasi = "-";
            }



            tbNoPermohonan.Text = noPermohonan;
            tbNamaPemohon.Text = namaPemohon;
            tbTglLahir.Text = tglLahir;
            tbNoPassport.Text = noPassport;

            testId.id = idUji;
            http.token = iauth;

            SetFileNames(tbNoPermohonan.Text);

            Version version = Assembly.GetEntryAssembly().GetName().Version;

            if (isEpaspor)
            {
                this.Text = "Electronic Passport Scanner";
                if (!GetCertsFromNetwork())
                {
                    this.Close();
                }
            }
            else
            {
                this.Text = "Passport Scanner";
            }
            this.Text = this.Text + " - " + version.ToString();

            // Initialize helper control to get around .NET 2.0 threadsafe control problem
            _threadHelperControl = new Control();
            _threadHelperControl.CreateControl();
            Initialise();

            // Initialize helper control to get around .NET 2.0 threadsafe control problem

        }

        private void SetFileNames(string noPermohonan)
        {
            pasporName = noPermohonan + "_" + noPassport + "_" + pasporName;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenu = new System.Windows.Forms.MenuItem();
            this.FileExit = new System.Windows.Forms.MenuItem();
            this.StateMenu = new System.Windows.Forms.MenuItem();
            this.StateEnabled = new System.Windows.Forms.MenuItem();
            this.StateDisabled = new System.Windows.Forms.MenuItem();
            this.StateAsleep = new System.Windows.Forms.MenuItem();
            this.StateSuspend = new System.Windows.Forms.MenuItem();
            this.SettingsMenu = new System.Windows.Forms.MenuItem();
            this.SettingsLogging = new System.Windows.Forms.MenuItem();
            this.LoggingOff = new System.Windows.Forms.MenuItem();
            this.LoggingErrorsOnly = new System.Windows.Forms.MenuItem();
            this.LoggingLowDetail = new System.Windows.Forms.MenuItem();
            this.LoggingMediumDetail = new System.Windows.Forms.MenuItem();
            this.LoggingHighDetail = new System.Windows.Forms.MenuItem();
            this.LoggingHighestDetail = new System.Windows.Forms.MenuItem();
            this.SettingsDataToSend = new System.Windows.Forms.MenuItem();
            this.SettingsRFID = new System.Windows.Forms.MenuItem();
            this.SettingsSaveLastImage = new System.Windows.Forms.MenuItem();
            this.SettingsSeperator = new System.Windows.Forms.MenuItem();
            this.SettingsSave = new System.Windows.Forms.MenuItem();
            this.WriteSettingsTextfile = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.StatePanel = new System.Windows.Forms.StatusBarPanel();
            this.TimePanel = new System.Windows.Forms.StatusBarPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimingsTab = new System.Windows.Forms.TabPage();
            this.TimingsList = new System.Windows.Forms.ListView();
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MessageSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UHFTab = new System.Windows.Forms.TabPage();
            this.EPCGroupBox = new System.Windows.Forms.GroupBox();
            this.EPCField = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SerialNumberValue = new System.Windows.Forms.Label();
            this.SerialNumberLabel = new System.Windows.Forms.Label();
            this.ModelNumberValue = new System.Windows.Forms.Label();
            this.ModelNumberLabel = new System.Windows.Forms.Label();
            this.MaskDesignerIDValue = new System.Windows.Forms.Label();
            this.MaskDesignerIDLabel = new System.Windows.Forms.Label();
            this.ManufacturerIDValue = new System.Windows.Forms.Label();
            this.ManufacturerIDLabel = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataFileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.validatedList = new System.Windows.Forms.ListView();
            this.dataItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.validated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPAStatus = new System.Windows.Forms.Label();
            this.lblTAStatus = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.lblCAStatus = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.lblAAStatus = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.lblSACStatus = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.lblBACStatus = new System.Windows.Forms.Label();
            this.lblChipId = new System.Windows.Forms.Label();
            this.lblAirBaudRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbPhotoAndMRTD = new System.Windows.Forms.GroupBox();
            this.lblRFIssuingState = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.lblRFDocNumber = new System.Windows.Forms.Label();
            this.lblRFDateOfBirth = new System.Windows.Forms.Label();
            this.lblRFSex = new System.Windows.Forms.Label();
            this.lblRFNationality = new System.Windows.Forms.Label();
            this.lblRFForenames = new System.Windows.Forms.Label();
            this.lblRFSurname = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblRFCodeline = new System.Windows.Forms.Label();
            this.rfImage = new System.Windows.Forms.PictureBox();
            this.ImagesTab = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbPassport = new System.Windows.Forms.GroupBox();
            this.visibleImage = new System.Windows.Forms.PictureBox();
            this.btnZoomIr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblChecksum = new System.Windows.Forms.Label();
            this.lblSecurityCheck = new System.Windows.Forms.Label();
            this.lblIssuingState = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.richTextBoxCodeline = new System.Windows.Forms.RichTextBox();
            this.lblDocumentType = new System.Windows.Forms.Label();
            this.lblDocumentNumber = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblForenames = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.photoImage = new System.Windows.Forms.PictureBox();
            this.btnZoomUv = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uvImage = new System.Windows.Forms.PictureBox();
            this.irImage = new System.Windows.Forms.PictureBox();
            this.btnZoomVis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbEPassport = new System.Windows.Forms.GroupBox();
            this.gbJari = new System.Windows.Forms.GroupBox();
            this.btnZoomFinger2 = new System.Windows.Forms.Button();
            this.btnZoomFinger1 = new System.Windows.Forms.Button();
            this.lblFinger2Type = new System.Windows.Forms.Label();
            this.lblFinger1Type = new System.Windows.Forms.Label();
            this.pbFinger2 = new System.Windows.Forms.PictureBox();
            this.pbFinger1 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ImagesRearTab = new System.Windows.Forms.TabPage();
            this.label92 = new System.Windows.Forms.Label();
            this.irImageRear = new System.Windows.Forms.PictureBox();
            this.visibleImageRear = new System.Windows.Forms.PictureBox();
            this.label93 = new System.Windows.Forms.Label();
            this.uvImageRear = new System.Windows.Forms.PictureBox();
            this.label94 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label32 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label33 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label76 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label77 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label78 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tbNoPassport = new System.Windows.Forms.TextBox();
            this.tbTglLahir = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.tbNamaPemohon = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.tbNoPermohonan = new System.Windows.Forms.TextBox();
            this.btnSerahkan = new System.Windows.Forms.Button();
            this.btnCetakUlang = new System.Windows.Forms.Button();
            this.tbHasilUji = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label99 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.BtnHapus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.StatePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePanel)).BeginInit();
            this.TimingsTab.SuspendLayout();
            this.UHFTab.SuspendLayout();
            this.EPCGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPhotoAndMRTD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rfImage)).BeginInit();
            this.ImagesTab.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbPassport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibleImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.irImage)).BeginInit();
            this.gbEPassport.SuspendLayout();
            this.gbJari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.ImagesRearTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.irImageRear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibleImageRear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvImageRear)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenu,
            this.StateMenu,
            this.SettingsMenu});
            // 
            // FileMenu
            // 
            this.FileMenu.Index = 0;
            this.FileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileExit});
            this.FileMenu.Text = "File";
            this.FileMenu.Visible = false;
            // 
            // FileExit
            // 
            this.FileExit.Index = 0;
            this.FileExit.Text = "E&xit";
            this.FileExit.Click += new System.EventHandler(this.fileExit_Click);
            // 
            // StateMenu
            // 
            this.StateMenu.Index = 1;
            this.StateMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.StateEnabled,
            this.StateDisabled,
            this.StateAsleep,
            this.StateSuspend});
            this.StateMenu.Text = "State";
            this.StateMenu.Visible = false;
            // 
            // StateEnabled
            // 
            this.StateEnabled.Index = 0;
            this.StateEnabled.Text = "&Enabled";
            this.StateEnabled.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // StateDisabled
            // 
            this.StateDisabled.Index = 1;
            this.StateDisabled.Text = "&Disabled";
            this.StateDisabled.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // StateAsleep
            // 
            this.StateAsleep.Index = 2;
            this.StateAsleep.Text = "&Asleep";
            this.StateAsleep.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // StateSuspend
            // 
            this.StateSuspend.Index = 3;
            this.StateSuspend.Text = "Suspend";
            this.StateSuspend.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.Index = 2;
            this.SettingsMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SettingsLogging,
            this.SettingsDataToSend,
            this.SettingsRFID,
            this.SettingsSaveLastImage,
            this.SettingsSeperator,
            this.SettingsSave,
            this.WriteSettingsTextfile});
            this.SettingsMenu.Text = "Settings";
            this.SettingsMenu.Visible = false;
            // 
            // SettingsLogging
            // 
            this.SettingsLogging.Index = 0;
            this.SettingsLogging.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.LoggingOff,
            this.LoggingErrorsOnly,
            this.LoggingLowDetail,
            this.LoggingMediumDetail,
            this.LoggingHighDetail,
            this.LoggingHighestDetail});
            this.SettingsLogging.Text = "&Logging";
            // 
            // LoggingOff
            // 
            this.LoggingOff.Index = 0;
            this.LoggingOff.Shortcut = System.Windows.Forms.Shortcut.Alt0;
            this.LoggingOff.Text = "Off";
            // 
            // LoggingErrorsOnly
            // 
            this.LoggingErrorsOnly.Index = 1;
            this.LoggingErrorsOnly.Shortcut = System.Windows.Forms.Shortcut.Alt1;
            this.LoggingErrorsOnly.Text = "Errors Only";
            // 
            // LoggingLowDetail
            // 
            this.LoggingLowDetail.Index = 2;
            this.LoggingLowDetail.Shortcut = System.Windows.Forms.Shortcut.Alt2;
            this.LoggingLowDetail.Text = "Low Detail";
            // 
            // LoggingMediumDetail
            // 
            this.LoggingMediumDetail.Index = 3;
            this.LoggingMediumDetail.Shortcut = System.Windows.Forms.Shortcut.Alt3;
            this.LoggingMediumDetail.Text = "Medium Detail";
            // 
            // LoggingHighDetail
            // 
            this.LoggingHighDetail.Index = 4;
            this.LoggingHighDetail.Shortcut = System.Windows.Forms.Shortcut.Alt4;
            this.LoggingHighDetail.Text = "High Detail";
            // 
            // LoggingHighestDetail
            // 
            this.LoggingHighestDetail.Index = 5;
            this.LoggingHighestDetail.Shortcut = System.Windows.Forms.Shortcut.Alt5;
            this.LoggingHighestDetail.Text = "Highest Detail";
            // 
            // SettingsDataToSend
            // 
            this.SettingsDataToSend.Index = 1;
            this.SettingsDataToSend.Text = "&Data To Send";
            this.SettingsDataToSend.Click += new System.EventHandler(this.SettingsDataToSend_Click);
            // 
            // SettingsRFID
            // 
            this.SettingsRFID.Index = 2;
            this.SettingsRFID.Text = "RFID Settings";
            // 
            // SettingsSaveLastImage
            // 
            this.SettingsSaveLastImage.Index = 3;
            this.SettingsSaveLastImage.Text = "Save &Last Image";
            // 
            // SettingsSeperator
            // 
            this.SettingsSeperator.Index = 4;
            this.SettingsSeperator.Text = "-";
            // 
            // SettingsSave
            // 
            this.SettingsSave.Index = 5;
            this.SettingsSave.Text = "Save Settings";
            this.SettingsSave.Click += new System.EventHandler(this.SettingsSave_Click);
            // 
            // WriteSettingsTextfile
            // 
            this.WriteSettingsTextfile.Index = 6;
            this.WriteSettingsTextfile.Text = "Write Settings Textfile";
            this.WriteSettingsTextfile.Click += new System.EventHandler(this.WriteSettingsTextfile_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 706);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.StatePanel,
            this.TimePanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(1284, 22);
            this.statusBar.TabIndex = 33;
            this.statusBar.Text = "statusBar";
            // 
            // StatePanel
            // 
            this.StatePanel.Name = "StatePanel";
            this.StatePanel.Text = "State:";
            this.StatePanel.Width = 250;
            // 
            // TimePanel
            // 
            this.TimePanel.Name = "TimePanel";
            this.TimePanel.Text = "Time:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.InitialiseTimer);
            // 
            // TimingsTab
            // 
            this.TimingsTab.Controls.Add(this.TimingsList);
            this.TimingsTab.Location = new System.Drawing.Point(4, 22);
            this.TimingsTab.Name = "TimingsTab";
            this.TimingsTab.Padding = new System.Windows.Forms.Padding(20);
            this.TimingsTab.Size = new System.Drawing.Size(626, 492);
            this.TimingsTab.TabIndex = 2;
            this.TimingsTab.Text = "Timings";
            this.TimingsTab.UseVisualStyleBackColor = true;
            // 
            // TimingsList
            // 
            this.TimingsList.AllowColumnReorder = true;
            this.TimingsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Time,
            this.MessageName,
            this.MessageSize,
            this.Data});
            this.TimingsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimingsList.FullRowSelect = true;
            this.TimingsList.HideSelection = false;
            this.TimingsList.Location = new System.Drawing.Point(20, 20);
            this.TimingsList.Name = "TimingsList";
            this.TimingsList.Size = new System.Drawing.Size(586, 452);
            this.TimingsList.TabIndex = 1;
            this.TimingsList.UseCompatibleStateImageBehavior = false;
            this.TimingsList.View = System.Windows.Forms.View.Details;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 78;
            // 
            // MessageName
            // 
            this.MessageName.Text = "Message Name";
            this.MessageName.Width = 156;
            // 
            // MessageSize
            // 
            this.MessageSize.Text = "Size";
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.Width = 353;
            // 
            // UHFTab
            // 
            this.UHFTab.Controls.Add(this.EPCGroupBox);
            this.UHFTab.Controls.Add(this.groupBox4);
            this.UHFTab.Location = new System.Drawing.Point(4, 22);
            this.UHFTab.Name = "UHFTab";
            this.UHFTab.Size = new System.Drawing.Size(626, 492);
            this.UHFTab.TabIndex = 3;
            this.UHFTab.Text = "UHF";
            this.UHFTab.UseVisualStyleBackColor = true;
            // 
            // EPCGroupBox
            // 
            this.EPCGroupBox.Controls.Add(this.EPCField);
            this.EPCGroupBox.Location = new System.Drawing.Point(15, 104);
            this.EPCGroupBox.Name = "EPCGroupBox";
            this.EPCGroupBox.Size = new System.Drawing.Size(773, 51);
            this.EPCGroupBox.TabIndex = 1;
            this.EPCGroupBox.TabStop = false;
            this.EPCGroupBox.Text = "EPC";
            // 
            // EPCField
            // 
            this.EPCField.AutoSize = true;
            this.EPCField.Location = new System.Drawing.Point(17, 25);
            this.EPCField.Name = "EPCField";
            this.EPCField.Size = new System.Drawing.Size(0, 13);
            this.EPCField.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SerialNumberValue);
            this.groupBox4.Controls.Add(this.SerialNumberLabel);
            this.groupBox4.Controls.Add(this.ModelNumberValue);
            this.groupBox4.Controls.Add(this.ModelNumberLabel);
            this.groupBox4.Controls.Add(this.MaskDesignerIDValue);
            this.groupBox4.Controls.Add(this.MaskDesignerIDLabel);
            this.groupBox4.Controls.Add(this.ManufacturerIDValue);
            this.groupBox4.Controls.Add(this.ManufacturerIDLabel);
            this.groupBox4.Location = new System.Drawing.Point(15, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(773, 75);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tag ID";
            // 
            // SerialNumberValue
            // 
            this.SerialNumberValue.AutoSize = true;
            this.SerialNumberValue.Location = new System.Drawing.Point(151, 55);
            this.SerialNumberValue.Name = "SerialNumberValue";
            this.SerialNumberValue.Size = new System.Drawing.Size(0, 13);
            this.SerialNumberValue.TabIndex = 8;
            // 
            // SerialNumberLabel
            // 
            this.SerialNumberLabel.AutoSize = true;
            this.SerialNumberLabel.Location = new System.Drawing.Point(17, 55);
            this.SerialNumberLabel.Name = "SerialNumberLabel";
            this.SerialNumberLabel.Size = new System.Drawing.Size(79, 13);
            this.SerialNumberLabel.TabIndex = 7;
            this.SerialNumberLabel.Text = "Serial Number: ";
            // 
            // ModelNumberValue
            // 
            this.ModelNumberValue.AutoSize = true;
            this.ModelNumberValue.Location = new System.Drawing.Point(151, 42);
            this.ModelNumberValue.Name = "ModelNumberValue";
            this.ModelNumberValue.Size = new System.Drawing.Size(0, 13);
            this.ModelNumberValue.TabIndex = 6;
            // 
            // ModelNumberLabel
            // 
            this.ModelNumberLabel.AutoSize = true;
            this.ModelNumberLabel.Location = new System.Drawing.Point(17, 42);
            this.ModelNumberLabel.Name = "ModelNumberLabel";
            this.ModelNumberLabel.Size = new System.Drawing.Size(82, 13);
            this.ModelNumberLabel.TabIndex = 5;
            this.ModelNumberLabel.Text = "Model Number: ";
            // 
            // MaskDesignerIDValue
            // 
            this.MaskDesignerIDValue.AutoSize = true;
            this.MaskDesignerIDValue.Location = new System.Drawing.Point(151, 29);
            this.MaskDesignerIDValue.Name = "MaskDesignerIDValue";
            this.MaskDesignerIDValue.Size = new System.Drawing.Size(0, 13);
            this.MaskDesignerIDValue.TabIndex = 4;
            // 
            // MaskDesignerIDLabel
            // 
            this.MaskDesignerIDLabel.AutoSize = true;
            this.MaskDesignerIDLabel.Location = new System.Drawing.Point(17, 29);
            this.MaskDesignerIDLabel.Name = "MaskDesignerIDLabel";
            this.MaskDesignerIDLabel.Size = new System.Drawing.Size(98, 13);
            this.MaskDesignerIDLabel.TabIndex = 3;
            this.MaskDesignerIDLabel.Text = "Mask Designer ID: ";
            // 
            // ManufacturerIDValue
            // 
            this.ManufacturerIDValue.AutoSize = true;
            this.ManufacturerIDValue.Location = new System.Drawing.Point(151, 16);
            this.ManufacturerIDValue.Name = "ManufacturerIDValue";
            this.ManufacturerIDValue.Size = new System.Drawing.Size(0, 13);
            this.ManufacturerIDValue.TabIndex = 2;
            // 
            // ManufacturerIDLabel
            // 
            this.ManufacturerIDLabel.AutoSize = true;
            this.ManufacturerIDLabel.Location = new System.Drawing.Point(17, 16);
            this.ManufacturerIDLabel.Name = "ManufacturerIDLabel";
            this.ManufacturerIDLabel.Size = new System.Drawing.Size(90, 13);
            this.ManufacturerIDLabel.TabIndex = 1;
            this.ManufacturerIDLabel.Text = "Manufacturer ID: ";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(626, 492);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "RFID";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataFileList
            // 
            this.dataFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.dataFileList.HideSelection = false;
            this.dataFileList.Location = new System.Drawing.Point(1188, 9);
            this.dataFileList.Name = "dataFileList";
            this.dataFileList.Size = new System.Drawing.Size(55, 20);
            this.dataFileList.TabIndex = 35;
            this.dataFileList.UseCompatibleStateImageBehavior = false;
            this.dataFileList.View = System.Windows.Forms.View.Details;
            this.dataFileList.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data Item";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data Size";
            this.columnHeader2.Width = 159;
            // 
            // validatedList
            // 
            this.validatedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dataItem,
            this.validated});
            this.validatedList.HideSelection = false;
            this.validatedList.Location = new System.Drawing.Point(327, 253);
            this.validatedList.Name = "validatedList";
            this.validatedList.Size = new System.Drawing.Size(310, 222);
            this.validatedList.TabIndex = 34;
            this.validatedList.UseCompatibleStateImageBehavior = false;
            this.validatedList.View = System.Windows.Forms.View.Details;
            // 
            // dataItem
            // 
            this.dataItem.Text = "Data Item";
            this.dataItem.Width = 147;
            // 
            // validated
            // 
            this.validated.Text = "Validated";
            this.validated.Width = 159;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lblPAStatus);
            this.groupBox3.Controls.Add(this.lblTAStatus);
            this.groupBox3.Controls.Add(this.label98);
            this.groupBox3.Controls.Add(this.lblCAStatus);
            this.groupBox3.Controls.Add(this.label96);
            this.groupBox3.Controls.Add(this.lblAAStatus);
            this.groupBox3.Controls.Add(this.label91);
            this.groupBox3.Controls.Add(this.lblSACStatus);
            this.groupBox3.Controls.Add(this.label80);
            this.groupBox3.Location = new System.Drawing.Point(6, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 228);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(6, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "PA Status:";
            // 
            // lblPAStatus
            // 
            this.lblPAStatus.Location = new System.Drawing.Point(84, 56);
            this.lblPAStatus.Name = "lblPAStatus";
            this.lblPAStatus.Size = new System.Drawing.Size(165, 16);
            this.lblPAStatus.TabIndex = 14;
            // 
            // lblTAStatus
            // 
            this.lblTAStatus.Location = new System.Drawing.Point(84, 125);
            this.lblTAStatus.Name = "lblTAStatus";
            this.lblTAStatus.Size = new System.Drawing.Size(165, 16);
            this.lblTAStatus.TabIndex = 13;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.Transparent;
            this.label98.Location = new System.Drawing.Point(6, 125);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(100, 16);
            this.label98.TabIndex = 12;
            this.label98.Text = "TA Status:";
            // 
            // lblCAStatus
            // 
            this.lblCAStatus.Location = new System.Drawing.Point(84, 89);
            this.lblCAStatus.Name = "lblCAStatus";
            this.lblCAStatus.Size = new System.Drawing.Size(165, 16);
            this.lblCAStatus.TabIndex = 11;
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.Transparent;
            this.label96.Location = new System.Drawing.Point(6, 89);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(100, 16);
            this.label96.TabIndex = 10;
            this.label96.Text = "CA Status:";
            // 
            // lblAAStatus
            // 
            this.lblAAStatus.Location = new System.Drawing.Point(84, 23);
            this.lblAAStatus.Name = "lblAAStatus";
            this.lblAAStatus.Size = new System.Drawing.Size(165, 16);
            this.lblAAStatus.TabIndex = 9;
            // 
            // label91
            // 
            this.label91.BackColor = System.Drawing.Color.Transparent;
            this.label91.Location = new System.Drawing.Point(6, 23);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(100, 16);
            this.label91.TabIndex = 8;
            this.label91.Text = "AA Status:";
            // 
            // lblSACStatus
            // 
            this.lblSACStatus.Location = new System.Drawing.Point(84, 161);
            this.lblSACStatus.Name = "lblSACStatus";
            this.lblSACStatus.Size = new System.Drawing.Size(165, 16);
            this.lblSACStatus.TabIndex = 7;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Location = new System.Drawing.Point(6, 161);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(100, 16);
            this.label80.TabIndex = 6;
            this.label80.Text = "SAC Status:";
            // 
            // lblBACStatus
            // 
            this.lblBACStatus.Location = new System.Drawing.Point(1257, 37);
            this.lblBACStatus.Name = "lblBACStatus";
            this.lblBACStatus.Size = new System.Drawing.Size(165, 16);
            this.lblBACStatus.TabIndex = 5;
            this.lblBACStatus.Visible = false;
            // 
            // lblChipId
            // 
            this.lblChipId.Location = new System.Drawing.Point(1257, 80);
            this.lblChipId.Name = "lblChipId";
            this.lblChipId.Size = new System.Drawing.Size(165, 16);
            this.lblChipId.TabIndex = 4;
            this.lblChipId.Visible = false;
            // 
            // lblAirBaudRate
            // 
            this.lblAirBaudRate.Location = new System.Drawing.Point(1257, 59);
            this.lblAirBaudRate.Name = "lblAirBaudRate";
            this.lblAirBaudRate.Size = new System.Drawing.Size(165, 16);
            this.lblAirBaudRate.TabIndex = 3;
            this.lblAirBaudRate.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(1179, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "BAC Status:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(1179, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Chip id:";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(1179, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Air Baud Rate:";
            this.label4.Visible = false;
            // 
            // gbPhotoAndMRTD
            // 
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFIssuingState);
            this.gbPhotoAndMRTD.Controls.Add(this.label85);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFDocNumber);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFDateOfBirth);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFSex);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFNationality);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFForenames);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFSurname);
            this.gbPhotoAndMRTD.Controls.Add(this.label20);
            this.gbPhotoAndMRTD.Controls.Add(this.label21);
            this.gbPhotoAndMRTD.Controls.Add(this.label22);
            this.gbPhotoAndMRTD.Controls.Add(this.label23);
            this.gbPhotoAndMRTD.Controls.Add(this.label13);
            this.gbPhotoAndMRTD.Controls.Add(this.lblRFCodeline);
            this.gbPhotoAndMRTD.Controls.Add(this.rfImage);
            this.gbPhotoAndMRTD.Location = new System.Drawing.Point(6, 17);
            this.gbPhotoAndMRTD.Name = "gbPhotoAndMRTD";
            this.gbPhotoAndMRTD.Size = new System.Drawing.Size(352, 219);
            this.gbPhotoAndMRTD.TabIndex = 32;
            this.gbPhotoAndMRTD.TabStop = false;
            this.gbPhotoAndMRTD.Text = "Foto dan MRTD";
            // 
            // lblRFIssuingState
            // 
            this.lblRFIssuingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFIssuingState.Location = new System.Drawing.Point(218, 80);
            this.lblRFIssuingState.Name = "lblRFIssuingState";
            this.lblRFIssuingState.Size = new System.Drawing.Size(97, 16);
            this.lblRFIssuingState.TabIndex = 34;
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(128, 80);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(95, 16);
            this.label85.TabIndex = 33;
            this.label85.Text = "Negara Penerbit:";
            // 
            // lblRFDocNumber
            // 
            this.lblRFDocNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFDocNumber.Location = new System.Drawing.Point(202, 128);
            this.lblRFDocNumber.Name = "lblRFDocNumber";
            this.lblRFDocNumber.Size = new System.Drawing.Size(134, 16);
            this.lblRFDocNumber.TabIndex = 32;
            // 
            // lblRFDateOfBirth
            // 
            this.lblRFDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFDateOfBirth.Location = new System.Drawing.Point(185, 112);
            this.lblRFDateOfBirth.Name = "lblRFDateOfBirth";
            this.lblRFDateOfBirth.Size = new System.Drawing.Size(134, 16);
            this.lblRFDateOfBirth.TabIndex = 31;
            // 
            // lblRFSex
            // 
            this.lblRFSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFSex.Location = new System.Drawing.Point(208, 96);
            this.lblRFSex.Name = "lblRFSex";
            this.lblRFSex.Size = new System.Drawing.Size(107, 16);
            this.lblRFSex.TabIndex = 30;
            // 
            // lblRFNationality
            // 
            this.lblRFNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFNationality.Location = new System.Drawing.Point(229, 64);
            this.lblRFNationality.Name = "lblRFNationality";
            this.lblRFNationality.Size = new System.Drawing.Size(107, 16);
            this.lblRFNationality.TabIndex = 29;
            // 
            // lblRFForenames
            // 
            this.lblRFForenames.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFForenames.Location = new System.Drawing.Point(165, 32);
            this.lblRFForenames.Name = "lblRFForenames";
            this.lblRFForenames.Size = new System.Drawing.Size(174, 16);
            this.lblRFForenames.TabIndex = 28;
            // 
            // lblRFSurname
            // 
            this.lblRFSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFSurname.Location = new System.Drawing.Point(165, 48);
            this.lblRFSurname.Name = "lblRFSurname";
            this.lblRFSurname.Size = new System.Drawing.Size(174, 16);
            this.lblRFSurname.TabIndex = 27;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(128, 128);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 16);
            this.label20.TabIndex = 26;
            this.label20.Text = "No. Passport:";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(128, 112);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(84, 16);
            this.label21.TabIndex = 25;
            this.label21.Text = "Tgl. Lahir:";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(128, 96);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 16);
            this.label22.TabIndex = 24;
            this.label22.Text = "Jenis Kelamin:";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(128, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(104, 16);
            this.label23.TabIndex = 23;
            this.label23.Text = "Kewarganegaraan:";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(128, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 11;
            this.label13.Text = "Nama:";
            // 
            // lblRFCodeline
            // 
            this.lblRFCodeline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRFCodeline.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFCodeline.Location = new System.Drawing.Point(19, 162);
            this.lblRFCodeline.Name = "lblRFCodeline";
            this.lblRFCodeline.Size = new System.Drawing.Size(320, 43);
            this.lblRFCodeline.TabIndex = 3;
            // 
            // rfImage
            // 
            this.rfImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rfImage.Location = new System.Drawing.Point(19, 22);
            this.rfImage.Name = "rfImage";
            this.rfImage.Size = new System.Drawing.Size(104, 132);
            this.rfImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rfImage.TabIndex = 9;
            this.rfImage.TabStop = false;
            // 
            // ImagesTab
            // 
            this.ImagesTab.BackColor = System.Drawing.SystemColors.Control;
            this.ImagesTab.Controls.Add(this.flowLayoutPanel1);
            this.ImagesTab.Location = new System.Drawing.Point(4, 22);
            this.ImagesTab.Name = "ImagesTab";
            this.ImagesTab.Size = new System.Drawing.Size(1268, 492);
            this.ImagesTab.TabIndex = 0;
            this.ImagesTab.Text = "Images";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.gbPassport);
            this.flowLayoutPanel1.Controls.Add(this.gbEPassport);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1254, 489);
            this.flowLayoutPanel1.TabIndex = 37;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // gbPassport
            // 
            this.gbPassport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPassport.Controls.Add(this.visibleImage);
            this.gbPassport.Controls.Add(this.btnZoomIr);
            this.gbPassport.Controls.Add(this.label2);
            this.gbPassport.Controls.Add(this.groupBox1);
            this.gbPassport.Controls.Add(this.btnZoomUv);
            this.gbPassport.Controls.Add(this.label5);
            this.gbPassport.Controls.Add(this.uvImage);
            this.gbPassport.Controls.Add(this.irImage);
            this.gbPassport.Controls.Add(this.btnZoomVis);
            this.gbPassport.Controls.Add(this.label1);
            this.gbPassport.Location = new System.Drawing.Point(3, 3);
            this.gbPassport.Name = "gbPassport";
            this.gbPassport.Size = new System.Drawing.Size(694, 481);
            this.gbPassport.TabIndex = 35;
            this.gbPassport.TabStop = false;
            this.gbPassport.Text = "Passport";
            // 
            // visibleImage
            // 
            this.visibleImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.visibleImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.visibleImage.Location = new System.Drawing.Point(363, 37);
            this.visibleImage.Name = "visibleImage";
            this.visibleImage.Size = new System.Drawing.Size(325, 205);
            this.visibleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.visibleImage.TabIndex = 20;
            this.visibleImage.TabStop = false;
            // 
            // btnZoomIr
            // 
            this.btnZoomIr.Location = new System.Drawing.Point(47, 244);
            this.btnZoomIr.Name = "btnZoomIr";
            this.btnZoomIr.Size = new System.Drawing.Size(42, 23);
            this.btnZoomIr.TabIndex = 34;
            this.btnZoomIr.Text = "Zoom";
            this.btnZoomIr.UseVisualStyleBackColor = true;
            this.btnZoomIr.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(367, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "UV:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblChecksum);
            this.groupBox1.Controls.Add(this.lblSecurityCheck);
            this.groupBox1.Controls.Add(this.lblIssuingState);
            this.groupBox1.Controls.Add(this.label83);
            this.groupBox1.Controls.Add(this.richTextBoxCodeline);
            this.groupBox1.Controls.Add(this.lblDocumentType);
            this.groupBox1.Controls.Add(this.lblDocumentNumber);
            this.groupBox1.Controls.Add(this.lblDateOfBirth);
            this.groupBox1.Controls.Add(this.lblSex);
            this.groupBox1.Controls.Add(this.lblNationality);
            this.groupBox1.Controls.Add(this.lblForenames);
            this.groupBox1.Controls.Add(this.lblSurname);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.photoImage);
            this.groupBox1.Location = new System.Drawing.Point(7, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 221);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Foto dan MRTD";
            // 
            // lblChecksum
            // 
            this.lblChecksum.AutoSize = true;
            this.lblChecksum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChecksum.Location = new System.Drawing.Point(240, 18);
            this.lblChecksum.Name = "lblChecksum";
            this.lblChecksum.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.lblChecksum.Size = new System.Drawing.Size(59, 19);
            this.lblChecksum.TabIndex = 37;
            this.lblChecksum.Text = "Checksum";
            // 
            // lblSecurityCheck
            // 
            this.lblSecurityCheck.AutoSize = true;
            this.lblSecurityCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSecurityCheck.Location = new System.Drawing.Point(133, 18);
            this.lblSecurityCheck.Name = "lblSecurityCheck";
            this.lblSecurityCheck.Padding = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.lblSecurityCheck.Size = new System.Drawing.Size(101, 19);
            this.lblSecurityCheck.TabIndex = 36;
            this.lblSecurityCheck.Text = "Security Check";
            // 
            // lblIssuingState
            // 
            this.lblIssuingState.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuingState.Location = new System.Drawing.Point(219, 90);
            this.lblIssuingState.Name = "lblIssuingState";
            this.lblIssuingState.Size = new System.Drawing.Size(98, 16);
            this.lblIssuingState.TabIndex = 35;
            // 
            // label83
            // 
            this.label83.Location = new System.Drawing.Point(129, 90);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(104, 16);
            this.label83.TabIndex = 34;
            this.label83.Text = "Negara Penerbit:";
            // 
            // richTextBoxCodeline
            // 
            this.richTextBoxCodeline.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxCodeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxCodeline.Enabled = false;
            this.richTextBoxCodeline.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxCodeline.Location = new System.Drawing.Point(13, 175);
            this.richTextBoxCodeline.Name = "richTextBoxCodeline";
            this.richTextBoxCodeline.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxCodeline.Size = new System.Drawing.Size(320, 40);
            this.richTextBoxCodeline.TabIndex = 33;
            this.richTextBoxCodeline.Text = "";
            // 
            // lblDocumentType
            // 
            this.lblDocumentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentType.Location = new System.Drawing.Point(10, 16);
            this.lblDocumentType.Name = "lblDocumentType";
            this.lblDocumentType.Size = new System.Drawing.Size(103, 21);
            this.lblDocumentType.TabIndex = 22;
            // 
            // lblDocumentNumber
            // 
            this.lblDocumentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNumber.Location = new System.Drawing.Point(202, 138);
            this.lblDocumentNumber.Name = "lblDocumentNumber";
            this.lblDocumentNumber.Size = new System.Drawing.Size(135, 16);
            this.lblDocumentNumber.TabIndex = 21;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(189, 122);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(135, 16);
            this.lblDateOfBirth.TabIndex = 20;
            // 
            // lblSex
            // 
            this.lblSex.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(208, 106);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(53, 16);
            this.lblSex.TabIndex = 19;
            // 
            // lblNationality
            // 
            this.lblNationality.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(228, 76);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(98, 16);
            this.lblNationality.TabIndex = 18;
            // 
            // lblForenames
            // 
            this.lblForenames.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForenames.Location = new System.Drawing.Point(169, 44);
            this.lblForenames.Name = "lblForenames";
            this.lblForenames.Size = new System.Drawing.Size(168, 16);
            this.lblForenames.TabIndex = 17;
            // 
            // lblSurname
            // 
            this.lblSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(169, 60);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(168, 16);
            this.lblSurname.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(129, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "No. Passport:";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(129, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "Tgl. Lahir:";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(129, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "Jenis Kelamin:";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(129, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Kewarganegaraan:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(129, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nama:";
            // 
            // photoImage
            // 
            this.photoImage.Location = new System.Drawing.Point(13, 40);
            this.photoImage.Name = "photoImage";
            this.photoImage.Size = new System.Drawing.Size(100, 129);
            this.photoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoImage.TabIndex = 9;
            this.photoImage.TabStop = false;
            // 
            // btnZoomUv
            // 
            this.btnZoomUv.Location = new System.Drawing.Point(403, 242);
            this.btnZoomUv.Name = "btnZoomUv";
            this.btnZoomUv.Size = new System.Drawing.Size(42, 23);
            this.btnZoomUv.TabIndex = 33;
            this.btnZoomUv.Text = "Zoom";
            this.btnZoomUv.UseVisualStyleBackColor = true;
            this.btnZoomUv.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "IR:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uvImage
            // 
            this.uvImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uvImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uvImage.Location = new System.Drawing.Point(364, 271);
            this.uvImage.Name = "uvImage";
            this.uvImage.Size = new System.Drawing.Size(325, 205);
            this.uvImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uvImage.TabIndex = 21;
            this.uvImage.TabStop = false;
            // 
            // irImage
            // 
            this.irImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.irImage.Location = new System.Drawing.Point(6, 270);
            this.irImage.Name = "irImage";
            this.irImage.Size = new System.Drawing.Size(325, 205);
            this.irImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.irImage.TabIndex = 24;
            this.irImage.TabStop = false;
            // 
            // btnZoomVis
            // 
            this.btnZoomVis.Location = new System.Drawing.Point(403, 12);
            this.btnZoomVis.Name = "btnZoomVis";
            this.btnZoomVis.Size = new System.Drawing.Size(42, 23);
            this.btnZoomVis.TabIndex = 32;
            this.btnZoomVis.Text = "Zoom";
            this.btnZoomVis.UseVisualStyleBackColor = true;
            this.btnZoomVis.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(370, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Vis:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbEPassport
            // 
            this.gbEPassport.Controls.Add(this.gbJari);
            this.gbEPassport.Controls.Add(this.gbPhotoAndMRTD);
            this.gbEPassport.Controls.Add(this.groupBox3);
            this.gbEPassport.Controls.Add(this.validatedList);
            this.gbEPassport.Location = new System.Drawing.Point(703, 3);
            this.gbEPassport.Name = "gbEPassport";
            this.gbEPassport.Size = new System.Drawing.Size(644, 481);
            this.gbEPassport.TabIndex = 36;
            this.gbEPassport.TabStop = false;
            this.gbEPassport.Text = "E-Passport";
            // 
            // gbJari
            // 
            this.gbJari.Controls.Add(this.btnZoomFinger2);
            this.gbJari.Controls.Add(this.btnZoomFinger1);
            this.gbJari.Controls.Add(this.lblFinger2Type);
            this.gbJari.Controls.Add(this.lblFinger1Type);
            this.gbJari.Controls.Add(this.pbFinger2);
            this.gbJari.Controls.Add(this.pbFinger1);
            this.gbJari.Location = new System.Drawing.Point(364, 17);
            this.gbJari.Name = "gbJari";
            this.gbJari.Size = new System.Drawing.Size(273, 219);
            this.gbJari.TabIndex = 35;
            this.gbJari.TabStop = false;
            this.gbJari.Text = "Jari";
            // 
            // btnZoomFinger2
            // 
            this.btnZoomFinger2.Location = new System.Drawing.Point(147, 20);
            this.btnZoomFinger2.Name = "btnZoomFinger2";
            this.btnZoomFinger2.Size = new System.Drawing.Size(42, 23);
            this.btnZoomFinger2.TabIndex = 36;
            this.btnZoomFinger2.Text = "Zoom";
            this.btnZoomFinger2.UseVisualStyleBackColor = true;
            this.btnZoomFinger2.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnZoomFinger1
            // 
            this.btnZoomFinger1.Location = new System.Drawing.Point(13, 20);
            this.btnZoomFinger1.Name = "btnZoomFinger1";
            this.btnZoomFinger1.Size = new System.Drawing.Size(42, 23);
            this.btnZoomFinger1.TabIndex = 35;
            this.btnZoomFinger1.Text = "Zoom";
            this.btnZoomFinger1.UseVisualStyleBackColor = true;
            this.btnZoomFinger1.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // lblFinger2Type
            // 
            this.lblFinger2Type.AutoSize = true;
            this.lblFinger2Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinger2Type.Location = new System.Drawing.Point(144, 187);
            this.lblFinger2Type.Name = "lblFinger2Type";
            this.lblFinger2Type.Size = new System.Drawing.Size(11, 15);
            this.lblFinger2Type.TabIndex = 3;
            this.lblFinger2Type.Text = "-";
            // 
            // lblFinger1Type
            // 
            this.lblFinger1Type.AutoSize = true;
            this.lblFinger1Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinger1Type.Location = new System.Drawing.Point(10, 187);
            this.lblFinger1Type.Name = "lblFinger1Type";
            this.lblFinger1Type.Size = new System.Drawing.Size(11, 15);
            this.lblFinger1Type.TabIndex = 2;
            this.lblFinger1Type.Text = "-";
            // 
            // pbFinger2
            // 
            this.pbFinger2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinger2.Location = new System.Drawing.Point(139, 48);
            this.pbFinger2.Name = "pbFinger2";
            this.pbFinger2.Size = new System.Drawing.Size(127, 127);
            this.pbFinger2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger2.TabIndex = 1;
            this.pbFinger2.TabStop = false;
            // 
            // pbFinger1
            // 
            this.pbFinger1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFinger1.Location = new System.Drawing.Point(6, 48);
            this.pbFinger1.Name = "pbFinger1";
            this.pbFinger1.Size = new System.Drawing.Size(127, 127);
            this.pbFinger1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFinger1.TabIndex = 0;
            this.pbFinger1.TabStop = false;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.ImagesTab);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.UHFTab);
            this.tabControl.Controls.Add(this.TimingsTab);
            this.tabControl.Controls.Add(this.ImagesRearTab);
            this.tabControl.Location = new System.Drawing.Point(8, 131);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1276, 518);
            this.tabControl.TabIndex = 32;
            // 
            // ImagesRearTab
            // 
            this.ImagesRearTab.BackColor = System.Drawing.SystemColors.Control;
            this.ImagesRearTab.Controls.Add(this.label92);
            this.ImagesRearTab.Controls.Add(this.irImageRear);
            this.ImagesRearTab.Controls.Add(this.visibleImageRear);
            this.ImagesRearTab.Controls.Add(this.label93);
            this.ImagesRearTab.Controls.Add(this.uvImageRear);
            this.ImagesRearTab.Controls.Add(this.label94);
            this.ImagesRearTab.Location = new System.Drawing.Point(4, 22);
            this.ImagesRearTab.Name = "ImagesRearTab";
            this.ImagesRearTab.Size = new System.Drawing.Size(626, 492);
            this.ImagesRearTab.TabIndex = 4;
            this.ImagesRearTab.Text = "Images Rear";
            // 
            // label92
            // 
            this.label92.Location = new System.Drawing.Point(13, 27);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(24, 16);
            this.label92.TabIndex = 29;
            this.label92.Text = "IR:";
            this.label92.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // irImageRear
            // 
            this.irImageRear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.irImageRear.Location = new System.Drawing.Point(43, 27);
            this.irImageRear.Name = "irImageRear";
            this.irImageRear.Size = new System.Drawing.Size(352, 178);
            this.irImageRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.irImageRear.TabIndex = 24;
            this.irImageRear.TabStop = false;
            // 
            // visibleImageRear
            // 
            this.visibleImageRear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.visibleImageRear.Location = new System.Drawing.Point(440, 24);
            this.visibleImageRear.Name = "visibleImageRear";
            this.visibleImageRear.Size = new System.Drawing.Size(352, 178);
            this.visibleImageRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.visibleImageRear.TabIndex = 20;
            this.visibleImageRear.TabStop = false;
            // 
            // label93
            // 
            this.label93.Location = new System.Drawing.Point(407, 24);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(27, 16);
            this.label93.TabIndex = 25;
            this.label93.Text = "Vis:";
            this.label93.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uvImageRear
            // 
            this.uvImageRear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uvImageRear.Location = new System.Drawing.Point(440, 214);
            this.uvImageRear.Name = "uvImageRear";
            this.uvImageRear.Size = new System.Drawing.Size(352, 178);
            this.uvImageRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uvImageRear.TabIndex = 21;
            this.uvImageRear.TabStop = false;
            // 
            // label94
            // 
            this.label94.Location = new System.Drawing.Point(404, 216);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(30, 16);
            this.label94.TabIndex = 26;
            this.label94.Text = "UV:";
            this.label94.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.label33);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(806, 407);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Images";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.richTextBox1);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Location = new System.Drawing.Point(33, 24);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(352, 208);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 154);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(320, 40);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(24, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 16);
            this.label14.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(240, 128);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 16);
            this.label15.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(240, 112);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(104, 16);
            this.label16.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(240, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 16);
            this.label17.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(240, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 16);
            this.label18.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(240, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(104, 16);
            this.label19.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(240, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 16);
            this.label25.TabIndex = 16;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(136, 128);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 16);
            this.label26.TabIndex = 15;
            this.label26.Text = "Document Number:";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(136, 112);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 16);
            this.label27.TabIndex = 14;
            this.label27.Text = "Date of Birth:";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(136, 96);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 16);
            this.label28.TabIndex = 13;
            this.label28.Text = "Sex:";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(136, 80);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 16);
            this.label29.TabIndex = 12;
            this.label29.Text = "Nationality:";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(136, 64);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(68, 16);
            this.label30.TabIndex = 11;
            this.label30.Text = "Forenames:";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(136, 48);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 16);
            this.label31.TabIndex = 10;
            this.label31.Text = "Surname:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(3, 240);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(24, 16);
            this.label32.TabIndex = 29;
            this.label32.Text = "IR:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(33, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(352, 152);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(440, 24);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(352, 178);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(407, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(27, 16);
            this.label33.TabIndex = 25;
            this.label33.Text = "Vis:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(440, 214);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(352, 178);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(404, 216);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(30, 16);
            this.label34.TabIndex = 26;
            this.label34.Text = "UV:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(806, 407);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "RFID";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(400, 240);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 152);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data Item";
            this.columnHeader3.Width = 189;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data Size";
            this.columnHeader4.Width = 159;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(400, 24);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(360, 200);
            this.listView2.TabIndex = 34;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Data Item";
            this.columnHeader5.Width = 189;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Validated";
            this.columnHeader6.Width = 159;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Location = new System.Drawing.Point(24, 232);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(352, 168);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(160, 76);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(100, 16);
            this.label35.TabIndex = 5;
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(160, 56);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(100, 16);
            this.label36.TabIndex = 4;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(160, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 16);
            this.label37.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(24, 80);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 16);
            this.label38.TabIndex = 2;
            this.label38.Text = "BAC Status:";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(24, 56);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(100, 16);
            this.label39.TabIndex = 1;
            this.label39.Text = "Chip id:";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(24, 32);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(100, 16);
            this.label40.TabIndex = 0;
            this.label40.Text = "Air Baud Rate:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label41);
            this.groupBox7.Controls.Add(this.label42);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Controls.Add(this.label44);
            this.groupBox7.Controls.Add(this.label45);
            this.groupBox7.Controls.Add(this.label46);
            this.groupBox7.Controls.Add(this.label47);
            this.groupBox7.Controls.Add(this.label48);
            this.groupBox7.Controls.Add(this.label49);
            this.groupBox7.Controls.Add(this.label50);
            this.groupBox7.Controls.Add(this.label51);
            this.groupBox7.Controls.Add(this.label52);
            this.groupBox7.Controls.Add(this.label53);
            this.groupBox7.Controls.Add(this.pictureBox5);
            this.groupBox7.Location = new System.Drawing.Point(24, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(352, 208);
            this.groupBox7.TabIndex = 32;
            this.groupBox7.TabStop = false;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(240, 128);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(104, 16);
            this.label41.TabIndex = 32;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(240, 112);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(104, 16);
            this.label42.TabIndex = 31;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(240, 96);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(104, 16);
            this.label43.TabIndex = 30;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(240, 80);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(104, 16);
            this.label44.TabIndex = 29;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(240, 64);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(104, 16);
            this.label45.TabIndex = 28;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(240, 48);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(104, 16);
            this.label46.TabIndex = 27;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(136, 128);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(104, 16);
            this.label47.TabIndex = 26;
            this.label47.Text = "Document Number:";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(136, 112);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(84, 16);
            this.label48.TabIndex = 25;
            this.label48.Text = "Date of Birth:";
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(136, 96);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(56, 16);
            this.label49.TabIndex = 24;
            this.label49.Text = "Sex:";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(136, 80);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(68, 16);
            this.label50.TabIndex = 23;
            this.label50.Text = "Nationality:";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(136, 64);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(68, 16);
            this.label51.TabIndex = 22;
            this.label51.Text = "Forenames:";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(136, 48);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 16);
            this.label52.TabIndex = 11;
            this.label52.Text = "Surname:";
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(16, 160);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(320, 32);
            this.label53.TabIndex = 3;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(16, 48);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(104, 96);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox9);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(806, 407);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "UHF";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label54);
            this.groupBox8.Location = new System.Drawing.Point(15, 104);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(773, 51);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "EPC";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(17, 25);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(0, 13);
            this.label54.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label55);
            this.groupBox9.Controls.Add(this.label56);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Controls.Add(this.label59);
            this.groupBox9.Controls.Add(this.label60);
            this.groupBox9.Controls.Add(this.label61);
            this.groupBox9.Controls.Add(this.label62);
            this.groupBox9.Location = new System.Drawing.Point(15, 14);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(773, 75);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tag ID";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(151, 55);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(0, 13);
            this.label55.TabIndex = 8;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(17, 55);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(79, 13);
            this.label56.TabIndex = 7;
            this.label56.Text = "Serial Number: ";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(151, 42);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(0, 13);
            this.label57.TabIndex = 6;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(17, 42);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(82, 13);
            this.label58.TabIndex = 5;
            this.label58.Text = "Model Number: ";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(151, 29);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(0, 13);
            this.label59.TabIndex = 4;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(17, 29);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(98, 13);
            this.label60.TabIndex = 3;
            this.label60.Text = "Mask Designer ID: ";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(151, 16);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(0, 13);
            this.label61.TabIndex = 2;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(17, 16);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(90, 13);
            this.label62.TabIndex = 1;
            this.label62.Text = "Manufacturer ID: ";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(20);
            this.tabPage5.Size = new System.Drawing.Size(806, 407);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Timings";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.AllowColumnReorder = true;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.FullRowSelect = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(20, 20);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(766, 367);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Time";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Message Name";
            this.columnHeader8.Width = 156;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Size";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Data";
            this.columnHeader10.Width = 353;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.richTextBox2);
            this.groupBox10.Controls.Add(this.label63);
            this.groupBox10.Controls.Add(this.label64);
            this.groupBox10.Controls.Add(this.label65);
            this.groupBox10.Controls.Add(this.label66);
            this.groupBox10.Controls.Add(this.label67);
            this.groupBox10.Controls.Add(this.label68);
            this.groupBox10.Controls.Add(this.label69);
            this.groupBox10.Controls.Add(this.label70);
            this.groupBox10.Controls.Add(this.label71);
            this.groupBox10.Controls.Add(this.label72);
            this.groupBox10.Controls.Add(this.label73);
            this.groupBox10.Controls.Add(this.label74);
            this.groupBox10.Controls.Add(this.label75);
            this.groupBox10.Controls.Add(this.pictureBox6);
            this.groupBox10.Location = new System.Drawing.Point(33, 24);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(352, 208);
            this.groupBox10.TabIndex = 31;
            this.groupBox10.TabStop = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(16, 154);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox2.Size = new System.Drawing.Size(320, 40);
            this.richTextBox2.TabIndex = 33;
            this.richTextBox2.Text = "";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(24, 24);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(96, 16);
            this.label63.TabIndex = 22;
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(240, 128);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(104, 16);
            this.label64.TabIndex = 21;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(240, 112);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(104, 16);
            this.label65.TabIndex = 20;
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(240, 96);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(104, 16);
            this.label66.TabIndex = 19;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(240, 80);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(104, 16);
            this.label67.TabIndex = 18;
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(240, 64);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(104, 16);
            this.label68.TabIndex = 17;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(240, 48);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(104, 16);
            this.label69.TabIndex = 16;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(136, 128);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(104, 16);
            this.label70.TabIndex = 15;
            this.label70.Text = "Document Number:";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(136, 112);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(84, 16);
            this.label71.TabIndex = 14;
            this.label71.Text = "Date of Birth:";
            // 
            // label72
            // 
            this.label72.Location = new System.Drawing.Point(136, 96);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(56, 16);
            this.label72.TabIndex = 13;
            this.label72.Text = "Sex:";
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(136, 80);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(68, 16);
            this.label73.TabIndex = 12;
            this.label73.Text = "Nationality:";
            // 
            // label74
            // 
            this.label74.Location = new System.Drawing.Point(136, 64);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(68, 16);
            this.label74.TabIndex = 11;
            this.label74.Text = "Forenames:";
            // 
            // label75
            // 
            this.label75.Location = new System.Drawing.Point(136, 48);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(56, 16);
            this.label75.TabIndex = 10;
            this.label75.Text = "Surname:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(24, 48);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(96, 96);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(3, 240);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(24, 16);
            this.label76.TabIndex = 29;
            this.label76.Text = "IR:";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox7.Location = new System.Drawing.Point(33, 240);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(352, 152);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 24;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.Location = new System.Drawing.Point(440, 24);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(352, 178);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 20;
            this.pictureBox8.TabStop = false;
            // 
            // label77
            // 
            this.label77.Location = new System.Drawing.Point(407, 24);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(27, 16);
            this.label77.TabIndex = 25;
            this.label77.Text = "Vis:";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox9.Location = new System.Drawing.Point(440, 214);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(352, 178);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 21;
            this.pictureBox9.TabStop = false;
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(404, 216);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(30, 16);
            this.label78.TabIndex = 26;
            this.label78.Text = "UV:";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label87);
            this.groupBox11.Controls.Add(this.tbNoPassport);
            this.groupBox11.Controls.Add(this.tbTglLahir);
            this.groupBox11.Controls.Add(this.label82);
            this.groupBox11.Controls.Add(this.tbNamaPemohon);
            this.groupBox11.Controls.Add(this.label81);
            this.groupBox11.Controls.Add(this.label79);
            this.groupBox11.Controls.Add(this.tbNoPermohonan);
            this.groupBox11.Location = new System.Drawing.Point(12, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(579, 130);
            this.groupBox11.TabIndex = 34;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Data Pemohon";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(318, 31);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(68, 13);
            this.label87.TabIndex = 7;
            this.label87.Text = "No. Passport";
            // 
            // tbNoPassport
            // 
            this.tbNoPassport.Location = new System.Drawing.Point(392, 28);
            this.tbNoPassport.Name = "tbNoPassport";
            this.tbNoPassport.ReadOnly = true;
            this.tbNoPassport.Size = new System.Drawing.Size(175, 20);
            this.tbNoPassport.TabIndex = 6;
            // 
            // tbTglLahir
            // 
            this.tbTglLahir.Location = new System.Drawing.Point(118, 77);
            this.tbTglLahir.Name = "tbTglLahir";
            this.tbTglLahir.ReadOnly = true;
            this.tbTglLahir.Size = new System.Drawing.Size(112, 20);
            this.tbTglLahir.TabIndex = 5;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(17, 80);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(72, 13);
            this.label82.TabIndex = 4;
            this.label82.Text = "Tanggal Lahir";
            // 
            // tbNamaPemohon
            // 
            this.tbNamaPemohon.Location = new System.Drawing.Point(118, 54);
            this.tbNamaPemohon.Name = "tbNamaPemohon";
            this.tbNamaPemohon.ReadOnly = true;
            this.tbNamaPemohon.Size = new System.Drawing.Size(175, 20);
            this.tbNamaPemohon.TabIndex = 3;
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(17, 57);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(83, 13);
            this.label81.TabIndex = 2;
            this.label81.Text = "Nama Pemohon";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(17, 33);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(87, 13);
            this.label79.TabIndex = 1;
            this.label79.Text = "No. Permohonan";
            // 
            // tbNoPermohonan
            // 
            this.tbNoPermohonan.Location = new System.Drawing.Point(118, 30);
            this.tbNoPermohonan.Name = "tbNoPermohonan";
            this.tbNoPermohonan.ReadOnly = true;
            this.tbNoPermohonan.Size = new System.Drawing.Size(175, 20);
            this.tbNoPermohonan.TabIndex = 0;
            // 
            // btnSerahkan
            // 
            this.btnSerahkan.Enabled = false;
            this.btnSerahkan.Location = new System.Drawing.Point(102, 62);
            this.btnSerahkan.Name = "btnSerahkan";
            this.btnSerahkan.Size = new System.Drawing.Size(80, 35);
            this.btnSerahkan.TabIndex = 48;
            this.btnSerahkan.Text = "Serahkan Passport";
            this.btnSerahkan.UseVisualStyleBackColor = true;
            this.btnSerahkan.Visible = false;
            this.btnSerahkan.Click += new System.EventHandler(this.btnSerahkan_Click);
            // 
            // btnCetakUlang
            // 
            this.btnCetakUlang.Enabled = false;
            this.btnCetakUlang.Location = new System.Drawing.Point(16, 62);
            this.btnCetakUlang.Name = "btnCetakUlang";
            this.btnCetakUlang.Size = new System.Drawing.Size(80, 35);
            this.btnCetakUlang.TabIndex = 47;
            this.btnCetakUlang.Text = "Cetak Ulang";
            this.btnCetakUlang.UseVisualStyleBackColor = true;
            this.btnCetakUlang.Visible = false;
            this.btnCetakUlang.Click += new System.EventHandler(this.btnCetakUlang_Click);
            // 
            // tbHasilUji
            // 
            this.tbHasilUji.Location = new System.Drawing.Point(111, 28);
            this.tbHasilUji.Name = "tbHasilUji";
            this.tbHasilUji.ReadOnly = true;
            this.tbHasilUji.Size = new System.Drawing.Size(243, 20);
            this.tbHasilUji.TabIndex = 46;
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(10, 31);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(85, 13);
            this.label88.TabIndex = 45;
            this.label88.Text = "Hasil Uji Kualitas";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label99);
            this.groupBox12.Controls.Add(this.rtbLog);
            this.groupBox12.Controls.Add(this.btnSerahkan);
            this.groupBox12.Controls.Add(this.btnCetakUlang);
            this.groupBox12.Controls.Add(this.label88);
            this.groupBox12.Controls.Add(this.tbHasilUji);
            this.groupBox12.Location = new System.Drawing.Point(597, 3);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(576, 130);
            this.groupBox12.TabIndex = 49;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Hasil";
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(357, 9);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(70, 13);
            this.label99.TabIndex = 50;
            this.label99.Text = "Alasan Gagal";
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(360, 27);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(203, 94);
            this.rtbLog.TabIndex = 49;
            this.rtbLog.Text = "";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(333, 655);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 35);
            this.btnEdit.TabIndex = 52;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(708, 655);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(167, 35);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Tutup Aplikasi";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BtnHapus
            // 
            this.BtnHapus.Location = new System.Drawing.Point(524, 655);
            this.BtnHapus.Name = "BtnHapus";
            this.BtnHapus.Size = new System.Drawing.Size(166, 35);
            this.BtnHapus.TabIndex = 53;
            this.BtnHapus.Text = "Hapus Data Pemohon";
            this.BtnHapus.UseVisualStyleBackColor = true;
            this.BtnHapus.Click += new System.EventHandler(this.BtnHapusData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1284, 728);
            this.ControlBox = false;
            this.Controls.Add(this.BtnHapus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.dataFileList);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblChipId);
            this.Controls.Add(this.lblBACStatus);
            this.Controls.Add(this.lblAirBaudRate);
            this.Menu = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Passport Scanner";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.StatePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimePanel)).EndInit();
            this.TimingsTab.ResumeLayout(false);
            this.UHFTab.ResumeLayout(false);
            this.EPCGroupBox.ResumeLayout(false);
            this.EPCGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.gbPhotoAndMRTD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rfImage)).EndInit();
            this.ImagesTab.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbPassport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.visibleImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.irImage)).EndInit();
            this.gbEPassport.ResumeLayout(false);
            this.gbJari.ResumeLayout(false);
            this.gbJari.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFinger1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ImagesRearTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.irImageRear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visibleImageRear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uvImageRear)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{

            string workingDirectory = @"C:\Program Files (x86)\Thales\Gemalto Document Reader SDK\3.7.1.17\Bin";
            SetWorkingDirectory(workingDirectory);

            string[] args = new string[] { "neviimmrzreader:http://host.docker.internal:9030/alokasi-paspor/dokim/cancel-reallocate/&http://host.docker.internal:9030/alokasi-paspor/dokim/exchange/&http://host.docker.internal:9030/alokasi-paspor/dokim/reallocate/&http://host.docker.internal:9030/alokasi-paspor/dokim/save-reallocation/&http://host.docker.internal:9030/alokasi-paspor/dokim/fail-test/&http://host.docker.internal:9030/alokasi-paspor/dokim/success-test/&http://host.docker.internal:9030/alokasi-paspor/dokim/set-status/&http://host.docker.internal:9091/notify&http://host.docker.internal:9030/auth-api/alur-mundur/login&http://host.docker.internal:9030/pengecekan-mrtd/pengecekan-dpri/adddoc&http://host.docker.internal:9030/pengecekan-mrtd/pengecekan-dpri/update-userid&MUHAMMAD_SOBIRIN&5539000000014862&17-01-1991&C5726112&7ea90a6f-a85a-4bf1-a761-a77a6c1f16cf&a54e7589-553c-4e24-baed-a9642df969ce&43e07f6d-e3a2-4138-bfe6-652b3bdb056d&eyJhbGciOiJIUzI1NiJ9.eyJ3b3JrX3VuaXQiOnsiaWQiOiIyN0FBIiwiaWRTYXR1YW5LZXJqYSI6IjI3QUEiLCJuYW1hU2F0dWFuS2VyamEiOiJLSlJJIEpPSE9SIEJBSFJVIiwiZGVza3JpcHNpU2F0dWFuS2VyamEiOiJLSlJJIEpPSE9SIEJBSFJVIiwiYWxhbWF0IjoiTm8uNDYsIEphbGFuIFRhYXQsIDgwMTAwIEpvaG9yIEJhaHJ1IiwidGVsZXBvbiI6Iis2MDcgLSAyMjcgNDE4OC8yMjEzMjQzIiwiZmF4IjoiKzYwNy0yMjEgMzI0NiIsInN0cnVrdHVyU2F0dWFuS2VyamEiOm51bGwsImluZHVrU2F0dWFuS2VyamEiOm51bGwsImtvZGVVbml0IjoiMjdBQSIsImtvZGVDYWJhbmciOiI1NTMiLCJhY3RpdmUiOnRydWV9LCJyb2xlIjoiU1VQRVIiLCJuYW1lIjoiU3VwZXIiLCJpZCI6IjQzZTA3ZjZkLWUzYTItNDEzOC1iZmU2LTY1MmIzYmRiMDU2ZCIsImV4cCI6MTU4OTIyMzQ4MSwidXNlcm5hbWUiOiIxMjM0NSIsIm9uT2ZmIjp0cnVlfQ.YbNttOZjl-r7hLO2jBVBkjdZfXhnF8swVqWtKA1BFvs&AKTIF&TERCETAK&BIASA" };

            string strneviimmrzreader = "neviimmrzreader:";


            if (args.Length == 1 && args[0].Contains("neviimmrzreader:") && args[0].Length > (strneviimmrzreader).Length)
            {
                MainForm form = new MainForm(args);
                if (!form.IsDisposed)
                {
                    Application.Run(form);
                }
            }
            else
            {
                MessageBox.Show("Silahkan menjalankan program melalui aplikasi web", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

        private static void SetWorkingDirectory(string directoryPath)
        {
            try
            {
                // Check if the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Set the current directory to the specified path
                    Environment.CurrentDirectory = directoryPath;
                    Console.WriteLine("Working directory set to: " + Environment.CurrentDirectory);
                }
                else
                {
                    Console.WriteLine("Directory does not exist: " + directoryPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting working directory: " + ex.Message);
            }
        }

        void DataCallbackThreadHelper(MMM.Readers.FullPage.DataType aDataType, object aData)
		{
			if (_threadHelperControl.InvokeRequired)
			{
				_threadHelperControl.Invoke(
					new MMM.Readers.FullPage.DataDelegate(DataCallback),
					new object[] { aDataType, aData }
				);
			}
			else
			{
				DataCallback(aDataType, aData);
			}
		}

        void HighlightCodelineCheckDigits(MMM.Readers.CodelineData aCodeline)
        {
            for (int loop = 0; loop < aCodeline.CheckDigitDataListCount; loop++)
            {
                MMM.Readers.CodelineCheckDigitData lCDData = aCodeline.CheckDigitDataList[loop];
                int lIndex = lCDData.puCodelinePos;
                for (int line = 1; line < lCDData.puCodelineNumber; line++)
                {
                    switch (line)
                    {
                        case 1:
                            lIndex += aCodeline.Line1.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                        case 2:
                            lIndex += aCodeline.Line2.Length;
                            ++lIndex; //Add 1 for EOL char
                            break;
                    }
                }

                richTextBoxCodeline.Select(lIndex, 1);
                if(lCDData.puValueExpected == lCDData.puValueRead)
                    richTextBoxCodeline.SelectionColor = Color.Green;
                else
                    richTextBoxCodeline.SelectionColor = Color.Red;
                richTextBoxCodeline.DeselectAll();
            }
        }

		void DataCallback(MMM.Readers.FullPage.DataType aDataType, object aData)
		{
			try
			{
				LogDataItem(aDataType, aData);
                Bitmap ResizeImage(Image image, int width, int height)
                {
                    var destRect = new Rectangle(0, 0, width, height);
                    var destImage = new Bitmap(width, height);

                    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                    using (var graphics = Graphics.FromImage(destImage))
                    {
                        graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        using (var wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }

                    return destImage;
                }
                string ConvertToBase64WithQuality(Bitmap bitmap, long quality)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                        var imageCodecInfo = GetEncoder(ImageFormat.Jpeg);

                        bitmap.Save(memoryStream, imageCodecInfo, encoderParameters);
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
                ImageCodecInfo GetEncoder(ImageFormat format)
                {
                    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
                    foreach (ImageCodecInfo codec in codecs)
                    {
                        if (codec.FormatID == format.Guid)
                        {
                            return codec;
                        }
                    }
                    return null;
                }


                if (aData != null)
				{
					switch (aDataType)
					{
						case MMM.Readers.FullPage.DataType.CD_CODELINE_DATA:
							{
                                rtbLog.Text = "";
                                tbHasilUji.Text = "";
								MMM.Readers.CodelineData codeline = (MMM.Readers.CodelineData)aData;

                                richTextBoxCodeline.Text =
                                    codeline.Line1 + "\n" +
                                    codeline.Line2 + "\n" +
                                    codeline.Line3;
                                HighlightCodelineCheckDigits(codeline);
								lblSurname.Text = codeline.Forenames == "" ? "" : codeline.Surname;
								lblForenames.Text = codeline.Forenames == "" ? codeline.Surname : codeline.Forenames;
								lblNationality.Text = codeline.Nationality;
                                lblIssuingState.Text = codeline.IssuingState;
								lblSex.Text = codeline.Sex.ToUpper() == "MALE"? "Laki - Laki" : "Perempuan" ;
								lblDateOfBirth.Text = string.Format(
									"{0:00}-{1:00}-{2:00}",
									codeline.DateOfBirth.Day,
									codeline.DateOfBirth.Month,
									codeline.DateOfBirth.Year
								);
								lblDocumentNumber.Text = codeline.DocNumber;
								lblDocumentType.Text = codeline.DocType;

                                forename = codeline.Forenames == "" ? "" : codeline.Forenames;
                                surname = codeline.Surname == "" ? "" : codeline.Surname;
                                kewarganegaraan = codeline.Nationality;
                                issuingState = codeline.IssuingState;
                                gender = codeline.Sex.ToUpper() == "MALE" ? "Laki - Laki" : "Perempuan";
                                dob = string.Format(
                                    "{0:00}-{1:00}-{2:00}",
                                    codeline.DateOfBirth.Day,
                                    codeline.DateOfBirth.Month,
                                    codeline.DateOfBirth.Year
                                );
                                docNumber = codeline.DocNumber;
                                docType = codeline.DocType;




                                if ((lblDocumentType.Text.ToUpper() != "PASSPORT") 
                                    && (lblDocumentType.Text.ToUpper() != "TRAVEL DOCUMENT"))
                                {
                                    SetResultAndButtonState("Tidak Lulus", "Dokumen tidak terdeteksi sebagai passport");
                                }

                                if (lblDocumentNumber.Text != noPassport)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "No. passport tidak sama");
                                }
                                else
                                {
                                    SetResultAndButtonState("Lulus", "");
                                }
                                codeline1 = codeline.Line1;
                                codeline2 = codeline.Line2;

                                break;
							}
                        case MMM.Readers.FullPage.DataType.CD_CHECKSUM:
                            {
                                int check = Convert.ToInt32(aData);
                                if (check == 0)
                                {
                                    lblChecksum.Text = "Checksum";
                                    lblChecksum.BackColor = SystemColors.Control;
                                }
                                else if (check > 0)
                                {
                                    lblChecksum.Text = "Checksum Passed";
                                    lblChecksum.BackColor = Color.LimeGreen;
                                    SetResultAndButtonState("Lulus", "");
                                }
                                else if (check < -1)
                                {
                                    lblChecksum.Text = "Checksum Failed";
                                    lblChecksum.BackColor = Color.Red;
                                    SetResultAndButtonState("Tidak Lulus", "Hasil uji menemukan kesalahan");
                                }
                                else if (check == -1)
                                {
                                    lblChecksum.Text = "Checksum Failed";
                                    lblChecksum.BackColor = Color.Red;
                                    SetResultAndButtonState("Tidak Lulus", "Hasil uji menemukan kesalahan");
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEIR:
                            {
                                irImage.Image = aData as Bitmap;
                                 Bitmap bitmap = irImage.Image as Bitmap;
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                    byte[] byteBuffer = memoryStream.ToArray();
                                    string base64String = Convert.ToBase64String(byteBuffer);
                                    base64IR = base64String;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEVIS:
                            {
                                //Image img = aData as Bitmap;
                                //visibleImage.Image = img;
                                //string combinedPath = Path.Combine(tempPath, pasporName);
                                //SaveImagetoTemp(img, combinedPath);

                                //using (MemoryStream memoryStream = new MemoryStream())
                                //{
                                //    img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                //    byte[] byteBuffer = memoryStream.ToArray();
                                //    string base64String = Convert.ToBase64String(byteBuffer);
                                //    base64VIS = base64String;
                                //}
                                //break;

                                Image img = aData as Bitmap;
                                if (img != null)
                                {
                                    visibleImage.Image = img;
                                    string combinedPath = Path.Combine(tempPath, pasporName);
                                    SaveImagetoTemp(img, combinedPath);

                                    // Resize the image
                                    int newWidth = 400; 
                                    int newHeight = 300; 
                                    Bitmap resizedImage = ResizeImage(img, newWidth, newHeight);

                                    // Adjust quality to ensure the Base64 string is under 50 KB
                                    string base64String = null;
                                    long quality = 80; 
                                    while (true)
                                    {
                                        base64String = ConvertToBase64WithQuality(resizedImage, quality);
                                        if ((base64String.Length * 3 / 4) <= 30 * 1024 || quality <= 10)
                                        {
                                            break;
                                        }
                                        quality -= 5;
                                    }

                                    base64VIS = base64String;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid image data.");
                                }
                                break;
                            }

                        case MMM.Readers.FullPage.DataType.CD_IMAGEPHOTO:
                            {
                                photoImage.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEUV:
                            {
                                uvImage.Image = aData as Bitmap;
                                 Bitmap bitmap = uvImage.Image as Bitmap;

                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                    byte[] byteBuffer = memoryStream.ToArray();
                                    string base64String = Convert.ToBase64String(byteBuffer);
                                    base64UV = base64String;
                                }
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEIRREAR:
                            {
                                irImageRear.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEVISREAR:
                            {
                                visibleImageRear.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_IMAGEUVREAR:
                            {
                                uvImageRear.Image = aData as Bitmap;
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCAIRBAUD:
							{
								lblAirBaudRate.Text = aData as string;
								break;
							}
						case MMM.Readers.FullPage.DataType.CD_BACKEY_CORRECTION:
							{
                                bool lTemp = _threadHelperControl.InvokeRequired;
                                {
                                    System.Text.StringBuilder lStringBuilder =
                                        aData as System.Text.StringBuilder;

                                    if (lStringBuilder != null)
                                    {
                                        FormBACKeyCorrection lForm = new FormBACKeyCorrection();
                                        lForm.SetCodeline(lStringBuilder.ToString());

                                        if (lForm.ShowDialog() == DialogResult.OK)
                                        {
                                            lStringBuilder.Replace(
                                                lStringBuilder.ToString(),
                                                lForm.GetCodeline()
                                            );
                                        }
                                    }
                                }

                                break;
							}
						case MMM.Readers.FullPage.DataType.CD_SCDG1_CODELINE_DATA:
							{
								MMM.Readers.CodelineData codeline = (MMM.Readers.CodelineData)aData;

                                lblRFCodeline.Text = codeline.Line1 + "\n" +
                                                     codeline.Line2 + "\n" +
                                                     codeline.Line3;

                                lblRFSurname.Text = codeline.Forenames == "" ? "" : codeline.Surname;
								lblRFForenames.Text = codeline.Forenames == ""? codeline.Surname : codeline.Forenames;
								lblRFNationality.Text = codeline.Nationality;
                                lblRFIssuingState.Text = codeline.IssuingState;
								lblRFSex.Text = codeline.Sex.ToUpper() == "MALE"? "Laki - Laki" : "Perempuan";
								lblRFDateOfBirth.Text = string.Format(
									"{0:00}-{1:00}-{2:00}",
									codeline.DateOfBirth.Day,
									codeline.DateOfBirth.Month,
									codeline.DateOfBirth.Year
								);
								lblRFDocNumber.Text = codeline.DocNumber;

                                forename = codeline.Forenames == "" ? "" : codeline.Forenames;
                                surname = codeline.Surname == "" ? "" : codeline.Surname;
                                kewarganegaraan = codeline.Nationality;
                                issuingState = codeline.IssuingState;
                                gender = codeline.Sex.ToUpper() == "MALE" ? "Laki - Laki" : "Perempuan";
                                dob = string.Format(
                                    "{0:00}-{1:00}-{2:00}",
                                    codeline.DateOfBirth.Day,
                                    codeline.DateOfBirth.Month,
                                    codeline.DateOfBirth.Year
                                );
                                docNumber = codeline.DocNumber;
                                docType = codeline.DocType;

                                if (codeline.Line1 != codeline1 
                                     || codeline.Line2 != codeline2)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "MRZ fisik dan chip tidak sama");
                                }

								break;
							}
						case MMM.Readers.FullPage.DataType.CD_SCDG2_PHOTO:
							{
								byte[] lInputBuffer = aData as byte[];
								try
								{
									// .NET bitmaps can be constructed from JPEG images
									System.IO.Stream streamBuffer = new System.IO.MemoryStream();
									streamBuffer.Write(lInputBuffer, 0, lInputBuffer.Length);
									streamBuffer.Seek(0, System.IO.SeekOrigin.Begin);
									rfImage.Image = new Bitmap(streamBuffer);
                                    string combinedPath = Path.Combine(tempPath, "foto.jpg");
                                    SaveImagetoTemp(rfImage.Image, combinedPath);
                                }
								catch (Exception imgExcept)
								{
									// but it throws an exception if its a JPEG 2000. You can use the 
									// low level API to convert JPEG 2000 to BMP though.
									byte[] lOutputBuffer = null;

									MMM.Readers.Modules.Imaging.ConvertFormat
												(MMM.Readers.FullPage.ImageFormats.RTE_BMP,
												lInputBuffer, out lOutputBuffer);

									if (lOutputBuffer != null)
									{
										try
										{
											System.IO.Stream j2kStream = new System.IO.MemoryStream();
											j2kStream.Write(lOutputBuffer, 0, lOutputBuffer.Length);
											j2kStream.Seek(0, System.IO.SeekOrigin.Begin);
											rfImage.Image = new Bitmap(j2kStream);
                                            string combinedPath = Path.Combine(tempPath, "foto.jpg");
                                            rfImage.Image.Save("foto", ImageFormat.Jpeg);
                                            SaveImagetoTemp(rfImage.Image, combinedPath);
                                        }
										catch (Exception decodeExcept)
										{
                                            SetResultAndButtonState("Tidak Lulus", "Pemunculan foto gagal");
                                            System.Windows.Forms.MessageBox.Show(decodeExcept.ToString());
										}
									}
								}

								break;
							}
                        case MMM.Readers.FullPage.DataType.CD_SCDG3_FINGERPRINTS:
                            {
                                int counter = 1;
                                DG3FingerprintData data = (DG3FingerprintData) aData;
                                foreach (DG3FingerImage image in data.puFingerImages)
                                {
                                    byte[] lInputBuffer = image.puDataBuffer;
                                    try
                                    {
                                        // .NET bitmaps can be constructed from JPEG images
                                        System.IO.Stream streamBuffer = new System.IO.MemoryStream();
                                        streamBuffer.Write(lInputBuffer, 0, lInputBuffer.Length);
                                        streamBuffer.Seek(0, System.IO.SeekOrigin.Begin);
                                        if (counter > 1)
                                        {
                                            pbFinger2.Image = new Bitmap(streamBuffer);
                                            string combinedPath = Path.Combine(tempPath, "finger2.jpg");
                                            SaveImagetoTemp(pbFinger2.Image, combinedPath);
                                            lblFinger2Type.Text = LocalizeFingerName(image.puFingerPosition);
                                        }
                                        else
                                        {
                                            pbFinger1.Image = new Bitmap(streamBuffer);
                                            string combinedPath = Path.Combine(tempPath, "finger1.jpg");
                                            SaveImagetoTemp(pbFinger1.Image, combinedPath);
                                            lblFinger1Type.Text = LocalizeFingerName(image.puFingerPosition);
                                            ListViewItem thisItem = validatedList.Items.Add("CD_SCDG3_VALIDATE");
                                            thisItem.SubItems.Add("RFID_VC_VALID");
                                        }
                                        counter++;
                                    }
                                    catch (Exception imgExcept)
                                    {
                                        // but it throws an exception if its a JPEG 2000. You can use the 
                                        // low level API to convert JPEG 2000 to BMP though.
                                        byte[] lOutputBuffer = null;

                                        MMM.Readers.Modules.Imaging.ConvertFormat
                                                    (MMM.Readers.FullPage.ImageFormats.RTE_BMP,
                                                    lInputBuffer, out lOutputBuffer);

                                        if (lOutputBuffer != null)
                                        {
                                            try
                                            {
                                                System.IO.Stream j2kStream = new System.IO.MemoryStream();
                                                j2kStream.Write(lOutputBuffer, 0, lOutputBuffer.Length);
                                                j2kStream.Seek(0, System.IO.SeekOrigin.Begin);
                                                if (counter > 1)
                                                {
                                                    pbFinger2.Image = new Bitmap(j2kStream);
                                                    string combinedPath = Path.Combine(tempPath, "finger2.jpg");
                                                    SaveImagetoTemp(pbFinger2.Image, combinedPath);
                                                    lblFinger2Type.Text = LocalizeFingerName(image.puFingerPosition);
                                                }
                                                else
                                                {
                                                    pbFinger1.Image = new Bitmap(j2kStream);
                                                    string combinedPath = Path.Combine(tempPath, "finger1.jpg");
                                                    SaveImagetoTemp(pbFinger1.Image, combinedPath);
                                                    lblFinger1Type.Text = LocalizeFingerName(image.puFingerPosition);
                                                    ListViewItem thisItem = validatedList.Items.Add("CD_SCDG3_VALIDATE");
                                                    thisItem.SubItems.Add("RFID_VC_VALID");
                                                }
                                                counter++;
                                            }
                                            catch (Exception decodeExcept)
                                            {
                                                SetResultAndButtonState("Tidak Lulus", "Pemunculan sidik jari gagal");
                                                System.Windows.Forms.MessageBox.Show(decodeExcept.ToString());
                                            }
                                        }
                                    }
                                }

                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCCHIPID:
							{
								lblChipId.Text = aData as string;
								break;
							}
						case MMM.Readers.FullPage.DataType.CD_SCDG1_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG2_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG3_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG4_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG5_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG6_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG7_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG8_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG9_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG10_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG11_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG12_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG13_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG14_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG15_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCDG16_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCSIGNEDATTRS_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_SCSIGNATURE_VALIDATE:
						case MMM.Readers.FullPage.DataType.CD_VALIDATE_DOC_SIGNER_CERT:
							{
								ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

								MMM.Readers.Modules.RF.ValidationCode lValidationResult = (MMM.Readers.Modules.RF.ValidationCode)aData;
								thisItem.SubItems.Add(lValidationResult.ToString());
								break;
							}
						case MMM.Readers.FullPage.DataType.CD_ACTIVE_AUTHENTICATION:
                            {
                                ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState != MMM.Readers.Modules.RF.TriState.TS_SUCCESS)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "Active Auth Gagal");
                                }
                                thisItem.SubItems.Add(lState.ToString());
                                this.lblAAStatus.Text = lState.ToString();
                                setLblColor(this.lblAAStatus);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCBAC_STATUS:
                            {
                                //ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                //MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                //thisItem.SubItems.Add(lState.ToString());
                                //this.lblBACStatus.Text = lState.ToString();
                                //setLblColor(this.lblBACStatus);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SAC_STATUS:
                            {
                                ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState != MMM.Readers.Modules.RF.TriState.TS_SUCCESS)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "SAC Gagal");
                                }
                                thisItem.SubItems.Add(lState.ToString());
                                this.lblSACStatus.Text = lState.ToString();
                                SACstatus = lState.ToString();
                                setLblColor(this.lblSACStatus);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_PASSIVE_AUTHENTICATION:
                            {
                                ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState.ToString() == "4")
                                {
                                    lState = MMM.Readers.Modules.RF.TriState.TS_FAILURE;
                                }
                                if (lState != MMM.Readers.Modules.RF.TriState.TS_SUCCESS)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "Passive Auth Gagal");
                                }
                                thisItem.SubItems.Add(lState.ToString());
                                this.lblPAStatus.Text = lState.ToString();
                                setLblColor(this.lblPAStatus);
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SCTERMINAL_AUTHENTICATION_STATUS:
                            {
                                ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState != MMM.Readers.Modules.RF.TriState.TS_SUCCESS)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "Terminal Auth Gagal");
                                }
                                thisItem.SubItems.Add(lState.ToString());
                                this.lblTAStatus.Text = lState.ToString();
                                setLblColor(this.lblTAStatus);
                                break;
                            }
						case MMM.Readers.FullPage.DataType.CD_SCCHIP_AUTHENTICATION_STATUS:
                            {
                                ListViewItem thisItem = validatedList.Items.Add(aDataType.ToString());

                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                if (lState != MMM.Readers.Modules.RF.TriState.TS_SUCCESS)
                                {
                                    SetResultAndButtonState("Tidak Lulus", "Chip Auth Gagal");
                                }
                                thisItem.SubItems.Add(lState.ToString());
                                this.lblCAStatus.Text = lState.ToString();
                                setLblColor(this.lblCAStatus);
                                break;
							}
						case MMM.Readers.FullPage.DataType.CD_SCDG1_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG2_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG3_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG4_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG5_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG6_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG7_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG8_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG9_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG10_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG11_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG12_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG13_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG14_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG15_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCDG16_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCEF_COM_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCEF_SOD_FILE:
						case MMM.Readers.FullPage.DataType.CD_SCEF_CVCA_FILE:
							{
								byte[] lFileData = aData as byte[];

								ListViewItem thisItem = dataFileList.Items.Add(aDataType.ToString());
								thisItem.SubItems.Add(lFileData.Length.ToString() + " bytes");
								break;
							}

						case MMM.Readers.FullPage.DataType.CD_UHF_EPC:
							{
								String lEPCString = "";
								foreach (byte lByte in (byte[])aData)
								{
									if (lEPCString.Length != 0)
										lEPCString += "-";
									lEPCString += lByte.ToString("X4");
								}

								EPCField.Text = lEPCString;
								break;
							}
						case MMM.Readers.FullPage.DataType.CD_UHF_TAGID:
							{
								if (aData is MMM.Readers.FullPage.UHFTagIDData)
								{
									DisplayUHFTagID(
										(MMM.Readers.FullPage.UHFTagIDData)aData);
								}
								break;
							}
					}

                    switch (aDataType)
                    {
                        case MMM.Readers.FullPage.DataType.CD_SCBAC_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                this.lblBACStatus.Text = lState.ToString();
                                break;
                            }
                        case MMM.Readers.FullPage.DataType.CD_SAC_STATUS:
                            {
                                MMM.Readers.Modules.RF.TriState lState = (MMM.Readers.Modules.RF.TriState)aData;
                                this.lblSACStatus.Text = lState.ToString();
                                break;
                            }
                    }
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(
					e.ToString(),
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
			}
		}

        private void setLblColor(Label lbl)
        {
            switch (lbl.Text)
            {
                case "TS_SUCCESS":
                    lbl.BackColor = Color.LightGreen;
                    break;
                case "TS_NOT_PERFORMED":
                    lbl.BackColor = Color.Yellow;
                    break;
                case "TS_FAILURE":
                    lbl.BackColor = Color.Red;
                    break;
            }
        }

        private string LocalizeFingerName(FIR_FINGER_POSITION fingerPos)
        {
            string fingerName = "Tidak Terdeteksi";

            switch (fingerPos)
            {
                case FIR_FINGER_POSITION.FFP_UNKNOWN:
                    fingerName = "Tidak Terdeteksi";
                    break;
                case FIR_FINGER_POSITION.FFP_THUMBS:
                    fingerName = "2 Jari Jempol";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_FOUR:
                    fingerName = "4 Jari Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_FOUR:
                    fingerName = "4 Jari Kiri";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_THUMB:
                    fingerName = "Jempol Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_INDEX:
                    fingerName = "Telunjuk Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_MIDDLE:
                    fingerName = "Tengah Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_RING:
                    fingerName = "Manis Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_RIGHT_LITTLE:
                    fingerName = "Kelingking Kanan";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_THUMB:
                    fingerName = "Jempol Kiri";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_INDEX:
                    fingerName = "Telunjuk Kiri";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_MIDDLE:
                    fingerName = "Tengah Kiri";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_RING:
                    fingerName = "Manis Kiri";
                    break;
                case FIR_FINGER_POSITION.FFP_LEFT_LITTLE:
                    fingerName = "Kelingking Kiri";
                    break;
                default:
                    fingerName = "Tak Terdeteksi";
                    break;
            }

            return fingerName;
        }

        private void InitTempDirectory(string path)
        {
            tempPath = Path.Combine(path, "temp");
            DirectoryInfo di = Directory.CreateDirectory(tempPath);
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }

        private bool GetCertsFromNetwork()
        {
            BlowFish blowFish = new BlowFish("1m1gras1");
            string fileName;
            string destFile;
            string result;

            try
            {

                bool isLocal = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLocal"]);
                string NetPath = ConfigurationManager.AppSettings["CertsPath"];
                string uri = ConfigurationManager.AppSettings["Uri"];
                string encryptedUsername = ConfigurationManager.AppSettings["Username"];
                string encryptedPassword = ConfigurationManager.AppSettings["Password"];

                string username = blowFish.Decrypt_CBC(encryptedUsername);
                string password = blowFish.Decrypt_CBC(encryptedPassword);

                if (!isLocal)
                {
                    result = NetworkShare.DisconnectFromShare(@uri, true);

                    result = NetworkShare.ConnectToShare(@uri, username, password);

                    if (result != null)
                    {
                        MessageBox.Show("Terjadi Kesalahan" + Environment.NewLine + result, "Error: ReadCertFromNetwork");
                        return false;
                    }
                }

                if (System.IO.Directory.Exists(@NetPath))
                {
                    string[] files = System.IO.Directory.GetFiles(@NetPath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(tempPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    MessageBox.Show("Direktori sertifikat tidak ditemukan", "Error: ReadCert");
                    return false;
                }

                if (!isLocal)
                {
                    result = NetworkShare.DisconnectFromShare(@uri, true);
                    if (result != null)
                    {
                       MessageBox.Show("Terjadi Kesalahan" + Environment.NewLine + result, "Error: DisconnectFromShare");
                       return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat pembacaan sertifikat." + Environment.NewLine +
                                "Err Msg: " + ex.Message, "Error: ReadCertFromNetwork");
                return false;
            }

            return true;
        }

        private void SaveImagetoTemp(Image img, string path)
        {
            img.Save(path, ImageFormat.Jpeg);
        }

		void EventCallbackThreadHelper(MMM.Readers.FullPage.EventCode aEventType)
		{
			if (_threadHelperControl.InvokeRequired)
			{
				_threadHelperControl.Invoke(
					new MMM.Readers.FullPage.EventDelegate(EventCallback),
					new object[] { aEventType }
				);
			}
			else
			{
				EventCallback(aEventType);
			}
		}

		async void EventCallback(MMM.Readers.FullPage.EventCode aEventType)
		{
			try
			{
				LogEvent(aEventType);

				switch (aEventType)
				{
					case MMM.Readers.FullPage.EventCode.SETTINGS_INITIALISED:
						{
							// You may wish to change the settings immediately after they have 
							// been loaded - for example, to turn off options that you do not 
							// want.

                              var dataToSend = new
                            {
                                status = "initializing"
                            };

                            var jsonData = JsonSerializer.Serialize(dataToSend);

                            await SendJsonToClients(jsonData);

							MMM.Readers.FullPage.ReaderSettings settings;
							MMM.Readers.ErrorCode errorCode = MMM.Readers.FullPage.Reader.GetSettings(
								out settings
							);

							if (errorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
							{
                                if (settings.puCameraSettings.puSplitImage == false)
                                    this.tabControl.Controls.Remove(this.ImagesRearTab);

                                settings.puDataToSend.send |=
                                    MMM.Readers.FullPage.DataSendSet.Flags.DOCMARKERS
                                    |MMM.Readers.FullPage.DataSendSet.Flags.SMARTCARD;

                                settings.puDataToSend.special |=
                                    MMM.Readers.FullPage.DataSendSet.Flags.VISIBLEIMAGE;
                                //uncomment if want to set crop codeline as default
                                //|MMM.Readers.FullPage.DataSendSet.Flags.IRIMAGE; 

                                #region Settings for EPassport
                                if (isEpaspor)
                                {
                                    settings.puDataToSend.rfid.puDGFile[1] = 1;
                                    settings.puDataToSend.rfid.puDG1MRZData = 1;
                                    settings.puDataToSend.rfid.puDGFile[2] = 1;
                                    settings.puDataToSend.rfid.puDG2FaceJPEG = 1;
                                    settings.puDataToSend.rfid.puDGFile[3] = 1;
                                    settings.puDataToSend.rfid.puDG3Fingerprints = 1;
                                    settings.puDataToSend.rfid.puActiveAuthentication = 1;
                                    settings.puDataToSend.rfid.puGetTerminalAuthStatus = 1;
                                    settings.puDataToSend.rfid.puPassiveAuthentication = 1;
                                    settings.puDataToSend.rfid.puGetChipAuthStatus = 1;
                                    settings.puDataToSend.rfid.puGetSACStatus = 1;
                                    settings.puDataToSend.rfid.puGetBACStatus = 1;
                                    settings.puImageSettings.faceFind = false;

                                    settings.puRFIDSettings.puRFProcessSettings.puExternalCSCMode = MMM.Readers.Modules.RF.ExternalCertMode.ECM_CERT_FILE_STORE;
                                    settings.puRFIDSettings.puRFProcessSettings.puExternalCVCertsMode = MMM.Readers.Modules.RF.ExternalCertMode.ECM_CERT_FILE_STORE;
                                    settings.puRFIDSettings.puRFProcessSettings.puExternalDSCMode = MMM.Readers.Modules.RF.ExternalCertMode.ECM_CERT_FILE_STORE;
                                    settings.puRFIDSettings.puRFProcessSettings.puExternalPrivateKeyMode = MMM.Readers.Modules.RF.ExternalCertMode.ECM_CERT_FILE_STORE;
                                    settings.puRFIDSettings.puRFProcessSettings.puSACEnabled = true;
                                    settings.puRFIDSettings.puRFProcessSettings.puEACEnabled = true;
                                    settings.puRFIDSettings.puRFProcessSettings.puEACVersion = 2;

                                    char[] realPath = settings.puRFIDSettings.puRFProcessSettings.puCertsDir;
                                    int realLength = realPath.Length;

                                    char[] newPath = tempPath.ToCharArray();
                                    int newLength = newPath.Length;

                                    char[] renewedPath = new char[realLength];

                                    for (int i = 0; i < realLength; i++)
                                    {
                                        if (i < newLength)
                                        {
                                            renewedPath[i] = newPath[i];
                                        }
                                        else
                                        {
                                            renewedPath[i] = realPath[i];
                                        }
                                    }
                                    settings.puRFIDSettings.puRFProcessSettings.puCertsDir = renewedPath;
                                }
                                else
                                {
                                    settings.puDataToSend.rfid.puDGFile[1] = 0;
                                    settings.puDataToSend.rfid.puDG1MRZData = 0;
                                    settings.puDataToSend.rfid.puDGFile[2] = 0;
                                    settings.puDataToSend.rfid.puDG2FaceJPEG = 0;
                                    settings.puDataToSend.rfid.puDGFile[3] = 0;
                                    settings.puDataToSend.rfid.puDG3Fingerprints = 0;
                                    settings.puDataToSend.rfid.puActiveAuthentication = 0;
                                    settings.puDataToSend.rfid.puGetTerminalAuthStatus = 0;
                                    settings.puDataToSend.rfid.puPassiveAuthentication = 0;
                                    settings.puDataToSend.rfid.puGetChipAuthStatus = 0;
                                    settings.puDataToSend.rfid.puGetSACStatus = 0;
                                    settings.puDataToSend.rfid.puGetBACStatus = 0;

                                    //UPDATE ON 24-12-2021
                                    settings.puImageSettings.faceFind = false;


                                    settings.puRFIDSettings.puRFProcessSettings.puSACEnabled = false;
                                    settings.puRFIDSettings.puRFProcessSettings.puEACEnabled = false;
                                }
                                #endregion Settings for EPassport

                                MMM.Readers.FullPage.Reader.UpdateSettings(settings);

                                MMM.Readers.FullPage.Reader.EnableLogging(
                                    true,
                                    settings.puLoggingSettings.logLevel,
                                    (int)settings.puLoggingSettings.logMask,
                                    "HLNonBlockingExample.Net.log"
                                );
							}
							else
							{
								MessageBox.Show(
									"GetSettings failure, check for Settings " +
									"structure mis-match. Error: " +
									errorCode.ToString(),
									"Error",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error
								);
							}
							break;
						}
					case MMM.Readers.FullPage.EventCode.DOC_ON_WINDOW:
						{
							prDocStartTime = System.DateTime.UtcNow;
							Clear();
							break;
						}
					case MMM.Readers.FullPage.EventCode.PLUGINS_INITIALISED:
						{
							int lIndex = 0;
							string lPluginName = "";

							while (
								MMM.Readers.FullPage.Reader.GetPluginName(
									ref lPluginName,
									lIndex
								) == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED &&
								lPluginName.Length > 0
							)
							{
								ListViewItem thisItem = TimingsList.Items.Add(
									System.DateTime.UtcNow.ToLongTimeString()
								);
								thisItem.SubItems.Add("Plugin Found");
								thisItem.SubItems.Add("");
								thisItem.SubItems.Add(lPluginName);
								++lIndex;

								//							//Example of how to enable a plugin
								//							MMM.Readers.FullPage.Reader.EnablePlugin(
								//								lPluginName,
								//								true
								//							);
							}
							break;
						}
					case MMM.Readers.FullPage.EventCode.END_OF_DOCUMENT_DATA:
						{
							System.TimeSpan duration = (System.DateTime.UtcNow - prDocStartTime);
							float docTime = duration.Ticks / System.TimeSpan.TicksPerSecond;
							statusBar.Panels[1].Text =
								"Time: " + docTime.ToString() + "s";

                            var scan_foto = new
                            {
                                Vis = base64VIS
                            };

                            var scan_data = new
                            {
                                surname = surname,
                                forename = forename,
                                kewarganegaraan = kewarganegaraan,
                                issuingState = issuingState,
                                gender = gender,
                                dob = dob,
                                docNumber = docNumber,
                                docType = docType,
                                resultState = resultState,
                                resultStateDetail = resultStateDetail
                            };

                            var dataToSend = new Dictionary<string, object>();
                            if (isEpaspor)
                            {
                                var scan_epaspor = new
                                {
                                    AAstatus = AAstatus,
                                    PAstatus = PAstatus,
                                    CAstatus = CAstatus,
                                    TAstatus = TAstatus,
                                    SACstatus = SACstatus,
                                    DOC_Signer = DOC_Signer,
                                    base64Finger1 = base64Finger1,
                                    base64Finger2 = base64Finger2,
                                    ChipId = ChipId
                                };

                                dataToSend = new Dictionary<string, object>
                                {
                                    { "scan_foto", scan_foto },
                                    { "scan_data", scan_data },
                                    { "scan_epaspor", scan_epaspor }
                                };
                            }
                            else
                            {
                                dataToSend = new Dictionary<string, object>
                                {
                                    { "scan_foto", scan_foto },
                                    { "scan_data", scan_data }
                                };
                            }

                            var jsonData = JsonSerializer.Serialize(dataToSend);

                            await SendJsonToClients(jsonData);

							break;
						}
				}

				UpdateState(MMM.Readers.FullPage.Reader.GetState());
			}
			catch (Exception e)
			{
				LogError(0, e.Message);
			}
		}

		void Clear()
		{
            richTextBoxCodeline.Text = "";
			lblSurname.Text = "";
			lblForenames.Text = "";
			lblNationality.Text = "";
            lblIssuingState.Text = "";
			lblSex.Text = "";
			lblDateOfBirth.Text = "";
			lblDocumentNumber.Text = "";
			lblDocumentType.Text = "";
			irImage.Image = null;
			visibleImage.Image = null;
			photoImage.Image = null;
			uvImage.Image = null;

            irImageRear.Image = null;
            visibleImageRear.Image = null;
            uvImageRear.Image = null;

			lblRFCodeline.Text = "";
			lblRFSurname.Text = "";
			lblRFForenames.Text = "";
			lblRFNationality.Text = "";
            lblRFIssuingState.Text = "";
			lblRFSex.Text = "";
			lblRFDateOfBirth.Text = "";
			lblRFDocNumber.Text = "";
			rfImage.Image = null;
            pbFinger1.Image = null;
            pbFinger2.Image = null;
			validatedList.Items.Clear();
			dataFileList.Items.Clear();

            lblFinger1Type.Text = "-";
            lblFinger2Type.Text = "-";

            lblChipId.Text = "";
            lblAirBaudRate.Text = "";
            lblBACStatus.Text = "";
            lblSACStatus.Text = "";

            lblAAStatus.Text = "";
            lblPAStatus.Text = "";
            lblTAStatus.Text = "";
            lblCAStatus.Text = "";

            lblSACStatus.BackColor = Color.Transparent;
            lblAAStatus.BackColor = Color.Transparent;
            lblPAStatus.BackColor = Color.Transparent;
            lblTAStatus.BackColor = Color.Transparent;
            lblCAStatus.BackColor = Color.Transparent;
        }

		void UpdateState(MMM.Readers.FullPage.ReaderState state)
		{
			statusBar.Panels[0].Text = "State:" + state.ToString();

            System.TimeSpan duration = (System.DateTime.UtcNow - prDocStartTime);
            float docTime = duration.Ticks / System.TimeSpan.TicksPerSecond;
            statusBar.Panels[1].Text =
                "Time: " + docTime.ToString() + "s";
		}

		void ErrorCallbackThreadHelper(
			MMM.Readers.ErrorCode aErrorCode,
			string aErrorMessage
		)
		{
			if (_threadHelperControl.InvokeRequired)
			{
				_threadHelperControl.Invoke(
					new MMM.Readers.ErrorDelegate(ErrorCallback),
					new object[] { aErrorCode, aErrorMessage }
				);
			}
			else
			{
				ErrorCallback(aErrorCode, aErrorMessage);
			}
		}

        void ErrorCallback(MMM.Readers.ErrorCode aErrorCode, string aErrorMessage)
        {
            LogError(aErrorCode, aErrorMessage);
        }

        void WarningCallbackThreadHelper(
            MMM.Readers.WarningCode aWarningCode,
            string aWarningMessage
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                _threadHelperControl.Invoke(
                    new MMM.Readers.WarningDelegate(WarningCallback),
                    new object[] { aWarningCode, aWarningMessage }
                );
            }
            else
            {
                WarningCallback(aWarningCode, aWarningMessage);
            }
        }

        void WarningCallback(MMM.Readers.WarningCode aWarningCode, string aWarningMessage)
        {
            LogWarning(aWarningCode, aWarningMessage);
        }

        bool CertificateCallbackThreadHelper(
			byte[] aCertIdentifier,
			MMM.Readers.Modules.RF.CertType aCertType,
			out byte[] aCertBuffer
		)
		{
			if (_threadHelperControl.InvokeRequired)
			{
				aCertBuffer = null;
				object[] lParams = new object[]
				{ 
					aCertIdentifier, aCertType, aCertBuffer 
				};
				bool lResult = (bool)_threadHelperControl.Invoke(
					new MMM.Readers.FullPage.CertificateDelegate(CertificateCallback),
					lParams
					);

				aCertBuffer = (byte[])lParams[2];

				return lResult;
			}
			else
			{
				return CertificateCallback(aCertIdentifier, aCertType, out aCertBuffer);
			}
		}

		bool CertificateCallback(
			byte[] aCertIdentifier,
			MMM.Readers.Modules.RF.CertType aCertType,
			out byte[] aCertBuffer
		)
		{
			bool lSuccess = false;
			OpenFileDialog fileSelector = new OpenFileDialog();
			aCertBuffer = null;

			//aCertType determines what data is held in aCertIdentifier
			//switch (aCertType)
			//{
			//    case MMM.Readers.Modules.RF.CertType.CT_CERTIFICATE_REVOCATION_LIST:
			//        //ASN.1 DER Encoded Issuer and Serial Number
			//        break;
			//    case MMM.Readers.Modules.RF.CertType.CT_COUNTRY_SIGNER_CERT:
			//        //ASN.1 DER Encoded Authority Key Identifier
			//        break;
			//    case MMM.Readers.Modules.RF.CertType.CT_DOC_SIGNER_CERT:
			//        //ASN.1 DER Encoded SignerIdentifier
			//        break;
			//    case MMM.Readers.Modules.RF.CertType.CT_CVCA_CERT:
			//        //Country Verifier Certificate Authority Reference (CV CAR) ascii string
			//    case MMM.Readers.Modules.RF.CertType.CT_DV_CERT:
			//        //Document Verifier Certificate Authority Reference (DV CAR) ascii string
			//    case MMM.Readers.Modules.RF.CertType.CT_IS_CERT:
			//        //Insepction System Certificate Authority Reference (IS CAR) ascii string
			//    case MMM.Readers.Modules.RF.CertType.CT_IS_PRIVATE_KEY:
			//        //Inspection System Certificate Holder Reference (IS CHR) ascii string
			//        break;

			//}

			fileSelector.Title = "Open external certificate: " + aCertType.ToString();
			fileSelector.InitialDirectory = "c:\\certs\\";
			fileSelector.Filter = "Certs and keys|*.cer;*.der;*.cvcert;*.pkcs8;*.bin|All files (*.*)|*.*";
			fileSelector.FilterIndex = 1;
			fileSelector.RestoreDirectory = true;

			if (fileSelector.ShowDialog() == DialogResult.OK)
			{
				try
				{
					System.IO.Stream fs = null;
					if ((fs = fileSelector.OpenFile()) != null)
					{
						aCertBuffer = new byte[fs.Length];
						fs.Read(aCertBuffer, 0, aCertBuffer.Length);
						fs.Close();
						lSuccess = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}

			return lSuccess;
		}

        bool SignRequestCallbackThreadHelper(
            byte[] aBufferToSign,
            byte[] aCertificateBuffer,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aSignature
        )
        {
            if (_threadHelperControl.InvokeRequired)
            {
                aSignature = null;
                object[] lParams = new object[]
                {
                            aBufferToSign,
                            aCertificateBuffer,
                            aCertType,
                            aSignature
                };
                bool lResult = (bool)_threadHelperControl.Invoke(
                    new MMM.Readers.FullPage.SignRequestDelegate(SignRequestCallback),
                    lParams
                    );

                aSignature = (byte[])lParams[3];
                return lResult;
            }
            else
            {
                return SignRequestCallback(
                    aBufferToSign,
                    aCertificateBuffer,
                    aCertType,
                    out aSignature
                    );
            }
        }

        bool SignRequestCallback(
            byte[] aBufferToSign,
            byte[] aCertificateBuffer,
            MMM.Readers.Modules.RF.CertType aCertType,
            out byte[] aSignature
        )
        {
            bool lSuccess = false;
            aSignature = null;

            MessageBox.Show(
                "SignRequestCallback Type: " + aCertType.ToString() +
                " Cert Buffer Len: " + System.Convert.ToString(aCertificateBuffer.Length),
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1
                );

            //-Decode aCertificateBuffer
            //-Read certificate reference
            //-Sign aBufferToSign with relevant key
            //-Fill aSignature with the signature bytes
            //-Return success

            return lSuccess;
        }

        void LogDataItem(MMM.Readers.FullPage.DataType aDataType, object aData)
		{
			if (aDataType == MMM.Readers.FullPage.DataType.CD_SWIPE_MSR_DATA)
			{
				MMM.Readers.Modules.Swipe.MsrData msrData =
					(MMM.Readers.Modules.Swipe.MsrData)aData;

				LogDataItem("MSR_TRACK_1", msrData.Track1);
				LogDataItem("MSR_TRACK_2", msrData.Track2);
				LogDataItem("MSR_TRACK_3", msrData.Track3);
			}
			else if (aDataType == MMM.Readers.FullPage.DataType.CD_AAMVA_DATA)
			{
				MMM.Readers.AAMVAData aamvaData = (MMM.Readers.AAMVAData)aData;

				LogDataItem("AAMVA_FULL_NAME", aamvaData.Parsed.FullName);
				LogDataItem("AAMVA_LICENCE_NUMBER", aamvaData.Parsed.LicenceNumber);
			}
			else if (aDataType > MMM.Readers.FullPage.DataType.CD_PLUGIN)
			{
				// Here is a generic example of getting data out of a plugin
				MMM.Readers.FullPage.PluginData pluginData =
					(MMM.Readers.FullPage.PluginData)aData;

                //richTextBoxCodeline.Text = pluginData.puData;
				ListViewItem thisItem = dataFileList.Items.Add(pluginData.puDataFormat.ToString());

				string lInfo =
					pluginData.puFeatureName + " " + pluginData.puFieldName + ": ";
				if (pluginData.puData is string)
					LogDataItem(
						aDataType.ToString(),
						lInfo + (string)pluginData.puData
					);
				else if (pluginData.puData is byte[])
					LogDataItem(
						aDataType.ToString(),
						lInfo + ((byte[])pluginData.puData).Length + " bytes"
					);
				else
					LogDataItem(aDataType.ToString(), lInfo + aData);
			}
            else
            {
                LogDataItem(aDataType.ToString(), aData);
            }
		}
		void LogDataItem(string aDataType, object aData)
		{
			System.TimeSpan duration = (System.DateTime.UtcNow - prDocStartTime);
			float dataItemTime = duration.Ticks / System.TimeSpan.TicksPerSecond;
			ListViewItem thisItem = TimingsList.Items.Add(dataItemTime.ToString() + "s");
			thisItem.SubItems.Add(aDataType);
			thisItem.SubItems.Add("");

			if (aData != null)
			{
				if (aData is string || aData is int)
				{
					thisItem.SubItems.Add(aData.ToString());
				}
				else
				{
					thisItem.SubItems.Add(aData.GetType().ToString());
				}
			}
		}

		void LogEvent(MMM.Readers.FullPage.EventCode aEventType)
		{
			ListViewItem thisItem = TimingsList.Items.Add(System.DateTime.UtcNow.ToLongTimeString());
			thisItem.SubItems.Add(aEventType.ToString());
            if (aEventType == MMM.Readers.FullPage.EventCode.READER_STATE_CHANGED)
            {
                thisItem.SubItems.Add("");
                thisItem.SubItems.Add(MMM.Readers.FullPage.Reader.GetState().ToString());
            }
		}

        void LogError(MMM.Readers.ErrorCode aErrorCode, string aErrorMessage)
        {
            ListViewItem thisItem = TimingsList.Items.Add(System.DateTime.UtcNow.ToLongTimeString());
            thisItem.SubItems.Add(aErrorCode.ToString());
            thisItem.SubItems.Add("");
            thisItem.SubItems.Add(aErrorMessage);
        }

        void LogWarning(MMM.Readers.WarningCode aWarningCode, string aWarningMessage)
        {
            ListViewItem thisItem = TimingsList.Items.Add(System.DateTime.UtcNow.ToLongTimeString());
            thisItem.SubItems.Add(aWarningCode.ToString());
            thisItem.SubItems.Add("");
            thisItem.SubItems.Add(aWarningMessage);
        }

        void SetResultAndButtonState(string status, string statusLog)
        {
            if (status == "Lulus")
            {
                if (tbHasilUji.Text != "Tidak Lulus")
                {
                    tbHasilUji.Text = status;
                    btnCetakUlang.Enabled = true;
                    btnSerahkan.Enabled = true;
                     resultState = status;
                }
            }
            else
            {
                tbHasilUji.Text = status;
                btnCetakUlang.Enabled = true;
                btnSerahkan.Enabled = false;
                 resultState = status;
            }

            if (statusLog != "")
            {
                if (rtbLog.Text == "")
                {
                    rtbLog.AppendText("-- " + statusLog);
                }
                else {
                    rtbLog.AppendText("\r\n" + "-- " + statusLog);
                }
            }
            resultStateDetail = rtbLog.Text;
        }

        protected System.DateTime prDocStartTime = System.DateTime.UtcNow;

		private void fileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

        private void btnZoom_Click(object sender, System.EventArgs e)
        {Button btn = (Button)sender;
            string btnName = btn.Name;

            if (btnName == "btnZoomVis")
            {
                if (visibleImage.Image != null)
                {
                    ZoomPreview preview = new ZoomPreview(visibleImage.Image);
                    preview.SetSizeMode(4);
                    preview.ShowDialog();
                    preview.Dispose();
                }
            }
            else if (btnName == "btnZoomIr")
            {
                if (irImage.Image != null)
                {
                    ZoomPreview preview = new ZoomPreview(irImage.Image);
                    preview.SetSizeMode(4);
                    preview.ShowDialog();
                    preview.Dispose();
                }
            }
            else if (btnName == "btnZoomUv")
            {
                if (uvImage.Image != null)
                {
                    ZoomPreview preview = new ZoomPreview(uvImage.Image);
                    preview.SetSizeMode(4);
                    preview.ShowDialog();
                    preview.Dispose();
                }
            }
            else if (btnName == "btnZoomFinger1")
            {
                if (uvImage.Image != null)
                {
                    ZoomPreview preview = new ZoomPreview(pbFinger1.Image);
                    preview.SetSizeMode(2);
                    preview.ShowDialog();
                    preview.Dispose();
                }
            }
            else if (btnName == "btnZoomFinger2")
            {
                if (uvImage.Image != null)
                {
                    ZoomPreview preview = new ZoomPreview(pbFinger2.Image);
                    preview.SetSizeMode(2);
                    preview.ShowDialog();
                    preview.Dispose();
                }
            }

        }

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				MMM.Readers.FullPage.Reader.Shutdown();
			}
			catch (System.DllNotFoundException except)
			{
				// only happens in the case where you started without MMMReaderHighLevelAPI.dll in the search path
			}
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
            tabControl.TabPages.Remove(tabPage1);
            tabControl.TabPages.Remove(UHFTab);
            tabControl.TabPages.Remove(TimingsTab);
            tabControl.TabPages.Remove(ImagesRearTab);
            //Initialise();
            // we wont actually do the initialisation in load so that the window opens before we do it, as it can take a while.
            timer1.Start();
		}

        private void Initialise()
        {
            try
            {
                MMM.Readers.FullPage.Reader.EnableLogging(
                    true,
                    1,
                    -1,
                    "HLNonBlockingExample.Net.log"
                );

                UpdateState(MMM.Readers.FullPage.ReaderState.READER_NOT_INITIALISED);
                prDocStartTime = System.DateTime.UtcNow;

                // Thread helper delegates are used to avoid thread-safety issues, particularly 
                // with .NET framework 2.0				
                MMM.Readers.ErrorCode lResult = MMM.Readers.ErrorCode.NO_ERROR_OCCURRED;

                Microsoft.Win32.SystemEvents.PowerModeChanged += new Microsoft.Win32.PowerModeChangedEventHandler(OnPowerModeChanged);

                lResult = MMM.Readers.FullPage.Reader.Initialise(
                    new MMM.Readers.FullPage.DataDelegate(DataCallbackThreadHelper),
                    new MMM.Readers.FullPage.EventDelegate(EventCallbackThreadHelper),
                    new MMM.Readers.ErrorDelegate(ErrorCallbackThreadHelper),
                    new MMM.Readers.FullPage.CertificateDelegate(CertificateCallbackThreadHelper),
                    true,
                    false
                );

                if (lResult != MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                    MessageBox.Show(
                        "Initialise failed - " + lResult.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1
                        );
                }
                MMM.Readers.FullPage.Reader.SetWarningCallback(new MMM.Readers.WarningDelegate(WarningCallbackThreadHelper));

                //Example of how to set the signrequest callback
                //MMM.Readers.FullPage.Reader.SetSignRequestCallback(
                //    SignRequestCallbackThreadHelper
                //);
            }
            catch (System.DllNotFoundException except)
            {
                MessageBox.Show(
                    except.Message +
                    "\nEnsure the \"working directory\" of the application is set to the " +
                    "3M Page Reader\\bin folder. When run within the IDE, set this through " +
                    "Properties -> Configuration Properties -> Debugging"
                );
            }
        }

		private void InitialiseTimer(object sender, System.EventArgs e)
		{
			timer1.Stop();

			try
			{
				MMM.Readers.FullPage.Reader.EnableLogging(
					true,
					1,
					-1,
					"HLNonBlockingExample.Net.log"
				);

				UpdateState(MMM.Readers.FullPage.ReaderState.READER_NOT_INITIALISED);
				prDocStartTime = System.DateTime.UtcNow;

				// Thread helper delegates are used to avoid thread-safety issues, particularly 
				// with .NET framework 2.0				
                MMM.Readers.ErrorCode lResult = MMM.Readers.ErrorCode.NO_ERROR_OCCURRED;

                Microsoft.Win32.SystemEvents.PowerModeChanged += new Microsoft.Win32.PowerModeChangedEventHandler(OnPowerModeChanged);

                lResult = MMM.Readers.FullPage.Reader.Initialise(
                    new MMM.Readers.FullPage.DataDelegate(DataCallbackThreadHelper),
                    new MMM.Readers.FullPage.EventDelegate(EventCallbackThreadHelper),
                    new MMM.Readers.ErrorDelegate(ErrorCallbackThreadHelper),
                    new MMM.Readers.FullPage.CertificateDelegate(CertificateCallbackThreadHelper),
                    true,
                    false
                );

                if (lResult != MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                    MessageBox.Show(
                        "Initialise failed - " + lResult.ToString(),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1
                        );
                }
                MMM.Readers.FullPage.Reader.SetWarningCallback(new MMM.Readers.WarningDelegate(WarningCallbackThreadHelper));


				//			//Example of how to set the signrequest callback
				//			MMM.Readers.FullPage.Reader.SetSignRequestCallback(
				//				SignRequestCallbackThreadHelper
				//			);
			}
			catch (System.DllNotFoundException except)
			{
				MessageBox.Show(
                    except.Message +
				    "\nEnsure the \"working directory\" of the application is set to the " +
				    "3M Page Reader\\bin folder. When run within the IDE, set this through " +
				    "Properties -> Configuration Properties -> Debugging"
                );
			}
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			MMM.Readers.FullPage.Reader.SetState(
				MMM.Readers.FullPage.ReaderState.READER_ENABLED,
				true
			);
			UpdateState(MMM.Readers.FullPage.ReaderState.READER_ENABLED);
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			MMM.Readers.FullPage.Reader.SetState(
				MMM.Readers.FullPage.ReaderState.READER_DISABLED,
				true
				);
			UpdateState(MMM.Readers.FullPage.ReaderState.READER_DISABLED);
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			MMM.Readers.FullPage.Reader.SetState(
				MMM.Readers.FullPage.ReaderState.READER_ASLEEP,
				true
				);
			UpdateState(MMM.Readers.FullPage.ReaderState.READER_ASLEEP);
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			MMM.Readers.FullPage.Reader.SetState(
				MMM.Readers.FullPage.ReaderState.READER_SUSPENDED,
				true
				);
			UpdateState(MMM.Readers.FullPage.ReaderState.READER_SUSPENDED);
		}

        private MMM.Readers.FullPage.ReaderState prPreviousState = MMM.Readers.FullPage.ReaderState.READER_ENABLED;
        private void OnPowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case Microsoft.Win32.PowerModes.Resume:
                    // delay before starting up as the USB subsystem seems to take a while to startup.
                    // If you don't delay, things will recover via the error recovery system, but you'll
                    // get some "access denied" errors from USB devices until it is fully started.
                    System.Threading.Thread.Sleep(5000);
                    MMM.Readers.FullPage.Reader.SetState(prPreviousState, true);
                    UpdateState(prPreviousState);
                    break;

                case Microsoft.Win32.PowerModes.Suspend:
                    {
                        // signal that we want to change state
                        MMM.Readers.FullPage.ReaderState lCurrentState
                             = MMM.Readers.FullPage.Reader.GetState();
                        prPreviousState = lCurrentState;

                        if ((lCurrentState != MMM.Readers.FullPage.ReaderState.READER_NOT_INITIALISED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_ERRORED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_TERMINATED) &&
                            (lCurrentState != MMM.Readers.FullPage.ReaderState.READER_SUSPENDED))
                        {
                            MMM.Readers.FullPage.Reader.SetState(
                                MMM.Readers.FullPage.ReaderState.READER_SUSPENDED,
                                true
                                );

                            UpdateState(MMM.Readers.FullPage.ReaderState.READER_SUSPENDED);

                            // Wait for the state change to be applied
                            do
                            {
                                System.Threading.Thread.Sleep(10);
                                lCurrentState = MMM.Readers.FullPage.Reader.GetState();
                            }
                            while (lCurrentState == prPreviousState);
                        }
                    }
                    break;
            }
        }

		private void SettingsDataToSend_Click(Object aSender, EventArgs aEventArgs)
		{
			DataToSend lDataToSendDlg = new DataToSend();
			lDataToSendDlg.ShowDialog();
		}

		private void SettingsSave_Click(Object aSender, EventArgs aEventArgs)
		{
			MMM.Readers.FullPage.Reader.SaveSettings();
		}

		private void WriteSettingsTextfile_Click(Object aSender, EventArgs aEventArgs)
		{
			MMM.Readers.FullPage.ReaderSettings lSettings;
			MMM.Readers.ErrorCode lErrorCode =
				MMM.Readers.FullPage.Reader.GetSettings(out lSettings);

            string lPath = ".\\settings_data.txt";

            if (lErrorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
            {
                lErrorCode = MMM.Readers.FullPage.Reader.WriteTextfileSettings(lSettings, ref lPath);
                if (lErrorCode == MMM.Readers.ErrorCode.NO_ERROR_OCCURRED)
                {
                }
            }
		}

		private void DisplayUHFTagID(MMM.Readers.FullPage.UHFTagIDData aData)
		{
			ManufacturerIDValue.Text = aData.puManufacturerID.ToString();
			MaskDesignerIDValue.Text = aData.puMaskDesignerID.ToString();
			ModelNumberValue.Text = aData.puModelNumber.ToString();

			String lSerialNum = "";
			foreach (Byte lByte in aData.puSerialNumber)
			{
				if (lSerialNum.Length != 0)
					lSerialNum += "-";
				lSerialNum += lByte.ToString("X4");
			}
			SerialNumberValue.Text = lSerialNum;
		}

        private void btnCetakUlang_Click(object sender, EventArgs e)
        {
            SentTestData data = new SentTestData
            {
                id = idAlokasi
            };
            //string fail = http.GetHTTPRequest<SentTestData>(data, failTest, true);
            //ResponseTestDokim failResponse = fail.ToObj<ResponseTestDokim>();

            //if (!failResponse.responseStatus.Equals("200"))
            //{
            //    MessageBox.Show("Ada kesalahan, mohon lakukan lagi");
            //    return;
            //}

            string realloc = http.GetHTTPRequest<SentTestData>(data, reallocate, true);
            ResponseTestReAlloc reallocateResponse = realloc.ToObj<ResponseTestReAlloc>();

            if (!reallocateResponse.responseStatus.Equals("200"))
            {
                MessageBox.Show("Ada kesalahan, mohon lakukan lagi");
                return;
            }
            
            Form form = new AlokasiUlang(tbNoPermohonan.Text, tbNoPassport.Text, reallocateResponse.responseObject.no_paspor, idAlokasi, reallocateResponse.responseObject.id, idUji, userId, cancelReallocate, exchange, saveReallocation, urlUpdateUserId, setStatus, http.token, oldStatus, oldStatusDetail);
            var result = form.ShowDialog();
            form.Dispose();
            if(result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnSerahkan_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Apakah anda ingin mengakhiri uji kualitas passport dan menyimpan data?", "Simpan Data", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    string path = tempPath;

                    Paspor pasporData = new Paspor()
                    {
                        kodePermohonan = noPermohonan,
                        idPaspor = noPassport
                    };

                    UserDPRI user = new UserDPRI()
                    {
                        id = userId
                    };

                    SentPasporData sentData = new SentPasporData()
                    {
                        paspor = pasporData,
                        id = idUji,
                        dokumenPaspor = File.Exists(path + "\\" + pasporName) ? pasporName : "",
                        dokumenPasporBase64 = File.Exists(path + "\\" + pasporName) ? GetBase64StringFromFile(path + "\\" + pasporName) : ""
                    };

                    Adddoc add = new Adddoc()
                    {
                        adddoc = sentData,
                        userId = userId
                    };

                    string response = http.GetHTTPRequest<Adddoc>(add, urlSentData, true);

                    if (response != "404")
                    {

                        ResponseSentData isSuccess = response.ToObj<ResponseSentData>();

                        if (isSuccess.result)
                        {
                            SentTestData data = new SentTestData
                            {
                                id = idAlokasi
                            };
                            string success = http.GetHTTPRequest<SentTestData>(data, successTest, true);
                            ResponseTestDokim successResponse = success.ToObj<ResponseTestDokim>();

                            if (successResponse.responseStatus.Equals("200"))
                            {
                                MessageBox.Show("Penyimpanan berhasil");
                                Application.Exit();
                            }
                            else
                            {
                                MessageBox.Show("Insert penyerahan berhasil, namun update status dokim gagal", "Error: Success Test");
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Penyimpanan belum berhasil, mohon lakukan lagi", "Error: Sent Data");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Penyimpanan belum berhasil, mohon lakukan lagi", "Error: Sent Data");
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                MessageBox.Show(msg, "Error: Serahkan paspor");
            }
        }

        private string GetBase64StringFromImage(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            Byte[] bytes = ms.ToArray();
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            return base64String;
        }

        private string GetBase64StringFromFile(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            return base64String;
        }

        private void GetFileFromBase64String(string base64, string path)
        {
            Byte[] bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(path, bytes);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if (form.Width < 1000)
            {

            }
        }

        private void label100_Click(object sender, EventArgs e)
        {

        }

        private void CallSailsLock()
        {
            try
            {
                if (!notify.ToUpper().Equals("FALSE"))
                {
                    SentSailsData data = new SentSailsData()
                    {
                        id = idUji
                    };

                    string success = http.GetHTTPRequest<SentSailsData>(data, urlSailsLock, false);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SentSailsData data = new SentSailsData()
                {
                    id = idUji,
                    type = "ujikualitas",
                    action = ""
                };

                if (!isCloseFromEdit)
                {
                    if (!notify.ToUpper().Equals("FALSE"))
                    {
                        string success = http.GetHTTPRequest<SentSailsData>(data, notify, false);
                    }
                }

                DeleteTempDirectory();

                MMM.Readers.FullPage.Reader.Shutdown();
            }
            catch (System.DllNotFoundException except)
            {
                // only happens in the case where you started without MMMReaderHighLevelAPI.dll in the search path
            }
            catch (WebException webEx)
            {

            }
            
        }

        private void DeleteTempDirectory()
        {
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah anda yakin ingin menutup aplikasi Uji Kualitas?", "Warning", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.Close();
                Environment.Exit(0);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form editForm = new EditForm(idUji, userId, notify, login, urlUpdateUserId, setStatus, http.token, noPermohonan);
            var result = editForm.ShowDialog();
            editForm.Dispose();
            if (result == DialogResult.OK)
            {
                isCloseFromEdit = true;
                this.Close();
            }
            else
            {
                isCloseFromEdit = false;
            }
        }

        public void StartServer()
        {
            mServerSocket = new ServerSocket(9000);
            mServerSocket.WaitForConnection();
        }

        

        public async void StartWebSocketServer(string url, string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine($"Listening on {url}...");

            while (true)
            {
                HttpListenerContext context = await listener.GetContextAsync();
                if (context.Request.IsWebSocketRequest)
                {
                    WebSocketContext webSocketContext = await context.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    Console.WriteLine("WebSocket connection established");

                    connectedClients.Add(webSocket);

                    try
                    {
                        await HandleWebSocketCommunication(webSocket, args);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                        }
                    }

                    //await HandleWebSocketCommunication(webSocket);
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
            }
        }

        public async Task HandleWebSocketCommunication(WebSocket webSocket, string[] args)
        {
            OnWebSocketConnected(webSocket);

            byte[] buffer = new byte[1024];
            WebSocketReceiveResult result;

            do
            {
                ArraySegment<byte> arraySegment = new ArraySegment<byte>(buffer);
                result = await webSocket.ReceiveAsync(arraySegment, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine($"Received message: {message}");
                    //byte[] responseBuffer = Encoding.UTF8.GetBytes($"{message}");
                    //await webSocket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

                    JsonDocument jsonDocument = JsonDocument.Parse(message);
                    JsonElement root = jsonDocument.RootElement;


                    JsonElement msgCode = root.GetProperty("msgCode");

                    DataModel data = JsonSerializer.Deserialize<DataModel>(msgCode.ToString());

                    Console.WriteLine(data.NomorPermohonan);
                    ProsesData(data);
                }
            }
            while (!result.CloseStatus.HasValue);

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);

            OnWebSocketDisconnected(webSocket);
        }



        public void OnWebSocketConnected(WebSocket webSocket)
        {
            Console.WriteLine("WebSocket connected.");
            // Add your custom logic for handling a new WebSocket connection here.
            // For example, you can add the connected WebSocket to a list of connected clients.
        }

        public void OnWebSocketDisconnected(WebSocket webSocket)
        {
            Console.WriteLine("WebSocket disconnected.");
            // Add your custom logic for handling a WebSocket disconnection here.
            // For example, you can remove the disconnected WebSocket from the list of connected clients.
        }

        public async Task SendJsonToClients(string json)
        {
            foreach (var client in connectedClients)
            {
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(json);
                    await client.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send message to a client: {ex.Message}");
                }
            }
        }


        private void BtnHapusData_Click(object sender, EventArgs e)
        {
            Hapus();
        }

        public void Hapus()
        {
            try
            {
                DialogResult result = MessageBox.Show("Apakah Anda Yakin Ingin Menghapus Data Pemohon?", "Warning", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    namaPemohon = "";
                    noPermohonan = "";
                    tglLahir = "";
                    noPassport = "";
                    tbNamaPemohon.Text = "";
                    tbNoPermohonan.Text = "";
                    tbNamaPemohon.Text = "";
                    tbTglLahir.Text = "";
                    tbNoPassport.Text = "";
                }


            }
            catch (Exception)
            {

            }
        }
    }
}
