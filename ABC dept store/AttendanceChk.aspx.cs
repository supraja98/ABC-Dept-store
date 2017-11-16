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

public partial class AttendanceChk : System.Web.UI.Page
{
    Empl em = new Empl();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        em.connect();
        em.cmd.CommandText="select Eid,Ename from EmpTab";
        em.rs = em.cmd.ExecuteReader();
        if (em.rs.Read())
        {
            GridView1.DataSource = em.rs;
            GridView1.DataBind();
        }
        em.disconnect();
           
    }
}
