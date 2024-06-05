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
/// Summary description for clsDistributor
/// </summary>
public class clsDistributor:clsUser 
{
	public clsDistributor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ConsumerNo { get; set; }
    public string ConsumerAddress { get; set; }
    public string  ConnectionName { get; set; }
    public DateTime RequestedDate { get; set; }
    public DateTime AllotedDate { get; set; }
    public int CylinderNo { get; set; }
    public int Regulator { get; set; }
    public string ConsumerName { get; set; }
    public decimal DepositAmount { get; set; }
    public decimal  ConnectionCharge { get; set; }
    public int SNO { get; set; }
    public DataSet GetConsumerConnectionRequests()
    {
        SqlParameter p = new SqlParameter("@UserId", UserId);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowConsumerConnectionRequests",p);  
    }
    public string InsertConnectionDetails()
    {
        SqlParameter[] p = new SqlParameter[12];
        p[0] = new SqlParameter("@ConsumerNo", ConsumerNo);
        p[1] = new SqlParameter("@ConsumerName", ConsumerName);
        p[2] = new SqlParameter("@ConsumerAddress", ConsumerAddress);
        p[3] = new SqlParameter("@ConnectionName", ConnectionName);
        p[4] = new SqlParameter("@RequestedDate", RequestedDate);
        p[5] = new SqlParameter("@AllotedDate", AllotedDate);
        p[6] = new SqlParameter("@CylinderNo", CylinderNo);
        p[7] = new SqlParameter("@Regulator", Regulator);
        p[8] = new SqlParameter("@AgencyName", AgencyName);
        p[9] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[9].Direction = ParameterDirection.Output;
        p[10]=new SqlParameter("@DepositAmount",DepositAmount);
        p[11] = new SqlParameter("@ConnectionCharge", ConnectionCharge); 
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertGasConnectionDetails",p);
        return p[9].Value.ToString();  
    }
    public DataSet GetGasBookingRequest()
    {
        SqlParameter p = new SqlParameter("@UserId", UserId);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowGasBookingDetails", p);  
    }
    public DataSet TransferRequest()
    {
        SqlParameter p = new SqlParameter("@UserId", UserId);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowUserLocationTransferRequests", p); 
    }
    public int SendToAdminTransferRequest()
    {
        string SqlStat = "update tbl_LocationTransferRequests set Status='ToAdmin' where SNO=" + SNO;
        int a = SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.Text, SqlStat);
        return a;
    }
    public DataSet ShowConsumerReports()
    {
        SqlParameter p = new SqlParameter("@UserId", UserId); 
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowConsumerReports", p); 
    }
    public DataSet GetAcceptGasConnection(int UserId)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spAcceptGasBooking", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


}
