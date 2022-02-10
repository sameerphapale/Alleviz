﻿using Microsoft.Data.SqlClient;
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
                cmd.Parameters.AddWithValue("@VisiAdd", objApp.VisiAdd.ToString());
                cmd.Parameters.AddWithValue("@VisiMobileNo", objApp.VisiMobileNo.ToString());
                cmd.Parameters.AddWithValue("@VisiEmailID", objApp.VisiEmailID.ToString());
                cmd.Parameters.AddWithValue("@VisiDesigName", objApp.VisiDesigName.ToString());
                cmd.Parameters.AddWithValue("@VehicleNo", objApp.VehicleNo.ToString());
                cmd.Parameters.AddWithValue("@VisiteeID", objApp.VisiteeID.ToString());
                cmd.Parameters.AddWithValue("@VisiCatID", objApp.VisiCatID.ToString());
                cmd.Parameters.AddWithValue("@VisiBranchID", objApp.VisiBranchID.ToString());
                cmd.Parameters.AddWithValue("@VisiDeptID", objApp.VisiDeptID.ToString());
                cmd.Parameters.AddWithValue("@PurposeID", objApp.PurposeID.ToString());
                cmd.Parameters.AddWithValue("@AppDatefrom", objApp.AppDatefrom);
                cmd.Parameters.AddWithValue("@AppDateTo", objApp.AppDateTo);
                cmd.Parameters.AddWithValue("@AppTimefrom", objApp.AppTimefrom);
                cmd.Parameters.AddWithValue("@AppTimeto", objApp.AppTimeto);
                cmd.Parameters.AddWithValue("@Assets", objApp.Assets.ToString());
                cmd.Parameters.AddWithValue("@ConferenceId", objApp.ConferenceId.ToString());
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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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


        public List<Appointment> GetAppointmentDeatilsByID(long Visiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "FETCH".ToString());
                cmd.Parameters.AddWithValue("@Visiid", Visiid);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Appointment List = new Appointment();

                    //List.Visiid = Convert.ToInt64(dt.Rows[i]["Visiid"].ToString());
                    //List.Assets = dt.Rows[i]["Assets"].ToString();
                    //List.VisitorType = dt.Rows[i]["VisitorType"].ToString().Trim();
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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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


        public List<Appointment> GetAppointmentDeatilsByEmpID(long Empid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "BIND".ToString());
                cmd.Parameters.AddWithValue("@Empid", Empid);

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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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


        public List<Appointment> GetPassDeatilsByVisiId(long Visiid)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "Pass".ToString());
                cmd.Parameters.AddWithValue("@Visiid", Visiid);

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
                    //List.catName = dt.Rows[i]["catName"].ToString();
                    //List.BranchID_visit = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    //List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    //List.Deptid_visit = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    //List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    //List.Purpose_id = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    //List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    //List.Empid = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.HostName = dt.Rows[i]["HostName"].ToString();
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
                    List.Temprature = Convert.ToDecimal(dt.Rows[i]["Temprature"].ToString());
                    //List.Host = Convert.ToInt64(dt.Rows[i]["Host"].ToString());
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

        public List<Appointment> GetAppointmentDeatilsByBranch(string BranchName)
        {
            try
            {
                DataTable dt = new DataTable();
                List<Appointment> Lists = new List<Appointment>();

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");

                cmd.Parameters.AddWithValue("@Command", "BranchSerach".ToString());
                cmd.Parameters.AddWithValue("@BranchName", BranchName);

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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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
                    List.VisiCatID = Convert.ToInt64(dt.Rows[i]["Visi_cat_id"].ToString());
                    List.VisiBranchID = Convert.ToInt64(dt.Rows[i]["BranchID_visit"].ToString());
                    List.BranchName = dt.Rows[i]["BranchName"].ToString();
                    List.VisiDeptID = Convert.ToInt64(dt.Rows[i]["Deptid_visit"].ToString());
                    List.DeptName = dt.Rows[i]["DeptName"].ToString();
                    List.PurposeID = Convert.ToInt64(dt.Rows[i]["Purpose_id"].ToString());
                    List.Purpose = dt.Rows[i]["Purpose"].ToString();
                    List.VisiteeID = Convert.ToInt64(dt.Rows[i]["Empid"].ToString());
                    List.VisiEmailID = dt.Rows[i]["VisiEmailID"].ToString();
                    List.AppDatefrom = Convert.ToDateTime(dt.Rows[i]["AppDatefrom"].ToString());
                    List.AppDateTo = Convert.ToDateTime(dt.Rows[i]["AppDateTo"].ToString());
                    List.AppTimefrom = Convert.ToDateTime(dt.Rows[i]["AppTimefrom"].ToString());
                    List.AppTimeto = Convert.ToDateTime(dt.Rows[i]["AppTimeto"].ToString());
                    List.IDProof = dt.Rows[i]["IDProof"].ToString();
                    List.IDProofNumber = dt.Rows[i]["IDProofNumber"].ToString();
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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
                    List.Badge_no = Convert.ToInt64(dt.Rows[i]["Badge_no"].ToString());
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

        public List<AppointmentCount> GetVisitorCount(string SearchDate)
        {
            try
            {
                DataTable dt = new DataTable();

                List<AppointmentCount> Lists = new List<AppointmentCount>();
                SqlCommand cmd = new SqlCommand("SP_CategoryMaster");

                cmd.Parameters.AddWithValue("@Command", "VisiCount".ToString());
                cmd.Parameters.AddWithValue("@SearchDate", SearchDate);

                dt = SqlHelper.ExtecuteProcedureReturnDataTable(cmd);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AppointmentCount VCount = new AppointmentCount();

                    //  VCount.Scheduled = Convert.ToInt64(dt.Rows[0]["Scheduled"].ToString());
                    VCount.Visited = Convert.ToInt64(dt.Rows[0]["Visited"].ToString());
                    VCount.WalkIn = Convert.ToInt64(dt.Rows[0]["WalkIn"].ToString());
                    VCount.InPremises = Convert.ToInt64(dt.Rows[0]["InPremises"].ToString());

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

        public Int32 RemoveAppointment(Int64 Visiid)
        {
            Int32 Result = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SP_AppointmentDetails");
                cmd.Parameters.AddWithValue("@Command", "DELETE");
                cmd.Parameters.AddWithValue("@Visiid", Visiid.ToString());


                Result = SqlHelper.ExtecuteProcedureReturnInteger(cmd);

                return Result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}