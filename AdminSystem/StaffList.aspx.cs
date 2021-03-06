﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

public partial class _1_List : System.Web.UI.Page
{
    protected void lstStaffNumberList_SelectedIndexChanged(object sender, EventArgs e) { }

    protected void Page_Load(object sender, EventArgs e)
    {
        btnConfirmDelete.Visible = false;

        if (IsPostBack == false)
        {
            DisplayStaff();
        }
    }

    void DisplayStaff()
    {
        clsStaffCollection StaffMembers = new clsStaffCollection();
        lstStaffList.DataSource = StaffMembers.StaffList;
        lstStaffList.DataValueField = "StaffNumber";
        lstStaffList.DataTextField = "FirstName";
        lstStaffList.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Session["StaffNumber"] = -1;
        Response.Redirect("StaffDataEntry.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        int StaffNumber;
        if (lstStaffList.SelectedIndex != -1)
        {
            StaffNumber = Convert.ToInt32(lstStaffList.SelectedValue);
            Session["StaffNumber"] = StaffNumber;
            Response.Redirect("StaffDataEntry.aspx");
        }
        else
        {
            lblError.Text = "No record selected";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstStaffList.SelectedIndex != -1)
        {
            if (btnConfirmDelete.Visible == false)
            {
                btnConfirmDelete.Visible = true;
                btnAbortDelete.Visible = true;
            }
            else if (btnConfirmDelete.Visible == true)
            {
                btnConfirmDelete.Visible = false;
            }
        }
        else
        {
            lblError.Text = "No record selected";
        }
    }

    protected void btnConfirmDelete_Click(object sender, EventArgs e)
    {
        clsStaffCollection StaffList = new clsStaffCollection();
        StaffList.ThisStaff.Find(Convert.ToInt32(lstStaffList.SelectedValue));
        StaffList.Delete();
        btnConfirmDelete.Visible = false;
        Response.Redirect("StaffList.aspx");
    }

    protected void btnApply_Click(object sender, EventArgs e)
    {
        clsStaffCollection Staff = new clsStaffCollection();
        Staff.ReportByFirstName(txtFirstNameFilter.Text);
        lstStaffList.DataSource = Staff.StaffList;
        lstStaffList.DataValueField = "StaffNumber";
        lstStaffList.DataTextField = "FirstName";
        lstStaffList.DataBind();
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clsStaffCollection Staff = new clsStaffCollection();
        Staff.ReportByFirstName("");
        txtFirstNameFilter.Text = "";
        lstStaffList.DataSource = Staff.StaffList;
        lstStaffList.DataValueField = "StaffNumber";
        lstStaffList.DataTextField = "FirstName";
        lstStaffList.DataBind();
    }


    protected void btnView_Click(object sender, EventArgs e)
    {
        int StaffNumber;
        if (lstStaffList.SelectedIndex != -1)
        {
            StaffNumber = Convert.ToInt32(lstStaffList.SelectedValue);
            Session["StaffNumber"] = StaffNumber;
            Response.Redirect("StaffViewer.aspx");
        }
        else
        {
            lblError.Text = "No record selected";
        }
    }

    protected void btnAbortDelete_Click(object sender, EventArgs e)
    {
        btnConfirmDelete.Visible = false;
        btnAbortDelete.Visible = false;
    }
}