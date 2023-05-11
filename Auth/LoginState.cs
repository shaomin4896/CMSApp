using CaseManagementAPI.Models;

public class LoginState
{
    public bool IsLogin { get; set; } = false;
    public CmsUser User { get; set; }
}