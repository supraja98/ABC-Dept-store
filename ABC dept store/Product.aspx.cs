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

public partial class Product : System.Web.UI.Page
{
    ProClass pc = new ProClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            select();
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
    

    protected void LinkButton1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("StockLess.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "insert into producttable values(@i,@n,@p,@q)";
        pc.cmd.Parameters.AddWithValue("@i", TextBox1.Text);
        pc.cmd.Parameters.Add("@n", TextBox2.Text);
        pc.cmd.Parameters.Add("@p", TextBox3.Text);
        pc.cmd.Parameters.Add("@q", TextBox4.Text);
        pc.cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Data Stored Successfully')</script>");
        pc.disconnect();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "select max(pid)+1 from producttable";
        pc.rs = pc.cmd.ExecuteReader();
        while (pc.rs.Read())
        {
            TextBox1.Text = pc.rs[0].ToString();
        }
        pc.disconnect();
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";

    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "update producttable set pname=@n,pprice=@p,pqnty=@q where pid=@i";
        pc.cmd.Parameters.Add("@n", TextBox5.Text);
        pc.cmd.Parameters.Add("@p", TextBox6.Text);
        pc.cmd.Parameters.Add("@q", TextBox7.Text);
        pc.cmd.Parameters.AddWithValue("@i", DropDownList1.SelectedItem.ToString());
        pc.cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Data updated successfully')</script>");
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
            TextBox5.Text = pc.rs[1].ToString();
            TextBox6.Text = pc.rs[2].ToString();
            TextBox7.Text = pc.rs[3].ToString();
        }
        pc.disconnect();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        pc.connect();
        pc.cmd.CommandText = "delete from producttable where pid=@i";
        pc.cmd.Parameters.AddWithValue("@i", DropDownList1.SelectedItem.ToString());
        pc.cmd.ExecuteNonQuery();
        Response.Write("<script>alert('data deleted')</script>");
        pc.disconnect();
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        select();
    }
}
