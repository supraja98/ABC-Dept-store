using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class StockLess : System.Web.UI.Page
{
    ProClass pc = new ProClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "select * from producttable where pqnty<=@q";
        pc.cmd.Parameters.Add("@q", 10);
        pc.rs = pc.cmd.ExecuteReader();
        TextBox1.Text += "pID" + "\t" + "pName" + "\t\t" + "pPrice" + "\t" + "pQnty" + "\n";
        while (pc.rs.Read())
        {
            for (int i = 0; i <= 3; i++)
                TextBox1.Text += pc.rs[i].ToString() + "\t";
            TextBox1.Text += "\n";
            
        }
        pc.disconnect();

    }
}
