using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

/// <summary>
/// Summary description for Empl
/// </summary>
public class Empl
{
    public SqlCommand cmd;
    public SqlConnection con;
    public SqlDataReader rs;
	
	public Empl()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void connect()
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\USERS\\JOHN\\DOCUMENTS\\VISUAL STUDIO 2005\\WEBSITES\\WEBSITE2\\APP_DATA\\EMPREC.MDF;Integrated Security=True;User Instance=True");
        con.Open();
        cmd = new SqlCommand();
        cmd.Connection = con;

    }
    public void disconnect()
    {
        con.Close();
        cmd.Dispose();
    }

}
