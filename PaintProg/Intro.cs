/*
 * Created by SharpDevelop.
 * User: Jiří
 * Date: 7. 5. 2018
 * Time: 20:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PaintProg
{
	/// <summary>
	/// Description of Intro.
	/// </summary>
	public partial class Intro : Form
	{
		public Intro()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
