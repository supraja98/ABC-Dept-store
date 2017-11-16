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

public partial class StkChkr : System.Web.UI.Page
{
    int tot,sum;
    ProClass pc = new ProClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            select();
            TextBox4.Text += "PName" + "\t\t" + "PPrice" + "\t" + "Price" + "\t" + "Qnty purchased" + "\n";
        }
        
    }
    public void select()
    {
        DropDownList1.Items.Clear();
        pc.connect();
        pc.cmd.CommandText = "select pid from producttable";
        pc.rs = pc.cmd.ExecuteReader();
        while (pc.rs.Read())
        {
            DropDownList1.Items.Add(pc.rs[0].ToString());
        }
        pc.disconnect();
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "select * from producttable where pid=@i";
        pc.cmd.Parameters.Add("@i", DropDownList1.SelectedItem.ToString());
        pc.rs = pc.cmd.ExecuteReader();
        if (pc.rs.Read())
        {
            TextBox1.Text = pc.rs[1].ToString();
            TextBox2.Text = pc.rs[2].ToString();
            TextBox5.Text = pc.rs[3].ToString();
        }
        pc.disconnect();
        TextBox3.Text = "";
    }
    int n,n1;
    int price=0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox4.Text += TextBox1.Text + "\t\t" + TextBox2.Text + "\t" + TextBox3.Text+"\t";
        pc.connect();
        pc.cmd.CommandText = "update producttable set pqnty=@q where pid=@i";
        n = Int16.Parse(TextBox5.Text);
        n1 = Int16.Parse(TextBox3.Text);
        price = Int16.Parse(TextBox2.Text);
        pc.cmd.Parameters.Add("@q", (n - n1));
        pc.cmd.Parameters.Add("@i", DropDownList1.SelectedItem.ToString());
        pc.cmd.ExecuteNonQuery();
        pc.disconnect();
        TextBox4.Text += (price * n1) + "\n";
        sum =Int16.Parse(TextBox6.Text);
        tot = sum +(price * n1);
        TextBox6.Text = tot.ToString();
       
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox4.Text = "Bill prepared successfully" + "\n";
        TextBox4.Text += Label7.Text + "\t";
        TextBox4.Text += TextBox6.Text;
        DropDownList1.Items.Clear();
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox5.Text = "";
    }
}
