using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static VisitorManagementSystemWebApi.Model.Visitor.Visitor;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Visitor
{
    public class VisitorDal
    {
        //public Int32 InsertVisitorData(VisitorInsert visitorInsert)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

        //        cmd.Parameters.AddWithValue("@command", visitorInsert.Command.ToString());
        //        cmd.Parameters.AddWithValue("@VisiName", visitorInsert.VisiName.ToString());
        //        cmd.Parameters.AddWithValue("@VisiCompany", visitorInsert.VisiCompany.ToString());
        //        cmd.Parameters.AddWithValue("@VisiAdd", visitorInsert.VisiAdd.ToString());
        //        cmd.Parameters.AddWithValue("@VisiMobileNo", visitorInsert.VisiMobileNo.ToString());
        //        cmd.Parameters.AddWithValue("@VisiEmailID", visitorInsert.VisiEmailID.ToString());
        //        cmd.Parameters.AddWithValue("@VisiDesigName", visitorInsert.VisiDesigName.ToString());
        //        cmd.Parameters.AddWithValue("@VehicleNo", visitorInsert.VehicleNo.ToString());


        //        return SqlHelper.ExtecuteProcedureReturnInteger(cmd);

        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //    finally
        //    {

        //    }
        //}


        public Int32 InsertVisitorData(VisitorInsert visitorInsert)
        {
            try
            {
                //SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                SqlCommand cmd = new SqlCommand("Sp_InsertVisitorEntry");

                cmd.Parameters.AddWithValue("@command", visitorInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@VisiName", visitorInsert.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", visitorInsert.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiAdd", visitorInsert.VisiAdd.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", visitorInsert.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@VisiEmailID", visitorInsert.VisiEmailID.ToString());
                cmd.Parameters.AddWithValue("@VisiDesigName", visitorInsert.VisiDesigName.ToString());
                cmd.Parameters.AddWithValue("@VehicleNo", visitorInsert.VehicleNo.ToString());
                //cmd.Parameters.AddWithValue("@CoVisiCount", visitorInsert.CoVisiCount.ToString());
                //cmd.Parameters.AddWithValue("@CoVisitor_Name", visitorInsert.CoVisitor_Name.ToString());
                cmd.Parameters.AddWithValue("@Empid", visitorInsert.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", visitorInsert.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@BranchID_visit", visitorInsert.BranchID_visit.ToString());
                cmd.Parameters.AddWithValue("@Deptid_visit", visitorInsert.Deptid_visit.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", visitorInsert.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", visitorInsert.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", visitorInsert.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", visitorInsert.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", visitorInsert.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", visitorInsert.Assets.ToString());
                cmd.Parameters.AddWithValue("@ConferenceId", visitorInsert.ConferenceId.ToString());


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

        public Int32 UpdateVisitorDetails(VisitorUpdate visitorUpdate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_InsertVisitorEntry");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@Visiid", visitorUpdate.Visiid.ToString());
                cmd.Parameters.AddWithValue("@VisiName", visitorUpdate.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", visitorUpdate.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiAdd", visitorUpdate.VisiAdd.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", visitorUpdate.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@VisiEmailID", visitorUpdate.VisiEmailID.ToString());
                cmd.Parameters.AddWithValue("@VisiDesigName", visitorUpdate.VisiDesigName.ToString());
                cmd.Parameters.AddWithValue("@VehicleNo", visitorUpdate.VehicleNo.ToString());
                cmd.Parameters.AddWithValue("@Empid", visitorUpdate.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", visitorUpdate.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@BranchID_visit", visitorUpdate.BranchID_visit.ToString());
                cmd.Parameters.AddWithValue("@Deptid_visit", visitorUpdate.Deptid_visit.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", visitorUpdate.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", visitorUpdate.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", visitorUpdate.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", visitorUpdate.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", visitorUpdate.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", visitorUpdate.Assets.ToString());


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

        public Int32 UpdateSheduledVisitorDetails(SheduledVisitorUpdate sheduledVisitorUpdate)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_InsertVisitorEntry");

                cmd.Parameters.AddWithValue("@Command", "UPDATESecurity".ToString());

                cmd.Parameters.AddWithValue("@Visiid", sheduledVisitorUpdate.Visiid.ToString());
                cmd.Parameters.AddWithValue("@VisiName", sheduledVisitorUpdate.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", sheduledVisitorUpdate.VisiCompany.ToString());
                //cmd.Parameters.AddWithValue("@VisiAdd", sheduledVisitorUpdate.VisiAdd.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", sheduledVisitorUpdate.VisiMobileNo.ToString());
                //cmd.Parameters.AddWithValue("@VisiEmailID", sheduledVisitorUpdate.VisiEmailID.ToString());
                //cmd.Parameters.AddWithValue("@VisiDesigName", sheduledVisitorUpdate.VisiDesigName.ToString());
                //cmd.Parameters.AddWithValue("@VehicleNo", sheduledVisitorUpdate.VehicleNo.ToString());
                cmd.Parameters.AddWithValue("@Empid", sheduledVisitorUpdate.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", sheduledVisitorUpdate.Visi_cat_id.ToString());
                //cmd.Parameters.AddWithValue("@BranchID_visit", sheduledVisitorUpdate.BranchID_visit.ToString());
                //cmd.Parameters.AddWithValue("@Deptid_visit", sheduledVisitorUpdate.Deptid_visit.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", sheduledVisitorUpdate.Purpose_id.ToString());

                cmd.Parameters.AddWithValue("@IDProof", sheduledVisitorUpdate.IDProof.ToString());
                cmd.Parameters.AddWithValue("@IDProofNumber", sheduledVisitorUpdate.IDProofNumber.ToString());
                cmd.Parameters.AddWithValue("@Temprature", sheduledVisitorUpdate.Temprature.ToString());
              
                cmd.Parameters.AddWithValue("@Badge_no", sheduledVisitorUpdate.Badge_no.ToString());

                //cmd.Parameters.AddWithValue("@AppDatefrom", sheduledVisitorUpdate.AppDatefrom);
                //cmd.Parameters.AddWithValue("@AppDateTo", sheduledVisitorUpdate.AppDateTo);
                //cmd.Parameters.AddWithValue("@AppTimefrom", sheduledVisitorUpdate.AppTimefrom);
                //cmd.Parameters.AddWithValue("@AppTimeto", sheduledVisitorUpdate.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", sheduledVisitorUpdate.Assets.ToString());


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

        public Int32 UpdatePersonalTimeLine(VisitorTimeline visitorTimeline)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_InsertVisitorEntry");

                cmd.Parameters.AddWithValue("@Command", "CHANGE".ToString());

                cmd.Parameters.AddWithValue("@Visiid", visitorTimeline.Visiid.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", visitorTimeline.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiName", visitorTimeline.VisiName.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", visitorTimeline.Purpose_id.ToString());
               
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

        public Int32 InsertUnSheduleData(UnScheduledVisitor unScheduledVisitor)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@command", unScheduledVisitor.Command.ToString());
                cmd.Parameters.AddWithValue("@VisiName", unScheduledVisitor.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", unScheduledVisitor.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", unScheduledVisitor.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", unScheduledVisitor.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", unScheduledVisitor.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@IDProof", unScheduledVisitor.IDProof.ToString());
                cmd.Parameters.AddWithValue("@IDProofNumber", unScheduledVisitor.IDProofNumber.ToString());
                cmd.Parameters.AddWithValue("@Temprature", unScheduledVisitor.Temprature.ToString());
                cmd.Parameters.AddWithValue("@Host", unScheduledVisitor.Host.ToString());
                cmd.Parameters.AddWithValue("@Badge_no", unScheduledVisitor.Badge_no.ToString());
                cmd.Parameters.AddWithValue("@Assets", unScheduledVisitor.Assets.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", unScheduledVisitor.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", unScheduledVisitor.AppDateTo);


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

        public Int32 InsertCoVisitorData(CoVisitorInsert coVisitorInsert)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@command", coVisitorInsert.Command.ToString());
                cmd.Parameters.AddWithValue("@visiid", coVisitorInsert.Visiid.ToString());
                cmd.Parameters.AddWithValue("@CoVisitor_Name", coVisitorInsert.CoVisitor_Name.ToString());
                cmd.Parameters.AddWithValue("@mobileNo", coVisitorInsert.mobileNo.ToString());

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

        public List<PurposeDetails> GetPurposeDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PurposeDetails> Lists = new List<PurposeDetails>();

                SqlCommand cmd = new SqlCommand("SP_GetPurpose");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PurposeDetails List = new PurposeDetails();

                    List.Srno = Convert.ToInt64(dt.Rows[i]["Srno"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                
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

        public List<TodayUnScheduledVisitor> GetTodayUnSheduledAppDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<TodayUnScheduledVisitor> Lists = new List<TodayUnScheduledVisitor>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TodayUnScheduledVisitor List = new TodayUnScheduledVisitor();

                    
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.Purpose_id = Convert.ToInt32(dt.Rows[i]["Purpose_id"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                   


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

        public List<TodaySheduledDetails> GetTodaySheduledAppDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<TodaySheduledDetails> Lists = new List<TodaySheduledDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "Sheduled".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TodaySheduledDetails List = new TodaySheduledDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                   // List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    //List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    //List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    //List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                       List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    //List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    //List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    //List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                  //  List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    //List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    //List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    //List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    //List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    //List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    //List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    //List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());



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


        public List<DailyOutPassDetails> GetDailyOutPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DailyOutPassDetails> Lists = new List<DailyOutPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "OutPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DailyOutPassDetails List = new DailyOutPassDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    



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

        public List<DailyOutPassDetails> GetVisitorDetailsForBlack()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DailyOutPassDetails> Lists = new List<DailyOutPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "UnBlackVisitor".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DailyOutPassDetails List = new DailyOutPassDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());




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

        public List<DailyOutPassDetails> GetBlackVisitorDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DailyOutPassDetails> Lists = new List<DailyOutPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "BlackVisitor".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DailyOutPassDetails List = new DailyOutPassDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());




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

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "FreeConf".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ConferenceDetails List = new ConferenceDetails();


                    List.ConID = Convert.ToInt64(dt.Rows[i]["ConID"].ToString());
                    List.ConName = dt.Rows[i]["ConName"].ToString();
                
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

        public List<RePrintPassDetails> GetRePrintPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<RePrintPassDetails> Lists = new List<RePrintPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "RePrintPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RePrintPassDetails List = new RePrintPassDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                




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

        public List<PeriodicPassDetails> GetPeriodicPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PeriodicPassDetails> Lists = new List<PeriodicPassDetails>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "PeriodicPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PeriodicPassDetails List = new PeriodicPassDetails();


                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.OutDate = Convert.ToDateTime(dt.Rows[i]["OutDate"].ToString());
                    List.Premises_Time = Convert.ToDateTime(dt.Rows[i]["Premises_Time"].ToString());
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());





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

        public List<TodayUnScheduledVisitor> GetTodayUnSheduledAppDetailsByName(string VisiName)
        {
            try
            {
                DataTable dt = new DataTable();
                List<TodayUnScheduledVisitor> Lists = new List<TodayUnScheduledVisitor>();

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");

                cmd.Parameters.AddWithValue("@Command", "FEATCH".ToString());
                cmd.Parameters.AddWithValue("@VisiName", VisiName);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TodayUnScheduledVisitor List = new TodayUnScheduledVisitor();


                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.Purpose_id = Convert.ToInt32(dt.Rows[i]["Purpose_id"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());





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


        public List<VisitorTimeLineDetails> GetVisitorPesrsonalTimeLineDetails(long Empid, string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<VisitorTimeLineDetails> Lists = new List<VisitorTimeLineDetails>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "TimeLine".ToString());
                cmd.Parameters.AddWithValue("@Empid", Empid);
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    VisitorTimeLineDetails List = new VisitorTimeLineDetails();

                    List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    //  List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());





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

        public Int32 CheckAppointment(long VisiMobileNo)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                cmd.Parameters.AddWithValue("@Command", "CHECK");
                cmd.Parameters.AddWithValue("@VisiMobileNo", VisiMobileNo.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 DailyInVisitor(long Visiid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                cmd.Parameters.AddWithValue("@Command", "VisiIn");
                cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    

        public Int32 ExitVisitor(long Visiid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                cmd.Parameters.AddWithValue("@Command", "VisiOut");
                cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 BlackVisitor(long Visiid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_VisitorDetails");
                cmd.Parameters.AddWithValue("@Command", "Block");
                cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}
