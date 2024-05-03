using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HLNonBlockingExample.NET
{
	/// <summary>
	/// Summary description for FormBACKeyCorrection.
	/// </summary>
	public class FormBACKeyCorrection : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBoxLine1;
		private System.Windows.Forms.TextBox textBoxLine2;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxLine3;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormBACKeyCorrection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void SetCodeline(string aCodeline)
		{
			//MMM.Readers.CodelineData lCodelineData = new MMM.Readers.CodelineData(aCodeline);
			string[] lines = aCodeline.Split('\r');

			if (lines.Length > 0)
			{
				textBoxLine1.Text = lines[0];
			}
			if (lines.Length > 1)
			{
				textBoxLine2.Text = lines[1];
			}
			if (lines.Length > 2)
			{
				textBoxLine3.Text = lines[2];
			}
		}

        public void SetCodelines(string aCodeline1, string aCodeline2, string aCodeline3)
        {
            textBoxLine1.Text = aCodeline1;            
            textBoxLine2.Text = aCodeline2;            
            textBoxLine3.Text = aCodeline3;
        }

		public string GetCodeline()
		{
			return textBoxLine1.Text + textBoxLine2.Text + textBoxLine3.Text;
		}

        public string GetCodeline1()
        {
            return textBoxLine1.Text;
        }

        public string GetCodeline2()
        {
            return textBoxLine2.Text;
        }

        public string GetCodeline3()
        {
            return textBoxLine3.Text;
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxLine1 = new System.Windows.Forms.TextBox();
			this.textBoxLine2 = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxLine3 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBoxLine1
			// 
			this.textBoxLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLine1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxLine1.Location = new System.Drawing.Point(15, 24);
			this.textBoxLine1.Name = "textBoxLine1";
			this.textBoxLine1.Size = new System.Drawing.Size(380, 23);
			this.textBoxLine1.TabIndex = 0;
			this.textBoxLine1.Text = "";
			// 
			// textBoxLine2
			// 
			this.textBoxLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLine2.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxLine2.Location = new System.Drawing.Point(13, 56);
			this.textBoxLine2.Name = "textBoxLine2";
			this.textBoxLine2.Size = new System.Drawing.Size(380, 23);
			this.textBoxLine2.TabIndex = 1;
			this.textBoxLine2.Text = "textBox2";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(119, 128);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(215, 128);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "&Cancel";
			// 
			// textBoxLine3
			// 
			this.textBoxLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxLine3.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxLine3.Location = new System.Drawing.Point(13, 88);
			this.textBoxLine3.Name = "textBoxLine3";
			this.textBoxLine3.Size = new System.Drawing.Size(380, 23);
			this.textBoxLine3.TabIndex = 4;
			this.textBoxLine3.Text = "textBox3";
			// 
			// FormBACKeyCorrection
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(408, 166);
			this.Controls.Add(this.textBoxLine3);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.textBoxLine2);
			this.Controls.Add(this.textBoxLine1);
			this.Name = "FormBACKeyCorrection";
			this.Text = "FormBACKeyCorrection";
			this.ResumeLayout(false);

		}
		#endregion

	}
}
