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
/// Summary description for clsUser
/// </summary>
public class clsUser:clsState 
{
	public clsUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime DOB { get; set; }
    public byte[] Image { get; set; }
    public string FileName { get; set; }
    public DateTime DOR { get; set; }
    public string Role { get; set; }
    public string Gender { get; set; }
    public string  AgencyName { get; set; }
    public int Connection { get; set; }
    public int AgentId { get; set; }
    public int ToCity { get; set; }
    public string ToAgencyName { get; set; }
    public int ToAgentId { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }



    public string InsertUserRegistration()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[20];
            p[0] = new SqlParameter("@UserName", UserName);
            p[1] = new SqlParameter("@Password", Password);
            p[2] = new SqlParameter("@FirstName", FirstName);
            p[3] = new SqlParameter("@MiddleName", MiddleName);
            p[4] = new SqlParameter("@LastName", LastName);
            p[5] = new SqlParameter("@Email", Email);
            p[6] = new SqlParameter("@Address", Address);
            p[7] = new SqlParameter("@PhoneNo", PhoneNo);
            p[8] = new SqlParameter("@DOB", DOB);
            p[9] = new SqlParameter("@DOR", DOR);
            p[10] = new SqlParameter("@Image",Image);
            p[11] = new SqlParameter("@FileName", FileName);
            p[12] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[12].Direction = ParameterDirection.Output;
            p[13] = new SqlParameter("@Role", Role);            
            p[14] = new SqlParameter("@Gender", Gender);
            p[15] = new SqlParameter("@State", StateId);
            p[16] = new SqlParameter("@District", DistrictId);
            p[17] = new SqlParameter("@City", CityId);
            p[18] = new SqlParameter("@AgencyName", AgencyName);
            p[19] = new SqlParameter("@ConnectionType", Connection);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertUserRegistration", p);
            return p[12].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    
    public string UpdateProfile()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@UserId",UserId);
            p[1] = new SqlParameter("@PhoneNo", PhoneNo);
            p[2] = new SqlParameter("@Email", Email);
            p[3] = new SqlParameter("@Image", Image);
            p[4] = new SqlParameter("@FileName", FileName);
            p[5] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@Address", Address);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateProfile", p);
            return p[5].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet ShowConnectionDetailsByuser()
    {
        SqlParameter p = new SqlParameter("@UserId", @UserId);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spSelectConnectionStatus", p);
    }

    public string UserBookGas()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@UserId", UserId);
        p[1] = new SqlParameter("@AgencyName", AgencyName);
        p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 1000);
        p[2].Direction = ParameterDirection.Output;
        p[3]=new SqlParameter("@AgentId",AgentId); 

        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertGasBookingDetails", p);
        return p[2].Value.ToString();  
    }
    public DataSet GasBookingStatus()
    {
            SqlParameter p = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spGasBookingStatus", p);
    }

    public string InsertTransferRequest()
    {
        SqlParameter[] p = new SqlParameter[8];
        p[0] = new SqlParameter("@UserId", UserId);
        p[1] = new SqlParameter("@FromCity", CityId);
        p[2] = new SqlParameter("@FromAgencyName", AgencyName);
        p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        p[4] = new SqlParameter("@FromAgentId", AgentId); 
        p[5]=new SqlParameter("@ToCity",ToCity) ;
        p[6] = new SqlParameter("@ToAgencyName", ToAgencyName);
        p[7] = new SqlParameter("@ToAgentId", ToAgentId); 
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertLocationTransferRequest", p);
        return p[3].Value.ToString();  
 
    }
    public DataSet  GetUserConnection()
    {
        SqlParameter p = new SqlParameter("@UserId", UserId);
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spShowUserAgency",p); 
    }
    public int InserFeedBack()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@Subject", Subject);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@FeedBackBy", UserId);
       int a= SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertFeedBack", p);
       return a;
    }

    public int InsertGuestFeedBack()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@Subject", Subject);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@FeedBackBy", UserId);
        int a = SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.Text, "spInsertFeedBackbyguest", p);
        return a;
    }

    //public DataSet GetManufacturers()
    //{
    //    try
    //    {
    //        string str = "select UserId,UserName from tbl_UserRegistration where Role='Manufacturer'";
    //      return  SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text,str);

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //}

    public DataSet GasTransferStatus()
    {
            SqlParameter p = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spGasTransferStatus", p);
    }
}
