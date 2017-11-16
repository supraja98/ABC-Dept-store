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

public partial class Employee : System.Web.UI.Page
{
    Empl em = new Empl();
    String str1, str2;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        em.connect();
        em.cmd.CommandText = "select * from EmpTab where Eid=@i";
        em.cmd.Parameters.Add("@i", TextBox1.Text);
        em.rs = em.cmd.ExecuteReader();
        if (em.rs.Read())
        {
            str1 = em.rs[7].ToString();
        } 
        str2 = TextBox2.Text;
       // Response.Write(TextBox1.Text + "   " + TextBox2.Text);
        if (String.Equals(str1, str2) == true)
        {
            Response.Redirect("AttendanceChk.aspx");
        }
        else
        {

            Label4.Text = "Ur username or password is wrong";
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
        em.disconnect();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Employee.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpReg.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpReg.aspx");
    }
}
