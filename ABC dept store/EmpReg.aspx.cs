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

public partial class EmpReg : System.Web.UI.Page
{
    Empl em = new Empl();
    String str1,str2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            reset();   
        }
    }
    public void reset()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";


    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
    {
        string s;
        s = args.Value.ToString();
       if (s.Length == 10)
            args.IsValid = true;
        else
            args.IsValid = false;
    }

    
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        em.connect();
        em.cmd.CommandText = "insert into EmpTab values(@i,@n,@e,@m,@s,@a,@d,@p)";
        em.cmd.Parameters.AddWithValue("@i", TextBox10.Text);
        str1 = TextBox1.Text;
        str2 = TextBox5.Text;
        str1=str1+" "+str2;
        em.cmd.Parameters.Add("@n", str1.ToString());
        em.cmd.Parameters.Add("@e", TextBox2.Text);
        em.cmd.Parameters.Add("@m", TextBox3.Text);
        em.cmd.Parameters.Add("@s", TextBox4.Text);
        em.cmd.Parameters.Add("@a", TextBox6.Text);
        em.cmd.Parameters.Add("@d", TextBox7.Text);
        em.cmd.Parameters.Add("@p", TextBox8.Text);

        em.cmd.ExecuteNonQuery();
        Response.Write("<script>alert('Data Stored Successfully')</script>");
         
        //em.cmd.CommandText = "delete * from EmpTab";
        
        em.disconnect();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        reset();             
    }
}
