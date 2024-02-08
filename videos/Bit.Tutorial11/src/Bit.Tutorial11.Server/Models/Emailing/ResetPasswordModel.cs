namespace Bit.Tutorial11.Server.Models.Emailing;

public class ResetPasswordModel
{
    public string? DisplayName { get; set; }

    public Uri? ResetPasswordLink { get; set; }
}
