using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string pickup = txtPickup.Text;
        string dropoff = txtDropoff.Text;
        string pickupDate = txtPickupDate.Text;
        string dropoffDate = txtDropoffDate.Text;
        string pickupTime = txtPickupTime.Text;
        
    }
}