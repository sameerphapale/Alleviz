using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VisitorManagementSystemWebApi.Model.Visitor;
using static VisitorManagementSystemWebApi.Model.Visitor.Appointment;

namespace VisitorManagementSystemWebApi.App_Code.DAL.Visitor
{
    public class AppointmentDal
    {
        public Int32 InsertVisitorAppointmenntData(Appointment objApp)
        {



            try
            {
                
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@command", objApp.Command.ToString());
                cmd.Parameters.AddWithValue("@VisiName", objApp.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", objApp.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiAdd", objApp.VisiAdd);
                cmd.Parameters.AddWithValue("@VisiMobileNo", objApp.VisiMobileNo);
                cmd.Parameters.AddWithValue("@VisiEmailID", objApp.VisiEmailID);
                cmd.Parameters.AddWithValue("@VisiDesigName", objApp.VisiDesigName);
                cmd.Parameters.AddWithValue("@VehicleNo", objApp.VehicleNo);
                cmd.Parameters.AddWithValue("@Empid", objApp.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", objApp.Visi_cat_id);
                cmd.Parameters.AddWithValue("@BranchID_visit", objApp.BranchID_visit);
                cmd.Parameters.AddWithValue("@Deptid_visit", objApp.Deptid_visit);
                cmd.Parameters.AddWithValue("@Purpose_id", objApp.Purpose_id);
                cmd.Parameters.AddWithValue("@AppDatefrom", objApp.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", objApp.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", objApp.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", objApp.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", objApp.Assets);
                cmd.Parameters.AddWithValue("@IDProof", objApp.IDProof);
                cmd.Parameters.AddWithValue("@IDProofNumber", objApp.IDProofNumber);
                cmd.Parameters.AddWithValue("@Temprature", objApp.Temprature);
                cmd.Parameters.AddWithValue("@Badge_no", objApp.Badge_no);
                cmd.Parameters.AddWithValue("@ConferenceId", objApp.ConferenceId);
                cmd.Parameters.AddWithValue("@AppTypeID", objApp.AppTypeID);
                cmd.Parameters.AddWithValue("@catName", objApp.catName);
                cmd.Parameters.AddWithValue("@Purpose", objApp.Purpose);
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


        public Int32 InsertVisitorAppointmentBulk(VisiBulkUpload objApp)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@command", objApp.Command.ToString());
                cmd.Parameters.AddWithValue("@VisiName", objApp.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", objApp.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", objApp.VisiMobileNo);
                cmd.Parameters.AddWithValue("@catName", objApp.catName.ToString());
                cmd.Parameters.AddWithValue("@Purpose", objApp.Purpose);
                cmd.Parameters.AddWithValue("@AppDatefrom", objApp.AppDatefrom);

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

        public Int32 InsertCoVisitorData(Appointment objApp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@command", objApp.Command.ToString());
                cmd.Parameters.AddWithValue("@AppID", objApp.AppID.ToString());
                cmd.Parameters.AddWithValue("@CoVisitor_Name", objApp.CoVisiName.ToString());
                cmd.Parameters.AddWithValue("@mobileNo", objApp.mobileNo.ToString());

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

        public Int32 UpdateSheduledVisitorDetails(Appointment objApp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATESecurity".ToString());

                cmd.Parameters.AddWithValue("@AppID", objApp.AppID.ToString());
                cmd.Parameters.AddWithValue("@VisiName", objApp.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", objApp.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", objApp.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@Empid", objApp.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", objApp.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", objApp.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@IDProof", objApp.IDProof.ToString());
                cmd.Parameters.AddWithValue("@IDProofNumber", objApp.IDProofNumber.ToString());
                cmd.Parameters.AddWithValue("@Temprature", objApp.Temprature.ToString());
                cmd.Parameters.AddWithValue("@Badge_no", objApp.Badge_no.ToString());
                cmd.Parameters.AddWithValue("@Assets", objApp.Assets.ToString());
                cmd.Parameters.AddWithValue("@AppTypeID", objApp.AppTypeID);
                cmd.Parameters.AddWithValue("@Covisiid", objApp.Covisiid.ToString());


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

        public Int32 UpdateVisitorDetails(Appointment objApp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "UPDATE".ToString());

                cmd.Parameters.AddWithValue("@AppID", objApp.AppID.ToString());
                cmd.Parameters.AddWithValue("@VisiName", objApp.VisiName.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", objApp.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiAdd", objApp.VisiAdd.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", objApp.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@VisiEmailID", objApp.VisiEmailID.ToString());
                cmd.Parameters.AddWithValue("@VisiDesigName", objApp.VisiDesigName.ToString());
                cmd.Parameters.AddWithValue("@VehicleNo", objApp.VehicleNo.ToString());
                cmd.Parameters.AddWithValue("@Empid", objApp.Empid.ToString());
                cmd.Parameters.AddWithValue("@Visi_cat_id", objApp.Visi_cat_id.ToString());
                cmd.Parameters.AddWithValue("@BranchID_visit", objApp.BranchID_visit.ToString());
                cmd.Parameters.AddWithValue("@Deptid_visit", objApp.Deptid_visit.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", objApp.Purpose_id.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", objApp.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", objApp.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", objApp.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", objApp.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", objApp.Assets.ToString());
                cmd.Parameters.AddWithValue("@AppTypeID", objApp.AppTypeID);


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

        public Int32 UpdatePersonalTimeLine(Appointment AppointmentInsert)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_InsertVisitorEntry");

                cmd.Parameters.AddWithValue("@Command", "CHANGE".ToString());

                cmd.Parameters.AddWithValue("@AppID", AppointmentInsert.AppID.ToString());
                cmd.Parameters.AddWithValue("@VisiCompany", AppointmentInsert.VisiCompany.ToString());
                cmd.Parameters.AddWithValue("@VisiName", AppointmentInsert.VisiName.ToString());
                cmd.Parameters.AddWithValue("@Purpose_id", AppointmentInsert.Purpose_id.ToString());

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

        public List<Appointment> GetTodaySheduledAppDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "Sheduled".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.Covisiid = Convert.ToInt64(dt.Rows[i]["Covisiid"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());

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

        public List<Appointment> SearchTodaySheduledAppDetails(string QRCode)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "SearchSheduled".ToString());
                cmd.Parameters.AddWithValue("@QRCode", QRCode.ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());

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

        public List<Appointment> GetDailyOutPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "OutPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.AppTypeID = Convert.ToInt64(dt.Rows[i]["AppTypeID"].ToString());
                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.QRCode = dt.Rows[i]["QRCode"].ToString();




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

        public List<Appointment> GetVisitorDetailsForBlack()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "UnBlackVisitor".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
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

        public Int32 BlackVisitor(long AppID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@Command", "Block");
                cmd.Parameters.AddWithValue("@AppID", AppID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }
        public List<Appointment> GetBlackVisitorDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "BlackVisitor".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
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

        public Int32 ExitVisitor(long AppID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@Command", "VisiOut");
                cmd.Parameters.AddWithValue("@AppID", AppID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public Int32 DailyInVisitor(long AppID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@Command", "VisiIn");
                cmd.Parameters.AddWithValue("@AppID", AppID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

        public List<Appointment> GetAppointmentDeatils()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "SELECT".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    //List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    //List.Assets = dt.Rows[i]["Assets"].ToString();
                    //List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    //List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    //List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    //List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    //List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    //List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    //List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    //List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    //List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    //List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    //List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    //List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    //List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    //List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    //List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    //List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                  //  List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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


        public List<Appointment> GetPeriodicPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "PeriodicPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.OutDate = Convert.ToDateTime(dt.Rows[i]["OutDate"].ToString());
                    List.Premises_Time = Convert.ToDateTime(dt.Rows[i]["Premises_Time"].ToString());
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.QRCode = dt.Rows[i]["QRCode"].ToString();





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
        public List<Appointment> GetAppointmentDeatilsByID(long AppID,long Covisiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "TodayApp".ToString());
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.Parameters.AddWithValue("@Covisiid", Covisiid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = dt.Rows[i]["Badge_no"].ToString();
                   List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                   // List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();


                    List.Covisiid = Convert.ToInt64(dt.Rows[i]["Covisiid"].ToString());
                    List.mobileNo = dt.Rows[i]["mobileNo"].ToString();
                    List.CoInDate = dt.Rows[i]["CoInDate"].ToString();
                    List.CoOutDate = dt.Rows[i]["CoOutDate"].ToString();
                    List.CoVisiName = dt.Rows[i]["CoVisiName"].ToString();
                    List.QRCode = dt.Rows[i]["QRCode"].ToString();
                   









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


        public List<Appointment> GetAppointmentDeatilsByEmpID(long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "AppDetails".ToString());
                cmd.Parameters.AddWithValue("@Empid", Empid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = dt.Rows[i]["Badge_no"].ToString();
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
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

        public List<Appointment> GetVisitorDeatilsByEmpID(long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiDetails".ToString());
                cmd.Parameters.AddWithValue("@Empid", Empid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = dt.Rows[i]["Badge_no"].ToString();
                     List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
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

        public List<Appointment> GetAppointmentDeatilsByDept(string DeptName)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DeptSerach".ToString());
                cmd.Parameters.AddWithValue("@DeptName", DeptName);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    //List.Assets = dt.Rows[i]["Assets"].ToString();
                    //List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    //List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    //List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    //List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    //List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    //List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    //List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    //List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    //List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    //List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    //List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    //List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    //List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    //List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    //List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    //List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    //List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    //List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());


                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                  //  List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                   // List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<Appointment> GetRePrintPassDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "RePrintPass".ToString());

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();


                    List.AppID = Convert.ToInt64(dt.Rows[i]["AppID"].ToString());
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


        public List<Appointment> GetPassDeatilsByVisiId([FromBody]long AppID,long Covisiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "Pass".ToString());
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.Parameters.AddWithValue("@Covisiid", Covisiid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

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
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = dt.Rows[i]["Badge_no"].ToString();
                   List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.EntryDate = Convert.ToDateTime(dt.Rows[i]["EntryDate"].ToString());
                    List.InDate = Convert.ToDateTime(dt.Rows[i]["InDate"].ToString());
                    List.QRCode = dt.Rows[i]["QRCode"].ToString();
                    string s = (string)dt.Rows[i]["VisiPhoto"].ToString();
                    byte[] data = Convert.FromBase64String(s);
                    List.VisiPhoto = data;


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


        public List<Appointment> GetVisitorVisitedReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiVisited".ToString());
                cmd.Parameters.AddWithValue("@fromd", fromd);
                cmd.Parameters.AddWithValue("@tod", tod);
                cmd.Parameters.AddWithValue("@visitype", visitype);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@hostname", hostname);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.ConName = dt.Rows[i]["ConName"].ToString();
                    string s = (string)dt.Rows[i]["VisiPhoto"].ToString();
                    byte[] data = Convert.FromBase64String(s);
                    List.VisiPhoto = data;


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

        public List<Appointment> GetHostList(string dept)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "HostList".ToString());
                cmd.Parameters.AddWithValue("@dept", dept);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
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

        public List<Appointment> GetVisitorInOutPunchReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "VisitorInOut".ToString());
                cmd.Parameters.AddWithValue("@fromd", fromd);
                cmd.Parameters.AddWithValue("@tod", tod);
                cmd.Parameters.AddWithValue("@visitype", visitype);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@hostname", hostname);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    //List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = dt.Rows[i]["Badge_no"].ToString();
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
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

        public List<Appointment> GetVisitorAppointmentReport(DateTime fromd, DateTime tod, string visitype, string dept, string hostname)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "AppReport".ToString());
                cmd.Parameters.AddWithValue("@fromd", fromd);
                cmd.Parameters.AddWithValue("@tod", tod);
                cmd.Parameters.AddWithValue("@visitype", visitype);
                cmd.Parameters.AddWithValue("@dept", dept);
                cmd.Parameters.AddWithValue("@hostname", hostname);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                   
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.ConName = dt.Rows[i]["ConName"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();   
                    List.catName = dt.Rows[i]["catName"].ToString();
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();               
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();                   
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
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

        public List<Appointment> GetAppointmentDeatilsByBranch(long BranchID)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "BranchSerach".ToString());
                cmd.Parameters.AddWithValue("@BranchID", BranchID);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
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
                    //   List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                   List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<Appointment> GetAppointmentDeatilsByDept(long DeptId)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DeptSerach".ToString());
                cmd.Parameters.AddWithValue("@DeptId", DeptId);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
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
                    //   List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<Appointment> GetAppointmentDeatilsByDate(string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DateSerach".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
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
                   // List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<Appointment> GetAppointmentbasicreport(string DeptName, string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "DateSerach".ToString());
                cmd.Parameters.AddWithValue("@DeptName", DeptName);
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    List.Assets = dt.Rows[i]["Assets"].ToString();
                    List.VisiName = dt.Rows[i]["VisiName"].ToString();
                    List.VehicleNo = dt.Rows[i]["VehicleNo"].ToString();
                    List.VisiDesigName = dt.Rows[i]["VisiDesigName"].ToString();
                    List.VisiAdd = dt.Rows[i]["VisiAdd"].ToString();
                    List.VisiMobileNo = Convert.ToInt64(dt.Rows[i]["VisiMobileNo"].ToString());
                    List.VisiCompany = dt.Rows[i]["VisiCompany"].ToString();
                    //List.Visi_cat_id = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    //List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    //List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    //List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    //List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    //List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    //List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    //  List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<AppointmentStartEnd> GetAppointmentStartEndTime(string AppDatefrom)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentStartEnd> Lists = new List<AppointmentStartEnd>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "TimeSerach".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentStartEnd List = new AppointmentStartEnd();

                    List.starttime = dt.Rows[i]["starttime"].ToString();
                    List.endtime = dt.Rows[i]["endtime"].ToString();

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

        public List<AppointmentStartEnd> GetPersonaltimelineStartEndTime(string AppDatefrom, long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<AppointmentStartEnd> Lists = new List<AppointmentStartEnd>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "VisiTimeline".ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", AppDatefrom);
                cmd.Parameters.AddWithValue("@Empid", Empid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AppointmentStartEnd List = new AppointmentStartEnd();

                    List.starttime = dt.Rows[i]["starttime"].ToString();
                    List.endtime = dt.Rows[i]["endtime"].ToString();

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

        public List<SheduledAppCount> GetAppointmentDeatilsByMonth(int Month)
        {
            try
            {
                DataTable dt = new DataTable();

                List<SheduledAppCount> Lists = new List<SheduledAppCount>();
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "AppCount".ToString());
                cmd.Parameters.AddWithValue("@Month", Month);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    SheduledAppCount VCount = new SheduledAppCount();

                    VCount.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    VCount.VisitorCount = Convert.ToInt64(dt.Rows[i]["VisitorCount"].ToString());
                  
                    Lists.Add(VCount);
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

        public List<AppointmentCount> GetVisitorCount(string SearchDate)
        {
            try
            {
                DataTable dt = new DataTable();

                List<AppointmentCount> Lists = new List<AppointmentCount>();
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiCount".ToString());
                cmd.Parameters.AddWithValue("@SearchDate", SearchDate);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AppointmentCount VCount = new AppointmentCount();

                    VCount.Sheduled = Convert.ToInt64(dt.Rows[0]["Sheduled"].ToString());
                    VCount.WalkIn = Convert.ToInt64(dt.Rows[0]["WalkIn"].ToString());
                    VCount.InPremises = Convert.ToInt64(dt.Rows[0]["InPremises"].ToString());
                    VCount.Visited = Convert.ToInt64(dt.Rows[0]["Visited"].ToString());

                    Lists.Add(VCount);
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


        public List<AppointmentCount> GetVisitorCountForSecurity()
        {
            try
            {
                DataTable dt = new DataTable();

                List<AppointmentCount> Lists = new List<AppointmentCount>();
                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiCountForSec".ToString());
               
                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AppointmentCount VCount = new AppointmentCount();

                    VCount.InPremises = Convert.ToInt64(dt.Rows[0]["InPremises"].ToString());
                    VCount.Visited = Convert.ToInt64(dt.Rows[0]["Visited"].ToString());

                    Lists.Add(VCount);
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

        public Int32 RemoveAppointment(Int64 AppID)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("Sp_VisitorAppoinmentMaster");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@AppID", AppID.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}
