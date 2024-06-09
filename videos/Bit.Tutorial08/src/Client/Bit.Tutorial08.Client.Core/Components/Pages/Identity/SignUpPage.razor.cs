using Bit.Tutorial08.Client.Core.Controllers.Identity;
using Bit.Tutorial08.Shared.Dtos.Identity;

namespace Bit.Tutorial08.Client.Core.Components.Pages.Identity;

public partial class SignUpPage
{
    [AutoInject] IIdentityController identityController = default!;

    private bool isLoading;
    private bool isSignedUp;
    private string? signUpMessage;
    private BitSeverity signUpMessageType;
    private SignUpRequestDto signUpModel = new();

    private async Task DoSignUp()
    {
        if (isLoading) return;

        isLoading = true;
        signUpMessage = null;

        try
        {
            await identityController.SignUp(signUpModel, CurrentCancellationToken);

            isSignedUp = true;
        }
        catch (ResourceValidationException e)
        {
            signUpMessageType = BitSeverity.Error;
            signUpMessage = string.Join(Environment.NewLine, e.Payload.Details.SelectMany(d => d.Errors).Select(e => e.Message));
        }
        catch (KnownException e)
        {
            signUpMessage = e.Message;
            signUpMessageType = BitSeverity.Error;
        }
        finally
        {
            isLoading = false;
        }
    }

    private async Task DoResendLink()
    {
        if (isLoading) return;

        isLoading = true;
        signUpMessage = null;

        try
        {
            await identityController.SendConfirmationEmail(new() { Email = signUpModel.Email }, CurrentCancellationToken);

            signUpMessageType = BitSeverity.Success;
            signUpMessage = Localizer[nameof(AppStrings.ResendConfirmationLinkMessage)];
        }
        catch (KnownException e)
        {
            signUpMessage = e.Message;
            signUpMessageType = BitSeverity.Error;
        }
        finally
        {
            isLoading = false;
        }
    }
}
