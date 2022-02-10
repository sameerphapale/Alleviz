using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Master.Conference;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Master
{
    public class ConferenceDAL
    {
        public Int32 InsertConferenceData(ConferenceInsert conferenceInsert)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");
                cmd.Parameters.AddWithValue("@command", conferenceInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@ConferenceName", conferenceInsert.ConferenceName.ToString());
                cmd.Parameters.AddWithValue("@LandlineNo", conferenceInsert.LandlineNo.ToString());
                cmd.Parameters.AddWithValue("@ConferenceCapicity", conferenceInsert.ConferenceCapicity.ToString());
                return SqlHelper.ExtecuteProcedureReturnInteger(cmd);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {

            }
        }
        public List<ConferenceDetails> GetConferenceDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<ConferenceDetails> Lists = new List<ConferenceDetails>();

                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConferenceDetails List = new ConferenceDetails();

                    List.ConferenceID = Convert.ToInt64(dt.Rows[i]["ConID"].ToString());
                    List.ConferenceName = dt.Rows[i]["ConName"].ToString();
                    List.LandlineNo = dt.Rows[i]["LandlineNo"].ToString();
                    List.ConferenceCapicity = dt.Rows[i]["ConCapicity"].ToString();
                    Lists.Add(List);
                }
                return Lists;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public List<ConferenceDetails> GetFreeConfDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<ConferenceDetails> Lists = new List<ConferenceDetails>();

                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");

                cmd.Parameters.AddWithValue("@Command", "FreeConf".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConferenceDetails List = new ConferenceDetails();


                    List.ConferenceID = Convert.ToInt64(dt.Rows[i]["ConID"].ToString());
                    List.ConferenceName = dt.Rows[i]["ConName"].ToString();

                    Lists.Add(List);
                }
                return Lists;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }


        public List<ConferenceDetails> GetConferenceDeatilsById(long ConferenceID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<ConferenceDetails> Lists = new List<ConferenceDetails>();

                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");
                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@ConferenceID", ConferenceID);
                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConferenceDetails List = new ConferenceDetails();

                    List.ConferenceID = Convert.ToInt64(dt.Rows[i]["ConID"].ToString());
                    List.ConferenceName = dt.Rows[i]["ConName"].ToString();
                    List.LandlineNo = dt.Rows[i]["LandlineNo"].ToString();
                    List.ConferenceCapicity = dt.Rows[i]["ConCapicity"].ToString();
                    Lists.Add(List);
                }
                return Lists;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        public Int32 UpdateConferenceDetails(ConferenceUpdate conferenceUpdate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");
                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());
                cmd.Parameters.AddWithValue("@ConferenceID", conferenceUpdate.ConferenceID);
                cmd.Parameters.AddWithValue("@ConferenceName", conferenceUpdate.ConferenceName.ToString());
                cmd.Parameters.AddWithValue("@LandlineNo", conferenceUpdate.LandlineNo.ToString());
                cmd.Parameters.AddWithValue("@ConferenceCapicity", conferenceUpdate.ConferenceCapicity.ToString());

                return SqlHelper.ExtecuteProcedureReturnInteger(cmd);

            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {

            }
        }

        public Int32 DeleteConference(Int64 ConferenceID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_ConferenceMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@ConferenceID", ConferenceID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
