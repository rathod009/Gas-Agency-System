using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using EGAS.DAL;  
/// <summary>
/// Summary description for clsAdmin
/// </summary>
public class clsAdmin
{
	public clsAdmin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ConnectionTypeId { get; set; }
    public string  ConnectionName { get; set; }
    public string Description { get; set; }
    public decimal RefillCharge { get; set; }
    public decimal NewConnectionCharge { get; set; }
    public int SNO { get; set; }
    public int TotalCylinders { get; set; }
    public int AvailableCylinders { get; set; }
    public int CityId { get; set; }
    public string AgencyName { get; set; }
    public int UserId { get; set; }

    public string AddInsertConnection()
    {
        SqlParameter[] p = new SqlParameter[5];
        p[0] = new SqlParameter("@ConnectionName", ConnectionName);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@RefillCharge", RefillCharge);
        p[3] = new SqlParameter("@NewConnectionPrice", NewConnectionCharge);
        p[4] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[4].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertConnectionType", p);
        return p[4].Value.ToString();  
        
    }
    public DataSet ShowConnectionType()
    {
        string SqlStat = "select ConnectionTypeId,ConnectionName,Description,RefillCharge,NewConnectionPrice from tbl_ConnectionType";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);  
    }
    public string UpdateConnection()
    {
        SqlParameter[] p = new SqlParameter[6];
        p[0] = new SqlParameter("@ConnectionName", ConnectionName);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@RefillCharge", RefillCharge);
        p[3] = new SqlParameter("@NewConnectionPrice", NewConnectionCharge);
        p[4] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[4].Direction = ParameterDirection.Output;
        p[5] = new SqlParameter("@ConnectionTypeId", ConnectionTypeId);
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spUpdateConnection", p);
        return p[4].Value.ToString();

    }
    public DataSet ShowUserLocationTransferRequestsToAdmin()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowUserLocationTransferRequestsToAdmin");  
    }
    public string UpdateUserTransperRequests()
    {
        SqlParameter[] p = new SqlParameter[5];
        p[0]=new SqlParameter("@SNO",SNO);
        p[1]=new SqlParameter("@UserId",UserId);
        p[2]=new SqlParameter("@ToCity",CityId);
        p[3]=new SqlParameter("@ToAgencyName",AgencyName); 
        p[4]=new SqlParameter("@Message",SqlDbType.VarChar,100);
        p[4].Direction =ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection,CommandType.StoredProcedure,"spUpdateTransferRequestByAdmin",p);  
        return p[4].Value.ToString();  
    }
    public string AddCylinderDetails()
    {
        SqlParameter[] p = new SqlParameter[6];
        p[0] = new SqlParameter("@CityId", CityId);
        p[1] = new SqlParameter("@AgentId", UserId);
        p[2] = new SqlParameter("@AgencyName", AgencyName);
        p[3] = new SqlParameter("@TotalCylinders", TotalCylinders);
        p[4] = new SqlParameter("@AvailableCylinders", AvailableCylinders);
        p[5] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[5].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertGasCylinders", p);
        return p[5].Value.ToString();  
    }
    public DataSet ShowDitributorsReport()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowDistributors");   
    }
    public DataSet ShowConsumersReport()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowConsumers");
    }
    public DataSet  DispalyCylinderStatus()
    {
        SqlParameter[] p = new SqlParameter[2];
        p[0] = new SqlParameter("@CityId", CityId);
        p[1] = new SqlParameter("@AgencyName", AgencyName);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spCylinderStatus", p); 
    }
    public DataSet ShowAllCylinders()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowAllCylinders");  
    }
    public string  UpdateCylinders()
    {
        SqlParameter[]p=new  SqlParameter[4];
        p[0] = new SqlParameter("@SNO", SNO);
        p[1] = new SqlParameter("@TotalCylinders", TotalCylinders);
        p[2] = new SqlParameter("@AvailableCylinders", AvailableCylinders);
        p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;   
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spUpdateCylinders", p);
        return p[3].Value.ToString();  
         
  
    }
    public DataSet ShowFeedBack()
    {
       return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowFeedBack" );
    }
}
