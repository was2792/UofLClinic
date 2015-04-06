<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Vaccines_and_Travel_Clinic.Models.Calendar>" %>

<!DOCTYPE html>

<html>
<body>
  <% Html.BeginForm("Save", "CalendarController"); %>
    <div>
      <%= Html.TextArea("text", Model.text, 5, 42, null)%>
      </div>
      <%= Html.Hidden("id", Model.id)%>
      <div>
        From
        <%= Html.TextBox("start_date", Model.start_date, new { @readonly = "readonly" })%>
        To
        <%= Html.TextBox("end_date", Model.end_date, new { @readonly = "readonly" })%>
      </div>
      <%= Html.Hidden("user_id", Model.user_id)%>
      <p>
        <input type="submit" name="actionButton" value="Save" />
        <input type="button" onclick="lightbox.close()/* helper-method, only available in custom lightbox */" value="Close" />
        <input type="submit" name="actionButton" value="Delete" />
      </p>
  <% Html.EndForm(); %>
</body>
</html>
