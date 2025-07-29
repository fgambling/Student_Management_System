using Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Login page code-behind class for user authentication.
/// This page handles user login functionality, validates credentials,
/// and manages user sessions upon successful authentication.
/// </summary>
public partial class user_login : System.Web.UI.Page
{
    /// <summary>
    /// Page load event handler.
    /// Initializes the login page and performs any necessary setup.
    /// </summary>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">Event arguments</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Page initialization logic can be added here
        // Currently no specific initialization is required
    }

    /// <summary>
    /// Handles the login button click event.
    /// Validates user credentials and manages authentication flow.
    /// </summary>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">Event arguments</param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Extract and trim user input
        string username = this.username.Text.Trim();
        string password = this.password.Text.Trim();

        // Attempt to authenticate the user
        if (Student.BLL.User.Login(username, password))
        {
            // Authentication successful - retrieve user details
            Student.Model.User user = Student.BLL.User.Getuser(username);

            // Check if the user account is active
            if (user.State == 1)
            {
                // Account is active - create user session and redirect to dashboard
                SessionHelper.SetSession("user", user);
                JsHelper.Redirect("/user/index.aspx");
            }
            else
            {
                // Account is inactive - show error message and redirect back to login
                JsHelper.AlertAndRedirect("This account is inactive", "/user/login.aspx");
            }
        }
        else
        {
            // Authentication failed - show error message and redirect back to login
            JsHelper.AlertAndRedirect("Login failed", "/user/login.aspx");
        }
    }

    /// <summary>
    /// Handles the password text box change event.
    /// Currently not implemented but available for future enhancements.
    /// </summary>
    /// <param name="sender">The source of the event</param>
    /// <param name="e">Event arguments</param>
    protected void password_TextChanged(object sender, EventArgs e)
    {
        // Password change event handler
        // Can be used for real-time password validation or strength checking
    }
}