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
	/// Shows an introductory pop-up.
	/// </summary>
	public partial class Intro : Form
	{
		public Intro()
		{
			InitializeComponent();
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
