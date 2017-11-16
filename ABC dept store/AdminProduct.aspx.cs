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

public partial class AdminProduct : System.Web.UI.Page
{
    Empl em = new Empl();
    ProClass pc = new ProClass();
    protected void Page_Load(object sender, EventArgs e)
    {
       // GridView2.Visible = false;
    }
    String s;
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        s = Menu1.SelectedItem.Text;
        Response.Write(s);
        if (s.Equals("Stock Checking"))
        {
            pc.connect();
            pc.cmd.CommandText="select pname,pqnty from producttable";
            pc.rs=pc.cmd.ExecuteReader();
            GridView2.Visible = false;
            if(pc.rs.Read())
            {
                GridView1.DataSource=pc.rs;
                GridView1.DataBind();
            }
            pc.disconnect();
            
        }   
        else if(s.Equals("Product Checking"))
        {
            pc.connect();
            pc.cmd.CommandText="select * from producttable";
            pc.rs=pc.cmd.ExecuteReader();
            GridView2.Visible = false;
            if(pc.rs.Read())
            {
                GridView1.DataSource=pc.rs;
                GridView1.DataBind();
            }
            pc.disconnect();
        }
        else 
        {
            GridView2.Visible = true;
            em.connect();
            Response.Write("ZZZZZZ");
            em.cmd.CommandText = "select Eid,Ename from EmpTab";
            em.rs = em.cmd.ExecuteReader();
            GridView1.Visible = false;
            while(em.rs.Read())
            {
                GridView1.DataSource=em.rs;
                GridView1.DataBind();
            }
            em.disconnect();
            
        }
        

    }

    
}
