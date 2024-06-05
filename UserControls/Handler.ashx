<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;   
public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(connectionString);
        myConnection.Open();
        int CID = Convert.ToInt32(context.Request.QueryString["CID"].ToString());
        string sql = "Select Image from tbl_UserRegistration where UserId=" + CID;
        SqlCommand cmd = new SqlCommand(sql, myConnection);
        //cmd.Parameters.Add("@SNo", SqlDbType.Int).Value = context.Request.QueryString["SNo"];
        // cmd.Prepare(); 
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();

        //context.Response.ContentType = dr["PhotoFileName"].ToString();
        context.Response.BinaryWrite((byte[])dr["Image"]);
        dr.Close();
        myConnection.Close();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}