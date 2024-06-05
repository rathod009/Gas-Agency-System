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
/// Summary description for clsState
/// </summary>
public class clsState
{
    public clsState()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int StateId { get; set; }
    public string StateName { get; set; }
    public string Description { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string CityName { get; set; }
    public int CityId { get; set; }

    public string InsertState()
    {
        SqlParameter[] p = new SqlParameter[3];
        p[0] = new SqlParameter("@StateName", StateName);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[2].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertState", p);
        return p[2].Value.ToString();

    }
    public DataSet ShowState()
    {
        string SqlStat = "select * from tbl_State";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public string InsertDistrict()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@DistrictName", DistrictName);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@StateId", StateId);
        p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertDistrict", p);
        return p[3].Value.ToString();

    }
    public string InsertCity()
    {
        SqlParameter[] p = new SqlParameter[4];
        p[0] = new SqlParameter("@CityName", CityName);
        p[1] = new SqlParameter("@Description", Description);
        p[2] = new SqlParameter("@DistrictId", DistrictId);
        p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
        p[3].Direction = ParameterDirection.Output;
        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "spInsertCity", p);
        return p[3].Value.ToString();

    }
    public DataSet ShowDistrict()
    {
        string SqlStat = "select * from tbl_District";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet ShowAllCity()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "ShowAllCity");
    }
    public DataSet ShowAllDistrict()
    {
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "ShowAllDistrict");
    }
    public DataSet ShowDistrictByStateId()
    {
        string SqlStat = "select * from tbl_District where StateId=" + StateId;
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet ShowCityByDistrictId()
    {
        string SqlStat = "select * from tbl_City where DistrictId=" + DistrictId;
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
    public DataSet ShowAgencyName()
    {
        string SqlStat = "select UserId, AgencyName from tbl_UserRegistration where City="+CityId+" and Role='Distributor'";
        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, SqlStat);
    }
}
